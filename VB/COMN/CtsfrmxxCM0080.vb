'ﾌｧｲﾙ名：xxCM0080.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：チップ状態変更登録、不良チップ情報(№表示)　メインフォーム
'作成日：2004/03/23 (Tue) 15:52:06 T.Kitagawa
'更新日：2019/10/25 (Fri) 15:55:46 T.Oide
'      ：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2019, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM0080
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM0080    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM0080
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM0080
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM0080)
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

    '@--------------------------------------------------------------------------------------
    '@機能ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ時の注意！！
    '@起動区分によりﾌｫｰﾑｷｬﾌﾟｼｮﾝ&機能仕様が変化します。
    '@よって機能ﾊﾞｰｼﾞｮﾝを上げる時は、必ずEN0190、EN01Q0、EN02G0の3つを修正すること(SPIRY+.exeのことだよ)
    '@
    '@★工程端末(M)：状態変更(良品→傾向/不良、傾向→傾向/不良　良い方向への変更は禁止)
    '@ﾒﾆｭｰKey:CPstrKeyEN0190、ｷｬﾌﾟｼｮﾝ名：チップ状態変更登録
    '@
    '@★ｽﾀｯﾌ & 開発端末(S & A)：状態変更(試作/実験ﾛｯﾄは上書き可)
    '@ﾒﾆｭｰKey:CPstrKeyEN01Q0、ｷｬﾌﾟｼｮﾝ名：チップ状態変更登録(上書き)
    '@
    '@★全端末(M & S & A)：不良ﾁｯﾌﾟ情報(№表示)
    '@ﾒﾆｭｰKey:CPstrKeyEN02G0、ｷｬﾌﾟｼｮﾝ名：不良ﾁｯﾌﾟ情報(№表示)
    '@
    '@機能IDについても同様の処理を行います。


    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2020/03/06 (Fri) 10:39:30 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion             As String = "17.03"
    Private Const CMstrLocalVersion             As String = "17.04"
    '@↑2020/03/06 (Fri) 10:39:30 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2020/01/15 (Wed) 14:20:02 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer          As String = "03.04"             'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer          As String = "04.00"             'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:20:02 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_insprst_Ver          As String = "02.01"             '不良/払出/保留/傾向登録結果登録
    Private Const CMstrmas_scplist_Ver          As String = "03.00"             '不良/払出一覧取得
    Private Const CMstrlot_waferlistVer         As String = "02.05"             'ﾛｯﾄWF情報取得(新)
    Private Const CMstrmas_mapinfo_Ver          As String = "01.01"             'ｽﾛｯﾄﾏｯﾌﾟ取得
    Private Const CMstrwf__mapinfo_Ver          As String = "04.03"             'ｳｪﾊﾏｯﾌﾟ情報取得
    Private Const CMstrelt_mapget__Ver          As String = "01.02"             '電特結果要求
    Private Const CMstrlot_chkwaistVer          As String = "01.00"             'WAITﾃﾞｰﾀ状態確認
    Private Const CMstrmas_empname_Ver          As String = "02.01"             '作業者名取得
    '@↓2020/03/18 (Wed) 15:36:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_chkexclusionprocessVer   As String = "01.00"         '抜取・全数検査ﾁｪｯｸ
    Private Const CMstrlot_chkexclusionprocessVer   As String = "02.00"         '抜取・全数検査ﾁｪｯｸ
    '@↑2020/03/18 (Wed) 15:36:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrelt_vfimapgetVer         As String = "01.00"             '異物検査機ﾏｯﾌﾟ要求

    '@ﾌﾚｯｸｽｸﾞﾘｯﾄﾞのｶﾗﾑ定数
    '@ｸﾞﾘｯﾄの単位
    Private Const CMlngvsfWtips                 As Integer = 15                 'ｸﾞﾘｯﾄのTwips単位
    Private Const CMvsfTitleFontSize            As Integer = 12                 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMvsfTopRow                   As Integer = 3                  '初期表示行番号

    '@WF情報
    Private Const CMlngvsfWFMapNo               As Integer = 0                  'ｽﾛｯﾄ№
    Private Const CMlngvsfWFMapID               As Integer = 1                  'WF_ID
    Private Const CMlngvsfWFMapDestNo           As Integer = 2                  '移載先ｽﾛｯﾄ№
    Private Const CMlngvsfWFCfWfID              As Integer = 3                  'CF_WFID
    Private Const CMlngvsfWFMapMaxSlotID        As Integer = 25                 'ｽﾛｯﾄ№の最大値
    Private Const CMlngvsfWFMapTitleHeight      As Integer = 18                 'ﾀｲﾄﾙ行の高さ
    Private Const CMlngvsfWFMapRowHeightMin     As Integer = 22                 '行の高さの最小値

    '@ﾁｯﾌﾟ数情報
    Private Const CMlngvsfChipCntTitle          As Integer = 0                  '不良/払出数
    Private Const CMlngvsfChipCntLot            As Integer = 1                  'LOT
    Private Const CMlngvsfChipCntWF             As Integer = 2                  'WF
    Private Const CMlngvsfChipCntOKRow          As Integer = 1                  '良品件数
    Private Const CMlngvsfChipCntAllNGRow       As Integer = 2                  '総不良品件数
    Private Const CMlngvsfChipCntNowNGRow       As Integer = 3                  '現不良品件数
    Private Const CMlngvsfChipCntAllFWRow       As Integer = 4                  '総払出品件数
    Private Const CMlngvsfChipCntNowFWRow       As Integer = 5                  '現払出品件数
    Private Const CMlngvsfChipCntOKRowL         As Integer = 6                  '良品-左
    Private Const CMlngvsfChipCntOKRowR         As Integer = 7                  '良品-右
    Private Const CMlngvsfChipCntNGRowL         As Integer = 8                  '不良-左
    Private Const CMlngvsfChipCntNGRowR         As Integer = 9                  '不良-右
    Private Const CMlngvsfChipCntNowNGRowL      As Integer = 10                 '現不良-左
    Private Const CMlngvsfChipCntNowNGRowR      As Integer = 11                 '現不良-右
    Private Const CMlngvsfChipCntTitleHeight    As Integer = 18                 'ﾀｲﾄﾙ高さ
    Private Const CMlngvsfChipCntRowHeight      As Integer = 23                 '高さ
    Private Const CMlngvsfChipCntHeight         As Integer = 137                'ｸﾞﾘｯﾄﾞの高さ(無機以外)
    Private Const CMlngvsfChipCntHeightVA       As Integer = 229                'ｸﾞﾘｯﾄﾞの高さ(無機)
    Private Const CMlngvsfChipCntRows           As Integer = 6                  '行数(無機以外)
    Private Const CMlngvsfChipCntRowsVA         As Integer = 12                 '行数(無機)
    Private Const CMstrItemNameOK_L             As String = "良品-左"           '良品-左
    Private Const CMstrItemNameOK_R             As String = "良品-右"           '良品-右
    Private Const CMstrItemNameNG_L             As String = "不良-左"           '不良-左
    Private Const CMstrItemNameNG_R             As String = "不良-右"           '不良-右
    Private Const CMstrItemNameNowNG_L          As String = "現不良-左"         '現不良-左
    Private Const CMstrItemNameNowNG_R          As String = "現不良-右"         '現不良-右
    Private Const CMstrItemNameOK               As String = "良品"              '良品
    Private Const CMstrItemNameNG               As String = "不良"              '不良
    Private Const CMstrItemNameNowNG            As String = "現不良"            '現不良
    Private Const CMstrItemNameAllFW            As String = "総払出"            '総払出
    Private Const CMstrItemNameNowFW            As String = "現払出"            '現払出

    '@不良/払出ｺｰﾄﾞ情報
    Private Const CMlngvsfScpListCode           As Integer = 0                  '不良/払出ｺｰﾄﾞ
    Private Const CMlngvsfScpListName           As Integer = 1                  '不良/払出名称
    Private Const CMlngvsfScpListScrapNum       As Integer = 2                  '不良/払出数
    Private Const CMlngvsfScpListHeight         As Integer = 23                 '行の高さ
    Private Const CMlngvsfScpListTitleHeight    As Integer = 20                 'ﾀｲﾄﾙ行の高さ
    Private Const CMlngvsfScpListHeightN        As Integer = 402                'ｸﾞﾘｯﾄﾞの高さ(無機以外)
    Private Const CMlngvsfScpListHeightVA       As Integer = 310                'ｸﾞﾘｯﾄﾞの高さ(無機)
    Private Const CMlngvsfScpListTopN           As Integer = 206                'ｸﾞﾘｯﾄﾞのTop(無機以外)
    Private Const CMlngvsfScpListTopVA          As Integer = 298                'ｸﾞﾘｯﾄﾞのTop(無機)


    '@ﾁｯﾌﾟ情報
    Private Const CMlngvsfChipMapNo             As Integer = 0                  '№
    Private Const CMlngvsfChipMapTitleHeight    As Integer = 26                 'ﾀｲﾄﾙ行の高さ
    Private Const CMlngvsfChipMapTitleWidth     As Integer = 20                 'ﾀｲﾄﾙ行の幅
    Private Const CMlngvsfChipMapRowHeightMin   As Integer = 27                 '行の高さの最小値
    Private Const CMlngvsfChipMapColWidthMin    As Integer = 48                 '列の幅の最小値
    Private Const CMlngvsfChipMapNomalHeight    As Integer = 542                '標準高さ
    Private Const CMlngvsfChipMapNomalWidth     As Integer = 646                '標準幅
    Private Const CMlngvsfChipMapNomalMaxRows   As Integer = 19                 '標準行数
    Private Const CMlngvsfChipMapNomalMaxCols   As Integer = 13                 '標準列数

    '@色宣言
    Private Const CMlngGlayColor                As Integer = &H80000004         '灰色
    Private Const CMlngWhiteColor               As Integer = &H80000005         '白
    Private Const CMlngBlackColor               As Integer = &H80000008         '黒
    Private Const CMlngEnableFalseColor         As Integer = &HE3E3E3           '灰色(使用不可)
    Private Const CMlngEnableTrueColor          As Integer = &H80000005         '白(使用可)
    Private Const CMlngChipNoForeColor          As Integer = &H808080           '灰色(ﾁｯﾌﾟ№文字色)
    Private Const CMlngKeikouColor              As Integer = &H80FFFF           'ﾚﾓﾝ色(既傾向色)
    Private Const CMlngKeikouColorNow           As Integer = &H297EE            '山吹色(現工程傾向色)
    Private Const CMlngFuryouColor              As Integer = &HC0C0FF           'ﾋﾟﾝｸ(既不良色)
    Private Const CMlngFuryouColorNow           As Integer = &H6320E4           '赤ﾋﾟﾝｸ(現工程不良色)
    Private Const CMlngHaraidashiColor          As Integer = &HC0FFC0           '薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ(既払出色)
    Private Const CMlngHaraidashiColorNow       As Integer = &H80FF80           'ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ(現工程払出色)
    Private Const CMlngReferOnlyColor           As Integer = &H80000016         '薄灰色(参照のみ)
    Private Const CMlngChipOmoteBackColor       As Integer = &H404040           '濃い灰色(ﾁｯﾌﾟ用表表示時の概観ﾊﾞｯｸｶﾗｰ)
    Private Const CMlngChipUraBackColor         As Integer = &H404080           '小豆色(ﾁｯﾌﾟ用裏表示時の概観ﾊﾞｯｸｶﾗｰ)
    Private Const CMlngEleOmoteBackColor        As Integer = &H400000           '紺色(電特結果用表表示時の概観ﾊﾞｯｸｶﾗｰ)
    Private Const CMlngEleUraBackColor          As Integer = &H4040&            '抹茶色(電特結果用裏表示時の概観ﾊﾞｯｸｶﾗｰ)
    Private Const CMlngWaistOmoteBackColor      As Integer = &H808000           'ﾋﾞﾘｼﾞｱﾝ(WAIST結果用表表示時の概観ﾊﾞｯｸｶﾗｰ)
    Private Const CMlngWaistUraBackColor        As Integer = &H800080           '深紫色(WAIST結果用裏表示時の概観ﾊﾞｯｸｶﾗｰ)
    Private Const CMlngCandidacyBackColor       As Integer = &HFFFFC0           '水色(適用候補表示用ﾊﾞｯｸｶﾗｰ)

    '@ｱｽｷｰｺｰﾄﾞ宣言
    Private Const CMlngKeyCodeA                 As Integer = 65                 '"A"文字

    '@表裏区分宣言
    Private Const CMstrCmdHyouriKbn1            As String = "表へ"              '表裏ｺﾏﾝﾄﾞ
    Private Const CMstrCmdHyouriKbn2            As String = "裏へ"              '表裏ｺﾏﾝﾄﾞ

    '@電特区分宣言
    Private Const CMstrCmdDentokuKbn1           As String = "電特結果へ"        '電特ｺﾏﾝﾄﾞ
    Private Const CMstrCmdDentokuKbn2           As String = "ﾁｯﾌﾟ登録へ"        '電特ｺﾏﾝﾄﾞ

    '@表示区分宣言
    Private Const CMstrCmdDisplayKbn1           As String = "全体表示"          '表示区分ｺﾏﾝﾄﾞ(Map拡大⇔Map全体)
    Private Const CMstrCmdDisplayKbn2           As String = "拡大表示"          '表示区分ｺﾏﾝﾄﾞ(Map拡大⇔Map全体)
    Private Const CMstrCmdDispForward           As String = "払出適用"          '表示区分ｺﾏﾝﾄﾞ(不良適用⇔払出適用)
    Private Const CMstrCmdDispFuryou            As String = "不良適用"          '表示区分ｺﾏﾝﾄﾞ(不良適用⇔払出適用)

    '@入力ﾁｪｯｸ区分宣言
    Private Const CMstrstrInputCheckKbn0        As String = ""                  '入力ﾁｪｯｸ区分(ﾁｯﾌﾟ情報未読込)
    Private Const CMstrstrInputCheckKbn1        As String = "1"                 '入力ﾁｪｯｸ区分(ﾁｯﾌﾟ情報未入力)
    Private Const CMstrstrInputCheckKbn2        As String = "2"                 '入力ﾁｪｯｸ区分(ﾁｯﾌﾟ情報入力済)

    '@測定結果宣言
    Private Const CMstrResultOK                 As String = "OK"                '測定結果OK
    Private Const CMstrResultNG                 As String = "NG"                '測定結果NG

    '@測定結果色宣言
    Private Const CMlngResultOKColor            As Integer = &HFFFFC0           '測定結果OK
    Private Const CMlngResultNGColor            As Integer = &HFFC0FF           '測定結果NG

    '@処理ﾎﾞﾀﾝ
    Private Const CMlngProcessKbn1              As Integer = 1                  'ﾁｯﾌﾟ登録
    Private Const CMlngProcessKbn2              As Integer = 2                  '電特結果表示
    Private Const CMlngProcessKbn3              As Integer = 3                  'WAIST結果表示

    '@WAISTﾃﾞｰﾀ状態
    Private Const CMstrWaistStatus0             As String = "0"                 '正常
    Private Const CMstrWaistStatus1             As String = "1"                 '入力ﾌｧｲﾙ作成中
    Private Const CMstrWaistStatus2             As String = "2"                 '入力ﾌｧｲﾙ作成異常
    Private Const CMstrWaistStatus3             As String = "3"                 'DB更新中
    Private Const CMstrWaistStatus4             As String = "4"                 'DB更新異常

    '@自工程更新ﾌﾗｸﾞ
    Private Const CMstrNowstepEditDisable       As String = "0"                 '自工程更新なし
    Private Const CMstrNowstepEditEnable        As String = "1"                 '自工程更新あり

    '@特殊流動中ﾌﾗｸﾞ用
    Private Const CMstrReworkFlag0              As String = "0"                 '特殊流動なし
    Private Const CMstrReworkFlag1              As String = "1"                 '分割先(子)特殊流動中
    Private Const CMstrReworkFlag2              As String = "2"                 '分割元(親)特殊流動中
    Private Const CMstrReworkFlag3              As String = "3"                 '全数特殊流動中
    Private Const CMstrReworkFinishFlag0        As String = "0"                 '特殊流動工程ﾌﾗｸﾞ_通常工程
    Private Const CMstrReworkFinishFlag1        As String = "1"                 '特殊流動工程ﾌﾗｸﾞ_最終工程
    Private Const CMlngReworkLen                As Integer = 3                  '特殊流動状態桁数
    Private Const CMlngReworkLen1               As Integer = 1                  '特殊流動桁
    Private Const CMlngReworkLen2               As Integer = 2                  '特殊流動桁
    Private Const CMlngReworkLen3               As Integer = 3                  '特殊流動桁
    Private Const CMstrRework0                  As String = "0"                 '特殊流動状態で使用
    Private Const CMstrRework1                  As String = "1"                 '特殊流動状態で使用
    Private Const CMstrRework2                  As String = "2"                 '特殊流動状態で使用

    '@画面表示ﾒｯｾｰｼﾞ用
    Private Const CMstrMsgSpecialR              As String = "リワーク"          'リワーク
    Private Const CMstrMsgSpecialA              As String = "追加流動"          '追加流動

    '@その他宣言
    Private Const CMlngCarrierMaxLength         As Integer = 6                  'ｷｬﾘｱIDの最大桁数
    Private Const CMstrOldClass5                As String = "5"                 '前工程値(5:傾向)

    '@定数宣言
    Private Const CMstrHandWork                 As String = "0"                 'ﾊﾝﾄﾞﾜｰｸ
    Private Const CMstrLotEventChip             As String = "1"                 'ﾁｯﾌﾟ
    Private Const CMstrLotEventMove             As String = "2"                 '移載
    Private Const CMstrLotEventLotOut           As String = "3"                 'ﾛｯﾄ終了

    '@WF情報取得中MSG用
    Private Const CMstrWFDataSelMsg             As String = "WFデータを読み込んでいます。"    'WFﾃﾞｰﾀ確認用

    '@DataMatrix用定数宣言
    Private Const CMstrDmStartChr               As String = "'"                 'DataMatrix入力開始文字
    Private Const CMstrDmBadSelectChr           As String = "B"                 '不良ｺｰﾄﾞ選択
    Private Const CMstrDmChipSelectChr          As String = "C"                 'ﾁｯﾌﾟ№選択
    Private Const CMstrDmBadApplyCmd            As String = "IBA"               '不良適用
    Private Const CMstrDmTendApplyCmd           As String = "ITA"               '傾向適用
    Private Const CMstrDmApplyCancelCmd         As String = "IAC"               '適用取消
    Private Const CMstrDmCancelCmd              As String = "IC"                '取消
    Private Const CMstrDmRegistCmd              As String = "IR"                '確定
    Private Const CMstrDmChipCancel             As String = "ICC"               'ﾁｯﾌﾟ選択ｷｬﾝｾﾙ
    Private Const CMstrDmWfIdSelectChr          As String = "WFID"              'WFID選択
    Private Const CMstrDmWfIdCondChr            As String = "#"                 'WFIDの8桁目
    Private Const CMlngDmWfIdCondChrPos         As Integer = 8                  'WFIDの8桁目
    Private Const CMlngDmWfIdCondLength         As Integer = 10                 'WFIDの桁数
    Private Const CMstrDmChipSelectFromat       As String = "000"               'ﾁｯﾌﾟ番号ﾌｫｰﾏｯﾄ
    Private Const CMstrDmErrMsgBadSelect        As String = "不良コード"        '不良ｺｰﾄﾞ選択
    Private Const CMstrDmErrMsgChipSelect       As String = "チップ"            'ﾁｯﾌﾟ№選択
    Private Const CMstrDmErrMsgCmdInput         As String = "操作コード"        '各ｺﾏﾝﾄﾞ
    Private Const CMstrDmCmdInput               As String = "BCR入力："         'BCR入力：
    Private Const CMstrDmBadSelectChrIN         As String = "不良ｺｰﾄﾞ(B)"       '不良ｺｰﾄﾞ選択
    Private Const CMstrDmChipSelectChrIN        As String = "ﾁｯﾌﾟ№(C)"         'ﾁｯﾌﾟ№選択
    Private Const CMstrDmBadApplyCmdIN          As String = "不良適用(IBA)"     '不良適用
    Private Const CMstrDmTendApplyCmdIN         As String = "傾向適用(ITA)"     '傾向適用
    Private Const CMstrDmApplyCancelCmdIN       As String = "適用取消(IAC)"     '適用取消
    Private Const CMstrDmCancelCmdIN            As String = "取消(IC)"          '取消
    Private Const CMstrDmRegistCmdIN            As String = "確定(IR)"          '確定
    Private Const CMstrDmChipCancelIN           As String = "ﾁｯﾌﾟ選択ｷｬﾝｾﾙ(ICC)" 'ﾁｯﾌﾟ選択ｷｬﾝｾﾙ
    Private Const CMstrDmWfIdSelectChrIN        As String = "WFID選択"          'WFID選択
    Private Const CMstrColon                    As String = ":"                 'ｺﾛﾝ

    '@WPID判別用
    '@↓2020/03/19 (Thu) 19:09:55 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrPakenWpId                As String = "H2PANEL"           'パ検WPID判別用(7文字判定)
    '@↑2020/03/19 (Thu) 19:09:55 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@欠損ﾁｯﾌﾟ用定数宣言
    Private Const CMlngLostChipNoLength         As Integer = 3                  '欠損ﾁｯﾌﾟ判定用ﾁｯﾌﾟ№文字数

    '@隅のWFID
    Private Const CMlngCornerWfNoSize           As Integer = 12                 '隅のWFIDｻｲｽﾞ(組立のみ)

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                 As String = "frmxxCM0080"               '自ﾌｫｰﾑ名
    Private Const CMstrTxtCarrierValidate       As String = "txtCarrier_Validate"       'ｷｬﾘｱ確定時処理
    Private Const CMstrVsfWFMapEnterCell        As String = "vsfWFMap_EnterCell"        'WFｽﾛｯﾄﾏｯﾌﾟｶﾚﾝﾄ行変更時処理
    Private Const CMstrOptProcessKbnClick       As String = "optProcessKbn_Click"       '処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝ選択時処理
    Private Const CMstrCmdRegistClick           As String = "cmdRegist_Click"           '確定ﾎﾞﾀﾝ押下時処理
    Private Const CMstrCmdMapDownLoadClick      As String = "cmdMapDownLoad_Click"      'ﾏｯﾌﾟ読込ﾎﾞﾀﾝ押下時処理
    Private Const CMstrPrvblnRegistAuthorityChk As String = "prvblnRegistAuthority_Chk" '権限ﾁｪｯｸ処理
    '@↓2020/03/19 (Thu) 16:43:02 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrPrvExclusionProcess      As String = "prvExclusionProcess"
    '@↑2020/03/19 (Thu) 16:43:02 Y.Yoneyama 「.Netへ反映未」 **************************************************


    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mblnFormStartKbn                    As Boolean                      'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動)
    Private mstrTaihiCarrierID                  As String                       'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrLotLastUpdate                   As String                       'ﾛｯﾄ最終更新日時
    Private mlblnRowHeigthOver                  As Boolean                      '高さｵｰﾊﾞｰ区分(True:ｵｰﾊﾞｰ,False:規定内)
    Private mlblnColWidthOver                   As Boolean                      '幅ｵｰﾊﾞｰ区分(True:ｵｰﾊﾞｰ,False:規定内)
    Private mlngWFNowIndex                      As Integer                      'WFﾏｯﾌﾟ情報の現在ｲﾝﾃﾞｯｸｽ(1～25)
    Private mlngAllDisplayRowHeigth             As Integer                      '全体表示時の1行の高さ
    Private mlngAllDisplayColWidth              As Integer                      '全体表示時の1列の幅
    Private mblnRightButton                     As Boolean                      'ﾏｳｽ右ﾎﾞﾀﾝ区分(True:右ｸﾘｯｸ,False:通常ｸﾘｯｸ)
    Private mblnTakeOverDispFlg                 As Boolean                      'ﾌｫｰﾑ初回表示ﾌﾗｸﾞ(True：2回目以降、False：初回)
    Private mstrSlotSize                        As String                       'ｽﾛｯﾄｻｲｽﾞ
    Private mstrLocalMenuKey                    As String                       'ﾒﾆｭｰｷｰ格納

    Private mlngWFAryCnt                        As Integer                      '配列数のWF数ｶｳﾝﾀ
    Private mblnNowNGLoadFlag                   As Boolean                      'WFﾃﾞｰﾀ読込中ﾌﾗｸﾞ(True:読込中,False:未読込)
    Private mlngWFCnt                           As Integer                      'WF数格納用

    Private mstrResult                          As String                       '確定結果判定用(1:ﾁｯﾌﾟ/2:WF移載/3:ﾛｯﾄｱｳﾄ)

    '@画面構造体情報
    '@ﾁｯﾌﾟGrid構造体
    Private mblnChipGridMap(,)                  As Boolean                      'ﾁｯﾌﾟGridのMAP情報
    Private mlngChipGridMaxRows                 As Integer                      'ﾁｯﾌﾟGridの最大行数
    Private mlngChipGridMaxCols                 As Integer                      'ﾁｯﾌﾟGridの最大列数

    '@ﾁｯﾌﾟGridの欠損ﾁｯﾌﾟ情報
    Private mstrChipGridLostChipId              As String                       'ﾁｯﾌﾟGridの欠損ﾁｯﾌﾟ情報("001,007,232,238"等の欠損ﾁｯﾌﾟ情報)

    '@ﾁｯﾌﾟ情報
    Private Structure LotWFChipInfo
        Dim blnEnableKbn                            As Boolean                      '使用可能区分(True:使用可能、False:使用不可)→　ﾊﾞｯｸｶﾗｰと同様
        Dim blnLostChipKbn                          As Boolean                      '欠損ﾁｯﾌﾟ区分(False:通常ﾁｯﾌﾟ、True:欠損ﾁｯﾌﾟ)
        Dim strChipId                               As String                       'ﾁｯﾌﾟID
        Dim strOldClass                             As String                       '現工程変更前区分(1:良品、2:不良、3:払い出し、4:保留、5:傾向)
        Dim strOldClassID                           As String                       '現工程変更前項目ID
        Dim strOldNowstepEditFlag                   As String                       '現工程変更前更新ﾌﾗｸﾞ(0:自工程更新なし、1:自工程更新あり)
        Dim strNewClass                             As String                       '現工程変更後区分(1:良品、2:不良、3:払い出し、4:保留、5:傾向)
        Dim strNewClassID                           As String                       '現工程変更後項目ID
        Dim strNewNowstepEditFlag                   As String                       '現工程変更後更新ﾌﾗｸﾞ(0:自工程更新なし、1:自工程更新あり)
        Dim strEleCode                              As String                       '電特ｺｰﾄﾞ
        Dim strEleGrade                             As String                       '電特ｸﾞﾚｰﾄﾞ
        Dim strWaistStatus                          As String                       'WAIST状態
        Dim strWaistCode                            As String                       'WAISTｺｰﾄﾞ
        Dim strBefoerClass                          As String                       '前工程最新区分
        Dim strBefoerClassID                        As String                       '前工程最新区分ID
    End Structure

    '@WF情報
    Private Structure LotWFInfo
        Dim strWfId                                 As String                       'WFID
        Dim strSlotPosition                         As String                       'WFｽﾛｯﾄ№
        Dim strClass                                As String                       '区分
        Dim strClassID                              As String                       '項目ID
        Dim typChipList(,)                          As LotWFChipInfo                'ﾁｯﾌﾟ情報ﾘｽﾄ
        Dim strInputCheckKbn                        As String                       '入力ﾁｪｯｸ区分(空白:ﾁｯﾌﾟ情報が未読込み、1:未入力、2:入力済)
        Dim strResult                               As String                       '測定結果
        Dim strWFChipQuantity                       As String                       '良品数量
        Dim strWFChipOutQuantity                    As String                       '総不良数量
        Dim strWFChipCurrentOutQuantity             As String                       '現不良数量
        Dim strWFChipForwardQuantity                As String                       '総払出数量
        Dim strWFChipCurrentForwardQuantity         As String                       '現払出数量
        Dim strChipQuantityLotL                     As String                       '良品ﾁｯﾌﾟ数LOT-左
        Dim strChipQuantityLotR                     As String                       '良品ﾁｯﾌﾟ数LOT-右
        Dim strChipQuantityWfL                      As String                       '良品ﾁｯﾌﾟ数WF-左
        Dim strChipQuantityWfR                      As String                       '良品ﾁｯﾌﾟ数WF-右
        Dim strChipOutQuantityLotL                  As String                       '不良数LOT-左
        Dim strChipOutQuantityLotR                  As String                       '不良数LOT-右
        Dim strChipOutQuantityWfL                   As String                       '不良数WF-左
        Dim strChipOutQuantityWfR                   As String                       '不良数WF-右
        Dim strChipCurrentOutQuantityLotL           As String                       '現工程不良数LOT-左
        Dim strChipCurrentOutQuantityLotR           As String                       '現工程不良数LOT-右
        Dim strChipCurrentOutQuantityWfL            As String                       '現工程不良数Wf-左
        Dim strChipCurrentOutQuantityWfR            As String                       '現工程不良数Wf-右
        Dim strToSlotPosition                       As String                       '移載先ｽﾛｯﾄ№
        Dim strCfWfID                               As String                       'CF_WF_ID
    End Structure
    Private mtypWFInfo()                        As LotWFInfo                    'WF情報ﾘｽﾄ

    '@不良ｺｰﾄﾞ項目一覧
    Private mtypMasScpList                      As MasItemList                  '不良ｺｰﾄﾞﾘｽﾄ
    Private mtypMasWaistList                    As MasItemList                  'WAIST機用項目ｺｰﾄﾞﾘｽﾄ
    Private mtypMasScpClearList                 As MasItemList                  '不良ｺｰﾄﾞ初期化用ｺｰﾄﾞﾘｽﾄ

    '@WP_TYPE
    Private mblnCopyOFF                         As Boolean                      '転写機能OFF判定ﾌﾗｸﾞ(True:ｺﾋﾟｰしない)

    '@DataMatrix用変数宣言
    Private mblnDmCodeKeyDownFlag               As Boolean                      'DataMatrixのEnterﾌﾗｸﾞ(False:未Enter、True：Enter発行)
    Private mstrDmCodeCommand                   As String                       'DataMatrix入力ｺﾏﾝﾄﾞ
    Private mstrDmSelectChipNo()                As String                       'DataMatrix入力での選択ﾁｯﾌﾟ№配列
    Private mlngDmSelectChipNoMaxCnt            As Integer                      'DataMatrix入力での選択ﾁｯﾌﾟ№配列要素数

    '@ﾛｯﾄ種別判別用
    Private mstrLotFlowClass                    As String                       'ﾛｯﾄ種別(0:初期値、1:PR/ES、2:PR/ES以外)

    '@WF不良/払出権限ﾁｪｯｸ用
    Private mblnFuryouClass                     As Boolean                      '不良存在判定ﾌﾗｸﾞ(True：不良あり、False：不良なし)
    Private mblnHaraidashiClass                 As Boolean                      '払出存在判定ﾌﾗｸﾞ(True：払出あり、False：払出なし)

    '@↓2020/03/19 (Thu) 15:41:10 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private mstrPanelInspectType                As String                       'ﾊﾟﾈﾙ検査種類
    '@↑2020/03/19 (Thu) 15:41:10 Y.Yoneyama 「.Netへ反映未」 **************************************************

    Private buttonProcessing                    As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                      'NSYS WindowCloseフラグ


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
    '======================================Private==========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 16:22:35 T.Kitagawa
    '更新日：2009/09/02 (Wed) 17:05:23 N.Kojima
    '備　考：
    '　　　：2004/11/04 (Thu) 12:02:55 T.Kitagawa　 子画面起動の場合はForm_Loadﾌﾗｸﾞが常に正常になってしまうので、
    '　　　　                                       単体起動のみ設定するように変更
    '　　　：2005/01/17 (Mon) 12:56:50 H.Wajima     ﾁｯﾌﾟ状態自工程更新時表示色変更対応
    '　　　：2005/08/05 (Fri) 10:03:00 N.Kasai      状態変更機能制限(工程/ｽﾀｯﾌ&開発)
    '　　　：2008/04/25 (Fri) 09:45:21 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2009/03/31 (Tue) 14:37:53 N.Kojima     ﾁｯﾌﾟ払出対応に伴い処理追加/変更。(案件№03434)
    '　　　：2009/07/16 (Thu) 19:12:58 N.Kojima     送品待ちﾛｯﾄのﾁｯﾌﾟ状態確認時にｼｽﾃﾑｴﾗｰになる件を修正。(案件№03674)
    '　　　：2009/09/02 (Wed) 17:05:23 N.Kojima     不良ﾁｯﾌﾟ情報(№表示)対応。※不良ﾁｯﾌﾟについて、不良ｺｰﾄﾞではなくﾁｯﾌﾟ№で表示する。(案件№03685)
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値格納用

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①起動区分別、端末起動区分別、機能Ver判定処理
            '@　　②各種ｺﾝﾄﾛｰﾙ、変数の初期化処理
            '@　　③画面起動別初期処理(初期化、情報取得等)
            '@======================================================================================
            
            '@起動区分が"1：不良ﾁｯﾌﾟ情報(№表示)起動"か
            If plngfrmxxCM0080Kbn = CPlngNumOne Then

                '@機能IDｾｯﾄ
                mstrLocalMenuKey = CPstrKeyEN02G0
                
                '@=======================
                '@ 機能ﾊﾞｰｼﾞｮﾝ判定(不良ﾁｯﾌﾟ情報(№表示))
                '@=======================
                lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02G0, CMstrLocalVersion)
                
                '@処理結果判定
                If lblnAns = False Then
                    '@結果：異常の場合
                    Exit Sub
                End If

            Else
                '@起動区分が"1：不良ﾁｯﾌﾟ情報(№表示)起動"以外の場合(ﾁｯﾌﾟ状態変更系)

                '@★ 端末(起動)区分(M:工程端末、S:ｽﾀｯﾌ端末、A:開発)により処理分岐 ★
                Select Case pstrTerminalMode
                    
            
                    '@〓 工程端末(M)で起動 〓
                    Case CPstrManufactureStatus
                    
                        '@機能IDｾｯﾄ
                        mstrLocalMenuKey = CPstrKeyEN0190
                        
                        '@=======================
                        '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理(ﾁｯﾌﾟ状態変更登録)
                        '@=======================
                        lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0190, CMstrLocalVersion)
                        
                        '@処理結果判定
                        If lblnAns = False Then
                            '@結果：異常の場合
                            Exit Sub
                        End If
                    
                    
                    '@〓 ｽﾀｯﾌ(S) or 開発(A)で起動 〓
                    Case Else
            
                        '@機能IDｾｯﾄ
                        mstrLocalMenuKey = CPstrKeyEN01Q0
                        
                        '@=======================
                        '@ 機能ﾊﾞｰｼﾞｮﾝ判定(ﾁｯﾌﾟ状態変更登録(上書き))
                        '@=======================
                        lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01Q0, CMstrLocalVersion)
                        
                        '@処理結果判定
                        If lblnAns = False Then
                            '@結果：異常の場合
                            Exit Sub
                        End If
                        
                End Select
            End If

            '@ﾌｫｰﾑ起動区分を退避
            mblnFormStartKbn = pblnfrmxxCM0080Kbn
                
            '@=======================
            '@ 画面初期化処理
            '@=======================
            '画面表示位置
            Me.StartPosition = FormStartPosition.Manual
            Me.Top = 0
            Me.Left = 0 - My.Settings.FormOffset

            Call prvFrmxxCM0080_Init()

            '@=======================
            '@ 各種ﾎﾞﾀﾝ・ｸﾞﾘｯﾄﾞの制御処理(無効化)
            '@=======================
            Call prvFrmxxCM0080_CmbInit(False)
            
            '@傾向色、不良色、保留色、払出色の設定
            lblKeikouOld.BackColor = ColorTranslator.FromWin32(CMlngKeikouColor)               'ﾚﾓﾝ色(既傾向色)
            lblKeikouNew.BackColor = ColorTranslator.FromWin32(CMlngKeikouColorNow)            '山吹色(現工程傾向色)
            lblFuryouOld.BackColor = ColorTranslator.FromWin32(CMlngFuryouColor)               'ﾋﾟﾝｸ色(既不良色)
            lblFuryouNew.BackColor = ColorTranslator.FromWin32(CMlngFuryouColorNow)            '赤ﾋﾟﾝｸ(現工程不良色)
            lblHaraidashiOld.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColor)       '薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ(既払出色)
            lblHaraidashiNew.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColorNow)    'ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ(現工程払出色)
            
            '@単独起動か(ﾌｫｰﾑ起動区分判定)
            If mblnFormStartKbn = False Then
                '@単体起動の場合
                
                '@ｷｬﾘｱIDを使用可能
                txtCarrier.Enabled = True
                txtCarrier.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                
                '@引継ぎ情報初期化
                With ptypCommonInfo

                    .strCarrierId = vbNullString        'ｷｬﾘｱID
                    .strDivision = vbNullString         '起動区分
                    .strLotID = vbNullString            'ﾛｯﾄID
                    .strOpID = vbNullString             '大工程ID
                    .strStepID = vbNullString           '小工程ID
                    .strWpID = vbNullString             '装置ID
                    .strWpName = vbNullString           '装置名
                End With
                
                '@Form_Loadﾌﾗｸﾞ(正常)
                pblnFormLoad = True
            Else
                '@子画面起動の場合
                
                '@ｷｬﾘｱIDを使用不可能
                With txtCarrier

                    .Enabled = True
                    .Locked = True
                    .TabStop = False
                    .BackColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                    .GotBackColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                    .GotHighLight = False
                    .Text = ptypCommonInfo.strCarrierId
                End With
            End If
            
            '@閉じるﾎﾞﾀﾝのCausesValidation値を"False：ﾁｪｯｸ無し"に設定
            cmdClose.CausesValidation = False
            
            '@ﾌｫｰﾑ初回表示ﾌﾗｸﾞに"False：初回"をｾｯﾄ
            mblnTakeOverDispFlg = False

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：起動成功"をｾｯﾄ
            pblnFormLoad = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 16:13:24 H.Wajima
    '更新日：2019/10/25 (Fri) 15:54:26 T.Oide
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        
        Dim lblnAns     As Boolean          '戻り値格納用
        
        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①"S"or"A"：ｽﾀｯﾌ、管理端末起動時の作業者名取得処理
            '@　　②引継ぎｷｬﾘｱID"あり"の場合の情報取得処理
            '@======================================================================================


            '@ﾌｫｰﾑ初回表示ﾌﾗｸﾞが"True：2回目以降"か(FormLoad後、最初の1回しか処理しない)
            If mblnTakeOverDispFlg = True Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ初回表示ﾌﾗｸﾞに"True：2回目以降"をｾｯﾄ
            mblnTakeOverDispFlg = True

            '@M：工程端末以外からの起動か
            If pstrTerminalMode <> CPstrManufactureStatus Then
                '@S(ｽﾀｯﾌ)端末、A(管理者端末)での起動の場合
            
                '@Local起動か
                If pstrApoCode <> vbNullString Then
                    '@Local起動の場合
                    
                    '@basxxGC0010.pubstrGetUserNameで取得したAPOｺｰﾄﾞを格納
                    pstrUserID = pstrApoCode
                Else
                    '@Meta起動の場合
                
                    '@basxxCM0060.pubstrGetComputerNameで取得したAPOｺｰﾄﾞを格納
                    pstrUserID = Mid$(pstrComputerName, 5, 7)
                    
        '@↓2019/10/25 (Fri) 15:39:19 T.Oide **************************************************
                    '@pstrUserIDが空の場合、またはjpxxxxxxxなどｺﾝﾋﾟｭｰﾀ名が取れてしまった場合は再度取直す
                    ' (VB6開発用の仮想環境に対応するための追加ｺｰﾄﾞ)
                    If Trim(pstrUserID) = vbNullString Or _
                       Trim(Mid$(pstrComputerName, 1, 3)) <> "apo" Then

                        pstrUserID = Mid$(pubstrGetUserName(), 5)
                    End If
        '@↑2019/10/25 (Fri) 15:39:19 T.Oide **************************************************
                    
                End If

                '@=======================
                '@【作業者名取得】ﾒｯｾｰｼﾞ送受信処理
                '@=======================
                lblnAns = pubblnMasEmpName_Sel(CMstrmas_empname_Ver, _
                                               pstrUserID, _
                                               pstrUserName, _
                                               pstrDeptID, _
                                               pstrDeptName, _
                                               pstrGroupID)
            
                '@通信結果判定
                If lblnAns = False Then
                    '@結果：失敗の場合
                    
                    '@各Public変数を初期化
                    pstrUserID = vbNullString       'ﾕｰｻﾞｰID
                    pstrUserName = vbNullString     'ﾕｰｻﾞｰ名
                    pstrDeptID = vbNullString       '職場ID
                    pstrDeptName = vbNullString     '職場名
                    pstrGroupID = vbNullString      '所属ｸﾞﾙｰﾌﾟID
                    
                    '@=======================
                    '@ 閉じるﾎﾞﾀﾝ押下処理
                    '@=======================
                    Call cmdClose_Click(cmdClose, New EventArgs())
                    
                    Exit Sub
                End If
            End If

            '@引数のｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@NULL以外の場合
                
                '@ｷｬﾘｱIDの初期値を設定する
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                
                '@==============================
                '@ ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                '@==============================
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
            Else
                '@NULLの場合
            
                '@引継ぎｷｬﾘｱIDの初期化
                ptypCommonInfo.strCarrierId = vbNullString
            End If

            'NSYS Activate中にpublngMsgBox等で別ウィンドウを表示するとActivateがキャンセルされるため、再Activateする
            'NSYS Activateイベント中にActivate()を呼び出しても作用しないため、遅延で実行する。ラムダ式使用
            Dim lfuncActivate As Action = Sub()
                                              Me.Activate()
                                          End Sub
            Me.BeginInvoke(lfuncActivate)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "Form_Activate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 16:22:35 T.Kitagawa
    '更新日：2008/04/25 (Fri) 10:02:26 N.Kojima
    '備　考：
    '　　　：2004/09/13 (Mon) 10:08:51 Y.Yamagishi　ﾁｯﾌﾟMap上でEnter押下で不良、傾向適用は今のところ不可とする
    '　　　　                                       今後可能となるかもしれないので、ｺﾒﾝﾄにしておきます。
    '　　　：2005/05/30 (Mon) 14:02:54 S.Deguchi    ｾｯﾄﾌｫｰｶｽ対応処理追加
    '　　　：2006/06/23 (Fri) 13:10:29 T.Kitagawa   DataMatrixｺｰﾄﾞ(ﾊﾞｰｺｰﾄﾞ)対応(ﾕｰｻﾞ要望№0209)
    '　　　：2008/04/25 (Fri) 10:02:26 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ別、Enterｷｰ押下処理
            '@　　　⇒対象ｺﾝﾄﾛｰﾙのValidate処理を行う。
            '@　　③定義されていないｺﾝﾄﾛｰﾙのﾌｫｰｶｽ遷移処理
            '@======================================================================================
            
            
            '@以下の条件の場合、処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑのﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
                
                '@〓 ｷｬﾘｱID 〓
                Case txtCarrier.Name
                    
                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                        
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                            
                            '@=======================
                            '@ ｷｬﾘｱIDのValidate処理
                            '@=======================
                            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate

                    End Select


                '@〓 ｽｷｬﾅ入力 〓
                Case txtDmCode.Name
                    
                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode

                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                            
                            '@DataMatrixのEnterﾌﾗｸﾞに"True：Enter発行"をｾｯﾄ
                            mblnDmCodeKeyDownFlag = True
                            
                            '@=======================
                            '@ ｽｷｬﾅ入力のValidate処理
                            '@=======================
                            RemoveHandler txtDmCode.Validating, AddressOf txtDmCode_Validate
                            Call txtDmCode_Validate(txtDmCode, New CancelEventArgs(True))   'ﾌｫｰｶｽ保持
                            AddHandler txtDmCode.Validating, AddressOf txtDmCode_Validate
                            
                            '@DataMatrixのEnterﾌﾗｸﾞに"False:未Enter"をｾｯﾄ
                            mblnDmCodeKeyDownFlag = False
                            
                            '@ﾌｫｰｶｽ＆ﾊｲﾗｲﾄ処理
                            Call pubSetFocus(txtDmCode)     'ｽｷｬﾅ入力ﾃｷｽﾄ
                            Call pubHighlight(txtDmCode)
                    End Select


                '@〓 その他 〓
                Case Else
                    
                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode

                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                            
                            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True

                    End Select
            
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "Form_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyPress
    '機　能：ﾌｫｰﾑ　ｷｰ押下時処理
    '引　数：KeyAscii   ：入力ｱｽｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2006/06/23 (Fri) 13:16:57 T.Kitagawa
    '更新日：2008/04/25 (Fri) 10:10:26 N.Kojima
    '備　考：
    '　　　：2006/06/23 (Fri) 13:16:57 T.Kitagawa   DataMatrixｺｰﾄﾞ(ﾊﾞｰｺｰﾄﾞ)対応(ﾕｰｻﾞ要望№0209)
    '　　　：2008/04/25 (Fri) 10:10:26 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress

        Dim lstrKeyAsciiChar          As String         'KeyAscii文字
        
        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①ANSI文字ｺｰﾄﾞの変換
            '@　　②ｽｷｬﾝ入力ﾃｷｽﾄ関連の処理
            '@======================================================================================
            
            
            '@入力値のｷｬﾗｸﾀｰ文字変換
            lstrKeyAsciiChar = Chr(Asc(e.KeyChar))
            
            '@DataMatrix入力開始文字が"'"か
            If lstrKeyAsciiChar = CMstrDmStartChr Then
                
                '@開始文字をｸﾘｱする
                e.Handled = True
                
                '@ｽｷｬﾅ入力が有効か
                If txtDmCode.Enabled = True Then

                    '@前入力ｺｰﾄﾞをｸﾘｱし、ｽｷｬﾝ入力にﾌｫｰｶｽｾｯﾄ
                    txtDmCode.Text = vbNullString
                    Call pubSetFocus(txtDmCode)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "Form_KeyPress"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 14:47:14 T.Kitagawa
    '更新日：2009/09/02 (Wed) 17:05:23 N.Kojima
    '備　考：
    '　　　：2004/10/21 (Thu) 11:27:59 T.Kitagawa　 WAIST検査機対応
    '　　　：2004/10/26 (Tue) 10:47:25 T.Kitagawa　 DoEvents対応
    '　　　：2004/11/01 (Mon) 15:03:46 N.Kasai      閉じるﾎﾞﾀﾝ統合
    '　　　：2005/05/30 (Mon) 14:02:54 S.Deguchi    ｾｯﾄﾌｫｰｶｽ対応処理追加
    '　　　：2006/03/23 (Thu) 15:11:23 N.Kojima     最終更新日時の格納処理追加(ﾕｰｻﾞｰ要望№0145ﾃｽﾄ中に気付いた点の修正)。
    '　　　：2006/05/19 (Fri) 14:34:22 N.Kojima     不良数情報格納構造体の初期化処理追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2006/06/23 (Fri) 14:26:43 T.Kitagawa   DataMatrixｺｰﾄﾞ(ﾊﾞｰｺｰﾄﾞ)対応(ﾕｰｻﾞ要望№0209)
    '　　　：2006/07/11 (Tue) 17:15:11 T.Kitagawa   不良入力前の良品数を初期化する。(ﾕｰｻﾞ要望0210)
    '　　　：2008/04/25 (Fri) 09:52:20 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2009/09/02 (Wed) 17:05:23 N.Kojima     不良ﾁｯﾌﾟ情報(№表示)対応。※不良ﾁｯﾌﾟについて、不良ｺｰﾄﾞではなくﾁｯﾌﾟ№で表示する。(案件№03685)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try

            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①各種構造体、配列、変数の初期化
            '@　　②起動区分別、終了処理(ACT初期化、ﾒﾆｭｰ伸縮)
            '@　　③ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄの関連付け解除
            '@======================================================================================


            '@以下の条件の場合は、処理ｷｬﾝｾﾙ
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②DoEvents制御中の場合
            '@　③WFﾃﾞｰﾀ読込中の場合
            If pblnTrnFlag = True Or mblnNowNGLoadFlag = True Then
                e.Cancel = True
                Exit Sub
            End If

            '@ﾌｫｰﾑの"×"ﾎﾞﾀﾝでの終了要求か
            If mblnCloseFromControlMenu Then
            
                '@=======================
                '@ 閉じるﾎﾞﾀﾝ押下時処理
                '@=======================
                RemoveHandler Me.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler Me.FormClosing, AddressOf Form_QueryUnload

            End If
            
            '@最終更新日時を書換える
            ptypLotprestate.strLotLastUpdate = mstrLotLastUpdate
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@構造体、配列のｸﾘｱ
            Erase mtypWFInfo                                  'WF情報ﾘｽﾄ
            Erase mblnChipGridMap                             'ﾁｯﾌﾟﾏｯﾌﾟ配列
            Erase mstrDmSelectChipNo                          '選択ﾁｯﾌﾟ配列
            'Erase ptypLotScrapInfo.typWFScrapInfo()             'ﾛｯﾄ別不良ｺｰﾄﾞ別不良数ﾘｽﾄ
            If Not IsNothing(ptypLotScrapInfo.typWFScrapInfo) Then
                ptypLotScrapInfo.typWFScrapInfo.Clear()
            End If
            ptypLotScrapInfo.strLotOutQuantity = CPstrZero
            ptypLotScrapInfo.lngScrapInputBeforeChipCnt = 0
            
            'Erase ptypMasItemList.typeMasItem()                 '不良/傾向/保留/払出項目ﾘｽﾄ
            If Not IsNothing(ptypMasItemList.typeMasItem) Then
                ptypMasItemList.typeMasItem.Clear()
            End If
            ptypMasItemList.lngListCnt = 0
            ptypMasItemList.strLotEventId = CPstrZero
            
            '@不良ｺｰﾄﾞ項目ﾘｽﾄ、WAIST機用項目ｺｰﾄﾞﾘｽﾄのｸﾘｱ
            mtypMasScpList = mtypMasScpClearList
            mtypMasWaistList = mtypMasScpClearList


            '@起動区分の初期化
            plngfrmxxCM0080Kbn = CPlngNumZero

            '@単独起動か(単独起動の場合、ACT開放後、終了する)
            If mblnFormStartKbn = False Then
                
                '@Act初期化ﾌﾗｸﾞが"True:初期化済"か
                If pblnActInitFlg = True Then
                    '@Actを自前で初期化した場合
                    
                    '@=======================
                    '@ ACTｵﾌﾞｼﾞｪｸﾄ開放処理
                    '@=======================
                    lblnAnsTerm = pubblnAct_Term
                    
                    '@処理結果判定
                    If lblnAnsTerm = True Then
                        '@結果：正常の場合
                        '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                    End If
                Else
                    '@Act初期化ﾌﾗｸﾞが"False:未初期化"で、起動区分ﾌﾗｸﾞが単独起動の場合
                    If pblnfrmxxCM0080Kbn = False Then
                    
                        '@=======================
                        '@ ﾒｲﾝﾒﾆｭｰ画面拡張処理
                        '@=======================
                        Call pubMenuExpand_Disp()
                    End If
                End If
            End If
            
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/20 (Tue) 18:11:40 N.Kasai
    '更新日：2008/04/25 (Fri) 10:19:01 N.Kojima
    '備　考：
    '　　　：2008/04/25 (Fri) 10:19:01 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try

            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①単独起動時の画面の初期化処理
            '@　　②単独起動時の各種ﾎﾞﾀﾝ、ｸﾞﾘｯﾄﾞの制御処理
            '@======================================================================================
            

            '@単独起動か(ﾌｫｰﾑ起動区分判定)
            If mblnFormStartKbn = False Then
                
                '@=======================
                '@ 画面初期化処理
                '@ ※ｷｬﾘｱID変更時は情報をｸﾘｱする
                '@=======================
                Call prvFrmxxCM0080_Init()
                
                '@=======================
                '@ 各種ﾎﾞﾀﾝ、ｸﾞﾘｯﾄﾞの制御処理(無効化)
                '@=======================
                Call prvFrmxxCM0080_CmbInit(False)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "txtCarrier_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　Validate処理(入力確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 18:59:05 T.Kitagawa
    '更新日：2009/09/02 (Wed) 17:05:23 N.Kojima
    '備　考：
    '　　　：2004/09/03 (Fri) 13:30:08 T.Kitagawa　 不良入力項目取得Msg変更対応
    '　　　：2004/09/21 (Tue) 20:36:39 H.Wajima 　  不良ｺｰﾄﾞが0件の場合に、ﾒｯｾｰｼﾞ表示、ﾎﾞﾀﾝ押下不可(№653)
    '　　　：2004/09/24 (Fri) 10:17:53 S.Deguchi    ClassDivision：1T対応(不具合改善№572)
    '　　　：2004/10/20 (Wed) 15:17:23 T.Kitagawa   不良入力項目取得Msg変更対応
    '　　　：2004/10/21 (Thu) 15:30:03 T.Kitagawa   WAIST機対応
    '　　　：2004/11/25 (Thu) 11:07:28 S.Deguchi    WF情報取得ﾒｯｾｰｼﾞの処理区分を変更(0T⇒3N)
    '　　　：2005/03/01 (Tue) 10:38:09 S.Deguchi    不具合№261の対応でﾊﾝﾄﾞﾜｰｸ工程の処理分岐を追加
    '　　　：2005/05/20 (Fri) 09:06:52 S.Deguchi    不具合№820対応でﾛｯﾄ情報取得時に特殊流動最終工程の場合処理強制終了
    '　　　：2005/11/18 (Fri) 15:53:09 N.Kojima     ｺﾒﾝﾄﾎﾞﾀﾝは常時有効な状態にする。(ﾕｰｻﾞｰ要望№0119)
    '　　　：2006/03/08 (Wed) 17:31:28 N.Kojima     通常工程の処理中でもﾁｯﾌﾟ状態変更登録を行えるようにする。(ﾕｰｻﾞｰ要望№0145)
    '　　　：2006/05/23 (Tue) 14:14:54 N.Kojima     ①不良情報取得処理の移動。
    '　　　：                                       ②「現不良」ﾎﾞﾀﾝの活性化処理追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2006/06/06 (Tue) 17:16:45 N.Kojima     現不良格納配列の定義用にWF格納処理を追加。(運用障害№0831)
    '　　　：2006/06/23 (Fri) 17:09:15 T.Kitagawa   DataMatrixｺｰﾄﾞ(ﾊﾞｰｺｰﾄﾞ)対応(ﾕｰｻﾞ要望№0209)
    '　　　：2006/07/05 (Wed) 13:11:43 T.Kitagawa   不良ｺｰﾄﾞがｾﾞﾛ件の場合は「現不良」ﾎﾞﾀﾝを無効にする。(ﾕｰｻﾞｰ要望№0203のついでに対応)
    '　　　：2007/02/14 (Wed) 15:38:28 N.Kasai      処理中、後処理以外でもﾁｯﾌﾟ状態変更を可能とする。(№01739)
    '　　　：2007/02/27 (Tue) 13:22:28 N.Kasai      不良項目の有無ﾁｪｯｸ条件からﾛｯﾄ状態を削除
    '　　　：2008/01/28 (Mon) 14:38:52 N.Kojima     PR/ESﾛｯﾄのﾁｯﾌﾟ状態は、現状よりも良くする変更は禁止とする対応。(案件№02568)
    '　　　：2008/04/25 (Fri) 10:21:57 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2009/03/31 (Tue) 14:34:21 N.Kojima     ﾁｯﾌﾟ払出対応により処理追加。(案件№03434)
    '　　　：2009/09/02 (Wed) 17:05:23 N.Kojima     不良ﾁｯﾌﾟ情報(№表示)対応。※不良ﾁｯﾌﾟについて、不良ｺｰﾄﾞではなくﾁｯﾌﾟ№で表示する。(案件№03685)
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim ltypMasPdMap            As MasPdMapList         'ｽﾛｯﾄﾏｯﾌﾟ構造体
        Dim ltypWaferList           As Waferlist            'ﾛｯﾄWF情報構造体
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrRWEndFlag           As String               'ﾘﾜｰｸ最終工程判断ﾌﾗｸﾞ
        Dim lstrRWFlag              As String               'ﾘﾜｰｸ中ﾌﾗｸﾞ
        Dim lstrSelect              As String               '特殊流動名退避領域
        Dim lstrSBID                As String               'SBID
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim lblnNextCtrl            As Boolean              'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If (Not IsNothing(Me.ActiveControl) AndAlso Me.ActiveControl.Name = cmdClose.Name) OrElse mblnWindowClose = True Then
                Exit Sub
            End If

            ' NSYS フォーカス設定可能か判定
            If Me.ActiveControl.Name = txtCarrier.Name OrElse _
                Me.ActiveControl.Name = txtDmCode.Name Then
                ' 次コントロールがアクティブの場合
                lblnNextCtrl = True
            Else
                ' 次コントロール以外がアクティブの場合
                lblnNextCtrl = False
            End If
             
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①ｷｬﾘｱIDﾁｪｯｸ処理(NULLﾁｪｯｸ、6桁ﾁｪｯｸ、前入力ｷｬﾘｱIDとの比較)
            '@　　②画面情報の初期化、表示(WFｽﾛｯﾄﾏｯﾌﾟ、不良/払出ｺｰﾄﾞ一覧、ﾁｯﾌﾟ情報一覧、ﾁｯﾌﾟﾏｯﾌﾟetc...)
            '@　　③各種情報の取得(ﾛｯﾄ現在情報取得、ﾛｯﾄWF情報取得、機種ﾁｯﾌﾟﾏｯﾌﾟ取得、不良/払出ｺｰﾄﾞ情報取得)
            '@　　④各種ﾓｼﾞｭｰﾙ変数の設定(ﾛｯﾄ種別判定用変数、良品WF位置判定用変数etc...)
            '@　　⑤各ﾎﾞﾀﾝ、ｸﾞﾘｯﾄﾞの制御処理
            '@　　⑥各種ﾎﾞﾀﾝの制御処理(個別＆条件別)
            '@　　⑦ﾌｫｰｶｽ制御処理
            '@　　⑧起動区分が"1：不良ﾁｯﾌﾟ情報(№表示)"の場合の各種ｺﾝﾄﾛｰﾙ無効化処理
            '@======================================================================================
            
             
            '@単独起動か
            If mblnFormStartKbn = False Then
                '@単独起動の場合
                
                '@ｷｬﾘｱIDがNULLか
                If txtCarrier.Text = vbNullString Then
                    Exit Sub
                End If
                
                '@ｷｬﾘｱIDが6桁以外か
                If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                    '@"<TRM07W>$$キャリアIDは6桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    e.Cancel = True
                    Exit Sub
                End If
            End If
            
            '@ｷｬﾘｱIDがNULL以外で6桁、かつ入力ｷｬﾘｱIDと前回入力ｷｬﾘｱIDが異なるか
            If txtCarrier.Text <> vbNullString And _
                Len(txtCarrier.Text) = CMlngCarrierMaxLength And _
                txtCarrier.Text <> mstrTaihiCarrierID Then
                
                '@=======================
                '@ 画面情報初期化処理
                '@=======================
                Call prvFrmxxCM0080_Init()
                
                '@=======================
                '@ 各種ﾎﾞﾀﾝ、ｸﾞﾘｯﾄﾞの制御処理(無効化)
                '@=======================
                Call prvFrmxxCM0080_CmbInit(False)
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrTxtCarrierValidate)
                
                '@=======================
                '@【ﾛｯﾄ現在情報取得】ﾒｯｾｰｼﾞ送受信処理
                '@ ※処理区分=1T:ﾛｯﾄ現在状態取得(ﾁｯﾌﾟ処置登録)
                '@=======================
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                CPstrCD1T, _
                                                txtCarrier.Text, _
                                                ptypLotprestate)

                '@ﾛｯﾄ現在情報取得結果が"True：取得成功"か
                If lblnAns = True Then
                    '@結果：取得成功の場合

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrTxtCarrierValidate)
                    
                    With ptypLotprestate
                        
                        '@ﾛｯﾄ種別が"PR"or"ES"か
                        If .strFlowClass = CPstrFlowClassPR Or .strFlowClass = CPstrFlowClassES Then
                            
                            '@ﾛｯﾄ種別判定用変数に"1:PR/ES"を格納
                            mstrLotFlowClass = CPstrOne
                        Else
                            '@ﾛｯﾄ種別判定用変数に"2:PR/ES以外"を格納
                            mstrLotFlowClass = CPstrTwo
                        End If
                        
                        '@ﾘﾜｰｸﾌﾗｸﾞの退避
                        lstrRWEndFlag = Mid(.strReworkFlag, CMlngReworkLen1, CMlngReworkLen1)
                        lstrRWFlag = Mid(.strReworkFlag, CMlngReworkLen2, CMlngReworkLen1)
                        
                        '@子ﾛｯﾄが特殊流動中、かつ特殊流動の最終工程か
                        If lstrRWFlag = CMstrReworkFlag1 And lstrRWEndFlag = CMstrReworkFinishFlag1 Then
                            
                            '@ﾘﾜｰｸ中か
                            If .strReworkRouteID <> vbNullString Then
                                
                                '@特殊流動名に"ﾘﾜｰｸ"をｾｯﾄ
                                lstrSelect = CMstrMsgSpecialR
                            Else
                                '@ﾘﾜｰｸ中ではない場合
                                
                                '@追加流動中か
                                If .strSpecialRouteID <> vbNullString Then
                                    '@特殊流動名に"追加流動"をｾｯﾄ
                                    lstrSelect = CMstrMsgSpecialA
                                End If
                            End If
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005T, lstrSelect, Me.Text)
                            '@"<TRM5TW>$$[%1]の最終工程で[%2]できません。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Sub
                        End If
                    End With
                    
                    '@ｷｬﾘｱIDの退避
                    mstrTaihiCarrierID = txtCarrier.Text
                    
                    '@=======================
                    '@ 画面情報表示処理
                    '@=======================
                    Call prvFrmxxCM0080_Disp()
                    
                    '@--------------------------------------------------------
                    '@ 組立工程(2A0)で、かつﾛｯﾄ状態が"投入待ち"か
                    '@ ※受入在庫のｽﾛｯﾄﾏｯﾌﾟを表示する際はSBIDが基板で取得する。
                    '@--------------------------------------------------------
                    If pstrSBID = CPstrSBID2A0 And _
                        ptypLotprestate.strNowST = CPstrWaitThrowSt Then
                        
                        lstrSBID = CPstrSBID1A0
                    Else
                        lstrSBID = pstrSBID
                    End If
                    
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrTxtCarrierValidate)
                    
                    '@=======================
                    '@【機種ﾁｯﾌﾟﾏｯﾌﾟ取得】ﾒｯｾｰｼﾞ送受信処理
                    '@=======================
                    lblnAns = pubblnMasMapInfo_Sel(CMstrmas_mapinfo_Ver, _
                                                   ptypLotprestate.strPdId, _
                                                   lstrSBID, _
                                                   ltypMasPdMap)
                    
                    '@機種ﾁｯﾌﾟﾏｯﾌﾟ取得結果が"True：取得成功"か
                    If lblnAns = True Then
                        '@結果：取得成功の場合
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrTxtCarrierValidate)
                        
                        '@======================
                        '@ ﾁｯﾌﾟﾏｯﾌﾟの設定処理
                        '@======================
                        Call prvChipGridInfo_Set(ltypMasPdMap)
                    Else
                        '@機種ﾁｯﾌﾟﾏｯﾌﾟ取得結果が"False：取得失敗"の場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)

                        e.Cancel = True
                        Exit Sub
                    End If


                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrTxtCarrierValidate)
                    
                    '@=======================
                    '@【ﾛｯﾄWF情報取得】ﾒｯｾｰｼﾞ送受信処理
                    '@ ※処理区分=3N:ﾛｯﾄｳｪﾊ情報取得(全WF)
                    '@=======================
                    lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                                     txtCarrier.Text, _
                                                     CPstrCD3N, _
                                                     ltypWaferList)

                    '@ｽﾛｯﾄｻｲｽﾞ退避
                    mstrSlotSize = ltypWaferList.strSlotSize
                    
                    '@WF数を退避(現不良格納配列の定義用)
                    mlngWFCnt = ltypWaferList.lngListCnt
                    
                    '@ﾛｯﾄWF情報取得結果が"True：取得成功"か
                    If lblnAns = True Then
                        '@結果：取得成功の場合
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrTxtCarrierValidate)
                        
                        '@ｽｷｬﾝ入力ﾃｷｽﾄを有効にする
                        txtDmCode.Enabled = True
                        
                        '@=======================
                        '@ WFｽﾛｯﾄﾏｯﾌﾟ設定処理
                        '@=======================
                        Call prvLotWaferInfo_Set(ltypWaferList)
                    
                        '@WFｽﾛｯﾄﾏｯﾌﾟの初期設定
                        mlngWFNowIndex = 0
                        
                        '@WF構造体から良品WFのｽﾛｯﾄﾎﾟｼﾞｼｮﾝを検索
                        For llngCnt = 1 To CMlngvsfWFMapMaxSlotID 
                        
                            '@WFIDがNULL以外で、かつ不良/払出WF以外か
                            If mtypWFInfo(llngCnt-1).strWfId <> vbNullString And _
                                (mtypWFInfo(llngCnt-1).strClass <> CPstrClass2 _
                                Or mtypWFInfo(llngCnt-1).strClass <> CPstrClass3) Then
                                
                                mlngWFNowIndex = llngCnt   '良品WFの位置を記憶
                                
                                Exit For
                            End If
                        Next llngCnt
                        
                        '@WFｽﾛｯﾄﾏｯﾌﾟのｲﾝﾃﾞｯｸｽが0か
                        If mlngWFNowIndex = 0 Then
                            mlngWFNowIndex = 1
                        End If
                        
                    Else
                        '@ﾛｯﾄWF情報取得結果が"False：取得失敗"の場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)

                        e.Cancel = True
                        Exit Sub
                    End If
                    
                    
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrTxtCarrierValidate)
                    
                    '@=======================
                    '@【不良ｺｰﾄﾞ情報取得】ﾒｯｾｰｼﾞ送受信処理
                    '@ ※処理区分=3I:不良/払出情報取得(不良/払出項目ｾｯﾄID指定)
                    '@=======================
                    lblnAns = pubblnMasScpList_Sel(pstrSBID, _
                                                   CMstrmas_scplist_Ver, _
                                                   CPstrCD3I, _
                                                   ptypLotprestate.strLotScrapSetID, _
                                                   mtypMasScpList)

                    '@不良ｺｰﾄﾞ情報取得結果が"True：取得成功"か
                    If lblnAns = True Then
                        '@結果：取得成功の場合

                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrTxtCarrierValidate)

                        '@不良/払出ｺｰﾄﾞﾘｽﾄが0件以外か
                        If mtypMasScpList.lngListCnt <> 0 Then
                            
                            '@=======================
                            '@ 不良/払出ｺｰﾄﾞｸﾞﾘｯﾄﾞ設定処理
                            '@=======================
                            Call prvMasScpList_Set()

                        Else
                            '@不良/払出ｺｰﾄﾞﾘｽﾄが0件の場合
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002V)
                            '@"<TRM2VI>$$不良項目が設定されていないので、チップ状態変更登録はできません。"
                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                        
                        End If
                    Else
                        '@不良ｺｰﾄﾞ情報取得結果が"False：取得失敗"の場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)

                        e.Cancel = True
                        Exit Sub
                    End If
                    
                    '@WFｽﾛｯﾄﾏｯﾌﾟのｲﾝﾃﾞｯｸｽが1以上か
                    If mlngWFNowIndex > 0 Then
                        
                        '@ｲﾝﾃﾞｯｸｽに従い、初期ﾌｫｰｶｽ位置を設定
                        vsfWFMap.Row = CMlngvsfWFMapMaxSlotID - mlngWFNowIndex + 1
                    End If

                    '@Form_Loadﾌﾗｸﾞに"True:正常"をｾｯﾄ
                    pblnFormLoad = True

                    '@↓2020/03/19 (Thu) 17:01:20 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    '@【抜取・全数ﾁｪｯｸ】
                    Call prvExclusionProcess
                    '@↑2020/03/19 (Thu) 17:01:20 Y.Yoneyama 「.Netへ反映未」 **************************************************

                Else
                    '@ﾛｯﾄ現在情報取得結果が"False：取得失敗"の場合
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)

                    e.Cancel = True
                    Exit Sub
                End If
                        
                        
                '@★ 分岐条件がTrueかにより処理分岐 ★
                Select Case True
                    
                    '@〓 不良/払出ｺｰﾄﾞﾘｽﾄが0件 〓
                    Case mtypMasScpList.lngListCnt = 0
                        
                        '@=======================
                        '@ 各種ﾎﾞﾀﾝ、ｸﾞﾘｯﾄﾞの制御処理(無効化)
                        '@=======================
                        prvFrmxxCM0080_CmbInit (False)
                        
                        '@各種ｺﾝﾄﾛｰﾙの制御
                        fraProcessKbn.Enabled = True    '処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝﾌﾚｰﾑ
                        cmdHyouri.Enabled = True        '表へ/裏へﾎﾞﾀﾝ
                        cmdDisplayKbn.Enabled = True    '全体表示/拡大表示ﾎﾞﾀﾝ
                        vsfWFMap.Enabled = True         'WFｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ
                        vsfChipMap.Enabled = True       'ﾁｯﾌﾟﾏｯﾌﾟｸﾞﾘｯﾄﾞ
                    
                    
                    '@〓 不良/払出ｺｰﾄﾞﾘｽﾄが1件以上あり 〓
                    Case Else
                        
                        '@=======================
                        '@ 各種ﾎﾞﾀﾝ、ｸﾞﾘｯﾄﾞの制御処理(有効化)
                        '@=======================
                        Call prvFrmxxCM0080_CmbInit(True)

                End Select
                
                '@=======================
                '@ 各種ﾎﾞﾀﾝの制御処理(個別＆条件別)
                '@=======================
                Call prvCmdButtonEnable_Chk()

                '@ｺﾒﾝﾄﾎﾞﾀﾝを無効にする
                cmdComments.Enabled = True
                
                '@不良/払出ｺｰﾄﾞﾘｽﾄが1件以上あるか
                If mtypMasScpList.lngListCnt > 0 Then
                
                    '@現不良ﾎﾞﾀﾝを有効にする
                    cmdNowStepNG.Enabled = True
                Else
                    '@不良ｺｰﾄﾞﾘｽﾄが0件の場合
                
                    '@現不良ﾎﾞﾀﾝを無効にする
                    cmdNowStepNG.Enabled = False
                End If
            Else
                '@　①ｷｬﾘｱIDがNULL
                '@　②ｷｬﾘｱIDが6桁以外
                '@　③入力ｷｬﾘｱIDと前回入力ｷｬﾘｱIDが同じ
            
                '@ｽｷｬﾝ入力ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                If lblnNextCtrl Then
                    Call pubSetFocus(txtDmCode)
                End If
            End If
            
            '@起動区分が"1：不良ﾁｯﾌﾟ情報(№表示)起動"か
            If plngfrmxxCM0080Kbn = CPlngNumOne Then

                '@=======================
                '@ 不良ﾁｯﾌﾟ情報(№表示)起動時のｺﾝﾄﾛｰﾙ無効化処理
                '@=======================
                Call prvAnyControlDisable_Proc()

            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "txtCarrier_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtDmCode_Validate
    '機　能：DataMatrixｺｰﾄﾞ(ｽｷｬﾅ入力ﾃｷｽﾄ)　Validate処理(入力、読込み確定時処理)
    '引　数：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/02/03 (Fri) 13:15:55 N.Kasai
    '更新日：2009/09/02 (Wed) 17:05:23 N.Kojima
    '備　考：
    '　　　：2006/02/13 (Mon) 11:19:53 N.Kasai      ﾌｫｰｶｽの制御追加
    '　　　：2006/06/23 (Fri) 18:30:50 T.Kitagawa   DataMatrixｺｰﾄﾞ(ﾊﾞｰｺｰﾄﾞ)対応(ﾕｰｻﾞ要望№0209)
    '　　　：2006/07/03 (Mon) 13:37:54 T.Kitagawa   DataMatrixｺｰﾄﾞ(ﾊﾞｰｺｰﾄﾞ)の裏面入力も対応(ﾕｰｻﾞ要望№0209)
    '　　　：2006/07/27 (Thu) 15:36:22 T.Kitagawa   ﾁｯﾌﾟ№のｽｷｬﾅ入力時は、全体表示している場合、ShowCellしない様にする(案件№01355)
    '　　　：2008/04/25 (Fri) 11:11:44 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2009/09/02 (Wed) 17:05:23 N.Kojima     不良ﾁｯﾌﾟ情報(№表示)対応。※不良ﾁｯﾌﾟについて、不良ｺｰﾄﾞではなくﾁｯﾌﾟ№で表示する。(案件№03685)
    '　　　：2009/11/05 (Thu) 11:25:14 T.Oide       ﾊﾟ検入力漏れ対応
    Private Sub txtDmCode_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtDmCode.Validating
        
        Dim llngCnt                         As Integer      '汎用ｶｳﾝﾀ
        Dim llngCnt1                        As Integer      '汎用ｶｳﾝﾀ
        Dim llngCnt2                        As Integer      '汎用ｶｳﾝﾀ
        Dim lblnRtn                         As Boolean      '対象ﾃﾞｰﾀの有無判定用ﾌﾗｸﾞ(True:あり　False:なし)
        Dim lblnCfWf                        As Boolean      'CF_WFIDの設定の有無判定用ﾌﾗｸﾞ(True:CF設定　False:CF以外)
        Dim llngWfSelectRow                 As Integer      'WFID選択時のWFｽﾛｯﾄﾏｯﾌﾟの行
        Dim llngBadSelectRow                As Integer      '不良ｺｰﾄﾞ選択時の不良ｺｰﾄﾞ一覧行
        Dim llngChipSelectRow               As Integer      'ﾁｯﾌﾟ番号選択時のﾁｯﾌﾟｸﾞﾘｯﾄﾞ行
        Dim llngChipSelectCol               As Integer      'ﾁｯﾌﾟ番号選択時のﾁｯﾌﾟｸﾞﾘｯﾄﾞ列
        Dim llngDmSelectChipNoFindIndex     As Integer      'Dmﾁｯﾌﾟ選択配列の同一ﾁｯﾌﾟ番号Index
        Dim lblnInputCheck                  As Boolean      '画面入力ﾁｪｯｸ(True:正常,False:異常)
        Dim lstrBCRInput                    As String       'BCR入力値
        Dim ltypOnErrorInfoLog              As CommonOnErrorInfoLog     'ｴﾗｰﾛｸﾞ情報(暫定対応)
        Dim lblnNextCtrl                    As Boolean      'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            ' NSYS フォーカス設定可能か判定
            If Me.ActiveControl.Name = txtDmCode.Name OrElse _
                Me.ActiveControl.Name = optProcessKbn1.Name OrElse _
                Me.ActiveControl.Name = optProcessKbn2.Name OrElse _
                Me.ActiveControl.Name = optProcessKbn3.Name Then
                ' 次コントロールがアクティブの場合
                lblnNextCtrl = True
            Else
                ' 次コントロール以外がアクティブの場合
                lblnNextCtrl = False
            End If
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①入力ｺｰﾄﾞﾁｪｯｸ処理(Byte数ﾁｪｯｸ、NULLﾁｪｯｸ、ｺｰﾄﾞｴﾗｰﾁｪｯｸ)
            '@　　②入力ｺｰﾄﾞ別処理
            '@　　③DataMatrix入力ｺﾏﾝﾄﾞ別処理(適用関連処理、確定処理、各種背景色の制御etc...)
            '@　　④起動区分が"1：不良ﾁｯﾌﾟ情報(№表示)"の場合の各種ｺﾝﾄﾛｰﾙ無効化処理
            '@======================================================================================
            
            
            '@変数の初期化
            lblnRtn = False             '対象ﾃﾞｰﾀの有無判定用ﾌﾗｸﾞ
            lblnCfWf = False            'CF_WFIDの設定の有無判定用ﾌﾗｸﾞ
            mblnCopyOFF = False         '転写機能OFF判定ﾌﾗｸﾞ
            
            '@入力ｺｰﾄﾞが0Byte、またはNULLか
            If txtDmCode.NowByte = 0 Or txtDmCode.Text = vbNullString Then
                Exit Sub
            End If
            
            '@Dmｺｰﾄﾞの指示判定の初期化
            mstrDmCodeCommand = vbNullString    'DMｺﾏﾝﾄﾞ
            llngWfSelectRow = 0                 'WFID選択時のWFｸﾞﾘｯﾄﾞ行
            llngBadSelectRow = 0                '不良ｺｰﾄﾞ選択時の不良ｺｰﾄﾞ一覧行
            llngChipSelectRow = 0               'ﾁｯﾌﾟ番号選択時のﾁｯﾌﾟｸﾞﾘｯﾄﾞ行
            llngChipSelectCol = 0               'ﾁｯﾌﾟ番号選択時のﾁｯﾌﾟｸﾞﾘｯﾄﾞ列
            
            '@ﾛｸﾞ出力
            With ltypOnErrorInfoLog
                '@ｴﾗｰﾛｸﾞ情報を設定する
                .strDate = Format$(Today, CPstrDateTimeYMD)              '日付
                .strTime = Format$(TimeOfDay, CPstrDateFormatHMS)            '時刻
                .strComputerName = pstrComputerName                     '端末名
                .strIPaddress = pstrIpAddress                           'IPｱﾄﾞﾚｽ
                .strUserID = StrConv(Environ(CPstrEnvironUserName), vbLowerCase + vbNarrow)           'ﾕｰｻﾞｰID
                .strSbID = pstrSBID                                     'SBID
                .strTestStatus = pstrTestStatus                         'ﾃｽﾄｽﾃｰﾀｽ
                .strTerminalMode = pstrTerminalMode                     '端末区分
                .lngErrNumber = Hex(Err.Number)                         'ｴﾗｰ№(16進に変換)
                .strErrDescription = Err.Description                    'ｴﾗｰ説明
                .strMenuKey = "CM0080"                                  '機能ID
                .strProcName = "txtDmCode_Validate"                     'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrDetail = "txtDmCode_Validate"                    'ｴﾗｰ発生箇所
            End With
            
            '@BCR入力退避
            lstrBCRInput = txtDmCode.Text
            
            '@★ 入力ｺｰﾄﾞにより処理分岐 ★
            Select Case txtDmCode.Text
                
                '@〓 不良(払出)適用、傾向適用、適用取消、取消、確定、ﾁｯﾌﾟ選択ｷｬﾝｾﾙ 〓
                Case CMstrDmBadApplyCmd, CMstrDmTendApplyCmd, CMstrDmApplyCancelCmd, _
                    CMstrDmCancelCmd, CMstrDmRegistCmd, CMstrDmChipCancel
                    
                    '@DataMatrix入力ｺﾏﾝﾄﾞに入力ｺｰﾄﾞをｾｯﾄ
                    mstrDmCodeCommand = txtDmCode.Text
                    
            End Select

            '@DataMatrix入力ｺﾏﾝﾄﾞがNULLか
            If mstrDmCodeCommand = vbNullString Then
                '@DataMatrix入力ｺﾏﾝﾄﾞがNULLの場合
                
                '@入力ｺｰﾄﾞが10桁で、かつ8byte目が"#"か
                If Len(txtDmCode.Text) = CMlngDmWfIdCondLength And _
                    Mid$(txtDmCode.Text, CMlngDmWfIdCondChrPos, 1) = CMstrDmWfIdCondChr Then
                    
                    '@DataMatrix入力ｺﾏﾝﾄﾞに"WFID"をｾｯﾄ
                    mstrDmCodeCommand = CMstrDmWfIdSelectChr
                    
                    With vsfWFMap
                        
                        For llngCnt = 1 To .Rows.Count - 1
                            
                            '@入力ｺｰﾄﾞとWFｽﾛｯﾄﾏｯﾌﾟのWFIDが同じか
                            If txtDmCode.Text = .GetData(llngCnt, CMlngvsfWFMapID) Then
                                '@同じ場合
                                
                                '@対象ﾃﾞｰﾀの有無判定用ﾌﾗｸﾞに"True:あり"をｾｯﾄし、WFｽﾛｯﾄﾏｯﾌﾟの行番号を退避
                                lblnRtn = True
                                llngWfSelectRow = llngCnt
                                
                                Exit For
                            End If
                            
                            '@入力ｺｰﾄﾞとWFｽﾛｯﾄﾏｯﾌﾟのCF_WFIDが同じか
                            If txtDmCode.Text = .GetData(llngCnt, CMlngvsfWFCfWfID) Then
                                '@同じ場合
                                
                                '@対象ﾃﾞｰﾀの有無判定用ﾌﾗｸﾞに"True:あり"、CF_WFIDの設定の有無判定用ﾌﾗｸﾞに"True:CF設定"、
                                '@転写機能OFF判定ﾌﾗｸﾞに"True:ｺﾋﾟｰしない"をｾｯﾄし、WFｽﾛｯﾄﾏｯﾌﾟの行番号を退避
                                lblnRtn = True
                                lblnCfWf = True
                                mblnCopyOFF = True
                                llngWfSelectRow = llngCnt
                                
                                Exit For
                            End If
                        Next llngCnt
                    End With
                End If
                
                '@入力ｺｰﾄﾞの1Byte目が、"B:不良ｺｰﾄﾞ選択"か
                If Strings.Left$(txtDmCode.Text, 1) = CMstrDmBadSelectChr Then

                    With vsfScpList
                        
                        For llngCnt1 = 1 To .Rows.Count - 1
                            
                            '@不良/払出ｺｰﾄﾞと入力ｺｰﾄﾞの2Byte目から入力ｺｰﾄﾞ-1文字目の文字までが同じか
                            If .GetData(llngCnt1, CMlngvsfScpListCode) = _
                                Mid$(txtDmCode.Text, 2, Len(txtDmCode.Text) - 1) Then
                                '@同じ場合
                                
                                '@DataMatrix入力ｺﾏﾝﾄﾞに"B"をｾｯﾄ
                                mstrDmCodeCommand = CMstrDmBadSelectChr
                                
                                '@一致した不良ｺｰﾄﾞｸﾞﾘｯﾄﾞの択時の不良ｺｰﾄﾞ一覧行
                                llngBadSelectRow = llngCnt1
                                
                                Exit For
                            End If
                        Next llngCnt1
                    End With
                End If
                
                '@入力ｺｰﾄﾞの1Byte目が"B:不良/払出ｺｰﾄﾞ選択"で、かつ入力ｺｰﾄﾞの2Byte目から入力ｺｰﾄﾞ-1文字目の文字までが数値か
                If Strings.Left$(txtDmCode.Text, 1) = CMstrDmChipSelectChr And _
                    IsNumeric(Mid$(txtDmCode.Text, 2, Len(txtDmCode.Text) - 1)) = True Then
                    
                    '@ﾁｯﾌﾟﾏｯﾌﾟの最大行数分ﾙｰﾌﾟ
                    For llngCnt1 = 1 To mlngChipGridMaxRows
                        
                        '@ﾁｯﾌﾟﾏｯﾌﾟの最大列数分ﾙｰﾌﾟ
                        For llngCnt2 = 1 To mlngChipGridMaxCols
                            
                            '@ﾁｯﾌﾟﾏｯﾌﾟﾘｽﾄﾃﾞｰﾀの対象ﾁｯﾌﾟIDの右から3文字が、入力ｺｰﾄﾞの2Byte目から入力ｺｰﾄﾞ-1文字目の文字までと同じか
                            If Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt1-1, llngCnt2-1).strChipId, 3) = _
                                Format$(CInt(Mid$(txtDmCode.Text, 2, Len(txtDmCode.Text) - 1)), CMstrDmChipSelectFromat) Then
                                '@同一ﾁｯﾌﾟIDの場合
                                
                                '@DataMatrix入力ｺﾏﾝﾄﾞに"C"をｾｯﾄ
                                mstrDmCodeCommand = CMstrDmChipSelectChr
                                
                                llngChipSelectRow = llngCnt1        'ﾁｯﾌﾟ番号選択時のﾁｯﾌﾟﾏｯﾌﾟ行
                                llngChipSelectCol = llngCnt2        'ﾁｯﾌﾟ番号選択時のﾁｯﾌﾟﾏｯﾌﾟ列
                                
                                '@表/裏ﾎﾞﾀﾝの表示が"表へ"か
                                If cmdHyouri.Text = CMstrCmdHyouriKbn1 Then
                                    '@表へ(裏面の場合)
                                    
                                    '@ﾁｯﾌﾟﾏｯﾌﾟの列順を逆転させるさせて格納
                                    llngChipSelectCol = mlngChipGridMaxCols - llngCnt2 + 1
                                Else
                                    '@裏へ(表面の場合)
                                    
                                    '@ﾁｯﾌﾟﾏｯﾌﾟの列順をそのまま格納
                                    llngChipSelectCol = llngCnt2
                                End If
                                
                                Exit For
                            End If
                        Next llngCnt2
                        
                        '@DataMatrix入力ｺﾏﾝﾄﾞが"C"か
                        If mstrDmCodeCommand = CMstrDmChipSelectChr Then
                            Exit For
                        End If
                    Next llngCnt1
                End If
            End If


            '@***************************************
            '@ Dmｺﾏﾝﾄﾞ起動判定
            '@ ※WFID選択以外はEnter時のみ起動させる
            '@***************************************
            '@DataMatrix入力ｺﾏﾝﾄﾞが"不良ｺｰﾄﾞ選択、ﾁｯﾌﾟ№選択、不良(払出)適用、傾向適用、適用取消、取消、確定、ﾁｯﾌﾟ選択ｷｬﾝｾﾙ"か
            If mstrDmCodeCommand <> CMstrDmWfIdSelectChr Then
            
                '@DataMatrixのEnterﾌﾗｸﾞが"False:未Enter"か(False:未Enter、True：Enter発行)
                If mblnDmCodeKeyDownFlag = False Then
                    '@DataMatrixのEnterﾌﾗｸﾞが未Enterの場合は処理しない
                    Exit Sub
                End If
            End If
            
            
            '@***************************
            '@ Dmｺﾏﾝﾄﾞ起動
            '@***************************
            '@★ DataMatrix入力ｺﾏﾝﾄﾞにより処理分岐 ★
            Select Case mstrDmCodeCommand
                
                '@〓 "WFID：WFID選択" 〓
                Case CMstrDmWfIdSelectChr
                
                    '@入力ｺｰﾄﾞ"WFID"がないか
                    If lblnRtn = False Then
                        '@ない場合
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007J)
                        '@"<TRM7JW>$$このロットに属するWFIDではありません。$設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        e.Cancel = True
                        Exit Sub
                    End If
                    
                    '@WFｽﾛｯﾄﾏｯﾌﾟの該当するWFIDを選択済みにする
                    vsfWFMap.Row = llngWfSelectRow
                    
                    '@CF_WFIDが選択されているか
                    If lblnCfWf = True Then
                        '@CF_WFIDが選択されている場合
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007M)
                        '@"<TRM7MW>$$裏面(対向基板)のWFIDです。$TFT基板のWFIDを指定し、登録は表面に対して行って下さい｡"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        e.Cancel = True
                        Exit Sub
                    End If

                    '@ﾌｧｲﾙへﾛｸﾞ出力(問題箇所確認までの暫定対応)
                    ltypOnErrorInfoLog.strErrMessage = CMstrDmCmdInput & CMstrDmWfIdSelectChrIN & CMstrColon & lstrBCRInput
                    Call pubErrorLogOutput(ltypOnErrorInfoLog, CPlngCommonErrLogClientModeTrm)

                    '@BCRの値を情報ｳｨﾝﾄﾞｳに表示(BCR入力：WFID選択：xxxxx)
                     Call pubVsfInfo_Disp(CMstrDmCmdInput & CMstrDmWfIdSelectChrIN & CMstrColon & lstrBCRInput)

                '@〓 "B：不良/払出ｺｰﾄﾞ選択" 〓
                Case CMstrDmBadSelectChr
                
                    With vsfScpList
                        
                        '@不良/払出ｺｰﾄﾞｸﾞﾘｯﾄﾞが有効、かつﾃﾞｰﾀ行か
                        If .Enabled = True And llngBadSelectRow > 0 Then
                            
                            '@不良/払出ｺｰﾄﾞｸﾞﾘｯﾄﾞの対象行を選択する
                            .Row = llngBadSelectRow
                            .Col = CMlngvsfScpListCode
                            .ShowCell(.Row, .Col)
                        End If
                    End With
                
                    '@ﾌｧｲﾙへﾛｸﾞ出力(問題箇所確認までの暫定対応)
                    ltypOnErrorInfoLog.strErrMessage = CMstrDmCmdInput & CMstrDmBadSelectChrIN & CMstrColon & lstrBCRInput
                    Call pubErrorLogOutput(ltypOnErrorInfoLog, CPlngCommonErrLogClientModeTrm)
                    
                    '@BCRの値を情報ｳｨﾝﾄﾞｳに表示(BCR入力：不良ｺｰﾄﾞ(B)：xxxxx)
                     Call pubVsfInfo_Disp(CMstrDmCmdInput & CMstrDmBadSelectChrIN & CMstrColon & lstrBCRInput)
                
                '@〓 "C：ﾁｯﾌﾟ№選択" 〓
                Case CMstrDmChipSelectChr
                
                    With vsfChipMap
                        
                        '@ﾁｯﾌﾟﾏｯﾌﾟが有効で、かつﾃﾞｰﾀ行があるか
                        If .Enabled = True And llngChipSelectRow > 0 And llngChipSelectCol > 0 Then
                            
                            '@ﾁｯﾌﾟｸﾞﾘｯﾄﾞ選択
                            .Row = llngChipSelectRow
                            .Col = llngChipSelectCol
                            
                            '@拡大表示中(ﾎﾞﾀﾝは全体表示状態)の場合はｽｸﾛｰﾙ移動
                            If cmdDisplayKbn.Text = CMstrCmdDisplayKbn1 Then
                                .ShowCell(.Row, .Col)
                            End If
                            
                            
                            '@***************************************
                            '@ ﾁｯﾌﾟ情報配列の更新及び、ﾁｯﾌﾟﾏｯﾌﾟ設定
                            '@***************************************
                            '@不良(払出)適用ﾎﾞﾀﾝ、傾向適用ﾎﾞﾀﾝが有効か
                            If cmdFuryouTekiyou.Enabled = True And cmdKeikouTekiyou.Enabled = True Then
                                
                                '@★ ﾁｯﾌﾟﾏｯﾌﾟの選択ﾁｯﾌﾟにより処理分岐 ★
                                Select Case .GetCellRange(.Row, .Col).StyleDisplay.BackColor
                                    
                                    '@〓 ﾚﾓﾝ色(既傾向色)、山吹色(現工程傾向色)、ﾋﾟﾝｸ(既不良色)、
                                    '@　 赤ﾋﾟﾝｸ(現工程不良色)、薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ(既払出色)、ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ(現工程払出色)
                                    '@　 濃い灰色(ﾁｯﾌﾟ用表表示色)、小豆色(ﾁｯﾌﾟ用裏表示色) 〓
                                    Case ColorTranslator.FromWin32(CMlngKeikouColor), ColorTranslator.FromWin32(CMlngKeikouColorNow), ColorTranslator.FromWin32(CMlngFuryouColor), _
                                         ColorTranslator.FromWin32(CMlngFuryouColorNow), ColorTranslator.FromWin32(CMlngChipOmoteBackColor), ColorTranslator.FromWin32(CMlngChipUraBackColor), _
                                         ColorTranslator.FromWin32(CMlngHaraidashiColor), ColorTranslator.FromWin32(CMlngHaraidashiColorNow)

                                        '@処理なし
                                    
                                    
                                    '@〓 その他 〓
                                    Case Else
                                    
                                        '@背景色に水色を設定
                                        Dim newStyle As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngChipNoForeColor_BackColor_CMlngCandidacyBackColor")
                                        newStyle.ForeColor =  ColorTranslator.FromWin32(Convert.ToInt32(CMlngChipNoForeColor))
                                        newStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CMlngCandidacyBackColor))
                                        newStyle.TextAlign = TextAlignEnum.RightCenter
                                        Dim cellRange As CellRange = vsfChipMap.GetCellRange(.Row, .Col)
                                        cellRange.Style = newStyle
                                
                                End Select
                            End If
                            
                            '@Dmﾁｯﾌﾟ選択配列の設定
                            llngDmSelectChipNoFindIndex = -1
                            For llngCnt = 0 To mlngDmSelectChipNoMaxCnt - 1
                                
                                If Not IsNothing(mstrDmSelectChipNo) AndAlso mstrDmSelectChipNo(llngCnt) = _
                                    Format$(CInt(Mid$(txtDmCode.Text, 2, Len(txtDmCode.Text) - 1)), CMstrDmChipSelectFromat) Then
                                    
                                    '@同一ﾁｯﾌﾟID
                                    llngDmSelectChipNoFindIndex = llngCnt
                                    Exit For
                                End If
                            Next llngCnt
                            
                            If llngDmSelectChipNoFindIndex = -1 Then
                                '@Dmﾁｯﾌﾟ選択配列の追加
                                ReDim Preserve mstrDmSelectChipNo(mlngDmSelectChipNoMaxCnt)
                                mstrDmSelectChipNo(mlngDmSelectChipNoMaxCnt) = _
                                    Format$(CInt(Mid$(txtDmCode.Text, 2, Len(txtDmCode.Text) - 1)), CMstrDmChipSelectFromat)
                                mlngDmSelectChipNoMaxCnt = mlngDmSelectChipNoMaxCnt + 1
                            End If
                        End If
                    End With

                    '@ﾌｧｲﾙへﾛｸﾞ出力(問題箇所確認までの暫定対応)
                    ltypOnErrorInfoLog.strErrMessage = CMstrDmCmdInput & CMstrDmChipSelectChrIN & CMstrColon & lstrBCRInput
                    Call pubErrorLogOutput(ltypOnErrorInfoLog, CPlngCommonErrLogClientModeTrm)
                    
                    '@BCRの値を情報ｳｨﾝﾄﾞｳに表示(BCR入力：ﾁｯﾌﾟ№(C)：xxxxx)
                     Call pubVsfInfo_Disp(CMstrDmCmdInput & CMstrDmChipSelectChrIN & CMstrColon & lstrBCRInput)

                
                '@〓 "IBA：不良(払出)適用" 〓
                Case CMstrDmBadApplyCmd
                    
                    '@不良(払出)適用ﾎﾞﾀﾝが有効か
                    If cmdFuryouTekiyou.Enabled = True Then
                    
                        '@不良(払出)適用ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        If lblnNextCtrl Then
                            Call pubSetFocus(cmdFuryouTekiyou)
                        End If
                        
                        '@=======================
                        '@ 不良(払出)適用ﾎﾞﾀﾝ押下処理
                        '@=======================
                        Call cmdFuryouTekiyou_Click(cmdFuryouTekiyou, New EventArgs())
                    End If

                    '@ﾌｧｲﾙへﾛｸﾞ出力(問題箇所確認までの暫定対応)
                    ltypOnErrorInfoLog.strErrMessage = CMstrDmCmdInput & CMstrDmBadApplyCmdIN
                    Call pubErrorLogOutput(ltypOnErrorInfoLog, CPlngCommonErrLogClientModeTrm)
                    
                    '@BCRの値を情報ｳｨﾝﾄﾞｳに表示(BCR入力：不良適用(IBA))
                     Call pubVsfInfo_Disp(CMstrDmCmdInput & CMstrDmBadApplyCmdIN)

                '@〓 "ITA：傾向適用" 〓
                Case CMstrDmTendApplyCmd
                    
                    '@傾向適用ﾎﾞﾀﾝが有効か
                    If cmdKeikouTekiyou.Enabled = True Then
                        
                        '@傾向適用ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        If lblnNextCtrl Then
                            Call pubSetFocus(cmdKeikouTekiyou)
                        End If
                        
                        '@=======================
                        '@ 傾向適用ﾎﾞﾀﾝ押下処理
                        '@=======================
                        Call cmdKeikouTekiyou_Click(cmdKeikouTekiyou, New EventArgs())
                    End If

                    '@ﾌｧｲﾙへﾛｸﾞ出力(問題箇所確認までの暫定対応)
                    ltypOnErrorInfoLog.strErrMessage = CMstrDmCmdInput & CMstrDmTendApplyCmdIN
                    Call pubErrorLogOutput(ltypOnErrorInfoLog, CPlngCommonErrLogClientModeTrm)
                    
                    '@BCRの値を情報ｳｨﾝﾄﾞｳに表示(BCR入力：傾向適用(ITA))
                     Call pubVsfInfo_Disp(CMstrDmCmdInput & CMstrDmTendApplyCmdIN)

                
                '@〓 "IAC：適用取消" 〓
                Case CMstrDmApplyCancelCmd
                    
                    '@適用取消ﾎﾞﾀﾝが有効か
                    If cmdTekiyouClear.Enabled = True Then
                        
                        '@適用取消ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        If lblnNextCtrl Then
                            Call pubSetFocus(cmdTekiyouClear)
                        End If
                        
                        '@=======================
                        '@ 適用取消ﾎﾞﾀﾝ押下処理
                        '@=======================
                        Call cmdTekiyouClear_Click(cmdTekiyouClear, New EventArgs())
                    End If

                    '@ﾌｧｲﾙへﾛｸﾞ出力(問題箇所確認までの暫定対応)
                    ltypOnErrorInfoLog.strErrMessage = CMstrDmCmdInput & CMstrDmApplyCancelCmdIN
                    Call pubErrorLogOutput(ltypOnErrorInfoLog, CPlngCommonErrLogClientModeTrm)

                    '@BCRの値を情報ｳｨﾝﾄﾞｳに表示(BCR入力：適用取消(IAC))
                     Call pubVsfInfo_Disp(CMstrDmCmdInput & CMstrDmApplyCancelCmdIN)


                '@〓 "IC：取消" 〓
                Case CMstrDmCancelCmd
                    
                    '@取消ﾎﾞﾀﾝが有効か
                    If cmdClear.Enabled = True Then
                        
                        '@取消ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        If lblnNextCtrl Then
                            Call pubSetFocus(cmdClear)
                        End If
                        
                        '@=======================
                        '@ 取消ﾎﾞﾀﾝ押下処理
                        '@=======================
                        Call cmdClear_Click(cmdClear, New EventArgs())
                    End If

                    '@ﾌｧｲﾙへﾛｸﾞ出力(問題箇所確認までの暫定対応)
                    ltypOnErrorInfoLog.strErrMessage = CMstrDmCmdInput & CMstrDmCancelCmdIN
                    Call pubErrorLogOutput(ltypOnErrorInfoLog, CPlngCommonErrLogClientModeTrm)
                    
                    '@BCRの値を情報ｳｨﾝﾄﾞｳに表示(BCR入力：適用取消(IC))
                     Call pubVsfInfo_Disp(CMstrDmCmdInput & CMstrDmCancelCmdIN)

                
                '@〓 "IR：確定" 〓
                Case CMstrDmRegistCmd
                    
                    '@ﾌｧｲﾙへﾛｸﾞ出力(問題箇所確認までの暫定対応)
                    ltypOnErrorInfoLog.strErrMessage = CMstrDmCmdInput & CMstrDmRegistCmdIN
                    Call pubErrorLogOutput(ltypOnErrorInfoLog, CPlngCommonErrLogClientModeTrm)
                    
                    '@BCRの値を情報ｳｨﾝﾄﾞｳに表示(BCR入力：確定(IR))
                     Call pubVsfInfo_Disp(CMstrDmCmdInput & CMstrDmRegistCmdIN)
                    
                    '@確定ﾎﾞﾀﾝが有効か
                    If cmdRegist.Enabled = True Then
                        
                        '@=======================
                        '@ 入力ﾁｪｯｸ処理
                        '@=======================
                        lblnInputCheck = prvblnRegistInput_Chk
                        
                        '@処理結果判定
                        If lblnInputCheck = False Then
                            '@結果：異常の場合
                            e.Cancel = True
                            Exit Sub
                        End If
                        
                        '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        If lblnNextCtrl Then
                            Call pubSetFocus(cmdRegist)
                        End If
                        
                        '@=======================
                        '@ 確定ﾎﾞﾀﾝ押下処理
                        '@=======================
                        Call cmdRegist_Click(cmdRegist, New EventArgs())
                    End If

                
                '@〓 "ICC：ﾁｯﾌﾟ選択ｷｬﾝｾﾙ" 〓
                Case CMstrDmChipCancel

                    '@Dmﾁｯﾌﾟ選択配列の検索
                    llngDmSelectChipNoFindIndex = -1
                    
                    '@配列の後ろからﾁｪｯｸする為、ﾙｰﾌﾟｶｳﾝﾀは減算
                    For llngCnt = mlngDmSelectChipNoMaxCnt - 1 To 0 Step -1
                        
                        '@入力ｺｰﾄﾞのﾁｯﾌﾟ番号が数値か
                        If Not IsNothing(mstrDmSelectChipNo) AndAlso IsNumeric(mstrDmSelectChipNo(llngCnt)) = True Then
                            
                            '@ﾁｯﾌﾟ選択配列の同一ﾁｯﾌﾟ番号Indexに格納
                            llngDmSelectChipNoFindIndex = llngCnt
                            Exit For
                        End If
                    Next llngCnt
                    
                    '@Dmﾁｯﾌﾟ選択配列の同一ﾁｯﾌﾟ番号Indexが0より大きいか
                    If llngDmSelectChipNoFindIndex >= 0 Then
                        
                        llngChipSelectRow = 0               'ﾁｯﾌﾟ番号選択時のﾁｯﾌﾟｸﾞﾘｯﾄﾞ行
                        llngChipSelectCol = 0               'ﾁｯﾌﾟ番号選択時のﾁｯﾌﾟｸﾞﾘｯﾄﾞ列

                        For llngCnt1 = 1 To mlngChipGridMaxRows
                            
                            For llngCnt2 = 1 To mlngChipGridMaxCols
                                
                                '@ﾁｯﾌﾟﾏｯﾌﾟﾘｽﾄﾃﾞｰﾀの対象ﾁｯﾌﾟIDの右から3文字が、ﾁｯﾌﾟ選択配列の同一ﾁｯﾌﾟ番号Indexと同じか
                                If Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt1-1, llngCnt2-1).strChipId, 3) = _
                                    mstrDmSelectChipNo(llngDmSelectChipNoFindIndex) Then
                                    '@同一ﾁｯﾌﾟ№の場合
                                    
                                    llngChipSelectRow = llngCnt1        'ﾁｯﾌﾟ番号選択時のﾁｯﾌﾟｸﾞﾘｯﾄﾞ行
                                    llngChipSelectCol = llngCnt2        'ﾁｯﾌﾟ番号選択時のﾁｯﾌﾟｸﾞﾘｯﾄﾞ列
                                    
                                    '@表/裏ﾎﾞﾀﾝの表示が"表へ"か
                                    If cmdHyouri.Text = CMstrCmdHyouriKbn1 Then
                                        '@表へ(裏面の場合)
                                        
                                        '@ﾁｯﾌﾟﾏｯﾌﾟの列順を逆順で格納する
                                        llngChipSelectCol = mlngChipGridMaxCols - llngCnt2 + 1
                                    Else
                                        '@裏へ(表面の場合)
                                        
                                        '@ﾁｯﾌﾟﾏｯﾌﾟの列順をそのまま格納する
                                        llngChipSelectCol = llngCnt2
                                    End If
                                    
                                    Exit For
                                End If
                            Next llngCnt2
                            
                            If llngChipSelectRow > 0 And llngChipSelectCol > 0 Then
                                Exit For
                            End If
                        Next llngCnt1

                        With vsfChipMap
                            
                            '@ﾁｯﾌﾟﾏｯﾌﾟが有効で、かつﾁｯﾌﾟﾏｯﾌﾟのﾃﾞｰﾀｾﾙが選択されているか
                            If .Enabled = True And llngChipSelectRow > 0 And llngChipSelectCol > 0 Then
                                
                                '@不良(払出)適用ﾎﾞﾀﾝと傾向適用ﾎﾞﾀﾝが有効か
                                If cmdFuryouTekiyou.Enabled = True And cmdKeikouTekiyou.Enabled = True Then
                                    
                                    '@★ 選択ﾁｯﾌﾟﾏｯﾌﾟｾﾙの背景色により処理分岐 ★
                                    Select Case .GetCellRange(llngChipSelectRow, llngChipSelectCol).StyleDisplay.BackColor
                                        
                                        '@〓 水色(適用候補) 〓
                                        Case ColorTranslator.FromWin32(CMlngCandidacyBackColor)
                                            
                                            '@選択ﾁｯﾌﾟﾏｯﾌﾟｾﾙの背景色を白に戻す
                                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                                            newStyle.ForeColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngChipNoForeColor))
                                            newStyle.BackColor = Color.White
                                            newStyle.TextAlign = TextAlignEnum.RightCenter
                                            Dim cellRange As CellRange = .GetCellRange(llngChipSelectRow, llngChipSelectCol)
                                            cellRange.Style = newStyle
                                    
                                    End Select
                                End If
                            End If
                        End With
                        
                        '@Dmﾁｯﾌﾟ選択配列のｸﾘｱ
                        mstrDmSelectChipNo(llngDmSelectChipNoFindIndex) = vbNullString
                    
                        '@Dmﾁｯﾌﾟ選択配列の前選択ﾁｯﾌﾟ№の検索
                        llngDmSelectChipNoFindIndex = -1
                        For llngCnt = mlngDmSelectChipNoMaxCnt-1 To 0 Step -1
                            
                            If IsNumeric(mstrDmSelectChipNo(llngCnt)) = True Then
                                
                                '@ﾁｯﾌﾟ選択配列の同一ﾁｯﾌﾟ番号Indexに格納
                                llngDmSelectChipNoFindIndex = llngCnt
                                Exit For
                            End If
                        Next llngCnt
                        
                        '@ﾁｯﾌﾟ選択配列の同一ﾁｯﾌﾟ番号Indexが0より大きいか
                        If llngDmSelectChipNoFindIndex >= 0 Then
                            
                            llngChipSelectRow = 0               'ﾁｯﾌﾟ番号選択時のﾁｯﾌﾟｸﾞﾘｯﾄﾞ行
                            llngChipSelectCol = 0               'ﾁｯﾌﾟ番号選択時のﾁｯﾌﾟｸﾞﾘｯﾄﾞ列

                            For llngCnt1 = 1 To mlngChipGridMaxRows
                                
                                For llngCnt2 = 1 To mlngChipGridMaxCols
                                    
                                    '@ﾁｯﾌﾟﾏｯﾌﾟﾘｽﾄﾃﾞｰﾀの対象ﾁｯﾌﾟIDの右から3文字が、ﾁｯﾌﾟ選択配列の同一ﾁｯﾌﾟ番号Indexと同じか
                                    If Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt1-1, llngCnt2-1).strChipId, 3) = _
                                        mstrDmSelectChipNo(llngDmSelectChipNoFindIndex) Then
                                        '@同一ﾁｯﾌﾟ№の場合
                                        
                                        llngChipSelectRow = llngCnt1        'ﾁｯﾌﾟ番号選択時のﾁｯﾌﾟｸﾞﾘｯﾄﾞ行
                                        llngChipSelectCol = llngCnt2        'ﾁｯﾌﾟ番号選択時のﾁｯﾌﾟｸﾞﾘｯﾄﾞ列
                                        
                                        '@表/裏ﾎﾞﾀﾝの表示が"表へ"か
                                        If cmdHyouri.Text = CMstrCmdHyouriKbn1 Then
                                            '@表へ(裏面の場合)
                                            
                                            '@ﾁｯﾌﾟﾏｯﾌﾟのﾁｯﾌﾟ番号を逆転させる
                                            llngChipSelectCol = mlngChipGridMaxCols - llngCnt2 + 1
                                        Else
                                            '@裏へ(表面の場合)
                                            
                                            '@ﾁｯﾌﾟﾏｯﾌﾟのﾁｯﾌﾟ番号をそのまま表示
                                            llngChipSelectCol = llngCnt2
                                        End If
                                        
                                        Exit For
                                    End If
                                Next llngCnt2
                                
                                If llngChipSelectRow > 0 And llngChipSelectCol > 0 Then
                                    Exit For
                                End If
                            Next llngCnt1
                            
                            '@ﾁｯﾌﾟﾏｯﾌﾟ選択処理
                            With vsfChipMap
                            
                                .Row = llngChipSelectRow
                                .Col = llngChipSelectCol
                                
                                '@拡大表示中(ﾎﾞﾀﾝは全体表示状態)の場合はｽｸﾛｰﾙ移動
                                If cmdDisplayKbn.Text = CMstrCmdDisplayKbn1 Then
                                    .ShowCell(.Row, .Col)
                                End If
                            End With
                        Else
                            '@ﾌｫｰｶｽをﾏｯﾌﾟ外へ設定する。
                            vsfChipMap.Col = -1
                        End If
                    End If
                
                    '@ﾌｧｲﾙへﾛｸﾞ出力(問題箇所確認までの暫定対応)
                    ltypOnErrorInfoLog.strErrMessage = CMstrDmCmdInput & CMstrDmChipCancelIN
                    Call pubErrorLogOutput(ltypOnErrorInfoLog, CPlngCommonErrLogClientModeTrm)
                    
                    '@BCRの値を情報ｳｨﾝﾄﾞｳに表示(BCR入力：ﾁｯﾌﾟ選択ｷｬﾝｾﾙ(ICC))
                     Call pubVsfInfo_Disp(CMstrDmCmdInput & CMstrDmChipCancelIN)
                
                '@〓 その他 〓
                Case Else
                    
                    '@★ 入力ｺｰﾄﾞの1Byte目により処理分岐 ★
                    '@　※09/04/02時点で"払出ｺｰﾄﾞ"の入力の件は聞いていないので対応していません。
                    Select Case Strings.Left$(txtDmCode.Text, 1)
                        
                        '@〓 B：不良ｺｰﾄﾞ選択 〓
                        Case CMstrDmBadSelectChr
                            
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0091, CMstrDmErrMsgBadSelect)
                            
                            '@ﾌｧｲﾙへﾛｸﾞ出力(問題箇所確認までの暫定対応)
                            ltypOnErrorInfoLog.strErrMessage = pstrDMsg & CPstrParenthesisLeft & CMstrDmCmdInput & lstrBCRInput & CPstrParenthesisRight
                            Call pubErrorLogOutput(ltypOnErrorInfoLog, CPlngCommonErrLogClientModeTrm)

                            '@BCRの値を情報ｳｨﾝﾄﾞｳに表示
                            Call pubVsfInfo_Disp(CMstrDmCmdInput & lstrBCRInput)
                            
                            '@"<TRM91W>$$不良コード指定に誤りがあります。入力を見直してください。(BCR入力：xxxxxx)"
                            Call publngMsgBoxInfo(pstrDMsg & _
                                                  CPstrParenthesisLeft & CMstrDmCmdInput & lstrBCRInput & _
                                                  CPstrParenthesisRight, vbExclamation, Me.Text, True, 16)
                            
                            e.Cancel = True
                        
                        
                        '@〓 C：ﾁｯﾌﾟ№選択 〓
                        Case CMstrDmChipSelectChr
                            
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0091, CMstrDmErrMsgChipSelect)
                            
                            '@ﾌｧｲﾙへﾛｸﾞ出力(問題箇所確認までの暫定対応)
                            ltypOnErrorInfoLog.strErrMessage = pstrDMsg & CPstrParenthesisLeft & CMstrDmCmdInput & lstrBCRInput & CPstrParenthesisRight
                            Call pubErrorLogOutput(ltypOnErrorInfoLog, CPlngCommonErrLogClientModeTrm)

                            '@BCRの値を情報ｳｨﾝﾄﾞｳに表示
                            Call pubVsfInfo_Disp(CMstrDmCmdInput & lstrBCRInput)
                            
                             '@"<TRM91W>$$チップ指定に誤りがあります。入力を見直してください。(BCR入力：xxxxxx)"
                            Call publngMsgBoxInfo(pstrDMsg & _
                                                  CPstrParenthesisLeft & CMstrDmCmdInput & lstrBCRInput & _
                                                  CPstrParenthesisRight, vbExclamation, Me.Text, True, 16)
                            
                            e.Cancel = True
                        
                        
                        '@〓 その他 〓
                        Case Else
                            
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0091, CMstrDmErrMsgCmdInput)
                            
                            '@ﾌｧｲﾙへﾛｸﾞ出力(問題箇所確認までの暫定対応)
                            ltypOnErrorInfoLog.strErrMessage = pstrDMsg & CPstrParenthesisLeft & CMstrDmCmdInput & lstrBCRInput & CPstrParenthesisRight
                            Call pubErrorLogOutput(ltypOnErrorInfoLog, CPlngCommonErrLogClientModeTrm)

                            '@BCRの値を情報ｳｨﾝﾄﾞｳに表示
                            Call pubVsfInfo_Disp(CMstrDmCmdInput & lstrBCRInput)

                            '@"<TRM91W>$$操作コード指定に誤りがあります。入力を見直してください。(BCR入力：xxxxxx)"
                            Call publngMsgBoxInfo(pstrDMsg & _
                                                  CPstrParenthesisLeft & CMstrDmCmdInput & lstrBCRInput & _
                                                  CPstrParenthesisRight, vbExclamation, Me.Text, True, 16)

                            e.Cancel = True
                            
                    End Select

            End Select

            '@起動区分が"1：不良ﾁｯﾌﾟ情報(№表示)起動"か
            If plngfrmxxCM0080Kbn = CPlngNumOne Then

                '@=======================
                '@ 不良ﾁｯﾌﾟ情報(№表示)起動時のｺﾝﾄﾛｰﾙ無効化処理
                '@=======================
                Call prvAnyControlDisable_Proc()

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "txtDmCode_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfWFMap_EnterCell
    '機　能：WFｸﾞﾘｯﾄﾞ(WFｽﾛｯﾄﾏｯﾌﾟ)　ｶﾚﾝﾄ行変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/05 (Mon) 10:44:02 T.Kitagawa
    '更新日：2009/09/02 (Wed) 17:05:23 N.Kojima
    '備　考：
    '　　　：2004/09/14 (Tue) 12:57:47 Y.Yamagishi　電特/外観/パ検結果登録対応
    '　　　：2004/09/15 (Wed) 15:30:48 S.Deguchi    DoEventsを追加(理由はｺﾒﾝﾄで書いてます)
    '　　　：2004/10/26 (Tue) 09:44:12 T.Kitagawa   DoEvents対応、型一致ｴﾗｰ対応、チップ№初期表示設定
    '　　　：2006/06/22 (Thu) 13:10:29 T.Kitagawa   DataMatrixｺｰﾄﾞ(ﾊﾞｰｺｰﾄﾞ)対応(ﾕｰｻﾞ要望№0209)
    '　　　：2006/08/09 (Wed) 16:17:47 N.Kojima     WFﾏｯﾌﾟ情報の取得関数の引数に"CLASS_DIVISION"追加。(案件№01100)
    '　　　：2006/10/26 (Thu) 14:15:55 N.Kasai      上記修正元に戻す
    '　　　：2008/04/25 (Fri) 16:09:19 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2009/09/02 (Wed) 17:05:23 N.Kojima     不良ﾁｯﾌﾟ情報(№表示)対応。※不良ﾁｯﾌﾟについて、不良ｺｰﾄﾞではなくﾁｯﾌﾟ№で表示する。(案件№03685)
    Private Sub vsfWFMap_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfWFMap.EnterCell

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypWFMapInfo           As WFMapInfo            'WFﾏｯﾌﾟ情報構造体
        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngWFStartIndex        As Integer              'WFの開始ｽﾛｯﾄ№
        Dim llngStartRowPos         As Integer              '開始行位置
        Dim llngStartColPos         As Integer              '開始列位置
        Dim llngEndRowPos           As Integer              '終了行位置
        Dim llngEndColPos           As Integer              '終了列位置
        Dim lcellRange              As CellRange            'NSYS 選択範囲取得

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfWFMap.Rows.Count <= vsfWFMap.Rows.Fixed Then
                Return
            End If
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①WFﾏｯﾌﾟ情報取得処理
            '@　　②処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝ別、ﾁｯﾌﾟﾏｯﾌﾟ表示処理
            '@　　③各種ﾎﾞﾀﾝの制御処理
            '@　　④起動区分が"1：不良ﾁｯﾌﾟ情報(№表示)"の場合の各種ｺﾝﾄﾛｰﾙ無効化処理
            '@======================================================================================
            
            
            '@WFｽﾛｯﾄﾏｯﾌﾟの選択行がﾃﾞｰﾀ行以外か
            If vsfWFMap.Row < 1 Then
                Exit Sub
            End If
            
            '@WFｽﾛｯﾄﾏｯﾌﾟの現在ｲﾝﾃﾞｯｸｽ(1～25)の設定
            mlngWFNowIndex = CMlngvsfWFMapMaxSlotID - vsfWFMap.Row + 1
            
            '@ﾚｽﾎﾟﾝｽ測定開始(初期WF_IDの場合はｷｬﾘｱのLost自に行う為、初期WF以外の場合に測定する)
            llngWFStartIndex = 0
            For llngCnt = 1 To CMlngvsfWFMapMaxSlotID
            
                '@WFIDがNULL以外か
                If mtypWFInfo(llngCnt-1).strWfId <> vbNullString Then
                    llngWFStartIndex = llngCnt
                    Exit For
                End If
            Next llngCnt
            
            
            '@***********************
            '@　WF情報の設定
            '@***********************
            With mtypWFInfo(mlngWFNowIndex-1)
                
                '@入力ﾁｪｯｸ区分"NULL:ﾁｯﾌﾟ情報が未読込み"で、かつWFIDがNULL以外か
                If .strInputCheckKbn = CMstrstrInputCheckKbn0 And .strWfId <> vbNullString Then

                    'NSYS エラーダイアログ表示時のグリッド選択行ハイライト色不具合対応
                    vsfWFMap.Refresh()
                    
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrVsfWFMapEnterCell)
                    
                    '@=======================
                    '@【WFﾏｯﾌﾟ情報取得】ﾒｯｾｰｼﾞ送信処理
                    '@=======================
                    lblnAns = pubblnWFMapInfo_Sel(CMstrwf__mapinfo_Ver, _
                                                  lblLotID.Text, _
                                                  .strWfId, _
                                                  ptypLotprestate.strVaFlag, _
                                                  ptypLotprestate.strTpalClass, _
                                                  ltypWFMapInfo)
                                                  
                    '@通信結果が"True:正常"か
                    If lblnAns = True Then
                        '@結果：正常の場合
                    
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrVsfWFMapEnterCell)
                    
                        '@=======================
                        '@ WF情報の設定処理
                        '@=======================
                        Call prvWFMapInfo_Set(ltypWFMapInfo)
                    Else
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrVsfWFMapEnterCell)
                    End If
                End If
                
                '@********************************************************
                '@ ｵﾌﾟｼｮﾝﾎﾞﾀﾝの選択により、ﾁｯﾌﾟﾏｯﾌﾟの表示を切り替える
                '@********************************************************
                '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 〓
                Select Case True
                    
                    '@〓 "ﾁｯﾌﾟ登録" 〓
                    Case optProcessKbn1.Checked = True
                        
                        '@=======================
                        '@ 通常情報の表示処理
                        '@=======================
                        Call prvChipMapGrid_Set()
                    
                    
                    '@〓 "電特" 〓
                    Case optProcessKbn2.Checked = True
                        
                        '@=======================
                        '@ 電特結果情報の表示処理
                        '@=======================
                        Call prvChipMapElectric_Set()
                    
                    
                    '@〓 "WAIST" 〓
                    Case optProcessKbn3.Checked = True
                        
                        '@=======================
                        '@ WAIST検査機結果情報の表示処理
                        '@=======================
                        Call prvChipMapWaist_Set()
                
                End Select
                                
                '@転写機能OFF判定ﾌﾗｸﾞが"False：ｺﾋﾟｰする"か
                If mblnCopyOFF = False Then
                    
                    '@ｽｷｬﾅ入力に選択WFIDをｾｯﾄ
                    txtDmCode.Text = vsfWFMap.GetData(vsfWFMap.Row, CMlngvsfWFMapID)
                End If
                
                '@転写機能OFF判定ﾌﾗｸﾞに"False：ｺﾋﾟｰする"をｾｯﾄ
                mblnCopyOFF = False
             
                '@ﾌｫｰﾑﾛｰﾄﾞ処理が完了しているか
                If pblnFormLoad = True Then
                
                    '@選択WFIDがNULL以外か
                    If vsfWFMap.GetData(vsfWFMap.Row, CMlngvsfWFMapID) <> vbNullString Then
                    
                        '@ｽｷｬﾅ入力ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtDmCode)
                    End If
                End If
                
            End With

            '@ﾁｯﾌﾟ№の初期化
            lblChipNo.Text = vbNullString
            
            '@ﾁｯﾌﾟ№の表示
            '@ﾁｯﾌﾟﾏｯﾌﾟの選択ｾﾙがﾃﾞｰﾀｾﾙ(ﾁｯﾌﾟ番号があるｾﾙ)か
            If vsfChipMap.Row >= 1 And vsfChipMap.Col >= 1 Then
                
                '@ﾁｯﾌﾟﾏｯﾌﾟの選択状態を参照する
                'vsfChipMap.GetSelection( llngStartRowPos, llngStartColPos, llngEndRowPos, llngEndColPos)
                lcellRange = vsfChipMap.Selection
                llngStartRowPos = lcellRange.r1
                llngStartColPos = lcellRange.c1
                llngEndRowPos = lcellRange.r2
                llngEndColPos = lcellRange.c2
                
                '@1ｾﾙのみ選択しているか
                If llngStartRowPos = llngEndRowPos And llngStartColPos = llngEndColPos Then
                    
                    '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐 〓
                    Select Case cmdHyouri.Text
                        
                        '@〓 表へ 〓
                        Case CMstrCmdHyouriKbn1
                            
                            '@ﾁｯﾌﾟ№にWF情報のﾁｯﾌﾟIDを表示
                            lblChipNo.Text = _
                                Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngStartRowPos-1, mlngChipGridMaxCols - llngStartColPos).strChipId, 3)
                        
                        '@〓 裏へ 〓
                        Case CMstrCmdHyouriKbn2
                            
                            '@ﾁｯﾌﾟ№にWF情報のﾁｯﾌﾟIDを表示
                            lblChipNo.Text = _
                                Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngStartRowPos-1, llngStartColPos-1).strChipId, 3)
                    End Select
                End If
            End If
            
            '@=======================
            '@ 各種ﾎﾞﾀﾝの制御処理
            '@=======================
            Call prvCmdButtonEnable_Chk()
            
            '@Dmﾁｯﾌﾟ番号選択配列のｸﾘｱ
            Erase mstrDmSelectChipNo
            mlngDmSelectChipNoMaxCnt = 0
            
            '@起動区分が"1：不良ﾁｯﾌﾟ情報(№表示)起動"か
            If plngfrmxxCM0080Kbn = CPlngNumOne Then

                '@=======================
                '@ 不良ﾁｯﾌﾟ情報(№表示)起動時のｺﾝﾄﾛｰﾙ無効化処理
                '@=======================
                Call prvAnyControlDisable_Proc()

            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "vsfWFMap_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfScpList_EnterCell
    '機　能：不良/払出ｺｰﾄﾞﾘｽﾄ　ｶﾚﾝﾄ行列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/03/31 (Tue) 09:59:39 N.Kojima
    '更新日：2009/03/31 (Tue) 10:00:07 N.Kojima
    '備　考：
    Private Sub vsfScpList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfScpList.EnterCell

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfScpList.Rows.Count <= vsfScpList.Rows.Fixed Then
                Return
            End If

            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝにて"ﾁｯﾌﾟ登録"が選択されている場合の適用ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝ変更処理
            '@　　②処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝにて"ﾁｯﾌﾟ登録"が選択されている場合の傾向適用ﾎﾞﾀﾝの有効/無効制御処理
            '@======================================================================================


            With vsfScpList

                '@処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝにて"ﾁｯﾌﾟ登録"が選択されているか
                If optProcessKbn1.Checked = True AndAlso .Row >= .Rows.Fixed Then
            
                    '@選択ｺｰﾄﾞが"払出ｺｰﾄﾞ"か
                    If .GetData(.Row, CMlngvsfScpListCode) = CPstrForwardCode Then
                        '@選択ｺｰﾄﾞが"払出ｺｰﾄﾞ"
                        
                        '@不良(払出)適用ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝを"払出適用"に変更
                        cmdFuryouTekiyou.Text = CMstrCmdDispForward
                        
                        '@傾向適用ﾎﾞﾀﾝを無効にする
                        cmdKeikouTekiyou.Enabled = False
                    Else
                        '@選択ｺｰﾄﾞが"払出ｺｰﾄﾞ"以外
                        
                        '@画面がﾁｶﾁｶするのを防止する為、ｷｬﾌﾟｼｮﾝが"払出適用"の場合のみ実施
                        If cmdFuryouTekiyou.Text = CMstrCmdDispForward Then
            
                            '@払出適用ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝを"不良適用"に変更
                            cmdFuryouTekiyou.Text = CMstrCmdDispFuryou
                            
                            '@傾向適用ﾎﾞﾀﾝを有効にする
                            cmdKeikouTekiyou.Enabled = True
                        End If
                    End If
                
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "vsfScpList_EnterCell"
                .strErrMessage = vbNullString
            End With
            
            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfChipMap_Click
    '機　能：ﾁｯﾌﾟｸﾞﾘｯﾄﾞ(ﾁｯﾌﾟﾏｯﾌﾟ)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/05 (Mon) 10:53:28 T.Kitagawa
    '更新日：2004/08/04 (Wed) 09:38:54 N.Kasai
    '備　考：
    Private Sub vsfChipMap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfChipMap.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '2004/09/13 (Mon) 10:04:48 Y.Yamagishi
        'ﾁｯﾌﾟMapｸﾘｯｸで不良、傾向適用は今のところ不可とする(今後可能となるかもしれないので、ｺﾒﾝﾄにしておきます。)
        '@↓2004/09/13 (Mon) 10:04:48 Y.Yamagishi **************************************************
        '    Dim llngStartRowPos         As Long         '開始行位置
        '    Dim llngStartColPos         As Long         '開始列位置
        '    Dim llngEndRowPos           As Long         '終了行位置
        '    Dim llngEndColPos           As Long         '終了列位置
        '
        '    '@右ﾎﾞﾀﾝ区分を判定
        '    If mblnRightButton = True Then
        '        '@右ﾎﾞﾀﾝ区分をｸﾘｱ
        '        mblnRightButton = False
        '        '@処理ｽｷｯﾌﾟ
        '        Exit Sub
        '    End If
        '
        '    '@ﾁｯﾌﾟ範囲選択判定
        '    If vsfChipMap.Row < 1 Or vsfChipMap.Col < 1 Then
        '        '@未選択時は処理ｽｷｯﾌﾟ
        '        Exit Sub
        '    End If
        '
        '    '@ﾁｯﾌﾟGridの選択状態の参照
        '    vsfChipMap.GetSelection llngStartRowPos, llngStartColPos, llngEndRowPos, llngEndColPos
        '
        '    '@ﾁｯﾌﾟ№の表示、不良／傾向の簡易登録
        '    lblChipNo.Caption = vbNullString
        '    '@1ｾﾙ選択のみ可能
        '    If llngStartRowPos = llngEndRowPos And llngStartColPos = llngEndColPos Then
        '        '@ﾁｯﾌﾟ№の表示
        '        Select Case cmdHyouri.Caption
        '            '@表
        '            Case CMstrCmdHyouriKbn1
        '                lblChipNo.Caption = Right$(mtypWFInfo(mlngWFNowIndex).typChipList(llngStartRowPos, _
        '                                                                            mlngChipGridMaxCols - llngStartColPos + 1).strChipId, 3)
        '            '@裏
        '            Case CMstrCmdHyouriKbn2
        '                lblChipNo.Caption = Right$(mtypWFInfo(mlngWFNowIndex).typChipList(llngStartRowPos, llngStartColPos).strChipId, 3)
        '        End Select
        '
        '        '@不良／傾向の簡易登録
        '        '@ﾁｯﾌﾟIDが表示されている場合
        '        If IsNumeric(vsfChipMap.Cell(flexcpText, llngStartRowPos, llngStartColPos)) = True And _
        '            Len(vsfChipMap.Cell(flexcpText, llngStartRowPos, llngStartColPos)) = 3 Then
        '            Select Case True
        '                '@不良適用
        '                Case cmdFuryouTekiyou.FontBold = True
        '                    Call prvTekiyou_Set(cmdFuryouTekiyou.Name)
        '                '@傾向適用
        '                Case cmdKeikouTekiyou.FontBold = True
        '                    Call prvTekiyou_Set(cmdKeikouTekiyou.Name)
        '             End Select
        '        Else
        '            '@適用取消
        '             Call prvTekiyou_Set(cmdTekiyouClear.Name)
        '        End If
        '    End If
        '@↑2004/09/13 (Mon) 10:04:48 Y.Yamagishi **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "vsfChipMap_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfChipMap_EnterCell
    '機　能：ﾁｯﾌﾟｸﾞﾘｯﾄﾞ(ﾁｯﾌﾟﾏｯﾌﾟ)　ｶﾚﾝﾄ行列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/05 (Mon) 10:53:28 T.Kitagawa
    '更新日：2008/04/25 (Fri) 16:30:30 N.Kojima
    '備　考：
    '　　　：2008/04/25 (Fri) 16:30:30 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub vsfChipMap_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfChipMap.EnterCell
        
        Dim llngStartRowPos         As Integer      '開始行位置
        Dim llngStartColPos         As Integer      '開始列位置
        Dim llngEndRowPos           As Integer      '終了行位置
        Dim llngEndColPos           As Integer      '終了列位置
        Dim lcellRange              As CellRange    'NSYS 選択範囲取得

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfChipMap.Rows.Count <= vsfChipMap.Rows.Fixed Then
                Return
            End If
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①選択状況ﾁｪｯｸ(ﾁｯﾌﾟが選択されているか)
            '@　　②ﾁｯﾌﾟﾗﾍﾞﾙ表示処理(表裏別)
            '@======================================================================================
            
            
            '@ﾁｯﾌﾟﾏｯﾌﾟの選択ｾﾙがﾃﾞｰﾀｾﾙ(ﾁｯﾌﾟ番号が表示されているｾﾙ)か
            If vsfChipMap.Row < 1 Or vsfChipMap.Col < 1 Then
                Exit Sub
            End If
            
            '@ﾁｯﾌﾟﾏｯﾌﾟの選択状態を参照
            'vsfChipMap.GetSelection llngStartRowPos, llngStartColPos, llngEndRowPos, llngEndColPos
            lcellRange = vsfChipMap.Selection
            llngStartRowPos = lcellRange.r1
            llngStartColPos = lcellRange.c1
            llngEndRowPos = lcellRange.r2
            llngEndColPos = lcellRange.c2
            
            '@ﾁｯﾌﾟ№ﾗﾍﾞﾙをｸﾘｱ
            lblChipNo.Text = vbNullString
            
            '@1ｾﾙのみ選択しているか
            If llngStartRowPos = llngEndRowPos And llngStartColPos = llngEndColPos Then
                
                '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐 〓
                Select Case cmdHyouri.Text
                    
                    '@〓 表へ 〓
                    Case CMstrCmdHyouriKbn1
                    
                        '@ﾁｯﾌﾟ№にWF情報のﾁｯﾌﾟIDを表示
                        lblChipNo.Text = _
                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngStartRowPos-1, _
                                    mlngChipGridMaxCols - llngStartColPos).strChipId, 3)
                    
                    '@〓 裏へ 〓
                    Case CMstrCmdHyouriKbn2
                        
                        '@ﾁｯﾌﾟ№にWF情報のﾁｯﾌﾟIDを表示
                        lblChipNo.Text = _
                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngStartRowPos-1, _
                                    llngStartColPos-1).strChipId, 3)
                End Select
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "vsfChipMap_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfChipMap_KeyUp
    '機　能：ﾁｯﾌﾟｸﾞﾘｯﾄﾞ(ﾁｯﾌﾟﾏｯﾌﾟ)　ｷｰ押上時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 19:53:52 Y.Yamagishi
    '更新日：2008/04/25 (Fri) 16:36:16 N.Kojima
    '備　考：
    '　　　：2008/04/25 (Fri) 16:36:16 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub vsfChipMap_KeyUp(ByVal sender As Object, ByVal e As EventArgs) Handles vsfChipMap.KeyUp
        
        Dim llngStartRowPos         As Integer      '開始行位置
        Dim llngStartColPos         As Integer      '開始列位置
        Dim llngEndRowPos           As Integer      '終了行位置
        Dim llngEndColPos           As Integer      '終了列位置
        Dim lcellRange              As CellRange    'NSYS 選択範囲取得

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfChipMap.Rows.Count <= vsfChipMap.Rows.Fixed Then
                Return
            End If
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①選択状況ﾁｪｯｸ(ﾁｯﾌﾟが選択されているか)
            '@　　②ﾁｯﾌﾟﾗﾍﾞﾙ表示処理(表裏別)
            '@======================================================================================
            
            
            '@ﾁｯﾌﾟﾏｯﾌﾟの選択ｾﾙがﾃﾞｰﾀｾﾙ(ﾁｯﾌﾟ番号が表示されているｾﾙ)か
            If vsfChipMap.Row < 1 Or vsfChipMap.Col < 1 Then
                Exit Sub
            End If
            
            '@ﾁｯﾌﾟﾏｯﾌﾟの選択状態を参照
            'vsfChipMap.GetSelection llngStartRowPos, llngStartColPos, llngEndRowPos, llngEndColPos
            lcellRange = vsfChipMap.Selection
            llngStartRowPos = lcellRange.r1
            llngStartColPos = lcellRange.c1
            llngEndRowPos = lcellRange.r2
            llngEndColPos = lcellRange.c2
            
            '@ﾁｯﾌﾟ№ﾗﾍﾞﾙをｸﾘｱ
            lblChipNo.Text = vbNullString
            
            '@1ｾﾙのみ選択しているか
            If llngStartRowPos = llngEndRowPos And llngStartColPos = llngEndColPos Then
                
                '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐 ★
                Select Case cmdHyouri.Text
                    
                    '@〓 表へ 〓
                    Case CMstrCmdHyouriKbn1
                        
                        '@ﾁｯﾌﾟ№にWF情報のﾁｯﾌﾟIDを表示
                        lblChipNo.Text = _
                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngStartRowPos-1, _
                                    mlngChipGridMaxCols - llngStartColPos).strChipId, 3)
                    
                    '@〓 裏へ 〓
                    Case CMstrCmdHyouriKbn2
                        
                        '@ﾁｯﾌﾟ№にWF情報のﾁｯﾌﾟIDを表示
                        lblChipNo.Text = Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngStartRowPos-1, _
                                                    llngStartColPos-1).strChipId, 3)
                
                End Select
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "vsfChipMap_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfChipMap_MouseUp
    '機　能：ﾁｯﾌﾟｸﾞﾘｯﾄﾞ(ﾁｯﾌﾟﾏｯﾌﾟ)　ﾏｳｽｱｯﾌﾟ時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：X軸
    '　　　：Y      ：Y軸
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 19:54:29 Y.Yamagishi
    '更新日：2016/02/08 (Mon) 22:21:33 H.Hayashi
    '備　考：
    '　　　：2006/01/24 (Tue) 09:49:41 N.Kasai      ﾁｯﾌﾟ複数選択可
    '　　　：2008/04/25 (Fri) 16:43:08 N.Kojima     ｿｰｽ整備。(案件№02786)
    '      ：2016/02/05 (Fri) 14:15:43 H.Hayashi    GRB対応(R12-04)
    Private Sub vsfChipMap_MouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles vsfChipMap.MouseUp
        
        Dim llngStartRowPos         As Integer      '開始行位置
        Dim llngStartColPos         As Integer      '開始列位置
        Dim llngEndRowPos           As Integer      '終了行位置
        Dim llngEndColPos           As Integer      '終了列位置
        Dim llngRowCnt              As Integer      '行ｶｳﾝﾄ
        Dim llngColCnt              As Integer      '列ｶｳﾝﾄ
        Dim strTmpColorCd           As Integer      '機種別色指定ｺｰﾄﾞ格納用(&+HXXXXXX)
        Dim lcellRange              As CellRange    'NSYS 選択範囲取得

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfChipMap.Rows.Count <= vsfChipMap.Rows.Fixed Then
                Return
            End If
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①選択状況ﾁｪｯｸ(ﾁｯﾌﾟが選択されているか)
            '@　　②ﾁｯﾌﾟﾗﾍﾞﾙ表示処理(表裏別)
            '@　　③ﾁｯﾌﾟの背景色設定処理
            '@======================================================================================
            
            
            '@ﾁｯﾌﾟﾏｯﾌﾟの選択ｾﾙがﾃﾞｰﾀｾﾙ(ﾁｯﾌﾟ番号が表示されているｾﾙ)か
            If vsfChipMap.Row < 1 Or vsfChipMap.Col < 1 Then
                Exit Sub
            End If
            
            '@ﾁｯﾌﾟﾏｯﾌﾟの選択状態を参照
            'vsfChipMap.GetSelection llngStartRowPos, llngStartColPos, llngEndRowPos, llngEndColPos
            lcellRange = vsfChipMap.Selection
            llngStartRowPos = lcellRange.r1
            llngStartColPos = lcellRange.c1
            llngEndRowPos = lcellRange.r2
            llngEndColPos = lcellRange.c2
            
            '@ﾁｯﾌﾟ№ﾗﾍﾞﾙをｸﾘｱ
            lblChipNo.Text = vbNullString
            
            '@1ｾﾙのみ選択しているか
            If llngStartRowPos = llngEndRowPos And llngStartColPos = llngEndColPos Then
                
                '@★ 表裏ﾎﾞﾀﾝの表示により処理分岐 ★
                Select Case cmdHyouri.Text
                    
                    '@〓 表へ 〓
                    Case CMstrCmdHyouriKbn1
                    
                        '@ﾁｯﾌﾟ№にWF情報のﾁｯﾌﾟIDを表示
                        lblChipNo.Text = _
                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngStartRowPos-1, _
                                    mlngChipGridMaxCols - llngStartColPos).strChipId, 3)

                    '@〓 裏へ 〓
                    Case CMstrCmdHyouriKbn2
                        
                        '@ﾁｯﾌﾟ№にWF情報のﾁｯﾌﾟIDを表示
                        lblChipNo.Text = _
                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngStartRowPos-1, _
                                    llngStartColPos-1).strChipId, 3)
                
                End Select
            End If

            Dim newStyle_BC_vbWhite As CellStyle = vsfChipMap.Styles.Add("CustomStyle_BackColor_vbWhite")
            Dim newStyle_BC_CandidacyBackColor As CellStyle = vsfChipMap.Styles.Add("CustomStyle_BackColor_CMlngCandidacyBackColor")
            Dim cellRange As CellRange
            For llngRowCnt = llngStartRowPos To llngEndRowPos
                
                For llngColCnt = llngStartColPos To llngEndColPos
                    
                    '@不良(払出)適用ﾎﾞﾀﾝ、傾向適用ﾎﾞﾀﾝが有効か
                    If cmdFuryouTekiyou.Enabled = True Or cmdKeikouTekiyou.Enabled = True Then
                        
                        '@--------------------------------------------------------
                        '@ ﾊﾞｯｸｶﾗｰ判定
                        '@ ｸﾞﾘｯﾄﾞのﾊﾞｯｸｶﾗｰはVbWhiteではない為、指定色で判定する。
                        '@--------------------------------------------------------
                        '@★ 対象ﾁｯﾌﾟの状態により処理分岐 ★
                        Select Case vsfChipMap.GetCellRange(llngRowCnt, llngColCnt).StyleDisplay.BackColor
                            
                            '@〓 ﾚﾓﾝ色(既傾向色)、山吹色(現工程傾向色)、
                            '@　 ﾋﾟﾝｸ(既不良色)、赤ﾋﾟﾝｸ(現工程不良色)、
                            '@　 薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ(既払出色)、ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ(現工程払出色)、
                            '@　 濃い灰色(ﾁｯﾌﾟ用表表示色)、小豆色(ﾁｯﾌﾟ用裏表示色) 〓
                            Case ColorTranslator.FromWin32(CMlngKeikouColor), ColorTranslator.FromWin32(CMlngKeikouColorNow), _
                                ColorTranslator.FromWin32(CMlngFuryouColor), ColorTranslator.FromWin32(CMlngFuryouColorNow), _
                                ColorTranslator.FromWin32(CMlngHaraidashiColor), ColorTranslator.FromWin32(CMlngHaraidashiColorNow), _
                                ColorTranslator.FromWin32(CMlngChipOmoteBackColor), ColorTranslator.FromWin32(CMlngChipUraBackColor), _
                                ColorTranslator.FromWin32(CMlngReferOnlyColor)
                                
                                '@処理なし
                            
                            
                            '@〓 水色(適用候補色) 〓
                            Case ColorTranslator.FromWin32(CMlngCandidacyBackColor)
                                
                                '@対象ﾁｯﾌﾟの背景色を白にする
                                newStyle_BC_vbWhite.ForeColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngChipNoForeColor))
                                newStyle_BC_vbWhite.BackColor = Color.White
                                newStyle_BC_vbWhite.TextAlign = TextAlignEnum.RightCenter
                                cellRange = vsfChipMap.GetCellRange(llngRowCnt, llngColCnt)
                                cellRange.Style = newStyle_BC_vbWhite
                            
                            
                            '@〓 その他 〓
                            Case Else
                                
                                '@変数初期化
                                strTmpColorCd = 0
                                                       
                                '@機種別色指定ｺｰﾄﾞ設定の場合(組立工程のみ)
                                If ((pstrSBID = CPstrSBID2A0) And (ptypLotprestate.strColorCd <> vbNullString)) Then
                                
                                    '@機種別色指定ｺｰﾄﾞ設定(&+HXXXXXX)
                                    strTmpColorCd = CPstrAmpersand + ptypLotprestate.strColorCd
                                    
                                End If
                                
                                '@機種別色指定ｺｰﾄﾞ設定色の場合(ｳｪﾊの外側)
                                If vsfChipMap.GetCellRange(llngRowCnt, llngColCnt).StyleDisplay.BackColor = ColorTranslator.FromWin32(strTmpColorCd) Then
                                
                                    '@処理なし
                                Else
                                
                                    '@対象ﾁｯﾌﾟの背景色を水色にする
                                    newStyle_BC_CandidacyBackColor.ForeColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngChipNoForeColor))
                                    newStyle_BC_CandidacyBackColor.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngCandidacyBackColor))
                                    newStyle_BC_CandidacyBackColor.TextAlign = TextAlignEnum.RightCenter
                                    cellRange = vsfChipMap.GetCellRange(llngRowCnt, llngColCnt)
                                    cellRange.Style = newStyle_BC_CandidacyBackColor
                                End If

                        End Select
                    End If
                Next llngColCnt
            Next llngRowCnt
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "vsfChipMap_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfChipMap_MouseDown
    '機　能：ﾁｯﾌﾟｸﾞﾘｯﾄﾞ(ﾁｯﾌﾟﾏｯﾌﾟ)　ﾏｳｽﾎﾞﾀﾝ押下時処理
    '引　数：Button ：右,左ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '　　　：X      ：X座標
    '　　　：Y      ：Y座標
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 16:59:14 T.Kitagawa
    '更新日：2008/04/25 (Fri) 16:49:44 N.Kojima
    '備　考：
    '　　　：2008/04/25 (Fri) 16:49:44 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub vsfChipMap_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfChipMap.MouseDown
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfChipMap.Rows.Count <= vsfChipMap.Rows.Fixed Then
                Return
            End If

            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①押下ﾏｳｽﾎﾞﾀﾝ判定用変数への押下ﾎﾞﾀﾝ種別格納処理
            '@======================================================================================


            '@ﾏｳｽｲﾍﾞﾝﾄはﾏｳｽの右ﾎﾞﾀﾝ押下か
            If e.Button = MouseButtons.Right Then
                
                '@ﾏｳｽ右ﾎﾞﾀﾝ区分に"True：右ｸﾘｯｸ"をｾｯﾄ
                mblnRightButton = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "vsfChipMap_MouseDown"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optProcessKbn_Click
    '機　能：処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝ　選択時処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ(1:ﾁｯﾌﾟ登録、2:電特結果表示、3:WAIST結果表示)
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 10:51:33 T.Kitagawa
    '更新日：2008/04/25 (Fri) 16:51:47 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 10:46:39 H.Wajima     ﾁｯﾌﾟ№の初期化処理で、ｾﾙの選択状態によりｲﾝﾃﾞｯｸｽｴﾗｰが発生する問題を修正(№505)
    '　　　：2006/05/23 (Tue) 16:20:52 N.Kojima     ①「電特」が選択された場合、不良情報の引継ぎ構造体をｸﾘｱする。(ﾕｰｻﾞｰ要望№0185)
    '　　　：                                       ②「現不良」ﾎﾞﾀﾝの制御。
    '　　　：2006/07/05 (Wed) 13:08:59 T.Kitagawa   不良ｺｰﾄﾞがｾﾞﾛ件の場合は「現不良」ﾎﾞﾀﾝを無効にする。(ﾕｰｻﾞｰ要望№0203のついでに対応)
    '　　　：2008/04/25 (Fri) 16:51:47 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub optProcessKbn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optProcessKbn1.Click, optProcessKbn2.Click, optProcessKbn3.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngWFStartIndex        As Integer              'WFの開始ｽﾛｯﾄ№
        Dim lstrWaistStatus         As String               'WAISTﾃﾞｰﾀ状態
        Dim Index                   As Integer              'NSYS ｲﾝﾃﾞｯｸｽ

        Try

            ' ｲﾝﾃﾞｯｸｽ設定
            If optProcessKbn1.Checked Then
                Index = CMlngProcessKbn1
            Else If optProcessKbn2.Checked Then
                Index = CMlngProcessKbn2
            Else If optProcessKbn3.Checked Then
                Index = CMlngProcessKbn3
            Else
                Throw(New IndexOutOfRangeException())
            End If
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①選択された処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝ別、情報取得処理(WAIST:WAISTﾃﾞｰﾀ状態取得etc...)
            '@　　②WAISTﾃﾞｰﾀ状態別、ｴﾗｰ表示処理
            '@　　③"ﾁｯﾌﾟ登録"選択時、不良/払出ｺｰﾄﾞ一覧の設定処理、各種ﾎﾞﾀﾝ制御処理、通常用ﾁｯﾌﾟﾏｯﾌﾟ設定
            '@　　④"電特"選択時、各種ｺﾝﾄﾛｰﾙの無効化、不良/払出ｺｰﾄﾞ格納構造体の初期化、電特用ﾁｯﾌﾟﾏｯﾌﾟ設定
            '@　　⑤"WAIST"選択時、不良/払出ｺｰﾄﾞ情報取得、不良/払出ｺｰﾄﾞ一覧設定、WAIST用ﾁｯﾌﾟﾏｯﾌﾟ設定
            '@　　⑥各種ﾎﾞﾀﾝの制御処理
            '@======================================================================================
            
            
            '@WAIST検査機の場合は、WAIST結果が格納されているか確認する(※装置ﾀｲﾌﾟがWAIST検査機の場合のみ)
            If Index = CMlngProcessKbn3 And ptypLotprestate.strEqType = CPstrEqTypeWAIST Then
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrOptProcessKbnClick)
                
                '@=======================
                '@ 【WAISTﾃﾞｰﾀ状態取得】ﾒｯｾｰｼﾞ送信処理
                '@=======================
                lblnAns = pubblnLotChkWaist_Sel(CMstrlot_chkwaistVer, _
                                                pstrSBID, _
                                                lblLotID.Text, _
                                                lstrWaistStatus)
                
                '@通信結果が"True:正常"か
                If lblnAns = True Then
                    '@結果：正常の場合
                
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrOptProcessKbnClick)
                Else
                    '@結果：異常の場合
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrOptProcessKbnClick)
                    
                    '@処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝを"ﾁｯﾌﾟ登録"に変更する
                    optProcessKbn1.Checked = True
                    Exit Sub
                End If
                
                
                '@★ WAISTﾃﾞｰﾀ状態により処理分岐 ★
                Select Case lstrWaistStatus
                    
                    '@〓 正常 〓
                    Case CMstrWaistStatus0
                    
                        '@処理なし
                    
                    
                    '@〓 DB更新中 〓
                    Case CMstrWaistStatus3
                        
                        '@"<TRM3TW>$$現在、WAIST検査機の結果を取得中です。$再度、選択してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003T)
                        Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                        
                        '@処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝを"ﾁｯﾌﾟ登録"に変更し、ﾌｫｰｶｽｾｯﾄ
                        optProcessKbn1.Checked = True
                        Call pubSetFocus(optProcessKbn1)
                        
                        Exit Sub
                    

                    '@〓 DB更新異常 〓
                    Case CMstrWaistStatus4
                        
                        '@"<TRM0HE>$$WAIST検査機の結果取得中にエラーが発生しました。$システム担当者に連絡してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000H)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝを"ﾁｯﾌﾟ登録"に変更し、ﾌｫｰｶｽｾｯﾄ
                        optProcessKbn1.Checked = True
                        Call pubSetFocus(optProcessKbn1)
                        
                        Exit Sub
                    

                    '@〓 その他の異常 〓
                    Case Else
                        
                        '@"<TRM0GE>$$WAIST検査機の状態エラーが発生しました。$システム担当者に連絡してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000G)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝを"ﾁｯﾌﾟ登録"に変更し、ﾌｫｰｶｽｾｯﾄ
                        optProcessKbn1.Checked = True
                        Call pubSetFocus(optProcessKbn1)
                        
                        Exit Sub
                        
                End Select
            End If
            
            
            '@*********************
            '@ 不良/払出ｺｰﾄﾞ一覧の設定
            '@*********************
            '@★ 処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
            Select Case Index
                
                '@〓 ﾁｯﾌﾟ登録 〓
                Case CMlngProcessKbn1
                    
                    '@不良/払出ｺｰﾄﾞｸﾞﾘｯﾄﾞを有効にする
                    vsfScpList.Enabled = True
                    
                    '@=======================
                    '@ 不良/払出ｺｰﾄﾞ一覧の設定処理
                    '@=======================
                    Call prvMasScpList_Set()
                
                    '@不良/払出ｺｰﾄﾞが1件以上あるか
                    If mtypMasScpList.lngListCnt > 0 Then
                    
                        '@現不良ﾎﾞﾀﾝを有効にする
                        cmdNowStepNG.Enabled = True
                    Else
                        '@不良/払出ｺｰﾄﾞが0件の場合
                    
                        '@現不良ﾎﾞﾀﾝを無効にする
                        cmdNowStepNG.Enabled = False
                    End If
                    
                    
                '@〓 電特 〓
                Case CMlngProcessKbn2
                
                    '@不良/払出ｺｰﾄﾞｸﾞﾘｯﾄﾞを無効にする
                    vsfScpList.Enabled = False
                    
                    '@ｶﾚﾝﾄ行の変更
                    vsfScpList.Row = -1
                    vsfScpList.Redraw = False
                    vsfScpList.Rows.Count = 1
                    vsfScpList.Redraw = True
                    
                    '@現不良ﾎﾞﾀﾝを無効にする
                    cmdNowStepNG.Enabled = False

                    '@引継ぎ構造体の初期化
                    'Erase ptypMasItemList.typeMasItem()
                    If Not IsNothing(ptypMasItemList.typeMasItem) Then
                        ptypMasItemList.typeMasItem.Clear()
                    End If
                    ptypMasItemList.lngListCnt = 0
                    ptypMasItemList.strLotEventId = CPstrZero
                
                
                '@〓 WAIST 〓
                Case CMlngProcessKbn3
                
                    '@不良/払出ｺｰﾄﾞｸﾞﾘｯﾄﾞを無効にする
                    vsfScpList.Enabled = True
                    
                    '@現不良ﾎﾞﾀﾝを無効にする
                    cmdNowStepNG.Enabled = False
                    
                    '@不良/払出ｺｰﾄﾞが0件か
                    If mtypMasWaistList.lngListCnt <= 0 Then
                        
                        '@ﾚｽﾎﾟﾝｽ取得開始
                        Call pubResponseStart(CMstrFormName, CMstrOptProcessKbnClick)
                        
                        '@=======================
                        '@ 【不良ｺｰﾄﾞ情報取得】ﾒｯｾｰｼﾞ送信処理
                        '@ ※処理区分=3H：不良/払出項目取得(WAIST指定)
                        '@=======================
                        lblnAns = pubblnMasScpList_Sel(pstrSBID, _
                                                       CMstrmas_scplist_Ver, _
                                                       CPstrCD3H, _
                                                       vbNullString, _
                                                       mtypMasWaistList)

                        '@通信結果が"True:正常"か
                        If lblnAns = True Then
                            '@結果：正常の場合
                        
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(CMstrFormName, CMstrOptProcessKbnClick)
                        Else
                            '@結果：異常の場合
                        
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrOptProcessKbnClick)
                            Exit Sub
                        End If
                    End If
                    
                    '@====================
                    '@ 不良/払出ｺｰﾄﾞ一覧作成処理
                    '@====================
                    Call prvMasScpList_Set()
                    
            End Select
            
            '@WFｽﾛｯﾄﾏｯﾌﾟが選択されているか
            If vsfWFMap.Row < 1 Then
                Exit Sub
            End If
            
            '@WFｽﾛｯﾄﾏｯﾌﾟの選択ｽﾛｯﾄ№がNULLか
            If vsfWFMap.GetDataDisplay(vsfWFMap.Row, CMlngvsfWFMapNo) = vbNullString Then
                Exit Sub
            End If
            
            '@WFｽﾛｯﾄﾏｯﾌﾟ情報の現在ｲﾝﾃﾞｯｸｽ(1～25)の設定
            mlngWFNowIndex = vsfWFMap.GetDataDisplay(vsfWFMap.Row, CMlngvsfWFMapNo)
            
            '@ﾚｽﾎﾟﾝｽ測定開始(初期WFIDの場合はｷｬﾘｱのLost時に行う為、初期WF以外の場合に測定する)
            llngWFStartIndex = 0
            For llngCnt = 1 To CMlngvsfWFMapMaxSlotID
                '@WFIDがNULL以外か
                If mtypWFInfo(llngCnt - 1).strWfId <> vbNullString Then
                    llngWFStartIndex = llngCnt
                    Exit For
                End If
            Next llngCnt


            '@************************************************
            '@ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより、ﾁｯﾌﾟﾏｯﾌﾟの表示を切替
            '@************************************************
            '@★ 処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
            Select Case Index
                
                '@〓 "ﾁｯﾌﾟ登録" 〓
                Case CMlngProcessKbn1
                
                    '@=======================
                    '@ ﾁｯﾌﾟﾏｯﾌﾟの表示処理
                    '@=======================
                    Call prvChipMapGrid_Set()
                
                
                '@〓 "電特" 〓
                Case CMlngProcessKbn2
                    
                    '@=======================
                    '@ ﾁｯﾌﾟﾏｯﾌﾟの表示処理(電特)
                    '@=======================
                    Call prvChipMapElectric_Set()

                
                '@〓 "WAIST" 〓
                Case CMlngProcessKbn3
                
                    '@=======================
                    '@ ﾁｯﾌﾟﾏｯﾌﾟの表示処理(WAIST)
                    '@=======================
                    Call prvChipMapWaist_Set()

            End Select
            
            '@ﾁｯﾌﾟﾏｯﾌﾟの選択ｾﾙがﾃﾞｰﾀｾﾙ(ﾁｯﾌﾟ番号が表示されているｾﾙ)か
            If vsfChipMap.Row < 1 Or vsfChipMap.Col < 1 Then
                '@ﾃﾞｰﾀｾﾙ以外

                '@ﾁｯﾌﾟ№をｸﾘｱする
                lblChipNo.Text = vbNullString
            Else
                '@ﾃﾞｰﾀｾﾙの場合
                
                '@選択されているｾﾙのﾁｯﾌﾟ№がNULLか
                If vsfChipMap.GetData(vsfChipMap.Row, vsfChipMap.Col) = vbNullString Then
                    '@NULLの場合
                    
                    '@ﾁｯﾌﾟ№に空白を設定する
                    lblChipNo.Text = vbNullString
                End If
            End If
            
            '@=======================
            '@ 各種ﾎﾞﾀﾝの制御処理
            '@=======================
            Call prvCmdButtonEnable_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "optProcessKbn_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/31 (Wed) 10:33:47 T.Kitagawa
    '更新日：2016/06/17 (Fri) 15:31:50 T.Oide
    '備　考：
    '　　　：2004/10/04 (Mon) 10:13:23 Y.Yamagishi  処理確定後に画面を閉じないように修正(不具合改善№1010)
    '　　　：2004/11/25 (Thu) 16:35:07 S.Deguchi    画面情報ﾘﾌﾚｯｼｭ処理を追加(但し,処理を行ったWFの情報を表示するようにする)
    '　　　：2005/03/01 (Tue) 10:53:36 S.Deguchi    不具合№352/561の対応で登録結果判別処理を追加
    '　　　：2005/07/12 (Tue) 13:34:19 N.Kojima     作業終了画面でのﾁｪｯｸﾎﾞｯｸｽの制御用に値を退避させる処理追加。(不具合№1875)
    '　　　：2006/05/18 (Thu) 21:26:18 N.Kojima     ﾁｯﾌﾟの現工程不良数格納処理を追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2006/06/26 (Mon) 17:37:04 T.Kitagawa   DataMatrixｺｰﾄﾞ(ﾊﾞｰｺｰﾄﾞ)対応(ﾕｰｻﾞ要望№0209)
    '　　　：2006/09/22 (Fri) 10:42:11 N.Kojima     ﾛｯﾄｱｳﾄ時の処理修正。(案件№01523)
    '　　　：2008/04/28 (Mon) 10:11:20 N.Kojima     ｿｰｽ整備、WF不良登録時の権限ﾁｪｯｸ追加。(案件№02786)
    '　　　：2009/03/31 (Tue) 14:37:53 N.Kojima     ﾁｯﾌﾟ払出対応に伴い処理追加/変更。(案件№03434)
    '　　　：2009/08/11 (Tue) 10:29:20 N.Kojima     試作実験ﾛｯﾄの場合、確定時に検査工数削減のMsgを表示する。(案件№03542)
    '　　　：2009/08/17 (Mon) 16:09:47 T.Inafune    パネル検査工程内の抜取・全数検査ﾁｪｯｸのMsgを表示する。(案件No.03609)
    '      ：2016/04/14 (Thu) 10:57:44 T.Inafune    案件No.REQ-1465 パ検不良入力後のWF情報初期化
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnInputCheck          As Boolean              '画面入力ﾁｪｯｸ(True:正常,False:異常)
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotInsprst          As LotInsprst           '不良保留払出傾向登録構造体
        Dim ltypWaferList           As Waferlist            'WFlist
        Dim llngWFNowIndex          As String               'WFの選択行
        '@↓2020/03/19 (Thu) 16:45:50 Y.Yoneyama 「.Netへ反映未」 **************************************************
        'Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        'Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ
        'Dim lblnChkExclusionProAns  As Boolean              '抜取検査結果格納(案件No:03609)
        'Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        '@↑2020/03/19 (Thu) 16:45:50 Y.Yoneyama 「.Netへ反映未」 **************************************************
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①確定時の入力ﾁｪｯｸ処理
            '@　　②不良登録権限ﾁｪｯｸ処理
            '@　　③不良/保留/払出/傾向登録処理
            '@　　④引継ぎ構造体への情報格納処理
            '@　　⑤各種情報の再取得、各種ｺﾝﾄﾛｰﾙへの再表示処理
            '@======================================================================================
            
            
            '@以下の場合、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑが無効な場合
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@Dmﾁｯﾌﾟ番号選択配列のｸﾘｱ
            Erase mstrDmSelectChipNo
            mlngDmSelectChipNoMaxCnt = 0
            
            '@=======================
            '@ 確定時の入力ﾁｪｯｸ処理
            '@=======================
            lblnInputCheck = prvblnRegistInput_Chk()
            
            '@処理結果判定
            If lblnInputCheck = False Then
                '@結果：異常の場合
                Exit Sub
            End If
            
            '@=======================
            '@ WF不良/払出権限ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnRegistAuthority_Chk()
            
            '@処理結果が"False:異常"か
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If
            
            '@=======================
            '@ 登録情報格納処理
            '@=======================
            Call prvRegistDataSet_Proc(ltypLotInsprst)
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
            
            '@画面の使用禁止
            Me.KeyPreview = False
            
            '@=======================
            '@ 【不良/保留/払出/傾向登録】ﾒｯｾｰｼﾞ送受信処理
            '@=======================
            lblnAns = pubblnLotInsprst_Ins(CMstrlot_insprst_Ver, _
                                           ltypLotInsprst, _
                                           mstrResult)
            
            '@画面の使用禁止解除
            Me.KeyPreview = True
            
            '@通信結果が"True:正常"か
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                
                '@引継ぎ用構造体に情報をｾｯﾄ
                With ptypWorkEndInfo
                    
                    .strCarrierId = txtCarrier.Text         'ｷｬﾘｱID
                    .strLotID = lblLotID.Text               'ﾛｯﾄID
                    .strfrmxxKbn = CPstrKeyEN0190           '子画面のﾌｫｰﾑ名
                    
                    '@*******************************************************
                    '@ 連続登録可能なことからﾛｯﾄｱｳﾄ⇒WF移載⇒ﾁｯﾌﾟの順に考える
                    '@*******************************************************
                    '@★ 作業ﾌﾗｸﾞ(0:処理なし/1:ﾁｯﾌﾟ/2:WF移載/3:ﾛｯﾄ終了)により処理分岐 ★
                    Select Case .strWorkKbn
                        
                        '@〓 3:ﾛｯﾄ終了(ﾛｯﾄｱｳﾄ) 〓
                        '@(※2009/08/11現在、ﾛｯﾄｱｳﾄはﾛｯﾄ終了画面からしか行えない)
                        Case CMstrLotEventLotOut
                        
                            '@処理抜け
                        
                        
                        '@〓 2:WF移載 〓
                        Case CMstrLotEventMove
                        
                            '@登録/更新結果が"3:ﾛｯﾄｱｳﾄ"か(※2009/08/11現在、ﾛｯﾄｱｳﾄはﾛｯﾄ終了画面からしか行えない)
                            If mstrResult = CMstrLotEventLotOut Then
                                
                                '@ﾛｯﾄｱｳﾄの場合は、作業ﾌﾗｸﾞに"3:ﾛｯﾄｱｳﾄ"をｾｯﾄ
                                .strWorkKbn = CMstrLotEventLotOut
                            End If
                        
                        
                        '@〓 1:ﾁｯﾌﾟ不良/保留/払出 〓
                        Case CMstrLotEventChip
                        
                            '@★★ 登録/更新結果により処理分岐 ★★
                            Select Case mstrResult
                                
                                '@〓〓 2:WF移載 〓〓
                                Case CMstrLotEventMove
                                    
                                    '@作業ﾌﾗｸﾞに"2:WF移載"をｾｯﾄ
                                    .strWorkKbn = CMstrLotEventMove
                                    
                                '@〓〓 3:ﾛｯﾄｱｳﾄ 〓〓
                                '@(※2009/08/11現在、ﾛｯﾄｱｳﾄはﾛｯﾄ終了画面からしか行えない)
                                Case CMstrLotEventLotOut
                                
                                    '@作業ﾌﾗｸﾞに"3:ﾛｯﾄｱｳﾄ"をｾｯﾄ
                                    .strWorkKbn = CMstrLotEventLotOut

                            End Select
                            

                        '@〓 その他 〓
                        Case Else
                        
                            '@★★ 登録/更新結果により処理分岐 ★★
                            Select Case mstrResult
                                
                                '@〓〓 1:ﾁｯﾌﾟ不良/保留/払出 〓〓
                                Case CMstrLotEventChip
                                
                                    '@作業ﾌﾗｸﾞに"1:ﾁｯﾌﾟ不良/保留/払出"をｾｯﾄ
                                    .strWorkKbn = CMstrLotEventChip
                                
                                '@〓〓 2:WF移載 〓〓
                                Case CMstrLotEventMove
                                
                                    '@作業ﾌﾗｸﾞに"2:WF移載"をｾｯﾄ
                                    .strWorkKbn = CMstrLotEventMove
                                    
                                '@〓〓 3:ﾛｯﾄｱｳﾄ 〓〓
                                '@(※2009/08/11現在、ﾛｯﾄｱｳﾄはﾛｯﾄ終了画面からしか行えない)
                                Case CMstrLotEventLotOut
                                
                                    '@作業ﾌﾗｸﾞに"3:ﾛｯﾄｱｳﾄ"をｾｯﾄ
                                    .strWorkKbn = CMstrLotEventLotOut
                                    
                                '@〓〓 その他 〓〓
                                Case Else
                                    
                                    '@作業ﾌﾗｸﾞに"NULL:その他"をｾｯﾄ
                                    .strWorkKbn = vbNullString

                            End Select

                    End Select
                    
                    '@作業終了画面ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御用に値を格納
                    pstrLotInsprstResult.strOpID = lblOpName.Text                   '大工程ID
                    pstrLotInsprstResult.strStepID = lblStepName.Text               '小工程ID
                    pstrLotInsprstResult.strLotID = lblLotID.Text                   'ﾛｯﾄID
                    pstrLotInsprstResult.strWorkKbn = .strWorkKbn                   '作業ﾌﾗｸﾞ
                    pstrLotInsprstResult.strSpecialRuteFlag = .strSpecialRuteFlag   '特殊ﾙｰﾄﾌﾗｸﾞ
                    
                End With
                
                '@最終更新日時を書換える
                mstrLotLastUpdate = ptypLotprestate.strLotLastUpdate
                
                '@登録/更新結果が"3:ﾛｯﾄｱｳﾄ"か(※2009/08/11現在、ﾛｯﾄｱｳﾄはﾛｯﾄ終了画面からしか行えない)
                If mstrResult = CMstrLotEventLotOut Then
                    '@3:ﾛｯﾄｱｳﾄの場合
                
                    '@「"<TRM32I>$$ロット[%2]終了しました。キャリア[%1]"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0032, txtCarrier.Text, lblLotID.Text)
                Else
                    '@3:ﾛｯﾄｱｳﾄ以外
                
                    '@「"<TRM34I>$$チップ情報を登録しました。キャリア[%1] ロット[%2]"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0034, txtCarrier.Text, lblLotID.Text)
                End If
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)


                '@"3:ﾛｯﾄｱｳﾄ"以外か(※2009/08/11現在、ﾛｯﾄｱｳﾄはﾛｯﾄ終了画面からしか行えない)
                If mstrResult <> CMstrLotEventLotOut Then
                    '@"3:ﾛｯﾄｱｳﾄ"以外の場合
                    
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
                    
                    '@画面の使用禁止
                    Me.KeyPreview = False
                    
                    '@=======================
                    '@ 【ﾛｯﾄ現在状態取得】ﾒｯｾｰｼﾞ送受信処理
                    '@ ※処理区分=1T：ﾛｯﾄ現在状態取得(ﾁｯﾌﾟ処置登録)
                    '@=======================
                    lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                    CPstrCD1T, _
                                                    txtCarrier.Text, _
                                                    ptypLotprestate)

                    '@画面の使用禁止解除
                    Me.KeyPreview = True

                    '@通信結果が"True:正常"か
                    If lblnAns = True Then
                        '@結果：正常の場合
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                        
                        '@ﾛｯﾄの良品、総不良、現不良、総払出、現払出の数量の再表示
                        With ptypLotprestate

                            '@-----------------------
                            '@　ﾁｯﾌﾟ良品数
                            '@-----------------------
                            vsfChipCnt.SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot, 0)
                            If IsNumeric(.strChipQuantity) = True Then
                                vsfChipCnt.SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot, Format(CInt(.strChipQuantity), CPstrDateFormatKanma))
                            End If
                            
                            '@-----------------------
                            '@　ﾁｯﾌﾟ総不良数
                            '@-----------------------
                            vsfChipCnt.SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntLot, 0)
                            If IsNumeric(.strChipOutQuantity) = True Then
                                vsfChipCnt.SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntLot, Format(CInt(.strChipOutQuantity), CPstrDateFormatKanma))
                            End If
                            
                            '@-----------------------
                            '@　ﾁｯﾌﾟ現不良数
                            '@-----------------------
                            vsfChipCnt.SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot, 0)
                            If IsNumeric(.strChipCurrentOutQuantity) = True Then
                                vsfChipCnt.SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot, Format(CInt(.strChipCurrentOutQuantity), CPstrDateFormatKanma))
                                ptypLotScrapInfo.strLotOutQuantity = .strChipCurrentOutQuantity
                            End If

                            '@-----------------------
                            '@　ﾁｯﾌﾟ総払出数
                            '@-----------------------
                            vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, 0)
                            If IsNumeric(.strChipForwardQuantity) = True Then
                                vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, Format(CInt(.strChipForwardQuantity), CPstrDateFormatKanma))
                            End If
                            
                            '@-----------------------
                            '@　ﾁｯﾌﾟ現払出数
                            '@-----------------------
                            vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, 0)
                            If IsNumeric(.strChipCurrentForwardQuantity) = True Then
                                vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, Format(CInt(.strChipCurrentForwardQuantity), CPstrDateFormatKanma))
                                ptypLotScrapInfo.strLotForwardQuantity = .strChipCurrentForwardQuantity
                            End If

                            '@起動SBが基板か
                            If pstrSBID = CPstrSBID1A0 Then
                            
                                '@払出数行は"-"で表示
                                vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, CPstrMinus)
                                vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, CPstrMinus)
                                vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, CPstrMinus)
                                vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, CPstrMinus)
                            End If
                        End With
                    Else
                        '@結果：異常の場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                        Exit Sub
                    End If
                    
                    '@WFｽﾛｯﾄﾏｯﾌﾟ選択行用に退避
                    llngWFNowIndex = mlngWFNowIndex
                    
                    
                    '@********************
                    '@　WFｽﾛｯﾄﾏｯﾌﾟの設定
                    '@********************
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
                    
                    '@画面の使用禁止
                    Me.KeyPreview = False
                    
                    '@=======================
                    '@ 【ﾛｯﾄWFﾏｯﾌﾟ情報取得】ﾒｯｾｰｼﾞ送受信処理
                    '@ ※処理区分=3N：ﾛｯﾄｳｪﾊ情報取得(全WF)
                    '@=======================
                    lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                                     txtCarrier.Text, _
                                                     CPstrCD3N, _
                                                     ltypWaferList)

                    '@画面の使用禁止解除
                    Me.KeyPreview = True

                    '@ｽﾛｯﾄｻｲｽﾞ退避
                    mstrSlotSize = ltypWaferList.strSlotSize
                    
                    '@通信結果が"True:正常"か
                    If lblnAns = True Then
                        '@結果：正常の場合
                    
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                    
                        '@=======================
                        '@ WFｽﾛｯﾄﾏｯﾌﾟの設定処理
                        '@=======================
                        Call prvLotWaferInfo_Set(ltypWaferList)
                        
                        '@選択行を設定する
                        vsfWFMap.Row = CLng(CMlngvsfWFMapMaxSlotID) - llngWFNowIndex + 1

                    Else
                        '@結果：異常の場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                        Exit Sub
                    End If


                    With vsfScpList

                        '@払出ｺｰﾄﾞが選択されているか
                        If .GetData(.Row, CMlngvsfScpListCode) = CPstrForwardCode Then
                            
                            '@傾向適用ﾎﾞﾀﾝを無効にする
                            cmdKeikouTekiyou.Enabled = False
                        End If
                    End With

                    '@↓2020/03/19 (Thu) 15:47:14 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    '@【抜取・全数ﾁｪｯｸ】
                    Call prvExclusionProcess

                    '@ﾊﾟﾈﾙ検査の場合
                    If Mid$(ptypLotprestate.strWpID, 1, 7) = CPstrPakenWpId Then
                        '@確定したWF_IDの表示を赤にする（作業漏れ対策）
                        Dim newStyle As CellStyle = vsfWFMap.Styles.Add("CustomStyle_ForeColor_vbRed")
                        newStyle.ForeColor = Color.Red
                        newStyle.Font = New Font(newStyle.Font, FontStyle.Bold)
                        Dim cellRange As CellRange = vsfWFMap.GetCellRange(vsfWFMap.Row, CMlngvsfWFMapID)
                        newStyle.BackColor = cellRange.Style.BackColor
                        cellRange.Style = newStyle
                        '@パ検行程は確定後Mapをｸﾘｱしたいので1行目(WFが紐つかない)を選択する
                        vsfWFMap.Row = 1
                    End If
                    '@↑2020/03/19 (Thu) 15:47:14 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    '@↓2020/03/19 (Thu) 15:46:59 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    'If pstrSBID = CPstrSBID2A0 Then
                    '    '@2A0：組立の場合
                    '    
                    '    '@ﾚｽﾎﾟﾝｽ取得開始
                    '    Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
                    '    
                    '    '@=======================
                    '    '@ 抜取・全数確認処理
                    '    '@=======================
                    '    '@【抜取・全数ﾁｪｯｸ】ﾒｯｾｰｼﾞ送受信処理
                    '    lblnChkExclusionProAns = pubblnLotExclusionProcess_Chk(CMstrlot_chkexclusionprocessVer, _
                    '                                                    lblLotID.Text, _
                    '                                                    lstrGuidMsg, _
                    '                                                    lstrGuidMsgCode)
                    '
                    '    '@抜取・全数ﾁｪｯｸ結果が"True：ﾁｪｯｸ処理成功"か
                    '    If lblnChkExclusionProAns = True Then
                    '    
                    '        '@ﾚｽﾎﾟﾝｽ取得終了
                    '        Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                    ' 
                    '        '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞがNULL以外か
                    '        If lstrGuidMsgCode <> vbNullString Then
                    ' 
                    '            '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                    '            lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                    '                                CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                    '                                CPstrMsgCrCode & lstrGuidMsg
                    '
                    '            '@表示ﾒｯｾｰｼﾞ変換
                    '            '@「上記編集済みｶﾞｲﾀﾞﾝｽMsg」のﾒｯｾｰｼﾞ表示
                    '            pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                    '            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '        End If
                    '        
                    '        '@パ検行程か
                    '        If Mid$(ptypLotprestate.strWpID, 1, 7) = CMstrPakenWpId Then
                    '        
                    '            '@確定したWF_IDの表示を赤にする　（作業漏れ対策）
                    '            Dim newStyle As CellStyle = vsfWFMap.Styles.Add("CustomStyle_ForeColor_vbRed")
                    '            newStyle.ForeColor = Color.Red
                    '            newStyle.Font = New Font(newStyle.Font, FontStyle.Bold)
                    '            Dim cellRange As CellRange = vsfWFMap.GetCellRange(vsfWFMap.Row, CMlngvsfWFMapID)
                    '            newStyle.BackColor = cellRange.Style.BackColor
                    '            cellRange.Style = newStyle
                    '
                    '            '@パ検行程は確定後Mapをｸﾘｱしたいので1行目(WFが紐つかない)を選択する
                    '            vsfWFMap.Row = 1
                    '        End If
                    '    
                    '    Else
                    '    '@結果：異常の場合
                    ' 
                    '        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    '        Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                    '    End If
                    'End If
                    '@↑2020/03/19 (Thu) 15:46:59 Y.Yoneyama 「.Netへ反映未」 **************************************************                    

                    '@ｽｷｬﾝ入力ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtDmCode)
                Else
                    '@"3:ﾛｯﾄｱｳﾄ"の場合(※2009/08/11現在、ﾛｯﾄｱｳﾄはﾛｯﾄ終了画面からしか行えない)
                    
                    '@各種ｺﾝﾄﾛｰﾙを無効にする
                    cmdComments.Enabled = False             'ｺﾒﾝﾄ
                    cmdMapDownLoad.Enabled = False          'ﾏｯﾌﾟ読込
                    cmdFuryouTekiyou.Enabled = False        '不良(払出)適用
                    cmdKeikouTekiyou.Enabled = False        '傾向適用
                    cmdTekiyouClear.Enabled = False         '適用取消
                    cmdClear.Enabled = False                '取消
                    cmdRegist.Enabled = False               '確定
                End If
            Else
                '@結果：異常の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)

                '@画面の使用禁止解除
                Me.KeyPreview = True
            End If

            Exit Sub

        Catch ex As Exception

            '@画面の使用禁止解除
            Me.KeyPreview = True

            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdFuryouTekiyou_Click
    '機　能：不良(払出)適用ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/30 (Tue) 10:51:28 T.Kitagawa
    '更新日：2008/04/28 (Mon) 10:34:26 N.Kojima
    '備　考：
    '　　　：2004/09/13 (Mon) 10:04:48 Y.Yamagishi　ﾁｯﾌﾟを選択してから不良項目を選択し適用可能とする。
    '　　　：2006/01/25 (Wed) 09:11:27 N.Kasai      複数選択機能追加。
    '　　　：2006/05/23 (Tue) 14:18:48 N.Kojima     現工程不良数表示処理追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2008/04/28 (Mon) 10:34:26 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmdFuryouTekiyou_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFuryouTekiyou.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①不良(払出)適用ﾎﾞﾀﾝ、傾向適用ﾎﾞﾀﾝの制御処理
            '@　　②各種適用/適用取消処理Call、不良数ｶｳﾝﾄ処理
            '@======================================================================================
            

            '@不良(払出)適用、傾向適用ﾎﾞﾀﾝの制御
            cmdFuryouTekiyou.Font = New Font(cmdFuryouTekiyou.Font, FontStyle.Bold)            '不良(払出)適用ﾎﾞﾀﾝを太字にする
            cmdKeikouTekiyou.Font = New Font(cmdKeikouTekiyou.Font, FontStyle.Regular)         '傾向適用ﾎﾞﾀﾝを標準にする

            '@=======================
            '@ 各種適用/適用取消処理Call、不良/払出数ｶｳﾝﾄ処理
            '@=======================
            Call prvCommonTransaction_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdFuryouTekiyou_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdKeikouTekiyou_Click
    '機　能：傾向適用ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/30 (Tue) 10:51:28 T.Kitagawa
    '更新日：2008/04/28 (Mon) 10:38:46 N.Kojima
    '備　考：
    '　　　：2004/09/13 (Mon) 10:02:19 Y.Yamagishi  ﾁｯﾌﾟを選択してから不良項目を選択し適用可能とする
    '　　　：2006/01/25 (Wed) 09:12:00 N.Kasai      ﾁｯﾌﾟ複数選択
    '　　　：2006/05/23 (Tue) 14:18:48 N.Kojima     現工程不良数表示処理追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2008/04/28 (Mon) 10:38:46 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmdKeikouTekiyou_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdKeikouTekiyou.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①不良(払出)適用ﾎﾞﾀﾝ、傾向適用ﾎﾞﾀﾝの制御処理
            '@　　②各種適用/適用取消処理Call、不良数ｶｳﾝﾄ処理
            '@======================================================================================


            '@不良(払出)適用、傾向適用ﾎﾞﾀﾝの制御
            cmdFuryouTekiyou.Font = New Font(cmdFuryouTekiyou.Font, FontStyle.Regular)         '不良(払出)適用ﾎﾞﾀﾝを標準にする
            cmdKeikouTekiyou.Font = New Font(cmdKeikouTekiyou.Font, FontStyle.Bold)            '傾向適用ﾎﾞﾀﾝを太字にする
            
            '@=======================
            '@ 各種適用/適用取消処理Call、不良/払出数ｶｳﾝﾄ処理
            '@=======================
            Call prvCommonTransaction_Proc()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdKeikouTekiyou_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTekiyouClear_Click
    '機　能：適用取消ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/30 (Tue) 10:51:28 T.Kitagawa
    '更新日：2008/04/28 (Mon) 10:55:21 N.Kojima
    '備　考：
    '　　　：2006/01/25 (Wed) 09:12:47 N.Kasai      ﾁｯﾌﾟ複数選択
    '　　　：2006/05/23 (Tue) 14:18:48 N.Kojima     現工程不良数表示処理追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2008/04/28 (Mon) 10:55:21 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmdTekiyouClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTekiyouClear.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①各種適用/適用取消処理Call、不良/払出数ｶｳﾝﾄ処理
            '@======================================================================================
            
            
            '@=======================
            '@ 適用/適用取消処理Call、不良/払出数ｶｳﾝﾄ処理
            '@=======================
            Call prvCommonTransaction_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdTekiyouClear_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClear_Click
    '機　能：取消ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/31 (Wed) 10:14:37 T.Kitagawa
    '更新日：2008/04/28 (Mon) 11:23:13 N.Kojima
    '備　考：
    '　　　：2006/01/25 (Wed) 09:13:32 N.Kasai      ﾁｯﾌﾟ複数選択
    '　　　：2006/05/23 (Tue) 14:18:48 N.Kojima     現工程不良数表示処理追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2008/04/28 (Mon) 11:23:13 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①各種適用/適用取消処理Call、不良/払出数ｶｳﾝﾄ処理
            '@======================================================================================
            
            
            '@=======================
            '@ 適用/適用取消処理Call、不良/払出数ｶｳﾝﾄ処理
            '@=======================
            Call prvCommonTransaction_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdClear_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMapDownLoad_Click
    '機　能：ﾏｯﾌﾟ読込ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/13 (Mon) 11:02:47 Y.Yamagishi
    '更新日：2008/04/28 (Mon) 11:28:46 N.Kojima
    '備　考：
    '　　　：2004/09/24 (Fri) 21:31:15 Y.Yamagishi  電特結果がNG、NULLの場合ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
    '　　　：2006/05/18 (Thu) 21:26:18 N.Kojima     ﾁｯﾌﾟの現工程不良数格納処理を追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2006/08/09 (Wed) 16:17:47 N.Kojima     WFﾏｯﾌﾟ情報の取得関数の引数に"CLASS_DIVISION"追加。(案件№01100)
    '　　　：2006/10/26 (Thu) 14:17:39 N.Kasai      上記の修正戻し
    '　　　：2008/04/28 (Mon) 11:28:46 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2011/08/25 (Thu) 12:37:43 T.Oide       R8-3無機異物検査機Map反映機能で大幅変更(処理の大半を別関数に分離)
    Private Sub cmdMapDownLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMapDownLoad.Click


        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@以下の条件の場合、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑが無効(ﾛｯｸ中)の場合
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@処理結果判定
            If pblnCancel = True Then
                '@結果：異常orｷｬﾝｾﾙの場合
                Exit Sub
            End If
            
            '@装置によってﾏｯﾌﾟの取込処理を分岐
            Select Case ptypLotprestate.strEqType
            
                '@電特の場合
                Case CPstrEqTypeElect
                    '@電特ﾏｯﾌﾟ取得登録表示
                    Call prvEltMapGet()
                    
                '@無機異物の場合
               Case CPstrEqTypeVFI
                    '無機異物検査機の場合
                    Call prvVfiMapGet()
                    
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdMapDownLoad_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowStepNG_Click
    '機　能：現不良ﾎﾞﾀﾝ　押下＆Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/22 (Mon) 16:07:26 N.Kojima
    '更新日：2006/05/22 (Mon) 16:07:26
    '備　考：
    Private Sub cmdNowStepNG_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowStepNG.Click
        
        Dim lblnAns     As Boolean      '戻り値格納用
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①LOT(WF枚数分)ﾃﾞｰﾀ読込処理
            '@　　②現工程不良詳細表示画面起動＆表示処理
            '@======================================================================================
            
            
            '@読込中ﾌﾗｸﾞに"True:読込中"をｾｯﾄ
            mblnNowNGLoadFlag = True

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False

            '@=======================
            '@ LOT(WF枚数分)ﾃﾞｰﾀ読込処理
            '@=======================
            lblnAns = prvLoadingMessage_Disp()
            
            '@処理結果判定
            If lblnAns = True Then
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ 現工程不良詳細表示画面　起動処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxEN0191.Instance = New frmxxEN0191()

                '@子画面名称設定
                frmxxEN0191.Instance.Text = CPstrSubFormEN0191
                
                '@Form_Loadﾌﾗｸﾞが異常の場合
                If pblnFormLoad = False Then
                    '@異常の場合
                    
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    '@　ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    frmxxEN0191.Instance = Nothing
                    
                    Exit Sub
                End If
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ 現工程不良詳細表示画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxEN0191.Instance.ShowDialog(Me)
                frmxxEN0191.Instance = Nothing
                
            End If

            '@読込中ﾌﾗｸﾞの初期化
            mblnNowNGLoadFlag = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdNowStepNG_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDisplayKbn_Click
    '機　能：全体表示/拡大表示ﾎﾞﾀﾝ　押下＆Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/29 (Mon) 11:11:53 T.Kitagawa
    '更新日：2008/04/28 (Mon) 14:34:41 N.Kojima
    '備　考：
    '　　　：2008/04/28 (Mon) 14:34:41 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmdDisplayKbn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDisplayKbn.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①全体表示/拡大ﾎﾞﾀﾝ押下時のｷｬﾌﾟｼｮﾝ(ﾎﾞﾀﾝ名)変更処理
            '@　　②ﾁｯﾌﾟﾏｯﾌﾟの表示切替処理
            '@======================================================================================
            
            
            '@★ 全体表示/拡大ﾎﾞﾀﾝの表示により処理分岐 〓
            Select Case cmdDisplayKbn.Text
                
                '@〓 全体表示 〓
                Case CMstrCmdDisplayKbn1
                    
                    '@"全体表示"から"拡大表示"に変更
                    cmdDisplayKbn.Text = CMstrCmdDisplayKbn2
                
                '@〓 拡大表示 〓
                Case CMstrCmdDisplayKbn2
                    
                    '@"拡大表示"から"全体表示"に変更
                    cmdDisplayKbn.Text = CMstrCmdDisplayKbn1
            
            End Select
            
            '@=======================
            '@ ﾁｯﾌﾟﾏｯﾌﾟの表示切替処理
            '@=======================
            Call prvChipMapGridDisplayKbn_Set()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdDisplayKbn_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdHyouri_Click
    '機　能：表/裏ﾎﾞﾀﾝ　押下＆Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/30 (Tue) 10:16:25 T.Kitagawa
    '更新日：2008/04/28 (Mon) 14:38:37 N.Kojima
    '備　考：
    '　　　：2008/04/28 (Mon) 14:38:37 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmdHyouri_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHyouri.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①表/裏ﾎﾞﾀﾝ押下時のｷｬﾌﾟｼｮﾝ(ﾎﾞﾀﾝ名)変更処理
            '@　　②処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝ別、ﾁｯﾌﾟﾏｯﾌﾟ表示処理(ﾁｯﾌﾟ登録、電特、WAIST)
            '@　　③ﾌｫｰｶｽ制御処理
            '@======================================================================================
            

            '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐 〓
            Select Case cmdHyouri.Text
                
                '@〓 表へ 〓
                Case CMstrCmdHyouriKbn1
                    
                    '@"表へ"から"裏へ"に変更
                    cmdHyouri.Text = CMstrCmdHyouriKbn2
                
                '@〓 裏へ 〓
                Case CMstrCmdHyouriKbn2
                    
                    '@"裏へ"から"表へ"に変更
                    cmdHyouri.Text = CMstrCmdHyouriKbn1
            
            End Select
            
            
            '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 〓
            Select Case True
                
                '@〓 "ﾁｯﾌﾟ登録" 〓
                Case optProcessKbn1.Checked = True
                    
                    '@=======================
                    '@ 通常情報の表示処理
                    '@=======================
                    Call prvChipMapGrid_Set()
                
                
                '@〓 "電特" 〓
                Case optProcessKbn2.Checked = True
                    
                    '@=======================
                    '@ 電特結果情報の表示処理
                    '@=======================
                    Call prvChipMapElectric_Set()
                
                
                '@〓 "WAIST" 〓
                Case optProcessKbn3.Checked = True
                
                    '@=======================
                    '@ WAIST検査機結果情報の表示処理
                    '@=======================
                    Call prvChipMapWaist_Set()
                    
            End Select
            
            
            '@ﾃﾞｰﾀｾﾙが選択されているか
            If vsfChipMap.Row > 0 And vsfChipMap.Col > 0 Then
            
                '@ﾁｯﾌﾟﾏｯﾌﾟの選択列を現在選択されている行と正対象の行に変更する
                '@　※例:表は裏にした場合の列番号
                vsfChipMap.Select(vsfChipMap.Row, mlngChipGridMaxCols - vsfChipMap.Col + 1, False)
                
                '@ﾁｯﾌﾟﾏｯﾌﾟが有効か
                If vsfChipMap.Enabled = True Then
                    
                    '@ﾁｯﾌﾟﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfChipMap)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdHyouri_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdComments_Click
    '機　能：ｺﾒﾝﾄﾎﾞﾀﾝ　押下＆Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/06/01 (Wed) 08:57:24 S.Deguchi
    '更新日：2010/01/27 (Wed) 16:46:07 N.Kojima
    '備　考：
    '　　　：2005/11/18 (Fri) 11:43:15 N.Kojima     引継ぎｷｬﾘｱID、ﾛｯﾄID、起動区分を追加。(ﾕｰｻﾞｰ要望№0119)
    '　　　：2006/01/18 (Wed) 16:42:17 N.Kasai      緊急対応(ﾊﾝﾄﾞﾜｰｸL/Nの場合ｺﾒﾝﾄﾎﾞﾀﾝ押下でｴﾗｰ)
    '　　　：2006/01/25 (Wed) 13:46:26 N.Kasai      既存ﾊﾞｸﾞ修正(最終更新日時をﾛｯﾄｺﾒﾝﾄ画面より引き継ぐ)
    '　　　：2008/04/28 (Mon) 14:46:31 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2010/01/27 (Wed) 16:46:07 N.Kojima     ｺﾒﾝﾄ表示/登録画面がﾛｯﾄ処理順変更からも呼ばれるようになったことに伴い処理修正。(案件№03897)
    Private Sub cmdComments_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdComments.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①引継ぎ情報格納処理、引継ぎ情報初期化処理(戻って来た際)
            '@　　②ｺﾒﾝﾄ画面表示処理
            '@======================================================================================
            
            
            '@起動区分を設定(1：ﾁｯﾌﾟ状態変更登録)
            plngfrmxxCM00V0Kbn = CPlngNumOne
                
            '@ﾛｯﾄ現在情報取得で取得した、ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULL以外か
            If ptypLotprestate.strUnloaderCarrierID <> vbNullString Then
                '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱIDがNULL以外の場合
            
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDを格納する
                pstrCarrierID = ptypLotprestate.strUnloaderCarrierID
            Else
                '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱIDがNULLの場合
            
                '@ﾛｰﾀﾞｰｷｬﾘｱIDを退避
                pstrCarrierID = txtCarrier.Text
            End If
            
            '@現在の最終更新日時を退避
            pstrLotLastUpdate = mstrLotLastUpdate
            
            '@引継ぎ用にﾛｯﾄIDを退避
            pstrLotID = lblLotID.Text

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ ｺﾒﾝﾄ画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00V0.Instance.ShowDialog(Me)
            frmxxCM00V0.Instance = Nothing

            '@各種初期化
            plngfrmxxCM00V0Kbn = CPlngNumZero   '起動区分
            pstrCarrierID = vbNullString        '引継ぎ用ｷｬﾘｱID
            pstrLotID = vbNullString            '引継ぎ用ﾛｯﾄID
            
            '@ﾛｯﾄｺﾒﾝﾄ(子画面)より戻された、最終更新日時を反映
            '@　※ﾛｯﾄｺﾒﾝﾄ画面でｺﾒﾝﾄを更新されなければ、値は変更されません。
            mstrLotLastUpdate = pstrLotLastUpdate
            
            '@最終更新日時受渡し用退避変数の初期化
            pstrLotLastUpdate = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdComments_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 16:10:23 T.Kitagawa
    '更新日：2018/11/16 (Fri) 09:47:55 Y.Yoneyama
    '備　考：
    '　　　：2004/10/26 (Tue) 10:44:49 T.Kitagawa   DoEvents対応
    '　　　：2005/03/07 (Mon) 10:51:15 N.Kojima     戻り先画面の判定を追加(改善№512)
    '　　　：2006/03/23 (Thu) 14:12:21 N.Kojima     最終更新日時の格納処理追加(ﾕｰｻﾞｰ要望№0145ﾃｽﾄ中に気付いた点の修正)。
    '　　　：2006/05/23 (Tue) 16:45:16 N.Kojima     読込中の終了動作を禁止する。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2008/04/28 (Mon) 14:51:18 N.Kojima     ｿｰｽ整備。(案件№02786)
    '      ：2018/11/16 (Fri) 09:47:55 Y.Yoneyama   防湿ALD対応
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim llngRet         As Integer
        Dim ltypCommonInfo  As CommonInfo

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①起動区分別終了処理(子画面起動:呼び元画面への戻り処理、単独起動:終了処理)
            '@======================================================================================
            
            
            '@以下の条件の場合、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②DoEventsﾌﾗｸﾞor読込中ﾌﾗｸﾞが立っている場合
            If Cursor.Current = Cursors.WaitCursor Or _
                pblnTrnFlag = True Or mblnNowNGLoadFlag = True Then
                
                Exit Sub
            End If
            
            '@最終更新日時書換え
            ptypLotprestate.strLotLastUpdate = mstrLotLastUpdate
            
            '@子画面起動か
            If mblnFormStartKbn = True Then
                '@子画面起動の場合
            
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                Me.Close()

            Else
                '@単独起動の場合
            
                '@引継ぎ情報のｷｬﾘｱIDがNULL以外か
                If ptypCommonInfo.strCarrierId <> vbNullString Then
                    '@NULL以外の場合
                    
                    '@装置別ﾛｯﾄ一覧から引き継いで起動されたのか
                    If pblnfrmxxEN0150Kbn = True Then
                    
                        '@=======================
                        '@ 装置別ﾛｯﾄ一覧を起動する
                        '@=======================
                        Call pubMenuSelect_Proc(CPstrKeyEN0150)

                    '@装置別ﾛｯﾄ(防湿ALD)一覧から引き継いで起動された場合
                    ElseIf pblnfrmxxEN0151Kbn = True Then
                        '@装置別ﾛｯﾄ(防湿ALD)一覧を起動する
                        Call pubMenuSelect_Proc(CPstrKeyEN0151)

                    Else
                        '@装置別ﾛｯﾄ一覧以外からの起動
                    
                        '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧から引き継いで起動されたのか
                        If pblnfrmxxEN00J0Kbn = True Then
                            
                            '@=======================
                            '@ 装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧を起動する
                            '@=======================
                            Call pubMenuSelect_Proc(CPstrKeyEN00J0)

                        Else
                            '@工程別ﾛｯﾄ一覧から引き継いで起動された場合
                            
                            '@=======================
                            '@ 工程別ﾛｯﾄ一覧を起動する
                            '@=======================
                            Call pubMenuSelect_Proc(CPstrKeyEN0200)

                        End If
                    End If
                Else
                    '@NULLの場合
                    
                    '@=======================
                    '@ 終了処理
                    '@=======================
                    RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                    RemoveHandler txtDmCode.Validating, AddressOf txtDmCode_Validate
                    llngRet = publngEnd_Proc(CPstrKeyEN0190, ltypCommonInfo)
                    AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                    AddHandler txtDmCode.Validating, AddressOf txtDmCode_Validate
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              *関数の記述*
    '***************************************************************************************
    '======================================Private==========================================

    '関数名：prvFrmxxCM0080_Init
    '機　能：画面初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 16:26:46 T.Kitagawa
    '更新日：2014/11/21 (Fri) 15:57:08 T.Oide
    '備　考：
    '　　　：2004/10/04 (Mon) 10:28:03 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理追加
    '　　　：2004/10/21 (Thu) 10:46:35 T.Kitagawa   WAIST検査機対応に伴う処理ﾎﾞﾀﾝ追加
    '　　　：2004/10/25 (Mon) 15:05:18 T.Kitagawa   ﾁｯﾌﾟGridの行№を"00"ﾌｫｰﾏｯﾄする
    '　　　：2004/12/03 (Fri) 13:42:33 S.Deguchi    不具合№250対応で,WF単位のﾁｯﾌﾟ数を表示する領域を追加
    '　　　：2005/03/01 (Tue) 10:25:42 S.Deguchi    不具合№261の対応でWP_TYPEﾀｲﾌﾟ初期化処理追加
    '　　　：2005/08/05 (Fri) 14:59:41 N.Kasai      引数を判定してﾌｫｰﾑのｷｬﾌﾟｼｮﾝを変更
    '　　　：2005/09/02 (Fri) 11:38:01 N.Kasai      現不良項目追加
    '　　　：2006/03/08 (Wed) 18:09:41 N.Kojima     通常工程の「処理中」でもﾁｯﾌﾟ状態変更登録を可能とする対応により、
    '　　　：                                       "mstrWPTYPE"は不使用になった為、ｺﾒﾝﾄｱｳﾄ。(ﾕｰｻﾞｰ要望№0145)
    '　　　：2006/05/18 (Thu) 19:42:23 N.Kojima     不良数Col追加に伴う修正等。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2006/06/23 (Fri) 12:41:17 T.Kitagawa   DataMatrixｺｰﾄﾞ(ﾊﾞｰｺｰﾄﾞ)対応(ﾕｰｻﾞ要望№0209)
    '　　　：2006/07/11 (Tue) 17:15:53 T.Kitagawa   不良入力前の良品数を初期化する。(ﾕｰｻﾞ要望0210)
    '　　　：2006/07/27 (Thu) 19:37:50 T.Kitagawa   拡大表示後、別なｷｬﾘｱに変更した際にﾁｯﾌﾟGridのｽｸﾛｰﾙﾊﾞｰが表示されてしまう為、初期化を追加(案件№01355)
    '　　　：2006/09/22 (Fri) 10:21:13 N.Kojima     変数の初期化処理追加。(案件№01523)
    '　　　：2008/04/28 (Mon) 14:55:52 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2009/03/31 (Tue) 09:50:00 N.Kojima     ﾁｯﾌﾟ払出対応で色説明ﾗﾍﾞﾙの制御処理追加。(案件№3434)
    '　　　：2009/09/02 (Wed) 17:05:23 N.Kojima     不良ﾁｯﾌﾟ情報(№表示)対応。※不良ﾁｯﾌﾟについて、不良ｺｰﾄﾞではなくﾁｯﾌﾟ№で表示する。(案件№03685)
    '　　　：2010/06/10 (Thu) 16:36:08 T.Oide       案件№04059 左右別不良数表示機能追加
    '　　　：2014/11/21 (Fri) 15:57:08 T.Oide       (パ検)特殊表示対応
    Private Sub prvFrmxxCM0080_Init()

        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lstrFormTitle           As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①起動区分別、起動端末別に、機能関連情報取得処理
            '@　　②各種ｺﾝﾄﾛｰﾙの初期化処理(ﾗﾍﾞﾙ、ﾃｷｽﾄ、ﾎﾞﾀﾝ、ｵﾌﾟｼｮﾝﾎﾞﾀﾝ、ｸﾞﾘｯﾄﾞ、ﾌﾚｰﾑ)
            '@　　③各種ﾓｼﾞｭｰﾙ変数の初期化処理
            '@======================================================================================



            '@起動区分が"1：不良ﾁｯﾌﾟ情報(№表示)起動"か
            If plngfrmxxCM0080Kbn = CPlngNumOne Then

                '@=======================
                '@ 機能毎関連情報取得処理(不良ﾁｯﾌﾟ情報(№表示))
                '@=======================
                Call pubMenuItemCorrelation_Set(CPstrKeyEN02G0, lstrFormTitle)

            Else

                '@★ 端末(起動)区分(M:工程端末、S:ｽﾀｯﾌ端末、A:開発)により処理分岐 ★
                Select Case pstrTerminalMode
                    
                    '@〓 工程端末(M)で起動 〓
                    Case CPstrManufactureStatus
                        
                        '@=======================
                        '@ 機能毎関連情報取得処理(ﾁｯﾌﾟ状態変更登録)
                        '@=======================
                        Call pubMenuItemCorrelation_Set(CPstrKeyEN0190, lstrFormTitle)
                    
                    '@〓 ｽﾀｯﾌ(S) or 開発(A)で起動 〓
                    Case Else
                        
                        '@=======================
                        '@ 機能毎関連情報取得処理(ﾁｯﾌﾟ状態変更登録(上書き))
                        '@=======================
                        Call pubMenuItemCorrelation_Set(CPstrKeyEN01Q0, lstrFormTitle)
                        
                End Select
            End If
            

            '@★ 起動SBにより処理分岐 ★
            Select Case pstrSBID
                
                '@〓 1A0：基板で起動 〓
                Case CPstrSBID1A0
                    
                    '@各種説明ﾗﾍﾞﾙを無効＆非表示にする
                    lblHaraidashi.Enabled = False           '払出
                    lblHaraidashi.Visible = False
                    lblHaraidashiOld.Enabled = False        '払出(過去工程払出ｶﾗｰ)
                    lblHaraidashiOld.Visible = False
                    lblHaraidashiNew.Enabled = False        '払出(現工程払出ｶﾗｰ)
                    lblHaraidashiNew.Visible = False
                
                '@〓 2A0：組立で起動 〓
                Case CPstrSBID2A0
                    
                    '@各種説明ﾗﾍﾞﾙを有効＆表示にする
                    lblHaraidashi.Visible = True            '払出
                    lblHaraidashiOld.Visible = True         '払出(過去工程払出ｶﾗｰ)
                    lblHaraidashiNew.Visible = True         '払出(現工程払出ｶﾗｰ)
                    
                    '@各種説明ﾗﾍﾞﾙを無効＆非表示にする
                    lblWF.Enabled = False                   'WF
                    lblWF.Visible = False
                    lblNotti.Enabled = False                'ﾉｯﾁ
                    lblNotti.Visible = False

            End Select

            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@各ｺﾝﾄﾛｰﾙを初期化
            lblLotID.Text = vbNullString                             'ﾛｯﾄID
            lblFlowClass.Text = vbNullString                         '流動区分
            lblOpName.Text = vbNullString                            '大工程名
            lblStepName.Text = vbNullString                          '小工程名
            lblStatus.Text = vbNullString                            '状態
            lblChipNo.Text = vbNullString                            'ﾁｯﾌﾟ№
            cmdMapDownLoad.Enabled = False                           'ﾏｯﾌﾟ読込ﾎﾞﾀﾝ
            optProcessKbn1.Checked = True                            '処理ﾎﾞﾀﾝ(ﾁｯﾌﾟ登録を初期値)
            fraProcessKbn.Enabled = False                            '処理ﾎﾞﾀﾝ
            
            txtDmCode.Text = vbNullString                            'ｽｷｬﾝ入力
            txtDmCode.Enabled = False
            
            '@(ﾊﾟ検)特殊非表示
            labTokusyu.Visible = False
            labTokusyu.Text = vbNullString
            
            '@↓2020/03/19 (Thu) 16:09:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
            '@ﾊﾟﾈﾙ検査種類
            mstrPanelInspectType = vbNullString
            '@ﾊﾟﾈﾙ検査種類表示
            Call prvPanelInspectVisble
            '@↑2020/03/19 (Thu) 16:09:33 Y.Yoneyama 「.Netへ反映未」 **************************************************

            '@ﾛｯﾄ情報退避領域を初期化
            mstrTaihiCarrierID = vbNullString                        'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
               
            '@ﾓｼﾞｭｰﾙ変数の初期化
            mlngWFAryCnt = 0                '配列ｶｳﾝﾀ
            mblnNowNGLoadFlag = False       'WFﾃﾞｰﾀ読込中ﾌﾗｸﾞ
            mlngWFCnt = 0                   'WF数格納用
            mstrResult = vbNullString       '確定結果判定用
            mblnFuryouClass = False         '不良存在判定ﾌﾗｸﾞ
            mblnHaraidashiClass = False     '払出存在判定ﾌﾗｸﾞ
               
            '@***********************
            '@ ｸﾞﾘｯﾄ領域の初期化
            '@***********************
            '@-----------------------
            '@ WFｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ
            '@-----------------------
            With vsfWFMap
                .Redraw = False
                .Clear(ClearFlags.Content, .Rows.Fixed, .Cols.Fixed, .Rows.Count -1, .Cols.Count -1) '初期化
                .Rows(CMlngvsfWFMapNo).Height = CMlngvsfWFMapTitleHeight                             'ﾀｲﾄﾙの高さ設定
                
                '@ｽﾛｯﾄ№～移載先ｽﾛｯﾄ№
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbYellow_BackColor_CPlngBlueColor")
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfWFMapNo, CMlngvsfWFMapNo, CMlngvsfWFMapNo, .Cols.Count - 1)
                newStyle.Font = New Font(newStyle.Font.FontFamily, CMvsfTitleFontSize, newStyle.Font.Style, newStyle.Font.Unit) 'ﾌｫﾝﾄｻｲｽﾞ(12p)
                '@ﾀｲﾄﾙの色設定(ｽﾛｯﾄ№～移載先ｽﾛｯﾄ№)
                newStyle.ForeColor = Color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))
                newStyle.Trimming = StringTrimming.None 'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = newStyle
                
                
                '@行番号、書式、高さの設定
                Dim newStyle_BackColor_CMlngEnableTrueColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor")

                For llngCnt = 1 To CMlngvsfWFMapMaxSlotID
                    
                    '@ｽﾛｯﾄﾏｯﾌﾟ№
                    .SetData(llngCnt, CMlngvsfWFMapNo, _
                        Format$(CMlngvsfWFMapMaxSlotID - llngCnt + 1, CPstrSlotNoFormat))
                    
                    '@背景色設定(白)
                    newStyle_BackColor_CMlngEnableTrueColor.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngEnableTrueColor))
                    cellRange = .GetCellRange(llngCnt, CMlngvsfWFMapID, llngCnt, .Cols.Count - 1)
                    cellRange.Style = newStyle_BackColor_CMlngEnableTrueColor

                    '@高さ
                    .Rows(llngCnt).Height = CMlngvsfWFMapRowHeightMin
                Next llngCnt
                
                .TopRow = CMvsfTopRow
                .Row = 0
                '@非表示列の設定
                .Cols(CMlngvsfWFCfWfID).Visible = False
                .Redraw = True
            End With
            
            '@-----------------------
            '@ 不良/払出ｺｰﾄﾞｸﾞﾘｯﾄﾞ
            '@-----------------------
            With vsfScpList
                .Redraw = False
                .Top = CMlngvsfScpListTopN                                  'Top
                .Height = CMlngvsfScpListHeightN                            '高さ
                .Clear(ClearFlags.Content, .Rows.Fixed, .Cols.Fixed, .Rows.Count -1, .Cols.Count -1) '初期化
                .FocusRect = FocusRectEnum.None                             'ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .Rows(.Rows.Fixed - 1).Height = CMlngvsfScpListTitleHeight  'ﾀｲﾄﾙの高さ設定
                .Rows.Count = 1
                'Title設定
                .SetData(0, CMlngvsfScpListCode, "ｺｰﾄﾞ") 'ｺｰﾄﾞ
                .SetData(0, CMlngvsfScpListName, "名称") '名称
                .SetData(0, CMlngvsfScpListScrapNum, "数") '数
                
                '@ﾀｲﾄﾙ行の背景色、文字色の設定
                Dim newStyle As CellStyle = .Styles.Fixed
                newStyle.Font = New Font(newStyle.Font.FontFamily, CMvsfTitleFontSize, newStyle.Font.Style, newStyle.Font.Unit)  'ﾌｫﾝﾄｻｲｽﾞ(12p)
                
                newStyle.ForeColor = Color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))
                .Rows(.Rows.Fixed - 1).Height = CMlngvsfScpListTitleHeight     'ﾀｲﾄﾙの高さ設定
                newStyle.Trimming = StringTrimming.None 'NSYS ﾍｯﾀﾞは省略表示なしに設定
                .LeftCol = 0
                .Redraw = True
            End With
            
            
            '@-----------------------
            '@ ﾁｯﾌﾟ数ｸﾞﾘｯﾄﾞ
            '@-----------------------
            With vsfChipCnt
                
                .Enabled = True                             '有効
                .Redraw = False
                .Rows.Count = CMlngvsfChipCntRows           '行数設定
                .Height = CMlngvsfChipCntHeight             '高さ
                .Clear(ClearFlags.Content, .Rows.Fixed, .Cols.Fixed, .Rows.Count -1, .Cols.Count -1) '初期化

                '@列タイトル設定
                .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntTitle, CMstrItemNameOK)
                .SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntTitle, CMstrItemNameNG)
                .SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntTitle, CMstrItemNameNowNG)
                .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntTitle, CMstrItemNameAllFW)
                .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntTitle, CMstrItemNameNowFW)

                '@ﾁｯﾌﾟ数の初期設定(ﾛｯﾄ単位)
                .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot, vbNullString)
                .SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntLot, vbNullString)
                .SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot, vbNullString)
                .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, vbNullString)
                .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, vbNullString)
                
                ptypLotScrapInfo.strLotOutQuantity = CPstrZero
                ptypLotScrapInfo.strLotForwardQuantity = CPstrZero
                ptypLotScrapInfo.lngScrapInputBeforeChipCnt = 0
                
                If Not IsNothing(ptypLotScrapInfo.typWFScrapInfo) Then
                    ptypLotScrapInfo.typWFScrapInfo.Clear()
                End If

                '@ﾁｯﾌﾟ数の初期設定(WF単位)
                .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF, vbNullString)
                .SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntWF, vbNullString)
                .SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntWF, vbNullString)
                .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, vbNullString)
                .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, vbNullString)
                
                '@書式設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_CMvsfTitleFontSize")
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfChipCntTitle, CMlngvsfChipCntTitle, CMlngvsfChipCntNowFWRow, .Cols.Count - 1)
                newStyle.Font = New Font(newStyle.Font.FontFamily, CMvsfTitleFontSize, newStyle.Font.Style, newStyle.Font.Unit)
                cellRange.Style = newStyle
                
                '@ﾀｲﾄﾙの色設定
                Dim newStyle_title As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbYellow_BackColor_CPlngBlueColor")
                Dim cellRange_title As CellRange = .GetCellRange(CMlngvsfChipCntTitle, CMlngvsfChipCntTitle, CMlngvsfChipCntTitle, .Cols.Count - 1)
                newStyle_title.ForeColor = Color.Yellow
                newStyle_title.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))
                newStyle_title.Margins = New Printing.Margins(0,0,0,0)
                newStyle_title.Font = New Font(newStyle.Font.FontFamily, CMvsfTitleFontSize, newStyle.Font.Style, newStyle.Font.Unit)
                newStyle.Trimming = StringTrimming.None 'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange_title.Style = newStyle_title

                '@Rowの高さ設定
                .Rows(.Rows.Fixed - 1).Height = CMlngvsfScpListTitleHeight                 'ﾀｲﾄﾙの高さ設定
                .Rows(CMlngvsfChipCntOKRow).Height = CMlngvsfChipCntRowHeight             '良品
                .Rows(CMlngvsfChipCntAllNGRow).Height = CMlngvsfChipCntRowHeight          '総不良
                .Rows(CMlngvsfChipCntNowNGRow).Height = CMlngvsfChipCntRowHeight          '現不良
                .Rows(CMlngvsfChipCntAllFWRow).Height = CMlngvsfChipCntRowHeight          '総払出
                .Rows(CMlngvsfChipCntNowFWRow).Height = CMlngvsfChipCntRowHeight          '現払出

                .Row = 0
                .Redraw = True
                .Enabled = False
            
            End With
            
            
            '@-----------------------
            '@ ﾁｯﾌﾟ情報
            '@-----------------------
            With vsfChipMap
                .Redraw = False
                .Clear(ClearFlags.Content, .Rows.Fixed, .Cols.Fixed, .Rows.Count -1, .Cols.Count -1) '初期化
                .Rows.Count = CMlngvsfChipMapNomalMaxRows + 1
                .Cols.Count = CMlngvsfChipMapNomalMaxCols + 1
                .BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                .ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                .Row = -1
                .Col = -1
                .AllowEditing = False
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor")
                Dim cellRange As CellRange = .GetCellRange(1, 1, CMlngvsfChipMapNomalMaxRows, CMlngvsfChipMapNomalMaxCols)
                newStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngEnableTrueColor))
                newStyle.TextAlign = TextAlignEnum.RightCenter
                cellRange.Style = newStyle
                
                '@ﾀｲﾄﾙの高さ、幅の設定
                .Rows(CMlngvsfChipMapNo).Height = CMlngvsfChipMapTitleHeight
                .Cols(CMlngvsfChipMapNo).Width = CMlngvsfChipMapTitleWidth
                Dim newStyle_title As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbYellow_BackColor_CPlngBlueColor")
                Dim cellRange_title As CellRange = .GetCellRange(CMlngvsfChipMapNo, CMlngvsfChipMapNo, CMlngvsfChipMapNo, .Cols.Count - 1)
                newStyle_title.Font = New Font(newStyle_title.Font.FontFamily, CMvsfTitleFontSize, newStyle_title.Font.Style, newStyle_title.Font.Unit)
                newStyle_title.TextAlign = TextAlignEnum.CenterCenter
                newStyle.Trimming = StringTrimming.None 'NSYS ﾍｯﾀﾞは省略表示なしに設定
                
                '@ﾀｲﾄﾙの色設定
                newStyle_title.ForeColor = Color.Yellow
                newStyle_title.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))
                cellRange_title.Style = newStyle_title
                
                '@高さ、幅の最小値、最大値の初期設定
                .Rows.MaxSize = 0
                .Rows.MinSize = 0
                .Cols.MaxSize = 0
                .Cols.MinSize = 0
                
                '@行番号、書式、高さの設定
                For llngCnt = 1 To CMlngvsfChipMapNomalMaxRows
                    .SetData(llngCnt, CMlngvsfChipMapNo, Format$(llngCnt, CPstrSlotNoFormat))
                    .Rows(llngCnt).Height = CMlngvsfChipMapRowHeightMin
                Next llngCnt
                Dim newStyle_SlotNo As CellStyle = .Styles.Add("CustomStyle_SlotNo")
                newStyle_SlotNo.TextAlign = TextAlignEnum.RightCenter
                Dim cellRange_SlotNo As CellRange = .GetCellRange(1, CMlngvsfChipMapNo, CMlngvsfChipMapNomalMaxRows, CMlngvsfChipMapNo)
                cellRange_SlotNo.Style = newStyle_SlotNo
                
                '@列№、書式、幅の設定
                For llngCnt2 = 1 To CMlngvsfChipMapNomalMaxCols
                    .SetData(CMlngvsfChipMapNo, llngCnt2, Chr(CMlngKeyCodeA + llngCnt2 - 1))
                    .Cols(llngCnt2).Width = CMlngvsfChipMapColWidthMin
                Next llngCnt2
                Dim newStyle_ChipMapNo As CellStyle = .Styles.Add("CustomStyle_ChipMapNo")
                newStyle_ChipMapNo.TextAlign = TextAlignEnum.CenterCenter
                Dim cellRange_ChipMapNo As CellRange = .GetCellRange(1, 1, 1, CMlngvsfChipMapNomalMaxCols)
                cellRange_ChipMapNo.Style = newStyle_ChipMapNo
                
                '@高さ、幅の再調整
                .Height = CMlngvsfChipMapNomalHeight
                .Width = CMlngvsfChipMapNomalWidth
            
                '@ｽｸﾛｰﾙﾊﾞｰなし
                .ScrollBars = ScrollBars.None
                .Redraw = True
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvFrmxxCM0080_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxCM0080_CmbInit
    '機　能：各種ﾎﾞﾀﾝ、ｸﾞﾘｯﾄﾞの制御処理
    '引　数：lblnEnable：True:使用可能、False:使用不可
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 16:26:46 T.Kitagawa
    '更新日：2008/04/28 (Mon) 15:11:03 N.Kojima
    '備　考：
    '　　　：2004/10/21 (Thu) 11:37:04 T.Kitagawa   WAIST機対応
    '　　　：2005/06/01 (Wed) 08:51:37 S.Deguchi    ｺﾒﾝﾄ表示処理追加
    '　　　：2006/05/23 (Tue) 14:28:22 N.Kojima     「現工程」ﾎﾞﾀﾝの処理を追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2008/04/28 (Mon) 15:11:03 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvFrmxxCM0080_CmbInit(Optional ByVal lblnEnable As Boolean = False)

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①引数の値で各種ﾎﾞﾀﾝ、ｵﾌﾟｼｮﾝﾎﾞﾀﾝ、ｸﾞﾘｯﾄﾞの有効/無効制御を行なう
            '@　　②ﾁｯﾌﾟﾏｯﾌﾟの縦横の状態により、全体表示/拡大表示ﾎﾞﾀﾝの制御を行なう
            '@======================================================================================
            
            
            '@各種ﾎﾞﾀﾝの制御
            cmdHyouri.Enabled = lblnEnable                  '表/裏ﾎﾞﾀﾝ
            cmdDisplayKbn.Enabled = lblnEnable              '全体表示/拡大表示ﾎﾞﾀﾝ
            cmdFuryouTekiyou.Enabled = lblnEnable           '不良(払出)適用ﾎﾞﾀﾝ
            cmdKeikouTekiyou.Enabled = lblnEnable           '傾向適用ﾎﾞﾀﾝ
            cmdTekiyouClear.Enabled = lblnEnable            '適用取消ﾎﾞﾀﾝ
            cmdClear.Enabled = lblnEnable                   '取消ﾎﾞﾀﾝ
            cmdRegist.Enabled = lblnEnable                  '確定ﾎﾞﾀﾝ
            cmdComments.Enabled = lblnEnable                'ｺﾒﾝﾄ表示ﾎﾞﾀﾝ
            cmdNowStepNG.Enabled = lblnEnable               '現不良ﾎﾞﾀﾝ
            
            '@処理ﾎﾞﾀﾝ
            fraProcessKbn.Enabled = lblnEnable              '処理ﾎﾞﾀﾝ
            optProcessKbn1.Checked = True                   '処理ﾎﾞﾀﾝ(ﾁｯﾌﾟ登録を初期値)
            
            '@"True:使用可能"が引数で渡されているか
            If lblnEnable = True Then
            
                '@ﾁｯﾌﾟﾏｯﾌﾟの高さ、幅がｵｰﾊﾞｰしているか
                If mlblnRowHeigthOver = True Or mlblnColWidthOver = True Then
                    '@ｵｰﾊﾞｰしている場合
                    
                    '@全体表示/拡大表示ﾎﾞﾀﾝを有効にする
                    cmdDisplayKbn.Enabled = True
                Else
                    '@ｵｰﾊﾞｰしていない場合
                
                    '@全体表示/拡大表示ﾎﾞﾀﾝを無効にする
                    cmdDisplayKbn.Enabled = False
                End If
            End If
            
            '@表/裏ﾎﾞﾀﾝの初期設定(裏)
            cmdHyouri.Text = CMstrCmdHyouriKbn2
            
            '@表示区分ﾎﾞﾀﾝの初期設定(拡大表示)
            cmdDisplayKbn.Text = CMstrCmdDisplayKbn2

            '@ｸﾞﾘｯﾄﾞの制御
            vsfWFMap.Enabled = lblnEnable               'WFｽﾛｯﾄﾏｯﾌﾟ
            vsfChipMap.Enabled = lblnEnable             'ﾁｯﾌﾟﾏｯﾌﾟ
            
            '@不良(払出)適用、傾向適用ﾎﾞﾀﾝの選択初期化
            cmdFuryouTekiyou.Font = New Font(cmdFuryouTekiyou.Font, FontStyle.Bold)     '不良(払出)適用ﾎﾞﾀﾝを太字にする
            cmdKeikouTekiyou.Font = New Font(cmdKeikouTekiyou.Font, FontStyle.Regular)  '傾向適用ﾎﾞﾀﾝを標準にする

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvFrmxxCM0080_CmbInit"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmdButtonEnable_Chk
    '機　能：各種ﾎﾞﾀﾝの制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 10:08:56 Y.Yamagishi
    '更新日：2011/08/25 (Thu) 12:43:27 T.Oide
    '備　考：
    '　　　：2004/09/21 (Tue) 20:39:13 H.Wajima     不良ｺｰﾄﾞ0件の場合に、ﾎﾞﾀﾝ押下不可(№653)
    '　　　：                                       電特→ﾁｯﾌﾟの場合に、不良ｺｰﾄﾞｸﾞﾘｯﾄﾞのEnabledが設定されていないので修正
    '　　　：2004/09/27 (Mon) 10:23:15 Y.Yamagishi  ﾛｯﾄの状態が「後処理」の場合のみマップ読込ﾎﾞﾀﾝが有効となるように変更
    '　　　：2004/10/26 (Tue) 11:53:10 T.Kitagawa   ﾁｯﾌﾟMAPのｶﾚﾝﾄ行を保持させる
    '　　　：2004/11/25 (Thu) 11:33:25 S.Deguchi    ﾎﾞﾀﾝ設定を修正
    '　　　：2005/03/01 (Tue) 10:40:03 S.Deguchi    不具合№261の対応で各ﾎﾞﾀﾝ制御を修正
    '　　　：2005/08/24 (Wed) 11:01:16 N.Kojima     貼り合わせ済みﾁｪｯｸを追加。(運用不具合№501)
    '　　　：2006/01/17 (Tue) 17:32:39 N.Kasai      ODF工程は編集不可(暫定対応)
    '　　　：2006/02/09 (Thu) 17:19:25 N.Kasai      電特工程以外はﾀﾞｳﾝﾛｰﾄﾞﾎﾞﾀﾝ使用禁止
    '　　　：2006/03/14 (Tue) 17:28:44 N.Kojima     通常工程の処理中でもﾁｯﾌﾟ状態変更登録を行えるようにする。(ﾕｰｻﾞｰ要望№0145)
    '　　　：2006/09/22 (Fri) 10:27:07 N.Kojima     ﾛｯﾄ状態が"ﾛｯﾄｱｳﾄ"の場合は、各種ﾎﾞﾀﾝを無効にする。(案件№01523)
    '　　　：2007/02/14 (Wed) 15:41:10 N.Kasai      ﾛｯﾄ状態が処理中、後処理でもﾁｯﾌﾟ状態変更を可能とする。(№01739)
    '　　　：2008/04/30 (Wed) 13:49:18 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2011/08/25 (Thu) 12:43:27 T.Oide       R8-3無機異物検査対応
    Private Sub prvCmdButtonEnable_Chk()

        Dim lblnLotStatusFlag   As Boolean      'ﾛｯﾄ状態判定ﾌﾗｸﾞ(True:判定OK、False:判定NG)

        Try
                    
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①ﾛｯﾄ状態・装置ﾀｲﾌﾟ・処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝの選択状態・SBID別、各種ﾎﾞﾀﾝ制御処理
            '@======================================================================================
                    
                    
            '@★ ﾛｯﾄ状態により処理分岐 ★
            Select Case lblStatus.Text
                
                '@〓 作業待ち or 前処理 or 処理中 or 後処理 or 作業終了 〓
                Case CPstrWaitWorkSt, CPstrBeforeProgressSt, CPstrProcessingSt, CPstrAfterProgressSt, CPstrEndWorkSt
                    
                    '@ﾛｯﾄ状態判定ﾌﾗｸﾞに"True:判定OK"をｾｯﾄ
                    lblnLotStatusFlag = True
                
                '@〓 その他 〓
                Case Else
                    
                    '@ﾛｯﾄ状態判定ﾌﾗｸﾞに"False:判定NG"をｾｯﾄ
                    lblnLotStatusFlag = False

            End Select
               
            '@--------------------------------------
            '@以下の条件を満たすか
            '@　①処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝが"電特"
            '@　②ｼｽﾃﾑﾌﾞﾛｯｸが"1A0:基板"
            '@　③WFIDがNULL以外
            '@　④ﾛｯﾄ状態判定ﾌﾗｸﾞが"True:判定OK"
            '@--------------------------------------
            If optProcessKbn2.Checked = True _
                And pstrSBID = CPstrSBID1A0 And _
                mtypWFInfo(mlngWFNowIndex-1).strWfId <> vbNullString And _
                lblnLotStatusFlag = True Then
                
                '@装置ﾀｲﾌﾟが"6:電特装置"か
                If ptypLotprestate.strEqType = CPstrEqTypeElect Then
                    
                    '@★ ﾛｯﾄ状態により処理分岐(電特ﾏｯﾌﾟ読込は"処理中"、"後処理"のみ可) ★
                    Select Case lblStatus.Text
                        
                        '@〓 処理中 or 後処理 〓
                        Case CPstrProcessingSt, CPstrAfterProgressSt
                            
                            '@ﾏｯﾌﾟ読込ﾎﾞﾀﾝを有効にする
                            cmdMapDownLoad.Enabled = True
                        
                        '@〓 その他 〓
                        Case Else
                            
                            '@ﾏｯﾌﾟ読込ﾎﾞﾀﾝを無効にする
                            cmdMapDownLoad.Enabled = False

                    End Select
                End If
            Else
                'ﾁｯﾌﾟ登録で2A0で無機異物装置か
                If optProcessKbn1.Checked = True And _
                   pstrSBID = CPstrSBID2A0 And _
                   ptypLotprestate.strEqType = CPstrEqTypeVFI Then
                
                    '@ﾏｯﾌﾟ読込ﾎﾞﾀﾝを有効にする
                    cmdMapDownLoad.Enabled = True
                Else
                
                    '@ﾏｯﾌﾟ読込ﾎﾞﾀﾝを無効にする
                    cmdMapDownLoad.Enabled = False
                End If
            End If
                

            With ptypLotprestate
            
                '@-----------------------
                '@ 各種ﾎﾞﾀﾝの制御
                '@-----------------------
                
                '@--------------------------------------
                '@以下の条件の何れかに該当するか
                '@　①WFIDがNULL
                '@　②区分が良品以外
                '@　③ﾛｯﾄ状態判定ﾌﾗｸﾞがFalse
                '@　④不良ｺｰﾄﾞﾘｽﾄが0件
                '@--------------------------------------
                If mtypWFInfo(mlngWFNowIndex-1).strWfId = vbNullString Or _
                    mtypWFInfo(mlngWFNowIndex-1).strClass <> CPstrClass1 Or _
                    lblnLotStatusFlag = False Or _
                    mtypMasScpList.lngListCnt = 0 Then
                    '@上記の条件の何れかに該当した場合
                    
                    '@各種ﾎﾞﾀﾝを制御
                    cmdFuryouTekiyou.Enabled = False        '不良(払出)適用
                    cmdKeikouTekiyou.Enabled = False        '傾向適用
                    cmdTekiyouClear.Enabled = False         '適用取消
                    cmdClear.Enabled = False                '全部取消
                    cmdRegist.Enabled = False               '確定ﾎﾞﾀﾝ

                Else
                    '@上記の条件の何れにも該当しなかった場合
                
                    '@ﾁｯﾌﾟﾏｯﾌﾟを有効にする
                    vsfChipMap.Enabled = True

                    '@処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝにて"電特"、または"WAIST"が選択されているか
                    If optProcessKbn2.Checked = True Or _
                        optProcessKbn3.Checked = True Then
                       
                        '@各種ﾎﾞﾀﾝの制御(全て無効)
                        cmdFuryouTekiyou.Enabled = False    '不良(払出)適用
                        cmdKeikouTekiyou.Enabled = False    '傾向適用
                        cmdTekiyouClear.Enabled = False     '適用取消
                        cmdClear.Enabled = False            '全部取消
                        cmdRegist.Enabled = False           '確定

                    Else
                        '@処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝにて"ﾁｯﾌﾟ登録"が選択されている場合
                    
                        '@装置ﾀｲﾌﾟ(EQ_TYPE)が"4:TPAL装置"か
                        If .strEqType = CPstrEqTypeTPAL Then
                        
                            '@貼り合せﾌﾗｸﾞが"1:貼り合せ済み"か(CoverFlag=0：貼り合せ未完、CoverFlag=1：貼り合せ完了)
                            If .strCoverFlag = CPstrOne Then
                            
                                '@各種ﾎﾞﾀﾝの制御(全て有効)
                                cmdFuryouTekiyou.Enabled = True     '不良(払出)適用
                                cmdKeikouTekiyou.Enabled = True     '傾向適用
                                cmdTekiyouClear.Enabled = True      '適用取消
                                cmdClear.Enabled = True             '全部取消
                                cmdRegist.Enabled = True            '確定

                            '@"0:貼り合せ未完"の場合
                            Else
                                '@貼り合せ未完了の場合でも無機ﾊﾞｯﾁ貼り合せは例外とする
                                '@CF側が足りなくなる場合がある為
                                If .strVaFlag = CPstrOne And _
                                   (.strTpalClass = CPstrTpalJBatch Or _
                                    .strTpalClass = CPstrTpalJBatchLeft Or _
                                    .strTpalClass = CPstrTpalJBatchRight) Then
                            
                                    '@各種ﾎﾞﾀﾝの制御(全て有効)
                                    cmdFuryouTekiyou.Enabled = True     '不良(払出)適用
                                    cmdKeikouTekiyou.Enabled = True     '傾向適用
                                    cmdTekiyouClear.Enabled = True      '適用取消
                                    cmdClear.Enabled = True             '全部取消
                                    cmdRegist.Enabled = True            '確定
                            
                                Else
                                    '@各種ﾎﾞﾀﾝの制御(全て無効)
                                    cmdFuryouTekiyou.Enabled = False    '不良(払出)適用
                                    cmdKeikouTekiyou.Enabled = False    '傾向適用
                                    cmdTekiyouClear.Enabled = False     '適用取消
                                    cmdClear.Enabled = False            '全部取消
                                    cmdRegist.Enabled = False           '確定
                                End If
                            End If
                        Else
                            '@"4:TPAL装置"以外の場合
                        
                            '@各種ﾎﾞﾀﾝの制御(全て有効)
                            cmdFuryouTekiyou.Enabled = True     '不良(払出)適用
                            cmdKeikouTekiyou.Enabled = True     '傾向適用
                            cmdTekiyouClear.Enabled = True      '適用取消
                            cmdClear.Enabled = True             '全部取消
                            cmdRegist.Enabled = True            '確定
                        End If
                    
                        '@装置ﾀｲﾌﾟ(EQ_TYPE)が"14:ODF装置"か
                        If .strEqType = CPstrEqTypeODF Then
                        
                            '@各種ﾎﾞﾀﾝの制御(全て無効)
                            cmdFuryouTekiyou.Enabled = False    '不良(払出)適用
                            cmdKeikouTekiyou.Enabled = False    '傾向適用
                            cmdTekiyouClear.Enabled = False     '適用取消
                            cmdClear.Enabled = False            '全部取消
                            cmdRegist.Enabled = False           '確定
                        End If
                    End If
            
                    '@不良/払出ｺｰﾄﾞ一覧を有効にする
                    vsfScpList.Enabled = True
                End If

            End With
            
            '@ﾛｯﾄ状態が"3:ﾛｯﾄｱｳﾄ"か(※2009/08/11現在、ﾛｯﾄｱｳﾄはﾛｯﾄ終了画面からしか行えない)
            If mstrResult = CMstrLotEventLotOut Then
            
                '@各種ｺﾝﾄﾛｰﾙを無効にする
                cmdComments.Enabled = False             'ｺﾒﾝﾄ
                cmdMapDownLoad.Enabled = False          'ﾏｯﾌﾟ読込
                cmdFuryouTekiyou.Enabled = False        '不良(払出)適用
                cmdKeikouTekiyou.Enabled = False        '傾向適用
                cmdTekiyouClear.Enabled = False         '適用取消
                cmdClear.Enabled = False                '取消
                cmdRegist.Enabled = False               '確定
            End If

            With vsfScpList
                
                If .Row > 1 Then
                
                    '@払出ｺｰﾄﾞが選択されているか
                    If .GetData(.Row, CMlngvsfScpListCode) = CPstrForwardCode Then
                        
                        '@傾向適用ﾎﾞﾀﾝを無効にする
                        cmdKeikouTekiyou.Enabled = False
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvCmdButtonEnable_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxCM0080_Disp
    '機　能：画面情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/24 (Wed) 11:22:38 T.Kitagawa
    '更新日：2014/11/21 (Fri) 14:07:00 T.Oide
    '備　考：
    '　　　：2004/09/30 (Thu) 15:28:52 Y.Yamagishi  ﾁｯﾌﾟ不良数がNULLの場合初期値に0を入れる(不具合改善№1010)
    '　　　：2004/09/30 (Thu) 17:12:27 Y.Yamagishi  ﾁｯﾌﾟ良品数を計算して表示する(不具合改善№1014)
    '　　　：2004/10/05 (Tue) 16:05:16 Y.Yamagishi  ﾁｯﾌﾟ良品数を計算して表示する処理を削除(不具合改善№1016)
    '　　　：2005/03/01 (Tue) 10:27:05 S.Deguchi    不具合№261の対応でWP_TYPE追加
    '　　　：2005/06/01 (Wed) 09:00:01 S.Deguchi    ﾛｯﾄｺﾒﾝﾄを退避
    '　　　：2005/09/02 (Fri) 16:01:56 N.Kasai      ﾁｯﾌﾟ現不良数追加
    '　　　：2005/11/18 (Fri) 15:54:50 N.Kojima     ｺﾒﾝﾄ退避処理をｺﾒﾝﾄｱｳﾄ。(ﾕｰｻﾞｰ要望№0119)
    '　　　：2006/03/08 (Wed) 18:09:41 N.Kojima     通常工程の「処理中」でもﾁｯﾌﾟ状態変更登録を可能とする対応により、
    '　　　：                                       "mstrWPTYPE"は不使用になった為、ｺﾒﾝﾄｱｳﾄ。(ﾕｰｻﾞｰ要望№0145)
    '　　　：2006/05/18 (Thu) 21:01:20 N.Kojima     ﾁｯﾌﾟ(Lot単位)の現工程不良数を格納する処理追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2006/07/10 (Mon) 20:38:41 T.Kitagawa   不良入力前の良品数を退避する。(ﾕｰｻﾞ要望0210)
    '　　　：2008/04/28 (Mon) 15:21:58 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2010/06/10 (Thu) 16:36:08 T.Oide       案件№04059 左右別不良数表示機能追加
    '　　　：2014/06/09 (Mon) 15:28:00 T.Inafune    機種名表示追加
    '　　　：2014/11/21 (Fri) 14:07:00 T.Oide       (ﾊﾟ検)特殊表示対応
    Private Sub prvFrmxxCM0080_Disp()

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①各種ﾗﾍﾞﾙへの情報表示、ﾁｯﾌﾟ情報一覧の表示
            '@======================================================================================


            '@-----------------------
            '@ ﾛｯﾄ情報の表示
            '@-----------------------
            With ptypLotprestate
                
                '@基本情報
                lblLotID.Text = .strLotID               'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass       '流動区分
                '@=======================
                '@ 機種名表示追加
                lblPdID.Text = .strPdId                 '機種名
                '@=======================
                lblOpName.Text = .strOpID               '大工程名
                lblStatus.Text = .strNowST              '状態
                lblStepName.Text = .strStepID           '小工程名
                mstrLotLastUpdate = .strLotLastUpdate   'ﾛｯﾄ最終更新日時
                
                '@(ﾊﾟ検)特殊表示は空以外か
                If .strTokusyu <> vbNullString Then
                    '@(ﾊﾟ検)特殊表示
                    labTokusyu.Visible = True
                    labTokusyu.Text = .strTokusyu
                Else
                    '@(ﾊﾟ検)特殊非表示
                    labTokusyu.Visible = False
                    labTokusyu.Text = vbNullString
                End If
                
                '@***********************
                '@ ﾁｯﾌﾟ情報一覧の表示
                '@***********************
                
                '@-----------------------
                '@ ﾁｯﾌﾟ良品数
                '@-----------------------
                vsfChipCnt.SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot, 0)
                If IsNumeric(.strChipQuantity) = True Then
                    vsfChipCnt.SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot, Format(CInt(.strChipQuantity), CPstrDateFormatKanma))
                End If
                
                '@-----------------------
                '@ ﾁｯﾌﾟ総不良数
                '@-----------------------
                vsfChipCnt.SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntLot, 0)
                If IsNumeric(.strChipOutQuantity) = True Then
                    vsfChipCnt.SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntLot, Format(CInt(.strChipOutQuantity), CPstrDateFormatKanma))
                End If
                
                '@-----------------------
                '@ ﾁｯﾌﾟ現不良数
                '@-----------------------
                vsfChipCnt.SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot, 0)
                If IsNumeric(.strChipCurrentOutQuantity) = True Then
                    vsfChipCnt.SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot, Format(CInt(.strChipCurrentOutQuantity), CPstrDateFormatKanma))
                    '@ﾛｯﾄの現工程不良数を格納
                    ptypLotScrapInfo.strLotOutQuantity = .strChipCurrentOutQuantity
                End If
                
                '@-----------------------
                '@ ﾁｯﾌﾟ総払出数
                '@-----------------------
                vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, 0)
                If IsNumeric(.strChipForwardQuantity) = True Then
                    vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, Format(CInt(.strChipForwardQuantity), CPstrDateFormatKanma))
                End If
                
                '@-----------------------
                '@ ﾁｯﾌﾟ現払出数
                '@-----------------------
                vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, 0)
                If IsNumeric(.strChipCurrentForwardQuantity) = True Then
                    vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, Format(CInt(.strChipCurrentForwardQuantity), CPstrDateFormatKanma))
                    '@ﾛｯﾄの現工程払出数を格納
                    ptypLotScrapInfo.strLotForwardQuantity = .strChipCurrentForwardQuantity
                End If
                
                '@ﾛｯﾄは無機か
                If .strVaFlag = CPstrOne Then
                    
                    '@-----------------------
                    '@ 画面をVA用に変更
                    '@-----------------------
                    vsfScpList.Height = CMlngvsfScpListHeightVA                                     'vsfScpListｸﾞﾘｯﾄﾞの高さ設定
                    vsfScpList.Top = CMlngvsfScpListTopVA                                           'vsfScpListｸﾞﾘｯﾄﾞのTop設定
                    
                    vsfChipCnt.Height = CMlngvsfChipCntHeightVA                                     'vsfChipCntｸﾞﾘｯﾄﾞの高さ設定
                    vsfChipCnt.Rows.Count = CMlngvsfChipCntRowsVA                                   '行数追加
                    vsfChipCnt.Rows(CMlngvsfChipCntOKRowL).Height = CMlngvsfChipCntRowHeight        '行の高さ設定
                    vsfChipCnt.Rows(CMlngvsfChipCntOKRowR).Height = CMlngvsfChipCntRowHeight
                    vsfChipCnt.Rows(CMlngvsfChipCntNGRowL).Height = CMlngvsfChipCntRowHeight
                    vsfChipCnt.Rows(CMlngvsfChipCntNGRowR).Height = CMlngvsfChipCntRowHeight
                    vsfChipCnt.Rows(CMlngvsfChipCntNowNGRowL).Height = CMlngvsfChipCntRowHeight
                    vsfChipCnt.Rows(CMlngvsfChipCntNowNGRowR).Height = CMlngvsfChipCntRowHeight
                    vsfChipCnt.SetData(CMlngvsfChipCntOKRowL, 0, CMstrItemNameOK_L)       '表示項目追加(良品-左)
                    vsfChipCnt.SetData(CMlngvsfChipCntOKRowR, 0, CMstrItemNameOK_R)       '表示項目追加(良品-右)
                    vsfChipCnt.SetData(CMlngvsfChipCntNGRowL, 0, CMstrItemNameNG_L)       '表示項目追加(不良-左)
                    vsfChipCnt.SetData(CMlngvsfChipCntNGRowR, 0, CMstrItemNameNG_R)       '表示項目追加(不良-右)
                    vsfChipCnt.SetData(CMlngvsfChipCntNowNGRowL, 0, CMstrItemNameNowNG_L) '表示項目追加(現不良-左)
                    vsfChipCnt.SetData(CMlngvsfChipCntNowNGRowR, 0, CMstrItemNameNowNG_R) '表示項目追加(現不良-右)
                    vsfChipCnt.Enabled = True
                    
                Else
                    '@-----------------------
                    '@ 画面を通常に変更
                    '@-----------------------
                    vsfChipCnt.Rows.Count = CMlngvsfChipCntRows         'vsfChipCnt行数変更
                    vsfChipCnt.Height = CMlngvsfChipCntHeight           'vsfChipCntｸﾞﾘｯﾄﾞの高さ設定
                    vsfChipCnt.Enabled = False
                    
                    vsfScpList.Top = CMlngvsfScpListTopN                'vsfScpListｸﾞﾘｯﾄﾞのTop設定
                    vsfScpList.Height = CMlngvsfScpListHeightN          'vsfScpListｸﾞﾘｯﾄﾞの高さ設定
                    
                End If
                
                '@起動SBが基板か
                If pstrSBID = CPstrSBID1A0 Then
                
                    '@払出数行は"-"で表示
                    vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, CPstrMinus)
                    vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, CPstrMinus)
                    vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, CPstrMinus)
                    vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, CPstrMinus)
                End If
            End With
            
            ptypLotScrapInfo.lngScrapInputBeforeChipCnt = 0

            '@ﾁｯﾌﾟ情報の良品数が数値か
            If IsNumeric(vsfChipCnt.GetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot)) = True Then
                
                '@前工程の良品数=不良入力前良品数＋良品数
                ptypLotScrapInfo.lngScrapInputBeforeChipCnt = _
                    ptypLotScrapInfo.lngScrapInputBeforeChipCnt + _
                    CDec(vsfChipCnt.GetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot))
            End If
            
            '@ﾁｯﾌﾟ情報の現不良数が数値か
            If IsNumeric(vsfChipCnt.GetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot)) = True Then
                
                '@前工程の不良数=不良入力前不良数＋現不良数
                ptypLotScrapInfo.lngScrapInputBeforeChipCnt = _
                    ptypLotScrapInfo.lngScrapInputBeforeChipCnt + _
                    CDec(vsfChipCnt.GetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot))
            End If
            
            '@ﾁｯﾌﾟ情報の現払出数が数値か
            If IsNumeric(vsfChipCnt.GetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot)) = True Then
                
                '@前工程の払出数=払出入力前払出数＋現払出数
                ptypLotScrapInfo.lngScrapInputBeforeChipCnt = _
                    ptypLotScrapInfo.lngScrapInputBeforeChipCnt + _
                    CDec(vsfChipCnt.GetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot))
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvFrmxxCM0080_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMasScpList_Set
    '機　能：不良/払出ｺｰﾄﾞ一覧設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/25 (Thu) 11:44:20 T.Kitagawa
    '更新日：2016/06/08 (Wed) 14:28:51 T.Oide
    '備　考：
    '　　　：2004/10/21 (Thu) 16:08:13 T.Kitagawa　 WAIST機対応
    '　　　：2006/05/18 (Thu) 20:36:08 N.Kojima     不良数Col追加。ﾃﾞﾌｫﾙﾄで"0"を入力しておく処理追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2006/06/06 (Tue) 17:19:24 N.Kojima     配列の定義処理を変更。(運用障害№0831)
    '　　　：2006/07/05 (Wed) 14:04:59 T.Kitagawa   不良ｺｰﾄﾞがｾﾞﾛ件の場合はｼｽﾃﾑｴﾗｰになる為、回避する。(ﾕｰｻﾞｰ要望№0203のついでに対応)
    '　　　：2008/04/28 (Mon) 15:32:34 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2009/03/31 (Tue) 14:37:53 N.Kojima     ﾁｯﾌﾟ払出対応に伴い処理追加/変更。(案件№03434)
    '　　　：2009/07/16 (Thu) 13:37:14 N.Kojima     送品待ちﾛｯﾄのﾁｯﾌﾟ状態確認時にｼｽﾃﾑｴﾗｰになる件を修正。(案件№03674)
    Private Sub prvMasScpList_Set()
        
        Dim llngCnt             As Integer      'ｶｳﾝﾀ1
        Dim llngCnt2            As Integer      'ｶｳﾝﾀ2
        Dim llngCnt3            As Integer      'ｶｳﾝﾀ3
        Dim lintCurRow          As Integer      'NSYS 選択行保持用

        Try
            lintCurRow = -1 'NSYS 初期化
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①不良/払出ｺｰﾄﾞ一覧の表示
            '@　　　※払出ｺｰﾄﾞは組立ｽﾀｯﾌ端末、起動ﾕｰｻﾞｰがSTAFFの場合のみ表示
            '@======================================================================================


            '@-----------------------
            '@ 不良/払出ｺｰﾄﾞ一覧の表示
            '@-----------------------
            With vsfScpList
                .Redraw = False
                lintCurRow = .Row ' NSYS 選択行保持
                .Clear(ClearFlags.Content, .Rows.Fixed, .Cols.Fixed, .Rows.Count -1, .Cols.Count -1) '初期化
                .Rows.Count = 1                                   '初期化
                'Title設定
                .SetData(.Rows.Fixed - 1, CMlngvsfScpListCode, "ｺｰﾄﾞ") 'ｺｰﾄﾞ
                .SetData(.Rows.Fixed - 1, CMlngvsfScpListName, "名称") '名称
                .SetData(.Rows.Fixed - 1, CMlngvsfScpListScrapNum, "数") '数

                '@不良/払出ｺｰﾄﾞの設定
                For llngCnt = 0 To mtypMasScpList.lngListCnt - 1
                    
                    '@下記条件の場合はｺｰﾄﾞを表示しない
                    '@　①起動SBが基板で、かつ払出ｺｰﾄﾞか
                    If pstrSBID = CPstrSBID1A0 And _
                        mtypMasScpList.typeMasItem(llngCnt).strItemID = CPstrForwardCode Then
                    
                        '@基板で、かつ払出ｺｰﾄﾞは表示しない
                    
                    Else
                        '@①基板でかつ払出ｺｰﾄﾞではない
                        '@②組立でかつ払出ｺｰﾄﾞ
                        '@③組立でかつ払出ｺｰﾄﾞではない
                        
                        '@下記条件の場合はｺｰﾄﾞを表示しない
                        '@起動SBが組立、かつ使用ﾕｰｻﾞｰが"STAFF"以外、かつ払出ｺｰﾄﾞ
                        If pstrSBID = CPstrSBID2A0 And _
                            pstrGroupID <> CPstrDeptIDStaff And _
                            mtypMasScpList.typeMasItem(llngCnt).strItemID = CPstrForwardCode Then
                        
                            '@組立で、かつ使用ﾕｰｻﾞｰが"STAFF"以外、かつ払出ｺｰﾄﾞは表示しない

                        Else
                            '@①基板でかつ払出ｺｰﾄﾞではない
                            '@②組立でかつ使用ﾕｰｻﾞｰが"STAFF"以外、かつ払出ｺｰﾄﾞ以外
                            '@③組立でかつ使用ﾕｰｻﾞｰが"STAFF"、かつ払出ｺｰﾄﾞ
                            
                            .Rows.Count = .Rows.Count + 1
                        End If
                    End If
                Next llngCnt
                
                '@不良/払出ｺｰﾄﾞﾃﾞｰﾀが1件以上あるか
                If .Rows.Count > 1 Then
                    '@1件以上ある場合
                
                    '@配列の再定義
                    If IsNothing(ptypLotScrapInfo.typWFScrapInfo) Then
                        ptypLotScrapInfo.typWFScrapInfo = New List(Of WFScrapInfo)()
                    End If
                    For llngCnt = ptypLotScrapInfo.typWFScrapInfo.Count To mlngWFCnt - 1
                        Dim tmp As WFScrapInfo = New WFScrapInfo()
                        ptypLotScrapInfo.typWFScrapInfo.Add(tmp)
                    Next llngCnt
                    
                    For llngCnt = 0 To CLng(mlngWFCnt) -1
                        Dim tmp1 As WFScrapInfo = ptypLotScrapInfo.typWFScrapInfo(llngCnt)
                        If IsNothing(tmp1.typNowScrapList) Then
                            tmp1.typNowScrapList = New List(Of NowScrapList)()
                        End If
                        For llngCnt2 = tmp1.typNowScrapList.Count To .Rows.Count - 2
                            Dim tmp2 As NowScrapList = New NowScrapList()
                            tmp1.typNowScrapList.Add(tmp2)
                        Next llngCnt2
                        ptypLotScrapInfo.typWFScrapInfo(llngCnt) = tmp1
                    Next llngCnt
                End If

                '@現不良数格納
                ptypLotScrapInfo.strLotOutQuantity = _
                    vsfChipCnt.GetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot)
                
                '@現払出数格納
                ptypLotScrapInfo.strLotForwardQuantity = _
                    vsfChipCnt.GetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot)
                    
                
                '@配列のｶｳﾝﾀを格納
                mlngWFAryCnt = mlngWFCnt                    'WF枚数
                
                '@不良/払出ｺｰﾄﾞ一覧に1件以上ﾃﾞｰﾀがあるか
                If .Rows.Count > 1 Then
                    
                    '@ﾃﾞｰﾀが1件以上ある場合
                    ptypLotScrapInfo.lngScrapCnt = CLng(.Rows.Count - 1)      '不良/払出ｺｰﾄﾞ数
                Else
                    '@ﾃﾞｰﾀがない場合
                    ptypLotScrapInfo.lngScrapCnt = 0
                End If
                
                '@不良/払出ﾃﾞｰﾀがあるか
                If ptypLotScrapInfo.lngScrapCnt > 0 Then
                    Dim tmp As WFScrapInfo
                    llngCnt2 = 0
                    '@WFｽﾛｯﾄﾏｯﾌﾟの下ｽﾛｯﾄ(№01)から検索
                    For llngCnt = vsfWFMap.Rows.Count - 1 To 1 Step -1
                        
                        '@WFｽﾛｯﾄﾏｯﾌﾟにWFIDが存在するか
                        If vsfWFMap.GetData(llngCnt, CMlngvsfWFMapID) <> vbNullString Then

                            '@WFIDをｾｯﾄ
                            tmp = ptypLotScrapInfo.typWFScrapInfo(llngCnt2)
                            tmp.strWFID = vsfWFMap.GetData(llngCnt, CMlngvsfWFMapID)
                            ptypLotScrapInfo.typWFScrapInfo(llngCnt2) = tmp
                            '@ｶｳﾝﾄUP
                            llngCnt2 = llngCnt2 + 1
                            
                        End If
                    Next llngCnt
                End If
                

                '@不良項目一覧の行ｶｳﾝﾀの初期化
                llngCnt3 = 1

                '@不良/払出ｺｰﾄﾞの設定
                For llngCnt = 0 To mtypMasScpList.lngListCnt - 1
                    
                    '@下記条件の場合はｺｰﾄﾞを表示しない
                    '@　①起動SBが基板で、かつ払出ｺｰﾄﾞか
                    If pstrSBID = CPstrSBID1A0 And _
                        mtypMasScpList.typeMasItem(llngCnt).strItemID = CPstrForwardCode Then
                    
                        '@基板で、かつ払出ｺｰﾄﾞは表示しない

                    Else
                        '@①基板でかつ払出ｺｰﾄﾞではない
                        '@②組立でかつ払出ｺｰﾄﾞ
                        '@③組立でかつ払出ｺｰﾄﾞではない
                        
                        '@下記条件の場合はｺｰﾄﾞを表示しない
                        '@起動SBが組立、かつ使用ﾕｰｻﾞｰが"STAFF"以外、かつ払出ｺｰﾄﾞ
                        If pstrSBID = CPstrSBID2A0 And _
                            pstrGroupID <> CPstrDeptIDStaff And _
                            mtypMasScpList.typeMasItem(llngCnt).strItemID = CPstrForwardCode Then
                        
                            '@組立で、かつ使用ﾕｰｻﾞｰが"STAFF"以外、かつ払出ｺｰﾄﾞは表示しない
                            
                        Else
                            '@以下の条件の場合は表示する
                        
                            '@①基板でかつ払出ｺｰﾄﾞではない
                            '@②組立でかつ使用ﾕｰｻﾞｰが"STAFF"以外、かつ払出ｺｰﾄﾞ以外
                            '@③組立でかつ使用ﾕｰｻﾞｰが"STAFF"、かつ払出ｺｰﾄﾞ
                            
                            .SetData(llngCnt3, CMlngvsfScpListCode, mtypMasScpList.typeMasItem(llngCnt).strItemID)     '不良/払出ID
                            .SetData(llngCnt3, CMlngvsfScpListName, mtypMasScpList.typeMasItem(llngCnt).strItemName)   '不良/払出名
                            .SetData(llngCnt3, CMlngvsfScpListScrapNum, CPstrZero)                                     '数
                            
                            Dim tmp3 As NowScrapList
                            '@WFIDが同じ配列に不良項目を格納
                            For llngCnt2 = 0 To mlngWFAryCnt - 1
                                
                                tmp3 = ptypLotScrapInfo.typWFScrapInfo(llngCnt2).typNowScrapList(llngCnt3-1)
                                '@不良/払出情報格納
                                tmp3.strScrapCode = mtypMasScpList.typeMasItem(llngCnt).strItemID   '不良/払出ｺｰﾄﾞ
                                
                                tmp3.strScrapName = mtypMasScpList.typeMasItem(llngCnt).strItemName '不良/払出ｺｰﾄﾞ(和名)
                                
                                tmp3.strScrapNum = CPstrZero                                        '数
                                ptypLotScrapInfo.typWFScrapInfo(llngCnt2).typNowScrapList(llngCnt3-1) = tmp3
                            Next llngCnt2
                        
                            .Rows(llngCnt3).Height = CMlngvsfScpListHeight
                            
                            '@不良項目一覧の行ｶｳﾝﾀを+1する
                            llngCnt3 = llngCnt3 + 1
                        End If
                    End If
                Next llngCnt


                '@不良/払出ﾃﾞｰﾀがあるか
                If ptypLotScrapInfo.lngScrapCnt > 0 Then
                    
                    '@列幅自動調節
                    .AutoSizeCols(CMlngvsfScpListCode, .Cols.Count - 1, 6)
                End If
                
                '@行列のﾏｳｽでの変更を不可設定にする
                .AllowResizing = AllowResizingEnum.None
                
                '@構造体のｺﾋﾟｰ(子画面引継ぎ用)
                'ptypMasItemList = mtypMasScpList
                ptypMasItemList.strLotEventId = mtypMasScpList.strLotEventId
                ptypMasItemList.lngListCnt = mtypMasScpList.lngListCnt
                If Not IsNothing(ptypMasItemList.typeMasItem) Then
                    ptypMasItemList.typeMasItem.Clear()
                    ptypMasItemList.typeMasItem = Nothing
                End If
                If Not IsNothing(mtypMasScpList.typeMasItem) Then
                    ptypMasItemList.typeMasItem = New List(Of MasItem)(mtypMasScpList.typeMasItem)
                End If
                
                'NSYS 選択行の設定
                If lintCurRow > .Rows.Count - 1 Then
                    .Row = .Rows.Count - 1
                Else If lintCurRow >= .Rows.Fixed Then
                    .Row = lintCurRow
                Else
                    .Row = 0
                End If

                .Redraw = True
                '@不良/払出ｺｰﾄﾞ一覧ﾃﾞｰﾀが1件以上存在するか
                If mtypMasScpList.lngListCnt > 0 Then
                    
                    '@不良ｺｰﾄﾞｸﾞﾘｯﾄﾞを有効にする
                    .Enabled = True
                Else
                    '@不良ｺｰﾄﾞｸﾞﾘｯﾄﾞを無効にする
                    .Enabled = False
                End If
            End With
            
            '@パ検行程の場合、Mapを初期表示したくないので1行目を選択
            '@↓2020/03/19 (Thu) 19:11:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
            If Mid$(ptypLotprestate.strWpID, 1, 7) = CPstrPakenWpId Then
            '@↑2020/03/19 (Thu) 19:11:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                vsfWFMap.Row = 1
                Call pubSetFocus(txtDmCode) 'ｽｷｬﾅ入力へﾌｫｰｶｽｾｯﾄ
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvMasScpList_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvLotWaferInfo_Set
    '機　能：WFｽﾛｯﾄﾏｯﾌﾟの設定処理
    '引　数：ltypWaferInfo  ：ﾛｯﾄWF情報構造体
    '戻り値：なし
    '作成日：2004/03/26 (Fri) 16:09:45 T.Kitagawa
    '更新日：2008/04/28 (Mon) 16:30:10 N.Kojima
    '備　考：
    '　　　：2004/11/25 (Thu) 11:56:28 S.Deguchi    不良保留払出の各ｸﾗｽの色設定を追加
    '　　　：2005/06/01 (Wed) 15:26:23 S.Deguchi    不具合№845の対応で,移載先ｽﾛｯﾄ№を追加
    '　　　：2006/09/25 (Mon) 16:16:07 T.Kitagawa   欠損ﾁｯﾌﾟ対応(案件№01084)
    '　　　：2008/04/28 (Mon) 16:30:10 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvLotWaferInfo_Set(ByRef ltypWaferList As Waferlist)
        
        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ1
        Dim llngCnt2                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ2
        Dim llngCnt3                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ3

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①ﾛｯﾄWF情報構造体から、WF情報構造体へのﾃﾞｰﾀｺﾋﾟｰ
            '@　　②WFｽﾛｯﾄﾏｯﾌﾟの表示、背景色設定
            '@======================================================================================
            
            
            '@ﾁｯﾌﾟ構造体の初期設定
            Erase mtypWFInfo
            ReDim mtypWFInfo(CMlngvsfWFMapMaxSlotID-1)
            
            For llngCnt = 0 To CMlngvsfWFMapMaxSlotID - 1
                
                With mtypWFInfo(llngCnt)
                    
                    '@WF情報の初期化
                    .strWfId = vbNullString                 'WFID
                    .strSlotPosition = vbNullString         'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                    .strClass = vbNullString                'ｸﾗｽ
                    .strClassID = vbNullString              'ｸﾗｽID
                    .strInputCheckKbn = vbNullString        '入力ﾁｪｯｸ区分(NULL:ﾁｯﾌﾟ情報が未読込み、1:未入力、2:入力済)
                    .strResult = vbNullString               '結果
                    
                    '@ﾁｯﾌﾟ情報の初期化
                    ReDim .typChipList(mlngChipGridMaxRows-1, mlngChipGridMaxCols-1)
                    
                    For llngCnt2 = 0 To mlngChipGridMaxRows - 1
                        
                        For llngCnt3 = 0 To mlngChipGridMaxCols - 1
                            
                            '@有効/無効(使用可能/不可)区分の設定
                            .typChipList(llngCnt2, llngCnt3).blnEnableKbn = mblnChipGridMap(llngCnt2, llngCnt3)
                            
                            '@欠損ﾁｯﾌﾟ区分の設定(欠損無しを初期値)
                            .typChipList(llngCnt2, llngCnt3).blnLostChipKbn = False
                            
                            '@ﾁｯﾌﾟIDの設定
                            .typChipList(llngCnt2, llngCnt3).strChipId = vbNullString
                            
                            '@入力前後の設定
                            .typChipList(llngCnt2, llngCnt3).strOldClass = vbNullString             '現工程変更前区分(1:良品、2:不良、3:払出、4:保留、5:傾向)
                            .typChipList(llngCnt2, llngCnt3).strOldClassID = vbNullString           '現工程変更前区分ID
                            .typChipList(llngCnt2, llngCnt3).strNewClass = vbNullString             '現工程変更後区分(1:良品、2:不良、3:払出、4:保留、5:傾向)
                            .typChipList(llngCnt2, llngCnt3).strNewClassID = vbNullString           '現工程変更後区分ID
                            .typChipList(llngCnt2, llngCnt3).strOldNowstepEditFlag = vbNullString   '現工程変更前自工程更新ﾌﾗｸﾞ(0:自工程更新なし、1:自工程更新あり)
                            .typChipList(llngCnt2, llngCnt3).strNewNowstepEditFlag = vbNullString   '現工程変更後自工程更新ﾌﾗｸﾞ(0:自工程更新なし、1:自工程更新あり)
                            .typChipList(llngCnt2, llngCnt3).strBefoerClass = vbNullString          '前工程最新区分
                            .typChipList(llngCnt2, llngCnt3).strBefoerClassID = vbNullString        '前工程最新区分ID
                            
                        Next llngCnt3
                    Next llngCnt2
                End With
            Next llngCnt
            
            '@ﾛｯﾄWF構造体からﾁｯﾌﾟ構造体へ設定
            For llngCnt = 0 To ltypWaferList.lngListCnt - 1
                
                With ltypWaferList.typWfList(llngCnt)
                    
                    mtypWFInfo(Val(.strSlotPosition)-1).strWfId = .strWfId
                    mtypWFInfo(Val(.strSlotPosition)-1).strSlotPosition = .strSlotPosition
                    mtypWFInfo(Val(.strSlotPosition)-1).strClass = .strClass
                    mtypWFInfo(Val(.strSlotPosition)-1).strClassID = .strClassID
                    mtypWFInfo(Val(.strSlotPosition)-1).strResult = .strResult
                    mtypWFInfo(Val(.strSlotPosition)-1).strToSlotPosition = .strToCarrySlotPosition
                    mtypWFInfo(Val(.strSlotPosition)-1).strCfWfID = .strCfWfID
                End With
            Next llngCnt
            
            
            '@-----------------------
            '@ WFｽﾛｯﾄﾏｯﾌﾟの設定
            '@-----------------------
            With vsfWFMap
                
                '@全体の設定
                .Redraw = False                                           '描画ﾛｯｸ
                .Rows.Count = CMlngvsfWFMapMaxSlotID + 1                  '行設定
                .BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray) '背景色(濃いｸﾞﾚｰ)
                .ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)   '文字色(黒)
                .Row = -1                                                 '選択状態設定(ﾀｲﾄﾙ)
                .Col = -1                                                 '選択状態設定(ﾀｲﾄﾙ)
                .AllowEditing = False

                '無効Slot色
                Dim newStyle_BC_vbButtonFace As CellStyle = .Styles.Add("CustomStyle_BackColor_vbButtonFace")
                newStyle_BC_vbButtonFace.BackColor = SystemColors.ControlLight
                '良品(白)
                Dim newStyle_BC_EnableTrueColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor")
                newStyle_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                '不良(ﾋﾟﾝｸ)
                Dim newStyle_BC_FuryouColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngFuryouColor")
                newStyle_BC_FuryouColor.BackColor = ColorTranslator.FromWin32(CMlngFuryouColor)
                '払出(ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)
                Dim newStyle_BC_HaraidashiColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngHaraidashiColor")
                newStyle_BC_HaraidashiColor.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColor)
                '保留(薄灰色)
                Dim newStyle_BC_ReferOnlyColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngReferOnlyColor")
                newStyle_BC_ReferOnlyColor.BackColor = ColorTranslator.FromWin32(CMlngReferOnlyColor)
                '傾向(ﾚﾓﾝ色)
                Dim newStyle_BC_KeikouColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngKeikouColor")
                newStyle_BC_KeikouColor.BackColor = ColorTranslator.FromWin32(CMlngKeikouColor)
                Dim newStyle_BC_GridDarkGray As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                'その他(濃い灰色)
                newStyle_BC_GridDarkGray.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                Dim cellRange As CellRange
                '@ｽﾛｯﾄ№、WF_ID、傾向、不良の設定
                For llngCnt = 1 To CMlngvsfWFMapMaxSlotID
                    
                    '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                    If ltypWaferList.strSlotSize < CMlngvsfWFMapMaxSlotID - llngCnt + 1 Then
                        
                        '@ｽﾛｯﾄ№は空白
                        .SetData(llngCnt, CMlngvsfWFMapNo, vbNullString)
                        cellRange = .GetCellRange(llngCnt, CMlngvsfWFMapID)
                        cellRange.Style = newStyle_BC_vbButtonFace              'WFID
                        cellRange = .GetCellRange(llngCnt, CMlngvsfWFMapDestNo)
                        cellRange.Style = newStyle_BC_vbButtonFace              '移載先ｽﾛｯﾄ№
                        cellRange = .GetCellRange(llngCnt, CMlngvsfWFCfWfID)
                        cellRange.Style = newStyle_BC_vbButtonFace              'CF_WFID

                    Else
                        '@ｽﾛｯﾄ№の設定
                        .SetData(llngCnt, CMlngvsfWFMapNo, _
                            Format$(CMlngvsfWFMapMaxSlotID - llngCnt + 1, CPstrSlotNoFormat))
                        
                        '@WFIDの設定
                        .SetData(llngCnt, CMlngvsfWFMapID, _
                            mtypWFInfo(CMlngvsfWFMapMaxSlotID - llngCnt).strWfId)
                        
                        '@移載先ｽﾛｯﾄ№の設定
                        If IsNumeric(mtypWFInfo(CMlngvsfWFMapMaxSlotID - llngCnt).strToSlotPosition) Then
                            .SetData(llngCnt, CMlngvsfWFMapDestNo, _
                                Format$(CInt(mtypWFInfo(CMlngvsfWFMapMaxSlotID - llngCnt).strToSlotPosition), CPstrSlotNoFormat))
                        Else
                            .SetData(llngCnt, CMlngvsfWFMapDestNo, _
                                mtypWFInfo(CMlngvsfWFMapMaxSlotID - llngCnt).strToSlotPosition)
                        End If
                        
                        '@CF_WFIDの設定
                        .SetData(llngCnt, CMlngvsfWFCfWfID, _
                            mtypWFInfo(CMlngvsfWFMapMaxSlotID - llngCnt).strCfWfID)
                        
                        cellRange = .GetCellRange(llngCnt, CMlngvsfWFMapID, llngCnt, .Cols.Count - 1)
                        '@★ ｸﾗｽにより処理分岐 ★
                        Select Case mtypWFInfo(CMlngvsfWFMapMaxSlotID - llngCnt).strClass
                            
                            '@〓 1：良品(白) 〓
                            Case CPstrClass1
                                
                                cellRange.Style.BackColor = newStyle_BC_EnableTrueColor.BackColor
                            
                            '@〓 2：不良(ﾋﾟﾝｸ) 〓
                            Case CPstrClass2
                                
                                cellRange.Style.BackColor = newStyle_BC_FuryouColor.BackColor
                            
                            '@〓 3：払出(ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ) 〓
                            Case CPstrClass3

                                cellRange.Style.BackColor = newStyle_BC_HaraidashiColor.BackColor
                            
                            '@〓 4：保留(薄灰色) 〓
                            Case CPstrClass4
                                
                                cellRange.Style.BackColor = newStyle_BC_ReferOnlyColor.BackColor
                            
                            '@〓 5：傾向(ﾚﾓﾝ色) 〓
                            Case CPstrClass5
                                
                                cellRange.Style.BackColor = newStyle_BC_KeikouColor.BackColor
                            
                            '@〓 その他(濃い灰色) 〓
                            Case Else
                                
                                cellRange.Style.BackColor = newStyle_BC_GridDarkGray.BackColor
                        
                        End Select
                    End If
                Next llngCnt

                '@ｽﾛｯﾄ№の位置設定(右寄中央揃え)
                .Cols(CMlngvsfWFMapNo).TextAlign = TextAlignEnum.RightCenter
                '@WFIDの位置設定(左寄中央揃え)
                .Cols(CMlngvsfWFMapID).TextAlign = TextAlignEnum.LeftCenter
                '@移載先ｽﾛｯﾄ№の位置設定(右寄中央揃え)
                .Cols(CMlngvsfWFMapDestNo).TextAlign = TextAlignEnum.RightCenter
                '@WF_IDの位置設定(左寄中央揃え)
                .Cols(CMlngvsfWFCfWfID).TextAlign = TextAlignEnum.LeftCenter
                
                '@再描画
                .Redraw = True

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvLotWaferInfo_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvChipGridInfo_Set
    '機　能：ﾁｯﾌﾟﾏｯﾌﾟの設定処理
    '引　数：ltypMasPdMap：ｽﾛｯﾄﾏｯﾌﾟ構造体
    '戻り値：なし
    '作成日：2004/03/25 (Thu) 11:46:31 T.Kitagawa
    '更新日：2008/04/28 (Mon) 15:43:57 N.Kojima
    '備　考：
    '　　　：2004/10/25 (Mon) 14:49:56 T.Kitagawa   ﾁｯﾌﾟGridの行№を"00"ﾌｫｰﾏｯﾄする
    '　　　：2006/03/16 (Thu) 10:39:04 N.Kasai      ﾁｯﾌﾟ表示幅に余白を追加する。(ｴﾗｰｺｰﾄﾞ5桁、ﾁｯﾌﾟ数量296をMAX表示)
    '　　　：2006/09/25 (Mon) 13:51:13 T.Kitagawa   ODF欠損ﾁｯﾌﾟ対応(案件№01084)
    '　　　：2008/04/28 (Mon) 15:43:57 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvChipGridInfo_Set(ByRef ltypMasPdMap As MasPdMapList)
        
        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngChipCount           As Integer      'ﾁｯﾌﾟ数

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①ﾁｯﾌﾟﾏｯﾌﾟの表示
            '@　　②全体表示/拡大表示ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝ(ﾎﾞﾀﾝ名)設定、処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝの初期値設定
            '@======================================================================================


            '@ﾁｯﾌﾟﾏｯﾌﾟの最大行/列数の初期化
            mlngChipGridMaxRows = 0
            mlngChipGridMaxCols = 0
            
            '@ﾁｯﾌﾟﾏｯﾌﾟ構造体の設定
            Erase mblnChipGridMap
            
            '@最大行数の設定
            mlngChipGridMaxRows = ltypMasPdMap.lngListCnt
            
            '@最大列数の設定
            For llngCnt = 0 To ltypMasPdMap.lngListCnt - 1
            
                With ltypMasPdMap.typRowNumList(llngCnt)
                    
                    '@ﾁｯﾌﾟ数、先頭列番号が数値か
                    If IsNumeric(.strChipCount) = True And IsNumeric(.strStartColumn) = True Then
                        
                        '@開始番号とﾁｯﾌﾟ数(横表示用)を足す
                        llngChipCount = Val(.strStartColumn) + Val(.strChipCount) - 1
                        
                        '@ﾁｯﾌﾟ数(横表示用)が最大列数より大きいか
                        If llngChipCount > mlngChipGridMaxCols Then
                            
                            '@最大列数にﾁｯﾌﾟ数(横表示用)を格納
                            mlngChipGridMaxCols = llngChipCount
                        End If
                    End If
                End With
            Next llngCnt
            
            '@最大列数、または最大行数が0か
            If mlngChipGridMaxRows = 0 Or mlngChipGridMaxCols = 0 Then
                '@どちらかが0の場合は処理終了
                Exit Sub
            End If
            
            '@配列の再定義(最大行数、最大列数分の2次元配列)
            ReDim mblnChipGridMap(mlngChipGridMaxRows-1, mlngChipGridMaxCols-1)
            
            '@最大行数が標準行数より大きいか
            If mlngChipGridMaxRows > CMlngvsfChipMapNomalMaxRows Then
                
                '@高さｵｰﾊﾞｰﾌﾗｸﾞに"True:ｵｰﾊﾞｰ"をｾｯﾄ
                mlblnRowHeigthOver = True
            Else
                '@高さｵｰﾊﾞｰﾌﾗｸﾞに"False:19行以内"をｾｯﾄ
                mlblnRowHeigthOver = False
            End If
            
            '@最大列数が標準列数より大きいか
            If mlngChipGridMaxCols > CMlngvsfChipMapNomalMaxCols Then
                
                '@幅ｵｰﾊﾞｰﾌﾗｸﾞに"True:ｵｰﾊﾞｰ"をｾｯﾄ
                mlblnColWidthOver = True
            Else
                '@幅ｵｰﾊﾞｰﾌﾗｸﾞに"False:13行以内"をｾｯﾄ
                mlblnColWidthOver = False
            End If
            

            For llngCnt = 0 To mlngChipGridMaxRows - 1
                
                With ltypMasPdMap.typRowNumList(llngCnt)
                    
                    '@取得情報の行番号とﾙｰﾌﾟｶｳﾝﾀが同じか
                    'If llngCnt = .strRowNum Then
                    If IsNumeric(.strRowNum) AndAlso llngCnt+1 = CInt(.strRowNum) Then

                        For llngCnt2 = 0 To Val(.strStartColumn) - 2
                            
                            '@無効(背景ｸﾞﾚｰ)を設定
                            mblnChipGridMap(llngCnt, llngCnt2) = False
                        Next llngCnt2
                        
                        For llngCnt2 = Val(.strStartColumn) - 1 To Val(.strStartColumn) + Val(.strChipCount) - 2
                            
                            '@有効(背景白)を設定
                            mblnChipGridMap(llngCnt, llngCnt2) = True
                        Next llngCnt2
                        
                        For llngCnt2 = Val(.strStartColumn) + Val(.strChipCount)  To mlngChipGridMaxCols - 1
                            
                            '@無効(背景ｸﾞﾚｰ)を設定
                            mblnChipGridMap(llngCnt, llngCnt2) = False
                        Next llngCnt2

                    Else
                        '@取得情報の行番号とﾙｰﾌﾟｶｳﾝﾀが異なる場合
                    
                        For llngCnt2 = 0 To mlngChipGridMaxCols - 1
                            
                            '@無効(背景ｸﾞﾚｰ)を設定
                            mblnChipGridMap(llngCnt, llngCnt2) = False
                        Next llngCnt2
                    End If
                End With
            Next llngCnt
            
            
            '@-----------------------
            '@ ﾁｯﾌﾟﾏｯﾌﾟのｶﾗｰ、有効/無効定義
            '@-----------------------
            With vsfChipMap
                .Redraw = False
                '@全体の設定
                .Rows.Count = mlngChipGridMaxRows + 1
                .Cols.Count = mlngChipGridMaxCols + 1
                .BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                .ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                .Row = -1
                .Col = -1
                .AllowEditing = False
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_flexAlignRightCenter")
                Dim cellRange As CellRange = .GetCellRange(1, 1, mlngChipGridMaxRows, mlngChipGridMaxCols)
                newStyle.TextAlign = TextAlignEnum.RightCenter
                cellRange.Style = newStyle

                Dim newStyle_title As CellStyle = .Styles.Add("CustomStyle_title")
                Dim cellRange_title As CellRange = .GetCellRange(CMlngvsfChipMapNo, CMlngvsfChipMapNo, CMlngvsfChipMapNo, .Cols.Count - 1)
                newStyle_title.Font = New Font(newStyle_title.Font.FontFamily, CMvsfTitleFontSize, newStyle_title.Font.Style, newStyle_title.Font.Unit)
                newStyle_title.TextAlign = TextAlignEnum.CenterCenter

                '@ﾀｲﾄﾙの色設定
                newStyle_title.ForeColor = Color.Yellow
                newStyle_title.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))
                newStyle.Trimming = StringTrimming.None 'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange_title.Style = newStyle_title

                '@ﾀｲﾄﾙの高さ、幅の設定
                .Rows(CMlngvsfChipMapNo).Height = CMlngvsfChipMapTitleHeight
                .Cols(CMlngvsfChipMapNo).Width = CMlngvsfChipMapTitleWidth
                
                '@高さ、幅の最小値、最大値の初期設定
                .Rows.MaxSize = 0
                .Rows.MinSize = 0
                .Cols.MaxSize = 0
                .Cols.MinSize = 0
                
                '@行番号、書式、高さの設定
                mlngAllDisplayRowHeigth = 0
                mlngAllDisplayRowHeigth = (CMlngvsfChipMapNomalHeight - CMlngvsfChipMapTitleHeight) \ mlngChipGridMaxRows
                mlngAllDisplayRowHeigth = mlngAllDisplayRowHeigth
                For llngCnt = 1 To mlngChipGridMaxRows
                    .SetData(llngCnt, CMlngvsfChipMapNo, Format$(llngCnt, CPstrSlotNoFormat))
                    .Rows(llngCnt).Height = mlngAllDisplayRowHeigth
                Next llngCnt
                Dim newStyle_SlotNo As CellStyle = .Styles.Add("CustomStyle_SlotNo")
                newStyle_SlotNo.TextAlign = TextAlignEnum.RightCenter
                Dim cellRange_SlotNo As CellRange = .GetCellRange(1, CMlngvsfChipMapNo, mlngChipGridMaxRows, CMlngvsfChipMapNo)
                cellRange_SlotNo.Style = newStyle_SlotNo
                
                '@列№、書式、幅の設定
                mlngAllDisplayColWidth = 0
                mlngAllDisplayColWidth = (CMlngvsfChipMapNomalWidth - CMlngvsfChipMapTitleWidth) \ mlngChipGridMaxCols
                mlngAllDisplayColWidth = mlngAllDisplayColWidth
                For llngCnt2 = 1 To mlngChipGridMaxCols
                    .SetData(CMlngvsfChipMapNo, llngCnt2, Chr(CMlngKeyCodeA + llngCnt2 - 1))
                    .Cols(llngCnt2).Width = mlngAllDisplayColWidth
                Next llngCnt2
                
                '@ﾁｯﾌﾟﾏｯﾌﾟの高さ、幅の再調整
                If CMlngvsfChipMapTitleHeight + (mlngAllDisplayRowHeigth * mlngChipGridMaxRows) + 2 <= CMlngvsfChipMapNomalHeight Then
                    .Height = CMlngvsfChipMapTitleHeight + (mlngAllDisplayRowHeigth * mlngChipGridMaxRows) + 2
                Else 
                    .Height = CMlngvsfChipMapTitleHeight + (mlngAllDisplayRowHeigth * mlngChipGridMaxRows)
                End If
                
                '@余白+50追加
                .Width = CMlngvsfChipMapTitleWidth + (mlngAllDisplayColWidth * mlngChipGridMaxCols) + 3

                .Redraw = True
            End With
            
            '@ﾁｯﾌﾟﾏｯﾌﾟの欠損ﾁｯﾌﾟ情報の設定
            mstrChipGridLostChipId = ltypMasPdMap.strLostChipNo
            
            '@表/裏ﾎﾞﾀﾝの初期設定(裏)
            cmdHyouri.Text = CMstrCmdHyouriKbn2

            '@全体表示/拡大表示ﾎﾞﾀﾝの初期設定(拡大表示)
            cmdDisplayKbn.Text = CMstrCmdDisplayKbn2
            
            '@処理ﾎﾞﾀﾝ(ﾁｯﾌﾟ登録を初期値)
            optProcessKbn1.Checked = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvChipGridInfo_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWFMapInfo_Set
    '機　能：WF情報の設定処理
    '引　数：ltypWFMapInfo  ：WFﾏｯﾌﾟ構造体
    '戻り値：なし
    '作成日：2004/03/26 (Fri) 18:42:59 T.Kitagawa
    '更新日：2010/06/10 (Thu) 18:15:14 T.Oide
    '備　考：
    '　　　：2004/09/14 (Tue) 13:19:15 Y.Yamagishi　電特/外観/パ検結果登録対応
    '　　　：2004/10/21 (Thu) 19:10:19 T.Kitagawa　 WAIST機対応
    '　　　：2004/12/03 (Fri) 14:05:27 S.Deguchi    WF単位のﾁｯﾌﾟ数をｾｯﾄする処理を追加
    '　　　：2005/01/14 (Fri) 15:52:15 H.Wajima     自工程更新ﾌﾗｸﾞ追加
    '　　　：2005/08/09 (Tue) 14:08:08 N.Kasai      自工程変更前区分&ID追加
    '　　　：2005/12/21 (Wed) 13:52:55 N.Kojima     CF(大判)ﾛｯﾄの場合は、ﾁｯﾌﾟ表示を逆にする処理追加。(ﾕｰｻﾞｰ要望№0128)
    '　　　：2006/07/06 (Thu) 16:35:25 T.Kitagawa   1WF不良の場合は全Chip不良設定する。(不具合№3544)
    '　　　：2006/09/25 (Mon) 16:02:42 T.Kitagawa   欠損ﾁｯﾌﾟは設定不可とする(案件№01084)
    '　　　：2008/04/28 (Mon) 16:39:12 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2009/03/31 (Tue) 14:37:53 N.Kojima     ﾁｯﾌﾟ払出対応に伴い処理追加/変更。(案件№03434)
    '　　　：2010/06/10 (Thu) 16:36:08 T.Oide       案件№04059 左右別不良数表示機能追加
    Private Sub prvWFMapInfo_Set(ByRef ltypWFMapInfo As WFMapInfo)
        
        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt3                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lblnChipSetFlg          As Boolean      'ﾁｯﾌﾟ情報設定ﾌﾗｸﾞ(True:設定済、False:未設定)
        Dim llngLoopStartCnt        As Integer      'ﾙｰﾌﾟ開始ｶｳﾝﾀ
        Dim llngLoopEndCnt          As Integer      'ﾙｰﾌﾟ終了ｶｳﾝﾀ
        Dim llngLoopStep            As Integer      'ﾙｰﾌﾟ加算/減算用変数

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①ﾁｯﾌﾟ情報一覧の設定、WF情報構造体へ良品数・不良(払出)数・現不良(現払出)数の設定
            '@　　②WF情報構造体へﾁｯﾌﾟ詳細情報(区分、更新ﾌﾗｸﾞetc...)の設定
            '@======================================================================================


            '@入力ﾁｪｯｸ区分が"NULL:ﾁｯﾌﾟ情報が未入力"以外、またはWFIDがNULLか
            If mtypWFInfo(mlngWFNowIndex-1).strInputCheckKbn <> vbNullString Or _
                mtypWFInfo(mlngWFNowIndex-1).strWfId = vbNullString Then
                
                Exit Sub
            End If
            
            '@***********************
            '@ ﾁｯﾌﾟ情報一覧の設定、WF情報構造体の設定
            '@***********************
            
            '@-----------------------
            '@ 良品数
            '@-----------------------
            '@良品数がNULL以外か
            If ltypWFMapInfo.strChipQuantity <> vbNullString Then
                
                '@WF単位の良品ﾁｯﾌﾟ数
                vsfChipCnt.SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF, Format(CInt(ltypWFMapInfo.strChipQuantity), CPstrDateFormatKanma))
                mtypWFInfo(mlngWFNowIndex-1).strWFChipQuantity = ltypWFMapInfo.strChipQuantity
            Else
                '@良品数がNULLの場合
            
                '@WF単位の良品ﾁｯﾌﾟ数(=NULL)
                vsfChipCnt.SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF, vbNullString)
                mtypWFInfo(mlngWFNowIndex-1).strWFChipQuantity = vbNullString
            End If
            
            '@-----------------------
            '@ 総不良数
            '@-----------------------
            '@総不良数がNULL以外か
            If ltypWFMapInfo.strChipOutQuantity <> vbNullString Then
                
                '@WF単位の総不良ﾁｯﾌﾟ数
                vsfChipCnt.SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntWF, Format(CInt(ltypWFMapInfo.strChipOutQuantity), CPstrDateFormatKanma))
                mtypWFInfo(mlngWFNowIndex-1).strWFChipOutQuantity = ltypWFMapInfo.strChipOutQuantity
            Else
                '@総不良数がNULLの場合
                
                '@WF単位の総不良ﾁｯﾌﾟ数(=NULL)
                vsfChipCnt.SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntWF, vbNullString)
                mtypWFInfo(mlngWFNowIndex-1).strWFChipOutQuantity = vbNullString
            End If
            
            '@-----------------------
            '@ 現不良数
            '@-----------------------
            '@現不良数がNULL以外か
            If ltypWFMapInfo.strChipCurrentOutQuantity <> vbNullString Then
            
                '@WF単位の現不良ﾁｯﾌﾟ数
                vsfChipCnt.SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntWF, Format(CInt(ltypWFMapInfo.strChipCurrentOutQuantity), CPstrDateFormatKanma))
                mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentOutQuantity = ltypWFMapInfo.strChipCurrentOutQuantity
            Else
                '@現不良数がNULLの場合
                
                '@WF単位の現不良ﾁｯﾌﾟ数(=NULL)
                vsfChipCnt.SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntWF, vbNullString)
                mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentOutQuantity = vbNullString
            End If
            
            '@-----------------------
            '@ 総払出数
            '@-----------------------
            '@総払出数がNULL以外か
            If ltypWFMapInfo.strChipForwardQuantity <> vbNullString Then
            
                '@WF単位の総払出ﾁｯﾌﾟ数
                vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, Format(CInt(ltypWFMapInfo.strChipForwardQuantity), CPstrDateFormatKanma))
                mtypWFInfo(mlngWFNowIndex-1).strWFChipForwardQuantity = ltypWFMapInfo.strChipForwardQuantity
            Else
                '@総払出数がNULLの場合
                
                '@WF単位の総払出ﾁｯﾌﾟ数(=NULL)
                vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, vbNullString)
                mtypWFInfo(mlngWFNowIndex-1).strWFChipForwardQuantity = vbNullString
            End If
            
            '@-----------------------
            '@ 現払出数
            '@-----------------------
            '@現払出数がNULL以外か
            If ltypWFMapInfo.strChipCurrentForwardQuantity <> vbNullString Then
            
                '@WF単位の現払出ﾁｯﾌﾟ数
                vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, Format(CInt(ltypWFMapInfo.strChipCurrentForwardQuantity), CPstrDateFormatKanma))
                mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentForwardQuantity = ltypWFMapInfo.strChipCurrentForwardQuantity
            Else
                '@現払出数がNULLの場合
                
                '@WF単位の現払出ﾁｯﾌﾟ数(=NULL)
                vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, vbNullString)
                mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentForwardQuantity = vbNullString
            End If


        '@↓2010/06/10 (Thu) 18:15:05 T.Oide **************************************************
            '@無機ﾛｯﾄか(ｸﾞﾘｯﾄﾞの行数で判断)
            If vsfChipCnt.Rows.Count = CMlngvsfChipCntRowsVA Then
            
                '@-----------------------
                '@ 良品ﾁｯﾌﾟ数LOT-左
                '@-----------------------
                '@良品ﾁｯﾌﾟ数LOT-左がNULL以外か
                If ltypWFMapInfo.strChipQuantityLotL <> vbNullString Then
                
                    '@LOT単位の良品ﾁｯﾌﾟ数-左
                    vsfChipCnt.SetData(CMlngvsfChipCntOKRowL, CMlngvsfChipCntLot, Format(CInt(ltypWFMapInfo.strChipQuantityLotL), CPstrDateFormatKanma))
                    mtypWFInfo(mlngWFNowIndex-1).strChipQuantityLotL = ltypWFMapInfo.strChipQuantityLotL
                Else
                    '@LOT単位の良品ﾁｯﾌﾟ数がNULLの場合
                    
                    '@LOT単位の良品ﾁｯﾌﾟ数(=NULL)
                    vsfChipCnt.SetData(CMlngvsfChipCntOKRowL, CMlngvsfChipCntLot, vbNullString)
                    mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityLotL = vbNullString
                End If
            
                '@-----------------------
                '@ 良品ﾁｯﾌﾟ数LOT-右
                '@-----------------------
                '@良品ﾁｯﾌﾟ数LOT-右がNULL以外か
                If ltypWFMapInfo.strChipQuantityLotR <> vbNullString Then
                
                    '@LOT単位の良品ﾁｯﾌﾟ数-右
                    vsfChipCnt.SetData(CMlngvsfChipCntOKRowR, CMlngvsfChipCntLot, Format(CInt(ltypWFMapInfo.strChipQuantityLotR), CPstrDateFormatKanma))
                    mtypWFInfo(mlngWFNowIndex-1).strChipQuantityLotR = ltypWFMapInfo.strChipQuantityLotR
                Else
                    '@LOT単位の良品ﾁｯﾌﾟ数がNULLの場合
                    
                    '@LOT単位の良品ﾁｯﾌﾟ数(=NULL)
                    vsfChipCnt.SetData(CMlngvsfChipCntOKRowR, CMlngvsfChipCntLot, vbNullString)
                    mtypWFInfo(mlngWFNowIndex-1).strChipQuantityLotR = vbNullString
                End If
            
                '@-----------------------
                '@ 良品ﾁｯﾌﾟ数WF-左
                '@-----------------------
                '@良品ﾁｯﾌﾟ数WF-左がNULL以外か
                If ltypWFMapInfo.strChipQuantityWfL <> vbNullString Then
                
                    '@WF単位の良品ﾁｯﾌﾟ数-左
                    vsfChipCnt.SetData(CMlngvsfChipCntOKRowL, CMlngvsfChipCntWF, Format(CInt(ltypWFMapInfo.strChipQuantityWfL), CPstrDateFormatKanma))
                    mtypWFInfo(mlngWFNowIndex-1).strChipQuantityWfL = ltypWFMapInfo.strChipQuantityWfL
                Else
                    '@WF単位の良品ﾁｯﾌﾟ数がNULLの場合
                    
                    '@WF単位の良品ﾁｯﾌﾟ数(=NULL)
                    vsfChipCnt.SetData(CMlngvsfChipCntOKRowL, CMlngvsfChipCntWF, vbNullString)
                    mtypWFInfo(mlngWFNowIndex-1).strChipQuantityWfL = vbNullString
                End If

                '@-----------------------
                '@ 良品ﾁｯﾌﾟ数WF-右
                '@-----------------------
                '@良品ﾁｯﾌﾟ数WF-右がNULL以外か
                If ltypWFMapInfo.strChipQuantityWfR <> vbNullString Then
                
                    '@WF単位の良品ﾁｯﾌﾟ数-右
                    vsfChipCnt.SetData(CMlngvsfChipCntOKRowR, CMlngvsfChipCntWF, Format(CInt(ltypWFMapInfo.strChipQuantityWfR), CPstrDateFormatKanma))
                    mtypWFInfo(mlngWFNowIndex-1).strChipQuantityWfR = ltypWFMapInfo.strChipQuantityWfR
                Else
                    '@WF単位の良品ﾁｯﾌﾟ数がNULLの場合
                    
                        '@WF単位の良品ﾁｯﾌﾟ数(=NULL)
                    vsfChipCnt.SetData(CMlngvsfChipCntOKRowR, CMlngvsfChipCntWF, vbNullString)
                    mtypWFInfo(mlngWFNowIndex-1).strChipQuantityWfR = vbNullString
                End If
            
                '@-----------------------
                '@ 不良数LOT-左
                '@-----------------------
                '@不良数LOT-左がNULL以外か
                If ltypWFMapInfo.strChipOutQuantityLotL <> vbNullString Then
                
                    '@LOT単位の不良ﾁｯﾌﾟ数-左
                    vsfChipCnt.SetData(CMlngvsfChipCntNGRowL, CMlngvsfChipCntLot, Format(CInt(ltypWFMapInfo.strChipOutQuantityLotL), CPstrDateFormatKanma))
                    mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityLotL = ltypWFMapInfo.strChipOutQuantityLotL
                Else
                    '@現払出数がNULLの場合
                    
                    '@WF単位の現払出ﾁｯﾌﾟ数(=NULL)
                    vsfChipCnt.SetData(CMlngvsfChipCntNGRowL, CMlngvsfChipCntLot, vbNullString)
                    mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityLotL = vbNullString
                End If

                '@-----------------------
                '@ 不良数LOT-右
                '@-----------------------
                '@不良数LOT-右がNULL以外か
                If ltypWFMapInfo.strChipOutQuantityLotR <> vbNullString Then
                
                    '@LOT単位の不良ﾁｯﾌﾟ数-右
                    vsfChipCnt.SetData(CMlngvsfChipCntNGRowR, CMlngvsfChipCntLot, Format(CInt(ltypWFMapInfo.strChipOutQuantityLotR), CPstrDateFormatKanma))
                    mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityLotR = ltypWFMapInfo.strChipOutQuantityLotR
                Else
                    '@現払出数がNULLの場合
                    
                    '@WF単位の現払出ﾁｯﾌﾟ数(=NULL)
                    vsfChipCnt.SetData(CMlngvsfChipCntNGRowR, CMlngvsfChipCntLot, vbNullString)
                    mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityLotR = vbNullString
                End If

                '@-----------------------
                '@ 不良数WF-左
                '@-----------------------
                '@不良数WF-左がNULL以外か
                If ltypWFMapInfo.strChipOutQuantityWfL <> vbNullString Then
                
                    '@WF単位の不良ﾁｯﾌﾟ数-左
                    vsfChipCnt.SetData(CMlngvsfChipCntNGRowL, CMlngvsfChipCntWF, Format(CInt(ltypWFMapInfo.strChipOutQuantityWfL), CPstrDateFormatKanma))
                    mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityWfL = ltypWFMapInfo.strChipOutQuantityWfL
                Else
                    '@現払出数がNULLの場合
                    
                    '@WF単位の現払出ﾁｯﾌﾟ数(=NULL)
                    vsfChipCnt.SetData(CMlngvsfChipCntNGRowL, CMlngvsfChipCntWF, vbNullString)
                    mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityWfL = vbNullString
                End If

                '@-----------------------
                '@ 不良数WF-右
                '@-----------------------
                '@不良数WF-右がNULL以外か
                If ltypWFMapInfo.strChipOutQuantityWfR <> vbNullString Then
                
                    '@WF単位の不良ﾁｯﾌﾟ数-右
                    vsfChipCnt.SetData(CMlngvsfChipCntNGRowR, CMlngvsfChipCntWF, Format(CInt(ltypWFMapInfo.strChipOutQuantityWfR), CPstrDateFormatKanma))
                    mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityWfR = ltypWFMapInfo.strChipOutQuantityWfR
                Else
                    '@現払出数がNULLの場合
                    
                    '@WF単位の現払出ﾁｯﾌﾟ数(=NULL)
                    vsfChipCnt.SetData(CMlngvsfChipCntNGRowR, CMlngvsfChipCntWF, vbNullString)
                    mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityWfR = vbNullString
                End If



                '@-----------------------
                '@ 現工程不良数LOT-左
                '@-----------------------
                '@現工程不良数LOT-左がNULL以外か
                If ltypWFMapInfo.strChipCurrentOutQuantityLotL <> vbNullString Then
                
                    '@LOT単位の現工程不良ﾁｯﾌﾟ数-左
                    vsfChipCnt.SetData(CMlngvsfChipCntNowNGRowL, CMlngvsfChipCntLot, Format(CInt(ltypWFMapInfo.strChipCurrentOutQuantityLotL), CPstrDateFormatKanma))
                    mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityLotL = ltypWFMapInfo.strChipCurrentOutQuantityLotL
                Else
                    '@現払出数がNULLの場合
                    
                    '@WF単位の現払出ﾁｯﾌﾟ数(=NULL)
                    vsfChipCnt.SetData(CMlngvsfChipCntNowNGRowL, CMlngvsfChipCntLot, vbNullString)
                    mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityLotL = vbNullString
                End If

                '@-----------------------
                '@ 現工程不良数LOT-右
                '@-----------------------
                '@現工程不良数LOT-右がNULL以外か
                If ltypWFMapInfo.strChipCurrentOutQuantityLotR <> vbNullString Then
                
                    '@LOT単位の現工程不良ﾁｯﾌﾟ数-右
                    vsfChipCnt.SetData(CMlngvsfChipCntNowNGRowR, CMlngvsfChipCntLot, Format(CInt(ltypWFMapInfo.strChipCurrentOutQuantityLotR), CPstrDateFormatKanma))
                    mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityLotR = ltypWFMapInfo.strChipCurrentOutQuantityLotR
                Else
                    '@現払出数がNULLの場合
                    
                    '@WF単位の現払出ﾁｯﾌﾟ数(=NULL)
                    vsfChipCnt.SetData(CMlngvsfChipCntNowNGRowR, CMlngvsfChipCntLot, vbNullString)
                    mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityLotR = vbNullString
                End If

                '@-----------------------
                '@ 現工程不良数WF-左
                '@-----------------------
                '@現工程不良数WF-左がNULL以外か
                If ltypWFMapInfo.strChipCurrentOutQuantityWfL <> vbNullString Then
                
                    '@LOT単位の現工程不良ﾁｯﾌﾟ数-左
                    vsfChipCnt.SetData(CMlngvsfChipCntNowNGRowL, CMlngvsfChipCntWF, Format(CInt(ltypWFMapInfo.strChipCurrentOutQuantityWfL), CPstrDateFormatKanma))
                    mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityWfL = ltypWFMapInfo.strChipCurrentOutQuantityWfL
                Else
                    '@現払出数がNULLの場合
                    
                    '@WF単位の現払出ﾁｯﾌﾟ数(=NULL)
                    vsfChipCnt.SetData(CMlngvsfChipCntNowNGRowL, CMlngvsfChipCntWF, vbNullString)
                    mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityWfL = vbNullString
                End If

                '@-----------------------
                '@ 現工程不良数WF-右
                '@-----------------------
                '@現工程不良数WF-右がNULL以外か
                If ltypWFMapInfo.strChipCurrentOutQuantityWfR <> vbNullString Then
                
                    '@LOT単位の現工程不良ﾁｯﾌﾟ数-左
                    vsfChipCnt.SetData(CMlngvsfChipCntNowNGRowR, CMlngvsfChipCntWF, Format(CInt(ltypWFMapInfo.strChipCurrentOutQuantityWfR), CPstrDateFormatKanma))
                    mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityWfR = ltypWFMapInfo.strChipCurrentOutQuantityWfR
                Else
                    '@現払出数がNULLの場合
                    
                    '@WF単位の現払出ﾁｯﾌﾟ数(=NULL)
                    vsfChipCnt.SetData(CMlngvsfChipCntNowNGRowR, CMlngvsfChipCntWF, vbNullString)
                    mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityWfR = vbNullString
                End If
                
            End If
        '@↑2010/06/10 (Thu) 18:15:05 T.Oide **************************************************


            '@起動SBが基板か
            If pstrSBID = CPstrSBID1A0 Then
            
                '@払出数行は"-"で表示
                vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, CPstrMinus)
                vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, CPstrMinus)
                vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, CPstrMinus)
                vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, CPstrMinus)
            End If


            '@-----------------------
            '@ WFﾏｯﾌﾟ情報構造体からWF情報構造体へ情報を設定
            '@-----------------------
            With ltypWFMapInfo
                
                '@LP_FLAG(大判ﾌﾗｸﾞ)が"1"、CF_FLAGが"1"か　※LP_FLAG=1 and CF_FLAG=1 ：ODFﾛｯﾄ
                If ptypLotprestate.strLpFlag = "1" And ptypLotprestate.strCfFlag = "1" Then
                    
                    '@-----------------------
                    '@ ODFﾛｯﾄの場合
                    '@-----------------------
                    llngLoopStartCnt = mlngChipGridMaxCols - 1
                    llngLoopEndCnt = 0
                    llngLoopStep = -1
                Else
                    '@-----------------------
                    '@ TFT基板ﾛｯﾄの場合(=ODFﾛｯﾄではない場合)
                    '@-----------------------
                    llngLoopStartCnt = 0
                    llngLoopStep = 1
                    llngLoopEndCnt = mlngChipGridMaxCols - 1
                End If
                    
                    
                For llngCnt = 0 To .lngListCnt - 1
                    
                    '@ﾁｯﾌﾟ情報設定ﾌﾗｸﾞの初期化
                    lblnChipSetFlg = False
                    
                    For llngCnt2 = 0 To mlngChipGridMaxRows - 1
                        
                        '@ﾁｯﾌﾟ情報設定ﾌﾗｸﾞが"True:設定済"か
                        If lblnChipSetFlg = True Then
                            Exit For
                        End If
                        
                        For llngCnt3 = llngLoopStartCnt To llngLoopEndCnt Step llngLoopStep
                            
                            '@-----------------------
                            '@ ﾁｯﾌﾟIDの設定済みﾁｪｯｸ
                            '@-----------------------
                            '@使用可能区分が"True:使用可能"で、かつﾁｯﾌﾟIDがNULLか
                            If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).blnEnableKbn = True And _
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strChipId = vbNullString Then
                                '@使用可能区分=True、ﾁｯﾌﾟID=NULLの場合
                                
                                '@ﾁｯﾌﾟID
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strChipId = _
                                    .typChipList(llngCnt).strChipId
                                
                                '@現工程変更前区分
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strOldClass = _
                                    .typChipList(llngCnt).strClass
                                    
                                '@現工程変更後区分
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strNewClass = _
                                    .typChipList(llngCnt).strClass
                                
                                '@現工程変更前区分ID
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strOldClassID = _
                                    .typChipList(llngCnt).strClassID
                                
                                '@現工程変更後区分ID
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strNewClassID = _
                                    .typChipList(llngCnt).strClassID
                                
                                '@電特ｺｰﾄﾞ
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strEleCode = _
                                    .typChipList(llngCnt).strElectricCode
                                
                                '@電特ｸﾞﾚｰﾄﾞ
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strEleGrade = _
                                    .typChipList(llngCnt).strElectricGrade
                                
                                '@WAIST状態
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strWaistStatus = _
                                    .typChipList(llngCnt).strWaistStatus
                                
                                '@WAISTｺｰﾄﾞ
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strWaistCode = _
                                    .typChipList(llngCnt).strWaistCode
                                
                                '@現工程変更前更新ﾌﾗｸﾞ
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strOldNowstepEditFlag = _
                                    .typChipList(llngCnt).strNowstepEditFlag
                                
                                '@現工程変更後更新ﾌﾗｸﾞ
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strNewNowstepEditFlag = _
                                    .typChipList(llngCnt).strNowstepEditFlag
                                
                                '@前工程最新区分
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strBefoerClass = _
                                    .typChipList(llngCnt).strBeforeClass
                                
                                '@前工程最新区分ID
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strBefoerClassID = _
                                    .typChipList(llngCnt).strBeforeClassID
                                
                                '@1WF毎不良の場合は、全Chip不良と置換える
                                If mtypWFInfo(mlngWFNowIndex-1).strClass = CPstrClass2 Then
                                    
                                    '@変更後のﾁｯﾌﾟ状態が不良以外の場合は置換える
                                    If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strOldClass <> CPstrClass2 Then
                                        
                                        '@区分の再ｾｯﾄ
                                        mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strOldClass = mtypWFInfo(mlngWFNowIndex-1).strClass
                                        mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strNewClass = mtypWFInfo(mlngWFNowIndex-1).strClass
                                        
                                        '@区分IDの再ｾｯﾄ
                                        mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strOldClassID = mtypWFInfo(mlngWFNowIndex-1).strClassID
                                        mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strNewClassID = mtypWFInfo(mlngWFNowIndex-1).strClassID
                                        
                                        '@自工程更新ﾌﾗｸﾞの再ｾｯﾄ
                                        mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strOldNowstepEditFlag = CMstrNowstepEditEnable
                                        mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strNewNowstepEditFlag = CMstrNowstepEditEnable
                                    End If
                                End If


                                '@1WF毎払出の場合は、全Chip払出と置換える
                                If mtypWFInfo(mlngWFNowIndex-1).strClass = CPstrClass3 Then
                                    
                                    '@変更後のﾁｯﾌﾟ状態が払出以外の場合は置換える
                                    If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strOldClass <> CPstrClass3 Then
                                        
                                        '@区分の再ｾｯﾄ
                                        mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strOldClass = mtypWFInfo(mlngWFNowIndex-1).strClass
                                        mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strNewClass = mtypWFInfo(mlngWFNowIndex-1).strClass
                                        
                                        '@区分IDの再ｾｯﾄ
                                        mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strOldClassID = mtypWFInfo(mlngWFNowIndex-1).strClassID
                                        mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strNewClassID = mtypWFInfo(mlngWFNowIndex-1).strClassID
                                        
                                        '@自工程更新ﾌﾗｸﾞの再ｾｯﾄ
                                        mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strOldNowstepEditFlag = CMstrNowstepEditEnable
                                        mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strNewNowstepEditFlag = CMstrNowstepEditEnable
                                    End If
                                End If

                                
                                '@欠損ﾁｯﾌﾟ情報がNULL以外か
                                If mstrChipGridLostChipId <> vbNullString Then
                                    
                                    '@対象ﾁｯﾌﾟの現工程変更前区分が"2:不良"か
                                    If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strOldClass = CPstrClass2 Then
                                        '@2:不良の場合
                                        
                                        '@既に不良設定しており、該当ﾁｯﾌﾟが欠損ﾁｯﾌﾟ対象の場合は、欠損ﾁｯﾌﾟなので、変更不可とする
                                        If InStr(mstrChipGridLostChipId, _
                                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strChipId, CMlngLostChipNoLength)) > 0 Then
                                            
                                            '@欠損ﾁｯﾌﾟ区分に"True:欠損ﾁｯﾌﾟ"を設定
                                            mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).blnLostChipKbn = True
                                        End If
                                    End If
                                End If
                                
                                '@ﾁｯﾌﾟ情報設定ﾌﾗｸﾞの設定済み
                                lblnChipSetFlg = True

                                Exit For
                            End If
                        Next llngCnt3
                    Next llngCnt2
                Next llngCnt
                
            End With
            
            '@入力ﾁｪｯｸ区分に"1:未読込み"を設定する
            mtypWFInfo(mlngWFNowIndex-1).strInputCheckKbn = CMstrstrInputCheckKbn1

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvWFMapInfo_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWFMapDenInfo_Set
    '機　能：電特ﾌｧｲﾙ読込時のﾁｯﾌﾟﾏｯﾌﾟ設定処理
    '引　数：ltypWFMapInfo  ：WFﾏｯﾌﾟ情報構造体
    '戻り値：なし
    '作成日：2004/09/24 (Fri) 20:32:11 Y.Yamagishi
    '更新日：2010/06/10 (Thu) 18:54:11 T.Oide
    '備　考：
    '　　　：2004/10/21 (Thu) 19:13:59 T.Kitagawa　 WAIST機対応
    '　　　：2005/04/04 (Mon) 16:37:13 S.Deguchi    不具合№322の対応で,自工程更新ﾌﾗｸﾞの処理を追加
    '　　　：2005/05/18 (Wed) 10:08:15 S.Deguchi    不具合№811の対応でWF毎のﾁｯﾌﾟ数量をｾｯﾄ
    '　　　：2005/08/17 (Wed) 13:17:16 N.Kasai      更新ﾌﾗｸﾞ変更の条件を追加(№2986)
    '　　　：2005/09/12 (Mon) 11:56:20 N.Kasai      現不良数追加
    '　　　：2008/04/28 (Mon) 17:37:28 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2010/06/10 (Thu) 16:36:08 T.Oide       案件№04059 左右別不良数表示機能追加
    Private Sub prvWFMapDenInfo_Set(ByRef ltypWFMapInfo As WFMapInfo)
        
        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt3                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lblnChipSetFlg          As Boolean      'ﾁｯﾌﾟ情報設定ﾌﾗｸﾞ(True:設定済、False:未設定)

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①WFﾏｯﾌﾟ情報取得からWF情報構造体へのﾃﾞｰﾀｾｯﾄ処理
            '@======================================================================================


            '@ﾙｰﾌﾟｶｳﾝﾀの初期化
            llngCnt = 0
            
            '@-----------------------
            '@ WFﾏｯﾌﾟ情報構造体からﾁｯﾌﾟ構造体へ設定
            '@-----------------------
            With ltypWFMapInfo
            
                Do While llngCnt < .lngListCnt
                    
                    '@ﾁｯﾌﾟ情報設定ﾌﾗｸﾞの初期化
                    lblnChipSetFlg = False
                    
                    '@ﾁｯﾌﾟ数量をｾｯﾄ
                    mtypWFInfo(mlngWFNowIndex-1).strWFChipQuantity = .strChipQuantity                             '良品数
                    mtypWFInfo(mlngWFNowIndex-1).strWFChipOutQuantity = .strChipOutQuantity                       '総不良数
                    mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentOutQuantity = .strChipCurrentOutQuantity         '現工程不良数
                    mtypWFInfo(mlngWFNowIndex-1).strWFChipForwardQuantity = .strChipForwardQuantity               '総払出数
                    mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentForwardQuantity = .strChipCurrentForwardQuantity '現工程払出数
                    mtypWFInfo(mlngWFNowIndex-1).strChipQuantityLotL = .strChipQuantityLotL                       '良品ﾁｯﾌﾟ数LOT-左
                    mtypWFInfo(mlngWFNowIndex-1).strChipQuantityLotR = .strChipQuantityLotR                       '良品ﾁｯﾌﾟ数LOT-右
                    mtypWFInfo(mlngWFNowIndex-1).strChipQuantityWfL = .strChipQuantityWfL                         '良品ﾁｯﾌﾟ数WF-左
                    mtypWFInfo(mlngWFNowIndex-1).strChipQuantityWfR = .strChipQuantityWfR                         '良品ﾁｯﾌﾟ数WF-右
                    mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityLotL = .strChipOutQuantityLotL                 '不良数LOT-左
                    mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityLotR = .strChipOutQuantityLotR                 '不良数LOT-右
                    mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityWfL = .strChipOutQuantityWfL                   '不良数WF-左
                    mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityWfR = .strChipOutQuantityWfR                   '不良数WF-右
                    mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityLotL = .strChipCurrentOutQuantityLotL   '現工程不良数LOT-左
                    mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityLotR = .strChipCurrentOutQuantityLotR   '現工程不良数LOT-右
                    mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityWfL = .strChipCurrentOutQuantityWfL     '現工程不良数WF-左
                    mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityWfR = .strChipCurrentOutQuantityWfR     '現工程不良数WF-左

                    For llngCnt2 = 0 To mlngChipGridMaxRows - 1 
                        
                        For llngCnt3 = 0 To mlngChipGridMaxCols - 1
                            
                            '@使用可能区分が"True:使用可能"で、かつﾁｯﾌﾟIDがNULL以外か
                            If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).blnEnableKbn = True And _
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strChipId <> vbNullString Then
                                
                                '@ﾁｯﾌﾟID
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strChipId = _
                                    .typChipList(llngCnt).strChipId
                                
                                '@現工程変更前区分
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strOldClass = _
                                    .typChipList(llngCnt).strClass
                                
                                '@現工程変更後区分
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strNewClass = _
                                    .typChipList(llngCnt).strClass
                                
                                '@現工程変更前区分ID
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strOldClassID = _
                                    .typChipList(llngCnt).strClassID
                                
                                '@現工程変更後区分ID
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strNewClassID = _
                                    .typChipList(llngCnt).strClassID
                                
                                '@電特ｺｰﾄﾞ
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strEleCode = _
                                    .typChipList(llngCnt).strElectricCode
                                
                                '@電特ｸﾞﾚｰﾄﾞ
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strEleGrade = _
                                    .typChipList(llngCnt).strElectricGrade
                                
                                '@WAIST状態
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strWaistStatus = _
                                    .typChipList(llngCnt).strWaistStatus
                                
                                '@WAISTｺｰﾄﾞ
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strWaistCode = _
                                    .typChipList(llngCnt).strWaistCode
                                
                                '@電特ｺｰﾄﾞがNULL以外か
                                If .typChipList(llngCnt).strElectricCode <> vbNullString Then
                                
                                    '@前工程最新区分IDと電特ｺｰﾄﾞが異なるか
                                    If .typChipList(llngCnt).strBeforeClassID <> .typChipList(llngCnt).strElectricCode Then
                                        
                                        '@自工程更新ﾌﾗｸﾞが"1:自工程で更新あり"か
                                        If .typChipList(llngCnt).strNowstepEditFlag = CMstrNowstepEditEnable Then
                                            
                                            '@-----------------------
                                            '@ 読込後の処理の為、更新ﾌﾗｸﾞを立てる
                                            '@-----------------------
                                            '@現工程変更前自工程更新ﾌﾗｸﾞに"1:自工程更新あり"をｾｯﾄ
                                            mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strOldNowstepEditFlag = CMstrNowstepEditEnable
                                            
                                            '@現工程変更後自工程更新ﾌﾗｸﾞに"1:自工程更新あり"をｾｯﾄ
                                            mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2, llngCnt3).strNewNowstepEditFlag = CMstrNowstepEditEnable
                                        End If
                                    End If
                                End If
                                
                                '@ｶｳﾝﾀをｲﾝｸﾘﾒﾝﾄする
                                llngCnt = llngCnt + 1
                            End If
                        Next llngCnt3
                    Next llngCnt2
                Loop
            End With
            
            '@入力ﾁｪｯｸ区分に"1:未読込み"を設定する
            mtypWFInfo(mlngWFNowIndex-1).strInputCheckKbn = CMstrstrInputCheckKbn1
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvWFMapDenInfo_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvChipMapGrid_Set
    '機　能：ﾁｯﾌﾟﾏｯﾌﾟ設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/26 (Fri) 18:42:59 T.Kitagawa
    '更新日：2016/02/08 (Mon) 22:22:28 H.Hayashi
    '備　考：
    '　　　：2004/09/14 (Tue) 13:19:27 Y.Yamagishi　電特/外観/パ検結果登録対応
    '　　　：2004/11/25 (Thu) 16:03:10 S.Deguchi    傾向色と各Class設定を追加
    '　　　：2004/12/03 (Fri) 14:36:25 S.Deguchi    WF単位のﾁｯﾌﾟの良品/不良数をｾｯﾄ
    '　　　：2005/01/17 (Mon) 12:58:03 H.Wajima     自工程更新ﾌﾗｸﾞの判定処理を追加
    '　　　：2006/05/18 (Thu) 21:26:18 N.Kojima     不良ｺｰﾄﾞ別の現工程不良数格納処理を追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2006/06/26 (Mon) 17:11:38 T.Kitagawa   DataMatrixｺｰﾄﾞ(ﾊﾞｰｺｰﾄﾞ)対応(ﾕｰｻﾞ要望№0209)
    '　　　：2008/04/28 (Mon) 18:01:29 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2009/03/31 (Tue) 14:37:53 N.Kojima     ﾁｯﾌﾟ払出対応に伴い処理追加/変更。(案件№03434)
    '　　　：2009/09/02 (Wed) 17:05:23 N.Kojima     不良ﾁｯﾌﾟ情報(№表示)対応。※不良ﾁｯﾌﾟについて、不良ｺｰﾄﾞではなくﾁｯﾌﾟ№で表示する。(案件№03685)
    '　　　：2010/06/10 (Thu) 16:36:08 T.Oide       案件№04059 左右別不良数表示機能追加
    '      ：2016/02/05 (Fri) 14:15:43 H.Hayashi    GRB対応(R12-04)
    Private Sub prvChipMapGrid_Set()
        
        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt3                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngChipCol             As Integer      'ﾁｯﾌﾟ情報の列位置(表裏用判定)
        Dim llngScrapCmpCnt         As Integer      '不良ｺｰﾄﾞ比較用
        Dim llngWFCmpCnt            As Integer      'WFID比較用

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①WFｽﾛｯﾄﾏｯﾌﾟの背景色設定
            '@　　②ﾁｯﾌﾟ情報一覧のWF行の良品数、総不良数、現不良数、総払出数、現払出数の設定
            '@　　③ﾁｯﾌﾟﾏｯﾌﾟの列ﾀｲﾄﾙ設定(表:A～？、裏:Z～？)
            '@　　④ﾁｯﾌﾟﾏｯﾌﾟの設定(ﾁｯﾌﾟ№、背景色、文字色etc...)
            '@　　⑤不良/払出ｺｰﾄﾞ一覧の不良数の設定
            '@======================================================================================


            '@-----------------------
            '@ WFｽﾛｯﾄﾏｯﾌﾟの設定(ｽﾛｯﾄ№、WFID、傾向、不良、払出の設定)
            '@-----------------------
            With vsfWFMap

                '良品(白) 
                Dim newStyle_BC_EnableTrueColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor")
                newStyle_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                newStyle_BC_EnableTrueColor.ForeColor = SystemColors.WindowText
                newStyle_BC_EnableTrueColor.Font = New Font(newStyle_BC_EnableTrueColor.Font, FontStyle.Regular)
                '良品(白) 
                Dim newStyle_FC_vbRed_BC_EnableTrueColor As CellStyle = .Styles.Add("CustomStyle_ForColor_vbRed_BackColor_CMlngEnableTrueColor")
                newStyle_FC_vbRed_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                newStyle_FC_vbRed_BC_EnableTrueColor.ForeColor = Color.Red
                newStyle_FC_vbRed_BC_EnableTrueColor.Font = New Font(newStyle_FC_vbRed_BC_EnableTrueColor.Font, FontStyle.Bold)
                '不良(赤ﾋﾟﾝｸ)
                Dim newStyle_BC_FuryouColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngFuryouColor")
                newStyle_BC_FuryouColor.BackColor = ColorTranslator.FromWin32(CMlngFuryouColor)
                '払出(ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)
                Dim newStyle_BC_HaraidashiColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngHaraidashiColor")
                newStyle_BC_HaraidashiColor.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColor)
                '保留(薄灰色)
                Dim newStyle_BC_ReferOnlyColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngReferOnlyColor")
                newStyle_BC_ReferOnlyColor.BackColor = ColorTranslator.FromWin32(CMlngReferOnlyColor)
                '傾向(黄色)
                Dim newStyle_BC_KeikouColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngKeikouColor")
                newStyle_BC_KeikouColor.BackColor = ColorTranslator.FromWin32(CMlngKeikouColor)
                'その他(濃い灰色)
                Dim newStyle_BC_GridDarkGray As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle_BC_GridDarkGray.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)

                Dim cellRange As CellRange

                For llngCnt = 1 To CMlngvsfWFMapMaxSlotID
                    
                    '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きいか
                    If mstrSlotSize < CMlngvsfWFMapMaxSlotID - llngCnt + 1 Then
                    
                        '@処理なし

                    Else
                        '@ｽﾛｯﾄｻｲｽﾞの値の範囲(1～25)
                    
                        '@背景色を白に設定する
                        cellRange = .GetCellRange(llngCnt, CMlngvsfWFMapID)
                        If cellRange.StyleDisplay.ForeColor = Color.Red Then
                            cellRange.Style = newStyle_FC_vbRed_BC_EnableTrueColor
                        Else
                            cellRange.Style = newStyle_BC_EnableTrueColor
                        End If
                        
                        cellRange = .GetCellRange(llngCnt, CMlngvsfWFMapID, llngCnt, CMlngvsfWFMapDestNo)
                        '@★ 区分により処理分岐 ★
                        Select Case mtypWFInfo(CMlngvsfWFMapMaxSlotID - llngCnt).strClass
                            
                            '@〓 1：良品(白) 〓
                            Case CPstrClass1
                                If .GetCellRange(llngCnt, CMlngvsfWFMapID).StyleDisplay.ForeColor = Color.Red Then
                                    cellRange = .GetCellRange(llngCnt, CMlngvsfWFMapDestNo)
                                End If
                                cellRange.Style = newStyle_BC_EnableTrueColor
                            
                            '@〓 2：不良(赤ﾋﾟﾝｸ) 〓
                            Case CPstrClass2
                                
                                cellRange.Style = newStyle_BC_FuryouColor
                            
                            '@〓 3：払出(ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ) 〓
                            Case CPstrClass3

                                cellRange.Style = newStyle_BC_HaraidashiColor
                            
                            '@〓 4：保留(薄灰色) 〓
                            Case CPstrClass4
                                
                                cellRange.Style = newStyle_BC_ReferOnlyColor
                            
                            '@〓 5：傾向(黄色) 〓
                            Case CPstrClass5
                                
                                cellRange.Style = newStyle_BC_KeikouColor
                            
                            '@〓 その他(濃い灰色) 〓
                            Case Else
                                
                                cellRange.Style = newStyle_BC_GridDarkGray
                        
                        End Select
                    End If
                Next llngCnt
            End With
            
            
            '@-----------------------
            '@ ﾁｯﾌﾟ情報一覧の設定
            '@-----------------------
            With vsfChipCnt
                
                '@-----------------------
                '@ 良品数
                '@-----------------------
                If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strWFChipQuantity) Then
                    .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strWFChipQuantity), CPstrDateFormatKanma))
                Else
                    .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strWFChipQuantity)
                End If
                    
                '@-----------------------
                '@ 総不良数
                '@-----------------------
                If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strWFChipOutQuantity) Then
                    .SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strWFChipOutQuantity), CPstrDateFormatKanma))
                Else
                    .SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strWFChipOutQuantity)
                End If
                
                '@-----------------------
                '@ 現不良数
                '@-----------------------
                If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentOutQuantity) Then
                    .SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentOutQuantity), CPstrDateFormatKanma))
                Else
                    .SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentOutQuantity)
                End If
                
                '@-----------------------
                '@ 総払出数
                '@-----------------------
                If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strWFChipForwardQuantity) Then
                    .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strWFChipForwardQuantity), CPstrDateFormatKanma))
                Else
                    .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strWFChipForwardQuantity)
                End If
                
                '@-----------------------
                '@ 現払出数
                '@-----------------------
                If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentForwardQuantity) Then
                    .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentForwardQuantity), CPstrDateFormatKanma))
                Else
                    .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentForwardQuantity)
                End If
                
                '無機か(ｸﾞﾘｯﾄﾞの行数で判断)
                If vsfChipCnt.Rows.Count = CMlngvsfChipCntRowsVA Then
                
                    '@-----------------------
                    '@ 良品ﾁｯﾌﾟ数LOT-左
                    '@-----------------------
                    If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strChipQuantityLotL) Then
                        .SetData(CMlngvsfChipCntOKRowL, CMlngvsfChipCntLot, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strChipQuantityLotL), CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntOKRowL, CMlngvsfChipCntLot, mtypWFInfo(mlngWFNowIndex-1).strChipQuantityLotL)
                    End If
                    
                    '@-----------------------
                    '@ 良品ﾁｯﾌﾟ数LOT-右
                    '@-----------------------
                    If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strChipQuantityLotR) Then
                        .SetData(CMlngvsfChipCntOKRowR, CMlngvsfChipCntLot, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strChipQuantityLotR), CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntOKRowR, CMlngvsfChipCntLot, mtypWFInfo(mlngWFNowIndex-1).strChipQuantityLotR)
                    End If
                        
                    '@-----------------------
                    '@ 良品ﾁｯﾌﾟ数WF-左
                    '@-----------------------
                    If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strChipQuantityWfL) Then
                        .SetData(CMlngvsfChipCntOKRowL, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strChipQuantityWfL), CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntOKRowL, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strChipQuantityWfL)
                    End If
                        
                    '@-----------------------
                    '@ 良品ﾁｯﾌﾟ数WF-右
                    '@-----------------------
                    If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strChipQuantityWfR) Then
                        .SetData(CMlngvsfChipCntOKRowR, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strChipQuantityWfR), CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntOKRowR, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strChipQuantityWfR)
                    End If
                    
                    '@-----------------------
                    '@ 不良数LOT-左
                    '@-----------------------
                    If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityLotL) Then
                        .SetData(CMlngvsfChipCntNGRowL, CMlngvsfChipCntLot, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityLotL), CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntNGRowL, CMlngvsfChipCntLot, mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityLotL)
                    End If
                    
                    '@-----------------------
                    '@ 不良数LOT-右
                    '@-----------------------
                    If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityLotR) Then
                        .SetData(CMlngvsfChipCntNGRowR, CMlngvsfChipCntLot, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityLotR), CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntNGRowR, CMlngvsfChipCntLot, mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityLotR)
                    End If
                        
                    '@-----------------------
                    '@ 不良数WF-左
                    '@-----------------------
                    If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityWfL) Then
                        .SetData(CMlngvsfChipCntNGRowL, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityWfL), CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntNGRowL, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityWfL)
                    End If
                        
                    '@-----------------------
                    '@ 不良数WF-右
                    '@-----------------------
                    If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityWfR) Then
                        .SetData(CMlngvsfChipCntNGRowR, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityWfR), CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntNGRowR, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strChipOutQuantityWfR)
                    End If
                        
                    '@-----------------------
                    '@ 現工程不良数LOT-左
                    '@-----------------------
                    If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityLotL) Then
                        .SetData(CMlngvsfChipCntNowNGRowL, CMlngvsfChipCntLot, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityLotL), CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntNowNGRowL, CMlngvsfChipCntLot, mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityLotL)
                    End If
                        
                    '@-----------------------
                    '@ 現工程不良数LOT-右
                    '@-----------------------
                    If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityLotR) Then
                        .SetData(CMlngvsfChipCntNowNGRowR, CMlngvsfChipCntLot, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityLotR), CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntNowNGRowR, CMlngvsfChipCntLot, mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityLotR)
                    End If
                    
                    '@-----------------------
                    '@ 現工程不良数WF-左
                    '@-----------------------
                    If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityWfL) Then
                        .SetData(CMlngvsfChipCntNowNGRowL, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityWfL), CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntNowNGRowL, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityWfL)
                    End If
                    
                    '@-----------------------
                    '@ 現工程不良数WF-右
                    '@-----------------------
                    If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityWfL) Then
                        .SetData(CMlngvsfChipCntNowNGRowR, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityWfR), CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntNowNGRowR, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strChipCurrentOutQuantityWfR)
                    End If
                    
                End If
                    
                '@起動SBが基板か
                If pstrSBID = CPstrSBID1A0 Then
                
                    '@払出数行は"-"で表示
                    .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, CPstrMinus)
                    .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, CPstrMinus)
                    .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, CPstrMinus)
                    .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, CPstrMinus)
                End If
            End With
            
            
            '@-----------------------
            '@ ﾁｯﾌﾟﾏｯﾌﾟの列ﾀｲﾄﾙ設定
            '@-----------------------
            With vsfChipMap
                
                For llngCnt = 1 To mlngChipGridMaxCols
                    
                    '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐 〓
                    Select Case cmdHyouri.Text
                        
                        '@〓 表へ 〓
                        Case CMstrCmdHyouriKbn1
                            
                            .SetData(CMlngvsfChipMapNo, llngCnt, Chr(CMlngKeyCodeA + mlngChipGridMaxCols - llngCnt))
                        
                        '@〓 裏へ 〓
                        Case CMstrCmdHyouriKbn2
                            
                            .SetData(CMlngvsfChipMapNo, llngCnt, Chr(CMlngKeyCodeA + llngCnt - 1))
                    
                    End Select
                Next llngCnt
            End With
             
             
            '@-----------------------
            '@ ﾁｯﾌﾟﾏｯﾌﾟの設定
            '@-----------------------
            With vsfChipMap

                '良品
                Dim newStyle_FC_ChipNoForeColor_BC_EnableTrueColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngChipNoForeColor_BackColor_CMlngEnableTrueColor")
                newStyle_FC_ChipNoForeColor_BC_EnableTrueColor.ForeColor = ColorTranslator.FromWin32(CMlngChipNoForeColor)
                newStyle_FC_ChipNoForeColor_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                newStyle_FC_ChipNoForeColor_BC_EnableTrueColor.TextAlign = TextAlignEnum.RightCenter
                '@現工程用不良背景色(赤ﾋﾟﾝｸ)
                Dim newStyle_FC_BlackColor_BC_FuryouColorNow As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngFuryouColorNow")
                newStyle_FC_BlackColor_BC_FuryouColorNow.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                newStyle_FC_BlackColor_BC_FuryouColorNow.BackColor = ColorTranslator.FromWin32(CMlngFuryouColorNow)
                newStyle_FC_BlackColor_BC_FuryouColorNow.TextAlign = TextAlignEnum.RightCenter
                '@通常不良背景色(薄ﾋﾟﾝｸ)
                Dim newStyle_FC_BlackColor_BC_FuryouColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngFuryouColor")
                newStyle_FC_BlackColor_BC_FuryouColor.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                newStyle_FC_BlackColor_BC_FuryouColor.BackColor = ColorTranslator.FromWin32(CMlngFuryouColor)
                newStyle_FC_BlackColor_BC_FuryouColor.TextAlign = TextAlignEnum.RightCenter
                '@現工程用払出背景色(ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)
                Dim newStyle_FC_BlackColor_BC_HaraidashiColorNow As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngHaraidashiColorNow")
                newStyle_FC_BlackColor_BC_HaraidashiColorNow.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                newStyle_FC_BlackColor_BC_HaraidashiColorNow.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColorNow)
                newStyle_FC_BlackColor_BC_HaraidashiColorNow.TextAlign = TextAlignEnum.RightCenter
                '@通常払出背景色(薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)
                Dim newStyle_FC_BlackColor_BC_HaraidashiColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngHaraidashiColor")
                newStyle_FC_BlackColor_BC_HaraidashiColor.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                newStyle_FC_BlackColor_BC_HaraidashiColor.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColor)
                newStyle_FC_BlackColor_BC_HaraidashiColor.TextAlign = TextAlignEnum.RightCenter
                '@現工程用傾向背景色(山吹色)
                Dim newStyle_FC_BlackColor_BC_KeikouColorNow As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngKeikouColorNow")
                newStyle_FC_BlackColor_BC_KeikouColorNow.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                newStyle_FC_BlackColor_BC_KeikouColorNow.BackColor = ColorTranslator.FromWin32(CMlngKeikouColorNow)
                newStyle_FC_BlackColor_BC_KeikouColorNow.TextAlign = TextAlignEnum.RightCenter
                '@通常傾向背景色(黄色)
                Dim newStyle_FC_BlackColor_BC_KeikouColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngKeikouColor")
                newStyle_FC_BlackColor_BC_KeikouColor.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                newStyle_FC_BlackColor_BC_KeikouColor.BackColor = ColorTranslator.FromWin32(CMlngKeikouColor)
                newStyle_FC_BlackColor_BC_KeikouColor.TextAlign = TextAlignEnum.RightCenter
                newStyle_FC_BlackColor_BC_KeikouColorNow.TextAlign = TextAlignEnum.RightCenter
                '変更不可
                Dim newStyle_FC_ChipNoForeColor_BC_ReferOnlyColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngChipNoForeColor_BackColor_CMlngReferOnlyColor")
                newStyle_FC_ChipNoForeColor_BC_ReferOnlyColor.ForeColor = ColorTranslator.FromWin32(CMlngChipNoForeColor)
                newStyle_FC_ChipNoForeColor_BC_ReferOnlyColor.BackColor = ColorTranslator.FromWin32(CMlngReferOnlyColor)
                newStyle_FC_ChipNoForeColor_BC_ReferOnlyColor.TextAlign = TextAlignEnum.RightCenter
                'その他
                Dim newStyle_FC_BlackColor_BC_EnableTrueColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngEnableTrueColor")
                newStyle_FC_BlackColor_BC_EnableTrueColor.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                newStyle_FC_BlackColor_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                newStyle_FC_BlackColor_BC_EnableTrueColor.TextAlign = TextAlignEnum.RightCenter
                '@背景色を灰色に設定
                Dim newStyle_BC_EnableFalseColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableFalseColor")
                newStyle_BC_EnableFalseColor.ForeColor = ColorTranslator.FromWin32(CMlngChipNoForeColor)
                newStyle_BC_EnableFalseColor.BackColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                newStyle_BC_EnableFalseColor.TextAlign = TextAlignEnum.RightCenter
                '@小豆色(ﾁｯﾌﾟ用裏表示時の概観ﾊﾞｯｸｶﾗｰ)
                Dim newStyle_BC_ChipUraBackColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngWhiteColor_BackColor_CMlngChipUraBackColor")
                newStyle_BC_ChipUraBackColor.ForeColor = ColorTranslator.FromWin32(CMlngWhiteColor)
                newStyle_BC_ChipUraBackColor.BackColor = ColorTranslator.FromWin32(CMlngChipUraBackColor)
                newStyle_BC_ChipUraBackColor.TextAlign = TextAlignEnum.RightCenter
                newStyle_BC_ChipUraBackColor.Font = New Font(newStyle_BC_ChipUraBackColor.Font.FontFamily,CMlngCornerWfNoSize, FontStyle.Regular)
                '@濃い灰色(ﾁｯﾌﾟ用表表示時の概観ﾊﾞｯｸｶﾗｰ)
                Dim newStyle_BC_ChipOmoteBackColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngWhiteColor_BackColor_CMlngChipOmoteBackColor")
                newStyle_BC_ChipOmoteBackColor.ForeColor = ColorTranslator.FromWin32(CMlngWhiteColor)
                newStyle_BC_ChipOmoteBackColor.BackColor = ColorTranslator.FromWin32(CMlngChipOmoteBackColor)
                newStyle_BC_ChipOmoteBackColor.TextAlign = TextAlignEnum.RightCenter
                newStyle_BC_ChipOmoteBackColor.Font = New Font(newStyle_BC_ChipOmoteBackColor.Font.FontFamily,CMlngCornerWfNoSize, FontStyle.Regular)
                '機種設定色
                Dim newStyle_BC_PdBackColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngWhiteColor_BackColor_PdBackColor")
                newStyle_BC_PdBackColor.ForeColor = ColorTranslator.FromWin32(CMlngWhiteColor)
                newStyle_BC_PdBackColor.TextAlign = TextAlignEnum.RightCenter
                newStyle_BC_PdBackColor.Font = New Font(newStyle_BC_PdBackColor.Font.FontFamily,CMlngCornerWfNoSize, FontStyle.Regular)

                '@起動区分が"1：不良ﾁｯﾌﾟ情報(№表示)起動"か
                If plngfrmxxCM0080Kbn = CPlngNumOne Then
                    '@表示系機能なので見易くする為、太字にする
                    newStyle_FC_BlackColor_BC_FuryouColorNow.Font = New Font(newStyle_FC_BlackColor_BC_FuryouColorNow.Font, FontStyle.Bold)
                    newStyle_FC_BlackColor_BC_FuryouColor.Font = New Font(newStyle_FC_BlackColor_BC_FuryouColor.Font, FontStyle.Bold)
                Else
                    '@ﾁｯﾌﾟ状態変更登録(or上書き)起動の場合は、細字にする
                    newStyle_FC_BlackColor_BC_FuryouColorNow.Font = New Font(newStyle_FC_BlackColor_BC_FuryouColorNow.Font, FontStyle.Regular)
                    newStyle_FC_BlackColor_BC_FuryouColor.Font = New Font(newStyle_FC_BlackColor_BC_FuryouColor.Font, FontStyle.Regular)
                End If

                
                Dim cellRange As CellRange

                For llngCnt2 = 1 To mlngChipGridMaxRows
                    
                    For llngCnt3 = 1 To mlngChipGridMaxCols 
                        
                        '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐(ﾁｯﾌﾟ配列の列変換) ★
                        Select Case cmdHyouri.Text
                        
                            '@〓 表へ 〓
                            Case CMstrCmdHyouriKbn1
                            
                                llngChipCol = mlngChipGridMaxCols - llngCnt3 + 1
                            
                            '@〓 裏へ 〓
                            Case CMstrCmdHyouriKbn2
                            
                                llngChipCol = llngCnt3

                        End Select
                        
                        cellRange = .GetCellRange(llngCnt2, llngCnt3)
                        '@使用可能区分が"True:使用可能"か
                        If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).blnEnableKbn = True Then
                            
                            '@WFIDがNULL以外、かつﾁｯﾌﾟIDもNULL以外か
                            If mtypWFInfo(mlngWFNowIndex-1).strWfId <> vbNullString And _
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strChipId <> vbNullString Then
                                '@NULL以外の場合
                                
                                '@ﾁｯﾌﾟIDの文字色を灰色にする
                                    
                                '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐(ﾁｯﾌﾟIDの表示) ★
                                Select Case cmdHyouri.Text
                                    
                                    '@〓 表へ 〓
                                    Case CMstrCmdHyouriKbn1
                                        
                                        .SetData(llngCnt2, llngCnt3, _
                                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strChipId, 3))
                                    
                                    '@〓 裏へ 〓
                                    Case CMstrCmdHyouriKbn2
                                        
                                        .SetData(llngCnt2, llngCnt3, _
                                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strChipId, 3))
                                
                                End Select
                                
                                '@現工程変更後区分IDがNULL以外(設定されている)か
                                If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strNewClassID <> vbNullString Then
                                    
                                    '@文字色を黒色に戻す

                                    '@-----------------------
                                    '@ ①ﾁｯﾌﾟ状態変更登録(or上書き)での起動の場合、不良ｺｰﾄﾞを表示
                                    '@ ②不良ﾁｯﾌﾟ情報(№表示)での起動の場合、ﾁｯﾌﾟ№のままにする
                                    '@-----------------------
                                    '@起動区分が"1：不良ﾁｯﾌﾟ情報(№表示)起動"以外か
                                    '@　※"0：ﾁｯﾌﾟ状態変更登録(or上書き)"か
                                    If plngfrmxxCM0080Kbn <> CPlngNumOne Then

                                        '@現工程変更後区分IDの表示
                                        .SetData(llngCnt2, llngCnt3, _
                                            mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strNewClassID)
                                    End If
                                End If
                                
                                '@ﾁｯﾌﾟ背景色の初期化(既存不具合：表裏切り替えにて良品以外ﾁｯﾌﾟの背景色が残ってしまう不具合の対応)

                                '@★ 現工程変更後区分IDにより処理分岐(背景色の設定) ★
                                Select Case mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strNewClass
                                    
                                    '@〓 1：良品 〓
                                    Case CPstrClass1

                                        '@白
                                        cellRange.Style = newStyle_FC_ChipNoForeColor_BC_EnableTrueColor

                                    '@〓 2：不良 〓
                                    Case CPstrClass2
                                        
                                        '@★★ 現工程変更後自工程更新ﾌﾗｸﾞにより処理分岐(背景色の設定) ★★
                                        Select Case mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strNewNowstepEditFlag
                                            
                                            '@〓〓 1:自工程更新あり 〓〓
                                            Case CMstrNowstepEditEnable
                                            
                                                '@現工程用不良背景色(赤ﾋﾟﾝｸ)
                                                cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColorNow
                                            
                                            
                                            '@〓〓 0:自工程更新なし 〓〓
                                            Case CMstrNowstepEditDisable
                                        
                                                '@通常不良背景色(薄ﾋﾟﾝｸ)
                                                cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColor
                                            
                                            
                                            '@〓〓 その他 〓〓
                                            Case Else
                                            
                                                '@通常不良背景色(薄ﾋﾟﾝｸ)
                                                cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColor
                                        
                                        End Select

                                    '@〓 3:払出 〓
                                    Case CPstrClass3

                                        '@起動区分が"1：不良ﾁｯﾌﾟ情報(№表示)起動"以外か
                                        '@　※"0：ﾁｯﾌﾟ状態変更登録(or上書き)"か
                                        If plngfrmxxCM0080Kbn <> CPlngNumOne Then

                                            '@★★ 現工程変更後自工程更新ﾌﾗｸﾞにより処理分岐(背景色の設定) ★★
                                            Select Case mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strNewNowstepEditFlag
                                                
                                                '@〓〓 1:自工程更新あり 〓〓
                                                Case CMstrNowstepEditEnable
                                                
                                                    '@現工程用払出背景色(ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColorNow
                                                
                                                
                                                '@〓〓 0:自工程更新なし 〓〓
                                                Case CMstrNowstepEditDisable
                                            
                                                    '@通常払出背景色(薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColor
                                                
                                                
                                                '@〓〓 その他 〓〓
                                                Case Else
                                                
                                                    '@通常払出背景色(薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColor
                                            
                                            End Select
                                        Else
                                            '@起動区分が"1：不良ﾁｯﾌﾟ情報(№表示)起動"の場合
                                            cellRange.Style = newStyle_FC_BlackColor_BC_EnableTrueColor
                                        End If
                                    
                                    '@〓 5:傾向 〓
                                    Case CPstrClass5

                                        '@起動区分が"1：不良ﾁｯﾌﾟ情報(№表示)起動"以外か
                                        '@　※"0：ﾁｯﾌﾟ状態変更登録(or上書き)"か
                                        If plngfrmxxCM0080Kbn <> CPlngNumOne Then

                                            '@★★ 現工程変更後自工程更新ﾌﾗｸﾞにより処理分岐(背景色の設定) ★★
                                            Select Case mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strNewNowstepEditFlag
                                                
                                                '@〓〓 1:自工程更新あり 〓〓
                                                Case CMstrNowstepEditEnable
                                            
                                                    '@現工程用傾向背景色(山吹色)
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColorNow
                                                
                                                
                                                '@〓〓 0:自工程更新なし 〓〓
                                                Case CMstrNowstepEditDisable
                                                    
                                                    '@通常傾向背景色(黄色)
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColor
                                                
                                                
                                                '@〓〓 その他 〓〓
                                                Case Else
                                                    
                                                    '@通常傾向背景色(黄色)
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColor
                                            
                                            End Select
                                        Else
                                            '@起動区分が"1：不良ﾁｯﾌﾟ情報(№表示)起動"の場合
                                            cellRange.Style = newStyle_FC_BlackColor_BC_EnableTrueColor
                                        End If
                                    
                                    '@〓 10:変更不可 〓
                                    Case CPstrClass10
                            
                                        cellRange.Style = newStyle_FC_ChipNoForeColor_BC_ReferOnlyColor
                            
                            
                                    '@〓 その他 〓
                                    Case Else
                                        
                                        '@白
                                        cellRange.Style = newStyle_FC_BlackColor_BC_EnableTrueColor
                                
                                End Select
                            Else
                                '@WFID、またはﾁｯﾌﾟIDがNULLの場合
                            
                                '@ﾁｯﾌﾟの文字をｸﾘｱ
                                .SetData(llngCnt2, llngCnt3, vbNullString)
                                
                                '@背景色を灰色に設定
                                cellRange.Style = newStyle_BC_EnableFalseColor
                            End If
                        Else
                            '@使用可能区分が"False:使用不可"の場合
                        
                            '@ﾁｯﾌﾟの文字をｸﾘｱ
                            .SetData(llngCnt2, llngCnt3, vbNullString)
                            
                            '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐(背景色変更) ★
                            Select Case cmdHyouri.Text
                                
                                '@〓 表へ 〓
                                Case CMstrCmdHyouriKbn1
                                    
                                    '@WFIDがNULL
                                    If (mtypWFInfo(mlngWFNowIndex-1).strWfId = vbNullString) Then

                                        '@濃い灰色(ﾁｯﾌﾟ用表表示時の概観ﾊﾞｯｸｶﾗｰ)
                                        cellRange.Style = newStyle_BC_ChipOmoteBackColor
                                    Else
                                        
                                        '@小豆色(ﾁｯﾌﾟ用裏表示時の概観ﾊﾞｯｸｶﾗｰ)
                                        cellRange.Style = newStyle_BC_ChipUraBackColor
                                    End If

                                '@〓 裏へ 〓
                                Case CMstrCmdHyouriKbn2
                                    
                                    '@機種に紐付く色指定なし、又はWFIDがNULL
                                    If ((ptypLotprestate.strColorCd = vbNullString) Or (mtypWFInfo(mlngWFNowIndex-1).strWfId = vbNullString)) Then
                                                               
                                        '@背景色に濃い灰色(ﾁｯﾌﾟ用表表示時の概観ﾊﾞｯｸｶﾗｰ)
                                        cellRange.Style = newStyle_BC_ChipOmoteBackColor
                            
                                    Else
                                    
                                        '@背景色に機種に紐付く指定色
                                        newStyle_BC_PdBackColor.BackColor = ColorTranslator.FromWin32(CPstrAmpersand + ptypLotprestate.strColorCd)
                                        cellRange.Style = newStyle_BC_PdBackColor
                                    End If
                                    
                                    '@WFID有りの場合
                                    If ((pstrSBID = CPstrSBID2A0) And (mtypWFInfo(mlngWFNowIndex-1).strWfId <> vbNullString)) Then
                                            
                                        '@左上隅
                                        If (llngCnt2 = 1 And llngCnt3 = 1) Then

                                            '@WFID表示、白色文字
                                            .SetData(llngCnt2, llngCnt3, Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).strWfId, 3))

                                        '@右上隅
                                        ElseIf (llngCnt2 = 1 And llngCnt3 = mlngChipGridMaxCols) Then

                                            '@WFID表示、白色文字
                                            .SetData(llngCnt2, llngCnt3, Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).strWfId, 3))

                                        '@左下隅
                                        ElseIf (llngCnt2 = mlngChipGridMaxRows And llngCnt3 = 1) Then

                                            'WFID表示、白色文字
                                            .SetData(llngCnt2, llngCnt3, Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).strWfId, 3))

                                        '@右下隅
                                        ElseIf (llngCnt2 = mlngChipGridMaxRows And llngCnt3 = mlngChipGridMaxCols ) Then
                                                 
                                            'WFID表示、白色文字
                                            .SetData(llngCnt2, llngCnt3, Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).strWfId, 3))

                                        End If

                                    End If
                            
                            End Select
                        End If
                    Next llngCnt3
                Next llngCnt2
                
                
                '@-----------------------
                '@ 不良/払出ｺｰﾄﾞ一覧の不良/払出数の再設定
                '@-----------------------
                '@不良/払出ｺｰﾄﾞ一覧のﾃﾞｰﾀ数分ﾙｰﾌﾟする
                For llngCnt2 = 1 To vsfScpList.Rows.Count - 1
                
                    '@不良/払出ｺｰﾄﾞ一覧の不良/払出数を初期化("0"を格納)
                    vsfScpList.SetData(llngCnt2, CMlngvsfScpListScrapNum, CPstrZero)
                    
                Next llngCnt2
                
                For llngCnt2 = 1 To mlngChipGridMaxRows
                    
                    For llngCnt3 = 1 To mlngChipGridMaxCols
                        
                        '@ﾁｯﾌﾟの背景色が現工程不良色、または現工程払出色か
                        If .GetCellRange(llngCnt2, llngCnt3).StyleDisplay.BackColor = ColorTranslator.FromWin32(CMlngFuryouColorNow) Or _
                            .GetCellRange(llngCnt2, llngCnt3).StyleDisplay.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColorNow) Then
                                                
                            '@該当する不良/払出ｺｰﾄﾞを検索する(不良/払出一覧のｺｰﾄﾞとﾁｯﾌﾟ表示不良/払出ｺｰﾄﾞ)
                            '@不良/払出ｺｰﾄﾞ数分ﾙｰﾌﾟ
                            For llngScrapCmpCnt = 1 To vsfScpList.Rows.Count - 1
                                
                                '@適用不良/払出ｺｰﾄﾞと同じ不良/払出ｺｰﾄﾞか
                                If .GetData(llngCnt2, llngCnt3) = _
                                    vsfScpList.GetData(llngScrapCmpCnt, CMlngvsfScpListCode) Then

                                    '@不良/払出数(「数」)に+1
                                    vsfScpList.SetData(llngScrapCmpCnt, CMlngvsfScpListScrapNum, _
                                        CStr(CLng(vsfScpList.GetData(llngScrapCmpCnt, CMlngvsfScpListScrapNum)) + 1))
                                
                                End If
                            Next llngScrapCmpCnt
                        End If
                    Next llngCnt3
                Next llngCnt2
                
                
                '@-----------------------
                '@ 該当する不良/払出ｺｰﾄﾞを検索する(不良/払出一覧のｺｰﾄﾞとﾁｯﾌﾟ表示不良/払出ｺｰﾄﾞ)
                '@-----------------------
                '@不良/払出ｺｰﾄﾞ一覧にﾃﾞｰﾀが存在するか
                If vsfScpList.Rows.Count > 1 Then
                
                    '@WF数分ﾙｰﾌﾟ
                    For llngWFCmpCnt = 0 To ptypLotScrapInfo.typWFScrapInfo.Count - 1
            
                        '@選択WFIDと配列WFIDが同じ場合
                        If vsfWFMap.GetData(vsfWFMap.Row, CMlngvsfWFMapID) = _
                            ptypLotScrapInfo.typWFScrapInfo(llngWFCmpCnt).strWfId Then
            
                            '@不良/払出ｺｰﾄﾞ数分ﾙｰﾌﾟ
                            For llngScrapCmpCnt = 0 To ptypLotScrapInfo.typWFScrapInfo(llngWFCmpCnt).typNowScrapList.Count - 1
            
                                '@配列の不良/払出ｺｰﾄﾞと、ｸﾞﾘｯﾄﾞの不良/払出ｺｰﾄﾞが同じ場合
                                If vsfScpList.GetData(llngScrapCmpCnt+1, CMlngvsfScpListCode) = _
                                    ptypLotScrapInfo.typWFScrapInfo(llngWFCmpCnt).typNowScrapList(llngScrapCmpCnt).strScrapCode Then
                                    Dim tmp As NowScrapList = ptypLotScrapInfo.typWFScrapInfo(llngWFCmpCnt).typNowScrapList(llngScrapCmpCnt)
                                    '@不良/払出数
                                    tmp.strScrapNum = vsfScpList.GetData(llngScrapCmpCnt+1, CMlngvsfScpListScrapNum)
                                    ptypLotScrapInfo.typWFScrapInfo(llngWFCmpCnt).typNowScrapList(llngScrapCmpCnt) = tmp
                                
                                End If
                            Next llngScrapCmpCnt
                        End If
                    Next llngWFCmpCnt
                End If
                
            End With
            
            '@Dmﾁｯﾌﾟ番号選択配列のｸﾘｱ
            Erase mstrDmSelectChipNo
            mlngDmSelectChipNoMaxCnt = 0
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvChipMapGrid_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvChipMapElectric_Set
    '機　能：電特結果表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/06 (Mon) 17:14:47 Y.Yamagishi
    '更新日：2016/02/08 (Mon) 22:25:21 H.Hayashi
    '備　考：
    '　　　：2004/12/03 (Fri) 14:36:25 S.Deguchi    WF単位のﾁｯﾌﾟの良品/不良数をｾｯﾄ
    '　　　：2005/01/17 (Mon) 12:43:37 H.Wajima     自工程更新ﾌﾗｸﾞの判定を追加
    '　　　：2005/04/04 (Mon) 17:18:10 S.Deguchi    電特ﾏｯﾌﾟの場合にも読み込み時には自工程変更色を適用するように修正
    '　　　：2006/02/09 (Thu) 16:38:17 N.Kasai      総ﾁｯﾌﾟ数量の洗い替え表示追加
    '　　　：2006/05/18 (Thu) 21:26:18 N.Kojima     不良ｺｰﾄﾞ別の現工程不良数格納処理を追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2006/06/26 (Mon) 17:09:27 T.Kitagawa   DataMatrixｺｰﾄﾞ(ﾊﾞｰｺｰﾄﾞ)対応(ﾕｰｻﾞ要望№0209)
    '　　　：2008/04/30 (Wed) 12:47:42 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2009/03/31 (Tue) 11:30:26 N.Kojima     払出ﾁｯﾌﾟの色設定処理等追加。(案件№03434)
    '      ：2016/02/05 (Fri) 14:15:43 H.Hayashi    GRB対応(R12-04)
    Private Sub prvChipMapElectric_Set()
        
        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt3                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngChipCol             As Integer      'ﾁｯﾌﾟ情報の列位置(表裏用判定)

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①WFｽﾛｯﾄﾏｯﾌﾟの背景色設定
            '@　　②ﾁｯﾌﾟ情報一覧のWF行の良品、総不良、現不良、総払出、現払出の設定
            '@　　③ﾁｯﾌﾟﾏｯﾌﾟの列ﾀｲﾄﾙ設定(表:A～？、裏:Z～？)
            '@　　④電特ｺｰﾄﾞ＆電特ｸﾞﾚｰﾄﾞ別、ﾁｯﾌﾟﾏｯﾌﾟの設定(ﾁｯﾌﾟ№、背景色、文字色etc...)
            '@======================================================================================


            '@-----------------------
            '@ WFｽﾛｯﾄﾏｯﾌﾟの背景色設定
            '@-----------------------
            With vsfWFMap

                '@ﾊﾞｯｸｶﾗｰを水色に設定
                Dim newStyle_BC_ResultOKColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngResultOKColor")
                newStyle_BC_ResultOKColor.BackColor = ColorTranslator.FromWin32(CMlngResultOKColor)
                '@ﾊﾞｯｸｶﾗｰをﾋﾟﾝｸ(既不良の色とは異なる)に設定
                Dim newStyle_BC_ResultNGColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngResultNGColor")
                newStyle_BC_ResultNGColor.BackColor = ColorTranslator.FromWin32(CMlngResultNGColor)
                '@ﾊﾞｯｸｶﾗｰを白に設定
                Dim newStyle_BC_EnableTrueColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor")
                newStyle_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                '@ﾊﾞｯｸｶﾗｰを白に設定
                Dim newStyle_FC_vbRed_BC_EnableTrueColor As CellStyle = .Styles.Add("CustomStyle_ForColor_vbRed_BackColor_CMlngEnableTrueColor")
                newStyle_FC_vbRed_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                newStyle_FC_vbRed_BC_EnableTrueColor.ForeColor = Color.Red
                newStyle_FC_vbRed_BC_EnableTrueColor.Font = New Font(newStyle_FC_vbRed_BC_EnableTrueColor.Font, FontStyle.Bold)

                For llngCnt = 1 To CMlngvsfWFMapMaxSlotID
                    
                    '@ｽﾛｯﾄｻｲｽﾞより検索ｽﾛｯﾄ№が小さいか
                    If mstrSlotSize < CMlngvsfWFMapMaxSlotID - llngCnt + 1 Then
                    
                        '@処理なし

                    Else
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfWFMapID, llngCnt, CMlngvsfWFMapDestNo)
                        '@★ 電特結果により処理分岐 ★
                        Select Case mtypWFInfo(CMlngvsfWFMapMaxSlotID - llngCnt).strResult
                            
                            '@〓 OK 〓
                            Case CMstrResultOK
                                
                                '@ﾊﾞｯｸｶﾗｰを水色に設定
                                cellRange.Style = newStyle_BC_ResultOKColor
                            
                            '@〓 NG 〓
                            Case CMstrResultNG
                                
                                '@ﾊﾞｯｸｶﾗｰをﾋﾟﾝｸ(既不良の色とは異なる)に設定
                                cellRange.Style = newStyle_BC_ResultNGColor
                            
                            '@〓 その他 〓
                            Case vbNullString
                                
                                '@WFIDがNULL以外か
                                If mtypWFInfo(CMlngvsfWFMapMaxSlotID - llngCnt).strWfId <> vbNullString Then
                                    
                                    '@ﾊﾞｯｸｶﾗｰを白に設定
                                    If cellRange.StyleDisplay.ForeColor = Color.Red Then
                                        cellRange.Style = newStyle_FC_vbRed_BC_EnableTrueColor
                                        cellRange = .GetCellRange(llngCnt, CMlngvsfWFMapDestNo)
                                        cellRange.Style = newStyle_BC_EnableTrueColor
                                    Else
                                        cellRange.Style = newStyle_BC_EnableTrueColor
                                    End If
                                End If

                        End Select
                    End If
                Next llngCnt
            End With
            
            
            '@-----------------------
            '@ ﾁｯﾌﾟ情報一覧の数量設定
            '@-----------------------
            With vsfChipCnt

                '@-----------------------
                '@ 良品数
                '@-----------------------
                If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strWFChipQuantity) Then
                    .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strWFChipQuantity), CPstrDateFormatKanma))
                Else
                    .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strWFChipQuantity)
                End If
                    
                '@-----------------------
                '@ 総不良数
                '@-----------------------
                If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strWFChipOutQuantity) Then
                    .SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strWFChipOutQuantity), CPstrDateFormatKanma))
                Else
                    .SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strWFChipOutQuantity)
                End If
                    
                '@-----------------------
                '@ 現不良数
                '@-----------------------
                If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentOutQuantity) Then
                    .SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentOutQuantity), CPstrDateFormatKanma))
                Else
                    .SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentOutQuantity)
                End If

                '@-----------------------
                '@ 総払出数
                '@-----------------------
                If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strWFChipForwardQuantity) Then
                    .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strWFChipForwardQuantity), CPstrDateFormatKanma))
                Else
                    .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strWFChipForwardQuantity)
                End If
                    
                '@-----------------------
                '@ 現払出数
                '@-----------------------
                If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentForwardQuantity) Then
                    .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentForwardQuantity), CPstrDateFormatKanma))
                Else
                    .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentForwardQuantity)
                End If

                '@起動SBが基板か
                If pstrSBID = CPstrSBID1A0 Then
                
                    '@払出数行は"-"で表示
                    .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, CPstrMinus)
                    .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, CPstrMinus)
                    .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, CPstrMinus)
                    .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, CPstrMinus)
                End If
            End With
            
            
            '@-----------------------
            '@ ﾁｯﾌﾟﾏｯﾌﾟの列ﾀｲﾄﾙ変更
            '@-----------------------
            With vsfChipMap
                
                For llngCnt = 1 To mlngChipGridMaxCols
                    
                    '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐 ★
                    Select Case cmdHyouri.Text
                        
                        '@〓 表へ 〓
                        Case CMstrCmdHyouriKbn1
                            
                            '@列ﾀｲﾄﾙを"Z"⇒"A"と逆順で表示する
                            .SetData(CMlngvsfChipMapNo, llngCnt, Chr(CMlngKeyCodeA + mlngChipGridMaxCols - llngCnt))
                        
                        '@〓 裏へ 〓
                        Case CMstrCmdHyouriKbn2
                            
                            '@列ﾀｲﾄﾙを"A"から表示する
                            .SetData(CMlngvsfChipMapNo, llngCnt, Chr(CMlngKeyCodeA + llngCnt - 1))
                    
                    End Select
                Next llngCnt
            End With
             
             
            '@-----------------------
            '@ ﾁｯﾌﾟﾏｯﾌﾟの設定
            '@-----------------------
            With vsfChipMap

                '@背景色を白に設定
                Dim newStyle_FC_ChipNoForeColor_BC_EnableTrueColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngChipNoForeColor_BackColor_CMlngEnableTrueColor")
                newStyle_FC_ChipNoForeColor_BC_EnableTrueColor.ForeColor = ColorTranslator.FromWin32(CMlngChipNoForeColor)
                newStyle_FC_ChipNoForeColor_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                newStyle_FC_ChipNoForeColor_BC_EnableTrueColor.TextAlign = TextAlignEnum.RightCenter
                '@背景色を白に設定
                Dim newStyle_FC_BlackColor_BC_EnableTrueColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngEnableTrueColor")
                newStyle_FC_BlackColor_BC_EnableTrueColor.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                newStyle_FC_BlackColor_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                newStyle_FC_BlackColor_BC_EnableTrueColor.TextAlign = TextAlignEnum.RightCenter
                '@現工程用不良背景色(赤ﾋﾟﾝｸ)を設定
                Dim newStyle_FC_BlackColor_BC_FuryouColorNow As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngFuryouColorNow")
                newStyle_FC_BlackColor_BC_FuryouColorNow.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                newStyle_FC_BlackColor_BC_FuryouColorNow.BackColor = ColorTranslator.FromWin32(CMlngFuryouColorNow)
                newStyle_FC_BlackColor_BC_FuryouColorNow.TextAlign = TextAlignEnum.RightCenter
                '@既不良背景色(ﾋﾟﾝｸ)を設定
                Dim newStyle_FC_BlackColor_BC_FuryouColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngFuryouColor")
                newStyle_FC_BlackColor_BC_FuryouColor.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                newStyle_FC_BlackColor_BC_FuryouColor.BackColor = ColorTranslator.FromWin32(CMlngFuryouColor)
                newStyle_FC_BlackColor_BC_FuryouColor.TextAlign = TextAlignEnum.RightCenter
                '@現工程用払出背景色(ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)を設定
                Dim newStyle_FC_BlackColor_BC_HaraidashiColorNow As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngHaraidashiColorNow")
                newStyle_FC_BlackColor_BC_HaraidashiColorNow.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                newStyle_FC_BlackColor_BC_HaraidashiColorNow.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColorNow)
                newStyle_FC_BlackColor_BC_HaraidashiColorNow.TextAlign = TextAlignEnum.RightCenter
                '@既払出背景色(薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)を設定
                Dim newStyle_FC_BlackColor_BC_HaraidashiColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngHaraidashiColor")
                newStyle_FC_BlackColor_BC_HaraidashiColor.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                newStyle_FC_BlackColor_BC_HaraidashiColor.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColor)
                newStyle_FC_BlackColor_BC_HaraidashiColor.TextAlign = TextAlignEnum.RightCenter
                '@現工程用傾向背景色(山吹色)を設定
                Dim newStyle_FC_BlackColor_BC_KeikouColorNow As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngKeikouColorNow")
                newStyle_FC_BlackColor_BC_KeikouColorNow.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                newStyle_FC_BlackColor_BC_KeikouColorNow.BackColor = ColorTranslator.FromWin32(CMlngKeikouColorNow)
                newStyle_FC_BlackColor_BC_KeikouColorNow.TextAlign = TextAlignEnum.RightCenter
                '@既傾向背景色(ﾚﾓﾝ色)を設定
                Dim newStyle_FC_BlackColor_BC_KeikouColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngKeikouColor")
                newStyle_FC_BlackColor_BC_KeikouColor.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                newStyle_FC_BlackColor_BC_KeikouColor.BackColor = ColorTranslator.FromWin32(CMlngKeikouColor)
                newStyle_FC_BlackColor_BC_KeikouColor.TextAlign = TextAlignEnum.RightCenter
                '@背景色を白に設定
                Dim newStyle_BC_EnableFalseColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableFalseColor")
                newStyle_BC_EnableFalseColor.ForeColor = ColorTranslator.FromWin32(CMlngChipNoForeColor)
                newStyle_BC_EnableFalseColor.BackColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                newStyle_BC_EnableFalseColor.TextAlign = TextAlignEnum.RightCenter
                '@背景色に抹茶色を設定
                Dim newStyle_BC_EleUraBackColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEleUraBackColor")
                newStyle_BC_EleUraBackColor.ForeColor = ColorTranslator.FromWin32(CMlngWhiteColor)
                newStyle_BC_EleUraBackColor.BackColor = ColorTranslator.FromWin32(CMlngEleUraBackColor)
                newStyle_BC_EleUraBackColor.TextAlign = TextAlignEnum.RightCenter
                newStyle_BC_EleUraBackColor.Font = New Font(newStyle_BC_EleUraBackColor.Font.FontFamily,CMlngCornerWfNoSize, FontStyle.Regular)
                '@濃い灰色(ﾁｯﾌﾟ用表表示時の概観ﾊﾞｯｸｶﾗｰ)
                Dim newStyle_BC_ChipOmoteBackColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngChipOmoteBackColor")
                newStyle_BC_ChipOmoteBackColor.ForeColor = ColorTranslator.FromWin32(CMlngWhiteColor)
                newStyle_BC_ChipOmoteBackColor.BackColor = ColorTranslator.FromWin32(CMlngChipOmoteBackColor)
                newStyle_BC_ChipOmoteBackColor.TextAlign = TextAlignEnum.RightCenter
                newStyle_BC_ChipOmoteBackColor.Font = New Font(newStyle_BC_ChipOmoteBackColor.Font.FontFamily,CMlngCornerWfNoSize, FontStyle.Regular)
                '@背景色に紺色を設定
                Dim newStyle_BC_EleOmoteBackColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEleOmoteBackColor")
                newStyle_BC_EleOmoteBackColor.ForeColor = ColorTranslator.FromWin32(CMlngWhiteColor)
                newStyle_BC_EleOmoteBackColor.BackColor = ColorTranslator.FromWin32(CMlngEleOmoteBackColor)
                newStyle_BC_EleOmoteBackColor.TextAlign = TextAlignEnum.RightCenter
                newStyle_BC_EleOmoteBackColor.Font = New Font(newStyle_BC_EleOmoteBackColor.Font.FontFamily,CMlngCornerWfNoSize, FontStyle.Regular)
                '機種設定色
                Dim newStyle_BC_PdBackColor As CellStyle = .Styles.Add("CustomStyle_BackColor_PdBackColor")
                newStyle_BC_PdBackColor.ForeColor = ColorTranslator.FromWin32(CMlngWhiteColor)
                newStyle_BC_PdBackColor.TextAlign = TextAlignEnum.RightCenter
                newStyle_BC_PdBackColor.Font = New Font(newStyle_BC_PdBackColor.Font.FontFamily,CMlngCornerWfNoSize, FontStyle.Regular)

                Dim cellRange As CellRange

                For llngCnt2 = 1 To mlngChipGridMaxRows
                    
                    For llngCnt3 = 1 To mlngChipGridMaxCols
                        
                        '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐 ★
                        Select Case cmdHyouri.Text
                            
                            '@〓 表へ 〓
                            Case CMstrCmdHyouriKbn1
                                
                                llngChipCol = mlngChipGridMaxCols - llngCnt3 + 1
                            
                            '@〓 裏へ 〓
                            Case CMstrCmdHyouriKbn2
                                
                                llngChipCol = llngCnt3

                        End Select

                        cellRange = .GetCellRange(llngCnt2, llngCnt3)
                        '@使用可能区分が"True:使用可能"か
                        If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).blnEnableKbn = True Then
                            
                            '@WFIDがNULL以外、かつﾁｯﾌﾟIDがNULL以外か
                            If mtypWFInfo(mlngWFNowIndex-1).strWfId <> vbNullString And _
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strChipId <> vbNullString Then
                               
                                '@ﾁｯﾌﾟIDの文字色を灰色にする
                                
                                '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐(ﾁｯﾌﾟIDの表示) ★
                                Select Case cmdHyouri.Text
                                    
                                    '@〓 表へ 〓
                                    Case CMstrCmdHyouriKbn1
                                        
                                        '@ﾁｯﾌﾟIDを表示する
                                        .SetData(llngCnt2, llngCnt3, _
                                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strChipId, 3))
                                    
                                    '@〓 裏へ 〓
                                    Case CMstrCmdHyouriKbn2
                                        
                                        '@ﾁｯﾌﾟIDを表示する
                                        .SetData(llngCnt2, llngCnt3, _
                                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strChipId, 3))
                                
                                End Select
                                                            
                                '@処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝが"ﾁｯﾌﾟ登録"で、かつ対象ﾁｯﾌﾟの現工程変更後区分IDがNULL以外か
                                If optProcessKbn1.Checked = True _
                                    And mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strNewClassID <> vbNullString Then
                                    
                                    '@ﾁｯﾌﾟの文字色を黒色に戻す
                                    
                                    '@ﾁｯﾌﾟの区分IDの表示
                                    .SetData(llngCnt2, llngCnt3, mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strNewClassID)
                                    
                                    '@★ 現工程変更後区分により処理分岐 ★
                                    Select Case mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strNewClass
                                        
                                        '@〓 1：良品 〓
                                        Case CPstrClass1
                                            
                                            '@背景色を白に設定
                                            cellRange.Style = newStyle_FC_ChipNoForeColor_BC_EnableTrueColor
                                        
                                        
                                        '@〓 2：不良 〓
                                        Case CPstrClass2
                                            
                                            '@★★ 現工程変更後更新ﾌﾗｸﾞにより処理分岐 ★★
                                            Select Case mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strNewNowstepEditFlag
                                                
                                                '@〓〓 1:更新あり 〓〓
                                                Case CMstrNowstepEditEnable
                                                    
                                                    '@現工程用不良背景色(赤ﾋﾟﾝｸ)を設定
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColorNow
                                                
                                                
                                                '@〓〓 0:更新なし 〓〓
                                                Case CMstrNowstepEditDisable
                                                    
                                                    '@既不良背景色(ﾋﾟﾝｸ)を設定
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColor
                                                
                                                
                                                '@〓〓 その他 〓〓
                                                Case Else
                                                    
                                                    '@既不良背景色(ﾋﾟﾝｸ)を設定
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColor
                                            
                                            End Select
                                            

                                        '@〓 3：払出 〓
                                        Case CPstrClass3
                                            
                                            '@★★ 現工程変更後更新ﾌﾗｸﾞにより処理分岐 ★★
                                            Select Case mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strNewNowstepEditFlag
                                                
                                                '@〓〓 1:更新あり 〓〓
                                                Case CMstrNowstepEditEnable
                                                    
                                                    '@現工程用払出背景色(ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)を設定
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColorNow
                                                
                                                
                                                '@〓〓 0:更新なし 〓〓
                                                Case CMstrNowstepEditDisable
                                                    
                                                    '@既払出背景色(薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)を設定
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColor
                                                
                                                
                                                '@〓〓 その他 〓〓
                                                Case Else
                                                    
                                                    '@既払出背景色(薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)を設定
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColor
                                            
                                            End Select
                                        
                                        
                                        '@〓 5：傾向 〓
                                        Case CPstrClass5
                                            
                                            '@★★ 現工程変更後更新ﾌﾗｸﾞにより処理分岐 ★★
                                            Select Case mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strNewNowstepEditFlag
                                                
                                                '@〓〓 1:更新あり 〓〓
                                                Case CMstrNowstepEditEnable
                                                
                                                    '@現工程用傾向背景色(山吹色)を設定
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColorNow
                                                
                                                
                                                '@〓〓 0:更新なし 〓〓
                                                Case CMstrNowstepEditDisable
                                                    
                                                    '@既傾向背景色(ﾚﾓﾝ色)を設定
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColor
                                                
                                                
                                                '@〓〓 その他 〓〓
                                                Case Else
                                                    
                                                    '@既傾向背景色(ﾚﾓﾝ色)を設定
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColor
                                            
                                            End Select


                                        '@〓 その他 〓
                                        Case Else
                                            
                                            '@背景色を白に設定
                                            cellRange.Style = newStyle_BC_EnableFalseColor
                                    
                                    End Select
                                End If
                                
                                '@処理ｵﾌﾟｼｮﾝﾎﾞﾀﾝが"電特"か
                                If optProcessKbn2.Checked = True Then
                                    
                                    '@電特ｺｰﾄﾞがNULL以外か
                                    If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strEleCode <> vbNullString Then
                                        
                                        '@ﾁｯﾌﾟの文字色を黒色に戻す
                                        
                                        '@電特ｺｰﾄﾞの表示
                                        .SetData(llngCnt2, llngCnt3, _
                                            mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strEleCode)
                                        
                                        '@電特ｸﾞﾚｰﾄﾞがNULL以外か
                                        If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strEleGrade <> vbNullString Then
                                            
                                            '@電特ｺｰﾄﾞがNULLで、かつ電特ｸﾞﾚｰﾄﾞが"1"～"9"か(良品)
                                            If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strEleCode = vbNullString And _
                                                (mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strEleGrade >= 1 And _
                                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strEleGrade <= 9) Then
                                                
                                                '@背景色を白に設定
                                                cellRange.Style = newStyle_FC_BlackColor_BC_EnableTrueColor
                                            End If
                                            
                                            '@電特ｺｰﾄﾞがNULL以外で、かつ電特ｸﾞﾚｰﾄﾞが"1"～"9"か(傾向)
                                            If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strEleCode <> vbNullString And _
                                               (mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strEleGrade >= 1 And _
                                               mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strEleGrade <= 9) Then
                                                
                                                '@現工程変更後更新ﾌﾗｸﾞが"1:更新あり"、または電特結果がNULL以外か
                                                If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strNewNowstepEditFlag = _
                                                    CMstrNowstepEditEnable Or _
                                                    mtypWFInfo(mlngWFNowIndex-1).strResult <> vbNullString Then
                                                    
                                                    '@現工程傾向色(山吹色)を設定
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColorNow
                                                Else
                                                    '@既傾向色(ﾚﾓﾝ色)を設定
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColor
                                                End If
                                            End If
                                            
                                            '@電特ｺｰﾄﾞがNULL以外で、かつ電特ｸﾞﾚｰﾄﾞが"0"か(不良)
                                            If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strEleCode <> vbNullString And _
                                               mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strEleGrade = 0 Then
                                                
                                                '@現工程変更後更新ﾌﾗｸﾞが"1:更新あり"、または電特結果がNULL以外か
                                                If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strNewNowstepEditFlag = _
                                                    CMstrNowstepEditEnable Or _
                                                    mtypWFInfo(mlngWFNowIndex-1).strResult <> vbNullString Then
                                                    
                                                    '@現工程不良色(赤ﾋﾟﾝｸ)を設定
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColorNow
                                                Else
                                                    '@既不良色(ﾋﾟﾝｸ)を設定
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColor
                                                End If
                                            End If
                                        End If
                                    Else
                                        '@背景色に白を設定
                                        cellRange.Style = newStyle_FC_ChipNoForeColor_BC_EnableTrueColor
                                    End If
                                End If
                                
                            Else
                                '@ﾁｯﾌﾟIDをｸﾘｱ
                                .SetData(llngCnt2, llngCnt3, vbNullString)
                                
                                '@背景色に灰色を設定
                                cellRange.Style = newStyle_BC_EnableFalseColor
                            End If
                        Else
                            '@使用可能区分が"False:使用不可"の場合
                        
                            '@ﾁｯﾌﾟIDをｸﾘｱ
                            .SetData(llngCnt2, llngCnt3, vbNullString)
                            
                            '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐(背景色設定) ★
                            Select Case cmdHyouri.Text
                                
                                '@〓 表へ 〓
                                Case CMstrCmdHyouriKbn1
                                    
                                    '@WFIDがNULL
                                    If (mtypWFInfo(mlngWFNowIndex-1).strWfId = vbNullString) Then
                                     
                                        '@濃い灰色(ﾁｯﾌﾟ用表表示時の概観ﾊﾞｯｸｶﾗｰ)
                                        cellRange.Style = newStyle_BC_ChipOmoteBackColor
                                    Else
                                        
                                        '@背景色に抹茶色を設定
                                        cellRange.Style = newStyle_BC_EleUraBackColor
                                    End If
                                
                                '@〓 裏へ 〓
                                Case CMstrCmdHyouriKbn2
                                                       
                                    '@機種に紐付く色指定なし、又はWFIDがNULL
                                    If ((ptypLotprestate.strColorCd = vbNullString) Or (mtypWFInfo(mlngWFNowIndex-1).strWfId = vbNullString)) Then
                                                               
                                        '@背景色に紺色を設定
                                        cellRange.Style = newStyle_BC_EleOmoteBackColor
                            
                                    Else
                                    
                                        '@背景色に機種に紐付く指定色
                                        newStyle_BC_PdBackColor.BackColor = ColorTranslator.FromWin32(CPstrAmpersand + ptypLotprestate.strColorCd)
                                        cellRange.Style = newStyle_BC_PdBackColor
                                    End If
                                    
                                    '@WFID有りの場合
                                    If ((pstrSBID = CPstrSBID2A0) And (mtypWFInfo(mlngWFNowIndex-1).strWfId <> vbNullString)) Then
                                            
                                        '@左上隅
                                        If (llngCnt2 = 1 And llngCnt3 = 1) Then
                                            
                                            '@WFID表示、白色文字
                                            .SetData(llngCnt2, llngCnt3, Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).strWfId, 3))
                                        
                                        '@右上隅
                                        ElseIf (llngCnt2 = 1 And llngCnt3 = mlngChipGridMaxCols) Then
                                                 
                                            '@WFID表示、白色文字
                                            .SetData(llngCnt2, llngCnt3, Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).strWfId, 3))
                                            
                                        '@左下隅
                                        ElseIf (llngCnt2 = mlngChipGridMaxRows And llngCnt3 = 1) Then
                                                 
                                            'WFID表示、白色文字
                                            .SetData(llngCnt2, llngCnt3, Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).strWfId, 3))
                                            
                                        '@右下隅
                                        ElseIf (llngCnt2 = mlngChipGridMaxRows And llngCnt3 = mlngChipGridMaxCols ) Then
                                                 
                                            'WFID表示、白色文字
                                            .SetData(llngCnt2, llngCnt3, Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).strWfId, 3))
                                            
                                        End If
                                    
                                    End If
                                     
                            End Select
                        End If
                    Next llngCnt3
                Next llngCnt2
            End With
            
            '@Dmﾁｯﾌﾟ番号選択配列のｸﾘｱ
            Erase mstrDmSelectChipNo
            mlngDmSelectChipNoMaxCnt = 0
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvChipMapElectric_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvChipMapWaist_Set
    '機　能：WAIST結果表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 14:24:57 T.Kitagawa
    '更新日：2016/02/08 (Mon) 22:24:33 H.Hayashi
    '備　考：
    '　　　：2004/11/29 (Mon) 10:35:29 S.Deguchi    不良保留払出の各ｸﾗｽの色設定を追加
    '　　　：2004/12/03 (Fri) 14:36:25 S.Deguchi    WF単位のﾁｯﾌﾟの良品/不良数をｾｯﾄ
    '　　　：2005/01/17 (Mon) 12:37:43 H.Wajima     変更後自工程更新ﾌﾗｸﾞの判定を追加
    '　　　：2006/05/18 (Thu) 21:26:18 N.Kojima     不良ｺｰﾄﾞ別の現工程不良数格納処理を追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2006/06/26 (Mon) 17:12:39 T.Kitagawa   DataMatrixｺｰﾄﾞ(ﾊﾞｰｺｰﾄﾞ)対応(ﾕｰｻﾞ要望№0209)
    '　　　：2008/04/30 (Wed) 13:20:33 N.Kojima     ｿｰｽ整備。(案件№02786)
    '      ：2016/02/05 (Fri) 14:15:43 H.Hayashi    GRB対応(R12-04)
    Private Sub prvChipMapWaist_Set()
        
        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt3                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngChipCol             As Integer      'ﾁｯﾌﾟ情報の列位置(表裏用判定)

        Try

            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①WFｽﾛｯﾄﾏｯﾌﾟの背景色設定
            '@　　②ﾁｯﾌﾟ情報一覧のWF行の良品、総不良、現不良、総払出、現払出の設定
            '@　　③ﾁｯﾌﾟﾏｯﾌﾟの列ﾀｲﾄﾙ設定(表:A～？、裏:Z～？)
            '@　　④WAISTｺｰﾄﾞ別、ﾁｯﾌﾟﾏｯﾌﾟの設定(ﾁｯﾌﾟ№、背景色、文字色etc...)
            '@======================================================================================


            '@-----------------------
            '@ WFｽﾛｯﾄﾏｯﾌﾟの背景色設定
            '@-----------------------
            With vsfWFMap

                '良品(白) 
                Dim newStyle_BC_EnableTrueColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor")
                newStyle_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                '@良品(白) 
                Dim newStyle_FC_vbRed_BC_EnableTrueColor As CellStyle = .Styles.Add("CustomStyle_ForColor_vbRed_BackColor_CMlngEnableTrueColor")
                newStyle_FC_vbRed_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                newStyle_FC_vbRed_BC_EnableTrueColor.ForeColor = Color.Red
                newStyle_FC_vbRed_BC_EnableTrueColor.Font = New Font(newStyle_FC_vbRed_BC_EnableTrueColor.Font, FontStyle.Bold)
                '払出(ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)
                Dim newStyle_BC_HaraidashiColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngHaraidashiColor")
                newStyle_BC_HaraidashiColor.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColor)
                '保留(薄灰色)
                Dim newStyle_BC_ReferOnlyColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngReferOnlyColor")
                newStyle_BC_ReferOnlyColor.BackColor = ColorTranslator.FromWin32(CMlngReferOnlyColor)
                '傾向(黄色)
                Dim newStyle_BC_KeikouColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngKeikouColor")
                newStyle_BC_KeikouColor.BackColor = ColorTranslator.FromWin32(CMlngKeikouColor)
                'その他(濃い灰色)
                Dim newStyle_BC_GridDarkGray As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle_BC_GridDarkGray.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)

                Dim cellRange As CellRange

                For llngCnt = 1 To CMlngvsfWFMapMaxSlotID
                    
                    '@ｽﾛｯﾄｻｲｽﾞより検索ｽﾛｯﾄ№が小さいか
                    If mstrSlotSize < CMlngvsfWFMapMaxSlotID - llngCnt + 1 Then
                    
                        '@処理なし

                    Else
                    
                        '@背景色に白を設定
                        cellRange = .GetCellRange(llngCnt, CMlngvsfWFMapID)
                        If cellRange.StyleDisplay.ForeColor = Color.Red Then
                            cellRange.Style = newStyle_FC_vbRed_BC_EnableTrueColor
                        Else
                            cellRange.Style = newStyle_BC_EnableTrueColor
                        End If
                        
                        cellRange = .GetCellRange(llngCnt, CMlngvsfWFMapID, llngCnt, CMlngvsfWFMapDestNo)

                        '@★ 区分により処理分岐 ★
                        Select Case mtypWFInfo(CMlngvsfWFMapMaxSlotID - llngCnt).strClass
                            
                            '@〓 1：良品 〓
                            Case CPstrClass1
                                
                                '@背景色に白を設定
                                If .GetCellRange(llngCnt, CMlngvsfWFMapID).StyleDisplay.ForeColor = Color.Red Then
                                    cellRange = .GetCellRange(llngCnt, CMlngvsfWFMapDestNo)
                                End If
                                cellRange.Style = newStyle_BC_EnableTrueColor
                            
                            '@〓 2：不良 〓
                            Case CPstrClass2
                            
                                '@処理なし
                            
                            '@〓 3：払出 〓
                            Case CPstrClass3

                                '@背景色にｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝを設定
                                cellRange.Style = newStyle_BC_HaraidashiColor
                            
                            '@〓 4：保留 〓
                            Case CPstrClass4
                                
                                '@背景色に薄灰色を設定
                                cellRange.Style = newStyle_BC_ReferOnlyColor
                            
                            '@〓 5：傾向 〓
                            Case CPstrClass5
                                
                                '@背景色にﾚﾓﾝ色を設定
                                cellRange.Style = newStyle_BC_KeikouColor
                            
                            '@〓 その他 〓
                            Case Else
                                
                                '@背景色に濃い灰色を設定
                                cellRange.Style = newStyle_BC_GridDarkGray
                        
                        End Select
                    End If
                Next llngCnt
            End With
            
            
            '@-----------------------
            '@ ﾁｯﾌﾟ情報一覧の数量設定
            '@-----------------------
            With vsfChipCnt

                '@-----------------------
                '@ 良品数
                '@-----------------------
                If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strWFChipQuantity) Then
                    .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strWFChipQuantity), CPstrDateFormatKanma))
                Else
                    .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strWFChipQuantity)
                End If
                    
                '@-----------------------
                '@ 総不良数
                '@-----------------------
                If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strWFChipOutQuantity) Then
                    .SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strWFChipOutQuantity), CPstrDateFormatKanma))
                Else
                    .SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strWFChipOutQuantity)
                End If

                '@-----------------------
                '@ 現不良数
                '@-----------------------
                If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentOutQuantity) Then
                    .SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentOutQuantity), CPstrDateFormatKanma))
                Else
                    .SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentOutQuantity)
                End If

                '@-----------------------
                '@ 総払出数
                '@-----------------------
                If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strWFChipForwardQuantity) Then
                    .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strWFChipForwardQuantity), CPstrDateFormatKanma))
                Else
                    .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strWFChipForwardQuantity)
                End If

                '@-----------------------
                '@ 現払出数
                '@-----------------------
                If IsNumeric(mtypWFInfo(mlngWFNowIndex-1).strWFChipForwardQuantity) Then
                    .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, Format(CInt(mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentForwardQuantity), CPstrDateFormatKanma))
                Else
                    .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentForwardQuantity)
                End If

                '@起動SBが基板か
                If pstrSBID = CPstrSBID1A0 Then
                
                    '@払出数行は"-"で表示
                    .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, CPstrMinus)
                    .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, CPstrMinus)
                    .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, CPstrMinus)
                    .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, CPstrMinus)
                End If
            End With
            
            '@-----------------------
            '@ ﾁｯﾌﾟﾏｯﾌﾟの列ﾀｲﾄﾙ変更
            '@-----------------------
            With vsfChipMap
                
                For llngCnt = 1 To mlngChipGridMaxCols
                    
                    '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐 ★
                    Select Case cmdHyouri.Text
                        
                        '@〓 表へ 〓
                        Case CMstrCmdHyouriKbn1
                            
                            '@列ﾀｲﾄﾙを"Z"⇒"A"と逆順で表示する
                            .SetData(CMlngvsfChipMapNo, llngCnt, _
                                Chr(CMlngKeyCodeA + mlngChipGridMaxCols - llngCnt))
                        
                        '@〓 裏へ 〓
                        Case CMstrCmdHyouriKbn2
                            
                            '@列ﾀｲﾄﾙを"A"から順に表示する
                            .SetData(CMlngvsfChipMapNo, llngCnt, Chr(CMlngKeyCodeA + llngCnt - 1))
                    
                    End Select
                Next llngCnt
            End With
             
            
            '@-----------------------
            '@ ﾁｯﾌﾟﾏｯﾌﾟの設定
            '@-----------------------
            With vsfChipMap

                '@背景色に白色を設定
                Dim newStyle_FC_ChipNoForeColor_BC_EnableTrueColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngChipNoForeColor_BackColor_CMlngEnableTrueColor")
                newStyle_FC_ChipNoForeColor_BC_EnableTrueColor.ForeColor = ColorTranslator.FromWin32(CMlngChipNoForeColor)
                newStyle_FC_ChipNoForeColor_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                newStyle_FC_ChipNoForeColor_BC_EnableTrueColor.TextAlign = TextAlignEnum.RightCenter
                '@文字色を黒色に戻す
                Dim newStyle_FC_BlackColor_BC_EnableTrueColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngEnableTrueColor")
                newStyle_FC_BlackColor_BC_EnableTrueColor.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                newStyle_FC_BlackColor_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                newStyle_FC_BlackColor_BC_EnableTrueColor.TextAlign = TextAlignEnum.RightCenter
                '@背景色に灰色を設定
                Dim newStyle_BC_EnableFalseColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableFalseColor")
                newStyle_BC_EnableFalseColor.ForeColor = ColorTranslator.FromWin32(CMlngChipNoForeColor)
                newStyle_BC_EnableFalseColor.BackColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                newStyle_BC_EnableFalseColor.TextAlign = TextAlignEnum.RightCenter
                '@背景色に紫色を設定
                Dim newStyle_BC_WaistUraBackColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngWaistUraBackColor")
                newStyle_BC_WaistUraBackColor.ForeColor = ColorTranslator.FromWin32(CMlngWhiteColor)
                newStyle_BC_WaistUraBackColor.BackColor = ColorTranslator.FromWin32(CMlngWaistUraBackColor)
                newStyle_BC_WaistUraBackColor.TextAlign = TextAlignEnum.RightCenter
                newStyle_BC_WaistUraBackColor.Font = New Font(newStyle_BC_WaistUraBackColor.Font.FontFamily,CMlngCornerWfNoSize, FontStyle.Regular)
                '@濃い灰色(ﾁｯﾌﾟ用表表示時の概観ﾊﾞｯｸｶﾗｰ)
                Dim newStyle_BC_ChipOmoteBackColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngChipOmoteBackColor")
                newStyle_BC_ChipOmoteBackColor.ForeColor = ColorTranslator.FromWin32(CMlngWhiteColor)
                newStyle_BC_ChipOmoteBackColor.BackColor = ColorTranslator.FromWin32(CMlngChipOmoteBackColor)
                newStyle_BC_ChipOmoteBackColor.TextAlign = TextAlignEnum.RightCenter
                newStyle_BC_ChipOmoteBackColor.Font = New Font(newStyle_BC_ChipOmoteBackColor.Font.FontFamily,CMlngCornerWfNoSize, FontStyle.Regular)
                '@背景色にﾋﾞﾘｼﾞｱﾝ(青っぽい緑)を設定
                Dim newStyle_BC_WaistOmoteBackColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngWaistOmoteBackColor")
                newStyle_BC_WaistOmoteBackColor.ForeColor = ColorTranslator.FromWin32(CMlngWhiteColor)
                newStyle_BC_WaistOmoteBackColor.BackColor = ColorTranslator.FromWin32(CMlngWaistOmoteBackColor)
                newStyle_BC_WaistOmoteBackColor.TextAlign = TextAlignEnum.RightCenter
                newStyle_BC_WaistOmoteBackColor.Font = New Font(newStyle_BC_WaistOmoteBackColor.Font.FontFamily,CMlngCornerWfNoSize, FontStyle.Regular)
                '機種設定色
                Dim newStyle_BC_PdBackColor As CellStyle = .Styles.Add("CustomStyle_BackColor_PdBackColor")
                newStyle_BC_PdBackColor.ForeColor = ColorTranslator.FromWin32(CMlngWhiteColor)
                newStyle_BC_PdBackColor.TextAlign = TextAlignEnum.RightCenter
                newStyle_BC_PdBackColor.Font = New Font(newStyle_BC_PdBackColor.Font.FontFamily,CMlngCornerWfNoSize, FontStyle.Regular)

                Dim cellRange As CellRange

                For llngCnt2 = 1 To mlngChipGridMaxRows
                    
                    For llngCnt3 = 1 To mlngChipGridMaxCols
                        
                        cellRange = .GetCellRange(llngCnt2, llngCnt3)
                        '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐(ﾁｯﾌﾟ配列の列変換) ★
                        Select Case cmdHyouri.Text
                            
                            '@〓 表へ 〓
                            Case CMstrCmdHyouriKbn1
                                
                                llngChipCol = mlngChipGridMaxCols - llngCnt3 + 1
                            
                            '@〓 裏へ 〓
                            Case CMstrCmdHyouriKbn2
                                
                                llngChipCol = llngCnt3

                        End Select
                        
                        '@使用可能区分が"True:使用可能"か
                        If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).blnEnableKbn = True Then
                            
                            '@WFIDがNULL以外で、かつﾁｯﾌﾟIDがNULL以外か
                            If mtypWFInfo(mlngWFNowIndex-1).strWfId <> vbNullString And _
                                mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strChipId <> vbNullString Then
                               
                                '@ﾁｯﾌﾟIDの文字色を灰色にする
                                
                                '@背景色に灰色を設定
                                cellRange.Style = newStyle_BC_EnableFalseColor
                                
                                '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐(ﾁｯﾌﾟIDの表示) ★
                                Select Case cmdHyouri.Text
                                    
                                    '@〓 表へ 〓
                                    Case CMstrCmdHyouriKbn1
                                        
                                        .SetData(llngCnt2, llngCnt3, _
                                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strChipId, 3))
                                    
                                    '@〓 裏へ 〓
                                    Case CMstrCmdHyouriKbn2
                                        
                                        .SetData(llngCnt2, llngCnt3, _
                                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strChipId, 3))
                                
                                End Select
                                                            
                                '@WAIST状態がNULL以外か
                                If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strWaistStatus <> vbNullString Then
                                    
                                    '@背景色に白色を設定
                                    cellRange.Style = newStyle_FC_ChipNoForeColor_BC_EnableTrueColor
                                    
                                    '@WAISTｺｰﾄﾞがNULL以外か
                                    If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strWaistCode <> vbNullString Then
                                        
                                        '@文字色を黒色に戻す
                                        cellRange.Style = newStyle_FC_BlackColor_BC_EnableTrueColor
                                        
                                        '@WAISTｺｰﾄﾞを表示
                                        .SetData(llngCnt2, llngCnt3, _
                                            mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strWaistCode)
                                    
                                    End If
                                End If
                            Else
                                '@文字消去
                                .SetData(llngCnt2, llngCnt3, vbNullString)
                                
                                '@背景色に灰色を設定
                                cellRange.Style = newStyle_BC_EnableFalseColor
                            End If
                        Else
                            '@使用可能区分が"False:使用不可"の場合
                        
                            '@文字消去
                            .SetData(llngCnt2, llngCnt3, vbNullString)
                            
                            '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐(背景色の設定) ★
                            Select Case cmdHyouri.Text
                                
                                '@〓 表へ 〓
                                Case CMstrCmdHyouriKbn1
                                    
                                    '@WFIDがNULL
                                    If (mtypWFInfo(mlngWFNowIndex-1).strWfId = vbNullString) Then

                                        '@濃い灰色(ﾁｯﾌﾟ用表表示時の概観ﾊﾞｯｸｶﾗｰ)
                                        cellRange.Style = newStyle_BC_ChipOmoteBackColor
                                    Else
                                        
                                        '@背景色に紫色を設定
                                        cellRange.Style = newStyle_BC_WaistUraBackColor
                                    End If
                                
                                '@〓 裏へ 〓
                                Case CMstrCmdHyouriKbn2
                                                               
                                    '@機種に紐付く色指定なし、又はWFIDがNULL
                                    If ((ptypLotprestate.strColorCd = vbNullString) Or (mtypWFInfo(mlngWFNowIndex-1).strWfId = vbNullString)) Then
                                                               
                                        '@背景色にﾋﾞﾘｼﾞｱﾝ(青っぽい緑)を設定
                                        cellRange.Style = newStyle_BC_WaistOmoteBackColor
                            
                                    Else
                                    
                                        '@背景色に機種に紐付く指定色
                                        newStyle_BC_PdBackColor.BackColor = ColorTranslator.FromWin32(CPstrAmpersand + ptypLotprestate.strColorCd)
                                        cellRange.Style = newStyle_BC_PdBackColor
                                    End If
                                    
                                    '@WFID有りの場合
                                    If ((pstrSBID = CPstrSBID2A0) And (mtypWFInfo(mlngWFNowIndex-1).strWfId <> vbNullString)) Then
                                            
                                        '@左上隅
                                        If (llngCnt2 = 1 And llngCnt3 = 1) Then
                                            
                                            '@WFID表示、白色文字
                                            .SetData(llngCnt2, llngCnt3, Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).strWfId, 3))
                                        
                                        '@右上隅
                                        ElseIf (llngCnt2 = 1 And llngCnt3 = mlngChipGridMaxCols) Then
                                                 
                                            '@WFID表示、白色文字
                                            .SetData(llngCnt2, llngCnt3, Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).strWfId, 3))
                                            
                                        '@左下隅
                                        ElseIf (llngCnt2 = mlngChipGridMaxRows And llngCnt3 = 1) Then
                                                 
                                            'WFID表示、白色文字
                                            .SetData(llngCnt2, llngCnt3, Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).strWfId, 3))
                                            
                                        '@右下隅
                                        ElseIf (llngCnt2 = mlngChipGridMaxRows And llngCnt3 = mlngChipGridMaxCols) Then
                                                 
                                            'WFID表示、白色文字
                                            .SetData(llngCnt2, llngCnt3, Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).strWfId, 3))

                                        End If
                                    
                                    End If
                            
                            End Select
                        End If
                    Next llngCnt3
                Next llngCnt2
            End With
            
            '@Dmﾁｯﾌﾟ番号選択配列のｸﾘｱ
            Erase mstrDmSelectChipNo
            mlngDmSelectChipNoMaxCnt = 0
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvChipMapWaist_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvChipMapGridDisplayKbn_Set
    '機　能：ﾁｯﾌﾟﾏｯﾌﾟの表示切替(全体表示⇔拡大表示)処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/29 (Mon) 11:11:53 T.Kitagawa
    '更新日：2008/04/28 (Mon) 18:34:58 N.Kojima
    '備　考：
    '　　　：2006/03/16 (Thu) 11:13:50 N.Kasai      余白追加
    '　　　：2008/04/28 (Mon) 18:34:58 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvChipMapGridDisplayKbn_Set()

        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngRowHeigth           As Integer      '1行の高さ
        Dim llngColWidth            As Integer      '1列の幅
        Dim llngCurrentRow          As Integer      'ｶﾚﾝﾄ行
        Dim llngCurrentCol          As Integer      'ｶﾚﾝﾄ列

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①全体表示/拡大表示ﾎﾞﾀﾝ押下時の列幅の再設定、ｽｸﾛｰﾙﾎﾞﾀﾝの表示制御を行なう
            '@======================================================================================


            '@-----------------------
            '@ ﾁｯﾌﾟﾏｯﾌﾟの設定
            '@-----------------------
            With vsfChipMap
                
                '@ｶﾚﾝﾄ行列がﾃﾞｰﾀｾﾙか
                If .Row > 0 And .Col > 0 Then
                    
                    '@ｶﾚﾝﾄ行列の位置退避
                    llngCurrentRow = .Row
                    llngCurrentCol = .Col
                End If
                
                '@-----------------------
                '@ 行高設定
                '@-----------------------
                '@高さｵｰﾊﾞｰ区分が"True:ｵｰﾊﾞｰ"か
                If mlblnRowHeigthOver = True Then
                    
                    '@★ 全体表示/拡大表示ﾎﾞﾀﾝの表示により処理分岐(1行当りの高さ決定) ★
                    Select Case cmdDisplayKbn.Text
                        
                        '@〓 全体表示 〓
                        Case CMstrCmdDisplayKbn1
                            
                            '@行高に最小値を設定
                            llngRowHeigth = CMlngvsfChipMapRowHeightMin
                            '@ｸﾞﾘｯﾄﾞ全体の高さを標準値へ設定
                            .Height = CMlngvsfChipMapNomalHeight
                        
                        
                        '@〓 拡大表示 〓
                        Case CMstrCmdDisplayKbn2
                            
                            '@行高に全体表示時の1行の高さを設定
                            llngRowHeigth = mlngAllDisplayRowHeigth
                            '@ｸﾞﾘｯﾄﾞ全体の高さを微調整
                            .Height = CMlngvsfChipMapTitleHeight + (llngRowHeigth * mlngChipGridMaxRows) + 2
                    
                    End Select
                    
                    '@行高の再設定
                    For llngCnt = 1 To mlngChipGridMaxRows
                        .Rows(llngCnt).Height = llngRowHeigth
                    Next llngCnt
                End If
                
                
                '@-----------------------
                '@ 列幅設定
                '@-----------------------
                '@幅ｵｰﾊﾞｰ区分が"True:ｵｰﾊﾞｰ"か
                If mlblnColWidthOver = True Then
                    
                    '@★ 全体表示/拡大表示ﾎﾞﾀﾝの表示により処理分岐(1列当りの幅決定) ★
                    Select Case cmdDisplayKbn.Text
                        
                        '@〓 全体表示 〓
                        Case CMstrCmdDisplayKbn1
                            
                            '@幅に最小値を設定
                            llngColWidth = CMlngvsfChipMapColWidthMin
                            '@ｸﾞﾘｯﾄﾞ全体の幅を標準値へ設定
                            .Width = CMlngvsfChipMapNomalWidth
                        
                        
                        '@〓 拡大表示 〓
                        Case CMstrCmdDisplayKbn2
                            
                            '@幅に全体表示時の1列の幅を設定
                            llngColWidth = mlngAllDisplayColWidth
                            '@ｸﾞﾘｯﾄﾞ全体の幅を微調整
                            .Width = CMlngvsfChipMapTitleWidth + (llngColWidth * mlngChipGridMaxCols) + 3   
                    
                    End Select
                    
                    '@列幅の再調整
                    For llngCnt2 = 1 To mlngChipGridMaxCols
                        .Cols(llngCnt2).Width = llngColWidth
                    Next llngCnt2
                End If
                
                
                '@-----------------------
                '@ ｽｸﾛｰﾙﾊﾞｰ設定
                '@-----------------------
                '@★ 全体表示/拡大表示ﾎﾞﾀﾝの表示により処理分岐(ｽｸﾛｰﾙﾊﾞｰの設定) ★
                Select Case cmdDisplayKbn.Text
                    
                    '@〓 全体表示 〓
                    Case CMstrCmdDisplayKbn1
                        
                        '@高さｵｰﾊﾞｰ区分、または幅ｵｰﾊﾞｰ区分が"True:ｵｰﾊﾞｰ"か
                        If mlblnRowHeigthOver = True Or mlblnColWidthOver = True Then
                            
                            '@ｽｸﾛｰﾙﾊﾞｰ表示ありに設定(水平、垂直両方向)
                            .ScrollBars = ScrollBars.Both
                        Else
                            '@ｽｸﾛｰﾙﾊﾞｰ表示なしに設定
                            .ScrollBars = ScrollBars.None
                        End If
                    
                    
                    '@〓 拡大表示 〓
                    Case CMstrCmdDisplayKbn2
                        
                        '@左上のｾﾙを選択する
                        vsfChipMap.TopRow = 0
                        vsfChipMap.LeftCol = 0
                        
                        '@ｽｸﾛｰﾙﾊﾞｰ表示なしに設定
                        .ScrollBars = ScrollBars.None
                
                End Select
                
                
                '@-----------------------
                '@ 変更前の選択ｾﾙにﾌｫｰｶｽを戻す
                '@-----------------------
                '@変更前行、列がﾃﾞｰﾀｾﾙだったか
                If llngCurrentRow > 0 And llngCurrentCol > 0 Then
                    
                    '@全体表示/拡大表示ﾎﾞﾀﾝの表示が"全体表示"か
                    If cmdDisplayKbn.Text = CMstrCmdDisplayKbn1 Then
                        '@変更前の行、列にｽｸﾛｰﾙする
                        .ShowCell(llngCurrentRow, llngCurrentCol)
                    End If
                    
                    '@ﾁｯﾌﾟﾏｯﾌﾟが有効か
                    If vsfChipMap.Enabled = True Then
                        '@ﾁｯﾌﾟﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfChipMap)
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvChipMapGridDisplayKbn_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvLoadingMessage_Disp
    '機　能：LOT(WF枚数分)ﾃﾞｰﾀ読込中ﾒｯｾｰｼﾞ表示処理
    '引　数：なし
    '戻り値：True：読み込みOK、False：読み込みNG
    '作成日：2006/05/22 (Mon) 16:15:54 N.Kojima
    '更新日：2008/04/28 (Mon) 14:28:59 N.Kojima
    '備　考：
    '　　　：2008/04/28 (Mon) 14:28:59 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Function prvLoadingMessage_Disp() As Boolean

        Dim llngResultOKCnt     As Integer  '確認結果OKのWF枚数
        Dim llngNowRow          As Integer  '現選択行格納用
        Dim llngCnt             As Integer  '汎用ｶｳﾝﾀ
        
        Try

            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①WF情報読み込み中ﾒｯｾｰｼﾞBOX表示
            '@======================================================================================


            '@戻り値の初期化
            prvLoadingMessage_Disp = False
            
            '@ESCでの画面終了有効
            Me.CancelButton = Nothing
            
            With vsfWFMap
            
                '@現在選択されている行を格納
                llngNowRow = .Row
            
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ ｲﾝﾌｫﾒｰｼｮﾝ画面　起動処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM00X0.Instance = New frmxxCM00X0()
            
                '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定
                frmxxCM00X0.Instance.Text = CPstrSubFormCM00X0Chip
            
                '@MsgBox(CM00X0)のFormｻｲｽﾞ、ﾗﾍﾞﾙｻｲｽﾞ変更
                frmxxCM00X0.Instance.Size = New Size(608, 147)
                frmxxCM00X0.Instance.lblInfomation1.Width = 403
                frmxxCM00X0.Instance.lblInfomation2.Width = 608
                    
                '@ｲﾝﾌｫﾒｰｼｮﾝ1("WFデータ読み込んでいます。")
                frmxxCM00X0.Instance.lblInfomation1.Text = CMstrWFDataSelMsg

                '@WF枚数分ﾙｰﾌﾟさせる
                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@ｲﾝﾌｫﾒｰｼｮﾝ2("読込対象ウェハ　XX枚中　XX枚読込完了。")
                    frmxxCM00X0.Instance.lblInfomation2.Text = CPstrReadWF & mlngWFAryCnt & _
                                                         CPstrOutOfNum & llngResultOKCnt & CPstrReadComplete
                    
                    If frmxxCM00X0.Instance.Visible = False Then
                        '@ｲﾝﾌｫﾒｰｼｮﾝ画面表示
                        frmxxCM00X0.Instance.Show()
                    Else
						frmxxCM00X0.Instance.Refresh()
                    End If

                    '@*********************************
                    '@ 擬似的にWF情報読み込みを行なう
                    '@*********************************
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngvsfWFMapID) <> vbNullString Then
                        '@WFIDがNULL以外の場合
                        
                        '@確認WF枚数
                        llngResultOKCnt = llngResultOKCnt + 1
                        
                        '@行を選択し、ﾁｯﾌﾟ情報を格納する。(※色々処理が走るので追ってみて下さい)
                        .Row = llngCnt

                        '@ｲﾝﾌｫﾒｰｼｮﾝ2("読込対象ウェハ　XX枚中　XX枚読込完了。")
                        frmxxCM00X0.Instance.lblInfomation2.Text = CPstrReadWF & mlngWFAryCnt & _
                                                             CPstrOutOfNum & llngResultOKCnt & CPstrReadComplete
                
                        vsfWFMap.Refresh()
                        txtDmCode.Refresh()
                        vsfChipCnt.Refresh()
                        vsfScpList.Refresh()
                        vsfChipMap.Refresh()

                        '@ｲﾝﾌｫﾒｰｼｮﾝﾌｫｰﾑを先行して描画する為、記述しています。
                        frmxxCM00X0.Instance.Refresh()

                    End If
                Next llngCnt
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｲﾝﾌｫﾒｰｼｮﾝ画面ｱﾝﾛｰﾄﾞ
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00X0.Instance = Nothing
            
                '@処理前の行に戻す
                .Row = llngNowRow
            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@戻り値に"True:読み込みOK"をｾｯﾄ
                prvLoadingMessage_Disp = True

            End With

            Exit Function

        Catch ex As Exception
            
            Me.CancelButton = cmdClose
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey          '機能ID
                .strProcName = "prvLoadingMessage_Disp" '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvTekiyou_Set
    '機　能：(単数ﾁｯﾌﾟ選択時用)各種適用処理
    '引　数：lstrCmdName    ：ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名
    '戻り値：なし
    '作成日：2004/04/01 (Thu) 10:29:29 T.Kitagawa
    '更新日：2009/03/31 (Tue) 14:37:53 N.Kojima
    '備　考：
    '　　　：2004/09/14 (Tue) 13:20:44 Y.Yamagishi　電特/外観/パ検結果登録対応
    '　　　：2004/12/03 (Fri) 17:03:19 S.Deguchi    WF単位の数量計算を追加
    '　　　：2005/01/17 (Mon) 12:55:54 H.Wajima     自工程更新ﾌﾗｸﾞの判定処理を追加
    '　　　：2005/01/28 (Fri) 14:34:55 H.Wajima     全取消時にﾊﾟﾀｰﾝによってﾁｯﾌﾟ枚数の計算を誤る問題を修正
    '　　　：2005/05/30 (Mon) 15:39:58 S.Deguchi    不具合№828の対応で適用取消処理修正(適用取消可能の状態を追加)
    '　　　：2005/08/05 (Fri) 10:20:16 N.Kasai      ﾁｯﾌﾟ状態の不良→良品救い上げ機能抑止(№2986)
    '　　　：2005/09/07 (Wed) 09:51:35 N.Kasai      現不良数量追加
    '　　　：2006/02/06 (Mon) 10:10:12 N.Kasai      №3387対応
    '　　　：2006/05/18 (Thu) 21:26:18 N.Kojima     ﾁｯﾌﾟ(Lot単位)の現工程不良数格納処理を追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2006/06/26 (Mon) 17:35:00 T.Kitagawa   DataMatrixｺｰﾄﾞ(ﾊﾞｰｺｰﾄﾞ)対応(ﾕｰｻﾞ要望№0209)
    '　　　：2006/09/25 (Mon) 15:25:41 T.Kitagawa   ODF欠損ﾁｯﾌﾟの場合は適用不可にする(案件№01084)
    '　　　：2008/01/29 (Tue) 09:53:30 N.Kojima     ｽﾀｯﾌ・管理端末にてPR/ESﾛｯﾄは既不良のすくい上げを禁止。(案件№02568)
    '　　　：2008/04/28 (Mon) 18:50:05 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2009/03/31 (Tue) 14:37:53 N.Kojima     ﾁｯﾌﾟ払出対応に伴い処理追加/変更。(案件№03434)
    Private Sub prvTekiyou_Set(ByVal lstrCmdName As String)

        Dim llngCnt2                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt3                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngStartRowPos         As Integer      '開始行位置
        Dim llngStartColPos         As Integer      '開始列位置
        Dim llngEndRowPos           As Integer      '終了行位置
        Dim llngEndColPos           As Integer      '終了列位置
        Dim llngChipCol             As Integer      'ﾁｯﾌﾟ情報の列位置(表裏用判定)
        Dim lstrTekiyouCode         As String       '不良ｺｰﾄﾞ
        Dim llngCalTrnControlFlag   As Integer      '計算処理実行判定用ﾌﾗｸﾞ(1:良品数 + 不良数のみ、2:現不良のみ、
                                                    '                   3:不良全て、4:良品数 + 払出数のみ、5:現払出のみ、
                                                    '                   6:払出全て、7:全て)
        Dim lcellRange              As CellRange    'NSYS 選択範囲取得

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ別、各種選択状態ﾁｪｯｸ処理
            '@　　②不良/払出適用処理(対象ﾁｯﾌﾟの不良/払出/傾向ｺｰﾄﾞの反映、背景色の設定、WF情報構造体対象ﾁｯﾌﾟﾃﾞｰﾀの更新)
            '@　　③傾向適用処理(対象ﾁｯﾌﾟの不良/払出/傾向ｺｰﾄﾞの反映、背景色の設定、WF情報構造体対象ﾁｯﾌﾟﾃﾞｰﾀの更新)
            '@　　④適用取消処理(対象ﾁｯﾌﾟの不良/払出/傾向ｺｰﾄﾞの反映、背景色の設定、WF情報構造体対象ﾁｯﾌﾟﾃﾞｰﾀの更新)
            '@　　⑤取消処理(対象ﾁｯﾌﾟの不良/払出/傾向ｺｰﾄﾞの反映、背景色の設定、WF情報構造体対象ﾁｯﾌﾟﾃﾞｰﾀの更新)
            '@　　⑥上記、各処理後のﾁｯﾌﾟ情報一覧の良品数・総不良/払出数・現工程不良/払出数の再設定処理
            '@======================================================================================


            '@Dmﾁｯﾌﾟ番号選択配列のｸﾘｱ
            Erase mstrDmSelectChipNo
            mlngDmSelectChipNoMaxCnt = 0
            
            '@WFIDがNULLか
            If mtypWFInfo(mlngWFNowIndex-1).strWfId = vbNullString Then
                '@処理終了
                Exit Sub
            End If

            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐(ﾁｯﾌﾟ範囲選択判定) ★
            Select Case lstrCmdName
                
                '@〓 不良(払出)適用ﾎﾞﾀﾝ or 傾向適用ﾎﾞﾀﾝ or 適用取消ﾎﾞﾀﾝ 〓
                Case cmdFuryouTekiyou.Name, cmdKeikouTekiyou.Name, cmdTekiyouClear.Name
                    
                    '@ﾁｯﾌﾟが選択されているか
                    If vsfChipMap.Row < 1 Or vsfChipMap.Col < 1 Then
                        '@処理終了
                        Exit Sub
                    End If

            End Select
            
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐(適用ｺｰﾄﾞの選択判定) ★
            Select Case lstrCmdName
                
                '@〓 不良(払出)適用ﾎﾞﾀﾝ or 傾向適用ﾎﾞﾀﾝ 〓
                Case cmdFuryouTekiyou.Name, cmdKeikouTekiyou.Name
                    
                    '@不良ｺｰﾄﾞが選択されているか
                    If vsfScpList.Row < 1 Then
                        '@処理終了
                        Exit Sub
                    End If

            End Select
                    
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐(適用ｺｰﾄﾞのｾｯﾄ) ★
            Select Case lstrCmdName
                
                '@〓 不良(払出)適用ﾎﾞﾀﾝ or 傾向適用ﾎﾞﾀﾝ 〓
                Case cmdFuryouTekiyou.Name, cmdKeikouTekiyou.Name
                    
                    '@不良/払出ｺｰﾄﾞ一覧にて選択しているｺｰﾄﾞを不良/払出ｺｰﾄﾞ退避用変数にｾｯﾄ
                    lstrTekiyouCode = vsfScpList.GetData(vsfScpList.Row, CMlngvsfScpListCode)
                
                '@〓 適用取消ﾎﾞﾀﾝ or 取消ﾎﾞﾀﾝ 〓
                Case cmdTekiyouClear.Name, cmdClear.Name
                    
                    '@不良/払出ｺｰﾄﾞ退避用変数にNULLをｾｯﾄ
                    lstrTekiyouCode = vbNullString

            End Select
            
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐(ﾁｯﾌﾟﾏｯﾌﾟの選択行列の設定) ★
            Select Case lstrCmdName
                
                '@〓 不良(払出)適用ﾎﾞﾀﾝ or 傾向適用 or 適用取消 〓
                Case cmdFuryouTekiyou.Name, cmdKeikouTekiyou.Name, cmdTekiyouClear.Name
                    
                    '@選択範囲を参照し、開始・終了位置を設定する
                    'vsfChipMap.GetSelection llngStartRowPos, llngStartColPos, llngEndRowPos, llngEndColPos
                    lcellRange = vsfChipMap.Selection
                    llngStartRowPos = lcellRange.r1
                    llngStartColPos = lcellRange.c1
                    llngEndRowPos = lcellRange.r2
                    llngEndColPos = lcellRange.c2
                
                '@〓 取消 〓
                Case cmdClear.Name
                    
                    '@ﾁｯﾌﾟﾏｯﾌﾟの開始・終了位置の設定する
                    llngStartRowPos = 1
                    llngStartColPos = 1
                    llngEndRowPos = mlngChipGridMaxRows
                    llngEndColPos = mlngChipGridMaxCols

            End Select

            
            '既払出背景色(薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)を設定
            Dim newStyle_FC_BlackColor_BC_HaraidashiColor As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngHaraidashiColor")
            newStyle_FC_BlackColor_BC_HaraidashiColor.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
            newStyle_FC_BlackColor_BC_HaraidashiColor.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColor)
            newStyle_FC_BlackColor_BC_HaraidashiColor.TextAlign = TextAlignEnum.RightCenter
            '現工程用払出背景色(ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)を設定
            Dim newStyle_FC_BlackColor_BC_HaraidashiColorNow As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngHaraidashiColorNow")
            newStyle_FC_BlackColor_BC_HaraidashiColorNow.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
            newStyle_FC_BlackColor_BC_HaraidashiColorNow.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColorNow)
            newStyle_FC_BlackColor_BC_HaraidashiColorNow.TextAlign = TextAlignEnum.RightCenter
            '既不良背景色(ﾋﾟﾝｸ)を設定
            Dim newStyle_FC_BlackColor_BC_FuryouColor As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngFuryouColor")
            newStyle_FC_BlackColor_BC_FuryouColor.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
            newStyle_FC_BlackColor_BC_FuryouColor.BackColor = ColorTranslator.FromWin32(CMlngFuryouColor)
            newStyle_FC_BlackColor_BC_FuryouColor.TextAlign = TextAlignEnum.RightCenter
            '現工程用不良背景色(赤ﾋﾟﾝｸ)を設定
            Dim newStyle_FC_BlackColor_BC_FuryouColorNow As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngFuryouColorNow")
            newStyle_FC_BlackColor_BC_FuryouColorNow.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
            newStyle_FC_BlackColor_BC_FuryouColorNow.BackColor = ColorTranslator.FromWin32(CMlngFuryouColorNow)
            newStyle_FC_BlackColor_BC_FuryouColorNow.TextAlign = TextAlignEnum.RightCenter
            '既傾向背景色(ﾚﾓﾝ色)を設定
            Dim newStyle_FC_BlackColor_BC_KeikouColor As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngKeikouColor")
            newStyle_FC_BlackColor_BC_KeikouColor.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
            newStyle_FC_BlackColor_BC_KeikouColor.BackColor = ColorTranslator.FromWin32(CMlngKeikouColor)
            newStyle_FC_BlackColor_BC_KeikouColor.TextAlign = TextAlignEnum.RightCenter
            '現工程用傾向背景色(山吹色)を設定
            Dim newStyle_FC_BlackColor_BC_KeikouColorNow As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngKeikouColorNow")
            newStyle_FC_BlackColor_BC_KeikouColorNow.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
            newStyle_FC_BlackColor_BC_KeikouColorNow.BackColor = ColorTranslator.FromWin32(CMlngKeikouColorNow)
            newStyle_FC_BlackColor_BC_KeikouColorNow.TextAlign = TextAlignEnum.RightCenter
            '良品背景色(白色)を設定
            Dim newStyle_FC_ChipNoForeColor_BC_EnableTrueColor As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngChipNoForeColor_BackColor_CMlngEnableTrueColor")
            newStyle_FC_ChipNoForeColor_BC_EnableTrueColor.ForeColor = ColorTranslator.FromWin32(CMlngChipNoForeColor)
            newStyle_FC_ChipNoForeColor_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
            newStyle_FC_ChipNoForeColor_BC_EnableTrueColor.TextAlign = TextAlignEnum.RightCenter
            '背景色を白に変更
            Dim newStyle_FC_ChipNoForeColor_BC_vbWhite As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngChipNoForeColor_BackColor_vbWhite")
            newStyle_FC_ChipNoForeColor_BC_vbWhite.ForeColor = ColorTranslator.FromWin32(CMlngChipNoForeColor)
            newStyle_FC_ChipNoForeColor_BC_vbWhite.BackColor = Color.White
            newStyle_FC_ChipNoForeColor_BC_vbWhite.TextAlign = TextAlignEnum.RightCenter
            'ﾁｯﾌﾟIDの文字色を灰色にする
            Dim newStyle_FC_ChipNoForeColor_BC_ReferOnlyColor As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngChipNoForeColor_BackColor_CMlngReferOnlyColor")
            newStyle_FC_ChipNoForeColor_BC_ReferOnlyColor.ForeColor = ColorTranslator.FromWin32(CMlngChipNoForeColor)
            newStyle_FC_ChipNoForeColor_BC_ReferOnlyColor.BackColor = ColorTranslator.FromWin32(CMlngReferOnlyColor)
            newStyle_FC_ChipNoForeColor_BC_ReferOnlyColor.TextAlign = TextAlignEnum.RightCenter

            Dim cellRange As CellRange
            
            '@-----------------------------------------
            '@ ﾁｯﾌﾟ情報配列の更新及び、ﾁｯﾌﾟﾏｯﾌﾟの設定
            '@-----------------------------------------
            '@上記で設定したﾁｯﾌﾟﾏｯﾌﾟ開始～終了分ﾙｰﾌﾟする
            For llngCnt2 = llngStartRowPos To llngEndRowPos
                
                '@列も同様
                For llngCnt3 = llngStartColPos To llngEndColPos
                    
                    '@ﾁｯﾌﾟ情報の列位置(表裏用判定)の設定
                    llngChipCol = 0
                    
                    '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐(ﾁｯﾌﾟ配列の列変換) ★
                    Select Case cmdHyouri.Text
                    
                        '@〓 表へ 〓
                        Case CMstrCmdHyouriKbn1
                        
                            llngChipCol = mlngChipGridMaxCols - llngCnt3 + 1
                        
                        '@〓 裏へ 〓
                        Case CMstrCmdHyouriKbn2

                            llngChipCol = llngCnt3

                    End Select
                    
                    cellRange = vsfChipMap.GetCellRange(llngCnt2, llngCnt3)
                    '@-----------------------
                    '@ ﾁｯﾌﾟ情報配列の更新
                    '@-----------------------
                    With mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1)
                        
                        '@ﾁｯﾌﾟが存在する場合で、かつ欠損ﾁｯﾌﾟIDでないか
                        If .strChipId <> vbNullString And .blnLostChipKbn = False Then
                            
                            '@----------------------------------------------------------
                            '@下記の何れかの条件に該当するか
                            '@　①貼り合せ状態ﾌﾗｸﾞが"0:未完"
                            '@　②現工程変更前区分が"2:不良"以外、"3:払出"以外
                            '@　③現工程で不良/払出にしたﾁｯﾌﾟに対して不良/払出/傾向処理を行った場合
                            '@----------------------------------------------------------
                            If ptypLotprestate.strCoverFlag = 0 _
                                Or .strOldClass <> CPstrClass2 _
                                Or .strOldClass <> CPstrClass3 _
                                Or (.strNewClass = CPstrClass2 And .strNewNowstepEditFlag = CMstrNowstepEditEnable) _
                                Or (.strNewClass = CPstrClass3 And .strNewNowstepEditFlag = CMstrNowstepEditEnable) _
                                Or (.strNewClass = CPstrClass5 And .strNewNowstepEditFlag = CMstrNowstepEditEnable) Then
                                

                                '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
                                Select Case lstrCmdName
                                    
                                    '@〓 不良(払出)適用ﾎﾞﾀﾝ 〓
                                    Case cmdFuryouTekiyou.Name
                                        
                                        '@現工程変更後区分が"1:良品、または"5:傾向"か
                                        If .strNewClass = CPstrClass1 Or .strNewClass = CPstrClass5 Then
                                                
                                            '@選択ｺｰﾄﾞが"払出ｺｰﾄﾞ"か
                                            If lstrTekiyouCode = CPstrForwardCode Then
                                                '@払出ｺｰﾄﾞの場合

                                                '@現工程変更後区分、現工程変更後区分ID、現工程変更後自工程更新ﾌﾗｸﾞの設定
                                                .strNewClass = CPstrClass3                          '3:払出
                                                .strNewClassID = lstrTekiyouCode                    '払出ｺｰﾄﾞ
                                                .strNewNowstepEditFlag = CMstrNowstepEditEnable     '自工程更新あり
                                                
                                                '@ﾁｯﾌﾟﾏｯﾌﾟの対象ﾁｯﾌﾟに払出ｺｰﾄﾞを設定し、背景色をｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝに設定
                                                vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColorNow
                                                
                                                '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                    
                                                    '@計算処理指示ﾌﾗｸﾞに"6:払出全て"をｾｯﾄ
                                                    llngCalTrnControlFlag = CPlngNumSix
                                                Else
                                                    '@計算処理指示ﾌﾗｸﾞに"4:良品数 + 既払出数のみ"をｾｯﾄ
                                                    llngCalTrnControlFlag = CPlngNumFour
                                                End If
                                                
                                                '@==================================================================
                                                '@ ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                '@　⇒　計算指示"3:払出数加算"、計算処理指示は上記で設定した値で処理Call
                                                '@==================================================================
                                                Call prvVsfChipCntDataSet_Proc(CPlngNumThree, llngCalTrnControlFlag)

                                        
                                                '@-------------------------------------------------
                                                '@以下の条件か
                                                '@　①起動区分が"M:工程端末"
                                                '@　②現工程変更前区分が"3:払出"
                                                '@　③現工程変更前自工程更新ﾌﾗｸﾞが"0:自工程更新なし"
                                                '@-------------------------------------------------
                                                If pstrTerminalMode = CPstrManufactureStatus _
                                                    And .strOldClass = CPstrClass3 _
                                                    And .strOldNowstepEditFlag = CMstrNowstepEditDisable Then
                                                    
                                                    '@-------------------------------------------------
                                                    '@　上記の状態のﾁｯﾌﾟは状態を良い方向へ変更不可!!
                                                    '@-------------------------------------------------
                                                Else
                                                    '@起動区分が"M:工程端末"以外、または現工程変更前区分が"3:払出"以外、
                                                    '@または現工程変更前自工程更新ﾌﾗｸﾞが"0:自工程更新なし"以外の場合
                                                
                                                    '@現工程変更後区分が"3:払出"か
                                                    If .strNewClass = CPstrClass3 Then
                                                    
                                                        .strNewClass = CPstrClass3                          '3：払出
                                                        .strNewClassID = lstrTekiyouCode                    '払出ｺｰﾄﾞ
                                                        .strNewNowstepEditFlag = CMstrNowstepEditEnable     '1:自工程更新あり
                                                        
                                                        '@文字色を黒色にする
                                                        
                                                        '@ﾁｯﾌﾟﾏｯﾌﾟの設定(払出ｺｰﾄﾞの反映、背景色をｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝに変更)
                                                        vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                        cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColorNow
                                                    End If
                                                End If
                                            Else
                                                '@"払出ｺｰﾄﾞ"以外=不良ｺｰﾄﾞの場合
                                                
                                                '@現工程変更後区分、現工程変更後区分ID、現工程変更後自工程更新ﾌﾗｸﾞの設定
                                                .strNewClass = CPstrClass2                          '2:不良
                                                .strNewClassID = lstrTekiyouCode                    '不良ｺｰﾄﾞ
                                                .strNewNowstepEditFlag = CMstrNowstepEditEnable     '自工程更新あり
                                                
                                                '@ﾁｯﾌﾟﾏｯﾌﾟの対象ﾁｯﾌﾟに不良ｺｰﾄﾞを設定し、背景色を赤ﾋﾟﾝｸに設定
                                                vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColor
                                                
                                                '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                    
                                                    '@計算処理指示ﾌﾗｸﾞに"3:不良全て"をｾｯﾄ
                                                    llngCalTrnControlFlag = CPlngNumThree
                                                Else
                                                    '@現工程での不良適用がない場合
                                                
                                                    '@計算処理指示ﾌﾗｸﾞに"1:良品数 + 既不良数のみ"をｾｯﾄ
                                                    llngCalTrnControlFlag = CPlngNumOne
                                                End If
                                                
                                                '@==================================================================
                                                '@ ﾁｯﾌﾟ情報一覧の良品数・不良数・現工程不良数の設定処理
                                                '@　⇒　計算指示"1:不良数加算"、計算処理指示は上記で設定した値で処理Call
                                                '@==================================================================
                                                Call prvVsfChipCntDataSet_Proc(CPlngNumOne, llngCalTrnControlFlag)
                                            
                                                '@-------------------------------------------------
                                                '@以下の条件か
                                                '@　①起動区分が"M:工程端末"
                                                '@　②現工程変更前区分が"2:不良"
                                                '@　③現工程変更前自工程更新ﾌﾗｸﾞが"0:自工程更新なし"
                                                '@-------------------------------------------------
                                                If pstrTerminalMode = CPstrManufactureStatus _
                                                    And .strOldClass = CPstrClass2 _
                                                    And .strOldNowstepEditFlag = CMstrNowstepEditDisable Then
                                                    
                                                    '@-------------------------------------------------
                                                    '@　上記の状態のﾁｯﾌﾟは状態を良い方向へ変更不可!!
                                                    '@-------------------------------------------------
                                                Else
                                                    '@起動区分が"M:工程端末"以外、または現工程変更前区分が"2:不良"以外、
                                                    '@または現工程変更前自工程更新ﾌﾗｸﾞが"0:自工程更新なし"以外の場合
                                                
                                                    '@現工程変更後区分が"2:不良"か
                                                    If .strNewClass = CPstrClass2 Then
                                                    
                                                        .strNewClass = CPstrClass2                          '不良
                                                        .strNewClassID = lstrTekiyouCode                    '不良ｺｰﾄﾞ
                                                        .strNewNowstepEditFlag = CMstrNowstepEditEnable     '1:自工程更新あり
                                                        
                                                        '@文字色を黒色にする
                                                        
                                                        '@ﾁｯﾌﾟﾏｯﾌﾟの設定(不良ｺｰﾄﾞの反映、背景色を赤ﾋﾟﾝｸに変更)
                                                        vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                        cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColorNow
                                                    End If
                                                End If
                                            End If
                                        End If

                                        
                                        '@-------------------------------------------------
                                        '@以下の条件か
                                        '@　①起動区分が"M:工程端末"
                                        '@　②現工程変更前区分が"2:不良"
                                        '@　③現工程変更前自工程更新ﾌﾗｸﾞが"0:自工程更新なし"
                                        '@-------------------------------------------------
                                        If pstrTerminalMode = CPstrManufactureStatus _
                                            And .strOldClass = CPstrClass2 _
                                            And .strOldNowstepEditFlag = CMstrNowstepEditDisable Then

                                            '@-------------------------------------------------
                                            '@　上記の状態のﾁｯﾌﾟは状態を良い方向へ変更不可!!
                                            '@-------------------------------------------------
                                        Else
                                            '@起動区分が"M:工程端末"以外、または現工程変更前区分が"2:不良"以外、
                                            '@または現工程変更前自工程更新ﾌﾗｸﾞが"0:自工程更新なし"以外の場合

        '                                    '@現工程変更後区分が"2:不良"か
        '                                    If .strNewClass = CPstrClass2 Then

                                            '@現工程変更後区分が"2:不良"、かつ選択ｺｰﾄﾞが"払出ｺｰﾄﾞ"以外か
                                            '@　※払出ﾁｯﾌﾟの上書きは禁止
                                            If .strNewClass = CPstrClass2 And _
                                                lstrTekiyouCode <> CPstrForwardCode Then

                                                .strNewClass = CPstrClass2                          '不良
                                                .strNewClassID = lstrTekiyouCode                    '不良ｺｰﾄﾞ
                                                .strNewNowstepEditFlag = CMstrNowstepEditEnable     '1:自工程更新あり

                                                '@文字色を黒色にする

                                                '@ﾁｯﾌﾟﾏｯﾌﾟの設定(不良ｺｰﾄﾞの反映、背景色を赤ﾋﾟﾝｸに変更)
                                                vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColorNow
                                            
                                            End If
                                        End If

                                        
                                    '@〓 傾向適用ﾎﾞﾀﾝ 〓
                                    Case cmdKeikouTekiyou.Name
                                                              
                                        '@-------------------------------------------------
                                        '@以下の条件か
                                        '@　①起動区分が"M:工程端末"
                                        '@　②現工程変更前区分が"2:不良"or"3:払出"
                                        '@　③現工程変更前自工程更新ﾌﾗｸﾞが"0:自工程更新なし"
                                        '@-------------------------------------------------
                                        If pstrTerminalMode = CPstrManufactureStatus _
                                            And (.strOldClass = CPstrClass2 Or .strOldClass = CPstrClass3) _
                                            And .strOldNowstepEditFlag = CMstrNowstepEditDisable Then
                                            
                                            '@--------------------------------------------------
                                            '@　上記の状態のﾁｯﾌﾟは状態を良い方向へ変更不可!!
                                            '@--------------------------------------------------
                                        Else
                                            '@起動区分が"M:工程端末"以外、または現工程変更前区分が"2:不良"以外、
                                            '@または現工程変更前自工程更新ﾌﾗｸﾞが"0:自工程更新なし"以外の場合

                                            '@現工程変更後区分が"1:良品"、"2:不良"、または"3:払出"か
                                            If .strNewClass = CPstrClass1 Or .strNewClass = CPstrClass2 Or .strNewClass = CPstrClass3 Then
                                                
                                                '@ﾛｯﾄがPR/ES以外、または現工程変更前自工程更新ﾌﾗｸﾞが"自工程更新あり"か
                                                If mstrLotFlowClass <> CPstrOne Or _
                                                    .strOldNowstepEditFlag = CMstrNowstepEditEnable Then

                                                    '@★★ 現工程変更後区分により処理分岐 ★★
                                                    Select Case .strNewClass
                                                        
                                                        '@〓〓 2：不良 〓〓
                                                        Case CPstrClass2
                                                            
                                                            '@==================================================================
                                                            '@ ﾁｯﾌﾟ情報一覧の良品数・不良数・現不良数の設定処理
                                                            '@　⇒　計算指示"2:不良数減算"、計算処理指示"3:不良全て"で処理Call
                                                            '@==================================================================
                                                            Call prvVsfChipCntDataSet_Proc(CPlngNumTwo, CPlngNumThree)
                                                        
                                                        '@〓〓 3：払出 〓〓
                                                        Case CPstrClass3
                                                            
                                                            '@==================================================================
                                                            '@ ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                            '@　⇒　計算指示"4:払出数減算"、計算処理指示"6:払出全て"で処理Call
                                                            '@==================================================================
                                                            Call prvVsfChipCntDataSet_Proc(CPlngNumFour, CPlngNumSix)
                                                    
                                                    End Select
                                                    
                                                    '@文字色を黒色にする

                                                    .strNewClass = CPstrClass5                          '傾向
                                                    .strNewClassID = lstrTekiyouCode                    '傾向ｺｰﾄﾞ
                                                    .strNewNowstepEditFlag = CMstrNowstepEditEnable     '1:自工程更新あり
                                                    
                                                    '@ﾁｯﾌﾟﾏｯﾌﾟの設定(傾向ｺｰﾄﾞの反映、背景色を山吹色に変更)
                                                    vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColor
                                                End If
                                            End If
                                            
                                            '@現工程変更後区分が"5:傾向"か
                                            If .strNewClass = CPstrClass5 Then
                                                
                                                .strNewClass = CPstrClass5                          '傾向
                                                .strNewClassID = lstrTekiyouCode                    '傾向ｺｰﾄﾞ
                                                .strNewNowstepEditFlag = CMstrNowstepEditEnable     '1:自工程更新あり
                                                
                                                '@ﾁｯﾌﾟﾏｯﾌﾟの設定(傾向ｺｰﾄﾞの反映、背景色を黄色に変更)
                                                vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColorNow
                                            End If
                                        End If
                                    
                                    
                                    '@〓 適用取消ﾎﾞﾀﾝ 〓
                                    Case cmdTekiyouClear.Name
                                    
                                        '@-------------------------------------------------
                                        '@以下の条件か(入力後の状態を参照)
                                        '@　①起動区分が"M:工程端末"
                                        '@　②現工程変更後区分が"1:良品"以外
                                        '@　③現工程変更後自工程更新ﾌﾗｸﾞが"0:自工程更新なし"
                                        '@-------------------------------------------------
                                        If pstrTerminalMode = CPstrManufactureStatus _
                                            And .strNewClass <> CPstrClass1 _
                                            And .strNewNowstepEditFlag = CMstrNowstepEditDisable Then
                                            
                                            '@--------------------------------------------------
                                            '@　上記の状態のﾁｯﾌﾟは状態を良い方向へ変更不可!!
                                            '@--------------------------------------------------
                                        Else
                                            '@起動区分が"M:工程端末"以外、または現工程変更後区分が"1:良品"、
                                            '@または現工程変更後自工程更新ﾌﾗｸﾞが"0:自工程更新なし"以外の場合
                                        
                                            '@-------------------------------------------------
                                            '@以下の条件か(入力前の状態を参照)
                                            '@　①起動区分が"M:工程端末"
                                            '@　②現工程変更前区分が"1:良品"以外
                                            '@　③現工程変更前自工程更新ﾌﾗｸﾞが"0:自工程更新なし"
                                            '@-------------------------------------------------
                                            If pstrTerminalMode = CPstrManufactureStatus _
                                                And .strOldNowstepEditFlag = CMstrNowstepEditDisable _
                                                And .strOldClass <> CPstrClass1 Then

                                                '@--------------------------------------------------
                                                '@ ①現工程での良品⇒不良・払出へ変更したﾁｯﾌﾟの適用取消
                                                '@ ②現工程or前工程で傾向へ変更したﾁｯﾌﾟの適用取消
                                                '@--------------------------------------------------
                                                '@★★ 下記条件でTrueになる条件で処理分岐 ★★
                                                Select Case True
                                                    
                                                    '@〓〓 現工程変更後区分が"2:不良"かつ現工程変更前区分が"5:傾向" 〓〓
                                                    Case .strNewClass = CPstrClass2 And .strOldClass = CPstrClass5
                                                        
                                                        '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                        If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                            
                                                            '@計算処理指示ﾌﾗｸﾞに"3:不良全て"をｾｯﾄ
                                                            llngCalTrnControlFlag = CPlngNumThree
                                                        Else
                                                            '@計算処理指示ﾌﾗｸﾞに"1:良品数 + 既不良数のみ"をｾｯﾄ
                                                            llngCalTrnControlFlag = CPlngNumOne
                                                        End If
                                                        
                                                        '@==================================================================
                                                        '@ ﾁｯﾌﾟ情報一覧の良品数・不良数・現工程不良数の設定処理
                                                        '@　⇒　計算指示"2:不良数減算"、計算処理指示は上記で設定した値で処理Call
                                                        '@==================================================================
                                                        Call prvVsfChipCntDataSet_Proc(CPlngNumTwo, llngCalTrnControlFlag)
                                                    
                                                    
                                                    '@〓〓 現工程変更後区分が"3:払出"かつ現工程変更前区分が"5:傾向" 〓〓
                                                    Case .strNewClass = CPstrClass3 And .strOldClass = CPstrClass5
                                                        
                                                        '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                        If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                            
                                                            '@計算処理指示ﾌﾗｸﾞに"6:払出全て"をｾｯﾄ
                                                            llngCalTrnControlFlag = CPlngNumSix
                                                        Else
                                                            '@計算処理指示ﾌﾗｸﾞに"4:良品数 + 既払出数のみ"をｾｯﾄ
                                                            llngCalTrnControlFlag = CPlngNumFour
                                                        End If
                                                        
                                                        '@==================================================================
                                                        '@　ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                        '@　　⇒　計算指示"4:払出数減算"、計算処理指示は上記で設定した値で処理Call
                                                        '@==================================================================
                                                        Call prvVsfChipCntDataSet_Proc(CPlngNumFour, llngCalTrnControlFlag)

                                                End Select
                                                
                                                '@文字色を黒色にする

                                                .strNewClass = .strOldClass                         '現工程変更前区分
                                                .strNewClassID = .strOldClassID                     '現工程変更前区分ｺｰﾄﾞ
                                                .strNewNowstepEditFlag = .strOldNowstepEditFlag     '現工程変更前自工程更新ﾌﾗｸﾞ
                                                
                                                '@ﾁｯﾌﾟﾏｯﾌﾟの設定(現工程変更前区分の反映、現工程変更前区分に従い背景色を戻す)
                                                vsfChipMap.SetData(llngCnt2, llngCnt3, .strOldClassID)
                                                
                                                '@★★ 現工程変更後区分により処理分岐 ★★
                                                Select Case .strNewClass
                                                    
                                                    '@〓〓 2：不良 〓〓
                                                    Case CPstrClass2
                                                        
                                                        cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColor
                                                    

                                                    '@〓〓 3：払出 〓〓
                                                    Case CPstrClass3
                                                        
                                                        cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColor

                                                
                                                    '@〓〓 5：傾向 〓〓
                                                    Case CPstrClass5
                                                        
                                                        cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColor
                                                
                                                End Select
                                            Else
                                                '@起動区分が"M:工程端末"以外、または現工程変更前区分が"1:良品"、
                                                '@または現工程変更前自工程更新ﾌﾗｸﾞが"0:自工程更新なし"以外の場合
                                            
                                                '@-----------------------------------------------------------------------
                                                '@以下の条件の何れかに該当するか
                                                '@　①起動区分"M:工程端末"、かつ前工程最新区分ID"良品"以外
                                                '@ 　※前工程で傾向を現工程で傾向、または不良(払出)とした場合、傾向取消で良品にしてはNG
                                                '@ 　　以前に設定した内容に置き換えする。
                                                '@　②PR/ESﾛｯﾄ、かつ前工程最新区分ID"不良or払出or傾向"
                                                '@　③自工程更新あり、かつ前工程最新区分ID"不良or払出or傾向"
                                                '@-----------------------------------------------------------------------
                                                If (pstrTerminalMode = CPstrManufactureStatus _
                                                    And .strBefoerClassID <> vbNullString) _
                                                    Or (mstrLotFlowClass = CPstrOne And .strBefoerClassID <> vbNullString) _
                                                    Or (.strBefoerClassID <> vbNullString And .strOldNowstepEditFlag = CMstrNowstepEditEnable) Then

                                                    '@★★ 下記条件でTrueになる条件で処理分岐 ★★
                                                    Select Case True
                                                    
                                                        '@〓〓 現工程変更後区分が"2:不良"かつ前工程最新区分が"5:傾向" 〓〓
                                                        Case .strNewClass = CPstrClass2 And .strBefoerClass = CPstrClass5
                                                            
                                                            '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                            If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                                
                                                                '@計算処理指示ﾌﾗｸﾞに"3:不良全て"をｾｯﾄ
                                                                llngCalTrnControlFlag = CPlngNumThree
                                                            Else
                                                                '@計算処理指示ﾌﾗｸﾞに"1:良品数 + 既不良数のみ"をｾｯﾄ
                                                                llngCalTrnControlFlag = CPlngNumOne
                                                            End If
                                                            
                                                            '@==================================================================
                                                            '@ ﾁｯﾌﾟ情報一覧の良品数・不良数・現不良数の設定処理
                                                            '@　⇒　計算指示"2:不良数減算"、計算処理指示は上記で設定した値で処理Call
                                                            '@==================================================================
                                                            Call prvVsfChipCntDataSet_Proc(CPlngNumTwo, llngCalTrnControlFlag)
                                                        
                                                        
                                                        '@〓〓 現工程変更後区分が"3:払出"かつ前工程最新区分が"5:傾向" 〓〓
                                                        Case .strNewClass = CPstrClass3 And .strBefoerClass = CPstrClass5
                                                            
                                                            '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                            If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                                
                                                                '@計算処理指示ﾌﾗｸﾞに"6:払出全て"をｾｯﾄ
                                                                llngCalTrnControlFlag = CPlngNumSix
                                                            Else
                                                                '@計算処理指示ﾌﾗｸﾞに"1:良品数 + 既払出数のみ"をｾｯﾄ
                                                                llngCalTrnControlFlag = CPlngNumFour
                                                            End If
                                                            
                                                            '@==================================================================
                                                            '@ ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                            '@　⇒　計算指示"4:払出数減算"、計算処理指示は上記で設定した値で処理Call
                                                            '@==================================================================
                                                            Call prvVsfChipCntDataSet_Proc(CPlngNumFour, llngCalTrnControlFlag)
                                                        
                                                    End Select
                                                    
                                                    '@--------------------------------------------------------------------------------------
                                                    '@良品の適用取消で前工程まで"不良or払出"の場合(№03387、03434)
                                                    '@　①ｽﾀｯﾌ端末のﾁｯﾌﾟ状態変更登録で既不良/払出(前工程以前の不良/払出)を適用取消で良品にして登録
                                                    '@　②工程端末のﾁｯﾌﾟ状態変更で該当良品ﾁｯﾌﾟを適用取消する
                                                    '@　既不良/払出に戻るが良品/総不良(払出)/現不良(払出)数が変わらない(既存ﾊﾞｸﾞ)
                                                    '@　　※②で該当良品ﾁｯﾌﾟを傾向にし適用取消を行っても同様にﾁｯﾌﾟ数が変わりません｡
                                                    '@　　　(確定後、ｷｬﾘｱIDを入力し直すと正しいﾁｯﾌﾟ数が表示されます。)
                                                    '@---------------------------------------------------------------------------------------
                                                    '@★★ 下記条件でTrueになる条件で処理分岐 ★★
                                                    Select Case True
                        
                                                        '@〓〓 現工程変更後区分が"1:良品"、または"5:傾向"で、かつ前工程区分が"2:不良" 〓〓
                                                        Case (.strNewClass = CPstrClass1 Or .strNewClass = CPstrClass5) And .strBefoerClass = CPstrClass2
                                                        
                                                            '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                            If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                                
                                                                '@計算処理指示ﾌﾗｸﾞに"3:不良全て"をｾｯﾄ
                                                                llngCalTrnControlFlag = CPlngNumThree
                                                            Else
                                                                '@計算処理指示ﾌﾗｸﾞに"1:良品数 + 既不良数のみ"をｾｯﾄ
                                                                llngCalTrnControlFlag = CPlngNumOne
                                                            End If
                                                            
                                                            '@==================================================================
                                                            '@　ﾁｯﾌﾟ情報一覧の良品数・不良数・現不良数の設定処理
                                                            '@　　⇒　計算指示"1:不良数加算"、計算処理指示は上記で設定した値で処理Call
                                                            '@==================================================================
                                                            Call prvVsfChipCntDataSet_Proc(CPlngNumOne, llngCalTrnControlFlag)
                                                        
            
                                                        '@〓〓 現工程変更後区分が"1:良品"、または"5:傾向"で、かつ前工程区分が"3:払出" 〓〓
                                                        Case (.strNewClass = CPstrClass1 Or .strNewClass = CPstrClass5) And .strBefoerClass = CPstrClass3
                                                        
                                                            '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                            If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                                
                                                                '@計算処理指示ﾌﾗｸﾞに"6:払出全て"をｾｯﾄ
                                                                llngCalTrnControlFlag = CPlngNumSix
                                                            Else
                                                                '@計算処理指示ﾌﾗｸﾞに"4:良品数 + 既払出数のみ"をｾｯﾄ
                                                                llngCalTrnControlFlag = CPlngNumFour
                                                            End If
                                                            
                                                            '@==================================================================
                                                            '@　ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                            '@　　⇒　計算指示"3:払出数加算"、計算処理指示は上記で設定した値で処理Call
                                                            '@==================================================================
                                                            Call prvVsfChipCntDataSet_Proc(CPlngNumThree, llngCalTrnControlFlag)
                                                    
                                                    End Select

                                                                   
                                                    '@文字色を黒色にする
                    
                                                    '@前工程最新区分に置き換え(戻し)
                                                    .strNewClass = .strBefoerClass
                                                    .strNewClassID = .strBefoerClassID
                                                    
                                                    '@現工程変更後自工程更新ﾌﾗｸﾞに"1:自工程更新あり"をｾｯﾄ(表裏ﾎﾞﾀﾝ切替で取消前の情報が残る為)
                                                    .strNewNowstepEditFlag = CMstrNowstepEditEnable

                                                    '@ﾁｯﾌﾟﾏｯﾌﾟの設定(前工程最新区分の反映、前工程最新区分に従い背景色を戻す)
                                                    vsfChipMap.SetData(llngCnt2, llngCnt3, .strBefoerClassID)
                                                    
                                                    '@★★ 現工程変更後区分により処理分岐 ★★
                                                    Select Case .strBefoerClass
                                                        
                                                        '@〓〓 2：不良 〓〓
                                                        Case CPstrClass2
                                                            
                                                            cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColor
                                                        

                                                        '@〓〓 3：払出 〓〓
                                                        Case CPstrClass3
                                                            
                                                            cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColor

                                                        
                                                        '@〓〓 5：傾向 〓〓
                                                        Case CPstrClass5
                                                            
                                                            cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColor
                                                    
                                                    End Select
                                                    
                                                Else
                                                    '@起動区分"M:工程端末"以外、または"PR/ESﾛｯﾄ"以外、または"自工程更新なし"
                                                    '@または前工程最新区分が"良品"の場合

                                                    '@現工程変更後区分が"2:不良"、"3：払出"、または"5:傾向"か
                                                    If .strNewClass = CPstrClass2 Or .strNewClass = CPstrClass3 Or .strNewClass = CPstrClass5 Then
                                                        
                                                        '@ﾛｯﾄが"1:PR/ES"以外、または"1:自工程更新あり"か
                                                        If mstrLotFlowClass <> CPstrOne Or _
                                                            .strOldNowstepEditFlag = CMstrNowstepEditEnable Then
                                                            
                                                            '@★★ 現工程変更後区分により処理分岐 ★★
                                                            Select Case .strNewClass
                                                            
                                                                '@〓〓 2：不良 〓〓
                                                                Case CPstrClass2
                                                                    
                                                                    '@==================================================================
                                                                    '@　ﾁｯﾌﾟ情報一覧の良品数・不良数・現不良数の設定処理
                                                                    '@　　⇒　計算指示"2:不良数減算"、計算処理指示は"3:不良全て"で処理Call
                                                                    '@==================================================================
                                                                    Call prvVsfChipCntDataSet_Proc(CPlngNumTwo, CPlngNumThree)
                                                                
                                                                
                                                                '@〓〓 3：払出 〓〓
                                                                Case CPstrClass3
                                                                    
                                                                    '@==================================================================
                                                                    '@　ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                                    '@　　⇒　計算指示"4:払出数減算"、計算処理指示は"3:払出全て"で処理Call
                                                                    '@==================================================================
                                                                    Call prvVsfChipCntDataSet_Proc(CPlngNumFour, CPlngNumSix)
            
                                                            End Select

                                                                
                                                            '@現工程変更後区分、ID、更新ﾌﾗｸﾞの設定
                                                            .strNewClass = CPstrClass1                          '良品
                                                            .strNewClassID = lstrTekiyouCode                    '区分ｺｰﾄﾞ
                                                            .strNewNowstepEditFlag = CMstrNowstepEditDisable    '0:自工程更新なし
                                                            
                                                            '@ﾁｯﾌﾟﾏｯﾌﾟの設定(区分の反映、背景色を白に設定)
                                                            vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                            
                                                            With vsfChipMap
                                                            
                                                                '@ﾁｯﾌﾟIDの文字色を灰色にする
                                                                cellRange.Style = newStyle_FC_ChipNoForeColor_BC_EnableTrueColor
                                                                
                                                                '@★★ 表/裏ﾎﾞﾀﾝの表示により処理分岐 ★★
                                                                Select Case cmdHyouri.Text
                                                                
                                                                    '@〓〓 表へ 〓〓
                                                                    Case CMstrCmdHyouriKbn1
                                                                        
                                                                        .SetData(llngCnt2, llngCnt3, _
                                                                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strChipId, 3))
                                                                    
                                                                    '@〓〓 裏へ 〓〓
                                                                    Case CMstrCmdHyouriKbn2
                                                                        
                                                                        .SetData(llngCnt2, llngCnt3, _
                                                                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strChipId, 3))
                                                                
                                                                End Select
                                                            End With
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                        
                                        '@対象ﾁｯﾌﾟの背景色が水色か
                                        If vsfChipMap.GetCellRange(llngCnt2, llngCnt3).StyleDisplay.BackColor = ColorTranslator.FromWin32(CMlngCandidacyBackColor) Then
                                            
                                            '@背景色を白に変更
                                            cellRange.Style = newStyle_FC_ChipNoForeColor_BC_vbWhite
                                        End If
                                    
                                    
                                    '@〓 取消ﾎﾞﾀﾝ 〓
                                    Case cmdClear.Name
                                        
                                        '@----------------------------------------------------------------
                                        '@以下の条件の何れかに該当するか
                                        '@　①現工程の変更前区分と変更後区分が異なる
                                        '@　②現工程の変更前区分IDと変更後区分IDが異なる
                                        '@　③現工程変更前自工程更新ﾌﾗｸﾞと現工程変更後自工程更新ﾌﾗｸﾞが異なる
                                        '@----------------------------------------------------------------
                                        If .strNewClass <> .strOldClass _
                                            Or .strNewClassID <> .strOldClassID _
                                            Or .strNewNowstepEditFlag <> .strOldNowstepEditFlag Then
                                            
                                            '@★★ Case文がTrueになるかにより処理分岐 ★★
                                            Select Case True
                                                
                                                '@〓〓 ①良品→不良、②傾向→不良に変更されたﾁｯﾌﾟの取消(良品または傾向に戻す) 〓〓
                                                Case .strOldClass = CPstrClass1 And .strNewClass = CPstrClass2, _
                                                    .strOldClass = CPstrClass5 And .strNewClass = CPstrClass2

                                                    '@==================================================================
                                                    '@ ﾁｯﾌﾟ情報一覧の良品数・不良数・現不良数の設定処理
                                                    '@　⇒　計算指示"2:不良数減算"、計算処理指示は"3:不良全て"で処理Call
                                                    '@==================================================================
                                                    Call prvVsfChipCntDataSet_Proc(CPlngNumTwo, CPlngNumThree)
                                                
                                                
                                                '@〓〓 ①不良→良品、②不良→傾向に変更されたﾁｯﾌﾟの取消(不良に戻す) 〓〓
                                                Case .strOldClass = CPstrClass2 And .strNewClass = CPstrClass1, _
                                                    .strOldClass = CPstrClass2 And .strNewClass = CPstrClass5
                                                    
                                                    '@==================================================================
                                                    '@ ﾁｯﾌﾟ情報一覧の良品数・不良数・現不良数の設定処理
                                                    '@　⇒　計算指示"1:不良数加算"、計算処理指示は"3:不良全て"で処理Call
                                                    '@==================================================================
                                                    Call prvVsfChipCntDataSet_Proc(CPlngNumOne, CPlngNumThree)
                                                

                                                '@〓〓 ①良品→払出、②傾向→払出に変更されたﾁｯﾌﾟの取消(良品または傾向に戻す) 〓〓
                                                Case .strOldClass = CPstrClass1 And .strNewClass = CPstrClass3, _
                                                    .strOldClass = CPstrClass5 And .strNewClass = CPstrClass3

                                                    '@==================================================================
                                                    '@ ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                    '@　⇒　計算指示"4:払出数減算"、計算処理指示は"6:払出全て"で処理Call
                                                    '@==================================================================
                                                    Call prvVsfChipCntDataSet_Proc(CPlngNumFour, CPlngNumSix)
                                                
                                                
                                                '@〓〓 ①払出→良品、②払出→傾向に変更されたﾁｯﾌﾟの取消(払出に戻す) 〓〓
                                                Case .strOldClass = CPstrClass3 And .strNewClass = CPstrClass1, _
                                                    .strOldClass = CPstrClass3 And .strNewClass = CPstrClass5
                                                    
                                                    '@==================================================================
                                                    '@　ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                    '@　　⇒　計算指示"3:払出数加算"、計算処理指示は"6:払出全て"で処理Call
                                                    '@==================================================================
                                                    Call prvVsfChipCntDataSet_Proc(CPlngNumThree, CPlngNumSix)
                                                

                                                '@〓〓 その他 〓〓
                                                Case Else
                                                    
                                                    '@ｺｰﾄﾞのみの変更の場合は、数量の増減はないのでﾁｯﾌﾟ情報一覧の変更処理は無し
                                                    
                                            End Select
                                            
                                            '@前工程最新区分、前工程最新ID、現工程変更後更新ﾌﾗｸﾞの設定
                                            .strNewClass = .strOldClass
                                            .strNewClassID = .strOldClassID
                                            .strNewNowstepEditFlag = .strOldNowstepEditFlag
                                            
                                            '@ﾁｯﾌﾟﾏｯﾌﾟの設定(区分の反映、背景色を白に設定)
                                            vsfChipMap.SetData(llngCnt2, llngCnt3, .strNewClassID)
                                            
                                            '@★★ 現工程変更後区分により処理分岐 ★★
                                            Select Case .strNewClass
                                                
                                                '@〓〓 1：良品 〓〓
                                                Case CPstrClass1
                                                    
                                                    cellRange.Style = newStyle_FC_ChipNoForeColor_BC_EnableTrueColor
                                                
                                                '@〓〓 2：不良 〓〓
                                                Case CPstrClass2
                                                    
                                                    '@★★★ 現工程変更後更新ﾌﾗｸﾞにより処理分岐 ★★★
                                                    Select Case .strNewNowstepEditFlag
                                                        
                                                        '@〓〓〓 1:自工程更新あり 〓〓〓
                                                        Case CMstrNowstepEditEnable
                                                            
                                                            '@現工程用不良背景色(赤ﾋﾟﾝｸ)を設定
                                                            cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColorNow
                                                        
                                                        '@〓〓〓 0:自工程更新なし 〓〓〓
                                                        Case CMstrNowstepEditDisable
                                                            
                                                            '@既不良背景色(ﾋﾟﾝｸ)を設定
                                                            cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColor
                                                        
                                                        '@〓〓〓 その他 〓〓〓
                                                        Case Else
                                                            
                                                            '@既不良背景色(ﾋﾟﾝｸ)を設定
                                                            cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColor
                                                    
                                                    End Select
                                                    

                                                '@〓〓 3：払出 〓〓
                                                Case CPstrClass3
                                                    
                                                    '@★★★ 現工程変更後更新ﾌﾗｸﾞにより処理分岐 ★★★
                                                    Select Case .strNewNowstepEditFlag
                                                        
                                                        '@〓〓〓 1:自工程更新あり 〓〓〓
                                                        Case CMstrNowstepEditEnable
                                                            
                                                            '@現工程用払出背景色(ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)を設定
                                                            cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColorNow
                                                        
                                                        '@〓〓〓 0:自工程更新なし 〓〓〓
                                                        Case CMstrNowstepEditDisable
                                                            
                                                            '@既払出背景色(薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)を設定
                                                            cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColor
                                                        
                                                        '@〓〓〓 その他 〓〓〓
                                                        Case Else
                                                            
                                                            '@既払出背景色(薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)を設定
                                                            cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColor
                                                    
                                                    End Select
                                                
                                                
                                                '@〓〓 5：傾向 〓〓
                                                Case CPstrClass5
                                                    
                                                    '@★★★ 現工程変更後更新ﾌﾗｸﾞにより処理分岐 ★★★
                                                    Select Case .strNewNowstepEditFlag
                                                        
                                                        '@〓〓〓 1:自工程更新あり 〓〓〓
                                                        Case CMstrNowstepEditEnable
                                                            
                                                            '@現工程用傾向背景色(山吹色)を設定
                                                            cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColorNow
                                                        
                                                        '@〓〓〓 0:自工程更新なし 〓〓〓
                                                        Case CMstrNowstepEditDisable
                                                            
                                                            '@既傾向背景色(ﾚﾓﾝ色)を設定
                                                            cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColor
                                                        
                                                        '@〓〓〓 その他 〓〓〓
                                                        Case Else
                                                            
                                                            '@既傾向背景色(ﾚﾓﾝ色)を設定
                                                            cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColor
                                                    
                                                    End Select
                                                
                                                
                                                '@〓〓 その他 〓〓
                                                Case Else
                                                    
                                                    '@良品背景色(白色)を設定
                                                    cellRange.Style = newStyle_FC_ChipNoForeColor_BC_EnableTrueColor
                                            
                                            End Select
                                        End If
                                        
                                        '@文字色を黒色にする
                                        
                                        '@現工程変更前区分が"5:傾向"以外、"2:不良"以外、"3：払出"以外か
        '                                If .strOldClass <> CPstrClass5 And .strOldClass <> CPstrClass2 Then
                                        If .strOldClass <> CPstrClass5 And _
                                            .strOldClass <> CPstrClass2 And _
                                            .strOldClass <> CPstrClass3 Then
                                            
                                            With vsfChipMap
                                                
                                                '@ﾁｯﾌﾟIDの文字色を灰色にする
                                                If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strOldClass = CPstrClass1 Then
                                                    cellRange.Style = newStyle_FC_ChipNoForeColor_BC_EnableTrueColor
                                                Else
                                                    cellRange.Style = newStyle_FC_ChipNoForeColor_BC_ReferOnlyColor
                                                End If
                                                
                                                '@ﾁｯﾌﾟIDを設定する
                                                .SetData(llngCnt2, llngCnt3, Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strChipId, 3))
                                            End With
                                        End If

                                End Select
                                
                            End If
                        End If
                    End With
                Next llngCnt3
            Next llngCnt2

            '@入力ﾁｪｯｸ区分に"2:入力済み"を設定する
            mtypWFInfo(mlngWFNowIndex-1).strInputCheckKbn = CMstrstrInputCheckKbn2
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvTekiyou_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvPluralTekiyou_Set
    '機　能：(複数ﾁｯﾌﾟ選択時用)各種適用処理
    '引　数：lstrCmdName：ｺﾏﾝﾄﾞﾎﾞﾀﾝ名
    '戻り値：なし
    '作成日：2006/01/24 (Tue) 13:03:07 N.Kasai
    '更新日：2009/03/31 (Tue) 10:55:44 N.Kojima
    '備　考：複数選択専用
    '　　　：次回ﾁｯﾌﾟの改修を行う不幸な方へのﾒｯｾｰｼﾞ
    '　　　：prvPluralTekiyou_SetはprvTekiyou_Setをｺﾋﾟｰして作成しています。こればﾕｰｻﾞｰ要望で複数選択時の動作で要件が完結しないまま
    '　　　：ﾘﾘｰｽを行う為です。よって次回の改修で変更が簡単にすむよう外出しにしてあります。要件確定後、統合してください。
    '　　　：2006/02/06 (Mon) 10:12:08 N.Kasai      №3387対応
    '　　　：2006/05/18 (Thu) 21:26:18 N.Kojima     ﾁｯﾌﾟ(Lot単位)の現工程不良数格納処理を追加。(ﾕｰｻﾞｰ要望№0185)
    '　　　：2006/09/25 (Mon) 16:23:44 T.Kitagawa   ODF欠損ﾁｯﾌﾟの場合は適用不可にする(案件№01084)
    '　　　：2008/01/29 (Tue) 10:06:42 N.Kojima     ｽﾀｯﾌ・管理端末にてPR/ESﾛｯﾄは既不良のすくい上げを禁止。(案件№02568)
    '　　　：2008/04/30 (Wed) 14:55:15 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2009/03/31 (Tue) 14:37:53 N.Kojima     ﾁｯﾌﾟ払出対応に伴い処理追加/変更。(案件№03434)
    Private Sub prvPluralTekiyou_Set(ByVal lstrCmdName As String)

        Dim llngCnt2                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt3                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngStartRowPos         As Integer      '開始行位置
        Dim llngStartColPos         As Integer      '開始列位置
        Dim llngEndRowPos           As Integer      '終了行位置
        Dim llngEndColPos           As Integer      '終了列位置
        Dim llngChipCol             As Integer      'ﾁｯﾌﾟ情報の列位置(表裏用判定)
        Dim lstrTekiyouCode         As String       '不良ｺｰﾄﾞ
        Dim llngCalTrnControlFlag   As Integer      '計算処理実行判定用(1:良品数+不良数のみ、2:現不良のみ、3:全て)

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ別、各種選択状態ﾁｪｯｸ処理
            '@　　②不良/払出適用処理(対象ﾁｯﾌﾟの不良/払出/傾向ｺｰﾄﾞの反映、背景色の設定、WF情報構造体対象ﾁｯﾌﾟﾃﾞｰﾀの更新)
            '@　　③傾向適用処理(対象ﾁｯﾌﾟの不良/払出/傾向ｺｰﾄﾞの反映、背景色の設定、WF情報構造体対象ﾁｯﾌﾟﾃﾞｰﾀの更新)
            '@　　④適用取消処理(対象ﾁｯﾌﾟの不良/払出/傾向ｺｰﾄﾞの反映、背景色の設定、WF情報構造体対象ﾁｯﾌﾟﾃﾞｰﾀの更新)
            '@　　⑤取消処理(対象ﾁｯﾌﾟの不良/払出/傾向ｺｰﾄﾞの反映、背景色の設定、WF情報構造体対象ﾁｯﾌﾟﾃﾞｰﾀの更新)
            '@　　⑥上記、各処理後のﾁｯﾌﾟ情報一覧の良品数・総不良/払出数・現工程不良/払出数の再設定処理
            '@======================================================================================


            '@WFIDがNULLか
            If mtypWFInfo(mlngWFNowIndex-1).strWfId = vbNullString Then
                Exit Sub
            End If

            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐(ﾁｯﾌﾟ範囲選択判定) ★
            Select Case lstrCmdName
            
                '@〓 不良(払出)適用ﾎﾞﾀﾝ or 傾向適用ﾎﾞﾀﾝ or 適用取消ﾎﾞﾀﾝ 〓
                Case cmdFuryouTekiyou.Name, cmdKeikouTekiyou.Name, cmdTekiyouClear.Name
                
                    '@ﾁｯﾌﾟﾏｯﾌﾟにて、ﾁｯﾌﾟが選択されているか
                    If vsfChipMap.Row < 1 Or vsfChipMap.Col < 1 Then
                        Exit Sub
                    End If

            End Select
            
            
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐(適用ｺｰﾄﾞの選択判定) ★
            Select Case lstrCmdName
            
                '@〓 不良(払出)適用ﾎﾞﾀﾝ or 傾向適用ﾎﾞﾀﾝ 〓
                Case cmdFuryouTekiyou.Name, cmdKeikouTekiyou.Name
                
                    '@不良/払出ｺｰﾄﾞ一覧にて、ｺｰﾄﾞが選択されているか
                    If vsfScpList.Row < 1 Then
                        Exit Sub
                    End If

            End Select
                    
                    
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐(適用ｺｰﾄﾞのｾｯﾄ) ★
            Select Case lstrCmdName
                
                '@〓 不良(払出)適用ﾎﾞﾀﾝ or 傾向適用ﾎﾞﾀﾝ 〓
                Case cmdFuryouTekiyou.Name, cmdKeikouTekiyou.Name
                    
                    '@選択している適用ｺｰﾄﾞをｾｯﾄ
                    lstrTekiyouCode = vsfScpList.GetData(vsfScpList.Row, CMlngvsfScpListCode)
                
                '@〓 適用取消ﾎﾞﾀﾝ or 取消ﾎﾞﾀﾝ 〓
                Case cmdTekiyouClear.Name, cmdClear.Name
                    
                    '@NULLをｾｯﾄ
                    lstrTekiyouCode = vbNullString

            End Select
               
               
            '@ﾁｯﾌﾟﾏｯﾌﾟの開始/終了位置の設定する
            llngStartRowPos = 1
            llngStartColPos = 1
            llngEndRowPos = mlngChipGridMaxRows
            llngEndColPos = mlngChipGridMaxCols
            
            '既払出背景色(薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)を設定
            Dim newStyle_FC_BlackColor_BC_HaraidashiColor As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngHaraidashiColor")
            newStyle_FC_BlackColor_BC_HaraidashiColor.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
            newStyle_FC_BlackColor_BC_HaraidashiColor.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColor)
            newStyle_FC_BlackColor_BC_HaraidashiColor.TextAlign = TextAlignEnum.RightCenter
            '現工程用払出背景色(ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)を設定
            Dim newStyle_FC_BlackColor_BC_HaraidashiColorNow As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngHaraidashiColorNow")
            newStyle_FC_BlackColor_BC_HaraidashiColorNow.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
            newStyle_FC_BlackColor_BC_HaraidashiColorNow.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColorNow)
            newStyle_FC_BlackColor_BC_HaraidashiColorNow.TextAlign = TextAlignEnum.RightCenter
            '既不良背景色(ﾋﾟﾝｸ)を設定
            Dim newStyle_FC_BlackColor_BC_FuryouColor As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngFuryouColor")
            newStyle_FC_BlackColor_BC_FuryouColor.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
            newStyle_FC_BlackColor_BC_FuryouColor.BackColor = ColorTranslator.FromWin32(CMlngFuryouColor)
            newStyle_FC_BlackColor_BC_FuryouColor.TextAlign = TextAlignEnum.RightCenter
            '現工程用不良背景色(赤ﾋﾟﾝｸ)を設定
            Dim newStyle_FC_BlackColor_BC_FuryouColorNow As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngFuryouColorNow")
            newStyle_FC_BlackColor_BC_FuryouColorNow.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
            newStyle_FC_BlackColor_BC_FuryouColorNow.BackColor = ColorTranslator.FromWin32(CMlngFuryouColorNow)
            newStyle_FC_BlackColor_BC_FuryouColorNow.TextAlign = TextAlignEnum.RightCenter
            '既傾向背景色(ﾚﾓﾝ色)を設定
            Dim newStyle_FC_BlackColor_BC_KeikouColor As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngKeikouColor")
            newStyle_FC_BlackColor_BC_KeikouColor.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
            newStyle_FC_BlackColor_BC_KeikouColor.BackColor = ColorTranslator.FromWin32(CMlngKeikouColor)
            newStyle_FC_BlackColor_BC_KeikouColor.TextAlign = TextAlignEnum.RightCenter
            '現工程用傾向背景色(山吹色)を設定
            Dim newStyle_FC_BlackColor_BC_KeikouColorNow As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngBlackColor_BackColor_CMlngKeikouColorNow")
            newStyle_FC_BlackColor_BC_KeikouColorNow.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
            newStyle_FC_BlackColor_BC_KeikouColorNow.BackColor = ColorTranslator.FromWin32(CMlngKeikouColorNow)
            newStyle_FC_BlackColor_BC_KeikouColorNow.TextAlign = TextAlignEnum.RightCenter
            '良品背景色(白色)を設定
            Dim newStyle_FC_ChipNoForeColor_BC_EnableTrueColor As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngChipNoForeColor_BackColor_CMlngEnableTrueColor")
            newStyle_FC_ChipNoForeColor_BC_EnableTrueColor.ForeColor = ColorTranslator.FromWin32(CMlngChipNoForeColor)
            newStyle_FC_ChipNoForeColor_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
            newStyle_FC_ChipNoForeColor_BC_EnableTrueColor.TextAlign = TextAlignEnum.RightCenter
            'ﾁｯﾌﾟIDの文字色を灰色にする
            Dim newStyle_FC_ChipNoForeColor_BC_vbWhite As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngChipNoForeColor_BackColor_vbWhite")
            newStyle_FC_ChipNoForeColor_BC_vbWhite.ForeColor = ColorTranslator.FromWin32(CMlngChipNoForeColor)
            newStyle_FC_ChipNoForeColor_BC_vbWhite.BackColor = Color.White
            newStyle_FC_ChipNoForeColor_BC_vbWhite.TextAlign = TextAlignEnum.RightCenter
            'ﾁｯﾌﾟIDの文字色を灰色にする
            Dim newStyle_FC_ChipNoForeColor_BC_ReferOnlyColor As CellStyle = vsfChipMap.Styles.Add("CustomStyle_ForeColor_CMlngChipNoForeColor_BackColor_CMlngReferOnlyColor")
            newStyle_FC_ChipNoForeColor_BC_ReferOnlyColor.ForeColor = ColorTranslator.FromWin32(CMlngChipNoForeColor)
            newStyle_FC_ChipNoForeColor_BC_ReferOnlyColor.BackColor = ColorTranslator.FromWin32(CMlngReferOnlyColor)
            newStyle_FC_ChipNoForeColor_BC_ReferOnlyColor.TextAlign = TextAlignEnum.RightCenter

            Dim cellRange As CellRange
            '@-----------------------
            '@ ﾁｯﾌﾟ情報配列の更新及び、ﾁｯﾌﾟﾏｯﾌﾟ設定
            '@-----------------------
            For llngCnt2 = llngStartRowPos To llngEndRowPos
                
                For llngCnt3 = llngStartColPos To llngEndColPos
                    
                    '@ﾁｯﾌﾟの背景色が水色か
                    If vsfChipMap.GetCellRange(llngCnt2, llngCnt3).StyleDisplay.BackColor = ColorTranslator.FromWin32(CMlngCandidacyBackColor) Then
                    
                        '@ﾁｯﾌﾟ情報の列位置(表裏用判定)の設定
                        llngChipCol = 0
                        
                        '@★ 表/裏ﾎﾞﾀﾝの表示により処理分岐(表裏によりﾁｯﾌﾟ配列の検索ｷｰを変更) ★
                        Select Case cmdHyouri.Text
                            
                            '@〓 表へ 〓
                            Case CMstrCmdHyouriKbn1
                            
                                llngChipCol = mlngChipGridMaxCols - llngCnt3 + 1
                            
                            '@〓 裏へ 〓
                            Case CMstrCmdHyouriKbn2
                            
                                llngChipCol = llngCnt3

                        End Select
                        
                        cellRange = vsfChipMap.GetCellRange(llngCnt2, llngCnt3)
                        '@ﾁｯﾌﾟ情報配列の更新
                        With mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1)
                            
                            '@ﾁｯﾌﾟIDがNULL以外で、かつ欠損ﾁｯﾌﾟIDでないか
                            If .strChipId <> vbNullString And .blnLostChipKbn = False Then
                                
                                '@-----------------------------------------------------
                                '@以下の条件の何れかに該当するか
                                '@　①貼り合せﾌﾗｸﾞが"0:貼り合せ未完"
                                '@　②現工程変更前区分が"2:不良"以外、"3:払出"以外
                                '@　③現工程で不良/払出にし、かつ自工程更新ﾌﾗｸﾞが"1:更新あり"
                                '@　④現工程で傾向にし、かつ自工程更新ﾌﾗｸﾞが"1:更新あり"
                                '@-----------------------------------------------------
                                If ptypLotprestate.strCoverFlag = 0 _
                                    Or .strOldClass <> CPstrClass2 _
                                    Or .strOldClass <> CPstrClass3 _
                                    Or (.strNewClass = CPstrClass2 And .strNewNowstepEditFlag = CMstrNowstepEditEnable) _
                                    Or (.strNewClass = CPstrClass3 And .strNewNowstepEditFlag = CMstrNowstepEditEnable) _
                                    Or (.strNewClass = CPstrClass5 And .strNewNowstepEditFlag = CMstrNowstepEditEnable) Then
                                    '@上記の条件の何れかに該当した場合
                                    
                                    '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
                                    Select Case lstrCmdName
                                        
                                        '@〓 不良(払出)適用ﾎﾞﾀﾝ 〓
                                        Case cmdFuryouTekiyou.Name
                                        
                                            '@現工程変更後区分が"1:良品"、または"5:傾向"か
                                            If .strNewClass = CPstrClass1 Or .strNewClass = CPstrClass5 Then
                                                
                                                '@選択ｺｰﾄﾞが"払出ｺｰﾄﾞ"か
                                                If lstrTekiyouCode = CPstrForwardCode Then
                                                    '@払出ｺｰﾄﾞの場合
                                                    
                                                    '@現工程変更後区分、現工程変更後区分ID、現工程変更後更新ﾌﾗｸﾞの設定
                                                    .strNewClass = CPstrClass3                          '3:払出
                                                    .strNewClassID = lstrTekiyouCode                    '払出ｺｰﾄﾞ
                                                    .strNewNowstepEditFlag = CMstrNowstepEditEnable     '1:更新あり
                                                    
                                                    '@ﾁｯﾌﾟﾏｯﾌﾟの設定(払出ｺｰﾄﾞの反映、背景色を薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝに変更)
                                                    vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColor
                                                    
                                                    '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                    If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                        
                                                        '@計算処理指示ﾌﾗｸﾞに"6:払出全て"をｾｯﾄ
                                                        llngCalTrnControlFlag = CPlngNumSix
                                                    Else
                                                        '@計算処理指示ﾌﾗｸﾞに"4:良品数 + 既払出数のみ"をｾｯﾄ
                                                        llngCalTrnControlFlag = CPlngNumFour
                                                    End If
                                                    
                                                    '@==================================================================
                                                    '@　ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                    '@　　⇒　計算指示"3:払出数加算"、計算処理指示は上記設定値で処理Call
                                                    '@==================================================================
                                                    Call prvVsfChipCntDataSet_Proc(CPlngNumThree, llngCalTrnControlFlag)
                                                    
                                                    '@現工程変更後区分、現工程変更後区分ID、現工程変更後更新ﾌﾗｸﾞの設定
                                                    .strNewClass = CPstrClass3                          '3:払出
                                                    .strNewClassID = lstrTekiyouCode                    '払出ｺｰﾄﾞ
                                                    .strNewNowstepEditFlag = CMstrNowstepEditEnable     '1:更新あり
                                                    
                                                    '@文字色を黒色にする
                    
                                                    '@ﾁｯﾌﾟﾏｯﾌﾟの設定(払出ｺｰﾄﾞの反映、背景色をｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝに変更)
                                                    vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColorNow
                                                
                                                Else
                                                    '@"払出ｺｰﾄﾞ"以外=不良ｺｰﾄﾞの場合
                                                
                                                    '@現工程変更後区分、現工程変更後区分ID、現工程変更後更新ﾌﾗｸﾞの設定
                                                    .strNewClass = CPstrClass2                          '不良
                                                    .strNewClassID = lstrTekiyouCode                    'ｺｰﾄﾞ
                                                    .strNewNowstepEditFlag = CMstrNowstepEditEnable     '1:更新あり
                                                    
                                                    '@ﾁｯﾌﾟﾏｯﾌﾟの設定(不良ｺｰﾄﾞの反映、背景色をﾋﾟﾝｸに変更)
                                                    vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColor
                                                    
                                                    '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                    If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                        
                                                        '@計算処理指示ﾌﾗｸﾞに"3:不良全て"をｾｯﾄ
                                                        llngCalTrnControlFlag = CPlngNumThree
                                                    Else
                                                        '@計算処理指示ﾌﾗｸﾞに"1:良品数 + 既不良数のみ"をｾｯﾄ
                                                        llngCalTrnControlFlag = CPlngNumOne
                                                    End If
                                                    
                                                    '@==================================================================
                                                    '@ ﾁｯﾌﾟ情報一覧の良品数・不良数・現不良数の設定処理
                                                    '@　⇒　計算指示"1:不良数加算"、計算処理指示は上記設定値で処理Call
                                                    '@==================================================================
                                                    Call prvVsfChipCntDataSet_Proc(CPlngNumOne, llngCalTrnControlFlag)
                                                
                                                    '@現工程変更後区分、現工程変更後区分ID、現工程変更後更新ﾌﾗｸﾞの設定
                                                    .strNewClass = CPstrClass2                          '不良
                                                    .strNewClassID = lstrTekiyouCode                    'ｺｰﾄﾞ
                                                    .strNewNowstepEditFlag = CMstrNowstepEditEnable     '1:更新あり
                                                    
                                                    '@文字色を黒色にする
                    
                                                    '@ﾁｯﾌﾟﾏｯﾌﾟの設定(不良ｺｰﾄﾞの反映、背景色を赤ﾋﾟﾝｸに変更)
                                                    vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColorNow

                                                End If
                                            End If

                                            '@現工程変更後区分が"2:不良"、かつ選択ｺｰﾄﾞが"払出ｺｰﾄﾞ"以外か
                                            '@　※払出ﾁｯﾌﾟの上書きは禁止
                                            If .strNewClass = CPstrClass2 And _
                                                lstrTekiyouCode <> CPstrForwardCode Then

                                                '@現工程変更後区分、現工程変更後区分ID、現工程変更後更新ﾌﾗｸﾞの設定
                                                .strNewClass = CPstrClass2                          '不良
                                                .strNewClassID = lstrTekiyouCode                    'ｺｰﾄﾞ
                                                .strNewNowstepEditFlag = CMstrNowstepEditEnable     '1:更新あり

                                                '@文字色を黒色にする

                                                '@ﾁｯﾌﾟﾏｯﾌﾟの設定(不良ｺｰﾄﾞの反映、背景色を赤ﾋﾟﾝｸに変更)
                                                vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColorNow
                                            End If
                                        
                                        
                                        '@〓 傾向適用ﾎﾞﾀﾝ 〓
                                        Case cmdKeikouTekiyou.Name
                                                                  
                                            '@-------------------------------------------------
                                            '@以下の条件か
                                            '@　①起動区分が"M:工程端末"
                                            '@　②現工程変更前区分が"2:不良"、または"3:払出"
                                            '@　③現工程変更前自工程更新ﾌﾗｸﾞが"0:自工程更新なし"
                                            '@-------------------------------------------------
                                            If pstrTerminalMode = CPstrManufactureStatus _
                                                And (.strOldClass = CPstrClass2 Or .strOldClass = CPstrClass3) _
                                                And .strOldNowstepEditFlag = CMstrNowstepEditDisable Then
                                                
                                                '@--------------------------------------------------
                                                '@ 上記の状態のﾁｯﾌﾟは状態を良い方向へ変更不可!!
                                                '@--------------------------------------------------
                                            Else
                                                '@起動区分が"M:工程端末"以外、または現工程変更前区分が"2:不良"以外、
                                                '@または現工程変更前自工程更新ﾌﾗｸﾞが"0:自工程更新なし"以外の場合
            
                                                '@現工程変更後区分が"1:良品"、"2:不良"or"3:払出"か
                                                If .strNewClass = CPstrClass1 Or .strNewClass = CPstrClass2 Or .strNewClass = CPstrClass3 Then
                                                    
                                                    '@ﾛｯﾄが"1:PR/ES"以外、または現工程変更前更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                    If mstrLotFlowClass <> CPstrOne Or _
                                                        .strOldNowstepEditFlag = CMstrNowstepEditEnable Then

                                                        '@★★ 現工程変更後区分により処理分岐 ★★
                                                        Select Case .strNewClass
                                                            
                                                            '@〓〓 2：不良 〓〓
                                                            Case CPstrClass2
                                                                
                                                                '@==================================================================
                                                                '@ ﾁｯﾌﾟ情報一覧の良品数・不良数・現不良数の設定処理
                                                                '@　⇒　計算指示"2:不良数減算"、計算処理指示"3:不良全て"で処理Call
                                                                '@==================================================================
                                                                Call prvVsfChipCntDataSet_Proc(CPlngNumTwo, CPlngNumThree)
                                                            
                                                            
                                                            '@〓〓 3：払出 〓〓
                                                            Case CPstrClass3
                                                                
                                                                '@==================================================================
                                                                '@ ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                                '@　⇒　計算指示"4:払出数減算"、計算処理指示"6:払出全て"で処理Call
                                                                '@==================================================================
                                                                Call prvVsfChipCntDataSet_Proc(CPlngNumFour, CPlngNumSix)
                                                        
                                                        End Select

                                                        
                                                        '@文字色を黒色にする
                                                        
                                                        '@現工程変更後区分、現工程変更後区分ID、現工程変更後更新ﾌﾗｸﾞの設定
                                                        .strNewClass = CPstrClass5                          '傾向
                                                        .strNewClassID = lstrTekiyouCode                    '傾向ｺｰﾄﾞ
                                                        .strNewNowstepEditFlag = CMstrNowstepEditEnable     '1:自工程更新あり
                                                        
                                                        '@ﾁｯﾌﾟﾏｯﾌﾟの設定(傾向ｺｰﾄﾞの反映、背景色をﾚﾓﾝ色に変更)
                                                        vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                        cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColor
                                                    End If
                                                End If
                                                
                                                '@現工程変更後区分が"5:傾向"か
                                                If .strNewClass = CPstrClass5 Then
                                                    
                                                    '@現工程変更後区分、現工程変更後区分ID、現工程変更後更新ﾌﾗｸﾞの設定
                                                    .strNewClass = CPstrClass5                          '傾向
                                                    .strNewClassID = lstrTekiyouCode                    '傾向ｺｰﾄﾞ
                                                    .strNewNowstepEditFlag = CMstrNowstepEditEnable     '1:自工程更新あり
                                                    
                                                    '@ﾁｯﾌﾟﾏｯﾌﾟの設定(傾向ｺｰﾄﾞの反映、背景色を山吹色に変更)
                                                    vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                    cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColorNow
                                                End If
                                            End If
                                        
                                        
                                        '@〓 適用取消ﾎﾞﾀﾝ 〓
                                        Case cmdTekiyouClear.Name
                                            
                                            '@-------------------------------------------------
                                            '@以下の条件か(入力後の状態を参照)
                                            '@　①起動区分が"M:工程端末"
                                            '@　②現工程変更後区分が"1:良品"以外
                                            '@　③現工程変更後自工程更新ﾌﾗｸﾞが"0:自工程更新なし"
                                            '@-------------------------------------------------
                                            If pstrTerminalMode = CPstrManufactureStatus _
                                                And .strNewClass <> CPstrClass1 _
                                                And .strNewNowstepEditFlag = CMstrNowstepEditDisable Then
            
                                                '@--------------------------------------------------
                                                '@ 上記の状態のﾁｯﾌﾟは状態を良い方向へ変更不可!!
                                                '@--------------------------------------------------
                                            Else
                                                '@起動区分が"M:工程端末"以外、または現工程変更後区分が"1:良品"、
                                                '@または現工程変更後自工程更新ﾌﾗｸﾞが"0:自工程更新なし"以外の場合
                                            
                                                '@-------------------------------------------------
                                                '@以下の条件か(入力前の状態を参照)
                                                '@　①起動区分が"M:工程端末"
                                                '@　②現工程変更前区分が"1:良品"以外
                                                '@　③現工程変更前自工程更新ﾌﾗｸﾞが"0:自工程更新なし"
                                                '@-------------------------------------------------
                                                If pstrTerminalMode = CPstrManufactureStatus _
                                                    And .strOldNowstepEditFlag = CMstrNowstepEditDisable _
                                                    And .strOldClass <> CPstrClass1 Then
                                                    
                                                    '@--------------------------------------------------
                                                    '@ ①現工程での良品⇒不良へ変更したﾁｯﾌﾟの適用取消
                                                    '@ ②現工程での良品⇒払出へ変更したﾁｯﾌﾟの適用取消
                                                    '@ ③現工程or前工程で傾向へ変更したﾁｯﾌﾟの適用取消
                                                    '@--------------------------------------------------
                                                    
                                                    '@★★ 下記条件がTrueになるかにより処理分岐 ★★
                                                    Select Case True

                                                        '@〓〓 現工程変更後区分が"2:不良"、かつ現工程変更前区分が"5:傾向" 〓〓
                                                        Case .strNewClass = CPstrClass2 And .strOldClass = CPstrClass5
                                                            
                                                            '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                            If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                                
                                                                '@計算処理指示ﾌﾗｸﾞに"3:不良全て"をｾｯﾄ
                                                                llngCalTrnControlFlag = CPlngNumThree
                                                            Else
                                                                '@計算処理指示ﾌﾗｸﾞに"1:良品数 + 既不良数のみ"をｾｯﾄ
                                                                llngCalTrnControlFlag = CPlngNumOne
                                                            End If
                                                            
                                                            '@==================================================================
                                                            '@ ﾁｯﾌﾟ情報一覧の良品数・不良数・現不良数の設定処理
                                                            '@　⇒　計算指示"2:不良数減算"、計算処理指示は上記で設定した値で処理Call
                                                            '@==================================================================
                                                            Call prvVsfChipCntDataSet_Proc(CPlngNumTwo, llngCalTrnControlFlag)
                                                        
                                                        
                                                        '@〓〓 現工程変更後区分が"3:払出"、かつ現工程変更前区分が"5:傾向" 〓〓
                                                        Case .strNewClass = CPstrClass3 And .strOldClass = CPstrClass5
                                                            
                                                            '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                            If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                                
                                                                '@計算処理指示ﾌﾗｸﾞに"6:払出全て"をｾｯﾄ
                                                                llngCalTrnControlFlag = CPlngNumSix
                                                            Else
                                                                '@計算処理指示ﾌﾗｸﾞに"4:良品数 + 既払出数のみ"をｾｯﾄ
                                                                llngCalTrnControlFlag = CPlngNumFour
                                                            End If
                                                            
                                                            '@==================================================================
                                                            '@ ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                            '@　⇒　計算指示"4:払出数減算"、計算処理指示は上記で設定した値で処理Call
                                                            '@==================================================================
                                                            Call prvVsfChipCntDataSet_Proc(CPlngNumFour, llngCalTrnControlFlag)
                                                    
                                                    End Select
                                                    
                                                    
                                                    '@文字色を黒色にする
                    
                                                    '@現工程変更後区分、現工程変更後区分ID、現工程変更後更新ﾌﾗｸﾞの設定
                                                    .strNewClass = .strOldClass                         '傾向
                                                    .strNewClassID = .strOldClassID                     '傾向ｺｰﾄﾞ
                                                    .strNewNowstepEditFlag = .strOldNowstepEditFlag     '更新ﾌﾗｸﾞ
                                                    
                                                    '@ﾁｯﾌﾟﾏｯﾌﾟの設定(現工程変更前区分の反映、現工程変更前区分に従い背景色を戻す)
                                                    vsfChipMap.SetData(llngCnt2, llngCnt3, .strOldClassID)
                                                    
                                                    '@★★ 現工程変更後区分により処理分岐 ★★
                                                    Select Case .strNewClass
                                                        
                                                        '@〓〓 2：不良 〓〓
                                                        Case CPstrClass2
                                                            
                                                            cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColor
                                                        

                                                        '@〓〓 3：払出 〓〓
                                                        Case CPstrClass3
                                                            
                                                            cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColor

                                                    
                                                        '@〓〓 5：傾向 〓〓
                                                        Case CPstrClass5
                                                            
                                                            cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColor
                                                    
                                                    End Select
                                                        
                                                Else
                                                    '@起動区分が"M:工程端末"以外、または現工程変更前区分が"1:良品"、
                                                    '@または現工程変更前自工程更新ﾌﾗｸﾞが"0:自工程更新なし"以外の場合
                                                
                                                    '@-----------------------------------------------------------------------
                                                    '@以下の条件の何れかに該当するか
                                                    '@　①起動区分"M:工程端末"、かつ前工程最新区分ID"良品"以外
                                                    '@ 　※前工程で傾向を現工程で傾向、または不良/払出とした場合、傾向取消で良品にしてはNG
                                                    '@ 　　以前に設定した内容に置き換えする。
                                                    '@　②PR/ESﾛｯﾄ、かつ前工程最新区分ID"不良or傾向"
                                                    '@-----------------------------------------------------------------------
                                                    If (pstrTerminalMode = CPstrManufactureStatus And .strBefoerClassID <> vbNullString) _
                                                        Or (mstrLotFlowClass = CPstrOne And .strBefoerClassID <> vbNullString) Then

                                                        '@★★ 下記条件がTrueになるかにより処理分岐 ★★
                                                        Select Case True

                                                            '@〓〓 現工程変更後区分が"2:不良"、かつ前工程最新区分が"5:傾向" 〓〓
                                                            Case .strNewClass = CPstrClass2 And .strBefoerClass = CPstrClass5
                                                                
                                                                '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                                If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                                    
                                                                    '@計算処理指示ﾌﾗｸﾞに"3:不良全て"をｾｯﾄ
                                                                    llngCalTrnControlFlag = CPlngNumThree
                                                                Else
                                                                    '@計算処理指示ﾌﾗｸﾞに"1:良品数 + 既不良数のみ"をｾｯﾄ
                                                                    llngCalTrnControlFlag = CPlngNumOne
                                                                End If
                                                                
                                                                '@==================================================================
                                                                '@ ﾁｯﾌﾟ情報一覧の良品数・不良数・現不良数の設定処理
                                                                '@　⇒　計算指示"2:不良数減算"、計算処理指示は上記で設定した値で処理Call
                                                                '@==================================================================
                                                                Call prvVsfChipCntDataSet_Proc(CPlngNumTwo, llngCalTrnControlFlag)
            
            
                                                            '@〓〓 現工程変更後区分が"3:払出"、かつ前工程最新区分が"5:傾向" 〓〓
                                                            Case .strNewClass = CPstrClass3 And .strBefoerClass = CPstrClass5
                                                                
                                                                '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                                If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                                    
                                                                    '@計算処理指示ﾌﾗｸﾞに"6:払出全て"をｾｯﾄ
                                                                    llngCalTrnControlFlag = CPlngNumSix
                                                                Else
                                                                    '@計算処理指示ﾌﾗｸﾞに"4:良品数 + 既払出数のみ"をｾｯﾄ
                                                                    llngCalTrnControlFlag = CPlngNumFour
                                                                End If
                                                                
                                                                '@==================================================================
                                                                '@ ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                                '@　⇒　計算指示"4:払出数減算"、計算処理指示は上記で設定した値で処理Call
                                                                '@==================================================================
                                                                Call prvVsfChipCntDataSet_Proc(CPlngNumFour, llngCalTrnControlFlag)
                                                            
                                                        End Select

                                                        
                                                        '@--------------------------------------------------------------------------------------
                                                        '@良品の適用取消で前工程まで"不良"の場合(№03387、03434)
                                                        '@　①ｽﾀｯﾌ端末のﾁｯﾌﾟ状態変更登録で既不良/払出(前工程以前の不良/払出)を適用取消で良品にして登録
                                                        '@　②工程端末のﾁｯﾌﾟ状態変更で該当良品ﾁｯﾌﾟを適用取消する
                                                        '@　既不良(払出)に戻るが良品/総不良(払出)/現不良(払出)数が変わらない(既存ﾊﾞｸﾞ)
                                                        '@　　※②で該当良品ﾁｯﾌﾟを傾向にし適用取消を行っても同様にﾁｯﾌﾟ数が変わりません｡
                                                        '@　　　(確定後、ｷｬﾘｱIDを入力し直すと正しいﾁｯﾌﾟ数が表示されます。)
                                                        '@---------------------------------------------------------------------------------------
                                                        '@★★ 下記条件がTrueになるかにより処理分岐 ★★
                                                        Select Case True
                                                        
                                                            '@〓〓 現工程変更後区分が"1:良品"or"5:傾向"で、かつ前工程区分が"2:不良" 〓〓
                                                            Case (.strNewClass = CPstrClass1 Or .strNewClass = CPstrClass5) And .strBefoerClass = CPstrClass2
                                                            
                                                                '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                                If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                                    
                                                                    '@計算処理指示ﾌﾗｸﾞに"3:不良全て"をｾｯﾄ
                                                                    llngCalTrnControlFlag = CPlngNumThree
                                                                Else
                                                                    '@計算処理指示ﾌﾗｸﾞに"1:良品数 + 既不良数のみ"をｾｯﾄ
                                                                    llngCalTrnControlFlag = CPlngNumOne
                                                                End If
                                                                
                                                                '@==================================================================
                                                                '@ ﾁｯﾌﾟ情報一覧の良品数・不良数・現不良数の設定処理
                                                                '@　⇒　計算指示"1:不良数加算"、計算処理指示は上記で設定した値で処理Call
                                                                '@==================================================================
                                                                Call prvVsfChipCntDataSet_Proc(CPlngNumOne, llngCalTrnControlFlag)
                                                            
                                                            
                                                            '@〓〓 現工程変更後区分が"1:良品"or"5:傾向"で、かつ前工程区分が"3:払出" 〓〓
                                                            Case (.strNewClass = CPstrClass1 Or .strNewClass = CPstrClass5) And .strBefoerClass = CPstrClass3
                                                            
                                                                '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                                If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                                    
                                                                    '@計算処理指示ﾌﾗｸﾞに"6:払出全て"をｾｯﾄ
                                                                    llngCalTrnControlFlag = CPlngNumSix
                                                                Else
                                                                    '@計算処理指示ﾌﾗｸﾞに"4:良品数 + 既払出数のみ"をｾｯﾄ
                                                                    llngCalTrnControlFlag = CPlngNumFour
                                                                End If
                                                                
                                                                '@==================================================================
                                                                '@　ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                                '@　　⇒　計算指示"3:払出数加算"、計算処理指示は上記で設定した値で処理Call
                                                                '@==================================================================
                                                                Call prvVsfChipCntDataSet_Proc(CPlngNumThree, llngCalTrnControlFlag)
                                                        
                                                        End Select

                                                        
                                                        '@文字色を黒色にする
                        
                                                        '@前工程最新区分に置き換え(戻し)
                                                        .strNewClass = .strBefoerClass
                                                        .strNewClassID = .strBefoerClassID
                                                        
                                                        '@現工程変更後更新ﾌﾗｸﾞに"1:自工程更新あり"をｾｯﾄ(表裏ﾎﾞﾀﾝ切替で取消前の情報が残る為)
                                                        .strNewNowstepEditFlag = CMstrNowstepEditEnable

                                                        '@ﾁｯﾌﾟﾏｯﾌﾟの設定(前工程最新区分の反映、前工程最新区分に従い背景色を戻す)
                                                        vsfChipMap.SetData(llngCnt2, llngCnt3, .strBefoerClassID)
                                                        
                                                        '@★★ 前工程区分により処理分岐 ★★
                                                        Select Case .strBefoerClass
                                                            
                                                            '@〓〓 2：不良 〓〓
                                                            Case CPstrClass2
                                                                
                                                                cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColor
                                                            
                                                            
                                                            '@〓〓 3：払出 〓〓
                                                            Case CPstrClass3
                                                                
                                                                cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColor

                                                            
                                                            '@〓〓 5：傾向 〓〓
                                                            Case CPstrClass5
                                                                
                                                                cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColor
                                                        
                                                        End Select
                                                        
                                                    Else
                                                        '@起動区分"M:工程端末"以外、または"PR/ESﾛｯﾄ"以外、または"自工程更新なし"
                                                        '@または前工程最新区分が"良品"の場合
                                                    
                                                        '@ﾛｯﾄが"1:PR/ES"以外、または"1:自工程更新あり"か
                                                        If mstrLotFlowClass <> CPstrOne Or _
                                                            .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                        
                                                            '@現工程変更後区分が"2:不良"、"3:払出"、または"5:傾向"か
                                                            If .strNewClass = CPstrClass2 Or _
                                                                .strNewClass = CPstrClass3 Or _
                                                                .strNewClass = CPstrClass5 Then

                                                                '@★★ 現工程変更後区分により処理分岐 ★★
                                                                Select Case .strNewClass
                                                                
                                                                    '@〓〓 2：不良 〓〓
                                                                    Case CPstrClass2
                                                                    
                                                                        '@==================================================================
                                                                        '@ ﾁｯﾌﾟ情報一覧の良品数・不良数・現不良数の設定処理
                                                                        '@　⇒　計算指示"2:不良数減算"、計算処理指示は"3:不良全て"で処理Call
                                                                        '@==================================================================
                                                                        Call prvVsfChipCntDataSet_Proc(CPlngNumTwo, CPlngNumThree)
                                                                    
                                                                    
                                                                    '@〓〓 3：払出 〓〓
                                                                    Case CPstrClass3
                                                                    
                                                                        '@==================================================================
                                                                        '@　ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                                        '@　　⇒　計算指示"4:払出数減算"、計算処理指示は"6:払出全て"で処理Call
                                                                        '@==================================================================
                                                                        Call prvVsfChipCntDataSet_Proc(CPlngNumFour, CPlngNumSix)
                
                                                                End Select

                                                                
                                                                '@現工程変更後区分、現工程変更後区分ID、現工程変更後更新ﾌﾗｸﾞの設定
                                                                .strNewClass = CPstrClass1                          '良品
                                                                .strNewClassID = lstrTekiyouCode                    '区分ｺｰﾄﾞ
                                                                .strNewNowstepEditFlag = CMstrNowstepEditDisable    '0:自工程更新なし
                                                                
                                                                '@ﾁｯﾌﾟﾏｯﾌﾟの設定(区分の反映、背景色を白に設定)
                                                                vsfChipMap.SetData(llngCnt2, llngCnt3, lstrTekiyouCode)
                                                                cellRange.Style = newStyle_FC_ChipNoForeColor_BC_EnableTrueColor
                                                            End If
                                                            
                                                            With vsfChipMap
                                                                If vsfChipMap.GetCellRange(llngCnt2, llngCnt3).StyleDisplay.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngCandidacyBackColor)) Then
                                                                ' 何もしない
                                                                Else
                                                                    '@ﾁｯﾌﾟIDの文字色を灰色にする
                                                                    cellRange.Style = newStyle_FC_ChipNoForeColor_BC_EnableTrueColor
                                                                End If
                                                                
                                                                '@★★ 表/裏ﾎﾞﾀﾝの表示により処理分岐 ★★
                                                                Select Case cmdHyouri.Text
                                                                
                                                                    '@〓〓 表へ 〓〓
                                                                    Case CMstrCmdHyouriKbn1
                                                                        
                                                                        .SetData(llngCnt2, llngCnt3, _
                                                                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strChipId, 3))
                                                                    
                                                                    '@〓〓 裏へ 〓〓
                                                                    Case CMstrCmdHyouriKbn2
                                                                        
                                                                        .SetData(llngCnt2, llngCnt3, _
                                                                            Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strChipId, 3))
                                                                End Select

                                                            End With
                                                        End If
                                                    End If
                                                End If
                                            End If
                                            
                                            
                                        '@〓 取消ﾎﾞﾀﾝ 〓
                                        Case cmdClear.Name
                                            
                                            '@----------------------------------------------------------------
                                            '@以下の条件の何れかに該当するか
                                            '@　①現工程の変更前区分と変更後区分が異なる
                                            '@　②現工程の変更前区分IDと変更後区分IDが異なる
                                            '@　③現工程変更前自工程更新ﾌﾗｸﾞと現工程変更後自工程更新ﾌﾗｸﾞが異なる
                                            '@----------------------------------------------------------------
                                            If .strNewClass <> .strOldClass Or .strNewClassID <> .strOldClassID _
                                                Or .strNewNowstepEditFlag <> .strOldNowstepEditFlag Then
                                                
                                                '@★★ Case文がTrueになるかにより処理分岐 ★★
                                                Select Case True

                                                    '@〓〓 ①良品→不良、②傾向→不良に変更されたﾁｯﾌﾟの取消(良品または傾向に戻す) 〓〓
                                                    Case .strOldClass = CPstrClass1 And .strNewClass = CPstrClass2, _
                                                        .strOldClass = CPstrClass5 And .strNewClass = CPstrClass2
                                                        
                                                        '@==================================================================
                                                        '@ ﾁｯﾌﾟ情報一覧の良品数・不良数・現不良数の設定処理
                                                        '@　⇒　計算指示"2:不良数減算"、計算処理指示は"3:不良全て"で処理Call
                                                        '@==================================================================
                                                        Call prvVsfChipCntDataSet_Proc(CPlngNumTwo, CPlngNumThree)
                                                            
                                                            
                                                    '@〓〓 ①不良→良品、②不良→傾向に変更されたﾁｯﾌﾟの取消(不良に戻す) 〓〓
                                                    Case .strOldClass = CPstrClass2 And .strNewClass = CPstrClass1, _
                                                        .strOldClass = CPstrClass2 And .strNewClass = CPstrClass5
                                                        
                                                        '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                        If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                            
                                                            '@計算処理指示ﾌﾗｸﾞに"3:不良全て"をｾｯﾄ
                                                            llngCalTrnControlFlag = CPlngNumThree
                                                        Else
                                                            '@計算処理指示ﾌﾗｸﾞに"1:良品数 + 既不良数のみ"をｾｯﾄ
                                                            llngCalTrnControlFlag = CPlngNumOne
                                                        End If
                                                        
                                                        '@==================================================================
                                                        '@ ﾁｯﾌﾟ情報一覧の良品数・不良数・現不良数の設定処理
                                                        '@　⇒　計算指示"1:不良数加算"、計算処理指示は上記設定値で処理Call
                                                        '@==================================================================
                                                        Call prvVsfChipCntDataSet_Proc(CPlngNumOne, llngCalTrnControlFlag)
                                                    
                                                    
                                                    '@〓〓 ①良品→払出、②傾向→払出に変更されたﾁｯﾌﾟの取消(良品または傾向に戻す) 〓〓
                                                    Case .strOldClass = CPstrClass1 And .strNewClass = CPstrClass2, _
                                                        .strOldClass = CPstrClass5 And .strNewClass = CPstrClass2
                                                        
                                                        '@==================================================================
                                                        '@ ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                        '@　⇒　計算指示"4:払出数減算"、計算処理指示は"6:払出全て"で処理Call
                                                        '@==================================================================
                                                        Call prvVsfChipCntDataSet_Proc(CPlngNumFour, CPlngNumSix)
                                                            
                                                            
                                                    '@〓〓 ①払出→良品、②払出→傾向に変更されたﾁｯﾌﾟの取消(払出に戻す) 〓〓
                                                    Case .strOldClass = CPstrClass2 And .strNewClass = CPstrClass1, _
                                                        .strOldClass = CPstrClass2 And .strNewClass = CPstrClass5
                                                        
                                                        '@現工程変更後自工程更新ﾌﾗｸﾞが"1:自工程更新あり"か
                                                        If .strNewNowstepEditFlag = CMstrNowstepEditEnable Then
                                                            
                                                            '@計算処理指示ﾌﾗｸﾞに"6:払出全て"をｾｯﾄ
                                                            llngCalTrnControlFlag = CPlngNumSix
                                                        Else
                                                            '@計算処理指示ﾌﾗｸﾞに"4:良品数 + 既払出数のみ"をｾｯﾄ
                                                            llngCalTrnControlFlag = CPlngNumFour
                                                        End If
                                                        
                                                        '@==================================================================
                                                        '@ ﾁｯﾌﾟ情報一覧の良品数・払出数・現払出数の設定処理
                                                        '@　⇒　計算指示"3:払出数加算"、計算処理指示は上記設定値で処理Call
                                                        '@==================================================================
                                                        Call prvVsfChipCntDataSet_Proc(CPlngNumThree, llngCalTrnControlFlag)

                                                    
                                                    '@〓〓 その他 〓〓
                                                    Case Else
                                                        
                                                        '@ｺｰﾄﾞのみの変更の場合は、数量の増減はないのでﾁｯﾌﾟ情報一覧の変更処理は無し
                                                        
                                                End Select
                                                
                                                '@現工程変更後区分、現工程変更後区分ID、現工程変更後更新ﾌﾗｸﾞの設定
                                                .strNewClass = .strOldClass                         '現工程変更前区分
                                                .strNewClassID = .strOldClassID                     '現工程変更前区分ID
                                                .strNewNowstepEditFlag = .strOldNowstepEditFlag     '現工程変更前更新ﾌﾗｸﾞ
                                                
                                                '@ﾁｯﾌﾟﾏｯﾌﾟの設定(区分の反映、背景色を白に設定)
                                                vsfChipMap.SetData(llngCnt2, llngCnt3, .strNewClassID)
                                                
                                                '@★★ 現工程変更後区分により処理分岐 ★★
                                                Select Case .strNewClass
                                                    
                                                    '@〓〓 1：良品 〓〓
                                                    Case CPstrClass1
                                                        
                                                        cellRange.Style = newStyle_FC_ChipNoForeColor_BC_EnableTrueColor

                                                    
                                                    '@〓〓 2：不良 〓〓
                                                    Case CPstrClass2
                                                        
                                                        '@★★★ 現工程変更後更新ﾌﾗｸﾞにより処理分岐 ★★★
                                                        Select Case .strNewNowstepEditFlag
                                                            
                                                            '@〓〓〓 1:自工程更新あり 〓〓〓
                                                            Case CMstrNowstepEditEnable
                                                                
                                                                '@自工程用不良背景色(赤ﾋﾟﾝｸ)を設定
                                                                cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColorNow
                                                            
                                                            '@〓〓〓 0:自工程更新なし 〓〓〓
                                                            Case CMstrNowstepEditDisable
                                                                
                                                                '@既不良背景色(ﾋﾟﾝｸ)を設定
                                                                cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColor
                                                            
                                                            '@〓〓〓 その他 〓〓〓
                                                            Case Else
                                                                
                                                                '@既不良背景色(ﾋﾟﾝｸ)を設定
                                                                cellRange.Style = newStyle_FC_BlackColor_BC_FuryouColor
                                                        
                                                        End Select


                                                    '@〓〓 3：払出 〓〓
                                                    Case CPstrClass3
                                                        
                                                        '@★★★ 現工程変更後更新ﾌﾗｸﾞにより処理分岐 ★★★
                                                        Select Case .strNewNowstepEditFlag
                                                            
                                                            '@〓〓〓 1:自工程更新あり 〓〓〓
                                                            Case CMstrNowstepEditEnable
                                                                
                                                                '@自工程用払出背景色(ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)を設定
                                                                cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColorNow
                                                            
                                                            '@〓〓〓 0:自工程更新なし 〓〓〓
                                                            Case CMstrNowstepEditDisable
                                                                
                                                                '@既払出背景色(薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)を設定
                                                                cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColor
                                                            
                                                            '@〓〓〓 その他 〓〓〓
                                                            Case Else
                                                                
                                                                '@既払出背景色(薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)を設定
                                                                cellRange.Style = newStyle_FC_BlackColor_BC_HaraidashiColor
                                                        
                                                        End Select

                                                        
                                                    '@〓〓 5：傾向 〓〓
                                                    Case CPstrClass5
                                                        
                                                        '@★★★ 現工程変更後更新ﾌﾗｸﾞにより処理分岐 ★★★
                                                        Select Case .strNewNowstepEditFlag
                                                            
                                                            '@〓〓〓 1:自工程更新あり 〓〓〓
                                                            Case CMstrNowstepEditEnable
                                                                
                                                                '@自工程用傾向背景色(山吹色)を設定
                                                                cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColorNow
                                                            
                                                            '@〓〓〓 0:自工程更新なし 〓〓〓
                                                            Case CMstrNowstepEditDisable
                                                                
                                                                '@既傾向背景色(ﾚﾓﾝ色)を設定
                                                                cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColor
                                                            
                                                            '@〓〓〓 その他 〓〓〓
                                                            Case Else
                                                                
                                                                '@既傾向背景色(ﾚﾓﾝ色)を設定
                                                                cellRange.Style = newStyle_FC_BlackColor_BC_KeikouColor
                                                        
                                                        End Select
                                                    
                                                    '@〓〓 その他 〓〓
                                                    Case Else
                                                        
                                                        '@良品背景色(白色)を設定
                                                        cellRange.Style = newStyle_FC_ChipNoForeColor_BC_EnableTrueColor
                                                
                                                End Select
                                            End If
                                            
                                            '@文字色を黒色にする
                                            
                                            '@現工程変更前区分が"5:傾向"以外、"2:不良"以外or"3:払出"以外か
                                            If .strOldClass <> CPstrClass5 And _
                                                (.strOldClass <> CPstrClass2 Or .strOldClass <> CPstrClass3) Then
                                                
                                                '@ﾁｯﾌﾟIDの表示
                                                With vsfChipMap
                                                    
                                                    '@ﾁｯﾌﾟIDの文字色を灰色にする
                                                    If mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strOldClass = CPstrClass1 Then
                                                        cellRange.Style = newStyle_FC_ChipNoForeColor_BC_EnableTrueColor
                                                    Else
                                                        cellRange.Style = newStyle_FC_ChipNoForeColor_BC_ReferOnlyColor
                                                    End If
                                                    
                                                    '@ﾁｯﾌﾟIDを設定する
                                                    .SetData(llngCnt2, llngCnt3, Strings.Right$(mtypWFInfo(mlngWFNowIndex-1).typChipList(llngCnt2-1, llngChipCol-1).strChipId, 3))
                                                End With
                                            End If
                                            
                                            '@****************************
                                            '@ 複数指定専用記述(全部ｸﾘｱ)
                                            '@****************************
                                            '@背景色が水色か
                                            If vsfChipMap.GetCellRange(llngCnt2, llngCnt3).StyleDisplay.BackColor = ColorTranslator.FromWin32(CMlngCandidacyBackColor) Then
                                                
                                                '@背景色を白にする
                                                cellRange.Style = newStyle_FC_ChipNoForeColor_BC_vbWhite
                                            End If
                                            
                                    End Select
                                End If
                            End If
                        End With
                
                    End If
                
                Next llngCnt3
            Next llngCnt2
            
            '@入力ﾁｪｯｸ区分に"2:入力済み"を設定する
            mtypWFInfo(mlngWFNowIndex-1).strInputCheckKbn = CMstrstrInputCheckKbn2
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvTekiyou_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCommonTransaction_Proc
    '機　能：適用/適用取消処理Call、不良数/払出ｶｳﾝﾄ処理
    '　　　：不良(払出)適用ﾎﾞﾀﾝ、傾向適用ﾎﾞﾀﾝ、適用取消ﾎﾞﾀﾝ押下時共通処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/04/28 (Mon) 10:38:46 N.Kojima
    '更新日：2009/03/31 (Tue) 14:37:53 N.Kojima
    '備　考：
    '　　　：2009/03/31 (Tue) 14:37:53 N.Kojima     ﾁｯﾌﾟ払出対応に伴い処理追加/変更。(案件№03434)
    Private Sub prvCommonTransaction_Proc()

        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾀ
        Dim llngCnt2                As Integer      '汎用ｶｳﾝﾀ2
        Dim llngScrapCmpCnt         As Integer      '不良ｺｰﾄﾞ比較用

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①単数ﾁｯﾌﾟ選択の場合、単数適用/適用取消処理を行なう
            '@　　②複数ﾁｯﾌﾟ選択の場合、複数適用/適用取消処理を行なう
            '@　　③対象ﾁｯﾌﾟの背景色を判定し、不良/払出ｺｰﾄﾞ一覧の不良/払出ｺｰﾄﾞの不良/払出数を加算する
            '@　　④ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ別、ﾌｫｰｶｽｾｯﾄ処理
            '@======================================================================================
            
            
            '@=======================
            '@ 適用/適用取消処理
            '@=======================
            Call prvTekiyou_Set(ActiveControl.Name)
            
            '@=======================
            '@ 適用/適用取消処理(複数選択)
            '@=======================
            Call prvPluralTekiyou_Set(ActiveControl.Name)
            

            For llngCnt = 1 To vsfScpList.Rows.Count - 1
            
                '@不良/払出数を初期化("0"を格納)
                vsfScpList.SetData(llngCnt, CMlngvsfScpListScrapNum, CPstrZero)

            Next llngCnt
            
            With vsfChipMap
            
                '@行
                For llngCnt = 1 To mlngChipGridMaxRows
                    '@列
                    For llngCnt2 = 1 To mlngChipGridMaxCols
                        
                        '@対象ﾁｯﾌﾟの背景色が"濃いﾋﾟﾝｸ:現工程不良色"、または"ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ:現工程払出色"か
                        If .GetCellRange(llngCnt, llngCnt2).StyleDisplay.BackColor = ColorTranslator.FromWin32(CMlngFuryouColorNow) Or _
                            .GetCellRange(llngCnt, llngCnt2).StyleDisplay.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColorNow) Then
                                                
                            '@該当する不良/払出ｺｰﾄﾞを検索する(不良/払出項目一覧のｺｰﾄﾞとﾁｯﾌﾟ表示不良/払出ｺｰﾄﾞ)
                            '@不良/払出ｺｰﾄﾞ数分ﾙｰﾌﾟ
                            For llngScrapCmpCnt = 1 To vsfScpList.Rows.Count - 1
                                
                                '@適用不良/払出ｺｰﾄﾞと同じ不良/払出ｺｰﾄﾞか
                                If .GetData(llngCnt, llngCnt2) = _
                                    vsfScpList.GetData(llngScrapCmpCnt, CMlngvsfScpListCode) Then

                                     '@対象不良/払出ｺｰﾄﾞの不良/払出数(「数」)に+1する
                                    vsfScpList.SetData(llngScrapCmpCnt, CMlngvsfScpListScrapNum, _
                                        CStr(CLng(vsfScpList.GetData(llngScrapCmpCnt, CMlngvsfScpListScrapNum)) + 1))
                                
                                End If
                            Next llngScrapCmpCnt
                        End If
                    Next llngCnt2
                Next llngCnt
            End With
            
            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが取消ﾎﾞﾀﾝ以外か
            If ActiveControl.Name <> cmdClear.Name Then
                '@取消ﾎﾞﾀﾝ以外の場合
            
                '@ﾁｯﾌﾟﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfChipMap)
            Else
                '@取消ﾎﾞﾀﾝの場合
            
                '@ﾌｫｰｶｽ、ﾁｯﾌﾟ№の設定
                vsfChipMap.Col = -1                 'ﾁｯﾌﾟﾏｯﾌﾟの外
                lblChipNo.Text = vbNullString    'NULL
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvCommonTransaction_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfChipCntDataSet_Proc
    '機　能：ﾁｯﾌﾟ情報一覧の良品数・不良・払出数・現不良・現払出数の設定処理
    '引　数：llngCalIndicate        ：計算指示(1:不良数加算、2:不良数減算、3:払出数加算、4:払出数減算)
    '　　　：llngCalTrnControlFlag  ：計算処理実行判定ﾌﾗｸﾞ(1:良品数 + 既不良数のみ、2:現不良のみ、3:不良全て、
    '　　　：                       ：                  4:良品数 + 既払出数のみ、5:現払出のみ、6:払出全て、7:全て)
    '戻り値：なし
    '作成日：2008/04/30 (Wed) 15:19:33 N.Kojima
    '更新日：2009/03/31 (Tue) 14:37:53 N.Kojima
    '備　考：
    '　　　：2009/03/31 (Tue) 14:37:53 N.Kojima     ﾁｯﾌﾟ払出対応に伴い処理追加/変更。(案件№03434)
    Private Sub prvVsfChipCntDataSet_Proc(ByVal llngCalIndicate As Integer, _
                                          ByVal llngCalTrnControlFlag As Integer)

        Dim llngClass1CalEquation       As Integer  '良品数計算式格納用
        Dim llngClass2CalEquation       As Integer  '不良(払出)数計算式格納用

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①引数の計算指示・計算処理実行判定ﾌﾗｸﾞにより、良品数・総不良(払出)数・現不良(現払出)数の
            '@　　　加減算を行なう
            '@　　②ﾁｯﾌﾟ情報一覧のLOT行、WF行のﾃﾞｰﾀの再表示を行なう
            '@======================================================================================
            
            
            '@計算指示が"1:不良数加算"or"3:払出数加算"か
            If llngCalIndicate = CPlngNumOne Or _
                llngCalIndicate = CPlngNumThree Then
            
                '@加算(+1)で計算式を作成する
                llngClass1CalEquation = -1
                llngClass2CalEquation = 1
            Else
                '@計算指示が"2:不良数減算"or"4:払出数減算"の場合
            
                '@減算(-1)で計算式を作成する
                llngClass1CalEquation = 1
                llngClass2CalEquation = -1
            End If
            
            '@--------------------------------------
            '@ a.良品数・不良・払出数の加減算、再表示処理
            '@ b.現不良・現払出数の加減算、再表示処理
            '@--------------------------------------
            With vsfChipCnt
                
                '@計算処理実行判定ﾌﾗｸﾞが"1:良品数 + 既不良数のみ"、"3:不良全て"、または"7:全て"か
                If llngCalTrnControlFlag = CPlngNumOne Or _
                    llngCalTrnControlFlag = CPlngNumThree Or _
                    llngCalTrnControlFlag = CPlngNumSeven Then

                    '@ﾁｯﾌﾟ数量一覧のﾛｯﾄ列の総不良数を、上記で設定した計算式で計算して総不良に表示する
                    If IsNumeric(.GetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntLot)) Then
                        .SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntLot, _
                            Format(CInt(.GetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntLot)) + llngClass2CalEquation, CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntLot, _
                            Format(llngClass2CalEquation, CPstrDateFormatKanma))
                    End If

                    '@ﾁｯﾌﾟ数量一覧のWF列の総不良数を、上記で設定した計算式で計算して総不良に表示する
                    If IsNumeric(.GetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntWF)) Then
                        .SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntWF, _
                            Format(CInt(.GetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntWF)) + llngClass2CalEquation, CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntWF, _
                            Format(llngClass2CalEquation, CPstrDateFormatKanma))
                    End If


                    '@ﾁｯﾌﾟ数量一覧のﾛｯﾄ列の良品数を、上記で設定した計算式で計算して良品に表示する
                    If IsNumeric(.GetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot)) Then
                        .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot, _
                            Format(CInt(.GetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot)) + llngClass1CalEquation, CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot, _
                            Format(llngClass1CalEquation, CPstrDateFormatKanma))
                    End If

                    '@ﾁｯﾌﾟ数量一覧のWF列の良品数を、上記で設定した計算式で計算して良品に表示する
                    If IsNumeric(.GetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF)) Then
                        .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF, _
                            Format(CInt(.GetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF)) + llngClass1CalEquation, CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF, _
                            Format(llngClass1CalEquation, CPstrDateFormatKanma))
                    End If


                    '@WF情報の良品数、総不良数も書き換え
                    mtypWFInfo(mlngWFNowIndex-1).strWFChipQuantity = _
                        .GetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF)      '良品数
                    mtypWFInfo(mlngWFNowIndex-1).strWFChipOutQuantity = _
                        .GetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntWF)   '総不良数
                        
                End If
                
                '@計算処理実行判定ﾌﾗｸﾞが"2:現不良数のみ"、"3:不良全て"、または"7:全て"か
                If llngCalTrnControlFlag = CPlngNumTwo Or _
                    llngCalTrnControlFlag = CPlngNumThree Or _
                    llngCalTrnControlFlag = CPlngNumSeven Then

                    '@---------------------------
                    '@ 現不良数の加算・減算処理
                    '@---------------------------

                    '@ﾁｯﾌﾟ数量一覧のﾛｯﾄ列の現不良数を、上記で設定した計算式で計算して現不良に表示する
                    If IsNumeric(.GetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot)) Then
                        .SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot, _
                            Format(CInt(.GetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot)) + llngClass2CalEquation, CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot, _
                            Format(llngClass2CalEquation, CPstrDateFormatKanma))
                    End If
                    
                    '@ﾁｯﾌﾟ数量一覧のWF列の現不良数を、上記で設定した計算式で計算して現不良に表示する
                    If IsNumeric(.GetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntWF)) Then
                        .SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntWF, _
                            Format(CInt(.GetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntWF)) + llngClass2CalEquation, CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntWF, _
                            .GetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntWF) + llngClass2CalEquation)
                    End If
                    
                    '@不良/払出ﾁｯﾌﾟ情報構造体の現不良数も書き換え
                    If IsNumeric(.GetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot)) Then
                        ptypLotScrapInfo.strLotOutQuantity = _
                            (CInt(.GetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot)) + llngClass2CalEquation).ToString
                    Else
                        ptypLotScrapInfo.strLotOutQuantity = _
                            llngClass2CalEquation.ToString
                    End If
                    
                    '@WF情報の現不良数も書き換え
                    mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentOutQuantity = _
                        .GetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntWF)
                        
                End If

                '@計算処理実行判定ﾌﾗｸﾞが"4:良品数 + 払出数のみ"、"6:払出全て"、または"7:全て"か
                If llngCalTrnControlFlag = CPlngNumFour Or _
                    llngCalTrnControlFlag = CPlngNumSix Or _
                    llngCalTrnControlFlag = CPlngNumSeven Then

                    '@ﾁｯﾌﾟ数量一覧のﾛｯﾄ列の総払出数を、上記で設定した計算式で計算して総払出に表示する
                    If IsNumeric(.GetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot)) Then
                        .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, _
                            Format(CInt(.GetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot)) + llngClass2CalEquation, CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, _
                            Format(llngClass2CalEquation, CPstrDateFormatKanma))
                    End If

                    '@ﾁｯﾌﾟ数量一覧のWF列の総払出数を、上記で設定した計算式で計算して総払出に表示する
                    If IsNumeric(.GetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF)) Then
                        .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, _
                            Format(CInt(.GetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF)) + llngClass2CalEquation, CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, _
                            Format(llngClass2CalEquation, CPstrDateFormatKanma))
                    End If


                    '@ﾁｯﾌﾟ数量一覧のﾛｯﾄ行の良品数を、上記で設定した計算式で計算して良品数に表示する
                    If IsNumeric(.GetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot)) Then
                        .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot, _
                            Format(CInt(.GetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot)) + llngClass1CalEquation, CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot, _
                            Format(llngClass1CalEquation, CPstrDateFormatKanma))
                    End If

                    '@ﾁｯﾌﾟ数量一覧のWF行の良品数を、上記で設定した計算式で計算して良品数に表示する
                    If IsNumeric(.GetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF)) Then
                        .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF, _
                            Format(CInt(.GetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF)) + llngClass1CalEquation, CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF, _
                            Format(llngClass1CalEquation, CPstrDateFormatKanma))
                    End If

                    '@WF情報の良品数、払出数も書き換え
                    mtypWFInfo(mlngWFNowIndex-1).strWFChipQuantity = _
                        .GetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF)      '良品数
                    mtypWFInfo(mlngWFNowIndex-1).strWFChipForwardQuantity = _
                        .GetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF)   '払出数

                    '@起動SBが基板か
                    If pstrSBID = CPstrSBID1A0 Then
                    
                        '@払出数行は"-"で表示
                        .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, CPstrMinus)
                        .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, CPstrMinus)
                        .SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, CPstrMinus)
                        .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, CPstrMinus)
                    End If

                End If
                
                '@計算処理実行判定ﾌﾗｸﾞが"5:現払出数のみ"、"6:払出全て"、または"7:全て"か
                If llngCalTrnControlFlag = CPlngNumFive Or _
                    llngCalTrnControlFlag = CPlngNumSix Or _
                    llngCalTrnControlFlag = CPlngNumSeven Then

                    '@---------------------------
                    '@ 現払出数の加算・減算処理
                    '@---------------------------

                    '@ﾁｯﾌﾟ数量一覧のﾛｯﾄ列の現払出数を、上記で設定した計算式で計算して現払出に表示する
                    If IsNumeric(.GetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot)) Then
                        .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, _
                            Format(CInt(.GetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot)) + llngClass2CalEquation, CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, _
                            Format(llngClass2CalEquation, CPstrDateFormatKanma))
                    End If
                    
                    '@ﾁｯﾌﾟ数量一覧のWF行の現払出数を、上記で設定した計算式で計算して現払出に表示する
                    If IsNumeric(.GetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF)) Then
                        .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, _
                            Format(CInt(.GetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF)) + llngClass2CalEquation, CPstrDateFormatKanma))
                    Else
                        .SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, _
                            Format(llngClass2CalEquation, CPstrDateFormatKanma))
                    End If
                    
                    '@不良/払出ﾁｯﾌﾟ情報構造体の現払出数も書き換え
                    If IsNumeric(.GetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot)) Then
                        ptypLotScrapInfo.strLotForwardQuantity = _
                            CInt(.GetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot) + llngClass2CalEquation).ToString()
                    Else
                        ptypLotScrapInfo.strLotForwardQuantity = _
                            llngClass2CalEquation.ToString()
                    End If
                    
                    '@WF情報の現払出数も書き換え
                    mtypWFInfo(mlngWFNowIndex-1).strWFChipCurrentForwardQuantity = _
                        .GetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF)
                        
                End If
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvVsfChipCntDataSet_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnRegistInput_Chk
    '機　能：確定時の入力ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2004/03/31 (Wed) 13:59:06 T.Kitagawa
    '更新日：2016/06/17 (Fri) 15:32:05 T.Oide
    '備　考：
    '　　　：2006/06/22 (Thu) 13:10:29 T.Kitagawa   DataMatrixｺｰﾄﾞ(ﾊﾞｰｺｰﾄﾞ)対応(ﾕｰｻﾞ要望№0209)
    '　　　：2007/02/14 (Wed) 15:35:32 N.Kasai      ﾛｯﾄ状態が処理中、後処理以外は全数不良不可(№01739)
    '　　　：2008/04/30 (Wed) 11:42:45 N.Kojima     ｿｰｽ整備、WF不良ﾁｪｯｸ処理追加。(案件№02786)
    Private Function prvblnRegistInput_Chk() As Boolean
        
        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt3                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lblnChangeKbn           As Boolean      '変更区分判定ﾌﾗｸﾞ(True:変更あり、False:変更なし)
        Dim llngRow                 As Integer      'ｴﾗｰ行
        Dim lblnErrKbn              As Boolean      'ｴﾗｰ判定ﾌﾗｸﾞ(True:ｴﾗｰあり、False：ｴﾗｰなし)
        
        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①登録ﾃﾞｰﾀ有無ﾁｪｯｸ
            '@　　②ﾛｯﾄ状態ﾁｪｯｸ(ｴﾗｰ時はｴﾗｰ行へのﾌｫｰｶｽｾｯﾄ処理も行う)
            '@======================================================================================


            '@各種初期化
            prvblnRegistInput_Chk = False       '戻り値
            mblnFuryouClass = False             '不良存在判定ﾌﾗｸﾞ
            mblnHaraidashiClass = False         '払出存在判定ﾌﾗｸﾞ
            lblnChangeKbn = False               '変更区分判定ﾌﾗｸﾞ
            
            '@ｽﾛｯﾄ数分ﾙｰﾌﾟ
            For llngCnt = 0 To CMlngvsfWFMapMaxSlotID - 1
                
                '@変更区分判定ﾌﾗｸﾞが"True:変更あり"か
                If lblnChangeKbn = True Then
                    Exit For
                End If
                
                '@WFIDがNULL以外か
                If mtypWFInfo(llngCnt).strWfId <> vbNullString Then
                    
                    For llngCnt2 = 0 To mlngChipGridMaxRows - 1
                        
                        '@変更区分判定ﾌﾗｸﾞが"True:変更あり"か
                        If lblnChangeKbn = True Then
                            Exit For
                        End If
                        
                        For llngCnt3 = 0 To mlngChipGridMaxCols - 1
                            
                            With mtypWFInfo(llngCnt).typChipList(llngCnt2, llngCnt3)
                                
                                '@現工程変更前区分と現工程変更後区分が異なる、または変更前後の区分IDが異なるか
                                If .strOldClass <> .strNewClass Or .strOldClassID <> .strNewClassID Then
                                    
                                    '@変更区分判定ﾌﾗｸﾞに"True:変更あり"をｾｯﾄ
                                    lblnChangeKbn = True
                                    Exit For
                                End If
                            End With
                        Next llngCnt3
                    Next llngCnt2
                End If
            Next llngCnt
            
            '@変更区分判定ﾌﾗｸﾞが"False:変更なし"か
            If lblnChangeKbn = False Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0043)
                '@"<TRM43W>$$登録データがありません。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@パ検行程か
                '@↓2020/03/19 (Thu) 19:12:15 Y.Yoneyama 「.Netへ反映未」 **************************************************
                If Mid$(ptypLotprestate.strWpID, 1, 7) = CPstrPakenWpId Then
                '@↑2020/03/19 (Thu) 19:12:15 Y.Yoneyama 「.Netへ反映未」 **************************************************
                
                    '@確定したWF_IDの表示を赤にする(登録データがなくても) 作業漏れ対策
                    Dim newStyle As CellStyle = vsfWFMap.Styles.Add("CustomStyle_ForeColor_vbRed")
                    newStyle.ForeColor = Color.Red
                    newStyle.Font = New Font(newStyle.Font, FontStyle.Bold)
                    Dim cellRange As CellRange = vsfWFMap.GetCellRange(vsfWFMap.Row, CMlngvsfWFMapID)
                    newStyle.BackColor = cellRange.Style.BackColor
                    cellRange.Style = newStyle

                    '@パ検行程は、画面をクリアするため、1行目(WFが紐つかない)を選択
                    vsfWFMap.Row = 1
                End If
                
                Exit Function
            End If
            
            
            '@-----------------------
            '@ 全数不良(払出)ﾁｪｯｸ
            '@-----------------------
            '@★ ﾛｯﾄ状態により処理分岐 ★
            Select Case lblStatus.Text
                
                '@〓 処理中 or 後処理 〓
                Case CPstrProcessingSt, CPstrAfterProgressSt

                    '@-----------------------
                    '@ WFｱｳﾄ可否ﾁｪｯｸ
                    '@-----------------------
                    For llngCnt = 0 To mstrSlotSize - 1
                        
                        With mtypWFInfo(llngCnt)
                            
                            '@WF_IDがNULL以外、かつ登録不良/払出数がNULL以外、かつ良品数がNULL以外
                            If .strWfId <> vbNullString And _
                                .strWFChipCurrentOutQuantity <> vbNullString And _
                                .strWFChipCurrentForwardQuantity <> vbNullString And _
                                .strWFChipQuantity <> vbNullString Then
                            
                                '@不良/払出混成でWFの全ﾁｯﾌﾟ登録しようとしているか(登録不良0以上、かつ登録払出0以上、かつ良品ﾁｯﾌﾟ0)
                                If .strWFChipCurrentOutQuantity > 0 And _
                                    .strWFChipCurrentForwardQuantity > 0 And _
                                    .strWFChipQuantity = 0 Then
                    
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009L, .strWfId)
                                    '@"<TRM9LW>$$不良/払出コード混成での全数登録は出来ません。$設定を見直してください。ウェハ[%1]"
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    
                                    Exit Function
                                End If
                            End If
                        End With
                    Next llngCnt


                    '@ﾁｯﾌﾟ情報一覧の良品数が0以下か
                    If vsfChipCnt.GetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntWF) <= CPstrZero Then
                        
                        '@-----------------------
                        '@ 全不良か全払出かの判定
                        '@-----------------------
                        '@総不良数が1以上か
                        If vsfChipCnt.GetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntWF) > CPstrZero And _
                            vsfChipCnt.GetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF) <= CPstrZero Then
                            '@全不良
                            
                            '@不良存在判定ﾌﾗｸﾞに"True:不良あり"をｾｯﾄ
                            mblnFuryouClass = True
                        Else
                            '@全払出
                        
                            '@払出存在判定ﾌﾗｸﾞに"True:払出あり"をｾｯﾄ
                            mblnHaraidashiClass = True
                        End If
                    End If


                '@〓 その他 〓
                Case Else
                    
                    '@ｴﾗｰ判定ﾌﾗｸﾞの初期化
                    lblnErrKbn = False

                    For llngCnt = 0 To CMlngvsfWFMapMaxSlotID - 1
                    
                        '@WFIDがNULL以外か
                        If mtypWFInfo(llngCnt).strWfId <> vbNullString Then
                        
                            '@良品数が0か
                            If mtypWFInfo(llngCnt).strWFChipQuantity = CPstrZero Then
                                
                                '@ｴﾗｰ判定ﾌﾗｸﾞに"True:ｴﾗｰあり"をｾｯﾄ
                                lblnErrKbn = True
                                Exit For
                            End If
                        End If
                    Next llngCnt
                    
                    '@ｴﾗｰ判定ﾌﾗｸﾞが"True:ｴﾗｰあり"か
                    If lblnErrKbn = True Then
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009A, mtypWFInfo(llngCnt).strWfId)
                        '@"<TRM9AW>$$ロット状態が[処理中/後処理]ではない為、全数不良(払出)入力することはできません。$設定を見直してください。WFID[%1]"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ｴﾗｰ行検索
                        llngRow = vsfWFMap.FindRow(mtypWFInfo(llngCnt).strWfId, vsfWFMap.Rows.Fixed, CMlngvsfWFMapID, True, True, False)
                        
                        '@ｴﾗｰ行がﾃﾞｰﾀ行か
                        If llngRow <> -1 Then

                            '@ｴﾗｰ行にﾌｫｰｶｽをｾｯﾄする
                            With vsfWFMap
                                .Row = llngRow
                                .Col = CMlngvsfWFMapID
                                .Select(.Row, .Col)
                            End With
                        End If
                        
                        Exit Function
                    End If

            End Select
            
            '@戻り値に"True:ﾁｪｯｸOK"をｾｯﾄ
            prvblnRegistInput_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvblnRegistInput_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvRegistDataSet_Proc
    '機　能：登録情報格納処理
    '引　数：ltypLotInsprst ：登録構造体
    '戻り値：なし
    '作成日：2004/03/31 (Wed) 13:08:11 T.Kitagawa
    '更新日：2009/03/31 (Tue) 14:37:53 N.Kojima
    '備　考：
    '　　　：2007/02/13 (Tue) 16:39:28 N.Kasai      処理区分追加
    '　　　：2008/04/30 (Wed) 12:42:42 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2009/03/31 (Tue) 14:37:53 N.Kojima     ﾁｯﾌﾟ払出対応に伴い処理追加/変更。(案件№03434)
    Private Sub prvRegistDataSet_Proc(ByRef ltypLotInsprst As LotInsprst)
        
        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ(ｽﾛｯﾄ数)
        Dim llngCnt2                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt3                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lstrOldWFID             As String       'WFID退避用(ｺﾝﾄﾛｰﾙﾌﾞﾚｲｸ用)

        Try
            
            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①ﾁｯﾌﾟ状態変更登録ﾒｯｾｰｼﾞ送信ﾃﾞｰﾀの作成
            '@======================================================================================


            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotInsprst
                
                .strLotID = lblLotID.Text                            'ﾛｯﾄID
                .strEngEmpId = pstrUserID                               '作業者ID
                .strLotLastUpdate = mstrLotLastUpdate                   '最終更新日時
                .strClassDivision = CPstrCD1T                           'ﾁｯﾌﾟ状態変更
                
                '@WF情報、ﾁｯﾌﾟ情報
                .lngListCnt = 0
                lstrOldWFID = vbNullString
                
                '@ｽﾛｯﾄ№分ﾙｰﾌﾟ
                For llngCnt = 0 To CMlngvsfWFMapMaxSlotID - 1
                    
                    '@WFIDがNULL以外か
                    If mtypWFInfo(llngCnt).strWfId <> vbNullString Then
                        
                        '@ﾁｯﾌﾟﾏｯﾌﾟの最大行数分ﾙｰﾌﾟ
                        For llngCnt2 = 0 To mlngChipGridMaxRows - 1
                            
                            '@ﾁｯﾌﾟﾏｯﾌﾟの最大列数分ﾙｰﾌﾟ
                            For llngCnt3 = 0 To mlngChipGridMaxCols - 1
                                
                                '@現工程変更前区分と現工程変更後区分が異なる、または変更前後の区分IDが異なるか
                                If mtypWFInfo(llngCnt).typChipList(llngCnt2, llngCnt3).strOldClass <> _
                                    mtypWFInfo(llngCnt).typChipList(llngCnt2, llngCnt3).strNewClass _
                                    Or _
                                    mtypWFInfo(llngCnt).typChipList(llngCnt2, llngCnt3).strOldClassID <> _
                                    mtypWFInfo(llngCnt).typChipList(llngCnt2, llngCnt3).strNewClassID Then
                                    
                                    '@前WFID(lstrOldWFID)と比較し、WFIDが違う場合はWF構造体を追加する
                                    If mtypWFInfo(llngCnt).strWfId <> lstrOldWFID Then
                                        
                                        '@-----------------------
                                        '@ WF情報を設定
                                        '@-----------------------
                                        .lngListCnt = .lngListCnt + 1
                                        If IsNothing(.typWfList) Then
                                            .typWfList = New List(Of LotInsprstWF)()
                                        End If
                                        Dim tmp As LotInsprstWF = New LotInsprstWF()
                                        With tmp
                                            
                                            .strWfId = mtypWFInfo(llngCnt).strWfId                      'WFID
                                            .strSlotPosition = mtypWFInfo(llngCnt).strSlotPosition      'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                                            .strClassID = mtypWFInfo(llngCnt).strClassID                '区分
                                            .strClass = mtypWFInfo(llngCnt).strClass                    '区分ID
                                            
                                            '@ﾁｯﾌﾟ件数の初期化
                                            .lngListCnt = 0
                                        End With
                                        .typWfList.Add(tmp)
                                        
                                        '@WFID退避
                                        lstrOldWFID = mtypWFInfo(llngCnt).strWfId
                                    End If
                                    
                                    '@-----------------------
                                    '@ ﾁｯﾌﾟ情報を設定
                                    '@-----------------------
                                    Dim tmpLotInsprstWF As LotInsprstWF = .typWfList(.lngListCnt-1)
                                    tmpLotInsprstWF.lngListCnt = .typWfList(.lngListCnt-1).lngListCnt + 1
                                    If IsNothing(tmpLotInsprstWF.typChipList) Then
                                        tmpLotInsprstWF.typChipList = New List(Of LotInsprstChip)()
                                    End If
                                    Dim tmpLotInsprstChip As LotInsprstChip = New LotInsprstChip()
                                    
                                    With tmpLotInsprstChip
                                        
                                        .strChipId = mtypWFInfo(llngCnt).typChipList(llngCnt2, llngCnt3).strChipId          'ﾁｯﾌﾟID
                                        .strClass = mtypWFInfo(llngCnt).typChipList(llngCnt2, llngCnt3).strNewClass         '現工程変更後区分
                                        .strClassID = mtypWFInfo(llngCnt).typChipList(llngCnt2, llngCnt3).strNewClassID     '現工程変更後区分ID

                                    End With
                                    tmpLotInsprstWF.typChipList.Add(tmpLotInsprstChip)
                                    

                                    '@★ 登録区分により処理分岐 ★
                                    Select Case tmpLotInsprstWF.typChipList(tmpLotInsprstWF.lngListCnt-1).strClass
                                        
                                        '@〓 2：不良 〓
                                        Case CPstrTwo
                                        
                                            '@登録不良数が数値か
                                            If tmpLotInsprstWF.strRegistChipOutNum <> vbNullString Then
                                                '@初回以降は数値なので下記の処理
                                                
                                                '@SVﾁｪｯｸ用に不良数をﾌﾟﾗｽ
                                                tmpLotInsprstWF.strRegistChipOutNum = _
                                                    tmpLotInsprstWF.strRegistChipOutNum + 1
                                            Else
                                                '@初回はNULLなので"0"ｸﾘｱしてから+1
                                                
                                                '@SVﾁｪｯｸ用に不良数をﾌﾟﾗｽ
                                                tmpLotInsprstWF.strRegistChipOutNum = CPstrZero
                                                tmpLotInsprstWF.strRegistChipOutNum = _
                                                    tmpLotInsprstWF.strRegistChipOutNum + 1
                                            End If
                                        
                                        '@〓 3：払出 〓
                                        Case CPstrThree
                                        
                                            '@登録不良数が数値か
                                            If tmpLotInsprstWF.strRegistChipForwardNum <> vbNullString Then
                                                '@初回以降は数値なので下記の処理
                                                
                                                '@SVﾁｪｯｸ用に不良数をﾌﾟﾗｽ
                                                tmpLotInsprstWF.strRegistChipForwardNum = _
                                                    tmpLotInsprstWF.strRegistChipForwardNum + 1
                                            Else
                                                '@初回はNULLなので"0"ｸﾘｱしてから+1

                                                tmpLotInsprstWF.strRegistChipForwardNum = CPstrZero
                                                
                                                '@SVﾁｪｯｸ用に不良数をﾌﾟﾗｽ
                                                tmpLotInsprstWF.strRegistChipForwardNum = _
                                                    tmpLotInsprstWF.strRegistChipForwardNum + 1
                                            End If
                                        
                                    End Select
                                    .typWfList(.lngListCnt-1) = tmpLotInsprstWF
                                End If
                            Next llngCnt3
                        Next llngCnt2
                    End If
                    
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvRegistDataSet_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnRegistAuthority_Chk
    '機　能：WF不良/払出(1WF全ﾁｯﾌﾟ不良/払出)権限ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True:成功、False:失敗
    '作成日：2008/04/22 (Tue) 15:18:39 N.Kojima
    '更新日：2012/12/17 (Mon) 10:57:44 T.Oide
    '備　考：
    '　　　：2009/08/11 (Tue) 10:55:59 N.Kojima     案件№03542対応のついでにｿｰｽ整備。
    Private Function prvblnRegistAuthority_Chk() As Boolean
        
        Dim lstrFunctionID          As String       '機能ID
        Dim lstrActionID            As String       'ｱｸｼｮﾝID
        Dim lstrWkEmpID             As String       '作業者ID(退避用)
        Dim lstrEmpName             As String       '作業者名
        Dim lblnAuthorityCheckFlag  As Boolean      '権限ﾁｪｯｸ制御ﾌﾗｸﾞ(True：権限ﾁｪｯｸを行なう、Flase：権限ﾁｪｯｸを行なわない)
        Dim lblnAns                 As Boolean      '戻り値格納用

        Try

            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①ﾕｰｻﾞｰの所属ｸﾞﾙｰﾌﾟ(LINE、STAFF等)によりﾁｯﾌﾟ状態変更登録の実行権限ﾁｪｯｸを行う
            '@======================================================================================


            '@戻り値を初期化する
            prvblnRegistAuthority_Chk = False

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Function
            End If
            
            '@作業者IDを退避
            lstrWkEmpID = pstrUserID
            
            '@***************************
            '@ 権限ﾁｪｯｸが必要か判定する
            '@***************************
            '@★ 所属ｸﾞﾙｰﾌﾟIDにより処理分岐 ★
            Select Case pstrGroupID
            
        '@↓2012/12/17 (Mon) 10:47:50 T.Oide **************************************************
        '@        '@〓 STAFF(技術) 〓
        '@        Case CPstrDeptIDStaff
        '@
        '@            '@職場IDが"STAFF"で、かつ登録ﾃﾞｰﾀに"不良"が存在するか
        '@            If mblnFuryouClass = True Then
        '@                '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
        '@                lblnAuthorityCheckFlag = True
        '@            End If
        '@
        '@        '@〓 LINE(製造) 〓
        '@        Case CPstrDeptIDLine
        '@
        '@            '@職場IDが"LINE"で、かつ登録ﾃﾞｰﾀに"払出"が存在するか
        '@            If mblnHaraidashiClass = True Then
        '@                '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
        '@                lblnAuthorityCheckFlag = True
        '@            End If
        '@ -----------------------------------------------------------------------------------

                '@〓 STAFF(技術) 〓,〓 LINE(製造) 〓
                Case CPstrDeptIDStaff, CPstrDeptIDLine
                
                    '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
                        lblnAuthorityCheckFlag = True
                    
        '@↑2012/12/17 (Mon) 10:47:50 T.Oide **************************************************
                    
                '@〓 その他(現在はSYSTEMのみ) 〓
                Case Else

                    '@職場IDが"STAFF"or"LINE"以外で、かつ登録ﾃﾞｰﾀに"不良"or"払出"が存在するか
                    If mblnFuryouClass = True Or mblnHaraidashiClass = True Then
                        '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
                        lblnAuthorityCheckFlag = True
                    End If
                    
            End Select
                    
            '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
            If lblnAuthorityCheckFlag = True Then
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ ﾊﾟｽﾜｰﾄﾞ付き作業者ｺｰﾄﾞ入力画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                With frmxxCM0020.Instance
                    .txtUserID.Text = lstrWkEmpID
                    .txtUserID.Enabled = False
                    Call .ShowDialog(Me)
                End With
                frmxxCM0020.Instance = Nothing
                
                '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
                If pblnCancel = True Then
                    Exit Function
                End If
                
                '@実行権限の処理を追加
                lstrFunctionID = mstrLocalMenuKey           '機能ID：EN0190orEN01Q0(ﾁｯﾌﾟ状態変更登録 上書き禁止or上書き)
                lstrActionID = CPstrWFStatusChange          'ｱｸｼｮﾝID：不良/払出
                lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名：NULL
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrPrvblnRegistAuthorityChk)
                
                '@=======================
                '@ 実行権限ﾁｪｯｸ処理
                '@=======================
                lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                           lstrActionID, _
                                           pstrUserID, _
                                           lstrEmpName, _
                                           pstrSBID)

                '@処理結果が"False:異常"か
                If lblnAns = False Then
                    '@結果：異常の場合
            
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrPrvblnRegistAuthorityChk)
            
                    '@「<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                    Exit Function
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvblnRegistAuthorityChk)
            End If

            '@戻り値に"True:権限ﾁｪｯｸOK"をｾｯﾄ
            prvblnRegistAuthority_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvblnRegistAuthority_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvAnyControlDisable_Proc
    '機　能：不良ﾁｯﾌﾟ情報(№表示)起動時のｺﾝﾄﾛｰﾙ無効化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/09/02 (Wed) 19:17:04 N.Kojima
    '更新日：2009/09/02 (Wed) 19:17:04 N.Kojima
    '備　考：
    Private Sub prvAnyControlDisable_Proc()

        Try

            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①各ｺﾝﾄﾛｰﾙの無効化処理
            '@======================================================================================


            '@-----------------------
            '@ 各種ｺﾝﾄﾛｰﾙ無効化
            '@-----------------------
            optProcessKbn1.Enabled = False          'ﾁｯﾌﾟ登録
            optProcessKbn2.Enabled = False          '電特
            optProcessKbn3.Enabled = False          'WAIST

            vsfScpList.Enabled = False              '不良ｺｰﾄﾞ一覧

            cmdRegist.Enabled = False               '確定
            cmdClear.Enabled = False                '取消
            cmdTekiyouClear.Enabled = False         '適用取消
            cmdKeikouTekiyou.Enabled = False        '傾向適用
            cmdFuryouTekiyou.Enabled = False        '不良(払出)適用
            cmdNowStepNG.Enabled = False            '現不良
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvAnyControlDisable_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvEltMapGet
    '機　能：電特マップ取得表示
    '引　数：なし
    '戻り値：
    '作成日：2011/08/25 (Thu) 15:03:24 T.Oide
    '更新日：2011/08/25 (Thu) 15:03:24
    '備　考：
    '　　　：R8-3無機異物Map登録の対応でcmdMapDownLoad_Clickから分離
    Private Sub prvEltMapGet()

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrWFID                As String               'WFID
        Dim ltypEltMapget           As EltMapget            '電特結果要求構造体
        Dim ltypWFMapInfo           As WFMapInfo            'WFﾏｯﾌﾟ情報構造体
        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngWFListCnt           As Integer              '電特結果WFﾘｽﾄ数ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①電特結果取得処理
            '@　　②電特結果別、ｴﾗｰ処理
            '@　　③各種情報取得処理(WFﾏｯﾌﾟ情報取得、ﾛｯﾄ現在状態取得
            '@　　④WFﾏｯﾌﾟ情報の設定処理、電特結果表示処理
            '@======================================================================================
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdMapDownLoadClick)
            
            '@選択WFのWFIDをｾｯﾄする
            lstrWFID = mtypWFInfo(mlngWFNowIndex-1).strWfId
            
            '@ﾁｯﾌﾟ現不良品数計算値の初期化
            'llngCrrentChipNGCnt = 0
            
            '@=======================
            '@ 【電特結果要求】ﾒｯｾｰｼﾞ送受信処理
            '@=======================
            lblnAns = pubblnElt_Mapget_Sel(CMstrelt_mapget__Ver, _
                                           lstrWFID, _
                                           ltypEltMapget)

            '@通信結果が"True:正常"か
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdMapDownLoadClick)
                
                '@OKの場合WFIDのﾊﾞｯｸｶﾗｰを水色に変更する
                Dim newStyle_BC_ResultOKColor As CellStyle = vsfWFMap.Styles.Add("CustomStyle_BackColor_CMlngResultOKColor")
                newStyle_BC_ResultOKColor.BackColor = ColorTranslator.FromWin32(CMlngResultOKColor)
                '@NGの場合WFIDのﾊﾞｯｸｶﾗｰをﾋﾟﾝｸに変更する
                Dim newStyle_BC_EnableTrueColor As CellStyle = vsfWFMap.Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor")
                newStyle_BC_EnableTrueColor.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                '@NULLの場合WFIDのﾊﾞｯｸｶﾗｰを白に変更する
                Dim newStyle_BC_ResultNGColor As CellStyle = vsfWFMap.Styles.Add("CustomStyle_BackColor_CMlngResultNGColor")
                newStyle_BC_ResultNGColor.BackColor = ColorTranslator.FromWin32(CMlngResultNGColor)
                Dim cellRange As CellRange

                For llngWFListCnt = 0 To ltypEltMapget.lngCnt - 1

                    cellRange = vsfWFMap.GetCellRange(vsfWFMap.Row, CMlngvsfWFMapID, vsfWFMap.Row, CMlngvsfWFMapDestNo)
                    
                    '@★ 電特結果(ﾘｽﾄは常に1件)により処理分岐 ★
                    Select Case ltypEltMapget.typEltMapgetWFList(llngWFListCnt).strResult
                        
                        '@〓 結果:OK 〓
                        Case CMstrResultOK
                    
                            '@OKの場合WFIDのﾊﾞｯｸｶﾗｰを水色に変更する
                            cellRange.Style = newStyle_BC_ResultOKColor
                        
                            '@表示ﾒｯｾｰｼﾞ変換("<TRM2LI>$$ウエハ[%1]の電特マップ情報の読込に成功しました。")
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002L, lstrWFID)
                        
                        
                        '@〓 結果:NG 〓
                        Case CMstrResultNG

                            '@NGの場合WFIDのﾊﾞｯｸｶﾗｰをﾋﾟﾝｸに変更する
                            cellRange.Style = newStyle_BC_EnableTrueColor
                    
                            '@表示ﾒｯｾｰｼﾞ変換("<TRM2NI>$$ウエハ[%1]の電特マップ情報の判定でNGになりました。$電特結果コメント：%2")
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002N, lstrWFID, ltypEltMapget.typEltMapgetWFList(llngWFListCnt).strComments)
                    
                    
                        '@〓 結果:NULL 〓
                        Case vbNullString
                        
                            '@NULLの場合WFIDのﾊﾞｯｸｶﾗｰを白に変更する
                            cellRange.Style = newStyle_BC_ResultNGColor
                                
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM2MI>$$ウエハ[%1]の電特マップ情報はまだ存在しません。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002M, lstrWFID)
                            Call pubVsfInfo_Disp(pstrDMsg)
                            
                            Exit For
                            
                    End Select


                    For llngCnt = 1 To CMlngvsfWFMapMaxSlotID
                    
                        '@選択WFIDと電特結果のWFIDが同じか
                        If lstrWFID = mtypWFInfo(CMlngvsfWFMapMaxSlotID - llngCnt).strWfId Then
                            
                            '@結果を格納
                            mtypWFInfo(CMlngvsfWFMapMaxSlotID - llngCnt).strResult _
                                = ltypEltMapget.typEltMapgetWFList(llngWFListCnt).strResult
                            
                            Exit For
                        End If
                    Next llngCnt
                    
                    
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrCmdMapDownLoadClick)
                    
                    '@=======================
                    '@ 【WFﾏｯﾌﾟ情報取得】ﾒｯｾｰｼﾞ送受信処理
                    '@=======================
                    lblnAns = pubblnWFMapInfo_Sel(CMstrwf__mapinfo_Ver, _
                                                  lblLotID.Text, _
                                                  lstrWFID, _
                                                  ptypLotprestate.strVaFlag, _
                                                  ptypLotprestate.strTpalClass, _
                                                  ltypWFMapInfo)
                    
                    '@通信結果が"True:正常"か
                    If lblnAns = True Then
                        '@結果：正常の場合

                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdMapDownLoadClick)

                        '@=======================
                        '@ 電特ﾌｧｲﾙ読込時のﾁｯﾌﾟﾏｯﾌﾟ設定処理
                        '@=======================
                        Call prvWFMapDenInfo_Set(ltypWFMapInfo)
                    
                    Else
                        '@結果：異常の場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdMapDownLoadClick)
                        Exit Sub
                    End If

                    'ﾛｯﾄの良品数等を表示する
                    Call prvChipNumDisp()
                    
                    '@=======================
                    '@ 電特結果表示処理
                    '@=======================
                    Call prvChipMapElectric_Set()
                            
                    '@ﾛｯﾄ現在状態取得ﾒｯｾｰｼﾞで取得した日時を格納
                    mstrLotLastUpdate = ptypLotprestate.strLotLastUpdate
          
                    '@ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)

                Next llngWFListCnt

            Else
                '@結果：異常の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdMapDownLoadClick)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvEltMapGet"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVfiMapGet
    '機　能：電特マップ取得表示
    '引　数：なし
    '戻り値：
    '作成日：2011/08/25 (Thu) 15:03:24 T.Oide
    '更新日：
    '備　考：
    '　　　：R8-3無機異物Map登録の対応
    Private Sub prvVfiMapGet()

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrWFID                As String               'WFID
        Dim ltypWaferList           As Waferlist            'WFlist
        Dim llngWFNowIndex          As Integer              '選択中のｽﾛｯﾄ

        Try

            '@画面の使用禁止
            Me.KeyPreview = False
                    
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdMapDownLoadClick)
            
            '@選択WFのWFIDを退避する
            lstrWFID = mtypWFInfo(mlngWFNowIndex-1).strWfId
            
            
            '@=======================
            '@ 【無機異物検査Map取得】ﾒｯｾｰｼﾞ送受信処理
            '@=======================
            lblnAns = pubblnElt_VFIMapget_Sel(CMstrelt_vfimapgetVer, _
                                              CPstrCD01, lstrWFID)

            '@通信結果が"True:正常"か
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdMapDownLoadClick)
                
                '@WFｽﾛｯﾄﾏｯﾌﾟ選択行用に退避
                llngWFNowIndex = mlngWFNowIndex

                '@********************
                '@　WFｽﾛｯﾄﾏｯﾌﾟの設定
                '@********************
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrCmdMapDownLoadClick)
                
                
                '@=======================
                '@ 【ﾛｯﾄWFﾏｯﾌﾟ情報取得】ﾒｯｾｰｼﾞ送受信処理
                '@ ※処理区分=3N：ﾛｯﾄｳｪﾊ情報取得(全WF)
                '@=======================
                lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                                 txtCarrier.Text, _
                                                 CPstrCD3N, _
                                                 ltypWaferList)

                '@画面の使用禁止解除
                Me.KeyPreview = True

                '@ｽﾛｯﾄｻｲｽﾞ退避
                mstrSlotSize = ltypWaferList.strSlotSize
                
                '@通信結果が"True:正常"か
                If lblnAns = True Then
                    '@結果：正常の場合
                
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmdMapDownLoadClick)
                
                    '@=======================
                    '@ WFｽﾛｯﾄﾏｯﾌﾟの設定処理
                    '@=======================
                    Call prvLotWaferInfo_Set(ltypWaferList)
                    
                    '@選択行を設定する(vsfWFMap_EnterCellを呼ぶ→Map情報表示)
                    vsfWFMap.Row = CLng(CMlngvsfWFMapMaxSlotID) - llngWFNowIndex + 1
                
                    'ﾛｯﾄの良品数等を表示する
                    Call prvChipNumDisp()
                    
                    '@ﾛｯﾄ現在状態取得ﾒｯｾｰｼﾞで取得した日時を格納
                    mstrLotLastUpdate = ptypLotprestate.strLotLastUpdate

                Else
                    '@結果：異常の場合
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdMapDownLoadClick)
                    Exit Sub
                End If

                '@ﾒｯｾｰｼﾞ表示(<TRM77I>$$ウエハ[%1]の異物検査機マップ情報の読込に成功しました。)
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0077, lstrWFID)
                Call pubVsfInfo_Disp(pstrDMsg)

            Else
                '@結果：異常の場合
            
                '@画面の使用禁止解除
                Me.KeyPreview = True
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdMapDownLoadClick)
            End If
                
                
            Exit Sub

        Catch ex As Exception

            '@画面の使用禁止解除
            Me.KeyPreview = True
                
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvEltMapGet"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvChipNumDisp
    '機　能：ﾛｯﾄの良品数、総不良数、現工程不良数等を表示する
    '引　数：なし
    '戻り値：
    '作成日：2011/08/29 (Mon) 14:07:42 T.Oide
    '更新日：2011/08/29 (Mon) 14:07:42
    '備　考：
    '      ：R8-3無機異物Map登録の対応
    Private Sub prvChipNumDisp()

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)

        Try
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdMapDownLoadClick)

            '@=======================
            '@ 【ﾛｯﾄ現在情報取得】ﾒｯｾｰｼﾞ送受信処理
            '@ ※処理区分=1T：ﾛｯﾄ現在状態取得(ﾁｯﾌﾟ処置登録)
            '@=======================
            lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                            CPstrCD1T, _
                                            txtCarrier.Text, _
                                            ptypLotprestate)

            '@通信結果が"True:正常"か
            If lblnAns = True Then
                '@結果：正常の場合

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdMapDownLoadClick)

                '@ﾛｯﾄの良品、総不良、現不良、総払出、現払出の数量の再表示
                With ptypLotprestate

                    '@-----------------------
                    '@ ﾁｯﾌﾟ良品数
                    '@-----------------------
                    vsfChipCnt.SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot, 0)
                    If IsNumeric(.strChipQuantity) = True Then
                        vsfChipCnt.SetData(CMlngvsfChipCntOKRow, CMlngvsfChipCntLot, Format(CInt(.strChipQuantity), CPstrDateFormatKanma))
                    End If
                    
                    '@-----------------------
                    '@ ﾁｯﾌﾟ総不良数
                    '@-----------------------
                    vsfChipCnt.SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntLot, 0)
                    If IsNumeric(.strChipOutQuantity) = True Then
                        vsfChipCnt.SetData(CMlngvsfChipCntAllNGRow, CMlngvsfChipCntLot, Format(CInt(.strChipOutQuantity), CPstrDateFormatKanma))
                    End If
                    
                    '@-----------------------
                    '@ ﾁｯﾌﾟ現不良数
                    '@-----------------------
                    vsfChipCnt.SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot, 0)
                    If IsNumeric(.strChipCurrentOutQuantity) = True Then
                        vsfChipCnt.SetData(CMlngvsfChipCntNowNGRow, CMlngvsfChipCntLot, Format(CInt(.strChipCurrentOutQuantity), CPstrDateFormatKanma))
                        ptypLotScrapInfo.strLotOutQuantity = .strChipCurrentOutQuantity
                    End If

                    '@-----------------------
                    '@ ﾁｯﾌﾟ総払出数
                    '@-----------------------
                    vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, 0)
                    If IsNumeric(.strChipForwardQuantity) = True Then
                        vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, Format(CInt(.strChipForwardQuantity), CPstrDateFormatKanma))
                        ptypLotScrapInfo.strLotForwardQuantity = .strChipForwardQuantity
                    End If

                    '@-----------------------
                    '@ ﾁｯﾌﾟ現払出数
                    '@-----------------------
                    vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, 0)
                    If IsNumeric(.strChipCurrentForwardQuantity) = True Then
                        vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, Format(CInt(.strChipCurrentForwardQuantity), CPstrDateFormatKanma))
                        ptypLotScrapInfo.strLotForwardQuantity = .strChipCurrentForwardQuantity
                    End If

                    '@起動SBが基板か
                    If pstrSBID = CPstrSBID1A0 Then
                    
                        '@払出数行は"-"で表示
                        vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntLot, CPstrMinus)
                        vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntLot, CPstrMinus)
                        vsfChipCnt.SetData(CMlngvsfChipCntAllFWRow, CMlngvsfChipCntWF, CPstrMinus)
                        vsfChipCnt.SetData(CMlngvsfChipCntNowFWRow, CMlngvsfChipCntWF, CPstrMinus)
                    End If
                End With
                
            Else
                '@結果：異常の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdMapDownLoadClick)
                
            End If
            
            Exit Sub
                
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvChipNumDisp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvExclusionProcess
    '機　能：抜取・全数ﾒｯｾｰｼﾞ送受信処理
    '引　数：なし
    '戻り値：
    '作成日：2020/03/19 (Thu) 16:13:35 Y.Yoneyama 「.Netへ反映未」
    '更新日：
    '備　考：
    Private Sub prvExclusionProcess()
        
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ
        Dim lblnChkExclusionProAns  As Boolean              '抜取検査結果格納(案件No:03609)
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
    
        Try
            '@ﾊﾟﾈﾙ検査専用
            If Mid$(ptypLotprestate.strWpID, 1, 7) <> CPstrPakenWpId Then
                Exit Sub
            End If
    
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvExclusionProcess)
                
            '@=======================
            '@ 抜取・全数確認処理
            '@=======================
            '@【抜取・全数ﾁｪｯｸ】ﾒｯｾｰｼﾞ送受信処理
            lblnChkExclusionProAns = pubblnLotExclusionProcess_Chk(CMstrlot_chkexclusionprocessVer, _
                                                                lblLotID.Text, _
                                                                lstrGuidMsg, _
                                                                lstrGuidMsgCode, _
                                                                mstrPanelInspectType)
    
            '@抜取・全数ﾁｪｯｸ結果が"True：ﾁｪｯｸ処理成功"か
            If lblnChkExclusionProAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvExclusionProcess)
    
                '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞがNULL以外か
                If lstrGuidMsgCode <> vbNullString Then
    
                    '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                    lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                            CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                            CPstrMsgCrCode & lstrGuidMsg
    
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「上記編集済みｶﾞｲﾀﾞﾝｽMsg」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If
                
            '@結果：異常の場合
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvExclusionProcess)
            End If
                    
            '@ﾊﾟﾈﾙ検査種類表示
            Call prvPanelInspectVisble
    
            Exit Sub
        
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvExclusionProcess"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try

    End Sub

    '関数名：prvPanelInspectVisble
    '機　能：ﾊﾟﾈﾙ検査種類表示
    '引　数：なし
    '戻り値：
    '作成日：2020/03/19 (Thu) 16:13:35 Y.Yoneyama 「.Netへ反映未」
    '更新日：
    '備　考：
    Private Sub prvPanelInspectVisble()
    
        Try

            '@検査ﾀｲﾌﾟ無の場合
            If mstrPanelInspectType = vbNullString Then
                '@非表示
                lblPanelInspectType.Visible = False
                Exit Sub
            End If
    
            Select Case mstrPanelInspectType
        
                '@全数検査
                Case CPstrPanelInspectAll
                    lblPanelInspectType.Text = "全数" + vbCr + "検査"
                    lblPanelInspectType.ForeColor = Color.Red
                    lblPanelInspectType.BackColor = Color.Yellow
            
                '@抜取検査
                Case CPstrPanelInspectDecimate
                    lblPanelInspectType.Text = "抜取" + vbCr + "検査"
                    lblPanelInspectType.ForeColor = Color.Blue
                    lblPanelInspectType.BackColor = Color.LightGreen
            
                Case Else
                    Exit Sub
    
            End Select
    
            '@非表示
            lblPanelInspectType.Visible = True
    
            Exit Sub
        
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvPanelInspectVisble"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfChipCnt.BeforeDoubleClick, vsfChipMap.BeforeDoubleClick, vsfScpList.BeforeDoubleClick, vsfWFMap.BeforeDoubleClick

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

    '関数名：lblFuryou_Paint
    '機　能：lblFuryouのPaintイベント処理
    '作成日：2019/07/02 (Tue) 20:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub lblFuryou_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles lblFuryou.Paint

        Dim lbl As Label = DirectCast(sender, Label)

        '背景色設定 不良色,自工程不良色
        e.Graphics.FillRectangle(New SolidBrush(lblFuryouOld.BackColor),0,0,lbl.Width,CSng(lbl.Height\2))
        e.Graphics.FillRectangle(New SolidBrush(lblFuryouNew.BackColor),0,CSng(lbl.Height\2),lbl.Width,CSng(lbl.Height\2))
        'テキスト描画
        e.Graphics.DrawString(lbl.Text, lbl.Font, New SolidBrush(lbl.ForeColor), 0, 0)

    End Sub

    '関数名：lblKeikou_Paint
    '機　能：lblKeikouのPaintイベント処理
    '作成日：2019/07/02 (Tue) 20:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub lblKeikou_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles lblKeikou.Paint

        Dim lbl As Label = DirectCast(sender, Label)

        '背景色設定 傾向色,自工程傾向色
        e.Graphics.FillRectangle(New SolidBrush(lblKeikouOld.BackColor), 0, 0, lbl.Width, lbl.Height\2)
        e.Graphics.FillRectangle(New SolidBrush(lblKeikouNew.BackColor), 0, lbl.Height\2, lbl.Width, lbl.Height\2)
        'テキスト描画
        e.Graphics.DrawString(lbl.Text, lbl.Font, New SolidBrush(lbl.ForeColor), 0, 0)

    End Sub

    '関数名：lblHaraidashi_Paint
    '機　能：lblHaraidashiのPaintイベント処理
    '作成日：2019/07/02 (Tue) 20:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub lblHaraidashi_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles lblHaraidashi.Paint

        Dim lbl As Label = DirectCast(sender, Label)

        '背景色設定 払出色,自工程払出色
        e.Graphics.FillRectangle(New SolidBrush(lblHaraidashiOld.BackColor), 0, 0, lbl.Width, lbl.Height\2)
        e.Graphics.FillRectangle(New SolidBrush(lblHaraidashiNew.BackColor), 0, lbl.Height\2, lbl.Width, lbl.Height\2)
        'テキスト描画
        e.Graphics.DrawString(lbl.Text, lbl.Font, New SolidBrush(lbl.ForeColor), 0, 0)

    End Sub

    '関数名：cursor_Enter	
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。	
    '作成日：2019/07/02 NSYS	
    '更新日：	
    '備　考：Handlesは画面で入力できるすべての項目が対象	
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
        txtCarrier.Enter, txtDmCode.Enter, optProcessKbn1.Enter, optProcessKbn2.Enter, optProcessKbn3.Enter, _
        vsfWFMap.Enter, vsfChipCnt.Enter, vsfScpList.Enter, vsfChipMap.Enter, _
        cmdClose.Enter, cmdComments.Enter, cmdHyouri.Enter, cmdDisplayKbn.Enter, cmdNowStepNG.Enter, cmdMapDownLoad.Enter, _
        cmdFuryouTekiyou.Enter, cmdKeikouTekiyou.Enter, cmdTekiyouClear.Enter, cmdClear.Enter, cmdRegist.Enter 

        '選択されている項目の名前で判定	
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF	
            Case "cmdClose"
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
                '上記以外は自動Validate = ON	
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
