'ﾌｧｲﾙ名：xxEN00F0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：在庫管理　メインフォーム
'作成日：2004/06/25 (Fri) 11:27:52 S.Deguchi
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00F0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00F0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00F0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00F0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00F0)
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
    '@↓2020/03/06 (Fri) 11:10:11 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion                 As String = "31.00"
    Private Const CMstrLocalVersion                 As String = "32.00"
    '@↑2020/03/06 (Fri) 11:10:11 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN00F0            'ﾛｰｶﾙ機能ID
                                                                                          
    '@Msgﾊﾞｰｼﾞｮﾝ                                                                          
    Private Const CMstrinv_complotlistVer           As String = "05.00"                   '送品待在庫ﾛｯﾄﾘｽﾄ
    Private Const CMstrinv_acptlotlistVer           As String = "05.00"                   '在庫ﾛｯﾄﾘｽﾄ
    '@↓2020/01/27 (Mon) 16:05:09 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrinv_waferlistVer             As String = "03.02"                 'ｳｪﾊ在庫情報取得
    Private Const CMstrinv_waferlistVer             As String = "04.00"                 'ｳｪﾊ在庫情報取得
    '@↑2020/01/27 (Mon) 16:05:09 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrinv_lotlist_Ver              As String = "02.01"                   '在庫ﾛｯﾄﾘｽﾄ取得
    Private Const CMstrinv_getsendorderlistVer      As String = "03.01"                   '送品伝票情報取得
    Private Const CMstrinv_getlotexaminfoVer        As String = "03.00"                   'ﾛｯﾄ検定表情報取得
    Private Const CMstrlot_holdlistVer              As String = "04.01"                   '保留在庫ﾛｯﾄ情報取得
    Private Const CMstrlot_send____Ver              As String = "02.00"                   'ﾛｯﾄ送品
    Private Const CMstrlot_detail__Ver              As String = "03.00"                   'ﾛｯﾄ詳細情報
    Private Const CMstrmas_flowlistVer              As String = "04.00"                   '種別区分一覧取得
    Private Const CMstrmas_pdlist__Ver              As String = "03.00"                   '機種区分一覧取得
    Private Const CMstrmas_sblist__Ver              As String = "01.00"                   'ｼｽﾃﾑﾌﾞﾛｯｸ取得
    Private Const CMstrmas_sendsblistVer            As String = "01.00"                   '送品先ﾘｽﾄ取得

    '@vsfLotListPutの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfPutColNo                  As Integer = 0                        '№
    Private Const CMlngvsfPutColKb                  As Integer = 1                        '「分/移/保」表示
    Private Const CMlngvsfPutColDivideStatus        As Integer = 2                        '分割状態
    Private Const CMlngvsfPutColEntryTime           As Integer = 3                        '受入日
    Private Const CMlngvsfPutColCarrierID           As Integer = 4                        'ｷｬﾘｱID
    Private Const CMlngvsfPutColLotID               As Integer = 5                        'ﾛｯﾄID
    Private Const CMlngvsfPutColGrbClass            As Integer = 6                        'GRB区分
    Private Const CMlngvsfPutColFlowClass           As Integer = 7                        '種別
    Private Const CMlngvsfPutColPriority            As Integer = 8                        '優先度
    Private Const CMlngvsfPutColPDName              As Integer = 9                        '機種名
    Private Const CMlngvsfPutColWfNum               As Integer = 10                       'WF
    Private Const CMlngvsfPutColCfNum               As Integer = 11                       'ﾁｯﾌﾟ
    Private Const CMlngvsfPutColLostChipInfo        As Integer = 12                       '欠損ﾁｯﾌﾟ情報
    Private Const CMlngvsfPutColStayTime            As Integer = 13                       '停滞時間
    Private Const CMlngvsfPutColToCarrierID1        As Integer = 14                       '移載先ｷｬﾘｱID1
    Private Const CMlngvsfPutColToCarrierID2        As Integer = 15                       '移載先ｷｬﾘｱID2
    Private Const CMlngvsfPutColHoldFlag            As Integer = 16                       '保留ﾌﾗｸﾞ
    Private Const CMlngvsfPutColHoldTime            As Integer = 17                       '保留開始日
    Private Const CMlngvsfPutColHoldTermDate        As Integer = 18                       '保留期限
    Private Const CMlngvsfPutColHoldStayDate        As Integer = 19                       '保留期間
    Private Const CMlngvsfPutColHoldEmpID           As Integer = 20                       '保留担当者ID
    Private Const CMlngvsfPutColHoldEmpName         As Integer = 21                       '保留担当者
    Private Const CMlngvsfPutColHoldReasonCode      As Integer = 22                       '保留理由ID
    Private Const CMlngvsfPutColHoldReasonName      As Integer = 23                       '保留理由
    Private Const CMlngvsfPutColLotComments         As Integer = 24                       'ﾛｯﾄｺﾒﾝﾄ内容
    Private Const CMlngvsfPutColLotCommentDisp      As Integer = 25                       'ﾛｯﾄｺﾒﾝﾄ有無
    Private Const CMlngvsfPutColInvComments         As Integer = 26                       'SB連絡ｺﾒﾝﾄ内容
    Private Const CMlngvsfPutColInvCommentDisp      As Integer = 27                       'SB連絡ｺﾒﾝﾄ有無
    Private Const CMlngvsfPutColEngEmpID            As Integer = 28                       'ﾛｯﾄ担当者ID
    Private Const CMlngvsfPutColEngEmpName          As Integer = 29                       'ﾛｯﾄ担当者名
    Private Const CMlngvsfPutColWfCarryFlag         As Integer = 30                       'WF移載ﾌﾗｸﾞ
    Private Const CMlngvsfPutColSlotSize            As Integer = 31                       'ｽﾛｯﾄｻｲｽﾞ
    Private Const CMlngvsfPutColLastUpdate          As Integer = 32                       '最終更新日時

    '@vsfLotListPutの定数宣言(幅)
    Private Const CMlngvsfPutWColNo                 As Integer = 33                       '№
    Private Const CMlngvsfPutWColKb                 As Integer = 21                       '「分/移/保」表示
    Private Const CMlngvsfPutWColDivideStatus       As Integer = 19                       '分割状態
    Private Const CMlngvsfPutWColEntryTime          As Integer = 73                       '受入日
    Private Const CMlngvsfPutWColCarrierID          As Integer = 104                      'ｷｬﾘｱID
    Private Const CMlngvsfPutWColLotID              As Integer = 90                       'ﾛｯﾄID
    Private Const CMlngvsfPutWColGrbClass           As Integer = 33                       'GRB区分
    Private Const CMlngvsfPutWColFlowClass          As Integer = 25                       '種別
    Private Const CMlngvsfPutWColPriority           As Integer = 25                       '優先度
    Private Const CMlngvsfPutWColPDName             As Integer = 49                       '機種名
    Private Const CMlngvsfPutWColWfNum              As Integer = 25                       'WF
    Private Const CMlngvsfPutWColCfNum              As Integer = 73                       'ﾁｯﾌﾟ
    Private Const CMlngvsfPutWColLostChipInfo       As Integer = 73                       '欠損ﾁｯﾌﾟ情報
    Private Const CMlngvsfPutWColStayTime           As Integer = 90                       '停滞時間
    Private Const CMlngvsfPutWColToCarrierID1       As Integer = 163                      '移載先ｷｬﾘｱID1
    Private Const CMlngvsfPutWColToCarrierID2       As Integer = 163                      '移載先ｷｬﾘｱID2
    Private Const CMlngvsfPutWColHoldFlag           As Integer = 90                       '保留ﾌﾗｸﾞ
    Private Const CMlngvsfPutWColHoldTime           As Integer = 104                      '保留開始日
    Private Const CMlngvsfPutWColHoldTermDate       As Integer = 104                      '保留期限
    Private Const CMlngvsfPutWColHoldStayDate       As Integer = 104                      '保留期間
    Private Const CMlngvsfPutWColHoldEmpID          As Integer = 104                      '保留担当者ID
    Private Const CMlngvsfPutWColHoldEmpName        As Integer = 104                      '保留担当者
    Private Const CMlngvsfPutWColHoldReasonCode     As Integer = 104                      '保留理由ID
    Private Const CMlngvsfPutWColHoldReasonName     As Integer = 90                       '保留理由
    Private Const CMlngvsfPutWColLotComments        As Integer = 90                       'ﾛｯﾄｺﾒﾝﾄ内容
    Private Const CMlngvsfPutWColLotCommentDisp     As Integer = 47                       'ﾛｯﾄｺﾒﾝﾄ有無
    Private Const CMlngvsfPutWColInvComments        As Integer = 90                       'SB連絡ｺﾒﾝﾄ内容
    Private Const CMlngvsfPutWColInvCommentDisp     As Integer = 47                       'SB連絡ｺﾒﾝﾄ有無
    Private Const CMlngvsfPutWColEngEmpID           As Integer = 47                       'ﾛｯﾄ担当者ID
    Private Const CMlngvsfPutWColEngEmpName         As Integer = 104                      'ﾛｯﾄ担当者名
    Private Const CMlngvsfPutWColWfCarryFlag        As Integer = 47                       'WF移載ﾌﾗｸﾞ
    Private Const CMlngvsfPutWColSlotSize           As Integer = 47                       'ｽﾛｯﾄｻｲｽﾞ
    Private Const CMlngvsfPutWColLastUpdate         As Integer = 121                      '最終更新日時

    '@vsfLotListPutの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfPutColNo                  As String = "№"                      '№
    Private Const CMstrvsfPutColKb                  As String = ""                        '「分/移/保」表示
    Private Const CMstrvsfPutColDivideStatus        As String = "分割状態"                '分割状態
    Private Const CMstrvsfPutColEntryTime           As String = "受入日"                  '受入日
    Private Const CMstrvsfPutColCarrierID           As String = "キャリアID"              'ｷｬﾘｱID
    Private Const CMstrvsfPutColLotID               As String = "ロットID"                'ﾛｯﾄID
    Private Const CMstrvsfPutColGrbClass            As String = "GRB"                     'GRB区分
    Private Const CMstrvsfPutColFlowClass           As String = "種"                      '種別
    Private Const CMstrvsfPutColPriority            As String = "優"                      '優先度
    Private Const CMstrvsfPutColPDName              As String = "機種"                    '機種名
    Private Const CMstrvsfPutColWfNum               As String = "WF"                      'WF
    Private Const CMstrvsfPutColCfNum               As String = "チップ"                  'ﾁｯﾌﾟ
    Private Const CMstrvsfPutColLostChipInfo        As String = "欠損"                    '欠損ﾁｯﾌﾟ情報
    Private Const CMstrvsfPutColStayTime            As String = "停滞時間"                '停滞時間
    Private Const CMstrvsfPutColToCarrierID1        As String = "移載先キャリアID1"       '移載先ｷｬﾘｱID1
    Private Const CMstrvsfPutColToCarrierID2        As String = "移載先キャリアID2"       '移載先ｷｬﾘｱID2
    Private Const CMstrvsfPutColHoldFlag            As String = "保留ﾌﾗｸﾞ"                '保留ﾌﾗｸﾞ
    Private Const CMstrvsfPutColHoldTime            As String = "保留開始日"              '保留開始日
    Private Const CMstrvsfPutColHoldTermDate        As String = "保留期限"                '保留期限
    Private Const CMstrvsfPutColHoldStayDate        As String = "保留期間"                '保留期間
    Private Const CMstrvsfPutColHoldEmpID           As String = "保留担当者ID"            '保留担当者ID
    Private Const CMstrvsfPutColHoldEmpName         As String = "保留担当者"              '保留担当者
    Private Const CMstrvsfPutColHoldReasonCode      As String = "保留理由ID"              '保留理由ID
    Private Const CMstrvsfPutColHoldReasonName      As String = "保留理由"                '保留理由
    Private Const CMstrvsfPutColLotComments         As String = "コメント内容"            'ﾛｯﾄｺﾒﾝﾄ内容
    Private Const CMstrvsfPutColLotCommentDisp      As String = "コメント"                'ﾛｯﾄｺﾒﾝﾄ有無
    Private Const CMstrvsfPutColInvComments         As String = "前SB連絡内容"            'SB連絡ｺﾒﾝﾄ内容
    Private Const CMstrvsfPutColInvCommentDisp      As String = "前SB連絡"                'SB連絡ｺﾒﾝﾄ有無
    Private Const CMstrvsfPutColEngEmpID            As String = "ロット担当者ID"           'ﾛｯﾄ担当者ID
    Private Const CMstrvsfPutColEngEmpName          As String = "ロット担当者"             'ﾛｯﾄ担当者名
    Private Const CMstrvsfPutColWfCarryFlag         As String = "WF移載ﾌﾗｸﾞ"              'WF移載ﾌﾗｸﾞ
    Private Const CMstrvsfPutColSlotSize            As String = "ｽﾛｯﾄｻｲｽﾞ"                'ｽﾛｯﾄｻｲｽﾞ
    Private Const CMstrvsfPutColLastUpdate          As String = "最終更新日時"            '最終更新日時

    '@vsfLotListHoldの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfHoldColNo                 As Integer = 0                        '№
    Private Const CMlngvsfHoldColHoldTime           As Integer = 1                        '保留開始日
    Private Const CMlngvsfHoldColHoldTimeEnd        As Integer = 2                        '保留期限
    Private Const CMlngvsfHoldColStatus             As Integer = 3                        'LOT状態　(和名対応)
    Private Const CMlngvsfHoldColCarrierID          As Integer = 4                        'ｷｬﾘｱID
    Private Const CMlngvsfHoldColLotID              As Integer = 5                        'ﾛｯﾄID
    Private Const CMlngvsfHoldColFlowClass          As Integer = 6                        '種別
    Private Const CMlngvsfHoldColPDName             As Integer = 7                        '機種名
    Private Const CMlngvsfHoldColWfNum              As Integer = 8                        'WF
    Private Const CMlngvsfHoldColCfNum              As Integer = 9                        'ﾁｯﾌﾟ
    Private Const CMlngvsfHoldColOpID               As Integer = 10                       '大工程
    Private Const CMlngvsfHoldColStepID             As Integer = 11                       '小工程
    Private Const CMlngvsfHoldColWpID               As Integer = 12                       '装置名
    Private Const CMlngvsfHoldColHoldFlag           As Integer = 13                       '保留ﾌﾗｸﾞ
    Private Const CMlngvsfHoldColHoldStay           As Integer = 14                       '保留期間
    Private Const CMlngvsfHoldColHoldReasonID       As Integer = 15                       '保留理由ID
    Private Const CMlngvsfHoldColHoldReason         As Integer = 16                       '保留理由
    Private Const CMlngvsfHoldColHoldEmpID          As Integer = 17                       '保留担当者ID
    Private Const CMlngvsfHoldColHoldEmp            As Integer = 18                       '保留担当者
    Private Const CMlngvsfHoldColEntryID            As Integer = 19                       'ｴﾝﾄﾘID
    Private Const CMlngvsfHoldColLotManagerName     As Integer = 20                       'ﾛｯﾄ担当者名
    Private Const CMlngvsfHoldColLotComments        As Integer = 21                       'ｺﾒﾝﾄ内容
    Private Const CMlngvsfHoldColLastUpdate         As Integer = 22                       '最終更新日時
    Private Const CMlngvsfHoldColLotCommentButton   As Integer = 23                       'ｺﾒﾝﾄ
    Private Const CMlngvsfHoldColSlotSize           As Integer = 24                       'ｽﾛｯﾄｻｲｽﾞ
    Private Const CMlngvsfHoldColLotManagerID       As Integer = 25                       'ﾛｯﾄ担当者ID

    '@vsfLotListHoldの定数宣言(幅)
    Private Const CMlngvsfHoldWColNo                As Integer = 33                        '№
    Private Const CMlngvsfHoldWColHoldTime          As Integer = 104                       '保留開始日
    Private Const CMlngvsfHoldWColHoldTimeEnd       As Integer = 104                       '保留期限
    Private Const CMlngvsfHoldWColStatus            As Integer = 49                        'LOT状態　(和名対応)
    Private Const CMlngvsfHoldWColCarrierID         As Integer = 104                       'ｷｬﾘｱID
    Private Const CMlngvsfHoldWColLotID             As Integer = 90                        'ﾛｯﾄID
    Private Const CMlngvsfHoldWColFlowClass         As Integer = 25                        '種別
    Private Const CMlngvsfHoldWColPDName            As Integer = 49                        '機種名
    Private Const CMlngvsfHoldWColWfNum             As Integer = 25                        'WF
    Private Const CMlngvsfHoldWColCfNum             As Integer = 73                        'ﾁｯﾌﾟ
    Private Const CMlngvsfHoldWColOpID              As Integer = 73                        '大工程
    Private Const CMlngvsfHoldWColStepID            As Integer = 73                        '小工程
    Private Const CMlngvsfHoldWColWpID              As Integer = 73                        '装置名
    Private Const CMlngvsfHoldWColHoldFlag          As Integer = 90                        '保留ﾌﾗｸﾞ
    Private Const CMlngvsfHoldWColHoldStay          As Integer = 90                        '保留期間
    Private Const CMlngvsfHoldWColHoldReasonID      As Integer = 90                        '保留理由ID
    Private Const CMlngvsfHoldWColHoldReason        As Integer = 90                        '保留理由
    Private Const CMlngvsfHoldWColHoldEmpID         As Integer = 90                        '保留担当者ID
    Private Const CMlngvsfHoldWColHoldEmp           As Integer = 104                       '保留担当者
    Private Const CMlngvsfHoldWColEntryID           As Integer = 90                        'ｴﾝﾄﾘID
    Private Const CMlngvsfHoldWColLotManagerName    As Integer = 104                       'ﾛｯﾄ担当者名
    Private Const CMlngvsfHoldWColLotComments       As Integer = 90                        'ｺﾒﾝﾄ内容
    Private Const CMlngvsfHoldWColLastUpdate        As Integer = 121                       '最終更新日時
    Private Const CMlngvsfHoldWColLotCommentButton  As Integer = 90                        'ｺﾒﾝﾄ
    Private Const CMlngvsfHoldWColSlotSize          As Integer = 47                        'ｽﾛｯﾄｻｲｽﾞ
    Private Const CMlngvsfHoldWColLotManagerID      As Integer = 47                        'ﾛｯﾄ担当者ID

    '@vsfLotListHoldの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfHoldColNo                 As String = "№"                       '№
    Private Const CMstrvsfHoldColHoldTime           As String = "保留開始日"               '保留開始日
    Private Const CMstrvsfHoldColHoldTimeEnd        As String = "保留期限"                 '保留期限
    Private Const CMstrvsfHoldColStatus             As String = "状態"                     'LOT状態　(和名対応)
    Private Const CMstrvsfHoldColCarrierID          As String = "キャリアID"               'ｷｬﾘｱID
    Private Const CMstrvsfHoldColLotID              As String = "ロットID"                 'ﾛｯﾄID
    Private Const CMstrvsfHoldColFlowClass          As String = "種"                       '種別
    Private Const CMstrvsfHoldColPDNAME             As String = "機種"                     '機種名
    Private Const CMstrvsfHoldColWfNum              As String = "WF"                       'WF
    Private Const CMstrvsfHoldColCfNum              As String = "チップ"                   'ﾁｯﾌﾟ
    Private Const CMstrvsfHoldColOpID               As String = "大工程"                   '大工程
    Private Const CMstrvsfHoldColStepID             As String = "小工程"                   '小工程
    Private Const CMstrvsfHoldColWpID               As String = "装置名"                   '装置名
    Private Const CMstrvsfHoldColHoldFlag           As String = "保留ﾌﾗｸﾞ"                 '保留ﾌﾗｸﾞ
    Private Const CMstrvsfHoldColHoldStay           As String = "保留期間"                 '保留期間
    Private Const CMstrvsfHoldColHoldReasonID       As String = "保留理由ID"               '保留理由ID
    Private Const CMstrvsfHoldColHoldReason         As String = "保留理由"                 '保留理由
    Private Const CMstrvsfHoldColHoldEmpID          As String = "保留担当者ID"             '保留担当者ID
    Private Const CMstrvsfHoldColHoldEmp            As String = "保留担当者"               '保留担当者
    Private Const CMstrvsfHoldColEntryID            As String = "エントリ"                 'ｴﾝﾄﾘID
    Private Const CMstrvsfHoldColLotManagerName     As String = "ロット担当"               'ﾛｯﾄ担当者名
    Private Const CMstrvsfHoldColLotComments        As String = "コメント内容"             'ｺﾒﾝﾄ内容
    Private Const CMstrvsfHoldColLastUpdate         As String = "最終更新日時"             '最終更新日時
    Private Const CMstrvsfHoldColLotCommentButton   As String = "コメント"                 'ｺﾒﾝﾄ
    Private Const CMstrvsfHoldColSlotSize           As String = "ｽﾛｯﾄｻｲｽﾞ"                 'ｽﾛｯﾄｻｲｽﾞ
    Private Const CMstrvsfHoldColLotManagerID       As String = "ロット担当者ID"           'ﾛｯﾄ担当者ID

    '@vsfLotListWFの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfWFColNo                   As Integer = 0                         '№
    Private Const CMlngvsfWFColPutDay               As Integer = 1                         '受入日
    Private Const CMlngvsfWFColCarrierID            As Integer = 2                         'ｷｬﾘｱID
    Private Const CMlngvsfWFColCarrierPosition      As Integer = 3                         'ｷｬﾘｱ位置
    Private Const CMlngvsfWFColLotID                As Integer = 4                         '元ﾛｯﾄID
    Private Const CMlngvsfWFColWfNum                As Integer = 5                         'WF
    Private Const CMlngvsfWFColCfNum                As Integer = 6                         'ﾁｯﾌﾟ
    Private Const CMlngvsfWFColLastUpdate           As Integer = 7                         '最終更新日
    Private Const CMlngvsfWFColSlotSize             As Integer = 8                         'ｽﾛｯﾄｻｲｽﾞ
    Private Const CMlngvsfWFColInfoFlag             As Integer = 9                         '情報取得ﾌﾗｸﾞ(0：未取得/1：取得済)
    Private Const CMlngvsfWFColCarrierEmpName       As Integer = 10                        '責任者名
    Private Const CMlngvsfWFColcarrierComments      As Integer = 11                        'ｺﾒﾝﾄ


    '@vsfLotListWFの定数宣言(幅)
    Private Const CMlngvsfWFWColNo                  As Integer = 33                       '№
    Private Const CMlngvsfWFWColPutDay              As Integer = 73                       '受入日
    Private Const CMlngvsfWFWColCarrierID           As Integer = 121                      'ｷｬﾘｱID
    Private Const CMlngvsfWFWColCarrierPosition     As Integer = 145                      'ｷｬﾘｱ位置
    Private Const CMlngvsfWFWColLotID               As Integer = 90                       '元ﾛｯﾄID
    Private Const CMlngvsfWFWColWfNum               As Integer = 73                       'WF
    Private Const CMlngvsfWFWColCfNum               As Integer = 73                       'ﾁｯﾌﾟ
    Private Const CMlngvsfWFWColLastUpdate          As Integer = 121                      '最終更新日
    Private Const CMlngvsfWFWColSlotSize            As Integer = 121                      'ｽﾛｯﾄｻｲｽﾞ
    Private Const CMlngvsfWFWColInfoFlag            As Integer = 121                      '情報取得ﾌﾗｸﾞ(0：未取得/1：取得済)
    Private Const CMlngvsfWFWColCarrierEmpName      As Integer = 121                      '責任者名
    Private Const CMlngvsfWFWColCarrierComments     As Integer = 121                      'ｺﾒﾝﾄ

    '@vsfLotListWFの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfWFColNo                   As String = "№"                      '№
    Private Const CMstrvsfWFColPutDay               As String = "受入日"                  '受入日
    Private Const CMstrvsfWFColCarrierID            As String = "キャリアID"              'ｷｬﾘｱID
    Private Const CMstrvsfWFColWfNum                As String = "WF"                      'WF
    Private Const CMstrvsfWFColCfNum                As String = "チップ"                  'ﾁｯﾌﾟ
    Private Const CMstrvsfWFColCarrierPosition      As String = "キャリア位置"            'ｷｬﾘｱ位置"
    Private Const CMstrvsfWFColLotID                As String = "元ロットID"              '元ﾛｯﾄID
    Private Const CMstrvsfWFColLastUpdate           As String = "最終更新日"              '最終更新日
    Private Const CMstrvsfWFColSlotSize             As String = "ｽﾛｯﾄｻｲｽﾞ"                'ｽﾛｯﾄｻｲｽﾞ
    Private Const CMstrvsfWFColInfoFlag             As String = "情報取得ﾌﾗｸﾞ"            '情報取得ﾌﾗｸﾞ(0：未取得/1：取得済)
    Private Const CMstrvsfWFColCarrierEmpName       As String = "責任者"                  '責任者名
    Private Const CMstrvsfWFColCarrierComments      As String = "コメント"                'ｺﾒﾝﾄ

    '@vsfCarrierInfoの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfCIColNo                   As Integer = 0                          '№
    Private Const CMlngvsfCIColWFID                 As Integer = 1                          'WF ID
    '@↓2020/02/07 (Fri) 14:44:56 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfCIColGRB                  As Integer = 2                          'GRB
    Private Const CMlngvsfCIColClassID              As Integer = 3                          'Class_ID
    Private Const CMlngvsfCIColStatus               As Integer = 4                          '状況
    '@↑2020/02/07 (Fri) 14:44:56 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@vsfCarrierInfoの定数宣言(幅)
    Private Const CMlngvsfCIWColNo                  As Integer = 33                         '№
    '@↓2020/02/07 (Fri) 14:46:20 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMlngvsfCIWColWFID                As Integer = 121                       'WF ID
    Private Const CMlngvsfCIWColWFID                As Integer = 100                        'WF ID
    Private Const CMlngvsfCIWColGRB                 As Integer = 30                         'GRB
    '@↑2020/02/07 (Fri) 14:46:20 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfCIWColClassID             As Integer = 10                         'Class_ID
    Private Const CMlngvsfCIWColStatus              As Integer = 60                         '状況

    '@vsfCarrierInfoの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfCIColNo                   As String = ""                          '№
    Private Const CMstrvsfCIColWFID                 As String = "WFID"                      'WF_ID
    Private Const CMstrvsfCIColClassID              As String = "Class_ID"                  'Class_ID
    Private Const CMstrvsfCIColStatus               As String = "状況"                        '状況
    '@↓2020/02/07 (Fri) 14:47:57 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrvsfCIColGRB                  As String = "GRB"                       'GRB
    '@↑2020/02/07 (Fri) 14:47:57 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@vsfLotListSendの定数宣言(ｶﾗﾑ)(送品待ち)
    Private Const CMlngvsfSendColNo                 As Integer = 0                        '№
    Private Const CMlngvsfSendColKb                 As Integer = 1                        '「保」表示
    Private Const CMlngvsfSendColPutDay             As Integer = 2                        '受入日
    Private Const CMlngvsfSendColCarrierID          As Integer = 3                        'ｷｬﾘｱID
    Private Const CMlngvsfSendColLotID              As Integer = 4                        'ﾛｯﾄID
    Private Const CMlngvsfSendColGrbClass           As Integer = 5                        'GRB区分
    Private Const CMlngvsfSendColFlowClass          As Integer = 6                        '種別
    Private Const CMlngvsfSendColPriority           As Integer = 7                        '優先度
    Private Const CMlngvsfSendColPDName             As Integer = 8                        '機種名
    Private Const CMlngvsfSendColWfNum              As Integer = 9                        'WF
    Private Const CMlngvsfSendColCfNum              As Integer = 10                       'ﾁｯﾌﾟ
    Private Const CMlngvsfSendColSendSBID           As Integer = 11                       '送品先
    Private Const CMlngvsfSendColSBSystemFlag       As Integer = 12                       'SBｼｽﾃﾑﾌﾗｸﾞ
    Private Const CMlngvsfSendColBoxNo              As Integer = 13                       '箱№
    Private Const CMlngvsfSendColAtlasOrderNo       As Integer = 14                       'ATLASｵｰﾀﾞｰ№
    Private Const CMlngvsfSendColStayTime           As Integer = 15                       '停滞時間
    Private Const CMlngvsfSendColLotCommentDisp     As Integer = 16                       'ｺﾒﾝﾄ有無
    Private Const CMlngvsfSendColCommentDisp        As Integer = 17                       '次SB連絡有無
    Private Const CMlngvsfSendColHoldFlag           As Integer = 18                       '保留ﾌﾗｸﾞ
    Private Const CMlngvsfSendColHoldTime           As Integer = 19                       '保留開始日
    Private Const CMlngvsfSendColHoldTimeEnd        As Integer = 20                       '保留期限
    Private Const CMlngvsfSendColHoldStayTime       As Integer = 21                       '保留期間
    Private Const CMlngvsfSendColHoldEmpID          As Integer = 22                       '保留担当者ID
    Private Const CMlngvsfSendColHoldEmp            As Integer = 23                       '保留担当者
    Private Const CMlngvsfSendColHoldReasonID       As Integer = 24                       '保留理由ID
    Private Const CMlngvsfSendColHoldReason         As Integer = 25                       '保留理由
    Private Const CMlngvsfSendColHoldComments       As Integer = 26                       '保留ｺﾒﾝﾄ
    Private Const CMlngvsfSendColLotComments        As Integer = 27                       'ｺﾒﾝﾄ内容
    Private Const CMlngvsfSendColLastUpdate         As Integer = 28                       '最終更新日時
    Private Const CMlngvsfSendColComment            As Integer = 29                       '次SB連絡内容
    Private Const CMlngvsfSendColSlotSize           As Integer = 30                       'ｽﾛｯﾄｻｲｽﾞ
    Private Const CMlngvsfSendColLotManagerID       As Integer = 31                       'ﾛｯﾄ担当者ID
    Private Const CMlngvsfSendColLotManagerName     As Integer = 32                       'ﾛｯﾄ担当者名
    Private Const CMlngvsfSendColLotSendFlag        As Integer = 33                       '送品ﾌﾗｸﾞ(0:送品なし、1:送品あり)

    '@vsfLotListSendの定数宣言(幅)(送品待ち)
    Private Const CMlngvsfSendWColNo                As Integer = 33                       '№
    Private Const CMlngvsfSendWColKb                As Integer = 19                       '「保」表示
    Private Const CMlngvsfSendWColPutDay            As Integer = 73                       '受入日
    Private Const CMlngvsfSendWColCarrierID         As Integer = 104                      'ｷｬﾘｱID
    Private Const CMlngvsfSendWColLotID             As Integer = 90                       'ﾛｯﾄID
    Private Const CMlngvsfSendWColGrbClass          As Integer = 33                       'GRB区分
    Private Const CMlngvsfSendWColFlowClass         As Integer = 25                       '種別
    Private Const CMlngvsfSendWColPriority          As Integer = 25                       '優先度
    Private Const CMlngvsfSendWColPDName            As Integer = 49                       '機種名
    Private Const CMlngvsfSendWColWfNum             As Integer = 25                       'WF
    Private Const CMlngvsfSendWColCfNum             As Integer = 73                       'ﾁｯﾌﾟ
    Private Const CMlngvsfSendWColSendSBID          As Integer = 133                      '送品先
    Private Const CMlngvsfSendWColSBSystemFlag      As Integer = 49                       'SBｼｽﾃﾑﾌﾗｸﾞ
    Private Const CMlngvsfSendWColBoxNo             As Integer = 49                       '箱№
    Private Const CMlngvsfSendWColStayTime          As Integer = 90                       '停滞時間
    Private Const CMlngvsfSendWColHoldFlag          As Integer = 90                       '保留ﾌﾗｸﾞ
    Private Const CMlngvsfSendWColHoldTime          As Integer = 104                      '保留開始日
    Private Const CMlngvsfSendWColHoldTimeEnd       As Integer = 104                      '保留期限
    Private Const CMlngvsfSendWColHoldStayTime      As Integer = 104                      '保留期間
    Private Const CMlngvsfSendWColHoldEmpID         As Integer = 104                      '保留担当者ID
    Private Const CMlngvsfSendWColHoldEmp           As Integer = 104                      '保留担当者
    Private Const CMlngvsfSendWColHoldReasonID      As Integer = 104                      '保留理由ID
    Private Const CMlngvsfSendWColHoldReason        As Integer = 90                       '保留理由
    Private Const CMlngvsfSendWColLotComments       As Integer = 90                       'ｺﾒﾝﾄ内容
    Private Const CMlngvsfSendWColLastUpdate        As Integer = 121                      '最終更新日時
    Private Const CMlngvsfSendWColComment           As Integer = 90                       '次SB連絡内容
    Private Const CMlngvsfSendWColHoldComments      As Integer = 90                       '保留ｺﾒﾝﾄ
    Private Const CMlngvsfSendWColLotCommentDisp    As Integer = 47                       'ｺﾒﾝﾄ有無
    Private Const CMlngvsfSendWColCommentDisp       As Integer = 47                       '次SB連絡有無
    Private Const CMlngvsfSendWColSlotSize          As Integer = 47                       'ｽﾛｯﾄｻｲｽﾞ
    Private Const CMlngvsfSendWColLotManagerID      As Integer = 47                       'ﾛｯﾄ担当者ID
    Private Const CMlngvsfSendWColLotManagerName    As Integer = 104                      'ﾛｯﾄ担当者名
    Private Const CMlngvsfSendWColLotSendFlag       As Integer = 47                       '送品ﾌﾗｸﾞ

    '@vsfLotListSendの定数宣言(ﾀｲﾄﾙ)(送品待ち)
    Private Const CMstrvsfSendColNo                 As String = "№"                      '№
    Private Const CMstrvsfSendColKb                 As String = ""                        '「保」表示
    Private Const CMstrvsfSendColPutDay             As String = "受入日"                  '受入日
    Private Const CMstrvsfSendColCarrierID          As String = "キャリアID"              'ｷｬﾘｱID
    Private Const CMstrvsfSendColLotID              As String = "ロットID"                'ﾛｯﾄID
    Private Const CMstrvsfSendColGrbClass           As String = "GRB"                     'GRB区分
    Private Const CMstrvsfSendColFlowClass          As String = "種"                      '種別
    Private Const CMstrvsfSendColPriority           As String = "優"                      '優先度
    Private Const CMstrvsfSendColPDName             As String = "機種"                    '機種名
    Private Const CMstrvsfSendColWfNum              As String = "WF"                      'WF
    Private Const CMstrvsfSendColCfNum              As String = "チップ"                  'ﾁｯﾌﾟ
    Private Const CMstrvsfSendColSendSBID           As String = "送品先"                  '送品先
    Private Const CMstrvsfSendColSBSystemFlag       As String = "SBｼｽﾃﾑﾌﾗｸﾞ"              'SBｼｽﾃﾑﾌﾗｸﾞ
    Private Const CMstrvsfSendColBoxNo              As String = "箱№"                    '箱№
    Private Const CMstrvsfSendColStayTime           As String = "停滞時間"                '停滞時間
    Private Const CMstrvsfSendColHoldFlag           As String = "保留ﾌﾗｸﾞ"                '保留ﾌﾗｸﾞ
    Private Const CMstrvsfSendColHoldTime           As String = "保留開始日"              '保留開始日
    Private Const CMstrvsfSendColHoldTimeEnd        As String = "保留期限"                '保留期限
    Private Const CMstrvsfSendColHoldStayTime       As String = "保留期間"                '保留期間
    Private Const CMstrvsfSendColHoldEmpID          As String = "保留担当者ID"            '保留担当者ID
    Private Const CMstrvsfSendColHoldEmp            As String = "保留担当者"              '保留担当者
    Private Const CMstrvsfSendColHoldReasonID       As String = "保留理由ID"              '保留理由ID
    Private Const CMstrvsfSendColHoldReason         As String = "保留理由"                '保留理由
    Private Const CMstrvsfSendColLotComments        As String = "コメント内容"            'ｺﾒﾝﾄ内容
    Private Const CMstrvsfSendColLastUpdate         As String = "最終更新日時"            '最終更新日時
    Private Const CMstrvsfSendColComment            As String = "次SB連絡内容"            '次SB連絡
    Private Const CMstrvsfSendColHoldComments       As String = "保留コメント"            '保留ｺﾒﾝﾄ
    Private Const CMstrvsfSendColLotCommentDisp     As String = "コメント"                'ｺﾒﾝﾄ有無
    Private Const CMstrvsfSendColCommentDisp        As String = "次SB連絡"                '次SB連絡有無
    Private Const CMstrvsfSendColSlotSize           As String = "ｽﾛｯﾄｻｲｽﾞ"                'ｽﾛｯﾄｻｲｽﾞ
    Private Const CMstrvsfSendColLotManagerID       As String = "ロット担当者ID"          'ﾛｯﾄ担当者ID
    Private Const CMstrvsfSendColLotManagerName     As String = "ロット担当"              'ﾛｯﾄ担当者名
    Private Const CMstrvsfSendColLotSendFlag        As String = "送品ﾌﾗｸﾞ"                '送品ﾌﾗｸﾞ


    '@vsfLotListSendの定数宣言(ｶﾗﾑ)(送品済み)
    Private Const CMlngvsfSend2ColNo                As Integer = 0                         '№
    Private Const CMlngvsfSend2ColCB                As Integer = 1                         'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMlngvsfSend2ColST                As Integer = 2                         '「済」表示
    Private Const CMlngvsfSend2ColSendDay           As Integer = 3                         '送品日
    Private Const CMlngvsfSend2ColCarrierID         As Integer = 4                         'ｷｬﾘｱID
    Private Const CMlngvsfSend2ColLotID             As Integer = 5                         'ﾛｯﾄID
    Private Const CMlngvsfSend2ColGrbClass          As Integer = 6                         'GRB区分
    Private Const CMlngvsfSend2ColFlowClass         As Integer = 7                         '種別
    Private Const CMlngvsfSend2ColPutDay            As Integer = 8                         'TITAN受入日
    Private Const CMlngvsfSend2ColTAITANLotID       As Integer = 9                         'TITANﾛｯﾄID
    Private Const CMlngvsfSend2ColPDName            As Integer = 10                        '機種名
    Private Const CMlngvsfSend2ColWfNum             As Integer = 11                        'WF
    Private Const CMlngvsfSend2ColCfNum             As Integer = 12                        'ﾁｯﾌﾟ
    Private Const CMlngvsfSend2ColSendSBID          As Integer = 13                        '送品先
    Private Const CMlngvsfSend2ColSendEmpName       As Integer = 14                        '送品担当者
    Private Const CMlngvsfSend2ColSBSystemFlag      As Integer = 15                        'SBｼｽﾃﾑﾌﾗｸﾞ
    Private Const CMlngvsfSend2ColBoxNo             As Integer = 16                        '箱№
    Private Const CMlngvsfSend2ColAtlasOrderNo      As Integer = 17                        'ATLASｵｰﾀﾞｰ№
    Private Const CMlngvsfSend2ColLotComments       As Integer = 18                        'ｺﾒﾝﾄ内容
    Private Const CMlngvsfSend2ColLastUpdate        As Integer = 19                        '最終更新日時
    Private Const CMlngvsfSend2ColComment           As Integer = 20                        '次SB連絡内容
    Private Const CMlngvsfSend2ColLotCommentDisp    As Integer = 21                        'ｺﾒﾝﾄ有無
    Private Const CMlngvsfSend2ColCommentDisp       As Integer = 22                        '次SB連絡有無
    Private Const CMlngvsfSend2ColSlotSize          As Integer = 23                        'ｽﾛｯﾄｻｲｽﾞ
    Private Const CMlngvsfSend2ColAMPMFlag          As Integer = 24                        'AMPMﾌﾗｸﾞ
    Private Const CMlngvsfSend2ColSendDate          As Integer = 25                        '送品日付
    Private Const CMlngvsfSend2ColCarrierType       As Integer = 26                        'ｷｬﾘｱﾀｲﾌﾟ
    Private Const CMlngvsfSend2ColTransFlag         As Integer = 27                        '転送ﾌﾗｸﾞ
    Private Const CMlngvsfSend2ColLotManagerID      As Integer = 28                        'ﾛｯﾄ担当者ID
    Private Const CMlngvsfSend2ColLotManagerName    As Integer = 29                        'ﾛｯﾄ担当者名

    '@vsfLotListSendの定数宣言(幅)(送品済み)
    Private Const CMlngvsfSend2WColNo               As Integer = 33                        '№
    Private Const CMlngvsfSend2WColCB               As Integer = 19                        'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMlngvsfSend2WColST               As Integer = 25                        '「済」表示
    Private Const CMlngvsfSend2WColSendDay          As Integer = 73                        '送品日
    Private Const CMlngvsfSend2WColCarrierID        As Integer = 104                       'ｷｬﾘｱID
    Private Const CMlngvsfSend2WColLotID            As Integer = 90                        'ﾛｯﾄID
    Private Const CMlngvsfSend2WColGrbClass         As Integer = 33                        'GRB区分
    Private Const CMlngvsfSend2WColFlowClass        As Integer = 25                        '種別
    Private Const CMlngvsfSend2WColPutDay           As Integer = 117                       'TITAN受入日
    Private Const CMlngvsfSend2WColTAITANLotID      As Integer = 136                       'TITANﾛｯﾄID
    Private Const CMlngvsfSend2WColPDName           As Integer = 49                        '機種名
    Private Const CMlngvsfSend2WColWfNum            As Integer = 25                        'WF
    Private Const CMlngvsfSend2WColCfNum            As Integer = 73                        'ﾁｯﾌﾟ
    Private Const CMlngvsfSend2WColSendSBID         As Integer = 133                       '送品先
    Private Const CMlngvsfSend2WColSendEmpName      As Integer = 133                       '送品担当者
    Private Const CMlngvsfSend2WColSBSystemFlag     As Integer = 90                        'SBｼｽﾃﾑﾌﾗｸﾞ
    Private Const CMlngvsfSend2WColBoxNo            As Integer = 49                        '箱№
    Private Const CMlngvsfSend2WColLotComments      As Integer = 90                        'ｺﾒﾝﾄ内容
    Private Const CMlngvsfSend2WColLastUpdate       As Integer = 121                       '最終更新日時
    Private Const CMlngvsfSend2WColComment          As Integer = 90                        '次SB連絡内容
    Private Const CMlngvsfSend2WColLotCommentDisp   As Integer = 90                        'ｺﾒﾝﾄ有無
    Private Const CMlngvsfSend2WColCommentDisp      As Integer = 47                        '次SB連絡有無
    Private Const CMlngvsfSend2WColSlotSize         As Integer = 47                        'ｽﾛｯﾄｻｲｽﾞ
    Private Const CMlngvsfSend2WColAMPMFlag         As Integer = 47                        'AMPMﾌﾗｸﾞ
    Private Const CMlngvsfSend2WColSendDate         As Integer = 47                        '送品日付
    Private Const CMlngvsfSend2WColCarrierType      As Integer = 47                        'ｷｬﾘｱﾀｲﾌﾟ
    Private Const CMlngvsfSend2WColTransFlag        As Integer = 47                        '転送ﾌﾗｸﾞ
    Private Const CMlngvsfSend2WColLotManagerID     As Integer = 47                        'ﾛｯﾄ担当者ID
    Private Const CMlngvsfSend2WColLotManagerName   As Integer = 104                       'ﾛｯﾄ担当者名

    '@vsfLotListSendの定数宣言(ﾀｲﾄﾙ)(送品済み)
    Private Const CMstrvsfSend2ColNo                As String = "№"                       '№
    Private Const CMstrvsfSend2ColCB                As String = ""                         'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMstrvsfSend2ColST                As String = "受"                       '「未/済」表示
    Private Const CMstrvsfSend2ColSendDay           As String = "送品日"                   '送品日
    Private Const CMstrvsfSend2ColCarrierID         As String = "キャリアID"               'ｷｬﾘｱID
    Private Const CMstrvsfSend2ColLotID             As String = "ロットID"                 'ﾛｯﾄID
    Private Const CMstrvsfSend2ColGrbClass          As String = "GRB"                      'GRB区分
    Private Const CMstrvsfSend2ColFlowClass         As String = "種"                       '種別
    Private Const CMstrvsfSend2ColPutDay            As String = "TITAN受入日"              'TITAN受入日
    Private Const CMstrvsfSend2ColTAITANLotID       As String = "TITANロットID"            'TITANﾛｯﾄID
    Private Const CMstrvsfSend2ColPDName            As String = "機種"                     '機種名
    Private Const CMstrvsfSend2ColWfNum             As String = "WF"                       'WF
    Private Const CMstrvsfSend2ColCfNum             As String = "チップ"                   'ﾁｯﾌﾟ
    Private Const CMstrvsfSend2ColSendSBID          As String = "送品先"                   '送品先
    Private Const CMstrvsfSend2ColSendEmpName       As String = "送品担当者"               '送品担当者
    Private Const CMstrvsfSend2ColSBSystemFlag      As String = "SBｼｽﾃﾑﾌﾗｸﾞ"               'SBｼｽﾃﾑﾌﾗｸﾞ
    Private Const CMstrvsfSend2ColBoxNo             As String = "箱№"                     '箱№
    Private Const CMstrvsfSend2ColLotComments       As String = "コメント内容"             'ｺﾒﾝﾄ内容
    Private Const CMstrvsfSend2ColLastUpdate        As String = "最終更新日時"             '最終更新日時
    Private Const CMstrvsfSend2ColComment           As String = "次SB連絡内容"             '次SB連絡
    Private Const CMstrvsfSend2ColLotCommentDisp    As String = "コメント"                 'ｺﾒﾝﾄ有無
    Private Const CMstrvsfSend2ColCommentDisp       As String = "次SB連絡"                 '次SB連絡有無
    Private Const CMstrvsfSend2ColSlotSize          As String = "ｽﾛｯﾄｻｲｽﾞ"                 'ｽﾛｯﾄｻｲｽﾞ
    Private Const CMstrvsfSend2ColAMPMFlag          As String = "AMPM"                     'AMPMﾌﾗｸﾞ
    Private Const CMstrvsfSend2ColSendDate          As String = "送品日付"                 '送品日付
    Private Const CMstrvsfSend2ColCarrierType       As String = "ｷｬﾘｱﾀｲﾌﾟ"                 'ｷｬﾘｱﾀｲﾌﾟ
    Private Const CMstrvsfSend2ColTransFlag         As String = "転送ﾌﾗｸﾞ"                 '転送ﾌﾗｸﾞ
    Private Const CMstrvsfSend2ColLotManagerID      As String = "ロット担当者ID"           'ﾛｯﾄ担当者ID
    Private Const CMstrvsfSend2ColLotManagerName    As String = "ロット担当"               'ﾛｯﾄ担当者名

    '@vsfLotListCFEndの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfCFEndColNo                As Integer = 0                         '№
    Private Const CMlngvsfCFEndColKb                As Integer = 1                         '「保」表示
    Private Const CMlngvsfCFEndColPutDay            As Integer = 2                         '受入日
    Private Const CMlngvsfCFEndColCarrierID         As Integer = 3                         'ｷｬﾘｱID
    Private Const CMlngvsfCFEndColLotID             As Integer = 4                         'ﾛｯﾄID
    Private Const CMlngvsfCFEndColFlowClass         As Integer = 5                         '種別
    Private Const CMlngvsfCFEndColPDName            As Integer = 6                         '機種名
    Private Const CMlngvsfCFEndColCfNum             As Integer = 7                         'ﾁｯﾌﾟ
    Private Const CMlngvsfCFEndColReworkCount       As Integer = 8                         'ﾘﾜｰｸｶｳﾝﾄ
    Private Const CMlngvsfCFEndColRegenerationCnt   As Integer = 9                         '最大ﾘﾜｰｸｶｳﾝﾄ
    Private Const CMlngvsfCFEndColCfArea            As Integer = 10                        'CF区分
    Private Const CMlngvsfCFEndColLimitTime         As Integer = 11                        '有効期限
    Private Const CMlngvsfCFEndColStayTime          As Integer = 12                        '停滞時間
    Private Const CMlngvsfCFEndColHoldFlag          As Integer = 13                        '保留ﾌﾗｸﾞ
    Private Const CMlngvsfCFEndColHoldTime          As Integer = 14                        '保留開始日
    Private Const CMlngvsfCFEndColHoldTimeEnd       As Integer = 15                        '保留期限
    Private Const CMlngvsfCFEndColHoldStayTime      As Integer = 16                        '保留期間
    Private Const CMlngvsfCFEndColHoldEmpID         As Integer = 17                        '保留担当者ID
    Private Const CMlngvsfCFEndColHoldEmp           As Integer = 18                        '保留担当者
    Private Const CMlngvsfCFEndColHoldReasonID      As Integer = 19                        '保留理由ID
    Private Const CMlngvsfCFEndColHoldReason        As Integer = 20                        '保留理由
    Private Const CMlngvsfCFEndColLotComments       As Integer = 21                        'ｺﾒﾝﾄ内容
    Private Const CMlngvsfCFEndColLastUpdate        As Integer = 22                        '最終更新日時
    Private Const CMlngvsfCFEndColHoldComments      As Integer = 23                        '保留ｺﾒﾝﾄ内容
    Private Const CMlngvsfCFEndColLotCommentDisp    As Integer = 24                        'ｺﾒﾝﾄ有無
    Private Const CMlngvsfCFEndColLotManagerID      As Integer = 25                        'ﾛｯﾄ担当者ID
    Private Const CMlngvsfCFEndColLotManagerName    As Integer = 26                        'ﾛｯﾄ担当者名

    '@vsfLotListCFEndの定数宣言(幅)
    Private Const CMlngvsfCFEndWColNo               As Integer = 33                       '№
    Private Const CMlngvsfCFEndWColKb               As Integer = 19                       '「保」表示
    Private Const CMlngvsfCFEndWColPutDay           As Integer = 73                       '受入日
    Private Const CMlngvsfCFEndWColCarrierID        As Integer = 104                      'ｷｬﾘｱID
    Private Const CMlngvsfCFEndWColLotID            As Integer = 90                       'ﾛｯﾄID
    Private Const CMlngvsfCFEndWColFlowClass        As Integer = 25                       '種別
    Private Const CMlngvsfCFEndWColPDName           As Integer = 49                       '機種名
    Private Const CMlngvsfCFEndWColCfNum            As Integer = 73                       'ﾁｯﾌﾟ
    Private Const CMlngvsfCFEndWColReworkCount      As Integer = 25                       'ﾘﾜｰｸｶｳﾝﾄ
    Private Const CMlngvsfCFEndWColRegenerationCnt  As Integer = 73                       '最大ﾘﾜｰｸｶｳﾝﾄ
    Private Const CMlngvsfCFEndWColCfArea           As Integer = 73                       'CF区分
    Private Const CMlngvsfCFEndWColLimitTime        As Integer = 90                       '有効期限
    Private Const CMlngvsfCFEndWColStayTime         As Integer = 90                       '停滞時間
    Private Const CMlngvsfCFEndWColHoldFlag         As Integer = 90                       '保留ﾌﾗｸﾞ(非)
    Private Const CMlngvsfCFEndWColHoldTime         As Integer = 104                      '保留開始日
    Private Const CMlngvsfCFEndWColHoldTimeEnd      As Integer = 104                      '保留期限
    Private Const CMlngvsfCFEndWColHoldStayTime     As Integer = 104                      '保留期間
    Private Const CMlngvsfCFEndWColHoldEmpID        As Integer = 104                      '保留担当者ID(非)
    Private Const CMlngvsfCFEndWColHoldEmp          As Integer = 104                      '保留担当者
    Private Const CMlngvsfCFEndWColHoldReasonID     As Integer = 90                       '保留理由ID(非)
    Private Const CMlngvsfCFEndWColHoldReason       As Integer = 90                       '保留理由
    Private Const CMlngvsfCFEndWColLotComments      As Integer = 47                       'ｺﾒﾝﾄ内容(非)
    Private Const CMlngvsfCFEndWColLastUpdate       As Integer = 47                       '最終更新日時(非)
    Private Const CMlngvsfCFEndWColHoldComments     As Integer = 47                       '保留ｺﾒﾝﾄ内容(非)
    Private Const CMlngvsfCFEndWColLotCommentDisp   As Integer = 47                       'ｺﾒﾝﾄ有無
    Private Const CMlngvsfCFEndWColLotManagerID     As Integer = 47                       'ﾛｯﾄ担当者ID
    Private Const CMlngvsfCFEndWColLotManagerName   As Integer = 104                      'ﾛｯﾄ担当者名

    '@vsfLotListCFEndの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfCFEndColNo                As String = "№"                     '№
    Private Const CMstrvsfCFEndColKb                As String = ""                       '「保」表示
    Private Const CMstrvsfCFEndColPutDay            As String = "受入日"                 '受入日
    Private Const CMstrvsfCFEndColCarrierID         As String = "キャリアID"             'ｷｬﾘｱID
    Private Const CMstrvsfCFEndColLotID             As String = "ロットID"               'ﾛｯﾄID
    Private Const CMstrvsfCFEndColFlowClass         As String = "種"                     '種別
    Private Const CMstrvsfCFEndColPDName            As String = "機種"                   '機種名
    Private Const CMstrvsfCFEndColCfNum             As String = "チップ"                 'ﾁｯﾌﾟ
    Private Const CMstrvsfCFEndColReworkCount       As String = "RW"                     'ﾘﾜｰｸｶｳﾝﾄ
    Private Const CMstrvsfCFEndColRegenerationCnt   As String = "最大RW"                 '最大ﾘﾜｰｸｶｳﾝﾄ
    Private Const CMstrvsfCFEndColCfArea            As String = "CF区分"                 'CF区分
    Private Const CMstrvsfCFEndColLimitTime         As String = "有効期限"               '有効期限
    Private Const CMstrvsfCFEndColStayTime          As String = "停滞時間"               '停滞時間
    Private Const CMstrvsfCFEndColHoldFlag          As String = "保留ﾌﾗｸﾞ"               '保留ﾌﾗｸﾞ
    Private Const CMstrvsfCFEndColHoldTime          As String = "保留開始日"             '保留開始日
    Private Const CMstrvsfCFEndColHoldTimeEnd       As String = "保留期限"               '保留期限
    Private Const CMstrvsfCFEndColHoldStayTime      As String = "保留期間"               '保留期間
    Private Const CMstrvsfCFEndColHoldEmpID         As String = "保留担当者ID"           '保留担当者ID
    Private Const CMstrvsfCFEndColHoldEmp           As String = "保留担当者"             '保留担当者
    Private Const CMstrvsfCFEndColHoldReasonID      As String = "保留理由ID"             '保留理由ID
    Private Const CMstrvsfCFEndColHoldReason        As String = "保留理由"               '保留理由
    Private Const CMstrvsfCFEndColLotComments       As String = "コメント内容"           'ｺﾒﾝﾄ内容
    Private Const CMstrvsfCFEndColLastUpdate        As String = "最終更新日時"           '最終更新日時
    Private Const CMstrvsfCFEndColHoldComments      As String = "保留ｺﾒﾝﾄ内容"           '保留ｺﾒﾝﾄ内容
    Private Const CMstrvsfCFEndColLotCommentDisp    As String = "コメント"               'ｺﾒﾝﾄ有無
    Private Const CMstrvsfCFEndColLotManagerID      As String = "ロット担当者ID"         'ﾛｯﾄ担当者ID
    Private Const CMstrvsfCFEndColLotManagerName    As String = "ロット担当"             'ﾛｯﾄ担当者名

    '@ｸﾞﾘｯﾄﾞ共通の定数宣言
    Private Const CMlngVsfRowTitle                  As Integer = 0                         'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                  As Integer = 0                         'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                 As Integer = 11                        'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                   As Integer = 20                        'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                    As Integer = 24                        '1ｽﾛｯﾄの高さ
    Private Const CMstrLotHoldFlgOn                 As String = "1"                        '保留ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrWaitReceiveFlagOff           As String = "0"                        '送品受入待ちﾌﾗｸﾞOFF
    Private Const CMlngNoSelect                     As Integer = -1                        'ｸﾞﾘｯﾄ行未選択
    Private Const CMlngInfoFlagOn                   As Integer = 1                         '情報取得済
    Private Const CMlngInfoFlagOff                  As Integer = 0                         '情報未取得

    '@vsfCarrierInfoの定数宣言(表示幅)
    Private Const CMlngCarrierRowS                  As Integer = 26                        '行数
    Private Const CMlngCarrierCols                  As Integer = 3                         '列数
    Private Const CMlngCarrierHeight                As Integer = 18                        '1ｽﾛｯﾄの高さ

    '@vsfLotListSendの定数宣言
    Private Const CMlngvsfSendCols                  As Integer = 34                        '送品待ち列数
    Private Const CMlngvsfSend2Cols                 As Integer = 30                        '送品済み列数
    Private Const CMlngSendFrozenCols               As Integer = 7                         '固定列(=7)
    Private Const CMlngSend2FrozenCols1A0           As Integer = 8                         '固定列(=8)
    Private Const CMlngSend2FrozenCols2A0           As Integer = 10                        '固定列(=10)

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                  As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols                  As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbDispCol2                  As Integer = 2                         'ｸﾞﾘｯﾄﾞ表示列数=2
    Private Const CMlngCmbGroupCols                 As Integer = 1                         '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMlngCMbSelectMode                As Integer = 1                         '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMlngCmbRowHeight                 As Integer = 18                        'ﾘｽﾄ行の高さ
    Private Const CMstrCmbAddedComment              As String = " 項目選択"                '表示 文字列
    Private Const CMstrCmbAddedCommentNone          As String = "0 項目選択"               '表示 文字列「選択なし」
    Private Const CMlngCmbGridCol0                  As Integer = 0                         '選択列数
    Private Const CMlngCmbValueCol0                 As Integer = 0                         '値取得列=0
    Private Const CMlngCmbValueCol1                 As Integer = 1                         '値取得列=1
    Private Const CMlngCmbGetCol0                   As Integer = 0                         'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=0
    Private Const CMlngCmbGetCol1                   As Integer = 1                         'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=1

    '@Tab
    Private Const CMlngPutTab                       As Integer = 0                         '受入在庫ﾀﾌﾞIndex
    Private Const CMlngHoldTab                      As Integer = 1                         '保管在庫ﾀﾌﾞIndex
    Private Const CMlngWFTab                        As Integer = 2                         '中間在庫ﾀﾌﾞIndex
    Private Const CMlngSendTab                      As Integer = 3                         '完成在庫ﾀﾌﾞIndex
    Private Const CMlngCFEndTab                     As Integer = 4                         'CF完成在庫ﾀﾌﾞIndex
    Private Const CMlngNumOfTabs1A0                 As Integer = 3                         'ﾀﾌﾞの数(基板)
    Private Const CMlngNumOfTabs2A0                 As Integer = 5                         'ﾀﾌﾞの数(組立)
    Private Const CMlngNumOfTabs3A0                 As Integer = 3                         'ﾀﾌﾞの数(防湿ALD)


    '@ﾌｫｰﾏｯﾄ定数宣言
    Private Const CMlngFormatStart                  As Integer = 1                         'Mid取得先頭数(=1)
    Private Const CMlngFormatMid9                   As Integer = 9                         'Mid取得=9文字

    '@期間のNull変換定数
    Private Const CMstrZeroTerm                     As String = "  0日 00時間"             'Null置換を行う文字列

    '@国内/海外
    Private Const CMlngKokunai                      As Integer = 0                         '国内
    Private Const CMlngKaigai                       As Integer = 1                         '海外

    '@ﾁｪｯｸON/OFF
    Private Const CMlngChkOFF                       As Boolean = False                     'ﾁｪｯｸOFF
    Private Const CMlngChkON                        As Boolean = True                      'ﾁｪｯｸON

    '@その他
    Private Const CMstrHo                           As String = "保"                     '保留表示
    Private Const CMstrBun                          As String = "分"                     '分割予約表示
    Private Const CMstrIsai                         As String = "移"                     '移載中表示
    Private Const CMstrSumi                         As String = "済"                     '受入済
    Private Const CMlngStateNotEditColor            As Integer = &HFFECCC                '未編集色
    Private Const CMstrSendAbleFlagOn               As String = "1"                      '送品可能ﾌﾗｸﾞON
    Private Const CMstrWfCarryFlagOn                As String = "1"                      'WF移載ﾌﾗｸﾞON
    Private Const CMlngTxtLotIDMinLen               As Integer = 2                       '元ﾛｯﾄIDMinLen
    Private Const CMlngTxtLotIDMaxLen               As Integer = 10                      '元ﾛｯﾄIDMaxLen
    Private Const CMstrSlash                        As String = "/"                      '/
    Private Const CMstrAM                           As String = "AM"
    Private Const CMstrPM                           As String = "PM"
    Private Const CMstrAMTimeStart                  As String = "00:00:00"
    Private Const CMstrAMTimeEnd                    As String = "11:59:59"
    Private Const CMstrRegistFlag0                  As String = "0"                      '確定処理中断ﾌﾗｸﾞ
    Private Const CMstrRegistFlag1                  As String = "1"                      '確定処理完了ﾌﾗｸﾞ
    Private Const CMstrDspMsgThreeMonth             As String = "3ヶ月"                  '表示ﾒｯｾｰｼﾞ(期間指定)
    Private Const CMstrM                            As String = "M"                      '3ヶ月後計算用

    '@分割予約状態
    Private Const CMstrDevideStatusFlag0            As String = "0"                      '投入不可
    Private Const CMstrDevideStatusFlag1            As String = "1"                      '分割中
    Private Const CMstrDevideStatusFlag2            As String = "2"                      '投入可能
    Private Const CMstrDevideStatusFlag3            As String = "3"                      '移載中

    '@vsfLotListSendの定数宣言(処理区分)
    Private Const CMlngMouseClick                   As Integer = 1                         'ﾏｳｽｸﾘｯｸﾌﾗｸﾞ=1
    Private Const CMlngKeyDown                      As Integer = 2                         'ｷｰﾀﾞｳﾝﾌﾗｸﾞ=2
    Private Const CMlngvsfMauseClickEvent           As Integer = 0                         'ﾏｳｽｸﾘｯｸｲﾍﾞﾝﾄ(定義)

    '@送品ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ
    Private Const CMstrSendButtonCaption            As String = "送　品"                '送品
    Private Const CMstrCancelSendButtonCaption      As String = "送品取消"              '送品取消

    '@完成在庫(送品)Tab　ｺﾒﾝﾄﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ
    Private Const CMstrCommentDispButtonCaption     As String = "ﾛｯﾄｺﾒﾝﾄ" & vbCrLf & "表示"     'ﾛｯﾄｺﾒﾝﾄ表示
    Private Const CMstrCommentRegistButtonCaption   As String = "ロット" & vbCrLf & "コメント "  'ﾛｯﾄｺﾒﾝﾄ登録

    '@次SB連絡ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ
    Private Const CMstrInvCommCaptionUpd            As String = "次SB連絡" & vbCrLf & "登録"    '次SB連絡登録
    Private Const CMstrInvCommCaptionDisp           As String = "次SB連絡" & vbCrLf & "表示"    '次SB連絡表示

    '@送品待ち/送品済みｵﾌﾟｼｮﾝﾎﾞﾀﾝ
    Private Const CMlngOptSendBefore                As Integer = 0                         '送品待ち
    Private Const CMlngOptSendAfter                 As Integer = 1                         '送品済み

    Private Const CMlngDisplayMaxCnt                As Integer = 500                       '表示最大件数
    Private Const CMstrDisplayMax                   As String = "最大"                     '表示最大件数ｵｰﾊﾞｰ時の文字

    '@箱№の文字数
    Private Const CMlngBoxNoMaxLen                  As Integer = 4                         '箱№最大文字数

    '@ｽﾛｯﾄｻｲｽﾞ
    Private Const CMstrTPALSlotSize                 As String = "1"                        'TPALﾛｯﾄのｽﾛｯﾄｻｲｽﾞ
    Private Const CMstrCFSlotSize                   As String = "18"                       'CFﾛｯﾄのｽﾛｯﾄｻｲｽﾞ

    '@ﾚｽﾎﾟﾝｽ用定数
    Private Const CMstrFormName                     As String = "frmxxEN00F0"               '自ﾌｫｰﾑ名
    Private Const CMstrPrvvsfSBIDSendListSet        As String = "prvvsfSBIDSendList_Set"    'ｲﾍﾞﾝﾄ名称(送品先ｺﾝﾎﾞ設定)

    '@送品表示
    Private Const CMstrDispSendNasi                 As String = "送品なし"                  '送品なし表示

    '@CF区分表示
    Private Const CMstrDispCfAreaLeft               As String = "左"                    'CF区分
    Private Const CMstrDispCfAreaRight              As String = "右"                    'CF区分

    '@CF区分ｺｰﾄﾞ
    Private Const CMstrCfSelectCodeLeft             As String = "L"
    Private Const CMstrCfSelectCodeRight            As String = "R"

    Private mblnChkForignClick_CancelFlag           As Boolean                          'イベントキャンセルフラグ
    Private mblnAuthorityChkFlag                    As Boolean                          '権限ﾁｪｯｸ済みﾌﾗｸﾞ(ﾁｪｯｸ済み：True、未ﾁｪｯｸ：False)
    Private mlngStockListCnt                        As Integer                          '在庫ﾃﾞｰﾀｶｳﾝﾄ退避
    Private mblnOptChange   　                      As Boolean                          'チェック状態格納

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@送品伝票ﾛｯﾄﾘｽﾄ
    Private Structure SendOrderListLotList
        Dim strLotID                    As String
        Dim strSBName                   As String
        Dim strSbID                     As String
        Dim strBoxNo                    As String
        Dim strLotLastUpdate            As String
    End Structure

    '@送品伝票ﾛｯﾄﾘｽﾄ配列
    Private Structure SendOrderListLotListAry
        Dim lngLotListCount             As Integer
        Dim strLotList                  As List (Of SendOrderListLotList)
    End Structure

    '@送品先構造体
    Private Structure SendSBList
        Dim strSendSBName               As String
        Dim typAtlasExistList           As SendOrderListLotListAry
        Dim typAtlasNotExistList        As SendOrderListLotListAry
    End Structure

    '@同条件ﾛｯﾄID検索退避構造体
    Private Structure SearchList
        Dim strLotID                    As String
        Dim strDate                     As String
        Dim strAMPM                     As String
        Dim strEmpName                  As String
        Dim strSend                     As String
    End Structure

    '@WF情報
    Private mstrTaihiSBID0                          As String                           '利用SB退避領域
    Private mstrCarrierID                           As String                           'ｷｬﾘｱID
    Private mstrLotId                               As String                           'ﾛｯﾄID退避領域

    '@中間WF在庫：ｷｬﾘｱ情報退避領域
    Private Structure CarrierInfo
        Dim strNo                                       As String                           '№(ｸﾞﾘｯﾄﾞ)
        Dim strCarrierId                                As String                           'ｷｬﾘｱID
        Dim typInvWaferList                             As InvWaferList                     'WF情報
    End Structure
    Private mtypCaarierInfo                         As List(Of CarrierInfo)

    '@Tabで使用している共通構造体
    Private mtypProductList                         As List(Of ProductList)             '機種格納変数(保留在庫用)
    Private mlngProductListCnt                      As Integer                          '機種格納数(保留在庫用)
    Private mtypDivisionList                        As List(Of DivisionList)            '種別格納変数(保留在庫用)
    Private mlngDivisionListCnt                     As Integer                          '種別格納数(保留在庫用)
    Private mtypProductList2                        As List(Of ProductList)             '機種格納変数(受入在庫用)
    Private mlngProductListCnt2                     As Integer                          '機種格納数(受入在庫用)
    Private mtypDivisionList2                       As List(Of DivisionList)            '種別格納変数(受入在庫用)
    Private mlngDivisionListCnt2                    As Integer                          '種別格納数(受入在庫用)
    Private mtypProductList3                        As List(Of ProductList)             '機種格納変数(完成在庫用)
    Private mlngProductListCnt3                     As Integer                          '機種格納数(完成在庫用)
    Private mtypDivisionList3                       As List(Of DivisionList)            '種別格納変数(完成在庫用)
    Private mlngDivisionListCnt3                    As Integer                          '種別格納数(完成在庫用)
    Private mtypProductList4                        As List(Of ProductList)             '機種格納変数(CF完成在庫用)
    Private mlngProductListCnt4                     As Integer                          '機種格納数(CF完成在庫用)

    Private mtypstocklotlist                        As List(Of StockLotList)            '在庫ﾛｯﾄ応答格納構造体
    Private mtypstocklotlist2                       As List(Of StockLotList)            '在庫ﾛｯﾄ応答格納構造体(CF完成在庫)
    Private mtypInvLotList                          As InvLotListAns                    '中間在庫格納用構造体
    Private mtypMasSbList                           As MasSbList                        'ｼｽﾃﾑﾌﾞﾛｯｸ構造体
    Private mtypChgSortPutTab                       As ChgSort                          'ｿｰﾄ保持用(受入)
    Private mtypChgSortHoldTab                      As ChgSort                          'ｿｰﾄ保持用(保留)
    Private mtypChgSortWFTab                        As ChgSort                          'ｿｰﾄ保持用(中間)
    Private mtypChgSortSendTab                      As ChgSort                          'ｿｰﾄ保持用(完成)
    Private mtypChgSortCFEndTab                     As ChgSort                          'ｿｰﾄ保持用(CF完成)
    Private mtypLotDetailInfo                       As LotDetailInfo                    'ﾛｯﾄ情報詳細格納構造体

    Private mtypSendSBListAns                       As SendSBListAns                    '送品先ﾘｽﾄ格納用

    '@その他
    Private mblnInEditKbn                           As Boolean                          '編集中区分(True:編集中、False:未編集)
    Private mblnSyokaiKbn                           As Boolean                          '初回区分(True:初回、False:初回以外)中間在庫ﾀﾌﾞで使用
    Private mblnOptChangeFlag                       As Boolean                          'ｵﾌﾟｼｮﾝﾎﾞﾀﾝ変更ﾌﾗｸﾞ
    Private mblnComboCloseUpFlag                    As Boolean                          'ｺﾝﾎﾞｸﾛｰｽﾞｱｯﾌﾟﾌﾗｸﾞ
    Private mstrProductSendSelect                   As String                           '機種ｺﾝﾎﾞ選択内容退避
    Private mstrDivisionSendSelect                  As String                           '種別ｺﾝﾎﾞ選択内容退避
    Private mblnFormLoadFlag                        As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private mblnNowListWFFlag                       As Boolean                          '中間WF在庫Tab最新取得処理中ﾌﾗｸﾞ

    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                          'NSYS WindowCloseフラグ
    Private mblnSetFocus                            As Boolean                          'NSYS フォーカス設定フラグ
    Private mblnTabSelectEnabled                    As Boolean                          'NSYS TabControlの変更許可
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
        mblnTabSelectEnabled = True
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
    '作成日：2004/06/25 (Fri) 12:23:48 S.Deguchi
    '更新日：2004/10/18 (Mon) 09:35:07 N.Kasai
    '備　考：
    '　　　：2004/10/06 (Wed) 12:00:30 S.Deguchi    完成在庫用の機種・種別を取得する処理を追加
    '　　　：2004/10/18 (Mon) 09:35:07 N.Kasai      種別ﾌﾟﾛﾀﾞｸﾄ品対応
    '　　　：2004/12/06 (Mon) 10:14:26 S.Deguchi    CF完成在庫ﾀﾌﾞ追加の処理を追加
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrClassDivision   As String               'ClassDivision設定
        Dim lstrSBID            As String

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00F0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ｿｰﾄ保持用構造体の初期化
            '@受入在庫
            With mtypChgSortPutTab
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                Else
                    .typChgSortList.Clear
                End If
                '@列幅変更フラグ(未変更)
                .blnChgWidth = False
                '@カレント行検索キーを初期化
                .strKey = vbNullString
            End With
            
            '@保留在庫
            With mtypChgSortHoldTab
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
            
            '@中間在庫
            With mtypChgSortWFTab
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
            
            '@完成在庫
            With mtypChgSortSendTab
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
            
            '@CF完成在庫
            With mtypChgSortCFEndTab
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
            
            '@画面情報の初期化
            Call prvfrmxxEN00F0_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            '@---受入在庫ﾀﾌﾞ---
            
            '@処理区分判定
            If pstrSBID = CPstrSBID2A0 Then
                '@処理区分が組立(2A0)の場合受入在庫の機種は基板(1A0)のものを取得する
                lstrSBID = CPstrSBID1A0
                
                '@機種区分一覧取得
                '@lstrClassDivision = CPstrCD2A & CPstrCD02
                
                '@新規CLASS_DIVISION(送品可能機種(WF))を作成
                '@送品可能機種であり、基板機種もしくはODF機種を対象とする。
                lstrClassDivision = CPstrCD4F & CPstrCD30

                lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                              lstrClassDivision, _
                                              mtypProductList2, _
                                              mlngProductListCnt2, _
                                              lstrSBID)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose
                    
                    Exit Sub
                End If
                
                '@流動区分一覧取得(ﾌﾟﾛﾀﾞｸﾄ品の種別を選択する)
                '@lstrClassDivision = CPstrCD2T & CPstrCD02
                '@新規CLASS_DIVISION(送品可能機種の流動区分)
                lstrClassDivision = CPstrCD4F
                
                '@流動区分一覧取得
                lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                                mtypDivisionList2, _
                                                mlngDivisionListCnt2, _
                                                lstrSBID, _
                                                lstrClassDivision)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose
                    
                    Exit Sub
                End If
            End If
            
            '@流動区分一覧取得
            lstrClassDivision = CPstrCD02   '(全部)
            
            lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                            mtypDivisionList, _
                                            mlngDivisionListCnt, _
                                            pstrSBID, _
                                            lstrClassDivision)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@---中間在庫ﾀﾌﾞ---
            '@ｼｽﾃﾑﾌﾞﾛｯｸ取得結果
            lblnAns = pubblnMasSbList_Sel(CMstrmas_sblist__Ver, mtypMasSbList)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@---完成在庫ﾀﾌﾞ---
            '@画面ｻｲｽﾞ指定無しでWFのみを指定する
            '@機種区分一覧取得
        '    lstrClassDivision = CPstrCD2A & CPstrCD30
            
            '@新規CLASS_DIVISION(送品可能機種(WF))を作成
            '@送品可能機種であり、基板機種もしくはODF機種を対象とする。
             lstrClassDivision = CPstrCD4F & CPstrCD30
           
            lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                          lstrClassDivision, _
                                          mtypProductList3, _
                                          mlngProductListCnt3, _
                                          pstrSBID)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@流動区分一覧取得
        '    lstrClassDivision = CPstrCD2T & CPstrCD02  '(ﾌﾟﾛﾀﾞｸﾄ品の種別を選択する)
            lstrClassDivision = CPstrCD4F   '(送品可能機種の種別を選択する)
           
            lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                            mtypDivisionList3, _
                                            mlngDivisionListCnt3, _
                                            pstrSBID, _
                                            lstrClassDivision)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@組立起動の場合
            If pstrSBID = CPstrSBID2A0 Then
                '@---CF完成在庫ﾀﾌﾞ---
                '@画面ｻｲｽﾞ指定無しでCFのみを指定する
                '@機種区分一覧取得
                lstrClassDivision = CPstrCD2A & CPstrCD31
                lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                              lstrClassDivision, _
                                              mtypProductList4, _
                                              mlngProductListCnt4, _
                                              pstrSBID)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose
                    
                    Exit Sub
                End If
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
            If mblnFormLoadFlag = False Then
                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@利用SB表示
                Call prvcmbSbID_Disp()
            
                '@機種情報表示
                Call prvcmbPdList_Disp()
                
                '@種別Combo作成(保留ﾛｯﾄﾀﾌﾞ)
                Call prvcmbDivisionList_Disp(CMlngHoldTab)
                
                'NSYS 初期フォーカス設定
                If pstrSBID = CPstrSBID2A0 Then
                    Call pubSetFocus(cmbProductPut)
                Else
                    Call pubSetFocus(cmbDivisionHold)
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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑのKeyDown処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 10:58:33 S.Deguchi
    '更新日：2004/06/28 (Mon) 10:58:33
    '備　考：
    '　　　：2005/02/08 (Tue) 09:31:01 S.Deguchi    中間WF在庫のｺﾝﾄﾛｰﾙを追加
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@砂時計の場合はｷｰﾎﾞｰﾄﾞ入力を抑止
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If
            
            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙによる処理分岐
            Select Case ActiveControl.Name
                Case cmbProductPut.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@受入在庫-機種Validate処理へ
                            RemoveHandler cmbProductPut.Validating, AddressOf cmbProductPut_Validate
                            Call cmbProductPut_Validate(cmbProductPut,New CancelEventArgs(True))
                            AddHandler cmbProductPut.Validating, AddressOf cmbProductPut_Validate
                            e.Handled = True
                    End Select
                    
                Case cmbDivisionPut.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@受入在庫-種別Validate処理へ
                            RemoveHandler cmbDivisionPut.Validating, AddressOf cmbDivisionPut_Validate
                            Call cmbDivisionPut_Validate(cmbDivisionPut,New CancelEventArgs(True))
                            AddHandler cmbDivisionPut.Validating, AddressOf cmbDivisionPut_Validate
                            e.Handled = True
                    End Select
                    
                Case cmbDivisionHold.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@保管在庫-種別Validate処理へ
                            RemoveHandler cmbdivisionhold.Validating, AddressOf cmbdivisionhold_Validate
                            Call cmbdivisionhold_Validate(cmbdivisionhold,New CancelEventArgs(True))
                            AddHandler cmbdivisionhold.Validating, AddressOf cmbdivisionhold_Validate
                            e.Handled = True
                    End Select
                
                Case cmbSBID0.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@中間在庫-利用SBValidate処理へ
                            RemoveHandler cmbSBID0.Validating, AddressOf cmbSBID0_Validate
                            Call cmbSBID0_Validate(cmbSBID0,New CancelEventArgs(True))
                            AddHandler cmbSBID0.Validating, AddressOf cmbSBID0_Validate
                            e.Handled = True
                    End Select
                
                Case txtLotID.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@中間在庫-元ﾛｯﾄIDValidate処理へ
                            RemoveHandler txtLotID.Validating, AddressOf txtLotID_Validate
                            Call txtLotID_Validate(txtLotID,New CancelEventArgs(True))
                            AddHandler txtLotID.Validating, AddressOf txtLotID_Validate
                            e.Handled = True
                    End Select
                    
                Case cmbProductSend.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@完成在庫-機種Validate処理へ
                            RemoveHandler cmbProductSend.Validating, AddressOf cmbProductSend_Validate
                            Call cmbProductSend_Validate(cmbProductSend,New CancelEventArgs(True))
                            AddHandler cmbProductSend.Validating, AddressOf cmbProductSend_Validate
                            e.Handled = True
                    End Select
                    
                Case cmbDivisionSend.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@完成在庫-種別Validate処理へ
                            RemoveHandler cmbDivisionSend.Validating, AddressOf cmbDivisionSend_Validate
                            Call cmbDivisionSend_Validate(cmbDivisionSend,New CancelEventArgs(True))
                            AddHandler cmbDivisionSend.Validating, AddressOf cmbDivisionSend_Validate
                            e.Handled = True
                    End Select
                            
                Case Else
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            If ActiveControl IsNot vsfLotListSend.Editor Then
                                '@次項目へｾｯﾄﾌｫｰｶｽ
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

    '関数名：Form_QueryUnload
    '機　能：終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 12:24:00 S.Deguchi
    '更新日：2012/10/18 (Thu) 13:08:43 T.Oide
    '備　考：
    '　　　：2004/11/01 (Mon) 15:58:40 N.Kasai      閉じるﾎﾞﾀﾝ統合
    '　　　：2004/12/06 (Mon) 10:45:13 S.Deguchi    CF完成在庫Tab関連処理を追加
    '　　　：2005/09/06 (Tue) 15:42:50 N.Kojima     構造体の初期化処理追加(不具合№3047)
    '　　　：2012/10/18 (Thu) 13:08:52 T.Oide       EPPI送品対応
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm             As Boolean              '開放結果格納
        Dim ltypHoldConnect         As HoldConnect          '引継ぎ用構造体
        Dim ltypDepartmentList      As DepartmentInfo       '部署/所属格納構造体
        Dim ltypDeptEmpList         As DeptEmpInfo          'ﾕｰｻﾞ格納構造体
        Dim ltypSendMailList        As SendMailList         '宛先人格納構造体
        Dim ltypMailInfo            As MailInfo             'ﾒｰﾙ送信画面引継ぎ構造体

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose,New CancelEventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            Else
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Me.Close
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
          
            '未使用機能NSYS ↓
            ''@送品伝票印刷ﾌﾟﾚﾋﾞｭｰ画面の存在確認
            'If Not rptxxEN00F0 Is Nothing Then
            '    '@ﾌﾟﾚﾋﾞｭｰ画面が開いている場合
            '    '@送品伝票印刷ﾌﾟﾚﾋﾞｭｰ画面をUnloadする
            '    Unload rptxxEN00F0
            '    '@ﾌﾟﾚﾋﾞｭｰ画面の解放
            '    Set rptxxEN00F0 = Nothing
            'End If
            ''@ﾛｯﾄ検定表画面の存在確認
            'If Not rptxxEN00F1 Is Nothing Then
            '    '@ﾌﾟﾚﾋﾞｭｰ画面が開いている場合
            '    '@ﾛｯﾄ検定表印刷ﾌﾟﾚﾋﾞｭｰ画面をUnloadする
            '    Unload rptxxEN00F1
            '    '@ﾌﾟﾚﾋﾞｭｰ画面の解放
            '    Set rptxxEN00F1 = Nothing
            'End If
    
            ''@印刷ﾎﾞﾀﾝﾌｫｰﾑがLoadされているか判定する
            'If pubblnIsLoaded(pfrmReportPrint) = True Then
            '    '@印刷ﾎﾞﾀﾝﾌｫｰﾑを閉じる
            '    Unload pfrmReportPrint
            'End If
            ''@印刷ﾎﾞﾀﾝﾌｫｰﾑの存在確認
            'If Not pfrmReportPrint Is Nothing Then
            '    '@印刷ﾎﾞﾀﾝﾌｫｰﾑの解放
            '    Set pfrmReportPrint = Nothing
            'End If
    
            ''@印刷ﾎﾞﾀﾝﾌｫｰﾑがLoadされているか判定する
            'If pubblnIsLoaded(pfrmReportPrint2) = True Then
            '    '@印刷ﾎﾞﾀﾝﾌｫｰﾑを閉じる
            '    Unload pfrmReportPrint2
            'End If
            ''@印刷ﾎﾞﾀﾝﾌｫｰﾑの存在確認
            'If Not pfrmReportPrint2 Is Nothing Then
            '    '@印刷ﾎﾞﾀﾝﾌｫｰﾑの解放
            '    Set pfrmReportPrint2 = Nothing
            'End If
            '未使用機能NSYS ↑

            '@構造体の初期化
            If Not IsNothing(mtypProductList) Then            
                mtypProductList.Clear()
                mtypProductList = Nothing
            End If
            If Not IsNothing(mtypProductList2) Then              
                mtypProductList2.Clear()
                mtypProductList2 = Nothing
            End If
            If Not IsNothing(mtypProductList3) Then              
                mtypProductList3.Clear()
                mtypProductList3 = Nothing
            End If
            If Not IsNothing(mtypProductList4) Then              
                mtypProductList4.Clear()
                mtypProductList4 = Nothing
            End If
            If Not IsNothing(mtypDivisionList) Then            
                mtypDivisionList.Clear()
                mtypDivisionList = Nothing
            End If
            If Not IsNothing(mtypDivisionList2) Then              
                mtypDivisionList2.Clear()
                mtypDivisionList2 = Nothing
            End If
            If Not IsNothing(mtypDivisionList3) Then              
                mtypDivisionList3.Clear()
                mtypDivisionList3 = Nothing
            End If
            If Not IsNothing(mtypstocklotlist) Then              
                mtypstocklotlist.Clear()
                mtypstocklotlist = Nothing
            End If

             If Not IsNothing(mtypstocklotlist2) Then              
                mtypstocklotlist2.Clear()
                mtypstocklotlist2 = Nothing
            End If
             If Not IsNothing(mtypInvLotList.typLotListAns) Then              
                mtypInvLotList.typLotListAns.Clear()
                mtypInvLotList.typLotListAns = Nothing
            End If
             If Not IsNothing(mtypLotDetailInfo.typDivideLot2) Then              
                mtypLotDetailInfo.typDivideLot2.Clear()
                mtypLotDetailInfo.typDivideLot2 = Nothing
            End If
            mtypLotDetailInfo.lngDivideLot2Cnt = 0
            mlngStockListCnt = 0
            mblnAuthorityChkFlag = False

            '@sort保持用構造体のｸﾘｱ
            If Not IsNothing(mtypChgSortPutTab.typChgSortList) Then
                mtypChgSortPutTab.typChgSortList.Clear()
                mtypChgSortPutTab.typChgSortList = Nothing
            End If
            If Not IsNothing(mtypChgSortHoldTab.typChgSortList) Then
                mtypChgSortHoldTab.typChgSortList.Clear()
                mtypChgSortHoldTab.typChgSortList = Nothing
            End If
            If Not IsNothing(mtypChgSortWFTab.typChgSortList) Then
                mtypChgSortWFTab.typChgSortList.Clear()
                mtypChgSortWFTab.typChgSortList = Nothing
            End If
            If Not IsNothing(mtypChgSortSendTab.typChgSortList) Then
                mtypChgSortSendTab.typChgSortList.Clear()
                mtypChgSortSendTab.typChgSortList = Nothing
            End If
            If Not IsNothing(mtypChgSortCFEndTab.typChgSortList) Then
                mtypChgSortCFEndTab.typChgSortList.Clear()
                mtypChgSortCFEndTab.typChgSortList = Nothing
            End If

            '@引継ぎ用構造体の初期化
            ptypHoldConnect = ltypHoldConnect
            
            '@ﾒｰﾙ関連一式の構造体をｸﾘｱする。
            ptypDepartmentList = ltypDepartmentList
            ptypDeptEmpList = ltypDeptEmpList
            ptypSendMailList = ltypSendMailList
            ptypMailInfo = ltypMailInfo

            If Not IsNothing(ptypDepartmentList.typDepartmentList) Then
                ptypDepartmentList.typDepartmentList.Clear()
                ptypDepartmentList.typDepartmentList = Nothing
            End If
            If Not IsNothing(ptypDeptEmpList.typDeptEmpList) Then
                ptypDeptEmpList.typDeptEmpList.Clear()
                ptypDeptEmpList.typDeptEmpList = Nothing
            End If
            If Not IsNothing(ptypSendMailList.typSendMail) Then
                ptypSendMailList.typSendMail.Clear()
                ptypSendMailList.typSendMail = Nothing
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

    '関数名：cmbProductPut_Change
    '機　能：受入在庫-機種変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 10:57:09 S.Deguchi
    '更新日：2006/02/10 (Fri) 16:42:46 N.Kojima
    '備　考：
    '　　　：2006/02/10 (Fri) 16:42:46 N.Kojima     ﾎﾞﾀﾝの無効化制御を追加。(運用障害№539対応)
    Private Sub cmbProductPut_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProductPut.Change

        Try
            
            '@初期化
            '@種別Comboﾎﾞｯｸｽの初期化＆非活性化
            cmbDivisionPut.Clear
            cmbDivisionPut.Enabled = False
            
            '@受入在庫一覧のｸﾘｱ
            Call prvvsfLotListPut_Init()
            
            '@Commandﾎﾞﾀﾝの初期化
            cmdPartition.Enabled = False        '分割
            cmdHoldPut.Enabled = False          '保留
            cmdCancelPut.Enabled = False        '保留解除
            cmdWFPut.Enabled = False            '数量増減
            cmdCommentPut.Enabled = False       'ﾛｯﾄｺﾒﾝﾄ
            cmdPreCommentSend.Enabled = False   '前SB連絡表示
            cmdPutWFInfo.Enabled = False        'WF情報表示
            cmdNowListPut.Enabled = False       '最新取得
            cmdCopy.Enabled = False             'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProductPut_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProductPut_CloseUp
    '機　能：受入在庫-機種CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 10:57:12 S.Deguchi
    '更新日：2004/10/01 (Fri) 13:48:15 Y.Yamagishi
    '備　考：
    '　　　：2004/10/01 (Fri) 13:48:15 Y.Yamagishi  0項目選択でﾌｫｰｶｽ移動しないように修正
    Private Sub cmbProductPut_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProductPut.CloseUp

        Try

            '@空欄 or 0項目以外の場合
            If cmbProductPut.Text <> vbNullString And _
                cmbProductPut.Text <> CMstrCmbAddedCommentNone Then
                
                '@Validate処理
                RemoveHandler cmbProductPut.Validating,AddressOf cmbProductPut_Validate
                Call cmbProductPut_Validate( cmbProductPut,New CancelEventArgs(True))
                AddHandler cmbProductPut.Validating,AddressOf cmbProductPut_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProductPut_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProductPut_Validate
    '機　能：受入在庫-機種Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 10:57:15 S.Deguchi
    '更新日：2004/06/28 (Mon) 10:57:15
    '備　考：
    Private Sub cmbProductPut_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbProductPut.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If cmbProductPut.Text = vbNullString Or _
                cmbProductPut.Text = CMstrCmbAddedCommentNone Then
                '@空欄 or 0項目の場合
                
                '@閉じるにｾｯﾄﾌｫｰｶｽ
                If ActiveControl.Name = cmbProductPut.Name Then
                    Call pubSetFocus(cmdClose)
                End If

                Exit Sub
            Else
                If cmbDivisionPut.Text = vbNullString Then
                    '@空欄 or 0項目の場合
                    '@種別Combo作成
                    Call prvcmbDivisionList_Disp(CMlngPutTab)
                End If
                
                '@種別へｾｯﾄﾌｫｰｶｽ
                If ActiveControl.Name = cmbProductPut.Name Then
                    Call pubSetFocus(cmbDivisionPut)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProductPut_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDivisionPut_Change
    '機　能：受入在庫-種別変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 16:23:18 S.Deguchi
    '更新日：2006/02/10 (Fri) 17:04:17 N.Kojima
    '備　考：
    '　　　：2006/02/10 (Fri) 17:04:17 N.Kojima     ﾎﾞﾀﾝの無効化制御を追加。(運用障害№539対応)
    Private Sub cmbDivisionPut_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDivisionPut.Change

        Try

            '@初期化
            '@受入在庫一覧のｸﾘｱ
            Call prvvsfLotListPut_Init()
                
            '@Commandﾎﾞﾀﾝの初期化
            cmdPartition.Enabled = False        '分割
            cmdHoldPut.Enabled = False          '保留
            cmdCancelPut.Enabled = False        '保留解除
            cmdWFPut.Enabled = False            '数量増減
            cmdCommentPut.Enabled = False       'ﾛｯﾄｺﾒﾝﾄ
            cmdPreCommentSend.Enabled = False   '前SB連絡表示
            cmdPutWFInfo.Enabled = False        'WF情報表示
            cmdNowListPut.Enabled = False       '最新取得
            cmdCopy.Enabled = False             'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
                
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSortPutTab.strKey = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbDivisionPut_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDivisionPut_CloseUp
    '機　能：受入在庫-種別CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 16:23:27 S.Deguchi
    '更新日：2004/10/01 (Fri) 13:49:26 Y.Yamagishi
    '備　考：
    '　　　：2004/10/01 (Fri) 13:49:26 Y.Yamagishi　0項目選択でﾌｫｰｶｽ移動しないように修正
    Private Sub cmbDivisionPut_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDivisionPut.CloseUp

        Try

            '@空欄 or 0項目以外の場合
            If cmbDivisionPut.Text <> vbNullString And _
                cmbDivisionPut.Text <> CMstrCmbAddedCommentNone Then
                
                '@Validate処理へ
                RemoveHandler cmbDivisionPut.Validating,AddressOf cmbDivisionPut_Validate
                Call cmbDivisionPut_Validate(cmbDivisionPut,New CancelEventArgs(True))
                AddHandler cmbDivisionPut.Validating,AddressOf cmbDivisionPut_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbDivisionPut_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDivisionPut_Validate
    '機　能：受入在庫-種別Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 16:23:30 S.Deguchi
    '更新日：2004/06/28 (Mon) 16:23:30
    '備　考：
    Private Sub cmbDivisionPut_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbDivisionPut.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@種別の選択状況による処理分岐
            '@種別選択がされていない,「0 項目選択」の場合
            If cmbDivisionPut.Text = vbNullString Or _
                cmbDivisionPut.Text = CMstrCmbAddedCommentNone Then
                
                If ActiveControl.Name = cmbDivisionPut.Name Then
                    If cmdNowListPut.Enabled = True Then
                        '@最新取得へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdNowListPut)
                    Else
                        '@閉じるにｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmdClose)
                    End If
                End If

                Exit Sub
            End If
                
            If ActiveControl.Name <> cmbDivisionPut.Name Then
                mblnSetFocus = True
            End If

            '@最新情報取得処理へ
            Call cmdNowListPut_Click(cmdNowListPut,New EventArgs)

            mblnSetFocus = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbDivisionPut_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowListPut_Click
    '機　能：受入在庫-最新取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 17:31:46 S.Deguchi
    '更新日：2004/10/18 (Mon) 17:18:55 Y.Yamagishi
    '備　考：
    '　　　：2004/10/18 (Mon) 17:18:55 Y.Yamagishi  0件表示のﾒｯｾｰｼﾞﾎﾞｯｸｽを表示しない(ｺﾒﾝﾄｱｳﾄ)不具合改善№1093
    '　　　：2008/07/07 (Mon) 12:00:00 S.Ochiai     欠損ﾁｯﾌﾟ表示対応(No.03046)及びSource整備
    Private Sub cmdNowListPut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowListPut.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypInvAcptLotListReq   As invAcptLotListReq    '要求格納構造体
        Dim ltypInvAcptLotListAns   As InvAcptLotListAns    '応答格納構造体
        Dim llngInvAcptLotListCnt   As Integer              '応答ﾃﾞｰﾀﾛｯﾄﾘｽﾄ数
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngLoopCnt             As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrTemp                As Object               '一時取得

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
            
            '@空欄 or 0項目の場合
            If cmbProductPut.Text = vbNullString Or _
                cmbProductPut.Text = CMstrCmbAddedCommentNone Then
                If mblnSetFocus = False Then
                    Call pubSetFocus(cmbProductPut)
                End If
                Exit Sub
            End If
            
            '@空欄 or 0項目の場合
            If cmbDivisionPut.Text = vbNullString Or _
                cmbDivisionPut.Text = CMstrCmbAddedCommentNone Then
                If mblnSetFocus = False Then
                    Call pubSetFocus(cmbDivisionPut)
                End If
                Exit Sub
            End If
            
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
            lstrFormName = Me.Name
            lstrEventName = "cmdNowList_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
                                    
            'NSYS 選択行がある場合
            If vsfLotListPut.Row > 0 Then
                'NSYS 選択列をNo.列に移動
                vsfLotListPut.Col = CMlngvsfPutColNo
            End If

            '@要求格納構造体の初期化
            If ltypInvAcptLotListReq.typPdList Is Nothing Then
                ltypInvAcptLotListReq.typPdList = New List(Of PDList)
            Else
                ltypInvAcptLotListReq.typPdList.Clear
            End If
            If ltypInvAcptLotListReq.typFlowClassList Is Nothing Then
                ltypInvAcptLotListReq.typFlowClassList = New List(Of FlowClassList)
            Else
                ltypInvAcptLotListReq.typFlowClassList.Clear
            End If

            '@要求格納構造体へ格納
            With ltypInvAcptLotListReq
                .strMsgVer = CMstrinv_acptlotlistVer                                            'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strClassDivision = CPstrCD02   '02:全件検索
                .strSbID = pstrSBID                                                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                
                .lngPdCnt = cmbProductPut.ValueCount                                            'PD_IDｶｳﾝﾄ数
                '@機種区分構造体作成
                Dim typPdListTmp As New PDList
                lstrTemp = Split(cmbProductPut.Value, vbTab)
                For llngLoopCnt = LBound(lstrTemp) To UBound(lstrTemp)
                    typPdListTmp.strPdId = lstrTemp(llngLoopCnt)                 '機種ID
                    .typPdList.Add(typPdListTmp)
                Next llngLoopCnt
                
                .lngFlowClassCnt = cmbDivisionPut.ValueCount                                    'Classｶｳﾝﾄ数
                '@種別区分構造体作成
                Dim typFlowClassListTmp As New FlowClassList
                lstrTemp = Split(cmbDivisionPut.Value, vbTab)
                For llngLoopCnt = LBound(lstrTemp) To UBound(lstrTemp)
                    typFlowClassListTmp.strFlowClass = lstrTemp(llngLoopCnt)     '種別ID
                    .typFlowClassList.Add(typFlowClassListTmp)
                Next llngLoopCnt
                
            End With
            
            '@受入在庫Lot一覧取得
            lblnAns = pubblnInvAcptlotList_Sel(ltypInvAcptLotListReq, _
                                               ltypInvAcptLotListAns, _
                                               llngInvAcptLotListCnt)
            '@結果判定
            If lblnAns = True Then

                '@一覧表示
                Call prvvsfLotListPut_Disp(ltypInvAcptLotListAns, llngInvAcptLotListCnt)

                '@最新取得ﾎﾞﾀﾝ活性化
                cmdNowListPut.Enabled = True
                
                If vsfLotListPut.Enabled = True Then
                    If mblnSetFocus = False Then
                        '@一覧へｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(vsfLotListPut)
                    End If
                    '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの活性化
                    cmdCopy.Enabled = True
                Else
                     If mblnSetFocus = False Then
                        '@最新取得ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmdNowListPut)
                    End If
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
                If lblLotCntPut.Text = CPstrLotCnt0 Then
        '            '@表示ﾒｯｾｰｼﾞ変換
        '            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0029, lblLotCntPut.Caption)
        '            '@publngMsgBoxInfo("メッセージコード：C_I29%0$$該当件数 ： 0 件")
        '            Call publngMsgBoxInfo(pstrDMsg, vbInformation, frmxxEN00F0.Caption, True, 16)
                
                    '@各ﾎﾞﾀﾝの非活性化
                    cmdPartition.Enabled = False
                    cmdHoldPut.Enabled = False
                    cmdCancelPut.Enabled = False
                    cmdWFPut.Enabled = False
                    cmdCommentPut.Enabled = False
                    cmdPreCommentSend.Enabled = False
                End If
            Else
                '@受入在庫一覧のｸﾘｱ
                Call prvvsfLotListPut_Init()

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                cmdNowListPut.Enabled = True
                
                If mblnSetFocus = False Then
                    Call pubSetFocus(cmbProductPut)
                End If

                Exit Sub
            End If

            'NSYS 選択行が未指定の場合はヘッダ行を選択状態にする
            If vsfLotListPut.Row < 0 Then
                vsfLotListPut.Row = 0
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowListPut_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdPartition_Click
    '機　能：受入在庫-分割ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 16:16:32 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:27:02 T.Oide
    '備　考：
    '　　　：2006/03/28 (Tue) 20:30:17 N.Kojima     分割予約確定Msg送信時にINVENTORY_LOTﾃｰﾌﾞﾙの最終更新日時を送り
    '　　　：                                       LOT_STATUSﾃｰﾌﾞﾙの最終更新日時を比較している為、P/Rｵｰﾀﾞｰ変更を行なうとｴﾗｰになる。
    '　　　：                                       上記の件の対応として、LOT_STATUSﾃｰﾌﾞﾙの最終更新日時を引き継ぐように修正(暫定)。(ﾕｰｻﾞｰ要望№0155)
    '　　　：2012/01/24 (Tue) 13:27:02 T.Oide       REQ-1115で関数共通化
    Private Sub cmdPartition_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPartition.Click
        
        Dim lstrKeyID           As String       'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow          As Integer      '現在行を格納
        Dim lblnAns             As Boolean      '戻り値
        Dim lstrLotID           As String       'ﾛｯﾄID
        Dim lstrFormName        As String       'ﾌｫｰﾑ名
        Dim lstrEventName       As String       'ｲﾍﾞﾝﾄ名

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
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "prvHoldConnect_Set"
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ﾛｯﾄIDを格納(送信用)
            lstrLotID = vsfLotListPut.GetData(vsfLotListPut.Row, CMlngvsfPutColLotID)

            '@ﾛｯﾄ情報詳細取得処理(ﾛｯﾄで取得)
            lblnAns = pubblnLotDetail_Sel(CMstrlot_detail__Ver, _
                                          pstrSBID, _
                                          CPstrCD0L, _
                                          lstrLotID, _
                                          vbNullString, _
                                          mtypLotDetailInfo)

            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngPutTab)
            
            '@LOT_STATUSﾃｰﾌﾞﾙの最終更新日時を使用する(暫定的対応なので、改善が必要)
            ptypHoldConnect.strLastUpdate = mtypLotDetailInfo.strLotLastUpdate
                
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListPut
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfPutColLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN00F3.Instance = New frmxxEN00F3()
            
            '@子画面名称設定
            frmxxEN00F3.Instance.Text = CPstrSubFormEN00F3
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00F3.Instance = Nothing
                Exit Sub
            End If
            
            '@分割画面起動
            frmxxEN00F3.Instance.ShowDialog(Me)
            frmxxEN00F3.Instance = Nothing
            
            '@最新取得処理
            Call cmdNowListPut_Click(cmdNowListPut,New EventArgs)
            
            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListPut, lstrKeyID, CMlngvsfPutColLotID, cmdClose)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPartition_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdHoldPut_Click
    '機　能：受入在庫-保留ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 16:16:35 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:27:58 T.Oide
    '備　考：
    Private Sub cmdHoldPut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHoldPut.Click
        
        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

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

            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngPutTab)
            
            '@起動区分ｾｯﾄ(保留起動)
            ptypHoldConnect.strLotHoldFlg = "0"
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListPut
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfPutColLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN00F1.Instance = New frmxxEN00F1()
            
            '@子画面名称設定
            frmxxEN00F1.Instance.Text = CPstrSubFormEN00F1Hold
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00F1.Instance = Nothing
                Exit Sub
            End If
            
            '@保留画面起動
            frmxxEN00F1.Instance.ShowDialog(Me)
            frmxxEN00F1.Instance = Nothing

            '@最新取得処理
            Call cmdNowListPut_Click(cmdNowListPut,New EventArgs)
            
            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListPut, lstrKeyID, CMlngvsfPutColLotID, cmdClose)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdHoldPut_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCancelPut_Click
    '機　能：受入在庫-保留解除ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 16:16:38 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:28:07 T.Oide
    '備　考：
    Private Sub cmdCancelPut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelPut.Click

        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

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
            
            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngPutTab)
            '@起動区分ｾｯﾄ(保留解除起動)
            ptypHoldConnect.strLotHoldFlg = "1"
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListPut
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfPutColLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN00F1.Instance = New frmxxEN00F1()
            
            '@子画面名称設定
            frmxxEN00F1.Instance.Text = CPstrSubFormEN00F1Cancel
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00F1.Instance = Nothing
                Exit Sub
            End If
            
            '@保留解除画面起動
            frmxxEN00F1.Instance.ShowDialog(Me)
            frmxxEN00F1.Instance = Nothing

            '@最新取得処理
            Call cmdNowListPut_Click(cmdNowListPut,New EventArgs)

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListPut, lstrKeyID, CMlngvsfPutColLotID, cmdClose)
              
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCancelPut_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWFPut_Click
    '機　能：受入在庫-払出ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 16:16:41 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:28:20 T.Oide
    '備　考：
    Private Sub cmdWFPut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWFPut.Click

        Dim lstrKeyID       As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow      As Integer  '現在行を格納
        Dim llngAns         As Integer  '確認ﾒｯｾｰｼﾞの結果格納
        Dim lstrFlowClass   As String   '流動種別

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
            
            '@ｸﾞﾘｯﾄﾞ選択行の流動種別格納
            lstrFlowClass = vsfLotListPut.GetData(vsfLotListPut.Row, CMlngvsfPutColFlowClass)
            
            '@PR、ES品の場合は伝票処理が必要の旨ﾒｯｾｰｼﾞを表示
            If lstrFlowClass = CPstrFlowClassPR Or _
               lstrFlowClass = CPstrFlowClassES Then
                
                '@ﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0115, CPstrClass3J)
                '@<TRM115W>$$PR/ES品を[%1]する場合、別途伝票の発行が必要です。
                '　　　　　$$生産管理部門と調整のうえ伝票の発行を行ってください｡
                llngAns = publngMsgBox(pstrDMsg, vbNo, Me.Text, True, 16)
                
                '@いいえの場合は処理を中止
                If llngAns = vbNo Then
                    Exit Sub
                End If
            End If
            
            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngPutTab)
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListPut
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfPutColLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN00F2.Instance = New frmxxEN00F2()
            
            '@子画面名称設定
            frmxxEN00F2.Instance.Text = CPstrSubFormEN00F2
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00F2.Instance = Nothing
                Exit Sub
            End If
            
            '@払出画面起動
            frmxxEN00F2.Instance.ShowDialog(Me)
            frmxxEN00F2.Instance = Nothing

            '@最新取得処理
            Call cmdNowListPut_Click(cmdNowListPut,New EventArgs)

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListPut, lstrKeyID, CMlngvsfPutColLotID, cmdClose)
            
            '@ﾌｫｰｶｽｾｯﾄ
            With vsfLotListPut
                '@選択行がﾀｲﾄﾙの場合
                If .Row = 0 Then
                    '@各ﾎﾞﾀﾝの非活性化
                    cmdPartition.Enabled = False
                    cmdHoldPut.Enabled = False
                    cmdCancelPut.Enabled = False
                    cmdWFPut.Enabled = False
                    cmdCommentPut.Enabled = False
                    cmdPreCommentSend.Enabled = False
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWFPut_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentPut_Click
    '機　能：受入在庫-ｺﾒﾝﾄ表示ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/08 (Thu) 10:14:08 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:28:55 T.Oide
    '備　考：
    '　　　：2004/12/08 (Wed) 17:46:48 H.Wajima     不具合修正
    '　　　：2006/02/08 (Wed) 16:22:02 N.Kojima     編集ﾌﾗｸﾞをTrueで設定し、ﾛｯﾄｺﾒﾝﾄの登録も可能とする。(運用障害№539対応)
    '　　　：2012/01/24 (Tue) 13:28:55 T.Oide       REQ-1115関数共通化
    Private Sub cmdCommentPut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentPut.Click

        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngPutTab)
            
            '@編集ﾌﾗｸﾞに編集不可を設定
            ptypHoldConnect.blnEditFlag = True
            
            '@子画面名称設定
            frmxxEN00F4.Instance.Text = CPstrSubFormEN00F4
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListPut
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfPutColLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@払出画面起動
            frmxxEN00F4.Instance.ShowDialog(Me)
            frmxxEN00F4.Instance = Nothing

            '@ﾛｯﾄｺﾒﾝﾄが更新されているか
            If pblnCommetsCommitFlag = True Then
                '@最新情報の取得
                Call cmdNowListPut_Click(cmdNowListPut,New EventArgs)
                
                '@ﾛｯﾄｺﾒﾝﾄ更新ﾌﾗｸﾞを初期化
                pblnCommetsCommitFlag = False
            End If

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListPut, lstrKeyID, CMlngvsfPutColLotID, cmdClose)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommentPut_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdPreCommentSend_Click
    '機　能：前SB連絡表示ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/05 (Thu) 17:01:57 N.Kasai
    '更新日：2012/01/24 (Tue) 13:29:30 T.Oide
    '備　考：
    '　　　：2005/01/11 (Tue) 18:09:26 H.Wajima     前SB連絡情報画面をEN00F8に移動
    '　　　：2012/01/24 (Tue) 13:29:30 T.Oide       REQ-1115で関数共通化
    Private Sub cmdPreCommentSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPreCommentSend.Click

        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngPutTab)
            
            '@ﾀｲﾄﾙ判定ﾌﾗｸﾞ(前SB連絡)
            ptypHoldConnect.strTitleFlg = CPstrSubFormEN00F4Pre
            
            '@編集ﾌﾗｸﾞ(入力不可)
            ptypHoldConnect.blnEditFlag = False
            
            '@子画面名称設定
            frmxxEN00F8.Instance.Text = CPstrSubFormEN00F4Pre
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListPut
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfPutColLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@ｺﾒﾝﾄ画面起動
            frmxxEN00F8.Instance.ShowDialog(Me)
            frmxxEN00F8.Instance = Nothing

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListPut, lstrKeyID, CMlngvsfPutColLotID, cmdClose)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPreCommentSend_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdPutWFInfo_Click
    '機　能：WF情報表示ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/05 (Mon) 10:53:02 N.Kojima
    '更新日：2012/01/24 (Tue) 13:30:10 T.Oide
    '備　考：
    Private Sub cmdPutWFInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPutWFInfo.Click

        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

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
            
            '@引継ぎ構造体に格納
            With vsfLotListPut
                '@引継ぎ構造体を初期化
                ptypCommonInfo.strCarrierId = .GetData(.Row, CMlngvsfPutColCarrierID)          'ｷｬﾘｱID
                ptypCommonInfo.strLotID = .GetData(.Row, CMlngvsfPutColLotID)                  'ﾛｯﾄID
                ptypCommonInfo.strFlowClass = .GetData(.Row, CMlngvsfPutColFlowClass)          '種別
                ptypCommonInfo.strSlotSize = .GetData(.Row, CMlngvsfPutColSlotSize)            'ｽﾛｯﾄｻｲｽﾞ
            End With
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListPut
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfPutColLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面(WF情報)をﾛｰﾄﾞ
            frmxxEN00FA.Instance = New frmxxEN00FA()
            
            '@子画面名称設定
            frmxxEN00FA.Instance.Text = CPstrSubFormEN00FA
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00FA.Instance = Nothing
                Exit Sub
            End If
            
            '@WF情報画面起動
            Call frmxxEN00FA.Instance.ShowDialog(Me)

            With ptypCommonInfo
                '@引継ぎ構造体を初期化
                .strCarrierId = vbNullString      'ｷｬﾘｱID
                .strLotID = vbNullString          'ﾛｯﾄID
                .strFlowClass = vbNullString      '種別
                .strSlotSize = vbNullString       'ｽﾛｯﾄｻｲｽﾞ
            End With

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListPut, lstrKeyID, CMlngvsfPutColLotID, cmdClose)
            
            '@ﾌｫｰｶｽｾｯﾄ
            With vsfLotListPut
                '@選択行がﾀｲﾄﾙの場合
                If .Row = 0 Then
                    '@各ﾎﾞﾀﾝの非活性化
                    cmdPartition.Enabled = False            '分割/移載
                    cmdHoldPut.Enabled = False              '保留
                    cmdCancelPut.Enabled = False            '保留解除
                    cmdWFPut.Enabled = False                '数量増減
                    cmdCommentPut.Enabled = False           'ﾛｯﾄｺﾒﾝﾄ
                    cmdPutWFInfo.Enabled = False            'WF情報表示
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPutWFInfo_Click"         '処理名
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：vsfLotListHold_AfterUserResize
    '機　能：ｸﾞﾘｯﾄﾞｻｲｽﾞ変更
    '引　数：Row：変更行
    '　　　：Col：変更列
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 09:05:36 N.Kasai
    '更新日：2004/10/15 (Fri) 09:05:36
    '備　考：
    Private Sub vsfLotListHold_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotListHold.AfterResizeColumn, vsfLotListHold.AfterResizeRow

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListHold.Rows.Count <= vsfLotListHold.Rows.Fixed Then
                Return
            End If

             '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSortHoldTab.blnChgWidth = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListHold_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListHold_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞﾌｫｰｶｽ移動
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 09:08:07 N.Kasai
    '更新日：2004/10/15 (Fri) 09:08:07
    '備　考：
    Private Sub vsfLotListHold_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLotListHold.BeforeRowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListHold.Rows.Count <= vsfLotListHold.Rows.Fixed Then
                Return
            End If
                
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ﾛｯﾄID)
                mtypChgSortHoldTab.strKey = vsfLotListHold.GetData(e.NewRange.r1, CMlngvsfHoldColLotID)
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListHold_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListPut_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 18:45:15 S.Deguchi
    '更新日：2004/07/07 (Wed) 18:45:15
    '備　考：
    Private Sub vsfLotListPut_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotListPut.AfterSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListPut.Rows.Count <= vsfLotListPut.Rows.Fixed Then
                Return
            End If

            AddHandler vsfLotListPut.BeforeRowColChange,AddressOf vsfLotListPut_BeforeRowColChange
            AddHandler vsfLotListPut.EnterCell,AddressOf vsfLotListPut_EnterCell

            '@ｿｰﾄ順を格納
            With mtypChgSortPutTab

                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                Do While (.typChgSortList.Count -1 < .lngCnt)
                    .typChgSortList.Add(New ChgSortList)
                Loop
                Dim typChgSortListTmp As ChgSortList = New ChgSortList
                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納(昇順/降順)
                typChgSortListTmp.lngOrder = e.Order
                .typChgSortList(.lngCnt) = typChgSortListTmp

                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
            End With

            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
            Call pubVsfAfterSort(vsfLotListPut, CMlngVsfRowTitle,Nothing, Nothing, False, False, False, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListPut_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListPut_AfterUserResize
    '機　能：ｸﾞﾘｯﾄ列幅変更
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2004/10/14 (Thu) 16:31:34 N.Kasai
    '更新日：2004/10/14 (Thu) 16:31:34
    '備　考：
    Private Sub vsfLotListPut_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotListPut.AfterResizeColumn, vsfLotListPut.AfterResizeRow

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListPut.Rows.Count <= vsfLotListPut.Rows.Fixed Then
                Return
            End If
            
            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSortPutTab.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListPut_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListPut_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄ変更処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/10/14 (Thu) 16:35:05 N.Kasai
    '更新日：2004/10/14 (Thu) 16:35:05
    '備　考：
    Private Sub vsfLotListPut_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLotListPut.BeforeRowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListPut.Rows.Count <= vsfLotListPut.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がデータ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のKEYを格納(ﾛｯﾄID)
                mtypChgSortPutTab.strKey = vsfLotListPut.GetData(e.NewRange.r1, CMlngvsfPutColLotID)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListPut_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListPut_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 18:45:18 S.Deguchi
    '更新日：2004/07/07 (Wed) 18:45:18
    '備　考：
    Private Sub vsfLotListPut_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotListPut.BeforeSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListPut.Rows.Count <= vsfLotListPut.Rows.Fixed Then
                Return
            End If

            RemoveHandler vsfLotListPut.BeforeRowColChange,AddressOf vsfLotListPut_BeforeRowColChange
            RemoveHandler vsfLotListPut.EnterCell,AddressOf vsfLotListPut_EnterCell

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfBeforeSort(vsfLotListPut, CMlngVsfRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListPut_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListPut_EnterCell
    '機　能：受入在庫選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 16:34:11 S.Deguchi
    '更新日：2006/02/03 (Fri) 10:44:54 N.Kojima
    '備　考：
    '　　　：2004/10/06 (Wed) 13:41:24 S.Deguchi    使用可能ﾎﾞﾀﾝ制御追加
    '　　　：2004/11/02 (Tue) 11:29:31 N.Kasai      「移載中」の場合分割/移載ﾎﾞﾀﾝの使用不可
    '　　　：2005/04/14 (Thu) 09:00:18 S.Deguchi    複数保留対応
    '　　　：2005/09/02 (Fri) 11:52:16 N.Kojima     WF情報表示ﾎﾞﾀﾝ追加に伴う対応。(不具合№3047)
    '　　　：2006/02/03 (Fri) 10:44:54 N.Kojima     ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝを無条件で有効にする。(運用障害№539対応)
    Private Sub vsfLotListPut_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotListPut.EnterCell

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListPut.Rows.Count <= vsfLotListPut.Rows.Fixed Then
                Return
            End If

            With vsfLotListPut
                '@ﾍｯﾀﾞｰ以外の場合
                If .Row > 0 Then
                    
                    '@保留ﾌﾗｸﾞが立っている場合
                    If .GetData(.Row, CMlngvsfPutColHoldFlag) = CMstrLotHoldFlgOn Then
                        '@保留ﾎﾞﾀﾝを非活性化
                        cmdHoldPut.Enabled = True
                        '@保留解除ﾎﾞﾀﾝを活性化
                        cmdCancelPut.Enabled = True
                        '@分割ﾎﾞﾀﾝを非活性化
                        cmdPartition.Enabled = False
                        '@数量払出ﾎﾞﾀﾝを活性化
                        cmdWFPut.Enabled = True
                    Else
                        '@保留ﾎﾞﾀﾝを活性化
                        cmdHoldPut.Enabled = True
                        
                        '@保留解除ﾎﾞﾀﾝを非活性化
                        cmdCancelPut.Enabled = False
                        
                        '@分割状態による分割と払出の活性化処理
                        Select Case .GetData(.Row, CMlngvsfPutColDivideStatus)
                            
                            Case CMstrDevideStatusFlag0
                            '@送品直後の状態
                                '@分割ﾎﾞﾀﾝ、数量払出ﾎﾞﾀﾝを活性化
                                cmdPartition.Enabled = True
                                cmdWFPut.Enabled = True
                            
                            Case CMstrDevideStatusFlag1
                            '@移載予約済みの状態
                                '@分割ﾎﾞﾀﾝ、数量払出ﾎﾞﾀﾝを非活性化
                                cmdPartition.Enabled = False
                                cmdWFPut.Enabled = False
                            
                            Case CMstrDevideStatusFlag2
                            '@移載完了の状態
                                '@分割ﾎﾞﾀﾝ非活性化、数量払出ﾎﾞﾀﾝを活性化
                                cmdPartition.Enabled = False
                                cmdWFPut.Enabled = True
                        End Select
                    End If
                    
                    '@移載中の場合は分割/移載ﾎﾞﾀﾝの使用不可)
                    If InStr(1, .GetData(.Row, CMlngvsfPutColKb), CMstrIsai) <> 0 Then
                        '@分割ﾎﾞﾀﾝ使用不可、数量払出ﾎﾞﾀﾝを使用不可
                        cmdPartition.Enabled = False
                        cmdWFPut.Enabled = False
                    End If
                    
                    '@分割中の場合は分割/移載ﾎﾞﾀﾝの使用不可)
                    If InStr(1, .GetData(.Row, CMlngvsfPutColKb), CMstrBun) <> 0 Then
                        '@分割ﾎﾞﾀﾝ使用不可、数量払出ﾎﾞﾀﾝを使用不可
                        cmdPartition.Enabled = False
                        cmdWFPut.Enabled = False
                    End If
                    
                    '@無条件でﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝを活性化
                    cmdCommentPut.Enabled = True
                                
                    '@前SB連絡が入力されている場合
                    If .GetData(.Row, CMlngvsfPutColInvComments) <> vbNullString Then
                        '@前SB連絡表示ﾎﾞﾀﾝを活性化
                        cmdPreCommentSend.Enabled = True
                    Else
                        '@前SB連絡表示ﾎﾞﾀﾝを非活性化
                        cmdPreCommentSend.Enabled = False
                    End If
                    
                    '@WF情報表示ﾎﾞﾀﾝの制御追加
                    '@WF枚数が"0"ではない
                    If .GetData(.Row, CMlngvsfPutColWfNum) <> 0 Then
                        '@WF情報表示ﾎﾞﾀﾝを有効に
                        cmdPutWFInfo.Enabled = True
                    Else
                        '@WF情報表示ﾎﾞﾀﾝを無効に
                        cmdPutWFInfo.Enabled = False
                    End If
                Else
                    '@WF情報表示ﾎﾞﾀﾝを無効に
                    cmdPutWFInfo.Enabled = False
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListPut_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbproductHold_Change
    '機　能：保管在庫-機種変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 10:57:09 S.Deguchi
    '更新日：2006/02/10 (Fri) 17:29:50 N.Kojima
    '備　考：
    '　　　：2006/02/10 (Fri) 17:29:50 N.Kojima     ﾎﾞﾀﾝの無効化制御を追加。(運用障害№539対応)
    Private Sub cmbproductHold_Change()

        Try
            
            '@初期化
            '@種別Comboﾎﾞｯｸｽの初期化＆非活性化
            cmbDivisionHold.Clear
            cmbDivisionHold.Enabled = False
            
            '@保管在庫一覧のｸﾘｱ
            Call prvvsfLotListHold_Init()
                
            '@Commandﾎﾞﾀﾝの初期化
            cmdHoldHold.Enabled = False         '保留
            cmdCancelHold.Enabled = False       '保留解除
            cmdWFHold.Enabled = False           '数量増減
            cmdCommentHold.Enabled = False      'ﾛｯﾄｺﾒﾝﾄ表示
            cmdHoldWFInfo.Enabled = False       'WF情報表示
            cmdNowListHold.Enabled = False      '最新取得
            cmdCopy.Enabled = False             'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbproductHold_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbdivisionhold_Change
    '機　能：保管在庫-種別変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 16:23:18 S.Deguchi
    '更新日：2006/02/10 (Fri) 16:36:44 N.Kojima
    '備　考：
    '　　　：2006/02/10 (Fri) 16:36:44 N.Kojima     ﾎﾞﾀﾝの無効化制御を追加。(運用障害№539対応)
    Private Sub cmbdivisionhold_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbdivisionhold.Change

        Try

            '@初期化
            '@保管在庫一覧のｸﾘｱ
            Call prvvsfLotListHold_Init()
            
            '@Commandﾎﾞﾀﾝの初期化
            cmdHoldHold.Enabled = False         '保留
            cmdCancelHold.Enabled = False       '保留解除
            cmdWFHold.Enabled = False           '数量増減
            cmdCommentHold.Enabled = False      'ﾛｯﾄｺﾒﾝﾄ表示
            cmdHoldWFInfo.Enabled = False       'WF情報表示
            cmdNowListHold.Enabled = False      '最新取得
            cmdCopy.Enabled = False             'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
                
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSortHoldTab.strKey = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbdivisionhold_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbdivisionhold_CloseUp
    '機　能：保管在庫-種別CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 16:23:27 S.Deguchi
    '更新日：2004/10/01 (Fri) 13:55:28 Y.Yamagishi
    '備　考：
    '　　　：2004/10/01 (Fri) 13:55:28 Y.Yamagishi　0項目選択でﾌｫｰｶｽ移動しないように修正
    Private Sub cmbdivisionhold_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbdivisionhold.CloseUp

        Try

            '@空欄 or 0項目以外の場合
            If cmbDivisionHold.Text <> vbNullString And _
               cmbDivisionHold.Text <> CMstrCmbAddedCommentNone Then
                
                '@Validate処理へ
                RemoveHandler cmbdivisionhold.Validating,AddressOf cmbdivisionhold_Validate
                Call cmbdivisionhold_Validate(cmbdivisionhold,New CancelEventArgs(True))
                AddHandler cmbdivisionhold.Validating,AddressOf cmbdivisionhold_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbdivisionhold_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbdivisionhold_Validate
    '機　能：保管在庫-種別Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 16:23:30 S.Deguchi
    '更新日：2004/06/28 (Mon) 16:23:30
    '備　考：
    Private Sub cmbdivisionhold_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbdivisionhold.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@種別の選択状況による処理分岐
            '@種別選択がされていない,「0 項目選択」の場合
            If cmbDivisionHold.Text = vbNullString Or _
               cmbDivisionHold.Text = CMstrCmbAddedCommentNone Then
                
                If ActiveControl.Name = cmbdivisionhold.Name Then
                    If cmdNowListHold.Enabled = True Then
                        '@最新取得へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdNowListHold)
                    Else
                        '@閉じるにｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmdClose)
                    End If
                End If

                Exit Sub
            
            End If
                
            If ActiveControl.Name <> cmbdivisionhold.Name Then
                mblnSetFocus = True
            End If

            '@最新情報取得処理へ
            Call cmdNowListHold_Click(cmdNowListHold,New EventArgs)
            
            mblnSetFocus = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbdivisionhold_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowListHold_Click
    '機　能：保管在庫-最新取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 11:08:07 S.Deguchi
    '更新日：2007/12/11 (Tue) 16:21:51 N.Kasai
    '備　考：
    '　　　：2004/10/18 (Mon) 17:18:37 Y.Yamagishi  0件表示のﾒｯｾｰｼﾞﾎﾞｯｸｽを表示しない(ｺﾒﾝﾄｱｳﾄ)不具合改善№1093
    '　　　：2007/12/11 (Tue) 16:21:51 N.Kasai      機種検索条件削除
    Private Sub cmdNowListHold_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowListHold.Click
        
        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypRequestList         As InvAcptListRequest   '要求格納構造体
        Dim ltypInvActptLotList     As InvAcptLotList       '応答格納構造体
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngLoopCnt             As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrTemp                As Object               '一時取得

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
            
            '@空欄 or 0項目の場合
            If cmbDivisionHold.Text = vbNullString Or _
                cmbDivisionHold.Text = CMstrCmbAddedCommentNone Then

                If mblnSetFocus = False Then
                    Call pubSetFocus(cmbDivisionHold)
                End If

                Exit Sub
            End If
            
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
            lstrFormName = Me.Name
            lstrEventName = "cmdNowList_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
                          
            'NSYS 選択行がある場合
            If vsfLotListHold.Row > 0 Then
                'NSYS 選択列をNo.列に移動
                vsfLotListHold.Col = CMlngvsfHoldColNo
            End If

            '@要求格納構造体の初期化
            If ltypRequestList.typPdList Is Nothing Then
                ltypRequestList.typPdList = New List(Of PDList)
            Else
                ltypRequestList.typPdList.Clear
            End If
            If ltypRequestList.typFlowClassList Is Nothing Then
                ltypRequestList.typFlowClassList = New List(Of FlowClassList)
            Else
                ltypRequestList.typFlowClassList.Clear
            End If

            '@要求格納構造体へ格納
            With ltypRequestList
                .strSbID = pstrSBID                                                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                
                .strClassDivision = CPstrCD0F                                                   'ClassDivision:0F(保管ﾛｯﾄ)
                
                .lngFlowClassCnt = cmbDivisionHold.ValueCount                                   'Classｶｳﾝﾄ数
                '@種別区分構造体作成
                Dim typFlowClassListTmp As New FlowClassList
                lstrTemp = Split(cmbDivisionHold.Value, vbTab)
                For llngLoopCnt = LBound(lstrTemp) To UBound(lstrTemp)
                    typFlowClassListTmp.strFlowClass = lstrTemp(llngLoopCnt)     '種別ID
                    .typFlowClassList.Add(typFlowClassListTmp)
                Next llngLoopCnt
                
                .strMsgVer = CMstrlot_holdlistVer                                               'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
            End With
            
            '@=======================
            '@ 保管在庫Lot一覧取得
            '@=======================
            lblnAns = pubblnLotHoldList_Sel(CMstrlot_holdlistVer, _
                                            ltypRequestList, _
                                            ltypInvActptLotList)
            '@結果判定
            If lblnAns = True Then
                
                '@=======================
                '@ 保留在庫一覧表示
                '@=======================
                Call prvvsfLotListHold_Disp(ltypInvActptLotList)

                '@最新取得ﾎﾞﾀﾝ活性化
                cmdNowListHold.Enabled = True
                
                If vsfLotListHold.Enabled = True Then
                    If mblnSetFocus = False Then
                        '@一覧へｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(vsfLotListHold)
                    End If

                    '@ﾎﾞﾀﾝ使用可
                    cmdCopy.Enabled = True          'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ
                    
                    If vsfLotListHold.Row > 0 Then
                        cmdCancelHold.Enabled = True    '保留解除ﾎﾞﾀﾝ
                    End If
                Else
                    If mblnSetFocus = False Then
                        '@最新取得ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmdNowListHold)
                    End If

                    '@ﾎﾞﾀﾝ使用不可
                    cmdCancelHold.Enabled = False   '保留解除ﾎﾞﾀﾝ
                End If
            
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
            Else
                '@保管在庫一覧のｸﾘｱ
                Call prvvsfLotListHold_Init()

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                If mblnSetFocus = False Then
                    Call pubSetFocus(cmbDivisionHold)
                End If

                Exit Sub
            End If

            'NSYS 選択行が未指定の場合はヘッダ行を選択状態にする
            If vsfLotListHold.Row < 0 Then
                vsfLotListHold.Row = 0
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowListHold_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdHoldHold_Click
    '機　能：保留在庫-保留ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/14 (Thu) 09:02:06 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:30:36 T.Oide
    '備　考：
    Private Sub cmdHoldHold_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHoldHold.Click
        
        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

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

            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngHoldTab)
            
            '@起動区分ｾｯﾄ(保留起動)
            ptypHoldConnect.strLotHoldFlg = "0"
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListHold
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfHoldColNo)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN00F1.Instance = New frmxxEN00F1()
            
            '@子画面名称設定
            frmxxEN00F1.Instance.Text = CPstrSubFormEN00F1Hold
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00F1.Instance = Nothing
                Exit Sub
            End If
            
            '@保留画面起動
            frmxxEN00F1.Instance.ShowDialog(Me)
            frmxxEN00F1.Instance = Nothing

            '@最新取得処理
            Call cmdNowListHold_Click(cmdNowListHold,New EventArgs)
            
            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListHold, lstrKeyID, CMlngvsfHoldColLotID, cmdClose)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdHoldHold_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCancelhold_Click
    '機　能：保管在庫-保留解除ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 16:16:38 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:30:46 T.Oide
    '備　考：
    Private Sub cmdCancelhold_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelhold.Click
        
        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

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
            
            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngHoldTab)
            
            '@起動区分ｾｯﾄ(保留解除起動)
            ptypHoldConnect.strLotHoldFlg = "1"
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListHold
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfHoldColLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN00F1.Instance = New frmxxEN00F1()
            
            '@子画面名称設定
            frmxxEN00F1.Instance.Text = CPstrSubFormEN00F1Cancel
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00F1.Instance = Nothing
                Exit Sub
            End If
            
            '@保留解除画面起動
            frmxxEN00F1.Instance.ShowDialog(Me)
            frmxxEN00F1.Instance = Nothing

            '@最新取得処理
            Call cmdNowListHold_Click(cmdNowListHold,New EventArgs)

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListHold, lstrKeyID, CMlngvsfHoldColLotID, cmdClose)
            
            '@ﾌｫｰｶｽ戻り位置による処理
            If vsfLotListHold.Row < 1 Then
            '@ﾀｲﾄﾙの場合
                '@保留,保留解除ﾎﾞﾀﾝを非活性化
                cmdHoldHold.Enabled = False
                cmdCancelHold.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCancelhold_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWFhold_Click
    '機　能：保管在庫-払出ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 16:16:41 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:30:54 T.Oide
    '備　考：
    Private Sub cmdWFhold_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWFhold.Click
        
        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

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

            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngHoldTab)
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListHold
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfHoldColLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN00F2.Instance = New frmxxEN00F2()
            
            '@子画面名称設定
            frmxxEN00F2.Instance.Text = CPstrSubFormEN00F2
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00F2.Instance = Nothing
                Exit Sub
            End If
            
            '@払出画面起動
            frmxxEN00F2.Instance.ShowDialog(Me)
            frmxxEN00F2.Instance = Nothing

            '@最新取得処理
            Call cmdNowListHold_Click(cmdNowListHold,New EventArgs)

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListHold, lstrKeyID, CMlngvsfHoldColLotID, cmdClose)
            
            '@ﾌｫｰｶｽｾｯﾄ
            With vsfLotListHold
                '@選択行がﾀｲﾄﾙの場合
                If .Row = 0 Then
                    '@各ﾎﾞﾀﾝの非活性化
                    cmdHoldHold.Enabled = False             '保留
                    cmdCancelHold.Enabled = False           '保留解除
                    cmdWFHold.Enabled = False               '数量増減
                    cmdCommentHold.Enabled = False          'ﾛｯﾄｺﾒﾝﾄ
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWFhold_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentHold_Click
    '機　能：受入在庫-ｺﾒﾝﾄ表示ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/08 (Thu) 10:14:08 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:31:02 T.Oide
    '備　考：
    '　　　：2004/12/08 (Wed) 17:46:48 H.Wajima     不具合修正
    '　　　：2006/02/08 (Wed) 16:29:57 N.Kojima     編集ﾌﾗｸﾞをTrueで設定し、ﾛｯﾄｺﾒﾝﾄの登録も可能とする。(運用障害№539対応)
    '　　　：2012/01/24 (Tue) 13:31:02 T.Oide       REQ-1115で関数共通化
    Private Sub cmdCommentHold_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentHold.Click

        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngHoldTab)
            
            '@編集ﾌﾗｸﾞに編集不可を設定
            ptypHoldConnect.blnEditFlag = False
            
            '@子画面名称設定
            frmxxEN00F4.Instance.Text = CPstrSubFormEN00F4
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListHold
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfHoldColLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@払出画面起動
            frmxxEN00F4.Instance.ShowDialog(Me)
            frmxxEN00F4.Instance = Nothing

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListHold, lstrKeyID, CMlngvsfHoldColLotID, cmdClose)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommentHold_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdHoldWFInfo_Click
    '機　能：WF情報表示ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/05 (Mon) 10:54:46 N.Kojima
    '更新日：2012/01/24 (Tue) 13:31:55 T.Oide
    '備　考：
    Private Sub cmdHoldWFInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHoldWFInfo.Click

        Dim lstrKeyID           As String               'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow          As Integer              '現在行を格納
        Dim lblnAns             As Boolean              '汎用戻り値(boolean型)
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrClassDivision   As String               '処理区分格納用

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
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdHoldWFInfo_Click"
            
            '@処理区分格納(0L=ﾛｯﾄ指定)
            lstrClassDivision = CPstrCD0L
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
                
            With vsfLotListHold
                '@引継ぎ構造体に格納
                ptypCommonInfo.strCarrierId = .GetData(.Row, CMlngvsfHoldColCarrierID)           'ｷｬﾘｱID
                ptypCommonInfo.strLotID = .GetData(.Row, CMlngvsfHoldColLotID)                   'ﾛｯﾄID
                ptypCommonInfo.strFlowClass = .GetData(.Row, CMlngvsfHoldColFlowClass)           '種別
                ptypCommonInfo.strSlotSize = .GetData(.Row, CMlngvsfHoldColSlotSize)             'ｽﾛｯﾄｻｲｽﾞ
            
                '@ﾛｯﾄ情報詳細取得処理
                lblnAns = pubblnLotDetail_Sel(CMstrlot_detail__Ver, _
                                              pstrSBID, _
                                              lstrClassDivision, _
                                              ptypCommonInfo.strLotID, _
                                              ptypCommonInfo.strCarrierId, _
                                              mtypLotDetailInfo)
            
                '@Escﾎﾞﾀﾝを有効に
                Me.CancelButton = cmdclose

                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@引継ぎ構造体を初期化
                    ptypCommonInfo.strCarrierId = vbNullString      'ｷｬﾘｱID
                    ptypCommonInfo.strLotID = vbNullString          'ﾛｯﾄID
                    ptypCommonInfo.strFlowClass = vbNullString      '種別
                    ptypCommonInfo.strSlotSize = vbNullString       'ｽﾛｯﾄｻｲｽﾞ
                    ptypCommonInfo.strCfFlag = vbNullString         'CFﾌﾗｸﾞ
                    
                    Exit Sub
                Else
                    '@戻り値正常
                
                    '@CFﾌﾗｸﾞを格納
                    ptypCommonInfo.strCfFlag = mtypLotDetailInfo.strCfFlag
                
                    '@CF/TPALﾛｯﾄか(CF_FLAG=1or2)
                    If mtypLotDetailInfo.strCfFlag = CPstrOne Or _
                        mtypLotDetailInfo.strCfFlag = CPstrTwo Then
                    
                        '@CF(小判or大判)の判定
                        If mtypLotDetailInfo.strLpFlag <> CPstrOne Then
                            '@CF(小判)の場合
                        
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)

                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006Q)
                            '@"<TRM6QW>$$CFロット(小判)/TPALロットは、WF情報を参照することはできません。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@引継ぎ構造体を初期化
                            ptypCommonInfo.strCarrierId = vbNullString      'ｷｬﾘｱID
                            ptypCommonInfo.strLotID = vbNullString          'ﾛｯﾄID
                            ptypCommonInfo.strFlowClass = vbNullString      '種別
                            ptypCommonInfo.strSlotSize = vbNullString       'ｽﾛｯﾄｻｲｽﾞ
                            ptypCommonInfo.strCfFlag = vbNullString         'CFﾌﾗｸﾞ
                            
                            Exit Sub
                        End If
                    End If
                End If
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListHold
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfHoldColLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面(WF情報)をﾛｰﾄﾞ
            frmxxEN00FA.Instance = New frmxxEN00FA()
            
            '@子画面名称設定
            frmxxEN00FA.Instance.Text = CPstrSubFormEN00FA
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00FA.Instance = Nothing
                Exit Sub
            End If
            
            '@WF情報画面起動
            Call frmxxEN00FA.Instance.ShowDialog(Me)

            With ptypCommonInfo
                '@引継ぎ構造体を初期化
                .strCarrierId = vbNullString      'ｷｬﾘｱID
                .strLotID = vbNullString          'ﾛｯﾄID
                .strFlowClass = vbNullString      '種別
                .strSlotSize = vbNullString       'ｽﾛｯﾄｻｲｽﾞ
            End With

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListHold, lstrKeyID, CMlngvsfHoldColLotID, cmdClose)
            
            '@ﾌｫｰｶｽｾｯﾄ
            With vsfLotListHold
                '@選択行がﾀｲﾄﾙの場合
                If .Row = 0 Then
                    '@各ﾎﾞﾀﾝの非活性化
                    cmdHoldHold.Enabled = False             '保留
                    cmdCancelHold.Enabled = False           '保留解除
                    cmdWFHold.Enabled = False               '数量増減
                    cmdCommentHold.Enabled = False          'ﾛｯﾄｺﾒﾝﾄ
                    cmdHoldWFInfo.Enabled = False           'WF情報表示
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdHoldWFInfo_Click"        '処理名
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：vsfLotListHold_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 18:45:15 S.Deguchi
    '更新日：2004/07/07 (Wed) 18:45:15
    '備　考：
    Private Sub vsfLotListHold_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotListHold.AfterSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListHold.Rows.Count <= vsfLotListHold.Rows.Fixed Then
                Return
            End If

            AddHandler vsfLotListHold.BeforeRowColChange, AddressOf vsfLotListHold_BeforeRowColChange
            AddHandler vsfLotListHold.EnterCell, AddressOf vsfLotListHold_EnterCell

             '@ｿｰﾄ順を格納
            With mtypChgSortHoldTab

                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                Do While (.typChgSortList.Count -1 < .lngCnt)
                    .typChgSortList.Add(New ChgSortList)
                Loop
                Dim typChgSortListTmp As ChgSortList = New ChgSortList

                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納(昇順/降順)
                typChgSortListTmp.lngOrder = e.Order
                .typChgSortList(.lngCnt) = typChgSortListTmp

                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
            End With

            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
            Call pubVsfAfterSort(vsfLotListHold, CMlngVsfRowTitle,Nothing, Nothing, False, False, False, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListHold_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListHold_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 18:45:18 S.Deguchi
    '更新日：2004/07/07 (Wed) 18:45:18
    '備　考：
    Private Sub vsfLotListHold_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotListHold.BeforeSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListHold.Rows.Count <= vsfLotListHold.Rows.Fixed Then
                Return
            End If

            RemoveHandler vsfLotListHold.BeforeRowColChange, AddressOf vsfLotListHold_BeforeRowColChange
            RemoveHandler vsfLotListHold.EnterCell, AddressOf vsfLotListHold_EnterCell

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfBeforeSort(vsfLotListHold, CMlngVsfRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListHold_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListHold_EnterCell
    '機　能：ｷｬﾘｱ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 16:34:11 S.Deguchi
    '更新日：2006/02/08 (Wed) 16:40:44 N.Kojima
    '備　考：
    '　　　：2005/04/14 (Thu) 09:00:18 S.Deguchi    複数保留対応
    '　　　：2005/09/02 (Fri) 11:49:36 N.Kojima     WF情報表示ﾎﾞﾀﾝ追加に伴う対応。(不具合№3047)
    '　　　：2006/02/08 (Wed) 16:40:44 N.Kojima     ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝを無条件で有効にする。(運用障害№539対応)
    Private Sub vsfLotListHold_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotListHold.EnterCell

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListHold.Rows.Count <= vsfLotListHold.Rows.Fixed Then
                Return
            End If

            With vsfLotListHold
                '@ﾍｯﾀﾞｰ以外の場合
                If .Row > 0 Then
                    '@保留ﾌﾗｸﾞが立っている場合
                    If .GetData(.Row, CMlngvsfHoldColHoldFlag) = CMstrLotHoldFlgOn Then
                        '@保留ﾎﾞﾀﾝを活性化
                        cmdHoldHold.Enabled = True
                        '@保留解除ﾎﾞﾀﾝを活性化
                        cmdCancelHold.Enabled = True
                    Else
                        '@保留ﾎﾞﾀﾝを活性化
                        cmdHoldHold.Enabled = True
                        '@保留解除ﾎﾞﾀﾝを非活性化
                        cmdCancelHold.Enabled = False
                    End If
                    
                    '@ｺﾒﾝﾄが入力されている場合
                    If .GetData(.Row, CMlngvsfHoldColLotComments) <> vbNullString Then
                        '@ｺﾒﾝﾄ表示ﾎﾞﾀﾝを活性化
                        cmdCommentHold.Enabled = True
                    Else
                        '@ｺﾒﾝﾄ表示ﾎﾞﾀﾝを非活性化
                        cmdCommentHold.Enabled = False
                    End If
                    
                    '@WF情報表示ﾎﾞﾀﾝの制御
                    '@WF枚数が"0"ではない
                    If .GetData(.Row, CMlngvsfHoldColWfNum) <> 0 Then
                        '@WF情報表示ﾎﾞﾀﾝを有効に
                        cmdHoldWFInfo.Enabled = True
                    Else
                        '@WF情報表示ﾎﾞﾀﾝを無効に
                        cmdHoldWFInfo.Enabled = False
                    End If
                Else
                    '@WF情報表示ﾎﾞﾀﾝを無効に
                    cmdHoldWFInfo.Enabled = False
                End If
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListHold_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowListWF_Click
    '機　能：中間在庫-最新取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 11:47:47 S.Deguchi
    '更新日：2004/10/18 (Mon) 17:19:19 Y.Yamagishi
    '備　考：
    '　　　：2004/09/20 (Mon) 11:47:52 N.Kasai　    不具合№595　在庫一覧を全件取得(WF)を２分割対応
    '　　　：2004/10/18 (Mon) 17:19:19 Y.Yamagishi  0件表示のﾒｯｾｰｼﾞﾎﾞｯｸｽを表示しない(ｺﾒﾝﾄｱｳﾄ)不具合改善№1093
    '　　　：2005/02/04 (Fri) 12:31:52 S.Deguchi    不具合№471の修正
    Private Sub cmdNowListWF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowListWF.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypInvLotListReq       As InvLotListReq        '要求構造体

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
            
            '@ﾌﾗｸﾞを立てる
            mblnNowListWFFlag = True
            
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
            lstrFormName = Me.Name
            lstrEventName = "cmdNowList_Click"
                    
            '@ﾌﾗｸﾞを立てる
            mblnNowListWFFlag = True
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
                                 
            
            '@要求構造体に格納
            With ltypInvLotListReq
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                .strSbID = cmbSBID0.Value
                
                '@処理区分
                If txtLotID.Text = vbNullString Then
                    .strClassDivision = CPstrCD02
                Else
                    .strClassDivision = CPstrCD0L
                End If
                
                '@ｷｬﾘｱID(空欄)
                .strCarrierId = vbNullString
                
                '@ﾛｯﾄID
                .strLotID = txtLotID.Text
                
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstrinv_lotlist_Ver
            End With
            
            '@中間在庫Lot一覧取得
            lblnAns = pubblnInvLotList_Sel(ltypInvLotListReq, mtypInvLotList)
            
            '@結果判定
            If lblnAns = True Then
            
                '@一覧表示
                Call prvvsfLotListWF_Disp()

                '@最新取得ﾎﾞﾀﾝ活性化
                cmdNowListWF.Enabled = True
                
                '@SBIDの退避
                mstrTaihiSBID0 = cmbSBID0.Value
            
                '@退避領域へﾛｯﾄIDをｾｯﾄ
                mstrLotId = txtLotID.Text
                
                If vsfLotListWF.Enabled = True Then
                    '@一覧へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(vsfLotListWF)
                    
                    '@ﾎﾞﾀﾝの活性化
                    cmdCopy.Enabled = True          'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
                    
                    '@行が選択されている場合
                    If vsfLotListWF.Row > 0 Then
                        cmdCarrierM.Enabled = True  'ﾒﾝﾃﾅﾝｽﾎﾞﾀﾝ
                    Else
                        cmdCarrierM.Enabled = False 'ﾒﾝﾃﾅﾝｽﾎﾞﾀﾝ
                    End If
                    
                    '@ｷｬﾘｱ情報一覧の初期化
                    Call prvvsfCarrierInfo_Init()
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            
                '@ﾌﾗｸﾞを戻す
                mblnNowListWFFlag = False
                
                '@最新取得後,中間WF在庫の一覧でｾﾙを選択している場合
                With vsfLotListWF
                    If .Row > 0 Then
                        '@ｷｬﾘｱ詳細情報取得へ
                        Call cmdCarrierDetail_Click(cmdCarrierDetail,New EventArgs)
                    End If
                End With
            Else
                '@WF情報一覧の初期化
                Call prvvsfCarrierInfo_Init()

                '@中間在庫一覧のｸﾘｱ
                Call prvvsfLotListWF_Init()

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@ﾒﾝﾃﾅﾝｽﾎﾞﾀﾝ使用不可
                cmdCarrierM.Enabled = False
                
                '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ使用不可
                cmdCopy.Enabled = False
                
                '@ﾌﾗｸﾞを戻す
                mblnNowListWFFlag = False
                
                Exit Sub
            End If

            'NSYS 選択行が未指定の場合はヘッダ行を選択状態にする
            If vsfLotListWF.Row < 0 Then
                vsfLotListWF.Row = 0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowListWF_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierM_Click
    '機　能：ｷｬﾘｱﾒﾝﾃﾅﾝｽ画面起動
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/09 (Fri) 08:44:07 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:32:04 T.Oide
    '備　考：
    '　　　：2005/10/25 (Tue) 16:22:33 S.Deguchi    引継処理を修正
    '　　　：：2012/01/24 (Tue) 13:32:04 T.Oide     REQ-1115で関数共通化
    Private Sub cmdCarrierM_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierM.Click

        Dim lstrKeyID   As String   'ｷｬﾘｱIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

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
            
            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngWFTab)
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListWF
                '@ﾌｫｰｶｽを取得しているKEYを格納
                lstrKeyID = .GetData(.Row, CMlngvsfWFColCarrierID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
                
            '@引継ﾌﾗｸﾞの初期化
            pblnfrmxxCM00C0Kbn = True
            
            '@起動ﾌﾗｸﾞを初期化
            pblnFormLoad = False
            
            '@画面起動
            frmxxCM00C0.Instance = New frmxxCM00C0()
            
            '@判別
            If pblnFormLoad = False Then
                '@ｱﾝﾛｰﾄﾞ
                frmxxCM00C0.Instance = Nothing
                
                Exit Sub
            End If
            
            '@ｷｬﾘｱﾒﾝﾃﾅﾝｽ画面起動
            frmxxCM00C0.Instance.ShowDialog(Me)
            frmxxCM00C0.Instance = Nothing
            
            '@引継ﾌﾗｸﾞを戻す
            pblnfrmxxCM00C0Kbn = False
            
            '@起動ﾌﾗｸﾞを戻す
            pblnFormLoad = True
            
            '@最新取得処理
            Call cmdNowListWF_Click(cmdNowListWF,New EventArgs)

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListWF, lstrKeyID, CMlngvsfWFColCarrierID, cmdClose)
            
            '@ｷｬﾘｱ詳細を表示
            cmdCarrierDetail_Click(cmdCarrierDetail,New EventArgs)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierM_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMiddleWFInfo_Click
    '機　能：WF情報表示ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/05 (Mon) 10:56:12 N.Kojima
    '更新日：2012/01/24 (Tue) 13:32:41 T.Oide
    '備　考：
    '　　　：2005/11/08 (Tue) 13:57:23 N.Kojima     元ﾛｯﾄIDが複数ﾛｯﾄで構成されている場合の処理を追加。(運用障害№567)
    '　　　：2012/01/24 (Tue) 13:32:41 T.Oide       REQ-1115で関数共通化
    Private Sub cmdMiddleWFInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMiddleWFInfo.Click

        Dim lstrKeyID           As String               'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow          As Integer              '現在行を格納
        Dim lblnAns             As Boolean              '汎用戻り値(boolean型)
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrClassDivision   As String               '処理区分格納用

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
                
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdMiddleWFInfo_Click"
            
            '@処理区分格納(0L=ﾛｯﾄ指定)
            lstrClassDivision = CPstrCD0L
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
                
            With vsfLotListWF
                '@引継ぎ構造体に格納
                ptypCommonInfo.strCarrierId = .GetData(.Row, CMlngvsfWFColCarrierID)           'ｷｬﾘｱID

                '@"/"を探す
                If InStr(1, .GetData(.Row, CMlngvsfWFColLotID), CMstrSlash) <> 0 Then
                    '@"/"あり
                    ptypCommonInfo.strLotID = Strings.Left$(.GetData(.Row, CMlngvsfWFColLotID), 10)    '1ﾛｯﾄ目を格納
                    '@複数ﾛｯﾄで編成されていることを子画面で解るように値を設定
                    plngLotStatus = 2
                Else
                    '@"/"なし
                    ptypCommonInfo.strLotID = .GetData(.Row, CMlngvsfWFColLotID)               '元ﾛｯﾄID
                    '@単数ﾛｯﾄで編成されていることを子画面で解るように値を設定
                    plngLotStatus = 1
                End If
                
                ptypCommonInfo.strSlotSize = .GetData(.Row, CMlngvsfWFColSlotSize)             'ｽﾛｯﾄｻｲｽﾞ
                ptypCommonInfo.strSbID = cmbSBID0.Value                                                 '利用SBID
            
                '@ﾛｯﾄ情報詳細取得処理
                lblnAns = pubblnLotDetail_Sel(CMstrlot_detail__Ver, _
                                              cmbSBID0.Value, _
                                              lstrClassDivision, _
                                              ptypCommonInfo.strLotID, _
                                              ptypCommonInfo.strCarrierId, _
                                              mtypLotDetailInfo)
            
                '@Escﾎﾞﾀﾝを有効に
                Me.CancelButton = cmdClose

                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@引継ぎ構造体を初期化
                    ptypCommonInfo.strCarrierId = vbNullString        'ｷｬﾘｱID
                    ptypCommonInfo.strLotID = vbNullString            'ﾛｯﾄID
                    ptypCommonInfo.strFlowClass = vbNullString        '種別
                    ptypCommonInfo.strSlotSize = vbNullString         'ｽﾛｯﾄｻｲｽﾞ
                    ptypCommonInfo.strChipQuantity = vbNullString     'ﾁｯﾌﾟ数
                    ptypCommonInfo.strSbID = vbNullString             'SBID
                    ptypCommonInfo.strCfFlag = vbNullString           'CFﾌﾗｸﾞ
                    
                    '@元ﾛｯﾄ編成判定値を初期化する
                    plngLotStatus = 0
                    
                    Exit Sub
                Else
                    '@戻り値正常
                
                    '@引継ぎ構造体に格納
                    ptypCommonInfo.strFlowClass = mtypLotDetailInfo.strFlowClass    '種別
                    ptypCommonInfo.strCfFlag = mtypLotDetailInfo.strCfFlag          'CFﾌﾗｸﾞ
                    
                    '@CF/TPALﾛｯﾄか(CF_FLAG=1or2)
                    If mtypLotDetailInfo.strCfFlag = CPstrOne Or _
                       mtypLotDetailInfo.strCfFlag = CPstrTwo Then
                        '@CF(小判or大判)の判定
                        If mtypLotDetailInfo.strLpFlag <> CPstrOne Then
                        '@CF(小判)の場合
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)

                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006Q)
                            '@"<TRM6QW>$$CFロット(小判)/TPALロットは、WF情報を参照することはできません。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@引継ぎ構造体を初期化
                            ptypCommonInfo.strCarrierId = vbNullString        'ｷｬﾘｱID
                            ptypCommonInfo.strLotID = vbNullString            'ﾛｯﾄID
                            ptypCommonInfo.strFlowClass = vbNullString        '種別
                            ptypCommonInfo.strSlotSize = vbNullString         'ｽﾛｯﾄｻｲｽﾞ
                            ptypCommonInfo.strChipQuantity = vbNullString     'ﾁｯﾌﾟ数
                            ptypCommonInfo.strSbID = vbNullString             'SBID
                            ptypCommonInfo.strCfFlag = vbNullString           'CFﾌﾗｸﾞ
                            
                            '@元ﾛｯﾄ編成判定値を初期化する
                            plngLotStatus = 0
                            
                            Exit Sub
                        End If
                    End If
                End If
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListWF
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfWFColLotID)
                
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面(WF情報)をﾛｰﾄﾞ
            frmxxEN00FA.Instance = New frmxxEN00FA()
            
            '@子画面名称設定
            frmxxEN00FA.Instance.Text = CPstrSubFormEN00FA
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
            '@異常の場合は子画面終了
                frmxxEN00FA.Instance = Nothing
                
                Exit Sub
            End If
            
            '@WF情報画面起動
            Call frmxxEN00FA.Instance.ShowDialog(Me)

            With ptypCommonInfo
                '@引継ぎ構造体を初期化
                .strCarrierId = vbNullString        'ｷｬﾘｱID
                .strLotID = vbNullString            'ﾛｯﾄID
                .strFlowClass = vbNullString        '種別
                .strSlotSize = vbNullString         'ｽﾛｯﾄｻｲｽﾞ
                .strChipQuantity = vbNullString     'ﾁｯﾌﾟ数
                .strSbID = vbNullString             'SBID
                .strCfFlag = vbNullString           'CFﾌﾗｸﾞ
            End With
            
            '@元ﾛｯﾄ編成判定値を初期化する
            plngLotStatus = 0

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListWF, lstrKeyID, CMlngvsfWFColLotID, cmdClose)
            
            '@ﾌｫｰｶｽｾｯﾄ
            With vsfLotListWF
                '@選択行がﾀｲﾄﾙの場合
                If .Row = 0 Then
                    '@各ﾎﾞﾀﾝの非活性化
                    cmdCarrierM.Enabled = False             'ﾒﾝﾃﾅﾝｽ
                    cmdMiddleWFInfo.Enabled = False         'WF情報表示
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMiddleWFInfo_Click"      '処理名
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：cmdCarrierDetail_Click
    '機　能：ｷｬﾘｱ詳細参照ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:29:44 S.Deguchi
    '更新日：2004/09/20 (Mon) 13:10:46 N.Kasai
    '備　考：
    '　　　：2004/09/20 (Mon) 13:10:46 N.Kasai      ｷｬﾘｱ詳細ﾎﾞﾀﾝを非表示　不具合№499、595
    '　　　：復活の可能性がある為、ﾎﾞﾀﾝは残しています。
    Private Sub cmdCarrierDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierDetail.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypInvWaferList        As InvWaferList         '受信構造体
        Dim lstrSlotSize            As String               'ｽﾛｯﾄｻｲｽﾞ
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾄ

        Try
            
            '@中間WF在庫最新取得処理中ﾌﾗｸﾞが立っている場合は処理しない
            If mblnNowListWFFlag = True Then
                Exit Sub
            End If

            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
            lstrFormName = Me.Name
            lstrEventName = "cmdNowList_Click"

            With vsfLotListWF
                '@ﾍｯﾀﾞｰ以外の場合
                If .Row > 0 Then
                    '@退避領域と比較して異なる場合のみ取得
                    If .GetData(.Row, CMlngvsfWFColCarrierID) <> mstrCarrierID Then
                        '@WF情報が取得されていない場合
                        If .GetData(.Row, CMlngvsfWFColInfoFlag) = CMlngInfoFlagOff Then
                            '@ﾚｽﾎﾟﾝｽ取得開始
                            Call pubResponseStart(lstrFormName, lstrEventName)
                                                                                
                            '@WF情報一覧取得
                            lblnAns = pubblnInvWaferlist_Sel(CMstrinv_waferlistVer, _
                                                             .GetData(.Row, CMlngvsfWFColCarrierID), _
                                                             mstrTaihiSBID0, _
                                                             ltypInvWaferList)
                            '@結果判定
                            If lblnAns = True Then
                                '@ｽﾛｯﾄｻｲｽﾞ格納
                                lstrSlotSize = .GetData(.Row, CMlngvsfWFColSlotSize)
                                
                                '@WF一覧表示処理へ
                                Call prvvsfCarrierInfo_Disp(ltypInvWaferList, lstrSlotSize)
                            
                                '@情報を退避する
                                For llngCnt = 0 To .Rows.Count - 2
                                    '@取得したWF情報を退避領域へ
                                    If .GetData(.Row, CMlngvsfWFColCarrierID) = _
                                       mtypCaarierInfo(llngCnt).strCarrierId Then
                                        Dim mtypCaarierInfoTmp As CarrierInfo = mtypCaarierInfo(llngCnt)
                                        '@格納
                                        mtypCaarierInfoTmp.typInvWaferList = ltypInvWaferList
                                        mtypCaarierInfo(llngCnt) = mtypCaarierInfoTmp
                                        '@取得ﾌﾗｸﾞを立てる
                                        .SetData(.Row, CMlngvsfWFColInfoFlag, CMlngInfoFlagOn)
                                    End If
                                Next llngCnt
                            Else
                                '@WF情報一覧の初期化
                                Call prvvsfCarrierInfo_Init()

                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(lstrFormName, lstrEventName)
            
                                Exit Sub
                            End If

                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(lstrFormName, lstrEventName)
                        Else
                            '@WF情報が取得されている場合
                            
                            '@ｽﾛｯﾄｻｲｽﾞ格納
                            lstrSlotSize = .GetData(.Row, CMlngvsfWFColSlotSize)
                            
                            '@退避領域から情報を戻す
                            For llngCnt = 0 To .Rows.Count - 2
                                '@取得したWF情報を退避領域へ
                                If .GetData(.Row, CMlngvsfWFColCarrierID) = _
                                   mtypCaarierInfo(llngCnt).strCarrierId Then
                                    
                                    ltypInvWaferList = mtypCaarierInfo(llngCnt).typInvWaferList
                                End If
                            Next llngCnt
                            
                            '@WF一覧表示処理へ
                            Call prvvsfCarrierInfo_Disp(ltypInvWaferList, lstrSlotSize)
                        End If
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierDetail_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListSend_AfterUserResize
    '機　能：ｸﾞﾘｯﾄﾞ幅変更処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 10:27:59 N.Kasai
    '更新日：2004/10/15 (Fri) 10:27:59
    '備　考：
    Private Sub vsfLotListSend_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotListSend.AfterResizeColumn, vsfLotListSend.AfterResizeRow

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListSend.Rows.Count <= vsfLotListSend.Rows.Fixed Then
                Return
            End If

             '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSortSendTab.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListSend_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListSend_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾌｫｰｶｽ移動
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 10:29:58 N.Kasai
    '更新日：2004/10/15 (Fri) 10:29:58
    '備　考：
    Private Sub vsfLotListSend_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLotListSend.BeforeRowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListSend.Rows.Count <= vsfLotListSend.Rows.Fixed Then
                Return
            End If
             
             '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ﾛｯﾄID)
                mtypChgSortSendTab.strKey = vsfLotListSend.GetData(e.NewRange.r1, CMlngvsfSendColLotID)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListSend_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListSend_Click
    '機　能：編集許可の制御(ｷｰﾀﾞｳﾝ)
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2004/08/04 (Wed) 17:06:21 N.Kasai
    '更新日：2012/10/18 (Thu) 17:12:14 T.Oide
    '備　考：
    '　　　：2006/09/25 (Mon) 13:47:22 N.Kojima     量産ﾛｯﾄの送品先指定機能追加に伴い、処理修正。(案件№01452)
    '　　　：2006/10/05 (Thu) 14:28:20 N.Kojima     ①ﾃﾞﾌｫﾙﾄ送品先格納処理が不要処理だったので削除。
    '　　　：                                       ②送品先取得処理の条件を変更。(案件№01548)
    '　　　：2007/05/11 (Fri) 14:04:19 M.Miura      量産ﾛｯﾄは送品先変更不可にする(案件№1895)
    '　　　：2012/10/18 (Thu) 17:12:14 T.Oide       R9-05(EPPI送品対応)
    Private Sub vsfLotListSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotListSend.Click
        
        Dim lblnAns         As Boolean      '戻り値用
        Dim lstrPdID        As String       '機種退避用

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListSend.Rows.Count <= vsfLotListSend.Rows.Fixed Then
                Return
            End If

            'NSYS 選択行がない場合は処理を抜ける
            If vsfLotListSend.Row < vsfLotListSend.Rows.Fixed Then
                Return
            End If
                 
            'NSYS ヘッダー行選択時処理を抜ける
            If vsfLotListSend.MouseRow < vsfLotListSend.Rows.Fixed Then
                Return
            End If

            '@①起動SBが組立(2A0)、②「送品待ち」選択、③送品先列、④ﾁｪｯｸ済み
            '@①～④場合送品先を取得　※基板は操作不可。
        '@↓2018/07/23 (Mon) 16:15:02 Y.Yoneyama **************************************************
            If (pstrSBID = CPstrSBID2A0 Or pstrSBID = CPstrSBID3A0) And _
                optLotSendStatus0.Checked = True And _
                vsfLotListSend.Col = CMlngvsfSendColSendSBID And _
                vsfLotListSend.GetCellCheck(vsfLotListSend.Row, CMlngvsfSendColKb) = CheckEnum.Checked Then
        '@↑2018/07/23 (Mon) 16:15:02 Y.Yoneyama **************************************************
                
                '@機種を退避
                lstrPdID = vsfLotListSend.GetData(vsfLotListSend.Row, CMlngvsfSendColPDName)
            
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrPrvvsfSBIDSendListSet)
                
                '@送品先ﾘｽﾄ格納用構造体の初期化
                If mtypSendSBListAns.typSendSBList Is Nothing Then
                    mtypSendSBListAns.typSendSBList = New List(Of basxxCM0030.SendSBList)
                Else
                    mtypSendSBListAns.typSendSBList.Clear
                End If
                mtypSendSBListAns.lngSendSBListCnt = 0
                
                '@送品先ﾘｽﾄ取得
                lblnAns = pubblnMasSendSBList_Sel(CMstrmas_sendsblistVer, _
                                                  lstrPdID, _
                                                  mtypSendSBListAns)
                

                '@戻り値判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrPrvvsfSBIDSendListSet)
                    '@異常の場合終了
                    Exit Sub
                End If
                    
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvvsfSBIDSendListSet)
            End If
            
            '@編集処理へ
            Call prvvsfLotListSend_Edit(CMlngMouseClick, CMlngvsfMauseClickEvent)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListSend_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListSend_ComboCloseUp
    '機　能：ｺﾝﾎﾞ選択処理
    '引　数：Row：行
    '　　　：Col：列
    '　　　：FinishEdit：編集完了値
    '戻り値：なし
    '作成日：2004/08/04 (Wed) 17:03:16 N.Kasai
    '更新日：2006/09/15 (Fri) 15:36:13 N.Kojima
    '備　考：
    '　　　：2004/12/14 (Tue) 15:38:11 H.Wajima     運用系障害対応(ｶｳﾝﾀ間違い)
    '　　　：2006/09/15 (Fri) 15:36:13 N.Kojima     量産ﾛｯﾄの送品先設定機能追加に伴い、処理修正。(案件№01452)
    Private Sub vsfLotListSend_ComboCloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotListSend.ComboCloseUp

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListSend.Rows.Count <= vsfLotListSend.Rows.Fixed Then
                Return
            End If
            
            '@起動SBにより処理判定
            If pstrSBID = CPstrSBID2A0 Then
                '@組立(2A0)での起動時のみ処理有効
                
                '@ｺﾝﾎﾞｸﾛｰｽﾞｱｯﾌﾟﾌﾗｸﾞにTrueを設定
                mblnComboCloseUpFlag = True
                
                '@送品先列の場合
                If vsfLotListSend.Col = CMlngvsfSendColSendSBID Then
                    
                    '@送品先選択で編集完了
                    vsfLotListSend.FinishEditing()
                    
                    '@箱№の入力可否判定
                    With mtypSendSBListAns
                        For llngCnt = 0 To .lngSendSBListCnt -1
                            '@送品先が一致する項目を構造体から探す
                            If .typSendSBList(llngCnt).strSendSBName = _
                               vsfLotListSend.GetData(vsfLotListSend.Row, CMlngvsfSendColSendSBID) Then
            
                                '@一致した場合
                                vsfLotListSend.SetData(vsfLotListSend.Row, CMlngvsfSendColSBSystemFlag, _
                                    .typSendSBList(llngCnt).strSBSystemFlag)
            
                                Exit For
                            End If
                        Next llngCnt
                    End With
                End If
                
                vsfLotListSend.Col = CMlngvsfSendColBoxNo
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListSend_ComboCloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListSend_KeyDown
    '機　能：編集許可の制御(ｷｰﾀﾞｳﾝ)
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2004/08/04 (Wed) 17:10:02 N.Kasai
    '更新日：2004/08/04 (Wed) 17:10:02
    '備　考：
    Private Sub vsfLotListSend_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfLotListSend.KeyDown

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListSend.Rows.Count <= vsfLotListSend.Rows.Fixed Then
                Return
            End If

            'NSYS 選択行がない場合は処理を抜ける
            If vsfLotListSend.Row < vsfLotListSend.Rows.Fixed Then
                Return
            End If

            If e.KeyCode = Keys.F2 Then
                e.SuppressKeyPress = True
            End If

            '@prvvsfLotListSend_Edit処理へ
            Call prvvsfLotListSend_Edit(CMlngKeyDown, e.KeyCode)

            'NSYS Backｷｰ押下時
            If e.KeyCode = Keys.Back AndAlso (TypeOf vsfLotListSend.Editor Is TextBox)
                CType(vsfLotListSend.Editor, TextBox).Clear()
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListSend_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListSend_ValidateEdit
    '機　能：完成在庫-編集後処理
    '引　数：Row：ｶﾚﾝﾄ行
    '　　　：Col：ｶﾚﾝﾄ列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/25 (Thu) 21:34:04 H.Wajima
    '更新日：2007/06/07 (Thu) 13:23:31 N.Kasai
    '備　考：
    '　　　：2007/06/07 (Thu) 13:23:31 N.Kasai  何でｴﾗｰなのかわからんのでﾒｯｾｰｼﾞを表示する。
    Private Sub vsfLotListSend_ValidateEdit(ByVal sender As Object, ByVal e As ValidateEditEventArgs) Handles vsfLotListSend.ValidateEdit

        Dim llngCnt         As Integer

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListSend.Rows.Count <= vsfLotListSend.Rows.Fixed Then
                Return
            End If
            
            '@列の判定
            Select Case e.Col
                
                Case CMlngvsfSendColBoxNo
                    
                    '@箱№列の編集終了時
                    With vsfLotListSend

                        '@文字数が4文字以内か判定
                        If Len(.Editor.Text) > CMlngBoxNoMaxLen Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009G, CMlngBoxNoMaxLen)
                            '"<TRM9GW>$$箱№は最大%1桁です。$設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            e.Cancel = True
                            Dim tb As TextBox = .Editor
                            tb.Text = .GetData(e.Row, e.Col)
                            tb.SelectAll()
                        End If
                        
                        For llngCnt = 1 To Len(.Editor.Text)
                            '禁則文字処理
                            Select Case UCase$(Mid(.Editor.Text, llngCnt, 1))
                                Case "0" To "9", "A" To "Z"
                                '@数値(0～9),ｱﾙﾌｧﾍﾞｯﾄ(A～Z)の場合
                                
                                Case Else
                                '@上記以外は確定処理不可

                                    e.Cancel = True
                                    Dim tb As TextBox = .Editor
                                    tb.Text = .GetData(e.Row, e.Col)
                                    tb.SelectAll()
                                    Exit For
                            End Select
                        Next llngCnt
                        
                        If e.Cancel = False Then
                            .Editor.Text = UCase$(.Editor.Text)
                            'NSYS フォーカス移動時にエラーチェック
                            cmdSendRegist.CausesValidation = False
                            cmdLotExamInfo.CausesValidation = False
                            cmdSendOrderList.CausesValidation = False
                            cmdNextCommentSend.CausesValidation = False
                            cmdCommentSend.CausesValidation = False
                            cmdWFSend.CausesValidation = False
                            cmdCancelSend.CausesValidation = False
                            cmdHoldSend.CausesValidation = False
                            cmdSendWFInfo.CausesValidation = False
                            cmdCopy.CausesValidation = False
                            cmdClose.CausesValidation = False
                        End If
                    End With
            End Select
                       

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListSend_ValidateEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListWF_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 18:45:15 S.Deguchi
    '更新日：2004/10/15 (Fri) 10:12:43 N.Kasai
    '備　考：
    '　　　：2004/10/15 (Fri) 10:12:43 N.Kasai      ｿｰﾄ順変更格納追加
    Private Sub vsfLotListWF_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotListWF.AfterSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListWF.Rows.Count <= vsfLotListWF.Rows.Fixed Then
                Return
            End If

            AddHandler vsfLotListWF.BeforeRowColChange, AddressOf vsfLotListWF_BeforeRowColChange
            AddHandler vsfLotListWF.EnterCell, AddressOf vsfLotListWF_EnterCell
            AddHandler vsfLotListWF.RowColChange, AddressOf vsfLotListWF_RowColChange

            '@ｿｰﾄ順を格納
            With mtypChgSortWFTab
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                Do While (.typChgSortList.Count -1 < .lngCnt)
                    .typChgSortList.Add(New ChgSortList)
                Loop
                Dim typChgSortListTmp As ChgSortList = New ChgSortList
                
                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                
                '@並び替え方法を格納(昇順/降順)
                typChgSortListTmp.lngOrder = e.Order
                .typChgSortList(.lngCnt) = typChgSortListTmp

                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
            End With

            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
            Call pubVsfAfterSort(vsfLotListWF, CMlngVsfRowTitle,Nothing, Nothing, False, False, False, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListWF_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListWF_AfterUserResize
    '機　能：ｸﾞﾘｯﾄﾞ幅変更処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 10:11:32 N.Kasai
    '更新日：2004/10/15 (Fri) 10:11:32
    '備　考：
    Private Sub vsfLotListWF_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotListWF.AfterResizeColumn, vsfLotListWF.AfterResizeRow

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListWF.Rows.Count <= vsfLotListWF.Rows.Fixed Then
                Return
            End If
                
            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSortWFTab.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListWF_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListWF_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞﾌｫｰｶｽ移動
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 10:13:33 N.Kasai
    '更新日：2004/10/15 (Fri) 10:13:33
    '備　考：
    Private Sub vsfLotListWF_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLotListWF.BeforeRowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListWF.Rows.Count <= vsfLotListWF.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ｷｬﾘｱID)
                mtypChgSortWFTab.strKey = vsfLotListWF.GetData(e.NewRange.r1, CMlngvsfWFColCarrierID)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListWF_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListWF_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 18:45:18 S.Deguchi
    '更新日：2004/07/07 (Wed) 18:45:18
    '備　考：
    Private Sub vsfLotListWF_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotListWF.BeforeSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListWF.Rows.Count <= vsfLotListWF.Rows.Fixed Then
                Return
            End If

            RemoveHandler vsfLotListWF.BeforeRowColChange, AddressOf vsfLotListWF_BeforeRowColChange
            RemoveHandler vsfLotListWF.EnterCell, AddressOf vsfLotListWF_EnterCell
            RemoveHandler vsfLotListWF.RowColChange, AddressOf vsfLotListWF_RowColChange

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfBeforeSort(vsfLotListWF, CMlngVsfRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListWF_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListWF_Click
    '機　能：中間在庫一覧ｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/20 (Mon) 13:40:55 N.Kasai
    '更新日：2004/09/20 (Mon) 13:40:55
    '備　考：
    Private Sub vsfLotListWF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotListWF.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListWF.Rows.Count <= vsfLotListWF.Rows.Fixed Then
                Return
            End If
                 
            'NSYS ヘッダー行選択時処理を抜ける
            If vsfLotListWF.MouseRow < vsfLotListSend.Rows.Fixed Then
                Return
            End If

            With vsfLotListWF
                '@ﾍｯﾀﾞｰ以外の場合
                If .Row > 0 Then
                    '@詳細ﾎﾞﾀﾝｸﾘｯｸ処理
                    Call cmdCarrierDetail_Click(cmdCarrierDetail,New EventArgs)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListWF_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListWF_EnterCell
    '機　能：ｷｬﾘｱ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 10:07:30 S.Deguchi
    '更新日：2005/09/02 (Fri) 11:57:26 N.Kojima
    '備　考：
    '　　　：2005/09/02 (Fri) 11:57:26 N.Kojima     WF情報表示ﾎﾞﾀﾝ追加に伴う対応。(不具合№3047)
    Private Sub vsfLotListWF_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotListWF.EnterCell

        Try
            
            With vsfLotListWF
                '@ﾍｯﾀﾞｰ以外の場合
                If .Row > 0 Then
                    '@選択されているｾﾙのｷｬﾘｱが空欄ではない場合
                    If .GetData(.Row, CMlngvsfWFColCarrierID) <> vbNullString Then
                        '@退避領域とことなる場合にはｷｬﾘｱ情報一覧は初期化
                        If .GetData(.Row, CMlngvsfWFColCarrierID) <> mstrCarrierID Then

                            '@退避領域をｸﾘｱ
                            mstrCarrierID = vbNullString
                        End If
                        
                        '@ﾒﾝﾃﾅﾝｽﾎﾞﾀﾝを活性化
                        cmdCarrierM.Enabled = True
                        
                        '@ｷｬﾘｱ詳細ﾎﾞﾀﾝを活性化
                        cmdCarrierDetail.Enabled = True
                    Else
                        '@ﾒﾝﾃﾅﾝｽﾎﾞﾀﾝを非活性化
                        cmdCarrierM.Enabled = False
                        
                        '@ｷｬﾘｱ詳細ﾎﾞﾀﾝを非活性化
                        cmdCarrierDetail.Enabled = False
                    End If
                    
                    '@WF情報表示ﾎﾞﾀﾝの制御
                    '@WF枚数が"0"ではない
                    If .GetData(.Row, CMlngvsfWFColWfNum) <> 0 Then
                        '@WF情報表示ﾎﾞﾀﾝを有効に
                        cmdMiddleWFInfo.Enabled = True
                    Else
                        '@WF情報表示ﾎﾞﾀﾝを無効に
                        cmdMiddleWFInfo.Enabled = False
                    End If
                Else
                    '@WF情報表示ﾎﾞﾀﾝを無効に
                    cmdMiddleWFInfo.Enabled = False
                End If
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListWF_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListWF_RowColChange
    '機　能：ｸﾞﾘｯﾄﾞﾌｫｰｶｽ移動
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/25 (Mon) 15:03:23 S.Deguchi
    '更新日：2005/07/25 (Mon) 15:03:23
    '備　考：
    Private Sub vsfLotListWF_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotListWF.RowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListWF.Rows.Count <= vsfLotListWF.Rows.Fixed Then
                Return
            End If

            With vsfLotListWF
                '@ﾍｯﾀﾞｰ以外の場合
                If .Row > 0 Then
                    '@詳細ﾎﾞﾀﾝｸﾘｯｸ処理
                    Call cmdCarrierDetail_Click(cmdCarrierDetail,New EventArgs)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListWF_RowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optLotSendStatus_Click
    '機　能：完成在庫-送品待ち/送品済み選択処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2004/11/24 (Wed) 11:37:35 H.Wajima
    '更新日：2006/02/10 (Fri) 18:02:32 N.Kojima
    '備　考：
    '　　　：2006/02/10 (Fri) 18:02:32 N.Kojima     ①送品済み：ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝのCaptionを「ﾛｯﾄｺﾒﾝﾄ表示」に変更。
    '　　　：                                       ②送品待ち：ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝのCaptionを「ﾛｯﾄｺﾒﾝﾄ」に変更。   (運用障害№539対応)
    Private Sub optLotSendStatus_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optLotSendStatus0.CheckedChanged,optLotSendStatus1.CheckedChanged

        Dim llngAns         As Integer      '戻り値
        Dim lblnRet         As Integer      '戻り値

        Try

            'NSYS チェック状態判定
            If sender.Checked = False Then
                Exit Sub
            End If  

            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ変更ﾌﾗｸﾞの判定
            If mblnOptChangeFlag = True Then
                '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ変更ﾌﾗｸﾞの判定(PGによりValue値を変更した場合)
                '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ変更ﾌﾗｸﾞにTrueを設定し処理を抜ける
                mblnOptChangeFlag = False
                Exit Sub
            End If         

            '@編集中の場合は内容が初期化されるのでﾒｯｾｰｼﾞBOXを表示する
            If mblnInEditKbn = True Then
                '@送品待ち/送品済みの判定
                
                '@※ｵﾌﾟｼｮﾝﾎﾞﾀﾝが変わった後にﾁｪｯｸが走るので、通常とﾒｯｾｰｼﾞが逆であることに注意！！
                Select Case True
                    
                    '@送品待ちが選択された場合
                    Case optLotSendStatus0.Checked
                    
                        '@表示ﾒｯｾｰｼﾞ変換 "<TRM3QI>$$送品取消・帳票印刷選択中です。 内容を破棄してよろしいですか？"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003Q)
                    
                    '@送品済みが選択された場合
                    Case optLotSendStatus1.Checked
                    
                        '@表示ﾒｯｾｰｼﾞ変換 "<TRM3PI>$$送品設定中です。 内容を破棄してよろしいですか？"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003P)
                End Select
                
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                '@要求確認
                If llngAns = vbNo Then
                    
                    '@処理しない
                    If vsfLotListSend.Enabled = True Then
                        Call pubSetFocus(vsfLotListSend)
                    End If
                    
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの選択状態を元に戻す
                    Select Case True
                    
                        '@送品待ちが選択された場合
                        Case optLotSendStatus0.Checked
                        
                            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ変更ﾌﾗｸﾞにTrueを設定する
                            mblnOptChangeFlag = True
                            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝを送品済みに戻す
                            optLotSendStatus1.Checked = True
                            
                        '@送品済みが選択された場合
                        Case optLotSendStatus1.Checked
                        
                            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ変更ﾌﾗｸﾞにTrueを設定する
                            mblnOptChangeFlag = True
                            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝを送品待ちに戻す
                            optLotSendStatus0.Checked = True
                    End Select
                    
                    Exit Sub
                Else
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ変更ﾌﾗｸﾞにFalseを設定する
                    mblnOptChangeFlag = False
                    '@編集中ﾌﾗｸﾞの初期化
                    mblnInEditKbn = False
                End If
            End If
            
            Select Case True
                
                '@送品待ちが選択された場合
                Case optLotSendStatus0.Checked
                
                    '@日付を初期化して、ｶﾚﾝﾀﾞｰ無効
                    With calFromDate
                        .Value = vbNullString
                        .Enabled = False
                    End With
                    With calToDate
                        .Value = vbNullString
                        .Enabled = False
                    End With
                    
                    '@列幅変更ﾌﾗｸﾞ初期化
                    mtypChgSortSendTab.blnChgWidth = False
                    
                    '@ｺﾝﾄﾛｰﾙ初期化
                    Call prvCompTabControl_Init(False)
                    
                    '@ﾛｯﾄｺﾒﾝﾄのｷｬﾌﾟｼｮﾝを「ﾛｯﾄｺﾒﾝﾄ」に
                    cmdCommentSend.Text = CMstrCommentRegistButtonCaption
                    
                    '@送品ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝを送品に変更
                    cmdSendRegist.Text = CMstrSendButtonCaption
                    '@次SB連絡ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝを次SB連絡登録に変更
                    cmdNextCommentSend.Text = CMstrInvCommCaptionUpd
                    
                    '@検索条件が全て揃っているか判定
                    lblnRet = prvblnNowListSend_Chk(CMlngOptSendBefore)
                    '@戻り値の判定
                    If lblnRet = True Then
                        '@検索条件が揃っている時
                        '@最新情報取得へ
                        Call cmdNowListSend_Click(cmdNowListSend,New EventArgs)
                    Else
                        '@検索条件が揃っていない場合
                        '@機種にｾｯﾄﾌｫｰｶｽ
                        If cmbProductSend.Enabled = True Then
                            Call pubSetFocus(cmbProductSend)
                        End If
                    End If
                
                '@送品済みが選択された場合
                Case optLotSendStatus1.Checked
                
                    '@日付に当日日付を指定し、ｶﾚﾝﾀﾞｰ有効
                    With calFromDate
                        .Today
                        .Enabled = True
                    End With
                    With calToDate
                        .Today
                        .Enabled = True
                    End With
                    
                    '@列幅変更ﾌﾗｸﾞ初期化
                    mtypChgSortSendTab.blnChgWidth = False
                    
                    '@ｺﾝﾄﾛｰﾙ初期化
                    Call prvCompTabControl_Init(False)
                    
                    '@ﾛｯﾄｺﾒﾝﾄのｷｬﾌﾟｼｮﾝを「ﾛｯﾄｺﾒﾝﾄ表示」に
                    cmdCommentSend.Text = CMstrCommentDispButtonCaption
                    
                    '@送品ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝを送品取消に変更
                    cmdSendRegist.Text = CMstrCancelSendButtonCaption
                    '@次SB連絡ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝを次SB連絡表示に変更
                    cmdNextCommentSend.Text = CMstrInvCommCaptionDisp
            
                    '@検索条件が全て揃っているか判定
                    lblnRet = prvblnNowListSend_Chk(CMlngOptSendAfter)
                    '@戻り値の判定
                    If lblnRet = True Then
                        '@検索条件が揃っている時
                        '@最新情報取得へ
                        Call cmdNowListSend_Click(cmdNowListSend,New EventArgs)
                    Else
                        '@検索条件が揃っていない場合
                        '@機種にｾｯﾄﾌｫｰｶｽ
                        If cmbProductSend.Enabled = True Then
                            Call pubSetFocus(cmbProductSend)
                        End If
                    End If
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optLotSendStatus_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProductSend_Change
    '機　能：完成在庫-機種変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 10:57:09 S.Deguchi
    '更新日：2006/02/10 (Fri) 16:44:44 N.Kojima
    '備　考：
    '　　　：2004/11/25 (Thu) 09:24:55 H.Wajima     初期化処理をｻﾌﾞﾙｰﾁﾝ化
    '　　　：2004/12/07 (Tue) 09:50:39 H.Wajima     編集中ﾌﾗｸﾞの初期化を追加
    '　　　：2006/02/10 (Fri) 16:44:44 N.Kojima     ﾎﾞﾀﾝの無効化制御を追加。(運用障害№539対応)
    Private Sub cmbProductSend_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProductSend.Change

        Try
            
            '@初期化
            Call prvCompTabControl_Init(True)
            
            '@編集中ﾌﾗｸﾞの初期化
            mblnInEditKbn = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProductSend_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProductSend_CloseUp
    '機　能：完成在庫-機種CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 10:57:12 S.Deguchi
    '更新日：2004/10/01 (Fri) 14:06:40 Y.Yamagishi
    '備　考：
    '　　　：2004/10/01 (Fri) 14:06:40 Y.Yamagishi  0項目選択でﾌｫｰｶｽ移動しないように修正
    Private Sub cmbProductSend_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProductSend.CloseUp

        Try

            '@空欄 or 0項目以外の場合
            If cmbProductSend.Text <> vbNullString And _
                cmbProductSend.Text <> CMstrCmbAddedCommentNone Then
                
                '@Validate処理へ
                RemoveHandler cmbProductSend.Validating,AddressOf cmbProductSend_Validate
                Call cmbProductSend_Validate(cmbProductSend,New CancelEventArgs(True))
                AddHandler cmbProductSend.Validating,AddressOf cmbProductSend_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProductSend_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProductSend_Validate
    '機　能：完成在庫-機種Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 10:57:15 S.Deguchi
    '更新日：2004/06/28 (Mon) 10:57:15
    '備　考：
    Private Sub cmbProductSend_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbProductSend.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@選択された内容の判定
            If cmbProductSend.Text = vbNullString Or _
                cmbProductSend.Text = CMstrCmbAddedCommentNone Then
                '@空欄 or 0項目の場合
                
                '@閉じるにｾｯﾄﾌｫｰｶｽ
                If ActiveControl.Name = cmbProductSend.Name Then
                    Call pubSetFocus(cmdClose)
                End If

                Exit Sub
            Else
                '@空欄の場合
                If cmbDivisionSend.Text = vbNullString Then
                    '@種別Combo作成
                    Call prvcmbDivisionList_Disp(CMlngSendTab)
                End If
                
                '@種別へｾｯﾄﾌｫｰｶｽ
                If ActiveControl.Name = cmbProductSend.Name Then
                    Call pubSetFocus(cmbDivisionSend)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProductSend_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDivisionSend_Change
    '機　能：完成在庫-種別変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 16:23:18 S.Deguchi
    '更新日：2006/02/10 (Fri) 17:29:03 N.Kojima
    '備　考：
    '　　　：2004/10/15 (Fri) 10:26:53 N.Kasai      mtypChgSortSendTab追加
    '　　　：2004/12/07 (Tue) 09:49:38 H.Wajima     編集中ﾌﾗｸﾞの初期化を追加
    '　　　：2006/02/10 (Fri) 17:29:03 N.Kojima     ﾎﾞﾀﾝの無効化制御を追加。(運用障害№539対応)
    Private Sub cmbDivisionSend_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDivisionSend.Change

        Try

            '@初期化
            '@完成在庫一覧のｸﾘｱ
            Call prvvsfLotListSend_Init()
            
            '@Commandﾎﾞﾀﾝの初期化
            cmdSendWFInfo.Enabled = False       'WF情報表示
            cmdHoldSend.Enabled = False         '保留
            cmdCancelSend.Enabled = False       '保留解除
            cmdWFSend.Enabled = False           '数量増減
            cmdCommentSend.Enabled = False      'ﾛｯﾄｺﾒﾝﾄ(送品待ち)/ﾛｯﾄｺﾒﾝﾄ表示(送品済み)
            cmdNextCommentSend.Enabled = False  '次SB連絡登録
            cmdSendOrderList.Enabled = False    '送品伝票印刷
            cmdLotExamInfo.Enabled = False      'ﾛｯﾄ検定表印刷
            cmdSendRegist.Enabled = False       '送品
            cmdNowListSend.Enabled = False      '最新取得
            cmdCopy.Enabled = False             'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
                 
            '@ｶﾚﾝﾄ行検索キーを初期化
            mtypChgSortSendTab.strKey = vbNullString
            
            '@編集中ﾌﾗｸﾞの初期化
            mblnInEditKbn = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbDivisionSend_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDivisionSend_CloseUp
    '機　能：完成在庫-種別CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 16:23:27 S.Deguchi
    '更新日：2004/10/01 (Fri) 14:07:18 Y.Yamagishi
    '備　考：
    '　　　：2004/10/01 (Fri) 14:07:18 Y.Yamagishi  0項目選択でﾌｫｰｶｽ移動しないように修正
    Private Sub cmbDivisionSend_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDivisionSend.CloseUp

        Try

            '@空欄 or 0項目以外の場合
            If cmbDivisionSend.Text <> vbNullString And _
                cmbDivisionSend.Text <> CMstrCmbAddedCommentNone Then
                
                '@Validate処理へ
                RemoveHandler cmbDivisionSend.Validating,AddressOf cmbDivisionSend_Validate
                Call cmbDivisionSend_Validate(cmbDivisionSend,New CancelEventArgs(True))
                AddHandler cmbDivisionSend.Validating,AddressOf cmbDivisionSend_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbDivisionSend_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDivisionSend_Validate
    '機　能：完成在庫-種別Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 16:23:30 S.Deguchi
    '更新日：2004/06/28 (Mon) 16:23:30
    '備　考：
    Private Sub cmbDivisionSend_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbDivisionSend.Validating
        
        Dim lblnRet                     As Boolean              '戻り値

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            Select Case True
            
                '@送品待ちが選択されている場合
                Case optLotSendStatus0.Checked
                    
                    '@種別の選択状況による処理分岐
                    '@種別選択がされていない,「0 項目選択」の場合
                    If cmbDivisionSend.Text = vbNullString Or _
                       cmbDivisionSend.Text = CMstrCmbAddedCommentNone Then
                        
                        If ActiveControl.Name = cmbDivisionSend.Name Then 
                            If cmdNowListSend.Enabled = True Then
                                '@最新取得へﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(cmdNowListSend)
                            Else
                                '@閉じるにｾｯﾄﾌｫｰｶｽ
                                Call pubSetFocus(cmdClose)
                            End If
                        End If

                        Exit Sub
                    End If
                        
                    If ActiveControl.Name <> cmbDivisionSend.Name Then
                        mblnSetFocus = True
                    End If

                    '@最新情報取得処理へ
                    Call cmdNowListSend_Click(cmdNowListSend,New EventArgs)
                
                    mblnSetFocus = False

                '@送品済みが選択されている場合
                Case optLotSendStatus1.Checked
                        
                    '@検索条件が全て揃っているか判定
                    lblnRet = prvblnNowListSend_Chk(CMlngOptSendAfter)
                    
                    '@戻り値の判定
                    If lblnRet = True Then
                        If ActiveControl.Name <> cmbDivisionSend.Name Then
                            mblnSetFocus = True
                        End If

                        '@検索条件が揃っている時
                        '@最新情報取得へ
                        Call cmdNowListSend_Click(cmdNowListSend,New EventArgs)

                        mblnSetFocus = False
                    Else
                        '@検索条件が揃っていない場合
                        '@検索開始日にｾｯﾄﾌｫｰｶｽ
                        If ActiveControl.Name = cmbDivisionSend.Name Then 
                            If calFromDate.Enabled = True Then
                                Call pubSetFocus(calFromDate)
                            End If
                        End If
                    End If
                    
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbDivisionSend_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calFromDate_CalendarSelect
    '機　能：検索開始日付 ｶﾚﾝﾀﾞｰ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/30 (Tue) 21:47:06 H.Wajima
    '更新日：2004/11/30 (Tue) 21:47:06
    '備　考：
    Private Sub calFromDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calFromDate.CalendarSelect

        Try
            
            '@Validate処理へ
            RemoveHandler calFromDate.Validating,AddressOf calFromDate_Validate
            Call calFromDate_Validate(calFromDate,New CancelEventArgs(True))
            AddHandler calFromDate.Validating,AddressOf calFromDate_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calFromDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calFromDate_Validate
    '機　能：選択開始日付 Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2004/11/30 (Tue) 21:47:04 H.Wajima
    '更新日：2008/04/01 (Tue) 10:48:29 M.Koni
    '備　考：
    '      :検索期間を3ヶ月以内に制限する処理を追加。<案件No.02719>
    Private Sub calFromDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calFromDate.Validating
        
        Dim lblnRet                     As Boolean              '戻り値
        Dim lstrDateWork                As String               '日付演算値格納用

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@日付の有効性ﾁｪｯｸ
            '@日付が入力されている場合
            If calFromDate.Value <> CPstrNullDate Then
                
                '@日付が初期値以外の場合
                If pubblnYearRange_Chk(calFromDate.Value) = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ﾌｫｰｶｽを移さない
                    If Me.ActiveControl.Name = tabControl.Name Then
                        mblnTabSelectEnabled = False
                        sender.Focus()
                    Else
                        e.Cancel = True
                    End If
                    Exit Sub
                End If

                If IsDate(calToDate.Value) Then
                    '未来日時指定の排除処理
                    If Format$(CDate(calFromDate.Value), CPstrDateTimeYMD) > Format$(CDate(calToDate.Value), CPstrDateTimeYMD) Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                        '@"開始日が終了日より大きくなっています。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                        '@ﾌｫｰｶｽを移さない
                        If Me.ActiveControl.Name = tabControl.Name Then
                            mblnTabSelectEnabled = False
                            sender.Focus()
                        Else
                            e.Cancel = True
                        End If

                        Exit Sub
                    End If
                End If

                '期間日時制限処理
                ' → calFromDate.Value に，3ヶ月を加算して，calToDate.Value より未来なら警告する。
                lstrDateWork = Format$(DateAdd(CMstrM, 3, calFromDate.Value), CPstrDateTimeYMD)
                If lstrDateWork < Format$(CDate(calToDate.Value), CPstrDateTimeYMD) Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008W, CMstrDspMsgThreeMonth)
                    '@"<TRM8WW>$$期間指定について、開始～終了までの間は$3ヶ月以内で設定してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ﾌｫｰｶｽの移動を不許可
                    If Me.ActiveControl.Name = tabControl.Name Then
                        mblnTabSelectEnabled = False
                        sender.Focus()
                    Else
                        e.Cancel = True
                    End If
                    Exit Sub
                End If

                '@検索条件が全て揃っているか判定
                lblnRet = prvblnNowListSend_Chk(CMlngOptSendAfter)
                '@戻り値の判定
                If lblnRet = True Then
                    '@検索条件が揃っている時
                    If ActiveControl.Name <> calFromDate.Name Then
                       mblnSetFocus = True
                    End If

                    '@最新情報取得へ
                    Call cmdNowListSend_Click(cmdNowListSend,New EventArgs)

                    mblnSetFocus = False
                Else
                    '@検索条件が揃っていない場合
                    '@検索終了日にｾｯﾄﾌｫｰｶｽ
                    If ActiveControl.Name = calFromDate.Name Then 
                        If calToDate.Enabled = True Then
                            Call pubSetFocus(calToDate)
                        End If
                    End If
                End If
            Else
				'日付が入力されていない場合
				'@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                '@"正しい日付を入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@ﾌｫｰｶｽを移さない
                If Me.ActiveControl.Name = tabControl.Name Then
                    mblnTabSelectEnabled = False
                    sender.Focus()
                Else
                    e.Cancel = True
                End If
                Exit Sub
                
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calFromDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calToDate_CalendarSelect
    '機　能：検索終了日 ｶﾚﾝﾀﾞｰ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/01 (Wed) 09:55:39 H.Wajima
    '更新日：2004/12/01 (Wed) 09:55:39
    '備　考：
    Private Sub calToDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calToDate.CalendarSelect

        Try

            '@Validate処理へ
            RemoveHandler calToDate.Validating, AddressOf calToDate_Validate
            Call calToDate_Validate(calToDate,New CancelEventArgs(True))
            AddHandler calToDate.Validating, AddressOf calToDate_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calToDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calToDate_Validate
    '機　能：検索終了日 ｶﾚﾝﾀﾞｰValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/30 (Tue) 21:54:21 H.Wajima
    '更新日：2008/04/01 (Tue) 10:51:27 M.Koni
    '備　考：
    '      :検索期間を3ヶ月以内に制限する処理を追加。<案件No.02719>
    Private Sub calToDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calToDate.Validating
        
        Dim lblnRet                     As Boolean              '戻り値
        Dim lstrDateWork                As String               '日付演算値格納用

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@日付の有効性ﾁｪｯｸ
            '@日付が入力されている場合
            If calToDate.Value <> CPstrNullDate Then
                
                '@日付が初期値以外の場合
                If pubblnYearRange_Chk(calToDate.Value) = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                    Exit Sub
                End If

                If IsDate(calFromDate.Value) And IsDate(calToDate.Value) Then
                    '未来日時指定の排除処理
                    If Format$(CDate(calFromDate.Value), CPstrDateTimeYMD) > Format$(CDate(calToDate.Value), CPstrDateTimeYMD) Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                        '@"開始日が終了日より大きくなっています。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                        '@ﾌｫｰｶｽを移さない
                        If Me.ActiveControl.Name = tabControl.Name Then
                            mblnTabSelectEnabled = False
                            sender.Focus()
                        Else
                            e.Cancel = True
                        End If
                    
                        Exit Sub
                    End If
                End If

                '期間日時制限処理
                ' → calFromDate.Value に，3ヶ月を加算して，calToDate.Value より未来なら警告する。
                lstrDateWork = Format$(DateAdd(CMstrM, 3, calFromDate.Value), CPstrDateTimeYMD)

                If IsDate(calToDate.Value) AndAlso lstrDateWork < Format$(CDate(calToDate.Value), CPstrDateTimeYMD) Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008W, CMstrDspMsgThreeMonth)
                    '@"<TRM8WW>$$期間指定について、開始～終了までの間は$3ヶ月以内で設定してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ﾌｫｰｶｽの移動を不許可
                    If Me.ActiveControl.Name = tabControl.Name Then
                        mblnTabSelectEnabled = False
                        sender.Focus()
                    Else
                        e.Cancel = True
                    End If
                    Exit Sub
                End If

                '@検索条件が全て揃っているか判定
                lblnRet = prvblnNowListSend_Chk(CMlngOptSendAfter)
                '@戻り値の判定
                If lblnRet = True Then
                    '@検索条件が揃っている時
                    If ActiveControl.Name <> calToDate.Name Then
                       mblnSetFocus = True
                    End If

                    '@最新情報取得へ
                    Call cmdNowListSend_Click(cmdNowListSend,New EventArgs)

                    mblnSetFocus = False
                End If
            Else
				'日付が入力されていない場合
				'@表示ﾒｯｾｰｼﾞ変換
				pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
				'@"正しい日付を入力してください。"
				Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

				'@ﾌｫｰｶｽを移さない
				If Me.ActiveControl.Name = tabControl.Name Then
					mblnTabSelectEnabled = False
					sender.Focus()
				Else
					e.Cancel = True
				End If
				Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calToDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowListSend_Click
    '機　能：完成在庫-最新取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 15:20:32 S.Deguchi
    '更新日：2004/10/18 (Mon) 17:21:55 Y.Yamagishi
    '備　考：
    '　　　：2004/09/06 (Mon) 09:45:50 N.Kasai　    次SB連絡ﾎﾞﾀﾝ制御追加
    '　　　：2004/10/18 (Mon) 17:21:55 Y.Yamagishi  0件表示のﾒｯｾｰｼﾞﾎﾞｯｸｽを表示しない(ｺﾒﾝﾄｱｳﾄ)不具合改善№1093
    Private Sub cmdNowListSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowListSend.Click
        
        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypClassCompList       As ClassCompleteList    '要求格納構造体
        Dim llngStockListCnt        As Integer              '取得数
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngLoopCnt             As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrTemp                As Object               '一時取得
        Dim llngAns                 As Integer              '汎用戻り値

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
            
            '@編集中の場合は内容が初期化されるのでﾒｯｾｰｼﾞBOXを表示する
            If mblnInEditKbn = True Then
                '@送品待ち/送品済みの判定
                Select Case True
                
                    '@送品待ちが選択されている場合
                    Case optLotSendStatus0.Checked
                        
                        '@表示ﾒｯｾｰｼﾞ変換 "<TRM3PI>$$送品設定中です。 内容を破棄してよろしいですか？"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003P)
                    
                    '@送品済みが選択されている場合
                    Case optLotSendStatus1.Checked
                        
                        '@表示ﾒｯｾｰｼﾞ変換 "<TRM3QI>$$送品取消・帳票印刷選択中です。 内容を破棄してよろしいですか？"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003Q)
                End Select
                        
                '@ﾒｯｾｰｼﾞ表示
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                '@要求確認
                If llngAns = vbNo Then
                    If mblnSetFocus = False Then
                        '@処理しない
                        If vsfLotListSend.Enabled = True Then
                            Call pubSetFocus(vsfLotListSend)
                        End If
                    End If
                    Exit Sub
                Else
                    '@編集中ﾌﾗｸﾞの初期化
                    mblnInEditKbn = False
                End If
            End If
            
            '@空欄 or 0項目の場合
            If cmbProductSend.Text = vbNullString Or _
                cmbProductSend.Text = CMstrCmbAddedCommentNone Then

                If mblnSetFocus = False Then
                    Call pubSetFocus(cmbProductSend)
                End If

                Exit Sub
            End If
            
            '@空欄 or 0項目の場合
            If cmbDivisionSend.Text = vbNullString Or _
                cmbDivisionSend.Text = CMstrCmbAddedCommentNone Then
                
                If mblnSetFocus = False Then
                    '@ｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmbDivisionSend)
                End If

                Exit Sub
            End If
            
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
            lstrFormName = Me.Name
            lstrEventName = "cmdNowList_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)     
            
            'NSYS 選択行がある場合
            If vsfLotListSend.Row > 0 Then
                'NSYS 選択列をNo.列に移動
                vsfLotListSend.Col = CMlngvsfSendColNo
            End If

            '@要求格納構造体の初期化
            If ltypClassCompList.typFlowClassList Is Nothing Then
                ltypClassCompList.typFlowClassList = New List(Of FlowClassList)
            Else
                ltypClassCompList.typFlowClassList.Clear
            End If
            If ltypClassCompList.typPdList Is Nothing Then
                ltypClassCompList.typPdList = New List(Of PDList)
            Else
                ltypClassCompList.typPdList.Clear
            End If
            If mtypstocklotlist Is Nothing Then
                mtypstocklotlist = New List(Of StockLotList)
            Else
                mtypstocklotlist.Clear
            End If
            mlngStockListCnt = 0
            mblnAuthorityChkFlag = False

            '@送品済み/送品待ち判定
            Select Case True
            
                '@送品待ちの場合
                Case optLotSendStatus0.Checked
                
                    '@要求格納構造体へ格納
                    With ltypClassCompList
                        .strSbID = pstrSBID                                                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strClassDivison = CPstrCD04 & CPstrCD0H                                        'ClassDivision:040H
                        
                        .lngPdCnt = cmbProductSend.ValueCount                                           'PD_IDｶｳﾝﾄ数
                        '@機種区分構造体作成
                        Dim typPdListTmp As New PDList
                        lstrTemp = Split(cmbProductSend.Value, vbTab)
                        For llngLoopCnt = LBound(lstrTemp) To UBound(lstrTemp)
                            typPdListTmp.strPdId = lstrTemp(llngLoopCnt)                 '機種ID
                            .typPdList.Add(typPdListTmp)
                        Next llngLoopCnt
                        
                        .lngFlowClassCnt = cmbDivisionSend.ValueCount                                   'Classｶｳﾝﾄ数
                        '@機種区分構造体作成
                        Dim typFlowClassListTmp As New FlowClassList
                        lstrTemp = Split(cmbDivisionSend.Value, vbTab)
                        For llngLoopCnt = LBound(lstrTemp) To UBound(lstrTemp)
                            typFlowClassListTmp.strFlowClass = lstrTemp(llngLoopCnt)     '種別ID
                            .typFlowClassList.Add(typFlowClassListTmp)
                        Next llngLoopCnt
                        
                        .strInventoryFlag = CPstrInventory09                                            '完成
                        .strHoldFlag = vbNullString                                                     '(0：通常 1：保留ﾛｯﾄ 但し通常・保留両方の場合はNULL)
                    End With
                
                '@送品済みの場合
                Case optLotSendStatus1.Checked
                
                    '@要求格納構造体へ格納
                    With ltypClassCompList
                        .strSbID = pstrSBID                                                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strClassDivison = CPstrCD04 & CPstrCD0H & CPstrCD3M                            'ClassDivision:040H3M
                        
                        '@検索開始日付
                        Select Case True
                            
                            '@日付が____/__/__かNullの場合
                            Case calFromDate.Value = CPstrNullDate, calFromDate.Value = vbNullString
                                
                                .strRefStartDate = vbNullString
                                
                            '@日付が妥当でない場合
                            Case Not calFromDate.IsDate
                                
                                .strRefStartDate = vbNullString
                                
                            '@日付が有効範囲外の場合
                            Case Not pubblnYearRange_Chk(calFromDate.Value)
                                
                                .strRefStartDate = vbNullString
                                
                            '@上記以外の場合
                            Case Else
                                
                                .strRefStartDate = calFromDate.Value & CPstrSearchStartTime             '検索開始日付
                                
                        End Select
                        
                        '@検索終了日付
                        Select Case True
                            
                            '@日付が____/__/__かNullの場合
                            Case calToDate.Value = CPstrNullDate, calToDate.Value = vbNullString
                                
                                .strRefEndDate = vbNullString
                                
                            '@日付が妥当でない場合
                            Case Not calToDate.IsDate
                                
                                .strRefEndDate = vbNullString
                                
                            '@日付が有効範囲外の場合
                            Case Not pubblnYearRange_Chk(calToDate.Value)
                                
                                .strRefEndDate = vbNullString
                                
                            '@上記以外の場合
                            Case Else
                                
                                .strRefEndDate = calToDate.Value & CPstrSearchEndTime                   '検索開始日付
                                
                        End Select
                        
                        .lngPdCnt = cmbProductSend.ValueCount                                           'PD_IDｶｳﾝﾄ数
                        '@機種区分構造体作成
                        Dim typPdListTmp As New PDList
                        lstrTemp = Split(cmbProductSend.Value, vbTab)
                        For llngLoopCnt = LBound(lstrTemp) To UBound(lstrTemp)
                            typPdListTmp.strPdId = lstrTemp(llngLoopCnt)                 '機種ID
                            .typPdList.Add(typPdListTmp)
                        Next llngLoopCnt
                        
                        .lngFlowClassCnt = cmbDivisionSend.ValueCount                                   'Classｶｳﾝﾄ数
                        '@機種区分構造体作成
                        Dim typFlowClassListTmp As New FlowClassList
                        lstrTemp = Split(cmbDivisionSend.Value, vbTab)
                        For llngLoopCnt = LBound(lstrTemp) To UBound(lstrTemp)
                            typFlowClassListTmp.strFlowClass = lstrTemp(llngLoopCnt)     '種別ID
                            .typFlowClassList.Add(typFlowClassListTmp)
                        Next llngLoopCnt
                        
                        .strInventoryFlag = CPstrInventory09                                            '完成
                        .strHoldFlag = vbNullString                                                     '(0：通常 1：保留ﾛｯﾄ 但し通常・保留両方の場合はNULL)
                    End With
            End Select
            
            '@=======================
            '@ 完成在庫Lot一覧取得
            '@=======================
            lblnAns = pubblnInvCompLotList_Sel(CMstrinv_complotlistVer, _
                                               ltypClassCompList, _
                                               mtypstocklotlist, _
                                               llngStockListCnt)
            If lblnAns = True Then
            
                '@取得ﾃﾞｰﾀ数退避
                mlngStockListCnt = llngStockListCnt
                mblnAuthorityChkFlag = False
            
                '@送品済み/送品待ち判定
                Select Case True
                
                    '@送品待ちの場合
                    Case optLotSendStatus0.Checked
                        
                        '@=======================
                        '@ 完成在庫一覧(TFT基板)表示
                        '@=======================
                        Call prvvsfLotListSend_Disp(mtypstocklotlist, llngStockListCnt)
                        
                    '@送品済みの場合
                    Case optLotSendStatus1.Checked
                    
                        '@一覧表示
                        Call prvvsfLotListSend2_Disp(mtypstocklotlist, llngStockListCnt)
                        
                        '@送品ﾎﾞﾀﾝの使用可否判定
                        Call prvvsfSend2CmdStatus_Chk()
                End Select

                '@最新取得ﾎﾞﾀﾝ活性化
                cmdNowListSend.Enabled = True
                
                If vsfLotListSend.Enabled = True Then
                    If mblnSetFocus = False Then
                        '@一覧へｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(vsfLotListSend)
                    End If
                    
                    '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの活性化
                    cmdCopy.Enabled = True
                    
                Else
                    If mblnSetFocus = False Then
                        '@最新取得ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                        If cmdNowListSend.Enabled = True Then
                            Call pubSetFocus(cmdNowListSend)
                        End If
                    End If
                End If
            
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
                If lblLotCntSend.Text = CPstrLotCnt0 Then
        '            '@表示ﾒｯｾｰｼﾞ変換
        '            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0029, lblLotCntSend.Caption)
        '            '@publngMsgBoxInfo("メッセージコード：C_I29%0$$該当件数 ： 0 件")
        '            Call publngMsgBoxInfo(pstrDMsg, vbInformation, frmxxEN00F0.Caption, True, 16)
                    
                    '@完成在庫一覧のｸﾘｱ
                    Call prvvsfLotListSend_Init()

                    '@各ﾎﾞﾀﾝの非活性化
                    cmdHoldSend.Enabled = False             '保留
                    cmdCancelSend.Enabled = False           '保留解除
                    cmdWFSend.Enabled = False               '数量増減
                    cmdCommentSend.Enabled = False          'ﾛｯﾄｺﾒﾝﾄ
                    cmdSendRegist.Enabled = False           '送品
                    cmdNextCommentSend.Enabled = False      '次SB連絡
                End If
            Else
                '@完成在庫一覧のｸﾘｱ
                Call prvvsfLotListSend_Init()

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@各ﾎﾞﾀﾝの非活性化
                cmdHoldSend.Enabled = False             '保留
                cmdCancelSend.Enabled = False           '保留解除
                cmdWFSend.Enabled = False               '数量増減
                cmdCommentSend.Enabled = False          'ﾛｯﾄｺﾒﾝﾄ
                cmdSendRegist.Enabled = False           '送品
                cmdNextCommentSend.Enabled = False      '次SB連絡
                cmdCopy.Enabled = False                 'ｺﾋﾟｰ

                If mblnSetFocus = False Then
                    Call pubSetFocus(cmbProductSend)
                End If

                Exit Sub
            End If

            'NSYS 選択行が未指定の場合はヘッダ行を選択状態にする
            If vsfLotListSend.Row < 0 Then
                vsfLotListSend.Row = 0
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowListSend_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSendWFInfo_Click
    '機　能：WF情報表示ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/05 (Mon) 10:57:07 N.Kojima
    '更新日：2012/01/24 (Tue) 13:33:16 T.Oide
    '備　考：
    Private Sub cmdSendWFInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSendWFInfo.Click

        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

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
            
            With vsfLotListSend
                
                '@「送品待ち」が表示されている場合
                If optLotSendStatus0.Checked = True Then
                    '@引継ぎ構造体に格納
                    ptypCommonInfo.strCarrierId = .GetData(.Row, CMlngvsfSendColCarrierID)         'ｷｬﾘｱID
                    ptypCommonInfo.strLotID = .GetData(.Row, CMlngvsfSendColLotID)                 'ﾛｯﾄID
                    ptypCommonInfo.strFlowClass = .GetData(.Row, CMlngvsfSendColFlowClass)         '種別
                    ptypCommonInfo.strSlotSize = .GetData(.Row, CMlngvsfSendColSlotSize)           'ｽﾛｯﾄｻｲｽﾞ
            
                    '@ﾌｫｰｶｽ戻り位置を取得
                    '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                    lstrKeyID = .GetData(.Row, CMlngvsfSendColLotID)
                    '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                    llngTopRow = .Row
                Else
                    '@「送品済み」が表示されている場合
                    
                    '@引継ぎ構造体に格納
                    ptypCommonInfo.strCarrierId = .GetData(.Row, CMlngvsfSend2ColCarrierID)        'ｷｬﾘｱID
                    ptypCommonInfo.strLotID = .GetData(.Row, CMlngvsfSend2ColLotID)                'ﾛｯﾄID
                    ptypCommonInfo.strFlowClass = .GetData(.Row, CMlngvsfSend2ColFlowClass)        '種別
                    ptypCommonInfo.strSlotSize = .GetData(.Row, CMlngvsfSend2ColSlotSize)          'ｽﾛｯﾄｻｲｽﾞ
                    
                    '@ﾌｫｰｶｽ戻り位置を取得
                    '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                    lstrKeyID = .GetData(.Row, CMlngvsfSend2ColLotID)
                    '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                    llngTopRow = .Row
                End If
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面(WF情報)をﾛｰﾄﾞ
            frmxxEN00FA.Instance = New frmxxEN00FA()
            
            '@子画面名称設定
            frmxxEN00FA.Instance.Text = CPstrSubFormEN00FA
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00FA.Instance = Nothing
                Exit Sub
            End If
            
            '@WF情報画面起動
            Call frmxxEN00FA.Instance.ShowDialog(Me)
            
            With ptypCommonInfo
                '@引継ぎ構造体を初期化
                .strCarrierId = vbNullString      'ｷｬﾘｱID
                .strLotID = vbNullString          'ﾛｯﾄID
                .strFlowClass = vbNullString      '種別
                .strSlotSize = vbNullString       'ｽﾛｯﾄｻｲｽﾞ
            End With

            '@「送品待ち」が表示されている場合
            If optLotSendStatus0.Checked = True Then
                '@ﾌｫｰｶｽ戻り位置を設定
                Call pubGridFocus_Set(vsfLotListSend, lstrKeyID, CMlngvsfSendColLotID, cmdClose)
            Else
                '@「送品済み」が表示されている場合
            
                '@ﾌｫｰｶｽ戻り位置を設定
                Call pubGridFocus_Set(vsfLotListSend, lstrKeyID, CMlngvsfSend2ColLotID, cmdClose)
            End If
            
            '@ﾌｫｰｶｽｾｯﾄ
            With vsfLotListSend
                '@選択行がﾀｲﾄﾙの場合
                If .Row = 0 Then
                    '@各ﾎﾞﾀﾝの非活性化
                    cmdSendWFInfo.Enabled = False               'WF情報表示
                    cmdHoldSend.Enabled = False                 '保留
                    cmdCancelSend.Enabled = False               '保留解除
                    cmdWFSend.Enabled = False                   '数量増減
                    cmdCommentSend.Enabled = False              'ﾛｯﾄｺﾒﾝﾄ
                    cmdNextCommentSend.Enabled = False          '次SB連絡登録
                    cmdSendOrderList.Enabled = False            '送品伝票印刷
                    cmdLotExamInfo.Enabled = False              'ﾛｯﾄ検定表印刷
                    cmdSendRegist.Enabled = False               '送品
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSendWFInfo_Click"        '処理名
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：cmdHoldsend_Click
    '機　能：完成在庫-保留ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 16:16:35 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:33:26 T.Oide
    '備　考：
    '　　　：2004/11/10 (Wed) 09:48:49 N.Kasai      送品ﾁｪｯｸALLｸﾘ機能追加(№213)
    '　　　：2012/01/24 (Tue) 13:33:26 T.Oide       REQ-1115で関数共通化
    Private Sub cmdHoldsend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHoldsend.Click

        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納
        Dim llngAns     As Integer  '汎用戻り値

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
            
            '@編集中の場合は内容が初期化されるのでﾒｯｾｰｼﾞBOXを表示する
            If mblnInEditKbn = True Then
                '@表示ﾒｯｾｰｼﾞ変換 "<TRM3PI>$$送品設定中です。 内容を破棄してよろしいですか？"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003P)
                
                '@"送品設定中です。 内容を破棄してよろしいですか？"
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                '@要求確認
                If llngAns = vbNo Then
                '@処理しない
                    '@ｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(vsfLotListSend)
                    
                    Exit Sub
                Else
                    '@編集中ﾌﾗｸﾞの初期化
                    mblnInEditKbn = False
                    
                    '@送品ﾁｪｯｸALLｸﾘｱ処理
                    Call prvSendUnchecked_Proc()
                End If
            End If
            
            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngSendTab)
            
            '@起動区分ｾｯﾄ(保留起動)
            ptypHoldConnect.strLotHoldFlg = "0"
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListSend
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfSendColLotID)
                
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN00F1.Instance = New frmxxEN00F1()
            
            '@子画面名称設定
            frmxxEN00F1.Instance.Text = CPstrSubFormEN00F1Hold
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00F1.Instance = Nothing
                
                Exit Sub
            End If
            
            '@保留画面起動
            frmxxEN00F1.Instance.ShowDialog(Me)
            frmxxEN00F1.Instance = Nothing

            '@最新取得処理
            Call cmdNowListSend_Click(cmdNowListSend,New EventArgs)

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListSend, lstrKeyID, CMlngvsfSendColLotID, cmdClose)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdHoldsend_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCancelsend_Click
    '機　能：完成在庫-保留解除ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 16:16:38 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:34:00 T.Oide
    '備　考：
    '　　　：2004/11/10 (Wed) 09:48:10 N.Kasai      送品ﾁｪｯｸALLｸﾘｱ機能追加(№213)
    '　　　：2012/01/24 (Tue) 13:34:00 T.Oide       REQ-1115で関数共通化
    Private Sub cmdCancelsend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelsend.Click

        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納
        Dim llngAns     As Integer  '汎用戻り値

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
            
            '@編集中の場合は内容が初期化されるのでﾒｯｾｰｼﾞBOXを表示する
            If mblnInEditKbn = True Then
                '@表示ﾒｯｾｰｼﾞ変換 "<TRM3PI>$$送品設定中です。 内容を破棄してよろしいですか？"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003P)
                
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                '@要求確認
                If llngAns = vbNo Then
                '@処理しない
                    '@ｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(vsfLotListSend)
                    
                    Exit Sub
                Else
                    '@編集中ﾌﾗｸﾞの初期化
                    mblnInEditKbn = False
                    
                    '@送品ﾁｪｯｸALLｸﾘｱ処理
                    Call prvSendUnchecked_Proc()
                End If
            End If

            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngSendTab)
            
            '@起動区分ｾｯﾄ(保留解除起動)
            ptypHoldConnect.strLotHoldFlg = "1"
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListSend
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfSendColLotID)
                
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN00F1.Instance = New frmxxEN00F1()
            
            '@子画面名称設定
            frmxxEN00F1.Instance.Text = CPstrSubFormEN00F1Cancel
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00F1.Instance = Nothing
                Exit Sub
            End If
            
            '@保留解除画面起動
            frmxxEN00F1.Instance.ShowDialog(Me)
            frmxxEN00F1.Instance = Nothing

            '@最新取得処理
            Call cmdNowListSend_Click(cmdNowListSend,New EventArgs)

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListSend, lstrKeyID, CMlngvsfSendColLotID, cmdClose)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCancelsend_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWFsend_Click
    '機　能：完成在庫-払出ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 16:16:41 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:34:42 T.Oide
    '備　考：
    '　　　：2004/11/10 (Wed) 09:46:19 N.Kasai      送品ﾁｪｯｸALLｸﾘｱ機能追加(№213)
    '　　　：2012/01/24 (Tue) 13:34:42 T.Oide       REQ-1115で関数共通化
    Private Sub cmdWFsend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWFsend.Click

        Dim lstrKeyID       As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow      As Integer  '現在行を格納
        Dim llngAns         As Integer  '汎用戻り値
        Dim lstrFlowClass   As String   '流動種別

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
            
            '@ｸﾞﾘｯﾄﾞ選択行の流動種別格納
            lstrFlowClass = vsfLotListSend.GetData(vsfLotListSend.Row, CMlngvsfSendColFlowClass)
            
            '@PR、ES品の場合は伝票処理が必要の旨ﾒｯｾｰｼﾞを表示
            If lstrFlowClass = CPstrFlowClassPR Or _
               lstrFlowClass = CPstrFlowClassES Then
                
                '@ﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0115, CPstrClass3J)
                '@<TRM115W>$$PR/ES品を[%1]する場合、別途伝票の発行が必要です。
                '　　　　　$$生産管理部門と調整のうえ伝票の発行を行ってください｡
                llngAns = publngMsgBox(pstrDMsg, vbNo, Me.Text, True, 16)
                
                '@いいえの場合は処理を中止
                If llngAns = vbNo Then
                    Exit Sub
                End If
            End If
            
            '@編集中の場合は内容が初期化されるのでﾒｯｾｰｼﾞBOXを表示する
            If mblnInEditKbn = True Then
                '@表示ﾒｯｾｰｼﾞ変換 "<TRM3PI>$$送品設定中です。 内容を破棄してよろしいですか？"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003P)
                
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                '@要求確認
                If llngAns = vbNo Then
                '@処理しない
                    '@ｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(vsfLotListSend)
                    
                    Exit Sub
                Else
                    '@編集中ﾌﾗｸﾞの初期化
                    mblnInEditKbn = False
                    
                    '@送品ﾁｪｯｸALLｸﾘｱ処理
                    Call prvSendUnchecked_Proc()
                End If
            End If

            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngSendTab)
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListSend
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfSendColLotID)
                
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN00F2.Instance = New frmxxEN00F2()
            
            '@子画面名称設定
            frmxxEN00F2.Instance.Text = CPstrSubFormEN00F2
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00F2.Instance = Nothing
                Exit Sub
            End If
            
            '@払出画面起動
            frmxxEN00F2.Instance.ShowDialog(Me)
            frmxxEN00F2.Instance = Nothing

            '@最新取得処理
            Call cmdNowListSend_Click(cmdNowListSend,New EventArgs)

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListSend, lstrKeyID, CMlngvsfSendColLotID, cmdClose)
            
            '@ﾌｫｰｶｽｾｯﾄ
            With vsfLotListSend
                '@選択行がﾀｲﾄﾙの場合
                If .Row = 0 Then
                    '@各ﾎﾞﾀﾝの非活性化
                    cmdHoldSend.Enabled = False             '保留
                    cmdCancelSend.Enabled = False           '保留解除
                    cmdWFSend.Enabled = False               '数量増減
                    cmdCommentSend.Enabled = False          'ﾛｯﾄｺﾒﾝﾄ
                    cmdSendRegist.Enabled = False           '送品
                    cmdNextCommentSend.Enabled = False      '次SB連絡
                End If
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWFsend_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentSend_Click
    '機　能：受入在庫-ｺﾒﾝﾄ表示ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/08 (Thu) 10:14:08 S.Deguchi
    '更新日：2012/10/19 (Fri) 16:31:34 T.Oide
    '備　考：
    '　　　：2004/12/08 (Wed) 17:46:48 H.Wajima     不具合修正
    '　　　：2006/02/08 (Wed) 16:21:14 N.Kojima     送品待ち選択の場合は、編集ﾌﾗｸﾞをTrueで設定し、
    '　　　：                                       ﾛｯﾄｺﾒﾝﾄの登録も可能とする。                 (運用障害№539対応)
    '　　　：2012/01/24 (Tue) 13:35:40 T.Oide       REQ-1115で関数共通化
    '　　　：2012/10/19 (Fri) 16:31:34 T.Oide       R9-05(EPPI送品対応)
    Private Sub cmdCommentSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentSend.Click
        
        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngSendTab)
            
            '@編集ﾌﾗｸﾞに編集不可を設定
            If optLotSendStatus0.Checked = True Then
                '@送品待ちが選択されている場合は「編集可」
                ptypHoldConnect.blnEditFlag = True
            Else
                '@送品済みが選択されている場合は「編集不可」
                ptypHoldConnect.blnEditFlag = False
            End If
            
            '@子画面名称設定
            frmxxEN00F4.Instance.Text = CPstrSubFormEN00F4
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListSend
                
                '@送品待ち/送品済みの判定
                Select Case True
                
                    '@送品待ちの場合
                    Case optLotSendStatus0.Checked
                    
                        '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                        lstrKeyID = .GetData(.Row, CMlngvsfSendColLotID)
                        
                    '@送品済みの場合
                    Case optLotSendStatus1.Checked
                    
                        '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                        lstrKeyID = .GetData(.Row, CMlngvsfSend2ColLotID)
                End Select
                
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@ｺﾒﾝﾄ画面起動
            frmxxEN00F4.Instance.ShowDialog(Me)
            frmxxEN00F4.Instance = Nothing
            
            '@ﾛｯﾄｺﾒﾝﾄが更新されているか
            If pblnCommetsCommitFlag = True Then
                
                '@送品待ち/送品済みの判定
                Select Case True
                
                    '@送品待ちの場合
                    Case optLotSendStatus0.Checked
                    
                        With vsfLotListSend
                            '@引継ぎ構造体からｺﾒﾝﾄを取得する
                            .SetData(llngTopRow, CMlngvsfSendColLotComments, ptypHoldConnect.strCommnents)
                            
                            '@引継ぎ構造体から最終更新日時を取得する
                            .SetData(llngTopRow, CMlngvsfSendColLastUpdate, ptypHoldConnect.strLastUpdate)
                            
                            '@ｺﾒﾝﾄ入力有無の判定
                            If ptypHoldConnect.strCommnents <> vbNullString Then
                                '@ｺﾒﾝﾄ有無へ「あり」を表示
                                .SetData(llngTopRow, CMlngvsfSendColLotCommentDisp, CPstrAriFlg)
                            Else
                                '@ｺﾒﾝﾄ有無へ「なし」表示
                                .SetData(llngTopRow, CMlngvsfSendColLotCommentDisp, vbNullString)
                            End If
                        End With
                        
                    '@送品済みの場合
                    Case optLotSendStatus1.Checked
                    
                        With vsfLotListSend
                            '@引継ぎ構造体からｺﾒﾝﾄを取得する
                            .SetData(llngTopRow, CMlngvsfSend2ColLotComments, ptypHoldConnect.strCommnents)
                            
                            '@引継ぎ構造体から最終更新日時を取得する
                            .SetData(llngTopRow, CMlngvsfSend2ColLastUpdate, ptypHoldConnect.strLastUpdate)
                            
                            '@ｺﾒﾝﾄ入力有無の判定
                            If ptypHoldConnect.strCommnents <> vbNullString Then
                                '@ｺﾒﾝﾄ有無へ「あり」表示
                                .SetData(llngTopRow, CMlngvsfSend2ColLotCommentDisp, CPstrAriFlg)
                            Else
                                '@ｺﾒﾝﾄ有無へ「なし」表示
                                .SetData(llngTopRow, CMlngvsfSend2ColLotCommentDisp, vbNullString)
                            End If
                        End With
                End Select
                
                '@ﾛｯﾄｺﾒﾝﾄ更新ﾌﾗｸﾞを初期化
                pblnCommetsCommitFlag = False
                
                '@最新取得
                Call cmdNowListSend_Click(cmdNowListSend,New EventArgs)
            
            End If
            
            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListSend, lstrKeyID, CMlngvsfSendColLotID, cmdClose)
            
            Call pubSetFocus(vsfLotListSend)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommentSend_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNextCommentSend_Click
    '機　能：次SB連絡登録処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/05 (Thu) 15:18:27 N.Kasai
    '更新日：2012/10/19 (Fri) 16:30:15 T.Oide
    '備　考：ｺﾒﾝﾄの実登録はﾒｲﾝ画面の「送品」を行った時に行う。
    '　　　：次SB連絡の登録処理を変更
    '　　　：2004/10/21 (Thu) 10:59:39 Y.Yamagishi　次SB連絡有無へ表示なしの場合「なし」は表示しない
    '　　　：2004/11/29 (Mon) 10:23:48 H.Wajima     送品待ち/送品済み判定追加
    '　　　：2005/01/11 (Tue) 18:01:17 H.Wajima     次SB連絡画面をEN00F8に移動
    '　　　：2007/03/05 (Mon) 18:34:23 N.Kojima     "mtypstocklotlist"から"typSendSBID"ﾘｽﾄ削除に伴い、送品先の判定処理を変更。(案件№01549)
    '　　　：2012/01/24 (Tue) 13:36:25 T.Oide       REQ-1115で関数共通化
    '　　　：2012/10/19 (Fri) 16:30:15 T.Oide       R9-05(EPPI送品対応)
    Private Sub cmdNextCommentSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNextCommentSend.Click

        Dim lstrKeyID           As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow          As Integer  '現在行を格納
        Dim lblnSBOuterFlag     As Boolean  'SB千歳以外ﾌﾗｸﾞ

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngSendTab)
            
            '@ﾌﾗｸﾞ初期化
            lblnSBOuterFlag = False
            
            With vsfLotListSend
                '@SBｼｽﾃﾑﾌﾗｸﾞが「0:千歳以外」の場合
                If .GetData(.Row, CMlngvsfSendColSBSystemFlag) = CPstrSBSystemFlagOuterChitose Then
                    '@SB千歳以外ﾌﾗｸﾞにTrueを設定する
                    lblnSBOuterFlag = True
                End If
            End With

            '@外部送品ﾌﾗｸﾞ
            ptypHoldConnect.blnOuterSendFlag = lblnSBOuterFlag

            '@ﾀｲﾄﾙ判定ﾌﾗｸﾞ(次SB連絡)
            ptypHoldConnect.strTitleFlg = CPstrSubFormEN00F4Next
            
            '@ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝの判定
            Select Case cmdNextCommentSend.Text
                Case CMstrInvCommCaptionUpd
                '@ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝが次SB連絡登録の場合
                    ptypHoldConnect.blnEditFlag = True
                    
                Case CMstrInvCommCaptionDisp
                '@ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝが次SB連絡表示の場合
                    ptypHoldConnect.blnEditFlag = False
            End Select
           
            '@子画面名称設定
            frmxxEN00F8.Instance.Text = CPstrSubFormEN00F4Next
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListSend
                
                '@送品待ち/送品済みの判定
                Select Case True
                
                    '@送品待ちの場合
                    Case optLotSendStatus0.Checked
                    
                        '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                        lstrKeyID = .GetData(.Row, CMlngvsfSendColLotID)
                        
                    '@送品済みの場合
                    Case optLotSendStatus1.Checked
                    
                        '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                        lstrKeyID = .GetData(.Row, CMlngvsfSend2ColLotID)
                End Select
                
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@ｺﾒﾝﾄ画面起動
            frmxxEN00F8.Instance.ShowDialog(Me)
            frmxxEN00F8.Instance = Nothing
            
            '@ﾛｯﾄｺﾒﾝﾄが更新されているか
            If pblnCommetsCommitFlag = True Then

                '@送品待ち/送品済みの判定
                Select Case True
                
                    '@送品待ちの場合
                    Case optLotSendStatus0.Checked
                    
                        With vsfLotListSend
                            '@引継ぎ構造体から次SB連絡ｺﾒﾝﾄを取得する
                            .SetData(llngTopRow, CMlngvsfSendColComment, ptypHoldConnect.strNextCommnents)
                            
                            '@引継ぎ構造体から最終更新日時を取得する
                            .SetData(llngTopRow, CMlngvsfSendColLastUpdate, ptypHoldConnect.strLastUpdate)
                            
                            '@次SB連絡入力可否の判定
                            If ptypHoldConnect.strNextCommnents <> vbNullString Then
                                '@次SB連絡有無へ表示あり
                                .SetData(llngTopRow, CMlngvsfSendColCommentDisp, CPstrAriFlg)
                            Else
                                '@次SB連絡有無へ表示なし
                                .SetData(llngTopRow, CMlngvsfSendColCommentDisp, vbNullString)
                            End If
                        End With
                        
                    '@送品済みの場合
                    Case optLotSendStatus1.Checked
                    
                        With vsfLotListSend
                            '@引継ぎ構造体から次SB連絡ｺﾒﾝﾄを取得する
                            .SetData(llngTopRow, CMlngvsfSend2ColComment, ptypHoldConnect.strNextCommnents)
                            
                            '@引継ぎ構造体から最終更新日時を取得する
                            .SetData(llngTopRow, CMlngvsfSend2ColLastUpdate, ptypHoldConnect.strLastUpdate)
                            
                            '@次SB連絡入力可否の判定
                            If ptypHoldConnect.strNextCommnents <> vbNullString Then
                                '@次SB連絡有無へ表示あり
                                .SetData(llngTopRow, CMlngvsfSend2ColCommentDisp, CPstrAriFlg)
                            Else
                                '@次SB連絡有無へ表示なし
                                .SetData(llngTopRow, CMlngvsfSend2ColCommentDisp, vbNullString)
                            End If
                        End With
                End Select
            
                '@ﾛｯﾄｺﾒﾝﾄ更新ﾌﾗｸﾞを初期化
                pblnCommetsCommitFlag = False
                
                '@最新取得
                Call cmdNowListSend_Click(cmdNowListSend,New EventArgs)
                
            End If
            
            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListSend, lstrKeyID, CMlngvsfSendColLotID, cmdClose)
            
            Call pubSetFocus(vsfLotListSend)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNextCommentSend_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListSend_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 18:45:15 S.Deguchi
    '更新日：2004/07/07 (Wed) 18:45:15
    '備　考：
    Private Sub vsfLotListSend_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotListSend.AfterSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListSend.Rows.Count <= vsfLotListSend.Rows.Fixed Then
                Return
            End If

            AddHandler vsfLotListSend.BeforeRowColChange,AddressOf vsfLotListSend_BeforeRowColChange
            AddHandler vsfLotListSend.EnterCell,AddressOf vsfLotListSend_EnterCell

            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
            Call pubVsfAfterSort(vsfLotListSend, CMlngVsfRowTitle,Nothing, Nothing, False, False, False, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListSend_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListSend_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 18:45:18 S.Deguchi
    '更新日：2004/10/15 (Fri) 10:28:44 N.Kasai
    '備　考：
    '　　　：2004/10/15 (Fri) 10:28:44 N.Kasai      mtypChgSortSendTab追加
    Private Sub vsfLotListSend_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotListSend.BeforeSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListSend.Rows.Count <= vsfLotListSend.Rows.Fixed Then
                Return
            End If

            RemoveHandler vsfLotListSend.BeforeRowColChange,AddressOf vsfLotListSend_BeforeRowColChange
            RemoveHandler vsfLotListSend.EnterCell,AddressOf vsfLotListSend_EnterCell

            '@ｿｰﾄ順を格納
            With mtypChgSortSendTab
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                Do While (.typChgSortList.Count -1 <.lngCnt + 1)
                    .typChgSortList.Add(New ChgSortList)
                Loop
                Dim typChgSortListTmp As ChgSortList = New ChgSortList                

                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納(昇順/降順)
                typChgSortListTmp.lngOrder = e.Order
                .typChgSortList(.lngCnt) = typChgSortListTmp
                 
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
            End With
            
            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfBeforeSort(vsfLotListSend, CMlngVsfRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListSend_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListSend_EnterCell
    '機　能：ｷｬﾘｱ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 16:34:11 S.Deguchi
    '更新日：2006/02/03 (Fri) 13:02:28 N.Kojima
    '備　考：
    '　　　：2004/11/05 (Fri) 19:11:38 N.Kasai      ﾛｯﾄ状態が移載中の場合「払出」ﾎﾞﾀﾝ使用不可とする。
    '　　　：2004/11/25 (Thu) 18:00:03 H.Wajima     送品待ち/送品済み判定追加
    '　　　：2005/03/22 (Tue) 08:55:54 S.Deguchi    送品取消処理復活
    '　　　：2005/04/14 (Thu) 09:00:18 S.Deguchi    複数保留対応
    '　　　：2005/09/02 (Fri) 11:55:19 N.Kojima     WF情報表示ﾎﾞﾀﾝ追加に伴う対応。(不具合№3047)
    '　　　：2006/02/03 (Fri) 13:02:28 N.Kojima     ﾎﾞﾀﾝの有効無効制御を変更。※「送品待ち」「送品済み」でそれぞれ動きが異なります。(運用障害№539対応)
    '　　　：2006/02/16 (Thu) 15:06:13 N.Kojima     ｺﾒﾝﾄ「あり/なし」により、ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝを制御する。(不具合№3430対応)
    Private Sub vsfLotListSend_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotListSend.EnterCell
        
        Dim lblnRet             As Boolean      '戻り値

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListSend.Rows.Count <= vsfLotListSend.Rows.Fixed Then
                Return
            End If
            
            '@送品待ち/送品済みの判定
            Select Case True
                
                '@送品待ちの場合
                Case optLotSendStatus0.Checked
                    
                    With vsfLotListSend
                        '@ﾍｯﾀﾞｰ以外の場合
                        If .Row > 0 Then
                            '@保留ﾌﾗｸﾞが立っている場合
                            If .GetData(.Row, CMlngvsfSendColHoldFlag) = CMstrLotHoldFlgOn Then
                                '@保留ﾎﾞﾀﾝを活性化
                                cmdHoldSend.Enabled = True
                                
                                '@保留解除ﾎﾞﾀﾝを活性化
                                cmdCancelSend.Enabled = True
                            Else
                                '@保留ﾎﾞﾀﾝを活性化
                                cmdHoldSend.Enabled = True
                                
                                '@保留解除ﾎﾞﾀﾝを非活性化
                                cmdCancelSend.Enabled = False
                            End If
                                                
                            '@無条件でﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝを活性化
                            cmdCommentSend.Enabled = True
                            
                            '@送品ﾎﾞﾀﾝ有効無効ﾁｪｯｸ
                            lblnRet = prvblnLotSend_Chk
                            '@戻り値の判定
                            If lblnRet = True Then
                                '@送品可の場合
                                '@送品ﾎﾞﾀﾝ活性化
                                cmdSendRegist.Enabled = True
                            Else
                                '@送品不可の場合
                                '@送品ﾎﾞﾀﾝ非活性化
                                cmdSendRegist.Enabled = False
                            End If
                            
                            '@移載ﾛｯﾄの場合(「移」文字列で判定)
                            If InStr(1, .GetData(.Row, CMlngvsfSendColKb), CMstrIsai) = 0 Then
                                '@数量払出ﾎﾞﾀﾝを活性化
                                cmdWFSend.Enabled = True
                            Else
                                '@数量払出ﾎﾞﾀﾝを非活性化
                                cmdWFSend.Enabled = False
                            End If
                            
                            '@次SB連絡登録ﾎﾞﾀﾝ有効
                            cmdNextCommentSend.Enabled = True
                            
                            '@ｺﾝﾎﾞｸﾛｰｽﾞｱｯﾌﾟﾌﾗｸﾞの判定
                            If mblnComboCloseUpFlag = True Then
                                '@ｺﾝﾎﾞのCloseUpが実行された場合
                                
                                '@ﾌﾗｸﾞにFalseを設定する
                                mblnComboCloseUpFlag = False
                                
                                '@ﾕｰｻﾞによる列幅変更されていない場合
                                If mtypChgSortPutTab.blnChgWidth = False Then
                                    '@送品先の列幅を自動設定
                                    With vsfLotListSend
                                        '.AutoSizeMode = flexAutoSizeColWidth
                                        .AutoSizeCol(CMlngvsfSendColSendSBID, 6)
                                    End With
                                End If
                            End If
                        Else
                            '@次SB連絡登録ﾎﾞﾀﾝ無効
                            cmdNextCommentSend.Enabled = False
                        End If
                    End With
                    
                '@送品済みの場合
                Case optLotSendStatus1.Checked
                    
                    With vsfLotListSend
                        '@ﾍｯﾀﾞｰ以外の場合
                        If .Row > 0 Then
                            
                            '@保留ﾎﾞﾀﾝを非活性化
                            cmdHoldSend.Enabled = False
                            '@保留解除ﾎﾞﾀﾝを非活性化
                            cmdCancelSend.Enabled = False
                            '@数量払出ﾎﾞﾀﾝを非活性化
                            cmdWFSend.Enabled = False
                            
                            '@ｺﾒﾝﾄが入力されている場合
                            If .GetData(.Row, CMlngvsfSend2ColLotComments) <> vbNullString Then
                                '@ｺﾒﾝﾄ表示ﾎﾞﾀﾝを活性化
                                cmdCommentSend.Enabled = True
                            Else
                                '@ｺﾒﾝﾄ表示ﾎﾞﾀﾝを非活性化
                                cmdCommentSend.Enabled = False
                            End If
                                                
                            '@次SB連絡が入力されている場合
                            If .GetData(.Row, CMlngvsfSend2ColCommentDisp) <> vbNullString Then
                                '@次SB連絡登録ﾎﾞﾀﾝ有効
                                cmdNextCommentSend.Enabled = True
                            Else
                                '@次SB連絡登録ﾎﾞﾀﾝ無効
                                cmdNextCommentSend.Enabled = False
                            End If
                        Else
                            '@次SB連絡登録ﾎﾞﾀﾝ無効
                            cmdNextCommentSend.Enabled = False
                        End If
                   End With
                    
            End Select
            
            '@WF情報表示ﾎﾞﾀﾝの制御
            With vsfLotListSend
                
                '@ﾍｯﾀﾞｰ以外の場合
                If .Row > 0 Then
                
                    '@「送品待ち」が選択されているか
                    If optLotSendStatus0.Checked = True Then
                    
                        '@WF枚数が"0"ではない
                        If .GetData(.Row, CMlngvsfSendColWfNum) <> 0 Then
                            '@WF情報表示ﾎﾞﾀﾝを有効に
                            cmdSendWFInfo.Enabled = True
                        Else
                            '@WF情報表示ﾎﾞﾀﾝを無効に
                            cmdSendWFInfo.Enabled = False
                        End If
                    Else
                        '@「送品済み」が選択されている場合
                                        
                        '@WF情報表示ﾎﾞﾀﾝを無効に
                        cmdSendWFInfo.Enabled = False
                    End If
                Else
                    '@WF情報表示ﾎﾞﾀﾝを無効に
                    cmdSendWFInfo.Enabled = False
                End If
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListSend_EnterCell"
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
    '作成日：2004/06/25 (Fri) 12:22:31 S.Deguchi
    '更新日：2004/06/25 (Fri) 12:22:31
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
            Call publngEnd_Proc(CPstrKeyEN00F0, ltypCommonInfo)

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

    '関数名：cmdCopy_Click
    '機　能：ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 12:26:56 S.Deguchi
    '更新日：2004/10/21 (Thu) 14:11:49 Y.Yamagishi
    '備　考：：EXCELに貼り付ける際に、ｾﾙの先頭の文字列が、「－」、「＋」の場合は、自動計算されるので、罫線文字におきかえる
    '　　　：2004/10/21 (Thu) 14:11:49 Y.Yamagishi  1行の最後はCR+LFが入っているのでTABｺｰﾄﾞは不要(不具合改善№146)
    '　　　：2004/12/22 (Wed) 14:35:16 S.Deguchi    完成在庫(cf)Tabの制御を追加
    Private Sub cmdCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCopy.Click

        Dim llngRowCnt      As Integer      '行ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngColCnt      As Integer      '列ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrRET         As String       'ｺﾋﾟｰ文字列
        Dim lstrWk          As String       '文字列編集
        Dim lctlvsfName     As C1FlexGrid   'ｸﾞﾘｯﾄﾞ
        Dim llngLastCol     As Integer      '最終列

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@初期化
            lctlvsfName = Nothing
            
            '@Clipboardの内容を削除
            Clipboard.Clear
            
            '@開いているTabによる処理分岐
            Select Case tabControl.SelectedTab.Name
                
                '@受入在庫
                Case Tab0.Name
                    
                    lctlvsfName = vsfLotListPut
                    llngLastCol = CMlngvsfPutColInvCommentDisp
                        
                '@保留在庫
                Case Tab1.Name
                    
                    lctlvsfName = vsfLotListHold
                    llngLastCol = CMlngvsfHoldColLotCommentButton
                        
                '@中間在庫
                Case Tab2.Name
                    
                    lctlvsfName = vsfLotListWF
                    llngLastCol = CMlngvsfWFColSlotSize
                        
                '@完成在庫
                Case Tab3.Name
                    
                    lctlvsfName = vsfLotListSend
                    llngLastCol = CMlngvsfSendColCommentDisp
                    
                '@完成在庫(CF)
                Case Tab4.Name
                    
                    lctlvsfName = vsfLotListCFEnd
                    llngLastCol = CMlngvsfCFEndColLotCommentDisp
            End Select
                
            With lctlvsfName
                '@一覧をｺﾋﾟｰする
                For llngRowCnt = 0 To .Rows.Count - 1
                    For llngColCnt = 0 To .Cols.Count - 1
                        '@列が非表示でない場合
                        If .Cols(llngColCnt).Visible Then
                            
                            '@文字列編集変数に値をｾｯﾄ
                            lstrWk = .GetDataDisplay(llngRowCnt, llngColCnt)
                                
                            '@先頭の文字列が「-」「+」の場合は罫線文字に置き換える
                            If Mid$(lstrWk, 1, 1) = CPstrMinus Then
                                Mid$(lstrWk, 1, 1) = CPstrMinusWide
                            End If
                            If Mid$(lstrWk, 1, 1) = CPstrPlus Then
                                Mid$(lstrWk, 1, 1) = CPstrPlusWide
                            End If
                                
                            '@最終列の場合Tabいらない
                            If llngColCnt = llngLastCol Then
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

    '関数名：tabControl_Click
    '機　能：ﾀﾌﾞｸﾘｯｸ時処理
    '引　数：PreviousTab：使用しない
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 10:32:50 S.Deguchi
    '更新日：2004/08/31 (Tue) 17:24:16 N.Kasai
    '備　考：
    '　　　：2004/08/31 (Tue) 17:24:16 N.Kasai　    中間在庫初回区分判定を追加
    '　　　：2004/12/06 (Mon) 09:52:21 S.Deguchi    CF完成在庫Tabを追加
    Private Sub tabControl_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tabControl.SelectedIndexChanged

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@[ﾌﾟﾛｼｰｼﾞｬ]の引数ｴﾗｰ回避制御
            Me.Show
            
            '@選択ﾀﾌﾞ別処理
            Select Case tabControl.SelectedTab.Name
            
                '@受入在庫
                Case Tab0.Name
                
                    If vsfLotListPut.Enabled = True Then
                        '@一覧にｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(vsfLotListPut)
                        
                        '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの活性化
                        cmdCopy.Enabled = True
                    Else
                        '@機種ｺﾝﾎﾞにｾｯﾄﾌｫｰｶｽ
                        cmbProductPut.Enabled = True
                        Call pubSetFocus(cmbProductPut)
                    
                        '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの非活性化
                        cmdCopy.Enabled = False
                    End If
                    
                '@保留在庫
                Case Tab1.Name
                
                    If vsfLotListHold.Enabled = True Then
                        '@一覧にｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(vsfLotListHold)
                        
                        '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの活性化
                        cmdCopy.Enabled = True
                    Else
                        '@機種ｺﾝﾎﾞにｾｯﾄﾌｫｰｶｽ
                        cmbDivisionHold.Enabled = True
                        Call pubSetFocus(cmbDivisionHold)
                    
                        '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの非活性化
                        cmdCopy.Enabled = False
                    End If
                    
                '@中間在庫
                Case Tab2.Name
                    
                    '@初回のみ値を取得する。(以降は最新ﾎﾞﾀﾝにて取得)
                    If mblnSyokaiKbn = True Then
                        '@利用SB表示はﾌｫｰﾑﾛｰﾄﾞで行う
                        '@一覧最新取得ﾎﾞﾀﾝ処理へ
                        Call cmdNowListWF_Click(cmdNowListWF,New EventArgs)
                        
                        mblnSyokaiKbn = False
                    End If
                    
                '@完成在庫
                Case Tab3.Name
                
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ変更ﾌﾗｸﾞにFalseを設定する
                    mblnOptChangeFlag = False
                    
                    '@列幅変更ﾌﾗｸﾞにFalse(未変更)を設定する
                    mtypChgSortSendTab.blnChgWidth = False
                    
                    If vsfLotListSend.Enabled = True Then
                        '@一覧にｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(vsfLotListSend)
                    
                        '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの活性化
                        cmdCopy.Enabled = True
                    Else
                        '@機種ｺﾝﾎﾞにｾｯﾄﾌｫｰｶｽ
                        cmbProductSend.Enabled = True
                        Call pubSetFocus(cmbProductSend)
                    
                        '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの非活性化
                        cmdCopy.Enabled = False
                    End If
                    
                '@CF完成在庫
                Case Tab4.Name
                
                    If vsfLotListCFEnd.Enabled = True Then
                        '@一覧にｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(vsfLotListCFEnd)
                        
                        '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの活性化
                        cmdCopy.Enabled = True
                    Else
                        '@機種ｺﾝﾎﾞにｾｯﾄﾌｫｰｶｽ
                        cmbProductCFEnd.Enabled = True
                        Call pubSetFocus(cmbProductCFEnd)
                    
                        '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの非活性化
                        cmdCopy.Enabled = False
                    End If

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "tabControl_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSBID0_Change
    '機　能：利用SB変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 09:43:50 Y.Yamagishi
    '更新日：2004/07/15 (Thu) 09:43:50
    '備　考：
    Private Sub cmbSBID0_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSBID0.Change

        Try

            '@中間WF在庫一覧の初期化
            Call prvvsfLotListWF_Init()
            
            '@WF情報一覧の初期化
            Call prvvsfCarrierInfo_Init()
            
            '@退避領域を初期化
            mstrLotId = vbNullString
            
            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            txtLotID.Text = vbNullString
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSortWFTab.strKey = vbNullString
            
            '@情報取得日時の初期化
            lblNowDateWF.Text = vbNullString
            
            '@ﾒﾝﾃﾅﾝｽﾎﾞﾀﾝの初期化
            cmdCarrierM.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSBID0_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSBID0_CloseUp
    '機　能：利用SBのCloseUp
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 09:45:40 Y.Yamagishi
    '更新日：2004/07/15 (Thu) 09:45:40
    '備　考：
    Private Sub cmbSBID0_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSBID0.CloseUp

        Try

            '@cmbSBID0のValidateｲﾍﾞﾝﾄ呼び出す
            RemoveHandler cmbSBID0.Validating,AddressOf cmbSBID0_Validate
            Call cmbSBID0_Validate(cmbSBID0,New CancelEventArgs(False))
            AddHandler cmbSBID0.Validating,AddressOf cmbSBID0_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSBID0_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSBID0_Validate
    '機　能：利用SBのValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 09:48:27 Y.Yamagishi
    '更新日：2004/07/15 (Thu) 09:48:27
    '備　考：
    Private Sub cmbSBID0_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbSBID0.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@内容が変更されていない場合
            If cmbSBID0.Value = mstrTaihiSBID0 Then
                If ActiveControl.Name = cmbSBID0.Name Then 
                    '@次項目へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(txtLotID)
                End If

                Exit Sub
            End If
            
            '@SBIDの退避
            mstrTaihiSBID0 = cmbSBID0.Value
            
            '@最新情報取得処理へ
            Call cmdNowListWF_Click(cmdNowListWF,New EventArgs)
            
            If vsfLotListWF.Enabled = True Then
                If ActiveControl.Name = cmbSBID0.Name Then 
                    '@一覧にｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(vsfLotListWF)
                End If

                '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの活性化
                cmdCopy.Enabled = True
            Else
                '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの非活性化
                cmdCopy.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSBID0_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Change
    '機　能：元ﾛｯﾄID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/04 (Fri) 10:46:53 S.Deguchi
    '更新日：2005/02/04 (Fri) 10:46:53
    '備　考：
    Private Sub txtLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotID.Change

        Try

            '@中間WF在庫一覧の初期化
            Call prvvsfLotListWF_Init()
            
            '@WF情報一覧の初期化
            Call prvvsfCarrierInfo_Init()
            
            '@退避領域を初期化
            mstrLotId = vbNullString
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSortWFTab.strKey = vbNullString
            
            '@情報取得日時の初期化
            lblNowDateWF.Text = vbNullString
            
            '@ﾒﾝﾃﾅﾝｽﾎﾞﾀﾝの初期化
            cmdCarrierM.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Validate
    '機　能：元ﾛｯﾄIDValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/02/04 (Fri) 10:46:56 S.Deguchi
    '更新日：2005/02/04 (Fri) 10:46:56
    '備　考：
    Private Sub txtLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtLotID.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@元ﾛｯﾄID欄の入力状況による処理分岐
            If txtLotID.Text = vbNullString Then
                
                If ActiveControl.Name = txtLotID.Name Then
                    '@空欄時の場合(ﾌｫｰｶｽｾｯﾄ)
                    If vsfLotListWF.Enabled = True Then
                        '@一覧が表示されている場合
                        Call pubSetFocus(vsfLotListWF)
                    Else
                        If cmdNowListWF.Enabled = True Then
                            '@最新取得が使用できる場合
                            Call pubSetFocus(cmdNowListWF)
                        Else
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                End If
            Else
                '@入力文字数による処理(2文字以下の入力)
                If Len(txtLotID.Text) < CMlngTxtLotIDMinLen Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001H)
                    '@「ロットIDは2桁以上入力してください。」
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽそのまま
                    If Me.ActiveControl.Name = tabControl.Name Then
                        mblnTabSelectEnabled = False
                        sender.Focus()
                    Else
                        e.Cancel = True
                    End If
                    
                    '@処理ｽｷｯﾌﾟ
                    Exit Sub
                End If
            End If
            
            '@退避領域と同じ場合には処理抜け
            If mstrLotId = txtLotID.Text Then
                If ActiveControl.Name = txtLotID.Name Then
                    If vsfLotListWF.Enabled = True Then
                        '@一覧が表示されている場合
                        Call pubSetFocus(vsfLotListWF)
                    Else
                        If cmdNowListWF.Enabled = True Then
                            '@最新取得が使用できる場合
                            Call pubSetFocus(cmdNowListWF)
                        Else
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                End If
                '@処理ｽｷｯﾌﾟ
                Exit Sub
            Else
                '@最新情報取得処理へ
                Call cmdNowListWF_Click(cmdNowListWF,New EventArgs)
            
                If vsfLotListWF.Enabled = True Then
                    If ActiveControl.Name = txtLotID.Name Then
                        '@ﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfLotListWF)
                    End If
                    '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの活性化
                    cmdCopy.Enabled = True
                Else
                    '@最新取得ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtLotID.Name Then
                        If cmdNowListWF.Enabled = True Then
                            Call pubSetFocus(cmdNowListWF)
                        Else
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                    '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの非活性化
                    cmdCopy.Enabled = False
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSendRegist_Click
    '機　能：確定ﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/12 (Wed) 18:04:42 S.Deguchi
    '更新日：2007/03/30 (Fri) 09:37:52 N.Kasai
    '備　考：
    '　　　：2004/11/26 (Fri) 19:59:23 H.Wajima     送品伝票印刷対応
    '　　　：2004/12/06 (Mon) 17:05:04 H.Wajima     不具合修正
    '　　　：2004/12/15 (Wed) 17:05:04 H.Wajima     不具合修正
    '　　　：2004/12/21 (Tue) 16:55:17 H.Wajima     送品後に伝票印刷を行わない場合に最新取得が行われない不具合を修正
    '　　　：2005/02/21 (Mon) 13:07:54 S.Deguchi    送品処理修正対応
    '　　　：2005/03/22 (Tue) 17:47:08 S.Deguchi    送信取消処理追加
    '　　　：2006/09/15 (Fri) 16:18:55 N.Kojima     量産ﾛｯﾄの送品先指定機能追加に伴い、処理修正。(案件№01452)
    '　　　：2007/02/22 (Thu) 16:25:53 N.Kojima     送品先ID設定不具合の修正。(案件№01794)
    '　　　：2007/03/30 (Fri) 09:37:52 N.Kasai      単一送品対応(№01832)
    Private Sub cmdSendRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSendRegist.Click

        Dim lblnCheckAns            As Boolean          '結果取得(True:OK,False:NG)
        Dim lblnAns                 As Boolean          '結果取得(True:正常,False:異常)
        Dim ltypSendLotlist         As SendLotList      '送品ﾛｯﾄ構造体
        Dim llngSendCnt             As Integer          '送品(送品取消)ﾛｯﾄ総数
        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngCnt                 As Integer          '汎用ｶｳﾝﾀ
        Dim lblnRet                 As Boolean          '戻り値
		Dim llngSBCnt               As Integer          '送品先ｶｳﾝﾀ
        Dim llngSendCancelCnt       As Integer          '送品取消ｶｳﾝﾀ
		Dim lstrPdID                As String           '機種退避用

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
            
            '@送品待ち/送品済みの判定
            Select Case True
                
                '@送品待ちが選択されている場合(送品処理)
                Case optLotSendStatus0.Checked
                    
                    '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称を設定
                    lstrFormName = Me.Name
                    lstrEventName = "cmdSendRegist_Click"
                
                    '@初期化
                    If IsNothing(ltypSendLotlist.typSendLot) Then
                        ltypSendLotlist.typSendLot = New List(Of SendLot)()
                    Else
                        ltypSendLotlist.typSendLot.Clear()
                    End If
                    
                    '@送品ﾁｪｯｸ
                    lblnCheckAns = prvblnSendInfo_Chk
                    
                    If lblnCheckAns = False Then
                        '@送品ﾁｪｯｸNG
                        
        '                '@表示ﾒｯｾｰｼﾞ変換
        '                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0066)
        '
        '                '@publngMsgBoxInfo("ロット送品に必要な情報が選択されていません。設定を見直してください。")
        '                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN00F0.Caption, True, 16)
        '
        '                '@ｸﾞﾘｯﾄﾞにｾｯﾄﾌｫｰｶｽ
        '                Call pubSetFocus(vsfLotListSend)
                        
                        Exit Sub
                    End If
                    
                    '@作業者ｺｰﾄﾞ入力
                    frmxxCM0010.Instance.ShowDialog(Me)
                    frmxxCM0010.Instance = Nothing
                    
                    '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
                    If pblnCancel = True Then
                        Exit Sub
                    End If
                    
                    '@更新対象ﾃﾞｰﾀを取得
                    lblnAns = prvblnSendAry_Set(ltypSendLotlist, llngSendCnt)
                    If lblnAns = False Then
                        Exit Sub
                    End If
                    
                    '@ｲﾝﾌｫﾒｰｼｮﾝﾌｫｰﾑを先行して描画する為、記述しています。
                    '@作業者ID画面表示を閉じます。
                    'DoEvents
                    
                    lblnAns = prvblnSendRegist_Set(ltypSendLotlist, llngSendCnt)
                    If lblnAns = True Then
            
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0044)
                        '@pubVsfInfo_Disp("メッセージコード：C_I44%0$$ロットを送品しました。")
                        Call pubVsfInfo_Disp(pstrDMsg)
            
                        '@送品確定後は編集中のﾁｪｯｸは行わないようﾌﾗｸﾞをOFF
                        mblnInEditKbn = False
                        
                        '@送品ﾌﾗｸﾞにTrueを設定
                        pblnLotSendFlag = True

                        '@送品伝票印刷
                        lblnRet = prvblnSendOrderListPrint_Proc(ltypSendLotlist, llngSendCnt)
                        '@戻り値の判定
                        If lblnRet = True Then
                            '@正常終了の場合

                            '@画面情報の最新取得
                            Call cmdNowListSend_Click(cmdNowListSend,New EventArgs)
                        End If


                    Else
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                    End If
                    
                    '@ﾃﾞｰﾀが1件以上の場合
                    If vsfLotListSend.Rows.Count > vsfLotListSend.Rows.Fixed Then
                        '@ｸﾞﾘｯﾄﾞにｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(vsfLotListSend)
                        
                        '@選択行がﾀｲﾄﾙの場合
                        Select Case vsfLotListSend.Row
                            Case 0, -1
                                vsfLotListSend.Row = vsfLotListSend.Rows.Fixed
                        End Select
                        
                    End If
                    
                    '@送品ﾎﾞﾀﾝ無効
                    cmdSendRegist.Enabled = False
                    
                '@送品済みが選択されている場合(送品取消処理)
                Case optLotSendStatus1.Checked
                
                    '@初期化
                    llngSendCancelCnt = 0
                    
                    '@ﾁｪｯｸがついている行が1行か確認する
                    With vsfLotListSend
                        For llngCnt = 1 To .Rows.Count - 1
                            '@ﾁｪｯｸが1つか確認
                            If .GetCellCheck(llngCnt, CMlngvsfSend2ColCB) = CheckEnum.Checked Then
                                '@ｶｳﾝﾄｱｯﾌﾟ
                                llngSendCancelCnt = llngSendCancelCnt + 1
                                
                            End If
                        Next llngCnt
                    End With
                    
                    '@ｶｳﾝﾄ数により処理を分岐
                    Select Case llngSendCancelCnt
                        
                        '@1件も選択されていない場合：NG
                        Case 0
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004H)
                            '@"<TRM4HW>$$送品取消するロットが選択されていません。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Sub
                        
                        '@1件のみ選択されている場合：OK
                        Case 1
                            '@何もしない
                        
                        '@1件以上選択されている場合：NG
                        Case Else
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005G)
                            '@"<TRM5GW>$$複数のロットに対して送品取消できません。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Sub
                    End Select
                    
                    '@選択行の情報を構造体へ退避
                    Call prvSendCancelConnect_Set()
                    
                    '@子画面をﾛｰﾄﾞ
                    frmxxEN00F9.Instance = New frmxxEN00F9()
                    
                    '@子画面名称設定
                    frmxxEN00F9.Instance.Text = CPstrSubFormEN00F9
                    
                    '@画面起動
                    frmxxEN00F9.Instance.ShowDialog(Me)
                    frmxxEN00F9.Instance = Nothing
                    
                    '@確定処理が行われた場合
                    If ptypSendCancelConnect.strRegistFlag = CMstrRegistFlag1 Then
                        '@送品取消確定後は編集中のﾁｪｯｸは行わないようﾌﾗｸﾞをOFF
                        mblnInEditKbn = False
                        
                        '@最新取得処理
                        Call cmdNowListSend_Click(cmdNowListSend,New EventArgs)
                        
                        '@ﾌｫｰｶｽはﾀｲﾄﾙ行へｾｯﾄ
                        vsfLotListSend.Row = CMlngVsfRowTitle
                    End If
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSendRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSendOrderList_Click
    '機　能：完成在庫-送品伝票印刷ﾎﾞﾀﾝ ｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/26 (Fri) 08:55:57 H.Wajima
    '更新日：2009/05/11 (Mon) 12:12:40 N.Kojima
    '備　考：
    '　　　：2004/12/06 (Mon) 17:07:11 H.Wajima     不具合修正
    '　　　：2005/02/21 (Mon) 14:47:40 S.Deguchi    送品伝票印刷処理見直しによる処理修正
    '　　　：2009/05/11 (Mon) 12:12:40 N.Kojima     送品伝票のﾊﾝｺ欄を送品先別に変更する対応に伴い、送品先IDを格納するように修正。(案件№03520)
    Private Sub cmdSendOrderList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSendOrderList.Click
        
        Dim lblnRet                     As Boolean              '戻り値
        Dim lstrLotID                   As List(Of String)      '送信ﾛｯﾄIDﾘｽﾄ
        Dim llngLotCnt                  As Integer              '送信ﾛｯﾄIDﾘｽﾄｶｳﾝﾄ
        Dim ltypGetSendOrderList        As GetSendOrderList     '送品伝票情報構造体
        Dim llngCnt                     As Integer              'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2                    As Integer              'ﾙｰﾌﾟｶｳﾝﾀ2

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
            
            '@選択項目と同じ条件のﾛｯﾄを検索する
            lblnRet = prvblnvsfLotListSend_Sel(lstrLotID, llngLotCnt)
            '@戻り値の判定
            If lblnRet = False Then
                '@異常終了の場合
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004E)
                
                '@"<TRM4EW>$$送品伝票印刷に必要な情報が登録されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                Exit Sub
            Else
                '@正常終了の場合
                
                '@送品先ﾛｯﾄ情報の件数の判定
                If llngLotCnt = 0 Then
                    '@送品先ﾛｯﾄ情報が0件の場合
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004E)
                    
                    '@"<TRM4EW>$$送品伝票印刷に必要な情報が登録されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    Exit Sub
                End If
            End If

            '@送品伝票情報取得
            lblnRet = pubblnInvGetSendOrderList_Sel(CMstrinv_getsendorderlistVer, _
                                                    llngLotCnt, _
                                                    lstrLotID, _
                                                    ltypGetSendOrderList)
            If lblnRet = False Then
                '@異常終了の場合
                
                '@ﾌｫｰｶｽｾｯﾄ
                If vsfLotListSend.Enabled = True Then
                '@送品ﾘｽﾄが使用可能状態の場合
                    '@ﾘｽﾄにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfLotListSend)
                Else
                    '@閉じるにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
                
                Exit Sub
            End If
            
            '@送品先IDを格納
            With ltypGetSendOrderList

                For llngCnt = 0 To llngLotCnt -1
                    
                    For llngCnt2 = 0 To .lngLotListCount -1
                        
                        '@送品ﾛｯﾄ情報のﾛｯﾄIDと送品伝票情報のﾛｯﾄIDが同じか
                        If mtypstocklotlist(llngCnt).strLotID = _
                            .typLotList(llngCnt2).strLotID Then
                            
                            '@送品先IDを格納
                            Dim typLotListTmp As GetSendOrderListLotList = .typLotList(llngCnt2)
                            typLotListTmp.strSendSBID = _
                                mtypstocklotlist(llngCnt).strSendSBID

                            .typLotList(llngCnt2) = typLotListTmp
                        End If
                    Next llngCnt2
                Next llngCnt
            End With
           
            '@送品伝票印刷
            lblnRet = prvblnSendOrderList_Pri(ltypGetSendOrderList)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSendOrderList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名: cmdLotExamInfo_Click
    '機　能：完成在庫-ﾛｯﾄ検定表印刷ﾎﾞﾀﾝ ｸﾘｯｸ処理
    '引 数: なし
    '戻り値: なし
    '作成日：2004/11/26 (Fri) 15:05:39 H.Wajima
    '更新日：2004/11/26 (Fri) 15:05:39
    '備 考:
    Private Sub cmdLotExamInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotExamInfo.Click

        Dim ltypSendSBList              As List(Of SendSBList)      '送品先構造体
        Dim llngSendSBCount             As Integer                  '送品先構造体ｶｳﾝﾀ
        Dim llngCnt                     As Integer                  '汎用ｶｳﾝﾀ
        Dim llngCnt2                    As Integer                  '汎用ｶｳﾝﾀ
        Dim ltypGetLotExamInfo          As List(Of GetLotExamInfo)  'ﾛｯﾄ検定表情報構造体
        Dim llngGetLotExamInfoCount     As Integer                  'ﾛｯﾄ検定表情報構造体ｶｳﾝﾀ
        Dim ltypWkGetLotExamInfo        As GetLotExamInfo           'Workﾛｯﾄ検定表情報構造体
        Dim lblnRet                     As Boolean                  '戻り値

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
            
            '@送品先ﾛｯﾄ情報の取得
            lblnRet = prvblnAfterPrintLotList_Set(llngSendSBCount, ltypSendSBList)
            '@戻り値の判定
            If lblnRet = False Then
                '@異常終了の場合
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004E)
                
                '@"<TRM4EW>$$送品伝票印刷に必要な情報が登録されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                Exit Sub
            Else
                '@正常終了の場合
                
                '@送品先ﾛｯﾄ情報の件数の判定
                If llngSendSBCount = 0 Then
                    '@送品先ﾛｯﾄ情報が0件の場合
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004E)
                    
                    '@"<TRM4EW>$$送品伝票印刷に必要な情報が登録されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If
            End If
            
            '@構造体ｶｳﾝﾀの初期化
            llngGetLotExamInfoCount = 0
            
            '@構造体の初期化
            ltypGetLotExamInfo = New List(Of GetLotExamInfo)

            '@送品先ｶｳﾝﾀの判定
            '@送品先ごとのﾙｰﾌﾟ
            For llngCnt = 0 To llngSendSBCount -1
                '@ATLASｵｰﾀﾞｰありの処理
                With ltypSendSBList(llngCnt).typAtlasExistList
                    If .lngLotListCount > 0 Then
                        For llngCnt2 = 0 To .lngLotListCount -1
                        
                            '@ﾛｯﾄ検定表情報取得
                            lblnRet = pubblnInvGetLotExamInfo_Sel(CMstrinv_getlotexaminfoVer, _
                                                                  .strLotList(llngCnt2).strLotID, _
                                                                  ltypWkGetLotExamInfo)
                            '@戻り値の判定
                            If lblnRet = True Then
                                '@正常終了の場合
                                
                                '@送品伝票情報構造体ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                                llngGetLotExamInfoCount = llngGetLotExamInfoCount + 1
                                
                                '@構造体に取得情報を退避
                                ltypGetLotExamInfo.Add(ltypWkGetLotExamInfo)

                            Else
                                '@異常終了の場合
                                Exit Sub
                            End If
                        Next llngCnt2
                    End If
                End With

                '@ATLASｵｰﾀﾞｰなしの処理
                With ltypSendSBList(llngCnt).typAtlasNotExistList
                    If .lngLotListCount > 0 Then
                        For llngCnt2 = 0 To .lngLotListCount -1
                            '@ﾛｯﾄ検定表情報取得
                            lblnRet = pubblnInvGetLotExamInfo_Sel(CMstrinv_getlotexaminfoVer, _
                                                                  .strLotList(llngCnt2).strLotID, _
                                                                  ltypWkGetLotExamInfo)
                            '@戻り値の判定
                            If lblnRet = True Then
                                '@正常終了の場合
                                
                                '@送品伝票情報構造体ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                                llngGetLotExamInfoCount = llngGetLotExamInfoCount + 1
                                
                                '@構造体に取得情報を退避
                                ltypGetLotExamInfo.Add(ltypWkGetLotExamInfo)
                            Else
                                '@異常終了の場合
                                Exit Sub
                            End If
                        Next llngCnt2
                    End If
                End With
            Next llngCnt

            '@ﾛｯﾄ検定表印刷
            lblnRet = prvblnLotExamInfo_Pri(ltypGetLotExamInfo)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotExamInfo_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProductCFEnd_Change
    '機　能：CF完成在庫-機種変更処理
    '引　数：なし
    '戻り値：
    '作成日：2004/12/06 (Mon) 10:49:57 S.Deguchi
    '更新日：2006/10/06 (Fri) 12:02:40 N.Kasai
    '備　考：
    '　　　：2006/02/10 (Fri) 17:30:42 N.Kojima     ﾎﾞﾀﾝの無効化制御を追加。(運用障害№539対応)
    '　　　：2006/10/06 (Fri) 12:02:40 N.Kasai      ﾁｯﾌﾟ合計ｸﾘｱ
    Private Sub cmbProductCFEnd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProductCFEnd.Change

        Try

            '@初期化
            '@CF完成在庫一覧のｸﾘｱ
            Call prvvsfLotlistCFEnd_Init()
            
            '@Commandﾎﾞﾀﾝの初期化
            cmdHoldCFEnd.Enabled = False        '保留
            cmdCancelCFEnd.Enabled = False      '保留解除
            cmdCFEnd.Enabled = False            '数量増減
            cmdRework.Enabled = False           'ﾘﾜｰｸ
            cmdCommentCFEnd.Enabled = False     'ﾛｯﾄｺﾒﾝﾄ
            cmdNowListCFEnd.Enabled = False     '最新取得
            cmdCopy.Enabled = False             'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
                
            '@ﾁｯﾌﾟ合計ｸﾘｱ
            lblNum.Text = 0
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProductCFEnd_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProductCFEnd_CloseUp
    '機　能：CF完成在庫-CloseUp処理
    '引　数：なし
    '戻り値：
    '作成日：2004/12/06 (Mon) 10:50:00 S.Deguchi
    '更新日：2004/12/06 (Mon) 10:50:00
    '備　考：
    Private Sub cmbProductCFEnd_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProductCFEnd.CloseUp

        Try


            '@空欄 or 0項目以外の場合
            If cmbProductCFEnd.Text <> vbNullString And _
                cmbProductCFEnd.Text <> CMstrCmbAddedCommentNone Then
                
                '@Validate処理
                RemoveHandler cmbProductCFEnd.Validating,AddressOf cmbProductCFEnd_Validate
                Call cmbProductCFEnd_Validate(cmbProductCFEnd,New CancelEventArgs(True))
                AddHandler cmbProductCFEnd.Validating,AddressOf cmbProductCFEnd_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProductCFEnd_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProductCFEnd_Validate
    '機　能：CF完成在庫-Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 10:50:02 S.Deguchi
    '更新日：2004/12/06 (Mon) 10:50:02
    '備　考：
    Private Sub cmbProductCFEnd_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbProductCFEnd.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If cmbProductCFEnd.Text = vbNullString Or _
                cmbProductCFEnd.Text = CMstrCmbAddedCommentNone Then
                
                If ActiveControl.Name = cmbProductCFEnd.Name Then 
                    '@空欄 or 0項目の場合
                    If cmdNowListCFEnd.Enabled = True Then
                        '@最新取得へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdNowListCFEnd)
                    Else
                        '@閉じるにｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmdClose)
                    End If
                End If

                Exit Sub
            End If

            If ActiveControl.Name <> cmbProductCFEnd.Name Then 
                mblnSetFocus = True
            End If

            '@最新情報取得処理へ
            Call cmdNowListCFEnd_Click(cmdNowListCFEnd,New EventArgs)

            mblnSetFocus = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProductCFEnd_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowListCFEnd_Click
    '機　能：CF完成在庫-最新取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 11:08:41 S.Deguchi
    '更新日：2004/12/06 (Mon) 11:08:41
    '備　考：
    Private Sub cmdNowListCFEnd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowListCFEnd.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypClassCompList       As ClassCompleteList    '要求格納構造体
        Dim llngStockListCnt        As Integer              '取得数
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngLoopCnt             As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrTemp                As Object               '一時取得

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

            '@空欄 or 0項目の場合
            If cmbProductCFEnd.Text = vbNullString Or _
                cmbProductCFEnd.Text = CMstrCmbAddedCommentNone Then
                Call pubSetFocus(cmbProductCFEnd)
                
                Exit Sub
            End If

            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
            lstrFormName = Me.Name
            lstrEventName = "cmdNowList_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
                
            'NSYS 選択行がある場合
            If vsfLotListCFEnd.Row > 0 Then
                'NSYS 選択列をNo.列に移動
                vsfLotListCFEnd.Col = CMlngvsfSendColNo
            End If

            '@要求格納構造体の初期化
            If ltypClassCompList.typFlowClassList Is Nothing Then
                ltypClassCompList.typFlowClassList = New List(Of FlowClassList)
            Else
                ltypClassCompList.typFlowClassList.Clear
            End If
            If ltypClassCompList.typPdList Is Nothing Then
                ltypClassCompList.typPdList = New List(Of PDList)
            Else
                ltypClassCompList.typPdList.Clear
            End If
            If mtypstocklotlist2 Is Nothing Then
                mtypstocklotlist2 = New List(Of StockLotList)
            Else
                mtypstocklotlist2.Clear
            End If

            '@要求格納構造体へ格納
            With ltypClassCompList
                .strSbID = pstrSBID                                                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strClassDivison = CPstrCD04 & CPstrCD0H                                        'ClassDivision:040H
                
                .lngPdCnt = cmbProductCFEnd.ValueCount                                           'PD_IDｶｳﾝﾄ数
                '@機種区分構造体作成
                Dim typPdListTmp As New PDList
                lstrTemp = Split(cmbProductCFEnd.Value, vbTab)
                For llngLoopCnt = LBound(lstrTemp) To UBound(lstrTemp)
                    typPdListTmp.strPdId = lstrTemp(llngLoopCnt)                 '機種ID
                    .typPdList.Add(typPdListTmp)
                Next llngLoopCnt
                
                '@機種区分(1件のみ)
                .lngFlowClassCnt = 1                                                            'Classｶｳﾝﾄ数
                Dim typFlowClassListTmp As New FlowClassList
                typFlowClassListTmp.strFlowClass = "PR"                         '種別ID
                .typFlowClassList.Add(typFlowClassListTmp)

                .strInventoryFlag = CPstrInventory09                                            '完成
                .strHoldFlag = vbNullString                                                     '(0：通常 1：保留ﾛｯﾄ 但し通常・保留両方の場合はNULL)
            End With

            '@完成在庫Lot一覧取得
            lblnAns = pubblnInvCompLotList_Sel(CMstrinv_complotlistVer, _
                                               ltypClassCompList, _
                                               mtypstocklotlist2, _
                                               llngStockListCnt)
            If lblnAns = True Then
            
                '@最新取得ﾎﾞﾀﾝ活性化
                cmdNowListCFEnd.Enabled = True
                
                '@一覧表示
                Call prvvsfLotListCFEnd_Disp(mtypstocklotlist2, llngStockListCnt)
                
                If vsfLotListCFEnd.Enabled = True Then
                    If mblnSetFocus = False Then
                        '@一覧へｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(vsfLotListCFEnd)
                    End If
                    
                    '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの活性化
                    cmdCopy.Enabled = True
                    
                Else
                    If mblnSetFocus = False Then
                        '@最新取得ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                        If cmdNowListCFEnd.Enabled = True Then
                            Call pubSetFocus(cmdNowListCFEnd)
                        End If
                    End If
                End If
            
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)

                '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
                If lblLotCntCFEnd.Text = CPstrLotCnt0 Then
                    '@CF完成在庫一覧のｸﾘｱ
                    Call prvvsfLotlistCFEnd_Init()

                    '@各ﾎﾞﾀﾝの非活性化
                    cmdHoldCFEnd.Enabled = False            '保留
                    cmdCancelCFEnd.Enabled = False          '保留解除
                    cmdCFEnd.Enabled = False                '数量増減
                    cmdRework.Enabled = False               'ﾘﾜｰｸ
                    cmdCommentCFEnd.Enabled = False         'ﾛｯﾄｺﾒﾝﾄ
                End If
            Else
                '@CF完成在庫一覧のｸﾘｱ
                Call prvvsfLotlistCFEnd_Init()

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@各ﾎﾞﾀﾝの非活性化
                cmdHoldCFEnd.Enabled = False            '保留
                cmdCancelCFEnd.Enabled = False          '保留解除
                cmdCFEnd.Enabled = False                '数量増減
                cmdRework.Enabled = False               'ﾘﾜｰｸ
                cmdCommentCFEnd.Enabled = False         'ﾛｯﾄｺﾒﾝﾄ
                cmdCopy.Enabled = False                 'ｺﾋﾟｰ

                If mblnSetFocus = False Then
                    Call pubSetFocus(cmbProductCFEnd)
                End If

                Exit Sub
            End If

            'NSYS 選択行が未指定の場合はヘッダ行を選択状態にする
            If vsfLotListCFEnd.Row < 0 Then
                vsfLotListCFEnd.Row = 0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowListCFEnd_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdHoldCFEnd_Click
    '機　能：CF完成在庫-保留
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 15:25:22 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:37:05 T.Oide
    '備　考：なし
    Private Sub cmdHoldCFEnd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHoldCFEnd.Click

        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

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
            
            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngCFEndTab)
            
            '@起動区分ｾｯﾄ(保留起動)
            ptypHoldConnect.strLotHoldFlg = "0"
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListCFEnd
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfCFEndColLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN00F1.Instance = New frmxxEN00F1()
            
            '@子画面名称設定
            frmxxEN00F1.Instance.Text = CPstrSubFormEN00F1Hold
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00F1.Instance = Nothing
                Exit Sub
            End If
            
            '@保留画面起動
            frmxxEN00F1.Instance.ShowDialog(Me)
            frmxxEN00F1.Instance = Nothing

            '@最新取得処理
            Call cmdNowListCFEnd_Click(cmdNowListCFEnd,New EventArgs)

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListCFEnd, lstrKeyID, CMlngvsfCFEndColLotID, cmdClose)
            
            '@ﾌｫｰｶｽｾｯﾄ
            With vsfLotListCFEnd
                If .Enabled = True Then
                    Call pubSetFocus(vsfLotListCFEnd)
                Else
                    Call pubSetFocus(cmdClose)
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdHoldCFEnd_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCancelCFEnd_Click
    '機　能：CF完成在庫-保留解除
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 15:25:25 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:37:13 T.Oide
    '備　考：
    Private Sub cmdCancelCFEnd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelCFEnd.Click

        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

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
            
            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngCFEndTab)
            
            '@起動区分ｾｯﾄ(保留解除起動)
            ptypHoldConnect.strLotHoldFlg = "1"
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListCFEnd
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfCFEndColLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN00F1.Instance = New frmxxEN00F1()
            
            '@子画面名称設定
            frmxxEN00F1.Instance.Text = CPstrSubFormEN00F1Cancel
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00F1.Instance = Nothing
                Exit Sub
            End If
            
            '@保留解除画面起動
            frmxxEN00F1.Instance.ShowDialog(Me)
            frmxxEN00F1.Instance = Nothing

            '@最新取得処理
            Call cmdNowListCFEnd_Click(cmdNowListCFEnd,New EventArgs)

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListCFEnd, lstrKeyID, CMlngvsfCFEndColLotID, cmdClose)
            
            '@ﾌｫｰｶｽｾｯﾄ
            With vsfLotListCFEnd
                If .Enabled = True Then
                    Call pubSetFocus(vsfLotListCFEnd)
                Else
                    Call pubSetFocus(cmdClose)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCancelCFEnd_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCFEnd_Click
    '機　能：CF完成在庫-数量払出
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 15:25:27 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:37:22 T.Oide
    '備　考：
    Private Sub cmdCFEnd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCFEnd.Click

        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

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
            
            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngCFEndTab)
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListCFEnd
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfCFEndColLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN00F7.Instance = New frmxxEN00F7()
            
            '@子画面名称設定
            frmxxEN00F7.Instance.Text = CPstrSubFormEN00F7
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00F7.Instance = Nothing
                Exit Sub
            End If
            
            '@CF払出画面起動
            frmxxEN00F7.Instance.ShowDialog(Me)
            frmxxEN00F7.Instance = Nothing

            '@最新取得処理
            Call cmdNowListCFEnd_Click(cmdNowListCFEnd,New EventArgs)

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListCFEnd, lstrKeyID, CMlngvsfCFEndColLotID, cmdClose)
            
            '@ﾌｫｰｶｽｾｯﾄ
            With vsfLotListCFEnd
                '@選択行がﾀｲﾄﾙの場合
                If .Row = 0 Then
                    '@各ﾎﾞﾀﾝの非活性化
                    cmdHoldCFEnd.Enabled = False            '保留
                    cmdCancelCFEnd.Enabled = False          '保留解除
                    cmdCFEnd.Enabled = False                '数量増減
                    cmdRework.Enabled = False               'ﾘﾜｰｸ
                    cmdCommentCFEnd.Enabled = False         'ﾛｯﾄｺﾒﾝﾄ
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCFEnd_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRework_Click
    '機　能：CF完成在庫-ﾘﾜｰｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 15:25:30 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:37:30 T.Oide
    '備　考：
    Private Sub cmdRework_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRework.Click

        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

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
            
            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngCFEndTab)
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListCFEnd
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfCFEndColLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN00F6.Instance = New frmxxEN00F6()
            
            '@子画面名称設定
            frmxxEN00F6.Instance.Text = CPstrSubFormEN00F6
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00F6.Instance = Nothing
                Exit Sub
            End If
            
            '@CF払出画面起動
            frmxxEN00F6.Instance.ShowDialog(Me)
            frmxxEN00F6.Instance = Nothing

            '@最新取得処理
            Call cmdNowListCFEnd_Click(cmdNowListCFEnd,New EventArgs)

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListCFEnd, lstrKeyID, CMlngvsfCFEndColLotID, cmdClose)
            
            '@ﾌｫｰｶｽｾｯﾄ
            With vsfLotListCFEnd
                '@選択行がﾀｲﾄﾙの場合
                If .Row = 0 Then
                    '@各ﾎﾞﾀﾝの非活性化
                    cmdHoldCFEnd.Enabled = False            '保留
                    cmdCancelCFEnd.Enabled = False          '保留解除
                    cmdCFEnd.Enabled = False                '数量増減
                    cmdRework.Enabled = False               'ﾘﾜｰｸ
                    cmdCommentCFEnd.Enabled = False         'ﾛｯﾄｺﾒﾝﾄ
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRework_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCFEndWFInfo_Click
    '機　能：WF情報表示ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/05 (Mon) 10:57:59 N.Kojima
    '更新日：2012/01/24 (Tue) 13:37:40 T.Oide
    '備　考：
    Private Sub cmdCFEndWFInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCFEndWFInfo.Click

        Dim lstrKeyID           As String               'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow          As Integer              '現在行を格納
        Dim lblnAns             As Boolean              '汎用戻り値(boolean型)
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrClassDivision   As String               '処理区分格納用

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
                
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdCFEndWFInfo_Click"
                
            '@引継ぎ構造体に格納(その1)
            With vsfLotListCFEnd
                ptypCommonInfo.strCarrierId = .GetData(.Row, CMlngvsfCFEndColCarrierID)        'ｷｬﾘｱID
                ptypCommonInfo.strLotID = .GetData(.Row, CMlngvsfCFEndColLotID)                'ﾛｯﾄID
                ptypCommonInfo.strChipQuantity = .GetData(.Row, CMlngvsfCFEndColCfNum)         'ﾁｯﾌﾟ数
            End With
                
            '@処理区分格納(0L=ﾛｯﾄ指定)
            lstrClassDivision = CPstrCD0L
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ﾛｯﾄ情報詳細取得処理
            lblnAns = pubblnLotDetail_Sel(CMstrlot_detail__Ver, _
                                          pstrSBID, _
                                          lstrClassDivision, _
                                          ptypCommonInfo.strLotID, _
                                          ptypCommonInfo.strCarrierId, _
                                          mtypLotDetailInfo)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Sub
            Else
                '@流動区分を格納
                ptypCommonInfo.strFlowClass = mtypLotDetailInfo.strFlowClass
                
                '@TPALﾛｯﾄか(CF_FLAG!=2)
                If mtypLotDetailInfo.strCfFlag <> CPstrTwo Then
                    '@CFﾛｯﾄの場合
                    ptypCommonInfo.strSlotSize = CMstrCFSlotSize        'CFﾛｯﾄｽﾛｯﾄｻｲｽﾞ
                End If
                
                '@CFﾌﾗｸﾞを格納
                ptypCommonInfo.strCfFlag = mtypLotDetailInfo.strCfFlag
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListCFEnd
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfCFEndColLotID)
                
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面(WF情報)をﾛｰﾄﾞ
            frmxxEN00FA.Instance = New frmxxEN00FA()
            
            '@子画面名称設定
            frmxxEN00FA.Instance.Text = CPstrSubFormEN00FA
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00FA.Instance = Nothing
                
                Exit Sub
            End If
            
            '@WF情報画面起動
            Call frmxxEN00FA.Instance.ShowDialog(Me)

            '@引継ぎ構造体を初期化
            With ptypCommonInfo
                .strCarrierId = vbNullString        'ｷｬﾘｱID
                .strLotID = vbNullString            'ﾛｯﾄID
                .strFlowClass = vbNullString        '種別
                .strSlotSize = vbNullString         'ｽﾛｯﾄｻｲｽﾞ
                .strCfFlag = vbNullString           'CFﾌﾗｸﾞ
                .strChipQuantity = vbNullString     'ﾁｯﾌﾟ数
            End With

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListCFEnd, lstrKeyID, CMlngvsfCFEndColLotID, cmdClose)
            
            '@ﾌｫｰｶｽｾｯﾄ
            With vsfLotListCFEnd
                '@選択行がﾀｲﾄﾙの場合
                If .Row = 0 Then
                    '@各ﾎﾞﾀﾝの非活性化
                    cmdHoldCFEnd.Enabled = False            '保留
                    cmdCancelCFEnd.Enabled = False          '保留解除
                    cmdCFEnd.Enabled = False                '数量増減
                    cmdRework.Enabled = False               'ﾘﾜｰｸ
                    cmdCommentCFEnd.Enabled = False         'ﾛｯﾄｺﾒﾝﾄ
                    cmdCFEndWFInfo.Enabled = False          'WF情報表示
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCFEndWFInfo_Click"       '処理名
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentCFEnd_Click
    '機　能：CF完成在庫-ｺﾒﾝﾄ表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 15:25:33 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:37:51 T.Oide
    '備　考：
    '　　　：2004/12/08 (Wed) 17:46:48 H.Wajima     不具合修正
    '　　　：2006/02/08 (Wed) 16:27:06 N.Kojima     編集ﾌﾗｸﾞをTrueで設定し、ﾛｯﾄｺﾒﾝﾄの登録も可能とする。(運用障害№539対応)
    '　　　：2012/01/24 (Tue) 13:37:51 T.Oide       REQ-1115で関数共通化
    Private Sub cmdCommentCFEnd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentCFEnd.Click

        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@引継ぎ構造体に格納
            Call prvHoldConnect_Set(CMlngCFEndTab)

            '@編集ﾌﾗｸﾞに編集不可を設定
            ptypHoldConnect.blnEditFlag = True
            
            '@子画面名称設定
            frmxxEN00F4.Instance.Text = CPstrSubFormEN00F4
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotListCFEnd
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfCFEndColLotID)
                
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@ｺﾒﾝﾄ画面起動
            frmxxEN00F4.Instance.ShowDialog(Me)
            frmxxEN00F4.Instance = Nothing
            
            '@ﾛｯﾄｺﾒﾝﾄが更新されているか
            If pblnCommetsCommitFlag = True Then
                '@最新情報の取得
                Call cmdNowListCFEnd_Click(cmdNowListCFEnd,New EventArgs)
                
                '@ﾛｯﾄｺﾒﾝﾄ更新ﾌﾗｸﾞを初期化
                pblnCommetsCommitFlag = False
            End If
            
            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfLotListCFEnd, lstrKeyID, CMlngvsfCFEndColLotID, cmdClose)
            
            '@ﾌｫｰｶｽｾｯﾄ
            With vsfLotListCFEnd
                If .Enabled = True Then
                    Call pubSetFocus(vsfLotListCFEnd)
                Else
                    Call pubSetFocus(cmdClose)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommentCFEnd_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListCFEnd_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 13:17:54 S.Deguchi
    '更新日：2004/12/06 (Mon) 13:17:54
    '備　考：
    Private Sub vsfLotListCFEnd_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotListCFEnd.AfterSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListCFEnd.Rows.Count <= vsfLotListCFEnd.Rows.Fixed Then
                Return
            End If

            AddHandler vsfLotListCFEnd.EnterCell,AddressOf vsfLotListCFEnd_EnterCell
            AddHandler vsfLotListCFEnd.BeforeRowColChange,AddressOf vsfLotListCFEnd_BeforeRowColChange

             '@ｿｰﾄ順を格納
            With mtypChgSortCFEndTab
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                Do While (.typChgSortList.Count -1 < .lngCnt)
                    .typChgSortList.Add(New ChgSortList)
                Loop
                Dim typChgSortListTmp As ChgSortList = New ChgSortList
                
                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納（昇順/降順）
                typChgSortListTmp.lngOrder = e.Order
                .typChgSortList(.lngCnt) = typChgSortListTmp

                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
            End With

            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
            Call pubVsfAfterSort(vsfLotListCFEnd, CMlngVsfRowTitle,Nothing, Nothing, False, False, False, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListCFEnd_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListCFEnd_AfterUserResize
    '機　能：ｸﾞﾘｯﾄﾞｻｲｽﾞ変更
    '引　数：Row：変更行
    '　　　：Col：変更列
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 13:17:58 S.Deguchi
    '更新日：2004/12/06 (Mon) 13:17:58
    '備　考：
    Private Sub vsfLotListCFEnd_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotListCFEnd.AfterResizeColumn, vsfLotListCFEnd.AfterResizeRow

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListCFEnd.Rows.Count <= vsfLotListCFEnd.Rows.Fixed Then
                Return
            End If

             '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSortCFEndTab.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListCFEnd_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListCFEnd_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞﾌｫｰｶｽ移動
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 13:18:01 S.Deguchi
    '更新日：2004/12/06 (Mon) 13:18:01
    '備　考：
    Private Sub vsfLotListCFEnd_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLotListCFEnd.BeforeRowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListCFEnd.Rows.Count <= vsfLotListCFEnd.Rows.Fixed Then
                Return
            End If

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ﾛｯﾄID)
                mtypChgSortCFEndTab.strKey = vsfLotListCFEnd.GetData(e.NewRange.r1, CMlngvsfCFEndColLotID)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListCFEnd_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListCFEnd_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 13:18:03 S.Deguchi
    '更新日：2004/12/06 (Mon) 13:18:03
    '備　考：
    Private Sub vsfLotListCFEnd_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotListCFEnd.BeforeSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListCFEnd.Rows.Count <= vsfLotListCFEnd.Rows.Fixed Then
                Return
            End If

            RemoveHandler vsfLotListCFEnd.EnterCell,AddressOf vsfLotListCFEnd_EnterCell
            RemoveHandler vsfLotListCFEnd.BeforeRowColChange,AddressOf vsfLotListCFEnd_BeforeRowColChange

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfBeforeSort(vsfLotListCFEnd, CMlngVsfRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListCFEnd_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListCFEnd_EnterCell
    '機　能：ｷｬﾘｱ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 13:18:06 S.Deguchi
    '更新日：2006/02/03 (Fri) 14:49:08 N.Kojima
    '備　考：
    '　　　：2005/04/14 (Thu) 09:00:18 S.Deguchi    複数保留対応
    '　　　：2005/05/10 (Tue) 11:22:00 S.Deguchi    ﾘﾜｰｸｶｳﾝﾄ判別処理を追加
    '　　　：2005/09/01 (Thu) 17:25:19 N.Kojima     WF情報表示ﾎﾞﾀﾝ追加に伴う対応。(不具合№3047)
    '　　　：2006/02/03 (Fri) 14:49:08 N.Kojima     ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝを無条件で有効にする。(運用障害№539対応)
    Private Sub vsfLotListCFEnd_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotListCFEnd.EnterCell

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListCFEnd.Rows.Count <= vsfLotListCFEnd.Rows.Fixed Then
                Return
            End If

            With vsfLotListCFEnd
                '@ﾍｯﾀﾞｰ以外の場合
                If .Row > 0 Then
                    '@保留ﾌﾗｸﾞが立っている場合
                    If .GetData(.Row, CMlngvsfCFEndColHoldFlag) = CMstrLotHoldFlgOn Then
                        '@保留ﾎﾞﾀﾝを活性化
                        cmdHoldCFEnd.Enabled = True
                        '@保留解除ﾎﾞﾀﾝを活性化
                        cmdCancelCFEnd.Enabled = True
                        '@数量払出ﾎﾞﾀﾝを活性化
                        cmdCFEnd.Enabled = True
                    Else
                        '@保留ﾎﾞﾀﾝを活性化
                        cmdHoldCFEnd.Enabled = True
                        '@保留解除ﾎﾞﾀﾝを非活性化
                        cmdCancelCFEnd.Enabled = False
                        '@数量払出ﾎﾞﾀﾝを非活性化
                        cmdCFEnd.Enabled = True
                    End If
                            
                    '@無条件でﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝを活性化
                    cmdCommentCFEnd.Enabled = True
                    
                    '@最大ﾘﾜｰｸ回数とﾘﾜｰｸ回数を比較する
                    If .GetData(.Row, CMlngvsfCFEndColReworkCount) < _
                        .GetData(.Row, CMlngvsfCFEndColRegenerationCnt) Then
                    
                        '@CFﾘﾜｰｸ
                        cmdRework.Enabled = True
                    Else
                        '@CFﾘﾜｰｸ
                        cmdRework.Enabled = False
                    End If
                Else
                    '@WF情報表示ﾎﾞﾀﾝを無効に
                    cmdCFEndWFInfo.Enabled = False
                End If
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListCFEnd_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：chkForign_Click
    '機　能：
    '引　数：Index：
    '戻り値：
    '作成日：2012/10/18 (Thu) 09:31:54 T.Oide
    '更新日：2012/10/18 (Thu) 09:31:54
    '備　考：
    Private Sub chkForign_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkForign0.CheckedChanged,chkForign1.CheckedChanged

        Dim llngAns             As Integer  'ﾒｯｾｰｼﾞ表示の結果格納

        Try

            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞTrueなら終了
            If mblnChkForignClick_CancelFlag = True Then
                Exit Sub
            End If
            
            '@編集中の場合は内容が初期化されるのでﾒｯｾｰｼﾞを表示する
            If mblnInEditKbn = True Then
                        
                '@送品待ち選択状態か
                If optLotSendStatus0.Checked = True Then
                
                    '@表示ﾒｯｾｰｼﾞ変換 "<TRM3PI>$$送品設定中です。 内容を破棄してよろしいですか？"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003P)
                Else
                
                    '@表示ﾒｯｾｰｼﾞ変換 "<TRM3QI>$$送品取消・帳票印刷選択中です。 内容を破棄してよろしいですか？"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003Q)
                End If
               
                '@ﾒｯｾｰｼﾞ表示
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                
                '@要求確認
                If llngAns = vbNo Then
                    
                    '@「いいえ」の場合、変わったチェックを元に戻す
          
                    '@設定値がONならOFF（OFFならON)
                    mblnChkForignClick_CancelFlag = True
                    If sender.Checked = CMlngChkON Then
                        sender.Checked = CMlngChkOFF
                    Else
                        sender.Checked = CMlngChkON
                    End If
                    mblnChkForignClick_CancelFlag = False
                    
                    '@ﾌｫｰｶｽをｸﾞﾘｯﾄﾞに戻す
                    If vsfLotListSend.Enabled = True Then
                        Call pubSetFocus(vsfLotListSend)
                    End If
                    
                    Exit Sub
                    
                Else
                
                    '@編集中ﾌﾗｸﾞをﾘｾｯﾄ(破棄する場合)
                    mblnInEditKbn = False

                End If
                
            End If
            
            '@国内か海外かで処理を分岐
            Select Case sender.Name
            
                '@国内の場合
                Case chkForign0.Name
            
                    '@設定値が0なら海外をON
                    If chkForign0.Checked = CMlngChkOFF Then
                        mblnChkForignClick_CancelFlag = True
                        chkForign1.Checked = CMlngChkON
                        mblnChkForignClick_CancelFlag = False
                    End If
                    
                '@海外の場合
                Case chkForign1.Name 
                
                    '@設定値が0なら国内をON
                    If chkForign1.Checked = CMlngChkOFF Then
                        mblnChkForignClick_CancelFlag = True
                        chkForign0.Checked = CMlngChkON
                        mblnChkForignClick_CancelFlag = False
                    End If
                    
            End Select
                
            '@取得済みﾃﾞｰﾀはあるか
            If mlngStockListCnt <> 0 Then
            
                '@送品待ちﾁｪｯｸONか
                If optLotSendStatus0.Checked = True Then
                    '@ﾘｽﾄ再表示(送品待ち)
                    Call prvvsfLotListSend_Disp(mtypstocklotlist, mlngStockListCnt)
                Else
                    '@ﾘｽﾄ再表示(送品済み)
                    Call prvvsfLotListSend2_Disp(mtypstocklotlist, mlngStockListCnt)
                End If
                
            End If
            
            '@ﾎﾞﾀﾝの有効/無効
            With vsfLotListSend
                '@選択行がﾀｲﾄﾙの場合
                If .Row = 0 Then
                    cmdSendWFInfo.Enabled = False           'WF情報(完成在庫)
                    cmdHoldSend.Enabled = False             '保留(完成在庫)
                    cmdCancelSend.Enabled = False           '保留解除(完成在庫)
                    cmdWFSend.Enabled = False               '在庫払出(完成在庫)
                    cmdCommentSend.Enabled = False          'ロットコメント(完成在庫)
                    cmdNextCommentSend.Enabled = False      '次SB連絡登録(完成在庫)
                    cmdSendOrderList.Enabled = False        '送品伝票印刷(完成在庫)
                    cmdLotExamInfo.Enabled = False          'ロット検定表印刷(完成在庫)
                    cmdSendRegist.Enabled = False           '送品(完成在庫)
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "chkForign_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvfrmxxEN00F0_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 13:16:07 S.Deguchi
    '更新日：2009/02/25 (Wed) 19:47:15 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 12:09:55 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/12/06 (Mon) 10:15:59 S.Deguchi    CF完成在庫のTab追加による処理を追加
    '　　　：2004/12/06 (Mon) 17:54:02 H.Wajima     不具合修正
    '　　　：2005/02/04 (Fri) 10:42:17 S.Deguchi    不具合№471対応でﾃｷｽﾄﾎﾞｯｸｽ(元ﾛｯﾄID)の初期化処理を追加
    '　　　：2005/08/01 (Mon) 12:12:56 N.Kasai      L/Rﾗﾍﾞﾙ初期化追加
    '　　　：2005/09/05 (Mon) 18:08:29 N.Kojima     「WF情報表示」ﾎﾞﾀﾝの無効化、構造体初期化処理追記。(不具合№3047)
    '　　　：2009/02/25 (Wed) 19:47:15 N.Kojima     ﾁｯﾌﾟ品判別説明ﾗﾍﾞﾙの制御処理追加。(案件№03402)
    Private Sub prvfrmxxEN00F0_Init()

        Dim ltypInvLotList      As InvLotListAns    '中間在庫格納構造体
        Dim lstrFormTitle       As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00F0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@中間在庫格納構造体をｸﾘｱ
            mtypInvLotList = ltypInvLotList
            
            '@ﾛｯﾄ情報詳細構造体の初期化
            If mtypLotDetailInfo.typDivideLot2 Is Nothing Then
                mtypLotDetailInfo.typDivideLot2 = New List(Of DivideLot2)
            Else
                mtypLotDetailInfo.typDivideLot2.Clear
            End If
            mtypLotDetailInfo.lngDivideLot2Cnt = 0
            
            If pstrSBID = CPstrSBID2A0 Then
                '@ﾛｯﾄ受入在庫を初期表示とする
                tabControl.SelectedTab = Tab0
                
                '@保留在庫
                lblTitleHoldL.BackColor = ColorTranslator.FromWin32(CPlngLColor)
                lblTitleHoldR.BackColor = ColorTranslator.FromWin32(CPlngRColor)
                lblTitleHoldL.Visible = True
                lblTitleHoldR.Visible = True
                lblTitleHoldChip.Visible = True             'ﾁｯﾌﾟ品説明
                
                '@完成在庫
                lblTitleSendL.BackColor = ColorTranslator.FromWin32(CPlngLColor)
                lblTitleSendR.BackColor = ColorTranslator.FromWin32(CPlngRColor)
                lblTitleSendL.Visible = True
                lblTitleSendR.Visible = True
                lblTitleSendChip.Visible = True             'ﾁｯﾌﾟ品説明
                
                '@CF完成在庫
                lblTitleCfEndL.BackColor = ColorTranslator.FromWin32(CPlngLColor)
                lblTitleCfEndR.BackColor = ColorTranslator.FromWin32(CPlngRColor)
                lblTitleCfEndL.Visible = True
                lblTitleCfEndR.Visible = True
            Else
                '@受入在庫を使用不可にする
                Tab0.Enabled = False
                tabControl.TabPages.Remove(Tab0)
                
                '@CF完成在庫を使用不可にする
                Tab4.Enabled = False
                tabControl.TabPages.Remove(Tab4)
                '@ﾛｯﾄ保管在庫を初期表示とする
                tabControl.SelectedTab = Tab1
                
                '@保留在庫
                lblTitleHoldL.Visible = False
                lblTitleHoldR.Visible = False
                lblTitleHoldChip.Visible = False        'ﾁｯﾌﾟ品説明
                
                '@完成在庫
                lblTitleSendL.Visible = False
                lblTitleSendR.Visible = False
                lblTitleSendChip.Visible = False        'ﾁｯﾌﾟ品説明
                
                '@CF完成在庫
                lblTitleCfEndL.Visible = False
                lblTitleCfEndR.Visible = False
            End If
            
            mblnNowListWFFlag = False               '中間WF在庫TAB最新取得処理中ﾌﾗｸﾞの初期化
            
            '@退避領域の初期化
            If IsNothing(mtypProductList) Then                 '機種
                mtypProductList = New List(Of ProductList)()
            Else
                mtypProductList.Clear()
            End If
            If IsNothing(mtypDivisionList) Then                '種別
                mtypDivisionList = New List(Of DivisionList)()
            Else
                mtypDivisionList.Clear()
            End If
            If IsNothing(mtypProductList2) Then                 '機種
                mtypProductList2 = New List(Of ProductList)()
            Else
                mtypProductList2.Clear()
            End If
            If IsNothing(mtypDivisionList2) Then                '種別
                mtypDivisionList2 = New List(Of DivisionList)()
            Else
                mtypDivisionList2.Clear()
            End If
            If IsNothing(mtypProductList3) Then                 '機種
                mtypProductList3 = New List(Of ProductList)()
            Else
                mtypProductList3.Clear()
            End If
            If IsNothing(mtypDivisionList3) Then                '種別
                mtypDivisionList3 = New List(Of DivisionList)()
            Else
                mtypDivisionList3.Clear()
            End If
            If IsNothing(mtypProductList4) Then                 '機種
                mtypProductList4 = New List(Of ProductList)()
            Else
                mtypProductList4.Clear()
            End If
            
            mstrCarrierID = vbNullString            '退避ｷｬﾘｱID
            
            '@各Comboﾎﾞｯｸｽの初期化
            cmbProductPut.Clear                     '受入在庫-機種
            cmbProductSend.Clear                    '完成在庫-機種
            cmbProductCFEnd.Clear                   'CF完成在庫-機種
            
            cmbDivisionPut.Clear                    '受入在庫-種別
            cmbDivisionHold.Clear                   '保管在庫-種別
            cmbDivisionSend.Clear                   '完成在庫-種別
            
            cmbDivisionPut.Enabled = False          '受入在庫-種別
            cmbDivisionHold.Enabled = False         '保管在庫-種別
            cmbDivisionSend.Enabled = False         '完成在庫-種別
            
            '@各ﾗﾍﾞﾙの初期化
            lblLotCntPut.Text = vbNullString     '受入在庫-該当件数
            lblLotCntHold.Text = vbNullString    '保管在庫-該当件数
            lblLotCntWF.Text = vbNullString      '中間在庫-該当件数
            lblLotCntSend.Text = vbNullString    '完成在庫-該当件数
            lblLotCntCFEnd.Text = vbNullString   'CF完成在庫-該当件数
            
            lblNowDatePut.Text = vbNullString    '受入在庫-取得時間
            lblNowDateHold.Text = vbNullString   '保管在庫-取得時間
            lblNowDateWF.Text = vbNullString     '中間在庫-取得時間
            lblNowDateSend.Text = vbNullString   '完成在庫-取得時間
            lblNowDateCFEnd.Text = vbNullString  'CF完成在庫-取得時間
            
            '@各Commandﾎﾞﾀﾝの初期化(非活性化)
            '@共通画面ﾎﾞﾀﾝ
            cmdCopy.Enabled = False                 'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
            
            '@受入在庫Tab
            cmdPartition.Enabled = False            '分割
            cmdHoldPut.Enabled = False              '受入在庫-保留
            cmdCancelPut.Enabled = False            '受入在庫-保留解除
            cmdWFPut.Enabled = False                '受入在庫-数量増減(払出)
            cmdCommentPut.Enabled = False           '受入在庫-ｺﾒﾝﾄ表示
            cmdNowListPut.Enabled = False           '受入在庫-最新取得
            cmdPreCommentSend.Enabled = False       '受入在庫-前SB連絡表示
            cmdPutWFInfo.Enabled = False            '受入在庫-WF情報表示
            
            '@保留/保管ﾛｯﾄ在庫Tab
            cmdHoldHold.Enabled = False             '保管在庫-保留
            cmdCancelHold.Enabled = False           '保管在庫-保留解除
            cmdWFHold.Enabled = False               '保管在庫-数量増減(払出)
            cmdCommentHold.Enabled = False          '保管在庫-ｺﾒﾝﾄ表示
            cmdNowListHold.Enabled = False          '保管在庫-最新取得
            cmdHoldWFInfo.Enabled = False           '保管在庫-WF情報表示
            
            '@中間在庫Tab
            cmdCarrierM.Enabled = False             '中間在庫-ｷｬﾘｱﾒﾝﾃﾅﾝｽ
            cmdNowListWF.Enabled = False            '中間在庫-最新取得
            cmdMiddleWFInfo.Enabled = False         '中間在庫-WF情報表示
            
            '@完成在庫(送品待ち)Tab
            cmdHoldSend.Enabled = False             '完成在庫-保留
            cmdCancelSend.Enabled = False           '完成在庫-保留解除
            cmdWFSend.Enabled = False               '完成在庫-数量増減(払出)
            cmdCommentSend.Enabled = False          '完成在庫-ｺﾒﾝﾄ表示
            cmdNowListSend.Enabled = False          '完成在庫-最新取得
            cmdNextCommentSend.Enabled = False      '完成在庫-次SB連絡表示
            cmdSendRegist.Enabled = False           '完成在庫-送品
            cmdSendWFInfo.Enabled = False           '完成在庫-WF情報表示
            
            '@処理区分設定
            optLotSendStatus0.Checked = True        '送品待ち選択
            optLotSendStatus0.Enabled = True        '送品待ちｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optLotSendStatus1.Enabled = True        '送品済みｵﾌﾟｼｮﾝﾎﾞﾀﾝ

            '@CF完成在庫Tab
            cmdHoldCFEnd.Enabled = False            'CF完成在庫-保留
            cmdCancelCFEnd.Enabled = False          'CF完成在庫-保留解除
            cmdCFEnd.Enabled = False                'CF完成在庫-数量増減(払出)
            cmdRework.Enabled = False               'CF完成在庫-ﾘﾜｰｸ
            cmdCommentCFEnd.Enabled = False         'CF完成在庫-ｺﾒﾝﾄ表示
            cmdNowListCFEnd.Enabled = False         'CF完成在庫-最新取得
            cmdCFEndWFInfo.Enabled = False          'CF完成在庫-WF情報表示
            
            '@各vsfｸﾞﾘｯﾄﾞの初期化
            Call prvvsfLotListPut_Init              '受入在庫一覧
            Call prvvsfLotListHold_Init             '保管在庫一覧
            Call prvvsfLotListWF_Init               '中間在庫一覧
            Call prvvsfCarrierInfo_Init             'ｷｬﾘｱ情報一覧
            Call prvvsfLotListSend_Init             '完成在庫一覧
            Call prvvsfLotlistCFEnd_Init            'CF完成在庫一覧
            
            '@ｶﾚﾝﾀﾞｰ設定
            With calFromDate
                .CalendarHeight = CPlngMClHeight                    '高さ
                .CalendarWidth = CPlngMClWidth                      '幅
                .DayFont = New Font(.DayFont.FontFamily, CPlngMClFontSize, .DayFont.Style, .DayFont.Unit)                     'ﾌｫﾝﾄｻｲｽﾞ
                .TitleFont = New Font(.TitleFont.FontFamily, CPlngMClTlFontSize, .TitleFont.Style, .TitleFont.Unit)               'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CPlngMClGridFontSize, .GridFont.Style, .GridFont.Unit)               'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
            End With
            
            With calToDate
                .CalendarHeight = CPlngMClHeight                    '高さ
                .CalendarWidth = CPlngMClWidth                      '幅
                .DayFont = New Font(.DayFont.FontFamily, CPlngMClFontSize, .DayFont.Style, .DayFont.Unit)                     'ﾌｫﾝﾄｻｲｽﾞ
                .TitleFont = New Font(.TitleFont.FontFamily, CPlngMClTlFontSize, .TitleFont.Style, .TitleFont.Unit)               'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CPlngMClGridFontSize, .GridFont.Style, .GridFont.Unit)               'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
            End With
            
            '@ﾃｷｽﾄﾎﾞｯｸｽ設定
            txtLotID.Text = vbNullString                            '元ﾛｯﾄID
            
            '@完成在庫-(送品編集中ﾌﾗｸﾞ)の初期化
            mblnInEditKbn = False
            
            '@中間在庫-(初回区分)初回設定
            mblnSyokaiKbn = True

            '@ﾀﾌﾞ区切り指定
            If pstrSBID <> CPstrSBID2A0 Then
                tabControl.ItemSize = New Size((tabControl.Width - 5) / CMlngNumOfTabs1A0, tabControl.ItemSize.Height)
            End If
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00F0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotListPut_Init
    '機　能：ﾛｯﾄ受入在庫一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 16:27:42 S.Deguchi
    '更新日：2016/02/08 (Mon) 23:16:05 H.Hayashi
    '備　考：
    '　　　：2004/10/06 (Wed) 16:37:43 S.Deguchi    分割のｶﾗﾑを追加(非表示)
    '　　　：2004/10/13 (Wed) 16:37:43 S.Deguchi    ｽﾛｯﾄｻｲｽﾞを追加
    '　　　：2004/12/06 (Mon) 12:57:06 S.Deguchi    移載先ｷｬﾘｱID欄を追加
    '　　　：2005/01/13 (Thu) 14:14:04 S.Deguchi    WF移載ﾌﾗｸﾞ欄を追加
    '　　　：2005/11/21 (Mon) 14:17:49 S.Deguchi    技術担当者ID欄追加
    '　　　：2008/06/04 (Wed) 12:39:24 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Private Sub prvvsfLotListPut_Init()

        Try

            With vsfLotListPut
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@固定列の設定
                .Cols.Frozen = CMlngSendFrozenCols

                .SelectionMode = SelectionModeEnum.Row
                
                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfRowTitle, CMlngvsfPutColNo, CMlngvsfRowTitle, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                                             '文字色
                headerStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                                              '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)       'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               '文字位置
                cellRange.Style = headerStyle

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColNo, CMstrvsfPutColNo)                                'No.
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColKb, CMstrvsfPutColKb)                                '「保」表示
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColDivideStatus, CMstrvsfPutColDivideStatus)            '分割状態
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColEntryTime, CMstrvsfPutColEntryTime)                  '受入日
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColCarrierID, CMstrvsfPutColCarrierID)                  'ｷｬﾘｱID
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColLotID, CMstrvsfPutColLotID)                          'ﾛｯﾄID
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColGrbClass, CMstrvsfPutColGrbClass)                    'GRB区分
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColFlowClass, CMstrvsfPutColFlowClass)                  '種別
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColPriority, CMstrvsfPutColPriority)                    '優先度
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColPDName, CMstrvsfPutColPDName)                        '機種名
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColWfNum, CMstrvsfPutColWfNum)                          'WF
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColCfNum, CMstrvsfPutColCfNum)                          'ﾁｯﾌﾟ
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColLostChipInfo, CMstrvsfPutColLostChipInfo)            '欠損ﾁｯﾌﾟ情報
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColStayTime, CMstrvsfPutColStayTime)                    '停滞時間
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColToCarrierID1, CMstrvsfPutColToCarrierID1)            '移載先ｷｬﾘｱID1
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColToCarrierID2, CMstrvsfPutColToCarrierID2)            '移載先ｷｬﾘｱID2
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColHoldFlag, CMstrvsfPutColHoldFlag)                    '保留ﾌﾗｸﾞ
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColHoldTime, CMstrvsfPutColHoldTime)                    '保留開始日
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColHoldTermDate, CMstrvsfPutColHoldTermDate)            '保留期限
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColHoldStayDate, CMstrvsfPutColHoldStayDate)            '保留期間
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColHoldEmpID, CMstrvsfPutColHoldEmpID)                  '保留担当者ID
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColHoldEmpName, CMstrvsfPutColHoldEmpName)              '保留担当者
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColHoldReasonCode, CMstrvsfPutColHoldReasonCode)        '保留理由ID
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColHoldReasonName, CMstrvsfPutColHoldReasonName)        '保留理由
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColLotComments, CMstrvsfPutColLotComments)              'ｺﾒﾝﾄ内容
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColLotCommentDisp, CMstrvsfPutColLotCommentDisp)        'ｺﾒﾝﾄ有無
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColInvComments, CMstrvsfPutColInvComments)              '次SB連絡
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColInvCommentDisp, CMstrvsfPutColInvCommentDisp)        '次SB連絡有無
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColEngEmpID, CMstrvsfPutColEngEmpID)                    'ﾛｯﾄ担当者ID
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColEngEmpName, CMstrvsfPutColEngEmpName)                'ﾛｯﾄ担当者名
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColWfCarryFlag, CMstrvsfPutColWfCarryFlag)              'WF移載ﾌﾗｸﾞ
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColSlotSize, CMstrvsfPutColSlotSize)                    'ｽﾛｯﾄｻｲｽﾞ
                .SetData(CMlngVsfRowTitle, CMlngvsfPutColLastUpdate, CMstrvsfPutColLastUpdate)                '最終更新日時

                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSortPutTab.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfPutColNo).Width = CMlngvsfPutWColNo                                 'No.
                    .Cols(CMlngvsfPutColKb).Width = CMlngvsfPutWColKb                                 '保留区分
                    .Cols(CMlngvsfPutColDivideStatus).Width = CMlngvsfPutWColDivideStatus             '分割状態
                    .Cols(CMlngvsfPutColEntryTime).Width = CMlngvsfPutWColEntryTime                   '受入日
                    .Cols(CMlngvsfPutColCarrierID).Width = CMlngvsfPutWColCarrierID                   'ｷｬﾘｱID
                    .Cols(CMlngvsfPutColLotID).Width = CMlngvsfPutWColLotID                           'ﾛｯﾄID
                    .Cols(CMlngvsfPutColGrbClass).Width = CMlngvsfPutWColGrbClass                     'GRB区分
                    .Cols(CMlngvsfPutColFlowClass).Width = CMlngvsfPutWColFlowClass                   '種別
                    .Cols(CMlngvsfPutColPriority).Width = CMlngvsfPutWColPriority                     '優先度
                    .Cols(CMlngvsfPutColPDName).Width = CMlngvsfPutWColPDName                         '機種名
                    .Cols(CMlngvsfPutColWfNum).Width = CMlngvsfPutWColWfNum                           'WF
                    .Cols(CMlngvsfPutColCfNum).Width = CMlngvsfPutWColCfNum                           'ﾁｯﾌﾟ
                    .Cols(CMlngvsfPutColLostChipInfo).Width = CMlngvsfPutWColLostChipInfo             '欠損ﾁｯﾌﾟ情報
                    .Cols(CMlngvsfPutColStayTime).Width = CMlngvsfPutWColStayTime                     '停滞時間
                    .Cols(CMlngvsfPutColToCarrierID1).Width = CMlngvsfPutWColToCarrierID1             '移載先ｷｬﾘｱID1
                    .Cols(CMlngvsfPutColToCarrierID2).Width = CMlngvsfPutWColToCarrierID2             '移載先ｷｬﾘｱID2
                    .Cols(CMlngvsfPutColHoldFlag).Width = CMlngvsfPutWColHoldFlag                     '保留ﾌﾗｸﾞ
                    .Cols(CMlngvsfPutColHoldTime).Width = CMlngvsfPutWColHoldTime                     '保留開始日
                    .Cols(CMlngvsfPutColHoldTermDate).Width = CMlngvsfPutWColHoldTermDate             '保留期限
                    .Cols(CMlngvsfPutColHoldStayDate).Width = CMlngvsfPutWColHoldStayDate             '保留期間
                    .Cols(CMlngvsfPutColHoldEmpID).Width = CMlngvsfPutWColHoldEmpID                   '保留担当者ID
                    .Cols(CMlngvsfPutColHoldEmpName).Width = CMlngvsfPutWColHoldEmpName               '保留担当者
                    .Cols(CMlngvsfPutColHoldReasonCode).Width = CMlngvsfPutWColHoldReasonCode         '保留理由
                    .Cols(CMlngvsfPutColHoldReasonName).Width = CMlngvsfPutWColHoldReasonName         '保留理由
                    .Cols(CMlngvsfPutColLotComments).Width = CMlngvsfPutWColLotComments               'ｺﾒﾝﾄ内容
                    .Cols(CMlngvsfPutColLotCommentDisp).Width = CMlngvsfPutWColLotCommentDisp         'ｺﾒﾝﾄ有無
                    .Cols(CMlngvsfPutColInvComments).Width = CMlngvsfPutWColInvComments               'SB連絡ｺﾒﾝﾄ内容
                    .Cols(CMlngvsfPutColInvCommentDisp).Width = CMlngvsfPutWColInvCommentDisp         'SB連絡ｺﾒﾝﾄ有無
                    .Cols(CMlngvsfPutColEngEmpID).Width = CMlngvsfPutWColEngEmpID                     'ﾛｯﾄ担当者ID
                    .Cols(CMlngvsfPutColEngEmpName).Width = CMlngvsfPutWColEngEmpName                 'ﾛｯﾄ担当者名
                    .Cols(CMlngvsfPutColWfCarryFlag).Width = CMlngvsfPutWColWfCarryFlag               'WF移載ﾌﾗｸﾞ
                    .Cols(CMlngvsfPutColSlotSize).Width = CMlngvsfPutWColSlotSize                     'ｽﾛｯﾄｻｲｽﾞ
                    .Cols(CMlngvsfPutColLastUpdate).Width = CMlngvsfPutWColLastUpdate                 '最終更新日時

                End If

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight      '高さ
                
                '@非表示設定
                .Cols(CMlngvsfPutColDivideStatus).Visible = False       '分割状態
                .Cols(CMlngvsfPutColHoldFlag).Visible = False           '保留ﾌﾗｸﾞ
                .Cols(CMlngvsfPutColHoldEmpID).Visible = False          '保留担当者ID
                .Cols(CMlngvsfPutColHoldReasonCode).Visible = False     '保留理由ID
                .Cols(CMlngvsfPutColLotComments).Visible = False        'ｺﾒﾝﾄ内容
                .Cols(CMlngvsfPutColInvComments).Visible = False        'SB連絡ｺﾒﾝﾄ内容
                .Cols(CMlngvsfPutColEngEmpID).Visible = False           'ﾛｯﾄ担当者ID
                .Cols(CMlngvsfPutColEngEmpName).Visible = False         'ﾛｯﾄ担当者名
                .Cols(CMlngvsfPutColWfCarryFlag).Visible = False        'WF移載ﾌﾗｸﾞ
                .Cols(CMlngvsfPutColSlotSize).Visible = False           'ｽﾛｯﾄｻｲｽﾞ
                .Cols(CMlngvsfPutColLastUpdate).Visible = False         '最終更新日時

                '@ﾛｯｸ
                .Enabled = False
                
                '@行列のﾏｳｽでの変更を可にする
                .AllowResizing = AllowResizingEnum.Columns
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light


            End With
            
            '@該当件数のｸﾘｱ
            lblLotCntPut.Text = 0
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListPut_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotListPut_Disp
    '機　能：受入在庫一覧取得
    '引　数：ltypInvActptLotList：受入在庫構造体
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 18:27:50 S.Deguchi
    '更新日：2016/02/08 (Mon) 23:16:56 H.Hayashi
    '備　考：
    '　　　：2004/09/22 (Wed) 09:58:00 S.Deguchi    ｺﾒﾝﾄ表示をｸﾗｲｱﾝﾄでありなし表示へ変換
    '　　　：2004/09/26 (Sun) 09:20:49 S.Deguchi    ｺﾒﾝﾄ表示をｸﾗｲｱﾝﾄであり/Null表示へ変換
    '　　　：2004/10/06 (Wed) 13:09:57 S.Deguchi    分割移載予約状況の表示処理を追加
    '　　　：2004/10/20 (Wed) 14:38:21 Y.Yamagishi  分割予約時の『予』の文字列を『分』に変更
    '　　　：2004/11/02 (Tue) 11:06:25 N.Kasai      移載中ﾌﾗｸﾞ判定追加
    '　　　：2004/12/22 (Wed) 15:02:22 S.Deguchi    移載の分割予約状態ﾌﾗｸﾞの処理を修正(不具合改善№200)
    '　　　：2005/03/24 (Thu) 08:56:54 S.Deguchi    描画制御修正
    '　　　：2005/11/21 (Mon) 14:17:49 S.Deguchi    技術担当者ID追加
    '　　　：2008/06/04 (Wed) 12:41:54 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/07/07 (Mon) 12:00:00 S.Ochiai     欠損ﾁｯﾌﾟ表示対応(No.03046)及びSource整備
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Private Sub prvvsfLotListPut_Disp(ByRef ltypInvAcptLotListAns As InvAcptLotListAns, _
                                      ByVal llngInvAcptLotListCnt As Integer)

        Dim llngDoCnt   As Integer  'ｶｳﾝﾄ
        Dim lstrTemp    As String   '一時取得
        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try
            
            If llngInvAcptLotListCnt <> 0 Then
                '@格納ﾃﾞｰﾀがあるの場合

                With vsfLotListPut
                
                    '@描画ﾛｯｸ
                    .Redraw = False
                    
                    RemoveHandler vsfLotListPut.BeforeRowColChange,AddressOf vsfLotListPut_BeforeRowColChange
                    RemoveHandler vsfLotListPut.EnterCell,AddressOf vsfLotListPut_EnterCell

                    .Row = -1

                    '@行数初期化(ｸﾞﾘｯﾄﾞの初期化)
                    .Rows.Count = .Rows.Fixed
                    .Col = 0

                    '@行数設定
                    .Rows.Count = llngInvAcptLotListCnt + 1
                    
                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 1
                    
                    '@ﾛｯﾄ一覧表示情報設定
                    Do While .Rows.Count > llngDoCnt
                    
                        '@下記, IF分岐を冗長に記載しているが, わかりにくくならないようにｶﾗﾑの順番に記載
                        '@しているので, 追加/変更時は注意の事
                    
                        .SetData(llngDoCnt, CMlngvsfPutColNo, llngDoCnt)                                          '№

                        '@---------------------------------------------------------------------
                        '@ﾌﾗｸﾞ判定について
                        '@  DIVIDE_STATUS:分割予約状態(0:予約なし 1:予約中 2:移載完了)
                        '@  WF_CARRY_FLAG:WF移載ﾌﾗｸﾞ(0:移載なし　1:移載中)払出しを行った場合にON
                        '@  組立分割中の場合はDivideStatus = "1" and WfCarryFlag = "1"
                        '@  払出→移載中の場合はDivideStatus = "0" and WfCarryFlag = "1"
                        '@  組立分割の移載が完了した場合はDivideStatus = "2" and WfCarryFlag = "0"
                        '@  払出し移載が完了した場合はDivideStatus = "0" and WfCarryFlag = "0"
                        '@---------------------------------------------------------------------
                        '@分割状態ﾌﾗｸﾞが"1:分割中"の場合は, "分"を表示
                        '@分割状態ﾌﾗｸﾞが"3:移載中"の場合は, "移"を表示
                        If ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strDivideStatus = CMstrDevideStatusFlag1 Then
                            .SetData(llngDoCnt, CMlngvsfPutColKb, CMstrBun)
                        ElseIf ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strDivideStatus = CMstrDevideStatusFlag3 Then
                            .SetData(llngDoCnt, CMlngvsfPutColKb, CMstrIsai)                                      '移
                        End If
                        
                        '@保留の場合は"保"を表示 ("移"/"分"に追記して表示)
                        If ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strLotHoldFlag = CPstrHold1 Then
                            .SetData(llngDoCnt, CMlngvsfPutColKb, _
                                pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfPutColKb), CMstrHo))                   '保
                        End If
                        
                        .SetData(llngDoCnt, CMlngvsfPutColDivideStatus, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strDivideStatus)                                         '分割/移載状態
                        
                        If IsDate(ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strEntryTime) Then                                 '保留開始日                            '受入日
                            .SetData(llngDoCnt, CMlngvsfPutColEntryTime, _
                                Format$(CDate(ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strEntryTime), CPstrDateFormatMDHM))   
                        Else
                            .SetData(llngDoCnt, CMlngvsfPutColEntryTime, _
                                ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strEntryTime)
                        End If

                        .SetData(llngDoCnt, CMlngvsfPutColCarrierID, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strCarrierId)                                            'ｷｬﾘｱID
                        
                        .SetData(llngDoCnt, CMlngvsfPutColLotID, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strLotID)                                                'ﾛｯﾄID
                                                           
                        .SetData(llngDoCnt, CMlngvsfPutColGrbClass, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strGrbClass)                                             'GRB区分

                        .SetData(llngDoCnt, CMlngvsfPutColFlowClass, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strFlowClass)                                            '流動区分
                            
                        .SetData(llngDoCnt, CMlngvsfPutColPriority, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strLotPriority)                                          '優先度
                        
                        .SetData(llngDoCnt, CMlngvsfPutColPDName, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strPdId)                                                 '機種
                        
                        .SetData(llngDoCnt, CMlngvsfPutColWfNum, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strWFQuantity)                                           'WF枚数
                        
                        If IsNumeric(ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strChipQuantity) Then
                            .SetData(llngDoCnt, CMlngvsfPutColCfNum, _
                                Format$(CInt(ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strChipQuantity), CPstrDateFormatKanma))      'CHIP枚数
                        Else
                            .SetData(llngDoCnt, CMlngvsfPutColCfNum, _
                                ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strChipQuantity)     
                        End If

                        .SetData(llngDoCnt, CMlngvsfPutColLostChipInfo, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strLostChipInfo)                                         '欠損ﾁｯﾌﾟ
                        
                        '@ﾌｫｰﾏｯﾄ変更
                        lstrTemp = Mid(ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strStayTime, _
                                       CMlngFormatStart, CMlngFormatMid9)
                        .SetData(llngDoCnt, CMlngvsfPutColStayTime, lstrTemp)                                                       '停滞時間
                        
                        .SetData(llngDoCnt, CMlngvsfPutColToCarrierID1, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strToCarrierID1)                                         '移載先ｷｬﾘｱID1
                        
                        .SetData(llngDoCnt, CMlngvsfPutColToCarrierID2, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strToCarrierID2)                                         '移載先ｷｬﾘｱID2
                        
                        .SetData(llngDoCnt, CMlngvsfPutColHoldFlag, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strLotHoldFlag)                                          '保留ﾌﾗｸﾞ
                        
                        '@保留中の場合, 保留情報をｾｯﾄ
                        If ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strLotHoldFlag = CPstrHold1 Then

                            If IsDate(ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strHoldTime) Then                              '保留開始日
                                .SetData(llngDoCnt, CMlngvsfPutColHoldTime, _
                                    Format$(CDate(ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strHoldTime), CPstrDateTimeYMD))          
                            Else
                                .SetData(llngDoCnt, CMlngvsfPutColHoldTime, _
                                    ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strHoldTime)
                            End If

                            If IsDate(ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strHoldTermDate) Then                          '保留期限
                                .SetData(llngDoCnt, CMlngvsfPutColHoldTermDate, _
                                    Format$(CDate(ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strHoldTermDate), CPstrDateTimeYMD))  
                            Else
                                .SetData(llngDoCnt, CMlngvsfPutColHoldTermDate, _
                                    ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strHoldTermDate)
                            End If

                            lstrTemp = Mid(ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strHoldStayDate, _
                                           CMlngFormatStart, CMlngFormatMid9)
                            .SetData(llngDoCnt, CMlngvsfPutColHoldStayDate, lstrTemp)                                               '保留期間
                            
                            .SetData(llngDoCnt, CMlngvsfPutColHoldEmpID, _
                                ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strHoldEmpID)                                        '保留担当者ID
                            
                            .SetData(llngDoCnt, CMlngvsfPutColHoldEmpName, _
                                ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strHoldEmpName)                                      '保留担当者
            
                            .SetData(llngDoCnt, CMlngvsfPutColHoldReasonCode, _
                                ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strReasonCode)                                       '保留理由ID
                                
                            .SetData(llngDoCnt, CMlngvsfPutColHoldReasonName, _
                                ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strReasonName)                                       '保留理由
                        End If
                            
                        .SetData(llngDoCnt, CMlngvsfPutColLotComments, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strLotComments)                                          'ﾛｯﾄｺﾒﾝﾄ内容
                        
                        '@ﾛｯﾄｺﾒﾝﾄの有無判定
                        If ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strLotComments <> vbNullString Then
                            .SetData(llngDoCnt, CMlngvsfPutColLotCommentDisp, CPstrAriFlg)                                          'ﾛｯﾄｺﾒﾝﾄ有無
                        End If
                        
                        .SetData(llngDoCnt, CMlngvsfPutColInvComments, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strInvComments)                                          'SB連絡ｺﾒﾝﾄ内容
                        
                        '@SBｺﾒﾝﾄの有無判定
                        If ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strInvComments <> vbNullString Then
                            .SetData(llngDoCnt, CMlngvsfPutColInvCommentDisp, CPstrAriFlg)                                          'SB連絡ｺﾒﾝﾄ有無
                        End If
                        
                        .SetData(llngDoCnt, CMlngvsfPutColEngEmpID, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strEngEmpId)                                             'ﾛｯﾄ担当者ID

                        .SetData(llngDoCnt, CMlngvsfPutColEngEmpName, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strEngEmpName)                                           'ﾛｯﾄ担当者名
                        
                        .SetData(llngDoCnt, CMlngvsfPutColWfCarryFlag, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strWfCarryFlag)                                          'WF移載ﾌﾗｸﾞ
                        
                        .SetData(llngDoCnt, CMlngvsfPutColSlotSize, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strSlotSize)                                             'ｽﾛｯﾄｻｲｽﾞ
                        
                        .SetData(llngDoCnt, CMlngvsfPutColLastUpdate, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strEditTime)                                             '最終更新日時
                            
                        '@ｾﾙ色変更
                        '@ DIVIDE_STATUS = 0(未分割/移載), 1(分割/移載中)
                        '@  → 水色
                        '@ LOT_HOLD_FLAG = 1(保留中)
                        '@  → 黄色
                        '@※保留色優先
                        If ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strDivideStatus <> CMstrDevideStatusFlag2 Then
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngStateNotEditColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngStateNotEditColor)
                            Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        End If
                        
                        If ltypInvAcptLotListAns.typLotList(llngDoCnt -1).strLotHoldFlag = CMstrLotHoldFlgOn Then
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        End If
                        
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height = CMlngVsfHeight
                        
                        '@ｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                    Loop
                        
                     '@ｻｲｽﾞ未変更の場合
                     If mtypChgSortPutTab.blnChgWidth = False Then
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCol(CMlngvsfPutColNo, 6)                '№
                        .AutoSizeCol(CMlngvsfPutColKb, 6)                '「分/移」表示
                        .AutoSizeCol(CMlngvsfPutColDivideStatus, 6)      '分割状態
                        .AutoSizeCol(CMlngvsfPutColEntryTime, 6)         '受入日
                        .AutoSizeCol(CMlngvsfPutColCarrierID, 6)         'ｷｬﾘｱID
                        .AutoSizeCol(CMlngvsfPutColLotID, 6)             'ﾛｯﾄID
                        .AutoSizeCol(CMlngvsfPutColGrbClass, 6)          'GRB区分
                        .AutoSizeCol(CMlngvsfPutColFlowClass, 6)         '種別
                        .AutoSizeCol(CMlngvsfPutColPriority, 6)          '優先度
                        .AutoSizeCol(CMlngvsfPutColPDName, 6)            '機種名
                        .AutoSizeCol(CMlngvsfPutColWfNum, 6)             'WF
                        .AutoSizeCol(CMlngvsfPutColCfNum, 6)             'ﾁｯﾌﾟ
                        .AutoSizeCol(CMlngvsfPutColLostChipInfo, 6)      '欠損ﾁｯﾌﾟ情報
                        .AutoSizeCol(CMlngvsfPutColStayTime, 6)          '停滞時間
                        .AutoSizeCol(CMlngvsfPutColToCarrierID1, 6)      '移載先ｷｬﾘｱID1
                        .AutoSizeCol(CMlngvsfPutColToCarrierID2, 6)      '移載先ｷｬﾘｱID2
                        .AutoSizeCol(CMlngvsfPutColHoldFlag, 6)          '保留ﾌﾗｸﾞ
                        .AutoSizeCol(CMlngvsfPutColHoldTime, 6)          '保留開始日
                        .AutoSizeCol(CMlngvsfPutColHoldTermDate, 6)      '保留期限
                        .AutoSizeCol(CMlngvsfPutColHoldStayDate, 6)      '保留期間
                        .AutoSizeCol(CMlngvsfPutColHoldEmpID, 6)         '保留担当者ID
                        .AutoSizeCol(CMlngvsfPutColHoldEmpName, 6)       '保留担当者
                        .AutoSizeCol(CMlngvsfPutColHoldReasonCode, 6)    '保留理由ID
                        .AutoSizeCol(CMlngvsfPutColHoldReasonName, 6)    '保留理由
                        .AutoSizeCol(CMlngvsfPutColLotComments, 6)       'ｺﾒﾝﾄ内容
                        .AutoSizeCol(CMlngvsfPutColLotCommentDisp, 6)    'ｺﾒﾝﾄ有無
                        .AutoSizeCol(CMlngvsfPutColInvComments, 6)       'SB連絡ｺﾒﾝﾄ内容
                        .AutoSizeCol(CMlngvsfPutColInvCommentDisp, 6)    'SB連絡ｺﾒﾝﾄ有無
                        .AutoSizeCol(CMlngvsfPutColEngEmpID, 6)          'ﾛｯﾄ担当者ID
                        .AutoSizeCol(CMlngvsfPutColEngEmpName, 6)        'ﾛｯﾄ担当者名
                        .AutoSizeCol(CMlngvsfPutColWfCarryFlag, 6)       'WF移載ﾌﾗｸﾞ
                        .AutoSizeCol(CMlngvsfPutColSlotSize, 6)          'ｽﾛｯﾄｻｲｽﾞ
                        .AutoSizeCol(CMlngvsfPutColLastUpdate, 6)        '最終更新日時
                        
                    End If
                    
                    '@書式設定
                    .Cols(CMlngvsfPutColNo).TextAlign = TextAlignEnum.RightCenter                  '№
                    .Cols(CMlngvsfPutColKb).TextAlign = TextAlignEnum.LeftCenter                   '「分/移/保」表示
                    .Cols(CMlngvsfPutColDivideStatus).TextAlign = TextAlignEnum.RightCenter        '分割状態
                    .Cols(CMlngvsfPutColEntryTime).TextAlign = TextAlignEnum.LeftCenter            '受入日
                    .Cols(CMlngvsfPutColCarrierID).TextAlign = TextAlignEnum.LeftCenter            'ｷｬﾘｱID
                    .Cols(CMlngvsfPutColLotID).TextAlign = TextAlignEnum.LeftCenter                'ﾛｯﾄID
                    .Cols(CMlngvsfPutColGrbClass).TextAlign = TextAlignEnum.LeftCenter             'GRB区分
                    .Cols(CMlngvsfPutColFlowClass).TextAlign = TextAlignEnum.LeftCenter            '種別
                    .Cols(CMlngvsfPutColPriority).TextAlign = TextAlignEnum.RightCenter            '優先度
                    .Cols(CMlngvsfPutColPDName).TextAlign = TextAlignEnum.LeftCenter               '機種名
                    .Cols(CMlngvsfPutColWfNum).TextAlign = TextAlignEnum.RightCenter               'WF
                    .Cols(CMlngvsfPutColCfNum).TextAlign = TextAlignEnum.RightCenter               'ﾁｯﾌﾟ
                    .Cols(CMlngvsfPutColLostChipInfo).TextAlign = TextAlignEnum.RightCenter        '欠損ﾁｯﾌﾟ情報
                    .Cols(CMlngvsfPutColStayTime).TextAlign = TextAlignEnum.LeftCenter             '停滞時間
                    .Cols(CMlngvsfPutColToCarrierID1).TextAlign = TextAlignEnum.LeftCenter         '移載先ｷｬﾘｱID1
                    .Cols(CMlngvsfPutColToCarrierID2).TextAlign = TextAlignEnum.LeftCenter         '移載先ｷｬﾘｱID2
                    .Cols(CMlngvsfPutColHoldFlag).TextAlign = TextAlignEnum.RightCenter            '保留ﾌﾗｸﾞ
                    .Cols(CMlngvsfPutColHoldTime).TextAlign = TextAlignEnum.LeftCenter             '保留開始日
                    .Cols(CMlngvsfPutColHoldTermDate).TextAlign = TextAlignEnum.LeftCenter         '保留期限
                    .Cols(CMlngvsfPutColHoldStayDate).TextAlign = TextAlignEnum.LeftCenter         '保留期間
                    .Cols(CMlngvsfPutColHoldEmpID).TextAlign = TextAlignEnum.LeftCenter            '保留担当者ID
                    .Cols(CMlngvsfPutColHoldEmpName).TextAlign = TextAlignEnum.LeftCenter          '保留担当者
                    .Cols(CMlngvsfPutColHoldReasonCode).TextAlign = TextAlignEnum.LeftCenter       '保留理由ID
                    .Cols(CMlngvsfPutColHoldReasonName).TextAlign = TextAlignEnum.LeftCenter       '保留理由
                    .Cols(CMlngvsfPutColLotComments).TextAlign = TextAlignEnum.LeftCenter          'ﾛｯﾄｺﾒﾝﾄ内容
                    .Cols(CMlngvsfPutColLotCommentDisp).TextAlign = TextAlignEnum.LeftCenter       'ﾛｯﾄｺﾒﾝﾄ有無
                    .Cols(CMlngvsfPutColInvComments).TextAlign = TextAlignEnum.LeftCenter          'SB連絡ｺﾒﾝﾄ内容
                    .Cols(CMlngvsfPutColInvCommentDisp).TextAlign = TextAlignEnum.LeftCenter       'SB連絡ｺﾒﾝﾄ有無
                    .Cols(CMlngvsfPutColEngEmpID).TextAlign = TextAlignEnum.LeftCenter             'ﾛｯﾄ担当者ID
                    .Cols(CMlngvsfPutColEngEmpName).TextAlign = TextAlignEnum.LeftCenter           'ﾛｯﾄ担当者ID
                    .Cols(CMlngvsfPutColWfCarryFlag).TextAlign = TextAlignEnum.RightCenter         'WF移載ﾌﾗｸﾞ
                    .Cols(CMlngvsfPutColSlotSize).TextAlign = TextAlignEnum.RightCenter            'ｽﾛｯﾄｻｲｽﾞ
                    .Cols(CMlngvsfPutColLastUpdate).TextAlign = TextAlignEnum.LeftCenter           '最終更新日時
                    
                    '@ﾕｰｻﾞによりsortされている場合
                    If mtypChgSortPutTab.lngCnt > 0 Then
                        '@sort保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSortPutTab.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSortPutTab.typChgSortList(llngCnt).lngCol).Sort = mtypChgSortPutTab.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort, mtypChgSortPutTab.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    AddHandler vsfLotListPut.BeforeRowColChange,AddressOf vsfLotListPut_BeforeRowColChange
                    AddHandler vsfLotListPut.EnterCell,AddressOf vsfLotListPut_EnterCell

                    '@ｿｰﾄ検索用KEY(ﾛｯﾄID)がある場合
                    If mtypChgSortPutTab.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@ﾛｯﾄIDが同じ場合
                            If vsfLotListPut.GetData(llngCnt, CMlngvsfPutColLotID) = mtypChgSortPutTab.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                Call pubVsfBeforeSort(vsfLotListPut, CMlngVsfRowTitle)
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                Call pubVsfAfterSort(vsfLotListPut, CMlngVsfRowTitle,Nothing ,Nothing ,False, False, False, False)
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        .TopRow = 0    '行
                        .Row = 0       'ｶﾚﾝﾄ行の移動
                    End If
                   
                    '@再描画
                    .Redraw = True
                   
                    '@ﾛｯｸ解除
                    .Enabled = True
                    
                    If mblnSetFocus = False Then
                        '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfLotListPut)
                    End If
                End With
            End If

            '@該当件数
            lblLotCntPut.Text = llngInvAcptLotListCnt

            '@現在日時表示
            lblNowDatePut.Text = Format$(Now, CPstrDateFormat)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListPut_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotListHold_Init
    '機　能：保留/保管ﾛｯﾄ在庫一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 16:28:28 S.Deguchi
    '更新日：2008/06/04 (Wed) 13:04:41 N.Kojima
    '備　考：
    '　　　：2004/10/13 (Wed) 16:51:25 S.Deguchi    ｽﾛｯﾄｻｲｽﾞの欄を追加
    '　　　：2005/11/21 (Mon) 14:17:49 S.Deguchi    技術担当者ID欄追加
    '　　　：2008/06/04 (Wed) 13:04:41 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvvsfLotListHold_Init()

        Try

            With vsfLotListHold
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@固定列の設定
                .Cols.Frozen = CMlngvsfHoldColPDName
                
                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfHoldColNo, CMlngVsfRowTitle, CMlngvsfHoldColLotCommentButton)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                                             '文字色
                headerStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                                              '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit) 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               '文字位置
                cellRange.Style = headerStyle

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColNo, CMstrvsfHoldColNo)                                  'No.
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColHoldTime, CMstrvsfHoldColHoldTime)                      '保留開始日
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColHoldTimeEnd, CMstrvsfHoldColHoldTimeEnd)                '保留期限
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColStatus, CMstrvsfHoldColStatus)                          'LOT状態
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColCarrierID, CMstrvsfHoldColCarrierID)                    'ｷｬﾘｱID
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColLotID, CMstrvsfHoldColLotID)                            'ﾛｯﾄID
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColFlowClass, CMstrvsfHoldColFlowClass)                    '種別
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColPDName, CMstrvsfHoldColPDNAME)                          '機種名
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColWfNum, CMstrvsfHoldColWfNum)                            'WF
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColCfNum, CMstrvsfHoldColCfNum)                            'ﾁｯﾌﾟ
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColOpID, CMstrvsfHoldColOpID)                              '大工程
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColStepID, CMstrvsfHoldColStepID)                          '小工程
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColWpID, CMstrvsfHoldColWpID)                              '装置名
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColHoldFlag, CMstrvsfHoldColHoldFlag)                      '保留ﾌﾗｸﾞ
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColHoldStay, CMstrvsfHoldColHoldStay)                      '保留期間
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColHoldReasonID, CMstrvsfHoldColHoldReasonID)              '保留理由ID
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColHoldReason, CMstrvsfHoldColHoldReason)                  '保留理由
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColHoldEmpID, CMstrvsfHoldColHoldEmpID)                    '保留担当者ID
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColHoldEmp, CMstrvsfHoldColHoldEmp)                        '保留担当者
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColEntryID, CMstrvsfHoldColEntryID)                        'ｴﾝﾄﾘ
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColLotManagerName, CMstrvsfHoldColLotManagerName)          'ﾛｯﾄ担当者名
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColLotComments, CMstrvsfHoldColLotComments)                'ｺﾒﾝﾄ内容
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColLastUpdate, CMstrvsfHoldColLastUpdate)                  '最終更新日時
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColLotCommentButton, CMstrvsfHoldColLotCommentButton)      'ｺﾒﾝﾄ
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColSlotSize, CMstrvsfHoldColSlotSize)                      'ｽﾛｯﾄｻｲｽﾞ
                .SetData(CMlngVsfRowTitle, CMlngvsfHoldColLotManagerID, CMstrvsfHoldColLotManagerID)              'ﾛｯﾄ担当者ID
                
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSortHoldTab.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfHoldColNo).Width = CMlngvsfHoldWColNo                                   'No.
                    .Cols(CMlngvsfHoldColHoldTime).Width = CMlngvsfHoldWColHoldTime                       '保留開始日
                    .Cols(CMlngvsfHoldColHoldTimeEnd).Width = CMlngvsfHoldWColHoldTimeEnd                 '保留期限
                    .Cols(CMlngvsfHoldColStatus).Width = CMlngvsfHoldWColStatus                           'LOT状態
                    .Cols(CMlngvsfHoldColCarrierID).Width = CMlngvsfHoldWColCarrierID                     'ｷｬﾘｱID
                    .Cols(CMlngvsfHoldColLotID).Width = CMlngvsfHoldWColLotID                             'ﾛｯﾄID
                    .Cols(CMlngvsfHoldColFlowClass).Width = CMlngvsfHoldWColFlowClass                     '種別
                    .Cols(CMlngvsfHoldColPDName).Width = CMlngvsfHoldWColPDName                           '機種名
                    .Cols(CMlngvsfHoldColWfNum).Width = CMlngvsfHoldWColWfNum                             'WF
                    .Cols(CMlngvsfHoldColCfNum).Width = CMlngvsfHoldWColCfNum                             'ﾁｯﾌﾟ
                    .Cols(CMlngvsfHoldColOpID).Width = CMlngvsfHoldWColOpID                               '大工程
                    .Cols(CMlngvsfHoldColStepID).Width = CMlngvsfHoldWColStepID                           '小工程
                    .Cols(CMlngvsfHoldColWpID).Width = CMlngvsfHoldWColWpID                               '装置名
                    .Cols(CMlngvsfHoldColHoldFlag).Width = CMlngvsfHoldWColHoldFlag                       '保留ﾌﾗｸﾞ
                    .Cols(CMlngvsfHoldColHoldStay).Width = CMlngvsfHoldWColHoldStay                       '保留期間
                    .Cols(CMlngvsfHoldColHoldReasonID).Width = CMlngvsfHoldWColHoldReasonID               '保留理由ID
                    .Cols(CMlngvsfHoldColHoldReason).Width = CMlngvsfHoldWColHoldReason                   '保留理由
                    .Cols(CMlngvsfHoldColHoldEmpID).Width = CMlngvsfHoldWColHoldEmpID                     '保留担当者ID
                    .Cols(CMlngvsfHoldColHoldEmp).Width = CMlngvsfHoldWColHoldEmp                         '保留担当者
                    .Cols(CMlngvsfHoldColEntryID).Width = CMlngvsfHoldWColEntryID                         'ｴﾝﾄﾘ
                    .Cols(CMlngvsfHoldColLotManagerName).Width = CMlngvsfHoldWColLotManagerName           'ﾛｯﾄ担当者名
                    .Cols(CMlngvsfHoldColLotComments).Width = CMlngvsfHoldWColLotComments                 'ｺﾒﾝﾄ内容
                    .Cols(CMlngvsfHoldColLastUpdate).Width = CMlngvsfHoldWColLastUpdate                   '最終更新日時
                    .Cols(CMlngvsfHoldColLotCommentButton).Width = CMlngvsfHoldWColLotCommentButton       'ｺﾒﾝﾄ
                    .Cols(CMlngvsfHoldColSlotSize).Width = CMlngvsfHoldWColSlotSize                       'ｽﾛｯﾄｻｲｽﾞ
                    .Cols(CMlngvsfHoldColLotManagerID).Width = CMlngvsfHoldWColLotManagerID               'ﾛｯﾄ担当者ID
                End If

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight    '高さ
                
                '@非表示設定
                .Cols(CMlngvsfHoldColHoldReasonID).Visible = False  '保留理由ID
                .Cols(CMlngvsfHoldColHoldEmpID).Visible = False     '保留責任者ID
                .Cols(CMlngvsfHoldColHoldFlag).Visible = False      '保留ﾌﾗｸﾞ
                .Cols(CMlngvsfHoldColLotComments).Visible = False   'ｺﾒﾝﾄ内容
                .Cols(CMlngvsfHoldColLastUpdate).Visible = False    '最終更新日時
                .Cols(CMlngvsfHoldColSlotSize).Visible = False      'ｽﾛｯﾄｻｲｽﾞ
                .Cols(CMlngvsfHoldColLotManagerID).Visible = False  'ﾛｯﾄ担当者ID

                '@ﾛｯｸ
                .Enabled = False
                
                '@行列のﾏｳｽでの変更を可にする
                .AllowResizing = AllowResizingEnum.Columns
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light

            End With
            
            '@該当件数のｸﾘｱ
            lblLotCntHold.Text = 0

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListHold_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotListHold_Disp
    '機　能：保管在庫一覧取得
    '引　数：ltypInvActptLotList：保管在庫格納構造体
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 11:11:54 S.Deguchi
    '更新日：2009/12/03 (Thu) 13:18:42 H.Hayashi
    '備　考：
    '　　　：2004/09/20 (Mon) 10:43:29 N.Kasai      保留期限超過の場合は色を変更を追加
    '　　　：2004/09/22 (Wed) 09:58:00 S.Deguchi    ｺﾒﾝﾄ表示をｸﾗｲｱﾝﾄでありなし表示へ変換
    '　　　：2004/09/26 (Sun) 09:20:49 S.Deguchi    ｺﾒﾝﾄ表示をｸﾗｲｱﾝﾄであり/Null表示へ変換
    '　　　：2004/10/13 (Wed) 16:54:15 S.Deguchi    ｽﾛｯﾄｻｲｽﾞ欄を追加
    '　　　：2005/03/24 (Thu) 08:55:55 S.Deguchi    描画制御修正
    '　　　：2005/08/01 (Mon) 10:13:09 N.Kasai      液晶方向(L/R表示)追加
    '　　　：2005/11/21 (Mon) 14:17:49 S.Deguchi    技術担当者ID追加
    '　　　：2007/01/31 (Wed) 11:28:07 N.Kasai      保留ｺﾒﾝﾄ削除(№01714)
    '　　　：2008/06/04 (Wed) 13:07:35 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/02/24 (Tue) 16:34:58 N.Kojima     起動SBが組立、かつ送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。
    '　　　：2009/12/03 (Thu) 13:18:42 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    Private Sub prvvsfLotListHold_Disp(ByRef ltypInvActptLotList As InvAcptLotList)

        Dim llngDoCnt       As Integer      'ｶｳﾝﾄ
        Dim lstrTemp        As String       '一時取得
        Dim llngCnt         As Integer      '汎用ｶｳﾝﾄ
        Dim newStyle        As CellStyle    'NSYS セルスタイル
        Dim cellRange       As CellRange    'NSYS セルレンジ

        Try
            
            With vsfLotListHold
            
                If ltypInvActptLotList.InvAcptLotListCnt <> 0 Then
                    '@格納ﾃﾞｰﾀがあるの場合
                    
                    '@描画ﾛｯｸ
                    .Redraw = False
                    
                    RemoveHandler vsfLotListHold.BeforeRowColChange, AddressOf vsfLotListHold_BeforeRowColChange
                    RemoveHandler vsfLotListHold.EnterCell, AddressOf vsfLotListHold_EnterCell

                    .Row = -1

                    '@行数初期化(グリッドの初期化)
                    .Rows.Count = .Rows.Fixed

                    '@行数設定
                    .Rows.Count = ltypInvActptLotList.InvAcptLotListCnt + 1
                    
                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 1
                    
                    '@ﾛｯﾄ一覧表示情報設定
                    Do While .Rows.Count > llngDoCnt
                        .SetData(llngDoCnt, CMlngvsfHoldColNo, llngDoCnt)                                                       '№
                        
                        If IsDate(ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strRecordTime) Then                           '保留開始日
                            .SetData(llngDoCnt, CMlngvsfHoldColHoldTime, _
                                Format$(CDate(ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strRecordTime), CPstrDateTimeYMD))
                        Else
                            .SetData(llngDoCnt, CMlngvsfHoldColHoldTime, _
                                ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strRecordTime)                                  
                        End If

                        If IsDate(ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strHoldTermDate) Then                         '保留期限
                            .SetData(llngDoCnt, CMlngvsfHoldColHoldTimeEnd, _
                                Format$(CDate(ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strHoldTermDate), CPstrDateTimeYMD))  
                        Else
                            .SetData(llngDoCnt, CMlngvsfHoldColHoldTimeEnd, _
                                ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strHoldTermDate) 
                        End If

                        .SetData(llngDoCnt, CMlngvsfHoldColStatus, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strCurrentStatus)                                   'LOT状態
                            
                        .SetData(llngDoCnt, CMlngvsfHoldColCarrierID, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strCarrierId)                                       'ｷｬﾘｱID
                            
                        .SetData(llngDoCnt, CMlngvsfHoldColLotID, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strLotID)                                           'ﾛｯﾄID
                            
                        .SetData(llngDoCnt, CMlngvsfHoldColFlowClass, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strFlowClass)                                       '種別
                            
                        .SetData(llngDoCnt, CMlngvsfHoldColPDName, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strPdId)                                            '機種名
                            
                        .SetData(llngDoCnt, CMlngvsfHoldColWfNum, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strWFQuantity)                                      'WF
                            
                        If ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strChipQuantity = vbNullString Then                     'ﾁｯﾌﾟ
                            .SetData(llngDoCnt, CMlngvsfHoldColCfNum,"0")
                        Else
                            .SetData(llngDoCnt, CMlngvsfHoldColCfNum, _
                                Format$(CInt(ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strChipQuantity), CPstrDateFormatKanma))
                        End If
                        
                        .SetData(llngDoCnt, CMlngvsfHoldColOpID, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strOpID)                                            '大工程
                            
                        .SetData(llngDoCnt, CMlngvsfHoldColStepID, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strStepID)                                          '小工程
                            
                        .SetData(llngDoCnt, CMlngvsfHoldColWpID, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strWpName)                                          '装置名
                            
                        .SetData(llngDoCnt, CMlngvsfHoldColHoldFlag, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strLotHoldFlg)                                      '保留ﾌﾗｸﾞ
                        
                        '@ﾌｫｰﾏｯﾄ変更
                        lstrTemp = Mid(ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strHoldStayTime, _
                                       CMlngFormatStart, _
                                       CMlngFormatMid9)
                        .SetData(llngDoCnt, CMlngvsfHoldColHoldStay, lstrTemp)                                    '保留期間
                        
                        .SetData(llngDoCnt, CMlngvsfHoldColHoldReasonID, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strReasonCode)                                      '保留理由ID
                            
                        .SetData(llngDoCnt, CMlngvsfHoldColHoldReason, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strReasonName)                                      '保留理由
                            
                        .SetData(llngDoCnt, CMlngvsfHoldColHoldEmpID, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strHoldEmpID)                                       '保留担当者ID
                        
                        .SetData(llngDoCnt, CMlngvsfHoldColHoldEmp, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strHoldEmpName)                                     '保留担当者
                        
                        .SetData(llngDoCnt, CMlngvsfHoldColEntryID, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strEntryID)                                         'ｴﾝﾄﾘ
                            
                        .SetData(llngDoCnt, CMlngvsfHoldColLotManagerName, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strEngEmpName)                                      'ﾛｯﾄ担当者名
                            
                        .SetData(llngDoCnt, CMlngvsfHoldColLotComments, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strComments)                                        'ｺﾒﾝﾄ
                            
                        .SetData(llngDoCnt, CMlngvsfHoldColLastUpdate, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strEditTime)                                        '最終更新日時
                        
                        .SetData(llngDoCnt, CMlngvsfHoldColSlotSize, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strSlotSize)                                        'ｽﾛｯﾄｻｲｽﾞ
                        
                        .SetData(llngDoCnt, CMlngvsfHoldColLotManagerID, _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strEngEmpId)                                        'ﾛｯﾄ担当者ID
                        
                        '@----------------------------------
                        '@ 背景色の優先順位　時間超過>L/R色
                        '@----------------------------------
                        '@液晶方向(L/R/Null)による背景色変更
                        Select Case ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strLcDirection
                             Case CPstrPDIDL
                                 '@ｾﾙ背景色変更
                                newStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngLColor)
                                cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle                                                                 'Lｶﾗｰ(水色)
                            Case CPstrPDIDR
                                 '@ｾﾙ背景色変更
                                newStyle = .Styles.Add("CustomStyle_BackColor_CPlngRColor")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngRColor)
                                cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1) 
                                cellRange.Style = newStyle                                                                 'Rｶﾗｰ(ﾋﾟﾝｸ)
                            Case Else
                                '@ｾﾙ背景色変更
                                newStyle = .Styles.Add("CustomStyle_BackColor_White")
                                newStyle.BackColor = Color.White
                                cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1) 
                                cellRange.Style = newStyle                                                                    '初期(白)
                        End Select
                          
                        '@保留期限超過の場合は色を変更
                        If .GetData(llngDoCnt, CMlngvsfHoldColHoldTimeEnd) < Format$(Now, CPstrDateTimeYMD) Then
                            '@ｾﾙの色変更(保留Lotｶﾗｰ)
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor_ForeColor_vbBlack" +  llngDoCnt.ToString)
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            newStyle.ForeColor = Color.Black
                            cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle

                        End If
                        
                        '@ｺﾒﾝﾄの有無判定(あり/Null)
                        If ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strComments <> vbNullString Then
                            .SetData(llngDoCnt, CMlngvsfHoldColLotCommentButton, CPstrAriFlg)
                        Else
                            .SetData(llngDoCnt, CMlngvsfHoldColLotCommentButton, vbNullString)
                        End If
                        

                        '@-----------------------------------------------
                        '@ ﾌｫﾝﾄ色の設定(組立限定機能)
                        '@　①ﾁｯﾌﾟ品LOT：青色
                        '@-----------------------------------------------
                        '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"か
                        If pstrSBID = CPstrSBID2A0 And _
                            ltypInvActptLotList.typInvAcptLot(llngDoCnt -1).strSbArea = CPstrProductChip Then
                                                
                            '@ﾌｫﾝﾄｶﾗｰを青色に変更
                            newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue" +  llngDoCnt.ToString)
                            newStyle.BackColor = cellRange.Style.BackColor
                            newStyle.ForeColor = Color.Blue
                            cellRange = .GetCellRange(llngDoCnt, CMlngvsfHoldColNo, _
                                llngDoCnt, CMlngvsfHoldColLotManagerID)
                            cellRange.Style = newStyle
                        
                        End If

                        
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height = CMlngVsfHeight
                        
                        '@ｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                    Loop
                    
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSortHoldTab.blnChgWidth = False Then
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCol(CMlngvsfHoldColHoldTime, 6)             '保留開始日
                        .AutoSizeCol(CMlngvsfHoldColHoldTimeEnd, 6)          '保留期限
                        .AutoSizeCol(CMlngvsfHoldColStatus, 6)               '状態
                        .AutoSizeCol(CMlngvsfHoldColCarrierID, 6)            'ｷｬﾘｱID
                        .AutoSizeCol(CMlngvsfHoldColLotID, 6)                'ﾛｯﾄID
                        .AutoSizeCol(CMlngvsfHoldColFlowClass, 6)            '種別
                        .AutoSizeCol(CMlngvsfHoldColPDName, 6)               '機種名
                        .AutoSizeCol(CMlngvsfHoldColWfNum, 6)                'WF
                        .AutoSizeCol(CMlngvsfHoldColCfNum, 6)                'ﾁｯﾌﾟ
                        .AutoSizeCol(CMlngvsfHoldColOpID, 6)                 '大工程
                        .AutoSizeCol(CMlngvsfHoldColStepID, 6)               '小工程
                        .AutoSizeCol(CMlngvsfHoldColWpID, 6)                 '装置名
                        .AutoSizeCol(CMlngvsfHoldColHoldFlag, 6)             '保留ﾌﾗｸﾞ
                        .AutoSizeCol(CMlngvsfHoldColHoldStay, 6)             '保留期間
                        .AutoSizeCol(CMlngvsfHoldColHoldReason, 6)           '保留理由
                        .AutoSizeCol(CMlngvsfHoldColHoldEmp, 6)              '保留担当者
                        .AutoSizeCol(CMlngvsfHoldColEntryID, 6)              'ｴﾝﾄﾘ
                        .AutoSizeCol(CMlngvsfHoldColLotManagerName, 6)       'ﾛｯﾄ担当者名
                        .AutoSizeCol(CMlngvsfHoldColLotComments, 6)          'ｺﾒﾝﾄ
                        .AutoSizeCol(CMlngvsfHoldColLastUpdate, 6)           '最終更新日時
                    End If
                    
                    '@書式設定
                    .Cols(CMlngvsfHoldColNo).TextAlign = TextAlignEnum.RightCenter                 'ｽﾛｯﾄ№(右寄せ中央揃え)
                    .Cols(CMlngvsfHoldColHoldTime).TextAlign = TextAlignEnum.LeftCenter            '保留開始日(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColHoldTimeEnd).TextAlign = TextAlignEnum.LeftCenter         '保留期限(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColStatus).TextAlign = TextAlignEnum.LeftCenter              '状態(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColCarrierID).TextAlign = TextAlignEnum.LeftCenter           'ｷｬﾘｱID(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColLotID).TextAlign = TextAlignEnum.LeftCenter               'ﾛｯﾄID(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColFlowClass).TextAlign = TextAlignEnum.LeftCenter           '種別(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColPDName).TextAlign = TextAlignEnum.LeftCenter              '機種名(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColWfNum).TextAlign = TextAlignEnum.RightCenter              'WF(右寄せ中央揃え)
                    .Cols(CMlngvsfHoldColCfNum).TextAlign = TextAlignEnum.RightCenter              'ﾁｯﾌﾟ(右寄せ中央揃え)
                    .Cols(CMlngvsfHoldColOpID).TextAlign = TextAlignEnum.LeftCenter                '大工程(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColStepID).TextAlign = TextAlignEnum.LeftCenter              '小工程(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColWpID).TextAlign = TextAlignEnum.LeftCenter                '装置名(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColHoldFlag).TextAlign = TextAlignEnum.LeftCenter            '保留ﾌﾗｸﾞ(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColHoldStay).TextAlign = TextAlignEnum.LeftCenter            '保留期間(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColHoldReason).TextAlign = TextAlignEnum.LeftCenter          '保留理由(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColHoldEmp).TextAlign = TextAlignEnum.LeftCenter             '保留担当者(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColEntryID).TextAlign = TextAlignEnum.LeftCenter             'ｴﾝﾄﾘ(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColLotManagerName).TextAlign = TextAlignEnum.LeftCenter      'ﾛｯﾄ担当者名(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColLotComments).TextAlign = TextAlignEnum.LeftCenter         'ｺﾒﾝﾄ(左寄せ中央揃え)
                    .Cols(CMlngvsfHoldColLastUpdate).TextAlign = TextAlignEnum.LeftCenter          '最終更新日時(左寄せ中央揃え)
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSortHoldTab.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSortHoldTab.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSortHoldTab.typChgSortList(llngCnt).lngCol).Sort = mtypChgSortHoldTab.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort, mtypChgSortHoldTab.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    AddHandler vsfLotListHold.BeforeRowColChange, AddressOf vsfLotListHold_BeforeRowColChange
                    AddHandler vsfLotListHold.EnterCell, AddressOf vsfLotListHold_EnterCell

                    '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がある場合
                    If mtypChgSortHoldTab.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@ﾛｯﾄIDが同じ場合
                            If .GetData(llngCnt, CMlngvsfHoldColLotID) = mtypChgSortHoldTab.strKey Then
                                .Row = llngCnt
                                
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                Call pubVsfBeforeSort(vsfLotListHold, CMlngVsfRowTitle)
                                
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                Call pubVsfAfterSort(vsfLotListHold, CMlngVsfRowTitle,Nothing ,Nothing ,False, False, False, False)
                                
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        .TopRow = 0    '行
                        .Row = 0       'ｶﾚﾝﾄ行の移動
                    End If
                    
                    '@再描画
                    .Redraw = True
                    
                    '@ﾛｯｸ解除
                    .Enabled = True

                    If mblnSetFocus = False Then
                        '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfLotListHold)
                    End If
                End If
            End With

            '@該当件数
            lblLotCntHold.Text = ltypInvActptLotList.InvAcptLotListCnt

            '@現在日時表示
            lblNowDateHold.Text = Format$(Now, CPstrDateFormat)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListHold_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotListWF_Init
    '機　能：中間WF在庫一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 16:29:19 S.Deguchi
    '更新日：2006/11/01 (Wed) 11:19:15 N.Kasai
    '備　考：
    '　　　：2004/10/13 (Wed) 16:26:58 S.Deguchi    不具合№775対応で中間WF在庫一覧にｽﾛｯﾄｻｲｽﾞ欄(非表示)を追加
    '　　　：2005/02/04 (Fri) 10:36:01 S.Deguchi    不具合№471対応で元ﾛｯﾄIDを追加＆最終更新者を非表示に設定
    '　　　：2005/07/25 (Mon) 14:34:00 S.Deguchi    不具合№2929の対応で情報取得ﾌﾗｸﾞを追加
    '　　　：2006/11/01 (Wed) 11:19:15 N.Kasai      責任者、ｺﾒﾝﾄ欄追加(№01500)
    Private Sub prvvsfLotListWF_Init()

        Try

            With vsfLotListWF
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfWFColNo, CMlngVsfRowTitle, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                                             '文字色
                headerStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                                              '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)       'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               '文字位置
                cellRange.Style = headerStyle

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfWFColNo, CMstrvsfWFColNo)                              'No.
                .SetData(CMlngVsfRowTitle, CMlngvsfWFColPutDay, CMstrvsfWFColPutDay)                      '受入日
                .SetData(CMlngVsfRowTitle, CMlngvsfWFColCarrierID, CMstrvsfWFColCarrierID)                'ｷｬﾘｱID
                .SetData(CMlngVsfRowTitle, CMlngvsfWFColCarrierPosition, CMstrvsfWFColCarrierPosition)    'ｷｬﾘｱ位置
                .SetData(CMlngVsfRowTitle, CMlngvsfWFColLotID, CMstrvsfWFColLotID)                        '元ﾛｯﾄID
                .SetData(CMlngVsfRowTitle, CMlngvsfWFColWfNum, CMstrvsfWFColWfNum)                        'WF
                .SetData(CMlngVsfRowTitle, CMlngvsfWFColCfNum, CMstrvsfWFColCfNum)                        'ﾁｯﾌﾟ
                .SetData(CMlngVsfRowTitle, CMlngvsfWFColLastUpdate, CMstrvsfWFColLastUpdate)              '最終更新日
                .SetData(CMlngVsfRowTitle, CMlngvsfWFColSlotSize, CMstrvsfWFColSlotSize)                  'ｽﾛｯﾄｻｲｽﾞ
                .SetData(CMlngVsfRowTitle, CMlngvsfWFColInfoFlag, CMstrvsfWFColInfoFlag)                  '情報取得ﾌﾗｸﾞ
                .SetData(CMlngVsfRowTitle, CMlngvsfWFColCarrierEmpName, CMstrvsfWFColCarrierEmpName)      '責任者
                .SetData(CMlngVsfRowTitle, CMlngvsfWFColcarrierComments, CMstrvsfWFColCarrierComments)    'ｺﾒﾝﾄ

                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSortWFTab.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfWFColNo).Width = CMlngvsfWFWColNo                               'No.
                    .Cols(CMlngvsfWFColPutDay).Width = CMlngvsfWFWColPutDay                       '受入日
                    .Cols(CMlngvsfWFColCarrierID).Width = CMlngvsfWFWColCarrierID                 'ｷｬﾘｱID
                    .Cols(CMlngvsfWFColCarrierPosition).Width = CMlngvsfWFWColCarrierPosition     'ｷｬﾘｱ位置
                    .Cols(CMlngvsfWFColLotID).Width = CMlngvsfWFWColLotID                         '元ﾛｯﾄID
                    .Cols(CMlngvsfWFColWfNum).Width = CMlngvsfWFWColWfNum                         'WF
                    .Cols(CMlngvsfWFColCfNum).Width = CMlngvsfWFWColCfNum                         'ﾁｯﾌﾟ
                    .Cols(CMlngvsfWFColLastUpdate).Width = CMlngvsfWFWColLastUpdate               '最終更新日
                    .Cols(CMlngvsfWFColSlotSize).Width = CMlngvsfWFWColSlotSize                   'ｽﾛｯﾄｻｲｽﾞ
                    .Cols(CMlngvsfWFColInfoFlag).Width = CMlngvsfWFWColInfoFlag                   '情報取得ﾌﾗｸﾞ
                    .Cols(CMlngvsfWFColCarrierEmpName).Width = CMlngvsfWFWColCarrierEmpName       '責任者
                    .Cols(CMlngvsfWFColcarrierComments).Width = CMlngvsfWFWColCarrierComments     'ｺﾒﾝﾄ
                End If
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight      '高さ
                
                '@非表示設定
                .Cols(CMlngvsfWFColSlotSize).Visible = False            'ｽﾛｯﾄｻｲｽﾞ
                .Cols(CMlngvsfWFColInfoFlag).Visible = False            '情報取得ﾌﾗｸﾞ
                
                '@ﾛｯｸ
                .Enabled = False
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.None
            End With
            
            '@該当件数のｸﾘｱ
            lblLotCntWF.Text = 0
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListWF_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotListWF_Disp
    '機　能：中間WF在庫一覧作成
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 14:04:21 S.Deguchi
    '更新日：2006/11/01 (Wed) 11:21:47 N.Kasai
    '備　考：
    '　　　：2004/10/13 (Wed) 17:02:33 S.Deguchi    ｽﾛｯﾄｻｲｽﾞ追加
    '　　　：2004/10/15 (Fri) 10:19:53 N.Kasai      ｿｰﾄ順ｸﾞﾘｯﾄｻｲｽﾞ保持対応
    '　　　：2004/11/10 (Wed) 15:55:27 N.Kasai      №設定を変更
    '　　　：2005/02/04 (Fri) 12:40:42 S.Deguchi    不具合№471対応(構造体変更による処理修正)
    '　　　：2005/03/24 (Thu) 09:01:05 S.Deguchi    描画制御修正
    '　　　：2005/07/25 (Mon) 14:35:48 S.Deguchi    不具合№2929の対応で情報取得ﾌﾗｸﾞ処理を追加
    '　　　：2006/11/01 (Wed) 11:21:47 N.Kasai      責任者、ｺﾒﾝﾄ欄追加(№01500)
    Private Sub prvvsfLotListWF_Disp()

        Dim llngDoCnt   As Integer  'ｶｳﾝﾄ
        Dim llngCnt     As Integer  '汎用ｶｳﾝﾄ
        Dim lstrBFLotID As String   'ﾛｯﾄID欄
        Dim ScrollPosition As Point

        Try
            
            With vsfLotListWF
                If mtypInvLotList.lngLotListAnsCnt <> 0 Then
                '@格納ﾃﾞｰﾀがあるの場合
                    '@ｷｬﾘｱのWF情報を格納する領域を確保
                    If mtypCaarierInfo Is Nothing Then
                        mtypCaarierInfo = New List(Of CarrierInfo)
                    Else
                        mtypCaarierInfo.Clear
                    End If

                    Dim mtypCaarierInfoTmp As New CarrierInfo

                    '@描画ﾛｯｸ
                    .Redraw = False
                    
                    ScrollPosition = .ScrollPosition

                    RemoveHandler vsfLotListWF.BeforeRowColChange, AddressOf vsfLotListWF_BeforeRowColChange
                    RemoveHandler vsfLotListWF.EnterCell, AddressOf vsfLotListWF_EnterCell

                    .Row = -1
                    .Col = CMlngvsfWFColNo

                    '@行数初期化(ｸﾞﾘｯﾄﾞの初期化)
                    .Rows.Count = .Rows.Fixed
                    
                    '@行数設定
                    .Rows.Count = mtypInvLotList.lngLotListAnsCnt + 1
                    
                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 1
                    
                    Do While .Rows.Count > llngDoCnt
                        '@ﾛｯﾄ一覧表示情報設定
                        .SetData(llngDoCnt, CMlngvsfWFColNo, llngDoCnt)                                             '№
                        
                        mtypCaarierInfoTmp.strNo = llngDoCnt                                                        '№
                        
                        If IsDate(mtypInvLotList.typLotListAns(llngDoCnt -1).strEntryTime) Then                     '受入日
                            .SetData(llngDoCnt, CMlngvsfWFColPutDay, _
                                Format$(CDate(mtypInvLotList.typLotListAns(llngDoCnt -1).strEntryTime), CPstrDateTimeYMD)) 
                        Else
                            .SetData(llngDoCnt, CMlngvsfWFColPutDay, _
                            mtypInvLotList.typLotListAns(llngDoCnt -1).strEntryTime)  
                        End If

                        .SetData(llngDoCnt, CMlngvsfWFColCarrierID, _
                            mtypInvLotList.typLotListAns(llngDoCnt -1).strCarrierId)                                'ｷｬﾘｱID
                            
                        mtypCaarierInfoTmp.strCarrierId = _
                            mtypInvLotList.typLotListAns(llngDoCnt -1).strCarrierId                                 'ｷｬﾘｱID
                            
                        mtypCaarierInfo.Add(mtypCaarierInfoTmp)

                        .SetData(llngDoCnt, CMlngvsfWFColCarrierPosition, _
                            mtypInvLotList.typLotListAns(llngDoCnt -1).strCurrentPositionName)                      'ｷｬﾘｱ位置
                        
                        '@元ﾛｯﾄIDのｾｯﾄ
                        lstrBFLotID = vbNullString
                        For llngCnt = 0 To mtypInvLotList.typLotListAns(llngDoCnt -1).lngBFLotListCnt -1
                            If llngCnt = 0 Then
                                lstrBFLotID = mtypInvLotList.typLotListAns(llngDoCnt -1).typBFLotList(llngCnt).strLotID
                            Else
                                lstrBFLotID = lstrBFLotID & _
                                              CMstrSlash & _
                                              mtypInvLotList.typLotListAns(llngDoCnt -1).typBFLotList(llngCnt).strLotID
                            End If
                        Next
                        .SetData(llngDoCnt, CMlngvsfWFColLotID, lstrBFLotID)                                        '元ﾛｯﾄID
                            
                        .SetData(llngDoCnt, CMlngvsfWFColWfNum, _
                            mtypInvLotList.typLotListAns(llngDoCnt -1).strWFQuantity)                               'WF
                        
                        '@ﾁｯﾌﾟ数のｾｯﾄ
                        If mtypInvLotList.typLotListAns(llngDoCnt -1).strChipQuantity = vbNullString Then
                            .SetData(llngDoCnt, CMlngvsfWFColCfNum, "0")
                        Else
                            .SetData(llngDoCnt, CMlngvsfWFColCfNum, _
                                Format$(CInt(mtypInvLotList.typLotListAns(llngDoCnt -1).strChipQuantity), CPstrDateFormatKanma))
                        End If
                        
                        .SetData(llngDoCnt, CMlngvsfWFColLastUpdate, _
                            mtypInvLotList.typLotListAns(llngDoCnt -1).strEditTime)                                         '最終更新日時
                        
                        .SetData(llngDoCnt, CMlngvsfWFColSlotSize, _
                            mtypInvLotList.typLotListAns(llngDoCnt -1).strSlotSize)                                         'ｽﾛｯﾄｻｲｽﾞ
                        
                        .SetData(llngDoCnt, CMlngvsfWFColInfoFlag, CMlngInfoFlagOff)                                        '情報取得ﾌﾗｸﾞ：OFF
                        
                        .SetData(llngDoCnt, CMlngvsfWFColCarrierEmpName, _
                            mtypInvLotList.typLotListAns(llngDoCnt -1).strCarrierEmpName)                                   '責任者
                        
                        '@ｺﾒﾝﾄ欄は改行ｺｰﾄﾞをNullに置き換える
                        .SetData(llngDoCnt, CMlngvsfWFColcarrierComments, _
                            Replace(mtypInvLotList.typLotListAns(llngDoCnt -1).strCarrierComments, vbCrLf, vbNullString))   'ｺﾒﾝﾄ
                        
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height = CMlngVsfHeight
                        
                        '@ｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                    Loop
                    
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSortWFTab.blnChgWidth = False Then
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCol(CMlngvsfWFColPutDay, 6)             '受入日
                        .AutoSizeCol(CMlngvsfWFColCarrierID, 6)          'ｷｬﾘｱID
                        .AutoSizeCol(CMlngvsfWFColCarrierPosition, 6)    'ｷｬﾘｱ位置
                        .AutoSizeCol(CMlngvsfWFColLotID, 6)              'ﾛｯﾄID
                        .AutoSizeCol(CMlngvsfWFColWfNum, 6)              'WF
                        .AutoSizeCol(CMlngvsfWFColCfNum, 6)              'ﾁｯﾌﾟ
                        .AutoSizeCol(CMlngvsfWFColLastUpdate, 6)         '最終更新日時
                        .AutoSizeCol(CMlngvsfWFColCarrierEmpName, 6)     '責任者
                        .AutoSizeCol(CMlngvsfWFColcarrierComments, 6)    'ｺﾒﾝﾄ
                    End If

                    '@書式設定
                    .Cols(CMlngvsfWFColNo).TextAlign = TextAlignEnum.RightCenter               'ｽﾛｯﾄ№(右寄せ中央揃え)
                    .Cols(CMlngvsfWFColPutDay).TextAlign = TextAlignEnum.LeftCenter            '受入日(左寄せ中央揃え)
                    .Cols(CMlngvsfWFColCarrierID).TextAlign = TextAlignEnum.LeftCenter         'ｷｬﾘｱID(左寄せ中央揃え)
                    .Cols(CMlngvsfWFColCarrierPosition).TextAlign = TextAlignEnum.LeftCenter   'ｷｬﾘｱ位置(左寄せ中央揃え)
                    .Cols(CMlngvsfWFColWfNum).TextAlign = TextAlignEnum.RightCenter            'WF(右寄せ中央揃え)
                    .Cols(CMlngvsfWFColCfNum).TextAlign = TextAlignEnum.RightCenter            'ﾁｯﾌﾟ(右寄せ中央揃え)
                    .Cols(CMlngvsfWFColLastUpdate).TextAlign = TextAlignEnum.LeftCenter        '最終更新日時(左寄せ中央揃え)
                    .Cols(CMlngvsfWFColCarrierEmpName).TextAlign = TextAlignEnum.LeftCenter    '責任者
                    .Cols(CMlngvsfWFColcarrierComments).TextAlign = TextAlignEnum.LeftCenter   'ｺﾒﾝﾄ
                    
                    '@行列のﾏｳｽでの変更を可にする
                    .AllowResizing = AllowResizingEnum.Columns
                    
                    '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                    .FocusRect = FocusRectEnum.Light
                              
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSortWFTab.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSortWFTab.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSortWFTab.typChgSortList(llngCnt).lngCol).Sort = mtypChgSortWFTab.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort, mtypChgSortWFTab.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    AddHandler vsfLotListWF.BeforeRowColChange, AddressOf vsfLotListWF_BeforeRowColChange
                    AddHandler vsfLotListWF.EnterCell, AddressOf vsfLotListWF_EnterCell

                    '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がある場合
                    If mtypChgSortWFTab.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@ﾛｯﾄIDが同じ場合
                            If .GetData(llngCnt, CMlngvsfWFColCarrierID) = mtypChgSortWFTab.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                Call pubVsfBeforeSort(vsfLotListWF, CMlngVsfRowTitle)
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                Call pubVsfAfterSort(vsfLotListWF, CMlngVsfRowTitle,Nothing ,Nothing ,False, False, False, False)
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        .TopRow = 0    '行
                        .Row = 0       'ｶﾚﾝﾄ行の移動
                    End If
                        
                    .ScrollPosition = New Point(ScrollPosition.X,.ScrollPosition.Y)

                    '@再描画
                    .Redraw = True
                    
                    '@ﾛｯｸ解除
                    .Enabled = True
                    
                    '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfLotListWF)
                End If
            End With

            '@該当件数
            lblLotCntWF.Text = mtypInvLotList.lngLotListAnsCnt

            '@現在日時表示
            lblNowDateWF.Text = Format$(Now, CPstrDateFormat)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListWF_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCarrierInfo_Init
    '機　能：ｷｬﾘｱ情報一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 16:30:02 S.Deguchi
    '更新日：2004/06/25 (Fri) 16:30:02
    '備　考：
    Private Sub prvvsfCarrierInfo_Init()
        
        Dim llngCnt As Integer  'ﾙｰﾌﾟｶｳﾝﾄ

        Try
            
            With vsfCarrierInfo

                .Redraw = False

                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                
                '@一覧表の表題設定
                .Rows.Count = CMlngCarrierRowS                                                                '行数
                Dim headercellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfCIColNo, CMlngVsfRowTitle, CMlngvsfCIColStatus)             '表題
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                                             '文字色
                headerStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                                              '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)       'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               '文字位置
                headercellRange.Style = headerStyle                                      
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight                                          '高さ
                
                '@ﾊﾞｯｸｶﾗｰを白に変更
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                newStyle.BackColor = Color.White
                Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngvsfCIColWFID, CMlngCarrierRowS - 1, CMlngvsfCIColStatus)
                cellRange.Style = newStyle
                
                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMlngvsfCIColWFID).Width = CMlngvsfCIWColWFID                                       'WFID
                .SetData(CMlngVsfRowTitle, CMlngvsfCIColWFID, CMstrvsfCIColWFID)
                '@↓2020/02/07 (Fri) 14:47:06 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfCIColGRB).Width = CMlngvsfCIWColGRB                                         'GRB
                .SetData(CMlngVsfRowTitle, CMlngvsfCIColGRB, CMstrvsfCIColGRB)
                '@↑2020/02/07 (Fri) 14:47:06 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfCIColClassID).Width = CMlngvsfCIWColClassID                                 'Class_ID
                .SetData(CMlngVsfRowTitle, CMlngvsfCIColClassID, CMstrvsfCIColClassID)
                .Cols(CMlngvsfCIColStatus).Width = CMlngvsfCIWColStatus                                   '状況
                .SetData(CMlngVsfRowTitle, CMlngvsfCIColStatus, CMstrvsfCIColStatus)
                
                '@一覧表のSlot№設定
                For llngCnt = 1 To CMlngCarrierRowS - 1
                    .Col = CMlngvsfCIColNo
                    .Row = llngCnt
                    .Font = New Font(.Font.FontFamily,CMlngVsfHFontSize,.Font.Style,.Font.Unit)
                    .Rows(llngCnt).Height = CMlngCarrierHeight
                    .SetData(llngCnt, CMlngvsfCIColNo, CStr(Format$(CMlngCarrierRowS - llngCnt, CPstrSlotNoFormat)))
                Next llngCnt
                
                '@ｽﾛｯﾄ№の右寄せ
                .Cols(CMlngvsfCIColNo).TextAlign = TextAlignEnum.RightCenter
                
                '@左寄せ
                .Cols(CMlngvsfCIColWFID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfCIColStatus).TextAlign = TextAlignEnum.LeftCenter
                '@↓2020/02/07 (Fri) 14:48:53 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfCIColGRB).TextAlign = TextAlignEnum.LeftCenter
                '@↑2020/02/07 (Fri) 14:48:53 Y.Yoneyama 「.Netへ反映未」 **************************************************
                
                '@非表示設定
                .Cols(CMlngvsfCIColClassID).Visible = False
                
                .Redraw = True

                '@ﾛｯｸ
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCarrierInfo_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCarrierInfo_Disp
    '機　能：ｷｬﾘｱ情報一覧の表示
    '引　数：ltypInvWaferList：WF情報取得構造体
    '引　数：lstrSlotSize：ｽﾛｯﾄｻｲｽﾞ
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 11:28:43 S.Deguchi
    '更新日：2004/10/26 (Tue) 10:30:21 Y.Yamagishi
    '備　考：2004/10/26 (Tue) 10:30:21 Y.Yamagishi  最大ｽﾛｯﾄ数以内のWFの存在しないｾﾙのﾊﾞｯｸｶﾗｰを濃いｸﾞﾚｰに変更
    '　　　：                                       最大ｽﾛｯﾄ数を超えたｾﾙのﾊﾞｯｸｶﾗｰを薄いｸﾞﾚｰに変更
    '　　　：2005/03/24 (Thu) 08:36:00 S.Deguchi    描画制御修正
    Private Sub prvvsfCarrierInfo_Disp(ByRef ltypInvWaferList As InvWaferList, ByVal lstrSlotSize As String)

        Dim llngCnt         As Integer  'ｶｳﾝﾄ(=1:固定)
        Dim llngLoopCnt     As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngWriteRow    As Integer  '書き込み行

        Try
            
            '@WF情報一覧の初期化
            Call prvvsfCarrierInfo_Init()

            With vsfCarrierInfo
                '@再描画を行わない
                .Redraw = False

                '@取得したｽﾛｯﾄｻｲｽﾞが数値のみの場合
                If IsNumeric(lstrSlotSize) = True Then
                    '@ｽﾛｯﾄｻｲｽﾞ以上のｽﾛｯﾄ№を空白に、背景色を灰色に変更(初期化)
                    For llngCnt = 1 To CMlngCarrierRowS - 1
                        If llngCnt <= CMlngCarrierRowS - CLng(lstrSlotSize) - 1 Then
                            '@ｽﾛｯﾄ№は空白
                            .SetData(llngCnt, CMstrvsfCIColNo, vbNullString)
                            '@WFID
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbButtonFace")
                            newStyle.BackColor = SystemColors.ControlLight
                            'Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfCIColWFID)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfCIColWFID, llngCnt, CMlngvsfCIColStatus)
                            cellRange.Style = newStyle

                        Else
                            '@WFID
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                            'Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfCIColWFID)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfCIColWFID, llngCnt, CMlngvsfCIColStatus)
                            cellRange.Style = newStyle
                        End If
                    Next
                End If

                '@取得在庫WFﾘｽﾄの表示
                If ltypInvWaferList.lngInvWaferListCnt > 0 Then
                    llngCnt = ltypInvWaferList.lngInvWaferListCnt
                    Dim newStyleGRB As CellStyle
                    Dim cellRangeGRB As CellRange
                    '@WF情報の設定
                    For llngLoopCnt = 0 To ltypInvWaferList.lngInvWaferListCnt -1
                        '@取得した情報で空欄以外の場合には表記する
                        If ltypInvWaferList.typInvWaferList(llngLoopCnt).strSlotPosition <> vbNullString Then
                            '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝの設定
                            llngWriteRow = CMlngCarrierRowS - _
                                           CLng(ltypInvWaferList.typInvWaferList(llngLoopCnt).strSlotPosition)

                            '@表示
                            .SetData(llngWriteRow, CMlngvsfCIColWFID, _
                                ltypInvWaferList.typInvWaferList(llngLoopCnt).strWfId)                     'WF_ID
                                
                            .SetData(llngWriteRow, CMlngvsfCIColClassID, _
                                ltypInvWaferList.typInvWaferList(llngLoopCnt).strWFStatusID)               'ClassID
                                
                            .SetData(llngWriteRow, CMlngvsfCIColStatus, _
                                ltypInvWaferList.typInvWaferList(llngLoopCnt).strWFStatus)                 '状態

                            '@↓2020/02/07 (Fri) 14:50:51 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .SetData(llngWriteRow, CMlngvsfCIColGRB, _
                                ltypInvWaferList.typInvWaferList(llngLoopCnt).strGRBClass)                 'GRB
                            '@↑2020/02/07 (Fri) 14:50:51 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                
                            '@背景色を白に変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White
                            'Dim cellRange As CellRange = .GetCellRange(llngWriteRow, CMlngvsfCIColWFID)
                            Dim cellRange As CellRange = .GetCellRange(llngWriteRow, CMlngvsfCIColWFID, llngWriteRow, CMlngvsfCIColStatus)
                            cellRange.Style = newStyle              

                            '@↓2020/02/07 (Fri) 14:51:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            '@GRB背景色
                            newStyleGRB = .Styles.Add("CustomStyle_BackColor_GRB" + llngWriteRow.ToString)
                            newStyleGRB.BackColor = pubGRBBackColor(ltypInvWaferList.typInvWaferList(llngLoopCnt).strGRBClass, Color.White)
                            cellRangeGRB = .GetCellRange(llngWriteRow, CMlngvsfCIColGRB)
                            cellRangeGRB.Style = newStyleGRB
                            '@↑2020/02/07 (Fri) 14:51:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        End If
                    Next llngLoopCnt
                End If
                
                '@再描画
                .Redraw = True

                '@ﾛｯｸ
                .Enabled = False

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCarrierInfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotListSend_Init
    '機　能：完成在庫(送品待ち)一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 16:30:43 S.Deguchi
    '更新日：2016/02/08 (Mon) 23:18:04 H.Hayashi
    '備　考：
    '　　　：2004/10/13 (Wed) 16:58:41 S.Deguchi    ｽﾛｯﾄｻｲｽﾞ欄を追加
    '　　　：2004/11/25 (Thu) 11:00:11 H.Wajima     送品待ち/送品済み判定追加
    '　　　：2005/02/21 (Mon) 11:01:26 S.Deguchi    送品済みに送品担当者欄を,送品待ち/送品済みにAMPMﾌﾗｸﾞ欄を追加
    '　　　：2005/03/22 (Tue) 16:43:08 S.Deguchi    送品済みにTAITAN受入日/TAITANﾛｯﾄID/ｷｬﾘｱﾀｲﾌﾟ欄を追加
    '　　　：2005/11/21 (Mon) 14:17:49 S.Deguchi    技術担当者ID欄追加
    '　　　：2006/11/07 (Tue) 11:52:21 N.Kasai      保留ｺﾒﾝﾄ表示開放(№01500)
    '　　　：2008/06/04 (Wed) 13:12:12 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2012/10/22 (Mon) 12:43:59 T.Oide       R9-05(EPPI送品対応)
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Private Sub prvvsfLotListSend_Init()
        
        Dim llngCnt     As Integer      '汎用ｶｳﾝﾀ

        Try
            
            '@国内/海外ﾁｪｯｸ初期化
            If pstrSBID = CPstrSBID1A0 Then
                '@基板の場合
                '@ﾁｪｯｸﾎﾞｯｸｽ無効
                chkForign0.Enabled = False
                chkForign1.Enabled = False
                
            Else
                '@組立の場合
                '@ﾁｪｯｸﾎﾞｯｸｽ有効
                chkForign0.Enabled = True
                chkForign1.Enabled = True
                
            End If
            
            '@ﾁｪｯｸON
            chkForign0.Checked = CMlngChkON
            chkForign1.Checked = CMlngChkON
            
            '@送品待ち/送品済みの判定
            Select Case True
            
                '@送品待ちが選択されている場合
                Case optLotSendStatus0.Checked
                
                    '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
                    With vsfLotListSend

                        .Redraw = False

                        '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                        .Clear(ClearFlags.Content)
                        
                        '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                        .AllowSorting = AllowSortingEnum.SingleColumn
                                
                        '@初期行数設定
                        .Rows.Count = .Rows.Fixed
                        
                        '@初期列数設定
                        .Cols.Count = CMlngvsfSendCols

                        '@固定列の設定
                        .Cols.Frozen = CMlngSendFrozenCols
                
                        .SelectionMode = SelectionModeEnum.Row
                        
                        '@ﾊｲﾗｲﾄ設定
                        .HighLight = HighLightEnum.Always
                        
                        '@一覧表の表題設定
                        Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfSendColNo, CMlngVsfRowTitle, CMlngvsfSendCols - 1)
                        Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                        headerStyle.ForeColor = Color.Yellow                                                                                             '文字色
                        headerStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                                              '背景色
                        headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)       'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                        headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               '文字位置
                        cellRange.Style = headerStyle

                        '@ﾀｲﾄﾙ設定
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColNo, CMstrvsfSendColNo)                                  'No.
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColKb, CMstrvsfSendColKb)                                  '「保」表示
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColPutDay, CMstrvsfSendColPutDay)                          '受入日
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColCarrierID, CMstrvsfSendColCarrierID)                    'ｷｬﾘｱID
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColLotID, CMstrvsfSendColLotID)                            'ﾛｯﾄID
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColGrbClass, CMstrvsfSendColGrbClass)                      'GRB区分
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColFlowClass, CMstrvsfSendColFlowClass)                    '種別
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColPriority, CMstrvsfSendColPriority)                      '優先度
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColPDName, CMstrvsfSendColPDName)                          '機種名
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColWfNum, CMstrvsfSendColWfNum)                            'WF
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColCfNum, CMstrvsfSendColCfNum)                            'ﾁｯﾌﾟ
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColSendSBID, CMstrvsfSendColSendSBID)                      '送品先
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColBoxNo, CMstrvsfSendColBoxNo)                            '箱№
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColStayTime, CMstrvsfSendColStayTime)                      '停滞時間
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColHoldFlag, CMstrvsfSendColHoldFlag)                      '保留ﾌﾗｸﾞ
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColHoldTime, CMstrvsfSendColHoldTime)                      '保留開始日
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColHoldTimeEnd, CMstrvsfSendColHoldTimeEnd)                '保留期限
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColHoldStayTime, CMstrvsfSendColHoldStayTime)              '保留期間
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColHoldEmpID, CMstrvsfSendColHoldEmpID)                    '保留担当者ID
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColHoldEmp, CMstrvsfSendColHoldEmp)                        '保留担当者
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColHoldReasonID, CMstrvsfSendColHoldReasonID)              '保留理由ID
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColHoldReason, CMstrvsfSendColHoldReason)                  '保留理由
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColLotComments, CMstrvsfSendColLotComments)                'ｺﾒﾝﾄ内容
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColLastUpdate, CMstrvsfSendColLastUpdate)                  '最終更新日時
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColComment, CMstrvsfSendColComment)                        '次SB連絡
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColHoldComments, CMstrvsfSendColHoldComments)              '保留ｺﾒﾝﾄ内容
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColLotCommentDisp, CMstrvsfSendColLotCommentDisp)          'ｺﾒﾝﾄ有無
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColCommentDisp, CMstrvsfSendColCommentDisp)                '次SB連絡有無
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColSlotSize, CMstrvsfSendColSlotSize)                      'ｽﾛｯﾄｻｲｽﾞ
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColLotManagerID, CMstrvsfSendColLotManagerID)              'ﾛｯﾄ担当者ID
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColLotManagerName, CMstrvsfSendColLotManagerName)          'ﾛｯﾄ担当者名
                        .SetData(CMlngVsfRowTitle, CMlngvsfSendColLotSendFlag, CMstrvsfSendColLotSendFlag)                '送品ﾌﾗｸﾞ

                        
                        '@ﾕｰｻﾞによる列幅変更されていない場合
                        If mtypChgSortSendTab.blnChgWidth = False Then
                            '@列幅設定
                            .Cols(CMlngvsfSendColNo).Width = CMlngvsfSendWColNo                                   'No.
                            .Cols(CMlngvsfSendColKb).Width = CMlngvsfSendWColKb                                   '「保」表示
                            .Cols(CMlngvsfSendColPutDay).Width = CMlngvsfSendWColPutDay                           '受入日
                            .Cols(CMlngvsfSendColCarrierID).Width = CMlngvsfSendWColCarrierID                     'ｷｬﾘｱID
                            .Cols(CMlngvsfSendColLotID).Width = CMlngvsfSendWColLotID                             'ﾛｯﾄID
                            .Cols(CMlngvsfSendColGrbClass).Width = CMlngvsfSendWColGrbClass                       'GRB区分
                            .Cols(CMlngvsfSendColFlowClass).Width = CMlngvsfSendWColFlowClass                     '種別
                            .Cols(CMlngvsfSendColPriority).Width = CMlngvsfSendWColPriority                       '優先度
                            .Cols(CMlngvsfSendColPDName).Width = CMlngvsfSendWColPDName                           '機種名
                            .Cols(CMlngvsfSendColWfNum).Width = CMlngvsfSendWColWfNum                             'WF
                            .Cols(CMlngvsfSendColCfNum).Width = CMlngvsfSendWColCfNum                             'ﾁｯﾌﾟ
                            .Cols(CMlngvsfSendColSendSBID).Width = CMlngvsfSendWColSendSBID                       '送品先
                            .Cols(CMlngvsfSendColSBSystemFlag).Width = CMlngvsfSendWColSBSystemFlag               'SBｼｽﾃﾑﾌﾗｸﾞ
                            .Cols(CMlngvsfSendColBoxNo).Width = CMlngvsfSendWColBoxNo                             '箱№
                            .Cols(CMlngvsfSendColStayTime).Width = CMlngvsfSendWColStayTime                       '停滞時間
                            .Cols(CMlngvsfSendColHoldFlag).Width = CMlngvsfSendWColHoldFlag                       '保留ﾌﾗｸﾞ
                            .Cols(CMlngvsfSendColHoldTime).Width = CMlngvsfSendWColHoldTime                       '保留開始日
                            .Cols(CMlngvsfSendColHoldTimeEnd).Width = CMlngvsfSendWColHoldTimeEnd                 '保留期限
                            .Cols(CMlngvsfSendColHoldStayTime).Width = CMlngvsfSendWColHoldStayTime               '保留期間
                            .Cols(CMlngvsfSendColHoldEmpID).Width = CMlngvsfSendWColHoldEmpID                     '保留担当者ID
                            .Cols(CMlngvsfSendColHoldEmp).Width = CMlngvsfSendWColHoldEmp                         '保留担当者
                            .Cols(CMlngvsfSendColHoldReasonID).Width = CMlngvsfSendWColHoldReasonID               '保留理由ID
                            .Cols(CMlngvsfSendColHoldReason).Width = CMlngvsfSendWColHoldReason                   '保留理由
                            .Cols(CMlngvsfSendColLotComments).Width = CMlngvsfSendWColLotComments                 'ｺﾒﾝﾄ内容
                            .Cols(CMlngvsfSendColLastUpdate).Width = CMlngvsfSendWColLastUpdate                   '最終更新日時
                            .Cols(CMlngvsfSendColComment).Width = CMlngvsfSendWColComment                         '次SB連絡内容
                            .Cols(CMlngvsfSendColHoldComments).Width = CMlngvsfSendWColHoldComments               '保留ｺﾒﾝﾄ内容
                            .Cols(CMlngvsfSendColLotCommentDisp).Width = CMlngvsfSendWColLotCommentDisp           'ｺﾒﾝﾄ有無
                            .Cols(CMlngvsfSendColCommentDisp).Width = CMlngvsfSendWColCommentDisp                 '次SB連絡有無
                            .Cols(CMlngvsfSendColSlotSize).Width = CMlngvsfSendWColSlotSize                       'ｽﾛｯﾄｻｲｽﾞ
                            .Cols(CMlngvsfSendColLotManagerID).Width = CMlngvsfSendWColLotManagerID               'ﾛｯﾄ担当者ID
                            .Cols(CMlngvsfSendColLotManagerName).Width = CMlngvsfSendWColLotManagerName           'ﾛｯﾄ担当者名
                            .Cols(CMlngvsfSendColLotSendFlag).Width = CMlngvsfSendWColLotSendFlag                 '送品ﾌﾗｸﾞ

                        End If
                        
                        '@ﾍｯﾀﾞｰの高さを設定
                        .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight      '高さ
                        
                        '@非表示設定
                        For llngCnt = 0 To .Cols.Count -1
                            '@非表示設定初期化
                            .Cols(llngCnt).Visible = True
                        Next llngCnt
                        
                        .Cols(CMlngvsfSendColSBSystemFlag).Visible  = False      'SBｼｽﾃﾑﾌﾗｸﾞ
                        .Cols(CMlngvsfSendColHoldReasonID).Visible  = False      '保留理由ID
                        .Cols(CMlngvsfSendColHoldEmpID).Visible  = False         '保留責任者
                        .Cols(CMlngvsfSendColHoldFlag).Visible  = False          '保留ﾌﾗｸﾞ
                        .Cols(CMlngvsfSendColLotComments).Visible  = False       'ｺﾒﾝﾄ内容
                        .Cols(CMlngvsfSendColLastUpdate).Visible  = False        '最終更新日時
                        .Cols(CMlngvsfSendColComment).Visible  = False           '次SB連絡内容
                        .Cols(CMlngvsfSendColSlotSize).Visible  = False          'ｽﾛｯﾄｻｲｽﾞ
                        .Cols(CMlngvsfSendColLotManagerID).Visible  = False      'ﾛｯﾄ担当者ID
                        .Cols(CMlngvsfSendColLotManagerName).Visible  = False    'ﾛｯﾄ担当者名
                        .Cols(CMlngvsfSendColLotSendFlag).Visible  = False       '送品ﾌﾗｸﾞ
                        .Cols(CMlngvsfSendColAtlasOrderNo).Visible  = False      'ｵｰﾀﾞｰ非表示(ｶﾗﾑ非表示のみ)

                        'NSYS DataType変更
                        .Cols(CMlngvsfSendColPriority).DataType = GetType(Int32)
                        .Cols(CMlngvsfSendColWfNum).DataType = GetType(Int32)
                        .Cols(CMlngvsfSendColCfNum).DataType = GetType(Int32)
                        .Cols(CMlngvsfSendColCfNum).Format = CPstrDateFormatKanma
                        .Cols(CMlngvsfSendColSendSBID).DataType = GetType(Object)
                        .Cols(CMlngvsfSendColSBSystemFlag).DataType = GetType(Object)
                        .Cols(CMlngvsfSendColSBSystemFlag).Format = vbNullString

                        .Redraw = True

                        '@ﾛｯｸ
                        .Enabled = False
                        
                        '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                        .FocusRect = FocusRectEnum.Light
                
                    End With
                    
                '@送品済みが選択されている場合
                Case optLotSendStatus1.Checked
                
                    '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
                    With vsfLotListSend

                        .Redraw = False

                        '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                        .Clear(ClearFlags.Content)
                        
                        '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                        .AllowSorting = AllowSortingEnum.SingleColumn
                                
                        '@初期行数設定
                        .Rows.Count = .Rows.Fixed
                        
                        '@初期列数設定
                        .Cols.Count = CMlngvsfSend2Cols
                        
                        '@固定列の設定
                        '@ｼｽﾃﾑﾌﾞﾛｯｸによる処理分岐
                        If pstrSBID = CPstrSBID1A0 Then
                            .Cols.Frozen = CMlngSend2FrozenCols1A0
                        Else
                            .Cols.Frozen = CMlngSend2FrozenCols2A0
                        End If
                
                        .SelectionMode = SelectionModeEnum.Row
                        
                        '@ﾊｲﾗｲﾄ設定
                        .HighLight = HighLightEnum.Always
                        
                        '@一覧表の表題設定
                        Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngVsfColTitle, CMlngVsfRowTitle, .Cols.Count - 1)
                        Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                        headerStyle.ForeColor = Color.Yellow                                                                                             '文字色
                        headerStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                                              '背景色
                        headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)       'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                        headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               '文字位置
                        cellRange.Style = headerStyle

                        '@ﾀｲﾄﾙ設定
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColNo, CMstrvsfSend2ColNo)                                'No.
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColCB, CMstrvsfSend2ColCB)                                'ﾁｪｯｸﾎﾞｯｸｽ
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColST, CMstrvsfSend2ColST)                                '「済」表示
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColSendDay, CMstrvsfSend2ColSendDay)                      '送品日
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColCarrierID, CMstrvsfSend2ColCarrierID)                  'ｷｬﾘｱID
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColLotID, CMstrvsfSend2ColLotID)                          'ﾛｯﾄID
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColGrbClass, CMstrvsfSend2ColGrbClass)                    'GRB区分
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColFlowClass, CMstrvsfSend2ColFlowClass)                  '種別
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColPutDay, CMstrvsfSend2ColPutDay)                        'TITAN受入日
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColTAITANLotID, CMstrvsfSend2ColTAITANLotID)              'TITANﾛｯﾄID
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColPDName, CMstrvsfSend2ColPDName)                        '機種名
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColWfNum, CMstrvsfSend2ColWfNum)                          'WF
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColCfNum, CMstrvsfSend2ColCfNum)                          'ﾁｯﾌﾟ
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColSendSBID, CMstrvsfSend2ColSendSBID)                    '送品先
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColSendEmpName, CMstrvsfSend2ColSendEmpName)              '送品者
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColSBSystemFlag, CMstrvsfSend2ColSBSystemFlag)            'SBｼｽﾃﾑﾌﾗｸﾞ
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColBoxNo, CMstrvsfSend2ColBoxNo)                          '箱№
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColLotComments, CMstrvsfSend2ColLotComments)              'ｺﾒﾝﾄ内容
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColLastUpdate, CMstrvsfSend2ColLastUpdate)                '最終更新日時
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColComment, CMstrvsfSend2ColComment)                      '次SB連絡
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColLotCommentDisp, CMstrvsfSend2ColLotCommentDisp)        'ｺﾒﾝﾄ有無
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColCommentDisp, CMstrvsfSend2ColCommentDisp)              '次SB連絡有無
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColSlotSize, CMstrvsfSend2ColSlotSize)                    'ｽﾛｯﾄｻｲｽﾞ
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColAMPMFlag, CMstrvsfSend2ColAMPMFlag)                    'AMPMﾌﾗｸﾞ
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColSendDate, CMstrvsfSend2ColSendDate)                    '送品日付
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColCarrierType, CMstrvsfSend2ColCarrierType)              'ｷｬﾘｱﾀｲﾌﾟ
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColTransFlag, CMstrvsfSend2ColTransFlag)                  '転送ﾌﾗｸﾞ
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColLotManagerID, CMstrvsfSend2ColLotManagerID)            'ﾛｯﾄ担当者ID
                        .SetData(CMlngVsfRowTitle, CMlngvsfSend2ColLotManagerName, CMstrvsfSend2ColLotManagerName)        'ﾛｯﾄ担当者名
                                        
                        '@ﾕｰｻﾞによる列幅変更されていない場合
                        If mtypChgSortSendTab.blnChgWidth = False Then
                            '@列幅設定
                            .Cols(CMlngvsfSend2ColNo).Width = CMlngvsfSend2WColNo                                 'No.
                            .Cols(CMlngvsfSend2ColCB).Width = CMlngvsfSend2WColCB                                 'ﾁｪｯｸﾎﾞｯｸｽ
                            .Cols(CMlngvsfSend2ColST).Width = CMlngvsfSend2WColST                                 '「済」表示
                            .Cols(CMlngvsfSend2ColSendDay).Width = CMlngvsfSend2WColSendDay                       '送品日
                            .Cols(CMlngvsfSend2ColCarrierID).Width = CMlngvsfSend2WColCarrierID                   'ｷｬﾘｱID
                            .Cols(CMlngvsfSend2ColLotID).Width = CMlngvsfSend2WColLotID                           'ﾛｯﾄID
                            .Cols(CMlngvsfSend2ColGrbClass).Width = CMlngvsfSend2WColGrbClass                     'GRB区分
                            .Cols(CMlngvsfSend2ColFlowClass).Width = CMlngvsfSend2WColFlowClass                   '種別
                            .Cols(CMlngvsfSend2ColPutDay).Width = CMlngvsfSend2WColPutDay                         '受入日
                            .Cols(CMlngvsfSend2ColTAITANLotID).Width = CMlngvsfSend2WColTAITANLotID               'TITANﾛｯﾄID
                            .Cols(CMlngvsfSend2ColPDName).Width = CMlngvsfSend2WColPDName                         '機種名
                            .Cols(CMlngvsfSend2ColWfNum).Width = CMlngvsfSend2WColWfNum                           'WF
                            .Cols(CMlngvsfSend2ColCfNum).Width = CMlngvsfSend2WColCfNum                           'ﾁｯﾌﾟ
                            .Cols(CMlngvsfSend2ColSendSBID).Width = CMlngvsfSend2WColSendSBID                     '送品先
                            .Cols(CMlngvsfSend2ColSendEmpName).Width = CMlngvsfSend2WColSendEmpName               '送品担当者
                            .Cols(CMlngvsfSend2ColSBSystemFlag).Width = CMlngvsfSend2WColSBSystemFlag             'SBｼｽﾃﾑﾌﾗｸﾞ
                            .Cols(CMlngvsfSend2ColBoxNo).Width = CMlngvsfSend2WColBoxNo                           '箱№
                            .Cols(CMlngvsfSend2ColLotComments).Width = CMlngvsfSend2WColLotComments               'ｺﾒﾝﾄ内容
                            .Cols(CMlngvsfSend2ColLastUpdate).Width = CMlngvsfSend2WColLastUpdate                 '最終更新日時
                            .Cols(CMlngvsfSend2ColComment).Width = CMlngvsfSend2WColComment                       '次SB連絡内容
                            .Cols(CMlngvsfSend2ColLotCommentDisp).Width = CMlngvsfSend2WColLotCommentDisp         'ｺﾒﾝﾄ有無
                            .Cols(CMlngvsfSend2ColCommentDisp).Width = CMlngvsfSend2WColCommentDisp               '次SB連絡有無
                            .Cols(CMlngvsfSend2ColSlotSize).Width = CMlngvsfSend2WColSlotSize                     'ｽﾛｯﾄｻｲｽﾞ
                            .Cols(CMlngvsfSend2ColAMPMFlag).Width = CMlngvsfSend2WColAMPMFlag                     'AMPM
                            .Cols(CMlngvsfSend2ColSendDate).Width = CMlngvsfSend2WColSendDate                     '送品日付
                            .Cols(CMlngvsfSend2ColCarrierType).Width = CMlngvsfSend2WColCarrierType               'ｷｬﾘｱﾀｲﾌﾟ
                            .Cols(CMlngvsfSend2ColTransFlag).Width = CMlngvsfSend2WColTransFlag                   '転送ﾌﾗｸﾞ
                            .Cols(CMlngvsfSend2ColLotManagerID).Width = CMlngvsfSend2WColLotManagerID             'ﾛｯﾄ担当者ID
                            .Cols(CMlngvsfSend2ColLotManagerName).Width = CMlngvsfSend2WColLotManagerName         'ﾛｯﾄ担当者名
                            
                        End If
                        
                        '@ﾍｯﾀﾞｰの高さを設定
                        .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight      '高さ
                        
                        '@非表示設定
                        For llngCnt = 0 To .Cols.Count -1
                            '@非表示設定初期化
                            .Cols(llngCnt).Visible  = True
                        Next llngCnt

                        '@ｼｽﾃﾑﾌﾞﾛｯｸによる非表示設定
                        If pstrSBID = CPstrSBID1A0 Then
                            .Cols(CMlngvsfSend2ColCarrierID).Visible = True     'ｷｬﾘｱID
                            .Cols(CMlngvsfSend2ColGrbClass).Visible = True      'GRB区分
                            .Cols(CMlngvsfSend2ColPutDay).Visible = False       '受入日
                            .Cols(CMlngvsfSend2ColTAITANLotID).Visible = False  'TITANﾛｯﾄID
                        Else
                            .Cols(CMlngvsfSend2ColCarrierID).Visible = False    'ｷｬﾘｱID
                            .Cols(CMlngvsfSend2ColPutDay).Visible = True        '受入日
                            .Cols(CMlngvsfSend2ColTAITANLotID).Visible = True   'TITANﾛｯﾄID
                        End If

                        .Cols(CMlngvsfSend2ColSBSystemFlag).Visible = False     'SBｼｽﾃﾑﾌﾗｸﾞ
                        .Cols(CMlngvsfSend2ColLotComments).Visible = False      'ｺﾒﾝﾄ内容
                        .Cols(CMlngvsfSend2ColLastUpdate).Visible = False       '最終更新日時
                        .Cols(CMlngvsfSend2ColComment).Visible = False          '次SB連絡内容
                        .Cols(CMlngvsfSend2ColSlotSize).Visible = False         'ｽﾛｯﾄｻｲｽﾞ
                        .Cols(CMlngvsfSend2ColAMPMFlag).Visible = False         'AMPM
                        .Cols(CMlngvsfSend2ColSendDate).Visible = False         '送品日付
                        .Cols(CMlngvsfSend2ColCarrierType).Visible = False      'ｷｬﾘｱﾀｲﾌﾟ
                        .Cols(CMlngvsfSend2ColTransFlag).Visible = False        '転送ﾌﾗｸﾞ
                        .Cols(CMlngvsfSend2ColLotManagerID).Visible = False     'ﾛｯﾄ担当者ID
                        .Cols(CMlngvsfSend2ColLotManagerName).Visible = False   'ﾛｯﾄ担当者名
                        .Cols(CMlngvsfSend2ColAtlasOrderNo).Visible = False     'ｵｰﾀﾞｰ非表示(ｶﾗﾑ非表示のみ)

                        'NSYS DataType変更
                        .Cols(CMlngvsfSend2ColFlowClass).DataType = GetType(Object)
                        .Cols(CMlngvsfSend2ColWfNum).DataType = GetType(Int32)
                        .Cols(CMlngvsfSend2ColCfNum).DataType = GetType(Int32)
                        .Cols(CMlngvsfSend2ColCfNum).Format = CPstrDateFormatKanma
                        .Cols(CMlngvsfSend2ColTAITANLotID).DataType = GetType(Object)
                        .Cols(CMlngvsfSend2ColPDName).DataType = GetType(Object)
                        .Cols(CMlngvsfSend2ColPDName).Format = vbNullString

                        .Redraw = True

                        '@ﾛｯｸ
                        .Enabled = False
                        
                        '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                        .FocusRect = FocusRectEnum.Light
                
                    End With
                    
            End Select
            
            '@該当件数のｸﾘｱ
            lblLotCntSend.Text = 0
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListSend_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotListSend_Disp
    '機　能：完成在庫(送品待ち)一覧の作成
    '引　数：MtypStocklotlist() ：完成在庫格納構造体
    '　　　：llngStockListCnt   ：完成在庫格納数
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 18:56:31 S.Deguchi
    '更新日：2016/02/08 (Mon) 23:26:16 H.Hayashi
    '備　考：
    '　　　：2004/08/31 (Tue) 11:48:26 N.Kasai　    停滞時間、保留時間の表示を修正
    '　　　：2004/09/22 (Wed) 09:58:00 S.Deguchi    ｺﾒﾝﾄ表示をｸﾗｲｱﾝﾄでありなし表示へ変換
    '　　　：2004/09/26 (Sun) 09:20:49 S.Deguchi    ｺﾒﾝﾄ表示をｸﾗｲｱﾝﾄであり/Null表示へ変換
    '　　　：2004/10/12 (Tue) 14:21:59 N.Kasai      送品可能ﾌﾗｸﾞ判定追加(№1009)
    '　　　：2004/10/13 (Wed) 17:00:55 S.Deguchi    ｽﾛｯﾄｻｲｽﾞ欄を追加
    '　　　：2004/11/02 (Tue) 12:06:24 N.Kasai      WF移載ﾌﾗｸﾞ判定追加(№133)
    '　　　：2005/03/24 (Thu) 08:57:44 S.Deguchi    描画制御修正
    '　　　：2005/08/01 (Mon) 12:01:32 N.Kasai      L/R色追加
    '　　　：2005/11/21 (Mon) 14:17:49 S.Deguchi    技術担当者ID追加
    '　　　：2007/02/26 (Mon) 18:20:19 N.Kojima     SBｼｽﾃﾑﾌﾗｸﾞの設定を起動SBによって変更するように修正。(案件№01794)
    '　　　：2007/06/07 (Thu) 11:13:16 N.Kasai      箱№表示追加
    '　　　：2008/04/02 (Wed) 13:08:22 M.Koni       表示数制限追加 <案件No.02719>
    '　　　：2008/06/04 (Wed) 13:13:37 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/02/24 (Tue) 16:34:58 N.Kojima     起動SBが組立、かつ送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。
    '　　　：2009/12/03 (Thu) 13:18:42 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    '　　　：2012/10/18 (Thu) 11:22:12 T.Oide       EPPI送品対応
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Private Sub prvvsfLotListSend_Disp(ByRef mtypstocklotlist As List(Of StockLotList), ByVal llngStockListCnt As Integer)

        Dim llngDoCnt   As Integer  'ｶｳﾝﾄ
        Dim lstrTemp    As String   '一時取得
        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ
        Dim llngCnt2    As Integer  '汎用ｶｳﾝﾀ2
        Dim llngRowCnt  As Integer  'ｸﾞﾘｯﾄﾞの行ｶｳﾝﾄ
        Dim newStyle    As CellStyle'NSYS セルスタイル
        Dim cellRange   As CellRange'NSYS セルレンジ

        Try
            
            With vsfLotListSend
            
                If llngStockListCnt <> 0 Then
                '@格納ﾃﾞｰﾀがあるの場合

                    '@描画ﾛｯｸ
                    .Redraw = False
                    
                    RemoveHandler vsfLotListSend.BeforeRowColChange,AddressOf vsfLotListSend_BeforeRowColChange
                    RemoveHandler vsfLotListSend.EnterCell,AddressOf vsfLotListSend_EnterCell

                    .Row = -1

                    '@行数初期化(グリッドの初期化)
                    .Rows.Count = .Rows.Fixed

                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 0
                    
                    '@行ｶｳﾝﾄ初期化
                    llngRowCnt = 1
                    
                    '@ﾛｯﾄ一覧表示情報設定(ﾘｽﾄぶんﾙｰﾌﾟ)
                    Do While llngStockListCnt -1 >= llngDoCnt

                        '@国内/海外の条件に合うデータを表示(両方ﾁｪｯｸONの場合は両方のﾃﾞｰﾀが表示される)
                        '@
                        
                        Dim mtypstocklotlistTmp As StockLotList = mtypstocklotlist(llngDoCnt)

                        '@国内海外ﾌﾗｸﾞがNULL(送品先なし)の場合は国内とする
                        If mtypstocklotlist(llngDoCnt).strForeignCountryFlag = vbNullString Then
                            mtypstocklotlistTmp.strForeignCountryFlag = "0"
                            mtypstocklotlist(llngDoCnt) = mtypstocklotlistTmp
                        End If
                        
                        '@ 国内ﾁｪｯｸON 且つ 海外ﾌﾗｸﾞ0　又は
                        '@ 海外ﾁｪｯｸON 且つ 概外ﾌﾗｸﾞ1　か？
                        If (chkForign0.Checked = CMlngChkON And _
                            mtypstocklotlist(llngDoCnt).strForeignCountryFlag = "0") Or _
                           (chkForign1.Checked = CMlngChkON And _
                            mtypstocklotlist(llngDoCnt).strForeignCountryFlag = "1") Then
                            
                            '@表示行追加
                            .Rows.Count = .Rows.Count + 1
         
                            .SetData(llngRowCnt, CMlngvsfSendColNo, llngRowCnt)                                             '№
                        
                            If IsDate(mtypstocklotlist(llngDoCnt).strDate) Then                                             '受入日
                                .SetData(llngRowCnt, CMlngvsfSendColPutDay, _
                                    Format$(CDate(mtypstocklotlist(llngDoCnt).strDate), CPstrDateTimeYMDHM))                            
                            Else
                                .SetData(llngRowCnt, CMlngvsfSendColPutDay, _
                                    mtypstocklotlist(llngDoCnt).strDate)                
                            End If
                            .SetData(llngRowCnt, CMlngvsfSendColCarrierID, _
                                mtypstocklotlist(llngDoCnt).strCarrierId)                                                    'ｷｬﾘｱID
                                
                            .SetData(llngRowCnt, CMlngvsfSendColLotID, _
                                mtypstocklotlist(llngDoCnt).strLotID)                                                        'ﾛｯﾄID
                                
                            .SetData(llngRowCnt, CMlngvsfSendColGrbClass, _
                                mtypstocklotlist(llngDoCnt).strGrbClass)                                                     'GRB区分

                            .SetData(llngRowCnt, CMlngvsfSendColFlowClass, _
                                mtypstocklotlist(llngDoCnt).strFlowClass)                                                    '種別
                                
                            .SetData(llngRowCnt, CMlngvsfSendColPriority, _
                                mtypstocklotlist(llngDoCnt).strLotPriority)                                                  '優先度
                                
                            .SetData(llngRowCnt, CMlngvsfSendColPDName, _
                                mtypstocklotlist(llngDoCnt).strPdId)                                                         '機種名
                                
                            .SetData(llngRowCnt, CMlngvsfSendColWfNum, _
                                mtypstocklotlist(llngDoCnt).strWFQuantity)                                                   'WF
                            
                            If mtypstocklotlist(llngDoCnt).strChipQuantity = vbNullString Then                              'ﾁｯﾌﾟ
                                .SetData(llngRowCnt, CMlngvsfSendColCfNum, "0")
                            Else
                                .SetData(llngRowCnt, CMlngvsfSendColCfNum, _
                                    Format$(CInt(mtypstocklotlist(llngDoCnt).strChipQuantity), CPstrDateFormatKanma))
                            End If
                            
        '@↓2018/07/23 (Mon) 11:38:38 Y.Yoneyama **************************************************
                            '@起動が"1A0:基板"、3A0:防湿ALDか
                            '@(送品伝票印刷対象にならないように)
                            If pstrSBID = CPstrSBID1A0 Or pstrSBID = CPstrSBID3A0 Then
        '@↑2018/07/23 (Mon) 11:38:38 Y.Yoneyama **************************************************
                                '@基板起動の場合は、ﾃﾞﾌｫﾙﾄで1:千歳を設定
                                .SetData(llngRowCnt, CMlngvsfSendColSBSystemFlag, "1")                                       'SBｼｽﾃﾑﾌﾗｸﾞ
                            Else
                                '@組立起動の場合は、Msgに格納されている値を格納
                                .SetData(llngRowCnt, CMlngvsfSendColSBSystemFlag, _
                                    mtypstocklotlist(llngDoCnt).strSBSystemFlag)                                             'SBｼｽﾃﾑﾌﾗｸﾞ
                            End If
                            
                            .SetData(llngRowCnt, CMlngvsfSendColLotSendFlag, _
                                    mtypstocklotlist(llngDoCnt).strLotSendFlag)                                              '送品ﾌﾗｸﾞ(0:なし、1:あり)
                                    
                            '@送品なし/あり表示
                            Select Case mtypstocklotlist(llngDoCnt).strLotSendFlag
                                '@送品なし
                                Case CPlngLotSendNasi
                                     .SetData(llngRowCnt, CMlngvsfSendColSendSBID, CMstrDispSendNasi)                        '送品なし
                            End Select
                            
                            If pstrSBID = CPstrSBID2A0 Then
                                .SetData(llngRowCnt, CMlngvsfSendColBoxNo, _
                                    mtypstocklotlist(llngDoCnt).strBoxNo)                                                    '箱№
                            End If
                                
                            '@ﾌｫｰﾏｯﾄ変更
                            lstrTemp = Mid(mtypstocklotlist(llngDoCnt).strStayTime, CMlngFormatStart, CMlngFormatMid9)
                            .SetData(llngRowCnt, CMlngvsfSendColStayTime, lstrTemp)                                          '停滞時間
                            
                            .SetData(llngRowCnt, CMlngvsfSendColHoldFlag, _
                                mtypstocklotlist(llngDoCnt).strLotHoldFlag)                                                  '保留ﾌﾗｸﾞ

                            If IsDate(mtypstocklotlist(llngDoCnt).strRecordTime) Then                                        '保留開始日
                                .SetData(llngRowCnt, CMlngvsfSendColHoldTime, _
                                    Format$(CDate(mtypstocklotlist(llngDoCnt).strRecordTime), CPstrDateTimeYMD))                        
                            Else
                                .SetData(llngRowCnt, CMlngvsfSendColHoldTime, _
                                    mtypstocklotlist(llngDoCnt).strRecordTime)                      
                            End If

                            If IsDate(mtypstocklotlist(llngDoCnt).strHoldTermDate) Then                                      '保留期限
                                .SetData(llngRowCnt, CMlngvsfSendColHoldTimeEnd, _
                                    Format$(CDate(mtypstocklotlist(llngDoCnt).strHoldTermDate), CPstrDateTimeYMD))                      
                            Else
                                .SetData(llngRowCnt, CMlngvsfSendColHoldTimeEnd, _
                                    mtypstocklotlist(llngDoCnt).strHoldTermDate)                
                            End If

                            .SetData(llngRowCnt, CMlngvsfSendColHoldEmpID, _
                                mtypstocklotlist(llngDoCnt).strHoldEmpID)                                                    '保留担当者ID
                            
                            .SetData(llngRowCnt, CMlngvsfSendColHoldEmp, _
                                mtypstocklotlist(llngDoCnt).strHoldEmpName)                                                  '保留担当者
                            
                            .SetData(llngRowCnt, CMlngvsfSendColHoldReasonID, _
                                mtypstocklotlist(llngDoCnt).strReasonCodeID)                                                 '保留理由ID
                                
                            .SetData(llngRowCnt, CMlngvsfSendColHoldReason, _
                                mtypstocklotlist(llngDoCnt).strReasonName)                                                   '保留理由
                                
                            .SetData(llngRowCnt, CMlngvsfSendColLotComments, _
                                mtypstocklotlist(llngDoCnt).strLotComments)                                                  'ﾛｯﾄｺﾒﾝﾄ
                                
                            .SetData(llngRowCnt, CMlngvsfSendColHoldComments, _
                                Replace(mtypstocklotlist(llngDoCnt).strInvHoldComments, vbCrLf, vbNullString))               '保留ｺﾒﾝﾄ
                                
                            .SetData(llngRowCnt, CMlngvsfSendColLastUpdate, _
                                mtypstocklotlist(llngDoCnt).strEntryTime)                                                    '最終更新日時
                                
                            .SetData(llngRowCnt, CMlngvsfSendColComment, _
                                mtypstocklotlist(llngDoCnt).strInvComments)                                                  '送品時ｺﾒﾝﾄ
                            
                            .SetData(llngRowCnt, CMlngvsfSendColSlotSize, _
                                mtypstocklotlist(llngDoCnt).strSlotSize)                                                     'ｽﾛｯﾄｻｲｽﾞ
                            
                            .SetData(llngRowCnt, CMlngvsfSendColLotManagerID, _
                                mtypstocklotlist(llngDoCnt).strEngEmpId)                                                     'ﾛｯﾄ担当者ID
            
                            .SetData(llngRowCnt, CMlngvsfSendColLotManagerName, _
                                mtypstocklotlist(llngDoCnt).strEngEmpName)                                                   'ﾛｯﾄ担当者名
                            
                            '@----------------------------------
                            '@ 背景色の優先順位　保留>L/R色
                            '@----------------------------------
                            '@液晶方向(L/R/Null)による背景色変更
                            Select Case mtypstocklotlist(llngDoCnt).strLcDirection
                                 Case CPstrPDIDL
                                     '@ｾﾙ背景色変更
                                    newStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngLColor)'Lｶﾗｰ（水色)
                                    cellRange = .GetCellRange(llngRowCnt, CMlngVsfColTitle, llngRowCnt, .Cols.Count - 1)
                                    cellRange.Style = newStyle

                                Case CPstrPDIDR
                                     '@ｾﾙ背景色変更
                                    newStyle = .Styles.Add("CustomStyle_BackColor_CPlngRColor")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngRColor)'Rｶﾗｰ（ﾋﾟﾝｸ)
                                    cellRange = .GetCellRange(llngRowCnt, CMlngVsfColTitle, llngRowCnt, .Cols.Count - 1)
                                    cellRange.Style = newStyle

                                Case Else
                                    '@ｾﾙ背景色変更
                                    newStyle = .Styles.Add("CustomStyle_BackColor_White")
                                    newStyle.BackColor = Color.White         '初期（白）  
                                    cellRange = .GetCellRange(llngRowCnt, CMlngVsfColTitle, llngRowCnt, .Cols.Count - 1)
                                    cellRange.Style = newStyle   
                                    
                            End Select
                            
                            '@ﾌﾗｸﾞ判定(ﾛｯﾄ保留)
                            If .GetData(llngRowCnt, CMlngvsfSendColHoldFlag) = CMstrLotHoldFlgOn Then
                                '@ｾﾙの色変更(保留Lotｶﾗｰ)
                                '@ﾌｫﾝﾄの色変更(黒色)
                                newStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor_ForeColor_vbBlack" +  llngRowCnt.ToString)
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                                newStyle.ForeColor = Color.Black
                                cellRange = .GetCellRange(llngRowCnt, CMlngVsfColTitle, llngRowCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle
                                
                                '@ﾌﾗｸﾞ判定(WF移載ﾌﾗｸﾞ 1:移載中)
                                If mtypstocklotlist(llngDoCnt).strWfCarryFlag = CMstrWfCarryFlagOn Then
                                    '@「移」を表示
                                    .SetData(llngRowCnt, CMlngvsfSendColKb, CMstrIsai)                                 '移
                                Else
                                    '@「保」を表示
                                    .SetData(llngRowCnt, CMlngvsfSendColKb, CMstrHo)                                   '保
                                End If
                                
                                '@ﾌｫｰﾏｯﾄ変更
                                lstrTemp = Mid(mtypstocklotlist(llngDoCnt).strHoldStayDate, CMlngFormatStart, CMlngFormatMid9)
                                .SetData(llngRowCnt, CMlngvsfSendColHoldStayTime, lstrTemp)                            '保留期間
                            Else
                                '@保留ﾌﾗｸﾞOFF(送品可能)の場合
                                '@-------------------------------------
                                '@ﾌﾗｸﾞ判定について
                                '@  WF移載ﾌﾗｸﾞONの場合は送品可能ﾌﾗｸﾞOFF
                                '@-------------------------------------
                                '@送品可能ﾌﾗｸﾞを判定
                                If mtypstocklotlist(llngDoCnt).strSendAbleFlag = CMstrSendAbleFlagOn Then
                                '@送品可能の場合
                                    '@ﾁｪｯｸﾎﾞｯｸｽ挿入
                                    .SetCellCheck(llngRowCnt, CMlngvsfSendColKb, CheckEnum.Unchecked)

                                Else
                                    '@ﾌﾗｸﾞ判定(WF移載ﾌﾗｸﾞ 1:移載中)
                                    If mtypstocklotlist(llngDoCnt).strWfCarryFlag = CMstrWfCarryFlagOn Then
                                        '@「移」を表示
                                        .SetData(llngRowCnt, CMlngvsfSendColKb, CMstrIsai)                             '移
                                    Else
                                        '@空白表示
                                        .SetData(llngRowCnt, CMlngvsfSendColKb, vbNullString)                          '空白
                                    End If
                                End If
                                
                                '@位置設定(中央中央)
                                .Cols(CMlngvsfSendColKb).TextAlign = TextAlignEnum.CenterCenter
                            End If
                            
                            '@ｺﾒﾝﾄの有無判定
                            If mtypstocklotlist(llngDoCnt).strLotComments <> vbNullString Then
                                .SetData(llngRowCnt, CMlngvsfSendColLotCommentDisp, CPstrAriFlg)
                            Else
                                .SetData(llngRowCnt, CMlngvsfSendColLotCommentDisp, vbNullString)
                            End If
                            
                            '@送品時ｺﾒﾝﾄの有無判定
                            If mtypstocklotlist(llngDoCnt).strInvComments <> vbNullString Then
                                .SetData(llngRowCnt, CMlngvsfSendColCommentDisp, CPstrAriFlg)
                            Else
                                .SetData(llngRowCnt, CMlngvsfSendColCommentDisp, vbNullString)
                            End If
                                                   
                            '@-----------------------------------------------
                            '@ ﾌｫﾝﾄ色の設定(組立限定機能)
                            '@　①ﾁｯﾌﾟ品LOT：青色
                            '@-----------------------------------------------

                            '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"か
                            If pstrSBID = CPstrSBID2A0 And _
                                mtypstocklotlist(llngDoCnt).strSbArea = CPstrProductChip Then
                                
                                '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"の場合
                                '@文字色を青色に変更
                                newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue"+  llngRowCnt.ToString)
                                newStyle.BackColor = cellRange.Style.BackColor
                                newStyle.ForeColor = Color.Blue
                                cellRange = .GetCellRange(llngRowCnt, CMlngvsfSendColNo, _
                                    llngRowCnt, CMlngvsfSendColLotSendFlag)
                                cellRange.Style = newStyle
                            
                            End If
            
                            If vsfLotListSend.getCellCheck(llngRowCnt, CMlngvsfSendColKb) = CheckEnum.None Then
                                newStyle = .Styles.Add("CustomStyle_CheckBox"+  llngRowCnt.ToString)
                                newStyle.BackColor = cellRange.Style.BackColor
                                newStyle.ForeColor = cellRange.Style.ForeColor
                                newStyle.Font = New Font(.Font.FontFamily, CMlngvsfHFontSize, .Font.Style, .Font.Unit)
                                cellRange = .GetCellRange(llngRowCnt, CMlngvsfSendColKb)
                                cellRange.Style = newStyle
                            End If


                            '@ｽﾛｯﾄの高さの設定
                            .Rows(llngRowCnt).Height = CMlngVsfHeight
                            
                            llngRowCnt = llngRowCnt + 1
                            
                        End If
                        
                        '@ｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                        
                    Loop
                    
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSortSendTab.blnChgWidth = False Then
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCol(CMlngvsfSendColKb, 6)                   '「保」表示
                        .AutoSizeCol(CMlngvsfSendColPutDay, 6)               '受入日
                        .AutoSizeCol(CMlngvsfSendColCarrierID, 6)            'ｷｬﾘｱID
                        .AutoSizeCol(CMlngvsfSendColLotID, 6)                'ﾛｯﾄID
                        .AutoSizeCol(CMlngvsfSendColGrbClass, 6)             'GRB区分
                        .AutoSizeCol(CMlngvsfSendColFlowClass, 6)            '種別
                        .AutoSizeCol(CMlngvsfSendColPriority, 6)             '優先度
                        .AutoSizeCol(CMlngvsfSendColPDName, 6)               '機種名
                        .AutoSizeCol(CMlngvsfSendColWfNum, 6)                'WF
                        .AutoSizeCol(CMlngvsfSendColCfNum, 6)                'ﾁｯﾌﾟ
                        .AutoSizeCol(CMlngvsfSendColSendSBID, 6)             '送品先
                        .AutoSizeCol(CMlngvsfSendColBoxNo, 6)                '箱№
                        .AutoSizeCol(CMlngvsfSendColStayTime, 6)             '停滞時間
                        .AutoSizeCol(CMlngvsfSendColHoldFlag, 6)             '保留ﾌﾗｸﾞ
                        .AutoSizeCol(CMlngvsfSendColHoldTime, 6)             '保留開始日
                        .AutoSizeCol(CMlngvsfSendColHoldTimeEnd, 6)          '保留期限
                        .AutoSizeCol(CMlngvsfSendColHoldStayTime, 6)         '保留期間
                        .AutoSizeCol(CMlngvsfSendColHoldEmp, 6)              '保留担当者
                        .AutoSizeCol(CMlngvsfSendColHoldReason, 6)           '保留理由
                        .AutoSizeCol(CMlngvsfSendColLotComments, 6)          'ｺﾒﾝﾄ
                        .AutoSizeCol(CMlngvsfSendColLastUpdate, 6)           '最終更新日時
                        .AutoSizeCol(CMlngvsfSendColComment, 6)              '次SB連絡
                        .AutoSizeCol(CMlngvsfSendColHoldComments, 6)         '保留ｺﾒﾝﾄ
                        .AutoSizeCol(CMlngvsfSendColLotCommentDisp, 6)       'ｺﾒﾝﾄ有無
                        .AutoSizeCol(CMlngvsfSendColCommentDisp, 6)          '次SB連絡有無
                                        
                    End If
                    
                    '@書式設定
                    .Cols(CMlngvsfSendColNo).TextAlign = TextAlignEnum.RightCenter                 'ｽﾛｯﾄ№(右寄せ中央揃え)
                    .Cols(CMlngvsfSendColKb).TextAlign = TextAlignEnum.LeftCenter                  '「保」表示(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColPutDay).TextAlign = TextAlignEnum.LeftCenter              '受入日(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColCarrierID).TextAlign = TextAlignEnum.LeftCenter           'ｷｬﾘｱID(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColLotID).TextAlign = TextAlignEnum.LeftCenter               'ﾛｯﾄID(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColGrbClass).TextAlign = TextAlignEnum.LeftCenter            'GRB区分(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColFlowClass).TextAlign = TextAlignEnum.LeftCenter           '種別(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColPriority).TextAlign = TextAlignEnum.RightCenter           '優先度(右寄せ中央揃え)
                    .Cols(CMlngvsfSendColPDName).TextAlign = TextAlignEnum.LeftCenter              '機種名(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColWfNum).TextAlign = TextAlignEnum.RightCenter              'WF(右寄せ中央揃え)
                    .Cols(CMlngvsfSendColCfNum).TextAlign = TextAlignEnum.RightCenter              'ﾁｯﾌﾟ(右寄せ中央揃え)
                    .Cols(CMlngvsfSendColSendSBID).TextAlign = TextAlignEnum.LeftCenter            '送品先(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColBoxNo).TextAlign = TextAlignEnum.LeftCenter               '箱№(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColStayTime).TextAlign = TextAlignEnum.LeftCenter            '停滞時間(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColHoldFlag).TextAlign = TextAlignEnum.LeftCenter            '保留ﾌﾗｸﾞ(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColHoldTime).TextAlign = TextAlignEnum.LeftCenter            '保留開始日(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColHoldTimeEnd).TextAlign = TextAlignEnum.LeftCenter         '保留期限(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColHoldStayTime).TextAlign = TextAlignEnum.LeftCenter        '保留期間(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColHoldEmp).TextAlign = TextAlignEnum.LeftCenter             '保留担当者(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColHoldReason).TextAlign = TextAlignEnum.LeftCenter          '保留理由(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColLotComments).TextAlign = TextAlignEnum.LeftCenter         'ｺﾒﾝﾄ(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColComment).TextAlign = TextAlignEnum.LeftCenter             '次SB連絡内容(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColHoldComments).TextAlign = TextAlignEnum.LeftCenter        '保留ｺﾒﾝﾄ内容(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColLotCommentDisp).TextAlign = TextAlignEnum.LeftCenter      'ｺﾒﾝﾄ有無(左寄せ中央揃え)
                    .Cols(CMlngvsfSendColCommentDisp).TextAlign = TextAlignEnum.LeftCenter         '次SB連絡有無(左寄せ中央揃え)
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSortSendTab.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSortSendTab.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSortSendTab.typChgSortList(llngCnt).lngCol).Sort = mtypChgSortSendTab.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort, mtypChgSortSendTab.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    AddHandler vsfLotListSend.BeforeRowColChange,AddressOf vsfLotListSend_BeforeRowColChange
                    AddHandler vsfLotListSend.EnterCell,AddressOf vsfLotListSend_EnterCell

                    '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がある場合
                    If mtypChgSortSendTab.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@ﾛｯﾄIDが同じ場合
                            If .GetData(llngCnt, CMlngvsfSendColLotID) = mtypChgSortSendTab.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                Call pubVsfBeforeSort(vsfLotListSend, CMlngVsfRowTitle)
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                Call pubVsfAfterSort(vsfLotListSend, CMlngVsfRowTitle,Nothing ,Nothing ,False, False, False, False)
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        .TopRow = 0    '行
                        .Row = 0       'ｶﾚﾝﾄ行の移動
                    End If
                    
                    '@再描画
                    .Redraw = True
                    
                    '@ﾛｯｸ解除
                    .Enabled = True
                    
                    If mblnSetFocus = False Then
                        '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        If .Enabled = True Then
                            Call pubSetFocus(vsfLotListSend)
                        End If
                    End If
                End If
            End With

            '@該当件数ﾗﾍﾞﾙに取得件数を表示
            If llngStockListCnt >= CMlngDisplayMaxCnt Then
                '@該当件数が500件以上の場合は、"最大 500"を表示する
                lblLotCntSend.Text = CMstrDisplayMax & Space(1) & Format$(llngStockListCnt, CPstrDateFormatKanma)
            Else
                lblLotCntSend.Text = Format$(llngStockListCnt, CPstrDateFormatKanma)
            End If

            '@現在日時表示
            lblNowDateSend.Text = Format$(Now, CPstrDateFormat)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListSend_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotListSend2_Disp
    '機　能：完成在庫(送品済み)一覧の作成
    '引　数：mtypstocklotlist()：完成在庫格納構造体
    '　　　：llngStockListCnt：完成在庫格納数
    '戻り値：なし
    '作成日：2004/11/25 (Thu) 12:06:12 H.Wajima
    '更新日：2012/11/09 (Fri) 14:57:59 T.Oide
    '備　考：
    '　　　：2005/02/21 (Mon) 11:16:43 S.Deguchi    送品担当者とAMPMﾌﾗｸﾞと送品日付を追加
    '　　　：2005/03/23 (Wed) 14:29:47 S.Deguchi    TITAN受入日/ﾛｯﾄID/ｷｬﾘｱﾀｲﾌﾟ/転送ﾌﾗｸﾞを追加
    '　　　：2005/03/24 (Thu) 08:58:26 S.Deguchi    描画制御修正
    '　　　：2005/08/01 (Mon) 12:05:41 N.Kasai      L/R色追加
    '　　　：2005/11/21 (Mon) 14:17:49 S.Deguchi    技術担当者ID追加
    '　　　：2006/09/19 (Tue) 13:17:58 N.Kojima     送品先指定追加に伴い、処理追加。(案件№01452)
    '　　　：2008/04/02 (Wed) 13:08:22 M.Koni      表示数制限追加 <案件No.02719>
    '　　　：2008/06/04 (Wed) 13:17:34 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/03/09 (Mon) 10:12:49 N.Kojima     起動SBが組立、かつ送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。
    '　　　：2009/12/03 (Thu) 13:18:42 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    '　　　：2012/10/18 (Thu) 11:22:12 T.Oide       EPPI送品対応
    Private Sub prvvsfLotListSend2_Disp(ByRef mtypstocklotlist As List(Of StockLotList), _
                                        ByVal llngStockListCnt As Integer)

        Dim llngDoCnt   As Integer  'ｶｳﾝﾄ
        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ
        Dim llngCnt2    As Integer  '汎用ｶｳﾝﾀ2
        Dim lstrTime    As String
        Dim llngRowCnt  As Integer  'ｸﾞﾘｯﾄﾞの行ｶｳﾝﾄ
        Dim newStyle    As CellStyle'NSYS セルスタイル
        Dim cellRange   As CellRange'NSYS セルレンジ

        Try
            
            With vsfLotListSend
                
                If llngStockListCnt <> 0 Then
                    '@格納ﾃﾞｰﾀがあるの場合

                    '@描画ﾛｯｸ
                    .Redraw = False
                    
                    RemoveHandler vsfLotListSend.BeforeRowColChange,AddressOf vsfLotListSend_BeforeRowColChange
                    RemoveHandler vsfLotListSend.EnterCell,AddressOf vsfLotListSend_EnterCell

                    .Row = -1

                    '@行数初期化(グリッドの初期化)
                    .Rows.Count = .Rows.Fixed

                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 0
                    
                    '@行ｶｳﾝﾄ初期化
                    llngRowCnt = 1
                    
                    '@ﾛｯﾄ一覧表示情報設定(ﾘｽﾄぶんﾙｰﾌﾟ)
                    Do While llngStockListCnt -1 >= llngDoCnt
                    
                        '@国内/海外の条件に合うデータを表示(両方ﾁｪｯｸONの場合は両方のﾃﾞｰﾀが表示される)
                        '@

                        Dim mtypstocklotlistTmp As StockLotList = mtypstocklotlist(llngDoCnt)

                        '@国内海外ﾌﾗｸﾞがNULL(送品先なし)の場合は国内とする
                        If mtypstocklotlist(llngDoCnt).strForeignCountryFlag = vbNullString Then
                            mtypstocklotlistTmp.strForeignCountryFlag = "0"
                            mtypstocklotlist(llngDoCnt) = mtypstocklotlistTmp
                        End If
                        
                        '@ 国内ﾁｪｯｸON 且つ 海外ﾌﾗｸﾞ0　又は
                        '@ 海外ﾁｪｯｸON 且つ 概外ﾌﾗｸﾞ1　か？
                        If (chkForign0.Checked = CMlngChkON And _
                            mtypstocklotlist(llngDoCnt).strForeignCountryFlag = "0") Or _
                           (chkForign1.Checked = CMlngChkON And _
                            mtypstocklotlist(llngDoCnt).strForeignCountryFlag = "1") Then
                            
                            '@表示行追加
                            .Rows.Count = .Rows.Count + 1
                        
                            .SetData(llngRowCnt, CMlngvsfSend2ColNo, llngRowCnt)                                   '№
                        
                            .SetCellCheck(llngRowCnt, CMlngvsfSend2ColCB, CheckEnum.Unchecked)                     'ﾁｪｯｸﾎﾞｯｸｽ
                            
                            '@ﾌﾗｸﾞ判定(次SB受入済み)
                            '@WAIT_RECEIVE_FLAGはOn,Offの意味合いが逆なので注意(0:受入済、1:受入前)
                            If mtypstocklotlist(llngDoCnt).strWaitReceiveFlag = CMstrWaitReceiveFlagOff Then
                                '@受入済みの場合
                                '@「済」を表示
                                .SetData(llngRowCnt, CMlngvsfSend2ColST, CMstrSumi)                                '済
                            End If
                            
                            '@----------------------------------
                            '@ 背景色の優先順位　L/R色
                            '@----------------------------------
                            '@液晶方向(L/R/Null)による背景色変更
                            Select Case mtypstocklotlist(llngDoCnt).strLcDirection
                                 Case CPstrPDIDL
                                     '@ｾﾙ背景色変更
                                    newStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngLColor)'Lｶﾗｰ（水色)
                                    cellRange = .GetCellRange(llngRowCnt, CMlngVsfColTitle, llngRowCnt, .Cols.Count - 1) 
                                    cellRange.Style = newStyle

                                Case CPstrPDIDR
                                     '@ｾﾙ背景色変更
                                    newStyle = .Styles.Add("CustomStyle_BackColor_CPlngRColor")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngRColor)'Rｶﾗｰ（ﾋﾟﾝｸ)
                                    cellRange = .GetCellRange(llngRowCnt, CMlngVsfColTitle, llngRowCnt, .Cols.Count - 1) 
                                    cellRange.Style = newStyle

                                Case Else
                                    '@ｾﾙ背景色変更
                                    newStyle = .Styles.Add("CustomStyle_BackColor_White")
                                    newStyle.BackColor = Color.White         '初期（白）  
                                    cellRange = .GetCellRange(llngRowCnt, CMlngVsfColTitle, llngRowCnt, .Cols.Count - 1) 
                                    cellRange.Style = newStyle

                            End Select
                            
                            If IsDate(mtypstocklotlist(llngDoCnt).strSendDate) Then                                          '送品日
                                .SetData(llngRowCnt, CMlngvsfSend2ColSendDay, _
                                    Format$(CDate(mtypstocklotlist(llngDoCnt).strSendDate), CPstrDateTimeYMDHM))                 
                            Else
                                .SetData(llngRowCnt, CMlngvsfSend2ColSendDay, _
                                    mtypstocklotlist(llngDoCnt).strSendDate)               
                            End If

                            .SetData(llngRowCnt, CMlngvsfSend2ColCarrierID, _
                                mtypstocklotlist(llngDoCnt).strCarrierId)                                                    'ｷｬﾘｱID
                                
                            .SetData(llngRowCnt, CMlngvsfSend2ColLotID, _
                                mtypstocklotlist(llngDoCnt).strLotID)                                                        'ﾛｯﾄID
                                                   
                            .SetData(llngRowCnt, CMlngvsfSend2ColGrbClass, _
                                mtypstocklotlist(llngDoCnt).strGrbClass)                                                     'GRB区分
                                
                            .SetData(llngRowCnt, CMlngvsfSend2ColFlowClass, _
                                mtypstocklotlist(llngDoCnt).strFlowClass)                                                    '種別
                            
                            If IsDate(mtypstocklotlist(llngDoCnt).strTitanAcceptDate) Then                                   'TITAN受入日
                                .SetData(llngRowCnt, CMlngvsfSend2ColPutDay, _
                                    Format$(CDate(mtypstocklotlist(llngDoCnt).strTitanAcceptDate), CPstrDateTimeYMDHM))          
                            Else
                                .SetData(llngRowCnt, CMlngvsfSend2ColPutDay, _
                                    mtypstocklotlist(llngDoCnt).strTitanAcceptDate)         
                            End If

                            .SetData(llngRowCnt, CMlngvsfSend2ColTAITANLotID, _
                                mtypstocklotlist(llngDoCnt).strTitanLotID)                                                   'TITANﾛｯﾄID
                                
                            .SetData(llngRowCnt, CMlngvsfSend2ColPDName, _
                                mtypstocklotlist(llngDoCnt).strPdId)                                                         '機種名
                                
                            .SetData(llngRowCnt, CMlngvsfSend2ColWfNum, _
                                mtypstocklotlist(llngDoCnt).strWFQuantity)                                                   'WF
                            
                            If mtypstocklotlist(llngDoCnt).strChipQuantity = vbNullString Then                              'ﾁｯﾌﾟ
                                .SetData( llngRowCnt, CMlngvsfSend2ColCfNum, "0")
                            Else
                                .SetData(llngRowCnt, CMlngvsfSend2ColCfNum, _
                                    Format$(CInt(mtypstocklotlist(llngDoCnt).strChipQuantity), CPstrDateFormatKanma))
                            End If
                            
                            '@SBﾘｽﾄｶｳﾝﾄ件数の判定
                            '@0件か1件しかありえない
                            .SetData(llngRowCnt, CMlngvsfSend2ColSendSBID, _
                                mtypstocklotlist(llngDoCnt).strSendSBName)                                                   '送品先
                            
                            .SetData(llngRowCnt, CMlngvsfSend2ColSBSystemFlag, _
                                mtypstocklotlist(llngDoCnt).strSBSystemFlag)                                                 'SBｼｽﾃﾑﾌﾗｸﾞ
                            
                            .SetData(llngRowCnt, CMlngvsfSend2ColSendEmpName, _
                                mtypstocklotlist(llngDoCnt).strEmpName)                                                      '送品担当者
                                
                            .SetData(llngRowCnt, CMlngvsfSend2ColBoxNo, _
                                mtypstocklotlist(llngDoCnt).strBoxNo)                                                        '箱№
                                                
                            .SetData(llngRowCnt, CMlngvsfSend2ColLotComments, _
                                mtypstocklotlist(llngDoCnt).strLotComments)                                                  'ﾛｯﾄｺﾒﾝﾄ
                                
                            .SetData(llngRowCnt, CMlngvsfSend2ColLastUpdate, _
                                mtypstocklotlist(llngDoCnt).strEntryTime)                                                    '最終更新日時
                                
                            .SetData(llngRowCnt, CMlngvsfSend2ColComment, _
                                mtypstocklotlist(llngDoCnt).strInvComments)                                                  '送品時ｺﾒﾝﾄ(次SB連絡ｺﾒﾝﾄ)
                            
                            .SetData(llngRowCnt, CMlngvsfSend2ColSlotSize, _
                                mtypstocklotlist(llngDoCnt).strSlotSize)                                                     'ｽﾛｯﾄｻｲｽﾞ
                                
                            .SetData(llngRowCnt, CMlngvsfSend2ColLotManagerID, _
                                mtypstocklotlist(llngDoCnt).strEngEmpId)                                                     'ﾛｯﾄ担当者ID
            
                            .SetData(llngRowCnt, CMlngvsfSend2ColLotManagerName, _
                                mtypstocklotlist(llngDoCnt).strEngEmpName)                                                   'ﾛｯﾄ担当者名
                                
                            '@ｺﾒﾝﾄの有無判定
                            If mtypstocklotlist(llngDoCnt).strLotComments <> vbNullString Then
                                .SetData(llngRowCnt, CMlngvsfSend2ColLotCommentDisp, CPstrAriFlg)
                            Else
                                .SetData(llngRowCnt, CMlngvsfSend2ColLotCommentDisp, vbNullString)
                            End If
            
                            '@送品時ｺﾒﾝﾄの有無判定
                            If mtypstocklotlist(llngDoCnt).strInvComments <> vbNullString Then
                                .SetData(llngRowCnt, CMlngvsfSend2ColCommentDisp, CPstrAriFlg)
                            Else
                                .SetData(llngRowCnt, CMlngvsfSend2ColCommentDisp, vbNullString)
                            End If
                            
                            '@AMPMﾌﾗｸﾞ
                            lstrTime = Strings.Right(.GetData(llngRowCnt, CMlngvsfSend2ColSendDay), 5)
                            If CMstrAMTimeStart <= lstrTime And CMstrAMTimeEnd >= lstrTime Then
                                .SetData(llngRowCnt, CMlngvsfSend2ColAMPMFlag, CMstrAM)
                            Else
                                .SetData(llngRowCnt, CMlngvsfSend2ColAMPMFlag, CMstrPM)
                            End If
                            
                            '@送品日付(YYYY/MM/DD)
                            If IsDate(mtypstocklotlist(llngDoCnt).strSendDate) Then
                                .SetData(llngRowCnt, CMlngvsfSend2ColSendDate, _
                                    Format$(CDate(mtypstocklotlist(llngDoCnt).strSendDate), CPstrDateTimeYMD))
                            Else
                                .SetData(llngRowCnt, CMlngvsfSend2ColSendDate, _
                                    mtypstocklotlist(llngDoCnt).strSendDate)
                            End If

                            '@ｷｬﾘｱﾀｲﾌﾟ
                            .SetData(llngRowCnt, CMlngvsfSend2ColCarrierType, _
                                mtypstocklotlist(llngDoCnt).strCarrierType)
                            
                            '@転送ﾌﾗｸﾞ
                            .SetData(llngRowCnt, CMlngvsfSend2ColTransFlag, _
                                mtypstocklotlist(llngDoCnt).strWaitTransFlag)

                            '@-----------------------------------------------
                            '@ ﾌｫﾝﾄ色の設定(組立限定機能)
                            '@　①ﾁｯﾌﾟ品LOT：青色
                            '@-----------------------------------------------

                            '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"か
                            If pstrSBID = CPstrSBID2A0 And _
                                mtypstocklotlist(llngDoCnt).strSbArea = CPstrProductChip Then
                                
                                '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"の場合
                                '@文字色を青色に変更
                                newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue"+  llngRowCnt.ToString)
                                newStyle.BackColor = cellRange.Style.BackColor
                                newStyle.ForeColor = Color.Blue
                                cellRange = .GetCellRange(llngRowCnt, CMlngvsfSend2ColNo, _
                                    llngRowCnt, CMlngvsfSend2ColLotManagerName)
                                cellRange.Style = newStyle
                            
                            End If
            
                            '@ｾﾙの高さの設定
                            .Rows(llngRowCnt).Height = CMlngVsfHeight
                            
                            llngRowCnt = llngRowCnt + 1
                        
                        End If

                        '@ｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                    Loop
                    
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSortSendTab.blnChgWidth = False Then
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCol(CMlngvsfSend2ColCB, 6)                  'ﾁｪｯｸﾎﾞｯｸｽ
                        .AutoSizeCol(CMlngvsfSend2ColST, 6)                  'ｽﾃｰﾀｽ
                        .AutoSizeCol(CMlngvsfSend2ColSendDay, 6)             '送品日
                        .AutoSizeCol(CMlngvsfSend2ColCarrierID, 6)           'ｷｬﾘｱID
                        .AutoSizeCol(CMlngvsfSend2ColLotID, 6)               'ﾛｯﾄID
                        .AutoSizeCol(CMlngvsfSend2ColGrbClass, 6)            'GRB区分
                        .AutoSizeCol(CMlngvsfSend2ColFlowClass, 6)           '種別
                        .AutoSizeCol(CMlngvsfSend2ColPutDay, 6)              'TITAN受入日
                        .AutoSizeCol(CMlngvsfSend2ColTAITANLotID, 6)         'TITANﾛｯﾄID
                        .AutoSizeCol(CMlngvsfSend2ColPDName, 6)              '機種名
                        .AutoSizeCol(CMlngvsfSend2ColWfNum, 6)               'WF
                        .AutoSizeCol(CMlngvsfSend2ColCfNum, 6)               'ﾁｯﾌﾟ
                        .AutoSizeCol(CMlngvsfSend2ColSendSBID, 6)            '送品先
                        .AutoSizeCol(CMlngvsfSend2ColSendEmpName, 6)         '送品担当者
                        .AutoSizeCol(CMlngvsfSend2ColBoxNo, 6)               '箱№
                        .AutoSizeCol(CMlngvsfSend2ColComment, 6)             '次SB連絡
                        .AutoSizeCol(CMlngvsfSend2ColLotCommentDisp, 6)      'ｺﾒﾝﾄ有無
                        .AutoSizeCol(CMlngvsfSend2ColCommentDisp, 6)         '次SB連絡有無
                                        
                    End If
                    
                    '@書式設定
                    .Cols(CMlngvsfSend2ColNo).TextAlign = TextAlignEnum.RightCenter                '№(右寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColCB).TextAlign = TextAlignEnum.RightCenter                'ﾁｪｯｸﾎﾞｯｸｽ(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColST).TextAlign = TextAlignEnum.LeftCenter                 'ｽﾃｰﾀｽ(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColSendDay).TextAlign = TextAlignEnum.LeftCenter            '送品日(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColCarrierID).TextAlign = TextAlignEnum.LeftCenter          'ｷｬﾘｱID(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColLotID).TextAlign = TextAlignEnum.LeftCenter              'ﾛｯﾄID(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColGrbClass).TextAlign = TextAlignEnum.LeftCenter           'GRB区分(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColFlowClass).TextAlign = TextAlignEnum.LeftCenter          '種別(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColPutDay).TextAlign = TextAlignEnum.LeftCenter             'TITAN受入日(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColTAITANLotID).TextAlign = TextAlignEnum.LeftCenter        'TITANﾛｯﾄID(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColPDName).TextAlign = TextAlignEnum.LeftCenter             '機種名(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColWfNum).TextAlign = TextAlignEnum.RightCenter             'WF(右寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColCfNum).TextAlign = TextAlignEnum.RightCenter             'ﾁｯﾌﾟ(右寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColSendSBID).TextAlign = TextAlignEnum.LeftCenter           '送品先(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColSendEmpName).TextAlign = TextAlignEnum.LeftCenter        '送品担当者(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColBoxNo).TextAlign = TextAlignEnum.LeftCenter              '箱№(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColLotComments).TextAlign = TextAlignEnum.LeftCenter        'ｺﾒﾝﾄ(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColComment).TextAlign = TextAlignEnum.LeftCenter            '次SB連絡内容(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColLotCommentDisp).TextAlign = TextAlignEnum.LeftCenter     'ｺﾒﾝﾄ有無(左寄せ中央揃え)
                    .Cols(CMlngvsfSend2ColCommentDisp).TextAlign = TextAlignEnum.LeftCenter        '次SB連絡有無(左寄せ中央揃え)
                        
                    Dim llngRow As Integer = .Row
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSortSendTab.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSortSendTab.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSortSendTab.typChgSortList(llngCnt).lngCol).Sort = mtypChgSortSendTab.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort, mtypChgSortSendTab.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                        .Row = llngRow
                    End If
                    
                    AddHandler vsfLotListSend.BeforeRowColChange,AddressOf vsfLotListSend_BeforeRowColChange
                    AddHandler vsfLotListSend.EnterCell,AddressOf vsfLotListSend_EnterCell

                    '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がある場合
                    If mtypChgSortSendTab.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@ﾛｯﾄIDが同じ場合
                            If .GetData(llngCnt, CMlngvsfSendColLotID) = mtypChgSortSendTab.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                Call pubVsfBeforeSort(vsfLotListSend, CMlngVsfRowTitle)
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                Call pubVsfAfterSort(vsfLotListSend, CMlngVsfRowTitle,Nothing ,Nothing ,False, False, False, False)
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        .TopRow = 0    '行
                        .Row = 0       'ｶﾚﾝﾄ行の移動
                    End If
                    
                    '@再描画
                    .Redraw = True
                    
                    '@ﾛｯｸ解除
                    .Enabled = True
                    
                    If mblnSetFocus = False Then
                        If vsfLotListSend.Enabled = True Then
                            '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfLotListSend)
                        End If
                    End If
                Else
                    .Rows.Count = .Rows.Fixed
                End If
            End With
            
            '@該当件数ﾗﾍﾞﾙに取得件数を表示
            If llngStockListCnt >= CMlngDisplayMaxCnt Then
                '@該当件数が500件以上の場合は、"最大 500"を表示する
                lblLotCntSend.Text = CMstrDisplayMax & Space(1) & Format$(llngStockListCnt, CPstrDateFormatKanma)
            Else
                lblLotCntSend.Text = Format$(llngStockListCnt, CPstrDateFormatKanma)
            End If
            
            '@現在日時表示
            lblNowDateSend.Text = Format$(Now, CPstrDateFormat)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListSend2_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotlistCFEnd_Init
    '機　能：CF完成在庫一覧の初期化
    '引　数：なし
    '戻り値：
    '作成日：2004/12/06 (Mon) 10:28:49 S.Deguchi
    '更新日：2008/06/04 (Wed) 13:19:48 N.Kojima
    '備　考：
    '　　　：2005/05/07 (Sat) 08:57:59 S.Deguchi    有効期限を追加
    '　　　：2005/05/10 (Sat) 08:57:59 S.Deguchi    最大ﾘﾜｰｸ回数/ﾘﾜｰｸ回数を追加
    '　　　：2005/11/21 (Mon) 14:17:49 S.Deguchi    技術担当者ID欄追加
    '　　　：2008/06/04 (Wed) 13:19:48 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvvsfLotlistCFEnd_Init()

        Try

            With vsfLotListCFEnd

                .Redraw = False

                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@固定列の設定
                .Cols.Frozen = CMlngSendFrozenCols

                .SelectionMode = SelectionModeEnum.Row
                
                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfCFEndColNo, CMlngVsfRowTitle, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                                             '文字色
                headerStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                                              '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)       'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               '文字位置
                cellRange.Style = headerStyle

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColNo, CMstrvsfCFEndColNo)                                'No.
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColKb, CMstrvsfCFEndColKb)                                '「保」表示
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColPutDay, CMstrvsfCFEndColPutDay)                        '受入日
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColCarrierID, CMstrvsfCFEndColCarrierID)                  'ｷｬﾘｱID
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColLotID, CMstrvsfCFEndColLotID)                          'ﾛｯﾄID
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColFlowClass, CMstrvsfCFEndColFlowClass)                  '種別
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColPDName, CMstrvsfCFEndColPDName)                        '機種名
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColCfNum, CMstrvsfCFEndColCfNum)                          'ﾁｯﾌﾟ
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColReworkCount, CMstrvsfCFEndColReworkCount)              'ﾘﾜｰｸ回数
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColRegenerationCnt, CMstrvsfCFEndColRegenerationCnt)      '最大ﾘﾜｰｸ回数
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColCfArea, CMstrvsfCFEndColCfArea)                        'CF区分
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColLimitTime, CMstrvsfCFEndColLimitTime)                  '有効期限
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColStayTime, CMstrvsfCFEndColStayTime)                    '停滞時間
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColHoldFlag, CMstrvsfCFEndColHoldFlag)                    '保留ﾌﾗｸﾞ
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColHoldTime, CMstrvsfCFEndColHoldTime)                    '保留開始日
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColHoldTimeEnd, CMstrvsfCFEndColHoldTimeEnd)              '保留期限
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColHoldStayTime, CMstrvsfCFEndColHoldStayTime)            '保留期間
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColHoldEmpID, CMstrvsfCFEndColHoldEmpID)                  '保留担当者ID
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColHoldEmp, CMstrvsfCFEndColHoldEmp)                      '保留担当者
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColHoldReasonID, CMstrvsfCFEndColHoldReasonID)            '保留理由ID
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColHoldReason, CMstrvsfCFEndColHoldReason)                '保留理由
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColLotComments, CMstrvsfCFEndColLotComments)              'ｺﾒﾝﾄ内容
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColLastUpdate, CMstrvsfCFEndColLastUpdate)                '最終更新日時
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColHoldComments, CMstrvsfCFEndColHoldComments)            '保留ｺﾒﾝﾄ内容
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColLotCommentDisp, CMstrvsfCFEndColLotCommentDisp)        'ｺﾒﾝﾄ有無
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColLotManagerID, CMstrvsfCFEndColLotManagerID)            'ﾛｯﾄ担当者ID
                .SetData(CMlngVsfRowTitle, CMlngvsfCFEndColLotManagerName, CMstrvsfCFEndColLotManagerName)        'ﾛｯﾄ担当者名
                
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSortCFEndTab.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfCFEndColNo).Width = CMlngvsfCFEndWColNo                                 'No.
                    .Cols(CMlngvsfCFEndColKb).Width = CMlngvsfCFEndWColKb                                 '保留区分
                    .Cols(CMlngvsfCFEndColPutDay).Width = CMlngvsfCFEndWColPutDay                         '受入日
                    .Cols(CMlngvsfCFEndColCarrierID).Width = CMlngvsfCFEndWColCarrierID                   'ｷｬﾘｱID
                    .Cols(CMlngvsfCFEndColLotID).Width = CMlngvsfCFEndWColLotID                           'ﾛｯﾄID
                    .Cols(CMlngvsfCFEndColFlowClass).Width = CMlngvsfCFEndWColFlowClass                   '種別
                    .Cols(CMlngvsfCFEndColPDName).Width = CMlngvsfCFEndWColPDName                         '機種名
                    .Cols(CMlngvsfCFEndColCfNum).Width = CMlngvsfCFEndWColCfNum                           'ﾁｯﾌﾟ
                    .Cols(CMlngvsfCFEndColReworkCount).Width = CMlngvsfCFEndWColReworkCount               'ﾘﾜｰｸ回数
                    .Cols(CMlngvsfCFEndColRegenerationCnt).Width = CMlngvsfCFEndWColRegenerationCnt       '最大ﾘﾜｰｸ回数
                    .Cols(CMlngvsfCFEndColCfArea).Width = CMlngvsfCFEndWColCfArea                         'CF区分
                    .Cols(CMlngvsfCFEndColLimitTime).Width = CMlngvsfCFEndWColLimitTime                   '有効期限
                    .Cols(CMlngvsfCFEndColStayTime).Width = CMlngvsfCFEndWColStayTime                     '停滞時間
                    .Cols(CMlngvsfCFEndColHoldFlag).Width = CMlngvsfCFEndWColHoldFlag                     '保留ﾌﾗｸﾞ
                    .Cols(CMlngvsfCFEndColHoldTime).Width = CMlngvsfCFEndWColHoldTime                     '保留開始日
                    .Cols(CMlngvsfCFEndColHoldTimeEnd).Width = CMlngvsfCFEndWColHoldTimeEnd               '保留期限
                    .Cols(CMlngvsfCFEndColHoldStayTime).Width = CMlngvsfCFEndWColHoldStayTime             '保留期間
                    .Cols(CMlngvsfCFEndColHoldEmpID).Width = CMlngvsfCFEndWColHoldEmpID                   '保留担当者ID
                    .Cols(CMlngvsfCFEndColHoldEmp).Width = CMlngvsfCFEndWColHoldEmp                       '保留担当者
                    .Cols(CMlngvsfCFEndColHoldReasonID).Width = CMlngvsfCFEndWColHoldReasonID             '保留理由
                    .Cols(CMlngvsfCFEndColHoldReason).Width = CMlngvsfCFEndWColHoldReason                 '保留理由
                    .Cols(CMlngvsfCFEndColLotComments).Width = CMlngvsfCFEndWColLotComments               'ｺﾒﾝﾄ内容
                    .Cols(CMlngvsfCFEndColLastUpdate).Width = CMlngvsfCFEndWColLastUpdate                 '最終更新日時
                    .Cols(CMlngvsfCFEndColHoldComments).Width = CMlngvsfCFEndWColHoldComments             '保留ｺﾒﾝﾄ内容
                    .Cols(CMlngvsfCFEndColLotCommentDisp).Width = CMlngvsfCFEndWColLotCommentDisp         'ｺﾒﾝﾄ有無
                    .Cols(CMlngvsfCFEndColLotManagerID).Width = CMlngvsfCFEndWColLotManagerID             'ﾛｯﾄ担当者ID
                    .Cols(CMlngvsfCFEndColLotManagerName).Width = CMlngvsfCFEndWColLotManagerName         'ﾛｯﾄ担当者名
                End If
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight    '高さ
                
                '@非表示設定
                .Cols(CMlngvsfCFEndColHoldReasonID).Visible = False     '保留理由ID
                .Cols(CMlngvsfCFEndColHoldEmpID).Visible = False        '保留担当者ID
                .Cols(CMlngvsfCFEndColLotComments).Visible = False      'ｺﾒﾝﾄ内容
                .Cols(CMlngvsfCFEndColHoldFlag).Visible = False         '保留ﾌﾗｸﾞ
                .Cols(CMlngvsfCFEndColLastUpdate).Visible = False       '最終更新日時
                .Cols(CMlngvsfCFEndColHoldComments).Visible = False     '保留ｺﾒﾝﾄ内容
                .Cols(CMlngvsfCFEndColLotManagerID).Visible = False     'ﾛｯﾄ担当者ID
                .Cols(CMlngvsfCFEndColLotManagerName).Visible = False   'ﾛｯﾄ担当者名
                
                .Redraw = True

                '@ﾛｯｸ
                .Enabled = False
                
                '@行列のﾏｳｽでの変更を可にする
                .AllowResizing = AllowResizingEnum.Columns
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
            End With
            
            '@該当件数のｸﾘｱ
            lblLotCntCFEnd.Text = 0
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotlistCFEnd_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotListCFEnd_Disp
    '機　能：CF完成在庫一覧表示処理
    '引　数：mtypstocklotlist2()：完成在庫格納構造体
    '　　　：llngStockListCnt：完成在庫格納数
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 11:42:12 S.Deguchi
    '更新日：2008/06/04 (Wed) 13:21:30 N.Kojima
    '備　考：
    '　　　：2005/03/24 (Thu) 08:52:57 S.Deguchi    描画修正
    '　　　：2005/04/21 (Thu) 13:03:15 S.Deguchi    保留期間の表示変換処理を削除
    '　　　：2005/05/07 (Sat) 08:58:33 S.Deguchi    不具合№770の対応で有効期限を追加＆文字色変更処理を追加
    '　　　：2005/05/10 (Sat) 08:58:33 S.Deguchi    不具合№770の対応でﾘﾜｰｸ回数/最大ﾘﾜｰｸ回数を追加
    '　　　：2005/08/01 (Mon) 12:16:22 N.Kasai      L/R色追加
    '　　　：2005/08/02 (Tue) 08:28:18 S.Deguchi    TPALの有効期限の表記を修正
    '　　　：2005/11/21 (Mon) 14:17:49 S.Deguchi    技術担当者ID欄追加
    '　　　：2006/10/06 (Fri) 12:01:44 N.Kasai      ﾁｯﾌﾟ合計表示追加
    '　　　：2008/06/04 (Wed) 13:21:30 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvvsfLotListCFEnd_Disp(ByRef mtypstocklotlist2 As List(Of StockLotList), _
                                        ByVal llngStockListCnt As Integer)
                                        
        Dim llngDoCnt   As Integer  'ｶｳﾝﾄ
        Dim lstrTemp    As String   '一時取得
        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ
        Dim llngCnt2    As Integer  '汎用ｶｳﾝﾀ2
        Dim lstrNowDate As String   '現在日時退避
        Dim llngChipCnt As Integer  'ﾁｯﾌﾟｶｳﾝﾄ
        Dim newStyle    As CellStyle'NSYS セルスタイル
        Dim cellRange   As CellRange'NSYS セルレンジ
        
        Try
            
            llngChipCnt = 0
            
            With vsfLotListCFEnd
                If llngStockListCnt <> 0 Then
                '@格納ﾃﾞｰﾀがあるの場合
                    '@現在日時を退避
                    lstrNowDate = Format$(Now, CPstrDateTimeYMDHM)
                    
                    '@描画ﾛｯｸ
                    .Redraw = False
                    
                    RemoveHandler vsfLotListCFEnd.EnterCell,AddressOf vsfLotListCFEnd_EnterCell
                    RemoveHandler vsfLotListCFEnd.BeforeRowColChange,AddressOf vsfLotListCFEnd_BeforeRowColChange

                    .Row = -1
                    
                    '@行数初期化(ｸﾞﾘｯﾄﾞの初期化)
                    .Rows.Count = .Rows.Fixed

                    '@行数設定
                    .Rows.Count = llngStockListCnt + 1
                    
                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 1
                    
                    '@ﾛｯﾄ一覧表示情報設定
                    Do While .Rows.Count > llngDoCnt
                        .SetData(llngDoCnt, CMlngvsfCFEndColNo, llngDoCnt)                                                  '№
                        
                        If IsDate(mtypstocklotlist2(llngDoCnt -1).strDate) Then                                             '受入日
                            .SetData(llngDoCnt, CMlngvsfCFEndColPutDay, _
                                Format$(CDate(mtypstocklotlist2(llngDoCnt -1).strDate), CPstrDateFormatMDHM))                           
                        Else
                            .SetData(llngDoCnt, CMlngvsfCFEndColPutDay, _
                                mtypstocklotlist2(llngDoCnt -1).strDate)                         
                        End If

                        .SetData(llngDoCnt, CMlngvsfCFEndColCarrierID, _
                            mtypstocklotlist2(llngDoCnt -1).strCarrierId)                                                    'ｷｬﾘｱID
                            
                        .SetData(llngDoCnt, CMlngvsfCFEndColLotID, _
                            mtypstocklotlist2(llngDoCnt -1).strLotID)                                                        'ﾛｯﾄID
                            
                        .SetData(llngDoCnt, CMlngvsfCFEndColFlowClass, _
                            mtypstocklotlist2(llngDoCnt -1).strFlowClass)                                                    '種別
                            
                        .SetData(llngDoCnt, CMlngvsfCFEndColPDName, _
                            mtypstocklotlist2(llngDoCnt -1).strPdId)                                                         '機種名
                        
                        If mtypstocklotlist2(llngDoCnt -1).strChipQuantity = vbNullString Then                               'ﾁｯﾌﾟ
                            .SetData(llngDoCnt, CMlngvsfCFEndColCfNum,"0")
                        Else
                            .SetData(llngDoCnt, CMlngvsfCFEndColCfNum, _
                                Format$(CInt(mtypstocklotlist2(llngDoCnt -1).strChipQuantity), CPstrDateFormatKanma))
                        End If
                        
                        '@ﾁｯﾌﾟｶｳﾝﾄ加算
                        llngChipCnt = llngChipCnt + CLng(.GetData(llngDoCnt, CMlngvsfCFEndColCfNum))
                        
                        .SetData(llngDoCnt, CMlngvsfCFEndColReworkCount, _
                            mtypstocklotlist2(llngDoCnt -1).strReworkCount)                                                  'ﾘﾜｰｸ回数
                        
                        .SetData(llngDoCnt, CMlngvsfCFEndColRegenerationCnt, _
                            mtypstocklotlist2(llngDoCnt -1).strMaxReworkCount)                                               '最大ﾘﾜｰｸ回数
                        
                        If mtypstocklotlist2(llngDoCnt -1).strCfArea = CMstrCfSelectCodeLeft Then                                            'CF区分
                            .SetData(llngDoCnt, CMlngvsfCFEndColCfArea, CMstrDispCfAreaLeft)
                        ElseIf mtypstocklotlist2(llngDoCnt -1).strCfArea = CMstrCfSelectCodeRight Then
                            .SetData(llngDoCnt, CMlngvsfCFEndColCfArea, CMstrDispCfAreaRight)
                        Else
                            .SetData(llngDoCnt, CMlngvsfCFEndColCfArea, vbNullString)
                        End If
                        
                        '@ﾌｫｰﾏｯﾄ変更(YYYY/MM/DD HH:MM)
                        If IsDate(mtypstocklotlist2(llngDoCnt -1).strLimitTime) Then
                            lstrTemp = Format$(CDate(mtypstocklotlist2(llngDoCnt -1).strLimitTime), CPstrDateTimeYMDHM)
                        Else
                            lstrTemp = mtypstocklotlist2(llngDoCnt -1).strLimitTime
                        End If
                        .SetData(llngDoCnt, CMlngvsfCFEndColLimitTime, lstrTemp)                               '有効期限
                        
                        '@ﾌｫｰﾏｯﾄ変更
                        lstrTemp = Mid(mtypstocklotlist2(llngDoCnt -1).strStayTime, CMlngFormatStart, CMlngFormatMid9)
                        .SetData(llngDoCnt, CMlngvsfCFEndColStayTime, lstrTemp)                                '停滞時間
                        
                        .SetData(llngDoCnt, CMlngvsfCFEndColHoldFlag, _
                            mtypstocklotlist2(llngDoCnt -1).strLotHoldFlag)                                                  '保留ﾌﾗｸﾞ
                        
                        If IsDate(mtypstocklotlist2(llngDoCnt -1).strRecordTime) Then                                        '保留開始日
                            .SetData(llngDoCnt, CMlngvsfCFEndColHoldTime, _
                                Format$(CDate(mtypstocklotlist2(llngDoCnt -1).strRecordTime), CPstrDateTimeYMD))                        
                        Else
                            .SetData(llngDoCnt, CMlngvsfCFEndColHoldTime, _
                                mtypstocklotlist2(llngDoCnt -1).strRecordTime)
                        End If
                          
                        If IsDate(mtypstocklotlist2(llngDoCnt -1).strHoldTermDate) Then                                      '保留期限
                            .SetData(llngDoCnt, CMlngvsfCFEndColHoldTimeEnd, _
                                Format$(CDate(mtypstocklotlist2(llngDoCnt -1).strHoldTermDate), CPstrDateTimeYMD))                      
                        Else
                            .SetData(llngDoCnt, CMlngvsfCFEndColHoldTimeEnd, _
                                mtypstocklotlist2(llngDoCnt -1).strHoldTermDate)                      
                        End If

                        .SetData(llngDoCnt, CMlngvsfCFEndColHoldEmpID, _
                            mtypstocklotlist2(llngDoCnt -1).strHoldEmpID)                                                    '保留担当者ID
                        
                        .SetData(llngDoCnt, CMlngvsfCFEndColHoldEmp, _
                            mtypstocklotlist2(llngDoCnt -1).strHoldEmpName)                                                  '保留担当者
                        
                        .SetData(llngDoCnt, CMlngvsfCFEndColHoldReasonID, _
                            mtypstocklotlist2(llngDoCnt -1).strReasonCodeID)                                                 '保留理由ID
                            
                        .SetData(llngDoCnt, CMlngvsfCFEndColHoldReason, _
                            mtypstocklotlist2(llngDoCnt -1).strReasonName)                                                   '保留理由
                            
                        .SetData(llngDoCnt, CMlngvsfCFEndColLotComments, _
                            mtypstocklotlist2(llngDoCnt -1).strLotComments)                                                  'ﾛｯﾄｺﾒﾝﾄ
                            
                        .SetData(llngDoCnt, CMlngvsfCFEndColHoldComments, _
                        mtypstocklotlist2(llngDoCnt -1).strInvHoldComments)                                                  '保留ｺﾒﾝﾄ
                            
                        .SetData(llngDoCnt, CMlngvsfCFEndColLastUpdate, _
                            mtypstocklotlist2(llngDoCnt -1).strEntryTime)                                                    '最終更新日時
                        
                        .SetData(llngDoCnt, CMlngvsfCFEndColLotManagerID, _
                            mtypstocklotlist2(llngDoCnt -1).strEngEmpId)                                                     'ﾛｯﾄ担当者ID

                        .SetData(llngDoCnt, CMlngvsfCFEndColLotManagerName, _
                            mtypstocklotlist2(llngDoCnt -1).strEngEmpName)                                                   'ﾛｯﾄ担当者名
                        
                        '@----------------------------------
                        '@背景色の優先順位　保留>L/R色
                        '@----------------------------------
                        '@液晶方向(L/R/Null)による背景色変更
                        Select Case mtypstocklotlist2(llngDoCnt -1).strLcDirection
                             Case CPstrPDIDL
                                 '@ｾﾙ背景色変更
                                newStyle = .Styles.Add("CustomStyle_ForeColor_CPlngLColor")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngLColor)'Lｶﾗｰ（水色)
                                cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle
                            Case CPstrPDIDR
                                 '@ｾﾙ背景色変更
                                newStyle = .Styles.Add("CustomStyle_ForeColor_CPlngRColor")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngRColor)'Rｶﾗｰ（ﾋﾟﾝｸ)
                                cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle   
                                                                        
                            Case Else
                                '@ｾﾙ背景色変更
                                newStyle = .Styles.Add("CustomStyle_ForeColor_White")
                                newStyle.BackColor = Color.White         '初期（白）  
                                cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle                                                                               '初期(白)
                        End Select
                        
                        '@ﾌﾗｸﾞ判定(ﾛｯﾄ保留)
                        If .GetData(llngDoCnt, CMlngvsfCFEndColHoldFlag) = CMstrLotHoldFlgOn Then
                            '@ｾﾙの色変更(保留Lotｶﾗｰ)
                            '@ﾌｫﾝﾄの色変更(黒色)
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor_ForeColor_vbBlack")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            newStyle.ForeColor = Color.Black
                            cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                            
                            '@「保」を表示
                            .SetData(llngDoCnt, CMlngvsfCFEndColKb, CMstrHo)                                       '保
                            
                            '@ﾌｫｰﾏｯﾄ変更
                            lstrTemp = Mid(mtypstocklotlist2(llngDoCnt -1).strHoldStayDate, CMlngFormatStart, CMlngFormatMid9)
                            .SetData(llngDoCnt, CMlngvsfCFEndColHoldStayTime, lstrTemp)                            '保留期間
                            
                            '@位置設定(中央中央)
                            .Cols(CMlngvsfCFEndColKb).TextAlign = TextAlignEnum.CenterCenter
                        End If
                        
                        '@有効期限判定
                        If .GetData(llngDoCnt, CMlngvsfCFEndColLimitTime) < lstrNowDate Then
                            '@ﾌｫﾝﾄの色変更(赤色)
                            newStyle = .Styles.Add("CustomStyle_ForeColor_vbRed"+  llngDoCnt.ToString)
                            newStyle.ForeColor = Color.Red
                            newStyle .BackColor = cellRange.Style.BackColor
                            cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        Else
                            '@ﾌｫﾝﾄの色変更(黒色)
                            newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlack"+  llngDoCnt.ToString)
                            newStyle.ForeColor = Color.Black
                            newStyle .BackColor = cellRange.Style.BackColor
                            cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        End If
                        
                        '@ｺﾒﾝﾄの有無判定
                        If mtypstocklotlist2(llngDoCnt -1).strLotComments <> vbNullString Then
                            .SetData(llngDoCnt, CMlngvsfCFEndColLotCommentDisp, CPstrAriFlg)
                        Else
                            .SetData(llngDoCnt, CMlngvsfCFEndColLotCommentDisp, vbNullString)
                        End If
                        
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height = CMlngVsfHeight
                        
                        '@ｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                    Loop
                    
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSortCFEndTab.blnChgWidth = False Then
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCol(CMlngvsfCFEndColKb, 6)                  '「保」表示
                        .AutoSizeCol(CMlngvsfCFEndColPutDay, 6)              '受入日
                        .AutoSizeCol(CMlngvsfCFEndColCarrierID, 6)           'ｷｬﾘｱID
                        .AutoSizeCol(CMlngvsfCFEndColLotID, 6)               'ﾛｯﾄID
                        .AutoSizeCol(CMlngvsfCFEndColFlowClass, 6)           '種別
                        .AutoSizeCol(CMlngvsfCFEndColPDName, 6)              '機種名
                        .AutoSizeCol(CMlngvsfCFEndColCfNum, 6)               'ﾁｯﾌﾟ
                        .AutoSizeCol(CMlngvsfCFEndColReworkCount, 6)         'RW
                        .AutoSizeCol(CMlngvsfCFEndColRegenerationCnt, 6)     '最大RW
                        .AutoSizeCol(CMlngvsfCFEndColCfArea, 6)              'CF区分
                        .AutoSizeCol(CMlngvsfCFEndColLimitTime, 6)           '有効期限
                        .AutoSizeCol(CMlngvsfCFEndColStayTime, 6)            '停滞時間
                        .AutoSizeCol(CMlngvsfCFEndColHoldFlag, 6)            '保留ﾌﾗｸﾞ
                        .AutoSizeCol(CMlngvsfCFEndColHoldTime, 6)            '保留開始日
                        .AutoSizeCol(CMlngvsfCFEndColHoldTimeEnd, 6)         '保留期限
                        .AutoSizeCol(CMlngvsfCFEndColHoldStayTime, 6)        '保留期間
                        .AutoSizeCol(CMlngvsfCFEndColHoldEmp, 6)             '保留担当者
                        .AutoSizeCol(CMlngvsfCFEndColHoldReason, 6)          '保留理由
                        .AutoSizeCol(CMlngvsfCFEndColLotComments, 6)         'ｺﾒﾝﾄ
                        .AutoSizeCol(CMlngvsfCFEndColLastUpdate, 6)          '最終更新日時
                        .AutoSizeCol(CMlngvsfCFEndColHoldComments, 6)        '保留ｺﾒﾝﾄ
                        .AutoSizeCol(CMlngvsfCFEndColLotCommentDisp, 6)      'ｺﾒﾝﾄ有無
                    End If
                    
                    '@書式設定
                    .Cols(CMlngvsfCFEndColNo).TextAlign = TextAlignEnum.RightCenter                'ｽﾛｯﾄ№(右寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColKb).TextAlign = TextAlignEnum.LeftCenter                 '「保」表示(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColPutDay).TextAlign = TextAlignEnum.LeftCenter             '受入日(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColCarrierID).TextAlign = TextAlignEnum.LeftCenter          'ｷｬﾘｱID(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColLotID).TextAlign = TextAlignEnum.LeftCenter              'ﾛｯﾄID(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColFlowClass).TextAlign = TextAlignEnum.LeftCenter          '種別(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColPDName).TextAlign = TextAlignEnum.LeftCenter             '機種名(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColCfNum).TextAlign = TextAlignEnum.RightCenter             'ﾁｯﾌﾟ(右寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColReworkCount).TextAlign = TextAlignEnum.RightCenter       'RW(右寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColRegenerationCnt).TextAlign = TextAlignEnum.RightCenter   '最大RW(右寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColCfArea).TextAlign = TextAlignEnum.LeftCenter             'CF区分(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColLimitTime).TextAlign = TextAlignEnum.LeftCenter          '有効期限(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColStayTime).TextAlign = TextAlignEnum.LeftCenter           '停滞時間(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColHoldFlag).TextAlign = TextAlignEnum.LeftCenter           '保留ﾌﾗｸﾞ(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColHoldTime).TextAlign = TextAlignEnum.LeftCenter           '保留開始日(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColHoldTimeEnd).TextAlign = TextAlignEnum.LeftCenter        '保留期限(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColHoldStayTime).TextAlign = TextAlignEnum.LeftCenter       '保留期間(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColHoldEmp).TextAlign = TextAlignEnum.LeftCenter            '保留担当者(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColHoldReason).TextAlign = TextAlignEnum.LeftCenter         '保留理由(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColLotComments).TextAlign = TextAlignEnum.LeftCenter        'ｺﾒﾝﾄ(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColHoldComments).TextAlign = TextAlignEnum.LeftCenter       '保留ｺﾒﾝﾄ内容(左寄せ中央揃え)
                    .Cols(CMlngvsfCFEndColLotCommentDisp).TextAlign = TextAlignEnum.LeftCenter     'ｺﾒﾝﾄ有無(左寄せ中央揃え)
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSortCFEndTab.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSortCFEndTab.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSortCFEndTab.typChgSortList(llngCnt).lngCol).Sort = mtypChgSortCFEndTab.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort, mtypChgSortCFEndTab.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    AddHandler vsfLotListCFEnd.EnterCell,AddressOf vsfLotListCFEnd_EnterCell
                    AddHandler vsfLotListCFEnd.BeforeRowColChange,AddressOf vsfLotListCFEnd_BeforeRowColChange

                    '@ｿｰﾄ検索用ｷｰ(ﾛｯﾄID)がある場合
                    If mtypChgSortCFEndTab.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@ﾛｯﾄIDが同じ場合
                            If .GetData(llngCnt, CMlngvsfCFEndColLotID) = mtypChgSortCFEndTab.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                Call pubVsfBeforeSort(vsfLotListCFEnd, CMlngVsfRowTitle)
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                Call pubVsfAfterSort(vsfLotListCFEnd, CMlngVsfRowTitle,Nothing ,Nothing ,False, False, False, False)
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        .TopRow = 0    '行
                        .Row = 0       'ｶﾚﾝﾄ行の移動
                    End If
                    
                    '@再描画
                    .Redraw = True
                    
                    '@ﾛｯｸ解除
                    .Enabled = True
                    
                    If mblnSetFocus = False Then
                        '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        If .Enabled = True Then
                            Call pubSetFocus(vsfLotListCFEnd)
                        End If
                    End If

                    '@ﾁｯﾌﾟ合計を表示
                    lblNum.Text = Format$(llngChipCnt, CPstrDateFormatKanma)
                Else
                    '@CF完成在庫一覧のｸﾘｱ
                    Call prvvsfLotlistCFEnd_Init()

                    '@ﾁｯﾌﾟ合計ｸﾘｱ
                    lblNum.Text = 0
                End If
            End With
            
            '@該当件数ﾗﾍﾞﾙに取得件数を表示
            lblLotCntCFEnd.Text = Format$(llngStockListCnt, CPstrDateFormatKanma)

            '@現在日時表示
            lblNowDateCFEnd.Text = Format$(Now, CPstrDateFormat)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListCFEnd_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPdList_Disp
    '機　能：機種Combo作成
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 16:44:31 S.Deguchi
    '更新日：2004/06/25 (Fri) 16:44:31
    '備　考：
    '　　　：2004/12/06 (Mon) 10:42:28 S.Deguchi CF完成在庫Tab処理を追加
    Private Sub prvcmbPdList_Disp()

        Dim llngCnt                     As Integer          'ﾙｰﾌﾟｶｳﾝﾄ

        Try
            
            If pstrSBID = CPstrSBID2A0 Then
                '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)-受入在庫
                With cmbProductPut
                    '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                    .Clear
                    .DirectInput = False                                        '直接入力(False)
                    .SelectMode = CMlngCMbSelectMode                            '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                    .AllSelectButton = True                                     '全選択ﾎﾞﾀﾝ表示
                    .DispCols = CMlngCmbDispCols                                'ｸﾞﾘｯﾄﾞ表示列数
                    .GroupCols = CMlngCmbGroupCols                              '列方向のﾚｺｰﾄﾞ数
                    .GroupRows = mlngProductListCnt2                            '行方向のﾚｺｰﾄﾞ数
                    .AddedComment = CMstrCmbAddedComment                        '"選択"文字列
                    .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                                   'ﾌｫﾝﾄｻｲｽﾞ
                    .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize,.GridFont.Style, .GridFont.Unit)                'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ                    
                    .RowHeight = CMlngCmbRowHeight                              'ﾘｽﾄ行の高さ
                    .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左寄中央揃え
                    
                    '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                    For llngCnt = 0 To mlngProductListCnt2 -1
                        .AddItem(mtypProductList2(llngCnt).strProductID & _
                                 vbTab & _
                                 llngCnt)                                        'ID/Index
                    Next llngCnt
                End With
            
                '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)-CF完成在庫
                With cmbProductCFEnd
                    '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                    .Clear
                    .DirectInput = False                                        '直接入力(False)
                    .SelectMode = CMlngCMbSelectMode                            '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                    .AllSelectButton = True                                     '全選択ﾎﾞﾀﾝ表示
                    .DispCols = CMlngCmbDispCols                                'ｸﾞﾘｯﾄﾞ表示列数
                    .GroupCols = CMlngCmbGroupCols                              '列方向のﾚｺｰﾄﾞ数
                    .GroupRows = mlngProductListCnt4                            '行方向のﾚｺｰﾄﾞ数
                    .AddedComment = CMstrCmbAddedComment                        '"選択"文字列
                    .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                                   'ﾌｫﾝﾄｻｲｽﾞ
                    .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)               'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    .RowHeight = CMlngCmbRowHeight                              'ﾘｽﾄ行の高さ
                    .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左寄中央揃え
                    
                    '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                    For llngCnt = 0 To mlngProductListCnt4 -1
                        .AddItem(mtypProductList4(llngCnt).strProductID & _
                                 vbTab & _
                                 llngCnt)                                        'ID/Index
                    Next llngCnt
                End With
            End If
            
            '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)-完成在庫
            With cmbProductSend
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbGroupCols                                  '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngProductListCnt3                                '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                            '"選択"文字列
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                                   'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)               'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え

                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngProductListCnt3 -1
                    .AddItem(mtypProductList3(llngCnt).strProductID & _
                             vbTab & _
                             llngCnt)                                            'ID/Index
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbPdList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbDivisionList_Disp
    '機　能：種別Combo作成
    '引　数：llngTabIndexFlg:ﾌｫｰﾑﾀﾌﾞｲﾝﾃﾞｯｸｽﾌﾗｸﾞ(0:受入在庫)
    '　　　：                                  (1:保管在庫)
    '　　　：                                  (2:中間在庫)←使用しない
    '　　　：                                  (3:完成在庫)
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 16:47:46 S.Deguchi
    '更新日：2004/10/18 (Mon) 09:40:23 N.Kasai
    '備　考：
    '　　　：2004/10/18 (Mon) 09:40:23 N.Kasai      保留、受入、完成在庫の種別をﾌﾟﾛﾀﾞｸﾄ品限定に変更
    Private Sub prvcmbDivisionList_Disp(ByVal llngTabIndexFlg As Integer)

        Dim llngCnt             As Integer          'ﾙｰﾌﾟｶｳﾝﾄ

        Try
            
            '@ｱｸﾃｨﾌﾞﾀﾌﾞによる処理分岐
            Select Case llngTabIndexFlg
            
                '@受入在庫
                Case CMlngPutTab
                
                    If pstrSBID = CPstrSBID2A0 Then
                        '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)-受入在庫
                        With cmbDivisionPut
                            '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                            .Clear
                            .Enabled = True                                                 '活性化
                            .DirectInput = False                                            '直接入力(False)
                            .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                            .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                            .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                            .GroupCols = 1                                                  '列方向のﾚｺｰﾄﾞ数
                            .GroupRows = mlngDivisionListCnt2                               '行方向のﾚｺｰﾄﾞ数
                            .AddedComment = CMstrCmbAddedComment                            '"選択"文字列
                            .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                                   'ﾌｫﾝﾄｻｲｽﾞ
                            .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)               'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                            .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                            .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                            
                            '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                            For llngCnt = 0 To mlngDivisionListCnt2 -1
                                .AddItem(mtypDivisionList2(llngCnt).strDivisionID & _
                                         vbTab & _
                                         llngCnt)                                            'ID/Index
                            Next llngCnt
                        End With
                    End If
                    
                '@保留在庫
                Case CMlngHoldTab
                
                    '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)-保留在庫
                    With cmbDivisionHold
                        '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                        .Clear
                        .Enabled = True                                                 '活性化
                        .DirectInput = False                                            '直接入力(False)
                        .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                        .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                        .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                        .GroupCols = 1                                                  '列方向のﾚｺｰﾄﾞ数
                        .GroupRows = mlngDivisionListCnt                                '行方向のﾚｺｰﾄﾞ数
                        .AddedComment = CMstrCmbAddedComment                            '"選択"文字列
                        .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                                   'ﾌｫﾝﾄｻｲｽﾞ
                        .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)               'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                        .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                        .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                        
                        '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                        For llngCnt = 0 To mlngDivisionListCnt -1
                            .AddItem(mtypDivisionList(llngCnt).strDivisionID & _
                                     vbTab & _
                                     llngCnt)                                            'ID/Index
                        Next llngCnt
                    End With
                
                '@完成在庫
                Case CMlngSendTab
                
                    '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)-完成在庫
                    With cmbDivisionSend
                        '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                        .Clear
                        .Enabled = True                                                 '活性化
                        .DirectInput = False                                            '直接入力(False)
                        .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                        .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                        .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                        .GroupCols = 1                                                  '列方向のﾚｺｰﾄﾞ数
                        .GroupRows = mlngDivisionListCnt3                               '行方向のﾚｺｰﾄﾞ数
                        .AddedComment = CMstrCmbAddedComment                            '"選択"文字列
                        .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                                   'ﾌｫﾝﾄｻｲｽﾞ
                        .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)               'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                        .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                        .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                        
                        '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                        For llngCnt = 0 To mlngDivisionListCnt3 -1
                            .AddItem(mtypDivisionList3(llngCnt).strDivisionID & _
                                     vbTab & _
                                     llngCnt)                                            'ID/Index
                        Next llngCnt
                    End With
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbDivisionList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvHoldConnect_Set
    '機　能：引継ぎ構造体へ格納
    '引　数：llngTabIndexFlg:ﾌｫｰﾑﾀﾌﾞｲﾝﾃﾞｯｸｽﾌﾗｸﾞ(0:受入在庫)
    '　　　：                                  (1:保管在庫)
    '　　　：                                  (2:中間在庫)
    '　　　：                                  (3:完成在庫)
    '　　　：                                  (4:CF完成在庫)
    '戻り値：True:OK/False:NG
    '作成日：2004/06/29 (Tue) 16:22:19 S.Deguchi
    '更新日：2008/06/04 (Wed) 12:42:48 N.Kojima
    '備　考：
    '　　　：2004/10/13 (Wed) 17:16:28 S.Deguchi    ｽﾛｯﾄｻｲｽﾞ追加
    '　　　：2004/10/15 (Fri) 12:12:51 N.Kasai      構造体に保留責任者名を追加
    '　　　：2004/11/29 (Mon) 09:50:55 H.Wajima     送品待ち/送品済み判定追加
    '　　　：2004/12/06 (Mon) 15:30:02 S.Deguchi    CF完成在庫判定処理を追加＆ﾁｯﾌﾟ数量をｾｯﾄ
    '　　　：2005/01/12 (Wed) 09:05:48 H.Wajima     外部送品ﾌﾗｸﾞの初期化を追加
    '　　　：2005/01/19 (Wed) 14:57:24 S.Deguchi    処理順を修正(送品ｵﾌﾟｼｮﾝ判定を完成在庫内へ移動)
    '　　　：2005/03/31 (Thu) 13:36:32 S.Deguchi    不具合№700保留期限に保留開始日がセットされていた件を修正
    '　　　：2005/11/21 (Mon) 15:22:54 S.Deguchi    保留ﾒｰﾙ用情報の退避処理を追加
    '　　　：2007/01/31 (Wed) 12:51:56 N.Kasai      保管在庫保留一覧(保留ｺﾒﾝﾄ削除)№01714
    '　　　：2008/06/04 (Wed) 12:42:48 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/07/07 (Mon) 12:00:00 S.Ochiai     Source整備(受入在庫ﾀﾌﾞの不要引継ぎ変数削除)
    Private Function prvHoldConnect_Set(ByVal llngTabIndexFlg As Integer) As Boolean

        Try

            '@初期化
            prvHoldConnect_Set = False
            
            '@引数による処理分岐
            Select Case llngTabIndexFlg
            
                '@受入在庫
                Case CMlngPutTab
                
                    With vsfLotListPut
                        '@ﾀｲﾄﾙ以外
                        If .Row > 0 Then
                            ptypHoldConnect.lngTabFlag = CMlngPutTab                                       'ﾀﾌﾞﾌﾗｸﾞ
                            ptypHoldConnect.strCarrierId = .GetData(.Row, CMlngvsfPutColCarrierID)         'ｷｬﾘｱID
                            ptypHoldConnect.strLotID = .GetData(.Row, CMlngvsfPutColLotID)                 'ﾛｯﾄID
                            ptypHoldConnect.strFlowClass = .GetData(.Row, CMlngvsfPutColFlowClass)         '流動区分
                            ptypHoldConnect.strCommnents = .GetData(.Row, CMlngvsfPutColLotComments)       'ﾛｯﾄｺﾒﾝﾄ内容
                            ptypHoldConnect.strNextCommnents = .GetData(.Row, CMlngvsfPutColInvComments)   'SB連絡ｺﾒﾝﾄ内容
                            ptypHoldConnect.strLastUpdate = .GetData(.Row, CMlngvsfPutColLastUpdate)       '最終更新日時
                            
                            '@結果OKを返す
                            prvHoldConnect_Set = True
                        Else
                            ptypHoldConnect.lngTabFlag = CMlngPutTab            'ﾀﾌﾞﾌﾗｸﾞ
                            ptypHoldConnect.strCarrierId = vbNullString         'ｷｬﾘｱID
                            ptypHoldConnect.strLotID = vbNullString             'ﾛｯﾄID
                            ptypHoldConnect.strFlowClass = vbNullString         '流動区分
                            ptypHoldConnect.strCommnents = vbNullString         'ﾛｯﾄｺﾒﾝﾄ内容
                            ptypHoldConnect.strNextCommnents = vbNullString     'SB連絡ｺﾒﾝﾄ内容
                            ptypHoldConnect.strLastUpdate = vbNullString        '最終更新日時
                        End If
                    End With
                
                '@保留在庫
                Case CMlngHoldTab
                
                    With vsfLotListHold
                        '@ﾀｲﾄﾙ以外
                        If .Row > 0 Then
                            ptypHoldConnect.strCarrierId = .GetData(.Row, CMlngvsfHoldColCarrierID)        'ｷｬﾘｱID
                            ptypHoldConnect.strLotID = .GetData(.Row, CMlngvsfHoldColLotID)                'ﾛｯﾄID
                            ptypHoldConnect.strFlowClass = .GetData(.Row, CMlngvsfHoldColFlowClass)        '流動区分
                            ptypHoldConnect.strLotHoldFlg = vbNullString                                   '保留ﾌﾗｸﾞ
                            ptypHoldConnect.strLastUpdate = .GetData(.Row, CMlngvsfHoldColLastUpdate)      '最終更新日時
                            ptypHoldConnect.strHoldTremDate = .GetData(.Row, CMlngvsfHoldColHoldTimeEnd)   '保留期限
                            ptypHoldConnect.strHoldEmpID = .GetData(.Row, CMlngvsfHoldColHoldEmpID)        '保留責任者ID
                            ptypHoldConnect.strHoldEmpName = .GetData(.Row, CMlngvsfHoldColHoldEmp)        '保留責任者名
                            ptypHoldConnect.strReasonCode = .GetData(.Row, CMlngvsfHoldColHoldReason)      '保留理由
                            ptypHoldConnect.strCommnents = .GetData(.Row, CMlngvsfHoldColLotComments)      'ｺﾒﾝﾄ
                            ptypHoldConnect.lngTabFlag = CMlngHoldTab                                      'ﾀﾌﾞﾌﾗｸﾞ
                            ptypHoldConnect.strSbID = vbNullString                                         '退避処理区分(中間在庫のみ使用)
                            ptypHoldConnect.strNextCommnents = vbNullString                                '次SB連絡
                            ptypHoldConnect.strSlotSize = .GetData(.Row, CMlngvsfHoldColSlotSize)          'ｽﾛｯﾄｻｲｽﾞ
                            ptypHoldConnect.strChipQuantity = vbNullString                                 'ﾁｯﾌﾟ数量
                            ptypHoldConnect.blnOuterSendFlag = False                                       '外部送品ﾌﾗｸﾞ
                            ptypHoldConnect.strPdId = .GetData(.Row, CMlngvsfHoldColPDName)                '機種
                            ptypHoldConnect.strOpID = .GetData(.Row, CMlngvsfHoldColOpID)                  '大工程
                            ptypHoldConnect.strStepID = .GetData(.Row, CMlngvsfHoldColStepID)              '小工程
                            ptypHoldConnect.strEngEmpId = .GetData(.Row, CMlngvsfHoldColLotManagerID)      'ﾛｯﾄ担当者ID
                            ptypHoldConnect.strEngEmpName = .GetData(.Row, CMlngvsfHoldColLotManagerName)  'ﾛｯﾄ担当者名
                            
                            '@結果OKを返す
                            prvHoldConnect_Set = True
                        Else
                            ptypHoldConnect.strCarrierId = vbNullString         'ｷｬﾘｱID
                            ptypHoldConnect.strLotID = vbNullString             'ﾛｯﾄID
                            ptypHoldConnect.strFlowClass = vbNullString         '流動区分
                            ptypHoldConnect.strLotHoldFlg = vbNullString        '保留ﾌﾗｸﾞ
                            ptypHoldConnect.strLastUpdate = vbNullString        '最終更新日時
                            ptypHoldConnect.strHoldTremDate = vbNullString      '保留期限
                            ptypHoldConnect.strHoldEmpID = vbNullString         '保留責任者ID
                            ptypHoldConnect.strHoldEmpName = vbNullString       '保留責任者名
                            ptypHoldConnect.strReasonCode = vbNullString        '保留理由
                            ptypHoldConnect.strCommnents = vbNullString         'ｺﾒﾝﾄ
                            ptypHoldConnect.lngTabFlag = CMlngHoldTab           'ﾀﾌﾞﾌﾗｸﾞ
                            ptypHoldConnect.strSbID = vbNullString              '退避処理区分(中間在庫のみ使用)
                            ptypHoldConnect.strNextCommnents = vbNullString     '次SB連絡
                            ptypHoldConnect.strHoldComments = vbNullString      '保留ｺﾒﾝﾄ内容
                            ptypHoldConnect.strSlotSize = vbNullString          'ｽﾛｯﾄｻｲｽﾞ
                            ptypHoldConnect.strChipQuantity = vbNullString      'ﾁｯﾌﾟ数量
                            ptypHoldConnect.blnOuterSendFlag = False            '外部送品ﾌﾗｸﾞ
                            ptypHoldConnect.strPdId = vbNullString              '機種
                            ptypHoldConnect.strOpID = vbNullString              '大工程
                            ptypHoldConnect.strStepID = vbNullString            '小工程
                            ptypHoldConnect.strEngEmpId = vbNullString          'ﾛｯﾄ担当者ID
                            ptypHoldConnect.strEngEmpName = vbNullString        'ﾛｯﾄ担当者名
                        End If
                    End With
                
                '@中間在庫
                Case CMlngWFTab
                
                    With vsfLotListWF
                        '@ﾀｲﾄﾙ以外
                        If .Row > 0 Then
                            ptypHoldConnect.strCarrierId = _
                                .GetData(.Row, CMlngvsfWFColCarrierID)                  'ｷｬﾘｱID
                            ptypHoldConnect.strLotID = vbNullString                     'ﾛｯﾄID
                            ptypHoldConnect.strFlowClass = vbNullString                 '流動区分
                            ptypHoldConnect.strLotHoldFlg = vbNullString                '保留ﾌﾗｸﾞ
                            ptypHoldConnect.strLastUpdate = vbNullString                '最終更新日時
                            ptypHoldConnect.strHoldTremDate = vbNullString              '保留期限
                            ptypHoldConnect.strHoldEmpID = vbNullString                 '保留責任者ID
                            ptypHoldConnect.strHoldEmpName = vbNullString               '保留責任者名
                            ptypHoldConnect.strReasonCode = vbNullString                '保留理由
                            ptypHoldConnect.strCommnents = vbNullString                 'ｺﾒﾝﾄ
                            ptypHoldConnect.lngTabFlag = CMlngWFTab                     'ﾀﾌﾞﾌﾗｸﾞ
                            ptypHoldConnect.strSbID = mstrTaihiSBID0                    '退避処理区分
                            ptypHoldConnect.strNextCommnents = vbNullString             '次SB連絡
                            ptypHoldConnect.strHoldComments = vbNullString              '保留ｺﾒﾝﾄ内容
                            ptypHoldConnect.strSlotSize = vbNullString                  'ｽﾛｯﾄｻｲｽﾞ
                            ptypHoldConnect.strChipQuantity = vbNullString              'ﾁｯﾌﾟ数量
                            ptypHoldConnect.blnOuterSendFlag = False                    '外部送品ﾌﾗｸﾞ
                            ptypHoldConnect.strPdId = vbNullString                      '機種
                            ptypHoldConnect.strOpID = vbNullString                      '大工程
                            ptypHoldConnect.strStepID = vbNullString                    '小工程
                            ptypHoldConnect.strEngEmpId = vbNullString                  'ﾛｯﾄ担当者ID
                            ptypHoldConnect.strEngEmpName = vbNullString                'ﾛｯﾄ担当者
                            
                            '@結果OKを返す
                            prvHoldConnect_Set = True
                        Else
                            ptypHoldConnect.strCarrierId = vbNullString         'ｷｬﾘｱID
                            ptypHoldConnect.strLotID = vbNullString             'ﾛｯﾄID
                            ptypHoldConnect.strFlowClass = vbNullString         '流動区分
                            ptypHoldConnect.strLotHoldFlg = vbNullString        '保留ﾌﾗｸﾞ
                            ptypHoldConnect.strLastUpdate = vbNullString        '最終更新日時
                            ptypHoldConnect.strHoldTremDate = vbNullString      '保留期限
                            ptypHoldConnect.strHoldEmpID = vbNullString         '保留責任者
                            ptypHoldConnect.strHoldEmpName = vbNullString       '保留責任者名
                            ptypHoldConnect.strReasonCode = vbNullString        '保留理由
                            ptypHoldConnect.strCommnents = vbNullString         'ｺﾒﾝﾄ
                            ptypHoldConnect.lngTabFlag = CMlngWFTab             'ﾀﾌﾞﾌﾗｸﾞ
                            ptypHoldConnect.strSbID = vbNullString              '退避処理区分
                            ptypHoldConnect.strNextCommnents = vbNullString     '次SB連絡
                            ptypHoldConnect.strHoldComments = vbNullString      '保留ｺﾒﾝﾄ内容
                            ptypHoldConnect.strSlotSize = vbNullString          'ｽﾛｯﾄｻｲｽﾞ
                            ptypHoldConnect.strChipQuantity = vbNullString      'ﾁｯﾌﾟ数量
                            ptypHoldConnect.blnOuterSendFlag = False            '外部送品ﾌﾗｸﾞ
                            ptypHoldConnect.strPdId = vbNullString              '機種
                            ptypHoldConnect.strOpID = vbNullString              '大工程
                            ptypHoldConnect.strStepID = vbNullString            '小工程
                            ptypHoldConnect.strEngEmpId = vbNullString          'ﾛｯﾄ担当者ID
                            ptypHoldConnect.strEngEmpName = vbNullString        'ﾛｯﾄ担当者
                        End If
                    End With
                
                '@完成在庫
                Case CMlngSendTab
                
                    '@送品待ち/送品済み判定追加
                    Select Case True
                        Case optLotSendStatus0.Checked
                            '@送品待ちの場合
                            With vsfLotListSend
                                '@ﾀｲﾄﾙ以外
                                If .Row > 0 Then
                                    ptypHoldConnect.strCarrierId = .GetData(.Row, CMlngvsfSendColCarrierID)        'ｷｬﾘｱID
                                    ptypHoldConnect.strLotID = .GetData(.Row, CMlngvsfSendColLotID)                'ﾛｯﾄID
                                    ptypHoldConnect.strFlowClass = .GetData(.Row, CMlngvsfSendColFlowClass)        '流動区分
                                    ptypHoldConnect.strLotHoldFlg = vbNullString                                   '保留ﾌﾗｸﾞ
                                    ptypHoldConnect.strLastUpdate = .GetData(.Row, CMlngvsfSendColLastUpdate)      '最終更新日時
                                    ptypHoldConnect.strHoldTremDate = .GetData(.Row, CMlngvsfSendColHoldTimeEnd)   '保留期限
                                    ptypHoldConnect.strHoldEmpID = .GetData(.Row, CMlngvsfSendColHoldEmpID)        '保留責任者ID
                                    ptypHoldConnect.strHoldEmpName = .GetData(.Row, CMlngvsfSendColHoldEmp)        '保留責任者名
                                    ptypHoldConnect.strReasonCode = .GetData(.Row, CMlngvsfSendColHoldReason)      '保留理由
                                    ptypHoldConnect.strCommnents = .GetData(.Row, CMlngvsfSendColLotComments)      'ｺﾒﾝﾄ
                                    ptypHoldConnect.lngTabFlag = CMlngSendTab                                      'ﾀﾌﾞﾌﾗｸﾞ
                                    ptypHoldConnect.strSbID = vbNullString                                         '退避処理区分(中間在庫のみ使用)
                                    ptypHoldConnect.strNextCommnents = .GetData(.Row, CMlngvsfSendColComment)      '次SB連絡
                                    ptypHoldConnect.strHoldComments = .GetData(.Row, CMlngvsfSendColHoldComments)  '保留ｺﾒﾝﾄ内容
                                    ptypHoldConnect.strSlotSize = .GetData(.Row, CMlngvsfSendColSlotSize)          'ｽﾛｯﾄｻｲｽﾞ
                                    ptypHoldConnect.strChipQuantity = vbNullString                                 'ﾁｯﾌﾟ数量
                                    ptypHoldConnect.blnOuterSendFlag = False                                       '外部送品ﾌﾗｸﾞ
                                    ptypHoldConnect.strPdId = .GetData(.Row, CMlngvsfSendColPDName)                '機種
                                    ptypHoldConnect.strOpID = vbNullString                                         '大工程
                                    ptypHoldConnect.strStepID = vbNullString                                       '小工程
                                    ptypHoldConnect.strEngEmpId = .GetData(.Row, CMlngvsfSendColLotManagerID)      'ﾛｯﾄ担当者ID
                                    ptypHoldConnect.strEngEmpName = .GetData(.Row, CMlngvsfSendColLotManagerName)  'ﾛｯﾄ担当者名
                                    ptypHoldConnect.strGrbClass = .GetData(.Row, CMlngvsfSendColGrbClass)          'GRB区分

                                    '@結果OKを返す
                                    prvHoldConnect_Set = True
                                Else
                                    ptypHoldConnect.strCarrierId = vbNullString         'ｷｬﾘｱID
                                    ptypHoldConnect.strLotID = vbNullString             'ﾛｯﾄID
                                    ptypHoldConnect.strFlowClass = vbNullString         '流動区分
                                    ptypHoldConnect.strLotHoldFlg = vbNullString        '保留ﾌﾗｸﾞ
                                    ptypHoldConnect.strLastUpdate = vbNullString        '最終更新日時
                                    ptypHoldConnect.strHoldTremDate = vbNullString      '保留期限
                                    ptypHoldConnect.strHoldEmpID = vbNullString         '保留責任者ID
                                    ptypHoldConnect.strHoldEmpName = vbNullString       '保留責任者名
                                    ptypHoldConnect.strReasonCode = vbNullString        '保留理由
                                    ptypHoldConnect.strCommnents = vbNullString         'ｺﾒﾝﾄ
                                    ptypHoldConnect.lngTabFlag = CMlngSendTab           'ﾀﾌﾞﾌﾗｸﾞ
                                    ptypHoldConnect.strSbID = vbNullString              '退避処理区分(中間在庫のみ使用)
                                    ptypHoldConnect.strNextCommnents = vbNullString     '次SB連絡
                                    ptypHoldConnect.strHoldComments = vbNullString      '保留ｺﾒﾝﾄ内容
                                    ptypHoldConnect.strSlotSize = vbNullString          'ｽﾛｯﾄｻｲｽﾞ
                                    ptypHoldConnect.strChipQuantity = vbNullString      'ﾁｯﾌﾟ数量
                                    ptypHoldConnect.blnOuterSendFlag = False            '外部送品ﾌﾗｸﾞ
                                    ptypHoldConnect.strPdId = vbNullString              '機種
                                    ptypHoldConnect.strOpID = vbNullString              '大工程
                                    ptypHoldConnect.strStepID = vbNullString            '小工程
                                    ptypHoldConnect.strEngEmpId = vbNullString          'ﾛｯﾄ担当者ID
                                    ptypHoldConnect.strEngEmpName = vbNullString        'ﾛｯﾄ担当者
                                    ptypHoldConnect.strGrbClass = vbNullString          'GRB区分
                                End If
                            End With
                        
                        '@送品済みの場合
                        Case optLotSendStatus1.Checked
                            
                            With vsfLotListSend
                                '@ﾀｲﾄﾙ以外
                                If .Row > 0 Then
                                    ptypHoldConnect.strCarrierId = .GetData(.Row, CMlngvsfSend2ColCarrierID)       'ｷｬﾘｱID
                                    ptypHoldConnect.strLotID = .GetData(.Row, CMlngvsfSend2ColLotID)               'ﾛｯﾄID
                                    ptypHoldConnect.strFlowClass = .GetData(.Row, CMlngvsfSend2ColFlowClass)       '流動区分
                                    ptypHoldConnect.strLotHoldFlg = vbNullString                                   '保留ﾌﾗｸﾞ
                                    ptypHoldConnect.strLastUpdate = .GetData(.Row, CMlngvsfSend2ColLastUpdate)     '最終更新日時
                                    ptypHoldConnect.strHoldTremDate = vbNullString                                 '保留期限
                                    ptypHoldConnect.strHoldEmpID = vbNullString                                    '保留責任者ID
                                    ptypHoldConnect.strHoldEmpName = vbNullString                                  '保留責任者名
                                    ptypHoldConnect.strReasonCode = vbNullString                                   '保留理由
                                    ptypHoldConnect.strCommnents = .GetData(.Row, CMlngvsfSend2ColLotComments)     'ｺﾒﾝﾄ
                                    ptypHoldConnect.lngTabFlag = CMlngSendTab                                      'ﾀﾌﾞﾌﾗｸﾞ
                                    ptypHoldConnect.strSbID = vbNullString                                         '退避処理区分(中間在庫のみ使用)
                                    ptypHoldConnect.strNextCommnents = .GetData(.Row, CMlngvsfSend2ColComment)     '次SB連絡
                                    ptypHoldConnect.strHoldComments = vbNullString                                 '保留ｺﾒﾝﾄ内容
                                    ptypHoldConnect.strSlotSize = .GetData(.Row, CMlngvsfSend2ColSlotSize)         'ｽﾛｯﾄｻｲｽﾞ
                                    ptypHoldConnect.strChipQuantity = vbNullString                                 'ﾁｯﾌﾟ数量
                                    ptypHoldConnect.blnOuterSendFlag = False                                       '外部送品ﾌﾗｸﾞ
                                    ptypHoldConnect.strPdId = .GetData(.Row, CMlngvsfSend2ColPDName)               '機種
                                    ptypHoldConnect.strOpID = vbNullString                                         '大工程
                                    ptypHoldConnect.strStepID = vbNullString                                       '小工程
                                    ptypHoldConnect.strEngEmpId = .GetData(.Row, CMlngvsfSend2ColLotManagerID)     'ﾛｯﾄ担当者ID
                                    ptypHoldConnect.strEngEmpName = .GetData(.Row, CMlngvsfSend2ColLotManagerName) 'ﾛｯﾄ担当者名
                                    ptypHoldConnect.strGrbClass = .GetData(.Row, CMlngvsfSend2ColGrbClass)         'GRB区分
                                    
                                    '@結果OKを返す
                                    prvHoldConnect_Set = True
                                Else
                                    ptypHoldConnect.strCarrierId = vbNullString         'ｷｬﾘｱID
                                    ptypHoldConnect.strLotID = vbNullString             'ﾛｯﾄID
                                    ptypHoldConnect.strFlowClass = vbNullString         '流動区分
                                    ptypHoldConnect.strLotHoldFlg = vbNullString        '保留ﾌﾗｸﾞ
                                    ptypHoldConnect.strLastUpdate = vbNullString        '最終更新日時
                                    ptypHoldConnect.strHoldTremDate = vbNullString      '保留期限
                                    ptypHoldConnect.strHoldEmpID = vbNullString         '保留責任者ID
                                    ptypHoldConnect.strHoldEmpName = vbNullString       '保留責任者名
                                    ptypHoldConnect.strReasonCode = vbNullString        '保留理由
                                    ptypHoldConnect.strCommnents = vbNullString         'ｺﾒﾝﾄ
                                    ptypHoldConnect.lngTabFlag = CMlngSendTab           'ﾀﾌﾞﾌﾗｸﾞ
                                    ptypHoldConnect.strSbID = vbNullString              '退避処理区分(中間在庫のみ使用)
                                    ptypHoldConnect.strNextCommnents = vbNullString     '次SB連絡
                                    ptypHoldConnect.strHoldComments = vbNullString      '保留ｺﾒﾝﾄ内容
                                    ptypHoldConnect.strSlotSize = vbNullString          'ｽﾛｯﾄｻｲｽﾞ
                                    ptypHoldConnect.strChipQuantity = vbNullString      'ﾁｯﾌﾟ数量
                                    ptypHoldConnect.blnOuterSendFlag = False            '外部送品ﾌﾗｸﾞ
                                    ptypHoldConnect.strPdId = vbNullString              '機種
                                    ptypHoldConnect.strOpID = vbNullString              '大工程
                                    ptypHoldConnect.strStepID = vbNullString            '小工程
                                    ptypHoldConnect.strEngEmpId = vbNullString          'ﾛｯﾄ担当者ID
                                    ptypHoldConnect.strEngEmpName = vbNullString        'ﾛｯﾄ担当者
                                    ptypHoldConnect.strGrbClass = vbNullString          'GRB区分
                                End If
                            End With
                    End Select
                
                '@CF完成在庫
                Case CMlngCFEndTab
                
                    With vsfLotListCFEnd
                        '@ﾀｲﾄﾙ以外
                        If .Row > 0 Then
                            ptypHoldConnect.strCarrierId = .GetData(.Row, CMlngvsfCFEndColCarrierID)           'ｷｬﾘｱID
                            ptypHoldConnect.strLotID = .GetData(.Row, CMlngvsfCFEndColLotID)                   'ﾛｯﾄID
                            ptypHoldConnect.strFlowClass = .GetData(.Row, CMlngvsfCFEndColFlowClass)           '流動区分
                            ptypHoldConnect.strLotHoldFlg = vbNullString                                       '保留ﾌﾗｸﾞ
                            ptypHoldConnect.strLastUpdate = .GetData(.Row, CMlngvsfCFEndColLastUpdate)         '最終更新日時
                            ptypHoldConnect.strHoldTremDate = .GetData(.Row, CMlngvsfCFEndColHoldTimeEnd)      '保留期限
                            ptypHoldConnect.strHoldEmpID = .GetData(.Row, CMlngvsfCFEndColHoldEmpID)           '保留責任者ID
                            ptypHoldConnect.strHoldEmpName = .GetData(.Row, CMlngvsfCFEndColHoldEmp)           '保留責任者名
                            ptypHoldConnect.strReasonCode = .GetData(.Row, CMlngvsfCFEndColHoldReason)         '保留理由
                            ptypHoldConnect.strCommnents = .GetData(.Row, CMlngvsfCFEndColLotComments)         'ｺﾒﾝﾄ
                            ptypHoldConnect.lngTabFlag = CMlngCFEndTab                                         'ﾀﾌﾞﾌﾗｸﾞ
                            ptypHoldConnect.strSbID = vbNullString                                             '退避処理区分(中間在庫のみ使用)
                            ptypHoldConnect.strNextCommnents = vbNullString                                    '次SB連絡ｺﾒﾝﾄ
                            ptypHoldConnect.strHoldComments = .GetData(.Row, CMlngvsfCFEndColHoldComments)     '保留ｺﾒﾝﾄ内容
                            ptypHoldConnect.strSlotSize = vbNullString                                         'ｽﾛｯﾄｻｲｽﾞ
                            ptypHoldConnect.strChipQuantity = .GetData(.Row, CMlngvsfCFEndColCfNum)            'ﾁｯﾌﾟ数量
                            ptypHoldConnect.blnOuterSendFlag = False                                           '外部送品ﾌﾗｸﾞ
                            ptypHoldConnect.strPdId = .GetData(.Row, CMlngvsfCFEndColPDName)                   '機種
                            ptypHoldConnect.strOpID = vbNullString                                             '大工程
                            ptypHoldConnect.strStepID = vbNullString                                           '小工程
                            ptypHoldConnect.strEngEmpId = .GetData(.Row, CMlngvsfCFEndColLotManagerID)         'ﾛｯﾄ担当者ID
                            ptypHoldConnect.strEngEmpName = .GetData(.Row, CMlngvsfCFEndColLotManagerName)     'ﾛｯﾄ担当者名
                            
                            '@結果OKを返す
                            prvHoldConnect_Set = True
                        Else
                            ptypHoldConnect.strCarrierId = vbNullString         'ｷｬﾘｱID
                            ptypHoldConnect.strLotID = vbNullString             'ﾛｯﾄID
                            ptypHoldConnect.strFlowClass = vbNullString         '流動区分
                            ptypHoldConnect.strLotHoldFlg = vbNullString        '保留ﾌﾗｸﾞ
                            ptypHoldConnect.strLastUpdate = vbNullString        '最終更新日時
                            ptypHoldConnect.strHoldTremDate = vbNullString      '保留期限
                            ptypHoldConnect.strHoldEmpID = vbNullString         '保留責任者ID
                            ptypHoldConnect.strHoldEmpName = vbNullString       '保留責任者名
                            ptypHoldConnect.strReasonCode = vbNullString        '保留理由
                            ptypHoldConnect.strCommnents = vbNullString         'ｺﾒﾝﾄ
                            ptypHoldConnect.lngTabFlag = CMlngSendTab           'ﾀﾌﾞﾌﾗｸﾞ
                            ptypHoldConnect.strSbID = vbNullString              '退避処理区分(中間在庫のみ使用)
                            ptypHoldConnect.strNextCommnents = vbNullString     '次SB連絡
                            ptypHoldConnect.strHoldComments = vbNullString      '保留ｺﾒﾝﾄ内容
                            ptypHoldConnect.strSlotSize = vbNullString          'ｽﾛｯﾄｻｲｽﾞ
                            ptypHoldConnect.strChipQuantity = vbNullString      'ﾁｯﾌﾟ数量
                            ptypHoldConnect.blnOuterSendFlag = False            '外部送品ﾌﾗｸﾞ
                            ptypHoldConnect.strPdId = vbNullString              '機種
                            ptypHoldConnect.strOpID = vbNullString              '大工程
                            ptypHoldConnect.strStepID = vbNullString            '小工程
                            ptypHoldConnect.strEngEmpId = vbNullString          'ﾛｯﾄ担当者ID
                            ptypHoldConnect.strEngEmpName = vbNullString        'ﾛｯﾄ担当者
                        End If
                    End With
            End Select
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvHoldConnect_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvCmbSbID_Disp
    '機　能：利用SB表示
    '引　数：ltypMasSbList：ｼｽﾃﾑﾌﾞﾛｯｸ構造体
    '戻り値：なし
    '作成日：2004/09/20 (Mon) 15:06:21 N.Kasai
    '更新日：2004/09/20 (Mon) 15:06:21 N.Kasai
    '備　考：
    Private Sub prvcmbSbID_Disp()

        Dim llngCnt             As Integer              'ｶｳﾝﾄ
        Dim llngDispIndex       As Integer              '表示用ｲﾝﾃﾞｯｸｽ

        Try
            
            '@ｷｬﾘｱ登録Tab
            With cmbSBID0
                '@利用SB初期化
                .Clear
                .DispCols = CMlngCmbDispCol2                                 'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                '値取得列
                .GetCol = CMlngCmbGetCol0                                    '表示列
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                                   'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)               'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .ColAlignment(CMlngCmbGetCol0) = TextAlignEnum.LeftCenter    '左寄中央揃え
                .ColAlignment(CMlngCmbGetCol1) = TextAlignEnum.LeftCenter    '左寄中央揃え
                .DirectInput = False                                         '直接入力(Flase)
                .BackColor = SystemColors.Window
                '@利用SBがない場合
                If mtypMasSbList.lngSbListCnt = 0 Then
                    Exit Sub
                End If
                
                '@利用SBがなくなるまで
                For llngCnt = 0 To mtypMasSbList.lngSbListCnt -1
                    .AddItem(mtypMasSbList.typSbList(llngCnt).strSBName & vbTab & _
                             mtypMasSbList.typSbList(llngCnt).strSbID)             'ｼｽﾃﾑﾌﾞﾛｯｸID&ｼｽﾃﾑﾌﾞﾛｯｸ名
                
                If pstrSBID = mtypMasSbList.typSbList(llngCnt).strSbID Then
                    '@利用SB退避領域に値格納(初回)
                    mstrTaihiSBID0 = pstrSBID
                    llngDispIndex = llngCnt
                End If
                
                Next llngCnt
                         
                '@初期表示
                .ListIndex = llngDispIndex
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbSbID_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotListSend_Edit
    '機　能：ｸﾞﾘｯﾄﾞ編集(ﾁｪｯｸﾎﾞｯｸｽ,ﾘｽﾄ選択,ｺﾒﾝﾄ入力)を許可する制御
    '引　数：llngEditFlg：制御の判断ﾌﾗｸﾞ(1=ﾏｳｽ,2=ｷｰﾎﾞｰﾄﾞ)
    '　　　：llngKeyCode：ｷｰｺｰﾄﾞ(0:ﾏｳｽ(定義),32(vbKeySpace):ｽﾍﾟｰｽｷｰ)
    '戻り値：なし
    '作成日：2004/08/04 (Wed) 16:40:31 N.Kasai
    '更新日：2012/10/18 (Thu) 18:35:55 T.Oide
    '備　考：@次SB連絡有無をｸﾘｱで"なし"をいれる
    '　　　：2004/10/12 (Tue) 14:07:35 N.Kasai      ﾁｪｯｸﾎﾞｯｸｽ以外は処理を行わない
    '　　　：2004/10/21 (Thu) 11:21:42 Y.Yamagishi  次SB連絡有無をｸﾘｱで"なし"をいれない(不具合改善№141)
    '　　　：2004/11/25 (Thu) 19:10:56 H.Wajima     送品待ち/送品済み判定追加
    '　　　：2004/12/13 (Mon) 11:13:36 H.Wajima     「送品日の異なるロットは同時に選択できません」のﾒｯｾｰｼﾞが複数回表示される問題を修正(不具合改善№320)
    '　　　：2004/12/17 (Fri) 16:07:57 H.Wajima     ﾁｪｯｸONの10件制約を外す
    '　　　：2004/12/22 (Wed) 13:05:41 H.Wajima     箱№のｸﾘｱ処理を追加
    '　　　：2005/03/22 (Tue) 13:47:34 S.Deguchi    送品取消処理を行う処理を追加
    '　　　：2006/02/16 (Thu) 15:06:13 N.Kojima     ｺﾒﾝﾄ「あり/なし」により、ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝを制御する。(不具合№3430対応)
    '　　　：2006/09/25 (Mon) 13:47:01 N.Kojima     量産ﾛｯﾄの送品先指定機能追加に伴い、処理修正。(案件№01452)
    '　　　：2007/05/11 (Fri) 14:04:19 M.Miura      量産ﾛｯﾄは送品先変更不可にする(案件№1895)
    '　　　：2012/10/18 (Thu) 14:14:31 T.Oide       R9-05(EPPI送品対応)
    Private Sub prvvsfLotListSend_Edit(ByRef llngEditFlg As Integer, ByRef llngKeyCode As Short)

        Dim lblnAns             As Boolean      '汎用戻り値
        Dim lblnRet             As Boolean      '戻り値
        Dim lstrFunctionID      As String       '機能ID
        Dim lstrActionID        As String       'アクションID
        Dim lstrEmpID           As String       'ﾕｰｻﾞID
        Dim lstrEmpName         As String       'ﾕｰｻﾞ名
        Dim lstrSBID            As String       'SB_ID
        Dim lstrEventName       As String       'イベント名
        Dim llngCnt             As Integer      'ｶｳﾝﾀ
        Dim llngAns             As Integer


        Try
            
            '@関数名設定
            lstrEventName = "prvvsfSBIDSendList_Set"
            
            With vsfLotListSend
                
                '@送品待ち/送品済みの判定
                Select Case True
                    
                    '@送品待ちの場合
                    Case optLotSendStatus0.Checked
                    
                        
                        '@選択された列が下記の場合には編集を可能にする
                        Select Case .Col
                            
                            '@ﾁｪｯｸﾎﾞｯｸｽ欄
                            Case CMlngvsfSendColKb
                                
                                'ﾁｪｯｸﾎﾞｯｸｽではない場合は処理を行わない。
                                If .GetCellCheck(.Row, CMlngvsfSendColKb) = CheckEnum.None Then
                                      Exit Sub
                                End If
                                
                                '@保留ﾌﾗｸﾞが立っていない場合
                                If .GetData(.Row, CMlngvsfSendColHoldFlag) <> CMstrLotHoldFlgOn Then
                                    
                                    '@ﾏｳｽ動作(ｸﾘｯｸ)の場合
                                    If llngEditFlg = CMlngMouseClick Then
                                    
                                        '@ｸﾞﾘｯﾄﾞを編集可能にする
                                        .StartEditing()
                                        
                                        If .GetCellCheck(.Row, CMlngvsfSendColKb) <> CheckEnum.Checked Then
                                            '@ﾁｪｯｸを外した場合
                                        
                                            '送品なしの場合
                                            If .GetData(.Row, CMlngvsfSendColLotSendFlag) = CPlngLotSendNasi Then
                                                '@送品先初期値へ
                                                .SetData(.Row, CMlngvsfSendColSendSBID, CMstrDispSendNasi)
                                            Else
                                                '@送品先をｸﾘｱ
                                                .SetData(.Row, CMlngvsfSendColSendSBID, vbNullString)
                                            End If
                                            
                                        Else
                                            '@ﾁｪｯｸをつけた場合
                                                                                
                                            '@起動SBにより処理を判定
                                            If pstrSBID = CPstrSBID1A0 Then
                                                '@基板
                                                .SetData(.Row, CMlngvsfSendColSendSBID, CPstrSBID2A0Name)
                                            Else
                                                '@組立
                                                '@ﾃﾞﾌｫﾙﾄの送品先を表示
                                                ' (構造体のﾃﾞｰﾀと表示されている行数が必ずしも一致しないので一致するロットIDを見つけて表示する)
                                                llngCnt = 0
                                                Do While mlngStockListCnt >= llngCnt
                                                
                                                    '@該当ロットと構造体のロットが同じか
                                                    If .GetData(.Row, CMlngvsfSendColLotID) = mtypstocklotlist(llngCnt).strLotID Then
                                                        '@一致したら表示
                                                        .SetData(.Row, CMlngvsfSendColSendSBID, mtypstocklotlist(llngCnt).strSendSBName)
                                                        Exit Do
                                                    End If
                                                    llngCnt = llngCnt + 1
                                                Loop
                                                    
                                                    
                                            End If
                                        End If
                                    Else
                                        '@ｷｰﾀﾞｳﾝ-ｽﾍﾟｰｽの場合のみ
                                        If llngKeyCode = Keys.Space Then
                                            
                                            '@ｸﾞﾘｯﾄﾞを編集可能にする
                                            .StartEditing()
                                            
                                            '@ﾁｪｯｸを外した場合
                                            If .GetCellCheck(.Row, CMlngvsfSendColKb) <> CheckEnum.Checked Then
                                                '送品なしの場合
                                                If .GetData(.Row, CMlngvsfSendColLotSendFlag) = CPlngLotSendNasi Then
                                                    '@送品先初期値へ
                                                    .SetData(.Row, CMlngvsfSendColSendSBID, CMstrDispSendNasi)
                                                Else
                                                    '@送品先をｸﾘｱ
                                                    .SetData(.Row, CMlngvsfSendColSendSBID, vbNullString)
                                                End If
                                                
        '                                        '@箱№をｸﾘｱ
        '                                        .Cell(flexcpText, .Row, CMlngvsfSendColBoxNo) = vbNullString
                                            Else
                                                '@ﾁｪｯｸをつけた場合
                                                
                                                '@起動SBにより処理を判定
                                                If pstrSBID = CPstrSBID1A0 Then
                                                    '@基板
                                                    .SetData(.Row, CMlngvsfSendColSendSBID, CPstrSBID2A0Name)
                                                Else
                                                    '@組立
                                                
                                                    '@ﾃﾞﾌｫﾙﾄの送品先を表示
                                                    .SetData(.Row, CMlngvsfSendColSendSBID, _
                                                        mtypstocklotlist(.GetData(.Row, CMlngvsfSendColNo) -1).strSendSBName)
                                                End If
                                            End If
                                        End If
                                    End If
                                    
                                    '@ﾕｰｻﾞによる列幅変更されていない場合
                                    If mtypChgSortSendTab.blnChgWidth = False Then
                                        '@列幅設定
                                        '.AutoSizeMode = flexAutoSizeColWidth
                                        .AutoSizeCol(CMlngvsfSendColSendSBID, 6)             '送品先
                                    End If
                                End If
                                
                            '@送品先ﾘｽﾄ欄
                            Case CMlngvsfSendColSendSBID
                                
        '@↓2018/07/23 (Mon) 16:17:58 Y.Yoneyama **************************************************
                                '@組立(2A0)での起動時のみ有効
                                If pstrSBID = CPstrSBID2A0 Or pstrSBID = CPstrSBID3A0 Then
        '@↑2018/07/23 (Mon) 16:17:58 Y.Yoneyama **************************************************
                                    
                                    '@保留ﾌﾗｸﾞが立っていない場合
                                    If .GetData(.Row, CMlngvsfSendColHoldFlag) <> CMstrLotHoldFlgOn Then
                                            
                                        '@ﾁｪｯｸが付いている場合
                                        If .GetCellCheck(.Row, CMlngvsfSendColKb) = CheckEnum.Checked Then
                                            
                                            '@送品ﾘｽﾄ作成処理へ
                                            Call prvvsfSBIDSendList_Set(.GetData(.Row, CMlngvsfSendColNo))
                                            
                                            '@ﾃﾞﾌｫﾙﾄ送品先も送品先ﾘｽﾄも空(NULL)の場合
                                            If mtypstocklotlist(.GetData(.Row, CMlngvsfSendColNo) -1).strSendSBID = vbNullString And _
                                                mtypSendSBListAns.lngSendSBListCnt = 0 Then
                                                
                                                '@編集不可
                                                .AllowEditing = False
                                            Else
                                            
                                                '@権限チェックで権限未ﾁｪｯｸで、量産品(PR or ES)か
                                                If mblnAuthorityChkFlag = False And _
                                                   (.GetData(.Row, CMlngvsfSendColFlowClass) = CPstrFlowClassPR Or _
                                                    .GetData(.Row, CMlngvsfSendColFlowClass) = CPstrFlowClassES) Then
                                                    
                                                    '@確認ﾒｯｾｰｼﾞ表示
                                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0123)
                                                    '@<TRM123W>$$量産ロット(PR、ES)の送品先を変更しようとしています。
                                                    '　　　　　$$$よろしいですか？
                                                    llngAns = publngMsgBox(pstrDMsg, vbNo, Me.Text, True, 16)
                                                    
                                                    '@いいえの場合は処理を中止
                                                    If llngAns = vbNo Then
                                                        Exit Sub
                                                    End If
                                                    
                                                    
                                                    '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
                                                    frmxxCM0020.Instance.ShowDialog(Me)
                                                    frmxxCM0020.Instance = Nothing
                                                    
                                                    '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
                                                    If pblnCancel = True Then
                                                        Exit Sub
                                                    End If
                                                    
                                                    '@ﾚｽﾎﾟﾝｽ取得開始
                                                    Call pubResponseStart(Me.Name, lstrEventName)
                                                
                                                    '@実行権限の処理を追加
                                                    lstrFunctionID = CPstrKeyEN00F0             '機能ID: EN00F0
                                                    lstrActionID = CPstrProductLotSendChange    'ｱｸｼｮﾝID：量産Lot送品先変更
                                                    lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
                                                    lstrEmpName = pstrUserName                  'ﾕｰｻﾞｰ名
                                                    lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                                                
                                                    '@実行権限ﾁｪｯｸ
                                                    lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, lstrEmpID, lstrEmpName, lstrSBID)
                                                    '@結果判定
                                                    If lblnAns = True Then
                                                        
                                                        '@権限確認済みﾌﾗｸﾞｾｯﾄ
                                                        mblnAuthorityChkFlag = True
                                                        
                                                        '@ﾚｽﾎﾟﾝｽ取得終了
                                                        Call publngResponseEnd(Me.Name, lstrEventName)
                                                         
                                                        '@ｸﾞﾘｯﾄﾞを編集可能にする
                                                        .StartEditing()
                                                        
                                                    Else
                                                        
                                                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                                        Call pubResponseCancel(Me.Name, lstrEventName)
                                                
                                                        '@表示ﾒｯｾｰｼﾞ変換
                                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
                                                        '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                                
                                                        '@編集不可
                                                        .AllowEditing = False

                                                    End If
                                                    
                                                Else
                                                    '権限ﾁｪｯｸ済みまたは、量産品以外の場合
                                                    '@ｸﾞﾘｯﾄﾞを編集可能にする
                                                    .StartEditing()
                                                End If
                                            End If
                                            
                                        Else
                                            '@編集不可
                                            .AllowEditing = False
                                        End If
                                    End If
                                    
                                Else
                                    '@基板の場合
                                
                                    '@編集不可
                                    .AllowEditing = False
                                End If
                                
                            '@箱№欄
                            Case CMlngvsfSendColBoxNo
                            
                                '@組立(2A0)での起動時のみ有効
                                If pstrSBID = CPstrSBID2A0 Then
                                    
                                    '@保留ﾌﾗｸﾞの判定
                                    If .GetData(.Row, CMlngvsfSendColHoldFlag) <> CMstrLotHoldFlgOn Then
                                        
                                        '@保留ﾌﾗｸﾞが立っていない場合
                                        If .GetCellCheck(.Row, CMlngvsfSendColKb) = CheckEnum.Checked Then
                                            '@ﾁｪｯｸが付いている場合
                                            
                                            '@SBｼｽﾃﾑﾌﾗｸﾞの判定
                                            If .GetData(.Row, CMlngvsfSendColSBSystemFlag) = "0" Then
                                                '@ｸﾞﾘｯﾄﾞを編集可能にする
                                                .StartEditing()
                                                .Editor.BackColor = .GetCellStyleDisplay(.Row, CMlngvsfSendColBoxNo).BackColor
                                                .Editor.ForeColor = .GetCellStyleDisplay(.Row, CMlngvsfSendColBoxNo).ForeColor
                                                'NSYS フォーカス移動時にエラーチェック
                                                cmdSendRegist.CausesValidation = True
                                                cmdLotExamInfo.CausesValidation = True
                                                cmdSendOrderList.CausesValidation = True
                                                cmdNextCommentSend.CausesValidation = True
                                                cmdCommentSend.CausesValidation = True
                                                cmdWFSend.CausesValidation = True
                                                cmdCancelSend.CausesValidation = True
                                                cmdHoldSend.CausesValidation = True
                                                cmdSendWFInfo.CausesValidation = True
                                                cmdCopy.CausesValidation = True
                                                cmdClose.CausesValidation = True

                                            End If
                                        End If
                                    End If
                                Else
                                    '@基板の場合
                                
                                    '@編集不可
                                    .AllowEditing = False
                                End If
                            
                            Case Else
                                '@上記以外
                                
                                '@編集不可
                                .AllowEditing = False
                        End Select
                        
                        '@送品可否判定
                        lblnRet = prvblnLotSend_Chk
                        '@戻り値の判定
                        If lblnRet = True Then
                        '@送品可の場合
                            '@送品ﾎﾞﾀﾝ活性化
                            cmdSendRegist.Enabled = True
                        Else
                        '@送品不可の場合
                            '@送品ﾎﾞﾀﾝ非活性化
                            cmdSendRegist.Enabled = False
                        End If
                    
                    '@送品済みが選択された場合
                    Case optLotSendStatus1.Checked
                    
                        '@選択された列が下記の場合には編集を可能にする
                        Select Case .Col
                        
                            '@ﾁｪｯｸﾎﾞｯｸｽ列の場合
                            Case CMlngvsfSend2ColCB
                            
                                '@動作の判定
                                Select Case True
                                    
                                    '@ﾏｳｽによるｸﾘｯｸか、ｷｰﾀﾞｳﾝｽﾍﾟｰｽの場合
                                    Case llngEditFlg = CMlngMouseClick, llngKeyCode = Keys.Space
                                    
                                        '@ｸﾞﾘｯﾄﾞを編集可能にする
                                        .StartEditing()
                                        
                                        '@ﾁｪｯｸOn/Offの判定
                                        Select Case .GetCellCheck(.Row, CMlngvsfSend2ColCB)
                                            Case CheckEnum.Unchecked
                                                '@ﾁｪｯｸを外した場合
                                                
                                            Case CheckEnum.Checked
                                                '@ﾁｪｯｸをつけた場合
                                        End Select
                                End Select
                                
                            Case Else
                                '@上記以外の場合
                                
                                '@編集不可
                                .AllowEditing = False
                        End Select
                        
                        '@ﾛｯﾄｺﾒﾝﾄ表示ﾎﾞﾀﾝ 使用可否判定
                        If .GetData(.Row, CMlngvsfSend2ColLotCommentDisp) = CPstrAriFlg Then
                        '@ﾛｯﾄｺﾒﾝﾄ有無が、「あり」の場合
                            '@ﾛｯﾄｺﾒﾝﾄ表示ﾎﾞﾀﾝ有効
                            cmdCommentSend.Enabled = True
                        Else
                        '@上記以外の場合(ﾛｯﾄｺﾒﾝﾄなし)
                            '@ﾛｯﾄｺﾒﾝﾄ表示ﾎﾞﾀﾝ無効
                            cmdCommentSend.Enabled = False
                        End If
                                        
                        '@送品ﾎﾞﾀﾝの使用可否判定
                        Call prvvsfSend2CmdStatus_Chk()
                End Select
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListSend_Edit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSBIDSendList_Set
    '機　能：ｸﾞﾘｯﾄﾞ項目別送品先ﾘｽﾄ作成処理
    '引　数：llngSendListCnt:送品選択数
    '戻り値：True:あり　False:なし
    '作成日：2004/08/04 (Wed) 16:48:26 N.Kasai
    '更新日：2012/10/18 (Thu) 19:24:49 T.Oide
    '備　考：
    '　　　：2004/12/01 (Wed) 11:17:08 H.Wajima     送品待ち/送品済み対応
    '　　　：2004/12/14 (Tue) 15:36:55 H.Wajima     運用系障害対応(ｶｳﾝﾀ間違い)
    '　　　：2006/09/15 (Fri) 14:00:15 N.Kojima     量産ﾛｯﾄの送品先設定機能追加に伴い、処理修正。(案件№01452)
    '　　　：2012/10/18 (Thu) 19:24:49 T.Oide       R9-05(EPPI送品対応)
    Private Sub prvvsfSBIDSendList_Set(ByRef llngSendListCnt As Integer)

        Dim llngLoopCnt         As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrSBList          As String       'ﾘｽﾄ作成領域
        Dim llngCnt             As Integer      '汎用ｶｳﾝﾀ
        Dim lstrDefaultSendSbId As String       'ﾃﾞﾌｫﾙﾄ送品先

        With vsfLotListSend
        
            '@ﾃﾞﾌｫﾙﾄの送品先を表示
            ' (構造体のﾃﾞｰﾀと表示されている行数が必ずしも一致しないので一致するロットIDを見つけて表示する)
            llngCnt = 0
            Do While mlngStockListCnt -1 >= llngCnt
            
                '@該当ロットと構造体のロットが同じか
                If .GetData(.Row, CMlngvsfSendColLotID) = mtypstocklotlist(llngCnt).strLotID Then
                
                    '@一致したらﾘｽﾄに追加
                    lstrSBList = lstrSBList & mtypstocklotlist(llngCnt).strSendSBName
                    
                    '@ﾃﾞﾌｫﾙﾄ送品先ｾｯﾄ
                    lstrDefaultSendSbId = mtypstocklotlist(llngCnt).strSendSBName
                    
                    Exit Do
                    
                End If
                llngCnt = llngCnt + 1
            Loop
        
            '@送品先ﾘｽﾄ作成
            If lstrDefaultSendSbId <> vbNullString Then
        
                '@ﾘｽﾄ項目の設定(2行目以降)
                For llngLoopCnt = 0 To mtypSendSBListAns.lngSendSBListCnt -1
                
                    '@ﾃﾞﾌｫﾙﾄ送品先と異なる場合のみｾｯﾄ
                    If lstrDefaultSendSbId <> mtypSendSBListAns.typSendSBList(llngLoopCnt).strSendSBName Then

                        If mtypSendSBListAns.typSendSBList(llngLoopCnt).strSendSBName <> vbNullString Then
                            '@SB名が空白以外の場合、そのまま和名をｾｯﾄ
                            lstrSBList = lstrSBList _
                                       & "|" _
                                       & mtypSendSBListAns.typSendSBList(llngLoopCnt).strSendSBName
                        Else
                            '@SB名が空白の場合、IDをｾｯﾄ
                            lstrSBList = lstrSBList _
                                       & "|" _
                                       & mtypSendSBListAns.typSendSBList(llngLoopCnt).strSendSBID
                        End If
                    End If
                Next
            Else
                '@ﾃﾞﾌｫﾙﾄSBが設定されていない場合

                '@送品先ﾘｽﾄが0件か
                If mtypSendSBListAns.lngSendSBListCnt = 0 Then
                    '@0件の場合
                    lstrSBList = CPstrComboBrank
                Else
                    '@0件じゃない場合
                    
                    '@初期化
                    llngLoopCnt = 0
                    lstrSBList = vbNullString
        
                    '@ﾘｽﾄ項目の設定(1行目)
                    lstrSBList = lstrSBList & mtypSendSBListAns.typSendSBList(llngLoopCnt).strSendSBName

                    '@ﾘｽﾄ項目の設定(2行目)
                    For llngLoopCnt = 1 To mtypSendSBListAns.lngSendSBListCnt -1
                        '@SB名をｾｯﾄする
                        lstrSBList = lstrSBList _
                                   & "|" _
                                   & mtypSendSBListAns.typSendSBList(llngLoopCnt).strSendSBName
                    Next
                End If
            End If

            '@送品先
            .Cols(CMlngvsfSendColSendSBID).ComboList = lstrSBList
            
            '@箱№の入力可否判定
            With mtypSendSBListAns
                For llngCnt = 0 To .lngSendSBListCnt -1
                '@送品先が一致する項目を構造体から探す
                    If .typSendSBList(llngCnt).strSendSBName = _
                       vsfLotListSend.GetData(vsfLotListSend.Row, CMlngvsfSendColSendSBID) Then
                        
                        '@一致した場合
                        vsfLotListSend.SetData(vsfLotListSend.Row, CMlngvsfSendColSBSystemFlag, _
                            .typSendSBList(llngCnt).strSBSystemFlag)

                        Exit For
                    End If
                Next llngCnt
            End With
        End With

        Exit Sub

    Error_Handler:

        '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
        With ptypOnErrorInfo
            .strMenuKey = CMstrLocalMenuKey
            .strProcName = "prvvsfSBIDSendList_Set"
            .strErrMessage = vbNullString
        End With

        '@共通ｴﾗｰ処理
        Call pubOnError_Proc()

    End Sub

    '関数名：prvblnSendInfo_Chk
    '機　能：送品内容ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：成功、False：失敗
    '作成日：2004/08/04 (Wed) 17:44:01 N.Kasai
    '更新日：2007/06/07 (Thu) 13:09:37 N.Kasai
    '備　考：
    '　　　：2006/09/15 (Fri) 16:42:44 N.Kojima     送品先指定ﾁｪｯｸの処理を修正。(案件№01452)
    '　　　：2007/06/07 (Thu) 13:09:37 N.Kasai      箱№のﾁｪｯｸ追加
    Private Function prvblnSendInfo_Chk() As Boolean
        
        Dim llngLoopCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        
        Try

            '@初期化
            prvblnSendInfo_Chk = False
            
            With vsfLotListSend

                '@起動SBが組立(2A0)、防湿ALD(3A0)の場合のみﾁｪｯｸする
        '@↓2018/07/23 (Mon) 10:59:59 Y.Yoneyama **************************************************
                If pstrSBID = CPstrSBID2A0 Or pstrSBID = CPstrSBID3A0 Then
        '@↑2018/07/23 (Mon) 10:59:59 Y.Yoneyama **************************************************
                    
                    For llngLoopCnt = 1 To .Rows.Count - 1
                        '@送品ﾁｪｯｸﾎﾞｯｸｽONの場合
                        If .GetCellCheck(llngLoopCnt, CMlngvsfSendColKb) = CheckEnum.Checked Then

                            '@送品先が未選択
                            If Trim$(.GetData(llngLoopCnt, CMlngvsfSendColSendSBID)) = vbNullString Then
                                
                                '@判定NG
                                prvblnSendInfo_Chk = False
                                
                                '@判定NGの箇所を選択状態(ﾌｫｰｶｽは送品先欄)
                                .Select(llngLoopCnt, CMlngvsfSendColSendSBID)
                                '@選択箇所を表示
                                .ShowCell(llngLoopCnt, CMlngvsfSendColSendSBID)
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0066)
                                '@publngMsgBoxInfo("ロット送品に必要な情報が選択されていません。設定を見直してください。")
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                '@ｸﾞﾘｯﾄﾞにｾｯﾄﾌｫｰｶｽ
                                Call pubSetFocus(vsfLotListSend)
                                Exit Function
                            End If
                            
                            '@箱№の桁ﾁｪｯｸ
                            If .GetData(llngLoopCnt, CMlngvsfSendColBoxNo) <> vbNullString Then
                                '@箱№は4桁まで
                                If LenB(.GetData(llngLoopCnt, CMlngvsfSendColBoxNo)) > CMlngBoxNoMaxLen Then
                                
                                    '@判定NG
                                    prvblnSendInfo_Chk = False
                                    
                                    '@判定NGの箇所を選択状態(ﾌｫｰｶｽは送品先欄)
                                    .Select(llngLoopCnt, CMlngvsfSendColBoxNo)
                                    '@選択箇所を表示
                                    .ShowCell(llngLoopCnt, CMlngvsfSendColBoxNo)
                                    
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009G, CMlngBoxNoMaxLen)
                                    '"<TRM9GW>$$箱№は最大%1桁です。$設定を見直してください。"
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    
                                    '@ｸﾞﾘｯﾄﾞを編集可能にする
                                    .StartEditing()

                                    Exit Function
                                End If
                            End If
                        End If
                    Next
                    '@判定OK
                    prvblnSendInfo_Chk = True
                
                Else
                    '@基板(1A0)での起動の場合は、ﾍﾞﾀで送品先を"2A0"に指定する為、送品先指定ﾁｪｯｸはNoCheck!!
                    '@判定OK
                    prvblnSendInfo_Chk = True
                End If
            End With
                
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnSendInfo_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnCancelSend_Chk
    '機　能：送品取消内容ﾁｪｯｸ
    '引　数：なし
    '戻り値：True:正常終了、False:異常終了
    '作成日：2004/11/29 (Mon) 10:28:56 H.Wajima
    '更新日：2004/11/29 (Mon) 10:28:56
    '備　考：
    Private Function prvblnCancelSend_Chk() As Boolean
        
        Dim llngLoopCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@初期化
            prvblnCancelSend_Chk = False

            With vsfLotListSend
                For llngLoopCnt = 1 To .Rows.Count - 1
                    '@送品ﾁｪｯｸﾎﾞｯｸｽONの場合
                    If .GetCellCheck(llngLoopCnt, CMlngvsfSend2ColCB) = CheckEnum.Checked Then
                        '@次ｼｽﾃﾑで受入されていないか判定
                        If .GetData(llngLoopCnt, CMlngvsfSend2ColST) <> CMstrSumi Then
                            '@判定OK(ｽﾃｰﾀｽが「済」でない場合)
                            prvblnCancelSend_Chk = True
                        Else
                            '@判定NG(ｽﾃｰﾀｽが「済」の場合)
                            prvblnCancelSend_Chk = False
                            
                            '@判定NGの箇所を選択状態(ﾌｫｰｶｽはｽﾃｰﾀｽ欄)
                            .Select(llngLoopCnt, CMlngvsfSend2ColST)
                            
                            '@選択箇所を表示
                            .ShowCell(llngLoopCnt, CMlngvsfSend2ColST)
                            Exit For
                        End If
                    End If
                Next
            End With
                
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnCancelSend_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvSendUnchecked_Proc
    '機　能：送品ﾁｪｯｸALLｸﾘｱ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/10 (Wed) 09:42:55 N.Kasai
    '更新日：2004/12/22 (Wed) 13:05:41 H.Wajima
    '備　考：
    '　　　：2004/12/22 (Wed) 13:05:41 H.Wajima     箱№のｸﾘｱ処理を追加
    Private Sub prvSendUnchecked_Proc()
        
        Dim llngLoopCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try
            
            With vsfLotListSend
                
                For llngLoopCnt = 1 To .Rows.Count - 1
                    
                    '@ﾁｪｯｸ済み設定判定
                    If .GetCellCheck(llngLoopCnt, CMlngvsfSendColKb) = CheckEnum.Checked Then
                        '@ﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸが入っている場合ﾁｪｯｸｸﾘｱ
                        .SetCellCheck(llngLoopCnt, CMlngvsfSendColKb, CheckEnum.Unchecked)
                        '@送品先をｸﾘｱ
                        .SetData(llngLoopCnt, CMlngvsfSendColSendSBID, vbNullString)
                        '@箱№をｸﾘｱ
                        .SetData(.Row, CMlngvsfSendColBoxNo, vbNullString)
                        '@次SB連絡内容をｸﾘｱ
                        .SetData(llngLoopCnt, CMlngvsfSendColComment, vbNullString)
                        '@次SB連絡有無をｸﾘｱ
                        .SetData(llngLoopCnt, CMlngvsfSendColCommentDisp, vbNullString)
                    End If
                Next llngLoopCnt
            End With
            
            '@送品ﾎﾞﾀﾝ使用不可
            cmdSendRegist.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSendUnchecked_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCompTabControl_Init
    '機　能：完成在庫-ｺﾝﾄﾛｰﾙ初期化処理
    '引　数：lblnComboClear：種別ｺﾝﾎﾞｸﾘｱﾌﾗｸﾞ True:ｸﾘｱする、False:ｸﾘｱしない
    '戻り値：なし
    '作成日：2004/11/24 (Wed) 21:02:02 H.Wajima
    '更新日：2006/02/10 (Fri) 19:49:25 N.Kojima
    '備　考：
    '　　　：2006/02/10 (Fri) 19:49:25 N.Kojima     ﾎﾞﾀﾝの無効化制御を追加。(運用障害№539対応)
    Private Sub prvCompTabControl_Init(ByVal lblnComboClear As Boolean)

        Try
            
            If lblnComboClear = True Then
                '@種別Comboﾎﾞｯｸｽの初期化＆非活性化
                cmbDivisionSend.Clear
                cmbDivisionSend.Enabled = False
            Else
                'NSYS スクロール位置設定
                vsfLotListSend.LeftCol = 0
            End If
            
            '@完成在庫一覧のｸﾘｱ
            Call prvvsfLotListSend_Init()
            
            '@Commandﾎﾞﾀﾝの初期化
            cmdSendWFInfo.Enabled = False           'WF情報表示
            cmdHoldSend.Enabled = False             '保留
            cmdCancelSend.Enabled = False           '保留解除
            cmdWFSend.Enabled = False               '数量増減(払出)
            cmdCommentSend.Enabled = False          'ﾛｯﾄｺﾒﾝﾄ表示
            cmdNextCommentSend.Enabled = False      '次SB連絡登録
            cmdSendOrderList.Enabled = False        '送品伝票印刷
            cmdLotExamInfo.Enabled = False          'ﾛｯﾄ検定表印刷
            cmdNowListSend.Enabled = False          '最新取得
            cmdSendRegist.Enabled = False           '送品
            cmdCopy.Enabled = False                 'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
                
            '@情報取得日時
            lblNowDateSend.Text = vbNullString
            
            '@該当件数
            lblLotCntSend.Text = "0"
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCompTabControl_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSend2CmdStatus_Chk
    '機　能：完成在庫-送品済み選択時ｺﾏﾝﾄﾞﾎﾞﾀﾝ有効無効ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/25 (Thu) 19:26:45 H.Wajima
    '更新日：2004/11/25 (Thu) 19:26:45
    '備　考：
    '　　　：送品取消処理を修正の為,ﾎﾞﾀﾝ処理を修正
    Private Sub prvvsfSend2CmdStatus_Chk()
        
        Dim llngRowCnt              As Integer      '行ｶｳﾝﾀ
        Dim llngPrintCheckOKCnt     As Integer      '印刷ﾁｪｯｸ有効ｶｳﾝﾀ
        Dim llngPrintCheckNGCnt     As Integer      '印刷ﾁｪｯｸ無効ｶｳﾝﾀ
        Dim llngCancelSendOKCnt     As Integer      '送品取消有効ｶｳﾝﾀ
        Dim llngCancelSendNGCnt     As Integer      '送品取消無効ｶｳﾝﾀ

        Try
            
            '@ｶｳﾝﾀの初期化
            llngPrintCheckOKCnt = 0
            llngPrintCheckNGCnt = 0
            llngCancelSendOKCnt = 0
            llngCancelSendNGCnt = 0
            
            With vsfLotListSend
                '@行のﾙｰﾌﾟ
                For llngRowCnt = .Rows.Fixed To .Rows.Count - 1
                    
                    '@ﾁｪｯｸﾎﾞｯｸｽが選択されている場合
                    If .GetCellCheck(llngRowCnt, CMlngvsfSend2ColCB) = CheckEnum.Checked Then
                    
                        '@SBｼｽﾃﾑﾌﾞﾛｯｸ判定
                        If .GetData(llngRowCnt, CMlngvsfSend2ColSBSystemFlag) = "1" Then
                            '@SBｼｽﾃﾑﾌﾞﾛｯｸが1:千歳の場合
                            
                            '@印刷ﾁｪｯｸ無効ｶｳﾝﾀｲﾝｸﾘﾒﾝﾄ
                            llngPrintCheckNGCnt = llngPrintCheckNGCnt + 1
                        Else
                            '@SBｼｽﾃﾑﾌﾞﾛｯｸが0:千歳以外の場合
                            
                            '@印刷ﾁｪｯｸ有効ｶｳﾝﾀｲﾝｸﾘﾒﾝﾄ
                            llngPrintCheckOKCnt = llngPrintCheckOKCnt + 1
                        End If
                        
                        '@送品取消ﾎﾞﾀﾝ判定
                        If .GetData(llngRowCnt, CMlngvsfSend2ColST) = CMstrSumi Then
                            '@ｽﾃｰﾀｽ欄が「済」の場合
                            
                            '@送品取消無効ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                            llngCancelSendNGCnt = llngCancelSendNGCnt + 1
                        Else
                            '@ｽﾃｰﾀｽ欄が「済」以外の場合
                            
                            '@送品取消有効ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                            llngCancelSendOKCnt = llngCancelSendOKCnt + 1
                        End If
                    End If
                Next llngRowCnt
                
                '@印刷ﾎﾞﾀﾝの有効無効判定
                If llngPrintCheckOKCnt > 0 And llngPrintCheckNGCnt = 0 Then
                    '@印刷有効ｶｳﾝﾀが1以上で、印刷無効ｶｳﾝﾀが0件の場合
                    
                    '@送品伝票印刷ﾎﾞﾀﾝ有効
                    cmdSendOrderList.Enabled = True
                    '@ﾛｯﾄ検定表印刷ﾎﾞﾀﾝ有効
                    cmdLotExamInfo.Enabled = True
                Else
                    '@上記以外の場合
                    
                    '@送品伝票印刷ﾎﾞﾀﾝ有効
                    cmdSendOrderList.Enabled = False
                    '@ﾛｯﾄ検定表印刷ﾎﾞﾀﾝ有効
                    cmdLotExamInfo.Enabled = False
                End If
                
                '@送品取消ﾎﾞﾀﾝの有効無効判定
                If llngCancelSendOKCnt = 1 And llngCancelSendNGCnt = 0 Then
                    '@送品取消有効ｶｳﾝﾀが1件で、送品取消無効ｶｳﾝﾀが0件の場合
                    
                    '@送品取消ﾎﾞﾀﾝ有効
                    cmdSendRegist.Enabled = True
                Else
                    '@上記以外の場合
                    
                    '@送品取消ﾎﾞﾀﾝ無効
                    cmdSendRegist.Enabled = False
                End If
                
                '@編集中ﾌﾗｸﾞの判定
                If llngPrintCheckOKCnt > 0 Or llngCancelSendOKCnt > 0 Then
                    '@編集中ﾌﾗｸﾞにTrueを設定
                    mblnInEditKbn = True
                Else
                    '@編集中ﾌﾗｸﾞの初期化
                    mblnInEditKbn = False
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSend2CmdStatus_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnSendOrderList_Pri
    '機　能：送品伝票印刷処理
    '引　数：ltypGetSendOrderList：送品伝票情報構造体
    '戻り値：True:正常終了、False:異常終了
    '作成日：2004/11/26 (Fri) 17:31:06 H.Wajima
    '更新日：2005/01/27 (Thu) 14:03:52 H.Wajima
    '備　考：
    '　　　：2004/12/15 (Wed) 11:28:41 H.Wajima     不具合修正
    '　　　：2004/12/27 (Mon) 13:19:45 H.Wajima     印刷ﾎﾞﾀﾝを連打すると異常終了する問題を修正
    '　　　：2005/01/27 (Thu) 14:03:52 H.Wajima     仕掛品ｺｰﾄﾞ印刷対応
    Private Function prvblnSendOrderList_Pri(ByRef ltypGetSendOrderList As GetSendOrderList) As Boolean

        Try
            ptypGetSendOrderList.lngLotListCount = ltypGetSendOrderList.lngLotListCount

            If Not IsNothing(ptypGetSendOrderList.typLotList) Then
                ptypGetSendOrderList.typLotList.Clear()
            End If
            If Not IsNothing(ltypGetSendOrderList.typLotList) Then
                ptypGetSendOrderList.typLotList = New List(Of GetSendOrderListLotList)(ltypGetSendOrderList.typLotList)
            End If

            '@ﾌｫｰﾑのｵﾌﾞｼﾞｪｸﾄ
            pfrmReportPrint = frmxxEN00F5.Instance
            
            '@印刷ﾎﾞﾀﾝﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定する
            pfrmReportPrint.Text = CPstrSendOrderListPrintFormCaption

            ptypGetSendOrderList = ltypGetSendOrderList
            
            If rptxxEN00F0.Instance.Visible = False Then
                '@送品伝票ﾚﾎﾟｰﾄをLoadする
                rptxxEN00F0.Instance = New rptxxEN00F0()

                '@ﾌﾟﾚﾋﾞｭｰ画面位置、ｻｲｽﾞ指定
                rptxxEN00F0.Instance.Show(Me)
            End If

            If pfrmReportPrint.Visible = False Then
                '@印刷ﾎﾞﾀﾝﾌｫｰﾑ表示
                pfrmReportPrint.Show(rptxxEN00F0.Instance)
            End If
        
            '@DoEvents前にﾌﾗｸﾞ・画面無効化の設定を行う
            Call pubDoEventsBefoer(Me)
            
            '@DoEvents後にﾌﾗｸﾞ・画面有効化の設定を行う
            Call pubDoEventsAfter(Me)
            
            '@印刷ﾎﾞﾀﾝﾌｫｰﾑを最前面に表示
            If Not pfrmReportPrint Is Nothing Then
                If pfrmReportPrint.Visible = True Then
                    pfrmReportPrint.BringToFront()
                End If
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnSendOrderList_Pri"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnLotExamInfo_Pri
    '機　能：ﾛｯﾄ検定表印刷
    '引　数：ltypgetlotexaminfo()：ﾛｯﾄ検定表情報構造体
    '戻り値：True:正常終了、False:異常終了
    '作成日：2020/11/04 13:17:00 Y.Tanaka
    '更新日：2020/11/04 13:17:00 Y.Tanaka
    '備　考：

    Private Function prvblnLotExamInfo_Pri(ByRef ltypGetLotExamInfo As List(Of GetLotExamInfo)) As Boolean

        Try
            
            '@印刷ﾎﾞﾀﾝﾌｫｰﾑのｵﾌﾞｼﾞｪｸﾄを変数に設定
            '@ﾌｫｰﾑのｵﾌﾞｼﾞｪｸﾄ
            pfrmReportPrint2 = frmxxEN00F5.Instance
            
            '@印刷ﾎﾞﾀﾝﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定する
            pfrmReportPrint2.Text = CPstrLotExamInfoPrintFormCaption
            
            '@構造体をｺﾋﾟｰする
            ptypGetLotExamInfo = ltypGetLotExamInfo
            
            If rptxxEN00F1.Instance.Visible = False Then
                '@送品伝票ﾚﾎﾟｰﾄをLoadする
                rptxxEN00F1.Instance = New rptxxEN00F1()

                '@ﾌﾟﾚﾋﾞｭｰ画面位置、ｻｲｽﾞ指定
                rptxxEN00F1.Instance.Show(Me)
            End If
            If pfrmReportPrint2.Visible = False Then
                '@印刷ﾎﾞﾀﾝﾌｫｰﾑ表示
                pfrmReportPrint2.Show(rptxxEN00F1.Instance)
            End If
            
            '@DoEvents前にﾌﾗｸﾞ・画面無効化の設定を行う
            Call pubDoEventsBefoer(Me)
            
            '@DoEvents後にﾌﾗｸﾞ・画面有効化の設定を行う
            Call pubDoEventsAfter(Me)
                
            '@印刷ﾎﾞﾀﾝﾌｫｰﾑを最前面に表示
            If Not pfrmReportPrint2 Is Nothing Then
                If pfrmReportPrint2.Visible = True Then
                    pfrmReportPrint2.BringToFront()
                End If
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnLotExamInfo_Pri"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnNowListSend_Chk
    '機　能：送品済み 最新取得項目ﾁｪｯｸ
    '引　数：llngSendAfterFlg：送品済みﾌﾗｸﾞ 0:送品待ちﾁｪｯｸ、1:送品済みﾁｪｯｸ
    '戻り値：True:正常終了、False:異常終了
    '作成日：2004/12/01 (Wed) 14:58:24 H.Wajima
    '更新日：2008/04/02 (Wed) 13:08:22 M.Koni
    '備　考：
    '　　　：2008/04/02 (Wed) 13:08:22 M.Koni       表示数制限追加 <案件No.02719>
    Private Function prvblnNowListSend_Chk(ByVal llngSendAfterFlg As Integer) As Boolean

        Dim lstrDateWork            As String               '日時計算用ﾜｰｸ

        Try
            
            '@当関数の戻り値にFalseを設定
            prvblnNowListSend_Chk = False
            
            '@機種の判定
            Select Case cmbProductSend.Text
                Case vbNullString
                    '@機種が未選択の場合
                    Exit Function
                Case CMstrCmbAddedCommentNone
                    '@0項目選択の場合
                    Exit Function
            End Select
            
            '@種別の判定
            Select Case cmbDivisionSend.Text
                Case vbNullString
                    '@種別が未選択の場合
                    Exit Function
                Case CMstrCmbAddedCommentNone
                    '@0項目選択の場合
                    Exit Function
            End Select
            
            '@送品済みﾌﾗｸﾞの判定
            If llngSendAfterFlg = CMlngOptSendAfter Then
            '@送品済み指定の場合
                '@検索開始日付、検索終了日付の判定
                Select Case True
                    Case Not calFromDate.IsDate, Not calToDate.IsDate
                        '@日付として妥当でない場合
                        Exit Function
                        
                    Case calFromDate.Value = vbNullString, calToDate.Value = vbNullString
                        '@空白の場合
                        Exit Function
                        
                    Case calFromDate.Value = CPstrNullDate, calToDate.Value = CPstrNullDate
                        '@____/__/__の場合
                        Exit Function
                        
                    Case Not pubblnYearRange_Chk(calFromDate.Value), Not pubblnYearRange_Chk(calToDate.Value)
                        '@日付の有効範囲外の場合
                        Exit Function

                    Case Else
                        '期間日時制限処理
                        ' → calFromDate.Value に，3ヶ月を加算して，calToDate.Value より未来なら警告する。
                        lstrDateWork = Format$(DateAdd(CMstrM, 3, calFromDate.Value), CPstrDateTimeYMD)
                        If lstrDateWork < Format$(CDate(calToDate.Value), CPstrDateTimeYMD) Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008W, CMstrDspMsgThreeMonth)
                            '@"<TRM8WW>$$期間指定について、開始～終了までの間は$3ヶ月以内で設定してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            Exit Function
                        End If

                End Select
            End If
            
            '@当関数の戻り値にTrueを設定
            prvblnNowListSend_Chk = True
                
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnNowListSend_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnLotSend_Chk
    '機　能：送品条件ﾁｪｯｸ
    '引　数：なし
    '戻り値：True:送品可、False:送品不可
    '作成日：2004/12/01 (Wed) 19:25:13 H.Wajima
    '更新日：2006/09/15 (Fri) 17:37:30 N.Kojima
    '備　考：
    '　　　：2006/09/15 (Fri) 17:37:30 N.Kojima     量産ﾛｯﾄの送品先指定機能追加に伴い、処理修正。(案件№01452)
    Private Function prvblnLotSend_Chk() As Boolean
        
        Dim llngLoopCnt         As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngCheckOnCnt      As Integer      'ﾁｪｯｸﾎﾞｯｸｽONｶｳﾝﾀ
        Dim llngCnt             As Integer      '汎用ｶｳﾝﾀ
        Dim llngCnt2            As Integer      '汎用ｶｳﾝﾀ
        Dim lblnSelectFlag      As Integer      '選択ﾌﾗｸﾞ

        Try
            
            '@当関数の戻り値にFalseを設定
            prvblnLotSend_Chk = False
            
            '@ｶｳﾝﾀ初期化
            llngCheckOnCnt = 0
            
            '@選択ﾌﾗｸﾞ初期化
            lblnSelectFlag = True
            
            With vsfLotListSend
                
                For llngLoopCnt = 1 To .Rows.Count - 1
                    
                    If .GetCellCheck(llngLoopCnt, CMlngvsfSendColKb) = CheckEnum.Checked Then
                        '@送品ﾁｪｯｸﾎﾞｯｸｽONの場合
                        
                        '@ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                        llngCheckOnCnt = llngCheckOnCnt + 1
                        
                        '@送品先が選択されているか判定
                        If .GetData(llngLoopCnt, CMlngvsfSendColSendSBID) = vbNullString Then
                            '@送品先が選択されていない場合
                            
                            '@選択ﾌﾗｸﾞにFalseを設定する(選択されている場合にSBｼｽﾃﾑﾌﾗｸﾞの設定をするので、ﾙｰﾌﾟから抜けない)
                            lblnSelectFlag = False
                        Else
                            '@送品先が選択されている場合
                            
                            '@ﾛｯﾄIDが一致するﾃﾞｰﾀを構造体から探す
                            For llngCnt = 0 To mtypstocklotlist.Count -1
                                If .GetData(llngLoopCnt, CMlngvsfSendColLotID) = _
                                   mtypstocklotlist(llngCnt).strLotID Then
                                    '@ﾛｯﾄIDが一致した場合
                                                                
                                    '@送品先名が一致するSBIDを探す
                                    For llngCnt2 = 0 To mtypSendSBListAns.lngSendSBListCnt -1
                                        With mtypSendSBListAns.typSendSBList(llngCnt2)
                                            '@SB名の判定
                                            If .strSendSBName = _
                                               vsfLotListSend.GetData(llngLoopCnt, CMlngvsfSendColSendSBID) Then
                                                '@SB名が一致した場合
                                                
                                                '@SBｼｽﾃﾑﾌﾗｸﾞ列にSBIDに対応するSBｼｽﾃﾑﾌﾗｸﾞを設定する
                                                vsfLotListSend.SetData(llngLoopCnt, CMlngvsfSendColSBSystemFlag, _
                                                    .strSBSystemFlag)
                                            End If
                                        End With
                                    Next llngCnt2
                                End If
                            Next llngCnt
                            
                        End If
                    End If
                Next
            End With
            
            '@ﾁｪｯｸﾎﾞｯｸｽONｶｳﾝﾀの判定
            If llngCheckOnCnt = 0 Then
            '@ﾁｪｯｸﾎﾞｯｸｽがONの行が1行もない場合
                '@編集中ﾌﾗｸﾞの初期化
                mblnInEditKbn = False
                
                '@処理を抜ける
                Exit Function
            Else
            '@ﾁｪｯｸﾎﾞｯｸｽのONが1つ以上ある場合
                '@編集中ﾌﾗｸﾞにTrueを設定
                mblnInEditKbn = True
            End If
            
            '@選択ﾌﾗｸﾞの判定
            If lblnSelectFlag = False Then
                '@一致しない項目があった場合は処理を抜ける
                Exit Function
            End If
            
            '@当関数の戻り値にTrueを設定
            prvblnLotSend_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnLotSend_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnvsfLotListSend_Sel
    '機　能：送品伝票用ﾛｯﾄID検索処理
    '引　数：lstrLotID()：選出ﾛｯﾄID
    '　　　：llnglotCnt：選出ﾛｯﾄIDｶｳﾝﾄ
    '戻り値：True：OK/False:NG
    '作成日：2005/02/21 (Mon) 14:51:29 S.Deguchi
    '更新日：2005/02/21 (Mon) 14:51:29
    '備　考：
    Private Function prvblnvsfLotListSend_Sel(ByRef lstrLotID As List (Of String), _
                                              ByRef llngLotCnt As Integer) As Boolean

        Dim llngCnt     As Integer                      'ｶｳﾝﾀ
        Dim llngCnt2    As Integer                      'ｶｳﾝﾀ
        Dim llngCnt3    As Integer                      'ｶｳﾝﾀ
        Dim ltypSerch   As List (Of SearchList)         '構造体
        Dim lblnFlag    As Boolean                      '重複ﾌﾗｸﾞ

        Try
            
            '@初期化
            prvblnvsfLotListSend_Sel = False
            llngLotCnt = 0
            If IsNothing(lstrLotID) Then
                lstrLotID = New List(Of String)()
            Else
                lstrLotID.Clear()
            End If
            If IsNothing(ltypSerch) Then
                ltypSerch = New List(Of SearchList)()
            Else
                ltypSerch.Clear()
            End If

            With vsfLotListSend
                '@ﾁｪｯｸされたﾛｯﾄをﾘｽﾄへ格納
                For llngCnt = 1 To .Rows.Count - 1
                    '@ﾁｪｯｸあり
                    If .GetCellCheck(llngCnt, CMlngvsfSend2ColCB) = CheckEnum.Checked Then
                        '@SBｼｽﾃﾑﾌﾞﾛｯｸﾌﾗｸﾞの判定(0:千歳以外の場合)
                        If .GetCellCheck(llngCnt, CMlngvsfSend2ColSBSystemFlag) = "0" Then
                            '@送品先の判定
                            If .GetData(llngCnt, CMlngvsfSend2ColSendSBID) <> vbNullString Then
                                '@領域確保
                                llngLotCnt = llngLotCnt + 1
                                Do While (lstrLotID.Count < llngLotCnt)
                                    lstrLotID.Add("")
                                Loop
                                Do While (ltypSerch.Count < llngLotCnt)
                                    ltypSerch.Add(New SearchList)
                                Loop

                                Dim ltypSerchTmp As SearchList = New SearchList
                                '@変数へ取得
                                lstrLotID(llngLotCnt -1) = .GetData(llngCnt, CMlngvsfSend2ColLotID)
                                ltypSerchTmp.strLotID = .GetData(llngCnt, CMlngvsfSend2ColLotID)
                                ltypSerchTmp.strDate = .GetData(llngCnt, CMlngvsfSend2ColSendDate)
                                ltypSerchTmp.strAMPM = .GetData(llngCnt, CMlngvsfSend2ColAMPMFlag)
                                ltypSerchTmp.strSend = .GetData(llngCnt, CMlngvsfSend2ColSendSBID)
                                ltypSerchTmp.strEmpName = .GetData(llngCnt, CMlngvsfSend2ColSendEmpName)
                                ltypSerch(llngLotCnt -1) = ltypSerchTmp

                            Else
                                '@処理を抜ける
                                Exit Function
                            End If
                        End If
                    End If
                Next llngCnt
                
                '@ﾁｪｯｸされたﾛｯﾄ以外に同じ条件のﾛｯﾄが存在しないか検索する
                For llngCnt = 0 To llngLotCnt -1
                    For llngCnt2 = 1 To .Rows.Count - 1
                        '@同じ条件
                        If ltypSerch(llngCnt).strDate = .GetData(llngCnt2, CMlngvsfSend2ColSendDate) And _
                            ltypSerch(llngCnt).strAMPM = .GetData(llngCnt2, CMlngvsfSend2ColAMPMFlag) And _
                            ltypSerch(llngCnt).strSend = .GetData(llngCnt2, CMlngvsfSend2ColSendSBID) And _
                            ltypSerch(llngCnt).strEmpName = .GetData(llngCnt2, CMlngvsfSend2ColSendEmpName) And _
                            ltypSerch(llngCnt).strLotID <> .GetData(llngCnt2, CMlngvsfSend2ColLotID) Then
                            
                            '@初期化
                            lblnFlag = False
                            
                            '@既に存在している場合には処理抜け
                            For llngCnt3 = 0 To llngLotCnt -1
                                If .GetData(llngCnt2, CMlngvsfSend2ColLotID) = lstrLotID(llngCnt3) Then
                                    '@ﾌﾗｸﾞたて
                                    lblnFlag = True
                                    
                                    '@処理抜け
                                    Exit For
                                End If
                            Next llngCnt3
                            
                            If lblnFlag = False Then
                                Do While (lstrLotID.Count -1 < llngLotCnt)
                                    lstrLotID.Add("")
                                Loop

                                '@変数へ取得
                                lstrLotID(llngLotCnt) = .GetData(llngCnt2, CMlngvsfSend2ColLotID)
                                '@領域確保
                                llngLotCnt = llngLotCnt + 1
                            End If
                        End If
                    Next llngCnt2
                Next llngCnt
            End With
            
            '@成功を返す
            prvblnvsfLotListSend_Sel = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnvsfLotListSend_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnAfterPrintLotList_Set
    '機　能：送品済み送品伝票情報取得 要求Msg情報設定
    '引　数：llngSendSBCount：送品先ﾛｯﾄ情報構造体ｶｳﾝﾀ
    '　　　：ltypSendSBList()：送品先ﾛｯﾄ情報構造体
    '戻り値：True:正常終了、False:異常終了
    '作成日：2004/11/26 (Fri) 15:42:39 H.Wajima
    '更新日：2005/02/21 (Mon) 14:23:45 S.Deguchi
    '備　考：
    '　　　：2004/12/06 (Mon) 17:14:44 H.Wajima     不具合修正
    '　　　：2005/02/21 (Mon) 14:23:45 S.Deguchi    不具合№336/366の対応で処理を見直し
    Private Function prvblnAfterPrintLotList_Set(ByRef llngSendSBCount As Integer, _
                                                 ByRef ltypSendSBList As List(Of SendSBList)) As Boolean

        Dim llngCnt                     As Integer              '汎用ｶｳﾝﾀ
        Dim llngRowCnt                  As Integer              '行ｶｳﾝﾀ
        Dim lblnAgreementFlag           As Boolean              '一致ﾌﾗｸﾞ

        Try

            '@関数の戻り値を設定
            prvblnAfterPrintLotList_Set = False

            '@ｶｳﾝﾀの初期化
            llngSendSBCount = 0

            '@構造体の初期化
            If ltypSendSBList Is Nothing Then
                ltypSendSBList = New List(Of SendSBList)
            Else
                ltypSendSBList.Clear
            End If

            With vsfLotListSend
                '@行のﾙｰﾌﾟ
                For llngRowCnt = .Rows.Fixed To .Rows.Count - 1
                    '@ﾁｪｯｸﾎﾞｯｸｽが選択されている場合
                    If .GetCellCheck(llngRowCnt, CMlngvsfSend2ColCB) = CheckEnum.Checked Then
                        '@SBｼｽﾃﾑﾌﾗｸﾞが0:千歳以外の場合
                        If .GetCellCheck(llngRowCnt, CMlngvsfSendColSBSystemFlag) = "0" Then
                            '@送品先が空白以外の場合
                            If .GetData(llngRowCnt, CMlngvsfSend2ColSendSBID) <> vbNullString Then
                                '@送品先構造体ｶｳﾝﾀの判定
                                Select Case llngSendSBCount
                                    Case 0
                                    '@0件の場合
                                        '@送品先ｶｳﾝﾀの設定
                                        llngSendSBCount = 0
                                        
                                        '@領域確保
                                        Dim ltypSendSBListTmp As New SendSBList

                                        '@送品先の退避
                                        ltypSendSBListTmp.strSendSBName = _
                                            vsfLotListSend.GetData(llngRowCnt, CMlngvsfSend2ColSendSBID)

                                        '@ﾛｯﾄﾘｽﾄｶｳﾝﾀの初期化
                                        ltypSendSBListTmp.typAtlasExistList.lngLotListCount = 0
                                        ltypSendSBListTmp.typAtlasNotExistList.lngLotListCount = 0

                                        With ltypSendSBListTmp
                                            '@ﾛｯﾄﾘｽﾄの初期化
                                            With .typAtlasExistList
                                                .strLotList = New List(Of SendOrderListLotList)
                                                .lngLotListCount = 0
                                            End With
                                            With .typAtlasNotExistList
                                                .strLotList = New List(Of SendOrderListLotList)
                                                .lngLotListCount = 0
                                            End With

                                            '@ATLASｵｰﾀﾞｰ№の存在確認
                                            If vsfLotListSend.GetData(llngRowCnt, CMlngvsfSend2ColAtlasOrderNo) <> vbNullString Then
                                                '@ATLASｵｰﾀﾞｰ№が存在する場合
                                                With .typAtlasExistList
                                                    Dim strLotListTmp As New SendOrderListLotList
                                                    '@ﾛｯﾄIDの退避
                                                    strLotListTmp.strLotID = _
                                                        vsfLotListSend.GetData(llngRowCnt, CMlngvsfSend2ColLotID)
                                                    .strLotList.Add(strLotListTmp)
                                                    '@ﾛｯﾄﾘｽﾄｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                                                    .lngLotListCount = .lngLotListCount + 1

                                                End With
                                            Else
                                                '@ATLASｵｰﾀﾞｰ№が存在しない場合
                                                With .typAtlasNotExistList
                                                    Dim strLotListTmp As New SendOrderListLotList
                                                    
                                                    '@ﾛｯﾄIDの退避
                                                    strLotListTmp.strLotID = _
                                                        vsfLotListSend.GetData(llngRowCnt, CMlngvsfSend2ColLotID)
                                                    .strLotList.Add(strLotListTmp)
                                                    '@ﾛｯﾄﾘｽﾄｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                                                    .lngLotListCount = .lngLotListCount + 1

                                                End With
                                            End If
                                        End With
                                        
                                        ltypSendSBList.Add(ltypSendSBListTmp)

                                    Case Else
                                    '@1件以上の場合
                                        '@一致ﾌﾗｸﾞの初期化
                                        lblnAgreementFlag = False
                                        
                                        '@送品先名構造体のﾙｰﾌﾟ
                                        For llngCnt = 0 To ltypSendSBList.Count -1
                                            '@構造体に同じ送品先があるかどうか判定
                                            If ltypSendSBList(llngCnt).strSendSBName = _
                                                .GetData(llngRowCnt, CMlngvsfSend2ColSendSBID) Then
                                                
                                                '@送品先構造体に既に同じ送品先がある場合
                                                lblnAgreementFlag = True
                                                Exit For
                                            End If
                                        Next llngCnt
                                        
                                        Dim ltypSendSBListTmp As New SendSBList

                                        '@一致ﾌﾗｸﾞの判定
                                        If lblnAgreementFlag = False Then
                                            '@送品先構造体に同じ送品先が無かった場合
                                            '@送品先ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                                            llngSendSBCount = ltypSendSBList.Count + 1
                                            '@送品先の退避
                                            ltypSendSBListTmp.strSendSBName = _
                                                .GetData(llngRowCnt, CMlngvsfSend2ColSendSBID)
                                        Else
                                            '@送品先構造体に同じ送品先があった場合
                                            '@配列番号を同じ送品先の配列に移動する
                                            llngSendSBCount = llngCnt
                                        End If

                                        With ltypSendSBListTmp
                                            '@ATLASｵｰﾀﾞｰ№の存在確認
                                            If vsfLotListSend.GetData(llngRowCnt, CMlngvsfSend2ColAtlasOrderNo) <> vbNullString Then
                                                '@ATLASｵｰﾀﾞｰ№が存在する場合
                                                With .typAtlasExistList
                                                    '@ﾛｯﾄﾘｽﾄｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                                                    .lngLotListCount = .lngLotListCount + 1
                                                    '@ﾛｯﾄIDの退避
                                                    Dim strLotListTmp As New SendOrderListLotList
                                                    strLotListTmp.strLotID = _
                                                        vsfLotListSend.GetData(llngRowCnt, CMlngvsfSend2ColLotID)
                                                    .strLotList.Add(strLotListTmp)
                                                End With
                                            Else
                                                '@ATLASｵｰﾀﾞｰ№が存在しない場合
                                                With .typAtlasNotExistList
                                                    '@ﾛｯﾄﾘｽﾄｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                                                    .lngLotListCount = .lngLotListCount + 1
                                                    '@ﾛｯﾄIDの退避
                                                    Dim strLotListTmp As New SendOrderListLotList
                                                    strLotListTmp.strLotID = _
                                                        vsfLotListSend.GetData(llngRowCnt, CMlngvsfSend2ColLotID)
                                                    .strLotList.Add(strLotListTmp)
                                                End With
                                            End If
                                        End With
                                        ltypSendSBList.Add(ltypSendSBListTmp)
                                End Select
                            Else
                            '@送品先が空白の場合(通常はありえない)
                                '@処理を抜ける
                                Exit Function
                            End If
                        End If
                    End If
                Next llngRowCnt
            End With

            '@llngSendSBCountに値を設定
            llngSendSBCount = ltypSendSBList.Count

            '@関数の戻り値を設定
            prvblnAfterPrintLotList_Set = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnAfterPrintLotList_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnSendOrderListPrint_Proc
    '機　能：新・送品伝票印刷処理
    '引　数：ltypSendLotlist：送品先構造体
    '　　　：llngSendCnt：送品先ｶｳﾝﾄ数
    '戻り値：
    '作成日：2005/02/21 (Mon) 13:16:25 S.Deguchi
    '更新日：2005/02/21 (Mon) 13:16:25
    '戻り値：True：正常終了、False：異常終了
    Private Function prvblnSendOrderListPrint_Proc(ByRef ltypSendLotlist As SendLotList, _
                                                   ByVal llngSendCnt As Integer) As Boolean

        Dim llngCnt                     As Integer              'ｶｳﾝﾀ
        Dim llngCnt2                    As Integer              'ｶｳﾝﾀ2
        Dim ltypGetSendOrderList        As GetSendOrderList     '送品伝票情報構造体
        Dim lstrLotList                 As List(Of String)
        Dim lblnRet                     As Boolean              '戻り値
        Dim llngPrintCnt                As Integer              '印刷ｶｳﾝﾄ

        Try
            
            '@戻り値の設定
            prvblnSendOrderListPrint_Proc = False
          
            llngPrintCnt = 0
            
            '@ﾛｯﾄIDを格納
            With ltypSendLotlist
                '@ﾛｯﾄIDのみ格納
                For llngCnt = 0 To llngSendCnt -1
                    If .typSendLot(llngCnt).strSBSystemFlag <> CPstrSBSystemFlagInnerChitose Then
                        '@領域確保
                        llngPrintCnt = llngPrintCnt + 1
                        If lstrLotList Is Nothing Then
                            lstrLotList = New List(Of String)
                        End If
                        
                        lstrLotList.Add(.typSendLot(llngCnt).strLotID)
                    End If
                Next llngCnt
            End With
            
            If llngPrintCnt > 0 Then

                '@送品伝票情報取得
                lblnRet = pubblnInvGetSendOrderList_Sel(CMstrinv_getsendorderlistVer, _
                                                        llngSendCnt, _
                                                        lstrLotList, _
                                                        ltypGetSendOrderList)
                                                        
                
                If lblnRet = False Then
                '@異常終了の場合
                    Exit Function
                End If
                
                '@送品先IDを格納
                With ltypGetSendOrderList

                    For llngCnt = 0 To llngSendCnt -1
                        
                        For llngCnt2 = 0 To .lngLotListCount -1
                            
                            '@送品ﾛｯﾄ情報のﾛｯﾄIDと送品伝票情報のﾛｯﾄIDが同じか
                            If ltypSendLotlist.typSendLot(llngCnt).strLotID = _
                                .typLotList(llngCnt2).strLotID Then
                                
                                '@送品先IDを格納
                                Dim typLotListTmp As GetSendOrderListLotList = .typLotList(llngCnt2)
                                typLotListTmp.strSendSBID = _
                                    ltypSendLotlist.typSendLot(llngCnt).strSendSBID

                                .typLotList(llngCnt2) = typLotListTmp
                            End If
                        Next llngCnt2
                    Next llngCnt
                End With
                
                '@送品伝票印刷
                lblnRet = prvblnSendOrderList_Pri(ltypGetSendOrderList)

            End If
            
            '@戻り値にTrueを設定
            prvblnSendOrderListPrint_Proc = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnSendOrderListPrint_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

   '関数名：pubLotExamInfoPrint_Proc
    '機　能：新・ﾛｯﾄ検定表印刷処理
    '引　数：なし
    '戻り値：
    '作成日：2004/12/15 (Wed) 13:37:45 H.Wajima
    '更新日：2004/12/15 (Wed) 13:56:26 H.Wajima
    '備　考：
    Public Function pubLotExamInfoPrint_Proc() As Boolean

        Dim llngCnt                     As Integer                       'ｶｳﾝﾀ
        Dim lblnRet                     As Boolean                       '戻り値
        Dim ltypGetLotExamInfo          As List(Of GetLotExamInfo)       'ﾛｯﾄ検定表情報構造体
        Dim llngGetLotExamInfoCount     As Integer                       'ﾛｯﾄ検定表情報構造体ｶｳﾝﾀ
        Dim ltypWkGetLotExamInfo        As GetLotExamInfo                'Workﾛｯﾄ検定表情報構造体

        Try
            
            '@戻り値の設定
            pubLotExamInfoPrint_Proc = False

            With ptypGetSendOrderList
                For llngCnt = 0 To .lngLotListCount -1
                    '@ﾛｯﾄ検定表情報取得
                    lblnRet = pubblnInvGetLotExamInfo_Sel(CMstrinv_getlotexaminfoVer, _
                                                          .typLotList(llngCnt).strLotID, _
                                                          ltypWkGetLotExamInfo)
                    '@戻り値の判定
                    If lblnRet = True Then
                        '@正常終了の場合
                        '@送品伝票情報構造体ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                        llngGetLotExamInfoCount = llngGetLotExamInfoCount + 1
                        '@配列の再定義
                        If ltypGetLotExamInfo Is Nothing Then
                            ltypGetLotExamInfo = New List(Of GetLotExamInfo)
                        End If
                        '@構造体に取得情報を退避
                        ltypGetLotExamInfo.Add(ltypWkGetLotExamInfo)
                    Else
                        '@異常終了の場合
                
                        Exit Function
                
                    End If
                Next llngCnt
            End With
            
            '@ﾛｯﾄ検定表印刷
            lblnRet = prvblnLotExamInfo_Pri(ltypGetLotExamInfo)
            
            '@戻り値にTrueを設定
            pubLotExamInfoPrint_Proc = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "pubLotExamInfoPrint_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvSendCancelConnect_Set
    '機　能：送信取消構造体へ情報を退避
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/22 (Tue) 17:46:08 S.Deguchi
    '更新日：2005/03/22 (Tue) 17:46:08
    '備　考：
    Private Sub prvSendCancelConnect_Set()

        Dim llngRow         As Integer  '選択行退避
        Dim llngCnt         As Integer  'ﾙｰﾌﾟｶｳﾝﾀ

        Try
            
            '@初期化
            llngRow = 0
            
            '@ﾁｪｯｸ行の行数を退避
            With vsfLotListSend
                For llngCnt = 1 To .Rows.Count - 1
                    '@ﾁｪｯｸの入っている行を取得する
                    If .GetCellCheck(llngCnt, CMlngvsfSend2ColCB) = CheckEnum.Checked Then
                        llngRow = llngCnt
                        
                        Exit For
                    End If
                Next
            End With
            
            '@情報をｾｯﾄ
            With ptypSendCancelConnect
                .strLotID = vsfLotListSend.GetData(llngRow, CMlngvsfSend2ColLotID)                 'ﾛｯﾄID
                .strToSend = vsfLotListSend.GetData(llngRow, CMlngvsfSend2ColSendSBID)             '送品先
                .strSendDate = vsfLotListSend.GetData(llngRow, CMlngvsfSend2ColSendDay)            '送品日
                .strBoxNo = vsfLotListSend.GetData(llngRow, CMlngvsfSend2ColBoxNo)                 '箱№
                .strPdId = vsfLotListSend.GetData(llngRow, CMlngvsfSend2ColPDName)                 '機種
                .strWFQuantity = vsfLotListSend.GetData(llngRow, CMlngvsfSend2ColWfNum)            'WF数
                .strChipQuantity = vsfLotListSend.GetData(llngRow, CMlngvsfSend2ColCfNum)          'ﾁｯﾌﾟ数
                .strCarrierType = vsfLotListSend.GetData(llngRow, CMlngvsfSend2ColCarrierType)     'ｷｬﾘｱﾀｲﾌﾟ
                .strLotLastUpdate = vsfLotListSend.GetData(llngRow, CMlngvsfSend2ColLastUpdate)    '最終更新日時
                .strRegistFlag = CMstrRegistFlag0                                                           '取消完了ﾌﾗｸﾞ(初期化)
                
                .strCarrierId = vsfLotListSend.GetData(llngRow, CMlngvsfSend2ColCarrierID)         'ｷｬﾘｱID(一応)
                .strAtlasOrderNo = vbNullString                                                             'ATLASｵｰﾀﾞｰ№(Null)
                .strPartCode = vbNullString                                                                 '仕掛品ｺｰﾄﾞ(Null)
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSendCancelConnect_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：pubLotListSendRefresh_Proc
    '機　能：完成在庫の最新取得処理呼出関数
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/24 (Thu) 09:59:10 S.Deguchi
    '更新日：2005/03/24 (Thu) 09:59:10
    '備　考：
    Public Sub pubLotListSendRefresh_Proc()

        Try

            '@最新取得処理呼出
            Call cmdNowListSend_Click(cmdNowListSend,New EventArgs)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "pubLotListSendRefresh_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnSendAry_Set
    '機　能：送品ﾃﾞｰﾀ格納処理
    '引　数：ltypSendLotlist：送品ﾛｯﾄ構造体
    '　　　：llngSendCnt：送品(送品取消)ﾛｯﾄ総数
    '戻り値：True:成功、False:失敗
    '作成日：2007/03/28 (Wed) 16:01:07 N.Kasai
    '更新日：2007/03/28 (Wed) 16:01:07
    '備　考：
    Private Function prvblnSendAry_Set(ByRef ltypSendLotlist As SendLotList, ByRef llngSendCnt As Integer) As Boolean

        Dim lblnAns                 As Boolean          '結果取得(True:正常,False:異常)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngCnt                 As Integer          '汎用ｶｳﾝﾀ
        Dim llngCnt2                As Integer          '汎用ｶｳﾝﾀ2
        Dim lstrPdID                As String           '機種退避用

        Try
            
            prvblnSendAry_Set = False
            
            '@作業者ID
            ltypSendLotlist.strEmpID = pstrUserID
            
            With vsfLotListSend
                '@対象ﾃﾞｰﾀ検索
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    '@ﾁｪｯｸありの場合
                    If .GetCellCheck(llngCnt, CMlngvsfSendColKb) = CheckEnum.Checked Then
                        
                        If ltypSendLotlist.typSendLot Is Nothing Then
                            ltypSendLotlist.typSendLot = New List(Of SendLot)
                        End If

                        Dim typSendLotTmp As New SendLot

                        '@ﾛｯﾄID
                        typSendLotTmp.strLotID = .GetData(llngCnt, CMlngvsfSendColLotID)
                        
                        '@起動SBにより処理を判定
                        If pstrSBID = CPstrSBID1A0 Then
                            '@基板の場合
                            
                            '@SBIDは"2A0"固定
                            typSendLotTmp.strSendSBID = CPstrSBID2A0
                        Else
                            '@組立の場合
                            
                            '@機種を退避
                            lstrPdID = .GetData(llngCnt, CMlngvsfSendColPDName)

                            '@ﾚｽﾎﾟﾝｽ取得開始
                            lstrEventName = "prvblnSendRegist_Set"
                            Call pubResponseStart(Me.Name, lstrEventName)

                            '@送品先ﾘｽﾄ格納用構造体の初期化
                            If mtypSendSBListAns.typSendSBList Is Nothing Then
                                mtypSendSBListAns.typSendSBList = New List(Of basxxCM0030.SendSBList)
                            Else
                                mtypSendSBListAns.typSendSBList.Clear
                            End If
                            mtypSendSBListAns.lngSendSBListCnt = 0

                            '@送品先ﾘｽﾄ取得
                            lblnAns = pubblnMasSendSBList_Sel(CMstrmas_sendsblistVer, lstrPdID, mtypSendSBListAns)

                            '@戻り値判定
                            If lblnAns = False Then
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(Me.Name, lstrEventName)
                                '@異常の場合終了
                                Exit Function
                            End If

                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(Me.Name, lstrEventName)
                            
                            '@送品先名が一致するSBIDを探す
                            For llngCnt2 = 0 To mtypSendSBListAns.lngSendSBListCnt -1
                                
                                '@SB名の判定
                                If mtypSendSBListAns.typSendSBList(llngCnt2).strSendSBName _
                                        = .GetData(llngCnt, CMlngvsfSendColSendSBID) Then
                                    '@SB名が一致した場合
                                    
                                    '@送品先ID
                                    typSendLotTmp.strSendSBID _
                                        = mtypSendSBListAns.typSendSBList(llngCnt2).strSendSBID
                                    Exit For
                                Else
                                    '@SB名が一致しない場合
                                    
                                    '@送品先IDにﾃﾞﾌｫﾙﾄ送品先をｾｯﾄ
                                    typSendLotTmp.strSendSBID _
                                        = mtypstocklotlist(.GetData(llngCnt, CMlngvsfSendColNo) -1).strSendSBID
                                End If
                            Next llngCnt2
                            
                        End If
                        
                        '@箱№
                        typSendLotTmp.strBoxNo = _
                            .GetData(llngCnt, CMlngvsfSendColBoxNo)
                            
                        '@最終更新日時
                        typSendLotTmp.strLotLastUpdate = _
                            .GetData(llngCnt, CMlngvsfSendColLastUpdate)
                        
                        '@ｼｽﾃﾑﾌﾞﾛｯｸﾌﾗｸﾞ
                        typSendLotTmp.strSBSystemFlag = _
                            .GetData(llngCnt, CMlngvsfSendColSBSystemFlag)

                        ltypSendLotlist.typSendLot.Add(typSendLotTmp)

                        '@ｶｳﾝﾄｱｯﾌﾟ＆領域確保
                        llngSendCnt = llngSendCnt + 1

                    End If
                Next llngCnt
            End With
            
            prvblnSendAry_Set = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnSendAry_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnSendRegist_Set
    '機　能：ﾛｯﾄ送品処理
    '引　数：ltypSendLotlist：送品ﾃﾞｰﾀ
    '　　　：llngSendCnt：送品件数
    '戻り値：True:成功、False:失敗
    '作成日：2007/03/28 (Wed) 16:53:24 N.Kasai
    '更新日：2007/03/28 (Wed) 16:53:24
    '備　考：
    Private Function prvblnSendRegist_Set(ByRef ltypSendLotlist As SendLotList, ByRef llngSendCnt As Integer) As Boolean

        Dim lblnAns                 As Boolean          '結果取得(True:正常,False:異常)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngCnt                 As Integer          '汎用ｶｳﾝﾀ
        Dim ltypLotSendReq          As LotSendReq       'ﾛｯﾄ送品要求構造体
        
        Try
            
            prvblnSendRegist_Set = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "prvblnSendRegist_Set"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@ｲﾝﾌｫﾒｰｼｮﾝ画面起動
            frmxxCM00X0.Instance = New frmxxCM00X0()
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定
            frmxxCM00X0.Instance.Text = Me.Text & "(送品)"
            frmxxCM00X0.Instance.lblInfomation1.Text = ""
            
            '@ｲﾝﾌｫﾒｰｼｮﾝﾌｫｰﾑを先行して描画する為、記述しています。
            frmxxCM00X0.Instance.Show(Me)
            frmxxCM00X0.Instance.Refresh
            Me.Refresh

            For llngCnt = 0 To llngSendCnt -1
            
                frmxxCM00X0.Instance.lblInfomation1.Text = "[" & ltypSendLotlist.typSendLot(llngCnt).strLotID & "]処理中  (" & llngCnt & "/" & llngSendCnt & ")"
                
                frmxxCM00X0.Instance.Refresh

                With ltypLotSendReq
                    .strMsgVer = CMstrlot_send____Ver
                    .strLotID = ltypSendLotlist.typSendLot(llngCnt).strLotID
                    .strSBSystemFlag = ltypSendLotlist.typSendLot(llngCnt).strSBSystemFlag
                    .strSendSBID = ltypSendLotlist.typSendLot(llngCnt).strSendSBID
                    .strBoxNo = ltypSendLotlist.typSendLot(llngCnt).strBoxNo
                    .strEmpID = ltypSendLotlist.strEmpID
                    .strLotLastUpdate = ltypSendLotlist.typSendLot(llngCnt).strLotLastUpdate
                End With
                
                '@ﾒｯｾｰｼﾞ送信処理呼び出し
                lblnAns = pubblnlotSend_Upd(ltypLotSendReq)
                '@結果取得
                If lblnAns = False Then
                    '@ｲﾝﾌｫﾒｰｼｮﾝ画面起動
                    frmxxCM00X0.Instance = Nothing
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)
                    Exit Function
                End If
            Next
            
            '@ｲﾝﾌｫﾒｰｼｮﾝ画面起動
            frmxxCM00X0.Instance = Nothing
            
            '@成功ﾒｯｾｰｼﾞ表示
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
            prvblnSendRegist_Set = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnSendRegist_Set"
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

    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles FraCarrierInfo.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfCarrierInfo.BeforeDoubleClick, vsfLotListCFEnd.BeforeDoubleClick, vsfLotListHold.BeforeDoubleClick, vsfLotListPut.BeforeDoubleClick, vsfLotListSend.BeforeDoubleClick, vsfLotListWF.BeforeDoubleClick

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
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfCarrierInfo.KeyDownEdit, vsfLotListCFEnd.KeyDownEdit, vsfLotListHold.KeyDownEdit, vsfLotListPut.KeyDownEdit, vsfLotListSend.KeyDownEdit, vsfLotListWF.KeyDownEdit

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

    '関数名：TabControl_Selecting
    '機　能：Tabページ切替キャンセル
    '作成日：2019/09/24 (Thu) 20:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub TabControl_Selecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles tabControl.Selecting
        
        Select Case tabControl.SelectedTab.Name
            Case Tab0.Name
                If Tab0.Enabled = False Then
                    e.Cancel = True
                End If

            Case Tab1.Name
                If Tab1.Enabled = False Then
                    e.Cancel = True
                End If

            Case Tab2.Name
                If Tab2.Enabled = False Then
                    e.Cancel = True
                End If

            Case Tab3.Name
                If Tab3.Enabled = False Then
                    e.Cancel = True
                End If

            Case Tab4.Name
                If Tab4.Enabled = False Then
                    e.Cancel = True
                End If

        End Select
    End Sub

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
                                                                        cmdCopy.Enter, 
                                                                        cmdPutWFInfo.Enter, 
                                                                        cmdPreCommentSend.Enter,
                                                                        cmdCommentPut.Enter, 
                                                                        cmdHoldPut.Enter, 
                                                                        cmdWFPut.Enter, 
                                                                        cmdPartition.Enter, 
                                                                        cmdCancelPut.Enter, 
                                                                        cmdNowListPut.Enter, 
                                                                        cmbDivisionPut.Enter, 
                                                                        cmbProductPut.Enter, 
                                                                        vsfLotListPut.Enter, 
                                                                        cmdHoldWFInfo.Enter, 
                                                                        cmdHoldHold.Enter, 
                                                                        cmdCommentHold.Enter, 
                                                                        cmdCancelHold.Enter, 
                                                                        cmdWFHold.Enter, 
                                                                        cmdNowListHold.Enter, 
                                                                        cmbDivisionHold.Enter, 
                                                                        vsfLotListHold.Enter, 
                                                                        cmdMiddleWFInfo.Enter, 
                                                                        cmdCarrierDetail.Enter, 
                                                                        cmdNowListWF.Enter, 
                                                                        vsfCarrierInfo.Enter, 
                                                                        cmdCarrierM.Enter, 
                                                                        vsfLotListWF.Enter, 
                                                                        cmbSBID0.Enter, 
                                                                        txtLotID.Enter, 
                                                                        chkForign1.Enter, 
                                                                        chkForign0.Enter, 
                                                                        cmdSendWFInfo.Enter, 
                                                                        optLotSendStatus1.Enter,
                                                                        optLotSendStatus0.Enter,
                                                                        cmdSendOrderList.Enter, 
                                                                        cmdLotExamInfo.Enter, 
                                                                        cmdSendRegist.Enter, 
                                                                        cmdNextCommentSend.Enter,
                                                                        cmdCommentSend.Enter, 
                                                                        cmdNowListSend.Enter, 
                                                                        cmdHoldSend.Enter, 
                                                                        cmdWFSend.Enter, 
                                                                        cmdCancelSend.Enter, 
                                                                        vsfLotListSend.Enter, 
                                                                        cmbDivisionSend.Enter, 
                                                                        cmbProductSend.Enter, 
                                                                        calFromDate.Enter, 
                                                                        calToDate.Enter, 
                                                                        cmdCFEndWFInfo.Enter, 
                                                                        cmdCommentCFEnd.Enter, 
                                                                        cmdCancelCFEnd.Enter, 
                                                                        cmdCFEnd.Enter, 
                                                                        cmdHoldCFEnd.Enter, 
                                                                        cmdNowListCFEnd.Enter, 
                                                                        cmdRework.Enter, 
                                                                        vsfLotListCFEnd.Enter, 
                                                                        cmbProductCFEnd.Enter, 
                                                                        cmdClose.Enter, 
                                                                        tabControl.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '自動Validate = OFF
            Case cmdClose.Name,cmdCopy.Name,cmdPutWFInfo.Name,cmdPreCommentSend.Name,
                 cmdCommentPut.Name,cmdHoldPut.Name,cmdWFPut.Name,cmdPartition.Name,
                 cmdCancelPut.Name,cmdHoldWFInfo.Name,cmdHoldHold.Name,cmdCommentHold.Name,
                 cmdCancelHold.Name,cmdWFHold.Name,cmdMiddleWFInfo.Name,cmdSendWFInfo.Name,
                 cmdSendOrderList.Name,cmdLotExamInfo.Name,cmdSendRegist.Name,cmdNextCommentSend.Name,
                 cmdCommentSend.Name,cmdHoldSend.Name,cmdWFSend.Name,cmdCancelSend.Name,
                 cmdCFEndWFInfo.Name,cmdCommentCFEnd.Name,cmdCancelCFEnd.Name,cmdCFEnd.Name,
                 cmdHoldCFEnd.Name,cmdRework.Name

                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '自動Validate = ON
            Case tabControl.Name
                If Me.ActiveControl.Name = tabControl.Name Then
                    Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
                End If
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
    Private Sub tabList_Deselecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles tabControl.Deselecting

        '処理中の場合またはタブ切り替えが無効の場合はタブ選択をキャンセルする
        If Me.buttonProcessing = True OrElse mblnTabSelectEnabled = False Then
            e.Cancel = True
            mblnTabSelectEnabled = True
        End If

    End Sub

End Class
