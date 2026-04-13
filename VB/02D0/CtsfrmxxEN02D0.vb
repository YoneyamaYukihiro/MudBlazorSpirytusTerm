'ﾌｧｲﾙ名：xxEN02D0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：蒸着治具管理　メインフォーム
'作成日：2009/05/26 (Tue) 13:26:21 K.Nishizawa
'更新日：2017/02/16 (Thu) 09:08:24 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2017, all rights reserved.
Option Explicit On
Imports C1.Win.C1Document
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02D0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02D0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02D0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02D0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02D0)
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
    '======================================Private==========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2017/02/16 (Thu) 09:08:24 T.Oide **************************************************
    'Private Const CMstrLocalVersion                     As String = "03.00"
    Private Const CMstrLocalVersion                     As String = "04.00"
    '@↑2017/02/16 (Thu) 09:08:24 T.Oide **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_carriercategorylistVer       As String = "01.00"         'ｷｬﾘｱｶﾃｺﾞﾘﾘｽﾄ取得MsgVer
    Private Const CMstrjig_jyclist__Ver                 As String = "02.02"         '無機治具情報一覧取得MsgVer
    Private Const CMstrjig_jjiglistVer					As String = "01.00"         '蒸着治具情報一覧取得
	Private Const CMstrjig_chgjyc___Ver                 As String = "01.02"         '無機治具情報変更MsgVer
	Private Const CMstrjig_chgjjigVer					As String = "01.00"         '蒸着治具情報変更MsgVer
    Private Const CMstrmas_screenlistVer                As String = "02.00"         '画面ｻｲｽﾞﾏｽﾀ取得MsgVer

    '平置き治具一覧の列数
    Private Const CMlngvsfJycJigListColCnt              As Integer = 20
	Private Const CMlngvsfJJigListColCnt				As Integer = 22

    '@vsfLotListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfJycJigListNoCol               As Integer = 0                 '№
    Private Const CMlngvsfJycJigListWashCol             As Integer = 1                 '洗浄
    Private Const CMlngvsfJycJigListJigIdCol            As Integer = 2                 '治具ID
    Private Const CMlngvsfJycJigListJigStatusCol        As Integer = 3                 'ステータス(ID)
    Private Const CMlngvsfJycJigListJigStatusNmCol      As Integer = 4                 'ステータス
    Private Const CMlngvsfJycJigListJigClassIdCol       As Integer = 5                 '治具識別
    Private Const CMlngvsfJycJigListCarrieCategoryCol   As Integer = 6                 '治具カテゴリ(ID)
    Private Const CMlngvsfJycJigListCarrieCategoryNCol  As Integer = 7                 '治具カテゴリ
    Private Const CMlngvsfJycJigListpanelKindCol        As Integer = 8                 'パネル識別
    Private Const CMlngvsfJycJigListScreenSizeIdCol     As Integer = 9                 'スクリーンサイズ
    Private Const CMlngvsfJycJigListWashUseNumCol       As Integer = 10                '洗浄後使用回数
    Private Const CMlngvsfJycJigListWashUseLimitCol     As Integer = 11                '洗浄後上限回数
    Private Const CMlngvsfJycJigListStartTimeCol        As Integer = 12                '使用開始日時
    Private Const CMlngvsfJycJigListCleanTimeCol        As Integer = 13                '最終洗浄日時
    Private Const CMlngvsfJycJigListUseNumCol           As Integer = 14                '累積使用回数
    Private Const CMlngvsfJycJigListUseLimitCol         As Integer = 15                '累積上限回数
    Private Const CMlngvsfJycJigListEmpIdCol            As Integer = 16                '最終更新者(ID)
    Private Const CMlngvsfJycJigListEmpNameCol          As Integer = 17                '最終使用者
    Private Const CMlngvsfJycJigListCommentsCol         As Integer = 18                'コメント
    Private Const CMlngvsfJycJigListUpdateFlag          As Integer = 19                '変更フラグ

    '@vsfJycJigListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfJycJigListColNo               As String = "№"
    Private Const CMstrvsfJycJigListColWash             As String = "洗浄"
    Private Const CMstrvsfJycJigListColJigId            As String = "治具ID"
    Private Const CMstrvsfJycJigListColJigStatus        As String = "ステータス(ID)"
    Private Const CMstrvsfJycJigListColJigStatusNm      As String = "ステータス"
    Private Const CMstrvsfJycJigListColJigClassId       As String = "治具識別"
    Private Const CMstrvsfJycJigListColJigCategory      As String = "治具カテゴリ(ID)"
    Private Const CMstrvsfJycJigListColJigCategoryN     As String = "治具カテゴリ"
    Private Const CMstrvsfJycJigListColpanelKind        As String = "パネル識別"
    Private Const CMstrvsfJycJigListColScreenSizeId     As String = "スクリーンサイズ"
    Private Const CMstrvsfJycJigListColWashUseNum       As String = "洗浄後使用回数"
    Private Const CMstrvsfJycJigListColWashUseLimit     As String = "洗浄後上限回数"
    Private Const CMstrvsfJycJigListColStartTime        As String = "使用開始日時"
    Private Const CMstrvsfJycJigListColCleanTime        As String = "最終洗浄日時"
    Private Const CMstrvsfJycJigListColUseNum           As String = "累積使用回数"
    Private Const CMstrvsfJycJigListColUseLimit         As String = "累積上限回数"
    Private Const CMstrvsfJycJigListColEmpId            As String = "最終更新者(ID)"
    Private Const CMstrvsfJycJigListColEmpName          As String = "最終更新者"
    Private Const CMstrvsfJycJigListColComments         As String = "コメント"
    Private Const CMstrvsfJycJigListColUpdateFlag       As String = "変更フラグ"

    '@vsfJycJigListの定数宣言(列幅)
    Private Const CMlngvsfJycJigListNoWidth             As Integer = 35               '№
    Private Const CMlngvsfJycJigListWashWidth           As Integer = 42               '洗浄
    Private Const CMlngvsfJycJigListJigIdWidth          As Integer = 100              '治具ID
    Private Const CMlngvsfJycJigListJigStatusWidth      As Integer = 120              'ステータス(ID)
    Private Const CMlngvsfJycJigListJigStatusNmWidth    As Integer = 95               'ステータス
    Private Const CMlngvsfJycJigListJigClassWidth       As Integer = 76               '治具識別
    Private Const CMlngvsfJycJigListJigCategoryWidth    As Integer = 138              '治具カテゴリ(ID)
    Private Const CMlngvsfJycJigListJigCategoryNWidth   As Integer = 120              '治具カテゴリ
    Private Const CMlngvsfJycJigListpanelKindWidth      As Integer = 95               'パネル識別
    Private Const CMlngvsfJycJigListScreenSizeWidth     As Integer = 140              'スクリーンサイズ
    Private Const CMlngvsfJycJigListWashUseNumWidth     As Integer = 120              '洗浄後使用回数
    Private Const CMlngvsfJycJigListWashUseLimitWidth   As Integer = 120              '洗浄後上限回数
    Private Const CMlngvsfJycJigListStartTimeWidth      As Integer = 125              '使用開始日時
    Private Const CMlngvsfJycJigListCleanTimeWidth      As Integer = 125              '最終洗浄日時
    Private Const CMlngvsfJycJigListUseNumWidth         As Integer = 120              '累積使用回数
    Private Const CMlngvsfJycJigListUseLimitWidth       As Integer = 120              '累積上限回数
    Private Const CMlngvsfJycJigListEmpIDWidth          As Integer = 125              '最終更新者(ID)
    Private Const CMlngvsfJycJigListEmpNameWidth        As Integer = 120              '最終使用者
    Private Const CMlngvsfJycJigListCommentsWidth       As Integer = 120              'コメント
    Private Const CMlngvsfJycJigListUpdateFlagWidth     As Integer = 120              '変更フラグ


	'@vsfJJigListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfJJigListNoCol						As Integer = 0					'№
    Private Const CMlngvsfJJigListSelectCol					As Integer = 1					'選択
    Private Const CMlngvsfJJigListJigIdCol					As Integer = 2					'治具ID
    Private Const CMlngvsfJJigListJJigStatusIdCol			As Integer = 3					'ステータス(ID)
    Private Const CMlngvsfJJigListJJigStatusNmCol			As Integer = 4					'ステータス
    Private Const CMlngvsfJJigListPdIdCol					As Integer = 5					'機種
    Private Const CMlngvsfJJigListJJigCategoryIdCol			As Integer = 6					'治具カテゴリ(ID)
    Private Const CMlngvsfJJigListJJigCategoryNmCol			As Integer = 7					'治具カテゴリ
    Private Const CMlngvsfJJigListSetGuideMaskCol			As Integer = 8					'組立相手
    Private Const CMlngvsfJJigListSetEmpIdCol				As Integer = 9					'蒸着マスク組立作業者(ID)
	Private Const CMlngvsfJJigListSetEmpNameCol				As Integer = 10					'蒸着マスク組立作業者
    Private Const CMlngvsfJJigListWashUseNumCol				As Integer = 11					'洗浄後使用回数
	Private Const CMlngvsfJJigListWashUseLimitCol			As Integer = 12					'洗浄後上限回数
    Private Const CMlngvsfJJigListNextStockReadyFlagCol		As Integer = 13					'次回在庫準備
	Private Const CMlngvsfJJigListStartTimeCol				As Integer = 14					'使用開始日時
    Private Const CMlngvsfJJigListCleanTimeCol				As Integer = 15					'最終洗浄日時
    Private Const CMlngvsfJJigListUseNumCol					As Integer = 16					'累積使用回数
    Private Const CMlngvsfJJigListUseLimitCol				As Integer = 17					'累積上限回数
    Private Const CMlngvsfJJigListEmpIdCol					As Integer = 18					'最終更新者(ID)
    Private Const CMlngvsfJJigListEmpNameCol				As Integer = 19					'最終使用者
    Private Const CMlngvsfJJigListCommentsCol				As Integer = 20					'コメント
    Private Const CMlngvsfJJigListUpdateFlag				As Integer = 21					'変更フラグ

	'@vsfJJigListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfJJigListColNo						As String = "№"
    Private Const CMstrvsfJJigListColSelect					As String = "選択"
    Private Const CMstrvsfJJigListColJJigId					As String = "治具ID"
    Private Const CMstrvsfJJigListColJJigStatusId			As String = "ステータス(ID)"
    Private Const CMstrvsfJJigListColJJigStatusNm			As String = "ステータス"
    Private Const CMstrvsfJJigListColPdId					As String = "機種"
    Private Const CMstrvsfJJigListColJJigCategoryId			As String = "治具カテゴリ(ID)"
    Private Const CMstrvsfJJigListColJJigCategoryNm			As String = "蒸着治具カテゴリ"
    Private Const CMstrvsfJJigListSetGuideMaskId			As String = "組立相手"
    Private Const CMstrvsfJJigListColSetEmpId				As String = "組立作業者(ID)"
    Private Const CMstrvsfJJigListColSetEmpName				As String = "組立作業者"
    Private Const CMstrvsfJJigListColWashUseNum				As String = "使用回数"
    Private Const CMstrvsfJJigListColWashUseLimit			As String = "上限回数"
    Private Const CMstrvsfJJigListColNextStockReadyFlag		As String = "次回在庫"
    Private Const CMstrvsfJJigListColStartTime				As String = "使用開始日時"
    Private Const CMstrvsfJJigListColCleanTime				As String = "最終洗浄日時"
    Private Const CMstrvsfJJigListColUseNum					As String = "累積使用回数"
	Private Const CMstrvsfJJigListColUseLimit				As String = "累積上限回数"
    Private Const CMstrvsfJJigListColEmpId					As String = "最終更新者(ID)"
    Private Const CMstrvsfJJigListColEmpName				As String = "最終更新者"
    Private Const CMstrvsfJJigListColComments				As String = "コメント"
    Private Const CMstrvsfJJigListColUpdateFlag				As String = "変更フラグ"

	'@vsfJJigListの定数宣言(列幅)
    Private Const CMlngvsfJJigListNoWidth					As Integer = 35			'№
    Private Const CMlngvsfJJigListSelectWidth				As Integer = 42         '選択
    Private Const CMlngvsfJJigListJJigIdWidth				As Integer = 100        '治具ID
    Private Const CMlngvsfJJigListJJigStatusIdWidth			As Integer = 120        'ステータス(ID)
    Private Const CMlngvsfJJigListJJigStatusNmWidth			As Integer = 120        'ステータス
    Private Const CMlngvsfJJigListJJigPdIdWidth				As Integer = 100        '機種
    Private Const CMlngvsfJJigListJJigCategoryIdWidth		As Integer = 138        '治具カテゴリ(ID)
    Private Const CMlngvsfJJigListJJigCategoryNmWidth		As Integer = 140        '治具カテゴリ
    Private Const CMlngvsfJJigListSetGuideMaskWidth			As Integer = 100		'組立相手
    Private Const CMlngvsfJJigListSetEmpIdWidth				As Integer = 125        '蒸着マスク組立作業者(ID)
    Private Const CMlngvsfJJigListSetEmpNameWidth			As Integer = 100        '蒸着マスク組立作業者
    Private Const CMlngvsfJJigListWashUseNumWidth			As Integer = 80			'洗浄後使用回数
    Private Const CMlngvsfJJigListWashUseLimitWidth			As Integer = 80			'洗浄後上限回数
	Private Const CMlngvsfJJigListNextStockReadyFlagWidth	As Integer = 80         '次回在庫準備
    Private Const CMlngvsfJJigListStartTimeWidth			As Integer = 125        '使用開始日時
    Private Const CMlngvsfJJigListCleanTimeWidth			As Integer = 125		'最終洗浄日時
    Private Const CMlngvsfJJigListUseNumWidth				As Integer = 120        '累積使用回数
    Private Const CMlngvsfJJigListUseLimitWidth				As Integer = 120        '累積上限回数
    Private Const CMlngvsfJJigListEmpIDWidth				As Integer = 125        '最終更新者(ID)
    Private Const CMlngvsfJJigListEmpNameWidth				As Integer = 120        '最終使用者
    Private Const CMlngvsfJJigListCommentsWidth				As Integer = 120        'コメント
    Private Const CMlngvsfJJigListUpdateFlagWidth			As Integer = 120        '変更フラグ

    '@vsfJycJigListの定数宣言(処理区分)
    Private Const CMlngMouseClick                       As Integer = 1                 'ﾏｳｽｸﾘｯｸﾌﾗｸﾞ=1
    Private Const CMlngKeyDown                          As Integer = 2                 'ｷｰﾀﾞｳﾝﾌﾗｸﾞ=2
    Private Const CMlngGridTitleRow                     As Integer = 0                 'ﾀｲﾄﾙ行

    '@ｺﾝﾎﾞ
    Private Const CMstrPipeString                       As String = "|"

    'ｺﾝﾎﾞﾎﾞｯｸｽ定義ｱｲﾃﾑ
    Private Const CMstrCmbItemAll                       As String = "全て"
    Private Const CMstrJigClassJycId                    As String = "J"
    Private Const CMstrJigClassJycNm                    As String = "蒸着"
    Private Const CMstrJigClassHirId                    As String = "H"
    Private Const CMstrJigClassHirNm                    As String = "平置"
    Private Const CMstrPanelKindTFTId                   As String = "T"
    Private Const CMstrPanelKindTFTNm                   As String = "TFT"
    Private Const CMstrPanelKindCFId                    As String = "C"
    Private Const CMstrPanelKindCFNm                    As String = "CF(小板)"
    Private Const CMstrPanelKindODFId                   As String = "O"
    Private Const CMstrPanelKindODFNm                   As String = "CF(大板)"
    Private Const CMstrPanelKindDummiyId                As String = "D"
    Private Const CMstrPanelKindDummiyNm                As String = "ダミー"
    Private Const CMstrListIsNull                       As String = ""

	'蒸着治具側ｺﾝﾎﾞﾎﾞｯｸｽ定義ｱｲﾃﾑ
	Private Const CMstrCmbStatusAllExScrapId			As String = "7"
	Private Const CMstrCmbStatusAllExScrapNm			As String = "廃却以外全て"
	Private Const CMstrCmbStatusScrapId					As String = "6"
	Private Const CMstrCmbStatusScrapNm					As String = "廃却"
	Private Const CMstrCmbStatusRdyUseBeforeSetId		As String = "5"
	Private Const CMstrCmbStatusRdyUseBeforeSetNm		As String = "使用可(組前)"
	Private Const CMstrCmbStatusRdyUseAfterSetId		As String = "0"
	Private Const CMstrCmbStatusRdyUseId				As String = "0"
	Private Const CMstrCmbStatusRdyUseAfterSetNm		As String = "使用可(組後)"
	Private Const CMstrCmbStatusRdyUseNm				As String = "使用可"
	Private Const CMstrCmbStatusWashingId				As String = "4"
	Private Const CMstrCmbStatusWashingNm				As String = "洗浄中"
	Private Const CMstrCmbStatusUsingSetId				As String = "1"
	Private Const CMstrCmbStatusUsingNm					As String = "使用中"
	Private Const CMstrCmbStatusNotUseId				As String = "2"
	Private Const CMstrCmbStatusNotUseNm				As String = "使用不可"
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

	Private Const CMstrNextStockReady                   As String = "済"           '次回在庫準備

	'蒸着治具イベントID
	Private Const CMstrJigEventIdWash					As String = "1"				'洗浄
	Private Const CMstrJigEventIdWashComp				As String = "2"				'受入
	Private Const CMstrJigEventIdNotUse					As String = "3"				'使用不可
	Private Const CMstrJigEventIdScrap					As String = "4"				'廃却



    '@治具識別ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbGridColName                   As Integer = 0                 '名称列番
    Private Const CMlngCmbGridColID                     As Integer = 1                 'ID列番(非表示項目)
    Private Const CMlngCmbDispCols                      As Integer = 1                 'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbListIndex                     As Integer = 0                 'ﾘｽﾄｲﾝﾃﾞｯｸｽ
    Private Const CMlngCmbRowHeight                     As Integer = 18               'ﾘｽﾄ行の高さ
    Private Const CMlngCmbFontSize                      As Integer = 11                'ﾌｫﾝﾄｻｲｽﾞ

    '@項目行
    Private Const CMlngTitleRow                         As Integer = 0                      'ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ行
                                                                                            
    '@色の定数宣言                                                                          
    Private Const CMlngVbColorWhite                     As Integer = &HFFFFFF               '白色
	Private Const CMlngBackColorYellow                  As Integer = &HC0FFFF               '黄色
    Private Const CMlngBackColorSBlue                   As Integer = &HFFFFC0               '選択行の背景色(水色)

    '@治具のｽﾃｰﾀｽ
    Private Const CMlngSiyouka                          As Integer = 0                      '使用可
    Private Const CMlngSiyouCyuu                        As Integer = 1                      '使用中
    Private Const CMlngSiyoufuka                        As Integer = 2                      '使用不可
    Private Const CMlngYoyaku                           As Integer = 3                      '移載予約
    Private Const CMlngSenjyouCyu                       As Integer = 4                      '洗浄中
	Private Const CMlngSiyoukaKumimae                   As Integer = 5                      '使用可(組前)
    Private Const CMlngHaikyaku							As Integer = 6                      '廃却

                                                                                            
    '@機能ID                                                                                
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN02D0          
                                                                                            
    '@ﾃｷｽﾄ                                                                                  
    Private Const CMlngMaxDispRow                       As Integer = 3                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '@その他
    Private Const CMstrFormName                         As String = "frmxxEN02D0"				'自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"					'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdNowListClick                  As String = "cmdNowList_Click"			'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdRegistClick                   As String = "cmdRegist_Click"			'ｲﾍﾞﾝﾄ名称
	Private Const CMstrCmdJJigNowListClick              As String = "cmdJJigNowList_Click"      'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdJJigRegistClick               As String = "cmdJJigRegist_Click"       'ｲﾍﾞﾝﾄ名称
    '@画面ｻｲｽﾞ取得時用
    Private Const CMstrCfFlag1                          As String = "1"                     'CFﾌﾗｸﾞ(1：CFの時)

	'TabIndex
    Private Const CMintTab0 As Integer = 0
    Private Const CMintTab1 As Integer = 1


    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mstrComments                                As String                           'ｺﾒﾝﾄ退避
    Private mtypChgSort                                 As ChgSort                          'ｿｰﾄ保持用
    Private mblnErrChkFlag                              As Boolean                          'ｴﾗｰﾁｪｯｸﾌﾗｸﾞ
    Private mtypCarrierCategory                         As CarrierCategoryList              'ｷｬﾘｱｶﾃｺﾞﾘ
    Private mtypScreenSizeList                          As ScreenSizeList                   'ｽｸﾘｰﾝｻｲｽﾞ格納変数
    Private mstrCategoryName                            As String                           'ｶﾃｺﾞﾘ名
    Private mstrScreenSize                              As String                           'ｽｸﾘｰﾝｻｲｽﾞ
    Private mstrScreenSizeList                          As String                           'ｽｸﾘｰﾝｻｲｽﾞﾘｽﾄ
    Private mstrUseLimit                                As String                           '累積上限回数
    Private mstrWashUseLimit                            As String                           '洗浄後上限回数
    Private mblnEventCancelFlag                         As Boolean                          'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ
    Private mblnToWashFlag                              As Boolean                          '洗浄ﾁｪｯｸﾌﾗｸﾞ
    Private mblnToWashCompFlag                          As Boolean                          '洗浄完了ﾌﾗｸﾞ
    Private mblnJigDataEditFlag                         As Boolean                          '治具ﾃﾞｰﾀ編集ﾌﾗｸﾞ

	'蒸着治具タブ用
    Private mstrJJigComments                            As String                           'ｺﾒﾝﾄ退避
    Private mtypJJigChgSort                             As ChgSort                          'ｿｰﾄ保持用
    Private mblnJJigErrChkFlag                          As Boolean                          'ｴﾗｰﾁｪｯｸﾌﾗｸﾞ
    Private mstrJJigCategoryName                        As String                           'ｶﾃｺﾞﾘ名
    Private mstrJJigUseLimit                            As String                           '累積上限回数
    Private mstrJJigWashUseLimit                        As String                           '洗浄後上限回数
    Private mblnJJigEventCancelFlag                     As Boolean                          'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ
    Private mblnJJigToWashFlag                          As Boolean                          '洗浄ﾁｪｯｸﾌﾗｸﾞ
    Private mblnJJigToWashCompFlag                      As Boolean                          '洗浄完了ﾌﾗｸﾞ
    Private mblnJJigDataEditFlag						As Boolean                          '蒸着治具ﾃﾞｰﾀ編集ﾌﾗｸﾞ
	Private mblnJJigSelectFlag							As Boolean                          '蒸着治具選択ﾌﾗｸﾞ
	Private mblnJJigNotUseFlag							As Boolean                          '使用不可ﾌﾗｸﾞ
	Private mblnJJigScrapFlag							As Boolean                          '廃却ﾌﾗｸﾞ

	Private mobjScrollPos								As Integer							'スクロール位置

	Private mblnValidateFlag                             As Boolean                           'Validate用



    '@↓2013/04/26 (Fri) 10:59:45 T.Oide **************************************************
    Private mstrcmbJigClass                             As String                           '治具識別ｺﾝﾎﾞ退避用
    Private mstrcmbPanelKind                            As String                           'ﾊﾟﾈﾙ識別ｺﾝﾎﾞ退避用
    Private mstrcmbScreenSize                           As String                           'ｽｸﾘｰﾝｻｲｽﾞｺﾝﾎﾞ退避用

	Private mstrcmbJJigStatus							As String                           'ステータスｺﾝﾎﾞ退避用
    Private mstrcmbJJigCategory                          As String                           '蒸着治具ｶﾃｺﾞﾘ退避用
    'Private mstrcmbScreenSize                           As String                           'ｽｸﾘｰﾝｻｲｽﾞｺﾝﾎﾞ退避用


    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ
    '@↑2013/04/26 (Fri) 10:59:45 T.Oide **************************************************

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
    '機　能：ACT初期設定および初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/26 (Tue) 13:26:21 K.Nishizawa
    '更新日：2013/04/17 (Wed) 12:07:30 T.Oide
    '備　考：
    '　　　：2009/06/17 (Wed) 09:45:43 N.Kojima     確定ﾎﾞﾀﾝ制御処理追加。
    '　　　：2009/08/06 (Thu) 14:35:59 N.Kojima     無機対応Phase3、ﾀﾞﾐｰ冶具選択は空き冶具一覧から選択させるようにしたことに伴う修正。(案件№03704)
    '　　　：2010/01/22 (Fri) 16:39:50 T.Oide       №03910対応(ｽｸﾘｰﾝｻｲｽﾞの手動変更対応)
    '　　　：2010/04/26 (Mon) 13:35:24 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Private Sub Form_Load()
        
        Dim lblnAns             As Boolean
        Dim lblnAns2            As Boolean
        Dim lblnAns3            As Boolean
        Dim llngCnt             As Integer
        Dim lstrCategoryList    As String       'ｷｬﾘｱｶﾃｺﾞﾘのﾘｽﾄを格納
		Dim lstrJJigCategoryList    As String	'グリッドコンボ用蒸着治具ｶﾃｺﾞﾘのﾘｽﾄ

        Try
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02D0, CMstrLocalVersion)
            
            If lblnAns = False Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@ｽｸﾘｰﾝｻｲｽﾞﾏｽﾀｰ取得
            lblnAns2 = pubblnMasScreenList_Sel(CMstrmas_screenlistVer, _
                                              CMstrCfFlag1, _
                                              mtypScreenSizeList)
            
            If lblnAns2 = False Then
                '@取得失敗した場合
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
                
            Else
                '@取得成功した場合ｺﾝﾎﾞﾘｽﾄ設定
                
                '@取得数が0でないか
                If mtypScreenSizeList.lngScreenSizeListCnt <> 0 Then
                
                    '@取得数分繰り返し(|xxxx|xxxx|...の形で変数に格納してｺﾝﾎﾞのﾘｽﾄを作成
                    For llngCnt = 0 To mtypScreenSizeList.lngScreenSizeListCnt -1
                        
                        If llngCnt = 0 Then
                            mstrScreenSizeList = mtypScreenSizeList.typScreenList(llngCnt).strScreenSizeID
                        Else
                            mstrScreenSizeList = mstrScreenSizeList & CMstrPipeString & mtypScreenSizeList.typScreenList(llngCnt).strScreenSizeID
                        End If
                    Next
                    
                    '@ｸﾞﾘｯﾄﾞのｽｸﾘｰﾝｻｲｽﾞにｺﾝﾎﾞﾘｽﾄ設定
                    vsfJycJigList.Cols(CMlngvsfJycJigListScreenSizeIdCol).ComboList = mstrScreenSizeList
                    
                End If
            End If
            
            
            '@ｷｬﾘｱｶﾃｺﾞﾘの一覧取得
            lblnAns3 = pubblnCarrierCategoryList_Sel(CMstrmas_carriercategorylistVer, _
                                                pstrSBID, mtypCarrierCategory)
            '@取得OKならﾘｽﾄ作成
            If lblnAns3 = False Then
                '@取得失敗した場合
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
                
            Else
            
                '@取得数は0でないか
                If mtypCarrierCategory.lngCarrierCategoryCnt <> 0 Then
                    
                    '@取得数分ﾙｰﾌﾟ
                    For llngCnt = 0 To mtypCarrierCategory.lngCarrierCategoryCnt -1
                        If llngCnt = 0 Then
                            lstrCategoryList = mtypCarrierCategory.typCarrierCategory(llngCnt).strCategoryName
                        Else
                            lstrCategoryList = lstrCategoryList & CMstrPipeString & mtypCarrierCategory.typCarrierCategory(llngCnt).strCategoryName
                        End If
                    Next
                    
                    '@ｺﾝﾎﾞﾘｽﾄ設定
                    vsfJycJigList.Cols(CMlngvsfJycJigListCarrieCategoryNCol).ComboList = lstrCategoryList
                End If
                
            End If
            

			'蒸着治具ﾘｽﾄの蒸着治具ｶﾃｺﾞﾘ列にコンボ設定
			lstrJJigCategoryList　= CMstrCmbJJigCategoryGuideNm & CMstrPipeString & _
									CMstrCmbJJigCategoryMaskNm & CMstrPipeString & _
									CMstrCmbJJigCategoryHolderNm & CMstrPipeString & _
									CMstrCmbJJigCategoryDummyNm
			'グリッドにも設定
			vsfJJigList.Cols(CMlngvsfJJigListJJigCategoryNmCol).ComboList = lstrJJigCategoryList
            
            '@ｿｰﾄ保持用構造体 初期化
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

			'@ｿｰﾄ保持用構造体 初期化
            With mtypJJigChgSort
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
                
            '@ｺﾝﾎﾞﾎﾞｯｸｽの設定(治具識別&ﾊﾟﾈﾙ種別)
			'@蒸着治具側コンボも設定
            Call prvCmbBox_Set()
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfJycJigList_Init()
			Call prvvsfJJigList_Init()
            
            '@=======================
            '@ 最新取得ﾎﾞﾀﾝ押下処理
            '@=======================
			
            Call cmdNowList_Click(cmdNowList,New EventArgs)
            Call cmdJJigNowList_Click(cmdJJigNowList,New EventArgs)

            pblnFormLoad = True
            
            '@編集状態管理ﾌﾗｸﾞ初期化
            mblnToWashFlag = False
            mblnToWashCompFlag = False
            mblnJigDataEditFlag = False

			'@編集状態管理ﾌﾗｸﾞ初期化
            mblnJJigToWashFlag = False
            mblnJJigToWashCompFlag = False
            mblnJJigDataEditFlag = False

			'初期表示として蒸着治具タブを選択する
            tabJIG.SelectedIndex = 1

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

    '関数名：cmbJigClass_Change
    '機　能：再選択された場合ﾘｽﾄをｸﾘｱｰする
    '引　数：なし
    '戻り値：
    '作成日：2013/04/26 (Fri) 09:57:50 T.Oide
    '更新日：2013/04/26 (Fri) 09:57:50
    '備　考：
    Private Sub cmbJigClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbJigClass.Change

        Try

            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙ中か
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If

            '@編集中確認
            If prvChkEdit <> True Then
                mblnEventCancelFlag = True
                '@元に戻す
                cmbJigClass.Text = mstrcmbJigClass
                mblnEventCancelFlag = False
                Exit Sub
            End If
            
            '@現在値退避
            mstrcmbJigClass = cmbJigClass.Text
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfJycJigList_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbJigClass_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbJigClass_CloseUp
    '機　能：平置き治具を選択した場合、パネル識別は｢すべて｣固定にする
    '引　数：なし
    '戻り値：
    '作成日：2009/07/22 (Wed) 16:28:24 T.Oide
    '更新日：2009/07/22 (Wed) 16:28:24
    '備　考：
    Private Sub cmbJigClass_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbJigClass.CloseUp

        Try
            
            If cmbJigClass.Text = CMstrJigClassHirNm Then
            
                cmbPanelKind.ListIndex = 0
                cmbPanelKind.Enabled = False
            
            Else
                cmbPanelKind.Enabled = True
                
            End If
            
        Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbJigClass_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbPanelKind_Change
    '機　能：再選択された場合ﾘｽﾄをｸﾘｱｰする
    '引　数：なし
    '戻り値：
    '作成日：2013/04/26 (Fri) 10:02:58 T.Oide
    '更新日：2013/04/26 (Fri) 10:02:58
    '備　考：
    Private Sub cmbPanelKind_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPanelKind.Change

        Try
            
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙ中か
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            '@編集中確認
            If prvChkEdit <> True Then
                mblnEventCancelFlag = True
                '@元に戻す
                cmbPanelKind.Text = mstrcmbPanelKind
                mblnEventCancelFlag = False
                Exit Sub
            End If
            
            '@現在値退避
            mstrcmbPanelKind = cmbPanelKind.Text
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfJycJigList_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPanelKind_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbPanelKind_CloseUp
    '機　能：TFTとダミーのときスクリーンサイズコンボを「全て｣で無効にする
    '引　数：なし
    '戻り値：
    '作成日：2013/04/17 (Wed) 13:18:45 T.Oide
    '更新日：2013/04/17 (Wed) 13:18:45
    '備　考：
    Private Sub cmbPanelKind_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPanelKind.Closeup

        Try
            
            If cmbPanelKind.Text = CMstrPanelKindTFTNm Or _
               cmbPanelKind.Text = CMstrPanelKindDummiyNm Then
            
                cmbScreenSize.ListIndex = 0
                cmbScreenSize.Enabled = False
            
            Else
                cmbScreenSize.Enabled = True
                
            End If
            
        Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPanelKind_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：cmbScreenSize_Change
    '機　能：再選択された場合ﾘｽﾄをｸﾘｱｰする
    '引　数：なし
    '戻り値：
    '作成日：2013/04/26 (Fri) 10:04:11 T.Oide
    '更新日：2013/04/26 (Fri) 10:04:11
    '備　考：
    Private Sub cmbScreenSize_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbScreenSize.Change

        Try
            
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙ中か
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            '@編集中確認
            If prvChkEdit <> True Then
                mblnEventCancelFlag = True
                '@元に戻す
                cmbScreenSize.Text = mstrcmbScreenSize
                mblnEventCancelFlag = False
                Exit Sub
            End If
            
            '@現在値退避
            mstrcmbScreenSize = cmbScreenSize.Text
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfJycJigList_Init()
            
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

	
    '関数名：cmbJJigStatus_Change
    '機　能：再選択された場合ﾘｽﾄをｸﾘｱｰする
    '引　数：なし
    '戻り値：
    '作成日：
    '更新日：
    '備　考：
    Private Sub cmbJJigStatus_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbJJigStatus.Change

        Try

            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙ中か
            If mblnJJigEventCancelFlag = True Then
                Exit Sub
            End If

            '@編集中確認
            If prvChkEdit <> True Then
                mblnJJigEventCancelFlag = True
                '@元に戻す
                cmbJJigStatus.Text = mstrcmbJJigStatus
                mblnJJigEventCancelFlag = False
                Exit Sub
            End If
            
            '@現在値退避
            mstrcmbJJigStatus = cmbJJigStatus.Text
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfJJigList_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbJJigStatus_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

	'関数名：cmbJJigCategory_Change
    '機　能：再選択された場合ﾘｽﾄをｸﾘｱｰする
    '引　数：なし
    '戻り値：
    '作成日：
    '更新日：
    '備　考：
    Private Sub cmbJJigCategory_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbJJigCategory.Change

        Try

            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙ中か
            If mblnJJigEventCancelFlag = True Then
                Exit Sub
            End If

            '@編集中確認
            If prvChkEdit <> True Then
                mblnJJigEventCancelFlag = True
                '@元に戻す
                cmbJJigCategory.Text = mstrcmbJJigCategory
                mblnJJigEventCancelFlag = False
                Exit Sub
            End If
            
            '@現在値退避
            mstrcmbJJigCategory = cmbJJigCategory.Text
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfJJigList_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbJJigCategory_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '関数名：Form_QueryUnload
    '機　能：
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：
    '作成日：2009/05/26 (Tue) 13:26:21 K.Nishizawa
    '更新日：2010/04/26 (Mon) 16:12:46 T.Oide
    '備　考：
    '　　　：2010/04/26 (Mon) 13:35:24 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm         As Boolean
        
        Try
                        
            'ｵﾌﾞｼﾞｪｸﾄ初期化
            pubtypJycJigListTmp.llngJigListCnt = 0
            If pubtypJycJigListTmp.pubJycJigList Is Nothing Then
                pubtypJycJigListTmp.pubJycJigList = New List(Of JycJigList)
            Else
                pubtypJycJigListTmp.pubJycJigList.Clear
            End If
            If mtypCarrierCategory.typCarrierCategory Is Nothing Then
                mtypCarrierCategory.typCarrierCategory = New List(Of CarrierCategory)
            Else
                mtypCarrierCategory.typCarrierCategory.Clear
            End If

            If mtypChgSort.typChgSortList Is Nothing Then
                mtypChgSort.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort.typChgSortList.Clear
            End If

            If mtypJJigChgSort.typChgSortList Is Nothing Then
                mtypJJigChgSort.typChgSortList = New List(Of ChgSortList)
            Else
                mtypJJigChgSort.typChgSortList.Clear
            End If



			'蒸着治具タブｵﾌﾞｼﾞｪｸﾄ初期化
            pubtypJJigListTmp.llngJJigListCnt = 0
            If pubtypJJigListTmp.pubJJigList Is Nothing Then
                pubtypJJigListTmp.pubJJigList = New List(Of JJigList)
            Else
                pubtypJJigListTmp.pubJJigList.Clear
            End If


            mstrCategoryName = vbNullString
            mstrScreenSize = vbNullString
            mstrScreenSizeList = vbNullString
            mstrUseLimit = vbNullString
            mstrWashUseLimit = vbNullString

			
            mstrJJigCategoryName = vbNullString
            mstrJJigUseLimit = vbNullString
            mstrJJigWashUseLimit = vbNullString


            '@ActInitﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                
                '@=======================
                '@　ACTｵﾌﾞｼﾞｪｸﾄの開放処理
                '@=======================
                lblnAnsTerm = pubblnAct_Term
                
                '@処理結果判定
                If lblnAnsTerm = True Then
                    '@結果：正常の場合
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@=======================
                '@　ﾒﾆｭｰを広げる処理
                '@=======================
                Call pubMenuExpand_Disp()
            End If
            
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception
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
    '機　能：最新取得ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2013/04/26 (Fri) 10:42:23 T.Oide
    '備　考：
    '　　　：2009/06/17 (Wed) 09:45:43 N.Kojima     確定ﾎﾞﾀﾝ制御処理追加。
    '　　　：2009/08/06 (Thu) 14:35:59 N.Kojima     無機対応Phase3、ﾀﾞﾐｰ冶具選択は空き冶具一覧から選択させるようにしたことに伴う修正。(案件№03704)
    '　　　：2010/04/27 (Tue) 12:40:26 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Public Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click
        
        Dim ltypJycJigList          As pubtypJycJigList             '蒸着治具ﾘｽﾄ
        Dim lblnRet                 As Boolean                      'ACTﾒｯｾｰｼﾞ取得結果
        Dim lstrFormName            As String                       'ﾌｫｰﾑ名
        Dim lstrEventName           As String                       'ｲﾍﾞﾝﾄ名

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2013/04/26 (Fri) 10:31:30 T.Oide **************************************************
            '@編集中確認
            If prvChkEdit <> True Then
                Exit Sub
            End If
        '--------------------------------------------------------------------------------------
        '@
        '@    '@編集中ﾃﾞｰﾀがある場合は確認ﾒｯｾｰｼﾞを表示する
        '@    If mblnToWashFlag = True Or _
        '@       mblnToWashCompFlag = True Or _
        '@       mblnJigDataEditFlag = True Then
        '@
        '@        '@表示ﾒｯｾｰｼﾞ変換
        '@        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
        '@
        '@        '@"編集中です。 内容を破棄してよろしいですか？"
        '@        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, frmxxEN02D0.Caption, True, 16)
        '@
        '@        '@要求確認
        '@        If llngAns = vbNo Then
        '@            '@装置ﾃﾞｰﾀﾘｽﾄにﾌｫｰｶｽｾｯﾄ
        '@            Call pubSetFocus(vsfJycJigList)
        '@            Exit Sub
        '@        End If
        '@
        '@    End If
        '@↑2013/04/26 (Fri) 10:31:30 T.Oide **************************************************
            
            
            '@ﾚｽﾎﾟﾝｽﾁｪｯｸｽﾀｰﾄ
            lstrFormName = Me.Name
            lstrEventName = "cmdNowList_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ｸﾞﾛｰﾊﾞﾙｵﾌﾞｼﾞｪｸﾄ初期化
            pubtypJycJigListTmp.llngJigListCnt = 0
            If pubtypJycJigListTmp.pubJycJigList Is Nothing Then
                pubtypJycJigListTmp.pubJycJigList = New List(Of JycJigList)
            Else
                pubtypJycJigListTmp.pubJycJigList.Clear
            End If


            '編集ﾌﾗｸﾞ変数初期化
            mblnToWashFlag = False
            mblnToWashCompFlag = False
            mblnJigDataEditFlag = False

            '@治具一覧取得
        '@↓2013/04/17 (Wed) 13:09:31 T.Oide **************************************************
        '@    lblnRet = pubblnJycJigList_Sel(CMstrjig_jyclist__Ver, _
        '@                                   cmbJigClass.Value, _
        '@                                   cmbPanelKind.Value, _
        '@                                   ltypJycJigList)
        '@-------------------------------------------------------------------------------------
            lblnRet = pubblnJycJigList_Sel(CMstrjig_jyclist__Ver, _
                                           cmbJigClass.Value, _
                                           cmbPanelKind.Value, _
                                           ltypJycJigList, _
                                           , _
                                           cmbScreenSize.Value)
        '@↑2013/04/17 (Wed) 13:09:31 T.Oide **************************************************

            '@取得結果展開
            If lblnRet Then
                '@ﾃﾞｰﾀをｸﾞﾘｯﾄﾞにｾｯﾄ
                Call prvvsfJycJigList_Disp(ltypJycJigList)
                txtComments.Enabled = True
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdNowList)
            End If

            '@ｸﾞﾛｰﾊﾞﾙｵﾌﾞｼﾞｪｸﾄに格納
            pubtypJycJigListTmp = ltypJycJigList
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：cmdJJigNowList_Click
    '機　能：最新取得ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Public Sub cmdJJigNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdJJigNowList.Click
        
        Dim ltypJJigList			As pubtypJJigList				'蒸着治具ﾘｽﾄ
        Dim lblnRet                 As Boolean                      'ACTﾒｯｾｰｼﾞ取得結果
        Dim lstrFormName            As String                       'ﾌｫｰﾑ名
        Dim lstrEventName           As String                       'ｲﾍﾞﾝﾄ名

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@編集中確認
            If prvChkEdit <> True Then
                Exit Sub
            End If

                   
            '@ﾚｽﾎﾟﾝｽﾁｪｯｸｽﾀｰﾄ
            lstrFormName = Me.Name
            lstrEventName = "cmdJJigNowList_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ｸﾞﾛｰﾊﾞﾙｵﾌﾞｼﾞｪｸﾄ初期化
            pubtypJJigListTmp.llngJJigListCnt = 0
            If pubtypJJigListTmp.pubJJigList Is Nothing Then
                pubtypJJigListTmp.pubJJigList = New List(Of JJigList)
            Else
                pubtypJJigListTmp.pubJJigList.Clear
            End If


            '編集ﾌﾗｸﾞ変数初期化
            mblnJJigToWashFlag = False
            mblnJJigToWashCompFlag = False
            mblnJJigDataEditFlag = False

            lblnRet = pubblnJJigList_Sel(CMstrjig_jjiglistVer, _
                                           cmbJJigStatus.Value, _
                                           cmbJJigCategory.Value, _
										   txtPdId.Text, _
                                           ltypJJigList)

            '@取得結果展開
            If lblnRet Then
                '@ﾃﾞｰﾀをｸﾞﾘｯﾄﾞにｾｯﾄ
                Call prvvsfJJigList_Disp(ltypJJigList)
                txtJJigComments.Enabled = True
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdJJigNowList)
            End If

            '@ｸﾞﾛｰﾊﾞﾙｵﾌﾞｼﾞｪｸﾄに格納
            pubtypJJigListTmp = ltypJJigList
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdJJigClose_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/26 (Fri) 17:06:25 N.Kojima
    '更新日：2013/04/26 (Fri) 10:42:48 T.Oide
    '備　考：
    '　　　：2010/04/27 (Tue) 12:40:26 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim lblnUpd         As Boolean
        Dim ltypCommonInfo  As CommonInfo

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@変数初期化
            lblnUpd = False
            
        '@↓2013/04/26 (Fri) 10:31:30 T.Oide **************************************************
            '@編集中確認
            If prvChkEdit <> True Then
                Exit Sub
            End If
            
            '@=======================
            '@　終了処理
            '@=======================
            Call publngEnd_Proc(CPstrKeyEN02D0, ltypCommonInfo)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUpdate_Click
    '機　能：蒸着治具変更確定
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2010/04/27 (Tue) 13:47:53 T.Oide
    '備　考：
    '　　　：2010/04/27 (Tue) 12:40:26 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click

        Dim lblnAns                     As Boolean
        Dim lprvJycJigListreq           As pubtypJycJigList
        Dim lstrFormName                As String
        Dim lstrEventName               As String
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得
            lstrFormName = Me.Name
            lstrEventName = "cmdUpdate_click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@変更ﾃﾞｰﾀを変数に格納
            Call prvGetJycJigList_typ(lprvJycJigListreq, vbNullString)
            
            '@更新ﾒｯｾｰｼﾞ発行
            lblnAns = pubblnJycJigData_Upd(CMstrjig_chgjyc___Ver, lprvJycJigListreq)
            
            '@結果確認
            If lblnAns Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006Z)
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
        '@↓2010/04/27 (Tue) 13:49:27 T.Oide **************************************************
                '@変更ﾌﾗｸﾞ初期化
                mblnToWashFlag = False
                mblnToWashCompFlag = False
                mblnJigDataEditFlag = False
        '@↑2010/04/27 (Tue) 13:49:27 T.Oide **************************************************
                
                '@再表示
                Call cmdNowList_Click(cmdNowList,New EventArgs)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdNowList)
                
            End If

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

	'関数名：cmdJJigUpdate_Click
    '機　能：蒸着治具変更確定
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub cmdJJigUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdJJigUpdate.Click

        Dim lblnAns                     As Boolean
        Dim lprvJJigListreq				As pubtypJJigList
        Dim lstrFormName                As String
        Dim lstrEventName               As String
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得
            lstrFormName = Me.Name
            lstrEventName = "cmdJJigUpdate_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@変更ﾃﾞｰﾀを変数に格納
            Call prvGetJJigList_typ(lprvJJigListreq, vbNullString, vbNullString, vbNullString)
            
            '@更新ﾒｯｾｰｼﾞ発行
            lblnAns = pubblnJJigData_Upd(CMstrjig_chgjjigVer, lprvJJigListreq)
            
            '@結果確認
            If lblnAns Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006Z)
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                

                '@変更ﾌﾗｸﾞ初期化
                mblnJJigSelectFlag = False
                mblnJJigDataEditFlag = False

                
                '@再表示
                Call cmdJJigNowList_Click(cmdJJigNowList,New EventArgs)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdJJigNowList)
                
            End If

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdJJigUpdate_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub


    '関数名：txtComments_Change
    '機　能：ｺﾒﾝﾄ入力
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2010/04/26 (Mon) 19:12:24 T.Oide
    '備　考：
    '　　　：2010/04/26 (Mon) 13:35:24 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Private Sub txtComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.Change
        
        Dim llngNowByte                 As Integer
        
        Try

            '@変更したｺﾒﾝﾄに紐づく治具IDをﾘｽﾄから検索
            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtComments.NowByte
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)
            
            '@ｺﾒﾝﾄをｾｯﾄする
            With vsfJycJigList
            
                If Trim(.GetData(.Row, CMlngvsfJycJigListCommentsCol)) <> Trim(txtComments.Text) Then
                    .SetData(.Row, CMlngvsfJycJigListCommentsCol, txtComments.Text)
                    .SetCellCheck(.Row, CMlngvsfJycJigListUpdateFlag, CheckEnum.Checked)
                    
        '@↓2010/04/26 (Mon) 19:04:29 T.Oide **************************************************
                    '@編集ﾌﾗｸﾞｾｯﾄ
                    mblnJigDataEditFlag = True
                    
                    '@ﾎﾞﾀﾝの有効/無効ﾁｪｯｸ
                    Call prvCmdButtonEnableChk()
                    
        '@            cmdUpdate.Enabled = True
        '@↑2010/04/26 (Mon) 19:04:29 T.Oide **************************************************
                    
                End If
            End With

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtJJigComments_Change
    '機　能：ｺﾒﾝﾄ入力
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub txtJJigComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtJJigComments.Change
        
        Dim llngNowByte                 As Integer
        
        Try

            '@変更したｺﾒﾝﾄに紐づく治具IDをﾘｽﾄから検索
            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtJJigComments.NowByte

            lblJJigLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtJJigComments, CMlngMaxDispRow, cmdJJigSUp, cmdJJigSDown)
            
            '@ｺﾒﾝﾄをｾｯﾄする
            With vsfJJigList
            
                If Trim(.GetData(.Row, CMlngvsfJJigListCommentsCol)) <> Trim(txtJJigComments.Text) Then
                    .SetData(.Row, CMlngvsfJJigListCommentsCol, txtJJigComments.Text)
                    .SetCellCheck(.Row, CMlngvsfJJigListUpdateFlag, CheckEnum.Checked)
                    
                    '@編集ﾌﾗｸﾞｾｯﾄ
                    mblnJJigDataEditFlag = True
                    
                    '@ﾎﾞﾀﾝの有効/無効ﾁｪｯｸ
                    Call prvCmdButtonEnableChk()
                    
                    
                End If
            End With

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtJJigComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_KeyUp
    '機　能：ｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '機　能：ｺﾒﾝﾄ ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2009/06/01 (Tue) 10:41:08 K.Nishizawa
    '更新日：2009/06/02 (Tue) 10:41:08
    '備　考：
    Private Sub txtComments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComments.KeyUp
        
        Try
            
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)
            
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

	'関数名：txtJJigComments_KeyUp
    '機　能：ｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '機　能：ｺﾒﾝﾄ ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2009/06/01 (Tue) 10:41:08 K.Nishizawa
    '更新日：2009/06/02 (Tue) 10:41:08
    '備　考：
    Private Sub txtJJigComments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtJJigComments.KeyUp
        
        Try
            
            Call pubtxtKeyUp_Proc(e.KeyCode, txtJJigComments, CMlngMaxDispRow, cmdJJigSUp, cmdJJigSDown)
            
            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtJJigComments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：txtComments_MouseUp
    '機　能：ｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2009/06/01 (Tue) 10:41:08 K.Nishizawa
    '更新日：2009/06/02 (Tue) 10:41:08
    '備　考：
    Private Sub txtComments_MouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.MouseUp

        Try

                '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：txtJJigComments_MouseUp
    '機　能：ｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub txtJJigComments_MouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles txtJJigComments.MouseUp

        Try

                '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtJJigComments, CMlngMaxDispRow, cmdJJigSUp, cmdJJigSDown)
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtJJigComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_Validate
    '機　能：ｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '引　数：Cansel:ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2009/06/01 (Tue) 10:41:08 K.Nishizawa
    '更新日：2010/04/26 (Mon) 10:09:54 T.Oide
    '備　考：
    '　　　：2010/04/23 (Fri) 14:03:38 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Private Sub txtComments_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtComments.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            
        '@↓2010/04/23 (Fri) 17:49:19 T.Oide **************************************************
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞが立ている場合処理中止
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
        '@↑2010/04/23 (Fri) 17:49:19 T.Oide **************************************************
            
            With vsfJycJigList
            
                '@退避したｺﾒﾝﾄと違っているか
                If Trim(mstrComments) <> Trim(txtComments.Text) Then
                
                    '@ｸﾞﾘｯﾄﾞに値を格納
                    .SetData(.Row, CMlngvsfJycJigListCommentsCol, txtComments.Text)
                    
                    '@変更ﾁｪｯｸをON
                    .SetCellCheck(.Row, CMlngvsfJycJigListUpdateFlag, CheckEnum.Checked)
                    
        '@↓2010/04/26 (Mon) 19:05:26 T.Oide **************************************************
                    '@編集中ﾌﾗｸﾞｾｯﾄ
                    mblnJigDataEditFlag = True
        '@↑2010/04/26 (Mon) 19:05:26 T.Oide **************************************************
                
                End If
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：txtJJigComments_Validate
    '機　能：ｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '引　数：Cansel:ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub txtJJigComments_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtJJigComments.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞが立ている場合処理中止
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If

            With vsfJJigList
            
                '@退避したｺﾒﾝﾄと違っているか
                If Trim(mstrJJigComments) <> Trim(txtJJigComments.Text) Then
                
                    '@ｸﾞﾘｯﾄﾞに値を格納
                    .SetData(.Row, CMlngvsfJJigListCommentsCol, txtJJigComments.Text)
                    
                    '@変更ﾁｪｯｸをON
                    .SetCellCheck(.Row, CMlngvsfJJigListUpdateFlag, CheckEnum.Checked)
                    
                    '@編集中ﾌﾗｸﾞｾｯﾄ
                    mblnJJigDataEditFlag = True
                
                End If
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtJJigComments_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSUp_Click
    '機　能：ｺﾒﾝﾄ欄ｽｸﾛｰﾙｱｯﾌﾟ
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2009/05/28 (Thr) 17:06:25
    '備　考：
    Private Sub cmdSUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSUp.Click
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUp
            Call pubtxtCmdUp_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)
            'NSYS 文字を全選択
            Call pubSetFocus(txtComments)

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

	'関数名：cmdJJigSUp_Click
    '機　能：ｺﾒﾝﾄ欄ｽｸﾛｰﾙｱｯﾌﾟ
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub cmdJJigSUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdJJigSUp.Click
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUp
            Call pubtxtCmdUp_Proc(txtJJigComments, CMlngMaxDispRow, cmdJJigSUp, cmdJJigSDown)
            'NSYS 文字を全選択
            Call pubSetFocus(txtJJigComments)

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdJJigSUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdSDown_Click
    '機　能：ｺﾒﾝﾄ欄ｽｸﾛｰﾙｱｯﾌﾟ
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2009/05/28 (Thr) 17:06:25
    '備　考：
    Private Sub cmdSDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSDown.Click
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)
            'NSYS 文字を全選択
            Call pubSetFocus(txtComments)

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

	'関数名：cmdJJigSDown_Click
    '機　能：ｺﾒﾝﾄ欄ｽｸﾛｰﾙｱｯﾌﾟ
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2009/05/28 (Thr) 17:06:25
    '備　考：
    Private Sub cmdJJigSDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdJJigSDown.Click
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtJJigComments, CMlngMaxDispRow, cmdJJigSUp, cmdJJigSDown)
            'NSYS 文字を全選択
            Call pubSetFocus(txtJJigComments)

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdJJigSDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfJycJigList_AfterSort
    '機　能：治具一覧ｿｰﾄ後処理
    '引　数：col:列 Order:ｿｰﾄ値
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2009/05/28 (Thr) 17:06:25
    '備　考：
    Private Sub vsfJycJigList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfJycJigList.AfterSort
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJycJigList.Rows.Count <= vsfJycJigList.Rows.Fixed Then
                Return
            End If
            
            AddHandler vsfJycJigList.BeforeRowColChange,AddressOf vsfJycJigList_BeforeRowColChange
            AddHandler vsfJycJigList.EnterCell,AddressOf vsfJycJigList_EnterCell

            '@ｿｰﾄ順を格納
            With mtypChgSort
                .lngCnt = .lngCnt + 1

                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                Dim typChgSortListTmp As New ChgSortList
                typChgSortListTmp.lngCol = e.Col
                typChgSortListTmp.lngOrder = e.Order
                .typChgSortList.Add(typChgSortListTmp)
            End With
            
            '@ｿｰﾄ後処理
            Call pubVsfAfterSort(vsfJycJigList, CMlngvsfJycJigListJigIdCol)

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJycJigList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfJJigList_AfterSort
    '機　能：蒸着治具一覧ｿｰﾄ後処理
    '引　数：col:列 Order:ｿｰﾄ値
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfJJigList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs)  Handles vsfJJigList.AfterSort
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJJigList.Rows.Count <= vsfJJigList.Rows.Fixed Then
                Return
            End If
            
            AddHandler vsfJJigList.BeforeRowColChange,AddressOf vsfJJigList_BeforeRowColChange
            AddHandler vsfJJigList.EnterCell,AddressOf vsfJJigList_EnterCell

            '@ｿｰﾄ順を格納
            With mtypJJigChgSort
                .lngCnt = .lngCnt + 1

                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                Dim typChgSortListTmp As New ChgSortList
                typChgSortListTmp.lngCol = e.Col
                typChgSortListTmp.lngOrder = e.Order
                .typChgSortList.Add(typChgSortListTmp)
            End With
            
            '@ｿｰﾄ後処理
            Call pubVsfAfterSort(vsfJJigList, CMlngvsfJJigListJigIdCol)

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJJigList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfJycJigList_BeforeEdit
    '機　能：蒸着治具一覧変更前処理
    '引　数：Row:行 Col:列 Cancel:ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2009/05/28 (Thr) 17:06:25
    '備　考：
    Private Sub vsfJycJigList_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs)  Handles vsfJycJigList.BeforeEdit

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJycJigList.Rows.Count <= vsfJycJigList.Rows.Fixed Then
                Return
            End If
            
            With vsfJycJigList
            
                '@ｶﾗﾑで処理分岐
                Select Case e.Col
                
                    '@ｺﾒﾝﾄ行の場合
                    Case CMlngvsfJycJigListCommentsCol
                    
                        '@変数にｺﾒﾝﾄを退避
                        mstrComments = .GetData(e.Row, e.Col)
                        
                End Select
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJycJigList_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

	'関数名：vsfJJigList_BeforeEdit
    '機　能：蒸着治具一覧変更前処理
    '引　数：Row:行 Col:列 Cancel:ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfJJigList_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs)  Handles vsfJJigList.BeforeEdit

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJJigList.Rows.Count <= vsfJJigList.Rows.Fixed Then
                Return
            End If
            
            With vsfJJigList
            
                '@ｶﾗﾑで処理分岐
                Select Case e.Col
                
                    '@ｺﾒﾝﾄ行の場合
                    Case CMlngvsfJJigListCommentsCol
                    
                        '@変数にｺﾒﾝﾄを退避
                        mstrJJigComments = .GetData(e.Row, e.Col)
                        
                End Select
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJJigList_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfJycJigList_AfterEdit
    '機　能：蒸着治具一覧編集（編集した行にﾁｪｯｸをつける(編集済み識別をさせる)）
    '引　数：変更行: Row 変更列:Col
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2010/04/26 (Mon) 16:05:37 T.Oide
    '備　考：
    '　　　：2010/04/06 (Tue) 16:42:06 T.Oide       №03910対応(ｽｸﾘｰﾝｻｲｽﾞの手動変更対応)+ｿｰｽ整備
    '　　　：2010/04/26 (Mon) 13:35:24 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Private Sub vsfJycJigList_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs)  Handles vsfJycJigList.AfterEdit
        
        Dim lblnAns         As Boolean
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJycJigList.Rows.Count <= vsfJycJigList.Rows.Fixed Then
                Return
            End If
            
            With vsfJycJigList
            
                '@ｶﾗﾑにより処理分岐
                Select Case .Col
                
        '@↓2010/04/26 (Mon) 16:05:32 T.Oide **************************************************
        '@            '@使用上限の場合
        '@            Case CMlngvsfJycJigListUseLimitCol
                    
                    '@洗浄後上限回数か累積上限回数の場合
                    Case CMlngvsfJycJigListWashUseLimitCol, CMlngvsfJycJigListUseLimitCol
        '@↑2010/04/26 (Mon) 16:05:32 T.Oide **************************************************
                        
                        '@入力値をﾁｪｯｸ
                        lblnAns = prvblnInput_Chk(e.Row)
                        
                        If Not lblnAns Then
                        
                            '@NGの場合
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001F)
                            '@<TRM1FW>$$数字を入力してください。
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@ﾁｪｯｸoff、入力値をｸﾘｱ
                            .SetCellCheck(e.Row, CMlngvsfJycJigListUpdateFlag, CheckEnum.Unchecked)
                            .SetData(e.Row, e.Col, vbNullString)
                        
                        End If
                    
                    '@ｷｬﾘｱｶﾃｺﾞﾘの場合
                    Case CMlngvsfJycJigListCarrieCategoryNCol
                        
                        '@ｷｬﾘｱｶﾃｺﾞﾘ更新時はIDを構造体から取得する
                        Call vsfJycJigList_ValidateEdit(vsfJycJigList,New EventArgs)
                        
                End Select
                

        '@↓2010/04/26 (Mon) 16:07:12 T.Oide **************************************************
        '@        '@変更前の値と異なるか(ｶﾃｺﾞﾘ、ｽｸﾘｰﾝｻｲｽﾞ、累積上限回数)
        '@        If mstrCategoryName <> .Cell(flexcpText, .Row, CMlngvsfJycJigListCarrieCategoryNCol) Or _
        '@           mstrScreenSize <> .Cell(flexcpText, .Row, CMlngvsfJycJigListScreenSizeIdCol) Or _
        '@           mstrUseLimit <> .Cell(flexcpText, .Row, CMlngvsfJycJigListUseLimitCol) Then
                   
                   
                '@変更前の値と異なるか(ｶﾃｺﾞﾘ、ｽｸﾘｰﾝｻｲｽﾞ、累積上限回数、洗浄後上限回数)
                If mstrCategoryName <> .GetData(.Row, CMlngvsfJycJigListCarrieCategoryNCol) Or _
                   mstrScreenSize <> .GetData(.Row, CMlngvsfJycJigListScreenSizeIdCol) Or _
                   mstrUseLimit <> .GetData(.Row, CMlngvsfJycJigListUseLimitCol) Or _
                   mstrWashUseLimit <> .GetData(.Row, CMlngvsfJycJigListWashUseLimitCol) Then
        '@↑2010/04/26 (Mon) 16:07:12 T.Oide **************************************************
                   
                   
                   
                    '@変更されている場合は、ﾊﾞｯｸｶﾗｰを水色にする
                    Select Case .Col
                        
                        '@ｶﾃｺﾞﾘ
                        Case CMlngvsfJycJigListCarrieCategoryNCol
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)
                            Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfJycJigListCarrieCategoryNCol)
                            cellRange.Style = newStyle
                        
                        '@ｽｸﾘｰﾝｻｲｽﾞ
                        Case CMlngvsfJycJigListScreenSizeIdCol
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)
                            Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfJycJigListScreenSizeIdCol)
                            cellRange.Style = newStyle
                        
        '@↓2010/04/26 (Mon) 16:16:49 T.Oide **************************************************
                        '@洗浄後上限回数
                        Case CMlngvsfJycJigListWashUseLimitCol
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                            newStyle.BackColor =ColorTranslator.FromWin32( CMlngBackColorSBlue)
                            Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfJycJigListWashUseLimitCol)
                            cellRange.Style = newStyle
        '@↑2010/04/26 (Mon) 16:16:49 T.Oide **************************************************
                        
                        '@累積上限回数
                        Case CMlngvsfJycJigListUseLimitCol
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)
                            Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfJycJigListUseLimitCol)
                            cellRange.Style = newStyle
                        
                    End Select
                
                    '@ｱｯﾌﾟﾃﾞｰﾄﾌﾗｸﾞをON
                    .SetCellCheck(.Row, CMlngvsfJycJigListUpdateFlag, CheckEnum.Checked)
                    
        '@↓2010/04/26 (Mon) 19:06:33 T.Oide **************************************************
                    '@編集ﾌﾗｸﾞをｾｯﾄ
                    mblnJigDataEditFlag = True
                    
                    '@ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
                    Call prvCmdButtonEnableChk()
                    
        '@            '@｢治具ﾃﾞｰﾀ変更ボタン｣を有効にする
        '@            cmdUpdate.Enabled = True
        '@↑2010/04/26 (Mon) 19:06:33 T.Oide **************************************************

                End If
                
            End With

            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJycJigList_AfterEdit()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

	'関数名：vsfJJigList_AfterEdit
    '機　能：蒸着治具一覧編集（編集した行にﾁｪｯｸをつける(編集済み識別をさせる)）
    '引　数：変更行: Row 変更列:Col
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfJJigList_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs)  Handles vsfJJigList.AfterEdit
        
        Dim lblnAns         As Boolean
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJJigList.Rows.Count <= vsfJJigList.Rows.Fixed Then
                Return
            End If
            
            With vsfJJigList
            
                '@ｶﾗﾑにより処理分岐
                Select Case .Col
                
                    '@洗浄後上限回数の場合
                    Case CMlngvsfJJigListWashUseLimitCol, CMlngvsfJJigListUseLimitCol
                        
                        '@入力値をﾁｪｯｸ
                        lblnAns = prvblnJJigInput_Chk(e.Row)
                        
                        If Not lblnAns Then
                        
                            '@NGの場合
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001F)
                            '@<TRM1FW>$$数字を入力してください。
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@ﾁｪｯｸoff、入力値をｸﾘｱ
                            .SetCellCheck(e.Row, CMlngvsfJJigListUpdateFlag, CheckEnum.Unchecked)
                            .SetData(e.Row, e.Col, vbNullString)
                        
                        End If
                    
                    '@蒸着治具ｶﾃｺﾞﾘの場合
                    Case CMlngvsfJJigListJJigCategoryNmCol
                        
                        '@ｷｬﾘｱｶﾃｺﾞﾘ更新時はIDを構造体から取得する
                        Call vsfJJigList_ValidateEdit(vsfJJigList,New EventArgs)
                        
                End Select
                
                   
                '@変更前の値と異なるか(蒸着治具ｶﾃｺﾞﾘ、洗浄後上限回数)
                If mstrJJigCategoryName <> .GetData(e.Row, CMlngvsfJJigListJJigCategoryNmCol) Or _
                   mstrJJigWashUseLimit <> .GetData(e.Row, CMlngvsfJJigListWashUseLimitCol) Or _
				   mstrJJigUseLimit <> .GetData(e.Row, CMlngvsfJJigListUseLimitCol) Then

                    '@変更されている場合は、ﾊﾞｯｸｶﾗｰを水色にする
                    Select Case .Col
                        
                        '@ｶﾃｺﾞﾘ
                        Case CMlngvsfJJigListJJigCategoryNmCol
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)
                            Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfJJigListJJigCategoryNmCol)
                            cellRange.Style = newStyle
                        
                        '@洗浄後上限回数
                        Case CMlngvsfJJigListWashUseLimitCol
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                            newStyle.BackColor =ColorTranslator.FromWin32( CMlngBackColorSBlue)
                            Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfJJigListWashUseLimitCol)
                            cellRange.Style = newStyle

						'@洗浄後上限回数
                        Case CMlngvsfJJigListUseLimitCol
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                            newStyle.BackColor =ColorTranslator.FromWin32( CMlngBackColorSBlue)
                            Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfJJigListUseLimitCol)
                            cellRange.Style = newStyle

                        
                    End Select
                
                    '@ｱｯﾌﾟﾃﾞｰﾄﾌﾗｸﾞをON
                    .SetCellCheck(.Row, CMlngvsfJJigListUpdateFlag, CheckEnum.Checked)
                    
                    '@編集ﾌﾗｸﾞをｾｯﾄ
                    mblnJJigDataEditFlag = True
                    
                    '@ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
                    Call prvCmdButtonEnableChk()
                    

                End If
                
            End With

            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJJigList_AfterEdit()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfJycJigList_AfterUserResize
    '機　能：蒸着治具一覧情報 列幅変更時処理
    '引　数：Row：行番号
    '　　　：Col：列番号
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：
    '備　考：
    Private Sub vsfJycJigList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs)  Handles vsfJycJigList.AfterResizeColumn, vsfJycJigList.AfterResizeRow

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJycJigList.Rows.Count <= vsfJycJigList.Rows.Fixed Then
                Return
            End If

            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJycJigList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：vsfJJigList_AfterUserResize
    '機　能：蒸着治具一覧情報 列幅変更時処理
    '引　数：Row：行番号
    '　　　：Col：列番号
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfJJigList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfJJigList.AfterResizeColumn, vsfJJigList.AfterResizeRow

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJJigList.Rows.Count <= vsfJJigList.Rows.Fixed Then
                Return
            End If

            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypJJigChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJJigList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfJycJigList_BeforeRowColChange
    '機　能：ｶﾚﾝﾄ行列変更時処理
    '引　数：OldRow：旧行番号
    '　　　：OldCol：旧列番号
    '　　　：NewRow：新行番号
    '　　　：NewCol：新列番号
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2010/04/23 (Fri) 17:49:25 T.Oide
    '備　考：
    '　　　：2010/04/23 (Fri) 14:03:38 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Private Sub vsfJycJigList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfJycJigList.BeforeRowColChange
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJycJigList.Rows.Count <= vsfJycJigList.Rows.Fixed Then
                Return
            End If

        '@↓2010/04/23 (Fri) 17:49:19 T.Oide **************************************************
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞが立ている場合処理中止
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
        '@↑2010/04/23 (Fri) 17:49:19 T.Oide **************************************************
            
            '@現在行が0以上で且つOld行と違っているか
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
            
                '@ｿｰﾄｷｰを退避
                mtypChgSort.strKey = vsfJycJigList.GetData(e.NewRange.r1, CMlngvsfJycJigListJigIdCol)
                
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJycJigList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：vsfJJigList_BeforeRowColChange
    '機　能：ｶﾚﾝﾄ行列変更時処理
    '引　数：OldRow：旧行番号
    '　　　：OldCol：旧列番号
    '　　　：NewRow：新行番号
    '　　　：NewCol：新列番号
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2010/04/23 (Fri) 17:49:25 T.Oide
    '備　考：
    Private Sub vsfJJigList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfJJigList.BeforeRowColChange
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJJigList.Rows.Count <= vsfJJigList.Rows.Fixed Then
                Return
            End If

        '@↓2010/04/23 (Fri) 17:49:19 T.Oide **************************************************
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞが立ている場合処理中止
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
        '@↑2010/04/23 (Fri) 17:49:19 T.Oide **************************************************
            
            '@現在行が0以上で且つOld行と違っているか
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
            
                '@ｿｰﾄｷｰを退避
                mtypJJigChgSort.strKey = vsfJJigList.GetData(e.NewRange.r1, CMlngvsfJJigListJigIdCol)
                
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJJigList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfJycJigList_BeforeSort
    '機　能：
    '引　数：Col：
    '　　　：Order：
    '戻り値：
    '作成日：2010/04/14 (Wed) 15:37:05 T.Oide
    '更新日：2010/04/14 (Wed) 15:37:05
    '備　考：
    Private Sub vsfJycJigList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfJycJigList.BeforeSort
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJycJigList.Rows.Count <= vsfJycJigList.Rows.Fixed Then
                Return
            End If
            
            RemoveHandler vsfJycJigList.BeforeRowColChange,AddressOf vsfJycJigList_BeforeRowColChange
            RemoveHandler vsfJycJigList.EnterCell,AddressOf vsfJycJigList_EnterCell

            '@ｿｰﾄ前のｶﾚﾝﾄKey値の格納処理
            Call pubVsfBeforeSort(vsfJycJigList, CMlngvsfJycJigListJigIdCol)
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJycJigList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

	'関数名：vsfJJigList_BeforeSort
    '機　能：
    '引　数：Col：
    '　　　：Order：
    '戻り値：
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfJJigList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfJJigList.BeforeSort
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJJigList.Rows.Count <= vsfJJigList.Rows.Fixed Then
                Return
            End If
            
            RemoveHandler vsfJJigList.BeforeRowColChange,AddressOf vsfJJigList_BeforeRowColChange
            RemoveHandler vsfJJigList.EnterCell,AddressOf vsfJJigList_EnterCell

            '@ｿｰﾄ前のｶﾚﾝﾄKey値の格納処理
            Call pubVsfBeforeSort(vsfJJigList, CMlngvsfJJigListJigIdCol)
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJJigList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfJycJigList_Click
    '機　能：蒸着治具一覧ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2017/02/16 (Thu) 09:08:24 T.Oide
    '備　考：
    '　　　：2010/01/22 (Fri) 16:39:50 T.Oide       №03910対応(ｽｸﾘｰﾝｻｲｽﾞの手動変更対応) + 全体的にｿｰｽ整備
    '　　　：2010/02/18 (Thu) 15:17:43 T.Oide       №03970対応 治具ﾃﾞｰﾀ変更ﾎﾞﾀﾝの有効制御変更
    '　　　：2010/04/05 (Mon) 15:25:03 T.Oide       R6-10ｼｽﾃﾑﾃｽﾄで見つかった不具合対応(｢使用中｣は治具の情報を変更させない)
    '　　　：2010/04/26 (Mon) 13:35:24 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Private Sub vsfJycJigList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfJycJigList.Click
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJycJigList.Rows.Count <= vsfJycJigList.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー行選択時処理を抜ける
            If vsfJycJigList.MouseRow < vsfJycJigList.Rows.Fixed Then
                Return
            End If

            With vsfJycJigList
            
                '@ﾀｲﾄﾙ行でなければ処理実行
                If .Row <> CMlngTitleRow Then
                
                    '@ｶﾃｺﾞﾘとｽｸﾘｰﾝｻｲｽﾞ退避
                    mstrCategoryName = .GetData(.Row, CMlngvsfJycJigListCarrieCategoryNCol)
                    mstrScreenSize = .GetData(.Row, CMlngvsfJycJigListScreenSizeIdCol)
                    mstrUseLimit = .GetData(.Row, CMlngvsfJycJigListUseLimitCol)
                    mstrWashUseLimit = .GetData(.Row, CMlngvsfJycJigListWashUseLimitCol)

                    '@選択ｶﾗﾑによって処理分岐
                    Select Case .Col
                        '@洗浄列、治具ID列の場合
                        Case CMlngvsfJycJigListWashCol, CMlngvsfJycJigListJigIdCol
                            
                            '@洗浄のﾁｪｯｸ--------------------
                            '@ｽﾃｰﾀｽは｢使用可｣または｢使用不可｣ で
                            ' 累積使用回数 < 累積上限回数
                            If (.GetData(.Row, CMlngvsfJycJigListJigStatusCol) = CMlngSiyouka) Or _
                               (CLng(.GetData(.Row, CMlngvsfJycJigListJigStatusCol)) = CMlngSiyoufuka And _
                                CLng(.GetData(.Row, CMlngvsfJycJigListUseNumCol)) < CLng((.GetData(.Row, CMlngvsfJycJigListUseLimitCol)))) Then
                              
                                '@チェックはOFFか
                                If .GetCellCheck(.Row, CMlngvsfJycJigListWashCol) = CheckEnum.Unchecked Then
                                    '@ﾁｪｯｸOFFの場合--------------------
                                    
                                    '@洗浄完了フラグ = Falseで､編集フラグ = Falseか
                                    If mblnToWashCompFlag = False And mblnJigDataEditFlag = False Then
                                      
                                        '@ﾁｪｯｸをONにする
                                        .SetCellCheck(.Row, CMlngvsfJycJigListWashCol, CheckEnum.Checked)
                                        '@編集ﾌﾗｸﾞ(洗浄)をｾｯﾄ
                                        mblnToWashFlag = True
                                    Else
                                    
                                        'いずれかのﾌﾗｸﾞがTrueの場合はﾁｪｯｸはOFFのまま
                                        '@ﾁｪｯｸをOFFにする
                                        .SetCellCheck(.Row, CMlngvsfJycJigListWashCol, CheckEnum.Unchecked)
                                      
                                    End If
                                    
                                Else
                                    '@ﾁｪｯｸONの場合--------------------
                                    If mblnToWashCompFlag = False And mblnJigDataEditFlag = False Then
                                    
                                        '@ﾁｪｯｸをOFFにする
                                        .SetCellCheck(.Row, CMlngvsfJycJigListWashCol, CheckEnum.Unchecked)
                                        '@編集ﾌﾗｸﾞ(洗浄)をﾘｾｯﾄするか判定
                                        Call prvWashFlagChk(1)
                                        
                                    'Else
                                    
                                        'いずれかのﾌﾗｸﾞがTrueの場合→ありえないはず
                                        '(ﾌﾗｸﾞがTrueのときﾁｪｯｸはONにならない)
                                        
                                    End If
                                    
                                End If
                            End If
                            
                            '@洗浄完了のﾁｪｯｸ--------------------
                            '@ｽﾃｰﾀｽは｢洗浄中｣か
                            If .GetData(.Row, CMlngvsfJycJigListJigStatusCol) = CMlngSenjyouCyu Then
                                
                                '@ﾁｪｯｸはOFFか
                                If .GetCellCheck(.Row, CMlngvsfJycJigListWashCol) = CheckEnum.Unchecked Then
                                    '@ﾁｪｯｸOFFの場合--------------------
                                    
                                    '@洗浄フラグ = Falseで､編集フラグ = Falseか
                                    If mblnToWashFlag = False And mblnJigDataEditFlag = False Then
                                    
                                        '@ﾁｪｯｸをONにする
                                        .SetCellCheck(.Row, CMlngvsfJycJigListWashCol, CheckEnum.Checked)
                                        '@編集ﾌﾗｸﾞ(洗浄中)をｾｯﾄ
                                        mblnToWashCompFlag = True
                                    Else
                                    
                                        'いずれかのﾌﾗｸﾞがTrueの場合はﾁｪｯｸはOFFのまま
                                        '@ﾁｪｯｸをOFFにする
                                        .SetCellCheck(.Row, CMlngvsfJycJigListWashCol, CheckEnum.Unchecked)
                                    End If
                                      
                                Else
                                    '@ﾁｪｯｸONの場合--------------------
                                    If mblnToWashFlag = False And mblnJigDataEditFlag = False Then
                                    
                                        '@ﾁｪｯｸをOFFにする
                                        .SetCellCheck(.Row, CMlngvsfJycJigListWashCol, CheckEnum.Unchecked)
                                        '@編集ﾌﾗｸﾞ(洗浄)をﾘｾｯﾄするか判定
                                        Call prvWashFlagChk(2)
                                    
                                    'Else
                                    
                                        'いずれかのﾌﾗｸﾞがTrueの場合→ありえないはず
                                        '(ﾌﾗｸﾞがTrueのときﾁｪｯｸはONにならない)
                                      
                                    End If
                                End If
                            End If
                            
                        '@ｷｬﾘｱｶﾃｺﾞﾘ列の場合
                        Case CMlngvsfJycJigListCarrieCategoryNCol

                            '@状態は｢使用可｣か
                            If .GetData(.Row, CMlngvsfJycJigListJigStatusCol) = CMlngSiyouka Then

                                '@編集ﾌﾗｸﾞ(洗浄)と編集ﾌﾗｸﾞ(洗浄完)がFalseか
                                If mblnToWashFlag = False And mblnToWashCompFlag = False Then
                                    '@ｾﾙを編集状態にする
                                    .StartEditing()
                                End If

                            Else
                                
                                '@編集不可
                                .AllowEditing = False
                                
                            End If

                        
                        '@ｽｸﾘｰﾝｻｲｽﾞ列の場合
                        Case CMlngvsfJycJigListScreenSizeIdCol
                            
                            '@蒸着のTFT治具以外の場合ｽｸﾘｰﾝｻｲｽﾞのｺﾝﾎﾞﾘｽﾄを出す
                            If .GetData(.Row, CMlngvsfJycJigListpanelKindCol) = CMstrPanelKindTFTNm Then
                            
                                '@ｸﾞﾘｯﾄﾞのｽｸﾘｰﾝｻｲｽﾞにｺﾝﾎﾞﾘｽﾄ設定
                                vsfJycJigList.Cols(CMlngvsfJycJigListScreenSizeIdCol).ComboList = vbNullString
                                
                            Else
                                
                                '@状態は｢使用可｣か
                                If .GetData(.Row, CMlngvsfJycJigListJigStatusCol) = CMlngSiyouka Then
            
                                    '@ｸﾞﾘｯﾄﾞのｽｸﾘｰﾝｻｲｽﾞにｺﾝﾎﾞﾘｽﾄ設定
                                    vsfJycJigList.Cols(CMlngvsfJycJigListScreenSizeIdCol).ComboList = mstrScreenSizeList
                                        
                                    '@編集ﾌﾗｸﾞ(洗浄)と編集ﾌﾗｸﾞ(洗浄完)がFalseか
                                    If mblnToWashFlag = False And mblnToWashCompFlag = False Then
                                        '@ｾﾙを編集状態にする
                                        .StartEditing()
                                    End If
                                    
                                Else
                                
                                    '@編集不可
                                    .AllowEditing = False
                                    
                                End If
                                
                            End If

                    End Select
                    
                End If
                
                '@ﾎﾞﾀﾝの有効/無効ﾁｪｯｸ
                Call prvCmdButtonEnableChk()
                        
            End With

            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJycJigList_Click()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：vsfJJigList_Click
    '機　能：蒸着治具一覧ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Sub vsfJJigList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfJJigList.Click
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJJigList.Rows.Count <= vsfJJigList.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー行選択時処理を抜ける
            If vsfJJigList.MouseRow < vsfJJigList.Rows.Fixed Then
                Return
            End If

            With vsfJJigList
            
                '@ﾀｲﾄﾙ行でなければ処理実行
                If .Row <> CMlngTitleRow Then
                
                    '@ｶﾃｺﾞﾘと洗浄後上限回数退避
                    mstrJJigCategoryName = .GetData(.Row, CMlngvsfJJigListJJigCategoryNmCol)
                    mstrJJigWashUseLimit = .GetData(.Row, CMlngvsfJJigListWashUseLimitCol)
					mstrJJigUseLimit = .GetData(.Row, CMlngvsfJJigListUseLimitCol)

                    '@選択ｶﾗﾑによって処理分岐
                    Select Case .Col

                        '@選択列、治具ID列の場合
                        Case CMlngvsfJJigListSelectCol, CMlngvsfJJigListJigIdCol

                            '@チェックはOFFか
                            If .GetCellCheck(.Row, CMlngvsfJJigListSelectCol) = CheckEnum.Unchecked Then
								'@ﾁｪｯｸOFFの場合--------------------
                                    
                                '@編集フラグ = Falseか
								'@編集フラグがOnの場合はデータを更新してからじゃないと洗浄など各種ボタンを押せないようにﾁｪｯｸをつけない
                                If mblnJJigDataEditFlag = False Then
                                      
                                    '@ﾁｪｯｸをONにする
                                    .SetCellCheck(.Row, CMlngvsfJJigListSelectCol, CheckEnum.Checked)
                                    '@選択フラグをｾｯﾄ
                                    mblnJJigSelectFlag = True

                                End If
                                    
                            Else
                                '@ﾁｪｯｸONの場合--------------------
                                If  mblnJJigDataEditFlag = False Then
                                    
                                    '@ﾁｪｯｸをOFFにする
                                    .SetCellCheck(.Row, CMlngvsfJJigListSelectCol, CheckEnum.Unchecked)
                                    '@選択フラグをﾘｾｯﾄするか判定
                                    Call prvJJigFlagChk(1)
                                        
                                        
                                End If
                                    
                            End If
                            
 
					'@蒸着ｶﾃｺﾞﾘ列の場合
					Case CMlngvsfJJigListJJigCategoryNmCol
						If mblnJJigSelectFlag = False And (.GetData(.Row, CMlngvsfJJigListJJigStatusIdCol) = CMlngSiyouka Or .GetData(.Row, CMlngvsfJJigListJJigStatusIdCol) = CMlngSiyoukaKumimae)  Then
							'@何もしない
							'新規登録時にマスタと突き合わせているので誤って登録することはほぼない→変更機能は不要    
						End If

					End Select
                    
                End If
                
                '@ﾎﾞﾀﾝの有効/無効ﾁｪｯｸ
                Call prvCmdButtonEnableChk()
                        
            End With

            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJJigList_Click()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfJycJigList_ComboCloseUp
    '機　能：ｷｬﾘｱｶﾃｺﾞﾘ選択時処理
    '引　数：Row:行 Col:列
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2009/05/28 (Thr) 17:06:25
    '備　考：
    Private Sub vsfJycJigList_ComboCloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles vsfJycJigList.ComboCloseUp
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJycJigList.Rows.Count <= vsfJycJigList.Rows.Fixed Then
                Return
            End If
            
            With vsfJycJigList
            
                '@治具一覧変更後処理
                Call vsfJycJigList_ValidateEdit(vsfJycJigList,New EventArgs)
            
            End With
                
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJycJigList_ComboCloseUp()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

	'関数名：vsfJJigList_ComboCloseUp
    '機　能：蒸着ｶﾃｺﾞﾘ選択時処理
    '引　数：Row:行 Col:列
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfJJigList_ComboCloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles vsfJJigList.ComboCloseUp
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJJigList.Rows.Count <= vsfJJigList.Rows.Fixed Then
                Return
            End If
            
            With vsfJJigList
            
                '@治具一覧変更後処理
                Call vsfJJigList_ValidateEdit(vsfJJigList,New EventArgs)
            
            End With
                
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJJigList_ComboCloseUp()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfJycJigList_KeyDown
    '機　能：ｶﾃｺﾞﾘとｽｸﾘｰﾝｻｲｽﾞ退避(治具ﾃﾞｰﾀ変更ﾎﾞﾀﾝの有効制御用)
    '引　数：KeyCode：
    '　　　：Shift：
    '戻り値：
    '作成日：2010/02/18 (Thu) 15:22:09 T.Oide
    '更新日：2010/04/26 (Mon) 16:12:10 T.Oide
    '備　考：
    '　　　：2010/04/26 (Mon) 13:35:24 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Private Sub vsfJycJigList_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfJycJigList.KeyDown

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJycJigList.Rows.Count <= vsfJycJigList.Rows.Fixed Then
                Return
            End If


            With vsfJycJigList
            
                '@ﾃﾞｰﾀ行の場合
                If .Rows.Fixed <= .Row Then
                
                   '@ｶﾃｺﾞﾘとｽｸﾘｰﾝｻｲｽﾞ退避
                    mstrCategoryName = .GetData(.Row, CMlngvsfJycJigListCarrieCategoryNCol)
                    mstrScreenSize = .GetData(.Row, CMlngvsfJycJigListScreenSizeIdCol)
        '@↓2010/04/06 (Tue) 16:48:40 T.Oide **************************************************
                    mstrUseLimit = .GetData(.Row, CMlngvsfJycJigListUseLimitCol)
        '@↑2010/04/06 (Tue) 16:48:40 T.Oide **************************************************
        '@↓2010/04/26 (Mon) 16:11:29 T.Oide **************************************************
                    mstrWashUseLimit = .GetData(.Row, CMlngvsfJycJigListWashUseLimitCol)
        '@↑2010/04/26 (Mon) 16:11:29 T.Oide **************************************************

                End If
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJycJigList_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

	'関数名：vsfJJigList_KeyDown
    '機　能：ｶﾃｺﾞﾘ退避(治具ﾃﾞｰﾀ変更ﾎﾞﾀﾝの有効制御用)
    '引　数：KeyCode：
    '　　　：Shift：
    '戻り値：
    '作成日：
    '更新日：
    '備　考：
    '　　　：
    Private Sub vsfJJigList_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfJJigList.KeyDown

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJJigList.Rows.Count <= vsfJJigList.Rows.Fixed Then
                Return
            End If


            With vsfJJigList
            
                '@ﾃﾞｰﾀ行の場合
                If .Rows.Fixed <= .Row Then
                
                   '@ｶﾃｺﾞﾘ退避
                    mstrJJigCategoryName = .GetData(.Row, CMlngvsfJJigListJJigCategoryNmCol)
                    mstrJJigWashUseLimit = .GetData(.Row, CMlngvsfJJigListWashUseLimitCol)
					mstrJJigUseLimit = .GetData(.Row, CMlngvsfJJigListUseLimitCol)
                End If
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJJigList_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfJycJigList_ValidateEdit
    '機　能：治具一覧変更後処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2009/05/28 (Thr) 17:06:25
    '備　考：
    Private Sub vsfJycJigList_ValidateEdit(ByVal sender As Object, ByVal e As EventArgs) Handles vsfJycJigList.ValidateEdit

        Dim llngCnt             As Integer
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJycJigList.Rows.Count <= vsfJycJigList.Rows.Fixed Then
                Return
            End If
            
            With vsfJycJigList
            
                '@選択ｶﾗﾑによって処理分岐
                Select Case .Col
                
                    '@ｶﾃｺﾞﾘの場合
                    Case CMlngvsfJycJigListCarrieCategoryNCol
                    
                        '@ﾒﾓﾘのｶﾃｺﾞﾘｶｳﾝﾄが0以外か
                        If mtypCarrierCategory.lngCarrierCategoryCnt <> 0 Then
                        
                            '@構造体全体をﾁｪｯｸ
                            For llngCnt = 0 To mtypCarrierCategory.lngCarrierCategoryCnt -1
                            
                                '@構造体のｶﾃｺﾞﾘ名とｸﾞﾘｯﾄﾞのｶﾃｺﾞﾘ名が一致しているか
                                If mtypCarrierCategory.typCarrierCategory(llngCnt).strCategoryName = _
                                        .GetData(.Row, CMlngvsfJycJigListCarrieCategoryNCol) Then
                                    
                                    '一致している場合ｸﾞﾘｯﾄﾞのｶﾃｺﾞﾘIDを設定
                                    .SetData(.Row, CMlngvsfJycJigListCarrieCategoryCol, _
                                        mtypCarrierCategory.typCarrierCategory(llngCnt).strCategoryID)
                                        
                                End If
                            Next
                            
                        End If
                        
                        
                    Case Else
                        
                        '@その他のｶﾗﾑの場合
                        If Not mtypChgSort.blnChgWidth Then
                            '.AutoSizeMode = flexAutoSizeColWidth
                            .AutoSizeCol(.Col, 6)
                        End If
                    
                End Select
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJycJigList_ValidateEdit()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：vsfJJigList_ValidateEdit
    '機　能：蒸着治具一覧変更後処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfJJigList_ValidateEdit(ByVal sender As Object, ByVal e As EventArgs) Handles vsfJJigList.ValidateEdit

        Dim llngCnt             As Integer
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJJigList.Rows.Count <= vsfJJigList.Rows.Fixed Then
                Return
            End If
            
            With vsfJJigList
            
                '@選択ｶﾗﾑによって処理分岐
                Select Case .Col
                
                    '@ｶﾃｺﾞﾘの場合
                    Case CMlngvsfJJigListJJigCategoryNmCol
						
						If .GetData(.Row, CMlngvsfJJigListJJigCategoryNmCol) = CMstrCmbJJigCategoryGuideNm Then
							'「ガイドリング」→「G」を設定
							.SetData(.Row, CMlngvsfJJigListJJigCategoryIdCol, CMstrCmbJJigCategoryGuideId)

						Else If .GetData(.Row, CMlngvsfJJigListJJigCategoryNmCol) = CMstrCmbJJigCategoryMaskNm Then
							'「マスク」→「M」を設定
							.SetData(.Row, CMlngvsfJJigListJJigCategoryIdCol, CMstrCmbJJigCategoryMaskId)
						
						Else If .GetData(.Row, CMlngvsfJJigListJJigCategoryNmCol) = CMstrCmbJJigCategoryHolderNm Then
							'「ホルダ」→「H」を設定
							.SetData(.Row, CMlngvsfJJigListJJigCategoryIdCol, CMstrCmbJJigCategoryHolderId)

						Else If .GetData(.Row, CMlngvsfJJigListJJigCategoryNmCol) = CMstrCmbJJigCategoryDummyNm Then
							'「ダミー」→「D」を設定
							.SetData(.Row, CMlngvsfJJigListJJigCategoryIdCol, CMstrCmbJJigCategoryDummyId)
                        
						End If

                        
                    Case Else
                        
                        '@その他のｶﾗﾑの場合
                        If Not mtypJJigChgSort.blnChgWidth Then
                            '.AutoSizeMode = flexAutoSizeColWidth
                            .AutoSizeCol(.Col, 6)
                        End If
                    
                End Select
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJJigList_ValidateEdit()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfJycJigList_DblClick
    '機　能：蒸着治具一覧編集
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2010/04/26 (Mon) 13:35:24 T.Oide
    '備　考：
    '　　　：2009/08/06 (Thu) 14:35:59 N.Kojima     無機対応Phase3、ﾀﾞﾐｰ冶具選択は空き冶具一覧から選択させるようにしたことに伴う修正。(案件№03704)
    '　　　：2010/04/05 (Mon) 15:25:03 T.Oide       R6-10ｼｽﾃﾑﾃｽﾄで見つかった不具合対応(｢使用中｣は治具の情報を変更させない)
    '　　　：2010/04/26 (Mon) 13:35:24 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Private Sub vsfJycJigList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfJycJigList.DoubleClick

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfJycJigList.Rows.Count <= vsfJycJigList.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー行選択時処理を抜ける
            If vsfJycJigList.MouseRow < vsfJycJigList.Rows.Fixed Then
                Return
            End If
            
            With vsfJycJigList
                
                '使用上限値を変更する
                Select Case .Col
                    
        '@↓2010/04/26 (Mon) 13:34:31 T.Oide **************************************************
        '@            '@使用上限数
        '@            Case CMlngvsfJycJigListUseLimitCol

                    '@洗浄後上限回数、累積上限回数
                    Case CMlngvsfJycJigListUseLimitCol, CMlngvsfJycJigListWashUseLimitCol
        '@↑2010/04/26 (Mon) 13:34:31 T.Oide **************************************************
                        
                        '@ﾀｲﾄﾙ行以外で状態が｢使用可｣か？
                        If .Row <> 0 And _
                           .GetData(.Row, CMlngvsfJycJigListJigStatusCol) = CMlngSiyouka Then
                           
        '@↓2010/04/27 (Tue) 11:43:24 T.Oide **************************************************

                            '@編集ﾌﾗｸﾞ(洗浄)と洗浄ﾌﾗｸﾞ(洗浄完)がFlaseか
                            If mblnToWashFlag = False And mblnToWashCompFlag = False Then
                                '@編集状態にする
                                .StartEditing()
                                .Editor.BackColor = .GetCellStyleDisplay(.Row,.Col).BackColor
                                .Editor.ForeColor = .GetCellStyleDisplay(.Row,.Col).ForeColor
                            End If
                            
        '@↑2010/04/27 (Tue) 11:43:24 T.Oide **************************************************
                            
                        Else
                        
                            '@編集不可
                            .AllowEditing = False
                        
                        End If
                    
                    Case Else
                        
                        .AllowEditing = False
                End Select
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJycJigList_DblClick()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：vsfJJigList_DblClick
    '機　能：蒸着治具一覧編集
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Sub vsfJJigList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfJJigList.DoubleClick

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfJJigList.Rows.Count <= vsfJJigList.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー行選択時処理を抜ける
            If vsfJJigList.MouseRow < vsfJJigList.Rows.Fixed Then
                Return
            End If
            
            With vsfJJigList
                
                '使用上限値を変更する
                Select Case .Col
                    

                    '@洗浄後上限回数
                    Case  CMlngvsfJJigListWashUseLimitCol, CMlngvsfJJigListUseLimitCol
                        
                        '@ﾀｲﾄﾙ行以外で状態が｢使用可｣「使用可(組前)」か？
                        If .Row <> 0 And _
                           (.GetData(.Row, CMlngvsfJJigListJJigStatusIdCol) = CMlngSiyouka Or .GetData(.Row, CMlngvsfJJigListJJigStatusIdCol) = CMlngSiyoukaKumimae)　　 Then

                            '@選択ﾌﾗｸﾞがFlaseか
                            If mblnJJigSelectFlag = False  Then
                                '@編集状態にする
								.StartEditing()
                                .Editor.BackColor = .GetCellStyleDisplay(.Row,.Col).BackColor
                                .Editor.ForeColor = .GetCellStyleDisplay(.Row,.Col).ForeColor
                            End If
                            

                            
                        Else
                        
                            '@編集不可
                            .AllowEditing = False
                        
                        End If
                    
                    Case Else
                        
                        .AllowEditing = False
                End Select
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJJigList_DblClick()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：vsfJycJigList_EnterCell
    '機　能：蒸着治具一覧編集
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2010/04/23 (Fri) 17:50:02 T.Oide
    '備　考：
    '　　　：2009/06/17 (Wed) 09:44:38 N.Kojima     確定ﾎﾞﾀﾝの処理追加。
    '　　　：2009/08/06 (Thu) 14:35:59 N.Kojima     無機対応Phase3、ﾀﾞﾐｰ冶具選択は空き冶具一覧から選択させるようにしたことに伴う修正。(案件№03704)
    '　　　：2010/04/23 (Fri) 14:03:38 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Private Sub vsfJycJigList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfJycJigList.EnterCell
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJycJigList.Rows.Count <= vsfJycJigList.Rows.Fixed Then
                Return
            End If
            
        '@↓2010/04/23 (Fri) 17:49:19 T.Oide **************************************************
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞが立ている場合処理中止
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
        '@↑2010/04/23 (Fri) 17:49:19 T.Oide **************************************************
            

            
        '@↓2010/04/26 (Mon) 18:58:56 T.Oide **************************************************
        '@    With vsfJycJigList
        '@
        '@        '@ﾀｲﾄﾙ行のみでは無いか
        '@        If .Rows <> (CMlngTitleRow + 1) Then
        '@            txtComments.Text = .Cell(flexcpText, .Row, CMlngvsfJycJigListCommentsCol)
        '@            For llngRowCnt = 1 To .Rows - 1
        '@                '編集行があった場合は"蒸着治具ﾃﾞｰﾀ"変更ボタン有効化
        '@                If .Cell(flexcpChecked, llngRowCnt, CMlngvsfJycJigListUpdateFlag) = flexChecked Then
        '@                    cmdUpdate.Enabled = True
        '@                End If
        '@            Next
        '@        End If
        '@
        '@    End With

            If vsfJycJigList.Row < vsfJycJigList.Rows.Fixed Then
                Exit Sub
            End If

            With vsfJycJigList
            
                '@ﾀｲﾄﾙ行のみでは無いか
                If .Rows.Count <> (CMlngTitleRow + 1) Then
                
                    '@ｺﾒﾝﾄをｸﾞﾘｯﾄﾞの反映
                    txtComments.Text = .GetData(.Row, CMlngvsfJycJigListCommentsCol)
                
                End If
            
            End With
            
            '@ボタン有効/無効ﾁｪｯｸ
            Call prvCmdButtonEnableChk()

        '@↑2010/04/26 (Mon) 18:58:56 T.Oide **************************************************

            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJycJigList_EnterCell()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

	'関数名：vsfJJigList_EnterCell
    '機　能：蒸着治具一覧編集
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Sub vsfJJigList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfJJigList.EnterCell
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJJigList.Rows.Count <= vsfJJigList.Rows.Fixed Then
                Return
            End If
            
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞが立ている場合処理中止
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If

            If vsfJJigList.Row < vsfJJigList.Rows.Fixed Then
                Exit Sub
            End If

            With vsfJJigList
            
                '@ﾀｲﾄﾙ行のみでは無いか
                If .Rows.Count <> (CMlngTitleRow + 1) Then
                
                    '@ｺﾒﾝﾄをｸﾞﾘｯﾄﾞの反映
                    txtJJigComments.Text = .GetData(.Row, CMlngvsfJJigListCommentsCol)
                
                End If
            
            End With
            
            '@ボタン有効/無効ﾁｪｯｸ
            Call prvCmdButtonEnableChk()

        '@↑2010/04/26 (Mon) 18:58:56 T.Oide **************************************************

            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJJigList_EnterCell()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：cmdJigWash_Click
    '機　能：治具洗浄　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2010/04/27 (Tue) 13:45:22 T.Oide
    '備　考：
    '　　　：2010/04/27 (Tue) 12:40:26 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Private Sub cmdJigWash_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdJigWash.Click

        Dim lblnAns                     As Boolean
        Dim lprvJycJigListreq           As pubtypJycJigList
        Dim lstrFormName                As String
        Dim lstrEventName               As String
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得
            lstrFormName = Me.Name
            lstrEventName = "cmdUpdate_click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
        '@↓2010/04/27 (Tue) 15:02:38 T.Oide **************************************************
        '@    '@変更ﾃﾞｰﾀを構造体に格納
        '@    Call prvGetWashJycJigList_typ(lprvJycJigListreq, CMlngSenjyouCyu)

            '@変更ﾃﾞｰﾀを構造体に格納
            Call prvGetJycJigList_typ(lprvJycJigListreq, CMlngSenjyouCyu)
        '@↑2010/04/27 (Tue) 15:02:38 T.Oide **************************************************
            
            '@更新ﾒｯｾｰｼﾞ発行
            lblnAns = pubblnJycJigData_Upd(CMstrjig_chgjyc___Ver, lprvJycJigListreq)
            
            '@結果確認
            If lblnAns Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0071)
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
        '@↓2010/04/27 (Tue) 13:45:14 T.Oide **************************************************
                '@編集ﾌﾗｸﾞ初期化
                mblnToWashFlag = False
                mblnToWashCompFlag = False
                mblnJigDataEditFlag = False
        '@↑2010/04/27 (Tue) 13:45:14 T.Oide **************************************************
                
                '@再検索
                Call cmdNowList_Click(cmdNowList,New EventArgs)
                
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdNowList)
            
            End If

            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdJigWash_Click()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：cmdJJigWash_Click
    '機　能：蒸着治具洗浄　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub cmdJJigWash_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdJJigWash.Click

        Dim lblnAns                     As Boolean
        Dim lprvJJigListreq				As pubtypJJigList
        Dim lstrFormName                As String
        Dim lstrEventName               As String
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得
            lstrFormName = Me.Name
            lstrEventName = "cmdJJigWash_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)

            
			'@変更ﾃﾞｰﾀが正しいかﾁｪｯｸ
			if prvBlnJJigBtnData_Chk(CMstrCmbStatusWashingId) = False Then
				'@ステータスが不適な場合エラー表示
				'@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0187,CMstrCmbStatusNotUseNm)
                '@成功ﾒｯｾｰｼﾞ表示（<TRM183W>$$[%1]以外にﾁｪｯｸが入っているため処理できません。)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
				
				'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdJJigNowList)
			
				Exit Sub
			End If


            '@変更ﾃﾞｰﾀを構造体に格納
            Call prvGetJJigList_typ(lprvJJigListreq, CMstrCmbStatusWashingId, CMstrJigEventIdWash, CPstrFlagOff)

            
            '@更新ﾒｯｾｰｼﾞ発行
            lblnAns = pubblnJJigData_Upd(CMstrjig_chgjjigVer, lprvJJigListreq)
            
            '@結果確認
            If lblnAns Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0071)
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
   
                '@編集ﾌﾗｸﾞ初期化
				mblnJJigSelectFlag = False
                mblnJJigDataEditFlag = False

                
                '@再検索
                Call cmdJJigNowList_Click(cmdNowList,New EventArgs)
                
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdJJigNowList)
            
            End If

            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdJJigWash_Click()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2010/04/26 (Mon) 16:36:46 T.Oide **************************************************
    '関数名：cmdJigWashComp_Click()
    '機　能：洗浄中の治具を使用可に更新する
    '引　数：なし
    '戻り値：
    '作成日：2010/04/26 (Mon) 16:36:20 T.Oide
    '更新日：2010/04/26 (Mon) 16:36:20
    '備　考：
    Private Sub cmdJigWashComp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdJigWashComp.Click

        Dim lblnAns                     As Boolean
        Dim lprvJycJigListreq           As pubtypJycJigList
        Dim lstrFormName                As String
        Dim lstrEventName               As String
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得
            lstrFormName = Me.Name
            lstrEventName = "cmdJigWashComp_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@変更ﾃﾞｰﾀを変数に格納
            Call prvGetJycJigList_typ(lprvJycJigListreq, CMlngSiyouka)
            
            '@更新ﾒｯｾｰｼﾞ発行
            lblnAns = pubblnJycJigData_Upd(CMstrjig_chgjyc___Ver, lprvJycJigListreq)
            
            '@結果確認
            If lblnAns Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0074)
                '@成功ﾒｯｾｰｼﾞ表示（<TRM74I>$$治具洗浄を完了して、使用可になりました。)
                Call pubVsfInfo_Disp(pstrDMsg)
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@変更ﾌﾗｸﾞ初期化
                mblnToWashFlag = False
                mblnToWashCompFlag = False
                mblnJigDataEditFlag = False
                
                '@再表示
                Call cmdNowList_Click(cmdNowList,New EventArgs)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdNowList)
                
            End If
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdJigWashComp_Click()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdJJigWashComp_Click()
    '機　能：洗浄中の治具を使用可に更新する
    '引　数：なし
    '戻り値：
    '作成日：
    '更新日：
    '備　考：
    Private Sub cmdJJigWashComp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdJJigWashComp.Click

        Dim lblnAns                     As Boolean
        Dim lprvJJigListreq				As pubtypJJigList
        Dim lstrFormName                As String
        Dim lstrEventName               As String
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得
            lstrFormName = Me.Name
            lstrEventName = "cmdJJigWashComp_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)

			'@変更ﾃﾞｰﾀが正しいかﾁｪｯｸ
			if prvBlnJJigBtnData_Chk(CMstrCmbStatusRdyUseId) = False Then
				'@ステータスが不適な場合エラー表示
				'@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0187,CMstrCmbStatusWashingNm)
                '@成功ﾒｯｾｰｼﾞ表示（<TRM183W>$$[%1]以外にﾁｪｯｸが入っているため処理できません。)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
				
				'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdJJigNowList)
			
				Exit Sub
			End If

			'@変更ﾃﾞｰﾀを変数に格納
            Call prvGetJJigList_typ(lprvJJigListreq, CMlngSiyouka, CMstrJigEventIdWashComp, vbNullString)

            '@更新ﾒｯｾｰｼﾞ発行
            lblnAns = pubblnJJigData_Upd(CMstrjig_chgjjigVer, lprvJJigListreq)
            
            '@結果確認
            If lblnAns Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0074)
                '@成功ﾒｯｾｰｼﾞ表示（<TRM74I>$$治具洗浄を完了して、使用可になりました。)
                Call pubVsfInfo_Disp(pstrDMsg)
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@変更ﾌﾗｸﾞ初期化
                mblnJJigSelectFlag = False
                mblnJJigDataEditFlag = False
                
                '@再表示
                Call cmdJJigNowList_Click(cmdNowList,New EventArgs)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdJJigNowList)
                
            End If
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdJJigWashComp_Click()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '関数名：cmdNotUse_Click()
    '機　能：使用不可
    '引　数：なし
    '戻り値：
    '作成日：
    '更新日：
    '備　考：
    Private Sub cmdNotUse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNotUse.Click

        Dim lblnAns                     As Boolean
        Dim lprvJJigListreq				As pubtypJJigList
        Dim lstrFormName                As String
        Dim lstrEventName               As String
		Dim lstrTmpMsg					As String
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            


			'@作業者ｺｰﾄﾞ入力
			'@権限チェック
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing

             '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If


			'権限チェック
			if prvblnAuthority_Chk = False Then
				'権限なしの場合キャンセル
				Exit Sub
			End If


            '@ﾚｽﾎﾟﾝｽ取得
            lstrFormName = Me.Name
            lstrEventName = "cmdNotUse_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)

			'組立相手もﾁｪｯｸを入れる
			if prvSetGuideMaskChk() = False Then
				'見つからなかった場合エラー表示
				'@表示ﾒｯｾｰｼﾞ変換
    '            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0186)
    '            '@成功ﾒｯｾｰｼﾞ表示（<TRM182W>$$組立相手が見つかりませんでした。一覧に表示してください。)
    '            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
				'Exit Sub
			End If


			'@変更ﾃﾞｰﾀが正しいかﾁｪｯｸ
			if prvBlnJJigBtnData_Chk(CMstrCmbStatusNotUseId) = False Then
				'@ステータスが不適な場合エラー表示
				'@表示ﾒｯｾｰｼﾞ変換
				lstrTmpMsg = CMstrCmbStatusRdyUseNm & "(組前、組後含む)"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0187,lstrTmpMsg)
                '@成功ﾒｯｾｰｼﾞ表示（<TRM183W>$$[%1]以外にﾁｪｯｸが入っているため処理できません。)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
				
				'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdJJigNowList)
			
				Exit Sub
			End If
            
            '@変更ﾃﾞｰﾀを変数に格納
            Call prvGetJJigList_typ(lprvJJigListreq, CMlngSiyoufuka, CMstrJigEventIdNotUse, vbNullString)
            
            '@更新ﾒｯｾｰｼﾞ発行
            lblnAns = pubblnJJigData_Upd(CMstrjig_chgjjigVer, lprvJJigListreq)
            
            '@結果確認
            If lblnAns Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0086)
                '@成功ﾒｯｾｰｼﾞ表示（<TRM86I>$$治具を使用不可にしました。)
                Call pubVsfInfo_Disp(pstrDMsg)
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@変更ﾌﾗｸﾞ初期化
                mblnJJigSelectFlag = False
                mblnJJigDataEditFlag = False
                
                '@再表示
                Call cmdJJigNowList_Click(cmdJJigNowList,New EventArgs)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdJJigNowList)
                
            End If
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNotUse_Click()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

	'関数名：cmdScrap_Click()
    '機　能：使用不可の治具を廃却する
    '引　数：なし
    '戻り値：
    '作成日：
    '更新日：
    '備　考：
    Private Sub cmdScrap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdScrap.Click

        Dim lblnAns                     As Boolean
        Dim lprvJJigListreq				As pubtypJJigList
        Dim lstrFormName                As String
        Dim lstrEventName               As String
		Dim lstrTmpMsg					As String
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

			'@作業者ｺｰﾄﾞ入力
			'@権限チェック
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
			
			'権限チェック
			if prvblnAuthority_Chk = False Then
				'権限なしの場合キャンセル
				Exit Sub
			End If


            '@ﾚｽﾎﾟﾝｽ取得
            lstrFormName = Me.Name
            lstrEventName = "cmdScrap_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)

			'@変更ﾃﾞｰﾀが正しいかﾁｪｯｸ
			if prvBlnJJigBtnData_Chk(CMstrCmbStatusScrapId) = False Then
				'@ステータスが不適な場合エラー表示
				'@表示ﾒｯｾｰｼﾞ変換
				lstrTmpMsg = CMstrCmbStatusRdyUseNm & "(組前含む)," & CMstrCmbStatusNotUseNm
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0187,lstrTmpMsg)
                '@成功ﾒｯｾｰｼﾞ表示（<TRM183W>$$[%1]以外にﾁｪｯｸが入っているため処理できません。)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
				
				'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdJJigNowList)
			
				Exit Sub
			End If
            
            '@変更ﾃﾞｰﾀを変数に格納
            Call prvGetJJigList_typ(lprvJJigListreq, CMlngHaikyaku, CMstrJigEventIdScrap, vbNullString)
            
            '@更新ﾒｯｾｰｼﾞ発行
            lblnAns = pubblnJJigData_Upd(CMstrjig_chgjjigVer, lprvJJigListreq)
            
            '@結果確認
            If lblnAns Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0087)
                '@成功ﾒｯｾｰｼﾞ表示（<TRM87I>$$治具を廃却しました。)
                Call pubVsfInfo_Disp(pstrDMsg)
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@変更ﾌﾗｸﾞ初期化
                mblnJJigSelectFlag = False
                mblnJJigDataEditFlag = False
                
                '@再表示
                Call cmdJJigNowList_Click(cmdJJigNowList,New EventArgs)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdJJigNowList)
                
            End If
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdScrap_Click()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


	'関数名：cmdNextStockRdy_Click()
    '機　能：使用不可の治具を廃却する
    '引　数：なし
    '戻り値：
    '作成日：
    '更新日：
    '備　考：
    Private Sub cmdNextStockRdy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNextStockRdy.Click

        Dim lblnAns                     As Boolean
        Dim lprvJJigListreq				As pubtypJJigList
        Dim lstrFormName                As String
        Dim lstrEventName               As String
		Dim lstrTmpMsg					As String
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
			'@作業者ｺｰﾄﾞ入力
			'@権限チェック
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
			'@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            

            '@ﾚｽﾎﾟﾝｽ取得
            lstrFormName = Me.Name
            lstrEventName = "cmdNextStockRdy_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)

			'組立相手もﾁｪｯｸを入れる
			if prvSetGuideMaskChk() = False Then
				'見つからなかった場合エラー表示
				'@表示ﾒｯｾｰｼﾞ変換
    '            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0186)
    '            '@成功ﾒｯｾｰｼﾞ表示（<TRM182W>$$組立相手が見つかりませんでした。一覧に表示されているか確認してください。)
    '            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
				'Exit Sub
			End If

            
            '@変更ﾃﾞｰﾀを変数に格納
            Call prvGetJJigList_typ(lprvJJigListreq, vbNullString, vbNullString, CPstrFlagOn)
            
            '@更新ﾒｯｾｰｼﾞ発行
            lblnAns = pubblnJJigData_Upd(CMstrjig_chgjjigVer, lprvJJigListreq)
            
            '@結果確認
            If lblnAns Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006Z)
                '@成功ﾒｯｾｰｼﾞ表示（<TRM6ZI>$$治具情報が変更されました。)
                Call pubVsfInfo_Disp(pstrDMsg)
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@変更ﾌﾗｸﾞ初期化
                mblnJJigSelectFlag = False
                mblnJJigDataEditFlag = False
                
                '@再表示
                Call cmdJJigNowList_Click(cmdJJigNowList,New EventArgs)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdJJigNowList)
                
            End If
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNextStockRdy_Click()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：新規治具登録　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/28 (Thr) 17:06:25 K.Nishizawa
    '更新日：2009/05/28 (Thr) 17:06:25
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click, cmdJJigRegist.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
			'@呼び出し元を区別するために引継ぎ文字列設定
			If Me.ActiveControl.Name = cmdRegist.Name Then
				'平置き新規治具登録ボタンからの呼び出しの場合
				pstrJJigCategoryId = vbNullString
			Else If Me.ActiveControl.Name = cmdJJigRegist.Name
				'蒸着新規治具登録ボタンからの呼び出しの場合
				pstrJJigCategoryId = CMstrCmbJJigCategoryGuideId
			End If


            frmxxEN02D1.Instance = New frmxxEN02D1()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
            
                '@異常の場合は子画面終了
                frmxxEN02D1.Instance = Nothing
                Exit Sub
                
            End If
            
            '@治具ID初期化
            pstrJigID = vbNullString

            
            '@ﾌｫｰﾑ表示
            frmxxEN02D1.Instance.ShowDialog(Me)
            frmxxEN02D1.Instance = Nothing
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：prvCmbBox_Set
    '機　能：ｺﾝﾎﾞﾎﾞｯｸｽ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/26 (Tue) 13:26:21 K.Nishizawa
    '更新日：2013/04/17 (Wed) 12:10:27 T.Oide
    '備　考：
    Private Sub prvCmbBox_Set()

    '@↓2013/04/17 (Wed) 12:15:16 T.Oide **************************************************
        Dim llngCnt As Integer
    '@↑2013/04/17 (Wed) 12:15:16 T.Oide **************************************************

        Try
            
            '@治具ｸﾗｽｺﾝﾎﾞ設定
            With cmbJigClass
                .Clear
                .BackColor = SystemColors.Window
                .DirectInput = False
                .DispCols = CMlngCmbDispCols
                .GetCol = CMlngCmbGridColName
                .ValueCol = CMlngCmbGridColID
                
                '@選択ﾘｽﾄ設定
                .AddItem(CMstrCmbItemAll & vbTab & vbNullString)             'すべて
                .AddItem(CMstrJigClassJycNm & vbTab & CMstrJigClassJycId)    '蒸着
                .AddItem(CMstrJigClassHirNm & vbTab & CMstrJigClassHirId)    '平置

                
                '@ﾌｫﾝﾄｻｲｽﾞ設定、初期値設定
                .GridFont = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)
                .ListIndex = CMlngCmbListIndex
            End With
            
            '@ﾊﾟﾈﾙ区分ｺﾝﾎﾞ設定
            With cmbPanelKind
                .Clear
                .BackColor = SystemColors.Window
                .DirectInput = False
                .DispCols = CMlngCmbDispCols
                .GetCol = CMlngCmbGridColName
                .ValueCol = CMlngCmbGridColID
                .ListIndex = CMlngCmbListIndex
                

                .AddItem(CMstrCmbItemAll & vbTab & vbNullString)                     'すべて
                .AddItem(CMstrPanelKindTFTNm & vbTab & CMstrPanelKindTFTId)          'TFT
                .AddItem(CMstrPanelKindCFNm & vbTab & CMstrPanelKindCFId)            'CF(小板)
                .AddItem(CMstrPanelKindODFNm & vbTab & CMstrPanelKindODFId)          'CF(大板)
                .AddItem(CMstrPanelKindDummiyNm & vbTab & CMstrPanelKindDummiyId)    'ダミー
                
                '@ﾌｫﾝﾄｻｲｽﾞ設定、初期値設定
                .GridFont = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)
                .ListIndex = CMlngCmbListIndex
            End With
            
            
            
            '@ｽｸﾘｰﾝｻｲｽﾞｺﾝﾎﾞ設定
            With cmbScreenSize
                .Clear
                .BackColor = SystemColors.Window
                .DirectInput = False
                .DispCols = CMlngCmbDispCols
                .GetCol = CMlngCmbGridColName
                .ValueCol = CMlngCmbGridColID

                .AddItem(CMstrCmbItemAll & vbTab & vbNullString)             'すべて

                '@ｽｸﾘｰﾝｻｲｽﾞｺﾝﾎﾞにﾘｽﾄ設定
                If mtypScreenSizeList.lngScreenSizeListCnt <> 0 Then
                
                    '@取得数分繰り返し
                    For llngCnt = 0 To mtypScreenSizeList.lngScreenSizeListCnt -1
                        '@ｺﾝﾎﾞﾘｽﾄ追加
                        .AddItem(mtypScreenSizeList.typScreenList(llngCnt).strScreenSizeID & vbTab & _
                                 mtypScreenSizeList.typScreenList(llngCnt).strScreenSizeID)
                    Next

                End If
                
                '@ﾌｫﾝﾄｻｲｽﾞ設定、初期値設定
                .GridFont = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)
                .ListIndex = CMlngCmbListIndex
                
            End With
            


			'@蒸着治具ステータスコンボ設定
            With cmbJJigStatus
                .Clear
                .BackColor = SystemColors.Window
                .DirectInput = False
                .DispCols = CMlngCmbDispCols
                .GetCol = CMlngCmbGridColName
                .ValueCol = CMlngCmbGridColID
                
                '@選択ﾘｽﾄ設定
                .AddItem(CMstrCmbStatusAllExScrapNm & vbTab & CMstrCmbStatusAllExScrapId)             '廃却以外全て
                .AddItem(CMstrCmbStatusScrapNm & vbTab & CMstrCmbStatusScrapId)    '廃却
                .AddItem(CMstrCmbStatusRdyUseBeforeSetNm & vbTab & CMstrCmbStatusRdyUseBeforeSetId)    '使用可(組前)
				.AddItem(CMstrCmbStatusRdyUseAfterSetNm & vbTab & CMstrCmbStatusRdyUseAfterSetId)    '使用可(組後)
                .AddItem(CMstrCmbStatusRdyUseNm & vbTab & CMstrCmbStatusRdyUseId)    '使用可
				.AddItem(CMstrCmbStatusWashingNm & vbTab & CMstrCmbStatusWashingId)    '洗浄中
				.AddItem(CMstrCmbStatusUsingNm & vbTab & CMstrCmbStatusUsingSetId)    '使用中
				.AddItem(CMstrCmbStatusNotUseNm & vbTab & CMstrCmbStatusNotUseId)    '使用不可

                
                '@ﾌｫﾝﾄｻｲｽﾞ設定、初期値設定
                .GridFont = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)
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

    '関数名：prvvsfJycJigList_Init
    '機　能：平置き治具情報一覧初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/26 (Tue) 13:26:21 K.Nishizawa
    '更新日：2013/04/26 (Fri) 10:50:11 T.Oide
    '備　考：
    '　　　：2010/01/22 (Fri) 16:39:50 T.Oide       №03910対応(ｽｸﾘｰﾝｻｲｽﾞの手動変更対応)
    '　　　：2010/04/23 (Fri) 14:03:38 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Private Sub prvvsfJycJigList_Init()

        Try
            
            '@ｸﾞﾘｯﾄﾞ初期化
            With vsfJycJigList
            
                mblnEventCancelFlag = True

                .Clear(ClearFlags.Content)
                .Rows.Count = .Rows.Fixed
                .Cols.Count = CMlngvsfJycJigListColCnt
                .Cols.Frozen = CMlngvsfJycJigListJigClassIdCol
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngTitleRow, CMlngvsfJycJigListNoCol, CMstrvsfJycJigListColNo)                         '№
                .SetData(CMlngTitleRow, CMlngvsfJycJigListWashCol, CMstrvsfJycJigListColWash)                     '洗浄
                .SetData(CMlngTitleRow, CMlngvsfJycJigListJigIdCol, CMstrvsfJycJigListColJigId)                   '治具ID
                .SetData(CMlngTitleRow, CMlngvsfJycJigListJigStatusCol, CMstrvsfJycJigListColJigStatus)           'ｽﾃｰﾀｽ(ID)
                .SetData(CMlngTitleRow, CMlngvsfJycJigListJigStatusNmCol, CMstrvsfJycJigListColJigStatusNm)       'ｽﾃｰﾀｽ
                .SetData(CMlngTitleRow, CMlngvsfJycJigListJigClassIdCol, CMstrvsfJycJigListColJigClassId)         '治具識別
                .SetData(CMlngTitleRow, CMlngvsfJycJigListCarrieCategoryCol, CMstrvsfJycJigListColJigCategory)    '治具ｶﾃｺﾞﾘ(ID)
                .SetData(CMlngTitleRow, CMlngvsfJycJigListCarrieCategoryNCol, CMstrvsfJycJigListColJigCategoryN)  '治具ｶﾃｺﾞﾘ
                .SetData(CMlngTitleRow, CMlngvsfJycJigListpanelKindCol, CMstrvsfJycJigListColpanelKind)           'パネル識別
                .SetData(CMlngTitleRow, CMlngvsfJycJigListScreenSizeIdCol, CMstrvsfJycJigListColScreenSizeId)     'ｽｸﾘｰﾝｻｲｽﾞ
                .SetData(CMlngTitleRow, CMlngvsfJycJigListWashUseNumCol, CMstrvsfJycJigListColWashUseNum)         '洗浄後使用回数
                .SetData(CMlngTitleRow, CMlngvsfJycJigListWashUseLimitCol, CMstrvsfJycJigListColWashUseLimit)     '洗浄後上限回数
                .SetData(CMlngTitleRow, CMlngvsfJycJigListStartTimeCol, CMstrvsfJycJigListColStartTime)           '使用開始日時
                .SetData(CMlngTitleRow, CMlngvsfJycJigListCleanTimeCol, CMstrvsfJycJigListColCleanTime)           '最終洗浄日時
                .SetData(CMlngTitleRow, CMlngvsfJycJigListUseNumCol, CMstrvsfJycJigListColUseNum)                 '累積使用回数
                .SetData(CMlngTitleRow, CMlngvsfJycJigListUseLimitCol, CMstrvsfJycJigListColUseLimit)             '累積上限回数
                .SetData(CMlngTitleRow, CMlngvsfJycJigListEmpIdCol, CMstrvsfJycJigListColEmpId)                   '最終更新者(ID)
                .SetData(CMlngTitleRow, CMlngvsfJycJigListEmpNameCol, CMstrvsfJycJigListColEmpName)               '最終更新者
                .SetData(CMlngTitleRow, CMlngvsfJycJigListCommentsCol, CMstrvsfJycJigListColComments)             'ｺﾒﾝﾄ
                .SetData(CMlngTitleRow, CMlngvsfJycJigListUpdateFlag, CMstrvsfJycJigListColUpdateFlag)            '変更ﾌﾗｸﾞ
                
                '@隠しｶﾗﾑ設定
                .Cols(CMlngvsfJycJigListJigStatusCol).Visible = False                                           'ｽﾃｰﾀｽ(ID)
                .Cols(CMlngvsfJycJigListCarrieCategoryCol).Visible = False                                      '治具ｶﾃｺﾞﾘ(ID)
                .Cols(CMlngvsfJycJigListEmpIdCol).Visible = False                                               '最終更新者ID
                .Cols(CMlngvsfJycJigListUpdateFlag).Visible = False                                             '変更ﾌﾗｸﾞ
                
                '@幅変更ﾌﾗｸﾞがFalseの場合、幅を設定
                If Not mtypChgSort.blnChgWidth Then
                    .Cols(CMlngvsfJycJigListNoCol).Width = CMlngvsfJycJigListNoWidth                          '№
                    .Cols(CMlngvsfJycJigListWashCol).Width = CMlngvsfJycJigListWashWidth                      '洗浄
                    .Cols(CMlngvsfJycJigListJigIdCol).Width = CMlngvsfJycJigListJigIdWidth                    '治具ID
                    .Cols(CMlngvsfJycJigListJigStatusCol).Width = CMlngvsfJycJigListJigStatusWidth            'ｽﾃｰﾀｽ(ID)
                    .Cols(CMlngvsfJycJigListJigStatusNmCol).Width = CMlngvsfJycJigListJigStatusNmWidth        'ｽﾃｰﾀｽ
                    .Cols(CMlngvsfJycJigListJigClassIdCol).Width = CMlngvsfJycJigListJigClassWidth            '治具識別
                    .Cols(CMlngvsfJycJigListCarrieCategoryCol).Width = CMlngvsfJycJigListJigCategoryWidth     '治具ｶﾃｺﾞﾘ(ID)
                    .Cols(CMlngvsfJycJigListCarrieCategoryNCol).Width = CMlngvsfJycJigListJigCategoryNWidth   '治具ｶﾃｺﾞﾘ
                    .Cols(CMlngvsfJycJigListpanelKindCol).Width = CMlngvsfJycJigListpanelKindWidth            'パネル識別
                    .Cols(CMlngvsfJycJigListScreenSizeIdCol).Width = CMlngvsfJycJigListScreenSizeWidth        'ｽｸﾘｰﾝｻｲｽﾞ
                    .Cols(CMlngvsfJycJigListWashUseNumCol).Width = CMlngvsfJycJigListWashUseNumWidth          '洗浄後使用回数
                    .Cols(CMlngvsfJycJigListWashUseLimitCol).Width = CMlngvsfJycJigListWashUseLimitWidth      '洗浄後上限回数
                    .Cols(CMlngvsfJycJigListStartTimeCol).Width = CMlngvsfJycJigListStartTimeWidth            '使用開始日時
                    .Cols(CMlngvsfJycJigListCleanTimeCol).Width = CMlngvsfJycJigListCleanTimeWidth            '最終洗浄日時
                    .Cols(CMlngvsfJycJigListUseNumCol).Width = CMlngvsfJycJigListUseNumWidth                  '累積使用回数
                    .Cols(CMlngvsfJycJigListUseLimitCol).Width = CMlngvsfJycJigListUseLimitWidth              '累積上限回数
                    .Cols(CMlngvsfJycJigListEmpIdCol).Width = CMlngvsfJycJigListEmpIDWidth                    '最終更新者(ID)
                    .Cols(CMlngvsfJycJigListEmpNameCol).Width = CMlngvsfJycJigListEmpNameWidth                '最終更新者
                    .Cols(CMlngvsfJycJigListCommentsCol).Width = CMlngvsfJycJigListCommentsWidth              'ｺﾒﾝﾄ
                    .Cols(CMlngvsfJycJigListUpdateFlag).Width = CMlngvsfJycJigListUpdateFlagWidth             '変更ﾌﾗｸﾞ
                End If
                
            End With
            
            '変更ﾎﾞﾀﾝ初期化
            cmdUpdate.Enabled = False
            cmdJigWash.Enabled = False
            cmdJigWashComp.Enabled = False
            cmdRegist.Enabled = True

            '@画面および変数初期化
            txtComments.Enabled = False
            lblJigCnt.Text = vbNullString
            lblNowDate.Text = vbNullString
            mstrComments = vbNullString
            mblnEventCancelFlag = False
        '@↓2013/04/26 (Fri) 10:51:42 T.Oide **************************************************
            mblnToWashFlag = False
            mblnToWashCompFlag = False
            mblnJigDataEditFlag = False
        '@↑2013/04/26 (Fri) 10:51:42 T.Oide **************************************************
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfJycJigList_Init()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：prvvsfJJigList_Init
    '機　能：蒸着治具情報一覧初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    '　　　：
    Private Sub prvvsfJJigList_Init()

        Try
            
            '@ｸﾞﾘｯﾄﾞ初期化
            With vsfJJigList
            
                mblnEventCancelFlag = True

                .Clear(ClearFlags.Content)
                .Rows.Count = .Rows.Fixed
                .Cols.Count = CMlngvsfJJigListColCnt
                .Cols.Frozen = CMlngvsfJJigListJJigStatusIdCol
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngTitleRow, CMlngvsfJJigListNoCol, CMstrvsfJJigListColNo)							'№
                .SetData(CMlngTitleRow, CMlngvsfJJigListSelectCol, CMstrvsfJJigListColSelect)					'選択
                .SetData(CMlngTitleRow, CMlngvsfJJigListJigIdCol, CMstrvsfJJigListColJJigId)					'治具ID
                .SetData(CMlngTitleRow, CMlngvsfJJigListJJigStatusIdCol, CMstrvsfJJigListColJJigStatusId)       'ｽﾃｰﾀｽ(ID)
                .SetData(CMlngTitleRow, CMlngvsfJJigListJJigStatusNmCol, CMstrvsfJJigListColJJigStatusNm)       'ｽﾃｰﾀｽ
                .SetData(CMlngTitleRow, CMlngvsfJJigListPdIdCol, CMstrvsfJJigListColPdId)						'機種
                .SetData(CMlngTitleRow, CMlngvsfJJigListJJigCategoryIdCol, CMstrvsfJJigListColJJigCategoryId)   '治具ｶﾃｺﾞﾘ(ID)
                .SetData(CMlngTitleRow, CMlngvsfJJigListJJigCategoryNmCol, CMstrvsfJJigListColJJigCategoryNm)	'治具ｶﾃｺﾞﾘ
                .SetData(CMlngTitleRow, CMlngvsfJJigListSetGuideMaskCol, CMstrvsfJJigListSetGuideMaskId)        '組立相手
                .SetData(CMlngTitleRow, CMlngvsfJJigListSetEmpIdCol, CMstrvsfJJigListColSetEmpId)				'組立作業者(ID)
				.SetData(CMlngTitleRow, CMlngvsfJJigListSetEmpNameCol, CMstrvsfJJigListColSetEmpName)			'組立作業者
                .SetData(CMlngTitleRow, CMlngvsfJJigListWashUseNumCol, CMstrvsfJJigListColWashUseNum)			'洗浄後使用回数
				.SetData(CMlngTitleRow, CMlngvsfJJigListNextStockReadyFlagCol, CMstrvsfJJigListColNextStockReadyFlag)     '次回在庫準備
                .SetData(CMlngTitleRow, CMlngvsfJJigListWashUseLimitCol, CMstrvsfJJigListColWashUseLimit)		'洗浄後上限回数     
                .SetData(CMlngTitleRow, CMlngvsfJJigListStartTimeCol, CMstrvsfJJigListColStartTime)				'使用開始日時
                .SetData(CMlngTitleRow, CMlngvsfJJigListCleanTimeCol, CMstrvsfJJigListColCleanTime)				'最終洗浄日時      
                .SetData(CMlngTitleRow, CMlngvsfJJigListUseNumCol, CMstrvsfJJigListColUseNum)					'累積使用回数
				.SetData(CMlngTitleRow, CMlngvsfJJigListUseLimitCol, CMstrvsfJJigListColUseLimit)					'累積使用回数
                .SetData(CMlngTitleRow, CMlngvsfJJigListEmpIdCol, CMstrvsfJJigListColEmpId)						'最終更新者(ID)
                .SetData(CMlngTitleRow, CMlngvsfJJigListEmpNameCol, CMstrvsfJJigListColEmpName)					'最終更新者
                .SetData(CMlngTitleRow, CMlngvsfJJigListCommentsCol, CMstrvsfJJigListColComments)				'ｺﾒﾝﾄ
                .SetData(CMlngTitleRow, CMlngvsfJJigListUpdateFlag, CMstrvsfJJigListColUpdateFlag)				'変更ﾌﾗｸﾞ
                
                '@隠しｶﾗﾑ設定
                .Cols(CMlngvsfJJigListJJigStatusIdCol).Visible = False                                          'ｽﾃｰﾀｽ(ID)
                .Cols(CMlngvsfJJigListJJigCategoryIdCol).Visible = False										'治具ｶﾃｺﾞﾘ(ID)
                .Cols(CMlngvsfJJigListSetEmpIdCol).Visible = False												'蒸着マスク組立作業者
				.Cols(CMlngvsfJJigListEmpIdCol).Visible = False													'最終更新者ID
                .Cols(CMlngvsfJJigListUpdateFlag).Visible = False												'変更ﾌﾗｸﾞ
                
                '@幅変更ﾌﾗｸﾞがFalseの場合、幅を設定
                If Not mtypJJigChgSort.blnChgWidth Then
                    .Cols(CMlngvsfJJigListNoCol).Width = CMlngvsfJJigListNoWidth								'№
                    .Cols(CMlngvsfJJigListSelectCol).Width = CMlngvsfJJigListSelectWidth						'選択
                    .Cols(CMlngvsfJJigListJigIdCol).Width = CMlngvsfJJigListJJigIdWidth							'治具ID
                    .Cols(CMlngvsfJJigListJJigStatusIdCol).Width = CMlngvsfJJigListJJigStatusIdWidth            'ｽﾃｰﾀｽ(ID)
                    .Cols(CMlngvsfJJigListJJigStatusNmCol).Width = CMlngvsfJJigListJJigStatusNmWidth			'ｽﾃｰﾀｽ
                    .Cols(CMlngvsfJJigListPdIdCol).Width = CMlngvsfJJigListJJigPdIdWidth						'機種
                    .Cols(CMlngvsfJJigListJJigCategoryIdCol).Width = CMlngvsfJJigListJJigCategoryIdWidth		'治具ｶﾃｺﾞﾘ(ID)
                    .Cols(CMlngvsfJJigListJJigCategoryNmCol).Width = CMlngvsfJJigListJJigCategoryNmWidth		'治具ｶﾃｺﾞﾘ
                    .Cols(CMlngvsfJJigListSetGuideMaskCol).Width =  CMlngvsfJJigListSetGuideMaskWidth           '組立相手
                    .Cols(CMlngvsfJJigListSetEmpIdCol).Width = CMlngvsfJJigListSetEmpIdWidth					'蒸着マスク組立作業者
                    .Cols(CMlngvsfJJigListSetEmpNameCol).Width = CMlngvsfJJigListSetEmpNameWidth				'蒸着マスク組立作業者
                    .Cols(CMlngvsfJJigListWashUseNumCol).Width = CMlngvsfJJigListWashUseNumWidth				'洗浄後使用回数
                    .Cols(CMlngvsfJJigListWashUseLimitCol).Width = CMlngvsfJJigListWashUseLimitWidth            '洗浄後上限回数
					.Cols(CMlngvsfJJigListNextStockReadyFlagCol).Width = CMlngvsfJJigListNextStockReadyFlagWidth            '次回在庫準備
                    .Cols(CMlngvsfJJigListStartTimeCol).Width = CMlngvsfJJigListStartTimeWidth					'使用開始日時
                    .Cols(CMlngvsfJJigListCleanTimeCol).Width = CMlngvsfJJigListCleanTimeWidth					'最終洗浄日時
                    .Cols(CMlngvsfJJigListUseNumCol).Width = CMlngvsfJJigListUseNumWidth						'累積使用回数
					.Cols(CMlngvsfJJigListUseLimitCol).Width = CMlngvsfJJigListUseLimitWidth						'累積使用回数
                    .Cols(CMlngvsfJJigListEmpIdCol).Width = CMlngvsfJJigListEmpIDWidth							'最終更新者(ID)
                    .Cols(CMlngvsfJJigListEmpNameCol).Width = CMlngvsfJJigListEmpNameWidth						'最終更新者
                    .Cols(CMlngvsfJJigListCommentsCol).Width = CMlngvsfJJigListCommentsWidth					'ｺﾒﾝﾄ
                    .Cols(CMlngvsfJJigListUpdateFlag).Width = CMlngvsfJJigListUpdateFlagWidth					'変更ﾌﾗｸﾞ
                End If
                
            End With
            
            '変更ﾎﾞﾀﾝ初期化
            cmdJJigUpdate.Enabled = False
            cmdJJigWash.Enabled = False
            cmdJJigWashComp.Enabled = False
            cmdJJigRegist.Enabled = True
			cmdNotUse.Enabled = False
			cmdScrap.Enabled = False
			cmdJMaskSet.Enabled = True
			cmdNextStockRdy.Enabled = False

            '@画面および変数初期化
            txtJJigComments.Enabled = False
            lblJJigCnt.Text = vbNullString
            lblJJigNowDate.Text = vbNullString
            mstrJJigComments = vbNullString
            mblnEventCancelFlag = False
 
            mblnJJigToWashFlag = False
            mblnJJigToWashCompFlag = False
			mblnJJigSelectFlag = False
            mblnJJigDataEditFlag = False

            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfJJigList_Init()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfjycJigList_Disp
    '機　能：平置き治具情報一覧取得結果反映
    '引　数：平置き治具ﾘｽﾄ : pubtypJycJigList
    '戻り値：なし
    '作成日：2009/05/26 (Tue) 13:26:21 K.Nishizawa
    '更新日：2013/04/16 (Tue) 13:45:52 T.Oide
    '備　考：
    '　　　：2010/04/23 (Fri) 14:03:38 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    '　　　：2013/04/16 (Tue) 13:45:52 T.Oide       蒸着治具ODF対応
    Private Sub prvvsfJycJigList_Disp(ByRef ltypJycJigList As pubtypJycJigList)

        Dim llngRowCnt                  As Integer          'ｶｳﾝﾀ
        Dim llngCnt                     As Integer          'ｶｳﾝﾀ(構造体)
        Dim llngSCnt                    As Integer          'ｶｳﾝﾀ(ｿｰﾄ)

        Try
            
            '@変数初期化
            mstrComments = vbNullString
            
            vsfJycJigList.Redraw = False

            RemoveHandler vsfJycJigList.BeforeRowColChange,AddressOf vsfJycJigList_BeforeRowColChange
            RemoveHandler vsfJycJigList.EnterCell,AddressOf vsfJycJigList_EnterCell

            'ｸﾞﾘｯﾄﾞ初期化
            Call prvvsfJycJigList_Init()
            
            '@ﾃﾞｰﾀなしの場合は終了
            If ltypJycJigList.llngJigListCnt = 0 Then
                AddHandler vsfJycJigList.EnterCell,AddressOf vsfJycJigList_EnterCell
                AddHandler vsfJycJigList.BeforeRowColChange,AddressOf vsfJycJigList_BeforeRowColChange
                Exit Sub
            End If
            
            'ｸﾞﾘｯﾄﾞの設定
            With vsfJycJigList
                                
                .Rows.Count = ltypJycJigList.llngJigListCnt + 1
                
                '@治具ﾘｽﾄ分繰り返し
                For llngRowCnt = 1 To ltypJycJigList.llngJigListCnt
                    
                    '@ｸﾞﾘｯﾄﾞの各々の値を設定
                    .SetData(llngRowCnt, CMlngvsfJycJigListNoCol, llngCnt +1)                                                     '№
                    .SetCellCheck(llngRowCnt, CMlngvsfJycJigListWashCol, CheckEnum.Unchecked)                                     '洗浄ﾁｪｯｸ
                    .SetData(llngRowCnt, CMlngvsfJycJigListJigIdCol, ltypJycJigList.pubJycJigList(llngCnt).strjigId)              '治具ID
                    .SetData(llngRowCnt, CMlngvsfJycJigListJigStatusCol, ltypJycJigList.pubJycJigList(llngCnt).strjigStatus)      '治具ｽﾃｰﾀｽ(ID)
                    .SetData(llngRowCnt, CMlngvsfJycJigListJigStatusNmCol, ltypJycJigList.pubJycJigList(llngCnt).strjigStatusNm)  '治具ｽﾃｰﾀｽ
                    
                    '治具識別変換 "J"→"蒸着" "H"→"平置"
                    If ltypJycJigList.pubJycJigList(llngCnt).strjigClass = CMstrJigClassJycId Then
                        .SetData(llngRowCnt, CMlngvsfJycJigListJigClassIdCol, CMstrJigClassJycNm)
                    ElseIf ltypJycJigList.pubJycJigList(llngCnt).strjigClass = CMstrJigClassHirId Then
                        .SetData(llngRowCnt, CMlngvsfJycJigListJigClassIdCol, CMstrJigClassHirNm)
                    Else
                        .SetData(llngRowCnt, CMlngvsfJycJigListJigClassIdCol, CMstrListIsNull)
                    End If
                    
                    'ﾊﾟﾈﾙ区分変換 "T"→"TFT" "C"→"CF"
        '@↓2013/04/16 (Tue) 13:47:16 T.Oide **************************************************
        '@            If ltypJycJigList.pubJycJigList(llngCnt).strPanelKind = CMstrPanelKindTFTId Then
        '@                .Cell(flexcpText, llngRowCnt, CMlngvsfJycJigListpanelKindCol) = CMstrPanelKindTFTNm
        '@            ElseIf ltypJycJigList.pubJycJigList(llngCnt).strPanelKind = CMstrPanelKindCFId Then
        '@                .Cell(flexcpText, llngRowCnt, CMlngvsfJycJigListpanelKindCol) = CMstrPanelKindCFNm
        '@            Else
        '@                .Cell(flexcpText, llngRowCnt, CMlngvsfJycJigListpanelKindCol) = CMstrListIsNull
        '@            End If
        '@-----------------------------------------------------------------------------------------
                    Select Case ltypJycJigList.pubJycJigList(llngCnt).strPanelKind
                    
                        '@TFTの場合
                        Case CMstrPanelKindTFTId
                            .SetData(llngRowCnt, CMlngvsfJycJigListpanelKindCol, CMstrPanelKindTFTNm)
                            
                        '@CFの場合
                        Case CMstrPanelKindCFId
                            .SetData(llngRowCnt, CMlngvsfJycJigListpanelKindCol, CMstrPanelKindCFNm)
                            
                        '@ODFの場合
                        Case CMstrPanelKindODFId
                            .SetData(llngRowCnt, CMlngvsfJycJigListpanelKindCol, CMstrPanelKindODFNm)
                            
                        '@ダミーの場合
                        Case CMstrPanelKindDummiyId
                            .SetData(llngRowCnt, CMlngvsfJycJigListpanelKindCol, CMstrPanelKindDummiyNm)
                            
                        '@その他
                        Case Else
                            .SetData(llngRowCnt, CMlngvsfJycJigListpanelKindCol, CMstrListIsNull)
                            
                    End Select
        '@↑2013/04/16 (Tue) 13:46:59 T.Oide **************************************************
                    
                    .SetData(llngRowCnt, CMlngvsfJycJigListCarrieCategoryCol, ltypJycJigList.pubJycJigList(llngCnt).strCarrierCategoryId)                     'ｶﾃｺﾞﾘID
                    .SetData(llngRowCnt, CMlngvsfJycJigListCarrieCategoryNCol, ltypJycJigList.pubJycJigList(llngCnt).strcarrierCategoryNm)                    'ｶﾃｺﾞﾘ
                    .SetData(llngRowCnt, CMlngvsfJycJigListScreenSizeIdCol, ltypJycJigList.pubJycJigList(llngCnt).strScreenSize)                              'ｽｸﾘｰﾝｻｲｽﾞ
                    .SetData(llngRowCnt, CMlngvsfJycJigListWashUseNumCol, ltypJycJigList.pubJycJigList(llngCnt).strWashUseNum)                                '洗浄後使用回数
                    .SetData(llngRowCnt, CMlngvsfJycJigListWashUseLimitCol, ltypJycJigList.pubJycJigList(llngCnt).strWashUseLimit)                            '洗浄後上限回数
                    If IsDate(ltypJycJigList.pubJycJigList(llngCnt).strStartTime) Then                                                                        '使用開始日時
                        .SetData(llngRowCnt, CMlngvsfJycJigListStartTimeCol, Format$(CDate(ltypJycJigList.pubJycJigList(llngCnt).strStartTime), CPstrDateTimeY2MDHM))    
                    Else
                        .SetData(llngRowCnt, CMlngvsfJycJigListStartTimeCol, ltypJycJigList.pubJycJigList(llngCnt).strStartTime) 
                    End If
                    If IsDate(ltypJycJigList.pubJycJigList(llngCnt).strCleanTime) Then                                                                        '最終洗浄日時
                        .SetData(llngRowCnt, CMlngvsfJycJigListCleanTimeCol, Format$(CDate(ltypJycJigList.pubJycJigList(llngCnt).strCleanTime), CPstrDateTimeY2MDHM))    
                    Else
                        .SetData(llngRowCnt, CMlngvsfJycJigListCleanTimeCol, ltypJycJigList.pubJycJigList(llngCnt).strCleanTime)
                    End If
                    .SetData(llngRowCnt, CMlngvsfJycJigListUseNumCol, ltypJycJigList.pubJycJigList(llngCnt).strUseNum)                                        '累積使用回数
                    .SetData(llngRowCnt, CMlngvsfJycJigListUseLimitCol, ltypJycJigList.pubJycJigList(llngCnt).strUseLimit)                                    '累積上限回数
                    .SetData(llngRowCnt, CMlngvsfJycJigListEmpIdCol, ltypJycJigList.pubJycJigList(llngCnt).strEmpID)                                          '最終更新者(ID)
                    .SetData(llngRowCnt, CMlngvsfJycJigListEmpNameCol, ltypJycJigList.pubJycJigList(llngCnt).strEmpName)                                      '最終更新者
                    .SetData(llngRowCnt, CMlngvsfJycJigListCommentsCol, ltypJycJigList.pubJycJigList(llngCnt).strComments)                                    'コメント
                    .SetCellCheck(llngRowCnt, CMlngvsfJycJigListUpdateFlag, CheckEnum.Unchecked)                                                                      '編集ﾌﾗｸﾞ
                
                    llngCnt = llngCnt + 1
                Next
                
            End With
            
            '@ｿｰﾄｶｳﾝﾄは0より大きいか
            If mtypChgSort.lngCnt > 0 Then
                For llngSCnt = 0 To mtypChgSort.lngCnt -1

                    vsfJycJigList.Cols(mtypChgSort.typChgSortList(llngSCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngSCnt).lngOrder
                    vsfJycJigList.Sort(SortFlags.UseColSort, mtypChgSort.typChgSortList(llngSCnt).lngCol)

                Next llngSCnt
            End If
            
            AddHandler vsfJycJigList.EnterCell,AddressOf vsfJycJigList_EnterCell
            AddHandler vsfJycJigList.BeforeRowColChange,AddressOf vsfJycJigList_BeforeRowColChange

            '@ｿｰﾄｷｰはNULL以外か
            If mtypChgSort.strKey <> vbNullString Then
                For llngSCnt = vsfJycJigList.Rows.Fixed To vsfJycJigList.Rows.Count - 1
                    If vsfJycJigList.GetData(llngSCnt, CMlngvsfJycJigListJigIdCol) = mtypChgSort.strKey Then
                        vsfJycJigList.Row = llngSCnt
                        Call pubVsfBeforeSort(vsfJycJigList, CMlngvsfJycJigListJigIdCol)
                        Call pubVsfAfterSort(vsfJycJigList, CMlngvsfJycJigListJigIdCol,Nothing,Nothing,True,True,True,True,False)
                    Exit For
                    End If
                Next llngSCnt
            Else
                '@先頭ﾍﾟｰｼﾞ設定
                vsfJycJigList.TopRow = CMlngGridTitleRow
                '@ﾀｲﾄﾙ行に設定
                vsfJycJigList.Row = CMlngGridTitleRow
            End If
            
            If Not mtypChgSort.blnChgWidth Then
                vsfJycJigList.AutoSizeCol(CMlngvsfJycJigListJigIdCol, 6)
            End If
            
            '@ｸﾞﾘｯﾄﾞ表示後処理
            Call pubVsfDisp(vsfJycJigList)
            
            '再表示開始
            vsfJycJigList.Redraw = True

            '@ﾗﾍﾞﾙへのｾｯﾄ
            lblJigCnt.Text = ltypJycJigList.llngJigListCnt
            lblNowDate.Text = Format$(Now, CPstrDateFormat)
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfJycJigList_Disp()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfJJigList_Disp
    '機　能：蒸着治具情報一覧取得結果反映
    '引　数：蒸着治具ﾘｽﾄ : pubtypJJigList
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Sub prvvsfJJigList_Disp(ByRef ltypJJigList As pubtypJJigList)

        Dim llngRowCnt                  As Integer          'ｶｳﾝﾀ
        Dim llngCnt                     As Integer          'ｶｳﾝﾀ(構造体)
        Dim llngSCnt                    As Integer          'ｶｳﾝﾀ(ｿｰﾄ)

        Try
            
            '@変数初期化
            mstrComments = vbNullString
            
            vsfJJigList.Redraw = False

            RemoveHandler vsfJJigList.BeforeRowColChange,AddressOf vsfJJigList_BeforeRowColChange
            RemoveHandler vsfJJigList.EnterCell,AddressOf vsfJJigList_EnterCell

            'ｸﾞﾘｯﾄﾞ初期化
            Call prvvsfJJigList_Init()
            
            '@ﾃﾞｰﾀなしの場合は終了
            If ltypJJigList.llngJJigListCnt = 0 Then
                AddHandler vsfJJigList.EnterCell,AddressOf vsfJJigList_EnterCell
                AddHandler vsfJJigList.BeforeRowColChange,AddressOf vsfJJigList_BeforeRowColChange
				vsfJJigList.Redraw = True
                Exit Sub
            End If
            
            'ｸﾞﾘｯﾄﾞの設定
            With vsfJJigList
                                
                .Rows.Count = ltypJJigList.llngJJigListCnt + 1
                
                '@治具ﾘｽﾄ分繰り返し
                For llngRowCnt = 1 To ltypJJigList.llngJJigListCnt
                    
                    '@ｸﾞﾘｯﾄﾞの各々の値を設定
                    .SetData(llngRowCnt, CMlngvsfJJigListNoCol, llngCnt +1)                                                 '№
                    .SetCellCheck(llngRowCnt, CMlngvsfJJigListSelectCol, CheckEnum.Unchecked)                               '選択ﾁｪｯｸ
                    .SetData(llngRowCnt, CMlngvsfJJigListJigIdCol, ltypJJigList.pubJJigList(llngCnt).strJJigId)             '治具ID
                    .SetData(llngRowCnt, CMlngvsfJJigListJJigStatusIdCol, ltypJJigList.pubJJigList(llngCnt).strJJigStatusId) '治具ｽﾃｰﾀｽ(ID)

					'治具ステータス変換 "ガイドリングorマスク　かつ　0" → "使用可(組後)" "それ以外　→ "使用可"
					If ltypJJigList.pubJJigList(llngCnt).strJJigStatusId = CMstrCmbStatusRdyUseAfterSetId And _
						(ltypJJigList.pubJJigList(llngCnt).strJJigCategoryId = CMstrCmbJJigCategoryGuideId Or _
							ltypJJigList.pubJJigList(llngCnt).strJJigCategoryId = CMstrCmbJJigCategoryMaskId) Then
						.SetData(llngRowCnt, CMlngvsfJJigListJJigStatusNmCol, CMstrCmbStatusRdyUseAfterSetNm)
					Else
						.SetData(llngRowCnt, CMlngvsfJJigListJJigStatusNmCol, ltypJJigList.pubJJigList(llngCnt).strJJigStatusNm)

					End If


					.SetData(llngRowCnt, CMlngvsfJJigListPdIdCol, ltypJJigList.pubJJigList(llngCnt).strJJigPdId) '機種
                    .SetData(llngRowCnt, CMlngvsfJJigListJJigCategoryIdCol, ltypJJigList.pubJJigList(llngCnt).strJJigCategoryId)      'ｶﾃｺﾞﾘID

					'蒸着治具カテゴリ名変換&組立相手列統合
					if ltypJJigList.pubJJigList(llngCnt).strJJigCategoryId = CMstrCmbJJigCategoryGuideId Then
						'G→ガイドリング　組立相手→組立マスクID
						.SetData(llngRowCnt, CMlngvsfJJigListJJigCategoryNmCol, CMstrCmbJJigCategoryGuideNm)
						.SetData(llngRowCnt, CMlngvsfJJigListSetGuideMaskCol, ltypJJigList.pubJJigList(llngCnt).strSetMaskId)
					Else If ltypJJigList.pubJJigList(llngCnt).strJJigCategoryId = CMstrCmbJJigCategoryMaskId Then
						'M→マスク　組立相手→組立ガイドリングID
						.SetData(llngRowCnt, CMlngvsfJJigListJJigCategoryNmCol, CMstrCmbJJigCategoryMaskNm)
						.SetData(llngRowCnt, CMlngvsfJJigListSetGuideMaskCol, ltypJJigList.pubJJigList(llngCnt).strSetGuideId)
					Else If ltypJJigList.pubJJigList(llngCnt).strJJigCategoryId = CMstrCmbJJigCategoryHolderId Then
						.SetData(llngRowCnt, CMlngvsfJJigListJJigCategoryNmCol, CMstrCmbJJigCategoryHolderNm)
						'クライアントの表示上は無し
						.SetData(llngRowCnt, CMlngvsfJJigListSetGuideMaskCol, vbNullString)
					Else If ltypJJigList.pubJJigList(llngCnt).strJJigCategoryId = CMstrCmbJJigCategoryDummyId Then
						.SetData(llngRowCnt, CMlngvsfJJigListJJigCategoryNmCol, CMstrCmbJJigCategoryDummyNm)
						.SetData(llngRowCnt, CMlngvsfJJigListSetGuideMaskCol, vbNullString)
					End If

					.SetData(llngRowCnt, CMlngvsfJJigListSetEmpIdCol, ltypJJigList.pubJJigList(llngCnt).strSetEmpId)			  '作業者(ID)
					.SetData(llngRowCnt, CMlngvsfJJigListSetEmpNameCol, ltypJJigList.pubJJigList(llngCnt).strSetEmpName)		  '作業者(名)
                    .SetData(llngRowCnt, CMlngvsfJJigListWashUseNumCol, ltypJJigList.pubJJigList(llngCnt).strWashUseNum)          '洗浄後使用回数
                    .SetData(llngRowCnt, CMlngvsfJJigListWashUseLimitCol, ltypJJigList.pubJJigList(llngCnt).strWashUseLimit)      '洗浄後上限回数

					’次回在庫準備フラグ
					if ltypJJigList.pubJJigList(llngCnt).strNextStockReadyFlag = CPstrFlagOn Then
						.SetData(llngRowCnt, CMlngvsfJJigListNextStockReadyFlagCol, CMstrNextStockReady)
					Else 
						.SetData(llngRowCnt, CMlngvsfJJigListNextStockReadyFlagCol, vbNullString)
						'在庫準備フラグOFF　かつ　使用回数+10 >= 上限回数だった場合は,「使用回数」列の背景色を黄色にする
						if CLng(ltypJJigList.pubJJigList(llngCnt).strWashUseNum)+10 >= CLNG(ltypJJigList.pubJJigList(llngCnt).strWashUseLimit) Then
							Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorYellow")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorYellow)
                            Dim cellRange As CellRange = .GetCellRange(llngRowCnt, CMlngvsfJJigListWashUseNumCol)
                            cellRange.Style = newStyle
						End If
					End If

					If IsDate(ltypJJigList.pubJJigList(llngCnt).strStartTime) Then                                                                        '使用開始日時
                        .SetData(llngRowCnt, CMlngvsfJJigListStartTimeCol, Format$(CDate(ltypJJigList.pubJJigList(llngCnt).strStartTime), CPstrDateTimeY2MDHM))    
                    Else
                        .SetData(llngRowCnt, CMlngvsfJJigListStartTimeCol, ltypJJigList.pubJJigList(llngCnt).strStartTime) 
                    End If
					
					If IsDate(ltypJJigList.pubJJigList(llngCnt).strCleanTime) Then                                                                        '最終洗浄日時
						.SetData(llngRowCnt, CMlngvsfJJigListCleanTimeCol, Format$(CDate(ltypJJigList.pubJJigList(llngCnt).strCleanTime), CPstrDateTimeY2MDHM))
					Else
						.SetData(llngRowCnt, CMlngvsfJJigListCleanTimeCol, ltypJJigList.pubJJigList(llngCnt).strCleanTime)
					End If

					.SetData(llngRowCnt, CMlngvsfJJigListUseNumCol, ltypJJigList.pubJJigList(llngCnt).strUseNum)                                        '累積使用回数
					.SetData(llngRowCnt, CMlngvsfJJigListUseLimitCol, ltypJJigList.pubJJigList(llngCnt).strUseLimit)                                        '累積使用回数
                    .SetData(llngRowCnt, CMlngvsfJJigListEmpIdCol, ltypJJigList.pubJJigList(llngCnt).strEmpID)                                          '最終更新者(ID)
                    .SetData(llngRowCnt, CMlngvsfJJigListEmpNameCol, ltypJJigList.pubJJigList(llngCnt).strEmpName)                                      '最終更新者
                    .SetData(llngRowCnt, CMlngvsfJJigListCommentsCol, ltypJJigList.pubJJigList(llngCnt).strComments)                                    'コメント
                    .SetCellCheck(llngRowCnt, CMlngvsfJJigListUpdateFlag, CheckEnum.Unchecked)                                                                      '編集ﾌﾗｸﾞ
                
                    llngCnt = llngCnt + 1
                Next
                
            End With

			'@ｿｰﾄｶｳﾝﾄは0より大きいか
			If mtypJJigChgSort.lngCnt > 0 Then
				For llngSCnt = 0 To mtypJJigChgSort.lngCnt - 1

					vsfJJigList.Cols(mtypJJigChgSort.typChgSortList(llngSCnt).lngCol).Sort = mtypJJigChgSort.typChgSortList(llngSCnt).lngOrder
					vsfJJigList.Sort(SortFlags.UseColSort, mtypJJigChgSort.typChgSortList(llngSCnt).lngCol)

				Next llngSCnt
			End If

			AddHandler vsfJJigList.EnterCell, AddressOf vsfJJigList_EnterCell
			AddHandler vsfJJigList.BeforeRowColChange, AddressOf vsfJJigList_BeforeRowColChange

			'@ｿｰﾄｷｰはNULL以外か
			If mtypJJigChgSort.strKey <> vbNullString Then
				For llngSCnt = vsfJJigList.Rows.Fixed To vsfJJigList.Rows.Count - 1
					If vsfJJigList.GetData(llngSCnt, CMlngvsfJJigListJigIdCol) = mtypJJigChgSort.strKey Then
						vsfJJigList.Row = llngSCnt
						Call pubVsfBeforeSort(vsfJJigList, CMlngvsfJJigListJigIdCol)
						Call pubVsfAfterSort(vsfJJigList, CMlngvsfJJigListJigIdCol, Nothing, Nothing, True, True, True, True, False)
						Exit For
					End If
				Next llngSCnt
			Else
				'@先頭ﾍﾟｰｼﾞ設定
				vsfJJigList.TopRow = CMlngGridTitleRow
				'@ﾀｲﾄﾙ行に設定
				vsfJJigList.Row = CMlngGridTitleRow
			End If

			If Not mtypJJigChgSort.blnChgWidth Then
				vsfJJigList.AutoSizeCol(CMlngvsfJJigListJigIdCol, 6)
			End If

			'@ｸﾞﾘｯﾄﾞ表示後処理
			Call pubVsfDisp(vsfJJigList)

			'再表示開始
			vsfJJigList.Redraw = True

			'@ﾗﾍﾞﾙへのｾｯﾄ
			lblJJigCnt.Text = ltypJJigList.llngJJigListCnt
			lblJJigNowDate.Text = Format$(Now, CPstrDateFormat)

			Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfJJigList_Disp()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvGetJycJigList_typ
    '機　能：変更ﾌﾗｸﾞをﾁｪｯｸして、変更内容を配列に格納する
    '引　数：蒸着治具ﾘｽﾄ : pubtypJycJigList
    '引　数：更新ｽﾃｰﾀｽ：lstrStatus
    '戻り値：なし
    '作成日：2009/05/26 (Tue) 13:26:21 K.Nishizawa
    '更新日：2010/04/27 (Tue) 14:33:02 T.Oide
    '備　考：
    '　　　：2010/01/22 (Fri) 16:39:50 T.Oide       №03910対応(ｽｸﾘｰﾝｻｲｽﾞの手動変更対応) + ｿｰｽ整備
    '　　　：2010/04/26 (Mon) 13:35:24 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Private Sub prvGetJycJigList_typ(ByRef ltypJycJigListReq As pubtypJycJigList, _
                                     ByVal lstrStatus As String)
        
        Dim llngRowCnt              As Integer
        Dim llngCnt                 As Integer
        
        Try
            
            With vsfJycJigList
            
                If ltypJycJigListReq.pubJycJigList Is Nothing Then
                    ltypJycJigListReq.pubJycJigList = New List(Of JycJigList)
                Else
                    ltypJycJigListReq.pubJycJigList.Clear
                End If

                '@ｸﾞﾘｯﾄﾞの行数分ﾙｰﾌﾟ
                For llngRowCnt = 1 To .Rows.Count - 1

        '@↓2010/04/27 (Tue) 14:56:05 T.Oide **************************************************
        '@全体的に見直し実施

                    '@洗浄ﾁｪｯｸまたは変更ﾁｪｯｸはONか
                    If .GetCellCheck(llngRowCnt, CMlngvsfJycJigListWashCol) = CheckEnum.Checked Or _
                       .GetCellCheck(llngRowCnt, CMlngvsfJycJigListUpdateFlag) = CheckEnum.Checked Then
                        
                        '@配列の要素数定義
                        Dim pubJycJigListTmp As New JycJigList

                        '@配列へ変更内容を格納
                        pubJycJigListTmp.strjigId = _
                                    .GetData(llngRowCnt, CMlngvsfJycJigListJigIdCol)           '治具ID

                        '@ｽﾃｰﾀｽが空で無い場合はｾｯﾄ
                        If lstrStatus <> vbNullString Then
                            pubJycJigListTmp.strjigStatus = lstrStatus          'ｽﾃｰﾀｽ
                        End If

                        pubJycJigListTmp.strScreenSize = _
                                    .GetData(llngRowCnt, CMlngvsfJycJigListScreenSizeIdCol)    'ｽｸﾘｰﾝｻｲｽﾞ
                                    
                        pubJycJigListTmp.strCarrierCategoryId = _
                                    .GetData(llngRowCnt, CMlngvsfJycJigListCarrieCategoryCol)  'ｶﾃｺﾞﾘ

                        pubJycJigListTmp.strWashUseLimit = _
                                    .GetData(llngRowCnt, CMlngvsfJycJigListWashUseLimitCol)    '洗浄後上限回数

                        pubJycJigListTmp.strUseLimit = _
                                    .GetData(llngRowCnt, CMlngvsfJycJigListUseLimitCol)        '累積上限回数
                        
                        pubJycJigListTmp.strComments = _
                                    .GetData(llngRowCnt, CMlngvsfJycJigListCommentsCol)        'ｺﾒﾝﾄ

                        '@ｽﾃｰﾀｽが｢使用可｣の場合最終洗浄時刻を入れる(洗浄中→使用可にする場合)
                        If lstrStatus = CStr(CMlngSiyouka) Then
                            pubJycJigListTmp.strCleanTime = _
                                    Format$(Now, CPstrDateTimeYMDHMS)                                   '洗浄時間
                                    
                            pubJycJigListTmp.strWashUseNum = 0                                  '洗浄後使用回数
                            
                        End If
        '@↑2010/04/27 (Tue) 14:56:05 T.Oide **************************************************

                        ltypJycJigListReq.pubJycJigList.Add(pubJycJigListTmp)

                        llngCnt = llngCnt + 1

                        ltypJycJigListReq.llngJigListCnt = llngCnt

                    End If
                    
                Next
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGetJycJigList_typ()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

	'関数名：prvGetJJigList_typ
    '機　能：変更ﾌﾗｸﾞをﾁｪｯｸして、変更内容を配列に格納する
    '引　数：蒸着治具ﾘｽﾄ : pubtypJJigList
    '引　数：更新ｽﾃｰﾀｽ：lstrStatus
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Sub prvGetJJigList_typ(ByRef ltypJJigListReq As pubtypJJigList, _
                                     ByVal lstrStatus As String, _
									 ByVal lstrJigEventId As String, _
									ByVal lstrNextStockReadyFlag As String)
        
        Dim llngRowCnt              As Integer
        Dim llngCnt                 As Integer
        
        Try
            
            With vsfJJigList
            
                If ltypJJigListReq.pubJJigList Is Nothing Then
                    ltypJJigListReq.pubJJigList = New List(Of JJigList)
                Else
                    ltypJJigListReq.pubJJigList.Clear
                End If

                '@ｸﾞﾘｯﾄﾞの行数分ﾙｰﾌﾟ
                For llngRowCnt = 1 To .Rows.Count - 1

                    '@選択ﾁｪｯｸまたは変更ﾁｪｯｸはONか
                    If .GetCellCheck(llngRowCnt, CMlngvsfJJigListSelectCol) = CheckEnum.Checked Or _
                       .GetCellCheck(llngRowCnt, CMlngvsfJJigListUpdateFlag) = CheckEnum.Checked Then
                        
                        '@配列の要素数定義
                        Dim pubJJigListTmp As New JJigList

                        '@配列へ変更内容を格納
						'治具ID
                        pubJJigListTmp.strJJigId = .GetData(llngRowCnt, CMlngvsfJJigListJigIdCol)           

                        '@ｽﾃｰﾀｽが空で無い場合はｾｯﾄ(空の場合はステータス変更なし）
                        If lstrStatus <> vbNullString Then
							'受入ボタンからの呼び出し(ステータスが使用可)の場合かつガイドリングかマスクの場合はステータスを（組前）にする
							If lstrStatus = CStr(CMlngSiyouka) And _ 
								(.GetData(llngRowCnt, CMlngvsfJJigListJJigCategoryIdCol) = CMstrCmbJJigCategoryGuideId Or _
								 .GetData(llngRowCnt, CMlngvsfJJigListJJigCategoryIdCol) = CMstrCmbJJigCategoryMaskId) Then
								pubJJigListTmp.strJJigStatusId = CMlngSiyoukaKumimae
							Else
								'ｽﾃｰﾀｽ
								pubJJigListTmp.strJJigStatusId = lstrStatus          
							End If
                        End If
                        
						'蒸着治具ｶﾃｺﾞﾘ
                        pubJJigListTmp.strJJigCategoryId = .GetData(llngRowCnt, CMlngvsfJJigListJJigCategoryIdCol)  

						
						'組立相手
						If lstrStatus <> CStr(CMlngSiyoufuka) Then
							'使用不可以外の場合はそのまま
							pubJJigListTmp.strSetEmpId = .GetData(llngRowCnt, CMlngvsfJJigListSetEmpIdCol) 
							If .GetData(llngRowCnt, CMlngvsfJJigListJJigCategoryIdCol) = CMstrCmbJJigCategoryGuideId Then	
								'ガイドリングIDの場合
								'組立マスクIDを入れる
								pubJJigListTmp.strSetMaskId = .GetData(llngRowCnt, CMlngvsfJJigListSetGuideMaskCol) 
							Else If .GetData(llngRowCnt, CMlngvsfJJigListJJigCategoryIdCol) = CMstrCmbJJigCategoryMaskId Then
								'マスクIDの場合
								'組立ガイドリングIDを入れる
								pubJJigListTmp.strSetGuideId = .GetData(llngRowCnt, CMlngvsfJJigListSetGuideMaskCol)
							End If
						End If
                        
						'洗浄後上限回数
						pubJJigListTmp.strWashUseLimit = .GetData(llngRowCnt, CMlngvsfJJigListWashUseLimitCol)    
                        
						'ｺﾒﾝﾄ
                        pubJJigListTmp.strComments = .GetData(llngRowCnt, CMlngvsfJJigListCommentsCol)        

                        '@受入ボタンからの呼び出しの場合最終洗浄時刻を入れる(洗浄中→使用可にする場合)
						If lstrStatus <> vbNullString Then
							If lstrStatus = CStr(CMlngSiyouka) Then
								'洗浄時間
								pubJJigListTmp.strCleanTime = _
										Format$(Now, CPstrDateTimeYMDHMS)                                   
                     
								'洗浄後使用回数
								pubJJigListTmp.strWashUseNum = 0                                  
							End If
						End if

						'累積上限回数
						pubJJigListTmp.strUseLimit = .GetData(llngRowCnt, CMlngvsfJJigListUseLimitCol)  

						'@引数の次回在庫準備ﾌﾗｸﾞが空ではない場合
                        If lstrNextStockReadyFlag <> vbNullString Then
                            '次回在庫準備フラグを更新
							pubJJigListTmp.strNextStockReadyFlag = lstrNextStockReadyFlag
                        End If

						'@イベントIDが空で無い場合はｾｯﾄ
						If lstrJigEventId <> vbNullString Then
                            pubJJigListTmp.strJigEventId = lstrJigEventId
                        End If


                        ltypJJigListReq.pubJJigList.Add(pubJJigListTmp)

                        llngCnt = llngCnt + 1

                        ltypJJigListReq.llngJJigListCnt = llngCnt

                    End If
                    
                Next
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGetJJigList_typ()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：変更ﾃﾞｰﾀ収集
    '引　数：
    '戻り値：TRUE:成功 FALSE:失敗
    '作成日：2009/05/26 (Tue) 13:26:21 K.Nishizawa
    '更新日：2009/05/26 (Tue) 13:26:21 K.Nishizawa
    '備　考：
    Private Function prvblnInput_Chk(ByVal gridRow As Integer) As Boolean
        
        Try
            
            '@ﾁｪｯｸ結果を初期
            prvblnInput_Chk = False

            '@数値でなかったら異常
            With vsfJycJigList
            
                '@対象ｾﾙは空以外か
                If .GetData(gridRow, .Col) <> vbNullString Then
                
                    '@ｶﾗﾑによって処理分岐
                    Select Case .Col
                    
                        '@使用回数上限ｶﾗﾑの場合
                        Case CMlngvsfJycJigListUseLimitCol
                        
                            '@ｾﾙの値は数字以外、または、先頭が0ではないか
                            If (.GetData(gridRow, .Col) Like "*[!0-9]*") OrElse _
                                Strings.Left(.GetData(gridRow, .Col), 1) = 0 Then
                                
                                '@不正文字として検出
                                Exit Function
                                
                            End If
                            
                    End Select
                    
                End If
                
            End With
            
            '@ﾁｪｯｸOK
            prvblnInput_Chk = True
            
            Exit Function

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInput_Chk()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvblnJJigInput_Chk
    '機　能：変更ﾃﾞｰﾀ収集
    '引　数：
    '戻り値：TRUE:成功 FALSE:失敗
    '作成日：2009/05/26 (Tue) 13:26:21 K.Nishizawa
    '更新日：2009/05/26 (Tue) 13:26:21 K.Nishizawa
    '備　考：
    Private Function prvblnJJigInput_Chk(ByVal gridRow As Integer) As Boolean
        
        Try
            
            '@ﾁｪｯｸ結果を初期
            prvblnJJigInput_Chk = False

            '@数値でなかったら異常
            With vsfJJigList
            
                '@対象ｾﾙは空以外か
                If .GetData(gridRow, .Col) <> vbNullString Then
                
                    '@ｶﾗﾑによって処理分岐
                    Select Case .Col
                    
                        '@使用回数上限ｶﾗﾑの場合
                        Case CMlngvsfJJigListUseLimitCol, CMlngvsfJJigListWashUseLimitCol
                        
                            '@ｾﾙの値は数字以外、または、先頭が0ではないか
                            If (.GetData(gridRow, .Col) Like "*[!0-9]*") OrElse _
                                Strings.Left(.GetData(gridRow, .Col), 1) = 0 Then
                                
                                '@不正文字として検出
                                Exit Function
                                
                            End If
                            
                    End Select
                    
                End If
                
            End With
            
            '@ﾁｪｯｸOK
            prvblnJJigInput_Chk = True
            
            Exit Function

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnJJigInput_Chk()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvCmdButtonEnableChk
    '機　能：コマンドボタンの有効/無効を制御する
    '引　数：なし
    '戻り値：
    '作成日：2010/04/26 (Mon) 18:47:01 T.Oide
    '更新日：2010/04/26 (Mon) 18:59:48 T.Oide
    '備　考：
    Private Sub prvCmdButtonEnableChk()

        Try
            
            With vsfJycJigList

                '@治具ﾃﾞｰﾀ変更ﾎﾞﾀﾝﾁｪｯｸ
                '@編集ﾌﾗｸﾞはTrueか
                If mblnJigDataEditFlag = True Then
                
                    '@治具ﾃﾞｰﾀ"変更ボタン有効化
                    cmdUpdate.Enabled = True
                Else
                
                    '@治具ﾃﾞｰﾀ"変更ボタン無効化
                    cmdUpdate.Enabled = False
                End If
                
                
                '@洗浄ﾎﾞﾀﾝﾁｪｯｸ
                '@編集ﾌﾗｸﾞ(洗浄)はTrueか
                If mblnToWashFlag = True Then
                
                    '@洗浄ボタンを有効化
                    cmdJigWash.Enabled = True
                Else
                    
                    '@洗浄ボタン無効化
                    cmdJigWash.Enabled = False
                End If
                
                
                '@洗浄完了ﾎﾞﾀﾝﾁｪｯｸ
                '@編集ﾌﾗｸﾞ(洗浄完了)はTrueか
                If mblnToWashCompFlag = True Then
                
                    '@洗浄完了ﾎﾞﾀﾝを有効化
                    cmdJigWashComp.Enabled = True
                Else
                    
                    '@洗浄完了ﾎﾞﾀﾝ無効化
                    cmdJigWashComp.Enabled = False
                End If
                
                '@新規治具登録ﾎﾞﾀﾝﾁｪｯｸ
                '@編集ﾌﾗｸﾞ×3つは全てFlaseか
                If mblnToWashFlag = False And _
                   mblnToWashCompFlag = False And _
                   mblnJigDataEditFlag = False Then
                
                    '@新規治具登録ﾎﾞﾀﾝを有効化
                    cmdRegist.Enabled = True
                Else
                    
                    '@新規治具登録ﾎﾞﾀﾝ無効化
                    cmdRegist.Enabled = False
                End If
            
            End With


			With vsfJJigList
				'@治具ﾃﾞｰﾀ変更ﾎﾞﾀﾝﾁｪｯｸ
                '選択ﾌﾗｸﾞ　編集ﾌﾗｸﾞ　どちらもOFF
                If mblnJJigDataEditFlag = False And mblnJJigSelectFlag = False Then

                    '@ボタン無効化
					cmdJJigUpdate.Enabled = False
                    cmdJJigWash.Enabled = False
					cmdJJigWashComp.Enabled = False
					cmdNotUse.Enabled = False
					cmdScrap.Enabled = False
					cmdNextStockRdy.Enabled = False
					'@新規登録有効化
					cmdJJigRegist.Enabled = True
					'@コメント欄有効化
					txtJJigComments.Enabled = True

                Else if  mblnJJigSelectFlag = True And mblnJJigDataEditFlag = False Then
					'選択ﾌﾗｸﾞ　のみON
					cmdJJigUpdate.Enabled = False			'治具データ変更
                    cmdJJigWash.Enabled = True				'洗浄
					cmdJJigWashComp.Enabled = True			'受入
					cmdNotUse.Enabled = True				'使用不可
					cmdScrap.Enabled = True					'廃却
					cmdNextStockRdy.Enabled = True			'次回在庫準備
					cmdJJigRegist.Enabled = False			'新規登録
					'@コメント欄無効
					txtJJigComments.Enabled = False

				Else if  mblnJJigSelectFlag = False And mblnJJigDataEditFlag = True Then
					'編集ﾌﾗｸﾞ　のみON
					cmdJJigUpdate.Enabled = True				'治具データ変更
                    cmdJJigWash.Enabled = False				'洗浄
					cmdJJigWashComp.Enabled = False			'受入
					cmdNotUse.Enabled = False				'使用不可
					cmdScrap.Enabled = False				'廃却
					cmdNextStockRdy.Enabled = False			'次回在庫準備
					cmdJJigRegist.Enabled = False			'新規登録
					'@コメント欄有効
					txtJJigComments.Enabled = True
				Else 
					'両方ONの場合
					cmdJJigUpdate.Enabled = True			'治具データ変更
                    cmdJJigWash.Enabled = False				'洗浄
					cmdJJigWashComp.Enabled = False			'受入
					cmdNotUse.Enabled = False				'使用不可
					cmdScrap.Enabled = False				'廃却
					cmdNextStockRdy.Enabled = False			'次回在庫準備
					cmdJJigRegist.Enabled = False			'新規登録
					'@コメント欄有効
					txtJJigComments.Enabled = True

                End If
                

			End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdButtonEnableChk()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '関数名：prvFlagChk
    '機　能：編集ﾌﾗｸﾞ(洗浄)をﾘｾｯﾄするか判定
    '引　数：llngChkFlag(1:mblnToWashFlag 2:mblnToWashCompFlag)
    '戻り値：
    '作成日：2010/04/27 (Tue) 10:21:06 T.Oide
    '更新日：2010/04/27 (Tue) 10:21:06
    '備　考：
    Private Sub prvWashFlagChk(ByVal llngChkFlag As Integer)

        Dim llngRowCnt      As Integer
        Dim lblnChkFlag     As Boolean

        Try
            
            lblnChkFlag = False
            
            '@ｸﾞﾘｯﾄﾞ行分ﾙｰﾌﾟして1件でも洗浄のﾁｪｯｸがONなら｢治具洗浄｣ボタンを有効にする
            For llngRowCnt = 1 To vsfJycJigList.Rows.Count - 1
            
                '@ﾁｪｯｸはONか
                If vsfJycJigList.GetCellCheck(llngRowCnt, CMlngvsfJycJigListWashCol) = CheckEnum.Checked Then
                    
                    '@1つでもﾁｪｯｸがあればﾌﾗｸﾞを1にして終了
                    lblnChkFlag = True
                    Exit For
                        
                End If
            Next
            
            '@ﾁｪｯｸﾌﾗｸﾞはFalseのままか(1つもﾁｪｯｸがない)
            If lblnChkFlag = False Then
            
                '@どちらのﾌﾗｸﾞをﾘｾｯﾄするか引数で分ける
                Select Case llngChkFlag
                
                    Case 1
                        '@編集ﾌﾗｸﾞ(洗浄)をｾｯﾄ
                        mblnToWashFlag = False
                
                    Case 2
                        '@編集ﾌﾗｸﾞ(洗浄完)をｾｯﾄ
                        mblnToWashCompFlag = False
                
                End Select
            
            End If
            
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWashFlagChk()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：prvJJigFlagChk
    '機　能：編集ﾌﾗｸﾞをﾘｾｯﾄするか判定
    '引　数：llngChkFlag(1:mblnJJigSelectFlag)
    '戻り値：
    '作成日：2010/04/27 (Tue) 10:21:06 T.Oide
    '更新日：2010/04/27 (Tue) 10:21:06
    '備　考：
    Private Sub prvJJigFlagChk(ByVal llngChkFlag As Integer)

        Dim llngRowCnt      As Integer
        Dim lblnChkFlag     As Boolean

        Try
            
            lblnChkFlag = False
            
            '@ｸﾞﾘｯﾄﾞ行分ﾙｰﾌﾟして1件でも洗浄のﾁｪｯｸがONならボタンを有効にする
            For llngRowCnt = 1 To vsfJJigList.Rows.Count - 1
            
                '@ﾁｪｯｸはONか
                If vsfJJigList.GetCellCheck(llngRowCnt, CMlngvsfJJigListSelectCol) = CheckEnum.Checked Then
                    
                    '@1つでもﾁｪｯｸがあればﾌﾗｸﾞを1にして終了
                    lblnChkFlag = True
                    Exit For
                        
                End If
            Next

            
            '@ﾁｪｯｸﾌﾗｸﾞはFalseのままか(1つもﾁｪｯｸがない)
            If lblnChkFlag = False Then
            
                '@どちらのﾌﾗｸﾞをﾘｾｯﾄするか引数で分ける
                Select Case llngChkFlag
                
                    Case 1
                        '@選択ﾌﾗｸﾞをﾘｾｯﾄ
                        mblnJJigSelectFlag = False

                End Select
            
            End If
            
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvJJigFlagChk()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvChkEdit
    '機　能：編集中か確認して編集中ならメッセージ表示
    '引　数：なし
    '戻り値：True：編集中止OK(編集なし)、False：編集中止NG
    '作成日：2013/04/26 (Fri) 10:17:49 T.Oide
    '更新日：2013/04/26 (Fri) 10:cmdJigWash17:49
    '備　考：
    Private Function prvChkEdit() As Boolean

        Dim llngAns     As Integer

        Try
            
            '@編集なし、又は、編集中止OK
            prvChkEdit = True

            '@編集中か
            If mblnToWashFlag = True Or _
               mblnToWashCompFlag = True Or _
               mblnJigDataEditFlag = True Or _
			   mblnJJigDataEditFlag = True Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)

                '@"編集中です。 内容を破棄してよろしいですか？"
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                
                '@要求確認
                If llngAns = vbNo Then
                
                    '@編集中止NG
                    prvChkEdit = False
                    
                    '@装置ﾃﾞｰﾀﾘｽﾄにﾌｫｰｶｽｾｯﾄ
                    'Call pubSetFocus(vsfJycJigList)
                    
                    Exit Function
                End If
                
            End If
            
            Exit Function

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvChkEdit"
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) 

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

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
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) 

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
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) 

        Try
            If TypeOf sender.Editor Is ComboBox
                '行の高さを変更
                Dim editor As ComboBox = CType(sender.Editor, ComboBox)
                editor.DrawMode = DrawMode.OwnerDrawFixed
                editor.DropDownHeight = 106
                editor.MaxDropDownItems = 12
            End If

        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try

    End Sub

	'関数名：prvblnJJigBtnData_Chk
    '機　能：各ボタン処理前ﾃﾞｰﾀﾁｪｯｸ
    '引　数：
    '戻り値：TRUE:成功 FALSE:失敗
    '作成日：
    '更新日：
    '備　考：
    Private Function prvblnJJigBtnData_Chk(ByVal lstrStatus As String) As Boolean
        
        Dim llngRowCnt              As Integer
        Dim llngCnt                 As Integer
        
        Try

			prvblnJJigBtnData_Chk = False
            
           With vsfJJigList



                '@ｸﾞﾘｯﾄﾞの行数分ﾙｰﾌﾟ
                For llngRowCnt = 1 To .Rows.Count - 1
					
					If .GetCellCheck(llngRowCnt, CMlngvsfJJigListSelectCol) = CheckEnum.Checked Then

						Select Case lstrStatus
							'洗浄ボタン押下時ﾁｪｯｸ
							Case CMstrCmbStatusWashingId
								if .GetData(llngRowCnt,CMlngvsfJJigListJJigStatusIdCol) <> CMstrCmbStatusNotUseId Then
									'ステータスが使用不可以外のものがあればNGで返却
									prvblnJJigBtnData_Chk = False
									Return prvblnJJigBtnData_Chk
								End If

							'受入ボタン押下時ﾁｪｯｸ
							Case CMstrCmbStatusRdyUseId
								'洗浄中か確認
								if .GetData(llngRowCnt,CMlngvsfJJigListJJigStatusIdCol) <> CMstrCmbStatusWashingId Then
									'ステータスが洗浄中以外のものがあればNGで返却
									prvblnJJigBtnData_Chk = False
									Return prvblnJJigBtnData_Chk
								End If
                    	
							'使用不可ボタン押下時ﾁｪｯｸ
							Case CMstrCmbStatusNotUseId
								'「使用可(組前)」「使用可（組後）」「使用可」か確認
								if .GetData(llngRowCnt,CMlngvsfJJigListJJigStatusIdCol) <> CMstrCmbStatusRdyUseId And .GetData(llngRowCnt,CMlngvsfJJigListJJigStatusIdCol) <> CMstrCmbStatusRdyUseBeforeSetId Then
									'ステータスが洗浄中以外のものがあればNGで返却
									prvblnJJigBtnData_Chk = False
									Return prvblnJJigBtnData_Chk
								End If

							'廃却ボタン押下時ﾁｪｯｸ
							Case CMstrCmbStatusScrapId
								'「使用可」「使用可(組前)」「使用不可」か確認
								if .GetData(llngRowCnt,CMlngvsfJJigListJJigStatusIdCol) <> CMstrCmbStatusNotUseId And _
									.GetData(llngRowCnt,CMlngvsfJJigListJJigStatusIdCol) <> CMstrCmbStatusRdyUseBeforeSetId And _
									.GetData(llngRowCnt,CMlngvsfJJigListJJigStatusNmCol) <> CMstrCmbStatusRdyUseNm Then				'「使用可」のみ名前で確認
									'ステータスが洗浄中以外のものがあればNGで返却
									prvblnJJigBtnData_Chk = False
									Return prvblnJJigBtnData_Chk
								End If


						End Select

					
					End If

                Next



			End With 
			'NG無く処理を抜けられればOK
			prvblnJJigBtnData_Chk = True


                
            Return prvblnJJigBtnData_Chk
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGetJJigList_typ()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

			prvblnJJigBtnData_Chk = False
			return prvblnJJigBtnData_Chk
            
        End Try
    End Function

	Private Sub txtPdId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPdId.KeyPress
        Try

            '@全角の入力を制御(記号可)
            Select Case Asc(e.KeyChar)
                '@0～9、A～Z、ﾊﾞｯｸｽﾍﾟｰｽ　入力可
                Case CPlngKeyAsciiNum0 To CPlngKeyAsciiNum9, _
                     CPlngKeyAsciiUppA To CPlngKeyAsciiUppZ, _
                     CPlngKeyAsciiLowA To CPlngKeyAsciiLowZ, _
                     CPlngKeyBackSpace

					'@ｸﾞﾘｯﾄﾞの初期化
					Call prvvsfJJigList_Init()

                Case CPlngKeyReturn
                    '最新情報取得
                     Call cmdJJigNowList_Click(cmdJJigNowList,New EventArgs)

                '@それ以外は入力不可
                Case Else
                    e.Handled = True 'ｷｰ無効
            End Select

            Exit Sub
            
        Catch ex As Exception
            
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey   
                .strProcName = "txtPdId_KeyPress" 
                .strErrMessage = ""                 
            End With

            Call pubOnError_Proc()
        End Try
    End Sub

	Private Sub txtBcrRead_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBcrRead.KeyPress
        Try

            '@全角の入力を制御(記号可)
            Select Case Asc(e.KeyChar)
                '@0～9、A～Z、ﾊﾞｯｸｽﾍﾟｰｽ　入力可
                Case CPlngKeyAsciiNum0 To CPlngKeyAsciiNum9, _
                     CPlngKeyAsciiUppA To CPlngKeyAsciiUppZ, _
                     CPlngKeyAsciiLowA To CPlngKeyAsciiLowZ, _
                     CPlngKeyBackSpace

                Case CPlngKeyReturn
                    '@=======================
                    '@ BCR蒸着治具IDValidateｲ処理
                    '@=======================
                    RemoveHandler txtBcrRead.Validating,AddressOf txtBcrRead_Validate
                    Call txtBcrRead_Validate(sender,New CancelEventArgs(True))
                    AddHandler txtBcrRead.Validating,AddressOf txtBcrRead_Validate

                '@それ以外は入力不可
                Case Else
                    e.Handled = True 'ｷｰ無効
            End Select

            Exit Sub
            
        Catch ex As Exception
            
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey   
                .strProcName = "txtPdId_KeyPress" 
                .strErrMessage = ""                 
            End With

            Call pubOnError_Proc()
        End Try
    End Sub


	'関数名：txtBcrId_Validate
    '機　能：BCR読み取りValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Public Sub txtBcrRead_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtBcrRead.Validating

        Dim lblnFind                As Boolean              '検索結果(True:正常,False:存在せず)
        Dim lstrJigId				As String				'読み取った蒸着治具ID
		Dim llngRowCnt				As Integer				'ｶｳﾝﾄ
		Dim lstrNowActiveControlName As String
        Try
            
            '@空ENTERの場合は何もしない
            If Trim(txtBcrRead.Text) = vbNullString Then
                Exit Sub
            End If

            '@10桁ﾁｪｯｸ
            If txtBcrRead.NowByte < txtBcrRead.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009O)
                '@"治具IDは10桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                e.Cancel = True
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtBcrRead)
                
                Exit Sub
            End If

			'その他の操作をした場合は処理を抜ける
            lstrNowActiveControlName = ActiveControl.Name
            If lstrNowActiveControlName <> txtBcrRead.Name Then
				Exit Sub
            End If

            
            '@ﾌﾗｸﾞ判定開始(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            mblnValidateFlag = False
            
			lstrJigId = txtBcrRead.Text
			lblnFind = false

			'蒸着治具一覧から入力された治具IDと同じ治具を検索
			With vsfJJigList
			    '@ｸﾞﾘｯﾄﾞの行数分ﾙｰﾌﾟ
                For llngRowCnt = 1 To .Rows.Count - 1

                    '@見つかったか
                    If .GetData(llngRowCnt, CMlngvsfJJigListJigIdCol) = lstrJigId Then

						'@見つかった場合
						'スクロール位置設定
						mobjScrollPos = llngRowCnt
						lblnFind = true

						If .GetCellCheck(llngRowCnt, CMlngvsfJJigListSelectCol) = CheckEnum.UnChecked Then
							'ﾁｪｯｸが入っていなかったら入れる
							.SetCellCheck(llngRowCnt, CMlngvsfJJigListSelectCol,CheckEnum.Checked)
							'選択ﾌﾗｸﾞをONに
							mblnJJigSelectFlag = true
							Exit For
						Else
							'ﾁｪｯｸがついていたら外す
							.SetCellCheck(llngRowCnt, CMlngvsfJJigListSelectCol,CheckEnum.UnChecked)
							'@選択フラグをﾘｾｯﾄするか判定
                            Call prvJJigFlagChk(1)
							Exit For
						End If
                        
                    End If
						

				Next

			End With

			'見つからなかった場合
			if lblnFind = False
				'@表示ﾒｯｾｰｼﾞ変換
				pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0185)
				'@"入力された治具IDが見つかりませんでした。"
				Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
				e.Cancel = True
				'@ﾌｫｰｶｽｾｯﾄ　連続でスキャンできるようにする
				Call pubSetFocus(txtBcrRead)
				'@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
				mblnValidateFlag = True
				Exit Sub
			End If

			'@ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
            Call prvCmdButtonEnableChk()

			With vsfJJigList
				If mobjScrollPos < .TopRow  Or .BottomRow < mobjScrollPos Then
					'画面外の場合はスクロール位置変更
					.TopRow = mobjScrollPos
				End If
				'スクロールせずに見える範囲にあった場合は何もしない
			End With

			'@ﾌｫｰｶｽｾｯﾄ　連続でスキャンできるようにする
			Call pubSetFocus(txtBcrRead)

            '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            mblnValidateFlag = True
            
            Exit Sub

        Catch ex As Exception
            
            '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            mblnValidateFlag = True
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtBcrRead_Validate"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


	'関数名：prvSetGuideMaskChk
    '機　能：使用不可押下時に組相手もﾁｪｯｸ対象にする
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Function  prvSetGuideMaskChk() As Boolean
        
        Dim llngRowCnt              As Integer
        Dim llngCnt                 As Integer

        prvSetGuideMaskChk = True

        Try
            
            With vsfJJigList
            

                '@ｸﾞﾘｯﾄﾞの行数分ﾙｰﾌﾟ
                For llngRowCnt = 1 To .Rows.Count - 1

                    '@選択ﾁｪｯｸはONか
                    If .GetCellCheck(llngRowCnt, CMlngvsfJJigListSelectCol) = CheckEnum.Checked Then
						'組立相手がnullじゃない
						if .GetData(llngRowCnt, CMlngvsfJJigListSetGuideMaskCol)  <> vbNullString　Then   
							
							'組立相手治具ID取得
							Dim lstrSetJigId = .GetData(llngRowCnt, CMlngvsfJJigListSetGuideMaskCol)
							'ﾌﾗｸﾞ設定
							Dim lblnFindFlag = false

							'見つかったら最初から全検索してﾁｪｯｸが入ってなかったらﾁｪｯｸを入れる
							For llngCnt = 1 To .Rows.Count - 1
								If .GetData(llngCnt, CMlngvsfJJigListJigIdCol) = lstrSetJigId Then
									'発見ﾌﾗｸﾞをTrueに設定
									lblnFindFlag = true
								    If .GetCellCheck(llngCnt, CMlngvsfJJigListSelectCol) = CheckEnum.UnChecked Then
										.SetCellCheck(llngCnt, CMlngvsfJJigListSelectCol,  CheckEnum.Checked)
										Exit For
									Else
										'既にﾁｪｯｸが入っていたら処理を抜ける
										Exit For
									End If
								End If
							Next

							'一度でも見つからないことがあれば結果はFalseを返す
							If lblnFindFlag = False Then
								prvSetGuideMaskChk =  False
							End If


						End If
					End If
 
                Next
                
            End With

			Return prvSetGuideMaskChk
            
            Exit Function
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSetGuideMaskChk()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try

    End Function

	'関数名：prvblnAuthority_Chk
    '機　能：権限ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Function prvblnAuthority_Chk() As Boolean

        Dim lblnAns                 As Boolean              '戻り値判定用
        Dim lstrFunctionID          As String               '機能ID
        Dim lstrActionID            As String               'ｱｸｼｮﾝID
        Dim lstrEmpID               As String               '作業者ID
        Dim lstrEmpName             As String               '作業者名
        Dim lstrSBID                As String               'ｼｽﾃﾑﾌﾞﾛｯｸ

        Try
                    
            '@戻り値の初期化
            prvblnAuthority_Chk = False

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor
                

                Exit Function
            End If
            
            
            Me.KeyPreview = False
            
            
            '@実行権限の処理を追加
            lstrFunctionID = CPstrKeyEN02D0             '機能ID：EN02D0
            lstrActionID = CPstrNotUseScrap				'ｱｸｼｮﾝID：使用不可/廃却
            lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
            lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
            lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                
            '@=======================
            '@ 実行権限ﾁｪｯｸ
            '@=======================
            lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                        lstrActionID, _
                                        lstrEmpID, _
                                        lstrEmpName, _
                                        lstrSBID)
                
            Me.KeyPreview = True
                
            '@結果判定
            If lblnAns = False Then
                '@権限が"なし"の場合
            
                '@表示ﾒｯｾｰｼﾞ変換
                '@「<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrNotUseScrap)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                '@戻り値を"False=権限なし"で設定
                prvblnAuthority_Chk = False
			Else
				'権限チェックOK
				prvblnAuthority_Chk = True
			End If


            Exit Function

        Catch ex As Exception

            
            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnAuthority_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

	Private Sub cmdJMaskSet_Click(sender As Object, e As EventArgs) Handles cmdJMaskSet.Click
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
            
            '自フォームフラグ
            pblnfrmxxEN02D0kbn = True

            'インスタンス生成
            frmxxEN02V0.Instance = New frmxxEN02V0()
                
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                pblnfrmxxEN02F0kbn = False
                frmxxEN02V0.Instance = Nothing
                Exit Sub
            End If
            
            '「蒸着マスク組立」画面表示
            frmxxEN02V0.Instance.ShowDialog(Me)
            frmxxEN02V0.Instance = Nothing
            pstrLotID = vbNullString
            pblnFormLoad = False
			Call prvvsfJJigList_Init()
			Call cmdJJigNowList_Click(cmdJJigNowList,New EventArgs)

            pblnfrmxxEN02D0kbn = False
            
            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkStart_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
	End Sub
End Class
