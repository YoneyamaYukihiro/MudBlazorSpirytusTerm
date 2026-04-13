'ﾌｧｲﾙ名：xxEN01U0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾌｫﾄF/Bﾃﾞｰﾀ変更
'作成日：2006/03/03 (Fri) 19:22:10 N.Kasai
'更新日：2023/12/25 (Mon) 16:09:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2023, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01U0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01U0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01U0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01U0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01U0)
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
    '@機能ﾊﾞｰｼﾞｮﾝ
    'Private Const CMstrLocalVersion                     As String = "04.02"
    Private Const CMstrLocalVersion                     As String = "04.03"

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_wplist__Ver                  As String = "05.01"             '装置一覧取得
    Private Const CMstrmas_RecipNameList_Ver            As String = "01.01"             'ﾚｼﾋﾟ名一覧取得
    'Private Const CMstreq__photofbdatachgVer            As String = "03.01"             'ﾌｫﾄF/Bﾃﾞｰﾀ変更(合せ)
	Private Const CMstreq__photofbdatalistVer           As String = "04.00"             'ﾌｫﾄF/Bﾃﾞｰﾀ取得(合せ)
    Private Const CMstreq__photofbdatachgVer            As String = "04.00"             'ﾌｫﾄF/Bﾃﾞｰﾀ変更(合せ)
    Private Const CMstreq__photofbdatalist2Ver          As String = "01.00"             'ﾌｫﾄF/Bﾃﾞｰﾀ取得(露光)
    Private Const CMstreq__photofbdatachg2Ver           As String = "02.00"             'ﾌｫﾄF/Bﾃﾞｰﾀ変更(露光)
	Private Const CMstreq__eqtypeRecplist				As String = "01.00"             '装置ﾀｲﾌﾟ別ﾚｼﾋﾟﾘｽﾄ
	Private Const CMstreq__photofbdatacopy				As String = "01.00"             'ﾌｫﾄFBﾃﾞｰﾀｺﾋﾟｰ

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN01U0      'ﾛｰｶﾙﾒﾆｭｰKey

    '@vsfFbDataListの定数宣言（ｶﾗﾑ）
    Private Const CMlngvsfListColNo                     As Integer = 0                  '№
    Private Const CMlngvsfListColItem1                  As Integer = 1                  'ﾊﾟﾗﾒｰﾀ1
    Private Const CMlngvsfListColItem2                  As Integer = 2                  'ﾊﾟﾗﾒｰﾀ2
    Private Const CMlngvsfListColItem3                  As Integer = 3                  'ﾊﾟﾗﾒｰﾀ3
    Private Const CMlngvsfListColItem4                  As Integer = 4                  'ﾊﾟﾗﾒｰﾀ4
    Private Const CMlngvsfListColItem5                  As Integer = 5                  'ﾊﾟﾗﾒｰﾀ5
    Private Const CMlngvsfListColItem6                  As Integer = 6                  'ﾊﾟﾗﾒｰﾀ6
    Private Const CMlngvsfListColItem7                  As Integer = 7                  'ﾊﾟﾗﾒｰﾀ7
    Private Const CMlngvsfListColItem8                  As Integer = 8                  'ﾊﾟﾗﾒｰﾀ8
    Private Const CMlngvsfListColItem9                  As Integer = 9                  'ﾊﾟﾗﾒｰﾀ9
    Private Const CMlngvsfListColItem10                 As Integer = 10                 'ﾊﾟﾗﾒｰﾀ10
    Private Const CMlngvsfListColItem11                 As Integer = 11                 'ﾊﾟﾗﾒｰﾀ11
    Private Const CMlngvsfListColItem12                 As Integer = 12                 'ﾊﾟﾗﾒｰﾀ12
    Private Const CMlngvsfListColFbLot                  As Integer = 13                 'ﾌｫﾄFB計算対象ﾛｯﾄ
    Private Const CMlngvsfListColEditTime               As Integer = 14                 '最終更新日時
    Private Const CMlngvsfListColEditEmp                As Integer = 15                 '最終更新者
    Private Const CMlngvsfListColComments               As Integer = 16                 'ｺﾒﾝﾄ

    '@vsfFbDataListの定数宣言（表示幅）
    Private Const CMlngvsfListColWNo                    As Integer = 42                 '№
    'Private Const CMlngvsfListColwItem1                 As Integer = 109                'ﾊﾟﾗﾒｰﾀ1
    Private Const CMlngvsfListColwItem1                 As Integer = 73                'ﾊﾟﾗﾒｰﾀ1
    Private Const CMlngvsfListColwItem2                 As Integer = 73                'ﾊﾟﾗﾒｰﾀ2
    Private Const CMlngvsfListColwItem3                 As Integer = 73                'ﾊﾟﾗﾒｰﾀ3
    Private Const CMlngvsfListColwItem4                 As Integer = 73                'ﾊﾟﾗﾒｰﾀ4
    Private Const CMlngvsfListColwItem5                 As Integer = 73                'ﾊﾟﾗﾒｰﾀ5
    Private Const CMlngvsfListColwItem6                 As Integer = 73                'ﾊﾟﾗﾒｰﾀ6
    Private Const CMlngvsfListColwItem7                 As Integer = 73                'ﾊﾟﾗﾒｰﾀ7
    Private Const CMlngvsfListColwItem8                 As Integer = 73                'ﾊﾟﾗﾒｰﾀ8
    Private Const CMlngvsfListColwItem9                 As Integer = 73                'ﾊﾟﾗﾒｰﾀ9
    Private Const CMlngvsfListColwItem10                As Integer = 73                'ﾊﾟﾗﾒｰﾀ10
    Private Const CMlngvsfListColwItem11                As Integer = 73                'ﾊﾟﾗﾒｰﾀ11
    Private Const CMlngvsfListColwItem12                As Integer = 73                'ﾊﾟﾗﾒｰﾀ12
    Private Const CMlngvsfListColwFbLot                 As Integer = 133                'ﾌｫﾄFB計算対象ﾛｯﾄ
    Private Const CMlngvsfListColwEditTime              As Integer = 167                '最終更新日時
    Private Const CMlngvsfListColwEditEmp               As Integer = 181                '最終更新者
    Private Const CMlngvsfListColwComments              As Integer = 133                'ｺﾒﾝﾄ

    '@vsfFbDataListの定数宣言（ﾀｲﾄﾙ）
    Private Const CMstrvsfListColTNo                    As String = ""
    Private Const CMstrvsfListColtItem1                 As String = ""
    Private Const CMstrvsfListColtItem2                 As String = ""
    Private Const CMstrvsfListColtItem3                 As String = ""
    Private Const CMstrvsfListColtItem4                 As String = ""
    Private Const CMstrvsfListColtItem5                 As String = ""
    Private Const CMstrvsfListColtItem6                 As String = ""
    Private Const CMstrvsfListColtItem7                 As String = ""
    Private Const CMstrvsfListColtItem8                 As String = ""
    Private Const CMstrvsfListColtItem9                 As String = ""
    Private Const CMstrvsfListColtItem10                As String = ""
    Private Const CMstrvsfListColtItem11                As String = ""
    Private Const CMstrvsfListColtItem12                As String = ""
    Private Const CMstrvsfListColtFbLot                 As String = "F/B計算対象ﾛｯﾄ"
    Private Const CMstrvsfListColtEditTime              As String = "最終更新日時"
    Private Const CMstrvsfListColtEditEmp               As String = "最終更新者"
    Private Const CMstrvsfListColtComments              As String = "ｺﾒﾝﾄ"

    '@vsfFbDataList2の定数宣言（ｶﾗﾑ）
    Private Const CMlngvsfList2ColNo                    As Integer = 0                  '№
    Private Const CMlngvsfList2ColItem1                 As Integer = 1                  'ﾊﾟﾗﾒｰﾀ1
    Private Const CMlngvsfList2ColItem2                 As Integer = 2                  'ﾊﾟﾗﾒｰﾀ2
    Private Const CMlngvsfList2ColItem3                 As Integer = 3                  'ﾊﾟﾗﾒｰﾀ3
    Private Const CMlngvsfList2ColItem4                 As Integer = 4                  'ﾊﾟﾗﾒｰﾀ4
    Private Const CMlngvsfList2ColEditTime              As Integer = 5                  '最終更新日時
    Private Const CMlngvsfList2ColEditEmp               As Integer = 6                  '最終更新者
    Private Const CMlngvsfList2ColComments              As Integer = 7                  'ｺﾒﾝﾄ

    '@vsfFbDataList2の定数宣言（表示幅）
    Private Const CMlngvsfList2ColWNo                   As Integer = 42                 '№
    Private Const CMlngvsfList2ColwItem1                As Integer = 133                'ﾊﾟﾗﾒｰﾀ1
    Private Const CMlngvsfList2ColwItem2                As Integer = 133                'ﾊﾟﾗﾒｰﾀ2
    Private Const CMlngvsfList2ColwItem3                As Integer = 133                'ﾊﾟﾗﾒｰﾀ3
    Private Const CMlngvsfList2ColwItem4                As Integer = 133                'ﾊﾟﾗﾒｰﾀ4
    Private Const CMlngvsfList2ColwEditTime             As Integer = 167                '最終更新日時
    Private Const CMlngvsfList2ColwEditEmp              As Integer = 133                '最終更新者
    Private Const CMlngvsfList2ColwComments             As Integer = 133                'ｺﾒﾝﾄ

    '@vsfFbDataList2の定数宣言（ﾀｲﾄﾙ）
    Private Const CMstrvsfList2ColTNo                   As String = ""
    Private Const CMstrvsfList2ColtItem1                As String = ""
    Private Const CMstrvsfList2ColtItem2                As String = ""
    Private Const CMstrvsfList2ColtItem3                As String = ""
    Private Const CMstrvsfList2ColtItem4                As String = ""
    Private Const CMstrvsfList2ColtEditTime             As String = "最終更新日時"
    Private Const CMstrvsfList2ColtEditEmp              As String = "最終更新者"
    Private Const CMstrvsfList2ColtComments             As String = "ｺﾒﾝﾄ"

    'vsfRecipeCopyの定数宣言（ｶﾗﾑ）
    Private Const CMintvsfCopyRecipe                    As Integer = 0                  'ｺﾋﾟｰ元ﾚｼﾋﾟ
    Private Const CMintvsfCopyGouki						As Integer = 1                  'ﾚｼﾋﾟ登録号機(元)
    Private Const CMintvsfCopyCpRecipe					As Integer = 2                  'ｺﾋﾟｰ先ﾚｼﾋﾟ
    Private Const CMintvsfCopyCpGouki					As Integer = 3                  'ﾚｼﾋﾟ登録号機(先)

    'vsfRecipeCopyの定数宣言（表示幅）
    Private Const CMintvsfCopyWRecipe                   As Integer = 320                'ｺﾋﾟｰ元ﾚｼﾋﾟ
    Private Const CMintvsfCopyWGouki					As Integer = 138                'ﾚｼﾋﾟ登録号機(元)
    Private Const CMintvsfCopyWCpRecipe					As Integer = 320                'ｺﾋﾟｰ先ﾚｼﾋﾟ
    Private Const CMintvsfCopyWCpGouki					As Integer = 133                'ﾚｼﾋﾟ登録号機(先)

    'vsfRecipeCopyの定数宣言（ﾀｲﾄﾙ）
    Private Const CMintvsfCopyTRecipe                   As String = "レシピ"
    Private Const CMintvsfCopyTGouki					As String = "レシピ登録号機"
    Private Const CMintvsfCopyTCpRecipe					As String = "レシピ"
    Private Const CMintvsfCopyTCpGouki					As String = "レシピ登録号機"

	'Web表示用
	Private Const CMstrDetailsNavi1						As String = "wtrn_fbdata.html?in_wp_id=&in_rcp_Scan=1&in_dsp_kbn="	'「FBデータ設定表示」
	Private Const CMstrDetailsNavi2						As String = "&in_recipe_id="										'「FBデータ設定表示」
	Private Const CMstrTrnWebUrl						As String = "WB0010"
	Private Const CMstrTrn								As String = "trn"
	Private Const CMstrParaKbnAwase						As String = "0"					'ﾊﾟﾗﾒｰﾀ表示区分(合せ)
	Private Const CMstrParaKbnRokou						As String = "1"					'ﾊﾟﾗﾒｰﾀ表示区分(露光)
	　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　
    '@ｸﾞﾘｯﾄﾞ制御(合せ)
    Private Const CMlngvsfColS                          As Integer = 13                 'ｶﾗﾑ数
    Private Const CMlngvsfListCols                      As Integer = 17                 'ｶﾗﾑ数
    '@ｸﾞﾘｯﾄﾞ制御(露光)
    Private Const CMlngvsf2ColS                         As Integer = 5                  'ｶﾗﾑ数
    Private Const CMlngvsfList2Cols                     As Integer = 8                  'ｶﾗﾑ数
	'@ｸﾞﾘｯﾄﾞ制御(ﾊﾟﾗﾒｰﾀｺﾋﾟｰ)
    Private Const CMlngvsf3ColS                         As Integer = 4                  'ｶﾗﾑ数

    '@ｸﾞﾘｯﾄﾞ制御(共通)
    Private Const CMlngvsfTRow                          As Integer = 0                  'ﾀｲﾄﾙ行
    Private Const CMlngVsfHFontSize                     As Integer = 9                  'ﾍｯﾀﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHFontSize2                    As Integer = 12                 'ﾍｯﾀﾞﾌｫﾝﾄｻｲｽﾞ
	Private Const CMlngVsfHFontSize3                    As Integer = 12                 'ﾍｯﾀﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                       As Integer = 27                 '行の高さ(ﾍｯﾀﾞｰ)
    Private Const CMlngvsfBHeight                       As Integer = 43                 '行の高さ(ﾎﾞﾃﾞｨ)
    Private Const CMlngInputNDataMaxByte                As Integer = 10                 '文字入力の最大ﾊﾞｲﾄ数(数値）

    '@ｽｸﾛｰﾙ制御
    Private Const CMlngSideScrollOnFlag                 As Integer = 1                  '横ｽｸﾛｰﾙ活性化
    Private Const CMlngSideScrollOffFlag                As Integer = 2                  '横ｽｸﾛｰﾙ非活性化
    Private Const CMlngUpDownindex                      As Integer = 0                  '縦ｽｸﾛｰﾙﾗﾍﾞﾙｲﾝﾃﾞｯｸｽ
    Private Const CMlngLeftRightindex                   As Integer = 1                  '横ｽｸﾛｰﾙﾗﾍﾞﾙｲﾝﾃﾞｯｸｽ

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Integer = 16                 'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 16                 'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols1                     As Integer = 1                  'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbRowHeight                     As Integer = 43                 'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                      As Integer = 0                  '名称列番=0
    Private Const CMlngCmbGridCol1                      As Integer = 1                  '名称列番=1

    '@Tabｲﾝﾃﾞｯｸｽ宣言
    Private Const CMlng0Tab                             As Integer = 0                  '合わせﾊﾟﾗﾒｰﾀﾀﾌﾞIndex
    Private Const CMlng1Tab                             As Integer = 1                  '露光ﾊﾟﾗﾒｰﾀﾀﾌﾞIndex
	Private Const CMlng2Tab                             As Integer = 2                  'ﾊﾟﾗﾒｰﾀｺﾋﾟｰﾀﾌﾞIndex

    '@その他
    Private Const CMlngDisplayMaxCnt                    As Integer = 500                '表示最大件数
    Private Const CMstrDisplayMax                       As String = "最大"
    Private Const CMlngMaxDispRow                       As Integer = 3                  'ｺﾒﾝﾄ1ﾍﾟｰｼﾞ最大行
    Private Const CMlngParameterNum                     As Integer = 8 + 4              '合せﾊﾟﾗﾒｰﾀ数ﾁｪｯｸ用(+Shot分離4)
    Private Const CMlngParameterNum2                    As Integer = 4                  '露光ﾊﾟﾗﾒｰﾀ数ﾁｪｯｸ用
	Private Const CMlngParameterNum3                    As Integer = 2                  'ﾊﾟﾗﾒｰﾀｺﾋﾟｰデータ数ﾁｪｯｸ用

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypChgSort                                 As ChgSort                      'ｿｰﾄ保持用(合せ)
    Private mtypChgSort2                                As ChgSort                      'ｿｰﾄ保持用(露光)
    Private mlngcmbWpIndex                              As Integer                      'ﾌｫﾄ号機ｺﾝﾎﾞ内容を退避(合せ)
    Private mlngcmbWp2Index                             As Integer                      'ﾌｫﾄ号機ｺﾝﾎﾞ内容を退避(露光)
    Private mlngcmb1stWpIndex                           As Integer                      '1stﾌｫﾄ号機ｺﾝﾎﾞ内容を退避
    Private mblnFirstLoad                               As Boolean                      '初回画面ﾛｰﾄﾞ判定ﾌﾗｸﾞ
    Private mtypPhotoFbDataList2Ans                     As PhotoFbDataList2Ans          'ﾌｫﾄF/Bﾃﾞｰﾀ格納構造体(露光)
    Private mtypMasRecipeNameList                       As MasRecipeNameList            'ﾚｼﾋﾟ応答格納構造体(合せ）
    Private mtypMasRecipeNameList2                      As MasRecipeNameList            'ﾚｼﾋﾟ応答格納構造体(露光)
	Private mtypEqTypeRecpList							As List(Of eqtyperecplist)		'装置ﾀｲﾌﾟ別ﾚｼﾋﾟﾘｽﾄ構造体
    Private mtypCpoyLine                                As PhotoFbDataChgReq            '行ｺﾋﾟｰﾃﾞｰﾀ格納(合せ)
    Private mtypCpoyLine2                               As PhotoFbDataChg2Req           '行ｺﾋﾟｰﾃﾞｰﾀ格納(露光)
    Private mblnCpoyLineFlag                            As Boolean                      '行ｺﾋﾟｰﾌﾗｸﾞ（True:ｺﾋﾟｰ中、False:なし）合せ
    Private mblnCpoyLine2Flag                           As Boolean                      '行ｺﾋﾟｰﾌﾗｸﾞ（True:ｺﾋﾟｰ中、False:なし）露光
    Private mstrRecipeID                                As String                       'ﾚｼﾋﾟID(合せ)
    Private mstrRecipeID2                               As String                       'ﾚｼﾋﾟID(露光)
    Private mstrBeforeEditString                        As String                       '変更前文字列
    Private mstrEntryTime                               As String                       '最新のENTRY_TIME(合せ)
    Private mstrEntryTime2                              As String                       '最新のENTRY_TIME(露光)
    Private mblnEventCancelFlag                         As Boolean                      'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ
    Private mblnAfterSerchFlag                          As Boolean                      '検索済ﾌﾗｸﾞ(合せ)
    Private mblnAfterSerch2Flag                         As Boolean                      '検索済ﾌﾗｸﾞ(露光)
    Private buttonProcessing                            As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                      'NSYS WindowCloseフラグ
    Private mstrOldGridEditorText                       As String                       'NSYS グリッドの編集前文字列
    Private FbDateInitFlg                               As Boolean                      'NSYS 合わせ最新取得押下時の初期化フラグ
    Private FbDate2InitFlg                              As Boolean                      'NSYS 露光最新取得押下時の初期化フラグ
    Private mblnTabSelectEnabled                        As Boolean                      'NSYS TabControlの変更許可


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
        mblnTabSelectEnabled = True
        Form_Load()
        'NSYS スクロールバーなしグリッドのマウスホイール対応
        pubVsfMouseWheelManager_Set(vsfFbDataList2, cmdUP2, cmdDown2, cmdLeft2, cmdRight2)
        pubVsfMouseWheelManager_Set(vsfFbDataList, cmdUP, cmdDown, cmdLeft, cmdRight)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:30:21 N.Kasai
    '更新日：2006/02/23 (Thu) 13:30:21
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns                     As Boolean              '汎用戻り値
        Dim lstrEventName               As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngWpListCnt               As Integer              '装置一覧件数
        Dim lstrWP                      As String               '装置ID退避

        Try
            'ｶｰｿﾙを砂時計に変更
			Cursor.Current = Cursors.WaitCursor

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            '@起動区分：Null(単体起動)
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01U0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                '@ﾌｫｰﾑを閉じる
                Call Form_QueryUnload(Me, New FormClosingEventArgs(CloseReason.UserClosing, False))
                Exit Sub
            End If
            
            '@構造体の初期化（ｿｰﾄ用）
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If Not IsNothing(.typChgSortList) Then
                    .typChgSortList.Clear()
                End If
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@画面初期化
            Call prvMainForm_Init()
            
            '@格納変数を初期化
            mlngcmbWpIndex = -1                 'ﾌｫﾄ号機ｺﾝﾎﾞ（合せ）
            mlngcmbWp2Index = -1                'ﾌｫﾄ号機ｺﾝﾎﾞ（露光）
            mlngcmb1stWpIndex = -1              '1stﾌｫﾄ号機ｺﾝﾎﾞ
            mstrRecipeID = vbNullString         'ﾚｼﾋﾟID(合せ)
            mstrRecipeID2 = vbNullString        'ﾚｼﾋﾟID(露光)
            
            '@行ｺﾋﾟｰﾌﾗｸﾞ（OFF)
            mblnCpoyLineFlag = False            '合せ
            mblnCpoyLine2Flag = False           '露光
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString   '合せ
            mtypChgSort2.strKey = vbNullString  '露光
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "Form_Load"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@装置一覧取得結果
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, llngWpListCnt, pstrSBID, CPstrCD2J)
            
            '@戻り値判定
            If lblnAns = True Then
                '@装置ｺﾝﾎﾞへｾｯﾄ
                Call prvcmbWp_Disp(llngWpListCnt)
                
                '@装置が1件の場合は装置に紐付くﾚｼﾋﾟを取得する。
                If llngWpListCnt = 1 Then
                
                    '@装置ID取得
                    With cmbWp
                        .ValueCol = 1
                        lstrWP = .Value
                    End With
                    
                    '@MSG[ﾚｼﾋﾟ名一覧取得]を実行
                    lblnAns = pubblnMasRecipeNameList_Sel(pstrSBID, _
                                                          CMstrmas_RecipNameList_Ver, _
                                                          vbNullString, _
                                                          lstrWP, _
                                                          vbNullString, _
                                                          mtypMasRecipeNameList)
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, lstrEventName)
                        Exit Sub
                    Else
                        '@露光用に退避
                        mtypMasRecipeNameList2 = mtypMasRecipeNameList
                    End If
                End If
            Else
                '@異常の場合終了
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                Exit Sub
            End If

			'ﾚｼﾋﾟｺﾋﾟｰ用ﾚｼﾋﾟ一覧取得(msgVer, Eq_Type, ﾚｼﾋﾟ部分一致, ﾚｼﾋﾟﾘｽﾄ格納構造体)
            lblnAns = pubblnEqtypeRecplist__Sel(CMstreq__eqtypeRecplist, CPstrEqTypeReticle, _
												vbNullString, mtypEqTypeRecpList)
            
            '戻り値判定
            If lblnAns = True Then

                'ｺﾝﾎﾞﾘｽﾄ設定
                Call prvcmbRecpList_Set(mtypEqTypeRecpList)
                
            Else
                '異常の場合終了
                'ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                Exit Sub
            End If
			
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True
            
            '@初回ﾛｰﾄﾞﾌﾗｸﾞ
            mblnFirstLoad = False
            
			'ｶｰｿﾙを通常に変更
			Cursor.Current = Cursors.Default

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
		
		Finally

			'ｶｰｿﾙを通常に変更
			Cursor.Current = Cursors.Default
        End Try
		
    End Sub

    '関数名：Form_Activate
    '機　能：ﾛｰﾄﾞ後処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/14 (Tue) 17:34:44 N.Kasai
    '更新日：2017/03/10 (Fri) 17:09:26 T.Oide
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            '@初回ﾌｫｰﾑ起動時のみ走行
            If mblnFirstLoad = True Then
                Exit Sub
            End If
           
            '@初回ﾌﾗｸﾞON
            mblnFirstLoad = True
            
            '@検索済ﾌﾗｸﾞOFF
            mblnAfterSerchFlag = False
            mblnAfterSerch2Flag = False
            
            '@合わせtabにﾌｫｰｶｽｾｯﾄ
            tabRecipe.SelectedTab.Name = Tab0.Name

            'NSYS 初期フォーカス設定
            Call pubSetFocus(cmbWP)
           
            '@---------------------------------
            '@条件ｺﾝﾎﾞが全て1件の場合のみ走行
            '@(多分ないと思うけどね)
            '@---------------------------------
            '@ﾌｫﾄ号機ｺﾝﾎﾞ
            If cmbWp.ListCount <> 1 Then
                Exit Sub
            End If
            '1stﾌｫﾄ号機ｺﾝﾎﾞ
            If cmbReferenceWP.ListCount <> 1 Then
                Exit Sub
            End If

            '@格納変数に初期値を設定
            mlngcmbWpIndex = 0              'ﾌｫﾄ号機ｺﾝﾎﾞ(合せ)
            mlngcmbWp2Index = 0             'ﾌｫﾄ号機ｺﾝﾎﾞ(露光)
            mlngcmb1stWpIndex = 0           '1stﾌｫﾄ号機ｺﾝﾎﾞ
            mstrRecipeID = vbNullString     'ﾚｼﾋﾟID(合せ)
            mstrRecipeID2 = vbNullString    'ﾚｼﾋﾟID(露光)
            
            '@ｺﾝﾎﾞﾁｪｯｸ
            Call prvComb_Chk()
            
            '@ﾃﾞｰﾀｸﾞﾘｯﾄﾞが使用可能の場合
            If vsfFbData.Enabled = True Then
                '@次項目にﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfFbData)
            Else
                '@最新取得ﾎﾞﾀﾝが使用可能の場合
                If cmdSearch.Enabled = True Then
                    '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdSearch)
                Else
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
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

    '関数名：cmbWP_Change
    '機　能：ﾌｫﾄ号機ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 14:18:03 N.Kasai
    '更新日：2006/03/02 (Thu) 14:18:03
    '備　考：
    Private Sub cmbWp_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp.Change

        Try
            '@ｸﾞﾘｯﾄﾞ簡易初期化
            Call prvGrid_Init()
            
            '@ｺﾝﾎﾞINDEX内容退避
            mlngcmbWpIndex = -1
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWP_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWP_CloseUp
    '機　能：装置ｺﾝﾎﾞ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 14:36:52 N.Kasai
    '更新日：2006/03/02 (Thu) 14:36:52
    '備　考：
    Private Sub cmbWp_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp.CloseUp

        Try
            '@ｺﾝﾎﾞが選択済みの場合
            If cmbWp.ListIndex > -1 Then
                '@Validate処理
                RemoveHandler cmbWp.Validating, AddressOf cmbWp_Validate
                Call cmbWp_Validate(cmbWp, New CancelEventArgs(True))
                AddHandler cmbWp.Validating, AddressOf cmbWp_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWP_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWP_Validate
    '機　能：装置ｺﾝﾎﾞValidate処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 14:37:17 N.Kasai
    '更新日：2006/03/02 (Thu) 14:37:17
    '備　考：
    Private Sub cmbWp_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWp.Validating

        Dim lstrEventName           As String               'ﾚｽﾎﾟﾝｽ
        Dim lblnAns                 As Boolean              '戻り値
        Dim lstrWP                  As String               '装置ID退避
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｺﾝﾎﾞ内容に変更がある場合
            If mlngcmbWpIndex = cmbWp.ListIndex Then
                '@ﾚｼﾋﾟｺﾝﾎﾞが使用可能の場合
                If txtRecipeID.Enabled = True Then
                    If ActiveControl.Name = cmbWp.Name Then
                        '@ﾚｼﾋﾟにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtRecipeID)
                    End If
                End If
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmbWP_Validate"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@装置ID取得
            With cmbWp
                .ValueCol = 1
                lstrWP = .Value
            End With
            
            '@MSG[ﾚｼﾋﾟ名一覧取得]を実行
            lblnAns = pubblnMasRecipeNameList_Sel(pstrSBID, _
                                                  CMstrmas_RecipNameList_Ver, _
                                                  vbNullString, _
                                                  lstrWP, _
                                                  vbNullString, _
                                                  mtypMasRecipeNameList)
            '@結果判定
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                Exit Sub
            End If
            
            
            '@ｺﾝﾎﾞ内容を変更
            mlngcmbWpIndex = cmbWp.ListIndex

            '@ﾚｼﾋﾟIDが選択済みの場合
            If txtRecipeID.Text <> vbNullString Then
                '@ﾚｼﾋﾟID整合性ﾁｪｯｸ
                lblnAns = prvblnRecipeData_Chk
                '@整合性結果NG
                If lblnAns = False Then
                    '@ﾚｼﾋﾟが使用可能の場合
                    If txtRecipeID.Enabled = True Then
                        If ActiveControl.Name = cmbWp.Name Then
                            '@ﾚｼﾋﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(txtRecipeID)
                        End If
                    End If
                
                    Exit Sub
                End If
            End If
            
            '@ｺﾝﾎﾞﾁｪｯｸ
            Call prvComb_Chk()
           
            '@ﾃﾞｰﾀｸﾞﾘｯﾄﾞが使用可能の場合
            If vsfFbData.Enabled = True Then
                If ActiveControl.Name = cmbWp.Name Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfFbData)
                End If
            Else
                '@ﾚｼﾋﾟが使用可能の場合
                If txtRecipeID.Enabled = True Then
                    If ActiveControl.Name = cmbWp.Name Then
                        '@ﾚｼﾋﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtRecipeID)
                    End If
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWP_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWP2_Change
    '機　能：ﾌｫﾄ号機ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 14:18:03 N.Kasai
    '更新日：2006/03/02 (Thu) 14:18:03
    '備　考：
    Private Sub cmbWp2_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp2.Change

        Try
            '@ｸﾞﾘｯﾄﾞ簡易初期化
            Call prvGrid_Init()
            
            '@ｺﾝﾎﾞINDEX内容退避
            mlngcmbWp2Index = -1
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWP2_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWP2_CloseUp
    '機　能：装置ｺﾝﾎﾞ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 14:36:52 N.Kasai
    '更新日：2006/03/02 (Thu) 14:36:52
    '備　考：
    Private Sub cmbWp2_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp2.CloseUp

        Try
            '@ｺﾝﾎﾞが選択済みの場合
            If cmbWP2.ListIndex > -1 Then
                '@Validate処理
                RemoveHandler cmbWp2.Validating, AddressOf cmbWp2_Validate
                Call cmbWp2_Validate(cmbWp2, New CancelEventArgs(True))
                AddHandler cmbWp2.Validating, AddressOf cmbWp2_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWP2_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWP2_Validate
    '機　能：装置ｺﾝﾎﾞValidate処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 14:37:17 N.Kasai
    '更新日：2006/03/02 (Thu) 14:37:17
    '備　考：
    Private Sub cmbWp2_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWp2.Validating

        Dim lstrEventName           As String               'ﾚｽﾎﾟﾝｽ
        Dim lblnAns                 As Boolean              '戻り値
        Dim lstrWP                  As String               '装置ID退避
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｺﾝﾎﾞ内容に変更がある場合
            If mlngcmbWp2Index = cmbWP2.ListIndex Then
                '@ﾚｼﾋﾟｺﾝﾎﾞが使用可能の場合
                If txtRecipeID2.Enabled = True Then
                    If ActiveControl.Name = cmbWp2.Name Then
                        '@ﾚｼﾋﾟにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtRecipeID2)
                    End If
                End If
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmbWP2_Validate"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@装置ID取得
            With cmbWP2
                .ValueCol = 1
                lstrWP = .Value
            End With
            
            '@MSG[ﾚｼﾋﾟ名一覧取得]を実行
            lblnAns = pubblnMasRecipeNameList_Sel(pstrSBID, _
                                                  CMstrmas_RecipNameList_Ver, _
                                                  vbNullString, _
                                                  lstrWP, _
                                                  vbNullString, _
                                                  mtypMasRecipeNameList2)
            '@結果判定
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                Exit Sub
            End If
            
            '@ｺﾝﾎﾞ内容を変更
            mlngcmbWp2Index = cmbWP2.ListIndex
            
            '@ﾚｼﾋﾟID整合性ﾁｪｯｸ
            lblnAns = prvblnRecipeData2_Chk
            '@ｴﾗｰありの場合
            If lblnAns = False Then
                
                If txtRecipeID2.Enabled = True Then
                    If ActiveControl.Name = cmbWp2.Name Then
                        '@ﾚｼﾋﾟIDにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtRecipeID2)
                    End If
                End If
                
                Exit Sub
            End If
            
            '@ｺﾝﾎﾞﾁｪｯｸ
            Call prvComb_Chk()
            
           
            '@ﾃﾞｰﾀｸﾞﾘｯﾄﾞが使用可能の場合
            If vsfFbData2.Enabled = True Then
                If ActiveControl.Name = cmbWp2.Name Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfFbData2)
                End If
            Else
                '@ﾚｼﾋﾟが使用可能の場合
                If txtRecipeID2.Enabled = True Then
                    If ActiveControl.Name = cmbWp2.Name Then
                        '@ﾚｼﾋﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtRecipeID2)
                    End If
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWP2_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmb1stWP_Change
    '機　能：1stﾌｫﾄ号機ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 15:21:19 N.Kasai
    '更新日：2006/03/02 (Thu) 15:21:19
    '備　考：
    Private Sub cmb1stWP_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbReferenceWP.Change

        Try
            '@ｸﾞﾘｯﾄﾞ簡易初期化
            Call prvGrid_Init()
            
            '@ｺﾝﾎﾞINDEX内容退避
            mlngcmb1stWpIndex = -1
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmb1stWP_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：cmb1stWP_CloseUp
    '機　能：1stﾌｫﾄ号機ｺﾝﾎﾞ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 15:22:36 N.Kasai
    '更新日：2006/03/02 (Thu) 15:22:36
    '備　考：
    Private Sub cmb1stWP_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbReferenceWP.CloseUp

        Try
            '@ｺﾝﾎﾞが選択済みの場合
            If cmbReferenceWP.ListIndex > -1 Then
                '@Validate処理
                RemoveHandler cmbReferenceWP.Validating, AddressOf cmb1stWP_Validate
                Call cmb1stWP_Validate(cmbReferenceWP, New CancelEventArgs(True))
                AddHandler cmbReferenceWP.Validating, AddressOf cmb1stWP_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmb1stWP_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmb1stWP_Validate
    '機　能：1stﾌｫﾄ号機ｺﾝﾎﾞValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 15:23:20 N.Kasai
    '更新日：2006/03/02 (Thu) 15:23:20
    '備　考：
    Private Sub cmb1stWP_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbReferenceWP.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｺﾝﾎﾞ内容に変更がある場合
            If mlngcmb1stWpIndex = cmbReferenceWP.ListIndex Then
                '@ﾃﾞｰﾀｸﾞﾘｯﾄﾞが使用可能の場合
                If vsfFbData.Enabled = True Then
                    If ActiveControl.Name = cmbReferenceWP.Name Then
                        '@次項目にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfFbData)
                    End If
                Else
                    '@最新取得ﾎﾞﾀﾝが使用可能の場合
                    If cmdSearch.Enabled = True Then
                        If ActiveControl.Name = cmbReferenceWP.Name Then
                            '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdSearch)
                        End If
                    Else
                        If ActiveControl.Name = cmbReferenceWP.Name Then
                            '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                End If
                '@処理抜け
                Exit Sub
            End If
            
            '@ｺﾝﾎﾞﾁｪｯｸ
            Call prvComb_Chk()
            
            '@ｺﾝﾎﾞ内容を変更
            mlngcmb1stWpIndex = cmbReferenceWP.ListIndex
           
            '@ﾃﾞｰﾀｸﾞﾘｯﾄﾞが使用可能の場合
            If vsfFbData.Enabled = True Then
                If ActiveControl.Name = cmbReferenceWP.Name Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfFbData)
                End If
            Else
                '@最新取得ﾎﾞﾀﾝが使用可能の場合
                If cmdSearch.Enabled = True Then
                    If ActiveControl.Name = cmbReferenceWP.Name Then
                        '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdSearch)
                    End If
                Else
                    If ActiveControl.Name = cmbReferenceWP.Name Then
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmb1stWP_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbPatchNo_Change
    '機　能：選択したﾊﾟｯﾁ№のﾃﾞｰﾀを表示する
    '引　数：なし
    '戻り値：
    '作成日：2017/01/20 (Fri) 10:10:42 T.Oide
    '更新日：2017/01/20 (Fri) 10:10:42
    '備　考：
    Private Sub cmbPatchNo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPatchNo.Change

        Try
            '@ｷｬﾝｾﾙﾌﾗｸﾞがTrueか
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            '@ﾃﾞｰﾀ表示
            RemoveHandler cmbPatchNo.Validating, AddressOf cmbPatchNo_Validate
            Call cmbPatchNo_Validate(cmbPatchNo, New CancelEventArgs(False))
            AddHandler cmbPatchNo.Validating, AddressOf cmbPatchNo_Validate
            
            Exit Sub
                
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPatchNo_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbPatchNo_Validate
    '機　能：F/Bﾃﾞｰﾀを表示する
    '引　数：Cancel：
    '戻り値：
    '作成日：2017/01/20 (Fri) 12:44:09 T.Oide
    '更新日：2017/01/20 (Fri) 12:44:09
    '備　考：
    Private Sub cmbPatchNo_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPatchNo.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｷｬﾝｾﾙﾌﾗｸﾞがTrueか
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If

            '@F/Bﾃﾞｰﾀ表示
            Call prvvsfFbDataList_Disp(cmbPatchNo.Text)

            Exit Sub
                
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPatchNo_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:31:41 N.Kasai
    '更新日：2006/02/23 (Thu) 13:31:41
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim llngRet         As Integer      '戻り値
        Dim ltypCommonInfo  As CommonInfo   '構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@終了関数を実行する
            llngRet = publngEnd_Proc(CPstrKeyEN01U0, ltypCommonInfo)

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

    '関数名：cmdPatDivSet_Click
    '機　能：patch分割設定画面呼出
    '引　数：なし
    '戻り値：
    '作成日：2017/01/19 (Thu) 10:55:25 T.Oide
    '更新日：2017/01/19 (Thu) 10:55:25
    '備　考：
    Private Sub cmdPatDivSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPatDivSet.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                
            '@「ﾌｫﾄF/B patch分割ﾊﾟﾗﾒｰﾀ設定」画面表示
            frmxxEN01U2.Instance.ShowDialog(Me)
            frmxxEN01U2.Instance = Nothing
            
            '@最新情報を取得する
            Call cmdSearch_Click(cmdSearch, New EventArgs)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPatDivSet_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '関数名：cmdCopy_Click
    '機　能：行ｺﾋﾟｰﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/31 (Fri) 15:35:00 N.Kasai
    '更新日：2007/08/31 (Fri) 15:35:00
    '備　考：
    Private Sub cmdCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCopy.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾀﾌﾞ判定
            Select Case tabRecipe.SelectedTab.Name
                
                '@合わせﾊﾟﾗﾒｰﾀ
                Case Tab0.Name
             
                    With vsfFbDataList
                        If .Row > 0 Then
                            '@行ｺﾋﾟｰ
                            mtypCpoyLine.strShiftX = .GetData(.Row, CMlngvsfListColItem1)
                            mtypCpoyLine.strShiftY = .GetData(.Row, CMlngvsfListColItem2)
                            mtypCpoyLine.strWaferMagX = .GetData(.Row, CMlngvsfListColItem3)
                            mtypCpoyLine.strWaferMagY = .GetData(.Row, CMlngvsfListColItem4)
                            mtypCpoyLine.strWaferRotX = .GetData(.Row, CMlngvsfListColItem5)
                            mtypCpoyLine.strWaferRotY = .GetData(.Row, CMlngvsfListColItem6)
                            mtypCpoyLine.strShotRot = .GetData(.Row, CMlngvsfListColItem7)
                            mtypCpoyLine.strShotMag = .GetData(.Row, CMlngvsfListColItem8)
                            'Shot分離
                            mtypCpoyLine.strShotRotX = .GetData(.Row, CMlngvsfListColItem9)
                            mtypCpoyLine.strShotRotY = .GetData(.Row, CMlngvsfListColItem10)
                            mtypCpoyLine.strShotMagX = .GetData(.Row, CMlngvsfListColItem11)
                            mtypCpoyLine.strShotMagY = .GetData(.Row, CMlngvsfListColItem12)
                            
                            '@行ｺﾋﾟｰﾌﾗｸﾞ（ON)
                            mblnCpoyLineFlag = True
                            '@貼り付けﾎﾞﾀﾝ使用可
                            cmdPaste.Enabled = True
                        End If
                    End With
                    
                '@露光ﾊﾟﾗﾒｰﾀ
                Case Tab1.Name
                
                    With vsfFbDataList2
                        If .Row > 0 Then
                            '@行ｺﾋﾟｰ
                            mtypCpoyLine2.strExposureLowerLimitValue = .GetData(.Row, CMlngvsfList2ColItem1)
                            mtypCpoyLine2.strExposureValue = .GetData(.Row, CMlngvsfList2ColItem2)
                            mtypCpoyLine2.strExposureUpperLimitValue = .GetData(.Row, CMlngvsfList2ColItem3)
                            mtypCpoyLine2.strFocusOffsetValue = .GetData(.Row, CMlngvsfList2ColItem4)
                            
                            '@行ｺﾋﾟｰﾌﾗｸﾞ（ON)
                            mblnCpoyLine2Flag = True
                            '@貼り付けﾎﾞﾀﾝ使用可
                            cmdPaste.Enabled = True
                        End If
                    End With
                    
            End Select
            
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

    '関数名：cmdPaste_Click
    '機　能：行貼り付け
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/04 (Tue) 09:53:46 N.Kasai
    '更新日：2007/09/04 (Tue) 09:53:46
    '備　考：
    Private Sub cmdPaste_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPaste.Click
        
        Dim llngCnt As Integer  'ｶｳﾝﾀ
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾀﾌﾞ判定
            Select Case tabRecipe.SelectedTab.Name
                
                '@合わせﾊﾟﾗﾒｰﾀ
                Case Tab0.Name
            
                    With vsfFbData
                        '@ｸﾞﾘｯﾄﾞ使用不可の場合
                        If .Enabled = False Then
                            Exit Sub
                        End If
                    
                        If .Row = 1 Then
                             .SetData(.Row, CMlngvsfListColItem1, CDbl(mtypCpoyLine.strShiftX))
                             .SetData(.Row, CMlngvsfListColItem2, CDbl(mtypCpoyLine.strShiftY))
                             .SetData(.Row, CMlngvsfListColItem3, CDbl(mtypCpoyLine.strWaferMagX))
                             .SetData(.Row, CMlngvsfListColItem4, CDbl(mtypCpoyLine.strWaferMagY))
                             .SetData(.Row, CMlngvsfListColItem5, CDbl(mtypCpoyLine.strWaferRotX))
                             .SetData(.Row, CMlngvsfListColItem6, CDbl(mtypCpoyLine.strWaferRotY))
                             .SetData(.Row, CMlngvsfListColItem7, CDbl(mtypCpoyLine.strShotRot))
                             .SetData(.Row, CMlngvsfListColItem8, CDbl(mtypCpoyLine.strShotMag))
                             'Shot分離
                             .SetData(.Row, CMlngvsfListColItem9, CDbl(mtypCpoyLine.strShotRotX))
                             .SetData(.Row, CMlngvsfListColItem10, CDbl(mtypCpoyLine.strShotRotY))
                             .SetData(.Row, CMlngvsfListColItem11, CDbl(mtypCpoyLine.strShotMagX))
                             .SetData(.Row, CMlngvsfListColItem12, CDbl(mtypCpoyLine.strShotMagY))
                        End If
                        
                        '@ﾊﾞｯｸｶﾗｰの変更
                        For llngCnt = 0 To .Cols.Count - 1
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White
                            Dim cellRange As CellRange = .GetCellRange(1, llngCnt)
                            cellRange.Style = newStyle
                        Next

                        'Shot分離なし
                        If lblShotSeparateFlag.Text <> CPstrAriFlg Then
                            '@ﾊﾞｯｸｶﾗｰの変更(入力不可色：ｸﾞﾚｰ)
                            Dim newShotStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                            newShotStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                            Dim cellShot As CellRange = .GetCellRange(.Rows.Count - 1, CMlngvsfListColItem9, .Rows.Count - 1, CMlngvsfListColItem12)
                            cellShot.Style = newShotStyle

                        ’Shot分離あり
                        Else
                            '@ﾊﾞｯｸｶﾗｰの変更(入力不可色：ｸﾞﾚｰ)
                            Dim newShotStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                            newShotStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                            Dim cellShot As CellRange = .GetCellRange(.Rows.Count - 1, CMlngvsfListColItem7, .Rows.Count - 1, CMlngvsfListColItem8)
                            cellShot.Style = newShotStyle

                        End If
                        
                        .Select(.Row, CMlngvsfListColItem1)
                        .Focus()
                    
                    End With
                    
                '@露光ﾊﾟﾗﾒｰﾀ
                Case Tab1.Name
                    
                     With vsfFbData2
                        '@ｸﾞﾘｯﾄﾞ使用不可の場合
                        If .Enabled = False Then
                            Exit Sub
                        End If
                    
                        If .Row = 1 Then
                             .SetData(.Row, CMlngvsfList2ColItem1, CDbl(mtypCpoyLine2.strExposureLowerLimitValue))
                             .SetData(.Row, CMlngvsfList2ColItem2, CDbl(mtypCpoyLine2.strExposureValue))
                             .SetData(.Row, CMlngvsfList2ColItem3, CDbl(mtypCpoyLine2.strExposureUpperLimitValue))
                             .SetData(.Row, CMlngvsfList2ColItem4, CDbl(mtypCpoyLine2.strFocusOffsetValue))
                        End If
                        
                        '@ﾊﾞｯｸｶﾗｰの変更
                        For llngCnt = 0 To .Cols.Count - 1
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White
                            Dim cellRange As CellRange = .GetCellRange(1, llngCnt)
                            cellRange.Style = newStyle
                        Next
                        
                        .Select(.Row, CMlngvsfListColItem1)
                        .Focus()
                    
                    End With
            End Select
            
            '@共通ｺﾏﾝﾄﾞﾎﾞﾀﾝﾁｪｯｸ
            Call prvCmdButton_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPaste_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：cmdLineAdd_Click
    '機　能：行追加処理
    '引　数：なし
    '戻り値：なし
    '作成日：2024/02/14 (Wed) 14:54:00 T.Oide
    '更新日：2024/02/14 (Wed) 14:54:00
    '備　考：
	Private Sub cmdLineAdd_Click(sender As Object, e As EventArgs) Handles cmdLineAdd.Click

		Try
			With vsfRecipeCopy

				'空行追加
                .AddItem(vbNullString, .Rows.Count)
				.Rows(.Rows.Count - 1).Height = CMlngVsfHHeight         '行高さ設定
				.Row = .Rows.Count - 1
				.Enabled = True
			End With

			'ﾎﾞﾀﾝ有効/無効制御
			Call prvCmdButton_Chk()

			Exit Sub

		Catch ex As Exception

			'ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLineAdd_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

		End Try

	End Sub

	'関数名：cmdLineDel_Click
    '機　能：行削除処理
    '引　数：なし
    '戻り値：なし
    '作成日：2024/02/14 (Wed) 14:54:00 T.Oide
    '更新日：2024/02/14 (Wed) 14:54:00
    '備　考：
	Private Sub cmdLineDel_Click(sender As Object, e As EventArgs) Handles cmdLineDel.Click

		Try
			With vsfRecipeCopy

				'ﾍｯﾀﾞｰ行の場合は何もしない
				If .Row <= 0 Then
					Exit Sub
				End If

				'選択中の行を削除
				.RemoveItem(.Row)

			End With

			'ﾎﾞﾀﾝ有効/無効制御
			Call prvCmdButton_Chk()

			Exit Sub

		Catch ex As Exception

			'ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLineDel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

		End Try

	End Sub

	'関数名：cmdKakunin_Click
    '機　能：コピーデータ確認処理(Web-トラン「FBデータ設定表示」起動)
    '引　数：なし
    '戻り値：なし
    '作成日：2024/02/14 (Wed) 14:54:00 T.Oide
    '更新日：2024/02/14 (Wed) 14:54:00
    '備　考：
	Private Sub cmdKakunin_Click(sender As Object, e As EventArgs) Handles cmdKakuninA.Click, cmdKakuninR.Click

		Dim lstrRecipeId	As String = Nothing
		Dim lstrDispKbn		As String = Nothing						'表示区分(0：合わせﾊﾟﾗﾒｰﾀ、1:露光ﾊﾟﾗﾒｰﾀ)
		Dim clickedButton	As Button = DirectCast(sender, Button)	'押されたボタンの区別用

		Try
			'クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
			'押されたボタン判定
			If clickedButton Is cmdKakuninA Then
				' cmdKakuninA クリック
				lstrDispKbn = CMstrParaKbnAwase     '0:合せを設定
			ElseIf clickedButton Is cmdKakuninR Then
				' cmdKakuninRクリック
				lstrDispKbn = CMstrParaKbnRokou		'1:露光を設定
			End If

			With vsfRecipeCopy

				'データがない場合は表示しない
				If .Rows.Count = 1 Then
					Exit Sub
				End If

				'ﾚｼﾋﾟを選択していない場合処理しない
				If .Col <> CMintvsfCopyRecipe And .Col <> CMintvsfCopyCpRecipe Then
					Exit Sub
				End If

				'ﾚｼﾋﾟIDを格納
				lstrRecipeId = .GetData(.Row, .Col)

				'ﾚｼﾋﾟIDが空の場合処理しない
				If lstrRecipeId = vbNullString Then
					Exit Sub
				End If

				'ブラウザ接続情報取得
				Dim lstrTitle			As String = vbNullString	'接続先URLを取得する為のダミー
				Dim lintCarrTakeOver	As String = vbNullString	'同上
				Dim lstrFormName		As String = vbNullString
				Dim lstrUrl				As String = vbNullString
				Call pubMenuItemCorrelation_Set(CMstrTrnWebUrl, lstrTitle, lintCarrTakeOver, lstrFormName)
				lstrUrl = Mid(lstrFormName, 1, InStr(lstrFormName, CMstrTrn) + 3)
				Dim strTmp As String = lstrUrl & CMstrDetailsNavi1 & lstrDispKbn & CMstrDetailsNavi2 & lstrRecipeId
				'Web「FBデータ設定表示」起動
				Call browserStertUp(strTmp)
			End With

            Exit Sub
			
		Catch ex As Exception

			'ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdKakunin_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

		End Try

	End Sub

    '関数名：cmdProcEnd_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 16:07:20 N.Kasai
    '更新日：2024/02/20 (Tue) 09:32:52 T.Oide
    '備　考
    Private Sub cmdProcEnd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdProcEnd.Click
        
        Dim lblnAns                 As Boolean              '登録戻り値(True/False)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim ltypPhotoFbDataChg2Req  As PhotoFbDataChg2Req   'ﾌｫﾄF/Bﾃﾞｰﾀ変更要求格納構造体(露光)
        Dim lstrMsg                 As String               '成功ﾒｯｾｰｼﾞ格納
        Dim lstrFunctionID          As String               '機能ID
        Dim lstrActionID            As String               'ｱｸｼｮﾝID
		Dim ltypPhotofbdataCopy		As photofbdatacopy = Nothing	'ﾌｫﾄFBﾚｼﾋﾟﾊﾟﾗﾒｰﾀｺﾋﾟｰ

        Try
            'クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾀﾌﾞ判定
            Select Case tabRecipe.SelectedTab.Name
                
                '@合わせﾊﾟﾗﾒｰﾀ
                Case Tab0.Name
            
                    '@確定ﾁｪｯｸ
                    lblnAns = prvblnProcEnd_Chk
                    '@結果判定
                    If lblnAns = False Then
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
                    lstrEventName = "cmdProcEnd_Click"
                    Call pubResponseStart(Me.Name, lstrEventName)

                    '@更新内容の設定
                    With ptypPhotoFbDataChgReq
                        '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                        .strMsgVer = CMstreq__photofbdatachgVer
                        '@ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strSbID = pstrSBID
                        '@ﾌｫﾄ号機
                        cmbWp.ValueCol = CMlngCmbGridCol1
                        .strWpID = cmbWp.Value
                        '@ﾚｼﾋﾟID
                        .strRecipeId = txtRecipeID.Text
                        '基準ﾌｫﾄ号機
                        cmbReferenceWP.ValueCol = CMlngCmbGridCol1
                        .strReferencePhotoWpID = cmbReferenceWP.Value

                        '@F/Bﾊﾟﾗﾒｰﾀ
                        .strShiftX = CDbl(Format$(vsfFbData.GetData(vsfFbData.Rows.Fixed, CMlngvsfListColItem1), _
                                            pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShiftXValidDigit)))

                        '@F/Bﾊﾟﾗﾒｰﾀ
                        .strShiftY = CDbl(Format$(vsfFbData.GetData(vsfFbData.Rows.Fixed, CMlngvsfListColItem2), _
                                            pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShiftYValidDigit)))

                        '@F/Bﾊﾟﾗﾒｰﾀ
                        .strWaferMagX = CDbl(Format$(vsfFbData.GetData(vsfFbData.Rows.Fixed, CMlngvsfListColItem3), _
                                            pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferMagXValidDigit)))

                        '@F/Bﾊﾟﾗﾒｰﾀ
                        .strWaferMagY = CDbl(Format$(vsfFbData.GetData(vsfFbData.Rows.Fixed, CMlngvsfListColItem4), _
                                            pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferMagYValidDigit)))

                        '@F/Bﾊﾟﾗﾒｰﾀ
                        .strWaferRotX = CDbl(Format$(vsfFbData.GetData(vsfFbData.Rows.Fixed, CMlngvsfListColItem5), _
                                            pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferRotXValidDigit)))

                        '@F/Bﾊﾟﾗﾒｰﾀ
                        .strWaferRotY = CDbl(Format$(vsfFbData.GetData(vsfFbData.Rows.Fixed, CMlngvsfListColItem6), _
                                            pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferRotYValidDigit)))

                        '@F/Bﾊﾟﾗﾒｰﾀ
                        .strShotRot = CDbl(Format$(vsfFbData.GetData(vsfFbData.Rows.Fixed, CMlngvsfListColItem7), _
                                            pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotValidDigit)))

                        '@F/Bﾊﾟﾗﾒｰﾀ
                        .strShotMag = CDbl(Format$(vsfFbData.GetData(vsfFbData.Rows.Fixed, CMlngvsfListColItem8), _
                                            pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagValidDigit)))

                        'Shot分離
                        .strShotRotX = CDbl(Format$(vsfFbData.GetData(vsfFbData.Rows.Fixed, CMlngvsfListColItem9), _
                                            pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotXValidDigit)))

                        .strShotRotY = CDbl(Format$(vsfFbData.GetData(vsfFbData.Rows.Fixed, CMlngvsfListColItem10), _
                                            pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotYValidDigit)))
                        
                        .strShotMagX = CDbl(Format$(vsfFbData.GetData(vsfFbData.Rows.Fixed, CMlngvsfListColItem11), _
                                            pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagXValidDigit)))
                        
                        .strShotMagY = CDbl(Format$(vsfFbData.GetData(vsfFbData.Rows.Fixed, CMlngvsfListColItem12), _
                                            pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagYValidDigit)))

                        '@作業者ID
                        .strEmpID = pstrUserID

                        '@ｺﾒﾝﾄ
                        .strComments = txtComments.Text

                        '@最新ﾃﾞｰﾀ更新日時（排他用）
                        .strEntryTime = mstrEntryTime
                        
                        '@ﾊﾟｯﾁ分割数（ﾊﾟｯﾁ分割なしの場合は1固定)
                        .lngPatchDivideNum = CPlngPatchNo1

                    End With
                    
                    '@【ﾌｫﾄF/Bﾃﾞｰﾀ変更(合せ)】
                    lblnAns = pubblnPhotoFbDataChg_Upd(ptypPhotoFbDataChgReq)
                    
                    '@結果判定
                    If lblnAns = True Then
                    
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(Me.Name, lstrEventName)
                        
                        '@ﾀﾌﾞ名取得
                        lstrMsg = Tab0.Text
                        '@ﾒｯｾｰｼﾞ表示"<TRM46I>$$合せパラメータを登録しました。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0046, lstrMsg)
                        '@成功ﾒｯｾｰｼﾞ表示
                        Call pubVsfInfo_Disp(pstrDMsg)
                        
                        '@ｸﾞﾘｯﾄﾞ初期化
                        Call prvGrid_Init()
                        
                        '@確定後の最新を取得する。
                        Call cmdSearch_Click(cmdSearch, New EventArgs)
                        
                        '@ﾃﾞｰﾀ件数判定
                        If vsfFbDataList.Rows.Count < vsfFbDataList.Rows.Fixed Then
                            '@該当件数なし
                            '@構造体の初期化（ｿｰﾄ用）
                            With mtypChgSort
                                '@ｿｰﾄ保持構造体初期化
                                .lngCnt = 0
                                If Not IsNothing(.typChgSortList) Then
                                    .typChgSortList.Clear()
                                End If
                                '@列幅変更ﾌﾗｸﾞ（未変更）
                                .blnChgWidth = False
                                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                                .strKey = vbNullString
                            End With
                        End If
                        
                        '@ﾊｲﾗｲﾄ表示
                        vsfFbData.Select(1, 0)
                        '@ﾌｫｰｶｽを入力可能ｴﾘｱへ設定する。
                        Call pubSetFocus(vsfFbData)
                       
                    Else
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, lstrEventName)
                        '@異常の場合終了
                        Exit Sub
                    End If
                    
                '@露光ﾊﾟﾗﾒｰﾀ
                Case Tab1.Name
                    
                    '@確定ﾁｪｯｸ
                    lblnAns = prvblnProcEnd_Chk
                    '@結果判定
                    If lblnAns = False Then
                        Exit Sub
                    End If
                    
                    '@権限ﾁｪｯｸ
                    lblnAns = prvblnAuthority_Chk
                    
                    '@結果判定
                    If lblnAns = False Then
                        '@権限不要の場合
                        '@作業者ｺｰﾄﾞ入力
                        frmxxCM0010.Instance.ShowDialog(Me)
                        frmxxCM0010.Instance = Nothing
                        
                        '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
                        If pstrUserID = vbNullString Then
                            '@未入力の場合、投入中止
                            Exit Sub
                        End If
                        
                        '@ﾚｽﾎﾟﾝｽ取得開始
                        lstrEventName = "cmdProcEnd_Click"
                        Call pubResponseStart(Me.Name, lstrEventName)

                    Else
                        '@権限要の場合
                        '@作業者ｺｰﾄﾞ入力(ﾊﾟｽﾜｰﾄﾞ付き）
                        frmxxCM0020.Instance.ShowDialog(Me)
                        frmxxCM0020.Instance = Nothing
                        
                        '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
                        If pstrUserID = vbNullString Then
                            '@未入力の場合、投入中止
                            Exit Sub
                        End If
                    
                        '@実行権限の処理を追加
                        lstrFunctionID = CPstrKeyEN01U0             '機能ID：EN01U0
                        lstrActionID = CPstrExposureAuth            'ｱｸｼｮﾝID：露光パラメータ変更
                        
                        '@ﾚｽﾎﾟﾝｽ取得開始
                        lstrEventName = "cmdProcEnd_Click"
                        Call pubResponseStart(Me.Name, lstrEventName)
                        
                        '@実行権限ﾁｪｯｸ
                        lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, pstrUserID, pstrUserName, pstrSBID)
                        '@結果判定
                        If lblnAns = False Then
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(Me.Name, lstrEventName)
                    
                            '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, pstrUserName, lstrActionID)
                            '@警告ﾒｯｾｰｼﾞ
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                            Exit Sub
                        End If
                    End If
                    
                    '@更新内容の設定
                    With ltypPhotoFbDataChg2Req
                        '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                        .strMsgVer = CMstreq__photofbdatachg2Ver
                        '@ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strSbID = pstrSBID
                        '@ﾌｫﾄ号機
                        cmbWP2.ValueCol = CMlngCmbGridCol1
                        .strWpID = cmbWP2.Value
                        '@ﾚｼﾋﾟID
                        .strRecipeId = txtRecipeID2.Text
                        
                        '@F/Bﾊﾟﾗﾒｰﾀ（EXPOSURE_LOWER_LIMIT）計算値
                        .strExposureLowerLimitValue = CDbl(Format$(vsfFbData2.GetData(vsfFbData2.Rows.Fixed, CMlngvsfList2ColItem1), _
                                            pubStrFormatValue_Set(mtypPhotoFbDataList2Ans.strExposureLowerLimitValidDigit)))
                        
                        '@F/Bﾊﾟﾗﾒｰﾀ（EXPOSURE）計算値
                        .strExposureValue = CDbl(Format$(vsfFbData2.GetData(vsfFbData2.Rows.Fixed, CMlngvsfList2ColItem2), _
                                            pubStrFormatValue_Set(mtypPhotoFbDataList2Ans.strExposureValidDigit)))
                        
                        '@F/Bﾊﾟﾗﾒｰﾀ（EXPOSURE_UPPER_LIMIT）計算値
                        .strExposureUpperLimitValue = CDbl(Format$(vsfFbData2.GetData(vsfFbData2.Rows.Fixed, CMlngvsfList2ColItem3), _
                                            pubStrFormatValue_Set(mtypPhotoFbDataList2Ans.strExposureUpperLimitValidDigit)))
                        
                        '@F/Bﾊﾟﾗﾒｰﾀ（FOCUSOFFSET）計算値
                        .strFocusOffsetValue = CDbl(Format$(vsfFbData2.GetData(vsfFbData2.Rows.Fixed, CMlngvsfList2ColItem4), _
                                            pubStrFormatValue_Set(mtypPhotoFbDataList2Ans.strFocusOffsetValidDigit)))
                        
                        
                        '@作業者ID
                        .strEmpID = pstrUserID
                        
                        '@ｺﾒﾝﾄ
                        .strComments = txtComments2.Text
                        
                        '@最新ﾃﾞｰﾀ更新日時（排他用）
                        .strEntryTime = mstrEntryTime2
                        
                    End With
                    
                    '@【ﾌｫﾄF/Bﾃﾞｰﾀ変更(露光)】
                    lblnAns = pubblnPhotoFbDataChg2_Upd(ltypPhotoFbDataChg2Req)
                    
                    '@結果判定
                    If lblnAns = True Then
                    
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(Me.Name, lstrEventName)
                        
                        '@ﾀﾌﾞ名取得
                        lstrMsg = Tab1.Text
                        '@ﾒｯｾｰｼﾞ表示"<TRM46I>$$露光パラメータを登録しました。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0046, lstrMsg)
                        '@成功ﾒｯｾｰｼﾞ表示
                        Call pubVsfInfo_Disp(pstrDMsg)
                        
                        '@ｸﾞﾘｯﾄﾞ初期化
                        Call prvGrid_Init()
                        
                        '@確定後の最新を取得する。
                        Call cmdSearch2_Click(cmdSearch2, New EventArgs)
                        
                        '@ﾃﾞｰﾀ件数判定
                        If vsfFbDataList2.Rows.Count < vsfFbDataList2.Rows.Fixed Then
                            '@該当件数なし
                            '@構造体の初期化（ｿｰﾄ用）
                            With mtypChgSort2
                                '@ｿｰﾄ保持構造体初期化
                                .lngCnt = 0
                                If Not IsNothing(.typChgSortList) Then
                                    .typChgSortList.Clear()
                                End If
                                '@列幅変更ﾌﾗｸﾞ（未変更）
                                .blnChgWidth = False
                                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                                .strKey = vbNullString
                            End With
                        End If
                        
                        '@ﾊｲﾗｲﾄ表示
                        vsfFbData2.Select(1, 0)
                        '@ﾌｫｰｶｽを入力可能ｴﾘｱへ設定する。
                        Call pubSetFocus(vsfFbData2)
                       
                    Else
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, lstrEventName)
                        '@異常の場合終了
                        Exit Sub
                    End If
				
				'ﾊﾟﾗﾒｰﾀｺﾋﾟｰTab
				Case Tab2.Name
                    
					'登録ﾁｪｯｸ
                    lblnAns = prvblnParaCopy_Chk()
                    
					'NGの場合終了
                    If lblnAns = False Then
                        Exit Sub
                    End If
                    
                    '@権限ﾁｪｯｸ
                    lblnAns = prvblnAuthority_Chk
                    
                    '@結果判定
                    If lblnAns = False Then
                        '@権限不要の場合
                        '@作業者ｺｰﾄﾞ入力
                        frmxxCM0010.Instance.ShowDialog(Me)
                        frmxxCM0010.Instance = Nothing
                        
                        '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
                        If pstrUserID = vbNullString Then
                            '@未入力の場合、投入中止
                            Exit Sub
                        End If
                        
                        '@ﾚｽﾎﾟﾝｽ取得開始
                        lstrEventName = "cmdProcEnd_Click"
                        Call pubResponseStart(Me.Name, lstrEventName)

                    Else
                        '@権限要の場合
                        '@作業者ｺｰﾄﾞ入力(ﾊﾟｽﾜｰﾄﾞ付き）
                        frmxxCM0020.Instance.ShowDialog(Me)
                        frmxxCM0020.Instance = Nothing
                        
                        '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
                        If pstrUserID = vbNullString Then
                            '@未入力の場合、投入中止
                            Exit Sub
                        End If
                    
                        '@実行権限の処理を追加
                        lstrFunctionID = CPstrKeyEN01U0             '機能ID：EN01U0
                        lstrActionID = CPstrExposureAuth            'ｱｸｼｮﾝID：露光パラメータ変更      後で変更する
                        
                        '@ﾚｽﾎﾟﾝｽ取得開始
                        lstrEventName = "cmdProcEnd_Click"
                        Call pubResponseStart(Me.Name, lstrEventName)
                        
                        '@実行権限ﾁｪｯｸ
                        lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, pstrUserID, pstrUserName, pstrSBID)
                        '@結果判定
                        If lblnAns = False Then
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(Me.Name, lstrEventName)
                    
                            '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, pstrUserName, lstrActionID)
                            '@警告ﾒｯｾｰｼﾞ
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                            Exit Sub
                        End If
                    End If
                    
					'登録ﾃﾞｰﾀを構造体に格納
					ltypPhotofbdatacopy.strMsgVer = CMstreq__photofbdatacopy
					ltypPhotofbdatacopy.strEmpId = pstrUserID
					lblnAns = prvblnParaCopy_Set(ltypPhotofbdatacopy)
                    
					'NGの場合終了
                    If lblnAns = False Then
                        Exit Sub
                    End If
					
					'ﾊﾟﾗﾒｰﾀｺﾋﾟｰ実行
                    lblnAns = pubblnPhotoParaCopy(ltypPhotofbdatacopy)
                    
                    '@結果判定
                    If lblnAns = True Then
                    
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(Me.Name, lstrEventName)
                        
                        '>$$%1を登録しました。
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0046, Tab2.Text)
                        Call pubVsfInfo_Disp(pstrDMsg)
						
						'ｸﾞﾘｯﾄﾞを灰色に変更して登録が完了したことを解るようにする
						Call prvVsfRecipeCopyBackclor_chg()

                    Else
                        
						'ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, lstrEventName)

                        '異常の場合終了
                        Exit Sub

					End If

            End Select
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdProcEnd_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try

    End Sub

    '関数名：cmdClipCopy_Click
    '機　能：ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
    '引　数：なし
    '戻り値：なし
    '作成日：2017/01/26 (Thu) 11:44:50 T.Oide
    '更新日：2017/03/10 (Fri) 16:04:54 T.Oide
    '備　考：
    Private Sub cmdClipCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClipCopy.Click

        Dim llngRowCnt     As Integer      '行ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngColCnt     As Integer      '列ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrRET        As String       'ｺﾋﾟｰ文字列
        Dim lstrWk         As String       '文字列編集
        Dim lobjGrid        As C1FlexGrid
        
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
            
            '@最前面のﾀﾌﾞ判定
            Select Case tabRecipe.SelectedTab.Name
                '@合せ
                Case Tab0.Name
                    lobjGrid = vsfFbData
                '@露光
                Case Tab1.Name
                    lobjGrid = vsfFbData2
                Case Else
                    Exit Sub
            End Select
            
            '@一覧をｺﾋﾟｰする
            'With vsfFbData
            With lobjGrid
                
                '@行ﾙｰﾌﾟ
                For llngRowCnt = 0 To .Rows.Count - 1
                    
                    '@列ﾙｰﾌﾟ
                    For llngColCnt = 0 To .Cols.Count - 1
                        
                        '@文字列編集変数に値をｾｯﾄ
                        lstrWk = .GetData(llngRowCnt, llngColCnt)
                        
                        '@最終列の場合Tabいらない
                        If llngColCnt = .Cols.Count - 1 Then
                            '@ｺﾋﾟｰ文字列作成
                            lstrRET = lstrRET & lstrWk
                        Else
                            '@ｺﾋﾟｰ文字列作成
                            lstrRET = lstrRET & lstrWk & vbTab
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
            Call publngMsgBoxInfo(pstrDMsg, vbInformation, frmxxEN0230.Instance.Text, True, 16)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdCopy_Click"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdClipPaste_Click
    '機　能：ｸﾘｯﾌﾟﾎﾞｰﾄﾞ貼付
    '引　数：なし
    '戻り値：
    '作成日：2017/01/26 (Thu) 12:53:51 T.Oide
    '更新日：2024/02/14 (Wed) 17:12:00 T.Oide
    '備　考：
    Private Sub cmdClipPaste_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClipPaste.Click

        Dim lstrDataLine()          As String       '1行分の文字列

        Try
            'クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@1行のﾃﾞｰﾀを取得(line(0)～(8)に1行分のﾃﾞｰﾀがTab区切りで入っている状態
            lstrDataLine = Split(Clipboard.GetText, vbCrLf)
            
            '@選択ﾀﾌﾞ別処理
            Select Case tabRecipe.SelectedTab.Name
                
				'合わせﾊﾟﾗﾒｰﾀ
                Case Tab0.Name

                    'ｸﾘｯﾌﾟﾎﾞｰﾄﾞの中身をﾁｪｯｸ(ﾁｪｯｸNGの場合は処理中止)
                    If prvClipCheck(lstrDataLine) = False Then
                        Exit Sub
                    End If

					'ｸﾘｯﾌﾟﾎﾞｰﾄﾞ貼付け(合せ)
					Call prvClipPaste(vsfFbData, lstrDataLine)

                '露光ﾊﾟﾗﾒｰﾀﾀﾌﾞ
                Case Tab1.Name

                    'ｸﾘｯﾌﾟﾎﾞｰﾄﾞの中身をﾁｪｯｸ(ﾁｪｯｸNGの場合は処理中止)
                    If prvClipCheck2(lstrDataLine) = False Then
                        Exit Sub
                    End If

					'ｸﾘｯﾌﾟﾎﾞｰﾄﾞ貼付け(露光)
					Call prvClipPaste(vsfFbData2, lstrDataLine)
				
				'ﾊﾟﾗﾒｰﾀｺﾋﾟｰ
				Case Tab2.Name

					'ｸﾘｯﾌﾟﾎﾞｰﾄﾞの中身をﾁｪｯｸ(ﾁｪｯｸNGの場合は処理中止)
					lstrDataLine = Split(Clipboard.GetText, vbCrLf)
                    If prvClipCheckCopy(lstrDataLine) = False Then
                        Exit Sub
                    End If

                    'ｸﾘｯﾌﾟﾎﾞｰﾄﾞ貼付け(ﾊﾟﾗﾒｰﾀｺﾋﾟｰ)
					Call prvClipPasteParaCopy(vsfRecipeCopy, lstrDataLine)

                Case Else

                    Exit Sub

            End Select
                       
            '@ボタン有効/無効制御
            Call prvCmdButton_Chk()
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClipPaste_Click"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdLeft_Click
    '機　能：左ｽｸﾛｰﾙﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:32:06 N.Kasai
    '更新日：2007/07/06 (Fri) 13:57:13 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 13:57:13 N.Kasai  ｸﾞﾘｯﾄﾞ共通
    Private Sub cmdLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@左ｽｸﾛｰﾙﾎﾞﾀﾝ制御
            Call pubVsfCmdLeft(vsfFbDataList, cmdLeft, cmdRight)
            
            '@ﾌｫｰｶｽを常に入力可能ｸﾞﾘｯﾄﾞへ
            Call pubSetFocus(vsfFbData)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLeft_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLeft2_Click
    '機　能：左ｽｸﾛｰﾙﾎﾞﾀﾝ(露光)
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:27:50 N.Kasai
    '更新日：2007/09/18 (Tue) 10:27:50
    '備　考：
    Private Sub cmdLeft2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft2.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@左ｽｸﾛｰﾙﾎﾞﾀﾝ制御
            Call pubVsfCmdLeft(vsfFbDataList2, cmdLeft2, cmdRight2)
            
            '@ﾌｫｰｶｽを常に入力可能ｸﾞﾘｯﾄﾞへ
            Call pubSetFocus(vsfFbData2)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLeft2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：cmdRight_Click
    '機　能：右ｽｸﾛｰﾙﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:32:17 N.Kasai
    '更新日：2007/07/06 (Fri) 13:56:25 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 13:56:25 N.Kasai  ｸﾞﾘｯﾄﾞ共通
    Private Sub cmdRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@右ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            Call pubVsfCmdRight(vsfFbDataList, cmdLeft, cmdRight)
            
            '@ﾊｲﾗｲﾄ表示
            vsfFbData.Select(1, 0)
            
            '@ﾌｫｰｶｽを常に入力可能ｸﾞﾘｯﾄﾞへ
            Call pubSetFocus(vsfFbData)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRight_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRight2_Click
    '機　能：ｽｸﾛｰﾙﾎﾞﾀﾝ(露光)
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:28:23 N.Kasai
    '更新日：2007/09/18 (Tue) 10:28:23
    '備　考：
    Private Sub cmdRight2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight2.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@右ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            Call pubVsfCmdRight(vsfFbDataList2, cmdLeft2, cmdRight2)
            
            '@ﾊｲﾗｲﾄ表示
            vsfFbData2.Select(1, 0)
            
            '@ﾌｫｰｶｽを常に入力可能ｸﾞﾘｯﾄﾞへ
            Call pubSetFocus(vsfFbData2)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRight2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:32:29 N.Kasai
    '更新日：2006/02/23 (Thu) 13:32:29
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm                 As Boolean              '開放結果格納
        Dim ltypPhotoFbDataListAns      As PhotoFbDataListAns   'ﾌｫﾄF/Bﾃﾞｰﾀ格納構造体(合せ)
        Dim ltypPhotoFbDataList2Ans     As PhotoFbDataList2Ans  'ﾌｫﾄF/Bﾃﾞｰﾀ格納構造体(露光)
        Dim ltypMasRecipeNameList       As MasRecipeNameList    'ﾚｼﾋﾟ応答格納構造体
        Dim ltypRecipeInfo              As RecipeInfo           'ﾚｼﾋﾟ一覧検索（ﾌｫﾄF/Bﾃﾞｰﾀ）
        
        Try
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@配列の解放（ｿｰﾄ用）
            If Not IsNothing(mtypChgSort.typChgSortList) Then
                mtypChgSort.typChgSortList.Clear()
                mtypChgSort.typChgSortList = Nothing
            End If
            
            '@構造体の初期化
            ptypPhotoFbDataListAns = ltypPhotoFbDataListAns
            mtypPhotoFbDataList2Ans = ltypPhotoFbDataList2Ans
            mtypMasRecipeNameList = ltypMasRecipeNameList
            mtypMasRecipeNameList2 = ltypMasRecipeNameList

            ptypRecipeInfo = ltypRecipeInfo
            
            '@ActInitフラグの判定
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

    '関数名：tabRecipe_Click
    '機　能：ﾚｼﾋﾟﾊﾟﾗﾒｰﾀﾀﾌﾞｸﾘｯｸ
    '引　数：PreviousTab：ﾀﾌﾞｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2007/08/31 (Fri) 10:10:40 N.Kasai
    '更新日：2007/08/31 (Fri) 10:10:40
    '備　考：
    Private Sub tabRecipe_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tabRecipe.SelectedIndexChanged

        Try
            'クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@選択ﾀﾌﾞ別処理
            Select Case tabRecipe.SelectedTab.Name
                '@合わせﾊﾟﾗﾒｰﾀ
                Case Tab0.Name
                    fra0.Enabled = True		'合わせﾌﾚｰﾑ有効
                    fra1.Enabled = False	'露光ﾌﾚｰﾑ無効
					fra2.Enabled = False	'ｺﾋﾟｰﾌﾚｰﾑ無効

                '@露光ﾊﾟﾗﾒｰﾀﾀﾌﾞ
                Case Tab1.Name
					fra0.Enabled = False	'合わせﾌﾚｰﾑ無効
                    fra1.Enabled = True		'露光ﾌﾚｰﾑ有効
					fra2.Enabled = False	'ｺﾋﾟｰﾌﾚｰﾑ無効

				Case Tab2.Name
					fra0.Enabled = False	'合わせﾌﾚｰﾑ無効
					fra1.Enabled = False	'露光ﾌﾚｰﾑ無効
					fra2.Enabled = True		'ｺﾋﾟｰﾌﾚｰﾑ有効

            End Select
            
            '@共通ｺﾏﾝﾄﾞﾎﾞﾀﾝﾁｪｯｸ
            Call prvCmdButton_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "tabRecipe_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtComments_Change
    '機　能：ｺﾒﾝﾄ変更
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/31 (Fri) 09:08:02 N.Kasai
    '更新日：2007/08/31 (Fri) 09:08:02
    '備　考：
    Private Sub txtComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.Change

        Dim llngNowByte     As Integer  'ｺﾒﾝﾄ桁数

        Try
            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtComments.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)

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

    '関数名：txtComments2_Change
    '機　能：ｺﾒﾝﾄ入力(露光)
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:29:03 N.Kasai
    '更新日：2007/09/18 (Tue) 10:29:03
    '備　考：
    Private Sub txtComments2_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments2.Change

        Dim llngNowByte     As Integer  'ｺﾒﾝﾄ桁数

        Try
            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtComments2.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount2.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments2, CMlngMaxDispRow, cmdCommentUp2, cmdCommentDown2)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments2_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_GotFocus
    '機　能：ｺﾒﾝﾄﾌｫｰｶｽ設定
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/31 (Fri) 09:08:14 N.Kasai
    '更新日：2007/08/31 (Fri) 09:08:14
    '備　考：
    Private Sub txtComments_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.Enter

        Try
            '@ｸﾞﾘｯﾄﾞからｺﾒﾝﾄにﾌｫｰｶｽ移動した場合
            '@ﾌｫﾝﾄｻｲｽﾞがｸﾞﾘｯﾄﾞのﾌｫﾝﾄｻｲｽﾞに書き換わる
            '@一度、OSに制御を戻し、ﾌｫﾝﾄを再設定する。
            'DoEvents
            
            '@ﾌｫﾝﾄｻｲｽﾞ再設定
            With txtComments
                .Font = New Font("ＭＳ ゴシック", 15.75, .Font.Style, .Font.Unit)
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments2_GotFocus
    '機　能：ｺﾒﾝﾄGotFocus
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:29:39 N.Kasai
    '更新日：2007/09/18 (Tue) 10:29:39
    '備　考：
    Private Sub txtComments2_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments2.Enter

        Try
            '@ｸﾞﾘｯﾄﾞからｺﾒﾝﾄにﾌｫｰｶｽ移動した場合
            '@ﾌｫﾝﾄｻｲｽﾞがｸﾞﾘｯﾄﾞのﾌｫﾝﾄｻｲｽﾞに書き換わる
            '@一度、OSに制御を戻し、ﾌｫﾝﾄを再設定する。
            'DoEvents
            
            '@ﾌｫﾝﾄｻｲｽﾞ再設定
            With txtComments2
                .Font = New Font("ＭＳ ゴシック", 15.75, .Font.Style, .Font.Unit)
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments2_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_KeyUp
    '機　能：ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:47:07 N.Kasai
    '更新日：2005/11/29 (Tue) 13:47:07
    '備　考：
    Private Sub txtComments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComments.KeyUp

        Try
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComments, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
            
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

    '関数名：txtComments2_KeyUp
    '機　能：ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:30:09 N.Kasai
    '更新日：2007/09/18 (Tue) 10:30:09
    '備　考：
    Private Sub txtComments2_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComments2.KeyUp

        Try
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComments2, CMlngMaxDispRow, cmdCommentUp2, cmdCommentDown2)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments2_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：txtComments_MouseUp
    '機　能：ﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:48:44 N.Kasai
    '更新日：2005/11/29 (Tue) 13:48:44
    '備　考：
    Private Sub txtComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtComments.MouseUp

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown, e.Button)
            
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

    '関数名：txtComments2_MouseUp
    '機　能：ﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：ｙ座標
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:31:38 N.Kasai
    '更新日：2007/09/18 (Tue) 10:31:38
    '備　考：
    Private Sub txtComments2_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtComments2.MouseUp

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments2, CMlngMaxDispRow, cmdCommentUp2, cmdCommentDown2, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments2_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentUp_Click
    '機　能：▲ﾎﾞﾀﾝｸﾘｯｸ処理(合せ)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:38:43 N.Kasai
    '更新日：2005/12/02 (Fri) 16:02:04 N.Kasai
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
            Call pubtxtCmdUp_Proc(txtComments, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)

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

    '関数名：cmdCommentUp2_Click
    '機　能：▲ﾎﾞﾀﾝｸﾘｯｸ処理(露光)
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:32:44 N.Kasai
    '更新日：2007/09/18 (Tue) 10:32:44
    '備　考：
    Private Sub cmdCommentUp2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentUp2.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtComments2, CMlngMaxDispRow, cmdCommentUp2, cmdCommentDown2)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommentUp2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentDOWN_Click
    '機　能：▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:39:56 N.Kasai
    '更新日：2004/11/18 (Thu) 11:39:56
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
            Call pubtxtCmdDown_Proc(txtComments, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommentDOWN_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentDown2_Click
    '機　能：▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:33:53 N.Kasai
    '更新日：2007/09/18 (Tue) 10:33:53
    '備　考：
    Private Sub cmdCommentDown2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentDown2.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtComments2, CMlngMaxDispRow, cmdCommentUp2, cmdCommentDown2)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommentDOWN2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtRecipeID_Change
    '機　能：ﾚｼﾋﾟID変更
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/31 (Fri) 09:01:17 N.Kasai
    '更新日：2007/08/31 (Fri) 09:01:17
    '備　考：
    Private Sub txtRecipeID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtRecipeID.Change

        Try
            '@ｸﾞﾘｯﾄﾞ簡易初期化
            Call prvGrid_Init()
            
            '@ﾚｼﾋﾟIDｸﾘｱ
            mstrRecipeID = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtRecipeID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：txtRecipeID_Validate
    '機　能：ﾚｼﾋﾟValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/08/31 (Fri) 09:01:43 N.Kasai
    '更新日：2007/08/31 (Fri) 09:01:43
    '備　考：
    Private Sub txtRecipeID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtRecipeID.Validating
        
        Dim lblnAns     As Boolean  '戻り値
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            If txtRecipeID.Text = vbNullString Then
                If ActiveControl.Name = txtRecipeID.Name Then
                    '@1stﾌｫﾄ号機ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbReferenceWP)
                End If
                Exit Sub
            End If
           
            '@ﾚｼﾋﾟID整合性ﾁｪｯｸ
            lblnAns = prvblnRecipeData_Chk
            '@ｴﾗｰありの場合
            If lblnAns = False Then
                '@"<TRM0MW>$$レシピIDの設定に不備があります。設定を見直して下さい。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000M)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                If Me.ActiveControl.Name = tabRecipe.Name Then
                    mblnTabSelectEnabled = False
                    sender.Focus()
                Else
                    e.Cancel = True
                End If

                If ActiveControl.Name = txtRecipeID.Name Then
                    '@ﾚｼﾋﾟIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtRecipeID)
                End If
            
                Exit Sub
            End If
            
            '@ﾚｼﾋﾟIDが変更された場合
            If mstrRecipeID <> txtRecipeID.Text Then
                '@ｺﾝﾎﾞﾁｪｯｸ
                Call prvComb_Chk()
            End If
            '@ﾚｼﾋﾟID退避
            mstrRecipeID = txtRecipeID.Text
            
            '@ﾃﾞｰﾀｸﾞﾘｯﾄﾞが使用可能の場合
            If vsfFbData.Enabled = True Then
                If ActiveControl.Name = txtRecipeID.Name Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfFbData)
                End If
            Else
                '@1stﾌｫﾄ号機ｺﾝﾎﾞが使用可能の場合
                If cmbReferenceWP.Enabled = True Then
                    If ActiveControl.Name = txtRecipeID.Name Then
                        '@1stﾌｫﾄ号機ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbReferenceWP)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtRecipeID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：txtRecipeID2_Change
    '機　能：ﾚｼﾋﾟID変更
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/31 (Fri) 09:01:17 N.Kasai
    '更新日：2007/08/31 (Fri) 09:01:17
    '備　考：
    Private Sub txtRecipeID2_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtRecipeID2.Change

        Try
            '@ｸﾞﾘｯﾄﾞ簡易初期化
            Call prvGrid_Init()
            
            '@ﾚｼﾋﾟIDｸﾘｱ
            mstrRecipeID2 = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtRecipeID2_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：txtRecipeID2_Validate
    '機　能：ﾚｼﾋﾟValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/08/31 (Fri) 09:01:43 N.Kasai
    '更新日：2007/08/31 (Fri) 09:01:43
    '備　考：
    Private Sub txtRecipeID2_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtRecipeID2.Validating
        
        Dim lblnAns     As Boolean  '戻り値
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            If txtRecipeID2.Text = vbNullString Then
                '@ﾃﾞｰﾀｸﾞﾘｯﾄﾞが使用可能の場合
                If vsfFbData2.Enabled = True Then
                    If ActiveControl.Name = txtRecipeID2.Name Then
                        '@次項目にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfFbData2)
                    End If
                Else
                    If ActiveControl.Name = txtRecipeID2.Name Then
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                Exit Sub
            End If
           
            '@ﾚｼﾋﾟID整合性ﾁｪｯｸ
            lblnAns = prvblnRecipeData2_Chk
            '@ｴﾗｰありの場合
            If lblnAns = False Then
                '@"<TRM0MW>$$レシピIDの設定に不備があります。設定を見直して下さい。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000M)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                If Me.ActiveControl.Name = tabRecipe.Name Then
                    mblnTabSelectEnabled = False
                    sender.Focus()
                Else
                    e.Cancel = True
                End If

                If ActiveControl.Name = txtRecipeID2.Name Then
                    '@ﾚｼﾋﾟIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtRecipeID2)
                End If

                Exit Sub
            End If
            
            '@ﾚｼﾋﾟIDが変更された場合
            If mstrRecipeID2 <> txtRecipeID2.Text Then
                '@ｺﾝﾎﾞﾁｪｯｸ
                Call prvComb_Chk()
            End If
            '@ﾚｼﾋﾟID退避
            mstrRecipeID2 = txtRecipeID2.Text
            
            
            '@ﾃﾞｰﾀｸﾞﾘｯﾄﾞが使用可能の場合
            If vsfFbData2.Enabled = True Then
                If ActiveControl.Name = txtRecipeID2.Name Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfFbData2)
                End If
            Else
                If ActiveControl.Name = txtRecipeID2.Name Then
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtRecipeID2_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：vsfFbData_BeforeEdit
    '機　能：ｸﾞﾘｯﾄﾞ編集前
    '引　数：Row：行
    '　　　：Col：列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/03/24 (Fri) 16:28:20 N.Kasai
    '更新日：2006/03/24 (Fri) 16:28:20
    '備　考：
    Private Sub vsfFbData_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfFbData.SetupEditor

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbData.Rows.Count <= vsfFbData.Rows.Fixed Then
                Return
            End If

                '@見出し以外
                If e.Row > 0 Then
                    With vsfFbData
                        '@入力最大桁数
                        CType(.Editor, Textbox).MaxLength = CMlngInputNDataMaxByte
                        '@変更前文字列を取得
                        mstrBeforeEditString = .GetData(e.Row, e.Col)
                    End With
                End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbData_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbData2_BeforeEdit
    '機　能：ｸﾞﾘｯﾄﾞ編集前(露光)
    '引　数：Row：行
    '　　　：Col：列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:35:30 N.Kasai
    '更新日：2007/09/18 (Tue) 10:35:30
    '備　考：
    Private Sub vsfFbData2_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfFbData2.SetupEditor

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbData2.Rows.Count <= vsfFbData2.Rows.Fixed Then
                Return
            End If

                '@見出し以外
                If e.Row > 0 AndAlso e.Col > 0 Then
                    With vsfFbData2
                        '@入力最大桁数
                        CType(.Editor, Textbox).MaxLength = CMlngInputNDataMaxByte
                        '@変更前文字列を取得
                        mstrBeforeEditString = .GetData(e.Row, e.Col)
                    End With
                End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbData2_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbData_EnterCell
    '機　能：ｸﾞﾘｯﾄﾞEnterCell
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/31 (Fri) 09:02:31 N.Kasai
    '更新日：2017/01/24 (Tue) 18:55:19 T.Oide
    '備　考：
    Private Sub vsfFbData_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFbData.EnterCell
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbData.Rows.Count <= vsfFbData.Rows.Fixed Then
                Return
            End If
            
           '@patch分割設対象外 or 分割なしか(1は分割なし、0はありえないはずだが一応)
            If ptypPhotoFbDataListAns.strPatchDivideNumRecipe = vbNullString Or _
               ptypPhotoFbDataListAns.strPatchDivideNumRecipe = "0" Or _
               ptypPhotoFbDataListAns.strPatchDivideNumRecipe = "1" Then
            
                '@ﾃﾞｰﾀ入力ｸﾞﾘｯﾄﾞ
                With vsfFbData
                    If .Row > 0 Then
                        With txtComments
                            If .Locked = True Then
                                .Text = vbNullString
                                .Locked = False
                                
                                '@ﾊﾞｯｸｶﾗｰの変更を行う為に記述しています。
                                '@ｺﾒﾝﾄにﾌｫｰｶｽがある場合ﾊﾞｯｸｶﾗｰの変更ができません。
                                'DoEvents
                                .BackColor = Color.White
                                .GotBackColor = Color.White
                                lblLengthCount.Visible = True
                            End If
                        End With
                    End If
                
                End With
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbData_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbData2_EnterCell
    '機　能：ｸﾞﾘｯﾄﾞEnterCell
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:36:33 N.Kasai
    '更新日：2007/09/18 (Tue) 10:36:33
    '備　考：
    Private Sub vsfFbData2_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFbData2.EnterCell
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbData2.Rows.Count <= vsfFbData2.Rows.Fixed Then
                Return
            End If
            
            '@ﾃﾞｰﾀ入力ｸﾞﾘｯﾄﾞ
            With vsfFbData2
                If .Row > 0 Then
                    With txtComments2
                        If .Locked = True Then
                            .Text = vbNullString
                            .Locked = False
                            
                            '@ﾊﾞｯｸｶﾗｰの変更を行う為に記述しています。
                            '@ｺﾒﾝﾄにﾌｫｰｶｽがある場合ﾊﾞｯｸｶﾗｰの変更ができません。
                            'DoEvents
                            .BackColor = Color.White
                            .GotBackColor = Color.White
                            lblLengthCount2.Visible = True
                        End If
                    End With
                End If
            
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbData2_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbData2_AfterEdit
    '機　能：ｸﾞﾘｯﾄﾞAfterEdit
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:39:42 N.Kasai
    '更新日：2007/09/18 (Tue) 10:39:42
    '備　考：
    Private Sub vsfFbData2_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfFbData2.AfterEdit

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbData2.Rows.Count <= vsfFbData2.Rows.Fixed Then
                Return
            End If
            
            With vsfFbData2
                Select Case e.Col
                    '@№
                    Case CMlngvsfList2ColNo
                        '@編集不可
                         .AllowEditing = False
                    '@ﾊﾟﾗﾒｰﾀ値の場合
                    Case Else
                        'NSYS 編集内容が数値の場合
                        If IsNumeric(.GetData(e.Row, e.Col)) Then
                            .SetData(e.Row, e.Col, CDbl(.GetData(e.Row, e.Col)))
                        End If

                        '@編集可
                        .AllowEditing = True
                End Select
            
                '@変更内容の確認
                If mstrBeforeEditString <> CStr(.GetData(e.Row, e.Col)) Then
                    '@編集色へ変更
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngEditColor")
                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngEditColor)
                    Dim cellRange As CellRange = .GetCellRange(1, e.Col)
                    cellRange.Style = newStyle
                End If
             End With
            
            '@共通ｺﾏﾝﾄﾞﾎﾞﾀﾝﾁｪｯｸ
            Call prvCmdButton_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbData2_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbDataList_AfterRowColChange
    '機　能：ﾃﾞｰﾀﾘｽﾄ行変更処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '戻り値：なし
    '作成日：2006/03/13 (Mon) 11:24:09 N.Kasai
    '更新日：2017/01/24 (Tue) 18:27:42 T.Oide
    '備　考：
    Private Sub vsfFbDataList_AfterRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfFbDataList.AfterRowColChange
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbDataList.Rows.Count <= vsfFbDataList.Rows.Fixed Then
                Return
            End If
            
            '@ﾊﾟｯﾁ分割以外か
            If ptypPhotoFbDataListAns.strPatchDivideNumRecipe = vbNullString Or _
               ptypPhotoFbDataListAns.strPatchDivideNumRecipe = "0" Or _
               ptypPhotoFbDataListAns.strPatchDivideNumRecipe = "1" Then

                '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
                If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                    '@ﾃﾞｰﾀ表示【転写】
                    Call prvvsfFbData_Disp()
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbDataList_AfterRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：vsfFbDataList2_AfterRowColChange
    '機　能：ｸﾞﾘｯﾄﾞ行変更
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:41:32 N.Kasai
    '更新日：2017/01/24 (Tue) 18:22:07 T.Oide
    '備　考：
    Private Sub vsfFbDataList2_AfterRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfFbDataList2.AfterRowColChange
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbDataList2.Rows.Count <= vsfFbDataList2.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ﾃﾞｰﾀ表示【転写】
                Call prvvsfFbData2_Disp()
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbDataList_AfterRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：vsfFbDataList_AfterUserResize
    '機　能：ｸﾞﾘﾄﾞｻｲｽﾞ変更
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:33:02 N.Kasai
    '更新日：2006/02/23 (Thu) 13:33:02
    '備　考：
    Private Sub vsfFbDataList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfFbDataList.AfterResizeColumn, vsfFbDataList.AfterResizeRow

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbDataList.Rows.Count <= vsfFbDataList.Rows.Fixed Then
                Return
            End If
            
            '@列幅変更フラグ（変更）
            mtypChgSort.blnChgWidth = True
            
            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御（ｸﾞﾘｯﾄﾞ共通化関数）
            Call pubCmdLREnable_Set(vsfFbDataList, cmdLeft, cmdRight)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbDataList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbDataList2_AfterUserResize
    '機　能：ｸﾞﾘｯﾄﾞﾕｰｻﾞﾘｻｲｽﾞ
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:42:56 N.Kasai
    '更新日：2007/09/18 (Tue) 10:42:56
    '備　考：
    Private Sub vsfFbDataList2_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfFbDataList2.AfterResizeColumn, vsfFbDataList2.AfterResizeRow

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbDataList2.Rows.Count <= vsfFbDataList2.Rows.Fixed Then
                Return
            End If
            
            '@列幅変更フラグ（変更）
            mtypChgSort2.blnChgWidth = True
            
            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御（ｸﾞﾘｯﾄﾞ共通化関数）
            Call pubCmdLREnable_Set(vsfFbDataList2, cmdLeft2, cmdRight2)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbDataList2_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbDataList_BeforeRowColChange
    '機　能：行列変更前処理
    '引　数：OldRow：旧行番号
    '　　　：OldCol：旧列番号
    '　　　：NewRow：新行番号
    '　　　：NewCol：新列番号
    '　　　：Cancel：ｷｬﾝｾﾙt値
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:33:21 N.Kasai
    '更新日：2006/02/23 (Thu) 13:33:21
    '備　考：
    Private Sub vsfFbDataList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfFbDataList.BeforeRowColChange
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbDataList.Rows.Count <= vsfFbDataList.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（№）
                mtypChgSort.strKey = vsfFbDataList.GetData(e.NewRange.r1, CMlngvsfListColNo)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbDataList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbDataList2_BeforeRowColChange
    '機　能：行変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:43:50 N.Kasai
    '更新日：2007/09/18 (Tue) 10:43:50
    '備　考：
    Private Sub vsfFbDataList2_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfFbDataList2.BeforeRowColChange
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbDataList2.Rows.Count <= vsfFbDataList2.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（№）
                mtypChgSort2.strKey = vsfFbDataList2.GetData(e.NewRange.r1, CMlngvsfList2ColNo)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbDataList2_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSearch_Click
    '機　能：ﾌｫﾄFBﾃﾞｰﾀ取得(合せ)
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 15:28:14 N.Kasai
    '更新日：2017/03/10 (Fri) 17:08:41 T.Oide
    '備　考：
    '　　　：2006/04/04 (Tue) 15:49:35 N.Kasai      ﾚｼﾋﾟID追加
    '　　　：2006/06/20 (Tue) 13:22:04 N.Kojima     応答格納構造体を変更。(R3-4指摘)
    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click

        Dim lblnAns                 As Boolean              '戻り値
        Dim lstrEventName           As String               'ﾚｽﾎﾟﾝｽ用(ｲﾍﾞﾝﾄ名)
        Dim ltypPhotoFbDataListReq  As PhotoFbDataListReq   '要求格納
        Dim ltypPhotoFbDataListAns  As PhotoFbDataListAns   '構造体ｸﾘｱ用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmdLotSearch_Click"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@情報取得日時初期化
            lblNowDate.Text = vbNullString
            '@該当件数ｸﾘｱ
            lblLotCnt.Text = vbNullString
            'Shot分離
            lblShotSeparateFlag.Text = vbNullString
            
            '@変数初期化
            mstrEntryTime = vbNullString
            
            '@要求格納
            With ltypPhotoFbDataListReq
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstreq__photofbdatalistVer
                '@処理区分
                .strSbID = pstrSBID
                '@ﾌｫﾄ号機
                cmbWp.ValueCol = CMlngCmbGridCol1
                .strWpID = cmbWp.Value
                '@ﾚｼﾋﾟID
                .strRecipeId = txtRecipeID.Text
                '基準ﾌｫﾄ号機
                cmbReferenceWP.ValueCol = CMlngCmbGridCol1
                .strReferencePhotoWpID = cmbReferenceWP.Value
            End With
            
            '@【ﾌｫﾄF/Bﾃﾞｰﾀ取得】
            ptypPhotoFbDataListAns = ltypPhotoFbDataListAns     '@取得前に構造体ｸﾘｱ
            lblnAns = pubblnPhotoFbDataList_Sel(ltypPhotoFbDataListReq, ptypPhotoFbDataListAns)
            
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                
                '@ｸﾞﾘｯﾄﾞ初期化
                Call prvGrid_Init()
                
                Exit Sub
            End If
            
            FbDateInitFlg = True

            '@ｸﾞﾘｯﾄﾞ初期化
            Call prvGrid_Init()

            FbDateInitFlg = False

            '@検索済ﾌﾗｸﾞON
            mblnAfterSerchFlag = True
            '@ﾌｫﾄF/Bﾃﾞｰﾀ表示(patch分割は指定しない)
            Call prvvsfFbDataList_Disp(CPlngPatchNoNasi)
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
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

    '関数名：cmdSearch2_Click
    '機　能：ﾌｫﾄFBﾃﾞｰﾀ取得(露光)
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:45:28 N.Kasai
    '更新日：2007/09/18 (Tue) 10:45:28
    '備　考：
    Private Sub cmdSearch2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch2.Click

        Dim lblnAns                 As Boolean              '戻り値
        Dim lstrEventName           As String               'ﾚｽﾎﾟﾝｽ用(ｲﾍﾞﾝﾄ名)
        Dim ltypPhotoFbDataList2Req As PhotoFbDataList2Req  '要求格納
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmdLotSearch2_Click"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@情報取得日時初期化
            lblNowDate2.Text = vbNullString
            '@該当件数ｸﾘｱ
            lblLotCnt2.Text = vbNullString
            
            '@変数初期化
            mstrEntryTime2 = vbNullString
            
            '@要求格納
            With ltypPhotoFbDataList2Req
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstreq__photofbdatalist2Ver
                '@処理区分
                .strSbID = pstrSBID
                '@ﾌｫﾄ号機
                cmbWP2.ValueCol = CMlngCmbGridCol1
                .strWpID = cmbWP2.Value
                '@ﾚｼﾋﾟID
                .strRecipeId = txtRecipeID2.Text
            End With
            
            '@【ﾌｫﾄF/Bﾃﾞｰﾀ取得】
            lblnAns = pubblnPhotoFbDataList2_Sel(ltypPhotoFbDataList2Req, mtypPhotoFbDataList2Ans)
            
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                
                '@ｸﾞﾘｯﾄﾞ初期化
                Call prvGrid_Init()
                
                Exit Sub
            End If
            
            FbDate2InitFlg = True

            '@ｸﾞﾘｯﾄﾞ初期化
            Call prvGrid_Init()

            FbDate2InitFlg = False

            '@検索済ﾌﾗｸﾞON
            mblnAfterSerch2Flag = True
            '@ﾌｫﾄF/Bﾃﾞｰﾀ表示
            Call prvvsfFbDataList2_Disp()
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
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

    '関数名：cmdRecipe_Click
    '機　能：ﾚｼﾋﾟ検索
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/31 (Fri) 08:58:54 N.Kasai
    '更新日：2007/08/31 (Fri) 08:58:54
    '備　考：
    Private Sub cmdRecipe_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRecipe.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@引渡し構造体へ格納
            With ptypRecipeInfo
                .strSearchRecipeID = txtRecipeID.Text
                .typMasRecipeNameList = mtypMasRecipeNameList
                .strResultRecipeID = vbNullString
            End With

            '@ﾛｯﾄｺﾒﾝﾄ表示ﾌｫｰﾑを開く
            frmxxEN01U1.Instance.ShowDialog(Me)
            frmxxEN01U1.Instance = Nothing
            
            '@検索結果判定
            If ptypRecipeInfo.strResultRecipeID <> vbNullString Then
                '@検索結果を反映する。
                txtRecipeID.Text = ptypRecipeInfo.strResultRecipeID
                
                '@ﾚｼﾋﾟID退避
                mstrRecipeID = txtRecipeID.Text

                '@ﾌｫｰｶｽの移動(1stﾌｫﾄ号機)
                Call pubSetFocus(cmbReferenceWP)
                '@ｺﾝﾎﾞﾁｪｯｸ
                Call prvComb_Chk()
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRecipe_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRecipe2_Click
    '機　能：ﾚｼﾋﾟ検索
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:46:37 N.Kasai
    '更新日：2007/09/18 (Tue) 10:46:37
    '備　考：
    Private Sub cmdRecipe2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRecipe2.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@引渡し構造体へ格納
            With ptypRecipeInfo
                .strSearchRecipeID = txtRecipeID2.Text
                .typMasRecipeNameList = mtypMasRecipeNameList2
                .strResultRecipeID = vbNullString
            End With

            '@ﾛｯﾄｺﾒﾝﾄ表示ﾌｫｰﾑを開く
            frmxxEN01U1.Instance.ShowDialog(Me)
            frmxxEN01U1.Instance = Nothing
            
            '@検索結果判定
            If ptypRecipeInfo.strResultRecipeID <> vbNullString Then
                '@検索結果を反映する。
                txtRecipeID2.Text = ptypRecipeInfo.strResultRecipeID
                
                '@ﾚｼﾋﾟID退避
                mstrRecipeID2 = txtRecipeID2.Text
                
                '@ｺﾝﾎﾞﾁｪｯｸ
                Call prvComb_Chk()
                
                If vsfFbData2.Enabled = True Then
                    '@ﾌｫｰｶｽの移動(ﾃﾞｰﾀｸﾞﾘｯﾄﾞ)
                    Call pubSetFocus(vsfFbData2)
                Else
                    '@ﾌｫｰｶｽの移動(閉じる)
                    Call pubSetFocus(cmdClose)
                End If
                
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRecipe2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：上ｽｸﾛｰﾙﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:34:00 N.Kasai
    '更新日：2006/02/23 (Thu) 13:34:00
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

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdUp(vsfFbDataList, cmdUP, cmdDown)
            
            '@ﾊｲﾗｲﾄ表示
             vsfFbData.Select(1, 0)
            
            '@ﾌｫｰｶｽを常に入力可能ｸﾞﾘｯﾄﾞへ
            Call pubSetFocus(vsfFbData)

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

    '関数名：cmdUp2_Click
    '機　能：▲ｽｸﾛｰﾙ
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:47:16 N.Kasai
    '更新日：2007/09/18 (Tue) 10:47:16
    '備　考：
    Private Sub cmdUp2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp2.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdUp(vsfFbDataList2, cmdUP2, cmdDown2)
            
            '@ﾊｲﾗｲﾄ表示
             vsfFbData2.Select(1, 0)
            
            '@ﾌｫｰｶｽを常に入力可能ｸﾞﾘｯﾄﾞへ
            Call pubSetFocus(vsfFbData2)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：下ｽｸﾛｰﾙﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:34:13 N.Kasai
    '更新日：2006/02/23 (Thu) 13:34:13
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
            
            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdDown(vsfFbDataList, cmdUP, cmdDown)
            
            '@ﾊｲﾗｲﾄ表示
            vsfFbData.Select(1, 0)
            
            '@ﾌｫｰｶｽを常に入力可能ｸﾞﾘｯﾄﾞへ
            Call pubSetFocus(vsfFbData)

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

    '関数名：cmdDown2_Click
    '機　能：▼ﾎﾞﾀﾝｽｸﾛｰﾙ
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:47:40 N.Kasai
    '更新日：2007/09/18 (Tue) 10:47:40
    '備　考：
    Private Sub cmdDown2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown2.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdDown(vsfFbDataList2, cmdUP2, cmdDown2)
            
            '@ﾊｲﾗｲﾄ表示
            vsfFbData2.Select(1, 0)
            
            '@ﾌｫｰｶｽを常に入力可能ｸﾞﾘｯﾄﾞへ
            Call pubSetFocus(vsfFbData2)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown2_Click"
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
    '作成日：2006/02/23 (Thu) 13:34:35 N.Kasai
    '更新日：2007/07/06 (Fri) 14:32:29 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 14:32:29 N.Kasai  ｸﾞﾘｯﾄﾞ共通
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            Select Case tabRecipe.SelectedTab.Name
            
                Case Tab0.Name
            
                    '@ｸﾞﾘｯﾄﾞｷｰ制御（ｸﾞﾘｯﾄﾞ共通仕様）
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfFbDataList, cmdUP, cmdDown)
                    
                    '@ｸﾞﾘｯﾄﾞｷｰ制御（ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ）
                    Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfFbDataList, cmdLeft, cmdRight)
                    
                    '@ｸﾞﾘｯﾄﾞｷｰ制御（ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ,ｽｸﾛｰﾙﾎﾞﾀﾝの有無）
                    Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfFbData, , , False)
                    
                Case Tab1.Name
                
                    '@ｸﾞﾘｯﾄﾞｷｰ制御（ｸﾞﾘｯﾄﾞ共通仕様）
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfFbDataList2, cmdUP2, cmdDown2)
                    
                    '@ｸﾞﾘｯﾄﾞｷｰ制御（ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ）
                    Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfFbDataList2, cmdLeft2, cmdRight2)
                    
                    '@ｸﾞﾘｯﾄﾞｷｰ制御（ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ,ｽｸﾛｰﾙﾎﾞﾀﾝの有無）
                    Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfFbData2, , , False)
            End Select
            
            '@Key判定
            Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    Select Case ActiveControl.Name
                        Case cmbWp.Name
                        '@ﾌｫﾄ号機の場合
                            '@Validate処理を呼ぶ
                            RemoveHandler cmbWp.Validating, AddressOf cmbWp_Validate
                            Call cmbWp_Validate(cmbWp, New CancelEventArgs(True))
                            AddHandler cmbWp.Validating, AddressOf cmbWp_Validate
                            e.Handled = True
                        Case cmbReferenceWP.Name
                        '@1stﾌｫﾄ号機の場合
                            '@Validate処理を呼ぶ
                            RemoveHandler cmbReferenceWP.Validating, AddressOf cmb1stWP_Validate
                            Call cmb1stWP_Validate(cmbReferenceWP, New CancelEventArgs(True))
                            AddHandler cmbReferenceWP.Validating, AddressOf cmb1stWP_Validate
                        Case txtRecipeID.Name
                        '@ﾚｼﾋﾟID
                            '@Validate処理を呼ぶ
                            RemoveHandler txtRecipeID.Validating, AddressOf txtRecipeID_Validate
                            Call txtRecipeID_Validate(txtRecipeID, New CancelEventArgs(True))
                            AddHandler txtRecipeID.Validating, AddressOf txtRecipeID_Validate
                            
                        Case txtComments.Name
                        '@ｺﾒﾝﾄ
                            Exit Sub
                        
                        Case cmbWP2.Name
                        '@ﾌｫﾄ号機の場合
                            '@Validate処理を呼ぶ
                            RemoveHandler cmbWp2.Validating, AddressOf cmbWp2_Validate
                            Call cmbWp2_Validate(cmbWp2, New CancelEventArgs(True))
                            AddHandler cmbWp2.Validating, AddressOf cmbWp2_Validate
                            e.Handled = True
                            
                        Case txtRecipeID2.Name
                        '@ﾚｼﾋﾟID
                            '@Validate処理を呼ぶ
                            RemoveHandler txtRecipeID2.Validating, AddressOf txtRecipeID2_Validate
                            Call txtRecipeID2_Validate(txtRecipeID2, New CancelEventArgs(True))
                            AddHandler txtRecipeID2.Validating, AddressOf txtRecipeID2_Validate
                            
                        Case txtComments2.Name
                        '@ｺﾒﾝﾄ
                            Exit Sub
                        Case Else
                        '@その他
                            If ActiveControl IsNot vsfFbData.Editor AndAlso ActiveControl IsNot vsfFbData2.Editor Then
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                            End If
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

    '関数名：vsfFbDataList_BeforeSort
    '機　能：ソート前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:35:14 N.Kasai
    '更新日：2006/02/23 (Thu) 13:35:14
    '備　考：
    Private Sub vsfFbDataList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfFbDataList.BeforeSort

        Try
            
            'ソートでRowColChangeを発生しないようにする
            RemoveHandler vsfFbDataList.BeforeRowColChange, AddressOf vsfFbDataList_BeforeRowColChange
            RemoveHandler vsfFbDataList.AfterRowColChange, AddressOf vsfFbDataList_AfterRowColChange

            'NSYS データ行がない場合は処理を抜ける
            If vsfFbDataList.Rows.Count <= vsfFbDataList.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列 [№] ）
            Call pubVsfBeforeSort(vsfFbDataList, CMlngvsfListColNo)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbDataList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbDataList2_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：れrつ
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:48:44 N.Kasai
    '更新日：2007/09/18 (Tue) 10:48:44
    '備　考：
    Private Sub vsfFbDataList2_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfFbDataList2.BeforeSort

        Try
            
            'ソートでRowColChangeを発生しないようにする
            RemoveHandler vsfFbDataList2.BeforeRowColChange, AddressOf vsfFbDataList2_BeforeRowColChange
            RemoveHandler vsfFbDataList2.AfterRowColChange, AddressOf vsfFbDataList2_AfterRowColChange

            'NSYS データ行がない場合は処理を抜ける
            If vsfFbDataList2.Rows.Count <= vsfFbDataList2.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列 [№] ）
            Call pubVsfBeforeSort(vsfFbDataList2, CMlngvsfList2ColNo)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbDataList2_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbDataList_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:35:26 N.Kasai
    '更新日：2006/02/23 (Thu) 13:35:26
    '備　考：
    Private Sub vsfFbDataList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfFbDataList.AfterSort

        Try

            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfFbDataList.BeforeRowColChange, AddressOf vsfFbDataList_BeforeRowColChange
            AddHandler vsfFbDataList.AfterRowColChange, AddressOf vsfFbDataList_AfterRowColChange

            'NSYS データ行がない場合は処理を抜ける
            If vsfFbDataList.Rows.Count <= vsfFbDataList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort
                'NSYS リストを初期化
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                Dim ltypChgSortList As ChgSortList
                '@ｿｰﾄ列番号を格納
                ltypChgSortList.lngCol = e.Col
                '@並び替え方法を格納（昇順/降順）
                ltypChgSortList.lngOrder = e.Order

                .typChgSortList.Add(ltypChgSortList)
            End With

            '@ｶﾚﾝﾄ行の設定（ｸﾞﾘｯﾄﾞ、保持列 [№]、前頁、次頁 ）
            Call pubVsfAfterSort(vsfFbDataList, CMlngvsfListColNo, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbDataList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbDataList2_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:49:38 N.Kasai
    '更新日：2007/09/18 (Tue) 10:49:38
    '備　考：
    Private Sub vsfFbDataList2_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfFbDataList2.AfterSort

        Try
            
            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfFbDataList2.BeforeRowColChange, AddressOf vsfFbDataList2_BeforeRowColChange
            AddHandler vsfFbDataList2.AfterRowColChange, AddressOf vsfFbDataList2_AfterRowColChange

            'NSYS データ行がない場合は処理を抜ける
            If vsfFbDataList2.Rows.Count <= vsfFbDataList2.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort2
                'NSYS リストを初期化
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                Dim ltypChgSortList As ChgSortList
                '@ｿｰﾄ列番号を格納
                ltypChgSortList.lngCol = e.Col
                '@並び替え方法を格納（昇順/降順）
                ltypChgSortList.lngOrder = e.Order

                .typChgSortList.Add(ltypChgSortList)
            End With

            '@ｶﾚﾝﾄ行の設定（ｸﾞﾘｯﾄﾞ、保持列 [№]、前頁、次頁 ）
            Call pubVsfAfterSort(vsfFbDataList2, CMlngvsfList2ColNo, cmdUP2, cmdDown2)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbDataList2_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbData_KeyDown
    '機　能：ﾃﾞｰﾀｸﾞﾘｯﾄﾞKeyDown
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 12:52:28 N.Kasai
    '更新日：2006/03/02 (Thu) 12:52:28
    '備　考：
    Private Sub vsfFbData_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfFbData.KeyDown

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbData.Rows.Count <= vsfFbData.Rows.Fixed Then
                Return
            End If
            
            With vsfFbData
                '@ﾍｯﾀﾞｰ行の場合、処理中止
                If .Row = 0 Then
                    Exit Sub
                End If
                
                Select Case e.KeyCode
                    Case Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.PageUp, Keys.PageDown
                        
                    Case Else
                            
                        Select Case .Col
                            '@№
                            Case CMlngvsfListColNo
                                '@編集不可
                                .AllowEditing = False
                                
                            '@ﾊﾟﾗﾒｰﾀ値
                            Case Else
                                
                                'Shot分離対応、Shot分離有無で入力パラメータが異なるので、入力不可色の場合は編集不可とする
                                If .GetCellStyle(.Row, .Col).BackColor = ColorTranslator.FromWin32(CPlngNotInputColor) Then
                                    '@編集不可
                                    .AllowEditing = False
                                    Exit Sub
                                End If

                                'NSYS [F2][Space]キーの場合
                                If e.KeyCode = Keys.F2 OrElse e.KeyCode = Keys.Space Then
                                    e.SuppressKeyPress = True
                                End If

                                If e.KeyCode = Keys.Space Then  'ｽﾍﾟｰｽは無効
                                    e.Handled = True
                                End If
                                '@DELETEｷｰの場合は値をｸﾘｱする。
                                If e.KeyCode = Keys.Delete Then
                                    .SetData(.Row, .Col, vbNullString)
                                End If
                                
        '@↓2017/01/24 (Tue) 18:51:42 T.Oide **************************************************
        '@                        '@編集可能ｾﾙの場合
        '@                        .Select .Row, .Col  '編集可能ｾﾙの範囲選択
        '@                        .EditCell           '編集可能にする
        '@------------------------------------------------------------------------------
                                '@patch分割設対象外 or 分割なしか(1は分割なし、0はありえないはずだが一応)
                                If ptypPhotoFbDataListAns.strPatchDivideNumRecipe = vbNullString Or _
                                   ptypPhotoFbDataListAns.strPatchDivideNumRecipe = "0" Or _
                                   ptypPhotoFbDataListAns.strPatchDivideNumRecipe = "1" Then

                                    '@編集可能ｾﾙの場合
                                    'NSYS 編集時の前景色と背景色を設定
                                    If .GetCellStyle(.Row, .Col).BackColor = ColorTranslator.FromWin32(CPlngEditColor) Then
                                        'NSYS 背景色が水色(編集済)の場合は編集中の背景色も水色に設定
                                        .Styles.Editor.BackColor = ColorTranslator.FromWin32(CPlngEditColor)
                                        .Styles.Editor.ForeColor = SystemColors.WindowText
                                    Else
                                        'NSYS 背景色が水色でない場合は編集中の背景色を白色に設定
                                        .Styles.Editor.BackColor = SystemColors.Window
                                        .Styles.Editor.ForeColor = SystemColors.WindowText
                                    End If
                                    
                                    .Select(.Row, .Col)  '編集可能ｾﾙの範囲選択
                                    .StartEditing()      '編集可能にする

                                    'NSYS [BackSpace]キーの場合
                                    If e.KeyCode = Keys.Back AndAlso (TypeOf .Editor Is TextBox)
                                        CType(.Editor, TextBox).Clear()
                                    End If
                   
                                End If
        '@↑2017/01/24 (Tue) 18:51:42 T.Oide **************************************************
                        
                        End Select
                        
                End Select
            End With
            
            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbData_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：vsfFbData2_KeyDown
    '機　能：ﾃﾞｰﾀｸﾞﾘｯﾄﾞｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:58:35 N.Kasai
    '更新日：2007/09/18 (Tue) 10:58:35
    '備　考：
    Private Sub vsfFbData2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfFbData2.KeyDown

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbData2.Rows.Count <= vsfFbData2.Rows.Fixed Then
                Return
            End If
            
            With vsfFbData2
                '@ﾍｯﾀﾞｰ行の場合、処理中止
                If .Row = 0 Then
                    Exit Sub
                End If
                '@ｷｰｺｰﾄﾞ判定
                Select Case e.KeyCode
                    Case Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.PageUp, Keys.PageDown
                        '@矢印ｷｰの場合は特に制御なし
                        
                    Case Else
                            
                        Select Case .Col
                            '@№
                            Case CMlngvsfList2ColNo
                                '@編集不可
                                .AllowEditing = False
                                
                            '@ﾊﾟﾗﾒｰﾀ値
                            Case Else
                                'NSYS [F2][Space]キーの場合
                                If e.KeyCode = Keys.F2 OrElse e.KeyCode = Keys.Space Then
                                    e.SuppressKeyPress = True
                                End If

                                If e.KeyCode = Keys.Space Then  'ｽﾍﾟｰｽは無効
                                    e.Handled = True
                                End If
                                '@DELETEｷｰの場合は値をｸﾘｱする。
                                If e.KeyCode = Keys.Delete Then
                                    .SetData(.Row, .Col, vbNullString)
                                End If
                                '@編集可能ｾﾙの場合
                                'NSYS 編集時の前景色と背景色を設定
                                If .GetCellStyle(.Row, .Col).BackColor = ColorTranslator.FromWin32(CPlngEditColor) Then
                                    'NSYS 背景色が水色(編集済)の場合は編集中の背景色も水色に設定
                                    .Styles.Editor.BackColor = ColorTranslator.FromWin32(CPlngEditColor)
                                    .Styles.Editor.ForeColor = SystemColors.WindowText
                                Else
                                    'NSYS 背景色が水色でない場合は編集中の背景色を白色に設定
                                    .Styles.Editor.BackColor = SystemColors.Window
                                    .Styles.Editor.ForeColor = SystemColors.WindowText
                                End If

                                .Select(.Row, .Col)  '編集可能ｾﾙの範囲選択
                                .StartEditing()           '編集可能にする

                                'NSYS [BackSpace]キーの場合
                                If e.KeyCode = Keys.Back AndAlso (TypeOf .Editor Is TextBox)
                                    CType(.Editor, TextBox).Clear()
                                End If
                        End Select
                        
                End Select
            End With
            
            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbData2_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：vsfFbData_KeyPressEdit
    '機　能：ﾃﾞｰﾀｸﾞﾘｯﾄﾞKeyPressEdit
    '引　数：Row：行
    '　　　：Col：列
    '　　　：KeyAscii：Asciiｺｰﾄﾞ
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 12:54:00 N.Kasai
    '更新日：2006/03/02 (Thu) 12:54:00
    '備　考：
    Private Sub vsfFbData_KeyPressEdit(ByVal sender As Object, ByVal e As KeyPressEditEventArgs) Handles vsfFbData.KeyPressEdit

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbData.Rows.Count <= vsfFbData.Rows.Fixed Then
                Return
            End If

            With vsfFbData
                Select Case e.Col
                    '@№
                    Case CMlngvsfListColNo
                        '@編集不可
                        .AllowEditing = False
                    
                    '@ﾊﾟﾗﾒｰﾀ値
                    Case Else
                        '@半角数字,「.」「-」のみ入力可
                        Select Case Asc(e.KeyChar)
                            Case CPlngKeyAsciiNum0 To CPlngKeyAsciiNum9, CPlngKeyBackSpace, CPlngKeyReturn, CPlngKeyAsciiDecPoint, CPlngKeyAsciiMinus

                                If .GetCellStyle(.Row, .Col).BackColor = ColorTranslator.FromWin32(CPlngNotInputColor) Then
                                    e.Handled = True 'ｷｰ無効
                                End If

                                '@入力可能
                            Case Else
                                e.Handled = True 'ｷｰ無効
                        
                        End Select
                End Select
            End With
            
            '@[']の入力禁止
            If Asc(e.KeyChar) = CPlngKeyAscSingleQ Then
                e.Handled = True
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbData_KeyPressEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbData2_KeyPressEdit
    '機　能：ﾃﾞｰﾀｸﾞﾘｯﾄﾞKeyPressEdit
    '引　数：Row：行
    '　　　：Col：列
    '　　　：KeyAscii：Asciiｺｰﾄﾞ
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 11:00:22 N.Kasai
    '更新日：2007/09/18 (Tue) 11:00:22
    '備　考：
    Private Sub vsfFbData2_KeyPressEdit(ByVal sender As Object, ByVal e As KeyPressEditEventArgs) Handles vsfFbData2.KeyPressEdit

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbData2.Rows.Count <= vsfFbData2.Rows.Fixed Then
                Return
            End If

             With vsfFbData2
                    Select Case e.Col
                        '@№
                         Case CMlngvsfList2ColNo
                            '@編集不可
                             .AllowEditing = False
                        '@ﾊﾟﾗﾒｰﾀ値
                        Case Else
                        '@半角数字,「.」「-」のみ入力可
                        Select Case Asc(e.KeyChar)
                            Case CPlngKeyAsciiNum0 To CPlngKeyAsciiNum9, CPlngKeyBackSpace, CPlngKeyReturn, CPlngKeyAsciiDecPoint, CPlngKeyAsciiMinus
                                '@入力可能
                            Case Else
                                e.Handled = True 'ｷｰ無効
                        
                        End Select
                    
                    End Select
                End With
            
                '@[']の入力禁止
                If Asc(e.KeyChar) = CPlngKeyAscSingleQ Then
                    e.Handled = True
                End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbData2_KeyPressEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbData_AfterEdit
    '機　能：FBﾃﾞｰﾀｸﾞﾘｯﾄﾞ後処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 15:44:59 N.Kasai
    '更新日：2006/03/02 (Thu) 15:44:59
    '備　考：
    Private Sub vsfFbData_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfFbData.AfterEdit

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbData.Rows.Count <= vsfFbData.Rows.Fixed Then
                Return
            End If
            
            With vsfFbData
                Select Case e.Col
                    '@№
                    Case CMlngvsfListColNo
                        '@編集不可
                         .AllowEditing = False
                    '@ﾊﾟﾗﾒｰﾀ値の場合
                    Case Else
                        '@patch分割設対象外 or 分割なしか(1は分割なし、0はありえないはずだが一応)
                        If ptypPhotoFbDataListAns.strPatchDivideNumRecipe = vbNullString Or _
                           ptypPhotoFbDataListAns.strPatchDivideNumRecipe = "0" Or _
                           ptypPhotoFbDataListAns.strPatchDivideNumRecipe = "1" Then

                            'NSYS 編集内容が数値の場合
                            If IsNumeric(.GetData(e.Row, e.Col)) Then
                                .SetData(e.Row, e.Col, CDbl(.GetData(e.Row, e.Col)))
                            End If

                            '@編集可
                            .AllowEditing = True
                        End If
                End Select
            
                '@変更内容の確認
                If mstrBeforeEditString <> CStr(.GetData(e.Row, e.Col)) Then
                    '@編集色へ変更
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngEditColor")
                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngEditColor)
                    Dim cellRange As CellRange = .GetCellRange(1, e.Col)
                    cellRange.Style = newStyle

                    ’Shot分離なしのレシピ
                    If lblShotSeparateFlag.Text <> CPstrAriFlg Then
                        '「SHOTROT」を入力の場合
                        If e.Col = CMlngvsfListColItem7 Then
                            '「SHOTROTX」「SHOTROTY」に「SHOTROT」の値を入れる
                            .SetData(e.Row, CMlngvsfListColItem9, CDbl(Format$(.GetData(e.Row, e.Col), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotXValidDigit))))
                            .SetData(e.Row, CMlngvsfListColItem10, CDbl(Format$(.GetData(e.Row, e.Col), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotYValidDigit))))
                        End If

                        '「SHOTMAG」を入力の場合
                        If e.Col = CMlngvsfListColItem8 Then
                            '「SHOTMAGX」「SHOTMAGY」に「SHOTMAG」の値を入れる
                            .SetData(e.Row, CMlngvsfListColItem11, CDbl(Format$(.GetData(e.Row, e.Col), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagXValidDigit))))
                            .SetData(e.Row, CMlngvsfListColItem12, CDbl(Format$(.GetData(e.Row, e.Col), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagXValidDigit))))
                        End If

                    ’Shot分離ありのレシピ
                    Else
                        '「SHOTROTX」「SHOTROTY」を入力の場合
                        If e.Col = CMlngvsfListColItem9 Or e.Col = CMlngvsfListColItem10 Then
                            '「SHOTROT」に「SHOTROTX」「SHOTROTY」の平均値を入れる
                            If CStr(.GetData(e.Row, CMlngvsfListColItem9)) <> vbNullString And CStr(.GetData(e.Row, CMlngvsfListColItem10)) <> vbNullString Then
                                Dim tmp As Single =  Single.Parse(.GetData(e.Row, CMlngvsfListColItem9)) + Single.Parse(.GetData(e.Row, CMlngvsfListColItem10))
                                .SetData(e.Row, CMlngvsfListColItem7, CDbl(Format$(tmp/2, pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotValidDigit))))
                            End If
                        End If

                        '「SHOTMAGX」「SHOTMAGY」を入力の場合
                        If e.Col = CMlngvsfListColItem11 Or e.Col = CMlngvsfListColItem12 Then
                            '「SHOTMAG」に「SHOTMAGX」「SHOTMAGY」の平均値を入れる
                            If CStr(.GetData(e.Row, CMlngvsfListColItem11)) <> vbNullString And CStr(.GetData(e.Row, CMlngvsfListColItem12)) <> vbNullString Then
                                Dim tmp As Single =  Single.Parse(.GetData(e.Row, CMlngvsfListColItem11)) + Single.Parse(.GetData(e.Row, CMlngvsfListColItem12))
                                .SetData(e.Row, CMlngvsfListColItem8, CDbl(Format$(tmp/2, pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagValidDigit))))
                            End If
                        End If
                    End If
                End If
            
            End With
            
            
            '@共通ｺﾏﾝﾄﾞﾎﾞﾀﾝﾁｪｯｸ
            Call prvCmdButton_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbData_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbData_DblClick
    '機　能：ﾃﾞｰﾀｸﾞﾘｯﾄﾞDblClick
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 13:56:02 N.Kasai
    '更新日：2017/01/24 (Tue) 18:39:44 T.Oide
    '備　考：
    Private Sub vsfFbData_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFbData.DoubleClick

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbData.Rows.Count <= vsfFbData.Rows.Fixed Then
                Return
            End If

            With vsfFbData
             
                '@ﾍｯﾀﾞｰ行の場合、処理中止
                If .Row = 0 Then
                    Exit Sub
                End If
                
                '@列判定
                 Select Case .Col
                    '@№
                    Case CMlngvsfListColNo
                        '@編集不可
                        .AllowEditing = False
                    '@変更値
                    Case Else
                    
        '@↓2017/01/24 (Tue) 18:39:08 T.Oide **************************************************
        '@                '@編集可能ｾﾙの場合
        '@                .Select .Row, .Col  '編集可能ｾﾙの範囲選択
        '@                .EditCell           '編集可能にする
        '@-------------------------------------------------------------------
                        '@patch分割設対象外 or 分割なしか(1は分割なし、0はありえないはずだが一応)
                        If ptypPhotoFbDataListAns.strPatchDivideNumRecipe = vbNullString Or _
                           ptypPhotoFbDataListAns.strPatchDivideNumRecipe = "0" Or _
                           ptypPhotoFbDataListAns.strPatchDivideNumRecipe = "1" Then

                            '@編集可能ｾﾙの場合
                            'NSYS 編集時の前景色と背景色を設定
                            If .GetCellStyle(.Row, .Col).BackColor = ColorTranslator.FromWin32(CPlngEditColor) Then
                                'NSYS 背景色が水色(編集済)の場合は編集中の背景色も水色に設定
                                .Styles.Editor.BackColor = ColorTranslator.FromWin32(CPlngEditColor)
                                .Styles.Editor.ForeColor = SystemColors.WindowText
                            Else
                                'NSYS 背景色が水色でない場合は編集中の背景色を白色に設定
                                .Styles.Editor.BackColor = SystemColors.Window
                                .Styles.Editor.ForeColor = SystemColors.WindowText
                            End If
                            
                            .Select(.Row, .Col)  '編集可能ｾﾙの範囲選択
                            .StartEditing()      '編集可能にする
                        
                        End If
        '@↑2017/01/24 (Tue) 18:39:08 T.Oide **************************************************
                        
                End Select
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbData_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbData2_DblClick
    '機　能：ﾃﾞｰﾀｸﾞﾘｯﾄﾞDblClick
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 11:00:43 N.Kasai
    '更新日：2007/09/18 (Tue) 11:00:43
    '備　考：
    Private Sub vsfFbData2_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFbData2.DoubleClick

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbData2.Rows.Count <= vsfFbData2.Rows.Fixed Then
                Return
            End If

            With vsfFbData2
             
                '@ﾍｯﾀﾞｰ行の場合、処理中止
                If .Row = 0 Then
                    Exit Sub
                End If
                
                '@列判定
                 Select Case .Col
                    '@№
                    Case CMlngvsfList2ColNo
                        '@編集不可
                        .AllowEditing = False
                    '@変更値
                    Case Else
                        '@編集可能ｾﾙの場合
                        'NSYS 編集時の前景色と背景色を設定
                        If .GetCellStyle(.Row, .Col).BackColor = ColorTranslator.FromWin32(CPlngEditColor) Then
                            'NSYS 背景色が水色(編集済)の場合は編集中の背景色も水色に設定
                            .Styles.Editor.BackColor = ColorTranslator.FromWin32(CPlngEditColor)
                            .Styles.Editor.ForeColor = SystemColors.WindowText
                        Else
                            'NSYS 背景色が水色でない場合は編集中の背景色を白色に設定
                            .Styles.Editor.BackColor = SystemColors.Window
                            .Styles.Editor.ForeColor = SystemColors.WindowText
                        End If
                        
                        .Select(.Row, .Col)  '編集可能ｾﾙの範囲選択
                        .StartEditing()      '編集可能にする
                End Select
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbData2_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try

    End Sub

    '関数名：vsfRecipeCopy_DoubleClick
    '機　能：ｸﾞﾘｯﾄﾞのｺﾝﾎﾞﾘｽﾄ変更
    '引　数：なし
    '戻り値：なし
    '作成日：2024/02/19 (Mon) 09:07:43 T.Oide
    '更新日：2024/02/19 (Mon) 09:07:43
    '備　考：
	Private Sub vsfRecipeCopy_DoubleClick(sender As Object, e As EventArgs) Handles vsfRecipeCopy.Click

        Try
			With vsfRecipeCopy

				'データ行がない場合は処理を抜ける
				If .Rows.Count <= .Rows.Fixed Then
					Return
				End If
				
                'ﾍｯﾀﾞｰ行の場合、処理中止
                If .Row = 0 Then
                    Exit Sub
                End If
                
				'ﾍｯﾀﾞｰ行の場合、処理中止
                If .MouseRow = 0 Then
                    Exit Sub
                End If
                
				'列により処理分岐
                Select Case .Col

                    'ｺﾋﾟｰ元ﾚｼﾋﾟ、ｺﾋﾟｰ先ﾚｼﾋﾟの場合
                    Case CMintvsfCopyRecipe, CMintvsfCopyCpRecipe

						'ｸﾞﾘｯﾄﾞｺﾝﾎﾞﾘｽﾄを再作成
						Call prvcmbRecpList_Set(mtypEqTypeRecpList)
						
						'編集状態にする
'						.Styles.Editor.BackColor = SystemColors.Window
						.StartEditing()
						
                End Select
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRecipeCopy_DoubleClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try

	End Sub

	'関数名：vsfRecipeCopy_EnterCell
    '機　能：セルの選択でボタンの有効/無効を制御
    '引　数：なし
    '戻り値：なし
    '作成日：2024/02/19 (Mon) 09:07:43 T.Oide
    '更新日：2024/02/19 (Mon) 09:07:43
    '備　考：
	Private Sub vsfRecipeCopy_EnterCell(sender As Object, e As EventArgs) Handles vsfRecipeCopy.EnterCell

		Try
			'ボタン有効/無効制御
			Call prvCmdButton_Chk()

			Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRecipeCopy_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try

	End Sub

	'関数名：vsfRecipeCopy_AfterEdit
    '機　能：ﾚｼﾋﾟ元/先選択時にﾚｼﾋﾟ登録号機を表示する
    '引　数：なし
    '戻り値：なし
    '作成日：2024/02/19 (Mon) 09:07:43 T.Oide
    '更新日：2024/02/19 (Mon) 09:07:43
    '備　考：
	Private Sub vsfRecipeCopy_AfterEdit(sender As Object, e As RowColEventArgs) Handles vsfRecipeCopy.AfterEdit

		Try
			If vsfRecipeCopy.Col = CMintvsfCopyRecipe Or  vsfRecipeCopy.Col = CMintvsfCopyCpRecipe Then
				'登録号機を表示する
				Call prvTourokuGoukiSet()
			End If

			'ボタン有効/無効制御
			Call prvCmdButton_Chk()

			Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRecipeCopy_AfterEdit"
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
    '関数名：prvvsfFbDataList_init
    '機　能：ｸﾞﾘｯﾄﾞの初期化(ﾃﾞｰﾀﾘｽﾄ)
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 14:21:43 N.Kasai
    '更新日：2006/02/23 (Thu) 14:21:43
    '備　考：
    Private Sub prvvsfFbDataList_init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfFbDataList
                '@描画なし
                .Redraw = False
                '@ｸﾞﾘｯﾄﾞの行設定
                .Rows.Count = .Rows.Fixed
                '@ｸﾞﾘｯﾄﾞの列設定
                .Cols.Count = CMlngvsfListCols
                '@固定列の設定
                .Cols.Frozen = 1
                '@ｸﾞﾘｯﾄﾞ設定
                '.AllowBigSelection = False                                 'ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowSelection = False                                    'ﾏｳｽでｾﾙ範囲選択不可
                .SelectionMode = SelectionModeEnum.Row                      '行選択
                '.FillStyle = flexFillRepeat                                'ﾌﾟﾛﾊﾟﾃｨの設定対象（選択ｾﾙ）
                .FocusRect = FocusRectEnum.Light                            'ｶﾚﾝﾄｾﾙのﾌｫｰｶｽ枠（細い枠）
                .ScrollBars = ScrollBars.None                               'ｽｸﾛｰﾙﾊﾞｰ（なし）
                '.AutoSizeMode = flexAutoSizeColWidth                       'ｵｰﾄｻｲｽﾞ（列）
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter  '文字列の最後に省略符号
                '.AllowUserResizing = flexResizeColumns                     '列幅の変更許可
                .ExtendLastCol = True                                       '右端の列をｸﾞﾘｯﾄﾞに合わせる
                .AllowSorting = AllowSortingEnum.None                       'ﾍｯﾀﾞｰｸﾘｯｸでｿｰﾄしない

                '@一覧表の表題設定
                .Select(CMlngvsfTRow, CMlngvsfListColNo, CMlngvsfTRow, .Cols.Count - 1)
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.Font = New Font(lFixedStyle.Font.FontFamily, CMlngVsfHFontSize, _
                                            lFixedStyle.Font.Style, lFixedStyle.Font.Unit)  'ﾌｫﾝﾄｻｲｽﾞ
                lFixedStyle.ForeColor = Color.Yellow                                        '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)           '背景色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                          '配置
                lFixedStyle.Trimming = StringTrimming.None                                  'NSYS ヘッダー文字列を省略表示しない
                .Rows(CMlngvsfTRow).Height = CMlngVsfHHeight                                'ﾍｯﾀﾞｰ高さ
                
                '@列幅設定
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    .Cols(CMlngvsfListColNo).Width = CMlngvsfListColWNo                     '№
                    .Cols(CMlngvsfListColItem1).Width = CMlngvsfListColwItem1               'ﾊﾟﾗﾒｰﾀ1
                    .Cols(CMlngvsfListColItem2).Width = CMlngvsfListColwItem2               'ﾊﾟﾗﾒｰﾀ2
                    .Cols(CMlngvsfListColItem3).Width = CMlngvsfListColwItem3               'ﾊﾟﾗﾒｰﾀ3
                    .Cols(CMlngvsfListColItem4).Width = CMlngvsfListColwItem4               'ﾊﾟﾗﾒｰﾀ4
                    .Cols(CMlngvsfListColItem5).Width = CMlngvsfListColwItem5               'ﾊﾟﾗﾒｰﾀ5
                    .Cols(CMlngvsfListColItem6).Width = CMlngvsfListColwItem6               'ﾊﾟﾗﾒｰﾀ6
                    .Cols(CMlngvsfListColItem7).Width = CMlngvsfListColwItem7               'ﾊﾟﾗﾒｰﾀ7
                    .Cols(CMlngvsfListColItem8).Width = CMlngvsfListColwItem8               'ﾊﾟﾗﾒｰﾀ8
                    'Shot分離
                    .Cols(CMlngvsfListColItem9).Width = CMlngvsfListColwItem9               'ﾊﾟﾗﾒｰﾀ9
                    .Cols(CMlngvsfListColItem10).Width = CMlngvsfListColwItem10              'ﾊﾟﾗﾒｰﾀ10
                    .Cols(CMlngvsfListColItem11).Width = CMlngvsfListColwItem11              'ﾊﾟﾗﾒｰﾀ11
                    .Cols(CMlngvsfListColItem12).Width = CMlngvsfListColwItem12              'ﾊﾟﾗﾒｰﾀ12
                    .Cols(CMlngvsfListColFbLot).Width = CMlngvsfListColwFbLot               'FB計算対象ﾛｯﾄ
                    .Cols(CMlngvsfListColEditTime).Width = CMlngvsfListColwEditTime         '最終更新日時
                    .Cols(CMlngvsfListColEditEmp).Width = CMlngvsfListColwEditEmp           '最終更新者
                    .Cols(CMlngvsfListColComments).Width = CMlngvsfListColwComments         'ｺﾒﾝﾄ
                End If
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfTRow, CMlngvsfListColNo, CMstrvsfListColTNo)               '№
                .SetData(CMlngvsfTRow, CMlngvsfListColItem1, CMstrvsfListColtItem1)         'ﾊﾟﾗﾒｰﾀ1
                .SetData(CMlngvsfTRow, CMlngvsfListColItem2, CMstrvsfListColtItem2)         'ﾊﾟﾗﾒｰﾀ2
                .SetData(CMlngvsfTRow, CMlngvsfListColItem3, CMstrvsfListColtItem3)         'ﾊﾟﾗﾒｰﾀ3
                .SetData(CMlngvsfTRow, CMlngvsfListColItem4, CMstrvsfListColtItem4)         'ﾊﾟﾗﾒｰﾀ4
                .SetData(CMlngvsfTRow, CMlngvsfListColItem5, CMstrvsfListColtItem5)         'ﾊﾟﾗﾒｰﾀ5
                .SetData(CMlngvsfTRow, CMlngvsfListColItem6, CMstrvsfListColtItem6)         'ﾊﾟﾗﾒｰﾀ6
                .SetData(CMlngvsfTRow, CMlngvsfListColItem7, CMstrvsfListColtItem7)         'ﾊﾟﾗﾒｰﾀ7
                .SetData(CMlngvsfTRow, CMlngvsfListColItem8, CMstrvsfListColtItem8)         'ﾊﾟﾗﾒｰﾀ8
                'Shot分離
                .SetData(CMlngvsfTRow, CMlngvsfListColItem9, CMstrvsfListColtItem9)         'ﾊﾟﾗﾒｰﾀ9
                .SetData(CMlngvsfTRow, CMlngvsfListColItem10, CMstrvsfListColtItem10)       'ﾊﾟﾗﾒｰﾀ10
                .SetData(CMlngvsfTRow, CMlngvsfListColItem11, CMstrvsfListColtItem11)       'ﾊﾟﾗﾒｰﾀ11
                .SetData(CMlngvsfTRow, CMlngvsfListColItem12, CMstrvsfListColtItem12)       'ﾊﾟﾗﾒｰﾀ12
                .SetData(CMlngvsfTRow, CMlngvsfListColFbLot, CMstrvsfListColtFbLot)         'FB計算対象ﾛｯﾄ
                .SetData(CMlngvsfTRow, CMlngvsfListColEditTime, CMstrvsfListColtEditTime)   '最終更新日時
                .SetData(CMlngvsfTRow, CMlngvsfListColEditEmp, CMstrvsfListColtEditEmp)     '最終更新者
                .SetData(CMlngvsfTRow, CMlngvsfListColComments, CMstrvsfListColtComments)   'ｺﾒﾝﾄ
                
                '@非表示Col設定
                .Cols(CMlngvsfListColComments).Visible = False  'ｺﾒﾝﾄ
                
                '@表示ﾌｫｰﾏｯﾄ
                .Cols(CMlngvsfListColNo).TextAlign = TextAlignEnum.RightCenter              '№（右中央）
                .Cols(CMlngvsfListColItem1).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ1（右中央）
                .Cols(CMlngvsfListColItem2).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ2（右中央）
                .Cols(CMlngvsfListColItem3).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ3（右中央）
                .Cols(CMlngvsfListColItem4).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ4（右中央）
                .Cols(CMlngvsfListColItem5).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ5（右中央）
                .Cols(CMlngvsfListColItem6).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ6（右中央）
                .Cols(CMlngvsfListColItem7).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ7（右中央）
                .Cols(CMlngvsfListColItem8).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ8（右中央）
                'Shot分離
                .Cols(CMlngvsfListColItem9).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ9（右中央）
                .Cols(CMlngvsfListColItem10).TextAlign = TextAlignEnum.RightCenter          'ﾊﾟﾗﾒｰﾀ10（右中央）
                .Cols(CMlngvsfListColItem11).TextAlign = TextAlignEnum.RightCenter          'ﾊﾟﾗﾒｰﾀ11（右中央）
                .Cols(CMlngvsfListColItem12).TextAlign = TextAlignEnum.RightCenter          'ﾊﾟﾗﾒｰﾀ12（右中央）
                .Cols(CMlngvsfListColFbLot).TextAlign = TextAlignEnum.LeftCenter            'FB計算対象ﾛｯﾄ（左中央）
                .Cols(CMlngvsfListColEditTime).TextAlign = TextAlignEnum.LeftCenter         '最終更新日時（左中央）
                .Cols(CMlngvsfListColEditEmp).TextAlign = TextAlignEnum.LeftCenter          '最終更新者（左中央）
                .Cols(CMlngvsfListColComments).TextAlign = TextAlignEnum.LeftCenter         'ｺﾒﾝﾄ（左中央）
                
                .LeftCol = .Cols.Fixed

                '@直接描画
                .Redraw = True
                
                '@ﾛｯｸ
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfFbDataList_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfFbDataList2_init
    '機　能：ｸﾞﾘｯﾄﾞ初期化(露光)
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:51:08 N.Kasai
    '更新日：2007/09/18 (Tue) 10:51:08
    '備　考：
    Private Sub prvvsfFbDataList2_init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfFbDataList2
                '@描画なし
                .Redraw = False
                '@ｸﾞﾘｯﾄﾞの行設定
                .Rows.Count = .Rows.Fixed
                '@ｸﾞﾘｯﾄﾞの列設定
                .Cols.Count = CMlngvsfList2Cols
                '@固定列の設定
                .Cols.Frozen = 1
                '@ｸﾞﾘｯﾄﾞ設定
                '.AllowBigSelection = False                                 'ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowSelection = False                                    'ﾏｳｽでｾﾙ範囲選択不可
                .SelectionMode = SelectionModeEnum.Row                      '行選択
                '.FillStyle = flexFillRepeat                                'ﾌﾟﾛﾊﾟﾃｨの設定対象（選択ｾﾙ）
                .FocusRect = FocusRectEnum.Light                            'ｶﾚﾝﾄｾﾙのﾌｫｰｶｽ枠（細い枠）
                .ScrollBars = ScrollBars.None                               'ｽｸﾛｰﾙﾊﾞｰ（なし）
                '.AutoSizeMode = flexAutoSizeColWidth                       'ｵｰﾄｻｲｽﾞ（列）
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter  '文字列の最後に省略符号
                '.AllowUserResizing = flexResizeColumns                     '列幅の変更許可
                .ExtendLastCol = True                                       '右端の列をｸﾞﾘｯﾄﾞに合わせる
                .AllowSorting = AllowSortingEnum.None                       'ﾍｯﾀﾞｰｸﾘｯｸでｿｰﾄしない
                
                '@一覧表の表題設定
                .Select(CMlngvsfTRow, CMlngvsfList2ColNo, CMlngvsfTRow, .Cols.Count - 1)
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.Font = New Font(lFixedStyle.Font.FontFamily, CMlngVsfHFontSize2, _
                                            lFixedStyle.Font.Style, lFixedStyle.Font.Unit)  'ﾌｫﾝﾄｻｲｽﾞ
                lFixedStyle.ForeColor = Color.Yellow                                        '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)           '背景色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                          '配置
                lFixedStyle.Trimming = StringTrimming.None                                  'NSYS ヘッダー文字列を省略表示しない
                .Rows(CMlngvsfTRow).Height = CMlngVsfHHeight                                'ﾍｯﾀﾞｰ高さ
                
                '@列幅設定
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort2.blnChgWidth = False Then
                    .Cols(CMlngvsfList2ColNo).Width = CMlngvsfList2ColWNo                                 '№
                    .Cols(CMlngvsfList2ColItem1).Width = CMlngvsfList2ColwItem1                           'ﾊﾟﾗﾒｰﾀ1
                    .Cols(CMlngvsfList2ColItem2).Width = CMlngvsfList2ColwItem2                           'ﾊﾟﾗﾒｰﾀ2
                    .Cols(CMlngvsfList2ColItem3).Width = CMlngvsfList2ColwItem3                           'ﾊﾟﾗﾒｰﾀ3
                    .Cols(CMlngvsfList2ColItem4).Width = CMlngvsfList2ColwItem4                           'ﾊﾟﾗﾒｰﾀ4
                    .Cols(CMlngvsfList2ColEditTime).Width = CMlngvsfList2ColwEditTime                     '最終更新日時
                    .Cols(CMlngvsfList2ColEditEmp).Width = CMlngvsfList2ColwEditEmp                       '最終更新者
                    .Cols(CMlngvsfList2ColComments).Width = CMlngvsfList2ColwComments                     'ｺﾒﾝﾄ
                End If
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfTRow, CMlngvsfList2ColNo, CMstrvsfList2ColTNo)               '№
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem1, CMstrvsfList2ColtItem1)         'ﾊﾟﾗﾒｰﾀ1
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem2, CMstrvsfList2ColtItem2)         'ﾊﾟﾗﾒｰﾀ2
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem3, CMstrvsfList2ColtItem3)         'ﾊﾟﾗﾒｰﾀ3
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem4, CMstrvsfList2ColtItem4)         'ﾊﾟﾗﾒｰﾀ4
                .SetData(CMlngvsfTRow, CMlngvsfList2ColEditTime, CMstrvsfList2ColtEditTime)   '最終更新日時
                .SetData(CMlngvsfTRow, CMlngvsfList2ColEditEmp, CMstrvsfList2ColtEditEmp)     '最終更新者
                .SetData(CMlngvsfTRow, CMlngvsfList2ColComments, CMstrvsfList2ColtComments)   'ｺﾒﾝﾄ
                
                '@非表示Col設定
                .Cols(CMlngvsfList2ColComments).Visible = False  'ｺﾒﾝﾄ
                
                '@表示ﾌｫｰﾏｯﾄ
                .Cols(CMlngvsfList2ColNo).TextAlign = TextAlignEnum.RightCenter                                '№（右中央）
                .Cols(CMlngvsfList2ColItem1).TextAlign = TextAlignEnum.RightCenter                             'ﾊﾟﾗﾒｰﾀ1（右中央）
                .Cols(CMlngvsfList2ColItem2).TextAlign = TextAlignEnum.RightCenter                             'ﾊﾟﾗﾒｰﾀ2（右中央）
                .Cols(CMlngvsfList2ColItem3).TextAlign = TextAlignEnum.RightCenter                             'ﾊﾟﾗﾒｰﾀ3（右中央）
                .Cols(CMlngvsfList2ColItem4).TextAlign = TextAlignEnum.RightCenter                             'ﾊﾟﾗﾒｰﾀ4（右中央）
                .Cols(CMlngvsfList2ColEditTime).TextAlign = TextAlignEnum.LeftCenter                           '最終更新日時（左中央）
                .Cols(CMlngvsfList2ColEditEmp).TextAlign = TextAlignEnum.LeftCenter                            '最終更新者（左中央）
                .Cols(CMlngvsfList2ColComments).TextAlign = TextAlignEnum.LeftCenter                           'ｺﾒﾝﾄ（左中央）
                
                '@直接描画
                .Redraw = True
                
                '@ﾛｯｸ
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfFbDataList2_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfFbData_init
    '機　能：ｸﾞﾘｯﾄﾞの初期化(ﾃﾞｰﾀ)
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 14:21:43 N.Kasai
    '更新日：2006/02/23 (Thu) 14:21:43
    '備　考：
    Private Sub prvvsfFbData_init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfFbData
                '@描画なし
                .Redraw = False
                '@行数設定
                .Rows.Count = .Rows.Fixed
                .Rows.Count = 2                                             '固定行
                '@ｸﾞﾘｯﾄﾞの列設定
                .Cols.Count = CMlngvsfColS
                '@固定列の設定
                .Cols.Frozen = 1
                '@ｸﾞﾘｯﾄﾞ設定
                '.AllowBigSelection = False                                 'ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowSelection = False                                    'ﾏｳｽでｾﾙ範囲選択不可
                .SelectionMode = SelectionModeEnum.Cell                     'ﾌﾘｰ選択
                .HighLight = HighLightEnum.WithFocus                        'ﾌｫｶｽがある場合反転
                '.FillStyle = flexFillRepeat                                'ﾌﾟﾛﾊﾟﾃｨの設定対象（選択ｾﾙ）
                .FocusRect = FocusRectEnum.None                             'ﾌｫｰｶｽ枠なし
                .ScrollBars = ScrollBars.None                               'ｽｸﾛｰﾙﾊﾞｰ（なし）
                '.AutoSizeMode = flexAutoSizeColWidth                       'ｵｰﾄｻｲｽﾞ（列）
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter  '文字列の最後に省略符号あり
                '.AllowUserResizing = flexResizeColumns                     '列幅の変更許可
                .ExtendLastCol = True                                       '右端の列をｸﾞﾘｯﾄﾞに合わせる
                
                '@一覧表の表題設定
                .Select(CMlngvsfTRow, CMlngvsfListColNo, CMlngvsfTRow, .Cols.Count - 1)
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.Font = New Font(lFixedStyle.Font.FontFamily, CMlngVsfHFontSize, _
                                            lFixedStyle.Font.Style, lFixedStyle.Font.Unit)  'ﾌｫﾝﾄｻｲｽﾞ
                lFixedStyle.ForeColor = Color.Yellow                                        '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)           '背景色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                          '配置
                lFixedStyle.Trimming = StringTrimming.None                                  'NSYS ヘッダー文字列を省略表示しない
                .Rows(CMlngvsfTRow).Height = CMlngVsfHHeight                                'ﾍｯﾀﾞｰ高さ
                
                '@列幅設定
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    .Cols(CMlngvsfListColNo).Width = CMlngvsfListColWNo                     '№
                    .Cols(CMlngvsfListColItem1).Width = CMlngvsfListColwItem1               '装置ﾊﾟﾗﾒｰﾀ1
                    .Cols(CMlngvsfListColItem2).Width = CMlngvsfListColwItem2               '装置ﾊﾟﾗﾒｰﾀ2
                    .Cols(CMlngvsfListColItem3).Width = CMlngvsfListColwItem3               '装置ﾊﾟﾗﾒｰﾀ3
                    .Cols(CMlngvsfListColItem4).Width = CMlngvsfListColwItem4               '装置ﾊﾟﾗﾒｰﾀ4
                    .Cols(CMlngvsfListColItem5).Width = CMlngvsfListColwItem5               '装置ﾊﾟﾗﾒｰﾀ5
                    .Cols(CMlngvsfListColItem6).Width = CMlngvsfListColwItem6               '装置ﾊﾟﾗﾒｰﾀ6
                    .Cols(CMlngvsfListColItem7).Width = CMlngvsfListColwItem7               '装置ﾊﾟﾗﾒｰﾀ7
                    .Cols(CMlngvsfListColItem8).Width = CMlngvsfListColwItem8               '装置ﾊﾟﾗﾒｰﾀ8
                    'Shot分離
                    .Cols(CMlngvsfListColItem9).Width = CMlngvsfListColwItem9               '装置ﾊﾟﾗﾒｰﾀ9
                    .Cols(CMlngvsfListColItem10).Width = CMlngvsfListColwItem10             '装置ﾊﾟﾗﾒｰﾀ10
                    .Cols(CMlngvsfListColItem11).Width = CMlngvsfListColwItem11             '装置ﾊﾟﾗﾒｰﾀ11
                    .Cols(CMlngvsfListColItem12).Width = CMlngvsfListColwItem12             '装置ﾊﾟﾗﾒｰﾀ12
                End If
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfTRow, CMlngvsfListColNo, CMstrvsfListColTNo)               '№
                .SetData(CMlngvsfTRow, CMlngvsfListColItem1, CMstrvsfListColtItem1)         '装置ﾊﾟﾗﾒｰﾀ1
                .SetData(CMlngvsfTRow, CMlngvsfListColItem2, CMstrvsfListColtItem2)         '装置ﾊﾟﾗﾒｰﾀ2
                .SetData(CMlngvsfTRow, CMlngvsfListColItem3, CMstrvsfListColtItem3)         '装置ﾊﾟﾗﾒｰﾀ3
                .SetData(CMlngvsfTRow, CMlngvsfListColItem4, CMstrvsfListColtItem4)         '装置ﾊﾟﾗﾒｰﾀ4
                .SetData(CMlngvsfTRow, CMlngvsfListColItem5, CMstrvsfListColtItem5)         '装置ﾊﾟﾗﾒｰﾀ5
                .SetData(CMlngvsfTRow, CMlngvsfListColItem6, CMstrvsfListColtItem6)         '装置ﾊﾟﾗﾒｰﾀ6
                .SetData(CMlngvsfTRow, CMlngvsfListColItem7, CMstrvsfListColtItem7)         '装置ﾊﾟﾗﾒｰﾀ7
                .SetData(CMlngvsfTRow, CMlngvsfListColItem8, CMstrvsfListColtItem8)         '装置ﾊﾟﾗﾒｰﾀ8
                'Shot分離
                .SetData(CMlngvsfTRow, CMlngvsfListColItem9, CMstrvsfListColtItem9)         '装置ﾊﾟﾗﾒｰﾀ9
                .SetData(CMlngvsfTRow, CMlngvsfListColItem10, CMstrvsfListColtItem10)       '装置ﾊﾟﾗﾒｰﾀ10
                .SetData(CMlngvsfTRow, CMlngvsfListColItem11, CMstrvsfListColtItem11)       '装置ﾊﾟﾗﾒｰﾀ11
                .SetData(CMlngvsfTRow, CMlngvsfListColItem12, CMstrvsfListColtItem12)       '装置ﾊﾟﾗﾒｰﾀ12
                '@非表示Col設定
                '@なし
                
                '@表示ﾌｫｰﾏｯﾄ
                .Cols(CMlngvsfListColNo).TextAlign = TextAlignEnum.RightCenter              '№（右中央）
                .Cols(CMlngvsfListColItem1).TextAlign = TextAlignEnum.RightCenter           '装置ﾊﾟﾗﾒｰﾀ1（右中央）
                .Cols(CMlngvsfListColItem2).TextAlign = TextAlignEnum.RightCenter           '装置ﾊﾟﾗﾒｰﾀ2（右中央）
                .Cols(CMlngvsfListColItem3).TextAlign = TextAlignEnum.RightCenter           '装置ﾊﾟﾗﾒｰﾀ3（右中央）
                .Cols(CMlngvsfListColItem4).TextAlign = TextAlignEnum.RightCenter           '装置ﾊﾟﾗﾒｰﾀ4（右中央）
                .Cols(CMlngvsfListColItem5).TextAlign = TextAlignEnum.RightCenter           '装置ﾊﾟﾗﾒｰﾀ5（右中央）
                .Cols(CMlngvsfListColItem6).TextAlign = TextAlignEnum.RightCenter           '装置ﾊﾟﾗﾒｰﾀ6（右中央）
                .Cols(CMlngvsfListColItem7).TextAlign = TextAlignEnum.RightCenter           '装置ﾊﾟﾗﾒｰﾀ7（右中央）
                .Cols(CMlngvsfListColItem8).TextAlign = TextAlignEnum.RightCenter           '装置ﾊﾟﾗﾒｰﾀ8（右中央）
                'Shot分離
                .Cols(CMlngvsfListColItem9).TextAlign = TextAlignEnum.RightCenter           '装置ﾊﾟﾗﾒｰﾀ9（右中央）
                .Cols(CMlngvsfListColItem10).TextAlign = TextAlignEnum.RightCenter          '装置ﾊﾟﾗﾒｰﾀ10（右中央）
                .Cols(CMlngvsfListColItem11).TextAlign = TextAlignEnum.RightCenter          '装置ﾊﾟﾗﾒｰﾀ11（右中央）
                .Cols(CMlngvsfListColItem12).TextAlign = TextAlignEnum.RightCenter          '装置ﾊﾟﾗﾒｰﾀ12（右中央）
                
                '@ﾊﾞｯｸｶﾗｰの変更(入力不可色：ｸﾞﾚｰ)
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngvsfListColNo)
                cellRange.Style = newStyle      '№

                '@スロットの高さの設定
                .Rows(.Rows.Fixed).Height = CMlngvsfBHeight
                
                '@非表示Col
                '@なし
                
                '@ﾊﾞｯﾌｧ経由で描画
                .Redraw = True
                
                '@ﾛｯｸ
                .Enabled = False
                
                .AllowEditing = False
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfFbData_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfFbData2_init
    '機　能：ﾃﾞｰﾀｸﾞﾘｯﾄﾞ初期化（露光）
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/14 (Fri) 13:25:19 N.Kasai
    '更新日：2007/09/14 (Fri) 13:25:19
    '備　考：
    Private Sub prvvsfFbData2_init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfFbData2
                '@描画なし
                .Redraw = False
                '@行数設定
                .Rows.Count = .Rows.Fixed
                .Rows.Count = 2                                             '固定行
                '@ｸﾞﾘｯﾄﾞの列設定
                .Cols.Count = CMlngvsf2ColS
                '@固定列の設定
                .Cols.Frozen = 1
                '@ｸﾞﾘｯﾄﾞ設定
                '.AllowBigSelection = False                                 'ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowSelection = False                                    'ﾏｳｽでｾﾙ範囲選択不可
                .SelectionMode = SelectionModeEnum.Cell                     'ﾌﾘｰ選択
                .HighLight = HighLightEnum.WithFocus                        'ﾌｫｶｽがある場合反転
                '.FillStyle = flexFillRepeat                                'ﾌﾟﾛﾊﾟﾃｨの設定対象（選択ｾﾙ）
                .FocusRect = FocusRectEnum.None                             'ﾌｫｰｶｽ枠なし
                .ScrollBars = ScrollBars.None                               'ｽｸﾛｰﾙﾊﾞｰ（なし）
                '.AutoSizeMode = flexAutoSizeColWidth                       'ｵｰﾄｻｲｽﾞ（列）
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter  '文字列の最後に省略符号あり
                '.AllowUserResizing = flexResizeColumns                     '列幅の変更許可
                .ExtendLastCol = True                                       '右端の列をｸﾞﾘｯﾄﾞに合わせる
                
                '@一覧表の表題設定
                .Select(CMlngvsfTRow, CMlngvsfList2ColNo, CMlngvsfTRow, .Cols.Count - 1)
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.Font = New Font(lFixedStyle.Font.FontFamily, CMlngVsfHFontSize2, _
                                            lFixedStyle.Font.Style, lFixedStyle.Font.Unit)  'ﾌｫﾝﾄｻｲｽﾞ
                lFixedStyle.ForeColor = Color.Yellow                                        '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)           '背景色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                          '配置
                lFixedStyle.Trimming = StringTrimming.None                                  'NSYS ヘッダー文字列を省略表示しない
                .Rows(CMlngvsfTRow).Height = CMlngVsfHHeight                                'ﾍｯﾀﾞｰ高さ
                
                '@列幅設定
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort2.blnChgWidth = False Then
                    .Cols(CMlngvsfList2ColNo).Width = CMlngvsfList2ColWNo                   '№
                    .Cols(CMlngvsfList2ColItem1).Width = CMlngvsfList2ColwItem1             '装置ﾊﾟﾗﾒｰﾀ1
                    .Cols(CMlngvsfList2ColItem2).Width = CMlngvsfList2ColwItem2             '装置ﾊﾟﾗﾒｰﾀ2
                    .Cols(CMlngvsfList2ColItem3).Width = CMlngvsfList2ColwItem3             '装置ﾊﾟﾗﾒｰﾀ3
                    .Cols(CMlngvsfList2ColItem4).Width = CMlngvsfList2ColwItem4             '装置ﾊﾟﾗﾒｰﾀ4
                End If
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfTRow, CMlngvsfList2ColNo, CMstrvsfList2ColTNo)             '№
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem1, CMstrvsfList2ColtItem1)       '装置ﾊﾟﾗﾒｰﾀ1
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem2, CMstrvsfList2ColtItem2)       '装置ﾊﾟﾗﾒｰﾀ2
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem3, CMstrvsfList2ColtItem3)       '装置ﾊﾟﾗﾒｰﾀ3
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem4, CMstrvsfList2ColtItem4)       '装置ﾊﾟﾗﾒｰﾀ4
                '@非表示Col設定
                '@なし
                
                '@表示ﾌｫｰﾏｯﾄ
                .Cols(CMlngvsfList2ColNo).TextAlign = TextAlignEnum.RightCenter             '№（右中央）
                .Cols(CMlngvsfList2ColItem1).TextAlign = TextAlignEnum.RightCenter          '装置ﾊﾟﾗﾒｰﾀ1（右中央）
                .Cols(CMlngvsfList2ColItem2).TextAlign = TextAlignEnum.RightCenter          '装置ﾊﾟﾗﾒｰﾀ2（右中央）
                .Cols(CMlngvsfList2ColItem3).TextAlign = TextAlignEnum.RightCenter          '装置ﾊﾟﾗﾒｰﾀ3（右中央）
                .Cols(CMlngvsfList2ColItem4).TextAlign = TextAlignEnum.RightCenter          '装置ﾊﾟﾗﾒｰﾀ4（右中央）
                
                '@ﾊﾞｯｸｶﾗｰの変更(入力不可色：ｸﾞﾚｰ)
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngvsfList2ColNo)
                cellRange.Style = newStyle     '№
                
                '@スロットの高さの設定
                .Rows(.Rows.Fixed).Height = CMlngvsfBHeight
                
                '@非表示Col
                '@なし
                
                '@ﾊﾞｯﾌｧ経由で描画
                .Redraw = True
                
                '@ﾛｯｸ
                .Enabled = False
                .AllowEditing = True
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfFbData2_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfRecipeCopy_init
    '機　能：ﾊﾟﾗﾒｰﾀｺﾋﾟｰｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2023/12/25 (Mon) 15:52:00 T.Oide
    '更新日：2023/12/25 (Mon) 15:52:00
    '備　考：
    Private Sub prvvsfRecipeCopy_init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfRecipeCopy
                '描画なし
                .Redraw = False
                'ｸﾞﾘｯﾄﾞの行設定
                .Rows.Count = .Rows.Fixed
                'ｸﾞﾘｯﾄﾞの列設定
                .Cols.Count = CMlngvsf3ColS
                '固定列の設定
                '.Cols.Frozen = 1
                'ｸﾞﾘｯﾄﾞ設定
                '.AllowBigSelection = False                                 'ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowSelection = False                                    'ﾏｳｽでｾﾙ範囲選択不可
                .SelectionMode = SelectionModeEnum.Row                      '行選択
                '.FillStyle = flexFillRepeat                                'ﾌﾟﾛﾊﾟﾃｨの設定対象（選択ｾﾙ）
                .FocusRect = FocusRectEnum.Light                            'ｶﾚﾝﾄｾﾙのﾌｫｰｶｽ枠（細い枠）
                .ScrollBars = ScrollBars.None                               'ｽｸﾛｰﾙﾊﾞｰ（なし）
                '.AutoSizeMode = flexAutoSizeColWidth                       'ｵｰﾄｻｲｽﾞ（列）
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter  '文字列の最後に省略符号
                '.AllowUserResizing = flexResizeColumns                     '列幅の変更許可
                .ExtendLastCol = True                                       '右端の列をｸﾞﾘｯﾄﾞに合わせる
                .AllowSorting = AllowSortingEnum.None                       'ﾍｯﾀﾞｰｸﾘｯｸでｿｰﾄしない

				'一覧のﾀｲﾄﾙ設定
				.Select(CMlngvsfTRow, CMlngvsfListColNo, CMlngvsfTRow, .Cols.Count - 1)
				Dim lFixedStyle As CellStyle
				lFixedStyle = .Styles.Fixed
				lFixedStyle.Font = New Font(lFixedStyle.Font.FontFamily, CMlngVsfHFontSize3, _
											lFixedStyle.Font.Style, lFixedStyle.Font.Unit)  'ﾌｫﾝﾄｻｲｽﾞ
				lFixedStyle.ForeColor = Color.Yellow                                        '文字色
				lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)           '背景色
				lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                          '配置
				lFixedStyle.Trimming = StringTrimming.None                                  'ヘッダー文字列を省略表示しない
				.Rows(CMlngvsfTRow).Height = CMlngVsfHHeight                                'ﾍｯﾀﾞｰ高さ
				
				'@列幅設定
				.Cols(CMintvsfCopyRecipe).Width = CMintvsfCopyWRecipe                       'ｺﾋﾟｰ元ﾚｼﾋﾟ
				.Cols(CMintvsfCopyGouki).Width = CMintvsfCopyWGouki							'ﾚｼﾋﾟ登録号機(元)
				.Cols(CMintvsfCopyCpRecipe).Width = CMintvsfCopyWCpRecipe                   'ｺﾋﾟｰ先ﾚｼﾋﾟ
				.Cols(CMintvsfCopyCpGouki).Width = CMintvsfCopyWCpGouki						'ﾚｼﾋﾟ登録号機(先)

				'@ﾀｲﾄﾙ設定
				.SetData(CMlngvsfTRow, CMintvsfCopyRecipe, CMintvsfCopyTRecipe)             'ｺﾋﾟｰ元ﾚｼﾋﾟ
				.SetData(CMlngvsfTRow, CMintvsfCopyGouki, CMintvsfCopyTGouki)				'ﾚｼﾋﾟ登録号機(元)
				.SetData(CMlngvsfTRow, CMintvsfCopyCpRecipe, CMintvsfCopyTCpRecipe)         'ｺﾋﾟｰ先ﾚｼﾋﾟ
				.SetData(CMlngvsfTRow, CMintvsfCopyCpGouki, CMintvsfCopyTCpGouki)			'ﾚｼﾋﾟ登録号機(先)

				'@表示ﾌｫｰﾏｯﾄ
				.Cols(CMintvsfCopyRecipe).TextAlign = TextAlignEnum.LeftCenter				'ｺﾋﾟｰ元ﾚｼﾋﾟ（左中央）
				.Cols(CMintvsfCopyGouki).TextAlign = TextAlignEnum.LeftCenter				'ﾚｼﾋﾟ登録号機(元)（左中央）
				.Cols(CMintvsfCopyCpRecipe).TextAlign = TextAlignEnum.LeftCenter			'ｺﾋﾟｰ先ﾚｼﾋﾟ（左中央）
				.Cols(CMintvsfCopyCpGouki).TextAlign = TextAlignEnum.LeftCenter				'ﾚｼﾋﾟ登録号機(先)（左中央）

				''ﾊﾞｯｸｶﾗｰの変更(入力不可色：ｸﾞﾚｰ)
				'Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
				'newStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
				'Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngvsfListColNo)
				'cellRange.Style = newStyle      '№

                '@直接描画
                .Redraw = True
                
                '@ﾛｯｸ
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfRecipeCopy_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMainForm_Init
    '機　能：画面初期設定
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/14 (Tue) 17:48:40 N.Kasai
    '更新日：2017/03/10 (Fri) 17:12:46 T.Oide
    '備　考：
    Private Sub prvMainForm_Init()

        Dim lstrFormTitle           As String   'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim llngNowByte             As Integer  '現在文字数
        
        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01U0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            'NSYS 画面表示位置
            Me.StartPosition = FormStartPosition.Manual
            Me.Top  = 0
            Me.Left = 0 - My.Settings.FormOffset
            
            '@ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString                      '情報取得日時
            lblLotCnt.Text = vbNullString                       '該当件数
            
            lblNowDate2.Text = vbNullString                     '情報取得日時
            lblLotCnt2.Text = vbNullString                      '該当件数

            lblShotSeparateFlag.Text = vbNullString             'Shot分離
           
            '@ｺﾝﾎﾞﾎﾞｯｸｽ
            cmbWp.Enabled = False                               'ﾌｫﾄ号機(合せ)
            cmbReferenceWP.Enabled = False                            '1stﾌｫﾄ号機
            cmbWP2.Enabled = False                              'ﾌｫﾄ号機(露光)
            cmbPatchNo.Enabled = False                          'PatchNo(APC設定の「ﾌｫﾄF/B(合せ)」のPatch分割設定

            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfFbDataList_init()                        'ﾃﾞｰﾀﾘｽﾄ(合せ)
            Call prvvsfFbData_init()                            'ﾃﾞｰﾀ(露光)
            Call prvvsfFbDataList2_init()                       'ﾃﾞｰﾀﾘｽﾄ(合せ)
            Call prvvsfFbData2_init()                           'ﾃﾞｰﾀ(露光)
            Call prvvsfRecipeCopy_init()						'ﾃﾞｰﾀｺﾋﾟｰ
			
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ
            cmdUP.Enabled = False                               '前ﾍﾟｰｼﾞ(合せ)
            cmdDown.Enabled = False                             '次ﾍﾟｰｼﾞ(合せ)
            cmdLeft.Enabled = False                             '左ﾎﾞﾀﾝ(合せ)
            cmdRight.Enabled = False                            '右ﾎﾞﾀﾝ(合せ)
            cmdSearch.Enabled = False                           '最新取得ﾎﾞﾀﾝ(合せ)
            cmdCommentUp.Enabled = False                        'ｺﾒﾝﾄ▲ﾎﾞﾀﾝ(合せ)
            cmdCommentDown.Enabled = False                      'ｺﾒﾝﾄ▼ﾎﾞﾀﾝ(合せ)
            
            cmdUP2.Enabled = False                              '前ﾍﾟｰｼﾞ(露光)
            cmdDown2.Enabled = False                            '次ﾍﾟｰｼﾞ(露光)
            cmdLeft2.Enabled = False                            '左ﾎﾞﾀﾝ(露光)
            cmdRight2.Enabled = False                           '右ﾎﾞﾀﾝ(露光)
            cmdSearch2.Enabled = False                          '最新取得ﾎﾞﾀﾝ(露光)
            cmdCommentUp2.Enabled = False                       'ｺﾒﾝﾄ▲ﾎﾞﾀﾝ(露光)
            cmdCommentDown2.Enabled = False                     'ｺﾒﾝﾄ▼ﾎﾞﾀﾝ(露光)
            
            cmdProcEnd.Enabled = False                          '確定ﾎﾞﾀﾝ(共通)
            cmdCopy.Enabled = False                             '行ｺﾋﾟｰ(共通)
            cmdPaste.Enabled = False                            '行貼り付け(共通)

            cmdPatDivSet.Enabled = False                        'patch分割設定
            cmdClipCopy.Enabled = False                         'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
            cmdClipPaste.Enabled = False                        'ｸﾘｯﾌﾟﾎﾞｰﾄﾞﾍﾟｰｽﾄ

            '@ﾃｷｽﾄの初期化
            txtRecipeID.Text = vbNullString                     'ﾚｼﾋﾟID(合せ)
            txtRecipeID2.Text = vbNullString                    'ﾚｼﾋﾟID(露光)
            
            With txtComments
                .Text = vbNullString                            'ｺﾒﾝﾄ
                '@使用不可
                .Locked = True
                .BackColor = SystemColors.ControlLight
                .GotBackColor = SystemColors.ControlLight
                '@現状のﾊﾞｲﾄ数を格納
                llngNowByte = .NowByte
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
                '@非表示
                lblLengthCount.Visible = False
            End With
            
            With txtComments2
                .Text = vbNullString                            'ｺﾒﾝﾄ
                '@使用不可
                .Locked = True
                .BackColor = SystemColors.ControlLight
                .GotBackColor = SystemColors.ControlLight
                '@現状のﾊﾞｲﾄ数を格納
                llngNowByte = .NowByte
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblLengthCount2.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
                '@非表示
                lblLengthCount2.Visible = False
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMainForm_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfFbDataList_Disp
    '機　能：ﾌｫﾄF/Bﾃﾞｰﾀ一覧
    '引　数：lngPatchNo:CmbpatchNoの値(この値が0以外の場合はｺﾝﾎﾞの変更で関数が呼ばれている)
    '戻り値：なし
    '作成日：2006/03/10 (Fri) 19:31:44 N.Kasai
    '更新日：2017/01/20 (Fri) 10:27:21 T.Oide
    '備　考：
    '　　　：2006/06/20 (Tue) 13:46:38 N.Kojima     ltypPhotoFbDataListAns個所を、全てmtypPhotoFbDataListAnsに変換。(R3-4指摘)
    Private Sub prvvsfFbDataList_Disp(ByVal lngPatchNo As Integer)

        Dim llngDoCnt                   As Integer  'Doの回数ｶｳﾝﾄ
        Dim llngCnt                     As Integer  '汎用ｶｳﾝﾄ（ｿｰﾄ用に使用）
        Dim lstrTmpShiftX               As String       'ﾊﾟﾗﾒｰﾀ1
        Dim lstrTmpShiftY               As String       'ﾊﾟﾗﾒｰﾀ2
        Dim lstrTmpWaferMagX            As String       'ﾊﾟﾗﾒｰﾀ3
        Dim lstrTmpWaferMagY            As String       'ﾊﾟﾗﾒｰﾀ4
        Dim lstrTmpaferRotX             As String       'ﾊﾟﾗﾒｰﾀ5
        Dim lstrTmpWaferRotY            As String       'ﾊﾟﾗﾒｰﾀ6
        Dim lstrTmpShotRot              As String       'ﾊﾟﾗﾒｰﾀ7
        Dim lstrTmpShotMag              As String       'ﾊﾟﾗﾒｰﾀ8
        Dim lstrTmpShotRotX             As String       'ﾊﾟﾗﾒｰﾀ9
        Dim lstrTmpShotRotY             As String       'ﾊﾟﾗﾒｰﾀ10
        Dim lstrTmpShotMagX             As String       'ﾊﾟﾗﾒｰﾀ11
        Dim lstrTmpShotMagY             As String       'ﾊﾟﾗﾒｰﾀ12
        Dim lstrTitleNo                 As String       'タイトルの末尾(_1～_9)
        Dim llngPatchNo                 As Integer      'ﾊﾟｯﾁNo
        
        Try
            
            If lngPatchNo = CPlngPatchNoNasi Then
                '@patchNoｺﾝﾎﾞ設定
                mblnEventCancelFlag = True
                Call prvSetcmbPatchNo(ptypPhotoFbDataListAns.lngPatchDivideNum)
                mblnEventCancelFlag = False
            End If
            
            '@入力欄表示
            With vsfFbData
                '@描画なし
                .Redraw = False
                
                '@「ﾊﾟｯﾁ分割あり」か
                If cmbPatchNo.Enabled = True Then
                    '@ﾀｲﾄﾙの末尾に"_N"を付ける
                    lstrTitleNo = "_" & cmbPatchNo.Text
                Else
                    lstrTitleNo = vbNullString
                End If
                
                '@ﾀｲﾄﾙ設定(入力）
                .SetData(CMlngvsfTRow, CMlngvsfListColItem1, ptypPhotoFbDataListAns.strShiftXItemName & lstrTitleNo)        'ﾊﾟﾗﾒｰﾀ1
                .SetData(CMlngvsfTRow, CMlngvsfListColItem2, ptypPhotoFbDataListAns.strShiftYItemName & lstrTitleNo)        'ﾊﾟﾗﾒｰﾀ2
                .SetData(CMlngvsfTRow, CMlngvsfListColItem3, ptypPhotoFbDataListAns.strWaferMagXItemName & lstrTitleNo)     'ﾊﾟﾗﾒｰﾀ3
                .SetData(CMlngvsfTRow, CMlngvsfListColItem4, ptypPhotoFbDataListAns.strWaferMagYItemName & lstrTitleNo)     'ﾊﾟﾗﾒｰﾀ4
                .SetData(CMlngvsfTRow, CMlngvsfListColItem5, ptypPhotoFbDataListAns.strWaferRotXItemName & lstrTitleNo)     'ﾊﾟﾗﾒｰﾀ5
                .SetData(CMlngvsfTRow, CMlngvsfListColItem6, ptypPhotoFbDataListAns.strWaferRotYItemName & lstrTitleNo)     'ﾊﾟﾗﾒｰﾀ6
                .SetData(CMlngvsfTRow, CMlngvsfListColItem7, ptypPhotoFbDataListAns.strShotRotItemName & lstrTitleNo)       'ﾊﾟﾗﾒｰﾀ7
                .SetData(CMlngvsfTRow, CMlngvsfListColItem8, ptypPhotoFbDataListAns.strShotMagItemName & lstrTitleNo)       'ﾊﾟﾗﾒｰﾀ8
                'Shot分離
                .SetData(CMlngvsfTRow, CMlngvsfListColItem9, ptypPhotoFbDataListAns.strShotRotXItemName & lstrTitleNo)      'ﾊﾟﾗﾒｰﾀ9
                .SetData(CMlngvsfTRow, CMlngvsfListColItem10, ptypPhotoFbDataListAns.strShotRotYItemName & lstrTitleNo)     'ﾊﾟﾗﾒｰﾀ10
                .SetData(CMlngvsfTRow, CMlngvsfListColItem11, ptypPhotoFbDataListAns.strShotMagXItemName & lstrTitleNo)     'ﾊﾟﾗﾒｰﾀ11
                .SetData(CMlngvsfTRow, CMlngvsfListColItem12, ptypPhotoFbDataListAns.strShotMagYItemName & lstrTitleNo)     'ﾊﾟﾗﾒｰﾀ12
                
                '@ﾌｫｰﾏｯﾄにより四捨五入
                .Cols(CMlngvsfListColItem1).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShiftXValidDigit)      'ﾊﾟﾗﾒｰﾀ1【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem2).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShiftYValidDigit)      'ﾊﾟﾗﾒｰﾀ2【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem3).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferMagXValidDigit)   'ﾊﾟﾗﾒｰﾀ3【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem4).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferMagYValidDigit)   'ﾊﾟﾗﾒｰﾀ4【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem5).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferRotXValidDigit)   'ﾊﾟﾗﾒｰﾀ5【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem6).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferRotYValidDigit)   'ﾊﾟﾗﾒｰﾀ6【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem7).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotValidDigit)     'ﾊﾟﾗﾒｰﾀ7【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem8).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagValidDigit)     'ﾊﾟﾗﾒｰﾀ8【ﾌｫｰﾏｯﾄ】
                'Shot分離
                .Cols(CMlngvsfListColItem9).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotXValidDigit)    'ﾊﾟﾗﾒｰﾀ9【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem10).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotYValidDigit)   'ﾊﾟﾗﾒｰﾀ10【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem11).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagXValidDigit)   'ﾊﾟﾗﾒｰﾀ11【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem12).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagYValidDigit)   'ﾊﾟﾗﾒｰﾀ12【ﾌｫｰﾏｯﾄ】

                .Enabled = True
                '@直接描画
                .Redraw = True
            End With
            
            mstrEntryTime = vbNullString
            
            '@一覧表示
            With vsfFbDataList
                '@描画なし
                .Redraw = False
                '@行数設定
                .Rows.Count = .Rows.Fixed
                RemoveHandler vsfFbDataList.BeforeRowColChange, AddressOf vsfFbDataList_BeforeRowColChange
                RemoveHandler vsfFbDataList.AfterRowColChange, AddressOf vsfFbDataList_AfterRowColChange
                .Rows.Count = ptypPhotoFbDataListAns.lngFbDataItemListCnt + 1
                AddHandler vsfFbDataList.BeforeRowColChange, AddressOf vsfFbDataList_BeforeRowColChange
                AddHandler vsfFbDataList.AfterRowColChange, AddressOf vsfFbDataList_AfterRowColChange
                '@ｶｳﾝﾀの初期化
                llngDoCnt = 0
                
                '@ﾀｲﾄﾙ設定(一覧）
                .SetData(CMlngvsfTRow, CMlngvsfListColItem1, ptypPhotoFbDataListAns.strShiftXItemName & lstrTitleNo)        'ﾊﾟﾗﾒｰﾀ1
                .SetData(CMlngvsfTRow, CMlngvsfListColItem2, ptypPhotoFbDataListAns.strShiftYItemName & lstrTitleNo)        'ﾊﾟﾗﾒｰﾀ2
                .SetData(CMlngvsfTRow, CMlngvsfListColItem3, ptypPhotoFbDataListAns.strWaferMagXItemName & lstrTitleNo)     'ﾊﾟﾗﾒｰﾀ3
                .SetData(CMlngvsfTRow, CMlngvsfListColItem4, ptypPhotoFbDataListAns.strWaferMagYItemName & lstrTitleNo)     'ﾊﾟﾗﾒｰﾀ4
                .SetData(CMlngvsfTRow, CMlngvsfListColItem5, ptypPhotoFbDataListAns.strWaferRotXItemName & lstrTitleNo)     'ﾊﾟﾗﾒｰﾀ5
                .SetData(CMlngvsfTRow, CMlngvsfListColItem6, ptypPhotoFbDataListAns.strWaferRotYItemName & lstrTitleNo)     'ﾊﾟﾗﾒｰﾀ6
                .SetData(CMlngvsfTRow, CMlngvsfListColItem7, ptypPhotoFbDataListAns.strShotRotItemName & lstrTitleNo)       'ﾊﾟﾗﾒｰﾀ7
                .SetData(CMlngvsfTRow, CMlngvsfListColItem8, ptypPhotoFbDataListAns.strShotMagItemName & lstrTitleNo)       'ﾊﾟﾗﾒｰﾀ8
                'Shot分離
                .SetData(CMlngvsfTRow, CMlngvsfListColItem9, ptypPhotoFbDataListAns.strShotRotXItemName & lstrTitleNo)      'ﾊﾟﾗﾒｰﾀ9
                .SetData(CMlngvsfTRow, CMlngvsfListColItem10, ptypPhotoFbDataListAns.strShotRotYItemName & lstrTitleNo)     'ﾊﾟﾗﾒｰﾀ10
                .SetData(CMlngvsfTRow, CMlngvsfListColItem11, ptypPhotoFbDataListAns.strShotMagXItemName & lstrTitleNo)     'ﾊﾟﾗﾒｰﾀ11
                .SetData(CMlngvsfTRow, CMlngvsfListColItem12, ptypPhotoFbDataListAns.strShotMagYItemName & lstrTitleNo)     'ﾊﾟﾗﾒｰﾀ12
                
                '@ﾌｫｰﾏｯﾄにより四捨五入
                .Cols(CMlngvsfListColItem1).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShiftXValidDigit)      'ﾊﾟﾗﾒｰﾀ1【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem2).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShiftYValidDigit)      'ﾊﾟﾗﾒｰﾀ2【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem3).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferMagXValidDigit)   'ﾊﾟﾗﾒｰﾀ3【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem4).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferMagYValidDigit)   'ﾊﾟﾗﾒｰﾀ4【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem5).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferRotXValidDigit)   'ﾊﾟﾗﾒｰﾀ5【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem6).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferRotYValidDigit)   'ﾊﾟﾗﾒｰﾀ6【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem7).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotValidDigit)     'ﾊﾟﾗﾒｰﾀ7【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem8).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagValidDigit)     'ﾊﾟﾗﾒｰﾀ8【ﾌｫｰﾏｯﾄ】
                'Shot分離
                .Cols(CMlngvsfListColItem9).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotXValidDigit)    'ﾊﾟﾗﾒｰﾀ9【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem10).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotYValidDigit)   'ﾊﾟﾗﾒｰﾀ10【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem11).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagXValidDigit)   'ﾊﾟﾗﾒｰﾀ11【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem12).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagYValidDigit)   'ﾊﾟﾗﾒｰﾀ12【ﾌｫｰﾏｯﾄ】

                'Shot分離有無
                If ptypPhotoFbDataListAns.strShotSeparateFlag = CPstrFlagOn Then
                    lblShotSeparateFlag.Text = CPstrAriFlg
                Else
                    lblShotSeparateFlag.Text = CPstrNasiFlg
                End If

                '@ﾌｫﾄF/Bﾃﾞｰﾀ一覧表示
                Do While .Rows.Count - 1 > llngDoCnt
                
                    '@ﾊﾟｯﾁNoｺﾝﾎﾞの設定は空か
                    If cmbPatchNo.Text = vbNullString Then
                        llngPatchNo = 0
                    Else
                        llngPatchNo = CLng(cmbPatchNo.Text)
                    End If
                    
                    '@ﾊﾟｯﾁ№に応じた値を取得
                    Call pubSetPatchNoItems(llngPatchNo, llngDoCnt, _
                                            lstrTmpShiftX, lstrTmpShiftY, _
                                            lstrTmpWaferMagX, lstrTmpWaferMagY, _
                                            lstrTmpaferRotX, lstrTmpWaferRotY, _
                                            lstrTmpShotRot, lstrTmpShotMag, _
                                            lstrTmpShotRotX, lstrTmpShotRotY, _
                                            lstrTmpShotMagX, lstrTmpShotMagY)
                                            
                    If IsNumeric(lstrTmpShiftX) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem1, CDbl(lstrTmpShiftX))       'ShiftX
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem1, lstrTmpShiftX)
                    End If

                    If IsNumeric(lstrTmpShiftY) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem2, CDbl(lstrTmpShiftY))       'ShiftY
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem2, lstrTmpShiftY)
                    End If

                    If IsNumeric(lstrTmpWaferMagX) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem3, CDbl(lstrTmpWaferMagX))    'WaferMagX
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem3, lstrTmpWaferMagX)
                    End If

                    If IsNumeric(lstrTmpWaferMagY) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem4, CDbl(lstrTmpWaferMagY))    'WaferMagY
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem4, lstrTmpWaferMagY)
                    End If

                    If IsNumeric(lstrTmpaferRotX) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem5, CDbl(lstrTmpaferRotX))     'WaferRotX
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem5, lstrTmpaferRotX)
                    End If

                    If IsNumeric(lstrTmpWaferRotY) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem6, CDbl(lstrTmpWaferRotY))    'WaferRotY
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem6, lstrTmpWaferRotY)
                    End If

                    If IsNumeric(lstrTmpShotRot) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem7, CDbl(lstrTmpShotRot))      'ShotRot
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem7, lstrTmpShotRot)
                    End If

                    If IsNumeric(lstrTmpShotMag) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem8, CDbl(lstrTmpShotMag))      'ShotMag
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem8, lstrTmpShotMag)
                    End If

                    'Shot分離
                    If IsNumeric(lstrTmpShotRotX) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem9, CDbl(lstrTmpShotRotX))      
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem9, lstrTmpShotRotX)
                    End If

                    If IsNumeric(lstrTmpShotRotY) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem10, CDbl(lstrTmpShotRotY))      
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem10, lstrTmpShotRotY)
                    End If

                    If IsNumeric(lstrTmpShotMagX) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem11, CDbl(lstrTmpShotMagX))      
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem11, lstrTmpShotMagX)
                    End If

                    If IsNumeric(lstrTmpShotMagY) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem12, CDbl(lstrTmpShotMagY))      
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColItem12, lstrTmpShotMagY)
                    End If

                    .SetData(llngDoCnt + 1, CMlngvsfListColFbLot, _
                            ptypPhotoFbDataListAns.typFbDataItemList(llngDoCnt).strFbCalcLots)   'FB計算対象ﾛｯﾄ


                    '@排他制御用に最新のENTRY_TIMEを退避する。
                    If llngDoCnt = 0 Then
                        mstrEntryTime = ptypPhotoFbDataListAns.typFbDataItemList(llngDoCnt).strEntryTime
                    End If
                    '@TIMESTAMP型なのでCLでﾌｫｰﾏｯﾄする。
                    If IsDate(ptypPhotoFbDataListAns.typFbDataItemList(llngDoCnt).strEntryTime) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColEditTime, _
                                Format$(CDate(Strings.Left$(ptypPhotoFbDataListAns.typFbDataItemList(llngDoCnt).strEntryTime, _
                                Len(ptypPhotoFbDataListAns.typFbDataItemList(llngDoCnt).strEntryTime) - 4)), CPstrDateTimeYMDHMS))    '最終更新日時
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColEditTime, vbNullString)
                    End If
                    
                    .SetData(llngDoCnt + 1, CMlngvsfListColEditEmp, _
                            ptypPhotoFbDataListAns.typFbDataItemList(llngDoCnt).strEmpName)              '最終更新者
                    .SetData(llngDoCnt + 1, CMlngvsfListColComments, _
                            ptypPhotoFbDataListAns.typFbDataItemList(llngDoCnt).strComments)             'ｺﾒﾝﾄ
                            
                    '@ｽﾛｯﾄの高さの設定
                    .Rows(llngDoCnt + 1).Height = CMlngvsfBHeight
                    llngDoCnt = llngDoCnt + 1
                Loop

                '@№設定
                For llngDoCnt = 1 To .Rows.Count - 1
                    .SetData(llngDoCnt, CMlngvsfListColNo, llngDoCnt)
                Next llngDoCnt
                
                '@ﾃﾞｰﾀ件数の確認
                If .Rows.Count > .Rows.Fixed Then
                    '@ﾊﾞｯｸｶﾗｰの変更(入力不可色：ｸﾞﾚｰ)
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                    Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngvsfListColNo, .Rows.Count - 1, .Cols.Count - 1)
                    cellRange.Style = newStyle

                    RemoveHandler vsfFbDataList.BeforeRowColChange, AddressOf vsfFbDataList_BeforeRowColChange
                    RemoveHandler vsfFbDataList.AfterRowColChange, AddressOf vsfFbDataList_AfterRowColChange

                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt - 1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    'NSYS ヘッダー行を選択
                    .Row = 0
                    .TopRow = 0
                
                    AddHandler vsfFbDataList.BeforeRowColChange, AddressOf vsfFbDataList_BeforeRowColChange
                    AddHandler vsfFbDataList.AfterRowColChange, AddressOf vsfFbDataList_AfterRowColChange
                    
                    '@ｵｰﾄ幅設定
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort.blnChgWidth = False Then
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCols(CMlngvsfListColFbLot, CMlngvsfListColEditEmp, 6)
                    End If
                    
                    '@左右ｽｸﾛｰﾙ制御の記述
                    '@ｶﾚﾝﾄ列初期化
                    .Col = .Cols.Fixed
                    .LeftCol = .Cols.Fixed

                    '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御（ｸﾞﾘｯﾄﾞ共通化関数）
                    Call pubCmdLREnable_Set(vsfFbDataList, cmdLeft, cmdRight)

                    '@前ﾍﾟｰｼﾞ、次ﾍﾟｰｼﾞ、ｽｸﾛｰﾙﾗﾍﾞﾙ表示設定
                    If .Rows.Count > 1 Then
                        cmdUP.Enabled = True
                        cmdDown.Enabled = True
            
                        '@ｸﾞﾘｯﾄﾞﾎﾞﾀﾝ制御、保持値ｸﾘｱ
                        Call pubVsfDisp(vsfFbDataList, cmdUP, cmdDown)
                    Else
                        cmdUP.Enabled = False
                        cmdDown.Enabled = False
                    End If
                 
                    '@該当件数ﾗﾍﾞﾙに取得件数を表示
                    If .Rows.Count - 1 >= CMlngDisplayMaxCnt Then
                        '@該当件数が500件以上の場合は、"最大500"を表示する
                        lblLotCnt.Text = CMstrDisplayMax & Format$(.Rows.Count - 1, CPstrDateFormatKanma)
                        '@ﾌｫﾝﾄｻｲｽﾞ1下げ
                        lblLotCnt.Font = New Font(lblLotCnt.Font.Name, 12.75, FontStyle.Regular)
                    Else
                        lblLotCnt.Text = Format$(.Rows.Count - 1, CPstrDateFormatKanma)
                        '@標準ﾌｫﾝﾄ
                        lblLotCnt.Font = New Font(lblLotCnt.Font.Name, 14.25, FontStyle.Regular)
                    End If
                    '@ﾛｯｸ解除
                    .Enabled = True
                Else
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用不可
                    cmdLeft.Enabled = False
                    cmdRight.Enabled = False
                    cmdUP.Enabled = False
                    cmdDown.Enabled = False
                
                    '@該当ﾃﾞｰﾀが存在しない場合
                    lblLotCnt.Text = 0
                    '@ﾛｯｸ
                    .Enabled = False
                End If
                
                '@行ｺﾋﾟｰﾌﾗｸﾞ（ON)
                If mblnCpoyLineFlag = True Then
                    cmdPaste.Enabled = True
                Else
                    cmdPaste.Enabled = False
                End If
                
                '@patch分割設対象外 or 分割なしか(1は分割なし、0はありえないはずだが一応)
                If ptypPhotoFbDataListAns.strPatchDivideNumRecipe = vbNullString Or _
                   ptypPhotoFbDataListAns.strPatchDivideNumRecipe = "0" Or _
                   ptypPhotoFbDataListAns.strPatchDivideNumRecipe = "1" Then
                   
                    '@ﾊﾟｯﾁ分割なしor対象外の場合
                    vsfFbData.AllowEditing = True       'ﾃﾞｰﾀ設定ｸﾞﾘｯﾄﾞ編集可
                Else
                
                    '@ﾊﾟｯﾁ分割ありの場合
                    vsfFbData.AllowEditing = False      'ﾃﾞｰﾀ設定ｸﾞﾘｯﾄﾞ編集不可
                End If                
                
        '@↓2017/01/20 (Fri) 11:23:20 T.Oide **************************************************
        '@        '@情報取得日時表示
        '@        lblNowDate.Caption = Format$(Now, CPstrDateFormat)
        '@
                '@情報取得日時表示
                If lngPatchNo = CPlngPatchNoNasi Then
                    '@情報取得日時表示
                    lblNowDate.Text = Format$(Now, CPstrDateFormat)
                End If
        '@↑2017/01/20 (Fri) 11:23:20 T.Oide **************************************************

                '@直接描画
                .Redraw = True
            
            End With
            
            '@入力欄表示
            With vsfFbData
                'Shot分離なし
                If lblShotSeparateFlag.Text <> CPstrAriFlg Then
                    '@ﾊﾞｯｸｶﾗｰの変更(入力不可色：ｸﾞﾚｰ)
                    Dim newShotStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                    newShotStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                    Dim cellShot As CellRange = .GetCellRange(.Rows.Count - 1, CMlngvsfListColItem9, .Rows.Count - 1, CMlngvsfListColItem12)
                    cellShot.Style = newShotStyle

                ’Shot分離あり
                Else
                    '@ﾊﾞｯｸｶﾗｰの変更(入力不可色：ｸﾞﾚｰ)
                    Dim newShotStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                    newShotStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                    Dim cellShot As CellRange = .GetCellRange(.Rows.Count - 1, CMlngvsfListColItem7, .Rows.Count - 1, CMlngvsfListColItem8)
                    cellShot.Style = newShotStyle

                End If
            End With                                
                
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ有効/無効設定
            Call prvCmdButton_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfFbDataList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfFbDataList2_Disp
    '機　能：ｸﾞﾘｯﾄﾞ表示(露光)
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:57:06 N.Kasai
    '更新日：2007/09/18 (Tue) 10:57:06
    '備　考：
    Private Sub prvvsfFbDataList2_Disp()

        Dim llngDoCnt               As Integer  'Doの回数ｶｳﾝﾄ
        Dim llngCnt                 As Integer  '汎用ｶｳﾝﾄ（ｿｰﾄ用に使用）
        
        Try
            
            '@入力欄表示
            With vsfFbData2
                '@描画なし
                .Redraw = False
                '@ﾀｲﾄﾙ設定(入力）
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem1, mtypPhotoFbDataList2Ans.strExposureLowerLimitItemName)  'ﾊﾟﾗﾒｰﾀ1
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem2, mtypPhotoFbDataList2Ans.strExposureItemName)            'ﾊﾟﾗﾒｰﾀ2
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem3, mtypPhotoFbDataList2Ans.strExposureUpperLimitItemName)  'ﾊﾟﾗﾒｰﾀ3
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem4, mtypPhotoFbDataList2Ans.strFocusOffsetItemName)         'ﾊﾟﾗﾒｰﾀ4
                
                '@ﾌｫｰﾏｯﾄにより四捨五入
                .Cols(CMlngvsfList2ColItem1).Format = pubStrFormatValue_Set(mtypPhotoFbDataList2Ans.strExposureLowerLimitValidDigit) 'ﾊﾟﾗﾒｰﾀ1【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfList2ColItem2).Format = pubStrFormatValue_Set(mtypPhotoFbDataList2Ans.strExposureValidDigit)           'ﾊﾟﾗﾒｰﾀ2【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfList2ColItem3).Format = pubStrFormatValue_Set(mtypPhotoFbDataList2Ans.strExposureUpperLimitValidDigit) 'ﾊﾟﾗﾒｰﾀ3【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfList2ColItem4).Format = pubStrFormatValue_Set(mtypPhotoFbDataList2Ans.strFocusOffsetValidDigit)        'ﾊﾟﾗﾒｰﾀ4【ﾌｫｰﾏｯﾄ】
                
                .Enabled = True
                '@直接描画
                .Redraw = True
            End With
            
            '@退避変数の初期化
            mstrEntryTime2 = vbNullString
            
            '@一覧表示
            With vsfFbDataList2
                '@描画なし
                .Redraw = False
                '@行数設定
                .Rows.Count = .Rows.Fixed
                RemoveHandler vsfFbDataList2.BeforeRowColChange, AddressOf vsfFbDataList2_BeforeRowColChange
                RemoveHandler vsfFbDataList2.AfterRowColChange, AddressOf vsfFbDataList2_AfterRowColChange
                .Rows.Count = mtypPhotoFbDataList2Ans.lngFbDataItemList2Cnt + 1
                AddHandler vsfFbDataList2.BeforeRowColChange, AddressOf vsfFbDataList2_BeforeRowColChange
                AddHandler vsfFbDataList2.AfterRowColChange, AddressOf vsfFbDataList2_AfterRowColChange
                '@ｶｳﾝﾀの初期化
                llngDoCnt = 0
                
                '@ﾀｲﾄﾙ設定(一覧）
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem1, mtypPhotoFbDataList2Ans.strExposureLowerLimitItemName)  'ﾊﾟﾗﾒｰﾀ1
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem2, mtypPhotoFbDataList2Ans.strExposureItemName)            'ﾊﾟﾗﾒｰﾀ2
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem3, mtypPhotoFbDataList2Ans.strExposureUpperLimitItemName)  'ﾊﾟﾗﾒｰﾀ3
                .SetData(CMlngvsfTRow, CMlngvsfList2ColItem4, mtypPhotoFbDataList2Ans.strFocusOffsetItemName)         'ﾊﾟﾗﾒｰﾀ4
                
                '@ﾌｫｰﾏｯﾄにより四捨五入
                .Cols(CMlngvsfList2ColItem1).Format = pubStrFormatValue_Set(mtypPhotoFbDataList2Ans.strExposureLowerLimitValidDigit) 'ﾊﾟﾗﾒｰﾀ1【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfList2ColItem2).Format = pubStrFormatValue_Set(mtypPhotoFbDataList2Ans.strExposureValidDigit)           'ﾊﾟﾗﾒｰﾀ2【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfList2ColItem3).Format = pubStrFormatValue_Set(mtypPhotoFbDataList2Ans.strExposureUpperLimitValidDigit) 'ﾊﾟﾗﾒｰﾀ3【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfList2ColItem4).Format = pubStrFormatValue_Set(mtypPhotoFbDataList2Ans.strFocusOffsetValidDigit)        'ﾊﾟﾗﾒｰﾀ4【ﾌｫｰﾏｯﾄ】
                
                '@ﾌｫﾄF/Bﾃﾞｰﾀ一覧表示
                Do While .Rows.Count - 1 > llngDoCnt
                    If IsNumeric(mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strExposureLowerLimitValue) Then
                        .SetData(llngDoCnt + 1, CMlngvsfList2ColItem1, _
                                CDbl(mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strExposureLowerLimitValue))    'EXPOSURE_LOWER_LIMIT_VALUE
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfList2ColItem1, _
                                mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strExposureLowerLimitValue)
                    End If

                    If IsNumeric(mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strExposureValue) Then
                        .SetData(llngDoCnt + 1, CMlngvsfList2ColItem2, _
                                CDbl(mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strExposureValue))              'EXPOSURE_VALUE
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfList2ColItem2, _
                                mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strExposureValue)
                    End If

                    If IsNumeric(mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strExposureUpperLimitValue) Then
                        .SetData(llngDoCnt + 1, CMlngvsfList2ColItem3, _
                                CDbl(mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strExposureUpperLimitValue))    'EXPOSURE_UPPER_LIMIT_VALUE
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfList2ColItem3, _
                                mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strExposureUpperLimitValue)
                    End If

                    If IsNumeric(mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strFocusOffsetValue) Then
                        .SetData(llngDoCnt + 1, CMlngvsfList2ColItem4, _
                                CDbl(mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strFocusOffsetValue))           'FOCUSOFFSET_VALUE
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfList2ColItem4, _
                                mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strFocusOffsetValue)
                    End If
                    
                    '@排他制御用に最新のENTRY_TIMEを退避する。
                    If llngDoCnt = 0 Then
                        mstrEntryTime2 = mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strEntryTime
                    End If
                    '@TIMESTAMP型なのでCLでﾌｫｰﾏｯﾄする。
                    If IsDate(mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strEntryTime) Then
                        .SetData(llngDoCnt + 1, CMlngvsfList2ColEditTime, _
                                Format$(CDate(Strings.Left$(mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strEntryTime, _
                                Len(mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strEntryTime) - 4)), CPstrDateTimeYMDHMS))  '最終更新日時
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfList2ColEditTime, vbNullString)
                    End If

                    .SetData(llngDoCnt + 1, CMlngvsfList2ColEditEmp, _
                            mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strEmpName)                    '最終更新者
                    .SetData(llngDoCnt + 1, CMlngvsfList2ColComments, _
                            mtypPhotoFbDataList2Ans.typFbDataItemList2(llngDoCnt).strComments)                   'ｺﾒﾝﾄ
                            
                    '@ｽﾛｯﾄの高さの設定
                    .Rows(llngDoCnt + 1).Height = CMlngvsfBHeight
                    llngDoCnt = llngDoCnt + 1
                Loop

                '@№設定
                For llngDoCnt = 1 To .Rows.Count - 1
                    .SetData(llngDoCnt, CMlngvsfList2ColNo, llngDoCnt)
                Next llngDoCnt
                
                '@ﾃﾞｰﾀ件数の確認
                If .Rows.Count > .Rows.Fixed Then
                    '@ﾊﾞｯｸｶﾗｰの変更(入力不可色：ｸﾞﾚｰ)
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                    Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngvsfList2ColNo, .Rows.Count - 1, .Cols.Count - 1)
                    cellRange.Style = newStyle

                    RemoveHandler vsfFbDataList2.BeforeRowColChange, AddressOf vsfFbDataList2_BeforeRowColChange
                    RemoveHandler vsfFbDataList2.AfterRowColChange, AddressOf vsfFbDataList2_AfterRowColChange
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort2.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort2.lngCnt - 1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort2.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort2.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort, mtypChgSort2.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    'NSYS ヘッダー行を選択
                    .Row = 0
                    .TopRow = 0
                    
                    AddHandler vsfFbDataList2.BeforeRowColChange, AddressOf vsfFbDataList2_BeforeRowColChange
                    AddHandler vsfFbDataList2.AfterRowColChange, AddressOf vsfFbDataList2_AfterRowColChange
                    
                    '@ｵｰﾄ幅設定
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort2.blnChgWidth = False Then
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCols(CMlngvsfList2ColEditTime, CMlngvsfList2ColEditEmp, 6)
                    End If
                    
                    '@左右ｽｸﾛｰﾙ制御の記述
                    '@ｶﾚﾝﾄ列初期化
                    .Col = .Cols.Fixed
                    .LeftCol = .Cols.Fixed

                    '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御（ｸﾞﾘｯﾄﾞ共通化関数）
                    Call pubCmdLREnable_Set(vsfFbDataList2, cmdLeft2, cmdRight2)

                    '@前ﾍﾟｰｼﾞ、次ﾍﾟｰｼﾞ、ｽｸﾛｰﾙﾗﾍﾞﾙ表示設定
                    If .Rows.Count > 1 Then
                        cmdUP2.Enabled = True
                        cmdDown2.Enabled = True
            
                        '@ｸﾞﾘｯﾄﾞﾎﾞﾀﾝ制御、保持値ｸﾘｱ
                        Call pubVsfDisp(vsfFbDataList2, cmdUP2, cmdDown2)
                    Else
                        cmdUP2.Enabled = False
                        cmdDown2.Enabled = False
                    End If
                 
                    '@該当件数ﾗﾍﾞﾙに取得件数を表示
                    If .Rows.Count - 1 >= CMlngDisplayMaxCnt Then
                        '@該当件数が500件以上の場合は、"最大500"を表示する
                        lblLotCnt2.Text = CMstrDisplayMax & Format$(.Rows.Count - 1, CPstrDateFormatKanma)
                        '@ﾌｫﾝﾄｻｲｽﾞ1下げ
                        lblLotCnt2.Font = New Font(lblLotCnt2.Font.Name, 12.75, FontStyle.Regular)
                    Else
                        lblLotCnt2.Text = Format$(.Rows.Count - 1, CPstrDateFormatKanma)
                        '@標準ﾌｫﾝﾄ
                        lblLotCnt2.Font = New Font(lblLotCnt2.Font.Name, 14.25, FontStyle.Regular)
                    End If
                    '@ﾛｯｸ解除
                    .Enabled = True
                Else
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用不可
                    cmdLeft2.Enabled = False
                    cmdRight2.Enabled = False
                    cmdUP2.Enabled = False
                    cmdDown2.Enabled = False
                
                    '@該当ﾃﾞｰﾀが存在しない場合
                    lblLotCnt2.Text = 0
                    '@ﾛｯｸ
                    .Enabled = False
                End If
                
                '@行ｺﾋﾟｰﾌﾗｸﾞ（ON)
                If mblnCpoyLine2Flag = True Then
                    cmdPaste.Enabled = True
                Else
                    cmdPaste.Enabled = False
                End If
                
                '@情報取得日時表示
                lblNowDate2.Text = Format$(Now, CPstrDateFormat)

                '@直接描画
                .Redraw = True
            
            End With

            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ有効/無効設定
            Call prvCmdButton_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfFbDataList2_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfFbData_Disp
    '機　能：ﾃﾞｰﾀ表示
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 11:45:18 N.Kasai
    '更新日：2017/01/20 (Fri) 10:23:48 T.Oide
    '備　考：
    Private Sub prvvsfFbData_Disp()

        Dim llngDoCnt               As Integer  'ｶｳﾝﾄ
        Dim lblnAns                 As Boolean  '戻り値
        Dim llngCnt                 As Integer  'ｶｳﾝﾀ
        
        Try
            
            '@一覧表示
            With vsfFbData
                '@描画なし
                .Redraw = False
                
                '@ｶｳﾝﾀの初期化
                llngDoCnt = .Rows.Fixed
                
                '@ﾃﾞｰﾀ情報設定
                '@ﾃﾞｰﾀﾘｽﾄから内容を転写する。
                .SetData(llngDoCnt, CMlngvsfListColNo, vsfFbDataList.GetData(vsfFbDataList.Row, CMlngvsfListColNo))
                .SetData(llngDoCnt, CMlngvsfListColItem1, vsfFbDataList.GetData(vsfFbDataList.Row, CMlngvsfListColItem1))
                .SetData(llngDoCnt, CMlngvsfListColItem2, vsfFbDataList.GetData(vsfFbDataList.Row, CMlngvsfListColItem2))
                .SetData(llngDoCnt, CMlngvsfListColItem3, vsfFbDataList.GetData(vsfFbDataList.Row, CMlngvsfListColItem3))
                .SetData(llngDoCnt, CMlngvsfListColItem4, vsfFbDataList.GetData(vsfFbDataList.Row, CMlngvsfListColItem4))
                .SetData(llngDoCnt, CMlngvsfListColItem5, vsfFbDataList.GetData(vsfFbDataList.Row, CMlngvsfListColItem5))
                .SetData(llngDoCnt, CMlngvsfListColItem6, vsfFbDataList.GetData(vsfFbDataList.Row, CMlngvsfListColItem6))
                .SetData(llngDoCnt, CMlngvsfListColItem7, vsfFbDataList.GetData(vsfFbDataList.Row, CMlngvsfListColItem7))
                .SetData(llngDoCnt, CMlngvsfListColItem8, vsfFbDataList.GetData(vsfFbDataList.Row, CMlngvsfListColItem8))
                
                'Shot分離
                .SetData(llngDoCnt, CMlngvsfListColItem9, vsfFbDataList.GetData(vsfFbDataList.Row, CMlngvsfListColItem9))
                .SetData(llngDoCnt, CMlngvsfListColItem10, vsfFbDataList.GetData(vsfFbDataList.Row, CMlngvsfListColItem10))
                .SetData(llngDoCnt, CMlngvsfListColItem11, vsfFbDataList.GetData(vsfFbDataList.Row, CMlngvsfListColItem11))
                .SetData(llngDoCnt, CMlngvsfListColItem12, vsfFbDataList.GetData(vsfFbDataList.Row, CMlngvsfListColItem12))

                'Shot分離有無による自動入力
                'Shot分離なし
                If lblShotSeparateFlag.Text <> CPstrAriFlg Then
                    'Shot分離SHOTROTの値が全てNULLの場合は分離なしの値(SHOTROT)を入れる
                    If .GetData(llngDoCnt, CMlngvsfListColItem9) = vbNullString And _
                        .GetData(llngDoCnt, CMlngvsfListColItem10) = vbNullString Then

                        .SetData(llngDoCnt, CMlngvsfListColItem9, CDbl(Format$(.GetData(llngDoCnt, CMlngvsfListColItem7), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotXValidDigit))))
                        .SetData(llngDoCnt, CMlngvsfListColItem10, CDbl(Format$(.GetData(llngDoCnt, CMlngvsfListColItem7), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotYValidDigit))))
                    End If

                    'Shot分離SHOTMAGの値が全てNULLの場合は分離なしの値(SHOTMAG)を入れる
                    If .GetData(llngDoCnt, CMlngvsfListColItem11) = vbNullString And _
                        .GetData(llngDoCnt, CMlngvsfListColItem12) = vbNullString Then

                        .SetData(llngDoCnt, CMlngvsfListColItem11, CDbl(Format$(.GetData(llngDoCnt, CMlngvsfListColItem8), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagXValidDigit))))
                        .SetData(llngDoCnt, CMlngvsfListColItem12, CDbl(Format$(.GetData(llngDoCnt, CMlngvsfListColItem8), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagYValidDigit))))
                    End If

                ’Shot分離あり
                Else
                    'Shot分離あり(SHOTROTX)(SHOTROTY)の値がある場合は平均値を分離なしの値(SHOTROT)に入れる
                    If .GetData(llngDoCnt, CMlngvsfListColItem9) <> vbNullString And _
                        .GetData(llngDoCnt, CMlngvsfListColItem10) <> vbNullString Then

                        Dim tmp As Single =  Single.Parse(.GetData(llngDoCnt, CMlngvsfListColItem9)) + Single.Parse(.GetData(llngDoCnt, CMlngvsfListColItem10))
                        .SetData(llngDoCnt, CMlngvsfListColItem7, CDbl(Format$(tmp/2, pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotValidDigit))))
                    End If

                    'Shot分離あり(SHOTMAGX)(SHOTMAGY)の値がある場合は平均値を分離なしの値(SHOTMAG)に入れる
                    If .GetData(llngDoCnt, CMlngvsfListColItem11) <> vbNullString And _
                        .GetData(llngDoCnt, CMlngvsfListColItem12) <> vbNullString Then

                        Dim tmp As Single =  Single.Parse(.GetData(llngDoCnt, CMlngvsfListColItem11)) + Single.Parse(.GetData(llngDoCnt, CMlngvsfListColItem12))
                        .SetData(llngDoCnt, CMlngvsfListColItem8, CDbl(Format$(tmp/2, pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagValidDigit))))
                    End If
                End If

                '@ﾊﾞｯｸｶﾗｰの変更
                For llngCnt = 0 To .Cols.Count - 1
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                    newStyle.BackColor = Color.White
                    Dim cellRange As CellRange = .GetCellRange(1, llngCnt)
                    cellRange.Style = newStyle
                Next
                
                'Shot分離なし
                If lblShotSeparateFlag.Text <> CPstrAriFlg Then
                    '@ﾊﾞｯｸｶﾗｰの変更(入力不可色：ｸﾞﾚｰ)
                    Dim newShotStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                    newShotStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                    Dim cellShot As CellRange = .GetCellRange(.Rows.Count - 1, CMlngvsfListColItem9, .Rows.Count - 1, CMlngvsfListColItem12)
                    cellShot.Style = newShotStyle

                ’Shot分離あり
                Else
                    '@ﾊﾞｯｸｶﾗｰの変更(入力不可色：ｸﾞﾚｰ)
                    Dim newShotStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                    newShotStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                    Dim cellShot As CellRange = .GetCellRange(.Rows.Count - 1, CMlngvsfListColItem7, .Rows.Count - 1, CMlngvsfListColItem8)
                    cellShot.Style = newShotStyle

                End If

                '@直接描画
                .Redraw = True
                .Focus()
                .Select(1, CMlngvsfListColNo)
                
                '@ｺﾒﾝﾄ内容
                With txtComments
                    .Text = vsfFbDataList.GetData(vsfFbDataList.Row, CMlngvsfListColComments)
                    .Locked = True
                    '@ﾊﾞｯｸｶﾗｰの変更を行う為、記述
                    '@ﾌｫｰｶｽが該当項目に存在する場合は記述要
                    'DoEvents
                    .BackColor = SystemColors.ControlLight
                    .GotBackColor = SystemColors.ControlLight
                End With
                lblLengthCount.Visible = False
                
                '@戻り値の初期化
                lblnAns = False
                '@ｸﾞﾘｯﾄﾞ内検索
                For llngCnt = 0 To .Cols.Count - 1
                    '@変更値に値が設定されている場合
                    If .GetData(llngDoCnt, llngCnt) = vbNullString AndAlso .GetData(llngDoCnt, llngCnt) <> "0" Then
                        '@Null発見！！
                        lblnAns = True
                        Exit For
                    End If
                Next
                
                '@入力判定
                If lblnAns = True Then
                    '@確定ﾎﾞﾀﾝ使用不可
                    cmdProcEnd.Enabled = False
                Else
                    '@確定ﾎﾞﾀﾝ使用可
                    cmdProcEnd.Enabled = True
                End If
                
                '@--------------------
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの使用可
                '@--------------------
                '@ﾃﾞｰﾀﾘｽﾄ
                With vsfFbDataList
                    If .Rows.Count > 1 Then
                        cmdCopy.Enabled = True
                    Else
                        cmdCopy.Enabled = False
                    End If
                End With
                
                '@行ｺﾋﾟｰﾌﾗｸﾞ（ON)
                If mblnCpoyLineFlag = True Then
                    cmdPaste.Enabled = True
                Else
                    cmdPaste.Enabled = False
                End If
                
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfFbData_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfFbData2_Disp
    '機　能：ｸﾞﾘｯﾄﾞ表示(露光)
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 10:57:43 N.Kasai
    '更新日：2007/09/18 (Tue) 10:57:43
    '備　考：
    Private Sub prvvsfFbData2_Disp()

        Dim llngDoCnt               As Integer  'ｶｳﾝﾄ
        Dim lblnAns                 As Boolean  '戻り値
        Dim llngCnt                 As Integer  'ｶｳﾝﾀ
        
        Try
            
            '@一覧表示
            With vsfFbData2
                '@描画なし
                .Redraw = False
                
                '@ｶｳﾝﾀの初期化
                llngDoCnt = .Rows.Fixed
                
                '@ﾃﾞｰﾀ情報設定
                '@ﾃﾞｰﾀﾘｽﾄから内容を転写する。
                .SetData(llngDoCnt, CMlngvsfList2ColNo, vsfFbDataList2.GetData(vsfFbDataList2.Row, CMlngvsfList2ColNo))
                .SetData(llngDoCnt, CMlngvsfList2ColItem1, vsfFbDataList2.GetData(vsfFbDataList2.Row, CMlngvsfList2ColItem1))
                .SetData(llngDoCnt, CMlngvsfList2ColItem2, vsfFbDataList2.GetData(vsfFbDataList2.Row, CMlngvsfList2ColItem2))
                .SetData(llngDoCnt, CMlngvsfList2ColItem3, vsfFbDataList2.GetData(vsfFbDataList2.Row, CMlngvsfList2ColItem3))
                .SetData(llngDoCnt, CMlngvsfList2ColItem4, vsfFbDataList2.GetData(vsfFbDataList2.Row, CMlngvsfList2ColItem4))
                
                '@ﾊﾞｯｸｶﾗｰの変更
                For llngCnt = 0 To .Cols.Count - 1
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                    newStyle.BackColor = Color.White
                    Dim cellRange As CellRange = .GetCellRange(1, llngCnt)
                    cellRange.Style = newStyle
                Next
                
                '@直接描画
                .Redraw = True
                .Focus()
                .Select(1, CMlngvsfList2ColNo)
                
                '@ｺﾒﾝﾄ内容
                With txtComments2
                    .Text = vsfFbDataList2.GetData(vsfFbDataList2.Row, CMlngvsfList2ColComments)
                    .Locked = True
                    '@ﾊﾞｯｸｶﾗｰの変更を行う為、記述
                    '@ﾌｫｰｶｽが該当項目に存在する場合は記述要
                    'DoEvents
                    .BackColor = SystemColors.ControlLight
                    .GotBackColor = SystemColors.ControlLight
                End With
                lblLengthCount2.Visible = False
                
                '@戻り値の初期化
                lblnAns = False
                '@ｸﾞﾘｯﾄﾞ内検索
                For llngCnt = 0 To .Cols.Count - 1
                    '@変更値に値が設定されている場合
                    If .GetData(llngDoCnt, llngCnt) = vbNullString AndAlso .GetData(llngDoCnt, llngCnt) <> "0" Then
                        '@Null発見！！
                        lblnAns = True
                        Exit For
                    End If
                Next
                
                '@入力判定
                If lblnAns = True Then
                    '@確定ﾎﾞﾀﾝ使用不可
                    cmdProcEnd.Enabled = False
                Else
                    '@確定ﾎﾞﾀﾝ使用可
                    cmdProcEnd.Enabled = True
                End If
                
                '@--------------------
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの使用可
                '@--------------------
                '@ﾃﾞｰﾀﾘｽﾄ
                With vsfFbDataList2
                    If .Rows.Count > 1 Then
                        cmdCopy.Enabled = True
                    Else
                        cmdCopy.Enabled = False
                    End If
                End With
                
                '@行ｺﾋﾟｰﾌﾗｸﾞ（ON)
                If mblnCpoyLine2Flag = True Then
                    cmdPaste.Enabled = True
                Else
                    cmdPaste.Enabled = False
                End If
                
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfFbData2_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbWP_Disp
    '機　能：ﾌｫﾄ号機/1stﾌｫﾄ号機ｺﾝﾎﾞｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 09:06:20 N.Kasai
    '更新日：2006/03/02 (Thu) 09:06:20
    '備　考：
    Private Sub prvcmbWp_Disp(ByVal llngWpListCnt As Integer)

        Dim llngCnt                 As Integer  'ｶｳﾝﾄ

        Try
                
                '@ﾌｫﾄ号機（合せ）
                With cmbWp
                    .Clear
                    .DispCols = CMlngCmbDispCols1                               'ｸﾞﾘｯﾄﾞ表示列数
                    .GetCol = CMlngCmbGridCol0                                  'ﾃｷｽﾄ表示列
                    .ValueCol = CMlngCmbGridCol1                                '値取得列
                    .DirectInput = False                                        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                    .Font = New Font(.Font.FontFamily, CSng(CMlngCmbFontSize), _
                                     .Font.Style, .Font.Unit)                   'ﾌｫﾝﾄｻｲｽﾞ
                    .GridFont = New Font(.GridFont.FontFamily, CSng(CMlngCmbGridFontSize), _
                                         .GridFont.Style, .GridFont.Unit)       'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    .RowHeight = CMlngCmbRowHeight                              '行の高さ
                    .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左中央
                    .Enabled = True                                             '使用可能

                    '@配列の件数ﾁｪｯｸ
                    If llngWpListCnt > 0 Then
                        For llngCnt = 0 To llngWpListCnt - 1
                            .AddItem(ptypWPList(llngCnt).strWpName & vbTab & ptypWPList(llngCnt).strWpID)
                        Next llngCnt
                        
                        '@1件の場合、ﾃﾞﾌｫﾙﾄ表示
                        If .ListCount = 1 Then
                            '@1件目表示
                            .ListIndex = 0
                        End If
                    End If
                End With
                
                '@1stﾌｫﾄ号機ｾｯﾄ
                With cmbReferenceWP
                    .Clear
                    .DispCols = CMlngCmbDispCols1                               'ｸﾞﾘｯﾄﾞ表示列数
                    .GetCol = CMlngCmbGridCol0                                  'ﾃｷｽﾄ表示列
                    .ValueCol = CMlngCmbGridCol1                                '値取得列
                    .DirectInput = False                                        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                    .Font = New Font(.Font.FontFamily, CSng(CMlngCmbFontSize), _
                                     .Font.Style, .Font.Unit)                   'ﾌｫﾝﾄｻｲｽﾞ
                    .GridFont = New Font(.GridFont.FontFamily, CSng(CMlngCmbGridFontSize), _
                                         .GridFont.Style, .GridFont.Unit)       'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    .RowHeight = CMlngCmbRowHeight                              '行の高さ
                    .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左中央
                    .Enabled = True                                             '使用可能

                    '@配列の件数ﾁｪｯｸ
                    If llngWpListCnt > 0 Then
                        For llngCnt = 0 To llngWpListCnt - 1
                            .AddItem(ptypWPList(llngCnt).strWpName & vbTab & ptypWPList(llngCnt).strWpID)
                        Next llngCnt

                        '@1件の場合、ﾃﾞﾌｫﾙﾄ表示
                        If .ListCount = 1 Then
                            '@1件目表示
                            .ListIndex = 0
                        End If
                    End If
                End With
                
        '@↓2017/01/20 (Fri) 12:51:15 T.Oide **************************************************
                '@patchNo
                With cmbPatchNo
                    .Clear
                    .DispCols = CMlngCmbDispCols1                               'ｸﾞﾘｯﾄﾞ表示列数
                    .GetCol = CMlngCmbGridCol0                                  'ﾃｷｽﾄ表示列
                    .ValueCol = CMlngCmbGridCol1                                '値取得列
                    .DirectInput = False                                        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                    .Font = New Font(.Font.FontFamily, CSng(CMlngCmbFontSize), _
                                     .Font.Style, .Font.Unit)                   'ﾌｫﾝﾄｻｲｽﾞ
                    .GridFont = New Font(.GridFont.FontFamily, CSng(CMlngCmbGridFontSize), _
                                         .GridFont.Style, .GridFont.Unit)       'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    .RowHeight = CMlngCmbRowHeight                              '行の高さ
                    .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左中央
                End With
        '@↑2017/01/20 (Fri) 12:51:15 T.Oide **************************************************
                
                '@ﾌｫﾄ号機ｾｯﾄ(露光)
                With cmbWP2
                    .Clear
                    .DispCols = CMlngCmbDispCols1                               'ｸﾞﾘｯﾄﾞ表示列数
                    .GetCol = CMlngCmbGridCol0                                  'ﾃｷｽﾄ表示列
                    .ValueCol = CMlngCmbGridCol1                                '値取得列
                    .DirectInput = False                                        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                    .Font = New Font(.Font.FontFamily, CSng(CMlngCmbFontSize), _
                                     .Font.Style, .Font.Unit)                   'ﾌｫﾝﾄｻｲｽﾞ
                    .GridFont = New Font(.GridFont.FontFamily, CSng(CMlngCmbGridFontSize), _
                                         .GridFont.Style, .GridFont.Unit)       'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    .RowHeight = CMlngCmbRowHeight                              '行の高さ
                    .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左中央
                    .Enabled = True                                             '使用可能

                    '@配列の件数ﾁｪｯｸ
                    If llngWpListCnt > 0 Then
                        For llngCnt = 0 To llngWpListCnt - 1
                            .AddItem(ptypWPList(llngCnt).strWpName & vbTab & ptypWPList(llngCnt).strWpID)
                        Next llngCnt
                        
                        '@1件の場合、ﾃﾞﾌｫﾙﾄ表示
                        If .ListCount = 1 Then
                            '@1件目表示
                            .ListIndex = 0
                        End If
                    End If
                End With
                
                
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbWP_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnRecipeData_Chk
    '機　能：ﾚｼﾋﾟID整合性ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：ｴﾗｰなし、False:ｴﾗｰあり
    '作成日：2007/08/31 (Fri) 12:04:54 N.Kasai
    '更新日：2007/08/31 (Fri) 12:04:54
    '備　考：
    Private Function prvblnRecipeData_Chk() As Boolean

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try
            
            '@戻り値初期化
            prvblnRecipeData_Chk = False
            
            '@ﾃﾞｰﾀ件数がある場合
            If mtypMasRecipeNameList.lngMasRecipeNameCnt > 0 Then
                '@ﾚｼﾋﾟ情報ｾｯﾄ
                For llngCnt = 0 To mtypMasRecipeNameList.lngMasRecipeNameCnt - 1
                    If txtRecipeID.Text = mtypMasRecipeNameList.typMasRecipeName(llngCnt).strRecipeId Then
                        '@正常ﾚｼﾋﾟ
                        prvblnRecipeData_Chk = True
                        Exit Function
                    End If
                Next llngCnt
            Else
                '@ｴﾗｰ
                Exit Function
            End If
                
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnRecipeData_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnRecipeData2_Chk
    '機　能：ﾚｼﾋﾟID整合性ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：ｴﾗｰなし、False:ｴﾗｰあり
    '作成日：2007/08/31 (Fri) 12:04:54 N.Kasai
    '更新日：2007/08/31 (Fri) 12:04:54
    '備　考：
    Private Function prvblnRecipeData2_Chk() As Boolean

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try
            
            '@戻り値初期化
            prvblnRecipeData2_Chk = False
            
            '@ﾃﾞｰﾀ件数がある場合
            If mtypMasRecipeNameList2.lngMasRecipeNameCnt > 0 Then
                '@ﾚｼﾋﾟ情報ｾｯﾄ
                For llngCnt = 0 To mtypMasRecipeNameList2.lngMasRecipeNameCnt - 1
                    If txtRecipeID2.Text = mtypMasRecipeNameList2.typMasRecipeName(llngCnt).strRecipeId Then
                        '@正常ﾚｼﾋﾟ
                        prvblnRecipeData2_Chk = True
                        Exit Function
                    End If
                Next llngCnt
            Else
                '@ｴﾗｰ
                Exit Function
            End If
                
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnRecipeData2_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvGrid_Init
    '機　能：ｸﾞﾘｯﾄﾞ簡易初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 14:31:21 N.Kasai
    '更新日：2017/03/10 (Fri) 17:10:42 T.Oide
    '備　考：
    Private Sub prvGrid_Init()
        
        Dim llngCol As Integer  'Colｶｳﾝﾄ
        
        Try
            
            '@最前面のﾀﾌﾞ判定
            Select Case tabRecipe.SelectedTab.Name
                
                '@合せﾀﾌﾞ
                Case Tab0.Name
                
                    '@ﾗﾍﾞﾙの初期化
                    lblNowDate.Text = vbNullString                   '情報取得日時
                    lblLotCnt.Text = vbNullString                    '該当件数
                    
                    '@ｸﾞﾘｯﾄﾞの初期化
                    
                    '@ﾃﾞｰﾀ
                    With vsfFbData
                        For llngCol = 0 To .Cols.Count - 1
                            .SetData(1, llngCol, vbNullString)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White
                            Dim cellRange As CellRange = .GetCellRange(1, llngCol)
                            cellRange.Style = newStyle
                        Next

                        If FbDateInitFlg = False Then
                            .Enabled = False
                        End If
                    End With
                    '@ﾃﾞｰﾀﾘｽﾄ
                    With vsfFbDataList
                        .Rows.Count = .Rows.Fixed

                        If FbDateInitFlg = False Then
                            .Enabled = False
                        End If
                    End With
                    
                    '@使用不可
                    If FbDateInitFlg = False Then
                        cmdUP.Enabled = False                            '前ﾍﾟｰｼﾞ
                        cmdDown.Enabled = False                          '次ﾍﾟｰｼﾞ
                        cmdLeft.Enabled = False                          '左ﾎﾞﾀﾝ
                        cmdRight.Enabled = False                         '右ﾎﾞﾀﾝ
                        cmdProcEnd.Enabled = False                       '確定ﾎﾞﾀﾝ
                        cmdCopy.Enabled = False                          'ｺﾋﾟｰﾎﾞﾀﾝ
                        cmdPaste.Enabled = False                         '貼り付けﾎﾞﾀﾝ
                    End If
                    
                    '@ｺﾒﾝﾄ
                    With txtComments
                        .Text = vbNullString
                        .Locked = True
                        .BackColor = SystemColors.ControlLight
                        .GotBackColor = SystemColors.ControlLight
                        lblLengthCount.Visible = False
                    End With

                    '@検索済ﾌﾗｸﾞOFF
                    mblnAfterSerchFlag = False
                    'mblnAfterSerch2Flag = False

                 
                '@露光ﾀﾌﾞ
                Case Tab1.Name
                
                    '@ﾗﾍﾞﾙの初期化
                    lblNowDate2.Text = vbNullString                  '情報取得日時
                    lblLotCnt2.Text = vbNullString                   '該当件数
                    
                    '@ｸﾞﾘｯﾄﾞの初期化
                    
                    '@ﾃﾞｰﾀ
                    With vsfFbData2
                        For llngCol = 0 To .Cols.Count - 1
                            .SetData(1, llngCol, vbNullString)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White
                            Dim cellRange As CellRange = .GetCellRange(1, llngCol)
                            cellRange.Style = newStyle
                        Next

                        If FbDate2InitFlg = False Then
                            .Enabled = False
                        End If
                    End With
                    '@ﾃﾞｰﾀﾘｽﾄ
                    With vsfFbDataList2
                        .Rows.Count = .Rows.Fixed

                        If FbDate2InitFlg = False Then
                            .Enabled = False
                        End If
                    End With
                    
                    '@使用不可
                    If FbDate2InitFlg = False Then
                        cmdUP2.Enabled = False                           '前ﾍﾟｰｼﾞ
                        cmdDown2.Enabled = False                         '次ﾍﾟｰｼﾞ
                        cmdLeft2.Enabled = False                         '左ﾎﾞﾀﾝ
                        cmdRight2.Enabled = False                        '右ﾎﾞﾀﾝ
                        cmdProcEnd.Enabled = False                       '確定ﾎﾞﾀﾝ
                        cmdCopy.Enabled = False                          'ｺﾋﾟｰﾎﾞﾀﾝ
                        cmdPaste.Enabled = False                         '貼り付けﾎﾞﾀﾝ
                    End If
                    
                    '@ｺﾒﾝﾄ
                    With txtComments2
                        .Text = vbNullString
                        .Locked = True
                        .BackColor = SystemColors.ControlLight
                        .GotBackColor = SystemColors.ControlLight
                        lblLengthCount.Visible = False
                    End With

                    '@検索済ﾌﾗｸﾞOFF
                    'mblnAfterSerchFlag = False
                    mblnAfterSerch2Flag = False

            End Select
            
            '@検索済ﾌﾗｸﾞOFF
            'mblnAfterSerchFlag = False
            'mblnAfterSerch2Flag = False
            
            If FbDateInitFlg = False Then
                '@ﾎﾞﾀﾝ有効/無効制御
                Call prvCmdButton_Chk()
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGrid_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvComb_Chk
    '機　能：ｺﾝﾎﾞﾎﾞｯｸｽﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/02 (Thu) 14:48:25 N.Kasai
    '更新日：2006/03/02 (Thu) 14:48:25
    '備　考：
    Private Sub prvComb_Chk()
        
        Try
            
            '@最前面のﾀﾌﾞ判定
            Select Case tabRecipe.SelectedTab.Name
            
                '@合せﾀﾌﾞ
                Case Tab0.Name
                
                    '@ﾌｫﾄ号機ｺﾝﾎﾞ
                    If cmbWp.ListIndex = -1 Then
                        '@最新取得ﾎﾞﾀﾝ使用不可
                        cmdSearch.Enabled = False
                        Exit Sub
                    End If
                    '@ﾚｼﾋﾟ
                    If txtRecipeID.Text = vbNullString Then
                        '@最新取得ﾎﾞﾀﾝ使用不可
                        cmdSearch.Enabled = False
                        Exit Sub
                    End If
                    '@1stﾌｫﾄ号機ｺﾝﾎﾞ
                    If cmbReferenceWP.ListIndex = -1 Then
                        '@最新取得ﾎﾞﾀﾝ使用不可
                        cmdSearch.Enabled = False
                        Exit Sub
                    End If
                    
                    '@--------------------
                    '@ｸﾞﾘｯﾄﾞの使用可
                    '@--------------------
                    '@ﾃﾞｰﾀｸﾞﾘｯﾄﾞ
                    With vsfFbData
                        .Enabled = True
                    End With
                    '@ﾃﾞｰﾀﾘｽﾄ
                    With vsfFbDataList
                        .Enabled = True
                    End With
                    
                    '@--------------------
                    '@最新取得ﾎﾞﾀﾝの使用可
                    '@--------------------
                    '@最新取得ﾎﾞﾀﾝ使用可
                    cmdSearch.Enabled = True
                    '@最新取得
                    Call cmdSearch_Click(cmdSearch, New EventArgs)
                
                    '@--------------------
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの使用可
                    '@--------------------
                    '@行ｺﾋﾟｰﾌﾗｸﾞ（ON)
                    If mblnCpoyLineFlag = True Then
                        cmdPaste.Enabled = True
                    Else
                        cmdPaste.Enabled = False
                    End If
                
                '@露光ﾀﾌﾞ
                Case Tab1.Name
                
                    '@ﾌｫﾄ号機ｺﾝﾎﾞ
                    If cmbWP2.ListIndex = -1 Then
                        '@最新取得ﾎﾞﾀﾝ使用不可
                        cmdSearch2.Enabled = False
                        Exit Sub
                    End If
                    '@ﾚｼﾋﾟ
                    If txtRecipeID2.Text = vbNullString Then
                        '@最新取得ﾎﾞﾀﾝ使用不可
                        cmdSearch2.Enabled = False
                        Exit Sub
                    End If
                    
                    '@--------------------
                    '@ｸﾞﾘｯﾄﾞの使用可
                    '@--------------------
                    '@ﾃﾞｰﾀｸﾞﾘｯﾄﾞ
                    With vsfFbData2
                        .Enabled = True
                    End With
                    '@ﾃﾞｰﾀﾘｽﾄ
                    With vsfFbDataList2
                        .Enabled = True
                    End With
                    
                    '@--------------------
                    '@最新取得ﾎﾞﾀﾝの使用可
                    '@--------------------
                    '@最新取得ﾎﾞﾀﾝ使用可
                    cmdSearch2.Enabled = True
                    '@最新取得
                    Call cmdSearch2_Click(cmdSearch2, New EventArgs)
                
                    '@--------------------
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの使用可
                    '@--------------------
                    '@行ｺﾋﾟｰﾌﾗｸﾞ（ON)
                    If mblnCpoyLine2Flag = True Then
                        cmdPaste.Enabled = True
                    Else
                        cmdPaste.Enabled = False
                    End If
                
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = "CMstrLocalMenuKey"
                .strProcName = "prvComb_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnProcEnd_Chk
    '機　能：確定時のﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2006/03/13 (Mon) 16:40:29 N.Kasai
    '更新日：2006/03/13 (Mon) 16:40:29
    '備　考：
    Private Function prvblnProcEnd_Chk() As Boolean

        Dim lblnAns     As Boolean  '戻り値
        Dim llngCnt     As Integer  'ｶｳﾝﾀ
        
        Try
            
            '@戻り値の初期化
            prvblnProcEnd_Chk = False
            
            '@ﾀﾌﾞ判定
            Select Case tabRecipe.SelectedTab.Name
                
                '@合わせﾊﾟﾗﾒｰﾀ
                Case Tab0.Name
                
                    '@------------------------
                    '@ﾚｼﾋﾟID整合性ﾁｪｯｸ
                    '@------------------------
                    lblnAns = prvblnRecipeData_Chk
                    '@ｴﾗｰありの場合
                    If lblnAns = False Then
                        '@"<TRM0MW>$$レシピIDの設定に不備があります。設定を見直して下さい。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000M)
                        '@警告ﾒｯｾｰｼﾞ
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Call pubSetFocus(txtRecipeID)
                        Exit Function
                    End If
                    
                    With vsfFbData
                        '@------------------------
                        '@入力値のﾁｪｯｸ（≠空白、数値）
                        '@------------------------
                        '@ｸﾞﾘｯﾄﾞ内検索
                        For llngCnt = 1 To .Cols.Count - 1
                            '@変更値に値が設定未設定の場合
                            If .GetData(1, llngCnt) = vbNullString AndAlso .GetData(1, llngCnt) <> "0" Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007Q)
                                '@"<TRM7QW>$$数値を入力して下さい。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                '@編集可能ｾﾙの場合
                                'NSYS 編集時の前景色と背景色を設定
                                If .GetCellStyle(1, llngCnt).BackColor = ColorTranslator.FromWin32(CPlngEditColor) Then
                                    'NSYS 背景色が水色(編集済)の場合は編集中の背景色も水色に設定
                                    .Styles.Editor.BackColor = ColorTranslator.FromWin32(CPlngEditColor)
                                    .Styles.Editor.ForeColor = SystemColors.WindowText
                                Else
                                    'NSYS 背景色が水色でない場合は編集中の背景色を白色に設定
                                    .Styles.Editor.BackColor = SystemColors.Window
                                    .Styles.Editor.ForeColor = SystemColors.WindowText
                                End If

                                .Select(1, llngCnt)      '編集可能ｾﾙの範囲選択
                                .StartEditing()          '編集可能にする
                                Exit Function
                            End If
                        
                            '@変更値に値が設定未設定の場合
                            If IsNumeric(.GetData(1, llngCnt)) = False Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007Q)
                                '@"<TRM7QW>$$数値を入力して下さい。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                '@編集可能ｾﾙの場合
                                'NSYS 編集時の前景色と背景色を設定
                                If .GetCellStyle(1, llngCnt).BackColor = ColorTranslator.FromWin32(CPlngEditColor) Then
                                    'NSYS 背景色が水色(編集済)の場合は編集中の背景色も水色に設定
                                    .Styles.Editor.BackColor = ColorTranslator.FromWin32(CPlngEditColor)
                                    .Styles.Editor.ForeColor = SystemColors.WindowText
                                Else
                                    'NSYS 背景色が水色でない場合は編集中の背景色を白色に設定
                                    .Styles.Editor.BackColor = SystemColors.Window
                                    .Styles.Editor.ForeColor = SystemColors.WindowText
                                End If

                                .Select(1, llngCnt)      '編集可能ｾﾙの範囲選択
                                .StartEditing()          '編集可能にする
                                Exit Function
                            End If
                        Next
                        
                        '@------------------------
                        '@現在値≠変更値であること
                        '@------------------------
                        '@新規登録の場合はﾁｪｯｸなし
                        If vsfFbDataList.Rows.Count > vsfFbDataList.Rows.Fixed Then
                            '@ｸﾞﾘｯﾄﾞ内検索
                            For llngCnt = 1 To vsfFbDataList.Rows.Count - 1
                                '@№="1"が最新ﾃﾞｰﾀの為、表示行を検索する。
                                If vsfFbDataList.GetData(llngCnt, CMlngvsfListColNo) = "1" Then
                                    Exit For
                                End If
                            Next
                            '@戻り値の初期化
                            lblnAns = False
                            
                            If CDbl(.GetData(1, CMlngvsfListColItem1)) <> CDbl(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem1)) Then
                                lblnAns = True
                            End If
                            If CDbl(.GetData(1, CMlngvsfListColItem2)) <> CDbl(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem2)) Then
                                lblnAns = True
                            End If
                            If CDbl(.GetData(1, CMlngvsfListColItem3)) <> CDbl(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem3)) Then
                                lblnAns = True
                            End If
                            If CDbl(.GetData(1, CMlngvsfListColItem4)) <> CDbl(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem4)) Then
                                lblnAns = True
                            End If
                            If CDbl(.GetData(1, CMlngvsfListColItem5)) <> CDbl(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem5)) Then
                                lblnAns = True
                            End If
                            If CDbl(.GetData(1, CMlngvsfListColItem6)) <> CDbl(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem6)) Then
                                lblnAns = True
                            End If
                            'Shot分離なし
                            If vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem7) <> vbNullString Then
                                If CDbl(.GetData(1, CMlngvsfListColItem7)) <> CDbl(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem7)) Then
                                    lblnAns = True
                                End If
                            End If
                            If vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem8) <> vbNullString Then
                                If CDbl(.GetData(1, CMlngvsfListColItem8)) <> CDbl(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem8)) Then
                                    lblnAns = True
                                End If
                            End If
                            'Shot分離あり
                            If vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem9) <> vbNullString Then
                                If CDbl(.GetData(1, CMlngvsfListColItem9)) <> CDbl(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem9)) Then
                                    lblnAns = True
                                End If
                            End If
                            If vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem10) <> vbNullString Then
                                If CDbl(.GetData(1, CMlngvsfListColItem10)) <> CDbl(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem10)) Then
                                    lblnAns = True
                                End If
                            End If
                            If vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem11) <> vbNullString Then
                                If CDbl(.GetData(1, CMlngvsfListColItem11)) <> CDbl(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem11)) Then
                                    lblnAns = True
                                End If
                            End If
                            If vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem12) <> vbNullString Then
                                If CDbl(.GetData(1, CMlngvsfListColItem12)) <> CDbl(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem12)) Then
                                    lblnAns = True
                                End If
                            End If
                            
                            '@戻り値判定（ﾁｮｯﾄ原始的）
                            If lblnAns = False Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007R)
                                '@"<TRM7RW>$$現行値と変更値が同じ値です。$設定を見直してください。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                '@編集可能ｾﾙの場合
                                .Select(1, llngCnt)      '編集可能ｾﾙの範囲選択
                                Call pubSetFocus(vsfFbData)
                                Exit Function
                            End If
                        End If
                        
                        '@ﾁｪｯｸOK
                        prvblnProcEnd_Chk = True
                    
                    End With
                    
                '@露光ﾊﾟﾗﾒｰﾀ
                Case Tab1.Name
                     
                    '@------------------------
                    '@ﾚｼﾋﾟID整合性ﾁｪｯｸ
                    '@------------------------
                    lblnAns = prvblnRecipeData2_Chk
                    '@ｴﾗｰありの場合
                    If lblnAns = False Then
                        '@"<TRM0MW>$$レシピIDの設定に不備があります。設定を見直して下さい。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000M)
                        '@警告ﾒｯｾｰｼﾞ
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Call pubSetFocus(txtRecipeID2)
                        Exit Function
                    End If
                    
                    With vsfFbData2
                        '@------------------------
                        '@入力値のﾁｪｯｸ（≠空白、数値）
                        '@------------------------
                        '@ｸﾞﾘｯﾄﾞ内検索
                        For llngCnt = 1 To .Cols.Count - 1
                            '@変更値に値が設定未設定の場合
                            If .GetData(1, llngCnt) = vbNullString AndAlso .GetData(1, llngCnt) <> "0" Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007Q)
                                '@"<TRM7QW>$$数値を入力して下さい。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                '@編集可能ｾﾙの場合
                                'NSYS 編集時の前景色と背景色を設定
                                If .GetCellStyle(1, llngCnt).BackColor = ColorTranslator.FromWin32(CPlngEditColor) Then
                                    'NSYS 背景色が水色(編集済)の場合は編集中の背景色も水色に設定
                                    .Styles.Editor.BackColor = ColorTranslator.FromWin32(CPlngEditColor)
                                    .Styles.Editor.ForeColor = SystemColors.WindowText
                                Else
                                    'NSYS 背景色が水色でない場合は編集中の背景色を白色に設定
                                    .Styles.Editor.BackColor = SystemColors.Window
                                    .Styles.Editor.ForeColor = SystemColors.WindowText
                                End If

                                .Select(1, llngCnt)      '編集可能ｾﾙの範囲選択
                                .StartEditing()          '編集可能にする
                                Exit Function
                            End If
                        
                            '@変更値に値が設定未設定の場合
                            If IsNumeric(.GetData(1, llngCnt)) = False Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007Q)
                                '@"<TRM7QW>$$数値を入力して下さい。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                '@編集可能ｾﾙの場合
                                'NSYS 編集時の前景色と背景色を設定
                                If .GetCellStyle(1, llngCnt).BackColor = ColorTranslator.FromWin32(CPlngEditColor) Then
                                    'NSYS 背景色が水色(編集済)の場合は編集中の背景色も水色に設定
                                    .Styles.Editor.BackColor = ColorTranslator.FromWin32(CPlngEditColor)
                                    .Styles.Editor.ForeColor = SystemColors.WindowText
                                Else
                                    'NSYS 背景色が水色でない場合は編集中の背景色を白色に設定
                                    .Styles.Editor.BackColor = SystemColors.Window
                                    .Styles.Editor.ForeColor = SystemColors.WindowText
                                End If

                                .Select(1, llngCnt)      '編集可能ｾﾙの範囲選択
                                .StartEditing()          '編集可能にする
                                Exit Function
                            End If
                        Next
                        
                        '@------------------------
                        '@現在値≠変更値であること
                        '@------------------------
                        '@新規登録の場合はﾁｪｯｸなし
                        If vsfFbDataList2.Rows.Count > vsfFbDataList2.Rows.Fixed Then
                            '@ｸﾞﾘｯﾄﾞ内検索
                            For llngCnt = 1 To vsfFbDataList2.Rows.Count - 1
                                '@№="1"が最新ﾃﾞｰﾀの為、表示行を検索する。
                                If vsfFbDataList2.GetData(llngCnt, CMlngvsfListColNo) = "1" Then
                                    Exit For
                                End If
                            Next
                            '@戻り値の初期化
                            lblnAns = False
                            
                            If .GetData(1, CMlngvsfList2ColItem1) <> vsfFbDataList2.GetData(llngCnt, CMlngvsfList2ColItem1) Then
                                lblnAns = True
                            End If
                            If .GetData(1, CMlngvsfList2ColItem2) <> vsfFbDataList2.GetData(llngCnt, CMlngvsfList2ColItem2) Then
                                lblnAns = True
                            End If
                            If .GetData(1, CMlngvsfList2ColItem3) <> vsfFbDataList2.GetData(llngCnt, CMlngvsfList2ColItem3) Then
                                lblnAns = True
                            End If
                            If .GetData(1, CMlngvsfList2ColItem4) <> vsfFbDataList2.GetData(llngCnt, CMlngvsfList2ColItem4) Then
                                lblnAns = True
                            End If
                            
                            '@戻り値判定（ﾁｮｯﾄ原始的）
                            If lblnAns = False Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007R)
                                '@"<TRM7RW>$$現行値と変更値が同じ値です。$設定を見直してください。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                '@編集可能ｾﾙの場合
                                .Select(1, llngCnt)      '編集可能ｾﾙの範囲選択
                                Call pubSetFocus(vsfFbData2)
                                Exit Function
                            End If
                        End If
                        
                        '@------------------------
                        '@上下限値の大小ﾁｪｯｸ
                        '@------------------------
                        '@下限値>上限値
                        If .GetData(1, CMlngvsfList2ColItem1) > .GetData(1, CMlngvsfList2ColItem3) Then
                            '@"<TRM7OW>$$下限値＜上限値となるよう入力してください。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007O)
                            '@警告ﾒｯｾｰｼﾞ
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            '@編集可能ｾﾙの場合
                            'NSYS 編集時の前景色と背景色を設定
                            If .GetCellStyle(1, CMlngvsfList2ColItem1).BackColor = ColorTranslator.FromWin32(CPlngEditColor) Then
                                'NSYS 背景色が水色(編集済)の場合は編集中の背景色も水色に設定
                                .Styles.Editor.BackColor = ColorTranslator.FromWin32(CPlngEditColor)
                                .Styles.Editor.ForeColor = SystemColors.WindowText
                            Else
                                'NSYS 背景色が水色でない場合は編集中の背景色を白色に設定
                                .Styles.Editor.BackColor = SystemColors.Window
                                .Styles.Editor.ForeColor = SystemColors.WindowText
                            End If

                            .Select(1, CMlngvsfList2ColItem1)        '編集可能ｾﾙの範囲選択
                            .StartEditing()                          '編集可能にする
                            Exit Function
                        End If
                        
                        '@------------------------
                        '@現在値と下限値の大小ﾁｪｯｸ
                        '@------------------------
                        '@変更値>現在値
                        If .GetData(1, CMlngvsfList2ColItem1) > .GetData(1, CMlngvsfList2ColItem2) Then
                            '@"<TRM7SW>$$変更値が下限値を超えています。$設定を見直してください。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007S)
                            '@警告ﾒｯｾｰｼﾞ
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            '@編集可能ｾﾙの場合
                            'NSYS 編集時の前景色と背景色を設定
                            If .GetCellStyle(1, CMlngvsfList2ColItem2).BackColor = ColorTranslator.FromWin32(CPlngEditColor) Then
                                'NSYS 背景色が水色(編集済)の場合は編集中の背景色も水色に設定
                                .Styles.Editor.BackColor = ColorTranslator.FromWin32(CPlngEditColor)
                                .Styles.Editor.ForeColor = SystemColors.WindowText
                            Else
                                'NSYS 背景色が水色でない場合は編集中の背景色を白色に設定
                                .Styles.Editor.BackColor = SystemColors.Window
                                .Styles.Editor.ForeColor = SystemColors.WindowText
                            End If

                            .Select(1, CMlngvsfList2ColItem2)        '編集可能ｾﾙの範囲選択
                            .StartEditing()                          '編集可能にする
                            Exit Function
                        End If
                        
                        '@------------------------
                        '@現在値と上限値の大小ﾁｪｯｸ
                        '@------------------------
                        '@変更値>上限値
                        If .GetData(1, CMlngvsfList2ColItem2) > .GetData(1, CMlngvsfList2ColItem3) Then
                            '@"<TRM7TW>$$変更値が上限値を超えています。$設定を見直してください。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007T)
                            '@警告ﾒｯｾｰｼﾞ
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            '@編集可能ｾﾙの場合
                            'NSYS 編集時の前景色と背景色を設定
                            If .GetCellStyle(1, CMlngvsfList2ColItem2).BackColor = ColorTranslator.FromWin32(CPlngEditColor) Then
                                'NSYS 背景色が水色(編集済)の場合は編集中の背景色も水色に設定
                                .Styles.Editor.BackColor = ColorTranslator.FromWin32(CPlngEditColor)
                                .Styles.Editor.ForeColor = SystemColors.WindowText
                            Else
                                'NSYS 背景色が水色でない場合は編集中の背景色を白色に設定
                                .Styles.Editor.BackColor = SystemColors.Window
                                .Styles.Editor.ForeColor = SystemColors.WindowText
                            End If

                            .Select(1, CMlngvsfList2ColItem2)        '編集可能ｾﾙの範囲選択
                            .StartEditing()                          '編集可能にする
                            Exit Function
                        End If
                        
                        '@ﾁｪｯｸOK
                        prvblnProcEnd_Chk = True
                    
                    End With
            
            End Select
                    
                    
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnProcEnd_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnAuthority_Chk
    '機　能：権限ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：権限ﾁｪｯｸ要、False：権限ﾁｪｯｸ不要
    '作成日：2007/09/18 (Tue) 11:01:29 N.Kasai
    '更新日：2007/09/18 (Tue) 11:01:29
    '備　考：
    Private Function prvblnAuthority_Chk() As Boolean

        Dim lblnAns As Boolean      '戻り値
        Dim llngCnt As Integer      '汎用ｶｳﾝﾀ
        
        Try
            
            '@戻り値初期化
            prvblnAuthority_Chk = False
            
            '@------------------------
            '@現在値と変更値の確認
            '@Exposure以外の項目が変更された場合は権限ﾁｪｯｸ要
            '@------------------------
            If vsfFbDataList2.Rows.Count > vsfFbDataList2.Rows.Fixed Then
                '@ｸﾞﾘｯﾄﾞ内検索
                For llngCnt = 1 To vsfFbDataList2.Rows.Count - 1
                    '@№="1"が最新ﾃﾞｰﾀの為、表示行を検索する。
                    If vsfFbDataList2.GetData(llngCnt, CMlngvsfList2ColNo) = "1" Then
                        Exit For
                    End If
                Next
                
                '@戻り値の初期化
                lblnAns = False
                
                If vsfFbData2.GetData(1, CMlngvsfList2ColItem1) <> vsfFbDataList2.GetData(llngCnt, CMlngvsfList2ColItem1) Then
                    lblnAns = True
                End If
                
                If vsfFbData2.GetData(1, CMlngvsfList2ColItem3) <> vsfFbDataList2.GetData(llngCnt, CMlngvsfList2ColItem3) Then
                    lblnAns = True
                End If
                
                If vsfFbData2.GetData(1, CMlngvsfList2ColItem4) <> vsfFbDataList2.GetData(llngCnt, CMlngvsfList2ColItem4) Then
                    lblnAns = True
                End If
                
                '@戻り値判定（ﾁｮｯﾄ原始的）
                If lblnAns = False Then
                    Exit Function
                Else
                    '@権限ﾁｪｯｸ要
                     prvblnAuthority_Chk = True
                End If
            Else
                '@新規登録の場合は必ず権限ﾁｪｯｸ
                '@権限ﾁｪｯｸ要
                prvblnAuthority_Chk = True
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnAuthority_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

	'関数名：prvcmbRecpList_Set
    '機　能：ｸﾞﾘｯﾄﾞのﾚｼﾋﾟのｺﾝﾎﾞﾘｽﾄを設定
    '引　数：typEqTypeRecpList	：ﾚｼﾋﾟﾘｽﾄが入っている構造体
    '戻り値：なし
    '作成日：2024/02/16 (Fri) 11:52:20 T.Oide
    '更新日：2024/02/16 (Fri) 11:52:20
    '備　考：
    Private Sub prvcmbRecpList_Set(ByVal typEqTypeRecpList As List(Of eqtyperecplist))

        Dim lintCnt                 As Integer  'ｶｳﾝﾄ
		Dim lstrRecpListMoto		As String = vbNullString
		Dim lstrRecpListSaki		As String = vbNullString
		Dim lstrMotoJyouken			As String = txtMotoJyouken.Text
		Dim lstrSakiJyouken			As String = txtSakiJyouken.Text
		Dim lintListCnt1			As Integer = 0
		Dim lintListCnt2			As Integer = 0

        Try

			'構造体で回す
			For lintCnt = 0 To typEqTypeRecpList.Count - 1

				If vsfRecipeCopy.Col = CMintvsfCopyRecipe Then

					'ｺﾋﾟｰ元のﾘｽﾄ作成
					If lstrMotoJyouken = vbNullString Or _
					   InStr(typEqTypeRecpList(lintCnt).strRecipeID, lstrMotoJyouken) > 0 Then
						lstrRecpListMoto = lstrRecpListMoto & CPstrPipeString & typEqTypeRecpList(lintCnt).strRecipeID
						lintListCnt1 = lintListCnt1 + 1
					End If

				ElseIf vsfRecipeCopy.Col = CMintvsfCopyCpRecipe Then

					'ｺﾋﾟｰ先のﾘｽﾄ作成
					If lstrSakiJyouken = vbNullString Or _
					   InStr(typEqTypeRecpList(lintCnt).strRecipeID, lstrSakiJyouken) > 0 Then
						lstrRecpListSaki = lstrRecpListSaki & CPstrPipeString & typEqTypeRecpList(lintCnt).strRecipeID
						lintListCnt2 = lintListCnt2 + 1
					End If
				
				End If

				'100件越えた場合砂時計にする
				If Cursor.Current = Cursors.Default　AND (lintListCnt1 > 100 Or lintListCnt2 > 100) Then
					'ｶｰｿﾙを砂時計に変更
					Cursor.Current = Cursors.WaitCursor
				End If

			Next
            
			'ｸﾞﾘｯﾄﾞｺﾝﾎﾞﾘｽﾄ設定
			vsfRecipeCopy.Cols(CMintvsfCopyRecipe).ComboList = lstrRecpListMoto		'ｺﾋﾟｰ元ﾚｼﾋﾟ
            vsfRecipeCopy.Cols(CMintvsfCopyCpRecipe).ComboList = lstrRecpListSaki	'ｺﾋﾟｰ先ﾚｼﾋﾟ
			
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbRecpList_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

		Finally

			'ｶｰｿﾙを通常に変更
			Cursor.Current = Cursors.Default

        End Try

    End Sub
	
    '関数名：prvblnParaCopy_Chk
    '機　能：ﾊﾟﾗﾒｰﾀｺﾋﾟｰ確定時のﾁｪｯｸ
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2024/02/20 (Tue) 09:38:29 T.Oide
    '更新日：2024/02/20 (Tue) 09:38:29
    '備　考：
    Private Function prvblnParaCopy_Chk() As Boolean
		
        Dim lintCnt     As Integer  'ｶｳﾝﾀ
		Dim lintCnt2    As Integer  'ｶｳﾝﾀ
		Dim lstrRecipId	As String
        
		'戻り値の初期化
		prvblnParaCopy_Chk = False

        Try
			With vsfRecipeCopy


				'------------------------
                ' 登録済の背景灰色が無いかﾁｪｯｸ
                '------------------------
                '行でﾙｰﾌﾟ
                For lintCnt = 1 To .Rows.Count - 1
					
					'背景灰色か
					If IsNothing(.GetCellStyle(lintCnt, CMintvsfCopyRecipe)) = False Then
						If .GetCellStyle(lintCnt, CMintvsfCopyRecipe).BackColor = ColorTranslator.FromWin32(CPlngNotInputColor) Then

							'「 <TRM184W>$$登録済の行が存在します。$一旦登録した行は行削除してください。」表示
							pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0184)
							Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
							.Row = 0
							Exit Function
						End If
					End If
                Next

				'------------------------
                ' 空白の設定が無いか
				' ﾏｽﾀｰ未登録ﾚｼﾋﾟが無いか
                '------------------------
                '行でﾙｰﾌﾟ
                For lintCnt = 1 To .Rows.Count - 1
					
					'空白の列が無いか確認
					If .GetData(lintCnt, CMintvsfCopyRecipe) = vbNullString Or _
					   .GetData(lintCnt, CMintvsfCopyGouki) = vbNullString Or _
					   .GetData(lintCnt, CMintvsfCopyCpRecipe) = vbNullString Or _
					   .GetData(lintCnt, CMintvsfCopyCpGouki) = vbNullString  Then
							
						'「未設定の項目があるか、マスター登録のないレシピが設定されています。設定を見直してください。」表示
						pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0182)
						Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

						'編集状態にする
						.Select(lintCnt, CMintvsfCopyRecipe)
						Exit Function
					End If
				
                Next

                '------------------------
                ' ｺﾋﾟｰ先の重複が無いかﾁｪｯｸ
                '------------------------
                '行でﾙｰﾌﾟ
                For lintCnt = 1 To .Rows.Count - 1

					'ｺﾋﾟｰ先ﾚｼﾋﾟ
					lstrRecipId = .GetData(lintCnt, CMintvsfCopyCpRecipe)

					For lintCnt2 = 1 To .Rows.Count - 1

						'同じﾚｼﾋﾟか(自分以外で)
						If lintCnt <> lintCnt2 And _
						   lstrRecipId = .GetData(lintCnt2, CMintvsfCopyCpRecipe) Then
							
							'「コピー先レシピの設定が重複しています。設定を見直してください。」表示
							pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0181)
							Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

							'編集状態にする
							.Select(lintCnt2, CMintvsfCopyCpRecipe)
							Exit Function
						End If
					Next

                Next
                
            End With
                    
			'ﾁｪｯｸOK
            prvblnParaCopy_Chk = True
			
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnParaCopy_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try

    End Function

    '関数名：prvblnParaCopy_Set
    '機　能：ﾊﾟﾗﾒｰﾀｺﾋﾟｰﾚｼﾋﾟを構造体に格納する
    '引　数：typPhotofbdataCopy	：ｺﾋﾟｰ情報格納
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2024/02/20 (Tue) 09:38:29 T.Oide
    '更新日：2024/02/20 (Tue) 09:38:29
    '備　考：
    Private Function prvblnParaCopy_Set(ByRef typPhotofbdataCopy As photofbdatacopy) As Boolean
		
        Dim lintCnt     As Integer  'ｶｳﾝﾀ
		Dim lintCnt2    As Integer  'ｶｳﾝﾀ
		Dim lintCnt3    As Integer  'ｶｳﾝﾀ
		Dim strWpList	As String = Nothing	'ｺﾋﾟｰ先の装置ﾘｽﾄ
        
		'戻り値の初期化
		prvblnParaCopy_Set = False

		'構造体初期化
		If IsNothing(typPhotofbdataCopy.typRecpList) Then
			typPhotofbdataCopy.typRecpList = New List(Of typCpRecpList)
		Else
			typPhotofbdataCopy.typRecpList.Clear
		End If

        Try
			With vsfRecipeCopy
				
                '行でﾙｰﾌﾟ
                For lintCnt = 1 To .Rows.Count - 1

					Dim tmpCopyData As New typCpRecpList

					'ｺﾋﾟｰ先ﾚｼﾋﾟ
					tmpCopyData.strMotoRecipeID = .GetData(lintCnt, CMintvsfCopyRecipe)		'ｺﾋﾟｰ元ﾚｼﾋﾟ
					tmpCopyData.strSakiRecipeID = .GetData(lintCnt, CMintvsfCopyCpRecipe)	'ｺﾋﾟｰ先ﾚｼﾋﾟ

					'ｺﾋﾟｰ先装置ﾘｽﾄ作成
					'ﾚｼﾋﾟﾘｽﾄの中から対象のﾚｼﾋﾟを探す
					For lintCnt2 = 0 To mtypEqTypeRecpList.Count

						'ｺﾋﾟｰ先のﾚｼﾋﾟと一致したか
						If mtypEqTypeRecpList(lintCnt2).strRecipeID = tmpCopyData.strSakiRecipeID Then

							'ｺﾋﾟｰ先ﾚｼﾋﾟの装置ﾘｽﾄを作成する(IN句の中に入れる形で作成)
							For lintCnt3 = 0 To mtypEqTypeRecpList(lintCnt2).typWpList.Count - 1
								If strWpList <> vbNullString Then
									strWpList = strWpList & ", "
								End If
								strWpList = strWpList & "'" & mtypEqTypeRecpList(lintCnt2).typWpList(lintCnt3).strWpId & "'"
							Next
							Exit For
						End If
					Next

					tmpCopyData.strWpList = strWpList
					typPhotofbdataCopy.typRecpList.Add(tmpCopyData)
                Next
                
            End With
                    
			'結果OK
            prvblnParaCopy_Set = True
			
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnParaCopy_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try

    End Function

	'関数名：prvClipPaste
    '機　能：ｸﾘｯﾌﾟﾎﾞｰﾄﾞ貼付け(合せ、露光)
    '引　数：lobjGrid	:対象グリッド
	'      ：strDataLine:ｸﾘｯﾌﾟﾎﾞｰﾄﾞの中身
    '戻り値：なし
    '作成日：2024/02/20 (Tue) 09:38:29 T.Oide
    '更新日：2024/02/20 (Tue) 09:38:29
    '備　考：
	Private Sub prvClipPaste(ByRef lobjGrid As C1FlexGrid, ByRef strDataLine() As String)

		Dim llngRowCnt              As Integer      '行ﾙｰﾌﾟｶｳﾝﾄ
		Dim llngColCnt              As Integer      '列ﾙｰﾌﾟｶｳﾝﾄ
		Dim lstrDataelement()       As String       '1ﾃﾞｰﾀ
		
		Try
			'一覧に張付る
            With lobjGrid
                
                '行ﾙｰﾌﾟ
                For llngRowCnt = 0 To .Rows.Count - 2
                    
                    '@1つのﾃﾞｰﾀを取得(element(0)～(7)に各ﾊﾟﾗﾒｰﾀの値が入っている状態)
                    lstrDataelement = Split(strDataLine(llngRowCnt), vbTab)
                    
                    '@列ﾙｰﾌﾟ
                    For llngColCnt = 0 To .Cols.Count - 2
                                    
                        '@ｾﾙに値をｾｯﾄ
                        .SetData(llngRowCnt + 1, llngColCnt + 1, CDbl(lstrDataelement(llngColCnt)))
                        
                    Next llngColCnt
                    
                Next llngRowCnt
                
            End With

			Exit Sub

		Catch ex As Exception

			'@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvClipPaste"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

		End Try

	End Sub

	'関数名：prvClipPasteParaCopy
    '機　能：ｸﾘｯﾌﾟﾎﾞｰﾄﾞ貼付け(ﾊﾟﾗﾒｰﾀｺﾋﾟｰ)
    '引　数：lobjGrid	:対象グリッド
	'      ：strDataLine:ｸﾘｯﾌﾟﾎﾞｰﾄﾞの中身
    '戻り値：なし
    '作成日：2024/02/20 (Tue) 09:38:29 T.Oide
    '更新日：2024/02/20 (Tue) 09:38:29
    '備　考：
	Private Sub prvClipPasteParaCopy(ByRef lobjGrid As C1FlexGrid, ByRef strDataLine() As String)

		Dim lintDataCnt				As Integer
		Dim lintRow					As Integer
		Dim lstrDataelement()       As String       '1ﾃﾞｰﾀ
		Dim lintRowCnt				As Integer
		
		Try
			'ｸﾞﾘｯﾄﾞに表示する
            With lobjGrid
                
                '行ﾙｰﾌﾟ
                For lintDataCnt = 0 To UBound(strDataLine) - 1

					'行を追加する
					.AddItem(vbNullString, .Rows.Count)
					.Rows(.Rows.Count - 1).Height = CMlngVsfHHeight         '行高さ設定
					lintRow = .Rows.Count - 1								'入力行設定

                    '1行のﾃﾞｰﾀを取得(element(0)～(1)にｺﾋﾟｰ元ﾚｼﾋﾟ、ｺﾋﾟｰ先ﾚｼﾋﾟが入っている状態)
                    lstrDataelement = Split(strDataLine(lintDataCnt), vbTab)
                    
                    'ｾﾙに値をｾｯﾄ
                    .SetData(lintRow, CMintvsfCopyRecipe, lstrDataelement(0))	'ｺﾋﾟｰ元ﾚｼﾋﾟ
					.SetData(lintRow, CMintvsfCopyCpRecipe, lstrDataelement(1))	'ｺﾋﾟｰ先ﾚｼﾋﾟ
					'.Refresh
                Next
                
				'ﾚｼﾋﾟ登録号機表示
				For lintRowCnt = 1 To .Rows.Count - 1

					.Row = lintRowCnt				'対象行を設定

					'ｺﾋﾟｰ元ﾚｼﾋﾟのﾚｼﾋﾟ登録号機表示
					.Col = CMintvsfCopyRecipe		'ｺﾋﾟｰ元ﾚｼﾋﾟ列設定
					Call prvTourokuGoukiSet()

					'ｺﾋﾟｰ先ﾚｼﾋﾟのﾚｼﾋﾟ登録号機表示
					.Col = CMintvsfCopyCpRecipe		'ｺﾋﾟｰ先ﾚｼﾋﾟ列設定
					Call prvTourokuGoukiSet()

				Next

				'ｸﾞﾘｯﾄﾞ有効化
				.Enabled = True

            End With

			Exit Sub

		Catch ex As Exception

			'@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvClipPasteParaCopy"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

		End Try

	End Sub

    '関数名：prvCmdButton_Chk
    '機　能：ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/18 (Tue) 11:02:33 N.Kasai
    '更新日：2017/03/10 (Fri) 17:01:41 T.Oide
    '備　考：
    Private Sub prvCmdButton_Chk()
        
        Dim llngCnt             As Integer  '汎用ｶｳﾝﾀ
        Dim lblnFlag            As Integer  '汎用ﾌﾗｸﾞ
        Dim lblnPatchDivFlag    As Boolean  'patch分割ﾌﾗｸﾞ

        Try
            '選択中のﾀﾌﾞで分岐
            Select Case tabRecipe.SelectedTab.Name
            
                '@合せﾀﾌﾞ
                Case Tab0.Name
                
                    '@patch分割ﾌﾗｸﾞ設定
                    '@patch分割設対象外 or 分割なしか(1は分割なし、0はありえないはずだが一応)
                    If ptypPhotoFbDataListAns.strPatchDivideNumRecipe = vbNullString Or _
                       ptypPhotoFbDataListAns.strPatchDivideNumRecipe = "0" Or _
                       ptypPhotoFbDataListAns.strPatchDivideNumRecipe = "1" Then
                       '@ﾊﾟｯﾁ分割なしの場合
                       lblnPatchDivFlag = False
                    Else
                        '@ﾊﾟｯﾁ分割ありの場合
                        lblnPatchDivFlag = True
                    End If
                
                    '@--------------------
                    '@確定ﾎﾞﾀﾝ制御
                    '@--------------------
					cmdProcEnd.Visible = True
                    lblnFlag = False
                    '@ﾃﾞｰﾀｸﾞﾘｯﾄﾞ
                    With vsfFbData
                        For llngCnt = 1 To .Cols.Count - 1
                            If .GetData(1, llngCnt) = vbNullString AndAlso .GetData(1, llngCnt) <> "0" Then
                                lblnFlag = True
                                Exit For
                            End If
                        Next
                    End With
                    '@結果判定
                    If lblnFlag = False Then
                        cmdProcEnd.Enabled = True
                    Else
                        cmdProcEnd.Enabled = False
                    End If
                    
                    '@--------------------
                    '@行ｺﾋﾟｰﾎﾞﾀﾝ制御
                    '@--------------------
					cmdCopy.Visible = True

                    '@ﾃﾞｰﾀﾘｽﾄ
                    With vsfFbDataList
                        If .Row > 0 Then
                            cmdCopy.Enabled = True
                        Else
                            cmdCopy.Enabled = False
                        End If
                    End With
                    
                    '@patch分割設ありか
                    If lblnPatchDivFlag = True Then
                        '@ﾊﾟｯﾁ分割ありの場合は常に無効
                        cmdCopy.Enabled = False
                    End If
                    
                    '@--------------------
                    '@行貼り付ﾎﾞﾀﾝ制御
                    '@--------------------
					cmdPaste.Visible = True

                    '@行ｺﾋﾟｰﾌﾗｸﾞ（ON)
                    If mblnCpoyLineFlag = True Then
                        cmdPaste.Enabled = True
                    Else
                        cmdPaste.Enabled = False
                    End If

                    '@patch分割設ありか
                    If lblnPatchDivFlag = True Then
                        '@ﾊﾟｯﾁ分割ありの場合は常に無効
                        cmdPaste.Enabled = False
                    End If
                
                    '@--------------------
                    '@patch分割設定制御
                    '@--------------------
                    '@patch分割設ありか
                    If lblnPatchDivFlag = True Then
                        '@ﾊﾟｯﾁ分割ありの場合
                        cmdPatDivSet.Enabled = True     'Patch分割設定ﾎﾞﾀﾝ
                        cmdCopy.Enabled = False         'ｺﾋﾟｰﾎﾞﾀﾝ
                        cmdPaste.Enabled = False        '行貼り付けﾎﾞﾀﾝ
                    Else
                        '@ﾊﾟｯﾁ分割なしor対象外の場合
                        cmdPatDivSet.Enabled = False    'Patch分割設定ﾎﾞﾀﾝ
                        
                    End If

                    '@--------------------
                    '@ ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ/ﾍﾟｰｽﾄ
                    '@--------------------
					cmdClipCopy.Visible = True
					cmdClipPaste.Visible = True

                    '@patch分割設ありか
                    If lblnPatchDivFlag = True Then
                        '@ﾊﾟｯﾁ分割ありの場合
                        cmdClipCopy.Enabled = False         'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
                        cmdClipPaste.Enabled = False        'ｸﾘｯﾌﾟﾎﾞｰﾄﾞﾍﾟｰｽﾄ
                    Else
                        '@検索済か
                        If mblnAfterSerchFlag = True Then
                            '@ﾊﾟｯﾁ分割なしor対象外の場合
                            cmdClipCopy.Enabled = True          'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
                            cmdClipPaste.Enabled = True         'ｸﾘｯﾌﾟﾎﾞｰﾄﾞﾍﾟｰｽﾄ
                        Else
                            cmdClipCopy.Enabled = False         'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
                            cmdClipPaste.Enabled = False        'ｸﾘｯﾌﾟﾎﾞｰﾄﾞﾍﾟｰｽﾄ
                        End If
                    End If
                
					'@--------------------
                    '@ patch分割設定
                    '@--------------------
					cmdPatDivSet.Visible = True

					'@--------------------
                    '@ 行追加／行削除
                    '@--------------------
					cmdLineAdd.Visible =  False
					cmdLineAdd.Enabled = False
					cmdLineDel.Visible =  False
					cmdLineDel.Enabled = False

					'@--------------------
                    '@ コピーデータ確認
                    '@--------------------
					cmdKakuninA.Visible = False
					cmdKakuninA.Enabled = False
					cmdKakuninR.Visible = False
					cmdKakuninR.Enabled = False

                '@露光ﾀﾌﾞ
                Case Tab1.Name
                
                    '@--------------------
                    '@確定ﾎﾞﾀﾝ制御
                    '@--------------------
					cmdProcEnd.Visible = True
                    lblnFlag = False
                    '@ﾃﾞｰﾀｸﾞﾘｯﾄﾞ
                    With vsfFbData2
                        For llngCnt = 1 To .Cols.Count - 1
                            If .GetData(1, llngCnt) = vbNullString AndAlso .GetData(1, llngCnt) <> "0" Then
                                lblnFlag = True
                                Exit For
                            End If
                        Next
                    End With
                    '@結果判定
                    If lblnFlag = False Then
                        cmdProcEnd.Enabled = True
                    Else
                        cmdProcEnd.Enabled = False
                    End If
                    
                    '@--------------------
                    '@行ｺﾋﾟｰﾎﾞﾀﾝ制御
                    '@--------------------
					cmdCopy.Visible = True

                    '@ﾃﾞｰﾀﾘｽﾄ
                    With vsfFbDataList2
                        If .Row > 0 Then
                            cmdCopy.Enabled = True
                        Else
                            cmdCopy.Enabled = False
                        End If
                    End With
                
                    '@--------------------
                    '@行貼り付ﾎﾞﾀﾝ制御
                    '@--------------------
					cmdPaste.Visible = True

                    '@行ｺﾋﾟｰﾌﾗｸﾞ（ON)
                    If mblnCpoyLine2Flag = True Then
                        cmdPaste.Enabled = True
                    Else
                        cmdPaste.Enabled = False
                    End If
                
                    '@--------------------
                    '@ ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ/ﾍﾟｰｽﾄ
                    '@--------------------
					cmdClipCopy.Visible = True
					cmdClipPaste.Visible = True

                    '@検索済か
                    If mblnAfterSerch2Flag = True Then
                        cmdClipCopy.Enabled = True          'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
                        cmdClipPaste.Enabled = True         'ｸﾘｯﾌﾟﾎﾞｰﾄﾞﾍﾟｰｽﾄ
                    Else
                        cmdClipCopy.Enabled = False         'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
                        cmdClipPaste.Enabled = False        'ｸﾘｯﾌﾟﾎﾞｰﾄﾞﾍﾟｰｽﾄ
                    End If
				
					'@--------------------
                    '@ patch分割設定
                    '@--------------------
					cmdPatDivSet.Visible = True

					'@--------------------
                    '@ 行追加／行削除
                    '@--------------------
					cmdLineAdd.Visible =  False
					cmdLineAdd.Enabled = False
					cmdLineDel.Visible =  False
					cmdLineDel.Enabled = False

					'@--------------------
                    '@ コピーデータ確認
                    '@--------------------
					cmdKakuninA.Visible = False
					cmdKakuninA.Enabled = False
					cmdKakuninR.Visible = False
					cmdKakuninR.Enabled = False


				'ﾊﾟﾗﾒｰﾀｺﾋﾟｰﾀﾌﾞ
                Case Tab2.Name

					'ﾎﾞﾀﾝ表示/非表示
					cmdCopy.Visible = False			'行ｺﾋﾟｰ
					cmdPaste.Visible = False		'行貼付け
					cmdClipCopy.Visible = False		'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
					cmdClipPaste.Visible = True		'ｸﾘｯﾌﾟﾎﾞｰﾄﾞﾍﾟｰｽﾄ
					cmdPatDivSet.Visible = False	'patch分割設定
                    cmdLineAdd.Visible =  True		'行追加
					cmdLineDel.Visible =  True		'行削除
					cmdKakuninA.Visible =  True		'コピーデータ確認(合せ)
					cmdKakuninR.Visible =  True		'コピーデータ確認(露光)
					cmdProcEnd.Visible = True		'確定ﾎﾞﾀﾝ制御
					

                    '--------------------
                    ' 確定ﾎﾞﾀﾝ制御
                    '--------------------
                    lblnFlag = True
                    'ﾃﾞｰﾀｸﾞﾘｯﾄﾞ
                    With vsfRecipeCopy
                        For llngCnt = 1 To .Rows.Count - 1
                            If .GetData(llngCnt, CMintvsfCopyRecipe) = vbNullString Or _
							   .GetData(llngCnt, CMintvsfCopyGouki) = vbNullString Or _
							   .GetData(llngCnt, CMintvsfCopyCpRecipe) = vbNullString Or _
							   .GetData(llngCnt, CMintvsfCopyCpGouki) = vbNullString Then

                                lblnFlag = False
                                Exit For
                            End If
                        Next

						'有効行が無い場合
						If .Rows.Count <= 1 Then
							lblnFlag = False
						End If

                    End With

                    '結果判定
                    If lblnFlag = True Then
                        cmdProcEnd.Enabled = True
                    Else
                        cmdProcEnd.Enabled = False
                    End If
                    
                    '@--------------------
                    '@行ｺﾋﾟｰﾎﾞﾀﾝ制御
                    '@--------------------
					cmdCopy.Enabled = False
                
                    '@--------------------
                    '@行貼り付ﾎﾞﾀﾝ制御
                    '@--------------------
					cmdPaste.Enabled = False

					'@--------------------
					'@ ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ/ﾍﾟｰｽﾄ
					'@--------------------
					cmdClipCopy.Enabled = False			'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
					cmdClipPaste.Enabled = True         'ｸﾘｯﾌﾟﾎﾞｰﾄﾞﾍﾟｰｽﾄ

					'@--------------------
                    '@ patch分割設定
                    '@--------------------
					cmdPatDivSet.Enabled = False

					'@--------------------
                    '@ 行追加
                    '@--------------------
					cmdLineAdd.Enabled = True

					'@--------------------
                    '@ 行削除
                    '@--------------------
					If vsfRecipeCopy.Row > 0 Then
						cmdLineDel.Enabled = True
					Else
						cmdLineDel.Enabled = False
					End If

					'@--------------------
                    '@ コピーデータ確認
                    '@--------------------
					With vsfRecipeCopy

						'ﾍｯﾀﾞｰ行の場合は無効
						If .Row > 0 Then

							'列が「ｺﾋﾟｰ元ﾚｼﾋﾟ」で「登録号機」がNULL以外、または
							'列が「ｺﾋﾟｰ先ﾚｼﾋﾟ」で「登録号機」がNULL以外の場合、有効
							If (.Col = CMintvsfCopyRecipe And .GetData(.Row, CMintvsfCopyGouki) <> vbNullString) Or _
							   (.Col = CMintvsfCopyCpRecipe And .GetData(.Row, CMintvsfCopyCpGouki) <> vbNullString) Then
								cmdKakuninA.Enabled = True
								cmdKakuninR.Enabled = True
							Else
								cmdKakuninA.Enabled = False
								cmdKakuninR.Enabled = False
							End If

						Else
							cmdKakuninA.Enabled = False
							cmdKakuninR.Enabled = False
						End If

					End With

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = "CMstrLocalMenuKey"
                .strProcName = "prvCmdButton_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvSetcmbPatchNo
    '機　能：PatchNoｺﾝﾎﾞの設定を行う
    '引　数：なし
    '戻り値：
    '作成日：2017/01/20 (Fri) 09:22:54 T.Oide
    '更新日：2017/01/20 (Fri) 09:22:54
    '備　考：
    Private Sub prvSetcmbPatchNo(ByVal llngPatchNum As Integer)
        
        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ
        
        Try
            
            '@ﾘｽﾄを追加
            cmbPatchNo.Clear
            cmbPatchNo.ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左中央

            For llngCnt = 1 To llngPatchNum
                cmbPatchNo.AddItem(llngCnt & vbTab & llngCnt)
            Next llngCnt
            
            '@ﾊﾟｯﾁ分割数が2以下の場合は無効
            If llngPatchNum < CPlngPatchNo2 Then
                cmbPatchNo.Enabled = False
            Else
                cmbPatchNo.Enabled = True
                cmbPatchNo.ListIndex = 0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = "CMstrLocalMenuKey"
                .strProcName = "prvSetcmbPatchNo"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvClipCheck
    '機　能：ｸﾘｯﾌﾟﾎﾞｰﾄﾞのﾃﾞｰﾀﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2017/01/26 (Thu) 14:42:54 T.Oide
    '更新日：2017/01/26 (Thu) 14:42:54
    '備　考：
    Private Function prvClipCheck(ByRef lstrDataLine() As String) As Boolean

        Dim llngRowCnt              As Integer      '行ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngColCnt              As Integer      '列ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrDataelement()       As String       '1ﾃﾞｰﾀ
        
        Try

            '@結果初期化
            prvClipCheck = False

            With vsfFbData
            
                'ﾃﾞｰﾀの貼付数確認
                If .Rows.Count - 1 <> UBound(lstrDataLine) Then
                    '@ﾊﾟｯﾁ数が正しくありません表示
            
                    '@"<TRM143W>$$設定patch数が異なっています。$ｸﾘｯﾌﾟﾎﾞｰﾄﾞのﾃﾞｰﾀを再確認してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0143)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Function
                End If
            
                'ﾃﾞｰﾀの型確認
                For llngRowCnt = 0 To UBound(lstrDataLine) - 1
                    
                    '@1つのﾃﾞｰﾀを取得(element(0)～(7)に各ﾊﾟﾗﾒｰﾀの値が入っている状態)
                    lstrDataelement = Split(lstrDataLine(llngRowCnt), vbTab)
                    
                    '@ﾊﾟﾗﾒｰﾀ数確認
                    If UBound(lstrDataelement) + 1 = CMlngParameterNum Then
                    
                        '@ﾃﾞｰﾀの型ﾁｪｯｸ
                        For llngColCnt = 0 To CMlngParameterNum - 1
                        
                            '@数値以外か
                            If IsNumeric(lstrDataelement(llngColCnt)) = False Then
                                
                                '@数値ﾃﾞｰﾀではありません表示                               
                                '@"<TRM145W>$$patch[%1]のﾊﾟﾗﾒｰﾀ[%2]に数値以外の値が設定されています。$ｸﾘｯﾌﾟﾎﾞｰﾄﾞのﾃﾞｰﾀを再確認してください。"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0145, llngRowCnt + 1, llngColCnt + 1)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                Exit Function
                            End If

                        Next
                    Else
                        '@ﾊﾟﾗﾒｰﾀ数が正しくありません表示
                        
                        '@"<TRM144W>$$patch[%1]のﾊﾟﾗﾒｰﾀ数が正しくありません。$ｸﾘｯﾌﾟﾎﾞｰﾄﾞのﾃﾞｰﾀを再確認してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0144, llngRowCnt + 1)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Exit Function
                    End If

                Next
                
            End With

            '@結果格納
            prvClipCheck = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvClipCheck"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    ''' <summary>
    ''' クリップボードデータチェック（露光）
    ''' </summary>
    ''' <param name="lstrDataLine"></param>
    ''' <returns></returns>
    Private Function prvClipCheck2(ByRef lstrDataLine() As String) As Boolean

        Dim llngRowCnt              As Integer      '行ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngColCnt              As Integer      '列ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrDataelement()       As String       '1ﾃﾞｰﾀ
        
        Try

            '@結果初期化
            prvClipCheck2 = False

            With vsfFbData
            
                'ﾃﾞｰﾀの貼付数確認
                If .Rows.Count - 1 <> UBound(lstrDataLine) Then
                    '@ﾊﾟｯﾁ数が正しくありません表示
            
                    '@"<TRM143W>$$設定patch数が異なっています。$ｸﾘｯﾌﾟﾎﾞｰﾄﾞのﾃﾞｰﾀを再確認してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0143)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Function
                End If
            
                'ﾃﾞｰﾀの型確認
                For llngRowCnt = 0 To UBound(lstrDataLine) - 1
                    
                    '@1つのﾃﾞｰﾀを取得(element(0)～(7)に各ﾊﾟﾗﾒｰﾀの値が入っている状態)
                    lstrDataelement = Split(lstrDataLine(llngRowCnt), vbTab)
                    
                    '@ﾊﾟﾗﾒｰﾀ数確認
                    If UBound(lstrDataelement) + 1 = CMlngParameterNum2 Then
                    
                        '@ﾃﾞｰﾀの型ﾁｪｯｸ
                        For llngColCnt = 0 To CMlngParameterNum2 - 1
                        
                            '@数値以外か
                            If IsNumeric(lstrDataelement(llngColCnt)) = False Then
                                
                                '@数値ﾃﾞｰﾀではありません表示                               
                                '@"<TRM145W>$$patch[%1]のﾊﾟﾗﾒｰﾀ[%2]に数値以外の値が設定されています。$ｸﾘｯﾌﾟﾎﾞｰﾄﾞのﾃﾞｰﾀを再確認してください。"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0145, llngRowCnt + 1, llngColCnt + 1)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                Exit Function
                            End If

                        Next
                    Else
                        '@ﾊﾟﾗﾒｰﾀ数が正しくありません表示
                        
                        '@"<TRM144W>$$patch[%1]のﾊﾟﾗﾒｰﾀ数が正しくありません。$ｸﾘｯﾌﾟﾎﾞｰﾄﾞのﾃﾞｰﾀを再確認してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0144, llngRowCnt + 1)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Exit Function
                    End If

                Next
                
            End With

            '@結果格納
            prvClipCheck2 = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvClipCheck2"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

	'関数名：prvTourokuGoukiSet
    '機　能：ﾚｼﾋﾟの設定で登録号機を表示する
    '引　数：なし
    '戻り値：
    '作成日：2024/02/19 (Mon) 11:53:54 T.Oide
    '更新日：2024/02/19 (Mon) 11:53:54
    '備　考：
	Private Sub prvTourokuGoukiSet()

		Dim lintRecpCnt			As Integer
		Dim lintCntWp			As Integer
		Dim lstrRecipeId		As String = vbNullString
		Dim lstrDispWp			As String = vbNullString

		Try
			With vsfRecipeCopy

				lstrRecipeId = .GetData(.Row, .Col)

				'登録号機を構造体から取得
				For lintRecpCnt = 0 To mtypEqTypeRecpList.Count - 1

					'ﾚｼﾋﾟは一致したか
					If lstrRecipeId = mtypEqTypeRecpList(lintRecpCnt).strRecipeID Then

						'装置名を取得する(末尾3文字)
						For lintCntWp = 0 To mtypEqTypeRecpList(lintRecpCnt).typWpList.Count - 1
							lstrDispWp = lstrDispWp & " " & Mid(mtypEqTypeRecpList(lintRecpCnt).typWpList(lintCntWp).strWpName, _
														    inStr(mtypEqTypeRecpList(lintRecpCnt).typWpList(lintCntWp).strWpName, "#") , 2)
						Next
						
						Exit For
					End If
				Next

				'登録号機を表示
				.SetData(.Row, .Col + 1, lstrDispWp)

			End With

			Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvClipCheck2"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try

	End Sub

	'関数名：prvClipCheckCopy
    '機　能：ﾊﾟﾗﾒｰﾀｺﾋﾟTabでｸﾘｯﾌﾟﾎﾞｰﾄﾞの内容をｸﾞﾘｯﾄﾞに表示する
    '引　数：なし
    '戻り値：
    '作成日：2024/02/19 (Mon) 11:53:54 T.Oide
    '更新日：2024/02/19 (Mon) 11:53:54
    '備　考：
	Private Function prvClipCheckCopy(ByRef lstrDataLine() As String) As Boolean

        Dim lintRowCnt              As Integer      '行ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrDataelement()       As String       '1ﾃﾞｰﾀ
        
		'結果初期化
		prvClipCheckCopy = False
		
        Try
            With vsfRecipeCopy
            
                'ﾃﾞｰﾀの型確認
                For lintRowCnt = 0 To UBound(lstrDataLine) - 1
                    
                    '1つのﾃﾞｰﾀを取得(element(0)～(1)にｺﾋﾟｰ元とｺﾋﾟｰ先のﾚｼﾋﾟが入っている状態)
                    lstrDataelement = Split(lstrDataLine(lintRowCnt), vbTab)
                    
                    'ﾊﾟﾗﾒｰﾀ数確認
                    If UBound(lstrDataelement) + 1 <> CMlngParameterNum3 Then
                        
                        '<TRM183W>$$クリップボードにコピーした項目数が正しくありません。
						'          $[コピー元]と[コピー先]のレシピをクリップボードコピーしてください。
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0183)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Exit Function
                    End If

                Next
                
            End With

            '結果格納
            prvClipCheckCopy = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvClipCheckCopy"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try

    End Function

	'関数名：prvVsfRecipeCopyBackclor_chg
    '機　能：ﾊﾟﾗﾒｰﾀｺﾋﾟTabでｺﾋﾟｰ実行後にｸﾞﾘｯﾄﾞに背景を灰色にする
    '引　数：なし
    '戻り値：
    '作成日：2024/02/19 (Mon) 11:53:54 T.Oide
    '更新日：2024/02/19 (Mon) 11:53:54
    '備　考：
	Private Sub prvVsfRecipeCopyBackclor_chg()
        
        Try
			With vsfRecipeCopy

				'背景色を灰色に変更
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                Dim cellRange As CellRange = .GetCellRange(1, CMintvsfCopyRecipe, .Rows.Count - 1, CMintvsfCopyCpGouki)
                cellRange.Style = newStyle
				
				.Row = 0

			End With
			
			Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfRecipeCopyBackclor_chg"
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfFbData.BeforeDoubleClick, vsfFbData2.BeforeDoubleClick, vsfFbDataList.BeforeDoubleClick, vsfFbDataList2.BeforeDoubleClick

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

        gridObj.AllowEditing = False

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True
            
        End If

    End Sub

    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfFbData.KeyDownEdit, vsfFbData2.KeyDownEdit, vsfFbDataList.KeyDownEdit, vsfFbDataList2.KeyDownEdit

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

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles cmbReferenceWP.Enter,
                                                                       cmbPatchNo.Enter,
                                                                       cmbWP.Enter,
                                                                       cmbWP2.Enter,
                                                                       cmdClipCopy.Enter,
                                                                       cmdClipPaste.Enter,
                                                                       cmdClose.Enter,
                                                                       cmdCommentDown.Enter,
                                                                       cmdCommentDown2.Enter,
                                                                       cmdCommentUp.Enter,
                                                                       cmdCommentUp2.Enter,
                                                                       cmdCopy.Enter,
                                                                       cmdDown.Enter,
                                                                       cmdDown2.Enter,
                                                                       cmdLeft.Enter,
                                                                       cmdLeft2.Enter,
                                                                       cmdPaste.Enter,
                                                                       cmdPatDivSet.Enter,
                                                                       cmdProcEnd.Enter,
                                                                       cmdRecipe.Enter,
                                                                       cmdRecipe2.Enter,
                                                                       cmdRight.Enter,
                                                                       cmdRight2.Enter,
                                                                       cmdSearch.Enter,
                                                                       cmdSearch2.Enter,
                                                                       cmdUP.Enter,
                                                                       cmdUP2.Enter,
                                                                       tabRecipe.Enter,
                                                                       txtComments.Enter,
                                                                       txtComments2.Enter,
                                                                       txtRecipeID.Enter,
                                                                       txtRecipeID2.Enter,
                                                                       vsfFbData.Enter,
                                                                       vsfFbData2.Enter,
                                                                       vsfFbDataList.Enter,
                                                                       vsfFbDataList2.Enter
        
        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF
            Case cmdClose.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            Case tabRecipe.Name
                If Me.ActiveControl.Name = tabRecipe.Name Then
                    Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
                End If
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub
    
    '関数名：tabList_Deselecting
    '機　能：タブの選択が解除される前に発生するイベント処理
    '引　数：sender：イベント発生源のオブジェクト
    '        e     ：イベント情報
    '戻り値：なし
    '作成日：2018/10/12 (Fri) NSYS
    '更新日：
    '備　考：
    Private Sub tabList_Deselecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles tabRecipe.Deselecting

        '処理中の場合またはタブ切り替えが無効の場合はタブ選択をキャンセルする
        If Me.buttonProcessing = True OrElse mblnTabSelectEnabled = False Then
            e.Cancel = True
            mblnTabSelectEnabled = True
        End If

    End Sub


End Class
