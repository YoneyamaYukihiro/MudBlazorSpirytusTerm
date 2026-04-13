'ﾌｧｲﾙ名：xxEN00K0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：バッチ作業終了　メインフォーム
'作成日：2004/07/20 (Mon) 17:07:34 S.Deguchi
'更新日：2019/06/10 (Mon) 09:48:42 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2019, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Authentication.ExtendedProtection
Imports System.Security.Permissions
Public Class frmxxEN00K0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00K0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00K0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00K0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00K0)
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
    Private Const CMstrLocalVersion                     As String = "11.00"

    '@Msgﾊﾞｰｼﾞｮﾝの宣言
    '@↓2019/06/06 (Thu) 15:40:01 Y.Yoneyama **************************************************
    'Private Const CMstrbat_lotlist_Ver                  As String = "02.02"                 'ﾊﾞｯﾁ組ﾛｯﾄ情報取得
    Private Const CMstrbat_lotlist_Ver                  As String = "03.00"                 'ﾊﾞｯﾁ組ﾛｯﾄ情報取得
    '@↑2019/06/06 (Thu) 15:40:01 Y.Yoneyama **************************************************
    Private Const CMstrbat_endwrk_Ver                   As String = "03.01"                 'ﾊﾞｯﾁ組ﾛｯﾄ作業終了
    Private Const CMstrlot_comntinfo_Ver                As String = "01.00"                 'ﾛｯﾄｺﾒﾝﾄ取得
    Private Const CMstrlot_actlist_Ver                  As String = "01.00"                 'ｱｸｼｮﾝ予約
    Private Const CMstrlot_nextsteplistVer              As String = "03.01"                 '次工程取得
    Private Const CMstrlot_nextSendVer                  As String = "03.03"                 '次工程送出
 

    Private Const CMstrlot_chkchangeorderVer            As String = "01.00"                 '量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
    Private Const CMstrlot_chkeasycombineVer            As String = "01.00"                 '簡易統合可否ﾁｪｯｸ
    Private Const CMstrctl_updwaitinglotVer             As String = "01.01"                 '処理待ちﾛｯﾄ更新
    Private Const CMstrspc_judge___Ver                  As String = "03.01"                 'SPC規格値判定
	'kkw 蒸着後流動予約追加↓
	Private Const CMstrlot_waferlistVer					As String = "02.05"					'ﾛｯﾄWF情報取得(新)
	Private Const CMstrlot_afterjrsvdetailVer			As String = "01.00"					'蒸着後流動予約情報詳細取得
	Private Const CMstrlot_afterjrsvcompletechkVer		As String = "01.00"					'蒸着後流動予約完了確認
	Private Const CMstrlot_throwrsvVer					As String = "03.00"					'投入予約登録
    Private Const CMstrlot_approveVer					As String = "01.04"					'投入ﾛｯﾄ承認要求
	Private Const CMstrcarrlist____Ver					As String = "07.00"					'ｷｬﾘｱ一覧
	Private Const CMstrcarradditionVer					As String = "01.00"					'ｷｬﾘｱ追加
	Private Const CMstrlot_dividedirectVer				As String = "01.00"					'ﾛｯﾄ分割(一括移載)
	Private Const CMstrlot_afterjrsvcombinelistVer		As String = "01.00"					'蒸着後流動予約統合対象一覧取得
	Private Const CMstrlot_chkcombineLotInVer			As String = "01.00"					'ﾛｯﾄ統合元ﾛｯﾄﾁｪｯｸ
	Private Const CMstrlot_combinedirectVer				As String = "02.00"					'ﾛｯﾄ統合(一括移載) 01.00→02.00
	Private Const CMstrlot_curstateVer					As String = "04.00"					'ﾛｯﾄ現在状態取得
	Private Const CMstrcarrmove____Ver                  As String = "03.01"					'ｷｬﾘｱ統合

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN00K0          'ﾛｰｶﾙ機能ID
	
    '@vsfBatListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfColNo                         As Integer = 0                      '順序
    Private Const CMlngvsfColCarrierID                  As Integer = 1                      'ｷｬﾘｱID
    Private Const CMlngvsfColUldCarrierID               As Integer = 2                      'ULDｷｬﾘｱID
    Private Const CMlngvsfColLotID                      As Integer = 3                      'ﾛｯﾄID
    Private Const CMlngvsfColFlowClass                  As Integer = 4                      '種別
    Private Const CMlngvsfColOpID                       As Integer = 5                      '大工程
    Private Const CMlngvsfColStepID                     As Integer = 6                      '小工程
    Private Const CMlngvsfColWFID                       As Integer = 7                      'WFID(#+2桁(例：#01))
    Private Const CMlngvsfColWFQuantity                 As Integer = 8                      'WF枚数
    Private Const CMlngvsfColJigID                      As Integer = 9                      '冶具ID
    Private Const CMlngvsfColS                          As Integer = 10                     '特殊特性
    Private Const CMlngvsfColTimeLimit                  As Integer = 11                     '時間制限
    Private Const CMlngvsfColLotManager                 As Integer = 12                     'ﾛｯﾄ担当
    Private Const CMlngvsfColStartDayTime               As Integer = 13                     '処理開始日時
    Private Const CMlngvsfColStatus                     As Integer = 14                     'ﾛｯﾄ状態
    Private Const CMlngvsfColPDID                       As Integer = 15                     '機種
    Private Const CMlngvsfColLotComment                 As Integer = 16                     'ﾛｯﾄｺﾒﾝﾄ
    Private Const CMlngvsfColLastUpdate                 As Integer = 17                     '最終更新日時
    Private Const CMlngvsfColOptionText                 As Integer = 18                     '作業条件
    Private Const CMlngvsfColNextOpID                   As Integer = 19                     '次大工程
    Private Const CMlngvsfColNextStepID                 As Integer = 20                     '次小工程
    Private Const CMlngvsfColResultFlag                 As Integer = 21                     '処理結果ﾌﾗｸﾞ
    Private Const CMlngvsfColRealTimeLimit              As Integer = 22                     '時間制限(実数)
    Private Const CMlngvsfColRestrictTypeID             As Integer = 23                     '制限時間ﾀｲﾌﾟID
    Private Const CMlngvsfColActionFlag                 As Integer = 24                     'ｱｸｼｮﾝﾌﾗｸﾞ
    Private Const CMlngvsfColLotKind                    As Integer = 25                     'ﾛｯﾄ区分(0：TFT、1：CF(小板)、2:CF(大板)、NULL：ﾀﾞﾐｰ冶具or未使用処理部)

    '@vsfBatListの定数宣言(幅)
    Private Const CMlngvsfWColNo                        As Integer = 30                     '順序
    Private Const CMlngvsfWcolCarrierID                 As Integer = 87                     'ｷｬﾘｱID
    Private Const CMlngvsfWColUldCarrierID              As Integer = 87                     'ULDｷｬﾘｱID
    Private Const CMlngvsfWColLotID                     As Integer = 78                     'ﾛｯﾄID
    Private Const CMlngvsfWColStatus                    As Integer = 40                     'ﾛｯﾄ状態
    Private Const CMlngvsfWcolFlowClass                 As Integer = 30                     '種別
    Private Const CMlngvsfWColPDID                      As Integer = 57                     '機種
    Private Const CMlngvsfWColOpID                      As Integer = 136                    '大工程
    Private Const CMlngvsfWColStepID                    As Integer = 136                    '小工程
    Private Const CMlngvsfWColWFID                      As Integer = 40                     'WFID(#+2桁(例：#01))
    Private Const CMlngvsfWColWFQuantity                As Integer = 30                     'WF枚数
    Private Const CMlngvsfWColJigID                     As Integer = 87                     '冶具ID
    Private Const CMlngvsfWColS                         As Integer = 30                     '特殊特性
    Private Const CMlngvsfWColTimeLimit                 As Integer = 78                     '時間制限
    Private Const CMlngvsfWColLotManager                As Integer = 80                     'ﾛｯﾄ担当
    Private Const CMlngvsfWColStartDayTime              As Integer = 136                    '処理開始日時
    Private Const CMlngvsfWColLotComment                As Integer = 133                    'ﾛｯﾄｺﾒﾝﾄ
    Private Const CMlngvsfWColLastUpdate                As Integer = 133                    '最終更新日時
    Private Const CMlngvsfWColOptionText                As Integer = 133                    '作業条件
    Private Const CMlngvsfWColNextOpID                  As Integer = 133                    '次大工程
    Private Const CMlngvsfWColNextStepID                As Integer = 133                    '次小工程
    Private Const CMlngvsfWColResultFlag                As Integer = 0                      '処理結果ﾌﾗｸﾞ
    Private Const CMlngvsfWColRealTimeLimit             As Integer = 0                      '時間制限(実数)
    Private Const CMlngvsfWColRestrictTypeID            As Integer = 0                      '制限時間ﾀｲﾌﾟID
    Private Const CMlngvsfWColActionFlag                As Integer = 20                     'ｱｸｼｮﾝﾌﾗｸﾞ
    Private Const CMlngvsfWColLotKind                   As Integer = 0                      'ﾛｯﾄ区分(0：TFT、1：CF、NULL：ﾀﾞﾐｰ冶具or未使用処理部)

    '@vsfBatListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfColNo                         As String = "順"                    '順序
    Private Const CMstrvsfColCarrierID                  As String = "ｷｬﾘｱID"                'ｷｬﾘｱID
    Private Const CMstrvsfColUldCarrierID               As String = "ULDｷｬﾘｱID"             'ULDｷｬﾘｱID
    Private Const CMstrvsfColLotID                      As String = "ﾛｯﾄID"                 'ﾛｯﾄID
    Private Const CMstrvsfColStatus                     As String = "状態"                  'ﾛｯﾄ状態
    Private Const CMstrvsfColFlowClass                  As String = "種"                    '種別
    Private Const CMstrvsfColPDID                       As String = "機種"                  '機種
    Private Const CMstrvsfColOpID                       As String = "大工程"                '大工程
    Private Const CMstrvsfColStepID                     As String = "小工程"                '小工程
    Private Const CMstrvsfColWFID                       As String = "WFID"                  'WFID(#+2桁(例：#01))
    Private Const CMstrvsfColWFQuantity                 As String = "WF"                    'WF枚数
    Private Const CMstrvsfColJigID                      As String = "冶具ID"                '冶具ID
    Private Const CMstrvsfColS                          As String = "特"                    '特殊特性
    Private Const CMstrvsfColTimeLimit                  As String = "時間制限"              '時間制限
    Private Const CMstrvsfColLotManager                 As String = "ﾛｯﾄ担当"               'ﾛｯﾄ担当
    Private Const CMstrvsfColStartDayTime               As String = "処理開始日時"          '処理開始日時
    Private Const CMstrvsfColLotComment                 As String = "コメント"              'ﾛｯﾄｺﾒﾝﾄ
    Private Const CMstrvsfColLastUpdate                 As String = "更新日時"              '最終更新日時
    Private Const CMstrvsfColOptionText                 As String = "作業条件"              '作業条件
    Private Const CMstrvsfColNextOpID                   As String = "次大工程"              '次大工程
    Private Const CMstrvsfColNextStepID                 As String = "次小工程"              '次小工程
    Private Const CMstrvsfColActionFlag                 As String = "ア"                    'ｱｸｼｮﾝﾌﾗｸﾞ
    Private Const CMstrvsfColLotKind                    As String = "ﾛｯﾄ区分"               'ﾛｯﾄ区分(0：TFT、1：CF、NULL：ﾀﾞﾐｰ冶具or未使用処理部)

    '@vsfBatListの定数宣言
    Private Const CMlngVsfRowTitle                      As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                      As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                     As Integer = 12                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                       As Integer = 21                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                        As Integer = 43                     '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfFrozenCols                    As Integer = 4                      '固定列数
    Private Const CMlngvsfLeftHiddenCols                As Integer = 3                      '最左表示

    '@vsfNextStepInfoの定数宣言(ｶﾗﾑ)
    Private Const CMlngNextStepInfoColCarrierID         As Integer = 0                      'ｷｬﾘｱID
    Private Const CMlngNextStepInfoColLotID             As Integer = 1                      'ﾛｯﾄID
    Private Const CMlngNextStepInfoColFlowClass         As Integer = 2                      '種別
    Private Const CMlngNextStepInfoColOpID              As Integer = 3                      '大工程ID
    Private Const CMlngNextStepInfoColStepID            As Integer = 4                      '小工程ID
    Private Const CMlngNextStepInfoColDefault           As Integer = 5                      'ﾃﾞﾌｫﾙﾄ
    Private Const CMlngNextStepInfoColWPID              As Integer = 6                      'WPID

    '@vsfNextStepInfoの定数宣言(ColWidth)
    Private Const CMlngGridColWidthCarrierID            As Integer = 98                     'ｷｬﾘｱID
    Private Const CMlngGridColWidthLotID                As Integer = 98                     'ﾛｯﾄID
    Private Const CMlngGridColWidthFlowClass            As Integer = 30                     '種別
    Private Const CMlngGridColWidthOpID                 As Integer = 206                    '大工程ID
    Private Const CMlngGridColWidthStepID               As Integer = 206                    '小工程ID
    Private Const CMlngGridColWidthDefault              As Integer = 67                     'ﾃﾞﾌｫﾙﾄ
    Private Const CMlngGridColWidthWPID                 As Integer = 200                    'WPID

    '@vsfNextStepInfoの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrNextStepInfoColTCarrierID        As String = "ｷｬﾘｱID"                'ｷｬﾘｱID
    Private Const CMstrNextStepInfoColTLotID            As String = "ﾛｯﾄID"                 'ﾛｯﾄID
    Private Const CMstrNextStepInfoColTFlowClass        As String = "種"                    '種別
    Private Const CMstrNextStepInfoColTOpID             As String = "次大工程"              '大工程ID
    Private Const CMstrNextStepInfoColTStepID           As String = "次小工程"              '小工程ID
    Private Const CMstrNextStepInfoColTDefault          As String = "ﾃﾞﾌｫﾙﾄ"                'ﾃﾞﾌｫﾙﾄ
    Private Const CMstrNextStepInfoColTWPID             As String = "装置名"                'WPID

    '@vsfNextStepInfoの定数宣言
    Private Const CMlngGridFixedRows                    As Integer = 1                      'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngGridTitleHeight                  As Integer = 21                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngGridRowHeight                    As Integer = 18                     '1明細の高さ
    Private Const CMlngGridPageRows                     As Integer = 4                      '1ﾍﾟｰｼﾞのｾﾙの行数
    Private Const CMlngGrid3DBlank                      As Integer = 5                      'ｸﾞﾘｯﾄﾞの3D表示の余白
    Private Const CMlngGrid3DBlankHeight                As Integer = 2                      'NSYS ｸﾞﾘｯﾄﾞの3D表示の縦余白
    Private Const CMlngScrollButtonSize                 As Integer = 49                     'ｽｸﾛｰﾙﾎﾞﾀﾝのｻｲｽﾞ

    Private Const CMlngGridRowTitle                     As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMstrDefaultStep                      As String = "○"                    'ﾃﾞﾌｫﾙﾄ小工程
    Private Const CMstrDaitaiStep                       As String = "　"                    '代替小工程

    '@vsfNextStepInfoの幅
    Private Const CMlngGridWidth                        As Integer = CMlngGridColWidthCarrierID _
                                                        + CMlngGridColWidthLotID _
                                                        + CMlngGridColWidthFlowClass _
                                                        + CMlngGridColWidthOpID _
                                                        + CMlngGridColWidthStepID _
                                                        + CMlngGridColWidthDefault _
                                                        + CMlngGridColWidthWPID _
                                                        + CMlngGrid3DBlank
    '@vsfNextStepInfoの高さ
    Private Const CMlngGridHeight                       As Integer = (CMlngGridTitleHeight _
                                                        * CMlngGridFixedRows) _
                                                        + (CMlngGridRowHeight _
                                                        * CMlngGridPageRows) _
                                                        + CMlngGrid3DBlankHeight

    '@定数宣言
    Private Const CMstrCarrierIDTitle                   As String = "ｷｬﾘｱID： "             'ｺﾒﾝﾄ入力ｷｬﾘｱ表示
    Private Const CMstrHour                             As String = "h"                     '時間制限
    Private Const CMstrFlagOK                           As String = "○"                    'ｱｸｼｮﾝ予約有り
    Private Const CMlngStartPDID                        As Integer = 1                      '機種IDの取得開始位置
    Private Const CMlngLengthPDID                       As Integer = 3                      '機種IDの取得長
    Private Const CMlngSideScrollOnFlag                 As Integer = 1                      '横ｽｸﾛｰﾙ活性化
    Private Const CMlngSideScrollOffFlag                As Integer = 2                      '横ｽｸﾛｰﾙ非活性化
    Private Const CMlngCmbRowHeight                     As Integer = 43                     'ｺﾝﾎﾞﾘｽﾄ行の高さ
    Private Const CMstrStepDaitai                       As String = "0"                     'ﾃﾞﾌｫﾙﾄ以外
    Private Const CMstrStepDefault                      As String = "1"                     'ﾃﾞﾌｫﾙﾄ
    Private Const CMstrEnter                            As String = "$"                     '
    Private Const CMlngMaxDispRowW                      As Integer = 3                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)
    Private Const CMlngMaxDispRowC                      As Integer = 3                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ｺﾒﾝﾄ)

    '@次工程送出ﾊﾞｯﾁﾌﾗｸﾞ定数宣言
    Private Const CMlngBatchWorkEnd                     As Integer = 1                      'ﾊﾞｯﾁ作業終了正常処理(=1)
    Private Const CMlngBatchOnError                     As Integer = 2                      'ﾊﾞｯﾁ作業終了通信ｴﾗｰ(=2)
    Private Const CMlngBatchRequestFail                 As Integer = 3                      'ﾊﾞｯﾁ作業終了正常処理(=3)

    '@処理結果ﾌﾗｸﾞ用
    Private Const CMstrResultFlag00                     As String = "00"                    '流動可(次工程送出可)
    Private Const CMstrResultFlag1                      As String = "1"                     '10の位で使用時：移載予約状態、1の位で使用時：ｱｸｼｮﾝ予約停止
    Private Const CMstrResultFlag2                      As String = "2"                     'ｱｸｼｮﾝ予約保留
    Private Const CMstrResultFlag3                      As String = "3"                     '異常処理票保留
    Private Const CMstrResultFlag4                      As String = "4"                     '通常保留
    Private Const CMlngResultRight1                     As Integer = 1                      '処理結果の右1桁用
    Private Const CMstrResultFlag_                      As String = "#"                     '処理結果比較用

    '@次工程ｵﾌﾟｼｮﾝﾎﾞﾀﾝの定数宣言
    Private Const CMlngOptLotNextSend0                  As Integer = 0                      '送出あり
    Private Const CMlngOptLotNextSend1                  As Integer = 1                      '送出なし

    '@その他
    Private Const CMstrEN00K0Title                      As String = "作業終了"
    Private Const CMstrBrLeft                           As String = "["                     '成功ﾒｯｾｰｼﾞ用
    Private Const CMstrBrRight                          As String = "]"                     '成功ﾒｯｾｰｼﾞ用
    Private Const CMstrMsgHold                          As String = "保留"                  '保留
    Private Const CMstrMsgExcpHold                      As String = "異常処理票保留"        '異常処理票保留
    Private Const CMstrMsgActHold                       As String = "アクション予約保留"    'ｱｸｼｮﾝ予約保留
    Private Const CMstrMsgActStop                       As String = "アクション予約停止"    'ｱｸｼｮﾝ予約停止
    Private Const CMstrMsgMove                          As String = "移載予約"              '移載予約

    '@ﾚｽﾎﾟﾝｽ計測用
    Private Const CMstrFormName                         As String = "frmxxEN00K0"                   '自ﾌｫｰﾑ名
    Private Const CMstrCmdActionDispClick               As String = "cmdActionDisp_Click"           'ｲﾍﾞﾝﾄ名定数(ｱｸｼｮﾝ予約確認ﾎﾞﾀﾝ押下)
    Private Const CMstrCmdRegistClick                   As String = "cmdRegist_Click"               'ｲﾍﾞﾝﾄ名定数(確定ﾎﾞﾀﾝ押下)
	Private Const CMstrprvblnCombineList				As String = "prvblnCombineList"				'ｲﾍﾞﾝﾄ名定数()
	Private Const CMstrprvblnCombine					As String = "prvblnCombine"					'ｲﾍﾞﾝﾄ名定数()
    Private Const CMstrTxtCarrierValidate               As String = "txtCarrier_Validate"           'ｲﾍﾞﾝﾄ名定数(ｷｬﾘｱIDﾃｷｽﾄValidate処理)
    Private Const CMstrPrvActionInfoSelDispProc         As String = "prvActionInfoSelDisp_Proc"     'ｲﾍﾞﾝﾄ名定数(権限ﾁｪｯｸ)
    Private Const CMstrPrvNextStepSel                   As String = "prvNextStep_Sel"               'ｲﾍﾞﾝﾄ名定数(次工程取得)
    Private Const CMstrPrvVsfBatListDisp                As String = "prvVsfBatList_Disp"            'ｲﾍﾞﾝﾄ名定数(ﾊﾞｯﾁ組情報一覧表示)
    Private Const CMstrPrvEasyCombCheck                 As String = "prvEasyComb_Chk"               'ｲﾍﾞﾝﾄ名定数(簡易統合ﾁｪｯｸ)
	Private Const CMstrPrvblnDivideGroup                As String = "prvblnDivideGroup"             'ｲﾍﾞﾝﾄ名定数(グループ別自動分割)

    '@↓2016/03/22 (Tue) 17:14:44 T.Oide **************************************************
    Private Const CMstrSpecCheckOK                      As String = "0"                             '正常
    Private Const CMstrSpecCheckSPCNG                   As String = "1"                             'SPC異常
    Private Const CMstrSpecCheckSpecNG                  As String = "2"                             '規格値異常
    Private Const CMstrSpecCheckOtherNG                 As String = "3"                             'その他異常
    Private Const CMstrSpecCheckNoRule                  As String = ""                              'Jobなし
    Private Const CMstrSpecCheckSystemErr               As String = "99"                            'SPC判定ｼｽﾃﾑｴﾗｰ
    '@↑2016/03/22 (Tue) 17:14:44 T.Oide **************************************************

	Private Const CMstrReserveGroupA					As String = "A"                            '予約グループA
	Private Const CMstrReserveGroupB					As String = "B"                            '予約グループB
	Private Const CMstrReserveGroupC					As String = "C"                            '予約グループC
	Private Const CMstrReserveGroupD					As String = "D"                            '予約グループD

	'@分割先ﾛｯﾄのWF数(蒸着後流動予約自動分割用)
    Private Const CMstrWFDefault                As String = "0"             'WF枚数ｾﾞﾛ入力時比較用定数
    Private Const CMstrDumCarrierTypeID         As String = "CARRSYS0"      '簡易分割用仮想ｷｬﾘｱのﾀｲﾌﾟ
    Private Const CMstrDumCarrierFirstWords     As String = "I"             'ｼｽﾃﾑ検証用仮想ｷｬﾘｱID1桁目
    Private Const CMstrFormatCarrIdSerial       As String = "00000"         '仮想ｷｬﾘｱIDﾍﾞﾝﾀﾞｰｼﾘｱﾙ
    Private Const CMstrAri                      As String = "あり"          'CARRIER.EMPTY_FLAG
	Private Const CMlngLeftLength               As Integer = 7                 'ﾛｯﾄID比較文字数
	Private Const CMstrResultOK                 As String = "OK"            '結果OK
	Private Const CMstrAuto						As String = "自動ｷｬﾘｱ"			'ｷｬﾘｱ交換後ﾒｯｾｰｼﾞ用

	'@ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝの定数宣言
    Private Const CMlngoptOffline                           As Integer = 0              'ｵﾌﾗｲﾝ


    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mstrCarrier                                 As String                           'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mlngSideScrollFlag                          As Integer                          '横ｽｸﾛｰﾙの使用ﾌﾗｸﾞ(1:発生/2:不要)
    Private mstrWpID                                    As String                           'WPID
    Private mblnTakeOverDispFlg                         As Boolean                          '引継ぎ表示ﾌﾗｸﾞ
    Private mtypLotActList()                            As LotActList                       'ｱｸｼｮﾝ予約ﾘｽﾄ
    Private mlngActCnt                                  As Integer                          'ｱｸｼｮﾝ予約ﾘｽﾄｶｳﾝﾄ
    Private mtypBatLotList                              As BatLotList                       'ﾊﾞｯﾁ組ﾛｯﾄ情報応答構造体
    Private mtypLotNextStep                             As LotNextStep                      '次工程情報応答構造体
    Private mstrResult                                  As String                           '簡易統合許可(0:簡易統合なし 1:簡易統合あり)
	Private mstrDumCarrierID							As String							'仮想ｷｬﾘｱ
	Private mstrLotLastUpdate							As String							'最終更新日時
	Private mstrNowDivideLotId							As String							'最新分割ロットID
	Private mtypDivideLot								As List(Of typDivideLot)			'自動分割ロット情報
	Private mtypCombineLot								As List(Of typCombineLot)			'自動統合ロット情報
	Private mtypCarrierMoveLot							As List(Of typCarrierMoveLot)		'自動キャリア交換ロット情報
	Private mtypAJRLot									As List(Of string)					'蒸着流動予約処理ロット
    Private buttonProcessing                            As Boolean              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean              'NSYS WindowCloseフラグ


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
        'NSYS スクロールバーなしグリッドのマウスホイール対応
        pubVsfMouseWheelManager_Set(vsfBatList, cmdUp, cmdDown, cmdLeft, cmdRight)
        pubVsfMouseWheelManager_Set(vsfNextStepInfo, cmdNextUp, cmdNextDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 09:29:51 S.Deguchi
    '更新日：2009/06/25 (Thu) 13:33:04 N.Kojima
    '備　考：
    '　　　：2009/06/25 (Thu) 13:33:04 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_Load()

        Dim lblnAns         As Boolean      '戻り値

        Try

            '@Escﾎﾞﾀﾝを無効にする(ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない)
            Me.CancelButton = Nothing

            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00K0, CMstrLocalVersion)
            
            '@機能ﾊﾞｰｼﾞｮﾝ判定処理結果が"False：失敗"か
            If lblnAns = False Then

                '@Escﾎﾞﾀﾝを有効にし、処理終了
                Me.CancelButton = cmdClose
                Exit Sub
            End If


            '@=======================
            '@ 画面情報初期化処理
            '@=======================
            Call prvFrmxxEN00K0_Init()


            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：起動処理成功"をｾｯﾄ
            pblnFormLoad = True

            '@引継ぎ情報表示済みﾌﾗｸﾞの初期化
            mblnTakeOverDispFlg = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
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
    '作成日：2004/07/27 (Tue) 18:23:41 H.Wajima
    '更新日：2009/06/25 (Thu) 13:55:26 N.Kojima
    '備　考：
    '　　　：2009/06/25 (Thu) 13:55:26 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@引継ぎ情報が表示済み(True)か
            '@ ※FormLoad後、最初の1回しか処理しない
            If mblnTakeOverDispFlg = True Then

                '@表示済みの場合、Escﾎﾞﾀﾝを有効にし、処理終了
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@Escﾎﾞﾀﾝを有効にする
            Me.CancelButton = cmdClose
            
            '@引継ぎ情報表示済みﾌﾗｸﾞに"True：表示済"をｾｯﾄ
            mblnTakeOverDispFlg = True

            'NSYS 初期値設定
            'ﾌｫｰﾑの位置を初期化
            Me.Top = 0
            Me.Left = 0 - My.Settings.FormOffset

            Me.Refresh()

            '@引数のｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@NULL以外でない場合
                
                '@ｷｬﾘｱIDに引継ぎｷｬﾘｱをｾｯﾄ
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                
                '@=======================
                '@ ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                '@=======================
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
                .strMenuKey = CMstrLocalMenuKey
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
    '機　能：ﾌｫｰﾑ　ｷｰ押下時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 18:10:09 S.Deguchi
    '更新日：2009/06/26 (Fri) 09:53:06 N.Kojima
    '備　考：
    '　　　：2007/07/05 (Thu) 13:58:36 N.Kasai      ｸﾞﾘｯﾄﾞ機能共通化
    '　　　：2009/06/26 (Fri) 09:53:06 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@以下の条件の場合、ｷｰｺｰﾄﾞを無効にし処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                
                e.Handled = True
                Exit Sub
            End If

          
            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、上(▲)ﾎﾞﾀﾝ、下(▼)ﾎﾞﾀﾝ)
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfBatList, cmdUP, cmdDown)
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左(<<)ﾎﾞﾀﾝ、右(>>)ﾎﾞﾀﾝ)
            '@=======================
            Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfBatList, cmdLeft, cmdRight)


            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
                
                '@〓 ｷｬﾘｱID 〓
                Case txtCarrier.Name
                    
                    '@Enterｷｰか
                    If e.KeyCode = Keys.Return Then
                        
                        '@=======================
                        '@ ｷｬﾘｱIDﾃｷｽﾄValidate処理
                        '@=======================
                        RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                        Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                        AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                        
                        Exit Sub
                    End If
                
                '@〓 作業ﾒﾓ 〓
                Case txtWorkMemo.Name

                    Exit Sub
                
                '@〓 その他 〓
                Case Else
                    
                    '@Enterｷｰか
                    If e.KeyCode = Keys.Return Then
                    
                        '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽをｾｯﾄし、ｷｰｺｰﾄﾞを無効にする
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                    End If

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_KeyDown"
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
    '作成日：2004/07/20 (Mon) 17:32:13 S.Deguchi
    '更新日：2009/06/26 (Fri) 09:57:41 N.Kojima
    '備　考：
    '　　　：2004/11/01 (Mon) 16:00:35 S.Deguchi    閉じるﾎﾞﾀﾝ統合
    '　　　：2009/06/26 (Fri) 09:57:41 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@"×"ﾎﾞﾀﾝにて閉じたか
            If mblnCloseFromControlMenu Then
            
                '@=======================
                '@ 閉じるﾎﾞﾀﾝ押下処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@構造体の解放
            ptypLotAction.lnglstCnt = 0                             '画面間引継ぎｱｸｼｮﾝ予約情報ｶｳﾝﾀ
            If Not IsNothing(ptypLotAction.typLotActList) Then
                ptypLotAction.typLotActList.Clear()                 '画面間引継ぎｱｸｼｮﾝ予約情報格納用構造体
            End If
            ptypExcpConnectList.typLotList.lngBatLotListCnt = 0     '画面間引継ぎ異常処理票情報ｶｳﾝﾀ
            If Not IsNothing(ptypExcpConnectList.typLotList.typBatList) Then
                ptypExcpConnectList.typLotList.typBatList.Clear()   '画面間引継ぎ異常処理票情報格納用構造体
            End If
            mtypLotNextStep.lngNextStepListCnt = 0                  'ﾛｯﾄ次工程情報ﾘｽﾄｶｳﾝﾀ
            If Not IsNothing(mtypLotNextStep.strNextStepList) Then
                mtypLotNextStep.strNextStepList.Clear()             'ﾛｯﾄ次工程情報ﾘｽﾄ
            End If
            
            '@ActInitﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                
                '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                lblnAnsTerm = pubblnAct_Term
                
                '@結果判定
                If lblnAnsTerm = True Then
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@=======================
                '@ ﾒﾆｭｰ伸縮処理
                '@=======================
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
    '作成日：2004/07/20 (Mon) 17:32:27 S.Deguchi
    '更新日：2009/06/26 (Fri) 09:59:30 N.Kojima
    '備　考：
    '　　　：2005/03/07 (Mon) 10:23:07 N.Kojima     戻り先画面の判定を追加(改善№512)
    '　　　：2009/06/26 (Fri) 09:59:30 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo  As CommonInfo           '戻り構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@引継ぎ情報のｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@NULL以外の場合
                
                '@装置別ﾛｯﾄ一覧から引き継いで起動されたか
                If pblnfrmxxEN0150Kbn = True Then
                    
                    '@=======================
                    '@ 装置別ﾛｯﾄ一覧を起動する
                    '@=======================
                    Call pubMenuSelect_Proc(CPstrKeyEN0150)
                Else
                    '@装置別ﾛｯﾄ一覧以外からの引継ぎ起動
                
                    '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧から引き継いで起動されたか
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
                '@ 終了関数を実行する
                '@=======================
                Call publngEnd_Proc(CPstrKeyEN00K0, ltypCommonInfo)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
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
    '作成日：2004/07/20 (Tue) 17:34:03 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:01:41 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:01:41 N.Kojima     無機対応。(案件№03560)
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try

            '@=======================
            '@ 画面情報初期化処理
            '@=======================
            Call prvFrmxxEN00K0_Init()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
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
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　選択確定時処理(Validate処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 17:34:59 S.Deguchi
    '更新日：2009/06/25 (Thu) 13:58:45 N.Kojima
    '備　考：
    '　　　：2004/08/27 (Fri) 11:04:35 S.Deguchi    異常処理ﾎﾞﾀﾝ活性化処理追加
    '　　　：2004/08/27 (Fri) 16:28:43 M.Miura      次工程自動送出ｺﾝﾎﾞをｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝに変更
    '　　　：2006/03/28 (Tue) 10:28:48 N.Kojima     引継ぎﾊﾞｸﾞ改修の為、時間制限の格納構造体を変更。(不具合№3444関連)
    '　　　：2009/06/25 (Thu) 13:58:45 N.Kojima     無機対応。(案件№03560)
    Private Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim ltypBatRequestList      As BatRequestList       'ﾊﾞｯﾁ組ﾛｯﾄ情報要求構造体
        Dim lblnAns                 As Boolean              '結果格納
        Dim llngMsgAns              As Integer              '簡易統合可否判断
        Dim lblnNextCtrl            As Boolean              'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@-----------------------
            '@ ｷｬﾘｱﾁｪｯｸ
            '@-----------------------
            '@ｷｬﾘｱIDがNULLか
            If Trim(txtCarrier.Text) = vbNullString Then
                '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtCarrier.Name Then
                    Call pubSetFocus(cmdClose)
                End If
                Exit Sub
            End If

            If ActiveControl.Name = txtCarrier.Name OrElse _
                ActiveControl.Name = vsfBatList.Name Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If
            
            '@ｷｬﾘｱIDが6桁以上か
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM07W>$$キャリアIDは6桁で入力してください。"」のﾒｯｾｰｼﾞを表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDへﾌｫｰｶｽを留める
                e.Cancel = True
                Exit Sub
            End If


            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If Trim(txtCarrier.Text) <> vbNullString And _
                txtCarrier.Text <> mstrCarrier Then
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrTxtCarrierValidate)
                
                '@=======================
                '@ 画面情報初期化処理
                '@=======================
                Call prvFrmxxEN00K0_Init()
                
                '@ﾊﾞｯﾁ組ﾛｯﾄ情報取得要求構造体に値を設定
                With ltypBatRequestList
                    
                    .strClassDivision = CPstrCD13               '処理区分(13:作業終了)
                    .strCarrierId = txtCarrier.Text             'ｷｬﾘｱID
                    .strMcGroupID = vbNullString                '装置ｸﾞﾙｰﾌﾟID
                    .strWpID = vbNullString                     'WP_ID
                    .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                    .strMsgVer = CMstrbat_lotlist_Ver           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                End With
                
                '@=======================
                '@ ﾊﾞｯﾁ組ﾛｯﾄ情報取得
                '@=======================
                lblnAns = pubblnBatLotList_Sel(ltypBatRequestList, mtypBatLotList)
                
                '@ﾊﾞｯﾁ組ﾛｯﾄ情報取得結果が"True：通信成功"か
                If lblnAns = True Then
                    '@True：成功の場合

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrTxtCarrierValidate)

                    '@=======================
                    '@ ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ表示処理
                    '@=======================
                    Call prvVsfBatList_Disp()
                    
                    '@=======================
                    '@ 簡易統合のﾁｪｯｸ処理
                    '@=======================
                    Call prvEasyComb_Chk()


        '@↓2009/06/30 (Tue) 21:05:20 N.Kojima **************************************************
        '            '@ﾊﾞｯﾁ組情報一覧のｷｬﾘｱID/ﾛｯﾄID/種別/大工程/小工程を変数に退避
        '            With vsfBatList
        '
        '                For llngCnt = 1 To .Rows - 1
        '
        '                    '@入力されたｷｬﾘｱIDと同じか
        '                    If txtCarrier.Text = .Cell(flexcpText, llngCnt, CMlngvsfColCarrierID) Then
        '                        '@同じ場合
        '
        '                        lstrCarrierID = .Cell(flexcpText, llngCnt, CMlngvsfColCarrierID)        'ｷｬﾘｱID
        '                        lstrLotID = .Cell(flexcpText, llngCnt, CMlngvsfColLotID)                'ﾛｯﾄID
        '                        lstrFlowClass = .Cell(flexcpText, llngCnt, CMlngvsfColFlowClass)        '種別
        '                        lstrOpID = .Cell(flexcpText, llngCnt, CMlngvsfColOpID)                  '大工程
        '                        lstrStepID = .Cell(flexcpText, llngCnt, CMlngvsfColStepID)              '小工程
        '
        '                        Exit For
        '                    End If
        '                Next llngCnt
        '            End With
        '
        '            '@=======================
        '            '@ 次工程情報取得＆表示処理
        '            '@=======================
        '            Call prvNextStep_Sel(lstrCarrierID, _
        '                                    lstrLotID, _
        '                                    lstrFlowClass, _
        '                                    lstrOpID, _
        '                                    lstrStepID)
                    '@=======================
                    '@ 次工程情報取得＆表示処理
                    '@=======================
                    Call prvNextStep_Sel()
                    
        '@↑2009/06/30 (Tue) 21:05:20 N.Kojima **************************************************

                    
                    '@=======================
                    '@ 画面情報表示処理
                    '@=======================
                    Call prvFrmxxEN00K0_Disp()

                    '@=======================
                    '@ ｱｸｼｮﾝ予約情報取得＆ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面表示処理
                    '@=======================
                    Call prvActionInfoSelDisp_Proc()
                    
                    '@ｱｸｼｮﾝ予約ﾌﾗｸﾞがNULL以外か
                    If vsfBatList.GetData(vsfBatList.Row, CMlngvsfColActionFlag) <> vbNullString Then
                        
                        '@ｱｸｼｮﾝ予約確認ﾎﾞﾀﾝを有効にする
                        cmdActionDisp.Enabled = True
                    Else
                        '@ｱｸｼｮﾝ予約確認ﾎﾞﾀﾝを無効にする
                        cmdActionDisp.Enabled = False
                    End If


                    '@=======================
                    '@ 確定ﾎﾞﾀﾝ制御ﾁｪｯｸ処理
                    '@=======================
                    lblnAns = prvblncmdRegist_Chk()
                    
                    '@ﾁｪｯｸ処理結果が"True：ﾁｪｯｸOK"か
                    If lblnAns = True Then

                        '@確定ﾎﾞﾀﾝを有効にする
                        cmdRegist.Enabled = True
                    Else
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    End If
                    
                    '@異常処理票起案ﾎﾞﾀﾝを有効にする
                    cmdTrouble.Enabled = True
                
                    '@作業ﾒﾓを有効にする
                    txtWorkMemo.Enabled = True


                    '@簡易統合ﾁｪｯｸ処理結果が"1：統合不可"か
                    If mstrResult = CPstrOne Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM104W>$$分割ロットが存在します。$ロット分割状態のまま送出しますか？"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0104)
                        llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                        
                        '@ﾒｯｾｰｼﾞBOXにて「はい」が選択されたか
                        If llngMsgAns = vbYes Then
                            '@「はい」が選択された場合
                            
                            '@各種ｵﾌﾟｼｮﾝﾎﾞﾀﾝを有効にする
                            optLotNextSend0.Enabled = True     '「送出あり」
                            optLotNextSend1.Enabled = True     '「送出なし」
                            
                            '@「送出あり」をﾃﾞﾌｫﾙﾄで選択する
                            optLotNextSend0.Checked = True
                        Else
                            '@「いいえ」が選択された場合

                            '@統合するため「次工程送出」にする
                            optLotNextSend0.Enabled = False
                            optLotNextSend1.Enabled = True
                            
                            optLotNextSend1.Checked = True

                        End If
                    Else
                        '@各種ｵﾌﾟｼｮﾝﾎﾞﾀﾝを有効にする
                        optLotNextSend0.Enabled = True     '「送出あり」
                        optLotNextSend1.Enabled = True     '「送出なし」
                        
                        '@「送出あり」をﾃﾞﾌｫﾙﾄで選択する
                        optLotNextSend0.Checked = True
                    
                    End If

                Else
                    '@False：通信失敗の場合
                
                    '@ｷｬﾘｱIDにﾌｫｰｶｽを留める
                    e.Cancel = True
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                    
                    Exit Sub
                End If
                    
                '@ｷｬﾘｱIDを退避する
                mstrCarrier = txtCarrier.Text
                
                '@ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞが有効か
                If vsfBatList.Enabled = True Then
                
                    '@ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(vsfBatList)
                    End If
                Else
                    '@ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞが無効の場合
                
                    '@ｷｬﾘｱIDにﾌｫｰｶｽを留める
                    e.Cancel = True
                End If

            Else
                '@ｷｬﾘｱIDがNULL、または前回入力ｷｬﾘｱと同じ場合
            
                '@ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞが有効か
                If vsfBatList.Enabled = True Then
                
                    '@ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(vsfBatList)
                    End If
                Else
                    '@ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞが無効の場合
                
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_Change
    '機　能：作業ﾒﾓﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 17:52:58 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:16:13 N.Kojima
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi        ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2009/06/26 (Fri) 10:16:13 N.Kojima     無機対応。(案件№03560)
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change

        Dim llngNowByte     As Integer  'ﾊﾞｲﾄ数

        Try
            
            '@現在のﾊﾞｲﾄ数を格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@=======================
            '@ 現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            '@=======================
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                          llngNowByte, _
                                                          CPlngLotCommentsMaxByte)

            '@=======================
            '@ ﾃｷｽﾄ変更処理((ｺﾒﾝﾄ系)ﾃｷｽﾄﾎﾞｯｸｽ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispRowW, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_KeyUp
    '機　能：作業ﾒﾓﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/12/01 (Thu) 13:10:57 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:18:09 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:18:09 N.Kojima     無機対応。(案件№03560)
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try

            '@=======================
            '@ ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作時処理((ｺﾒﾝﾄ系)ﾃｷｽﾄﾎﾞｯｸｽ共通仕様)
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispRowW, cmdMemoUp, cmdMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：作業ﾒﾓﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2005/12/01 (Thu) 13:11:47 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:19:23 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:19:23 N.Kojima     無機対応。(案件№03560)
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try

            '@=======================
            '@ ﾃｷｽﾄ変更処理((ｺﾒﾝﾄ系)ﾃｷｽﾄﾎﾞｯｸｽ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispRowW, cmdMemoUp, cmdMemoDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoUp_Click
    '機　能：作業ﾒﾓ用上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/13 (Tue) 17:54:36 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:20:54 N.Kojima
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2009/06/26 (Fri) 10:20:54 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@ ﾃｷｽﾄﾎﾞｯｸｽ用上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通仕様)
            '@=======================
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispRowW, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMemoUp_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoDown_Click
    '機　能：作業ﾒﾓ用下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/13 (Tue) 17:54:39 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:22:14 N.Kojima
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2009/06/26 (Fri) 10:22:14 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@ ﾃｷｽﾄﾎﾞｯｸｽ用下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通仕様)
            '@=======================
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispRowW, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMemoDown_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotCommnt_Change
    '機　能：ｺﾒﾝﾄﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:26:29 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:23:24 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:23:24 N.Kojima     無機対応。(案件№03560)
    Private Sub txtLotCommnt_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotCommnt.Change

        Try

            '@=======================
            '@ ﾃｷｽﾄ変更処理((ｺﾒﾝﾄ系)ﾃｷｽﾄﾎﾞｯｸｽ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtLotCommnt, CMlngMaxDispRowC, cmdTxtUp, cmdTxtDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotCommnt_KeyUp
    '機　能：ｺﾒﾝﾝﾄﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:27:19 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:25:02 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:25:02 N.Kojima     無機対応。(案件№03560)
    Private Sub txtLotCommnt_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLotCommnt.KeyUp

        Try

            '@=======================
            '@ ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作時処理((ｺﾒﾝﾄ系)ﾃｷｽﾄﾎﾞｯｸｽ共通仕様)
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtLotCommnt, CMlngMaxDispRowC, cmdTxtUp, cmdTxtDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotCommnt_MouseUp
    '機　能：ｺﾒﾝﾄﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:19:54 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:25:34 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:25:34 N.Kojima     無機対応。(案件№03560)
    Private Sub txtLotCommnt_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtLotCommnt.MouseUp

        Try

            '@=======================
            '@ ﾃｷｽﾄ変更処理((ｺﾒﾝﾄ系)ﾃｷｽﾄﾎﾞｯｸｽ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtLotCommnt, CMlngMaxDispRowC, cmdTxtUp, cmdTxtDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtUp_Click
    '機　能：ｺﾒﾝﾄ用上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/13 (Tue) 17:55:58 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:26:44 N.Kojima
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2009/06/26 (Fri) 10:26:44 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdTxtUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@ ﾃｷｽﾄﾎﾞｯｸｽ用上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通仕様)
            '@=======================
            Call pubtxtCmdUp_Proc(txtLotCommnt, CMlngMaxDispRowC, cmdTxtUp, cmdTxtDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTxtUp_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtDown_Click
    '機　能：ｺﾒﾝﾄ用下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/13 (Tue) 17:56:02 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:27:36 N.Kojima
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2009/06/26 (Fri) 10:27:36 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdTxtDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@ ﾃｷｽﾄﾎﾞｯｸｽ用下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通仕様)
            '@=======================
            Call pubtxtCmdDown_Proc(txtLotCommnt, CMlngMaxDispRowC, cmdTxtUp, cmdTxtDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTxtDown_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfBatList_AfterUserResize
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ　ﾕｰｻﾞｰ列幅変更後処理
    '引　数：Row    ：行番号
    '　　　：Col    ：列番号
    '戻り値：なし
    '作成日：2004/09/06 (Mon) 14:45:42 N.Kasai
    '更新日：2009/06/26 (Fri) 10:30:04 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:30:04 N.Kojima     無機対応。(案件№03560)
    Private Sub vsfBatList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfBatList.AfterResizeColumn, vsfBatList.AfterResizeRow

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfBatList.Rows.Count <= vsfBatList.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@ 左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
            '@=======================
            Call pubCmdLREnable_Set(vsfBatList, cmdLeft, cmdRight)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfBatList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfBatList_BeforeRowColChange
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ　行列変更前処理
    '引　数：OldRow ：変更前の行番号
    '　　　：OldCol ：変更前の列番号
    '　　　：NewRow ：変更後の行番号
    '　　　：NewCol ：変更後の列番号
    '　　　：Cancel ：ｶﾚﾝﾄｾﾙの変更を禁止するかどうか
    '戻り値：なし
    '作成日：2004/07/23 (Fri) 15:36:48 S.Deguchi
    '更新日：2009/07/22 (Wed) 13:51:57 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:30:04 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/22 (Wed) 13:51:57 N.Kojima     無機対応Phase2、次工程情報書き換え処理を行うかの判定からｷｬﾘｱIDを削除。(案件№03661)
    Private Sub vsfBatList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfBatList.BeforeRowColChange
        
        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ
        Dim OldRow          As Integer
        Dim NewRow          As Integer

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfBatList.Rows.Count <= vsfBatList.Rows.Fixed Then
                Return
            End If
            
            With vsfBatList

                OldRow = e.OldRange.r1
                NewRow = e.NewRange.r1
            
                '@変更前と変更後で行番号が変わっている場合のみ次工程再表示処理を行う
                If OldRow <> NewRow And NewRow > 0 And OldRow >= 0 Then
                    
        '@↓2009/06/30 (Tue) 21:08:29 N.Kojima **************************************************

                    '@ﾛｯﾄIDがNULL以外か(ﾀﾞﾐｰ冶具、未使用処理部は次工程情報取得を行わない)
                    '@かつ、旧選択行のﾛｯﾄIDと新選択行のﾛｯﾄIDが異なるか
                    If .GetData(NewRow, CMlngvsfColLotID) <> vbNullString And _
                        .GetData(OldRow, CMlngvsfColLotID) <> _
                        .GetData(NewRow, CMlngvsfColLotID) Then
                        
        '                '@=======================
        '                '@ 次工程情報取得＆表示処理
        '                '@=======================
        '                Call prvNextStep_Sel(.Cell(flexcpText, NewRow, CMlngvsfColCarrierID), _
        '                                     .Cell(flexcpText, NewRow, CMlngvsfColLotID), _
        '                                     .Cell(flexcpText, NewRow, CMlngvsfColFlowClass), _
        '                                     .Cell(flexcpText, NewRow, CMlngvsfColOpID), _
        '                                     .Cell(flexcpText, NewRow, CMlngvsfColStepID), _
        '                                     NewRow)

                        '@次工程情報が1件以上あるか
                        If mtypLotNextStep.lngNextStepListCnt > 0 Then
                        
                            For llngCnt = 0 To mtypLotNextStep.lngNextStepListCnt - 1
                                
                                '@選択ﾛｯﾄIDと次工程情報格納構造体のﾛｯﾄIDが同じか
                                If .GetData(NewRow, CMlngvsfColLotID) = _
                                    mtypLotNextStep.strNextStepList(llngCnt).strLotID Then
                                    '@同じ場合

                                    '@-----------------------
                                    '@ 次工程情報を作成
                                    '@-----------------------
                                    '@次工程が無い場合(次大工程、次小工程、工程ﾌﾗｸﾞがNULL)
                                    If mtypLotNextStep.strNextStepList(llngCnt).strNextOpId = vbNullString And _
                                        mtypLotNextStep.strNextStepList(llngCnt).strNextStepId = vbNullString And _
                                        mtypLotNextStep.strNextStepList(llngCnt).strStepDivision = vbNullString Then
                            
                                        '@=======================
                                        '@ 次工程情報ｸﾞﾘｯﾄﾞ初期化処理
                                        '@=======================
                                        Call prvVsfNextStepInfo_Init()
                            
                                    Else
                                        '@次大工程、次小工程、工程ﾌﾗｸﾞが空白以外の場合
                                        
                                        '@=======================
                                        '@ 次工程情報ｸﾞﾘｯﾄﾞ表示処理
                                        '@=======================
                                        Call prvVsfNextStepInfo_Disp(.GetData(NewRow, CMlngvsfColCarrierID), _
                                                                     .GetData(NewRow, CMlngvsfColLotID), _
                                                                     .GetData(NewRow, CMlngvsfColFlowClass))
                                    End If
                                End If
                            Next llngCnt
                        End If
                    End If

        '@↑2009/06/30 (Tue) 21:08:29 N.Kojima **************************************************

                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfBatList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfBatList_EnterCell
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Wed) 12:04:16 S.Deguchi
    '更新日：2009/06/25 (Thu) 14:25:24 N.Kojima
    '備　考：
    '　　　：2009/06/25 (Thu) 14:25:24 N.Kojima     無機対応。(案件№03560)
    Private Sub vsfBatList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfBatList.EnterCell

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfBatList.Rows.Count <= vsfBatList.Rows.Fixed Then
                Return
            End If

            With vsfBatList

                '@ﾀｲﾄﾙ行以外(ﾃﾞｰﾀ行)が選択されたか
                If .Row > 0 Then
                    
                    '@ﾛｯﾄｺﾒﾝﾄﾀｲﾄﾙに表示するｷｬﾘｱID
                    lblCarrierC.Text = CMstrCarrierIDTitle & .GetData(.Row, CMlngvsfColCarrierID)
                    
                    '@ﾛｯﾄｺﾒﾝﾄを表示
                    txtLotCommnt.Text = .GetData(.Row, CMlngvsfColLotComment)
                    
        '@↓2009/06/26 (Fri) 19:27:27 N.Kojima **************************************************

                    '@ﾛｯﾄIDがNULL以外か
                    If .GetData(.Row, CMlngvsfColLotID) <> vbNullString Then
                        
                        '@各種ﾎﾞﾀﾝを有効にする
                        cmdCommntInput.Enabled = True       'ﾛｯﾄｺﾒﾝﾄ
                        cmdCollectionInfo.Enabled = True    '装置ﾃﾞｰﾀ登録参照
                        cmdTrouble.Enabled = True           '異常処理票起案
                        cmdTreatWF.Enabled = True           'WF処置登録
                    Else
                        '@NULLの場合(ﾀﾞﾐｰ冶具or未使用処理部)
                        
                        '@各種ﾎﾞﾀﾝを無効にする
                        cmdCommntInput.Enabled = False      'ﾛｯﾄｺﾒﾝﾄ
                        cmdCollectionInfo.Enabled = False   '装置ﾃﾞｰﾀ登録参照
                        cmdTrouble.Enabled = False          '異常処理票起案
                        cmdTreatWF.Enabled = False          'WF処置登録
                    End If

        '@↑2009/06/26 (Fri) 19:27:27 N.Kojima **************************************************
                    
                    '@ｱｸｼｮﾝ予約があるか
                    If .GetData(.Row, CMlngvsfColActionFlag) = CMstrFlagOK Then
                        
                        '@ｱｸｼｮﾝ予約確認ﾎﾞﾀﾝを有効にする
                        cmdActionDisp.Enabled = True
                    Else
                        '@ｱｸｼｮﾝ予約確認ﾎﾞﾀﾝを無効にする
                        cmdActionDisp.Enabled = False
                    End If
                Else
                    '@ﾃﾞｰﾀ行以外の場合
                
                    '@各種ﾎﾞﾀﾝを無効にする
                    cmdTxtUp.Enabled = False                'ﾛｯﾄｺﾒﾝﾄ用▲(上)ｽｸﾛｰﾙ
                    cmdTxtDown.Enabled = False              'ﾛｯﾄｺﾒﾝﾄ用▼(下)ｽｸﾛｰﾙ
                    cmdCommntInput.Enabled = False          'ﾛｯﾄｺﾒﾝﾄ
                    cmdCollectionInfo.Enabled = False       '装置ﾃﾞｰﾀ登録参照
                    cmdTrouble.Enabled = False              '異常処理票起案
                    cmdTreatWF.Enabled = False              'WF処置登録
                    cmdActionDisp.Enabled = False           'ｱｸｼｮﾝ予約確認
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfBatList_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUP_Click
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ用上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 17:58:23 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:31:51 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:31:51 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ ｸﾞﾘｯﾄﾞ上(▲)ｽｸﾛｰﾙ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdUp(vsfBatList, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ用下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 17:58:26 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:33:04 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:33:04 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ ｸﾞﾘｯﾄﾞ下(▼)ｽｸﾛｰﾙ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdDown(vsfBatList, cmdUP, cmdDown, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLeft_Click
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ用左(<<)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 18:01:00 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:33:33 N.Kojima
    '備　考：
    '　　　：2007/07/05 (Thu) 13:57:16 N.Kasai      ｸﾞﾘｯﾄﾞ機能共通化
    '　　　：2009/06/26 (Fri) 10:33:33 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ ｸﾞﾘｯﾄﾞ左(<<)ｽｸﾛｰﾙ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdLeft(vsfBatList, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLeft_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRight_Click
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ用右(>>)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 18:01:02 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:34:36 N.Kojima
    '備　考：
    '　　　：2007/07/05 (Thu) 13:56:29 N.Kasai      ｸﾞﾘｯﾄﾞ機能共通化
    '　　　：2009/06/26 (Fri) 10:34:36 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ ｸﾞﾘｯﾄﾞ右(>>)ｽｸﾛｰﾙ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdRight(vsfBatList, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRight_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNextUP_Click
    '機　能：次工程情報ｸﾞﾘｯﾄﾞ用上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 16:14:12 S.Deguchi
    '更新日：2004/07/20 (Tue) 16:14:12
    '備　考：
    Private Sub cmdNextUP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNextUP.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ ｸﾞﾘｯﾄﾞ上(▲)ｽｸﾛｰﾙ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdUp(vsfNextStepInfo, cmdNextUP, cmdNextDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNextUP_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNextDown_Click
    '機　能：次工程情報ｸﾞﾘｯﾄﾞ用下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 16:14:15 S.Deguchi
    '更新日：2004/07/20 (Tue) 16:14:15
    '備　考：
    Private Sub cmdNextDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNextDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ ｸﾞﾘｯﾄﾞ下(▼)ｽｸﾛｰﾙ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdDown(vsfNextStepInfo, cmdNextUP, cmdNextDown, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNextDown_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdActionDisp_Click
    '機　能：ｱｸｼｮﾝ予約確認ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Wed) 17:29:11 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:35:01 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:35:01 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdActionDisp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdActionDisp.Click

        Dim lblnAns                 As Boolean              '結果判定
        Dim llngActCnt              As Integer              'ｶｳﾝﾄ
        Dim lstrLotID               As String               'ﾛｯﾄID
        Dim lstrFlowClass           As String               '流動区分
        Dim lstrOpID                As String               '大工程
        Dim lstrStepID              As String               '小工程
        Dim lstrPdID                As String               '機種ID
        Dim lstrMasPDVersion        As String               '工順
        Dim lstrWpId                As String               '装置ID

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

            With vsfBatList

                '@ﾀｲﾄﾙ以外、かつﾛｯﾄIDがNULL以外か
                If .Row > 0 AndAlso .GetData(.Row, CMlngvsfColLotID) <> vbNullString Then
                    
                    '@***********************
                    '@ 送信情報作成
                    '@***********************
                    lstrLotID = .GetData(.Row, CMlngvsfColLotID)               'ﾛｯﾄID
                    lstrFlowClass = .GetData(.Row, CMlngvsfColFlowClass)       '流動区分
                    lstrOpID = .GetData(.Row, CMlngvsfColOpID)                 '大工程
                    lstrStepID = .GetData(.Row, CMlngvsfColStepID)             '小工程
                    lstrPdID = .GetData(.Row, CMlngvsfColPDID)                 '機種
                    lstrMasPDVersion = vbNullString                            '工順
                    lstrWpId = mstrWpID                                        '装置ID
                    
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrCmdActionDispClick)
                        
                    '@ｱｸｼｮﾝ予約ﾘｽﾄ取得
                    ptypLotAction.lnglstCnt = 0
                    If IsNothing(ptypLotAction.typLotActList) Then
                        ptypLotAction.typLotActList = New List(Of LotActList)()
                    Else
                        ptypLotAction.typLotActList.Clear()
                    End If

                    '@=======================
                    '@ ｱｸｼｮﾝ予約ﾘｽﾄ取得
                    '@=======================
                    lblnAns = pubblnLotActList_Sel(CMstrlot_actlist_Ver, _
                                                   lstrLotID, _
                                                   lstrOpID, _
                                                   lstrStepID, _
                                                   lstrPdID, _
                                                   lstrMasPDVersion, _
                                                   lstrWpId, _
                                                   ptypLotAction)
                        
                    '@ｱｸｼｮﾝ予約ﾘｽﾄ取得結果が"True：通信成功"か
                    If lblnAns = True Then

                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdActionDispClick)

                        '@ｱｸｼｮﾝ予約ﾘｽﾄにﾃﾞｰﾀが1件以上あるか
                        If ptypLotAction.lnglstCnt > 0 Then
                            
                            With ptypLotAction
                                
                                '@ｱｸｼｮﾝ予約がなくなるまで
                                For llngActCnt = 0 To .lnglstCnt - 1
                                    Dim tmpLotActList As LotActList = .typLotActList(llngActCnt)
                                    
                                    tmpLotActList.strLotID = lstrLotID                    'ﾛｯﾄID
                                    tmpLotActList.strFlowClass = lstrFlowClass            '流動区分
                                    tmpLotActList.strActionTrigger = CMstrEN00K0Title     'ｱｸｼｮﾝﾄﾘｶﾞｰ
                                    tmpLotActList.strOpID = lstrOpID                      '大工程
                                    tmpLotActList.strStepID = lstrStepID                  '小工程
                                    
                                    '@★ ｱｸｼｮﾝ予約ﾀｲﾌﾟにより処理分岐 ★
                                    Select Case .typLotActList(llngActCnt).strLotActionTypeID
                                        
                                        '@〓 ﾛｯﾄ 〓
                                        Case CPstrLotActionTypeID0
                                            
                                            tmpLotActList.strLotActionTypeName = CPstrActTypeLOT       'ｱｸｼｮﾝﾀｲﾌﾟ：ﾛｯﾄ
                                            
                                        '@〓 機種 〓
                                        Case CPstrLotActionTypeID1
                                            
                                            tmpLotActList.strLotActionTypeName = CPstrActTypePD        'ｱｸｼｮﾝﾀｲﾌﾟ：機種
                                            
                                        '@〓 装置 〓
                                        Case CPstrLotActionTypeID2
                                            
                                            tmpLotActList.strLotActionTypeName = CPstrActTypeWP        'ｱｸｼｮﾝﾀｲﾌﾟ：装置
                                            
                                        '@〓 特定工程 〓
                                        Case CPstrLotActionTypeID3
                                            
                                            tmpLotActList.strLotActionTypeName = CPstrActTypeTStep     'ｱｸｼｮﾝﾀｲﾌﾟ：特定工程
                                    
                                    End Select
                                    .typLotActList(llngActCnt) = tmpLotActList
                                Next llngActCnt
                            End With
                            
                            '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面で確定していないか
                            If pblnSubDecision = False Then
                                
                                '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面名称設定
                                frmxxCM0040.Instance.Text = CPstrSubDispTitleActionMsg
                                
                                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                                '@ ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面　表示処理(ptypLotActionの情報でｱｸｼｮﾝ予約の内容を表示)
                                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                                frmxxCM0040.Instance.ShowDialog(Me)
                                frmxxCM0040.Instance = Nothing
                            
                            Else
                                '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面で確定している場合
                            
                                '@確定ﾌﾗｸﾞの初期化
                                pblnSubDecision = False
                            End If
                        End If
                    Else
                        '@ｱｸｼｮﾝ予約ﾘｽﾄ取得結果が"False：通信失敗"か
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdActionDispClick)
                    End If
                End If
            End With

            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
            SendKeys.SendWait(CPstrSendKeysTab)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdActionDisp_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommntInput_Click
    '機　能：ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 18:20:25 S.Deguchi
    '更新日：2008/06/16 (Mon) 15:28:31 N.Kojima
    '備　考：
    '　　　：2005/10/26 (Wed) 08:46:12 S.Deguchi    不具合№2404の対応で,画面引継処理を修正
    '　　　：2006/03/28 (Tue) 10:51:00 N.Kojima     引継ぎﾊﾞｸﾞ改修の為、時間制限の格納構造体を変更。(不具合№3444関連)
    '　　　：2006/06/08 (Thu) 09:38:19 M.Miura      子画面戻りで最新取得と情報復元処理の共通化(不具合№3435)
    '　　　：2008/06/16 (Mon) 15:28:31 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/06/26 (Fri) 10:43:50 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdCommntInput_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommntInput.Click

        Dim lstrTitle           As String       'ﾀｲﾄﾙ
        Dim lstrLotLastUpdate   As String       '最終更新日時判定用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2009/06/29 (Mon) 09:40:27 N.Kojima **************************************************

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾛｯﾄIDがNULLの場合
            If Cursor.Current = Cursors.WaitCursor Or _
                vsfBatList.GetData(vsfBatList.Row, CMlngvsfColLotID) = vbNullString Then

                Exit Sub
            End If

        '@↑2009/06/29 (Mon) 09:40:27 N.Kojima **************************************************

            '@***********************
            '@ 引継ぎﾃﾞｰﾀを格納
            '@ ※ptypLotprestateに格納してfrmxxCM0030を呼ぶ
            '@***********************
            With ptypLotprestate
                
                .strLotID = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColLotID)                      'ﾛｯﾄID
                .strFlowClass = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColFlowClass)              '流動区分
                .strWfNum = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColWFQuantity)                 'WF枚数
                .strOpID = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColOpID)                        '大工程
                .strStartTime = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColStartDayTime)           '処理開始日時
                .strPdId = Mid(vsfBatList.GetData(vsfBatList.Row, CMlngvsfColPDID), _
                               CMlngStartPDID, _
                               CMlngLengthPDID)                                                       '機種
                .strSpecialFlg = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColS)                     '特殊特性
                .strNowST = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColStatus)                     'Lot状態
                .strStepID = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColStepID)                    '小工程
                .strEngEmpName = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColLotManager)            'ﾛｯﾄ担当
                .strLimitTime = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColRealTimeLimit)          '時間制限(実数)
                .strRestrictTypeID = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColRestrictTypeID)    '制限時間ﾀｲﾌﾟID
                .strComments = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColLotComment)              'ﾛｯﾄｺﾒﾝﾄ
                .strLotLastUpdate = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColLastUpdate)         '最終更新日時

                pstrCarrierID = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColCarrierID)              'ｷｬﾘｱID
                
                '@親ﾌｫｰﾑからの呼び出しを識別するために起動識別ﾌﾗｸﾞをTrueにする
                pblnfrmxxCM0030Kbn = True
            
                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                pblnFormLoad = False
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ ﾛｯﾄｺﾒﾝﾄ画面　起動処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0030.Instance = New frmxxCM0030()
                
                '@=======================
                '@ 機能関連情報取得処理
                '@=======================
                Call pubMenuItemCorrelation_Set(CPstrKeyEN0140, lstrTitle)

                '@ﾛｯﾄｺﾒﾝﾄ画面の名称設定
                frmxxCM0030.Instance.Text = lstrTitle
                
                '@ﾌｫｰﾑﾛｰﾄﾞ結果が"True：起動成功"か
                If pblnFormLoad = True Then
                
                    '@最新取得前最終更新日時を退避
                    lstrLotLastUpdate = .strLotLastUpdate
                    
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    '@ ﾛｯﾄｺﾒﾝﾄ画面　表示処理
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    frmxxCM0030.Instance.ShowDialog(Me)
                    frmxxCM0030.Instance = Nothing
                    
                    '@=======================
                    '@ ﾊﾞｯﾁ作業終了画面の最新取得＆復元処理
                    '@ ※引数⇒True：最終更新日時判定あり、最新取得前最終更新日時
                    '@=======================
                    Call prvRefresh_Disp(True, lstrLotLastUpdate)
                    
                    '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝが有効か
                    If cmdCommntInput.Enabled = True Then
                        
                        '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdCommntInput)
                    End If
          
                Else
                    '@ﾌｫｰﾑﾛｰﾄﾞ結果が"False：起動失敗"の場合
                    
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    '@ ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    frmxxCM0030.Instance = Nothing
                
                    '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                    pblnFormLoad = True
                    
                    Exit Sub
                End If
                
                '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommntInput_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCollectionInfo_Click
    '機　能：装置ﾃﾞｰﾀ登録/参照ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/09 (Thu) 18:16:40 N.Kasai
    '更新日：2009/06/28 (Sun) 14:12:54 N.Kojima
    '備　考：
    '　　　：2004/11/04 (Thu) 10:33:18 T.Kitagawa   引継ぎ構造体を共通で使用している為、選択したｷｬﾘｱIDが最終的に引継ぎ構造体にｾｯﾄされてしまう件を修正
    '　　　：2005/02/17 (Thu) 16:15:12 S.Deguchi    上記対応を修正(最新情報を取得し直す)
    '　　　：2005/05/09 (Mon) 18:54:51 N.Kojima     上記修正を更にｺﾒﾝﾄ化。上記対応により装置ﾃﾞｰﾀ画面を閉じた際に、
    '　　　：                                       一覧のﾌｫｰｶｽがｷｬﾘｱIDにｾｯﾄされているｷｬﾘｱIDの行にあたる。(不具合№556)
    '　　　：2006/06/08 (Thu) 09:38:19 M.Miura      子画面戻りで最新取得と情報復元処理の共通化(不具合№3435)
    '　　　：2009/06/28 (Sun) 14:12:54 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdCollectionInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCollectionInfo.Click
        
        Dim lstrTitle           As String       'ﾀｲﾄﾙ
        Dim ltypOldCommonInfo   As CommonInfo   '引継ぎ構造体の退避領域
        Dim lstrLotLastUpdate   As String       '最終更新日時判定用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2009/06/29 (Mon) 09:40:27 N.Kojima **************************************************

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾛｯﾄIDがNULLの場合
            If Cursor.Current = Cursors.WaitCursor Or _
                vsfBatList.GetData(vsfBatList.Row, CMlngvsfColLotID) = vbNullString Then

                Exit Sub
            End If

        '@↑2009/06/29 (Mon) 09:40:27 N.Kojima **************************************************

            '@引継ぎ構造体の退避
            ltypOldCommonInfo = ptypCommonInfo
            
            '@***********************
            '@ 子ﾌｫｰﾑへの引継ぎ情報格納
            '@***********************
            With ptypCommonInfo
                
                .strCarrierId = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColCarrierID)               'ｷｬﾘｱID
                .strLotID = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColLotID)                       'ﾛｯﾄID
                .strOpID = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColOpID)                         '大工程
                .strStepID = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColStepID)                     '小工程
                .strWpID = mstrWpID                                                                    'WPID
                .strWpName = vbNullString
                
                '@最新取得前選択ｷｬﾘｱID取得
                pstrCarrierID = .strCarrierId
                lstrLotLastUpdate = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColLastUpdate)
            End With
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            pblnFormLoad = False
            
            '@親ﾌｫｰﾑからの呼び出しを識別するために起動識別ﾌﾗｸﾞをTrueにする
            pblnfrmxxCM00G0Kbn = True


            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 装置ﾃﾞｰﾀ登録/参照画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00G0.Instance = New frmxxCM00G0()
                
            '@=======================
            '@ 機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00T0, lstrTitle)
            
            '@装置ﾃﾞｰﾀ登録/参照画面の名称設定
            frmxxCM00G0.Instance.Text = lstrTitle
            
            '@ﾌｫｰﾑﾛｰﾄﾞ結果が"False：起動失敗"か
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00G0.Instance = Nothing
                
                '@引継ぎ情報の初期化
                ptypCommonInfo = ltypOldCommonInfo
                pblnfrmxxCM00G0Kbn = False
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 装置ﾃﾞｰﾀ登録/参照画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00G0.Instance.ShowDialog(Me)
            frmxxCM00G0.Instance = Nothing
            
            '@引継ぎ情報の初期化
            ptypCommonInfo = ltypOldCommonInfo
            pblnfrmxxCM00G0Kbn = False
            
            '@=======================
            '@ ﾊﾞｯﾁ作業終了画面の最新取得＆復元処理
            '@ ※引数⇒True：最終更新日時判定あり、最新取得前最終更新日時
            '@=======================
            Call prvRefresh_Disp(True, lstrLotLastUpdate)
            
            '@装置ﾃﾞｰﾀ登録/参照ﾎﾞﾀﾝが有効か
            If cmdCollectionInfo.Enabled = True Then
                
                '@装置ﾃﾞｰﾀ登録/参照ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdCollectionInfo)
            End If

            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
            SendKeys.SendWait(CPstrSendKeysTab)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCollectionInfo_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTrouble_Click
    '機　能：異常処理起案ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 20:07:22 S.Deguchi
    '更新日：2009/06/28 (Sun) 16:42:13 N.Kojima
    '備　考：
    '　　　：2005/03/03 (Thu) 10:06:56 S.Deguchi    引継の情報を保持する処理を追加
    '　　　：2005/05/09 (Mon) 17:41:11 N.Kojima     引継ぎ構造体の変更等の処理追加。(不具合№556対応)
    '　　　：2006/06/08 (Thu) 09:38:19 M.Miura      子画面戻りで最新取得と情報復元処理の共通化(不具合№3435)
    '　　　：2008/06/16 (Mon) 15:29:06 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/06/28 (Sun) 16:42:13 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdTrouble_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTrouble.Click

        Dim llngCnt                 As Integer              'ｶｳﾝﾄ格納
        Dim lstrTitle               As String               'ﾀｲﾄﾙ
        Dim lstrHouseCompLotID      As String               '引継ぎ構造体格納済み確認用ﾛｯﾄID
        Dim ltypExcpConnectList     As ExcpConnectList      '引継構造体初期化用
        Dim ltypOldCommonInfo       As CommonInfo           '引継ぎ構造体の退避領域

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2009/06/29 (Mon) 09:40:27 N.Kojima **************************************************

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾛｯﾄIDがNULLの場合
            If Cursor.Current = Cursors.WaitCursor Or _
                vsfBatList.GetData(vsfBatList.Row, CMlngvsfColLotID) = vbNullString Then

                Exit Sub
            End If

        '@↑2009/06/29 (Mon) 09:40:27 N.Kojima **************************************************
            
            '@引継ぎ構造体の退避
            ltypOldCommonInfo = ptypCommonInfo
            
            '@引継ぎ構造体の初期化(工程異常/不適合品処理登録画面でこの構造体に値が入っているかで判別している為)
            ptypCommonInfo.strLotID = vbNullString

            '@親ﾌｫｰﾑからの呼び出しを識別するために起動識別ﾌﾗｸﾞをTrueにする
            pblnfrmxxCM00I0Kbn = True

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞを初期化
            pblnFormLoad = False

            '@引継ぎ情報格納構造体を初期化する
            ptypExcpConnectList = ltypExcpConnectList

            '@最新取得前選択ｷｬﾘｱID取得
            pstrCarrierID = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColCarrierID)

            '@***********************
            '@ 引継ぎﾃﾞｰﾀを格納
            '@ ※ptypExcpConnectListに格納してfrmxxCM00I0を呼ぶ
            '@***********************
            With ptypExcpConnectList.typLotList
                
                .strBatchId = lblBatID.Text              'ﾊﾞｯﾁID
                .strWpID = vbNullString                  'WPID
                .strWpName = lblWpName.Text              '装置名
                .strRecipeId = lblRecipe.Text            'ﾚｼﾋﾟID

                If IsNothing(.typBatList) Then
                    .typBatList = New List(Of BatList)()
                End If
                
                For llngCnt = 1 To vsfBatList.Rows.Count - 1
                    
                    '@引継ぎ構造体に未格納、かつﾛｯﾄIDがNULL以外か(同じﾛｯﾄは格納しない、ﾀﾞﾐｰ冶具＆未使用処理部は格納しない)
                    If lstrHouseCompLotID <> vsfBatList.GetData(llngCnt, CMlngvsfColLotID) And _
                        vsfBatList.GetData(llngCnt, CMlngvsfColLotID) <> vbNullString Then

                        Dim tmpBatList As BatList = New BatList()
                        .lngBatLotListCnt = .lngBatLotListCnt + 1       'ﾛｯﾄ数
                        
                        tmpBatList.strLotID = vsfBatList.GetData(llngCnt, CMlngvsfColLotID)                      'ﾛｯﾄID
                        tmpBatList.strFlowClass = vsfBatList.GetData(llngCnt, CMlngvsfColFlowClass)              '種別
                        tmpBatList.strWFQuantity = vsfBatList.GetData(llngCnt, CMlngvsfColWFQuantity)            '数量
                        tmpBatList.strOpID = vsfBatList.GetData(llngCnt, CMlngvsfColOpID)                        '大工程
                        tmpBatList.strStepID = vsfBatList.GetData(llngCnt, CMlngvsfColStepID)                    '小工程
                        tmpBatList.strPdId = vsfBatList.GetData(llngCnt, CMlngvsfColPDID)                        '機種
                        tmpBatList.strSpecialFlag = vsfBatList.GetData(llngCnt, CMlngvsfColS)                    '特殊特性
                        tmpBatList.strStartTime = vsfBatList.GetData(llngCnt, CMlngvsfColStartDayTime)           '処理開始日時
                        tmpBatList.strCurrentStatusName = vsfBatList.GetData(llngCnt, CMlngvsfColStatus)         '状態
                        tmpBatList.strEngEmpName = vsfBatList.GetData(llngCnt, CMlngvsfColLotManager)            'ﾛｯﾄ担当
                        tmpBatList.strLimitTime = vsfBatList.GetData(llngCnt, CMlngvsfColTimeLimit)              '時間制約
                        tmpBatList.strLotLastUpdate = vsfBatList.GetData(llngCnt, CMlngvsfColLastUpdate)         '最終更新日時
                        tmpBatList.strCarrierId = vsfBatList.GetData(llngCnt, CMlngvsfColCarrierID)              'ｷｬﾘｱID

                        .typBatList.Add(tmpBatList)
                        
                        '@引継ぎ構造体格納済み確認用ﾛｯﾄID変数にﾛｯﾄIDをｾｯﾄ
                        lstrHouseCompLotID = vsfBatList.GetData(llngCnt, CMlngvsfColLotID)
                    End If
                Next llngCnt
            End With

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 工程異常/不適合品処理票登録画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00I0.Instance = New frmxxCM00I0()
            
            '@=======================
            '@ 機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00U0, lstrTitle)
            
            '@ﾌｫｰﾑﾛｰﾄﾞ結果が"False：起動失敗"か
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00I0.Instance = Nothing
                
                '@退避しておいた引継ぎｷｬﾘｱ情報を戻す
                ptypCommonInfo = ltypOldCommonInfo
                
                '@引継ぎ情報格納構造体の初期化
                ptypExcpConnectList = ltypExcpConnectList
                
                '@起動識別ﾌﾗｸﾞの初期化
                pblnfrmxxCM00I0Kbn = False

                Exit Sub
            End If
            
            '@工程異常/不適合品処理票登録画面の名称設定
            frmxxCM00I0.Instance.Text = lstrTitle
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 工程異常/不適合品処理票登録画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00I0.Instance.ShowDialog(Me)
            frmxxCM00I0.Instance = Nothing
            
            '@退避しておいた引継ぎｷｬﾘｱ情報を戻す
            ptypCommonInfo = ltypOldCommonInfo
            
            '@起動識別ﾌﾗｸﾞの初期化
            pblnfrmxxCM00I0Kbn = False

            '@引継ぎ情報格納構造体の初期化
            ptypExcpConnectList = ltypExcpConnectList

            '@=======================
            '@ ﾊﾞｯﾁ作業終了画面の最新取得＆復元処理
            '@ ※引数⇒なし
            '@=======================
            Call prvRefresh_Disp()
            
            '@異常処理票起案ﾎﾞﾀﾝが有効か
            If cmdTrouble.Enabled = True Then
                
                '@異常処理票起案ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdTrouble)
            End If

            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
            SendKeys.SendWait(CPstrSendKeysTab)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTrouble_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTreatWF_Click
    '機　能：WF処置登録ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 17:04:44 S.Deguchi
    '更新日：2009/06/28 (Sun) 14:18:32 N.Kojima
    '備　考：
    '　　　：2005/05/09 (Mon) 17:01:52 N.Kojima     引継ぎ構造体の変更等の処理追加。(不具合№556対応)
    '　　　：2006/06/08 (Thu) 09:38:19 M.Miura      子画面戻りで最新取得と情報復元処理の共通化(不具合№3435)
    '　　　：2009/06/28 (Sun) 14:18:32 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdTreatWF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTreatWF.Click

        Dim lstrTitle           As String           'ﾀｲﾄﾙ
        Dim ltypOldCommonInfo   As CommonInfo       '引継ぎ構造体の退避領域
        Dim lstrLotLastUpdate   As String           '最終更新日時判定用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2009/06/29 (Mon) 09:40:27 N.Kojima **************************************************

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾛｯﾄIDがNULLの場合
            If Cursor.Current = Cursors.WaitCursor Or _
                vsfBatList.GetData(vsfBatList.Row, CMlngvsfColLotID) = vbNullString Then

                Exit Sub
            End If

        '@↑2009/06/29 (Mon) 09:40:27 N.Kojima **************************************************
            
            '@引継ぎ構造体の退避
            ltypOldCommonInfo = ptypCommonInfo

            With vsfBatList
                
                '@ﾀｲﾄﾙ以外か
                If .Row > 0 Then
                    
                    '@***********************
                    '@ 引継ぎﾃﾞｰﾀを格納
                    '@***********************
                    pstrCarrierID = .GetData(.Row, CMlngvsfColCarrierID)                   'ｷｬﾘｱID1
                    ptypCommonInfo.strCarrierId = .GetData(.Row, CMlngvsfColCarrierID)     'ｷｬﾘｱID2
                    
                    '@最新取得前選択ﾛｯﾄ最終更新日時退避
                    lstrLotLastUpdate = .GetData(.Row, CMlngvsfColLastUpdate)
                
                    '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                    pblnFormLoad = False
                    
                    '@親ﾌｫｰﾑからの呼び出しを識別するために起動識別ﾌﾗｸﾞをTrueにする
                    pblnfrmxxCM0070Kbn = True
                    
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    '@ WF状態変更登録画面　起動処理
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    frmxxCM0070.Instance = New frmxxCM0070()
            
                    '@=======================
                    '@ 機能関連情報取得処理
                    '@=======================
                    Call pubMenuItemCorrelation_Set(CPstrKeyEN0180, lstrTitle)

                    '@WF状態変更登録画面の名称設定
                    frmxxCM0070.Instance.Text = lstrTitle
                    
                    '@ﾌｫｰﾑﾛｰﾄﾞ結果が"False：起動失敗"か
                    If pblnFormLoad = False Then
                        
                        '@引継ぎｷｬﾘｱ情報の初期化
                        ptypCommonInfo = ltypOldCommonInfo
                        
                        '@∇∇∇∇∇∇∇∇∇∇∇
                        '@ ｱﾝﾛｰﾄﾞ処理
                        '@∇∇∇∇∇∇∇∇∇∇∇
                        frmxxCM0070.Instance = Nothing
                        
                        Exit Sub
                    End If
                    
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    '@ WF状態変更登録画面　表示処理
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    frmxxCM0070.Instance.ShowDialog(Me)
                    frmxxCM0070.Instance = Nothing
                    
                    '@引継ぎｷｬﾘｱ情報の初期化
                    ptypCommonInfo = ltypOldCommonInfo

                    '@=======================
                    '@ ﾊﾞｯﾁ作業終了画面の最新取得＆復元処理
                    '@ ※引数⇒True：最終更新日時判定あり、最新取得前最終更新日時
                    '@=======================
                    Call prvRefresh_Disp(True, lstrLotLastUpdate)
                    
                End If
            End With
            
            '@確定ﾎﾞﾀﾝが有効か
            If cmdRegist.Enabled = True Then
                
                '@確定ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdRegist)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTreatWF_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWorkRecord_Click
    '機　能：作業記録ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/22 (Thu) 09:30:53 S.Deguchi
    '更新日：2009/06/28 (Sun) 14:24:04 N.Kojima
    '備　考：
    '　　　：2009/06/28 (Sun) 14:24:04 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdWorkRecord_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkRecord.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@仕様保留中の為,現状常時無効

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkRecord_Click"
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
    '作成日：2004/07/20 (Wed) 17:45:40 S.Deguchi
    '更新日：2016/03/22 (Tue) 15:40:41 T.Oide
    '備　考：
    '　　　：2004/08/27 (Fri) 16:33:40 M.Miura　    次工程自動送出ｺﾝﾎﾞをｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝに変更
    '　　　：2004/10/07 (Thu) 11:31:58 S.Deguchi    流動完了時の次工程送出先の判定でﾒｯｾｰｼﾞを分岐(不具合改善№1008)
    '　　　：2004/10/27 (Wed) 17:03:59 M.Miura　    次工程送出の引数の大小工程を削除(障害不具合№76)
    '　　　：2004/12/10 (Fri) 13:10:59 S.Deguchi    CtlSvr2対応
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2005/08/26 (Fri) 10:36:27 N.Kojima     要求構造体格納処理にstrCommentsを追加。(不具合№3035)
    '　　　：2005/09/27 (Tue) 11:20:52 N.Kasai      成功ﾒｯｾｰｼﾞ修正余白削除(№2299)
    '　　　：2006/11/07 (Tue) 10:56:48 M.Miura      保留中でも作業終了まで可の対応(案件№01437)
    '　　　：2009/01/19 (Mon) 14:53:55 M.Koni       [lot_.nextsend]ﾛｯﾄ分割確認要求ﾌﾗｸﾞ追加対応 <案件No.03329>
    '　　　：2009/03/05 (Thu) 10:45:57 N.Kojima     量産ｵｰﾀﾞｰ振替ﾁｪｯｸ処理追加。(案件№03402)
    '　　　：2009/06/28 (Sun) 14:24:44 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/15 (Wed) 16:59:17 N.Kojima     無機対応Phase2、確定ﾒｯｾｰｼﾞの判定処理変更。(案件№03661)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                     As Boolean              '結果取得(True:正常,False:異常)
        Dim lblnLotMatchFlag            As Boolean              '送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞ(True:格納済,False:未格納)
        Dim lblnCtlAns                  As Boolean              'CtlSvr2結果取得(True:正常,False:異常)
        Dim lblnChkChangeOrderAns       As Boolean              '量産ｵｰﾀﾞｰ振替ﾁｪｯｸ戻り値格納用
        Dim lblnShowFlag                As Boolean              '移載、ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ表示ﾌﾗｸﾞ(True：表示、False：非表示)
        Dim ltypBatEndWrk               As BatEndWrk            'ﾊﾞｯﾁﾛｯﾄ作業終了構造体
        Dim ltypBatLotEndList           As BatLotEndList        'ﾊﾞｯﾁﾛｯﾄ作業終了結果格納構造体
        Dim ltypCtlUpdWaitingLotList    As CtlUpWaitingLot      'CtlSvr2送信構造体
        Dim llngMsgAns                  As Integer              'ﾎﾟｯﾌﾟｱｯﾌﾟ結果格納用
        Dim llngCnt                     As Integer              '汎用ｶｳﾝﾀ1
        Dim llngCnt2                    As Integer              '汎用ｶｳﾝﾀ2
        Dim llngEndCnt                  As Integer              '汎用ｶｳﾝﾀ3
        Dim lstrCarrierID               As String               '登録ｷｬﾘｱID連結
        Dim lstrCompareCarrierID        As String               '比較用ｷｬﾘｱID
        Dim lstrRLotID                  As String               '結果ﾛｯﾄID
        Dim lstrClassDivision           As String               '処理区分
        Dim llngBatchFlag               As Integer              'ﾊﾞｯﾁ作業終了ﾌﾗｸﾞ
        Dim lstrErrorMsg                As String               'ﾊﾞｯﾁ作業終了ｴﾗｰﾒｯｾｰｼﾞ
        Dim lstrErrorMsgCal             As String               'ﾊﾞｯﾁ作業終了ｴﾗｰﾒｯｾｰｼﾞ集計
        Dim lstrErrorCode               As String               'ﾊﾞｯﾁ作業終了ｴﾗｰｺｰﾄﾞ
        Dim lstrResultFlag              As String               '処理結果ﾌﾗｸﾞ
        Dim llngACnt                    As Integer              'ｱｸｼｮﾝ予約ｶｳﾝﾄ
        Dim lstrActionFlag              As String               'ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ
        Dim lstrSendResult              As String               '次工程送出結果格納(Null:次工程送出/0:中間在庫/1:完成在庫/2:組立送品)
        Dim lstrGuidMsg                 As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode             As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance            As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrHoldMsg                 As String               '保留ﾒｯｾｰｼﾞ表示用
        Dim lstrDividedCheckFlag        As String               'ﾛｯﾄ分割確認要求ﾌﾗｸﾞ
        Dim ltypSpcJudge                As SpcJudge             'SPC規格値判定構造体
        Dim lblnSpcSpecchkAns           As Boolean              'SPC規格値判定結果
        Dim lstrSpcArermMsg             As String               'ｱﾗｰﾑ判定異常ﾒｯｾｰｼﾞ格納
        Dim lblnSpcJudgeSystemErr       As Boolean              'ｱﾗｰﾑ判定ｼｽﾃﾑｴﾗｰﾌﾗｸﾞ
        Dim lstrErrLotID                As String               'ｱﾗｰﾑ判定失敗ﾛｯﾄ
		Dim ltypWaferList               As Waferlist			'WF情報格納用構造体
		Dim lblnAfterJReserveFlag       As Boolean				'蒸着後流動予約処理実行ﾌﾗｸﾞ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑのﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                
                Exit Sub
            End If
            
            '@=======================
            '@ 確定前ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInputInfo_Chk()
            
            '@確定前ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
            If lblnAns = False Then
                Exit Sub
            End If


            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@作業者ｺｰﾄﾞ入力画面でｷｬﾝｾﾙﾎﾞﾀﾝを押されたか
            If pblnCancel = True Then
                Exit Sub
            End If

			lblnAfterJReserveFlag = False

            '@確定処理したｷｬﾘｱIDを格納する為に,まず初期化
            lstrErrorMsgCal = vbNullString
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypBatEndWrk
                
        '        .lngBLotListCnt = lblLotNum.Caption                 'ﾛｯﾄ数
                
                .strSbID = pstrSBID                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strBatchId = lblBatID.Text                              'ﾊﾞｯﾁID
                .strComments = txtWorkMemo.Text                     '作業ﾒﾓ
                .strEmpID = pstrUserID                              '作業者ID
                .strMsgVer = CMstrbat_endwrk_Ver                    'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strClassDivision = CPstrCD01                       '処理区分(01=ｸﾗｲｱﾝﾄ)
                .strEqType = mtypBatLotList.typBatLot(0).strEqType  '装置ﾀｲﾌﾟ
                
                '@ﾊﾞｯﾁ組ﾛｯﾄIDと最終更新日時を構造体へ
                For llngCnt = 1 To vsfBatList.Rows.Count - 1
                
                    '@ﾛｯﾄIDがNULL以外か
                    If vsfBatList.GetData(llngCnt, CMlngvsfColLotID) <> vbNullString Then
                        
                        '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞの初期化
                        lblnLotMatchFlag = False
                        
                        For llngCnt2 = 0 To .lngBLotListCnt - 1
                            
                            '@送信ﾃﾞｰﾀのﾛｯﾄﾘｽﾄに既に対象ﾛｯﾄが格納済みか
                            If .typBLotList(llngCnt2).strLotID = _
                                vsfBatList.GetData(llngCnt, CMlngvsfColLotID) Then
                                
                                '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞに"True：格納済"をｾｯﾄ
                                lblnLotMatchFlag = True
                            End If
                        Next llngCnt2
                            
                        '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞが"False：格納済"か
                        If lblnLotMatchFlag = False Then
                            
                            '@ﾘｽﾄを+1する
                            .lngBLotListCnt = .lngBLotListCnt + 1
                            If IsNothing(.typBLotList) Then
                                .typBLotList = New List(Of BLotList)()
                            End If
                            Dim tmpBLotList As BLotList = New BLotList()
                            
                            tmpBLotList.strLotID = _
                                vsfBatList.GetData(llngCnt, CMlngvsfColLotID)          'ﾛｯﾄID
                                
                            tmpBLotList.strLotLastUpdate = _
                                vsfBatList.GetData(llngCnt, CMlngvsfColLastUpdate)     '最終更新日時
                            
                            tmpBLotList.strLotKind = _
                                vsfBatList.GetData(llngCnt, CMlngvsfColLotKind)        'ﾛｯﾄ区分
                            .typBLotList.Add(tmpBLotList)
                        End If
                    End If
                Next llngCnt
                
            End With
            
            '@=======================
            '@ ﾊﾞｯﾁ作業終了
            '@=======================
            lblnAns = pubblnbatEndWrk_Upd(ltypBatEndWrk, _
                                          ltypBatLotEndList, _
                                          lstrGuidMsg, _
                                          lstrGuidMsgCode)
            
            '@ﾊﾞｯﾁ作業終了結果が"True：通信成功"か
            If lblnAns = True Then
                
                '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞに値が入っているか
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
                
                '@取得(更新)したﾛｯﾄの最終更新日時をｸﾞﾘｯﾄﾞの列へ反映
                With vsfBatList
                    
                    For llngEndCnt = 0 To ltypBatLotEndList.lngLotEndListCnt - 1
                        
                        '@ﾛｯﾄID格納(長いから変数に退避)
                        lstrRLotID = ltypBatLotEndList.typLotEndList(llngEndCnt).strLotID
                        
                        For llngCnt = 1 To .Rows.Count - 1
                            
                            '@確定処理返却ﾛｯﾄIDとﾊﾞｯﾁ組情報一覧のﾛｯﾄIDが同じか
                            If lstrRLotID = .GetData(llngCnt, CMlngvsfColLotID) Then
                                
                                '@最終更新日時
                                .SetData(llngCnt, CMlngvsfColLastUpdate, _
                                    ltypBatLotEndList.typLotEndList(llngEndCnt).strLastUpdate)
                                    
                                '@処理結果ﾌﾗｸﾞ
                                .SetData(llngCnt, CMlngvsfColResultFlag, _
                                    ltypBatLotEndList.typLotEndList(llngEndCnt).strResultFlag)

                                '@蒸着ﾊﾞｯﾁの場合、同一ﾛｯﾄIDが重複して表示されており、
                                '@以下のｺｰﾄﾞで同一ﾛｯﾄの処理を行わないようにする為にﾙｰﾌﾟ抜けしてﾃﾞｰﾀの違いを作る。
                                Exit For
                            
                            End If
                        Next llngCnt
                    Next llngEndCnt
                    
                    
        '@↓2016/03/22 (Tue) 13:06:18 T.Oide **************************************************
                    '@ｱﾗｰﾑﾒｯｾｰｼﾞ格納変数初期化
                    lstrSpcArermMsg = vbNullString
                    lblnSpcJudgeSystemErr = False
                    
                    '@ﾛｯﾄﾘｽﾄで回してｱﾗｰﾑ判定を実行
                    For llngEndCnt = 0 To ltypBatLotEndList.lngLotEndListCnt - 1
                        
                        '@ﾛｯﾄID格納
                        lstrRLotID = ltypBatLotEndList.typLotEndList(llngEndCnt).strLotID
                        
                        '@ｸﾞﾘｯﾄﾞの行数で回して対象ﾛｯﾄと同じ行を探す
                        For llngCnt = 1 To .Rows.Count - 1
                            
                            '@対象ﾛｯﾄと同じか
                            If lstrRLotID = .GetData(llngCnt, CMlngvsfColLotID) Then
                                
                                '@SPC規格値判定実行用の構造体に情報をｾｯﾄ
                                With ltypSpcJudge
                                    .strMsgVer = CMstrspc_judge___Ver                                       'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                                    .strSbID = pstrSBID                                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                                    .strLotID = vsfBatList.GetData(llngCnt, CMlngvsfColLotID)      'ﾛｯﾄID
                                    .strOpID = vsfBatList.GetData(llngCnt, CMlngvsfColOpID)        '大工程ID
                                    .strStepID = vsfBatList.GetData(llngCnt, CMlngvsfColStepID)    '小工程ID
                                    .strEmpID = pstrUserID                                                  '作業者ID
                                    .strNextLotID = .strLotID                                               '作業終了後ﾛｯﾄID
                                End With
                    
                                '@**************************************************
                                '@ SPC規格値判定ﾒｯｾｰｼﾞ送信処理呼び出し
                                '@**************************************************
                                lblnSpcSpecchkAns = pubblnSpcJudge_Sel(ltypSpcJudge)
                                
                                '@ｱﾗｰﾑ判定は失敗か
                                If lblnSpcSpecchkAns = False Then
                                    '@ｼｽﾃﾑｴﾗｰの場合はﾌﾗｸﾞを立てておく
                                    ' ﾊﾞｯﾁ内の判定は一通り行い、次行程送出の前で処理を中止する
                                    lblnSpcJudgeSystemErr = True
                                    lstrErrLotID = lstrErrLotID + ltypSpcJudge.strLotID + " "
                                End If
                                
                                '@「管理NG」「規格NG」「その他NG(有効ﾃﾞｰﾀ不足など)」の場合ｴﾗｰﾒｯｾｰｼﾞを格納
                                If ltypSpcJudge.strSpecCheck = CMstrSpecCheckSPCNG Or _
                                   ltypSpcJudge.strSpecCheck = CMstrSpecCheckSpecNG Or _
                                   ltypSpcJudge.strSpecCheck = CMstrSpecCheckOtherNG Then

                                    '@ﾒｯｾｰｼﾞを退避しておく(最後にまとめて表示用)
                                    lstrSpcArermMsg = lstrSpcArermMsg + _
                                            ltypSpcJudge.strSpecMsgCode + vbCrLf + _
                                            lstrRLotID + ":" + Mid$(ltypSpcJudge.strSpecMsg, 2) + vbCrLf + vbCrLf   'MIDの2は先頭の「$｣を外して改行させない為
                                End If

                                '@蒸着ﾊﾞｯﾁの場合、同一ﾛｯﾄIDが重複して表示されており、
                                '@以下のｺｰﾄﾞで同一ﾛｯﾄの処理を行わないようにする為にﾙｰﾌﾟ抜けしてﾃﾞｰﾀの違いを作る。
                                Exit For
                            
                            End If
                        Next llngCnt
                    Next llngEndCnt
                    
                    '@ｱﾗｰﾑ判定異常があった場合ﾒｯｾｰｼﾞを表示する(まとめて表示)
                    If lstrSpcArermMsg <> vbNullString Then
                        '@spcｻｰﾊﾞが返した、異常ﾒｯｾｰｼﾞをまとめて表示
                        pstrDMsg = pubstrMsgReplace_Set(lstrSpcArermMsg)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If
                    
                    '@ｱﾗｰﾑ判定に失敗はないか
                    If lblnSpcJudgeSystemErr = True Then
                        '@失敗がある場合処理を中止する
                        
                        '@Spcｱﾗｰﾑ判定が失敗しました。処理を中止します。
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000R, lstrErrLotID)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                        
                        '@処理中断
                        Exit Sub
                    End If
        '@↑2016/03/22 (Tue) 13:06:18 T.Oide **************************************************
                End With

				'@★ 装置ﾀｲﾌﾟにより処理分岐 ★
				'斜方蒸着の作業終了時のみ蒸着後流動予約処理を行う
                 If pstrSBID = CPstrSBID2A0 And mtypBatLotList.typBatLot(0).strEqType = CPstrEqTypeJyoucyaku Then
					'kkw 蒸着後流動予約 自動分割・統合処理
					With vsfBatList
					   '@ﾛｯﾄﾘｽﾄで回す実行
						For llngEndCnt = 0 To ltypBatLotEndList.lngLotEndListCnt - 1
							'@ﾛｯﾄID格納
							lstrRLotID = ltypBatLotEndList.typLotEndList(llngEndCnt).strLotID
							'@ｸﾞﾘｯﾄﾞの行数で回して対象ﾛｯﾄと同じ行を探す
							For llngCnt = 1 To .Rows.Count - 1
								''@対象ﾛｯﾄと同じか
								If lstrRLotID = .GetData(llngCnt, CMlngvsfColLotID) Then
									'既に統合ロットとして処理されているか確認
									'混在していない場合は既に統合対象として選定されておりロットIDが変わっている可能性があるため
									'既に処理されている場合はスキップする
									Dim lblnSkipFlag As Boolean = False
									If mtypCombineLot.Count > 0 Then
										Dim llngTmpCnt As Integer
										For llngTmpCnt = 0 To  mtypCombineLot.Count - 1
											If  mtypCombineLot(llngTmpCnt).strLotId = lstrRLotID Or  mtypCombineLot(llngTmpCnt).strCombineLotId = lstrRLotID Then
												lblnSkipFlag = True
												Exit For
											End If
										Next

										If lblnSkipFlag = True Then
											Exit For
										End If

									End If

									'@ｷｬﾘｱIDを格納
									lstrCarrierID = .GetData(llngCnt, CMlngvsfColCarrierID)
									'最終更新日時取得
									mstrLotLastUpdate = .GetData(llngCnt, CMlngvsfColLastUpdate)

									'各ロットに対して蒸着後流動予約自動分割、統合、キャリア交換を実施する
									Call prvAfterJReserveAction(lstrCarrierID, lstrRLotID)

									'@蒸着ﾊﾞｯﾁの場合、同一ﾛｯﾄIDが重複して表示されており、
									'@以下のｺｰﾄﾞで同一ﾛｯﾄの処理を行わないようにする為にﾙｰﾌﾟ抜けしてﾃﾞｰﾀの違いを作る。
									Exit For

								End If
							Next llngCnt
						Next llngEndCnt
					End With
                
					'kkw 蒸着後流動予約
					'蒸着流動予約があった場合フラグをON
					If mtypAJRLot.Count > 0  Then
						'自動分割、自動統合、自動キャリア交換が行われた場合にはロットIDが変わっている可能性があるため別途次工程送出処理を行う
						lblnAfterJReserveFlag = True
					End If

				End If

                '@「送出あり」にﾁｪｯｸが付いているか
                If optLotNextSend0.Checked = True Then
                    '@「送出あり」にﾁｪｯｸが付いているの場合
                    
                    '@***********************
                    '@ ﾊﾞｯﾁ組みされているﾛｯﾄ全てに対して次工程送出を行う
                    '@ ※ﾀﾞﾐｰ冶具、未使用処理部は除く
                    '@***********************
                    With vsfBatList
                        
                        For llngCnt = 1 To .Rows.Count - 1
                            
							'もし蒸着後流動予約に関して流動中
							If pstrSBID = CPstrSBID2A0 And lblnAfterJReserveFlag = True Then
								
								Dim targetLotId As String = .GetData(llngCnt, CMlngvsfColLotID)

								' 次の4つの構造体どれかにロットIDが含まれていれば通常の次工程送出処理はスキップ
								'処理済み(分割等はなし)、分割元、統合元、統合先、ｷｬﾘｱ交換対象
								If mtypAJRLot.Any(Function(x) x = targetLotId) _
								OrElse mtypDivideLot.Any(Function(x) x.strLotId = targetLotId) _
								OrElse mtypDivideLot.Any(Function(x) x.strDivideLotId = targetLotId) _
								OrElse mtypCombineLot.Any(Function(x) x.strLotId = targetLotId) _
								OrElse mtypCombineLot.Any(Function(x) x.strCombineLotId = targetLotId) _
								OrElse mtypCarrierMoveLot.Any(Function(x) x.strLotId = targetLotId) Then

									Continue For
								End If

							End If

                            '@***********************
                            '@ 以下の条件の場合、次工程送出、ｵｰﾀﾞｰ振替ﾁｪｯｸ、処理待ちﾛｯﾄ更新はｽｷｯﾌﾟ
                            '@ ①ﾀﾞﾐｰ冶具、未使用処理部の場合(蒸着限定)
                            '@ ②重複ﾛｯﾄの場合(蒸着限定)
                            '@***********************

                            '@ﾛｯﾄIDがNULL以外(製品ﾛｯﾄorﾓﾆﾀﾛｯﾄ)、または処理結果ﾌﾗｸﾞがNULL以外か
                            If .GetData(llngCnt, CMlngvsfColLotID) <> vbNullString Or _
                                .GetData(llngCnt, CMlngvsfColResultFlag) <> vbNullString Then
                            
                                '@処理結果ﾌﾗｸﾞを格納
                                lstrResultFlag = .GetData(llngCnt, CMlngvsfColResultFlag)
                            
                                '@処理結果ﾌﾗｸﾞが"00：流動可(次工程送出可)"か
                                If lstrResultFlag = CMstrResultFlag00 Then
                                    
                                    '@各種変数を初期化
                                    llngBatchFlag = CMlngBatchWorkEnd           'ﾊﾞｯﾁ作業終了ﾌﾗｸﾞ(初期化:正常処理)
                                    lstrErrorMsg = vbNullString                 'ﾊﾞｯﾁ作業終了ｴﾗｰﾒｯｾｰｼﾞ
                                    
                                    '@-----------------------
                                    '@ 次工程送出処理の処理区分設定
                                    '@-----------------------
                                    '@次大工程があるか
                                    If .GetData(llngCnt, CMlngvsfColNextOpID) <> vbNullString Then
                                        
                                        '@ある場合、処理区分に"NULL：次工程送出"をｾｯﾄ
                                        lstrClassDivision = vbNullString
                                    Else
                                        '@ない場合、処理区分に"24：流動完了"をｾｯﾄ
                                        lstrClassDivision = CPstrCD24
                                    End If
            
            
                                    '@-----------------------
                                    '@ 分割ﾁｪｯｸ判定
                                    '@-----------------------
                                    '@ﾛｯﾄ分割ﾁｪｯｸの有効／無効化 → 最終工程の場合のみ有効化
                                    '@処理区分が"24：流動完了"か
                                    If lstrClassDivision = CPstrCD24 Then
                                        
                                        '@分割ﾁｪｯｸﾌﾗｸﾞに"1：分割ﾁｪｯｸする"をｾｯﾄ
                                        lstrDividedCheckFlag = CPstrOne
                                    Else
                                        '@分割ﾁｪｯｸﾌﾗｸﾞに"0：分割ﾁｪｯｸしない"をｾｯﾄ
                                        lstrDividedCheckFlag = CPstrZero
                                    End If
            
            
                                    '@-----------------------
                                    '@ 量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
                                    '@-----------------------
                                    '@起動SBが組立か
                                    If pstrSBID = CPstrSBID2A0 Then
                                        '@2A0：組立の場合
                
                                        '@=======================
                                        '@ 量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
                                        '@=======================
                                        '@【量産ｵｰﾀﾞｰ振替ﾁｪｯｸ】ﾒｯｾｰｼﾞ送受信処理
                                        lblnChkChangeOrderAns = pubblnLotChkChgOrder_Chk(CMstrlot_chkchangeorderVer, _
                                                                                        .GetData(llngCnt, CMlngvsfColLotID), _
                                                                                        lstrGuidMsg, _
                                                                                        lstrGuidMsgCode)
                
                                        '@量産ｵｰﾀﾞｰ振替ﾁｪｯｸ結果が"True：ﾁｪｯｸ処理成功"か
                                        If lblnChkChangeOrderAns = True Then
                
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
                                        End If
                                    End If
            
                                    
                                    '@=======================
                                    '@ ﾛｯﾄ次工程送出(1回目)
                                    '@=======================
                                    lblnAns = pubblnLotNextSend_Upd(CMstrlot_nextSendVer _
                                                                   , .GetData(llngCnt, CMlngvsfColLotID) _
                                                                   , .GetData(llngCnt, CMlngvsfColLastUpdate) _
                                                                   , pstrUserID _
                                                                   , lstrDividedCheckFlag _
                                                                   , lstrClassDivision _
                                                                   , llngBatchFlag _
                                                                   , lstrErrorMsg _
                                                                   , lstrErrorCode _
                                                                   , lstrActionFlag _
                                                                   , _
                                                                   , lstrSendResult)
                                    
                                    '@1回目のﾛｯﾄ次工程送出結果が"True：通信成功"か
                                    If lblnAns = True Then
            
                                        '@ﾛｯﾄ次工程送出結果が"9：送品中断"か(要するにﾛｯﾄ分割されている場合⇒ﾕｰｻﾞｰ確認を行います)
                                        If lstrSendResult = CPstrSendAbort Then
            
                                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                            Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
            
                                            '@表示ﾒｯｾｰｼﾞ変換
                                            '@「"<TRM9JW>$$ロット[%1]は、ロット分割されています。$ロット分割状態のまま送出しますか？"」のﾒｯｾｰｼﾞ表示
                                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009J, .GetData(llngCnt, CMlngvsfColLotID))
                                            llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16, False)
            
                                            '@「はい」なら分割状態で送品する。
                                            '@ ※DIVIDED_CHECK_FLAG=0(分割ﾁｪｯｸ無し) とし、再度、ﾒｯｾｰｼﾞを発行する。
                                            If llngMsgAns = vbYes Then
            
                                                '@分割ﾁｪｯｸﾌﾗｸﾞに"0：分割ﾁｪｯｸなし"をｾｯﾄ
                                                lstrDividedCheckFlag = CPstrZero
                                                
                                                
                                                '@=======================
                                                '@ ﾛｯﾄ次工程送出(2回目)　※DIVIDED_CHECK_FLAG=0
                                                '@=======================
                                                lblnAns = pubblnLotNextSend_Upd(CMstrlot_nextSendVer _
                                                                               , .GetData(llngCnt, CMlngvsfColLotID) _
                                                                               , .GetData(llngCnt, CMlngvsfColLastUpdate) _
                                                                               , pstrUserID _
                                                                               , lstrDividedCheckFlag _
                                                                               , lstrClassDivision _
                                                                               , llngBatchFlag _
                                                                               , lstrErrorMsg _
                                                                               , lstrErrorCode _
                                                                               , lstrActionFlag _
                                                                               , _
                                                                               , lstrSendResult)
            
                                                '@2回目のﾛｯﾄ次工程送出結果が"True：通信成功"か
                                                If lblnAns = True Then
            
                                                    '@次工程送出結果が"NULL：次工程送出"か
                                                    '@ ※0:中間在庫/1:完成在庫/2:組立送品
                                                    If lstrSendResult = vbNullString Then
                                                        
                                                        '@-----------------------
                                                        '@ NULL：次工程送出時のみ処理待ちﾛｯﾄ更新処理を行う
                                                        '@-----------------------
                                                        
                                                        '@***********************
                                                        '@ 送信ﾃﾞｰﾀ作成
                                                        '@***********************
                                                        With ltypCtlUpdWaitingLotList
                                                            
                                                            .strClassDivision = CPstrCD01                                                       '処理区分(=01)
                                                            .strMsgVer = CMstrctl_updwaitinglotVer                                              'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                                                            .strSbID = pstrSBID                                                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                                                            .strWpID = vbNullString                                                             'WPID(=vbNullString)
                                                            
                                                            .lngWaitingLotListCnt = 1                                                           'ﾘｽﾄｶｳﾝﾄ(=1)
                                                            If IsNothing(.typWaitingLotList) Then
                                                                .typWaitingLotList = New List(Of UpWaitingLotList)()
                                                            Else
                                                                .typWaitingLotList.Clear()
                                                            End If
                                                            Dim tmpUpWaitingLotList As UpWaitingLotList = New UpWaitingLotList()
            
                                                            tmpUpWaitingLotList.strLotID = _
                                                                vsfBatList.GetData(llngCnt, CMlngvsfColLotID)                          'ﾛｯﾄID
            
                                                            tmpUpWaitingLotList.strOpID = _
                                                                vsfBatList.GetData(llngCnt, CMlngvsfColOpID)                           '大工程
            
                                                            tmpUpWaitingLotList.strStepID = _
                                                                vsfBatList.GetData(llngCnt, CMlngvsfColStepID)                         '小工程
            
                                                            tmpUpWaitingLotList.strSeqNum = vbNullString                  '処理順(=vbNullString)
                                                            .typWaitingLotList.Add(tmpUpWaitingLotList)
                                                        End With


                                                        '@=======================
                                                        '@ 処理待ちﾛｯﾄ更新
                                                        '@=======================
                                                        lblnCtlAns = pubblnCtlUpdWaitingLot_Upd(ltypCtlUpdWaitingLotList)
                                                        
                                                        '@処理待ちﾛｯﾄ更新結果が"False：通信失敗"か
                                                        If lblnCtlAns = False Then
                                                            
                                                            '@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"2：ﾊﾞｯﾁ作業終了処理失敗"か
                                                            If llngBatchFlag = CMlngBatchOnError Then
                                                                
                                                                Exit Sub
                                                            End If
            
                                                            '@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"3：要求処理失敗"か
                                                            If llngBatchFlag = CMlngBatchRequestFail Then
                                                                
                                                                '@ｴﾗｰﾒｯｾｰｼﾞをまとめて変数に保管(ｴﾗｰ表記：<ErrorCode> ErrorMsg)
                                                                lstrErrorMsgCal = lstrErrorMsgCal & _
                                                                                  CPstrStartMsgCode & _
                                                                                  lstrErrorCode & _
                                                                                  CPstrEndMsgCode & _
                                                                                  CMstrEnter & _
                                                                                  lstrErrorMsg & _
                                                                                  CMstrEnter
                                                            
                                                            End If
                                                        End If
                                                    End If
            
                                                    '@次大工程がNULL以外(次工程がある)か
                                                    If .GetData(llngCnt, CMlngvsfColNextOpID) <> vbNullString Then
                                                        '@次工程がある場合
                                                        
                                                        '@***********************
                                                        '@ さまざまな結果に従い、ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰに表示
                                                        '@***********************
                                                        
                                                        '@表示ﾒｯｾｰｼﾞ変換
                                                        '@「"<TRM14I>$$作業を終了して、次工程へ送出しました。キャリア[%1] ロット[%2]"」のﾒｯｾｰｼﾞ表示
                                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0014, _
                                                                                        .GetData(llngCnt, CMlngvsfColCarrierID), _
                                                                                        .GetData(llngCnt, CMlngvsfColLotID))
            
                                                        '@成功ﾒｯｾｰｼﾞ表示
                                                        Call pubVsfInfo_Disp(pstrDMsg)
            
                                                        '@表示ﾒｯｾｰｼﾞの初期化
                                                        pstrDMsg = vbNullString
                                                        
                                                        '@★ ｱｸｼｮﾝ予約実行ﾌﾗｸﾞにより処理分岐 ★
                                                        Select Case lstrActionFlag
                                                            
                                                            '@〓 ﾛｯﾄ停止 〓
                                                            Case CPstrActionFlag1
                                                                
                                                                '@表示ﾒｯｾｰｼﾞ変換
                                                                '@「"<TRM2SI>$$アクション予約によりロット[ %1 ] は [停止] されました。"」
                                                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, .GetData(llngCnt, CMlngvsfColLotID), CPstrStopSt)
                                                            
                                                            '@〓 ﾛｯﾄ保留 〓
                                                            Case CPstrActionFlag2
                                                                
                                                                '@表示ﾒｯｾｰｼﾞ変換
                                                                '@「"<TRM2SI>$$アクション予約によりロット[ %1 ] は [保留] されました。"」
                                                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, .GetData(llngCnt, CMlngvsfColLotID), CPstrHoldSt)
                                                        
                                                        End Select
            
                                                    Else
                                                        '@次工程がない(流動完了)の場合
                                                        
                                                        '@***********************
                                                        '@ 流動終了のﾒｯｾｰｼﾞを表示する
                                                        '@ ※lstrSendResult：(Null：次工程送出)、(0：中間在庫)、(1：完成在庫)、(2：組立送品)
                                                        '@***********************
                                                        
                                                        '@=======================
                                                        '@ 次工程送出ﾒｯｾｰｼﾞ送信結果受信時のﾎﾟｯﾌﾟｱｯﾌﾟ表示処理
                                                        '@=======================
                                                        Call pubLotNextSendResultPopUp(lstrSendResult, _
                                                                                        .GetData(llngCnt, CMlngvsfColCarrierID), _
                                                                                        .GetData(llngCnt, CMlngvsfColLotID))
                                                        
                                                        '@ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰにﾒｯｾｰｼﾞ表示
                                                        Call pubVsfInfo_Disp(pstrDMsg)
            
                                                    End If
            
                                                Else
                                                    '@2回目のﾛｯﾄ次工程送出(分割ﾁｪｯｸなしVer)の結果が"False：通信失敗"の場合
            
                                                    '@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"2：ﾊﾞｯﾁ作業終了処理失敗"か
                                                    If llngBatchFlag = CMlngBatchOnError Then
                                                        
                                                        Exit Sub
                                                    End If
            
                                                    '@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"3：要求処理失敗"か
                                                    If llngBatchFlag = CMlngBatchRequestFail Then
                                                        
                                                        '@ｴﾗｰﾒｯｾｰｼﾞをまとめて変数に保管(ｴﾗｰ表記：<ErrorCode> ErrorMsg)
                                                        lstrErrorMsgCal = lstrErrorMsgCal & _
                                                                          CPstrStartMsgCode & _
                                                                          lstrErrorCode & _
                                                                          CPstrEndMsgCode & _
                                                                          CMstrEnter & _
                                                                          lstrErrorMsg & _
                                                                          CMstrEnter
                                                    
                                                    End If
                                                End If
            
                                            Else
                                                '@「"<TRM9JW>$$ロット[%1]は、ロット分割されています。$ロット分割状態のまま送出しますか？"」のﾒｯｾｰｼﾞで、
                                                '@「いいえ」が選択された場合
                                                '@　→他のﾛｯﾄもある筈なので、ひとまず、対象ロットの送出処理を実施せずに次のﾛｯﾄのﾙｰﾌﾟに移行する。
                                                
                                                '@処理なし
            
                                            End If
            
                                        Else
                                            '@「送品中断」以外の場合(要するにﾛｯﾄが分割されていなく、ﾕｰｻﾞｰ確認が必要ない場合)
            
                                            '@次工程送出結果が"NULL：次工程送出"か
                                            '@ ※0:中間在庫/1:完成在庫/2:組立送品
                                            If lstrSendResult = vbNullString Then
                                                
                                                '@-----------------------
                                                '@ NULL：次工程送出時のみ処理待ちﾛｯﾄ更新処理を行う
                                                '@-----------------------
                                                
                                                '@***********************
                                                '@ 送信ﾃﾞｰﾀ作成
                                                '@***********************
                                                With ltypCtlUpdWaitingLotList
                                                    
                                                    .strClassDivision = CPstrCD01               '処理区分(=01)
                                                    .strMsgVer = CMstrctl_updwaitinglotVer      'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                                                    .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                                                    .strWpID = vbNullString                     'WPID(=vbNullString)
                                                    
                                                    .lngWaitingLotListCnt = 1                   'ﾘｽﾄｶｳﾝﾄ(=1)
                                                    If IsNothing(.typWaitingLotList) Then
                                                        .typWaitingLotList = New List(Of UpWaitingLotList)()
                                                    Else
                                                        .typWaitingLotList.Clear()
                                                    End If
                                                    Dim tmpUpWaitingLotList As UpWaitingLotList = New UpWaitingLotList()
            
                                                    tmpUpWaitingLotList.strLotID = _
                                                        vsfBatList.GetData(llngCnt, CMlngvsfColLotID)          'ﾛｯﾄID
            
                                                    tmpUpWaitingLotList.strOpID = _
                                                        vsfBatList.GetData(llngCnt, CMlngvsfColOpID)           '大工程
            
                                                    tmpUpWaitingLotList.strStepID = _
                                                        vsfBatList.GetData(llngCnt, CMlngvsfColStepID)         '小工程
            
                                                    tmpUpWaitingLotList.strSeqNum = vbNullString  '処理順(=vbNullString)
                                                    .typWaitingLotList.Add(tmpUpWaitingLotList)
                                                End With


                                                '@=======================
                                                '@ 処理待ちﾛｯﾄ更新
                                                '@=======================
                                                lblnCtlAns = pubblnCtlUpdWaitingLot_Upd(ltypCtlUpdWaitingLotList)
                                                
                                                '@処理待ちﾛｯﾄ更新結果が"False：通信失敗"か
                                                If lblnCtlAns = False Then
                                                    
                                                    '@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"2：ﾊﾞｯﾁ作業終了処理失敗"か
                                                    If llngBatchFlag = CMlngBatchOnError Then
                                                        
                                                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                                        Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                                                        Exit Sub
                                                    End If
            
                                                    '@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"3：要求処理失敗"か
                                                    If llngBatchFlag = CMlngBatchRequestFail Then
                                                        
                                                        '@ｴﾗｰﾒｯｾｰｼﾞをまとめて変数に保管(ｴﾗｰ表記：<ErrorCode> ErrorMsg)
                                                        lstrErrorMsgCal = lstrErrorMsgCal & _
                                                                          CPstrStartMsgCode & _
                                                                          lstrErrorCode & _
                                                                          CPstrEndMsgCode & _
                                                                          CMstrEnter & _
                                                                          lstrErrorMsg & _
                                                                          CMstrEnter
                                                    
                                                    End If
                                                End If
                                            End If
            
                                            '@次大工程がNULL以外(次工程がある)か
                                            If .GetData(llngCnt, CMlngvsfColNextOpID) <> vbNullString Then
                                                '@次工程がある場合
                                                
                                                '@***********************
                                                '@ さまざまな結果に従い、ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰに表示
                                                '@***********************
                                                
                                                '@表示ﾒｯｾｰｼﾞ変換
                                                '@「"<TRM14I>$$作業を終了して、次工程へ送出しました。キャリア[%1] ロット[%2]"」のﾒｯｾｰｼﾞ表示
                                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0014, _
                                                                                .GetData(llngCnt, CMlngvsfColCarrierID), _
                                                                                .GetData(llngCnt, CMlngvsfColLotID))
            
                                                '@成功ﾒｯｾｰｼﾞ表示
                                                Call pubVsfInfo_Disp(pstrDMsg)
            
                                                '@表示ﾒｯｾｰｼﾞの初期化
                                                pstrDMsg = vbNullString
                                                
                                                '@★ ｱｸｼｮﾝ予約実行ﾌﾗｸﾞにより処理分岐 ★
                                                Select Case lstrActionFlag
                                                    
                                                    '@〓 ﾛｯﾄ停止 〓
                                                    Case CPstrActionFlag1
                                                        
                                                        '@表示ﾒｯｾｰｼﾞ変換
                                                        '@「"<TRM2SI>$$アクション予約によりロット[ %1 ] は [停止] されました。"」
                                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, .GetData(llngCnt, CMlngvsfColLotID), CPstrStopSt)
                                                    
                                                    '@〓 ﾛｯﾄ保留 〓
                                                    Case CPstrActionFlag2
                                                        
                                                        '@表示ﾒｯｾｰｼﾞ変換
                                                        '@「"<TRM2SI>$$アクション予約によりロット[ %1 ] は [保留] されました。"」
                                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, .GetData(llngCnt, CMlngvsfColLotID), CPstrHoldSt)
                                                
                                                End Select
                                            Else
                                                '@次工程がない(流動完了)の場合
                                                
                                                '@***********************
                                                '@ 流動終了のﾒｯｾｰｼﾞを表示する
                                                '@ ※lstrSendResult：(Null：次工程送出)、(0：中間在庫)、(1：完成在庫)、(2：組立送品)
                                                '@***********************
            
                                                '@=======================
                                                '@ 次工程送出ﾒｯｾｰｼﾞ送信結果受信時のﾎﾟｯﾌﾟｱｯﾌﾟ表示処理
                                                '@=======================
                                                Call pubLotNextSendResultPopUp(lstrSendResult, .GetData(llngCnt, CMlngvsfColCarrierID), .GetData(llngCnt, CMlngvsfColLotID))
                                                
                                                '@ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰにﾒｯｾｰｼﾞ表示
                                                Call pubVsfInfo_Disp(pstrDMsg)
            
                                            End If
                                        End If
            
                                    Else
                                        '@1回目のﾛｯﾄ次工程送出結果が"False：通信失敗"か
                                        
                                        '@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"2：ﾊﾞｯﾁ作業終了処理失敗"か
                                        If llngBatchFlag = CMlngBatchOnError Then
                                            
                                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                            Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                                            Exit Sub
                                        End If
            
                                        '@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"3：要求処理失敗"か
                                        If llngBatchFlag = CMlngBatchRequestFail Then
                                            
                                            '@ｴﾗｰﾒｯｾｰｼﾞをまとめて変数に保管(ｴﾗｰ表記：<ErrorCode> ErrorMsg)
                                            lstrErrorMsgCal = lstrErrorMsgCal & _
                                                              CPstrStartMsgCode & _
                                                              lstrErrorCode & _
                                                              CPstrEndMsgCode & _
                                                              CMstrEnter & _
                                                              lstrErrorMsg & _
                                                              CMstrEnter
                                        
                                        End If
                                    End If
            
                                Else
                                    '@ﾊﾞｯﾁ作業終了で、処理結果ﾌﾗｸﾞが"00以外：次工程送出不可"が返されたﾛｯﾄか
                                    '@ ※移載予約状態、ｱｸｼｮﾝ予約停止、保留のいずれかの場合、次工程送出なし
                                    
                                    '@ｷｬﾘｱIDを格納
                                    lstrCarrierID = .GetData(llngCnt, CMlngvsfColCarrierID)
                                    
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    '@「"<TRM0LI>$$バッチ作業終了しました。キャリア[%1]"」
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000L, lstrCarrierID)
                                    
                                    '@ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰに表示
                                    Call pubVsfInfo_Disp(pstrDMsg)
                                    
                                    '@ﾛｯﾄIDを格納
                                    lstrRLotID = .GetData(llngCnt, CMlngvsfColLotID)
                                    
                                    '@処理結果ﾌﾗｸﾞの10の位が「1：移載予約状態」(例：11とか12とか)か
                                    If lstrResultFlag Like CMstrResultFlag1 & CMstrResultFlag_ Then
                                        
                                        '@移載、ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ表示ﾌﾗｸﾞが非表示の場合
                                        If lblnShowFlag = False Then
                                            
                                            '@ﾚｽﾎﾟﾝｽ取得終了
                                            Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                                        End If
            
                                        '@表示ﾒｯｾｰｼﾞ変換(ﾒｯｾｰｼﾞBOXに表示)
                                        '@「「"<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。"」
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006L, lstrRLotID, CMstrMsgMove)
                                        Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                                                 
                                        '@表示ﾒｯｾｰｼﾞ変換(ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰに表示)
                                        '@「"<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。"」
                                        lstrHoldMsg = pubstrMsgReplace_Set(CPstrMsgInf006L, lstrRLotID, CMstrMsgMove)
                                        
                                        '@ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰに表示
                                        Call pubVsfInfo_Disp(lstrHoldMsg)
                                        
                                        '@移載、ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ表示ﾌﾗｸﾞ(表示)
                                        lblnShowFlag = True
                                    End If
                                    
                                    '@ﾒｯｾｰｼﾞの初期化
                                    pstrDMsg = vbNullString
                                    
                                    '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ構造体初期化
                                    With ptypLotAction
                                        .lnglstCnt = 1
                                        If IsNothing(.typLotActList) Then
                                            .typLotActList = New List(Of LotActList)()
                                        Else
                                            .typLotActList.Clear()
                                        End If
                                        .typLotActList.Add(New LotActList())
                                    End With
                                    
            
                                    '@★ 処理結果ﾌﾗｸﾞの1の位の値により処理分岐 ★
                                    Select Case Strings.Right(lstrResultFlag, CMlngResultRight1)
                                        
                                        '@〓 1：ｱｸｼｮﾝ予約停止(1の位の場合) 〓
                                        Case CMstrResultFlag1
            
                                            '@表示ﾒｯｾｰｼﾞ変換
                                            '@「"アクション予約によりロット[ %1 ] は [ %2 ] されました。" & "$$ロット[ %3 ]は次工程送出されません。"」
                                            pstrDMsg = CPstrActionInfo & CPstrActionStopNextStepInfo
                                            pstrDMsg = pubstrMsgReplace_Set(pstrDMsg, lstrRLotID, CPstrStopSt, lstrRLotID)
                                            
                                            '@ｱｸｼｮﾝ予約実行ﾌﾗｸﾞに"1：ｱｸｼｮﾝ予約停止"をｾｯﾄ
                                            ptypLotAction.strActionFlag = CPstrActionFlag1
                                            
                                            '@表示ﾒｯｾｰｼﾞ変換
                                            '@「"<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。"」
                                            lstrHoldMsg = pubstrMsgReplace_Set(CPstrMsgInf006L, lstrRLotID, CMstrMsgActStop)
                                            
                                            '@ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰに表示
                                            Call pubVsfInfo_Disp(lstrHoldMsg)
                                        
                                        
                                        '@〓 2：ｱｸｼｮﾝ予約保留(1の位の場合) 〓
                                        Case CMstrResultFlag2
            
                                            '@表示ﾒｯｾｰｼﾞ変換
                                            '@「"アクション予約によりロット[ %1 ] は [ %2 ] されました。" & "$$ロット[ %3 ]は次工程送出されません。"」
                                            pstrDMsg = CPstrActionInfo & CPstrActionStopNextStepInfo
                                            pstrDMsg = pubstrMsgReplace_Set(pstrDMsg, lstrRLotID, CPstrHoldSt, lstrRLotID)
                                            
                                            '@ｱｸｼｮﾝ予約実行ﾌﾗｸﾞに"2：ｱｸｼｮﾝ予約保留"をｾｯﾄ
                                            ptypLotAction.strActionFlag = CPstrActionFlag2   '2:保留
                                    
                                            '@表示ﾒｯｾｰｼﾞ変換
                                            '@「"<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。"」
                                            lstrHoldMsg = pubstrMsgReplace_Set(CPstrMsgInf006L, lstrRLotID, CMstrMsgActHold)
                                            
                                            '@ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰに表示
                                            Call pubVsfInfo_Disp(lstrHoldMsg)
                                        
                                        
                                        '@〓 3：異常処理票保留(1の位の場合) 〓
                                        Case CMstrResultFlag3
                                            
                                            '@移載、ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ表示ﾌﾗｸﾞが"False：非表示"か
                                            If lblnShowFlag = False Then
                                                
                                                '@ﾚｽﾎﾟﾝｽ取得終了
                                                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                                                
                                                '@移載、ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ表示ﾌﾗｸﾞに"True：表示"をｾｯﾄ
                                                lblnShowFlag = True
                                            End If
                                            
                                            '@表示ﾒｯｾｰｼﾞ変換
                                            '@「"<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。"」
                                            lstrHoldMsg = pubstrMsgReplace_Set(CPstrMsgInf006L, lstrRLotID, CMstrMsgExcpHold)
                                            
                                            '@「<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。」のﾒｯｾｰｼﾞ表示
                                            Call publngMsgBoxInfo(lstrHoldMsg, vbInformation, Me.Text, True, 16)
                                            
                                            '@ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰに表示
                                            Call pubVsfInfo_Disp(lstrHoldMsg)
                                        
                                        
                                        '@〓 4：通常保留(1の位の場合) 〓
                                        Case CMstrResultFlag4
                                            
                                            '@移載、ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ表示ﾌﾗｸﾞが"False：非表示"か
                                            If lblnShowFlag = False Then
                                                
                                                '@ﾚｽﾎﾟﾝｽ取得終了
                                                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                                                
                                                '@移載、ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ表示ﾌﾗｸﾞに"True：表示"をｾｯﾄ
                                                lblnShowFlag = True
                                            End If
                                            
                                            '@表示ﾒｯｾｰｼﾞ変換
                                            '@「"<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。"」
                                            lstrHoldMsg = pubstrMsgReplace_Set(CPstrMsgInf006L, lstrRLotID, CMstrMsgHold)
                                            
                                            '@「"<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。"」のﾒｯｾｰｼﾞ表示
                                            Call publngMsgBoxInfo(lstrHoldMsg, vbInformation, Me.Text, True, 16)
                                            
                                            '@ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰに表示
                                            Call pubVsfInfo_Disp(lstrHoldMsg)
                                            
                                    End Select
                                    
                                    '@ｱｸｼｮﾝ予約の停止、保留ﾒｯｾｰｼﾞがあるか
                                    If pstrDMsg <> vbNullString Then
                                        
                                        '@移載、ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ表示ﾌﾗｸﾞが非表示の場合
                                        If lblnShowFlag = False Then
                                            '@ﾚｽﾎﾟﾝｽ取得終了
                                            Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                                        End If
                                        
                                        '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ構造体設定
                                        ptypLotAction.lnglstCnt = 1
                                        Dim tmpLotActList As LotActList = ptypLotAction.typLotActList(ptypLotAction.lnglstCnt-1)
                                        tmpLotActList.strMessage = pstrDMsg
                                        
                                        '@ｱｸｼｮﾝ予約ﾘｽﾄがなくなるまで
                                        For llngACnt = 0 To mlngActCnt - 1
                                            
                                            '@ﾛｯﾄIDが同じ場合
                                            If mtypLotActList(llngACnt).strLotID = lstrRLotID Then
                                                
                                                '@ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ表示用を格納
                                                tmpLotActList.strLotID = mtypLotActList(llngACnt).strLotID                           'ﾛｯﾄID
                                                tmpLotActList.strFlowClass = mtypLotActList(llngACnt).strFlowClass                   '流動区分
                                                tmpLotActList.strLotActionID = mtypLotActList(llngACnt).strLotActionID               'ｱｸｼｮﾝ予約ID
                                                tmpLotActList.strLotActionTypeID = mtypLotActList(llngACnt).strLotActionTypeID       'ｱｸｼｮﾝ予約ﾀｲﾌﾟID
                                                tmpLotActList.strLotActionTypeName = mtypLotActList(llngACnt).strLotActionTypeName   'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                                                tmpLotActList.strActionTrigger = mtypLotActList(llngACnt).strActionTrigger           'ｱｸｼｮﾝﾄﾘｶﾞｰ
                                                tmpLotActList.strOpID = mtypLotActList(llngACnt).strOpID                             '大工程
                                                tmpLotActList.strStepID = mtypLotActList(llngACnt).strStepID                         '小工程
                                                tmpLotActList.strWorkDirectionID = mtypLotActList(llngACnt).strWorkDirectionID       '作業指示書№
                                                Exit For
                                            End If
                                        Next llngACnt
                                        ptypLotAction.typLotActList(ptypLotAction.lnglstCnt-1) = tmpLotActList

                                        
                                        '@ﾏｳｽﾎﾟｲﾝﾀ設定(初期値)
                                        Cursor.Current = Cursors.Default
                                        
                                        '@ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ画面名称設定
                                        frmxxCM0040.Instance.Text = CPstrSubDispTitleActionInfo
                                        
                                        '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                                        '@ ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ表示画面　表示処理(ptypLotActionの情報でｱｸｼｮﾝ予約の内容を表示)
                                        '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                                        frmxxCM0040.Instance.ShowDialog(Me)
                                        frmxxCM0040.Instance = Nothing
                                        
                                        '@ﾏｳｽﾎﾟｲﾝﾀ設定(砂時計)
                                        Cursor.Current = Cursors.WaitCursor
            
                                        '@移載、ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ表示ﾌﾗｸﾞに"True：表示"をｾｯﾄ
                                        lblnShowFlag = True
                                    End If
                                End If
                            End If
                                                
                        Next llngCnt
                        
                        '@次工程送出失敗したｷｬﾘｱに対するﾒｯｾｰｼﾞ
                        If lstrErrorMsgCal <> vbNullString Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換(上記で作成したﾒｯｾｰｼﾞ)
                            pstrDMsg = pubstrMsgReplace_Set(lstrErrorMsgCal)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        End If
                    End With
                    
                    '@移載、ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ表示ﾌﾗｸﾞが"False：非表示か
                    If lblnShowFlag = False Then
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                    Else
                        '@ﾏｳｽﾎﾟｲﾝﾀ設定(初期値)
                        Cursor.Current = Cursors.Default
                    End If
                    
                Else
                    '@「送出なし」の場合
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                        
                    '@ﾊﾞｯﾁ組みされている全てのｷｬﾘｱを連結して成功ﾒｯｾｰｼﾞを表図する
                    With vsfBatList
                        
                        For llngCnt = 1 To .Rows.Count - 1
                            


                            '@ﾛｯﾄIDがNULL以外か
                            If .GetData(llngCnt, CMlngvsfColLotID) <> vbNullString Then
                                
                                '@比較用ｷｬﾘｱIDに格納
                                lstrCompareCarrierID = .GetData(llngCnt, CMlngvsfColCarrierID)
                                
                                '@-----------------------
                                '@ 既にｷｬﾘｱIDが格納されているかﾁｪｯｸ(蒸着ﾊﾞｯﾁ組対応)
                                '@-----------------------
                                '@表示ﾒｯｾｰｼﾞ用ｷｬﾘｱIDにﾙｰﾌﾟ行のｷｬﾘｱIDが含まれていないか
                                If InStr(1, lstrCarrierID, lstrCompareCarrierID) = 0 Then
                                    
                                    '@表示ﾒｯｾｰｼﾞ用のｷｬﾘｱID連結処理：[[ｷｬﾘｱID1][ｷｬﾘｱID2]]
                                    lstrCarrierID = lstrCarrierID _
                                                  & CMstrBrLeft _
                                                  & .GetData(llngCnt, CMlngvsfColCarrierID) _
                                                  & CMstrBrRight
                                End If
                            End If
                        Next llngCnt
                    End With

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM0LI>$$バッチ作業終了しました。キャリア[%1]"」
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000L, lstrCarrierID)

                    '@ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰに成功ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)



                    With vsfBatList
                        
                        For llngCnt = 1 To .Rows.Count - 1
                            
							'蒸着後流動予約処理
							If lblnAfterJReserveFlag = True Then
								' ｸﾞﾘｯﾄﾞのロットID取得
								Dim targetLotId As String = .GetData(llngCnt, CMlngvsfColLotID)

								' どれかの構造体にロットIDが含まれていればそのロットはロットIDが変わっている可能性があるためスキップ
								If mtypAJRLot.Any(Function(x) x = targetLotId) _
								OrElse	mtypDivideLot.Any(Function(x) x.strLotId = targetLotId) _
								OrElse mtypDivideLot.Any(Function(x) x.strDivideLotId = targetLotId) _
								OrElse mtypCombineLot.Any(Function(x) x.strLotId = targetLotId) _
								OrElse mtypCombineLot.Any(Function(x) x.strCombineLotId = targetLotId) _
								OrElse mtypCarrierMoveLot.Any(Function(x) x.strLotId = targetLotId) Then

									Continue For
								End If

							End If

                            '@ﾛｯﾄIDがNULL以外、かつ処理結果ﾌﾗｸﾞがNULL以外か
                            If .GetData(llngCnt, CMlngvsfColLotID) <> vbNullString And _
                                .GetData(llngCnt, CMlngvsfColResultFlag) <> vbNullString Then
                                
                                '@処理結果ﾌﾗｸﾞを格納
                                lstrResultFlag = .GetData(llngCnt, CMlngvsfColResultFlag)
                                
                                '@処理結果ﾌﾗｸﾞが"00：流動可(次工程送出可)"以外か
                                If lstrResultFlag <> CMstrResultFlag00 Then
                                    
                                    '@ﾛｯﾄIDを格納
                                    lstrRLotID = .GetData(llngCnt, CMlngvsfColLotID)
                                    
                                    '@処理結果ﾌﾗｸﾞの10の位が「1：移載予約状態」か
                                    If lstrResultFlag Like CMstrResultFlag1 & CMstrResultFlag_ Then
                                        
                                        '@表示ﾒｯｾｰｼﾞ変換
                                        '@「"<TRM1BI>$$ロット[%1]は移載予約されています。"」のﾒｯｾｰｼﾞ表示
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001B, lstrRLotID)
                                        Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                    End If
                                    
                                    '@ﾒｯｾｰｼﾞの初期化
                                    pstrDMsg = vbNullString
                                    
                                    '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ構造体初期化
                                    With ptypLotAction
                                        .lnglstCnt = 1
                                        If IsNothing(.typLotActList) Then
                                            .typLotActList = New List(Of LotActList)()
                                        Else
                                            .typLotActList.Clear()
                                        End If
                                        .typLotActList.Add(New LotActList())
                                    End With
                                    
                                    '@処理結果ﾌﾗｸﾞの1の位が「1：ｱｸｼｮﾝ予約停止」の場合
                                    If lstrResultFlag Like CMstrResultFlag_ & CMstrResultFlag1 = True Then
                                        
                                        '@表示ﾒｯｾｰｼﾞ変換
                                        '@「"アクション予約によりロット[%1] は [停止] されました。"」
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrActionInfo, lstrRLotID, CPstrStopSt)
                                        
                                        '@ｱｸｼｮﾝ予約実行ﾌﾗｸﾞに"1：停止"をｾｯﾄ
                                        ptypLotAction.strActionFlag = CPstrActionFlag1
                                    
                                    Else
                                        '@処理結果ﾌﾗｸﾞの1の位が「1：ｱｸｼｮﾝ予約停止」以外の場合
                                    
                                        '@処理結果ﾌﾗｸﾞの1の位が「2：ｱｸｼｮﾝ予約保留」の場合
                                        If lstrResultFlag Like CMstrResultFlag_ & CMstrResultFlag2 = True Then
                                            
                                            '@表示ﾒｯｾｰｼﾞ変換
                                            '@「"アクション予約によりロット[%1] は [保留] されました。"」
                                            pstrDMsg = pubstrMsgReplace_Set(CPstrActionInfo, lstrRLotID, CPstrHoldSt)
                                         
                                            '@ｱｸｼｮﾝ予約実行ﾌﾗｸﾞに"2：保留"をｾｯﾄ
                                            ptypLotAction.strActionFlag = CPstrActionFlag2
                                        End If
                                    End If
                                                                
                                    '@ｱｸｼｮﾝ予約の停止、保留ﾒｯｾｰｼﾞがあるか
                                    If pstrDMsg <> vbNullString Then
                                        
                                        '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ構造体設定
                                        ptypLotAction.lnglstCnt = 1
                                        Dim tmpLotActList As LotActList = ptypLotAction.typLotActList(ptypLotAction.lnglstCnt-1)
                                        tmpLotActList.strMessage = pstrDMsg
                                        
                                        '@ｱｸｼｮﾝ予約ﾘｽﾄがなくなるまで
                                        For llngACnt = 0 To mlngActCnt - 1
                                            
                                            '@ﾛｯﾄIDが同じ場合
                                            If mtypLotActList(llngACnt).strLotID = lstrRLotID Then
                                                
                                                tmpLotActList.strLotID = mtypLotActList(llngACnt).strLotID
                                                tmpLotActList.strFlowClass = mtypLotActList(llngACnt).strFlowClass
                                                tmpLotActList.strLotActionID = mtypLotActList(llngACnt).strLotActionID
                                                tmpLotActList.strLotActionTypeID = mtypLotActList(llngACnt).strLotActionTypeID
                                                tmpLotActList.strLotActionTypeName = mtypLotActList(llngACnt).strLotActionTypeName
                                                tmpLotActList.strActionTrigger = mtypLotActList(llngACnt).strActionTrigger
                                                tmpLotActList.strOpID = mtypLotActList(llngACnt).strOpID
                                                tmpLotActList.strStepID = mtypLotActList(llngACnt).strStepID
                                                tmpLotActList.strWorkDirectionID = mtypLotActList(llngACnt).strWorkDirectionID
                                                Exit For
                                                
                                            End If
                                        Next llngACnt
                                        ptypLotAction.typLotActList(ptypLotAction.lnglstCnt-1) = tmpLotActList

                                    
                                        '@ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ画面名称設定
                                        frmxxCM0040.Instance.Text = CPstrSubDispTitleActionInfo
                                        
                                        '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                                        '@ ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ表示画面　表示処理(ptypLotActionの情報でｱｸｼｮﾝ予約の内容を表示)
                                        '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                                        frmxxCM0040.Instance.ShowDialog(Me)
                                        frmxxCM0040.Instance = Nothing

                                    End If
                                End If
                            End If
                        Next llngCnt
                    End With
                End If
                    

				'kkw-----------------------------------------------------------------------------------------------------------
				'蒸着後流動予約ロットの次工程送出
				If pstrSBID = CPstrSBID2A0 And lblnAfterJReserveFlag = True Then
					'何かしら蒸着後流動予約処理(分割、統合、ｷｬﾘｱ統合)が行われたロットの次工程送出を行う

					'処理予定ロットリスト
					Dim typTodoLotId As New List(Of String)
					' 重複排除前提でSetを使う
					Dim doneSet As New HashSet(Of String)
					Dim todoSet As New HashSet(Of String)

					'統合処理が行われた元ロットIDのみ処理済みロットへ格納する(ロットIDが存在しない可能性があるため)
					For Each item In mtypCombineLot
						doneSet.Add(item.strLotId)
					Next

					'ｷｬﾘｱ交換済みのロットを処理予定リストに入れる(統合済みに含まれないロット）
					For Each item In mtypCarrierMoveLot
						If Not doneSet.Contains(item.strLotId) Then
							todoSet.Add(item.strLotId)
						End If
					Next

					'統合後のロットを処理予定ロットリストに入れる(統合済みに含まれないロット）
					For Each item In mtypCombineLot
						If Not doneSet.Contains(item.strCombineLotId) Then
							todoSet.Add(item.strCombineLotId)
						End If
					Next

					'分割後のロットを処理予定ロットリストに入れる(統合済みに含まれないロット）
					For Each item In mtypDivideLot
						If Not doneSet.Contains(item.strLotId) Then
							todoSet.Add(item.strLotId)
						End If
						If Not doneSet.Contains(item.strDivideLotId) Then
							todoSet.Add(item.strDivideLotId)
						End If
					Next

					'処理済みリストに入れる(統合済みに含まれないロット）
					'予約情報はあるが、分割、統合、ｷｬﾘｱ交換がされていないロット用（予約情報が揃っていないのに確認なしで次工程送出されないように）
					For Each item In mtypAJRLot
						If Not doneSet.Contains(item) Then
							todoSet.Add(item)
						End If
					Next

					' 最後にList化
					typTodoLotId = todoSet.ToList()

					'@「送出あり」にﾁｪｯｸが付いているか
					If optLotNextSend0.Checked = True Then

						For llngCnt = 0 To typTodoLotId.Count - 1 
							Dim lstrLotId As String
							Dim lstrLotLastUpdate As String
							Dim ltypLotCurState As Lotprestate
							Dim ltypLotNextStep As LotNextStep
							Dim lstrCompleteChk	As String
							lstrLotId = typTodoLotId(llngCnt)
							
							If lstrLotId <> vbNullString Then


								lblnAns =  pubblnAfterJReserveCompleteChk(CMstrlot_afterjrsvcompletechkVer, lstrLotId, lstrCompleteChk)
								If lblnAns = True Then
									'蒸着後流動予約処理が完了していない場合(グループ内のWF全てが揃っていない場合）
									'斜方蒸着ではない場合などはlstrCompleteChkが1で返ってくる
									'ユーザーへ確認ﾒｯｾｰｼﾞ
									If lstrCompleteChk = CPstrFlagOff Then
										'@表示ﾒｯｾｰｼﾞ変換
										'@「"<TRM198W>$$ロット[%1]は、蒸着後流動予約されています。$予約WFが揃っていないまま次工程送出しますか？"」のﾒｯｾｰｼﾞ表示
										pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0198, lstrLotId)
										llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16, False)


										'@ 「いいえ」なら次のロットの処理を行う
										If llngMsgAns = vbNo Then
											'@表示ﾒｯｾｰｼﾞ変換
											'@「"<TRM0LI>$$バッチ作業終了しました。キャリア[%1]"」
											pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000L, lstrLotId)
											'@ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰに表示
											Call pubVsfInfo_Disp(pstrDMsg)
											Continue For
										End If

									End If

								Else
									Continue For
								End If

								'ロット現在状態取得
								'@最終更新日時取得(統合や分割が行われている可能性があるためここで改めて取得する)
								'@DBからﾛｯﾄ情報の取得
								 lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, CPstrCD02, "", ltypLotCurState, lstrLotId)
								If lblnAns = True Then
									
									lstrLotLastUpdate = ltypLotCurState.strLotLastUpdate

									'@=======================
									'@ ﾛｯﾄ次工程取得
									'@=======================
									lblnAns = pubblnLotNextStepList_Sel(CMstrlot_nextsteplistVer, _
																	lstrLotId, _
																	ltypLotCurState.strOpID, _
																	ltypLotCurState.strStepID, _
																	ltypLotNextStep)
									If lblnAns = True Then
	

										'@各種変数を初期化
										llngBatchFlag = CMlngBatchWorkEnd           'ﾊﾞｯﾁ作業終了ﾌﾗｸﾞ(初期化:正常処理)
										lstrErrorMsg = vbNullString                 'ﾊﾞｯﾁ作業終了ｴﾗｰﾒｯｾｰｼﾞ
                                    
										'@-----------------------
										'@ 次工程送出処理の処理区分設定
										'@-----------------------
										'@次大工程があるか
										If ltypLotNextStep.strNextStepList(0).strNextOpId <> vbNullString Then
                                        
											 '@ある場合、処理区分に"NULL：次工程送出"をｾｯﾄ
											lstrClassDivision = vbNullString
										Else
											'@ない場合、処理区分に"24：流動完了"をｾｯﾄ
											lstrClassDivision = CPstrCD24
										End If
            
            
										'@-----------------------
										'@ 分割ﾁｪｯｸ判定
										'@-----------------------
										'@ﾛｯﾄ分割ﾁｪｯｸの有効／無効化 → 最終工程の場合のみ有効化
										'@処理区分が"24：流動完了"か
										If lstrClassDivision = CPstrCD24 Then
                                        
											'@分割ﾁｪｯｸﾌﾗｸﾞに"1：分割ﾁｪｯｸする"をｾｯﾄ
											lstrDividedCheckFlag = CPstrOne
										Else
											'@分割ﾁｪｯｸﾌﾗｸﾞに"0：分割ﾁｪｯｸしない"をｾｯﾄ
											lstrDividedCheckFlag = CPstrZero
										End If
            
            
										'@-----------------------
										'@ 量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
										'@-----------------------
										'@起動SBが組立か
										If pstrSBID = CPstrSBID2A0 Then
											'@2A0：組立の場合
                
											'@=======================
											'@ 量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
											'@=======================
											'@【量産ｵｰﾀﾞｰ振替ﾁｪｯｸ】ﾒｯｾｰｼﾞ送受信処理
											lblnChkChangeOrderAns = pubblnLotChkChgOrder_Chk(CMstrlot_chkchangeorderVer, _
																							lstrLotId, _
																							lstrGuidMsg, _
																							lstrGuidMsgCode)
                
											'@量産ｵｰﾀﾞｰ振替ﾁｪｯｸ結果が"True：ﾁｪｯｸ処理成功"か
											If lblnChkChangeOrderAns = True Then
                
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
											End If
										End If
            
                                    
										'@=======================
										'@ ﾛｯﾄ次工程送出(1回目)
										'@=======================
										lblnAns = pubblnLotNextSend_Upd(CMstrlot_nextSendVer _
																	   , lstrLotId _
																	   , lstrLotLastUpdate _
																	   , pstrUserID _
																	   , lstrDividedCheckFlag _
																	   , lstrClassDivision _
																	   , llngBatchFlag _
																	   , lstrErrorMsg _
																	   , lstrErrorCode _
																	   , lstrActionFlag _
																	   , _
																	   , lstrSendResult)
                                    
										'@1回目のﾛｯﾄ次工程送出結果が"True：通信成功"か
										If lblnAns = True Then
            
											'@ﾛｯﾄ次工程送出結果が"9：送品中断"か(要するにﾛｯﾄ分割されている場合⇒ﾕｰｻﾞｰ確認を行います)
											If lstrSendResult = CPstrSendAbort Or lstrSendResult = CPstrSendAbortAJR Then
            
												'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
												Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
												
												If lstrSendResult = CPstrSendAbort Then
													'@表示ﾒｯｾｰｼﾞ変換
													'@「"<TRM9JW>$$ロット[%1]は、ロット分割されています。$ロット分割状態のまま送出しますか？"」のﾒｯｾｰｼﾞ表示
													pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009J, lstrLotId)
													llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16, False)
												Else
													'@表示ﾒｯｾｰｼﾞ変換
													'@「 "<TRM198W>$$ロット[%1]は、蒸着後流動予約WFが揃っていません。$そのまま次工程送出しますか？"」のﾒｯｾｰｼﾞ表示
													pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0198, lstrLotId)
													llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16, False)

													'@「はい」なら次工程送出処理をする

												End If
												'@「はい」なら分割状態で送品する。
												'@ ※DIVIDED_CHECK_FLAG=0(分割ﾁｪｯｸ無し) とし、再度、ﾒｯｾｰｼﾞを発行する。
												'@ 蒸着後流動予約のチェックも飛ばす
												If llngMsgAns = vbYes Then
            
													'@分割ﾁｪｯｸﾌﾗｸﾞに"0：分割ﾁｪｯｸなし"をｾｯﾄ
													lstrDividedCheckFlag = CPstrZero

													
                                                
													'@=======================
													'@ ﾛｯﾄ次工程送出(2回目)　※DIVIDED_CHECK_FLAG=0
													'@=======================
													lblnAns = pubblnLotNextSend_Upd(CMstrlot_nextSendVer _
																				   , lstrLotId _
																				   , lstrLotLastUpdate _
																				   , pstrUserID _
																				   , lstrDividedCheckFlag _
																				   , lstrClassDivision _
																				   , llngBatchFlag _
																				   , lstrErrorMsg _
																				   , lstrErrorCode _
																				   , lstrActionFlag _
																				   , _
																				   , lstrSendResult)
            
													'@2回目のﾛｯﾄ次工程送出結果が"True：通信成功"か
													If lblnAns = True Then
            
														'@次工程送出結果が"NULL：次工程送出"か
														'@ ※0:中間在庫/1:完成在庫/2:組立送品
														If lstrSendResult = vbNullString Then
                                                        
															'@-----------------------
															'@ NULL：次工程送出時のみ処理待ちﾛｯﾄ更新処理を行う
															'@-----------------------
                                                        
															'@***********************
															'@ 送信ﾃﾞｰﾀ作成
															'@***********************
															With ltypCtlUpdWaitingLotList
                                                            
																.strClassDivision = CPstrCD01                                                       '処理区分(=01)
																.strMsgVer = CMstrctl_updwaitinglotVer                                              'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
																.strSbID = pstrSBID                                                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
																.strWpID = vbNullString                                                             'WPID(=vbNullString)
                                                            
																.lngWaitingLotListCnt = 1                                                           'ﾘｽﾄｶｳﾝﾄ(=1)
																If IsNothing(.typWaitingLotList) Then
																	.typWaitingLotList = New List(Of UpWaitingLotList)()
																Else
																	.typWaitingLotList.Clear()
																End If
																Dim tmpUpWaitingLotList As UpWaitingLotList = New UpWaitingLotList()
            
																tmpUpWaitingLotList.strLotID = lstrLotId						'ﾛｯﾄID
            
																tmpUpWaitingLotList.strOpID =   ltypLotCurState.strOpID           '大工程
            
																tmpUpWaitingLotList.strStepID = ltypLotCurState.strStepID         '小工程
            
																tmpUpWaitingLotList.strSeqNum = vbNullString                  '処理順(=vbNullString)
																.typWaitingLotList.Add(tmpUpWaitingLotList)
															End With


															'@=======================
															'@ 処理待ちﾛｯﾄ更新
															'@=======================
															lblnCtlAns = pubblnCtlUpdWaitingLot_Upd(ltypCtlUpdWaitingLotList)
                                                        
															'@処理待ちﾛｯﾄ更新結果が"False：通信失敗"か
															If lblnCtlAns = False Then
                                                            
																'@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"2：ﾊﾞｯﾁ作業終了処理失敗"か
																If llngBatchFlag = CMlngBatchOnError Then
                                                                
																	Exit Sub
																End If
            
																'@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"3：要求処理失敗"か
																If llngBatchFlag = CMlngBatchRequestFail Then
                                                                
																	'@ｴﾗｰﾒｯｾｰｼﾞをまとめて変数に保管(ｴﾗｰ表記：<ErrorCode> ErrorMsg)
																	lstrErrorMsgCal = lstrErrorMsgCal & _
																					  CPstrStartMsgCode & _
																					  lstrErrorCode & _
																					  CPstrEndMsgCode & _
																					  CMstrEnter & _
																					  lstrErrorMsg & _
																					  CMstrEnter
                                                            
																End If
															End If
														End If
            
														'@次大工程がNULL以外(次工程がある)か
														If ltypLotNextStep.strNextStepList(0).strNextOpId <> vbNullString Then
															'@次工程がある場合
                                                        
															'@***********************
															'@ さまざまな結果に従い、ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰに表示
															'@***********************
                                                        
															'@表示ﾒｯｾｰｼﾞ変換
															'@「"<TRM14I>$$作業を終了して、次工程へ送出しました。キャリア[%1] ロット[%2]"」のﾒｯｾｰｼﾞ表示
															pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0014, _
																							ltypLotCurState.strCarrierId, _
																							lstrLotId)
            
															'@成功ﾒｯｾｰｼﾞ表示
															Call pubVsfInfo_Disp(pstrDMsg)
            
															'@表示ﾒｯｾｰｼﾞの初期化
															pstrDMsg = vbNullString
                                                        
															'@★ ｱｸｼｮﾝ予約実行ﾌﾗｸﾞにより処理分岐 ★
															Select Case lstrActionFlag
                                                            
																'@〓 ﾛｯﾄ停止 〓
																Case CPstrActionFlag1
                                                                
																	'@表示ﾒｯｾｰｼﾞ変換
																	'@「"<TRM2SI>$$アクション予約によりロット[ %1 ] は [停止] されました。"」
																	pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, lstrLotId, CPstrStopSt)
                                                            
																'@〓 ﾛｯﾄ保留 〓
																Case CPstrActionFlag2
                                                                
																	'@表示ﾒｯｾｰｼﾞ変換
																	'@「"<TRM2SI>$$アクション予約によりロット[ %1 ] は [保留] されました。"」
																	pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, lstrLotId, CPstrHoldSt)
                                                        
															End Select
            
														Else
															'@次工程がない(流動完了)の場合
                                                        
															'@***********************
															'@ 流動終了のﾒｯｾｰｼﾞを表示する
															'@ ※lstrSendResult：(Null：次工程送出)、(0：中間在庫)、(1：完成在庫)、(2：組立送品)
															'@***********************
                                                        
															'@=======================
															'@ 次工程送出ﾒｯｾｰｼﾞ送信結果受信時のﾎﾟｯﾌﾟｱｯﾌﾟ表示処理
															'@=======================
															Call pubLotNextSendResultPopUp(lstrSendResult, _
																							ltypLotCurState.strCarrierId, _
																							lstrLotId)
                                                        
															'@ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰにﾒｯｾｰｼﾞ表示
															Call pubVsfInfo_Disp(pstrDMsg)
            
														End If
            
													Else
														'@2回目のﾛｯﾄ次工程送出(分割ﾁｪｯｸなしVer)の結果が"False：通信失敗"の場合
            
														'@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"2：ﾊﾞｯﾁ作業終了処理失敗"か
														If llngBatchFlag = CMlngBatchOnError Then
                                                        
															Exit Sub
														End If
            
														'@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"3：要求処理失敗"か
														If llngBatchFlag = CMlngBatchRequestFail Then
                                                        
															'@ｴﾗｰﾒｯｾｰｼﾞをまとめて変数に保管(ｴﾗｰ表記：<ErrorCode> ErrorMsg)
															lstrErrorMsgCal = lstrErrorMsgCal & _
																			  CPstrStartMsgCode & _
																			  lstrErrorCode & _
																			  CPstrEndMsgCode & _
																			  CMstrEnter & _
																			  lstrErrorMsg & _
																			  CMstrEnter
                                                    
														End If
													End If
            
												Else
													'@「"<TRM9JW>$$ロット[%1]は、ロット分割されています。$ロット分割状態のまま送出しますか？"」のﾒｯｾｰｼﾞで、
													'@「いいえ」が選択された場合
													'@　→他のﾛｯﾄもある筈なので、ひとまず、対象ロットの送出処理を実施せずに次のﾛｯﾄのﾙｰﾌﾟに移行する。
                                                
													'@処理なし
            
												End If
            
											Else
												'@「送品中断」以外の場合(要するにﾛｯﾄが分割されていなく、ﾕｰｻﾞｰ確認が必要ない場合)
            
												'@次工程送出結果が"NULL：次工程送出"か
												'@ ※0:中間在庫/1:完成在庫/2:組立送品
												If lstrSendResult = vbNullString Then
                                                
													'@-----------------------
													'@ NULL：次工程送出時のみ処理待ちﾛｯﾄ更新処理を行う
													'@-----------------------
                                                
													'@***********************
													'@ 送信ﾃﾞｰﾀ作成
													'@***********************
													With ltypCtlUpdWaitingLotList
                                                    
														.strClassDivision = CPstrCD01               '処理区分(=01)
														.strMsgVer = CMstrctl_updwaitinglotVer      'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
														.strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
														.strWpID = vbNullString                     'WPID(=vbNullString)
                                                    
														.lngWaitingLotListCnt = 1                   'ﾘｽﾄｶｳﾝﾄ(=1)
														If IsNothing(.typWaitingLotList) Then
															.typWaitingLotList = New List(Of UpWaitingLotList)()
														Else
															.typWaitingLotList.Clear()
														End If
														Dim tmpUpWaitingLotList As UpWaitingLotList = New UpWaitingLotList()
            
														tmpUpWaitingLotList.strLotID = lstrLotId        'ﾛｯﾄID
            
														tmpUpWaitingLotList.strOpID =  ltypLotCurState.strOpID          '大工程
            
														tmpUpWaitingLotList.strStepID = ltypLotCurState.strStepID          '小工程
            
														tmpUpWaitingLotList.strSeqNum = vbNullString  '処理順(=vbNullString)
														.typWaitingLotList.Add(tmpUpWaitingLotList)
													End With


													'@=======================
													'@ 処理待ちﾛｯﾄ更新
													'@=======================
													lblnCtlAns = pubblnCtlUpdWaitingLot_Upd(ltypCtlUpdWaitingLotList)
                                                
													'@処理待ちﾛｯﾄ更新結果が"False：通信失敗"か
													If lblnCtlAns = False Then
                                                    
														'@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"2：ﾊﾞｯﾁ作業終了処理失敗"か
														If llngBatchFlag = CMlngBatchOnError Then
                                                        
															'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
															Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
															Exit Sub
														End If
            
														'@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"3：要求処理失敗"か
														If llngBatchFlag = CMlngBatchRequestFail Then
                                                        
															'@ｴﾗｰﾒｯｾｰｼﾞをまとめて変数に保管(ｴﾗｰ表記：<ErrorCode> ErrorMsg)
															lstrErrorMsgCal = lstrErrorMsgCal & _
																			  CPstrStartMsgCode & _
																			  lstrErrorCode & _
																			  CPstrEndMsgCode & _
																			  CMstrEnter & _
																			  lstrErrorMsg & _
																			  CMstrEnter
                                                    
														End If
													End If
												End If
            
												'@次大工程がNULL以外(次工程がある)か
												If ltypLotNextStep.strNextStepList(0).strNextOpId <> vbNullString Then
													'@次工程がある場合
                                                
													'@***********************
													'@ さまざまな結果に従い、ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰに表示
													'@***********************
                                                
													'@表示ﾒｯｾｰｼﾞ変換
													'@「"<TRM14I>$$作業を終了して、次工程へ送出しました。キャリア[%1] ロット[%2]"」のﾒｯｾｰｼﾞ表示
													pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0014, _
																					ltypLotCurState.strCarrierId, _
																					lstrLotId)
            
													'@成功ﾒｯｾｰｼﾞ表示
													Call pubVsfInfo_Disp(pstrDMsg)
            
													'@表示ﾒｯｾｰｼﾞの初期化
													pstrDMsg = vbNullString
                                                
													'@★ ｱｸｼｮﾝ予約実行ﾌﾗｸﾞにより処理分岐 ★
													Select Case lstrActionFlag
                                                    
														'@〓 ﾛｯﾄ停止 〓
														Case CPstrActionFlag1
                                                        
															'@表示ﾒｯｾｰｼﾞ変換
															'@「"<TRM2SI>$$アクション予約によりロット[ %1 ] は [停止] されました。"」
															pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, lstrLotId, CPstrStopSt)
                                                    
														'@〓 ﾛｯﾄ保留 〓
														Case CPstrActionFlag2
                                                        
															'@表示ﾒｯｾｰｼﾞ変換
															'@「"<TRM2SI>$$アクション予約によりロット[ %1 ] は [保留] されました。"」
															pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, lstrLotId, CPstrHoldSt)
                                                
													End Select
												Else
													'@次工程がない(流動完了)の場合
                                                
													'@***********************
													'@ 流動終了のﾒｯｾｰｼﾞを表示する
													'@ ※lstrSendResult：(Null：次工程送出)、(0：中間在庫)、(1：完成在庫)、(2：組立送品)
													'@***********************
            
													'@=======================
													'@ 次工程送出ﾒｯｾｰｼﾞ送信結果受信時のﾎﾟｯﾌﾟｱｯﾌﾟ表示処理
													'@=======================
													Call pubLotNextSendResultPopUp(lstrSendResult, ltypLotCurState.strCarrierId, lstrLotId)
                                                
													'@ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰにﾒｯｾｰｼﾞ表示
													Call pubVsfInfo_Disp(pstrDMsg)
            
												End If
											End If
            
										Else
											'@1回目のﾛｯﾄ次工程送出結果が"False：通信失敗"か
                                        
											'@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"2：ﾊﾞｯﾁ作業終了処理失敗"か
											If llngBatchFlag = CMlngBatchOnError Then
                                            
												'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
												Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
												Exit Sub
											End If
            
											'@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞが"3：要求処理失敗"か
											If llngBatchFlag = CMlngBatchRequestFail Then
                                            
												'@ｴﾗｰﾒｯｾｰｼﾞをまとめて変数に保管(ｴﾗｰ表記：<ErrorCode> ErrorMsg)
												lstrErrorMsgCal = lstrErrorMsgCal & _
																  CPstrStartMsgCode & _
																  lstrErrorCode & _
																  CPstrEndMsgCode & _
																  CMstrEnter & _
																  lstrErrorMsg & _
																  CMstrEnter
                                        
											End If
										End If

									End If
								End If
							End If
						Next

					Else

					End If
				End If

                '@ｷｬﾘｱIDのｸﾘｱ
                txtCarrier.Text = vbNullString
                
                '@=======================
                '@ 画面情報初期化処理
                '@=======================
                Call prvFrmxxEN00K0_Init()

            Else
                '@ﾊﾞｯﾁ作業終了結果が"False：通信失敗"の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
            End If
            
            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvFrmxxEN00K0_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Mon) 17:35:28 S.Deguchi
    '更新日：2009/06/25 (Thu) 13:37:41 N.Kojima
    '備　考：
    '　　　：2004/08/27 (Fri) 10:59:44 S.Deguchi    異常処理票登録画面へ遷移するﾎﾞﾀﾝ処理を追加
    '　　　：2004/08/27 (Fri) 16:32:52 M.Miura      次工程自動送出ｺﾝﾎﾞをｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝに変更
    '　　　：2004/10/04 (Mon) 13:16:29 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2009/06/25 (Thu) 13:37:41 N.Kojima     無機対応。(案件№03560)
    Private Sub prvFrmxxEN00K0_Init()

        Dim llngNowByte         As Integer          '現在のﾊﾞｲﾄ数格納
        Dim lstrFormTitle       As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@=======================
            '@ 機能毎関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00K0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle

            '@ﾓｼﾞｭｰﾙ変数の初期化
            mstrCarrier = vbNullString                      'ｷｬﾘｱID
            mlngSideScrollFlag = 0                          '横ｽｸﾛｰﾙの使用ﾌﾗｸﾞ(1:発生/2:不要)
            mstrWpID = vbNullString                         '装置ID
            mlngActCnt = 0                                  'ｱｸｼｮﾝ予約ｶｳﾝﾀ
            Erase mtypLotActList                            'ｱｸｼｮﾝ予約ﾘｽﾄ
            mtypLotNextStep.lngNextStepListCnt = 0          'ﾛｯﾄ次工程情報ﾘｽﾄｶｳﾝﾀ
            'ﾛｯﾄ次工程情報ﾘｽﾄ
            If IsNothing(mtypLotNextStep.strNextStepList) Then
                mtypLotNextStep.strNextStepList = New List(Of NextStep)()
            Else
                mtypLotNextStep.strNextStepList.Clear()
            End If



            '蒸着流動予約処理済みロット情報
			 If IsNothing(mtypAJRLot) Then
                mtypAJRLot= New List(Of String)()
            Else
                mtypAJRLot.Clear()
            End If

            If IsNothing(mtypDivideLot) Then
                mtypDivideLot= New List(Of typDivideLot)()
            Else
                mtypDivideLot.Clear()
            End If

			 If IsNothing(mtypCombineLot) Then
                mtypCombineLot= New List(Of typCombineLot)()
            Else
                mtypCombineLot.Clear()
            End If

			If IsNothing(mtypCarrierMoveLot) Then
                mtypCarrierMoveLot= New List(Of typCarrierMoveLot)()
            Else
                mtypCarrierMoveLot.Clear()
            End If

        '@↓ '09/07/02（Thu）11:07:22 K.Nishizawa ***************************************
            mstrResult = CPstrZero                          '簡易統合ﾁｪｯｸ
        '@↑ '09/07/02（Thu）11:07:22 K.Nishizawa ***************************************

            '@-----------------------
            '@ ﾍｯﾀﾞｰ情報の初期化
            '@-----------------------
            '@各種ﾗﾍﾞﾙの初期化
            lblLotStatus.Text = vbNullString             '状態
            lblWpName.Text = vbNullString                '装置
            lblRecipe.Text = vbNullString                'ﾚｼﾋﾟ
            lblBatID.Text = vbNullString                 'ﾊﾞｯﾁID
            lblLotNum.Text = vbNullString                'ﾊﾞｯﾁ数

            
            '@-----------------------
            '@ 作業ﾒﾓ関連の初期化
            '@-----------------------
            With txtWorkMemo
                
                '@各種ﾌﾟﾛﾊﾟﾃｨ設定
                .ChrMaxByte = CPlngLotCommentsMaxByte   '最大文字数：2048Byte
                .Text = vbNullString                    'ﾃｷｽﾄ：NULL
                
                '@=======================
                '@ 現状のﾊﾞｲﾄ数を格納し、現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                '@=======================
                llngNowByte = .NowByte
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)

                .Enabled = False                        '無効
            End With
            
            '@作業ﾒﾓの上下ｽｸﾛｰﾙﾎﾞﾀﾝの初期化
            cmdMemoUp.Enabled = False                   '▲(上)：無効
            cmdMemoDown.Enabled = False                 '▼(下)：無効
            
            
            '@-----------------------
            '@ ﾛｯﾄｺﾒﾝﾄ関連の初期化
            '@-----------------------
            '@ﾛｯﾄｺﾒﾝﾄ表示
            lblCarrierC.Text = CMstrCarrierIDTitle & Space(6)    'ｺﾒﾝﾄ-ｷｬﾘｱID

            With txtLotCommnt

                '@各種ﾌﾟﾛﾊﾟﾃｨの初期化
                .ChrMaxByte = CPlngLotCommentsMaxByte     '最大文字数：2048Byte
                .Text = vbNullString                      'ﾃｷｽﾄ：NULL
                .BackColor = SystemColors.ControlLight    '背景色：ｸﾞﾚｰ
                .GotBackColor = SystemColors.ControlLight 'ﾌｫｰｶｽ取得時背景色：ｸﾞﾚｰ
                .Locked = True                            'ﾛｯｸ：ﾛｯｸする
            End With
            
            cmdTxtUp.Enabled = False                    '▲(上)：無効
            cmdTxtDown.Enabled = False                  '▼(下)：無効


            '@-----------------------
            '@ ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞの初期化
            '@-----------------------
            Call prvVsfBatList_Init()
            
            cmdUP.Enabled = False                       '▲(上)：無効
            cmdDown.Enabled = False                     '▼(下)：無効
            cmdLeft.Enabled = False                     '<<(左)：無効
            cmdRight.Enabled = False                    '>>(右)：無効
            
            
            '@-----------------------
            '@ 次工程情報ｸﾞﾘｯﾄﾞの初期化
            '@-----------------------
            Call prvVsfNextStepInfo_Init()

            cmdNextUP.Enabled = False                   '▲(上)：無効
            cmdNextDown.Enabled = False                 '▼(下)：無効


            '@-----------------------
            '@ 各種ﾎﾞﾀﾝの初期化
            '@-----------------------
            cmdActionDisp.Enabled = False               'ｱｸｼｮﾝ予約確認
            cmdCommntInput.Enabled = False              'ﾛｯﾄｺﾒﾝﾄ
            cmdCollectionInfo.Enabled = False           '装置ﾃﾞｰﾀ登録/参照
            cmdTrouble.Enabled = False                  '異常処理票登録
            cmdTreatWF.Enabled = False                  'WF処置登録
            cmdRegist.Enabled = False                   '確定
            cmdWorkRecord.Enabled = False               '作業記録


            '@-----------------------
            '@ ｵﾌﾟｼｮﾝﾎﾞﾀﾝの初期化
            '@-----------------------
            '@ﾁｪｯｸなし
            optLotNextSend0.Checked = False          '「送出あり」ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optLotNextSend1.Checked = False          '「送出なし」ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            
            '@無効
            optLotNextSend0.Enabled = False        '「送出あり」ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optLotNextSend1.Enabled = False        '「送出なし」ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN00K0_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxEN00K0_Disp
    '機　能：画面情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Wed) 13:14:41 S.Deguchi
    '更新日：2009/06/25 (Thu) 14:16:47 N.Kojima
    '備　考：
    '　　　：2006/03/28 (Tue) 10:34:34 N.Kojima     引継ぎﾊﾞｸﾞ改修の為、時間制限の格納構造体を変更。(不具合№3444関連)
    '　　　：2009/06/25 (Thu) 14:16:47 N.Kojima     無機対応。(案件№03560)
    Private Sub prvFrmxxEN00K0_Disp()
        
        Dim llngLoopCnt         As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngCnt             As Integer      'ﾊﾞｯﾁ数
        Dim lblnMoveCompFlag    As Boolean      '行移動完了ﾌﾗｸﾞ(True：行移動完了、False：行移動未完了)

        Try
            
            '@ﾊﾞｯﾁ組ﾛｯﾄ情報取得でﾃﾞｰﾀがあったか
            If mtypBatLotList.lngBatLotCnt > 0 Then
                '@1件以上あった場合
                
                '@ﾊﾞｯﾁ数を格納
                llngCnt = mtypBatLotList.lngBatLotCnt - 1
            
                '@共通項目をﾗﾍﾞﾙに設定する
                lblBatID.Text = mtypBatLotList.typBatLot(llngCnt).strBatchId                                'ﾊﾞｯﾁID
                lblWpName.Text = mtypBatLotList.typBatLot(llngCnt).strWpName                                '装置名
                lblRecipe.Text = mtypBatLotList.typBatLot(llngCnt).strRecipeId                              'ﾚｼﾋﾟID
        '        lblLotNum.Caption = mtypBatLotList.typBatLot(llngCnt).lngBatLotListCnt                         'ﾛｯﾄ数
                
                '@退避領域に装置IDを格納
                mstrWpID = mtypBatLotList.typBatLot(llngCnt).strWpID                                           '装置ID
                
                '@行移動完了ﾌﾗｸﾞの初期化
                lblnMoveCompFlag = False
                
                '@-----------------------
                '@ ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ
                '@-----------------------
                With vsfBatList
                    
                    '@入力されたｷｬﾘｱIDをﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞから探す
                    For llngLoopCnt = 1 To .Rows.Count - 1
                        
                        '@入力されたｷｬﾘｱと同じで、かつ行移動完了ﾌﾗｸﾞが"False：行移動未完了"か
                        If .GetData(llngLoopCnt, CMlngvsfColCarrierID) = txtCarrier.Text And _
                            lblnMoveCompFlag = False Then
                            
                            '@先頭へ持っていく
                            .TopRow = llngLoopCnt
                            
                            '@状態を表示
                            lblLotStatus.Text = mtypBatLotList.typBatLot(llngCnt).typBatList(llngLoopCnt-1).strCurrentStatusName
                            
                            '@選択状態にする
                            .Row = llngLoopCnt
                            '.Select(llngLoopCnt, CMlngVsfColTitle, llngLoopCnt, .Cols.Count - 1)
                            
                            '@-----------------------
                            '@ ｽｸﾛｰﾙﾎﾞﾀﾝの設定
                            '@-----------------------
                            '@=======================
                            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            Call pubVsfBeforeSort(vsfBatList, CMlngvsfColCarrierID)
                            
                            '@=======================
                            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            Call pubVsfAfterSort(vsfBatList, CMlngvsfColCarrierID, cmdUP, cmdDown, False, False, False, False)
                        
                            '@行移動完了ﾌﾗｸﾞに"True：行移動完了"をｾｯﾄ
                            lblnMoveCompFlag = True
                        
                        End If
                        
                        '@=======================
                        '@ ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ選択時処理
                        '@=======================
                        Call vsfBatList_EnterCell(vsfBatList, New EventArgs())
                        
                    Next llngLoopCnt

                    .Redraw = True
                    If .Rows.Count > .Rows.Fixed Then
                        .Enabled = True
                    End If

                End With
                

                '@-----------------------
                '@ 次工程情報ｸﾞﾘｯﾄﾞ
                '@-----------------------
                With vsfNextStepInfo
                    
                    '@***********************
                    '@ 次工程情報ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙﾎﾞﾀﾝ制御
                    '@***********************
                    '@上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ
                    cmdNextUP.SetBounds( .Left + .Width, _
                                .Top -1, _
                                CMlngScrollButtonSize, _
                                CMlngScrollButtonSize)
                    
                    '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ
                    cmdNextDown.SetBounds( .Left + .Width, _
                                .Top + .Height - CMlngScrollButtonSize +1, _
                                CMlngScrollButtonSize, _
                                CMlngScrollButtonSize)
                    
                    '@=======================
                    '@ 上下ｽｸﾛｰﾙﾎﾞﾀﾝ制御処理(ｸﾞﾘｯﾄﾞ共通化関数)
                    '@=======================
                    Call pubVsfDisp(vsfNextStepInfo, cmdNextUP, cmdNextDown)
                End With
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN00K0_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfBatList_Init
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Mon) 17:48:06 S.Deguchi
    '更新日：2016/03/22 (Tue) 12:51:26 T.Oide
    '備　考：
    '　　　：2006/03/28 (Tue) 18:48:30 N.Kojima     ﾛｯﾄｺﾒﾝﾄ画面引継ぎ用の時間制限Col追加に伴う修正。(不具合№3444関連)
    '　　　：2008/06/16 (Mon) 15:29:42 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/06/25 (Thu) 13:48:34 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/16 (Thu) 15:25:27 N.Kojima     無機対応Phase2、非表示列設定を追加。(案件№03661)
    Private Sub prvVsfBatList_Init()

        Try

            '@-----------------------
            '@ ﾊﾞｯﾁ組情報一覧の初期設定(各ｶﾗﾑの幅、ﾀｲﾄﾙを設定 etc...)
            '@-----------------------
            With vsfBatList

                .Redraw = False
                '.Clear()                             'ｸﾘｱ
                .AllowSorting = AllowSortingEnum.None 'ｿｰﾄ：不可
                .Rows.Count = CMlngGridFixedRows      '初期行数：1
                
                '@ﾀｲﾄﾙ行の文字色、背景色の設定
                '.Select(CMlngVsfRowTitle, CMlngvsfColNo, CMlngVsfRowTitle, .Cols.Count - 1)
                'NSYS スタイルを変数に設定
                Dim lFixedlStyle As CellStyle = .Styles.Fixed 
                lFixedlStyle.ForeColor = Color.Yellow                               '文字色
                lFixedlStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)  '背景色
                'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                lFixedlStyle.Font = New Font(lFixedlStyle.Font.FontFamily, CType(CMlngVsfHFontSize,Single), lFixedlStyle.Font.Style, lFixedlStyle.Font.Unit) 
                lFixedlStyle.TextAlign = TextAlignEnum.CenterCenter                 '文字位置
                lFixedlStyle.Trimming = StringTrimming.None                         'NSYS ヘッダ行省略表示なし

                '@列幅の設定
                .Cols(CMlngvsfColNo).Width = CMlngvsfWColNo                                                   '順序
                .Cols(CMlngvsfColCarrierID).Width = CMlngvsfWcolCarrierID                                     'ｷｬﾘｱID
                .Cols(CMlngvsfColUldCarrierID).Width = CMlngvsfWColUldCarrierID                               'ULDｷｬﾘｱID
                .Cols(CMlngvsfColLotID).Width = CMlngvsfWColLotID                                             'ﾛｯﾄID
                .Cols(CMlngvsfColStatus).Width = CMlngvsfWColStatus                                           'ﾛｯﾄ状態
                .Cols(CMlngvsfColFlowClass).Width = CMlngvsfWcolFlowClass                                     '種別
                .Cols(CMlngvsfColPDID).Width = CMlngvsfWColPDID                                               '機種
                .Cols(CMlngvsfColOpID).Width = CMlngvsfWColOpID                                               '大工程
                .Cols(CMlngvsfColStepID).Width = CMlngvsfWColStepID                                           '小工程
                .Cols(CMlngvsfColWFID).Width = CMlngvsfWColWFID                                               'WFID(#+2桁(例：#01))
                .Cols(CMlngvsfColWFQuantity).Width = CMlngvsfWColWFQuantity                                   'WF枚数
                .Cols(CMlngvsfColJigID).Width = CMlngvsfWColJigID                                             '冶具ID
                .Cols(CMlngvsfColS).Width = CMlngvsfWColS                                                     '特殊特性
                .Cols(CMlngvsfColTimeLimit).Width = CMlngvsfWColTimeLimit                                     '時間制限
                .Cols(CMlngvsfColLotManager).Width = CMlngvsfWColLotManager                                   'ﾛｯﾄ担当
                .Cols(CMlngvsfColStartDayTime).Width = CMlngvsfWColStartDayTime                               '処理開始日時
                .Cols(CMlngvsfColLotComment).Width = CMlngvsfWColLotComment                                   'ﾛｯﾄｺﾒﾝﾄ
                .Cols(CMlngvsfColLastUpdate).Width = CMlngvsfWColLastUpdate                                   '最終更新日時
                .Cols(CMlngvsfColOptionText).Width = CMlngvsfWColOptionText                                   '作業条件
                .Cols(CMlngvsfColNextOpID).Width = CMlngvsfWColNextOpID                                       '次大工程
                .Cols(CMlngvsfColNextStepID).Width = CMlngvsfWColNextStepID                                   '次小工程
                .Cols(CMlngvsfColResultFlag).Width = CMlngvsfWColResultFlag                                   '処理結果ﾌﾗｸﾞ
                .Cols(CMlngvsfColRealTimeLimit).Width = CMlngvsfWColRealTimeLimit                             '時間制限(実数)
                .Cols(CMlngvsfColRestrictTypeID).Width = CMlngvsfWColRestrictTypeID                           '制限時間ﾀｲﾌﾟID
                .Cols(CMlngvsfColActionFlag).Width = CMlngvsfWColActionFlag                                   'ｱｸｼｮﾝﾌﾗｸﾞ
                .Cols(CMlngvsfColLotKind).Width = CMlngvsfWColLotKind                                         'ﾛｯﾄ区分

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfColNo, CMstrvsfColNo)                          '順序
                .SetData(CMlngVsfRowTitle, CMlngvsfColCarrierID, CMstrvsfColCarrierID)            'ｷｬﾘｱID
                .SetData(CMlngVsfRowTitle, CMlngvsfColUldCarrierID, CMstrvsfColUldCarrierID)      'ULDｷｬﾘｱID
                .SetData(CMlngVsfRowTitle, CMlngvsfColLotID, CMstrvsfColLotID)                    'ﾛｯﾄID
                .SetData(CMlngVsfRowTitle, CMlngvsfColStatus, CMstrvsfColStatus)                  '状態
                .SetData(CMlngVsfRowTitle, CMlngvsfColFlowClass, CMstrvsfColFlowClass)            '種別
                .SetData(CMlngVsfRowTitle, CMlngvsfColPDID, CMstrvsfColPDID)                      '機種
                .SetData(CMlngVsfRowTitle, CMlngvsfColOpID, CMstrvsfColOpID)                      '大工程
                .SetData(CMlngVsfRowTitle, CMlngvsfColStepID, CMstrvsfColStepID)                  '小工程
                .SetData(CMlngVsfRowTitle, CMlngvsfColWFID, CMstrvsfColWFID)                      'WFID(#+2桁(例：#01))
                .SetData(CMlngVsfRowTitle, CMlngvsfColWFQuantity, CMstrvsfColWFQuantity)          'WF枚数
                .SetData(CMlngVsfRowTitle, CMlngvsfColJigID, CMstrvsfColJigID)                    '冶具ID
                .SetData(CMlngVsfRowTitle, CMlngvsfColS, CMstrvsfColS)                            '特殊特性
                .SetData(CMlngVsfRowTitle, CMlngvsfColTimeLimit, CMstrvsfColTimeLimit)            '時間制限
                .SetData(CMlngVsfRowTitle, CMlngvsfColLotManager, CMstrvsfColLotManager)          'ﾛｯﾄ担当
                .SetData(CMlngVsfRowTitle, CMlngvsfColStartDayTime, CMstrvsfColStartDayTime)      '処理開始日時
                .SetData(CMlngVsfRowTitle, CMlngvsfColLotComment, CMstrvsfColLotComment)          'ﾛｯﾄｺﾒﾝﾄ
                .SetData(CMlngVsfRowTitle, CMlngvsfColLastUpdate, CMstrvsfColLastUpdate)          '最終更新日時
                .SetData(CMlngVsfRowTitle, CMlngvsfColOptionText, CMstrvsfColOptionText)          '作業条件
                .SetData(CMlngVsfRowTitle, CMlngvsfColNextOpID, CMstrvsfColNextOpID)              '次大工程
                .SetData(CMlngVsfRowTitle, CMlngvsfColNextStepID, CMstrvsfColNextStepID)          '次小工程
                .SetData(CMlngVsfRowTitle, CMlngvsfColActionFlag, CMstrvsfColActionFlag)          'ｱｸｼｮﾝﾌﾗｸﾞ
                .SetData(CMlngVsfRowTitle, CMlngvsfColLotKind, CMstrvsfColLotKind)                'ﾛｯﾄ区分
                
                '@非表示設定
                .Cols(CMlngvsfColUldCarrierID).Visible = False          'ULDｷｬﾘｱID
                .Cols(CMlngvsfColWFID).Visible = False                  'WFID
                .Cols(CMlngvsfColJigID).Visible = False                 '冶具ID
                .Cols(CMlngvsfColResultFlag).Visible = False            '処理結果ﾌﾗｸﾞ
                .Cols(CMlngvsfColRealTimeLimit).Visible = False         '時間制限(実数)
                .Cols(CMlngvsfColRestrictTypeID).Visible = False        '制限時間ﾀｲﾌﾟID
                .Cols(CMlngvsfColLotKind).Visible = False               'ﾛｯﾄ区分

                '@表示位置の設定
                .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight      '高さ

                .Cols.Frozen = CMlngvsfFrozenCols                           '固定列：3
                .AllowResizing = AllowResizingEnum.Columns                  'ﾏｳｽによる列幅変更：列のみ可
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter  '省略符号(...)表示：する
                .FocusRect = FocusRectEnum.Light                            'ﾌｫｰｶｽ枠のｽﾀｲﾙ：細枠

                '@非表示項目の設定(仮処理)
                .Cols(CMlngvsfColPDID).Visible = False                  '機種:ﾊﾞｰｼﾞｮﾝ
                .Cols(CMlngvsfColStatus).Visible = False                '状態
                .Cols(CMlngvsfColLotComment).Visible = False            'ﾛｯﾄｺﾒﾝﾄ
                .Cols(CMlngvsfColLastUpdate).Visible = False            '最終更新日時
                .Cols(CMlngvsfColNextOpID).Visible = False              '次大工程
                .Cols(CMlngvsfColNextStepID).Visible = False            '次小工程
                .Cols(CMlngvsfColOptionText).Visible = False            '作業条件
                
                '@隠れている項目を表示する
                .LeftCol = CMlngvsfLeftHiddenCols
                .Redraw = True
                '@無効
                .Enabled = False

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfBatList_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfBatList_Disp
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 20:02:51 S.Deguchi
    '更新日：2012/03/12 (Mon) 14:44:48 T.Oide
    '備　考：
    '　　　：2004/09/09 (Thu) 16:18:56 Y.Yamagishi  時間制限を分表示に変更(不具合改善№693)
    '　　　：2006/03/28 (Tue) 10:33:14 N.Kojima     引継ぎﾊﾞｸﾞ改修の為、時間制限の格納構造体を変更。(不具合№3444関連)
    '　　　：2006/05/12 (Fri) 16:19:44 T.Kitagawa   制限時間の表示を分合計から時間と分で分割表示する(#,##0時間 #0分)(ﾕｰｻﾞ要望№0186)
    '　　　：2006/06/13 (Tue) 18:57:40 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/16 (Mon) 15:30:54 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/06/25 (Thu) 14:04:44 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/16 (Thu) 15:29:41 N.Kojima     無機対応Phase2、各種表示追加。(案件№03661)
    '　　　：2012/03/12 (Mon) 09:41:52 T.Oide       無機装置追加対応(REQ-1303)
    '　　　：2012/11/05 (Mon) 14:11:46 T.Oide       R9-04緊急対応(REQ-1384)
    Private Sub prvVsfBatList_Disp()

        Dim lblnAns                 As Boolean          '結果格納
        Dim ltypLotComntInfo        As LotComntInfo     'ﾛｯﾄｺﾒﾝﾄ取得構造体
        Dim llngDoCnt               As Integer          'ｶｳﾝﾄ
        Dim llngCnt                 As Integer          '取得ﾊﾞｯﾁIDのｶｳﾝﾄ数(=1)
        Dim llngCnt2                As Integer          '汎用ｶｳﾝﾀ2
        Dim llngLotCnt              As Integer          'ﾛｯﾄ数
        Dim lstrLimitTimeAns        As String           '時間制限変換用変数(#,##0時間 #0分)
        Dim lstrInfoGetCompLotID    As String           '情報取得済みﾛｯﾄID(同じ情報を2度取得しない対応)
        Dim lstrSearchLotID         As String           '検索ﾛｯﾄID
        Dim llngRowCnt              As Integer          '行ｶｳﾝﾀｰ
        Dim lstrTmpLotId            As String           'ﾛｯﾄID退避用

        Try

            With vsfBatList
                
                '@ﾊﾞｯﾁ組情報ﾃﾞｰﾀが0件か
                If mtypBatLotList.lngBatLotCnt = 0 Then
                    '@0件の場合
                    
                    '@=======================
                    '@ ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞの初期化
                    '@=======================
                    Call prvVsfBatList_Init()
                    
                    '@横ｽｸﾛｰﾙ(左右)ﾎﾞﾀﾝを無効にする
                    cmdLeft.Enabled = False
                    cmdRight.Enabled = False
                    
                    Exit Sub
                Else
                    '@1件以上ある場合
                    
                    '@ﾊﾞｯﾁ組情報数を格納
                    llngCnt = mtypBatLotList.lngBatLotCnt - 1
                    
                    '@ﾊﾞｯﾁ組情報のﾊﾞｯﾁ組ﾛｯﾄ数が0件か
                    If mtypBatLotList.typBatLot(llngCnt).lngBatLotListCnt = 0 Then
                        '@0件の場合
                        
                        '@=======================
                        '@ ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞの初期化
                        '@=======================
                        Call prvVsfBatList_Init()
                        
                        '@横ｽｸﾛｰﾙ(左右)ﾎﾞﾀﾝを無効にする
                        cmdLeft.Enabled = False
                        cmdRight.Enabled = False
                        
                        Exit Sub
                    Else
                        '@1件以上ある場合
                    
                        '@描画ﾛｯｸ
                        .Redraw = False

                        '@変数初期化
                        llngDoCnt = 0       '構造体のｶｳﾝﾀ
                        llngRowCnt = 1      '表示行
                        lstrTmpLotId = vbNullString
                        
                        '@***********************
                        '@ ﾊﾞｯﾁ組情報表示
                        '@
                        '@ - 表面処理でﾛｯﾄIDが前回値と同じ場合は表示ﾙｰﾌﾟをﾊﾟｽする
                        '@ - 表面処理装置のﾊﾞｯﾁ情報をJ_BATCHﾃｰﾌﾞﾙに格納した対応の影響として対応
                        '@
                        '@***********************
                        Dim newStyle_FC_Purple As CellStyle = .Styles.Add("CustomStyle_ForeColor_CPlngVbColorPurple")
                        newStyle_FC_Purple.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)
                        newStyle_FC_Purple.BackColor = .Styles.Normal.BackColor
                        newStyle_FC_Purple.Trimming =  StringTrimming.EllipsisCharacter
                        Dim newStyle_FC_Red As CellStyle = .Styles.Add("CustomStyle_ForeColor_CPlngVbColorRed")
                        newStyle_FC_Red.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)
                        newStyle_FC_Red.BackColor = .Styles.Normal.BackColor
                        newStyle_FC_Red.Trimming =  StringTrimming.EllipsisCharacter
                        Dim newStyle_FC_Black As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbBlack")
                        newStyle_FC_Black.ForeColor = Color.Black
                        newStyle_FC_Black.BackColor = .Styles.Normal.BackColor
                        newStyle_FC_Black.Trimming =  StringTrimming.EllipsisCharacter
                        Dim cellRange As CellRange

                        Do While mtypBatLotList.typBatLot(llngCnt).lngBatLotListCnt > llngDoCnt
                            
                            '@表面処理装置でﾛｯﾄIDが前回値と同じか
                            If lstrTmpLotId = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLotID And _
                               mtypBatLotList.typBatLot(llngCnt).strEqType = CPstrEqTypeHyoumenSyori Then
                            
                                '何もしない
                            
                            Else
                                
                                'バッチ情報を描画する
                                
                                '@行数設定
                                .Rows.Count = llngRowCnt + 1
                                
                                .SetData(llngRowCnt, CMlngvsfColNo, llngRowCnt)                                   '順序
                                
                                .SetData(llngRowCnt, CMlngvsfColCarrierID, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strCarrierId)                  'ｷｬﾘｱID
            
                                .SetData(llngRowCnt, CMlngvsfColUldCarrierID, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strUldCarrierID)               'ULDｷｬﾘｱID
            
                                .SetData(llngRowCnt, CMlngvsfColLotID, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLotID)                      'ﾛｯﾄID
            
                                '@ﾛｯﾄIDがNULLか
                                If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLotID = vbNullString Then
                                    
                                    '@ﾛｯﾄIDがNULLの場合は、ﾀﾞﾐｰ冶具or未使用処理部である為、ｷｬﾘｱID列に"ﾀﾞﾐｰ"or"未使用"をｾｯﾄ
                                    .SetData(llngRowCnt, CMlngvsfColCarrierID, _
                                        mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strWfId)                     'ｷｬﾘｱID(ﾀﾞﾐｰ、未使用処理部用)
                                End If
            
                                .SetData(llngRowCnt, CMlngvsfColStatus, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strCurrentStatusName)          'ﾛｯﾄ状態
                                    
                                .SetData(llngRowCnt, CMlngvsfColFlowClass, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strFlowClass)                  '種別
                                    
                                .SetData(llngRowCnt, CMlngvsfColPDID, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strPdId)                       '機種
                                    
                                .SetData(llngRowCnt, CMlngvsfColOpID, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strOpID)                       '大工程
                                    
                                .SetData(llngRowCnt, CMlngvsfColStepID, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strStepID)                     '小工程
            
                                '@ﾛｯﾄIDがNULL以外か
                                If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLotID <> vbNullString Then
            
                                    .SetData(llngRowCnt, CMlngvsfColWFID, _
                                        CPstrSharp & Strings.Right(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strWfId, 2))    'WFID(#+2桁(例：#01))
                                End If
            
                                .SetData(llngRowCnt, CMlngvsfColWFQuantity, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strWFQuantity)                 'WF枚数
            
                                .SetData(llngRowCnt, CMlngvsfColJigID, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strjigId)                      '冶具ID
            
                                .SetData(llngRowCnt, CMlngvsfColS, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strSpecialFlag)                '特殊特性
                                
                                '@-----------------------
                                '@ 時間制約有無の表示
                                '@-----------------------
                                If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLimitTime <> vbNullString Then

                                    cellRange = .GetCellRange(llngRowCnt, CMlngvsfColTimeLimit, llngRowCnt, CMlngvsfColTimeLimit)
                                    '@時間制約がﾌﾟﾗｽの場合
                                    If CInt(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLimitTime) >= 0 Then
                                        
                                        '@制限時間以下or処理時間制限以下の場合
                                        '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
                                        If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                            mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strRestrictTypeID = CPstrRestrictTypeID3 Then
                                            
                                            '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                            '@制限時間を時間と分で分割表示する
                                            lstrLimitTimeAns = pubstrLimitTime_Set(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLimitTime)
                                            .SetData(llngRowCnt, CMlngvsfColTimeLimit, lstrLimitTimeAns)
                                            
                                            '@警告時間が設定されている場合
                                            If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strWarnTime <> vbNullString Then
                                                
                                                '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                                If CInt(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strWarnTime) < 0 And _
                                                    CInt(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLimitTime) >= 0 Then
                                                    
        '@↓2012/11/05 (Mon) 14:04:15 T.Oide **************************************************
        '@                                            '@ﾌｫﾝﾄｶﾗｰを紫に変更
        '@                                            .Cell(flexcpForeColor, llngDoCnt, CMlngvsfColTimeLimit, llngDoCnt, CMlngvsfColTimeLimit) = CPlngVbColorPurple    '紫色
        '@-------------------------------------------------------------------------------------
                                                    '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                                    cellRange.Style = newStyle_FC_Purple    '紫色
        '@↑2012/11/05 (Mon) 14:04:15 T.Oide **************************************************
                                                Else
        '@↓2012/11/05 (Mon) 14:05:12 T.Oide **************************************************
        '@                                            '@ﾌｫﾝﾄｶﾗｰを黒に変更
        '@                                            .Cell(flexcpForeColor, llngDoCnt, CMlngvsfColTimeLimit, llngDoCnt, CMlngvsfColTimeLimit) = vbBlack              '黒
        '@-------------------------------------------------------------------------------------
                                                    '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                                    cellRange.Style = newStyle_FC_Black              '黒
        '@↑2012/11/05 (Mon) 14:05:12 T.Oide **************************************************
                                                End If
                                            End If
                                        End If
                                        
                                    Else
                                        '@制限時間がﾏｲﾅｽの場合
                                        
        '@↓2012/11/05 (Mon) 14:10:18 T.Oide **************************************************
        '@                                '@ﾌｫﾝﾄｶﾗｰを赤に変更
        '@                                .Cell(flexcpForeColor, llngDoCnt, CMlngvsfColTimeLimit, llngDoCnt, CMlngvsfColTimeLimit) = CPlngVbColorRed    '赤色
        '@-------------------------------------------------------------------------------------
                                        '@ﾌｫﾝﾄｶﾗｰを赤に変更
                                        cellRange.Style = newStyle_FC_Red    '赤色
        '@↑2012/11/05 (Mon) 14:10:18 T.Oide **************************************************
                                        
                                        '@制限時間以下or処理時間制限以下の場合
                                        '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
                                        If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                            mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strRestrictTypeID = CPstrRestrictTypeID3 Then
                                            
                                            '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                            '@制限時間を時間と分で分割表示する
                                            lstrLimitTimeAns = pubstrLimitTime_Set(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLimitTime)
                                            .SetData(llngRowCnt, CMlngvsfColTimeLimit, lstrLimitTimeAns)
                                        End If
                                        
                                        '@制限時間以上の場合
                                        If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strRestrictTypeID = CPstrRestrictTypeID2 Then
                                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,##0)+"分"
                                            
                                            '@制限時間を時間と分で分割表示する
                                            lstrLimitTimeAns = pubstrLimitTime_Set(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLimitTime)
                                            .SetData(llngRowCnt, CMlngvsfColTimeLimit, Replace(lstrLimitTimeAns, CPstrReplaceMinus, vbNullString))
                                        End If
                                    End If
                                End If
            
                                .SetData(llngRowCnt, CMlngvsfColLotManager, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strEngEmpName)                 'ﾛｯﾄ担当
                                
                                If IsDate(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strStartTime) Then
                                    .SetData(llngRowCnt, CMlngvsfColStartDayTime, _
                                        Format(CDate(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strStartTime), _
                                                 CPstrDateFormat))                                                         '処理開始予定日時
                                Else
                                    .SetData(llngRowCnt, CMlngvsfColStartDayTime, _
                                        mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strStartTime)              '処理開始予定日時
                                End If
                                
                                .SetData(llngRowCnt, CMlngvsfColRealTimeLimit, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLimitTime)                  '時間制限(実数)
                                
                                .SetData(llngRowCnt, CMlngvsfColRestrictTypeID, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strRestrictTypeID)             '制限時間ﾀｲﾌﾟID
                                
                                .SetData(llngRowCnt, CMlngvsfColLastUpdate, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLotLastUpdate)              '最終更新日時
                                
                                .SetData(llngRowCnt, CMlngvsfColOptionText, _
                                    mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strOptionText)                 '作業ﾒﾓ
            
            
                                '@ｺﾒﾝﾄ取得前に初期化
                                ltypLotComntInfo.strComments = vbNullString
                                ltypLotComntInfo.strLotLastUpdate = vbNullString
            
                                '@-----------------------
                                '@ ﾀﾞﾐｰ冶具、未使用処理部はﾛｯﾄｺﾒﾝﾄ取得、次工程取得は行わない
                                '@-----------------------
            
                                '@ﾛｯﾄIDがNULL以外か
                                If .GetData(llngRowCnt, CMlngvsfColLotID) <> vbNullString Then
                                    
                                    '@検索用にﾛｯﾄIDを退避(長いので)
                                    lstrSearchLotID = .GetData(llngRowCnt, CMlngvsfColLotID)
                                    
                                    '@情報取得済みﾛｯﾄIDではないか
                                    If InStr(1, lstrInfoGetCompLotID, lstrSearchLotID) = 0 Then
                                    
                                        '@ﾚｽﾎﾟﾝｽ取得開始
                                        Call pubResponseStart(CMstrFormName, CMstrPrvVsfBatListDisp)
                
                                        '@=======================
                                        '@ ﾛｯﾄｺﾒﾝﾄ取得処理
                                        '@=======================
                                        lblnAns = pubblnlotComntInfo_Sel(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strCarrierId, _
                                                                         CMstrlot_comntinfo_Ver, _
                                                                         ltypLotComntInfo)
                                        
                                        '@ﾛｯﾄｺﾒﾝﾄ取得処理結果が"True：通信成功"か
                                        If lblnAns = True Then
                                            '@True：通信成功の場合
                                            
                                            '@ﾚｽﾎﾟﾝｽ取得終了
                                            Call publngResponseEnd(CMstrFormName, CMstrPrvVsfBatListDisp)
                                        
                                            .SetData(llngRowCnt, CMlngvsfColLotComment, _
                                                ltypLotComntInfo.strComments)                                                    'ﾛｯﾄｺﾒﾝﾄ：取得値
                                        Else
                                            'False：通信失敗の場合
                                        
                                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                            Call pubResponseCancel(CMstrFormName, CMstrPrvVsfBatListDisp)
                                        
                                            .SetData(llngRowCnt, CMlngvsfColLotComment, _
                                                vbNullString)                                                                    'ﾛｯﾄｺﾒﾝﾄ：NULL
                                        End If
                
                                        '@ﾛｯﾄ数を+1する
                                        llngLotCnt = llngLotCnt + 1
            
                                    Else
                                        '@取得済みﾛｯﾄの場合
                                        
                                        For llngCnt2 = 1 To .Rows.Count - 1
                                            
                                            '@ﾛｯﾄIDが同じか
                                            If .GetData(llngRowCnt, CMlngvsfColLotID) = _
                                                .GetData(llngCnt2, CMlngvsfColLotID) Then
                                            
                                                '@同じﾛｯﾄIDの取得済みﾛｯﾄｺﾒﾝﾄをｺﾋﾟｰ
                                                .SetData(llngRowCnt, CMlngvsfColLotComment, _
                                                    .GetData(llngCnt2, CMlngvsfColLotComment))
                                                
                                                Exit For
                                            End If
                                        Next llngCnt2
                                    End If
                                    
                                    '@情報取得済みﾛｯﾄIDに情報取得したﾛｯﾄIDを退避(結合して格納していく)
                                    lstrInfoGetCompLotID = lstrInfoGetCompLotID & CPstrSpace & _
                                                            .GetData(llngRowCnt, CMlngvsfColLotID)
            
                                Else
                                    '@ﾛｯﾄIDがNULLの場合(ﾀﾞﾐｰ冶具or未使用処理部)
                                
                                    .SetData(llngRowCnt, CMlngvsfColLotComment, vbNullString)                      'ﾛｯﾄｺﾒﾝﾄ：NULL
                                    .SetData(llngRowCnt, CMlngvsfColNextOpID, vbNullString)                        '次大工程：NULL
                                    .SetData(llngRowCnt, CMlngvsfColNextStepID, vbNullString)                      '次小工程：NULL
                                End If
            
                                '@ｱｸｼｮﾝﾌﾗｸﾞの初期化(NULL)
                                .SetData(llngRowCnt, CMlngvsfColActionFlag, vbNullString)
                                
                                '@処理結果ﾌﾗｸﾞの初期化(NULL)
                                .SetData(llngRowCnt, CMlngvsfColResultFlag, vbNullString)
                                
            
                                '@※参考***********************************
                                '@ ①TFT基板ﾛｯﾄ     ：CF_FLAG=0,LP_FLAG=0
                                '@ ②CF(小板)ﾛｯﾄ    ：CF_FLAG=1,LP_FLAG=0
                                '@ ③CF(大板)ﾛｯﾄ    ：CF_FLAG=1,LP_FLAG=1
                                '@ ④TPALﾛｯﾄ        ：CF_FLAG=2,LP_FLAG=0
                                '@ ⑤その他         ：CF_FLAG=NULL,LP_FLAG=NULL
                                '@※参考***********************************
            
                                '@★ CFﾌﾗｸﾞにより処理分岐 ★
                                Select Case mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strCfFlag
                                
                                    '@〓 0 or NULL：TFT基板ﾛｯﾄ(CFﾛｯﾄandTPALﾛｯﾄ以外) 〓
                                    Case CPstrZero
                                            
                                        '@ﾛｯﾄ区分に"0：TFT"をｾｯﾄ
                                        .SetData(llngRowCnt, CMlngvsfColLotKind, CPstrZero)
                    
                    
                                    '@〓 1：CFﾛｯﾄ(小板、大板) 〓
                                    Case CPstrOne
                                        
                                        '@★★ LPﾌﾗｸﾞにより処理分岐 ★★
                                        Select Case mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLpFlag
                                            
                                            '@〓〓 0：CFﾛｯﾄ(小板) 〓〓
                                            Case CPstrZero
            
                                                '@ﾛｯﾄ区分に"1：CF(小板)"をｾｯﾄ
                                                .SetData(llngRowCnt, CMlngvsfColLotKind, CPstrOne)
                                            
                                            '@〓〓 1：CFﾛｯﾄ(大板) 〓〓
                                            Case CPstrOne
            
                                                '@ﾛｯﾄ区分に"2：CF(大板)"をｾｯﾄ
                                                .SetData(llngRowCnt, CMlngvsfColLotKind, CPstrTwo)
            
                                            '@〓〓 NULL：ﾀﾞﾐｰ冶具or未使用処理部 〓〓
                                            Case Else
                                            
                                                '@ﾛｯﾄ区分に"NULL：ﾀﾞﾐｰ冶具or未使用処理部"をｾｯﾄ
                                                .SetData(llngRowCnt, CMlngvsfColLotKind, vbNullString)
            
                                        End Select
                    
                                    '@〓 2：TPALﾛｯﾄ 〓
                                    Case CPstrTwo
                                    
                                        '@処理なし
                                        
                                    '@〓 NULL：ﾀﾞﾐｰ冶具or未使用処理部 〓
                                    Case Else
                                    
                                        '@ﾛｯﾄ区分に"NULL：ﾀﾞﾐｰ冶具or未使用処理部"をｾｯﾄ
                                        .SetData(llngRowCnt, CMlngvsfColLotKind, vbNullString)
                                    
                                End Select
                                
                                '@ｽﾛｯﾄの高さの設定
                                .Rows(llngRowCnt).Height = CMlngVsfHeight
                                
                                '@行ｶｳﾝﾄ+1
                                llngRowCnt = llngRowCnt + 1
                                
                            End If
                            
                            '@前回値としてﾛｯﾄID退避
                            lstrTmpLotId = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLotID
                            
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngDoCnt = llngDoCnt + 1
                            
                        Loop
        '@↑2012/03/12 (Mon) 14:46:19 T.Oide **************************************************

                        
                        '@★ 装置ﾀｲﾌﾟにより処理分岐 ★
                        Select Case mtypBatLotList.typBatLot(0).strEqType
                        
                            '@〓 "19：斜方蒸着装置" 〓
                            Case CPstrEqTypeJyoucyaku
                            
                                '@各種表示列の表示/非表示設定
                                .Cols(CMlngvsfColUldCarrierID).Visible = False    'ULDｷｬﾘｱID  ：非表示
                                .Cols(CMlngvsfColWFID).Visible = True             'WFID       ：表示
                                .Cols(CMlngvsfColJigID).Visible = True            '冶具ID     ：表示


                            '@〓 "20：表面処理装置" 〓
                            Case CPstrEqTypeHyoumenSyori
                                
                                '@各種表示列の表示/非表示設定
                                .Cols(CMlngvsfColUldCarrierID).Visible = True     'ULDｷｬﾘｱID  ：表示
                                .Cols(CMlngvsfColWFID).Visible = False            'WFID       ：非表示
                                .Cols(CMlngvsfColJigID).Visible = False           '冶具ID     ：非表示


                            '@〓 その他 〓
                            Case Else
                                
                                '@各種表示列を非表示にする
                                .Cols(CMlngvsfColUldCarrierID).Visible = False    'ULDｷｬﾘｱID
                                .Cols(CMlngvsfColWFID).Visible = False            'WFID
                                .Cols(CMlngvsfColJigID).Visible = False           '冶具ID

                        End Select
                        
                        '@書式設定
                        .Cols(CMlngvsfColNo).TextAlign = TextAlignEnum.RightCenter                       '中央右寄せ
                        .Cols(CMlngvsfColCarrierID).TextAlign = TextAlignEnum.LeftCenter                 '中央左寄せ
                        .Cols(CMlngvsfColUldCarrierID).TextAlign = TextAlignEnum.LeftCenter              '中央左寄せ
                        .Cols(CMlngvsfColLotID).TextAlign = TextAlignEnum.LeftCenter                     '中央左寄せ
                        .Cols(CMlngvsfColStatus).TextAlign = TextAlignEnum.LeftCenter                    '中央左寄せ
                        .Cols(CMlngvsfColFlowClass).TextAlign = TextAlignEnum.LeftCenter                 '中央左寄せ
                        .Cols(CMlngvsfColPDID).TextAlign = TextAlignEnum.LeftCenter                      '中央左寄せ
                        .Cols(CMlngvsfColOpID).TextAlign = TextAlignEnum.LeftCenter                      '中央左寄せ
                        .Cols(CMlngvsfColStepID).TextAlign = TextAlignEnum.LeftCenter                    '中央左寄せ
                        .Cols(CMlngvsfColWFID).TextAlign = TextAlignEnum.LeftCenter                      '中央左寄せ
                        .Cols(CMlngvsfColWFQuantity).TextAlign = TextAlignEnum.RightCenter               '中央右寄せ
                        .Cols(CMlngvsfColJigID).TextAlign = TextAlignEnum.LeftCenter                     '中央左寄せ
                        .Cols(CMlngvsfColS).TextAlign = TextAlignEnum.LeftCenter                         '中央左寄せ
                        .Cols(CMlngvsfColTimeLimit).TextAlign = TextAlignEnum.RightCenter                '中央右寄せ
                        .Cols(CMlngvsfColLotManager).TextAlign = TextAlignEnum.LeftCenter                '中央左寄せ
                        .Cols(CMlngvsfColStartDayTime).TextAlign = TextAlignEnum.LeftCenter              '中央左寄せ
                        .Cols(CMlngvsfColActionFlag).TextAlign = TextAlignEnum.LeftCenter                '中央左寄せ
                        .Cols(CMlngvsfColLotComment).TextAlign = TextAlignEnum.LeftCenter                '中央左寄せ
                        .Cols(CMlngvsfColLastUpdate).TextAlign = TextAlignEnum.LeftCenter                '中央左寄せ
                        .Cols(CMlngvsfColOptionText).TextAlign = TextAlignEnum.LeftCenter                '中央左寄せ
            
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCol(CMlngvsfColNo, 6)                                                   '順序
                        .AutoSizeCol(CMlngvsfColCarrierID, 6)                                            'ｷｬﾘｱID
                        .AutoSizeCol(CMlngvsfColUldCarrierID, 6)                                         'ULDｷｬﾘｱID
                        .AutoSizeCol(CMlngvsfColLotID, 6)                                                'ﾛｯﾄID
                        .AutoSizeCol(CMlngvsfColStatus, 6)                                               'ﾛｯﾄ状態
                        .AutoSizeCol(CMlngvsfColFlowClass, 6)                                            '流動区分
                        .AutoSizeCol(CMlngvsfColPDID, 6)                                                 '機種
                        .AutoSizeCol(CMlngvsfColOpID, 6)                                                 '大工程
                        .AutoSizeCol(CMlngvsfColStepID, 6)                                               '小工程
                        .AutoSizeCol(CMlngvsfColWFID, 6)                                                 'WFID(#+2桁(例：#01))
                        .AutoSizeCol(CMlngvsfColWFQuantity, 6)                                           'WF枚数
                        .AutoSizeCol(CMlngvsfColJigID, 6)                                                '冶具ID
                        .AutoSizeCol(CMlngvsfColS, 6)                                                    '特殊特性
                        .AutoSizeCol(CMlngvsfColTimeLimit, 6)                                            '時間制限
                        .AutoSizeCol(CMlngvsfColLotManager, 6)                                           'ﾛｯﾄ担当
                        .AutoSizeCol(CMlngvsfColStartDayTime, 6)                                         '処理開始予定日時
                        .AutoSizeCol(CMlngvsfColActionFlag, 6)                                           'ｱｸｼｮﾝﾌﾗｸﾞ
                        .AutoSizeCol(CMlngvsfColLotComment, 6)                                           'ﾛｯﾄｺﾒﾝﾄ
                        .AutoSizeCol(CMlngvsfColLastUpdate, 6)                                           '最終更新日時
                        .AutoSizeCol(CMlngvsfColOptionText, 6)                                           '作業ﾒﾓ
                        
                        '@描画開始
                        '.Redraw = True

                        '@=======================
                        '@ 左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                        '@=======================
                        Call pubCmdLREnable_Set(vsfBatList, cmdLeft, cmdRight)

                        '@有効にする
                        '.Enabled = True

                    End If
                End If
            End With
            
            '@ﾛｯﾄ数を表示
            lblLotNum.Text = CStr(llngLotCnt)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfBatList_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfNextStepInfo_Init
    '機　能：次工程情報ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 09:29:51 S.Deguchi
    '更新日：2009/06/25 (Thu) 13:48:34 N.Kojima
    '備　考：
    '　　　：2009/06/25 (Thu) 13:48:34 N.Kojima     無機対応。(案件№03560)
    Private Sub prvVsfNextStepInfo_Init()

        Try
            
            '@-----------------------
            '@ 次工程情報ｸﾞﾘｯﾄﾞの初期設定(各ｶﾗﾑの幅、ﾀｲﾄﾙを設定 etc...)
            '@-----------------------
            With vsfNextStepInfo

                'NSYS 再描画停止
                .Redraw = False

                '.Clear()                          'ｸﾘｱ
                .Rows.Count = CMlngGridFixedRows   '初期行数：1
                .Width = CMlngGridWidth            '幅
                .Height = CMlngGridHeight          '高さ
                
                '@一覧表の表題設定
                '.Select(CMlngGridRowTitle, CMlngNextStepInfoColCarrierID, CMlngGridRowTitle, CMlngNextStepInfoColWPID)
                'NSYS スタイルを変数に設定
                Dim lFixedlStyle As CellStyle = .Styles.Fixed 
                lFixedlStyle.ForeColor = Color.Yellow                                '文字色
                lFixedlStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)   '背景色
                'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                lFixedlStyle.Font = New Font(lFixedlStyle.Font.FontFamily, CType(CMlngVsfHFontSize,Single), lFixedlStyle.Font.Style, lFixedlStyle.Font.Unit) 
                lFixedlStyle.TextAlign = TextAlignEnum.CenterCenter                  '文字位置
                lFixedlStyle.Trimming = StringTrimming.None                          'NSYS ヘッダ行省略表示なし

                
                '@列幅の設定
                .Cols(CMlngNextStepInfoColCarrierID).Width = CMlngGridColWidthCarrierID   'ｷｬﾘｱID
                .Cols(CMlngNextStepInfoColLotID).Width = CMlngGridColWidthLotID           'ﾛｯﾄID
                .Cols(CMlngNextStepInfoColFlowClass).Width = CMlngGridColWidthFlowClass   '種別
                .Cols(CMlngNextStepInfoColOpID).Width = CMlngGridColWidthOpID             '大工程ID
                .Cols(CMlngNextStepInfoColStepID).Width = CMlngGridColWidthStepID         '小工程ID
                .Cols(CMlngNextStepInfoColDefault).Width = CMlngGridColWidthDefault       'ﾃﾞﾌｫﾙﾄ
                .Cols(CMlngNextStepInfoColWPID).Width = CMlngGridColWidthWPID             'WPID
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColCarrierID, CMstrNextStepInfoColTCarrierID)    'ｷｬﾘｱID
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColLotID, CMstrNextStepInfoColTLotID)            'ﾛｯﾄID
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColFlowClass, CMstrNextStepInfoColTFlowClass)    '種別
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColOpID, CMstrNextStepInfoColTOpID)              '大工程ID
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColStepID, CMstrNextStepInfoColTStepID)          '小工程ID
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColDefault, CMstrNextStepInfoColTDefault)        'ﾃﾞﾌｫﾙﾄ
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColWPID, CMstrNextStepInfoColTWPID)              'WPID
                        
                '@表示位置の設定
                '.Cell(flexcpAlignment, CMlngVsfRowTitle, CMlngVsfColTitle, .Rows.Count - 1, .Cols.Count - 1) = flexAlignCenterCenter
                .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight      '高さ
                
                '@結合ｾﾙ(ﾏｰｼﾞｾﾙ)の設定
                .AllowMerging = AllowMergingEnum.RestrictAll          '列方向のﾏｰｼﾞ
                .Cols(CMlngNextStepInfoColCarrierID).AllowMerging = True
                .Cols(CMlngNextStepInfoColLotID).AllowMerging = True
                .Cols(CMlngNextStepInfoColFlowClass).AllowMerging = True
                .Cols(CMlngNextStepInfoColOpID).AllowMerging = True
                .Cols(CMlngNextStepInfoColStepID).AllowMerging = True
                .Cols(CMlngNextStepInfoColDefault).AllowMerging = True

                
                '@無効
                .Enabled = False

                'NSYS 再描画開始
                .Redraw = True

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfNextStepInfo_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfNextStepInfo_Disp
    '機　能：次工程情報ｸﾞﾘｯﾄﾞ表示処理
    '引　数：lstrCarrierID  ：ｷｬﾘｱID
    '　　　：lstrLotID      ：ﾛｯﾄID
    '　　　：lstrFlowClass  ：種別
    '戻り値：なし
    '作成日：2004/07/21 (Wed) 16:28:25 S.Deguchi
    '更新日：2009/06/25 (Thu) 13:48:34 N.Kojima
    '備　考：
    '　　　：2009/06/25 (Thu) 13:48:34 N.Kojima     無機対応。(案件№03560)
    Private Sub prvVsfNextStepInfo_Disp(ByVal lstrCarrierID As String, _
                                        ByVal lstrLotID As String, _
                                        ByVal lstrFlowClass As String)

        Dim lllngWPListCnt      As Integer  'WPListCntｶｳﾝﾀ
        Dim llngStepCnt         As Integer  'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngRowCnt          As Integer  '行ｶｳﾝﾀ

        Try
            
            '@=======================
            '@ 次工程情報ｸﾞﾘｯﾄﾞ初期化処理(念のため)
            '@=======================
            Call prvVsfNextStepInfo_Init()


            With vsfNextStepInfo
                
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@ｶｳﾝﾀの初期化
                llngRowCnt = .Rows.Fixed
                
                '@ﾃﾞｰﾀ分ﾙｰﾌﾟ
                For llngStepCnt = 0 To mtypLotNextStep.lngNextStepListCnt - 1
                    
                    '@選択ﾛｯﾄの次工程情報か
                    If mtypLotNextStep.strNextStepList(llngStepCnt).strLotID = lstrLotID Then
                    
                        '@装置数分ﾙｰﾌﾟ
                        For lllngWPListCnt = 0 To mtypLotNextStep.strNextStepList(llngStepCnt).lngWpListCnt - 1
                            
                            '@行数の設定
                            .Rows.Count = llngRowCnt + 1

                            .SetData(llngRowCnt, CMlngNextStepInfoColCarrierID, lstrCarrierID)        'ｷｬﾘｱID
                            .SetData(llngRowCnt, CMlngNextStepInfoColLotID, lstrLotID)                'ﾛｯﾄID
                            .SetData(llngRowCnt, CMlngNextStepInfoColFlowClass, lstrFlowClass)        '種別
                            .SetData(llngRowCnt, CMlngNextStepInfoColOpID, _
                                mtypLotNextStep.strNextStepList(llngStepCnt).strNextOpId)             '次大工程
                            .SetData(llngRowCnt, CMlngNextStepInfoColStepID, _
                                mtypLotNextStep.strNextStepList(llngStepCnt).strNextStepId)            '次小工程
                            
                            '@★ 工程ﾌﾗｸﾞの値により処理分岐 ★
                            Select Case mtypLotNextStep.strNextStepList(llngStepCnt).strStepDivision
                                
                                '@〓 0：代替工程 〓
                                Case CMstrStepDaitai
                                    
                                    .SetData(llngRowCnt, CMlngNextStepInfoColDefault, CMstrDaitaiStep)
                                
                                '@〓 1：ﾃﾞﾌｫﾙﾄ工程 〓
                                Case CMstrStepDefault
                                    
                                    .SetData(llngRowCnt, CMlngNextStepInfoColDefault, CMstrDefaultStep)
                                
                                '@〓 その他 〓
                                Case Else
                                    
                                    .SetData(llngRowCnt, CMlngNextStepInfoColDefault, vbNullString)
                            
                            End Select
                            
                            '@装置名
                            .SetData(llngRowCnt, CMlngNextStepInfoColWPID, _
                                mtypLotNextStep.strNextStepList(llngStepCnt).strWPList(lllngWPListCnt).strWpName)
                            
                            '@ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                            llngRowCnt = llngRowCnt + 1
                        
                        Next lllngWPListCnt
                    End If
                Next llngStepCnt
                
                '書式設定(書き込む内容全てを左寄せにする)
                .Cols(CMlngNextStepInfoColCarrierID).TextAlign = TextAlignEnum.LeftCenter               '中央左寄せ
                .Cols(CMlngNextStepInfoColLotID).TextAlign = TextAlignEnum.LeftCenter                   '中央左寄せ
                .Cols(CMlngNextStepInfoColFlowClass).TextAlign = TextAlignEnum.LeftCenter               '中央左寄せ
                .Cols(CMlngNextStepInfoColOpID).TextAlign = TextAlignEnum.LeftCenter                    '中央左寄せ
                .Cols(CMlngNextStepInfoColStepID).TextAlign = TextAlignEnum.LeftCenter                  '中央左寄せ
                .Cols(CMlngNextStepInfoColDefault).TextAlign = TextAlignEnum.LeftCenter                 '中央左寄せ
                .Cols(CMlngNextStepInfoColWPID).TextAlign = TextAlignEnum.LeftCenter                    '中央左寄せ
                
                '@列幅設定(下記の列のみｵｰﾄｻｲｽﾞにする)
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCol(CMlngNextStepInfoColCarrierID, 6)         'ｷｬﾘｱID
                .AutoSizeCol(CMlngNextStepInfoColLotID, 6)             'ﾛｯﾄID
                .AutoSizeCol(CMlngNextStepInfoColFlowClass, 6)         '種別
                
                '@ﾀｲﾄﾙの行の高さ
                .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight
                
                '@明細の行の高さ
                For lintCnt As Integer = CMlngGridRowTitle+1 To .Rows.Count - 1
                    .Rows(lintCnt).Height = CMlngGridRowHeight
                Next
                
                '@=======================
                '@ 上下ｽｸﾛｰﾙﾎﾞﾀﾝ制御処理(ｸﾞﾘｯﾄﾞ共通化関数)
                '@=======================
                Call pubVsfDisp(vsfNextStepInfo, cmdNextUP, cmdNextDown)

                'NSYS ヘッダ行を選択状態にする
                .Row = 0

                '@描画開始
                .Redraw = True

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfNextStepInfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvNextStep_Sel
    '機　能：次工程情報取得＆表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/21 (Wed) 16:10:56 S.Deguchi
    '更新日：2009/06/25 (Thu) 14:40:24 N.Kojima
    '備　考：
    '　　　：2009/06/25 (Thu) 14:40:24 N.Kojima     無機対応。(案件№03560)
    Private Sub prvNextStep_Sel()

        Dim ltypLotNextStep         As LotNextStep      '次工程情報
        Dim lblnAns                 As Boolean          '結果格納
        Dim llngCnt                 As Integer          '汎用ｶｳﾝﾀ1
        Dim llngCnt2                As Integer          '汎用ｶｳﾝﾀ2
        Dim llngCnt3                As Integer          '汎用ｶｳﾝﾀ3
        Dim lstrInfoGetCompLotID    As String           '情報取得済みﾛｯﾄID(同じ情報を2度取得しない対応)
        Dim lstrSearchLotID         As String           '検索ﾛｯﾄID

        Try

            '@ﾛｯﾄ次工程情報格納構造体の初期化
            ltypLotNextStep.lngNextStepListCnt = 0
            ltypLotNextStep.strNextStepList = New List(Of NextStep)


            '@ﾊﾞｯﾁ組情報一覧のｷｬﾘｱID/ﾛｯﾄID/種別/大工程/小工程を変数に退避
            With vsfBatList

                For llngCnt = 1 To .Rows.Count - 1

                    '@ﾛｯﾄIDがNULL以外か
                    If .GetData(llngCnt, CMlngvsfColLotID) <> vbNullString Then
                        
                        '@検索用にﾛｯﾄIDを退避(長いので)
                        lstrSearchLotID = .GetData(llngCnt, CMlngvsfColLotID)
                        
                        '@情報取得済みﾛｯﾄIDではないか
                        If InStr(1, lstrInfoGetCompLotID, lstrSearchLotID) = 0 Then
                            '@取得済みﾛｯﾄ以外の場合
                        
        '                    '@***********************
        '                    '@ 送信ﾃﾞｰﾀ作成
        '                    '@***********************
        '                    lstrCarrierID = .Cell(flexcpText, llngCnt, CMlngvsfColCarrierID)    'ｷｬﾘｱID
        '                    lstrLotID = .Cell(flexcpText, llngCnt, CMlngvsfColLotID)            'ﾛｯﾄID
        '                    lstrFlowClass = .Cell(flexcpText, llngCnt, CMlngvsfColFlowClass)    '種別
        '                    lstrOpID = .Cell(flexcpText, llngCnt, CMlngvsfColOpID)              '大工程
        '                    lstrStepID = .Cell(flexcpText, llngCnt, CMlngvsfColStepID)          '小工程
                            
                            '@ﾚｽﾎﾟﾝｽ取得開始
                            Call pubResponseStart(CMstrFormName, CMstrPrvNextStepSel)
                            
                            '@=======================
                            '@ ﾛｯﾄ次工程取得
                            '@=======================
                            lblnAns = pubblnLotNextStepList_Sel(CMstrlot_nextsteplistVer, _
                                                                .GetData(llngCnt, CMlngvsfColLotID), _
                                                                .GetData(llngCnt, CMlngvsfColOpID), _
                                                                .GetData(llngCnt, CMlngvsfColStepID), _
                                                                ltypLotNextStep)
                                                                
                            '@ﾛｯﾄ次工程取得結果が"True：通信成功"か
                            If lblnAns = True Then
                            
                                '@ﾚｽﾎﾟﾝｽ取得終了
                                Call publngResponseEnd(CMstrFormName, CMstrPrvNextStepSel)
                                
                                '@次工程情報が1件以上存在するか
                                If ltypLotNextStep.lngNextStepListCnt > 0 Then
                                    
                                    For llngCnt2 = 0 To ltypLotNextStep.lngNextStepListCnt - 1

                                        If IsNothing(mtypLotNextStep.strNextStepList) Then
                                            mtypLotNextStep.strNextStepList = New List(Of NextStep)()
                                        End If
                                        Dim tmpNextStep As NextStep = New NextStep()
                                        
                                        '@次工程情報を退避
                                            '次工程情報
                                        tmpNextStep.lngNextStepListCnt = ltypLotNextStep.strNextStepList(llngCnt2).lngNextStepListCnt
                                        tmpNextStep.strNextOpId  = ltypLotNextStep.strNextStepList(llngCnt2).strNextOpId
                                        tmpNextStep.strNextStepId = ltypLotNextStep.strNextStepList(llngCnt2).strNextStepId
                                        tmpNextStep.strStepDivision = ltypLotNextStep.strNextStepList(llngCnt2).strStepDivision
                                        tmpNextStep.lngWpListCnt = ltypLotNextStep.strNextStepList(llngCnt2).lngWpListCnt
                                        If Not IsNothing(ltypLotNextStep.strNextStepList(llngCnt2).strWPList) Then
                                            tmpNextStep.strWPList = New List(Of WP)(ltypLotNextStep.strNextStepList(llngCnt2).strWPList)
                                        End If
                                        tmpNextStep.strLotID = _
                                            .GetData(llngCnt, CMlngvsfColLotID)                            'ﾛｯﾄID
                                        mtypLotNextStep.strNextStepList.Add(tmpNextStep)
                                        '@次工程情報格納構造体のﾘｽﾄ数を+1する
                                        mtypLotNextStep.lngNextStepListCnt = mtypLotNextStep.lngNextStepListCnt + 1


                                        '@次大工程/次小工程がNULLか
                                        If ltypLotNextStep.strNextStepList(llngCnt2).strNextOpId = vbNullString And _
                                            ltypLotNextStep.strNextStepList(llngCnt2).strNextStepId = vbNullString Then
                        
                                            '@次大工程、次小工程にNULLをｾｯﾄ
                                            .SetData(llngCnt, CMlngvsfColNextOpID, vbNullString)
                                            .SetData(llngCnt, CMlngvsfColNextStepID, vbNullString)
                        
                                        Else
                                            '@次大工程 or 次小工程がNULL以外の場合
                        
                                            '@工程ﾌﾗｸﾞが"1：ﾃﾞﾌｫﾙﾄ工程"か
                                            If ltypLotNextStep.strNextStepList(llngCnt2).strStepDivision = CMstrStepDefault Then
                        
                                                '@***********************
                                                '@ 次大工程 or 次小工程がNULL以外で、かつ工程ﾌﾗｸﾞが"1：ﾃﾞﾌｫﾙﾄ工程
                                                '@***********************
                        
                                                .SetData(llngCnt, CMlngvsfColNextOpID, _
                                                    ltypLotNextStep.strNextStepList(llngCnt2).strNextOpId)        '次大工程：取得値
                        
                                                .SetData(llngCnt, CMlngvsfColNextStepID, _
                                                    ltypLotNextStep.strNextStepList(llngCnt2).strNextStepId)      '次小工程：取得値
                                            End If
                                        End If
                                    Next llngCnt2
                                Else
                                    '@次工程情報が0件の場合
                        
                                    .SetData(llngCnt, CMlngvsfColNextOpID, vbNullString)                '次大工程：NULL
                                    .SetData(llngCnt, CMlngvsfColNextStepID, vbNullString)              '次小工程：NULL
                                End If
                                
                                
                                '@-----------------------
                                '@ 次工程情報を作成
                                '@-----------------------
                                '@次大工程、次小工程、工程ﾌﾗｸﾞが空白の場合
                                If ltypLotNextStep.strNextStepList(0).strNextOpId = vbNullString And _
                                    ltypLotNextStep.strNextStepList(0).strNextStepId = vbNullString And _
                                    ltypLotNextStep.strNextStepList(0).strStepDivision = vbNullString Then
                        
                                    '@=======================
                                    '@ 次工程情報ｸﾞﾘｯﾄﾞ初期化処理
                                    '@=======================
                                    Call prvVsfNextStepInfo_Init()
                        
                                Else
                                    '@次大工程、次小工程、工程ﾌﾗｸﾞが空白以外の場合
                                    
                                    '@=======================
                                    '@ 次工程情報ｸﾞﾘｯﾄﾞ表示処理
                                    '@=======================
                                    Call prvVsfNextStepInfo_Disp(.GetData(llngCnt, CMlngvsfColCarrierID), _
                                                                 .GetData(llngCnt, CMlngvsfColLotID), _
                                                                 .GetData(llngCnt, CMlngvsfColFlowClass))

                                End If
                            Else
                                '@ﾛｯﾄ次工程取得結果が"False：通信失敗"の場合
                            
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(CMstrFormName, CMstrPrvNextStepSel)
                                
                                With vsfBatList
                                
                                    '@次大工程/次小工程にNULLをｾｯﾄ
                                    .SetData(llngCnt, CMlngvsfColNextOpID, vbNullString)             '次大工程
                                    .SetData(llngCnt, CMlngvsfColNextStepID, vbNullString)           '次小工程
                                End With
                        
                                '@=======================
                                '@ 次工程情報ｸﾞﾘｯﾄﾞ初期化処理
                                '@=======================
                                Call prvVsfNextStepInfo_Init()
                        
                            End If

                            '@情報取得済みﾛｯﾄIDに情報取得したﾛｯﾄIDを退避(結合して格納していく)
                            lstrInfoGetCompLotID = lstrInfoGetCompLotID & CPstrSpace & _
                                                    .GetData(llngCnt, CMlngvsfColLotID)

                        Else
                            '@取得済みﾛｯﾄの場合
                            
                            For llngCnt3 = 1 To .Rows.Count - 1
                                
                                '@ﾛｯﾄIDが同じか
                                If .GetData(llngCnt, CMlngvsfColLotID) = _
                                    .GetData(llngCnt3, CMlngvsfColLotID) Then
                                    
                                    '@同じﾛｯﾄIDの取得済み情報をｺﾋﾟｰ
                                    .SetData(llngCnt, CMlngvsfColNextOpID, _
                                        .GetData(llngCnt3, CMlngvsfColNextOpID))            '次大工程：取得値
                
                                    .SetData(llngCnt, CMlngvsfColNextStepID, _
                                        .GetData(llngCnt3, CMlngvsfColNextStepID))          '次小工程：取得値
                                
                                    Exit For
                                End If
                            Next llngCnt3
                        End If
                    End If
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvNextStep_Sel"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvActionInfoSelDisp_Proc
    '機　能：ｱｸｼｮﾝ予約情報取得＆ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Wed) 15:57:44 S.Deguchi
    '更新日：2009/06/25 (Thu) 14:40:24 N.Kojima
    '備　考：
    '　　　：2009/06/25 (Thu) 14:40:24 N.Kojima     無機対応。(案件№03560)
    Private Sub prvActionInfoSelDisp_Proc()

        Dim lblnAns                 As Boolean              '結果判定
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ1
        Dim llngCnt2                As Integer              '汎用ｶｳﾝﾀ2
        Dim llngActCnt              As Integer              'ｶｳﾝﾄ
        Dim lstrLotID               As String               'ﾛｯﾄID
        Dim lstrFlowClass           As String               '流動区分
        Dim lstrOpID                As String               '大工程
        Dim lstrStepID              As String               '小工程
        Dim lstrPdID                As String               '機種ID
        Dim lstrMasPDVersion        As String               '工順
        Dim lstrWpId                As String               '装置ID
        Dim lstrInfoGetCompLotID    As String               '情報取得済みﾛｯﾄID(同じ情報を2度取得しない対応)
        Dim lstrSearchLotID         As String               '検索ﾛｯﾄID

        Try

            '@ｱｸｼｮﾝ予約総件数初期化
            mlngActCnt = 0
            
            With vsfBatList
                
                For llngCnt = 1 To .Rows.Count - 1
                    
        '@↓2009/06/25 (Thu) 14:56:09 N.Kojima **************************************************
                    
                    '@ﾛｯﾄIDがNULL以外か(NULLはﾀﾞﾐｰ冶具or未使用処理部なのでｱｸｼｮﾝ予約ﾘｽﾄ取得はｽｷｯﾌﾟ)
                    If .GetData(llngCnt, CMlngvsfColLotID) <> vbNullString Then
                    
                        '@検索用にﾛｯﾄIDを退避(長いので)
                        lstrSearchLotID = .GetData(llngCnt, CMlngvsfColLotID)
                        
                        '@情報取得済みﾛｯﾄIDではないか
                        If InStr(1, lstrInfoGetCompLotID, lstrSearchLotID) = 0 Then
                    
                            '@***********************
                            '@ 送信情報を作成
                            '@***********************
                            lstrLotID = .GetData(llngCnt, CMlngvsfColLotID)                'ﾛｯﾄID
                            lstrFlowClass = .GetData(llngCnt, CMlngvsfColFlowClass)        '流動区分
                            lstrOpID = .GetData(llngCnt, CMlngvsfColOpID)                  '大工程
                            lstrStepID = .GetData(llngCnt, CMlngvsfColStepID)              '小工程
                            lstrPdID = .GetData(llngCnt, CMlngvsfColPDID)                  '機種
                            lstrMasPDVersion = vbNullString                                '工順
                            lstrWpId = mstrWpID                                            '装置ID
                        
                            '@ﾚｽﾎﾟﾝｽ取得開始
                            Call pubResponseStart(CMstrFormName, CMstrPrvActionInfoSelDispProc)
                            
                            '@ｱｸｼｮﾝ予約情報格納用構造体の初期化
                            ptypLotAction.lnglstCnt = 0
                            If Not IsNothing(ptypLotAction.typLotActList) Then
                                ptypLotAction.typLotActList.Clear()
                            End If
                            
                            '@=======================
                            '@ ｱｸｼｮﾝ予約ﾘｽﾄ取得
                            '@=======================
                            lblnAns = pubblnLotActList_Sel(CMstrlot_actlist_Ver, _
                                                           lstrLotID, _
                                                           lstrOpID, _
                                                           lstrStepID, _
                                                           lstrPdID, _
                                                           lstrMasPDVersion, _
                                                           lstrWpId, _
                                                           ptypLotAction)
            
                            '@ｱｸｼｮﾝ予約ﾘｽﾄ取得結果が"True：通信成功"か
                            If lblnAns = True Then
                                '@True：通信成功の場合
                                
                                '@ﾚｽﾎﾟﾝｽ取得終了
                                Call publngResponseEnd(CMstrFormName, CMstrPrvActionInfoSelDispProc)
                                
                                '@ｱｸｼｮﾝ予約ﾘｽﾄが1件以上あるか
                                If ptypLotAction.lnglstCnt > 0 Then
                                    
                                    With ptypLotAction
                                        
                                        '@ｱｸｼｮﾝ予約がなくなるまで
                                        For llngActCnt = 0 To .lnglstCnt - 1
                                            
                                            Dim tmpLotActList As LotActList = .typLotActList(llngActCnt)
                                            '@ｱｸｼｮﾝ予約総件数
                                            ReDim Preserve mtypLotActList(mlngActCnt)
                                            
                                            tmpLotActList.strLotID = lstrLotID                             'ﾛｯﾄID
                                            mtypLotActList(mlngActCnt).strLotID = lstrLotID
                                            tmpLotActList.strFlowClass = lstrFlowClass                     '流動区分
                                            mtypLotActList(mlngActCnt).strFlowClass = lstrFlowClass
                                            
                                            '@★ ｱｸｼｮﾝ予約ﾀｲﾌﾟにより処理分岐 ★
                                            Select Case tmpLotActList.strLotActionTypeID
                                                
                                                '@〓 ﾛｯﾄ 〓
                                                Case CPstrLotActionTypeID0
                                                    
                                                    tmpLotActList.strLotActionTypeName = CPstrActTypeLOT   'ｱｸｼｮﾝ予約ﾀｲﾌﾟ：ﾛｯﾄ
                                                    mtypLotActList(mlngActCnt).strLotActionTypeName = CPstrActTypeLOT
                                                
                                                '@〓 機種 〓
                                                Case CPstrLotActionTypeID1
                                                    
                                                    tmpLotActList.strLotActionTypeName = CPstrActTypePD    'ｱｸｼｮﾝ予約ﾀｲﾌﾟ：機種
                                                    mtypLotActList(mlngActCnt).strLotActionTypeName = CPstrActTypePD
                                                
                                                '@〓 装置 〓
                                                Case CPstrLotActionTypeID2
                                                    
                                                    tmpLotActList.strLotActionTypeName = CPstrActTypeWP    'ｱｸｼｮﾝ予約ﾀｲﾌﾟ：装置
                                                    mtypLotActList(mlngActCnt).strLotActionTypeName = CPstrActTypeWP
                                                
                                                '@〓 特定工程 〓
                                                Case CPstrLotActionTypeID3
                                                    
                                                    tmpLotActList.strLotActionTypeName = CPstrActTypeTStep 'ｱｸｼｮﾝ予約ﾀｲﾌﾟ：特定工程
                                                    mtypLotActList(mlngActCnt).strLotActionTypeName = CPstrActTypeTStep
                                            
                                            End Select
                                            
                                            tmpLotActList.strActionTrigger = CMstrEN00K0Title              'ｱｸｼｮﾝﾄﾘｶﾞｰ
                                            mtypLotActList(mlngActCnt).strActionTrigger = CMstrEN00K0Title
                                            
                                            tmpLotActList.strOpID = lstrOpID                               '大工程
                                            mtypLotActList(mlngActCnt).strOpID = lstrOpID
                                            
                                            tmpLotActList.strStepID = lstrStepID                           '小工程
                                            mtypLotActList(mlngActCnt).strStepID = lstrStepID
                                            
                                            mtypLotActList(mlngActCnt).strWorkDirectionID _
                                                = .typLotActList(llngActCnt).strWorkDirectionID                         '作業指示書№

                                            .typLotActList(llngActCnt) = tmpLotActList

                                            mlngActCnt = mlngActCnt + 1
            
                                        Next llngActCnt
                                    End With
                                    
                                    '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面で確定していない(False)か
                                    If pblnSubDecision = False Then
                                        
                                        '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面名称設定
                                        frmxxCM0040.Instance.Text = CPstrSubDispTitleActionMsg
                                        
                                        '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                                        '@ ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面　表示処理
                                        '@ ※ptypLotActionの情報でｱｸｼｮﾝ予約の内容を表示
                                        '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                                        frmxxCM0040.Instance.ShowDialog(Me)
                                        frmxxCM0040.Instance = Nothing
                                        
                                        '@ｱｸｼｮﾝ予約表示ﾌﾗｸﾞの設定
                                        .SetData(llngCnt, CMlngvsfColActionFlag, CMstrFlagOK)
                        
                                    Else
                                        '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面確定ﾌﾗｸﾞに"False：確定していない"をｾｯﾄ
                                        pblnSubDecision = False
                                    End If
                                End If
                            Else
                                '@False：通信失敗の場合
            
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(CMstrFormName, CMstrPrvActionInfoSelDispProc)
                            End If
                            
                        Else
                            '@取得済みﾛｯﾄの場合
                            
                            For llngCnt2 = 1 To .Rows.Count - 1
                                
                                '@ﾛｯﾄIDが同じか
                                If .GetData(llngCnt, CMlngvsfColLotID) = _
                                    .GetData(llngCnt2, CMlngvsfColLotID) Then
                                
                                    '@同じﾛｯﾄIDの設定済みｱｸｼｮﾝﾌﾗｸﾞをｺﾋﾟｰ
                                    .SetData(llngCnt, CMlngvsfColActionFlag, _
                                        .GetData(llngCnt2, CMlngvsfColActionFlag))
                                    
                                    Exit For
                                End If
                            Next llngCnt2
                        End If
                        
                        '@情報取得済みﾛｯﾄIDに情報取得したﾛｯﾄIDを退避(結合して格納していく)
                        lstrInfoGetCompLotID = lstrInfoGetCompLotID & CPstrSpace & _
                                                .GetData(llngCnt, CMlngvsfColLotID)
                        
                    End If
                    
        '@↑2009/06/25 (Thu) 14:56:09 N.Kojima **************************************************
                    
                Next llngCnt

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvActionInfoSelDisp_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnCmdRegist_Chk
    '機　能：確定ﾎﾞﾀﾝ制御ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2004/07/20 (Wed) 20:24:47 S.Deguchi
    '更新日：2009/07/22 (Wed) 12:29:51 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:11:24 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/22 (Wed) 12:29:51 N.Kojima     無機対応Phase2、ﾁｪｯｸ条件からｷｬﾘｱIDを削除。(案件№03661)
    Private Function prvblncmdRegist_Chk() As Boolean

        Dim llngCnt     As Integer      'ｶｳﾝﾄ

        Try
            
            '@戻り値の初期化
            prvblncmdRegist_Chk = True
            
            With vsfBatList
                
                For llngCnt = 1 To .Rows.Count - 1

        '@↓2009/06/26 (Fri) 11:50:55 N.Kojima **************************************************

        '            '@後処理以外のｽﾃｰﾀｽがある場合
        '            If .Cell(flexcpText, llngCnt, CMlngvsfColStatus) <> CPstrAfterProgressSt Then
                    '@ﾛｯﾄIDがNULL以外で、かつ後処理以外のｽﾃｰﾀｽか
                    If .GetData(llngCnt, CMlngvsfColLotID) <> vbNullString And _
                        .GetData(llngCnt, CMlngvsfColStatus) <> CPstrAfterProgressSt Then
                        '@ある場合
                        
                        '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                        prvblncmdRegist_Chk = False
                        Exit For
                    End If
                    
        '@↑2009/06/26 (Fri) 11:50:55 N.Kojima **************************************************
                    
                Next llngCnt
            End With
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnCmdRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnInputInfo_Chk
    '機　能：確定前ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2004/07/20 (Thu) 10:40:11 S.Deguchi
    '更新日：2009/07/22 (Wed) 12:29:51 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 11:31:29 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/22 (Wed) 12:29:51 N.Kojima     無機対応Phase2、ﾁｪｯｸ条件からｷｬﾘｱIDを削除。(案件№03661)
    Private Function prvblnInputInfo_Chk() As Boolean

        Dim llngCnt         As Integer      'ｶｳﾝﾄ

        Try
            
            '@戻り値の初期化
            prvblnInputInfo_Chk = False
            
            '@ﾊﾞｯﾁIDがNULLか
            If lblBatID.Text = vbNullString Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM0JW>$$バッチIDが存在しません。設定を見直して下さい。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000J)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Function
            End If

            
            '@ﾛｯﾄID/最終更新日時ﾁｪｯｸ
            With vsfBatList
                
                For llngCnt = 1 To .Rows.Count - 1
                    
        '@↓2009/06/26 (Fri) 11:35:47 N.Kojima **************************************************

                    '@ﾛｯﾄIDがNULL以外(ﾀﾞﾐｰ冶具 or 未使用処理部以外)か
                    If .GetData(llngCnt, CMlngvsfColLotID) <> vbNullString Then
                        
                        '@最終更新日時ﾁｪｯｸ
                        If .GetData(llngCnt, CMlngvsfColLastUpdate) = vbNullString Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM0LW>$$バッチ組みされているロットの最終更新日時が存在しません。設定を見直して下さい。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000L)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Function
                        End If
                    Else
                        '@ﾛｯﾄIDがNULLの場合

                        '@ﾀﾞﾐｰ冶具以外、かつ未使用処理部以外か
                        If .GetData(llngCnt, CMlngvsfColCarrierID) <> CPstrDummyJig And _
                            InStr(1, .GetData(llngCnt, CMlngvsfColCarrierID), CPstrNotUse) = 0 Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM0KW>$$バッチ組みされているロットIDが存在しません。設定を見直して下さい。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000K)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Function
                        End If
                    End If

        '@↑2009/06/26 (Fri) 11:35:47 N.Kojima **************************************************

                Next llngCnt
            End With
            
            '@戻り値に"True：ﾁｪｯｸOK"をｾｯﾄ
            prvblnInputInfo_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInputInfo_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvRefresh_Disp
    '機　能：ﾊﾞｯﾁ作業終了画面の最新取得＆復元処理
    '引　数：lblnJudge          ：ﾛｯﾄ最終更新日時判定ﾌﾗｸﾞ(True：判定あり、False：判定なし)
    '　　　：lstrLotLastUpdate  ：最新取得前最終更新日時
    '戻り値：なし
    '作成日：2006/06/08 (Thu) 09:41:50 M.Miura
    '更新日：2009/06/26 (Fri) 11:31:29 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 11:31:29 N.Kojima     無機対応。(案件№03560)
    Private Sub prvRefresh_Disp(ByRef Optional lblnJudge As Boolean = False, _
                                ByRef Optional lstrLotLastUpdate As String = vbNullString)
        
        Dim lstrWorkMemo        As String           '作業ﾒﾓ復元用
        Dim llngOptCnt          As Integer          '次工程ｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝのｶｳﾝﾄ
        Dim llngLoopCnt         As Integer          'ﾙｰﾌﾟｶｳﾝﾄ

        Try
            Dim loptLot() As RadioButton = {optLotNextSend0, optLotNextSend1}

            '@ﾛｯﾄ最終更新日時判定ﾌﾗｸﾞが"True：判定あり"か
            If lblnJudge = True Then
                
                '@子画面でﾛｯﾄ最終更新日時が更新されていない場合は処理終了
                If lstrLotLastUpdate = ptypLotprestate.strLotLastUpdate Then
                    Exit Sub
                End If
            End If
            
            '@送出ｵﾌﾟｼｮﾝﾎﾞﾀﾝ分ﾙｰﾌﾟ(送出あり～追加流動)
            For llngOptCnt = LBound(loptLot) To UBound(loptLot)
                
                '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝにﾁｪｯｸが付いている場合は処理終了
                If loptLot(llngOptCnt).Checked = True Then
                    Exit For
                End If
            Next llngOptCnt
            
            '@作業ﾒﾓを退避
            lstrWorkMemo = txtWorkMemo.Text
            
            '@同一ｷｬﾘｱで最新取得する為、退避ｷｬﾘｱIDは初期化
            mstrCarrier = vbNullString
            
            '@=======================
            '@ ｷｬﾘｱIDﾃｷｽﾄのValidate処理(送出ｵﾌﾟｼｮﾝﾎﾞﾀﾝのﾁｪｯｸ付きの場合の復元処理はValidateにあるので)
            '@=======================
            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(True))
            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
            
            '@入力ｷｬﾘｱIDと選択ｷｬﾘｱIDが違う場合
            If txtCarrier.Text <> pstrCarrierID And _
                pstrCarrierID <> vbNullString Then
                
                With vsfBatList
                    
                    '@最新取得前の選択ｷｬﾘｱIDをｸﾞﾘｯﾄﾞ一覧から探し出す
                    For llngLoopCnt = 1 To .Rows.Count - 1
                        
                        '@最新取得前の選択ｷｬﾘｱIDと同じか
                        If .GetData(llngLoopCnt, CMlngvsfColCarrierID) = pstrCarrierID Then
                            
                            '@先頭へ持っていく
                            .TopRow = llngLoopCnt
                            
                            '@選択状態にする
                            .Row = llngLoopCnt
                            '.Select(llngLoopCnt, CMlngVsfColTitle, llngLoopCnt, .Cols.Count - 1)
                            
                            '@-----------------------
                            '@ ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙﾎﾞﾀﾝ設定
                            '@-----------------------
                            '@=======================
                            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            Call pubVsfBeforeSort(vsfBatList, CMlngvsfColCarrierID)
                            
                            '@=======================
                            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            Call pubVsfAfterSort(vsfBatList, CMlngvsfColCarrierID, cmdUP, cmdDown, False, False)
                        
                        End If
                        
                        '@=======================
                        '@ ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ選択時処理
                        '@=======================
                        Call vsfBatList_EnterCell(vsfBatList, New EventArgs())
                        
                    Next llngLoopCnt
                End With
            End If

            '@「送出あり」が無効で、かつ「送出なし」が有効か
            If optLotNextSend0.Enabled = False And _
                optLotNextSend1.Enabled = True Then
                '@「送出なし」のみ有効な場合(送出できない場合)
                
                '@「送出なし」にﾁｪｯｸを付ける
                optLotNextSend1.Checked = True
            Else
                '@上記以外のﾊﾟﾀｰﾝ

                '@どれかのｵﾌﾟｼｮﾝﾎﾞﾀﾝにﾁｪｯｸが付いているか
                If llngOptCnt <= UBound(loptLot) Then
                    
                    '@最新取得前の状態にｵﾌﾟｼｮﾝﾎﾞﾀﾝのﾁｪｯｸ状態を復元
                    loptLot(llngOptCnt).Checked = True
                End If
            End If
            
            '@作業ﾒﾓの内容を子画面起動前に復元
            txtWorkMemo.Text = lstrWorkMemo
           
            Exit Sub
           
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvRefresh_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
                        
        End Try
    End Sub

    '関数名：prvEasyComb_Chk
    '機　能：簡易統合可否のﾁｪｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/07/02 (Thu) 09:41:50 K.Nishizawa
    '更新日：2009/07/22 (Wed) 12:59:01 N.Kojima
    '備　考：
    '　　　：2009/07/22 (Wed) 12:59:01 N.Kojima     無機対応Phase2、ｿｰｽ整備。(案件№03661)
    Private Sub prvEasyComb_Chk()
        
        Dim lblnAns             As Boolean
        Dim llngCnt             As Integer
        Dim llngDoCnt           As Integer
        Dim lstrLotID           As String
        Dim lstrCarrierID       As String
        
        Try
            
            '@ﾊﾞｯﾁ組情報ﾃﾞｰﾀが0件か
            If mtypBatLotList.lngBatLotCnt = 0 Then
                
                '@0件の場合
                Exit Sub
            Else
                '@1件以上ある場合(ﾊﾞｯﾁ組情報ﾃﾞｰﾀ)
                
                '@ﾊﾞｯﾁ組情報数を格納
                llngCnt = mtypBatLotList.lngBatLotCnt - 1
                
                '@ﾊﾞｯﾁ組情報のﾊﾞｯﾁ組ﾛｯﾄ数が0件か
                If mtypBatLotList.typBatLot(llngCnt).lngBatLotListCnt = 0 Then
                    
                    '@0件の場合、処理終了
                    Exit Sub
                Else
                    '@1件以上ある場合(ﾊﾞｯﾁ組情報のﾊﾞｯﾁ組ﾛｯﾄ数)

                    '@装置ﾀｲﾌﾟが"19：斜方蒸着装置"以外か
                    If mtypBatLotList.typBatLot(llngCnt).strEqType <> CPstrEqTypeJyoucyaku Then
                        
                        '@"19：斜方蒸着装置"以外の場合、処理終了
                        Exit Sub
                    Else
                        '@"19：斜方蒸着装置"の場合
                    
                        llngDoCnt = 0
                        
                        Do While mtypBatLotList.typBatLot(llngCnt).lngBatLotListCnt > llngDoCnt
                            
                            '@CFﾌﾗｸﾞが"0：TFT基板ﾛｯﾄ"か
                            If (mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strCfFlag = CPstrZero) Then
                                '@"0：TFT基板ﾛｯﾄ"の場合
                                
                                '@ﾚｽﾎﾟﾝｽ計測開始
                                Call pubResponseStart(CMstrFormName, CMstrPrvEasyCombCheck)
                                
                                '@=======================
                                '@ 簡易統合実施可否ﾁｪｯｸ
                                '@=======================
                                lblnAns = pubblnLotChkEasyCombine_sel(CMstrlot_chkeasycombineVer, _
                                                                      pstrSBID, _
                                                                      mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLotID, _
                                                                      mstrResult, _
                                                                      lstrCarrierID, _
                                                                      lstrLotID)
                                
                                '@簡易統合実施可否ﾁｪｯｸ結果が"True：成功"か
                                If lblnAns Then
                                    
                                    '@ﾚｽﾎﾟﾝｽ計測終了
                                    Call publngResponseEnd(CMstrFormName, CMstrPrvEasyCombCheck)
                                    
                                    '@統合可否結果が"1：統合不可"か
                                    If mstrResult = CPstrOne Then

                                        '@統合不可なら処理終了
                                        Exit Sub
                                    End If
                                Else
                                
                                    '@ﾚｽﾎﾟﾝｽ計測ｷｬﾝｾﾙ
                                    Call pubResponseCancel(CMstrFormName, CMstrPrvEasyCombCheck)
                                    Exit Sub
                                End If
                            End If
                            
                            llngDoCnt = llngDoCnt + 1
                        Loop
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvEasyComb_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub


	'関数名：prvAfterJReserveAction
    '機　能：蒸着後流動予約自動処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：ｷｬﾘｱ交換
    Private Sub prvAfterJReserveAction(ByVal lstrCarrierId As String, ByVal lstrLotId As String)

		Try
			       
			Dim lblnAns							As Boolean							 '結果取得(True:正常,False:異常)
			Dim ltypAfterJReserveDetailListA	As New List(Of typAfterJReserveDetail)	 'グループAの予約情報
			Dim ltypAfterJReserveDetailListB	As New List(Of typAfterJReserveDetail)	'グループBの予約情報
			Dim ltypAfterJReserveDetailListC	As New List(Of typAfterJReserveDetail)	'グループCの予約情報
			Dim ltypAfterJReserveDetailListD	As New List(Of typAfterJReserveDetail)	'グループDの予約情報
			Dim ltypNoReserveWfList				As New List(Of WfList)					'予約情報なしのWFリスト
			Dim ltypWaferList					As Waferlist						'ロットのWFリスト
			Dim lstrAJRchkResult As Boolean

			'@ﾛｯﾄWF情報取得
			lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, lstrCarrierID, CPstrCD0T, ltypWaferList)

			If lblnAns = True Then
				'ロットに対して蒸着後流動予約を取得し、各グループに分割する
				lstrAJRchkResult = prvAfterJReserveChk(lstrCarrierID, lstrLotId, ltypWaferList, _
													   ltypAfterJReserveDetailListA, _
														ltypAfterJReserveDetailListB, _
														ltypAfterJReserveDetailListC, _
														ltypAfterJReserveDetailListD, _
														ltypNoReserveWfList)

				If lstrAJRchkResult = True Then
					'取得OKの場合

					'グループが混在しているかを確認する
					'分割後のロットIDとキャリアID
					Dim lstrDivideLotId As String
					Dim lstrDivideCarrierId As String
					'グループAが存在し、混在している場合グループAとその他で分割を行う
					If ltypAfterJReserveDetailListA.Count > 0 Then
						'予約情報のあるロットIDを処理済みロットとして格納しておく
						mtypAJRLot.Add(lstrLotId)
						If ltypAfterJReserveDetailListB.Count > 0 Or ltypAfterJReserveDetailListC.Count > 0 Or ltypAfterJReserveDetailListD.Count > 0 _
							Or ltypNoReserveWfList.Count > 0 Then
							'混在しているのでAのみを分割する処理　
							'AグループリストのWFIDを取得、分割用新規ロット作成、分割用新規仮想ｷｬﾘｱ作成 自動分割処理
							'グループ毎の自動分割処理
							lblnAns = prvblnDivideGroup(lstrCarrierID, lstrLotId,  lstrDivideCarrierId, lstrDivideLotId, ltypAfterJReserveDetailListA, ltypWaferList)

							If lblnAns = True And lstrDivideLotId <> vbNullString  And lstrDivideCarrierId <> vbNullString Then
								'グループ毎の分割が行われた場合
								'作業終了ロットから統合対象を取得し、対象がいれば統合を行う(対象は子ロット側)
								'その後ｷｬﾘｱ交換判定→交換もこの関数内で行う
								Call prvblnCombineList(lstrDivideCarrierId, lstrDivideLotId, ltypAfterJReserveDetailListA, ltypWaferList)

								'分割後の親ロット(残っている方)に対して再起的に処理を実施
								Call prvAfterJReserveAction(lstrCarrierID, lstrLotId)

							End If

						Else
							'Aグループのみ存在
							'自動統合処理
							'蒸着工程作業終了ロットから統合対象を取得する
							Call prvblnCombineList(lstrCarrierID, lstrLotId,  ltypAfterJReserveDetailListA, ltypWaferList)

						End If

					Else If ltypAfterJReserveDetailListB.Count > 0 Then
						'予約情報のあるロットIDを処理済みロットとして格納しておく
						mtypAJRLot.Add(lstrLotId)
						If ltypAfterJReserveDetailListC.Count > 0 Or ltypAfterJReserveDetailListD.Count > 0 _
						Or ltypNoReserveWfList.Count > 0 Then
							'Aグループは存在せず、Bグループとその他で混在している場合
							'グループ毎の自動分割処理
							lblnAns = prvblnDivideGroup(lstrCarrierID, lstrLotId, lstrDivideCarrierId, lstrDivideLotId, ltypAfterJReserveDetailListB, ltypWaferList)
							If lblnAns = True And lstrDivideLotId <> vbNullString Then
								'作業終了ロットから統合対象を取得し、対象がいれば統合を行う
								'その後ｷｬﾘｱ交換判定→交換まで行う
								Call prvblnCombineList(lstrDivideCarrierId, lstrDivideLotId, ltypAfterJReserveDetailListB, ltypWaferList)
								
								'分割後の親ロット(残っている方)に対して再起的に処理を実施
								Call prvAfterJReserveAction(lstrCarrierID, lstrLotId)

							End If
						Else
							'Bグループのみ
							'グループ毎の自動統合処理
							'作業終了ロットから統合対象を取得し、対象がいれば統合を行う
							'その後ｷｬﾘｱ交換判定→交換まで行う
							Call prvblnCombineList(lstrCarrierID, lstrLotId,  ltypAfterJReserveDetailListB, ltypWaferList)
						End If

					Else If ltypAfterJReserveDetailListC.Count > 0 Then
						'予約情報のあるロットIDを処理済みロットとして格納しておく
						mtypAJRLot.Add(lstrLotId)
						'A、Bグループは存在せず、Cグループとその他で混在している場合
						If ltypAfterJReserveDetailListD.Count > 0 Or ltypNoReserveWfList.Count > 0 Then
							'グループ毎の自動分割処理
							lblnAns = prvblnDivideGroup(lstrCarrierID, lstrLotId, lstrDivideCarrierId, lstrDivideLotId, ltypAfterJReserveDetailListC, ltypWaferList)
							If lblnAns = True And lstrDivideLotId <> vbNullString Then
								'作業終了ロットから統合対象を取得し、対象がいれば統合を行う
								'その後ｷｬﾘｱ交換判定→交換もこの関数内で行う
								Call prvblnCombineList(lstrDivideCarrierId, lstrDivideLotId, ltypAfterJReserveDetailListC, ltypWaferList)

								'分割後の親ロット(残っている方)に対して再起的に処理を実施
								Call prvAfterJReserveAction(lstrCarrierID, lstrLotId)
							End If
						Else
							'Cグループのみ
							'グループ毎の自動統合処理
							Call prvblnCombineList(lstrCarrierID, lstrLotId, ltypAfterJReserveDetailListC, ltypWaferList)
						End If


					Else If ltypAfterJReserveDetailListD.Count > 0 Then
						'予約情報のあるロットIDを処理済みロットとして格納しておく
						mtypAJRLot.Add(lstrLotId)
						'A、B、Cグループは存在せず、Dグループと予約なしで混在している場合
						If ltypNoReserveWfList.Count > 0 Then
							'グループ毎の自動分割処理
							lblnAns = prvblnDivideGroup(lstrCarrierID, lstrLotId, lstrDivideCarrierId,  lstrDivideLotId, ltypAfterJReserveDetailListD, ltypWaferList)
							If lblnAns = True And lstrDivideLotId <> vbNullString Then
								'作業終了ロットから統合対象を取得し、対象がいれば統合を行う
								'その後ｷｬﾘｱ交換判定→交換もこの関数内で行う
								Call prvblnCombineList(lstrDivideCarrierId, lstrDivideLotId, ltypAfterJReserveDetailListD, ltypWaferList)

								'分割後の親ロット(残っている方)に対して再起的に処理を実施
								Call prvAfterJReserveAction(lstrCarrierID, lstrLotId)
							End If
						Else
							'Dグループのみ
							'グループ毎の自動統合処理
							'作業終了ロットから統合対象を取得し、対象がいれば統合を行う
							'その後ｷｬﾘｱ交換判定→交換もこの関数内で行う
							Call prvblnCombineList(lstrCarrierID, lstrLotId, ltypAfterJReserveDetailListD, ltypWaferList)

						End If

					Else
						'予約ロットなし
						'次のロットの処理へ
						Exit Sub
					End If
				End If
			End If

			Exit Sub

		Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvAfterJReserveAction"			'処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


	'関数名：prvAfterJReserveChk
    '機　能：'ロットに対して蒸着後流動予約を取得し、各A~Dのグループ毎に構造体へ格納する
    '引　数：
    '　　　：
    '戻り値：
    '作成日：
    '更新日：
    '備　考：
    '　　　：
    Private Function prvAfterJReserveChk(ByVal lstrCarrierId As String, ByVal lstrLotId As String, ByRef ltypWaferList As Waferlist, _
										 ByRef ltypAfterJReserveDetailListA As List(Of typAfterJReserveDetail), _
										 ByRef ltypAfterJReserveDetailListB As List(Of typAfterJReserveDetail), _
									     ByRef ltypAfterJReserveDetailListC As List(Of typAfterJReserveDetail), _
										 ByRef ltypAfterJReserveDetailListD As List(Of typAfterJReserveDetail), _
										 ByRef ltypNoReserveWfList As List(Of WfList) )

		Dim lblnAns				As Boolean
		Dim llngCnt				As Integer
		Dim llngWfCnt			As Integer
		Dim lblnGroupAFlag      As Boolean
		Dim lblnGroupBFlag      As Boolean
		Dim lblnGroupCFlag      As Boolean
		Dim lblnGroupDFlag      As Boolean
		Dim lblnNoReserveFlag   As Boolean
		Dim ltypAfterJReserveDetail			As AfterJReserveDetailList	'蒸着後流動予約情報格納用構造体

        Try
           'キャリア、ロットIDが空の場合は終了
			if lstrCarrierId = vbNullstring Or lstrLotId = vbNullString Then
				Return False
				Exit Function
			End If

			'初期化
			lblnGroupAFlag = False
			lblnGroupBFlag = False
			lblnGroupCFlag = False
			lblnGroupDFlag = False
			lblnNoReserveFlag = False
			ltypAfterJReserveDetailListA = New List(Of typAfterJReserveDetail)
			ltypAfterJReserveDetailListB = New List(Of typAfterJReserveDetail)
			ltypAfterJReserveDetailListC = New List(Of typAfterJReserveDetail)
			ltypAfterJReserveDetailListD = New List(Of typAfterJReserveDetail)
			ltypNoReserveWfList = New List(Of WfList) 

			'@取得OKなら既に蒸着後流動予約があるか確認
			'@ロット内の全てのWFに対して蒸着後流動予約情報取得する
			'CLASS_DIVISION 4X 
			lblnAns = pubblnGetAfterJReserveDetail(CMstrlot_afterjrsvdetailVer, lstrCarrierId, lstrLotId, "", "", CPstrCD4X, _
														ltypWaferList.typWfList, ltypAfterJReserveDetail)

			'@結果確認
			If lblnAns = True Then

				'最初に対象ロット内に別のグループが混在しているか確認
				If ltypAfterJReserveDetail.lngAfterJReserveDetailListCnt > 0 Then
					If ltypAfterJReserveDetail.strNGFlag = CPstrFlagOn Then
						'ロット内に複数の予約IDが混在している場合はそのロットは自動処理しない
						'@表示ﾒｯｾｰｼﾞ変換
						'@「"<TRM197W>$$ロット[%1]は複数の予約IDが混在しているため[%2]できません。"」のﾒｯｾｰｼﾞを表示
						pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0197,lstrLotId,"自動分割・統合")
						Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
						Return False
					End If 

					'1件以上存在する場合
					'各WFの予約情報を予約グループ毎に分岐
					llngWfCnt = 0
					 Do While ltypWaferList.lngListCnt -1 >= llngWfCnt
						Dim lstrTmpWfId As String = ltypWaferList.typWfList(llngWfCnt).strWfId
						Dim　lblnFindFlag = False
						For llngCnt = 0 To ltypAfterJReserveDetail.lngAfterJReserveDetailListCnt - 1
							With ltypAfterJReserveDetail.typAfterJReserveDetailList(llngCnt)
								If lstrTmpWfId = .strWfID
									'WFリストのWFと予約情報のWFが一致
									lblnFindFlag = True

									'予約グループ毎に分岐
									Select Case .strReserveGroup
										Case CMstrReserveGroupA
											'予約グループがAだった場合
											ltypAfterJReserveDetailListA.Add(ltypAfterJReserveDetail.typAfterJReserveDetailList(llngCnt))
											lblnGroupAFlag = True
										Case CMstrReserveGroupB
											'予約グループがBだった場合
											ltypAfterJReserveDetailListB.Add(ltypAfterJReserveDetail.typAfterJReserveDetailList(llngCnt))
											lblnGroupBFlag = True
										Case CMstrReserveGroupC
											'予約グループがCだった場合
											ltypAfterJReserveDetailListC.Add(ltypAfterJReserveDetail.typAfterJReserveDetailList(llngCnt))
											lblnGroupCFlag = True
										Case CMstrReserveGroupD
											'予約グループがDだった場合
											ltypAfterJReserveDetailListD.Add(ltypAfterJReserveDetail.typAfterJReserveDetailList(llngCnt))
											lblnGroupDFlag = True
										Case Else
						
									End Select
								End If
					
							End With
						Next
							If lblnFindFlag = False Then
								'予約なしWF
								lblnNoReserveFlag = True
								ltypNoReserveWfList.Add(ltypWaferList.typWfList(llngCnt))
							End If
						llngWfCnt = llngWfCnt + 1
					Loop
				
					Return True
				
				Else
					Return False
				End if
						
			End If
           
			Return True
            Exit Function
           
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvAfterJReserveChk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
                        
        End Try
    End Function


	'関数名：prvblnDivideGroup
    '機　能：
    '引　数：
    '　　　：
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    '　　　：
    Private Function prvblnDivideGroup(ByRef lstrCarrierId As String, _
									   ByRef lstrLotId As String, _
									   ByRef lstrDivideCarrierId As String, _
									   ByRef lstrDivideLotId As String, _
									   ByRef ltypAfterJReserveDetailListA As List(Of typAfterJReserveDetail), _
									   ByRef ltypWaferList As Waferlist )
        	
		Dim lblnAns						As Boolean
		Dim llngCnt						As Integer
		Dim llngWfCnt					As Integer
		Dim lstrDummyCarrierId			As String
		Dim lstrTmpDivideLotId			As String 
		Dim ltypUsechange				As Lotdivide				'Lot分割(要求)
		Dim lstrMsg						As String					'変換後ﾒｯｾｰｼﾞ1
        Dim lstrGuidMsg					As String					'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode				As String					'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
		Dim ltypAfterJReserveDetail		As AfterJReserveDetailList	'蒸着後流動予約情報格納用構造体
		Dim lstrLotLastUpdate			As String					'ロット最終更新日時
		Dim ltypLotReserveIns			As LotReserve				'投入予定ロット登録ﾒｯｾｰｼﾞ用
		Dim ltypLotCurState				As Lotprestate				'ﾛｯﾄ現在状態格納構造体
        Try

			prvblnDivideGroup = False

           'キャリア、ロットIDが空の場合は終了
			if lstrCarrierId = vbNullstring Or lstrLotId = vbNullString Then
				Return False
				Exit Function
			End If

			lstrTmpDivideLotId = lstrDivideLotId
			lstrDummyCarrierId = lstrDivideCarrierId

			'初期化
			ltypLotReserveIns = New LotReserve
			lstrDivideLotId = ""
			lstrDivideCarrierId = ""
			'念のため空なら初期化
			If IsNothing(ltypAfterJReserveDetailListA) Then
				ltypAfterJReserveDetailListA = New List(Of typAfterJReserveDetail)
			End If

			'@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnDivideGroup)
			'@最終更新日時取得(統合や分割が行われている可能性があるためここで改めて取得する)
            '@DBからﾛｯﾄ情報の取得
             lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, CPstrCD02, "", ltypLotCurState, lstrLotId)
			If lblnAns = True Then
				lstrLotLastUpdate = ltypLotCurState.strLotLastUpdate
			Else
				Return False
				Exit Function
			End If

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotReserveIns
                
                .strSbID = pstrSBID
                
                '@親画面から引き渡されたﾛｯﾄIDがNULL以外か
                If lstrLotId <> vbNullString Then

                    .strDivideLotID = lstrLotId         '分割ﾛｯﾄID
                    .strCopySeqLotID = lstrLotId        '分割元ﾛｯﾄID
                Else
                    Exit Function
                End If

                '@分割ﾛｯﾄ&工順ｺﾋﾟｰ(0N0Q)
                .strClassDivision = CPstrCD0N & CPstrCD0Q
                
                '@分割ﾛｯﾄ作成の場合は機種&WF数は必要なし
                .strPdId = vbNullString                 'NULL
                .strWfNum = CMstrWFDefault              '0

                .strFlowClass = ""										'流動区分(蒸着後流動予約では不要？　→　サーバー側で取得してくれる)
                .strEngEmpId = ""										'技術担当者(蒸着後流動予約では不要？　→　サーバー側で取得してくれる)
                .strPlanThrowinDate = Format$(Now, CPstrDateTimeYMD)    '投入予定日
                .strLotSendFlag = ""									'送品ﾌﾗｸﾞ(蒸着後流動予約では不要？　→　サーバー側で取得してくれる)
                .strPROrderID = ""										'PRオーダー(蒸着後流動予約では不要？　→　サーバー側で取得してくれる)
                
                '@ﾕｰｻﾞｰIDは"工程管理ﾕｰｻﾞｰ(9999995)"とする
                .strEmpID = CPstrEasyLotDivideUserID
            End With

			  '@【ﾛｯﾄ投入予約】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnLotThrowrsv_Ins(CMstrlot_throwrsvVer, _
                                            ltypLotReserveIns)
            
            '@ﾛｯﾄ投入予約結果判定
            If lblnAns = True Then
                '@ﾛｯﾄ投入予約結果：正常の場合
            
                '@ﾛｯﾄID
                lstrTmpDivideLotId = ltypLotReserveIns.strLotID
                        
                '@【ﾛｯﾄ予約承認】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnLotApprove_Ins(CMstrlot_approveVer, _
                                               ltypLotReserveIns)
                
                '@ﾛｯﾄ予約承認結果判定
                If lblnAns = True Then
                    '@ﾛｯﾄ予約承認結果：正常の場合
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0003, lstrTmpDivideLotId)
                    '@ﾒｯｾｰｼﾞ："<TRM03I>$$投入予定ロット[%1]を登録しました。"
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)

                    '@作業ﾒﾓｸﾘｱ
                    txtWorkMemo.Text = vbNullString

					'分割先用仮想ｷｬﾘｱ取得
                    lstrDummyCarrierId = prvGetDummyCarrierId()

					If lstrDummyCarrierId <> "" And lstrTmpDivideLotId <> "" Then
						'分割先ロットと仮想キャリアが取得できたら分割処理
						'@***********************
						'@ 分割確定ﾃﾞｰﾀ作成
						'@***********************
						With ltypUsechange

							.strMsgVer = CMstrlot_dividedirectVer       '移載工程なし
							.strLotID = lstrLotId                      '分割元ﾛｯﾄID
							.strDivideLotID = lstrTmpDivideLotId          '分割先ﾛｯﾄID
							.strComments = txtWorkMemo.Text                 '作業ﾒﾓ
							.strEmpID = CPstrEasyLotDivideUserID            '作業者ｺｰﾄﾞ
							.strLotLastUpdate = lstrLotLastUpdate           '最終更新日時
							.strToCarrierId = lstrDummyCarrierId            '分割先ｷｬﾘｱID(取得した仮想ｷｬﾘｱ)
                
							'@ｽﾛｯﾄﾏｯﾌﾟ処理
							.typWFMap = New List(Of DivideWFMap)()

							'ロット内のWFの中からグループに該当するWFのみ分割先として格納する
							llngWfCnt = 0
							Do While ltypWaferList.lngListCnt -1 >= llngWfCnt
								Dim lstrTmpWfId As String = ltypWaferList.typWfList(llngWfCnt).strWfId
								Dim lblnFindFlag = False
								For llngCnt = 0 To ltypAfterJReserveDetailListA.Count - 1
									With ltypAfterJReserveDetailListA(llngCnt)
										If lstrTmpWfId = .strWfID
											'WFリストのWFと予約情報のWFが一致
											Dim typ As DivideWFMap = New DivideWFMap
											typ.strSlotPosition = ltypWaferList.typWfList(llngWfCnt).strSlotPosition        'ｽﾛｯﾄ№
											typ.strWfID = ltypWaferList.typWfList(llngWfCnt).strWfId          'WFID
											ltypUsechange.typWFMap.Add(typ)

										End If
					
									End With
								Next

								llngWfCnt = llngWfCnt + 1
							Loop

						End With


						'@=======================
						'@ ﾛｯﾄ分割(移載工程なし)
						'@=======================
						lblnAns = pubblnLotDivideDirect_Upd(ltypUsechange, lstrGuidMsg, lstrGuidMsgCode)
                

						'@ﾛｯﾄ分割結果が"True：成功"か
						If lblnAns = True Then
							lstrMsg = "ロット分割"
							'@"<TRM31I>$$[%1]しました。分割元キャリア[%2] 分割元ロット[%3] 分割先キャリア[%4] 分割先ロット[%5]"のﾒｯｾｰｼﾞ表示
							pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0031, lstrMsg, lstrCarrierId, lstrLotId, lstrDummyCarrierId, lstrTmpDivideLotId)

							'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
							Call pubResponseCancel(Me.Name, CMstrPrvblnDivideGroup)
                
							'@=======================
							'@ ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ表示制御
							'@=======================
							Call pubGuidMsg_Set(lstrGuidMsgCode, lstrGuidMsg, Me)
                
							'@成功ﾒｯｾｰｼﾞ表示
							Call pubVsfInfo_Disp(pstrDMsg)

							'空にしていた引数を更新する(分割されなければ空で返す)
							lstrDivideCarrierId = lstrDummyCarrierId
							lstrDivideLotId = lstrTmpDivideLotId

							'分割済み構造体へ格納
							Dim ltypDivideLot As typDivideLot
							With ltypDivideLot
								.strLotId = lstrLotId				'分割元ロット
								.strDivideLotId = lstrDivideLotId	'分割先ロット
							End With
							mtypDivideLot.Add(ltypDivideLot)

						Else
							'@ﾛｯﾄ分割結果が"False：失敗"の場合
            
							'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
							Call pubResponseCancel(Me.Name, CMstrPrvblnDivideGroup)
						End If


					Else
						'分割ロット、もしくは仮想ｷｬﾘｱが用意できなかった場合
						Return False

					End If
                    
					Return True
                End If
            End If

           
            Exit Function
           
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnDivideGroup"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
                        
        End Try
    End Function

	'関数名：prvGetDummyCarrierId
    '機　能：仮想ｷｬﾘｱID取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    '　　　：
    Private Function prvGetDummyCarrierId()

        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim llngCarrierIDSerialNum  As Integer              'ｷｬﾘｱIDの連番
        Dim ltypCarrierList         As CarrList             'ｷｬﾘｱ一覧取得結果格納用
        Dim ltypCarrierListReq      As CarrierListReq       '仮想ｷｬﾘｱ検索送信ﾃﾞｰﾀ格納用
        Dim ltypCarrierAdd          As CarrierAdd           '
        Dim lblnAns                 As Boolean              '戻り値格納用
        Dim lblnMakeAns             As Boolean              '
        Dim lstrFormatSerialNum     As String               'ﾌｫｰﾏｯﾄしたｷｬﾘｱIDの連番
        
        Try
            
            '@簡易分割仮想ｷｬﾘｱの初期化
            mstrDumCarrierID = vbNullString
            
            '@***********************
            '@ 仮想ｷｬﾘｱ検索送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypCarrierListReq

                .strMsgVer = CMstrcarrlist____Ver               'ﾒｯｾｰｼﾞVer
                .strClassDivision = CPstrCD02                   '処理区分(02：全て)
                .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸID
                .strCarrierTypeID = CMstrDumCarrierTypeID       'ｷｬﾘｱﾀｲﾌﾟ(CARRSYS0：簡易分割用仮想ｷｬﾘｱのﾀｲﾌﾟ)
            End With
            
            '@=======================
            '@ ｷｬﾘｱ一覧取得(空き仮想ｷｬﾘｱ)
            '@=======================
            lblnAns = pubblnCarrList_Sel(ltypCarrierListReq, _
                                         ltypCarrierList)
            
            '@ｷｬﾘｱ一覧取得結果が"True：取得成功"か
            If lblnAns = True Then

                With ltypCarrierList
                    
                    '@ｷｬﾘｱIDの連番の初期化
                    llngCarrierIDSerialNum = 1
                    
                    '@-----------------------
                    '@ 空き仮想ｷｬﾘｱがなければ無条件でｷｬﾘｱを作成
                    '@-----------------------
                    '@空き仮想ｷｬﾘｱﾘｽﾄが0件か
                    If .lngCarrierListCnt = 0 Then
                        '@0件の場合
                        
                        '@仮想ｷｬﾘｱ情報を作成("I"+"NNNNN")
                        lstrFormatSerialNum = Format$(CLng(llngCarrierIDSerialNum), CMstrFormatCarrIdSerial)
                        ltypCarrierAdd.strCarrierId = CMstrDumCarrierFirstWords & lstrFormatSerialNum
                        ltypCarrierAdd.strSbID = pstrSBID
                        ltypCarrierAdd.strStartTime = Format$(Now, CPstrDateTimeYMD)
                        ltypCarrierAdd.strCarrierTypeID = CMstrDumCarrierTypeID
                        ltypCarrierAdd.strProductionDate = Format$(Now, CPstrDateTimeYMD)
                    Else
                        '@空き仮想ｷｬﾘｱがある場合
                    
                        '@対象のｷｬﾘｱがあれば使えるもののみ(1ｷｬﾘｱだけ)を探す
                        For llngCnt = 0 To .lngCarrierListCnt - 1
                            
                            '@WF搭載なし、かつﾛｯﾄID紐付きなしか
                            If .typCarrierList(llngCnt).strEmptyFlag <> CMstrAri And _
                                .typCarrierList(llngCnt).strLotID = vbNullString Then

                                '@仮想ｷｬﾘｱ退避変数に退避
                                mstrDumCarrierID = .typCarrierList(llngCnt).strCarrierId
                                Exit For
                            Else
                                '@WF搭載あり、またはﾛｯﾄID紐付きありの場合
                                
                                '@ｷｬﾘｱIDの連番と仮想ｷｬﾘｱﾘｽﾄの件数が同じか
                                If llngCarrierIDSerialNum = .lngCarrierListCnt Then
                                    
                                    '@ｼﾘｱﾙ部分をｲﾝｸﾘﾒﾝﾄする
                                    '@ｷｬﾘｱIDでORDER BYしているので最後のﾘｽﾄのIDをMAX値としてｲﾝｸﾘﾒﾝﾄする
                                    llngCarrierIDSerialNum = CLng(Strings.Right(.typCarrierList(llngCnt).strCarrierId, 5))
                                    llngCarrierIDSerialNum = llngCarrierIDSerialNum + 1
                                    
                                    '@使えるものがないので、ｷｬﾘｱIDを生成
                                    lstrFormatSerialNum = Format$(CLng(llngCarrierIDSerialNum), CMstrFormatCarrIdSerial)
                                    ltypCarrierAdd.strCarrierId = CMstrDumCarrierFirstWords & lstrFormatSerialNum
                                    ltypCarrierAdd.strSbID = pstrSBID
                                    ltypCarrierAdd.strStartTime = Format$(Now, CPstrDateTimeYMD)
                                    ltypCarrierAdd.strCarrierTypeID = CMstrDumCarrierTypeID
                                    ltypCarrierAdd.strProductionDate = Format$(Now, CPstrDateTimeYMD)
                                End If
                            End If
                            
                            '@ｷｬﾘｱIDの連番を+1する
                            llngCarrierIDSerialNum = llngCarrierIDSerialNum + 1
                        Next
                    End If
                    
                    '@仮想ｷｬﾘｱIDの作成情報があるか
                    If ltypCarrierAdd.strCarrierId <> vbNullString Then
                        
                        '@=======================
                        '@ ｷｬﾘｱ新規追加
                        '@=======================
                        lblnMakeAns = pubblnCarrierID_Ins(CMstrcarradditionVer, _
                                                          ltypCarrierAdd)
                        
                        '@仮想ｷｬﾘｱ退避変数に新規登録したｷｬﾘｱIDを退避
                        mstrDumCarrierID = ltypCarrierAdd.strCarrierId
                    End If
                End With
            End If
            
            '@仮想ｷｬﾘｱIDをｱﾝﾛｰﾀﾞｷｬﾘｱIDにｾｯﾄ
            'txtToCarrier.Text = mstrDumCarrierID
            Return mstrDumCarrierID

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGetDummyCarrierId"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function


	'関数名：prvblnCombineList
    '機　能：蒸着工程作業終了ロットから統合対象(同一予約ID,予約グループのみで構成されたロット)を取得
	'	　：存在すれば統合処理を行う
	'	　：最後にｷｬﾘｱ交換判定と実施
    '引　数：
    '　　　：
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    '　　　：
    Private Sub prvblnCombineList(ByVal lstrCarrierId As String, ByVal lstrLotId As String,
										 ByRef ltypAfterJReserveDetailList As List(Of typAfterJReserveDetail), _
										 ByRef ltypWaferList As Waferlist )
        	
		Dim lblnAns						As Boolean
		Dim llngCnt						As Integer
		Dim lstrDummyCarrierId			As String
		Dim ltypAfterJReserveDetail		As typAfterJReserveDetail	'蒸着後流動予約情報格納用構造体
		Dim ltypAfterJRsvCombineList	As typAfterJRsvCombine		'蒸着後流動予約分割取得ﾒｯｾｰｼﾞ用
		Dim lstrLotId1					As String					'処理ロットID(統合があれば統合後に更新される)
		Dim lstrCarrierId1				As String					'処理ｷｬﾘｱID(統合があれば統合後に更新される)
		Dim ltypChkCombineLotIn			As typChkCombineLotIn		'ﾛｯﾄ統合時ﾁｪｯｸの送受信ﾒｯｾｰｼﾞ格納
        Try

           'キャリア、ロットIDが空の場合は終了
			if lstrCarrierId = vbNullstring Or lstrLotId = vbNullString Then
				Exit Sub
			End If

			'蒸着後流動予約情報が空の時は終了
			If isNothing(ltypAfterJReserveDetailList) Then
				Exit Sub
			End If

			If ltypAfterJReserveDetailList.Count < 1 Then
				Exit Sub
			End If

			'初期化
			ltypAfterJReserveDetail = New typAfterJReserveDetail
			lstrDummyCarrierId = ""

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypAfterJReserveDetail
                If ltypAfterJReserveDetailList.Count > 0 Then
					.strReserveId = ltypAfterJReserveDetailList(0).strReserveId
					.strReserveGroup = ltypAfterJReserveDetailList(0).strReserveGroup
					.strLotId = lstrLotId
				End If
            End With
			

			'@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrprvblnCombineList)

			  '@【蒸着後流動予約統合ロット取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnGetAfterJReserveCombineList(CMstrlot_afterjrsvcombinelistVer, _
                                            ltypAfterJReserveDetail, ltypAfterJRsvCombineList)
            
			'@統合元になるロットの情報
			lstrLotId1 = lstrLotId
			lstrCarrierId1 = lstrCarrierId

            '@蒸着後流動予約統合ロット取得結果判定
            If lblnAns = True Then
                '@蒸着後流動予約統合ロット取得結果：正常の場合
				
				If ltypAfterJRsvCombineList.lngAfterJReserveDetailListCnt > 0 Then
					'統合対象ロットが存在する場合
					Dim lstrCarrierId2 As String ' 統合相手
					Dim lstrLotId2 As String ' 統合相手
					Dim lstrPdId1 = ltypAfterJRsvCombineList.strPdId
					Dim lstrStepId1 = ltypAfterJRsvCombineList.strStepId

					'統合対象が存在する場合 順番に参照してロットIDが変わる度に統合を試みる
					For llngCnt = 0 To ltypAfterJRsvCombineList.lngAfterJReserveDetailListCnt - 1
						With ltypAfterJRsvCombineList.typAfterJReserveDetailList(llngCnt)
							
							'統合先のロット
							If lstrLotId2 <> vbNullString And lstrLotId2 <> "" And lstrLotId2 = .strLotId 
								'統合先が空（初回）でなくロットIDが変化しない場合は飛ばす
								Continue For
							End If
							'統合先ロットID更新
							lstrLotId2 = .strLotId
							lstrCarrierId2 = .strCarrierId

							'念のため空ではないか確認
							'統合元ロットIDと異なる場合
							If lstrLotId1 <> lstrLotId2 And lstrLotId2 <> vbNullString Then
								'統合前事前確認
								'@機種確認
								If lstrPdId1 <> ltypAfterJRsvCombineList.strPdId Then
									'@"<TRM5YW>$$機種が異なります。同一機種でロットを統合してください。"
									pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005Y)
									'@警告ﾒｯｾｰｼﾞ
									Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
									Exit Sub
								End If
            
								'@派生元ﾛｯﾄ確認
								If Strings.Left$(lstrLotId1, CMlngLeftLength) <> Strings.Left$(lstrLotId2, CMlngLeftLength) Then
									'@"<TRM59W>$$分割元ロットが異なります。同一ロットから分割されたロットを統合してください。"
									pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0059)
									'@警告ﾒｯｾｰｼﾞ
									Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
									Exit Sub
								End If
            
								'@小工程確認
								If lstrStepId1 <> .strStepId Then
									'@"<TRM60W>$$小工程が異なります。同一小工程でロットを統合してください。"
									pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0060)
									'@警告ﾒｯｾｰｼﾞ
									Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
									Exit Sub
								End If


								'CPstrCD4X
								If pstrSBID = CPstrSBID2A0 Then
                
									'@構造体に値をｾｯﾄ
									With ltypChkCombineLotIn

										.strSbID = pstrSBID
										'@画面上の2ﾛｯﾄのｳｪﾊｰﾘｽﾄをltypChkCombineLotInに格納
										Call prvWaferListSet(lstrlotId1, ltypAfterJReserveDetailList, ltypChkCombineLotIn)   '画面左のﾛｯﾄのｳｪﾊｰﾘｽﾄｾｯﾄ
										Call prvWaferListSet(lstrlotId2, ltypAfterJRsvCombineList.typAfterJReserveDetailList, ltypChkCombineLotIn)  '画面右のﾛｯﾄのｳｪﾊｰﾘｽﾄｾｯﾄ
                    
										'@再利用WFか否かの判定ﾌﾗｸﾞｾｯﾄ(ﾛｯﾄとWFの先頭7文字が同一か
										If Mid$(.strWfList(0), 1, 7) = Mid$(lstrLotId1, 1, 7) Then
											'@再利用ﾛｯﾄじゃない
											.strRecyclFlag = "0"
										Else
											'@再利用ﾛｯﾄである
											.strRecyclFlag = "1"
										End If
                    
									End With
                
									'@ 投入時のﾛｯﾄが共通か確認
									lblnAns = prvblnCombineInLot_Chk(CMstrlot_chkcombineLotInVer, ltypChkCombineLotIn)
                
									'@確定時ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か(関数自体の失敗成功ﾁｪｯｸ)
									If lblnAns = False Then
										Exit Sub
									End If
                
									'@投入元ﾛｯﾄは同じかの確認結果は、OK以外か(統合OK/NGのﾁｪｯｸ)
									If ltypChkCombineLotIn.strResult <> CMstrResultOK Then
                    
										'@"<TRM146W>$$[%1]投入時のロットが異なるため統合できません。"
										pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0146, CPstrSBID2A0Name)
										'@警告ﾒｯｾｰｼﾞ
										Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

										Exit Sub
									End If
								End If

								'統合処理関数呼び出し
								'統合されたロットを元ロットにして再びロット統合判定→終了したらｷｬﾘｱ交換判定
								'lstrLotId1とlstrCarrierId1が統合後ロットID、ｷｬﾘｱIDに更新される
								lblnAns =　prvblnCombineLot(lstrLotId1, lstrLotId2, lstrCarrierId1)

								If lblnAns = False Then
									Exit Sub
								End If
							End If

						End With

					Next


				End If

				'統合先が無くなれば自動キャリア交換に進む
				'ｷｬﾘｱ交換判定
				'統合終了後にｷｬﾘｱ交換判定と実施(統合相手がいなかった場合も含む）
				Call prvCarrierMove(lstrCarrierId1, lstrLotId1)

            End If

            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnCombineList"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
                        
        End Try
    End Sub

    '関数名：prvblnCombineLot
    '機　能：ロットを統合する
    '引　数：
    '　　　：lstrLotId1：統合元ロットID(統合後に統合後ロットIDに更新される）
    '　　　：lstrLotId2：統合元ロットID
    '　　　：lstrCarrierId1：(統合後に統合後ｷｬﾘｱIDIDに更新される）
    '戻り値：
    '作成日：
    '更新日：
    '備　考：
    Private Function prvblnCombineLot(ByRef lstrLotId1 As String, ByVal lstrLotId2 As String, ByRef lstrCarrierId1 As String)

        Dim llngRowCnt     As Integer
        Dim llngWaferCnt   As Integer
		Dim ltyplotcombine          As Lotcombine           'Lot統合(要求)	
		Dim lblnAns                 As Boolean              '戻り値(True:正常,False:異常)
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrMsg                 As String               '成功ﾒｯｾｰｼﾞ文字
		Dim ltypLotCurState1         As Lotprestate          'ﾛｯﾄ現在状態格納構造体
		Dim ltypLotCurState2         As Lotprestate          'ﾛｯﾄ現在状態格納構造体
		Dim lstrLotLastUpdate1		As String
		Dim lstrLotLastUpdate2		As String


		prvblnCombineLot = False
        Try

            llngRowCnt = 0     'typAfterJReserveDetail用
            llngWaferCnt = 0	'

             '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, CMstrprvblnCombine)

			'@最終更新日時取得(統合や分割が行われている可能性があるためここで改めて取得する)
            '@DBからﾛｯﾄ情報の取得
             lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, CPstrCD1B, "", ltypLotCurState1,lstrLotId1)
			If lblnAns = True Then
				lstrLotLastUpdate1 = ltypLotCurState1.strLotLastUpdate
			End If
			 
			'@DBからﾛｯﾄ情報の取得
            lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, CPstrCD1B, "", ltypLotCurState2,lstrLotId2)
			If lblnAns = True Then
				lstrLotLastUpdate2 = ltypLotCurState2.strLotLastUpdate
			End If

            '@ﾛｯﾄ統合ﾃﾞｰﾀ作成
            With ltyplotcombine
                .strMsgVer = CMstrlot_combinedirectVer      '移載工程なし
				.strClassDivision = CPstrCD4X				'自動統合用に追加
                .strLotID1 = lstrLotId1                   'ﾛｯﾄID(1)
                .strLotID2 = lstrLotId2                 'ﾛｯﾄID(2)
                .strLotLastUpdate1 = lstrLotLastUpdate1         '最終更新日時(1)
                .strLotLastUpdate2 = lstrLotLastUpdate2         '最終更新日時(2)
                .strEmpID = CPstrEasyLotDivideUserID             '@ﾕｰｻﾞｰIDは"工程管理ﾕｰｻﾞｰ(9999995)"とする
            End With
            

            '@ﾒｯｾｰｼﾞ送信【ﾛｯﾄ統合(一括移載)】
            lblnAns = pubblnLotCombineDirect_Upd(ltyplotcombine, lstrGuidMsg, lstrGuidMsgCode)
            lstrMsg = "ロット統合"
 
            
            '@結果判定
            If lblnAns = True Then
                '@ﾌｫｰﾑﾛｯｸ解除
                'Me.Enabled = True
                 '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, CMstrprvblnCombine)
                
                '@ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ表示制御
                Call pubGuidMsg_Set(lstrGuidMsgCode, lstrGuidMsg, Me)
            
                '@成功ﾒｯｾｰｼﾞ用ｷｬﾘｱID取得処理(応答Msgのﾛｯﾄと紐付くｷｬﾘｱを取得)
				'統合先ｷｬﾘｱIDを更新
                If ltyplotcombine.strCombineLotID = lstrLotId1 Then
                    lstrCarrierId1 = ltypLotCurState1.strCarrierId
                Else
                    lstrCarrierId1 = ltypLotCurState2.strCarrierId
                End If
                
                '@"<TRM55I>$$[%1]しました。統合先キャリア[%2] 統合先ロット[%3]"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0055, lstrMsg, lstrCarrierId1, ltyplotcombine.strCombineLotID)
                '@成功ﾒｯｾｰｼﾞ
                Call pubVsfInfo_Disp(pstrDMsg)

				Dim ltypCombineLot As typCombineLot
				With ltypCombineLot
					'統合先がLOT1の場合は統合元にLOT２を設定。統合先がLOT2の場合は統合元にLOT1を設定
					If ltyplotcombine.strCombineLotID = lstrLotId1 Then
						.strLotId =  lstrLotId2
					Else
						.strLotId =  lstrLotId1
					End If
					.strCombineLotId =  ltyplotcombine.strCombineLotID

				End With
				mtypCombineLot.Add(ltypCombineLot)

				'統合元ロットIDを統合先ロットに更新する
				'これが引数として返る
				lstrLotId1 = ltyplotcombine.strCombineLotID
                
				prvblnCombineLot = True

            Else

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrprvblnCombine)
				prvblnCombineLot = False
            End If

			Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnCombineLot"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

	'関数名：prvWaferListSet
    '機　能：ｳｪﾊｰﾘｽﾄをltypChkCombineLotInに格納する
    '引　数：
    '　　　：ltypChkCombineLotIn：ｳｪﾊｰﾘｽﾄ格納用構造体
    '戻り値：
    '作成日：
    '更新日：
    '備　考：
    Private Sub prvWaferListSet(ByVal lstrLotId As String, ByRef ltypAfterJReserveDetailList As List(Of typAfterJReserveDetail), ByRef ltypChkCombineLotIn As typChkCombineLotIn)

        Dim llngRowCnt     As Integer
        Dim llngWaferCnt   As Integer
            
        Try

            llngRowCnt = 0     'typAfterJReserveDetail用
            llngWaferCnt = 0	'

            With ltypChkCombineLotIn

                If .strWfList Is Nothing Then
                    .strWfList = New List(Of String)
                End If

				If IsNothing(ltypAfterJReserveDetailList) Then
					Exit Sub
				End If

                '@ｸﾞﾘｯﾄﾞの行分Loop
                Do While ltypAfterJReserveDetailList.Count > llngRowCnt
                
                    '@行は空以外か
					'@引数のロットIDと同じか
                    If ltypAfterJReserveDetailList(llngRowCnt).strWfId <> vbNullString And _
						ltypAfterJReserveDetailList(llngRowCnt).strLotId = lstrLotId Then
						
                        Dim strWfListTmp As String 

                        strWfListTmp = ltypAfterJReserveDetailList(llngRowCnt).strWfId
                        .strWfList.Add(strWfListTmp)

                        '@要素追加
                        llngWaferCnt = llngWaferCnt + 1
                    
                    End If
                    
                    llngRowCnt = llngRowCnt + 1
                Loop
                
                '@ｳｪﾊｰﾘｽﾄ数を格納(元々入っている分もあるのでﾌﾟﾗｽする)
                .lngWfListCnt = .lngWfListCnt + llngWaferCnt
            
            End With
               
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWaferListSet"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：prvCarrierMove
    '機　能：ｷｬﾘｱ交換確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：ｷｬﾘｱ交換
    Private Sub prvCarrierMove(ByVal lstrCarrierId As String, ByVal lstrLotId As String)

        Dim lblnAns                 As Boolean          '戻り値
		Dim lblnChk                 As Boolean          '戻り値
        Dim llngCnt                 As Integer          'ｶｳﾝﾄ
        Dim llngWFListCnt           As Integer          'WFﾘｽﾄｶｳﾝﾄ
        Dim llngWFCnt1              As Integer          'WFｶｳﾝﾄ1
        Dim llngWFCnt2              As Integer          'WFｶｳﾝﾄ2
        Dim ltypCarrMove            As CarrMove         'ｷｬﾘｱ統合(交換)構造体(要求)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim ltypAfterJReserveDetailList As  AfterJReserveDetailList

        Try

           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
			If lstrCarrierId = vbNullString Or lstrLotId = vbNullString Then
				Exit Sub
			End If

            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "prvCarrierMove"
            Call pubResponseStart(lstrFormName, lstrEventName)

			'ｷｬﾘｱ交換前確認(予約グループの全てのWFが揃っているか確認する）
			lblnChk = prvCarrierMoveChk(lstrCarrierId, lstrLotId, ltypAfterJReserveDetailList)
            
			If lblnChk = False Or ltypAfterJReserveDetailList.lngAfterJReserveDetailListCnt < 1 Then

				'チェックNGの場合はそのまま終了
				Exit Sub

			End If

            '@ﾛｯﾄ投入ﾃﾞｰﾀ作成
            With ltypCarrMove
                .strClassDivision = CPstrCD4X               '処理区分(移載代用)
                .strCarrierID1 = lstrCarrierId				'交換元ｷｬﾘｱID
                .strCarrierID2 = ltypAfterJReserveDetailList.typAfterJReserveDetailList(0).strCarrierId				'交換先ｷｬﾘｱID
                .strEmpID =   CPstrEasyLotDivideUserID      '自動処理なのでシステムユーザー

                '@ｵﾝﾗｲﾝﾌﾗｸﾞの処理判別
                .strOnlineFlag = CMlngoptOffline
                
                '@交換元WFはないので"0"を格納
                llngWFCnt1 = 0
                
                '@交換先WFがある場合
                If ltypAfterJReserveDetailList.lngAfterJReserveDetailListCnt > 0 Then
                    '@WFMap処理
                    .typWFMapList2 = New List(Of WFMapList)()

                    '@WFﾘｽﾄｶｳﾝﾄ
                    llngWFListCnt = 0
                    llngCnt = 0

                    '@交換先WF格納
                    For llngCnt = 0 To ltypAfterJReserveDetailList.lngAfterJReserveDetailListCnt - 1 
                        '@空白以外の場合
                        If ltypAfterJReserveDetailList.lngAfterJReserveDetailListCnt <> vbNullString Then
                            Dim tmpWFMapList As WFMapList = New WFMapList()
                            tmpWFMapList.strSlotPosition _
                                = ltypAfterJReserveDetailList.typAfterJReserveDetailList(llngCnt).strSlotPosition     'ｽﾛｯﾄ№
                                
                            tmpWFMapList.strWfId _
                                = ltypAfterJReserveDetailList.typAfterJReserveDetailList(llngCnt).strWfId      'WFID
                            
							'蒸着のバッチ作業終了後なのでJIG情報は削除されているはず
                           ' tmpWFMapList.strjigId _
                            '    = ltypAfterJReserveDetailList.typAfterJReserveDetailList(llngCnt).strd    '治具ID

                            .typWFMapList2.Add(tmpWFMapList)
                            llngWFListCnt = llngWFListCnt + 1
                        End If
                    Next llngCnt
                End If

				llngWFCnt2 = llngWFListCnt
                
                '@ﾒｯｾｰｼﾞ送信処理呼び出し
                lblnAns = pubblnCarrMove_Upd(CMstrcarrmove____Ver, ltypCarrMove, llngWFCnt1, llngWFCnt2)
                '@結果判定
                If lblnAns = True Then
 
                   '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002P, CMstrAuto, .strCarrierID1, .strCarrierID2)

                    
                    '@成功ﾒｯｾｰｼﾞｽﾃｰﾀｽﾊﾞｰ表示(%1:ｵﾝﾗｲﾝORｵﾌﾗｲﾝ)
                    '@pubVsfInfo_Disp("ﾒｯｾｰｼﾞｺｰﾄﾞ：<TRM2PI>$$%1交換しました。交換元キャリア[%2]、交換先キャリア[%3]")
                    Call pubVsfInfo_Disp(pstrDMsg)
                                                       
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
					
					Dim ltypCarrierMoveLot As typCarrierMoveLot
					With ltypCarrierMoveLot
						.strLotId = lstrLotId
					End With
					mtypCarrierMoveLot.Add(ltypCarrierMoveLot)                    
                    
                    Exit Sub
                End If
            End With
            
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(lstrFormName, lstrEventName)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvCarrierMove"			'処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：prvCarrierMoveChk
    '機　能：ｷｬﾘｱ交換前確認処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：ｷｬﾘｱ交換前確認
    Private Function prvCarrierMoveChk(ByRef lstrCarrierId As String, ByRef lstrLotId As String, ByRef ltypAfterJReserveDetailList As  AfterJReserveDetailList )

        Dim lblnAns                 As Boolean          '戻り値
        Dim llngCnt                 As Integer          'ｶｳﾝﾄ
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
		Dim ltypWaferList			As Waferlist
		Dim ltypAfterJReserveDetailListChk As  AfterJReserveDetailList
		Dim lstrReserveId			As String
		Dim lstrReserveGroup		As String

        Try

			prvCarrierMoveChk =  False

           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Function
            End If
            
			If lstrCarrierId = vbNullString Or lstrLotId = vbNullString Then
				Exit Function
			End If

            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "prvCarrierMoveChk"
            Call pubResponseStart(lstrFormName, lstrEventName)

            
			'@WF情報取得
			'@交換元ロットのWF情報取得（分割、統合で変わっている可能性もあるためここで再取得、治具IDも含めて)
			lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, lstrCarrierId, CPstrCD0T, ltypWaferList)


			if lblnAns = False Then
				Exit Function
			End If

			'蒸着後流動予約情報取得(移載先のｷｬﾘｱIDが正しいか知る為）
			lblnAns = pubblnGetAfterJReserveDetail(CMstrlot_afterjrsvdetailVer, lstrCarrierId, lstrLotId, "", "", CPstrCD4X, _
													ltypWaferList.typWfList, ltypAfterJReserveDetailList)

			if lblnAns = True And ltypAfterJReserveDetailList.strNGFlag = False Then
				'結果OK+重複なし
				If ltypAfterJReserveDetailList.lngAfterJReserveDetailListCnt > 0 Then
					'1件以上取得できた場合は、予約IDとグループで
					'@取得OKなら交換先のｷｬﾘｱIDが同じか、確認する

					lstrReserveId = ltypAfterJReserveDetailList.typAfterJReserveDetailList(0).strReserveId
					lstrReserveGroup = ltypAfterJReserveDetailList.typAfterJReserveDetailList(0).strReserveGroup
					
					'予約IDと予約グループが取得できなければ終了
					If lstrReserveId = "" Or lstrReserveGroup = "" Then
						Exit Function
					End If

					'予約IDと予約グループを指定して蒸着後流動予約情報取得し、全てのWFが揃っているか比較する
					lblnAns = pubblnGetAfterJReserveDetail(CMstrlot_afterjrsvdetailVer, "", "", lstrReserveId, lstrReserveGroup, CPstrCD4X, _
													ltypWaferList.typWfList, ltypAfterJReserveDetailListChk)

					If lblnAns = True Then

						'数が一致しているか
						If ltypAfterJReserveDetailList.lngAfterJReserveDetailListCnt = ltypAfterJReserveDetailListChk.lngAfterJReserveDetailListCnt Then
							'数が同じ場合は個別要素を確認(WF_IDと予約グループと移載先ｷｬﾘｱが同じか）
							'WF_IDソート済み
							For llngCnt = 0 To ltypAfterJReserveDetailList.lngAfterJReserveDetailListCnt - 1 
								With ltypAfterJReserveDetailList.typAfterJReserveDetailList(llngCnt)
									If .strReserveId <> ltypAfterJReserveDetailListChk.typAfterJReserveDetailList(llngCnt).strReserveId Or _
										.strReserveGroup <> ltypAfterJReserveDetailListChk.typAfterJReserveDetailList(llngCnt).strReserveGroup Or _
										.strWfId <> ltypAfterJReserveDetailListChk.typAfterJReserveDetailList(llngCnt).strWfId Or _
										.strCarrierId <> ltypAfterJReserveDetailListChk.typAfterJReserveDetailList(llngCnt).strCarrierId Then

										'どれか1つでも異なれば揃っていない判定
										'WF数が同じなのに予約情報と異なる場合
										'エラー
										'@"<TRM199W>$$ロット[%1]は、蒸着後流動予約と[%2]が異なるため[%3]できません。確認してください。"
										pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0199, lstrLotId, "構成", "ｷｬﾘｱ交換" )
										Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
										Exit Function

									End If

								End With

							Next
							
							'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝはｷｬﾘｱ交換時に実施

							
						Else
							
							'数が異なる場合は揃っていない判定
							Exit Function

								
						End If

					Else
						Exit Function

					End If

				Else
					'エラー
					'@"<TRM196W>$$予約情報が見つかりませんでした。データを確認してください。"
					pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0196)
					Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
					pubSetFocus(txtCarrier)
					Exit Function
				End If


			Else
				Exit Function

			End If

			'全てOK
			prvCarrierMoveChk = True
			Return prvCarrierMoveChk

            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvCarrierMoveChk"      '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfBatList.BeforeDoubleClick, vsfNextStepInfo.BeforeDoubleClick

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
    '機　能 ： 項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考 ： Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles cmdClose.Enter, _
            cmdActionDisp.Enter, cmdCommntInput.Enter, cmdCollectionInfo.Enter, cmdTrouble.Enter, _
            cmdTreatWF.Enter, cmdWorkRecord.Enter, cmdRegist.Enter, _
            txtCarrier.Enter, txtWorkMemo.Enter, txtLotCommnt.Enter, _
            cmdUP.Enter, cmdDown.Enter, cmdLeft.Enter, cmdRight.Enter, cmdNextUP.Enter, cmdNextDown.Enter, _
            cmdMemoUp.Enter, cmdMemoDown.Enter, cmdTxtUp.Enter, cmdTxtDown.Enter, _
            optLotNextSend0.Enter, optLotNextSend1.Enter, vsfBatList.Enter, vsfNextStepInfo.Enter

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

End Class
