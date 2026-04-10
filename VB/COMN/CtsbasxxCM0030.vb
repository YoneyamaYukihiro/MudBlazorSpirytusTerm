'ﾌｧｲﾙ名：xxCM0030.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：共通変数
'作成日：2004/02/13 (Fri) 11:29:35 K.Takano
'更新日：2019/12/09 (Mon) 15:50:47 T.Oide
'備　考：
'Copyright(C)2003-2019, SEIKO EPSON CORPORATION.
Option Explicit On
Imports TFLib
Public Module basxxCM0030
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '@-----------------------------------
    '@　Public格納用構造体宣言
    '@-----------------------------------
    Public ptypFuncInfo                 As UtilFuncInfo                '関数情報構造体(機能定数、機能ﾊﾞｰｼﾞｮﾝ)
    Public pTerm                        As TfBase                      'ﾒｯｾｰｼﾞ送信ｵﾌﾞｼﾞｪｸﾄ
    Public ptypLotprestate              As Lotprestate                 '子画面へのLotprestateﾃﾞｰﾀ引渡し用(子画面を呼ぶ前に格納、Showから戻ったらクリアする
    Public ptypPart                     As PartList                    '利用部材選択画面への引渡し用
    Public ptypLotAction                As LotAction                   'ｱｸｼｮﾝ予約表示画面への引渡し用
    Public ptypCM00J0                   As CM00J0                      '工順ｺﾋﾟｰﾛｯﾄ一覧(画面間の引渡し用)
    Public ptypMasCondDetailList        As MasCondDetailList           '処理条件詳細情報
    Public ptypUseRecpList              As UseRecpList                 '装置ﾚｼﾋﾟﾘｽﾄ(流動票画面間引渡し用)
    Public ptypOnErrorInfo              As OnErrorInfo                 '実行時ｴﾗｰ情報
    Public ptypCommonInfo               As CommonInfo                  'PG間ﾃﾞｰﾀ受け渡し用
    Public ptypExeInfo                  As List(Of ExeInfo)            'ﾌﾟﾛｾｽﾊﾝﾄﾞﾙ格納用配列
    Public ptypExeInfoCnt               As Integer                     'ﾌﾟﾛｾｽﾊﾝﾄﾞﾙｶｳﾝﾀ
    Public ptypGetSendOrderList         As GetSendOrderList            'ﾌｫｰﾑ･ﾚﾎﾟｰﾄ間ﾃﾞｰﾀ受け渡し用(送品伝票)
    Public ptypGetLotExamInfo           As List(Of GetLotExamInfo)     'ﾌｫｰﾑ･ﾚﾎﾟｰﾄ間ﾃﾞｰﾀ受け渡し用(ﾛｯﾄ検定表)
    Public ptypWaferListCp              As ProcWaferList               'WF情報退避
    Public ptypNextCollectInfo          As NextCollectInfo             '収集項目ID引継ぎ情報
    Public ptypSendCancelConnect        As SendCancelConnect           '送品取消情報引継構造体
    Public ptypLotReworkSet             As LotReWorkSet                'ﾛｯﾄﾘﾜｰｸ登録ﾃﾞｰﾀ格納
    Public pstrLotInsprstResult         As LotInsprstResult            '作業終了<=>WF状態変更/ﾁｯﾌﾟ状態変更/特殊流動 引継ぎ構造体
    Public ptypWorkEndInfo              As WorkEndInfo                 '作業終了<=>WF状態変更/ﾁｯﾌﾟ状態変更/特殊流動 引継ぎ構造体
    Public ptypRecp23List               As List(Of Lotrecplist)        'ﾃﾞﾌｫﾙﾄﾚｼﾋﾟ格納
    Public ptypRecp02List               As List(Of Lotrecplist)        'ﾏｽﾀﾚｼﾋﾟ格納
    Public ptypLotRlst                  As typLotRlst                  '投入LOT予定一覧納用
    Public ptypLotrecpList              As List(Of Lotrecplist)        'ﾛｯﾄ別ﾚｼﾋﾟ一覧格納用
    Public ptypWFrecpList               As List(Of Lotrecplist)        'WFﾚｼﾋﾟ一覧格納用
    Public ptypWPList                   As List(Of WpList)             '装置一覧格納用
    Public ptypWpuseinfo                As List(Of Wpuseinfo)          '装置使用工程格納用
    Public ptypEntryList                As List(Of EntryList)          'ﾏｽﾀ工順一覧格納
    Public ptypLotactrsv                As Lotactrsv                   'ｱｸｼｮﾝ予約設定
    Public ptypWfactrsv                 As Wfactrsv                    'WF設定ｱｸｼｮﾝ予約
    Public ptypLotActioninfo            As LotActioninfo               'ｱｸｼｮﾝ予約検索格納用
    Public plngTmResponseListMaxIndex   As Integer                     'ﾚｽﾎﾟﾝｽ測定送信用配列の最大INDEX
    Public ptypHoldConnect              As HoldConnect                 '在庫管理引継ぎ構造体
    Public ptypCfkiRenkeiInfo           As CfkiRenkeiInfo              '対向基板ﾘﾜｰｸ不良登録連携格納用
    Public ptypRirekeiNextinfo          As RirekeiNextinfo             '履歴情報引継ぎ構造体(流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟで使用)
    Public ptypCmpRirekeiinfo           As CmpRirekeiinfo              'ﾒﾝﾃﾅﾝｽ履歴表示用引継ぎ構造体
    '@ﾒｰﾙ送信画面に使用します。(最終的には内容を保持する可能性がある為、Publicに記述)
    Public ptypDepartmentList           As DepartmentInfo              '部署/所属格納構造体
    Public ptypDeptEmpList              As DeptEmpInfo                 'ﾕｰｻﾞ格納構造体
    Public ptypSendMailList             As SendMailList                '宛先人格納構造体
    Public ptypMailInfo                 As MailInfo                    'ﾒｰﾙ送信画面引継ぎ構造体
    Public ptypSendMessageList          As SendMessageList             'ﾒｰﾙ送信用格納構造体
    Public ptypOdfInfo                  As OdfInfo                     'ODF画面引継ぎ構造体
    Public ptypExcpReport               As ExcpReport                  '工程異常/不適合品処理票・登録更新/取得構造体
    Public ptypChkMaterial              As ChkMaterial                 '装置使用部材判定(引継ぎ用)
    Public ptypRegMaterial              As RegMaterial                 '装置使用部材登録/分割(引継ぎ用)
    Public ptypEqStopMenteDetailList    As EqDetailList                '予実表表示画面への引継ぎ用
    Public ptypEqStopMenteRenkeiInfo    As EqStopMenteRenkeiInfo       '装置停止ﾒﾝﾃ計画連携格納用
    Public ptypLotScrapInfo             As LotScrapInfo                'ﾛｯﾄ別不良ｺｰﾄﾞ別不良数ﾘｽﾄ
    Public ptypLTSelectList             As LTSelectList                '時間制限選択情報配列
    Public ptypApcOpStepInfo            As ApcOpStepInfo               'APC設定連携格納構造体
    Public ptypProcCondDetailList       As ProcCondDetailList          '個別処理条件配列
    Public ptypCopyCondDetailList       As ProcCondDetailList          '個別処理条件配列(ｺﾋﾟｰ用)
    Public ptypCondDetailListCp         As ProcCondDetailList          '個別処理条件配列(ｺﾋﾟｰ元ｸﾞﾘｯﾄﾞ)
    Public ptypProcTimeLimitInfo        As ProcTimeLimitInfo           '時間制約配列
    Public ptypApcAns                   As ApcAns                      'APC情報格納
    Public ptypEN01X7                   As EN01X7                      'ｺﾋﾟｰ元ﾛｯﾄ一覧引継ぎ構造体
    Public ptypEN01X4                   As EN01X4                      'ｺﾋﾟｰ元ﾛｯﾄ一覧引継ぎ構造体
    Public ptypWpRestrictInfo           As WpRestrictInfo              '号機記憶格納構造体
    Public ptypTakeOverDataEN01Y0       As List(Of TakeOverDataEN01Y0) '星取表表示画面引継ぎ用構造体
    Public ptypRepairInfo               As RepairInfo                  '故障修理記録情報引継ぎ構造体
    Public ptypRepairConnectInfo        As RepairConnectInfo           '故障修理記録票一覧への引継ぎ用情報格納構造体
    Public ptypPreserveInfo             As PreserveInfo                '保全記録情報引継ぎ構造体
    Public ptypPreserveConnectInfo      As PreserveConnectInfo         '保全記録票一覧への引継ぎ用情報格納構造体
    Public ptypRecipeInfo               As RecipeInfo                  'ﾚｼﾋﾟ一覧検索(ﾌｫﾄF/Bﾃﾞｰﾀ)
    Public ptypPhotoFbDataChgReq        As PhotoFbDataChgReq           'ﾌｫﾄF/Bﾃﾞｰﾀ変更要求格納構造体(合せ)
    Public ptypPhotoFbDataListAns       As PhotoFbDataListAns          'ﾌｫﾄF/Bﾃﾞｰﾀ変更からpatch分割設定への情報引継ぎ構造体
    Public ptypInvPart                  As typInvPartClass             '在庫管理画面起動引継ぎ用

    '@-----------------------------------
    '@　文字型定義
    '@-----------------------------------
    Public pstrAtlasFlowNumber          As String           'ATLASﾌﾛｰﾅﾝﾊﾞｰ(画面間の引渡し用)
    Public pstrMessageName              As String           'ﾒｯｾｰｼﾞ処理名格納主に通信失敗時のﾒｯｾｰｼﾞ用
    Public pstrUserID                   As String           'ﾕｰｻﾞID
    Public pstrUserName                 As String           'ﾕｰｻﾞ名称
    Public pstrDeptID                   As String           '職場ID
    Public pstrDeptName                 As String           '職場名
    Public pstrGroupID                  As String           '所属ｸﾞﾙｰﾌﾟID
    Public pstrCarrierID                As String           'ｷｬﾘｱID
    Public pstrCFCarrierID              As String           'CFｷｬﾘｱID(CM00T0)引渡し用
    Public pstrCFLotID                  As String           'CFﾛｯﾄID(EN02H0)引渡し用
    Public pstrWPID                     As String           'WPID(画面間の引渡し用)
    Public pstrWPName                   As String           'WP名(画面間の引渡し用)
    Public pstrEqType                   As String           'EQﾀｲﾌﾟ(画面間の引渡し用)
    Public pstrConnectSBID              As String           '引継ぎｼｽﾃﾑﾌﾞﾛｯｸ
    Public pstrLotRecipeFlag            As String           'ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ
    Public pstrLoaderUnloaderFlag       As String           'Loader/Unloaderﾌﾗｸﾞ
    Public pstrLotLastUpdate            As String           'ﾁｯﾌﾟ状態変更→ﾛｯﾄｺﾒﾝﾄ(子画面)最終更新日時引渡し
    Public pstrDefaultStep              As String           'ﾃﾞﾌｫﾙﾄ小工程(画面間の引渡し用)
    Public pstrStatusberMSG             As String           'ｽﾃｰﾀｽﾊﾞｰ表示(子画面から表示用)
    Public pstrLotID                    As String           'LotID(画面間の引渡し用)
    Public pstrLotList                  As List(Of String)  'LotID(画面間の引渡し用)
    Public pstrFlowClass                As String           'FlowClass(画面間の引渡し用)
    Public pstrStartFromName            As String           '起動ﾌｫｰﾑ名を格納(ﾒﾆｭｰ用)
    Public pstrDMsg                     As String           '表示ﾒｯｾｰｼﾞ用
    Public pstrPDID                     As String           'PDID(画面間の引渡し用)
    Public pstrPDIDAry                  As List(Of String)  'PDIDのｱﾚｰ(画面間の引渡し用)
    Public pstrEntryName                As String           'ｴﾝﾄﾘ名(画面間の引渡し用)
    Public pstrEntryID                  As String           'ｴﾝﾄﾘID(画面間の引渡し用)
    Public pstrMaxWFCount               As String           '最大WF枚数(画面間の引渡し用)
    Public pstrExcpName                 As String           '工程異常名格納
    Public pstrCarrierTypeID            As String           'ｷｬﾘｱﾀｲﾌﾟ(画面間の引渡し用)
    Public pstrJigTypeID                As String           '治具ﾀｲﾌﾟ(画面間の引渡し用)
    Public pstrJigStatus                As String           '治具ｽﾃｰﾀｽ(画面間の引渡し用)
    Public pstrScreenSizeID             As String           '治具のｽｸﾘｰﾝｻｲｽﾞ(画面間の引渡し用)
    Public pstrJigCategoryID            As String           '治具ｶﾃｺﾞﾘ(画面間の引渡し用)
    Public pstrJJigCategoryID           As String			'蒸着治具ｶﾃｺﾞﾘ(画面間の引渡し用)
	Public pstrCleanCondition           As String           '洗浄条件(画面間の引渡し用)
    Public pstrCommand                  As String           'ｺﾏﾝﾄﾞﾗｲﾝ引数格納用(起動ﾓｰﾄﾞ)
    Public pstrWorkMemo                 As String           '作業ﾒﾓ格納変数
    Public pstrChgSort                  As String           'ｶﾚﾝﾄｷｰ保持用
    Public pstrOptionValue              As String           'ｵﾌﾟｼｮﾝﾎﾞﾀﾝ値保持用(EN0060で使用)
    Public pstrfrmxxCM0090Kbn           As String           'ﾌｫｰﾑ起動区分(0M:lot分割以外から起動、0N:lot分割から起動、0Z:投入予定ﾛｯﾄ登録(品確、モニター・ダミー)からの起動)
    Public pstrTypeFlag                 As String           '空きｷｬﾘｱ一覧表示判定用ﾌﾗｸﾞ(値=1or0orNULL)(ｷｬﾘｱ管理で使用)
    Public pstrRelatedLotStatus         As String           '空きｷｬﾘｱ一覧表示判定用ﾌﾗｸﾞ(値=ﾛｯﾄｽﾃｰﾀｽorNULL)(ｷｬﾘｱ管理で使用)
    Public pstrTerminalFlag             As String           '端末状態判定ﾌﾗｸﾞ(0:ﾃﾞﾌｫﾙﾄ装置端末,1:ﾃﾞﾌｫﾙﾄ装置端末以外)
    Public pstrSystemBlcID              As String           'ｼｽﾃﾑﾌﾞﾛｯｸID
    Public pstrMakeMaterialLotID        As String           '装置使用部材管理(画面間引渡し用)
    Public pstrMakeMaterialOrderID      As String           '装置使用部材管理(画面間引渡し用)
    Public pstrEN01X8                   As String           '工順変更処理記憶一覧(画面間の引渡し用)
    Public pstrEN01X0KindFlag           As String           '種別(1:ﾛｯﾄ工順変更、2:組立工順一時保存)
    Public pstrEN01X0PdId               As String           '機種ID
    Public pstrEN01X0ProcFlag           As String           'ﾛｯﾄ種別ﾌﾗｸﾞ(0:通常ﾛｯﾄ、1:特殊ﾛｯﾄ(ﾘﾜｰｸ、追加流動))
    Public pstrExecuteMenuKey           As String           '起動中ﾌﾟﾛｸﾞﾗﾑ(ﾒﾆｭｰ起動中PG格納用)
    Public pstrExecuteWebMenuKey        As String           '起動中WEBﾌﾟﾛｸﾞﾗﾑ(ﾒﾆｭｰ起動中PG格納用)
    Public pstrExecuteExeMenuKey        As String           '起動中EXEﾌﾟﾛｸﾞﾗﾑ(ﾒﾆｭｰ起動中PG格納用)
    Public pstrProhibitedEmp            As String           '禁止担当者(工順変更用)
    Public pstrProhibitedDept           As String           '禁止担当部署(工順変更用)
    Public pstrVerUpProhibited          As String           '禁止設(0:可、1:不可)(工順変更用)
    Public pstrDefaultWpID              As String           'ﾃﾞﾌｫﾙﾄWPID(M_TERMINAL設定ﾃﾞｰﾀ)
    Public pstrCarrierCategoryID        As String           'ｷｬﾘｱｶﾃｺﾞﾘID(画面間の引渡し用)
    Public pstrVaFlag                   As String           '無機ﾌﾗｸﾞ(画面間の引渡し用)
    Public pstrTpalClass                As String           'TPAL設定(画面間の引渡し用)
    Public pstrfrmxxEN00M1Kbn           As String           'ﾌｫｰﾑ起動区分(1:ﾓﾆﾀ選択での起動、2:ﾀﾞﾐｰ選択での起動)
    Public pstrDummyJigID               As String           'ﾀﾞﾐｰ冶具IDﾌｫｰﾑ間引継ぎ用(ﾊﾞｯﾁ管理⇔冶具管理)
    Public pstrToCarrierID              As String           '分割先ｷｬﾘｱID
    Public pstrJigID                    As String           '治具ID
    Public pstrRestrictMessage          As String           '時間制限ﾒｯｾｰｼﾞ格納用
    Public pblnEN0271EditFlag           As Boolean          'WFｱｸｼｮﾝ予約編集ﾌﾗｸﾞ
    Public pstrWfActionFlag             As String           'ｳｪﾊｰｱｸｼｮﾝﾌﾗｸﾞ(0：なし、1：作業開始、2：作業終了、4全ﾀｲﾐﾝｸﾞ
    Public pstrfrmxxEN2Q0Div            As String           '防湿ALDﾛｯﾄ流動起動区分
	Public pstrReserveId				As String			'蒸着後流動予約ID(画面間の引渡用)

    '@-----------------------------------
    '@　配列定義
    '@-----------------------------------
    Public pstrFlowClassList()          As String           '投入予定ﾛｯﾄ変更/削除→投入予定ﾛｯﾄ一覧の場合に使用(種別)



    '@-----------------------------------
    '@　ﾌﾞｰﾙ型定義
    '@-----------------------------------
    Public pblnActInitFlg               As Boolean          'Act初期化ﾌﾗｸﾞ
    Public pblnEN00X5SelectOn           As Boolean          '時間制限選択(True:指定、False：未指定)
    Public pblnEN01X5LockOn             As Boolean          '時間制約番号のﾛｯｸﾌﾗｸﾞ(True:ﾛｯｸ、False：ﾛｯｸ解除)
    Public pblnEN01X5NewData            As Boolean          '時間制約番号の新規ﾃﾞｰﾀ判別(True:新規ﾃﾞｰﾀ、False：既存ﾃﾞｰﾀ)
    Public pblnEN01X2Edit               As Boolean          'ﾌﾟﾛｾｽ編集変更ﾌﾗｸﾞ
    Public pblnCancel                   As Boolean          'ｷｬﾝｾﾙﾎﾞﾀﾝ押下時True(各ﾌｫｰﾑ共通)
    Public pblnHisuInput                As Boolean          '品質記録の必須項目入力ﾌﾗｸﾞ(必須ﾌﾗｸﾞの入力項目がある場合このﾌﾗｸﾞがTrueにならないと確定できない)
    Public pblnHisuInputAri             As Boolean          '品質記録の必須項目ありﾌﾗｸﾞ(上記pblnHisuInputと対で使う)
    Public pblnfrmxxEN0060SPStartFlag   As Boolean          '作業終了-特殊流動ﾌﾗｸﾞ(作業終了確定→特殊流動自動起動時：True、その他：False)
    Public pblnfrmxxCM0030Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) ﾛｯﾄｺﾒﾝﾄ登録
    Public pblnfrmxxCM0050Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) レシピ設定変更
    Public pblnfrmxxCM0080Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) ﾁｯﾌﾟ不良／傾向／保留／払出登録
    Public pblnfrmxxCM0070Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) WF　不良／保留／払出／傾向登録
    Public pblnfrmxxCM00A0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) CFKI作業終了入力
    Public pblnfrmxxCM00B0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) 対向基板ﾘﾜｰｸ不良入力
    Public pblnfrmxxCM00C0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) ｷｬﾘｱ管理
    Public pblnfrmxxCM00G0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) 装置ﾃﾞｰﾀ登録/参照入力
    Public pblnfrmxxCM00H0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:起動成功、False:起動失敗) 異常処理票
    Public pblnfrmxxCM00H1Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:起動成功、False:起動失敗) 異常処理票-ﾛｯﾄ処置
    Public pblnfrmxxCM00H2Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:起動成功、False:起動失敗) 異常処理票-作業ﾐｽ報告書
    Public pblnfrmxxCM00H4Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:起動成功、False:起動失敗) 異常処理票-流動履歴表示
    Public pblnfrmxxCM00I0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) 異常処理票起案
    Public pblnfrmxxCM00P0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:当ﾌｫｰﾑから起動、False:未使用) 投入予定ﾛｯﾄ一覧
    Public pblnfrmxxCM00R0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動(基本的には無し)) ﾛｯﾄ情報詳細
    Public pblnfrmxxCM00S0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) ﾒｰﾙ送信
    Public pblnfrmxxCM00W0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) 投入予定ﾛｯﾄ変更/削除
    Public pblnfrmxxCM00Z0kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:当ﾌｫｰﾑから起動、False:他ﾌｫｰﾑ起動) 故障修理記録票登録／更新
    Public pblnfrmxxCM0110Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) ﾛｯﾄ処理順変更
    Public pblnfrmxxCM0130Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) 空治具一覧
    Public pblnfrmxxCM01A0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) ﾛｯﾄ情報変更/削除
    Public pblnfrmxxEN0030Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:当ﾌｫｰﾑから起動、False:他ﾌｫｰﾑ起動) 作業開始
    Public pblnfrmxxEN0050kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:当ﾌｫｰﾑから起動、False:他ﾌｫｰﾑ起動) ﾛｯﾄ保留
    Public pblnfrmxxEN00J0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:当ﾌｫｰﾑから起動、False:他ﾌｫｰﾑ起動(EN0150orEN0200)) 装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧
    Public pblnfrmxxEN00V0kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:当ﾌｫｰﾑから起動、False:他ﾌｫｰﾑ起動) 異常処理一覧
    Public pblnfrmxxEN00Y0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:起動成功、False:起動失敗) 特殊流動
    Public pblnfrmxxEN0120Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:EN0120から起動、False:EN0120以外から起動)
    Public pblnfrmxxEN0150Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:当ﾌｫｰﾑから起動、False:他ﾌｫｰﾑ起動(EN00J0orEN0200)) 装置別ﾛｯﾄ一覧
    Public pblnfrmxxEN0151Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:当ﾌｫｰﾑから起動、False:他ﾌｫｰﾑ起動) 装置別ﾛｯﾄ一覧(防湿ALD)
    Public pblnfrmxxEN0150BCR           As Boolean          '装置別ﾛｯﾄ一覧BCRｷｬﾘｱ照合ﾌﾗｸﾞ
    Public pblnfrmxxEN0200Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:当ﾌｫｰﾑから起動、False:他ﾌｫｰﾑ起動(EN00J0orEN0150)) 工程別ﾛｯﾄ一覧
    Public pblnfrmxxEN01A0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動(基本的には無し)) TPAL貼り合わせ登録
    Public pblnfrmxxEN01Z0kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:当ﾌｫｰﾑから起動、False:他ﾌｫｰﾑ起動) 故障修理記録票一覧
    Public pblnfrmxxEN02E0kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:当ﾌｫｰﾑから起動、False:他ﾌｫｰﾑ起動) CF移載情報登録
    Public pblnfrmxxEN0100kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:当ﾌｫｰﾑから起動、False:他ﾌｫｰﾑ起動) ﾛｯﾄ統合
    Public pblnfrmxxEN02F0kbn           As Boolean          'ﾌｫｰﾑ起動区分
    Public pblnfrmxxEN02D0kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:他ﾌｫｰﾑから起動、False:単独起動、初期値) 冶具管理
    Public pblnfrmxxEN02H0kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:他ﾌｫｰﾑから起動、False:単独起動) 無機対向基板紐付/蒸着バッチ情報
    Public pblnfrmxxEN02L0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) GRB属性設定
    Public pblnfrmxxEN02Q0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:当ﾌｫｰﾑから起動、False:他ﾌｫｰﾑ起動) 防湿ALDﾛｯﾄ流動
	Public pblnfrmxxEN02U0Kbn           As Boolean          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動) ODF予約

    Public pblnFavoritesEdit            As Boolean          'お気に入り編集ﾌﾗｸﾞ(True:編集あり、False：編集なし)
    Public pblnEdit                     As Boolean          '編集ﾌﾗｸﾞ
    Public pblnTrnFlag                  As Boolean          'DoEvents制御ﾌﾗｸﾞ
    Public pblnWpIDNullFlag             As Boolean          '作業開始→ﾚｼﾋﾟ変更画面で使用(True:WP_ID=NULL)
    Public pblnfrmxxCM0050CVFlag        As Boolean          'ﾚｼﾋﾟ設定変更画面(True:CARRIER_Validate完了、False:CARRIER_Validate中(ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用))
    Public pblnCommetsCommitFlag        As Boolean          'ﾛｯﾄｺﾒﾝﾄ更新(True:更新、False:未更新)
    Public pblnMaterialRegistFlag       As Boolean          '部材登録/分割/日付変更判定ﾌﾗｸﾞ(True:登録、False:未登録)
    Public pblnMaterialSelectFlag       As Boolean          '使用部材選択判定ﾌﾗｸﾞ(True:選択済み,False:未選択or選択に不備あり)
    Public pblnReqPrint                 As Boolean          '印刷要求判定用(EN01Y0)
    Public pblnLotSendFlag              As Boolean          '送品伝票・ﾛｯﾄ検定表印刷用 送品ﾌﾗｸﾞ
    '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。
    'Public pblnCdenProcJudgeFlag        As Boolean          'ﾁｯﾌﾟ電特工程有無判定ﾌﾗｸﾞ(True:ﾁｯﾌﾟ電特工程あり、False:ﾁｯﾌﾟ電特工程なし)
    Public pblnUseChangLoadKbn          As Boolean          '装置状態変更時起動判定ﾌﾗｸﾞ(True:装置状態変更での起動、False:初期値)
    Public pblnPreserveReportRegistFlag As Boolean          '保全記録票起票判定ﾌﾗｸﾞ(True:登録、False:未登録)
    Public pblnWpSelectFlag             As Boolean          'WP Selected Flag
    Public pblnMkEasyDivFlag            As Boolean          '無機用簡易分割識別ﾌﾗｸﾞ(True:簡易分割実施 False:簡易分割未実施)
	Public pblnDoubleJPdFlag			 As Boolean          '無機蒸着2回識別ﾌﾗｸﾞ(True:蒸着2回対象 False:蒸着2回対象外)
    Public pblnCFMoveDataFlag           As Boolean          'CF移載情報登録ﾌﾗｸﾞ(0:未登録、1:登録済み)
    Public pblnTerminalBCR              As Boolean          'ﾀｰﾐﾅﾙにBCR付属有無(0:無、1:有)



    '@-----------------------------------
    '@　数値型定義
    '@-----------------------------------
    Public plngfrmxxCM0080Kbn           As Integer          'ﾌｫｰﾑ起動区分(0:初期値、1:不良ﾁｯﾌﾟ情報(№表示)で起動) ﾁｯﾌﾟ状態変更登録
    Public plngfrmxxCM0120Kbn           As Integer          'ﾌｫｰﾑ起動区分(0:保留で起動、1:保留解除で起動) ﾛｯﾄ保留／保留解除
    Public plngfrmxxCM00F0Kbn           As Integer          'ﾌｫｰﾑ起動区分(0:機種ｴﾝﾄﾘ最新検索結果を表記,1:機種ｴﾝﾄﾘの全件検索結果を表記,2:ﾕｰｻﾞｰﾌﾟﾛｾｽ検索結果を表記)
    Public plngfrmxxCM00L0Kbn           As Integer          'ﾌｫｰﾑ起動区分(0:機種ｴﾝﾄﾘ最新検索結果を表記,1:機種ｴﾝﾄﾘの全件検索結果を表記,2:ﾕｰｻﾞｰﾌﾟﾛｾｽ検索結果を表記)
    Public plngfrmxxCM00M0Kbn           As Integer          'ﾌｫｰﾑ起動区分(0:投入予定ﾛｯﾄ登録で起動、1:分割予定ﾛｯﾄ登録で起動) 投入予定ﾛｯﾄ登録/分割予定ﾛｯﾄ登録
    Public plngfrmxxCM00S0Kbn           As Integer          'ﾌｫｰﾑ起動区分(0:初期化/1:起動成功＆閉じる/2:起動成功＆送信)
    Public plngfrmxxCM00T0Kbn           As Integer          'ﾌｫｰﾑ起動区分(0:CFｷｬﾘｱ一覧起動、1:TFT/CFﾛｯﾄ紐付き情報起動)
    Public plngfrmxxCM01B0Kbn           As Integer          'ﾌｫｰﾑ起動区分(0:CFｷｬﾘｱ一覧起動、1:TFT/CFﾛｯﾄ紐付き情報起動)
    Public plngfrmxxCM00V0Kbn           As Integer          'ﾌｫｰﾑ起動区分(0:ﾃﾞﾌｫﾙﾄ(初期化値)、1：ﾁｯﾌﾟ状態変更からの起動、2:ﾛｯﾄ投入(組立)からの起動、3：ﾛｯﾄ処理順変更からの起動) ｺﾒﾝﾄ/時間制限表示画面用
    Public plngTakingOverFlag           As Integer          '引継ぎﾌﾗｸﾞ(ﾒﾆｭｰ用)
    Public plngCarrTakeOver             As Integer          'ｷｬﾘｱ引継ぎﾌﾗｸﾞ(ﾒﾆｭｰ列用)
    Public plngFlowClass                As Integer          '投入予定ﾛｯﾄ変更/削除→投入予定ﾛｯﾄ一覧の場合に使用(選択数)
    Public plngLotStatus                As Integer          '在庫管理画面、中間WF在庫ﾀﾌﾞ判定用(0:中間在庫Tab以外からの起動,1:中間在庫Tab起動で元ﾛｯﾄ,2:中間在庫Tab起動で混成元ﾛｯﾄ)
    Public plngPrintLotCnt              As Integer          '印刷ﾛｯﾄ数格納用(EN01Y0)
    Public plngLotCondDetailIndex       As Integer          'ﾃﾞｰﾀ格納ｲﾝﾃﾞｯｸｽ
    Public plngTimeLimitCnt             As Integer          '時間制限設定番号
    Public plngSeqNoCnt                 As Integer          '工順番号
    Public plngLoadClass                As Integer          '起動区分(汎用)
    Public plngRestrictForeColor        As Integer          '時間制限ﾒｯｾｰｼﾞ表示色格納用


    '@-----------------------------------
    '@　IEｵﾌﾞｼﾞｪｸﾄ
    '@-----------------------------------
    '@IEｵﾌﾞｼﾞｪｸﾄ
    'Public pobjInetExp                  As Object           'IEのｵﾌﾞｼﾞｪｸﾄ
    Public plngInetExphWnd              As Integer          'IEのｳｨﾝﾄﾞｳﾊﾝﾄﾞﾙ

    '@-----------------------------------
    '@WSHｵﾌﾞｼﾞｪｸﾄ(Chrome用)
    '@-----------------------------------
    Public pobjWsh                      As Object           'Windows Script Hostｵﾌﾞｼﾞｪｸﾄ

    '@-----------------------------------
    '@Webｱﾄﾞﾚｽ
    '@-----------------------------------
    Public pstrWebAdd                   As String

    '@-----------------------------------
    '@　Formｵﾌﾞｼﾞｪｸﾄ
    '@-----------------------------------
    '@ﾚﾎﾟｰﾄ印刷ﾌｫｰﾑ
    Public pfrmReportPrint              As Form
    Public pfrmReportPrint2             As Form


    '@-----------------------------------
    '@　構造体定義
    '@-----------------------------------
    '@ﾛｸﾞｲﾝ/ﾛｸﾞｱｳﾄ登録
    Public Structure loginout
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strClassDivision                As String           '処理区分
        Dim strLogInID                      As String           'ﾛｸﾞｲﾝID
        Dim strLocalHostName                As String           'ﾛｰｶﾙﾎｽﾄ名
        Dim strServerHostName               As String           'ｻｰﾊﾞｰﾎｽﾄ名
    End Structure

    '@作業終了<=>WF状態変更/ﾁｯﾌﾟ状態変更/特殊流動 引継ぎ構造体  ★ﾁｪｯｸﾎﾞｯｸｽ判定用
    Public Structure LotInsprstResult
        Dim strOpID                         As String               '大工程ID
        Dim strStepID                       As String               '小工程ID
        Dim strLotID                        As String               'ﾛｯﾄID
        Dim strWorkKbn                      As String               '作業ﾌﾗｸﾞ(0:処理なし/1:ﾁｯﾌﾟ/2:WF移載/3:ﾛｯﾄ終了)
        Dim strSpecialRuteFlag              As String               '特殊流動ﾌﾗｸﾞ(0:処理なし/1:ﾘﾜｰｸ/2:追加流動)
    End Structure

    '@作業終了<=>WF状態変更/ﾁｯﾌﾟ状態変更/特殊流動 引継ぎ構造体
    Public Structure WorkEndInfo
        Dim strCarrierId                    As String               'ｷｬﾘｱID
        Dim strLotID                        As String               'ﾛｯﾄID
        Dim strfrmxxKbn                     As String               'ﾌｫｰﾑ区分
        Dim strWorkKbn                      As String               '作業ﾌﾗｸﾞ(0:処理なし/1:ﾁｯﾌﾟ/2:WF移載/3:ﾛｯﾄ終了)
        Dim strSpecialRuteFlag              As String               '特殊流動ﾌﾗｸﾞ(0：処理なし/１：ﾘﾜｰｸ/２：追加流動)
    End Structure

    '@ﾊﾞｯﾁ作業開始結果
    Public Structure batStart
        Dim strLotID                        As String               'ﾛｯﾄID
        Dim strLastUpdate                   As String               '最終更新日時
        Dim strResultFlag                   As String               '結果ﾌﾗｸﾞ
    End Structure

    '@制限時間情報格納用構造体(ﾊﾞｯﾁ作業開始の結果も格納)
    Public Structure RestrictInfo
        Dim strToOpId                       As String               '制限時間先大工程
        Dim strToStepId                     As String               '制限時間先小工程
        Dim strLimitTime                    As String               '制限時間
        Dim strWarnTime                     As String               '警告時間
        Dim typBatStart                     As List(Of batStart)    'ﾊﾞｯﾁ作業開始結果
        Dim lngBatStartCnt                  As Integer              'ﾘｽﾄの数
    End Structure

    '@装置ﾃﾞｰﾀ情報
    Public Structure CollectNextDvName
        Dim strNo                           As String               '№
        Dim strClass1                       As String               'ﾃﾞｰﾀ分類1名
        Dim strClass2                       As String               'ﾃﾞｰﾀ分類2名
        Dim strClass3                       As String               'ﾃﾞｰﾀ分類3名
        Dim strClass4                       As String               'ﾃﾞｰﾀ分類4名
        Dim strData                         As String               '登録値
        Dim strSpecCheck                    As String               '判定結果
    End Structure

    '@ﾊﾟﾗﾒｰﾀ情報
    Public Structure CollectNextParamater
        Dim strParameterID                  As String                     'ﾊﾟﾗﾒｰﾀID
        Dim strParameterVer                 As String                     'ﾊﾟﾗﾒｰﾀVer
        Dim strMeasureMode                  As String                     '測定ﾓｰﾄﾞ
        Dim strDataRetainFlag               As String                     '装置ﾃﾞｰﾀ引継ぎﾌﾗｸﾞ
        Dim lngDvNameCnt                    As Integer                    '装置ﾃﾞｰﾀ数
        Dim typDvName                       As List(Of CollectNextDvName) '装置ﾃﾞｰﾀ項目
    End Structure

    '@収集項目ID引継ぎ情報
    Public Structure CollectNextInfo
        Dim strCollectID                    As String                        '収集項目ID
        Dim strCollectVer                   As String                        '収集項目Ver
        Dim strOpID                         As String                        '大工程
        Dim strStepID                       As String                        '小工程
        Dim lngParameterCnt                 As Integer                       'ﾊﾟﾗﾒｰﾀ数
        Dim typParameter                    As List(Of CollectNextParamater) 'ﾊﾟﾗﾒｰﾀ情報
    End Structure

    '@装置ﾃﾞｰﾀ引継ぎ情報構造体
    Public Structure NextCollectInfo
        Dim lngCollectCnt                   As Integer                  '収集項目ｶｳﾝﾄ
        Dim typCollect                      As List(Of CollectNextInfo) '収集項目情報
    End Structure

    '@送品取消引継構造体
    Public Structure SendCancelConnect
        Dim strToSend                       As String               '送品先
        Dim strSendDate                     As String               '送品日
        Dim strLotID                        As String               'ﾛｯﾄID
        Dim strPdId                         As String               '機種
        Dim strBoxNo                        As String               '箱№
        Dim strPartCode                     As String               '仕掛品ｺｰﾄﾞ
        Dim strAtlasOrderNo                 As String               'ATLASｵｰﾀﾞｰ№
        Dim strWFQuantity                   As String               'WF数
        Dim strChipQuantity                 As String               'Chip数
        Dim strLotLastUpdate                As String           '技術担当者名
        Dim strCarrierId                    As String               'ｷｬﾘｱID
        Dim strCarrierType                  As String               'ｷｬﾘｱﾀｲﾌﾟ
        Dim strRegistFlag                   As String               '確定処理完了ﾌﾗｸﾞ(0:確定処理未/1:確定処理実行)
    End Structure

    '@構造体の宣言
    '@ﾀｽｸID・ﾌﾟﾛｾｽﾊﾝﾄﾞﾙ退避用
    Public Structure ExeInfo
        Dim strMenuKey                      As String           '機能ID
        Dim lngTaskID                       As Integer          'ﾀｽｸID
        Dim lnghProcess                     As IntPtr           'ﾌﾟﾛｾｽﾊﾝﾄﾞﾙ
    End Structure

    '@ｴﾘｱ装置用途情報(mas_.areainfo 受信)
    Public Structure AreaEquipmentList
        Dim strWpID                         As String           'WPID
        Dim strWpName                       As String           'WP名
        Dim strUseId                        As String           '用途ID
        Dim strUseName                      As String           '用途名
        Dim strMesModeId                    As String           '運用ﾓｰﾄﾞ
        Dim strWpTypeFlag                   As String           'WPﾀｲﾌﾟﾌﾗｸﾞ
        Dim strWpStopFlag                   As String           'WP停止ﾌﾗｸﾞ
        Dim strWpStatusName                 As String           '装置状態名
        Dim strPlaceID                      As String           'ｽﾄｯｶID
        Dim strPlaceName                    As String           'ｽﾄｯｶ名
        Dim strEqType                       As String           'EQﾀｲﾌﾟ
        Dim strALDProcessModeId             As String           'ALD処理ﾓｰﾄﾞ
        Dim strALDProcessName               As String           'ALD処理名
    End Structure

    '@ｴﾘｱ情報一覧(mas_.areainfo 受信)
    Public Structure AreaList
        Dim strAreaID                       As String           'ｴﾘｱID
        Dim strAreaName                     As String           'ｴﾘｱ名
    End Structure

    '@ｽﾄｯｶｰﾏｽﾀ一覧(mas_.stockerlist 受信)
    Public Structure StockerList
        Dim strStockerId                    As String           'ｽﾄｯｶID
        Dim strStockerName                  As String           'ｽﾄｯｶ名
    End Structure

    '@ｷｬﾘｱ新規追加
    Public Structure CarrierAdd
        Dim strSbID                         As String           '利用SB
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strCarrierTypeID                As String           'ｷｬﾘｱﾀｲﾌﾟ
        Dim strVenderId                     As String           'ﾍﾞﾝﾀﾞｰ
        Dim strVendorName                   As String           'ﾍﾞﾝﾀﾞｰ名
        Dim strStartTime                    As String           '利用開始日
        Dim strProductionDate               As String           '製造年月日
        Dim strEmpID                        As String           '作業者ID
    End Structure

    '@ｷｬﾘｱ関連ﾏｽﾀｰ
    Public Structure CarrierMaster
        Dim strCarrierDiscID                As String           'ｷｬﾘｱ識別ID
        Dim strVendorID                     As String           'ﾍﾞﾝﾀﾞｰID
        Dim strVendorName                   As String           'ﾍﾞﾝﾀﾞｰ名
        Dim strCarrierTypeID                As String           'ｷｬﾘｱﾀｲﾌﾟID
        Dim strCarrierTypeName              As String           'ｷｬﾘｱﾀｲﾌﾟ名
        Dim strSlotSize                     As String           'ｽﾛｯﾄ数
        Dim strMaxCleanCount                As String           '洗浄耐用回数
        Dim strMaxUseCount                  As String           '使用耐用回数
        Dim strTypeFlag                     As String           'ｷｬﾘｱﾀｲﾌﾟﾌﾗｸﾞ(1or0)
    End Structure

    '@ｷｬﾘｱ情報
    Public Structure CarrierList
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strCarrierStatID                As String           'ｷｬﾘｱ状態
        Dim strCurrentPositionID            As String           '現在位置
        Dim strVenderId                     As String           'ﾍﾞﾝﾀﾞｰID
        Dim strVenderName                   As String           'ﾍﾞﾝﾀﾞｰ名
        Dim strStartTime                    As String           '利用開始日
        Dim strCleanNum                     As String           '洗浄回数
        Dim strCleanFLG                     As String           '洗浄ﾌﾗｸﾞ
    End Structure

    Public Structure CarrierAllList '(carr.alllist_ 取得)
        Dim lngCnt                          As Integer              'ﾘｽﾄのｶｳﾝﾄ
        Dim typCarrierList                  As List(Of CarrierList) 'ｷｬﾘｱ情報
    End Structure

    '@ｷｬﾘｱ統合
    Public Structure WFMapList
        Dim strSlotPosition                 As String           'ｽﾛｯﾄNO
        Dim strWfId                         As String           'WFID
        Dim strjigId                        As String           'JIGID
    End Structure

    '@ｷｬﾘｱ統合
    Public Structure CarrMove
        Dim strOnlineFlag                   As String             '0：ｵﾌﾗｲﾝ/1：ｵﾝﾗｲﾝ
        Dim strClassDivision                As String             '処理区分
        Dim strCarrierID1                   As String             '移載対象ｷｬﾘｱ1ID
        Dim strCarrierID2                   As String             '移載対象ｷｬﾘｱ2ID
        Dim typWFMapList1                   As List(Of WFMapList) '移載後のｷｬﾘｱ1のｽﾛｯﾄ状態を表すｽﾛｯﾄﾏｯﾌﾟ
        Dim typWFMapList2                   As List(Of WFMapList) '移載後のｷｬﾘｱ2のｽﾛｯﾄ状態を表すｽﾛｯﾄﾏｯﾌﾟ
        Dim strEmpID                        As String             '作業者ID
        Dim strMessageName                  As String             'ﾒｯｾｰｼﾞﾎﾞｯｸｽ見出し用ﾀｲﾄﾙ名
    End Structure

    '@種別一覧
    Public Structure DivisionList
        Dim strDivisionID                   As String           '種別ID
        Dim strDivisionName                 As String           '種別名
    End Structure

    '@投入予約(lot_.thrwresv 要求)
    Public Structure LotReserve
        Dim strLotID                        As String           '生成LOTID
        Dim strPdId                         As String           '機種ID
        Dim strFlowClass                    As String           '流動区分
        Dim strWfNum                        As String           'WF枚数
        Dim strPlanThrowinDate              As String           '投入予定日
        Dim strEngEmpId                     As String           '技術担当
        Dim strCopySeqLotID                 As String           'ｺﾋﾟｰ元LotID
        Dim strMasVer                       As String           '工順Version
        Dim strDivideLotID                  As String           '分割LotID
        Dim strComment                      As String           'ｺﾒﾝﾄ
        Dim strClassDivision                As String           '処理区分
        Dim strEmpID                        As String           '作業者ID
        Dim strSbID                         As String           'SB
        Dim strPROrderID                    As String           'P/RｵｰﾀﾞｰID
        Dim strLotSendFlag                  As String           '送品ﾌﾗｸﾞ(0:送品なし、1:送品あり)
    End Structure

    '@ﾛｯﾄﾘﾜｰｸ登録　ｳｪﾊﾘｽﾄ
    Public Structure ReWrkWFMapList
        Dim strWfId                         As String           'WFID
    End Structure

    '@ﾛｯﾄﾘﾜｰｸ登録(lot_.reworkset　送信)
    '@ﾛｯﾄﾘﾜｰｸ(一括移載)lot_.reworksetdirect
    Public Structure LotReWorkSet
        Dim strMsgVer                       As String                  'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strCarrierId                    As String                  'ｷｬﾘｱID
        Dim strLotID                        As String                  'ﾛｯﾄID
        Dim typReWrkWFMapList               As List(Of ReWrkWFMapList) 'ｳｪﾊﾘｽﾄ
        Dim strEmpID                        As String                  '作業者ID
        Dim strComments                     As String                  '作業ﾒﾓ
        Dim strLotLastUpdate                As String                  '最終更新日時
        Dim strClassDivision                As String                  'ClassDivision
        Dim lngWfMapListCnt                 As Integer                 'ｳｪﾊﾘｽﾄｶｳﾝﾄ
        Dim strOpID                         As String                  '大工程
        Dim strStepID                       As String                  '小工程
        Dim strWpID                         As String                  '装置ID
        Dim strWpName                       As String                  '装置名
        Dim strWFQuantity                   As String                  'WF枚数
        Dim strChipQuantity                 As String                  'Chip枚数
        Dim strCfFlag                       As String                  'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strLpFlag                       As String                  'LPﾌﾗｸﾞ(0：ODFﾛｯﾄ以外、1：ODFﾛｯﾄ)
        Dim strPdId                         As String                  '機種
        Dim strToLotID                      As String                  '移載ﾛｯﾄID
        Dim strReworkReason                 As String                  'ﾘﾜｰｸ理由(大分類)
        Dim strReworkSubReason              As String                  'ﾘﾜｰｸ理由(小分類)
        Dim strFlowClass                    As String                  '種別
        Dim strToCarrierId                  As String                  '移載先ｷｬﾘｱID
        Dim strMoveSkip                     As String                  '移載工程ｽｷｯﾌﾟ(0:移載あり、1:移載なし)
        Dim strDivFlag                      As String                  '分割有無(0:分割無、1:分割有)
        Dim strRouteID                      As String                  'ﾙｰﾄID
    End Structure

    '@WPのﾘｽﾄを格納するための構造体
    Public Structure WP
        Dim strWpID                         As String           'WPID
        Dim strWpName                       As String           'WP名
    End Structure

    '@ｽﾃｯﾌﾟﾘｽﾄ取得(lot_.prestate 応答)
    Public Structure StepList
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strStepDivision                 As String           '工程ﾌﾗｸﾞ(1:ﾃﾞﾌｫﾙﾄ 0:代替)
        Dim strAltNumber                    As String           '代替番号
        Dim lngWpListCnt                    As Integer          'WPﾘｽﾄｶｳﾝﾄ
        Dim strWPList                       As List(Of WP)      'WPﾘｽﾄ
    End Structure

    '@ﾛｯﾄ現在状態取得(lot_.curstate 応答)
    Public Structure Lotprestate
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strFlowClass                    As String           '流動区分
        Dim strGrbClass                     As String           'GRB区分
        Dim strPdId                         As String           '機種ID
        Dim strPdName                       As String           '機種名
        Dim strSteplist                     As List(Of StepList)'ｽﾃｯﾌﾟﾘｽﾄ
        Dim strNowST                        As String           'LOT状態
        Dim strDispatchStartTime            As String           '作業開始予定時刻
        Dim strDispatchEndTime              As String           '終了予定時刻
        Dim strEngEmpId                     As String           '技術担当者ID
        Dim strEngEmpName                   As String           '技術担当者名
        Dim strWorkDirectFlg                As String           '作業指示
        Dim strWorkCondition                As String           '作業条件
        Dim strSpecialFlg                   As String           '特殊特性
        Dim strWfNum                        As String           'WF枚数
        Dim strLimitTime                    As String           '制限時間(時間制約)
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strLotHoldFlag                  As String           'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strLotLastUpdate                As String           'LOT最終更新日時
        Dim strStartTime                    As String           '作業開始時刻(実績)
        Dim strChipQuantity                 As String           '良品ﾁｯﾌﾟ数
        Dim strChipOutQuantity              As String           '総不良品ﾁｯﾌﾟ数
        Dim strChipCurrentOutQuantity       As String           '現不良品ﾁｯﾌﾟ数
        Dim strChipForwardQuantity          As String           '総払出品ﾁｯﾌﾟ数
        Dim strChipCurrentForwardQuantity   As String           '現払出品ﾁｯﾌﾟ数
        Dim strMasPdVersion                 As String           '工順ﾊﾞｰｼﾞｮﾝ
        Dim strWpTypeFlag                   As String           'WPﾀｲﾌﾟﾌﾗｸﾞ
        Dim strEqType                       As String           '装置ﾀｲﾌﾟ
        Dim strCollectionID                 As String           '収集項目ID
        Dim strCollectionVersion            As String           '収集項目ﾊﾞｰｼﾞｮﾝ
        Dim strBatchId                      As String           'ﾊﾞｯﾁID
        Dim strCarrierId                    As String           'ﾛｰﾀﾞｰｷｬﾘｱID
        Dim strReworkRouteID                As String           'ﾘﾜｰｸﾙｰﾄID
        Dim strCfFlag                       As String           'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strCfCompFlag                   As String           'CFﾛｯﾄ確定可能ﾌﾗｸﾞ(0；CFﾛｯﾄ確定不可　1；CFﾛｯﾄ確定可能)
        Dim strCFMoveDataFlag               As String           'CF移載情報入力ﾌﾗｸﾞ(0：ﾃﾞｰﾀなし、1：ﾃﾞｰﾀあり)
        Dim strCarrierTypeID                As String           'ｷｬﾘｱﾀｲﾌﾟID
        Dim strVaFlag                       As String           '無機ﾌﾗｸﾞ(0:有機　1：無機)
        Dim strTpalClass                    As String           'TPAL設定
        Dim strTpalChipQuantity             As String           'TPAL貼合数(TPAL_CLASS設定がある場合のみ)
        Dim strCarrierCategoryId            As String           'ｷｬﾘｱｶﾃｺﾞﾘID(現工程)
        Dim strNextCarrierCategoryId        As String           'ｷｬﾘｱｶﾃｺﾞﾘID(次工程)
        Dim lngStepListCnt                  As Integer          'ｽﾃｯﾌﾟﾘｽﾄｶｳﾝﾄ
    '----------------------------------------------------------------
        Dim strOpName                       As String           '大工程名
        Dim strOpID                         As String           '大工程ID
        Dim strStepName                     As String           '小工程名
        Dim strStepID                       As String           '小工程ID
        Dim strAltNumber                    As String           '代替番号
        Dim strWpID                         As String           'WPID
        Dim strWpName                       As String           'WP名
        Dim strReworkFlag                   As String           'ﾘﾜｰｸﾌﾗｸﾞ(0；無し　1；分割先(子)　2；分割元(親)　3；全数)
        Dim strCoverFlag                    As String           '貼り合せ状態ﾌﾗｸﾞ(0:貼り合せ未完、1:貼り合せ済み)
        Dim strLotScrapSetID                As String           '不良項目ｾｯﾄID
        Dim strWarnTime                     As String           '警告時間
        Dim strFlowType                     As String           '流動ﾀｲﾌﾟ(Null;移載工程以外、M;移載工程)
        Dim strRestrictTypeID               As String           '制限ﾀｲﾌﾟ(1;制限時間以下、2;制限時間以上)
        Dim strHoldTermDate                 As String           '保留期限
        Dim strSpecialRouteID               As String           '追加ﾙｰﾄID
        Dim strEntryID                      As String           'ｴﾝﾄﾘID(分割統合画面で使用)
        Dim strCFCarrierID                  As String           'CFｷｬﾘｱID
        Dim strLpFlag                       As String           'LPﾌﾗｸﾞ(0：ODFﾛｯﾄ以外、1：ODFﾛｯﾄ)
        Dim strUnloaderCarrierID            As String           'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
        Dim strFtpDataFlag                  As String           'ｵﾌﾗｲﾝFTPﾌﾗｸﾞ(0：対象外/1：対象)
        Dim strPROrderID                    As String           'P/RｵｰﾀﾞｰID
        Dim strSendSBID                     As String           '送品先ID
        Dim strSendSBName                   As String           '送品先名(和名)
        Dim strLotSendFlag                  As String           '送品ﾌﾗｸﾞ(0:送品なし、1:送品あり)
        Dim strUseId                        As String           '機種区分(Product、Dummy、Monitor etc…)
        Dim strBatchSeqNum                  As String           'ﾊﾞｯﾁ処理順
        Dim strMesModeId                    As String           '運用ﾓｰﾄﾞ
        Dim strScreenSize                   As String           'ｽｸﾘｰﾝｻｲｽﾞ
        Dim strTokusyu                      As String           '(パ検)特殊表示
        Dim strColorCd                      As String           '指定色
        Dim strTrvGRBClass                  As String           '流動票GRB

    End Structure

    '@装置別ﾎﾟｰﾄﾘｽﾄ
    Public Structure LotWPPortList
        Dim strPortID                       As String           'ﾎﾟｰﾄID
        Dim strPortName                     As String           'ﾎﾟｰﾄ名
        Dim strPortType                     As String           'ﾎﾟｰﾄﾀｲﾌﾟ
    End Structure

    '@ﾛｯﾄ別装置一覧取得(lot_.equipmnt 応答)(mas_.wpports_　でも使用)
    Public Structure Lotequipmnt
        Dim strWpID                         As String                 '装置ID
        Dim strWpName                       As String                 '装置名
        Dim lngPortCnt                      As Integer                'ﾎﾟｰﾄ数
        Dim strPortList                     As List(Of LotWPPortList) 'ﾎﾟｰﾄﾘｽﾄ
    End Structure

    '@ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ
    Public Structure RecipeBodyList
        Dim strRecipeItem                   As String           'ﾚｼﾋﾟｱｲﾃﾑ名
        Dim strRecipeValue                  As String           '値
        Dim strVariableFlag                 As String           'ﾚｼﾋﾟ値変更可否(0:不可　1:可)
        Dim strValueType                    As String           'A:文字ﾀｲﾌﾟ N:数字ﾀｲﾌﾟ
        Dim strItemValidDigit               As String           '小数点以下制御桁数
    End Structure

    '@ﾛｯﾄ別ﾚｼﾋﾟﾘｽﾄ一覧取得(lot_.recplist 応答)
    Public Structure Lotrecplist
        Dim strSlotPosition                 As String                  'ｽﾛｯﾄ№
        Dim strWfId                         As String                  'WFID
        Dim strRecipeId                     As String                  'ﾚｼﾋﾟID
        Dim strRecipeComment                As String                  'ﾚｼﾋﾟｺﾒﾝﾄ
        Dim strDefaultFlag                  As String                  'ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
        Dim lngRecipeBodyList               As Integer                 'ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ数
        Dim typRecipeBodyList               As List(Of RecipeBodyList) 'ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ
    End Structure

    '@ﾛｯﾄ保留情報
    Public Structure LotHoldset
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strHoldReasonID                 As String           '保留理由ID
        Dim strHoldComment                  As String           '保留理由ｺﾒﾝﾄ
        Dim strHoldTermDate                 As String           '保留期限
        Dim strHoldEmpID                    As String           '保留責任者
        Dim strEmpID                        As String           '作業者ID
        Dim strLotLastUpdate                As String           'ﾛｯﾄ最終更新日時
        Dim strHoldEditTime                 As String           '保留処理日時
    End Structure

    '@ﾛｯﾄ保留情報
    Public Structure LotHoldRelesset
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strHoldReleseComment            As String           '保留解除ｺﾒﾝﾄ
        Dim strEmpID                        As String           '作業者ID
        Dim strLotLastUpdate                As String           'ﾛｯﾄ最終更新日時
        Dim strEntryTime                    As String           '(保留)登録日時
    End Structure

    '@投入のWFMAP
    Public Structure LotThrowinWFMapList
        Dim strSlotNo                       As String           'ｽﾛｯﾄ№
        Dim strInvLotId                     As String           '在庫ﾛｯﾄID
    End Structure
    '@投入
    Public Structure LotThrowin
        Dim strMsgVer                       As String                       'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strLotID                        As String                       'LotID
        Dim strCarrierId                    As String                       'ｷｬﾘｱID
        Dim strEmpID                        As String                       '作業者ID
        Dim typWFMapList                    As List(Of LotThrowinWFMapList) 'WFﾏｯﾌﾟのﾘｽﾄ
        Dim strLotPriority                  As String                       '優先度
        Dim strOnlineFlag                   As String                       'ｵﾝﾗｲﾝﾌﾗｸﾞ
        Dim strWpID                         As String                       '投入装置ID
    End Structure

    '@ﾛｯﾄ作業開始(lot_.wrkstart 要求)
    Public Structure Lotwrkstart
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strWpID                         As String           'WPID
        Dim strPortID                       As String           'ﾎﾟｰﾄID
        Dim strEngEmpId                     As String           '作業者ID
        Dim strLotLastUpdate                As String           'LOT最終更新日時
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strAltNumber                    As String           '代替番号
        Dim strToCarriaID                   As String           'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
        Dim strToPortID                     As String           'ｱﾝﾛｰﾀﾞｰﾎﾟｰﾄID
        Dim strLoaderUnloaderFlag           As String           'ﾛｰﾀﾞｰｱﾝﾛｰﾀﾞｰﾌﾗｸﾞ
        Dim strCFCarrierID                  As String           'CFｷｬﾘｱID
    End Structure

    '@ﾛｯﾄ保留理由
    Public Structure HoldReasonList
        Dim strHoldReasonID                 As String           '保留理由ID
        Dim strHoldReasonName               As String           '保留理由名
    End Structure

    '@部材ﾘｽﾄ
    Public Structure PartList
        Dim strPartCode                     As String           '部材ｺｰﾄﾞ
        Dim strPartName                     As String           '部材名
        Dim strVenderClassId                As String           '部品ID(部材ID)
        Dim strVenderName                   As String           'ﾍﾞﾝﾀﾞｰ名
        Dim strPdId                         As String           '機種ID
        Dim objParentFrom                   As Form             '呼出元ﾌｫｰﾑ
    End Structure

    '@機種一覧
    Public Structure ProductList
        Dim strProductID                    As String           '機種ID
        Dim strProductName                  As String           '機種名
        Dim strMaxWFCount                   As String           '最大WF枚数
        Dim strParentPdId                   As String           '親機種ID(2004/07/28:追加　出口)
        Dim strMasPdVersion                 As String           'PDﾊﾞｰｼﾞｮﾝ
        Dim strLcDirection                  As String           'L/R表示
        Dim strForeColor                    As String           '文字色格納(ｺﾝﾎﾞL/R色に使用)
        Dim strBackColor                    As String           '背景色格納(ｺﾝﾎﾞL/R色に使用)
        Dim strUseId                        As String           '用途ID
        Dim strCfFlag                       As String           'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strLpFlag                       As String           'LPﾌﾗｸﾞ(0：ODFﾛｯﾄ以外、1：ODFﾛｯﾄ)
    End Structure

    '@装置使用工程
    Public Structure Wpuseinfo
        Dim strSTEPNUM                      As String           'STEPNUM
        Dim strOpID                         As String           'OPID
        Dim strStepID                       As String           'STEPID
        Dim strAltStepFlag                  As String           '代替工程有無ﾌﾗｸﾞ
        Dim strReworkStepFlag               As String           'ﾘﾜｰｸ工程有無ﾌﾗｸﾞ
        Dim strSpecialStepFlag              As String           '特殊工程有無ﾌﾗｸﾞ
        Dim strReworkRouteID                As String           'ﾘﾜｰｸ時ﾙｰﾄID
        Dim strSpecialRouteID               As String           '特殊ﾙｰﾄID
        Dim strActionFlag                   As String           'ｱｸｼｮﾝﾌﾗｸﾞ(0：なし/1:作業開始/2：作業終了/4：全ﾀｲﾐﾝｸﾞ)
    End Structure

    '@ﾛｯﾄ保留情報
    Public Structure LotHoldinfo
        Dim strHoldReasonID                 As String           '停止保留発生時理由ID
        Dim strHoldReasonName               As String           '停止保留発生時理由名
        Dim strHoldTime                     As String           '停止保留発生時刻
        Dim strHoldComment                  As String           '保留ｺﾒﾝﾄ
        Dim strHoldEmpID                    As String           '保留責任者
        Dim strHoldEmpName                  As String           '保留責任者名
        Dim strHoldTermDate                 As String           '保留期限
        Dim strRestrictFlag                 As String           '制限ﾌﾗｸﾞ
        Dim strHoldStayDate                 As String           '保留期間
        Dim strEntryTime                    As String           'EntryTime
    End Structure

    '@ﾛｯﾄ保留情報
    Public Structure LotHoldInfoList
        Dim typHoldInfoList                 As List(Of LotHoldinfo) '構造体
        Dim lngHoldInfoListCnt              As Integer              'ﾘｽﾄｶｳﾝﾄ
    End Structure

    '@ﾎﾟｰﾄﾘｽﾄ
    Public Structure PortList
        Dim strPortID                       As String           'ﾎﾟｰﾄID
        Dim strPortName                     As String           'ﾎﾟｰﾄ名
        Dim strPortType                     As String           'ﾎﾟｰﾄﾀｲﾌﾟ
        Dim strPortStatus                   As String           'ﾎﾟｰﾄ状態
    End Structure

    '@装置ﾘｽﾄ
    Public Structure WpList
        Dim strWpID                         As String            '装置ID
        Dim strWpName                       As String            '装置名
        Dim strWpStatusName                 As String            '装置状態
        Dim lngPortCnt                      As Integer           'ﾎﾟｰﾄ数
        Dim typPortList                     As List(Of PortList) 'ﾎﾟｰﾄﾘｽﾄ
        Dim strAltNumber                    As String            '代替番号
        Dim strMaxProcessBox                As String            '最大処理単位ﾎﾞｯｸｽ数
        Dim strEqType                       As String            'EQﾀｲﾌﾟﾌﾗｸﾞ
        Dim strLoaderUnloaderFlag           As String            'ﾛｰﾀﾞｰｱﾝﾛｰﾀﾞｰﾌﾗｸﾞ
        Dim strAfterCarrierTypeId           As String            'UNLOADERｷｬﾘｱﾀｲﾌﾟID
        Dim strCleanCondition               As String            '洗浄条件ﾌﾗｸﾞ
        Dim strMesModeId                    As String            '運用ﾓｰﾄﾞ
        Dim strPortStatusID                 As String            'ﾎﾟｰﾄ状態ID
        Dim strPortStatus                   As String            'ﾎﾟｰﾄ状態(和名)
        Dim strCarrierId                    As String            'ｷｬﾘｱID(搭載SMIF)
        Dim strLotRecipeFlag                As String            'ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ(0：枚葉可/1：枚葉不可)
        Dim strBatchComposeType             As String            'ﾊﾞｯﾁ自動編成方式(0：手動/1：自動)
    End Structure

    '@ﾛｯﾄ装置情報取得(lot_.wplist__ 応答)
    Public Structure LotWpList
        Dim lngWPCnt                        As Integer          '装置数
        Dim typWpList                       As List(Of WpList)  '装置ﾘｽﾄ
    End Structure

    '@技術担当一覧
    Public Structure TechManList
        Dim strTechManID                    As String           '技術担当ID
        Dim strTechManName                  As String           '技術担当名
    End Structure

    '@投入LOT予定一覧
    Public Structure typLotRlst
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strPdId                         As String           '機種ID
        Dim strPdName                       As String           '機種名
        Dim strFlowClass                    As String           '種別ID
        Dim strFlowClassName                As String           '種別名
        Dim strWfNum                        As String           'WF枚数
        Dim strPlanThrowinDate              As String           '投入予定日
        Dim strMasVer                       As String           '工順Version
        Dim strEngEmpId                     As String           '技術担当ID
        Dim strEngEmpName                   As String           '技術担当者名
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strLcDirection                  As String           '液晶方向(L/R/Null)
        Dim strSendSBID                     As String           '送品先
        Dim strSbArea                       As String           'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        Dim strGRBClass                     As String           'GRBｸﾗｽ
        Dim strLaserMarkerSkipFlag          As String           'ﾚｰｻﾞｰﾏｰｶｽｷｯﾌﾟﾌﾗｸﾞ
        Dim strLPFlag                       As String           'LPﾌﾗｸﾞ
        Dim strCFFlag                       As String           'CFﾌﾗｸﾞ
    End Structure

    '@工順元ﾛｯﾄ一覧
    Public Structure typOpLotLst
        Dim strLotID                        As String           '生成LOTID
        Dim strProductID                    As String           '機種ID
        Dim strProduct                      As String           '機種名
        Dim strDivisionID                   As String           '種別ID
        Dim strDivision                     As String           '種別名
        Dim strEntryDate                    As String           'ﾛｯﾄ投入日
        Dim strEmpID                        As String           '責任者ID
        Dim strTexhManNmae                  As String           '技術担当者名
        Dim strLotStatusFLG                 As String           'ﾛｯﾄ状態ﾌﾗｸﾞ
        Dim strEntryID                      As String           'ｴﾝﾄﾘID
        Dim strEntryName                    As String           'ｴﾝﾄﾘ名
        Dim strLcDirection                  As String           '液晶方向(L/R/Null)
        Dim strSendSBID                     As String           '送品先
        Dim strSbArea                       As String           'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
    End Structure

    '@ﾍﾞﾝﾀﾞｰﾛｯﾄID
    Public Structure typInvLotList
        Dim strInvLotId                     As String           '在庫ﾛｯﾄID
        Dim strInvNum                       As String           '在庫数
    End Structure

    '@ﾚｼﾋﾟ変更送信のﾚｼﾋﾟﾘｽﾄ
    Public Structure RecpList
        Dim strWfId                         As String                  'WFID
        Dim strRecpID                       As String                  'ﾚｼﾋﾟID
        Dim lngRecipeBodyList               As Integer                 'ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ数
        Dim typRecipeBodyList               As List(Of RecipeBodyList) 'ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ
    End Structure

    '@ﾚｼﾋﾟ変更送信(lot_.recpchng 送信)
    Public Structure LotRecpChng
        Dim strSbID                         As String            'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strClassDivision                As String            '処理区分
        Dim strLotID                        As String            'ﾛｯﾄID
        Dim strOpID                         As String            '大工程ID
        Dim strStepID                       As String            '小工程ID
        Dim strWpID                         As String            'WPID
        Dim strEmpID                        As String            '作業者ID
        Dim strComments                     As String            'ｺﾒﾝﾄ
        Dim strLotLastUpdate                As String            '最終更新日時
        Dim strAltNumber                    As String            '代替番号
        Dim typRecpList                     As List(Of RecpList) 'ﾚｼﾋﾟﾘｽﾄ
    End Structure

    '@ｱｸｼｮﾝ予約ﾘｽﾄ取得
    Public Structure LotActList
        Dim strLotActionID                  As String           'ｱｸｼｮﾝ予約ID
        Dim strLotActionTypeID              As String           'ｱｸｼｮﾝ予約ﾀｲﾌﾟID
        Dim strMessage                      As String           '表示ﾒｯｾｰｼﾞ
        Dim strWorkDirectionID              As String           '作業指示書№
        Dim strLotID                        As String           'ﾛｯﾄID(ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面用)
        Dim strFlowClass                    As String           '流動区分(ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面用)
        Dim strLotActionTypeName            As String           'ｱｸｼｮﾝ予約ﾀｲﾌﾟ名(ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面用)
        Dim strActionTrigger                As String           'ｱｸｼｮﾝﾄﾘｶﾞｰ名(ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面用)
        Dim strOpID                         As String           '大工程名(ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面用)
        Dim strStepID                       As String           '小工程名(ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面用)
        Dim strEngEmpName                   As String           '技術担当者名
        Dim strStopHoldFlag                 As String           '停止/保留ﾌﾗｸﾞ
        Dim strEmpID                        As String           '作業者ID
        Dim strEmpName                      As String           '作業者名
    End Structure

    '@ｱｸｼｮﾝ予約ﾘｽﾄ取得(lot_.actlist_ 受信)
    Public Structure LotAction
        Dim lnglstCnt                       As Integer             'ﾛｯﾄｱｸｼｮﾝﾘｽﾄの数
        Dim strActionFlag                   As String              'ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ(0:実行なし、1:停止、２:保留)
        Dim typLotActList                   As List(Of LotActList) 'ｱｸｼｮﾝ予約ﾘｽﾄ
    End Structure

    '@ﾏｽﾀｰﾚｼﾋﾟﾘｽﾄ
    Public Structure MasRecpList
        Dim strRecpID                       As String           'ｱｸｼｮﾝ予約ID
        Dim strRecpComment                  As String           '表示ﾒｯｾｰｼﾞ
    End Structure

    '@ﾏｽﾀｰﾚｼﾋﾟﾘｽﾄ取得(mas_.recplist　受信)
    Public Structure MasRecp
        Dim lnglstCnt                       As Integer              'ﾚｼﾋﾟﾘｽﾄの数
        Dim typRecpList                     As List(Of MasRecpList) '表示ﾒｯｾｰｼﾞ
    End Structure

    '@機能ﾊﾞｰｼﾞｮﾝ取得
    Public Structure FunctionList
        Dim strFunctionID                   As String           '機能ID
        Dim strFunctionName                 As String           '機能名
        Dim strFormName                     As String           'ﾌｫｰﾑ名
        Dim strTakingOverFlag               As String           '引継ぎﾌﾗｸﾞ
        Dim strEnableFlag                   As String           '有効/無効ﾌﾗｸﾞ
    End Structure

    '@機能ﾊﾞｰｼﾞｮﾝ取得(util.funcinfo 受信)
    Public Structure UtilFuncInfo
        Dim lngListCnt                      As Integer               'ﾘｽﾄｶｳﾝﾄ
        Dim typFunctionList                 As List(Of FunctionList) '機能ﾊﾞｰｼﾞｮﾝ構造体
    End Structure

    '@ﾒﾆｭｰお気に入りリスト
    Public Structure FavoriteList
        Dim strSeqNum                       As String           '順番
        Dim strFunctionID                   As String           '機能名
    End Structure

    '@ﾒﾆｭｰお気に入り取得(util.refmenu_　受信)
    Public Structure refmenu_
        Dim strTakingOverFlag               As String                '引継ぎﾌﾗｸﾞ
        Dim typFavoriteList                 As List(Of FavoriteList) 'お気に入りﾘｽﾄ
    End Structure

    '@ﾒﾆｭｰお気に入り登録(util.regmenu_　送信)
    Public Structure regmenu_
        Dim strLogInID                      As String                'ﾛｸﾞｲﾝ名
        Dim strMenuKind                     As String                'ﾒﾆｭｰ種別
        Dim strTakingOverFlag               As String                '引継ぎﾌﾗｸﾞ
        Dim typFavoriteList                 As List(Of FavoriteList) 'お気に入りﾘｽﾄ
    End Structure

    '@ﾒﾆｭｰお気に入り削除(util.delmenu_　送信)
    Public Structure delmenu_
        Dim strLogInID                      As String           'ﾛｸﾞｲﾝ名
        Dim strMenuKind                     As String           'ﾒﾆｭｰ種別
    End Structure

    '@優先順位ﾏｽﾀ項目格納構造体
    Public Structure typPriorityReasonList
        Dim strMasPriorityId                As String           '優先順位NO(ﾏｽﾀ)
        Dim strMasPriorityName              As String           '優先順位名(ﾏｽﾀ)
    End Structure

    '@ﾚｽﾎﾟﾝｽ測定送信(tm__.response 送信)
    Public Structure TmResponse
        Dim strHostName                     As String           'ﾎｽﾄ名
        Dim strIPaddress                    As String           'IPｱﾄﾞﾚｽ
        Dim strExeName                      As String           'EXEﾌｧｲﾙ名
        Dim strFormName                     As String           '画面識別名
        Dim strEventName                    As String           'ｲﾍﾞﾝﾄ(処理)名
        Dim strExeTime                      As String           '処理時間(msec)
    End Structure

    '@ﾚｽﾎﾟﾝｽ測定送信用構造体
    Public Structure typTmResponseList
        Dim strFormName                     As String           '画面識別名
        Dim strEventName                    As String           'ｲﾍﾞﾝﾄ(処理)名
        Dim tmStartDateTime                 As DateTime         '処理開始日時
        Dim lngStartCancelStatus            As Integer          '測定開始中止ｽﾃｰﾀｽ(0:通常、1:中止)
    End Structure
    Public ptypTmResponseList               As Dictionary(Of Tuple(Of String, String), typTmResponseList) 'ﾚｽﾎﾟﾝｽ測定送信用

    '@品質記録ﾃﾞｰﾀ用構造体(lot_.qtylist受信　および　lot_.wrkend__送信　で使用)
    Public Structure QuarityData
        Dim strParameterCode                As String           '入力項目ID
        Dim strParameterName                As String           '入力項目名
        Dim strDataTypeID                   As String           '型
        Dim strData                         As String           '入力ﾃﾞｰﾀ(mas_.inputqtyでは未使用)
        Dim strUnit                         As String           '単位
        Dim strSTDLower                     As String           '管理下限
        Dim strSTDMiddle                    As String           '管理中央
        Dim strSTDUpper                     As String           '管理上限
        Dim strRequirefFG                   As String           '必須ﾌﾗｸﾞ
    End Structure
    '@品質記録項目取得用構造体
    Public Structure MasInputQty
        Dim strLotID                        As String               'ﾛｯﾄID
        Dim strOpID                         As String               '大工程ID
        Dim strStepID                       As String               '小工程ID
        Dim strWpID                         As String               'WPID
        Dim strRecpID                       As String               'ﾚｼﾋﾟID
        Dim strWfId                         As String               'ｳｪﾊID
        Dim strEmpID                        As String               '作業者ID
        Dim strLstUpDate                    As String               '最終更新日時
        Dim lngListCnt                      As Integer              'ﾘｽﾄのｶｳﾝﾄ
        Dim typQuarityData                  As List(Of QuarityData) '取得した品質項目ﾃﾞｰﾀ
    End Structure

    '@作業記録ﾃﾞｰﾀ用構造体(lot_.wrklist受信　および　lot_.wrkend__送信　で使用)
    Public Structure WorkData
        Dim strItemCode                     As String           '入力項目ID
        Dim strItemName                     As String           '入力項目名
        Dim strItemData                     As String           '入力ﾃﾞｰﾀ(mas_.inputwrkでは未使用)
        Dim strItemType                     As String           '型
    End Structure

    '@作業記録項目ﾃﾞｰﾀ用構造体(lot_.wrklist受信)
    Public Structure MasInputWrk
        Dim lngListCnt                      As Integer           'ﾘｽﾄのｶｳﾝﾄ
        Dim typWorkData                     As List(Of WorkData) '取得した作業記録ﾃﾞｰﾀ
    End Structure

    '@不良項目ﾃﾞｰﾀ用構造体(mas_.inputscp受信　および　lot_.wrkend__送信　で使用)
    Public Structure ScrapData
        Dim strItemCode                     As String           '入力項目ID
        Dim strItemName                     As String           '入力項目名
        Dim strItemData                     As String           '入力ﾃﾞｰﾀ(mas_.inputscpでは未使用)
    End Structure

    '@不良項目ﾃﾞｰﾀ取得用構造体(mas_.inputscp受信)
    Public Structure MasInputScp
        Dim lngListCnt                      As Integer            'ﾘｽﾄのｶｳﾝﾄ
        Dim typScrapData                    As List(Of ScrapData) '取得した不良項目ﾃﾞｰﾀ
    End Structure

    '@ﾛｯﾄ作業終了(lot_.wrkend 要求)
    Public Structure LotwrkEnd
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strEngEmpId                     As String           '作業者ID
        Dim strComment                      As String           'ｺﾒﾝﾄ
        Dim strLotLastUpdate                As String           'LOT最終更新日時
    End Structure

    '@WP状態取得(lot_.reqstwpid　受信)
    Public Structure WPStatus
        Dim strWpID                         As String           'WPID
        Dim strWpName                       As String           'WP名
        Dim strPortID                       As String           'WPﾎﾟｰﾄID
    End Structure

    '@次工程のﾘｽﾄを格納する構造体
    Public Structure NextStep
        Dim lngNextStepListCnt              As Integer          '次小工程ﾘｽﾄｶｳﾝﾄ
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strNextOpId                     As String           '次大工程ID
        Dim strNextStepId                   As String           '次小工程ID
        Dim strStepDivision                 As String           '工程ﾌﾗｸﾞ(0：代替工程、1：ﾃﾞﾌｫﾙﾄ)
        Dim lngWpListCnt                    As Integer          'WPのﾘｽﾄｶｳﾝﾄ
        Dim strWPList                       As List(Of WP)      'WPﾘｽﾄ
    End Structure

    '@次工程取得(lot_.nextstepinfo　受信)
    Public Structure LotNextStep
        Dim lngNextStepListCnt              As Integer           '次小工程ﾘｽﾄｶｳﾝﾄ
        Dim strNextStepList                 As List(Of NextStep) '次小工程ﾘｽﾄ
    End Structure

    '@ﾛｯﾄ詳細情報取得(lot_.detailes_ 受信)
    Public Structure LotDetail
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strPdId                         As String           '機種ID
        Dim strPdName                       As String           '機種名
        Dim strPlanThrowInNum               As String           '計画ﾌﾛｱ投入数
        Dim strPlanFinishNum                As String           '計画ﾌﾛｱ仕上数
        Dim strThrowInTypeID                As String           'ﾌﾛｱ投入形態ID
        Dim strFinalTypeID                  As String           'ﾌﾛｱ終了形態ID
        Dim strPlanThrowinDate              As String           '計画投入予定日(yyyy/mm/dd)
        Dim strPlanFinishDate               As String           '計画終了予定日(yyyy/mm/dd)
        Dim strRouteID                      As String           '工順OID
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strOrderNum                     As String           'ｵｰﾀﾞｰNo
        Dim strEnactMent                    As String           '制定区分
        Dim strDrowingNum                   As String           '図面番号
        Dim strComment                      As String           'ｺﾒﾝﾄ
        Dim strLotPriority                  As String           '優先度
        Dim strFinishInventry               As String           '完成品在庫ﾎﾟﾝﾄ
        Dim strSendOpCode                   As String           '送品先工程ｺｰﾄﾞ
        Dim strPlannedTime                  As String           '計画作成日時
        Dim strPdTypeCode                   As String           '機種ﾀｲﾌﾟｺｰﾄﾞ
        Dim strThrowInForm                  As String           '投入形態
        Dim strTagNum                       As String           'TAGNO
        Dim strDivisionLotEndNum            As String           '分割ﾛｯﾄ最終No
        Dim strProductionType               As String           '生産種別
        Dim strListFlag                     As String           '帳票ﾌﾗｸﾞ
        Dim strDivideFlag                   As String           '分割ﾌﾗｸﾞ
        Dim strReviValFlag                  As String           '再生回数
        Dim strScreenSize                   As String           '画面ｻｲｽﾞ
        Dim strScreenResolution             As String           '解像度
        Dim strUpperSystemOerder            As String           '上位ｼｽﾃﾑｵｰﾀﾞ
        Dim strLotVersion                   As String           'ﾛｯﾄﾊﾞｰｼﾞｮﾝ
        Dim strFlowClass                    As String           '流動区分
        Dim strLotFlowType                  As String           'ﾛｯﾄ流動区分
        Dim strJFlowType                    As String           '実装流動区分
        Dim strProductType                  As String           '製品型番
        Dim strProductCode                  As String           '製品ｺｰﾄﾞ
        Dim strSendSBID                     As String           '送品先SBIB
        Dim strRecivedSBID                  As String           '受入元SBIB
        Dim strExceptionClass               As String           '例外区分
        Dim strExceptionCount               As String           '例外回数
        Dim strEntryType                    As String           '登録日時
        Dim strEditTime                     As String           '最終更新日
    End Structure

    '@ﾛｯﾄ処理開始(lot_.prcstart 要求)
    Public Structure Lotprcstart
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strWpID                         As String           'WPID
        Dim strPortID                       As String           'ﾎﾟｰﾄID
        Dim strEngEmpId                     As String           '作業者ID
        Dim strLotLastUpdate                As String           'LOT最終更新日時
        Dim strComment                      As String           'ｺﾒﾝﾄ
        Dim strEQFlag                       As String           '装置ﾌﾗｸﾞ
        Dim strToCarrierId                  As String           'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
        Dim strToPortID                     As String           'ｱﾝﾛｰﾀﾞｰﾎﾟｰﾄID
    End Structure

    '@装置用途ﾏｽﾀ取得(mas_.equse___ 受信)
    Public Structure UseList
        Dim strUseId                        As String           '用途ID
        Dim strUseName                      As String           '用途名
        Dim strUseEnableMode                As String           '装置状態ﾓｰﾄﾞ
        Dim strUseStopFlag                  As String           '装置停止ﾌﾗｸﾞ
        Dim strMessageID                    As String           'ﾒｯｾｰｼﾞID
        Dim strMessage                      As String           'ﾒｯｾｰｼﾞ
        Dim strNormalStateFlag              As String           '装置通常ﾌﾗｸﾞ(0：通常以外、1:通常)
    End Structure

    '@装置用途変更(eq__.usechange 要求)
    Public Structure Usechange
        Dim strWpID                         As String           'WPID
        Dim strWpName                       As String           '装置名
        Dim strOldUseID                     As String           '変更前用途ID
        Dim strUseId                        As String           '変更後用途ID
        Dim strLotLastUpdate                As String           '最終更新日時
        Dim strUseReserveDate               As String           '予約日時
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strEmpID                        As String           '作業者ID
        Dim strWpStopFlag                   As String           'WP停止ﾌﾗｸﾞ
        Dim strMessageID                    As String           'ﾒｯｾｰｼﾞID
    End Structure

    '@不良/傾向/保留/払出し項目
    Public Structure MasItem
        Dim strItemID                       As String           '入力項目
        Dim strItemName                     As String           '入力名
        Dim strSeqNum                       As String           '表示順番
    End Structure

    '@不良/傾向/保留/払出し項目ﾘｽﾄ取得(mas_scplist_、mas_tendlist、mas_holdreason、mas_takelist、mas_stopcode、mas_releasecode、mas_receivecode)
    Public Structure MasItemList
        Dim strLotEventId                   As String           'ﾛｯﾄｲﾍﾞﾝﾄID
        Dim lngListCnt                      As Integer          'ﾘｽﾄｶｳﾝﾄ
        Dim typeMasItem                     As List(Of MasItem) '不良/傾向/保留/払出しﾘｽﾄ
    End Structure
    Public ptypMasItemList              As MasItemList

    '@ｽﾛｯﾄﾏｯﾌﾟ構造体
    Public Structure MasPdMap
        Dim strRowNum                       As String           'WF行番号
        Dim strStartColumn                  As String           '開始列番号
        Dim strChipCount                    As String           'ﾁｯﾌﾟ数
    End Structure

    '@ｽﾛｯﾄﾏｯﾌﾟ情報ﾘｽﾄ取得(mas_.pdmap__ 受信)
    Public Structure MasPdMapList
        Dim lngListCnt                      As Integer           'ﾘｽﾄｶｳﾝﾄ
        Dim typRowNumList                   As List(Of MasPdMap) 'ｽﾛｯﾄﾏｯﾌﾟ情報ﾘｽﾄ
        Dim strLostChipNo                   As String            '欠損ﾁｯﾌﾟ№
    End Structure

    '@ﾁｯﾌﾟ情報構造体
    Public Structure ChipList
        Dim strChipId                       As String           'ﾁｯﾌﾟID
        Dim strClass                        As String           '区分
        Dim strClassID                      As String           '区分ID
        Dim strElectricCode                 As String           '電特ｺｰﾄﾞ
        Dim strElectricGrade                As String           '電特ｸﾞﾚｰﾄﾞ
        Dim strWaistStatus                  As String           'WAIST状態
        Dim strWaistCode                    As String           'WAIST状態ｺｰﾄﾞ
        Dim strNowstepEditFlag              As String           '自工程更新ﾌﾗｸﾞ(0:自工程で更新なし、1:自工程で更新あり)
        Dim strBeforeClass                  As String           '自工程前最新区分
        Dim strBeforeClassID                As String           '自工程前最新区分ID
    End Structure

    '@WFﾏｯﾌﾟ情報取得用構造体(wf__.mapinfo_)
    Public Structure WFMapInfo
        Dim lngListCnt                      As Integer           'ﾘｽﾄｶｳﾝﾄ
        Dim strChipQuantity                 As String            '良品ﾁｯﾌﾟ数量
        Dim strChipOutQuantity              As String            '総不良ﾁｯﾌﾟ数量
        Dim strChipCurrentOutQuantity       As String            '現不良ﾁｯﾌﾟ数量
        Dim strChipForwardQuantity          As String            '総払出ﾁｯﾌﾟ数量
        Dim strChipCurrentForwardQuantity   As String            '現払出ﾁｯﾌﾟ数量
        Dim strChipQuantityLotL             As String            '良品ﾁｯﾌﾟ数LOT-左
        Dim strChipQuantityLotR             As String            '良品ﾁｯﾌﾟ数LOT-右
        Dim strChipQuantityWfL              As String            '良品ﾁｯﾌﾟ数Wf-左
        Dim strChipQuantityWfR              As String            '良品ﾁｯﾌﾟ数Wf-右
        Dim strChipOutQuantityLotL          As String            '不良数LOT-左
        Dim strChipOutQuantityLotR          As String            '不良数LOT-右
        Dim strChipOutQuantityWfL           As String            '不良数WF-左
        Dim strChipOutQuantityWfR           As String            '不良数WF-右
        Dim strChipCurrentOutQuantityLotL   As String            '現工程不良数LOT-左
        Dim strChipCurrentOutQuantityLotR   As String            '現工程不良数LOT-右
        Dim strChipCurrentOutQuantityWfL    As String            '現工程不良数Wf-左
        Dim strChipCurrentOutQuantityWfR    As String            '現工程不良数Wf-右
        Dim typChipList                     As List(Of ChipList) 'ﾁｯﾌﾟ情報ﾘｽﾄ
    End Structure

    '@WF情報構造体
    Public Structure WfList
        Dim strWfId                         As String           'ｳｪﾊID
        Dim strSlotPosition                 As String           'ｳｪﾊｽﾛｯﾄ№
        Dim strGrbClass                     As String           'GRB区分
        Dim strClass                        As String           '区分
        Dim strClassID                      As String           '区分ID
        Dim strWFStatusName                 As String           'WFｽﾃｰﾀｽ　(和名対応)
        Dim strToCarrySlotPosition          As String           '移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
        Dim strMoveStatus                   As String           '移載予約状態
        Dim strMoveDestID                   As String           '移載先ﾛｯﾄ/ｷｬﾘｱID
        Dim strResult                       As String           '測定結果(ﾁｯﾌﾟ処置登録で使用)
        Dim strDataCollCompFlag             As String           'ﾃﾞｰﾀ収集完了ﾌﾗｸﾞ
        Dim strCfWfID                       As String           'CF側の貼り合せたWFID(ODFの場合)
        Dim strRecipeId                     As String           'ﾚｼﾋﾟID(処理区分0Tのみ使用)NULLの場合はWF選択条件or工順変更でﾚｼﾋﾟなし
        Dim strReworkFlag                   As String           'ﾘﾜｰｸﾌﾗｸﾞ
        Dim strReworkMode                   As String           'ﾘﾜｰｸﾓｰﾄﾞ(0:全数/1:部分(移載有)/2:部分(移載無)/3:部分(分割無))
        Dim strjigId                        As String           '蒸着治具ID
		'蒸着治具紐付け機能改修
		Dim typSetJigInfo					As List(Of JJigList)	'紐付け治具情報
		Dim strSetMaskId					As String			'組マスクID
		Dim strWashUseNum					As String			'洗浄後使用回数
		Dim strWashUseLimit					As String			'洗浄後使用上限回数
		Dim strSetHolderId					As String			'組マスクID
		Dim strSetHolderWashUseNum			As String			'洗浄後使用回数
		Dim strNextStockReadyFlag			As String			'次回在庫準備フラグ
    End Structure

    '@WF情報ﾘｽﾄ取得(lot_.waferlist 受信)(旧lot_.waferinfo)
    Public Structure Waferlist
        Dim lngListCnt                      As Integer          'ﾘｽﾄｶｳﾝﾄ
        Dim strCurrentPositionName          As String           '現在位置名
        Dim strWfCarryFlag                  As String           'WF移載ﾌﾗｸﾞ
        Dim typWfList                       As List(Of WfList)  'WF情報ﾘｽﾄ
        Dim strSlotSize                     As String           'ｽﾛｯﾄ№
        Dim strState                        As String           'ｽﾃｰﾀｽ
        Dim strWfRecipeFlag                 As String           'WFﾚｼﾋﾟﾌﾗｸﾞ(0:ﾛｯﾄﾚｼﾋﾟ、1:枚葉ﾚｼﾋﾟ)
        Dim strWpTypeFlag                   As String           '装置種別 H/W=0, NORMAL=1, 装置未確定=""
        Dim strEqType                       As String           '装置ﾀｲﾌﾟ
        Dim strTpalClass                    As String           'TPAL設定
        Dim strCarrierCategoryId            As String           'ｷｬﾘｱｶﾃｺﾞﾘID
        Dim strCfFlag                       As String           'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strLpFlag                       As String           'LPﾌﾗｸﾞ(0：ODFﾛｯﾄ以外、1：ODFﾛｯﾄ)
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
    End Structure

    '@不良/保留/払出/傾向情報(ﾁｯﾌﾟ)
    Public Structure LotInsprstChip
        Dim strChipId                       As String           'ﾁｯﾌﾟID
        Dim strClass                        As String           '区分
        Dim strClassID                      As String           '項目ID
    End Structure

    '@不良/保留/払出/傾向情報(ｳｪﾊ)
    Public Structure LotInsprstWF
        Dim strWfId                         As String                  'ｳｪﾊID
        Dim strSlotPosition                 As String                  'ｳｪﾊｽﾛｯﾄ№
        Dim strGrbClass                     As String                  'GRB区分
        Dim strClass                        As String                  '区分
        Dim strClassID                      As String                  '項目ID
        Dim strRegistChipOutNum             As String                  '登録不良ﾁｯﾌﾟ数
        Dim strRegistChipForwardNum         As String                  '登録払出ﾁｯﾌﾟ数
        Dim lngListCnt                      As Integer                 'ﾘｽﾄｶｳﾝﾄ
        Dim typChipList                     As List(Of LotInsprstChip) 'ﾁｯﾌﾟ情報ﾘｽﾄ
    End Structure

    '@不良/保留/払出/傾向登録(lot_.insprst 要求)
    Public Structure LotInsprst
        Dim lngListCnt                      As Integer               'ﾘｽﾄｶｳﾝﾄ
        Dim strLotID                        As String                'ﾛｯﾄID
        Dim typWfList                       As List(Of LotInsprstWF) 'ｳｪﾊ情報ﾘｽﾄ
        Dim strResponsble_Emp_ID            As String                '責任者ID
        Dim strEngEmpId                     As String                '作業者ID
        Dim strLotLastUpdate                As String                'LOT最終更新日時
        Dim strClassDivision                As String                '取得区分
    End Structure

    '@WF在庫情報取得構造体(wf__wfstockinfo 応答)
    Public Structure WFstockinfo
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strFlowClass                    As String           '流動区分
        Dim typWfList                       As List(Of WfList)  'WF情報格納用
    End Structure

    '@WF情報ﾘｽﾄ取得(lot_stockthrowin 要求)
    Public Structure WFMap
        Dim strSlotNo                       As String           'ｽﾛｯﾄ№
        Dim strWfId                         As String           'WFID
        Dim strCarrierId                    As String           'ｷｬﾘｱID
    End Structure

    '@在庫ロット投入構造体(lot_stockthrowin 要求)
    Public Structure WFstockthrowin
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strLotID                        As String           '投入ﾛｯﾄID
        Dim strEmpID                        As String           '作業者ID
        Dim strLotPriority                  As String           '優先度
        Dim typWFMap                        As List(Of WFMap)   'WFﾏｯﾌﾟ
    End Structure

    '@ﾛｯﾄ作業開始取消(lot_.cnclwrkstart 要求)
    Public Structure LotCnclWrkStart
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strEngEmpId                     As String           '作業者ID
        Dim strLotLastUpdate                As String           'LOT最終更新日時
        Dim strCancelMode                   As String           'ｷｬﾝｾﾙﾓｰﾄﾞ(0:作業待ち、1:前処理)
        Dim strComments                     As String           '作業ﾒﾓ
    End Structure

    '@WF情報ﾘｽﾄ取得(lot_divide__ 要求)
    Public Structure DivideWFMap
        Dim strSlotPosition                 As String           'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
        Dim strWfId                         As String           'WFID
    End Structure

    '@ﾛｯﾄ分割構造体(lot_divide__ 要求)
    '@ﾛｯﾄ分割構造体(lot_dividedirect 要求)
    Public Structure Lotdivide
        Dim strMsgVer                       As String               'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strLotID                        As String               '分割元ﾛｯﾄID
        Dim strGrbClass                     As String               '分割元GRB区分
        Dim strDivideLotID                  As String               '分割先ﾛｯﾄID
        Dim strDivideGrbClass               As String               '分割先GRB区分
        Dim strComments                     As String               'ｺﾒﾝﾄ
        Dim typWFMap                        As List(Of DivideWFMap) 'WFﾏｯﾌﾟ
        Dim strEmpID                        As String               '作業者ID
        Dim strLotLastUpdate                As String               'LOT最終更新日時
        Dim strToCarrierId                  As String               '分割先ｷｬﾘｱID
    End Structure

    '@ﾛｯﾄ統合構造体(lot_combine_ 要求)
    '@ﾛｯﾄ統合構造体(lot_combinedirect 要求)
    Public Structure Lotcombine
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
		Dim strClassDivision				As String			'クラス(蒸着後流動予約用）
        Dim strLotID1                       As String           '統合対象ﾛｯﾄID1
        Dim strLotID2                       As String           '統合対象ﾛｯﾄID2
        Dim strLotLastUpdate1               As String           '最終更新日時ﾛｯﾄID1
        Dim strLotLastUpdate2               As String           '最終更新日時ﾛｯﾄID2
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strEmpID                        As String           '作業者ID
        Dim strCombineLotID                 As String           '統合先ﾛｯﾄID(応答格納)
    End Structure

    '@機種区分ﾘｽﾄ格納構造体
    Public Structure PDList
        Dim strPdId                         As String           '機種区分
    End Structure

    '@流動区分ﾘｽﾄ取得(lot_resvlist_ 要求)
    Public Structure FlowClassList
        Dim strFlowClass                    As String           '流動区分
    End Structure

    '@投入予定一覧取得(lot_resvlist_ 要求)
    Public Structure Lotresvlist
        Dim typFlowClassList                As List(Of FlowClassList) 'WFﾏｯﾌﾟ
        Dim strClassDivision                As String                 '取得区分
        Dim strLotID                        As String                 '分割元ﾛｯﾄID
    End Structure

    '@ﾛｯﾄ終了(lot_.end_____ 要求)
    Public Structure LotEnd
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strClass                        As String           '終了区分
        Dim strReasonCode                   As String           '理由ｺｰﾄﾞ
        Dim strComments                     As String           '終了ｺﾒﾝﾄ
        Dim strResponsble_Emp_ID            As String           '責任者ID
        Dim strEmpID                        As String           '作業者ID
        Dim strLotLastUpdate                As String           '最終更新日時
    End Structure

    '@-----------------------------------------------------------------------------------
    'ここから下記置換予定
    '元々"lot_.list____"及び"lot_.oplotlist"で共通で使用していたが分離する
    '・lot_.list____    : 対応済
    '・lot_.oplotlist   : 未対応
    '※lot_.oplotlistの置換が終了したら、下記定義は削除の事
    '@ﾛｯﾄ一覧取得(Lotlist)
    Public Structure LotListList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strFlowClass                    As String           '流動区分
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strNowST                        As String           'LOT状態
        Dim strDispatchStartTime            As String           '投入予定時刻
        Dim strDispatchEndTime              As String           '終了予定時刻
        Dim strEngEmpName                   As String           '技術担当者名
        Dim strWfNum                        As String           'WF枚数
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ数
        Dim strLotHoldFlag                  As String           'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strLotStopFlag                  As String           'ﾛｯﾄ停止ﾌﾗｸﾞ
        Dim strLotPriority                  As String           '優先度
        Dim strRecipeId                     As String           'ﾚｼﾋﾟID
        Dim strLimitTime                    As String           '制限時間(時間制約)
        Dim strCurrentPositionID            As String           'ﾛｯﾄ位置
        Dim strCurrentPositionName          As String           'ﾛｯﾄ位置(和名)
        Dim strLotCommentsFlg               As String           'ﾛｯﾄｺﾒﾝﾄ有無ﾌﾗｸﾞ
        Dim strToOpId                       As String           '制限時間先大工程
        Dim strToStepId                     As String           '制限時間先小工程
        Dim strWarnTime                     As String           '警告時間
        Dim strCommitFlag                   As String           '号機指定(1：指定　0：指定なし)
        Dim strToCarrierId                  As String           'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
        Dim strRestrictTypeID               As String           '制限ﾀｲﾌﾟ
        Dim strAltNumber                    As String           '代替番号
        Dim strLotLastUpdate                As String           'ﾛｯﾄ最終更新日付
        Dim strReworkFlag                   As String           'ﾘﾜｰｸﾌﾗｸﾞ(1:ﾘﾜｰｸ　0:ﾘﾜｰｸなし)
        Dim strTemplateSeqNum               As String           'ﾃﾝﾌﾟﾚｰﾄ工順表示順序
        Dim strCarrierStatID                As String           'ｷｬﾘｱ状態ID
        Dim strCarrierStatName              As String           'ｷｬﾘｱ状態名
        Dim strDestPositionID               As String           'ｷｬﾘｱ目的位置ID(搬送先)
        Dim strDestName                     As String           'ｷｬﾘｱ目的位置名(搬送先)
        Dim strLcDirection                  As String           '液晶方向
        Dim strPlanShipDate                 As String           '送品予定日
        Dim strSendSBID                     As String           '送品先
        Dim strPdId                         As String           '機種ID
        Dim strPdVersion                    As String           '機種Ver
        Dim strJBatchId                     As String           '蒸着ﾊﾞｯﾁID
        Dim strCfFlag                       As String           'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strLpFlag                       As String           'LPﾌﾗｸﾞ(0：ODFﾛｯﾄ以外、1：ODFﾛｯﾄ)
        Dim strVaFlag                       As String           '無機ﾌﾗｸﾞ
        Dim strTpalClass                    As String           'TPAL区分
        Dim strSbArea                       As String           'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        Dim strEditLastUpdate               As String           '(LOT_EVENT_ID=14の)最終更新日時
        Dim strEditEmpName                  As String           '(LOT_EVENT_ID=14の)最終更新者
    End Structure

    '@ﾛｯﾄ一覧取得(lot_.list____ 応答)
    Public Structure LotList
        Dim typLotListList                  As List(Of LotListList) 'ﾛｯﾄﾘｽﾄ
        Dim strUseId                        As String               '用途ID
        Dim strUseName                      As String               '用途名
        Dim strMesModeId                    As String               '運用ﾓｰﾄﾞ
        Dim strWpTypeFlag                   As String               'WPﾀｲﾌﾟﾌﾗｸﾞ
        Dim strWpStopFlag                   As String               'WP停止ﾌﾗｸﾞ
        Dim strWpStatusName                 As String               '装置状態名
        Dim strMcType                       As String               '装置ﾀｲﾌﾟ(Normal,Batch,Exdummy)
        Dim strCollectTypeFlag              As String               '処理順ﾙｰﾙ判定ﾌﾗｸﾞ(0:FIFO,1:ﾚｼﾋﾟ(切替),2:ﾚｼﾋﾟ(固定))
    End Structure
    'ここまで上記置換予定
    '@-----------------------------------------------------------------------------------

    '@端末設定情報取得(util_.reftminfo 応答)
    '@ﾃﾞﾌｫﾙﾄ装置ﾘｽﾄ構造体
    Public Structure DefaultWpList
        Dim strDefaultWpID                  As String           'ﾃﾞﾌｫﾙﾄのWPID
        Dim strBCRFlag                      As String           'ﾊﾞｰｺｰﾄﾞﾘｰﾀﾞﾌﾗｸﾞ
    End Structure

    Public Structure UtilRefTmInfo
        Dim strAreaID                       As String                 'ｴﾘｱID
        Dim strWpID                         As String                 '現在のWPID
        Dim strOpID                         As String                 '大工程ID
        Dim strStepID                       As String                 '小工程ID
        Dim strMcGroupID                    As String                 '装置ｸﾞﾙｰﾌﾟID
        Dim strCarrierTypeID                As String                 'ｷｬﾘｱﾀｲﾌﾟID
        Dim lngWpListCount                  As Integer                'WPﾘｽﾄ数
        Dim typWpList                       As List(Of DefaultWpList) 'ﾃﾞﾌｫﾙﾄWPID
    End Structure

    '@端末設定情報格納(util_.regtminfo 応答)
    Public Structure UtilRegTmInfo
        Dim strWpID                         As String                 '現在のWPID
        Dim strOpID                         As String                 '大工程ID
        Dim strStepID                       As String                 '小工程ID
        Dim strMcGroupID                    As String                 '装置ｸﾞﾙｰﾌﾟID
        Dim strCarrierTypeID                As String                 'ｷｬﾘｱﾀｲﾌﾟID
        Dim lngWpListCount                  As Integer                'WPﾘｽﾄ数
        Dim typWpList                       As List(Of DefaultWpList) 'ﾃﾞﾌｫﾙﾄWPID
    End Structure


    '@部材種別ﾘｽﾄ構造体(mas_.partclassinfo 要求)
    Public Structure VenderClassList
        Dim strVenderClassId                As String           '部品ID(ﾍﾞﾝﾀﾞ取扱分類ID)
        Dim strVenderClassName              As String           '部品名(ﾍﾞﾝﾀﾞ取扱分類名称)
    End Structure

    '@部材ｺｰﾄﾞ構造体(mas_.partclasslist 応答)
    Public Structure PartClassList
        Dim strPartCode                     As String           '部品ｺｰﾄﾞ(部材ｺｰﾄﾞ)
        Dim strPartName                     As String           '部品名(部材名)
        Dim strRegenerationCount            As String           'Maxﾘﾜｰｸ数
        Dim strThicknessClass               As String           '板厚区分
        Dim strVenderName                   As String           'ﾍﾞﾝﾀﾞｰ名
    End Structure

    '@板厚構造体
    Public Structure ThicknessList
        Dim strThicknessCode                As String           '板厚
    End Structure

    '@板厚区分構造体(mas_.thicklist 応答)
    Public Structure ThicknessClassList
        Dim strThicknessClass               As String                 '板厚区分
        Dim strThicknessCount               As String                 '板厚ｶｳﾝﾄ数
        Dim typThicknessList                As List(Of ThicknessList) '板厚
    End Structure

    '@部材受入構造体(inv_.partaccept 要求)
    Public Structure PartAcceptList
        Dim strClassCode                    As String           '部品種別ｺｰﾄﾞ
        Dim strPartCode                     As String           '部品ｺｰﾄﾞ(部材ｺｰﾄﾞ)
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strProductionLotId              As String           '製造ﾛｯﾄID
        Dim strCaseNum                      As String           'ｹｰｽ数
        Dim strNum                          As String           '受入数
        Dim strDate                         As String           '受入日時(YYYY/MM/DD hh:mm)
        Dim strEmpID                        As String           '作業者ID
        Dim strShippingLotID                As String           '出荷ﾛｯﾄID
        Dim strBoardThickness               As String           'CF板厚
        Dim strReworkCount                  As String           'ﾘﾜｰｸ数
    End Structure

    '@①　ﾛｯﾄ送品先ﾘｽﾄ取得構造体(inv_.completelot 応答)
    '@②　送品先ﾘｽﾄ取得(mas_.sendsbidlist)　応答
    Public Structure SendSBList
        Dim strSendSBID                     As String           '送品先
        Dim strSendSBName                   As String           '送品先名
        Dim strSBSystemFlag                 As String           'ｼｽﾃﾑﾌﾞﾛｯｸﾌﾗｸﾞ(0:外部,1:千歳)
    End Structure

    '@種別別在庫ﾛｯﾄ取得構造体(inv_.completelot 応答)
    Public Structure StockLotList
        Dim strDate                         As String           '受入日
        Dim strSendDate                     As String           '送品日
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strFlowClass                    As String           '流動区分
        Dim strGrbClass                     As String           'GRB区分
        Dim strPdId                         As String           '機種ID
        Dim strWFQuantity                   As String           'WF枚数
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ数
        Dim strStayTime                     As String           '停滞時間
        Dim strLotHoldFlag                  As String           'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strRecordTime                   As String           '保留開始日時
        Dim strEmpID                        As String           '作業者ID
        Dim strEmpName                      As String           '作業者名
        Dim strReasonCode                   As String           '保留理由(使用しない)
        Dim strReasonCodeID                 As String           '保留理由ID
        Dim strReasonName                   As String           '保留理由
        Dim strLotComments                  As String           'ﾛｯﾄｺﾒﾝﾄ
        Dim strEntryTime                    As String           '最終更新日
        Dim strLotPriority                  As String           '優先度
        Dim strLotStopFlag                  As String           'ﾛｯﾄ停止ﾌﾗｸﾞ
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strWpID                         As String           'WPID
        Dim strHoldStayDate                 As String           '保留期間
        Dim strHoldEmpID                    As String           '保留責任者ID
        Dim strHoldEmpName                  As String           '保留責任者
        Dim strEntryID                      As String           'ｴﾝﾄﾘID
        Dim strCurrentStatus                As String           'Lot状態
        Dim strEngEmpId                     As String           '技術者ID
        Dim strEngEmpName                   As String           '技術者名
        Dim strHoldTermDate                 As String           '保留期限
        Dim strLimitTime                    As String           '有効期限
        Dim strThicknessCode                As String           '板厚
        Dim strInvComments                  As String           '送品時ｺﾒﾝﾄ
        Dim strInvHoldComments              As String           '在庫保留ｺﾒﾝﾄ
        Dim strSendAbleFlag                 As String           '送品可能ﾌﾗｸﾞ
        Dim strSlotSize                     As String           'ｽﾛｯﾄｻｲｽﾞ
        Dim strWfCarryFlag                  As String           'WF移載ﾌﾗｸﾞ(1：移載中)
        Dim strWaitReceiveFlag              As String           '送品受入待ちﾌﾗｸﾞ(0:次SB受入済み,1:次SB受入前)
        Dim strAtlasOrderNo                 As String           'ATLASｵｰﾀﾞｰ№
        Dim strBoxNo                        As String           '箱№
        Dim strCarrierType                  As String           'ｷｬﾘｱﾀｲﾌﾟ
        Dim strTitanAcceptDate              As String           'TITAN受入日
        Dim strTitanLotID                   As String           'TITANﾛｯﾄID
        Dim strWaitTransFlag                As String           '送品ﾌｧｲﾙ転送待ちﾌﾗｸﾞ(0:転送済み,1:転送待ち)
        Dim strReworkCount                  As String           'ﾘﾜｰｸ回数
        Dim strMaxReworkCount               As String           '最大ﾘﾜｰｸ回数
        Dim strLcDirection                  As String           '液晶方向(L/R/Null)
        Dim strSendSBID                     As String           '送品先ID
        Dim strSendSBName                   As String           '送品先名(和名)
        Dim strSBSystemFlag                 As String           'SBｼｽﾃﾑﾌﾗｸﾞ
        Dim strForeignCountryFlag           As String           '海外ﾌﾗｸﾞ
        Dim strLotSendFlag                  As String           '送品ﾌﾗｸﾞ
        Dim strVaFlag                       As String           '無機ﾌﾗｸﾞ
        Dim strCfArea                       As String           'CF区分
        Dim strSbArea                       As String           'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
    End Structure

    '@ﾛｯﾄ送品構造体(要求)
    Public Structure SendLot
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strSendSBID                     As String           '送品先
        Dim strSBSystemFlag                 As String           'SBｼｽﾃﾑﾌﾗｸﾞ
        Dim strLotLastUpdate                As String           'LOT最終更新日時
        Dim strBoxNo                        As String           '箱№
    End Structure

    '@ﾛｯﾄ送品構造体(inv_.sendlot_)
    Public Structure SendLotList
        Dim typSendLot                      As List(Of SendLot)
        Dim strEmpID                        As String           '作業者ID
    End Structure

    '@部材一覧取得(inv_.partlist 応答)
    Public Structure PartLotList
        Dim strPartCode                     As String           '部品ｺｰﾄﾞ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strLotID                        As String           '在庫ﾛｯﾄID
        Dim strProductionLotId              As String           '生産ﾛｯﾄID(製造ﾛｯﾄID)
        Dim strNum                          As String           '受入数
        Dim strDate                         As String           '受入日時
        Dim strEmpID                        As String           '作業者ID(受入担当者)
        Dim strEmpName                      As String           '作業者名(受入担当者)
        Dim strLimitTime                    As String           '在庫制限日時
        Dim strCreateTime                   As String           'ﾃﾞｰﾀ作成時間
        Dim strShippingLotID                As String           'CFﾒｰｶ出荷ﾛｯﾄID
        Dim strThicknessCode                As String           'CF板厚
        Dim strCurrentStatus                As String           '現在状態
        Dim strReworkCount                  As String           'CFﾘﾜｰｸ回数
        Dim strLotLastUpdate                As String           'LOT最終更新日時
        Dim strReasonCode                   As String           '理由ｺｰﾄﾞ
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strFlowClass                    As String           '流動区分
    End Structure

    '@部材状態変更(inv_.changstate 要求)
    Public Structure ChangeStateList
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strClassDivison                 As String           '処理区分(33：部材払出処理/34：組立在庫払出処理/Null：保留・保留解除)
        Dim strVenderClassId                As String           '部品ID(ﾍﾞﾝﾀﾞ取扱分類ID)
        Dim strLotID                        As String           '在庫ﾛｯﾄID
        Dim strLotEventId                   As String           'ﾛｯﾄｲﾍﾞﾝﾄID
        Dim strReasonCode                   As String           '変更ID
        Dim strNum                          As String           '数量
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strEmpID                        As String           '作業者ID
        Dim strLotLastUpdate                As String           'LOT最終更新日時
        Dim strHoldTermDate                 As String           '保留期限
        Dim strHoldEmpID                    As String           '保留責任者
        Dim strEntryTime                    As String           '登録日時
        Dim typWfList                       As List(Of WfList)  'WF情報ﾘｽﾄ
        Dim lngWfListCnt                    As Integer          'WF情報ﾘｽﾄｶｳﾝﾄ
        Dim strHoldDate                     As String           '保留日時(応答時挿入)
    End Structure

    '@種別別在庫ﾛｯﾄ取得(inv_.complotlist 要求)
    Public Structure ClassCompleteList
        Dim strClassDivison                 As String                 '処理区分(0：全在庫ﾛｯﾄ取得　1：流動区分指定)
        Dim strSbID                         As String                 'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim lngFlowClassCnt                 As Integer                '流動区分の選択数
        Dim typFlowClassList                As List(Of FlowClassList) '流動区分
        Dim lngPdCnt                        As Integer                '機種区分の選択数
        Dim typPdList                       As List(Of PDList)        '機種区分
        Dim strInventoryFlag                As String                 '在庫区分(01：受入　09：完成 但し受入・完成両方の場合はNULL)
        Dim strHoldFlag                     As String                 '保留区分ﾌﾗｸﾞ(0：指定なし　1：保留ﾛｯﾄ　但し受入・完成両方の場合はNULL)
        Dim strLotID                        As String                 'TFT基板ﾛｯﾄID(0L:ﾛｯﾄ指定TPAL使用可能の場合は指定)
        Dim strRefStartDate                 As String                 '開始日付
        Dim strRefEndDate                   As String                 '終了日付
    End Structure

    '@ﾛｯﾄ処理待ち一覧取得(応答用)
    Public Structure WaitingLotList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strFlowClass                    As String           '流動区分
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strNowST                        As String           'LOT状態
        Dim strDispatchStartTime            As String           '投入予定時刻
        Dim strDispatchEndTime              As String           '終了予定時刻
        Dim strEngEmpName                   As String           '技術担当者名
        Dim strWfNum                        As String           'WF枚数
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ数
        Dim strLotPriority                  As String           '優先度
        Dim strRecipeId                     As String           'ﾚｼﾋﾟID
        Dim strLimitTime                    As String           '制限時間(時間制約)
        Dim strCurrentPositionID            As String           'ﾛｯﾄ位置
        Dim strCurrentPositionName          As String           'ﾛｯﾄ位置(和名)
        Dim strLotCommentsFlg               As String           'ﾛｯﾄｺﾒﾝﾄ有無ﾌﾗｸﾞ
        Dim strSeqNum                       As String           '処理順
        Dim strLotHoldFlag                  As String           'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strLotStopFlag                  As String           'ﾛｯﾄ停止ﾌﾗｸﾞ
        Dim strToOpId                       As String           '制限時間先大工程
        Dim strToStepId                     As String           '制限時間先小工程
        Dim strWarnTime                     As String           '警告時間
        Dim strRestrictTypeID               As String           '制限ﾀｲﾌﾟ
        Dim strLotLastUpdate                As String           'ﾛｯﾄ最終更新日付
        Dim strReworkFlag                   As String           'ﾘﾜｰｸﾌﾗｸﾞ(1:ﾘﾜｰｸあり 0:ﾘﾜｰｸなし)
        Dim strLcDirection                  As String           '液晶方向(L/R/Null)
        Dim strCommitFlag                   As String           '号機指定ﾌﾗｸﾞ
    End Structure

    '@ﾛｯﾄ処理待ち一覧取得(lot_.waitinglist 応答)
    Public Structure LotWaitingList
        Dim typWaitingLotList               As List(Of WaitingLotList) 'ﾛｯﾄﾘｽﾄ
        Dim strUseId                        As String           '用途ID
        Dim strUseName                      As String           '用途名
        Dim strMesModeId                    As String           '運用ﾓｰﾄﾞ
        Dim strWpTypeFlag                   As String           'WPﾀｲﾌﾟﾌﾗｸﾞ
        Dim strWpStopFlag                   As String           'WP停止ﾌﾗｸﾞ
        Dim strWpStatusName                 As String           '装置状態名
    End Structure

    '@ﾛｯﾄ処理順変更(lot_.chgseqnum 要求)
    Public Structure LotChgSeqNumList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strSeqNum                       As String           '処理順
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strAvailableRecipeFlag          As String           '処理可能ﾚｼﾋﾟﾌﾗｸﾞ(0：処理可能ﾚｼﾋﾟ、1：処理不可ﾚｼﾋﾟ)
        Dim strLotLastUpdate                As String           'ﾛｯﾄ最終更新日付
    End Structure

    Public pblnSubDecision              As Boolean              'Sub画面確定ﾌﾗｸﾞ(True：確定、False：閉じる)

    '@ﾏｽﾀ工順一覧取得(mas_.pdentrylist)
    Public Structure EntryList
        Dim strEntryID                      As String           'ｴﾝﾄﾘID
        Dim strEntryName                    As String           'ｴﾝﾄﾘ名
        Dim strEntryApplyTime               As String           '適用日時
        Dim strEntryComments                As String           'ｴﾝﾄﾘ時ｺﾒﾝﾄ
        Dim strMaxWFCount                   As String           '最大WF枚数
    '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。
    '    strCdenFlag                     As String           'ﾁｯﾌﾟ電特ﾌﾗｸﾞ(0:ﾁｯﾌﾟ電特工程なし、1:ﾁｯﾌﾟ電特工程あり)
    End Structure

    '@WF指定ｱｸｼｮﾝ予約
    Public Structure WfAction
        Dim strNewFlag                      As String           '新規ﾌﾗｸﾞ
        Dim strDelFlag                      As String           '削除ﾌﾗｸﾞ
        Dim strWfId                         As String           'WF_ID
        Dim strExecTime                     As String           '実行時刻
    End Structure

    '@ｱｸｼｮﾝ予約設定(lot_.actrsv__)
    Public Structure Lotactrsv
        Dim strSbID                         As String            'ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strLotActionTypeID              As String            'ｱｸｼｮﾝ予約ﾀｲﾌﾟ(0:ﾛｯﾄ,1:機種,2:装置,3:工程)
        Dim strOpID                         As String            '大工程
        Dim strSTEP_ID                      As String            '小工程
        Dim strItemName                     As String            '項目名(予約ﾀｲﾌﾟで右項目をｾｯﾄ(0:ﾛｯﾄ,1:機種;Ver,2:装置)
        Dim strActionTrigger                As String            'ｱｸｼｮﾝﾄﾘｶﾞｰ(0:作業開始,1:作業終了,2:全ﾀｲﾐﾝｸﾞ)
        Dim strMessage                      As String            'ｱｸｼｮﾝﾒｯｾｰｼﾞ(256文字)
        Dim strWorkDirectionID              As String            '作業指示書No
        Dim strEngEmpId                     As String            '技術担当ID
        Dim strStopHoldFlag                 As String            '停止/保留ﾌﾗｸﾞ(0:なし,1:停止,2:保留)
        Dim strHoldReasonID                 As String            '保留理由ID
        Dim strEmpID                        As String            '作業者ID
        Dim strStartTime                    As String            '開始日付
        Dim strEndTime                      As String            '終了日付
        Dim strEditTime                     As String            '最終更新日時
        Dim strHoldComments                 As String            '保留ｺﾒﾝﾄ
        Dim strHoldPeriod                   As String            '保留相対日数
        Dim strHoldEmpID                    As String            '保留責任者ID
        Dim lngWfActionCnt                  As Integer           'WF数
        Dim typWfAction                     As List(Of WfAction) 'WF指定ｱｸｼｮﾝ予約
    End Structure

    Public Structure Wfactrsv
        Dim lngWfActionCnt                  As Integer           'WF数
        Dim typWfAction                     As List(Of WfAction) 'WF指定ｱｸｼｮﾝ予約
    End Structure

    '@ｱｸｼｮﾝ内容検索(lot_.actioninfo)
    Public Structure LotActioninfo
        Dim strLotActionID                  As String            'ｱｸｼｮﾝ予約ID(0:作業開始,1:作業終了,2:全ﾀｲﾐﾝｸﾞ)
        Dim strMessage                      As String            'ｱｸｼｮﾝﾒｯｾｰｼﾞ(256文字)
        Dim strWorkDirectionID              As String            '作業指示書No
        Dim strEngEmpId                     As String            '技術担当ID
        Dim strEngEmpName                   As String            '技術担当名
        Dim strStopHoldFlag                 As String            '停止/保留ﾌﾗｸﾞ(0:なし,1:停止,2:保留)
        Dim strHoldReasonID                 As String            '保留理由ID
        Dim strStartTime                    As String            '運用開始日時
        Dim strEndTime                      As String            '運用終了日時
        Dim strEditTime                     As String            '最終更新日時
        Dim strHoldComments                 As String            '保留ｺﾒﾝﾄ
        Dim strHoldPeriod                   As String            '保留期限(相対日数)
        Dim strHoldEmpID                    As String            '保留責任者ID
        Dim strHoldEmpName                  As String            '保留責任者名
        Dim lngWfActionCnt                  As Integer           'WF数
        Dim typWfAction                     As List(Of WfAction) 'WF指定ｱｸｼｮﾝ予約
    End Structure

    '@ｱｸｼｮﾝ予約状況取得(lot_.actstepinfo)
    Public Structure LotActStepInfo
        Dim strActionFlag                   As String           'ｱｸｼｮﾝﾌﾗｸﾞ(あり、なし)
        Dim strActionTrigger                As String           'ｱｸｼｮﾝﾄﾘｶﾞｰ
    End Structure

    '@ﾌﾟﾛｾｽﾊﾞｰｼﾞｮﾝﾘｽﾄ(mas_.processinfo)
    Public Structure ProcessList
        Dim strPCID                         As String           'ﾌﾟﾛｾｽID
        Dim strPcVersion                    As String           'ﾌﾟﾛｾｽﾊﾞｰｼﾞｮﾝ
    End Structure

    '@ﾛｯﾄ移載情報WFﾘｽﾄ取得(lot_.moveinfo応答)
    Public Structure MoveInfoWFList
        Dim strWfId                         As String           'WFID
        Dim strSlotPosition                 As String           'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
        Dim strWFStatus                     As String           'WFｽﾃｰﾀｽ
        Dim strToCarrySlotPosition          As String           '移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
        Dim strDivideCombineStatus          As String           '分割/統合ｽﾃｰﾀｽ
        Dim strDivideCombineLotID           As String           '分割/統合先ﾛｯﾄID
        Dim strOrgDivideCombineLotID        As String           '分割／統合ﾛｯﾄID編集元ﾛｯﾄID
        Dim strToCarrierId                  As String           '移載先ｷｬﾘｱID
        Dim strToFlowClass                  As String           '移載先流動区分
        '@↓2019/12/31 (Tue) 15:26:32 Y.Yoneyama 「.Netへ反映未」 **************************************************
        Dim strGRBClass                     As String           'GRB
        '@↑2019/12/31 (Tue) 15:26:32 Y.Yoneyama 「.Netへ反映未」 **************************************************
    End Structure

    '@ﾛｯﾄ移載情報(lot_.moveinfo応答)
    Public Structure Lotmoveinfo
        Dim strLotEventId                   As String                   'ﾛｯﾄｲﾍﾞﾝﾄID
        Dim strLotID1                       As String                   'ﾛｯﾄID
        Dim strFlowClass                    As String                   '流動区分
        Dim strPdId                         As String                   '機種ID
        Dim strNowST                        As String                   'ﾛｯﾄ状態
        Dim strLotStopFlag                  As String                   'ﾛｯﾄ停止ﾌﾗｸﾞ
        Dim strLotHoldFlag                  As String                   'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strWfNum                        As String                   'WF枚数
        Dim strWfCarryFlag                  As String                   'WF移載ﾌﾗｸﾞ
        Dim typMoveInfoWFList               As List(Of MoveInfoWFList)  'WFﾘｽﾄ
        Dim strLotLastUpdate1               As String                   '移載元ﾛｯﾄ最終更新日時
        Dim strLotLastUpdate2               As String                   '移載先ﾛｯﾄ1最終更新日時
        Dim strLotLastUpdate3               As String                   '移載先ﾛｯﾄ2最終更新日時
        Dim lngWfListCnt                    As Integer                  'WFﾘｽﾄｶｳﾝﾄ
        Dim strCarrierTypeID                As String                   'ｷｬﾘｱﾀｲﾌﾟID
        Dim strSlotSize                     As String                   'ｽﾛｯﾄｻｲｽﾞ
        Dim strOrgLotID1                    As String                   '移載ﾛｯﾄ編集元LOT_ID
        Dim strSourceFlag                   As String                   '移載元ﾌﾗｸﾞ(0：移載先、1：移載元)
    End Structure

    '@空ｷｬﾘｱ一覧取得(carr.emptylist応答)
    Public Structure EmptyCarrierList
        Dim strCarrierId                    As String           'ｷｬﾘｱID
    End Structure

    '@空ｷｬﾘｱ一覧取得(carr.emptylist応答)
    Public Structure CarrierEmptyList
        Dim typCarrierEmptyList             As List(Of EmptyCarrierList) '空ｷｬﾘｱ一覧
        Dim lngCarrierListCnt               As Integer                   '空ｷｬﾘｱｶｳﾝﾄ
    End Structure

    '@ｷｬﾘｱ一覧取得(carr.list____要求)
    Public Structure CarrierListReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strClassDivision                As String           '処理区分
        Dim strRestrictedSBID               As String           'ｷｬﾘｱ使用可能ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strCarrierTypeID                As String           'ｷｬﾘｱﾀｲﾌﾟ
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strCleanCondition               As String           '洗浄条件ﾌﾗｸﾞ
        Dim strCategoryID                   As String           'ｶﾃｺﾞﾘID
    End Structure

    '@ｷｬﾘｱ一覧取得(carr.list____応答)ｷｬﾘｱ一覧
    Public Structure CarrierIDList
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strEmptyFlag                    As String           'ｷｬﾘｱWF有無ﾌﾗｸﾞ
        Dim strStartTime                    As String           '利用開始日
        Dim strCleanFlag                    As String           '洗浄必要ﾌﾗｸﾞ
        Dim strCreanTime                    As String           '最終洗浄日時
        Dim strTotalUseCount                As String           '総使用回数
        Dim strCleanCount                   As String           '洗浄回数
        Dim strAfterCleanUseCount           As String           '洗浄後使用回数
        Dim strCarrierStatID                As String           'ｷｬﾘｱ状態
        Dim strCarrierStatName              As String           'ｷｬﾘｱ状態(和名)
        Dim strVendorName                   As String           'ﾍﾞﾝﾀﾞｰ名
        Dim strProductionDate               As String           '製造年月日
        Dim strCurrentPositionID            As String           '現在位置
        Dim strCurrentPositionName          As String           '現在位置(和名)
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strLdrUndrKind                  As String           'loader/unloader種別
        Dim strDestPositionID               As String           'ｷｬﾘｱ目的位置ID(搬送先)
        Dim strDestName                     As String           'ｷｬﾘｱ目的位置名(搬送先)
        Dim strReticleID                    As String           'SMIF格納ﾚﾁｸﾙID
        Dim strReticleStatusItemID          As String           'ﾚﾁｸﾙ状態項目ID
        Dim strReticleStatusItemName        As String           'ﾚﾁｸﾙ状態項目名
        Dim strCarrierMoveStat              As String           'ｷｬﾘｱ移載状態(0:移載外(不可)、1:移載中(可))
        Dim strCategoryID                   As String           'ｶﾃｺﾞﾘID
        Dim strCategoryName                 As String           'ｶﾃｺﾞﾘ名
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strEditTime                     As String           '最終更新日時
    End Structure

    '@ｷｬﾘｱ一覧取得(carr.list___応答)
    Public Structure CarrList
        Dim typCarrierList                  As List(Of CarrierIDList) 'ｷｬﾘｱ一覧
        Dim lngCarrierListCnt               As Integer                'ｷｬﾘｱｶｳﾝﾄ
    End Structure

    '@ﾛｯﾄ移載(lot_.move____ 要求)
    Public Structure Move____WFMapList
        Dim strSlotPosition                 As String           '移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
        Dim strWfId                         As String           '移載先WFID
    End Structure

    '@ﾛｯﾄ移載(lot_.move____ 要求)
    Public Structure LotMove____
        Dim strClassDivision                As String                     '処理区分
        Dim strSbID                         As String                     'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strCarrierID1                   As String                     '移載元ｷｬﾘｱID
        Dim strLotLastUpdate1               As String                     '移載元ﾛｯﾄ最終更新日時
        Dim strCarrierID2                   As String                     '移載先ｷｬﾘｱID
        Dim strLotID2                       As String                     '移載先ﾛｯﾄID
        Dim strLotLastUpdate2               As String                     '移載先ﾛｯﾄ最終更新日時
        Dim strCarrierID3                   As String                     '移載先ｷｬﾘｱID
        Dim strLotID3                       As String                     '移載先ﾛｯﾄID
        Dim strLotLastUpdate3               As String                     '移載先ﾛｯﾄ最終更新日時
        Dim typWFMapList                    As List(Of Move____WFMapList) '移載先WFﾏｯﾌﾟ
        Dim strEmpID                        As String                     '作業者ID
        Dim strMsgVer                       As String                     'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    End Structure

    '@引継ぎ情報構造体(装置一覧からｷｬﾘｱID他の情報を格納する構造体)
    Public Structure CommonInfo
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strWpID                         As String           '装置ID
        Dim strWpName                       As String           '装置ID名称
        Dim strDivision                     As String           '起動区分
        Dim strFromMenuKey                  As String           '呼び元ﾒﾆｭｰｷｰ
        Dim strToCarrierId                  As String           'ｱﾝﾛｰﾀﾞｷｬﾘｱID
        Dim strAltPointer                   As String           '代替番号
        Dim strSPSelectFlag                 As String           '特殊流動ﾌﾗｸﾞ("0":ﾘﾜｰｸ/"1":追加流動/"2":先行流動？)
        Dim strNowST                        As String           'ﾛｯﾄ状態
        Dim strWpTypeFlag                   As String           'WPﾀｲﾌﾟﾌﾗｸﾞ("0"：ﾊﾝﾄﾞﾜｰｸ/"1"通常)
        Dim strLoaderUnloaderFlag           As String           'L/Uﾌﾗｸﾞ("0"：処理条件による /"1"：L/U /"2"：Uni)
        Dim strEqType                       As String           'EQ_TYPE
        Dim strFlowClass                    As String           '流動区分
        Dim strPdId                         As String           '機種
        Dim strWfNum                        As String           'WF枚数
        Dim strPlanThrowDate                As String           '投入予定日
        Dim strEngEmpName                   As String           '技術担当者名
        Dim strLotLastUpdate                As String           '最終更新日時
        Dim strSlotSize                     As String           'ｽﾛｯﾄｻｲｽﾞ
        Dim strCfFlag                       As String           'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strSbID                         As String           'SBID
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ数
        Dim strBatchId                      As String           'ﾊﾞｯﾁID
        Dim strTapeBatchId                  As String           'ﾃｰﾌﾟﾊﾞｯﾁID
        Dim strOvenBatchId                  As String           'ｵｰﾌﾞﾝﾊﾞｯﾁID
        Dim strAldBatchId                   As String           'ALDﾊﾞｯﾁID
        Dim strACarrierId                   As String           'AｷｬﾘｱID
		Dim strJigId						As String			'治具ID
    End Structure

    '@ﾍﾞﾝﾀﾞｰｸﾗｽﾘｽﾄ取得(mas_.vendclasslist 応答)
    Public Structure VenderList
        Dim typVenderClassList              As List(Of VenderClassList) 'ﾍﾞﾝﾀﾞｰｸﾗｽﾘｽﾄ
        Dim lngVenderClassListCnt           As Integer                  'ﾍﾞﾝﾀﾞｰｸﾗｽﾘｽﾄｶｳﾝﾄ
    End Structure

    '画面ｻｲｽﾞﾏｽﾀ取得(mas_.screenlist 応答)
    Public Structure ScreenList
        Dim strScreenSizeID                 As String           '画面ｻｲｽﾞID
        Dim strChipCount                    As String           '基盤取個数
    End Structure

    '@画面ｻｲｽﾞﾏｽﾀ取得(mas_.screenlist 応答)
    Public Structure ScreenSizeList
        Dim typScreenList                   As List(Of ScreenList) '画面ｻｲｽﾞﾘｽﾄ
        Dim lngScreenSizeListCnt            As Integer             'ﾘｽﾄｶｳﾝﾄ
    End Structure

    '@CFﾛｯﾄ編成(PALETTE_MAP_LIST)
    Public Structure PaletteMapList
       Dim strSlotPositon                   As String           'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
       Dim strPaletteID                     As String           'ﾊﾟﾚｯﾄID
       Dim strChipCount                     As String           'ﾁｯﾌﾟ数
       Dim strLotID                         As String           '在庫ﾛｯﾄID
    End Structure

    '@CFﾛｯﾄ編成(lot_.cfthrowin 要求)
    Public Structure LotCfThrowin
        Dim strSbID                         As String                  'SBID
        Dim strCarrierId                    As String                  'ｷｬﾘｱID
        Dim strEmpID                        As String                  '作業者ID
        Dim strNum                          As String                  '投入数
        Dim strPdId                         As String                  '機種ID
        Dim strEntryID                      As String                  'ｴﾝﾄﾘID
        Dim strMasPdVersion                 As String                  '工順ﾊﾞｰｼﾞｮﾝ
        Dim typPaletteMapList               As List(Of PaletteMapList) 'ﾊﾟﾚｯﾄﾏｯﾌﾟ
        Dim lngPaletteMapListCnt            As Integer                 'ﾊﾟﾚｯﾄﾏｯﾌﾟｶｳﾝﾄ
        Dim strMsgVer                       As String                  'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strRetrunLotID                  As String                  '登録ﾛｯﾄID
        Dim strTechManID                    As String                  '技術担当者ID
        Dim strWpID                         As String                  '投入装置ID
    End Structure

    '@運用ﾓｰﾄﾞ変更(PORT_LIST)
    Public Structure eqPortList
        Dim strPortID                       As String           'ﾎﾟｰﾄID
        Dim strPortStatus                   As String           'ﾎﾟｰﾄ状態
        Dim strPortStatusID                 As String           'ﾎﾟｰﾄ状態ID
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strUsage                        As String           '用途(ﾎﾟｰﾄ)
        Dim strTransCarrier                 As String           '搬送予定ｷｬﾘｱID
        Dim strTransServiceStatus           As String           '自動搬送ｻｰﾋﾞｽ状態
        Dim strTransServiceStatusName       As String           '自動搬送ｻｰﾋﾞｽ状態(和名)
    End Structure

    '@装置処理順変更要求(eq_.chgprocorder) 要求
    Public Structure CollectTypeList
        Dim strCollectTypeName              As String           'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ名
        Dim strCollectTypeNum               As String           'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ番号(ID)
        Dim strUserSelectFlag               As String           '選択ﾚｼﾋﾟｸﾞﾙｰﾌﾟ
    End Structure

    '@運用ﾓｰﾄﾞ変更(eq__.state___ 応答)
    Public Structure Eqstate
        Dim strMesModeId                    As String                   '運用ﾓｰﾄﾞ
        Dim strReseerveMesModeID            As String                   '運用ﾓｰﾄﾞ予約状態
        Dim strMesModeType                  As String                   '運用ﾓｰﾄﾞﾀｲﾌﾟ
        Dim strModeStatus                   As String                   'ﾓｰﾄﾞ状態
        Dim strModeStatusID                 As String                   'ﾓｰﾄﾞ状態ID
        Dim strUseId                        As String                   '用途ID
        Dim strUseName                      As String                   '用途名
        Dim strWpTypeFlag                   As String                   'WPﾀｲﾌﾟﾌﾗｸﾞ
        Dim strWpStopFlag                   As String                   'WP停止ﾌﾗｸﾞ
        Dim strWpStatusName                 As String                   '装置状態名
        Dim strCollectTypeFlag              As String                   '処理順ﾌﾗｸﾞ(0：FIFO(到着順)、1：ﾚｼﾋﾟ(切替)、2：ﾚｼﾋﾟ(固定))
        Dim strRecipeFlowNum                As String                   '連続処理ﾛｯﾄ数
        Dim typPortList                     As List(Of eqPortList)      '装置ﾎﾟｰﾄﾘｽﾄ
        Dim lngPortListCnt                  As Integer                  'ﾎﾟｰﾄﾘｽﾄｶｳﾝﾄ
        Dim typCollectTypeList              As List(Of CollectTypeList) 'ﾚｼﾋﾟｸﾞﾙｰﾌﾟﾘｽﾄ
        Dim lngCollectTypeListCnt           As Integer                  'ﾚｼﾋﾟｸﾞﾙｰﾌﾟﾘｽﾄｶｳﾝﾄ
        Dim strWPCancelCarrierFlag          As String                   'WPｷｬﾝｾﾙｷｬﾘｱﾌﾗｸﾞ
        Dim strMcType                       As String                   '装置ﾀｲﾌﾟ(Normal,Batch,Exdummy)
        Dim strALDPorcessModeId             As String                   '防湿ALD処理ﾓｰﾄﾞID
        Dim strALDProcessNum                As String                   '防湿ALD処理番号
        Dim strALDProcessName               As String                   '防湿ALD処理名
    End Structure

    '@運用ﾓｰﾄﾞ変更(LOT_LIST)
    Public Structure EqLot
        Dim strSeqNum                       As String           '処理順番
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strCurrentStatus                As String           'LOT状態
    End Structure

    '@運用ﾓｰﾄﾞ変更(eq__.lotlist_ 応答)
    Public Structure EqLotList
        Dim typEqLot                        As List(Of EqLot)   'ﾛｯﾄﾘｽﾄ
        Dim lngEqLotListCnt                 As Integer          'ﾘｽﾄｶｳﾝﾄ
    End Structure

    '@運用ﾓｰﾄﾞ変更(eq__.chgmode_ 要求)
    Public Structure EqChgMode
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strWpID                         As String           'WPID
        Dim strMesModeId                    As String           'MESﾓｰﾄﾞ(M1,M2,S1,S2,F)
        Dim strEmpID                        As String           '作業者ID
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strOldUseID                     As String           '変更前装置状態ID
        Dim strUseId                        As String           '変更後装置状態ID
        Dim strWpStopFlag                   As String           'WP停止ﾌﾗｸﾞ
        Dim strMessageID                    As String           'ﾒｯｾｰｼﾞID
    End Structure

    '@組立在庫分割(lot_.asmdivide 要求)
    Public Structure LotAsmdivide
        Dim strLotID                        As String               '分割元ﾛｯﾄID
        Dim strDivedeLotID                  As String               '分割先ﾛｯﾄID
        Dim lngDivedewfMapListCnt           As Integer              '分割先WFﾘｽﾄｶｳﾝﾄ
        Dim typDivedeWfMapList              As List(Of DivideWFMap) '分割先WFﾏｯﾌﾟ
        Dim strDivedeLotID2                 As String               '分割先ﾛｯﾄID2
        Dim lngDivedewfMapListCnt2          As Integer              '分割先WFﾘｽﾄｶｳﾝﾄ2
        Dim typDivedeWfMapList2             As List(Of DivideWFMap) '分割先WFﾏｯﾌﾟ2
        Dim strEmpID                        As String               '作業者ID(受入担当者)
        Dim strLotLastUpdate                As String               '最終更新日時
        Dim strSbID                         As String               'SBID
        Dim strMsgVer                       As String               'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strToCarrierID1                 As String               '分割先ｷｬﾘｱID1
        Dim strToCarrierID2                 As String               '分割先ｷｬﾘｱID2
        Dim strOnlineFlag                   As String               'ｵﾝﾗｲﾝﾌﾗｸﾞ
    End Structure

    '@在庫管理(inv_.acptlotlist 応答)
    Public Structure InvAcptLot
        Dim strDate                         As String
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strFlowClass                    As String           '流動区分
        Dim strLotPriority                  As String           '優先度
        Dim strPdId                         As String           '機種ID
        Dim strWFQuantity                   As String           'WF枚数
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ数
        Dim strLotHoldFlg                   As String           '保留ﾌﾗｸﾞ
        Dim strStayTime                     As String           '停滞時間
        Dim strRecordTime                   As String           '保留開始日時
        Dim strEmpID                        As String           '作業者ID
        Dim strEmpName                      As String           '作業者名
        Dim strReasonCode                   As String           '保留理由(保管在庫にて使用)
        Dim strReasonCodeID                 As String           '保留理由ID
        Dim strReasonName                   As String           '保留理由
        Dim strComments                     As String           'ﾛｯﾄｺﾒﾝﾄ
        Dim strEditTime                     As String           '最終更新日
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strWpID                         As String           '装置ID
        Dim strWpName                       As String           '装置名
        Dim strHoldStayTime                 As String           '保留期間
        Dim strHoldTermDate                 As String           '保留期限
        Dim strHoldEmpID                    As String           '保留責任者ID
        Dim strHoldEmpName                  As String           '保留責任者名
        Dim strEntryID                      As String           'ｴﾝﾄﾘ
        Dim strCurrentStatus                As String           'ﾛｯﾄ状態
        Dim strEngEmpId                     As String           '技術担当者ID
        Dim strEngEmpName                   As String           '技術担当者名
        Dim strInvComments                  As String           '送品時ｺﾒﾝﾄ
        Dim strInvHoldComments              As String           '在庫保留ｺﾒﾝﾄ
        Dim strDivideStatus                 As String           '分割予約状態(0:移載予約なし/1:移載予約済み/2:移載完了)
        Dim strSlotSize                     As String           'ｽﾛｯﾄｻｲｽﾞ
        Dim strToCarrierID1                 As String           '移載先ｷｬﾘｱID1
        Dim strToCarrierID2                 As String           '移載先ｷｬﾘｱID2
        Dim strWfCarryFlag                  As String           'WF移載ﾌﾗｸﾞ(1：移載中)
        Dim strLcDirection                  As String           '液晶方向(L/R/Null)
        Dim strSendSBID                     As String           '送品先ID
        Dim strSendSBName                   As String           '送品先名(和名)
        Dim strSbArea                       As String           'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
    End Structure

    '@在庫管理(inv_.acptlotlist 要求)
    Public Structure InvAcptListRequest
        Dim strSbID                         As String                 'SBID
        Dim strClassDivision                As String                 '処理区分
        Dim lngPdCnt                        As Integer                '機種区分の選択数
        Dim typPdList                       As List(Of PDList)        '機種区分
        Dim lngFlowClassCnt                 As Integer                '流動区分の選択数
        Dim typFlowClassList                As List(Of FlowClassList) '流動区分
        Dim strMsgVer                       As String                 'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    End Structure

    '@在庫管理(inv_.acptlotlist 応答)
    Public Structure InvAcptLotList
        Dim typInvAcptLot                   As List(Of InvAcptLot) 'ﾛｯﾄ状態ﾘｽﾄ
        Dim InvAcptLotListCnt               As Integer             'ﾛｯﾄ状態ﾘｽﾄｶｳﾝﾄ
    End Structure

    '@在庫ﾛｯﾄﾘｽﾄ構造体(inv_.lotlist_ 要求 新)
    Public Structure InvLotListReq
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strSbID                         As String           'SBID
        Dim strClassDivision                As String           '処理区分
        Dim strMsgVer                       As String           'MsgVer
    End Structure

    '@元ﾛｯﾄﾘｽﾄ
    Public Structure BFLotList
        Dim strLotID                        As String           'ﾛｯﾄID
    End Structure

    '@在庫ﾛｯﾄﾘｽﾄ構造体(新)
    Public Structure InvLotlistLotList
        Dim strCarrierId                    As String             'ｷｬﾘｱID
        Dim strCurrentPosition              As String             'ｷｬﾘｱ位置
        Dim strCurrentPositionName          As String             '現在位置名
        Dim strSlotSize                     As String             'ｽﾛｯﾄ数
        Dim strWFQuantity                   As String             'WF枚数
        Dim strChipQuantity                 As String             'ﾁｯﾌﾟ数
        Dim strEntryTime                    As String             '受入日,保留開始日
        Dim strEditTime                     As String             '最終更新日時
        Dim lngBFLotListCnt                 As Integer            '元ﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typBFLotList                    As List(Of BFLotList) '元ﾛｯﾄﾘｽﾄ
        Dim strCarrierEmpName               As String             '責任者
        Dim strCarrierComments              As String             'ｺﾒﾝﾄ
    End Structure

    '@在庫ﾛｯﾄﾘｽﾄ取得構造体(inv_.lotlist_ 応答 新)
    Public Structure InvLotListAns
        Dim lngLotListAnsCnt                As Integer                    'ｶｳﾝﾄ数
        Dim typLotListAns                   As List(Of InvLotlistLotList) '在庫ﾘｽﾄ
    End Structure

    '@在庫管理引継ぎ構造体
    Public Structure HoldConnect
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strFlowClass                    As String           '流動区分
        Dim strLotHoldFlg                   As String           '保留ﾌﾗｸﾞ
        Dim strLastUpdate                   As String           '最終更新日時
        Dim strReasonCode                   As String           '保留理由
        Dim strHoldTremDate                 As String           '保留期限
        Dim strHoldEmpID                    As String           '保留責任者
        Dim strHoldEmpName                  As String           '保留責任者名
        Dim strCommnents                    As String           'ｺﾒﾝﾄ
        Dim lngTabFlag                      As Integer          'ﾀﾌﾞﾌﾗｸﾞ
        Dim strSbID                         As String           '処理区分
        Dim strNextCommnents                As String           '次SB連絡
        Dim strTitleFlg                     As String           'ｺﾒﾝﾄ/次SB/前SB切替ﾌﾗｸﾞ
        Dim strHoldComments                 As String           '保留ｺﾒﾝﾄ
        Dim strSlotSize                     As String           'ｽﾛｯﾄｻｲｽﾞ
        Dim blnEditFlag                     As Boolean          '編集ﾌﾗｸﾞ(True:編集可、False:編集不可)
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ数量(良品)
        Dim blnOuterSendFlag                As Boolean          '外部送品有無ﾌﾗｸﾞ(True:外部送品あり、False：外部送品なし)
        Dim strPdId                         As String           '機種
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strEngEmpId                     As String           '技術担当者ID
        Dim strEngEmpName                   As String           '技術担当者
        Dim strParentForm                   As String           '起動親フォーム
        Dim strGrbClass                     As String           'GRB区分
    End Structure

    '@CFKIﾛｯﾄ情報取得(lot_.cfkilotinfo 応答)
    Public Structure MetalPaletteMapList
        Dim strSlotPosition                 As String           'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
        Dim strPaletteID                    As String           'ﾊﾟﾚｯﾄID
        Dim strThicknessCode                As String           'CF板厚
        Dim strChipCount                    As String           'ﾁｯﾌﾟ数
        Dim strProductionLotId              As String           '製造ﾛｯﾄID
        Dim strShippingLotID                As String           '出荷ﾛｯﾄID
    End Structure

    '@CFKIﾛｯﾄ情報取得(lot_.cfkilotinfo 応答)
    Public Structure LotCfkiLotinfo
        Dim strLotID                        As String                       'ﾛｯﾄID
        Dim strPdId                         As String                       '機種ID
        Dim strPdName                       As String                       '機種名
        Dim strPartCode                     As String                       '部品ｺｰﾄﾞ(部材ｺｰﾄﾞ)
        Dim strPartName                     As String                       '部品名
        Dim strReworkCount                  As String                       'CFﾘﾜｰｸ数
        Dim strVenderName                   As String                       'ﾍﾞﾝﾀﾞｰ名
        Dim strComments                     As String                       'LOTｺﾒﾝﾄ
        Dim strChipQuantity                 As String                       'ﾁｯﾌﾟ現在数
        Dim lngMetalPaletteMapListCnt       As Integer                      '金属ﾊﾟﾚｯﾄﾏｯﾌﾟﾘｽﾄｶｳﾝﾄ
        Dim typMetalPaletteMapList          As List(Of MetalPaletteMapList) '金属ﾊﾟﾚｯﾄﾏｯﾌﾟﾘｽﾄ
        Dim strLotLastUpdate                As String                       '最終更新日時
        Dim strLotScrapSetID                As String                       '不良項目ｾｯﾄID
    End Structure

    '@CFKI作業入力要求(lot_.cfkimove 要求)
    Public Structure CfkiCarrierList
        Dim strCarrierID2                   As String           '移載先ｷｬﾘｱID
        Dim strNum                          As String           '搭載数
        Dim strCfArea                       As String           'CF区分
        Dim strComments                     As String           'LOTｺﾒﾝﾄ
    End Structure

    '@CFKI作業入力要求(lot_.cfkimove 要求)
    Public Structure LotCfkiMove
        Dim strMsgVer                       As String                   'Msgﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String                   'ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strCarrierID1                   As String                   '移載機元ｷｬﾘｱID
        Dim strLotLastUpdate                As String                   '移載機元ﾛｯﾄ最終更新日時
        Dim lngCfkiCarrierListCnt           As Integer                  '移載先ｷｬﾘｱﾏｯﾌﾟﾘｽﾄｶｳﾝﾄ
        Dim typCfkiCarrierList              As List(Of CfkiCarrierList) '移載先ｷｬﾘｱﾏｯﾌﾟﾘｽﾄ
        Dim strEmpID                        As String                   '作業者ID
    End Structure

    '@CFKI作業入力要求(lot_.cfkimove 応答)
    Public Structure TpLotList
        Dim strTpLotID                      As String           'TPALﾛｯﾄID
        Dim strCarrierId                    As String           '移載先ｷｬﾘｱID
    End Structure

    '@CFKI作業入力要求(lot_.cfkimove 応答)
    Public Structure LotCfkiMoveAns
        Dim lngTpLotListCnt                 As Integer            'TPALﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typTPLotList                    As List(Of TpLotList) 'TPALﾛｯﾄﾘｽﾄ
    End Structure

    '@TPAL編成ﾛｯﾄ情報取得(lot_.tpallotinfo 応答)
    Public Structure LotTpalLotList
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strTpLotID                      As String           'TPALﾛｯﾄID
        Dim strNum                          As String           '詰数
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strReworkCount                  As String           'ﾘﾜｰｸ回数
    End Structure

    '@TPAL編成ﾛｯﾄ情報取得(lot_.tpallotinfo 応答)
    Public Structure LotTpalLotInfo
        Dim lngLotTpalLotListCnt            As Integer                 'TPALﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typLotTpalLotList               As List(Of LotTpalLotList) 'TPALﾛｯﾄﾘｽﾄ
    End Structure

    '@TpalLotList⇒strLotLastUpdate追加、CoverCompLotList新規追加
    '@TPALﾛｯﾄ貼付(lot_.tpalcombstart 要求)
    Public Structure TpalLotList
        Dim strTpalLotId                    As String           '使用したTPALﾛｯﾄID
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ数
        Dim strChipOutQuantity              As String           '不良ﾁｯﾌﾟ数
        Dim strLotLastUpdate                As String           '最終更新日
    End Structure

    '@TPALﾛｯﾄ貼付(lot_.tpalcombstart 要求)
    Public Structure TpalCombStart
        Dim strMsgVer                       As String               'Msgﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String               'ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strLotID                        As String               'ﾛｯﾄID
        Dim typTpalLotList                  As List(Of TpalLotList) 'TPALﾛｯﾄﾘｽﾄ
        Dim strEmpID                        As String               '作業者ID
        Dim strLotLastUpdate                As String               'LOT最終更新日時
    End Structure

    '@TPAL貼合せ実績取得(lot_.tpalcombresult 応答)
    Public Structure CoverCompLotList
        Dim strTpalCarrierID                As String           '使用したTPALｷｬﾘｱID
        Dim strTpalLotId                    As String           '使用したTPALﾛｯﾄID
        Dim strChipCombQuantity             As String           '貼数(ﾁｯﾌﾟ)
        Dim strChipOutQuantity              As String           '不良数(ﾁｯﾌﾟ)
        Dim strChipRestQuantity             As String           '残数(ﾁｯﾌﾟ)
    End Structure

    '@TPAL貼合せ実績取得(lot_.tpalcombresult 応答)
    Public Structure CoverCompLot
        Dim lngCoverCompLotListCnt          As Integer                   'TPAL貼合せ実績ﾘｽﾄｶｳﾝﾄ
        Dim typCoverCompLotList             As List(Of CoverCompLotList) 'TPAL貼合せ実績ﾘｽﾄ
    End Structure

    '@CFﾘﾜｰｸ変更/CF不良登録 - Palette_List
    Public Structure PaletteList
        Dim strPaletteID                    As String           'ﾊﾟﾚｯﾄID
    End Structure

    '@CFﾘﾜｰｸ変更(lot_.cfkirework 要求)
    Public Structure ThicknessReworkList
        Dim strThicknessCode                As String           'CF板厚
        Dim strChipNum                      As String           'CFﾘﾜｰｸ数量
    End Structure

    '@CFﾘﾜｰｸ変更(lot_.cfkirework 要求)
    Public Structure LotCfkiRework
        Dim strMsgVer                       As String                       'Msgﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String                       'ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strLotID                        As String                       'ﾛｯﾄID
        Dim lngThicknessReworkListCnt       As Integer                      'CF板厚ﾘｽﾄｶｳﾝﾄ
        Dim typThicknessReworkList          As List(Of ThicknessReworkList) 'CF板厚ﾘｽﾄ
        Dim lngPaletteListCnt               As Integer                      'ﾊﾟﾚｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typPaletteList                  As List(Of PaletteList)         'ﾊﾟﾚｯﾄﾘｽﾄ
        Dim strEmpID                        As String                       '作業者ID
    End Structure

    '@CF不良登録(lot_.cfinsprst_ 要求)
    Public Structure ScrapList
        Dim strClass                        As String           '区分
        Dim strClassID                      As String           '項目ID
        Dim strNum                          As String           'ﾁｯﾌﾟ数
    End Structure

    '@CF不良登録(lot_.cfinsprst_ 要求)
    Public Structure LotCfinsprst
        Dim strMsgVer                       As String               'Msgﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String               'ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strLotID                        As String               'ﾛｯﾄID
        Dim lngScrapListCnt                 As Integer              '不良ﾘｽﾄｶｳﾝﾄ
        Dim typScrapList                    As List(Of ScrapList)   '不良ﾘｽﾄ
        Dim lngPaletteListCnt               As Integer              'ﾊﾟﾚｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typPaletteList                  As List(Of PaletteList) 'ﾊﾟﾚｯﾄﾘｽﾄ
        Dim strEmpID                        As String               '作業者ID
    End Structure

    '@CFKI数量取得(lot_.cfkinuminfo 要求)
    Public Structure LotCfkinuminfo
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strFlowClass                    As String           '流動区分
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strNowST                        As String           'LOT状態
        Dim strEngEmpName                   As String           '技術担当者名
        Dim strWorkDirectFlg                As String           '作業指示
        Dim strWorkCondition                As String           '作業条件
        Dim strSpecialFlg                   As String           '特殊特性
        Dim strPalletNum                    As String           'WF枚数
        Dim strLimitTime                    As String           '制限時間(時間制約)
        Dim strLotHoldFlag                  As String           'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strStartTime                    As String           '作業開始時刻(LOT状態が"後処理"の場合)
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ現在数
        Dim strChipOutQuantity              As String           'ﾁｯﾌﾟ不良数
        Dim strLotLastUpdate                As String           'LOT最終更新日時
        Dim strRegenerationCount            As String           '最大再生可能回数
        Dim strWarnTime                     As String           '警告時間
        Dim strRestrictTypeID               As String           '制限ﾀｲﾌﾟ
        Dim strWPType                       As String           'WP_TYPE(0：ﾊﾝﾄﾞﾜｰｸ)
    End Structure

    '@CFKI作業終了　⇔　対向基板ﾘﾜｰｸ不良登録　連携情報
    Public Structure CfkiRenkeiInfo
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim lngChipQuantity                 As Integer          '受入数
        Dim lngChipCarryingCount            As Integer          '既詰数
        Dim lngChipExpenditureCount         As Integer          '払出数
        Dim lngChipScrapCount               As Integer          '不良数
        Dim lngChipReworkCount              As Integer          'ﾘﾜｰｸ数
        Dim lngChipRemainCount              As Integer          '残数
        Dim strLotLastUpdate                As String           'LOT最終更新日時
    End Structure

    '@保管場所ﾏｽﾀ取得(mas_placelist 応答)
    Public Structure PlaceList
        Dim strPlaceID                      As String           'ｽﾄｯｶｰ№
        Dim strPlaceName                    As String           'ｽﾄｯｶｰ名
    End Structure

    '@ｼｽﾃﾑﾌﾞﾛｯｸﾘｽﾄ
    Public Structure SbList
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strSBName                       As String           'ｼｽﾃﾑﾌﾞﾛｯｸ名
    End Structure

    '@ｼｽﾃﾑﾌﾞﾛｯｸ取得(mas_.sblist__応答)
    Public Structure MasSbList
        Dim typSbList                       As List(Of SbList)  'ｼｽﾃﾑﾌﾞﾛｯｸ一覧
        Dim lngSbListCnt                    As Integer          'ｼｽﾃﾑﾌﾞﾛｯｸｶｳﾝﾄ
    End Structure

    '@廃棄WFﾘｽﾄ
    Public Structure WfScrapList
        Dim strWfId                         As String           'WFID
    End Structure

    '@WF廃棄(wf__.scrap__ 要求)
    Public Structure WfScrap
        Dim strCarrierId                    As String               'ｷｬﾘｱID
        Dim strComments                     As String               'ｺﾒﾝﾄ
        Dim strEmpID                        As String               '作業者ID
        Dim typWfList                       As List(Of WfScrapList) '廃棄WFﾘｽﾄ
    End Structure

    '@装置ｸﾞﾙｰﾌﾟﾘｽﾄ
    Public Structure McList
        Dim strMcGroupID                    As String           '装置ｸﾞﾙｰﾌﾟID
        Dim strMcGroupName                  As String           '装置ｸﾞﾙｰﾌﾟ名
        Dim strBatchFlag                    As String           'ﾊﾞｯﾁﾌﾗｸﾞ
    End Structure

    '@装置ｸﾞﾙｰﾌﾟ取得(mas_.mcgrouplist 要求)
    Public Structure McGroupList
        Dim typMcGroupList                  As List(Of McList)  '装置ｸﾞﾙｰﾌﾟﾘｽﾄ
        Dim lngMcGroupListCnt               As Integer          'ﾘｽﾄｶｳﾝﾄ
    End Structure

    '@ﾊﾞｯﾁ組ﾛｯﾄ情報取得(bat_.lotlist 要求)
    Public Structure BatRequestList
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strClassDivision                As String           '処理区分
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strMcGroupID                    As String           '装置ｸﾞﾙｰﾌﾟID
        Dim strWpID                         As String           'WPID
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞVer
    End Structure

    '@ﾊﾞｯﾁ組ﾛｯﾄ情報
    Public Structure BatList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strSeqNum                       As String           'ﾊﾞｯﾁ順序
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strjigId                        As String           '冶具ID
        Dim strWfId                         As String           'WFID
        Dim strUldCarrierID                 As String           'ｱﾝﾛｰﾀﾞｷｬﾘｱID
        Dim strConditionId                  As String           '処理条件
        Dim strCfFlag                       As String           'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strLpFlag                       As String           'LPﾌﾗｸﾞ(0：ODFﾛｯﾄ以外、1：ODFﾛｯﾄ)
        Dim strFlowClass                    As String           '流動区分
        Dim strFlowClassName                As String           '流動区分名
        Dim strLotPriority                  As String           '優先度
        Dim strSpecialFlag                  As String           '特殊特性
        Dim strLimitTime                    As String           '時間制約
        Dim strWFQuantity                   As String           'WF数量
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ数量
        Dim strOptionText                   As String           '作業条件
        Dim strEngEmpName                   As String           '技術担当
        Dim strStartTime                    As String           '処理開始予定日時
        Dim strCurrentStatusID              As String           'Lot状態ID
        Dim strCurrentStatusName            As String           'Lot状態
        Dim strLotLastUpdate                As String           'Lot最終更新日時
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strPdId                         As String           '機種ID+ﾊﾞｰｼﾞｮﾝ
        Dim strToOpId                       As String           '制限時間先大工程
        Dim strToStepId                     As String           '制限時間先小工程
        Dim strWarnTime                     As String           '警告時間
        Dim strRestrictTypeID               As String           '制限ﾀｲﾌﾟ
        Dim strUseId                        As String           '機種区分
        Dim strReworkFlag                   As String           'ﾘﾜｰｸﾌﾗｸﾞ
        Dim strVaFlag                       As String           '無機ﾌﾗｸﾞ
        Dim strJBatchId                     As String           '蒸着ﾊﾞｯﾁID
        Dim strHBatchId                     As String           '表面処理ﾊﾞｯﾁID
        Dim strInspectFlag                  As String           '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
        Dim strPairCarrier                  As String           '対ｷｬﾘｱ
    End Structure

    '@ﾊﾞｯﾁ組ﾛｯﾄﾘｽﾄ情報
    Public Structure BatLot
        Dim strBatchId                      As String           'ﾊﾞｯﾁID
        Dim strWpID                         As String           'WPID
        Dim strWpName                       As String           'WP名称
        Dim strRecipeId                     As String           'ﾚｼﾋﾟID
        Dim strVaConditionID                As String           '蒸着処理条件ID
        Dim strVaConditionFlag              As String           '蒸着処理条件制限ﾌﾗｸﾞ(1：有効、0：無効)
        Dim strEqType                       As String           '装置ﾀｲﾌﾟ
        Dim strMesModeId                    As String           '運用ﾓｰﾄﾞ
        Dim lngBatLotListCnt                As Integer          'ﾊﾞｯﾁﾛｯﾄﾘｽﾄｶｳﾝﾄ数
        Dim typBatList                      As List(Of BatList) 'ﾊﾞｯﾁ組ﾛｯﾄ情報
    End Structure

    '@ﾊﾞｯﾁ組ﾛｯﾄ情報取得(bat_.lotlist 応答)
    Public Structure BatLotList
        Dim lngBatLotCnt                    As Integer          'ﾊﾞｯﾁ組ﾛｯﾄﾘｽﾄ数
        Dim typBatLot                       As List(Of BatLot)  'ﾊﾞｯﾁ組ﾛｯﾄﾘｽﾄ
    End Structure

    '@ﾊﾞｯﾁﾛｯﾄ情報
    Public Structure BLotList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strLotLastUpdate                As String           'Lot最終更新日時
        Dim strLotKind                      As String           'ﾛｯﾄ区分(0：TFT、1：CF(小板)、2：CF(大板))
    End Structure

    '@ﾊﾞｯﾁ組ﾛｯﾄ作業開始(bat_.startwrk 要求)
    Public Structure BatStartWrk
        Dim strSbID                         As String            'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strBatchId                      As String            'ﾊﾞｯﾁID
        Dim strComments                     As String            '作業ﾒﾓ
        Dim strEmpID                        As String            '作業者ID
        Dim strMsgVer                       As String            'ﾒｯｾｰｼﾞVer
        Dim strClassDivision                As String            '処理区分
        Dim strEqType                       As String            '装置ﾀｲﾌﾟ
        Dim strWpID                         As String            '装置ID
        Dim strRecipeId                     As String            'ﾚｼﾋﾟID
        Dim lngBLotListCnt                  As Integer           'ﾊﾞｯﾁﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typBLotList                     As List(Of BLotList) 'ﾊﾞｯﾁﾛｯﾄﾘｽﾄ
    End Structure

    '@ﾛｯﾄｺﾒﾝﾄ取得(lot_.comntinfo 応答)
    Public Structure LotComntInfo
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strLotLastUpdate                As String           'Lot最終更新日時
    End Structure

    '@装置ﾛｯﾄﾘｽﾄ
    Public Structure McLot
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strFlowClass                    As String           '流動区分
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strNowST                        As String           'LOT状態
        Dim strDispatchStartTime            As String           '投入予定時刻
        Dim strWfNum                        As String           'WF枚数
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ数量
        Dim strLotHoldFlag                  As String           'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strLotStopFlag                  As String           'ﾛｯﾄ停止ﾌﾗｸﾞ
        Dim strLotPriority                  As String           '優先度
        Dim strLimitTime                    As String           '制限時間(時間制約)
        Dim strCurrentPositionName          As String           '現在位置名
        Dim strToOpId                       As String           '制限時間先大工程
        Dim strToStepId                     As String           '制限時間先小工程
        Dim strWarnTime                     As String           '警告時間
        Dim strRestrictTypeID               As String           '制限ﾀｲﾌﾟ
        Dim strReworkFlag                   As String           'ﾘﾜｰｸﾌﾗｸﾞ
        Dim strToCarrierId                  As String           'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
        Dim strAltNumber                    As String           '代替番号
        Dim strLcDirection                  As String           'L/R表示
        Dim strSendSBID                     As String           '送品先
        Dim strPdId                         As String           '機種ID
        Dim strPdVersion                    As String           '機種Ver
        Dim strJBatchId                     As String           '蒸着ﾊﾞｯﾁID
        Dim strCfFlag                       As String           'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strLpFlag                       As String           'LPﾌﾗｸﾞ(0：ODFﾛｯﾄ以外、1：ODFﾛｯﾄ)
        Dim strVaFlag                       As String           '無機ﾌﾗｸﾞ
        Dim strTpalClass                    As String           'TPAL区分
        Dim strSbArea                       As String           'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
    End Structure

    '@装置ﾛｯﾄﾘｽﾄ(lot_.mcalllotlist 応答)
    Public Structure McLotList
        Dim typMcLotList                    As List(Of McLot)   '装置ｸﾞﾙｰﾌﾟﾘｽﾄ
        Dim lngMcLotListCnt                 As Integer          'ﾘｽﾄｶｳﾝﾄ
    End Structure

    '@ﾊﾞｯﾁ組ﾛｯﾄ作業終了(bat_.endwrk 要求)
    Public Structure BatEndWrk
        Dim strSbID                         As String            'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strBatchId                      As String            'ﾊﾞｯﾁID
        Dim strComments                     As String            '作業ﾒﾓ
        Dim strEmpID                        As String            '作業者ID
        Dim strMsgVer                       As String            'ﾒｯｾｰｼﾞVer
        Dim strClassDivision                As String            '処理区分
        Dim strEqType                       As String            '装置ﾀｲﾌﾟ
        Dim lngBLotListCnt                  As Integer           'ﾊﾞｯﾁﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typBLotList                     As List(Of BLotList) 'ﾊﾞｯﾁﾛｯﾄﾘｽﾄ
    End Structure

    '@ﾊﾞｯﾁ組ﾛｯﾄ処理開始/終了(bat_.prcstart/bat_.prcend__ 要求)
    Public Structure BatPrcStartEnd
        Dim strSbID                         As String            'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strBatchId                      As String            'ﾊﾞｯﾁID
        Dim strComments                     As String            '作業ﾒﾓ
        Dim strEmpID                        As String            '作業者ID
        Dim strMsgVer                       As String            'ﾒｯｾｰｼﾞVer
        Dim strClassDivision                As String            '処理区分
        Dim strEqType                       As String            '装置ﾀｲﾌﾟ
        Dim lngBLotListCnt                  As Integer           'ﾊﾞｯﾁﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typBLotList                     As List(Of BLotList) 'ﾊﾞｯﾁﾛｯﾄﾘｽﾄ
    End Structure

    '@ﾊﾞｯﾁ作業終了 確定処理ﾛｯﾄID/最終更新日時格納構造体
    Public Structure LotEndList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strLastUpdate                   As String           '最終更新日時
        Dim strResultFlag                   As String           '処理結果ﾌﾗｸﾞ
    End Structure

    '@ﾊﾞｯﾁ作業終了 確定処理結果格納構造体(bat_.endwrk 応答)
    Public Structure BatLotEndList
        Dim lngLotEndListCnt                As Integer             'ｶｳﾝﾄ数
        Dim typLotEndList                   As List(Of LotEndList) '確定結果構造体
    End Structure

    '@装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄWPﾘｽﾄ
    Public Structure McGpLotWpList
        Dim strWpID                         As String           'WPID
        Dim strWpName                       As String           'WP名称
    End Structure

    '@装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄﾘｽﾄ
    Public Structure McGpLotList
        Dim strLotID                        As String                 'ﾛｯﾄID
        Dim strCarrierId                    As String                 'ｷｬﾘｱID
        Dim strLotPriority                  As String                 '優先度
        Dim strLimitTime                    As String                 '時間制約
        Dim strWFQuantity                   As String                 'WF数量
        Dim strOpID                         As String                 '大工程
        Dim strStepID                       As String                 '小工程
        Dim lngMcGpLotWpListCnt             As Integer                '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄWPﾘｽﾄ数
        Dim typMcGpLotWpList                As List(Of McGpLotWpList) '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄWPﾘｽﾄ
        Dim strRecipeId                     As String                 'ﾚｼﾋﾟID
        Dim strOptionText                   As String                 '作業条件
        Dim strCurrentStatusID              As String                 'Lot状態ID
        Dim strCurrentStatusName            As String                 'Lot状態
        Dim strLotLastUpdate                As String                 'Lot最終更新日時
        Dim strFlowClass                    As String                 '流動区分
        Dim strFlowClassName                As String                 '流動区分名
        Dim strUnlCarrierID                 As String                 'ｱﾝﾛｰﾀﾞｷｬﾘｱID
        Dim strUseId                        As String                 '機種区分
        Dim strToOpId                       As String                 '制限時間先大工程
        Dim strToStepId                     As String                 '制限時間先小工程
        Dim strWarnTime                     As String                 '警告時間
        Dim strRestrictTypeID               As String                 '制限ﾀｲﾌﾟ
        Dim strReworkFlag                   As String                 'ﾘﾜｰｸﾌﾗｸﾞ
        Dim strDispatchStartTime            As String                 '投入予定時刻
        Dim strCfFlag                       As String                 'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strLpFlag                       As String                 'LPﾌﾗｸﾞ(0：ODFﾛｯﾄ以外、1：ODFﾛｯﾄ)
        Dim strPdId                         As String                 '機種
        Dim strVaFlag                       As String                 '無機ﾌﾗｸﾞ
        Dim strJBatchId                     As String                 '蒸着ﾊﾞｯﾁID
        Dim strHBatchId                     As String                 '表面処理ﾊﾞｯﾁID
        Dim strInspectFlag                  As String                 '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
        Dim strPairCarrier                  As String                 '対ｷｬﾘｱ
        Dim lngMcGpLotWFListCnt             As Integer                '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄWFﾘｽﾄ数
        Dim typMcGpLotWFList                As List(Of WfList)        '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄWFﾘｽﾄ
    End Structure

    '@装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ情報取得(lot_.mcgplotlist 応答)
    Public Structure McGpLotInfo
        Dim lngMcGpLotListCnt               As Integer              '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄﾘｽﾄ数
        Dim typMcGpLotList                  As List(Of McGpLotList) '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄﾘｽﾄ
    End Structure

    '@ﾊﾞｯﾁ組変更ﾛｯﾄﾘｽﾄ
    Public Structure BatChangeLotList
        Dim strSeqNum                       As String           'ﾊﾞｯﾁ順序
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strjigId                        As String           '冶具ID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strLotLastUpdate                As String           'Lot最終更新日時
        Dim strUldCarrierID                 As String           'ｱﾝﾛｰﾀﾞｷｬﾘｱID
        Dim strWfId                         As String           'WFID
        Dim strPanelKind                    As String           'ﾊﾟﾈﾙ種類(0：TFT、1：CF)
        Dim strVaConditionID                As String           '蒸着処理条件
    End Structure

    '@ﾊﾞｯﾁ組ﾛｯﾄ登録変更(bat_.change__ 要求)
    Public Structure BatChange
        Dim strMsgVer                       As String                    'ﾒｯｾｰｼﾞVer
        Dim strSbID                         As String                    'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strClassDivision                As String                    '処理区分
        Dim strBatchId                      As String                    'ﾊﾞｯﾁID
        Dim lngBatChangeLotListCnt          As Integer                   'ﾊﾞｯﾁ組変更ﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typBatChangeLotList             As List(Of BatChangeLotList) 'ﾊﾞｯﾁ組変更ﾛｯﾄﾘｽﾄ
        Dim strWpID                         As String                    'WPID
        Dim strEmpID                        As String                    '作業者ID
        Dim strEqType                       As String                    '装置ﾀｲﾌﾟ
        Dim strRecipeId                     As String                    'ﾚｼﾋﾟID
    End Structure

    '@ﾕｰｻﾞｰｴﾝﾄﾘ取得(mas_.sppdentrylist 応答)
    Public Structure MasSppdentryList
        Dim llngSppdentryListCnt            As Integer            'ﾘｽﾄｶｳﾝﾄ数
        Dim typSppdentryList                As List(Of EntryList) 'ｴﾝﾄﾘﾘｽﾄ(流用：IDのみ格納で名称は空欄)
    End Structure

    '@組立ﾛｯﾄ投入(lot_.asmthrowin 要求)
    Public Structure LotAsmThrowIn
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞVer
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strBatchId                      As String           'ﾊﾞｯﾁID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strPdId                         As String           '機種ID
        Dim strEntryFlag                    As String           'ｴﾝﾄﾘﾌﾗｸﾞ(0:ｴﾝﾄﾘ選択/1:ﾕｰｻﾞｰﾌﾟﾛｾｽ選択)
        Dim strEntryID                      As String           'ｴﾝﾄﾘID
        Dim strLotPriority                  As String           '優先度
        Dim strComments                     As String           '作業ﾒﾓ
        Dim strEmpID                        As String           '作業者ID
        Dim strFlowClass                    As String           '流動区分
        Dim strEngEmpId                     As String           '技術担当者ID
        Dim strOrderNum                     As String           'ｵｰﾀﾞｰ№
        Dim strClassDivision                As String           '処理区分(0V；組立投入可能ﾛｯﾄ(量産以外)/3X；組立投入可能ﾛｯﾄ(量産のみ))
    '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。
    '    strCdenFlag                     As String           'ﾁｯﾌﾟ電特ﾌﾗｸﾞ(0:なし、1:あり)
    End Structure

    '@ﾀﾞﾐｰｶｾｯﾄﾛｰﾄﾞ/ｱﾝﾛｰﾄﾞ(dumy.chgstate 要求)
    Public Structure DumyChgState
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞVer
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strClassDivision                As String           '処理区分
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strCarrierStateFlg              As String           'ｷｬﾘｱ状態ﾌﾗｸﾞ
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strWpID                         As String           'WPID
        Dim strPortID                       As String           'ﾎﾟｰﾄID
        Dim strEmpID                        As String           '作業者ID
        Dim strLotLastUpdate                As String           'LOT最終更新日時
        Dim strComment                      As String           '作業ﾒﾓ
    End Structure

    '@ﾗﾋﾞﾝｸﾞ一覧ﾘｽﾄ
    Public Structure JigRubList
        Dim strRollID                       As String           'ﾛｰﾙID
        Dim strPdId                         As String           '機種ID
        Dim strRubbingDirection             As String           '方向
        Dim strUseNum                       As String           '使用回数
        Dim strExchangeDate                 As String           '張替日時
        Dim strExchangeEmpID                As String           '張替担当ID
        Dim strExchangeEmpName              As String           '張替担当名
        Dim strNarashiDate                  As String           '慣らし日時
        Dim strNarashiEmpID                 As String           '慣らし担当ID
        Dim strNarashiEmpName               As String           '慣らし担当名
        Dim strKarashiDate                  As String           '枯らし日時
        Dim strKarashiEmpID                 As String           '枯らし担当ID
        Dim strKarashiEmpName               As String           '枯らし担当名
        Dim strPrecedenceCheckDate          As String           '先行確認日時
        Dim strPrecedenceCheckEmpID         As String           '先行確認担当ID
        Dim strPrecedenceCheckEmpName       As String           '先行確認担当名
        Dim strPrecedenceCheckResult        As String           '先行確認結果
        Dim strEditTime                     As String           '最終更新日
        Dim strLcDirection                  As String           '液晶方向(L/R/Null)
    End Structure

    '@ﾗﾋﾞﾝｸﾞ一覧ﾘｽﾄ取得(jig_.rublist_ 応答)
    Public Structure JigRubbingList
        Dim lngRubbingListCnt               As Integer             'ﾗﾋﾞﾝｸﾞ一覧ﾘｽﾄｶｳﾝﾄ
        Dim typJigRubList                   As List(Of JigRubList) 'ﾗﾋﾞﾝｸﾞ一覧ﾘｽﾄ
    End Structure

    '@ﾗﾋﾞﾝｸﾞ登録(jig_.addrub__ 要求)
    Public Structure JigAddRub
        Dim strRollID                       As String           'ﾛｰﾙID
        Dim strPdId                         As String           '機種ID
        Dim strRubbingDirection             As String           '方向
        Dim strUseNum                       As String           '使用回数
        Dim strExchangeFlag                 As String           '張替ﾌﾗｸﾞ
        Dim strExchangeEmpID                As String           '張替担当ID
        Dim strNarashiFlag                  As String           '慣らしﾌﾗｸﾞ
        Dim strNarashiEmpID                 As String           '慣らし担当ID
        Dim strKarashiFlag                  As String           '枯らしﾌﾗｸﾞ
        Dim strKarashiEmpID                 As String           '枯らし担当ID
        Dim strPrecedenceCheckFlag          As String           '先行確認ﾌﾗｸﾞ
        Dim strPrecedenceCheckEmpID         As String           '先行確認担当ID
        Dim strPrecedenceCheckResult        As String           '先行確認結果
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞVer
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strEditTime                     As String           '最終更新日
    End Structure

    '@ﾗﾋﾞﾝｸﾞ削除(jig_.delrub__ 要求)
    Public Structure JigDelRub
        Dim strRollID                       As String           'ﾛｰﾙID
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞVer
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strEditTime                     As String           '最終更新日
    End Structure

    '@ｷｬﾘｱ状態確認(carr_.curstate 要求)
    Public Structure CarrCurstate
        Dim strClassDivision                As String           '処理区分
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞVer
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strCarrierTypeID                As String           'ｷｬﾘｱﾀｲﾌﾟ
        Dim strLotID                        As String           'ﾛｯﾄID(作業開始のみ要求)
        Dim strOpID                         As String           '大工程ID(作業開始のみ要求)
        Dim strStepID                       As String           '小工程ID(作業開始のみ要求)
        Dim strAltNumber                    As String           '代替番号(作業開始のみ要求)
    End Structure

    '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀﾘｽﾄ
    Public Structure LotCollectParams
        Dim strParameterID                  As String           'ﾊﾟﾗﾒｰﾀID
        Dim strParameterVersion             As String           'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
        Dim strUnit                         As String           '単位
        Dim strDataType                     As String           'ﾃﾞｰﾀﾀｲﾌﾟ
        Dim strClassification1              As String           'ﾃﾞｰﾀ分類1名
        Dim strClassification2              As String           'ﾃﾞｰﾀ分類2名
        Dim strClassification3              As String           'ﾃﾞｰﾀ分類3名
        Dim strClassification4              As String           'ﾃﾞｰﾀ分類4名
        Dim strMandatoryCount               As String           '必須項目数
        Dim strDvName                       As String           '装置報告ﾃﾞｰﾀ名
        Dim strCfFlag                       As String           'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strLpFlag                       As String           'LPﾌﾗｸﾞ(0：ODFﾛｯﾄ以外、1：ODFﾛｯﾄ)
        Dim strDataUnit                     As String           'ﾃﾞｰﾀ単位
        Dim strMeasureMode                  As String           '測定ﾓｰﾄﾞ
        Dim strCollectionType               As String           '収集項目ﾀｲﾌﾟ(0:作業記録、1:装置ﾃﾞｰﾀ)
        Dim strDataRetainFlag               As String           '装置ﾃﾞｰﾀ引継ぎﾌﾗｸﾞ
        Dim strDataCount                    As String           '発生ﾃﾞｰﾀ件数
        Dim strCeId                         As String           'CEID(0:正、1:異、Null:正)
    End Structure

    '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀﾘｽﾄ(lot_.collectparams 応答)
    Public Structure LotCollectParamsList
        Dim llngLotCollectParamsCnt         As Integer                   '収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀﾘｽﾄ数
        Dim strCategoryID                   As String                    'ｶﾃｺﾞﾘID
        Dim strLotDataCollCompFlag          As String                    'ﾛｯﾄﾃﾞｰﾀ収集完了ﾌﾗｸﾞ
        Dim typLotCollectParams             As List(Of LotCollectParams) '収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀ
    End Structure

    '@装置ﾃﾞｰﾀ参照ﾘｽﾄ
    Public Structure WfCollectionInfoList
        Dim strClassification1              As String           'ﾃﾞｰﾀ分類1名
        Dim strClassification2              As String           'ﾃﾞｰﾀ分類2名
        Dim strClassification3              As String           'ﾃﾞｰﾀ分類3名
        Dim strClassification4              As String           'ﾃﾞｰﾀ分類4名
        Dim strData                         As String           '登録値
        Dim strSpecCheck                    As String           '判定結果
    End Structure

    '@装置ﾃﾞｰﾀ参照取得(spc_.collectioninfo 要求)
    Public Structure CollectionInfoRequest
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strParameterID                  As String           'ﾊﾟﾗﾒｰﾀID
        Dim strParameterVersion             As String           'ﾊﾟﾗﾒｰﾀVer
        Dim strWfId                         As String           'WFID
    End Structure

    '@装置ﾃﾞｰﾀ参照取得(spc_.collectioninfo 応答)
    Public Structure WfCollectionInfo
        Dim lngWfCollectionInfoListCnt      As Integer                       '装置ﾃﾞｰﾀ参照数
        Dim typWfCollectionInfoList         As List(Of WfCollectionInfoList) '装置ﾃﾞｰﾀ参照ﾘｽﾄ
    End Structure

    '@装置WF登録ﾃﾞｰﾀﾘｽﾄ
    Public Structure EqWfDataEntry
        Dim strDvName                       As String           'ﾃﾞｰﾀ名
        Dim strDvNameParameter              As String           'ﾊﾟﾗﾒｰﾀID名
        Dim strDvValue                      As String           'ﾃﾞｰﾀ
        Dim strCollectionType               As String           '収集項目ﾀｲﾌﾟ(0:作業記録/1:装置ﾃﾞｰﾀ)
    End Structure

    '@装置ﾃﾞｰﾀ登録(wf__.chgcollection 要求)
    Public Structure WfChgCollection
        Dim strMsgVer                       As String                 'ﾒｯｾｰｼﾞVer
        Dim strSbID                         As String                 'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strClassDivision                As String                 '処理区分
        Dim strCarrierId                    As String                 'ｷｬﾘｱID
        Dim strParameterID                  As String                 'ﾊﾟﾗﾒｰﾀID
        Dim strParameterVersion             As String                 'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
        Dim strSlotPosition                 As String                 'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
        Dim lngEqWfDataEntryCnt             As Integer                '装置WF登録ﾃﾞｰﾀｶｳﾝﾄ
        Dim typEqWfDataEntry                As List(Of EqWfDataEntry) '装置WF登録ﾃﾞｰﾀ
        Dim strEmpID                        As String                 '作業者ID
        Dim strLotLastUpdate                As String                 'LOT最終更新日時
        Dim strDataDivision                 As String                 'DATA_DIVISION
    End Structure

    '@装置ﾃﾞｰﾀ登録(wf__.chgcollection 応答)
    Public Structure WfChgCollectionAns
        Dim strParameterID                  As String           'ﾊﾟﾗﾒｰﾀID
        Dim strParameterVersion             As String           'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
        Dim strSlotPosition                 As String           'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
        Dim lngResultCnt                    As Integer          '判定結果ｶｳﾝﾄ
        Dim strResult                       As List(Of String)  '判定結果
        Dim strLotLastUpdate                As String           'LOT最終更新日時
    End Structure

    '@社員名取得ﾘｽﾄ
    Public Structure DeptEmpList
        Dim strEmpID                        As String           '社員ID
        Dim strEmpName                      As String           '社員名
        Dim strMailAddress                  As String           'ﾒｰﾙｱﾄﾞﾚｽ
    End Structure

    '@社員名取得(mas_.deptemplist 応答)
    Public Structure DeptEmpInfo
        Dim lngDeptEmpListCnt               As Integer              'ﾘｽﾄｶｳﾝﾄ
        Dim typDeptEmpList                  As List(Of DeptEmpList) '社員名ﾘｽﾄ
    End Structure

    '@部門名取得ﾘｽﾄ
    Public Structure DepartmentList
        Dim strDeptCode                     As String           '部署ID
        Dim strDeptName                     As String           '部署名
        Dim typDeptEmpInfo                  As DeptEmpInfo      '社員名ﾘｽﾄ
    End Structure

    '@部署名取得(mas_.departmentlist 応答)
    Public Structure DepartmentInfo
        Dim lngDepartmentListCnt            As Integer                 'ﾘｽﾄｶｳﾝﾄ
        Dim typDepartmentList               As List(Of DepartmentList) '部門名ﾘｽﾄ
    End Structure

    '@異常処理項目名取得ﾘｽﾄ
    Public Structure TroubleItemList
        Dim strItemName                     As String
    End Structure

    '@異常処理項目名取得(mas_.troubleitemlist 応答)
    Public Structure TroubleItemInfo
        Dim lngTroubleItemListCnt           As Integer                  'ﾘｽﾄｶｳﾝﾄ
        Dim typTroubleItemList              As List(Of TroubleItemList) '異常処理項目名ﾘｽﾄ(異常処理系列/異常工程名/異常特性/WF処置/原因区分)
    End Structure

    '@ﾛｯﾄ処置WF情報ﾘｽﾄ
    Public Structure WFCauseList
        Dim strSlotPosition                 As String           'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
        Dim strWfId                         As String           'WFID
        Dim strExcpItemName                 As String           '異常特性
        Dim strWFDispoName                  As String           'WF処置名
    End Structure

    '@ﾛｯﾄ処置ﾘｽﾄ
    Public Structure CauseLotList
        Dim strLotID                        As String               '対象ﾛｯﾄID
        Dim strObjWafer                     As String               '対象ｳｪﾊ
        Dim strWFReserveQuantity            As String               '保留枚数
        Dim strWFAbandonQuantity            As String               '廃却枚数
        Dim strWFAmendQuantity              As String               '手直し流動枚数
        Dim strWFCorrectQuantity            As String               '矯正流動枚数
        Dim strWFUsualQuantity              As String               '通常流動枚数
        Dim strWFEvalQuantity               As String               '評価流動枚数
        Dim strWFTakeQuantity               As String               '特採流動枚数
        Dim strWFTotalQuantity              As String               '合計
        Dim strChipQuantity                 As String               'ﾁｯﾌﾟ数量
        Dim strDisposalFlag                 As String               '処置
        Dim strCauseOpIDName                As String               '原因大工程
        Dim strCauseStepIDName              As String               '原因小工程
        Dim strCauseWpName                  As String               '原因装置名
        Dim strCauseSeriesName              As String               '原因系列名
        Dim strCauseClassName               As String               '原因区分名
        Dim strCauseComments                As String               '原因内容
        Dim strStartWorkTeamName            As String               '開始作業者ﾁｰﾑ
        Dim strStartWorkEmpName             As String               '開始作業者
        Dim strEndWorkTeamName              As String               '終了作業者ﾁｰﾑ
        Dim strEndWorkEmpName               As String               '終了作業者
        Dim lngWfListCnt                    As Integer              'WFﾘｽﾄｶｳﾝﾄ
        Dim typWFCauseList                  As List(Of WFCauseList) 'WF状況ﾘｽﾄ
    End Structure

    '@異常処理票ﾘｽﾄ
    Public Structure ChgTroubleList
        Dim strExcpNo                       As String                '発行№
        Dim strFindDate                     As String                '発見日時
        Dim strFindDeptID                   As String                '発見者所属ID
        Dim strFindDeptName                 As String                '発見者所属名
        Dim strFindEmpID                    As String                '発見者氏名ID
        Dim strFindEmpName                  As String                '発見者氏名
        Dim strFindTelNo                    As String                '発見者電話番号
        Dim strReworkFlag                   As String                'ﾘﾜｰｸ有無
        Dim strProExcpName                  As String                '工程異常名
        Dim strExcpSeqFlag                  As String                '工程異常項目ﾌﾗｸﾞ
        Dim strExcpSeqOthr                  As String                '異常系列その他内容
        Dim lngPDIDListCnt                  As Integer               '機種ﾘｽﾄｶｳﾝﾄ
        Dim typPdList                       As List(Of PDList)       '機種ﾘｽﾄ
        Dim lngCauseLotListCnt              As Integer               'ﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typCauseLotList                 As List(Of CauseLotList) 'ﾛｯﾄﾘｽﾄ
        Dim strNum                          As String                '対象合計数
        Dim strWfNum                        As String                '対象合計数
        Dim strChipNum                      As String                '対象ﾁｯﾌﾟ合計数
        Dim strUnit                         As String                '単位
        Dim strFindOpIDName                 As String                '発見大工程名
        Dim strFindStepIDName               As String                '発見小工程名
        Dim strFindWpID                     As String                '発見時WPID
        Dim strFindWpName                   As String                '発見時WP名
        Dim strSituationComments            As String                '工程異常発生状況ｺﾒﾝﾄ
        Dim strInconguentFlag               As String                '不適合品発生有無
        Dim strEvalutionComments            As String                '異常内容評価ｺﾒﾝﾝﾄ
        Dim strRequestDeptID                As String                '依頼者所属ID
        Dim strRequestDeptName              As String                '依頼者所属名
        Dim strRequestEmpID                 As String                '依頼者氏名ID
        Dim strRequestEmpName               As String                '依頼者氏名
        Dim strRequestTelNo                 As String                '依頼者電話番号
        Dim strTrustOpID                    As String                '依頼先大工程
        Dim strTrustStepID                  As String                '依頼先小工程
        Dim strTrustDeptID                  As String                '依頼先所属ID
        Dim strTrustDeptName                As String                '依頼先所属名
        Dim strTrustEmpID                   As String                '依頼先氏名ID
        Dim strTrustEmpName                 As String                '依頼先氏名
        Dim strProcInflFlag                 As String                '後工程影響
        Dim strReliInflFlag                 As String                '信頼性影響
        Dim strDispoDirectDeptName          As String                '処置指示部署名
        Dim strInflChckDeptName             As String                '影響度確認部署名
        Dim strDirctContents                As String                '指示内容
        Dim strDirctInputDate               As String                '指示内容入力日時
        Dim strDirctInputEmpName            As String                '指示内容入力者名
        Dim strTechInvestCause              As String                '技術部門調査原因
        Dim strTechInvestEmpName            As String                '技術部門調査氏名
        Dim strTechInvestDate               As String                '技術部門調査日時
        Dim strManuInvestCause              As String                '製造部門調査原因
        Dim strManuInvestEmpName            As String                '製造部門調査氏名
        Dim strManuInvestDate               As String                '製造部門調査日時
        Dim strOthrInvestCause              As String                'その他部門調査原因
        Dim strOthrInvestEmpName            As String                'その他部門調査氏名
        Dim strOthrInvestDate               As String                'その他部門調査日時
        Dim strProvDirctContets             As String                '暫定対策指示内容
        Dim strProvDirctListName            As String                '指示帳票名
        Dim strProvDirctDeptName            As String                '指示部署名
        Dim strProvDirctInputDate           As String                '指示内容入力日時
        Dim strProvDirctInputEmpName        As String                '指示内容入力者名
        Dim strApplyFlag                    As String                '適応状態フラグ
        Dim strEmpID                        As String                '更新者ID
        Dim strEmpName                      As String                '更新者名
        Dim strEditTime                     As String                '最終更新日時
    End Structure

    '@異常処理登録/表示引継ぎ構造体
    Public Structure ExcpConnectList
        Dim strFindEmpID                    As String           '作業者ID
        Dim strFindEmpName                  As String           '作業者名
        Dim strFindDeptID                   As String           '所属ID
        Dim strFindDeptName                 As String           '所属名
        Dim strExcpNo                       As String           '異常処理№
        Dim strExcpFlag                     As String           '異常処理ﾌﾗｸﾞ(CM00H0:工程異常/CM00H1：不適合品)
        Dim strExcpInsFlag                  As String           '異常処理登録ﾌﾗｸﾞ(0:新規登録/1:更新/2:適用済み)
        Dim strFindDate                     As String           '発見日時
        Dim typLotList                      As BatLot           '引継ぎ情報格納構造体
    End Structure
    Public ptypExcpConnectList              As ExcpConnectList  '引継ぎ構造体

    '@投入予約工順登録(lot_.assythrowrsv 要求/応答)
    Public Structure Assythrowrsv
        Dim strSbID                         As String           'SB
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞVer
        Dim strClassDivision                As String           '処理区分
        Dim strPdId                         As String           '機種ID
        Dim strEntryID                      As String           'ｴﾝﾄﾘID
        Dim strEntryName                    As String           'ｴﾝﾄﾘ名
        Dim strEngEmpId                     As String           '技術担当
        Dim strCopySeqLotID                 As String           'ｺﾋﾟｰ元LotID
        Dim strCopySeqEntryID               As String           'ｺﾋﾟｰ元EntryID
        Dim strComment                      As String           'ｺﾒﾝﾄ
        Dim strEmpID                        As String           '作業者ID
        Dim strLotID                        As String           '生成LOTID
    End Structure

    '@工順ｺﾋﾟｰﾛｯﾄID(CM00J0)引継ぎ構造体
    Public Structure CM00J0
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim lngListIndex                    As Integer          'ListIndex(機種ｺﾝﾎﾞのｲﾝﾃﾞｯｸｽを格納)
        Dim strPdId                         As String           '機種ID
        Dim strClassDivisionPdlist          As String           '機種区分一覧取得用(ClassDivision)
        Dim strClassDivisionTravlist        As String           '工順元Lot一覧取得用(ClassDivision)
        Dim strFlowClass                    As String           '種別
        Dim strUserProcessFlag              As String           '投入予定工順登録(組立)から工順作成ﾁｪｯｸから呼ばれた場合のﾌﾗｸﾞ
    End Structure

    '@流動履歴情報取得
    Public Structure FlowRecord
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strWpID                         As String           '装置ID
        Dim strWpName                       As String           '装置名
        Dim strCauseSeriesName              As String           '原因系列
        Dim strStartWorkTeamName            As String           '開始作業者ﾁｰﾑ
        Dim strStartWorkEmpName             As String           '開始作業者名
        Dim strEndWorkTeamName              As String           '終了作業者ﾁｰﾑ
        Dim strEndWorkEmpName               As String           '終了作業者名
    End Structure

    '@流動履歴情報取得(lot_.simplitrvllist 応答)
    Public Structure SimpliTrvlList
        Dim lngSimpliTrvlListCnt            As Integer             'ﾘｽﾄｶｳﾝﾄ
        Dim typSimpliTrvlList               As List(Of FlowRecord) '流動履歴構造体
    End Structure
    Public ptypFlowRecord                   As FlowRecord       '流動履歴引継ぎ構造体

    '@ﾚﾁｸﾙ型番取得(mas_.rtclcodelist 応答)
    Public Structure RtclCodeList
        Dim lstrReticlePdCode               As String           '機種ｺｰﾄﾞ
        Dim lstrReticleMaskpattern          As String           'ﾏｽｸﾊﾟﾀｰﾝ
        Dim lstrReticleName                 As String           'ﾚﾁｸﾙ型番
    End Structure


    '@ﾚﾁｸﾙ情報取得(rtcl.list____ 応答)
    Public Structure RtclList
        Dim lstrReticleID                   As String           'ﾚﾁｸﾙID
        Dim lstrReticleStatusFlag           As String           'ﾚﾁｸﾙ状態ﾌﾗｸﾞ
        Dim lstrReticleStatusItemID         As String           'ﾚﾁｸﾙ状態項目ID
        Dim lstrReticleStatusItemName       As String           'ﾚﾁｸﾙ状態項目名
        Dim lstrCurrentPositionID           As String           'ﾚﾁｸﾙ現在位置ID
        Dim lstrCurrentPositionName         As String           'ﾚﾁｸﾙ現在位置名
        Dim lstrWPInFlag                    As String           '装置内ﾌﾗｸﾞ
        Dim lstrErrorFlag                   As String           'ﾚﾁｸﾙｴﾗｰﾌﾗｸﾞ
        Dim lstrGarbageInspection           As String           'ﾚﾁｸﾙｺﾞﾐ検査
        Dim lstrArriveTime                  As String           'ﾚﾁｸﾙ入荷日
        Dim lstrReasonCode                  As String           'ｴﾗｰ理由
        Dim lstrReasonComment               As String           'ｴﾗｰｺﾒﾝﾄ
        Dim lstrSmifID                      As String           'SMIFID
        Dim lstrEditTime                    As String           '最終更新日
        Dim lstrStockerInFlag               As String           'ｽﾄｯｶｰ内ﾌﾗｸﾞ
        Dim strCarrierStatID                As String           'ｷｬﾘｱ状態
        Dim strDestPositionID               As String           'ｷｬﾘｱ目的位置ID(搬送先)
        Dim strDestName                     As String           'ｷｬﾘｱ目的位置名(搬送先)
        Dim strTransferStatus               As String           '搬送ｽﾃｰﾀｽ(1:搬入予定、2:搬入可能、3:搬入済、4:搬出可能)
        Dim strTransferStatusName           As String           '搬送ｽﾃｰﾀｽ名(1:搬入予定、2:搬入可能、3:搬入済、4:搬出可能)
    End Structure

    '@ﾚﾁｸﾙ情報(rtcl.list____ 要求)
    Public Structure RtclList2
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strClassDivison                 As String           '処理区分
        Dim strReticlePdCode                As String           '機種ｺｰﾄﾞ
        Dim strReticleMaskPattern           As String           'ﾏｽｸﾊﾟﾀｰﾝ
        Dim strReticleName                  As String           'ﾚﾁｸﾙ型番
        Dim typWpList                       As List(Of WP)      '装置ID
        Dim lngWpListCnt                    As Integer          '装置ID数
    End Structure

    '@ﾚﾁｸﾙ登録情報(rtcl.regist__ 要求)
    Public Structure RtclRegist
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strReticleID                    As String           'ﾚﾁｸﾙID
        Dim strArriveTime                   As String           '入荷日
        Dim strEmpID                        As String           '作業者ID
        Dim strReticleName                  As String           'ﾚﾁｸﾙ型番
    End Structure

    '@ﾚﾁｸﾙ情報変更画面引継ぎ用
    Public Structure RtclInfChg
        Dim strReticleID                    As String           'ﾚﾁｸﾙID
        Dim strSmifID                       As String           'SMIFID
        Dim strReasonCode                   As String           'ｴﾗｰ理由
        Dim strReasonComments               As String           'ｴﾗｰｺﾒﾝﾄ
        Dim blnErrBtnFlg                    As Boolean          'ｴﾗｰﾎﾞﾀﾝﾌﾗｸﾞ
        Dim strEditTime                     As String           '最終更新日
    End Structure
    Public ptypRtclInfChg                   As RtclInfChg

    '@ﾚﾁｸﾙｴﾗｰ設定情報(rtcl.errset__ 要求)
    Public Structure RtclErrSet
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strClassDivison                 As String           '処理区分
        Dim strReasonCode                   As String           'ｴﾗｰ理由
        Dim strReasonComments               As String           'ｴﾗｰｺﾒﾝﾄ
        Dim strEmpID                        As String           '作業者ID
        Dim strReticleID                    As String           'ﾚﾁｸﾙID
        Dim strEditTime                     As String           '最終更新日
    End Structure

    '@ﾚﾁｸﾙ状態変更情報(rtcl.chgstat__ 要求)
    Public Structure RtclChgState
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strClassDivison                 As String           '処理区分
        Dim strReticleID                    As String           'ﾚﾁｸﾙID
        Dim strReticleStatusItemName        As String           'ﾚﾁｸﾙ状態項目名
        Dim strGarbageInspection            As String           'ﾚﾁｸﾙｺﾞﾐ検査
        Dim strEmpID                        As String           '作業者ID
        Dim strEditTime                     As String           '最終更新日
    End Structure

    '@大工程情報
    Public Structure MasOpId
        Dim strOpID                         As String           '大工程ID
        Dim strValidFlag                    As String           '状態ﾌﾗｸﾞ
    End Structure

    '@大工程情報(mas_.oplist__ 、mas_.useoplist 応答)
    Public Structure MasOpList
        Dim strCategoryID                   As String           'ｶﾃｺﾞﾘID
        Dim lngMasOpCnt                     As Integer          '大工程数
        Dim typMasOpId                      As List(Of MasOpId) '大工程情報
    End Structure

    '@小工程情報
    Public Structure MasStepId
        Dim strStepID                       As String           '小工程ID
        Dim strActionFlag                   As String           'ｱｸｼｮﾝﾌﾗｸﾞ(0：なし/1:作業開始/2：作業終了/4：全ﾀｲﾐﾝｸﾞ)
        Dim strValidFlag                    As String           '状態ﾌﾗｸﾞ
    End Structure

    '@小工程情報(mas_.steplist、mas_.usesteplist 応答)
    Public Structure MasStepList
        Dim strCategoryID                   As String             'ｶﾃｺﾞﾘID
        Dim lngMasStepCnt                   As Integer            '小工程数
        Dim typMasStepId                    As List(Of MasStepId) '小工程情報
    End Structure

    '@作業ﾐｽ報告書(excp.chgwkreport 要求/excp.wkreportinfo 要求)
    Public Structure ExcpWKReportList
        Dim strExcpNo                       As String           '異常処理NO
        Dim strGenDate                      As String           '発生日時
        Dim strGenEmpName                   As String           '発生者名
        Dim strGenDeptName                  As String           '発生者職場名
        Dim strFindEmpName                  As String           '発見者氏名
        Dim strManuExpYear                  As String           '製造経験年数
        Dim strManuExpMon                   As String           '製造経験月数
        Dim strEmpFlag                      As String           '社員区分ﾌﾗｸﾞ
        Dim strProcExpYear                  As String           '該当工程経験年数
        Dim strProcExpMon                   As String           '該当工程経験月数
        Dim strWfNoComments                 As String           '対象ｳｪﾊNoｺﾒﾝﾄ
        Dim strGenComments                  As String           '発生状況ｺﾒﾝﾄ
        Dim strClass                        As String           '区分
        Dim strStrdFlag                     As String           '標準面関連ﾌﾗｸﾞ
        Dim strStrdCause                    As String           '標準面原因
        Dim strStrdMeasure                  As String           '標準面対策
        Dim strStrdInputDate                As String           '標準面入力日
        Dim strEduFlag                      As String           '教育面関連ﾌﾗｸﾞ
        Dim strEduCause                     As String           '教育面原因
        Dim strEduMeasure                   As String           '教育面対策
        Dim strEduInputDate                 As String           '教育面入力日
        Dim strHimFlag                      As String           '人関連ﾌﾗｸﾞ
        Dim strHimCause                     As String           '人原因
        Dim strHimMeasure                   As String           '人対策
        Dim strHimInputDate                 As String           '人面入力日
        Dim strEqpFlag                      As String           '装置面関連ﾌﾗｸﾞ
        Dim strEqpCause                     As String           '装置面原因
        Dim strEqpMeasure                   As String           '装置面対策
        Dim strEqpInputDate                 As String           '装置面入力日
        Dim strReproPrice                   As String           '再生単価
        Dim strReproQuantity                As String           '再生枚数
        Dim strDefectPrice                  As String           '不良単価
        Dim strDefectQuantity               As String           '不良枚数
        Dim strForemanComments              As String           '作業長ｺﾒﾝﾄ
        Dim strChiefComments                As String           '課長ｺﾒﾝﾄ
    End Structure

    '@作業ﾐｽ報告書引継ぎ構造体
    Public Structure WKReportConnect
        Dim strSbID                         As String                '登録ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strExcpInsFlag                  As String                '引継ぎﾌﾗｸﾞ(0:新規登録/1:更新登録/2:適用済)
        Dim strExcpNo                       As String                '異常処理NO
        Dim strGenDate                      As String                '発生日時
        Dim strGenEmpName                   As String                '発生者名
        Dim strGenDeptID                    As String                '発生者職場ID
        Dim strGenDeptName                  As String                '発生者職場名
        Dim strFindEmpName                  As String                '発見者氏名
        Dim strFindOpIDName                 As String                '発生大工程名
        Dim strFindStepIDName               As String                '発生小工程名
        Dim strFindWpName                   As String                '発生時WP名
        Dim strPdId                         As String                '機種名
        Dim lngLotListCnt                   As String                'ﾘｽﾄｶｳﾝﾄ
        Dim typLotList                      As List(Of CauseLotList) 'ﾛｯﾄﾘｽﾄ
        Dim lngRegistFlag                   As Integer               '登録完了ﾌﾗｸﾞ
    End Structure
    Public ptypWkReportConnect              As WKReportConnect  '作業ﾐｽ報告書

    '@CFﾛｯﾄ終了要求格納構造体(lot_.cfend__ 要求)
    Public Structure LotCfEnd
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞVer
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strEmpID                        As String           '作業者ID
        Dim strLotLastUpdate                As String           'LOT最終更新日時
    End Structure

    '@ﾛｯﾄﾘｽﾄ
    Public Structure ExcpLotList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strDisposalFlag                 As String           '処置ﾌﾗｸﾞ(0:未処置/1:処置済)
    End Structure

    '@異常処理票一覧格納構造体(excp.troublelist 要求)
    Public Structure ExcpTroubleInfo
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞVer
        Dim strClassDivision                As String           '処理区分
        Dim strStartDate                    As String           '検索開始日
        Dim strEndDate                      As String           '検索終了日
        Dim strFindEmpID                    As String           '起案者ID
    End Structure

    '@異常処理票一覧格納構造体
    Public Structure ExcpTroubleList
        Dim strNo                           As String               '順番
        Dim strFindDate                     As String               '発見日時
        Dim strProExcpName                  As String               '工程異常名
        Dim strExcpNo                       As String               '発行№
        Dim strApplyFlag                    As String               '適応状態フラグ
        Dim lngLotListCnt                   As Integer              'ﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typExcpLotList                  As List(Of ExcpLotList) 'ﾛｯﾄﾘｽﾄ
        Dim strFindEmpID                    As String               '起案者ID
        Dim strFindEmpName                  As String               '起案者名
    End Structure

    '@異常処理票一覧格納構造体(excp.troublelist 応答)
    Public Structure ExcpTroubleListInfo
        Dim llngExcpTroubleListInfoCnt      As Integer                  'ｶｳﾝﾄ
        Dim typExcpTroubleList              As List(Of ExcpTroubleList) '工程異常格納構造体
        Dim llngExcpIncongListInfoCnt       As Integer                  'ｶｳﾝﾄ
        Dim typExcpIncongList               As List(Of ExcpTroubleList) '不適合品格納構造体
    End Structure

    '@処理確定格納構造体(excp.apply___ 要求)
    Public Structure ExcpApply
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞVer
        Dim strExcpNo                       As String           '発行№
    '    strListClass                    As String           '帳票種別(0:異常処理/1:不適合品) (R4-13削除)
        Dim strEditTime                     As String           '更新日時
        Dim strEmpID                        As String           '作業者ID
    End Structure

    '@不適合品処理票ﾘｽﾄ
    Public Structure ChgIncongList
        Dim strExcpNo                       As String           '発行№
        Dim strFindDate                     As String           '発見日時
        Dim strFindDeptID                   As String           '発見者所属ID
        Dim strFindDeptName                 As String           '発見者所属名
        Dim strFindEmpID                    As String           '発見者氏名ID
        Dim strFindEmpName                  As String           '発見者氏名
        Dim strFindTelNo                    As String           '発見者電話番号
        Dim strReworkFlag                   As String           'ﾘﾜｰｸ有無
        Dim strProExcpName                  As String           '工程異常名
        Dim strExcpSeqFlag                  As String           '工程異常項目ﾌﾗｸﾞ
        Dim strExcpSeqOthr                  As String           '異常系列その他内容
        Dim lngPDIDListCnt                  As Integer          '機種ﾘｽﾄｶｳﾝﾄ
        Dim typPdList                       As List(Of PDList)  '機種ﾘｽﾄ
        Dim lngCauseLotListCnt              As Integer          'ﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typCauseLotList                 As List(Of CauseLotList) 'ﾛｯﾄﾘｽﾄ
        Dim strNum                          As String           '対象合計数
        Dim strWfNum                        As String           '対象合計数
        Dim strChipNum                      As String           '対象ﾁｯﾌﾟ合計数
        Dim strUnit                         As String           '単位
        Dim strFindOpIDName                 As String           '発見大工程名
        Dim strFindStepIDName               As String           '発見小工程名
        Dim strFindWpID                     As String           '発見時WPID
        Dim strFindWpName                   As String           '発見時WP名
        Dim strSituationComments            As String           '工程異常発生状況ｺﾒﾝﾄ
        Dim strInconguentFlag               As String           '不適合品発生有無
        Dim strEvalutionComments            As String           '異常内容評価ｺﾒﾝﾝﾄ
        Dim strRequestDeptID                As String           '依頼者所属ID
        Dim strRequestDeptName              As String           '依頼者所属名
        Dim strRequestEmpID                 As String           '依頼者氏名ID
        Dim strRequestEmpName               As String           '依頼者氏名
        Dim strRequestTelNo                 As String           '依頼者電話番号
        Dim strTrustOpID                    As String           '依頼先大工程
        Dim strTrustStepID                  As String           '依頼先小工程
        Dim strTrustDeptID                  As String           '依頼先所属ID
        Dim strTrustDeptName                As String           '依頼先所属名
        Dim strTrustEmpID                   As String           '依頼先氏名ID
        Dim strTrustEmpName                 As String           '依頼先氏名
        Dim strProcInflFlag                 As String           '後工程影響
        Dim strReliInflFlag                 As String           '信頼性影響
        Dim strDispoDirectDeptName          As String           '処置指示部署名
        Dim strInflChckDeptName             As String           '影響度確認部署名
        Dim strDirctContents                As String           '指示内容
        Dim strDirctInputDate               As String           '指示内容入力日時
        Dim strDirctInputEmpName            As String           '指示内容入力者名
        Dim strDefectCharaName              As String           '不良特性名
        Dim strImprovComments               As String           '継続的改善取組ｺﾒﾝﾄ
        Dim strImprovFlag                   As String           '継続的改善取組ﾌﾗｸﾞ
        Dim strIncongArticleFlag            As String           '不適合品発生有無ﾌﾗｸﾞ
        Dim strIncongCheckComments          As String           '不適合品確認根拠
        Dim strIncongCheckDate              As String           '不適合品確認日
        Dim strIncongCheckDeptName          As String           '不適合品確認部署名
        Dim strIncongCheckEmpName           As String           '不適合品確認氏名
        Dim strIncongCheckGenFlag           As String           '不適合品発生量ﾌﾗｸﾞ
        Dim strIncongJdgDate                As String           '不適合品発生確認日
        Dim strIncongJdgDeptName            As String           '不適合品判定部署名
        Dim strIncongJdgEmpName             As String           '不適合品発生確認氏名
        Dim strThingAbandonFlag             As String           '廃却処置
        Dim strThingAmendFlag               As String           '手直し流動
        Dim strThingCorrectFlag             As String           '修正流動
        Dim strThingEvalFlag                As String           '評価流動
        Dim strThingTakeFlag                As String           '特採流動
        Dim strThingUsualFlag               As String           '通常流動
        Dim strThingProcDate                As String           '現品処置指示日
        Dim strThingProcDeptName            As String           '現品処置指示部署名
        Dim strThingProcEmpName             As String           '現品処置指示氏名
        Dim strThingProcListName            As String           '現品処置指示帳票名
        Dim strApplyFlag                    As String           '適用ﾌﾗｸﾞ
        Dim strEmpID                        As String           '更新者ID
        Dim strEmpName                      As String           '更新者名
        Dim strEditTime                     As String           '最終更新日時
        Dim strExcpDeleteFlag               As String           '異常処理票削除ﾌﾗｸﾞ
    End Structure

    '@ﾛｯﾄｲﾍﾞﾝﾄ履歴情報
    Public Structure LotEvent
        Dim strEntryTime                    As String           'ｲﾍﾞﾝﾄ日時
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strEmpID                        As String           '作業者ID
        Dim strEmpName                      As String           '作業者名
    End Structure

    '@ﾛｯﾄｲﾍﾞﾝﾄ履歴情報(lot_.eventlist 応答)
    Public Structure LotEventList
        Dim lngLotEventCnt                  As Integer          '工順変更中ﾛｯﾄ数
        Dim typLotEvent                     As List(Of LotEvent) '工順変更中ﾛｯﾄ工順情報
    End Structure

    '@ｶﾃｺﾞﾘID情報
    Public Structure MasCategoryId
        Dim strCategoryID                   As String           'ｶﾃｺﾞﾘID
    End Structure

    '@ｶﾃｺﾞﾘID情報(mas_.categoryidlist 応答)
    Public Structure MasCategoryIdList
        Dim lngMasCategoryIDCnt             As Integer                'ｶﾃｺﾞﾘID数
        Dim typMasCategoryID                As List(Of MasCategoryId) 'ｶﾃｺﾞﾘID情報
    End Structure

    '@処理条件ｾｯﾄID情報
    Public Structure MasCondition
        Dim strConditionId                  As String           '処理条件ID
        Dim strConditionVersion             As String           '処理条件ﾊﾞｰｼﾞｮﾝ
        Dim strOptionText                   As String           'ｵﾌﾟｼｮﾝﾃｷｽﾄ
        Dim strSkipFlag                     As String           'ｽｷｯﾌﾟﾌﾗｸﾞ
        Dim strTransMode                    As String           '移載ﾓｰﾄﾞ
        Dim strLoaderUnloaderFlag           As String           'ﾎﾟｰﾄ属性
        Dim strStatId                       As String           'ﾃﾞｰﾀ認定状態
        Dim strMaxVerFlag                   As String           'Maxﾊﾞｰｼﾞｮﾝﾌﾗｸﾞ
    End Structure

    '@処理条件ｾｯﾄID情報(mas_.conditionlist 応答)
    Public Structure MasConditionList
        Dim strCategoryID                   As String                'ｶﾃｺﾞﾘID
        Dim lngConditionCnt                 As Integer               '処理条件ｾｯﾄID数
        Dim typMasCondition                 As List(Of MasCondition) '処理条件ｾｯﾄID情報
    End Structure

    '@処理条件詳細情報
    Public Structure CondDetail
        Dim strWpID                         As String           '装置ID
        Dim strWpName                       As String           '装置名
        Dim strRecipeId                     As String           'ﾚｼﾋﾟID
        Dim strRecipeVersion                As String           'ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝ
        Dim strDefaultFlag                  As String           'ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
        Dim strWfId                         As String           'WFID
        Dim strComments                     As String           'ﾚｼﾋﾟｺﾒﾝﾄ
    End Structure

    '@ﾏｽﾀ処理条件詳細情報(mas_.conddetaillist 応答)
    Public Structure MasCondDetailList
        Dim lngMasCondDetailCnt             As Integer             '処理条件詳細数
        Dim typMasCondDetail                As List(Of CondDetail) '処理条件詳細情報
        Dim strSkipFlag                     As String              'ｽｷｯﾌﾟﾌﾗｸﾞ
        Dim strLoaderUnloaderFlag           As String              'ﾛｰﾀﾞｰｱﾝﾛｰﾀﾞｰﾌﾗｸﾞ
        Dim strTransModeName                As String              '移載ﾓｰﾄﾞ名
        Dim strWorkCondition                As String              '作業条件
        Dim strComments                     As String              'ｺﾒﾝﾄ
        Dim strBeforeCarrierTypeName        As String              '移載元ｷｬﾘｱ名
        Dim strAfterCarrierTypeName         As String              '移載先ｷｬﾘｱ名
        Dim strWpCommonRecipeFlag           As String              '装置共通ﾚｼﾋﾟﾌﾗｸﾞ( 0: 個別、1: 共通)
    End Structure

    '@ﾛｯﾄ処理条件詳細情報
    Public Structure LotCondDetail
        Dim strSeqNo                        As String              '工順番号(新)
        Dim blnEnableFlag                   As Boolean             '有効/無効ﾌﾗｸﾞ(新)
        Dim strOpID                         As String              '大工程
        Dim strStepID                       As String              '小工程
        Dim strWpCommonRecipeFlag           As String              '装置共通ﾚｼﾋﾟﾌﾗｸﾞ
        Dim lngCondDetailCnt                As Integer             '処理条件詳細情報数
        Dim typCondDetail                   As List(Of CondDetail) '処理条件詳細情報
    End Structure

    '@ﾛｯﾄ処理条件詳細情報(lot_.conddetaillist 応答)
    Public Structure LotCondDetailList
        Dim lngLotCondDetailCnt             As Integer                'ﾛｯﾄ処理条件詳細数
        Dim typLotCondDetail                As List(Of LotCondDetail) 'ﾛｯﾄ処理条件詳細情報
    End Structure

    '@測定条件情報
    Public Structure MeasureTerms
        Dim strSelectConditionID            As String           '測定条件ｾｯﾄID
        Dim strSlots                        As String           'ｽﾛｯﾄ(2桁の連番でｽﾛｯﾄを表す)
        Dim strBottomWafers                 As String           '下からのｳｴﾊｰ枚数
        Dim strMiddleWafers                 As String           '真中からのｳｴﾊｰ枚数
        Dim strTopWafers                    As String           '上からのｳｴﾊｰ枚数
        Dim strUserSelectFlag               As String           'ﾕｰｻﾞ選択ﾌﾗｸﾞ
        Dim strSelectRuleID                 As String           '選択ﾙｰﾙID
    End Structure

    '@測定条件情報(mas_.measuretermslist 応答)
    Public Structure MasMeasureTermsList
        Dim lngMeasureTermsCnt             As Integer               '選択ﾙｰﾙ数
        Dim typMeasureTerms                As List(Of MeasureTerms) '選択ﾙｰﾙ情報
    End Structure

    '@収集項目ﾊﾟﾗﾒｰﾀ情報
    Public Structure MasProcCollectionPara
        Dim strParameterID                  As String           'ﾊﾟﾗﾒｰﾀID
    End Structure

    '@収集項目情報
    Public Structure MasProcCollection
        Dim strCollectionID                 As String                         '収集項目ID
        Dim strCollectionVersion            As String                         '収集項目ﾊﾞｰｼﾞｮﾝ
        Dim strStatId                       As String                         '状態ﾌﾗｸﾞ
        Dim lngMasProcCollectionParaCnt     As Integer                        '収集項目ﾊﾟﾗﾒｰﾀ数
        Dim typMasProcCollectionPara        As List(Of MasProcCollectionPara) '収集項目ﾊﾟﾗﾒｰﾀ情報
    End Structure

    '@収集項目情報(mas_.proccollectionlist 応答)
    Public Structure MasProcCollectionList
        Dim strCategoryID                   As String                     'ｶﾃｺﾞﾘID
        Dim lngMasProcCollectionCnt         As Integer                    '収集項目情報数
        Dim typMasProcCollection            As List(Of MasProcCollection) '収集項目情報
    End Structure

    '@不良項目ｾｯﾄID情報
    Public Structure MasScrapSetId
        Dim strLotScrapSetID                As String           '不良項目ｾｯﾄID
    End Structure

    '@不良項目ｾｯﾄID情報(mas_.scrapsetidlist 応答)
    Public Structure MasScrapSetIdList
        Dim lngMasScrapSetIDCnt             As Integer                '不良項目ｾｯﾄID情報数
        Dim typMasScrapSetID                As List(Of MasScrapSetId) '不良項目ｾｯﾄID情報
    End Structure

    '@ﾚｼﾋﾟ一括変更ﾘｽﾄ
    Public Structure LotChgCollectRecpList
        Dim strOpID                         As String              '大工程
        Dim strStepID                       As String              '小工程
        Dim lngLotRecpChgWpListCnt          As Integer             'ﾚｼﾋﾟ一括変更WPﾘｽﾄ数
        Dim typLotRecpChgWpList             As List(Of CondDetail) '処理条件詳細情報
    End Structure

    '@ﾚｼﾋﾟ一括変更要求
    Public Structure LotChgCollectRecp
        Dim lngLotCghCollectRecpListCnt     As Integer                        'ﾚｼﾋﾟ一括変更ﾘｽﾄ数
        Dim typLotCghCollectRecpList        As List(Of LotChgCollectRecpList) 'ﾚｼﾋﾟ一括変更ﾘｽﾄ
    End Structure

    '@ﾚｼﾋﾟ一覧情報
    Public Structure MasRecipeName
        Dim strRecipeId                     As String           'ﾚｼﾋﾟID
        Dim strRecipeVersion                As String           'ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝ
        Dim strDefaultFlag                  As String           'ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
        Dim strComments                     As String           'ｺﾒﾝﾄ
    End Structure

    '@ﾚｼﾋﾟ一覧ﾘｽﾄ情報(mas_.recipenamelist 応答)
    Public Structure MasRecipeNameList
        Dim lngMasRecipeNameCnt             As Integer                'ﾚｼﾋﾟ一覧情報数
        Dim strWpID                         As String                 '装置ID
        Dim typMasRecipeName                As List(Of MasRecipeName) 'ﾚｼﾋﾟ一覧情報
    End Structure

    '@部材ｺｰﾄﾞﾘｽﾄ取得格納構造体(mas_.partlist 要求)
    Public Structure MasPartlist
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞVer
        Dim strPdId                         As String           '機種ID
        Dim strMasPdVersion                 As String           'PDﾊﾞｰｼﾞｮﾝ
        Dim strVenderClassId                As String           '部品ID(部材ID)
    End Structure

    '@ﾛｯﾄ再測定構造体(lot_.steprestart 要求)
    Public Structure LotStepRestart
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strLotLastUpdate                As String           '最終更新日時
        Dim strEmpID                        As String           '作業者ID
    End Structure

    '@代替工程取得(lot_.wrkstart 要求)
    Public Structure LotAltTraveler
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strClassDivision                As String           '処理区分
        Dim strPdId                         As String           '機種ID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strSTEPNUM                      As String           'ｽﾃｯﾌﾟ番号
        Dim strEntryID                      As String           'ｴﾝﾄﾘID
    End Structure

    '@代替工程取得(lot_.alttraveler 応答)代替工程ﾘｽﾄ
    Public Structure AltStepList
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strSeqNum                       As String           'ﾛｯﾄ工順
        Dim strReworkFlag                   As String           'ﾘﾜｰｸ工程有無ﾌﾗｸﾞ
        Dim strReworkRouteID                As String           'ﾘﾜｰｸ時ﾙｰﾄID
        Dim strActionFlag                   As String           'ｱｸｼｮﾝﾌﾗｸﾞ
    End Structure

    '@代替工程取得(lot_.alttraveler 応答)代替番号ﾘｽﾄ
    Public Structure AltNumberList
        Dim strAltNumber                    As String               '代替番号
        Dim lngAltStepCnt                   As Integer              '代替工程数
        Dim typAltStepList                  As List(Of AltStepList) '代替工程ﾘｽﾄ
    End Structure

    '@代替工程取得(lot_.alttraveler 応答)
    Public Structure LotAltStepList
        Dim lngAltNumberCnt                 As Integer                '代替数
        Dim lngStepCnt                      As Integer                '総件数
        Dim typAltNumberList                As List(Of AltNumberList) '代替番号ﾘｽﾄ
    End Structure

    '@ﾘﾜｰｸ工程取得(mas_.reworktraveler 応答)ﾘﾜｰｸ工程ﾘｽﾄ
    Public Structure ReworkStepList
        Dim strSTEPNUM                      As String           '工順番号
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strReworkReturnOpID             As String           'ﾘﾜｰｸ戻り先大工程
        Dim strReworkReturnStepID           As String           'ﾘﾜｰｸ戻り先小工程
        Dim strActionFlag                   As String           'ｱｸｼｮﾝﾌﾗｸﾞ
    End Structure

    '@ﾘﾜｰｸ工程取得(mas_.reworktraveler 応答)
    Public Structure MasReworkTraveler
        Dim lngReworkStepCnt                As Integer                 'ﾘﾜｰｸ工程数
        Dim typReworkStepList               As List(Of ReworkStepList) 'ﾘﾜｰｸ工程ﾘｽﾄ
    End Structure

    '@電特結果要求ﾘｽﾄ(elt_.Mapget__ 応答)
    Public Structure EltMapgetWFList
        Dim strWfId                         As String           'WFID
        Dim strResult                       As String           '測定結果
        Dim strComments                     As String           '測定結果ｺﾒﾝﾄ
    End Structure

    '@電特結果要求(elt_.Mapget__ 応答)
    Public Structure EltMapget
        Dim lngCnt                          As Integer                  '件数
        Dim typEltMapgetWFList              As List(Of EltMapgetWFList) '電特結果要求ﾘｽﾄ
    End Structure

    '@分割子ﾛｯﾄID
    Public Structure DivideLot2
        Dim strDivideLotID2                 As String           '分割子ﾛｯﾄID
    End Structure

    '@ﾛｯﾄ詳細情報取得(lot_.detail__ 応答)
    Public Structure LotDetailInfo
        Dim strLotID                        As String              'ﾛｯﾄID
        Dim strCarrierId                    As String              'ｷｬﾘｱID
        Dim strPdId                         As String              '機種ID
        Dim strFlowClass                    As String              '流動区分
        Dim strGrbClass                     As String              'GRB区分
        Dim strLotPriority                  As String              '優先度
        Dim strLotPriorityName              As String              '優先度名
        Dim strWfNum                        As String              'WF枚数
        Dim strChipQuantity                 As String              '良品ﾁｯﾌﾟ数
        Dim strEngEmpName                   As String              '技術担当者名
        Dim strCurrentPositionName          As String              'ﾛｯﾄ位置(和名)
        Dim strLastEventName                As String              '最終ｲﾍﾞﾝﾄ名
        Dim strEntryTime                    As String              '最終ｲﾍﾞﾝﾄ日時
        Dim strEmpName                      As String              '最終更新者
        Dim strComments                     As String              'ｺﾒﾝﾄ
        Dim strSpecialFlg                   As String              '特殊特性
        Dim strLotHoldFlag                  As String              'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strLotStopFlag                  As String              'ﾛｯﾄ停止ﾌﾗｸﾞ
        Dim strNowST                        As String              'LOT状態
        Dim strDispatchStartTime            As String              '投入予定時刻
        Dim strOpID                         As String              '大工程ID
        Dim strStepID                       As String              '小工程ID
        Dim strAltFlag                      As String              '代替工程有無ﾌﾗｸﾞ
        Dim strSwapFlag                     As String              '入替工程有無ﾌﾗｸﾞ
        Dim strReworkFlag                   As String              'ﾘﾜｰｸﾌﾗｸﾞ
        Dim strBatchId                      As String              'ﾊﾞｯﾁID
        Dim strWpName                       As String              'WP名
        Dim strPortName                     As String              'ﾎﾟｰﾄ名
        Dim strRecipeId                     As String              'ﾚｼﾋﾟID
        Dim strLoaderCarrierID              As String              'ﾛｰﾀﾞｰｷｬﾘｱID
        Dim strUnloaderCarrierID            As String              'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
        Dim strNextOpId                     As String              '次大工程
        Dim strNextStepId                   As String              '次小工程
        Dim strNextAltFlag                  As String              '代替次工程有無ﾌﾗｸﾞ
        Dim strNextSwapFlag                 As String              '入替次工程有無ﾌﾗｸﾞ
        Dim strDivideLotID                  As String              '分割親ﾛｯﾄID
        Dim lngDivideLot2Cnt                As Integer             '分割子ﾛｯﾄIDﾘｽﾄ数
        Dim typDivideLot2                   As List(Of DivideLot2) '分割子ﾛｯﾄIDﾘｽﾄ
        Dim strLimitTime                    As String              '制限時間(時間制約)
        Dim strToOpId                       As String              '制限時間先大工程
        Dim strToStepId                     As String              '制限時間先小工程
        Dim strWarnTime                     As String              '警告時間
        Dim strLotLastUpdate                As String              'LOT最終更新日時
        Dim strRestrictTypeID               As String              '制限ﾀｲﾌﾟ
        Dim strCfFlag                       As String              'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strVaFlag                       As String              'VAﾌﾗｸﾞ(0：有機、1：無機)
        Dim strKrfFileName                  As String              'KRFﾌｧｲﾙ名
        Dim strODFCarrierID                 As String              'ODFｷｬﾘｱID
        Dim strODFLotID                     As String              'ODFﾛｯﾄID
        Dim strLpFlag                       As String              'LPﾌﾗｸﾞ(0：ODFﾛｯﾄ以外、1：ODFﾛｯﾄ)
        Dim strLotSendFlag                  As String              '送品ﾌﾗｸﾞ(0:送品なし、1:送品あり)
    End Structure

    '@ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙ
    Public Structure GuideLevel
        Dim strGuideLevelID                 As String           'ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙID
        Dim strGuideLevelName               As String           'ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙ名
    End Structure

    '@ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙ取得(mas_.guilevelist 応答)
    Public Structure MasGuiLeveList
        Dim lngGuideLevelCnt                As Integer             'ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙ数
        Dim typGuideLevel                   As List(Of GuideLevel) 'ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙ
    End Structure

    '@ｶﾞｲﾀﾞﾝｽ情報
    Public Structure GuidInfo
        Dim strGuideTime                    As String           '発生日時
        Dim strWpID                         As String           'WPID
        Dim strWpName                       As String           'WP名
        Dim strPortID                       As String           'ﾎﾟｰﾄID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strGuideLevelID                 As String           'ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙID
        Dim strGuideCode                    As String           'ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ
        Dim strGuideMessage                 As String           'ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ
    End Structure

    '@ｶﾞｲﾀﾞﾝｽ情報取得(guid_.info____ 応答)
    Public Structure GuidInfoList
        Dim lngGuidInfoCnt                  As Integer           'ｶﾞｲﾀﾞﾝｽ情報数
        Dim typGuidInfo                     As List(Of GuidInfo) 'ｶﾞｲﾀﾞﾝｽ情報
    End Structure

    '@処理順号機設定解除(lot_.chgctlwp 要求)
    Public Structure Chgctlwp
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'SBID
        Dim strWpID                         As String           'WPID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strKindFlag                     As String           '設定解除ﾌﾗｸﾞ
        Dim strAltNumber                    As String           '代替番号
        Dim strLotLastUpdate                As String           'ﾛｯﾄ最終更新日付
        Dim strCarrierId                    As String           'ｷｬﾘｱID(成功ﾒｯｾｰｼﾞ用)
    End Structure

    '@在庫ﾛｯﾄ移載(Inv_.move____ 要求)
    Public Structure MoveList
        Dim strLotLastUpdate                As String           '移載先ﾛｯﾄ最終更新日時
        Dim strCarrierId                    As String           '移載先ｷｬﾘｱID
        Dim strLotID                        As String           '移載先ﾛｯﾄID
    End Structure

    '@在庫ﾛｯﾄ移載(Inv_.move____ 要求)
    Public Structure InvMove____
        Dim strMsgVer                       As String            'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strCarrierId                    As String            '移載元ｷｬﾘｱID
        Dim strEmpID                        As String            '作業者ID
        Dim llngMoveListCnt                 As Integer           '移載先ﾛｯﾄﾘｽﾄ件数
        Dim typMoveList                     As List(Of MoveList) '移載先ﾛｯﾄﾘｽﾄ
    End Structure

    '@在庫ﾛｯﾄ移載情報WFﾘｽﾄ取得(Inv_.moveinfo応答)
    Public Structure InvMoveInfoWFList
        Dim strWfId                         As String           'WFID
        Dim strSlotPosition                 As String           'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
        Dim strWFStatus                     As String           'WFｽﾃｰﾀｽ
        Dim strToCarrySlotPosition          As String           '移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
        Dim strDivideCombineStatus          As String           '分割/統合ｽﾃｰﾀｽ
        Dim strDivideCombineLotID           As String           '分割/統合先ﾛｯﾄID
        Dim strOrgDivideCombineLotID        As String           '分割／統合ﾛｯﾄID編集元ﾛｯﾄID
        Dim strToCarrierId                  As String           '移載先ｷｬﾘｱID
        Dim strToFlowClass                  As String           '移載先流動区分
        Dim strLotLastUpdate                As String           '移載元ﾛｯﾄ最終更新日時
        Dim strCarrierTypeID                As String           'ｷｬﾘｱﾀｲﾌﾟID
        Dim strSlotSize                     As String           'ｽﾛｯﾄｻｲｽﾞ
    End Structure

    '@在庫ﾛｯﾄ移載情報(Inv_.moveinfo応答)
    Public Structure InvMoveInfo
        Dim strLotEventId                   As String                     'ﾛｯﾄｲﾍﾞﾝﾄID
        Dim strLotID1                       As String                     'ﾛｯﾄID
        Dim strFlowClass                    As String                     '流動区分
        Dim strPdId                         As String                     '機種ID
        Dim strNowST                        As String                     'Lot状態
        Dim strLotStopFlag                  As String                     'ﾛｯﾄ停止ﾌﾗｸﾞ
        Dim strLotHoldFlag                  As String                     'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strWfNum                        As String                     'WF枚数
        Dim strWfCarryFlag                  As String                     'WF移載ﾌﾗｸﾞ
        Dim lngWfListCnt                    As Integer                    'WFﾘｽﾄｶｳﾝﾄ
        Dim typInvMoveInfoWFList            As List(Of InvMoveInfoWFList) 'WFﾘｽﾄ
    End Structure

    '@処理順一斉解除(lot_.canallseq要求用ﾘｽﾄ)
    Public Structure CanAllList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strLotLastUpdate                As String           'ﾛｯﾄ最終更新日付
    End Structure

    '@ｿｰﾄ保持ﾘｽﾄ
    Public Structure ChgSortList
        Dim lngCol                          As Integer          '列番号
        Dim lngOrder                        As Integer          '1：昇順、2：降順
    End Structure
    '@ｿｰﾄ保持用
    Public Structure ChgSort
        Dim lngCnt                          As Integer              'ｿｰﾄ回数
        Dim strKey                          As String               '行保持用
        Dim blnChgWidth                     As Boolean              '行保持用
        Dim typChgSortList                  As List(Of ChgSortList) 'ｿｰﾄ保持ﾘｽﾄ
    End Structure

    '@不具合№775対応でInv_.WaferListがWaferのみ格納
    '@元ﾛｯﾄID追加
    '@在庫ｳｪﾊﾘｽﾄ取得(inv_.waferlist 応答)
    Public Structure InvWafer
        Dim strWfId                         As String           'WFID
        Dim strSlotPosition                 As String           'WFｽﾛｯﾄ№
        Dim strWFStatus                     As String           'WFｽﾃｰﾀｽ名
        Dim strWFStatusID                   As String           'WFｽﾃｰﾀｽID
        Dim strBFLotID                      As String           '元ﾛｯﾄID
        Dim strChipQuantity                 As String           '良品ﾁｯﾌﾟ数
        Dim strChipOutQuantity              As String           '不良ﾁｯﾌﾟ数
        Dim strChipForwardQuantity          As String           '払出ﾁｯﾌﾟ数
        Dim strChipMarkQuantity             As String           '傾向ﾁｯﾌﾟ数
        '@↓2019/12/26 (Thu) 13:08:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
        Dim strGRBClass                     As String           'GRB
        '@↑2019/12/26 (Thu) 13:08:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
    End Structure

    Public Structure InvWaferList
        Dim lngInvWaferListCnt              As Integer           'ﾘｽﾄｶｳﾝﾄ
        Dim typInvWaferList                 As List(Of InvWafer) 'WFﾘｽﾄ
    End Structure

    '@流動票取得 WP_LIST(lot_.detaillist) 応答
    Public Structure LotDetailListWPListAry
        Dim strWpName                       As String           '装置名
        Dim strWpID                         As String           '装置ID
        Dim strPortName                     As List(Of String)  'ﾎﾟｰﾄ名
        Dim lngPortIDCount                  As Integer          'ﾎﾟｰﾄ件数
    End Structure

    '@流動票取得 DETAIL_LIST(lot_.detaillist) 応答
    Public Structure LotDetailListAry
        Dim strSeqNum                       As String                          'ﾛｯﾄ工順
        Dim strCarrierId                    As String                          'ｷｬﾘｱID
        Dim strOpID                         As String                          '大工程ID
        Dim strStepID                       As String                          '小工程ID
        Dim strStartTime                    As String                          '作業開始日時
        Dim strEndTime                      As String                          '作業終了日時
        Dim strRecipeId                     As String                          'ﾚｼﾋﾟID
        Dim typWpList                       As List(Of LotDetailListWPListAry) 'WP_LIST
        Dim lngWpListCount                  As Integer                         'WP_LIST件数
        Dim strCollectionFlag               As String                          'ﾃﾞｰﾀ収集有無
        Dim strWfNum                        As String                          'WF枚数
        Dim strChipNum                      As String                          'ﾁｯﾌﾟ良品数
        Dim strStartEmpName                 As String                          '開始作業者名
        Dim strEndEmpName                   As String                          '終了作業者名
        Dim strCommentFlag                  As String                          'ﾛｯﾄｺﾒﾝﾄ有無
        Dim strCommentTime                  As String                          'ｺﾒﾝﾄ登録日時
        Dim strCdenClass                    As String                          'ﾁｯﾌﾟ電特区分(限定工程設定=C：ﾁｯﾌﾟ品限定工程、M：ﾓｼﾞｭｰﾙ品限定工程、設定なし(NULL)：共通工程)
        Dim strDetailGrbClass               As String                          'GRB区分(流動票)
    End Structure

    '@流動票取得(lot_.detaillist) 応答
    Public Structure LotDetailList
        Dim strLotID                        As String                    'ﾛｯﾄID
        Dim strCarrierId                    As String                    'ｷｬﾘｱID
        Dim strPdId                         As String                    '機種ID
        Dim strCurrentSeqNum                As String                    '現在工順№
        Dim strOpID                         As String                    '現在大工程
        Dim strStepID                       As String                    '現在小工程
        Dim strNowST                        As String                    'ﾛｯﾄ現在状態
        Dim strWfNum                        As String                    'WF現在枚数
        Dim strHoldFlag                     As String                    '保留ﾌﾗｸﾞ
        Dim strStopFlag                     As String                    '停止ﾌﾗｸﾞ
        Dim strLastSeqNum                   As String                    '最終工順№
        Dim typDetailList                   As List(Of LotDetailListAry) '流動票情報
        Dim lngDetailListCount              As Integer                   '流動票情報件数
        Dim strLotLastUpdate                As String                    '最終更新日時
        Dim strSendSBID                     As String                    '送品先
        Dim strSbArea                       As String                    'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        Dim strLotGrbClass                  As String                    'GRB区分(LOT)
    End Structure

    '@大工程ﾛｯﾄﾘｽﾄ(lot_.oplotlist 要求)
    Public Structure OpLotList
        Dim strMsgVer                       As String                 'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String                 'SBID
        Dim strClassDivision                As String                 '処理区分
        Dim strOpID                         As String                 '大工程
        Dim strStepID                       As String                 '小工程
        Dim strStartDate                    As String                 '検索開始日
        Dim strEndDate                      As String                 '検索終了日
        Dim lngPdCnt                        As Integer                '機種区分の選択数
        Dim typPdList                       As List(Of PDList)        '機種区分
        Dim lngFlowClassCnt                 As Integer                '流動区分の選択数
        Dim typFlowClassList                As List(Of FlowClassList) '流動区分
        Dim strInventoryFlag                As String                   '在庫フラグ
    End Structure

    '@大工程ﾛｯﾄﾘｽﾄ
    Public Structure OpLotListList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strFlowClass                    As String           '流動区分
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strAltNumber                    As String           '代替番号
        Dim strNowST                        As String           'LOT状態
        Dim strEngEmpName                   As String           '技術担当者名
        Dim strWfNum                        As String           'WF枚数
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ数
        Dim strLotCommentsFlg               As String           'ﾛｯﾄｺﾒﾝﾄ有無ﾌﾗｸﾞ
        Dim strLotHoldFlag                  As String           'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strLotStopFlag                  As String           'ﾛｯﾄ停止ﾌﾗｸﾞ
        Dim strLotPriority                  As String           '優先度
        Dim strSecPriorityFlag              As String           '区間優先度ﾌﾗｸﾞ
        Dim strCurrentPositionName          As String           'ﾛｯﾄ位置(和名)
        Dim strLotLastUpdate                As String           'ﾛｯﾄ最終更新日時
        Dim strTemplateSeqNum               As String           'ﾃﾝﾌﾟﾚｰﾄ工順表示順序
        Dim strToCarrierId                  As String           'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
        Dim strReworkFlag                   As String           'ﾘﾜｰｸﾌﾗｸﾞ(1:ﾘﾜｰｸ　0:ﾘﾜｰｸなし)
        Dim strLcDirection                  As String           '液晶方向
        Dim strPlanShipDate                 As String           '送品予定日
        Dim strPlanFinishDate               As String           '完成予定日
        Dim strSendSBID                     As String           '送品先SBID
        Dim strSendSBName                   As String           '送品先名
        Dim strPdId                         As String           '機種ID
        Dim strPdVersion                    As String           '機種Ver
        Dim strJBatchId                     As String           '蒸着ﾊﾞｯﾁID
        Dim strCfFlag                       As String           'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strLpFlag                       As String           'LPﾌﾗｸﾞ(0：ODFﾛｯﾄ以外、1：ODFﾛｯﾄ)
        Dim strVaFlag                       As String           '無機ﾌﾗｸﾞ
        Dim strTpalClass                    As String           'TPAL区分
        Dim strSbArea                       As String           'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        Dim strEditLastUpdate               As String           '(LOT_EVENT_ID=14の)最終更新日時
        Dim strEditEmpName                  As String           '(LOT_EVENT_ID=14の)最終更新者
        Dim strPlanAssembleThrowinDate      As String           '組立投入予定日
        Dim strShipDiffDay                  As String           '進捗度
    End Structure

    '@大工程ﾛｯﾄﾘｽﾄ(lot_.oplotlist 応答)
    Public Structure OpLotListAns
        Dim typOpLotListList                As List(Of OpLotListList) '大工程ﾛｯﾄﾘｽﾄ
    End Structure

    '@投入移載ﾛｯﾄﾘｽﾄ(lot_.uncarrylist 応答用ﾘｽﾄ)
    Public Structure UnCarryPartList
        Dim strProductionLotId              As String           '製造ﾛｯﾄID
    End Structure

    '@投入移載ﾛｯﾄﾘｽﾄ(lot_.uncarrylist 応答用ﾘｽﾄ)
    Public Structure UnCarry
        Dim strThowinDate                   As String                   '投入確定日
        Dim strPdId                         As String                   '機種ID
        Dim strPdName                       As String                   '機種名
        Dim strLotID                        As String                   'ﾛｯﾄID
        Dim strFlowClass                    As String                   '流動区分(種別ID)
        Dim strFlowClassName                As String                   '流動区分(種別名)
        Dim strCarrierId                    As String                   'ｷｬﾘｱID
        Dim strWfNum                        As String                   'WF枚数
        Dim llngCarryPartListcnt            As Integer                  '製造ﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typUnCarryPartList              As List(Of UnCarryPartList) '製造ﾛｯﾄﾘｽﾄ
        Dim strEngEmpId                     As String                   '技術担当者ID
        Dim strEngEmpName                   As String                   '技術担当者名
    End Structure

    '@投入移載ﾛｯﾄﾘｽﾄ(lot_.uncarrylist 応答)
    Public Structure UnCarryList
        Dim llngUnCarryListcnt              As Integer          '投入移載ﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typUnCarry                      As List(Of UnCarry) '投入移載ﾛｯﾄﾘｽﾄ
    End Structure

    '@投入移載(lot_.forcedmove 要求)
    Public Structure Forcedmove
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'SBID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strCarrierId                    As String           'ｷｬﾘｱID(成功MSG用)
        Dim strEmpID                        As String           '作業者ID
        Dim strWpID                         As String           '装置ID
    End Structure

    '@部材履歴要求(inv_.history_ 要求)
    Public Structure HistoryRequest
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'SBID
        Dim strClassDivision                As String           '処理区分
        Dim strPartCode                     As String           '部材ｺｰﾄﾞ
        Dim strVenderClassId                As String           'ﾍﾞﾝﾀﾞｰ種別ID
        Dim strProductionLotId              As String           '製造ﾛｯﾄID
        Dim strShippingLotID                As String           'CFﾒｰｶｰ出荷ﾛｯﾄID
        Dim strStartDate                    As String           '検索開始日時(YYYY/MM/DD hh:mm:00)
        Dim strEndDate                      As String           '検索終了日時(YYYY/MM/DD hh:mm:59)
    End Structure

    '@部材履歴要求(inv_.history_ 応答)
    Public Structure AnswerHistory
        Dim strEventClass                   As String           'ｲﾍﾞﾝﾄ区分
        Dim strEventName                    As String           'ｲﾍﾞﾝﾄ区分(和名)
        Dim strReasonCode                   As String           '理由ｺｰﾄﾞ
        Dim strReasonName                   As String           '理由ｺｰﾄﾞ名
        Dim strLotID                        As String           '在庫ID
        Dim strProductionLotId              As String           '製造ﾛｯﾄID
        Dim strNum                          As String           '数量(後削除)
        Dim strAcceptNum                    As String           '受入数量
        Dim strScrapNum                     As String           '払出数量
        Dim strRecordTime                   As String           '記録日時
        Dim strEmpID                        As String           '作業者ID
        Dim strEmpName                      As String           '作業者名
        Dim strShippingLotID                As String           'CFﾒｰｶｰ出荷ﾛｯﾄID
        Dim strThicknessCode                As String           '板厚
        Dim strReworkCount                  As String           'ﾘﾜｰｸ数
        Dim strComments                     As String           'ｺﾒﾝﾄ(作業ﾒﾓ)
        Dim strIssueLotID                   As String           '払出先ﾛｯﾄID
        Dim strAcceptLotID                  As String           'ﾘﾜｰｸ元ﾛｯﾄID
    End Structure

    '@在庫履歴要求(inv_.history_ 応答)
    Public Structure InvHistory
        Dim typInvHistoryList               As List(Of AnswerHistory) '部材履歴要求構造体
        Dim strNowNum                       As String                 '現在数量
        Dim strAcceptTotalNum               As String                 '受入数量合計
        Dim strScrapTotalNum                As String                 '払出数量合計
        Dim lngInvHistoryListCnt            As Integer                'ｶｳﾝﾄ
    End Structure


    '@流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ要求(lot_.chgtraveler)
    Public Structure ChgTravelerList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strComments                     As String           'ｺﾒﾝﾄ(作業ﾒﾓ)
        Dim strLotLastUpdate                As String           '最終更新日時
        Dim strSamplingFlag                 As String           'ｻﾝﾌﾟﾘﾝｸﾞﾌﾗｸﾞ
    End Structure

    '@流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ要求(lot_.chgtraveler)
    Public Structure ChgTraveler
        Dim strSbID                         As String                   'SBID
        Dim strMsgVer                       As String                   'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strEmpID                        As String                   '作業者ID
        Dim lngChgTravelerCnt               As Integer                  '機種区分の選択数
        Dim typChgTravelerList              As List(Of ChgTravelerList) 'ﾛｯﾄﾘｽﾄ(流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ前)
    End Structure
            
    '@流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ応答(lot_.chgtraveler)
    Public Structure AnsTravelerList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
    End Structure

    '@流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ応答(lot_.chgtraveler)
    Public Structure AnsTraveler
        Dim lngAnsTravelerCnt               As Integer                  '機種区分の選択数
        Dim typAnsTravelerList              As List(Of AnsTravelerList) 'ﾛｯﾄﾘｽﾄ(流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ後)
    End Structure


    '@ﾛｯﾄ一覧取得(lot_.chgtrvlist 要求)
    Public Structure ChgTrvListRec
        Dim strSbID                         As String                'SBID
        Dim strMsgVer                       As String                'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim lngPdCnt                        As Integer               '機種区分の選択数
        Dim typPdList                       As List(Of PDList)       '機種区分
        Dim lngFlowClassListCnt             As Integer               '種別ｶｳﾝﾄ数
        Dim typFlowClassList                As List(Of DivisionList) '種別
        Dim strLotFlowStatusID              As String                'ﾛｯﾄ流動ｽﾃｰﾀｽID
        Dim strLotID                        As String                'ﾛｯﾄID
    End Structure

    '@ﾛｯﾄ一覧取得(lot_.chgtrvlist 応答)
    Public Structure ChgTrvListAns
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strFlowClass                    As String           '流動区分
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strNowST                        As String           'LOT状態
        Dim strEngEmpName                   As String           '技術担当者名
        Dim strLotHoldFlag                  As String           'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strLotStopFlag                  As String           'ﾛｯﾄ停止ﾌﾗｸﾞ
        Dim strLotPriority                  As String           '優先度
        Dim strCurrentPositionName          As String           'ﾛｯﾄ位置(和名)
        Dim strLotCommentsFlg               As String           'ﾛｯﾄｺﾒﾝﾄ有無ﾌﾗｸﾞ
        Dim strCommitFlag                   As String           '号機指定(1：指定　0：指定なし)
        Dim strLotLastUpdate                As String           'ﾛｯﾄ最終更新日付
        Dim strProcChangeFlag               As String           '工順変更有無(0：変更なし　1：変更あり)
        Dim strVersionChangeFlag            As String           '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ有無(0：なし、1：あり)
        Dim strEntryID                      As String           'ｴﾝﾄﾘID
        Dim strWfRecipeFlag                 As String           'WF個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ(0:ﾏｽﾀ 1:個別)
        Dim strLotRecipeFlag                As String           'ﾛｯﾄ個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ(0:ﾏｽﾀ 1:個別)
        Dim strMasEntryID                   As String           'ｴﾝﾄﾘID(ﾏｽﾀ最新ｴﾝﾄﾘ)
        Dim strPdId                         As String           '機種ID
        Dim strLcDirection                  As String           '液晶方向(L/R/Null)
        Dim strReworkFlag                   As String           'ﾘﾜｰｸ有無(0:なし、1:あり)
        Dim strSwapFlag                     As String           '入替有無(0:なし、1:あり)
        Dim strAltFlag                      As String           '代替有無(0:なし、1:あり)
        Dim strWfCarryFlag                  As String           'WF移載の有無(0:なし、1:あり)
        Dim strVerUpProhibitedFlag          As String           'ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ(0:可、1:不可)
        Dim strProhibitedEmpName            As String           '禁止設定者名
        Dim strProhibitedDeptName           As String           '禁止設定者部署名
        Dim strReworkCount                  As String           'ﾘﾜｰｸｶｳﾝﾄ
        Dim strSamplingFlag                 As String           'ｻﾝﾌﾟﾘﾝｸﾞﾌﾗｸﾞ(1:未来工程に抜取りあり,0:なし)
        Dim strSendSBID                     As String           '送品先
        Dim strSbArea                       As String           'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
    End Structure

    '@履歴情報引継ぎ構造体(流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟで使用)
    Public Structure RirekeiNextinfo
        Dim strLotID                        As String           'ﾛｯﾄID
    End Structure

    '@送品伝票情報取得-ﾛｯﾄﾘｽﾄ(inv_.getsendorderlist)
    Public Structure GetSendOrderListLotList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strBoxNo                        As String           '箱№
        Dim strFlowClass                    As String           '種別
        Dim strWFQuantity                   As String           'WF枚数
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ枚数
        Dim strPdId                         As String           '機種ｺｰﾄﾞ
        Dim strAtlasOrderNo                 As String           'ATLASｵｰﾀﾞｰ№
        Dim strExtPartCode                  As String           '仕掛品ｺｰﾄﾞ
        Dim strInvComments                  As String           '送品時ｺﾒﾝﾄ
        Dim strSBName                       As String           '送品元SB名
        Dim strAtlasPoint                   As String           '送品元ATLASﾎﾟｲﾝﾄ
        Dim strSendSBID                     As String           '送品先SBID
        Dim strSendSBName                   As String           '送品先SB名
        Dim strSendAtlasPoint               As String           '送品先ATLASﾎﾟｲﾝﾄ
        Dim strEmpName                      As String           '送品担当者
        Dim strSendDate                     As String           '送品日
        Dim strSbArea                       As String           'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
    End Structure

    '@送品伝票情報取得(inv_.getsendorderlist)
    Public Structure GetSendOrderList
        Dim lngLotListCount                 As Integer                          'ﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typLotList                      As List(Of GetSendOrderListLotList) 'ﾛｯﾄﾘｽﾄ
    End Structure

    '@ﾛｯﾄ検定表情報取得-(inv_.getlotexaminfo)
    Public Structure GetLotExamInfoWFList
        Dim strWfId                         As String           'WFID
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ数
    End Structure

    '@ﾛｯﾄ検定表情報取得(inv_.getlotexaminfo)
    Public Structure GetLotExamInfo
        Dim strLotID                        As String                        'ﾛｯﾄID
        Dim strBoxNo                        As String                        '箱№
        Dim strFlowClass                    As String                        '種別
        Dim strWFQuantity                   As String                        '送品WF数
        Dim strChipQuantity                 As String                        '送品ﾁｯﾌﾟ数
        Dim strPdId                         As String                        '機種
        Dim strAtlasOrderNo                 As String                        'ATLASｵｰﾀﾞｰ№
        Dim strSendDate                     As String                        '送品日
        Dim strSendSBName                   As String                        '送品先SB名
        Dim strWFThrowinDate                As String                        'WF投入日
        Dim strWFThrowinQuantity            As String                        '投入WF数
        Dim strWFFinishDate                 As String                        'WF完成日
        Dim strWFFinishQuantity             As String                        '完成WF数
        Dim strWFOutQuantity                As String                        '不良WF数
        Dim strWFIssueQuantity              As String                        '払出WF数
        Dim lngWFListCount                  As Integer                       'WFﾘｽﾄｶｳﾝﾄ
        Dim typWfList                       As List(Of GetLotExamInfoWFList) 'WFﾘｽﾄ
        Dim strChipThrowinQuantity          As String                        '投入ﾁｯﾌﾟ数
        Dim strChipOutQuantity              As String                        '不良ﾁｯﾌﾟ数
        Dim strGoodChipRatio                As String                        '組立歩留率
        Dim strInvComments                  As String                        '次SB連絡ｺﾒﾝﾄ
        Dim strExtPartCode                  As String                        '仕掛品ｺｰﾄﾞ
    End Structure

    '@搬送ﾓｰﾄﾞ取得(ｽﾄｯｶｰﾘｽﾄ)(fts_.mode____)
    Public Structure FtsStockerLIST
        Dim strStockerId                    As String           'ｽﾄｯｶｰID
        Dim strStockerName                  As String           'ｽﾄｯｶｰ名
        Dim strStatus                       As String           'ｽﾄｯｶｰ状態
        Dim strStatusName                   As String           'ｽﾄｯｶｰ状態名(和名)
        Dim strStockerCapacity              As String           'ｽﾄｯｶｰ収容状態ID
        Dim strStockerCapacityName          As String           'ｽﾄｯｶｰ収容状態名(和名)
        Dim strAlarmID                      As String           'ｶﾚﾝﾄｱﾗｰﾑID
        Dim strEditTime                     As String           '最終更新日時
    End Structure

    '@搬送ﾓｰﾄﾞ取得(ﾍﾞｲﾘｽﾄ)(fts_.mode____)
    Public Structure FtsBAYLIST
        Dim strBAYID                        As String           'ﾍﾞｲID
        Dim strBAYName                      As String           'ﾍﾞｲ名
        Dim strStatus                       As String           'ﾍﾞｲ状態(ID)
        Dim strStatusName                   As String           'ﾍﾞｲ状態名(和名)
        Dim strAlarmID                      As String           'ｶﾚﾝﾄｱﾗｰﾑID
        Dim strEditTime                     As String           '最終更新日時
    End Structure

    '@搬送ﾓｰﾄﾞ取得(ﾋﾞｰｸﾙﾘｽﾄ)(fts_.mode____)
    Public Structure FtsVehicleLIST
        Dim strVehicleID                    As String           'ﾋﾞｰｸﾙID
        Dim strVehicleName                  As String           'ﾋﾞｰｸﾙ名
        Dim strStatus                       As String           'ﾋﾞｰｸﾙ状態(ID)
        Dim strStatusName                   As String           'ﾋﾞｰｸﾙ状態名(和名)
        Dim strEditTime                     As String           '最終更新日時
    End Structure

    '@搬送ﾓｰﾄﾞ取得(fts_.mode____)
    Public Structure FtsMode
        Dim strTransferStatus               As String                  '搬送可能状態(ID)
        Dim strTransferStatusName           As String                  '搬送可能状態和名
        Dim strStatus                       As String                  '搬送ｻｰﾊﾞ状態(ID)
        Dim strStatusName                   As String                  '搬送ｻｰﾊﾞ状態和名
        Dim typFtsStockerLIST               As List(Of FtsStockerLIST) 'ｽﾄｯｶｰﾘｽﾄ
        Dim typFtsBAYLIST                   As List(Of FtsBAYLIST)     'BAYﾘｽﾄ
        Dim typFtsVehicleLIST               As List(Of FtsVehicleLIST) 'ﾋﾞｰｸﾙﾘｽﾄ
        Dim lngStockerListCnt               As Integer                 'ｽﾄｯｶｰﾘｽﾄｶｳﾝﾄ
        Dim lngBayListCnt                   As Integer                 'ﾍﾞｲﾘｽﾄｶｳﾝﾄ
        Dim lngVehicleListCnt               As Integer                 'ﾋﾞｰｸﾙﾘｽﾄｶｳﾝﾄ
    End Structure

    '@処理待ちﾛｯﾄ更新用LotList(ctl_.updwaitinglot)
    Public Structure UpWaitingLotList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strSeqNum                       As String           '処理順
    End Structure

    '@処理待ちﾛｯﾄ更新(ctl_.updwaitinglot)
    Public Structure CtlUpWaitingLot
        Dim strClassDivision                As String                    '処理区分
        Dim strSbID                         As String                    'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strWpID                         As String                    'WPID
        Dim strMsgVer                       As String                    'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim lngWaitingLotListCnt            As Integer                   'ﾘｽﾄｶｳﾝﾄ
        Dim typWaitingLotList               As List(Of UpWaitingLotList) '更新用ﾛｯﾄﾘｽﾄ
    End Structure

    '@CF在庫払出登録(inv_.cfforward)
    Public Structure InvCFForward
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strEventClass                   As String           'ｲﾍﾞﾝﾄ区分
        Dim strReasonCode                   As String           '払出理由ｺｰﾄﾞ
        Dim strReasonName                   As String           '払出理由名
        Dim strChipNum                      As String           'ﾁｯﾌﾟ数
        Dim strEmpID                        As String           '作業者ID
    End Structure

    '@CFﾛｯﾄ情報取得 要求(inv_.cflotinfo)
    Public Structure InvCFLotInfo
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strCarrierId                    As String           'ｷｬﾘｱID
    End Structure

    '@CFﾛｯﾄ情報取得 応答(inv_.cflotinfo)
    Public Structure InvCFLotInfoList
        Dim strReworkCount                  As String                 'ﾘﾜｰｸ数
        Dim strRegenerationCount            As String                 '最大ﾘﾜｰｸ数
        Dim lngThicknessCnt                 As Integer                '板厚ｶｳﾝﾄ
        Dim typThicknessList                As List(Of ThicknessList) '板厚構造体
    End Structure

    '@CFﾘﾜｰｸ登録(inv_.cfrework)-ThicknessList
    Public Structure CFThicknessList
        Dim strThicknessCode                As String           '板厚ｺｰﾄﾞ
        Dim strChipNum                      As String           'CFﾘﾜｰｸ数量
    End Structure

    '@CFﾘﾜｰｸ登録(inv_.cfrework)
    Public Structure InvRework
        Dim strMsgVer                       As String                   'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String                   'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strLotID                        As String                   'ﾛｯﾄID
        Dim strEmpID                        As String                   '作業者ID
        Dim lngThicknessCnt                 As Integer                  '板厚ｶｳﾝﾄ
        Dim typCFReowrkThickness            As List(Of CFThicknessList) '登録構造体
    End Structure

    '@規格値判定(spc_.Judge_)
    Public Structure SpcJudge
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strNextLotID                    As String           '作業終了後ﾛｯﾄID
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strEmpID                        As String           '作業者ID
        Dim strSpecCheck                    As String           '基準値判定結果(0:正常、1:SPC異常、2:規格値異常)
        Dim strSpecMsgCode                  As String           '基準値判定結果ﾒｯｾｰｼﾞｺｰﾄﾞ
        Dim strSpecMsg                      As String           '基準値判定結果ﾒｯｾｰｼﾞ
    End Structure

    '@共通OnError処理
    Public Structure OnErrorInfo
        Dim strMenuKey                      As String           '機能ID
        Dim strProcName                     As String           'ｴﾗｰ発生ﾌﾟﾛｼｰｼﾞｬ名
        Dim strErrPositionDetail            As String           'ｴﾗｰ発生箇所詳細
        Dim strErrMessage                   As String           'ｴﾗｰﾒｯｾｰｼﾞ
    End Structure

    '@共通OnError処理(Log)
    Public Structure OnErrorInfoLog
        Dim strDate                         As String           '日付
        Dim strTime                         As String           '時刻
        Dim strComputerName                 As String           '端末名
        Dim strIPaddress                    As String           'IPｱﾄﾞﾚｽ
        Dim strUserID                       As String           'ﾕｰｻﾞｰID
        Dim strSbID                         As String           'SBID
        Dim strTestStatus                   As String           'ﾃｽﾄｽﾃｰﾀｽ
        Dim strTerminalMode                 As String           '端末区分
        Dim lngErrNumber                    As String           'ｴﾗｰ№
        Dim strErrDescription               As String           'ｴﾗｰ説明
        Dim strMenuKey                      As String           '機能ID
        Dim strFormName                     As String           'ﾌｫｰﾑ名
        Dim strProcName                     As String           'ｴﾗｰ発生ﾌﾟﾛｼｰｼﾞｬ名
        Dim strErrPositionDetail            As String           'ｴﾗｰ発生箇所詳細
        Dim strErrMessage                   As String           'ｴﾗｰﾒｯｾｰｼﾞ
    End Structure

    '@ﾚﾁｸﾙ払出(rtcl.wpout____)要求
    Public Structure RtclWpout
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strClassDivision                As String           '処理区分
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strWpID                         As String           'WPID
        Dim strReticleID                    As String           '装置内ﾚﾁｸﾙID
        Dim strEmpID                        As String           '作業者ID
    End Structure

    '@ｽﾄｯｶｰ/装置搬送指示(carr.transfer)要求
    Public Structure CarrTransfer
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strClassDivision                As String           '処理区分
        Dim strCarrierId                    As String           'SMIF
        Dim strCurrentPositionID            As String           '搬送元ID(ｽﾄｯｶｰ搬送時：装置ID、装置搬送時：ｽﾄｯｶｰID)
        Dim strDestPositionID               As String           '搬送先ID(ｽﾄｯｶｰ搬送時：ｽﾄｯｶｰID、装置搬送時：装置ID)
        Dim strEmpID                        As String           '作業者ID
    End Structure

    '@研磨ﾚｰﾄ変更(eq__.chgcmprate)要求
    Public Structure Eqchgcmprate
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strWpID                         As String           'WPID
        Dim strHead                         As String           'ﾍｯﾄﾞ
        Dim strPlaten                       As String           'ﾌﾟﾗﾃﾝ
        Dim strPolRate                      As String           '研磨ﾚｰﾄ
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strEmpID                        As String           '作業者ID
        Dim strEditTime                     As String           '応答ﾒｯｾｰｼﾞ生成日時
    End Structure

    '@CMP状態変更(eq__.chgcmpstat)要求
    Public Structure Eqchgcmpstat
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strWpID                         As String           'WPID
        Dim strHead                         As String           'ﾍｯﾄﾞ
        Dim strPlaten                       As String           'ﾌﾟﾗﾃﾝ
        Dim strAvailFlag                    As String           '研磨ﾚｰﾄ使用可否(0：使用不可　1:使用可)
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strEmpID                        As String           '作業者ID
        Dim strEditTime                     As String           '応答ﾒｯｾｰｼﾞ生成日時
    End Structure

    '@CMPﾒﾝﾃﾅﾝｽｲﾍﾞﾝﾄ履歴取得(eq__.cmpeventlist)要求
    Public Structure EqcmpeventlistRec
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strWpID                         As String           'WPID
        Dim strHead                         As String           'ﾍｯﾄﾞ
        Dim strPlaten                       As String           'ﾌﾟﾗﾃﾝ
    End Structure

    '@CMPﾒﾝﾃﾅﾝｽｲﾍﾞﾝﾄ履歴取得(eq__.cmpeventlist)ﾘｽﾄ
    Public Structure Eqcmpeventlist
        Dim strEventName                    As String           'ｲﾍﾞﾝﾄ名
        Dim strEntryTime                    As String           '応答ﾒｯｾｰｼﾞ生成日時
        Dim strEmpName                      As String           '作業者名
        Dim strOldPolRate                   As String           '研磨ﾚｰﾄ(変更前)
        Dim strNewPolRate                   As String           '研磨ﾚｰﾄ(変更後)
        Dim strComments                     As String           'ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ
    End Structure

    '@CMPﾒﾝﾃﾅﾝｽｲﾍﾞﾝﾄ履歴取得(eq__.cmpeventlist)応答
    Public Structure EqcmpeventlistAns
        Dim lngEqcmpeventlistCnt            As Integer                 'ﾘｽﾄｶｳﾝﾄ
        Dim typEqcmpeventlist               As List(Of Eqcmpeventlist) '履歴ﾘｽﾄ
    End Structure

    '@CMP情報一覧取得(eq__.cmplist_)要求
    Public Structure EqcmplistRec
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strWpID                         As String           'WPID
    End Structure

    '@CMP情報一覧取得(eq__.cmplist_)ﾍｯﾄﾞﾌﾟﾗﾃﾝﾘｽﾄ
    Public Structure HeadPlatenList
        Dim strHead                         As String           'ﾍｯﾄﾞ
        Dim strPlaten                       As String           'ﾌﾟﾗﾃﾝ
        Dim strPolRate                      As String           '研磨ﾚｰﾄ
        Dim strRateCalcTime                 As String           'ﾚｰﾄ計算日時
        Dim strLotID                        As String           'ﾚｰﾄ計算ﾛｯﾄID
        Dim strCmpOpID                      As String           'CMP大工程
        Dim strPolTime                      As String           '研磨時間
        Dim strCmp1st                       As String           '1st膜厚
        Dim strCmp2nd                       As String           '2nd膜厚
        Dim strAvailFlag                    As String           '研磨ﾚｰﾄ使用可否
        Dim strEventName                    As String           'ｲﾍﾞﾝﾄ名
        Dim strComments                     As String           'ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ
        Dim strEmpName                      As String           '作業者名
    End Structure

    '@CMP情報一覧取得(eq__.cmplist_)CMPﾘｽﾄ
    Public Structure CmpList
        Dim strWpID                         As String                  'WPID
        Dim strWpName                       As String                  'WP名
        Dim lngHeadPlatenListCnt            As Integer                 'ﾍｯﾄﾞﾌﾟﾗﾃﾝﾘｽﾄｶｳﾝﾄ
        Dim typHeadPlatenList               As List(Of HeadPlatenList) 'ﾍｯﾄﾞﾌﾟﾗﾃﾝﾘｽﾄ
    End Structure

    '@CMP情報一覧取得(eq__.cmplist_)応答
    Public Structure EqcmplistAns
        Dim strEditTime                     As String           '応答ﾒｯｾｰｼﾞ生成日時
        Dim lngCmpListCnt                   As Integer          'CMPﾘｽﾄｶｳﾝﾄ
        Dim typCmpList                      As List(Of CmpList) 'CMPﾘｽﾄ
        Dim lngCmpListAnsCnt                As Integer          '総ﾃﾞｰﾀ件数
    End Structure

    '@ﾒﾝﾃﾅﾝｽ履歴表示用引継ぎ構造体
    Public Structure CmpRirekeiinfo
        Dim strWpID                         As String           'WPID
        Dim strWpName                       As String           '装置名
        Dim strHead                         As String           'ﾍｯﾄﾞ
        Dim strPlaten                       As String           'ﾌﾟﾗﾃﾝ
        Dim strPolRate                      As String           '研磨ﾚｰﾄ
        Dim strRateCalcTime                 As String           'ﾚｰﾄ計算日時
        Dim strLotID                        As String           'ﾚｰﾄ計算ﾛｯﾄID
        Dim strCmpOpID                      As String           'CMP大工程
        Dim strPolTime                      As String           '研磨時間
        Dim strCmp1st                       As String           '1st膜厚
        Dim strCmp2nd                       As String           '2nd膜厚
        Dim strAvailFlag                    As String           '研磨ﾚｰﾄ使用可否
    End Structure

    '@ﾌﾟﾛｾｽﾘｽﾄ取得(mas_.pclist__)要求
    Public Structure pclistreq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strFlowType                     As String           'ﾌﾛｰﾀｲﾌﾟ
    End Structure

    '@ﾌﾟﾛｾｽﾘｽﾄ取得(mas_.pclist__)応答：ﾌﾟﾛｾｽﾘｽﾄ
    Public Structure pclist
        Dim strPCID                         As String           'PC_ID
    End Structure

    '@ﾌﾟﾛｾｽﾘｽﾄ取得(mas_.pclist__)応答
    Public Structure pclistAns
        Dim lngPCListCnt                    As Integer          'ﾘｽﾄｶｳﾝﾄ
        Dim typPCList                       As List(Of pclist)  'PC_ID
    End Structure

    '@送品取消構造体(lot_.cancelsend)要求
    Public Structure SendCancelList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strLotLastUpdate                As String           '最終更新日時
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strEmpID                        As String           '作業者ID
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strCarrierId                    As String           'ｷｬﾘｱID
    End Structure

    '@ﾒｰﾙ送信内容格納
    Public Structure SendMail
        Dim strId                           As String           'ﾕｰｻﾞID
        Dim strName                         As String           'ﾕｰｻﾞ名
        Dim strMail1                        As String           'ﾒｰﾙｱﾄﾞﾚｽ1
    End Structure

    '@ﾒｰﾙ送信用格納構造体
    Public Structure SendMailList
        Dim lngSendMailCnt                  As Integer           'ﾒｰﾙﾘｽﾄｶｳﾝﾄ
        Dim typSendMail                     As List(Of SendMail) 'ﾒｰﾙ宛先ﾘｽﾄ
    End Structure

    '@ﾒｰﾙ送信
    Public Structure MessageList
        Dim strApoCode                      As String           'APOｺｰﾄﾞ
    End Structure

    '@ﾒｰﾙ送信
    Public Structure MailList
        Dim strMailAddress                  As String           'ﾒｰﾙｱﾄﾞﾚｽ
    End Structure

    '@ﾒｰﾙ送信用格納構造体(guid.sendmessage)
    Public Structure SendMessageList
        Dim lngMessageListCnt               As Integer              'APOﾘｽﾄｶｳﾝﾄ
        Dim typMessageList                  As List(Of MessageList) 'APOﾘｽﾄ
        Dim lngMailListCnt                  As Integer              '宛先ﾘｽﾄｶｳﾝﾄ
        Dim typMailList                     As List(Of MailList)    '宛先ﾘｽﾄ
        Dim strMessage                      As String               'ﾎﾟｯﾌﾟｱｯﾌﾟﾒｯｾｰｼﾞ内容
        Dim strMailSubject                  As String               'ﾒｰﾙｻﾌﾞｼﾞｪｸﾄ
        Dim strMailContents                 As String               'ﾒｰﾙ本文
        Dim strMsgVer                       As String               'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSendEmpID                    As String               '送信者ID
        Dim strSendEmpName                  As String               '送信者名
    End Structure

    '@ﾒｰﾙ内容引継ぎ(異常処理→ﾒｰﾙ送信)
    Public Structure MailInfo
        Dim strMailSubject                  As String           'ﾒｰﾙｻﾌﾞｼﾞｪｸﾄ
        Dim strMailContents                 As String           'ﾒｰﾙ本文
    End Structure


    '@量産計画ﾘﾘｰｽ取込ｴﾗｰ構造体(atls.chgplan_)応答
    Public Structure PlanErrorList
        Dim strExtPartCode                  As String           '仕掛品ｺｰﾄﾞ(ｴﾗｰ)
        Dim strOrderNum                     As String           'ｵｰﾀﾞ№
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strErrComment                   As String           'ｴﾗｰｺﾒﾝﾄ
    End Structure

    '@量産計画ﾘﾘｰｽ取込構造体(atls.chgplan_)応答
    Public Structure AtlasChgPlanAns
        Dim lngPlanErrorListCnt             As Integer                'ﾘｽﾄｶｳﾝﾄ
        Dim typPlanErrorList                As List(Of PlanErrorList) '量産計画ﾘﾘｰｽ取込ｴﾗｰ構造体
    End Structure

    '@量産計画ﾘﾘｰｽ構造体(atls.planlist)要求
    Public Structure AtlasPlanListReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strStartDate                    As String           '開始日
        Dim strEndDate                      As String           '終了日
        Dim lngPdListCnt                    As Integer          '機種ﾘｽﾄｶｳﾝﾄ
        Dim typPdList                       As List(Of PDList)  '機種ﾘｽﾄ
    End Structure

    '@量産計画ﾘﾘｰｽ構造体(atls.planlist)応答
    Public Structure PlanList
        Dim strAuthFlag                     As String           '承認ﾌﾗｸﾞ(0:未承認/1:承認済)
        Dim strOrderNum                     As String           'Atlasｵｰﾀﾞｰ№
        Dim strPdId                         As String           '機種ｺｰﾄﾞ
        Dim strPlanQuantity                 As String           '計画数量
        Dim strPlanThrowinDate              As String           '投入予定日
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strEmpID                        As String           '作業者ID
        Dim strEmpName                      As String           '作業者名
        Dim strAuthDate                     As String           'ﾘﾘｰｽ日時
        Dim strEntryDate                    As String           '投入日時
        Dim strLcDirection                  As String           '液晶方向(L/R/Null)
        Dim strSendSBID                     As String           '送品先ID
        Dim strSendSBName                   As String           '送品先(和名)
        Dim strSbArea                       As String           'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
    End Structure

    '@量産計画ﾘﾘｰｽ構造体(atls.planlist)応答
    Public Structure AtlasPlanListAns
        Dim lngAtlasPlanListCnt             As Integer           'ﾘｽﾄｶｳﾝﾄ
        Dim typPlanList                     As List(Of PlanList) '量産計画ﾘﾘｰｽ構造体
    End Structure

    '@量産計画承認構造体(atls.auth____)要求
    Public Structure OrderList
        Dim strOrderNum                     As String           'Atlasｵｰﾀﾞｰ№
        Dim strPdId                         As String           '機種ｺｰﾄﾞ
        Dim strPlanThrowinDate              As String           '投入予定日
        Dim strPlanQuantity                 As String           '計画数量
    End Structure

    '@量産計画承認構造体要求ﾃﾞｰﾀ格納
    Public Structure AtlasAuth____Req
        Dim strMsgVer                       As String             'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String             'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strEmpID                        As String             '作業者ID
        Dim strFlowClass                    As String             '流動区分
        Dim lngOrderListCnt                 As Integer            'Atlasｵｰﾀﾞｰﾘｽﾄｶｳﾝﾄ
        Dim typOrderList                    As List(Of OrderList) 'Atlasｵｰﾀﾞｰﾘｽﾄ
    End Structure

    '@量産計画承認構造体(atls.auth____)要求
    Public Structure AtlasAuthReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strEmpID                        As String           '作業者ID
        Dim strOrderNum                     As String           'Atlasｵｰﾀﾞｰ№
        Dim strPdId                         As String           '機種ｺｰﾄﾞ
        Dim strPlanThrowinDate              As String           '投入予定日
        Dim strPlanQuantity                 As String           '計画数量
        Dim strFlowClass                    As String           '流動区分
    End Structure

    '@ｵｰﾀﾞｰﾘｽﾄ構造体(atls.orderlist)応答
    Public Structure OrderNoList
        Dim strPlanThrowinDate              As String           '投入予定日
        Dim strPdId                         As String           '機種ｺｰﾄﾞ
        Dim strLR                           As String           'L/R
        Dim strQuantity                     As String           '数量
        Dim strOrderNum                     As String           'Atlasｵｰﾀﾞｰ№
        Dim strParentPdId                   As String           '親機種ID
        Dim strLcDirection                  As String           'L/R表示
        Dim strSendSBID                     As String           '送品先ID
        Dim strSendSBName                   As String           '送品先名(和名)
        Dim strSbArea                       As String           'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
    End Structure

    '@ｵｰﾀﾞｰﾘｽﾄ構造体(atls.orderlist)応答
    Public Structure AtlsOrderList
        Dim lngAltsOrderListCnt             As Integer              'ﾘｽﾄｶｳﾝﾄ
        Dim typOrderList                    As List(Of OrderNoList) 'ｵｰﾀﾞｰ№ﾘｽﾄ構造体
    End Structure

    '@時間制限取得構造体(lot_.getrestrict)応答
    Public Structure LotGetRestrict
        Dim strRestrictTypeID               As String           '時間制限ﾌﾗｸﾞ
        Dim strLimitTime                    As String           '制限時間
        Dim strWarnTime                     As String           '警告時間
        Dim strFromOpId                     As String           '開始大工程ID
        Dim strFromStepId                   As String           '開始小工程ID
        Dim strToOpId                       As String           '終了大工程ID
        Dim strToStepId                     As String           '終了小工程ID
    End Structure

    '@CFｷｬﾘｱﾘｽﾄ要求格納構造体(carr.cflist__、carr.cfcurstate)共通
    Public Structure CFListRec
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strTFTLotID                     As String           'TFTﾛｯﾄID
        Dim strWfNum                        As String           'WF枚数
        Dim strCFCarrierID                  As String           'CFｷｬﾘｱID
    End Structure

    '@CFﾘｽﾄ格納構造体
    Public Structure CFList
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strFlowClass                    As String           '種別
        Dim strPdId                         As String           '機種
        Dim strWfNum                        As String           '数量(WF)
        Dim strChipNum                      As String           '数量(CHIP)
        Dim strPriority                     As String           '優先度
    End Structure

    '@CFﾘｽﾄ取得構造体(carr.cflist__)応答
    Public Structure CFListAns
        Dim llngCFListCnt                   As Integer          'CFﾘｽﾄｶｳﾝﾄ
        Dim typCFList                       As List(Of CFList)  'CFﾘｽﾄ格納構造体
    End Structure


    '@TFT/CFﾛｯﾄ紐付き情報取得要求格納構造体(lot_.jbatchconnectedinfo)
    Public Structure JBatchConnectedInfoRec
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strJBatchId                     As String           '蒸着ﾊﾞｯﾁID
        Dim strCfFlag                       As String           'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
    End Structure

    '@ﾛｯﾄﾘｽﾄ格納構造体
    Public Structure JBatchLotList
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strFlowClass                    As String           '種別
        Dim strPdId                         As String           '機種
        Dim strWfNum                        As String           '数量(WF)
        Dim strChipNum                      As String           '数量(CHIP)
        Dim strPriority                     As String           '優先度
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strCurrentStatusName            As String           'ﾛｯﾄ現在状態
    End Structure

    '@TFT/CFﾛｯﾄ紐付き情報取得応答格納構造体(lot_.jbatchconnectedinfo)
    Public Structure JBatchConnectedInfoAns
        Dim llngJBatchLotListCnt            As Integer                'ﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typJBatchLotList                As List(Of JBatchLotList) 'ﾛｯﾄﾘｽﾄ格納構造体
    End Structure

    'TPALﾛｯﾄﾘｽﾄ(lot_.jbatchconnectedinfo2用)
    Public Structure TpalList
        Dim strTpalLotId                    As String           'ﾛｯﾄID
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ数
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strLotEventId                   As String           'ﾛｯﾄｲﾍﾞﾝﾄID
        Dim strCurrentStatusName            As String           'ﾛｯﾄ現在状態
    End Structure

    '@TFT/CFﾛｯﾄﾘｽﾄ(lot_.jbatchconnectedinfo2用)
    Public Structure TftCfLotList
        Dim strLotID                        As String            'ﾛｯﾄID
        Dim strCarrierId                    As String            'ｷｬﾘｱID
        Dim strFlowClass                    As String            '流動区分
        Dim strPdId                         As String            '機種
        Dim lngWfListCnt                    As Integer           'ｳｪﾊｰﾘｽﾄｶｳﾝﾄ
        Dim strWfList                       As List(Of String)   'ｳｪﾊｰﾘｽﾄ
        Dim strCfFlag                       As String            'CFﾌﾗｸﾞ
        Dim strLpFlag                       As String            'LPﾌﾗｸﾞ
        Dim lngTpalLotListCnt               As Integer           'TPALﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typeTpalLotList                 As List(Of TpalList) 'TPALﾛｯﾄﾘｽﾄ
        Dim strChipQuantity                 As String            '数量(CHIP)
        Dim strOpID                         As String            '大工程ID
        Dim strStepID                       As String            '小工程ID
        Dim strCurrentStatusName            As String            'ﾛｯﾄ現在状態
        Dim strTpalClass                    As String            'TPAL制限
    End Structure

    '@ﾊﾞｯﾁIDﾘｽﾄ(lot_.jbatchconnectedinfo2用)
    Public Structure JHBatchList
        Dim strEqType                       As String                'EQﾀｲﾌﾟ
        Dim strWpName                       As String                '装置名
        Dim strJHBatchID                    As String                'ﾊﾞｯﾁID(蒸着ﾊﾞｯﾁID、表面処理ﾊﾞｯﾁID)
        Dim llngLotListCnt                  As Integer               'TFT/CFﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typLotList                      As List(Of TftCfLotList) 'TFT/CFﾛｯﾄﾘｽﾄ
    End Structure

    '@TFT/CFﾛｯﾄ紐付き情報取得2要求格納構造体(lot_.jbatchconnectedinfo2)
    Public Structure JBatchConnectedInfoAns2
        Dim strMsgVer                       As String               'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim lngJHBatchListCnt               As Integer              'ﾊﾞｯﾁIDﾘｽﾄｶｳﾝﾄ
        Dim typeJHBatchList                 As List(Of JHBatchList) 'ﾊﾞｯﾁIDﾘｽﾄ
    End Structure

    '@ODF画面引継ぎ構造体(frmxxCM00T0/frmxxCM00U0)
    Public Structure OdfInfo
        Dim strLoaderCarrier                As String           'TFTｷｬﾘｱID(Loader)
        Dim strUnloaderCarrier              As String           'TFTｷｬﾘｱID(Unloader)
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strFlowClass                    As String           '種別
        Dim strPdId                         As String           '機種
        Dim strStatus                       As String           '状態
        Dim strWfNum                        As String           '数量(WF)
        Dim strChipNum                      As String           '数量(CHIP)
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strWpID                         As String           'WPID
        Dim strCFCarrierID                  As String           'CFｷｬﾘｱID
        Dim strOdfCoverFixFlag              As String           'ODF貼り合せ済みﾌﾗｸﾞ(0:未、1:済)
    End Structure

    '@ODF_LIST格納
    Public Structure OdfList
        Dim strSlotPosition                 As String           'ｽﾛｯﾄ番号
        Dim strTftWfID                      As String           'WF_ID(TFT)
        Dim strCfWfID                       As String           'WF_ID(CF)
        Dim strOdfCoverFixFlag              As String           'ODF貼り合せ済みﾌﾗｸﾞ(0:未、1:済)
    End Structure

    '@TFT_WF_LIST格納
    Public Structure TftWfList
        Dim strWfId                         As String           'WF_ID
    End Structure

    '@ODFｳｪﾊ結果取得(wf__.odflist_)要求
    Public Structure WfOdfListRec
        Dim strMsgVer                       As String             'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String             'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strCarrierId                    As String             'ｷｬﾘｱID
        Dim strWpID                         As String             'WPID
        Dim lngTftWfListCnt                 As Integer            'TFTWFﾘｽﾄｶｳﾝﾄ
        Dim typTftWfList                    As List(Of TftWfList) 'TFTWFﾘｽﾄ
        Dim strFromType                     As String             'ﾃﾞｰﾀ取得先(0:DB,1:WP)
    End Structure

    '@ODFｳｪﾊ結果取得(wf__.odflist_)応答
    Public Structure WfOdfListAns
        Dim strSlotSize                     As String           'ｽﾛｯﾄｻｲｽﾞ
        Dim lngOdfListCnt                   As Integer          'ODFﾘｽﾄｶｳﾝﾄ
        Dim typOdfList                      As List(Of OdfList) 'ODFﾘｽﾄ
    End Structure

    '@ODFｳｪﾊ登録(wf__.chgodf__)要求
    Public Structure WfChgOdfRec
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim lngOdfListCnt                   As Integer          'ODFﾘｽﾄｶｳﾝﾄ
        Dim typOdfList                      As List(Of OdfList) 'ODFﾘｽﾄ
    End Structure

    '@装置内ﾚﾁｸﾙﾘｽﾄ
    Public Structure RtclStatereplist
        Dim strReticleID                    As String           'ﾚﾁｸﾙID
        Dim strReticleStatusItemID          As String           'ﾚﾁｸﾙ状態ID
        Dim strCurrentPositionID            As String           '現在位置ID
        Dim strSmifID                       As String           'SMIFID
        Dim strEditTime                     As String           '最終更新日時
    End Structure

    '@ﾚﾁｸﾙ状態報告(rtcl.staterep)要求MSG
    Public Structure RtclStaterep_Rec
        Dim strSbID                         As String                    'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String                    'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strClassDivision                As String                    '処理区分(01:ｸﾗｲｱﾝﾄ、FF:搬送(ﾊﾞｰｺｰﾄﾞ)指定、ZZ:装置(全自動)指定)
        Dim strOnlineFlag                   As String                    'ｵﾝﾗｲﾝﾌﾗｸﾞ(0:装置稼動中/ｸﾗｲｱﾝﾄ、1:装置ｵﾝﾗｲﾝ)
        Dim strWpID                         As String                    '処理区分ZZのみ指定
        Dim lngRtclStatereplist             As Integer                   '装置内ﾚﾁｸﾙﾘｽﾄｶｳﾝﾄ
        Dim typRtclStatereplist             As List(Of RtclStatereplist) '装置内ﾚﾁｸﾙﾘｽﾄ
        Dim strEmpID                        As String                    '作業者ID
    End Structure

    '@ﾛｯﾄ存在確認(excp.checklot)要求
    Public Structure ExcpCheckLotReq
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strLotID                        As String           'ﾛｯﾄID
    End Structure

    '@ﾛｯﾄ存在確認(excp.checklot)応答
    Public Structure ExcpCheckLotAns
        Dim strPdId                         As String           '機種ID
        Dim strWfNum                        As String           '数量(WF)
        Dim strChipNum                      As String           '数量(CHIP)
        Dim strCFLotFlag                    As String           'CFﾛｯﾄﾌﾗｸﾞ(0:CFﾛｯﾄ以外 1:CFﾛｯﾄ)
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strWpID                         As String           '装置ID
        Dim strWpName                       As String           '装置名
    End Structure

    '@工程異常/不適合品処理票・登録更新/取得構造体(構成ﾛｯﾄ)
    Public Structure ExcpLot
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strReserveQuantity              As String           '保留枚数
        Dim strAbandonQuantity              As String           '廃却枚数
        Dim strAmendQuantity                As String           '手直ｼ流動枚数
        Dim strCorrectQuantity              As String           '修正流動枚数
        Dim strUsualQuantity                As String           '通常流動枚数
        Dim strEvalQuantity                 As String           '評価流動枚数
        Dim strTakeQuantity                 As String           '特殊流動枚数
        Dim strTargetQuantity               As String           '対象枚数
        Dim strTotalQuantity                As String           '総枚数
        Dim strDisposalFlag                 As String           '処置ﾌﾗｸﾞ
        Dim strAppendFlag                   As String           'ﾛｯﾄ追加ﾌﾗｸﾞ
        Dim strHoldFlag                     As String           'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strEditTime                     As String           '最終更新日時
    End Structure

    '@工程異常/不適合品処理票・登録更新/取得構造体
    Public Structure ExcpReport
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String           'Msgﾊﾞｰｼﾞｮﾝ
        Dim strHoldFlag                     As String           '保留ﾌﾗｸﾞ
        Dim strExcpNo                       As String           '異常処理NO
        Dim strFindDate                     As String           '発見日時
        Dim strEntryTime                    As String           '登録日時
        Dim strFindDeptID                   As String           '発見者所属ID
        Dim strFindDeptName                 As String           '発見者所属名
        Dim strFindEmpID                    As String           '発見者氏名ID
        Dim strFindEmpName                  As String           '発見者氏名
        Dim strFindTelNo                    As String           '発見者電話番号
        Dim strDocClass                     As String           '帳票種別
        Dim strExcpItemName                 As String           '工程異常名
        Dim strExcpItemNo                   As String           '工程異常項目
        Dim strExcpItemOthr                 As String           '異常項目その他内容
        Dim strTargetPDID                   As String           '対象機種名
        Dim strTargetQuantity               As String           '対象合計数
        Dim strTargetUnit                   As String           '単位
        Dim strFindOpID                     As String           '発見大工程名
        Dim strFindStepID                   As String           '発見小工程名
        Dim strFindWpID                     As String           '発見時WPID
        Dim strFindWpName                   As String           '発見時WP名
        Dim strExcpSituation                As String           '工程異常発生状況
        Dim strIncongFlag                   As String           '不適合品発生有無
        Dim strExcpDetailComments           As String           '異常内容詳細ｺﾒﾝﾄ
        Dim strInflFlag                     As String           '後工程/信頼性影響
        Dim strTechInflContents             As String           '技術部門処置内容
        Dim strTechInflEmpID                As String           '技術部門処置氏名ID
        Dim strTechInflEmpName              As String           '技術部門処置氏名
        Dim strTechInflDate                 As String           '技術部門処置日時
        Dim strManuInflContents             As String           '製造部門処置内容
        Dim strManuInflEmpID                As String           '製造部門処置氏名ID
        Dim strManuInflEmpName              As String           '製造部門処置氏名
        Dim strManuInflDate                 As String           '製造部門処置日時
        Dim strOthrInflContents             As String           'その他部門処置内容
        Dim strOthrInflEmpID                As String           'その他部門処置氏名ID
        Dim strOthrInflEmpName              As String           'その他部門処置氏名
        Dim strOthrInflDate                 As String           'その他部門処置日時
        Dim strTechInvestContents           As String           '技術部門調査原因
        Dim strTechInvestEmpID              As String           '技術部門調査氏名ID
        Dim strTechInvestEmpName            As String           '技術部門調査氏名
        Dim strTechInvestDate               As String           '技術部門調査日時
        Dim strManuInvestContents           As String           '製造部門調査原因
        Dim strManuInvestEmpID              As String           '製造部門調査氏名ID
        Dim strManuInvestEmpName            As String           '製造部門調査氏名
        Dim strManuInvestDate               As String           '製造部門調査日時
        Dim strOthrInvestContents           As String           'その他部門調査原因
        Dim strOthrInvestEmpID              As String           'その他部門調査氏名ID
        Dim strOthrInvestEmpName            As String           'その他部門調査氏名
        Dim strOthrInvestDate               As String           'その他部門調査日時
        Dim strTechIndicateContents         As String           '技術部門指示内容
        Dim strTechIndicateEmpID            As String           '技術部門指示氏名ID
        Dim strTechIndicateEmpName          As String           '技術部門指示氏名
        Dim strTechIndicateDate             As String           '技術部門指示日時
        Dim strManuIndicateContents         As String           '製造部門指示内容
        Dim strManuIndicateEmpID            As String           '製造部門指示氏名ID
        Dim strManuIndicateEmpName          As String           '製造部門指示氏名
        Dim strManuIndicateDate             As String           '製造部門指示日時
        Dim strOthrIndicateContents         As String           'その他部門指示内容
        Dim strOthrIndicateEmpID            As String           'その他部門指示氏名ID
        Dim strOthrIndicateEmpName          As String           'その他部門指示氏名
        Dim strOthrIndicateDate             As String           'その他部門指示日時
        Dim strApprovalFlag                 As String           '承認ﾌﾗｸﾞ
        Dim strApprovalEmpID                As String           '承認作業者ID
        Dim strApprovalEmpName              As String           '承認作業者名
        Dim strAllDisposalFlag              As String           '全処置ﾌﾗｸﾞ
        Dim strEditTime                     As String           '最終更新日時
        Dim strEmpID                        As String           '作業者ID
        Dim strEmpName                      As String           '作業者名
        Dim strIncongItemName               As String           '不良特性名
        Dim strTechCheckContents            As String           '技術部門確認内容
        Dim strTechCheckEmpID               As String           '技術部門確認氏名ID
        Dim strTechCheckEmpName             As String           '技術部門確認氏名
        Dim strTechCheckDate                As String           '技術部門確認日時
        Dim strManuCheckContents            As String           '製造部門確認内容
        Dim strManuCheckEmpID               As String           '製造部門確認氏名ID
        Dim strManuCheckEmpName             As String           '製造部門確認氏名
        Dim strManuCheckDate                As String           '製造部門確認日時
        Dim strOthrCheckContents            As String           'その他部門確認内容
        Dim strOthrCheckEmpID               As String           'その他部門確認氏名ID
        Dim strOthrCheckEmpName             As String           'その他部門確認氏名
        Dim strOthrCheckDate                As String           'その他部門確認日時
        Dim strIncongJudgeVolume            As String           '不適合品発生量ﾌﾗｸﾞ
        Dim strIncongJudgeEmpID             As String           '不適合品発生判定者ID
        Dim strIncongJudgeEmpName           As String           '不適合品判定確認氏名
        Dim strIncongJudgeDate              As String           '不適合品判定確認日
        Dim strDispoScrapFlag               As String           '現品廃却フラグ
        Dim strDispoMdifyFlag               As String           '現品手直し流動フラグ
        Dim strDispoPickFlag                As String           '現品：特採流動フラグ
        Dim strDispoRegularFlag             As String           '現品通常流動フラグ
        Dim strDispoAmendFlag               As String           '現品修正流動フラグ
        Dim strDispoRatingFlag              As String           '現品評価流動フラグ
        Dim strDispoContents                As String           '現品処理指示内容
        Dim strDispoIndicateEmpID           As String           '現品処理指示氏名ID
        Dim strDispoIndicateEmpName         As String           '現品処理指示氏名
        Dim strDispoIndicateDate            As String           '現品処理指示日
        Dim strImproKind                    As String           '改善取組
        Dim strImproContents                As String           '改善取組内容
        Dim strImproEmpID                   As String           '改善取組者ID
        Dim strImproEmpName                 As String           '改善取組者名
        Dim strImproDate                    As String           '改善取組日時
        Dim strCauseWpID                    As String           '原因装置ID
        Dim strCauseWpName                  As String           '原因装置名
        Dim strCauseSeriesName              As String           '原因系列名
        Dim strCauseClassName               As String           '原因区分名
        Dim lngExcpReportLotListCnt         As Integer          '構成ﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typExcpLotList                  As List(Of ExcpLot) '構成ﾛｯﾄﾘｽﾄ
    End Structure

    '@工程異常/不適合品処理票一覧取得(excp.reportlist)要求
    Public Structure ReportListReq
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strClassDivision                As String           '処理区分
        Dim strStartDate                    As String           '検索開始日時
        Dim strEndDate                      As String           '検索終了日時
        Dim strFindEmpID                    As String           '発見者ID
        Dim strToEmpID                      As String           '担当者ID
    End Structure

    '@担当者ﾘｽﾄ
    Public Structure ExcpEmpList
        Dim strEmpID                        As String           '担当者ID
        Dim strEmpName                      As String           '担当者名
    End Structure

    '@担当者ﾘｽﾄ
    Public Structure RepairEmpList
        Dim strEmpID                        As String           '担当者ID
        Dim strEmpName                      As String           '担当者名
    End Structure

    '@工程異常/不適合品処理票一覧取得(excp.reportlist)応答
    Public Structure ReportListAns
        Dim strDocClass                     As String               '帳票種別
        Dim strFindDate                     As String               '発見日時
        Dim strFindEmpID                    As String               '発見者氏名ID
        Dim strFindEmpName                  As String               '発見者氏名
        Dim strExcpNo                       As String               '異常処理NO
        Dim strExcpItemName                 As String               '工程異常名
        Dim strApprovalFlag                 As String               '承認ﾌﾗｸﾞ
        Dim strAllDisposalFlag              As String               '全処置ﾌﾗｸﾞ
        Dim lngLotListCnt                   As Integer              'ﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typExcpLotList                  As List(Of ExcpLotList) 'ﾛｯﾄﾘｽﾄ
        Dim strFindWpID                     As String               '発見装置ID
        Dim strFindWpName                   As String               '発見装置名
        Dim lnEmpListCnt                    As Integer              '担当者ﾘｽﾄｶｳﾝﾄ
        Dim typExcpEmpList                  As List(Of ExcpEmpList) '担当者ﾘｽﾄ
        Dim strFromEmpID                    As String               '依頼元担当者ID
        Dim strFromEmpName                  As String               '依頼元担当者名
        Dim strFromEntryTime                As String               '依頼日
        Dim strEditTime                     As String               '更新日時
        Dim strFindOpID                     As String               '大工程
        Dim strFindStepID                   As String               '小工程
        Dim strDispoName                    As String               '処置名
        Dim strDispoWfNum                   As String               '処置WF数
        Dim strExcpSitu                     As String               '工程異常発生状況
    End Structure

    '@工程異常/不適合品処理票一覧取得(excp.reportlist)応答
    Public Structure ExcpReportList
        Dim lngReportListCnt                As Integer                '応答件数
        Dim typReportList                   As List(Of ReportListAns) '応答構造体
    End Structure

    '@工程異常/不適合品処理票編集画面起動引継構造体
    Public Structure ExcpEdit
        Dim strExcpNo                       As String               '異常処理NO
        Dim strSbID                         As String               '起案ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strCFLotFlag                    As String               'CFﾛｯﾄﾌﾗｸﾞ(0:CFﾛｯﾄ以外 1:CFﾛｯﾄ 2:不明(全て))
        Dim strFromEmpID                    As String               '依頼元担当者ID
        Dim strFromEmpName                  As String               '依頼元担当者名
        Dim lnEmpListCnt                    As Integer              '担当者ﾘｽﾄｶｳﾝﾄ
        Dim typExcpEmpList                  As List(Of ExcpEmpList) '依頼先担当者ﾘｽﾄ
        Dim strFromEntryTime                As String               '依頼日
    End Structure
    Public ptypExcpEditList                 As ExcpEdit

    '@工程異常/不適合品処理票編集画面起動引継構造体
    Public Structure RepairEdit
        Dim strRepairNo                     As String                 '異常処理NO
        Dim strSbID                         As String                 '起案ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strFromEmpID                    As String                 '依頼元担当者ID
        Dim strFromEmpName                  As String                 '依頼元担当者名
        Dim lngEmpListCnt                   As Integer                '担当者ﾘｽﾄｶｳﾝﾄ
        Dim typRepairEmpList                As List(Of RepairEmpList) '依頼先担当者ﾘｽﾄ
        Dim strFromEntryTime                As String                 '依頼日
    End Structure
    Public ptypRepairEditList               As RepairEdit


    '@ﾘﾜｰｸ理由(小分類)取得ﾒｯｾｰｼﾞ用構造体(mas_.reworksubreason)応答
    Public Structure ReasonSubCodeList
        Dim strReasonSubCode                As String           '理由ｺｰﾄﾞ(小分類)
        Dim strReasonSubName                As String           '理由名(小分類)
    End Structure

    '@ﾘﾜｰｸ理由(小分類)取得ﾒｯｾｰｼﾞ用構造体(mas_.reworksubreason)応答
    Public Structure ReasonSubCode
        Dim lngReasonSubCodeListCnt         As Integer                    '理由ｺｰﾄﾞ(小分類)ﾘｽﾄｶｳﾝﾄ
        Dim typReasonSubCodeList            As List(Of ReasonSubCodeList) '理由ｺｰﾄﾞ(小分類)ﾘｽﾄ
    End Structure

    '@ﾘﾜｰｸ理由取得ﾒｯｾｰｼﾞ用構造体(mas_.reworkreason)応答
    Public Structure ReasonCodeList
        Dim strReasonCode                   As String           '理由ｺｰﾄﾞ
        Dim strReasonName                   As String           '理由名
        Dim strHoldFlag                     As String           '保留ﾌﾗｸﾞ
        Dim strExcpFlag                     As String           '工程異常処理票ﾌﾗｸﾞ
    End Structure

    '@ﾘﾜｰｸ理由取得ﾒｯｾｰｼﾞ用構造体(mas_.reworkreason)応答
    Public Structure ReasonCode
        Dim lngReasonCodeListCnt            As Integer                 '理由ｺｰﾄﾞﾘｽﾄｶｳﾝﾄ
        Dim typReasonCodeList               As List(Of ReasonCodeList) '理由ｺｰﾄﾞﾘｽﾄ
    End Structure

    '@ﾘﾜｰｸ原因引継構造体
    Public Structure ReworkInfoList
        Dim strExcpNo                       As String           '異常処理№
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim blnSelectFlag                   As Boolean          '全選択ﾌﾗｸﾞ
    End Structure
    Public ptypReworkInfoList               As ReworkInfoList

    '@強制ｷｬﾘｱ交換(carr_forcedmove)
    Public Structure CarrierForcedmove
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strCarrierId                    As String           '交換元ｷｬﾘｱID
        Dim strEmpID                        As String           '作業者ID
        Dim strToCarrierId                  As String           '交換先ｷｬﾘｱID
    End Structure

    '@依頼先ﾘｽﾄ
    Public Structure ExcpToEmpList
        Dim strToEmpID                      As String           '依頼先ID
        Dim strToEmpName                    As String           '依頼先名
    End Structure

    '@ﾜｰｸﾌﾛｰ登録情報格納構造体(excp.registworkflow)要求
    Public Structure WorkFlow
        Dim strSbID                         As String                 'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String                 'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strReportNo                     As String                 '処理票№
        Dim strFromEmpID                    As String                 '依頼元ID
        Dim strFromEmpName                  As String                 '依頼元名称
        Dim strWpID                         As String                 '装置ID
        Dim lngEmpListCnt                   As Integer                '依頼先ﾘｽﾄ件数
        Dim typEmpList                      As List(Of ExcpToEmpList) '依頼先ﾘｽﾄ
    End Structure
    Public ptypWorkFlow                     As WorkFlow

    '@ﾚｼﾋﾟﾎﾞﾃﾞｨ__ﾚｼﾋﾟ情報取得(lot_.userecp_)
    Public Structure UseRecipeBodyList
        Dim strRecipeItem                   As String           'ﾚｼﾋﾟｱｲﾃﾑ
        Dim strValueType                    As String           'ﾚｼﾋﾟﾃﾞｰﾀﾀｲﾌﾟ
        Dim strRecipeValue                  As String           'ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ値
    End Structure

    '@ﾚｼﾋﾟﾘｽﾄ_ﾚｼﾋﾟ情報取得(lot_.userecp_)
    Public Structure UseRecipeList
        Dim strRecipeId                     As String                     'ﾚｼﾋﾟID
        Dim strDefaultFlag                  As String                     'ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
        Dim strRecipeComments               As String                     'ﾚｼﾋﾟｺﾒﾝﾄ
        Dim lngUseRecipeBodyListCnt         As Integer                    'ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ件数
        Dim typUseRecipeBodyList            As List(Of UseRecipeBodyList) 'ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ
    End Structure

    '@WPﾘｽﾄ_ﾚｼﾋﾟ情報取得(lot_.userecp_)
    Public Structure UseWpList
        Dim strWpID                         As String                 'WPID
        Dim strWpName                       As String                 '装置名
        Dim strWfId                         As String                 'WFID
        Dim strHistoryFlag                  As String                 '実績ﾌﾗｸﾞ
        Dim lngtypUseRecipeListCnt          As Integer                'ﾚｼﾋﾟﾘｽﾄ件数
        Dim typUseRecipeList                As List(Of UseRecipeList) 'ﾚｼﾋﾟﾘｽﾄ
    End Structure

    '@ﾚｼﾋﾟ情報取得(lot_.userecp_) 応答
    Public Structure UseRecpAns
        Dim strSelectConditionID            As String             'WF選択条件
        Dim lngUseWpListCnt                 As Integer            'WPﾘｽﾄ件数
        Dim typUseWpList                    As List(Of UseWpList) 'WPﾘｽﾄ
    End Structure

    '@ﾚｼﾋﾟ情報取得(lot_.userecp_) 要求
    Public Structure UseRecpRec
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'SBID
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strLotID                        As String           'ﾛｯﾄID
    End Structure

    '@装置ﾚｼﾋﾟﾘｽﾄ (画面間引渡し用)
    Public Structure UseRecpList
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim typUseRecpAns                   As UseRecpAns       'ﾚｼﾋﾟﾘｽﾄ
    End Structure

    '@職制社員ﾘｽﾄ取得(mas_.roleemplist) 要求
    Public Structure MasRoleEmpListReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'SBID
        Dim strRole                         As String           '職制
    End Structure

    '@職制社員ﾘｽﾄ取得(mas_.roleemplist) 応答
    Public Structure MasRoleEmpListAns
        Dim typRoleEmpList                  As List(Of DeptEmpList) '職制社員ﾘｽﾄ(社員名取得ﾘｽﾄ流用)
        Dim lngRoleEmpListCnt               As Integer              '職制社員ﾘｽﾄｶｳﾝﾄ
    End Structure

    '@装置状態ﾒｯｾｰｼﾞ取得(eq_.wpmsglist) 要求
    Public Structure EqWpMsgListReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strWpID                         As String           'WPID
    End Structure

    '@装置状態ﾒｯｾｰｼﾞ取得(eq_.wpmsglist) 応答用
    Public Structure MsgList
        Dim strMessageID                    As String           'ﾒｯｾｰｼﾞID
        Dim strMessage                      As String           'ﾒｯｾｰｼﾞ
    End Structure

    '@装置状態ﾒｯｾｰｼﾞ取得(eq_.wpmsglist) 応答
    Public Structure EqWpMsgListAns
        Dim llngMsgListCnt                  As Integer
        Dim typMsgList                      As List(Of MsgList) 'ﾒｯｾｰｼﾞﾘｽﾄ
    End Structure

    '@搬送ポート 有効・無効変更要求(eq_.chgtrnstat) 要求
    Public Structure trnportList
        Dim strPortID                       As String           'ﾎﾟｰﾄID
        Dim strTransServiceStatus           As String           '自動搬送ｻｰﾋﾞｽ状態
    End Structure

    '@搬送ポート 有効・無効変更要求(eq_.chgtrnstat) 要求
    Public Structure ChgtrnstatReq
        Dim strMsgVer                       As String               'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strWpID                         As String               'WPID
        Dim strComments                     As String               'ｺﾒﾝﾄ
        Dim strEmpID                        As String               '作業者ID
        Dim llngtrnportListCnt              As Integer              'ﾎﾟｰﾄﾘｽﾄｶｳﾝﾄ
        Dim typtrnportList                  As List(Of trnportList) 'ﾎﾟｰﾄﾘｽﾄ
    End Structure

    '@装置処理順変更要求(eq_.chgprocorder) 要求
    Public Structure EqChgProcOrderReq
        Dim strMsgVer                       As String                   'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strWpID                         As String                   'WPID
        Dim strRecipeFlowNum                As String                   '条件毎連続処理数
        Dim strComments                     As String                   'ｺﾒﾝﾄ
        Dim strEmpID                        As String                   '作業者ID
        Dim typCollectTypeList              As List(Of CollectTypeList) 'ﾚｼﾋﾟｸﾞﾙｰﾌﾟﾘｽﾄ
        Dim lngCollectTypeListCnt           As Integer                  'ﾚｼﾋﾟｸﾞﾙｰﾌﾟﾘｽﾄｶｳﾝﾄ
        Dim strCollectTypeFlg               As String                   '収集ﾀｲﾌﾟﾌﾗｸﾞ(0:FIFO、1:ﾚｼﾋﾟ切替、2:ﾚｼﾋﾟ固定、3:FIFO同時禁止、4:ﾚｼﾋﾟ切替同時禁止、5:ﾚｼﾋﾟ固定同時禁止)
    End Structure

    '@ｷｬﾘｱｱﾝﾛｰﾄﾞ要求(eq__.carunload) 要求
    Public Structure EqCarUnloadReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strWpID                         As String           'WPID
        Dim strPortID                       As String           'ﾎﾟｰﾄID
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strEmpID                        As String           '作業者ID
    End Structure

    '@P/Rｵｰﾀﾞｰﾘｽﾄ取得(pr__.orderlist)　応答
    Public Structure PrOrderList
        Dim strPROrderID                    As String           'P/RｵｰﾀﾞｰID
        Dim strOrderComments                As String           'ｵｰﾀﾞｰｺﾒﾝﾄ
        Dim strGlobalDept                   As String           '部門(ｺｰﾄﾞ又は名称、他事業所も含む)
        Dim strCostCode                     As String           '原価ｺｰﾄﾞ
        Dim strEntryTime                    As String           '登録日時
        Dim strEditTime                     As String           '更新日時
        Dim strEmpID                        As String           '作業者ID
        Dim strEmpName                      As String           '作業者名
    End Structure

    '@P/Rｵｰﾀﾞｰﾘｽﾄ取得(pr__.orderlist)　応答
    Public Structure PrOrderListAns
        Dim lngPrOrderListCnt               As Integer              'ﾘｽﾄｶｳﾝﾄ
        Dim typPrOrderList                  As List(Of PrOrderList) 'P/Rｵｰﾀﾞｰﾘｽﾄ構造体
    End Structure

    '@P/Rｵｰﾀﾞｰ登録(pr__.chgorder)　要求
    Public Structure PrChgOrderReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strClassDivision                As String           '処理区分
        Dim strPROrderID                    As String           'P/RｵｰﾀﾞｰID
        Dim strOrderComments                As String           'ｵｰﾀﾞｰｺﾒﾝﾄ
        Dim strGlobalDept                   As String           '部門(ｺｰﾄﾞ又は名称、他事業所も含む)
        Dim strCostCode                     As String           '原価ｺｰﾄﾞ
        Dim strEditTime                     As String           '更新日時
        Dim strEmpID                        As String           '作業者ID
    End Structure

    '@P/Rｵｰﾀﾞｰ管理　⇔　P/Rｵｰﾀﾞｰ登録　連携情報
    Public Structure PrOrderRenkeiInfo
        Dim lngInsertMode                   As Integer          '登録ﾓｰﾄﾞ(1:新規、2:ｺﾋﾟｰ登録、3:修正)
        Dim strPROrderID                    As String           'P/RｵｰﾀﾞｰID
        Dim strEditTime                     As String           '最終更新日時
    End Structure
    Public ptypPrOrderRenkeiInfo            As PrOrderRenkeiInfo 'P/Rｵｰﾀﾞｰ管理連携格納用

    '@FTP収集状況確認　要求
    Public Structure FtpRegCollect
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strWfId                         As String           'WFID(TFTorCF)
        Dim strWpID                         As String           '装置ID
    End Structure

    '@ｷｬﾘｱ情報更新　要求
    Public Structure CarrierUpdateInfo
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strCategoryID                   As String           'ｶﾃｺﾞﾘID
        Dim strComments                     As String           'ｺﾒﾝﾄ
    End Structure

    '@ｷｬﾘｱ情報更新　要求
    Public Structure CarrierUpdateList
        Dim typCarrierUpdateInfo            As List(Of CarrierUpdateInfo) 'ｷｬﾘｱ情報構造体
    End Structure

    '@ｷｬﾘｱｶﾃｺﾞﾘﾘｽﾄ取得　応答
    Public Structure CarrierCategory
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strCategoryID                   As String           'ｶﾃｺﾞﾘID
        Dim strCategoryName                 As String           'ｶﾃｺﾞﾘ名
    End Structure

    '@ｷｬﾘｱｶﾃｺﾞﾘﾘｽﾄ取得　応答
    Public Structure CarrierCategoryList
        Dim typCarrierCategory              As List(Of CarrierCategory) 'ｷｬﾘｱｶﾃｺﾞﾘﾘｽﾄ構造体
        Dim lngCarrierCategoryCnt           As Integer                  'ｷｬﾘｱｶﾃｺﾞﾘﾘｽﾄｶｳﾝﾄ
    End Structure

    '@ﾌｫﾄF/B装置ﾊﾟﾗﾒｰﾀ取得(eq__.photofbeqprmlist 要求)
    Public Structure PhotoFbEqPrmListReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'SBID
        Dim strWpID                         As String           '装置ID
        Dim strDataKind                     As String           'ﾃﾞｰﾀ種別(1:F/Bﾊﾟﾗﾒｰﾀ、2:F/B初期値)
    End Structure

    '@ﾌｫﾄF/B装置ﾊﾟﾗﾒｰﾀ取得(eq__.photofbeqprmlist 応答用ﾘｽﾄ)
    Public Structure EqPrmList
        Dim strItemName                     As String           '装置ﾊﾟﾗﾒｰﾀ
        Dim strItemValue                    As String           '現在値
        Dim strItemUnit                     As String           '単位
        Dim strItemValidDigit               As String           '小数点以下有効桁数
        Dim strLowerLimit                   As String           '制限値下限
        Dim strUpperLimit                   As String           '制限値上限
        Dim strEmpName                      As String           '最終更新者
        Dim strEntryTime                    As String           '最終更新日時
    End Structure

    '@ﾌｫﾄF/B装置ﾊﾟﾗﾒｰﾀ取得(eq__.photofbeqprmlist 応答)
    Public Structure PhotoFbEqPrmListAns
        Dim lngEqPrmListCnt                 As Integer            'ﾊﾟﾗﾒｰﾀﾘｽﾄｶｳﾝﾄ
        Dim typEqPrmList                    As List(Of EqPrmList) 'ﾊﾟﾗﾒｰﾀﾘｽﾄ
    End Structure

    '@ﾌｫﾄF/B装置ﾊﾟﾗﾒｰﾀ変更(eq__.photofbeqprmchg 要求用ﾘｽﾄ)
    Public Structure FbItemList
        Dim strItemName                     As String           '装置ﾊﾟﾗﾒｰﾀ名
        Dim strItemValue                    As String           '装置ﾊﾟﾗﾒｰﾀ値
    End Structure

    '@ﾌｫﾄF/B装置ﾊﾟﾗﾒｰﾀ変更(eq__.photofbeqprmchg 要求)
    Public Structure PhotoFbEqPrmchgReq
        Dim strMsgVer                       As String              'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String              'SBID
        Dim strWpID                         As String              '装置ID
        Dim strEmpID                        As String              '作業者ID
        Dim strDataKind                     As String              'ﾃﾞｰﾀ種別(1:F/Bﾊﾟﾗﾒｰﾀ、2:F/B初期値)
        Dim lngFbItemListCnt                As Integer             'ﾌｫﾄF/Bｱｲﾃﾑﾘｽﾄｶｳﾝﾄ
        Dim typFbItemList                   As List(Of FbItemList) 'ﾌｫﾄF/Bｱｲﾃﾑﾘｽﾄ
    End Structure

    '@ﾌｫﾄF/Bﾃﾞｰﾀ変更(eq__.photofbdatachg 要求)
    Public Structure PhotoFbDataChgReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'SBID
        Dim strWpID                         As String           '装置ID
        Dim strRecipeId                     As String           'ﾚｼﾋﾟID
        Dim strReferencePhotoWpID           As String           '基準ﾌｫﾄ装置ID
        Dim strShiftX                       As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftY                       As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagX                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagY                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotX                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotY                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRot                      As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMag                      As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strEmpID                        As String           '作業者ID
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strEntryTime                    As String           '最新の更新日時(排他制御)
        Dim lngPatchDivideNum               As Integer
        Dim strShiftX_2                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftY_2                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagX_2                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagY_2                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotX_2                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotY_2                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRot_2                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMag_2                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftX_3                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftY_3                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagX_3                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagY_3                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotX_3                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotY_3                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRot_3                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMag_3                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftX_4                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftY_4                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagX_4                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagY_4                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotX_4                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotY_4                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRot_4                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMag_4                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftX_5                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftY_5                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagX_5                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagY_5                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotX_5                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotY_5                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRot_5                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMag_5                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftX_6                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftY_6                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagX_6                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagY_6                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotX_6                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotY_6                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRot_6                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMag_6                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftX_7                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftY_7                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagX_7                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagY_7                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotX_7                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotY_7                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRot_7                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMag_7                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftX_8                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftY_8                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagX_8                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagY_8                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotX_8                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotY_8                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRot_8                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMag_8                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftX_9                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftY_9                     As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagX_9                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagY_9                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotX_9                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotY_9                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRot_9                    As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMag_9                    As String           'FBﾊﾟﾗﾒｰﾀ
        'Shot分離対応
        Dim strShotRotX                     As String          
        Dim strShotRotX_2                   As String          
        Dim strShotRotX_3                   As String          
        Dim strShotRotX_4                   As String          
        Dim strShotRotX_5                   As String          
        Dim strShotRotX_6                   As String          
        Dim strShotRotX_7                   As String          
        Dim strShotRotX_8                   As String          
        Dim strShotRotX_9                   As String          
        Dim strShotRotY                     As String          
        Dim strShotRotY_2                   As String          
        Dim strShotRotY_3                   As String          
        Dim strShotRotY_4                   As String          
        Dim strShotRotY_5                   As String          
        Dim strShotRotY_6                   As String          
        Dim strShotRotY_7                   As String          
        Dim strShotRotY_8                   As String 
        Dim strShotRotY_9                   As String          
        Dim strShotMagX                     As String
        Dim strShotMagX_2                   As String
        Dim strShotMagX_3                   As String
        Dim strShotMagX_4                   As String
        Dim strShotMagX_5                   As String
        Dim strShotMagX_6                   As String
        Dim strShotMagX_7                   As String
        Dim strShotMagX_8                   As String
        Dim strShotMagX_9                   As String
        Dim strShotMagY                     As String          
        Dim strShotMagY_2                   As String          
        Dim strShotMagY_3                   As String          
        Dim strShotMagY_4                   As String          
        Dim strShotMagY_5                   As String          
        Dim strShotMagY_6                   As String          
        Dim strShotMagY_7                   As String          
        Dim strShotMagY_8                   As String          
        Dim strShotMagY_9                   As String          
    End Structure

    '@ﾌｫﾄF/Bﾃﾞｰﾀ取得(eq__.photofbdatachg 要求)
    Public Structure PhotoFbDataListReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'SBID
        Dim strWpID                         As String           '装置ID
        Dim strRecipeId                     As String           'ﾚｼﾋﾟID
        Dim strReferencePhotoWpID           As String           '基準ﾌｫﾄ装置ID
    End Structure

    '@ﾌｫﾄF/Bﾃﾞｰﾀ取得(eq__.photofbdatachg 応答用)
    Public Structure FbDataItemList
        Dim strShiftXValue                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftYValue                  As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagXValue               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagYValue               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotXValue               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotYValue               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRotValue                 As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMagValue                 As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strFbCalcLots                   As String           'FB計算対象ﾛｯﾄ
        Dim strEmpName                      As String           '最終更新者
        Dim strEntryTime                    As String           '最終更新日時
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strShiftXValue_2                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftYValue_2                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagXValue_2             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagYValue_2             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotXValue_2             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotYValue_2             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRotValue_2               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMagValue_2               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftXValue_3                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftYValue_3                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagXValue_3             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagYValue_3             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotXValue_3             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotYValue_3             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRotValue_3               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMagValue_3               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftXValue_4                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftYValue_4                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagXValue_4             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagYValue_4             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotXValue_4             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotYValue_4             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRotValue_4               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMagValue_4               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftXValue_5                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftYValue_5                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagXValue_5             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagYValue_5             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotXValue_5             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotYValue_5             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRotValue_5               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMagValue_5               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftXValue_6                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftYValue_6                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagXValue_6             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagYValue_6             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotXValue_6             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotYValue_6             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRotValue_6               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMagValue_6               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftXValue_7                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftYValue_7                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagXValue_7             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagYValue_7             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotXValue_7             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotYValue_7             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRotValue_7               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMagValue_7               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftXValue_8                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftYValue_8                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagXValue_8             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagYValue_8             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotXValue_8             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotYValue_8             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRotValue_8               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMagValue_8               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftXValue_9                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftYValue_9                As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagXValue_9             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagYValue_9             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotXValue_9             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotYValue_9             As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRotValue_9               As String           'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMagValue_9               As String           'FBﾊﾟﾗﾒｰﾀ
        'Shot分離対応
        Dim strShotRotXValue                As String           
        Dim strShotRotXValue_2              As String           
        Dim strShotRotXValue_3              As String           
        Dim strShotRotXValue_4              As String           
        Dim strShotRotXValue_5              As String           
        Dim strShotRotXValue_6              As String           
        Dim strShotRotXValue_7              As String           
        Dim strShotRotXValue_8              As String           
        Dim strShotRotXValue_9              As String           
        Dim strShotRotYValue                As String           
        Dim strShotRotYValue_2              As String           
        Dim strShotRotYValue_3              As String           
        Dim strShotRotYValue_4              As String           
        Dim strShotRotYValue_5              As String           
        Dim strShotRotYValue_6              As String           
        Dim strShotRotYValue_7              As String           
        Dim strShotRotYValue_8              As String           
        Dim strShotRotYValue_9              As String           
        Dim strShotMagXValue                As String  
        Dim strShotMagXValue_2              As String  
        Dim strShotMagXValue_3              As String  
        Dim strShotMagXValue_4              As String  
        Dim strShotMagXValue_5              As String  
        Dim strShotMagXValue_6              As String  
        Dim strShotMagXValue_7              As String  
        Dim strShotMagXValue_8              As String  
        Dim strShotMagXValue_9              As String  
        Dim strShotMagYValue                As String  
        Dim strShotMagYValue_2              As String  
        Dim strShotMagYValue_3              As String  
        Dim strShotMagYValue_4              As String  
        Dim strShotMagYValue_5              As String  
        Dim strShotMagYValue_6              As String  
        Dim strShotMagYValue_7              As String  
        Dim strShotMagYValue_8              As String  
        Dim strShotMagYValue_9              As String  
    End Structure

    '@ﾌｫﾄF/Bﾃﾞｰﾀ取得(eq__.photofbdatachg 応答)
    Public Structure PhotoFbDataListAns
        Dim lngFbDataItemListCnt            As Integer                 'FBｱｲﾃﾑﾘｽﾄｶｳﾝﾄ
        Dim strPatchDivideNumRecipe         As String                  'patch分割数RECIPEテーブルの値(NULL：フォト以外、またはﾊﾟﾗﾒｰﾀ未使用、0：分割なし、1~9分割あり)
        Dim lngPatchDivideNum               As Integer                 'patch分割数PHOTO_FB_DATAテーブルの値
        Dim typFbDataItemList               As List(Of FbDataItemList) 'FBｱｲﾃﾑﾘｽﾄ
        Dim strShiftXItemName               As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftXValidDigit             As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftXUnit                   As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftYItemName               As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftYValidDigit             As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strShiftYUnit                   As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagXItemName            As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagXValidDigit          As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagXUnit                As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagYItemName            As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagYValidDigit          As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferMagYUnit                As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotXItemName            As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotXValidDigit          As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotXUnit                As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotYItemName            As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotYValidDigit          As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strWaferRotYUnit                As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRotItemName              As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRotValidDigit            As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strShotRotUnit                  As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMagItemName              As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMagValidDigit            As String                  'FBﾊﾟﾗﾒｰﾀ
        Dim strShotMagUnit                  As String                  'FBﾊﾟﾗﾒｰﾀ
        'Shot分離対応
        Dim strShotRotXItemName             As String
        Dim strShotRotXValidDigit           As String                  
        Dim strShotRotXUnit                 As String                  
        Dim strShotRotYItemName             As String   
        Dim strShotRotYValidDigit           As String                  
        Dim strShotRotYUnit                 As String 
        Dim strShotMagXItemName             As String
        Dim strShotMagXValidDigit           As String                 
        Dim strShotMagXUnit                 As String                 
        Dim strShotMagYItemName             As String
        Dim strShotMagYValidDigit           As String                 
        Dim strShotMagYUnit                 As String
        
        Dim strShotSeparateFlag             As String                   'Shot分離FLAG
    End Structure

    '@部材管理IDﾘｽﾄ(mat_.materiallist 応答)
    Public Structure MaterialLotIDList
        Dim strMaterialLotID                As String           '部材管理ID
        Dim strVenderWarrantDaysJudge       As String           'ﾒｰｶｰ保証期間判定ﾌﾗｸﾞ(0:OK、1:NG)
        Dim strAcceptWarrantDaysJudge       As String           '受入制限時間判定ﾌﾗｸﾞ(0:OK、1:NG)
        Dim strUseValidPeriodJudge          As String           '使用可能時間判定ﾌﾗｸﾞ(0:OK、1:NG)
        Dim strWarningPeriodJudge           As String           'ﾜｰﾆﾝｸﾞ表示時間判定ﾌﾗｸﾞ(0:OK、1:NG)
        Dim strVenderWarrantWarningDaysJudge     As String      'ﾒｰｶｰ保証ﾜｰﾆﾝｸﾞ期間判定ﾌﾗｸﾞ(0:OK、1:NG)
        Dim strAcceptWarrantWarningDaysJudge     As String      '受入制限ﾜｰﾆﾝｸﾞ時間判定ﾌﾗｸﾞ(0:OK、1:NG)
    End Structure

    '@部材ﾘｽﾄ取得(mas_.material 応答)
    Public Structure MaterialIDList
        Dim strMatchFlag                    As String                     '機種限定ﾏｯﾁﾌﾗｸﾞ(0:機種限定一致、1:機種限定相違)
        Dim strMaterialID                   As String                     '部材ID
        Dim lngPdListCnt                    As Integer                    '機種ﾘｽﾄｶｳﾝﾄ
        Dim typPdList                       As List(Of PDList)            '機種ﾘｽﾄ
        Dim lngMaterialLotCnt               As Integer                    '部材管理IDﾘｽﾄｶｳﾝﾄ
        Dim typMaterialLotIDList            As List(Of MaterialLotIDList) '部材管理IDﾘｽﾄ
        Dim strOrderRemainNum               As String                     '発注ﾎﾟｲﾝﾄ
    End Structure

    '@部材種別ﾘｽﾄ構造体(mas_.materialtype 応答)
    Public Structure MaterialTypeList
        Dim strPdLimitFlag                  As String                  '機種限定ﾌﾗｸﾞ
        Dim strMaterialTypeID               As String                  '部材種別ID
        Dim strParameterID                  As String                  'ﾊﾟﾗﾒｰﾀID
        Dim lngMaterialCnt                  As Integer                 '部材IDﾘｽﾄｶｳﾝﾄ
        Dim typMaterialIDList               As List(Of MaterialIDList) '部材IDﾘｽﾄ
    End Structure

    '@部材使用装置ﾘｽﾄ構造体(mas_.materialwp 応答)、装置部材情報取得(mat_.materiallist 受信)
    Public Structure MaterialWPList
        Dim strWpID                         As String                    '装置ID
        Dim strWpName                       As String                    '装置名
        Dim lngMaterialTypeCnt              As Integer                   '部材種別IDﾘｽﾄｶｳﾝﾄ
        Dim typMaterialTypeList             As List(Of MaterialTypeList) '部材種別IDﾘｽﾄ
    End Structure

    '@部材使用装置取得(mas_.materialwp 応答)
    Public Structure MaterialWP
        Dim lngMaterialWPCnt                As Integer                 '装置ﾘｽﾄｶｳﾝﾄ
        Dim typMaterialWPList               As List(Of MaterialWPList) '装置ﾘｽﾄ
    End Structure

    '@装置使用部材判定(mat_.chkwpmaterial 送信)
    Public Structure ChkMaterial
        Dim strSbID                         As String                    'SBID
        Dim strMsgVer                       As String                    'ﾒｯｾｰｼﾞVer
        Dim strClassDivision                As String                    '処理区分(45:廃棄、46:装置使用、47:使用開始、48:使用解除)
        Dim strWpID                         As String                    '装置ID
        Dim strMaterialTypeID               As String                    '技術担当者
        Dim strMaterialID                   As String                    '部材ID
        Dim strMaterialLotID                As String                    '部材管理ID
        Dim strLotID                        As String                    'ﾛｯﾄID
        Dim lngMaterialTypeCnt              As Integer                   '部材種別IDﾘｽﾄｶｳﾝﾄ
        Dim typMaterialTypeList             As List(Of MaterialTypeList) '部材ﾘｽﾄ(部材種別→部材→部材管理IDand機種)
    End Structure

    '@装置使用部材一覧ﾘｽﾄ構造体(mat_.alllist_ 応答)
    Public Structure MaterialAllList
        Dim strMaterialLotID                As String           '部材管理ID
        Dim strMaterialStatus               As String           '部材状態
        Dim strWpID                         As String           '装置ID
        Dim strWpName                       As String           '装置名
        Dim strProductionDate               As String           '製造日
        Dim strAcceptanceDate               As String           '受入日
        Dim strUseTime                      As String           '使用開始日時
        Dim strVenderWarrantDays            As String           'ﾒｰｶｰ保証期間
        Dim strAcceptWarrantDays            As String           '受入制限時間
        Dim strVenderWarrantWarningDays     As String           'ﾒｰｶｰ保証ﾜｰﾆﾝｸﾞ期間
        Dim strAcceptWarrantWarningDays     As String           '受入制限ﾜｰﾆﾝｸﾞ時間
        Dim strUseValidPeriod               As String           '使用可能時間
        Dim strUseInvalidPeriod             As String           '使用禁止(不可)時間
        Dim strWarningPeriod                As String           'ﾜｰﾆﾝｸﾞ表示時間
        Dim strVenderWarrantDaysJudge       As String           'ﾒｰｶｰ保証期間判定ﾌﾗｸﾞ(0:OK、1:NG)
        Dim strAcceptWarrantDaysJudge       As String           '受入制限時間判定ﾌﾗｸﾞ(0:OK、1:NG)
        Dim strVenderWarrantWarningDaysJudge     As String      'ﾒｰｶｰ保証ﾜｰﾆﾝｸﾞ期間判定ﾌﾗｸﾞ(0:OK、1:NG)
        Dim strAcceptWarrantWarningDaysJudge     As String      '受入制限ﾜｰﾆﾝｸﾞ時間判定ﾌﾗｸﾞ(0:OK、1:NG)
        Dim strUseValidPeriodJudge          As String           '使用可能時間判定ﾌﾗｸﾞ(0:OK、1:NG)
        Dim strUseInvalidPeriodJudge        As String           '使用禁止(不可)時間判定ﾌﾗｸﾞ(0:OK、1:NG)
        Dim strWarningPeriodJudge           As String           'ﾜｰﾆﾝｸﾞ表示時間判定ﾌﾗｸﾞ(0:OK、1:NG)
        Dim strHoldFlag                     As String           '保留ﾌﾗｸﾞ(0:未保留、1:保留中)
        Dim strEditTime                     As String           '最終更新日時
    End Structure

    '@装置使用部材一覧取得(mat_.alllist_ 応答)
    Public Structure MaterialAll
        Dim lngMaterialAllCnt               As Integer                  '装置使用部材一覧ﾘｽﾄｶｳﾝﾄ
        Dim strVenderWarrantDays            As String                   'ﾒｰｶｰ保証期間
        Dim strAcceptWarrantDays            As String                   '受入制限期間
        Dim strUnitClassVwd                 As String                   '単位(ﾒｰｶ保証期間)
        Dim strUnitClassAwd                 As String                   '単位(受入制限期間)
        Dim strUseValidPeriod               As String                   '使用可能時間
        Dim strUnitClassUvp                 As String                   '単位(装置使用可能期間)
        Dim strUseInvalidPeriod             As String                   '使用禁止(不可)時間
        Dim strWarningPeriod                As String                   'ﾜｰﾆﾝｸﾞ表示時間
        Dim typMaterialAllList              As List(Of MaterialAllList) '装置使用部材一覧ﾘｽﾄ
    End Structure

    '@装置使用部材登録/分割(mat_.regmaterial 送信)
    Public Structure RegMaterial
        Dim strSbID                         As String           'SBID
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞVer
        Dim strClassDivision                As String           '処理区分(39:新規登録、44：分割登録)
        Dim strMaterialOrderID              As String           '発注ID
        Dim strMaterialOrderNum             As String           '発注数
        Dim strMaterialTypeID               As String           '部材種別ID
        Dim strMaterialID                   As String           '部材ID
        Dim strSrcMaterialLotID             As String           '分割元部材管理ID
        Dim strMaterialLotID                As String           '分割後(新規登録)部材管理ID
        Dim strProductionDate               As String           '製造日
        Dim strAcceptanceDate               As String           '受入日
        Dim strUseTime                      As String           '使用開始日時
        Dim strEditTime                     As String           '最終更新日時
        Dim strEmpID                        As String           '作業者ID
        Dim strWpID                         As String           '装置ID
    End Structure

    '@装置使用部材状態変更(mat_.chgmaterialstat 送信)
    Public Structure ChgMaterial
        Dim strSbID                         As String           'SBID
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞVer
        Dim strClassDivision                As String           '処理区分(45:廃棄、46:装置使用、47:使用開始、48:使用解除)
        Dim strMaterialTypeID               As String           '部材種別ID
        Dim strMaterialID                   As String           '部材ID
        Dim strMaterialLotID                As String           '部材管理ID
        Dim strWpID                         As String           '装置ID
        Dim strForcedAction                 As String           '強制実行ﾌﾗｸﾞ(0:通常実行、1:強制実行)
        Dim strEditTime                     As String           '最終更新日時
        Dim strEmpID                        As String           '作業者ID
    End Structure

    '@装置部材日付変更(mat_.chgmaterialdate 送信)
    Public Structure ChgMaterialDate
        Dim strSbID                         As String           'SBID
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞVer
        Dim strWpID                         As String           '装置ID
        Dim strMaterialTypeID               As String           '部材種別ID
        Dim strMaterialID                   As String           '部材ID
        Dim strMaterialLotID                As String           '部材管理ID
        Dim strProductionDate               As String           '製造日
        Dim strAcceptanceDate               As String           '受入日
        Dim strStartUseDate                 As String           '使用開始日時
        Dim strEditTime                     As String           '最終更新日時
    End Structure

    '@装置停止ﾒﾝﾃ計画ﾘｽﾄ取得(eq__.schwpmentelist)　要求
    Public Structure EqStopMenteListReq
        Dim strSbID                         As String                 'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String                 'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strClassDivision                As String                 '処理区分
        Dim strWpID                         As String                 '装置ID
        Dim typWpList                       As List(Of WpList)        '装置ﾘｽﾄ
        Dim lngWPCnt                        As Integer                '選択装置ｶｳﾝﾄ
        Dim strJudgeFlag                    As String                 '予実表表示用判定ﾌﾗｸﾞ
        Dim strMcGroupID                    As String                 '装置ｸﾞﾙｰﾌﾟID
        Dim strStartDate                    As String                 '検索開始日
        Dim strStartTime                    As String                 '検索開始時刻
        Dim strEndDate                      As String                 '検索終了日
        Dim strEndTime                      As String                 '検索終了時刻
        Dim typCategoryList                 As List(Of MasCategoryId) 'ｶﾃｺﾞﾘﾘｽﾄ
        Dim lngCategoryCnt                  As Integer                '選択ｶﾃｺﾞﾘｶｳﾝﾄ
    End Structure

    '@装置停止ﾒﾝﾃ計画ﾘｽﾄ取得(eq__.schwpmentelist)　応答
    Public Structure EqStopMenteList
        Dim strWpID                         As String           '装置ID
        Dim strWpName                       As String           '装置名
        Dim strWPStopRule                   As String           '停止ﾙｰﾙ
        Dim strWPStopComments               As String           '停止ｺﾒﾝﾄ
        Dim strEmpID                        As String           '作業者ID
        Dim strEmpName                      As String           '作業者名
        Dim strEditTime                     As String           '更新日時
        Dim strWPStopStart                  As String           '停止開始日時
        Dim strWPStopEnd                    As String           '停止終了日時
        Dim strEntryTime                    As String           '登録日時
        Dim strCategoryID                   As String           'ｶﾃｺﾞﾘID
        Dim strCategoryName                 As String           'ｶﾃｺﾞﾘ名(和名)
    End Structure

    '@装置停止ﾒﾝﾃ計画ﾘｽﾄ取得(eq__.schwpmentelist)　応答
    Public Structure EqStopMenteListAns
        Dim lngEqStopMenteListCnt           As Integer                  'ﾘｽﾄｶｳﾝﾄ
        Dim typEqStopMenteList              As List(Of EqStopMenteList) '装置停止ﾒﾝﾃ計画ﾘｽﾄ構造体
    End Structure

    '@日付ﾘｽﾄ構造体
    Public Structure WPNameList
        Dim strWpName                       As String                   '装置名
        Dim lngEqStopMenteListCnt           As Integer                  '予実ﾘｽﾄｶｳﾝﾄ
        Dim typEqStopMenteList              As List(Of EqStopMenteList) '予実ﾘｽﾄ
    End Structure

    '@予実ﾘｽﾄ構造体
    Public Structure DateList
        Dim strDate                         As String              '日付
        Dim strDateClass                    As String              '日付種別
        Dim lngWPNameCnt                    As Integer             '装置名ﾘｽﾄｶｳﾝﾄ
        Dim typWPNameList                   As List(Of WPNameList) '装置名ﾘｽﾄ
    End Structure

    '@予実表表示画面への引継ぎ用構造体
    Public Structure EqDetailList
        Dim lngDateCnt                      As Integer           '予実ﾘｽﾄｶｳﾝﾄ
        Dim typDateList                     As List(Of DateList) '日付ﾘｽﾄ
        Dim strMcGroupName                  As String            '装置ｸﾞﾙｰﾌﾟ名
        Dim strWpName                       As String            '装置名
        Dim strFromDate                     As String            '開始指定日
        Dim strFromTime                     As String            '開始指定時間
        Dim strToDate                       As String            '終了指定日
        Dim strToTime                       As String            '終了指定時間
    End Structure

    '@装置停止ﾒﾝテ計画登録/変更(eq__.schwpmentechg)　要求
    Public Structure EqStopMenteReq
        Dim strSbID                         As String           'SBID
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strClassDivision                As String           '処理区分
        Dim strWpID                         As String           '装置ID
        Dim strWPStopRule                   As String           '停止ﾙｰﾙ
        Dim strWPStopComments               As String           '停止ｺﾒﾝﾄ
        Dim strEmpID                        As String           '作業者ID
        Dim strEditTime                     As String           '更新日時
        Dim strWPStopStartOld               As String           '旧停止開始日時(計画or実績)
        Dim strWPStopStart                  As String           '停止開始日時(計画or実績)
        Dim strWPStopEnd                    As String           '停止終了日時(計画or実績)
        Dim strEntryTime                    As String           '登録日時
        Dim strCategoryID                   As String           'ｶﾃｺﾞﾘID
    End Structure

    '@①　装置停止ﾒﾝﾃ計画一覧　⇔　装置停止ﾒﾝﾃ計画登録　連携情報
    '@②　装置停止ﾒﾝﾃ計画一覧　⇔　停止ｺﾒﾝﾄ変更Msg　送信用
    Public Structure EqStopMenteRenkeiInfo
        Dim lngInsertMode                   As Integer          '登録ﾓｰﾄﾞ(1:新規、2:ｺﾋﾟｰ登録、3:修正)
        Dim strMcGroupID                    As String           '装置ｸﾞﾙｰﾌﾟID
        Dim strMcGroupName                  As String           '装置ｸﾞﾙｰﾌﾟ名
        Dim strWpID                         As String           '装置ID
        Dim strWpName                       As String           '装置名
        Dim strWPStopStart                  As String           '停止開始日時(計画/実績共通)
        Dim strWPStopEnd                    As String           '停止終了日時(計画/実績共通)
        Dim strWPStopStartOld               As String           '旧停止開始日時(計画/実績共通)
        Dim strWPStopEndOld                 As String           '旧停止終了日時(計画/実績共通)
        Dim strCategoryID                   As String           'ｶﾃｺﾞﾘID
        Dim strCategoryName                 As String           'ｶﾃｺﾞﾘ名
        Dim strStopTime                     As String           '停止時間
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strEditTime                     As String           '最終更新日時
        Dim strEntryTime                    As String           '登録日時
    End Structure

    '@ﾛｯﾄ別不良/払出ｺｰﾄﾞ別不良/払出数情報格納用
    Public Structure NowScrapList
        Dim strScrapCode                    As String           '不良/払出ｺｰﾄﾞ
        Dim strScrapName                    As String           '不良/払出ｺｰﾄﾞ(和名)
        Dim strScrapNum                     As String           '不良/払出数
    End Structure

    Public Structure WFScrapInfo
        Dim strWfId                         As String                'WFID
        Dim typNowScrapList                 As List(Of NowScrapList) '不良/払出情報ﾘｽﾄ
    End Structure

    Public Structure LotScrapInfo
        Dim typWFScrapInfo                  As List(Of WFScrapInfo) 'WF不良/払出数ﾘｽﾄ
        Dim strLotOutQuantity               As String               'ﾛｯﾄ合計不良数
        Dim strLotForwardQuantity           As String               'ﾛｯﾄ合計払出数
        Dim lngScrapCnt                     As Integer              '不良/払出項目数
        Dim lngScrapInputBeforeChipCnt      As Integer              '不良/払出入力前良品数
    End Structure



    '@↓工順変更------------------------------------------------------------------------------------------------------

    '@時間制限選択情報
    Public Structure TimeLimitSelectList
        Dim strListOrder                    As String           '時間制約番号
        Dim strEnableFlag                   As String           '有効/無効ﾌﾗｸﾞ
        Dim strFromOpId                     As String           '元大工程ID
        Dim strToOpId                       As String           '先大工程ID
        Dim strFromStepId                   As String           '元小工程ID
        Dim strToStepId                     As String           '先小工程ID
        Dim strRestrictTypeID               As String           '制限(制約)ﾀｲﾌﾟ名
    End Structure

    '@時間制限選択情報
    Public Structure LTSelectList
        Dim lngLTSelectListCnt              As Integer                      'ﾘｽﾄｶｳﾝﾄ
        Dim typLTSelectList                 As List(Of TimeLimitSelectList) '配列
    End Structure

    '@引継ぎ構造体(APC設定連携)
    Public Structure ApcOpStepList
        Dim strListOrder                    As String           'ｵｰﾀﾞ番号
        Dim strFromOpId                     As String           '処理大工程ID
        Dim strFromStepId                   As String           '処理小工程ID
        Dim strToOpId                       As String           '測定大工程ID
        Dim strToStepId                     As String           '測定小工程ID
        Dim blnPatchFlag                    As Boolean      'F/B(合せ)のpatchフラグ(False:パッチ分割なし、True：パッチ分割あり)
        Dim lngPatchDivNum                  As Integer      'F/B(合せ)のpatch分割数
        Dim strToOpId_2                     As String       '測定大工程2ID
        Dim strToStepId_2                   As String       '測定小工程2ID
        Dim strToOpId_3                     As String       '測定大工程3ID
        Dim strToStepId_3                   As String       '測定小工程3ID
        Dim strToOpId_4                     As String       '測定大工程4ID
        Dim strToStepId_4                   As String       '測定小工程4ID
        Dim strToOpId_5                     As String       '測定大工程5ID
        Dim strToStepId_5                   As String       '測定小工程5ID
        Dim strToOpId_6                     As String       '測定大工程6ID
        Dim strToStepId_6                   As String       '測定小工程6ID
        Dim strToOpId_7                     As String       '測定大工程7ID
        Dim strToStepId_7                   As String       '測定小工程7ID
        Dim strToOpId_8                     As String       '測定大工程8ID
        Dim strToStepId_8                   As String       '測定小工程8ID
        Dim strToOpId_9                     As String       '測定大工程9ID
        Dim strToStepId_9                   As String       '測定小工程9ID
    End Structure

    Public Structure ApcTypeList
        Dim lngApcOpStepListCnt             As Integer                'APC設定工程ﾘｽﾄｶｳﾝﾄ
        Dim typApcOpStepList                As List(Of ApcOpStepList) 'APC設定工程ﾘｽﾄ
    End Structure

    '@引継ぎ構造体(APC設定連携)
    Public Structure ApcOpStepInfo
        Dim lngApcTypeCnt                   As Integer              'APCﾀｲﾌﾟｶｳﾝﾄ
        Dim typApcTypeList                  As List(Of ApcTypeList) 'APCﾀｲﾌﾟﾘｽﾄ
        Dim strListOrderNow                 As List(Of String)      'xxx番号(選択済みのﾘｽﾄｵｰﾀﾞ)
        Dim strApcTypeNow                   As String               'APCﾀｲﾌﾟ(選択済みのﾀｲﾌﾟ)
    End Structure

    '@工順変更中ﾛｯﾄ工順情報
    Public Structure ProcChg
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strCurrentStatus                As String           'ﾛｯﾄ現在状態
        Dim strCurrentStatusName            As String           'ﾛｯﾄ現在状態(和名)
        Dim strLotPos                       As String           'ﾛｯﾄ位置
        Dim strEditStatus                   As String           '編集状態
        Dim strEmpID                        As String           '編集者ID
        Dim strEmpName                      As String           '編集者名
        Dim strEditTime                     As String           '最終更新日時
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strKindFlag                     As String           '種別
        Dim strUserPrcName                  As String           'ﾕｰｻﾞｰﾌﾟﾛセｽ名
        Dim strFlowClass                    As String           '流動区分
        Dim strLotHoldFlag                  As String           'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strLotStopFlag                  As String           'ﾛｯﾄ停止ﾌﾗｸﾞ
        Dim strWfCarryFlag                  As String           'WF移載中ﾌﾗｸﾞ
        Dim strPdId                         As String           '機種ID
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strLcDirection                  As String           '液晶方向
        Dim strReworkFlag                   As String           'ﾘﾜｰｸﾌﾗｸﾞ(0：なし、1：ﾘﾜｰｸ、2：追加)
        Dim strProcFlag                     As String           'ﾛｯﾄ種別(0:通常、1:ﾘﾜｰｸ(特殊))
        Dim strVerUpProhibitedFlag          As String           'VerUp禁止(0：可、1:不可)
        Dim strProhibitedEmpName            As String           '禁止設定者
        Dim strProhibitedDeptName           As String           '禁止設定部署名
        Dim strLotLastUpdate                As String           '最終更新日時(LOT_STATUS.EDIT_TIME)
        Dim strSendSBID                     As String           '送品先
        Dim strSbArea                       As String           'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        Dim strFlowChangeCount              As String           '工順変更回数
    End Structure

    '@工順変更中ﾛｯﾄ工順情報(proc.procchglist 応答)
    Public Structure ProcChgList
        Dim lngProcChgCnt                   As Integer          '工順変更中ﾛｯﾄ数
        Dim typProcChg                      As List(Of ProcChg) '工順変更中ﾛｯﾄ工順情報
    End Structure

    '@工順状態変更(proc.procchgstatus 要求)
    Public Structure ProcchgstatusReq
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strMsgVer                       As String           'Msgﾊﾞｰｼﾞｮﾝ
        Dim strAction                       As String           'ｱｸｼｮﾝｺｰﾄﾞ
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strEmpID                        As String           '作業者ID
        Dim strLotLastUpdate                As String           '最終更新日時
    End Structure

    '@工程ﾌﾛｰ時間制約情報
    Public Structure TimeOrder
        Dim strListOrder                    As String           '時間制約
        Dim strStatusFlag                   As String           '時間制約状態ﾌﾗｸﾞ
        Dim strRestrictTypeID               As String           '制約ﾀｲﾌﾟ
        Dim strOutSideFlag                  As String           '外部開始・終了
    End Structure

    '@工程ﾌﾛｰAPC情報
    Public Structure ApcOrder
        Dim strListOrder                    As String           'APCｵｰﾀﾞ番号
        Dim strStatusFlag                   As String           'APC状態ﾌﾗｸﾞ(P:処理、M：測定)
        Dim strApcType                      As String           'APCﾀｲﾌﾟ(1：F/F、2:F/B)
        Dim blnApcWfUnitFlg                 As Boolean          'APC枚葉設定
    End Structure

    Public Structure RecpSelApcElem
        Dim strListOrder                    As String           'APCｵｰﾀﾞ番号
        Dim strApcType                      As String           'APCﾀｲﾌﾟ(1：F/F、2:F/B)
        Dim strProcOpId                     As String           '処理大行程
        Dim strProcStepId                   As String           '処理小行程
        Dim strMeasOpId                     As String           '測定大行程
        Dim strMeasStepId                   As String           '測定小行程
        Dim blnApcWfUnitFlg                 As Boolean          'APC枚葉設定
    End Structure

    Public Structure RecipeSelApc
        Dim lngRecipeSelApcCnt              As Integer                 'APC数
        Dim typRecipeSelApc                 As List(Of RecpSelApcElem) 'ﾚｼﾋﾟ選択APC設定
    End Structure

    Public Structure TypeApcTeos
        Dim strGroupNo                      As String           'TEOSグループNo
        Dim strNoInGroup                    As String           'TEOSグループ内No
        Dim strCalcSkipFlag                 As String           'TEOS計算除外
        Dim strApcType                      As String           'TEOS工程タイプ
    End Structure

    Public Structure TypeApcTeosStep
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim typApcTeos                      As TypeApcTeos      'APC TEOS関連の情報
    End Structure

    '@工程ﾌﾛｰ情報
    Public Structure FlowList
        Dim strState                        As String            '状態
        Dim strPermit                       As String            '編集可否
        Dim strChange                       As String            '変更区分
        Dim strAbsNo                        As String            '絶対工順番号
        Dim strSeqNum                       As String            '工順番号
        Dim strOpID                         As String            '大工程ID
        Dim strStepID                       As String            '小工程ID
        Dim strConditionId                  As String            '処理条件ID
        Dim strConditionVersion             As String            '処理条件ﾊﾞｰｼﾞｮﾝ
        Dim strConditionOne                 As String            '個別処理条件
        Dim strSelectConditionID            As String            'WF選択条件ｾｯﾄID
        Dim strCollectionID                 As String            '収集項目ID
        Dim strCollectionVersion            As String            '収集項目ﾊﾞｰｼﾞｮﾝ
        Dim strLotScrapSetID                As String            '不良項目ｾｯﾄID
        Dim strReworkRouteID                As String            'ﾘﾜｰｸﾙｰﾄID
        Dim strReworkReturnOpID             As String            'ﾘﾜｰｸ戻り大工程(ｺﾋﾟｰ未)
        Dim strReworkReturnStepID           As String            'ﾘﾜｰｸ戻り小工程(ｺﾋﾟｰ未)
        Dim strSpecialRouteID               As String            '追加ﾙｰﾄID
        Dim strSpecialReturnOpID            As String            '追加戻り大工程(ｺﾋﾟｰ未)
        Dim strSpecialReturnStepID          As String            '追加戻り小工程(ｺﾋﾟｰ未)
        Dim strSwapIndicator                As String            '入替可能工程(ｺﾋﾟｰ未)
        Dim strAltStartFlag                 As String            '代替開始ﾌﾗｸﾞ(ｺﾋﾟｰ未)
        Dim strAltEndFlag                   As String            '代替終了ﾌﾗｸﾞ(ｺﾋﾟｰ未)
        Dim strAltPointer                   As String            '代替ﾎﾟｲﾝﾀ(ｺﾋﾟｰ未)
        Dim lngTimeOrderCnt                 As Integer           '工程ﾌﾛｰ時間制約情報数(ｺﾋﾟｰ未)
        Dim typTimeOrder                    As List(Of TimeOrder) '工程ﾌﾛｰ時間制約情報(ｺﾋﾟｰ未)
        Dim lngApcOrderCnt                  As Integer           '工程ﾌﾛｰAPC情報数(ｺﾋﾟｰ未)
        Dim typApcOrder                     As List(Of ApcOrder) '工程ﾌﾛｰAPC情報(ｺﾋﾟｰ未)
        Dim strRestrictFlag                 As String            'ﾛｯﾄ個別時間制約ﾌﾗｸﾞ(ｺﾋﾟｰ未)
        Dim strLotRecipeFlag                As String            'ﾛｯﾄ個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
        Dim strWfRecipeFlag                 As String            'WF個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
        Dim strSFlag                        As String            '特殊特性ﾌﾗｸﾞ
        Dim strEntryID                      As String            'ｴﾝﾄﾘｰID
        Dim strWorkCondition                As String            '作業条件
        Dim strProcChangeRecipeFlag         As String            '工順変更ﾚｼﾋﾟﾌﾗｸﾞ
        Dim strCommitFlag                   As String            '号機指定
        Dim strJudgeSkipFlag                As String            'SPC判定ｽｷｯﾌﾟﾌﾗｸﾞ( 0: SKIP不可、1:SKIP可)
        Dim strWfPartialRecipeFlag          As String            '枚葉ﾚｼﾋﾟ設定 ﾌﾗｸﾞ(0：全数、1:部分)
        Dim strListOrder                    As String            'ﾘｽﾄｵｰﾀﾞ(ﾌｫﾄF/B)(ｺﾋﾟｰ未)
        Dim strApcType                      As String            'APCﾀｲﾌﾟ(1:ﾌｫﾄ,2:ｺﾝﾀｸﾄ)(ｺﾋﾟｰ未)
        Dim strStatusFlag                   As String            'F/B工程ﾌﾗｸﾞ(S:開始、E:終了)(ｺﾋﾟｰ未)
        Dim strApcSkipFlag                  As String            'APC適用外(0:適用、1:適用外)(ｺﾋﾟｰ未)
        Dim strApcCalcSkipFlag              As String            'APC計算除外(0：計算実施、1：計算除外)(ｺﾋﾟｰ未)
        Dim strWpRestrictKind               As String            '処理号機種別(1:記憶、2:限定)(ｺﾋﾟｰ未)
        Dim strWpRestrictNum                As String            '処理号機番号(ｺﾋﾟｰ未)
        Dim strCdenClass                    As String            'ﾁｯﾌﾟ電特区分(限定工程設定=C：ﾁｯﾌﾟ品限定工程、M：ﾓｼﾞｭｰﾙ品限定工程、設定なし(NULL)：共通工程)
        Dim strOpValid                      As String            '大工程有効ﾌﾗｸﾞ
        Dim strStepValid                    As String            '小工程有効ﾌﾗｸﾞ
        Dim strConditionValid               As String            '処理条件有効ﾌﾗｸﾞ
        Dim strCollectionValid              As String            '収集項目有効ﾌﾗｸﾞ
        Dim strReworkRouteValid             As String            'ﾘﾜｰｸﾙｰﾄ有効ﾌﾗｸﾞ
        Dim strSpecialRouteValid            As String            '特殊ﾙｰﾄ有効ﾌﾗｸﾞ
        Dim strTpalClass                    As String            'TPAL区分
        Dim strCarrierCategoryId            As String            'ｷｬﾘｱｶﾃｺﾞﾘID
        Dim strMapUseFlag                   As String            'ﾏｯﾌﾟ適用ﾌﾗｸﾞ( 0:非自動適用、1:自動適用)
        Dim strPriority                     As String            '区間優先度
        Dim typApcTeos                      As TypeApcTeos       'APC TEOS関連の情報
        Dim typTeosPrismApc                 As TypeApcTeos       'TEOS PrismAPCの情報
        Dim strGrbClass                     As String            'GRB限定工程設定(GRB限定工程、設定なし(NULL)：共通工程)
        Dim lngRecpSelApcCnt                As Integer           'ﾚｼﾋﾟ選択APC情報数(ｺﾋﾟｰ未)、基本2以上はない(2以上使用するのは将来拡張用)
        Dim typRecpSelApc                   As List(Of ApcOrder) 'ﾚｼﾋﾟ選択APC(ｺﾋﾟｰ未)
    End Structure

    '@工程ﾌﾛｰ情報(proc.procflowlist 要求)
    Public Structure ProcFlowListReq
        Dim strSbID                         As String           'SB_ID
        Dim strMsgVer                       As String           'Msgﾊﾞｰｼﾞｮﾝ
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strTravelerType                 As String           'ﾄﾗﾍﾞﾗｰﾀｲﾌﾟ
    End Structure

    '@工程ﾌﾛｰ情報(proc.procflowlist 応答)
    Public Structure ProcFlowListAns
        Dim strCurrentStatus                As String            '現在状態
        Dim strCurrentStatusName            As String            '現在状態(和名)
        Dim strCurrentOpID                  As String            '現在大工程
        Dim strCurrentStepID                As String            '現在小工程
        Dim strChange                       As String            '全体変更区分
        Dim lngLotProcFlowCnt               As Integer           '工程ﾌﾛｰ数
        Dim typLotProcFlow                  As List(Of FlowList) '工程ﾌﾛｰ情報
    End Structure


    '@ﾌﾟﾛｾｽ登録(proc.procregist 要求)
    Public Structure ProcRegistReq
        Dim strSbID                         As String            'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String            'ﾒｯｾｰｼﾞVer
        Dim strAction                       As String            'ｱｸｼｮﾝ(1:一時保存、2:確定)
        Dim strLotID                        As String            'ﾛｯﾄID
        Dim strStartSeqNum                  As String            '変更開始工順
        Dim strComments                     As String            'ｺﾒﾝﾄ
        Dim strChange                       As String            '全体変更区分
        Dim strEmpID                        As String            '作業者ID
        Dim strVerUpProhibitedFlag          As String            'ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ禁止(0:可、1:禁止)
        Dim lngProcFlowCnt                  As Integer           '工程ﾌﾛｰ情報数
        Dim typProcFlow                     As List(Of FlowList) '工程ﾌﾛｰ情報
    End Structure


    '@ﾌﾟﾛｾｽ登録(proc.procregist 応答)
    Public Structure ProcRegistAns
        Dim strMessageStr                   As String           '論理ﾁｪｯｸｴﾗｰﾒｯｾｰｼﾞ
        Dim strErrorAbsNo                   As String           'ｴﾗｰ絶対工順番号
        Dim strLotLastUpdate                As String           '最終更新日時
    End Structure

    '@ﾛｯﾄｲﾍﾞﾝﾄ履歴情報
    Public Structure ProcEvent
        Dim strEntryTime                    As String           'ｲﾍﾞﾝﾄ日時
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strEmpID                        As String           '作業者ID
        Dim strEmpName                      As String           '作業者名
    End Structure

    '@ﾛｯﾄｲﾍﾞﾝﾄ履歴情報(proc.eventlist 応答)
    Public Structure ProcEventList
        Dim lngProcEventCnt                 As Integer            '工順変更中ﾛｯﾄ数
        Dim typProcEvent                    As List(Of ProcEvent) '工順変更中ﾛｯﾄ工順情報
    End Structure

    '@処理条件詳細情報
    Public Structure ProcCond
        Dim strWpID                         As String           '装置ID
        Dim strWpName                       As String           '装置名
        Dim strRecipeId                     As String           'ﾚｼﾋﾟID
        Dim strRecipeVersion                As String           'ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝ
        Dim strDefaultFlag                  As String           'ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
        Dim strWfId                         As String           'WFID
        Dim strComments                     As String           'ﾚｼﾋﾟｺﾒﾝﾄ
        Dim strSlotPosition                 As String           'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
    End Structure

    '@ﾛｯﾄ処理条件詳細情報
    Public Structure ProcCondDetail
        Dim strAbsNo                        As String            '絶対工順番号
        Dim blnEnableFlag                   As Boolean           '有効/無効ﾌﾗｸﾞ
        Dim strOpID                         As String            '大工程
        Dim strStepID                       As String            '小工程
        Dim strWpCommonRecipeFlag           As String            '装置共通ﾚｼﾋﾟﾌﾗｸﾞ
        Dim lngCondDetailCnt                As Integer           '処理条件詳細情報数
        Dim typProcCond                     As List(Of ProcCond) '処理条件詳細情報
    End Structure

    '@ﾛｯﾄ処理条件詳細情報(lot_.conddetaillist 応答)
    Public Structure ProcCondDetailList
        Dim lngProcCondDetailCnt            As Integer                'ﾛｯﾄ処理条件詳細数
        Dim typProcCondDetail               As List(Of ProcCondDetail) 'ﾛｯﾄ処理条件詳細情報
    End Structure

    '@ﾚｼﾋﾟ一括変更ﾘｽﾄ
    Public Structure ProcRecpList
        Dim strOpID                         As String            '大工程
        Dim strStepID                       As String            '小工程
        Dim lngProcCondListCnt              As Integer           'ﾚｼﾋﾟ一括変更WPﾘｽﾄ数
        Dim typProcCondList                 As List(Of ProcCond) '処理条件詳細情報
    End Structure

    '@ﾚｼﾋﾟ一括変更要求
    Public Structure ProcChgCollectRecp
        Dim lngProcRecpListCnt     As Integer                   'ﾚｼﾋﾟ一括変更ﾘｽﾄ数
        Dim typProcRecpList        As List(Of ProcRecpList)     'ﾚｼﾋﾟ一括変更ﾘｽﾄ
    End Structure

    '@時間制約ﾘｽﾄ
    Public Structure ProcTimeLimit
        Dim strListOrder                    As String           '時間制約番号
        Dim strFromOpId                     As String           '元大工程ID
        Dim strToOpId                       As String           '先大工程ID
        Dim strFromStepId                   As String           '元小工程ID
        Dim strToStepId                     As String           '先小工程ID
        Dim strRestrictTypeID               As String           '制限(制約)ﾀｲﾌﾟ名
        Dim strWarnTime                     As String           '警告時間
        Dim strLimitTime                    As String           '制限(制約)時間
        Dim blnEnableFlag                   As Boolean          '有効/無効ﾌﾗｸﾞ
    End Structure

    '@時間制約情報(proc.timelimitinfo 応答)
    Public Structure ProcTimeLimitInfo
        Dim strListOrderBase                As String                 '時間制約番号基底値
        Dim lngProcTimeLimitCnt             As Integer                '時間制約ﾘｽﾄ数
        Dim typProcTimeLimit                As List(Of ProcTimeLimit) '時間制約ﾘｽﾄ
    End Structure

    '@ｺﾋﾟｰ用構造体
    Public Structure CopyFlowList
        Dim lngLotProcFlowCnt               As Integer           '工程ﾌﾛｰ数
        Dim typLotProcFlow                  As List(Of FlowList) '工程ﾌﾛｰ情報
    End Structure

    '@APCﾀｲﾌﾟ
    Public Structure ApcList
        Dim strApcType                      As String           'APCﾀｲﾌﾟ
        Dim strProcessEqType                As String           '処理装置ﾀｲﾌﾟ
        Dim strProcessWpName                As String           '処理装置名
        Dim strMeasuerEqType                As String           '測定装置ﾀｲﾌﾟ
        Dim strMeasuerWpName                As String           '測定装置名
    End Structure

    'APC情報(mas_apclist_　応答)
    Public Structure ApcAns
        Dim lngApcListCnt                   As Integer          'APCﾘｽﾄｶｳﾝﾄ
        Dim typApcList                      As List(Of ApcList) 'APCﾘｽﾄ
    End Structure

    '@ﾌﾟﾛｾｽ編集開始
    Public Structure proceditstartReq
        Dim strMsgVer                       As String           'Msgﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strEmpID                        As String           '作業者ID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strAction                       As String           'ｱｸｼｮﾝ(1:保留 2:保留予約)
        Dim strOpID                         As String           '大工程      保留なら現工程、保留予約なら編集開始工程の直前の大工程
        Dim strStepID                       As String           '小工程      保留なら現工程、保留予約なら編集開始工程の直前の小工程
        Dim strAbsNo                        As String           '絶対工順番号(編集開始)
        Dim strCurrentOpID                  As String           '現在大工程(CLが抑えている大工程)
        Dim strCurrentStepID                As String           '現在小工程(CLが抑えている小工程)
    End Structure

    '@ﾛｯﾄ一覧取得(proc.list____)要求
    Public Structure ProcLotListReq
        Dim strSbID                         As String                 'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strAction                       As String                 'ｱｸｼｮﾝ(0：工順変更中ﾛｯﾄを含まない、1:工順変更中ﾛｯﾄを含む)
        Dim strMsgVer                       As String                 'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim lngPdCnt                        As Integer                '機種区分の選択数
        Dim typPdList                       As List(Of PDList)        '機種区分
        Dim typFlowClassList                As List(Of FlowClassList) '種別IDﾘｽﾄ
        Dim lngFlowClassListCnt             As Integer                '種別IDﾘｽﾄｶｳﾝﾄ
        Dim strLotFlowStatusID              As String                 'ﾛｯﾄ流動ｽﾃｰﾀｽID(0:流動中,1:流動前 2:流動外)
        Dim strLotID                        As String                 'ﾛｯﾄID
        Dim strCarrierId                    As String                 'ｷｬﾘｱID
    End Structure

    '@ﾛｯﾄ一覧取得(Lotlist)
    Public Structure ProcLotList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strFlowClass                    As String           '流動区分
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strNowST                        As String           'LOT状態
        Dim strEngEmpName                   As String           '技術担当者名
        Dim strWfNum                        As String           'WF枚数
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ数
        Dim strLotHoldFlag                  As String           'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strLotStopFlag                  As String           'ﾛｯﾄ停止ﾌﾗｸﾞ
        Dim strWfCarryFlag                  As String           'WF移載中ﾌﾗｸﾞ
        Dim strLotPriority                  As String           '優先度
        Dim strCurrentPositionName          As String           'ﾛｯﾄ位置(和名)
        Dim strComments                     As String
        Dim strLotLastUpdate                As String           'ﾛｯﾄ最終更新日付
        Dim strReworkFlag                   As String           'ﾘﾜｰｸﾌﾗｸﾞ(1:ﾘﾜｰｸ　0:ﾘﾜｰｸなし)
        Dim strProcFlag                     As String           'ﾛｯﾄ種別(0：通常ﾛｯﾄ、ﾘﾜｰｸ(特殊))
        Dim strPdId                         As String           '機種ID
        Dim strLcDirection                  As String           '液晶方向
        Dim strVerUpProhibitedFlag          As String           'VerUp禁止(0：可、1:不可)
        Dim strProhibitedEmpName            As String           '禁止設定者
        Dim strProhibitedDeptName           As String           '禁止設定者部署
        Dim strSendSBID                     As String           '送品先
        Dim strSbArea                       As String           'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
    End Structure

    '@ﾛｯﾄ一覧取得(proc.list____)応答
    Public Structure ProcLotListAns
        Dim lngProcLotListCnt               As Integer              'ﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typProcLotList                  As List(Of ProcLotList) 'ﾛｯﾄﾘｽﾄ
    End Structure

    '@ﾏｽﾀ工順ﾌﾛｰ取得(mas_.procflowlist　要求)
    Public Structure MstFlowListReq
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strPdId                         As String           '機種ID
        Dim strEntryID                      As String           'ｴﾝﾄﾘｰID
    End Structure

    '@引継ぎ構造体
    Public Structure EN01X7
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strNowDate                      As String           '情報取得日時
        Dim strProcFlag                     As String           'ﾛｯﾄ種別ﾌﾗｸﾞ(0:通常ﾛｯﾄ、1:特殊ﾛｯﾄ)
    End Structure

    '@引継ぎ構造体
    Public Structure EN01X4
        Dim strPdId                         As String           '機種id
        Dim strEntryID                      As String           'ｴﾝﾄﾘID
        Dim strEntryTime                    As String           '適用日時
    End Structure

    '@WF情報構造体
    Public Structure ProcWFList
        Dim strWfId                         As String           'ｳｪﾊID
        Dim strSlotPosition                 As String           'ｳｪﾊｽﾛｯﾄ№
        Dim strWaferRecipeKind              As String           '枚葉ﾚｼﾋﾟ設定状態
    End Structure

    '@WF情報ﾘｽﾄ取得(proc.waferlist)
    Public Structure ProcWaferList
        Dim lngProcWFListCnt                As Integer             'ﾘｽﾄｶｳﾝﾄ
        Dim typProcWFList                   As List(Of ProcWFList) 'WF情報ﾘｽﾄ
    End Structure

    '@号機限定(記憶)
    Public Structure WpRestrict
        Dim strWpRestrictNum                As String           '号機限定№
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strValidFlag                    As String           '有効/無効
    End Structure
    Public Structure WpRestrictInfo
        Dim lngWpRestrictCnt                As Integer             'ﾃﾞｰﾀｶｳﾝﾄ
        Dim typWpRestrict                   As List(Of WpRestrict) 'ﾃﾞｰﾀ構造体
    End Structure

    '@実績報告工程(要素)
    Public Structure ReportPointList
        Dim strSeqNum                       As String
        Dim strPrtsType                     As String
        Dim strOpID                         As String
        Dim strStepID                       As String
        Dim strCollectType                  As String
        Dim strPartCode                     As String
        Dim strPartName                     As String
    End Structure

    Public Structure PdReportPointList
        Dim strPdId                         As String
        Dim lngPdReportPointCnt             As Integer
        Dim typeReportPointList             As List(Of ReportPointList)
    End Structure

    '@実績報告工程
    Public Structure ReportPoint
        Dim strSbID                         As String
        Dim lngPdListCnt                    As Integer
        Dim typePdList                      As List(Of PdReportPointList)
    End Structure
    '@↑工順変更------------------------------------------------------------------------------------------------------

    '@ﾊﾟｰﾂｺｰﾄﾞ一覧
    Public Structure PointList
        Dim strPoint                        As String           'ﾎﾟｲﾝﾄ
    End Structure

    '@過去在庫一覧用(WF情報)
    Public Structure SnapWfList
        Dim strWfId                         As String           'WF_ID
        Dim strChipGoodQuantity             As String           '良品ﾁｯﾌﾟ
        Dim strChipOutQuantity              As String           '不良ﾁｯﾌﾟ
        Dim strKettenChipQuantity           As String           '欠点数
        Dim strChipForwardQuantity          As String           '払出
    End Structure

    '@過去在庫一覧用(機種別ﾏｯﾌﾟ情報)
    Public Structure SnapPDList
        Dim strPdId                         As String            'PD_ID
        Dim lngRowNumListCnt                As Integer           'ｽﾛｯﾄﾏｯﾌﾟ情報ﾘｽﾄ件数
        Dim typRowNumList                   As List(Of MasPdMap) 'ｽﾛｯﾄﾏｯﾌﾟ情報ﾘｽﾄ
    End Structure

    '@過去在庫一覧用(機種別ﾏｯﾌﾟ情報)
    Public Structure SnapPDMap
        Dim strSnapPDCnt                    As Integer             'ｶｳﾝﾄ
        Dim typSnapPDList                   As List(Of SnapPDList) 'ｽﾛｯﾄﾏｯﾌﾟ情報ﾘｽﾄ
    End Structure

    '@過去在庫一覧(lot_.snapshotlist 送信)
    Public Structure SnapShotReqList
        Dim strSbID                         As String                 'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strMsgVer                       As String                 'Msgﾊﾞｰｼﾞｮﾝ
        Dim strSearchDate                   As String                 '検索日時(年月日+時分)
        Dim lngPdCnt                        As Integer                '選択機種ｶｳﾝﾄ
        Dim typPdList                       As List(Of PDList)        '機種ﾘｽﾄ
        Dim lngFlowClassCnt                 As Integer                '選択種別ｶｳﾝﾄ
        Dim typFlowClassList                As List(Of FlowClassList) '種別ﾘｽﾄ
        Dim lngPointCnt                     As Integer                '選択ﾎﾟｲﾝﾄｶｳﾝﾄ
        Dim typPointList                    As List(Of PointList)     'ﾎﾟｲﾝﾄﾘｽﾄ
        Dim strCurrentPositionID            As String                 'ｷｬﾘｱ位置ID
        Dim strOpID                         As String                 '大工程
        Dim strStepID                       As String                 '小工程
    End Structure

    '@過去在庫一覧(lot_.snapshotlist 受信)
    Public Structure SnapShotAns
        Dim strPdId                         As String               '機種
        Dim strCurrentPositionName          As String               'ｷｬﾘｱ位置(和名)
        Dim strOpID                         As String               '大工程
        Dim strStepID                       As String               '小工程
        Dim strGnsWFNum                     As String               'Gns報告WF枚数
        Dim strGnsChipQuantity              As String               'Gns報告ﾁｯﾌﾟ数
        Dim strWfNum                        As String               'WF枚数
        Dim strChipQuantity                 As String               '良品Chip
        Dim strChipOutQuantity              As String               '不良Chip
        Dim strChipForwardQuantity          As String               '払出Chip
        Dim strCfWfNum                      As String               'WF枚数(対向)
        Dim strCfPartCode                   As String               '部品コード(対向)
        Dim strFlowClass                    As String               '種別
        Dim strLotID                        As String               'ﾛｯﾄID
        Dim strCarrierId                    As String               'ｷｬﾘｱID
        Dim strMPROrder                     As String               '量産ｵｰﾀﾞｰ
        Dim strPartCode                     As String               '部品ｺｰﾄﾞ
        Dim strPoint                        As String               '量産ﾎﾟｲﾝﾄ
        Dim strPROrder                      As String               'PRｵｰﾀﾞｰ
        Dim strCfFlag                       As String               'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strLpFlag                       As String               'LPﾌﾗｸﾞ(0：ODFﾛｯﾄ以外、1：ODFﾛｯﾄ)
        Dim lngWfListCnt                    As Integer              'WFﾘｽﾄ件数
        Dim typWfList                       As List(Of SnapWfList)  'WFﾘｽﾄ
        Dim lngRowNumListCnt                As Integer              'ｽﾛｯﾄﾏｯﾌﾟ情報ﾘｽﾄ件数
        Dim typRowNumList                   As List(Of MasPdMap)    'ｽﾛｯﾄﾏｯﾌﾟ情報ﾘｽﾄ
    End Structure

    '@過去在庫一覧(lot_.snapshotlist 受信)
    Public Structure SnapShotAnsList
        Dim lngSnapShotListCnt              As Integer              '在庫ｽﾅｯﾌﾟｼｮｯﾄ件数
        Dim typSnapShotList                 As List(Of SnapShotAns) '在庫ｽﾅｯﾌﾟｼｮｯﾄﾘｽﾄ
    End Structure

    '@星取表表示画面引継ぎ用構造体
    Public Structure TakeOverDataEN01Y0
        Dim strLotID                        As String              'ﾛｯﾄID
        Dim strPdId                         As String              '機種
        Dim strFlowClass                    As String              '種別
        Dim strCarrierId                    As String              'ｷｬﾘｱID
        Dim strOpID                         As String              '大工程
        Dim strStepID                       As String              '小工程
        Dim strMPROrder                     As String              '量産ｵｰﾀﾞｰ
        Dim strPartCode                     As String              '部品ｺｰﾄﾞ
        Dim strPoint                        As String              '量産ﾎﾟｲﾝﾄ
        Dim strSearchDate                   As String              '検索日時
        Dim strCfFlag                       As String              'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strLpFlag                       As String              'LPﾌﾗｸﾞ(0：ODFﾛｯﾄ以外、1：ODFﾛｯﾄ)
        Dim lngWfListCnt                    As Integer             'WFﾘｽﾄ件数
        Dim typWfList                       As List(Of SnapWfList) 'WFﾘｽﾄ
        Dim lngRowNumListCnt                As Integer             'ｽﾛｯﾄﾏｯﾌﾟ情報ﾘｽﾄ件数
        Dim typRowNumList                   As List(Of MasPdMap)   'ｽﾛｯﾄﾏｯﾌﾟ情報ﾘｽﾄ
    End Structure

    '@ｷｬﾘｱ位置取得(carr.curposition 受信, lot_.snapshotlist 送信)
    Public Structure CurrentPositionList
        Dim strCurrentPositionID            As String           'ｷｬﾘｱ位置ID
        Dim strCurrentPositionName          As String           'ｷｬﾘｱ位置名
    End Structure

    '@送品先ﾘｽﾄ取得(mas_.sendsbidlist,mas_.sbroutelist)　応答
    Public Structure SendSBListAns
        Dim lngSendSBListCnt                As Integer             'ﾘｽﾄｶｳﾝﾄ
        Dim typSendSBList                   As List(Of SendSBList) '送品先ﾘｽﾄ構造体
    End Structure

    '@ｶﾃｺﾞﾘ一覧(mas_.mentecategorylist 受信)
    Public Structure MenteCategoryList
        Dim strUseId                        As String           '用途ID
        Dim strUseName                      As String           '用途名
    End Structure

    '@不良保留払出傾向情報(廃棄ｳｪﾊ)
    Public Structure ScrapWF
        Dim strWfId                         As String           'ｳｪﾊID
        Dim strSlotPosition                 As String           'ｳｪﾊｽﾛｯﾄ№
        Dim strGrbClass                     As String           'GRB区分
        Dim strClass                        As String           '区分
        Dim strClassID                      As String           '項目ID
        Dim strRegistChipOutNum             As String           '登録不良ﾁｯﾌﾟ数
        Dim strRegistChipForwardNum         As String           '登録払出ﾁｯﾌﾟ数
    End Structure

    '@不良保留払出傾向登録(wf__.directscrap 要求)
    Public Structure DirectScrap
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           '処理区分
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim lngScrapWFListCnt               As Integer          'ﾘｽﾄｶｳﾝﾄ
        Dim typScrapWFList                  As List(Of ScrapWF) '廃棄ｳｪﾊ情報ﾘｽﾄ
        Dim strResponsble_Emp_ID            As String           '責任者ID
        Dim strEngEmpId                     As String           '作業者ID
        Dim strLotLastUpdate                As String           'LOT最終更新日時
    End Structure

    '@装置処理部用途取得(mas_.wpprocessingnamelist)要求
    Public Structure WpProcessingNameListReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           '処理区分
        Dim strWpID                         As String           'WPID
    End Structure

    '@処理部用途ﾘｽﾄ
    Public Structure ProcessingList
        Dim strChamberId                    As String           '処理部用途ID
        Dim strProcessingName               As String           '処理部用途名
        Dim strDispOnFlag                   As String           '表示ﾌﾗｸﾞ(0：しない、1:する)
    End Structure

    '@装置処理部用途取得(mas_.wpprocessingnamelist)応答
    Public Structure WpProcessingNameListAns
        Dim lngProcessingListCnt            As Integer                 '処理部用途ｶｳﾝﾄ
        Dim typProcessingList               As List(Of ProcessingList) '処理部用途ﾘｽﾄ
    End Structure

    '@処理部状態ﾘｽﾄ
    Public Structure ChamberUseList
        Dim strUseId                        As String           '処理部状態ID
        Dim strUseName                      As String           '処理部状態名
    End Structure

    '@装置処理部状態取得(mas_.chamberuselist)応答
    Public Structure ChamberuseListAns
        Dim lngChamberUseListCnt            As Integer                 '処理部用途ｶｳﾝﾄ
        Dim typChamberUseList               As List(Of ChamberUseList) '処理部状態ﾘｽﾄ
    End Structure

    '@装置処理部用途ﾘｽﾄ取得(eq__.wpprocessinguse)要求
    Public Structure WpProcessingUseReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strWpID                         As String           'WPID
    End Structure

    '@処理部用途ﾘｽﾄ
    Public Structure ProcessingUseList
        Dim strNo                           As String           '順番
        Dim strChamberId                    As String           '処理部用途ID
        Dim strChamberUseId                 As String           '処理部状態ID
        Dim strOldChamberId                 As String           '処理部用途ID(変更前)
        Dim strOldChamberUseId              As String           '処理部状態ID(変更前)
        Dim strEditTime                     As String           '更新日時
    End Structure

    '@装置処理部用途ﾘｽﾄ取得(eq__.wpprocessinguse)応答
    Public Structure WpProcessingUseAns
        Dim lngProcessingUseListCnt         As Integer                    '処理部用途ﾘｽﾄｶｳﾝﾄ
        Dim typProcessingUseList            As List(Of ProcessingUseList) '処理部用途ﾘｽﾄ
    End Structure

    '@装置処理部用途変更(eq__.chgwpprocessinguse)要求
    Public Structure ChgWpProcessingUseReq
        Dim strMsgVer                       As String                     'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strWpID                         As String                     'WPID
        Dim strSbID                         As String                     'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strComments                     As String                     'ｺﾒﾝﾄ
        Dim strEmpID                        As String                     '作業者ID
        Dim lngProcessingUseListCnt         As Integer                    '処理部用途ﾘｽﾄｶｳﾝﾄ
        Dim typProcessingUseList            As List(Of ProcessingUseList) '処理部用途ﾘｽﾄ
    End Structure


    '@故障修理記録票一覧取得(rep_.repairlist)要求
    Public Structure RepairInfoReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strRepairNo                     As String           '故障修理記録№
        Dim strStartDate                    As String           '検索開始日
        Dim strEndDate                      As String           '検索終了日
        Dim strWpID                         As String           '装置ID
        Dim strWpName                       As String           '装置名(ErrMsg用)
        Dim typWpList                       As List(Of WP)      '装置ﾘｽﾄ
        Dim lngWPCnt                        As Integer          '装置ﾘｽﾄｶｳﾝﾄ
        Dim strEntryTime                    As String           '登録日時
    End Structure
        
    '@担当者ﾘｽﾄ(確認依頼先)
    Public Structure EmpList
        Dim strEmpID                        As String           '担当者ID
        Dim strEmpName                      As String           '担当者名
    End Structure

    '@故障修理記録票情報(一覧)取得(rep_.repairlist, rep_.repairinfo)応答
    Public Structure RepairInfoAns
        Dim strRepairNo                     As String           '故障修理記録№
        Dim strEmpName                      As String           '作業者名(更新者名)
        Dim strEditTime                     As String           '更新日時
        Dim strEntryTime                    As String           '登録日時
        Dim strFromEmpName                  As String           '依頼元作業者名
        Dim lngEmpListCnt                   As Integer          '依頼先作業者ﾘｽﾄｶｳﾝﾄ
        Dim typEmpList                      As List(Of EmpList) '依頼先作業者ﾘｽﾄ
        Dim strFindEmpName                  As String           '発見者名
        Dim strFindDeptName                 As String           '発見職場名
        Dim strWpID                         As String           '装置ID
        Dim strWpName                       As String           '装置名
        Dim strPreserveEmpID                As String           '保全実施者ID
        Dim strPreserveEmpName              As String           '保全実施者名
        Dim strRepairStartDate              As String           '故障発生日時
        Dim strRepairEndDate                As String           '修理完了日時
        Dim strRepairName                   As String           '故障現象名
        Dim strRepairNameSignEmpID          As String           '故障現象ｻｲﾝ者ID
        Dim strRepairNameSignEmpName        As String           '故障現象ｻｲﾝ者氏名
        Dim strRepairNameSignDate           As String           '故障現象ｻｲﾝ日
        Dim strRepairContents               As String           '故障現象詳細
        Dim strRepairCauseContents          As String           '原因詳細
        Dim strRepairCauseSignEmpID         As String           '故障原因ｻｲﾝ者ID
        Dim strRepairCauseSignEmpName       As String           '故障原因ｻｲﾝ者氏名
        Dim strRepairCauseSignDate          As String           '故障原因ｻｲﾝ日
        Dim strRepairAnalysisContents       As String           '調査/分析詳細
        Dim strRepairAnalysisSignEmpID      As String           '故障原因調査/分析ｻｲﾝ者ID
        Dim strRepairAnalysisSignEmpName    As String           '故障原因調査/分析ｻｲﾝ者氏名
        Dim strRepairAnalysisSignDate       As String           '故障原因調査/分析ｻｲﾝ日
        Dim strRepairMeasureContents        As String           '対策詳細
        Dim strRepairMeasureSignEmpID       As String           '故障対策ｻｲﾝ者ID
        Dim strRepairMeasureSignEmpName     As String           '故障対策ｻｲﾝ者氏名
        Dim strRepairMeasureSignDate        As String           '故障対策ｻｲﾝ日
        Dim strPreserveSignEmpID            As String           '保全担当ｻｲﾝ者ID
        Dim strPreserveSignEmpName          As String           '保全担当ｻｲﾝ者氏名
        Dim strPreserveSignDate             As String           '保全担当ｻｲﾝ日
        Dim strPreserveLeaderSignEmpID      As String           '保全ﾘｰﾀﾞｰｻｲﾝ者ID
        Dim strPreserveLeaderSignEmpName    As String           '保全ﾘｰﾀﾞｰｻｲﾝ者氏名
        Dim strPreserveLeaderSignDate       As String           '保全ﾘｰﾀﾞｰｻｲﾝ日
        Dim strProductLeaderSignEmpID       As String           '作業長ｻｲﾝ者ID
        Dim strProductLeaderSignEmpName     As String           '作業長ｻｲﾝ者氏名
        Dim strProductLeaderSignDate        As String           '作業長ｻｲﾝ日
        Dim strEntryClass                   As String           '起票区分(0：手動起票、1：自動起票)
        Dim strApprovalEmpID                As String           '承認者ID
        Dim strApprovalEmpName              As String           '承認者名
        Dim strStopTime                     As String           '停止時間
        Dim strRepairStatus                 As String           '故障修理記録票状態(0：未処置、1：処置済、2：承認済、3：無効)
        Dim strCopeDivision                 As String           '対応区分(1:自主保全、2:ﾒｰｶｰ保全)
        Dim strPartCost                     As String           '部品費用
        Dim strWorkCost                     As String           '作業費用
    End Structure

    '@故障修理記録票情報登録/更新(rep_.chgrepairinfo)要求
    Public Structure RepairInfo
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           '処理区分
        Dim strWpID                         As String           '装置ID
        Dim strWpName                       As String           '装置名
        Dim strOldUseID                     As String           '変更前装置状態ID
        Dim strUseId                        As String           '変更後装置状態ID
        Dim strActionID                     As String           'ｱｸｼｮﾝID格納用
        Dim strRepairNo                     As String           '故障修理記録№
        Dim strRepairStartDate              As String           '故障発生日時
        Dim strRepairEndDate                As String           '修理完了日時
        Dim strPreserveEmpID                As String           '保全実施者ID
        Dim strPreserveEmpName              As String           '保全実施者名
        Dim strRepairName                   As String           '故障現象名
        Dim strRepairNameSignEmpID          As String           '故障現象ｻｲﾝ者ID
        Dim strRepairNameSignEmpName        As String           '故障現象ｻｲﾝ者氏名
        Dim strRepairNameSignDate           As String           '故障現象ｻｲﾝ日
        Dim strRepairContents               As String           '故障現象詳細
        Dim strRepairCauseContents          As String           '原因詳細
        Dim strRepairCauseSignEmpID         As String           '故障原因ｻｲﾝ者ID
        Dim strRepairCauseSignEmpName       As String           '故障原因ｻｲﾝ者氏名
        Dim strRepairCauseSignDate          As String           '故障原因ｻｲﾝ日
        Dim strRepairAnalysisContents       As String           '調査/分析詳細
        Dim strRepairAnalysisSignEmpID      As String           '故障原因調査/分析ｻｲﾝ者ID
        Dim strRepairAnalysisSignEmpName    As String           '故障原因調査/分析ｻｲﾝ者氏名
        Dim strRepairAnalysisSignDate       As String           '故障原因調査/分析ｻｲﾝ日
        Dim strRepairMeasureContents        As String           '対策詳細
        Dim strRepairMeasureSignEmpID       As String           '故障対策ｻｲﾝ者ID
        Dim strRepairMeasureSignEmpName     As String           '故障対策ｻｲﾝ者氏名
        Dim strRepairMeasureSignDate        As String           '故障対策ｻｲﾝ日
        Dim strPreserveSignEmpID            As String           '保全担当ｻｲﾝ者ID
        Dim strPreserveSignEmpName          As String           '保全担当ｻｲﾝ者氏名
        Dim strPreserveSignDate             As String           '保全担当ｻｲﾝ日
        Dim strPreserveLeaderSignEmpID      As String           '保全ﾘｰﾀﾞｰｻｲﾝ者ID
        Dim strPreserveLeaderSignEmpName    As String           '保全ﾘｰﾀﾞｰｻｲﾝ者氏名
        Dim strPreserveLeaderSignDate       As String           '保全ﾘｰﾀﾞｰｻｲﾝ日
        Dim strProductLeaderSignEmpID       As String           '作業長ｻｲﾝ者ID
        Dim strProductLeaderSignEmpName     As String           '作業長ｻｲﾝ者氏名
        Dim strProductLeaderSignDate        As String           '作業長ｻｲﾝ日
        Dim strEntryClass                   As String           '起票区分(0：手動起票、1：自動起票)
        Dim strRepairStatus                 As String           '状態
        Dim strApprovalEmpID                As String           '承認者ID
        Dim strApprovalEmpName              As String           '承認者名
        Dim strEmpID                        As String           '作業者ID
        Dim strEmpName                      As String           '作業者名
        Dim strEntryTime                    As String           '登録日時
        Dim strEditTime                     As String           '更新日時
        Dim strCopeDivision                 As String           '対応区分(1:自主保全、2:ﾒｰｶｰ保全)
        Dim strPartCost                     As String           '部品費用
        Dim strWorkCost                     As String           '作業費用
    End Structure

    '@故障修理記録票一覧への引継ぎ用情報格納構造体
    Public Structure RepairConnectInfo
        Dim strSbID                         As String           '処理区分
        Dim strMcGroupID                    As String           '装置ｸﾞﾙｰﾌﾟID
        Dim strMcGroupName                  As String           '装置ｸﾞﾙｰﾌﾟ名
        Dim strWpID                         As String           '装置ID()
        Dim strWpName                       As String           '装置名()
        Dim typWpList                       As List(Of WP)      '装置ﾘｽﾄ
        Dim lngWPCnt                        As Integer          '装置ﾘｽﾄｶｳﾝﾄ
        Dim strSearchFromDate               As String           '検索開始日時
        Dim strSearchToDate                 As String           '検索終了日時
        Dim strRepairNo                     As String           '故障記録票№
        Dim strRepairName                   As String           '故障現象名
        Dim strRepairContents               As String           '故障現象詳細
        Dim strEditTime                     As String           '更新日時
    End Structure

    '@保全記録票一覧取得(pre_.preservelist)要求
    Public Structure PreserveInfoReq
        Dim strMsgVer                       As String                 'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String                 'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strWpID                         As String                 '装置ID
        Dim strWpName                       As String                 '装置名(ErrMsg用)
        Dim typWpList                       As List(Of WP)            '装置ﾘｽﾄ
        Dim lngWPCnt                        As Integer                '装置ﾘｽﾄｶｳﾝﾄ
        Dim strCategoryID                   As String                 'ｶﾃｺﾞﾘID
        Dim strCategoryName                 As String                 'ｶﾃｺﾞﾘ名(ErrMsg用)
        Dim typCategoryList                 As List(Of MasCategoryId) 'ｶﾃｺﾞﾘﾘｽﾄ
        Dim lngCategoryCnt                  As Integer                'ｶﾃｺﾞﾘﾘｽﾄｶｳﾝﾄ
        Dim strStartDate                    As String                 '検索開始日
        Dim strEndDate                      As String                 '検索終了日
        Dim strPreserveNo                   As String                 '保全記録№
        Dim strEntryTime                    As String                 '登録日時
    End Structure

    '@保全記録票情報(一覧)取得(pre_.preservelist, pre_.preserveinfo)応答
    Public Structure PreserveInfoAns
        Dim strPreserveStatus               As String           '保全記録票状態(0：未処置、1：処置済、2：承認済、3：無効)
        Dim strPreserveNo                   As String           '保全記録№
        Dim strWpID                         As String           '装置ID
        Dim strWpName                       As String           '装置名
        Dim strCategoryID                   As String           'ｶﾃｺﾞﾘID
        Dim strCategoryName                 As String           'ｶﾃｺﾞﾘ名
        Dim strPreserveCategory             As String           '保全ｶﾃｺﾞﾘ
        Dim strPreserveStartDate            As String           '保全開始(予定)日時
        Dim strPreserveEndDate              As String           '保全終了(予定)日時
        Dim strEmpName                      As String           '作業者名(更新者名)
        Dim strEditTime                     As String           '更新日時
        Dim strEntryTime                    As String           '登録日時
        Dim strFromEmpName                  As String           '依頼元作業者名
        Dim lngEmpListCnt                   As Integer          '依頼先作業者ﾘｽﾄｶｳﾝﾄ
        Dim typEmpList                      As List(Of EmpList) '依頼先作業者ﾘｽﾄ
        Dim strPreserveEmpID                As String           '保全実施者ID
        Dim strPreserveEmpName              As String           '保全実施者名
        Dim strPreserveComments             As String           'ｺﾒﾝﾄ
        Dim strPreserveItem                 As String           '実施項目
        Dim strPreserveContents             As String           '実施内容
        Dim strPreservePurpose              As String           '実施理由/目的
        Dim strPreserveSignEmpID            As String           '保全担当ｻｲﾝ者ID
        Dim strPreserveSignEmpName          As String           '保全担当ｻｲﾝ者氏名
        Dim strPreserveSignDate             As String           '保全担当ｻｲﾝ日
        Dim strPreserveLeaderSignEmpID      As String           '保全ﾘｰﾀﾞｰｻｲﾝ者ID
        Dim strPreserveLeaderSignEmpName    As String           '保全ﾘｰﾀﾞｰｻｲﾝ者氏名
        Dim strPreserveLeaderSignDate       As String           '保全ﾘｰﾀﾞｰｻｲﾝ日
        Dim strProductLeaderSignEmpID       As String           '作業長ｻｲﾝ者ID
        Dim strProductLeaderSignEmpName     As String           '作業長ｻｲﾝ者氏名
        Dim strProductLeaderSignDate        As String           '作業長ｻｲﾝ日
        Dim strEntryClass                   As String           '起票区分(0：手動起票、1：自動起票)
        Dim strApprovalEmpID                As String           '承認者ID
        Dim strApprovalEmpName              As String           '承認者名
        Dim strStopTime                     As String           '停止時間
        Dim strCopeDivision                 As String           '対応区分(1:自主保全、2:ﾒｰｶｰ保全)
        Dim strPartCost                     As String           '部品費用
        Dim strWorkCost                     As String           '作業費用
    End Structure

    '@保全記録票情報登録/更新(rep_.chgpreserveinfo)要求
    Public Structure PreserveInfo
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           '処理区分
        Dim strWpID                         As String           '装置ID
        Dim strWpName                       As String           '装置名
        Dim strCategoryID                   As String           'ｶﾃｺﾞﾘID
        Dim strCategoryName                 As String           'ｶﾃｺﾞﾘ名
        Dim strPreserveCategory             As String           '保全ｶﾃｺﾞﾘ
        Dim strOldUseID                     As String           '変更前装置状態ID
        Dim strUseId                        As String           '変更後装置状態ID
        Dim strActionID                     As String           'ｱｸｼｮﾝID格納用
        Dim strPreserveNo                   As String           '保全記録№
        Dim strPreserveStartDate            As String           '保全開始(予定)日時
        Dim strPreserveEndDate              As String           '保全終了(予定)日時
        Dim strPreserveEmpID                As String           '保全実施者ID
        Dim strPreserveEmpName              As String           '保全実施者名
        Dim strPreserveComments             As String           'ｺﾒﾝﾄ
        Dim strPreserveItem                 As String           '実施項目
        Dim strPreserveContents             As String           '実施内容
        Dim strPreservePurpose              As String           '実施理由/目的
        Dim strPreserveSignEmpID            As String           '保全担当ｻｲﾝ者ID
        Dim strPreserveSignEmpName          As String           '保全担当ｻｲﾝ者氏名
        Dim strPreserveSignDate             As String           '保全担当ｻｲﾝ日
        Dim strPreserveLeaderSignEmpID      As String           '保全ﾘｰﾀﾞｰｻｲﾝ者ID
        Dim strPreserveLeaderSignEmpName    As String           '保全ﾘｰﾀﾞｰｻｲﾝ者氏名
        Dim strPreserveLeaderSignDate       As String           '保全ﾘｰﾀﾞｰｻｲﾝ日
        Dim strProductLeaderSignEmpID       As String           '作業長ｻｲﾝ者ID
        Dim strProductLeaderSignEmpName     As String           '作業長ｻｲﾝ者氏名
        Dim strProductLeaderSignDate        As String           '作業長ｻｲﾝ日
        Dim strEntryClass                   As String           '起票区分(0：手動起票、1：自動起票)
        Dim strPreserveStatus               As String           '保全記録票状態(0：未処置、1：処置済、2：承認済、3：無効)
        Dim strApprovalEmpID                As String           '承認者ID
        Dim strApprovalEmpName              As String           '承認者名
        Dim strEmpID                        As String           '作業者ID
        Dim strEmpName                      As String           '作業者名
        Dim strEntryTime                    As String           '登録日時
        Dim strEditTime                     As String           '更新日時
        Dim strCopeDivision                 As String           '対応区分(1:自主保全、2:ﾒｰｶｰ保全)
        Dim strPartCost                     As String           '部品費用
        Dim strWorkCost                     As String           '作業費用
    End Structure

    '@保全記録票一覧への引継ぎ用情報格納構造体
    Public Structure PreserveConnectInfo
        Dim strSbID                         As String                 '処理区分
        Dim strMcGroupID                    As String                 '装置ｸﾞﾙｰﾌﾟID
        Dim strMcGroupName                  As String                 '装置ｸﾞﾙｰﾌﾟ名
        Dim strWpID                         As String                 '装置ID
        Dim strWpName                       As String                 '装置名
        Dim typWpList                       As List(Of WP)            '装置ﾘｽﾄ
        Dim lngWPCnt                        As Integer                '装置ﾘｽﾄｶｳﾝﾄ
        Dim strCategoryID                   As String                 'ｶﾃｺﾞﾘID
        Dim strCategoryName                 As String                 'ｶﾃｺﾞﾘ名
        Dim strPreserveCategory             As String                 '保全ｶﾃｺﾞﾘ
        Dim typCategoryList                 As List(Of MasCategoryId) 'ｶﾃｺﾞﾘﾘｽﾄ
        Dim lngCategoryCnt                  As Integer                'ｶﾃｺﾞﾘﾘｽﾄｶｳﾝﾄ
        Dim strSearchFromDate               As String                 '検索開始日時
        Dim strSearchToDate                 As String                 '検索終了日時
        Dim strEditTime                     As String                 '更新日時
        Dim strEntryTime                    As String                 '登録日時
        Dim strPreserveNo                   As String                 '保全記録票№
    End Structure

    '@ﾛｯﾄ送品構造体(lot_.send____要求)
    Public Structure LotSendReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strEmpID                        As String           '作業者ID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strSendSBID                     As String           '送品先
        Dim strSBSystemFlag                 As String           'SBｼｽﾃﾑﾌﾗｸﾞ
        Dim strLotLastUpdate                As String           'LOT最終更新日時
        Dim strBoxNo                        As String           '箱№
    End Structure

    '@流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ状態変更(lot_.chgtrvprohibit 要求)
    Public Structure LotChgtrvprohibitReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strEmpID                        As String           '作業者ID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strVerUpProhibitedFlag          As String           '1:禁止、0:解除
        Dim strLotLastUpdate                As String           'LOT最終更新日時
    End Structure


    '@DEFIN情報取得(mas_.definelist 要求)
    Public Structure MasDefineReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strTableName                    As String           'ﾃｰﾌﾞﾙ名
        Dim strColumnName                   As String           'ｶﾗﾑ名
    End Structure

    '@DEFIN情報取得(mas_.definelist 要求)
    Public Structure MasDefineList
        Dim strId                           As String           'ID
        Dim strName                         As String           'ID名
    End Structure
    Public Structure MasDefineAns
        Dim lngMasDefineListCnt             As Integer                'ﾘｽﾄｶｳﾝﾄ
        Dim typMasDefineList                As List(Of MasDefineList) 'DEFIN情報
    End Structure

    '@ｵﾌﾗｲﾝFTPﾃﾞｰﾀ同期登録(eqft.syncregist 要求)
    Public Structure EqftWfList
        Dim strWfId                         As String           'WFID
        Dim strSlotNo                       As String           'ｽﾛｯﾄ№
    End Structure

    Public Structure EqftSyncregistReq
        Dim strMsgVer                       As String              'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strWpID                         As String              '装置ID
        Dim strSbID                         As String              'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strCarrierId                    As String              'ｷｬﾘｱID
        Dim strLotID                        As String              'ﾛｯﾄID
        Dim strWorkStartTime                As String              '処理開始時刻
        Dim lngEqftWfListCnt                As Integer             'WFﾘｽﾄｶｳﾝﾄ
        Dim typEqftWfList                   As List(Of EqftWfList) 'WFﾘｽﾄ
    End Structure

    '@F/Bﾃﾞｰﾀ登録(ﾚｼﾋﾟ一覧検索)引継ぎ構造体
    Public Structure RecipeInfo
        Dim strSearchRecipeID               As String               '検索ﾚｼﾋﾟ文字
        Dim strResultRecipeID               As String               '検索結果ﾚｼﾋﾟ
        Dim typMasRecipeNameList            As MasRecipeNameList    'ﾚｼﾋﾟ情報格納構造体
    End Structure

    '@ﾌｫﾄF/Bﾃﾞｰﾀ取得(露光ﾊﾟﾗﾒｰﾀ)(eq__.photofbdatalist2 要求)
    Public Structure PhotoFbDataList2Req
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'SBID
        Dim strWpID                         As String           '装置ID
        Dim strRecipeId                     As String           'ﾚｼﾋﾟID
    End Structure

    '@ﾌｫﾄF/Bﾃﾞｰﾀ取得(露光ﾊﾟﾗﾒｰﾀ)
    Public Structure FbDataItemList2
        Dim strExposureValue                As String           'F/Bﾊﾟﾗﾒｰﾀ(EXPOSURE)計算値
        Dim strExposureLowerLimitValue      As String           'F/Bﾊﾟﾗﾒｰﾀ(EXPOSURE_LOWER_LIMIT)計算値
        Dim strExposureUpperLimitValue      As String           'F/Bﾊﾟﾗﾒｰﾀ(EXPOSURE_UPPER_LIMIT)計算値
        Dim strFocusOffsetValue             As String           'F/Bﾊﾟﾗﾒｰﾀ(FOCUSOFFSET)計算値
        Dim strEmpName                      As String           '最終更新者
        Dim strEntryTime                    As String           '最終更新日時
        Dim strComments                     As String           'ｺﾒﾝﾄ
    End Structure

    '@ﾌｫﾄF/Bﾃﾞｰﾀ取得(露光ﾊﾟﾗﾒｰﾀ)(eq__.photofbdatalist2 応答)
    Public Structure PhotoFbDataList2Ans
        Dim lngFbDataItemList2Cnt           As Integer                  'FBｱｲﾃﾑﾘｽﾄｶｳﾝﾄ
        Dim typFbDataItemList2              As List(Of FbDataItemList2) 'FBｱｲﾃﾑﾘｽﾄ
        Dim strExposureItemName             As String                   'EXPOSURE　F/Bﾊﾟﾗﾒｰﾀ名
        Dim strExposureValidDigit           As String                   '小数点以下の有効桁数
        Dim strExposureUnit                 As String                   '単位
        Dim strExposureLowerLimitItemName   As String                   'EXPOSURE_LOWER_LIMIT　F/Bﾊﾟﾗﾒｰﾀ名
        Dim strExposureLowerLimitValidDigit As String                   '小数点以下の有効桁数
        Dim strExposureLowerLimitUnit       As String                   '単位
        Dim strExposureUpperLimitItemName   As String                   'EXPOSURE_UPPER_LIMIT_VALUE F/Bﾊﾟﾗﾒｰﾀ名
        Dim strExposureUpperLimitValidDigit As String                   '小数点以下の有効桁数
        Dim strExposureUpperLimitUnit       As String                   '単位
        Dim strFocusOffsetItemName          As String                   'FOCUSOFFSET　F/Bﾊﾟﾗﾒｰﾀ名
        Dim strFocusOffsetValidDigit        As String                   '小数点以下の有効桁数
        Dim strFocusOffsetUnit              As String                   '単位
    End Structure

    '@ﾌｫﾄF/Bﾃﾞｰﾀ変更(露光ﾊﾟﾗﾒｰﾀ)(eq__.photofbdatachg2 要求)
    Public Structure PhotoFbDataChg2Req
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'SBID
        Dim strWpID                         As String           '装置ID
        Dim strRecipeId                     As String           'ﾚｼﾋﾟID
        Dim strExposureValue                As String           'F/Bﾊﾟﾗﾒｰﾀ(EXPOSURE)計算値
        Dim strExposureLowerLimitValue      As String           'F/Bﾊﾟﾗﾒｰﾀ(EXPOSURE_LOWER_LIMIT)計算値
        Dim strExposureUpperLimitValue      As String           'F/Bﾊﾟﾗﾒｰﾀ(EXPOSURE_UPPER_LIMIT)計算値
        Dim strFocusOffsetValue             As String           'F/Bﾊﾟﾗﾒｰﾀ(FOCUSOFFSET)計算値
        Dim strEmpID                        As String           '作業者ID
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strEntryTime                    As String           '最新の更新日時(排他制御)
    End Structure

    '@ﾛｯﾄ情報取得(lot_.attribute)
    Public Structure LotAttribute
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           '処理区分
        Dim strReqLotID                     As String           'ﾛｯﾄID
        Dim strReqCarrierID                 As String           'ｷｬﾘｱID
        Dim strOrderNum                     As String           'ATLASｵｰﾀﾞｰ№
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strPdId                         As String           '機種ID
        Dim strFlowClass                    As String           '流動区分
        Dim strGrbClass                     As String           'GRB区分
        Dim strNowST                        As String           'LOT状態
        Dim strStartTime                    As String           '作業開始時刻(実績)
        Dim strDispatchStartTime            As String           '作業開始予定時刻
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strLimitTime                    As String           '制限時間(時間制約)
        Dim strWarnTime                     As String           '警告時間
        Dim strRestrictTypeID               As String           '制限ﾀｲﾌﾟ(1;制限時間以下、2;制限時間以上、3;処理制限時間)
        Dim strEntryID                      As String           'ｴﾝﾄﾘID
        Dim strEntryName                    As String           'ｴﾝﾄﾘ名
        Dim strSpecialFlag                  As String           '特殊特性
        Dim strWfNum                        As String           'WF枚数
        Dim strMaxWFCount                   As String           '最大WF枚数
        Dim strChipQuantity                 As String           '良品ﾁｯﾌﾟ数
        Dim strEngEmpId                     As String           '技術担当者ID
        Dim strEngEmpName                   As String           '技術担当者名
        Dim strPlanThrowinDate              As String           '投入予定日
        Dim strLotPriority                  As String           '優先度ID
        Dim strLotPriorityName              As String           '優先度名
        Dim strPROrderID                    As String           'P/RｵｰﾀﾞｰID
        Dim strLotSendFlag                  As String           '送品ﾌﾗｸﾞ(0:送品なし、1:送品あり)
        Dim strSendSBID                     As String           '送品先ID
        Dim strSendSBName                   As String           '送品先名(和名)
        Dim strCfFlag                       As String           'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strLpFlag                       As String           'LPﾌﾗｸﾞ(0：ODFﾛｯﾄ以外、1：ODFﾛｯﾄ)
        Dim strDivideFlag                   As String           '分割ﾌﾗｸﾞ(0:親、1:子)
        Dim strPlanShipDate                 As String           '送品予定日
        Dim strUseId                        As String           '製品区分
        Dim strLotLastUpdate                As String           'LOT最終更新日時
        Dim strFirstPhotoWpID               As String           '1stﾌｫﾄWpID
        Dim strFirstPhotoWpName             As String           '1stﾌｫﾄ和名
        Dim strPlanAssThrowinDate           As String           '組立投入予定日
        Dim strSecPriorityFlag              As String           '区間優先設定ﾌﾗｸﾞ
        Dim strAtlasFlowNumber              As String           'ATLASﾌﾛｰﾅﾝﾊﾞｰ
        Dim strScreenSizeID                 As String           '画面ｻｲｽﾞ
        Dim strCfScreenSizeID               As String           'CF画面ｻｲｽﾞ
    End Structure

    '@ﾛｯﾄ情報変更・削除(lot_.chgattribute)
    Public Structure LotchgAttribute
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           '処理区分
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strPlanThrowinQuantity          As String           '投入予定数量
        Dim strPlanThrowinDate              As String           '投入予定日
        Dim strLotPriority                  As String           '優先度ID
        Dim strEngEmpId                     As String           '技術担当者ID
        Dim strPROrderID                    As String           'P/RｵｰﾀﾞｰID
        Dim strLotSendFlag                  As String           '送品ﾌﾗｸﾞ(0:送品なし、1:送品あり)
        Dim strSendSBID                     As String           '送品先ID
        Dim strPlanShipDate                 As String           '送品予定日
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strEmpID                        As String           '作業者ID
        Dim strLotLastUpdate                As String           'LOT最終更新日時
        Dim strFirstPhotoWpID               As String           '1stﾌｫﾄWpID
        Dim strPlanAssThrowinDate           As String           '組立投入予定日
    End Structure

    '@ﾛｯﾄ情報変更(複数)ﾘｽﾄ
    Public Structure LotchgAttrList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strLotPlanFinishDate            As String           '完成予定日
        Dim strLotPlanShipDate              As String           '送品予定日
        Dim strLotPlanAssThrowDate          As String           '組立投入予定日
        Dim strLotPriority                  As String           '優先度
    End Structure

    '@ﾛｯﾄ情報変更(複数)(lot_.chgattributes)
    Public Structure LotchgAttributes
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           '処理区分
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strEmpID                        As String           '作業者ID
        Dim strInventoryFlag                As String           '在庫フラグ
        Dim typChgAttrList                  As List(Of LotchgAttrList)
    End Structure

    '@投入予定ﾛｯﾄ削除(lot_.cancelplan)
    Public Structure LotCancelPlan
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           '処理区分
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strEmpID                        As String           '作業者ID
        Dim strLotLastUpdate                As String           'LOT最終更新日時
    End Structure

    '@量産計画ﾘﾘｰｽ取消(atls.cancelauth)
    Public Structure AtlsCancelAuth
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           '処理区分
        Dim strOrderNum                     As String           'ｵｰﾀﾞ№
    End Structure

    '@代替ﾙｰﾄ(ﾘﾜｰｸ/追加流動)一覧取得(mas_.altroutelist)要求
    Public Structure MasAltRouteListReq
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strFlowType                     As String           '区分(1:ﾘﾜｰｸ/4:追加流動)
        Dim strRouteID                      As String           'ﾙｰﾄID
    End Structure

    '@代替ﾙｰﾄ(ﾘﾜｰｸ/追加流動)一覧取得(mas_.altroutelist)応答
    Public Structure AltRouteList
        Dim strRouteID                      As String           'ﾙｰﾄID
        Dim strComments                     As String           'ｺﾒﾝﾄ
    End Structure
    Public Structure MasAltRouteListAns
        Dim lngAltRouteListCnt              As Integer               '代替ﾙｰﾄﾘｽﾄｶｳﾝﾄ
        Dim typAltRouteList                 As List(Of AltRouteList) '代替ﾙｰﾄﾘｽﾄ
    End Structure

    '@汎用ﾛｯﾄﾘｽﾄ(各種Msg)
    Public Structure LotIdList
        Dim strLotID                        As String           'ﾛｯﾄID
    End Structure

    '@流動済工程情報取得　戻り小工程ﾘｽﾄ(mnt_.opsteplist)
    Public Structure RollBackStepList
        Dim strStepID                       As String           '小工程ID
    End Structure

    '@流動済工程情報取得　戻り大工程ﾘｽﾄ(mnt_.opsteplist)
    Public Structure RollBackOpList
        Dim strOpID                         As String                    '大工程ID
        Dim lngStepListCnt                  As Integer                   '小工程ﾘｽﾄｶｳﾝﾄ
        Dim typStepList                     As List(Of RollBackStepList) '小工程ﾘｽﾄ
    End Structure

    '@流動済工程情報取得　戻り大工程/小工程構造体(mnt_.opsteplist)
    Public Structure OpStepList
        Dim lngOpListCnt                    As Integer                 '大工程ﾘｽﾄｶｳﾝﾄ
        Dim typOpList                       As List(Of RollBackOpList) '大工程ﾘｽﾄ
    End Structure

    '@ｲﾍﾞﾝﾄ履歴取得/削除要求用構造体(mnt_.eventhist,mnt_.delhist)
    Public Structure ReqEventInfo
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strEmpID                        As String           '作業者ID
        Dim strComments                     As String           '作業ﾒﾓ
        Dim strLotLastUpdate                As String           '最終更新日時
    End Structure

    '@ｲﾍﾞﾝﾄ履歴取得応答用構造体　ｲﾍﾞﾝﾄ履歴ﾘｽﾄ(mnt_.eventhist)
    Public Structure EventList
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strLotEventId                   As String           'ﾛｯﾄｲﾍﾞﾝﾄID
        Dim strLotEventName                 As String           'ﾛｯﾄｲﾍﾞﾝﾄ名
        Dim strEntryTime                    As String           '登録日時
        Dim strEmpID                        As String           '作業者ID
        Dim strEmpName                      As String           '作業者名
        Dim strComments                     As String           '作業ﾒﾓ
        Dim strDeleteProhibited             As String           '削除可否判定ﾌﾗｸﾞ(0:削除可、1:削除不可)
    End Structure

    '@ｲﾍﾞﾝﾄ履歴取得応答用構造体(mnt_.eventhist)
    Public Structure AnsEventInfo
        Dim strSbID                         As String             'ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strLotID                        As String             'ﾛｯﾄID
        Dim strLotLastUpdate                As String             '最終更新日時
        Dim lngEventListCnt                 As Integer            'ｲﾍﾞﾝﾄ履歴ﾘｽﾄｶｳﾝﾄ
        Dim typEventList                    As List(Of EventList) 'ｲﾍﾞﾝﾄ履歴ﾘｽﾄ
    End Structure

    '@ﾛｯﾄ一覧取得要求用定義(lot_.list____)
    Public Structure LotListReq
        Dim strMsgVer                       As String           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strClassDivision                As String           '処理区分
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strWpID                         As String           '装置ID
    End Structure

    '@ﾛｯﾄ一覧取得応答用WFﾘｽﾄ定義(lot_.list____)
    Public Structure LotListWfList
        Dim strWfId                         As String           'ｳｪﾊID
    End Structure

    '@ﾛｯﾄ一覧取得応答用LOTﾘｽﾄ定義(lot_.list____)
    Public Structure LotListLotList
        Dim strLotID                        As String                 'ﾛｯﾄID
        Dim strFlowClass                    As String                 '流動区分
        Dim strOpID                         As String                 '大工程ID
        Dim strStepID                       As String                 '小工程ID
        Dim strAltNumber                    As String                 '代替番号
        Dim strNowST                        As String                 'LOT状態
        Dim strDispatchStartTime            As String                 '投入予定時刻
        Dim strDispatchEndTime              As String                 '終了予定時刻
        Dim strEngEmpName                   As String                 '技術担当者名
        Dim strWfNum                        As String                 'WF枚数
        Dim strChipQuantity                 As String                 'ﾁｯﾌﾟ数
        Dim strLotCommentsFlg               As String                 'ﾛｯﾄｺﾒﾝﾄ有無ﾌﾗｸﾞ
        Dim strLotHoldFlag                  As String                 'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strLotStopFlag                  As String                 'ﾛｯﾄ停止ﾌﾗｸﾞ
        Dim strReworkFlag                   As String                 'ﾘﾜｰｸﾌﾗｸﾞ(0:ﾘﾜｰｸなし/1:ﾘﾜｰｸ/2:追加流動)
        Dim strLotPriority                  As String                 '優先度
        Dim strRecipeId                     As String                 'ﾚｼﾋﾟID
        Dim strLcDirection                  As String                 '液晶方向
        Dim strLotLastUpdate                As String                 'ﾛｯﾄ最終更新日付
        Dim strSeqNum                       As String                 '処理順番号
        Dim strCommitFlag                   As String                 '号機指定(1：指定　0：指定なし)
        Dim strWfPartialRecipeFlag          As String                 '部分ﾚｼﾋﾟﾌﾗｸﾞ
        Dim strRestrictTypeID               As String                 '制限ﾀｲﾌﾟ
        Dim strLimitTime                    As String                 '制限時間(時間制約)
        Dim strWarnTime                     As String                 '警告時間
        Dim strToOpId                       As String                 '制限時間先大工程
        Dim strToStepId                     As String                 '制限時間先小工程
        Dim strTimeRestrictStartHold        As String                 '時間制限開始待ち保留
        Dim strCarrierId                    As String                 'ｷｬﾘｱID
        Dim strCurrentPositionID            As String                 'ﾛｯﾄ位置
        Dim strCurrentPositionName          As String                 'ﾛｯﾄ位置(和名)
        Dim strToCarrierId                  As String                 'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
        Dim strCarrierStatID                As String                 'ｷｬﾘｱ状態ID
        Dim strCarrierStatName              As String                 'ｷｬﾘｱ状態名
        Dim strDestPositionID               As String                 'ｷｬﾘｱ目的位置ID(搬送先)
        Dim strDestName                     As String                 'ｷｬﾘｱ目的位置名(搬送先)
        Dim strSendSBID                     As String                 '送品先
        Dim strPdId                         As String                 '機種
        Dim strPdVersion                    As String                 '機種Ver
        Dim strJBatchId                     As String                 '蒸着ﾊﾞｯﾁID
        Dim strHBatchId                     As String                 '表面ﾊﾞｯﾁID
        Dim strCfFlag                       As String                 'CFﾌﾗｸﾞ(0：TFT、1：CF、2：TPAL)
        Dim strLpFlag                       As String                 'LPﾌﾗｸﾞ(0：ODFﾛｯﾄ以外、1：ODFﾛｯﾄ)
        Dim strVaFlag                       As String                 '無機ﾌﾗｸﾞ
        Dim strTpalClass                    As String                 'TPAL区分
        Dim strSbArea                       As String                 'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        Dim strAvailableRecipeFlag          As String                 '処理可能ﾚｼﾋﾟﾌﾗｸﾞ(0：処理可能ﾚｼﾋﾟ、1：処理不可ﾚｼﾋﾟ)
        Dim strShipDiffDay                  As String                 'ﾛｯﾄ進捗度
        Dim strFrFlag                       As String                 'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ(0:処理可能、1:処理不可)
        Dim strGrbClass                     As String                 'GRB区分
        Dim strColorCd                      As String                 '指定色
        Dim lngWfListCnt                    As Integer                'ﾛｯﾄ一覧WFﾘｽﾄ数
        Dim typWfList                       As List(Of LotListWfList) 'ﾛｯﾄ一覧WFﾘｽﾄ
    End Structure

    '@ﾛｯﾄ一覧取得応答用定義(lot_.list____)
    Public Structure LotListAns
        Dim strWpTypeFlag                   As String                  'WPﾀｲﾌﾟﾌﾗｸﾞ
        Dim strUseId                        As String                  '用途ID
        Dim strUseName                      As String                  '用途名
        Dim strMesModeId                    As String                  '運用ﾓｰﾄﾞ
        Dim strWpStopFlag                   As String                  'WP停止ﾌﾗｸﾞ
        Dim strWpStatusName                 As String                  '装置状態名
        Dim strMcType                       As String                  '装置ﾀｲﾌﾟ(Normal,Batch,Exdummy)
        Dim typLotList                      As List(Of LotListLotList) 'ﾛｯﾄﾘｽﾄ
    End Structure
    
    '@ﾛｯﾄ一覧(防湿ALD)取得応答用LOTﾘｽﾄ定義(lot_.listald_)
    Public Structure LotListLotListALD
        Dim strLotID                        As String                 'ﾛｯﾄID
        Dim strFlowClass                    As String                 '流動区分
        Dim strOpID                         As String                 '大工程ID
        Dim strStepID                       As String                 '小工程ID
        Dim strNowST                        As String                 'LOT状態
        Dim strEngEmpName                   As String                 '技術担当者名
        Dim strWfNum                        As String                 'WF枚数
        Dim strChipQuantity                 As String                 'ﾁｯﾌﾟ数
        Dim strLotCommentsFlg               As String                 'ﾛｯﾄｺﾒﾝﾄ有無ﾌﾗｸﾞ
        Dim strLotHoldFlag                  As String                 'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strLotStopFlag                  As String                 'ﾛｯﾄ停止ﾌﾗｸﾞ
        Dim strLotPriority                  As String                 '優先度
        Dim strRecipeId                     As String                 'ﾚｼﾋﾟID
        Dim strLcDirection                  As String                 '液晶方向
        Dim strLotLastUpdate                As String                 'ﾛｯﾄ最終更新日付
        Dim strRestrictTypeID               As String                 '制限ﾀｲﾌﾟ
        Dim strLimitTime                    As String                 '制限時間(時間制約)
        Dim strWarnTime                     As String                 '警告時間
        Dim strToOpId                       As String                 '制限時間先大工程
        Dim strToStepId                     As String                 '制限時間先小工程
        Dim strCarrierId                    As String                 'ｷｬﾘｱID
        Dim strSendSBID                     As String                 '送品先
        Dim strPdId                         As String                 '機種
        Dim strPdVersion                    As String                 '機種Ver
        Dim strVaFlag                       As String                 '無機ﾌﾗｸﾞ
        Dim strSbArea                       As String                 'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        Dim strALDProcessNum                As String                 '防湿ALD処理番号
        Dim strALDProcessName               As String                 '防湿ALD処理名
        Dim strTapeBatchId                  As String                 'ﾃｰﾌﾟﾊﾞｯﾁID
        Dim strOvenBatchId                  As String                 'ｵｰﾌﾞﾝﾊﾞｯﾁID
        Dim strAldBatchId                   As String                 'ALDﾊﾞｯﾁID
        Dim strACarrierId                   As String                 'AｷｬﾘｱID
        Dim strMonitorUseFlag               As String                 'ﾓﾆﾀｰﾌﾗｸﾞ
        Dim strBatchFlowClass               As String                 'ﾊﾞｯﾁｸﾗｽ
        Dim lngWfListCnt                    As Integer                'ﾛｯﾄ一覧WFﾘｽﾄ数
        Dim typWfList                       As List(Of LotListWfList) 'ﾛｯﾄ一覧WFﾘｽﾄ
    End Structure

    '@ﾛｯﾄ一覧(防湿ALD)取得応答用定義(lot_.listald_)
    Public Structure LotListALDAns
        Dim strWpTypeFlag                   As String                     'WPﾀｲﾌﾟﾌﾗｸﾞ
        Dim strUseId                        As String                     '用途ID
        Dim strUseName                      As String                     '用途名
        Dim strMesModeId                    As String                     '運用ﾓｰﾄﾞ
        Dim strWpStopFlag                   As String                     'WP停止ﾌﾗｸﾞ
        Dim strWpStatusName                 As String                     '装置状態名
        Dim strMcType                       As String                     '装置ﾀｲﾌﾟ(Normal,Batch,Exdummy)
        Dim strALDPorcessModeId             As String                     '防湿ALD処理ﾓｰﾄﾞID
        Dim strALDProcessName               As String                     '防湿ALD処理名
        Dim typLotList                      As List(Of LotListLotListALD) 'ﾛｯﾄﾘｽﾄ
    End Structure

    '@受入在庫ﾛｯﾄ一覧取得用要求定義(inv_.acptlotlist)
    Public Structure invAcptLotListReq
        Dim strMsgVer                       As String                 'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strClassDivision                As String                 '処理区分
        Dim strSbID                         As String                 'ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strAssemblePdId                 As String                 '組立投入機種
        Dim lngFlowClassCnt                 As Integer                '流動区分数
        Dim typFlowClassList                As List(Of FlowClassList) '流動区分ﾘｽﾄ
        Dim lngPdCnt                        As Integer                '機種数
        Dim typPdList                       As List(Of PDList)        '機種ﾘｽﾄ
    End Structure

    '@受入在庫ﾛｯﾄ一覧取得応答用LOTﾘｽﾄ定義(inv_.acptlotlist)
    Public Structure InvAcptLotListLotList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strEntryTime                    As String           '受入日時
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strPdId                         As String           '機種
        Dim strFlowClass                    As String           '流動区分
        Dim strLotPriority                  As String           '優先度
        Dim strWFQuantity                   As String           'WF枚数
        Dim strChipQuantity                 As String           'Chip枚数
        Dim strStayTime                     As String           '停滞期間
        Dim strLotHoldFlag                  As String           'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strReasonCode                   As String           '保留理由ｺｰﾄﾞ
        Dim strReasonName                   As String           '保留理由名
        Dim strLotComments                  As String           'ﾛｯﾄｺﾒﾝﾄ
        Dim strEditTime                     As String           '最終更新日時
        Dim strHoldTime                     As String           '保留発生日時
        Dim strHoldStayDate                 As String           '保留期間
        Dim strHoldTermDate                 As String           '保留期限
        Dim strHoldEmpID                    As String           '保留担当者ID
        Dim strHoldEmpName                  As String           '保留担当者名
        Dim strEngEmpId                     As String           '技術担当者ID
        Dim strEngEmpName                   As String           '技術担当者名
        Dim strInvComments                  As String           'SB連絡ｺﾒﾝﾄ
        Dim strToCarrierID1                 As String           '分割/移載先ｷｬﾘｱID1
        Dim strToCarrierID2                 As String           '分割/移載先ｷｬﾘｱID2
        Dim strSendSBID                     As String           '送品先ｼｽﾃﾑﾌﾞﾛｯｸID
        Dim strSendSBName                   As String           '送品先ｼｽﾃﾑﾌﾞﾛｯｸ名
        Dim strLostChipInfo                 As String           '欠損ﾁｯﾌﾟ情報
        Dim strDivideStatus                 As String           '分割予約状態(0:未分割-移載/1:分割-移載中/2:分割-移載済)
        Dim strWfCarryFlag                  As String           'WF移載ﾌﾗｸﾞ
        Dim strSlotSize                     As String           'ｽﾛｯﾄｻｲｽﾞ
        Dim strSbArea                       As String           'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        Dim strGrbClass                     As String           'GRB区分
    End Structure

    '@受入在庫ﾛｯﾄ一覧取得応答用LOTﾘｽﾄ定義(inv_.acptlotlist)
    Public Structure InvAcptLotListAns
        Dim typLotList                      As List(Of InvAcptLotListLotList) 'ﾛｯﾄﾘｽﾄ
    End Structure

    '@工順変更確定時ﾙｰﾙ違反ﾘｽﾄ取得(proc.wprulechk)応答
    Public Structure RuleList
        Dim strRuleID                       As String           'ﾙｰﾙID
        Dim strRuleName                     As String           'ﾙｰﾙ名
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strJudgeMsg                     As String           '判定ｺﾒﾝﾄ
    End Structure

    '@工順変更確定時ﾙｰﾙ違反ﾘｽﾄ取得(proc.wprulechk)応答
    Public Structure RuleListAns
        Dim typRuleList                     As List(Of RuleList) 'ﾙｰﾙﾘｽﾄ
    End Structure

    '@治具ﾀｲﾌﾟﾏｽﾀｰ取得結果格納(mas_.jigfillnum)
    Public Structure JigFillNum
        Dim strPdId                         As String           '機種ID
        Dim strjigClass                     As String           '治具区分
        Dim strPanelKind                    As String           'ﾊﾟﾈﾙ種別
        Dim lngStuffCount                   As String           '詰数
    End Structure

    '@CFﾛｯﾄﾘｽﾄ(MKﾛｯﾄ編成画面情報受け渡し用List)
    Public Structure CfInvList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strLimitTime                    As String           '制限時間
        Dim strThickness                    As String           '板厚
        Dim lngReworkCnt                    As String           'ﾘﾜｰｸ数
        Dim lngQuantity                     As Integer          'ﾁｯﾌﾟ数量
        Dim strEditTime                     As String           '更新日時
    End Structure

    '@CFﾛｯﾄﾘｽﾄ(MKﾛｯﾄ編成画面情報受け渡し用)
    Public Structure CfInvInfo
        Dim strSlotNo                       As String             'ﾛｯﾄID
        Dim strjigId                        As String             '制限時間
        Dim lngStuffCount                   As Integer            '詰数
        Dim lngListCnt                      As Integer            '在庫ﾘｽﾄのｶｳﾝﾄ
        Dim typeCfInvList                   As List(Of CfInvList) '在庫ﾘｽﾄ
    End Structure

    '@MKﾛｯﾄ編成(混成List)
    Public Structure KonseiList
        Dim strLotID                        As String           '在庫ﾛｯﾄID
        Dim strBodyThickness                As String           '厚
        Dim strReworkCount                  As String           'ﾘﾜｰｸ数
        Dim strLimitTime                    As String           '制限時間
        Dim strInvCount                     As String           '在庫ﾁｯﾌﾟ数
        Dim strChipCount                    As String           'ﾁｯﾌﾟ数
        Dim strLotLastUpdate                As String           '最終更新日時
    End Structure

    '@MKﾛｯﾄ編成(混成List)
    Public Structure KonseiPartList
        Dim strSbID                         As String                 'SBID
        Dim strPdId                         As String                 '機種ID
        Dim typePartList                    As List(Of PartClassList) '部品ﾘｽﾄ
        Dim lngPartListSize                 As Integer                '部品ﾘｽﾄｻｲｽﾞ
        Dim strBodyThickness                As String                 '厚
        Dim strReworkCount                  As String                 'ﾘﾜｰｸ数
    End Structure

    '@MKﾛｯﾄ編成(JIG_MAP_LIST)
    Public Structure JigMapList
       Dim strSlotPositon                   As String              'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
       Dim strjigId                         As String              'jigID
       Dim strLotLastUpdate                 As String              '最終更新日時
       Dim strChipCount                     As String              'ﾁｯﾌﾟ数
       Dim strLotID                         As String              '在庫ﾛｯﾄID
       Dim strReworkCount                   As String              'ﾘﾜｰｸ数
       Dim strBodyThickness                 As String              '厚
       Dim typKonseiList                    As List(Of KonseiList) '混成ﾘｽﾄ
    End Structure

    '@MKﾛｯﾄ編成(lot_.mkthrowin 要求)
    Public Structure LotMkThrowin
        Dim strSbID                         As String              'SBID
        Dim strCarrierId                    As String              'ｷｬﾘｱID
        Dim strEmpID                        As String              '作業者ID
        Dim strNum                          As String              '投入数
        Dim strPdId                         As String              '機種ID
        Dim strFlowClass                    As String              '流動区分
        Dim strEntryID                      As String              'ｴﾝﾄﾘID
        Dim strMasPdVersion                 As String              '工順ﾊﾞｰｼﾞｮﾝ
        Dim typJigMapList                   As List(Of JigMapList) 'ｼﾞｸﾞﾏｯﾌﾟ
        Dim lngJigMapListCnt                As Integer             'ｼﾞｸﾞﾏｯﾌﾟｶｳﾝﾄ
        Dim strMsgVer                       As String              'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strRetrunLotID                  As String              '登録ﾛｯﾄID
        Dim strTechManID                    As String              '技術担当者ID
        Dim strWpID                         As String              '投入装置ID
    End Structure

    '@EN02C1の設定結果を格納
    Public Structure Konsei
        Dim strSlotNo                       As String              'ｽﾛｯﾄ№
        Dim strjigId                        As String              'ﾛｯﾄID
        Dim strBodyThickness                As String              '厚
        Dim strReworkCount                  As String              'ﾘﾜｰｸ数
        Dim lngKonseiListCnt                As Integer             'ﾘｽﾄ数
        Dim typKonseiList                   As List(Of KonseiList) '混成ﾛｯﾄのﾘｽﾄ
    End Structure

    '@EN02D0の設定結果を格納
    Public Structure JycJigList
        Dim strjigId                        As String           '治具ID
        Dim strjigStatus                    As String           '治具ｽﾃｰﾀｽ
        Dim strjigStatusNm                  As String           '治具ｽﾃｰﾀｽ名
        Dim strjigClass                     As String           '治具識別(蒸着/平置き)
        Dim strPanelKind                    As String           'ﾊﾟﾈﾙ識別(TFT/CF)
        Dim strCarrierCategoryId            As String           'ｷｬﾘｱｶﾃｺﾞﾘID(治具ｶﾃｺﾞﾘID)
        Dim strcarrierCategoryNm            As String           'ｷｬﾘｱｶﾃｺﾞﾘ名(治具ｶﾃｺﾞﾘ名)
        Dim strScreenSize                   As String           'ﾊﾟﾈﾙｻｲｽﾞ
        Dim strStartTime                    As String           '使用開始日時
        Dim strCleanTime                    As String           '最新洗浄日時
        Dim strUseNum                       As String           '使用回数
        Dim strUseLimit                     As String           '使用上限数
        Dim strEmpID                        As String           '作業者ID(氏名ｺｰﾄﾞ)
        Dim strEmpName                      As String           '作業者名
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strWashUseNum                   As String           '洗浄後使用回数
        Dim strWashUseLimit                 As String           '洗浄後上限回数
    End Structure

	'@EN02D0の設定結果を格納
    Public Structure JJigList
        Dim strJJigId                       As String           '治具ID
        Dim strJJigStatusId                 As String           '治具ｽﾃｰﾀｽ
        Dim strJJigStatusNm                 As String           '治具ｽﾃｰﾀｽ名
        Dim strJJigPdId						As String           '機種
        Dim strJJigCategoryId				As String           '治具ｶﾃｺﾞﾘID
        Dim strJJigCategoryNm				As String           '治具ｶﾃｺﾞﾘ名
		Dim strSetGuideId					As String           '紐付けガイドリングID
		Dim strSetMaskId					As String           '組立マスクID
		Dim strSetHolderId					As String           '紐付けホルダID
		Dim strSetEmpID						As String           '組立作業者ID(氏名ｺｰﾄﾞ)
        Dim strSetEmpName                   As String           '組立作業者名
        Dim strStartTime                    As String           '使用開始日時
        Dim strCleanTime                    As String           '最新洗浄日時
        Dim strUseNum                       As String           '累積使用回数
		Dim strUseLimit                     As String           '累積上限回数
        Dim strNextStockReadyFlag           As String           '次回在庫準備フラグ
        Dim strEmpID                        As String           '作業者ID(氏名ｺｰﾄﾞ)
        Dim strEmpName                      As String           '作業者名
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strWashUseNum                   As String           '洗浄後使用回数
        Dim strWashUseLimit                 As String           '洗浄後上限回数
		Dim strJigEventId					As String			'蒸着治具イベントID
    End Structure

    '@蒸着治具一覧取得(jig_.jyclist_)応答
    Public Structure pubtypJycJigList
        Dim llngJigListCnt          As Integer
        Dim pubJycJigList           As List(Of JycJigList)
    End Structure

    Public pubtypJycJigListTmp      As pubtypJycJigList

	'@蒸着治具一覧取得(jig_.jjiglist_)応答
    Public Structure pubtypJJigList
        Dim llngJJigListCnt         As Integer
        Dim pubJJigList				As List(Of JJigList)
    End Structure

    Public pubtypJJigListTmp      As pubtypJJigList

	'@EN02V0の設定結果を格納
    Public Structure JMaskSet
        Dim strGuideId                      As String           'ガイドリングID
        Dim strMaskId						As String           'マスクID
    End Structure
	
	'@蒸着マスク組立(jig_.jmaskset)要求
    Public Structure JMaskSetList
		Dim strJigStatus					As String				'治具ステータス（組後固定）
		Dim strEmpId						As String				'作業者ID
		Dim typJMaskSet						As List(Of JMaskSet)	'蒸着マスクセットリスト
		Dim lngtypJMaskSetCnt               As Integer				'蒸着マスクセットﾘｽﾄｶｳﾝﾄ
    End Structure
	
	'@EN02F0治具WF紐付けで使用
	Public Structure JigWfSet
        Dim strWfId								As String			'ウェハID
        Dim strSlotPosition						As String           'スロットポジション
		Dim strGuideId							As String           'ガイドリングID
		Dim strMaskId							As String           '組立マスクID
		Dim strWashUseNum						As String           '洗浄後使用回数
		Dim strWashUseLimit						As String           '洗浄後使用上限回数
		Dim strNextStockReadyFlag				As String           '次回在庫準備完了フラグ
		Dim strHolderId							As String           '紐付けホルダID
		Dim strHolderWashUseNum					As String           '紐付けホルダ洗浄後使用回数
		Dim strHolderWashUseLimit				As String           '紐付けホルダ洗浄後上限回数
    End Structure

	'@EN02F0治具WF紐付けで使用
    Public Structure JigWfSetList
		Dim typJigWfSet						As List(Of JigWfSet)	'治具WF紐付けリスト
		Dim lngJigWfSetCnt					As Integer				'治具WF紐付けｽﾄｶｳﾝﾄ
		Dim strSlotSize						As String				'スロットNo
    End Structure



    '@蒸着処理条件ﾘｽﾄ
    Public Structure VaConditionList
        Dim strSeqNum                       As String           '順(処理部)
        Dim strPanelKind                    As String           'ﾊﾟﾈﾙ種類(0：TFT、1：CF)
        Dim strVaConditionID                As String           '蒸着処理条件
        Dim strVaConditionFlag              As String           '蒸着処理条件制限ﾌﾗｸﾞ(1：有効、0：無効)
    End Structure

    '@蒸着処理条件取得(mas_.vacondition)結果を格納
    Public Structure VaConditionListAns
        Dim lngVaConditionListCnt           As Integer                  '蒸着処理条件ﾘｽﾄｶｳﾝﾄ
        Dim typVaConditionList              As List(Of VaConditionList) '蒸着処理条件ﾘｽﾄ
    End Structure

    '@lot_.cfchipmoveとcfchipmoveinfo用の構造体(WFのﾘｽﾄ)
    Public Structure cfjigList
        Dim strSlotNo                       As String           'ｽﾛｯﾄ№
        Dim strjigId                        As String           '治具ID
        Dim strWfId                         As String           '治具ｽﾃｰﾀｽ
    End Structure

    '@lot_.cfchipmoveとcfchipmoveinfo用の構造体
    Public Structure cfchipmovejigList
        Dim strMsgVersion                   As String             'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
        Dim strClassDivision                As String             '処理区分
        Dim strLotID                        As String             'ﾛｯﾄID
        Dim strCarrierId                    As String             'ｷｬﾘｱID
        Dim strOpID                         As String             '大工程
        Dim strStepID                       As String             '小工程
        Dim strBeforMoveNum                 As String             '移載前数量
        Dim strMoveNum                      As String             '移載数量
        Dim strScrapNum                     As String             '不良数量
        Dim strReworkNum                    As String             'ﾘﾜｰｸ数量
        Dim strEmpID                        As String             '作業者ID
        Dim lngcfjigListCnt                 As Integer            '治具ﾘｽﾄｶｳﾝﾄ
        Dim typcfjigList                    As List(Of cfjigList) '治具ﾘｽﾄ
    End Structure

    '@蒸着ﾊﾞｯﾁIDの取得有無ﾁｪｯｸ用構造体
    Public Structure JBatchFromLot
        Dim strBatchId                      As String           'ﾊﾞｯﾁID
        Dim strWfId                         As String           'WFID
        Dim strSlotPosition                 As String           'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
    End Structure

    Public Structure JBatchFromLotList
        Dim typJBatchLotList                As List(Of JBatchFromLot) '蒸着ﾊﾞｯﾁIDの取得有無ﾁｪｯｸ用構造体
        Dim lngJBatchLotListCnt             As Integer                'ｶｳﾝﾀ
    End Structure

    '@ﾊﾞｯﾁ投入順通知(eq__.batchmovein)　要求構造体
    Public Structure MoveInCarrierList
        Dim strSeqNum                       As String           '投入順
        Dim strLoaderCarrierID              As String           'LDｷｬﾘｱID
        Dim strUnloaderCarrierID            As String           'ULDｷｬﾘｱID
        Dim strUseId                        As String           '機種区分
    End Structure

    Public Structure EqBatchMoveIn
        Dim lngCarrierListCnt               As Integer                    '投入ｷｬﾘｱﾘｽﾄ件数
        Dim typCarrierList                  As List(Of MoveInCarrierList) '蒸着ﾊﾞｯﾁIDの取得有無ﾁｪｯｸ用構造体
        Dim strMsgVer                       As String                     'ﾒｯｾｰｼﾞVer
        Dim strBatchId                      As String                     'ﾊﾞｯﾁID
        Dim strRecipeId                     As String                     'ﾚｼﾋﾟID
        Dim strMsgSubject                   As String                     'ﾒｯｾｰｼﾞｻﾌﾞｼﾞｪｸﾄ
    End Structure

    '@紐付きMKﾛｯﾄﾘｽﾄ取得用(lot_.relationmklotlist)
    Public Structure typRelationMKLot
        Dim strMKLot                        As String           'MKﾛｯﾄID
    End Structure

    Public Structure typRelationMKLotList
        Dim lngCnt                          As Integer                   'ｱﾚｰｶｳﾝﾄ
        Dim typRelationMKLot                As List(Of typRelationMKLot) 'MKﾛｯﾄﾘｽﾄ
    End Structure

    '@対向基板紐付情報
    Public Structure MKLotRelation
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strPdId                         As String           '機種
        Dim strFlowClass                    As String           '種別
        Dim strTrowinTime                   As String           '投入日時
        Dim strTrowinNum                    As String           '投入数量
        Dim strMKIsuueNum                   As String           'MKﾛｯﾄ払出数
        Dim strLR                           As String           '左/右
        Dim strTpalClass                    As String           '貼合区分
        Dim strCarrierId                    As String           'キャリアID
        Dim strEmpName                      As String           '作業者
        Dim strStatus                       As String           '現在状態
    End Structure

    '@蒸着ﾊﾞｯﾁ情報
    Public Structure typeShelfInfo
        Dim strSeq                          As String           '順
        Dim strjigId                        As String           '治具ID
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strWfId                         As String           'WF_ID
    End Structure

    '@対向基板紐付/蒸着ﾊﾞｯﾁ情報
    Public Structure typeMKRelationBatchInfo
        Dim lngCFLotListcnt                 As Integer                'CFﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typCFLotList                    As List(Of MKLotRelation) 'CFﾛｯﾄﾘｽﾄ
        Dim typMKLot                        As MKLotRelation          'MKﾛｯﾄ
        Dim lngTpLotListCnt                 As Integer                'TPﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typTPLotList                    As List(Of MKLotRelation) 'TPﾛｯﾄﾘｽﾄ
        Dim lngTFTLotListCnt                As Integer                'TFTﾛｯﾄﾘｽﾄｶｳﾝﾄ
        Dim typTFTLotList                   As List(Of MKLotRelation) 'TFTﾛｯﾄﾘｽﾄ
        Dim strBatchId                      As String                 '蒸着ﾊﾞｯﾁID
        Dim strBatchTime                    As String                 'ﾊﾞｯﾁ編成時刻
        Dim strBatchNum                     As String                 'ﾊﾞｯﾁ編成枚数
        Dim strEmpName                      As String                 'ﾕｰｻﾞ名
        Dim lngShelfInfoListcnt             As Integer                '蒸着ﾊﾞｯﾁ情報ｶｳﾝﾄ
        Dim typeShelfInfoList               As List(Of typeShelfInfo) '蒸着ﾊﾞｯﾁ情報
    End Structure


    '@CF払出履歴情報取得(inv_.mkissuehistory)要素
    Public Structure typeHistoryList
        Dim strEventClass                   As String           'ｲﾍﾞﾝﾄｸﾗｽ
        Dim strEventName                    As String           'ｲﾍﾞﾝﾄ名
        Dim strRecordTime                   As String           '登録日時
        Dim strQuantity                     As String           '数量
        Dim strIssueQuantity                As String           '払出数量
        Dim strIssueLotID                   As String           '払出先
        Dim strEmpName                      As String           '作業者名
    End Structure

    '@CF払出履歴情報取得(inv_.mkissuehistory)
    Public Structure typeCFIssueHistory
        Dim strLotID                        As String                   'ﾛｯﾄID
        Dim strPartCode                     As String                   '部品
        Dim strProductionLotId              As String                   '製造ﾛｯﾄID
        Dim lngtypeHistoryListCnt           As Integer                  'ﾘｽﾄｶｳﾝﾄ
        Dim typeHistoryList                 As List(Of typeHistoryList) '履歴ﾘｽﾄ
    End Structure

    '@ﾛｯﾄ分割ﾚｼﾋﾟ状態ﾁｪｯｸ(lot_.chkdividerecipe)
    Public Structure typChkDivderRecipe
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strWfList                       As List(Of String)  'ｳｪﾊｰIDﾘｽﾄ
        Dim strDivLotID                     As String           '分割ﾛｯﾄID
        Dim strDiveWFList                   As List(Of String)  '分割ｳｪﾊｰﾘｽﾄ
        Dim strMsgCode                      As String           'ﾒｯｾｰｼﾞｺｰﾄﾞ
        Dim strMsg                          As String           'ﾒｯｾｰｼﾞ
    End Structure

    '@ﾛｯﾄ統合ﾚｼﾋﾟ状態ﾁｪｯｸ(lot_.chkcombinerecipe)
    Public Structure typChkCombineRecipe
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strDivLotID                     As String           '分割ﾛｯﾄID
        Dim strMsgCode                      As String           'ﾒｯｾｰｼﾞｺｰﾄﾞ
        Dim strMsg                          As String           'ﾒｯｾｰｼﾞ
    End Structure

    '@区間優先ﾘｽﾄ
    Public Structure typSecPriorityList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strGrbClass                     As String           'GRB区分
        Dim strCarrier                      As String           'ｷｬﾘｱID
        Dim strStartOpId                    As String           '開始大工程
        Dim strStartStepId                  As String           '開始小工程
        Dim strEndOpId                      As String           '終了大工程
        Dim strEndStepId                    As String           '終了小工程
        Dim strSectionPriority              As String           '区間優先度
        Dim strPriority                     As String           '優先度
        Dim strEmpName                      As String           '設定ユーザ
        Dim strEntryTime                    As String           '登録日時
        Dim strOpID                         As String           '大工程
        Dim strStepID                       As String           '小工程
        Dim strLotHoldFlag                  As String           '保留ﾌﾗｸﾞ
        Dim strLotStopFlag                  As String           '停止ﾌﾗｸﾞ
    End Structure

    '@区間優先情報取得(lot_.secpriority)
    Public Structure typSecPriority
        Dim strSbID                         As String                      'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim SecPriorityList                 As List(Of typSecPriorityList) '区間優先ﾘｽﾄ
        Dim lngListCnt                      As Integer                     'ﾘｽﾄｶｳﾝﾄ
        Dim strMsgCode                      As String                      'ﾒｯｾｰｼﾞｺｰﾄﾞ
        Dim strMsg                          As String                      'ﾒｯｾｰｼﾞ
    End Structure

    '@流動票情報
    Public Structure typSecPriDetailList
        Dim strOpID                         As String               '大工程
        Dim strStepID                       As String               '小工程
        Dim strSeqNum                       As String               '処理順
        Dim strSecPriority                  As String               '区間優先度
        Dim strExecedFlag                   As String               '流動済みﾌﾗｸﾞ
    End Structure

    '@ﾛｯﾄ・区間優先ﾘｽﾄ
    Public Structure typSecPriList
        Dim strLotID                        As String                       'ﾛｯﾄID
        Dim SecPriDetailList                As List(Of typSecPriDetailList) '流動票情報
        Dim lngListCnt2                     As Integer                      'ﾘｽﾄｶｳﾝﾄ
    End Structure

    '@区間優先情詳細報取得(lot_.secprioritydetail)
    Public Structure typSecPriorityDetail
        Dim strSbID                         As String                 'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim SecPriList                      As List(Of typSecPriList) 'ﾛｯﾄ・区間優先ﾘｽﾄ
        Dim lngListCnt1                     As Integer                'ﾘｽﾄｶｳﾝﾄ
        Dim strMsgCode                      As String                 'ﾒｯｾｰｼﾞｺｰﾄﾞ
        Dim strMsg                          As String                 'ﾒｯｾｰｼﾞ
    End Structure

    '@区間優先情報登録詳細
    Public Structure typChgSecPriList
        Dim strLotID                        As String               'ﾛｯﾄID
        Dim strStartOpId                    As String               '開始大工程
        Dim strStartStepId                  As String               '開始小工程
        Dim strEndOpId                      As String               '終了大工程
        Dim strEndStepId                    As String               '終了小工程
        Dim strSectionPriority              As String               '区間優先度
        Dim strPriority                     As String               '優先度
        Dim strEmpID                        As String               '設定ユーザ
    End Structure

    '@区間優先情報登録(lot_.chgsecpriority)
    Public Structure typChgSecPriority
        Dim strSbID                         As String                    'SB_ID
        Dim typChgSecPriority               As List(Of typChgSecPriList) '詳細ﾘｽﾄ
        Dim lngListCnt                      As Integer                   'ﾘｽﾄｶｳﾝﾄ
    End Structure

    '@在庫管理画面引継ぎ構造体
    Public Structure typInvPartClass
        Dim strPartID                       As String               '部品ｺｰﾄﾞ
        Dim strInvLotId                     As String               '在庫ﾛｯﾄID
        Dim strParentForm                   As String               '親画面
    End Structure

    '@ﾘｱｸﾀﾘｽﾄ
    Public Structure typRcList
        Dim strRc                           As String               'ﾘｱｸﾀ
        Dim strRcName                       As String               'ﾘｱｸﾀ名
    End Structure

    '@ﾚｼﾋﾟﾘｽﾄ
    Public Structure typRecipeList
        Dim strRecipeId                     As String               'ﾚｼﾋﾟID
    End Structure

    '@更新種別ﾘｽﾄ
    Public Structure typFbReasonList
        Dim strFbReasonId                   As String               '更新種別ID
        Dim strFbReasonName                 As String               '更新種別名
    End Structure

    '@TEOS F/B結果検索条件取得 (fb__.teosresultcondlist 応答)
    Public Structure typFbTeosResultCondList
        Dim rcList                          As List(Of typRcList)       'ﾘｱｸﾀﾘｽﾄ
        Dim lngRcListCnt                    As Integer                  'ﾘｱｸﾀﾘｽﾄｶｳﾝﾄ
        Dim recipeList                      As List(Of typRecipeList)   'ﾚｼﾋﾟﾘｽﾄ
        Dim lngRecipeListCnt                As Integer                  'ﾚｼﾋﾟﾘｽﾄｶｳﾝﾄ
        Dim fbReasonList                    As List(Of typFbReasonList) '更新種別ﾘｽﾄ
        Dim lngFbReasonListCnt              As Integer                  '更新種別ﾘｽﾄｶｳﾝﾄ
    End Structure

    '@TEOS F/B結果ﾘｽﾄ
    Public Structure typFbTeosRresultList
        Dim lngNo                           As Integer              'No
        Dim strState                        As String               '状態
        Dim strValidFlag                    As String               '有効・無効ﾌﾗｸﾞ(有効:1、無効:0)
        Dim strChangeProhibitFlag           As String               '更新許可ﾌﾗｸﾞ(禁止:1、許可:0)
        Dim strEntryTime                    As String               '実施日時
        Dim strFbStatId                     As String               '更新種別ID
        Dim strFbStatName                   As String               '更新種別名
        Dim strProcessTime                  As String               '補正値(sec)
        Dim strMinProcessTime               As String               '補正DEPO時間Min(sec)
        Dim strMaxProcessTime               As String               '補正DEPO時間Max(sec)
        Dim strFbLotId                      As String               '補正ﾛｯﾄID
        Dim strFbRecipeId1                  As String               '補正ﾚｼﾋﾟ1
        Dim strFbRecipeId2                  As String               '補正ﾚｼﾋﾟ2
        Dim strUserID                       As String               '実施ﾕｰｻﾞID
        Dim strUserName                     As String               '実施ﾕｰｻﾞ名
    End Structure

    '@TEOS F/B結果取得 (fb__.teosresultlist 応答)
    Public Structure pubTypFbTeosRresultList
        Dim fbTeosRresultList               As List(Of typFbTeosRresultList) 'TEOS F/B結果ﾘｽﾄ
        Dim lngFbTeosRresultListCnt         As Integer                       'TEOS F/B結果ﾘｽﾄｶｳﾝﾄ
    End Structure

    '@FR履歴リスト(fb__.contetfrhist 詳細)
    Public Structure typFbConstFrHistList
        Dim strFrId                         As String
        Dim strLotID                        As String
        Dim strRrecipId                     As String
        Dim strAcceleFacter                 As String
        Dim strCumProcTime                  As String
        Dim strProcTime                     As String
        Dim strCalcCumProcTime              As String
        Dim strEntryTime                    As String
        Dim strEmpName                      As String

    End Structure

    '@FR履歴取得 (fb__.contetfrhist 応答)
    Public Structure pubTypFbContFrHist
        Dim strWarMsgTime                   As String
        Dim strErrMsgTime                   As String
        Dim strRfRefValueTime               As String
        Dim strWpID                         As String
        Dim strProcessingId                 As String
        Dim lngFbConstFrHistCnt             As Integer                       '結果ﾘｽﾄｶｳﾝﾄ
        Dim fbConstFrHistList               As List(Of typFbConstFrHistList) 'FR履歴ﾘｽﾄ
    End Structure

    '@FR履歴登録(fb__.contetfrhistreg)
    Public Structure typFbConstFrHistReg
        Dim strWpID                         As String
        Dim strProcessingId                 As String
        Dim strLotID                        As String
        Dim strRcipId                       As String
        Dim strAcceleFacter                 As String
        Dim strCumProcTime                  As String
        Dim strProcTime                     As String
        Dim strCalcCumProcTime              As String
        Dim strEmpID                        As String
    End Structure

    Public Structure typChkCombineLotIn
        Dim strSbID                         As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strWfList                       As List(Of String)  'ｳｪﾊｰIDﾘｽﾄ
        Dim lngWfListCnt                    As Integer          'ｳｪﾊｰﾘｽﾄｶｳﾝﾄ
        Dim strRecyclFlag                   As String           '再利用ﾌﾗｸﾞ(0：Wf再利用なし、1：Wf再利用あり)
        Dim strResult                       As String           '結果(OK/NG)
        Dim strMsg                          As String           'ﾒｯｾｰｼﾞ
    End Structure

    '@ﾊﾞｯﾁ編成設定(ﾚｼﾋﾟ)
    Public Structure typBatchControlRecipe
        Dim strSeqNum                       As String
        Dim strRecipeType                   As String
        Dim strRecipeId                     As String
        Dim strWfNum                        As String
        Dim strTimeNum                      As String
        Dim strTimeWfNum                    As String
        Dim strEditEmpName                  As String
        Dim strEditTime                     As String
        Dim strEditFlag                     As String
    End Structure

    '@ﾊﾞｯﾁ編成設定
    Public Structure BatComposeStatus
        Dim strWpID                         As String
        Dim strBatchComposeType             As String
        Dim strEditEmpName                  As String
        Dim strEditTime                     As String
        Dim strEditFlag                     As String
        Dim lngRecipeListCnt                As Integer
        Dim typRecipeList                   As List(Of typBatchControlRecipe)
    End Structure

    '@ﾊﾞｯﾁﾚｼﾋﾟ
    Public Structure typBatchRecipe
        Dim strRecipeType                   As String
        Dim strRecipeId                     As String
        Dim strStatId                       As String
    End Structure

    '@ﾊﾞｯﾁﾚｼﾋﾟﾘｽﾄ
    Public Structure BatRecipeList
        Dim strWpID                         As String
        Dim strMaxProcessQuantity           As String
        Dim strTimeNumItem                  As String
        Dim lngRecipeListCnt                As Integer
        Dim typRecipeList                   As List(Of typBatchRecipe)
    End Structure

    '@ﾊﾞｯﾁﾚｼﾋﾟ
    Public Structure typBatchWaitingLot
        Dim strLotID                        As String
        Dim strRecipeId                     As String
        Dim strFlowClass                    As String
        Dim strLotPriority                  As String
        Dim strOpID                         As String
        Dim strStepID                       As String
        Dim strCarrierId                    As String
        Dim strWfQty                        As String
        Dim strCurrentPositionName          As String
        Dim strLotStopFlag                  As String
        Dim strLotHoldFlag                  As String
        Dim strStockerId                    As String
        Dim strWaitTimeH                    As String
    End Structure

    '@ﾊﾞｯﾁ装置待ちﾛｯﾄﾘｽﾄ
    Public Structure BatWaitingLotList
        Dim strWpID                         As String
        Dim lngBatLotCnt                    As Integer
        Dim typBatLotList                   As List(Of typBatchWaitingLot)
    End Structure

    '@時間制限流動設定(工程)
    Public Structure typRestrictFlow
        Dim strFromOpId                     As String
        Dim strFromStepId                   As String
        Dim strToOpId                       As String
        Dim strToStepId                     As String
        Dim strLotStopOn                    As String
        Dim strEditEmpName                  As String
        Dim strEditTime                     As String
        Dim strEditFlag                     As String
    End Structure

    '@時間制限流動設定(装置)
    Public Structure typRestrictWp
        Dim strWpID                         As String
        Dim strWpName                       As String
        Dim strSeqNum                       As String
        Dim strProcessingName               As String
        Dim strLotStopOff                   As String
        Dim strWaitLotNum                   As String
        Dim strEditEmpName                  As String
        Dim strEditTime                     As String
        Dim strEditFlag                     As String
    End Structure

    '@時間制限流動設定
    Public Structure TimeRestrict
        Dim strSbID                         As String
        Dim strRestrictType                 As String
        Dim lngFlowListCnt                  As Integer
        Dim typRestrictFlowList             As List(Of typRestrictFlow)
        Dim lngWpListCnt                    As Integer
        Dim typRestrictWpList               As List(Of typRestrictWp)
    End Structure

    '@↓2018/08/06 (Mon) 15:33:21 T.Oide **************************************************
    '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ機種詳細
    Public Structure typTapeStickPdList
        Dim strPdId                         As String
        Dim strParentPdId                   As String
    End Structure

    '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
    Public Structure TapeStickGr
        Dim strTapeStickGr                  As String
        Dim strAtrayChipNum                 As String
        Dim typPdList                       As List(Of typTapeStickPdList)
        Dim lngPdListCnt                    As Integer
    End Structure

    '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟﾘｽﾄ
    Public Structure TapeStickGrList
        Dim strSbID                         As String
        Dim typTapeStickGr                  As List(Of TapeStickGr)
        Dim lngTapeStickGrCnt               As Integer
    End Structure


    '@ALDﾊﾞｯﾁﾘｽﾄ(ﾛｯﾄ詳細)
    Public Structure typBatchDetail
        Dim strSeqNum                       As String
        Dim strLotID                        As String
        Dim strLotEventId                   As String
        Dim strPdId                         As String
        Dim strWfQty                        As String
        Dim strChipQty                      As String
        Dim strACrrierGroup                 As String
        Dim strTapeStickGr                  As String
        Dim strAtrayChipNum                 As String
        Dim strFlowClass                    As String
        Dim strTapeStickBatchId             As String
        Dim strTapeStickRrecipeId           As String
        Dim strOvenBatchId                  As String
        Dim strOvenRecipeId                 As String
        Dim strAldBatchId                   As String
        Dim strAldRecipeId                  As String
    End Structure

    '@ALDﾊﾞｯﾁﾘｽﾄ(ﾊﾞｯﾁ詳細)
    Public Structure typAldBatch
        Dim strBatchId                      As String
        Dim strBatchStatus                  As String
        Dim strEditable                     As String
        Dim strPlanThrowinDate              As String
        Dim strBatchFlowClass               As String
        Dim steMonitorUseFlag               As String
        Dim strEmpID                        As String
        Dim typBatchDetail                  As List(Of typBatchDetail)
        Dim lngBatchDetailCnt               As Integer
    End Structure

    '@ALDﾊﾞｯﾁﾘｽﾄ
    Public Structure typAldBatchList
        Dim strClassDiv                     As String
        Dim strSbID                         As String
        Dim typAldBatchList                 As List(Of typAldBatch)
        Dim lngAldBatchListCnt              As Integer
    End Structure

    '@防湿膜ALD「ﾃｰﾌﾟ貼り」「ｵｰﾌﾞﾝ」「ALD」ﾚｼﾋﾟ格納
    Public Structure AldBatchRecipe
        Dim strParentPdId                   As String
        Dim strPdId                         As String
        Dim strTapeStickRecipe              As String
        Dim strOvenRecipe                   As String
        Dim strAldRecipe                    As String
    End Structure

    '@防湿膜ALD「ﾃｰﾌﾟ貼り」「ｵｰﾌﾞﾝ」「ALD」ﾚｼﾋﾟのﾘｽﾄ格納
    Public Structure typAldBatchRecipeList
        Dim typeAldBatchRecipe             As List(Of AldBatchRecipe)
        Dim lngAldBatchRecipeCnt           As Integer
    End Structure
    
    '@↓2019/11/21 (Thu) 17:11:36 T.Oide **************************************************
    '@防湿ALD用部材一覧取得(inv_.partlistAld 要素)
    Public Structure typALDPart
        Dim strVenderClassId                As String
        Dim strVenderClassName              As String
        Dim strVenderId                     As String
        Dim strVenderName                   As String
        Dim strPartCode                     As String
        Dim strPartName                     As String
        Dim strLotID                        As String
        Dim strChipQty                      As String
        Dim strProdcLotId                   As String
    End Structure

    '@防湿ALD用部材一覧取得(inv_.partlistAld 要素)
    Public Structure typALDPartList
        Dim typeAldPart                     As List(Of typALDPart)
        Dim lngAldPartCnt                   As Integer
    End Structure
    '@↑2019/11/21 (Thu) 17:11:36 T.Oide **************************************************

    '@防湿ALD処理ﾏｽﾀ取得(mas_.aldprocess 受信)
    Public Structure ALDProcessList
        Dim strProcessNum                   As String
        Dim strProcessName                  As String
        Dim strEqType                       As String
        Dim strModeId                       As String
    End Structure

    '@防湿ALD処理変更(eq__.aldprocesschange 要求)
    Public Structure ALDProcessChange
        Dim strSbID                         As String
        Dim strClassDivision                As String
        Dim strWpID                         As String
        Dim strALDProcessModeId             As String   '防湿ALD処理ﾓｰﾄﾞ
    End Structure

    '@防湿ALD作業ﾛｯﾄ一覧(WorkLotList)
    Public Structure AldWorkLotList
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strCarrierId                    As String           'ｷｬﾘｱID
        Dim strToCarrierId                  As String           'ｷｬﾘｱID(Unloader)
        Dim strFlowClass                    As String           '流動区分
        Dim strOpID                         As String           '大工程ID
        Dim strStepID                       As String           '小工程ID
        Dim strNowST                        As String           'LOT状態
        Dim strEngEmpId                     As String
        Dim strEngEmpName                   As String
        Dim strWfNum                        As String           'WF枚数
        Dim strChipQuantity                 As String           'ﾁｯﾌﾟ数
        Dim strLotHoldFlag                  As String           'ﾛｯﾄ保留ﾌﾗｸﾞ
        Dim strLotStopFlag                  As String           'ﾛｯﾄ停止ﾌﾗｸﾞ
        Dim strLotPriority                  As String           '優先度
        Dim strLimitTime                    As String           '制限時間(時間制約)
        Dim strToOpId                       As String           '制限時間先大工程
        Dim strToStepId                     As String           '制限時間先小工程
        Dim strWarnTime                     As String           '警告時間
        Dim strRestrictTypeID               As String           '制限ﾀｲﾌﾟ
        Dim strPdId                         As String           '機種ID
        Dim strPdVersion                    As String           '機種Ver
        Dim strACarrierId                   As String           'AｷｬﾘｱID
        Dim strATrayNum                     As String           'Aﾄﾚｲ数
        Dim strWorkCondition                As String           '作業条件
        Dim strComments                     As String           'ｺﾒﾝﾄ
        Dim strEditTime                     As String           '最終更新日
        Dim strProcessNum                   As String
        Dim strProcessName                  As String
        Dim strCollectionID                 As String           '収集項目ID
        Dim strCollectionVersion            As String           '収集項目ﾊﾞｰｼﾞｮﾝ
    End Structure

    '@ACarrier一覧(WorkLotList)
    Public Structure AldWorkACarrierList
        Dim strSeqNum                       As String
        Dim strACarrierGroup                As String
        Dim strTapeBatchId                  As String
        Dim strOvenBatchId                  As String
        Dim strAldBatchId                   As String
        Dim strLotID                        As String           'ﾛｯﾄID
        Dim strACarrierId                   As String           'AｷｬﾘｱID
    End Structure

    '@@防湿ALD作業ﾛｯﾄ一覧取得(lot_.workaldlotlist 応答)
    Public Structure WorkALDLotList
        Dim strTapeBatchId                  As String
        Dim strOvenBatchId                  As String
        Dim strAldBatchId                   As String
        Dim strProcessUnit                  As String
        Dim strProcessNum                   As String
        Dim strProcessName                  As String
        Dim strLotID                        As String
        Dim strCarrierId                    As String
        Dim strMonitorUseFlag               As String
        Dim strBatchFlowClass               As String
        Dim lngAldWorkLotListCnt            As Integer
        Dim typAldWorkLotList               As List(Of AldWorkLotList)
        Dim lngAldWorkACarrierListCnt       As Integer
        Dim typAldWorkACarrierList          As List(Of AldWorkACarrierList)
    End Structure

    '@防湿ALD装置ﾚｼﾋﾟ一覧(ALDWpRecipeList)
    Public Structure ALDWpListList
        Dim strWpID                         As String
        Dim strWpName                       As String
        Dim strWpStatusName                 As String
        Dim strWpStopFlag                   As String
        Dim strRecipeId                     As String
        Dim strLotRecipeFlag                As String
        Dim strOpID                         As String
        Dim strStepID                       As String
        Dim strNextOpId                     As String
        Dim strNextStepId                   As String
        Dim strWpTypeFlag                   As String
        Dim strEqType                       As String
        Dim strMcType                       As String
        Dim strFtpDataFlag                  As String
        Dim strMesModeId                    As String
        Dim strMesModeStatus                As String
        Dim strUseId                        As String
        Dim strCommitFlag                   As String
        Dim strLoaderUnloaderFlag           As String
        Dim strBeforeCarrierTypeId          As String
        Dim strBeforeCarrierTypeName        As String
        Dim strAfterCarrierTypeId           As String
        Dim strAfterCarrierTypeName         As String
        Dim strCleanCondition               As String
        Dim strProcessNum                   As String
        Dim strProcessName                  As String
    End Structure

    '@防湿ALD装置ﾚｼﾋﾟ一覧(lot_.wplistald 応答)
    Public Structure ALDWpList
        Dim typALDWpListList                As List(Of ALDWpListList)
        Dim lngALDWpListListCnt             As Integer
    End Structure

    '@ATray一覧(ACarrierState)
    Public Structure ATrayList
        Dim strAtrayId                      As String
        Dim strAtrayStatus                  As String
        Dim strAtrayStatusName              As String
        Dim strAtrayClass                   As String
        Dim strTapeStickGroup               As String
        Dim strWashUseNum                   As String
        Dim strWashUseLimit                 As String
        Dim strUseNum                       As String
        Dim strUseLimit                     As String
        Dim strSlotPosition                 As String
        Dim strCleanCount                   As String
    '@↓2019/11/26 (Tue) 17:49:06 T.Oide **************************************************
    '@    strPartCode                     As String
    '@    strVender                       As String
    '@    strInvLotId                     As String
    '@    strProductionLotId              As String
    '@    strQty                          As String
    '@↑2019/11/26 (Tue) 17:49:06 T.Oide **************************************************
    End Structure

    '@Aｷｬﾘｱ状態(carr.acarstat 応答)
    Public Structure ACarrierState
        Dim strACarrierId                   As String
        Dim strACarrierStatId               As String
        Dim strACarrierClass                As String
        Dim strEmptyFlag                    As String
        Dim strCleanFlag                    As String
        Dim strCleanCount                   As String
        Dim strWashUseNum                   As String
        Dim strWashUseLimit                 As String
        Dim strUseNum                       As String
        Dim strUseLimit                     As String
        Dim strTapeStickBatchId             As String
        Dim strOvenBatchId                  As String
        Dim strAldBatchId                   As String
        Dim typAtrayList                    As List(Of ATrayList)
        Dim lngATrayListCnt                 As Integer
    '@↓2019/11/26 (Tue) 17:49:38 T.Oide **************************************************
        Dim typAtrayUsePart                 As typALDPartList
    '@↑2019/11/26 (Tue) 17:49:38 T.Oide **************************************************
    End Structure

    '@ﾃｰﾌﾟｸﾞﾙｰﾌﾟ
    Public Structure TapeGroup
        Dim strSeqNum                       As String
        Dim strLotID                        As String
        Dim strPdId                         As String
        Dim strFlowClass                    As String
        Dim strACarrierGroup                As String
        Dim strTapeBatchId                  As String
        Dim strOvenBatchId                  As String
        Dim strAldBatchId                   As String
        Dim strTapeStickGroup               As String
        Dim strACarrierId                   As String
    End Structure

    '@Aｷｬﾘｱｸﾞﾙｰﾌﾟ
    Public Structure ACarrierGroupInfo
        Dim strBatchStatus                  As String
        Dim strMonitorUseFlag               As String
        Dim strBatchFlowClass               As String
        Dim typtapeGroupList                As List(Of TapeGroup)
        Dim lngTapeGroupListCnt             As Integer
    End Structure

    '@Aｷｬﾘｱﾘｽﾄ
    Public Structure ACarrierList
        Dim strACarrierId                   As String
        Dim strATrayNum                     As String
    End Structure

    '@Aｷｬﾘｱﾘｽﾄ
    Public Structure ACarrierGroupList
        Dim strLotID                        As String
        Dim strACarrierClass                As String
        Dim strACarrierGroup                As String
        Dim strACarrierId                   As String
        Dim strATrayNum                     As String
    End Structure

    '@Aｷｬﾘｱｸﾞﾙｰﾌﾟ
    Public Structure ACarrierGroup
        Dim strTapeBatchId                  As String
        Dim strOvenBatchId                  As String
        Dim strAldBatchId                   As String
        Dim typACarrierGroupList            As List(Of ACarrierGroupList)
        Dim lngGroupListCnt                 As Integer
    End Structure
    
    '@Aﾄﾚｰﾘｽﾄ(atray.list____ 応答)
    Public Structure typeAtray
        Dim strAtrayId                      As String
        Dim strAtrayStatus                  As String
        Dim strAtrayStatusName              As String
        Dim strAtrayClass                   As String
        Dim strTapeStickGr                  As String
        Dim strStartTime                    As String
        Dim strCleanTime                    As String
        Dim strWashUseNum                   As String
        Dim strWashUseLimit                 As String
        Dim strUseNum                       As String
        Dim strUseLimit                     As String
        Dim strACarrierId                   As String
        Dim strSlotPosition                 As String
        Dim strEmpName                      As String
        Dim strEditTime                     As String
        Dim strComments                     As String
        Dim strCleanCount                   As String
    End Structure

    Public Structure typeAtrayList
        Dim typAtraytList                   As List(Of typeAtray)
        Dim lngAtraytListCnt                As Integer
    End Structure

    '@Aﾄﾚｰ情報登録・更新
    Public Structure typAtrayRegist
        Dim strClassDiv                     As String
        Dim strEmpID                        As String
        Dim typAtraytList                   As List(Of typeAtray)
        Dim lngAtraytListCnt                As Integer
    End Structure

    'TFTとCF情報(ODF貼り合せ可能な対を取得)
    Public Structure typTFTandCF
        Dim strPdId                         As String
        Dim strPdVersion                    As String
        Dim strLcDirection                  As String
        Dim strBackColor                    As String
        Dim strForeColor                    As String
        Dim strCfPdId                       As String
        Dim strCfPdVersion                  As String
    End Structure

    '貼り合わせ予約可能一覧
    Public Structure typOdfReserveRep
        Dim strPdId                         As String
        Dim strFlowClass                    As String
        Dim strLotId                        As String
        Dim strCfFlag                       As String
        Dim strWfId                         As String
        Dim strSlotPosition                 As String
        Dim strReserveFlag                  As String
        Dim strCarrierId                    As String
        Dim strCurrentStatus                As String
        Dim strCurrentStatusName            As String
    End Structure

    '貼り合わせ予約登録
    Public Structure typOdfReserveRegist
        Dim strWfId                         As String
        Dim strCfWfId                       As String
        Dim strLotId                        As String
        Dim strCfLotId                      As String
        Dim strCarrierId                    As String
        Dim strCfCarrierId                  As String
        Dim strSlotPosition                 As String
    End Structure

    '貼り合わせ予約情報
    Public Structure typOdfReserveInfo
        Dim strWfId                         As String
        Dim strCfWfId                       As String
        Dim strLotId                        As String
        Dim strCfLotId                      As String
        Dim strCarrierId                    As String
        Dim strCfCarrierId                  As String
        Dim strSlotPosition                 As String
        Dim strEmpName                      As String
        Dim strEditTime                     As String
        Dim strCurrentLotId                 As String   '現在のロットID(TFT)
        Dim strCurrentCfLotId               As String   '現在のロットID(CF)        
        Dim strCurrentCarrierId             As String   '現在のキャリアID(TFT)
        Dim strCurrentCfCarrierId           As String   '現在のキャリアID(CF)
    End Structure

    '表面処理予約情報
    Public Structure typHyoumenReserveInfo
        Dim strWfId                         As String
        Dim strCfWfId                       As String
        Dim strLotId                        As String   'ODF貼り合せ予約時のロットID(TFT)
        Dim strCfLotId                      As String   'ODF貼り合せ予約時のロットID(CF)
        Dim strCurrentLotId                 As String   '現在のロットID(TFT)
        Dim strCurrentCfLotId               As String   '現在のロットID(CF)
        Dim strCurrentCarrierId             As String   '現在のキャリアID(TFT)
        Dim strCurrentCfCarrierId           As String   '現在のキャリアD(CF)
        Dim strEditTime                     As String   'ODF貼り合せ予約の時間
        Dim strHReserveEmpName              As String   '表面処理予約の登録者名
        Dim strHReserveTime                 As String   '表面処理予約の時間
        Dim strHRecipeId                    As String   '表面処理装置のレシピID
    End Structure

    '表面処理予約の登録
    Public Structure typHyoumenReserveRegist
        Dim strWfId                         As String
        Dim strCfWfId                       As String
        Dim strLotId                        As String   'ODF貼り合せ予約時のロットID(TFT)
        Dim strCfLotId                      As String   'ODF貼り合せ予約時のロットID(CF)
        Dim strEditTime                     As String   'ODF貼り合せ予約の時間
    End Structure

    '表面処理予約Group
    Public Structure typHyoumenReserveGroup
        Dim strHReserveTime                 As String   '表面処理予約の時間
        Dim strLotId                        As String
        Dim strWfId                         As String
        Dim strCfFlag                       As String
    End Structure

    '現在のCFロット情報の取得
    Public Structure typCurCfLotInfo
        Dim strCfLotId                      As String
        Dim strWfNum                        As String
    End Structure

    '貼り合せ予約とのチェック
    Public Structure typChkOdfReserve
        Dim strLotId                        As String
        Dim strWfId                         As String
        Dim strSlotPosition                 As String
        Dim strCarrierId                    As String
        Dim strCfWfId                       As String
        Dim strCfLotId                      As String
        Dim strCfCarrierId                  As String
        Dim strCfSlotPosition               As String
    End Structure

	'装置ﾀｲﾌﾟ別ﾚｼﾋﾟﾘｽﾄ(eq__.eqtyperecplist 応答要素)
	Public Structure typWp
		Dim strWpId						As String
		Dim strWpName					As String
	End Structure

	'装置ﾀｲﾌﾟ別ﾚｼﾋﾟﾘｽﾄ(eq__.eqtyperecplist 応答)
    Public Structure eqtyperecplist
        Dim strRecipeID					As String
        Dim typWpList					As List(Of typWp)
    End Structure

	'装置ﾀｲﾌﾟ別ﾚｼﾋﾟﾘｽﾄ(eq__.photofbdatacopy 要求)
    Public Structure typCpRecpList
        Dim strMotoRecipeID             As String
        Dim strSakiRecipeID				As String
		Dim strWpList					As String
    End Structure

	'装置ﾀｲﾌﾟ別ﾚｼﾋﾟﾘｽﾄ(eq__.photofbdatacopy 要求)
    Public Structure photofbdatacopy
        Dim strMsgVer					As String
        Dim strEmpId					As String
		Dim typRecpList					As List(Of typCpRecpList)
    End Structure

	'@蒸着後流動予約情報
    Public Structure typAfterJReserveDetail

        Dim strReserveId					As String           '予約ID
        Dim strWfId							As String           'WFID
        Dim strLotId						As String			'ロットID
		Dim strPdId							As String			'機種(統合用)
		Dim strStepId						As String			'小工程(統合用)
        Dim strReserveGroup                 As String           '予約グループ
        Dim strSlotPosition                 As String           'ｽﾛｯﾄ№
        Dim strCarrierId					As String           'キャリアID
		Dim strMoveCompleteFlag				As String           'ｷｬﾘｱ交換済みフラグ
        Dim strEmpId						As String           '登録者ID
		Dim strEntryTime                    As String			'登録日時
    End Structure


	'@蒸着後流動予約情報一覧取得(lot_.afterjreservedetail)
	Public Structure AfterJReserveDetailList
		Dim lngAfterJReserveDetailListCnt	As Integer
        Dim typAfterJReserveDetailList		As List(Of typAfterJReserveDetail)
		Dim strReserveId					As String           '予約ID
		Dim strLotId						As String			'元ロットID
		Dim strEmpId						As String           '登録者ID
		Dim strEntryTime					As String			'登録日時
		Dim strNGFlag						As String			'重複フラグ
	End Structure

	'@蒸着後流動予約情報
    Public Structure typAfterJReserve
        Dim strReserveID					As String           '予約
		Dim strLotId						As String			'ロットID
        Dim strEmpId						As String           '登録者ID
		Dim strEmpName						As String           '登録者名
		Dim strEntryTime                    As String			'登録日時
    End Structure

	'@蒸着後流動予約情報一覧取得(lot_.afterjreservelist)
	Public Structure AfterJReserveList
		Dim lngAfterJReserveListCnt			As Integer
        Dim typAfterJReserveList			As List(Of typAfterJReserve)
	End Structure

	'@蒸着後流動予約情報取得
	Public Structure typAfterJReserveWf
		Dim strWfId As String           'WF_ID
		Dim strReserveGroup As String          'ロットID
		Dim strCarrierId As String           '登録者ID
	End Structure

	Public Structure AfterJReserveWfList
		Dim lngAfterJReserveWfListCnt		As Integer
        Dim typAfterJReserveWfList			As List(Of typAfterJReserveWf)
	End Structure



	Public Structure typAfterJRsvCombine
        Dim typAfterJReserveDetailList		As List(Of typAfterJReserveDetail)
		Dim lngAfterJReserveDetailListCnt	As Integer
        Dim strLotId						As String			'元ロットID
        Dim strPdId							As String           '元ロット機種
        Dim strStepId						As String           '元ロット小工程
    End Structure
	
	'自動分割ロット実績
	Public Structure typDivideLot
        Dim strLotId						As String			'元ロットID
        Dim strDivideLotId					As String			'分割後ロットID
    End Structure

	'自動統合ロット実績
	Public Structure typCombineLot
        Dim strLotId						As String			'元ロットID
        Dim strCombineLotId					As String			'統合後ロットID
    End Structure

	'自動ｷｬﾘｱ交換済みロット実績
	Public Structure typCarrierMoveLot
        Dim strLotId						As String			'元ロットID
    End Structure


End Module
