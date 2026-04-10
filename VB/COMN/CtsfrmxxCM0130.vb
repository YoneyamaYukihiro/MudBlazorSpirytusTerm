'ﾌｧｲﾙ名：xxCM0130.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：空き冶具一覧　メインフォーム
'作成日：2009/07/21 (Tue) 13:35:27 T.Oide
'更新日：2015/07/23 (Thu) 09:43:34 T.Inafune
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2015, all rights reserved.

Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM0130
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM0130    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM0130
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM0130
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM0130)
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
    '====================================Private============================================
    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyCM0130  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ

    Private Const CMstrjig_jyclist__Ver             As String = "02.01"         '無機治具情報一覧取得MsgVer
    Private Const CMstrjig_jjiglistVer				As String = "01.00"         '蒸着治具情報一覧取得MsgVer
 
    '@ComboBox設定
    Private Const CMlngCmbFontSize                  As Integer = 11                'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 11                'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽ
    Private Const CMlngCmbValueCol                  As Integer = 1                 '値取得列
    Private Const CMlngCmbGetCol                    As Integer = 0                 '表示列
    Private Const CMlngCmbDispColIndex              As Integer = 0                 '表示列番

    'ｺﾝﾎﾞﾎﾞｯｸｽ定義ｱｲﾃﾑ
    Private Const CMstrCmbItemAll                   As String = "全て"
    Private Const CMstrJigClassJycId                As String = "J"
    Private Const CMstrJigClassJycNm                As String = "蒸着"
    Private Const CMstrJigClassHirId                As String = "H"
    Private Const CMstrJigClassHirNm                As String = "平置き"
    Private Const CMstrPanelKindTFTId               As String = "T"
    Private Const CMstrPanelKindTFTNm               As String = "TFT"
    Private Const CMstrPanelKindCFId                As String = "C"
    Private Const CMstrPanelKindCFNm                As String = "CF(小板)"
    Private Const CMstrPanelKindDummy               As String = "D"
    Private Const CMstrPanelKindDummyNm             As String = "ダミー"
    Private Const CMstrPanelKindODF                 As String = "O"
    Private Const CMstrPanelKindODFNm               As String = "CF(大板)"

	'蒸着治具カテゴリコンボ
	Private Const CMstrCmbJJigCategoryGuideId			As String = "G"
	Private Const CMstrCmbJJigCategoryGuideNm			As String = "ガイドリング"
	Private Const CMstrCmbJJigCategoryMaskId			As String = "M"
	Private Const CMstrCmbJJigCategoryMaskNm			As String = "マスク"
	Private Const CMstrCmbJJigCategoryHolderId			As String = "H"
	Private Const CMstrCmbJJigCategoryHolderNm			As String = "ホルダ"
	Private Const CMstrCmbJJigCategoryDummyId			As String = "D"
	Private Const CMstrCmbJJigCategoryDummyNm			As String = "ダミープレート"
	Private Const CMstrCmbJJigCategoryAll				As String = "A"
	Private Const CMstrCmbJJigCategoryAllNm				As String = "全て"

    '@↓2013/05/16 (Thu) 16:50:48 T.Oide **************************************************
    Private Const CMlngCmbItemAll                   As Integer = 0     'コンボのIndex(全て)
    Private Const CMlngCmbItemTFT                   As Integer = 1     'コンボのIndex(TFT)
    Private Const CMlngCmbItemCF                    As Integer = 2     'コンボのIndex(CF(小板))
    Private Const CMlngCmbItemODF                   As Integer = 3     'コンボのIndex(CF(大板))
    Private Const CMlngCmbItemDummy                 As Integer = 4     'コンボのIndex(ダミー)

    Private Const CMlngAtlasFlowNumTPAL             As Integer = 1     'TPAL品
    Private Const CMlngAtlasFlowNumODF              As Integer = 2     'ODF品
    '@↑2013/05/16 (Thu) 16:50:48 T.Oide **************************************************

    Private Const CMstrListIsNull                   As String = ""

    '@治具識別ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbGridColName               As Integer = 0                 '名称列番
    Private Const CMlngCmbGridColID                 As Integer = 1                 'ID列番(非表示項目)
    Private Const CMlngCmbDispCols                  As Integer = 1                 'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbListIndex                 As Integer = 0                 'ﾘｽﾄｲﾝﾃﾞｯｸｽ
    Private Const CMlngCmbRowHeight                 As Integer = 270/15            'ﾘｽﾄ行の高さ


    '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
    Private Const CMstrvsfJigListNo                 As String = "№"            '№
    Private Const CMstrvsfJigListCreanTime          As String = "最終洗浄日時"  '最終洗浄日時
    Private Const CMstrvsfJigListJig                As String = "空き治具ID"    '空き治具一覧
	Private Const CMstrvsfJigListJJigCategory       As String = "蒸着治具カテゴリ"    '蒸着治具カテゴリ
    Private Const CMstrvsfJigListUseNum             As String = "洗浄後使用回数"'洗浄後使用回数
    Private Const CMstrvsfJigListCategory           As String = "カテゴリ"      'カテゴリ

    '@表の行ﾀｲﾄﾙ
    Private Const CMlngvsfJigListNo                 As Integer = 0                 '№
    Private Const CMlngvsfJigListCreanTime          As Integer = 1                 '最終洗浄日
    Private Const CMlngvsfJigListJigID              As Integer = 2                 '治具ID
	Private Const CMlngvsfJigListJJigCategory       As Integer = 3                 '蒸着治具カテゴリ
    Private Const CMlngvsfUseNum                    As Integer = 4                 '使用回数
    Private Const CMlngvsfCategory                  As Integer = 5                 'カテゴリ

    '@表の列幅
    Private Const CMlngvsfWJigListNo                As Integer = 30                '№
    Private Const CMlngvsfWJigListCreanTime         As Integer = 146               '最終洗浄日
    Private Const CMlngvsfWJigListJigID             As Integer = 117               '治具ID
	Private Const CMlngvsfWJigListJJigCategory      As Integer = 150               '蒸着治具カテゴリ
    Private Const CMlngvsfWUseNum                   As Integer = 117               '使用回数
    Private Const CMlngvsfWCategory                 As Integer = 100               'カテゴリ

    '@ｸﾞﾘｯﾄﾞの設定
    Private Const CMlngvsfJigListRowHeight          As Integer = 24                '行高さ
    Private Const CMlngvsfJigListTitleRowHeight     As Integer = 20                'ﾀｲﾄﾙ行高さ
    Private Const CMlngvsfJigListFontSize           As Integer = 11                'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfJigListTitleFontSize      As Integer = 11                'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfJigListTitleRow           As Integer = 0                 'ﾀｲﾄﾙ行

    Private Const CMstrDefYmdHms                    As String = "0000/00/00 00:00:00"   'ﾃﾞﾌｫﾙﾄ年月日日時
    Private Const CMstrDefY2mdHms                   As String = "00/00/00 00:00:00"     'ﾃﾞﾌｫﾙﾄ年月日日時
    Private Const CMstrDefMdHm                      As String = "00/00 00:00"           'ﾃﾞﾌｫﾙﾄ月日時

    '@ﾊﾞｯﾁ管理画面、ﾊﾞｯﾁ組予定ﾛｯﾄ一覧情報(列定義)
    Private Const CMlngvsfBatJigIDC             As Integer = 2                          '冶具ID

	'色の指定
	Private Const CMlngBackColorYellow                  As Integer = &HC0FFFF               '黄色

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '====================================Private============================================
    Private mstrJigTypName                          As String                   '退避治具ﾀｲﾌﾟ名
    Private mtypChgSort                             As ChgSort                  'ｿｰﾄ保持用
    Private mblnFormLoadFlag                        As Boolean                  'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private mtypJycJigList                          As pubtypJycJigList         '治具ﾘｽﾄ
    Private mtypJJigList							As pubtypJJigList			'蒸着治具ﾘｽﾄ
	Private mstrJJigCategory						As String					'蒸着治具カテゴリ
    Private mstrScreenSizeId                        As String                   'ｽｸﾘｰﾝｻｲｽﾞ退避用
	Private mstrJigStatus							As String					'治具ステータス
	Private mblnJJigFlag							As String					'蒸着治具フラグ
	Private mstrPdId								As String					'機種ID
    Private buttonProcessing                        As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                  'NSYS WindowCloseフラグ



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
    '機　能：ﾌｫｰﾑ初期設定
    '引　数：なし
    '戻り値：
    '作成日：2009/07/21 (Tue) 13:50:01 T.Oide
    '更新日：2009/08/06 (Thu) 15:49:21 T.Oide
    '備　考：
    Private Sub Form_Load()

        Dim lblnAnsJigList          As Boolean          '治具ﾘｽﾄ取得結果
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim lstrEventName           As String           'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
		Dim lstrJJigCategoryName	As String			'蒸着治具カテゴリ名

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "Form_Load"

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                'Erase .typChgSortList
                .typChgSortList = New List(Of ChgSortList)

                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False

                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With

            '@画面の初期化
            Call prvfrmxxCM0130_Init()

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False

                '@親画面から治具ﾀｲﾌﾟID引渡しありの場合
                If pstrJigTypeID <> vbNullString Then
                    
					'蒸着治具カテゴリ無効
					mblnJJigFlag = False
					cmbJJigCategory.Text = vbNullString
					cmbJJigCategory.Enabled = False
                    
					'@治具ﾀｲﾌﾟをｾｯﾄ
                    If Mid$(pstrJigTypeID, 1, 1) = CMstrJigClassJycId Then
                        '@｢J｣なら蒸着をｾｯﾄ
                        cmbJigClass.Text = CMstrJigClassJycNm
                    Else
                        '@｢H｣なら平置きをｾｯﾄ
                        If Mid$(pstrJigTypeID, 1, 1) = CMstrJigClassHirId Then
                            cmbJigClass.Text = CMstrJigClassHirNm
                        End If
                    End If
                    
                    '@治具ｸﾗｽは平置きか
                    If cmbJigClass.Value = CMstrJigClassHirId Then
                        'パネルカインド「すべて」を設定
                        cmbPanelKind.Text = CMstrCmbItemAll
        '@↓2013/05/23 (Thu) 11:20:42 T.Oide **************************************************
                        cmbPanelKind.Enabled = False                            '変更不可
                        mstrScreenSizeId = pstrScreenSizeID                     '@ｽｸﾘｰﾝｻｲｽﾞID設定
        '@↑2013/05/23 (Thu) 11:20:42 T.Oide **************************************************
                    Else



                        '@ﾊﾟﾈﾙｶｲﾝﾄﾞ設定(一旦TFTに初期化設定しておく→pstrAtlasFlowNumberが空の場合の対応)
                        cmbPanelKind.Text = CMstrPanelKindTFTNm
                        
                        '@TFT(TPAL)機種の場合
                        If Mid$(pstrJigTypeID, 2, 1) = CMstrPanelKindTFTId And _
                           pstrAtlasFlowNumber = CStr(CMlngAtlasFlowNumTPAL) Then
                            '@TFT用を設定
                            cmbPanelKind.Text = CMstrPanelKindTFTNm
                            '@ｽｸﾘｰﾝｻｲｽﾞID未設定
                            mstrScreenSizeId = vbNullString
                            cmbPanelKind.Enabled = True
                            '@コンボの選択肢をTFTとCF(大板)だけにする
                            cmbPanelKind.RemoveItem (CMlngCmbItemDummy) 'ﾀﾞﾐｰ       削除
                            cmbPanelKind.RemoveItem (CMlngCmbItemCF)    'CF(小板)   削除
                            cmbPanelKind.RemoveItem (CMlngCmbItemAll)   '全て       削除
                            
                        End If
                        
                        '@TFT(ODF)機種の場合
                        If Mid$(pstrJigTypeID, 2, 1) = CMstrPanelKindTFTId And _
                            pstrAtlasFlowNumber = CStr(CMlngAtlasFlowNumODF) Then
                            '@CF(大板)を設定
                            cmbPanelKind.Text = CMstrPanelKindODFNm
                            '@ｽｸﾘｰﾝｻｲｽﾞID設定
                            mstrScreenSizeId = pstrScreenSizeID
                            cmbPanelKind.Enabled = True
                            '@コンボの選択肢をTFTとCF(大板)だけにする
                            cmbPanelKind.RemoveItem (CMlngCmbItemDummy) 'ﾀﾞﾐｰ       削除
                            cmbPanelKind.RemoveItem (CMlngCmbItemCF)    'CF(小板)   削除
                            cmbPanelKind.RemoveItem (CMlngCmbItemAll)   '全て       削除

                        End If
                        
                        '@CF(小板)の場合
                        If Mid$(pstrJigTypeID, 2, 1) = CMstrPanelKindCFId Then
                            '@CF(小板)を設定
                            cmbPanelKind.Text = CMstrPanelKindCFNm
                            '@ｽｸﾘｰﾝｻｲｽﾞID設定
                            mstrScreenSizeId = pstrScreenSizeID
                            cmbPanelKind.Enabled = False
                        End If
                        
                        '@CF(大板)の場合
                        If Mid$(pstrJigTypeID, 2, 1) = CMstrPanelKindODF Then
                            '@CF(大板)を設定
                            cmbPanelKind.Text = CMstrPanelKindODFNm
                            '@ｽｸﾘｰﾝｻｲｽﾞID設定
                            mstrScreenSizeId = pstrScreenSizeID
                            cmbPanelKind.Enabled = False
                        End If
                        
                        '@ﾀﾞﾐｰの場合
                        If Mid$(pstrJigTypeID, 2, 1) = CMstrPanelKindDummy Then
                            '@ﾀﾞﾐｰを設定
                            cmbPanelKind.Text = CMstrPanelKindDummyNm
                            '@ｽｸﾘｰﾝｻｲｽﾞID未設定
                            mstrScreenSizeId = vbNullString
                            cmbPanelKind.Enabled = False
                        End If


                    End If
                    
                    '変更不可にする
                    cmbJigClass.Enabled = False

				'蒸着治具関係からの呼び出し
                Else If pstrJJigCategoryId <> vbNullString Then
					'蒸着治具フラグON
					mblnJJigFlag = True
					'治具識別とパネル識別コンボ変更不可
					cmbPanelKind.Text =  vbNullString
					cmbJigClass.Enabled = False
					cmbPanelKind.Enabled = False

					lstrJJigCategoryName = vbNullString

					'呼び出し元に応じて、蒸着治具カテゴリコンボの表示名を変更する
					If pstrJJigCategoryId = CMstrCmbJJigCategoryGuideId Then
						lstrJJigCategoryName　= CMstrCmbJJigCategoryGuideNm
					Else If pstrJJigCategoryId = CMstrCmbJJigCategoryMaskId Then
						lstrJJigCategoryName　= CMstrCmbJJigCategoryMaskNm
					Else If pstrJJigCategoryId = CMstrCmbJJigCategoryHolderId Then
						lstrJJigCategoryName　= CMstrCmbJJigCategoryHolderNm
					Else If pstrJJigCategoryId = CMstrCmbJJigCategoryDummyId Then
						lstrJJigCategoryName　= CMstrCmbJJigCategoryDummyNm
					Else 
						lstrJJigCategoryName　= CMstrCmbJJigCategoryAllNm
					End If

					cmbJJigCategory.Text = lstrJJigCategoryName
					mstrJJigCategory = pstrJJigCategoryId
					cmbJJigCategory.Enabled = False

					'引継ぎ治具ステータス（蒸着マスク組立だと[5:使用可(組前)]）
					mstrJigStatus = pstrJigStatus

					'機種(治具WF紐付け画面)
                    mstrPdId = pstrPDID
				Else
					'治具ﾀｲﾌﾟ(治具識別、パネル識別)の変更可能
					'蒸着治具カテゴリコンボ変更不可
					'蒸着治具フラグOFF
					mblnJJigFlag = False
					cmbJJigCategory.Text = vbNullString
					cmbJJigCategory.Enabled = False
                    cmbJigClass.Enabled = True
                    cmbPanelKind.Enabled = True
                End If
                
				If mblnJJigFlag = True Then
					'蒸着治具カテゴリ列表示
					vsfJigList.Cols(CMlngvsfJigListJJigCategory).Visible = True
					'カテゴリ列非表示
					vsfJigList.Cols(CMlngvsfCategory).Visible = False
					'蒸着治具情報取得
					lblnAnsJigList = prvblnJJigList_Sel()
				Else
					'蒸着治具カテゴリ列非表示
					vsfJigList.Cols(CMlngvsfJigListJJigCategory).Visible = False
					'カテゴリ列表示
					vsfJigList.Cols(CMlngvsfCategory).Visible = True
				    '@空治具取得処理   
					lblnAnsJigList = prvblnJigList_Sel()
				End If


                
                '@結果確認
                If lblnAnsJigList = True Then

                    '@治具が0件ではない(平置、蒸着どちらも)場合
                    If mtypJycJigList.llngJigListCnt <> 0 Or mtypJJigList.llngJJigListCnt <> 0 Then
                        '@Form_Loadﾌﾗｸﾞ（正常）
                        pblnFormLoad = True
                    Else
                        '@0件の場合

                        '@Escﾎﾞﾀﾝを有効
                        Me.CancelButton =Me.cmdClose

                        '@Form_Loadﾌﾗｸﾞ（異常）
                        pblnFormLoad = False

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)

                        '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0004, lblLotCnt.Text)

                        '@publngMsgBoxInfo("<TRM04I>$$該当データがありません。")
                        Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)

					    '@画面引継変数初期化
						pstrJigTypeID = vbNullString            '治具ﾀｲﾌﾟ
						pstrJigStatus = vbNullString            'ｽﾃｰﾀｽ
						pstrScreenSizeID = vbNullString         'ｽｸﾘｰﾝｻｲｽﾞ
						pstrJigCategoryID = vbNullString        'ｶﾃｺﾞﾘ
						pstrJJigCategoryID = vbNullString        '蒸着治具カテゴリ
						pstrPDID = vbNullString					'機種
                        Exit Sub
                        
                    End If

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)

                    Exit Sub
                Else
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = Me.cmdClose

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)

                    Exit Sub
                End If
                

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
    '機　能：
    '引　数：なし
    '戻り値：
    '作成日：2009/07/23 (Thu) 13:33:32 T.Oide
    '更新日：2009/07/23 (Thu) 13:33:32
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理判別
            If mblnFormLoadFlag = False Then
            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose

                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True

                '@取得OKなら結果表示
				'蒸着治具と場合分け
				If mblnJJigFlag = True Then
					Call prvfrmxxCM0130_JJIG_Disp(mtypJJigList)
				Else
					Call prvfrmxxCM0130_Disp(mtypJycJigList)
				End If


                '@ﾘｽﾄが0件以上の場合最新取得ﾎﾞﾀﾝを有効化
                If mtypJycJigList.llngJigListCnt > 0 Or mtypJJigList.llngJJigListCnt > 0 Then
                    cmdJigList.Enabled = True
                End If
                
            End If

            '@治具ﾀｲﾌﾟｺﾝﾎﾞﾎﾞｯｸｽが無効の場合
            If cmbJigClass.Enabled = False Then
                '@ｸﾞﾘｯﾄﾞにｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(vsfJigList)
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
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：なし
    '戻り値：なし
    '作成日：2009/07/23 (Thu) 16:07:49 T.Oide
    '更新日：
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

            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理判別
            Select Case ActiveControl.Name
                '@治具ﾀｲﾌﾟIDの場合
                Case cmbJigClass.Name, cmbPanelKind.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@前と同じ治具ﾀｲﾌﾟ名の場合は次項目へｾｯﾄﾌｫｰｶｽ
                            If mstrJigTypName = cmbJigClass.Value & cmbPanelKind.Value Then
                                '@次項目へｾｯﾄﾌｫｰｶｽ
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                            Else
                                '@最新情報取得
                                Call cmdJigList_Click(cmdJigList, New EventArgs())
                            End If

                        Case Else
                    End Select

                '@一覧の場合
                Case vsfJigList.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            With vsfJigList
                                If .Row >= .Rows.Fixed Then
                                    '@確定処理
                                    Call cmdChoice_Click(cmdChoice, New EventArgs())
                                End If
                            End With
                    End Select

                '@その他の場合
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
    '機　能：ｸｴﾘｰｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：
    '　　　：UnloadMode：
    '戻り値：
    '作成日：2009/07/23 (Thu) 13:43:17 T.Oide
    '更新日：2009/08/06 (Thu) 16:01:04 T.Oide
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

            '@ｿｰﾄ保持用構造体のｸﾘｱ
            If Not IsNothing(mtypChgSort.typChgSortList) Then
                mtypChgSort.typChgSortList.Clear()
                mtypChgSort.typChgSortList = Nothing
            End If

            '@画面引継変数初期化
            pstrJigTypeID = vbNullString            '治具ﾀｲﾌﾟ
            pstrJigStatus = vbNullString            'ｽﾃｰﾀｽ
            pstrScreenSizeID = vbNullString         'ｽｸﾘｰﾝｻｲｽﾞ
            pstrJigCategoryID = vbNullString        'ｶﾃｺﾞﾘ
			pstrJJigCategoryID = vbNullString       '蒸着治具カテゴリ
			pstrPDID = vbNullString					'機種

        '@↓2009/08/06 (Thu) 16:00:59 T.Oide **************************************************
            '@ﾊﾞｯﾁ管理画面から呼ばれた場合Trueとなるﾌﾗｸﾞをクリアしておく
            pblnfrmxxCM0130Kbn = False
        '@↑2009/08/06 (Thu) 16:00:59 T.Oide **************************************************

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
    '機　能：
    '引　数：なし
    '戻り値：
    '作成日：2009/07/23 (Thu) 13:41:45 T.Oide
    '更新日：2009/07/23 (Thu) 13:41:45
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

            '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞ
            Me.Close()

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

    '関数名：cmdChoice_Click
    '機　能：選択確定ﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：
    '作成日：2009/07/23 (Thu) 14:41:07 T.Oide
    '更新日：2009/08/06 (Thu) 16:44:17 T.Oide
    '備　考：
    Private Sub cmdChoice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChoice.Click

    '@↓2009/08/06 (Thu) 16:44:03 T.Oide **************************************************
        Dim lblnChkResult   As Boolean      '治具の重複ﾁｪｯｸ結果格納
        Dim lstrJigID       As String       '治具ID格納
    '@↑2009/08/06 (Thu) 16:44:03 T.Oide **************************************************
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@行が選択されていない場合は格納しない
            If vsfJigList.Row >= 1 Then
            
        '@↓2009/08/06 (Thu) 15:59:01 T.Oide **************************************************
                '@親画面がﾊﾞｯﾁ管理である場合、既に同じﾀﾞﾐｰ治具を選択していないかﾁｪｯｸ
                If pblnfrmxxCM0130Kbn = True Then
                
                    lstrJigID = vsfJigList.GetData(vsfJigList.Row, CMlngvsfJigListJigID)
                    
                    '@親画面に既に今回選択した治具が選択済みでないかﾁｪｯｸ
                    lblnChkResult = prvblnRepeatJig_Chk(lstrJigID)
                    
                    '@結果確認
                    If lblnChkResult = True Then
                    
                        '@"<TRM105W>$$治具[%1]は既に設定されています。$別な治具を選択してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0105, lstrJigID)
                        '@警告ﾒｯｾｰｼﾞ
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Exit Sub
                    End If
                End If
        '@↑2009/08/06 (Thu) 15:59:01 T.Oide **************************************************
                
                '@治具ID格納
                With vsfJigList
                    pstrJigID = .GetData(.Row, CMlngvsfJigListJigID)
                End With

                '@ﾌｫｰﾑを閉じる
                Me.Close()
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdChoice_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdJigList_Click
    '機　能：最新情報表示
    '引　数：なし
    '戻り値：
    '作成日：2009/07/23 (Thu) 13:53:33 T.Oide
    '更新日：2013/05/17 (Fri) 16:13:58 T.Oide
    '備　考：
    Private Sub cmdJigList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdJigList.Click

        Dim lblnAnsJigList          As Boolean          '治具ﾘｽﾄ取得結果
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim lstrEventName           As String           'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名

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

            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                Exit Sub
            End If

            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "cmdJigList_Click"

            '@ﾚｽﾎﾟﾝｽ開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
        '@↓2013/05/17 (Fri) 16:00:06 T.Oide **************************************************
            '@ｽｸﾘｰﾝｻｲｽﾞ設定
            Select Case cmbPanelKind.Text
            
                '@全て,TFT,ﾀﾞﾐｰ の場合
                Case CMstrCmbItemAll, CMstrPanelKindTFTNm, CMstrPanelKindDummyNm
                    mstrScreenSizeId = vbNullString
                
                '@CF(小板),CF(大板) の場合
                Case CMstrPanelKindCFNm, CMstrPanelKindODFNm
                    mstrScreenSizeId = pstrScreenSizeID
                    
                '@その他
                Case Else
                    mstrScreenSizeId = vbNullString
                    
            End Select
        '@↑2013/05/17 (Fri) 16:00:06 T.Oide **************************************************

            
			If mblnJJigFlag = True Then
				'蒸着治具情報取得
				RemoveHandler vsfJigList.BeforeRowColChange, AddressOf vsfJigList_BeforeRowColChange
				lblnAnsJigList = prvblnJJigList_Sel()
				AddHandler vsfJigList.BeforeRowColChange, AddressOf vsfJigList_BeforeRowColChange
			Else
				'@治具ﾘｽﾄ取得
				RemoveHandler vsfJigList.BeforeRowColChange, AddressOf vsfJigList_BeforeRowColChange
				lblnAnsJigList = prvblnJigList_Sel()
				AddHandler vsfJigList.BeforeRowColChange, AddressOf vsfJigList_BeforeRowColChange
			End If

            

            
            '@結果確認
            If lblnAnsJigList = True Then
                '@ﾃﾞｰﾀ表示行が存在するかどうかを判定
                If vsfJigList.Rows.Fixed <> vsfJigList.Rows.Count Then
                    '@ﾃﾞｰﾀ行がある場合
                    Call pubSetFocus(vsfJigList)

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)

                End If

                '@治具ﾀｲﾌﾟ名を取得する
                mstrJigTypName = cmbJigClass.Value & cmbPanelKind.Value

                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdJigList_Click"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbJigClass_Change
    '機　能：取得結果をｸﾘｱする
    '引　数：なし
    '戻り値：
    '作成日：2009/07/23 (Thu) 15:25:58 T.Oide
    '更新日：2009/07/23 (Thu) 15:25:58
    '備　考：
    Private Sub cmbJigClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbJigClass.Change

        Try

            '@起動時には処理を行わない
            If mblnFormLoadFlag = True Then
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                mtypChgSort.strKey = vbNullString

                '@ｸﾞﾘｯﾄﾞの初期化
                Call prvvsfJigList_Init()

                '@最新取得ﾎﾞﾀﾝをﾛｯｸ解除
                cmdJigList.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbJigClass_Change"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbJigClass_CloseUp
    '機　能：治具識別が｢H｣の場合、パネル種別を｢すべて｣設定する
    '引　数：なし
    '戻り値：
    '作成日：2009/07/23 (Thu) 15:34:45 T.Oide
    '更新日：2009/07/23 (Thu) 15:34:45
    '備　考：
    Private Sub cmbJigClass_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbJigClass.CloseUp

        Try
            
            If cmbJigClass.Value = CMstrJigClassHirId Then
            
                '@パネル識別を｢すべて｣にして無効化する
                cmbPanelKind.Text = CMstrCmbItemAll
                cmbPanelKind.Enabled = False
                
                '@最新情報取得
                Call cmdJigList_Click(cmdJigList, New EventArgs())
            
            Else
                'パネル識別有効化
                cmbPanelKind.Enabled = True
                
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbJigClass_CloseUp"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPanelKind_CloseUp
    '機　能：治具一覧取得
    '引　数：なし
    '戻り値：
    '作成日：2009/07/23 (Thu) 15:44:45 T.Oide
    '更新日：2009/07/23 (Thu) 15:44:45
    '備　考：
    Private Sub cmbPanelKind_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPanelKind.CloseUp, cmbJJigCategory.CloseUp
        
        Try
            
            '前回と同じ値の場合は取得しない
            If mstrJigTypName = cmbJigClass.Value & cmbPanelKind.Value Then
               
               Exit Sub
            Else
                '@最新情報取得
                Call cmdJigList_Click(cmdJigList, New EventArgs())
                
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbPanelKind_CloseUp"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfJigList_AfterSort
    '機　能：vsfJigList_AfterSort処理
    '引　数：Col：
    '　　　：Order：
    '戻り値：
    '作成日：2009/07/23 (Thu) 15:59:42 T.Oide
    '更新日：2009/07/23 (Thu) 15:59:42
    '備　考：
    Private Sub vsfJigList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfJigList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfJigList.Rows.Count <= vsfJigList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ後処理
            Call pubVsfAfterSort(vsfJigList, _
                                 CMlngvsfJigListNo & _
                                 vbTab & _
                                 CMlngvsfJigListCreanTime & _
                                 vbTab & _
                                 CMlngvsfJigListJigID & _
								 vbTab & _
								 CMlngvsfJigListJJigCategory & _
                                 vbTab & _
                                 CMlngvsfUseNum)

            '@ｿｰﾄ順を格納
            With mtypChgSort
                Dim ltypChgSortListTmp As ChgSortList
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                
                '@ｿｰﾄ列番号を格納
                ltypChgSortListTmp.lngCol = e.Col
                
                '@並び替え方法を格納（昇順/降順）
                ltypChgSortListTmp.lngOrder = e.Order

                .typChgSortList.Add(ltypChgSortListTmp)
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfJigList_AfterSort"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfJigList_BeforeRowColChange
    '機　能：変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2009/07/23 (Thu) 16:02:50 T.Oide
    '更新日：
    '備　考：
    Private Sub vsfJigList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfJigList.BeforeRowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfJigList.Rows.Count <= vsfJigList.Rows.Fixed Then
                Return
            End If

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(治具ID)
                mtypChgSort.strKey = vsfJigList.GetData(e.NewRange.r1, _
                                                         CMlngvsfJigListJigID)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                         '機能ID
                .strProcName = "vsfJigList_BeforeRowColChange"          '処理名
                .strErrMessage = vbNullString                           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfJigList_BeforeSort
    '機　能：vsfJigList_BeforeSort処理
    '引　数：Col：未使用
    '　　　：Order：未使用
    '戻り値：なし
    '作成日：2009/07/23 (Thu) 16:03:36 T.Oide
    '更新日：
    '備　考：
    Private Sub vsfJigList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfJigList.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfJigList.Rows.Count <= vsfJigList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ前処理
            Call pubVsfBeforeSort(vsfJigList, _
                                  CMlngvsfJigListNo & _
                                  vbTab & _
                                  CMlngvsfJigListCreanTime & _
                                  vbTab & _
                                  CMlngvsfJigListJigID & _
                                  vbTab & _
								  CMlngvsfJigListJJigCategory & _
                                  vbTab & _
                                  CMlngvsfUseNum)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfJigList_BeforeSort"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfJigList_DblClick
    '機　能：治具一覧ﾀﾞﾌﾞﾙｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/07/23 (Thu) 16:04:21 T.Oide
    '更新日：
    '備　考：
    Private Sub vsfJigList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfJigList.DoubleClick

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfJigList.Rows.Count <= vsfJigList.Rows.Fixed Then
                Return
            End If

            '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸの場合
            If vsfJigList.MouseRow = 0 Then
                Exit Sub
            End If

            '@選択確定
            Call cmdChoice_Click(cmdChoice, New EventArgs())

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfJigList_DblClick"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfJigList_RowColChange
    '機　能：治具選択処理
    '引　数：なし
    '戻り値：
    '作成日：2009/07/23 (Thu) 14:38:53 T.Oide
    '更新日：2009/07/23 (Thu) 14:38:53
    '備　考：
    Private Sub vsfJigList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfJigList.RowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfJigList.Rows.Count <= vsfJigList.Rows.Fixed Then
                Return
            End If

            'NSYS クリック行がヘッダ行の場合は処理を抜ける
            If vsfJigList.MouseRow < vsfJigList.Rows.Fixed Then
                Return
            End If

            '@ﾀｲﾄﾙ以外を選択した場合
            With vsfJigList
                If .Row > 0 Then
                    '@選択行の治具IDが空欄ではない場合
                    If .GetData(.Row, CMlngvsfJigListJigID) <> vbNullString Then
                        '@確定ﾎﾞﾀﾝ有効化
                        cmdChoice.Enabled = True
                    Else
                        '@確定ﾎﾞﾀﾝ無効化
                        cmdChoice.Enabled = False
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "vsfJigList_RowColChange"        '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvfrmxxCM0130_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 13:55:55 Y.Yamagishi
    '更新日：2004/09/23 (Thu) 13:55:55
    '備　考：
    Private Sub prvfrmxxCM0130_Init()

        Try

            '@最新取得ﾎﾞﾀﾝをﾛｯｸ
            cmdJigList.Enabled = False

            '@情報取得日時初期化
            lblNowDate.Text = vbNullString

            '@件数ｸﾘｱ
            lblLotCnt.Text = vbNullString

            '@閉じるﾎﾞﾀﾝはValidate無効
            cmdClose.CausesValidation = False

            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfJigList_Init()

            '@ｺﾝﾎﾞ初期化
            Call prvCmbBox_Set()

            '@選択確定ﾎﾞﾀﾝ使用不可
            cmdChoice.Enabled = False

            '@変数初期化
            pstrJigID = vbNullString
            mstrJigTypName = vbNullString

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxCM0130_Init"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbBox_Set
    '機　能：治具識別とパネル識別のｺﾝﾎﾞﾎﾞｯｸｽのﾘｽﾄを設定
    '引　数：なし
    '戻り値：
    '作成日：2009/07/23 (Thu) 11:24:45 T.Oide
    '更新日：2013/05/16 (Thu) 13:29:17 T.Oide
    '備　考：
    Private Sub prvCmbBox_Set()

        Try
            
            '@治具識別のｺﾝﾎﾞ設定
            With cmbJigClass
                .Clear()
                .BackColor = SystemColors.Window
                .DispCols = CMlngCmbDispCols
                .GetCol = CMlngCmbGridColName
                .ValueCol = CMlngCmbGridColID
                '@全て(Valueはなし)
                .AddItem(CMstrCmbItemAll _
                        & vbTab _
                        & vbNullString)
                '@蒸着(Valueは｢J｣)
                .AddItem(CMstrJigClassJycNm _
                        & vbTab _
                        & CMstrJigClassJycId)
                '@平置き(Valueは｢H｣)
                .AddItem(CMstrJigClassHirNm _
                        & vbTab _
                        & CMstrJigClassHirId)
                .ListIndex = CMlngCmbListIndex
            End With
            
            '@パネル識別のｺﾝﾎﾞ設定
            With cmbPanelKind
                .Clear()
                .BackColor = SystemColors.Window
                .DispCols = CMlngCmbDispCols
                .GetCol = CMlngCmbGridColName
                .ValueCol = CMlngCmbGridColID
                .ListIndex = CMlngCmbListIndex
                '@全て(Valueはなし)
                .AddItem(CMstrCmbItemAll _
                        & vbTab _
                        & vbNullString)
                '@TFT(Valueは｢T｣)
                .AddItem(CMstrPanelKindTFTNm _
                        & vbTab _
                        & CMstrPanelKindTFTId)
                '@CF小板(Valueは｢C｣)
                .AddItem(CMstrPanelKindCFNm _
                        & vbTab _
                        & CMstrPanelKindCFId)
        '@↓2013/05/16 (Thu) 13:29:47 T.Oide **************************************************
                '@CF大板(Valueは｢O｣)
                .AddItem(CMstrPanelKindODFNm _
                        & vbTab _
                        & CMstrPanelKindODF)
        '@↑2013/05/16 (Thu) 13:29:47 T.Oide **************************************************
                '@ﾀﾞﾐｰ(Valueは｢D｣)
                .AddItem(CMstrPanelKindDummyNm _
                        & vbTab _
                        & CMstrPanelKindDummy)

                .ListIndex = CMlngCmbListIndex
            End With
            
			'@蒸着治具カテゴリコンボ設定
            With cmbJJigCategory
                .Clear
                .BackColor = SystemColors.Window
                .DirectInput = False
                .DispCols = CMlngCmbDispCols
                .GetCol = CMlngCmbGridColName
                .ValueCol = CMlngCmbGridColID
                
                '@選択ﾘｽﾄ設定
				.AddItem(CMstrCmbJJigCategoryAllNm & vbTab & "")				'全て
                .AddItem(CMstrCmbJJigCategoryGuideNm & vbTab & CMstrCmbJJigCategoryGuideId)         'ガイドリング
                .AddItem(CMstrCmbJJigCategoryMaskNm & vbTab & CMstrCmbJJigCategoryMaskId)			'マスク
                .AddItem(CMstrCmbJJigCategoryHolderNm & vbTab & CMstrCmbJJigCategoryHolderId)		'ホルダ
                .AddItem(CMstrCmbJJigCategoryDummyNm & vbTab & CMstrCmbJJigCategoryDummyId)			'ダミープレート
                
                '@ﾌｫﾝﾄｻｲｽﾞ設定、初期値設定
                .GridFont = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)
                .ListIndex = CMlngCmbListIndex

            End With

            
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "CprvCmbBox_Set()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：prvvsfJigList_Init
    '機　能：ｸﾞﾘｯﾄﾞ初期化
    '引　数：なし
    '戻り値：
    '作成日：2009/07/28 (Tue) 11:30:49 T.Oide
    '更新日：2009/07/28 (Tue) 11:30:49
    '備　考：
    Private Sub prvvsfJigList_Init()
        Dim lNormalStyle    As CellStyle
        Dim lFixedStyle     As CellStyle

        Try

            With vsfJigList
                '@治具ﾘｽﾄｸﾘｱ
                vsfJigList.Clear()
                vsfJigList.Rows.Count = 1

                '@行の高さ指定
                .Rows.DefaultSize = CMlngvsfJigListRowHeight
                .Rows(0).Height = CMlngvsfJigListTitleRowHeight

                lNormalStyle = .Styles.Normal
                lFixedStyle = .Styles.Fixed
                '@ﾌｫﾝﾄの設定
                lNormalStyle.Font = New Font(.Font.FontFamily, CMlngvsfJigListFontSize, .Font.Style, _
                                        .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .Select(0, CMlngvsfJigListNo, .Rows.Fixed - 1, CMlngvsfUseNum)
                lFixedStyle.Font = New Font(.Font.FontFamily, CMlngvsfJigListTitleFontSize, .Font.Style, _
                                        .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)

                '@見出し行の色設定
                lFixedStyle.BackColor = Color.Navy
                lFixedStyle.ForeColor = Color.Yellow

                '@列幅の設定
                .Cols(CMlngvsfJigListNo).Width = CMlngvsfWJigListNo
                .Cols(CMlngvsfJigListCreanTime).Width = CMlngvsfWJigListCreanTime
                .Cols(CMlngvsfJigListJigID).Width = CMlngvsfWJigListJigID
				.Cols(CMlngvsfJigListJJigCategory).Width = CMlngvsfWJigListJJigCategory
                .Cols(CMlngvsfUseNum).Width = CMlngvsfWUseNum
                .Cols(CMlngvsfCategory).Width = CMlngvsfWCategory

                'NSYS 再描画停止
                .Redraw = False

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfJigListTitleRow, CMlngvsfJigListNo, CMstrvsfJigListNo)
                .SetData(CMlngvsfJigListTitleRow, CMlngvsfJigListCreanTime, CMstrvsfJigListCreanTime)
                .SetData(CMlngvsfJigListTitleRow, CMlngvsfJigListJigID, CMstrvsfJigListJig)
				.SetData(CMlngvsfJigListTitleRow, CMlngvsfJigListJJigCategory, CMstrvsfJigListJJigCategory)
                .SetData(CMlngvsfJigListTitleRow, CMlngvsfUseNum, CMstrvsfJigListUseNum)
                .SetData(CMlngvsfJigListTitleRow, CMlngvsfCategory, CMstrvsfJigListCategory)

                'NSYS 数値列設定
                .Cols(CMlngvsfJigListNo).DataType = GetType(System.Int32)
                .Cols(CMlngvsfUseNum).DataType = GetType(System.Int32)

                '@見出し行の文字位置設定
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter

                '@ﾍｯﾀﾞのｿｰﾄ指定
                .AllowSorting = AllowSortingEnum.SingleColumn

                'NSYS 再描画再開
                .Redraw = True

            End With


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfJigList_Init"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：prvfrmxxCM0130_Disp
    '機　能：治具ﾘｽﾄの取得結果を画面に表示する
    '引　数：ltypJycJigList：
    '戻り値：
    '作成日：2009/07/23 (Thu) 13:15:29 T.Oide
    '更新日：2009/07/23 (Thu) 13:15:29
    '備　考：
    Private Sub prvfrmxxCM0130_Disp(ByRef ltypJycJigList As pubtypJycJigList)

        Dim llngCnt                 As Integer      '治具のｶｳﾝﾄ数
        Dim llngJigListCnt          As Integer      '治具ﾘｽﾄのｶｳﾝﾄ数

        Try

            With vsfJigList
                '@描画ﾛｯｸ
                .Redraw = False

                '@ﾃﾞｰﾀ表示
                llngCnt = 0
                llngJigListCnt = 1

                '@行数設定
                vsfJigList.Rows.Count = ltypJycJigList.llngJigListCnt + 1

                '@ﾃﾞｰﾀｾｯﾄ(ﾃﾞｰﾀがある場合)
                If vsfJigList.Rows.Count > 1 Then
                    '@構造体のﾘｽﾄを順に表示する
                    Do While ltypJycJigList.llngJigListCnt-1 >= llngCnt
                        With ltypJycJigList.pubJycJigList(llngCnt)
                        
                            vsfJigList.SetData(llngJigListCnt, CMlngvsfJigListNo, _
                               llngJigListCnt)                                                '№

                            If .strCleanTime = CMstrDefYmdHms Then                              '最終洗浄日時
                                vsfJigList.SetData(llngJigListCnt, CMlngvsfJigListCreanTime, _
                                    CMstrDefY2mdHms)
                            Else
                                If IsDate(.strCleanTime) Then
                                    vsfJigList.SetData(llngJigListCnt, CMlngvsfJigListCreanTime, _
                                        Format$(CDate(.strCleanTime), CPstrDateTimeY2MDHMS))
                                Else
                                    vsfJigList.SetData(llngJigListCnt, CMlngvsfJigListCreanTime, _
                                        .strCleanTime)
                                End If
                            End If

                            vsfJigList.SetData(llngJigListCnt, CMlngvsfJigListJigID, _
                                .strjigId)                                                     '治具ID
        '@↓2015/07/23 (Thu) 09:43:34 T.Inafune **************************************************
        '                    vsfJigList.Cell(flexcpText, llngJigListCnt, CMlngvsfUseNum) _
        '                        = .struseNum                                                    '使用回数
                            '洗浄後使用回数
                            If IsNumeric(.strWashUseNum) Then
                                vsfJigList.SetData(llngJigListCnt, CMlngvsfUseNum, CLng(.strWashUseNum))
                            Else
                                vsfJigList.SetData(llngJigListCnt, CMlngvsfUseNum, .strWashUseNum)
                            End If
        '@↑2015/07/23 (Thu) 09:43:34 T.Inafune **************************************************

                            vsfJigList.SetData(llngJigListCnt, CMlngvsfCategory, _
                                .strcarrierCategoryNm)                                        'カテゴリ

                            '@行の高さ設定
                            vsfJigList.Rows(llngJigListCnt).Height = CMlngvsfJigListRowHeight

                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngJigListCnt = llngJigListCnt + 1
                            llngCnt = llngCnt + 1
                        End With
                    Loop

                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt - 1
                            '@該当行をｿｰﾄ
                            .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If

                    '@ｿｰﾄ検索用ｷｰ(治具ID)がある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@治具IDが同じ場合
                            If .GetData(llngCnt, CMlngvsfJigListJigID) = mtypChgSort.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ,保持列)
                                Call pubVsfBeforeSort(vsfJigList, CMlngvsfJigListNo)

                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ,保持列,前頁,次頁)
                                Call pubVsfAfterSort(vsfJigList, CMlngvsfJigListNo)

                                Exit For
                            End If
                        Next llngCnt
                    Else

                        '@ﾀｲﾄﾙ行を選択する
                        .Row = CMlngvsfJigListTitleRow
                    End If
                End If
                '@描画ﾛｯｸ解除
                .Redraw = True

                '@情報取得日時表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)

                '@件数表示
                lblLotCnt.Text = llngJigListCnt - 1

                '@ﾃﾞｰﾀ表示行が存在するかどうかを判定
                If .Rows.Fixed <> .Rows.Count Then
                    '@一覧使用可能
                    .Enabled = True
                Else
                    '@選択確定ﾎﾞﾀﾝ使用不可
                    cmdChoice.Enabled = False
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxCM0130_Disp"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：prvfrmxxCM0130_JJIG_Disp
    '機　能：蒸着治具ﾘｽﾄの取得結果を画面に表示する
    '引　数：ltypJJigList：
    '戻り値：
    '作成日：
    '更新日：
    '備　考：
    Private Sub prvfrmxxCM0130_JJIG_Disp(ByRef ltypJJigList As pubtypJJigList)

        Dim llngCnt                 As Integer      '治具のｶｳﾝﾄ数
        Dim llngJigListCnt          As Integer      '治具ﾘｽﾄのｶｳﾝﾄ数

        Try

            With vsfJigList
                '@描画ﾛｯｸ
                .Redraw = False

                '@ﾃﾞｰﾀ表示
                llngCnt = 0
                llngJigListCnt = 1

                '@行数設定
                vsfJigList.Rows.Count = ltypJJigList.llngJJigListCnt + 1

                '@ﾃﾞｰﾀｾｯﾄ(ﾃﾞｰﾀがある場合)
                If vsfJigList.Rows.Count > 1 Then
                    '@構造体のﾘｽﾄを順に表示する
                    Do While ltypJJigList.llngJJigListCnt-1 >= llngCnt
                        With ltypJJigList.pubJJigList(llngCnt)
                        
                            vsfJigList.SetData(llngJigListCnt, CMlngvsfJigListNo, _
                               llngJigListCnt)                                                '№

                            If .strCleanTime = CMstrDefYmdHms Then                              '最終洗浄日時
                                vsfJigList.SetData(llngJigListCnt, CMlngvsfJigListCreanTime, _
                                    CMstrDefY2mdHms)
                            Else
                                If IsDate(.strCleanTime) Then
                                    vsfJigList.SetData(llngJigListCnt, CMlngvsfJigListCreanTime, _
                                        Format$(CDate(.strCleanTime), CPstrDateTimeY2MDHMS))
                                Else
                                    vsfJigList.SetData(llngJigListCnt, CMlngvsfJigListCreanTime, _
                                        .strCleanTime)
                                End If
                            End If

                            vsfJigList.SetData(llngJigListCnt, CMlngvsfJigListJigID, _
                                .strJJigId)                                                     '治具ID


							'蒸着治具カテゴリ名変換
							if .strJJigCategoryId = CMstrCmbJJigCategoryGuideId Then
								'G→ガイドリング　
								vsfJigList.SetData(llngJigListCnt, CMlngvsfJigListJJigCategory, CMstrCmbJJigCategoryGuideNm) 
							Else If ltypJJigList.pubJJigList(llngCnt).strJJigCategoryId = CMstrCmbJJigCategoryMaskId Then
								'M→マスク　
								vsfJigList.SetData(llngJigListCnt, CMlngvsfJigListJJigCategory, CMstrCmbJJigCategoryMaskNm) 
							Else If ltypJJigList.pubJJigList(llngCnt).strJJigCategoryId = CMstrCmbJJigCategoryHolderId Then
								vsfJigList.SetData(llngJigListCnt, CMlngvsfJigListJJigCategory, CMstrCmbJJigCategoryHolderNm) 
							Else If ltypJJigList.pubJJigList(llngCnt).strJJigCategoryId = CMstrCmbJJigCategoryDummyId Then
								vsfJigList.SetData(llngJigListCnt, CMlngvsfJigListJJigCategory, CMstrCmbJJigCategoryDummyNm) 
							End If
            

                            '洗浄後使用回数
                            If IsNumeric(.strWashUseNum) Then
                                vsfJigList.SetData(llngJigListCnt, CMlngvsfUseNum, CLng(.strWashUseNum))
                            Else
                                vsfJigList.SetData(llngJigListCnt, CMlngvsfUseNum, .strWashUseNum)
                            End If

						'在庫準備フラグOFF　かつ　使用回数+10 >= 上限回数だった場合は,「使用回数」列の背景色を黄色にする
						if CLng(ltypJJigList.pubJJigList(llngCnt).strWashUseNum)+10 >= CLng(ltypJJigList.pubJJigList(llngCnt).strWashUseLimit) And _
								ltypJJigList.pubJJigList(llngCnt).strNextStockReadyFlag <> CPstrFlagOn Then
							Dim newStyle As CellStyle = vsfJigList.Styles.Add("CustomStyle_BackColor_CMlngBackColorYellow")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorYellow)
                            Dim cellRange As CellRange = vsfJigList.GetCellRange(llngJigListCnt, CMlngvsfUseNum)
                            cellRange.Style = newStyle
						End If

                            '@行の高さ設定
                            vsfJigList.Rows(llngJigListCnt).Height = CMlngvsfJigListRowHeight

                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngJigListCnt = llngJigListCnt + 1
                            llngCnt = llngCnt + 1
                        End With
                    Loop

                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt - 1
                            '@該当行をｿｰﾄ
                            .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If

                    '@ｿｰﾄ検索用ｷｰ(治具ID)がある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@治具IDが同じ場合
                            If .GetData(llngCnt, CMlngvsfJigListJigID) = mtypChgSort.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ,保持列)
                                Call pubVsfBeforeSort(vsfJigList, CMlngvsfJigListNo)

                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ,保持列,前頁,次頁)
                                Call pubVsfAfterSort(vsfJigList, CMlngvsfJigListNo)

                                Exit For
                            End If
                        Next llngCnt
                    Else

                        '@ﾀｲﾄﾙ行を選択する
                        .Row = CMlngvsfJigListTitleRow
                    End If
                End If
                '@描画ﾛｯｸ解除
                .Redraw = True

                '@情報取得日時表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)

                '@件数表示
                lblLotCnt.Text = llngJigListCnt - 1

                '@ﾃﾞｰﾀ表示行が存在するかどうかを判定
                If .Rows.Fixed <> .Rows.Count Then
                    '@一覧使用可能
                    .Enabled = True
                Else
                    '@選択確定ﾎﾞﾀﾝ使用不可
                    cmdChoice.Enabled = False
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxCM0130_Disp"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：prvblnJigList_Sel
    '機　能：
    '引　数：なし
    '戻り値：
    '作成日：2009/07/23 (Thu) 10:57:56 T.Oide
    '更新日：2009/07/23 (Thu) 10:57:56
    '備　考：
    Private Function prvblnJigList_Sel() As Boolean

        Dim lblnAns             As Boolean          '結果格納
        
        
        Try

            '@初期化
            prvblnJigList_Sel = False


            '@治具一覧取得
            lblnAns = pubblnJycJigList_Sel(CMstrjig_jyclist__Ver, _
                                           cmbJigClass.Value, _
                                           cmbPanelKind.Value, _
                                           mtypJycJigList, _
                                           pstrJigStatus, _
                                           mstrScreenSizeId, _
                                           pstrJigCategoryID)
            
            '@結果判定
            If lblnAns = True Then
            '@成功の場合

                '@描画処理
                If mblnFormLoadFlag = True Then
                '@初回起動時以外は描画を行う
                    '@取得OKなら結果表示
                    Call prvfrmxxCM0130_Disp(mtypJycJigList)
                End If

                prvblnJigList_Sel = True
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnJigList_Sel"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

	'関数名：prvblnJJigList_Sel
    '機　能：
    '引　数：なし
    '戻り値：
    '作成日：
    '更新日：
    '備　考：
    Private Function prvblnJJigList_Sel() As Boolean

        Dim lblnAns             As Boolean          '結果格納
        
        
        Try

            '@初期化
            prvblnJJigList_Sel = False


            '@治具一覧取得
            lblnAns = pubblnJJigList_Sel(CMstrjig_jjiglistVer, _
                                           mstrJigStatus, _
                                           mstrJJigCategory, _
										   mstrPdId, _
                                           mtypJJigList)
            
            '@結果判定
            If lblnAns = True Then
            '@成功の場合

                '@描画処理
                If mblnFormLoadFlag = True Then
                '@初回起動時以外は描画を行う
                    '@取得OKなら結果表示
                    Call prvfrmxxCM0130_JJIG_Disp(mtypJJigList)
                End If

                prvblnJJigList_Sel = True
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnJJigList_Sel"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '@↓2009/08/06 (Thu) 16:57:38 T.Oide **************************************************
    '関数名：prvblnRepeatJig_Chk
    '機　能：ﾀﾞﾐｰ治具重複ﾁｪｯｸ処理
    '引　数：lstrJigID  ：治具ID
    '戻り値：True：重複あり、False：重複なし
    '作成日：2009/08/06 (Thu) 16:57:02 T.Oide
    '更新日：2009/08/17 (Mon) 12:57:10 N.Kojima
    '備　考：
    '　　　：2009/08/17 (Mon) 12:57:10 N.Kojima     無機対応Phase3、ﾁｪｯｸ処理不具合の修正＆ｿｰｽ整備。(案件№03704)
    Private Function prvblnRepeatJig_Chk(ByVal lstrJigID As String) As Boolean
       
        Dim llngCnt     As Integer  'ｶｳﾝﾀ
        
        Try
            
            '@戻り値の初期化
            prvblnRepeatJig_Chk = False
            
            '@ﾊﾞｯﾁ管理画面のﾊﾞｯﾁ組予定ﾛｯﾄｸﾞﾘｯﾄﾞの行分ﾁｪｯｸを繰り返す
            With frmxxEN00M0.Instance.vsfBat
                
                '@ｶｳﾝﾀの初期化
                llngCnt = 1
                
                Do While .Rows.Count - 1 > llngCnt - 1
            
                    '@同じﾀﾞﾐｰ治具IDか
                    If .GetData(llngCnt, CMlngvsfBatJigIDC) = lstrJigID Then
                        '@重複ありの場合
                        
                        '@戻り値に"True：重複あり"をｾｯﾄ
                        prvblnRepeatJig_Chk = True
                        Exit Do
                    End If
                    
                    '@ﾙｰﾌﾟｶｳﾝﾀを+1する
                    llngCnt = llngCnt + 1
                Loop

            End With
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnRepeatJig_Chk"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function
    '@↑2009/08/06 (Thu) 16:57:38 T.Oide **************************************************


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
