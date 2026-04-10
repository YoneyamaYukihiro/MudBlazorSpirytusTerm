'ﾌｧｲﾙ名：CtsbasxxCM0040.vb
'説　明：共通定数
'作成日：2004/02/13 (Fri) 11:27:50 K.Takano
'更新日：2026/03/12 (Thu) 15:42:00 T.Oide
'　　　："☆☆☆メニュー項目追加時変更対象処理☆☆☆"の記述があるものに
'　　　：適宜修正が必要です。
'Copyright(C)2003-2026, SEIKO EPSON CORPORATION.
Option Explicit On
Imports TFLib
Public Module basxxCM0040
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '@OnError用
    Public Const CPstrSystemName                        As String = "工程管理"      'ｼｽﾃﾑ名

    '@----------------------------------------------
    '@ 汎用定数関連
    '@----------------------------------------------
    '@String型の数字
    Public Const CPstrZero                          As String = "0"                 '汎用定数("0")
    Public Const CPstrOne                           As String = "1"                 '汎用定数("1")
    Public Const CPstrTwo                           As String = "2"                 '汎用定数("2")
    Public Const CPstrThree                         As String = "3"                 '汎用定数("3")
    Public Const CPstrFour                          As String = "4"                 '汎用定数("4")
    Public Const CPstrFive                          As String = "5"                 '汎用定数("5")
    Public Const CPstrSix                           As String = "6"                 '汎用定数("6")
    Public Const CPstrSeven                         As String = "7"                 '汎用定数("7")
    Public Const CPstrEight                         As String = "8"                 '汎用定数("8")
    Public Const CPstrNine                          As String = "9"                 '汎用定数("9")
    Public Const CPstrTen                           As String = "10"                '汎用定数("10")
    Public Const CPstrEleven                        As String = "11"                '汎用定数("11")
    Public Const CPstrTwelveTime                    As String = "12"                '汎用定数("12")
    Public Const CPstrThirteenTime                  As String = "13"                '汎用定数("13")
    Public Const CPstrFourteenTime                  As String = "14"                '汎用定数("14")
    Public Const CPstrFifteenTime                   As String = "15"                '汎用定数("15")
    Public Const CPstrSixteenTime                   As String = "16"                '汎用定数("16")
    Public Const CPstrSeventeenTime                 As String = "17"                '汎用定数("17")
    Public Const CPstrEighteenTime                  As String = "18"                '汎用定数("18")
    Public Const CPstrNineteenTime                  As String = "19"                '汎用定数("19")
    Public Const CPstrTwentyTime                    As String = "20"                '汎用定数("20")
    Public Const CPstrTwentyOneTime                 As String = "21"                '汎用定数("21")
    Public Const CPstrTwentyTwoTime                 As String = "22"                '汎用定数("22")
    Public Const CPstrTwentyThreeTime               As String = "23"                '汎用定数("23")
    Public Const CPstrTwentyFourTime                As String = "24"                '汎用定数("24")
    Public Const CPstrHiphen                        As String = "-"                 '汎用定数("-")
    Public Const CPstrComma                         As String = ","                 '汎用定数(",")

    '@Long型の数字
    Public Const CPlngNumZero                       As Integer = 0                     '汎用定数(0)
    Public Const CPlngNumOne                        As Integer = 1                     '汎用定数(1)
    Public Const CPlngNumTwo                        As Integer = 2                     '汎用定数(2)
    Public Const CPlngNumThree                      As Integer = 3                     '汎用定数(3)
    Public Const CPlngNumFour                       As Integer = 4                     '汎用定数(4)
    Public Const CPlngNumFive                       As Integer = 5                     '汎用定数(5)
    Public Const CPlngNumSix                        As Integer = 6                     '汎用定数(6)
    Public Const CPlngNumSeven                      As Integer = 7                     '汎用定数(7)
    Public Const CPlngNumEight                      As Integer = 8                     '汎用定数(8)
    Public Const CPlngNumNine                       As Integer = 9                     '汎用定数(9)
    Public Const CPlngNumTen                        As Integer = 10                    '汎用定数(10)
    Public Const CPlngNumEleven                     As Integer = 11                    '汎用定数(11)

    '@0ﾌｫｰﾏｯﾄの数字
    Public Const CPstrZeroZero                      As String = "00"                '汎用定数("00")
    Public Const CPstrZeroOne                       As String = "01"                '汎用定数("01")
    Public Const CPstrZeroTwo                       As String = "02"                '汎用定数("02")
    Public Const CPstrZeroThree                     As String = "03"                '汎用定数("03")
    Public Const CPstrZeroFour                      As String = "04"                '汎用定数("04")
    Public Const CPstrZeroFive                      As String = "05"                '汎用定数("05")
    Public Const CPstrZeroSix                       As String = "06"                '汎用定数("06")
    Public Const CPstrZeroSeven                     As String = "07"                '汎用定数("07")
    Public Const CPstrZeroEight                     As String = "08"                '汎用定数("08")
    Public Const CPstrZeroNine                      As String = "09"                '汎用定数("09")

    '@ｽﾍﾟｰｽ
    Public Const CPstrSpace                         As String = " "                 '半角ｽﾍﾟｰｽ
    Public Const CPstrZenkakuSpace                  As String = "　"                '全角ｽﾍﾟｰｽ

    '@特殊記号
    Public Const CPstrAmpersand                     As String = "&"                 'ｱﾝﾊﾟｻﾝﾄﾞ
    Public Const CPstrSharp                         As String = "#"                 'ｼｬｰﾌﾟ
    Public Const CPstrSlash                         As String = "/"                 'ｽﾗｯｼｭ
    Public Const CPstrBracketLeft                   As String = "[ "                '大括弧(左)
    Public Const CPstrBracketRight                  As String = " ]"                '大括弧(右)
    Public Const CPstrBrLeft                        As String = "["                 '大括弧(左)：半角
    Public Const CPstrBrRight                       As String = "]"                 '大括弧(右)：半角
    Public Const CPstrParenthesisLeft               As String = "("                 '小括弧(左)
    Public Const CPstrParenthesisRight              As String = ")"                 '小括弧(右)
    Public Const CPstrHalfUnderScore                As String = "_"                 'ｱﾝﾀﾞｰｽｺｱ(ﾊﾞｰ)：半角
    Public Const CPstrFullUnderScore                As String = "＿"                'ｱﾝﾀﾞｰｽｺｱ(ﾊﾞｰ)：全角
    Public Const CPstrPipeString                    As String = "|"                 'パイプ

    '@----------------------------------------------
    '@ ｺﾝﾎﾞﾎﾞｯｸｽ関連
    '@----------------------------------------------
    Public Const CPstrComboBrank                    As String = " "                 'Comboﾘｽﾄで選択していない表示用定数
    Public Const CPstrComboAppointNo                As String = "指定なし"          'Comboﾘｽﾄで指定していない場合の表示用定数
    Public Const CPlngCmbRowHeight                  As Integer = 43                 'ｺﾝﾎﾞﾎﾞｯｸｽ高さ


    '@----------------------------------------------
    '@ 入力制限関連
    '@----------------------------------------------
    '@桁制限
    Public Const CPlngFoupSlot                      As Integer = 25                    'Foupｽﾛｯﾄ数
    Public Const CPlngPaletteSlot                   As Integer = 18                    'ﾊﾟﾚｯﾄｽﾛｯﾄ数
    Public Const CPlngJPaletteSlot                  As Integer = 5                     '蒸着ｷｬﾘｱｽﾛｯﾄ数
    Public Const CPlngEmpIDLength                   As Integer = 7                     '氏名ｺｰﾄﾞ、作業者ID文字数
    Public Const CPlngCarrierMaxLength              As Integer = 6                     'ｷｬﾘｱIDの最大桁数

    '@ﾃｷｽﾄ文字制限表示
    Public Const CPlngLotCommentsMaxByte            As Integer = 2048                  '作業記録などの最大入力ﾊﾞｲﾄ数
    Public Const CPlngLotCommentsMaxByte4000        As Integer = 4000                  'ﾛｯﾄｺﾒﾝﾄの最大入力ﾊﾞｲﾄ数
    Public Const CPlngWorkMemoMaxByte84             As Integer = 84                    '一部の作業ﾒﾓの最大入力ﾊﾞｲﾄ数
    Public Const CPlngMailContentsMaxByte           As Integer = 2000                  'ﾒｰﾙ本文の最大入力ﾊﾞｲﾄ数
    Public Const CPlngMailContentsMaxByteConnect    As Integer = 1500                  'ﾒｰﾙ本文の最大入力ﾊﾞｲﾄ数(ｺﾒﾝﾄ)
    Public Const CPlngMailSubjectMaxByte            As Integer = 80                    'ﾒｰﾙ件名の最大入力ﾊﾞｲﾄ数

    '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ機能制限文字
    Public Const CPstrMinus                         As String = "－"                '半角ﾏｲﾅｽ
    Public Const CPstrMinusWide                     As String = "─"                '全角ﾏｲﾅｽ
    Public Const CPstrPlus                          As String = "＋"                '半角ﾌﾟﾗｽ
    Public Const CPstrPlusWide                      As String = "┼"                '全角ﾌﾟﾗｽ


    '@----------------------------------------------
    '@ 色の定義(背景色、文字色等で使用)
    '@----------------------------------------------
    Public Const CPlngHoldLotColor                  As Integer = &HFFFF&               '黄色       ：保留/停止ﾛｯﾄ背景色
    Public Const CPlngStopLotColor                  As Integer = &HC0C0FF              '桃色       ：制限時間超過部材の背景色、故障修理記録票24h経過未編集票の背景色
    Public Const CPlngGridDarkGray                  As Integer = &HABABAB              '濃いｸﾞﾚｰ   ：無効系の背景色(ｽﾛｯﾄ等)
    Public Const CPlngGridGray                      As Integer = &HC0C0C0              '薄いｸﾞﾚｰ   ：禁止系の背景色、編集不可ﾃﾞｰﾀの背景色
    Public Const CPlngVbColorRed                    As Integer = &HFF&                 '赤色       ：制限/期限超過の文字色、流動票VerUp禁止の背景色、部分ﾚｼﾋﾟの背景色
    Public Const CPlngVbColorPurple                 As Integer = &H800080              '紫色       ：警告時間超過の文字色
    Public Const CPlngVbColorBlue                   As Integer = &HFF0000              '青色       ：個別処理条件の文字色
    Public Const CPlngInputColor                    As Integer = &HC0C0FF              'ﾋﾟﾝｸ       ：入力可能ｾﾙの背景色
    Public Const CPlngNotInputColor                 As Integer = &HE0E0E0              '薄いｸﾞﾚｰ   ：入力禁止/不可の背景色
    Public Const CPlngVbColorOrange                 As Integer = &H80C0FF              'ｵﾚﾝｼﾞ      ：ﾀﾞﾐｰの背景色
    Public Const CPlngLColor                        As Integer = &HFFFFC0              '水色       ：L/Rの"L"の背景色
    Public Const CPlngRColor                        As Integer = &HC0C0FF              'ﾋﾟﾝｸ       ：L/Rの"R"の背景色
    Public Const CPlngTxtLockColor                  As Integer = &H80000016            'ｸﾞﾚｰ       ：入力(編集)禁止/不可状態の背景色
    Public Const CPlngEnableTrueColor               As Integer = &H80000005            '白色       ：通常表示、使用可状態の背景色
    Public Const CPlngEnableFalseColor              As Integer = &H80000004            'ｸﾞﾚｰ       ：使用不可状態の背景色
    Public Const CPlngEditColor                     As Integer = &HFFFFC0              '水色       ：ｸﾞﾘｯﾄﾞｾﾙ編集時の背景色
    Public Const CPlngSpecialEditColor              As Integer = &H80FF80              'ｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ：ｸﾞﾘｯﾄﾞｾﾙ編集時の背景色(L/R表示で水色を使用している為、別途定義)
    Public Const CPlngNormalForeColor               As Integer = &H80000008            '黒
    Public Const CPlngFrNgColor                     As Integer = &H90EE90              'ﾗｲﾄｸﾞﾘｰﾝ　 ：FR累積時間の範囲外ﾛｯﾄ(ｺﾝﾀｸﾄｴｯﾁｬｰ)時の背景色
    Public Const CPlngTftColor                      As Integer = &H80000005            '白色       ：TFTﾛｯﾄ
    Public Const CPlngCfColor                       As Integer = &HFFFFC0              '水色       ：CFﾛｯﾄ
    Public Const CPlngInspectNg                     As Integer = &HC0C0C0              '薄いｸﾞﾚｰ   ：検査NG
    Public Const CPlngBatchPair                     As Integer = &HFFFF&               '黄色       ：ﾊﾞｯﾁ時対ｷｬﾘｱ

    '@----------------------------------------------
    '@ ﾌｫｰﾏｯﾄ関連
    '@----------------------------------------------
    '@【ﾌｫｰﾏｯﾄ】(ﾌｫﾄF/B)
    Public Const CPstrDoubleFormat1String           As String = "#,##0.0"           '小数点第１位
    Public Const CPstrDoubleFormat2String           As String = "#,##0.00"          '小数点第２位
    Public Const CPstrDoubleFormat3String           As String = "#,##0.000"         '小数点第３位
    Public Const CPstrDoubleFormat4String           As String = "#,##0.0000"        '小数点第４位
    Public Const CPstrDoubleFormat5String           As String = "#,##0.00000"       '小数点第５位
    Public Const CPstrDoubleFormat6String           As String = "#,##0.000000"      '小数点第６位
    Public Const CPstrDoubleFormat7String           As String = "#,##0.0000000"     '小数点第７位
    Public Const CPstrDoubleFormat8String           As String = "#,##0.00000000"    '小数点第８位
    Public Const CPstrDoubleFormat9String           As String = "#,##0.000000000"   '小数点第９位

    '@10m sec ﾌｫｰﾏｯﾄ
    Public Const CPstrMSec                          As String = "0.00"

    '@研磨ﾚｰﾄﾌｫｰﾏｯﾄ
    Public Const CPstrRate                          As String = "0.00"

    '@0表記ﾌｫｰﾏｯﾄ
    Public Const CPstrDateFormatKanma               As String = "#,##0"

    '@ｽﾛｯﾄ№ﾌｫｰﾏｯﾄ
    Public Const CPstrSlotNoFormat                  As String = "00"

    '@ｶﾝﾏ編集解除ﾌｫｰﾏｯﾄ
    Public Const CPstrNoKanmaFormat                 As String = "##0"

    '@CF用(ｶﾝﾏ編集)
    Public Const CPstrCFKnmaFormat                  As String = "#,###"


    '@----------------------------------------------
    '@ 表示ﾀｲﾄﾙ/ﾒｯｾｰｼﾞ関連
    '@----------------------------------------------
    '@表示項目ﾀｲﾄﾙ
    Public Const CPstrDispatchTime                  As String = "処理開始予定"
    Public Const CPstrStartTime                     As String = "処理開始日時"

    '@該当件数
    Public Const CPstrLotCnt0                       As String = "0"

    '@WFﾃﾞｰﾀ読込処理用(ﾁｯﾌﾟ状態変更で使用)
    Public Const CPstrReadWF                        As String = "読み込み対象ウェハ　"
    Public Const CPstrReadComplete                  As String = "枚読み込み完了。"

    '@ｺﾒﾝﾄ文字数表示用
    Public Const CPstrCommentLength                 As String = "( 半角%1文字/半角%2文字 )"

    '@ﾚｼﾋﾟ表示用
    Public Const CPstrRecpMaiyou                    As String = "枚葉レシピ"        'ﾚｼﾋﾟ表記文字列
    Public Const CPstrRecpAll                       As String = "全数"              'ﾚｼﾋﾟ表記文字列
    Public Const CPstrRecppartial                   As String = "部分"              'ﾚｼﾋﾟ表記文字列

    '@有無表示用
    Public Const CPstrAriFlg                        As String = "あり"
    Public Const CPstrNasiFlg                       As String = "なし"

    '@検索開始時間、検索終了時間表示用
    Public Const CPstrSearchStartTime               As String = " 00:00:00"         '00:00:00
    Public Const CPstrSearchEndTime                 As String = " 23:59:59"         '23:59:59

    '@送品伝票、ﾛｯﾄ検定表印刷ﾌｫｰﾑｷｬﾌﾟｼｮﾝ
    Public Const CPstrSendOrderListPrintFormCaption As String = "送品伝票印刷"      '送品伝票印刷
    Public Const CPstrLotExamInfoPrintFormCaption   As String = "ロット検定表印刷"  'ﾛｯﾄ検定表印刷

    '@開発用Errorﾒｯｾｰｼﾞ
    Public Const CPstrDeveErrMsg                    As String = "$$Code [%1]$Description [%2]"               '開発用 Err.Discription

    '@ﾃﾞｰﾀ収集有無表示用
    Public Const CPstrCollectionDataAri             As String = "あり"              'ﾃﾞｰﾀ収集あり
    Public Const CPstrCollectionDataNashi           As String = vbNullString        'ﾃﾞｰﾀ収集なし

    '@一覧系のﾛｯﾄ状態表示用
    Public Const CPstrHo                            As String = "保"                '保留表示
    Public Const CPstrTei                           As String = "停"                '停止表示
    Public Const CPstrKin                           As String = "禁"                '禁止表示
    Public Const CPstrDai                           As String = "代"                '代替表示
    Public Const CPstrIre                           As String = "入"                '入替表示
    Public Const CPstrRi                            As String = "リ"                'ﾘﾜｰｸ表示
    Public Const CPstrIsa                           As String = "移"                '移載表示
    Public Const CPstrTui                           As String = "追"                '追加表示
    Public Const CPstrBatch                         As String = "バ"                'バッチ編成済表示

    '@処理順指定
    Public Const CPstrRecipeFlowFifo                As String = "FIFO"              '0(FIFO)
    Public Const CPstrRecipeFlowNum                 As String = "ﾚｼﾋﾟ(切替)"        '1(ﾚｼﾋﾟ毎連続)
    Public Const CPstrRecipeFlowGroup               As String = "ﾚｼﾋﾟ(固定)"        '2(ﾚｼﾋﾟ固定)
    Public Const CPstrRecipeFlowFifoSameNG          As String = "FIFO限定"          '3(FIFO限定)
    Public Const CPstrRecipeFlowNumSameNG           As String = "ﾚｼﾋﾟ(切替)限定"    '4(ﾚｼﾋﾟ毎連続_限定)
    Public Const CPstrRecipeFlowGroupSameNG         As String = "ﾚｼﾋﾟ(固定)限定"    '5(ﾚｼﾋﾟ固定_限定)

    Public Const CPlngNumRecipeFlowFifo             As Integer = 0                     'FIFO
    Public Const CPlngNumRecipeFlowNum              As Integer = 1                     'ﾚｼﾋﾟ毎連続
    Public Const CPlngNumRecipeFlowGroup            As Integer = 2                     'ﾚｼﾋﾟ固定
    Public Const CPlngNumRecipeFlowFifoSameNG       As Integer = 3                     'FIFO(限定)
    Public Const CPlngNumRecipeFlowNumSameNG        As Integer = 4                     'ﾚｼﾋﾟ毎連続(限定)
    Public Const CPlngNumRecipeFlowGroupSameNG      As Integer = 5                     'ﾚｼﾋﾟ固定(限定)

    '@対応区分(現在は故障修理/保全記録票機能にて使用)
    Public Const CPstrCopeDivision1                 As String = "自主保全"          'COPE_DIVISION=1の場合に使用
    Public Const CPstrCopeDivision2                 As String = "ﾒｰｶｰ保全"          'COPE_DIVISION=2の場合に使用

    '@ﾊﾞｯﾁ投入順通知待ちﾒｯｾｰｼﾞ表示用
    Public Const CPstrBatchMoveInNotify             As String = "装置へ投入順を通知しています。"

    '@検査工数削減Msg表示用
    Public Const CPstrWF                            As String = "ウェハ"            '検査工数削減Msg用：WF状態変更時表示
    Public Const CPstrScrap                         As String = "不良/払出/保留"    '検査工数削減Msg用：WF状態変更時表示
    Public Const CPstrDirectScrap                   As String = "廃棄"              '検査工数削減Msg用：WF状態変更時表示
    Public Const CPstrDivide                        As String = "分割"              '検査工数削減Msg用：分割時表示
    Public Const CPstrDivideFrom                    As String = "分割元ロット"      '同上
    Public Const CPstrDivideTo                      As String = "分割先ロット"      '同上
    Public Const CPstrCombine                       As String = "統合"              '検査工数削減Msg用：統合時表示
    Public Const CPstrCombineTo                     As String = "統合先ロット"      '同上
    Public Const CPstrRework                        As String = "リワークロット"    '検査工数削減Msg用：分割ﾘﾜｰｸ時表示
    Public Const CPstrAdd                           As String = "追加流動ロット"    '検査工数削減Msg用：分割追加流動時表示
    Public Const CPstrLot                           As String = "ロット"            '検査工数削減Msg用：etc


    '@----------------------------------------------
    '@ ｼｽﾃﾑﾌﾞﾛｯｸ関連
    '@----------------------------------------------
    '@ｼｽﾃﾑﾌﾞﾛｯｸ
    Public Const CPstrSBID1A0                       As String = "1A0"               '基板工程
    Public Const CPstrSBID2A0                       As String = "2A0"               '組立工程
    Public Const CPstrSBID3A0                       As String = "3A0"               '防湿ALD工程

    '@ｼｽﾃﾑﾌﾞﾛｯｸ和名
    Public Const CPstrSBID1A0Name                   As String = "基板"              '基板工程
    Public Const CPstrSBID2A0Name                   As String = "組立"              '組立工程
    Public Const CPstrSBID3A0Name                   As String = "防湿ALD"           '防湿ALD工程

    '@SBｼｽﾃﾑﾌﾗｸﾞ
    Public Const CPstrSBSystemFlagInnerChitose      As String = "1"                 '千歳
    Public Const CPstrSBSystemFlagOuterChitose      As String = "0"                 '千歳以外


    '@----------------------------------------------
    '@ 端末関連
    '@----------------------------------------------
    '@端末区分
    Public Const CPstrManufactureStatus             As String = "M"                 'ｺﾏﾝﾄﾞﾗｲﾝ第3引数/工程
    Public Const CPstrStaffStatus                   As String = "S"                 'ｺﾏﾝﾄﾞﾗｲﾝ第3引数/ｽﾀｯﾌ
    Public Const CPstrAdminStatus                   As String = "A"                 'ｺﾏﾝﾄﾞﾗｲﾝ第3引数/管理用

    '@端末区分和名
    Public Const CPstrManufactureStatusName         As String = "端末"              '工程端末
    Public Const CPstrStaffStatusName               As String = "スタッフ"          'ｽﾀｯﾌ端末
    Public Const CPstrAdminStatusName               As String = "全機能"            '全機能


    '@----------------------------------------------
    '@ SYSTEM関連
    '@----------------------------------------------
    '@ﾒｯｾｰｼﾞ通信
    Public Const CPstrTRUE                          As String = "0"                 'ﾒｯｾｰｼﾞ受信結果RETとの比較用定数(成功)
    Public Const CPstrFALSE                         As String = "1"                 'ﾒｯｾｰｼﾞ受信結果RETとの比較用定数(失敗)
    Public Const CPstrMsgNull                       As String = ""                  'ﾒｯｾｰｼﾞ送信用Null文字

    '@SendKeysの定義
    Public Const CPstrSendKeysTab                   As String = "{TAB}"             '次ﾌｫｰｶｽｾｯﾄ用TAB定義
    Public Const CPstrSendKeysPageUp                As String = "{PGUP}"            'PageUp定義
    Public Const CPstrSendKeysPageDown              As String = "{PGDN}"            'PageDown定義
    Public Const CPstrSendKeysPulasTab              As String = "+{TAB}"            '次ﾌｫｰｶｽを戻す用TAB定義


    '@Msgﾊﾞｰｼﾞｮﾝ判定用定義
    Public Const CPstrVersion                       As String = "VER"               'Msgﾊﾞｰｼﾞｮﾝ判定文字
    Public Const CPlngVersion                       As Integer = 3                     'Msgﾊﾞｰｼﾞｮﾝ判定文字数
    Public Const CPlngVersionStart                  As Integer = 4                     'Msgﾊﾞｰｼﾞｮﾝ判定文字数開始位置
    Public Const CPlngVersionLength                 As Integer = 5                     'Msgﾊﾞｰｼﾞｮﾝ判定文字数ﾚﾝｸﾞｽ

    '@機能ﾊﾞｰｼﾞｮﾝ判定用定義
    Public Const CPstrFunction                      As String = "FUN"               '機能ﾊﾞｰｼﾞｮﾝ判定文字
    Public Const CPlngFunction                      As Integer = 3                     '機能ﾊﾞｰｼﾞｮﾝ判定文字数
    Public Const CPlngFunctionStart                 As Integer = 4                     '機能ﾊﾞｰｼﾞｮﾝ判定文字数開始位置
    Public Const CPlngFunctionLength                As Integer = 5                     '機能ﾊﾞｰｼﾞｮﾝ判定文字数ﾚﾝｸﾞｽ

    '@ﾒｯｾｰｼﾞ識別子
    Public Const CPstrErr                           As String = "ERR"               'ｴﾗｰﾒｯｾｰｼﾞ
    Public Const CPstrInf                           As String = "INF"               '案内ﾒｯｾｰｼﾞ
    Public Const CPstrWar                           As String = "WAR"               'ﾜｰﾆﾝｸﾞﾒｯｾｰｼﾞ


    '@----------------------------------------------
    '@ ﾛｸﾞ出力関連
    '@----------------------------------------------
    '@工程端末からLOG書き込みをする場合はﾌｧｲﾙｻｰﾊﾞｰの書き込み権限が必要
    'Public Const CPstrErrLogFilePath                As String = "\\163.141.231.98\temp_log"
    Public Const CPstrErrLogDevePath                As String = "\Deve"             '開発用ﾊﾟｽ
    Public Const CPstrErrLogReleasePath             As String = "\Release"          '運用用ﾊﾟｽ
    Public Const CPstrErrLogFileName                As String = "SpritusErrLog.txt" 'ﾛｸﾞﾌｧｲﾙ名


    '@----------------------------------------------
    '@ ﾛｯﾄ関連
    '@----------------------------------------------
    '@ﾛｯﾄ状態
    Public Const CPstrWaitThrowSt                   As String = "投入待ち"
    Public Const CPstrWaitWorkSt                    As String = "作業待ち"
    Public Const CPstrBeforeProgressSt              As String = "前処理"
    Public Const CPstrProcessingSt                  As String = "処理中"
    Public Const CPstrAfterProgressSt               As String = "後処理"
    Public Const CPstrHoldSt                        As String = "保留"
    Public Const CPstrHoldWorkSt                    As String = "作業保留"
    Public Const CPstrHoldProgressSt                As String = "仕掛保留"
    Public Const CPstrStopReservationSt             As String = "停止予約"
    Public Const CPstrStopSt                        As String = "停止"
    Public Const CPstrWaitUnityReworkSt             As String = "ﾘﾜｰｸ統合待ち"
    Public Const CPstrEndWorkSt                     As String = "作業終了"
    Public Const CPstrEndSt                         As String = "終了"
    Public Const CPstrNormalSt                      As String = "通常"
    Public Const CPstrLoadSt                        As String = "LOAD中"
    Public Const CPstrSendBeforeST                  As String = "送品待ち"

    '@特殊特性
    Public Const CPstrSpNull                        As String = "0"                 '特殊特性(=0:Null表記)
    Public Const CPstrSpBlackS                      As String = "1"                 '特殊特性(=1:ｺｰﾄﾞ表記)※未定
    Public Const CPstrSpWhiteS                      As String = "2"                 '特殊特性(=2:ｺｰﾄﾞ表記)※未定

    '@流動区分(種別)
    Public Const CPstrFlowClassPR                   As String = "PR"                '量産
    Public Const CPstrFlowClassES                   As String = "ES"                'ES
    Public Const CPstrFlowClassTS                   As String = "TS"                'TS
    Public Const CPstrFlowClassWS                   As String = "WS"                'WS
    Public Const CPstrFlowClassZZ                   As String = "ZZ"                '実験
    Public Const CPstrFlowClassGG                   As String = "GG"                'TEG品
    Public Const CPstrFlowClassSY                   As String = "SY"                'SYSTEM確認用

    '@品確/ﾓﾆﾀ種別
    Public Const CPstrFlowClassMO                   As String = "MO"                'ﾓﾆﾀ
    Public Const CPstrFlowClassQU                   As String = "QU"                '品確

    '@ﾀﾞﾐｰ判定用、種別
    Public Const CPstrFlowDummy                     As String = "D"                 'ﾀﾞﾐｰ判定用
    Public Const CPstrFillerDummy                   As String = "FD"                'ﾀﾞﾐｰ判定用(FD)
    Public Const CPstrSideDummy                     As String = "SD"                'ﾀﾞﾐｰ判定用(SD)
    Public Const CPstrExtraDummy                    As String = "ED"                'ﾀﾞﾐｰ判定用(ED)

    '@流動ﾀｲﾌﾟ(FLOW_TYPE)
    Public Const CPstrLotCurstateFlowTypeMove       As String = "M"                 '移載工程

    '@ﾌﾟﾛｾｽ流動ﾀｲﾌﾟ(M_PC.FLOW_TYPE)
    Public Const CPstrMasFlowTypeRework             As String = "1"                 'ﾘﾜｰｸ(M_PC.FLOW_TYPE)
    Public Const CPstrMasFlowTypeTsuika             As String = "4"                 '追加流動(M_PC.FLOW_TYPE)

    '@L/Rﾌﾗｸﾞ(LC_DIRECTION)
    Public Const CPstrPDIDL                         As String = "L"                 'L
    Public Const CPstrPDIDR                         As String = "R"                 'R

    '@製品区分(PD.USE_ID)
    Public Const CPstrProduct                       As String = "Product"           '製品区分
    Public Const CPstrUseIDProduct                  As String = "PRODUCT"           'PR等：製品
    Public Const CPstrUseIDTeg                      As String = "TEG"               'TEG等：製品
    Public Const CPstrUseIDMonitor                  As String = "MONITOR"           'MO：ﾓﾆﾀ
    Public Const CPstrUseIDFiller                   As String = "FILLER"            'FD:ﾌｨﾗｰ
    Public Const CPstrUseIDDummy                    As String = "DUMMY"             'SD等：ﾀﾞﾐｰ
    Public Const CPstrUseIDALL                      As String = "ALL"               '全て
    Public Const CPstrSpecUseProductName            As String = "製品"
    Public Const CPstrSpecUseMonitorName            As String = "モニタ"
    Public Const CPstrSpecUseDummyName              As String = "ダミー"


    '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟ判別用
    Public Const CPstrDefaultRecpFlag               As String = "1"                 'ﾃﾞﾌｫﾙﾄﾚｼﾋﾟﾌﾗｸﾞ

    '@枚葉ﾚｼﾋﾟ設定可否ﾌﾗｸﾞ(M_WP.LOT_RECIPE_FLAG)
    Public Const CPstrWfRecpOkFlag                  As String = "0"                 '枚葉ﾚｼﾋﾟ設定可能
    Public Const CPstrWfRecpNgFlag                  As String = "1"                 '枚葉ﾚｼﾋﾟ設定不可
    Public Const CPstrWfRecpSiFlag                  As String = "2"                 '単一枚葉ﾚｼﾋﾟ設定可

    '@在庫ﾌﾗｸﾞ(INVENTORY_FLAG)
    Public Const CPstrInventory01                   As String = "01"                '受入
    Public Const CPstrInventory09                   As String = "09"                '完成

    '@保留ﾌﾗｸﾞ(HOLD_FLAG)
    Public Const CPstrHold0                         As String = "0"                 '指定なし
    Public Const CPstrHold1                         As String = "1"                 '保留ﾛｯﾄ

    '@CFﾌﾗｸﾞ判定用(CF_FLAG ⇒ 0：CFﾛｯﾄ以外、1：CFﾛｯﾄ、2：TPAL)
    Public Const CPstrCF                            As String = "1"                 'CFﾛｯﾄ
    Public Const CPstrTPAL                          As String = "2"                 'TPALﾛｯﾄ

    '@LPﾌﾗｸﾞ判定用(LP_FLAG 0；小板　1；大板)
    Public Const CPstrLP                            As String = "1"                 'CFﾛｯﾄ(大判)

    '@CF_COMPﾌﾗｸﾞ判定用(0：CFﾛｯﾄ確定不可、1：CFﾛｯﾄ確定可能)
    Public Const CPstrCOMP                          As String = "1"                 'CFﾛｯﾄ確定可能

    '@COVER_FLAG判定用(0：貼り合せ未実施、1：貼り合わせ済み(1Sのみ判定処理実施))
    Public Const CPstrTpalComp                      As String = "1"                 'TPALﾛｯﾄ確定可能

    '@COVER_FLAG判定用(0：貼り合せ未実施、1：貼り合わせ済み(1Sのみ判定処理実施))
    Public Const CPstrODFComp                       As String = "1"                 'ODFﾛｯﾄ確定可能

    '@TPALﾛｯﾄ判定用
    Public Const CPstrTpalLot                       As String = "TP"                'TPALﾛｯﾄ

    '@ﾘﾜｰｸ関係
    Public Const CPstrRouteEmpty                    As String = "-1"                '空ﾘﾜｰｸ/追加流動
    Public Const CPstrReworkEmpty                   As String = "(空)リワーク"
    Public Const CPstrTsuikaEmpty                   As String = "(空)追加流動"

    '@----------------------------------------------
    '@ 装置関連
    '@----------------------------------------------

    '@装置ﾀｲﾌﾟ(WP_TYPE)
    Public Const CPstrWpTypeHandWork                As String = "0"                 'ﾊﾝﾄﾞﾜｰｸ
    Public Const CPstrWpTypeNormal                  As String = "1"                 '通常

    '@装置ﾀｲﾌﾟ(EQ_TYPE)
    Public Const CPstrEqTypeNormal                  As String = "0"                 '通常
    Public Const CPstrEqTypeBatch                   As String = "1"                 'ﾊﾞｯﾁ
    Public Const CPstrEqTypeReticle                 As String = "2"                 'ﾚﾁｸﾙ
    Public Const CPstrEqTypeCFKI                    As String = "3"                 'CFKI
    Public Const CPstrEqTypeTPAL                    As String = "4"                 'TPAL
    Public Const CPstrEqTypeSORTER                  As String = "5"                 'ｿｰﾀｰ(移載機)
    Public Const CPstrEqTypeElect                   As String = "6"                 '電特装置
    Public Const CPstrEqTypeTFTS                    As String = "7"                 'TFT測定装置
    Public Const CPstrEqTypeWAIST                   As String = "8"                 'WAIST検査機
    Public Const CPstrEqTypeCMP                     As String = "9"                 'CMP研磨装置
    Public Const CPstrEqTypeKRF                     As String = "11"                'ﾊﾟﾀｰﾝ検査機
    Public Const CPstrEqTypeThrowin                 As String = "13"                '投入装置
    Public Const CPstrEqTypeODF                     As String = "14"                'ODF装置
    Public Const CPstrEqTypeContEt                  As String = "17"                'CONTｴｯﾁｬｰ
    Public Const CPstrEqTypeJyoucyaku               As String = "19"                '斜方蒸着装置
    Public Const CPstrEqTypeHyoumenSyori            As String = "20"                '表面処理装置
    Public Const CPstrEQ_TYPE_MoveB                 As String = "22"                '移載機B
    Public Const CPstrEQ_TYPE_MoveC                 As String = "23"                '移載機B
    Public Const CPstrEqTypeIPA                     As String = "24"                'IPA洗浄装置(無機)
    Public Const CPstrEqTypeIPADrier                As String = "25"                'IPA乾燥装置(無機表面処理)
    Public Const CPstrEqTypeBeforeMove              As String = "26"                '処理前移戴必須装置
    Public Const CPstrEqTypeTEOS                    As String = "28"                'TEOS装置
    Public Const CPstrEqTypeVFI                     As String = "27"                '無機異物検査機
    Public Const CPstrEqTypeALDKensu                As String = "30"                '防湿ALD検数
    Public Const CPstrEqTypeALDTape                 As String = "31"                '防湿ALDテープ貼剥
    Public Const CPstrEqTypeALDOven                 As String = "32"                '防湿ALDオーブン
    Public Const CPstrEqTypeALDSeimaku              As String = "33"                '防湿ALD成膜
    '@↓2019/12/13 (Fri) 15:03:31 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Public Const CPstrEqTypeGRBSet                  As String = "34"                'GRB設定
    '@↑2019/12/13 (Fri) 15:03:31 Y.Yoneyama 「.Netへ反映未」 **************************************************
	Public Const CPstrEqTypeKMZR                    As String = "35"                '組ズレ検査機

    '@ﾎﾟｰﾄﾀｲﾌﾟ(PORT_TYPE)
    Public Const CPstrPortTypeUin                   As String = "UNI"               'Uni
    Public Const CPstrPortTypeLoader                As String = "LOADER"            'Loader
    Public Const CPstrPortTypeUnloader              As String = "UNLOADER"          'Unloader

    '@装置状態(WP_STATUS)
    Public Const CPstrWpIdle                        As String = "待機中"
    Public Const CPstrWpExecuting                   As String = "処理実行中"

    '@用途ID(USE_ID)
    Public Const CPstrMcUseIDNormal                 As String = "MCUSE0001"         '通常
    Public Const CPstrMcUseIDWpStop                 As String = "MCUSE0004"         '故障停止
    Public Const CPstrMcUseIDPlanMnt                As String = "MCUSE0005"         '計画保全

    '@運用ﾓｰﾄﾞ(MES_MODE_ID)
    Public Const CPstrM1                            As String = "M1"                '運用ﾓｰﾄﾞ"M1"
    Public Const CPstrM2                            As String = "M2"                '運用ﾓｰﾄﾞ"M2"
    Public Const CPstrS1                            As String = "S1"                '運用ﾓｰﾄﾞ"S1"
    Public Const CPstrS2                            As String = "S2"                '運用ﾓｰﾄﾞ"S2"
    Public Const CPstrF                             As String = "F"                 '運用ﾓｰﾄﾞ"F"

    '@運用ﾓｰﾄﾞﾀｲﾌﾟ(MES_MODE_TYPE)
    Public Const CPstrMesModeType0                  As String = "0"                 '全て可、M1処理中可
    Public Const CPstrMesModeType1                  As String = "1"                 'S2/F不可、M1処理中可
    Public Const CPstrMesModeType2                  As String = "2"                 'M2不可、M1処理中可
    Public Const CPstrMesModeType3                  As String = "3"                 'S2不可、M1処理中可
    Public Const CPstrMesModeType4                  As String = "4"                 'F不可、M1処理中可
    Public Const CPstrMesModeType9                  As String = "9"                 'M1のみ
    Public Const CPstrMesModeType10                 As String = "10"                '全て可、M1処理中不可
    Public Const CPstrMesModeType11                 As String = "11"                'S2/F不可、M1処理中不可
    Public Const CPstrMesModeType12                 As String = "12"                'M2不可、M1処理中不可
    Public Const CPstrMesModeType13                 As String = "13"                'S2不可、M1処理中不可
    Public Const CPstrMesModeType14                 As String = "14"                'F不可、M1処理中不可

    '@装置ﾀｲﾌﾟ(MC_TYPE)
    Public Const CPstrMCTypeNormal                  As String = "NORMAL"            'ﾀﾞﾐｰ判定用(通常装置)
    Public Const CPstrMCTypeBatch                   As String = "BATCH"             'ﾀﾞﾐｰ判定用(ﾊﾞｯﾁ装置)
    Public Const CPstrMCTypeExDummy                 As String = "EXDUMMY"           'ﾀﾞﾐｰ判定用(EXﾀﾞﾐｰ製品扱い装置)

    '@用途判定用
    Public Const CPstrMonitor                       As String = "Monitor"           '用途判定用(ﾓﾆﾀ)
    Public Const CPstrQuality                       As String = "Quality"           '用途判定用(品確)
    Public Const CPstrPdDummy                       As String = "Dummy"             '用途判定用(ﾀﾞﾐｰ)

    '@装置経過時間ﾁｪｯｸ結果
    Public Const CPstrchkResultOK                   As String = "0"                 'ｵｰﾊﾞあり
    Public Const CPstrchkResultNG                   As String = "1"                 'ｵｰﾊﾞあり

    '@画面表示用
    Public Const CPstrKonsei                        As String = "KONSEI"            'KONSEI表示(MKﾛｯﾄ編成で使用)


    '@----------------------------------------------
    '@ 理由ｺｰﾄﾞ関連
    '@----------------------------------------------
    '@ﾘﾜｰｸ原因理由ｺｰﾄﾞ
    Public Const CPstrReworkReasonCode              As String = "R000000012"        '理由：ﾘﾜｰｸ保留


    '@----------------------------------------------
    '@ 時間制限関連
    '@----------------------------------------------
    '@時間制約関連
    Public Const CPstrMade                          As String = " まで "            '時間制約結合文字列
    Public Const CPstrHour                          As String = "時間"              '時間制約結合文字列
    Public Const CPstrh                             As String = "分"                '時間制約結合文字列
    Public Const CPstrReplaceMinus                  As String = "-"                 'ﾏｲﾅｽ
    Public Const CPstrinai                          As String = "以内"              '以下
    Public Const CPstrijyou                         As String = "以上"              '以上
    Public Const CPstrRestrictID1                   As String = "1"                 '制限時間以下
    Public Const CPstrRestrictID2                   As String = "2"                 '制限時間以上
    Public Const CPstrRestrict                      As String = "RESTRICT"          '結果文字

    '@制限ﾀｲﾌﾟ(RESTRICT_TYPE_ID)
    Public Const CPstrRestrictTypeID1               As String = "1"                 '以下
    Public Const CPstrRestrictTypeID2               As String = "2"                 '以上
    Public Const CPstrRestrictTypeID3               As String = "3"                 '処理時間制限以下


    '@----------------------------------------------
    '@ 送品関連
    '@----------------------------------------------
    '@次工程送出
    Public Const CPstrChukan                        As String = "0"                  '送信結果(中間在庫)
    Public Const CPstrKansei                        As String = "1"                  '送信結果(完成在庫)
    Public Const CPstrSouhin                        As String = "2"                  '送信結果(組立送品)
    Public Const CPstrSendWait                      As String = "8"                  '送信結果(送品待ち)
    Public Const CPstrSendAbort                     As String = "9"                  '送信結果(送品中断)
    Public Const CPstrSendAbortAJR                  As String = "99"                 '送信結果(送品中断_蒸着後流動予約)
    Public Const CPstrChukanZaiko                   As String = "中間在庫へ送出"      '送信結果成功ﾒｯｾｰｼﾞ(中間在庫)
    Public Const CPstrKanseiZaiko                   As String = "完成在庫へ送出"      '送信結果成功ﾒｯｾｰｼﾞ(完成在庫)
    Public Const CPstrSouhinZaiko                   As String = "組立工程へ送品"      '送信結果成功ﾒｯｾｰｼﾞ(組立送品)
    Public Const CPstrInvSendAbortMsg               As String = "完成在庫へ送出中止"
    Public Const CPstrSendAbortMsg                  As String = "送出中止"

    '@送品ﾌﾗｸﾞ(LOT_SEND_FLAG)
    Public Const CPlngLotSendNasi                   As Integer = 0                     '送品なし
    Public Const CPlngLotSendAri                    As Integer = 1                     '送品あり


    '@----------------------------------------------
    '@ ｶﾞｲﾀﾞﾝｽ関連
    '@----------------------------------------------
    '@表示ﾒｯｾｰｼﾞ用
    Public Const CPstrStartMsgCode                  As String = "<"
    Public Const CPstrEndMsgCode                    As String = ">"
    Public Const CPstrMsgCrCode                     As String = "$$"
    Public Const CPstrWarMsgCode                    As String = "【警告】"
    Public Const CPstrGuidanceMsg                   As String = "ガイダンスメッセージ"
    Public Const CPstrGuidanceCode                  As String = "ガイダンスコード"


    '@----------------------------------------------
    '@ ｵﾌﾗｲﾝFTP関連
    '@----------------------------------------------
    Public Const CPstrFtpDataFlagOn                 As String = "1"                                     'ｵﾌﾗｲﾝFTPﾌﾗｸﾞ
    Public Const CPstrFTP                           As String = "装置データ登録中です。"                  'ｵﾌﾗｲﾝFTP
    Public Const CPstrDataConfirm                   As String = "装置データ登録状況を確認しています。"
    Public Const CPstrTotalNum                      As String = "確認対象ウェハ　"
    Public Const CPstrOutOfNum                      As String = "枚中　"
    Public Const CPstrComplete                      As String = "枚確認完了。"


    '@----------------------------------------------
    '@ ｱｸｼｮﾝ予約関連
    '@----------------------------------------------
    '@ｱｸｼｮﾝ予約状況(ｱｸｼｮﾝﾄﾘｶﾞ)
    Public Const CPlngLotActStepInfoWrkStart        As String = "開始時"            '作業開始時
    Public Const CPlngLotActStepInfoWrkEnd          As String = "終了時"            '作業終了時
    Public Const CPlngLotActStepInfoBoth            As String = "開始時/終了時"     '開始/終了

    '@ｱｸｼｮﾝ予約実行用
    Public Const CPstrActionFlag0                   As String = "0"                 '実行なし
    Public Const CPstrActionFlag1                   As String = "1"                 '停止
    Public Const CPstrActionFlag2                   As String = "2"                 '保留
    Public Const CPstrActionInfo                    As String = "アクション予約によりロット[%1] は [%2] されました。"   'ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ
    Public Const CPstrActionStopNextStepInfo        As String = "$$ロット[%3]は次工程送出されません。"                  'ｱｸｼｮﾝ予約実行時未送出ﾒｯｾｰｼﾞ

    '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ名用
    Public Const CPstrLotActionTypeID0              As String = "0"                 'ﾛｯﾄ
    Public Const CPstrLotActionTypeID1              As String = "1"                 '機種
    Public Const CPstrLotActionTypeID2              As String = "2"                 '装置
    Public Const CPstrLotActionTypeID3              As String = "3"                 '特定工程
    Public Const CPstrActTypeLOT                    As String = "ロット"
    Public Const CPstrActTypePD                     As String = "機種"
    Public Const CPstrActTypeWP                     As String = "装置"
    Public Const CPstrActTypeTStep                  As String = "特定工程"


    '@----------------------------------------------
    '@ ﾒｰﾙ関連
    '@----------------------------------------------
    '@ﾒｰﾙ用定数
    Public Const CPstrMailSendTitleExcp             As String = "工程異常処理票　兼　不適合品処理票"
    Public Const CPstrMailSendTitleRepair           As String = "故障修理記録票"
    Public Const CPstrMailSendTitlePreserve         As String = "保全記録票"
    Public Const CPstrMailSubjectExcp               As String = "確認依頼(%1)"      '異常処理票用ﾒｰﾙ件名
    Public Const CPstrMailSubjectReport             As String = "確認依頼(%1)"      '処理票票用ﾒｰﾙ件名
    Public Const CPstrMailSubjectHold               As String = "ロット保留(%1)"    'ﾛｯﾄ保留用ﾒｰﾙ件名
    Public Const CPstrMailWP                        As String = "対象装置："        '異常処理票用ﾒｰﾙ本文
    Public Const CPstrMailLOT_S                     As String = "対象ロット№："    '異常処理票用ﾒｰﾙ本文
    Public Const CPstrMailEXCPNAME                  As String = "工程異常名："      '異常処理票用ﾒｰﾙ本文
    Public Const CPstrMailRepairName                As String = "故障現象名："      '故障修理記録票用ﾒｰﾙ本文
    Public Const CPstrMailPreserveItemName          As String = "実施項目："        '保全記録票用ﾒｰﾙ本文
    Public Const CPstrMailEXCPNO                    As String = "発行№："          '異常処理票用ﾒｰﾙ本文
    Public Const CPstrMailReportNo                  As String = "発行№："          '処理票用ﾒｰﾙ本文
    Public Const CPstrMailSENDER                    As String = "送信者："          '異常処理票用ﾒｰﾙ本文
    Public Const CPstrMailPDID                      As String = "機種："            'ﾛｯﾄ保留用ﾒｰﾙ本文
    Public Const CPstrMailOPID                      As String = "大工程："          'ﾛｯﾄ保留用ﾒｰﾙ本文
    Public Const CPstrMailSTEPID                    As String = "小工程："          'ﾛｯﾄ保留用ﾒｰﾙ本文
    Public Const CPstrMailHOLDREASON                As String = "保留理由："        'ﾛｯﾄ保留用ﾒｰﾙ本文
    Public Const CPstrMailSENDDATE                  As String = "保留日時："        'ﾛｯﾄ保留用ﾒｰﾙ本文
    Public Const CPstrMailLOT                       As String = "ロット№："        'ﾛｯﾄ保留用ﾒｰﾙ本文
    Public Const CPstrMailHOLDTERMDATE              As String = "保留期限："        'ﾛｯﾄ保留用ﾒｰﾙ本文
    Public Const CPstrMailHOLDComments              As String = "メール本文："      'ﾛｯﾄ保留用ﾒｰﾙ本文


    '@----------------------------------------------
    '@ P/Rｵｰﾀﾞ関連
    '@----------------------------------------------
    '@P/Rｵｰﾀﾞｰ管理のP/R区分
    Public Const CPstrPrOrderClassP                 As String = "P"                 'P:生産実験ｵｰﾀﾞｰ
    Public Const CPstrPrOrderClassR                 As String = "R"                 'R:研究開発ｵｰﾀﾞｰ

    '@P/Rｵｰﾀﾞｰ登録のﾓｰﾄﾞ
    Public Const CPlngPrOrderInsertMode1            As Integer = 1                     '新規
    Public Const CPlngPrOrderInsertMode2            As Integer = 2                     'ｺﾋﾟｰ登録
    Public Const CPlngPrOrderInsertMode3            As Integer = 3                     '修正
    Public Const CPlngPrOrderInsertMode4            As Integer = 4                     '削除(未使用)


    '@----------------------------------------------
    '@ ｷｬﾘｱ関連
    '@----------------------------------------------
    '@ｷｬﾘｱ位置ID(CURRENT_POSITION_ID)
    Public Const CPstrCarrierPosition               As String = "POS0001"

    '@ｷｬﾘｱ状態(CARRIER_STAT_ID)
    Public Const CPstrCarrierStatReady              As String = "READY"
    Public Const CPstrCarrierStatStkout             As String = "STKOUT"
    Public Const CPstrCarrierStatMove               As String = "MOVE"
    Public Const CPstrCarrierStatStkin              As String = "STKIN"
    Public Const CPstrCarrierStatActive             As String = "ACTIVE"

    '@ｷｬﾘｱﾀｲﾌﾟ(CARRIER_TYPE_ID)
    Public Const CPstrCarrTypeFOUP                  As String = "CARR0001"          'FOUP
    Public Const CPstrCarrTypeOP                    As String = "CARR0002"          'ｵｰﾌﾟﾝｶｾｯﾄ
    Public Const CPstrCarrTypeFOSB                  As String = "CARR9999"          'FOSB
    Public Const CPstrCarrTypeCF                    As String = "CARR0005"          'CFﾊﾟﾚｯﾄｶｾｯﾄ
    Public Const CPstrCarrTypeTPAL                  As String = "CARR0006"          'TPALﾄﾚｲｶｾｯﾄ
    Public Const CPstrCarrTypeSMIF                  As String = "CARR0007"          'SMIF
    Public Const CPstrCarrTypeJyo                   As String = "CARR0010"          '蒸着治具ｶｾｯﾄ
    Public Const CPstrCarrTypeHotOP                 As String = "CARR0011"          '耐熱ｵｰﾌﾟﾝｶｾｯﾄ
    Public Const CPstrCarrTypeJS                    As String = "CARR0012"          'JSｷｬﾘｱ
    Public Const CPstrCarrTypeA                     As String = "CARR0013"          'Aｷｬﾘｱ
	Public Const CPstrCarrTypeI                     As String = "CARRSYS0"          'Iｷｬﾘｱ(簡易分割仮想ｷｬﾘｱ)

    '@ｷｬﾘｱ洗浄条件(CLEAN_FLAG)
    Public Const CPstrCarrierClean1                 As String = "1"                 '使用後洗浄不要：未洗浄可
    Public Const CPstrCarrierClean2                 As String = "2"                 '使用後洗浄不要：要洗浄済
    Public Const CPstrCarrierClean3                 As String = "3"                 '使用後洗浄必要：未洗浄可
    Public Const CPstrCarrierClean4                 As String = "4"                 '使用後洗浄必要：要洗浄済

    '@治具ﾀｲﾌﾟ(JIG_TYPE_ID)
    Public Const CPstrJigTypeJT                     As String = "JT"                '蒸着TFT
    Public Const CPstrJigTypeJC                     As String = "JC"                '蒸着CF
    Public Const CPstrJigTypeJO                     As String = "JO"                '蒸着ODF
    Public Const CPstrJigTypeJD                     As String = "JD"                '蒸着ﾀﾞﾐｰ
    Public Const CPstrJigTypeHI                     As String = "HI"                '平置き

    '@治具ｽﾃｰﾀｽ
    Public Const CPstrJigStatusCanUse               As String = "0"                 '使用可
    Public Const CPstrJigStatusUsing                As String = "1"                 '使用中
    Public Const CPstrJigStatusNG                   As String = "2"                 '使用不可
    Public Const CPstrJigStatusReserve              As String = "3"                 '使用不可


    'キャリアカテゴリ(必要に応じて追記 M_CARRIER_CATEGORYテーブル参照）
    Public Const CPstrCarrCateJyo                   As String = "CAT05001"          '蒸着処理
    Public Const CPstrCarrCateHyo                   As String = "CAT05002"          '表面処理
    Public Const CPstrCarrCateHari                  As String = "CAT05005"          '貼合せ処理

    '@----------------------------------------------
    '@ ｶﾚﾝﾀﾞｰ/日付関連
    '@----------------------------------------------
    '@ｶﾚﾝﾀﾞｰ設定(流動系ｻｲｽﾞ)
    Public Const CPlngClHeight                      As Integer = 378                   '高さ
    Public Const CPlngClWidth                       As Integer = 410                   '幅
    Public Const CPlngClFontSize                    As Integer = 12                    'ﾌｫﾝﾄｻｲｽﾞ
    Public Const CPlngClTlFontSize                  As Integer = 18                    'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
    Public Const CPlngClGridFontSize                As Integer = 16                    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ

    '@ｶﾚﾝﾀﾞｰ設定(ﾂｰﾙ系ｻｲｽﾞ)
    Public Const CPlngMClHeight                     As Integer = 240                   '高さ
    Public Const CPlngMClWidth                      As Integer = 253                   '幅
    Public Const CPlngMClFontSize                   As Integer = 11                    'ﾌｫﾝﾄｻｲｽﾞ
    Public Const CPlngMClTlFontSize                 As Integer = 14                    'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
    Public Const CPlngMClGridFontSize               As Integer = 12                    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ

    '@ｶﾚﾝﾀﾞｰ表示ﾓｰﾄﾞ
    Public Const CPlngCalModeFlow                   As Integer = 0                     '工程管理ﾓｰﾄﾞ
    Public Const CPlngCalModeTool                   As Integer = 1                     'ﾂｰﾙ系(ﾏｽﾀｰ)ﾓｰﾄﾞ

    '@無効日付・日時
    Public Const CPstrNullDate                      As String = "____/__/__"        '無効日付
    Public Const CPstrNullTime                      As String = "__:__"             '無効時間
    Public Const CPstrDayStartTime                  As String = "00:00"             '時間(00:00)
    Public Const CPstrDayEndTime                    As String = "23:59"             '時間(23:59)

    '@日時取得定数
    Public Const CPstrNow                           As String = " 現在"             '現在日時表示文字列

    '@日付ﾌｫｰﾏｯﾄ
    Public Const CPstrDefYmdHms                     As String = "0000/00/00 00:00:00"   'ﾃﾞﾌｫﾙﾄ年月日日時
    Public Const CPstrDefY2mdHms                    As String = "00/00/00 00:00:00"     'ﾃﾞﾌｫﾙﾄ年月日日時
    Public Const CPstrDefMdHm                       As String = "00/00 00:00"           'ﾃﾞﾌｫﾙﾄ月日時

    '@SendKey
    Public Const CPstrSendKeysRight                 As String = "{RIGHT}"

    '@----------------------------------------------
    '@ 無機ODF追越制限関連
    '@----------------------------------------------
    '@追越制限違反状態 (OVERTAKE_STATUS)
    Public Const CPstrOvertakeOk                    As String = "0"                 '追越制限違反無し
    Public Const CPstrOvertakeNg                    As String = "1"                 '追越制限違反有り

    '@----------------------------------------------
    '@汎用ﾌﾗｸﾞ(文字型)
    '@----------------------------------------------
    Public Const CPstrFlagOn                       As String = "1"             'ﾌﾗｸﾞON
    Public Const CPstrFlagOff                      As String = "0"             'ﾌﾗｸﾞOFF

    '@----------------------------------------------
    '@ 親画面ﾒﾆｭｰｷｰ識別定数(機能ID)
    '@----------------------------------------------
    '@☆☆☆ﾒﾆｭｰ項目追加時変更対象処理☆☆☆
    '@画面機能ID
    Public Const CPstrKeyMN0002                     As String = "MENUTOP"           'ﾒﾆｭｰﾄｯﾌﾟ画面
    'Public Const CPstrKeyEN0010                     As String = "EN0010"            'ｷｬﾘｱ管理
    Public Const CPstrKeyEN0020                     As String = "EN0020"            '投入予定ﾛｯﾄ登録
    Public Const CPstrKeyEN0030                     As String = "EN0030"            '作業開始
    Public Const CPstrKeyEN0040                     As String = "EN0040"            '投入(基板)
    Public Const CPstrKeyEN0050                     As String = "EN0050"            '保留／保留解除
    Public Const CPstrKeyEN0060                     As String = "EN0060"            '作業終了
    Public Const CPstrKeyEN0070                     As String = "EN0070"            '処理開始
    Public Const CPstrKeyEN0080                     As String = "EN0080"            '処理終了
    'Public Const CPstrKeyEN0090                     As String = "EN0090"            '優先順位変更
    Public Const CPstrKeyEN00A0                     As String = "EN00A0"            'ﾛｯﾄ保留解除
    Public Const CPstrKeyEN00B0                     As String = "EN00B0"            'CFﾛｯﾄ編成
    Public Const CPstrKeyEN00C0                     As String = "EN00C0"            '運用ﾓｰﾄﾞ変更/装置状態変更
    Public Const CPstrKeyEN00E0                     As String = "EN00E0"            'CFKI作業終了
    Public Const CPstrKeyEN00F0                     As String = "EN00F0"            '在庫管理
    Public Const CPstrKeyEN00G0                     As String = "EN00G0"            'ｷｬﾘｱ管理
    Public Const CPstrKeyEN00H0                     As String = "EN00H0"            '対向基板処置登録
    Public Const CPstrKeyEN00I0                     As String = "EN00I0"            'ﾊﾞｯﾁ作業開始
    Public Const CPstrKeyEN00J0                     As String = "EN00J0"            '装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧
    Public Const CPstrKeyEN00K0                     As String = "EN00K0"            'ﾊﾞｯﾁ作業終了
    Public Const CPstrKeyEN00L0                     As String = "EN00L0"            'ﾊﾞｯﾁ処理開始
    Public Const CPstrKeyEN00M0                     As String = "EN00M0"            'ﾊﾞｯﾁ管理
    Public Const CPstrKeyEN00N0                     As String = "EN00N0"            'ﾊﾞｯﾁ処理終了
    Public Const CPstrKeyEN00O0                     As String = "EN00O0"            '投入予定ﾛｯﾄ登録(品確、ﾓﾆﾀｰ・ﾀﾞﾐｰ)
    Public Const CPstrKeyEN00P0                     As String = "EN00P0"            '投入予定ﾛｯﾄ一覧
    Public Const CPstrKeyEN00Q0                     As String = "EN00Q0"            'ﾛｯﾄ投入(組立)
    Public Const CPstrKeyEN00R0                     As String = "EN00R0"            'ﾀﾞﾐｰ Load/Unload/再投入
    Public Const CPstrKeyEN00S0                     As String = "EN00S0"            'ﾚｼﾋﾟ設定変更
    Public Const CPstrKeyEN00T0                     As String = "EN00T0"            '装置ﾃﾞｰﾀ参照/登録
    Public Const CPstrKeyEN00U0                     As String = "EN00U0"            '工程異常/不適合品処理票登録
    Public Const CPstrKeyEN00V0                     As String = "EN00V0"            '工程異常/不適合品処理票一覧
    Public Const CPstrKeyEN00X0                     As String = "EN00X0"            '投入予定工順登録(組立)
    Public Const CPstrKeyEN00Y0                     As String = "EN00Y0"            'ﾛｯﾄﾘﾜｰｸ
    Public Const CPstrKeyEN00Z0                     As String = "EN00Z0"            'ﾚﾁｸﾙ管理
    Public Const CPstrKeyEN0100                     As String = "EN0100"            '次工程送出
    Public Const CPstrKeyEN0110                     As String = "EN0110"            '装置用途変更
    Public Const CPstrKeyEN0120                     As String = "EN0120"            'ﾛｯﾄ編成(保留/払出WF)
    Public Const CPstrKeyEN0130                     As String = "EN0130"            '作業開始取消
    Public Const CPstrKeyEN0140                     As String = "EN0140"            'ﾛｯﾄｺﾒﾝﾄ
    Public Const CPstrKeyEN0150                     As String = "EN0150"            '装置処理待ちﾛｯﾄ一覧
    Public Const CPstrKeyEN0151                     As String = "EN0151"            '装置処理待ちﾛｯﾄ一覧(防湿ALD)
    Public Const CPstrKeyEN0160                     As String = "EN0160"            'ﾛｯﾄ分割
    Public Const CPstrKeyEN0170                     As String = "EN0170"            'ﾛｯﾄ終了
    Public Const CPstrKeyEN0180                     As String = "EN0180"            'WF状態変更登録
    Public Const CPstrKeyEN0190                     As String = "EN0190"            'ﾁｯﾌﾟ状態変更登録
    Public Const CPstrKeyEN01A0                     As String = "EN01A0"            'TPAL貼り合せ登録
    Public Const CPstrKeyEN01B0                     As String = "EN01B0"            'ﾛｯﾄ再測定
    Public Const CPstrKeyEN01C0                     As String = "EN01C0"            'ﾛｯﾄ情報詳細表示
    Public Const CPstrKeyEN01D0                     As String = "EN01D0"            'ｶﾞｲﾀﾞﾝｽ表示
    Public Const CPstrKeyEN01E0                     As String = "EN01E0"            '在庫移載
    Public Const CPstrKeyEN01F0                     As String = "EN01F0"            '分割予定ﾛｯﾄ登録
    Public Const CPstrKeyEN01G0                     As String = "EN01G0"            'ﾛｯﾄ流動票
    Public Const CPstrKeyEN01H0                     As String = "EN01H0"            '投入移載一覧
    Public Const CPstrKeyEN01I0                     As String = "EN01I0"            '部材履歴
    Public Const CPstrKeyEN01J0                     As String = "EN01J0"            '装置履歴
    Public Const CPstrKeyEN01K0                     As String = "EN01K0"            '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ
    Public Const CPstrKeyEN01L0                     As String = "EN01L0"            '搬送ﾓｰﾄﾞ管理
    Public Const CPstrKeyEN01M0                     As String = "EN01M0"            'ﾚﾁｸﾙﾏﾆｭｱﾙ搬送
    Public Const CPstrKeyEN01N0                     As String = "EN01N0"            'CMPﾒﾝﾃﾅﾝｽ
    Public Const CPstrKeyEN01O0                     As String = "EN01O0"            'ﾒｰﾙ送信
    Public Const CPstrKeyEN01Q0                     As String = "EN01Q0"            'ﾁｯﾌﾟ状態変更(上書き)
    'Public Const CPstrKeyEN01R0                     As String = "EN01R0"            '投入予定ﾛｯﾄ変更/削除
    Public Const CPstrKeyEN01S0                     As String = "EN01S0"            'P/Rｵｰﾀﾞｰ管理
    Public Const CPstrKeyEN01T0                     As String = "EN01T0"            'ﾌｫﾄF/Bﾊﾟﾗﾒｰﾀ変更
    Public Const CPstrKeyEN01U0                     As String = "EN01U0"            'ﾌｫﾄF/Bﾃﾞｰﾀ変更
    Public Const CPstrKeyEN01V0                     As String = "EN01V0"            '装置使用部材管理
    'Public Const CPstrKeyEN01W0                     As String = "EN01W0"            '装置停止・ﾒﾝﾃ計画
    Public Const CPstrKeyEN01X0                     As String = "EN01X0"            'ﾛｯﾄ工順変更
    Public Const CPstrKeyEN01Y0                     As String = "EN01Y0"            '過去在庫一覧
    Public Const CPstrKeyEN01Z0                     As String = "EN01Z0"            '装置ﾒﾝﾃﾅﾝｽ記録票一覧
    Public Const CPstrKeyEN0200                     As String = "EN0200"            '工程別ﾛｯﾄ一覧
    Public Const CPstrKeyEN0210                     As String = "EN0210"            '部材受入
    Public Const CPstrKeyEN0220                     As String = "EN0220"            'ﾛｯﾄ統合
    Public Const CPstrKeyEN0230                     As String = "EN0230"            '部材管理
    'Public Const CPstrKeyEN0240                     As String = "EN0240"            'ﾛｯﾄ送品
    Public Const CPstrKeyEN0250                     As String = "EN0250"            '工程ｽｷｯﾌﾟ
    Public Const CPstrKeyEN0260                     As String = "EN0260"            'ﾛｯﾄ処理順変更
    Public Const CPstrKeyEN0270                     As String = "EN0270"            'ｱｸｼｮﾝ予約
    Public Const CPstrKeyEN0280                     As String = "EN0280"            '移載(ｿｰﾀｰ)
    Public Const CPstrKeyEN0290                     As String = "EN0290"            'ﾛｯﾄ情報変更・削除
    Public Const CPstrKeyEN02A0                     As String = "EN02A0"            '工程戻し
    Public Const CPstrKeyEN02B0                     As String = "EN02B0"            'ﾛｯﾄ情報一括変更
    Public Const CPstrKeyEN02C0                     As String = "EN02C0"            'MKﾛｯﾄ編成
    Public Const CPstrKeyEN02C1                     As String = "EN02C1"            'MKﾛｯﾄ編成混成用子画面
    Public Const CPstrKeyEN02D0                     As String = "EN02D0"            '治具管理
    Public Const CPstrKeyEN02D1                     As String = "EN02D1"            '治具登録ﾌｫｰﾑ
    Public Const CPstrKeyEN02E0                     As String = "EN02E0"            'CF移載情報登録
    Public Const CPstrKeyEN02F0                     As String = "EN02F0"            '治具Wafer紐付け
    Public Const CPstrKeyEN02G0                     As String = "EN02G0"            '不良ﾁｯﾌﾟ情報(№表示)
    Public Const CPstrKeyEN02H0                     As String = "EN02H0"            '無機対向基板紐付/蒸着バッチ情報
    Public Const CPstrKeyEN02I0                     As String = "EN02I0"            '区間優先設定
    Public Const CPstrKeyEN02J0                     As String = "EN02J0"            'TEOS F/B変更/参照
    Public Const CPstrKeyEN02K0                     As String = "EN02K0"            'CONTｴｯﾁｬｰFR使用履歴
    Public Const CPstrKeyEN02L0                     As String = "EN02L0"            'GRB属性設定
    Public Const CPstrKeyEN02M0                     As String = "EN02M0"            'ﾛｯﾄGRB分割
    Public Const CPstrKeyEN02N0                     As String = "EN02N0"            'ﾊﾞｯﾁ装置管理
    Public Const CPstrKeyEN02O0                     As String = "EN02O0"            '時間制限流動管理
    Public Const CPstrKeyEN02P0                     As String = "EN02P0"            'バッチ_受入在庫
    Public Const CPstrKeyEN02Q0                     As String = "EN02Q0"            '防湿ALDﾛｯﾄ流動
    Public Const CPstrKeyEN02Q1                     As String = "EN02Q1"            '作業開始(防湿ALD)
    Public Const CPstrKeyEN02Q2                     As String = "EN02Q2"            '処理開始(防湿ALD)
    Public Const CPstrKeyEN02Q3                     As String = "EN02Q3"            '処理終了(防湿ALD)
    Public Const CPstrKeyEN02Q4                     As String = "EN02Q4"            '作業終了(防湿ALD)
    Public Const CPstrKeyEN02R0                     As String = "EN02R0"            'ﾛｯﾄ投入(ALD)
    Public Const CPstrKeyEN02S0                     As String = "EN02S0"            'Aトレー管理
    Public Const CPstrKeyEN02S1                     As String = "EN02S1"            'Aトレー管理子画面
    Public Const CPstrKeyEN02T0                     As String = "EN02T0"            'Aｷｬﾘｱ管理画面
    Public Const CPstrKeyEN02U0                     As String = "EN02U0"            'ODF貼り合わせ予約
	Public Const CPstrKeyEN02U1                     As String = "EN02U1"            '蒸着後流動予約一覧
	Public Const CPstrKeyEN02V0                     As String = "EN02V0"            '蒸着マスク組立

    Public Const CPstrMenuKeyMMenu                  As String = "EX0010"            'ﾏｽﾀ系
    Public Const CPstrMenuKeySpc                    As String = "EX0020"            '品質管理ﾂｰﾙ
    Public Const CPstrMenuKeySpace                  As String = "SPACE"             'ﾒﾆｭｰ空白行

    '@EXE機能ID
    Public Const CPstrMenuKeyExecuteLower           As String = "EX0000"            'EXE起動ﾒﾆｭｰｷｰ下限
    Public Const CPstrMenuKeyExecuteUpper           As String = "EXZZZZ"            'EXE起動ﾒﾆｭｰｷｰ上限

    '@WEB機能ID
    Public Const CPstrMenuKeyWebLower               As String = "WB0000"            'WEB起動ﾒﾆｭｰｷｰ下限
    Public Const CPstrMenuKeyWebUpper               As String = "WBZZZZ"            'WEB起動ﾒﾆｭｰｷｰ上限

    Public Const CPstrFormMN0000                    As String = "frmxxMN0000"       'ﾒﾆｭｰ画面

    '@帳票機能ID
    Public Const CPstrKeyRPTEN00F0                  As String = "RPTEN00F0"
    Public Const CPstrKeyRPTEN00F1                  As String = "RPTEN00F1"

    '@ﾒﾆｭｰ画面ﾀﾌﾞ
    Public Const CPlngMenuTabFlow                   As Integer = 0                     '流動系ﾀﾌﾞ
    Public Const CPlngMenuTabTool                   As Integer = 1                     'ﾂｰﾙ系ﾀﾌﾞ
    Public Const CPlngMenuTabFavorites              As Integer = 2                     'お気に入りﾀﾌﾞ

    '@ﾒﾆｭｰ起動中ﾌﾗｸﾞ
    Public Const CPlngMenuExecuteFlg                As Integer = 1                     '起動中
    Public Const CPlngMenuSuspendFlg                As Integer = 0                     '停止中

    '@ﾒﾆｭｰｷｬﾘｱID引継ぎ状態
    Public Const CPlngMenuCarrTakeOverOn            As Integer = 1                     'ｷｬﾘｱIDを引き継ぐ
    Public Const CPlngMenuCarrTakeOverOff           As Integer = 0                     'ｷｬﾘｱIDを引き継がない
    Public Const CPlngMenuCarrTakeOverEnable        As Integer = 1                     'ｷｬﾘｱIDを引き継ぎ可
    Public Const CPlngMenuCarrTakeOverDisable       As Integer = 0                     'ｷｬﾘｱIDを引き継ぎ不可

    '@引継ぎﾌﾗｸﾞ
    Public Const CPlngMenuCarrTakeOver0             As Integer = 0                     '次機能へ引継ぎなし、前機能から引継ぎなし
    Public Const CPlngMenuCarrTakeOver1             As Integer = 1                     '次機能へ引継ぎあり、前機能から引継ぎなし
    Public Const CPlngMenuCarrTakeOver2             As Integer = 2                     '次機能へ引継ぎなし、前機能から引継ぎあり
    Public Const CPlngMenuCarrTakeOver3             As Integer = 3                     '次機能へ引継ぎあり、前機能から引継ぎあり
    Public Const CPlngMenuCarrTakeOver5             As Integer = 5                     'EXEﾂｰﾙにｺﾏﾝﾄﾞﾗｲﾝ引数を引き継がない
    Public Const CPlngMenuCarrTakeOver6             As Integer = 6                     'EXEﾂｰﾙにｺﾏﾝﾄﾞﾗｲﾝ引数を引き継ぐ

    '@ﾒﾆｭｰ有効ﾌﾗｸﾞ
    Public Const CPstrEnableFlagFalse               As String = "0"                 'ﾒﾆｭｰ無効
    Public Const CPstrEnableFlagTrue                As String = "1"                 'ﾒﾆｭｰ無効

    '@ﾒﾆｭｰﾀｲﾄﾙ列設定
    Public Const CPlngMenuKeyCol                    As Integer = 0                     'ﾒﾆｭｰｷｰ列(機能ID)
    Public Const CPlngMenuTitleCol                  As Integer = 1                     'ﾀｲﾄﾙ列(機能名)
    Public Const CPlngMenuExecuteCol                As Integer = 2                     '起動中ﾌﾗｸﾞ列
    Public Const CPlngMenuCarrTakeOver              As Integer = 3                     'ｷｬﾘｱID引継ぎﾌﾗｸﾞ列

    '@ﾒﾆｭｰ用ﾒｯｾｰｼﾞ定数
    Public Const CPstrMenuKindSeparator             As String = ";"                 'MenuKind区切り文字

    '@ｱﾌﾟﾘﾊﾞｰｼﾞｮﾝ情報
    Public Const CPstrAppVer                        As String = "Ver."              'ﾊﾞｰｼﾞｮﾝ
    Public Const CPstrAppVerPeriod                  As String = "."                 'ﾋﾟﾘｵﾄﾞ

    '@ﾒﾆｭｰ画面設定用
    Public Const CPlngMenuWideLeft                  As Integer = 512                   'ﾒﾆｭｰのLeft(大)
    Public Const CPlngMenuWideWidth                 As Integer = 512                   'ﾒﾆｭｰのWidth(大)
    Public Const CPlngMenuNarrowWidth               As Integer = 60                    'ﾒﾆｭｰのWidth(小)
    Public Const CPstrMenuFormCaption               As String = " SPIRYTUS"
    Public Const CPstrFrmMenu                       As String = "frmxxMN0000"
    Public Const CPstrFrmMenuInfo                   As String = "frmxxMN0002"
    Public Const CPstrFrmxxCM0100                   As String = "frmxxCM0100"

    Public Const CPlngAppliHeight                   As Integer = 681                  'ｱﾌﾟﾘｹｰｼｮﾝ画面ｻｲｽﾞ(高さ)
    Public Const CPlngAppliNarrowWidth              As Integer = 729                  'ｱﾌﾟﾘｹｰｼｮﾝ画面ｻｲｽﾞ(幅)(狭)
    Public Const CPlngAppliWideWidth                As Integer = 1001                 'ｱﾌﾟﾘｹｰｼｮﾝ画面ｻｲｽﾞ(幅)(広)
    Public Const CPlngAppliSmallHeight              As Integer = 66                   'ﾌｫｰﾑの高さ
    Public Const CPlngAppliWebHeight                As Integer = 775                  'Web画面の高さ
    Public Const CPlngAppliWebWidth                 As Integer = 1038                 'Web画面の幅


    '@----------------------------------------------
    '@ 子画面関連
    '@----------------------------------------------
    '@子画面ﾌｫｰﾑID
    Public Const CPstrKeyCM0040                     As String = "CM0040"            'ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ
    Public Const CPstrKeyCM00C1                     As String = "CM00C1"            'ｷｬﾘｱ洗浄
    Public Const CPstrKeyCM00D0                     As String = "CM00D0"            'ﾛｯﾄｺﾒﾝﾄ(CFKI用)
    Public Const CPstrKeyCM00E0                     As String = "CM00E0"            'ｷｬﾘｱ一覧(汎用、基板ｻｲｽﾞ)
    Public Const CPstrKeyCM00E1                     As String = "CM00E1"            'Aｷｬﾘｱ選択
    Public Const CPstrKeyCM00E2                     As String = "CM00E2"            'Aｷｬﾘｱ選択(ﾓﾆﾀ/品確/ﾀﾞﾐｰ)
    Public Const CPstrKeyCM00F0                     As String = "CM00F0"            '機種ｴﾝﾄﾘ選択(汎用、基板ｻｲｽﾞ)
    Public Const CPstrKeyCM00H0                     As String = "CM00H0"            '工程異常処理票　兼　不適合品処理票
    Public Const CPstrKeyCM00H1                     As String = "CM00H1"            '対象ﾛｯﾄ処理
    Public Const CPstrKeyCM00H2                     As String = "CM00H2"            '作業ﾐｽ報告書
    Public Const CPstrKeyCM00H3                     As String = "CM00H3"            '工程異常名変更
    Public Const CPstrKeyCM00H4                     As String = "CM00H4"            'ﾛｯﾄ流動履歴
    Public Const CPstrKeyCM00I0                     As String = "CM00I0"            '工程異常/不適合品処理票登録
    Public Const CPstrKeyCM00J0                     As String = "CM00J0"            'ｺﾋﾟｰ元ﾛｯﾄID検索
    Public Const CPstrKeyCM00K0                     As String = "CM00K0"            '空ｷｬﾘｱ一覧(汎用、ﾂｰﾙｻｲｽﾞ)
    Public Const CPstrKeyCM00L0                     As String = "CM00L0"            '機種ｴﾝﾄﾘ選択(汎用、ﾂｰﾙｻｲｽﾞ)
    Public Const CPstrKeyCM00N0                     As String = "CM00N0"            '中間WF在庫選択
    Public Const CPstrKeyCM00O0                     As String = "CM00O0"            'ﾊﾟﾚｯﾄ情報
    Public Const CPstrKeyCM00Q0                     As String = "CM00Q0"            '作業ﾒﾓ(部材履歴用)
    Public Const CPstrKeyCM00S1                     As String = "CM00S1"            '宛先検索
    Public Const CPstrKeyCM00T0                     As String = "CM00T0"            'CFｷｬﾘｱ選択
    Public Const CPstrKeyCM00U0                     As String = "CM00U0"            'ODF貼り合せ
    Public Const CPstrKeyCM00V0                     As String = "CM00V0"            'ﾛｯﾄｺﾒﾝﾄ(ﾛｯﾄ投入(組立)用)
    Public Const CPstrKeyCM00X0                     As String = "CM00X0"            '処理終了(ｲﾝﾌｫﾒｰｼｮﾝ画面)
    Public Const CPstrKeyCM00Y0                     As String = "CM00Y0"            '使用部材一覧画面
    Public Const CPstrKeyCM00Z0                     As String = "CM00Z0"            '装置ﾒﾝﾃﾅﾝｽ記録票画面
    Public Const CPstrKeyCM00Z1                     As String = "CM00Z1"            '故障現象名選択/保全記録票選択画面
    Public Const CPstrKeyCM0100                     As String = "CM0100"            'ﾒｲﾝﾒﾆｭｰ(ﾒｯｾｰｼﾞﾊﾞｰ)
    Public Const CPstrKeyCM0130                     As String = "CM0130"            '治具一覧
    Public Const CPstrKeyCM01C0                     As String = "CM01C0"            '在庫ﾛｯﾄ一覧
    Public Const CPstrKeyCM01D0                     As String = "CM01D0"            '現品票ﾗﾍﾞﾙ読込
    Public Const CPstrKeyEN00F1                     As String = "EN00F1"            '在庫保留/保留解除(在庫管理)
    Public Const CPstrKeyEN00F2                     As String = "EN00F2"            '在庫払出(在庫管理)
    Public Const CPstrKeyEN00F3                     As String = "EN00F3"            '組立在庫分割予約(在庫管理)
    Public Const CPstrKeyEN00F4                     As String = "EN00F4"            'ｺﾒﾝﾄ(在庫管理)
    Public Const CPstrKeyEN00F5                     As String = "EN00F5"            '送品伝票印刷(在庫管理)
    Public Const CPstrKeyEN00F6                     As String = "EN00F6"            'CF在庫ﾘﾜｰｸ(在庫管理)
    Public Const CPstrKeyEN00F7                     As String = "EN00F7"            'CF在庫処置(在庫管理)
    Public Const CPstrKeyEN00F8                     As String = "EN00F8"            'ｺﾒﾝﾄ(在庫管理)
    Public Const CPstrKeyEN00F9                     As String = "EN00F9"            '送品取消(在庫管理)
    Public Const CPstrKeyEN00FA                     As String = "EN00FA"            'WF情報(在庫管理)
    Public Const CPstrKeyEN00M1                     As String = "EN00M1"            'ﾓﾆﾀﾛｯﾄ一覧(ﾊﾞｯﾁ管理)
    Public Const CPstrKeyEN00Y1                     As String = "EN00Y1"            'ﾘﾜｰｸ不適合品処理起案(特殊流動)
    Public Const CPstrKeyEN00Z1                     As String = "EN00Z1"            'ﾚﾁｸﾙ情報変更(ﾚﾁｸﾙ管理)
    Public Const CPstrKeyEN00Z2                     As String = "EN00Z2"            'ｴﾗｰ設定(ﾚﾁｸﾙ管理)
    Public Const CPstrKeyEN0191                     As String = "EN0191"            'ｴﾗｰ設定(現工程不良詳細)
    Public Const CPstrKeyEN01G1                     As String = "EN01G1"            '装置ﾚｼﾋﾟ表示(流動票)
    Public Const CPstrKeyEN01G2                     As String = "EN01G2"            'ﾛｯﾄｺﾒﾝﾄ(流動票)
    Public Const CPstrKeyEN01K1                     As String = "EN01K1"            '変更履歴(流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ)
    Public Const CPstrKeyEN01N1                     As String = "EN01N1"            'ﾒﾝﾃﾅﾝｽ履歴確認(CMPﾒﾝﾃﾅﾝｽ)
    Public Const CPstrKeyEN01S1                     As String = "EN01S1"            'P/Rｵｰﾀﾞｰ登録
    Public Const CPstrKeyEN01U1                     As String = "EN01U1"            'ﾚｼﾋﾟ一覧
    Public Const CPstrKeyEN01U2                     As String = "EN01U2"            'ﾌｫﾄF/B patch分割パラメータ設定
    Public Const CPstrKeyEN01V1                     As String = "EN01V1"            '装置使用部材登録
    'Public Const CPstrKeyEN01W1                     As String = "EN01W1"            '装置停止・ﾒﾝﾃ計画
    'Public Const CPstrKeyEN01W2                     As String = "EN01W2"            '装置停止・ﾒﾝﾃ計画/実績表示
    Public Const CPstrKeyEN01Y1                     As String = "EN01Y1"            '星取表表示
    Public Const CPstrKeyEN01X1                     As String = "EN01X1"            'ﾛｯﾄ一覧(工順変更)
    Public Const CPstrKeyEN01X2                     As String = "EN01X2"            'ﾌﾟﾛｾｽ編集(工順変更)
    Public Const CPstrKeyEN01X3                     As String = "EN01X3"            '処理条件編集(工順変更)
    Public Const CPstrKeyEN01X4                     As String = "EN01X4"            'ｺﾋﾟｰ元　ﾏｽﾀ工順選択(工順変更)
    Public Const CPstrKeyEN01X5                     As String = "EN01X5"            '時間制限設定(工順変更)
    Public Const CPstrKeyEN01X6                     As String = "EN01X6"            'ﾌｫﾄF/B設定(工順変更)
    Public Const CPstrKeyEN01X7                     As String = "EN01X7"            'ｺﾋﾟｰ元　ﾛｯﾄ工順選択(工順変更)
    Public Const CPstrKeyEN01X8                     As String = "EN01X8"            '号機記憶工程一覧(工順変更)
    Public Const CPstrKeyEN01X9                     As String = "EN01X9"            '設定値検索(工順変更)
    Public Const CPstrKeyEN01Z1                     As String = "EN01Z1"            '装置ﾒﾝﾃﾅﾝｽ記録票(新規登録画面)
    Public Const CPstrKeyEN0271                     As String = "EN0271"            'WF指定ｱｸｼｮﾝ予約
    Public Const CPstrKeyCM01B0                     As String = "CM01B0"            'CF/TFTロット紐付


    '@子画面ﾀｲﾄﾙ定数
    Public Const CPstrSubDispTitleActionMsg         As String = "アクション予約メッセージ"
    Public Const CPstrSubDispTitleActionInfo        As String = "アクション予約実行メッセージ"
    Public Const CPstrSubDispTitleCarrierList       As String = "キャリア一覧"
    Public Const CPstrSubDispTitleLotThrwList       As String = "投入予定ロット一覧"
    Public Const CPstrSubDispTitleCopyLotSel        As String = "コピー元ロットID一覧"
    Public Const CPstrSubDispTitleDiviLotSel        As String = "分割元ロットID一覧"
    Public Const CPstrSubDispTitleVenderList        As String = "ベンダーロット一覧"
    Public Const CPstrSubDispTitleQualityInfo       As String = "品質情報(品質記録/作業記録)登録参照"
    Public Const CPstrSubDispTitleRepSet            As String = "レシピ設定変更"
    Public Const CPstrSubDispTitlePDEntryList       As String = "エントリ一覧"
    Public Const CPstrSubDispTitleUserPrcList       As String = "ユーザープロセス一覧"
    Public Const CPstrSubDispTitleSign              As String = "サイン"
    Public Const CPstrSubFormDivid                  As String = "装置使用部材分割"
    Public Const CPstrSubFormDateChg                As String = "装置使用部材日時変更"
    Public Const CPstrSubFormOrder                  As String = "装置使用部材発注"
    Public Const CPstrSubFormRegist                 As String = "装置使用部材登録"

    Public Const CPstrSubFormCM00C1                 As String = "キャリア洗浄"
    Public Const CPstrSubFormCM00E0Carrier          As String = "空きキャリア一覧"
    Public Const CPstrSubFormCM00E0SMIF             As String = "空きSMIF一覧"
    Public Const CPstrSubFormCM00H0                 As String = "工程異常処理票 兼 不適合品処理票"
    Public Const CPstrSubFormCM00H1                 As String = "対象ロット処置"
    Public Const CPstrSubFormCM00H2                 As String = "作業ミス報告書"
    Public Const CPstrSubFormCM00H3T                As String = "工程異常名変更"
    Public Const CPstrSubFormCM00H3I                As String = "不良特性名変更"
    Public Const CPstrSubFormCM00H4                 As String = "ロット流動履歴"
    Public Const CPstrSubFormCM00Q0                 As String = "作業メモ"
    Public Const CPstrSubFormCM00S0                 As String = "メール送信"
    Public Const CPstrSubFormCM00S0BatchMoveIn      As String = "バッチ投入順通知"
    Public Const CPstrSubFormCM00S0EXCP             As String = "工程異常処理票　兼　不適合品処理票確認依頼"
    Public Const CPstrSubFormCM00S0HOLD             As String = "保留ロットメール送信"
    Public Const CPstrSubFormCM00T0                 As String = "TFT/CFロット紐付き情報"
    Public Const CPstrSubFormCM00V0Comments         As String = "コメント"
    Public Const CPstrSubFormCM00V0Restrict         As String = "時間制限"
    Public Const CPstrSubFormCM00V1                 As String = "ロットコメント"
    Public Const CPstrSubFormCM00X0Proc             As String = "処理終了"
    Public Const CPstrSubFormCM00X0Work             As String = "作業終了"
    Public Const CPstrSubFormCM00X0Chip             As String = "チップ状態変更登録"
    Public Const CPstrSubFormCM00W0                 As String = "投入予定ロット変更/削除"
    Public Const CPstrSubFormCM00Z0                 As String = "装置メンテナンス記録票"
    Public Const CPstrSubFormCM01B0                 As String = "TFT/CFロット紐付き情報"
    Public Const CPstrSubFormCM01C0                 As String = "在庫ロット一覧"
    Public Const CPstrSubFormEN00F1Hold             As String = "ロット保留"
    Public Const CPstrSubFormEN00F1Cancel           As String = "ロット保留解除"
    Public Const CPstrSubFormEN00F2                 As String = "在庫払出"
    Public Const CPstrSubFormEN00F3                 As String = "組立在庫分割予約"
    Public Const CPstrSubFormEN00F4                 As String = "ロットコメント"
    Public Const CPstrSubFormEN00F4Next             As String = "次SB連絡"
    Public Const CPstrSubFormEN00F4Pre              As String = "前SB連絡"
    Public Const CPstrSubFormEN00F6                 As String = "CF在庫リワーク"
    Public Const CPstrSubFormEN00F7                 As String = "CF在庫処置"
    Public Const CPstrSubFormEN00F9                 As String = "送品取消"
    Public Const CPstrSubFormEN00FA                 As String = "WF情報表示"
    Public Const CPstrSubFormEN00Y1                 As String = "リワーク原因設定"
    Public Const CPstrSubFormEN00Z1                 As String = "レチクル情報変更"
    Public Const CPstrSubFormEN00Z2                 As String = "エラー設定"
    Public Const CPstrSubFormEN0191                 As String = "現工程不良詳細"
    Public Const CPstrSubFormEN01J1                 As String = "コメント"
    Public Const CPstrSubFormEN01W2                 As String = "装置停止・メンテ計画/実績"
    Public Const CPstrSubFormEN01Y1                 As String = "星取表表示"
    Public Const CPstrSubFormEN01Z0                 As String = "装置メンテナンス記録票確認依頼"


    '@----------------------------------------------
    '@ 権限関連
    '@----------------------------------------------
    '@ActionID
    '@☆☆☆実行権限追加対象処理☆☆☆
    Public Const CPstrExcpApply                     As String = "工程異常/不適合品処理票承認"
    Public Const CPstrAuthority                     As String = "処置登録"
    Public Const CPstrOrder                         As String = "オーダー取込"
    Public Const CPstrReleaseAuth                   As String = "リリース承認/取消"
    Public Const CPstrExcpDiscon                    As String = "工程異常/不適合品処理票破棄"
    Public Const CPstrReworkHoldCancel              As String = "リワーク保留解除"
    Public Const CPstrLotChgPlan                    As String = "変更/削除"
    Public Const CPstrPrOrderControl                As String = "P/Rオーダー管理"
    Public Const CPstrUsePeriodOverMaterial         As String = "期限超過部材使用"
    Public Const CPstrUsePdRestrictMaterial         As String = "機種限定部材使用"
    Public Const CPstr1A0ChangeSendSB               As String = "基板送品先設定"
    Public Const CPstr2A0ChangeSendSB               As String = "組立送品先設定"
    Public Const CPstr3A0ChangeSendSB               As String = "防湿膜ALD送品先設定"
    Public Const CPstrUseNewMaterial                As String = "新部材使用"
    Public Const CPstrHoldRelease                   As String = "保留/保留解除"
    Public Const CPstrPrEsRecipeChange              As String = "PR/ESロットレシピ変更"
    Public Const CPstrApply                         As String = "装置メンテナンス記録票承認"
    Public Const CPstrDiscon                        As String = "装置メンテナンス記録票破棄"
    Public Const CPstrProcessingStCancel            As String = "処理開始取消"
    Public Const CPstrExposureAuth                  As String = "露光パラメータ変更"
    Public Const CPstrPlanShipAuth                  As String = "送品予定日変更"
    Public Const CPstrPlanAssembleAuth              As String = "組立投入予定変更"
    Public Const CPstrChangeApply                   As String = "工順変更適用"
    Public Const CPstrWFStatusChange                As String = "不良/払出"
    Public Const CPstrRollBackOpStep                As String = "工程戻し"
    Public Const CPstrPlanShipAuthPlural            As String = "送品予定日一括変更"
    Public Const CPstrFirstPhotoWpIDChange          As String = "1stフォト装置設定変更"
    Public Const CPstrCBRCarrierIdSkip              As String = "BCRキャリアID照合スキップ"
    Public Const CPstrProductLotSendChange          As String = "量産Lot送品先変更"
    Public Const CPstrProductLotThrowRsv            As String = "量産ロット登録"
    Public Const CPstrOvertake                      As String = "ロット追越制限"
    Public Const CPstrInvalid                       As String = "無効化"
	Public Const CPstrNotUseScrap					As String = "使用不可/廃却"


    '@職制社員取得対象処理
    Public Const CPstrRoleForeman                   As String = "作業長"

    '@技術/製造ﾁｪｯｸ用
    Public Const CPstrDeptIDStaff                   As String = "STAFF"             '所属職場："STAFF"判定用
    Public Const CPstrDeptIDLine                    As String = "LINE"              '所属職場："LINE"判定用
    Public Const CPstrDeptNameStaff                 As String = "技術"              '所属職場："技術"表示用
    Public Const CPstrDeptNameLine                  As String = "製造"              '所属職場："製造"表示用


    '@----------------------------------------------
    '@ 工順変更関連
    '@----------------------------------------------
    '@vsfProcCngListの定数宣言(ｶﾗﾑ)
    Public Const CPlngvsfProcCngListNo              As Integer = 0                     '№
    Public Const CPlngvsfProcCngListKb              As Integer = 1                     '保/停
    Public Const CPlngvsfProcCngListLotID           As Integer = 2                     'ﾛｯﾄID
    Public Const CPlngvsfProcCngListOpID            As Integer = 3                     '大工程
    Public Const CPlngvsfProcCngListStepID          As Integer = 4                     '小工程
    Public Const CPlngvsfProcCngListLotStatus       As Integer = 5                     'ﾛｯﾄ現在状態
    Public Const CPlngvsfProcCngListLotPos          As Integer = 6                     'ﾛｯﾄ位置
    Public Const CPlngvsfProcCngListEditStatus      As Integer = 7                     '編集状態
    Public Const CPlngvsfProcCngListEmpName         As Integer = 8                     '編集者
    Public Const CPlngvsfProcCngListEditTime        As Integer = 9                     '最終更新日時
    Public Const CPlngvsfProcCngListProcName        As Integer = 10                    'ﾕｰｻﾞｰﾌﾟﾛｾｽ名
    Public Const CPlngvsfProcCngListPdID            As Integer = 11                    '機種
    Public Const CPlngvsfProcCngListCarrierID       As Integer = 12                    'ｷｬﾘｱID
    Public Const CPlngvsfProcCngListEmpID           As Integer = 13                    '編集者ID
    Public Const CPlngvsfProcCngListComments        As Integer = 14                    'ｺﾒﾝﾄ
    Public Const CPlngvsfProcCngListHistoryFlag     As Integer = 15                    '変更履歴読込ﾌﾗｸﾞ(Null：未読込み、"1"：読込済み)
    Public Const CPlngvsfProcCngListHistory         As Integer = 16                    '変更履歴
    Public Const CPlngvsfProcCngListKindFlag        As Integer = 17                    '種別(1：ﾛｯﾄ工順変更、2：組立工順一時保存)
    Public Const CPlngvsfProcCngListFlowClass       As Integer = 18                    '流動区分
    Public Const CPlngvsfProcCngListLotHold         As Integer = 19                    '保留区分
    Public Const CPlngvsfProcCngListLotStop         As Integer = 20                    '停止区分
    Public Const CPlngvsfProcCngListLcDirection     As Integer = 21                    '液晶方向
    Public Const CPlngvsfProcCngListReworkFlag      As Integer = 22                    'ﾘﾜｰｸﾌﾗｸﾞ(0：通常、1：ﾘﾜｰｸ、2：追加)
    Public Const CPlngvsfProcCngListProcFlag        As Integer = 23                    'ﾛｯﾄ種別(0：通常、1：特殊)
    Public Const CPlngvsfProcCngListWfCarryFlag     As Integer = 24                    'WF移載中ﾌﾗｸﾞ
    Public Const CPlngvsfProcCngListProhibitedFlag  As Integer = 25                    'VerUp禁止(0：可、1：不可)
    Public Const CPlngvsfProcCngListProhibitedEmp   As Integer = 26                    '禁止設定者
    Public Const CPlngvsfProcCngListProhibitedDept  As Integer = 27                    '禁止設定者部署
    Public Const CPlngvsfProcCngListLotLastUpdate   As Integer = 28                    '最終更新日時(lot_staus)

    '@処理条件ｾｯﾄIDﾘｽﾄ
    Public Const CPlngvsfConListNo                  As Integer = 0                     '№
    Public Const CPlngvsfConListConID               As Integer = 1                     '処理条件ｾｯﾄID
    Public Const CPlngvsfConListVer                 As Integer = 2                     'Ver
    Public Const CPlngvsfConListStatID              As Integer = 3                     '状態
    Public Const CPlngvsfConListOptionText          As Integer = 4                     '作業条件
    Public Const CPlngvsfConListSkipFlag            As Integer = 5                     'ｽｷｯﾌﾟﾌﾗｸﾞ
    Public Const CPlngvsfConListLoaderUnloaderFlag  As Integer = 6                     'ﾎﾟｰﾄ属性
    Public Const CPlngvsfConListTransMode           As Integer = 7                     '移載ﾓｰﾄﾞ
    Public Const CPlngvsfConListMaxVerFlag          As Integer = 8                     '最新Verﾌﾗｸﾞ

    '@処理条件ｾｯﾄID詳細ﾘｽﾄ(装置個別/装置共通)
    Public Const CPlngvsfConDetailListNo            As Integer = 0                     '№
    Public Const CPlngvsfConDetailListWpName        As Integer = 1                     '装置名
    Public Const CPlngvsfConDetailListWF            As Integer = 2                     'WF
    Public Const CPlngvsfConDetailListRecID         As Integer = 3                     'ﾚｼﾋﾟ
    Public Const CPlngvsfConDetailListDefaultFlag   As Integer = 4                     'ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
    Public Const CPlngvsfConDetailListWpID          As Integer = 5                     '装置ID
    Public Const CPlngvsfConDetailListRecVer        As Integer = 6                     'ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝ

    '@ﾌﾛｰﾘｽﾄの列番号
    Public Const CPlngvsfFlowNo                     As Integer = 0                     '№
    Public Const CPlngvsfFlowAbsNo                  As Integer = 1                     '絶対番号
    Public Const CPlngvsfFlowOpID                   As Integer = 2                     '大工程ID
    Public Const CPlngvsfFlowStepID                 As Integer = 3                     '小工程ID
    Public Const CPlngvsfFlowConditionID            As Integer = 4                     '処理条件ｾｯﾄID
    Public Const CPlngvsfFlowConditionVer           As Integer = 5                     '処理条件ｾｯﾄIDVer
    Public Const CPlngvsfFlowConditionOne           As Integer = 6                     '処理条件個別
    Public Const CPlngvsfFlowSelectConditionID      As Integer = 7                     '測定条件ｾｯﾄID
    Public Const CPlngvsfFlowCollectionID           As Integer = 8                     '収集項目ｾｯﾄID
    Public Const CPlngvsfFlowCollectionVer          As Integer = 9                     '収集項目ｾｯﾄIDVer
    Public Const CPlngvsfFlowLotScrapSetId          As Integer = 10                    '不良項目ｾｯﾄID
    Public Const CPlngvsfFlowReworkRouteID          As Integer = 11                    'ﾘﾜｰｸﾙｰﾄID
    Public Const CPlngvsfFlowReworkReturnOpID       As Integer = 12                    'ﾘﾜｰｸ戻り先大工程ID
    Public Const CPlngvsfFlowReworkReturnStepID     As Integer = 13                    'ﾘﾜｰｸ戻り先小工程ID
    Public Const CPlngvsfFlowSPRouteID              As Integer = 14                    '特殊ﾙｰﾄID
    Public Const CPlngvsfFlowSPReturnOpID           As Integer = 15                    '特殊戻り先大工程ID
    Public Const CPlngvsfFlowSPReturnStepID         As Integer = 16                    '特殊戻り先小工程ID
    Public Const CPlngvsfFlowSwapIndictor           As Integer = 17                    '入替可能ｲﾝｼﾞｹｰﾀ
    Public Const CPlngvsfFlowSwapIndictorCopy       As Integer = 18                    '入替可能ｲﾝｼﾞｹｰﾀ退避
    Public Const CPlngvsfFlowAltSet                 As Integer = 19                    '代替工程
    Public Const CPlngvsfFlowAltPointer             As Integer = 20                    '代替ﾎﾟｲﾝﾀ
    Public Const CPlngvsfFlowAltStartFlag           As Integer = 21                    '代替開始ﾌﾗｸﾞ
    Public Const CPlngvsfFlowAltEndFlag             As Integer = 22                    '代替終了ﾌﾗｸﾞ
    Public Const CPlngvsfFlowGrbClass               As Integer = 23                    'GRB限定工程設定
    Public Const CPlngvsfFlowTimeLimit              As Integer = 24                    '時間制限
    Public Const CPlngvsfFlowTimeLimitFlag          As Integer = 25                    '時間制限ﾌﾗｸﾞ(変更ﾌﾗｸﾞ⇒0：変更なし、1：変更あり)
    Public Const CPlngvsfFlowLotRecipeFlag          As Integer = 26                    'ﾛｯﾄ個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
    Public Const CPlngvsfFlowWFRecipeFlag           As Integer = 27                    'WF個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
    Public Const CPlngvsfFlowSFlag                  As Integer = 28                    '特殊特性ﾌﾗｸﾞ
    Public Const CPlngvsfFlowEntryID                As Integer = 29                    'ｴﾝﾄﾘID
    Public Const CPlngvsfFlowRecipeChgFlg           As Integer = 30                    '工順ﾚｼﾋﾟ変更ﾌﾗｸﾞ
    Public Const CPlngvsfFlowWorkCondition          As Integer = 31                    '作業条件
    Public Const CPlngvsfFlowCommitFlag             As Integer = 32                    '号機指定
    Public Const CPlngvsfFlowJudgeSkipFlag          As Integer = 33                    'SPC判定ｽｷｯﾌﾟﾌﾗｸﾞ(0：SKIP不可、1：SKIP可)
    Public Const CPlngvsfFlowApc                    As Integer = 34                    'APC設定
    Public Const CPlngvsfFlowApcWfUnitFlg           As Integer = 35                    'APC枚葉設定
    Public Const CPlngvsfFlowApcSkipFlag            As Integer = 36                    'APC適用外(0：適用、1：適用外)
    Public Const CPlngvsfFlowApcCalcSkipFlag        As Integer = 37                    'APC計算除外(0：計算対象、1：計算除外)
    Public Const CPlngvsfFlowApcTeosGroupNo         As Integer = 38                    'P-TEOS グループ番号
    Public Const CPlngvsfFlowApcTeosNoInGroup       As Integer = 39                    'P-TEOS グループ内番号
    Public Const CPlngvsfFlowApcTeosCalcSkipFlag    As Integer = 40                    'P-TEOS 計算適用外
    Public Const CPlngvsfFlowApcTeosFbType          As Integer = 41                    'P-TEOS 工程タイプ
    Public Const CPlngvsfFlowTeosPrismAPC           As Integer = 42                    'Teos PrismAPC
    Public Const CPlngvsfFlowWpRestrict             As Integer = 43                    '処理号機
    Public Const CPlngvsfFlowWpRestrictFlag         As Integer = 44                    '処理号機ﾌﾗｸﾞ(変更ﾌﾗｸﾞ⇒0：変更なし、1：変更あり)
    Public Const CPlngvsfFlowState                  As Integer = 45                    '状態(STATE)：
    Public Const CPlngvsfFlowPermit                 As Integer = 46                    '編集可否(PERMIT)：
    Public Const CPlngvsfFlowChange                 As Integer = 47                    '変更区分(CHANGE)：
    '@discon判定
    Public Const CPlngvsfFlowOpValid                As Integer = 48                    '大工程有効ﾌﾗｸﾞ
    Public Const CPlngvsfFlowStepValid              As Integer = 49                    '小工程有効ﾌﾗｸﾞ
    Public Const CPlngvsfFlowConditionValid         As Integer = 50                    '処理条件ｾｯﾄID有効ﾌﾗｸﾞ
    Public Const CPlngvsfFlowCollectionValid        As Integer = 51                    '収集項目ｾｯﾄID有効ﾌﾗｸﾞ
    Public Const CPlngvsfFlowReworkRouteValid       As Integer = 52                    'ﾘﾜｰｸﾙｰﾄ有効ﾌﾗｸﾞ
    Public Const CPlngvsfFlowSPRouteValid           As Integer = 53                    '特殊ﾙｰﾄ有効ﾌﾗｸﾞ
    Public Const CPlngvsfFlowCdenClass              As Integer = 54                    'ﾁｯﾌﾟ電特区分(限定工程設定=C：ﾁｯﾌﾟ品限定工程、M：ﾓｼﾞｭｰﾙ品限定工程、設定なし(NULL)：共通工程)
    Public Const CPlngvsfFlowTpalClass              As Integer = 55                    'TPAL区分
    Public Const CPlngvsfFlowCarrierCategoryID      As Integer = 56                    'ｷｬﾘｱｶﾃｺﾞﾘID
    Public Const CPlngvsfFlowApcWfUnitFlgSetable    As Integer = 57                    'APC枚葉設定可否情報
    Public Const CPlngvsfFlowMapUseFlag             As Integer = 58                    'ﾏｯﾌﾟ適用ﾌﾗｸﾞ(0：非自動適用、1：自動適用)
    Public Const CPlngvsfFlowPriority               As Integer = 59                    '区間優先度
    Public Const CPlngvsfFlowReportPointFlag        As Integer = 60                    '実績報告工程
    Public Const CPlngvsfFlowRecpSelApc             As Integer = 61                    '｢ﾚｼﾋﾟ選択APC｣

    Public Const CPstrMeasureMark                   As String = "M"                 'APC測定ﾏｰｸ（M)
    Public Const CPstrProcessMark                   As String = "P"                 'APC処理ﾏｰｸ（P)

    Public Const CPstrRecpNot                       As String = "未設定"            'ﾚｼﾋﾟ表記文字列
    Public Const CPstrRecpNotID                     As String = "＠レシピ"          'ﾚｼﾋﾟ表記文字列

    Public Const CPlngvsfConDetailListWFCol         As Integer = 2                     'WF
    Public Const CPstrParsonalCondition             As String = "個別処理条件"
    Public Const CPstrAtMark                        As String = "@"                 '大工程判定用(ｺﾋﾟｰ行大工程の先頭に付与)
    Public Const CPstrWFRecipeMSG                   As String = "単一枚葉レシピ設定"
    Public Const CPstrWFRecipeNgMSG                 As String = "枚葉レシピ設定不可"
    Public Const CPstrWFBatchNgMSG                  As String = "バッチ"

    '@----------------------------------------------
    '@ ｵｰﾀﾞｰ振替関連
    '@----------------------------------------------
    '@ﾁｯﾌﾟ電特区分(限定工程設定)
    Public Const CPstrChip                          As String = "C"                 'C：ﾁｯﾌﾟ品限定工程
    Public Const CPstrModule                        As String = "M"                 'M：ﾓｼﾞｭｰﾙ品限定工程
    Public Const CPstrProductChip                   As String = "7"                 '7x0：ﾁｯﾌﾟ品

    '@----------------------------------------------
    '@ ﾁｯﾌﾟ・WF関連
    '@----------------------------------------------
    '@ﾁｯﾌﾟ・WFｸﾗｽ(項目)区分(ID)
    Public Const CPstrClass1                        As String = "1"                 '良品ｸﾗｽ
    Public Const CPstrClass2                        As String = "2"                 '不良ｸﾗｽ
    Public Const CPstrClass3                        As String = "3"                 '払出ｸﾗｽ
    Public Const CPstrClass4                        As String = "4"                 '保留ｸﾗｽ
    Public Const CPstrClass5                        As String = "5"                 '傾向ｸﾗｽ
    Public Const CPstrClass8                        As String = "8"                 '貼合ｸﾗｽ
    Public Const CPstrClass9                        As String = "9"                 '廃棄ｸﾗｽ
    Public Const CPstrClass10                       As String = "10"                '変更不可ｸﾗｽ

    '@ﾁｯﾌﾟ・WFｸﾗｽ(項目)区分(和名)
    Public Const CPstrClass1J                       As String = "良品"              '良品ｸﾗｽ
    Public Const CPstrClass2J                       As String = "不良"              '不良ｸﾗｽ
    Public Const CPstrClass3J                       As String = "払出"              '払出ｸﾗｽ
    Public Const CPstrClass4J                       As String = "保留"              '保留ｸﾗｽ
    Public Const CPstrClass5J                       As String = "傾向"              '傾向ｸﾗｽ
    Public Const CPstrClass8J                       As String = "貼合"              '貼合ｸﾗｽ
    Public Const CPstrClass9J                       As String = "廃棄"              '廃棄ｸﾗｽ
    Public Const CPstrClass10J                      As String = "変更不可"          '変更不可ｸﾗｽ

    '@払出ｺｰﾄﾞ定数
    Public Const CPstrForwardCode                   As String = "0THD"              '払出ｺｰﾄﾞ(※今はﾕｰｻﾞｰ要望により固定で持っている)

    '@----------------------------------------------
    '@ 無機関連
    '@----------------------------------------------
    '@TPAL区分の定数宣言
    Public Const CPstrTpalJBatch                    As String = "B"                 '蒸着ﾊﾞｯﾁ貼合
    Public Const CPstrTpalJLeft                     As String = "L"                 '蒸着左側貼合
    Public Const CPstrTpalJRight                    As String = "R"                 '蒸着右側貼合
    Public Const CPstrTpalJBatchLeft                As String = "BL"                '蒸着ﾊﾞｯﾁ+左側貼合
    Public Const CPstrTpalJBatchRight               As String = "BR"                '蒸着ﾊﾞｯﾁ+右側貼合
    Public Const CPstrTpalHBatch                    As String = "HB"                '表面ﾊﾞｯﾁ貼合

    Public Const CPstrTpalJBatchName                As String = "[蒸]ﾊﾞｯﾁ貼合"          '蒸着ﾊﾞｯﾁ貼合
    Public Const CPstrTpalJLeftName                 As String = "[蒸]左貼合"            '蒸着左側貼合
    Public Const CPstrTpalJRightName                As String = "[蒸]右貼合"            '蒸着右側貼合
    Public Const CPstrTpalJBatchLeftName            As String = "[蒸](ﾊﾞｯﾁ＋左)貼合"    '蒸着ﾊﾞｯﾁ+左側貼合
    Public Const CPstrTpalJBatchRightName           As String = "[蒸](ﾊﾞｯﾁ＋右)貼合"    '蒸着ﾊﾞｯﾁ+右側貼合
    Public Const CPstrTpalHBatchName                As String = "[表]ﾊﾞｯﾁ貼合"          '表面ﾊﾞｯﾁ貼合

    '@分割子ﾛｯﾄ生成自動実行ﾕｰｻﾞｰ
    Public Const CPstrEasyLotDivideUserID           As String = "9999995"           '簡易分割時分割ﾛｯﾄ自動生成ﾕｰｻﾞｰ

    '@ﾀﾞﾐｰ冶具、未使用処理部判定用
    Public Const CPstrDummyJig                      As String = "ダミー"            'ﾀﾞﾐｰ冶具判定用
    Public Const CPstrNotUse                        As String = "未使用"            '未使用処理部判定用

    '@区間優先度文字
    Public Const CPstrSectionPriority               As String = "区"                '区間優先判定文字

    '@----------------------------------------------
    '@ TEOS F/B関連
    '@----------------------------------------------
    '@状態の定数宣言
    Public Const CPstrStateFbData                   As String = "有効"              '有効表示文字
    Public Const CPstrStateFbNg                     As String = "禁止"              '禁止表示文字

    '@ﾊﾞｯﾁ自動編成
    Public Const CPstrAuto                          As String = "自動"              '自動
    Public Const CPstrManual                        As String = "手動"              '手動

    '@時間制限流動設定
    Public Const CPstrRestrictTypeName_0            As String = "設定なし"
    Public Const CPstrRestrictTypeName_1            As String = "開始/終了2工程(時間制限：以内)、後装置：処理部レシピあり"
    Public Const CPstrRestrictTypeName_2            As String = "開始/終了2工程(時間制限：以内)、後装置：バッチ装置"

    Public Const CPlngRestrictType_0                As Integer = 0
    Public Const CPlngRestrictType_1                As Integer = 1
    Public Const CPlngRestrictType_2                As Integer = 2

    Public Const CPstrTimeRestrictStartWait         As String = "開始待ち"

    '@----------------------------------------------
    '@ 装置別ﾛｯﾄ一覧(EN0150)のｸﾞﾘｯﾄﾞｶﾗﾑ定数(引継ぎ(xxCM0060.bas)でも使っているのでﾊﾟﾌﾞﾘｯｸに変更)
    '@----------------------------------------------
    '@ｸﾞﾘｯﾄﾞ定数
    '@1A0基板の並び
    Public Const CPlngvsfAreaEqCol_1A0_No                   As Integer = 0                     '№
    Public Const CPlngvsfAreaEqCol_1A0_Kb                   As Integer = 1                     '保/停区分
    Public Const CPlngvsfAreaEqCol_1A0_NowSt                As Integer = 3                     'ﾛｯﾄ状態
    Public Const CPlngvsfAreaEqCol_1A0_LimitTime            As Integer = 4                     '時間制限
    Public Const CPlngvsfAreaEqCol_1A0_CarrierID            As Integer = 8                     'ｷｬﾘｱID(col変更時はbasxxEN150も同じく修正する必要あり)
    Public Const CPlngvsfAreaEqCol_1A0_CarrierPositionName  As Integer = 14                    'ｷｬﾘｱ位置
    Public Const CPlngvsfAreaEqCol_1A0_CarrierStatusName    As Integer = 15                    'ｷｬﾘｱ状態
    Public Const CPlngvsfAreaEqCol_1A0_LotID                As Integer = 6                     'ﾛｯﾄID(col変更時はbasxxEN150も同じく修正する必要あり)
    Public Const CPlngvsfAreaEqCol_1A0_PdID                 As Integer = 29                    '機種(col変更時はbasxxEN150も同じく修正する必要あり)
    Public Const CPlngvsfAreaEqCol_1A0_FlowClass            As Integer = 16                    '種別
    Public Const CPlngvsfAreaEqCol_1A0_WfId                 As Integer = 20                    'WFIDの下3桁の結合("#01,#02,#03,#04,#05")
    Public Const CPlngvsfAreaEqCol_1A0_Priority             As Integer = 5                     '優先順位
    Public Const CPlngvsfAreaEqCol_1A0_OpID                 As Integer = 11                    '大工程(col変更時はbasxxEN150も同じく修正する必要あり)
    Public Const CPlngvsfAreaEqCol_1A0_StepID               As Integer = 12                    '小工程(col変更時はbasxxEN150も同じく修正する必要あり)
    Public Const CPlngvsfAreaEqCol_1A0_Recipe               As Integer = 10                    'ﾚｼﾋﾟ
    Public Const CPlngvsfAreaEqCol_1A0_DispatchStartTime    As Integer = 18                    '処理開始予実
    Public Const CPlngvsfAreaEqCol_1A0_LotManagerName       As Integer = 13                    'ﾛｯﾄ担当
    Public Const CPlngvsfAreaEqCol_1A0_WfNum                As Integer = 9                     'WF枚数
    Public Const CPlngvsfAreaEqCol_1A0_ChipNum              As Integer = 17                    'ﾁｯﾌﾟ数
    Public Const CPlngvsfAreaEqCol_1A0_CommitFlag           As Integer = 21                    '号機指定(1：指定　0：指定なし)
    Public Const CPlngvsfAreaEqCol_1A0_LCarrierID           As Integer = 22                    'ﾛｰﾀﾞｷｬﾘｱID(ｷｬﾘｱID引継ぎに使用 20を変えると作業開始で引き継がれなくなる)
    Public Const CPlngvsfAreaEqCol_1A0_UCarrierID           As Integer = 23                    'ｱﾝﾛｰﾀﾞｷｬﾘｱID(ｷｬﾘｱID引継ぎに使用)
    Public Const CPlngvsfAreaEqCol_1A0_AltNumber            As Integer = 24                    '代替番号
    Public Const CPlngvsfAreaEqCol_1A0_LotLastUpdate        As Integer = 25                    'ﾛｯﾄ最終更新日付
    Public Const CPlngvsfAreaEqCol_1A0_ReworkFlag           As Integer = 26                    'ﾘﾜｰｸﾌﾗｸﾞ(1:ﾘﾜｰｸあり　0:ﾘﾜｰｸなし)
    Public Const CPlngvsfAreaEqCol_1A0_CarrierPositionID    As Integer = 27                    'ｷｬﾘｱ位置ID
    Public Const CPlngvsfAreaEqCol_1A0_CarrierStatusID      As Integer = 28                    'ｷｬﾘｱ状態ID
    Public Const CPlngvsfAreaEqCol_1A0_LotComments          As Integer = 19                    'ｺﾒﾝﾄ
    Public Const CPlngvsfAreaEqCol_1A0_JBatchID             As Integer = 30                    '蒸着ﾊﾞｯﾁID
    Public Const CPlngvsfAreaEqCol_1A0_CfFlag               As Integer = 31                    'CFﾌﾗｸﾞ
    Public Const CPlngvsfAreaEqCol_1A0_LpFlag               As Integer = 32                    'LPﾌﾗｸﾞ
    Public Const CPlngvsfAreaEqCol_1A0_VaFlag               As Integer = 33                    '無機ﾌﾗｸﾞ
    Public Const CPlngvsfAreaEqCol_1A0_TpalClass            As Integer = 34                    'TPAL区分
    Public Const CPlngvsfAreaEqCol_1A0_HBatchID             As Integer = 35                    '表面ﾊﾞｯﾁID

    Public Const CPlngvsfAreaEqCol_1A0_ShipDiffDay          As Integer = 2                     'ﾛｯﾄ進捗度
    Public Const CPlngvsfAreaEqCol_1A0_FrFlag               As Integer = 36                    'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
    Public Const CPlngvsfAreaEqCol_1A0_GrbClass             As Integer = 7                     'GRB区分
    Public Const CPlngvsfAreaEqCol_1A0_ColorCd              As Integer = 37                    '指定色

    '@2A0組立の並び
    Public Const CPlngvsfAreaEqCol_2A0_No                   As Integer = 0                     '№
    Public Const CPlngvsfAreaEqCol_2A0_Kb                   As Integer = 1                     '保/停区分
    Public Const CPlngvsfAreaEqCol_2A0_NowSt                As Integer = 2                     'ﾛｯﾄ状態
    Public Const CPlngvsfAreaEqCol_2A0_LimitTime            As Integer = 3                     '時間制限
    Public Const CPlngvsfAreaEqCol_2A0_CarrierID            As Integer = 6                     'ｷｬﾘｱID(col変更時はbasxxEN150も同じく修正する必要あり)
    Public Const CPlngvsfAreaEqCol_2A0_CarrierPositionName  As Integer = 12                    'ｷｬﾘｱ位置
    Public Const CPlngvsfAreaEqCol_2A0_CarrierStatusName    As Integer = 13                    'ｷｬﾘｱ状態
    Public Const CPlngvsfAreaEqCol_2A0_LotID                As Integer = 7                     'ﾛｯﾄID(col変更時はbasxxEN150も同じく修正する必要あり)
    Public Const CPlngvsfAreaEqCol_2A0_PdID                 As Integer = 5                     '機種(col変更時はbasxxEN150も同じく修正する必要あり)
    Public Const CPlngvsfAreaEqCol_2A0_FlowClass            As Integer = 11                    '種別
    Public Const CPlngvsfAreaEqCol_2A0_WfId                 As Integer = 8                     'WFIDの下3桁の結合("#01,#02,#03,#04,#05")
    Public Const CPlngvsfAreaEqCol_2A0_Priority             As Integer = 14                    '優先順位
    Public Const CPlngvsfAreaEqCol_2A0_OpID                 As Integer = 15                    '大工程(col変更時はbasxxEN150も同じく修正する必要あり)
    Public Const CPlngvsfAreaEqCol_2A0_StepID               As Integer = 16                    '小工程(col変更時はbasxxEN150も同じく修正する必要あり)
    Public Const CPlngvsfAreaEqCol_2A0_Recipe               As Integer = 4                     'ﾚｼﾋﾟ
    Public Const CPlngvsfAreaEqCol_2A0_DispatchStartTime    As Integer = 17                    '処理開始予実
    Public Const CPlngvsfAreaEqCol_2A0_LotManagerName       As Integer = 18                    'ﾛｯﾄ担当
    Public Const CPlngvsfAreaEqCol_2A0_WfNum                As Integer = 9                     'WF枚数
    Public Const CPlngvsfAreaEqCol_2A0_ChipNum              As Integer = 10                    'ﾁｯﾌﾟ数
    Public Const CPlngvsfAreaEqCol_2A0_CommitFlag           As Integer = 22                    '号機指定(1：指定　0：指定なし)
    Public Const CPlngvsfAreaEqCol_2A0_LCarrierID           As Integer = 20                    'ﾛｰﾀﾞｷｬﾘｱID(ｷｬﾘｱID引継ぎに使用 20を変えると作業開始で引き継がれなくなる)
    Public Const CPlngvsfAreaEqCol_2A0_UCarrierID           As Integer = 21                    'ｱﾝﾛｰﾀﾞｷｬﾘｱID(ｷｬﾘｱID引継ぎに使用)
    Public Const CPlngvsfAreaEqCol_2A0_AltNumber            As Integer = 23                    '代替番号
    Public Const CPlngvsfAreaEqCol_2A0_LotLastUpdate        As Integer = 24                    'ﾛｯﾄ最終更新日付
    Public Const CPlngvsfAreaEqCol_2A0_ReworkFlag           As Integer = 25                    'ﾘﾜｰｸﾌﾗｸﾞ(1:ﾘﾜｰｸあり　0:ﾘﾜｰｸなし)
    Public Const CPlngvsfAreaEqCol_2A0_CarrierPositionID    As Integer = 26                    'ｷｬﾘｱ位置ID
    Public Const CPlngvsfAreaEqCol_2A0_CarrierStatusID      As Integer = 27                    'ｷｬﾘｱ状態ID
    Public Const CPlngvsfAreaEqCol_2A0_LotComments          As Integer = 19                    'ｺﾒﾝﾄ
    Public Const CPlngvsfAreaEqCol_2A0_JBatchID             As Integer = 28                    '蒸着ﾊﾞｯﾁID
    Public Const CPlngvsfAreaEqCol_2A0_CfFlag               As Integer = 29                    'CFﾌﾗｸﾞ
    Public Const CPlngvsfAreaEqCol_2A0_LpFlag               As Integer = 30                    'LPﾌﾗｸﾞ
    Public Const CPlngvsfAreaEqCol_2A0_VaFlag               As Integer = 31                    '無機ﾌﾗｸﾞ
    Public Const CPlngvsfAreaEqCol_2A0_TpalClass            As Integer = 32                    'TPAL区分
    Public Const CPlngvsfAreaEqCol_2A0_HBatchID             As Integer = 33                    '表面ﾊﾞｯﾁID
    Public Const CPlngvsfAreaEqCol_2A0_ShipDiffDay          As Integer = 34                    'ﾛｯﾄ進捗度
    Public Const CPlngvsfAreaEqCol_2A0_FrFlag               As Integer = 35                    'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
    Public Const CPlngvsfAreaEqCol_2A0_GrbClass             As Integer = 36                    'GRB区分
    Public Const CPlngvsfAreaEqCol_2A0_ColorCd              As Integer = 37                    '指定色

    '@APC機能 ﾌｫﾄF/B(合せ)のpatch分割時の定数
    Public Const CPlngPatchNoNasi                           As Integer = 0                     'patchNoの指定なし
    Public Const CPlngPatchNo1                              As Integer = 1                     'patchNo1
    Public Const CPlngPatchNo2                              As Integer = 2                     'patchNo2
    Public Const CPlngPatchNo3                              As Integer = 3                     'patchNo3
    Public Const CPlngPatchNo4                              As Integer = 4                     'patchNo4
    Public Const CPlngPatchNo5                              As Integer = 5                     'patchNo5
    Public Const CPlngPatchNo6                              As Integer = 6                     'patchNo6
    Public Const CPlngPatchNo7                              As Integer = 7                     'patchNo7
    Public Const CPlngPatchNo8                              As Integer = 8                     'patchNo8
    Public Const CPlngPatchNo9                              As Integer = 9                     'patchNo9
    Public Const CPlngFotoFBAwasePatchDivMaxNum             As Integer = 9                     'ﾌｫﾄFB(合せ)patch分割のMax数（この数値を変えただけでMax数を増減することはできません)

    '@防湿ALD定数
    Public Const CPstrProcessUnit_Lot                       As String = "LOT"
    Public Const CPstrProcessUnit_Batch                     As String = "BATCH"

    Public Const CPstrProcessUnitName_Lot                   As String = "ロット"
    Public Const CPstrProcessUnitName_Batch                 As String = "バッチ"

    '@Aｷｬﾘｱ状態定数
    Public Const CPstrACarStat_Available                    As String = "0"                 '0:空(使用可)
    Public Const CPstrACarStat_AvailableATray               As String = "1"                 '1:ATRYあり(CHIPなし)
    Public Const CPstrACarStat_AvailableATrayOnChip         As String = "2"                 '2:ATRYあり(CHIPあり)
    Public Const CPstrACarStat_NotAvailable                 As String = "9"                 '9:空(使用不可)

    '@防湿ALD処理番号
    Public Const CPstrALDProcessNum_0                       As String = "0"                 '単一設定
    Public Const CPstrALDProcessNum_10                      As String = "10"                '検数(投入)
    Public Const CPstrALDProcessNum_20                      As String = "20"                'テープ貼り
    Public Const CPstrALDProcessNum_30                      As String = "30"                'オーブン
    Public Const CPstrALDProcessNum_40                      As String = "40"                '成膜
    Public Const CPstrALDProcessNum_50                      As String = "50"                'テープ剥離
    Public Const CPstrALDProcessNum_60                      As String = "60"                '検数(送品)

    '@ﾊﾟﾈﾙ検査機WP
    Public Const CPstrPakenWpId                             As String = "H2PANEL"           'ﾊﾟ検WPID判別用(7文字判定)

    '@ﾊﾟﾈﾙ検査種類
    Public Const CPstrPanelInspectAll                       As String = "ALL"               '全数検査
    Public Const CPstrPanelInspectDecimate                  As String = "DECIMATE"          '抜取検査

End Module
