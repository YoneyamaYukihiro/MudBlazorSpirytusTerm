'ﾌｧｲﾙ名：xxEN02I0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：区間優先設定 メインフォーム
'作成日：2011/09/14 (Wed) 14:09:23 T.Oide
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'      ：
'Copyright(C) SEIKO EPSON CORPORATION 2011-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02I0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02I0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02I0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02I0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02I0)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property

    '******************************************************************************************
    '                                       *定数の記述*
    '******************************************************************************************
    '=========================================Private==========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2018/03/09 (Fri) 12:53:28 Y.Yoneyama **************************************************
    'Private Const CMstrLocalVersion                 As String = "02.00"
    Private Const CMstrLocalVersion                 As String = "02.01"
    '@↑2018/03/09 (Fri) 12:53:28 Y.Yoneyama **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN02I0      'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_secPriorityVer           As String = "02.00"             '区間優先情報取得
    Private Const CMstrlot_secPriorityDetailVer     As String = "01.00"             '区間優先情報詳細取得
    Private Const CMstrlot_chgSecnPriorityVer       As String = "01.00"             '区間優先情報登録
    Private Const CMstrlot_detail__Ver              As String = "03.00"             'ﾛｯﾄ詳細情報
    Private Const CMstrmas_pdlist__Ver              As String = "03.00"             '機種区分一覧取得
    Private Const CMstrmas_wplist__Ver              As String = "05.01"             '装置一覧取得
    Private Const CMstrmas_useoplist_Ver            As String = "02.00"             '大工程ﾏｽﾀ取得
    Private Const CMstrlot_steplistVer              As String = "03.00"             '小工程取得
    '@↓2018/01/17 (Wed) 11:14:37 Y.Yoneyama **************************************************
    'Private Const CMstrlot_list____Ver              As String = "12.00"             'ﾛｯﾄ一覧
    Private Const CMstrlot_list____Ver              As String = "12.01"             'ﾛｯﾄ一覧
    '@↑2018/01/17 (Wed) 11:14:37 Y.Yoneyama **************************************************
    Private Const CMstrlot_oplotlistVer             As String = "07.00"             '大工程ﾛｯﾄ検索一覧
    Private Const CMstrmas_flowlistVer              As String = "04.00"             '種別区分一覧取得
    Private Const CMstrproclist____Ver              As String = "03.01"             'ﾛｯﾄ一覧

    '@ｸﾞﾘｯﾄﾞの初期値定数宣言
    Private Const CMstrGridFontName                 As String = "ＭＳ ゴシック"     'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄ名
    Private Const CMlngGridFontSize                 As Single = 11.25               'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngGridFixedCols                As Integer = 0                  'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngGridFixedRows                As Integer = 1                  'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngGridTitleHeight              As Integer = 20                 'ﾍｯﾀﾞｰの高さ
    Private Const CMlngGridRowHeight                As Integer = 18                 '1明細の高さ
    Private Const CMlngGridPageRows                 As Integer = 10                 '1ﾍﾟｰｼﾞのｾﾙの行数
    Private Const CMlngGrid3DBlank                  As Integer = 4                  'ｸﾞﾘｯﾄﾞの3D表示の余白
    Private Const CMlngGridRowTitle                 As Integer = 0                  'ﾀｲﾄﾙ行(行)
    Private Const CMlngGridScrollBarWidth           As Integer = 16                 '縦ｽｸﾛｰﾙﾊﾞｰの幅

    '@vsf共通のｶﾗﾑ定数
    Private Const CMlngvsfLotListRowTitle           As Integer = 0                  '行ﾀｲﾄﾙ
    Private Const CMlngvsfLotListColTitle           As Integer = 0                  '列ﾀｲﾄﾙ
    Private Const CMlngvsfLotListHHeight            As Integer = 20                 'ﾍｯﾀﾞｰ高さ
    Private Const CMlngvsfLotListHeight             As Integer = 18                 '行高さ
    Private Const CMlngvsfLotListHFontSize          As Single = 11.25               'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ：11
    Private Const CMlngvsfLotListFontSize           As Single = 11.25               'ﾌｫﾝﾄｻｲｽﾞ：11

    '@ｸﾞﾘｯﾄﾞの列設定(vsfCF)
    Private Const CMlngvsfLotListNo                 As Integer = 0                  'No
    Private Const CMlngvsfLotListEdit               As Integer = 1                  '対象
    Private Const CMlngvsfLotListLot                As Integer = 2                  'ロットID
    Private Const CMlngvsfLotListGrbClass           As Integer = 3                  'GRB区分
    Private Const CMlngvsfLotListSOp_Id             As Integer = 4                  '開始大工程
    Private Const CMlngvsfLotListSStep_Id           As Integer = 5                  '開始小工程
    Private Const CMlngvsfLotListEOp_Id             As Integer = 6                  '終了大工程
    Private Const CMlngvsfLotListEStep_Id           As Integer = 7                  '終了小工程
    Private Const CMlngvsfLotListSecPriority        As Integer = 8                  '区間優先度
    Private Const CMlngvsfLotListPriority           As Integer = 9                  '優先度
    Private Const CMlngvsfLotListUser               As Integer = 10                 '設定ユーザ
    Private Const CMlngvsfLotListDate               As Integer = 11                 '設定日時

    '@ｸﾞﾘｯﾄﾞの幅設定
    Private Const CMlngvsfLotListNoW                As Integer = 33                 'No
    Private Const CMlngvsfLotListEditW              As Integer = 41                 '変更
    Private Const CMlngvsfLotListLotW               As Integer = 100                'ロットID
    Private Const CMlngvsfLotListSOp_IdW            As Integer = 131                '開始大工程
    Private Const CMlngvsfLotListSStep_IdW          As Integer = 131                '開始小工程
    Private Const CMlngvsfLotListEOp_IdW            As Integer = 131                '終了大工程
    Private Const CMlngvsfLotListEStep_IdW          As Integer = 131                '終了小工程
    Private Const CMlngvsfLotListSecPriorityW       As Integer = 89                 '区間優先度
    Private Const CMlngvsfLotListPriorityW          As Integer = 54                 '優先度
    Private Const CMlngvsfLotListUserW              As Integer = 125                '設定ユーザ
    Private Const CMlngvsfLotListDateW              As Integer = 160                '設定日時
    Private Const CMlngvsfLotListGrbClassW          As Integer = 54                 'GRB区分

    '@ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ設定
    Private Const CMstrvsfLotListNoT                As String = "No"
    Private Const CMstrvsfLotListEditT              As String = "対象"
    Private Const CMstrvsfLotListLotT               As String = "ロットID"
    Private Const CMstrvsfLotListSOp_IdT            As String = "開始大工程"
    Private Const CMstrvsfLotListSStep_IdT          As String = "開始小工程"
    Private Const CMstrvsfLotListEOp_IdT            As String = "終了大工程"
    Private Const CMstrvsfLotListEStep_IdT          As String = "終了小工程"
    Private Const CMstrvsfLotListSecPriorityT       As String = "区間優先"
    Private Const CMstrvsfLotListPriorityT          As String = "優先度"
    Private Const CMstrvsfLotListUserT              As String = "設定ユーザ"
    Private Const CMstrvsfLotListDateT              As String = "設定日時"
    Private Const CMstrvsfLotListGrbClassT          As String = "GRB"

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMstrCmbFontName                  As String = "ＭＳ ゴシック"         'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄ名
    Private Const CMlngCmbFontSize                  As Single = 11.25                   'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Single = 11.25                   'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName               As Integer = 0                      '名称列番
    Private Const CMlngCmbGridColID                 As Integer = 1                      'ID列番(非表示項目：PD_ID)
    Private Const CMlngCmbGridColID2                As Integer = 2                      'ID列番2(非表示項目：USE_ID)
    Private Const CMlngCmbSortAsc                   As Integer = 1                      '昇順(ｿｰﾄ)
    Private Const CMlngCmbDispCols                  As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                 As Integer = 18                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbClearListIndex            As Integer = -1                     'ﾃｷｽﾄ値初期化
    Private Const CMlngCMbSelectMode                As Integer = 1                      '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMlngCmbFirstListIndex            As Integer = 0                      'ｺﾝﾎﾞLISTの表示位置
    Private Const CMlngCmbGetCol5                   As Integer = 5                      'ﾊﾞｯｸｶﾗｰ格納Col

    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝｲﾝﾃﾞｯｸｽ
    Private Const CMlngoptSerchLot                  As Integer = 0                      'ロット
    Private Const CMlngoptSerchWp                   As Integer = 1                      '装置名
    Private Const CMlngoptSerchOp                   As Integer = 2                      '特定工程
    Private Const CMlngoptSerchPd                   As Integer = 3                      '機種
    Private Const CMlngoptSerchPriority             As Integer = 4                      '区間優先設定あり

    '@その他宣言
    '@↓2018/11/20 (Tue) 11:02:31 T.Oide **************************************************
    'Private Const CPstrPipeString                   As String = "|"                 'ｸﾞﾘｯﾄﾞｺﾝﾎﾞ設定用
    'xxCM0040.basにPublicにして移動
    '@↑2018/11/20 (Tue) 11:02:31 T.Oide **************************************************
    Private Const CMstrCmbCheckOn                   As String = "1"                 'ｺﾝﾎﾞﾁｪｯｸON
    Private Const CMstrSecPriorityAll               As String = "ALL"               '区間優先設定ありのﾃﾞｰﾀを全部取得
    Private Const CMstrAsciiAster                   As String = "*"                 'ﾛｯﾄIDのﾗｲｸ検索
    Private Const CMlngMaxDetailCnt                 As Integer = 20                 '詳細表示Max表示数

    '@色宣言
    Private ReadOnly CMlngEnableFalseColor          As Color = SystemColors.ControlLight    '灰色(使用不可)
    Private Const CMlngInputColor                   As Integer = &HC0C0FF           'ﾋﾟﾝｸ
    Private Const CMlngNotInputColor                As Integer = &HE0E0E0           '薄灰色
    Private ReadOnly CMlngOkForeColor               As Color = Color.Black          '黒色(通常色)
    Private Const CMlngBKColorCel                   As Integer = &HFFC0C0           '薄紫(ｸﾞﾘｯﾄﾞ選択時のﾊﾞｯｸｶﾗｰ)

    Private Const CMlngCmbNoSelect                  As Integer = -1
    Private Const CMstrAddedComment                 As String = "項目選択"          'コンボ一覧選択時の追加コメント
    Private Const CMstrSamePriority                 As String = "(優先度が同一)"    '設定不備メッセージ

    Private Const CMlngZero                         As Integer = 0                  '0(数値)
    Private Const CMlngOne                          As Integer = 1                  '1(数値)
    Private Const CMlngTwo                          As Integer = 2                  '2(数値)
    Private Const CMlngThree                        As Integer = 3                  '3(数値)
    Private Const CMlngFour                         As Integer = 4                  '4(数値)
    Private Const CMlngFive                         As Integer = 5                  '5(数値)
    Private Const CMlngTen                          As Integer = 10                 '10(数値)

    Private Const CMstrDelete                       As String = "削除"

    '******************************************************************************************
    '                                       *変数の記述*
    '******************************************************************************************
    '=========================================Private==========================================
    Private mtypProductList                         As List(Of ProductList)         '機種ﾘｽﾄ格納
    Private mtypSecPriorityDetail                   As typSecPriorityDetail         '区間優先詳細情報格納
    Private mblnEventCancelFlag                     As Boolean                      'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ
    Private mstrBeforEditValue                      As String                       'ｸﾞﾘｯﾄﾞ変更前の値
    Private mblnEditFlag                            As Boolean                      '編集中ﾌﾗｸﾞ
    Private mPdCount                                As Integer                      '機種数
    Private mstrOpID                                As String                       '大工程
    Private mstrStepID                              As String                       '小工程
    Private mtypDivisionList                        As List(Of DivisionList)        '種別格納変数
    Private mlngDivisionListCnt                     As Integer                      '種別格納数
    Private mblnCheckOnFlag                         As Boolean                      'ﾁｪｯｸONﾌﾗｸﾞ(True：ﾁｪｯｸON済み、False：ﾁｪｯｸOFF済み)
    Private mtypGridDrowSecPriority                 As typChgSecPriority            'ﾃﾞｰﾀ取得時の値を変更前の値として格納
    Private buttonProcessing                        As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                      'NSYS WindowCloseフラグ
    Private vsfLotListRowBeforeSort                 As Integer                      'NSYS ｿｰﾄ時の選択行退避
    Private vsfLotListScrollPosition                As Point                        'NSYS ｿｰﾄ時のスクロール位置退避


    '******************************************************************************************
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
    '                                 *イベントハンドラの記述*
    '******************************************************************************************
    '=========================================Private==========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2011/09/14 (Wed) 15:00:42 T.Oide
    '更新日：2011/09/14 (Wed) 15:00:42
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns         As Boolean      '戻り値

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02I0, CMstrLocalVersion)
            
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            'NSYS 画面表示位置
            Me.StartPosition = FormStartPosition.Manual
            Me.Top  = 0
            Me.Left = 0 - My.Settings.FormOffset
            
            '@画面初期化
            Call prvfrmxxEN02I0_Init()
            
            'NSYS ロットIDラジオボタンをチェック状態にする
            optSerch0.Checked = True
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞｾｯﾄ
            pblnFormLoad = True
            
            '@変数初期化
            mblnEditFlag = False        '編集中ﾌﾗｸﾞﾘｾｯﾄ
            mblnCheckOnFlag = False     '全ﾁｪｯｸONﾌﾗｸﾞﾘｾｯﾄ

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
    '機　能：起動時にﾎﾞﾀﾝの有効/無効を設定する
    '引　数：なし
    '戻り値：
    '作成日：2011/09/29 (Thu) 14:14:04 T.Oide
    '更新日：2011/09/29 (Thu) 14:14:04
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
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

    '関数名：optSerch_Click
    '機　能：ｵﾌﾟｼｮﾝﾎﾞﾀﾝ設定時処理
    '引　数：Index：0ロット、1装置名、2特定工程、3機種、4区間設定あり
    '戻り値：
    '作成日：2011/09/15 (Thu) 14:50:08 T.Oide
    '更新日：2011/09/15 (Thu) 14:50:08
    '備　考：
    Private Sub optSerch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optSerch0.CheckedChanged, optSerch1.CheckedChanged, optSerch2.CheckedChanged, optSerch4.CheckedChanged
        
        Try
            'NSYS チェック状態判定
            If sender.Checked = False Then
                Exit Sub
            End If  

            '@Indexによって処理分岐
            Select Case sender.Name
            
                '@ロット
                Case optSerch0.Name
                    txtLotID.Enabled = True
                    cmbWpID.Enabled = False
                    cmbWpID.ListIndex = CMlngCmbNoSelect
                    cmbOpID.Enabled = False
                    cmbOpID.ListIndex = CMlngCmbNoSelect
                    cmbStepID.Enabled = False
                    cmbStepID.ListIndex = CMlngCmbNoSelect
                    cmbProduct.Enabled = False
                    
                '@装置名
                Case optSerch1.Name
                    txtLotID.Enabled = False
                    txtLotID.Text = vbNullString
                    cmbWpID.Enabled = True
                    cmbOpID.Enabled = False
                    cmbOpID.ListIndex = CMlngCmbNoSelect
                    cmbStepID.Enabled = False
                    cmbStepID.ListIndex = CMlngCmbNoSelect
                    cmbProduct.Enabled = False
                    
                '@特定工程
                Case optSerch2.Name
                    txtLotID.Enabled = False
                    txtLotID.Text = vbNullString
                    cmbWpID.Enabled = False
                    cmbWpID.ListIndex = CMlngCmbNoSelect
                    cmbOpID.Enabled = True
                    cmbStepID.Enabled = False
                    cmbStepID.ListIndex = CMlngCmbNoSelect
                    cmbProduct.Enabled = True
                    
                '@区間設定あり
                Case optSerch4.Name
                    txtLotID.Enabled = False
                    txtLotID.Text = vbNullString
                    cmbWpID.Enabled = False
                    cmbWpID.ListIndex = CMlngCmbNoSelect
                    cmbOpID.Enabled = False
                    cmbOpID.ListIndex = CMlngCmbNoSelect
                    cmbStepID.Enabled = False
                    cmbStepID.ListIndex = CMlngCmbNoSelect
                    cmbProduct.Enabled = False
                    
            End Select
            
            mstrOpID = vbNullString
            mstrStepID = vbNullString
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optSerch_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbOpId_Change
    '機　能：フォーカスを移動
    '引　数：なし
    '戻り値：
    '作成日：2011/09/27 (Tue) 12:58:02 T.Oide
    '更新日：2011/09/27 (Tue) 12:58:02
    '備　考：
    Private Sub cmbOpID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOpID.Change

        Try
            '@空ではないか
            If cmbOpID.Text <> vbNullString Then
                cmbStepID.Enabled = True
                SendKeys.SendWait(CPstrSendKeysTab)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOpId_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()


        End Try
    End Sub

    '関数名：cmbOpId_Validate
    '機　能：大工程から小工程一覧を取得する
    '引　数：Cancel：
    '戻り値：
    '作成日：2011/09/15 (Thu) 15:58:43 T.Oide
    '更新日：2011/09/15 (Thu) 15:58:43
    '備　考：
    Private Sub cmbOpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbOpID.Validating
        
        Dim lblnAns         As Boolean              'データ取得結果
        Dim lstrOpID        As String               '大工程
        Dim ltypLotList     As List(Of LotIdList)   'ﾛｯﾄ情報格納構造体
        Dim ltypMasStepList As MasStepList          '小工程情報ｶｳﾝﾀ格納
        Dim llngCnt         As Integer
        Dim lstrFormName    As String
        Dim lstrEventName   As String
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@前回値と同じか
            If mstrOpID = cmbOpID.Text Then
                Exit Sub
            End If
            
            '@大工程を退避
            mstrOpID = cmbOpID.Text
            
            '@空白か
            If cmbOpID.Text = vbNullString Then
                '@閉じるへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = cmbOpID.Name Then
                    Call pubSetFocus(cmdClose)
                End If
                
                Exit Sub
            End If
            
            
           '@ﾚｽﾎﾟﾝ開始
            lstrFormName = Me.Name
            lstrEventName = "cmbOpID_Validate"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@大工程取得
            With cmbOpID
                .ValueCol = 0
                lstrOpID = .Value
            End With
            
            '@小工程取得
            lblnAns = pubblnLotStepList_Sel(pstrSBID, _
                                            CMstrlot_steplistVer, _
                                            CPstrCD28, _
                                            ltypLotList, _
                                            ltypMasStepList, _
                                            lstrOpID)

            With cmbStepID

                '@結果判定
                If lblnAns = True Then
                '@成功の場合
                    .Clear              '初期化
            
                    '@ﾘｽﾄｾｯﾄ
                    For llngCnt = 0 To ltypMasStepList.lngMasStepCnt - 1
                        .AddItem(ltypMasStepList.typMasStepId(llngCnt).strStepID)
                    Next
                    
                Else
                '@異常の場合終了
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
            
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose
            
                    Exit Sub
                End If
                
                '@リストカウントによって動作を変更
                mblnEventCancelFlag = True
                Select Case .ListCount
                    
                    Case 1
                        .ListIndex = -1
                        .Enabled = False
                        
                    Case 2
                        .ListIndex = 1
                        .Enabled = True
                        
                    Case Is > 2
                        .ListIndex = -1
                        .Enabled = True
                        
                End Select
                mblnEventCancelFlag = False
                
            End With
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            '@ﾚｽﾎﾟﾝｽ終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOpId_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbStepId_Change
    '機　能：ﾌｫｰｶｽを次へ移動
    '引　数：なし
    '戻り値：
    '作成日：2011/09/27 (Tue) 13:14:53 T.Oide
    '更新日：2011/09/27 (Tue) 13:14:53
    '備　考：
    Private Sub cmbStepID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStepID.Change

        Try
            '@ｷｬﾝｾﾙﾌﾗｸﾞはTrueか
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            '@空ではないか
            If cmbStepID.Text <> vbNullString Then
                cmbStepID.Enabled = True
                mstrStepID = cmbStepID.Text
                SendKeys.SendWait(CPstrSendKeysTab)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbStepId_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProduct_Change
    '機　能：ﾌｫｰｶｽを次へ移動
    '引　数：なし
    '戻り値：
    '作成日：2011/09/27 (Tue) 13:56:59 T.Oide
    '更新日：2011/09/27 (Tue) 13:56:59
    '備　考：
    Private Sub cmbProduct_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProduct.Change

        Try
            '@ｷｬﾝｾﾙﾌﾗｸﾞはTrueか
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            SendKeys.SendWait(CPstrSendKeysTab)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProduct_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSerch_Click
    '機　能：検索実行
    '引　数：なし
    '戻り値：
    '作成日：2011/09/16 (Fri) 16:55:09 T.Oide
    '更新日：2011/09/16 (Fri) 16:55:09
    '備　考：
    Private Sub cmdSerch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSerch.Click
        
        Dim llngMsgAns      As Integer
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
           '@編集中の場合はユーザに本当にやめるか確認する
            If mblnEditFlag <> False Then
                
                '@$$編集中のデータは破棄されます。$終了してもよろしいですか？
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001W)
                '@メッセージを表示
                llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16)
            
                '@メッセージボックスの戻り値判定
                If llngMsgAns = vbNo Then '「いいえ」を選択
                    Exit Sub
                End If
                
            End If
            
            '@ﾃﾞｰﾀを検索して表示する(追加検索：False、再描画：False)
            Call prvvsfLotListShow(False, False)
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            Exit Sub
                
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDetail_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdSerchAdd_Click
    '機　能：追加検索実行
    '引　数：なし
    '戻り値：
    '作成日：2011/09/16 (Fri) 16:55:40 T.Oide
    '更新日：2011/09/16 (Fri) 16:55:40
    '備　考：
    Private Sub cmdSerchAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSerchAdd.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃﾞｰﾀを検索して表示する(追加検索：True、再描画：False)
            Call prvvsfLotListShow(True, False)
            
            Exit Sub
                
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSerchAdd_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdAllOn_Click
    '機　能：全てのﾁｪｯｸをONにする
    '引　数：なし
    '戻り値：
    '作成日：2011/09/16 (Fri) 16:56:53 T.Oide
    '更新日：2011/09/16 (Fri) 16:56:53
    '備　考：
    Private Sub cmdAllOn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAllOn.Click

        Dim llngCnt         As Integer
        Dim lstrLotID       As String

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfLotList
            
                '@全てのﾁｪｯｸをON/OFFする
                llngCnt = 1
                Do While .Rows.Count > llngCnt
                
                    '@ﾁｪｯｸONﾌﾗｸﾞはTrueか
                    If mblnCheckOnFlag = True Then
                    
                        '@ﾁｪｯｸをOFFする
                        .SetCellCheck(llngCnt, CMlngvsfLotListEdit, CheckEnum.Unchecked)
                        
                        '@変更前の設定値の戻す
                        lstrLotID = .GetData(llngCnt, CMlngvsfLotListLot)
                        Call prvGridDispRollBack(lstrLotID, llngCnt)
                        
                    Else
                        'ﾁｪｯｸをONする
                        .SetCellCheck(llngCnt, CMlngvsfLotListEdit, CheckEnum.Checked)
                    End If
                    llngCnt = llngCnt + 1
                Loop
                
            End With
            
            '@次回実行時の為にﾌﾗｸﾞをｾｯﾄする
            If mblnCheckOnFlag = False Then
                mblnCheckOnFlag = True
            Else
                mblnCheckOnFlag = False
            End If
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            Exit Sub
                
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdAllOn_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdClear_Click
    '機　能：画面初期化
    '引　数：なし
    '戻り値：
    '作成日：2011/09/16 (Fri) 16:57:11 T.Oide
    '更新日：2011/09/16 (Fri) 16:57:11
    '備　考：
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click

        Dim llngMsgAns              As Integer
        
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@編集中の場合はユーザに本当にやめるか確認する
            If mblnEditFlag <> False Then
                
                '@$$編集中のデータは保存されません。$終了してもよろしいですか？
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001W)
                '@メッセージを表示
                llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, False, 16)
            
                '@メッセージボックスの戻り値判定
                If llngMsgAns = vbNo Then '「いいえ」を選択
                    
                    Exit Sub
                End If
                
            End If
            
            '@変数初期化(全部初期化)
            Call prvMemInit(True)
            
            '@画面初期化実行
            Call prvfrmxxEN02I0_Init()
            
            '@ﾛｯﾄをﾁｪｯｸON,ﾛｯﾄID有効化
            optSerch0.Checked = True
            txtLotID.Enabled = True

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

    '関数名：cmdCopy_Click
    '機　能：設定のコピー
    '引　数：なし
    '戻り値：
    '作成日：2011/09/16 (Fri) 16:57:29 T.Oide
    '更新日：2011/09/16 (Fri) 16:57:29
    '備　考：
    Private Sub cmdCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCopy.Click
        
        Dim strLotID   As String
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfLotList
                
                '@上の設定をコピーする
                .SetCellCheck(.Row, CMlngvsfLotListEdit, CheckEnum.Checked)                                                   'ﾁｪｯｸON
                .SetData(.Row, CMlngvsfLotListSOp_Id, .GetData(.Row - 1, CMlngvsfLotListSOp_Id))             '開始大工程
                .SetData(.Row, CMlngvsfLotListSStep_Id, .GetData(.Row - 1, CMlngvsfLotListSStep_Id))         '開始小工程
                .SetData(.Row, CMlngvsfLotListEOp_Id, .GetData(.Row - 1, CMlngvsfLotListEOp_Id))             '終了大工程
                .SetData(.Row, CMlngvsfLotListEStep_Id, .GetData(.Row - 1, CMlngvsfLotListEStep_Id))         '終了小工程
                .SetData(.Row, CMlngvsfLotListSecPriority, .GetData(.Row - 1, CMlngvsfLotListSecPriority))   '区間優先度
                
                '@ﾛｯﾄIDを格納(ﾒｯｾｰｼﾞ用)
                strLotID = .GetData(.Row, CMlngvsfLotListLot)
                
                '@対象ﾛｯﾄの工順取得
                Call prvGetTraveler()
                        
                '@================
                '@ 開始大工程ﾁｪｯｸ
                '@================
                
                '@開始大工程のｺﾝﾎﾞ設定
                Call prvSetStartOpIdList()
                
                '@開始大工程はﾘｽﾄに存在するか
                If InStr(CMlngOne, _
                         vsfLotList.Cols(CMlngvsfLotListSOp_Id).ComboList, _
                         .GetData(.Row, CMlngvsfLotListSOp_Id)) = CMlngZero Then
                
                    '@存在しない場合はNULLに変更
                    .SetData(.Row, CMlngvsfLotListSOp_Id, vbNullString)       '開始大工程
                    .SetData(.Row, CMlngvsfLotListSStep_Id, vbNullString)     '開始小工程
                    .SetData(.Row, CMlngvsfLotListEOp_Id, vbNullString)       '終了大工程
                    .SetData(.Row, CMlngvsfLotListEStep_Id, vbNullString)     '終了小工程
                    .SetData(.Row, CMlngvsfLotListSecPriority, vbNullString)  '区間優先
                    
                    
                    '@ｴﾗｰﾒｯｾｰｼﾞ表示(<TRM112W>$$ロット[%1]の流動票にコピー元の%2が存在しないためコピーできません。)
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0112, strLotID, CMstrvsfLotListSOp_IdT)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If
            
            
                '@================
                '@ 開始小工程ﾁｪｯｸ
                '@================
                '@ｺﾝﾎﾞをｾｯﾄする
                Call prvSetStertStepIdList()

                '@ﾘｽﾄに存在するか
                If InStr(CMlngOne, _
                         vsfLotList.Cols(CMlngvsfLotListSStep_Id).ComboList, _
                         .GetData(.Row, CMlngvsfLotListSStep_Id)) = CMlngZero Then
                
                    '@存在しない場合はNULLに変更
                    .SetData(.Row, CMlngvsfLotListSStep_Id, vbNullString)     '開始小工程
                    .SetData(.Row, CMlngvsfLotListEOp_Id, vbNullString)       '終了大工程
                    .SetData(.Row, CMlngvsfLotListEStep_Id, vbNullString)     '終了小工程
                    .SetData(.Row, CMlngvsfLotListSecPriority, vbNullString)  '区間優先
                    
                    
                    '@ｴﾗｰﾒｯｾｰｼﾞ表示(<TRM112W>$$ロット[%1]の流動票にコピー元の%2が存在しないためコピーできません。)
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0112, strLotID, CMstrvsfLotListSStep_IdT)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If

                '@================
                '@ 終了大工程ﾁｪｯｸ
                '@================
                '@ｺﾝﾎﾞをｾｯﾄする
                Call prvSetEndOpIdList()
                
                '@ﾘｽﾄに存在するか
                If InStr(CMlngOne, _
                         vsfLotList.Cols(CMlngvsfLotListEOp_Id).ComboList, _
                         .GetData(.Row, CMlngvsfLotListEOp_Id)) = CMlngZero Then
                
                    '@存在しない場合はNULLに変更
                    .SetData(.Row, CMlngvsfLotListEOp_Id, vbNullString)       '終了大工程
                    .SetData(.Row, CMlngvsfLotListEStep_Id, vbNullString)     '終了小工程
                    .SetData(.Row, CMlngvsfLotListSecPriority, vbNullString)  '区間優先
                    
                    
                    '@ｴﾗｰﾒｯｾｰｼﾞ表示(<TRM112W>$$ロット[%1]の流動票にコピー元の%2が存在しないためコピーできません。)
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0112, strLotID, CMstrvsfLotListEOp_IdT)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If
                
                '@================
                '@ 終了小工程ﾁｪｯｸ
                '@================
                '@ｺﾝﾎﾞをｾｯﾄする
                Call prvSetEndStepList()
            
                '@ﾘｽﾄに存在するか
                If InStr(CMlngOne, _
                         vsfLotList.Cols(CMlngvsfLotListEStep_Id).ComboList, _
                         .GetData(.Row, CMlngvsfLotListEStep_Id)) = CMlngZero Then
                
                    '@存在しない場合はNULLに変更
                    .SetData(.Row, CMlngvsfLotListEStep_Id, vbNullString)     '終了小工程
                    
                    '@ｴﾗｰﾒｯｾｰｼﾞ表示(<TRM112W>$$ロット[%1]の流動票にコピー元の%2が存在しないためコピーできません。)
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0112, strLotID, CMstrvsfLotListEStep_IdT)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If
                
                '@================
                '@ 区間優先度ﾁｪｯｸ
                '@================
                '@ｺﾝﾎﾞをｾｯﾄする
                Call prvSecPriorityList()
                
                '@ﾘｽﾄに存在するか
                If InStr(CMlngOne, _
                         vsfLotList.Cols(CMlngvsfLotListSecPriority).ComboList, _
                         .GetData(.Row, CMlngvsfLotListSecPriority)) = CMlngZero Then
                
                    '@存在しない場合はNULLに変更
                    .SetData(.Row, CMlngvsfLotListSecPriority, vbNullString)     '区間優先
                    
                    
                    '@ｴﾗｰﾒｯｾｰｼﾞ表示(<TRM113W>$$ロット[%1]は区間優先が未設定なため[削除]は設定できません。$手動で設定してください。)
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0113, strLotID, CMstrvsfLotListSecPriorityT)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If
                
                
            End With
            
            '@編集中ﾌﾗｸﾞｾｯﾄ
            mblnEditFlag = True
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            Exit Sub
                
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCopy_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdHidden_Click
    '機　能：ﾁｪｯｸOFFのﾛｯﾄを非表示にする
    '引　数：なし
    '戻り値：
    '作成日：2011/09/16 (Fri) 17:31:39 T.Oide
    '更新日：2011/09/16 (Fri) 17:31:39
    '備　考：
    Private Sub cmdHidden_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHidden.Click

        Dim llngCnt     As Integer  'ｶｳﾝﾀ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfLotList
            
                '@行数ぶんﾙｰﾌﾟ
                llngCnt = 1
                .Redraw = False
                Do While vsfLotList.Rows.Count > llngCnt
                
                    '@ﾁｪｯｸはOFFか
                    If .GetCellCheck(llngCnt, CMlngvsfLotListEdit) = CheckEnum.Unchecked Then
                        
                        '@ﾁｪｯｸOFFの行を削除
                        .RemoveItem(llngCnt)
                        llngCnt = llngCnt - 1
                    End If
                
                    llngCnt = llngCnt + 1
                Loop
                .Redraw = True
            
            End With
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            Exit Sub
                
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdHidden_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdClipCopy_Click
    '機　能：表示中のﾃﾞｰﾀをｸﾘｯﾌﾟﾎﾞｰﾄﾞにｺﾋﾟｰする
    '引　数：なし
    '戻り値：
    '作成日：2011/10/03 (Mon) 10:12:56 T.Oide
    '更新日：2011/10/03 (Mon) 10:12:56
    '備　考：
    Private Sub cmdClipCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClipCopy.Click

        Dim llngRowCnt     As Integer      '行ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngColCnt     As Integer      '列ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrRET        As String       'ｺﾋﾟｰ文字列
        Dim lstrWk         As String       '文字列編集
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@Clipboardの内容を削除
            Clipboard.Clear
            
            '@一覧をｺﾋﾟｰする
            With vsfLotList
                '@行
                For llngRowCnt = 0 To .Rows.Count - 1
                    '@列
                    For llngColCnt = 0 To .Cols.Count - 1
                        '@列が非表示でない場合
                        If Not .Cols(llngColCnt).Visible = False Then
                        
                            '@文字列編集変数に値をｾｯﾄ
                            lstrWk = Replace(.GetDataDisplay(llngRowCnt, llngColCnt), vbCrLf, ",")
                            
                            '@先頭の文字列が「-」「+」の場合は罫線文字に置き換える
                            If Mid$(lstrWk, 1, 1) = CPstrMinus Then
                                Mid$(lstrWk, 1, 1) = CPstrMinusWide
                            End If
                            If Mid$(lstrWk, 1, 1) = CPstrPlus Then
                                Mid$(lstrWk, 1, 1) = CPstrPlusWide
                            End If

                            If llngColCnt = CMlngvsfLotListEdit AndAlso llngRowCnt <> 0 Then
                                If .GetCellCheck(llngRowCnt, llngColCnt) = CheckEnum.Checked Then
                                    lstrWk = "-1"
                                Else
                                    lstrWk = "0"
                                End If
                            End If
                            
                            '@最終列の場合Tabいらない
                            If llngColCnt = CMlngvsfLotListDate Then
                                '@ｺﾋﾟｰ文字列作成
                                lstrRET = lstrRET & lstrWk
                            Else
                                '@ｺﾋﾟｰ文字列作成
                                lstrRET = lstrRET & lstrWk & vbTab
                            End If
                        End If
                    Next llngColCnt
                    
                    '@ｺﾋﾟｰ文字列作成
                    lstrRET = lstrRET & vbCrLf
                    
                Next llngRowCnt
            End With
            
            '@Clipboard にﾃｷｽﾄ文字列を挿入
            Clipboard.SetText(lstrRET)
            
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0041)
            
            '@publngMsgBoxInfo("メッセージコード：C_I41%0$$クリップボードにコピーしました。
            '@(Excel等に Ctrl＋Vキー で貼り付けてください)")
            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClipCopy_Click"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '関数名：cmdRegist_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：
    '作成日：2011/09/16 (Fri) 16:57:39 T.Oide
    '更新日：2011/09/16 (Fri) 16:57:39
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim ltypChgSecPriority      As typChgSecPriority    '登録情報を格納
        Dim llngCnt                 As Integer              'ｶｳﾝﾀ
        Dim lblnAns                 As Boolean              'ﾃﾞｰﾀ取得結果
        Dim lblnCheck               As Boolean              '登録前のﾁｪｯｸ結果
        Dim lstrFormName            As String               'ﾌｫｰﾑ名
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名
        Dim lstrMsgCode             As String               'ｴﾗｰﾒｯｾｰｼﾞｺｰﾄﾞ
        Dim lstrMsg                 As String               'ｴﾗｰﾒｯｾｰｼﾞ
        Dim lstrLot                 As String               '設定に問題のあるﾛｯﾄIDを格納
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            pstrMessageName = "区間優先登録"
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@ﾌｫｰﾑのﾛｯｸ中は処理を行わない
            If Me.Enabled = False Then
                Exit Sub
            End If

            'NSYS 確定ボタン押下前のスクロール位置を保持
            vsfLotListScrollPosition = vsfLotList.ScrollPosition
            
            '@設定状態ﾁｪｯｸ
            lblnCheck = prvblnChkReg(lstrLot)
            
            '@結果確認
            If lblnCheck = False Then
                '@ｴﾗｰﾒｯｾｰｼﾞ表示「<TRM111W>$$ロット[%1]の設定に不備があります。$設定を見直してください。」
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0111, lstrLot)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                
                Exit Sub
            End If

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If
            
            
            '@ﾚｽﾎﾟﾝ開始
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            With ltypChgSecPriority
            
                '@構造体に登録する情報を格納する
                '@ｸﾞﾘｯﾄﾞの行分ﾙｰﾌﾟ
                llngCnt = 1

                If IsNothing(.typChgSecPriority) Then
                    .typChgSecPriority = New List(Of typChgSecPriList)
                Else
                    .typChgSecPriority.Clear
                End If

                Do While vsfLotList.Rows.Count > llngCnt
                    
                    '@ﾁｪｯｸがONか
                    If vsfLotList.GetData(llngCnt, CMlngvsfLotListEdit) <> False Then
                        '@設定値を構造体に格納
                        .strSbID = pstrSBID
                        
                        Dim typChgSecPriorityTmp As typChgSecPriList = New typChgSecPriList
                        typChgSecPriorityTmp.strLotID = vsfLotList.GetData(llngCnt, CMlngvsfLotListLot)                     'ﾛｯﾄID
                        typChgSecPriorityTmp.strStartOpId = vsfLotList.GetData(llngCnt, CMlngvsfLotListSOp_Id)              '開始大工程
                        typChgSecPriorityTmp.strStartStepId = vsfLotList.GetData(llngCnt, CMlngvsfLotListSStep_Id)          '開始小工程
                        typChgSecPriorityTmp.strEndOpId = vsfLotList.GetData(llngCnt, CMlngvsfLotListEOp_Id)                '終了大工程
                        typChgSecPriorityTmp.strEndStepId = vsfLotList.GetData(llngCnt, CMlngvsfLotListEStep_Id)            '終了小工程
                        typChgSecPriorityTmp.strSectionPriority = vsfLotList.GetData(llngCnt, CMlngvsfLotListSecPriority)   '区間優先度
                        typChgSecPriorityTmp.strEmpID = pstrUserID                                                          '設定ユーザID

                        .typChgSecPriority.Add(typChgSecPriorityTmp)
                        .lngListCnt = .lngListCnt + 1
                    End If
                
                    llngCnt = llngCnt + 1
                Loop
            
            End With

            
            '@区間優先設定登録実行
            lblnAns = pubblnLotSectionPriority_Reg(CMstrlot_chgSecnPriorityVer, _
                                                   ltypChgSecPriority, _
                                                   lstrMsgCode, _
                                                   lstrMsg)
            '@結果判定
            If lblnAns = True Then
            
                '@成功の場合
                
                '@ﾚｽﾎﾟﾝｽ終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            
                '@成功ﾒｯｾｰｼﾞ表示「<TRM78I>$$区間優先設定を登録しました。」
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0078)
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@変数を初期化(一部初期化)
                Call prvMemInit(False)
                
                '@再表示(現在画面にあるﾛｯﾄﾘｽﾄの区間優先情報を再取得して表示する)
                '@ﾃﾞｰﾀを再検索して再表示(追加検索：False、再描画：True)
                Call prvvsfLotListShow(False, True)
                
            Else
            
                '@異常の場合終了
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@ﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(lstrMsgCode & vbCrLf & vbCrLf & lstrMsg)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                
            
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

    '関数名：cmdDetail_Click
    '機　能：詳細画面表示
    '引　数：なし
    '戻り値：
    '作成日：2011/09/16 (Fri) 12:57:38 T.Oide
    '更新日：2011/09/16 (Fri) 12:57:38
    '備　考：
    Private Sub cmdDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDetail.Click

        Dim llngCnt             As Integer
        Dim llngDataCnt         As Integer

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                
            With vsfLotList
            
                '@引渡しデータ設定
                llngCnt = 1
                llngDataCnt = 0

                If IsNothing(pstrLotList) Then
                    pstrLotList = New List(Of String)
                Else
                    pstrLotList.Clear
                End If

                Do While vsfLotList.Rows.Count > llngCnt
                    
                    '@ﾁｪｯｸONか
                    If .GetCellCheck(llngCnt, CMlngvsfLotListEdit) <> CheckEnum.Unchecked Then
                        Dim pstrLotListTmp As String
                        pstrLotListTmp = .GetData(llngCnt, CMlngvsfLotListLot)

                        pstrLotList.Add(pstrLotListTmp)
                        llngDataCnt = llngDataCnt + 1
                    End If
                    
                    llngCnt = llngCnt + 1
                Loop
                
            End With
            
            '@詳細表示はﾃﾞｰﾀ量が多くなるので20ﾛｯﾄで制限する
            If llngDataCnt > CMlngMaxDetailCnt Then
                
                '@ﾒｯｾｰｼﾞ表示(<TRM7DI>$$詳細表示はデータ量が多くなるため$20ロット以下でお願いします。)
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007D)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub
            End If
            
                
            '@詳細画面表示
            frmxxEN02I1.Instance.ShowDialog(Me)
            frmxxEN02I1.Instance = Nothing
                
            Exit Sub
                
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDetail_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub
    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：
    '作成日：2011/09/15 (Thu) 13:45:03 T.Oide
    '更新日：2011/09/15 (Thu) 13:45:03
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
            
            '@ｺﾝﾄﾛｰﾙによって処理分岐
            Select Case ActiveControl.Name
            
               
                '@ﾛｯﾄIDにﾌｫｰｶｽがある場合
                Case txtLotID.Name
                
                    '@ｷｰによって処理分岐
                    Select Case e.KeyCode
                        
                        '@Enterの場合
                        Case Keys.Return
                        
                            '@次の項目へﾌｫｰｶｽ移動
                            SendKeys.SendWait(CPstrSendKeysTab)
                            
                            
                            
                    End Select
                
                '@ｸﾞﾘｯﾄﾞの場合
                Case vsfLotList.Name
                
                    '@ｷｰによって処理分岐
                    Select Case e.KeyCode
                            
                        '@F2ｷｰの場合
                        Case Keys.F2
                        
                            '@編集可否判定
                            Call vsfLotList_Edit()
                            
                        Case Keys.Space
                            
                            '@[対象]の行か
                            If vsfLotList.Col = CMlngvsfLotListEdit Then
                                '@ﾁｪｯｸON/OFFする
                                Call prvGuridCheckOnOff()
                            End If
                            
                    End Select
                    
                    
                
                '@その他のｺﾝﾄﾛｰﾙにﾌｫｰｶｽがある場合
                Case Else
                    
                    '@Enterの場合
                    Select Case e.KeyCode
                        
                        Case Keys.Return
                            
                            '@次ﾌｫｰｶｽへ
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


    '関数名：Form_KeyPress
    '機　能：ﾌｫｰﾑｷｰﾌﾟﾚｽ処理
    '引　数：KeyAscii：ｱｽｷｰｺｰﾄﾞ
    '戻り値：
    '作成日：2011/09/15 (Thu) 13:44:44 T.Oide
    '更新日：2011/09/15 (Thu) 13:44:44
    '備　考：
    Private Sub Form_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress

        Try
            Select Case Asc(e.KeyChar)
                '@ｺﾛﾝ(:)58の場合は入力不可
        '        Case CMlngColonKeyAscii
        '           KeyAscii = 0
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_KeyPress"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：
    '作成日：2011/09/15 (Thu) 13:44:24 T.Oide
    '更新日：2011/09/15 (Thu) 13:44:24
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
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

    '関数名：cmdClose_Click
    '機　能："閉じる"ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/08 (Mon) 11:29:47 T.Oide
    '更新日：2010/03/08 (Mon) 11:29:47
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
            
            '@変数初期化(全部初期化)
            Call prvMemInit(True)
            
            '@終了関数を実行する
            Call publngEnd_Proc(CPstrKeyEN02I0, ltypCommonInfo)
            
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

    '関数名：txtLotID_Change
    '機　能：ﾎﾞﾀﾝの有効/無効を設定する
    '引　数：なし
    '戻り値：
    '作成日：2011/09/29 (Thu) 15:13:39 T.Oide
    '更新日：2011/09/29 (Thu) 15:13:39
    '備　考：
    Private Sub txtLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotID.Change

        Try
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
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

    '関数名：cmbWpId_Change
    '機　能：フォーカスを次のTabIndexに移動
    '引　数：なし
    '戻り値：
    '作成日：2011/09/27 (Tue) 12:51:06 T.Oide
    '更新日：2011/09/27 (Tue) 12:51:06
    '備　考：
    Private Sub cmbWpID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpID.Change

        Try
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
                
            SendKeys.SendWait(CPstrSendKeysTab)
            
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

    '関数名：vsfLotList_AfterEdit
    '機　能：設定値を空に変えられた場合の処理
    '引　数：Row：
    '　　　：Col：
    '戻り値：
    '作成日：2011/09/22 (Thu) 10:12:35 T.Oide
    '更新日：2011/09/22 (Thu) 10:12:35
    '備　考：
    Private Sub vsfLotList_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotList.AfterEdit

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
            
            '@ｷｬﾝｾﾙﾌﾗｸﾞはTrueか
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            With vsfLotList
            
                '@変更前の値と異なるか
                If .GetData(.Row, .Col) <> mstrBeforEditValue Then
                    
                    '@ｷｬﾝｾﾙﾌﾗｸﾞをｾｯﾄ(BeforEdit,AfterEditをｷｬﾝｾﾙする)
                    mblnEventCancelFlag = True
                    
                    Select Case .Col
                        
                        '@開始大工程の場合
                        Case CMlngvsfLotListSOp_Id
                            '@開始大工程以下の設定値を全てからに変更
                            .SetData(.Row, CMlngvsfLotListSStep_Id, vbNullString)     '開始小工程
                            .SetData(.Row, CMlngvsfLotListEOp_Id, vbNullString)       '終了大工程
                            .SetData(.Row, CMlngvsfLotListEStep_Id, vbNullString)     '終了小工程
                            
                        '@開始小工程の場合
                        Case CMlngvsfLotListSStep_Id
                            '@開始小工程以下の設定値を全てからに変更
                            .SetData(.Row, CMlngvsfLotListEOp_Id, vbNullString)       '終了大工程
                            .SetData(.Row, CMlngvsfLotListEStep_Id, vbNullString)     '終了小工程
                            
                        '@終了大工程の場合
                        Case CMlngvsfLotListEOp_Id
                            '@終了小工程以下の設定値を全てからに変更
                            .SetData(.Row, CMlngvsfLotListEStep_Id, vbNullString)     '終了小工程
                          
                        '@区間優先の場合
                        Case CMlngvsfLotListSecPriority
                            
                            '@設定値が"削除"の場合は工程を灰色表示にする
                            If .GetData(.Row, CMlngvsfLotListSecPriority) = CMstrDelete Then
                                '@灰色表示
                                Call prvGridForeColorSet(.Row, ColorTranslator.FromWin32(CMlngNotInputColor))
                            Else
                                '@通常の黒色表示
                                Call prvGridForeColorSet(.Row, CMlngOkForeColor)
                            End If
                            
                    End Select
                    
                    '@ｷｬﾝｾﾙﾌﾗｸﾞをﾘｾｯﾄ
                    mblnEventCancelFlag = False
                    
                End If
                
                '@編集中ﾌﾗｸﾞｾｯﾄ
                mblnEditFlag = True
                
            End With

            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfLotList_BeforeEdit
    '機　能：
    '引　数：Row：
    '　　　：Col：
    '　　　：Cancel：
    '戻り値：
    '作成日：2011/09/21 (Wed) 09:43:58 T.Oide
    '更新日：2011/09/21 (Wed) 09:43:58
    '備　考：
    Private Sub vsfLotList_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotList.StartEdit

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
            
            '@ｷｬﾝｾﾙﾌﾗｸﾞはTrueか
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            '@流動票を取得して構造体に格納する(開始大工程～終了小工程のﾘｽﾄを作成する元ﾈﾀになる)
            Call prvGetTraveler()
            
            With vsfLotList
            
                '@選択ｶﾗﾑで分岐
                Select Case .Col
            
                    '@開始大工程の場合
                    Case CMlngvsfLotListSOp_Id
                        
                        '@開始大工程のﾘｽﾄをｾｯﾄする
                        Call prvSetStartOpIdList()
                        
                     
                    '@開始小工程の場合
                    Case CMlngvsfLotListSStep_Id
                        
                        '@開始小工程のﾘｽﾄをｾｯﾄする
                        Call prvSetStertStepIdList()
                    
                    
                    '@終了大工程の場合
                    Case CMlngvsfLotListEOp_Id
                    
                        '@終了大工程のﾘｽﾄをｾｯﾄする
                        Call prvSetEndOpIdList()
                    
                    
                    '@終了小工程の場合
                    Case CMlngvsfLotListEStep_Id
                        
                        '@終了小工程のﾘｽﾄをｾｯﾄする
                        Call prvSetEndStepList()
                        
                    
                    '@区間優先度の場合
                    Case CMlngvsfLotListSecPriority
                        
                        '@優先度のｺﾝﾎﾞﾘｽﾄ作成
                        Call prvSecPriorityList()
                        
                        
                End Select
            
                '@変更前の値を退避
                mstrBeforEditValue = .GetData(.Row, .Col)
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_Click
    '機　能：選択された列によって処理を実行
    '引　数：なし
    '戻り値：
    '作成日：2011/09/21 (Wed) 13:56:20 T.Oide
    '更新日：2011/09/21 (Wed) 13:56:20
    '備　考：
    Private Sub vsfLotList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
            
            With vsfLotList
            
                Select Case .Col

                    '@変更行ならﾁｪｯｸのON/OFFをする
                    Case CMlngvsfLotListEdit

                        'NSYS データ行でない場合は編集状態にしない
                        If vsfLotList.MouseRow <= 0 Then
                            Exit Sub
                        End If

                        '@ﾁｪｯｸをON/OFFする
                        Call prvGuridCheckOnOff()
                        
                End Select
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfLotList_ComboCloseUp
    '機　能：CloseUpしたらｸﾞﾘｯﾄﾞの編集状態を終了する
    '引　数：Row：未使用
    '　　　：Col：未使用
    '　　　：FinishEdit：編集終了
    '戻り値：
    '作成日：2011/09/22 (Thu) 16:01:18 T.Oide
    '更新日：2011/09/22 (Thu) 16:01:18
    '備　考：
    Private Sub vsfLotList_ComboCloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.ComboCloseUp

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
            
            vsfLotList.FinishEditing()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_ComboCloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfLotList_DblClick
    '機　能：ｸﾞﾘｯﾄﾞを編集状態にする
    '引　数：なし
    '戻り値：
    '作成日：2011/09/22 (Thu) 09:26:52 T.Oide
    '更新日：2011/09/22 (Thu) 09:26:52
    '備　考：
    Private Sub vsfLotList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.DoubleClick

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
            
            '@編集可否判定
            Call vsfLotList_Edit()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '関数名：vsfLotList_RowColChange
    '機　能：ﾎﾞﾀﾝの有効/無効を設定
    '引　数：なし
    '戻り値：
    '作成日：2011/09/29 (Thu) 16:49:03 T.Oide
    '更新日：2011/09/29 (Thu) 16:49:03
    '備　考：
    Private Sub vsfLotList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.RowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
            
            '@ｷｬﾝｾﾙﾌﾗｸﾞTrueか
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_RowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
               
        End Try
    End Sub

    '******************************************************************************************
    '                                       *関数の記述*
    '******************************************************************************************
    '=========================================Private==========================================
    '関数名：prvfrmxxEN02I0_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2011/09/14 (Wed) 15:00:42 T.Oide
    '更新日：2011/09/14 (Wed) 15:00:42
    '備　考：
    Private Sub prvfrmxxEN02I0_Init()

        Dim lstrFormTitle               As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim lblnAns                     As Boolean      '汎用戻り値(True/False)
        Dim llngCnt                     As Integer      '汎用ｶｳﾝﾀ
        Dim lstrFormName                As String       'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String       'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngProductCnt              As Integer      'ﾌﾟﾛﾀﾞｸﾄﾘｽﾄのｶｳﾝﾄ
        Dim llngWpCnt                   As Integer      '装置IDのｶｳﾝﾄ
        Dim lstrClassDivision           As String       '処理区分
        Dim ltypMasOpList               As MasOpList    '大工程情報格納


        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02I0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle

            '@各ｺﾝﾄﾛｰﾙの初期化
            '@ﾛｯﾄ
            With txtLotID
                .Text = vbNullString
                .Enabled = False
            End With
            
            '@機種
            With cmbProduct
                .Clear
                .Enabled = False
                .DirectInput = False
                .DispCols = 1
                .GetCol = 0
                .ColAlignment(.GetCol) = TextAlignEnum.LeftCenter
                .Font = New Font(CMstrCmbFontName, CMlngCmbFontSize, .Font.Style, .Font.Unit)
                .GridFont = New Font(CMstrCmbFontName, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)
                .SelectMode = CMlngOne                          '複数選択ﾓｰﾄﾞ
                .AddedComment = CMstrAddedComment               '項目選択を付加する
                .AllSelectButton = True                         '全数選択ﾎﾞﾀﾝ表示
            End With
            
            '@装置名
            With cmbWpID
                .Clear
                .Enabled = False
                .DirectInput = False
                .DispCols = 1
                .GetCol = 0
                .ColAlignment(.GetCol) = TextAlignEnum.LeftCenter
                .Font = New Font(CMstrCmbFontName, CMlngCmbFontSize, .Font.Style, .Font.Unit)
                .GridFont = New Font(CMstrCmbFontName, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)
                .ValueCol = 1                               '装置ID
                .BackColor = SystemColors.Window            'NSYS 背景色を白色に設定
            End With
            
            '@特定工程(大工程)
            With cmbOpID
                .Clear
                .Enabled = False
                .DirectInput = False
                .DispCols = 1
                .GetCol = 0
                .ColAlignment(.GetCol) = TextAlignEnum.LeftCenter
                .Font = New Font(CMstrCmbFontName, CMlngCmbFontSize, .Font.Style, .Font.Unit)
                .GridFont = New Font(CMstrCmbFontName, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)
                .BackColor = SystemColors.Window            'NSYS 背景色を白色に設定
            End With
            
            '@特定工程(小工程)
            With cmbStepID
                .Clear
                .Enabled = False
                .DirectInput = False
                .DispCols = 1
                .GetCol = 0
                .ColAlignment(.GetCol) = TextAlignEnum.LeftCenter
                .Font = New Font(CMstrCmbFontName, CMlngCmbFontSize, .Font.Style, .Font.Unit)
                .GridFont = New Font(CMstrCmbFontName, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)
                .BackColor = SystemColors.Window            'NSYS 背景色を白色に設定
            End With
            
            '@情報取得日時
            lblNowDate.Text = vbNullString
            
            '@該当件数
            lblLotCnt.Text = vbNullString
            
            '@ｸﾞﾘｯﾄの初期化
            Call prvvsfLotList_Init()
            
            
            '@各種cmbデータ取得設定
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            
            
            '@機種区分一覧取得(画面サイズ指定なし、全て)
            lstrClassDivision = CPstrCD2A & CPstrCD02
            lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                          lstrClassDivision, _
                                          mtypProductList, _
                                          llngProductCnt, _
                                          pstrSBID)
            '@結果判定
            With cmbProduct
                If lblnAns = True Then
                    '@成功の場合
                    If llngProductCnt > 0 Then
                        
                        '@ｺﾝﾎﾞの行、列設定
                        cmbProduct.GroupCols = CMlngOne
                        cmbProduct.GroupRows = llngProductCnt
                        
                        '@ﾘｽﾄｾｯﾄ
                        For llngCnt = 0 To llngProductCnt - 1
                            '@機種ｺﾝﾎﾞ格納
                            .AddItem(mtypProductList(llngCnt).strProductID & vbTab & _
                                     vbNullString & vbTab & _
                                     llngCnt & vbTab & _
                                     vbNullString & vbTab & _
                                     CMstrCmbCheckOn)                '@初期選択状態として全選択の状態にする
                        Next
                        mPdCount = llngProductCnt
                    End If
                    
                    '@選択数を表示
                    mblnEventCancelFlag = True
                    .Text = mPdCount & CMstrAddedComment
                    mblnEventCancelFlag = False
                    
                Else
                '@異常の場合終了
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose
                        
                    Exit Sub
                End If

                '@機種が1件の場合は表示
                If .ListCount = 1 Then
                    .ListIndex = 0
                End If
            End With

            '@装置一覧取
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, _
                                       llngWpCnt, _
                                       pstrSBID, _
                                       CPstrCD02)
            '@結果判定
            With cmbWpID
                If lblnAns = True Then
                '@成功の場合
                    .Clear              '初期化
                    
                    llngCnt = 0
                    If llngWpCnt > 0 Then
                        For llngCnt = 0 To llngWpCnt - 1
                            '@ﾘｽﾄｾｯﾄ
                            .AddItem (ptypWPList(llngCnt).strWpName _
                                   & vbTab _
                                   & ptypWPList(llngCnt).strWpID)
                        Next
                    End If
                Else
                '@異常の場合終了
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)

                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose

                    Exit Sub
                End If

                '@技術担当者が1件か
                If .ListCount = 1 Then
                    '@1件の技術担当者をﾃﾞﾌｫﾙﾄで表示する
                    .ListIndex = 0
                End If
            End With


            '@特定工程取得
            lblnAns = pubblnMasUseOpList_Sel(pstrSBID, _
                                             CMstrmas_useoplist_Ver, _
                                             CPstrCD02, _
                                             ltypMasOpList)
            '@結果判定
            With cmbOpID
                If lblnAns = True Then
                '@成功の場合
                    .Clear              '初期化

                    '@ﾘｽﾄｾｯﾄ
                    For llngCnt =0 To ltypMasOpList.lngMasOpCnt - 1
                        .AddItem(ltypMasOpList.typMasOpId(llngCnt).strOpID)
                    Next
                Else
                    '@異常の場合終了
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)

                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose

                    Exit Sub
                End If

                '@@特定工程取得結果が１件の場合は表示
                If .ListCount = 1 Then
                    .ListIndex = 0
                End If
            End With
            
            '@流動区分ﾏｽﾀｰ取得(全て)
            lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                            mtypDivisionList, _
                                            mlngDivisionListCnt, _
                                            pstrSBID, _
                                            CPstrCD02)

            '@流動区分一覧取得結果が"False：取得失敗"か
            If lblnAns = False Then
                
                '@異常の場合終了
                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効に戻す
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02I0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotList_Init
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：
    '作成日：2010/03/05 (Fri) 13:51:55 T.Oide
    '更新日：2016/02/11 (Thu) 22:17:56 H.Hayashi
    '備　考：
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Private Sub prvvsfLotList_Init()

        Dim ScrollPosition  As Point    'NSYS スクロール位置保持用

        Try
            
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfLotList
                
                mblnEventCancelFlag = True

                'NSYS 元のスクロール位置を保持
                ScrollPosition = .ScrollPosition

                .Redraw = False
                
                '@ﾌﾟﾛﾊﾟﾃｨ初期値
                .Clear
                .Rows.Count = CMlngGridFixedRows
                .Cols.Fixed = CMlngGridFixedCols
                .Rows.Fixed = CMlngGridFixedRows
                .SelectionMode = SelectionModeEnum.Row
                '.FillStyle = flexFillSingle             '単一選択
                .FocusRect = FocusRectEnum.Light         'ｶﾚﾝﾄｾﾙ枠線の設定(細枠)
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                .HighLight = HighLightEnum.Always        'ｸﾞﾘｯﾄﾞからﾌｫｰｶｽが外れた場合でも選択中のｾﾙを分かるようにする
                .Font = New Font(CMstrGridFontName, CMlngGridFontSize, .Font.Style, .Font.Unit)
                .ScrollBars = ScrollBars.Both
                '.AllowSelection = False
                '.AllowBigSelection = False
                .ExtendLastCol = True
                .AllowSorting = AllowSortingEnum.SingleColumn
                .Cols(CMlngvsfLotListNo).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfLotListEdit).ImageAlign = ImageAlignEnum.CenterCenter
                .Cols(CMlngvsfLotListLot).TextAlign = TextAlignEnum.LeftCenter
        '@↓2016/01/16 (Sat) 16:48:38 H.Hayashi **************************************************
                .Cols(CMlngvsfLotListGrbClass).TextAlign = TextAlignEnum.LeftCenter
        '@↑2016/01/16 (Sat) 16:48:38 H.Hayashi **************************************************
                .Cols(CMlngvsfLotListSOp_Id).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfLotListSStep_Id).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfLotListEOp_Id).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfLotListEStep_Id).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfLotListSecPriority).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfLotListPriority).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfLotListUser).TextAlign = TextAlignEnum.LeftCenter
                .Styles.Highlight.BackColor = ColorTranslator.FromWin32(CMlngBKColorCel)          '選択時のﾊﾞｯｸｶﾗｰ(薄紫)
                .Styles.Highlight.ForeColor = CMlngOkForeColor                                    '選択時の文字色(黒)
                
                
                
                '@一覧表ﾀｲﾄﾙの設定
                .Select(CMlngvsfLotListRowTitle, CMlngvsfLotListColTitle, .Rows.Count - 1, .Cols.Count - 1)
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                                  '中央表示
                lFixedStyle.ForeColor = Color.Yellow                                                '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)                   '背景色
                lFixedStyle.Font = New Font(lFixedStyle.Font.FontFamily, CMlngvsfLotListHFontSize, _
                                            lFixedStyle.Font.Style, lFixedStyle.Font.Unit)          'ﾌｫﾝﾄｻｲｽﾞ
                lFixedStyle.Trimming = StringTrimming.None                                          'NSYS ヘッダー文字列を省略表示しない
                .Rows(CMlngvsfLotListRowTitle).Height = CMlngvsfLotListHHeight                      '高さ
                
                
                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMlngvsfLotListNo).Width = CMlngvsfLotListNoW                                       'No(幅)
                .SetData(CMlngvsfLotListRowTitle, CMlngvsfLotListNo, CMstrvsfLotListNoT)                  'No(ﾀｲﾄﾙ)
                .Cols(CMlngvsfLotListNo).TextAlign = TextAlignEnum.GeneralCenter                          'No(ｱﾗｲﾒﾝﾄ)
                
                .Cols(CMlngvsfLotListEdit).Width = CMlngvsfLotListEditW                                   '変更(幅)
                .SetData(CMlngvsfLotListRowTitle, CMlngvsfLotListEdit, CMstrvsfLotListEditT)              '変更(ﾀｲﾄﾙ)
                .Cols(CMlngvsfLotListEdit).TextAlign = TextAlignEnum.GeneralCenter                        '変更(ｱﾗｲﾒﾝﾄ)
                .Cols(CMlngvsfLotListEdit).DataType = GetType(Boolean)                                    'NSYS DatatypeをBooleanに設定
                
                .Cols(CMlngvsfLotListLot).Width = CMlngvsfLotListLotW                                     'ロットID(幅)
                .SetData(CMlngvsfLotListRowTitle, CMlngvsfLotListLot, CMstrvsfLotListLotT)                'ロットID(ﾀｲﾄﾙ)
                .Cols(CMlngvsfLotListLot).TextAlign = TextAlignEnum.GeneralCenter                         'ロットID(ｱﾗｲﾒﾝﾄ)
                
        '@↓2016/01/16 (Sat) 16:50:07 H.Hayashi **************************************************
                .Cols(CMlngvsfLotListGrbClass).Width = CMlngvsfLotListGrbClassW                           'GRB区分(幅)
                .SetData(CMlngvsfLotListRowTitle, CMlngvsfLotListGrbClass, CMstrvsfLotListGrbClassT)      'GRB(ﾀｲﾄﾙ)
                .Cols(CMlngvsfLotListGrbClass).TextAlign = TextAlignEnum.GeneralCenter                    'GRB(ｱﾗｲﾒﾝﾄ)
        '@↑2016/01/16 (Sat) 16:50:07 H.Hayashi **************************************************

                .Cols(CMlngvsfLotListSOp_Id).Width = CMlngvsfLotListSOp_IdW                               '開始大工程(幅)
                .SetData(CMlngvsfLotListRowTitle, CMlngvsfLotListSOp_Id, CMstrvsfLotListSOp_IdT)          '開始大工程(ﾀｲﾄﾙ)
                .Cols(CMlngvsfLotListSOp_Id).TextAlign = TextAlignEnum.GeneralCenter                      '開始大工程(ｱﾗｲﾒﾝﾄ)
                
                .Cols(CMlngvsfLotListSStep_Id).Width = CMlngvsfLotListSStep_IdW                           '開始小工程(幅)
                .SetData(CMlngvsfLotListRowTitle, CMlngvsfLotListSStep_Id, CMstrvsfLotListSStep_IdT)      '開始小工程(ﾀｲﾄﾙ)
                .Cols(CMlngvsfLotListSStep_Id).TextAlign = TextAlignEnum.GeneralCenter                    '開始小工程(ｱﾗｲﾒﾝﾄ)
                
                .Cols(CMlngvsfLotListEOp_Id).Width = CMlngvsfLotListEOp_IdW                               '終了大工程(幅)
                .SetData(CMlngvsfLotListRowTitle, CMlngvsfLotListEOp_Id, CMstrvsfLotListEOp_IdT)          '終了大工程(ﾀｲﾄﾙ)
                .Cols(CMlngvsfLotListEOp_Id).TextAlign = TextAlignEnum.GeneralCenter                      '終了大工程(ｱﾗｲﾒﾝﾄ)
                
                .Cols(CMlngvsfLotListEStep_Id).Width = CMlngvsfLotListEStep_IdW                           '終了小工程(幅)
                .SetData(CMlngvsfLotListRowTitle, CMlngvsfLotListEStep_Id, CMstrvsfLotListEStep_IdT)      '終了小工程(ﾀｲﾄﾙ)
                .Cols(CMlngvsfLotListEStep_Id).TextAlign = TextAlignEnum.GeneralCenter                    '終了小工程(ｱﾗｲﾒﾝﾄ)
                        
                .Cols(CMlngvsfLotListSecPriority).Width = CMlngvsfLotListSecPriorityW                       '区間優先度(幅)
                .SetData(CMlngvsfLotListRowTitle, CMlngvsfLotListSecPriority, CMstrvsfLotListSecPriorityT)  '区間優先度(ﾀｲﾄﾙ)
                .Cols(CMlngvsfLotListSecPriority).TextAlign = TextAlignEnum.GeneralCenter                   '区間優先度(ｱﾗｲﾒﾝﾄ)
                
                .Cols(CMlngvsfLotListPriority).Width = CMlngvsfLotListPriorityW                           '優先度(幅)
                .SetData(CMlngvsfLotListRowTitle, CMlngvsfLotListPriority, CMstrvsfLotListPriorityT)      '優先度(ﾀｲﾄﾙ)
                .Cols(CMlngvsfLotListPriority).TextAlign = TextAlignEnum.GeneralCenter                    '優先度(ｱﾗｲﾒﾝﾄ)
                
                .Cols(CMlngvsfLotListUser).Width = CMlngvsfLotListUserW                                   '設定ユーザ(幅)
                .SetData(CMlngvsfLotListRowTitle, CMlngvsfLotListUser, CMstrvsfLotListUserT)              '設定ユーザ(ﾀｲﾄﾙ)
                .Cols(CMlngvsfLotListUser).TextAlign = TextAlignEnum.GeneralCenter                        '設定ユーザ(ｱﾗｲﾒﾝﾄ)
                
                .Cols(CMlngvsfLotListDate).Width = CMlngvsfLotListDateW                                   '設定日時(幅)
                .SetData(CMlngvsfLotListRowTitle, CMlngvsfLotListDate, CMstrvsfLotListDateT)              '設定日時(ﾀｲﾄﾙ)
                .Cols(CMlngvsfLotListDate).TextAlign = TextAlignEnum.GeneralCenter                        '設定日時(ｱﾗｲﾒﾝﾄ)
                
                'NSYS 横スクロール位置を設定
                If pblnFormLoad = False Then
                    .LeftCol = .Cols.Fixed
                Else
                     .ScrollPosition = New Point(ScrollPosition.X,.ScrollPosition.Y)
                End If
                
                .Redraw = True

                '@無効化
                .Enabled = False
                
                mblnEventCancelFlag = False
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotList_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnChekSerchCondition
    '機　能：検索条件をﾁｪｯｸして、区間優先情報を取得するﾛｯﾄﾘｽﾄを取得
    '引　数：lstrLotLis：
    '戻り値：
    '作成日：2011/09/20 (Tue) 13:32:19 T.Oide
    '更新日：2011/09/20 (Tue) 13:32:19
    '備　考：
    Private Function prvblnChekSerchCondition(ByRef lstrLotList As List(Of String)) As Boolean

        Dim lstrFormName                As String           'ﾌｫｰﾑ名
        Dim lstrEventName               As String           'ｲﾍﾞﾝﾄ名
        Dim lblnAns                     As Boolean          '取得結果
        Dim ltypLotListReq              As LotListReq       'ﾛｯﾄ一覧要求構造体
        Dim ltypLotListAns              As LotListAns       'ﾛｯﾄ一覧応答格納用
        Dim llngLotListCnt              As Integer          'ﾃﾞｰﾀ格納数
        Dim llngCnt                     As Integer          '汎用ｶｳﾝﾀ
        Dim ltypLotListOp               As OpLotList
        Dim ltypLotList                 As LotList          'ﾛｯﾄ一覧取得情報格納
        Dim lstrLotID                   As String
        Dim ltypProcLotListReq          As ProcLotListReq   'ﾛｯﾄ一覧要求情報構造体
        Dim ltypProcLotListAns          As ProcLotListAns   'ﾛｯﾄ一覧取得情報格納
        
        Try
            
            '@ﾚｽﾎﾟﾝ開始
            lstrFormName = Me.Name
            lstrEventName = "prvblnChekSerchCondition"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '結果初期化
            prvblnChekSerchCondition = False
            
            '@配列設定
            Dim lstrLotListTmp As String
            
            '@=======================
            '@ ﾛｯﾄで検索の場合
            '@=======================
            If optSerch0.Checked = True Then
            
                '@ﾛｯﾄIDは10桁か
                If Len(txtLotID.Text) < CMlngTen Then
                    
                    '@2文字以上は入れる
                    If Len(txtLotID.Text) < CMlngTwo Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001H)
                        '@「ロットIDは2桁以上入力してください。」
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        Exit Function
                        
                    End If
                
                    '@ﾛｯﾄID + "*"
                    lstrLotID = txtLotID.Text & CMstrAsciiAster
                    
                    '@要求構造体へ情報を格納
                    With ltypProcLotListReq
                        .strSbID = pstrSBID                                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strAction = "0"                                                        'ｱｸｼｮﾝ(工順変更中ﾛｯﾄを含まない)
                        .strMsgVer = CMstrproclist____Ver                                       'Msgﾊﾞｰｼﾞｮﾝ
                        .strLotFlowStatusID = CMlngThree                                        '流動区分(0:流動前,1:流動中 2:流動終了 3:流動外以外)
                        
                        '@種別区分構造体作成
                        .lngPdCnt = 0                                                           '機種ｶｳﾝﾄ
                        If IsNothing(.typPdList) Then
                            .typPdList = New List(Of PDList)
                        Else
                            .typPdList.Clear
                        End If
                        
                        '@種別区分構造体作成
                        .lngFlowClassListCnt = 0                                                '種別ｶｳﾝﾄ
                        If IsNothing(.typFlowClassList) Then
                            .typFlowClassList = New List(Of FlowClassList)
                        Else
                            .typFlowClassList.Clear
                        End If
            
                        .strLotID = lstrLotID                                                   'ﾛｯﾄID
                        .strCarrierId = vbNullString                                            'ｷｬﾘｱID
                    End With
            
                
                    '@ﾛｯﾄ一覧取得
                    lblnAns = pubblnProcList_Sel(ltypProcLotListReq, ltypProcLotListAns)
                    
                    '@結果判定
                    If lblnAns = True Then
                        
                        '@取得結果は1件以上か
                        If ltypProcLotListAns.lngProcLotListCnt > 0 Then
                        
                            '@ﾛｯﾄ一覧取得に成功の場合(ﾛｯﾄのﾘｽﾄを格納)
                            For llngCnt = 0 To ltypProcLotListAns.lngProcLotListCnt - 1
                                lstrLotListTmp = ltypProcLotListAns.typProcLotList(llngCnt).strLotID
                                lstrLotList.Add(lstrLotListTmp)
                            Next
                            
                        End If
                    Else
                    
                        '@ﾛｯﾄ一覧取得に失敗
                        '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        Exit Function
                        
                    End If
                    
                Else
                    
                    '@10桁以上ある場合
                    lstrLotList.Add(txtLotID.Text)
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ(いきなり検索できるので)
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                
                End If
                
                '@ﾚｽﾎﾟﾝｽ終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
            End If
            
            
            '@=======================
            '@ 装置名で検索の場合
            '@=======================
            If optSerch1.Checked = True Then
               
                '@ 送信ﾃﾞｰﾀ作成
                With ltypLotListReq
                    .strMsgVer = CMstrlot_list____Ver       'Msgﾊﾞｰｼﾞｮﾝ
                    .strClassDivision = CPstrCD26           '処理区分：26(装置別ﾛｯﾄ一覧)
                    .strSbID = pstrSBID                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                    .strWpID = cmbWpID.Value                '装置ID
                End With
                
                '@ ﾛｯﾄ一覧情報取得
                lblnAns = pubblnLotList_Sel(ltypLotListReq, _
                                            ltypLotListAns, _
                                            llngLotListCnt)
            
                '@取得結果は成功か
                If lblnAns = True Then
                    
                    '@取得結果は1件以上か
                    If llngLotListCnt > 0 Then
                        'ﾛｯﾄﾘｽﾄを変数に格納
                        For llngCnt = 0 To llngLotListCnt - 1
                            lstrLotListTmp = ltypLotListAns.typLotList(llngCnt).strLotID
                            lstrLotList.Add(lstrLotListTmp)
                        Next
                    End If
                
                Else
                
                    '@異常の場合終了
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    Exit Function
                    
                End If
                
                '@ﾚｽﾎﾟﾝｽ終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
            End If
            
            
            '@=======================
            '@ 特定工程で検索の場合
            '@=======================
            If optSerch2.Checked = True Then
                
                '@工程別ﾛｯﾄ一覧取得要求ﾃﾞｰﾀ作成処理(27：大工程・小工程指定/機種・種別全指定)
                Call prvLotListReq_Proc(CPstrCD27, ltypLotListOp)
                
                
                '@工程別ﾛｯﾄ一覧取得
                lblnAns = pubblnOpLotList_Sel(ltypLotListOp, _
                                              ltypLotList, _
                                              llngLotListCnt)
                

                '@工程別ﾛｯﾄ一覧ﾘｽﾄ取得処理結果が"True：処理成功"か
                If lblnAns = True Then

                    '@工程別ﾛｯﾄ一覧取得ﾃﾞｰﾀ数が1件以上あるか
                    If llngLotListCnt > 0 Then

                        '@ﾛｯﾄﾘｽﾄを変数に格納
                        For llngCnt = 0 To llngLotListCnt - 1
                            lstrLotListTmp = ltypLotList.typLotListList(llngCnt).strLotID
                            lstrLotList.Add(lstrLotListTmp)
                        Next
                        
                    End If
                    
                    '@ﾚｽﾎﾟﾝｽ終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                
                Else
                
                    '@異常の場合終了
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    Exit Function
                    
                End If
                
            End If
            
            
            '@=======================
            '@ 区間優先設定ありで取得の場合
            '@=======================
            If optSerch4.Checked = True Then
                '@ALLをｾｯﾄ
                lstrLotList.Add(CMstrSecPriorityAll)                '@LOT_ID = ALL で"設定あり"のﾛｯﾄを全ﾛｯﾄ取得する
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ(いきなり検索できるので)
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
            End If
            
            
            '結果成功
            prvblnChekSerchCondition = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnChekSerchCondition"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnChkReg
    '機　能：登録前の設定ﾁｪｯｸを実施
    '引　数：lstrLot：設定に問題のあるﾛｯﾄを格納(先頭1ﾛｯﾄのみ)
    '戻り値：True：設定OK、Fase:設定に問題あり
    '作成日：2011/09/20 (Tue) 16:58:29 T.Oide
    '更新日：2011/09/20 (Tue) 16:58:29
    '備　考：
    Private Function prvblnChkReg(ByRef lstrLot As String) As Boolean

        Dim llngCnt     As Integer       'ｶｳﾝﾀｰ

        Try
            
            '@結果初期化
            prvblnChkReg = False
            
            '@ｸﾞﾘｯﾄﾞの行数ぶんﾙｰﾌﾟ
            llngCnt = 1
            Do While vsfLotList.Rows.Count > llngCnt
            
                '@変更がONか
                If vsfLotList.GetData(llngCnt, CMlngvsfLotListEdit) <> False Then
                    
                    '@開始大工程,開始小工程、終了大工程、終了小工程、区間優先度 のいずれかがNULLではないか
                    If vsfLotList.GetData(llngCnt, CMlngvsfLotListSOp_Id) = vbNullString Or _
                       vsfLotList.GetData(llngCnt, CMlngvsfLotListSStep_Id) = vbNullString Or _
                       vsfLotList.GetData(llngCnt, CMlngvsfLotListEOp_Id) = vbNullString Or _
                       vsfLotList.GetData(llngCnt, CMlngvsfLotListEStep_Id) = vbNullString Or _
                       vsfLotList.GetData(llngCnt, CMlngvsfLotListSecPriority) = vbNullString Then
                    
                        '@設定不備のﾛｯﾄを格納して返す
                        lstrLot = vsfLotList.GetData(llngCnt, CMlngvsfLotListLot)
                        
                        '@不備の行にﾌｫｰｶｽを移動
                        vsfLotList.Select(llngCnt, CMlngvsfLotListLot)

                        'NSYS スクロール位置を移動しない
                        vsfLotList.ScrollPosition = New Point(vsfLotList.ScrollPosition.X, vsfLotListScrollPosition.Y)
                        
                        Exit Function
                    
                    End If
                    
                    '@区間優先と優先度の設定値が同一ではないか
                    If vsfLotList.GetData(llngCnt, CMlngvsfLotListPriority) = _
                       vsfLotList.GetData(llngCnt, CMlngvsfLotListSecPriority) Then
                    
                        '@設定不備のﾛｯﾄを格納して返す
                        lstrLot = vsfLotList.GetData(llngCnt, CMlngvsfLotListLot) & CMstrSamePriority
                        
                        '@不備の行にﾌｫｰｶｽを移動
                        vsfLotList.Select(llngCnt, CMlngvsfLotListLot)

                        'NSYS スクロール位置を移動しない
                        vsfLotList.ScrollPosition = New Point(vsfLotList.ScrollPosition.X, vsfLotListScrollPosition.Y)
                        
                        Exit Function
                    
                    End If
                    
                End If
                
                llngCnt = llngCnt + 1
            Loop
            
            '@結果OKを格納
            prvblnChkReg = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnChkReg"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：vsfLotList_Edit
    '機　能：ｸﾞﾘｯﾄﾞの編集可否を判定
    '引　数：なし
    '戻り値：
    '作成日：2011/09/22 (Thu) 09:57:01 T.Oide
    '更新日：2011/09/22 (Thu) 09:57:01
    '備　考：
    Private Sub vsfLotList_Edit()

        Try

            'NSYS データ行でない場合は編集状態にしない
            If vsfLotList.Row <= 0 Then
                Exit Sub
            End If

            With vsfLotList
            
                Select Case .Col
                    
                    '@開始大工程の場合
                    Case CMlngvsfLotListSOp_Id
                    
                        '@ﾁｪｯｸはONか
                        If .GetCellCheck(.Row, CMlngvsfLotListEdit) <> CheckEnum.Unchecked Then
                            
                            'NSYS 編集時の前景色と背景色を設定
                            If Not IsNothing(.GetCellStyle(.Row, .Col)) Then
                                'NSYS セルの背景色を編集中の背景色にも設定
                                .Styles.Editor.BackColor = .GetCellStyle(.Row, .Col).BackColor
                                .Styles.Editor.ForeColor = .GetCellStyle(.Row, .Col).ForeColor
                            Else
                                'NSYS 編集中の背景色を白色に設定
                                .Styles.Editor.BackColor = SystemColors.Window
                                .Styles.Editor.ForeColor = SystemColors.WindowText
                            End If
                            
                            '@編集状態にする
                            .Select(.Row, .Col)
                            .StartEditing()
                            
                        End If
                        
                        
                    '@開始小工程の場合
                    Case CMlngvsfLotListSStep_Id
                        '@開始大工程が設定済みなら変更を可にする(ﾘｽﾄは、開始大工程の選択時に入れる)
                        
                        '@開始大工程はNULL以外か
                        If .GetData(.Row, CMlngvsfLotListSOp_Id) <> vbNullString And _
                           .GetCellCheck(.Row, CMlngvsfLotListEdit) <> CheckEnum.Unchecked Then
                            
                            'NSYS 編集時の前景色と背景色を設定
                            If Not IsNothing(.GetCellStyle(.Row, .Col)) Then
                                'NSYS セルの背景色を編集中の背景色にも設定
                                .Styles.Editor.BackColor = .GetCellStyle(.Row, .Col).BackColor
                                .Styles.Editor.ForeColor = .GetCellStyle(.Row, .Col).ForeColor
                            Else
                                'NSYS 編集中の背景色を白色に設定
                                .Styles.Editor.BackColor = SystemColors.Window
                                .Styles.Editor.ForeColor = SystemColors.WindowText
                            End If

                            '@編集状態にする
                            .Select(.Row, .Col)
                            .StartEditing()
                            
                        End If
                    
                    
                    '@終了大工程の場合
                    Case CMlngvsfLotListEOp_Id
                        '@開始小工程が設定済みなら変更を可にする(ﾘｽﾄは、開始小工程の選択時に入れる)
                        '@ﾘｽﾄは、開始大工程より後の工程だけ
                    
                        '@開始小工程はNULL以外か
                        If .GetData(.Row, CMlngvsfLotListSStep_Id) <> vbNullString And _
                           .GetCellCheck(.Row, CMlngvsfLotListEdit) <> CheckEnum.Unchecked Then

                            'NSYS 編集時の前景色と背景色を設定
                            If Not IsNothing(.GetCellStyle(.Row, .Col)) Then
                                'NSYS セルの背景色を編集中の背景色にも設定
                                .Styles.Editor.BackColor = .GetCellStyle(.Row, .Col).BackColor
                                .Styles.Editor.ForeColor = .GetCellStyle(.Row, .Col).ForeColor
                            Else
                                'NSYS 編集中の背景色を白色に設定
                                .Styles.Editor.BackColor = SystemColors.Window
                                .Styles.Editor.ForeColor = SystemColors.WindowText
                            End If
                            
                            '@編集状態にする
                            .Select(.Row, .Col)
                            .StartEditing()
                            
                        End If
                        
                    
                    '@終了小工程の場合
                    Case CMlngvsfLotListEStep_Id
                        '@終了大工程が設定済みなら変更を可にする(ﾘｽﾄは、終了大工程の選択時に入れる)
                    
                        '@終了大工程はNULL以外か
                        If .GetData(.Row, CMlngvsfLotListEOp_Id) <> vbNullString And _
                           .GetCellCheck(.Row, CMlngvsfLotListEdit) <> CheckEnum.Unchecked Then

                            'NSYS 編集時の前景色と背景色を設定
                            If Not IsNothing(.GetCellStyle(.Row, .Col)) Then
                                'NSYS セルの背景色を編集中の背景色にも設定
                                .Styles.Editor.BackColor = .GetCellStyle(.Row, .Col).BackColor
                                .Styles.Editor.ForeColor = .GetCellStyle(.Row, .Col).ForeColor
                            Else
                                'NSYS 編集中の背景色を白色に設定
                                .Styles.Editor.BackColor = SystemColors.Window
                                .Styles.Editor.ForeColor = SystemColors.WindowText
                            End If
                            
                            '@編集状態にする
                            .Select(.Row, .Col)
                            .StartEditing()
                            
                        End If
                    
                    
                    '@区間優先度の場合
                    Case CMlngvsfLotListSecPriority
                        '@区間優先自身が空白なら1～5のﾘｽﾄを入れ変更を可にする(新規設定)
                        '@区間優先自身が空白以外なら1～5と"削除"をﾘｽﾄを入れ変更を可にする(変更設定)
                        
                        '@終了小工程はNULL以外か
                        If .GetData(.Row, CMlngvsfLotListEStep_Id) <> vbNullString And _
                           .GetCellCheck(.Row, CMlngvsfLotListEdit) <> CheckEnum.Unchecked Then

                            'NSYS 編集時の前景色と背景色を設定
                            If Not IsNothing(.GetCellStyle(.Row, .Col)) Then
                                'NSYS セルの背景色を編集中の背景色にも設定
                                .Styles.Editor.BackColor = .GetCellStyle(.Row, .Col).BackColor
                                .Styles.Editor.ForeColor = .GetCellStyle(.Row, .Col).ForeColor
                            Else
                                'NSYS 編集中の背景色を白色に設定
                                .Styles.Editor.BackColor = SystemColors.Window
                                .Styles.Editor.ForeColor = SystemColors.WindowText
                            End If
                            
                            '@編集状態にする
                            .Select(.Row, .Col)
                            .StartEditing()
                            
                        End If
                        
                End Select
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_Edit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotListShow
    '機　能：ﾃﾞｰﾀを検索して表示する
    '引　数：blnDataAddFlag：False:検索、True：追加検索
    '引　数：blnRedrawFlag:再描画ﾌﾗｸﾞ
    '戻り値：
    '作成日：2011/09/22 (Thu) 17:06:05 T.Oide
    '更新日：2016/02/11 (Thu) 22:18:40 H.Hayashi
    '備　考：
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Private Sub prvvsfLotListShow(ByVal blnDataAddFlag As Boolean, ByVal blnRedrawFlag As Boolean)

        Dim lblnAns         As Boolean          'ﾃﾞｰﾀ取得結果
        Dim lblnCheckAns    As Boolean          '検索条件取得結果格納
        Dim lstrLotList     As List(Of String)  'ﾛｯﾄﾘｽﾄ
        Dim llngCnt         As Integer          '汎用ｶｳﾝﾀ
        Dim lstrFormName    As String           'ﾌｫｰﾑ名
        Dim lstrEventName   As String           'ｲﾍﾞﾝﾄ名
        Dim ltypSecPriority As typSecPriority   '区間優先設定取得結果格納
        Dim lstrCurLotId    As String           '追加表示の場合の現在LotID
        Dim lblnFindFlag    As Boolean          '追加表示の場合にﾃﾞｰﾀが既にあるか(True：表示済み、False：未表示)
        Dim llngCnt2        As Integer          '重複ﾛｯﾄを探すためのｶｳﾝﾀ
        Dim llngCnt3        As Integer          'ｸﾞﾘｯﾄﾞ行を示す表示用ｶｳﾝﾀ
        Dim lngDispStartRow As Integer
        Dim llngBeforCnt    As Integer          '結果取得後の描画前の行数を格納
        Dim lintBeforRow    As Integer          'NSYS 検索前の選択行保持用
        Dim newStyle        As CellStyle        'NSYS セルスタイル
        Dim newStyle2       As CellStyle        'NSYS セルスタイル
        Dim cellRange       As CellRange        'NSYS セルレンジ
        Dim cellRange2      As CellRange        'NSYS セルレンジ
        Dim ScrollPosition  As Point            'NSYS スクロール位置保持用

        Try
            'NSYS 元のスクロール位置を保持
            ScrollPosition = vsfLotList.ScrollPosition

            'NSYS リスト初期化
            If IsNothing(lstrLotList) Then
                lstrLotList = New List(Of String)
            Else
                lstrLotList.Clear
            End If
            
            If blnRedrawFlag = False Then
                
                '@検索条件ﾁｪｯｸ
                lblnCheckAns = prvblnChekSerchCondition(lstrLotList)
                
                '@結果判定
                If lblnCheckAns = False Then
                    Exit Sub
                End If
            Else
                
                '@再描画の場合は画面のﾛｯﾄﾘｽﾄを渡して再検索実行する
                Dim lstrLotListTmp As String
                For llngCnt = 1 To vsfLotList.Rows.Count - 1
                    lstrLotListTmp = vsfLotList.GetData(llngCnt, CMlngvsfLotListLot) 'ﾛｯﾄIDを格納
                    lstrLotList.Add(lstrLotListTmp)
                Next llngCnt
                
            End If
            
            '@ﾛｯﾄが空の場合はﾒｯｾｰｼﾞを表示
            If lstrLotList.Count = 0 Then
                
                '@新規検索の場合は表示中のﾃﾞｰﾀをｸﾘｱする
                If blnDataAddFlag = False Then
                    vsfLotList.Redraw = False
                    vsfLotList.Rows.Count = 1
                    vsfLotList.Redraw = True

                    '@変数を初期化(一部初期化)
                    Call prvMemInit(False)
                    
                    '@ﾒｯｾｰｼﾞ表示(<TRM7BI>$$検索条件のロットは存在しません。$条件を見直してください。)
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007B)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                End If
                
                lblNowDate.Text = Format$(Now, CPstrDateFormat)                            '情報取得日時表示
                lblLotCnt.Text = Format$(vsfLotList.Rows.Count - 1, CPstrDateFormatKanma)  '該当件数
                Exit Sub
            
            End If
            
            
            '@ﾚｽﾎﾟﾝ開始
            lstrFormName = Me.Name
            lstrEventName = "cmdSerch_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            
            '@区間優先設定情報取得
            lblnAns = pubblnLotSectionPriority_Sel(pstrSBID, _
                                                   CMstrlot_secPriorityVer, _
                                                   lstrLotList, _
                                                   ltypSecPriority)
            '@結果判定
            If lblnAns = True Then
            
                '@成功の場合
                
                '@現在の行数を退避
                llngBeforCnt = vsfLotList.Rows.Count
                lintBeforRow = vsfLotList.Row

                vsfLotList.Redraw = False
                
                '@取得結果をｸﾞﾘｯﾄﾞに表示
                With ltypSecPriority
                
                    '@追加表示ﾌﾗｸﾞはFalseか
                    If blnDataAddFlag = False Then
                    
                        '@新規表示の場合
                        vsfLotList.Rows.Count = 1
                        lngDispStartRow = 0
                    
                    Else
                    
                        '@追加表示の場合
                        lngDispStartRow = vsfLotList.Rows.Count - 1
                        
                    End If
                    
                    '@変数のﾃﾞｰﾀ数文ﾙｰﾌﾟする
                    llngCnt3 = 1
                    For llngCnt = 0 To .lngListCnt - 1
                        
                        '@既に同じﾛｯﾄが表示されて居ないか（追加検索の場合、同じﾃﾞｰﾀがある場合は表示しない)
                        lstrCurLotId = .SecPriorityList(llngCnt).strLotID
                        lblnFindFlag = False    'ﾌﾗｸﾞ初期化
                        
                        '@同じﾛｯﾄIDの行があるかﾁｪｯｸ
                        For llngCnt2 = 1 To vsfLotList.Rows.Count - 1
                            '@現在行のﾛｯﾄとｶﾚﾝﾄﾛｯﾄは同じか
                            If vsfLotList.GetData(llngCnt2, CMlngvsfLotListLot) = lstrCurLotId Then
                            
                                '@ﾌﾗｸﾞを設定
                                lblnFindFlag = True
                                Exit For
                            End If
                        Next llngCnt2
                        
                        '@表示済みﾌﾗｸﾞはFalseか
                        If lblnFindFlag = False Then
                            
                            '@ﾃﾞｰﾀは表示
                            vsfLotList.Rows.Count = vsfLotList.Rows.Count + 1
                            vsfLotList.SetData(llngCnt3 + lngDispStartRow, CMlngvsfLotListNo, llngCnt3 + lngDispStartRow)                                           'No
                            vsfLotList.SetCellCheck(llngCnt3 + lngDispStartRow, CMlngvsfLotListEdit, CheckEnum.Unchecked)                            '変更
                            vsfLotList.SetData(llngCnt3 + lngDispStartRow, CMlngvsfLotListLot, .SecPriorityList(llngCnt).strLotID)                   'ﾛｯﾄID
        '@↓2016/01/16 (Sat) 15:06:57 H.Hayashi **************************************************
                            vsfLotList.SetData(llngCnt3 + lngDispStartRow, CMlngvsfLotListGrbClass, .SecPriorityList(llngCnt).strGrbClass)           'GRB区分
        '@↑2016/01/16 (Sat) 15:06:57 H.Hayashi **************************************************
                            vsfLotList.SetData(llngCnt3 + lngDispStartRow, CMlngvsfLotListSOp_Id, .SecPriorityList(llngCnt).strStartOpId)            '開始大工程
                            vsfLotList.SetData(llngCnt3 + lngDispStartRow, CMlngvsfLotListSStep_Id, .SecPriorityList(llngCnt).strStartStepId)        '開始小工程
                            vsfLotList.SetData(llngCnt3 + lngDispStartRow, CMlngvsfLotListEOp_Id, .SecPriorityList(llngCnt).strEndOpId)              '終了大工程
                            vsfLotList.SetData(llngCnt3 + lngDispStartRow, CMlngvsfLotListEStep_Id, .SecPriorityList(llngCnt).strEndStepId)          '終了小工程
                            vsfLotList.SetData(llngCnt3 + lngDispStartRow, CMlngvsfLotListSecPriority, .SecPriorityList(llngCnt).strSectionPriority) '区間優先度
                            vsfLotList.SetData(llngCnt3 + lngDispStartRow, CMlngvsfLotListPriority, .SecPriorityList(llngCnt).strPriority)           '優先度
                            vsfLotList.SetData(llngCnt3 + lngDispStartRow, CMlngvsfLotListUser, .SecPriorityList(llngCnt).strEmpName)                '設定者
                            vsfLotList.SetData(llngCnt3 + lngDispStartRow, CMlngvsfLotListDate, .SecPriorityList(llngCnt).strEntryTime)              '設定日時
                            
                            '@保留/停止の場合は黄色表示
                            If .SecPriorityList(llngCnt).strLotHoldFlag = "1" Or .SecPriorityList(llngCnt).strLotStopFlag = "1" Then
                                newStyle = vsfLotList.Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                                cellRange = vsfLotList.GetCellRange(llngCnt3 + lngDispStartRow, CMlngvsfLotListNo, _
                                                                    llngCnt3 + lngDispStartRow, CMlngvsfLotListDate)
                                cellRange.Style = newStyle
                            End If

                            'NSYS 対象列のフォントサイズを設定
                            If .SecPriorityList(llngCnt).strLotHoldFlag = "1" Or .SecPriorityList(llngCnt).strLotStopFlag = "1" Then
                                newStyle2 = vsfLotList.Styles.Add("CustomStyle_Font_BackColor_CMlngvsfLotListEdit")
                                newStyle2.Font = New Font(CMstrGridFontName, 9, vsfLotList.Font.Style, vsfLotList.Font.Unit)
                                newStyle2.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                                cellRange2 = vsfLotList.GetCellRange(llngCnt3 + lngDispStartRow, CMlngvsfLotListEdit, _
                                                                    llngCnt3 + lngDispStartRow, CMlngvsfLotListEdit)
                                cellRange2.Style = newStyle2
                            Else
                                newStyle2 = vsfLotList.Styles.Add("CustomStyle_Font_CMlngvsfLotListEdit")
                                newStyle2.Font = New Font(CMstrGridFontName, 9, vsfLotList.Font.Style, vsfLotList.Font.Unit)
                                cellRange2 = vsfLotList.GetCellRange(llngCnt3 + lngDispStartRow, CMlngvsfLotListEdit, _
                                                                    llngCnt3 + lngDispStartRow, CMlngvsfLotListEdit)
                                cellRange2.Style = newStyle2
                            End If
                            
                            llngCnt3 = llngCnt3 + 1
                        End If
                        
                    Next llngCnt
                
                    '@追加表示ﾌﾗｸﾞはFalseか
                    If blnDataAddFlag = True Then
                        '@№の順番が崩れるので表示
                        Call prvGuridNoReDrow()
                    End If
                    
                End With
                
                'NSYS グリッドの先頭行を表示
                If blnDataAddFlag = True Then
                    vsfLotList.Row = lintBeforRow
                    vsfLotList.ScrollPosition = New Point(ScrollPosition.X, ScrollPosition.Y)
                Else
                    vsfLotList.Row = 0
                    vsfLotList.ScrollPosition = New Point(ScrollPosition.X, 0)
                End If
                
                vsfLotList.Redraw = True
                
                '@ｸﾞﾘｯﾄﾞを有効にする
                vsfLotList.Enabled = True
                
                '@編集中ﾌﾗｸﾞﾘｾｯﾄ
                mblnEditFlag = False
                
                '@追加検索か
                If blnDataAddFlag = True Then
                
                    '@追加前と追加後を比較して変化が無い場合ﾒｯｾｰｼﾞを表示
                    If llngBeforCnt = vsfLotList.Rows.Count Then
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        '@各種ﾗﾍﾞﾙの表示
                        lblNowDate.Text = Format$(Now, CPstrDateFormat)                            '情報取得日時表示
                        lblLotCnt.Text = Format$(vsfLotList.Rows.Count - 1, CPstrDateFormatKanma)  '該当件数
                        
                        '@ﾒｯｾｰｼﾞ表示(<TRM7CI>$$追加で表示するロットは存在しません。$既に表示済みか、該当ロットは存在しません。)
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007C)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Exit Sub
                    End If
                    
                End If
                
            Else
            
                '@異常の場合終了
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
                
            End If
            
            
            '@変更前の値として構造体に値を退避しておく
            With mtypGridDrowSecPriority
                
                '@件数は0以外か
                If vsfLotList.Rows.Count > 1 Then
            
                    .lngListCnt = vsfLotList.Rows.Count - 1                   'ﾚｺｰﾄﾞ数

                    If IsNothing(.typChgSecPriority) Then
                        .typChgSecPriority = New List(Of typChgSecPriList)
                    Else
                        .typChgSecPriority.Clear
                    End If
                    
                    Dim typChgSecPriorityTmp As typChgSecPriList = New typChgSecPriList
                    
                    '@ﾃﾞｰﾀを格納
                    For llngCnt = 1 To vsfLotList.Rows.Count - 1
                        
                        typChgSecPriorityTmp.strLotID = vsfLotList.GetData(llngCnt, CMlngvsfLotListLot)             'ロットID
                        typChgSecPriorityTmp.strStartOpId = vsfLotList.GetData(llngCnt, CMlngvsfLotListSOp_Id)      '開始大工程
                        typChgSecPriorityTmp.strStartStepId = vsfLotList.GetData(llngCnt, CMlngvsfLotListSStep_Id)  '開始小工程
                        typChgSecPriorityTmp.strEndOpId = vsfLotList.GetData(llngCnt, CMlngvsfLotListEOp_Id)        '終了大工程
                        typChgSecPriorityTmp.strEndStepId = vsfLotList.GetData(llngCnt, CMlngvsfLotListEStep_Id)    '終了小工程
                        typChgSecPriorityTmp.strSectionPriority = vsfLotList.GetData(llngCnt, CMlngvsfLotListSecPriority)   '区間優先
                        typChgSecPriorityTmp.strPriority = vsfLotList.GetData(llngCnt, CMlngvsfLotListPriority)     '優先度

                        .typChgSecPriority.Add(typChgSecPriorityTmp)
                    Next llngCnt

                End If
                
            End With
            
            '@各種ﾗﾍﾞﾙの表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)                            '情報取得日時表示
            lblLotCnt.Text = Format$(vsfLotList.Rows.Count - 1, CPstrDateFormatKanma)  '該当件数
            
            '@ﾚｽﾎﾟﾝｽ終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
                
            '@結果からだった場合はﾒｯｾｰｼﾞを表示する
            If vsfLotList.Rows.Count = 1 Then
            
                '@表示を初期化
                vsfLotList.Redraw = False
                vsfLotList.Rows.Count = 1
                vsfLotList.Redraw = True
                
                '@変数を初期化(一部初期化)
                Call prvMemInit(False)
                
                '@ﾒｯｾｰｼﾞ表示(<TRM7BI>$$検索条件のロットは存在しません。$条件を見直してください。)
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007B)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListShow"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvLotListReq_Proc
    '機　能：工程別ﾛｯﾄ一覧取得要求ﾃﾞｰﾀ作成処理
    '引　数：lstrClassDivision  ：処理区分
    '　　　：ltypLotListReq     ：要求構造体
    '戻り値：なし
    '作成日：2011/09/27 (Tue) 17:43:22 T.Oide
    '更新日：2011/09/27 (Tue) 17:43:22
    '備　考：
    Private Sub prvLotListReq_Proc(ByVal lstrClassDivision As String, _
                                   ByRef ltypLotListReq As OpLotList)

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ
        Dim lstrTemp        As Object       '一時取得用変数

        Try

            '@各種構造体ﾒﾝﾊﾞの配列の初期化
            If IsNothing(ltypLotListReq.typFlowClassList) Then
                ltypLotListReq.typFlowClassList = New List(Of FlowClassList)    '流動区分ﾘｽﾄ
            Else
                ltypLotListReq.typFlowClassList.Clear
            End If
            If IsNothing(ltypLotListReq.typPdList) Then
                ltypLotListReq.typPdList = New List(Of PDList)                  '機種ﾘｽﾄ
            Else
                ltypLotListReq.typPdList.Clear
            End If

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotListReq

                .strSbID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrlot_oplotlistVer                      'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strClassDivision = lstrClassDivision                   '処理区分
                .strOpID = cmbOpID.Text                                 '大工程
                .strStepID = cmbStepID.Text                             '小工程

                .lngPdCnt = cmbProduct.ValueCount                            '機種ｶｳﾝﾄ数

                '@機種ｺﾝﾎﾞﾃﾞｰﾀ件数が1件以上か
                If cmbProduct.ValueCount > 0 Then
                    Dim typPdListTmp As PDList = New PDList
                    lstrTemp = Split(cmbProduct.Value, vbTab)

                    For llngCnt = LBound(lstrTemp) To UBound(lstrTemp)

                        typPdListTmp.strPdId _
                            = lstrTemp(llngCnt)                         '機種

                        .typPdList.Add(typPdListTmp)
                    Next llngCnt
                End If

                .lngFlowClassCnt = mlngDivisionListCnt                  '流動区分ｶｳﾝﾄ数

                '@流動区分を全件設定
                Dim typFlowClassListTmp As FlowClassList
                For llngCnt = 0 To mlngDivisionListCnt - 1
                    typFlowClassListTmp.strFlowClass = mtypDivisionList(llngCnt).strDivisionID

                    .typFlowClassList.Add(typFlowClassListTmp)
                Next llngCnt

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLotListReq_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvGetTraveler
    '機　能：ﾛｯﾄの流動票一覧を取得してｺﾝﾎﾞに設定する
    '引　数：なし
    '戻り値：
    '作成日：2011/09/28 (Wed) 16:01:13 T.Oide
    '更新日：2011/09/28 (Wed) 16:01:13
    '備　考：
    Private Sub prvGetTraveler()

        Dim lstrFormName    As String
        Dim lstrEventName   As String
        Dim lstrLotID       As List(Of String)
        Dim lstrMsgCode     As String
        Dim lstrMsg         As String
        Dim lblnAns         As String

        Try
            
            lstrFormName = Me.Name
            lstrEventName = "prvGetTraveler"
            
            With vsfLotList
            
                '@ﾁｪｯｸはONか
                If .GetCellCheck(.Row, CMlngvsfLotListEdit) <> CheckEnum.Unchecked Then
                    
                    '@既にﾃﾞｰﾀがある場合は再取得はしない
                    If mtypSecPriorityDetail.lngListCnt1 <> 0 Then
                        
                        '@取得済みﾃﾞｰﾀは該当ﾛｯﾄのものか
                        If mtypSecPriorityDetail.SecPriList(0).strLotID = .GetData(.Row, CMlngvsfLotListLot) Then
                            '@既に取得済みなので再取得しない
                            Exit Sub
                        End If
                
                    End If
                
                    '@ﾚｽﾎﾟﾝｽ開始
                    Call pubResponseStart(lstrFormName, lstrEventName)
                
                    '@工程ﾘｽﾄを取得するために区間優先情報詳細を取得
                    If IsNothing(lstrLotID) Then
                        lstrLotID = New List(Of String)
                    Else
                        lstrLotID.Clear
                    End If

                    lstrLotID.Add(.GetData(.Row, CMlngvsfLotListLot))

                    lblnAns = pubblnLotSecPriorityDetail_Sel(pstrSBID, _
                                                             CMstrlot_secPriorityDetailVer, _
                                                             lstrLotID, _
                                                             mtypSecPriorityDetail, _
                                                             lstrMsgCode, _
                                                             lstrMsg)
                    
                    If lblnAns = False Then
                        '@異常の場合終了
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        '@ｴﾗｰﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(lstrMsgCode & vbCrLf & vbCrLf & lstrMsg)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                        Exit Sub
                        
                    End If
                    
                    '@ﾚｽﾎﾟﾝｽ完了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                
                End If

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGetTraveler"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvSetStartOpIdList
    '機　能：大工程のﾘｽﾄをｺﾝﾎﾞに設定する
    '引　数：なし
    '戻り値：
    '作成日：2011/09/29 (Thu) 18:52:16 T.Oide
    '更新日：2011/09/29 (Thu) 18:52:16
    '備　考：
    Private Sub prvSetStartOpIdList()

        Dim lstrTmpOpID             As String
        Dim llngCnt                 As Integer
        Dim lstrAddString           As String

        Try
            
            '@何らかの原因でﾃﾞｰﾀ取得に失敗している場合は処理を中止する
            If mtypSecPriorityDetail.lngListCnt1 = 0 Then
                Exit Sub
            End If
            
            With mtypSecPriorityDetail.SecPriList(0)
                        
                lstrTmpOpID = vbNullString
            
                '@現在工程以降の大工程ﾘｽﾄをｺﾝﾎﾞﾘｽﾄに設定(A | B | C…)
                For llngCnt = 0 To .lngListCnt2 - 1
                
                    '@流動済みﾌﾗｸﾞは0か？
                    If .SecPriDetailList(llngCnt).strExecedFlag = 0 Then
                                                
                        '@大工程は違うか
                        If lstrTmpOpID <> .SecPriDetailList(llngCnt).strOpID Then
                            
                            '@ﾘｽﾄ追加
                            lstrAddString = lstrAddString & CPstrPipeString & .SecPriDetailList(llngCnt).strOpID
                            
                            '@大工程を格納
                            lstrTmpOpID = .SecPriDetailList(llngCnt).strOpID
                        End If
                        
                    End If
                
                Next llngCnt
                
                '@大工程ｺﾝﾎﾞﾘｽﾄ設定
                vsfLotList.Cols(CMlngvsfLotListSOp_Id).ComboList = lstrAddString
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSetStartOpIdList"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvSetStertStepIdList
    '機　能：開始小工程のﾘｽﾄをｺﾝﾎﾞにｾｯﾄ
    '引　数：なし
    '戻り値：
    '作成日：2011/09/28 (Wed) 16:17:44 T.Oide
    '更新日：2011/09/28 (Wed) 16:17:44
    '備　考：
    Private Sub prvSetStertStepIdList()

        Dim lstrSechOpID            As String
        Dim llngCnt                 As Integer
        Dim lstrAddString           As String

        Try
            
            '@何らかの原因でﾃﾞｰﾀ取得に失敗している場合は処理を中止する
            If mtypSecPriorityDetail.lngListCnt1 = 0 Then
                Exit Sub
            End If
            
            '@開始大工程に対応した開始小工程のｺﾝﾎﾞﾘｽﾄを設定する
            With mtypSecPriorityDetail.SecPriList(0)
            
                '@大工程を変数に設定
                lstrSechOpID = vsfLotList.GetData(vsfLotList.Row, CMlngvsfLotListSOp_Id)
                
                '@変数から大工程を探すためにループ
                For llngCnt = 0 To .lngListCnt2 - 1
                
                    '@大工程は同じか
                    If .SecPriDetailList(llngCnt).strOpID = lstrSechOpID Then
                        
                        '@ﾘｽﾄ追加(A | B | C…)
                        lstrAddString = lstrAddString & CPstrPipeString & .SecPriDetailList(llngCnt).strStepID
                        
                    End If
                
                Next llngCnt
                
            End With
            
            '@大工程ｺﾝﾎﾞﾘｽﾄ設定
            vsfLotList.Cols(CMlngvsfLotListSStep_Id).ComboList = lstrAddString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSetStertStepIdList"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvSetEndOpIdList
    '機　能：終了大工程のﾘｽﾄをｺﾝﾎﾞにｾｯﾄ
    '引　数：なし
    '戻り値：
    '作成日：2011/09/28 (Wed) 16:18:44 T.Oide
    '更新日：2011/09/28 (Wed) 16:18:44
    '備　考：
    Private Sub prvSetEndOpIdList()

        Dim lstrSechOpID            As String
        Dim lstrTmpOpID             As String
        Dim lblnFindFlag            As Boolean
        Dim llngCnt                 As Integer
        Dim lstrAddString           As String
        
        Try

            '@何らかの原因でﾃﾞｰﾀ取得に失敗している場合は処理を中止する
            If mtypSecPriorityDetail.lngListCnt1 = 0 Then
                Exit Sub
            End If
            
            '@開始大工程以降の大工程をｺﾝﾎﾞﾘｽﾄに設定する
            With mtypSecPriorityDetail.SecPriList(0)
            
                '@大工程を変数に設定
                lstrSechOpID = vsfLotList.GetData(vsfLotList.Row, CMlngvsfLotListSOp_Id)
                lstrTmpOpID = vbNullString
                
                '@変数から大工程を探すためにループ
                lblnFindFlag = False
                For llngCnt = 0 To .lngListCnt2 - 1
                
                    '@大工程は同じか
                    If .SecPriDetailList(llngCnt).strOpID = lstrSechOpID Then
                        
                        lblnFindFlag = True
                    
                    End If
                    
                    '@同じ大工程が見つかって、前回と違う大工程ならﾘｽﾄに追加
                    If lblnFindFlag = True And lstrTmpOpID <> .SecPriDetailList(llngCnt).strOpID Then
                        
                        '@ﾘｽﾄ追加(A | B | C…)
                        lstrAddString = lstrAddString & CPstrPipeString & .SecPriDetailList(llngCnt).strOpID
                        lstrTmpOpID = .SecPriDetailList(llngCnt).strOpID
                        
                    End If
                    
                Next llngCnt
                
            End With
            
            '@大工程ｺﾝﾎﾞﾘｽﾄ設定
            vsfLotList.Cols(CMlngvsfLotListEOp_Id).ComboList = lstrAddString
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSetEndOpIdList"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：prvSetEndStepList
    '機　能：終了小工程のﾘｽﾄをｺﾝﾎﾞにｾｯﾄ
    '引　数：なし
    '戻り値：
    '作成日：2011/09/28 (Wed) 16:19:36 T.Oide
    '更新日：2011/09/28 (Wed) 16:19:36
    '備　考：
    Private Sub prvSetEndStepList()

        Dim lblnFindFlag                As Boolean
        Dim lstrSechOpID                As String
        Dim llngCnt                     As Integer
        Dim lstrAddString               As String
        
        Try

            '@何らかの原因でﾃﾞｰﾀ取得に失敗している場合は処理を中止する
            If mtypSecPriorityDetail.lngListCnt1 = 0 Then
                Exit Sub
            End If
            
            '@終了大工程に対応した終了小工程をｺﾝﾎﾞﾘｽﾄに設定する
            With mtypSecPriorityDetail.SecPriList(0)

                '@変数初期化
                lblnFindFlag = False
                
                '@開始大工程と終了大工程は同じか
                If vsfLotList.GetData(vsfLotList.Row, CMlngvsfLotListSOp_Id) = _
                   vsfLotList.GetData(vsfLotList.Row, CMlngvsfLotListEOp_Id) Then
                    
                    '--------------------------------------------------------
                    ' @設定された開始大工程と終了大工程が同じ場合
                    ' @大工程に紐付く「開始小工程」以降の小工程をﾘｽﾄに入れる
                    '--------------------------------------------------------
                    
                    '@構造体から探す大工程を変数に格納
                    lstrSechOpID = vsfLotList.GetData(vsfLotList.Row, CMlngvsfLotListSOp_Id)
                
                    '@変数から大工程を探すためにループ
                    For llngCnt = 0 To .lngListCnt2 - 1
                    
                        '@大工程は同じか
                        If .SecPriDetailList(llngCnt).strOpID = lstrSechOpID Then
                            
                            '@小工程は同じか
                            If vsfLotList.GetData(vsfLotList.Row, CMlngvsfLotListSStep_Id) = _
                                .SecPriDetailList(llngCnt).strStepID Then
                            
                                lblnFindFlag = True
                            End If
                            
                            If lblnFindFlag = True Then
                                '@ﾘｽﾄ追加(A | B | C…)
                                lstrAddString = lstrAddString & CPstrPipeString & .SecPriDetailList(llngCnt).strStepID
                            End If
                            
                        End If
                    
                        '@大工程が違っていて、FindFlag = Trueか
                        If .SecPriDetailList(llngCnt).strOpID <> lstrSechOpID And _
                           lblnFindFlag = True Then
                            
                            Exit For
                        End If
                    
                    Next llngCnt
                    
                Else
                    
                    '--------------------------------------------------------
                    ' @設定された開始大工程と終了大工程が違う場合
                    ' @大工程に紐付く小工程をﾘｽﾄに入れる
                    '--------------------------------------------------------
                    
                    '@構造体から探す大工程を変数に格納
                    lstrSechOpID = vsfLotList.GetData(vsfLotList.Row, CMlngvsfLotListEOp_Id)
                    
                    '@変数から大工程を探すためにループ
                    For llngCnt = 0 To .lngListCnt2 - 1
                    
                        '@大工程は同じか
                        If .SecPriDetailList(llngCnt).strOpID = lstrSechOpID Then
                            
                            lblnFindFlag = True
                            
                            '@ﾘｽﾄ追加(A | B | C…)
                            lstrAddString = lstrAddString & CPstrPipeString & .SecPriDetailList(llngCnt).strStepID
                            
                        End If
                    
                        '@大工程が違っていて、FindFlag = Trueか
                        If .SecPriDetailList(llngCnt).strOpID <> lstrSechOpID And _
                           lblnFindFlag = True Then
                            
                            Exit For
                        End If
                    
                    Next llngCnt
                
                End If
                
            End With
            
            '@大工程ｺﾝﾎﾞﾘｽﾄ設定
            vsfLotList.Cols(CMlngvsfLotListEStep_Id).ComboList = lstrAddString

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSetEndStepList"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvSecPriorityList
    '機　能：区間優先のｺﾝﾎﾞﾘｽﾄを作成する
    '引　数：なし
    '戻り値：
    '作成日：2011/10/06 (Thu) 15:04:41 T.Oide
    '更新日：2011/10/06 (Thu) 15:04:41
    '備　考：
    Private Sub prvSecPriorityList()

        Dim lstrAddString               As String
        
        Try

            With vsfLotList
            
                lstrAddString = CPstrPipeString & CMlngOne & _
                                CPstrPipeString & CMlngTwo & _
                                CPstrPipeString & CMlngThree & _
                                CPstrPipeString & CMlngFour & _
                                CPstrPipeString & CMlngFive
                        
                        
                '@既存設定がある場合は"削除も追加する"
                If .GetData(.Row, CMlngvsfLotListUser) <> vbNullString Then
                    lstrAddString = lstrAddString & CPstrPipeString & CMstrDelete
                End If
                
                '@優先度ｺﾝﾎﾞﾘｽﾄ設定
                .Cols(CMlngvsfLotListSecPriority).ComboList = lstrAddString
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSecPriorityList"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '関数名：prvButtonControl
    '機　能：ﾎﾞﾀﾝの有効/無効をｺﾝﾄﾛｰﾙ
    '引　数：なし
    '戻り値：
    '作成日：2011/09/26 (Mon) 16:25:18 T.Oide
    '更新日：2011/09/26 (Mon) 16:25:18
    '備　考：
    Private Sub prvButtonControl()

        Dim llngCnt         As Integer
        Dim lblnFindFlag    As Boolean

        Try
            
            '@============================
            '@ 検索ﾎﾞﾀﾝ、追加検索ﾎﾞﾀﾝ
            '@============================

            '検索条件が何も無い場合無効
            '各ｵﾌﾟｼｮﾝ毎にﾁｪｯｸを実施
            Select Case True
                
                '@ﾛｯﾄで検索
                Case optSerch0.Checked = True
                    
                    '@ﾛｯﾄIDは空か
                    If txtLotID.Text = vbNullString Then
                        cmdSerch.Enabled = False
                        cmdSerchAdd.Enabled = False
                    Else
                        cmdSerch.Enabled = True
                        
                        '@追加検索ﾎﾞﾀﾝ制御
                        Call prvSerchAddEnable()
                    End If
                    
                '@装置で検索
                Case optSerch1.Checked = True
                
                    '@装置の設定は空か
                    If cmbWpID.Text = vbNullString Then
                        cmdSerch.Enabled = False
                        cmdSerchAdd.Enabled = False
                    Else
                        cmdSerch.Enabled = True
                        
                        '@追加検索ﾎﾞﾀﾝ制御
                        Call prvSerchAddEnable()
                    End If
                    
                '@特定工程で検索
                Case optSerch2.Checked = True
                    
                    '@大工程は空かまたは機種の選択が0件か
                    If cmbOpID.Text = vbNullString Or cmbProduct.Text = CMlngZero & CMstrAddedComment Then
                        cmdSerch.Enabled = False
                        cmdSerchAdd.Enabled = False
                    Else
                        cmdSerch.Enabled = True
                                    
                        '@追加検索ﾎﾞﾀﾝ制御
                        Call prvSerchAddEnable()
                    End If
                    
                '@設定あり全てで検索
                Case optSerch4.Checked = True
                
                    '@検索ﾎﾞﾀﾝ有効化
                    cmdSerch.Enabled = True
                    
                    '@追加検索ﾎﾞﾀﾝ制御
                    Call prvSerchAddEnable()

                    
            End Select

            '@============================
            '@ 全てON、ﾁｪｯｸOFF非表示、ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ ﾎﾞﾀﾝ
            '@============================
            
            '検索結果が現在0行の場合は無効
            If vsfLotList.Rows.Count = CMlngOne Then
                cmdAllOn.Enabled = False
                cmdHidden.Enabled = False
                cmdClipCopy.Enabled = False
            Else
                cmdAllOn.Enabled = True
                cmdHidden.Enabled = True
                cmdClipCopy.Enabled = True
            End If
            
            '@============================
            '@ 上の設定ｺﾋﾟｰﾎﾞﾀﾝ
            '@============================

            '上の行がﾀｲﾄﾙまたは設定なしの場合無効
            With vsfLotList
                
                '@1つ上の行がﾀｲﾄﾙ行以外ではなく、設定が全てNULL以外か
                If .Row > CMlngOne Then
                    If .GetData(.Row - 1, CMlngvsfLotListSOp_Id) = vbNullString Or _
                       .GetData(.Row - 1, CMlngvsfLotListSStep_Id) = vbNullString Or _
                       .GetData(.Row - 1, CMlngvsfLotListEOp_Id) = vbNullString Or _
                       .GetData(.Row - 1, CMlngvsfLotListEStep_Id) = vbNullString Or _
                       .GetData(.Row - 1, CMlngvsfLotListSecPriority) = vbNullString Then
                    
                        cmdCopy.Enabled = False
                    Else
                        cmdCopy.Enabled = True
                    End If
                Else
                    cmdCopy.Enabled = False
                End If
            
            End With
            
            '@============================
            '@ 詳細表示ﾎﾞﾀﾝ、確定ﾎﾞﾀﾝ
            '@============================

            'ﾁｪｯｸONの行が無ければ無効
            lblnFindFlag = False
            For llngCnt = 1 To vsfLotList.Rows.Count - 1
            
                '@ﾁｪｯｸはONか
                If vsfLotList.GetCellCheck(llngCnt, CMlngvsfLotListEdit) <> CheckEnum.Unchecked Then
                    '@ﾌﾗｸﾞをｾｯﾄする
                    lblnFindFlag = True
                End If
                
            Next llngCnt
            
            '@ﾌﾗｸﾞはTrueか
            If lblnFindFlag = True Then
                cmdDetail.Enabled = True
                cmdRegist.Enabled = True
            Else
                cmdDetail.Enabled = False
                cmdRegist.Enabled = False
            End If
            
            '@編集中ﾌﾗｸﾞはFalseか
            If mblnEditFlag = False Then
                cmdRegist.Enabled = False
            End If
            
            
            '@============================
            '@ 閉じるﾎﾞﾀﾝ、全部取消ﾎﾞﾀﾝ
            '@============================
            
            '常に有効
            cmdClose.Enabled = True
            cmdClear.Enabled = True
            
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvButtonControl"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvSerchAddEnable
    '機　能：追加検索ボタンの有効/無効制御
    '引　数：なし
    '戻り値：
    '作成日：2011/10/11 (Tue) 13:53:13 T.Oide
    '更新日：2011/10/11 (Tue) 13:53:13
    '備　考：
    Private Sub prvSerchAddEnable()

        Try
            
            '@ｸﾞﾘｯﾄﾞは0行か
            If vsfLotList.Rows.Count = CMlngOne Then
                cmdSerchAdd.Enabled = False
            Else
                cmdSerchAdd.Enabled = True
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSerchAddEnable"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMemInit
    '機　能：変数を初期化する
    '引　数：blnAllInitFlag:True：全て初期化、False：一部初期化
    '戻り値：
    '作成日：2011/09/29 (Thu) 20:11:51 T.Oide
    '更新日：2011/09/29 (Thu) 20:11:51
    '備　考：
    Private Sub prvMemInit(ByVal blnAllInitFlag As Boolean)

        Dim ltypSecPriorityDetail       As typSecPriorityDetail
        Dim ltypProductList             As List(Of ProductList)
        Dim ltypDivisionList            As List(Of DivisionList)
        Dim ltypGridDrowSecPriority     As typChgSecPriority

        Try

            '@変数を初期化する
            mblnEventCancelFlag = False                         'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ
            mstrBeforEditValue = vbNullString                   'ｸﾞﾘｯﾄﾞ変更前の値
            mblnEditFlag = False                                '編集中ﾌﾗｸﾞ
            mstrOpID = vbNullString                             '大工程
            mstrStepID = vbNullString                           '小工程
            mblnCheckOnFlag = False                             'ﾁｪｯｸONﾌﾗｸﾞ
            mtypSecPriorityDetail = ltypSecPriorityDetail       '区間優先詳細情報格納
            mtypGridDrowSecPriority = ltypGridDrowSecPriority   '検索時のｸﾞﾘｯﾄﾞ描画情報


            '@全削除ﾌﾗｸﾞはTrueか
            If blnAllInitFlag = True Then

                mtypProductList = ltypProductList               '機種ﾘｽﾄ格納
                mPdCount = 0                                    '機種数
                mtypDivisionList = ltypDivisionList             '種別格納変数
                mlngDivisionListCnt = 0                         '機種数

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMemInit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvGuridNoReDrow
    '機　能：ｸﾞﾘｯﾄﾞのNoを振りなおす
    '引　数：なし
    '戻り値：
    '作成日：2011/09/30 (Fri) 14:37:40 T.Oide
    '更新日：2011/09/30 (Fri) 14:37:40
    '備　考：
    Private Sub prvGuridNoReDrow()

        Dim llngCnt     As Integer

        Try
            
            With vsfLotList
                
                '@ｸﾞﾘｯﾄﾞの行数繰り返し
                For llngCnt = 1 To .Rows.Count - 1
                    '@Noを1～振りなおす
                    .SetData(llngCnt, CMlngvsfLotListNo, llngCnt)
                Next llngCnt
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGuridNoReDrow"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvGridDispRollBack
    '機　能：設定を途中で止めた場合設定値を元の状態に戻す(構造体：mtypGridDrowSecPriorityに格納してある)
    '引　数：lstrLotId：戻す対象のﾛｯﾄID
    '戻り値：
    '作成日：2011/09/30 (Fri) 16:04:52 T.Oide
    '更新日：2011/09/30 (Fri) 16:04:52
    '備　考：
    Private Sub prvGridDispRollBack(ByVal lstrLotID As String, ByVal lngRowNo As Integer)

        Dim llngCnt         As Integer

        Try
            
            '@構造体から該当ﾛｯﾄのﾃﾞｰﾀを探す
            For llngCnt = 0 To mtypGridDrowSecPriority.lngListCnt - 1
                
                With mtypGridDrowSecPriority.typChgSecPriority(llngCnt)
                
                    '@ﾛｯﾄIDは同じか
                    If .strLotID = lstrLotID Then
                            
                        '@値を戻す
                        vsfLotList.SetData(lngRowNo, CMlngvsfLotListSOp_Id, .strStartOpId)              '開始大工程
                        vsfLotList.SetData(lngRowNo, CMlngvsfLotListSStep_Id, .strStartStepId)          '開始小工程
                        vsfLotList.SetData(lngRowNo, CMlngvsfLotListEOp_Id, .strEndOpId)                '終了大工程
                        vsfLotList.SetData(lngRowNo, CMlngvsfLotListEStep_Id, .strEndStepId)            '終了小工程
                        vsfLotList.SetData(lngRowNo, CMlngvsfLotListSecPriority, .strSectionPriority)   '区間優先
                        
                        '@色も黒に戻す(灰色になっている可能性ありなので)
                        Call prvGridForeColorSet(lngRowNo, CMlngOkForeColor)
                        
                        Exit For
                    End If
                
                End With
                
            Next llngCnt
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGridDispRollBack"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvGuridCheckOnOff
    '機　能：対象のﾁｪｯｸをON/OFFする
    '引　数：なし
    '戻り値：
    '作成日：2011/10/03 (Mon) 11:16:06 T.Oide
    '更新日：2011/10/03 (Mon) 11:16:06
    '備　考：
    Private Sub prvGuridCheckOnOff()

        Dim lstrLotID       As String

        Try
                
            With vsfLotList
                        
                '@ﾁｪｯｸはOFFか
                If .GetCellCheck(.Row, CMlngvsfLotListEdit) = CheckEnum.Unchecked Then
                    '@ﾁｪｯｸON
                    .SetCellCheck(.Row, CMlngvsfLotListEdit, CheckEnum.Checked)
                Else
                    '@ﾁｪｯｸOFF
                    .SetCellCheck(.Row, CMlngvsfLotListEdit, CheckEnum.Unchecked)
                    
                    '@変更前の設定値の戻す(検索時に構造体：mtypGridDrowSecPriorityに格納してある)
                    lstrLotID = .GetData(.Row, CMlngvsfLotListLot)
                    Call prvGridDispRollBack(lstrLotID, .Row)
                    
                End If
                
            End With

            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGuridCheckOnOff"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvGridForeColorSet
    '機　能：ｸﾞﾘｯﾄﾞの表示色を変更
    '引　数：lngRowNo：対象行
    '　　　：lngColor：変更色
    '戻り値：
    '作成日：2011/10/03 (Mon) 11:27:48 T.Oide
    '更新日：2011/10/03 (Mon) 11:27:48
    '備　考：
    Private Sub prvGridForeColorSet(ByVal lngRowNo As Integer, ByVal lngColor As Color)
        
        Try
                            
            '@色も黒に戻す(灰色になっている可能性ありなので)
            With vsfLotList

                'NSYS 開始大工程～終了小工程の前景色/背景色を設定
                Select Case lngColor

                    'NSYS 前景色が灰色の場合
                    Case ColorTranslator.FromWin32(CMlngNotInputColor)
                        
                        If Not IsNothing(.GetCellStyle(lngRowNo, CMlngvsfLotListNo)) Then
                            'NSYS 保留/停止の場合は背景色を黄色に設定
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngNotInputColor_CPlngHoldLotColor")
                            newStyle.ForeColor = lngColor
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            Dim cellRange As CellRange = .GetCellRange(lngRowNo, CMlngvsfLotListSOp_Id, lngRowNo, CMlngvsfLotListEStep_Id)
                            cellRange.Style = newStyle
                        Else
                            'NSYS 行の背景色が未設定の場合は背景色を設定しない
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngNotInputColor")
                            newStyle.ForeColor = lngColor
                            Dim cellRange As CellRange = .GetCellRange(lngRowNo, CMlngvsfLotListSOp_Id, lngRowNo, CMlngvsfLotListEStep_Id)
                            cellRange.Style = newStyle
                        End If

                    'NSYS 前景色が黒色の場合
                    Case CMlngOkForeColor
                        
                        If Not IsNothing(.GetCellStyle(lngRowNo, CMlngvsfLotListNo)) Then
                            'NSYS 保留/停止の場合は背景色を黄色に設定
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngOkForeColor_CPlngHoldLotColor")
                            newStyle.ForeColor = lngColor
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            Dim cellRange As CellRange = .GetCellRange(lngRowNo, CMlngvsfLotListSOp_Id, lngRowNo, CMlngvsfLotListEStep_Id)
                            cellRange.Style = newStyle
                        Else
                            'NSYS 行の背景色が未設定の場合は背景色を設定しない
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngOkForeColor")
                            newStyle.ForeColor = lngColor
                            Dim cellRange As CellRange = .GetCellRange(lngRowNo, CMlngvsfLotListSOp_Id, lngRowNo, CMlngvsfLotListEStep_Id)
                            cellRange.Style = newStyle
                        End If

                End Select
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGridForeColorSet"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraLot.Paint, frmSerch0.Paint

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


    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfLotList.KeyDownEdit

        With CType(sender, C1FlexGrid)
            '@'ｶﾚﾝﾄｾﾙがﾍｯﾀﾞｰ行でない場合
            If e.Row >= .Rows.Fixed Then
                Select Case e.KeyCode
                    Case Keys.Left  '[←]ｷｰ押下
                        Dim editor As Object = CType(.Editor, Object)
                        ' 編集不可のコンボボックスの場合
                        ' または、
                        ' テキストボックスまたは編集可のコンボボックスで、かつ、カーソルが先頭の場合は、
                        '   左隣へ
                        If (TypeOf editor Is ComboBox AndAlso _
                                    CType(editor, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList) _
                            OrElse _
                            ((TypeOf editor Is TextBox OrElse TypeOf editor Is ComboBox) AndAlso _
                                (editor.SelectionStart = 0 AndAlso editor.SelectionLength = 0)) Then
                            If .FinishEditing() = True Then
                                ' 左側で固定行直前まで移動可能なセルを探す
                                For lintCnt As Integer = .Col - 1 To .Cols.Fixed Step -1
                                    If .Cols(lintCnt).Visible Then
                                        .Col = lintCnt
                                        Exit For
                                    End If
                                Next lintCnt
                            End If
                            e.Handled = True
                        End If
                    Case Keys.Right '[→]ｷｰ押下
                        Dim editor As Object = CType(.Editor, Object)
                        ' 編集不可のコンボボックスの場合
                        ' または、
                        ' テキストボックスまたは編集可のコンボボックスで、かつ、カーソルが末尾の場合は、
                        '   右隣へ
                        If (TypeOf editor Is ComboBox AndAlso _
                                CType(editor, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList) _
                            OrElse _
                            ((TypeOf editor Is TextBox OrElse TypeOf editor Is ComboBox) AndAlso _
                                (editor.SelectionStart = editor.Text.Length)) Then
                            If .FinishEditing() = True Then
                                ' 右側でグリッドの最後まで移動可能なセルを探す
                                For lintCnt As Integer = .Col + 1 To .Cols.Count - 1 Step 1
                                    If .Cols(lintCnt).Visible Then
                                        .Col = lintCnt
                                        Exit For
                                    End If
                                Next lintCnt
                            End If
                            e.Handled = True
                        End If
                End Select
            End If
        End With

    End Sub

    '関数名：flex_SetupEditor
    '機　能：グリッド内コンボボックス表示行数調整
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/11/14 (Thu) 12:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotList.SetupEditor

        Try
            If TypeOf sender.Editor Is ComboBox
                '行の高さを変更
                Dim editor As ComboBox = CType(sender.Editor, ComboBox)
                editor.DrawMode = DrawMode.OwnerDrawFixed
                editor.DropDownHeight = 106
                editor.MaxDropDownItems = 12
                CType(sender, C1FlexGrid).Styles.Editor.Trimming = StringTrimming.None
            End If

        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try

    End Sub

    '関数名：vsfLotList_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2020/05/21 (Thu) 11:20:00 NSYS
    '更新日：
    '備　考：
    Private Sub vsfLotList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotList.BeforeSort
        
        Try
            'NSYS ソートでRowColChangeを発生しないようにする
            RemoveHandler vsfLotList.RowColChange, AddressOf vsfLotList_RowColChange

            'NSYS ソート前の選択行とスクロール位置を保持
            vsfLotListRowBeforeSort = vsfLotList.Row
            vsfLotListScrollPosition = vsfLotList.ScrollPosition

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfLotList_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2020/05/21 (Thu) 11:20:00 NSYS
    '更新日：
    '備　考：
    Private Sub vsfLotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotList.AfterSort
        
        Try
            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfLotList.RowColChange, AddressOf vsfLotList_RowColChange

            'ソート前と同じ行を選択する
            vsfLotList.Redraw = False
            vsfLotList.Row = vsfLotListRowBeforeSort
            vsfLotList.ScrollPosition = New Point(vsfLotList.ScrollPosition.X, vsfLotListScrollPosition.Y)
            vsfLotList.Redraw = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfLotList_ValidateEdit
    '機　能：設定値を空に変えられた場合の処理
    '引　数：
    '戻り値：
    '作成日：2020/05/21 (Thu) 09:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub vsfLotList_ValidateEdit(ByVal sender As Object, ByVal e As ValidateEditEventArgs) Handles vsfLotList.ValidateEdit

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
           
           'NSYS ﾘｽﾄ以外の入力の場合は空白に変更
           If vsfLotList.ComboBoxEditor.SelectedIndex = CMlngCmbClearListIndex Then
                vsfLotList.Editor.Text = vbNullString
           End If
            
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_KeyPressEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

End Class
