'ﾌｧｲﾙ名：xxEN01X1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット一覧(ロット工順変更の子画面)　メインフォーム
'作成日：2006/05/12 (Fri) 15:32:21 N.Kasai
'更新日：2011/05/09 (Mon) 09:47:48 T.Oide
'備　考：
'　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01X1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01X1    ' ただ一つのフォームのインスタンスを保持する変数
    Private ReadOnly vbButtonFace   As Color = SystemColors.ControlLight   'NSYS vbButtonFace

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
    Public Shared Property Instance() As frmxxEN01X1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01X1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01X1)
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
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN01X1          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrproclist____Ver              As String = "03.01"                 'ﾛｯﾄ一覧
    '@↓2011/05/09 (Mon) 10:14:02 T.Oide **************************************************
    'Private Const CMstrmas_pdlist__Ver              As String = "02.02"                 '機種区分一覧取得
    Private Const CMstrmas_pdlist__Ver              As String = "03.00"                 '機種区分一覧取得
    '@↑2011/05/09 (Mon) 10:14:02 T.Oide **************************************************
    '@↓2011/05/09 (Mon) 10:45:39 T.Oide **************************************************
    'Private Const CMstrmas_flowlistVer              As String = "03.00"                 '種別区分一覧取得
    Private Const CMstrmas_flowlistVer              As String = "04.00"                 '種別区分一覧取得
    '@↑2011/05/09 (Mon) 10:45:39 T.Oide **************************************************

    '@vsfLotListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfSearchNo                  As Integer = 0                         '№
    Private Const CMlngvsfSearchKb                  As Integer = 1                         '保/停
    Private Const CMlngvsfSearchOpID                As Integer = 2                         '大工程
    Private Const CMlngvsfSearchStepID              As Integer = 3                         '小工程
    Private Const CMlngvsfSearchNowSt               As Integer = 4                         '状態
    Private Const CMlngvsfSearchLotID               As Integer = 5                         'ﾛｯﾄID
    Private Const CMlngvsfSearchPdID                As Integer = 6                         '機種
    Private Const CMlngvsfSearchFlowClass           As Integer = 7                         '種別
    Private Const CMlngvsfSearchCarrierID           As Integer = 8                         'ｷｬﾘｱID
    Private Const CMlngvsfSearchPriority            As Integer = 9                         '優先度
    Private Const CMlngvsfSearchLotPos              As Integer = 10                        'ﾛｯﾄ位置
    Private Const CMlngvsfSearchLotManagerName      As Integer = 11                        'ﾛｯﾄ担当
    Private Const CMlngvsfSearchWfNum               As Integer = 12                        'WF枚数
    Private Const CMlngvsfSearchChipNum             As Integer = 13                        'ﾁｯﾌﾟ数
    Private Const CMlngvsfSearchLotComments         As Integer = 14                        'ｺﾒﾝﾄ
    Private Const CMlngvsfSearchLotHold             As Integer = 15                        '保留区分
    Private Const CMlngvsfSearchLotStop             As Integer = 16                        '停止区分
    Private Const CMlngvsfSearchLcDirection         As Integer = 17                        '液晶方向
    Private Const CMlngvsfSearchReworkFlag          As Integer = 18                        'ﾘﾜｰｸﾌﾗｸﾞ
    Private Const CMlngvsfSearchProcFlag            As Integer = 19                        'ﾛｯﾄ種別ﾌﾗｸﾞ
    Private Const CMlngvsfSearchWfCarryFlag         As Integer = 20                        'WF移載中ﾌﾗｸﾞ
    Private Const CMlngvsfSearchProhibitedFlag      As Integer = 21                        'VerUp禁止(0：可、1:不可)
    Private Const CMlngvsfSearchProhibitedEmp       As Integer = 22                        '禁止設定者
    Private Const CMlngvsfSearchProhibitedDept      As Integer = 23                        '禁止設定者部署
    Private Const CMlngvsfSearchLotLastUpdate       As Integer = 24                        '最終更新日時



    '@vsfLotListの定数宣言(幅)
    Private Const CMlngvsfwSearchNo                 As Integer = 37                       '№
    Private Const CMlngvsfwSearchKb                 As Integer = 14                       '保/停区分
    Private Const CMlngvsfwSearchNowSt              As Integer = 87                       '状態
    Private Const CMlngvsfwSearchCarrierID          As Integer = 65                       'ｷｬﾘｱID
    Private Const CMlngvsfwSearchLotID              As Integer = 110                      'ﾛｯﾄID
    Private Const CMlngvsfwSearchPdID               As Integer = 110                      '機種
    Private Const CMlngvsfwSearchFlowClass          As Integer = 25                       '種別
    Private Const CMlngvsfwSearchPriority           As Integer = 25                       '優先順位
    Private Const CMlngvsfwSearchOpID               As Integer = 133                      '大工程
    Private Const CMlngvsfwSearchStepID             As Integer = 133                      '小工程
    Private Const CMlngvsfwSearchLotPos             As Integer = 133                      'ﾛｯﾄ位置
    Private Const CMlngvsfwSearchLotManagerName     As Integer = 133                      'ﾛｯﾄ担当
    Private Const CMlngvsfwSearchWfNum              As Integer = 133                      'WF枚数
    Private Const CMlngvsfwSearchChipNum            As Integer = 133                      'ﾁｯﾌﾟ数
    Private Const CMlngvsfwSearchLotComments        As Integer = 133                      'ｺﾒﾝﾄ
    Private Const CMlngvsfwSearchLotHold            As Integer = 133                      '保留区分
    Private Const CMlngvsfwSearchLotStop            As Integer = 133                      '停止区分
    Private Const CMlngvsfwSearchLcDirection        As Integer = 133                      '液晶方向
    Private Const CMlngvsfwSearchReworkFlag         As Integer = 133                      'ﾘﾜｰｸﾌﾗｸﾞ
    Private Const CMlngvsfwSearchProcFlag           As Integer = 133                      'ﾛｯﾄ種別ﾌﾗｸﾞ
    Private Const CMlngvsfwSearchWfCarryFlag        As Integer = 133                      'WF移載中ﾌﾗｸﾞ
    Private Const CMlngvsfwSearchProhibitedFlag     As Integer = 133                      'VerUp禁止(0：可、1:不可)
    Private Const CMlngvsfwSearchProhibitedEmp      As Integer = 133                      '禁止設定者
    Private Const CMlngvsfwSearchProhibitedDept     As Integer = 133                      '禁止設定者部署
    Private Const CMlngvsfwSearchLotLastUpdate      As Integer = 133                      '最終更新日時
                                                                 


    '@vsfLotListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsftSearchNo                 As String = " № "
    Private Const CMstrvsftSearchKb                 As String = ""                     '保/停区分
    Private Const CMstrvsftSearchNowSt              As String = "状態"
    Private Const CMstrvsftSearchCarrierID          As String = "キャリアID"
    Private Const CMstrvsftSearchLotID              As String = "ロットID"
    Private Const CMstrvsftSearchPdID               As String = "機種"
    Private Const CMstrvsftSearchFlowClass          As String = "種"
    Private Const CMstrvsftSearchPriority           As String = "優"
    Private Const CMstrvsftSearchOpID               As String = "大工程"
    Private Const CMstrvsftSearchStepID             As String = "小工程"
    Private Const CMstrvsftSearchLotPos             As String = "ロット位置"
    Private Const CMstrvsftSearchLotManagerName     As String = "ロット担当"
    Private Const CMstrvsftSearchWfNum              As String = "WF枚数"
    Private Const CMstrvsftSearchChipNum            As String = "チップ"
    Private Const CMstrvsftSearchLotComments        As String = "コメント"
    Private Const CMstrvsftSearchLotHold            As String = "保留区分"
    Private Const CMstrvsftSearchLotStop            As String = "停止区分"
    Private Const CMstrvsftSearchLcDirection        As String = "液晶方向"
    Private Const CMstrvsftSearchReworkFlag         As String = "ﾘﾜｰｸﾌﾗｸﾞ"
    Private Const CMstrvsftSearchProcFlag           As String = "ﾛｯﾄ種別ﾌﾗｸﾞ"
    Private Const CMstrvsftSearchWfCarryFlag        As String = "WF移載中ﾌﾗｸﾞ"
    Private Const CMstrvsftSearchProhibitedFlag     As String = "VerUp禁止"
    Private Const CMstrvsftSearchProhibitedEmp      As String = "禁止設定者"
    Private Const CMstrvsftSearchProhibitedDept     As String = "禁止設定者部署"
    Private Const CMstrvsftSearchLotLastUpdate      As String = "最終更新日時"


    '@ｸﾞﾘｯﾄﾞ共通宣言
    Private Const CMlngTHeight                      As Integer = 20                       'ﾀｲﾄﾙの高さ
    Private Const CMlngRHeight                      As Integer = 18                       '1明細の高さ
    Private Const CMlngTRow                         As Integer = 0                         'ﾀｲﾄﾙ行
    Private Const CMlngMaxCols                      As Integer = 25                        '最大列数

    '@保留/停止区分表示文字
    Private Const CMstrHo                           As String = "保"                    '保留表示
    Private Const CMstrTei                          As String = "停"                    '停止表示
    Private Const CMstrRi                           As String = "リ"                    'ﾘﾜｰｸ表示
    Private Const CMstrTsui                         As String = "追"                    '追加表示
    Private Const CMstrSen                          As String = "先"                    '先行表示
    Private Const CMstrIsai                         As String = "移"                    '移載表示

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbRowHeight                 As Integer = 17                       'ﾘｽﾄ行の高さ
    Private Const CMlngCmbDispCols1                 As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbDispCols2                 As Integer = 2                         'ｸﾞﾘｯﾄﾞ表示列数=2
    Private Const CMlngCmbValueCol0                 As Integer = 0                         '値取得個数=0
    Private Const CMlngCmbGroupCols                 As Integer = 1                         '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMlngCmbGridCol0                  As Integer = 0                         '名称列番=0
    Private Const CMlngCmbGridCol1                  As Integer = 1                         '名称列番=1
    Private Const CMlngCmbFontSize                  As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCMbSelectMode                As Integer = 1                         '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMstrCmbAddedComment              As String = " 項目選択"              '表示 文字列
    Private Const CMstrCmbAddedCommentNone          As String = "0 項目選択"             '表示 文字列「選択なし」
    Private Const CMlngCmbGetCol5                   As Integer = 5                         'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=5(ﾊﾞｯｸｶﾗｰ)

    '@種別ﾌﾗｸﾞ
    Private Const CMstrKindFlag1                    As String = "1"                     'ﾛｯﾄ工順変更
    Private Const CMstrKindFlag2                    As String = "2"                     '組立工順一時保存

    '@その他
    Private Const CMstrLotHoldFlgOn                 As String = "1"                     '保留ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrLotStopFlgOn                 As String = "1"                     '停止ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrReworkFlgOn                  As String = "1"                     'ﾘﾜｰｸﾌﾗｸﾞON
    Private Const CMstrLotReworkFlgOn2              As String = "2"                     '追加ﾌﾗｸﾞON
    Private Const CMlngSearch0                      As Integer = 0                         '検索条件(機種/種別/流動区分)
    Private Const CMlngSearch1                      As Integer = 1                         '検索条件(ﾛｯﾄID)
    Private Const CMlngSearch2                      As Integer = 2                         '検索条件(ｷｬﾘｱID)

    Private Const CMlngFlowClass0                   As Integer = 0                         '流動区分(流動前)
    Private Const CMlngFlowClass1                   As Integer = 1                         '流動区分(流動中)
    Private Const CMstrStateNotEdit                 As String = "未編集"
    Private Const CMlngStateNotEditColor            As Integer = &HFFECCC                  '未編集色

    '@文字制限
    Private Const CMlngKeyBackSpace                 As Integer = 8                         'ﾊﾞｯｸｽﾍﾟｰｽのｱｽｷｰｺｰﾄﾞ
    Private Const CMlngKeyReturn                    As Integer = 13                        'ｴﾝﾀｰｷｰのｱｽｷｰｺｰﾄﾞ
    Private Const CMlngKeyAsciiAster                As Integer = 42                        'ｱｽｷｰｺｰﾄﾞ-*
    Private Const CMlngKeyAsciiNum0                 As Integer = 48                        'ｱｽｷｰｺｰﾄﾞ-0
    Private Const CMlngKeyAsciiNum9                 As Integer = 57                        'ｱｽｷｰｺｰﾄﾞ-9
    Private Const CMlngKeyAsciiUppA                 As Integer = 65                        'ｱｽｷｰｺｰﾄﾞ-A
    Private Const CMlngKeyAsciiUppZ                 As Integer = 90                        'ｱｽｷｰｺｰﾄﾞ-Z
    Private Const CMlngKeyAsciiUnderBar             As Integer = 95                        'ｱｽｷｰｺｰﾄﾞ-_
    Private Const CMlngKeyAsciiLowA                 As Integer = 97                        'ｱｽｷｰｺｰﾄﾞ-a
    Private Const CMlngKeyAsciiLowZ                 As Integer = 122                       'ｱｽｷｰｺｰﾄﾞ-z
    Private Const CMstrUnderBar                     As String = "_"
    Private Const CMstrAsciiAster                   As String = "*"

    '@ｺﾒﾝﾄｽｸﾛｰﾙ制御用
    Private Const CMlngMaxDispRow                   As Integer = 6                         'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mblncmbValidateEvent                    As Boolean                          'ｺﾝﾎﾞValidate発生ﾌﾗｸﾞ(Ture:発生、False:発生なし)
    Private mtypChgSort                             As ChgSort                          'ｿｰﾄ保持用
    Private mblnFormLoadFlag                        As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private mtypProductList                         As List(Of ProductList)             '機種ﾘｽﾄ構造体
    Private mlngProductCnt                          As Integer                          '機種ﾘｽﾄ数
    Private mtypFlowClassList                       As List(Of DivisionList)            '種別ﾘｽﾄ構造体
    Private mlngFlowClassCnt                        As Integer                          '種別ﾘｽﾄ数
    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策   
    Private mblnCloseFromControlMenu                As Boolean                          'NSYS システムコマンドでの画面クローズ   
    Private mblnWindowClose                         As Boolean                          'NSYS WindowCloseフラグ
    Private vsfLotlistRowBeforeSort                 As Integer                          'NSYS ｿｰﾄ時の選択行退避
    Private blnKeepNoneRedrawFlg                    As Boolean                          'NSYS Redrawしない継続ﾌﾗｸﾞ
    Private blnDblClickFlg                          As Boolean                          'NSYS ﾀﾞﾌﾞﾙｸﾘｯｸ処理中ﾌﾗｸﾞ
    Private mstrPreOptSearchName                    As String                           'NSYS 前回検索ﾗｼﾞｵﾎﾞﾀﾝ選択名

    '@ﾛｯﾄ一覧情報構造体
    Private Structure SearchResult
        Dim strNo                                       As String                           '行№
        Dim strKb                                       As String                           '保留/停止区分
        Dim strLotID                                    As String                           'ﾛｯﾄID
        Dim strOpID                                     As String                           '大工程
        Dim strStepID                                   As String                           '小工程
        Dim strCurrentStatus                            As String                           '現在状態
        Dim strLotPos                                   As String                           'ﾛｯﾄ位置
        Dim strCarrierId                                As String                           'ｷｬﾘｱID
        Dim strColKb                                    As String                           '区分
        Dim strPdId                                     As String                           '機種
        Dim strFrowClass                                As String                           '種別
        Dim strLotHold                                  As String                           '保留区分
        Dim strLotStop                                  As String                           '停止区分
        Dim strLcDirection                              As String                           '液晶方向
        Dim strReworkFlag                               As String                           'ﾘﾜｰｸﾌﾗｸﾞ
        Dim strProcFlag                                 As String                           'ﾛｯﾄ種別ﾌﾗｸﾞ
        Dim strWfCarryFlag                              As String                           'WF移載中ﾌﾗｸﾞ
        Dim strVerUpProhibitedFlag                      As String                           'VerUp禁止(0:可、1:不可)
        Dim strProhibitedEmpName                        As String                           '禁止設定者
        Dim strProhibitedDeptName                       As String                           '禁止設定者部署
        Dim strLotLastUpdate                            As String                           '最終更新日時
    End Structure

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
    '作成日：2006/05/12 (Fri) 16:12:16 N.Kasai
    '更新日：2007/07/03 (Tue) 10:06:54 N.Kasai
    '備　考：
    '　　　：2007/07/03 (Tue) 10:06:54 N.Kasai  機種ｺﾝﾎﾞ複数選択(№02006)
    Private Sub Form_Load()

        Dim lblnAns             As Boolean          '結果格納
        Dim lstrEventName       As String           'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)
        Dim lstrClassDivision   As String           '処理区分
        
        Try

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            'NSYS 選択ラジオ初期値
            mstrPreOptSearchName = optSearch0.Name 
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "Form_Load"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@ﾌﾗｸﾞ初期化
            mblnFormLoadFlag = False

            '@ﾒｲﾝﾌｫｰﾑの初期化
            Call prvfrmxxEN01X1_Init()

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
                 Me.CancelButton = cmdClose 
                Exit Sub
            End If
            
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
                Me.CancelButton = cmdClose 
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '作成日：2006/05/12 (Fri) 16:13:52 N.Kasai
    '更新日：2006/05/12 (Fri) 16:13:52
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
                       
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐
            If mblnFormLoadFlag = False Then
                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                '@機種情報ｾｯﾄ
                Call prvcmbPd_Disp()
                
                '@種別情報ｾｯﾄ
                Call prvcmbFlowClass_Disp()
                
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Activate"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2006/05/12 (Fri) 16:15:10 N.Kasai
    '更新日：2006/05/12 (Fri) 16:15:10
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

            Select Case e.KeyCode
                '@Enterの場合
                Case Keys.Return
                    Select Case ActiveControl.Name
                        Case vsfLotList.Name
                        '@一覧にﾌｫｰｶｽがある場合
                            With vsfLotList
                                '@ﾃﾞｰﾀ行の場合
                                If .Row >= .Rows.Fixed Then
                                    '@確定ﾎﾞﾀﾝの押下
                                    If cmdRegist.Enabled = True Then
                                        Call cmdRegist_Click(Me, New EventArgs)
                                    End If
                                End If
                            End With
                            
                        Case cmbPd.Name
                        '@機種にﾌｫｰｶｽがある場合
                            '@Validate処理へ
                            RemoveHandler cmbPD.Validating,AddressOf cmbPd_Validate
                            Call cmbPd_Validate(sender, New CancelEventArgs(True))
                            AddHandler cmbPD.Validating,AddressOf cmbPd_Validate
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                        
                        Case txtLotID.Name
                        '@LotID欄にﾌｫｰｶｽがある場合
                            '@Validate処理へ
                            RemoveHandler txtLotID.Validating,AddressOf txtLotID_Validate
                            Call txtLotID_Validate(sender, New CancelEventArgs(True))
                            AddHandler txtLotID.Validating,AddressOf txtLotID_Validate
                            '@ﾌｫｰｶｽ処理
                            If vsfLotList.Enabled = True Then
                                Call pubSetFocus(vsfLotList)
                            End If
                        
                        Case txtCarrierID.Name
                        '@CarrierID欄にﾌｫｰｶｽがある場合
                            '@Validate処理へ
                            RemoveHandler txtCarrierID.Validating,AddressOf txtCarrierID_Validate
                            Call txtCarrierID_Validate(sender, New CancelEventArgs(True))
                            AddHandler txtCarrierID.Validating,AddressOf txtCarrierID_Validate
                            '@ﾌｫｰｶｽ処理
                            If vsfLotList.Enabled = True Then
                                Call pubSetFocus(vsfLotList)
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
    '作成日：2006/05/12 (Fri) 16:15:30 N.Kasai
    '更新日：2006/05/12 (Fri) 16:15:30
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            
            
            '@構造体のｸﾘｱ
            'ｿｰﾄ保持用
            If IsNothing(mtypChgSort.typChgSortList) Then
                mtypChgSort.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort.typChgSortList.Clear
            End If

            '機種ﾘｽﾄ構造体
            If IsNothing(mtypProductList) = True Then
                mtypProductList = New List(Of ProductList)
            Else
                mtypProductList.Clear
            End If

            '種別ﾘｽﾄ構造体
             If IsNothing(mtypFlowClassList) = True Then
                mtypFlowClassList = New List(Of DivisionList)
            Else
                mtypFlowClassList.Clear
            End If
            
            '@変数のｸﾘｱ
            mlngProductCnt = 0
            mlngFlowClassCnt = 0

            '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄとの関連付けを解除
            

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
    '作成日：2006/05/12 (Fri) 16:15:44 N.Kasai
    '更新日：2006/05/12 (Fri) 16:15:44
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
    '作成日：2006/05/12 (Fri) 16:17:29 N.Kasai
    '更新日：2006/05/12 (Fri) 16:17:29
    '備　考：機種ｺﾝﾎﾞのValideteにて種別にﾌｫｰｶｽがあたらない為、強引にﾌｫｰｶｽ設定する
    Private Sub optFlowClass_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles optFlowClass0.Enter,optFlowClass1.Enter

        Try
           
            Select Case sender.name 
                '@流動前
                Case optFlowClass0.Name
                    '@機種Validate発生ﾌﾗｸﾞの場合
                    If mblncmbValidateEvent = True Then
                        If cmbFlowClass.Enabled = True Then
                            '@種別へﾌｫｰｶｽ設定
                            Call pubSetFocus(cmbFlowClass)
                            mblncmbValidateEvent = False
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
    '機　能：流動区分(流動前/流動中)
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 16:17:56 N.Kasai
    '更新日：2006/05/12 (Fri) 16:17:56
    '備　考：
    Private Sub optFlowClass_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optFlowClass0.Click,optFlowClass1.Click

        Try

            'NSYS 選択ﾗｼﾞｵが前回と同じ場合は処理を抜ける
            If sender.Name = mstrPreOptSearchName Then
                Exit Sub
            Else
                '異なる場合は今回選択ﾗｼﾞｵ名を退避
                mstrPreOptSearchName = sender.Name
            End If
            
            
            '@ｸﾞﾘｯﾄﾞの初期化
            With vsfLotList
                '@描画なし
                .Redraw = false
                '@ｸﾘｱ
                
                '@初期行/列設定
                .Rows.Count = .Rows.Fixed
                '@直接描画
                .Redraw = True
            End With
            
            '@ｺﾒﾝﾄ欄のｸﾘｱ
            txtComments.Text = vbNullString
            
            '@情報取得日時表示
            lblGetInfoDate.Text = vbNullString
            '@該当件数ﾗﾍﾞﾙに取得件数を表示
            lblListCnt.Text = vbNullString
            
            '@ﾎﾞﾀﾝの使用許可
            cmdRegist.Enabled = False      '確定ﾎﾞﾀﾝ
            
            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearch_Chk()

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
    '作成日：2006/05/12 (Fri) 17:09:03 N.Kasai
    '更新日：2006/05/12 (Fri) 17:09:03
    '備　考：
    Private Sub optSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optSearch0.Click,optSearch1.Click,optSearch2.Click

        Try

            'NSYS 選択ﾗｼﾞｵが前回と同じ場合は処理を抜ける
            If sender.Name = mstrPreOptSearchName Then
                Exit Sub
            Else
                '異なる場合は今回選択ﾗｼﾞｵ名を退避
                mstrPreOptSearchName = sender.Name
            End If
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@ｸﾞﾘｯﾄﾞの初期化
            With vsfLotList
                '@描画なし
                .Redraw = false
                '@ｸﾘｱ
                
                '@初期行/列設定
                .Rows.Count = .Rows.Fixed
                '@直接描画
                .Redraw = True
                '@ﾛｯｸ
                .Enabled = False
            End With
            
            '@ｺﾒﾝﾄ欄のｸﾘｱ
            txtComments.Text = vbNullString
            
            '@ﾎﾞﾀﾝの使用許可
            cmdRegist.Enabled = False      '確定ﾎﾞﾀﾝ
            
            '@検索ﾎﾞﾀﾝの使用許可
            Call prvcmdSearch_Chk()
            
            Select Case sender.Name
                '@機種・種別が選択された場合
                Case optSearch0.Name
                    '@機種・種別使用可
                    cmbPD.Enabled = True
                    cmbFlowClass.Enabled = False
                    cmbPD.BackColor = Color.White
                    cmbFlowClass.BackColor = vbButtonFace
                    optFlowClass0.Enabled = True
                    optFlowClass1.Enabled = True
                    optFlowClass0.Checked = True
                    fraKisyu.Enabled = True
                    
                    '@ﾛｯﾄID使用不可
                    txtLotID.Text = vbNullString
                    txtLotID.Enabled = False
                    txtLotID.BackColor = vbButtonFace
                    
                    '@ｷｬﾘｱID使用不可
                    txtCarrierID.Text = vbNullString
                    txtCarrierID.Enabled = False
                    txtCarrierID.BackColor = vbButtonFace
                    
                    '@情報取得日時表示
                    lblGetInfoDate.Text = vbNullString
                    '@該当件数ﾗﾍﾞﾙに取得件数を表示
                    lblListCnt.Text = vbNullString
                    
                '@ﾛｯﾄIDが選択された場合
                Case optSearch1.Name
                    '@機種・種別使用不可
                    cmbPd.ListIndex = -1
                    cmbPd.Enabled = False
                    cmbPd.BackColor = vbButtonFace
                    cmbFlowClass.Text = vbNullString
                    cmbFlowClass.Enabled = False
                    cmbFlowClass.BackColor = vbButtonFace
                    optFlowClass0.Checked = False
                    optFlowClass1.Checked = False
                    optFlowClass0.Enabled = False
                    optFlowClass1.Enabled = False
                    fraKisyu.Enabled = False
                    
                    '@ﾛｯﾄID使用可
                    txtLotID.Enabled = True
                    txtLotID.BackColor = Color.White
                    
                    '@ｷｬﾘｱID使用不可
                    txtCarrierID.Text = vbNullString
                    txtCarrierID.Enabled = False
                    txtCarrierID.BackColor = vbButtonFace
                    
                    '@情報取得日時表示
                    lblGetInfoDate.Text = vbNullString
                    '@該当件数ﾗﾍﾞﾙに取得件数を表示
                    lblListCnt.Text = vbNullString
                    
                '@ｷｬﾘｱIDが選択された場合
                Case optSearch2.Name
                    cmbPd.ListIndex = -1
                    cmbPd.Enabled = False
                    cmbPd.BackColor = vbButtonFace
                    cmbFlowClass.Text = vbNullString
                    cmbFlowClass.Enabled = False
                    cmbFlowClass.BackColor = vbButtonFace
                    optFlowClass0.Checked = False
                    optFlowClass1.Checked = False
                    optFlowClass0.Enabled = False
                    optFlowClass1.Enabled = False
                    fraKisyu.Enabled = False
                    
                    '@ﾛｯﾄID使用不可
                    txtLotID.Text = vbNullString
                    txtLotID.Enabled = False
                    txtLotID.BackColor = vbButtonFace
                    
                    '@ｷｬﾘｱID使用可
                    txtCarrierID.Enabled = True
                    txtCarrierID.BackColor = Color.White
                    
                    '@情報取得日時表示
                    lblGetInfoDate.Text = vbNullString
                    '@該当件数ﾗﾍﾞﾙに取得件数を表示
                    lblListCnt.Text = vbNullString
                    
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
    '作成日：2006/05/15 (Mon) 15:57:15 N.Kasai
    '更新日：2006/05/15 (Mon) 15:57:15
    '備　考：
    Private Sub cmbPd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.Change
        
        Try
                        
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@ｸﾞﾘｯﾄﾞの初期化
            With vsfLotList
                '@描画なし
                .Redraw = False
                '@ｸﾘｱ
                
                '@初期行/列設定
                .Rows.Count = .Rows.Fixed
                '@直接描画
                .Redraw = True
            End With
            
            '@ｺﾒﾝﾄ欄のｸﾘｱ
            txtComments.Text = vbNullString
            
            '@ﾎﾞﾀﾝの使用許可
            cmdRegist.Enabled = False       '確定ﾎﾞﾀﾝ
            cmdSearch.Enabled = False       '最新取得ﾎﾞﾀﾝ

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
    '作成日：2006/05/15 (Mon) 15:58:21 N.Kasai
    '更新日：2006/05/15 (Mon) 15:58:21
    '備　考：
    Private Sub cmbPd_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.CloseUp

        Try
            

            '@空欄 or 0項目以外の場合
            If cmbPd.Text <> vbNullString And _
                cmbPd.Text <> CMstrCmbAddedCommentNone Then
                '@Validate処理
                RemoveHandler cmbPD.Validating,AddressOf cmbPd_Validate
                Call cmbPd_Validate(sender , New CancelEventArgs(False))
                AddHandler cmbPD.Validating,AddressOf cmbPd_Validate
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
    '作成日：2006/05/15 (Mon) 15:59:04 N.Kasai
    '更新日：2006/05/15 (Mon) 15:59:04
    '備　考：
    Private Sub cmbPd_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPd.Validating

        Try
            

            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            

            '@機種ｺﾝﾎﾞ選択可否
            If cmbPd.Text = vbNullString Or _
                cmbPd.Text = CMstrCmbAddedCommentNone Then
                '@空欄 or 0項目の場合
                Exit Sub
            End If
            
            '@取得情報を種別一覧へｾｯﾄ
            Call prvcmbFlowClass_Disp()

            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearch_Chk()
            
            '@種別を有効にする
            cmbFlowClass.Enabled = True
            cmbFlowClass.BackColor = Color.White
            If ActiveControl.Name = cmbPD.Name 
             Call pubSetFocus(cmbFlowClass)
            End if
            
            '@種別へ強制ﾌｫｰｶｽ設定
            mblncmbValidateEvent = True
            
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
    '作成日：2006/05/15 (Mon) 15:59:23 N.Kasai
    '更新日：2006/05/15 (Mon) 15:59:23
    '備　考：
    Private Sub cmbFlowClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFlowClass.Change
        
        Try
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@ｸﾞﾘｯﾄﾞの初期化
            With vsfLotList
               '@描画なし
                .Redraw = False
                '@ｸﾘｱ
                '@初期行/列設定
                .Rows.Count = .Rows.Fixed
                '@直接描画
                .Redraw = True
            End With
            
            '@ｺﾒﾝﾄ欄のｸﾘｱ
            txtComments.Text = vbNullString
            
            '@ﾎﾞﾀﾝの使用許可
            cmdRegist.Enabled = False      '確定ﾎﾞﾀﾝ
            
            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearch_Chk()

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
    '作成日：2006/05/15 (Mon) 16:00:26 N.Kasai
    '更新日：2006/05/15 (Mon) 16:00:26
    '備　考：
    Private Sub cmbFlowClass_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFlowClass.CloseUp

        Try
            
            '@Validate処理へ
            If cmbFlowClass.Text <> vbNullString Then
                RemoveHandler cmbFlowClass.Validating,AddressOf cmbFlowClass_Validate
                Call cmbFlowClass_Validate(sender, New CancelEventArgs(True)) 
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
    '作成日：2006/05/15 (Mon) 16:03:36 N.Kasai
    '更新日：2006/05/15 (Mon) 16:03:36
    '備　考：
    Private Sub cmbFlowClass_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbFlowClass.Validating

        Try
           
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            

            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearch_Chk()

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

    '関数名：txtCarrierID_Change
    '機　能：ｷｬﾘｱID 変更
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/22 (Mon) 13:12:17 N.Kasai
    '更新日：2006/05/22 (Mon) 13:12:17
    '備　考：
    Private Sub txtCarrierID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID.Change

        Try
            

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@ｸﾞﾘｯﾄﾞの初期化
            With vsfLotList
                '@描画なし
                .Redraw = False
                '@ｸﾘｱ
                '@初期行/列設定
                .Rows.Count = .Rows.Fixed
                '@直接描画
                .Redraw = True
            End With
            
            '@ｺﾒﾝﾄ欄のｸﾘｱ
            txtComments.Text = vbNullString
            
            '@ﾎﾞﾀﾝの使用許可
            cmdRegist.Enabled = False      '確定ﾎﾞﾀﾝ
            
            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearch_Chk()

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtCarrierID_Change"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_Validate
    '機　能：ｷｬﾘｱID変更処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/05/22 (Mon) 13:19:07 N.Kasai
    '更新日：2006/05/22 (Mon) 13:19:07
    '備　考：
    Private Sub txtCarrierID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierID.Validating
        Dim blnMovedFocusFlg         As Boolean 'NSYS ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが自身の処理かTabまたはShift+Tabで発生した場合かのﾌﾗｸﾞ
        Dim lstrNowActiveControlName As String  'NSYS Validate呼び出し時のActiveControl名

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            
            '@ｷｬﾘｱID入力判定
            If txtCarrierID.Text = vbNullString Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ             
                If txtCarrierID.NowByte < txtCarrierID.ChrMaxByte Then
                  '@表示ﾒｯｾｰｼﾞ変換
                   pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                  '@"キャリアIDは6桁で入力してください。"
                  Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                  e.Cancel = True
                 '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                 Call pubSetFocus(txtCarrierID)
                
                 Exit Sub
              End If

             'NSYS ﾗｼﾞｵﾎﾞﾀﾝ変更から呼び出された場合
            lstrNowActiveControlName = ActiveControl.Name
            If lstrNowActiveControlName = optSearch0.Name _
                Or lstrNowActiveControlName = optSearch1.Name _
                Or lstrNowActiveControlName = optSearch2.Name Then

                'NSYS 前回ﾗｼﾞｵ選択値と異なる場合は処理を抜ける
                If mstrPreOptSearchName <> lstrNowActiveControlName Then
                    Exit Sub
                End If
            End If
            
            'NSYS ActiveControlによるcmdSearch_Click内でのpubSetFocusを実行するかの判定
            If ActiveControl.Name = txtCarrierID.Name Then
                blnMovedFocusFlg = False
            Else
                blnMovedFocusFlg = True
            End If
           
            '@最新取得
            Call cmdSearch_Click(sender, e, blnMovedFocusFlg)
            
            '@ﾌｫｰｶｽの制御 NSYS ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが自身の場合の条件を追加
            If blnMovedFocusFlg = False AndAlso vsfLotList.Enabled = True Then
                Call pubSetFocus(vsfLotList)
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtCarrierID_Validate"      '処理名
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
    '作成日：2006/05/15 (Mon) 16:04:08 N.Kasai
    '更新日：2006/05/15 (Mon) 16:04:22
    '備　考：
    Private Sub txtLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotID.Change

        Try
            

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@ｸﾞﾘｯﾄﾞの初期化
            With vsfLotList
                '@描画なし
                .Redraw = False
                '@ｸﾘｱ
                '@初期行/列設定
                .Rows.Count = .Rows.Fixed
                '@直接描画
                .Redraw = True
            End With
            
            '@ｺﾒﾝﾄ欄のｸﾘｱ
            txtComments.Text = vbNullString
            
            '@ﾎﾞﾀﾝの使用許可
            cmdRegist.Enabled = False      '確定ﾎﾞﾀﾝ
            
            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearch_Chk()

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
    '作成日：2006/05/15 (Mon) 16:05:26 N.Kasai
    '更新日：2006/05/15 (Mon) 16:05:26
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
    '作成日：2006/05/15 (Mon) 16:06:04 N.Kasai
    '更新日：2006/05/15 (Mon) 16:06:04
    '備　考：
    Private Sub txtLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtLotID.Validating
            Dim blnMovedFocusFlg         As Boolean 'NSYS ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが自身の処理かTabまたはShift+Tabで発生した場合かのﾌﾗｸﾞ
            Dim lstrNowActiveControlName As String  'NSYS Validate呼び出し時のActiveControl名

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
                
               'NSYS ﾗｼﾞｵﾎﾞﾀﾝ変更から呼び出された場合
                lstrNowActiveControlName = ActiveControl.Name
                If lstrNowActiveControlName = optSearch0.Name _
                    Or lstrNowActiveControlName = optSearch1.Name _
                    Or lstrNowActiveControlName = optSearch2.Name Then

                    'NSYS 前回ﾗｼﾞｵ選択値と異なる場合は処理を抜ける
                    If mstrPreOptSearchName <> lstrNowActiveControlName Then
                        Exit Sub
                    End If
                End If

                'NSYS ActiveControlによるcmdSearch_Click内でのpubSetFocusを実行するかの判定
                If ActiveControl.Name = txtLotID.Name Then
                    blnMovedFocusFlg = False
                Else
                    blnMovedFocusFlg = True
                End If
                
                '@最新取得
                Call cmdSearch_Click(sender, e , blnMovedFocusFlg)

                'NSYS ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが自身の場合の条件を追加
                If blnMovedFocusFlg = False AndAlso vsfLotList.Enabled = True Then
                    Call pubSetFocus(vsfLotList)
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

    '関数名：cmdSearch_Click
    '機　能：最新取得ﾎﾞﾀﾝ　押下時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/15 (Mon) 16:08:48 N.Kasai
    '更新日：2006/05/15 (Mon) 16:08:48
    '備　考：
    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs,Optional ByVal blnMovedFocusFlg As Boolean = False) Handles cmdSearch.Click
        
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
            
            
            '@検索結果ﾘｽﾄの初期化
            Call prvvsfLotList_Init()
            
            
            
            '@MSG実行
            Select Case True
            
                Case Optsearch0.checked

                    Select Case True
                        Case optFlowClass0.checked
                            lstrLotFlowStatusID = Trim$(Str(CMlngFlowClass0))  '流動前
                        
                        Case optFlowClass1.checked
                            lstrLotFlowStatusID = Trim$(Str(CMlngFlowClass1))  '流動中
                    End Select
                    
                    
                    '@要求構造体へ情報を格納    '流動区分(0:流動前,1:流動中 2:流動終了 3:流動外以外)
                    With ltypProcLotListReq
                        .strSbID = pstrSBID                                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strAction = "0"                                                        'ｱｸｼｮﾝ(工順変更中ﾛｯﾄを含まない)
                        .strMsgVer = CMstrproclist____Ver                                       'Msgﾊﾞｰｼﾞｮﾝ
                        .strLotFlowStatusID = lstrLotFlowStatusID                               '流動区分
                        
                        '@機種指定
                        .lngPdCnt = cmbPd.ValueCount                                            'ｶｳﾝﾄ数
                        '@種別区分構造体作成
                        If .typPdList Is Nothing Then
                            .typPdList = New List(Of PDList) 
                        Else
                            .typPdList.Clear()
                        End If
                        lstrTemp = Split(cmbPd.Value, vbTab)
                        For llngCnt = LBound(lstrTemp) To UBound(lstrTemp)
                            Dim typPdListtmp As PDList = New PDList 
                            typPdListtmp.strPdId = lstrTemp(llngCnt) 
                            .typPdList.Add(typPdListtmp)                                        '機種ID
                        Next llngCnt

                        '@種別区分構造体作成
                        .lngFlowClassListCnt = cmbFlowClass.ValueCount                          '種別ｶｳﾝﾄ
                        If .typFlowClassList Is Nothing Then
                            .typFlowClassList = New List(Of FlowClassList) 
                        Else
                            .typFlowClassList.Clear
                        End If
                        lstrTemp = Split(cmbFlowClass.Value, vbTab)
                        For llngCnt = LBound(lstrTemp) To UBound(lstrTemp)
                            Dim typFlowClassListTmp As FlowClassList = New FlowClassList
                            typFlowClassListTmp.strFlowClass = lstrTemp(llngCnt) 
                            .typFlowClassList.Add(typFlowClassListTmp)                          '種別ID
                        Next llngCnt

                        .strLotID = vbNullString                                                'ﾛｯﾄID
                        .strCarrierId = vbNullString                                            'ｷｬﾘｱID
                    End With

                Case Optsearch1.checked
                    '@ﾛｯﾄIDが10桁ない場合
                    If Len(txtLotID.Text) < 10 Then
                        '@ﾛｯﾄID + "*"
                        lstrLotID = txtLotID.Text & CMstrAsciiAster
                    Else
                        lstrLotID = txtLotID.Text
                    End If
                    
                    '@要求構造体へ情報を格納    '流動区分(0:流動前,1:流動中 2:流動終了 3:流動外以外)
                    With ltypProcLotListReq
                        .strSbID = pstrSBID                                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strAction = "0"                                                        'ｱｸｼｮﾝ(工順変更中ﾛｯﾄを含まない)
                        .strMsgVer = CMstrproclist____Ver                                       'Msgﾊﾞｰｼﾞｮﾝ
                        .strLotFlowStatusID = "3"                                               '流動区分(流動外以外)
                        
                        '@種別区分構造体作成
                        .lngPdCnt = 0                                                           '機種ｶｳﾝﾄ
                        If .typPdList Is Nothing Then
                            .typPdList = New List(Of PDList) 
                        Else
                            .typPdList.Clear()
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
            
                Case Optsearch2.Checked
              
                    '@要求構造体へ情報を格納    '流動区分(0:流動前,1:流動中 2:流動終了 3:流動外以外)
                    With ltypProcLotListReq
                        .strSbID = pstrSBID                                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strAction = "0"                                                        'ｱｸｼｮﾝ(工順変更中ﾛｯﾄを含まない)
                        .strMsgVer = CMstrproclist____Ver                                       'Msgﾊﾞｰｼﾞｮﾝ
                        .strLotFlowStatusID = "3"                                               '流動区分(流動外以外)
                        
                        '@種別区分構造体作成
                        .lngPdCnt = 0                                                           '機種ｶｳﾝﾄ
                        If .typPdList Is Nothing Then
                            .typPdList = New List(Of PDList) 
                        Else
                            .typPdList.Clear()
                        End If

                        '@種別区分構造体作成
                        .lngFlowClassListCnt = 0                                                '種別ｶｳﾝﾄ
                        If .typFlowClassList Is Nothing Then
                            .typFlowClassList = New List(Of FlowClassList)
                        Else
                            .typFlowClassList.Clear
                       End If

                        .strLotID = vbNullString                                                'ﾛｯﾄID
                        .strCarrierId = txtCarrierID.Text                                       'ｷｬﾘｱID
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
                    Call prvvsfLotList_Disp(ltypProcLotListAns)
                    
                    'NSYS ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが自身かつﾌｫｰｶｽ移動により自身がﾌｫｰｶｽされていない場合
                    If ActiveControl.Name = cmdSearch.Name AndAlso blnMovedFocusFlg = False Then
                        Call pubSetFocus(vsfLotList)
                    End If
                Else
                    'NSYS 一覧0件の場合一覧が再描画されないためヘッダーのみ再描画を行う
                    vsfLotList.Redraw = True
                End If
                
                '@情報取得日時表示
                lblGetInfoDate.Text = Format$(Now, CPstrDateFormat)

                '@該当件数ﾗﾍﾞﾙに取得件数を表示
                lblListCnt.Text = Format$(ltypProcLotListAns.lngProcLotListCnt, CPstrDateFormatKanma)

            Else
                '@ﾛｯﾄ一覧取得に失敗
                
                
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
    '作成日：2006/05/15 (Mon) 16:10:14 N.Kasai
    '更新日：2009/12/08 (Tue) 17:21:37 H.Hayashi
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim llngCnt                 As Integer               'ｶｳﾝﾀ
        Dim llngRowCnt              As Integer               'ｶｳﾝﾀ
        Dim llngFindRow             As Integer               '工順変更中ﾛｯﾄﾘｽﾄの既存行(-1:なし、1以上:あり)
        Dim llngRow                 As Integer               '選択行
        Dim ltypSearchResult        As List(Of SearchResult) 'ﾛｯﾄ一覧情報構造体
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@流動中ﾛｯﾄの確認
            With vsfLotList
                '@選択行番号配列の初期化
                'ReDim ltypSearchResult(.Rows.Selected.Count)
                ltypSearchResult = New List(Of SearchResult)
                    
                '@選択された範囲分
                Dim tmpSearchResult As SearchResult
                For llngCnt = 0 To .Rows.Selected.Count - 1
                    '@ﾊｲﾗｲﾄ取得
                    tmpSearchResult = New SearchResult
                    llngRow = .Rows.Selected(llngCnt).Index                                                 '№
                    tmpSearchResult.strNo = .GetData(llngRow, CMlngvsfSearchNo)
                    tmpSearchResult.strKb = .GetData(llngRow, CMlngvsfSearchKb)                             '保留停止
                    tmpSearchResult.strLotID = .GetData(llngRow, CMlngvsfSearchLotID)                       'ﾛｯﾄID
                    tmpSearchResult.strOpID = .GetData(llngRow, CMlngvsfSearchOpID)                         '大工程
                    tmpSearchResult.strStepID = .GetData(llngRow, CMlngvsfSearchStepID)                     '小工程
                    tmpSearchResult.strCurrentStatus = .GetData(llngRow, CMlngvsfSearchNowSt)               '現在状態
                    tmpSearchResult.strLotPos = .GetData(llngRow, CMlngvsfSearchLotPos)                     'ﾛｯﾄ位置
                    tmpSearchResult.strCarrierID = .GetData(llngRow, CMlngvsfSearchCarrierID)               'ｷｬﾘｱID
                    tmpSearchResult.strColKb = .GetData(llngRow, CMlngvsfSearchKb)                          '保/停
                    tmpSearchResult.strPDID = .GetData(llngRow, CMlngvsfSearchPdID)                         '機種
                    tmpSearchResult.strFrowClass = .GetData(llngRow, CMlngvsfSearchFlowClass)               '種別
                    tmpSearchResult.strLotHold = .GetData(llngRow, CMlngvsfSearchLotHold)                   '保留区分
                    tmpSearchResult.strLotStop = .GetData(llngRow, CMlngvsfSearchLotStop)                   '停止区分
                    tmpSearchResult.strLcDirection = .GetData(llngRow, CMlngvsfSearchLcDirection)           '液晶方向
                    tmpSearchResult.strReworkFlag = .GetData(llngRow, CMlngvsfSearchReworkFlag)             'ﾘﾜｰｸﾌﾗｸﾞ
                    tmpSearchResult.strProcFlag = .GetData(llngRow, CMlngvsfSearchProcFlag)                 'ﾛｯﾄ種別ﾌﾗｸﾞ
                    tmpSearchResult.strWfCarryFlag = .GetData(llngRow, CMlngvsfSearchWfCarryFlag)           'WF移載中ﾌﾗｸﾞ
                    tmpSearchResult.strVerUpProhibitedFlag = .GetData(llngRow, CMlngvsfSearchProhibitedFlag) 'VerUp禁止
                    tmpSearchResult.strProhibitedEmpName = .GetData(llngRow, CMlngvsfSearchProhibitedEmp)    '禁止設定者
                    tmpSearchResult.strProhibitedDeptName = .GetData(llngRow, CMlngvsfSearchProhibitedDept)  '禁止設定者部署
                    tmpSearchResult.strLotLastUpdate = .GetData(llngRow, CMlngvsfSearchLotLastUpdate)        '最終更新日時

                    'NSYS 編集済み構造体をリストへ追加
                    ltypSearchResult.Add(tmpSearchResult)
                Next llngCnt
                
            End With
            
            '@工順変更中ﾛｯﾄﾘｽﾄの存在確認
            With frmxxEN01X0.Instance.vsfProcCngList
                '@選択行分ﾙｰﾌﾟ
                For llngRowCnt = 0 To vsfLotList.Rows.Selected.Count - 1
                    llngFindRow = -1
                    For llngCnt = 1 To .Rows.Count - 1
                        If .GetData(llngCnt, CPlngvsfProcCngListLotID) = _
                                ltypSearchResult(llngRowCnt).strLotID Then
                            llngFindRow = llngCnt       '存在行番号を設定
                            Exit For
                        End If
                    Next llngCnt
                    
                    '@存在確認
                    Select Case llngFindRow
                        '@存在しない場合は新規行を追加する
                        Case -1
                            
                            '@見出し行以外のﾃﾞｰﾀ
                            If IsNumeric(ltypSearchResult(llngRowCnt).strNo) = True Then
                                '@最終行へ追加する
                                .AddItem(.Rows.Count & vbTab & _
                                        ltypSearchResult(llngRowCnt).strKb & vbTab & _
                                        ltypSearchResult(llngRowCnt).strLotID & vbTab & _
                                        ltypSearchResult(llngRowCnt).strOpID & vbTab & _
                                        ltypSearchResult(llngRowCnt).strStepID & vbTab & _
                                        ltypSearchResult(llngRowCnt).strCurrentStatus & vbTab & _
                                        ltypSearchResult(llngRowCnt).strLotPos & vbTab & _
                                        CMstrStateNotEdit & vbTab & _
                                        frmxxEN01X0.Instance.lblUserName.text & vbTab & _
                                        vbNullString & vbTab & _
                                        vbNullString & vbTab & _
                                        ltypSearchResult(llngRowCnt).strPDID & vbTab & _
                                        ltypSearchResult(llngRowCnt).strCarrierID & vbTab & _
                                        frmxxEN01X0.Instance.txtUserID.Text & vbTab & _
                                        vbNullString & vbTab & _
                                        vbNullString & vbTab & _
                                        vbNullString & vbTab & _
                                        CMstrKindFlag1 & vbTab & ltypSearchResult(llngRowCnt).strFrowClass & vbTab & _
                                        ltypSearchResult(llngRowCnt).strLotHold & vbTab & ltypSearchResult(llngRowCnt).strLotStop & vbTab & _
                                        ltypSearchResult(llngRowCnt).strLcDirection & vbTab & ltypSearchResult(llngRowCnt).strReworkFlag & vbTab & _
                                        ltypSearchResult(llngRowCnt).strProcFlag & vbTab & ltypSearchResult(llngRowCnt).strWfCarryFlag & vbTab & _
                                        ltypSearchResult(llngRowCnt).strVerUpProhibitedFlag & vbTab & ltypSearchResult(llngRowCnt).strProhibitedEmpName & vbTab & _
                                        ltypSearchResult(llngRowCnt).strProhibitedDeptName & vbTab & ltypSearchResult(llngRowCnt).strLotLastUpdate)
                                        
                                '@最終行をｶﾚﾝﾄ行設定する
                                .Row = .Rows.Count - 1
                                
                                '@未編集色の設定
                               Dim cellRange = .GetCellRange(.Row, CPlngvsfProcCngListNo, .Row, .Cols.Count - 1)
                               Dim notEditStyle = .Styles.Add("NOT_EDIT_PASTE_COLOR")
                               notEditStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngStateNotEditColor))    '薄い水色
                               cellRange.Style = notEditStyle

                                    
        '@↓2009/12/08 (Tue) 17:21:08 H.Hayashi **************************************************
                                If vsfLotList.GetCellRange(vsfLotList.Row, CPlngvsfProcCngListOpID).StyleDisplay.ForeColor = ColorTranslator.FromWin32(CPlngVbColorBlue ) Then
                                
                                    '@未編集色の設定
                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue")
                                    newStyle.ForeColor = ColorTranslator.FromWin32(CPlngVbColorBlue )
                                    Dim cellRange_ As CellRange = .GetCellRange(.Row, CPlngvsfProcCngListNo, .Row, .Cols.Count - 1)
                                    cellRange_.Style = newStyle   '文字色青
                                End If
        '@↑2009/12/08 (Tue) 17:21:08 H.Hayashi **************************************************
                                    
                            End If

                        '@存在する場合は上書きする
                        Case 1 To .Rows.Count - 1
                            .SetData(llngFindRow, CPlngvsfProcCngListKb, _
                                                        ltypSearchResult(llngRowCnt).strKb)                      '保留/停止
                            
                            .SetData(llngFindRow, CPlngvsfProcCngListLotID, _
                                                        ltypSearchResult(llngRowCnt).strLotID)                   'ﾛｯﾄID
                            
                            .SetData(llngFindRow, CPlngvsfProcCngListOpID, _
                                                        ltypSearchResult(llngRowCnt).strOpID)                    '大工程
                            
                            .SetData(llngFindRow, CPlngvsfProcCngListStepID, _
                                                        ltypSearchResult(llngRowCnt).strStepID)                  '小工程
                            
                            .SetData(llngFindRow, CPlngvsfProcCngListLotStatus, _
                                                        ltypSearchResult(llngRowCnt).strCurrentStatus)           '現在状態
                            
                            .SetData(llngFindRow, CPlngvsfProcCngListLotPos, _
                                                        ltypSearchResult(llngRowCnt).strLotPos)                  'ﾛｯﾄ位置
                                                        
                            .SetData(llngFindRow, CPlngvsfProcCngListHistoryFlag, vbNullString)       'ｲﾍﾞﾝﾄ履歴未読み
                            
                            .SetData(llngFindRow, CPlngvsfProcCngListHistory, vbNullString)           '変更履歴
                            
                            .SetData(llngFindRow, CPlngvsfProcCngListKindFlag, CMstrKindFlag1)        'ﾛｯﾄ工順変更
                            
                            .SetData(llngFindRow, CPlngvsfProcCngListCarrierID, _
                                                        ltypSearchResult(llngRowCnt).strCarrierId)               'ｷｬﾘｱID
                                                        
                            .SetData(llngFindRow, CPlngvsfProcCngListProhibitedFlag, _
                                                        ltypSearchResult(llngRowCnt).strVerUpProhibitedFlag)     'VerUp禁止
                                                        
                            .SetData(llngFindRow, CPlngvsfProcCngListProhibitedEmp, _
                                                        ltypSearchResult(llngRowCnt).strProhibitedEmpName)       '禁止設定者
                                                        
                            .SetData(llngFindRow, CPlngvsfProcCngListProhibitedDept, _
                                                        ltypSearchResult(llngRowCnt).strProhibitedDeptName)      '禁止設定者部署
                                                        
                            .SetData(llngFindRow, CPlngvsfProcCngListLotLastUpdate, _
                                                        ltypSearchResult(llngRowCnt).strLotLastUpdate)           '最終更新日時

                            '@ｶﾚﾝﾄ行設定する
                            .Row = llngFindRow
                    End Select
                Next llngRowCnt
            End With
            
            '@ﾛｯﾄ一覧画面を閉じる
            Call cmdClose_Click(sender, e)
            
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

    '関数名：cmdUp_Click
    '機　能：工順変更ｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/06/26 (Tue) 14:02:42 N.Kasai
    '更新日：2007/06/26 (Tue) 14:02:42 N.Kasai
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
            
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdUp_Click"                '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：工順変更ｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/06/26 (Tue) 14:02:53 N.Kasai
    '更新日：2007/06/26 (Tue) 14:02:53 N.Kasai
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
            
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdDown_Click"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_Change
    '機　能：ｺﾒﾝﾄ欄変更
    '引　数：なし
    '戻り値：なし
    '作成日：2007/06/26 (Tue) 14:03:03 N.Kasai
    '更新日：2007/06/26 (Tue) 14:03:03 N.Kasai
    '備　考：
    Private Sub txtComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.Change

        Try
                       
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2007/06/26 (Tue) 14:03:15 N.Kasai
    '更新日：2007/06/26 (Tue) 14:03:15 N.Kasai
    '備　考：
    Private Sub txtComments_KeyUp(ByVal sender As Object, ByVal e As keyEventArgs) Handles txtComments.KeyUp
        
        Try
           

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComments, CMlngMaxDispRow, cmdUP, cmdDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2007/06/26 (Tue) 14:03:29 N.Kasai
    '更新日：2007/06/26 (Tue) 14:03:29 N.Kasai
    '備　考：
    Private Sub txtComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtComments.MouseUp

        Try
            

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfLotList_AfterSort
    '機　能：検索結果ﾘｽﾄ ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2006/05/15 (Mon) 16:10:50 N.Kasai
    '更新日：2006/05/15 (Mon) 16:11:03
    '備　考：
    Private Sub vsfLotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotList.AfterSort

        Try
             'BeforeSortで除外していたRowColChangeイベントを復帰           
            AddHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotlist_BeforeRowColChange
            AddHandler vsfLotList.EnterCell, AddressOf vsfLotList_EnterCell

            'NSYS ソート前の選択行が有効行でない場合、ヘッダを選択行とする
            If vsfLotlistRowBeforeSort <  vsfLotList.Rows.Fixed Then
                vsfLotList.Row = 0
            End If
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                'NSYS ローカス変数にコピー
                Dim typChgSortListTmp As ChgSortList = New ChgSortList
                '@ｿｰﾄ列番号を格納               
                typChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納（昇順/降順）
                typChgSortListTmp.lngOrder = e.Order
                'NSYS ローカル変数からリストへコピー
                .typChgSortList.Add(typChgSortListTmp)
            End With
            
            '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列）
            Call pubVsfAfterSort(vsfLotList, CMlngvsfSearchLotID)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotList_AfterSort"  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_AfterUserResize
    '機　能：列幅変更後処理
    '引　数：Row：行番号
    '　　　：Col：列番号
    '戻り値：
    '作成日：2006/05/15 (Mon) 16:11:18 N.Kasai
    '更新日：2006/05/15 (Mon) 16:11:18
    '備　考：
    Private Sub vsfLotList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotList.AfterResizeColumn, vsfLotList.AfterResizeRow
        
        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
            
            
            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                     '機能ID
                .strProcName = "vsfLotList_AfterUserResize"    '処理名
                .strErrMessage = vbNullString                       'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_BeforeRowColChange
    '機　能：行列変更前処理
    '引　数：OldRow：旧行番号
    '　　　：OldCol：旧列番号
    '　　　：NewRow：新行番号
    '　　　：NewCol：新列番号
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/05/15 (Mon) 16:11:41 N.Kasai
    '更新日：2006/05/15 (Mon) 16:11:41
    '備　考：
    Private Sub vsfLotList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLotList.BeforeRowColChange
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 >  0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（ﾛｯﾄID）
                mtypChgSort.strKey = vsfLotList.GetData(e.NewRange.r1, CMlngvsfSearchLotID)
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                         '機能ID
                .strProcName = "vsfLotList_BeforeRowColChange"     '処理名
                .strErrMessage = vbNullString                           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_BeforeSort
    '機　能：検索結果ﾘｽﾄ ｿｰﾄ前処理
    '引　数：Col　：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2006/05/15 (Mon) 16:12:01 N.Kasai
    '更新日：2006/05/15 (Mon) 16:12:01
    '備　考：
    Private Sub vsfLotList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotList.BeforeSort

        Try
           'ソートでRowColChangeを発生しないようにする
            RemoveHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotlist_BeforeRowColChange
            RemoveHandler vsfLotlist.EnterCell, AddressOf vsfLotlist_EnterCell
            vsfLotlistRowBeforeSort = vsflotlist.Row 'NSYS ソート前の選択行を保持
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
            Call pubVsfBeforeSort(vsfLotList, CMlngvsfSearchLotID)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotList_BeforeSort" '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_DblClick
    '機　能：検索結果ｸﾞﾘｯﾄのﾀﾞﾌﾞﾙｸﾘｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/15 (Mon) 16:12:14 N.Kasai
    '更新日：2006/05/15 (Mon) 16:12:14
    '備　考：
    Private Sub vsfLotList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.DoubleClick

        Try
            'NSYS ﾀﾞﾌﾞﾙｸﾘｯｸ中ﾌﾗｸﾞを設定
            blnDblClickFlg = True

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸの場合
            If vsfLotList.MouseRow = 0   Then
                Exit Sub
            End If
            
            '@確定ﾎﾞﾀﾝの押下
            If cmdRegist.Enabled = True Then
                Call cmdRegist_Click(sender, e)
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotList_DblClick"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        Finally
            'NSYS ﾀﾞﾌﾞﾙｸﾘｯｸ中ﾌﾗｸﾞを初期化
            blnDblClickFlg = False

        End Try
    End Sub

    '関数名：vsfLotList_EnterCell
    '機　能：検索結果ｸﾞﾘｯﾄ ｶﾚﾝﾄ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/15 (Mon) 16:12:42 N.Kasai
    '更新日：2006/05/15 (Mon) 16:12:42
    '備　考：
    Private Sub vsfLotList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.EnterCell

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
            

            '@固定行判定
            With vsfLotList
                If .Row < 1 Then
                    Exit Sub
                End If

                '@ｺﾒﾝﾄの反映
                txtComments.Text = .GetData(.Row, CMlngvsfSearchLotComments)
            End With
            
            '@確定ﾎﾞﾀﾝの有効
            cmdRegist.Enabled = True
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotList_EnterCell"  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                                   * 関数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    '関数名：prvfrmxxEN01X1_Init
    '機　能：ﾌｫｰﾑの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/15 (Mon) 16:13:15 N.Kasai
    '更新日：2009/02/25 (Wed) 19:33:56 N.Kojima
    '備　考：
    '　　　：2009/02/25 (Wed) 19:33:56 N.Kojima     ﾁｯﾌﾟ品判別説明ﾗﾍﾞﾙの制御処理追加。(案件№03402)
    Private Sub prvfrmxxEN01X1_Init()
        
        Try
            
        '@↓2009/03/02 (Mon) 14:39:12 N.Kojima **************************************************
            
            '@-----------------------
            '@ ﾗﾍﾞﾙﾊﾞｯｸｶﾗｰ設定
            '@-----------------------
            '@起動SBが"2A0：組立"か
            If pstrSBID = CPstrSBID2A0 Then
                '@2A0：組立の場合
            
                lblTitleL.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngLColor))          '機種L              cmbPD.BackColor
                lblTitleR.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngRColor))          '機種R
                lblTitleL.Visible = True
                lblTitleR.Visible = True
                lblTitleChip.Visible = True                 'ﾁｯﾌﾟ品説明
            Else
                '@1A0：基板の場合

                lblTitleL.Visible = False
                lblTitleR.Visible = False
                lblTitleChip.Visible = False                'ﾁｯﾌﾟ品説明
            End If

        '@↑2009/03/02 (Mon) 14:39:12 N.Kojima **************************************************
            
            '@保留停止色
            lblTitleHT.BackColor = Color.Yellow      '保留/停止
            
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = false
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@内容のｸﾘｱ
            optSearch0.Checked= True
            optFlowClass0.Checked = True
            txtLotID.Text = vbNullString
            lblGetInfoDate.Text = vbNullString
            lblListCnt.Text = vbNullString

            '@機種・種別使用可
            cmbPd.Enabled = True
            cmbFlowClass.Enabled = False
            cmbPd.BackColor = Color.White
            cmbFlowClass.BackColor = vbButtonFace
            fraKisyu.Enabled = True
            
            '@ﾛｯﾄID使用不可
            txtLotID.Enabled = False
            txtLotID.BackColor = vbButtonFace
            
            '@ｷｬﾘｱID使用不可
            txtCarrierID.Enabled = False
            txtCarrierID.BackColor = vbButtonFace
            
            '@検索結果ﾘｽﾄの初期化
            Call prvvsfLotList_Init()
            
            '@ﾎﾞﾀﾝの使用許可
            cmdRegist.Enabled = False       '確定ﾎﾞﾀﾝ
            cmdSearch.Enabled = False       '最新取得ﾎﾞﾀﾝ
            cmdUP.Enabled = False           '▲ﾎﾞﾀﾝ
            cmdDown.Enabled = False         '▼ﾎﾞﾀﾝ
            
            '@ｺﾒﾝﾄ欄
            With txtComments
                .Text = vbNullString
                .Locked = True
            End With
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            'NSYS グリッド使用不可
            vsfLotList.Enabled = false
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxEN01X1_Init"        '処理名
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
                    cmbPd.ValueCol = CMlngCmbValueCol0
                    
                    If cmbPd.Value = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0013)
                        '@"機種が指定されていません。機種を指定してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Call pubSetFocus(cmbPd)
                        
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
               
                '@ｷｬﾘｱIDの場合
                Case optSearch2.Checked
                    If Len(txtCarrierID.Text) < 6 Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                        '@"キャリアIDは6桁で入力してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Call pubSetFocus(txtCarrierID)
                        
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

    '関数名：prvvsfLotList_Init
    '機　能：ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 16:37:04 N.Kasai
    '更新日：2008/06/11 (Wed) 15:57:56 N.Kojima
    '備　考：
    '　　　：2007/04/05 (Thu) 15:35:34 N.Kasai      流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ(№01831)
    '　　　：2008/06/11 (Wed) 15:57:56 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvvsfLotList_Init()
        Dim headerStyle As CellStyle    'NSYS ヘッダー用追加Style
        Dim cellRange As CellRange      'NSYS 追加Sytle設定範囲

        Try

            '@一覧表示の各ｶﾗﾑの幅,ﾀｲﾄﾙを設定
            With vsfLotList
                
                '@描画なし
                .Redraw = False
                
                '@ｸﾘｱ

                '@初期行/列設定
                .Rows.Count = .Rows.Fixed
                .Cols.Count = CMlngMaxCols 
                
                '@ﾏｳｽによる列ｻｲｽﾞ変更の可             
                .AllowResizing = AllowResizingEnum.Columns

                '@固定列の設定               
                .Cols.Frozen = CMlngvsfSearchLotID

                .SelectionMode = SelectionModeEnum.ListBox

                '@一覧表の表題設定    
               
                headerStyle = .Styles.Add("headerStyle_new")
                headerStyle.ForeColor = Color.Yellow                                                  '文字色
                cellRange = .GetCellRange(CMlngTRow, CMlngvsfSearchNo, CMlngTRow, .Cols.Count - 1)
                cellRange.Style = headerStyle

                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfSearchNo).Width = CMlngvsfwSearchNo                                 '№
                    .Cols(CMlngvsfSearchKb).Width = CMlngvsfwSearchKb                                 '保/停区分
                    .Cols(CMlngvsfSearchOpID).Width = CMlngvsfwSearchOpID                             '大工程
                    .Cols(CMlngvsfSearchStepID).Width = CMlngvsfwSearchStepID                         '小工程
                    .Cols(CMlngvsfSearchNowSt).Width = CMlngvsfwSearchNowSt                           '状態
                    .Cols(CMlngvsfSearchLotID).Width = CMlngvsfwSearchLotID                           'ﾛｯﾄID
                    .Cols(CMlngvsfSearchFlowClass).Width = CMlngvsfwSearchFlowClass                   '種別
                    .Cols(CMlngvsfSearchCarrierID).Width = CMlngvsfwSearchCarrierID                   'ｷｬﾘｱID
                    .Cols(CMlngvsfSearchPriority).Width = CMlngvsfwSearchPriority                     '優先度
                    .Cols(CMlngvsfSearchLotPos).Width = CMlngvsfwSearchLotPos                         'ﾛｯﾄ位置
                    .Cols(CMlngvsfSearchLotManagerName).Width = CMlngvsfwSearchLotManagerName         'ﾛｯﾄ担当
                    .Cols(CMlngvsfSearchWfNum).Width = CMlngvsfwSearchWfNum                           'WF枚数
                    .Cols(CMlngvsfSearchChipNum).Width = CMlngvsfwSearchChipNum                       'ﾁｯﾌﾟ数
                    .Cols(CMlngvsfSearchLotComments).Width = CMlngvsfwSearchLotComments               'ｺﾒﾝﾄ
                End If
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngTRow, CMlngvsfSearchNo,  CMstrvsftSearchNo)                             'No.                                                                              
                .SetData(CMlngTRow, CMlngvsfSearchOpID, CMstrvsftSearchOpID)                         '大工程                                                                             
                .Setdata(CMlngTRow, CMlngvsfSearchStepID, CMstrvsftSearchStepID)                     '小工程                                                 
                .SetData(CMlngTRow, CMlngvsfSearchNowSt, CMstrvsftSearchNowSt)                       '状態                                                                                                                                          
                .SetData(CMlngTRow, CMlngvsfSearchLotID, CMstrvsftSearchLotID)                       'ﾛｯﾄID 
                .SetData(CMlngTRow, CMlngvsfSearchFlowClass,  CMstrvsftSearchFlowClass)               '種別                                                                     
                .SetData(CMlngTRow, CMlngvsfSearchCarrierID, CMstrvsftSearchCarrierID)                'ｷｬﾘｱID                                                                      
                .SetData(CMlngTRow, CMlngvsfSearchPriority, CMstrvsftSearchPriority)                  '優先度 
                .SetData(CMlngTRow, CMlngvsfSearchLotPos,  CMstrvsftSearchLotPos)                     'ﾛｯﾄ位置 
                .SetData( CMlngTRow, CMlngvsfSearchLotManagerName,CMstrvsftSearchLotManagerName)      'ﾛｯﾄ担当
                .SetData(CMlngTRow, CMlngvsfSearchWfNum, CMstrvsftSearchWfNum)                         'WF枚数                                                                           
                .SetData(CMlngTRow, CMlngvsfSearchChipNum,  CMstrvsftSearchChipNum)                    'ﾁｯﾌﾟ数                                                                       
                .SetData(CMlngTRow, CMlngvsfSearchLotComments, CMstrvsftSearchLotComments)             'ｺﾒﾝﾄ 
                .SetData(CMlngTRow, CMlngvsfSearchLotHold, CMstrvsftSearchLotHold)                     '保留区分                                                                         
                .SetData(CMlngTRow, CMlngvsfSearchLotStop, CMstrvsftSearchLotStop)                     '停止区分                                                                                        
                .SetData(CMlngTRow, CMlngvsfSearchLcDirection, CMstrvsftSearchLcDirection)             '液晶方向                                                                                      
                .SetData(CMlngTRow, CMlngvsfSearchReworkFlag, CMstrvsftSearchReworkFlag)               'ﾘﾜｰｸﾌﾗｸﾞ                                                                                        
                .SetData(CMlngTRow, CMlngvsfSearchProcFlag,  CMstrvsftSearchProcFlag)                  'ﾛｯﾄ種別ﾌﾗｸﾞ                                                                                        
                .SetData(CMlngTRow, CMlngvsfSearchWfCarryFlag,  CMstrvsftSearchWfCarryFlag)            'WF移載中ﾌﾗｸﾞ
        '@↓2007/04/05 (Thu) 12:50:50 N.Kasai **************************************************
                .SetData(CMlngTRow, CMlngvsfSearchProhibitedFlag,  CMstrvsftSearchProhibitedFlag)      'VerUp禁止                                                                     
                .SetData(CMlngTRow, CMlngvsfSearchProhibitedEmp,  CMstrvsftSearchProhibitedEmp)        '禁止設定者                                                                     
                .SetData(CMlngTRow, CMlngvsfSearchProhibitedDept, CMstrvsftSearchProhibitedDept)      '禁止設定者部署                                                                    
                .SetData(CMlngTRow, CMlngvsfSearchLotLastUpdate,  CMstrvsftSearchLotLastUpdate)        '最終更新日時
        '@↑2007/04/05 (Thu) 12:50:50 N.Kasai **************************************************
                
                '@表示位置の設定(中央寄せ中央揃え)
                headerStyle.TextAlign = TextAlignEnum.CenterCenter

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngTRow).Height = CMlngTHeight
                
                '@非表示列
                .Cols(CMlngvsfSearchLotPos).Visible  = False             'ﾛｯﾄ位置
                .Cols(CMlngvsfSearchLotHold).Visible = False            '保留区分
                .Cols(CMlngvsfSearchLotStop).Visible = False            '停止区分
                .Cols(CMlngvsfSearchLcDirection).Visible = False        '液晶方向
                .Cols(CMlngvsfSearchReworkFlag).Visible = False         'ﾘﾜｰｸﾌﾗｸﾞ
                .Cols(CMlngvsfSearchProcFlag).Visible = False           'ﾛｯﾄ種別ﾌﾗｸﾞ
                .Cols(CMlngvsfSearchWfCarryFlag).Visible = False        'WF移載中ﾌﾗｸﾞ
                .Cols(CMlngvsfSearchProhibitedFlag).Visible  = false     'VerUp禁止
                .Cols(CMlngvsfSearchProhibitedEmp).Visible  = false      '禁止設定者
                .Cols(CMlngvsfSearchProhibitedDept).Visible  = false     '禁止設定者部署
                .Cols(CMlngvsfSearchLotLastUpdate).Visible  = false      '最終更新日時
                
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@ｵｰﾄ幅設定(ｺﾒﾝﾄ列は対象外)
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(CMlngvsfSearchNo, .Cols.Count - 1, 6)
                End If

                '@情報取得日時初期化
                lblGetInfoDate.Text = vbNullString

                '@該当件数ﾗﾍﾞﾙの初期化
                lblListCnt.Text = vbNullString

                '@使用不可
                

                'NSYS KeepNoneRedrawがFalseの場合のみ再描画
                If blnKeepNoneRedrawFlg = False Then
                    '@直接描画
                    .Redraw = True
                End If

            End With

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfLotList_Init"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotList_Disp
    '機　能：ﾛｯﾄ一覧検索結果表示
    '引　数：ltypProcLotListAns：ﾃﾞｰﾀ格納構造体
    '戻り値：なし
    '作成日：2006/06/30 (Fri) 10:24:21 N.Kasai
    '更新日：2009/12/02 (Wed) 10:38:28 H.Hayashi
    '備　考：
    '　　　：2006/10/19 (Thu) 08:53:17 M.Miura      保/停区分の結合表示(案件№01565)
    '　　　：2008/06/11 (Wed) 15:58:59 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/02/25 (Wed) 11:52:25 N.Kojima     起動SBが組立、かつ送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。(案件№03402)
    '　　　：2009/12/02 (Wed) 10:38:28 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    Private Sub prvvsfLotList_Disp(ByRef ltypProcLotListAns As ProcLotListAns)

        Dim llngCnt                     As Integer  'ｶｳﾝﾄ
        Dim newStyle                    As CellStyle'NSYS メソッド内共通使用
        Dim cellRange                   As CellRange'NSYS メソッド内共通使用
        Dim keepBackColorObj            As Color   'NSYS 設定済み背景色(時間制限ﾌｫﾝﾄ設定時初期化されるため再設定用)

        Try
            'NSYS 不要イベント発生抑止解除
            RemoveHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange
            RemoveHandler vsfLotList.EnterCell, AddressOf vsfLotlist_EnterCell

            With vsfLotList

                                '@描画ﾛｯｸ
                .Redraw = False

                '@行数設定
                .Rows.Count = ltypProcLotListAns.lngProcLotListCnt + 1

                '@ﾛｯﾄ一覧表示
                Dim arrayIdx As Integer = 0
                For llngCnt = 1 To ltypProcLotListAns.lngProcLotListCnt 
                 
                    '@ｾﾙ色変更
                    newStyle  = .Styles.Add("CustomStyle_BackColor_vbWhite")
                    newStyle.BackColor = Color.White
                    cellRange = .GetCellRange(llngCnt, CMlngTRow, llngCnt, .Cols.Count - 1)
                    cellRange.Style = newStyle            '白色
                    'NSYS 設定背景色退避
                    keepBackColorObj = Color.White
                    '@ﾌｫﾝﾄ色変更
                    newStyle  = .Styles.Add("CustomStyle_ForeColor_vbBlack")
                    newStyle.ForeColor = Color.Black
                    cellRange  = .GetCellRange(llngCnt, CMlngTRow, llngCnt, .Cols.Count - 1)
                    cellRange.Style = newStyle            '黒色
                    
                    .SetData(llngCnt, CMlngvsfSearchOpID, _
                        ltypProcLotListAns.typProcLotList(arrayIdx).strOpID)        '大工程
                    
                    .SetData(llngCnt,  CMlngvsfSearchStepID, _
                        ltypProcLotListAns.typProcLotList(arrayIdx).strStepID)      '小工程


        '            '@時間制約有無の表示
        '            If ltypProcLotListAns.typProcLotList(llngCnt).strLimitTime <> vbNullString Then
        '                '@時間制約がﾌﾟﾗｽの場合
        '                If CLng(ltypProcLotListAns.typProcLotList(llngCnt).strLimitTime) >= 0 Then
        '                    '@制限時間以下の場合
        '                    If ltypProcLotListAns.typProcLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID1 Or _
        '                        ltypProcLotListAns.typProcLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID3 Then
        '
        '                        '@ﾌｫｰﾏｯﾄ変換(##,##0)
        '                        lstrLimitTime = Format$(ltypProcLotListAns.typProcLotList(llngCnt).strLimitTime, CPstrDateFormatKanma)
        '
        '                        '@制限時間先大工程+制限時間先小工程+制限時間+「以内」
        '                        '@制限時間を時間と分で分割表示する
        '                        lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
        '                        .Cell(flexcpText, llngCnt, CMlngvsfSearchLimitTime) _
        '                            = ltypProcLotListAns.typProcLotList(llngCnt).strToOpID _
        '                            & CPstrSpace _
        '                            & ltypProcLotListAns.typProcLotList(llngCnt).strToStepID _
        '                            & CPstrMade _
        '                            & lstrLimitTimeAns _
        '                            & CPstrinai
        '
        '                        '@警告時間が設定されている場合
        '                        If ltypProcLotListAns.typProcLotList(llngCnt).strWarnTime <> vbNullString Then
        '                            '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
        '                            If CLng(ltypProcLotListAns.typProcLotList(llngCnt).strWarnTime) < 0 _
        '                                And CLng(ltypProcLotListAns.typProcLotList(llngCnt).strLimitTime) >= 0 Then
        '
        '                                '@ﾌｫﾝﾄｶﾗｰを紫に変更
        '                                .Cell(flexcpForeColor, llngCnt, CMlngvsfSearchLimitTime, _
        '                                                       llngCnt, CMlngvsfSearchLimitTime) = CPlngVbColorPurple   '紫色
        '                            Else
        '                                '@ﾌｫﾝﾄｶﾗｰを黒に変更
        '                                .Cell(flexcpForeColor, llngCnt, CMlngvsfSearchLimitTime, _
        '                                                       llngCnt, CMlngvsfSearchLimitTime) = vbBlack              '黒
        '                            End If
        '                        End If
        '                    End If
        '                Else
        '                '@制限時間がﾏｲﾅｽの場合
        '                    '@ForColorの変更
        '                    .Cell(flexcpForeColor, llngCnt, CMlngvsfSearchLimitTime, _
        '                                           llngCnt, CMlngvsfSearchLimitTime) = CPlngVbColorRed                  '赤色
        '
        '                    '@制限時間以下の場合
        '                    If ltypProcLotListAns.typProcLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID1 Or _
        '                        ltypProcLotListAns.typProcLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID3 Then
        '
        '                        '@ﾌｫｰﾏｯﾄ変換(##,##0)
        '                        lstrLimitTime = Format$(ltypProcLotListAns.typProcLotList(llngCnt).strLimitTime, CPstrDateFormatKanma)
        '
        '                        '@制限時間先大工程+制限時間先小工程+制限時間+「以内」
        '                        '@制限時間を時間と分で分割表示する
        '                        lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
        '                        .Cell(flexcpText, llngCnt, CMlngvsfSearchLimitTime) _
        '                            = ltypProcLotListAns.typProcLotList(llngCnt).strToOpID _
        '                            & CPstrSpace _
        '                            & ltypProcLotListAns.typProcLotList(llngCnt).strToStepID _
        '                            & CPstrMade _
        '                            & lstrLimitTimeAns _
        '                            & CPstrinai
        '                    End If
        '
        '                    '@制限時間以上の場合
        '                    If ltypProcLotListAns.typProcLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID2 Then
        '                        '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,##0)+"分"
        '                        lstrLimitTime = Replace(Format$(ltypProcLotListAns.typProcLotList(llngCnt).strLimitTime _
        '                                        , CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString)
        '
        '                        '@制限時間先大工程+制限時間先小工程+制限時間+「以上」
        '                        '@制限時間を時間と分で分割表示する
        '                        lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
        '                        .Cell(flexcpText, llngCnt, CMlngvsfSearchLimitTime) _
        '                            = ltypProcLotListAns.typProcLotList(llngCnt).strToOpID _
        '                            & CPstrSpace _
        '                            & ltypProcLotListAns.typProcLotList(llngCnt).strToStepID _
        '                            & CPstrMade _
        '                            & lstrLimitTimeAns _
        '                            & CPstrijyou
        '                    End If
        '                End If
        '            End If
                    
                    .SetData(llngCnt,  CMlngvsfSearchNowSt, _
                        ltypProcLotListAns.typProcLotList(arrayIdx).strNowSt)       'ﾛｯﾄ現在状態
                    
                    .SetData(llngCnt, CMlngvsfSearchLotID, _
                        ltypProcLotListAns.typProcLotList(arrayIdx).strLotID )      'ﾛｯﾄID
                    
                    .SetData(llngCnt, CMlngvsfSearchPdID, _
                        ltypProcLotListAns.typProcLotList(arrayIdx).strPDID  )      '機種
                    
                    .SetData(llngCnt, CMlngvsfSearchFlowClass, _
                        ltypProcLotListAns.typProcLotList(arrayIdx).strFlowClass )  '種別
                    
                    .SetData(llngCnt, CMlngvsfSearchCarrierID, _
                        ltypProcLotListAns.typProcLotList(arrayIdx).strCarrierID )  'ｷｬﾘｱID
                    
                    .SetData(llngCnt, CMlngvsfSearchPriority, _
                        ltypProcLotListAns.typProcLotList(arrayIdx).strLotPriority )'優先順位
                        
        '            .Cell(flexcpText, llngCnt, CMlngvsfSearchRecipe) _
        '                = ltypProcLotListAns.typProcLotList(llngCnt).strRecipeId                                            'ﾚｼﾋﾟ
                        
                   .SetData(llngCnt, CMlngvsfSearchLotPos, _
                        ltypProcLotListAns.typProcLotList(arrayIdx).strCurrentPositionName  )'ﾛｯﾄ位置
                        
        '            .Cell(flexcpText, llngCnt, CMlngvsfSearchDispatchStartTime) _
        '                = Format$(ltypProcLotListAns.typProcLotList(llngCnt).strDispatchStartTime, CPstrDateFormatMDHM)     '処理開始予実
                        
                    .Setdata(llngCnt, CMlngvsfSearchLotManagerName,ltypProcLotListAns.typProcLotList(arrayIdx).strEngEmpName) 'ﾛｯﾄ担当
                                                                                                           
                    .Setdata(llngCnt, CMlngvsfSearchWfNum, _
                           ltypProcLotListAns.typProcLotList(arrayIdx).strWfNum)                                              'WF枚数
                                        
                    .SetData(llngCnt, CMlngvsfSearchChipNum, _
                           ltypProcLotListAns.typProcLotList(arrayIdx).strChipQuantity)                                       'ﾁｯﾌﾟ数
                    
        '            '@ﾛｯﾄｺﾒﾝﾄ有無の表示
        '            If ltypProcLotListAns.typProcLotList(llngCnt).strLotCommentsFlg = CPstrAriFlg Then
        '                .Cell(flexcpText, llngCnt, CMlngvsfSearchLotComments) = CPstrAriFlg                                 'ﾛｯﾄｺﾒﾝﾄ有
        '            Else
        '                .Cell(flexcpText, llngCnt, CMlngvsfSearchLotComments) = vbNullString                                'ﾛｯﾄｺﾒﾝﾄ無
        '            End If
                    
                    '@ﾛｯﾄｺﾒﾝﾄ
                    .SetData(llngCnt, CMlngvsfSearchLotComments,ltypProcLotListAns.typProcLotList(arrayIdx).strComments) 
                       
                    
                    '@------------------------------------
                    '@ 背景色の優先順位　保留/停止>L/R色
                    '@------------------------------------
                    '@L/Rによる文字色変更
                    Select Case ltypProcLotListAns.typProcLotList(arrayIdx).strLcDirection
                        Case CPstrPDIDL
                             '@ｾﾙ背景色変更                           
                             newStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor" + llngCnt.ToString)
                             newStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngLColor))
                             cellRange = .GetCellRange(llngCnt,CMlngTRow, _
                                                    llngCnt, .Cols.Count - 1)
                             cellRange.Style = newStyle    'Lｶﾗｰ（水色)
                            'NSYS 設定背景色退避
                            keepBackColorObj = ColorTranslator.FromWin32(Convert.ToInt32(CPlngLColor))
                        Case CPstrPDIDR
                             '@ｾﾙ背景色変更
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngRColor" + llngCnt.ToString)
                            newStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngRColor))
                            cellRange = .GetCellRange(llngCnt,CMlngTRow, _
                                                    llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle    'Rｶﾗｰ（ﾋﾟﾝｸ)
                            'NSYS 設定背景色退避
                            keepBackColorObj = ColorTranslator.FromWin32(Convert.ToInt32(CPlngRColor))
                        Case Else
                            '@ｾﾙ背景色変更
                            newStyle = .Styles.Add("CustomStyle_BackColor_vbWhite" + llngCnt.ToString)
                            newStyle.BackColor = Color.White
                            cellRange = .GetCellRange(llngCnt, CMlngTRow, _
                                                      llngCnt, .Cols.Count - 1) 
                            cellRange.Style = newStyle    '初期（白）
                            'NSYS 設定背景色退避
                            keepBackColorObj = Color.White
                    End Select

                    .SetData(llngCnt,CMlngvsfSearchLcDirection, ltypProcLotListAns.typProcLotList(arrayIdx).strLcDirection) 
                    
                    '@ﾌﾗｸﾞ判定（ﾛｯﾄ保留）
                    If ltypProcLotListAns.typProcLotList(arrayIdx).strLotHoldFlag = CMstrLotHoldFlgOn Then
                        '@ｾﾙの色変更
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor" + llngCnt.ToString)
                        newStyle.BackColor = Color.Yellow
                        cellRange = .GetCellRange(llngCnt, CMlngTRow, _
                                               llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle    '保留Lotｶﾗｰ
                        'NSYS 設定背景色退避
                        keepBackColorObj = Color.Yellow
                        
                        '@ﾌｫﾝﾄの色変更
                        newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlack" + llngCnt.ToString)
                        newStyle.ForeColor = Color.Black
                        cellRange = .GetCellRange(llngCnt, CMlngTRow, _
                                               llngCnt, CMlngvsfSearchNowSt)
                        cellRange.Style = newStyle    '黒色
                                               
                        newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlack" + llngCnt.ToString)
                        newStyle.ForeColor = Color.Black
                        cellRange = .GetCellRange(llngCnt, CMlngvsfSearchLotID, _
                                               llngCnt, CMlngvsfSearchLotComments)
                        cellRange.Style = newStyle    '黒色
                        '@保留/停止列に表示
                        
                        '@"保"表示
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor" + llngCnt.ToString)
                        newStyle.BackColor = Color.Yellow
                        cellRange = .GetCellRange(llngCnt, CMlngTRow, _
                                               llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle        
                        'NSYS 設定背景色退避
                        keepBackColorObj = Color.Yellow
                        .SetData(llngCnt, CMlngvsfSearchKb, _
                        pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfSearchKb), CMstrHo))                     '「保」表示
                    End If
                    
                    .SetData(llngCnt, CMlngvsfSearchLotHold, ltypProcLotListAns.typProcLotList(arrayIdx).strLotHoldFlag)

                    '@ﾌﾗｸﾞ判定（ﾛｯﾄ停止）
                    If ltypProcLotListAns.typProcLotList(arrayIdx).strLotStopFlag = CMstrLotStopFlgOn Then
                        '@ｾﾙ色変更
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor" + llngCnt.ToString)
                        newStyle.BackColor = Color.Yellow
                        cellRange  = .GetCellRange(llngCnt, CMlngTRow, _
                                              llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle                              '停止Lotｶﾗｰ（黄色）
                        'NSYS 設定背景色退避
                        keepBackColorObj = Color.Yellow
                        
                        '@ﾌｫﾝﾄ色変更
                        newStyle  = .Styles.Add("CustomStyle_ForeColor_vbBlack" + llngCnt.ToString)
                        newStyle.ForeColor = Color.Black
                        cellRange  = .GetCellRange(llngCnt, CMlngTRow, _
                                               llngCnt, CMlngvsfSearchNowSt)
                        cellRange.Style = newStyle                              '黒色
                                               
                        newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlack" + llngCnt.ToString)
                        newStyle.ForeColor = Color.Black
                        cellRange = .GetCellRange(llngCnt, CMlngvsfSearchLotID, _
                                               llngCnt, CMlngvsfSearchLotComments)
                        cellRange.Style = newStyle                        '黒色
                        
                        '@"停"表示
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor" + llngCnt.ToString)
                        newStyle.BackColor = Color.Yellow
                        cellRange = .GetCellRange(llngCnt, CMlngTRow, _
                                               llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle        
                        'NSYS 設定背景色退避
                        keepBackColorObj = Color.Yellow
                        .SetData(llngCnt, CMlngvsfSearchKb, _
                        pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfSearchKb), CMstrTei))                    '「停」表示
                    End If
                    
                    .SetData(llngCnt,  CMlngvsfSearchLotStop, ltypProcLotListAns.typProcLotList(arrayIdx).strLotStopFlag) 
                    
                    .SetData(llngCnt, CMlngvsfSearchReworkFlag,ltypProcLotListAns.typProcLotList(arrayIdx).strReworkFlag)  'ﾘﾜｰｸﾌﾗｸﾞ

                    
                    '@ﾌﾗｸﾞ判定(ﾘﾜｰｸ/追加)
                    Select Case ltypProcLotListAns.typProcLotList(arrayIdx).strReworkFlag
                        Case CMstrReworkFlgOn
                            '@"リ"表示
                            .SetData(llngCnt, CMlngvsfSearchKb, _
                            pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfSearchKb), CMstrRi))                                             '「リ」表示
                        Case CMstrLotReworkFlgOn2
                            '@"追"表示
                            .SetData(llngCnt, CMlngvsfSearchKb, _
                            pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfSearchKb), CMstrTsui))                                           '「追」表示
                    End Select
                    
                    '@WF移載中ﾌﾗｸﾞ
                    If ltypProcLotListAns.typProcLotList(arrayIdx).strWfCarryFlag Then
                        '@"移"表示
                        .SetData(llngCnt, CMlngvsfSearchKb, _
                        pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfSearchKb), CMstrIsai))                                                '「移」表示
                    End If
                    
                    .SetData(llngCnt, CMlngvsfSearchProcFlag, ltypProcLotListAns.typProcLotList(arrayIdx).strProcFlag)                   'ﾛｯﾄ種別ﾌﾗｸﾞ
                        
                        
                    .SetData(llngCnt, CMlngvsfSearchWfCarryFlag, ltypProcLotListAns.typProcLotList(arrayIdx).strWfCarryFlag)             'WF移載中ﾌﾗｸﾞ
                        
                    .SetData(llngCnt, CMlngvsfSearchProhibitedFlag,ltypProcLotListAns.typProcLotList(arrayIdx).strVerUpProhibitedFlag)    'VerUP禁止 
                                                            
                    .SetData(llngCnt, CMlngvsfSearchProhibitedEmp,  ltypProcLotListAns.typProcLotList(arrayIdx).strProhibitedEmpName)   '禁止設定者                                                                  
                    .SetData(llngCnt, CMlngvsfSearchProhibitedDept, ltypProcLotListAns.typProcLotList(arrayIdx).strProhibitedDeptName)  '禁止設定者部署                                                                  
                    .SetData(llngCnt, CMlngvsfSearchLotLastUpdate, ltypProcLotListAns.typProcLotList(arrayIdx).strLotLastUpdate)        '最終更新日時
                    
        '@↓2009/02/24 (Tue) 15:48:35 N.Kojima **************************************************

                    '@-----------------------------------------------
                    '@ ﾌｫﾝﾄ色の設定(組立限定機能)
                    '@　①ﾁｯﾌﾟ品LOT：青色
                    '@-----------------------------------------------
        '@↓2009/12/02 (Wed) 10:39:58 H.Hayashi **************************************************
                    '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"
        '            If pstrSBID = CPstrSBID2A0 And _
        '                Left$(ltypProcLotListAns.typProcLotList(llngCnt).strSendSBID, 1) = CPstrProductChip Then
                    
                    If pstrSBID = CPstrSBID2A0 And _
                        ltypProcLotListAns.typProcLotList(arrayIdx).strSbArea = CPstrProductChip Then
                        
                        '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"の場合
        '@↑2009/12/02 (Wed) 10:39:58 H.Hayashi **************************************************
                        
                        '@文字色を青色に変更
                        Dim newStyle_ As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue")
                        newStyle.ForeColor = ColorTranslator.FromWin32(CPlngVbColorBlue )
                        Dim cellRange_ As CellRange = .GetCellRange(llngCnt, CMlngvsfSearchNo, _
                            llngCnt, CMlngvsfSearchLotLastUpdate)
                        cellRange.Style = newStyle
                    
                    End If

        '@↑2009/02/24 (Tue) 15:48:35 N.Kojima **************************************************
                    
                    
                    '@高さの設定
                    .Rows(llngCnt).Height = CMlngRHeight

                   arrayIdx  = arrayIdx + 1
                Next llngCnt

                '@書式設定
                .Cols(CMlngvsfSearchKb).TextAlign = TextAlignEnum.LeftCenter                 '左詰の中央揃え（ﾛｯﾄ状態）
                .Cols(CMlngvsfSearchOpID).TextAlign = TextAlignEnum.LeftCenter               '左詰の中央揃え（大工程）
                .Cols(CMlngvsfSearchStepID).TextAlign = TextAlignEnum.LeftCenter             '左詰の中央揃え（小工程）
                .Cols(CMlngvsfSearchNowSt).TextAlign = TextAlignEnum.LeftCenter              '左詰の中央揃え（状態）
                .Cols(CMlngvsfSearchLotID).TextAlign = TextAlignEnum.LeftCenter              '左詰の中央揃え（ﾛｯﾄID）
                .Cols(CMlngvsfSearchPdID).TextAlign = TextAlignEnum.LeftCenter               '左詰の中央揃え（機種）
                .Cols(CMlngvsfSearchFlowClass).TextAlign = TextAlignEnum.LeftCenter          '左詰の中央揃え（種）
                .Cols(CMlngvsfSearchCarrierID).TextAlign = TextAlignEnum.LeftCenter          '左詰の中央揃え（ｷｬﾘｱID）
                .Cols(CMlngvsfSearchPriority).TextAlign = TextAlignEnum.RightCenter          '右詰の中央揃え（優先順位）
                .Cols(CMlngvsfSearchLotPos).TextAlign = TextAlignEnum.LeftCenter             '左詰の中央揃え（ﾛｯﾄ位置）
                .Cols(CMlngvsfSearchWfNum).TextAlign = TextAlignEnum.RightCenter             '右詰の中央揃え（WF枚数）
                .Cols(CMlngvsfSearchChipNum).TextAlign = TextAlignEnum.RightCenter           '右詰の中央揃え（ﾁｯﾌﾟ）
                .Cols(CMlngvsfSearchLotComments).TextAlign = TextAlignEnum.LeftCenter        '左詰の中央揃え（ｺﾒﾝﾄ）
                .Cols(CMlngvsfSearchProhibitedFlag).TextAlign = TextAlignEnum.LeftCenter     '左詰の中央揃え（VerUp）
                .Cols(CMlngvsfSearchProhibitedEmp).TextAlign = TextAlignEnum.LeftCenter      '左詰の中央揃え（禁止設定者）
                .Cols(CMlngvsfSearchProhibitedDept).TextAlign = TextAlignEnum.LeftCenter     '左詰の中央揃え（禁止設定者部署）
                .Cols(CMlngvsfSearchLotLastUpdate).TextAlign = TextAlignEnum.LeftCenter      '左詰の中央揃え（最終更新日時）

                '@№設定
                For llngCnt = 1 To .Rows.Count - 1
                    .SetData(llngCnt, CMlngvsfSearchNo, llngCnt)
                    '@高さの設定
                   .Rows(llngCnt).Height = CMlngRHeight
                    
                    '@№のｾﾝﾀﾘﾝｸﾞ
                    .Cols(CMlngvsfSearchNo).TextAlign = TextAlignEnum.RightCenter           '右中央
                Next llngCnt

                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@ｵｰﾄ幅設定(ｺﾒﾝﾄ行は対象外)
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(CMlngvsfSearchNo, .Cols.Count - 1, 12)
                End If
                
                '@ﾕｰｻﾞによりｿｰﾄされている場合
                If mtypChgSort.lngCnt > 0 Then
                    '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                    For llngCnt = 0 To mtypChgSort.lngCnt -1
                        '@該当行をｿｰﾄ
                        .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                    Next llngCnt
                End If
                
                '@ｿｰﾄ検索用ｷｰ(ﾛｯﾄID)がある場合
                If mtypChgSort.strKey <> vbNullString Then
                    'NSYS .Rowｾｯﾄ有無判定ﾌﾗｸﾞ
                    Dim blnIsSetRowNo As Boolean = False

                    'NSYS ﾙｰﾌﾟ前に.Rowを初期化
                    .Row = -1
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@ﾛｯﾄIDが同じ場合
                        If .GetData(llngCnt, CMlngvsfSearchLotID) = mtypChgSort.strKey Then
                            .Row = llngCnt
                            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                            Call pubVsfBeforeSort(vsfLotList, CMlngvsfSearchLotID)
                            
                            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                            Call pubVsfAfterSort(vsfLotList, CMlngvsfSearchLotID,Nothing,Nothing,True,True,False,False,False)

                            'NSYS RowNo.セット済み
                            blnIsSetRowNo = True
                            
                            'NSYS カレントセルを行の先頭へ移動
                            .Col = 0

                            
                            Exit For
                        End If
                    Next llngCnt

                    'NSYS ｿｰﾄｷｰ一致するものが無い場合は行選択しない
                    If blnIsSetRowNo = False Then
                        .Row = CMlngTRow
                        .TopRow = CMlngTRow    '行
                    End If
                Else
                    .Row = CMlngTRow           'ｶﾚﾝﾄ行の移動
                    .TopRow = CMlngTRow        '行
                End If

                '@ｸﾞﾘｯﾄﾞを初期値へ移動
                .LeftCol = CMlngTRow           '列

                '@描画ﾛｯｸ解除
                .Redraw = True

                '@ﾛｯｸ解除
                .Enabled = True
            End With

            'NSYS 不要イベント発生抑止解除
            AddHandler vsfLotList.EnterCell, AddressOf vsflotlist_EnterCell
            AddHandler vsflotlist.BeforeRowColChange, AddressOf vsfLotlist_BeforeRowColChange

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfLotList_Disp"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPd_Disp
    '機　能：機種Combo作成
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 16:38:24 N.Kasai
    '更新日：2007/07/03 (Tue) 10:42:38 N.Kasai
    '備　考：
    '　　　：2007/07/03 (Tue) 10:42:38 N.Kasai  機種ｺﾝﾎﾞ複数選択(№02006)
    Private Sub prvcmbPd_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try
            
            With cmbPd
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .DirectInput = False                                                                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                                                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                                                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols1                                                                                   'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbGroupCols                                                                                  '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngProductCnt                                                                                     '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                                                                            '"選択"文字列
                .Font = New Font(.Font.Name, CMlngCmbFontSize,.Font.Style)                                                      'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, .Font.Style, .Font.Unit)                       'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                                                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol1) = TextAlignEnum.LeftCenter                                                      '左寄中央揃え
                    
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngProductCnt-1
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
    '作成日：2006/05/12 (Fri) 16:43:08 N.Kasai
    '更新日：2006/05/12 (Fri) 16:43:08
    '備　考：
    Private Sub prvcmbFlowClass_Disp()
        
        Try

            Dim llngCnt     As Integer      '汎用ｶｳﾝﾀ

            '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)
            With cmbFlowClass
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .DirectInput = False                                                                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                                                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                                                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols1                                                                                   'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbGroupCols                                                                                  '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngFlowClassCnt                                                                                   '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                                                                            '"選択"文字列
                .Font = New Font(.Font.Name, CMlngCmbFontSize,.Font.Style)                                                      'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, .Font.Style, .Font.Unit)                       'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                                                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol1) = TextAlignEnum.LeftCenter                                                      '左寄中央揃え
                
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngFlowClassCnt-1
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

    '関数名：prvcmdSearch_Chk
    '機　能：最新取得ﾎﾞﾀﾝ　使用許可
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 16:43:51 N.Kasai
    '更新日：2006/05/12 (Fri) 16:43:51
    '備　考：
    Private Sub prvcmdSearch_Chk()
        
        Try
            
            '@初期化
            
            
            Select Case True
                '@機種・種別
                Case optSearch0.Checked
                    '@機種
                    If cmbPd.Text = CMstrCmbAddedCommentNone Or _
                                    cmbPd.Text = vbNullString Then
                        cmdSearch.Enabled = False
                        Exit Sub
                    End If
                    
                    '@種別
                    If cmbFlowClass.Text = CMstrCmbAddedCommentNone Or _
                                        cmbFlowClass.Text = vbNullString Then
                        cmdSearch.Enabled = False
                        Exit Sub
                    End If
                
                '@ﾛｯﾄID
                Case optSearch1.Checked
                    '@ﾛｯﾄID2桁以上
                    If Len(txtLotID.Text) < 2 Then
                        cmdSearch.Enabled = False
                        Exit Sub
                    End If
                    
                    '@「_」でないこと
                    '@ﾛｯﾄID1桁目
                    If Strings.Left(txtLotID.Text, 1) = CMstrUnderBar Then
                        cmdSearch.Enabled = False
                        Exit Sub
                    End If
                    
                    '@ﾛｯﾄID2桁目
                    If Mid(txtLotID.Text, 2, 1) = CMstrUnderBar Then
                        cmdSearch.Enabled = False
                        Exit Sub
                    End If
                    
                '@ｷｬﾘｱID
                Case optSearch2.Checked
                    '@@ｷｬﾘｱID1桁以上
                    If Len(txtCarrierID.Text) < 1 Then
                        cmdSearch.Enabled = False
                        Exit Sub
                    End If
                  
            End Select
               
            '@最新取得ﾎﾞﾀﾝ使用可
            cmdSearch.Enabled = True

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmdSearch_Chk"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
                        

                    Case SC_MOVE
                        'フォームの移動を無効化する
                        m.Result = IntPtr.Zero
                        Return
                End Select

            Case WM_CLOSE
                'Application.Exit以外で閉じられようとしている場合
                mblnWindowClose = True
                

        End Select

        MyBase.WndProc(m)

        If lblnSysCommandScClose = True Then
            'NSYS SC_CLOSE 処理後 WM_CLOSE が発生しないでキャンセルされることもあるため、フラグを戻す
            'NSYS WM_CLOSE が発生していれば、すでにこの時点では画面は閉じている
            mblnCloseFromControlMenu = False
        End If
        
    End Sub

    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfLotList.BeforeDoubleClick

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

    '更新日：
    '備　考 ： Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles optSearch0.Enter,
                                                                       cmbPD.Enter,
                                                                       cmbFlowClass.Enter,
                                                                       optFlowClass0.Enter,
                                                                       optFlowClass1.Enter,
                                                                       optSearch1.Enter,
                                                                       txtLotID.Enter,
                                                                       optSearch2.Enter,
                                                                       txtCarrierID.Enter,
                                                                       cmdSearch.Enter,
                                                                       vsfLotList.Enter,
                                                                       cmdClose.Enter,
                                                                       cmdRegist.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '自動Validate = OFF
            Case cmdClose.Name
                Me.AutoValidate = AutoValidate.Disable

            '自動Validate = ON
            Case Else
                Me.AutoValidate = AutoValidate.EnablePreventFocusChange
        End Select
        
    End Sub

    '関数名：flex_OwnerDrawCell	
    '機　能：オーナー描画イベント。Focusの背景色のカスタマイズ	
    '引　数：sender：イベント発生元	
    '　　　：e     ：イベントオブジェクト	
    '戻り値：なし	
    '作成日：2019/03/13 (Wed) 18:00:00 NSYS	
    '更新日：	
    '備　考：	
    Private Sub flex_OwnerDrawCell(ByVal sender As Object, ByVal e As OwnerDrawCellEventArgs) Handles vsfLotList.OwnerDrawCell
        pubVsfOwnerDrawCell(CType(sender, C1FlexGrid), e)	
    End Sub	


End Class
