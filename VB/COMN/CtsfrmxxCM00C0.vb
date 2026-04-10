'ﾌｧｲﾙ名：xxCM00C0.frm
'説　明：キャリア管理 メインフォーム
'作成日：2004/07/07 (Wed) 18:18:23 N.Kojima
'更新日：2025/04/18 (Fri) 16:34:52 T.Oide
'備　考：2018/07/24 (Tue) 11:10:28 Y.Yoneyama   防湿ALD対応
'Copyright(C) SEIKO EPSON CORPORATION 2003-2025, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00C0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00C0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00C0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00C0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00C0)
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
    '@↓2025/04/18 (Fri) 16:34:52 T.Oide **************************************************
    'Private Const CMstrLocalVersion                         As String = "12.05"         '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion                         As String = "12.06"         '機能ﾊﾞｰｼﾞｮﾝ
    '@↑2025/04/18 (Fri) 16:34:52 T.Oide **************************************************
    
    '@ﾛｰｶﾙ機能ID
    Private Const CMstrLocalMenuKey                         As String = CPstrKeyEN00G0   'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrcarradditionVer                      As String = "01.00"         'ｷｬﾘｱ追加
    Private Const CMstrcarrdelete__Ver                      As String = "01.00"         'ｷｬﾘｱ削除
    Private Const CMstrcarrchgstockerVer                    As String = "01.00"         'ｷｬﾘｱ位置変更
    Private Const CMstrcarrclean___Ver                      As String = "01.00"         'ｷｬﾘｱ洗浄
    Private Const CMstrcarrmove____Ver                      As String = "03.01"         'ｷｬﾘｱ統合
    Private Const CMstrcarrlist____Ver                      As String = "07.00"         'ｷｬﾘｱ一覧
    Private Const CMstrcarrmaslist_Ver                      As String = "05.00"         'ｷｬﾘｱ関連ﾏｽﾀｰ
    Private Const CMstrcarrcurstateVer                      As String = "05.02"         'ｷｬﾘｱ状態確認
    Private Const CMstrcarrmanuoutportVer                   As String = "01.00"         'ｷｬﾘｱ手動出庫要求
    Private Const CMstrlot_waferlistVer                     As String = "02.05"         'ﾛｯﾄWF情報取得(新)
    Private Const CMstrmas_placelistVer                     As String = "02.00"         '保管場所ﾏｽﾀ取得
    Private Const CMstrmas_sblist__Ver                      As String = "01.00"         'ｼｽﾃﾑﾌﾞﾛｯｸ取得
    Private Const CMstrmas_stockerlistVer                   As String = "01.00"         'ｽﾄｯｶｰﾏｽﾀ取得
    Private Const CMstrwf__scrap___Ver                      As String = "01.00"         'WF廃棄
    Private Const CMstrutilregtminfoVer                     As String = "06.00"         '端末設定情報登録
    Private Const CMstrutilreftminfoVer                     As String = "04.00"         '端末設定情報取得
    Private Const CMstrcarrforcedmoveVer                    As String = "01.00"         '強制ｷｬﾘｱ交換
    Private Const CMstrcarrupdate__Ver                      As String = "01.00"         'ｷｬﾘｱ情報更新
    Private Const CMstrmas_carriercategorylistVer           As String = "01.00"         'ｷｬﾘｱｶﾃｺﾞﾘﾘｽﾄ取得
    Private Const CMstrjig_usechkVer                        As String = "01.00"         '治具使用可否判定
    '@↓2020/01/15 (Wed) 14:16:00 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer                      As String = "03.04"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer                      As String = "04.00"         'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:16:00 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_attributeVer                     As String = "05.00"         'ﾛｯﾄ情報取得

    '@ComboBox設定
    Private Const CMlngCmbFontSize                          As Integer = 11              'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                      As Integer = 11              'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbRowHeight                         As Integer = 18              'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGetCol0                           As Integer = 0               'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=0
    Private Const CMlngCmbGetCol1                           As Integer = 1               'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=1
    Private Const CMlngCmbGetCol2                           As Integer = 2               'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=2
    Private Const CMlngCmbDispCol1                          As Integer = 1               'ｺﾝﾎﾞﾘｽﾄ表示列番=1
    Private Const CMlngCmbDispCol2                          As Integer = 2               'ｺﾝﾎﾞﾘｽﾄ表示列番=2
    Private Const CMlngCmbDispCol3                          As Integer = 3               'ｺﾝﾎﾞﾘｽﾄ表示列番=3
    Private Const CMlngCmbValueCol0                         As Integer = 0               '値取得列=0
    Private Const CMlngCmbValueCol1                         As Integer = 1               '値取得列=1

    '@ｷｬﾘｱ一覧列設定
    Private Const CMlngvsfCarrierListColNo                  As Integer = 0               '№
    Private Const CMlngvsfCarrierListColCarrierID           As Integer = 1               'ｷｬﾘｱID
    Private Const CMlngvsfCarrierListColLotID               As Integer = 2               'ﾛｯﾄID
    Private Const CMlngvsfCarrierListColPosition            As Integer = 3               '現在位置名
    Private Const CMlngvsfCarrierListColCategoryName        As Integer = 4               '使用ｶﾃｺﾞﾘ名
    Private Const CMlngvsfCarrierListColCategoryID          As Integer = 5               '使用ｶﾃｺﾞﾘID
    Private Const CMlngvsfCarrierListColComments            As Integer = 6               'ｺﾒﾝﾄ
    Private Const CMlngvsfCarrierListColCleanFlag           As Integer = 7               '要洗浄
    Private Const CMlngvsfCarrierListColState               As Integer = 8               '状態
    Private Const CMlngvsfCarrierListColEditTime            As Integer = 9               '最終更新日時
    Private Const CMlngvsfCarrierListColTotalCnt            As Integer = 10              '総回数
    Private Const CMlngvsfCarrierListColCleanCnt            As Integer = 11              '洗浄回数
    Private Const CMlngvsfCarrierListColAfterCleanCnt       As Integer = 12              '洗浄後回数
    Private Const CMlngvsfCarrierListColUnloderReserve      As Integer = 13              'Unloder予約
    Private Const CMlngvsfCarrierListColCarrierMoveStat     As Integer = 14              'ｷｬﾘｱ強制交換
    Private Const CMlngvsfCarrierListColCarrierStat         As Integer = 15              'ｷｬﾘｱ状態
    Private Const CMlngvsfCarrierListColStartTime           As Integer = 16              '使用開始日時
    Private Const CMlngvsfCarrierListColCleanTime           As Integer = 17              '最終洗浄日時
    Private Const CMlngvsfCarrierListColVendor              As Integer = 18              'ﾍﾞﾝﾀﾞｰ
    Private Const CMlngvsfCarrierListColPositionID          As Integer = 19              'ｷｬﾘｱ位置ID(現在位置ID)
    Private Const CMlngvsfCarrierListColProductionDate      As Integer = 20              '製造年月日

    '@ｷｬﾘｱ一覧ﾀｲﾄﾙ設定
    Private Const CMstrvsfCarrierListTNo                    As String = "№"             '№
    Private Const CMstrvsfCarrierListTCarrierID             As String = "キャリアID"     'ｷｬﾘｱID
    Private Const CMstrvsfCarrierListTLotID                 As String = "ロットID"       'ﾛｯﾄID
    Private Const CMstrvsfCarrierListTPosition              As String = "現在位置"       '現在位置名
    Private Const CMstrvsfCarrierListTCategoryName          As String = "使用カテゴリ"   '使用ｶﾃｺﾞﾘ名
    Private Const CMstrvsfCarrierListTCategoryID            As String = "使用カテゴリID" '使用ｶﾃｺﾞﾘID
    Private Const CMstrvsfCarrierListTComments              As String = "コメント"       'ｺﾒﾝﾄ
    Private Const CMstrvsfCarrierListTCleanFlag             As String = "要洗浄"         '要洗浄
    Private Const CMstrvsfCarrierListTState                 As String = "状態"           '状態
    Private Const CMstrvsfCarrierListTEditTime              As String = "最終更新日時"   '最終更新日時
    Private Const CMstrvsfCarrierListTTotalCnt              As String = "総回数"         '総回数
    Private Const CMstrvsfCarrierListTCleanCnt              As String = "洗浄回数"       '洗浄回数
    Private Const CMstrvsfCarrierListTAfterCleanCnt         As String = "洗浄後回数"     '洗浄後回数
    Private Const CMstrvsfCarrierListTUnloderReserve        As String = "予"             'Unloder予約
    Private Const CMstrvsfCarrierListTCarrierMoveStat       As String = "交"             'ｷｬﾘｱ強制交換
    Private Const CMstrvsfCarrierListTCarrierStat           As String = "キャリア状態"   'ｷｬﾘｱ状態
    Private Const CMstrvsfCarrierListTStartTime             As String = "使用開始日"     '使用開始日時
    Private Const CMstrvsfCarrierListTCleanTime             As String = "最終洗浄日時"   '最終洗浄日時
    Private Const CMstrvsfCarrierListTVendor                As String = "ベンダー"       'ﾍﾞﾝﾀﾞｰ
    Private Const CMstrvsfCarrierListTColPositionID         As String = "ｷｬﾘｱ位置ID"     'ｷｬﾘｱ位置ID(現在位置ID)
    Private Const CMstrvsfCarrierListTProductionDate        As String = "製造年月日"     '製造年月日

    '@ｷｬﾘｱ一覧列幅設定
    Private Const CMlngvsfCarrierListWNo                    As Integer = 40              '№
    Private Const CMlngvsfCarrierListWCarrierID             As Integer = 88              'ｷｬﾘｱID
    Private Const CMlngvsfCarrierListWLotID                 As Integer = 100             'ﾛｯﾄID
    Private Const CMlngvsfCarrierListWPosition              As Integer = 137             '現在位置名
    Private Const CMlngvsfCarrierListWCategoryName          As Integer = 233             '使用ｶﾃｺﾞﾘ名
    Private Const CMlngvsfCarrierListWCategoryID            As Integer = 0               '使用ｶﾃｺﾞﾘID
    Private Const CMlngvsfCarrierListWComments              As Integer = 137             'ｺﾒﾝﾄ
    Private Const CMlngvsfCarrierListWCleanFlag             As Integer = 68              '要洗浄
    Private Const CMlngvsfCarrierListWState                 As Integer = 54              '状態
    Private Const CMlngvsfCarrierListWEditTime              As Integer = 166             '最終更新日時
    Private Const CMlngvsfCarrierListWTotalCnt              As Integer = 68              '総回数
    Private Const CMlngvsfCarrierListWCleanCnt              As Integer = 76              '洗浄回数
    Private Const CMlngvsfCarrierListWAfterCleanCnt         As Integer = 87              '洗浄後回数
    Private Const CMlngvsfCarrierListWUnloderReserve        As Integer = 27              'Unloder予約
    Private Const CMlngvsfCarrierListWCarrierMoveStat       As Integer = 27              'ｷｬﾘｱ強制交換
    Private Const CMlngvsfCarrierListWCarrierStat           As Integer = 166             'ｷｬﾘｱ状態
    Private Const CMlngvsfCarrierListWStartTime             As Integer = 166             '使用開始日時
    Private Const CMlngvsfCarrierListWCleanTime             As Integer = 166             '最終洗浄日時
    Private Const CMlngvsfCarrierListWVendor                As Integer = 200             'ﾍﾞﾝﾀﾞｰ
    Private Const CMlngvsfCarrierListWPositionID            As Integer = 0               'ｷｬﾘｱ位置ID(現在位置ID)
    Private Const CMlngvsfCarrierListWProductionDate        As Integer = 166             '製造年月日

    '@ｷｬﾘｱ一覧設定
    Private Const CMlngvsfCarrierListCols                   As Integer = 21              '列数
    Private Const CMlngvsfCarrierListSize                   As Integer = 11              'ﾌｫﾝﾄｻｲｽﾞ

    '@ｽﾛｯﾄﾏｯﾌﾟ列設定
    Private Const CMlngvsfMoveSlotMapColNo                  As Integer = 0              'ｽﾛｯﾄ№
    Private Const CMlngvsfMoveSlotMapColCheck               As Integer = 1              'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMlngvsfMoveSlotMapColWFID                As Integer = 2              'WFID
    '@↓2020/02/07 (Fri) 16:39:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfMoveSlotMapColGRB                 As Integer = 3              'GRB
    Private Const CMlngvsfMoveSlotMapColJIGID               As Integer = 4              '治具ID
    Private Const CMlngvsfMoveSlotMapColWFStat              As Integer = 5              '状態
    Private Const CMlngvsfMoveSlotMapColBeforRow            As Integer = 6              '移動前の行
    Private Const CMlngvsfMoveSlotMapColBeforJIG            As Integer = 7              '変更前の治具ID
    '@↑2020/02/07 (Fri) 16:39:04 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@ｽﾛｯﾄﾏｯﾌﾟ幅設定
    Private Const CMlngvsfMoveSlotMapWNo                    As Integer = 19             'ｽﾛｯﾄ№
    Private Const CMlngvsfMoveSlotMapWCheck                 As Integer = 19             'ﾁｪｯｸ
    Private Const CMlngvsfMoveSlotMapWWFID                  As Integer = 80             'WFID
    '@↓2020/02/07 (Fri) 17:17:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfMoveSlotMapWGRB                   As Integer = 35             'GRB
    '@↑2020/02/07 (Fri) 17:17:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfMoveSlotMapWJIGID                 As Integer = 93             'JIGID
    Private Const CMlngvsfMoveSlotMapWWFStat                As Integer = 45             '状態
    Private Const CMlngvsfMoveSlotMapW0                     As Integer = 0              '状態(隠し列)

    '@ｽﾛｯﾄﾏｯﾌﾟﾀｲﾄﾙ設定
    Private Const CMstrvsfMoveSlotMapTNo                    As String = ""              'ｽﾛｯﾄ№
    Private Const CMstrvsfMoveSlotMapTCheck                 As String = ""              'ﾁｪｯｸ
    Private Const CMstrvsfMoveSlotMapTWFID                  As String = "WFID"          'WFID
    '@↓2020/02/07 (Fri) 17:16:59 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrvsfMoveSlotMapTGRB                   As String = "GRB"           'GRB
    '@↑2020/02/07 (Fri) 17:16:59 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrvsfMoveSlotMapTJIGID                 As String = "治具ID"        'JIGID
    Private Const CMstrvsfMoveSlotMapTWFStat                As String = "状態"          '状態

    '@ｸﾞﾘｯﾄ共通設定
    Private Const CMlngvsfGridTitleRow                      As Integer = 0               'ﾀｲﾄﾙ行
    Private Const CMlngvsfGridFontSize                      As Integer = 9               'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfGridRows                          As Integer = 26              'ｽﾛｯﾄﾏｯﾌﾟ行数
    Private Const CMlngvsfMouseClick                        As Integer = 1               'ﾏｳｽｸﾘｯｸﾌﾗｸﾞ=1
    Private Const CMlngvsfKeyDown                           As Integer = 2               'ｷｰﾀﾞｳﾝﾌﾗｸﾞ=2
    Private Const CMlngvsfMauseClickEvent                   As Integer = 0               'ﾏｳｽｸﾘｯｸｲﾍﾞﾝﾄ(定義)

    '@ﾀﾌﾞｲﾝﾃﾞｯｸｽ
    Private Const CMlngtabCarrier0                          As Integer = 0               'ｷｬﾘｱ登録
    Private Const CMlngtabCarrier1                          As Integer = 1               'ｷｬﾘｱ一覧
    Private Const CMlngtabCarrier2                          As Integer = 2               'ｷｬﾘｱﾒﾝﾃﾅﾝｽ
    Private Const CMlngtabCarrierMnt0                       As Integer = 0               'WF統合
    Private Const CMlngtabCarrierMnt1                       As Integer = 1               'ｽﾛｯﾄ情報変更
    Private Const CMlngtabCarrierMnt2                       As Integer = 2               'WF廃棄
    Private Const CMlngtabCarrierMnt3                       As Integer = 3               'ｷｬﾘｱ位置情報変更
    Private Const CMlngtabCarrierMnt4                       As Integer = 4               'ｷｬﾘｱ交換

    '@文字制限
    Private Const CMlngCarrierMaxByte                       As Integer = 6               'ｷｬﾘｱ最大桁数
    Private Const CMlngNoSelect                             As Integer = -1              'ｸﾞﾘｯﾄ行未選択

    '@文字
    Private Const CMstrAri                                  As String = "あり"          '状態(あり)
    Private Const CMstrSekisai                              As String = "積載"          '状態(積載)
    Private Const CMstrKara                                 As String = "空"            '状態(空)
    Private Const CMstrCleanFlgNothing                      As String = "不要"          '要洗浄(なし)
    Private Const CMstrUnloderReserve                       As String = "○"                    'Unloder予約状態
    Private Const CMstrUnloder                              As String = "UNLOADER"              'Unloder予約状態
    Private Const CMstrDefYmdHms                            As String = "0000/00/00 00:00:00"   'ﾃﾞﾌｫﾙﾄ年月日日時
    Private Const CMstrDefMdHm                              As String = "00/00 00:00"           'ﾃﾞﾌｫﾙﾄ月日時
    Private Const CMstrDefY2mdHms                           As String = "00/00/00 00:00:00"     'ﾃﾞﾌｫﾙﾄ年月日時
    Private Const CMstrNashi                                As String = "なし"          'なし

    Private Const CMlngCmbValueColID                        As Integer = 1              '装置ID・ｽﾄｯｶｰの取得列数
    Private Const CMlngCmbValueColName                      As Integer = 0              '装置ID・ｽﾄｯｶｰの名称取得列数
    Private Const CMstrCarrierMoveStatDisp                  As String = "○"            'ｷｬﾘｱ強制交換
    Private Const CMstrCarrierMoveStatOK                    As String = "1"             'ｷｬﾘｱ強制交換可能

    '@ｷｬﾘｱ位置
    Private Const CMstrOutStockerPosition                   As String = "ストッカー外"
    Private Const CMstrTransPortStatusName                  As String = "搬送中"
    Private Const CMstrTransPortStatusID                    As String = "MOVE"
    Private Const CMstrArrow                                As String = "→"
    Private Const CMstrOutStocker                           As String = "OUT"
    Private Const CMstrNoPositionInfo                       As String = "位置情報なし"

    '@ｷｬﾘｱ状態
    Private Const CMstrRelatedLotStatus1D                   As String = "-1"            '作業待ち
    Private Const CMstrRelatedLotStatus0                    As String = "0"             '作業待ち
    Private Const CMstrRelatedLotStatus1                    As String = "1"             '前処理
    Private Const CMstrRelatedLotStatus2                    As String = "2"             '処理中
    Private Const CMstrRelatedLotStatus3                    As String = "3"             '後処理
    Private Const CMstrRelatedLotStatus4                    As String = "4"             '作業終了
    Private Const CMstrRelatedLotStatus5                    As String = "5"             '送品待ち
    Private Const CMstrRelatedLotStatus8                    As String = "8"             '貼り合わせ
    Private Const CMstrRelatedLotStatus9                    As String = "9"             'ﾛｯﾄ終了

    '@ActiveControl
    Private Const CMstrCmbStockerName                       As String = "cmbStockerName"

    '@背景色
    Private Const CMlngBackColorSBlue                       As Integer = &HFFFFC0       '水色

    '@禁則文字
    Private Const CMstrNoInputString                        As String = "'"             '禁則文字："'"

    '@利用SB定数宣言
    Private Const CMstrNotAppoint                           As String = "指定なし"      '利用SB

    '@その他
    Private Const CMlngDiscNum                              As Integer = 1              'ｷｬﾘｱIDﾍﾞﾝﾀﾞｰ識別文字数
    Private Const CMlngWFCommentMaxDispRow                  As Integer = 13             'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(WF廃棄)
    Private Const CMlngCarrierCommentMaxDispRow             As Integer = 2              'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ｷｬﾘｱ一覧Tab)
    Private Const CMlngMaxLen                               As Integer = 256            'ｺﾒﾝﾄの最大文字数
    Private Const CMstrAllDisp                              As String = "全て"          '使用ｶﾃｺﾞﾘ表示用

    '@ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝの定数宣言
    Private Const CMlngoptOffline                           As Integer = 0              'ｵﾌﾗｲﾝ
    Private Const CMlngoptOnline                            As Integer = 1              'ｵﾝﾗｲﾝ
    Private Const CMstrOnlineMsg                            As String = "オンライン"    'ｵﾝﾗｲﾝ(成功MSG)
    Private Const CMstrOfflineMsg                           As String = "オフライン"    'ｵﾌﾗｲﾝ(成功MSG)


    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mtypStockerList                                 As List(Of StockerList)     'ｽﾄｯｶﾏｽﾀ格納
    Private mlngStockerListCnt                              As Integer                  'ｽﾄｯｶﾘｽﾄｶｳﾝﾄ
    Private mstrStockerName                                 As String                   'ｽﾄｯｶ名退避用

    Private mstrCarrier                                     As String                   'ｷｬﾘｱID
    Private mlngCarrTypListCnt                              As Integer                  'ｷｬﾘｱ識別ﾘｽﾄ数(ｷｬﾘｱ一覧用)
    Private mtypCarrierMaster                               As List(Of CarrierMaster)   'ｷｬﾘｱ関連ﾏｽﾀｰ格納(ｷｬﾘｱ一覧用)
    Private mlngCarrTypListCntAll                           As Integer                  'ｷｬﾘｱ識別ﾘｽﾄ数(ｷｬﾘｱ登録用)
    Private mtypCarrierMasterAll                            As List(Of CarrierMaster)   'ｷｬﾘｱ関連ﾏｽﾀｰ格納(ｷｬﾘｱ登録用)
    Private mtypCarrierAdd                                  As CarrierAdd               '登録情報格納
    Private mstrSBID                                        As String                   'ｼｽﾃﾑﾌﾞﾛｯｸ
    Private mstrSlotSize                                    As String                   'ｽﾛｯﾄｻｲｽﾞ退避用

    Private mblncmbSBID1CngFlg                              As Boolean                  '処理区分変更ﾌﾗｸﾞ(True:変更　False:未変更)
    Private mstrCarrierID0                                  As String                   'ｷｬﾘｱID登録ｷｬﾘｱID退避用変数
    Private mblnCarrierID0Flg                               As Boolean                  'ｷｬﾘｱID登録済みﾌﾗｸﾞ(True:登録済み　False:未登録)
    Private mstrCarrierID1                                  As String                   'ｷｬﾘｱﾒﾝﾃﾅﾝｽ交換先ｷｬﾘｱID退避用変数
    Private mlngLenCarrierID                                As Integer                  'ｷｬﾘｱﾒﾝﾃﾅﾝｽ交換先ｷｬﾘｱID文字数退避用変数
    Private mstrCarrType                                    As String                   'ｷｬﾘｱﾀｲﾌﾟ退避用
    Private mblnFormLoad2ActivateFlg                        As Boolean                  'ﾌｫｰﾑLoad後Activate処理ﾌﾗｸﾞ
    Private mtypChgSort                                     As ChgSort                  'ｿｰﾄ保持用
    Private mstrtxtCarrierID2CarrType                       As String                   'ｷｬﾘｱID2ｷｬﾘｱﾀｲﾌﾟ退避用
    Private mstrtxtCarrierMntCarrType                       As String                   '統合先ｷｬﾘｱIDｷｬﾘｱﾀｲﾌﾟ退避用
    Private mstrtxtCarrierMnt2CarrType                      As String                   '交換先ｷｬﾘｱIDｷｬﾘｱﾀｲﾌﾟ退避用
    Private mstrtxtCarrierID2TypeFlag                       As String                   'ｷｬﾘｱID2(ｷｬﾘｱﾒﾝﾃﾅﾝｽTab)ｷｬﾘｱﾀｲﾌﾟﾌﾗｸﾞ退避用
    Private mstrtxtCarrierMntTypeFlag                       As String                   '統合先ｷｬﾘｱ,ｷｬﾘｱﾀｲﾌﾟﾌﾗｸﾞ退避用
    Private mstrtxtCarrierMnt2TypeFlag                      As String                   '交換先ｷｬﾘｱ,ｷｬﾘｱﾀｲﾌﾟﾌﾗｸﾞ退避用

    Private mstrCarrierTypeID                               As String                   'ｷｬﾘｱﾀｲﾌﾟID格納
    Private mblnInitFlg                                     As Boolean                  'ﾒﾝﾃﾅﾝｽTabの初期化(False:実行/True:未実行)
    Private mblnCarrChangeFlag                              As Boolean                  'ｷｬﾘｱ位置変更処理実行ﾌﾗｸﾞ(True：実行済/False：未実行)
    Private mstrCarrierID2Status                            As String                   'ｷｬﾘｱID2で入力したｷｬﾘｱの状態
    Private mstrCarrierID3Status                            As String                   '統合先ｷｬﾘｱIDで入力したｷｬﾘｱの状態
    Private mstrWpTypeFlag                                  As String                   '装置種別 H/W=0, NORMAL=1, 装置未確定=""
    Private mstrWpCarryFlag                                 As String                   '移載予約ﾌﾗｸﾞ(0:なし、1:移載予約中)
    Private mstrTpalClass                                   As String                   'TPAL設定
    Private mstrEqType                                      As String                   'EQﾀｲﾌﾟ

    Private mtypCarrierCategoryList                         As CarrierCategoryList      'ｷｬﾘｱｶﾃｺﾞﾘ格納
    Private mstrCombCategoryName                            As String                   'ｶﾃｺﾞﾘ名退避用(Comb)
    Private mstrListCategoryName                            As String                   'ｶﾃｺﾞﾘ名退避用(List)
    Private mstrListComments                                As String                   'ｺﾒﾝﾄ退避用(List)
    Private mstrTextComments                                As String                   'ｺﾒﾝﾄ退避用(Text)
    Private mblnEditFlag                                    As Boolean                  '編集ﾌﾗｸﾞ(True:変更有/False:変更無)
    Private mblnAnsFlag                                     As Boolean                  '確認済みﾌﾗｸﾞ(True:変更の可否を表示済/False:変更の可否を表示未)
    Private mstrSBName                                      As String                   'ｷｬﾘｱ一覧利用SB退避用
    Private mlngSBIdx                                       As Integer                  '利用SBｺﾝﾎﾞIndex退避用
    Private mlngCarrTypeIdx                                 As Integer                  'ｷｬﾘｱﾀｲﾌﾟｺﾝﾎﾞIndex退避用
    Private mlngCombCategoryIdx                             As Integer                  'ｶﾃｺﾞﾘｺﾝﾎﾞIndex退避用
    Private mstrOpID                                        As String                   '大工程
    Private mstrStepID                                      As String                   '小工程
    Private mstrLotId                                       As String                   'ロットID
    Private mblnCfFlag                                      As Boolean                  'CFﾌﾗｸﾞ
    Private mtypLotCurState                                 As Lotprestate              'ﾛｯﾄ情報格納構造体
    Private mtypLotAttribute                                As LotAttribute             'ﾛｯﾄ属性情報格納

    Private ReadOnly vbButtonFace                           As Color = SystemColors.ControlLight
    Private buttonProcessing                                As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                        As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mintCarrierListRowBeforeSort                    As Integer                  'NSYS CarrierListのソート前選択行
    Private mblnTabSelectEnabled                            As Boolean                  'NSYS TabControlの変更許可
    Private mblnWindowClose                                 As Boolean                  'NSYS WindowCloseフラグ
    Private mblnTabCarrierMntSelect                         As Boolean                  'NSYS キャリアメンテナンスタブ切替フラグ
    Private mblnCarrierListSearch                           As Boolean                  'NSYS 

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
        mintCarrierListRowBeforeSort = 0
        mblnTabSelectEnabled = True
        mblnCarrierListSearch = True
        Form_Load()
        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/08 (Thu) 09:30:49 N.Kojima
    '更新日：2009/12/03 (Thu) 15:28:11 T.Oide
    '備　考：
    '　　　：2004/09/21 (Tue) 15:32:30 H.Wajima     一部の処理をActivateへ移動(show時のSetFocusｴﾗｰ対応。№859)
    '　　　：2004/10/04 (Mon) 10:45:40 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/10/14 (Thu) 16:28:45 M.Miura　    ｿｰﾄ保持構造体初期化を追加
    '　　　：2004/12/10 (Fri) 11:30:14 N.Kasai      端末情報取得追加
    '　　　：2005/10/26 (Wed) 15:23:10 S.Deguchi    不具合№2404の対応で,機能ﾊﾞｰｼﾞｮﾝ判定処理を修正
    '　　　：2009/12/03 (Thu) 15:28:11 T.Oide       空治具選択ﾎﾞﾀﾝ追加
    Private Sub Form_Load()

        Dim lblnAns                 As Boolean          'ｷｬﾘｱﾀｲﾌﾟ一覧取得
        Dim llngCnt                 As Integer          'ｶｳﾝﾀ変数
        Dim lstrEventName           As String           'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim ltypMasSbList           As MasSbList        'ｼｽﾃﾑﾌﾞﾛｯｸ構造体
        Dim lstrFormTitle           As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim ltypUtilRefTmInfo       As UtilRefTmInfo    '端末設定情報格納
        
        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00G0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                Exit Sub
            End If
            
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If IsNothing(.typChgSortList) Then
                    .typChgSortList = New List(Of ChgSortList)()
                Else
                    .typChgSortList.Clear()
                End If

                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00G0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '画面表示位置
            Me.Top = 0
            Me.Left = 0 - My.Settings.FormOffset
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
           
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "Form_Load"

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@Private変数初期化
            Call prvPrivate_Init()
            
            fraCarrier0.Enabled = True
            fraCarrier1.Enabled = True
            fraCarrier2.Enabled = True
            fraCarrierMnt0.Enabled = True
            fraCarrierMnt1.Enabled = True
            fraCarrierMnt2.Enabled = True
            fraCarrierMnt3.Enabled = True
            fraCarrierMnt4.Enabled = True

            RemoveHandler tabCarrier.SelectedIndexChanged, AddressOf tabCarrier_Click
            RemoveHandler tabCarrierMnt.SelectedIndexChanged, AddressOf tabCarrierMnt_Click

            '@ｷｬﾘｱ登録ﾀﾌﾞ初期化
            Call prvCarrierTab0_Init(True)
            
            '@ｷｬﾘｱ一覧ﾀﾌﾞ初期化
            Call prvCarrierTab1_Init(True)
            
            '@ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)ﾀﾌﾞ初期化
            Call prvCarrierTabMnt0_Init(True)
                
            AddHandler tabCarrier.SelectedIndexChanged, AddressOf tabCarrier_Click
            AddHandler tabCarrierMnt.SelectedIndexChanged, AddressOf tabCarrierMnt_Click
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸ取得結果
            lblnAns = pubblnMasSbList_Sel(CMstrmas_sblist__Ver, ltypMasSbList)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Sub
            Else
                '@利用SB表示
                Call prvcmbSbID_Disp(ltypMasSbList)
            End If
            
            '@空治具選択ﾎﾞﾀﾝの表示/非表示設定
            If pstrSBID = CPstrSBID1A0 Then
                cmdJigSelect.Visible = False
            Else
                cmdJigSelect.Visible = True
            End If
            
            '@ｷｬﾘｱﾀｲﾌﾟ取得について
            '@処理区分"02"の場合SB_IDに関わらず全てのｷｬﾘｱﾀｲﾌﾟ情報を取得する。
            '@(CARRIER内のﾃﾞｰﾀ有無条件も無視)
            '@このことによりｷｬﾘｱ登録時、TRNにﾃﾞｰﾀがない場合でも新規登録が可能です。

            '@ｷｬﾘｱﾀｲﾌﾟ一覧取得結果(処理区分：02全て)
            lblnAns = pubblnCarrMasList_Sel(CMstrcarrmaslist_Ver, _
                                            CPstrCD02, _
                                            mlngCarrTypListCnt, _
                                            mtypCarrierMaster, _
                                            pstrSBID)
            '@結果判定
            If lblnAns = True Then
                '@ｷｬﾘｱ登録用に全件内容を退避する
                mlngCarrTypListCntAll = mlngCarrTypListCnt
                mtypCarrierMasterAll = New List(Of CarrierMaster)(mtypCarrierMaster)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If
            
            '@ｷｬﾘｱ一覧のｷｬﾘｱﾀｲﾌﾟｺﾝﾎﾞに格納する為、記述している。
            '@(ｷｬﾘｱ一覧ﾀﾌﾞで取得してもよいがｷｬﾘｱ一覧msgで件数が多い場合のﾚｽﾎﾟﾝｽを
            '@考慮してここで格納する。)
            
            '@共通構造体の初期化
            mlngCarrTypListCnt = 0
            If IsNothing(mtypCarrierMaster) Then
                mtypCarrierMaster = New List(Of CarrierMaster)()
            Else
                mtypCarrierMaster.Clear()
            End If

            '@ｷｬﾘｱﾀｲﾌﾟ一覧取得結果(処理区分：38ｷｬﾘｱﾀｲﾌﾟ)
            lblnAns = pubblnCarrMasList_Sel(CMstrcarrmaslist_Ver, _
                                            CPstrCD38, _
                                            mlngCarrTypListCnt, _
                                            mtypCarrierMaster, _
                                            pstrSBID)
            '@結果判定
            If lblnAns = True Then
                '@ｷｬﾘｱﾀｲﾌﾟ一覧情報表示
                Call prvcmbCarrTyp_Disp(mlngCarrTypListCnt, mtypCarrierMaster)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If
            
            '@ｺﾝﾋﾟｭｰﾀ名(META実行時はWBTのｸﾗｲｱﾝﾄ名)の設定
            Call pubGetWbtComputerName()
            
            '@MSG[端末設定情報取得]の実行
            lblnAns = pubblnUtilRefTmInfo_Sel(pstrSBID, _
                                              CMstrutilreftminfoVer, _
                                              pstrComputerName, _
                                              ltypUtilRefTmInfo)

            '@結果判定
            If lblnAns = True Then
                
                With ltypUtilRefTmInfo
                    
                    '@取得した値がNULLではない場合
                    If .strCarrierTypeID <> vbNullString Then
                        '@取得した値を変数に代入
                        mstrCarrierTypeID = .strCarrierTypeID
                    End If
                    
                    '@ｷｬﾘｱﾀｲﾌﾟｺﾝﾎﾞ初期設定
                    For llngCnt = 0 To mlngCarrTypListCnt - 1
                        '@端末情報のｷｬﾘﾀｲﾌﾟとﾏｽﾀのｷｬﾘｱﾀｲﾌﾟを比較
                        If mtypCarrierMaster(llngCnt).strCarrierTypeID = mstrCarrierTypeID Then
                            '@一致した場合は初期設定
                            cmbCarrType.Text = mtypCarrierMaster(llngCnt).strCarrierTypeName
                            
                            '@前回ｷｬﾘｱﾀｲﾌﾟへ格納(和名)
                            mstrCarrType = mtypCarrierMaster(llngCnt).strCarrierTypeName
                            Exit For
                        End If
                    Next llngCnt
                    
                    '@検索結果が一致なしの場合はｺﾝﾎﾞ空白
                    If llngCnt > mlngCarrTypListCnt Then
                        cmbCarrType.ListIndex = -1
                    End If
                End With
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            '@ﾌｫｰﾑLoad後ActivateﾌﾗｸﾞにTrueを設定する
            mblnFormLoad2ActivateFlg = True
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
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
    '機　能：ﾌｫｰﾑｱｸﾃｨﾌﾞ化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/21 (Tue) 15:30:13 H.Wajima
    '更新日：2004/10/29 (Fri) 10:09:18 M.Miura
    '備　考：
    '　　　：2004/10/29 (Fri) 10:09:18 M.Miura　    単独起動の場合に利用SBにﾌｫｰｶｽｾｯﾄを追加
    '　　　：2005/05/30 (Mon) 10:24:59 S.Deguchi    ｾｯﾄﾌｫｰｶｽ対応
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑLoad後Activateﾌﾗｸﾞの判定
            '@ﾌｫｰﾑLoad後の場合のみ処理を行う
            If mblnFormLoad2ActivateFlg = False Then
            '@ﾌｫｰﾑLoad後のActivateｲﾍﾞﾝﾄの以外の場合
                '@Escﾎﾞﾀﾝを有効
                '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
                Me.CancelButton = cmdClose
                
                '@処理を抜ける
                Exit Sub
            Else
            '@ﾌｫｰﾑLoad後のActivateｲﾍﾞﾝﾄの場合
                '@ﾌｫｰﾑLoad後ActivateﾌﾗｸﾞにFalseを設定する
                mblnFormLoad2ActivateFlg = False
            End If
            
            '@在庫管理から呼ばれた場合
            If ptypHoldConnect.strCarrierId <> vbNullString Then
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸの格納
                mstrSBID = ptypHoldConnect.strSbID
                
                '@ｷｬﾘｱﾒﾝﾃﾅﾝｽﾀﾌﾞ表示
                tabCarrier.SelectTab(CMlngtabCarrier2)
                
                '@WF統合ﾀﾌﾞ最前面
                tabCarrierMnt.SelectTab(CMlngtabCarrierMnt0)
                
                '@ｷｬﾘｱID設定
                With txtCarrierID2
                    .TabStop = False                        'ﾀﾌﾞｽﾄｯﾌﾟなし
                    .BackColor = vbButtonFace               '背景色(灰)
                    .GotBackColor = vbButtonFace            'ﾌｫｰｶｽ取得時背景色(灰)
                    .Text = ptypHoldConnect.strCarrierId    '在庫管理のｷｬﾘｱIDをｾｯﾄ
                    .GotHighLight = True                    'ﾌｫｰｶｽ取得時のﾊｲﾗｲﾄあり(一時的)
                End With
              
                '@ｷｬﾘｱﾒﾝﾃﾅﾝｽﾀﾌﾞ表示
                Call tabCarrier_Click(tabCarrier, New EventArgs())
                
                '@ｷｬﾘｱIDをﾛｯｸ(ﾌｫｰｶｽｾｯﾄにてｴﾗｰになるのを回避)
                txtCarrierID2.Locked = True
                
                '@ｷｬﾘｱ情報表示処理
                RemoveHandler txtCarrierID2.Validating, AddressOf txtCarrierID2_Validate
                Call txtCarrierID2_Validate(txtCarrierID2, New CancelEventArgs(False))
                AddHandler txtCarrierID2.Validating, AddressOf txtCarrierID2_Validate

                '@ﾊｲﾗｲﾄなし(Validateを1回走らせるため、Call txtCarrierID2_Validateの後で設定)
                txtCarrierID2.GotHighLight = False
            Else
                '@ｼｽﾃﾑﾌﾞﾛｯｸの格納
                mstrSBID = pstrSBID
                
                '@ｷｬﾘｱ登録ﾀﾌﾞ表示
                tabCarrier.SelectTab(CMlngtabCarrier0)
                
                '@WF統合最前面
                tabCarrierMnt.SelectTab(CMlngtabCarrierMnt0)
                
                '@有効ﾀﾌﾞ制御
                fraCarrier0.Enabled = True
                fraCarrier1.Enabled = False
                fraCarrier2.Enabled = False
                
                '@利用SBにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbSBID0)
            End If
            
            '@Escﾎﾞﾀﾝを有効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = cmdClose
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_Activate"          '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2004/07/08 (Thu) 09:31:25 N.Kojima
    '更新日：2009/12/03 (Thu) 13:34:40 T.Oide
    '備　考：
    '　　　：2004/12/06 (Mon) 18:01:38 N.Kojima　   出庫指示機能追加に伴い、Enterｷｰ押下時の処理を修正(改善№179)
    '　　　：2005/03/25 (Fri) 10:17:19 N.Kasai      ｷｰﾎﾞｰﾄﾞ制御を追加
    '　　　：2006/02/28 (Tue) 15:52:15 N.Kojima     使用ｶﾃｺﾞﾘ選択時のｷｰ操作追加。(ﾕｰｻﾞｰ要望№0141)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑのﾛｯｸ中は処理を行わない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    Select Case tabCarrier.SelectedIndex
                        '@ｷｬﾘｱ登録ﾀﾌﾞ
                        Case CMlngtabCarrier0
                            '@製造年月日の場合
                            If ActiveControl.Name = calManuDate.Name Then
                                '@Validate処理へ
                                RemoveHandler calManuDate.Validating, AddressOf calManuDate_Validate
                                Call calManuDate_Validate(calManuDate, New CancelEventArgs(True))
                                AddHandler calManuDate.Validating, AddressOf calManuDate_Validate
                                e.Handled = True
                                Exit Sub
                            End If
                            
                        '@ｷｬﾘｱ一覧ﾀﾌﾞ
                        Case CMlngtabCarrier1
                            
                            Select Case ActiveControl.Name
                                
                                Case cmbCarrType.Name
                                    '@ﾌｫｰｶｽの移動
                                    SendKeys.SendWait(CPstrSendKeysTab)
                                    e.Handled = True
                                    '@ｽﾌﾟﾚｯﾄﾞの状態ﾁｪｯｸ
                                    If vsfCarrierList.Enabled = True Then
                                        '@Enabled = Trueの場合
                                        Call pubSetFocus(vsfCarrierList)   'ﾌｫｰｶｽの移動
                                    End If
                    
                                    '@ｷｬﾘｱﾀｲﾌﾟが選ばれた場合
                                    If cmbCarrType.Text <> vbNullString Then
                                        Exit Sub
                                    End If
                                
                                Case cmbUseCategory.Name
                                    '@ﾌｫｰｶｽの移動
                                    SendKeys.SendWait(CPstrSendKeysTab)
                                    e.Handled = True
                                    '@ｽﾌﾟﾚｯﾄﾞの状態ﾁｪｯｸ
                                    If vsfCarrierList.Enabled = True Then
                                        '@Enabled = Trueの場合
                                        Call pubSetFocus(vsfCarrierList)   'ﾌｫｰｶｽの移動
                                    End If

                                    '@使用ｶﾃｺﾞﾘが選ばれた場合
                                    If cmbUseCategory.Text <> vbNullString Then
                                        Exit Sub
                                    End If

                                Case Else
                            End Select
                            
                        '@ｷｬﾘｱﾒﾝﾃﾅﾝｽﾀﾌﾞ
                        Case CMlngtabCarrier2
                            Select Case ActiveControl.Name
                                Case txtCarrierID2.Name
                                    '@ｷｬﾘｱ統合先ｷｬﾘｱID表示
                                    RemoveHandler txtCarrierID2.Validating, AddressOf txtCarrierID2_Validate
                                    Call txtCarrierID2_Validate(txtCarrierID2, New CancelEventArgs(False))
                                    AddHandler txtCarrierID2.Validating, AddressOf txtCarrierID2_Validate
                                    Exit Sub
                                Case txtCarrierMnt.Name
                                    '@ｷｬﾘｱ統合先ｷｬﾘｱID表示
                                    RemoveHandler txtCarrierMnt.Validating, AddressOf txtCarrierMnt_Validate
                                    Call txtCarrierMnt_Validate(txtCarrierMnt, New CancelEventArgs(False))
                                    AddHandler txtCarrierMnt.Validating, AddressOf txtCarrierMnt_Validate
                                    Exit Sub
                                Case txtComment.Name
                                    '@ｺﾒﾝﾄ改行の為
                                    Exit Sub
                            End Select
                    End Select

                    '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが「ｽﾄｯｶｰ」ではない場合
                    If ActiveControl.Name <> CMstrCmbStockerName Then
                        If ActiveControl IsNot vsfMoveSlotMap4.Editor Then
                            '@次項目にﾌｫｰｶｽ移動
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                        End If
                    Else
                        '@ｷｬﾘｱ一覧が有効な場合
                        If vsfCarrierList.Enabled = True Then
                            '@ｷｬﾘｱ一覧にﾌｫｰｶｽ移動
                            Call pubSetFocus(vsfCarrierList)
                            e.Handled = True
                        End If
                    End If

            End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_KeyDown"           '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：Form_KeyUp
    '機　能：
    '引　数：KeyCode：
    '　　　：Shift：
    '戻り値：
    '作成日：2009/12/03 (Thu) 13:42:35 T.Oide
    '更新日：2009/12/03 (Thu) 13:42:35
    '備　考：
    Private Sub Form_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyUp

        Try
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑのﾛｯｸ中は処理を行わない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            Select Case e.KeyCode
            
                '@↓↑ｷｰの場合
                Case Keys.Down, Keys.Up
                    
                    If ActiveControl.Name = vsfMoveSlotMap4.Name Then
                    
                        '@空治具選択ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
                        Call prvCmdJigSelect_Set()
                        
                    End If
            
            End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_KeyDown"           '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/02/18 (Wed) 17:31:14 K.Takano
    '更新日：2013/05/17 (Fri) 10:40:30 T.Oide
    '備　考：
    '　　　：2004/10/14 (Thu) 16:44:20 M.Miura　    ｿｰﾄ保持用構造体のｸﾘｱを追加
    '　　　：2004/11/01 (Mon) 15:12:23 N.Kasai      閉じるﾎﾞﾀﾝ統合
    '　　　：2004/11/29 (Mon) 14:40:27 N.Kojima　   出庫指示機能追加に伴い、初期化処理追加
    '　　　：2005/01/08 (Sat) 17:09:32 N.Kasai      構造体初期化追加
    '　　　：2006/02/21 (Tue) 16:56:41 N.Kojima     ｶﾃｺﾞﾘ退避変数、ｶﾃｺﾞﾘﾘｽﾄ格納配列の初期化処理追加。(ﾕｰｻﾞｰ要望№0141)
    '　　　：2013/05/16 (Thu) 16:08:15 T.Oide       蒸着治具ODF対応
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納
        Dim llngAns                 As Integer          '戻り値
        
        Try

            '@編集中判定(編集ﾌﾗｸﾞから判断)
            If mblnEditFlag = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                
                '@"編集中です。 内容を破棄してよろしいですか？"
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                '@要求確認
                If llngAns = vbNo Then
                    '@確認済みﾌﾗｸﾞをFalseに初期化
                    mblnAnsFlag = False
                
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                    e.Cancel = True
                    Exit Sub
                Else
                    '@確認済みﾌﾗｸﾞをTrueに(cmdNowList_Clickで2度表示されるのを防止)
                    mblnAnsFlag = True
                End If
            End If

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@Private変数初期化
            Call prvPrivate_Init()
            
            '@ﾓｼﾞｭｰﾙ変数のｸﾘｱ
            mstrStockerName = vbNullString                      'ｽﾄｯｶｰ退避用
            mlngStockerListCnt = 0                              'ｽﾄｯｶｰﾘｽﾄｶｳﾝﾄ
            mstrCombCategoryName = vbNullString                 'ｶﾃｺﾞﾘ名退避用(ｺﾝﾎﾞ)
            mstrListCategoryName = vbNullString                 'ｶﾃｺﾞﾘ名退避用(ﾘｽﾄ)
            mstrListComments = vbNullString                     'ｺﾒﾝﾄ退避用
            mblnEditFlag = False                                '編集中ﾌﾗｸﾞ

            '@ﾓｼﾞｭｰﾙ構造体の初期化
            If Not IsNothing(mtypStockerList) Then              'ｽﾄｯｶﾘｽﾄ格納用
                mtypStockerList.Clear()
                mtypStockerList = Nothing
            End If
            If Not IsNothing(mtypCarrierMaster) Then            'ｷｬﾘｱ関連ﾏｽﾀｰ格納(ｷｬﾘｱ一覧用)
                mtypCarrierMaster.Clear()
                mtypCarrierMaster = Nothing
            End If
            If Not IsNothing(mtypCarrierMasterAll) Then         'ｷｬﾘｱ関連ﾏｽﾀｰ格納(ｷｬﾘｱ登録用)
                mtypCarrierMasterAll.Clear()
                mtypCarrierMasterAll = Nothing
            End If
            If Not IsNothing(mtypCarrierCategoryList.typCarrierCategory) Then 'ｷｬﾘｱｶﾃｺﾞﾘ格納用
                mtypCarrierCategoryList.typCarrierCategory.Clear()
                mtypCarrierCategoryList.typCarrierCategory = Nothing
            End If
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            'Erase mtypChgSort.typChgSortList()
            If Not IsNothing(mtypChgSort.typChgSortList) Then
                mtypChgSort.typChgSortList.Clear()
                mtypChgSort.typChgSortList = Nothing
            End If
            
            '@在庫管理から呼ばれていない場合
            If ptypHoldConnect.strCarrierId = vbNullString Then
                '@Actを自前で初期化した場合
                If pblnActInitFlg = True Then
                    '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                    lblnAnsTerm = pubblnAct_Term()
                    If lblnAnsTerm = True Then
                        '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                    End If
                Else
                    '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                    Call pubMenuExpand_Disp()
                End If
            End If
            
            '@ﾊﾟﾌﾞﾘｯｸ変数初期化
            pstrAtlasFlowNumber = vbNullString
            
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

    '関数名：cmbUseCategory_Change
    '機　能：使用ｶﾃｺﾞﾘ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/21 (Tue) 15:54:13 N.Kojima
    '更新日：2006/05/10 (Wed) 15:52:53 M.Miura 運用障害№758、不具合№3463対応(編集中に使用ｶﾃｺﾞﾘ変更した場合にﾀﾞｲｱﾛｸﾞ表示)
    '備　考：
    Private Sub cmbUseCategory_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbUseCategory.Change
        Dim llngAns As Integer '戻り値格納
        
        Try

            '@編集中の場合
            With cmbUseCategory
                If mblnEditFlag = True Then
                    '@使用ｶﾃｺﾞﾘが変更された場合(破棄しますか？が2回表示しない為の判定)
                    If .ListIndex <> mlngCombCategoryIdx Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                        
                        '@"編集中です。 内容を破棄してよろしいですか？"
                        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                        '@要求確認
                        If llngAns = vbNo Then
                            '@「いいえ」選択の場合は使用ｶﾃｺﾞﾘを変更前に戻す
                            .ListIndex = mlngCombCategoryIdx
                            Exit Sub
                        End If
                    Else
                        '@使用ｶﾃｺﾞﾘが変更されなかった場合は抜ける
                        Exit Sub
                    End If
                End If
                '@ｶﾃｺﾞﾘｺﾝﾎﾞIndex退避
                mlngCombCategoryIdx = .ListIndex
            End With
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If IsNothing(.typChgSortList) Then
                    .typChgSortList = New List(Of ChgSortList)()
                Else
                    .typChgSortList.Clear()
                End If
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
          
            '@編集中ﾌﾗｸﾞを初期化
            mblnEditFlag = False
            '@ｺﾒﾝﾄﾃｷｽﾄを初期化
            txtCarrierComments.Text = vbNullString
            '@ｺﾒﾝﾄﾌｨｰﾙﾄﾞを無効にする
            txtCarrierComments.Enabled = False
          
            '@ｷｬﾘｱ一覧の初期化
            With vsfCarrierList
                .Redraw = False
                .Rows.Count = .Rows.Fixed
                .Redraw = True
                .Enabled = False
            End With

            '@使用ｶﾃｺﾞﾘが空白以外の場合
            If cmbUseCategory.Text = vbNullString Then
                '@使用ｶﾃｺﾞﾘ・ｺﾒﾝﾄ変更ﾎﾞﾀﾝを無効に
                cmdUpdate.Enabled = False
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbUseCategory_Change"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbUseCategory_CloseUp
    '機　能：使用ｶﾃｺﾞﾘのCloseUp
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/21 (Tue) 15:55:56 N.Kojima
    '更新日：2006/02/21 (Tue) 15:55:56
    '備　考：
    Private Sub cmbUseCategory_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbUseCategory.CloseUp
        
        Try
                 
            '@cmbUseCategoryのValidateｲﾍﾞﾝﾄ呼び出す
            RemoveHandler cmbUseCategory.Validating, AddressOf cmbUseCategory_Validate
            Call cmbUseCategory_Validate(cmbUseCategory, New CancelEventArgs(True))
            AddHandler cmbUseCategory.Validating, AddressOf cmbUseCategory_Validate
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbUseCategory_CloseUp" '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbUseCategory_Validate
    '機　能：使用ｶﾃｺﾞﾘのValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/02/21 (Tue) 16:45:42 N.Kojima
    '更新日：2006/02/21 (Tue) 16:45:42
    '備　考：
    Private Sub cmbUseCategory_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbUseCategory.Validating
        
        Dim lblnNextCtrl            As Boolean          'NSYS Focus設定フラグ
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If

            ' NSYS フォーカス設定可能か判定
            If Me.ActiveControl.Name = cmbUseCategory.Name OrElse _
                (Me.ActiveControl.Name = cmbStockerName.Name AndAlso cmbStockerName.Visible AndAlso cmbStockerName.Enabled) OrElse _
                (Not (cmbStockerName.Visible AndAlso cmbStockerName.Enabled) AndAlso Me.ActiveControl.Name = vsfCarrierList.Name) Then
                ' 次コントロールがアクティブの場合
                lblnNextCtrl = True
            Else
                ' 次コントロール以外がアクティブの場合
                lblnNextCtrl = False
            End If

            '@前回のｶﾃｺﾞﾘと同じ場合は処理を抜ける
            If mstrCombCategoryName = cmbUseCategory.Text Then
                '@ﾌｫｰｶｽを移動
                With vsfCarrierList
                    '@ｽﾄｯｶｰｺﾝﾎﾞが表示されていて、かつ有効な場合
                    If cmbStockerName.Visible = True And cmbStockerName.Enabled = True Then
                        '@ﾌｫｰｶｽの移動(ｽﾄｯｶｰｺﾝﾎﾞへ)
	                    If lblnNextCtrl Then
                        	Call pubSetFocus(cmbStockerName)
	                    End If
                    Else
                        '@ｷｬﾘｱ一覧にﾃﾞｰﾀが1件以上ある場合
                        If vsfCarrierList.Rows.Count > vsfCarrierList.Rows.Fixed Then
                            '@ﾌｫｰｶｽの移動(ｷｬﾘｱ一覧へ)
	                        If lblnNextCtrl Then
	                            Call pubSetFocus(vsfCarrierList)
	                        End If
                        Else
                            '@最新取得ﾎﾞﾀﾝが有効か
                            If cmdNowList.Enabled = True Then
                                '@ﾌｫｰｶｽの移動(最新取得ﾎﾞﾀﾝへ)
	                            If lblnNextCtrl Then
	                                Call pubSetFocus(cmdNowList)
	                            End If 
                            Else
                                '@ﾌｫｰｶｽの移動(閉じるﾎﾞﾀﾝへ)
	                            If lblnNextCtrl Then
	                                Call pubSetFocus(cmdClose)
	                            End If
                            End If
                        End If
                    End If
                End With
            
                Exit Sub
            End If

            '@取得列をｶﾃｺﾞﾘID列に設定
            cmbUseCategory.ValueCol = CMlngCmbValueColID
            
            '@ｷｬﾘｱ一覧表示
            Call cmdNowList_Click(cmdNowList, New EventArgs())
            
            With vsfCarrierList
                
                '@ｽﾄｯｶｰｺﾝﾎﾞが表示されていて、かつ有効な場合
                If cmbStockerName.Visible = True And cmbStockerName.Enabled = True Then
                    '@ﾌｫｰｶｽの移動(ｽﾄｯｶｰｺﾝﾎﾞへ)
                    If lblnNextCtrl Then
                    	Call pubSetFocus(cmbStockerName)
                    End If
                Else
                    '@ｷｬﾘｱ一覧にﾃﾞｰﾀが1件以上ある場合
                    If vsfCarrierList.Rows.Count > vsfCarrierList.Rows.Fixed Then
                        '@ﾌｫｰｶｽの移動(ｷｬﾘｱ一覧へ)
	                    If lblnNextCtrl Then
	                        Call pubSetFocus(vsfCarrierList)
	                    End If
                    Else
                        '@最新取得ﾎﾞﾀﾝが有効か
                        If cmdNowList.Enabled = True Then
                            '@ﾌｫｰｶｽの移動(最新取得ﾎﾞﾀﾝへ)
	                        If lblnNextCtrl Then
	                            Call pubSetFocus(cmdNowList)
	                        End If
                        Else
                            '@ﾌｫｰｶｽの移動(閉じるﾎﾞﾀﾝへ)
	                        If lblnNextCtrl Then
	                            Call pubSetFocus(cmdClose)
	                        End If
                        End If
                    End If
                End If
                
            End With
            
            '@ｶﾃｺﾞﾘ退避用変数に値を格納
            mstrCombCategoryName = cmbUseCategory.Text
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbUseCategory_Validate"    '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbStockerName_Change
    '機　能：ｽﾄｯｶｰ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 14:27:45 N.Kojima
    '更新日：2004/11/18 (Thu) 14:27:45
    '備　考：
    Private Sub cmbStockerName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStockerName.Change
        
        Try

            '@ｽﾄｯｶｰが空白以外の場合
            If cmbStockerName.Text = vbNullString Then
                '@出庫指示ﾎﾞﾀﾝを無効に
                cmdShip.Enabled = False
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbStockerName_Change"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStockerName_CloseUp
    '機　能：ｽﾄｯｶｰのCloseUp
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 14:32:16 N.Kojima
    '更新日：2004/11/18 (Thu) 14:32:16
    '備　考：
    Private Sub cmbStockerName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStockerName.CloseUp
        
        Dim llngCnt             As Integer      'ｶｳﾝﾄ
        
        Try
            
            With vsfCarrierList
                '@ｽﾄｯｶｰが空白の場合
                If cmbStockerName.Text <> vbNullString Then
                    
                    '@cmbStockerNameのValidateｲﾍﾞﾝﾄ呼び出す
                    RemoveHandler cmbStockerName.Validating, AddressOf cmbStockerName_Validate
                    Call cmbStockerName_Validate(cmbStockerName, New CancelEventArgs(True))
                    AddHandler cmbStockerName.Validating, AddressOf cmbStockerName_Validate
                    
                    '@ｷｬﾘｱﾘｽﾄが有効な場合
                    If .Enabled = True Then
                        '@ﾌｫｰｶｽの移動
                        Call pubSetFocus(vsfCarrierList)
                    End If
                End If
                
                For llngCnt = 0 To mlngStockerListCnt - 1
                    '@ｽﾄｯｶｰIDと選択ｷｬﾘｱ位置IDが同じか
                    If .GetData(.Row, CMlngvsfCarrierListColPositionID) _
                        = mtypStockerList(llngCnt).strStockerId Then
                        
                        '@出庫指示ﾎﾞﾀﾝを有効に
                        cmdShip.Enabled = True
                        Exit For
                    Else
                        '@出庫指示ﾎﾞﾀﾝを無効に
                        cmdShip.Enabled = False
                    End If
                Next llngCnt
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbStockerName_CloseUp" '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStockerName_Validate
    '機　能：ｽﾄｯｶｰのValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 14:32:02 N.Kojima
    '更新日：2004/12/13 (Mon) 11:20:24 N.Kasai
    '備　考：
    '　　　：2004/12/13 (Mon) 11:20:24 N.Kasai      CLng関数の前に数値ﾁｪｯｸを追加
    Private Sub cmbStockerName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbStockerName.Validating
        
        Dim llngCarrierCnt      As Integer
        Dim lblnNextCtrl        As Boolean          'NSYS Focus設定フラグ
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If
            
            ' NSYS フォーカス設定可能か判定
            If Me.ActiveControl.Name = vsfCarrierList.Name Then
                ' 次コントロールがアクティブの場合
                lblnNextCtrl = True
            Else
                ' 次コントロール以外がアクティブの場合
                lblnNextCtrl = False
            End If
            
            '@前回のｽﾄｯｶｰと同じ場合、ｽﾄｯｶｰが未選択状態の場合は処理を抜ける
            If mstrStockerName = cmbStockerName.Text Or _
                cmbStockerName.Value = vbNullString Then
                Exit Sub
            End If

            '@取得列をｽﾄｯｶｰに設定
            cmbStockerName.ValueCol = CMlngCmbValueColID
            
            '@該当件数の数値判定
            If IsNumeric(lblCarrierCnt.Text) = True Then
                llngCarrierCnt = CInt(lblCarrierCnt.Text)
            Else
                llngCarrierCnt = 0
            End If
            
            '@取得件数のﾁｪｯｸ
            If llngCarrierCnt > 0 Then
                '@ﾌｫｰﾑﾛｰﾄﾞ中ではない場合
                If pblnFormLoad = True Then
                    '@取得件数が0件以上の場合はﾌｫｰｶｽを移動
                    If lblnNextCtrl Then
                    	Call pubSetFocus(vsfCarrierList)
                    End If
                End If
            End If
            
            '@ｽﾄｯｶｰ退避用変数に値を格納
            mstrStockerName = cmbStockerName.Text
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbStockerName_Validate"    '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdUpdate_Click
    '機　能：使用ｶﾃｺﾞﾘ/ｺﾒﾝﾄ変更ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/21 (Tue) 17:03:03 N.Kojima
    '更新日：2006/02/21 (Tue) 17:03:03
    '備　考：
    Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click

        Dim lblnAns                     As Boolean              '戻り値
        Dim llngCnt                     As Integer              '汎用ｶｳﾝﾀ
        Dim llngCnt2                    As Integer              '汎用ｶｳﾝﾀ2
        Dim llngCarrierInfoChgCnt       As Integer              'ｷｬﾘｱ情報変更ｶｳﾝﾀ
        Dim lstrEditTime                As String               '最終更新日時
        Dim lstrFormName                As String               'ﾌｫｰﾑ名
        Dim lstrEventName               As String               'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        Dim ltypCarrierUpdate           As CarrierUpdateList    'ｷｬﾘｱ情報更新
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱ一覧のﾘｽﾄ件数が0件、NULL、数値以外の場合
            If lblCarrierCnt.Text = CPstrZero Or _
                lblCarrierCnt.Text = vbNullString Or _
                IsNumeric(lblCarrierCnt.Text) = False Then
                
                Exit Sub
            End If
            
            llngCarrierInfoChgCnt = 0 'NSYS 初期化
            
            '@不正なﾃﾞｰﾀがないかﾁｪｯｸし、正常なﾃﾞｰﾀの場合は送信用構造体に格納
            With vsfCarrierList
            
                For llngCnt = 1 To CInt(lblCarrierCnt.Text)
                    '@更新候補か
                    If .GetCellRange(llngCnt, CMlngvsfCarrierListColCategoryName).StyleDisplay.BackColor = _
                    	ColorTranslator.FromWin32(CMlngBackColorSBlue) Or _
                        .GetCellRange(llngCnt, CMlngvsfCarrierListColComments).StyleDisplay.BackColor = _
                        ColorTranslator.FromWin32(CMlngBackColorSBlue) Then
                        '@ｷｬﾘｱIDがNULLか
                        If .GetData(llngCnt, CMlngvsfCarrierListColCarrierID) = vbNullString Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                            '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが設定されていません。設定を見直してください。")
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@格納構造体の配列の初期化
                            If IsNothing(ltypCarrierUpdate.typCarrierUpdateInfo) Then
                                ltypCarrierUpdate.typCarrierUpdateInfo = New List(Of CarrierUpdateInfo)
                            Else
                                ltypCarrierUpdate.typCarrierUpdateInfo.Clear()
                            End If
                            
                            '@ﾌｫｰｶｽの設定
                            Call pubSetFocus(cmdUpdate)
                            Exit Sub
                        Else
                            '@正常なﾃﾞｰﾀの場合
                            
                            
                            '@配列の確保
                            Dim typCarrierUpdateInfoTmp As CarrierUpdateInfo = New CarrierUpdateInfo()
                            If IsNothing(ltypCarrierUpdate.typCarrierUpdateInfo) Then
                                ltypCarrierUpdate.typCarrierUpdateInfo = New List(Of CarrierUpdateInfo)
                            End If
                            
                            '@ｷｬﾘｱ情報更新要求ﾃﾞｰﾀ格納
                            typCarrierUpdateInfoTmp.strCarrierId = _
                                .GetData(llngCnt, CMlngvsfCarrierListColCarrierID)            'ｷｬﾘｱID
                            
                            '@更新候補のｶﾃｺﾞﾘIDをﾏｽﾀから検索しｾｯﾄし直す
                            For llngCnt2 = 0 To mtypCarrierCategoryList.lngCarrierCategoryCnt - 1
                                '@更新候補のｶﾃｺﾞﾘ名とﾏｽﾀのｶﾃｺﾞﾘ名が同じか
                                If mtypCarrierCategoryList.typCarrierCategory(llngCnt2).strCategoryName = _
                                    .GetData(llngCnt, CMlngvsfCarrierListColCategoryName) Then
                                    
                                    typCarrierUpdateInfoTmp.strCategoryID = _
                                        mtypCarrierCategoryList.typCarrierCategory(llngCnt2).strCategoryID      'ｶﾃｺﾞﾘID
                                    Exit For
                                End If
                            Next llngCnt2
                            
                            typCarrierUpdateInfoTmp.strComments = _
                                .GetData(llngCnt, CMlngvsfCarrierListColComments)             'ｺﾒﾝﾄ
							
							ltypCarrierUpdate.typCarrierUpdateInfo.Add(typCarrierUpdateInfoTmp)
                            '@配列のｶｳﾝﾄUP
                            llngCarrierInfoChgCnt = llngCarrierInfoChgCnt + 1
                        End If
                    End If
                Next llngCnt
            End With
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "cmdUpdate_Click"
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ｷｬﾘｱ情報更新(現在は応答のEDIT_TIMEは使用していないが、必要が生じた場合使用する)
            lblnAns = pubblnCarrUpdate_Upd(CMstrcarrupdate__Ver, _
                                           cmbSBID1.Value, _
                                           llngCarrierInfoChgCnt, _
                                           ltypCarrierUpdate, _
                                           lstrEditTime)
            
            '@戻り値判定
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@表示ﾒｯｾｰｼﾞ変換("<TRM5BI>$$キャリア情報を更新しました。")
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005B)
                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)

                '@編集中ﾌﾗｸﾞ、確認済みﾌﾗｸﾞを初期化
                mblnEditFlag = False
                mblnAnsFlag = False

                '@最新情報取得
                Call cmdNowList_Click(cmdNowList, New EventArgs())
                
                '@使用ｶﾃｺﾞﾘ/ｺﾒﾝﾄ変更ﾎﾞﾀﾝを無効にする
                cmdUpdate.Enabled = False
                
                '@ﾌｫｰｶｽｾｯﾄ
                If vsfCarrierList.Enabled = True Then
                    Call pubSetFocus(vsfCarrierList)
                End If
                
                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "cmdUpdate_Click"                '処理名
                .strErrMessage = ""                             'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdShip_Click
    '機　能：出庫指示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 14:32:40 N.Kojima
    '更新日：2006/02/27 (Mon) 19:22:38 N.Kojima
    '備　考：
    '　　　：2004/12/09 (Thu) 14:57:43 S.Deguchi    最新取得処理復活＆ﾌｫｰｶｽｾｯﾄ(不要かも)
    '　　　：2006/02/27 (Mon) 19:22:38 N.Kojima     編集中のﾒｯｾｰｼﾞを表示する。(ﾕｰｻﾞｰ要望№0141)
    Private Sub cmdShip_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdShip.Click
        
        Dim lblnAns                 As Boolean          '戻り値
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim lstrEventName           As String           'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        Dim lstrCarrierID           As String           'ｷｬﾘｱID
        Dim lstrCarrierPosition     As String           'ｷｬﾘｱ位置
        Dim lstrCarrierStatus       As String           'ｷｬﾘｱ状態
        Dim llngAns                 As Integer          '戻り値
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@編集中判定(編集ﾌﾗｸﾞから判断)
            If mblnEditFlag = True Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                
                '@"編集中です。 内容を破棄してよろしいですか？"
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                '@要求確認
                If llngAns = vbNo Then
                    '@確認済みﾌﾗｸﾞをFalseに初期化
                    mblnAnsFlag = False
                
                    '@出庫ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdShip)
                    Exit Sub
                Else
                    '@確認済みﾌﾗｸﾞをTrueに(cmdNowList_Clickで2度表示されるのを防止)
                    mblnAnsFlag = True
                End If
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾃﾞｰﾀﾁｪｯｸ用
            With vsfCarrierList
                lstrCarrierID = .GetData(.Row, CMlngvsfCarrierListColCarrierID)                'ｷｬﾘｱID
                lstrCarrierPosition = .GetData(.Row, CMlngvsfCarrierListColPositionID)         'ｷｬﾘｱ位置ID
                lstrCarrierStatus = .GetData(.Row, CMlngvsfCarrierListColCarrierStat)          'ｷｬﾘｱ状態
            End With

            '@空の項目があれば中止
            '@ｷｬﾘｱIDﾁｪｯｸ
            If lstrCarrierID = vbNullString Then

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)

                '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが設定されていません。設定を見直してください。")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@ﾌｫｰｶｽの設定
                Call pubSetFocus(cmdShip)
                Exit Sub
            End If
            
            '@ｷｬﾘｱ位置ﾁｪｯｸ(ｽﾄｯｶ内の場合(位置情報なし(POS0001)、ｽﾄｯｶ外(OUT)か)
            If lstrCarrierPosition = CPstrCarrierPosition Or _
                Strings.Right$(Trim$(lstrCarrierPosition), 1) = CMstrOutStocker Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004C, lstrCarrierID)

                '@失敗ﾒｯｾｰｼﾞ表示("キャリア[%1]はストッカー内に存在しません。")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@ﾌｫｰｶｽ設定
                Call pubSetFocus(cmdShip)
                Exit Sub
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "cmdShip_Click"
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ｷｬﾘｱ手動出庫指示要求
            lblnAns = pubblnCarrManuOutPort_Ins(lstrCarrierID, _
                                                CMstrcarrmanuoutportVer, _
                                                cmbStockerName.Value, _
                                                pstrUserID)
            '@戻り値判定
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003G, lstrCarrierID, cmbStockerName.Text)
                
                '@pubVsfInfo_Disp(ﾒｯｾｰｼﾞｺｰﾄﾞ："<TRM3GI>$$キャリア[%1]のストッカー[%2]への出庫指示を受け付けました。")
                Call pubVsfInfo_Disp(pstrDMsg)

                '@最新情報取得
                Call cmdNowList_Click(cmdNowList, New EventArgs())
                
                '@ﾌｫｰｶｽｾｯﾄ
                If vsfCarrierList.Enabled = True Then
                    Call pubSetFocus(vsfCarrierList)
                End If
                
                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdShip_Click"          '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierForcedmove_Click
    '機　能：ｷｬﾘｱ強制交換
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 14:25:07 N.Kasai
    '更新日：2006/02/27 (Mon) 19:25:10 N.Kojima
    '備　考：
    '　　　：2006/02/27 (Mon) 19:25:10 N.Kojima     編集中のﾒｯｾｰｼﾞを表示する。(ﾕｰｻﾞｰ要望№0141)
    Private Sub cmdCarrierForcedmove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierForcedmove.Click

        Dim lblnAns                     As Boolean              '戻り値
        Dim lstrFormName                As String               'ﾌｫｰﾑ名
        Dim lstrEventName               As String               'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        Dim lstrCarrierID               As String               'ｷｬﾘｱID
        Dim ltypCarrierForcedmove       As CarrierForcedmove    'ｷｬﾘｱ強制交換
        Dim llngAns                     As Integer              '戻り値
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@編集中判定(編集ﾌﾗｸﾞから判断)
            If mblnEditFlag = True Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                
                '@"編集中です。 内容を破棄してよろしいですか？"
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                '@要求確認
                If llngAns = vbNo Then
                    '@確認済みﾌﾗｸﾞをFalseに初期化
                    mblnAnsFlag = False
                
                    '@ｷｬﾘｱ強制交換ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdCarrierForcedmove)
                    Exit Sub
                Else
                    '@確認済みﾌﾗｸﾞをTrueに(cmdNowList_Clickで2度表示されるのを防止)
                    mblnAnsFlag = True
                End If
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾃﾞｰﾀﾁｪｯｸ用
            With vsfCarrierList
                lstrCarrierID = .GetData(.Row, CMlngvsfCarrierListColCarrierID)                'ｷｬﾘｱID
            End With

            '@空の項目があれば中止
            '@ｷｬﾘｱIDﾁｪｯｸ
            If lstrCarrierID = vbNullString Then

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)

                '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが設定されていません。設定を見直してください。")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@ﾌｫｰｶｽの設定
                Call pubSetFocus(cmdCarrierForcedmove)
                Exit Sub
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "cmdCarrierForcedmove_Click"
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ｷｬﾘｱ強制交換応答格納
            With ltypCarrierForcedmove
                .strMsgVer = CMstrcarrforcedmoveVer
                .strCarrierId = lstrCarrierID
                .strEmpID = pstrUserID
            End With
            
            '@ｷｬﾘｱ強制交換
            lblnAns = pubblnCarrForcedmove_Upd(ltypCarrierForcedmove)
            
            '@戻り値判定
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@表示ﾒｯｾｰｼﾞ変換("<TRM06I>$$強制交換しました。交換元キャリア[%1]、交換先キャリア[%2]")
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0006, lstrCarrierID, ltypCarrierForcedmove.strToCarrierId)
                
                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)

                '@最新情報取得
                Call cmdNowList_Click(cmdNowList, New EventArgs())
                
                '@ﾌｫｰｶｽｾｯﾄ
                If vsfCarrierList.Enabled = True Then
                    Call pubSetFocus(vsfCarrierList)
                End If
                
                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "cmdCarrierForcedmove_Click"     '処理名
                .strErrMessage = ""                             'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCopy_Click
    '機　能：ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/18 (Fri) 12:06:43 N.Kasai
    '更新日：2005/11/18 (Fri) 12:06:43
    '備　考：EXCELに貼り付ける際に、ｾﾙの先頭の文字列が、「－」、「＋」の場合は、自動計算されるので、罫線文字におきかえる
    Private Sub cmdCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCopy.Click

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
            Clipboard.Clear()
            
            With vsfCarrierList
                '@一覧をｺﾋﾟｰする
                For llngRowCnt = 0 To .Rows.Count - 1
                    For llngColCnt = 0 To .Cols.Count - 1
                        '@列が非表示でない場合
                        If .Cols(llngColCnt).Visible Then
                        
                            '@文字列編集変数に値をｾｯﾄ
                            lstrWk = .GetData(llngRowCnt, llngColCnt)
                            
                            '@先頭の文字列が「-」「+」の場合は罫線文字に置き換える
                            If Mid$(lstrWk, 1, 1) = CPstrMinus Then
                                Mid$(lstrWk, 1, 1) = CPstrMinusWide
                            End If
                            If Mid$(lstrWk, 1, 1) = CPstrPlus Then
                                Mid$(lstrWk, 1, 1) = CPstrPlusWide
                            End If
                            
                            '@最終列の場合Tabいらない
                            If llngColCnt = .Cols.Count - 1 Then
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
                .strProcName = "cmdCopy_Click"              '処理名
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
    '作成日：2004/02/13 (Fri) 11:00:00 K.Takano
    '更新日：2006/02/28 (Tue) 14:06:18 N.Kojima
    '備　考：
    '　　　：2006/02/28 (Tue) 14:06:18 N.Kojima     編集中のﾒｯｾｰｼﾞ出力処理追加。(ﾕｰｻﾞｰ要望№0141)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim ltypCommonInfo          As CommonInfo       '引継ぎ情報構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@終了関数を実行する
            RemoveHandler cmbUseCategory.Validating, AddressOf cmbUseCategory_Validate
            RemoveHandler cmbStockerName.Validating, AddressOf cmbStockerName_Validate
            RemoveHandler txtCarrierID0.Validating, AddressOf txtCarrierID0_Validate
            RemoveHandler calUseStartDate.Validating, AddressOf calUseStartDate_Validate
            RemoveHandler calManuDate.Validating, AddressOf calManuDate_Validate
            RemoveHandler cmbSBID1.Validating, AddressOf cmbSBID1_Validate
            RemoveHandler cmbCarrType.Validating, AddressOf cmbCarrType_Validate
            RemoveHandler txtCarrierMnt2.Validating, AddressOf txtCarrierMnt2_Validate
            RemoveHandler txtCarrierID2.Validating, AddressOf txtCarrierID2_Validate
            RemoveHandler txtCarrierMnt.Validating, AddressOf txtCarrierMnt_Validate
            RemoveHandler txtCarrierComments.Validating, AddressOf txtCarrierComments_Validate
            Call publngEnd_Proc(CPstrKeyEN00G0, ltypCommonInfo)
            AddHandler cmbUseCategory.Validating, AddressOf cmbUseCategory_Validate
            AddHandler cmbStockerName.Validating, AddressOf cmbStockerName_Validate
            AddHandler txtCarrierID0.Validating, AddressOf txtCarrierID0_Validate
            AddHandler calUseStartDate.Validating, AddressOf calUseStartDate_Validate
            AddHandler calManuDate.Validating, AddressOf calManuDate_Validate
            AddHandler cmbSBID1.Validating, AddressOf cmbSBID1_Validate
            AddHandler cmbCarrType.Validating, AddressOf cmbCarrType_Validate
            AddHandler txtCarrierMnt2.Validating, AddressOf txtCarrierMnt2_Validate
            AddHandler txtCarrierID2.Validating, AddressOf txtCarrierID2_Validate
            AddHandler txtCarrierMnt.Validating, AddressOf txtCarrierMnt_Validate
            AddHandler txtCarrierComments.Validating, AddressOf txtCarrierComments_Validate
            
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

    '関数名：cmdCarrierClean_Click
    '機　能：ｷｬﾘｱ指定洗浄ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 21:18:25 N.Kasai
    '更新日：2006/02/27 (Mon) 10:38:32 N.Kojima
    '備　考：
    '　　　：2005/10/06 (Thu) 14:53:02 S.Deguchi    不具合№2995の対応で要求情報を構造体に変更
    '　　　：2006/02/27 (Mon) 10:38:32 N.Kojima     ｷｬﾘｱ一覧取得 要求に「ｶﾃｺﾞﾘID」追加。(ﾕｰｻﾞｰ要望№0141)
    Private Sub cmdCarrierClean_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierClean.Click
        
        Dim ltypCarrierList         As CarrList             'ｷｬﾘｱﾘｽﾄ取得結果格納
        Dim llngCarrierRow          As Integer              '該当ｷｬﾘｱ行
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim lstrFormName            As String               'ﾌｫｰﾑ名
        Dim lstrEventName           As String               'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        Dim lblnAns                 As Boolean              '汎用戻り値結果取得(True:正常,False:異常)
        Dim ltypCarrierListReq      As CarrierListReq       '要求構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@子画面をﾛｰﾄﾞ
            frmxxCM00C1.Instance = New frmxxCM00C1()
            
            '@子画面名称設定
            frmxxCM00C1.Instance.Text = CPstrSubFormCM00C1
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00C1.Instance = Nothing
                Exit Sub
            End If
            
            '@初期化
            pstrCarrierID = vbNullString
            
            '@ｷｬﾘｱ洗浄画面起動
            frmxxCM00C1.Instance.ShowDialog(Me)
            frmxxCM00C1.Instance = Nothing
            
            'NSYS サブ画面閉じた後、左上の項目にフォーカスをセット
            If tabCarrier.SelectedIndex = CMlngtabCarrier0 Then
                pubSetFocus(cmbSBID0)
            ElseIf tabCarrier.SelectedIndex = CMlngtabCarrier1 Then
                pubSetFocus(cmbSBID1)
            ElseIf tabCarrier.SelectedIndex = CMlngtabCarrier2 Then
                pubSetFocus(txtCarrierID2)
            End If
            
            '@引継ぎｷｬﾘｱIDの有無を判定
            If pstrCarrierID = vbNullString Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱﾒﾝﾃﾅﾝｽ一覧ﾀﾌﾞ表示の場合
            If tabCarrier.SelectedIndex = CMlngtabCarrier1 Then
                '@一覧画面が表示されている。
                If vsfCarrierList.Enabled = True Then
                    '@初期化
                    llngCarrierRow = 0
                
                    '@該当ｷｬﾘｱIDを検索
                    With vsfCarrierList
                        For llngCnt = 1 To .Rows.Count - 1
                            '@一覧の内容と該当ｷｬﾘｱIDを比較して行番号を取得する。
                            If .GetData(llngCnt, CMlngvsfCarrierListColCarrierID) = pstrCarrierID Then
                                llngCarrierRow = llngCnt
                                Exit For
                            End If
                        Next llngCnt
                    End With

                    '@検索結果判定
                    If llngCarrierRow = 0 Then
                        Exit Sub
                    End If
                    
                    '@最新情報の表示
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    lstrFormName = frmxxCM00C1.Instance.Name
                    lstrEventName = "cmdCarrierClean_Click"
                    Call pubResponseStart(lstrFormName, lstrEventName)

                    '@ｷｬﾘｱ一覧取得 要求構造体へ情報を格納
                    With ltypCarrierListReq
                        .strMsgVer = CMstrcarrlist____Ver                       'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                        .strSbID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strClassDivision = CPstrCD0K                           '処理区分：0K ｷｬﾘｱ指定
                        .strRestrictedSBID = vbNullString                       'ｷｬﾘｱ使用可能ｼｽﾃﾑﾌﾞﾛｯｸID
                        .strCarrierTypeID = vbNullString                        'ｷｬﾘｱﾀｲﾌﾟ
                        .strCarrierId = pstrCarrierID                           'ｷｬﾘｱID(ｷｬﾘｱID指定時設定)
                        .strCleanCondition = vbNullString                       '洗浄条件
                        .strCategoryID = cmbUseCategory.Value                   'ｶﾃｺﾞﾘID
                    End With
                    
                    '@ｷｬﾘｱ一覧取得
                    lblnAns = pubblnCarrList_Sel(ltypCarrierListReq, ltypCarrierList)
                    
                    '@取得結果確認
                    If lblnAns = True Then
                        '@ﾘｽﾄｶｳﾝﾄを判定
                        If ltypCarrierList.lngCarrierListCnt > 0 Then
                            '@件数ありの場合画面表示
                            Call prvCarrierClean_Disp(ltypCarrierList, llngCarrierRow)
                        End If
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(lstrFormName, lstrEventName)
                    Else
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        Exit Sub
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierClean_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：tabCarrier_Click
    '機　能：ﾀﾌﾞ切り替え処理
    '引　数：PreviousTab：ﾀﾌﾞｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 17:48:50 N.Kojima
    '更新日：2006/02/23 (Thu) 11:03:12 N.Kojima
    '備　考：ｷｬﾘｱ登録、ｷｬﾘｱ一覧、ｷｬﾘｱﾒﾝﾃﾅﾝｽﾀﾌﾞを切り替える
    '　　　：2005/01/08 (Sat) 18:13:54 N.Kasai      在庫管理より連動した場合のｷｬﾘｱ一覧を初期表示
    '　　　：2006/02/23 (Thu) 11:03:12 N.Kojima     使用ｶﾃｺﾞﾘﾘｽﾄ取得処理追加。(ﾕｰｻﾞｰ要望№0141)
    Private Sub tabCarrier_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tabCarrier.SelectedIndexChanged
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With tabCarrier
                Select Case .SelectedIndex
                    '@ｷｬﾘｱ登録ﾀﾌﾞ
                    Case CMlngtabCarrier0
                        '@有効ﾀﾌﾞ制御
                        fraCarrier0.Enabled = True
                        fraCarrier1.Enabled = False
                        fraCarrier2.Enabled = False
                        '@ﾌｫｰﾑが表示されてる場合
                        If Me.Visible = True Then
                            '@利用SBにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbSBID0)
                        End If
                    
                    '@ｷｬﾘｱ一覧ﾀﾌﾞ
                    Case CMlngtabCarrier1
                        '@有効ﾀﾌﾞ制御
                        fraCarrier0.Enabled = False
                        fraCarrier1.Enabled = True
                        fraCarrier2.Enabled = False
                        
                        If vsfCarrierList.Enabled = False Then

                            cmdNowList.Enabled = False
                            
                            '最新取得ﾎﾞﾀﾝを有効に
                            cmdNowList.Enabled = True

                            '@SBが"1A0"か
                            If pstrSBID = CPstrSBID1A0 Then
                                '@ｽﾄｯｶｰ情報ｾｯﾄ
                                Call prvcmbStockerName_Disp()
                            End If
                            
                            '@使用ｶﾃｺﾞﾘ情報ｾｯﾄ
                            Call prvcmbUseCategory_Disp()
                            
                            '@初回のみ取得
                            Call cmdNowList_Click(cmdNowList, New EventArgs())

                            '@利用SB変更ﾌﾗｸﾞ初期化
                            mblncmbSBID1CngFlg = False
                        Else
                            '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfCarrierList)
                        End If
                        
                    '@ｷｬﾘｱﾒﾝﾃﾅﾝｽﾀﾌﾞ
                    Case CMlngtabCarrier2
                        '@利用SB変更ﾌﾗｸﾞ初期化
                        mblncmbSBID1CngFlg = False

                        '@有効ﾀﾌﾞ制御
                        fraCarrier0.Enabled = False
                        fraCarrier1.Enabled = False
                        fraCarrier2.Enabled = True
                        
                        '@ｷｬﾘｱﾒﾝﾃのﾀﾌﾞ制御
                        Call tabCarrierMnt_Click(tabCarrierMnt, New EventArgs())
                End Select
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "tabCarrier_Click"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '====================================ｷｬﾘｱ登録Tab====================================
    '関数名：cmbSBID0_CloseUp
    '機　能：利用SB選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 18:47:17 N.Kojima
    '更新日：2005/01/12 (Wed) 09:04:02 N.Kasai
    '備　考：ｷｬﾘｱ登録Tab
    '　　　：2005/01/12 (Wed) 09:04:02 N.Kasai  画面起動時に取得する為ｺﾒﾝﾄｱｳﾄ
    Private Sub cmbSBID0_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSBID0.CloseUp
        
        Try
            
            '@cmbSBID0のValidateｲﾍﾞﾝﾄ呼び出す
            If cmbSBID0.Text <> vbNullString Then
                '@ｷｬﾘｱID(ｷｬﾘｱ登録Tab)にﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrierID0)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbSBID0_CloseUp"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtCarrierID0_Change
    '機　能：ｷｬﾘｱIDの変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/08 (Thu) 10:23:25 N.Kasai
    '更新日：2004/04/08 (Thu) 10:23:25
    '備　考：ｷｬﾘｱ登録Tab
    Private Sub txtCarrierID0_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID0.Change

        Try
                             
            '@ｷｬﾘｱIDが6桁の場合
            If txtCarrierID0.NowByte = txtCarrierID0.ChrMaxByte Then
                '@入力ﾁｪｯｸ
                Call prvInput_Chk()
            
                '@登録済みｷｬﾘｱID退避
                mstrCarrierID0 = txtCarrierID0.Text
            Else
	            '@確定、削除ﾎﾞﾀﾝﾛｯｸ
	            Call prvCmd_Set(False)
                '@登録済みｷｬﾘｱID退避変数初期化
                mstrCarrierID0 = vbNullString
                '@ｷｬﾘｱID登録済みﾌﾗｸﾞ初期化
                mblnCarrierID0Flg = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierID0_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID0_Validate
    '機　能：ｷｬﾘｱID項目入力ﾁｪｯｸ
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/08 (Thu) 09:38:43 M.Miura
    '更新日：2004/08/10 (Tue) 10:33:59 Y.Yamagishi
    '備　考：ｷｬﾘｱ登録Tab
    Private Sub txtCarrierID0_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierID0.Validating
        
        Dim lblnAns                 As Boolean                  'ｷｬﾘｱ情報設定戻り値(True:正常,False:異常)

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDがない場合は抜ける
            If txtCarrierID0.Text = vbNullString Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrierID0.NowByte <> txtCarrierID0.ChrMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@再入力
                If Me.ActiveControl.Name = tabCarrier.Name Then
                    mblnTabSelectEnabled = False
                    sender.Focus()
                Else
	                e.Cancel = True
                End If
                Exit Sub
            End If
                
            '@入力したｷｬﾘｱIDの有効性ﾁｪｯｸ
            lblnAns = prvblnMasterCarrier_Set()
            '@結果判定
            If lblnAns = False Then
                '@再入力
                If Me.ActiveControl.Name = tabCarrier.Name Then
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
                .strProcName = "txtCarrierID0_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calUseStartDate_CalendarSelect
    '機　能：利用開始日選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/13 (Thu) 11:37:25 M.Miura
    '更新日：2004/10/01 (Fri) 11:57:42 M.Miura
    '備　考：ｷｬﾘｱ登録Tab
    '　　　：2004/10/01 (Fri) 11:57:42 M.Miura　    空の場合はﾌｫｰｶｽを留める処理を追加
    Private Sub calUseStartDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calUseStartDate.CalendarSelect

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@日付が空の場合はﾌｫｰｶｽを留める
            If calUseStartDate.Value = CPstrNullDate Then
                Exit Sub
            End If
            
            '@Validate処理へ
            RemoveHandler calUseStartDate.Validating, AddressOf calUseStartDate_Validate
            Call calUseStartDate_Validate(calUseStartDate, New CancelEventArgs(True))
            AddHandler calUseStartDate.Validating, AddressOf calUseStartDate_Validate
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calUseStartDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calUseStartDate_Change
    '機　能：利用開始日変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 17:41:56 M.Miura
    '更新日：2004/06/01 (Tue) 17:41:56
    '備　考：ｷｬﾘｱ登録Tab
    Private Sub calUseStartDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calUseStartDate.Change

        Try

            '@入力ﾁｪｯｸ
            Call prvInput_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calUseStartDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calUseStartDate_Validate
    '機　能：利用開始日処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/18 (Tue) 10:53:43 Y.Yamagishi
    '更新日：2004/09/20 (Mon) 17:17:27 N.Kasai
    '備　考：ｷｬﾘｱ登録Tab
    '　　　：2004/09/02 (Thu) 17:34:54 M.Miura　    ｴﾗｰ時のﾌｫｰｶｽ制御を追加(不具合改善№164)
    '　　　：2004/09/20 (Mon) 17:17:27 N.Kasai　    利用開始日は過去日付不可
    Private Sub calUseStartDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calUseStartDate.Validating

        Dim lstrNowDT As String     '現在日時の退避

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If

            '@日付が入力されていない(空欄)場合
            If calUseStartDate.Value <> CPstrNullDate Then
                '@日付の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(calUseStartDate.Value) = False Then
                    If Me.ActiveControl.Name <> tabCarrier.Name Then
                        sender.Focus()
                    End If
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@登録、削除ﾎﾞﾀﾝ無効
                    Call prvCmd_Set(False)

                    '@利用開始日にｾｯﾄﾌｫｰｶｽ
                    If Me.ActiveControl.Name = tabCarrier.Name Then
                        mblnTabSelectEnabled = False
                        sender.Focus()
                    Else
	                    e.Cancel = True
                    End If
                    Exit Sub
                Else
                    '@過去日付のﾁｪｯｸ
                    '@現在日付取得
                    lstrNowDT = (Date.Now()).ToString(CPstrDateTimeYMD)
                    If Format$(CDate(calUseStartDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                        If Me.ActiveControl.Name <> tabCarrier.Name Then
                            sender.Focus()
                        End If
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                        '@"過去日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        '@ﾌｫｰｶｽを移さない
                        If Me.ActiveControl.Name = tabCarrier.Name Then
                            mblnTabSelectEnabled = False
                            sender.Focus()
                        Else
	                        e.Cancel = True
                        End If
                        Exit Sub
                    End If
                
                    '@日付が入力されていない(空欄)場合
                    If calManuDate.Value <> CPstrNullDate Then
                        '@日付の有効性ﾁｪｯｸ
                        If pubblnYearRange_Chk(calManuDate.Value) = True Then
                            '@ｷｬﾘｱID入力欄が空欄か否か
                            If txtCarrierID0.Text = vbNullString Then
                                '@登録、削除ﾎﾞﾀﾝ無効
                                Call prvCmd_Set(False)
                            Else
                                '@登録、削除ﾎﾞﾀﾝ有効
                                Call prvCmd_Set(True)
                            End If
                        Else
                            If Me.ActiveControl.Name <> tabCarrier.Name Then
                                sender.Focus()
                            End If
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                            '@"正しい日付を入力してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            '@登録、削除ﾎﾞﾀﾝ無効
                            Call prvCmd_Set(False)
                            '@利用開始日にｾｯﾄﾌｫｰｶｽ
                            If Me.ActiveControl.Name = tabCarrier.Name Then
                                mblnTabSelectEnabled = False
                                sender.Focus()
                            Else
	                            e.Cancel = True
                            End If
                            Exit Sub
                        End If
                    Else
                        '@登録、削除ﾎﾞﾀﾝ無効
                        Call prvCmd_Set(False)
                    End If
                End If
            Else
                '@登録、削除ﾎﾞﾀﾝ無効
                Call prvCmd_Set(False)
            End If

            '@製造年月日にｾｯﾄﾌｫｰｶｽ
            If ActiveControl.Name = calUseStartDate.Name Then
	            Call pubSetFocus(calManuDate)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "calUseStartDate_Validate"   '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：calManuDate_CalendarSelect
    '機　能：製造年月日選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/13 (Thu) 11:39:07 M.Miura
    '更新日：2004/05/28 (Fri) 11:14:01 S.Deguchi
    '備　考：ｷｬﾘｱ登録Tab
    Private Sub calManuDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calManuDate.CalendarSelect

        Try

            '@日付が空の場合はﾌｫｰｶｽを留める
            If calManuDate.Value = CPstrNullDate Then
                Exit Sub
            End If
            
            '@入力ﾁｪｯｸ
            Call prvInput_Chk()
            
            '@Validate処理へ
            RemoveHandler calManuDate.Validating, AddressOf calManuDate_Validate
            Call calManuDate_Validate(calManuDate, New CancelEventArgs(True))
            AddHandler calManuDate.Validating, AddressOf calManuDate_Validate
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calManuDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calManuDate_Change
    '機　能：製造年月日変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 17:46:59 M.Miura
    '更新日：2004/06/01 (Tue) 17:46:59
    '備　考：ｷｬﾘｱ登録Tab
    Private Sub calManuDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calManuDate.Change

        Try

            '@入力ﾁｪｯｸ
            Call prvInput_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calManuDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calManuDate_Validate
    '機　能：製造年月日処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/18 (Tue) 11:31:22 Y.Yamagishi
    '更新日：2004/10/19 (Tue) 16:40:08 N.Kojima
    '備　考：ｷｬﾘｱ登録Tab
    '　　　：2004/09/02 (Thu) 17:36:43 M.Miura　    ｴﾗｰ時のﾌｫｰｶｽ制御を追加(不具合改善№164)
    '　　　：2004/09/20 (Mon) 16:58:07 N.Kasai　    製造年月日は未来日付は入力不可追加
    '　　　：                                       ｷｬﾘｱ管理の製造年月日は過去日付は入力可
    '　　　：                                       ｷｬﾘｱ管理の製造年月日は未来日付は入力不可
    '　　　：2004/10/19 (Tue) 16:40:08 N.Kojima     Tab、Enterでｷｬﾘｱ削除ﾎﾞﾀﾝにﾌｫｰｶｽが移らないようにする。(不具合№113)
    Private Sub calManuDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calManuDate.Validating
        
        Dim lstrNowDT    As String     '現在日時の退避
        Dim lblnNextCtrl As Boolean    'NSYS Focus設定フラグ
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If
            
            ' NSYS フォーカス設定可能か判定
            If Me.ActiveControl.Name = cmdRegist.Name Then
                ' 次コントロールがアクティブの場合
                lblnNextCtrl = True
            Else
                ' 次コントロール以外がアクティブの場合
                lblnNextCtrl = False
            End If

            '@日付が入力されていない(空欄)場合
            If calManuDate.Value <> CPstrNullDate Then
                '@日付の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(calManuDate.Value) = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@登録、削除ﾎﾞﾀﾝ無効
                    Call prvCmd_Set(False)

                    '@製造年月日にｾｯﾄﾌｫｰｶｽ
                    If Me.ActiveControl.Name = tabCarrier.Name Then
                        mblnTabSelectEnabled = False
                        sender.Focus()
                    Else
	                    e.Cancel = True
                    End If
                    
                    Exit Sub
                Else
                    '@未来日付のﾁｪｯｸ
                    '@現在日付取得
                    lstrNowDT = (Date.Now()).ToString(CPstrDateTimeYMD)
                    '@未来日付の場合
                    If Format$(CDate(calManuDate.Value), CPstrDateTimeYMD) > lstrNowDT Then
                       '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                        '@"未来日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        '@製造年月日にｾｯﾄﾌｫｰｶｽ
                        If Me.ActiveControl.Name = tabCarrier.Name Then
                            mblnTabSelectEnabled = False
                            sender.Focus()
                        Else
	                        e.Cancel = True
                        End If
                        Exit Sub
                    End If
                
                    '@利用開始日付が入力されていない(空欄)場合
                    If calUseStartDate.Value <> CPstrNullDate Then
                        '@日付の有効性ﾁｪｯｸ
                        If pubblnYearRange_Chk(calUseStartDate.Value) = True Then
                            '@ｷｬﾘｱID入力欄が空欄か否か
                            If txtCarrierID0.Text = vbNullString Then
                                '@登録、削除ﾎﾞﾀﾝ無効
                                Call prvCmd_Set(False)
                            Else
                                '@登録、削除ﾎﾞﾀﾝ有効
                                Call prvCmd_Set(True)
                            End If
                        Else
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                            '@"正しい日付を入力してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            '@登録、削除ﾎﾞﾀﾝ無効
                            Call prvCmd_Set(False)
                            '@製造年月日にｾｯﾄﾌｫｰｶｽ
                            If Me.ActiveControl.Name = tabCarrier.Name Then
                                mblnTabSelectEnabled = False
                                sender.Focus()
                            Else
	                            e.Cancel = True
                            End If
                            
                            Exit Sub
                        End If
                    Else
                        '@登録、削除ﾎﾞﾀﾝ無効
                        Call prvCmd_Set(False)
                    End If
                End If
            Else
                '@登録、削除ﾎﾞﾀﾝ無効
                Call prvCmd_Set(False)
            End If

            '@次項目へｾｯﾄﾌｫｰｶｽ
            If cmdRegist.Enabled = True Then
                '@ｷｬﾘｱ登録ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                If lblnNextCtrl OrElse e.Cancel = True Then
                	Call pubSetFocus(cmdRegist)
                End If
            Else
                '@ﾀﾌﾞにﾌｫｰｶｽｾｯﾄ
                If lblnNextCtrl OrElse e.Cancel = True Then
                	Call pubSetFocus(tabCarrier)
                End If
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "calManuDate_Validate"   '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：ｷｬﾘｱの新規登録実行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/13 (Fri) 16:30:00 K.Takano
    '更新日：2004/05/20 (Thu) 16:32:31 S.Deguchi
    '備　考：ｷｬﾘｱ登録Tab
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAnsCarrierAdd       As Boolean          '登録ｷｬﾘｱ
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
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@構造体に登録内容格納
            With mtypCarrierAdd
                .strSbID = cmbSBID0.Value                   '利用SB
                .strCarrierId = txtCarrierID0.Text          'ｷｬﾘｱID
                .strStartTime = calUseStartDate.Value       '利用開始日
                .strProductionDate = calManuDate.Value      '製造年月日
            End With
            
            '@ﾃﾞｰﾀﾁｪｯｸ
            With mtypCarrierAdd
            '@空の項目があれば中止
                '@ｷｬﾘｱIDﾁｪｯｸ
                If .strCarrierId = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                    
                    '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが設定されていません。設定を見直してください。")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽの設定
                    Call pubSetFocus(txtCarrierID0)
                    
                    Exit Sub
                End If
                
                '@利用開始日ﾁｪｯｸ
                If .strStartTime = CPstrNullDate Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0002)
                    
                    '@失敗ﾒｯｾｰｼﾞ表示("利用開始日が設定されていません。設定を見直してください。")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                    '@ﾌｫｰｶｽ設定
                    Call pubSetFocus(calUseStartDate)
                    
                    Exit Sub
                End If
                
                '@製造年月日ﾁｪｯｸ
                If .strProductionDate = CPstrNullDate Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0003)
                    
                    '@失敗ﾒｯｾｰｼﾞ表示("製造年月日が設定されていません。設定を見直してください。")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ﾌｫｰｶｽ設定
                    Call pubSetFocus(calManuDate)
                    
                    Exit Sub
                End If
                
                If .strProductionDate > .strStartTime Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0004)
                    
                    '@失敗ﾒｯｾｰｼﾞ表示("利用開始日と製造年月日の関係が間違っています。設定を見直してください。")
                      Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽの設定
                    Call pubSetFocus(calUseStartDate)
                    
                    Exit Sub
                End If
                
                If .strCarrierTypeID = vbNullString Or _
                   .strVenderId = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0005)
                    
                   '@失敗ﾒｯｾｰｼﾞ表示("ベンダーロットIDが正しく取得出来ませんでした。システム担当者に連絡して下さい。")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽの設定
                    Call pubSetFocus(txtCarrierID0)
                    
                    Exit Sub
                End If
            End With
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "cmdRegist_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@作業者ID構造体に格納
            mtypCarrierAdd.strEmpID = pstrUserID
            
            '@新規登録実行
            lblnAnsCarrierAdd = pubblnCarrierID_Ins(CMstrcarradditionVer, mtypCarrierAdd)
            
            '@結果判定
            If lblnAnsCarrierAdd = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0001, txtCarrierID0.Text)
                
                '@pubVsfInfo_Disp("ﾒｯｾｰｼﾞｺｰﾄﾞ：C_I01%0$$キャリア[ %1 ]を登録しました。")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@画面の初期化
                Call prvCarrierTab0_Init(False)
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                '@利用SBにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbSBID0)
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(lstrFormName, lstrEventName)
            
            '@ｷｬﾘｱIDにﾌｫｰｶｽ移動
            Call pubSetFocus(txtCarrierID0)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdRegist_Click"        '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdDel_Click
    '機　能：ｷｬﾘｱの削除(無効化)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/13 (Fri) 17:00:00 K.Takano
    '更新日：2006/03/08 (Wed) 14:44:24 N.Kojima
    '備　考：ｷｬﾘｱ登録Tab
    '　　　：2004/10/19 (Tue) 16:47:59 N.Kojima     ｷｬﾝｾﾙ時にﾌｫｰｶｽを留める処理追加。(不具合№113)
    '　　　：2006/03/08 (Wed) 14:44:24 N.Kojima     確認ﾒｯｾｰｼﾞ表示処理を追加。(運用障害№720)
    Private Sub cmdDel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDel.Click

        Dim lstrDelCarrierID        As String   '削除ｷｬﾘｱID
        Dim lblnDelCarrier          As Boolean  '削除ｷｬﾘｱ
        Dim lstrEventName           As String   'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        Dim lstrFormName            As String   'ﾌｫｰﾑ名
        Dim llngAns                 As Integer  'ﾎﾟｯﾌﾟｱｯﾌﾟﾒｯｾｰｼﾞ戻り値格納用
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "cmdDel_Click"
            
            '@削除ｷｬﾘｱIDを変数に格納
            lstrDelCarrierID = txtCarrierID0.Text    'ｷｬﾘｱID
            
            '@ﾃﾞｰﾀﾁｪｯｸ(ｷｬﾘｱIDが空なら中止)
            If lstrDelCarrierID = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0006)
                
                '@失敗ﾒｯｾｰｼﾞ表示("削除するｷｬﾘｱIDが入力されていません。ｷｬﾘｱIDを入力してください。")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Exit Sub
            End If
            
            '@削除の確認を行なう
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007P, lstrDelCarrierID)
            
            '@"<TRM7PW>$$キャリア[%1]を削除します。よろしいですか？"
            llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
            '@要求確認
            If llngAns = vbNo Then
                '@削除ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdDel)
                Exit Sub
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Call pubSetFocus(cmdDel)
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmdDel_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ｷｬﾘｱ削除実行
            lblnDelCarrier = pubblnCarrierID_Del(CMstrcarrdelete__Ver, lstrDelCarrierID, pstrUserID)
            
            '@結果判定
            If lblnDelCarrier = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0002, lstrDelCarrierID)
                
                '@pubVsfInfo_Disp("ﾒｯｾｰｼﾞｺｰﾄﾞ：C_I02%0$$キャリア[ %1 ]を削除しました。")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@画面の初期化
                Call prvCarrierTab0_Init(False)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)
                
                '@利用SBにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbSBID0)
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(Me.Name, lstrEventName)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdDel_Click"           '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '====================================ｷｬﾘｱ一覧Tab====================================
    '関数名：cmbSBID1_Change
    '機　能：利用SB変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 20:40:36 N.Kojima
    '更新日：2006/05/10 (Wed) 16:27:16 M.Miura
    '備　考：ｷｬﾘｱ一覧Tab
    '　　　：2004/10/14 (Thu) 15:47:31 M.Miura　    ｶﾚﾝﾄ行検索ｷｰを初期化
    '　　　：2005/01/11 (Tue) 09:12:05 N.Kasai      ｽﾄｯｶｺﾝﾎﾞ初期化を追加
    '　　　：2005/03/25 (Fri) 10:38:05 N.Kasai      ｸﾞﾘｯﾄﾞ初期化見直し
    '　　　：2005/11/18 (Fri) 13:06:41 N.Kasai      ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ追加
    '　　　：2006/02/23 (Thu) 09:59:51 N.Kojima     使用ｶﾃｺﾞﾘｺﾝﾎﾞを初期化処理等を追加。(ﾕｰｻﾞｰ要望№0141対応)
    '　　　：2006/05/10 (Wed) 16:27:16 M.Miura      運用障害№758、不具合№3463対応 (編集中に利用SBを変更した場合にﾀﾞｲｱﾛｸﾞ表示)
    Private Sub cmbSBID1_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSBID1.Change
        Dim llngAns As Integer '戻り値退避　←2006/05/10 (Wed) 15:57:14 M.Miura 運用障害№758、不具合№3463対応
        
        Try
            
            With cmbSBID1
                '@編集中の場合
                If mblnEditFlag = True Then
                    '@利用SBが変更された場合(破棄しますか？が2回表示しない為の判定)
                    If .ListIndex <> mlngSBIdx Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                        
                        '@"編集中です。 内容を破棄してよろしいですか？"
                        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                        '@要求確認
                        If llngAns = vbNo Then
                            '@「いいえ」選択の場合は利用SBを変更前に戻す
                            .ListIndex = mlngSBIdx
                            Exit Sub
                        End If
                    Else
                        '@利用SBが変更されなかった場合は抜ける
                        Exit Sub
                    End If
                End If
                
                '@利用SBｺﾝﾎﾞIndex退避
                mlngSBIdx = .ListIndex
            End With
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString

            '@編集中ﾌﾗｸﾞを初期化
            mblnEditFlag = False
            '@ｺﾒﾝﾄﾃｷｽﾄを初期化
            txtCarrierComments.Text = vbNullString
            '@ｺﾒﾝﾄﾌｨｰﾙﾄﾞを無効にする
            txtCarrierComments.Enabled = False

            '@ｷｬﾘｱ一覧の初期化
            With vsfCarrierList
                .Redraw = False
                .Rows.Count = .Rows.Fixed
                .Redraw = True
                .Enabled = False
            End With
            
            '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ使用不可
            cmdCopy.Enabled = False
            
            mblncmbSBID1CngFlg = True
            
            '@ｷｬﾘｱﾀｲﾌﾟｺﾝﾎﾞを初期表示
            cmbCarrType.ListIndex = CMlngNoSelect

            '@ｽﾄｯｶｰｺﾝﾎﾞを初期化
            cmbStockerName.ListIndex = CMlngNoSelect
            cmbStockerName.Enabled = False

            '@使用ｶﾃｺﾞﾘｺﾝﾎﾞを初期化
            cmbUseCategory.ListIndex = CMlngNoSelect

            '@ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString           '情報取得日時
            lblCarrierCnt.Text = vbNullString        '該当件数
            
            '@ｷｬﾘｱﾀｲﾌﾟが入力済み、最新取得ﾎﾞﾀﾝが無効の時
            If cmbCarrType.Text <> vbNullString And cmdNowList.Enabled = False Then
                '@最新取得ﾎﾞﾀﾝ有効
                cmdNowList.Enabled = True
            Else
                '@最新取得ﾎﾞﾀﾝ無効
                cmdNowList.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSBID1_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSBID1_CloseUp
    '機　能：利用SB選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 18:47:17 N.Kojima
    '更新日：2004/07/05 (Mon) 18:47:17
    '備　考：ｷｬﾘｱ一覧Tab
    Private Sub cmbSBID1_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSBID1.CloseUp
        
        Try
            
            '@cmbSBID1のValidateｲﾍﾞﾝﾄ呼び出す
            If cmbSBID1.Text <> vbNullString Then
                
                '@Validate処理へ
                RemoveHandler cmbSBID1.Validating, AddressOf cmbSBID1_Validate 
                Call cmbSBID1_Validate(cmbSBID1, New CancelEventArgs(True))
                AddHandler cmbSBID1.Validating, AddressOf cmbSBID1_Validate 
                
                '@ｷｬﾘｱﾀｲﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbCarrType)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbSBID1_CloseUp"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbSBID1_Validate
    '機　能：利用区分SB変更処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/12/13 (Mon) 09:48:44 N.Kasai
    '更新日：2006/02/28 (Tue) 12:57:17 N.Kojima
    '備　考：
    '　　　：2006/02/28 (Tue) 12:57:17 N.Kojima     使用ｶﾃｺﾞﾘ情報取得処理追加。(ﾕｰｻﾞｰ要望№0141)
    Private Sub cmbSBID1_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbSBID1.Validating

        Dim lstrEventName           As String           'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim lblnAns                 As Boolean          '汎用戻り値

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If
            
            '@利用区分変更有無判定
            If mblncmbSBID1CngFlg = False Then
                '@変更なしの場合は以下の処理なし
                Exit Sub
            End If
            
            '@利用SB変更ﾌﾗｸﾞの初期化
            mblncmbSBID1CngFlg = False
            
            '@使用ｶﾃｺﾞﾘ情報ｾｯﾄ
            Call prvcmbUseCategory_Disp()
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "cmbSBID1_Validate"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ｷｬﾘｱﾀｲﾌﾟ一覧取得結果(処理区分：38ｷｬﾘｱﾀｲﾌﾟ)
            lblnAns = pubblnCarrMasList_Sel(CMstrcarrmaslist_Ver, _
                                            CPstrCD38, _
                                            mlngCarrTypListCnt, _
                                            mtypCarrierMaster, _
                                            cmbSBID1.Value)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            Else
                '@ｷｬﾘｱﾀｲﾌﾟ一覧情報ｾｯﾄ
                Call prvcmbCarrTyp_Disp(mlngCarrTypListCnt, mtypCarrierMaster)
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSBID1_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbCarrType_Change
    '機　能：ｷｬﾘｱﾀｲﾌﾟ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 20:40:36 N.Kojima
    '更新日：2006/05/10 (Wed) 16:27:16 M.Miura
    '備　考：ｷｬﾘｱ一覧Tab
    '　　　：2004/10/14 (Thu) 15:46:28 M.Miura　    ｶﾚﾝﾄ行検索ｷｰ初期化を追加
    '　　　：2005/03/23 (Wed) 10:33:01 N.Kasai      ｶﾚﾝﾄ行検索ｷｰ初期化を修正
    '　　　：2005/03/25 (Fri) 10:47:36 N.Kasai      ｸﾞﾘｯﾄﾞ初期化見直し
    '　　　：2006/02/28 (Tue) 13:52:04 N.Kojima     編集中ﾌﾗｸﾞの初期化等を追加。(ﾕｰｻﾞｰ要望№0141)
    '　　　：2006/05/10 (Wed) 16:27:16 M.Miura      運用障害№758、不具合№3463対応 (編集中にﾍｯﾀﾞのｷｬﾘｱﾀｲﾌﾟを変更した場合にﾀﾞｲｱﾛｸﾞ表示)
    Private Sub cmbCarrType_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCarrType.Change

        Dim llngAns As Integer '戻り値退避
        
        Try
            
            With cmbCarrType
                '@編集中の場合
                If mblnEditFlag = True Then
                    '@ｷｬﾘｱﾀｲﾌﾟが変更された場合(破棄しますか？が2回表示しない為の判定)
                    If .ListIndex <> mlngCarrTypeIdx Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                        
                        '@"編集中です。 内容を破棄してよろしいですか？"
                        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                        '@要求確認
                        If llngAns = vbNo Then
                            '@「いいえ」選択の場合はｷｬﾘｱﾀｲﾌﾟを変更前に戻す
                            .ListIndex = mlngCarrTypeIdx
                            Exit Sub
                        End If
                    Else
                        '@ｷｬﾘｱﾀｲﾌﾟが変更されなかった場合は抜ける
                        Exit Sub
                    End If
                End If
                
                '@ｷｬﾘｱﾀｲﾌﾟｺﾝﾎﾞIndex退避
                mlngCarrTypeIdx = .ListIndex
            End With

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If IsNothing(.typChgSortList) Then
                    .typChgSortList = New List(Of ChgSortList)()
                Else
                    .typChgSortList.Clear()
                End If
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
          
            '@編集中ﾌﾗｸﾞを初期化
            mblnEditFlag = False
            '@ｺﾒﾝﾄﾃｷｽﾄを初期化
            txtCarrierComments.Text = vbNullString
            '@ｺﾒﾝﾄﾌｨｰﾙﾄﾞを無効にする
            txtCarrierComments.Enabled = False
          
            '@ｷｬﾘｱ一覧の初期化
            With vsfCarrierList
                .Redraw = False
                .Rows.Count = .Rows.Fixed
                .Redraw = True
                .Enabled = False
            End With
            
            '@ｷｬﾘｱﾀｲﾌﾟが入力済み、最新取得ﾎﾞﾀﾝが無効の時
            If cmbCarrType.Text <> vbNullString And cmdNowList.Enabled = False Then
                '@最新取得ﾎﾞﾀﾝ有効
                cmdNowList.Enabled = True
            End If
            
            '@ｷｬﾘｱﾀｲﾌﾟID初期化
            mstrCarrType = vbNullString
            cmdNowList.CausesValidation = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbCarrType_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbCarrType_CloseUp
    '機　能：ｷｬﾘｱﾀｲﾌﾟ一覧処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 20:34:11 N.Kojima
    '更新日：2006/02/23 (Thu) 10:05:24 N.Kojima
    '備　考：ｷｬﾘｱ一覧Tab
    '　　　：2004/11/29 (Mon) 13:46:19 N.Kojima　   出庫指示機能追加に伴い、ｽﾄｯｶｰｺﾝﾎﾞの有効無効処理追加
    '　　　：2006/02/23 (Thu) 10:05:24 N.Kojima     使用ｶﾃｺﾞﾘｺﾝﾎﾞ追加に伴なう修正。(ﾕｰｻﾞｰ要望№0141)
    Private Sub cmbCarrType_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCarrType.CloseUp
        
        Try
            
            '@SBが"1A0"か
            If pstrSBID = CPstrSBID1A0 Then
                '@ｷｬﾘｱﾀｲﾌﾟが表示されている場合
                If cmbCarrType.Text <> vbNullString Then
                    '@処理区分の設定
                    Select Case cmbCarrType.Value
                        '@SMIF
                        Case CPstrCarrTypeSMIF
                            '@ｽﾄｯｶｰｺﾝﾎﾞをﾛｯｸ解除
                            cmbStockerName.Enabled = True
                        '@FOUP
                        Case CPstrCarrTypeFOUP
                            '@ｽﾄｯｶｰｺﾝﾎﾞをﾛｯｸ解除
                            cmbStockerName.Enabled = True
                        '@その他
                        Case Else
                            '@ｽﾄｯｶｰｺﾝﾎﾞをﾛｯｸ
                            cmbStockerName.Enabled = False
                    End Select
                End If
            End If
            
            '@Validate処理を呼ぶ
            RemoveHandler cmbCarrType.Validating, AddressOf cmbCarrType_Validate
            Call cmbCarrType_Validate(cmbCarrType, New CancelEventArgs(True))
            AddHandler cmbCarrType.Validating, AddressOf cmbCarrType_Validate

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbCarrType_CloseUp"    '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbCarrType_Validate
    '機　能：ｷｬﾘｱﾀｲﾌﾟValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：
    '作成日：2004/09/10 (Fri) 13:40:50 Y.Yamagishi
    '更新日：2006/02/23 (Thu) 10:02:34 N.Kojima
    '備　考：
    '　　　：2004/11/29 (Mon) 18:01:31 N.Kojima　   出庫指示機能追加に伴い、ｽﾄｯｶｰ情報ｾｯﾄ呼び出しを追加
    '　　　：2006/02/23 (Thu) 10:02:34 N.Kojima     使用ｶﾃｺﾞﾘｺﾝﾎﾞ追加に伴なう修正。(ﾕｰｻﾞｰ要望№0141)
    Private Sub cmbCarrType_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbCarrType.Validating
        
        Dim lblnNextCtrl        As Boolean          'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If
            
            ' NSYS フォーカス設定可能か判定
            If Me.ActiveControl.Name = cmbCarrType.Name Then
                ' 自コントロールがアクティブの場合
                lblnNextCtrl = True
            Else
                ' 自コントロール以外がアクティブの場合
                lblnNextCtrl = False
            End If

            '@前回ｷｬﾘｱﾀｲﾌﾟと同じ場合
            If mstrCarrType = cmbCarrType.Text Then
                '@ｷｬﾘｱ一覧が表示されている場合
                If vsfCarrierList.Rows.Count > vsfCarrierList.Rows.Fixed Then
                    '@一覧にｾｯﾄﾌｫｰｶｽ
                    If lblnNextCtrl Then
                    	Call pubSetFocus(vsfCarrierList)
                    End If
                End If
                
                '@処理を抜ける
                Exit Sub
            End If

            '@ｷｬﾘｱﾀｲﾌﾟID退避
            mstrCarrType = cmbCarrType.Text
            
            '@SBが"1A0"か
            If pstrSBID = CPstrSBID1A0 Then
                '@ｽﾄｯｶｰ情報ｾｯﾄ
                Call prvcmbStockerName_Disp()
            End If
            
            '@使用ｶﾃｺﾞﾘが入力されている場合
            If cmbUseCategory.Text <> vbNullString Then
                '@ｷｬﾘｱ一覧表示
                If Not lblnNextCtrl Then
                    mblnCarrierListSearch = False
                End If
                Call cmdNowList_Click(cmdNowList, New EventArgs())
                
                '@ｷｬﾘｱ一覧にﾃﾞｰﾀが1件以上ある場合
                If vsfCarrierList.Rows.Count > vsfCarrierList.Rows.Fixed Then
                    '@ｷｬﾘｱ一覧にﾌｫｰｶｽの移動
                    If lblnNextCtrl Then
	                    Call pubSetFocus(vsfCarrierList)
                    End If
                Else
                    '@使用ｶﾃｺﾞﾘｺﾝﾎﾞが有効な場合
                    If cmbUseCategory.Enabled = True Then
                        '@使用ｶﾃｺﾞﾘｺﾝﾎﾞにｾｯﾄﾌｫｰｶｽ
                        If lblnNextCtrl Or e.Cancel Then
	                        Call pubSetFocus(cmbUseCategory)
                        End If 
                    Else
                        '@最新取得ﾎﾞﾀﾝが有効か
                        If cmdNowList.Enabled = True Then
                            '@最新取得ﾎﾞﾀﾝにｾｯﾄﾌｫｰｶｽ
                            If lblnNextCtrl Then
	                            Call pubSetFocus(cmdNowList)
                            End If
                        Else
                            '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            If lblnNextCtrl Then
                            	Call pubSetFocus(cmdClose)
                            End If
                        End If
                    End If
                End If
                
                Exit Sub
            End If

            '@ｷｬﾘｱﾀｲﾌﾟID退避
            mstrCarrType = cmbCarrType.Text
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbCarrType_Validate"   '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtCarrierMnt2_Change
    '機　能：交換先ｷｬﾘｱID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 18:30:44 N.Kojima
    '更新日：2005/12/01 (Thu) 16:54:44 N.Kasai
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｷｬﾘｱ交換(交換先))Tab
    '　　　：2005/07/26 (Tue) 10:18:12 S.Deguchi    処理状態の設定を追加
    '　　　：2005/08/11 (Thu) 11:38:50 N.Kasai      ﾎﾞﾀﾝ使用条件修正
    '　　　：2005/12/01 (Thu) 16:54:44 N.Kasai      ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ条件をｺﾒﾝﾄする。
    '　　　：2018/07/24 (Tue) 11:10:28 Y.Yoneyama   防湿ALD対応
    Private Sub txtCarrierMnt2_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierMnt2.Change

        Try
                
            '@交換先ｷｬﾘｱIDが1文字も入力されてない場合
            If txtCarrierMnt2.Text <> vbNullString Then
                    
                '@ｷｬﾘｱ交換確定ﾎﾞﾀﾝのﾛｯｸ解除
                cmdExchange.Enabled = True
                
        '@↓2018/07/24 (Tue) 11:04:36 Y.Yoneyama **************************************************
                '@ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝ選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝの設定
                '@防湿ALDの場合
                If pstrSBID = CPstrSBID3A0 Then
                    optOnline0.Checked = True
                    optOnline1.Checked = False
                    optOnline0.Enabled = True
                    optOnline1.Enabled = False
                Else
                    optOnline0.Checked = True
                    optOnline1.Checked = False
                    optOnline0.Enabled = True
                    optOnline1.Enabled = True
                End If
        '@↑2018/07/24 (Tue) 11:04:36 Y.Yoneyama **************************************************
                
                
                '@交換元ｽﾛｯﾄﾏｯﾌﾟを復元する
                Call prvvsfMoveSlotMapCancel2_Disp()
                    
                '@交換先ｽﾛｯﾄﾏｯﾌﾟ初期化
                Call prvvsfMoveSlotMap_Init(vsfMoveSlotMap7)

                '@基板工程の場合は治具ID列は非表示にする
                If pstrSBID = CPstrSBID1A0 Then
                    vsfMoveSlotMap7.Cols(CMlngvsfMoveSlotMapColJIGID).Visible = False
                End If
                
                '@ｷｬﾘｱID文字数退避
                mlngLenCarrierID = Len(txtCarrierMnt2.Text)
            Else
                '@交換元ｽﾛｯﾄﾏｯﾌﾟを復元する
                Call prvvsfMoveSlotMapCancel2_Disp()
                
                '@交換先ｽﾛｯﾄﾏｯﾌﾟ初期化
                Call prvvsfMoveSlotMap_Init(vsfMoveSlotMap7)

                '@基板工程の場合は治具ID列は非表示にする
                If pstrSBID = CPstrSBID1A0 Then
                    vsfMoveSlotMap7.Cols(CMlngvsfMoveSlotMapColJIGID).Visible = False
                End If
                
                '@ｷｬﾘｱ交換確定ﾎﾞﾀﾝのﾛｯｸ
                cmdExchange.Enabled = False
            
                '@ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝ選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝの設定
                optOnline0.Checked = False
                optOnline1.Checked = False
                optOnline0.Enabled = False
                optOnline1.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierMnt2_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierMnt2_Validate
    '機　能：交換先ｷｬﾘｱID入力処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 18:28:38 N.Kojima
    '更新日：2009/06/23 (Tue) 18:17:25 T.Oide
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｷｬﾘｱ交換(交換先))Tab
    '　　　：2005/07/26 (Tue) 10:18:12 S.Deguchi    処理状態の設定を追加
    '　　　：2005/08/24 (Wed) 14:20:19 N.Kasai      既に確定ﾎﾞﾀﾝが押せる状態の場合はｵﾌﾟｼｮﾝﾎﾞﾀﾝの値を変更しない。
    '　　　：2005/11/04 (Fri) 09:32:31 N.Kojima     FOUP(OPｶｾｯﾄ)⇔FOSBは交換可能にする。(ﾕｰｻﾞｰ要望№0104)
    '　　　：2005/11/28 (Mon) 16:22:26 N.Kasai      中間在庫以外の場合はFOSBへの交換は不可
    Private Sub txtCarrierMnt2_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierMnt2.Validating
        
        Dim lblnAns             As Boolean              'ｷｬﾘｱ情報設定戻り値(True:正常,False:異常)
        Dim lblnMapDataFlag     As Boolean              'ﾃﾞｰﾀ有り無しﾌﾗｸﾞ
        Dim llngCnt             As Integer              'ｶｳﾝﾄ
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypCarrCurstate    As CarrCurstate         'ｷｬﾘｱ状態確認要求構造体
        Dim lstrDiscID          As String               '識別ID
        Dim lblnExchangeFlag    As Boolean              '確定ﾎﾞﾀﾝﾌﾗｸﾞ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If

            'NSYS メンテナンスタブを切替時はValidate処理を行わない
            If mblnTabCarrierMntSelect Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDがない場合は抜ける
            If txtCarrierMnt2.Text = vbNullString Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrierMnt2.NowByte <> txtCarrierMnt2.ChrMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"ﾒｯｾｰｼﾞｺｰﾄﾞ：<TRM07W>$$キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝ選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝの設定
                optOnline0.Checked = False
                optOnline1.Checked = False
                optOnline0.Enabled = False
                optOnline1.Enabled = False
                
                '@確定ﾎﾞﾀﾝのﾛｯｸ
                cmdExchange.Enabled = False
                
                '@再入力
                If Me.ActiveControl.Name = tabCarrier.Name OrElse _
                    Me.ActiveControl.Name = tabCarrierMnt.Name Then
                    mblnTabSelectEnabled = False
                    sender.Focus()
                Else
	                e.Cancel = True
                End If
                
                Exit Sub
            End If
                
            '@ｷｬﾘｱIDの重複ﾁｪｯｸ
            If txtCarrierID2.Text = txtCarrierMnt2.Text Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000C)
                '@"ﾒｯｾｰｼﾞｺｰﾄﾞ：<TRM0CW>$$キャリアIDが重複しています。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝ選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝの設定
                optOnline0.Checked = False
                optOnline1.Checked = False
                optOnline0.Enabled = False
                optOnline1.Enabled = False
                
                '@確定ﾎﾞﾀﾝのﾛｯｸ
                cmdExchange.Enabled = False
                
                '@再入力
                If Me.ActiveControl.Name = tabCarrier.Name OrElse _
                    Me.ActiveControl.Name = tabCarrierMnt.Name Then
                    mblnTabSelectEnabled = False
                    sender.Focus()
                Else
	                e.Cancel = True
                End If
                
                Exit Sub
            End If
                
            '@ｷｬﾘｱIDの識別IDの取得
            lstrDiscID = Strings.Left(txtCarrierMnt2.Text, CMlngDiscNum)
            
            '@識別IDの一致確認
            mstrtxtCarrierMnt2CarrType = vbNullString
            For llngCnt = 0 To mlngCarrTypListCntAll - 1
                '@識別IDが一致している場合
                If mtypCarrierMasterAll(llngCnt).strCarrierDiscID = lstrDiscID Then
                    '@ｷｬﾘｱﾀｲﾌﾟを設定
                    With mtypCarrierMasterAll(llngCnt)
                        mstrtxtCarrierMnt2CarrType = .strCarrierTypeID
                        
                        '@ｷｬﾘｱﾀｲﾌﾟﾌﾗｸﾞを退避(判定用)
                        mstrtxtCarrierMnt2TypeFlag = .strTypeFlag
                        
                    End With
                    
                    Exit For
                End If
            Next llngCnt
            
            '@ｷｬﾘｱﾀｲﾌﾟﾌﾗｸﾞで判定
            If mstrtxtCarrierID2TypeFlag <> mstrtxtCarrierMnt2TypeFlag Then
				'蒸着治具紐付け機能改修
				'簡易分割仮想キャリア（Iキャリア)→FOUP(Bキャリア) 、簡易分割仮想キャリア（Iキャリア）→ 耐熱オープン(Jキャリア)の組み合わせのみ許可する
				If Not (((mstrtxtCarrierID2CarrType = CPstrCarrTypeI And mstrtxtCarrierMnt2CarrType =　CPstrCarrTypeFOUP) Or _
						(mstrtxtCarrierID2CarrType = CPstrCarrTypeI And mstrtxtCarrierMnt2CarrType =　CPstrCarrTypeHotOP)) And pstrSBID = CPstrSBID2A0) Then
				
                
					'@表示ﾒｯｾｰｼﾞ変換
					pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003Z)
					'@"<TRM3YW>$$交換元キャリアIDとキャリアタイプが異なります。設定を見直してください。"
					Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
					'@ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝ選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝの設定
					optOnline0.Checked = False
					optOnline1.Checked = False
					optOnline0.Enabled = False
					optOnline1.Enabled = False
                
					'@確定ﾎﾞﾀﾝのﾛｯｸ
					cmdExchange.Enabled = False
                
					'@再入力
					If Me.ActiveControl.Name = tabCarrier.Name OrElse _
						Me.ActiveControl.Name = tabCarrierMnt.Name Then
						mblnTabSelectEnabled = False
						sender.Focus()
					Else
						e.Cancel = True
					End If
                
					Exit Sub
				End If
			End If
            
            '@交換元ｷｬﾘｱのﾛｯﾄ状態判定
            '@中間在庫以外でFOSBに交換は不可
            If mstrCarrierID2Status <> vbNullString Then
                '@FOSBの場合
                If mstrtxtCarrierMnt2CarrType = CPstrCarrTypeFOSB Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003Z)
                    '@"<TRM3YW>$$交換元キャリアIDとキャリアタイプが異なります。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝ選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝの設定
                    optOnline0.Checked = False
                    optOnline1.Checked = False
                    optOnline0.Enabled = False
                    optOnline1.Enabled = False
                    '@確定ﾎﾞﾀﾝのﾛｯｸ
                    cmdExchange.Enabled = False
                    '@再入力
                    If Me.ActiveControl.Name = tabCarrier.Name OrElse _
                        Me.ActiveControl.Name = tabCarrierMnt.Name Then
                        mblnTabSelectEnabled = False
                        sender.Focus()
                    Else
	                    e.Cancel = True
                    End If
                
                    Exit Sub
                End If
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "txtCarrierMnt2_Validate"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ｷｬﾘｱ情報(要求)格納
            With ltypCarrCurstate
                .strCarrierId = txtCarrierMnt2.Text     'ｷｬﾘｱID
                .strClassDivision = CPstrCD1X           'ｷｬﾘｱ交換
                .strMsgVer = CMstrcarrcurstateVer       'MSGVER
                .strSbID = mstrSBID                     '処理区分
                .strCarrierTypeID = vbNullString        'ｷｬﾘｱﾀｲﾌﾟ(判断はできない)
            End With
            
            '@ｷｬﾘｱ状態取得
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, True, mstrSlotSize)
            '@取得結果確認
            If lblnAns = True Then
                '@ﾃﾞｰﾀﾁｪｯｸﾌﾗｸﾞをfalse
                lblnMapDataFlag = False
            
                '@ﾘｽﾄにﾃﾞｰﾀがあるかﾁｪｯｸ
                For llngCnt = 1 To vsfMoveSlotMap6.Rows.Count - 1
                    '@ﾃﾞｰﾀがある場合
                    If vsfMoveSlotMap6.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                        '@ﾃﾞｰﾀﾁｪｯｸﾌﾗｸﾞをtrue
                        lblnMapDataFlag = True
                        
                        Exit For
                    End If
                Next llngCnt
                
                '@ﾃﾞｰﾀがある場合
                If lblnMapDataFlag = True Then
                    '@交換先ｽﾛｯﾄﾏｯﾌﾟにWF情報を表示
                    Call prvvsfMoveSlotMap7_Disp()
                End If
            
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝ選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝの設定
                optOnline0.Checked = False
                optOnline1.Checked = False
                optOnline0.Enabled = False
                optOnline1.Enabled = False
                
                '@確定ﾎﾞﾀﾝのﾛｯｸ
                cmdExchange.Enabled = False
                
                '@ﾌｫｰｶｽ保持
                If Me.ActiveControl.Name = tabCarrier.Name OrElse _
                    Me.ActiveControl.Name = tabCarrierMnt.Name Then
                    mblnTabSelectEnabled = False
                    sender.Focus()
                Else
	                e.Cancel = True
                End If
                
                Exit Sub
            End If
            
            '@交換先ｽﾛｯﾄﾏｯﾌﾟの表示変更
            With vsfMoveSlotMap7
                '@取得したｽﾛｯﾄｻｲｽﾞが数字の場合のみ処理
                If IsNumeric(mstrSlotSize) = True Then
                    '@ｽﾛｯﾄｻｲｽﾞ以上のｽﾛｯﾄ№を空白に、背景色を灰色(ﾎﾞﾀﾝの表面の色)に変更(初期化)
                    Dim newStyle_BackColor_vbButtonFace As CellStyle = .Styles.Add("CustomStyle_BackColor_vbButtonFace")
                    newStyle_BackColor_vbButtonFace.BackColor = vbButtonFace
                    Dim newStyle_BackColor_CPlngGridDarkGray As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                    newStyle_BackColor_CPlngGridDarkGray.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngGridDarkGray))
                    Dim cellRange As CellRange
                    For llngCnt = 1 To CMlngvsfGridRows - 1
                        If llngCnt <= CMlngvsfGridRows - CLng(mstrSlotSize) - 1 Then
                            '@ｽﾛｯﾄ№は空白
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColNo, vbNullString)
                            '@WFID
                            cellRange  = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID)
                            cellRange.Style = newStyle_BackColor_vbButtonFace
                            '@治具ID
                            cellRange = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColJIGID)
                            cellRange.Style = newStyle_BackColor_vbButtonFace
                            '@状態
                            cellRange = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFStat)
                            cellRange.Style = newStyle_BackColor_vbButtonFace
                            '@↓2020/02/07 (Fri) 17:18:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            '@GRB
                            cellRange = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColGRB)
                            cellRange.Style = newStyle_BackColor_vbButtonFace
                            '@↑2020/02/07 (Fri) 17:18:34 Y.Yoneyama 「.Netへ反映未」 **************************************************

                        Else
                            If .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) = vbNullString Then
                                '@WFID
                                cellRange = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID)
                                cellRange.Style = newStyle_BackColor_CPlngGridDarkGray
                                '@治具ID
                                cellRange = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColJIGID)
                                cellRange.Style = newStyle_BackColor_CPlngGridDarkGray
                                '@状態
                                cellRange = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                cellRange.Style = newStyle_BackColor_CPlngGridDarkGray
                                '@↓2020/02/07 (Fri) 17:19:08 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                '@GRB
                                cellRange = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColGRB)
                                cellRange.Style = newStyle_BackColor_CPlngGridDarkGray
                                '@↑2020/02/07 (Fri) 17:19:08 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            End If
                        End If
                    Next
                End If
            End With
                    
            '@状態からﾎﾞﾀﾝ制御
            Select Case mstrCarrierID2Status
                Case vbNullString, _
                     CMstrRelatedLotStatus1D, _
                     CMstrRelatedLotStatus0, _
                     CMstrRelatedLotStatus4, _
                     CMstrRelatedLotStatus5, _
                     CMstrRelatedLotStatus9
                    
                    '@ﾌﾗｸﾞ初期化
                    lblnExchangeFlag = False
                    
                    '@ｽﾛｯﾄ№が存在しないのに確定ﾎﾞﾀﾝが押せるのを修正する
                    For llngCnt = 1 To CMlngvsfGridRows - 1
                        '@ｽﾛｯﾄﾏｯﾌﾟが存在しない
                        If vsfMoveSlotMap7.GetData(llngCnt, CMlngvsfMoveSlotMapColNo) = vbNullString Then
                            '@ﾃﾞｰﾀがある場合
                            If vsfMoveSlotMap7.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                                '@ﾌﾗｸﾞをTrue
                                lblnExchangeFlag = True
                                Exit For
                            End If
                        End If
                    Next llngCnt
                    
                    If lblnExchangeFlag = True Then
                        '@確定ﾎﾞﾀﾝのﾛｯｸ
                        cmdExchange.Enabled = False
                    
                        '@ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝ選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝの設定
                        optOnline0.Checked = False
                        optOnline1.Checked = False
                        optOnline0.Enabled = False
                        optOnline1.Enabled = False
                    Else
                        '@既に確定ﾎﾞﾀﾝが押せる状態の場合はｵﾌﾟｼｮﾝﾎﾞﾀﾝの値を変更しない。
                        If cmdExchange.Enabled = False Then
                            '@確定ﾎﾞﾀﾝのﾛｯｸ解除
                            cmdExchange.Enabled = True
                            
                            '@ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝ選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝの設定
                            optOnline0.Checked = True
                            optOnline1.Checked = False
                            optOnline0.Enabled = True
                            optOnline1.Enabled = True
                        End If
                    End If
                
                Case Else
                    '@確定ﾎﾞﾀﾝのﾛｯｸ
                    cmdExchange.Enabled = False
            
                    '@ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝ選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝの設定
                    optOnline0.Checked = False
                    optOnline1.Checked = False
                    optOnline0.Enabled = False
                    optOnline1.Enabled = False
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierMnt2_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCarrierList_AfterEdit
    '機　能：ｷｬﾘｱ一覧編集後処理
    '引　数：Row：列
    '　　　：Col：行
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 14:40:23 N.Kojima
    '更新日：2006/02/23 (Thu) 14:40:23
    '備　考：
    Private Sub vsfCarrierList_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfCarrierList.AfterEdit
        
        Try
           With vsfCarrierList
            
                '@列の判定
                Select Case e.Col
                    
                    '@ｶﾃｺﾞﾘ編集終了時
                    Case CMlngvsfCarrierListColCategoryName
            
                        '@ｵｰﾄｻｲｽﾞ設定(幅)
                        '@ﾕｰｻﾞによる列幅変更されていない場合
                        If mtypChgSort.blnChgWidth = False Then
                            .AutoSizeCol(CMlngvsfCarrierListColCategoryName, 6)             'ｶﾃｺﾞﾘ
                        End If
                    
                    '@上記以外
                    Case Else
                    
                End Select
                
            End With
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfCarrierList_AfterEdit"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCarrierList_AfterUserResize
    '機　能：列幅変更時処理
    '引　数：Row：行番号
    '　　　：Col：列番号
    '戻り値：なし
    '作成日：2004/10/14 (Thu) 16:30:14 M.Miura
    '更新日：2004/10/14 (Thu) 16:30:14
    '備　考：
    Private Sub vsfCarrierList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfCarrierList.AfterResizeColumn, vsfCarrierList.AfterResizeRow

        Try

            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCarrierList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCarrierList_BeforeEdit
    '機　能：ｸﾞﾘｯﾄﾞ編集前処理
    '引　数：Row：
    '　　　：Col：
    '　　　：Cancel：
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 12:50:12 N.Kojima
    '更新日：2006/02/23 (Thu) 12:50:12
    '備　考：
    Private Sub vsfCarrierList_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfCarrierList.SetupEditor

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfCarrierList.Rows.Count <= vsfCarrierList.Rows.Fixed Then
                Return
            End If
            
            With vsfCarrierList
            
                '@ﾃﾞｰﾀ行ではない場合
                If e.Row < .Rows.Fixed Then
                    Exit Sub
                End If
            
                '@選択列がｺﾒﾝﾄの場合
                If .Col = CMlngvsfCarrierListColComments Then
                    '@最大入力文字は256ﾊﾞｲﾄまで
                    Dim tb As TextBox = CType(vsfCarrierList.Editor, TextBox)
                    tb.MaxLength = CMlngMaxLen
                End If
            
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCarrierList_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCarrierList_BeforeRowColChange
    '機　能：ｶﾚﾝﾄ行列変更時処理
    '引　数：OldRow：旧行番号
    '　　　：OldCol：旧列番号
    '　　　：NewRow：新行番号
    '　　　：NewCol：新列番号
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/10/14 (Thu) 16:34:19 M.Miura
    '更新日：2004/11/29 (Mon) 15:18:33 N.Kojima
    '備　考：
    '　　　：2004/11/29 (Mon) 15:18:33 N.Kojima　   出庫指示機能追加に伴い、出庫指示ﾎﾞﾀﾝ有効無効判定修正
    Private Sub vsfCarrierList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfCarrierList.BeforeRowColChange
        
        Dim llngCnt             As Integer      'ｶｳﾝﾄ
        Dim OldRow              As Integer      'NSYS 
        Dim NewRow              As Integer

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfCarrierList.Rows.Count <= vsfCarrierList.Rows.Fixed Then
                Return
            End If

            OldRow = e.OldRange.r1
            NewRow = e.NewRange.r1
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If OldRow <> NewRow And NewRow > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ｷｬﾘｱID、使用開始日時)
                mtypChgSort.strKey = vsfCarrierList.GetData(NewRow, CMlngvsfCarrierListColCarrierID) & _
                                     vsfCarrierList.GetData(NewRow, CMlngvsfCarrierListColStartTime)
            End If
            
            With vsfCarrierList
            
                '@選択行がﾍｯﾀﾞｰ以外の場合
                If NewRow > 0 Then
                    '@SBが"1A0"か
                    If pstrSBID = CPstrSBID1A0 Then
                        '@ｷｬﾘｱ位置が"NULL"ではないか
                        If .GetData(NewRow, CMlngvsfCarrierListColPosition) <> vbNullString Then
                            '@ｽﾄｯｶｰが"NULL"ではないか
                            If cmbStockerName.Text <> vbNullString Then
                                For llngCnt = 0 To mlngStockerListCnt - 1
                                    '@ｽﾄｯｶｰIDと選択ｷｬﾘｱ位置IDが同じか
                                    If .GetData(NewRow, CMlngvsfCarrierListColPositionID) _
                                        = mtypStockerList(llngCnt).strStockerId Then
                                        
                                        '@出庫指示ﾎﾞﾀﾝを有効に
                                        cmdShip.Enabled = True
                                        Exit For
                                    Else
                                        '@出庫指示ﾎﾞﾀﾝを無効に
                                        cmdShip.Enabled = False
                                    End If
                                Next llngCnt
                            Else
                                '@出庫指示ﾎﾞﾀﾝを無効に
                                cmdShip.Enabled = False
                            End If
                        Else
                            '@出庫指示ﾎﾞﾀﾝを無効に
                            cmdShip.Enabled = False
                        End If
                    End If
                End If
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCarrierList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfResvLotList_BeforeSort
    '機　能：ｷｬﾘｱ一覧ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 15:02:56 M.Miura
    '更新日：2004/04/14 (Wed) 15:02:56
    '備　考：ｷｬﾘｱ一覧Tab
    Private Sub vsfCarrierList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfCarrierList.BeforeSort

        Try
            'NSYS ソート時はBeforeRowColChange/RowColChangeを抑制する
            RemoveHandler vsfCarrierList.BeforeRowColChange, AddressOf vsfCarrierList_BeforeRowColChange
            RemoveHandler vsfCarrierList.RowColChange, AddressOf vsfCarrierList_RowColChange
            mintCarrierListRowBeforeSort = vsfCarrierList.Row 'NSYS ソート前の選択行を保持
            'NSYS データ行がない場合は処理を抜ける
            If vsfCarrierList.Rows.Count <= vsfCarrierList.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列 [ｷｬﾘｱID,使用開始日時] )
            Call pubVsfBeforeSort(vsfCarrierList, CMlngvsfCarrierListColCarrierID & vbTab & CMlngvsfCarrierListColStartTime)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCarrierList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCarrierList_AfterSort
    '機　能：ｷｬﾘｱ一覧ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 15:07:53 M.Miura
    '更新日：2004/10/14 (Thu) 16:31:29 M.Miura
    '備　考：ｷｬﾘｱ一覧Tab
    '　　　：2004/04/14 (Wed) 15:07:53 M.Miura　ｿｰﾄ順の格納を追加
    Private Sub vsfCarrierList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfCarrierList.AfterSort

        Try
            'NSYS ソート前の選択行が有効行でない場合、ヘッダを選択行とする
            If mintCarrierListRowBeforeSort <  vsfCarrierList.Rows.Fixed Then
                vsfCarrierList.Row = 0
            End If
            'NSYS ソート時のBeforeRowColChange/RowColChangeイベントの抑制を解除する
            RemoveHandler vsfCarrierList.BeforeRowColChange, AddressOf vsfCarrierList_BeforeRowColChange
            RemoveHandler vsfCarrierList.RowColChange, AddressOf vsfCarrierList_RowColChange
            AddHandler vsfCarrierList.BeforeRowColChange, AddressOf vsfCarrierList_BeforeRowColChange
            AddHandler vsfCarrierList.RowColChange, AddressOf vsfCarrierList_RowColChange
            'NSYS データ行がない場合は処理を抜ける
            If vsfCarrierList.Rows.Count <= vsfCarrierList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort
                Dim lChgSortList As ChgSortList = New ChgSortList()
                '@ｿｰﾄ列番号を格納
                lChgSortList.lngCol = e.Col
                '@並び替え方法を格納(昇順/降順)
                lChgSortList.lngOrder = e.Order
                If IsNothing(.typChgSortList) Then
                    .typChgSortList = New List(Of ChgSortList)()
                End If
                .typChgSortList.Add(lChgSortList)
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
            End With
            
            '@ｶﾚﾝﾄ行の設定(ｸﾞﾘｯﾄﾞ、保持列 [ｷｬﾘｱID,使用開始日時] )
            Call pubVsfAfterSort(vsfCarrierList, CMlngvsfCarrierListColCarrierID & vbTab & CMlngvsfCarrierListColStartTime, , , False, False)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCarrierList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCarrierList_Click
    '機　能：ｷｬﾘｱ一覧Click処理
    '引　数：なし
    '戻り値：
    '作成日：2006/02/22 (Wed) 14:15:49 N.Kojima
    '更新日：2006/02/22 (Wed) 14:15:49
    '備　考：
    Private Sub vsfCarrierList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfCarrierList.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfCarrierList.Rows.Count <= vsfCarrierList.Rows.Fixed Then
                Return
            End If
            
            With vsfCarrierList
                '@ﾃﾞｰﾀ行の場合
                If .Rows.Fixed <= .Row Then
                    '@ｶﾃｺﾞﾘ名、ｺﾒﾝﾄ退避(比較用)
                    mstrListCategoryName = .GetData(.Row, CMlngvsfCarrierListColCategoryName)
                    mstrListComments = .GetData(.Row, CMlngvsfCarrierListColComments)
                End If
            End With

            '@prvvsfCarrierList_Edit処理へ
            Call prvvsfCarrierList_Edit(CMlngvsfMouseClick, CMlngvsfMauseClickEvent)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCarrierList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCarrierList_ComboCloseUp
    '機　能：ｺﾝﾎﾞ選択処理
    '引　数：Row：行
    '　　　：Col：列
    '　　　：FinishEdit：編集完了値
    '戻り値：なし
    '作成日：2006/02/22 (Wed) 14:31:15 N.Kojima
    '更新日：2006/02/22 (Wed) 14:31:15
    '備　考：
    Private Sub vsfCarrierList_ComboCloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles vsfCarrierList.ComboCloseUp

        Try
            With vsfCarrierList
                RemoveHandler vsfCarrierList.ValidateEdit, AddressOf vsfCarrierList_ValidateEdit
                '@ValidateEdit処理へ
                Call vsfCarrierList_ValidateEdit(vsfCarrierList, New ValidateEditEventArgs(.Row, .Col, CheckEnum.None))
                AddHandler vsfCarrierList.ValidateEdit, AddressOf vsfCarrierList_ValidateEdit
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCarrierList_ComboCloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCarrierList_RowColChange
    '機　能：ｷｬﾘｱ一覧ﾌｫｰｶｽ移動処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 10:23:58 N.Kojima
    '更新日：2006/02/23 (Thu) 14:40:20 N.Kojima
    '備　考：ｷｬﾘｱ一覧Tab
    '　　　：2004/09/22 (Wed) 19:29:10 N.Kojima　   ｷｬﾘｱ洗浄ﾎﾞﾀﾝの有効無効のﾀｲﾐﾝｸﾞを修正
    '　　　：2006/02/23 (Thu) 14:40:20 N.Kojima     ｺﾒﾝﾄﾌｨｰﾙﾄﾞの有効無効制御追加。(ﾕｰｻﾞｰ要望№0141対応)
    Private Sub vsfCarrierList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfCarrierList.RowColChange
        
        Dim lstrStat        As String   'ｽﾃｰﾀｽ
        Dim lstrLotID       As String   'ﾛｯﾄID
        Dim lstrUnLoader    As String   'Unloader予約
        Dim lstrCarrierMoveStat    As String   'ｷｬﾘｱ強制交換

        Try
            
            With vsfCarrierList
                '@ﾃﾞｰﾀ行にﾌｫｰｶｽがあたった場合
                If .Row >= .Rows.Fixed Then
                    '@積載状態格納
                    lstrStat = .GetData(.Row, CMlngvsfCarrierListColState)
                    '@ﾛｯﾄID格納
                    lstrLotID = .GetData(.Row, CMlngvsfCarrierListColLotID)
                    '@Unloader予約格納
                    lstrUnLoader = .GetData(.Row, CMlngvsfCarrierListColUnloderReserve)
                    
                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱではない場合
                    If lstrUnLoader = vbNullString Then
                        '@積載状態が空でﾛｯﾄと紐付きがない場合
                        If lstrStat = CMstrKara And lstrLotID = vbNullString Then
                            '@洗浄ﾎﾞﾀﾝ有効
                            cmdClean.Enabled = True
                        Else
                            '@洗浄ﾎﾞﾀﾝ無効
                            cmdClean.Enabled = False
                        End If
                    Else
                        '@洗浄ﾎﾞﾀﾝ無効
                        cmdClean.Enabled = False
                    End If
                    
                    '@ｷｬﾘｱ強制交換取得
                    lstrCarrierMoveStat = .GetData(.Row, CMlngvsfCarrierListColCarrierMoveStat)
                    
                    '@ｷｬﾘｱ強制交換状態判定
                    If lstrCarrierMoveStat = CMstrCarrierMoveStatDisp Then
                        '@ｷｬﾘｱ強制交換ﾎﾞﾀﾝ使用可
                        cmdCarrierForcedmove.Enabled = True
                    Else
                        '@ｷｬﾘｱ強制交換ﾎﾞﾀﾝ使用不可
                        cmdCarrierForcedmove.Enabled = False
                    End If
                    
                    '@ｺﾒﾝﾄﾌｨｰﾙﾄﾞを有効にする
                    txtCarrierComments.Enabled = True
                    
                    '@ﾃｷｽﾄにｺﾒﾝﾄを反映
                    txtCarrierComments.Text = .GetData(.Row, CMlngvsfCarrierListColComments)
                    '@反映された変更前のﾃｷｽﾄを退避
                    mstrTextComments = txtCarrierComments.Text

                Else
                    '@洗浄ﾎﾞﾀﾝ無効
                    cmdClean.Enabled = False
                    '@ｷｬﾘｱ強制交換ﾎﾞﾀﾝ使用不可
                    cmdCarrierForcedmove.Enabled = False
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCarrierList_RowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCarrierList_KeyDown
    '機　能：編集許可の制御(ｷｰﾀﾞｳﾝ)
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2006/02/27 (Mon) 14:32:30 N.Kojima
    '更新日：2006/02/27 (Mon) 14:32:30
    '備　考：
    Private Sub vsfCarrierList_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfCarrierList.KeyDown

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfCarrierList.Rows.Count <= vsfCarrierList.Rows.Fixed Then
                Return
            End If

            With vsfCarrierList
                '@ﾃﾞｰﾀ行の場合
                If .Rows.Fixed <= .Row Then
                    '@ｶﾃｺﾞﾘ名、ｺﾒﾝﾄ退避(比較用)
                    mstrListCategoryName = .GetData(.Row, CMlngvsfCarrierListColCategoryName)
                    mstrListComments = .GetData(.Row, CMlngvsfCarrierListColComments)
                End If
            End With

            '@prvvsfLotListSend_Edit処理へ
            Call prvvsfCarrierList_Edit(CMlngvsfKeyDown, e.KeyCode)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCarrierList_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCarrierList_ValidateEdit
    '機　能：ｷｬﾘｱ一覧-編集後処理
    '引　数：Row：ｶﾚﾝﾄ行
    '　　　：Col：ｶﾚﾝﾄ列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/02/22 (Wed) 14:39:30 N.Kojima
    '更新日：2006/02/22 (Wed) 14:39:30
    '備　考：
    Private Sub vsfCarrierList_ValidateEdit(ByVal sender As Object, ByVal e As ValidateEditEventArgs) Handles vsfCarrierList.ValidateEdit

        Dim llngCnt         As Integer

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfCarrierList.Rows.Count <= vsfCarrierList.Rows.Fixed Then
                Return
            End If
            
            With vsfCarrierList
            
                '@列の判定
                Select Case e.Col
                    
                    '@ｶﾃｺﾞﾘ編集終了時
                    Case CMlngvsfCarrierListColCategoryName
                    
                        '@ﾃﾞｰﾀ行の場合
                        If .Rows.Fixed <= .Row Then
                            Dim combo As ComboBox = CType(.Editor, ComboBox)
                            '@ｶﾃｺﾞﾘ名が変更されているか変更前に退避したﾃﾞｰﾀと比較する
                            If Not IsNothing(combo) AndAlso mstrListCategoryName <> combo.SelectedItem Then
                            
                                '@変更されている場合は、ﾊﾞｯｸｶﾗｰを水色にする
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                                newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)
                                Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfCarrierListColCategoryName)
                                cellRange.Style = newStyle
                                
                                '@使用ｶﾃｺﾞﾘ/ｺﾒﾝﾄ変更ﾎﾞﾀﾝを有効にする
                                cmdUpdate.Enabled = True
                                
                                '@編集中ﾌﾗｸﾞをTrueにする
                                mblnEditFlag = True
                            End If
                        End If
                
                    '@ｺﾒﾝﾄ編集終了時
                    Case CMlngvsfCarrierListColComments
                        
                        '@文字数が256文字以内か判定
                        If Len(.Editor.Text) > CMlngMaxLen Then
                            e.Cancel = True
                        End If
                        
                        For llngCnt = 1 To Len(.Editor.Text)
                            '禁則文字処理
                            Select Case UCase$(Mid(.Editor.Text, llngCnt, 1))
                                Case CMstrNoInputString
                                '@数値(0～9),ｱﾙﾌｧﾍﾞｯﾄ(A～Z)の場合
                                    e.Cancel = False
                                    Exit For
                                Case Else
                                '@上記以外は何もしない
                            End Select
                        Next llngCnt
                        
                    '@上記以外
                    Case Else
                    
                End Select
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCarrierList_ValidateEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowList_Click
    '機　能：最新取得ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 19:39:04 N.Kojima
    '更新日：2008/07/01 (Tue) 17:49:49 M.Koni
    '備　考：ｷｬﾘｱ一覧Tab
    '　　　：ｷｬﾘｱ一覧取得ﾒｯｾｰｼﾞでｼｽﾃﾑﾌﾞﾛｯｸ追加対応(MsgVer 02.00)
    '　　　：2004/10/04 (Mon) 10:22:33 S.Deguchi    ﾒｯｾｰｼﾞを「該当件数：0件」へ変更＆最新ﾎﾞﾀﾝﾛｯｸ処理を削除
    '　　　：2004/10/18 (Mon) 14:46:28 Y.Yamagishi  0件表示のﾒｯｾｰｼﾞﾎﾞｯｸｽを表示しない(ｺﾒﾝﾄｱｳﾄ)不具合改善№1093
    '　　　：2004/12/10 (Fri) 17:56:23 N.Kasai      端末情報登録機能追加　№275
    '　　　：2005/03/25 (Fri) 10:20:53 N.Kasai      最新ﾎﾞﾀﾝ押下～表示までﾎﾞﾀﾝの使用不可
    '　　　：2005/05/30 (Mon) 10:17:54 S.Deguchi    ｾｯﾄﾌｫｰｶｽ処理対応
    '　　　：2005/10/06 (Thu) 14:53:02 S.Deguchi    不具合№2995の対応で要求情報を構造体に変更
    '　　　：2005/11/18 (Fri) 12:58:02 N.Kasai      ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ機能追加
    '　　　：2006/02/23 (Thu) 10:46:12 N.Kojima     ｷｬﾘｱ一覧取得 要求に「ｶﾃｺﾞﾘID」追加、使用ｶﾃｺﾞﾘ/ｺﾒﾝﾄ変更ﾎﾞﾀﾝの制御追加。(ﾕｰｻﾞｰ要望対応№0141)
    '　　　：2008/07/01 (Tue) 17:34:53 M.Koni       "util.regtminfo"応答ﾒｯｾｰｼﾞ変更対応<案件No.03006>
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click

        Dim ltypCarrierList         As CarrList         'ｷｬﾘｱﾘｽﾄ取得結果格納
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim lstrEventName           As String           'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        Dim lstrSBID                As String           '利用SB
        Dim lblnAns                 As Boolean          '汎用戻り値
        Dim llngAns                 As Integer          '戻り値
        Dim lstrCarrierTypeID       As String           'ｷｬﾘｱﾀｲﾌﾟ格納
        Dim ltypCarrierListReq      As CarrierListReq   '要求構造体
        Dim ltypUtilRegTmInfo       As UtilRegTmInfo    '端末設定情報格納
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@編集中判定(編集ﾌﾗｸﾞから判断)
            If mblnEditFlag = True And mblnAnsFlag = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                
                '@"編集中です。 内容を破棄してよろしいですか？"
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                '@要求確認
                If llngAns = vbNo Then
                    '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdNowList)
                    Exit Sub
                End If
            End If

           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "cmdNowList_Click"
            
            '@空白の場合抜ける
            If cmbCarrType.Text = vbNullString Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@利用SBが指定なしの場合
            If cmbSBID1.Value = vbNullString Then
                lstrSBID = vbNullString
            Else
                lstrSBID = cmbSBID1.Value
            End If

                '@使用ｶﾃｺﾞﾘ/ｺﾒﾝﾄ変更ﾎﾞﾀﾝのﾛｯｸ
                cmdUpdate.Enabled = False
                
                '@ｺﾒﾝﾄの初期化
                txtCarrierComments.Text = vbNullString

            '@ｷｬﾘｱ一覧取得 要求構造体へ情報を格納
            With ltypCarrierListReq
                .strMsgVer = CMstrcarrlist____Ver                       'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strClassDivision = CPstrCD02                           '処理区分：02全て
                .strRestrictedSBID = lstrSBID                           'ｷｬﾘｱ使用可能ｼｽﾃﾑﾌﾞﾛｯｸID
                .strCarrierTypeID = cmbCarrType.Value                   'ｷｬﾘｱﾀｲﾌﾟ
                .strCarrierId = vbNullString                            'ｷｬﾘｱID(ｷｬﾘｱID指定時設定)
                .strCleanCondition = vbNullString                       '洗浄条件
                .strCategoryID = cmbUseCategory.Value                   'ｶﾃｺﾞﾘID
            End With
                
            '@ｷｬﾘｱ一覧取得
            lblnAns = pubblnCarrList_Sel(ltypCarrierListReq, ltypCarrierList)
            
            '@結果確認
            If lblnAns = True Then
                
                '@取得OKなら結果表示
                Call prvvsfCarrierList_Disp(ltypCarrierList)

                '@最新取得ﾎﾞﾀﾝのﾛｯｸ
                cmdNowList.Enabled = True
          
                '@件数の判定
                If vsfCarrierList.Rows.Count > vsfCarrierList.Rows.Fixed Then
                    '@件数が1件以上ある場合
                    '@ｸﾞﾘｯﾄﾞを使用可能にする
                    vsfCarrierList.Enabled = True
                    
                    '@選択Tabがｷｬﾘｱ一覧Tabの場合
                    If tabCarrier.SelectedIndex = CMlngtabCarrier1 Then
                        If mblnCarrierListSearch Then
                            Call pubSetFocus(vsfCarrierList)
                        End If
                    End If
                    
                    '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ使用可
                    cmdCopy.Enabled = True
                Else
                    '@件数が0件の場合
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@ｷｬﾘｱ一覧ﾛｯｸ
                    vsfCarrierList.Enabled = False
                    '@洗浄ﾎﾞﾀﾝﾛｯｸ
                    cmdClean.Enabled = False
                    
                    '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝﾛｯｸ
                    cmdCopy.Enabled = False
                    
                    Exit Sub
                End If
                
                '@起動SB=使用SBが一致した場合は端末情報へ書き込みする。
                '@一致しない場合は値をｸﾘｱ(利用SBはﾕｰｻﾞで変更可能である。初期表示起動SBｷｬﾘｱﾀｲﾌﾟが不一致となって起動される為)
                If pstrSBID = cmbSBID1.Value Then
                    lstrCarrierTypeID = cmbCarrType.Value
                Else
                    lstrCarrierTypeID = vbNullString
                End If
                
                '@MSG[端末設定情報登録]の実行
                lblnAns = pubblnUtilRegTmInfo_Upd(pstrSBID, CMstrutilregtminfoVer, _
                                                  CPstrCD3O, _
                                                  pstrComputerName, _
                                                  ltypUtilRegTmInfo, _
                                                  , , , , lstrCarrierTypeID)
                
                '@MSG[端末設定情報登録]の結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                Exit Sub
            Else
                
                '@最新取得ﾎﾞﾀﾝを活性化
                cmdNowList.Enabled = True
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@ｷｬﾘｱ一覧ﾛｯｸ
                vsfCarrierList.Enabled = False
                
                '@ｷｬﾘｱﾀｲﾌﾟが有効の場合
                If cmbCarrType.Enabled = True Then
                    '@ｷｬﾘｱﾀｲﾌﾟにﾌｫｰｶｽｾｯﾄ
                    If mblnCarrierListSearch Then
                        Call pubSetFocus(cmbCarrType)
                    End If
                End If
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdNowList_Click"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        Finally
            mblnCarrierListSearch = True

        End Try
    End Sub

    '関数名：cmdClean_Click
    '機　能：洗浄処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 10:08:24 N.Kojima
    '更新日：2006/02/27 (Mon) 10:38:57 N.Kojima
    '備　考：ｷｬﾘｱ一覧Tab
    '　　　：2005/10/06 (Thu) 14:53:02 S.Deguchi    不具合№2995の対応で要求情報を構造体に変更
    '　　　：2006/02/27 (Mon) 10:38:57 N.Kojima     ｷｬﾘｱ一覧取得 要求に「ｶﾃｺﾞﾘID」追加。(ﾕｰｻﾞｰ要望№0141)
    Private Sub cmdClean_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClean.Click
            
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrCarrier             As String               'ｷｬﾘｱID
        Dim ltypCarrierList         As CarrList             'ｷｬﾘｱﾘｽﾄ取得結果格納
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim llngCarrierRow          As Integer              '該当ｷｬﾘｱ行
        Dim ltypCarrierListReq      As CarrierListReq       '要求構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@画面入力ﾁｪｯｸ(ｷｬﾘｱID取得)
            lblnAns = prvblnCleanInput_Check(lstrCarrier)
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdClean_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ｷｬﾘｱ洗浄ﾒｯｾｰｼﾞ送信
            lblnAns = pubblnCarrClean_Upd(CMstrcarrclean___Ver, lstrCarrier, pstrUserID)
            
            '@結果判定
            If lblnAns = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000C, lstrCarrier)
                '@成功ﾒｯｾｰｼﾞ表示
                '@pubVsfInfo_Disp("C_I0C%0$$キャリア[%1]の洗浄を完了しました。$いつでも利用可能です。")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@該当ｷｬﾘｱIDを検索
                With vsfCarrierList
                    For llngCnt = 1 To .Rows.Count - 1
                        '@一覧の内容と該当ｷｬﾘｱIDを比較して行番号を取得する。
                        If .GetData(llngCnt, CMlngvsfCarrierListColCarrierID) = lstrCarrier Then
                            llngCarrierRow = llngCnt
                            Exit For
                        End If
                    Next llngCnt
                End With

                '@検索結果判定
                If llngCarrierRow = 0 Then
                    '@ｸﾞﾘｯﾄにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfCarrierList)
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    Exit Sub
                End If

                '@ｷｬﾘｱ一覧取得 要求構造体へ情報を格納
                With ltypCarrierListReq
                    .strMsgVer = CMstrcarrlist____Ver                       'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                    .strSbID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                    .strClassDivision = CPstrCD0K                           '処理区分：0K ｷｬﾘｱ指定
                    .strRestrictedSBID = vbNullString                       'ｷｬﾘｱ使用可能ｼｽﾃﾑﾌﾞﾛｯｸID
                    .strCarrierTypeID = vbNullString                        'ｷｬﾘｱﾀｲﾌﾟ
                    .strCarrierId = lstrCarrier                             'ｷｬﾘｱID(ｷｬﾘｱID指定時設定)
                    .strCleanCondition = vbNullString                       '洗浄条件
                    .strCategoryID = cmbUseCategory.Value                   'ｶﾃｺﾞﾘID
                End With
                
                '@ｷｬﾘｱ一覧取得(ｷｬﾘｱID指定)
                lblnAns = pubblnCarrList_Sel(ltypCarrierListReq, ltypCarrierList)
                
                '@取得結果確認
                If lblnAns = True Then
                    '@ﾘｽﾄｶｳﾝﾄを判定
                    If ltypCarrierList.lngCarrierListCnt > 0 Then
                        '@件数ありの場合画面表示
                        Call prvCarrierClean_Disp(ltypCarrierList, llngCarrierRow)
                    End If
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    '@ｸﾞﾘｯﾄにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfCarrierList)
                    Exit Sub
                End If

                '@ｸﾞﾘｯﾄにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfCarrierList)
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                '@ｷｬﾘｱﾀｲﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbCarrType)
            End If
                
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdClean_Click"         '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
                
        End Try
    End Sub

    '====================================ｷｬﾘｱﾒﾝﾃﾅﾝｽ(共通)Tab====================================
    '関数名：txtCarrierID2_Change
    '機　能：ｷｬﾘｱID変更処理(ｷｬﾘｱﾒﾝﾃﾅﾝｽTab)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 15:35:55 N.Kojima
    '更新日：2004/06/30 (Wed) 15:35:55
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(共通)
    '　　　：2004/09/29 (Wed) 09:36:41 S.Deguchi 初期化ﾌﾗｸﾞによる判別処理を追加
    Private Sub txtCarrierID2_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID2.Change
        
        '@初期化ﾌﾗｸﾞによる処理分岐
        If mblnInitFlg = False Then
            '@ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)ﾀﾌﾞ初期化
            Call prvCarrierTabMnt0_Init()
            
            '@一度初期化したら初期化処理を行わない為にﾌﾗｸﾞを変更する
            mblnInitFlg = True
        End If
        
     End Sub

    '関数名：txtCarrierID2_Validate
    '機　能：ｷｬﾘｱID入力処理(ｷｬﾘｱﾒﾝﾃﾅﾝｽTab)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 15:35:10 N.Kojima
    '更新日：2013/05/17 (Fri) 10:11:47 T.Oide
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(共通)Tab
    '　　　：2004/09/16 (Thu) 20:33:10 N.Kojima　   ｷｬﾘｱ交換Tab処理追加(不具合№608)
    '　　　：2004/09/26 (Sun) 17:46:32 N.Kojima　   ｷｬﾘｱに紐付くWFが存在しない場合のMsgを変更(不具合№774)
    '　　　：2004/09/29 (Wed) 09:36:41 S.Deguchi    初期化ﾌﾗｸﾞの初期化処理追加
    '　　　：2004/10/27 (Wed) 10:09:29 Y.Yamagishi  ｷｬﾘｱﾀｲﾌﾟを取得する(統合先ｷｬﾘｱID、交換先ｷｬﾘｱID比較用)
    '　　　：2005/05/30 (Mon) 09:14:23 S.Deguchi    位置情報取得ﾒｯｾｰｼﾞ送信は特定Tabの場合のみ行うように修正
    '　　　：2005/11/21 (Mon) 15:47:49 N.Kasai      WF廃棄ﾀﾌﾞ修正
    '　　　：2009/12/03 (Thu) 16:46:09 T.Oide       ｽﾛｯﾄ情報変更Tabに[空治具選択]ﾎﾞﾀﾝ追加
    '　　　：2013/05/17 (Fri) 10:11:47 T.Oide       無機蒸着治具ODF対応
    Private Sub txtCarrierID2_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierID2.Validating
        
        Dim lblnAns             As Boolean              'ｷｬﾘｱ情報設定戻り値(True:正常,False:異常)
        Dim ltypWaferList       As Waferlist            'ｷｬﾘｱWF情報構造体
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngCnt             As Integer              'ｶｳﾝﾄ
        Dim lstrDiscID          As String               '識別ID
        Dim lblnAnsLot          As Boolean              'ﾛｯﾄ情報取得結果格納
        Dim lblnAnsLot2         As Boolean              'ﾛｯﾄ属性情報取得結果格納
        Dim lblnNextCtrl        As Boolean              'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If
            
            ' NSYS フォーカス設定可能か判定
            If Me.ActiveControl.Name = vsfMoveSlotMap.Name OrElse _
                Me.ActiveControl.Name = vsfMoveSlotMap3.Name OrElse _
                Me.ActiveControl.Name = vsfMoveSlotMap5.Name OrElse _
                Me.ActiveControl.Name = cmbChangePosiotionID.Name OrElse _
                Me.ActiveControl.Name = vsfMoveSlotMap6.Name OrElse _ 
                Me.ActiveControl.Name = txtCarrierID2.Name Then
                ' 次コントロールがアクティブの場合
                lblnNextCtrl = True
            Else
                ' 次コントロール以外がアクティブの場合
                lblnNextCtrl = False
            End If
            
            '@在庫管理からよばれた場合は抜ける
            If txtCarrierID2.GotHighLight = False Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDがない場合は抜ける
            If txtCarrierID2.Text = vbNullString Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrierID2.NowByte <> txtCarrierID2.ChrMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@再入力
                If Me.ActiveControl.Name = tabCarrier.Name Then
                    mblnTabSelectEnabled = False
                    sender.Focus()
                Else
	                e.Cancel = True
                End If
                
                Exit Sub
            End If

            '@ｷｬﾘｱIDの比較
            If mstrCarrier = txtCarrierID2.Text Then
                Select Case tabCarrierMnt.SelectedIndex
                    '@WF統合
                    Case CMlngtabCarrierMnt0
                        '@統合先ｷｬﾘｱIDが有効な場合
                        If txtCarrierMnt.Enabled = True Then
                            '@統合先ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                            If lblnNextCtrl Then
	                            Call pubSetFocus(txtCarrierMnt)
                            End If
                        Else
                            '@閉じるにﾌｫｰｶｽｾｯﾄ
                            If lblnNextCtrl Then
	                            Call pubSetFocus(cmdClose)
	                        End If
                        End If
                        
                    '@ｽﾛｯﾄ情報変更
                    Case CMlngtabCarrierMnt1
                         '@変更前ｽﾛｯﾄﾏｯﾌﾟが有効な場合
                        If vsfMoveSlotMap3.Enabled = True Then
                            '@ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                            If lblnNextCtrl Then
	                            Call pubSetFocus(vsfMoveSlotMap3)
                            End If 
                        Else
                            '@閉じるにﾌｫｰｶｽｾｯﾄ
                            If lblnNextCtrl Then
                            	Call pubSetFocus(cmdClose)
                            End If
                        End If
                        
                    '@WF廃棄
                    Case CMlngtabCarrierMnt2
                                    
                        '@ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                        If vsfMoveSlotMap5.Enabled = True Then
                            If lblnNextCtrl Then
	                            Call pubSetFocus(vsfMoveSlotMap5)
                            End If
                        Else
                            '@閉じるにﾌｫｰｶｽｾｯﾄ
                            If lblnNextCtrl Then
                            	Call pubSetFocus(cmdClose)
                            End If
                        End If

                    '@ｷｬﾘｱ位置変更
                    Case CMlngtabCarrierMnt3
                        '@変更後位置が有効な場合
                        If cmbChangePosiotionID.Enabled = True Then
                            '@変更後位置にﾌｫｰｶｽｾｯﾄ
                            If lblnNextCtrl Then
                            	Call pubSetFocus(cmbChangePosiotionID)
                            End If
                        End If
                        
                    '@ｷｬﾘｱ交換
                    Case CMlngtabCarrierMnt4
                        '@交換先ｷｬﾘｱIDが有効な場合
                        If txtCarrierMnt2.Enabled = True Then
                            '@交換先ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                            If lblnNextCtrl Then
                            	Call pubSetFocus(txtCarrierMnt2)
                            End If
                        Else
                            '@閉じるにﾌｫｰｶｽｾｯﾄ
                            If lblnNextCtrl Then
                            	Call pubSetFocus(cmdClose)
                            End If
                        End If
                End Select
                
                Exit Sub
            End If
            
            
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "txtCarrierID2_Validate"
            Call pubResponseStart(lstrFormName, lstrEventName)
                
            '@ｷｬﾘｱWF情報の取得
            lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                             txtCarrierID2.Text, _
                                             CPstrCD3Y, _
                                             ltypWaferList, , _
                                             mstrSBID)
            '@結果判定
            If lblnAns = True Then
            
                '大工程、小工程を退避しておく(治具の使用可否確認用)
                mstrLotId = ltypWaferList.strLotID
                mstrOpID = ltypWaferList.strOpID
                mstrStepID = ltypWaferList.strStepID
                If ltypWaferList.strCfFlag = "1" Then
                    mblnCfFlag = True
                Else
                    mblnCfFlag = False
                End If
            
                '@ｽﾛｯﾄｻｲｽﾞを退避
                mstrSlotSize = ltypWaferList.strSlotSize
            
                '@現在位置ｾｯﾄ
                lblCurrentPositionID.Text = ltypWaferList.strCurrentPositionName
                
                '@ｷｬﾘｱの状態を退避
                mstrCarrierID2Status = ltypWaferList.strState
                
                '@装置種別退避(H/W=0, NORMAL=1, 装置未確定="")
                mstrWpTypeFlag = ltypWaferList.strWpTypeFlag
                
                '@移載予約ﾌﾗｸﾞ退避(0:予約なし、1:移載予約中)
                mstrWpCarryFlag = ltypWaferList.strWfCarryFlag
                
                '@TPAL設定ｾｯﾄ
                mstrTpalClass = ltypWaferList.strTpalClass
                
                '@EQﾀｲﾌﾟｾｯﾄ
                mstrEqType = ltypWaferList.strEqType
                
                '@ｷｬﾘｱｶﾃｺﾞﾘIDｾｯﾄ
                pstrCarrierCategoryID = ltypWaferList.strCarrierCategoryId
                
                
                '@Tab："キャリア位置変更"が表示されている場合下記処理を行う
                If tabCarrierMnt.SelectedIndex = CMlngtabCarrierMnt3 Then
                    lblnAns = prvblnmasPlaceList_Sel(txtCarrierID2.Text, True)
                    '@結果判定
                    If lblnAns = False Then
                        '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                        If Me.ActiveControl.Name = tabCarrier.Name Then
                            mblnTabSelectEnabled = False
                            sender.Focus()
                        Else
	                        e.Cancel = True
                        End If
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
            
                        Exit Sub
                    End If
                End If

                '@WFがあり、ｷｬﾘｱ位置情報変更ﾀﾌﾞではない場合
                If ltypWaferList.lngListCnt <> 0 Then
                    '@ｷｬﾘｱID退避
                    mstrCarrier = txtCarrierID2.Text
                End If
                
                '@WFが0枚でｷｬﾘｱ位置情報変更ﾀﾌﾞではない場合
                If ltypWaferList.lngListCnt = 0 Then
                    '@ｷｬﾘｱ位置情報変更ﾀﾌﾞ以外の場合
                    If tabCarrierMnt.SelectedIndex <> CMlngtabCarrierMnt3 Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0077, txtCarrierID2.Text)
                        '@publngMsgBoxInfo("ﾒｯｾｰｼﾞｺｰﾄﾞ：<TRM77W>$$キャリア[%1]に紐付くウエハが存在しません。")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                        If Me.ActiveControl.Name = tabCarrier.Name Then
                            mblnTabSelectEnabled = False
                            sender.Focus()
                        Else
                        	e.Cancel = True
                        End If
                    Else
                        '@変更後位置にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbChangePosiotionID)
                    End If
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@初期化ﾌﾗｸﾞを元に戻す
                    mblnInitFlg = False
                    
                    Exit Sub
                End If
                
                '@ｷｬﾘｱIDの識別IDの取得
                lstrDiscID = Strings.Left(txtCarrierID2.Text, CMlngDiscNum)
                
                '@識別IDの一致確認
                mstrtxtCarrierID2CarrType = vbNullString
                For llngCnt = 0 To mlngCarrTypListCntAll - 1
                    '@識別IDが一致している場合
                    If mtypCarrierMasterAll(llngCnt).strCarrierDiscID = lstrDiscID Then
                        '@ｷｬﾘｱﾀｲﾌﾟを設定
                        With mtypCarrierMasterAll(llngCnt)
                            mstrtxtCarrierID2CarrType = .strCarrierTypeID

                            '@ｷｬﾘｱﾀｲﾌﾟﾌﾗｸﾞを退避(判定用)
                            mstrtxtCarrierID2TypeFlag = .strTypeFlag
                            
                        End With
                        Exit For
                    End If
                Next llngCnt
                Dim tmpFlg As Boolean
            
                '@WF統合画面表示処理
                tmpFlg = fraCarrierMnt0.Enabled
                If tmpFlg = False Then
                    fraCarrierMnt0.Enabled = True
                End If
                Call prvvsfMoveSlotMap_Disp(vsfMoveSlotMap, ltypWaferList)
                If tmpFlg = False Then
                    fraCarrierMnt0.Enabled = False
                End If
                '@ｽﾛｯﾄ情報変更画面表示処理
                tmpFlg = fraCarrierMnt1.Enabled
                If tmpFlg = False Then
                    fraCarrierMnt1.Enabled = True
                End If
                Call prvvsfMoveSlotMap_Disp(vsfMoveSlotMap3, ltypWaferList)
                If tmpFlg = False Then
                    fraCarrierMnt1.Enabled = False
                End If
                '@WF廃棄画面表示処理
                tmpFlg = fraCarrierMnt2.Enabled
                If tmpFlg = False Then
                    fraCarrierMnt2.Enabled = True
                End If
                Call prvvsfMoveSlotMap_Disp(vsfMoveSlotMap5, ltypWaferList)
                If tmpFlg = False Then
                    fraCarrierMnt2.Enabled = False
                End If
                '@ｷｬﾘｱ交換画面表示処理
                tmpFlg = fraCarrierMnt4.Enabled
                If tmpFlg = False Then
                    fraCarrierMnt4.Enabled = True
                End If
                Call prvvsfMoveSlotMap_Disp(vsfMoveSlotMap6, ltypWaferList)
                If tmpFlg = False Then
                    fraCarrierMnt4.Enabled = False
                End If
                
                '@組立てでCF_FLAG = 1、VB_FLAG = 0の場合WF_IDのｶﾗﾑを非表示にする
                If pstrSBID = CPstrSBID2A0 Then
                    If ltypWaferList.strCfFlag = CPstrOne And ltypWaferList.strLpFlag = CPstrZero Then
                        vsfMoveSlotMap.Cols(CMlngvsfMoveSlotMapColWFID).Visible = False
                        vsfMoveSlotMap2.Cols(CMlngvsfMoveSlotMapColWFID).Visible = False
                        vsfMoveSlotMap3.Cols(CMlngvsfMoveSlotMapColWFID).Visible = False
                        vsfMoveSlotMap4.Cols(CMlngvsfMoveSlotMapColWFID).Visible = False
                        vsfMoveSlotMap5.Cols(CMlngvsfMoveSlotMapColWFID).Visible = False
                        vsfMoveSlotMap6.Cols(CMlngvsfMoveSlotMapColWFID).Visible = False
                        vsfMoveSlotMap7.Cols(CMlngvsfMoveSlotMapColWFID).Visible = False

                        '@↓2020/02/07 (Fri) 17:20:35 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        vsfMoveSlotMap.Cols(CMlngvsfMoveSlotMapColGRB).Visible = False
                        vsfMoveSlotMap2.Cols(CMlngvsfMoveSlotMapColGRB).Visible = False
                        vsfMoveSlotMap3.Cols(CMlngvsfMoveSlotMapColGRB).Visible = False
                        vsfMoveSlotMap4.Cols(CMlngvsfMoveSlotMapColGRB).Visible = False
                        vsfMoveSlotMap5.Cols(CMlngvsfMoveSlotMapColGRB).Visible = False
                        vsfMoveSlotMap6.Cols(CMlngvsfMoveSlotMapColGRB).Visible = False
                        vsfMoveSlotMap7.Cols(CMlngvsfMoveSlotMapColGRB).Visible = False
                        '@↑2020/02/07 (Fri) 17:20:35 Y.Yoneyama 「.Netへ反映未」 **************************************************
                
                    Else
                        vsfMoveSlotMap.Cols(CMlngvsfMoveSlotMapColWFID).Visible = True
                        vsfMoveSlotMap2.Cols(CMlngvsfMoveSlotMapColWFID).Visible = True
                        vsfMoveSlotMap3.Cols(CMlngvsfMoveSlotMapColWFID).Visible = True
                        vsfMoveSlotMap4.Cols(CMlngvsfMoveSlotMapColWFID).Visible = True
                        vsfMoveSlotMap5.Cols(CMlngvsfMoveSlotMapColWFID).Visible = True
                        vsfMoveSlotMap6.Cols(CMlngvsfMoveSlotMapColWFID).Visible = True
                        vsfMoveSlotMap7.Cols(CMlngvsfMoveSlotMapColWFID).Visible = True
                
                        '@↓2020/02/07 (Fri) 17:21:10 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        vsfMoveSlotMap.Cols(CMlngvsfMoveSlotMapColGRB).Visible = True
                        vsfMoveSlotMap2.Cols(CMlngvsfMoveSlotMapColGRB).Visible = True
                        vsfMoveSlotMap3.Cols(CMlngvsfMoveSlotMapColGRB).Visible = True
                        vsfMoveSlotMap4.Cols(CMlngvsfMoveSlotMapColGRB).Visible = True
                        vsfMoveSlotMap5.Cols(CMlngvsfMoveSlotMapColGRB).Visible = True
                        vsfMoveSlotMap6.Cols(CMlngvsfMoveSlotMapColGRB).Visible = True
                        vsfMoveSlotMap7.Cols(CMlngvsfMoveSlotMapColGRB).Visible = True
                        '@↑2020/02/07 (Fri) 17:21:10 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    End If
                End If

                Select Case tabCarrierMnt.SelectedIndex
                
                    '@WF統合ﾀﾌﾞ
                    Case CMlngtabCarrierMnt0
                    
                        If txtCarrierMnt.Enabled = True AndAlso lblnNextCtrl Then
                            '@統合先ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(txtCarrierMnt)
                        End If
                        
                    '@ｽﾛｯﾄ情報変更ﾀﾌﾞ
                    Case CMlngtabCarrierMnt1
                    
                        If vsfMoveSlotMap3.Enabled = True AndAlso lblnNextCtrl Then
                            '@ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfMoveSlotMap3)
                        End If
                        
                    '@WF廃棄ﾀﾌﾞ
                    Case CMlngtabCarrierMnt2
                                    
                        '@ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                        If vsfMoveSlotMap5.Enabled = True AndAlso lblnNextCtrl Then
                            Call pubSetFocus(vsfMoveSlotMap5)
                        End If

                    '@ｷｬﾘｱ位置変更ﾀﾌﾞ
                    Case CMlngtabCarrierMnt3
                    	If lblnNextCtrl Then
	                        '@変更後位置にﾌｫｰｶｽｾｯﾄ
	                        Call pubSetFocus(cmbChangePosiotionID)
                        End If
                    
                    '@ｷｬﾘｱ交換ﾀﾌﾞ
                    Case CMlngtabCarrierMnt4
                    
                        If txtCarrierMnt2.Enabled = True AndAlso lblnNextCtrl Then
                            '@交換先ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(txtCarrierMnt2)
                        End If
                        
                End Select
                
                '@初期化ﾌﾗｸﾞを元に戻す
                mblnInitFlg = False

                '@治具IDがNULLで無い場合ﾛｯﾄ現在状態を取得(変更治具の候補を取得する情報を得るため)
                If ltypWaferList.typWfList(0).strjigId <> vbNullString Then
                    '@ﾛｯﾄﾃﾞｰﾀを取得
                    lblnAnsLot = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                       CPstrCD3L, _
                                                       txtCarrierID2.Text, _
                                                       mtypLotCurState)
                                                       
                    '@ﾛｯﾄ属性情報要求ﾒｯｾｰｼﾞ格納
                    With mtypLotAttribute
                        .strMsgVer = CMstrlot_attributeVer
                        .strSbID = pstrSBID
                        .strReqCarrierID = mtypLotCurState.strCarrierId
                        .strReqLotID = mtypLotCurState.strLotID
                    End With
                    
                    'ﾛｯﾄ属性情報取得(ATLAS_FLOW_NUMBERを取得するため→CM0130の呼び出し時に使用する)
                    lblnAnsLot2 = pubblnLotAttribute_Sel(mtypLotAttribute)

                    '@ﾛｯﾄ現在状態とﾛｯﾄ属性情報の取得に失敗した場合は処理中断
                    If lblnAnsLot = False Or _
                       lblnAnsLot2 = False Then

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        Exit Sub
                    End If
                    
                    '@ATLASﾌﾛｰﾅﾝﾊﾞｰ退避
                    pstrAtlasFlowNumber = mtypLotAttribute.strAtlasFlowNumber
                    
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                If Me.ActiveControl.Name = tabCarrier.Name Then
                    mblnTabSelectEnabled = False
                    sender.Focus()
                Else
	                e.Cancel = True
                End If
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtCarrierID2_Validate"     '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：tabCarrierMnt_Click
    '機　能：ｷｬﾘｱﾒﾝﾃﾅﾝｽﾀﾌﾞ切り替え処理
    '引　数：PreviousTab：ﾀﾌﾞｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 17:48:50 N.Kojima
    '更新日：2004/09/16 (Thu) 19:54:12 N.Kojima
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(共通)Tab
    '　　　：2004/09/16 (Thu) 19:54:12 N.Kojima　ｷｬﾘｱ交換Tab切り替え時の処理追加(不具合№608)
    Private Sub tabCarrierMnt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tabCarrierMnt.SelectedIndexChanged

        Dim lblnAns As Boolean              '結果判定
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@在庫管理から呼ばれた場合
            If txtCarrierID2.BackColor = vbButtonFace Then
                fraCarrier0.Enabled = False
                fraCarrier1.Enabled = False
                fraCarrier2.Enabled = True
            End If
            
            mblnTabCarrierMntSelect = True
            With tabCarrierMnt
                Select Case .SelectedIndex
                    '@ｷｬﾘｱﾒﾝﾃﾅﾝｽWF統合ﾀﾌﾞ
                    Case CMlngtabCarrierMnt0
                        '@有効ﾀﾌﾞ制御
                        fraCarrierMnt1.Enabled = False
                        fraCarrierMnt2.Enabled = False
                        fraCarrierMnt3.Enabled = False
                        fraCarrierMnt4.Enabled = False
                        fraCarrierMnt0.Enabled = True
                        
                        '@ﾌｫｰﾑがShowされている場合
                        If Me.Visible = True Then
                            '@在庫管理から呼ばれた場合
                            If txtCarrierID2.BackColor = vbButtonFace Then
                                '@Form_Loadから呼ばれていない場合
                                If txtCarrierID2.Locked = True Then
                                    '@統合先ｷｬﾘｱIDが有効か
                                    If txtCarrierMnt.Enabled = True Then
                                        '@統合先ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                                        Call pubSetFocus(txtCarrierMnt)
                                    End If
                                End If
                            Else
                                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(txtCarrierID2)
                                
                                '@移載ﾎﾞﾀﾝは初期化
                                cmdMove.Enabled = False
                                cmdMoveCancel.Enabled = False
                            End If
                        End If
                        
                    '@ｷｬﾘｱﾒﾝﾃﾅﾝｽｽﾛｯﾄ情報ﾀﾌﾞ
                    Case CMlngtabCarrierMnt1
                        '@有効ﾀﾌﾞ制御
                        fraCarrierMnt0.Enabled = False
                        fraCarrierMnt1.Enabled = True
                        fraCarrierMnt2.Enabled = False
                        fraCarrierMnt3.Enabled = False
                        fraCarrierMnt4.Enabled = False
                        
                        '@ﾌｫｰﾑがShowされている場合
                        If Me.Visible = True Then
                            '@在庫管理から呼ばれた場合
                            If txtCarrierID2.BackColor = vbButtonFace Then
                                '@Form_Loadから呼ばれていない場合
                                If txtCarrierID2.Locked = True Then
                                    '@ｽﾛｯﾄﾏｯﾌﾟが有効か
                                    If vsfMoveSlotMap3.Enabled = True Then
                                        '@ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                                         Call pubSetFocus(vsfMoveSlotMap3)
                                    End If
                                End If
                            Else
                                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(txtCarrierID2)
                            
                                '@移載ﾎﾞﾀﾝは初期化
                                cmdMove2.Enabled = False
                                cmdMoveCancel2.Enabled = False
                            End If
                        End If
                    
                    '@ｷｬﾘｱﾒﾝﾃﾅﾝｽWF廃棄ﾀﾌﾞ
                    Case CMlngtabCarrierMnt2
                        '@有効ﾀﾌﾞ制御
                        fraCarrierMnt0.Enabled = False
                        fraCarrierMnt1.Enabled = False
                        fraCarrierMnt2.Enabled = True
                        fraCarrierMnt3.Enabled = False
                        fraCarrierMnt4.Enabled = False
                        
                        '@ﾌｫｰﾑがShowされている場合
                        If Me.Visible = True Then
                            '@在庫管理から呼ばれた場合
                            If txtCarrierID2.BackColor = vbButtonFace Then
                                '@Form_Loadから呼ばれていない場合
                                If txtCarrierID2.Locked = True Then
                                    '@ｺﾒﾝﾄが有効か
                                    If txtComment.Enabled = True Then
                                        '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
                                        Call pubSetFocus(txtComment)
                                    End If
                                End If
                            Else
                                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(txtCarrierID2)
                            End If
                        End If
                        
                    '@ｷｬﾘｱﾒﾝﾃﾅﾝｽｷｬﾘｱ位置情報変更ﾀﾌﾞ
                    Case CMlngtabCarrierMnt3
                        '@有効ﾀﾌﾞ制御
                        fraCarrierMnt0.Enabled = False
                        fraCarrierMnt1.Enabled = False
                        fraCarrierMnt2.Enabled = False
                        fraCarrierMnt3.Enabled = True
                        fraCarrierMnt4.Enabled = False
                        
                        '@ｷｬﾘｱIDの桁ﾁｪｯｸ
                        If txtCarrierID2.NowByte <> txtCarrierID2.ChrMaxByte Then
                            Exit Sub
                        End If
                        
                        '@ｷｬﾘｱIDがNULLではなく,退避領域と異なり,位置情報ｺﾝﾎﾞが非活性化の場合
                        If txtCarrierID2.Text <> vbNullString _
                           And cmbChangePosiotionID.Enabled = False Then
                            
                            lblnAns = prvblnmasPlaceList_Sel(txtCarrierID2.Text, False)
                            '@結果判定
                            If lblnAns = False Then
                                Exit Sub
                            End If
                        End If
                        
                        '@ﾌｫｰﾑがShowされている場合
                        If Me.Visible = True Then
                            '@在庫管理から呼ばれた場合
                            If txtCarrierID2.BackColor = vbButtonFace Then
                                '@Form_Loadから呼ばれていない場合
                                If txtCarrierID2.Locked = True Then
                                    '@変更後位置が有効か
                                    If cmbChangePosiotionID.Enabled = True Then
                                        '@変更後位置にﾌｫｰｶｽｾｯﾄ
                                        Call pubSetFocus(cmbChangePosiotionID)
                                    End If
                                End If
                            Else
                                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(txtCarrierID2)
                            End If
                        End If
                        
                    '@ｷｬﾘｱﾒﾝﾃﾅﾝｽｷｬﾘｱ交換ﾀﾌﾞ
                    Case CMlngtabCarrierMnt4
                        '@有効ﾀﾌﾞ制御
                        fraCarrierMnt0.Enabled = False
                        fraCarrierMnt1.Enabled = False
                        fraCarrierMnt2.Enabled = False
                        fraCarrierMnt3.Enabled = False
                        fraCarrierMnt4.Enabled = True
                        
                        '@ﾌｫｰﾑがShowされている場合
                        If Me.Visible = True Then
                            '@在庫管理から呼ばれた場合
                            If txtCarrierID2.BackColor = vbButtonFace Then
                                '@Form_Loadから呼ばれていない場合
                                If txtCarrierID2.Locked = True Then
                                    '@交換先ｷｬﾘｱIDが有効か
                                    If txtCarrierMnt2.Enabled = True Then
                                        '@交換先ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                                        Call pubSetFocus(txtCarrierMnt2)
                                    End If
                                End If
                            Else
                                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(txtCarrierID2)
                            End If
                        End If
                End Select
            End With
            mblnTabCarrierMntSelect = False
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "tabCarrierMnt_Click"    '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '====================================ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)Tab====================================
    '関数名：cmdMove_GotFocus
    '機　能：統合ﾎﾞﾀﾝﾌｫｰｶｽ取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 11:26:51 N.Kojima
    '更新日：2004/07/05 (Mon) 11:26:51
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)Tab
    Private Sub cmdMove_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMove.Enter

        Try

            '@統合ﾎﾞﾀﾝにﾌｫｰｶｽがあたった場合ｸﾞﾘｯﾄにﾊｲﾗｲﾄを残す
            vsfMoveSlotMap.HighLight = HighLightEnum.Always
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMove_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMove_LostFocus
    '機　能：統合ﾎﾞﾀﾝﾌｫｰｶｽ喪失処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 11:34:23 N.Kojima
    '更新日：2004/07/05 (Mon) 11:34:23
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)Tab
    Private Sub cmdMove_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMove.Leave

        Try

            '@統合ﾎﾞﾀﾝにﾌｫｰｶｽがあたった場合ｸﾞﾘｯﾄﾞにﾌｫｰｶｽがあるときのみﾊｲﾗｲﾄ表示
            vsfMoveSlotMap.HighLight = HighLightEnum.WithFocus

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMove_LostFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMoveCancel_GotFocus
    '機　能：統合ｷｬﾝｾﾙﾎﾞﾀﾝﾌｫｰｶｽ取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 11:26:51 N.Kojima
    '更新日：2004/07/05 (Mon) 11:26:51
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)Tab
    Private Sub cmdMoveCancel_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMoveCancel.Enter

        Try

            '@統合ﾎﾞﾀﾝにﾌｫｰｶｽがあたった場合ｸﾞﾘｯﾄにﾊｲﾗｲﾄを残す
            vsfMoveSlotMap2.HighLight = HighLightEnum.Always
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMoveCancel_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMoveCancel_LostFocus
    '機　能：統合ｷｬﾝｾﾙﾎﾞﾀﾝﾌｫｰｶｽ喪失処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 11:31:54 N.Kojima
    '更新日：2004/07/05 (Mon) 11:31:54
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)Tab
    Private Sub cmdMoveCancel_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMoveCancel.Leave

        Try

            '@統合ﾎﾞﾀﾝにﾌｫｰｶｽがあたった場合ｸﾞﾘｯﾄﾞにﾌｫｰｶｽがあるときのみﾊｲﾗｲﾄ表示
            vsfMoveSlotMap2.HighLight =  HighLightEnum.WithFocus
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMoveCancel_LostFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMoveSlotMap_DblClick
    '機　能：統合元ｽﾛｯﾄﾏｯﾌﾟﾀﾞﾌﾞﾙｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 13:20:35 N.Kojima
    '更新日：2004/07/05 (Mon) 13:20:35
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)Tab
    Private Sub vsfMoveSlotMap_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMoveSlotMap.DoubleClick

        Try
            
            '@統合処理
            Call cmdMove_Click(sender, New EventArgs())
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMoveSlotMap_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMoveSlotMap_MouseUp
    '機　能：統合元ｽﾛｯﾄﾏｯﾌﾟ ﾏｳｽｱｯﾌﾟ処理
    '引　数：Button：未使用
    '　　　：Shift：未使用
    '　　　：X：未使用
    '　　　：Y：未使用
    '戻り値：なし
    '作成日：2005/01/05 (Wed) 13:13:46 H.Wajima
    '更新日：2005/01/05 (Wed) 13:13:46
    '備　考：ｸﾘｯｸから処理を移動
    Private Sub vsfMoveSlotMap_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfMoveSlotMap.MouseUp

        Try
            
            '@統合元ｽﾛｯﾄﾏｯﾌﾟ選択処理
            Call prvvsfMoveSlotMapSelect_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMoveSlotMap_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：vsfMoveSlotMap2_DblClick
    '機　能：統合先ｽﾛｯﾄﾏｯﾌﾟﾀﾞﾌﾞﾙｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 13:20:35 N.Kojima
    '更新日：2004/07/05 (Mon) 13:20:35
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)Tab
    Private Sub vsfMoveSlotMap2_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMoveSlotMap2.DoubleClick

        Try
            
            '@統合ｷｬﾝｾﾙ処理
            Call cmdMoveCancel_Click(cmdMoveCancel, New EventArgs())
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMoveSlotMap2_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierMnt_Change
    '機　能：統合先ｷｬﾘｱID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 16:04:18 N.Kojima
    '更新日：2004/07/02 (Fri) 16:04:18
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)Tab
    Private Sub txtCarrierMnt_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierMnt.Change
        
        Try
            
            '@統合元ｽﾛｯﾄﾏｯﾌﾟ復元
            Call prvvsfMoveSlotMapCancel_Disp()
            
            '@統合先ｽﾛｯﾄﾏｯﾌﾟ初期化
            Call prvvsfMoveSlotMap_Init(vsfMoveSlotMap2)

            '@基板工程の場合は治具ID列は非表示にする
            If pstrSBID = CPstrSBID1A0 Then
                vsfMoveSlotMap2.Cols(CMlngvsfMoveSlotMapColJIGID).Visible = False
            End If

            '@ｷｬﾘｱ状態初期化
            mstrCarrierID3Status = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierMnt_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierMnt_Validate
    '機　能：ｷｬﾘｱID入力処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 15:35:10 N.Kojima
    '更新日：2005/11/28 (Mon) 13:11:35 N.Kasai
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合(統合先))Tab
    '　　　：2005/11/04 (Fri) 09:34:04 N.Kojima     FOUP(OPｶｾｯﾄ)⇔FOSBは交換可能にする。(ﾕｰｻﾞｰ要望№0104)
    '　　　：2005/11/28 (Mon) 13:11:35 N.Kasai      空ｷｬﾘｱﾁｪｯｸ追加
    Private Sub txtCarrierMnt_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierMnt.Validating
        
        Dim lblnAns             As Boolean              'ｷｬﾘｱ情報設定戻り値(True:正常,False:異常)
        Dim ltypWaferList       As Waferlist            'ｷｬﾘｱWF情報構造体
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrDiscID          As String               '識別ID
        Dim llngCnt             As Integer              'ｶｳﾝﾀ変数
        Dim ltypCarrCurstate    As CarrCurstate         'ｷｬﾘｱ状態確認要求構造体

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If

            'NSYS メンテナンスタブを切替時はValidate処理を行わない
            If mblnTabCarrierMntSelect Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDがない場合は抜ける
            If txtCarrierMnt.Text = vbNullString Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrierMnt.NowByte <> txtCarrierMnt.ChrMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@再入力
                If Me.ActiveControl.Name = tabCarrier.Name OrElse _
                    Me.ActiveControl.Name = tabCarrierMnt.Name Then
                    mblnTabSelectEnabled = False
                    sender.Focus()
                Else
                    e.Cancel = True
                End If
                Exit Sub
            End If
                
            '@ｷｬﾘｱIDの重複ﾁｪｯｸ
            If txtCarrierID2.Text = txtCarrierMnt.Text Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000C)
                '@"ﾒｯｾｰｼﾞｺｰﾄﾞ：C_W0C%0$$キャリアIDが重複しています。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@再入力
                If Me.ActiveControl.Name = tabCarrier.Name OrElse _
                    Me.ActiveControl.Name = tabCarrierMnt.Name Then
                    mblnTabSelectEnabled = False
                    sender.Focus()
                Else
                    e.Cancel = True
                End If
                Exit Sub
            End If
                
            '@ｷｬﾘｱIDの識別IDの取得
            lstrDiscID = Strings.Left(txtCarrierMnt.Text, CMlngDiscNum)
            
            '@識別IDの一致確認
            mstrtxtCarrierMntCarrType = vbNullString
            For llngCnt = 0 To mlngCarrTypListCntAll - 1
                '@識別IDが一致している場合
                If mtypCarrierMasterAll(llngCnt).strCarrierDiscID = lstrDiscID Then
                    '@ｷｬﾘｱﾀｲﾌﾟを設定
                    With mtypCarrierMasterAll(llngCnt)
                        mstrtxtCarrierMntCarrType = .strCarrierTypeID
                        
                        '@ｷｬﾘｱﾀｲﾌﾟﾌﾗｸﾞを退避(判定用)
                        mstrtxtCarrierMntTypeFlag = .strTypeFlag
                        
                    End With
                    
                    Exit For
                End If
            Next llngCnt
            
            '@ｷｬﾘｱﾀｲﾌﾟﾌﾗｸﾞで判定
            If mstrtxtCarrierID2TypeFlag <> mstrtxtCarrierMntTypeFlag Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003Y)
                '@"<TRM3YW>$$統合元キャリアIDとキャリアタイプが異なります。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@再入力
                If Me.ActiveControl.Name = tabCarrier.Name OrElse _
                    Me.ActiveControl.Name = tabCarrierMnt.Name Then
                    mblnTabSelectEnabled = False
                    sender.Focus()
                Else
                    e.Cancel = True
                End If
                Exit Sub
            End If
            
            If mstrtxtCarrierID2TypeFlag = "1" And mstrCarrierID2Status <> vbNullString Then
            
                If mstrtxtCarrierMntCarrType = CPstrCarrTypeFOSB Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003Y)
                    '@"<TRM3YW>$$統合元キャリアIDとキャリアタイプが異なります。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@再入力
                    If Me.ActiveControl.Name = tabCarrier.Name OrElse _
                        Me.ActiveControl.Name = tabCarrierMnt.Name Then
                        mblnTabSelectEnabled = False
                        sender.Focus()
                    Else
                        e.Cancel = True
                    End If
                    Exit Sub
                
                End If
                
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "txtCarrierMnt_Validate"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ｷｬﾘｱWF情報の取得
            lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                             txtCarrierMnt.Text, _
                                             CPstrCD3Y, _
                                             ltypWaferList, , _
                                             mstrSBID)
            '@結果判定
            If lblnAns = True Then
                
                '@WF枚数が0枚の場合空ｷｬﾘｱのﾁｪｯｸを行なう。
                If ltypWaferList.lngListCnt = 0 Then
                    '@ｷｬﾘｱ情報(要求)格納
                    With ltypCarrCurstate
                        .strCarrierId = txtCarrierMnt.Text      'ｷｬﾘｱID
                        .strClassDivision = CPstrCD3D           'WF移動
                        .strMsgVer = CMstrcarrcurstateVer       'MSGVER
                        .strSbID = mstrSBID                     '処理区分
                        .strCarrierTypeID = vbNullString        'ｷｬﾘｱﾀｲﾌﾟ(判断はできない)
                    End With
                    
                    '@ｷｬﾘｱ状態取得
                    lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, True)
                    '@結果判定
                    If lblnAns = False Then
                        '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                        If Me.ActiveControl.Name = tabCarrier.Name OrElse _
                            Me.ActiveControl.Name = tabCarrierMnt.Name Then
                            mblnTabSelectEnabled = False
                            sender.Focus()
                        Else
                            e.Cancel = True
                        End If
                        
                        '@ｽﾛｯﾄﾏｯﾌﾟ&移動ﾎﾞﾀﾝ使用不可
                        vsfMoveSlotMap.Enabled = False
                        cmdMove.Enabled = False
                        cmdMoveCancel.Enabled = False
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        Exit Sub
                    End If

                End If
                
                '@ｷｬﾘｱ状態を退避
                mstrCarrierID3Status = ltypWaferList.strState

                '@画面表示処理
                Call prvvsfMoveSlotMap2_Disp(ltypWaferList)

                '@ﾎﾞﾀﾝ活性化処理
                Call prvvsfMoveSlotMapSelect_Proc()
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                If Me.ActiveControl.Name = tabCarrier.Name OrElse _
                    Me.ActiveControl.Name = tabCarrierMnt.Name Then
                    mblnTabSelectEnabled = False
                    sender.Focus()
                Else
                    e.Cancel = True
                End If
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Sub
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierMnt_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMove_Click
    '機　能：WF統合処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 10:24:46 N.Kojima
    '更新日：2009/06/22 (Mon) 17:01:30 T.Oide
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)Tab
    '　　　：2005/12/01 (Thu) 15:30:40 N.Kasai      ｽﾛｯﾄ№の判定追加MAXｽﾛｯﾄｻｲｽﾞ考慮
    Private Sub cmdMove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMove.Click
        
        Dim lstrWFID1       As String   '統合元WFID
        Dim lstrWFID2       As String   '統合先WFID
        Dim llngCnt         As Integer  'ｶｳﾝﾄ
        Dim llngRow         As Integer  '選択行
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfMoveSlotMap
            
                '@選択された範囲分
                For llngCnt = 0 To .Rows.Selected.Count - 1
                
                    '@ﾊｲﾗｲﾄ取得
                    llngRow = .Rows.Selected(llngCnt).Index
                    
                    '@行が選択されている場合
                    If llngRow <> CMlngNoSelect Then
                        '@統合元WFID
                        lstrWFID1 = .GetData(llngRow, CMlngvsfMoveSlotMapColWFID)
                        '@統合先WFID
                        lstrWFID2 = vsfMoveSlotMap2.GetData(llngRow, CMlngvsfMoveSlotMapColWFID)
                        
                        '@統合元WFIDがある場合
                        If lstrWFID1 <> vbNullString Then
                            
                            '@ｽﾛｯﾄｻｲｽﾞを判定(MAXｽﾛｯﾄｻｲｽﾞ以上の№へ移動ﾀﾞﾒ)
                            If vsfMoveSlotMap2.GetData(llngRow, CMlngvsfMoveSlotMapColNo) <> vbNullString Then
                            
                                '@統合先WFIDがない場合
                                If lstrWFID2 = vbNullString Then
                                    vsfMoveSlotMap2.SetData(llngRow, CMlngvsfMoveSlotMapColWFID, lstrWFID1)       'WF_ID
                                    '@↓2020/02/07 (Fri) 17:22:26 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                    vsfMoveSlotMap2.SetData(llngRow, CMlngvsfMoveSlotMapColGRB, .GetData(llngRow, CMlngvsfMoveSlotMapColGRB))   'GRB
                                    '@↑2020/02/07 (Fri) 17:22:26 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                    vsfMoveSlotMap2.SetData(llngRow, CMlngvsfMoveSlotMapColJIGID, .GetData(llngRow, CMlngvsfMoveSlotMapColJIGID))   '治具ID
                                    vsfMoveSlotMap2.SetData(llngRow, CMlngvsfMoveSlotMapColWFStat, .GetData(llngRow, CMlngvsfMoveSlotMapColWFStat)) '状態
                                    vsfMoveSlotMap2.SetData(llngRow, CMlngvsfMoveSlotMapColBeforRow, llngRow)
                                    
                                    .SetData(llngRow, CMlngvsfMoveSlotMapColWFID, vbNullString)     '元WF_ID
                                    .SetData(llngRow, CMlngvsfMoveSlotMapColJIGID, vbNullString)    '元治具ID
                                    '@↓2020/02/21 (Fri) 14:24:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                    .SetData(llngRow, CMlngvsfMoveSlotMapColGRB, vbNullString)      'GRB 
                                    '@↑2020/02/21 (Fri) 14:24:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                End If
                            End If
                        End If
                    End If
                Next llngCnt
                
                '@統合元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfMoveSlotMap)
            
            End With

            '@ﾛｯｸ
            cmdMove.Enabled = False
            
            '@確定ﾎﾞﾀﾝ制御
            Call prvWFMove_Set()

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdMove_Click"          '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMoveCancel_Click
    '機　能：WF統合ｷｬﾝｾﾙ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 10:24:46 N.Kojima
    '更新日：2009/06/22 (Mon) 17:01:37 T.Oide
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)Tab
    Private Sub cmdMoveCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMoveCancel.Click
        
        Dim lstrWFID1       As String       '統合元WFID
        Dim lstrWFID2       As String       '統合先WFID
        Dim llngBackColor   As Color        'ﾊﾞｯｸｶﾗｰ
        Dim llngCnt         As Integer      'ｶｳﾝﾄ
        Dim llngRow         As Integer      '統合先選択行
        Dim llngRow2        As Integer      '統合元選択行
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfMoveSlotMap2
                '@選択された範囲分
                For llngCnt = 0 To .Rows.Selected.Count - 1
                    '@ﾊｲﾗｲﾄ取得
                    llngRow = .Rows.Selected(llngCnt).Index
                    
                    '@行が選択されている場合
                    If llngRow >= .Rows.Fixed Then
                        '@統合先WFID
                        lstrWFID2 = .GetData(llngRow, CMlngvsfMoveSlotMapColWFID)
                        '@統合元WFID
                        lstrWFID1 = vsfMoveSlotMap.GetData(llngRow, CMlngvsfMoveSlotMapColWFID)
                        '@統合先ﾊﾞｯｸｶﾗｰ
                        llngBackColor = .GetCellRange(llngRow, CMlngvsfMoveSlotMapColWFID).StyleDisplay.BackColor
                
                        '@統合先に統合元のWFIDがある場合
                        If lstrWFID2 <> vbNullString And llngBackColor <> ColorTranslator.FromWin32(CPlngGridGray) Then
                            '@移動前の行取得
                            llngRow2 = .GetData(llngRow, CMlngvsfMoveSlotMapColBeforRow)
                            
                            vsfMoveSlotMap.SetData(llngRow2, CMlngvsfMoveSlotMapColWFID, lstrWFID2)       'WF_ID
                            '@↓2020/02/07 (Fri) 17:23:59 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            vsfMoveSlotMap.SetData(llngRow2, CMlngvsfMoveSlotMapColGRB, .GetData(llngRow, CMlngvsfMoveSlotMapColGRB))   'GRB                               
                            '@↑2020/02/07 (Fri) 17:23:59 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            vsfMoveSlotMap.SetData(llngRow2, CMlngvsfMoveSlotMapColJIGID, .GetData(llngRow, CMlngvsfMoveSlotMapColJIGID))   '治具ID
                            vsfMoveSlotMap.SetData(llngRow2, CMlngvsfMoveSlotMapColWFStat, .GetData(llngRow, CMlngvsfMoveSlotMapColWFStat))
                            
                            .SetData(llngRow, CMlngvsfMoveSlotMapColWFID, vbNullString)
                            '@↓2020/02/07 (Fri) 17:24:48 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .SetData(llngRow, CMlngvsfMoveSlotMapColGRB, vbNullString)
                            '@↑2020/02/07 (Fri) 17:24:48 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .SetData(llngRow, CMlngvsfMoveSlotMapColJIGID, vbNullString)
                            .SetData(llngRow, CMlngvsfMoveSlotMapColWFStat, vbNullString)

                        End If
                    End If
                Next llngCnt
                
                '@統合先ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfMoveSlotMap2)
            End With
            
            '@ﾛｯｸ
            cmdMoveCancel.Enabled = False
            
            '@確定ﾎﾞﾀﾝ制御
            Call prvWFMove_Set()
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdMoveCancel_Click"    '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdCarrierSelect_Click
    '機　能：空ｷｬﾘｱ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/25 (Fri) 09:57:11 N.Kasai
    '更新日：2005/11/25 (Fri) 09:57:11
    '備　考：
    Private Sub cmdCarrierSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@交換先ｷｬﾘｱIDと同じｷｬﾘｱﾀｲﾌﾟを選択して表示
            pstrCarrierTypeID = mstrtxtCarrierID2CarrType
            
            '@ｷｬﾘｱの洗浄条件：使用後洗浄不要：要洗浄済
            pstrCleanCondition = CPstrCarrierClean2
            
            '@ｷｬﾘｱ管理からの起動区分を設定
            pblnfrmxxCM00C0Kbn = True
            '@空きｷｬﾘｱ一覧表示判定用ﾌﾗｸﾞを設定
            pstrTypeFlag = mstrtxtCarrierID2TypeFlag
            
            '@ﾛｯﾄ状態を退避
            pstrRelatedLotStatus = mstrCarrierID2Status
            
            '@空きｷｬﾘｱ一覧表示
            frmxxCM00K0.Instance = New frmxxCM00K0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00K0.Instance = Nothing
                Exit Sub
            End If
            
            '@ｷｬﾘｱ一覧表示
            frmxxCM00K0.Instance.ShowDialog(Me)
            frmxxCM00K0.Instance = Nothing
                 
            '@空きｷｬﾘｱが選択されている場合
            If pstrCarrierID <> vbNullString Then
                '@交換先ｷｬﾘｱIDをｾｯﾄ
                txtCarrierMnt.Text = pstrCarrierID
                '@ｷｬﾘｱ交換先ｷｬﾘｱID処理へ
                RemoveHandler txtCarrierMnt.Validating, AddressOf  txtCarrierMnt_Validate
                Call txtCarrierMnt_Validate(txtCarrierMnt, New CancelEventArgs(False))
                AddHandler txtCarrierMnt.Validating, AddressOf  txtCarrierMnt_Validate
            End If
            
            '@ｷｬﾘｱ管理からの起動区分を初期化
            pblnfrmxxCM00C0Kbn = False
            '@空きｷｬﾘｱ一覧表示判定用ﾌﾗｸﾞを初期化
            pstrTypeFlag = vbNullString
            pstrRelatedLotStatus = vbNullString
            
            '@交換先ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrierMnt)

            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｷｬﾘｱID

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdCarrierSelect_Click"     '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWFMove_Click
    '機　能：WF統合確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 13:44:12 N.Kojima
    '更新日：2004/07/05 (Mon) 13:44:12
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)Tab
    '　　　：2005/07/26 (Tue) 10:33:32 S.Deguchi    ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝTagの追加対応
    Private Sub cmdWFMove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWFMove.Click
        
        Dim lblnAns                 As Boolean          '戻り値
        Dim llngCnt                 As Integer          'ｶｳﾝﾄ
        Dim llngWFListCnt           As Integer          'WFﾘｽﾄｶｳﾝﾄ
        Dim llngWFCnt1              As Integer          'WFｶｳﾝﾄ1
        Dim llngWFCnt2              As Integer          'WFｶｳﾝﾄ2
        Dim ltypCarrMove            As CarrMove         'ｷｬﾘｱ統合構造体(要求)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnWFMoveInput_Chk()
            If lblnAns = False Then
                '@不正項目あり
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
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmdWFMove_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@統合元WF枚数退避
            llngWFCnt1 = prvblnSlotMap_Get(vsfMoveSlotMap)
            '@統合先WF枚数退避
            llngWFCnt2 = prvblnSlotMap_Get(vsfMoveSlotMap2)
            
            '@ﾛｯﾄ投入ﾃﾞｰﾀ作成
            With ltypCarrMove
                .strClassDivision = CPstrCD0B               '処理区分(ｷｬﾘｱ統合(OffLine))
                .strCarrierID1 = txtCarrierID2.Text         '統合元ｷｬﾘｱID
                .strCarrierID2 = txtCarrierMnt.Text         '統合先ｷｬﾘｱID
                .strEmpID = pstrUserID                      '作業者ｺｰﾄﾞ
                .strMessageName = tabCarrierMnt.Text        'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ
                .strOnlineFlag = CMlngoptOffline            'ｵﾝﾗｲﾝﾌﾗｸﾞ⇒0：ｵﾌﾗｲﾝ
                
                '@統合元WFがある場合
                If llngWFCnt1 > 0 Then
                    '@WFMap処理
                    'ReDim Preserve .typWFMapList1(llngWFCnt1)
                     .typWFMapList1 = New List(Of WFMapList)()

                    '@WFﾘｽﾄｶｳﾝﾄ
                    llngWFListCnt = 0
                    llngCnt = 0
                    '@統合元WF格納
                    For llngCnt = vsfMoveSlotMap.Rows.Fixed To vsfMoveSlotMap.Rows.Count - 1
                        '@空白以外の場合
                        If vsfMoveSlotMap.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                            Dim tmpWFMapList As WFMapList = New WFMapList()
                            tmpWFMapList.strSlotPosition = _
                                vsfMoveSlotMap.GetData(llngCnt, CMlngvsfMoveSlotMapColNo)          'ｽﾛｯﾄ№
                            tmpWFMapList.strWfId = _
                                vsfMoveSlotMap.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)        'WFID
                            tmpWFMapList.strjigId = _
                                vsfMoveSlotMap.GetData(llngCnt, CMlngvsfMoveSlotMapColJIGID)       '治具ID
                            
                            .typWFMapList1.Add(tmpWFMapList)
                            llngWFListCnt = llngWFListCnt + 1
                        End If
                    Next llngCnt
                End If
                
                '@統合先WFがある場合
                If llngWFCnt2 > 0 Then
                    '@WFMap処理
                    'ReDim Preserve .typWFMapList2(llngWFCnt2)
                     .typWFMapList2 = New List(Of WFMapList)()

                    '@WFﾘｽﾄｶｳﾝﾄ
                    llngWFListCnt = 0
                    llngCnt = 0
                    '@統合先WF格納
                    For llngCnt = vsfMoveSlotMap2.Rows.Fixed To vsfMoveSlotMap2.Rows.Count - 1
                        '@空白以外の場合
                        If vsfMoveSlotMap2.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                            Dim tmpWFMapList As WFMapList = New WFMapList()
                            tmpWFMapList.strSlotPosition = _
                                vsfMoveSlotMap2.GetData(llngCnt, CMlngvsfMoveSlotMapColNo)         'ｽﾛｯﾄ№
                                
                            tmpWFMapList.strWfId = _
                                vsfMoveSlotMap2.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)       'WFID

                            .typWFMapList2.Add(tmpWFMapList)
                            llngWFListCnt = llngWFListCnt + 1
                        End If
                    Next llngCnt
                End If
                
                '@ﾒｯｾｰｼﾞ送信処理呼び出し
                lblnAns = pubblnCarrMove_Upd(CMstrcarrmove____Ver, ltypCarrMove, llngWFCnt1, llngWFCnt2)
                '@結果判定
                If lblnAns = True Then
                    '@画面の初期化
                    Call prvCarrierTabMnt0_Init(True)
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000D, .strCarrierID1, .strCarrierID2)
                    '@成功ﾒｯｾｰｼﾞｽﾃｰﾀｽﾊﾞｰ表示
                    '@"<TRM0DI>$$WF移動しました。移動元キャリア[%1] 移動先キャリア[%2]"
                    Call pubVsfInfo_Disp(pstrDMsg)
                                                       
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                    '@在庫管理から呼ばれている場合
                    If txtCarrierID2.Locked = True Then
                        '@ﾌｫｰﾑを閉じる終了
                        Me.Close()
                        Exit Sub
                    End If
                    
                    '@ｷｬﾘｱID(ｷｬﾘｱﾒﾝﾃﾅﾝｽ)にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrierID2)
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
                .strProcName = "cmdWFMove_Click"        '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfMoveSlotMap2_MouseUp
    '機　能：統合先ｽﾛｯﾄﾏｯﾌﾟﾏｳｽｱｯﾌﾟ処理
    '引　数：Button：未使用
    '　　　：Shift：未使用
    '　　　：X：未使用
    '　　　：Y：未使用
    '戻り値：なし
    '作成日：2005/01/05 (Wed) 13:16:56 H.Wajima
    '更新日：2005/01/05 (Wed) 13:16:56
    '備　考：
    Private Sub vsfMoveSlotMap2_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfMoveSlotMap2.MouseUp
        
        Try
            
            '@統合先ｽﾛｯﾄﾏｯﾌﾟ選択処理
            Call prvvsfMoveSlotMap2Select_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMoveSlotMap2_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '====================================ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｽﾛｯﾄ情報変更)Tab====================================
    '関数名：vsfMoveSlotMap3_DblClick
    '機　能：変更前ｽﾛｯﾄﾏｯﾌﾟﾀﾞﾌﾞﾙｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 17:10:23 N.Kojima
    '更新日：2004/07/06 (Tue) 17:10:23
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｽﾛｯﾄ情報変更)Tab
    Private Sub vsfMoveSlotMap3_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMoveSlotMap3.DoubleClick
        
        Try
            '@変更処理
            Call cmdMove2_Click(cmdMove2, New EventArgs())
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMoveSlotMap3_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMoveSlotMap3_MouseUp
    '機　能：ｽﾛｯﾄ情報変更前ｽﾛｯﾄﾏｯﾌﾟ ﾏｳｽｱｯﾌﾟ処理
    '引　数：Button：未使用
    '　　　：Shift：未使用
    '　　　：X：未使用
    '　　　：Y：未使用
    '戻り値：なし
    '作成日：2005/01/05 (Wed) 13:19:55 H.Wajima
    '更新日：2005/01/05 (Wed) 13:19:55
    '備　考：ｸﾘｯｸから処理を移動
    Private Sub vsfMoveSlotMap3_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfMoveSlotMap3.MouseUp
        
        Dim lstrWFID1       As String   '変更前WFID
        Dim lstrWFID2       As String   '変更後WFID
        Dim llngRowTop      As Integer  '選択最上段行
        Dim llngRowBottom   As Integer  '選択最下段行
        Dim llngCnt         As Integer  'ｶｳﾝﾄ

        Try
            
            '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ
            cmdMoveCancel2.Enabled = False
            
            With vsfMoveSlotMap3
                If .Rows.Selected.Count < 1 Then
                    '選択行なし
                    Exit Sub
                End If
                '@選択最上段行を格納
                llngRowTop = .Rows.Selected(CMlngvsfGridTitleRow).Index
                '@選択最下段行を格納
                llngRowBottom = llngRowTop + .Rows.Selected.Count - 1
                
                '@選択された範囲分
                For llngCnt = llngRowBottom To llngRowTop Step -1
                    '@ﾃﾞｰﾀ行の場合
                    If .Rows.Fixed <= .Rows.Count Then
                        '@変更前WFID
                        lstrWFID1 = .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                        '@変更後WFID
                        lstrWFID2 = vsfMoveSlotMap4.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                        
                        '@変更前WFIDがある場合
                        If lstrWFID1 <> vbNullString Then
                            '@変更後WFIDがない場合
                             If lstrWFID2 = vbNullString Then
                                '@ｽﾛｯﾄ情報変更ﾎﾞﾀﾝﾛｯｸ解除
                                cmdMove2.Enabled = True
                                '@確定ﾎﾞﾀﾝ制御
                                Call prvWFMove2_Set()
                                Exit Sub
                             End If
                        End If
                    End If
                Next llngCnt
            End With
            
            '@ｽﾛｯﾄ情報変更ﾎﾞﾀﾝﾛｯｸ
            cmdMove2.Enabled = False
            
            '@確定ﾎﾞﾀﾝ制御
            Call prvWFMove2_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMoveSlotMap3_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：vsfMoveSlotMap4_AfterEdit
    '機　能：治具IDの使用可否チェックを行う
    '引　数：Row：
    '　　　：Col：
    '戻り値：
    '作成日：2009/06/25 (Thu) 16:15:46 T.Oide
    '更新日：2009/06/25 (Thu) 16:15:46
    '備　考：
    Private Sub vsfMoveSlotMap4_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfMoveSlotMap4.AfterEdit
        
        Dim ltypJigChk          As JigCheck         '治具使用可否判定確認Msg
        Dim lstrGuideMsgCode    As String           '返信ﾒｯｾｰｼﾞｺｰﾄﾞ
        Dim lstrGuideMsg        As String           '返信ﾒｯｾｰｼﾞ
        Dim lblnAns2            As Boolean          '結果
        Dim lstrDispGuidMsg     As String           '表示ﾒｯｾｰｼﾞ
        
        
        Try
            
            '@治具IDが変わっていない場合はﾁｪｯｸしない
            If vsfMoveSlotMap4.GetData(e.Row, CMlngvsfMoveSlotMapColJIGID) = _
               vsfMoveSlotMap4.GetData(e.Row, CMlngvsfMoveSlotMapColBeforJIG) Then
            
                Exit Sub
            End If
            
            
            '@使用する治具のﾏｽﾀｰﾁｪｯｸ(ﾏｽﾀｰに登録済みか使用可能か、適切な治具かをﾁｪｯｸ)
            ltypJigChk.strSbID = pstrSBID
            ltypJigChk.strjigId = vsfMoveSlotMap4.GetData(e.Row, e.Col)
            ltypJigChk.strLotID = mstrLotId
            ltypJigChk.strOpID = mstrOpID
            ltypJigChk.strStepID = mstrStepID
            ltypJigChk.strScreenSizeID = vbNullString
            
            If mblnCfFlag = "1" Then
            
                lblnAns2 = pubblnJycJigUse_Check(CPstrCD4I, CMstrjig_usechkVer, ltypJigChk, _
                                                lstrGuideMsgCode, lstrGuideMsg)
            Else
                lblnAns2 = pubblnJycJigUse_Check(CPstrCD4H, CMstrjig_usechkVer, ltypJigChk, _
                                                lstrGuideMsgCode, lstrGuideMsg)
            End If
            
            If lblnAns2 = True Then
                If lstrGuideMsg <> vbNullString Then
                    
                    '@ﾒｯｾｰｼﾞがあった場合は、ｴﾗｰMsgを表示
                    lstrDispGuidMsg = CPstrStartMsgCode & lstrGuideMsgCode & CPstrEndMsgCode & "$$" & lstrGuideMsg
                    pstrDMsg = pubstrMsgReplace_Set(lstrDispGuidMsg)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN02C0.Instance.Text, True, 16)
                        
                    '元の治具IDにﾌｫｰｶｽを戻す
                    SendKeys.Send(CPstrSendKeysPulasTab)
                    
                    '変更した治具IDを元に戻す
                    vsfMoveSlotMap4.SetData(e.Row, CMlngvsfMoveSlotMapColJIGID, _
                        vsfMoveSlotMap4.GetData(e.Row, CMlngvsfMoveSlotMapColBeforJIG))
                    
                    Exit Sub
                End If
            Else
                '元の治具IDにﾌｫｰｶｽを戻す
                SendKeys.Send(CPstrSendKeysPulasTab)
                
                '変更した治具IDを元に戻す
                vsfMoveSlotMap4.SetData(e.Row, CMlngvsfMoveSlotMapColJIGID, _
                    vsfMoveSlotMap4.GetData(e.Row, CMlngvsfMoveSlotMapColBeforJIG))
            End If
            
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMoveSlotMap4_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMoveSlotMap4_MouseDown
    '機　能：治具IDがNULLで無い場合ｸﾞﾘｯﾄﾞの変更を有効にする
    '引　数：Button：
    '　　　：Shift：
    '　　　：X：
    '　　　：Y：
    '戻り値：
    '作成日：2009/06/23 (Tue) 20:31:01 T.Oide
    '更新日：2009/06/23 (Tue) 20:31:01
    '備　考：
    Private Sub vsfMoveSlotMap4_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfMoveSlotMap4.MouseDown

        Try
            
            '@変更ｶﾗﾑが治具IDで治具IDがNULLで無い場合ｸﾞﾘｯﾄﾞの変更を有効にする
            
            If vsfMoveSlotMap4.Col = CMlngvsfMoveSlotMapColJIGID And _
                vsfMoveSlotMap4.GetData(vsfMoveSlotMap4.Row, CMlngvsfMoveSlotMapColJIGID) <> vbNullString Then
                '@ｸﾞﾘｯﾄﾞの変更を可にする
                vsfMoveSlotMap4.Styles.Editor.ForeColor = SystemColors.WindowText
                vsfMoveSlotMap4.Styles.Editor.BackColor = SystemColors.Window
                vsfMoveSlotMap4.AllowEditing = True
            Else
                '@ｸﾞﾘｯﾄﾞの変更を不可にする
                vsfMoveSlotMap4.AllowEditing = False
            End If
            
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMoveSlotMap4_MouseDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdLower_Click
    '機　能：下詰処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 18:46:25 N.Kojima
    '更新日：2009/12/08 (Tue) 15:07:45 T.Oide
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｽﾛｯﾄ情報変更)Tab
    Private Sub cmdLower_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLower.Click
        
        Dim llngCnt     As Integer  'ｶｳﾝﾄ
        Dim llngRow1    As Integer  '空き行番号
        Dim llngRow2    As Integer  '現在の行番号
        Dim lstrWFID    As String   'WFID

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfMoveSlotMap4
            
                '@行番号初期化
                llngRow1 = .Rows.Count - 1
                llngRow2 = llngRow1
                
                '@全行分
                For llngCnt = .Rows.Count - 1 To .Rows.Fixed Step -1
                    '@WFID
                    lstrWFID = .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                    
                    '@WFIDがない場合
                    If lstrWFID = vbNullString Then
                        llngRow2 = llngCnt
                        '@前回の空き行番号にWFIDがない場合
                        If .GetData(llngRow1, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                            '@空き行番号に現在の行番号を格納
                            llngRow1 = llngRow2
                        End If
                    Else
                        '@空き番号と現在の行番号が異なっている場合
                        If llngRow1 <> llngCnt Then
                        
                            '@空き行に現在のWFを入れる
                            .SetData(llngRow1, CMlngvsfMoveSlotMapColWFID, .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID))
                            '@↓2020/02/10 (Mon) 13:30:59 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .SetData(llngRow1, CMlngvsfMoveSlotMapColGRB, .GetData(llngCnt, CMlngvsfMoveSlotMapColGRB))
                            '@↑2020/02/10 (Mon) 13:30:59 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .SetData(llngRow1, CMlngvsfMoveSlotMapColJIGID, .GetData(llngCnt, CMlngvsfMoveSlotMapColJIGID))
                            .SetData(llngRow1, CMlngvsfMoveSlotMapColWFStat, .GetData(llngCnt, CMlngvsfMoveSlotMapColWFStat))
                            .SetData(llngRow1, CMlngvsfMoveSlotMapColBeforRow, .GetData(llngCnt, CMlngvsfMoveSlotMapColBeforRow))
                            .SetData(llngRow1, CMlngvsfMoveSlotMapColBeforJIG, .GetData(llngCnt, CMlngvsfMoveSlotMapColBeforJIG))

                            '@現在の行をｸﾘｱ
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColWFID, vbNullString)
                            '@↓2020/02/10 (Mon) 13:31:28 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColGRB, vbNullString)
                            '@↑2020/02/10 (Mon) 13:31:28 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColJIGID, vbNullString)
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColWFStat, vbNullString)
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColBeforRow, vbNullString)
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColBeforJIG, vbNullString)

                        End If
                        llngRow1 = llngRow1 - 1
                    End If
                    
                Next llngCnt
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLower_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUpper_Click
    '機　能：上詰処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 18:21:06 N.Kojima
    '更新日：2009/12/08 (Tue) 15:08:57 T.Oide
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｽﾛｯﾄ情報変更)Tab
    Private Sub cmdUpper_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpper.Click
        
        Dim llngCnt     As Integer  'ｶｳﾝﾄ
        Dim llngRow1    As Integer  '空き行番号
        Dim llngRow2    As Integer  '現在の行番号
        Dim lstrWFID    As String   'WFID

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfMoveSlotMap4
                '@行番号初期化
                llngRow1 = .Rows.Count - mstrSlotSize
                llngRow2 = llngRow1
                
                '@全行分
                For llngCnt = .Rows.Count - mstrSlotSize To .Rows.Count - 1
                    '@WFID
                    lstrWFID = .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                    
                    '@WFIDがない場合
                    If lstrWFID = vbNullString Then
                        llngRow2 = llngCnt
                        '@前回の空き行番号にWFIDがない場合
                        If .GetData(llngRow1, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                            '@空き行番号に現在の行番号を格納
                            llngRow1 = llngRow2
                        End If
                    Else
                        '@空き番号と現在の行番号が異なっている場合
                        If llngRow1 <> llngCnt Then
                        
                            '@空き行に現在のWFを入れる
                            .SetData(llngRow1, CMlngvsfMoveSlotMapColWFID, .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID))
                            '@↓2020/02/10 (Mon) 13:31:43 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .SetData(llngRow1, CMlngvsfMoveSlotMapColGRB, .GetData(llngCnt, CMlngvsfMoveSlotMapColGRB))
                            '@↑2020/02/10 (Mon) 13:31:43 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .SetData(llngRow1, CMlngvsfMoveSlotMapColJIGID, .GetData(llngCnt, CMlngvsfMoveSlotMapColJIGID))
                            .SetData(llngRow1, CMlngvsfMoveSlotMapColWFStat, .GetData(llngCnt, CMlngvsfMoveSlotMapColWFStat))
                            .SetData(llngRow1, CMlngvsfMoveSlotMapColBeforRow, .GetData(llngCnt, CMlngvsfMoveSlotMapColBeforRow))
                            .SetData(llngRow1, CMlngvsfMoveSlotMapColBeforJIG, .GetData(llngCnt, CMlngvsfMoveSlotMapColBeforJIG))
                            '@現在の行をｸﾘｱ
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColWFID, vbNullString)
                            '@↓2020/02/10 (Mon) 13:32:02 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColGRB, vbNullString)
                            '@↑2020/02/10 (Mon) 13:32:02 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColJIGID, vbNullString)
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColWFStat, vbNullString)
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColBeforRow, vbNullString)
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColBeforJIG, vbNullString)
                            
                        End If
                        llngRow1 = llngRow1 + 1
                    End If
                Next llngCnt
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUpper_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMove2_Click
    '機　能：ｽﾛｯﾄ情報WF移動ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 10:24:46 N.Kojima
    '更新日：2009/06/22 (Mon) 16:36:29 T.Oide
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｽﾛｯﾄ情報変更)Tab
    Private Sub cmdMove2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMove2.Click
        
        Dim lstrWFID1       As String   '変更前WFID
        Dim lstrWFID2       As String   '変更後WFID
        Dim llngCnt         As Integer  'ｶｳﾝﾄ
        Dim llngRow         As Integer  '選択行
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfMoveSlotMap3
                '@選択された範囲分
                For llngCnt = 0 To .Rows.Selected.Count - 1
                    '@ﾊｲﾗｲﾄ取得
                    llngRow = .Rows.Selected(llngCnt).Index
                    
                    '@行が選択されている場合
                    If llngRow <> CMlngNoSelect Then
                        '@変更前WFID
                        lstrWFID1 = .GetData(llngRow, CMlngvsfMoveSlotMapColWFID)
                        '@変更後WFID
                        lstrWFID2 = vsfMoveSlotMap4.GetData(llngRow, CMlngvsfMoveSlotMapColWFID)
                        
                        
                        '@変更前WFIDがある場合
                        If lstrWFID1 <> vbNullString Then
                            '@変更後WFIDがない場合
                             If lstrWFID2 = vbNullString Then
                                vsfMoveSlotMap4.SetData(llngRow, CMlngvsfMoveSlotMapColWFID, lstrWFID1)                                             'WF_ID
                                '@↓2020/02/10 (Mon) 13:32:30 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                vsfMoveSlotMap4.SetData(llngRow, CMlngvsfMoveSlotMapColGRB, .GetData(llngRow, CMlngvsfMoveSlotMapColGRB))           'GRB
                                '@↑2020/02/10 (Mon) 13:32:30 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                vsfMoveSlotMap4.SetData(llngRow, CMlngvsfMoveSlotMapColJIGID, .GetData(llngRow, CMlngvsfMoveSlotMapColJIGID))       '治具ID
                                vsfMoveSlotMap4.SetData(llngRow, CMlngvsfMoveSlotMapColBeforJIG, .GetData(llngRow, CMlngvsfMoveSlotMapColJIGID))    '変更前の治具ID
                                vsfMoveSlotMap4.SetData(llngRow, CMlngvsfMoveSlotMapColWFStat, .GetData(llngRow, CMlngvsfMoveSlotMapColWFStat))     '状態
                                vsfMoveSlotMap4.SetData(llngRow, CMlngvsfMoveSlotMapColBeforRow, llngRow)       '変更前のRow
                                .SetData(llngRow, CMlngvsfMoveSlotMapColWFID, vbNullString)     'WF_IDを空にする
                                '@↓2020/02/10 (Mon) 13:33:51 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                .SetData(llngRow, CMlngvsfMoveSlotMapColGRB, vbNullString)      'GRBを空にする
                                '@↑2020/02/10 (Mon) 13:33:51 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                .SetData(llngRow, CMlngvsfMoveSlotMapColJIGID, vbNullString)    '治具IDを空にする
                                .SetData(llngRow, CMlngvsfMoveSlotMapColWFStat, vbNullString)   '状態を空にする
                             End If
                        End If
                    End If
                Next llngCnt
                
                '@変更前ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfMoveSlotMap3)
            End With

            '@ﾛｯｸ
            cmdMove2.Enabled = False
            
            '@確定ﾎﾞﾀﾝ制御
            Call prvWFMove2_Set()

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdMove2_Click"         '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMoveCancel2_Click
    '機　能：ｽﾛｯﾄ情報WF移動ｷｬﾝｾﾙﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 15:48:38 N.Kojima
    '更新日：2009/06/22 (Mon) 16:42:07 T.Oide
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｽﾛｯﾄ情報変更)Tab
    Private Sub cmdMoveCancel2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMoveCancel2.Click
        
        Dim lstrWFID        As String   'WFID
        Dim llngCnt         As Integer  'ｶｳﾝﾄ
        Dim llngRow         As Integer  '統合先選択行
        Dim llngRow2        As Integer  '統合元選択行

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfMoveSlotMap4
                '@選択された範囲分
                For llngCnt = 0 To .Rows.Selected.Count - 1
                    '@ﾊｲﾗｲﾄ取得
                    llngRow = .Rows.Selected(llngCnt).Index
                    
                    '@行が選択されている場合
                    If llngRow <> CMlngNoSelect Then
                        '@変更前ｽﾛｯﾄﾏｯﾌﾟのﾃﾞｰﾀ行の場合
                        If .Rows.Fixed <= llngRow Then
                            '@変更後WFID
                            lstrWFID = .GetData(llngRow, CMlngvsfMoveSlotMapColWFID)
                            
                            '@変更後WFIDがある場合
                            If lstrWFID <> vbNullString Then
                                llngRow2 = .GetData(llngRow, CMlngvsfMoveSlotMapColBeforRow)
                                vsfMoveSlotMap3.SetData(llngRow2, CMlngvsfMoveSlotMapColWFID, lstrWFID)       'WF_ID
                                '@↓2020/02/10 (Mon) 13:34:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                vsfMoveSlotMap3.SetData(llngRow2, CMlngvsfMoveSlotMapColGRB, .GetData(llngRow, CMlngvsfMoveSlotMapColGRB))          'GRB
                                '@↑2020/02/10 (Mon) 13:34:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                vsfMoveSlotMap3.SetData(llngRow2, CMlngvsfMoveSlotMapColWFStat, .GetData(llngRow, CMlngvsfMoveSlotMapColWFStat))    '状態
                                vsfMoveSlotMap3.SetData(llngRow2, CMlngvsfMoveSlotMapColJIGID, .GetData(llngRow, CMlngvsfMoveSlotMapColBeforJIG))   '変更前の治具IDを戻す
                                
                                '@変更後の表示を消す
                                .SetData(llngRow, CMlngvsfMoveSlotMapColWFID, vbNullString)
                                '@↓2020/02/10 (Mon) 13:34:26 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                .SetData(llngRow, CMlngvsfMoveSlotMapColGRB, vbNullString)
                                '@↑2020/02/10 (Mon) 13:34:26 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                .SetData(llngRow, CMlngvsfMoveSlotMapColJIGID, vbNullString)
                                .SetData(llngRow, CMlngvsfMoveSlotMapColWFStat, vbNullString)
                                .SetData(llngRow, CMlngvsfMoveSlotMapColBeforRow, vbNullString)
                                .SetData(llngRow, CMlngvsfMoveSlotMapColBeforJIG, vbNullString)
                            End If
                        End If
                    End If
                Next llngCnt
                '@変更後ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfMoveSlotMap4)
                '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ
                cmdMoveCancel2.Enabled = False
            End With
            
            '@確定ﾎﾞﾀﾝ制御
            Call prvWFMove2_Set()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMoveCancel2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWFMove2_Click
    '機　能：ｽﾛｯﾄ情報変更確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 18:06:31 N.Kojima
    '更新日：2009/06/23 (Tue) 13:29:24 T.Oide
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｽﾛｯﾄ情報変更)Tab
    '　　　：2005/07/26 (Tue) 10:33:32 S.Deguchi    ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝTagの追加対応
    Private Sub cmdWFMove2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWFMove2.Click
        
        Dim lblnAns                 As Boolean          '戻り値
        Dim llngCnt                 As Integer          'ｶｳﾝﾄ
        Dim llngWFListCnt           As Integer          'WFﾘｽﾄｶｳﾝﾄ
        Dim llngWFCnt1              As Integer          'WFｶｳﾝﾄ1
        Dim llngWFCnt2              As Integer          'WFｶｳﾝﾄ2
        Dim ltypCarrMove            As CarrMove         'ｷｬﾘｱ統合構造体(要求)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnWFMove2Input_Chk()
            If lblnAns = False Then
                '@不正項目あり
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
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmdWFMove2_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@WF枚数(変更後ｽﾛｯﾄﾏｯﾌﾟ)
            llngWFCnt1 = prvblnSlotMap_Get(vsfMoveSlotMap4)
            '@WF枚数
            llngWFCnt2 = 1
            
            '@ｷｬﾘｱ統合ﾃﾞｰﾀ作成
            With ltypCarrMove
                .strClassDivision = CPstrCD0D               '処理区分(ｽﾛｯﾄ変更)
                .strCarrierID1 = txtCarrierID2.Text         'ｷｬﾘｱID
                .strCarrierID2 = vbNullString               'なし
                .strEmpID = pstrUserID                      '作業者ｺｰﾄﾞ
                .strMessageName = tabCarrierMnt.Text        'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ
                .strOnlineFlag = CMlngoptOffline            'ｵﾝﾗｲﾝﾌﾗｸﾞ⇒0：ｵﾌﾗｲﾝ
                
                '@WFがある場合
                If llngWFCnt1 > 0 Then
                    '@WFMap処理
                    .typWFMapList1 = New List(Of WFMapList)()

                    '@WFﾘｽﾄｶｳﾝﾄ
                    llngWFListCnt = 0
                    llngCnt = 0
                    '@統合元WF格納
                    For llngCnt = vsfMoveSlotMap4.Rows.Fixed To vsfMoveSlotMap.Rows.Count - 1
                        '@空白以外の場合
                        If vsfMoveSlotMap4.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                            Dim tmpWFMapList As WFMapList = New WFMapList()
                            tmpWFMapList.strSlotPosition = _
                                vsfMoveSlotMap4.GetData(llngCnt, CMlngvsfMoveSlotMapColNo)             'ｽﾛｯﾄ№
                            tmpWFMapList.strWfId = _
                                vsfMoveSlotMap4.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)           'WFID
                            tmpWFMapList.strjigId = _
                                vsfMoveSlotMap4.GetData(llngCnt, CMlngvsfMoveSlotMapColJIGID)          '治具ID
                            
                            .typWFMapList1.Add(tmpWFMapList)
                            llngWFListCnt = llngWFListCnt + 1
                        End If
                    Next llngCnt
                End If
                
                '@WFMap処理
                .typWFMapList2 = New List(Of WFMapList)()
                Dim tmpWFMapList2 As WFMapList = New WFMapList()
                tmpWFMapList2.strSlotPosition = vbNullString            'ｽﾛｯﾄ№
                tmpWFMapList2.strWfId = vbNullString                    'WFID
                tmpWFMapList2.strjigId = vbNullString                   '治具ID
                .typWFMapList2.Add(tmpWFMapList2)
                       
                '@ﾒｯｾｰｼﾞ送信処理呼び出し
                lblnAns = pubblnCarrMove_Upd(CMstrcarrmove____Ver, ltypCarrMove, llngWFCnt1, llngWFCnt2)
                '@結果判定
                If lblnAns = True Then
                    '@画面の初期化
                    Call prvCarrierTabMnt0_Init(True)
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000E, .strCarrierID1)
                    '@成功ﾒｯｾｰｼﾞｽﾃｰﾀｽﾊﾞｰ表示
                    '@pubVsfInfo_Disp("ﾒｯｾｰｼﾞｺｰﾄﾞ：C_I0E%0$$スロット情報を変更しました。キャリア[ %1 ]")
                    Call pubVsfInfo_Disp(pstrDMsg)
                                                       
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                    '@在庫管理から呼ばれている場合
                    If txtCarrierID2.Locked = True Then
                        '@ﾌｫｰﾑを閉じる終了
                        Me.Close()
                        Exit Sub
                    End If
                    
                    '@ｷｬﾘｱID(ｷｬﾘｱﾒﾝﾃﾅﾝｽ)にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrierID2)
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
                .strProcName = "cmdWFMove2_Click"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtCarrierComments_Change
    '機　能：ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/27 (Mon) 16:37:06 N.Kojima
    '更新日：2006/02/27 (Mon) 16:37:06
    '備　考：
    Private Sub txtCarrierComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierComments.Change

        Dim llngNowByte     As Integer  'ｺﾒﾝﾄ桁数

        Try
               
            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtCarrierComments.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblCarrierLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CMlngMaxLen)

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtCarrierComments, CMlngCarrierCommentMaxDispRow, cmdUP, cmdDown)
            
            With vsfCarrierList
                '@ﾃﾞｰﾀ行の場合
                If .Rows.Fixed <= .Row Then
                    '@ｺﾒﾝﾄを一覧に反映
                    .SetData(.Row, CMlngvsfCarrierListColComments, txtCarrierComments.Text)
                    
                    '@変更候補か
                    If .GetCellRange(.Row, CMlngvsfCarrierListColComments).StyleDisplay.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue) Then
                        '@使用ｶﾃｺﾞﾘ/ｺﾒﾝﾄ変更ﾎﾞﾀﾝを有効に
                        cmdUpdate.Enabled = True
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierComments_KeyPress
    '機　能：キャリアコメントキー押下時処理
    '引　数：sender：イベント発生源のオブジェクト
    '        e     ：イベント情報
    '戻り値：なし
    '作成日：2020/03/06 (Fri) NSYS
    '更新日：
    '備　考：
    Private Sub txtCarrierComments_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtCarrierComments.KeyPress
        Try

            'Enterの入力をｷｬﾝｾﾙ
            If e.KeyChar = Chr(Keys.Enter) Then
                e.Handled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierComments_KeyPress"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：txtCarrierComments_KeyUp
    '機　能：ｺﾒﾝﾄﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2006/02/27 (Mon) 16:40:29 N.Kojima
    '更新日：2006/02/27 (Mon) 16:40:29
    '備　考：
    Private Sub txtCarrierComments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCarrierComments.KeyUp
        
        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtCarrierComments, CMlngCarrierCommentMaxDispRow, cmdUP, cmdDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierComments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierComments_MouseUp
    '機　能：ｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2006/02/27 (Mon) 16:41:08 N.Kojima
    '更新日：2006/02/27 (Mon) 16:41:08
    '備　考：
    Private Sub txtCarrierComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtCarrierComments.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtCarrierComments, CMlngCarrierCommentMaxDispRow, cmdUP, cmdDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtCarrierComments_Validate
    '機　能：ｺﾒﾝﾄﾃｷｽﾄValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/02/27 (Mon) 16:48:41 N.Kojima
    '更新日：2006/02/27 (Mon) 16:48:41
    '備　考：
    Private Sub txtCarrierComments_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierComments.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If
            
            With vsfCarrierList
                '@ﾃﾞｰﾀ行の場合
                If .Rows.Fixed <= .Row Then
                    '@元の文と現在の文を比較する
                    If Trim(mstrTextComments) <> Trim(txtCarrierComments.Text) Then
                        '@変更されている場合は、ﾊﾞｯｸｶﾗｰを水色にし、ｺﾒﾝﾄを一覧にも反映
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                        newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)
                        Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfCarrierListColComments)
                        cellRange.Style = newStyle
                        .SetData(.Row, CMlngvsfCarrierListColComments, txtCarrierComments.Text)
                        
                        '@使用ｶﾃｺﾞﾘ/ｺﾒﾝﾄ変更ﾎﾞﾀﾝを有効に
                        cmdUpdate.Enabled = True
                        
                        '@編集中ﾌﾗｸﾞをTrueにする
                        mblnEditFlag = True
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierComments_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：ｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/27 (Mon) 16:34:51 N.Kojima
    '更新日：2006/02/27 (Mon) 16:34:51
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
            Call pubtxtCmdUp_Proc(txtCarrierComments, CMlngCarrierCommentMaxDispRow, cmdUP, cmdDown)

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

    '関数名：cmdDown_Click
    '機　能：ｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/27 (Mon) 16:33:05 N.Kojima
    '更新日：2006/02/27 (Mon) 16:33:05
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
            Call pubtxtCmdDown_Proc(txtCarrierComments, CMlngCarrierCommentMaxDispRow, cmdUP, cmdDown)

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

    '====================================ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF廃棄)Tab====================================
    '関数名：txtComment_Change
    '機　能：ｺﾒﾝﾄのChange処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/15 (Sat) 11:08:07 Y.Yamagishi
    '更新日：2005/11/21 (Mon) 15:21:52 N.Kasai
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF廃棄)Tab
    '　　　：2005/11/21 (Mon) 15:21:52 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub txtComment_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComment.Change

        Dim llngNowByte As Integer 'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtComment.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComment, CMlngWFCommentMaxDispRow, cmdCommentUp, cmdCommentDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComment_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComment_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/21 (Mon) 15:23:37 N.Kasai
    '更新日：2005/11/21 (Mon) 15:23:37
    '備　考：
    Private Sub txtComment_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComment.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComment, CMlngWFCommentMaxDispRow, cmdCommentUp, cmdCommentDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComment_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComment_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：ｘ座標
    '　　　：Y：ｙ座標
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 08:41:50 N.Kasai
    '更新日：2005/11/22 (Tue) 08:41:50
    '備　考：
    Private Sub txtComment_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtComment.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComment, CMlngWFCommentMaxDispRow, cmdCommentUp, cmdCommentDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComment_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfMoveSlotMap5_Click
    '機　能：WF廃棄ｽﾛｯﾄﾏｯﾌﾟｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/18 (Fri) 14:45:50 N.Kasai
    '更新日：2005/11/18 (Fri) 14:45:50
    '備　考：
    Private Sub vsfMoveSlotMap5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMoveSlotMap5.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            If vsfMoveSlotMap5.MouseRow >= vsfMoveSlotMap5.Rows.Fixed Then
                '@ｸﾞﾘｯﾄﾞ編集(ﾁｪｯｸﾎﾞｯｸｽ)を許可する制御
                Call prvvsfSlotMap_Edit()
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMoveSlotMap5_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '関数名：vsfMoveSlotMap5_KeyDown
    '機　能：WF廃棄ｽﾛｯﾄﾏｯﾌﾟｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：keycode
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/18 (Fri) 14:49:01 N.Kasai
    '更新日：2005/11/18 (Fri) 14:49:01
    '備　考：WF廃棄に特化した機能な為、個別に記述
    Private Sub vsfMoveSlotMap5_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfMoveSlotMap5.KeyDown

        Try

            Select Case e.KeyCode
                '@Spaceｷｰの場合
                Case Keys.Space
                    '@ｸﾞﾘｯﾄﾞ編集(ﾁｪｯｸﾎﾞｯｸｽ)を許可する制御
                    Call prvvsfSlotMap_Edit()
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMoveSlotMap5_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWFScrap_Click
    '機　能：全WF廃棄処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 19:17:33 N.Kojima
    '更新日：2005/11/18 (Fri) 16:43:27 N.Kasai
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF廃棄)Tab
    '　　　：2005/11/18 (Fri) 16:43:27 N.Kasai  WF部分廃棄対応
    Private Sub cmdWFScrap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWFScrap.Click

        Dim lblnAns                 As Boolean          '戻り値
        Dim llngCnt                 As Integer          'ｶｳﾝﾄ
        Dim llngWFListCnt           As Integer          'WFﾘｽﾄｶｳﾝﾄ
        Dim llngWFCnt1              As Integer          'WFｶｳﾝﾄ1
        Dim ltypWfScrap             As WfScrap          'WF廃棄構造体(要求)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnWFMove2Input_Chk()
            If lblnAns = False Then
                '@不正項目あり
                Exit Sub
            End If
                
            '@WFﾁｪｯｸ
            lblnAns = prvblnSlotMap_Chk()
            '@結果判定
            If lblnAns = False Then
                '@失敗の場合
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0039)
                
                '@"WFIDが設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、中止
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmdWFScrap_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@WF枚数
            llngWFCnt1 = prvblnSlotMap_Get(vsfMoveSlotMap5)
            
            '@WF廃棄ﾃﾞｰﾀ作成
            With ltypWfScrap
                .strCarrierId = txtCarrierID2.Text      'ｷｬﾘｱID
                .strComments = txtComment.Text          'ｺﾒﾝﾄ
                .strEmpID = pstrUserID                  '作業者ｺｰﾄﾞ
                
                '@WFがある場合
                If llngWFCnt1 > 0 Then
                    '@WFMap処理
                    .typWfList = New List(Of WfScrapList)()

                    '@WFﾘｽﾄｶｳﾝﾄ
                    llngWFListCnt = 0
                    llngCnt = 0
                    '@統合元WF格納
                    For llngCnt = vsfMoveSlotMap5.Rows.Fixed To vsfMoveSlotMap.Rows.Count - 1
                        '@空白以外の場合
                        If vsfMoveSlotMap5.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                            
                            '@ﾁｪｯｸ済みのWFの場合
                            If vsfMoveSlotMap5.GetCellCheck(llngCnt, CMlngvsfMoveSlotMapColCheck) = CheckEnum.Checked Then
                                Dim tmpWfScrapList As WfScrapList = New WfScrapList()
                            
                                tmpWfScrapList.strWfId = _
                                    vsfMoveSlotMap5.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)                'WFID

                                .typWfList.Add(tmpWfScrapList)
                                llngWFListCnt = llngWFListCnt + 1

                            End If
                            
                        End If
                    Next llngCnt
                End If
                
                '@ﾒｯｾｰｼﾞ送信処理呼び出し
                lblnAns = pubblnWfScrap_Del(CMstrwf__scrap___Ver, ltypWfScrap)
                If lblnAns = True Then
                
                    '@画面の初期化
                    Call prvCarrierTabMnt0_Init(True)
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000F, .strCarrierId)
                    '@成功ﾒｯｾｰｼﾞｽﾃｰﾀｽﾊﾞｰ表示
                    '@"<TRM0FI>$$ウエハを廃棄しました。キャリア[%1]"
                    Call pubVsfInfo_Disp(pstrDMsg)
                                                       
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                    '@在庫管理から呼ばれている場合
                    If txtCarrierID2.Locked = True Then
                        '@ﾌｫｰﾑを閉じる終了
                        Me.Close()
                        Exit Sub
                    End If
                    
                    '@ｷｬﾘｱID(ｷｬﾘｱﾒﾝﾃﾅﾝｽ)にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrierID2)
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
                .strProcName = "cmdWFScrap_Click"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWFAllSelect_Click
    '機　能：全選択ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/18 (Fri) 14:58:42 N.Kasai
    '更新日：2005/11/18 (Fri) 14:58:42
    '備　考：
    Private Sub cmdWFAllSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWFAllSelect.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            Dim llngCnt             As Integer  '汎用ｶｳﾝﾀ
            Dim lblnAllSelectFlag   As Boolean  'ﾁｪｯｸ判定ﾌﾗｸﾞ(True:全数ﾁｪｯｸ済み、False:全数未ﾁｪｯｸ)
            Dim llngCKCnt           As Integer  'ﾁｪｯｸ済みｶｳﾝﾄ
            Dim llngWFcnt           As Integer  'WF枚数ﾁｪｯｸｶｳﾝﾄ
            
            With vsfMoveSlotMap5
                '@ｽﾛｯﾄﾏｯﾌﾟ判定
                For llngCnt = 1 To .Rows.Count - 1
                    '@選択された列が空行以外の場合
                    If .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                        '@WF枚数のｶｳﾝﾄ
                        llngWFcnt = llngWFcnt + 1
                        '@ﾁｪｯｸ済みのWFの存在ﾁｪｯｸ
                        If .GetCellCheck(llngCnt, CMlngvsfMoveSlotMapColCheck) = CheckEnum.Checked Then    'ﾁｪｯｸ
                            '@WFﾁｪｯｸ済み枚数のｶｳﾝﾄ
                            llngCKCnt = llngCKCnt + 1
                        End If
                    End If
                Next
                
                '@変更前のWF状態をﾁｪｯｸ
                Select Case True
                    '@全未ﾁｪｯｸの場合
                    Case llngCKCnt = 0
                        lblnAllSelectFlag = False
                    '@全ﾁｪｯｸ済みの場合
                    Case llngCKCnt = llngWFcnt
                        lblnAllSelectFlag = True
                    '@ﾁｪｯｸ済みであるが全数ではない場合
                    Case Else
                        lblnAllSelectFlag = False
                End Select
            
                '@全数選択ﾌﾗｸﾞが立っていない場合にはすべてﾁｪｯｸを入れる/立っている場合には全てのﾁｪｯｸをはずす
                If lblnAllSelectFlag = False Then
                    '@WF一覧の先頭行～最終行までﾙｰﾌﾟ
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@WFIDがある場合
                        If .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                            '@ﾁｪｯｸを付ける
                            .SetCellCheck(llngCnt, CMlngvsfMoveSlotMapColCheck, CheckEnum.Checked)
                        End If
                    Next llngCnt
                    
                    '@確定ﾎﾞﾀﾝ使用可
                    cmdWFScrap.Enabled = True
                Else
                    '@WF一覧の先頭行～最終行までﾙｰﾌﾟ
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@WFIDがある場合
                        If .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                            '@ﾁｪｯｸをはずす
                            .SetCellCheck(llngCnt, CMlngvsfMoveSlotMapColCheck, CheckEnum.Unchecked)
                        End If
                    Next llngCnt
                    
                    '@確定ﾎﾞﾀﾝ使用不可
                    cmdWFScrap.Enabled = False
                End If
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdWFAllSelect_Click"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentUp_Click
    '機　能：ｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/16 (Fri) 09:20:24 Y.Yamagishi
    '更新日：2005/11/21 (Mon) 15:18:42 N.Kasai
    '備　考：
    '　　　：2005/11/21 (Mon) 15:18:42 N.Kasai      ｽｸﾛｰﾙ連動
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
            Call pubtxtCmdUp_Proc(txtComment, CMlngWFCommentMaxDispRow, cmdCommentUp, cmdCommentDown)
                
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdCommentUp_Click"     '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentDown_Click
    '機　能：ｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/16 (Fri) 09:20:29 Y.Yamagishi
    '更新日：2004/07/16 (Fri) 09:20:29
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
            Call pubtxtCmdDown_Proc(txtComment, CMlngWFCommentMaxDispRow, cmdCommentUp, cmdCommentDown)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdCommentDown_Click"   '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '====================================ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｷｬﾘｱ位置情報変更)Tab====================================
    '関数名：cmbChangePosiotionID_Change
    '機　能：変更後位置変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 20:08:53 N.Kojima
    '更新日：2004/07/07 (Wed) 20:08:53
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｷｬﾘｱ位置情報変更)Tab
    Private Sub cmbChangePosiotionID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbChangePosiotionID.Change
        
        Try
            
            '@変更後位置が選択された場合
            If cmbChangePosiotionID.Text <> vbNullString Then
                '@ｷｬﾘｱの状態からﾎﾞﾀﾝの活性化ﾁｪｯｸ
                If mstrCarrierID2Status <> CMstrRelatedLotStatus2 Then
                    '@確定ﾎﾞﾀﾝﾛｯｸ解除
                    cmdChgStocker.Enabled = True
                Else
                    '@確定ﾎﾞﾀﾝﾛｯｸ
                    cmdChgStocker.Enabled = False
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbChangePosiotionID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbChangePosiotionID_CloseUp
    '機　能：変更後位置選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 18:47:17 N.Kojima
    '更新日：2004/07/07 (Wed) 15:16:42 N.Kojima
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｷｬﾘｱ位置情報変更)Tab
    Private Sub cmbChangePosiotionID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbChangePosiotionID.CloseUp
        
        Try
            
            '@確定ﾎﾞﾀﾝが有効の場合
            If cmdChgStocker.Enabled = True Then
                '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdChgStocker)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "cmbChangePosiotionID_CloseUp"   '処理名
                .strErrMessage = ""                             'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdChgStocker_Click
    '機　能：ｷｬﾘｱ位置変更確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 11:51:01 N.Kojima
    '更新日：2004/07/07 (Wed) 11:51:01
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｷｬﾘｱ位置情報変更)Tab
    Private Sub cmdChgStocker_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChgStocker.Click

        Dim lblnAns                 As Boolean          '戻り値
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnChgStockerInput_Chk()
            If lblnAns = False Then
                '@不正項目あり
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
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmdChgStocker_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnCarrChgStocker_Upd(CMstrcarrchgstockerVer, _
                                               txtCarrierID2.Text, _
                                               cmbChangePosiotionID.Value, _
                                               pstrUserID)
            '@結果判定
            If lblnAns = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000G, txtCarrierID2.Text, cmbChangePosiotionID.Text)
                
                '@画面の初期化
                Call prvCarrierTabMnt0_Init(True)
                
                '@成功ﾒｯｾｰｼﾞｽﾃｰﾀｽﾊﾞｰ表示
                '@pubVsfInfo_Disp("ﾒｯｾｰｼﾞｺｰﾄﾞ：C_I0G%0$$キャリア位置を変更しました。キャリア[ %1 ]")
                Call pubVsfInfo_Disp(pstrDMsg)
                                                   
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@在庫管理から呼ばれている場合
                If txtCarrierID2.Locked = True Then
                    '@ﾌｫｰﾑを閉じる終了
                    Me.Close()
                    Exit Sub
                End If
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrierID2)
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(lstrFormName, lstrEventName)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdChgStocker_Click"    '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdExchange_Click
    '機　能：ｷｬﾘｱ交換確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 18:47:36 N.Kojima
    '更新日：2004/09/16 (Thu) 18:47:36
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｷｬﾘｱ交換)Tab
    '　　　：2005/07/26 (Tue) 10:33:32 S.Deguchi    ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝTagの追加対応
    Private Sub cmdExchange_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdExchange.Click

        Dim lblnAns                 As Boolean          '戻り値
        Dim llngCnt                 As Integer          'ｶｳﾝﾄ
        Dim llngWFListCnt           As Integer          'WFﾘｽﾄｶｳﾝﾄ
        Dim llngWFCnt1              As Integer          'WFｶｳﾝﾄ1
        Dim llngWFCnt2              As Integer          'WFｶｳﾝﾄ2
        Dim ltypCarrMove            As CarrMove         'ｷｬﾘｱ統合(交換)構造体(要求)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnExchangeInput_Chk()
            If lblnAns = False Then
                '@不正項目あり
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
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmdExchange_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@交換元WF枚数退避
            llngWFCnt1 = prvblnSlotMap_Get(vsfMoveSlotMap6)
            '@交換先WF枚数退避
            llngWFCnt2 = prvblnSlotMap_Get(vsfMoveSlotMap7)
            
            '@ﾛｯﾄ投入ﾃﾞｰﾀ作成
            With ltypCarrMove
                .strClassDivision = CPstrCD0B               '処理区分(移載代用)
                .strCarrierID1 = txtCarrierID2.Text         '交換元ｷｬﾘｱID
                .strCarrierID2 = txtCarrierMnt2.Text        '交換先ｷｬﾘｱID
                .strEmpID = pstrUserID                      '作業者ｺｰﾄﾞ
                .strMessageName = tabCarrierMnt.Text        'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ
                
                '@ｵﾝﾗｲﾝﾌﾗｸﾞの処理判別
                If optOnline1.Checked = True Then 
                    .strOnlineFlag = CMlngoptOnline
                Else
                    .strOnlineFlag = CMlngoptOffline
                End If
                
                '@交換元WFはないので"0"を格納
                llngWFCnt1 = 0
                
                '@交換先WFがある場合
                If llngWFCnt2 > 0 Then
                    '@WFMap処理
                    .typWFMapList2 = New List(Of WFMapList)()

                    '@WFﾘｽﾄｶｳﾝﾄ
                    llngWFListCnt = 0
                    llngCnt = 0
                    '@交換先WF格納
                    For llngCnt = vsfMoveSlotMap2.Rows.Fixed To vsfMoveSlotMap2.Rows.Count - 1
                        '@空白以外の場合
                        If vsfMoveSlotMap7.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                            Dim tmpWFMapList As WFMapList = New WFMapList()
                            tmpWFMapList.strSlotPosition _
                                = vsfMoveSlotMap7.GetData(llngCnt, CMlngvsfMoveSlotMapColNo)       'ｽﾛｯﾄ№
                                
                            tmpWFMapList.strWfId _
                                = vsfMoveSlotMap7.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)     'WFID
                            
                            tmpWFMapList.strjigId _
                                = vsfMoveSlotMap7.GetData(llngCnt, CMlngvsfMoveSlotMapColJIGID)    '治具ID

                            .typWFMapList2.Add(tmpWFMapList)
                            llngWFListCnt = llngWFListCnt + 1
                        End If
                    Next llngCnt
                End If
                
                '@ﾒｯｾｰｼﾞ送信処理呼び出し
                lblnAns = pubblnCarrMove_Upd(CMstrcarrmove____Ver, ltypCarrMove, llngWFCnt1, llngWFCnt2)
                '@結果判定
                If lblnAns = True Then
                    '@画面の初期化
                    Call prvCarrierTabMnt0_Init(True)
                    
                    '@ｵﾝﾗｲﾝﾌﾗｸﾞを判定して成功ﾒｯｾｰｼﾞを変更
                    Select Case .strOnlineFlag
                        Case CMlngoptOnline
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002P, CMstrOnlineMsg, .strCarrierID1, .strCarrierID2)
                        Case Else
                             '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002P, CMstrOfflineMsg, .strCarrierID1, .strCarrierID2)
                    End Select
                    
                    '@成功ﾒｯｾｰｼﾞｽﾃｰﾀｽﾊﾞｰ表示(%1:ｵﾝﾗｲﾝORｵﾌﾗｲﾝ)
                    '@pubVsfInfo_Disp("ﾒｯｾｰｼﾞｺｰﾄﾞ：<TRM2PI>$$%1交換しました。交換元キャリア[%2]、交換先キャリア[%3]")
                    Call pubVsfInfo_Disp(pstrDMsg)
                                                       
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                    '@在庫管理から呼ばれている場合
                    If txtCarrierID2.Locked = True Then
                        '@ﾌｫｰﾑを閉じる終了
                        Me.Close()
                        
                        Exit Sub
                    End If
                    
                    '@ｷｬﾘｱID(ｷｬﾘｱﾒﾝﾃﾅﾝｽ)にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrierID2)
                    
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
                .strProcName = "cmdExchange_Click"      '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierSelect2_Click
    '機　能：空きｷｬﾘｱ一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 19:31:09 N.Kojima
    '更新日：2005/11/16 (Wed) 11:14:41 N.Kojima
    '備　考：
    '　　　：2004/10/27 (Wed) 10:41:21 Y.Yamagishi　交換先ｷｬﾘｱIDと同じｷｬﾘｱﾀｲﾌﾟを選択して一覧の初期表示をする
    '　　　：2005/10/06 (Thu) 16:34:39 S.Deguchi    ｷｬﾘｱの洗浄条件設定処理を追加
    '　　　：2005/11/16 (Wed) 11:14:41 N.Kojima     ｷｬﾘｱ管理からの起動区分、空きｷｬﾘｱ一覧表示判定用ﾌﾗｸﾞを設定。(ﾕｰｻﾞｰ要望№0104)
    Private Sub cmdCarrierSelect2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect2.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@交換先ｷｬﾘｱIDと同じｷｬﾘｱﾀｲﾌﾟを選択して表示
            pstrCarrierTypeID = mstrtxtCarrierID2CarrType
            
            '@ｷｬﾘｱの洗浄条件：未洗浄不可
            pstrCleanCondition = CPstrCarrierClean2
            
            '@ｷｬﾘｱ管理からの起動区分を設定
            pblnfrmxxCM00C0Kbn = True
            '@空きｷｬﾘｱ一覧表示判定用ﾌﾗｸﾞを設定
            pstrTypeFlag = mstrtxtCarrierID2TypeFlag
            
            '@ﾛｯﾄ状態を退避
            pstrRelatedLotStatus = mstrCarrierID2Status
            
            '@空きｷｬﾘｱ一覧表示
            frmxxCM00K0.Instance = New frmxxCM00K0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00K0.Instance = Nothing
                Exit Sub
            End If
            
            '@ｷｬﾘｱ一覧表示
            frmxxCM00K0.Instance.ShowDialog(Me)
            frmxxCM00K0.Instance = Nothing
                 
            '@空きｷｬﾘｱが選択されている場合
            If pstrCarrierID <> vbNullString Then
                '@交換先ｷｬﾘｱIDをｾｯﾄ
                txtCarrierMnt2.Text = pstrCarrierID
                '@ｷｬﾘｱ交換先ｷｬﾘｱID処理へ
                RemoveHandler txtCarrierMnt2.Validating, AddressOf txtCarrierMnt2_Validate
                Call txtCarrierMnt2_Validate(txtCarrierMnt2, New CancelEventArgs(False))
                AddHandler txtCarrierMnt2.Validating, AddressOf txtCarrierMnt2_Validate
            End If
            
            '@ｷｬﾘｱ管理からの起動区分を初期化
            pblnfrmxxCM00C0Kbn = False
            '@空きｷｬﾘｱ一覧表示判定用ﾌﾗｸﾞを初期化
            pstrTypeFlag = vbNullString
            
            '@空きｷｬﾘｱ一覧表示判定用ﾌﾗｸﾞを初期化
            pstrRelatedLotStatus = vbNullString
            
            '@交換先ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrierMnt2)

            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｷｬﾘｱID

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdCarrierSelect2_Click"    '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdJigSelect_Click
    '機　能：空き治具選択
    '引　数：なし
    '戻り値：なし
    '作成日：2009/12/03 (Thu) 12:33:00 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub cmdJigSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdJigSelect.Click
        
        Dim llngRow         As Integer  '一覧表示時の行を退避
        
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
            
            '一覧表示時の選択行を退避
            llngRow = vsfMoveSlotMap4.Row
            
            '@治具ﾀｲﾌﾟID引渡し
            If mtypLotCurState.strCfFlag = 1 Then
            
                '@CFの場合
                '@CF(大板)か
                If mtypLotCurState.strLpFlag = 1 Then
                    '@CF(大板)の場合
                    pstrJigTypeID = CPstrJigTypeJO                              '蒸着治具(ODF)
                    pstrScreenSizeID = mtypLotCurState.strScreenSize            'ｽｸﾘｰﾝｻｲｽﾞ
                    pstrJigCategoryID = vbNullString                            'ｶﾃｺﾞﾘ
                Else

                    '@CF(小板)の場合
                    '////////////////////////メモ//////////////////////////
                    ' CF(小板)の場合、下記既存の実装では蒸着治具への交換が出来ない(蒸着工程で交換すると平置き治具にしか交換できない)
                    ' また、蒸着工程以外でもパネルカインドを限定していないのでTFT治具やダミーなど適当でない治具への交換が出来てしまう
                    ' 今回の蒸着治具ODF対応では下記の修正までは行わない
                    '//////////////////////////////////////////////////////
                    pstrJigTypeID = CPstrJigTypeHI                              '平置き治具
                    pstrScreenSizeID = mtypLotCurState.strScreenSize            'ｽｸﾘｰﾝｻｲｽﾞ
                    
                    '@ﾛｯﾄの状態でｶﾃｺﾞﾘを変化させる
                    Select Case mtypLotCurState.strNowST
                        
                        Case CPstrWaitWorkSt, CPstrBeforeProgressSt
                            '@作業待ち､前処理の場合
                            pstrJigCategoryID = mtypLotCurState.strCarrierCategoryId    'ｶﾃｺﾞﾘ
                        
                        Case CPstrAfterProgressSt, CPstrEndWorkSt
                            '@後処理､作業終了の場合
                            pstrJigCategoryID = mtypLotCurState.strNextCarrierCategoryId    '次工程ｶﾃｺﾞﾘ
                    
                    End Select
                End If
                
            Else
                '@TFT基板の場合
                pstrJigTypeID = CPstrJigTypeJT                              '蒸着治具
                pstrScreenSizeID = mtypLotAttribute.strCfScreenSizeID       '貼合せ相手のｽｸﾘｰﾝｻｲｽﾞ
                pstrJigCategoryID = vbNullString                            'ｶﾃｺﾞﾘ
            End If
            pstrJigStatus = CPstrJigStatusCanUse                            '使用可能
            
            
            '@空き治具一覧表示
            frmxxCM0130.Instance = New frmxxCM0130()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM0130.Instance = Nothing
                Exit Sub
            End If
            
            '@空き治具一覧表示
            frmxxCM0130.Instance.ShowDialog(Me)
            frmxxCM0130.Instance = Nothing
                 
            '@空きｷｬﾘｱが選択されている場合
            If pstrJigID <> vbNullString Then
                '@治具IDをｾｯﾄ
                vsfMoveSlotMap4.SetData(llngRow, CMlngvsfMoveSlotMapColJIGID, pstrJigID)
                '@治具IDの妥当性ﾁｪｯｸ
                Call vsfMoveSlotMap4_AfterEdit(vsfMoveSlotMap4, New RowColEventArgs(llngRow, CMlngvsfMoveSlotMapColJIGID))
                
            End If
            
            '@治具ID格納変数初期化
            pstrJigID = vbNullString
            
            '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(vsfMoveSlotMap4)
                
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdJigSelect_Click"         '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfMoveSlotMap4_Click
    '機　能：空治具選択ボタンを有効/無効にする
    '引　数：なし
    '戻り値：
    '作成日：2009/12/03 (Thu) 13:03:11 T.Oide
    '更新日：2009/12/03 (Thu) 13:03:11
    '備　考：
    Private Sub vsfMoveSlotMap4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMoveSlotMap4.MouseUp

        Try
            
            '@空治具選択ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
            Call prvCmdJigSelect_Set()
                
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfMoveSlotMap4_Click"      '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfMoveSlotMap4_LostFocus
    '機　能：@空治具選択ﾎﾞﾀﾝを無効にする
    '引　数：なし
    '戻り値：
    '作成日：2009/12/03 (Thu) 13:46:54 T.Oide
    '更新日：2009/12/03 (Thu) 13:46:54
    '備　考：
    Private Sub vsfMoveSlotMap4_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMoveSlotMap4.Leave
        
        Try
            
            If ActiveControl.Name <> cmdJigSelect.Name Then
                            
                '@空治具選択ﾎﾞﾀﾝ無効
                cmdJigSelect.Enabled = False
                    
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfMoveSlotMap4_LostFocus"  '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfMoveSlotMap4_GotFocus
    '機　能：@空治具選択ﾎﾞﾀﾝの有効/無効ﾁｪｯｸをする
    '引　数：なし
    '戻り値：
    '作成日：2009/12/04 (Fri) 10:29:50 T.Oide
    '更新日：2009/12/04 (Fri) 10:29:50
    '備　考：
    Private Sub vsfMoveSlotMap4_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMoveSlotMap4.Enter

        Try
            
            If ActiveControl.Name <> cmdJigSelect.Name Then
                            
                '@空治具選択ﾎﾞﾀﾝ有効/無効設定
                Call prvCmdJigSelect_Set()
                    
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfMoveSlotMap4_GotFocus"   '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：prvPrivate_Init
    '機　能：Private変数初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/08 (Thu) 09:24:59 M.Miura
    '更新日：2005/03/25 (Fri) 10:25:32 N.Kasai
    '備　考：2004/09/29 (Wed) 09:38:57 S.Deguchi 初期化ﾌﾗｸﾞの初期設定
    '　　　：2005/03/25 (Fri) 10:25:32 N.Kasai  @ﾎﾞﾀﾝ制御ﾌﾗｸﾞｺﾒﾝﾄｱｳﾄ
    Private Sub prvPrivate_Init()

        Dim mtypCarrierAddInit  As CarrierAdd               '登録情報格納初期化用

        Try

            '@初期化
            mblnInitFlg = False

            '@Private変数のｸﾘｱ
            mstrCarrier = vbNullString
            mlngCarrTypListCnt = 0
            mstrCarrier = vbNullString

            '@構造体のｸﾘｱ
            '@ActInitフラグの判定
            If IsNothing(mtypCarrierMaster) Then
                mtypCarrierMaster = New List(Of CarrierMaster)()
            End If
            mtypCarrierAddInit = New CarrierAdd()
            mtypCarrierAdd = mtypCarrierAddInit
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvPrivate_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCarrierTab0_Init
    '機　能：画面の初期化
    '引　数：lblnFrstFlg：True：初回、False：通常ｸﾘｱ
    '戻り値：なし
    '作成日：2004/02/13 (Fri) 15:30:00 K.Takano
    '更新日：2004/02/18 (Wed) 13:34:05 K.Takano
    '備　考：ｷｬﾘｱ登録Tab
    Private Sub prvCarrierTab0_Init(ByVal lblnFrstFlg As Boolean)

        Try

            '@ﾌｫｰﾑ初期化
            '@初回のみﾃﾞﾌｫﾙﾄ設定
            If lblnFrstFlg = True Then
                '@ｷｬﾘｱID最大桁数設定(6桁)
                txtCarrierID0.ChrMaxByte = CMlngCarrierMaxByte
                calUseStartDate.Value = (Date.Now()).ToString(CPstrDateTimeYMD)
                calManuDate.Value = (Date.Now()).ToString(CPstrDateTimeYMD)
            End If
            
            '@ｷｬﾘｱID(ｷｬﾘｱ登録Tab)の初期化
            txtCarrierID0.Text = vbNullString
            
            '@各種ﾗﾍﾞﾙの初期化
            lblCarrierType.Text = vbNullString
            lblVendorName.Text = vbNullString
            lblSlotNum.Text = vbNullString
            lblWashDuraNum.Text = vbNullString
            lblUseDuraNum.Text = vbNullString
            
            '@閉じるﾎﾞﾀﾝはValidate無効
            cmdClose.CausesValidation = False
            '@ｷｬﾘｱ一覧ﾎﾞﾀﾝはValidate無効
            cmdClose.CausesValidation = False
            
            '@登録と削除ﾎﾞﾀﾝﾛｯｸ
            cmdDel.Enabled = False
            cmdRegist.Enabled = False
            
            '@ｷｬﾘｱ登録用変数初期化
            With mtypCarrierAdd
                .strCarrierId = vbNullString
                .strCarrierTypeID = vbNullString
                .strProductionDate = vbNullString
                .strStartTime = vbNullString
                .strVenderId = vbNullString
            End With
            
            '@ｶﾚﾝﾀﾞｰ設定
            With calUseStartDate
                .CalendarHeight = CPlngClHeight
                .CalendarWidth = CPlngClWidth
                .DayFont = New Font(.DayFont.FontFamily, CPlngClFontSize, .DayFont.Style, .DayFont.Unit)
                .TitleFont = New Font(.TitleFont.FontFamily, CPlngClTlFontSize, .TitleFont.Style, .TitleFont.Unit)
                .GridFont = New Font(.GridFont.FontFamily, CPlngClGridFontSize, .GridFont.Style, .GridFont.Unit)
            End With
            With calManuDate
                .CalendarHeight = CPlngClHeight
                .CalendarWidth = CPlngClWidth
                .DayFont = New Font(.DayFont.FontFamily, CPlngClFontSize, .DayFont.Style, .DayFont.Unit)
                .TitleFont = New Font(.TitleFont.FontFamily, CPlngClTlFontSize, .TitleFont.Style, .TitleFont.Unit)
                .GridFont = New Font(.GridFont.FontFamily, CPlngClGridFontSize, .GridFont.Style, .GridFont.Unit)
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCarrierTab0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbSbID_Disp
    '機　能：利用SB表示
    '引　数：ltypMasSbList：ｼｽﾃﾑﾌﾞﾛｯｸ構造体
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 09:22:44 M.Miura
    '更新日：2004/12/07 (Tue) 20:03:06 N.Kasai
    '備　考：ｷｬﾘｱ登録Tab、ｷｬﾘｱ一覧Tab
    '　　　：2004/12/07 (Tue) 20:03:06 N.Kasai  利用SBのﾃﾞﾌｫﾙﾄ表示追加
    Private Sub prvcmbSbID_Disp(ByRef ltypMasSbList As MasSbList)

        Dim llngCnt             As Integer              'ｶｳﾝﾄ
        Dim llngSBID0           As Integer              '利用SBｲﾝﾃﾞｯｸｽ退避(ｷｬﾘｱ登録ﾀﾌﾞ)
        Dim llngSBID1           As Integer              '利用SBｲﾝﾃﾞｯｸｽ退避(ｷｬﾘｱ一覧ﾀﾌﾞ)

        Try
          
            '@ｷｬﾘｱ登録Tab
            With cmbSBID0
                '@利用SB初期化
                .Clear()
                .DispCols = CMlngCmbDispCol2                                  'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                 '値取得列
                .GetCol = CMlngCmbGetCol0                                     '表示列
                .Font = New Font(.Font.FontFamily, _ 
                       CMlngCmbFontSize, .Font.Style, .Font.Unit)             'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, _
                       CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .ColAlignment(CMlngCmbGetCol0) = TextAlignEnum.LeftCenter     '左寄中央揃え
                .ColAlignment(CMlngCmbGetCol1) = TextAlignEnum.LeftCenter     '左寄中央揃え
                .DirectInput = False                                          '直接入力(Flase)
                
                '@利用SBがない場合
                If ltypMasSbList.lngSbListCnt = 0 Then
                    Exit Sub
                End If
                
                '@利用SBｲﾝﾃﾞｯｸｽの初期化
                llngSBID0 = 0
                
                '@利用SB指定なし設定
                 .AddItem(CMstrNotAppoint)
                
                '@利用SBがなくなるまで
                For llngCnt = 0 To ltypMasSbList.lngSbListCnt - 1
                    .AddItem(ltypMasSbList.typSbList(llngCnt).strSBName & vbTab & _
                             ltypMasSbList.typSbList(llngCnt).strSbID)             'ｼｽﾃﾑﾌﾞﾛｯｸID&ｼｽﾃﾑﾌﾞﾛｯｸ名
                    '@利用SB = 起動SBの場合ﾃﾞﾌｫﾙﾄ表示用ｲﾝﾃﾞｸｽを退避する
                    If ltypMasSbList.typSbList(llngCnt).strSbID = pstrSBID Then
                        '@ｲﾝﾃﾞｯｸｽ退避
                        llngSBID0 = llngCnt + 1
                    End If
                Next llngCnt
                
                '@ﾃﾞﾌｫﾙﾄ表示
                .ListIndex = llngSBID0
            End With

            '@ｷｬﾘｱ一覧Tab
            With cmbSBID1
                '@利用SB初期化
                .Clear()
                .DispCols = CMlngCmbDispCol2                                   'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                  '値取得列
                .GetCol = CMlngCmbGetCol0                                      '表示列
                .Font = New Font(.Font.FontFamily, _
                        CMlngCmbFontSize, .Font.Style, .Font.Unit)             'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, _
                        CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .ColAlignment(CMlngCmbGetCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .ColAlignment(CMlngCmbGetCol1) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .DirectInput = False                                           '直接入力(Flase)
                
                '@利用SBがない場合
                If ltypMasSbList.lngSbListCnt = 0 Then
                    Exit Sub
                End If
                
                '@利用SB指定なし設定
                 .AddItem(CMstrNotAppoint)
                
                '@利用SBがなくなるまで
                For llngCnt = 0 To ltypMasSbList.lngSbListCnt - 1
                    .AddItem(ltypMasSbList.typSbList(llngCnt).strSBName & vbTab & _
                             ltypMasSbList.typSbList(llngCnt).strSbID)             'ｼｽﾃﾑﾌﾞﾛｯｸID&ｼｽﾃﾑﾌﾞﾛｯｸ名
                
                     '@利用SB = 起動SBの場合ﾃﾞﾌｫﾙﾄ表示用ｲﾝﾃﾞｸｽを退避する
                    If ltypMasSbList.typSbList(llngCnt).strSbID = pstrSBID Then
                        '@ｲﾝﾃﾞｯｸｽ退避
                        llngSBID1 = llngCnt + 1
                    End If
                Next llngCnt
                         
                '@ﾃﾞﾌｫﾙﾄ表示
                .ListIndex = llngSBID1
                
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

    '関数名：prvblnMasterCarrier_Set
    '機　能：ｽﾛｯﾄ数、洗浄耐用回数、使用耐用回数を設定
    '引　数：なし
    '戻り値：True：設定成功、False：設定失敗
    '作成日：2004/02/16 (Mon) 14:30:00 K.Takano
    '更新日：2004/07/08 (Thu) 10:50:48 N.Kojima
    '備　考：ｷｬﾘｱ登録Tab
    Private Function prvblnMasterCarrier_Set() As Boolean
        
        Dim lstrDiscID      As String           '識別ID
        Dim llngCnt         As Integer          'ｶｳﾝﾀ変数

        Try
            
            '@戻り値の初期値設定(設定失敗)
            prvblnMasterCarrier_Set = False
            
            '@識別IDの取得
            lstrDiscID = Strings.Left(txtCarrierID0.Text, CMlngDiscNum)
            
            '@識別IDの一致確認
            For llngCnt = 0 To mlngCarrTypListCntAll - 1
                '@識別IDが一致している場合
                If mtypCarrierMasterAll(llngCnt).strCarrierDiscID = lstrDiscID Then
                    '@表示項目を設定
                    With mtypCarrierMasterAll(llngCnt)
                        lblCarrierType.Text = .strCarrierTypeName
                        lblVendorName.Text = .strVendorName
                        lblSlotNum.Text = .strSlotSize
                        lblWashDuraNum.Text = .strMaxCleanCount
                        lblUseDuraNum.Text = .strMaxUseCount
                    End With
                    '@ｷｬﾘｱ登録要素追加
                    With mtypCarrierAdd
                        .strCarrierTypeID = mtypCarrierMasterAll(llngCnt).strCarrierTypeID
                        .strVenderId = mtypCarrierMasterAll(llngCnt).strVendorID
                    End With
                    
                    '@戻り値の初期値設定(設定成功)
                    prvblnMasterCarrier_Set = True
                    Exit Function
                End If
            Next llngCnt
            
            '@確定、削除ﾎﾞﾀﾝﾛｯｸ
            Call prvCmd_Set(False)
            
            '@識別IDが一致しない場合(初期化)
            lblCarrierType.Text = vbNullString
            lblVendorName.Text = vbNullString
            lblSlotNum.Text = vbNullString
            lblWashDuraNum.Text = vbNullString
            lblUseDuraNum.Text = vbNullString
            With mtypCarrierAdd
                .strCarrierTypeID = vbNullString
                .strVenderId = vbNullString
            End With
            
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0009)
            '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが不正です。先頭文字を確認してください。" )
            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnMasterCarrier_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvInput_Chk
    '機　能：入力値ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 17:10:24 M.Miura
    '更新日：2004/08/27 (Fri) 17:27:14 N.Kasai
    '備　考：ｷｬﾘｱ登録Tab
    '　　　：2004/08/27 (Fri) 17:27:14 N.Kasai　ｷｬﾘｱﾀｲﾌﾟ追加
    Private Sub prvInput_Chk()
        
        Dim lstrStartTime           As String                   '利用開始日
        Dim lstrProductionDate      As String                   '製造年月日
        Dim lblnAns                 As Boolean                  'ｷｬﾘｱ情報設定戻り値(True:正常,False:異常)
        Dim ltypCarrCurstate        As CarrCurstate             'ｷｬﾘｱ状態確認要求構造体
        
        Try
            
            '@ｷｬﾘｱIDﾁｪｯｸ
            With txtCarrierID0
                '@ｷｬﾘｱIDが6桁ではない場合
                If Len(.Text) <> .ChrMaxByte Then
                    '@ｽﾛｯﾄ数,洗浄耐用回数,使用耐用回数のｸﾘｱ
                    lblCarrierType.Text = vbNullString
                    lblVendorName.Text = vbNullString
                    lblSlotNum.Text = vbNullString
                    lblWashDuraNum.Text = vbNullString
                    lblUseDuraNum.Text = vbNullString
                    '@確定、削除ﾎﾞﾀﾝﾛｯｸ
                    Call prvCmd_Set(False)
                    Exit Sub
                End If
            End With
            
            '@利用開始日格納
            lstrStartTime = calUseStartDate.Value
            
            '@利用開始日が日付ではない場合
            If IsDate(lstrStartTime) = False Then
                '@確定、削除ﾎﾞﾀﾝﾛｯｸ
                Call prvCmd_Set(False)
                Exit Sub
            End If
            
            '@製造年月日格納
            lstrProductionDate = calManuDate.Value
            
            '@製造年月日ﾁｪｯｸ
            '@製造年月日が日付ではない場合
            If IsDate(lstrProductionDate) = False Then
                '@確定、削除ﾎﾞﾀﾝﾛｯｸ
                Call prvCmd_Set(False)
                Exit Sub
            End If
            
            
            '@利用開始日付と製造年月日の大小ﾁｪｯｸ
            If lstrStartTime < lstrProductionDate Then
                '@利用開始日付のほうが製造年月日よりも新しい場合
                '@確定、削除ﾎﾞﾀﾝﾛｯｸ
                Call prvCmd_Set(False)
                Exit Sub
            End If
            
            '@ｷｬﾘｱ情報(要求)格納
            With ltypCarrCurstate
                .strCarrierId = txtCarrierID0.Text  'ｷｬﾘｱID
                .strClassDivision = CPstrCD2C       '登録済みﾁｪｯｸ
                .strMsgVer = CMstrcarrcurstateVer   'MSGVER
                .strSbID = pstrSBID                 '処理区分
                .strCarrierTypeID = vbNullString    'ｷｬﾘｱﾀｲﾌﾟ(判断の必要はなし)
            End With
                
            '@ｷｬﾘｱ状態取得(ｷｬﾘｱID登録済みﾁｪｯｸ)
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, False)
            
            '@入力したｷｬﾘｱIDの存在ﾁｪｯｸ結果確認
            If lblnAns = False Then
                '@ｷｬﾘｱID登録済みﾌﾗｸﾞ初期化
                mblnCarrierID0Flg = False
                '@ﾎﾞﾀﾝ有効無効処理
                Call prvCmd_Set(True)
            Else
                'Call pubSetFocus(txtCarrierID0) ' NSYS 不要なため削除
                '@登録済みｷｬﾘｱID退避
                mstrCarrierID0 = txtCarrierID0.Text
                '@ｷｬﾘｱID登録済みﾌﾗｸﾞTrue
                mblnCarrierID0Flg = True
                '@ﾎﾞﾀﾝ有効無効処理
                Call prvCmd_Set(True)
                Exit Sub
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvInput_Chk"           '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
           
        End Try
    End Sub

    '関数名：prvCmd_Set
    '機　能：登録、削除ﾎﾞﾀﾝの使用可否制御
    '引　数：lblnEnabled：True：ﾛｯｸ解除、False：ﾛｯｸ
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 16:58:35 M.Miura
    '更新日：2006/03/08 (Wed) 10:32:54 N.Kojima
    '備　考：ｷｬﾘｱ登録Tab
    '　　　：2006/03/08 (Wed) 10:32:54 N.Kojima     確定ﾎﾞﾀﾝはｷｬﾘｱが存在する場合、有効にする。(運用障害№)
    Private Sub prvCmd_Set(ByVal lblnEnabled As Boolean)

        Try
            
            '@引数がFalseの場合
            If lblnEnabled = False Then
                '@登録ﾎﾞﾀﾝ
                cmdRegist.Enabled = lblnEnabled
                '@削除ﾎﾞﾀﾝ
                cmdDel.Enabled = lblnEnabled
                Exit Sub
            End If
            
            '@ｷｬﾘｱID登録済みﾌﾗｸﾞがTrueの場合
            If mblnCarrierID0Flg = True Then
            
                '@登録ﾎﾞﾀﾝ
                cmdRegist.Enabled = True
                
                '@削除ﾎﾞﾀﾝ
                cmdDel.Enabled = True
            Else
                '@登録ﾎﾞﾀﾝ
                cmdRegist.Enabled = True
                '@削除ﾎﾞﾀﾝ
                cmdDel.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmd_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmdJigSelect_Set
    '機　能：空治具選択ﾎﾞﾀﾝﾝの使用可否制御
    '引　数：なし
    '戻り値：なし
    '作成日：2009/12/03 (Thu) 13:23:09　T.Oide
    '更新日：
    '備　考：
    Private Sub prvCmdJigSelect_Set()

        Try
            
            '@ﾀｲﾄﾙ行でなく、ｽﾃｰﾀｽと治具IDがNULLでないか
            If vsfMoveSlotMap4.Row > 0 And _
               vsfMoveSlotMap4.GetData(vsfMoveSlotMap4.Row, CMlngvsfMoveSlotMapColWFStat) <> vbNullString And _
               vsfMoveSlotMap4.GetData(vsfMoveSlotMap4.Row, CMlngvsfMoveSlotMapColJIGID) <> vbNullString Then
                
                '@空治具選択ﾎﾞﾀﾝ有効
                cmdJigSelect.Enabled = True
            Else
                
                '@空治具選択ﾎﾞﾀﾝ無効
                cmdJigSelect.Enabled = False
                
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdJigSelect_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCarrierTab1_Init
    '機　能：ｷｬﾘｱ一覧画面の初期化
    '引　数：lblnFrstFlg：True：初回、False：通常ｸﾘｱ
    '戻り値：なし
    '作成日：2004/02/13 (Fri) 15:30:00 K.Takano
    '更新日：2006/02/21 (Tue) 16:53:17 N.Kojima
    '備　考：ｷｬﾘｱ一覧Tab
    '　　　：2004/11/29 (Mon) 13:57:31 N.Kojima　   出庫指示機能追加に伴い、ｽﾄｯｶｰｺﾝﾎﾞの有効無効処理追加
    '　　　：2005/11/18 (Fri) 12:15:03 N.Kasai      ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ機能追加
    '　　　：2006/02/21 (Tue) 16:53:17 N.Kojima     使用ｶﾃｺﾞﾘ/ｺﾒﾝﾄ変更ﾎﾞﾀﾝ追加に伴ない処理追加。(ﾕｰｻﾞｰ要望№0141)
    Private Sub prvCarrierTab1_Init(ByVal lblnFrstFlg As Boolean)

        Try
            
            '@該当件数の初期化
            lblCarrierCnt.Text = vbNullString
            
            '@ﾛｯｸ
            '@"1A0"の時以外は表示しない
            If pstrSBID <> CPstrSBID1A0 Then
                '@ｽﾄｯｶｰｺﾝﾎﾞ/ﾗﾍﾞﾙ・出庫指示ﾎﾞﾀﾝ
                cmbStockerName.Visible = False
                cmdShip.Visible = False
                lblTitle5.Visible = False
            Else
                '@ｽﾄｯｶｰｺﾝﾎﾞ・出庫指示ﾎﾞﾀﾝ
                cmbStockerName.Visible = True
                cmdShip.Visible = True
                cmdShip.Enabled = False
                cmbStockerName.Enabled = False
            End If
            
            '@ﾎﾞﾀﾝのﾛｯｸ
            cmdNowList.Enabled = False              '最新取得ﾎﾞﾀﾝ
            cmdClean.Enabled = False                '洗浄ﾎﾞﾀﾝ
            cmdCarrierForcedmove.Enabled = False    'ｷｬﾘｱ強制交換ﾎﾞﾀﾝ
            cmdCopy.Enabled = False                 'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ
            cmdUpdate.Enabled = False               '使用ｶﾃｺﾞﾘ/ｺﾒﾝﾄ変更ﾎﾞﾀﾝ

            '@ｺﾒﾝﾄﾌｨｰﾙﾄﾞを初期化する
            txtCarrierComments.Text = vbNullString
            txtCarrierComments_Change(txtCarrierComments, New EventArgs())
            txtCarrierComments.Enabled = False
            
            '@編集中ﾌﾗｸﾞを初期化
            mblnEditFlag = False                    '編集中ﾌﾗｸﾞ
            
            '@ｷｬﾘｱ一覧の初期化
            Call prvvsfCarrierList_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCarrierTab1_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCarrierList_Init
    '機　能：ｷｬﾘｱ一覧(ｸﾞﾘｯﾄﾞ)初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 14:16:34 M.Matsuura
    '更新日：2006/02/21 (Tue) 15:41:18 N.Kojima
    '備　考：ｷｬﾘｱ一覧Tab
    '　　　：2004/09/17 (Fri) 11:29:01 N.Kojima　   Unloderﾘｽﾄ項目追加
    '　　　：2004/12/09 (Thu) 15:29:54 S.Deguchi    隠しCol設定を追加
    '　　　：2006/02/21 (Tue) 15:41:18 N.Kojima     一覧項目の並び順変更と項目の追加。(ﾕｰｻﾞｰ要望№0141)
    Private Sub prvvsfCarrierList_Init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfCarrierList
                '@ﾌﾟﾛﾊﾟﾃｨ初期値
                .Clear(ClearFlags.Content)
                .Redraw = False
                .Cols.Count = CMlngvsfCarrierListCols
                .Rows.Count = .Rows.Fixed
                .SelectionMode = SelectionModeEnum.Row
                .FocusRect = FocusRectEnum.Light
                .HighLight = HighLightEnum.Always
                .Font = New Font(.Font.FontFamily, CMlngvsfCarrierListSize, .Font.Style, .Font.Unit)
                .Rows.DefaultSize = 18
                .ScrollBars = ScrollBars.Both
                .AllowDragging = AllowDraggingEnum.None
                .AllowSorting = AllowSortingEnum.SingleColumn
                .Cols.Frozen = CMlngvsfCarrierListColCarrierID + 1
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter

                '@表示位置の設定
                .Cols(CMlngvsfCarrierListColNo).TextAlign = TextAlignEnum.RightCenter                   '№
                .Cols(CMlngvsfCarrierListColCarrierID).TextAlign = TextAlignEnum.LeftCenter             'ｷｬﾘｱID
                .Cols(CMlngvsfCarrierListColLotID).TextAlign = TextAlignEnum.LeftCenter                 'ﾛｯﾄID
                .Cols(CMlngvsfCarrierListColPosition).TextAlign = TextAlignEnum.LeftCenter              '現在位置名
                .Cols(CMlngvsfCarrierListColCategoryName).TextAlign = TextAlignEnum.LeftCenter          '使用ｶﾃｺﾞﾘ名
                .Cols(CMlngvsfCarrierListColCategoryID).TextAlign = TextAlignEnum.LeftCenter            '使用ｶﾃｺﾞﾘID
                .Cols(CMlngvsfCarrierListColComments).TextAlign = TextAlignEnum.LeftCenter              'ｺﾒﾝﾄ
                .Cols(CMlngvsfCarrierListColCleanFlag).TextAlign = TextAlignEnum.LeftCenter             '要洗浄
                .Cols(CMlngvsfCarrierListColState).TextAlign = TextAlignEnum.LeftCenter                 '状態
                .Cols(CMlngvsfCarrierListColEditTime).TextAlign = TextAlignEnum.LeftCenter              '最終更新日時
                .Cols(CMlngvsfCarrierListColTotalCnt).TextAlign = TextAlignEnum.RightCenter             '総回数
                .Cols(CMlngvsfCarrierListColCleanCnt).TextAlign = TextAlignEnum.RightCenter             '洗浄回数
                .Cols(CMlngvsfCarrierListColAfterCleanCnt).TextAlign = TextAlignEnum.RightCenter        '洗浄後回数
                .Cols(CMlngvsfCarrierListColUnloderReserve).TextAlign = TextAlignEnum.LeftCenter        'Unloder予約
                .Cols(CMlngvsfCarrierListColCarrierMoveStat).TextAlign = TextAlignEnum.LeftCenter       'ｷｬﾘｱ強制交換
                .Cols(CMlngvsfCarrierListColCarrierStat).TextAlign = TextAlignEnum.LeftCenter           'ｷｬﾘｱ状態
                .Cols(CMlngvsfCarrierListColStartTime).TextAlign = TextAlignEnum.LeftCenter             '使用開始日時
                .Cols(CMlngvsfCarrierListColCleanTime).TextAlign = TextAlignEnum.LeftCenter             '最終洗浄日時
                .Cols(CMlngvsfCarrierListColVendor).TextAlign = TextAlignEnum.LeftCenter                'ﾍﾞﾝﾀﾞｰ
                .Cols(CMlngvsfCarrierListColPositionID).TextAlign = TextAlignEnum.LeftCenter            'ｷｬﾘｱ位置ID
                .Cols(CMlngvsfCarrierListColProductionDate).TextAlign = TextAlignEnum.LeftCenter        '製造年月日

                '@ｸﾞﾘｯﾄﾞの表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfGridTitleRow, CMlngvsfCarrierListColNo, CMlngvsfGridTitleRow, CMlngvsfCarrierListColProductionDate)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                                             '文字色
                headerStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                                              '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfCarrierListSize, headerStyle.Font.Style, headerStyle.Font.Unit) 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               '文字位置
                headerStyle.Trimming = StringTrimming.None                                                                                       'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle


                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColNo, CMstrvsfCarrierListTNo)                              '№
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColCarrierID, CMstrvsfCarrierListTCarrierID)                'ｷｬﾘｱID
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColLotID, CMstrvsfCarrierListTLotID)                        'ﾛｯﾄID
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColPosition, CMstrvsfCarrierListTPosition)                  '現在位置名
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColCategoryName, CMstrvsfCarrierListTCategoryName)          '使用ｶﾃｺﾞﾘ名
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColCategoryID, CMstrvsfCarrierListTCategoryID)              '使用ｶﾃｺﾞﾘID
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColComments, CMstrvsfCarrierListTComments)                  'ｺﾒﾝﾄ
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColCleanFlag, CMstrvsfCarrierListTCleanFlag)                '要洗浄
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColState, CMstrvsfCarrierListTState)                        '状態
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColEditTime, CMstrvsfCarrierListTEditTime)                  '最終更新日時
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColTotalCnt, CMstrvsfCarrierListTTotalCnt)                  '総回数
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColCleanCnt, CMstrvsfCarrierListTCleanCnt)                  '洗浄回数
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColAfterCleanCnt, CMstrvsfCarrierListTAfterCleanCnt)        '洗浄後回数
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColUnloderReserve, CMstrvsfCarrierListTUnloderReserve)      'Unloder予約
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColCarrierMoveStat, CMstrvsfCarrierListTCarrierMoveStat)    'ｷｬﾘｱ強制交換
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColCarrierStat, CMstrvsfCarrierListTCarrierStat)            'ｷｬﾘｱ状態
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColStartTime, CMstrvsfCarrierListTStartTime)                '使用開始日時
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColCleanTime, CMstrvsfCarrierListTCleanTime)                '最終洗浄日時
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColVendor, CMstrvsfCarrierListTVendor)                      'ﾍﾞﾝﾀﾞｰ
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColPositionID, CMstrvsfCarrierListTColPositionID)           'ｷｬﾘｱ位置ID
                .SetData(CMlngvsfGridTitleRow, CMlngvsfCarrierListColProductionDate, CMstrvsfCarrierListTProductionDate)      '製造年月日

                .AutoSizeCols(CMlngvsfCarrierListColNo, CMlngvsfCarrierListColProductionDate,6)

                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@列幅の設定
                    .Cols(CMlngvsfCarrierListColNo).Width = CMlngvsfCarrierListWNo                            '№
                    .Cols(CMlngvsfCarrierListColCarrierID).Width = CMlngvsfCarrierListWCarrierID              'ｷｬﾘｱID
                    .Cols(CMlngvsfCarrierListColLotID).Width = CMlngvsfCarrierListWLotID                      'ﾛｯﾄID
                    .Cols(CMlngvsfCarrierListColPosition).Width = CMlngvsfCarrierListWPosition                '現在位置名
                    .Cols(CMlngvsfCarrierListColCategoryName).Width = CMlngvsfCarrierListWCategoryName        '使用ｶﾃｺﾞﾘ名
                    .Cols(CMlngvsfCarrierListColCategoryID).Width = CMlngvsfCarrierListWCategoryID            '使用ｶﾃｺﾞﾘID
                    .Cols(CMlngvsfCarrierListColComments).Width = CMlngvsfCarrierListWComments                'ｺﾒﾝﾄ
                    .Cols(CMlngvsfCarrierListColCleanFlag).Width = CMlngvsfCarrierListWCleanFlag              '要洗浄
                    .Cols(CMlngvsfCarrierListColState).Width = CMlngvsfCarrierListWState                      '状態
                    .Cols(CMlngvsfCarrierListColEditTime).Width = CMlngvsfCarrierListWEditTime                '最終更新日時
                    .Cols(CMlngvsfCarrierListColTotalCnt).Width = CMlngvsfCarrierListWTotalCnt                '総回数
                    .Cols(CMlngvsfCarrierListColCleanCnt).Width = CMlngvsfCarrierListWCleanCnt                '洗浄回数
                    .Cols(CMlngvsfCarrierListColAfterCleanCnt).Width = CMlngvsfCarrierListWAfterCleanCnt      '洗浄後回数
                    .Cols(CMlngvsfCarrierListColUnloderReserve).Width = CMlngvsfCarrierListWUnloderReserve    'Unloder予約
                    .Cols(CMlngvsfCarrierListColCarrierMoveStat).Width = CMlngvsfCarrierListWCarrierMoveStat  'ｷｬﾘｱ強制交換
                    .Cols(CMlngvsfCarrierListColCarrierStat).Width = CMlngvsfCarrierListWCarrierStat          'ｷｬﾘｱ状態
                    .Cols(CMlngvsfCarrierListColStartTime).Width = CMlngvsfCarrierListWStartTime              '使用開始日時
                    .Cols(CMlngvsfCarrierListColCleanTime).Width = CMlngvsfCarrierListWCleanTime              '最終洗浄日時
                    .Cols(CMlngvsfCarrierListColVendor).Width = CMlngvsfCarrierListWVendor                    'ﾍﾞﾝﾀﾞｰ
                    .Cols(CMlngvsfCarrierListColPositionID).Width = CMlngvsfCarrierListWPositionID            'ｷｬﾘｱ位置ID
                    .Cols(CMlngvsfCarrierListColProductionDate).Width = CMlngvsfCarrierListWProductionDate    '製造年月日
                End If
                
                '@隠しCol設定
                .Cols(CMlngvsfCarrierListColPositionID).Visible = False         'ｷｬﾘｱ位置ID
                .Cols(CMlngvsfCarrierListColCarrierStat).Visible = False        'ｷｬﾘｱ状態
                .Cols(CMlngvsfCarrierListColCategoryID).Visible = False         '使用ｶﾃｺﾞﾘID
                
                '@最終colを自動幅設定
                .ExtendLastCol = True
                
                '@該当件数初期化
                lblCarrierCnt.Text = vbNullString
                '@ｷｬﾘｱ一覧取得日時初期化
                lblNowDate.Text = vbNullString
                '@編集中ﾌﾗｸﾞを初期化
                mblnEditFlag = False                    '編集中ﾌﾗｸﾞ
                
                .LeftCol = 0
                '@描画
                .Redraw = True
                '@ﾛｯｸ
                .Enabled = False

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCarrierList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbCarrTyp_Disp
    '機　能：ｷｬﾘｱﾀｲﾌﾟ一覧情報表示
    '引　数：llngCarrierCnt：ｷｬﾘｱﾀｲﾌﾟ一覧ﾃﾞｰﾀ数
    '　　　：mtypCarrierMaster()：ｷｬﾘｱﾀｲﾌﾟ一覧情報格納ﾃﾞｰﾀ
    '戻り値：なし
    '作成日：2004/06/09 (Wed) 11:13:30 Y.Yamagishi
    '更新日：2004/06/10 (Thu) 09:10:06 K.Takano
    '備　考：ｷｬﾘｱ一覧Tab
    Private Sub prvcmbCarrTyp_Disp(ByRef llngCarrierCnt As Integer, ByRef mtypCarrierMaster As List(Of CarrierMaster))

        Dim llngCnt             As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngCarrTypCntList  As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngCarrTypCnt      As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrCarrTyp(,)      As String               'ｷｬﾘｱﾀｲﾌﾟ格納配列
        Dim lblnFlg             As Boolean              '配列格納ﾌﾗｸﾞ

        Try
            
            With cmbCarrType
                '@ｷｬﾘｱﾀｲﾌﾟ情報初期化
                .Clear()
                .DispCols = CMlngCmbDispCol1                                  'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                 '値取得列
                .GetCol = CMlngCmbGetCol0                                     '表示列
                .Font = New Font(.Font.FontFamily, _ 
                       CMlngCmbFontSize, .Font.Style, .Font.Unit)             'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, _
                       CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .ColAlignment(CMlngCmbGetCol0) = TextAlignEnum.LeftCenter     '左寄中央揃え
                .DirectInput = False                                          '直接入力(Flase)
                
                '@ｷｬﾘｱﾀｲﾌﾟがない場合
                If llngCarrierCnt = 0 Then
                    Exit Sub
                End If
                
                llngCarrTypCntList = 1
                
                ReDim lstrCarrTyp(1, llngCarrTypCntList-1)
                
                lstrCarrTyp(0, llngCarrTypCntList-1) = mtypCarrierMaster(llngCarrTypCntList-1).strCarrierTypeName
                lstrCarrTyp(1, llngCarrTypCntList-1) = mtypCarrierMaster(llngCarrTypCntList-1).strCarrierTypeID
                
                '@ｷｬﾘｱﾀｲﾌﾟ情報ｾｯﾄ
                '@構造体のﾙｰﾌﾟ
                For llngCnt = 0 To llngCarrierCnt - 1
                    '@配列格納ﾌﾗｸﾞ初期化
                    lblnFlg = False
                    '@配列のﾙｰﾌﾟ
                    For llngCarrTypCnt = 0 To llngCarrTypCntList - 1
                        '@ｷｬﾘｱﾀｲﾌﾟIDの判定
                        If lstrCarrTyp(1, llngCarrTypCnt) = mtypCarrierMaster(llngCnt).strCarrierTypeID Then
                            '@同じ場合
                            '@配列格納ﾌﾗｸﾞTrue
                            lblnFlg = True
                            Exit For
                        End If
                    Next llngCarrTypCnt
                    '@配列格納ﾌﾗｸﾞがFalseの場合
                    If lblnFlg = False Then
                        '@配列ｶｳﾝﾄｱｯﾌﾟ
                        llngCarrTypCntList = llngCarrTypCntList + 1
                        ReDim Preserve lstrCarrTyp(1, llngCarrTypCntList-1)
                        '@配列にｷｬﾘｱﾀｲﾌﾟ名,ｷｬﾘｱﾀｲﾌﾟID格納
                        lstrCarrTyp(0, llngCarrTypCntList-1) = mtypCarrierMaster(llngCnt).strCarrierTypeName
                        lstrCarrTyp(1, llngCarrTypCntList-1) = mtypCarrierMaster(llngCnt).strCarrierTypeID
                    End If
                Next llngCnt
                
                '@配列のﾙｰﾌﾟ
                For llngCarrTypCnt = 0 To llngCarrTypCntList - 1
                    .AddItem(lstrCarrTyp(0, llngCarrTypCnt) & vbTab & _
                            lstrCarrTyp(1, llngCarrTypCnt))        'ｷｬﾘｱﾀｲﾌﾟ名&ｷｬﾘｱﾀｲﾌﾟID
                Next llngCarrTypCnt
                         
                '@ｷｬﾘｱﾀｲﾌﾟ情報が1件の場合
                If .ListCount = 1 Then
                    '@1件目表示
                    .ListIndex = 0
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbCarrTyp_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCarrierList_Disp
    '機　能：ｷｬﾘｱﾘｽﾄ表示
    '引　数：ltypCarrierAllList:表示ﾃﾞｰﾀ格納
    '戻り値：なし
    '作成日：2004/03/30 (Tue) 13:00:05 T.Oide
    '更新日：2006/05/11 (Thu) 09:47:02 M.Miura
    '備　考：ｷｬﾘｱ一覧Tab
    '　　　：2004/09/17 (Fri) 11:29:01 N.Kojima　   Unloderﾘｽﾄ項目追加
    '　　　：2004/10/14 (Thu) 19:22:08 M.Miura　    ｿｰﾄ順表示、ｶﾚﾝﾄ行設定の追加
    '　　　：2004/11/29 (Mon) 17:23:52 N.Kojima　   出庫指示機能追加に伴い、ｷｬﾘｱ位置ID(判定用)を追加
    '　　　：2004/12/15 (Wed) 15:29:55 N.Kasai      ｷｬﾘｱ状態IDを判定してMOVEの場合は搬送先を表示する。
    '　　　：2005/01/21 (Fri) 11:06:23 N.Kasai      ｷｬﾘｱ位置表示(DEST→DEST_NAMEへ変更)不具合№327
    '　　　：2005/02/09 (Wed) 09:23:50 N.Kasai      ｷｬﾘｱ状態が搬送、出庫、入庫中の場合は搬送先を表示する。
    '　　　：2005/03/25 (Fri) 10:58:13 N.Kasai      初期化見直し
    '　　　：2005/06/09 (Thu) 10:48:04 N.Kojima     日付表示の統一(不具合№430)
    '　　　：2006/02/21 (Tue) 15:41:18 N.Kojima     一覧項目の並び順変更と項目の追加。(ﾕｰｻﾞｰ要望№0141)
    '　　　：2006/05/11 (Thu) 09:47:02 M.Miura      運用障害№758、不具合№3463対応(一覧表示時に編集中ﾌﾗｸﾞをｸﾘｱ)
    Private Sub prvvsfCarrierList_Disp(ByRef ltypCarrierList As CarrList)

        Dim llngCnt                 As Integer      'ｷｬﾘｱのｶｳﾝﾄ数

        Try

            '@ｷｬﾘｱ一覧取得日時
            lblNowDate.Text = Format$(Now(), CPstrDateFormat)
            
            'NSYS 不要イベント発生抑止
            RemoveHandler vsfCarrierList.BeforeRowColChange, AddressOf vsfCarrierList_BeforeRowColChange
            RemoveHandler vsfCarrierList.RowColChange, AddressOf vsfCarrierList_RowColChange

            With vsfCarrierList
                '@描画なし
                .Redraw =  False
                '@行の初期化
                .Rows.Count = .Rows.Fixed
                '@行数設定
                .Rows.Count = ltypCarrierList.lngCarrierListCnt + 1
            End With
            
            '@編集中ﾌﾗｸﾞをFalseにｸﾘｱ
            mblnEditFlag = False
            
            '@件数表示
            lblCarrierCnt.Text = ltypCarrierList.lngCarrierListCnt
            
            '@ﾃﾞｰﾀ表示
            llngCnt = 1
            Do While ltypCarrierList.lngCarrierListCnt >= llngCnt
                
                With ltypCarrierList.typCarrierList(llngCnt-1)
                    
                    vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColNo, llngCnt)                        '№
                    vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColCarrierID, .strCarrierId)           'ｷｬﾘｱID
                    vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColLotID, .strLotID)                   'ﾛｯﾄID
                    
                    '@ｷｬﾘｱ状態を判定して、現在位置を表示
                    Select Case .strCarrierStatID
                        '@ｷｬﾘｱ状態(搬送中、出庫中、入庫中)
                        Case CPstrCarrierStatMove, CPstrCarrierStatStkout, CPstrCarrierStatStkin
                            '@搬送中の場合
                            vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColPosition, _
                                CMstrArrow & CPstrSpace & .strDestName)                                       '搬送先
                            '@ここでｸﾘｱしないと出庫指示ﾎﾞﾀﾝ制御で不備あり
                            vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColPositionID, _
                                vbNullString)                                                                 '現在位置ID(ｷｬﾘｱ位置ID)
                            
                         Case Else
                            '@搬送中ではない場合
                            vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColPosition, _
                                .strCurrentPositionName)                                                      '現在位置
                                
                            vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColPositionID, _
                                .strCurrentPositionID)                                                        '現在位置ID(ｷｬﾘｱ位置ID)
                    End Select
                    
                    vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColCategoryName, .strCategoryName)     'ｶﾃｺﾞﾘ名
                    vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColCategoryID, .strCategoryID)         'ｶﾃｺﾞﾘID
                    vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColComments, .strComments)             'ｺﾒﾝﾄ
                    vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColCleanFlag, .strCleanFlag)           '要洗浄
                        
                    '@ｷｬﾘｱWF有無ﾌﾗｸﾞが"あり"の場合
                    If .strEmptyFlag = CMstrAri Then
                        vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColState, CMstrSekisai)            '状態(積載)
                    Else
                        vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColState, CMstrKara)               '状態(空)
                    End If
                    
                    '@最終更新日時が"0000/00/00 00:00:00"の場合
                    If .strEditTime = CMstrDefYmdHms Or .strEditTime = vbNullString Then
                        vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColEditTime, CMstrDefY2mdHms)      '最終更新日時
                    Else
                        vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColEditTime, _
                            Format$(CDate(.strEditTime), CPstrDateTimeY2MDHMS))                               '最終更新日時
                    End If

                    vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColTotalCnt, .strTotalUseCount)        '総回数
                    vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColCleanCnt, .strCleanCount)           '洗浄回数
                    vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColAfterCleanCnt, .strAfterCleanUseCount)  '洗浄後回数
                    
                    '@loder/unloder種別が"UNLOADER"の場合
                    If Trim(.strLdrUndrKind) = CMstrUnloder Then
                        vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColUnloderReserve, _
                            CMstrUnloderReserve)                                                               'Unloder予約状態(○)
                    Else
                        vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColUnloderReserve, _
                            vbNullString)                                                                      'Unloder非予約状態(Null)
                    End If
                    
                    '@ｷｬﾘｱ強制交換可能の場合
                     If .strCarrierMoveStat = CMstrCarrierMoveStatOK Then
                        vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColCarrierMoveStat, _
                            CMstrCarrierMoveStatDisp)                                                          'ｷｬﾘｱ交換可能(○)
                    Else
                        vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColCarrierMoveStat, _
                            vbNullString)                                                                      'ｷｬﾘｱ交不可(Null)
                    End If
                    
                    vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColCarrierStat, _
                        .strCarrierStatName)                                                                   'ｷｬﾘｱ状態
                    
                    If .strStartTime <> vbNullString Then
	                    vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColStartTime, _
	                        Format$(CDate(.strStartTime), CPstrDateTimeYMD))                                   '使用開始日
                    End If
                        
                    '@最終洗浄日時が"0000/00/00 00:00:00"の場合
                    If .strCreanTime = CMstrDefYmdHms Then
                        vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColCleanTime, CMstrDefY2mdHms)      '最終洗浄日時
                    Else If .strCreanTime = vbNullString Then
                        vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColCleanTime, vbNullString)         '最終洗浄日時
                    Else If .strCreanTime = CMstrNashi Then
                        vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColCleanTime, CMstrNashi)           '最終洗浄日時
                    Else
                        vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColCleanTime, _
                            Format$(CDate(.strCreanTime), CPstrDateTimeY2MDHMS))                               '最終洗浄日時
                    End If
                        
                    vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColVendor, _
                        .strVendorName)                                                                        'ﾍﾞﾝﾀﾞｰ

                    If .strProductionDate <> vbNullString Then
	                    vsfCarrierList.SetData(llngCnt, CMlngvsfCarrierListColProductionDate, _
	                        Format$(CDate(.strProductionDate), CPstrDateTimeYMD))                              '製造年月日
                    End If
                
                    llngCnt = llngCnt + 1
                End With
            Loop
            
            '@画面描画に負荷が掛かった時に画面に制御を戻す
            'DoEvents
            
            With vsfCarrierList
                '@ﾕｰｻﾞによりｿｰﾄされている場合
                If mtypChgSort.lngCnt > 0 Then
                    '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                    For llngCnt = 0 To mtypChgSort.lngCnt - 1
                        '@該当行をｿｰﾄ
                        .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                        .Sort(SortFlags.UseColSort,mtypChgSort.typChgSortList(llngCnt).lngCol)

                    Next llngCnt
                End If

                'NSYS 不要イベント発生抑止解除
                AddHandler vsfCarrierList.BeforeRowColChange, AddressOf vsfCarrierList_BeforeRowColChange
                AddHandler vsfCarrierList.RowColChange, AddressOf vsfCarrierList_RowColChange

                '@ｿｰﾄ検索用ｷｰがある場合
                If mtypChgSort.strKey <> vbNullString Then
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@ｷｬﾘｱID、使用開始日時が同じ場合
                        If .GetData(llngCnt, CMlngvsfCarrierListColCarrierID) & _
                           .GetData(llngCnt, CMlngvsfCarrierListColStartTime) = mtypChgSort.strKey Then
                            .Row = llngCnt
                            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                            Call pubVsfBeforeSort(vsfCarrierList, _
                                                  CMlngvsfCarrierListColCarrierID & vbTab & CMlngvsfCarrierListColStartTime)
                                                  
                            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                            Call pubVsfAfterSort(vsfCarrierList, _
                                                 CMlngvsfCarrierListColCarrierID & vbTab & CMlngvsfCarrierListColStartTime)
                                                 
                            Exit For
                        End If
                    Next llngCnt
                Else
                    '@先頭ﾍﾟｰｼﾞ設定
                    .TopRow = CMlngvsfGridTitleRow

                    '@ﾀｲﾄﾙ行に行設定
                    .Row = CMlngvsfGridTitleRow
                End If
            End With

            '@№に列設定
            vsfCarrierList.LeftCol = vsfCarrierList.Cols.Fixed
            '@№に列設定
            vsfCarrierList.Col = vsfCarrierList.Cols.Fixed

            '@ﾕｰｻﾞによる列幅変更されていない場合
            If mtypChgSort.blnChgWidth = False Then
                '@ｵｰﾄｻｲｽﾞ設定(ｺﾒﾝﾄのみ対象外)
                vsfCarrierList.AutoSizeCols(CMlngvsfCarrierListColNo, CMlngvsfCarrierListColCategoryID, 6)
                vsfCarrierList.AutoSizeCols(CMlngvsfCarrierListColCleanFlag, CMlngvsfCarrierListColProductionDate, 6)
            End If
            
            '@ｸﾞﾘｯﾄﾞ表示後処理
            Call pubVsfDisp(vsfCarrierList)
            
            '@直接表示
            vsfCarrierList.Redraw = True
                    
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCarrierList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnCleanInput_Check
    '機　能：洗浄入力ﾁｪｯｸ
    '引　数：lstrCarrier:ｷｬﾘｱID
    '戻り値：True:正常、False:異常
    '作成日：2004/06/30 (Wed) 10:53:40 N.Kojima
    '更新日：2004/06/30 (Wed) 10:53:40
    '備　考：ｷｬﾘｱ一覧Tab
    Private Function prvblnCleanInput_Check(ByRef lstrCarrier As String) As Boolean
        
        Try
            
            With vsfCarrierList
                '@ｸﾞﾘｯﾄのｷｬﾘｱIDを退避
                lstrCarrier = .GetData(.Row, CMlngvsfCarrierListColCarrierID)
                '@ｷｬﾘｱIDがない場合
                If lstrCarrier = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                    '@"キャリアIDが設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ｸﾞﾘｯﾄにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfCarrierList)
                    Exit Function
                End If
            End With
            
            prvblnCleanInput_Check = True
                
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnCleanInput_Check"     '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
                
        End Try
    End Function

    '関数名：prvCarrierTabMnt0_Init
    '機　能：ｷｬﾘｱﾒﾝﾃﾅﾝｽﾀﾌﾞ画面の初期化
    '引　数：lblnFrstFlg：True：初回、False：通常ｸﾘｱ
    '戻り値：なし
    '作成日：2004/02/13 (Fri) 15:30:00 K.Takano
    '更新日：2013/05/17 (Fri) 11:10:32 T.Oide
    '備　考：
    '　　　：2004/09/16 (Thu) 19:11:59 N.Kojima　   各種初期化処理追加(不具合№608)
    '　　　：2004/10/19 (Tue) 11:32:36 M.Miura　    CausesValidation設定を追加
    '　　　：2005/07/26 (Tue) 10:13:04 S.Deguchi    処理状態ｵﾌﾟｼｮﾝﾎﾞﾀﾝの初期化処理を追加
    '　　　：2005/11/21 (Mon) 09:11:53 N.Kasai      WF移動ﾀﾌﾞ空ｷｬﾘｱ一覧ﾎﾞﾀﾝ追加
    '　　　：2013/05/17 (Fri) 11:10:32 T.Oide       蒸着治具ODF対応
    Private Sub prvCarrierTabMnt0_Init(Optional ByVal lblnFrstFlg As Boolean = False)

        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim lstrEventName           As String           'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名

        Try
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "prvCarrierTabMnt0_Init"

            '@ｷｬﾘｱID初期化
            txtCarrierMnt.Text = vbNullString
            txtCarrierMnt2.Text = vbNullString
            
            '@ｷｬﾘｱID退避初期化
            mstrCarrier = vbNullString
            
            '@現在位置初期化
            lblCurrentPositionID.Text = vbNullString

            '@ｷｬﾘｱ状態初期化
            mstrCarrierID2Status = vbNullString
            
            '@装置種別初期化
            mstrWpTypeFlag = vbNullString
            
            '@移載予約ﾌﾗｸﾞ
            mstrWpCarryFlag = vbNullString
            
            '@TPAL設定
            mstrTpalClass = vbNullString
            
            '@ｷｬﾘｱｶﾃｺﾞﾘID
            pstrCarrierCategoryID = vbNullString
            
            '@大工程、小工程を初期化
            mstrLotId = vbNullString
            mstrOpID = vbNullString
            mstrStepID = vbNullString
            mblnCfFlag = False
            
            '@ATLASﾌﾛｰﾅﾝﾊﾞｰ初期化
            pstrAtlasFlowNumber = vbNullString
            
            '@Validateｲﾍﾞﾝﾄ無効
            tabCarrierMnt.CausesValidation = False
            cmdCarrierSelect.CausesValidation = False
            cmdCarrierSelect2.CausesValidation = False
            
            '@位置設定
            With cmbChangePosiotionID
                .Clear()
                .DispCols = CMlngCmbDispCol2                                  'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol0                                 '値取得列
                .GetCol = CMlngCmbGetCol1                                     '表示列
                .Font = New Font(.Font.FontFamily, _ 
                       CMlngCmbFontSize, .Font.Style, .Font.Unit)             'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, _
                       CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .ColAlignment(CMlngCmbGetCol0) = TextAlignEnum.LeftCenter     '左寄中央揃え
                .ColAlignment(CMlngCmbGetCol1) = TextAlignEnum.LeftCenter     '左寄中央揃え
                .DirectInput = False                                          '直接入力(Flase)
                .BackColor = SystemColors.Window                              '背景色
                .Enabled = False                                              'ﾛｯｸ
            End With
            
            '@ｷｬﾘｱ位置変更確定ﾎﾞﾀﾝﾛｯｸ
            cmdChgStocker.Enabled = False
            
            '@ｷｬﾘｱ交換確定ﾎﾞﾀﾝﾛｯｸ
            cmdExchange.Enabled = False
            
            '@統合先ｷｬﾘｱID最大桁数設定(6桁)
            txtCarrierMnt.ChrMaxByte = CMlngCarrierMaxByte
            '@交換先ｷｬﾘｱID最大桁数設定(6桁)
            txtCarrierMnt2.ChrMaxByte = CMlngCarrierMaxByte

            '@ﾌｫｰﾑ初期化
            '@初回のみﾃﾞﾌｫﾙﾄ設定
            If lblnFrstFlg = True Then
                '@ｷｬﾘｱID最大桁数設定(6桁)
                txtCarrierID2.ChrMaxByte = CMlngCarrierMaxByte
                '@ｷｬﾘｱID初期化
                txtCarrierID2.Text = vbNullString
            End If
            
            '@統合先ｷｬﾘｱIDﾛｯｸ
            txtCarrierMnt.Enabled = False
            '@空きｷｬﾘｱ選択ﾎﾞﾀﾝﾛｯｸ
            cmdCarrierSelect.Enabled = False

            '@交換先ｷｬﾘｱIDﾛｯｸ
            txtCarrierMnt2.Enabled = False
            '@空きｷｬﾘｱ選択ﾎﾞﾀﾝﾛｯｸ
            cmdCarrierSelect2.Enabled = False
            
            '@ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝ選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝを追加
            optOnline0.Checked = False
            optOnline1.Checked = False
            optOnline0.Enabled = False
            optOnline1.Enabled = False
            
            '@ｷｬﾘｱﾒﾝﾃｽﾛｯﾄﾏｯﾌﾟの初期化
            Call prvvsfMoveSlotMap_Init(vsfMoveSlotMap)
            Call prvvsfMoveSlotMap_Init(vsfMoveSlotMap2)
            Call prvvsfMoveSlotMap_Init(vsfMoveSlotMap3)
            Call prvvsfMoveSlotMap_Init(vsfMoveSlotMap4)
            Call prvvsfMoveSlotMap_Init(vsfMoveSlotMap5)
            Call prvvsfMoveSlotMap_Init(vsfMoveSlotMap6)
            Call prvvsfMoveSlotMap_Init(vsfMoveSlotMap7)
            
            '@基板工程の場合は治具ID列は非表示にする
            If pstrSBID = CPstrSBID1A0 Then
                vsfMoveSlotMap.Cols(CMlngvsfMoveSlotMapColJIGID).Visible = False
                vsfMoveSlotMap2.Cols(CMlngvsfMoveSlotMapColJIGID).Visible = False
                vsfMoveSlotMap3.Cols(CMlngvsfMoveSlotMapColJIGID).Visible = False
                vsfMoveSlotMap4.Cols(CMlngvsfMoveSlotMapColJIGID).Visible = False
                vsfMoveSlotMap5.Cols(CMlngvsfMoveSlotMapColJIGID).Visible = False
                vsfMoveSlotMap6.Cols(CMlngvsfMoveSlotMapColJIGID).Visible = False
                vsfMoveSlotMap7.Cols(CMlngvsfMoveSlotMapColJIGID).Visible = False
            End If
            
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCarrierTabMnt0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfMoveSlotMap_Init
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ初期化(ｷｬﾘｱﾒﾝﾃﾅﾝｽﾀﾌﾞ共通)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 14:16:34 M.Matsuura
    '更新日：2009/06/24 (Wed) 11:12:29 T.Oide
    '備　考：
    '　　　：2004/09/16 (Thu) 18:39:12 N.Kojima     ｷｬﾘｱ交換Tab追加に伴う修正
    '　　　：2004/09/29 (Wed) 09:12:29 S.Deguchi    ﾊﾞｯﾌｧ経由で描画"を追加
    Private Sub prvvsfMoveSlotMap_Init(ByVal lobjSlotMap As C1FlexGrid)

        Dim llngCnt As Integer  'ｶｳﾝﾄ

        Try

            '@WF統合元ｽﾛｯﾄﾏｯﾌﾟ表示の各カラムの幅、タイトルを設定
            With lobjSlotMap
                
                '@描画なし
                .Redraw = False

                RemoveHandler vsfMoveSlotMap.RowColChange, AddressOf vsfMoveSlotMap_RowColChange
                RemoveHandler vsfMoveSlotMap2.RowColChange, AddressOf vsfMoveSlotMap2_RowColChange

                '@ﾌﾟﾛﾊﾟﾃｨ初期値
                .Clear(ClearFlags.Content)
                .Cols.Count = CMlngvsfMoveSlotMapColWFStat + 1
                .Rows.Count = .Rows.Fixed

                .Rows.Count = CMlngvsfGridRows
                .Row = 0
                AddHandler vsfMoveSlotMap.RowColChange, AddressOf vsfMoveSlotMap_RowColChange
                AddHandler vsfMoveSlotMap2.RowColChange, AddressOf vsfMoveSlotMap2_RowColChange

                .SelectionMode = SelectionModeEnum.ListBox 
                .FocusRect = FocusRectEnum.Light
                .HighLight = HighLightEnum.WithFocus
                .Font = New Font(.Font.FontFamily, CMlngvsfGridFontSize, .Font.Style, .Font.Unit)
                .ScrollBars = ScrollBars.None 
                .FocusRect = FocusRectEnum.None 

                '@表示位置の設定
                .Cols(CMlngvsfMoveSlotMapColNo).TextAlign = TextAlignEnum.RightCenter       'ｽﾛｯﾄ№
                .Cols(CMlngvsfMoveSlotMapColWFID).TextAlign = TextAlignEnum.LeftCenter      'WFID
                '@↓2020/02/10 (Mon) 13:36:18 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfMoveSlotMapColGRB).TextAlign = TextAlignEnum.LeftCenter       'GRB
                '@↑2020/02/10 (Mon) 13:36:18 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfMoveSlotMapColJIGID).TextAlign = TextAlignEnum.LeftCenter     '治具ID
                

                '@ｸﾞﾘｯﾄﾞの表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfGridTitleRow, CMlngvsfMoveSlotMapColNo, CMlngvsfGridTitleRow, CMlngvsfMoveSlotMapColWFStat)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                     '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))       '背景色
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                       '文字位置
                headerStyle.Trimming  = StringTrimming.None                                              'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle


                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfGridTitleRow, CMlngvsfMoveSlotMapColNo, CMstrvsfMoveSlotMapTNo)        'ｽﾛｯﾄ№
                .SetData(CMlngvsfGridTitleRow, CMlngvsfMoveSlotMapColCheck, CMstrvsfMoveSlotMapTCheck)  'ﾁｪｯｸ
                .SetData(CMlngvsfGridTitleRow, CMlngvsfMoveSlotMapColWFID, CMstrvsfMoveSlotMapTWFID)    'WFID
                '@↓2020/02/10 (Mon) 13:36:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .SetData(CMlngvsfGridTitleRow, CMlngvsfMoveSlotMapColGRB, CMstrvsfMoveSlotMapTGRB)      'GRB
                '@↑2020/02/10 (Mon) 13:36:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .SetData(CMlngvsfGridTitleRow, CMlngvsfMoveSlotMapColJIGID, CMstrvsfMoveSlotMapTJIGID)  '治具ID
                .SetData(CMlngvsfGridTitleRow, CMlngvsfMoveSlotMapColWFStat, CMstrvsfMoveSlotMapTWFStat)'状態
                
                
                '@列幅の設定
                .Cols(CMlngvsfMoveSlotMapColNo).Width = CMlngvsfMoveSlotMapWNo          'ｽﾛｯﾄ№
                .Cols(CMlngvsfMoveSlotMapColCheck).Width = CMlngvsfMoveSlotMapWCheck    'ﾁｪｯｸ
                .Cols(CMlngvsfMoveSlotMapColWFID).Width = CMlngvsfMoveSlotMapWWFID      'WFID
                '@↓2020/02/10 (Mon) 13:37:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfMoveSlotMapColGRB).Width = CMlngvsfMoveSlotMapWGRB        'GRB
                '@↑2020/02/10 (Mon) 13:37:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfMoveSlotMapColJIGID).Width = CMlngvsfMoveSlotMapWJIGID    '治具ID
                
                Select Case .Name
                    '@WF統合元ｽﾛｯﾄﾏｯﾌﾟの場合
                    Case vsfMoveSlotMap.Name
                        .DrawMode = DrawModeEnum.OwnerDraw
                        .Cols(CMlngvsfMoveSlotMapColCheck).Width = CMlngvsfMoveSlotMapW0          'ﾁｪｯｸﾎﾞｯｸｽ(隠し列)
                        .Cols(CMlngvsfMoveSlotMapColWFStat).Width = CMlngvsfMoveSlotMapW0         '状態(隠し列)
                        
                    '@WF統合先ｽﾛｯﾄﾏｯﾌﾟの場合
                    Case vsfMoveSlotMap2.Name
                        .DrawMode = DrawModeEnum.OwnerDraw
                        .Cols.Count = CMlngvsfMoveSlotMapColBeforRow + 1
                        .Cols(CMlngvsfMoveSlotMapColCheck).Width = CMlngvsfMoveSlotMapW0          'ﾁｪｯｸﾎﾞｯｸｽ(隠し列)
                        .Cols(CMlngvsfMoveSlotMapColBeforRow).Width = CMlngvsfMoveSlotMapW0       '移動前行(隠し列)
                        .Cols(CMlngvsfMoveSlotMapColWFStat).Width = CMlngvsfMoveSlotMapWWFStat    '状態
                        
                    '@ｽﾛｯﾄ情報変更前ｽﾛｯﾄﾏｯﾌﾟの場合
                    Case vsfMoveSlotMap3.Name
                        .DrawMode = DrawModeEnum.OwnerDraw
                        .Cols(CMlngvsfMoveSlotMapColCheck).Width = CMlngvsfMoveSlotMapW0          'ﾁｪｯｸﾎﾞｯｸｽ(隠し列)
                        .Cols(CMlngvsfMoveSlotMapColWFStat).Width = CMlngvsfMoveSlotMapW0         '状態(隠し列)
                        
                    '@ｽﾛｯﾄ情報変更後ｽﾛｯﾄﾏｯﾌﾟの場合
                    Case vsfMoveSlotMap4.Name
                        .DrawMode = DrawModeEnum.OwnerDraw
                        .Cols.Count = CMlngvsfMoveSlotMapColBeforRow + 2
                        .Cols(CMlngvsfMoveSlotMapColCheck).Width = CMlngvsfMoveSlotMapW0          'ﾁｪｯｸﾎﾞｯｸｽ(隠し列)
                        .Cols(CMlngvsfMoveSlotMapColBeforRow).Width = CMlngvsfMoveSlotMapW0       '移動前行(隠し列)
                        .Cols(CMlngvsfMoveSlotMapColWFStat).Width = CMlngvsfMoveSlotMapWWFStat    '状態
                        .Cols(CMlngvsfMoveSlotMapColBeforJIG).Width = CMlngvsfMoveSlotMapW0       '変更前治具(隠し列)
                        
                    '@WF廃棄ｽﾛｯﾄﾏｯﾌﾟの場合
                    Case vsfMoveSlotMap5.Name
                        .SelectionMode = SelectionModeEnum.Row
                        .Cols(CMlngvsfMoveSlotMapColCheck).ImageAlign = TextAlignEnum.CenterCenter 'ﾁｪｯｸﾎﾞｯｸｽ
                        .Cols(CMlngvsfMoveSlotMapColCheck).Width = CMlngvsfMoveSlotMapWCheck      'ﾁｪｯｸﾎﾞｯｸｽ
                        .Cols(CMlngvsfMoveSlotMapColWFStat).Width = CMlngvsfMoveSlotMapWWFStat    '状態
                        
                    '@WF交換元ｽﾛｯﾄﾏｯﾌﾟの場合
                    Case vsfMoveSlotMap6.Name
                        .DrawMode = DrawModeEnum.OwnerDraw
                        .Cols(CMlngvsfMoveSlotMapColCheck).Width = CMlngvsfMoveSlotMapW0          'ﾁｪｯｸﾎﾞｯｸｽ(隠し列)
                        .Cols(CMlngvsfMoveSlotMapColWFStat).Width = CMlngvsfMoveSlotMapW0         '状態(隠し列)
                        
                    '@WF交換先ｽﾛｯﾄﾏｯﾌﾟの場合
                    Case vsfMoveSlotMap7.Name
                        .DrawMode = DrawModeEnum.OwnerDraw
                        .Cols.Count = CMlngvsfMoveSlotMapColBeforRow + 1
                        .Cols(CMlngvsfMoveSlotMapColCheck).Width = CMlngvsfMoveSlotMapW0          'ﾁｪｯｸﾎﾞｯｸｽ(隠し列)
                        .Cols(CMlngvsfMoveSlotMapColBeforRow).Width = CMlngvsfMoveSlotMapW0       '移動前行(隠し列)
                        .Cols(CMlngvsfMoveSlotMapColWFStat).Width = CMlngvsfMoveSlotMapWWFStat    '状態
                    
                    Case Else
                End Select

                '@ｽﾛｯﾄﾏｯﾌﾟの1行からｽﾛｯﾄﾏｯﾌﾟの最後まで
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    '@ｽﾛｯﾄ№設定
                    .SetData(llngCnt, CMlngvsfMoveSlotMapColNo, Format$(CMlngvsfGridRows - llngCnt, CPstrSlotNoFormat))
                Next llngCnt
                
                '@直接描画
                .Redraw = True

                
                '@WF統合ﾀﾌﾞのﾛｯｸ
                cmdMove.Enabled = False
                cmdMoveCancel.Enabled = False
                cmdMove.Enabled = False
                cmdMoveCancel.Enabled = False
                cmdWFMove.Enabled = False
                
                '@統合先ｽﾛｯﾄﾏｯﾌﾟではない場合
                If lobjSlotMap.Name <> vsfMoveSlotMap2.Name Then
                
                    '@ｽﾛｯﾄ情報変更ﾀﾌﾞのﾛｯｸ
                    cmdMove2.Enabled = False
                    cmdMoveCancel2.Enabled = False
                    cmdUpper.Enabled = False
                    cmdLower.Enabled = False
                    cmdWFMove2.Enabled = False
                
                    '@WF廃棄ﾀﾌﾞのﾛｯｸ
                    txtComment.Enabled = False
                    cmdCommentDown.Enabled = False
                    cmdCommentUp.Enabled = False
                    cmdWFScrap.Enabled = False
                    cmdWFAllSelect.Enabled = False
                    '@ｺﾒﾝﾄ初期化
                    With txtComment
                        .ChrMaxByte = CPlngLotCommentsMaxByte
                        .Text = vbNullString
                        '@ｺﾒﾝﾄ変更処理
                        Call txtComment_Change(txtComment, New EventArgs())
                    End With
                End If
                
                '@統合元ｽﾛｯﾄﾏｯﾌﾟの場合
                If lobjSlotMap.Name = vsfMoveSlotMap2.Name Then
                    '@ﾛｯｸ
                    vsfMoveSlotMap.Enabled = False
                End If
                
                '@ﾛｯｸ
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfMoveSlotMap_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfMoveSlotMap_Disp
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ表示(ｷｬﾘｱﾒﾝﾃﾅﾝｽﾀﾌﾞ共通)
    '引　数：ltypWaferList：ｷｬﾘｱWF情報構造体
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 11:54:18 M.Miura
    '更新日：2007/04/23 (Mon) 12:42:21 N.Kasai
    '備　考：
    '　　　：2004/09/16 (Thu) 20:05:46 N.Kojima　   ｷｬﾘｱ交換Tab処理追加(不具合№608)
    '　　　：2005/11/21 (Mon) 09:22:18 N.Kasai      WF移動ﾀﾌﾞ空ｷｬﾘｱ一覧ﾎﾞﾀﾝ追加
    '　　　：2007/04/23 (Mon) 12:42:21 N.Kasai      ｷｬﾘｱﾒﾝﾃﾀﾌﾞ動作統一
    '　　　：2009/09/10 (Thu) 17:13:34 T.Oide       №03772修正中のﾃｽﾄで既存の不具合発見修正
    Private Sub prvvsfMoveSlotMap_Disp(ByVal lobjSlotMap As C1FlexGrid, ByRef ltypWaferList As Waferlist)
        
        Dim llngCnt           As Integer   'ｶｳﾝﾄ
        Dim llngRCnt          As Integer   'ｶｳﾝﾄ
        Dim llngRow           As Integer   '行番号
        Dim cellRange         As CellRange 'NSYS セル範囲
        Dim newStyleGray      As CellStyle 'NSYS BackColor 薄い灰色
        Dim newStyleDarkGray  As CellStyle 'NSYS BackColor 濃い灰色
        Dim newStyleWhite     As CellStyle 'NSYS BackColor 濃い白

        Try

            With lobjSlotMap
                
                '@描画なし
                .Redraw = False

                newStyleGray = .Styles.Add("CustomStyle_BackColor_CPlngGray")
                newStyleGray.BackColor = SystemColors.ControlLight
                newStyleDarkGray = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyleDarkGray.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngGridDarkGray))
                newStyleWhite = .Styles.Add("CustomStyle_BackColor_vbWhite")
                newStyleWhite.BackColor = Color.White

                '@WF枚数分ﾙｰﾌﾟ
                For llngCnt = 1 To CMlngvsfGridRows - 1
                    cellRange  = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColCheck, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                    '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                    If ltypWaferList.strSlotSize < CMlngvsfGridRows - llngCnt Then
                        '@ｽﾛｯﾄ№は空白
                        .SetData(llngCnt, CMlngvsfMoveSlotMapColNo, vbNullString)
                        
                        '@ｽﾛｯﾄがｷｬﾘｱに存在しない場合はﾊﾞｯｸｶﾗｰを薄い灰色(ﾎﾞﾀﾝの表面の色)に変更する
                        cellRange.Style = newStyleGray
                    Else
                        '@WFが存在しない場合はﾊﾞｯｸｶﾗｰを濃い灰色に変更する
                        cellRange.Style = newStyleDarkGray
                    End If
                Next
                    
                '@ｷｬﾘｱWF情報ﾘｽﾄｶｳﾝﾄ
                llngRCnt = ltypWaferList.lngListCnt
            
                '@ｷｬﾘｱWF情報ﾘｽﾄがなくなるまで
                For llngCnt = 0 To llngRCnt - 1
                    If IsNumeric(ltypWaferList.typWfList(llngCnt).strSlotPosition) = True Then
                        '@行数
                        llngRow = ltypWaferList.typWfList(llngCnt).strSlotPosition
                        llngRow = CMlngvsfGridRows - llngRow
                        
                        
                        .SetCellCheck(llngRow, CMlngvsfMoveSlotMapColCheck, CheckEnum.Unchecked)  'ﾁｪｯｸﾎﾞｯｸｽ
                        
                        .SetData(llngRow, CMlngvsfMoveSlotMapColWFID, _
                            ltypWaferList.typWfList(llngCnt).strWfId)                   '@WFID
                            
                        '@↓2020/02/10 (Mon) 13:37:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .SetData(llngRow, CMlngvsfMoveSlotMapColGRB, _
                            ltypWaferList.typWfList(llngCnt).strGRBClass)               '@GRB
                        '@↑2020/02/10 (Mon) 13:37:36 Y.Yoneyama 「.Netへ反映未」 **************************************************

                        .SetData(llngRow, CMlngvsfMoveSlotMapColJIGID, _
                            ltypWaferList.typWfList(llngCnt).strjigId)                  '@治具ID
                            
                        .SetData(llngRow, CMlngvsfMoveSlotMapColWFStat, _
                            ltypWaferList.typWfList(llngCnt).strWFStatusName)           '@WFｽﾃｰﾀｽ(和名対応)
                            
                        '@濃い白に変更する
                        cellRange  = .GetCellRange(llngRow, CMlngvsfMoveSlotMapColCheck, llngRow, CMlngvsfMoveSlotMapColWFStat)
                        cellRange.Style = newStyleWhite
                    End If
                Next llngCnt

                '@組立てでCF_FLAG = 1、VB_FLAG = 0の場合WF_IDのｶﾗﾑを非表示にする
                If pstrSBID = CPstrSBID2A0 Then
                    If ltypWaferList.strCfFlag = CPstrOne And ltypWaferList.strLpFlag = CPstrZero Then
                        .Cols(CMlngvsfMoveSlotMapColWFID).Visible  = False
                    Else
                        .Cols(CMlngvsfMoveSlotMapColWFID).Visible  = True
                    End If
                End If
                
                '@直接描画
                .Redraw = True
            End With
            
            '@統合/分割元ｷｬﾘｱIDが中間在庫の場合
            If mstrCarrierID2Status = vbNullString Then
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝﾛｯｸ解除(WF統合Tab)
                cmdCarrierSelect.Enabled = True
                '@統合先ｷｬﾘｱIDﾛｯｸ解除(WF統合Tab)
                txtCarrierMnt.Enabled = True
            End If
            
            '@vsfMoveSlotMap3の場合,vsfMoveSlotMap4のｽﾛｯﾄﾏｯﾌﾟもｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合ｽﾛｯﾄ№は空白にする
            If lobjSlotMap.Equals(vsfMoveSlotMap3) Then
                '@ｽﾛｯﾄ情報変更後ｽﾛﾄﾏｯﾌﾟの初期化
                Call prvvsfMoveSlotMap_Init(vsfMoveSlotMap4)

                vsfMoveSlotMap4.Redraw = False
                '@基板工程の場合は治具ID列は非表示にする
                If pstrSBID = CPstrSBID1A0 Then
                    vsfMoveSlotMap4.Cols(CMlngvsfMoveSlotMapColJIGID).Visible = False
                ElseIf pstrSBID = CPstrSBID2A0 Then
                    '@組立てでCF_FLAG = 1、VB_FLAG = 0の場合WF_IDのｶﾗﾑを非表示にする
                    If ltypWaferList.strCfFlag = CPstrOne And ltypWaferList.strLpFlag = CPstrZero Then
                        vsfMoveSlotMap4.Cols(CMlngvsfMoveSlotMapColWFID).Visible  = False
                    Else
                        vsfMoveSlotMap4.Cols(CMlngvsfMoveSlotMapColWFID).Visible  = True
                    End If
                End If

                Dim newStyleSlotMap4 As CellStyle = vsfMoveSlotMap4.Styles.Add("CustomStyle_BackColor_CPlngGray")
                newStyleSlotMap4.BackColor  = SystemColors.ControlLight
                '@WF枚数分ﾙｰﾌﾟ
                For llngCnt = 1 To CMlngvsfGridRows - 1
                    '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                    If ltypWaferList.strSlotSize < CMlngvsfGridRows - llngCnt Then
                        '@ｽﾛｯﾄ№は空白
                        vsfMoveSlotMap4.SetData(llngCnt, CMlngvsfMoveSlotMapColNo, vbNullString)
                            
                        '@ｽﾛｯﾄがｷｬﾘｱに存在しない場合はﾊﾞｯｸｶﾗｰを灰色(ﾎﾞﾀﾝの表面の色)に変更する
                        cellRange = vsfMoveSlotMap4.GetCellRange(llngCnt, CMlngvsfMoveSlotMapColCheck, _
                                                                    llngCnt, CMlngvsfMoveSlotMapColBeforJIG)
                        cellRange.Style = newStyleSlotMap4
                    End If
                Next
                vsfMoveSlotMap4.Redraw = True
            ElseIf lobjSlotMap.Equals(vsfMoveSlotMap) Then
                If pstrSBID = CPstrSBID2A0 Then
                    vsfMoveSlotMap2.Redraw = False
                    '@組立てでCF_FLAG = 1、VB_FLAG = 0の場合WF_IDのｶﾗﾑを非表示にする
                    If ltypWaferList.strCfFlag = CPstrOne And ltypWaferList.strLpFlag = CPstrZero Then
                        vsfMoveSlotMap2.Cols(CMlngvsfMoveSlotMapColWFID).Visible  = False
                    Else
                        vsfMoveSlotMap2.Cols(CMlngvsfMoveSlotMapColWFID).Visible  = True
                    End If
                    vsfMoveSlotMap2.Redraw = True
                End If
            ElseIf lobjSlotMap.Equals(vsfMoveSlotMap6) Then
                If pstrSBID = CPstrSBID2A0 Then
                    vsfMoveSlotMap7.Redraw = False
                    '@組立てでCF_FLAG = 1、VB_FLAG = 0の場合WF_IDのｶﾗﾑを非表示にする
                    If ltypWaferList.strCfFlag = CPstrOne And ltypWaferList.strLpFlag = CPstrZero Then
                        vsfMoveSlotMap7.Cols(CMlngvsfMoveSlotMapColWFID).Visible  = False
                    Else
                        vsfMoveSlotMap7.Cols(CMlngvsfMoveSlotMapColWFID).Visible  = True
                    End If
                    vsfMoveSlotMap7.Redraw = True
                End If
            End If

             '@WF移載予約の場合
            If mstrWpCarryFlag = "1" Then
                '@ｽﾛｯﾄﾏｯﾌﾟ使用不可
                lobjSlotMap.Enabled = False
            Else
                Select Case lobjSlotMap.Name
                    '@変更前ｽﾛｯﾄﾏｯﾌﾟの場合
                    Case vsfMoveSlotMap3.Name
                        
                        '@状態が"作業待ち","作業終了","ﾛｯﾄ終了","送品待ち"等の場合のみ処理
                        '@後処理追加、H/Wの場合のみ処理中可
                        Select Case mstrCarrierID2Status
                            Case vbNullString, _
                                 CMstrRelatedLotStatus1D, _
                                 CMstrRelatedLotStatus0, _
                                 CMstrRelatedLotStatus4, _
                                 CMstrRelatedLotStatus5, _
                                 CMstrRelatedLotStatus9, _
                                 CMstrRelatedLotStatus3
                            
                            Case CMstrRelatedLotStatus2
                                '@処理中の場合H/W装置の場合使用可
                                If mstrWpTypeFlag <> "0" Then
                                    Exit Sub
                                End If
                            Case Else
                                '@上記以外の場合は操作不可
                                Exit Sub
                        End Select
                        
                        '@ｽﾛｯﾄ情報変更ｽﾛﾄﾏｯﾌﾟのﾛｯｸ解除
                        vsfMoveSlotMap3.Enabled = True
                        vsfMoveSlotMap4.Enabled = True
            
                    '@廃棄ｽﾛｯﾄﾏｯﾌﾟの場合
                    Case vsfMoveSlotMap5.Name
                                    
                        '@ﾛｯﾄとの紐付けなし(中間在庫&ﾛｯﾄ終了)
                        If mstrCarrierID2Status = vbNullString Or _
                           mstrCarrierID2Status = CMstrRelatedLotStatus9 Then
                           
                            cmdWFAllSelect.Enabled = True
                            '@ｽﾛｯﾄ情報変更ｽﾛﾄﾏｯﾌﾟのﾛｯｸ解除
                            vsfMoveSlotMap5.Enabled = True
                            '@WF廃棄ﾛｯｸ解除
                            txtComment.Enabled = True
                        
                        End If
                    
                    '@ｷｬﾘｱ交換の場合
                    Case vsfMoveSlotMap6.Name
                        
                        '@状態からﾎﾞﾀﾝ制御
                        '@状態が"作業待ち","作業終了","ﾛｯﾄ終了","送品待ち"等の場合のみ処理
                        Select Case mstrCarrierID2Status
                            Case vbNullString, _
                                 CMstrRelatedLotStatus1D, _
                                 CMstrRelatedLotStatus0, _
                                 CMstrRelatedLotStatus4, _
                                 CMstrRelatedLotStatus5, _
                                 CMstrRelatedLotStatus9
                            Case Else
                                '@上記以外の場合は操作不可
                                Exit Sub
                        End Select
                        
                        '@交換先ｷｬﾘｱIDﾛｯｸ解除(ｷｬﾘｱ交換Tab)
                        txtCarrierMnt2.Enabled = True
                        '@空きｷｬﾘｱ選択ﾎﾞﾀﾝﾛｯｸ解除(ｷｬﾘｱ交換Tab)
                        cmdCarrierSelect2.Enabled = True
                End Select
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfMoveSlotMap_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnSlotMap_Get
    '機　能：WF枚数取得(ｷｬﾘｱﾒﾝﾃﾅﾝｽﾀﾌﾞ共通)
    '引　数：なし
    '戻り値：WF枚数
    '作成日：2004/04/07 (Wed) 09:18:21 N.Kasai
    '更新日：2005/11/18 (Fri) 16:56:14 N.Kasai
    '備　考：
    '　　　：2005/11/18 (Fri) 16:56:14 N.Kasai  WF部分廃棄機能追加
    Private Function prvblnSlotMap_Get(ByVal lobjSlotMap As Object) As Integer

        Dim llngCnt As Integer    'ｶｳﾝﾄ
        Dim llngWFcnt As Integer  'ｶｳﾝﾄ

        Try

            Select Case lobjSlotMap.Name
            
                Case "vsfMoveSlotMap5"
            
                    '@ｽﾛｯﾄﾏｯﾌﾟの件数ﾁｪｯｸ
                    With lobjSlotMap
                    
                        '@ｽﾛｯﾄﾏｯﾌﾟの値をﾁｪｯｸ
                        For llngCnt = 1 To .Rows.Count - 1
                            '@空白以外の場合
                            If .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                            
                                '@ﾁｪｯｸ済みのWFの場合
                                If .GetCellCheck(llngCnt, CMlngvsfMoveSlotMapColCheck) = CheckEnum.Checked Then
                                    llngWFcnt = llngWFcnt + 1
                                End If
                                
                            End If
                        Next llngCnt
                    End With
                    
                Case Else
                
                    '@ｽﾛｯﾄﾏｯﾌﾟの件数ﾁｪｯｸ
                    With lobjSlotMap
                        '@ｽﾛｯﾄﾏｯﾌﾟの値をﾁｪｯｸ
                        For llngCnt = 1 To .Rows.Count - 1
                            '@空白以外の場合
                            If .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                                llngWFcnt = llngWFcnt + 1
                            End If
                        Next llngCnt
                    End With
            End Select
            
            '@WF枚数格納
            prvblnSlotMap_Get = llngWFcnt

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnSlotMap_Get"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnWFMove2Input_Chk
    '機　能：WF廃棄、ｽﾛｯﾄ位置変更入力確認
    '引　数：なし
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/29 (Mon) 15:34:29 N.Kasai
    '更新日：2004/07/07 (Wed) 13:24:01 N.Kojima
    '備　考：
    Private Function prvblnWFMove2Input_Chk() As Boolean

        Try

            prvblnWFMove2Input_Chk = False
            
            With Me
                
                '@ｷｬﾘｱIDの入力ﾁｪｯｸ
                If .txtCarrierID2.Text = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                    '@"キャリアIDが設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(.txtCarrierID2)
                    Exit Function
                End If
                
                '@ｷｬﾘｱIDの桁ﾁｪｯｸ
                If LenB(txtCarrierID2.Text) < CMlngCarrierMaxByte Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                    '@"キャリアIDは6桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(txtCarrierID2)
                    Exit Function
                End If
                
                '@入力OK
                prvblnWFMove2Input_Chk = True
            
            End With
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnWFMove2Input_Chk"     '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvvsfMoveSlotMap2_Disp
    '機　能：ｷｬﾘｱ統合先ｽﾛｯﾄﾏｯﾌﾟ表示
    '引　数：ltypCarrSlotlist：ｷｬﾘｱWF情報構造体
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 16:17:00 N.Kojima
    '更新日：2009/06/24 (Wed) 15:29:24 T.Oide
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)
    Private Sub prvvsfMoveSlotMap2_Disp(ByRef ltypWaferList As Waferlist)
        
        Dim llngCnt     As Integer  'ｶｳﾝﾄ
        Dim llngRCnt    As Integer  'ｶｳﾝﾄ
        Dim llngRow     As Integer  '行番号
        Dim cellRange         As CellRange 'NSYS セル範囲
        Dim newStyleGray      As CellStyle 'NSYS BackColor 薄い灰色
        Dim newStyleGridGray  As CellStyle 'NSYS BackColor 背景色（灰）

        Try

            With vsfMoveSlotMap2

                newStyleGray = .Styles.Add("CustomStyle_BackColor_CPlngGray")
                newStyleGray.BackColor  = SystemColors.ControlLight
                newStyleGridGray = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                newStyleGridGray.BackColor  = ColorTranslator.FromWin32(Convert.ToInt32(CPlngGridGray))

                '@WF枚数分ﾙｰﾌﾟ
                For llngCnt = 1 To CMlngvsfGridRows - 1
                    '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                    If ltypWaferList.strSlotSize < CMlngvsfGridRows - llngCnt Then
                        '@ｽﾛｯﾄ№は空白
                        .SetData(llngCnt, CMlngvsfMoveSlotMapColNo, vbNullString)
                        
                        '@ｽﾛｯﾄがｷｬﾘｱに存在しない場合はﾊﾞｯｸｶﾗｰを灰色(ﾎﾞﾀﾝの表面の色)に変更する
                        cellRange = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                        cellRange.Style = newStyleGray
                    End If
                Next
                '@ｷｬﾘｱWF情報ﾘｽﾄｶｳﾝﾄ
                llngRCnt = ltypWaferList.lngListCnt
            
                '@ｷｬﾘｱWF情報ﾘｽﾄがなくなるまで
                For llngCnt = 0 To llngRCnt - 1
                    If IsNumeric(ltypWaferList.typWfList(llngCnt).strSlotPosition) = True Then
                        '@行数
                        llngRow = ltypWaferList.typWfList(llngCnt).strSlotPosition
                        llngRow = CMlngvsfGridRows - llngRow
                        .SetData(llngRow, CMlngvsfMoveSlotMapColWFID, _
                            ltypWaferList.typWfList(llngCnt).strWfId)                   '@WFID
                            
                        '@↓2020/02/10 (Mon) 13:38:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .SetData(llngRow, CMlngvsfMoveSlotMapColGRB, _
                            ltypWaferList.typWfList(llngCnt).strGRBClass)               '@GRB
                        '@↑2020/02/10 (Mon) 13:38:13 Y.Yoneyama 「.Netへ反映未」 **************************************************

                        .SetData(llngRow, CMlngvsfMoveSlotMapColJIGID, _
                            ltypWaferList.typWfList(llngCnt).strjigId)                  '@治具ID
                            
                        .SetData(llngRow, CMlngvsfMoveSlotMapColWFStat, _
                            ltypWaferList.typWfList(llngCnt).strWFStatusName)           '@WFｽﾃｰﾀｽ(和名対応)
                            
                        cellRange = .GetCellRange(llngRow, CMlngvsfMoveSlotMapColWFID, llngRow, CMlngvsfMoveSlotMapColWFStat)
                        cellRange.Style = newStyleGridGray                              '背景色（灰）

                    End If
                Next llngCnt
                
                '@ﾛｯｸ解除
                vsfMoveSlotMap.Enabled = True
                .Enabled = True
                
                '@統合元ｽﾛｯﾄﾏｯﾌﾟが有効な場合
                If vsfMoveSlotMap.Enabled = True Then
                    '@統合元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfMoveSlotMap)
                End If
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfMoveSlotMap2_Disp"    '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMoveSlotMap_RowColChange
    '機　能：統合元ｽﾛｯﾄﾏｯﾌﾟｾﾙ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 10:49:24 N.Kojima
    '更新日：2005/01/05 (Wed) 13:44:30 H.Wajima
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)
    '　　　：2005/01/05 (Wed) 13:44:30 H.Wajima     統合元ｽﾛｯﾄﾏｯﾌﾟ 選択処理
    Private Sub vsfMoveSlotMap_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMoveSlotMap.RowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfMoveSlotMap.Rows.Count <= vsfMoveSlotMap.Rows.Fixed Then
                Return
            End If
            
            '@統合元ｽﾛｯﾄﾏｯﾌﾟ選択処理
            Call prvvsfMoveSlotMapSelect_Proc()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMoveSlotMap_RowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMoveSlotMap2_RowColChange
    '機　能：統合先ｽﾛｯﾄﾏｯﾌﾟｾﾙ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 10:53:16 N.Kojima
    '更新日：2005/01/05 (Wed) 13:47:34 H.Wajima
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)
    '　　　：2005/01/05 (Wed) 13:47:34 H.Wajima
    Private Sub vsfMoveSlotMap2_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMoveSlotMap2.RowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfMoveSlotMap2.Rows.Count <= vsfMoveSlotMap2.Rows.Fixed Then
                Return
            End If

            '@統合先ｽﾛｯﾄﾏｯﾌﾟ選択処理
            Call prvvsfMoveSlotMap2Select_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMoveSlotMap2_RowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfMoveSlotMapCancel_Disp
    '機　能：統合元ｽﾛｯﾄﾏｯﾌﾟ復元処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 12:01:12 N.Kojima
    '更新日：2004/07/05 (Mon) 12:01:12
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)
    Private Sub prvvsfMoveSlotMapCancel_Disp()
        
        Dim lstrWFID1       As String     '統合元WFID
        Dim lstrWFID2       As String     '統合先WFID
        Dim llngBackColor   As Color      'ﾊﾞｯｸｶﾗｰ
        Dim llngCnt         As Integer    'ｶｳﾝﾄ
        Dim llngRow2        As Integer    '統合元選択行

        Try
            
            With vsfMoveSlotMap2
                
                '@最終行まで
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    '@統合先WFID
                    lstrWFID2 = .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                    '@統合元WFID
                    lstrWFID1 = vsfMoveSlotMap.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                    '@統合先ﾊﾞｯｸｶﾗｰ
                    llngBackColor = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID).StyleDisplay.BackColor
            
                    '@統合先に統合元のWFIDがある場合
                    If lstrWFID2 <> vbNullString And llngBackColor <> ColorTranslator.FromWin32(CPlngGridGray) Then
                        '@移動前の行取得
                        If IsNumeric(.GetData(llngCnt, CMlngvsfMoveSlotMapColBeforRow)) = True Then
                            llngRow2 = .GetData(llngCnt, CMlngvsfMoveSlotMapColBeforRow)
                            vsfMoveSlotMap.SetData(llngRow2, CMlngvsfMoveSlotMapColWFID, lstrWFID2)
                            vsfMoveSlotMap.SetData(llngRow2, CMlngvsfMoveSlotMapColWFStat, .GetData(llngCnt, CMlngvsfMoveSlotMapColWFStat))
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColWFID, vbNullString)
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColWFStat, vbNullString)
                        End If
                    End If
                Next llngCnt
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfMoveSlotMapCancel_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnWFMoveInput_Chk
    '機　能：WF統合入力確認
    '引　数：なし
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/29 (Mon) 15:34:29 N.Kasai
    '更新日：2004/03/29 (Mon) 15:34:29
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)
    Private Function prvblnWFMoveInput_Chk() As Boolean

        Try

            prvblnWFMoveInput_Chk = False
            
            With Me
                
                '@統合元ｷｬﾘｱIDの入力ﾁｪｯｸ
                If .txtCarrierID2.Text = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                    '@"キャリアIDが設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@統合元ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(.txtCarrierID2)
                    Exit Function
                End If
                
                '@統合元ｷｬﾘｱIDの桁ﾁｪｯｸ
                If LenB(txtCarrierID2.Text) < CMlngCarrierMaxByte Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                    '@"キャリアIDは6桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@統合元ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrierID2)
                    Exit Function
                End If
                
                '@統合先ｷｬﾘｱIDの入力ﾁｪｯｸ
                If .txtCarrierMnt.Text = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                    '@"キャリアIDが設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@統合先ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(.txtCarrierMnt)
                    Exit Function
                End If
                
                '@統合先ｷｬﾘｱIDの桁ﾁｪｯｸ
                If LenB(txtCarrierMnt.Text) < CMlngCarrierMaxByte Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                    '@"キャリアIDは6桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@統合先ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrierMnt)
                    Exit Function
                End If
                
                '@入力OK
                prvblnWFMoveInput_Chk = True
            
            End With
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnWFMoveInput_Chk"      '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvWFMove_Set
    '機　能：WF統合確定ﾎﾞﾀﾝ制御
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 13:33:21 N.Kojima
    '更新日：2004/07/05 (Mon) 13:33:21
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(WF統合)
    Private Sub prvWFMove_Set()
        
        Dim lstrWFID2       As String     '統合先WFID
        Dim llngBackColor   As Color      'ﾊﾞｯｸｶﾗｰ
        Dim llngCnt         As Integer    'ｶｳﾝﾄ

        Try
            
            '@ｷｬﾘｱの状態が同じ場合
            If mstrCarrierID2Status = mstrCarrierID3Status Then
                Select Case mstrCarrierID2Status
                    Case vbNullString, CMstrRelatedLotStatus1D
                    '@状態が流動外(Null)の場合のみ可能
                    
                    Case Else
                    '@上記以外の場合は確定ﾎﾞﾀﾝ使用不可
                        Exit Sub
                End Select
            Else
                '@状態が異なる場合には確定ﾎﾞﾀﾝ使用不可
                Exit Sub
            End If
            
            With vsfMoveSlotMap2
                '@最終行まで
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    '@統合先WFID
                    lstrWFID2 = .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                    '@統合先ﾊﾞｯｸｶﾗｰ
                    llngBackColor = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID).StyleDisplay.BackColor
            
                    '@統合先に統合元のWFIDがある場合
                    If lstrWFID2 <> vbNullString And llngBackColor <> ColorTranslator.FromWin32(CPlngGridGray) Then
                        '@確定ﾎﾞﾀﾝ解除
                        cmdWFMove.Enabled = True
                        Exit Sub
                    End If
                Next llngCnt
            End With
            
            '@確定ﾎﾞﾀﾝﾛｯｸ
            cmdWFMove.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWFMove_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWFMove2_Set
    '機　能：ｽﾛｯﾄ情報変更確定ﾎﾞﾀﾝ制御
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 14:36:30 M.Miura
    '更新日：2007/04/18 (Wed) 10:32:19 N.Kasai
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｽﾛｯﾄ情報変更)Tab
    '　　　：2007/04/18 (Wed) 10:32:19 N.Kasai  処理中(H/Wのみ)後処理でもｽﾛｯﾄ情報変更可能(№01846)
    '　　　：2009/09/10 (Thu) 17:13:34 T.Oide   №03772修正中のﾃｽﾄで既存の不具合発見修正
    Private Sub prvWFMove2_Set()
        
        Dim lstrWFID        As String     'WFID
        Dim llngCnt         As Integer    'ｶｳﾝﾄ

        Try
            
            '@移載予約中の場合は不可
            If mstrWpCarryFlag <> 0 Then
                Exit Sub
            End If
            
            '@状態が"作業待ち","作業終了","ﾛｯﾄ終了","送品待ち"等の場合のみ処理
            '@後処理追加、H/Wの場合のみ処理中可
            Select Case mstrCarrierID2Status
                Case vbNullString, _
                     CMstrRelatedLotStatus1D, _
                     CMstrRelatedLotStatus0, _
                     CMstrRelatedLotStatus4, _
                     CMstrRelatedLotStatus5, _
                     CMstrRelatedLotStatus9, _
                     CMstrRelatedLotStatus3
                
                Case CMstrRelatedLotStatus2
                    '@処理中の場合H/W装置の場合使用可
                    If mstrWpTypeFlag <> "0" Then
                        Exit Sub
                    End If
                
                Case Else
                    '@上記以外の場合は確定ﾎﾞﾀﾝ使用不可
                    Exit Sub
            End Select
            
            With vsfMoveSlotMap4
                '@最終行まで
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    '@変更前WFID
                    lstrWFID = .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
            
                    '@変更後ｸﾞﾘｯﾄﾞに変更前ｸﾞﾘｯﾄﾞのWFIDがある場合
                    If lstrWFID <> vbNullString Then
                        Exit For
                    End If
                Next llngCnt
                
                '@WFが1枚もない場合
                If llngCnt >= .Rows.Count Then
                    '@確定ﾎﾞﾀﾝﾛｯｸ
                    cmdWFMove2.Enabled = False
                    '@上詰、下詰ﾎﾞﾀﾝﾛｯｸ
                    cmdUpper.Enabled = False
                    cmdLower.Enabled = False
                    Exit Sub
                End If
            End With
            
            '@上詰、下詰ﾎﾞﾀﾝﾛｯｸ解除
            cmdUpper.Enabled = True
            cmdLower.Enabled = True
            
            With vsfMoveSlotMap3
                '@最終行まで
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    '@変更前WFID
                    lstrWFID = .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
            
                    '@変更後ｸﾞﾘｯﾄﾞに変更前ｸﾞﾘｯﾄﾞのWFIDがある場合
                    If lstrWFID <> vbNullString Then
                        '@確定ﾎﾞﾀﾝﾛｯｸ
                        cmdWFMove2.Enabled = False
                        Exit Sub
                    End If
                Next llngCnt
                
            End With
            
            '@確定ﾎﾞﾀﾝﾛｯｸ解除
            cmdWFMove2.Enabled = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWFMove2_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnChgStockerInput_Chk
    '機　能：ｷｬﾘｱ位置変更入力確認
    '引　数：なし
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/29 (Mon) 15:34:29 N.Kasai
    '更新日：2004/07/07 (Wed) 11:53:20 N.Kojima
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｷｬﾘｱ位置情報変更)Tab
    Private Function prvblnChgStockerInput_Chk() As Boolean

        Try

            prvblnChgStockerInput_Chk = False
            
            With Me
                '@ｷｬﾘｱIDの入力ﾁｪｯｸ
                If .txtCarrierID2.Text = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                    '@"キャリアIDが設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(.txtCarrierID2)
                    Exit Function
                End If
                
                '@ｷｬﾘｱIDの桁ﾁｪｯｸ
                If LenB(txtCarrierID2.Text) < CMlngCarrierMaxByte Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                    '@"キャリアIDは6桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(txtCarrierID2)
                    Exit Function
                End If
                
                '@変更後位置ﾁｪｯｸ
                '@変更後位置IDがない場合
                If cmbChangePosiotionID.Value = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000I)
                    '@"ﾒｯｾｰｼﾞｺｰﾄﾞ：C_W0I%0$$変更後位置が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(cmbChangePosiotionID)
                    Exit Function
                End If
                
                '@入力OK
                prvblnChgStockerInput_Chk = True
            End With
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "prvblnChgStockerInput_Chk"      '処理名
                .strErrMessage = ""                             'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvblnExchangeInput_Chk
    '機　能：ｷｬﾘｱ交換入力確認
    '引　数：なし
    '戻り値：True：成功、False：失敗
    '作成日：2004/09/16 (Thu) 18:51:13 N.Kojima
    '更新日：2005/12/01 (Thu) 16:41:35 N.Kasai
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｷｬﾘｱ交換)
    '　　　：2005/12/01 (Thu) 16:41:35 N.Kasai      ｽﾛｯﾄ№ﾁｪｯｸ追加
    Private Function prvblnExchangeInput_Chk() As Boolean

        Dim llngCnt             As Integer      'ｶｳﾝﾄ
        Dim lblnExchangeFlag    As Boolean      'ｽﾛｯﾄ№ﾁｪｯｸﾌﾗｸﾞ
        Try

            prvblnExchangeInput_Chk = False
            
            With Me
                
                '@交換元ｷｬﾘｱIDの入力ﾁｪｯｸ
                If .txtCarrierID2.Text = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                    '@"キャリアIDが設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@交換元ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(.txtCarrierID2)
                    Exit Function
                End If
                
                '@交換元ｷｬﾘｱIDの桁ﾁｪｯｸ
                If LenB(txtCarrierID2.Text) < CMlngCarrierMaxByte Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                    '@"キャリアIDは6桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@交換元ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrierID2)
                    Exit Function
                End If
                
                '@交換先ｷｬﾘｱIDの入力ﾁｪｯｸ
                If .txtCarrierMnt2.Text = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                    '@"キャリアIDが設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@交換先ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(.txtCarrierMnt2)
                    Exit Function
                End If
                
                '@交換先ｷｬﾘｱIDの桁ﾁｪｯｸ
                If LenB(txtCarrierMnt2.Text) < CMlngCarrierMaxByte Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                    '@"キャリアIDは6桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@交換先ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrierMnt2)
                    Exit Function
                End If
                
                '@ﾌﾗｸﾞ初期化
                lblnExchangeFlag = False
                    
                '@ｽﾛｯﾄ№が存在しないのに確定ﾎﾞﾀﾝが押せるのを修正する
                For llngCnt = 1 To CMlngvsfGridRows - 1
                    '@ｽﾛｯﾄﾏｯﾌﾟが存在しない
                    If vsfMoveSlotMap7.GetData(llngCnt, CMlngvsfMoveSlotMapColNo) = vbNullString Then
                        '@ﾃﾞｰﾀがある場合
                        If vsfMoveSlotMap7.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                            '@ﾌﾗｸﾞをTrue
                            lblnExchangeFlag = True
                            Exit For
                        End If
                    End If
                Next llngCnt
                
                '@ｽﾛｯﾄ№ﾁｪｯｸ
                If lblnExchangeFlag = True Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007H)
                    '@"設定できないスロットにWFIDが設定されています。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@交換先ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrierMnt2)
                    Exit Function
                End If
                
                '@入力OK
                prvblnExchangeInput_Chk = True
            
            End With
            
            Exit Function

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "prvblnExchangeInput_Chk"      '処理名
                .strErrMessage = ""                             'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvvsfMoveSlotMap7_Disp
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ表示(ｷｬﾘｱ交換Tab)
    '引　数：ltypWaferList：ｷｬﾘｱWF情報構造体
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 20:05:46 N.Kojima
    '更新日：2004/09/16 (Thu) 20:05:46
    '備　考：
    Private Sub prvvsfMoveSlotMap7_Disp()
        
        Dim llngCnt             As Integer   'ｶｳﾝﾄ
        Dim lblnTpalMoveFlag    As Boolean   'TPALｷｬﾘｱ交換ﾌﾗｸﾞ
        Dim lblnReverseMoveFlag As Boolean   'SLOT反転ﾌﾗｸﾞ
        Dim lstrSlot            As String    'SLOT
        Dim cellRange6          As CellRange 'NSYS セル範囲
        Dim cellRange7          As CellRange 'NSYS セル範囲
        
        Try
            
            lblnTpalMoveFlag = False
            lblnReverseMoveFlag = False
            
            With vsfMoveSlotMap6
                
                '@無機用(特殊移戴)
                '@TPAL設定に左右貼合設定がある場合は移戴元SLOTをﾁｪｯｸする
                If mstrTpalClass = CPstrTpalJLeft Or mstrTpalClass = CPstrTpalJBatchLeft Or _
                   mstrTpalClass = CPstrTpalJRight Or mstrTpalClass = CPstrTpalJBatchRight Then
                              
                    '@無機の左右貼合を行う際はTPALを2回実施する
                    '@1回目のTPAL終了後に再度OPNE→FOUPへ移戴する処理である
                    '@1回目TPAL終了時は1,3,5,7,9SLOTからの移戴しかない
                    '@もう一度TPAL処理を行うのでTPAL前のSLOTへ移戴する
                    
                    '@WF枚数分ﾙｰﾌﾟ
                    For llngCnt = 1 To CMlngvsfGridRows - 1
                        
                        '@ｽﾛｯﾄNo取得
                        lstrSlot = .GetData(llngCnt, CMlngvsfMoveSlotMapColNo)
                        
                        Select Case lstrSlot
                        
                            '@該当SLOTにはWFがあるorない
                            Case "01", "03", "05", "07", "09"
                            
                            
                            '@その他SLOTにはWFがない
                            Case Else
                                
                                '@移戴元ｽﾛｯﾄﾏｯﾌﾟにはWF情報が無いこと
                                If .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) = vbNullString Then
                                    lblnTpalMoveFlag = True
                                
                                '@移戴元にWF情報がある場合は、TPAL移戴続行不可
                                Else
                                    lblnTpalMoveFlag = False
                                    Exit For
                                End If
                        End Select
                        
                        '@交換先ｽﾛｯﾄﾏｯﾌﾟをｸﾘｱ
                        cellRange7 = vsfMoveSlotMap7.GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                        vsfMoveSlotMap7.SetData(cellRange7, vbNullString)
                    Next
                    
                '@処理前移戴必須装置(特殊移戴)
                ElseIf mstrEqType = CPstrEqTypeBeforeMove Then
                
                    '@ﾎﾟｽﾄｷｭｱ、ｼｰﾙ銀点形成装置は処理前に移戴が必要
                    '@元SLOT(2,4,6,8,10)→先SLOT(10,8,6,4,2)の特殊移戴
                    
                    '@WF枚数分ﾙｰﾌﾟ
                    For llngCnt = 1 To CMlngvsfGridRows - 1
                        
                        '@ｽﾛｯﾄNo取得
                        lstrSlot = .GetData(llngCnt, CMlngvsfMoveSlotMapColNo)
                        
                        Select Case lstrSlot
                        
                            '@該当SLOTにはWFがあるorない
                            Case "02", "04", "06", "08", "10"
                            
                            
                            '@その他SLOTにはWFがない
                            Case Else
                                
                                '@移戴元ｽﾛｯﾄﾏｯﾌﾟにはWF情報が無いこと
                                If .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) = vbNullString Then
                                    lblnReverseMoveFlag = True
                                
                                '@移戴元にWF情報がある場合は、反転移戴続行不可
                                Else
                                    lblnReverseMoveFlag = False
                                    Exit For
                                End If
                        End Select
                        
                        '@交換先ｽﾛｯﾄﾏｯﾌﾟをｸﾘｱ
                        cellRange7 = vsfMoveSlotMap7.GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                        vsfMoveSlotMap7.SetData(cellRange7, vbNullString)
                    
                    Next
                End If
                
                '@無機用(特殊移戴)
                '@TPAL設定に左右貼合設定がある場合は交換先を変更する
                If lblnTpalMoveFlag Then
                    
                    '@WF枚数分ﾙｰﾌﾟ
                    For llngCnt = 1 To CMlngvsfGridRows - 1
                        
                        '@ｽﾛｯﾄNo取得
                        lstrSlot = .GetData(llngCnt, CMlngvsfMoveSlotMapColNo)
                        
                        Select Case lstrSlot
                        
                            '@SLOT:01→10へ移戴
                            Case "01"
                                '@交換元ｽﾛｯﾄﾏｯﾌﾟを交換先のｽﾛｯﾄﾏｯﾌﾟに移す
                                cellRange6 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7 = vsfMoveSlotMap7.GetCellRange(llngCnt - 9, CMlngvsfMoveSlotMapColWFID, llngCnt - 9, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7.Clip = cellRange6.Clip
                                
                            '@SLOT:03→08へ移戴
                            Case "03"
                                '@交換元ｽﾛｯﾄﾏｯﾌﾟを交換先のｽﾛｯﾄﾏｯﾌﾟに移す
                                cellRange6 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7 = vsfMoveSlotMap7.GetCellRange(llngCnt - 5, CMlngvsfMoveSlotMapColWFID, llngCnt - 5, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7.Clip = cellRange6.Clip
                                
                            '@SLOT:05→06へ移戴
                            Case "05"
                                '@交換元ｽﾛｯﾄﾏｯﾌﾟを交換先のｽﾛｯﾄﾏｯﾌﾟに移す
                                cellRange6 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7 = vsfMoveSlotMap7.GetCellRange(llngCnt - 1, CMlngvsfMoveSlotMapColWFID, llngCnt - 1, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7.Clip = cellRange6.Clip
                                
                            '@SLOT:07→04へ移戴
                            Case "07"
                                '@交換元ｽﾛｯﾄﾏｯﾌﾟを交換先のｽﾛｯﾄﾏｯﾌﾟに移す
                                cellRange6 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7 = vsfMoveSlotMap7.GetCellRange(llngCnt + 3, CMlngvsfMoveSlotMapColWFID, llngCnt + 3, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7.Clip = cellRange6.Clip
                                
                            '@SLOT:09→02へ移戴
                            Case "09"
                                '@交換元ｽﾛｯﾄﾏｯﾌﾟを交換先のｽﾛｯﾄﾏｯﾌﾟに移す
                                cellRange6 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7 = vsfMoveSlotMap7.GetCellRange(llngCnt + 7, CMlngvsfMoveSlotMapColWFID, llngCnt + 7, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7.Clip = cellRange6.Clip
                                
                        End Select
                                
                        '@交換元ｽﾛｯﾄﾏｯﾌﾟをｸﾘｱ
                        cellRange6 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                        .SetData(cellRange6, vbNullString)
                        
                    Next
                
                '@処理前移戴必須装置(特殊移戴)
                ElseIf lblnReverseMoveFlag Then
                
                    '@WF枚数分ﾙｰﾌﾟ
                    For llngCnt = 1 To CMlngvsfGridRows - 1
                        
                        '@ｽﾛｯﾄNo取得
                        lstrSlot = .GetData(llngCnt, CMlngvsfMoveSlotMapColNo)
                        
                        Select Case lstrSlot
                        
                            '@SLOT:02→10へ移戴
                            Case "02"
                                '@交換元ｽﾛｯﾄﾏｯﾌﾟを交換先のｽﾛｯﾄﾏｯﾌﾟに移す
                                cellRange6 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7 = vsfMoveSlotMap7.GetCellRange(llngCnt - 8, CMlngvsfMoveSlotMapColWFID, llngCnt - 8, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7.Clip = cellRange6.Clip
                                
                            '@SLOT:04→08へ移戴
                            Case "04"
                                '@交換元ｽﾛｯﾄﾏｯﾌﾟを交換先のｽﾛｯﾄﾏｯﾌﾟに移す
                                cellRange6 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7 = vsfMoveSlotMap7.GetCellRange(llngCnt - 4, CMlngvsfMoveSlotMapColWFID, llngCnt - 4, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7.Clip = cellRange6.Clip
                                
                            '@SLOT:06→06へ移戴
                            Case "06"
                                '@交換元ｽﾛｯﾄﾏｯﾌﾟを交換先のｽﾛｯﾄﾏｯﾌﾟに移す
                                cellRange6 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7 = vsfMoveSlotMap7.GetCellRange(llngCnt - 0, CMlngvsfMoveSlotMapColWFID, llngCnt - 0, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7.Clip = cellRange6.Clip
                                
                            '@SLOT:08→04へ移戴
                            Case "08"
                                '@交換元ｽﾛｯﾄﾏｯﾌﾟを交換先のｽﾛｯﾄﾏｯﾌﾟに移す
                                cellRange6 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7 = vsfMoveSlotMap7.GetCellRange(llngCnt + 4, CMlngvsfMoveSlotMapColWFID, llngCnt + 4, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7.Clip = cellRange6.Clip
                                
                            '@SLOT:10→02へ移戴
                            Case "10"
                                '@交換元ｽﾛｯﾄﾏｯﾌﾟを交換先のｽﾛｯﾄﾏｯﾌﾟに移す
                                cellRange6 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7 = vsfMoveSlotMap7.GetCellRange(llngCnt + 8, CMlngvsfMoveSlotMapColWFID, llngCnt + 8, CMlngvsfMoveSlotMapColWFStat)
                                cellRange7.Clip = cellRange6.Clip
                                
                        End Select
                                
                        '@交換元ｽﾛｯﾄﾏｯﾌﾟをｸﾘｱ
                        cellRange6 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                        .SetData(cellRange6, vbNullString)
                        
                    Next
                
                '@通常のｷｬﾘｱ交換(平行移戴)
                Else
                    '@WF枚数分ﾙｰﾌﾟ
                    For llngCnt = 1 To CMlngvsfGridRows - 1
                        '@交換元ｽﾛｯﾄﾏｯﾌﾟを交換先のｽﾛｯﾄﾏｯﾌﾟに移す
                        cellRange6 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                        cellRange7 = vsfMoveSlotMap7.GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                        cellRange7.Clip = cellRange6.Clip
                        
                        '@交換元ｽﾛｯﾄﾏｯﾌﾟをｸﾘｱ
                        cellRange6 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                        .SetData(cellRange6, vbNullString)

                    Next
                End If
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfMoveSlotMap7_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfMoveSlotMapCancel_Disp
    '機　能：交換元ｽﾛｯﾄﾏｯﾌﾟ復元処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/17 (Fri) 15:44:34 N.Kojima
    '更新日：2004/09/17 (Fri) 15:44:34
    '備　考：ｷｬﾘｱﾒﾝﾃﾅﾝｽ(ｷｬﾘｱ交換)
    Private Sub prvvsfMoveSlotMapCancel2_Disp()
        
        Dim lstrWFID1           As String    '交換元WFID
        Dim lstrWFID2           As String    '交換先WFID
        Dim llngBackColor       As Color     'ﾊﾞｯｸｶﾗｰ
        Dim llngCnt             As Integer   'ｶｳﾝﾄ
        Dim lblnTpalMoveFlag    As Boolean   'TPALｷｬﾘｱ交換ﾌﾗｸﾞ
        Dim lblnReverseMoveFlag As Boolean   'SLOT反転ﾌﾗｸﾞ
        Dim lstrSlot            As String    'SLOT
        Dim cellRange6          As CellRange 'NSYS セル範囲
        Dim cellRange7          As CellRange 'NSYS セル範囲
        
        Try
            
            lblnTpalMoveFlag = False
            lblnReverseMoveFlag = False
            
            With vsfMoveSlotMap7
                
                '@無機用(特殊移戴)
                '@TPAL設定に左右貼合設定がある場合は移戴元SLOTをﾁｪｯｸする
                If mstrTpalClass = CPstrTpalJLeft Or mstrTpalClass = CPstrTpalJBatchLeft Or _
                   mstrTpalClass = CPstrTpalJRight Or mstrTpalClass = CPstrTpalJBatchRight Then

                    '@最終行まで
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                
                        '@ｽﾛｯﾄNo取得
                        lstrSlot = .GetData(llngCnt, CMlngvsfMoveSlotMapColNo)
                            
                        Select Case lstrSlot
                            
                            '@該当SLOTにはWFがあるorない
                            Case "02", "04", "06", "08", "10"
                            
                            
                            '@その他SLOTにはWFがない
                            Case Else
                                
                                '@移戴先ｽﾛｯﾄﾏｯﾌﾟにはWF情報が無いこと
                                If .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) = vbNullString Then
                                    lblnTpalMoveFlag = True
                                
                                '@移戴元にWF情報がある場合は、TPAL移戴続行不可
                                Else
                                    lblnTpalMoveFlag = False
                                    Exit For
                                End If
                        End Select
                        
                    Next llngCnt
                    
                '@処理前移戴必須装置(特殊移戴)
                ElseIf mstrEqType = CPstrEqTypeBeforeMove Then
                
                    '@ﾎﾟｽﾄｷｭｱ、ｼｰﾙ銀点形成装置は処理前に移戴が必要
                    '@元SLOT(2,4,6,8,10)→先SLOT(10,8,6,4,2)の特殊移戴
                    
                    '@WF枚数分ﾙｰﾌﾟ
                    For llngCnt = 1 To CMlngvsfGridRows - 1
                        
                        '@ｽﾛｯﾄNo取得
                        lstrSlot = .GetData(llngCnt, CMlngvsfMoveSlotMapColNo)
                        
                        Select Case lstrSlot
                        
                            '@該当SLOTにはWFがあるorない
                            Case "02", "04", "06", "08", "10"
                            
                            
                            '@その他SLOTにはWFがない
                            Case Else
                                
                                '@移戴先ｽﾛｯﾄﾏｯﾌﾟにはWF情報が無いこと
                                If .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID) = vbNullString Then
                                    lblnReverseMoveFlag = True
                                
                                '@移戴元にWF情報がある場合は、反転移戴続行不可
                                Else
                                    lblnReverseMoveFlag = False
                                    Exit For
                                End If
                        End Select
                        
                    Next
                End If
                
                '@無機用(特殊移戴)
                '@TPAL設定に左右貼合設定がある場合は交換元を変更する
                If lblnTpalMoveFlag Then
                    
                    '@最終行まで
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        
                        '@交換先WFID
                        lstrWFID2 = .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                        '@交換元WFID
                        lstrWFID1 = vsfMoveSlotMap6.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                        '@交換先ﾊﾞｯｸｶﾗｰ
                        llngBackColor = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID).StyleDisplay.BackColor
                        
                        '@交換先に交換元のWFIDがある場合
                        If lstrWFID2 <> vbNullString And llngBackColor <> ColorTranslator.FromWin32(CPlngGridGray) Then
                            
                            '@ｽﾛｯﾄNo取得
                            lstrSlot = .GetData(llngCnt, CMlngvsfMoveSlotMapColNo)
                        
                            Select Case lstrSlot
                            
                                '@SLOT:10→01へ移戴
                                Case "10"
                                    '@交換先ｽﾛｯﾄﾏｯﾌﾟを交換元のｽﾛｯﾄﾏｯﾌﾟに移す
                                    cellRange7 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6 = vsfMoveSlotMap6.GetCellRange(llngCnt + 9, CMlngvsfMoveSlotMapColWFID, llngCnt + 9, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6.Clip = cellRange7.Clip
                                
                                '@SLOT:08→03へ移戴
                                Case "08"
                                    '@交換先ｽﾛｯﾄﾏｯﾌﾟを交換元のｽﾛｯﾄﾏｯﾌﾟに移す
                                    cellRange7 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6 = vsfMoveSlotMap6.GetCellRange(llngCnt + 5, CMlngvsfMoveSlotMapColWFID, llngCnt + 5, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6.Clip = cellRange7.Clip
                                
                                '@SLOT:06→05へ移戴
                                Case "06"
                                    '@交換先ｽﾛｯﾄﾏｯﾌﾟを交換元のｽﾛｯﾄﾏｯﾌﾟに移す
                                    cellRange7 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6 = vsfMoveSlotMap6.GetCellRange(llngCnt + 1, CMlngvsfMoveSlotMapColWFID, llngCnt + 1, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6.Clip = cellRange7.Clip
                                
                                '@SLOT:04→07へ移戴
                                Case "04"
                                    '@交換先ｽﾛｯﾄﾏｯﾌﾟを交換元のｽﾛｯﾄﾏｯﾌﾟに移す
                                    cellRange7 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6 = vsfMoveSlotMap6.GetCellRange(llngCnt - 3, CMlngvsfMoveSlotMapColWFID, llngCnt - 3, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6.Clip = cellRange7.Clip
                                
                                '@SLOT:02→09へ移戴
                                Case "02"
                                    '@交換先ｽﾛｯﾄﾏｯﾌﾟを交換元のｽﾛｯﾄﾏｯﾌﾟに移す
                                    cellRange7 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6 = vsfMoveSlotMap6.GetCellRange(llngCnt - 7, CMlngvsfMoveSlotMapColWFID, llngCnt - 7, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6.Clip = cellRange7.Clip
                                
                            End Select
                            
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColWFID, vbNullString)
                        
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColWFStat, vbNullString)
                        
                        End If
                    
                    Next llngCnt
                   
                '@処理前移戴必須装置(特殊移戴)
                ElseIf lblnReverseMoveFlag Then
                    
                    '@最終行まで
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        
                        '@交換先WFID
                        lstrWFID2 = .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                        '@交換元WFID
                        lstrWFID1 = vsfMoveSlotMap6.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                        '@交換先ﾊﾞｯｸｶﾗｰ
                        llngBackColor = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID).StyleDisplay.BackColor
                        
                        '@交換先に交換元のWFIDがある場合
                        If lstrWFID2 <> vbNullString And llngBackColor <> ColorTranslator.FromWin32(CPlngGridGray) Then
                            
                            '@ｽﾛｯﾄNo取得
                            lstrSlot = .GetData(llngCnt, CMlngvsfMoveSlotMapColNo)
                        
                            Select Case lstrSlot
                            
                                '@SLOT:10→02へ移戴
                                Case "10"
                                    '@交換先ｽﾛｯﾄﾏｯﾌﾟを交換元のｽﾛｯﾄﾏｯﾌﾟに移す
                                    cellRange7 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6 = vsfMoveSlotMap6.GetCellRange(llngCnt + 8, CMlngvsfMoveSlotMapColWFID, llngCnt + 9, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6.Clip = cellRange7.Clip
                                
                                '@SLOT:08→04へ移戴
                                Case "08"
                                    '@交換先ｽﾛｯﾄﾏｯﾌﾟを交換元のｽﾛｯﾄﾏｯﾌﾟに移す
                                    cellRange7 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6 = vsfMoveSlotMap6.GetCellRange(llngCnt + 4, CMlngvsfMoveSlotMapColWFID, llngCnt + 5, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6.Clip = cellRange7.Clip
                                
                                '@SLOT:06→06へ移戴
                                Case "06"
                                    '@交換先ｽﾛｯﾄﾏｯﾌﾟを交換元のｽﾛｯﾄﾏｯﾌﾟに移す
                                    cellRange7 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6 = vsfMoveSlotMap6.GetCellRange(llngCnt + 0, CMlngvsfMoveSlotMapColWFID, llngCnt + 1, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6.Clip = cellRange7.Clip
                                
                                '@SLOT:04→08へ移戴
                                Case "04"
                                    '@交換先ｽﾛｯﾄﾏｯﾌﾟを交換元のｽﾛｯﾄﾏｯﾌﾟに移す
                                    cellRange7 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6 = vsfMoveSlotMap6.GetCellRange(llngCnt - 4, CMlngvsfMoveSlotMapColWFID, llngCnt - 3, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6.Clip = cellRange7.Clip
                                
                                '@SLOT:02→10へ移戴
                                Case "02"
                                    '@交換先ｽﾛｯﾄﾏｯﾌﾟを交換元のｽﾛｯﾄﾏｯﾌﾟに移す
                                    cellRange7 = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6 = vsfMoveSlotMap6.GetCellRange(llngCnt - 8, CMlngvsfMoveSlotMapColWFID, llngCnt - 7, CMlngvsfMoveSlotMapColWFStat)
                                    cellRange6.Clip = cellRange7.Clip
                                
                            End Select
                            
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColWFID, vbNullString)
                        
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColWFStat, vbNullString)
                        
                        End If
                    
                    Next llngCnt
                
                '@通常のｷｬﾘｱ交換(平行移戴)
                Else
                    '@最終行まで
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@交換先WFID
                        lstrWFID2 = .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                        '@交換元WFID
                        lstrWFID1 = vsfMoveSlotMap6.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                        '@交換先ﾊﾞｯｸｶﾗｰ
                        llngBackColor = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID).StyleDisplay.BackColor
                        
                        '@交換先に交換元のWFIDがある場合
                        If lstrWFID2 <> vbNullString And llngBackColor <> ColorTranslator.FromWin32(CPlngGridGray) Then
                            vsfMoveSlotMap6.SetData(llngCnt, CMlngvsfMoveSlotMapColWFID, lstrWFID2) 'WF_ID
                            
                            '@↓2020/02/10 (Mon) 13:43:38 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            vsfMoveSlotMap6.SetData(llngCnt, CMlngvsfMoveSlotMapColGRB, _
                                .GetData(llngCnt, CMlngvsfMoveSlotMapColGRB))                       'GRB
                            '@↑2020/02/10 (Mon) 13:43:38 Y.Yoneyama 「.Netへ反映未」 **************************************************

                            vsfMoveSlotMap6.SetData(llngCnt, CMlngvsfMoveSlotMapColJIGID, _
                                .GetData(llngCnt, CMlngvsfMoveSlotMapColJIGID))                     '治具ID
                            vsfMoveSlotMap6.SetData(llngCnt, CMlngvsfMoveSlotMapColWFStat, _
                                .GetData(llngCnt, CMlngvsfMoveSlotMapColWFStat))                    '状態
                        
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColWFID, vbNullString)             'WF_ID削除
                            '@↓2020/02/10 (Mon) 13:44:06 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColGRB, vbNullString)              'GRB削除
                            '@↑2020/02/10 (Mon) 13:44:06 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColJIGID, vbNullString)            '治具ID削除
                            .SetData(llngCnt, CMlngvsfMoveSlotMapColWFStat, vbNullString)           '状態削除
                        End If
                    Next llngCnt
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfMoveSlotMapCancel2_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCarrierClean_Disp
    '機　能：ｷｬﾘｱ一覧最新表示(ｷｬﾘｱ指定)
    '引　数：ltypCarrierList：ｷｬﾘｱ一覧格納構造体
    '　　　：llngCarrierRow：値の反映行
    '戻り値：なし
    '作成日：2004/09/28 (Tue) 15:15:22 N.Kasai
    '更新日：2004/09/28 (Tue) 15:15:22
    '備　考：
    '　　　：2005/06/17 (Fri) 10:40:19 S.Deguchi    ﾌｫｰﾏｯﾄ変換ﾐｽを修正(MM/DD HH:MM ⇒ YY/MM/DD HH:MM:SS)
    Private Sub prvCarrierClean_Disp(ByRef ltypCarrierList As CarrList, ByVal llngCarrierRow As Integer)

        Try

            '@洗浄情報最新表示(必ず1件)
            With ltypCarrierList.typCarrierList(0)
                vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColPosition, _
                    .strCurrentPositionName)                                                           '現在位置
                
                If .strStartTime <> vbNullString Then
	                vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColStartTime, _
	                    Format$(CDate(.strStartTime), CPstrDateTimeYMD))                               '使用開始日
                End If
                
                '@最終洗浄日時が"0000/00/00 00:00:00"の場合
                If .strCreanTime = CMstrDefYmdHms Then
                    vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColCleanTime, _
                        CMstrDefY2mdHms)                                                               '最終洗浄日時
                Else If .strCreanTime = vbNullString Then
                        vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColCleanTime, _
                        vbNullString)                                                                  '最終洗浄日時
                Else If .strCreanTime = CMstrNashi Then
                    vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColCleanTime, CMstrNashi) '最終洗浄日時
                Else
                    vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColCleanTime, _
                        Format$(CDate(.strCreanTime), CPstrDateTimeY2MDHMS))                           '最終洗浄日時
                End If
                
                vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColTotalCnt, _
                    .strTotalUseCount)                                                                 '総回数
                    
                vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColCleanCnt, _
                    .strCleanCount)                                                                    '洗浄回数
                    
                vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColAfterCleanCnt, _
                    .strAfterCleanUseCount)                                                            '洗浄後回数
                
                vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColCleanFlag, _
                    .strCleanFlag)                                                                     '要洗浄
                
                '@ｷｬﾘｱWF有無ﾌﾗｸﾞが"あり"の場合
                If .strEmptyFlag = CMstrAri Then
                    vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColState, _
                        CMstrSekisai)                                                                  '状態(積載)
                Else
                    vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColState, _
                        CMstrKara)                                                                     '状態(空)
                End If
                
                '@loder/unloder種別が"UNLOADER"の場合
                If Trim(.strLdrUndrKind) = CMstrUnloder Then
                    vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColUnloderReserve, _
                        CMstrUnloderReserve)                                                           'Unloder予約状態(○)
                Else
                    vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColUnloderReserve, _
                        vbNullString)                                                                  'Unloder非予約状態(Null)
                End If
                
                vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColCarrierStat, _
                    .strCarrierStatName)                                                               'ｷｬﾘｱ状態
                
                vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColLotID, _
                    .strLotID)                                                                         'ﾛｯﾄID
                
                vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColVendor, _
                    .strVendorName)                                                                    'ﾍﾞﾝﾀﾞｰ
                
                If .strProductionDate <> vbNullString Then
	                vsfCarrierList.SetData(llngCarrierRow, CMlngvsfCarrierListColProductionDate, _
	                    Format$(CDate(.strProductionDate), CPstrDateTimeYMD))                          '製造年月日
                End If

            End With

            '@該当行にﾌｫｰｶｽｾｯﾄ
            vsfCarrierList.Row = llngCarrierRow
            
            '@選択行を表示
            vsfCarrierList.ShowCell(llngCarrierRow, CMlngvsfCarrierListColCarrierID)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCarrierClean_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbUseCategory_Disp
    '機　能：使用ｶﾃｺﾞﾘ表示
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/21 (Tue) 16:01:23 N.Kojima
    '更新日：2006/02/21 (Tue) 16:01:23
    '備　考：
    Private Sub prvcmbUseCategory_Disp()
        
        Dim lblnAns             As Boolean  '戻り値
        Dim llngCnt             As Integer  'ｶｳﾝﾄ
        Dim lstrFormName        As String   'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String   'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

        Try
            llngCnt = 0
            
            With cmbUseCategory
                
                '@初期化
                .Clear()
                .DispCols = CMlngCmbGetCol1                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGetCol0                                      'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGetCol1                                    '値取得列
                .DirectInput = False                                           'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, _
                        CMlngCmbFontSize, .Font.Style, .Font.Unit)             'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, _
                        CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                 '行の高さ
                .ColAlignment(CMlngCmbGetCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .Enabled = True                                                '有効
                .GroupRows = 0                                                 'GroupRow=取得件数
                
                '@ﾌｫｰﾑ名格納
                lstrFormName = Me.Name
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                lstrEventName = "prvcmbUseCategory_Disp"
                Call pubResponseStart(lstrFormName, lstrEventName)
                
                '@ｷｬﾘｱｶﾃｺﾞﾘﾘｽﾄ取得
                lblnAns = pubblnCarrierCategoryList_Sel(CMstrmas_carriercategorylistVer, _
                                                        cmbSBID1.Value, _
                                                        mtypCarrierCategoryList)
                
                '@戻り値判定
                If lblnAns = True Then
                        
                    '@1項目目には"全て"を表示させる
                    .AddItem(CMstrAllDisp _
                            & vbTab _
                            & vbNullString _
                            & vbTab _
                            & llngCnt)
                        
                    '@ｶﾃｺﾞﾘｾｯﾄ
                    For llngCnt = 0 To mtypCarrierCategoryList.lngCarrierCategoryCnt - 1

                        '@ﾘｽﾄに項目追加
                        .AddItem(mtypCarrierCategoryList.typCarrierCategory(llngCnt).strCategoryName _
                               & vbTab _
                               & mtypCarrierCategoryList.typCarrierCategory(llngCnt).strCategoryID _
                               & vbTab _
                               & llngCnt)                                        'ｶﾃｺﾞﾘ名 & ｶﾃｺﾞﾘID & 現在のｶｳﾝﾄ数
                        
                    Next llngCnt
                                 
                    '@表示件数分だけ表示
                    .GroupRows = llngCnt
                    
                    '@初回表示は「全て」を表示
                    .Text = CMstrAllDisp
                    '@ｶﾃｺﾞﾘ退避用変数に値を格納
                    mstrCombCategoryName = .Text
                    
                    '@ﾘｽﾄが1件の場合は直接表示
                    If .ListCount = 1 Then
                        '@表示
                        .ListIndex = 0
                    End If
                    
                Else
                    '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    Exit Sub
                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbUseCategory_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCarrierListCategory_Disp
    '機　能：ｷｬﾘｱ一覧使用ｶﾃｺﾞﾘ表示
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 11:38:56 N.Kojima
    '更新日：2006/02/23 (Thu) 11:38:56
    '備　考：
    Private Sub prvvsfCarrierListCategory_Disp()
        
        Dim llngLoopCnt         As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrCategoryList    As String       'ﾘｽﾄ作成領域

        Try
            
            With vsfCarrierList
                
                '@送品先ﾘｽﾄ設定
                '@使用ｶﾃｺﾞﾘﾘｽﾄが0件か
                If mtypCarrierCategoryList.lngCarrierCategoryCnt > 0 Then
                    '@ﾘｽﾄが存在する場合
                    
                    '@初期化
                    llngLoopCnt = 0
                    lstrCategoryList = vbNullString
                    
                    '@ﾘｽﾄ項目の設定(1行目)
                    lstrCategoryList = lstrCategoryList & mtypCarrierCategoryList.typCarrierCategory(llngLoopCnt).strCategoryName
                    
                    '@ﾘｽﾄ項目の設定(2行目以降)
                    For llngLoopCnt = 1 To mtypCarrierCategoryList.lngCarrierCategoryCnt - 1
                        
                        If mtypCarrierCategoryList.typCarrierCategory(llngLoopCnt).strCategoryName <> vbNullString Then
                            '@ｶﾃｺﾞﾘ名が空白以外の場合
                            lstrCategoryList = lstrCategoryList _
                                                & "|" _
                                                & mtypCarrierCategoryList.typCarrierCategory(llngLoopCnt).strCategoryName
                        Else
                            '@ｶﾃｺﾞﾘ名が空白の場合
                            lstrCategoryList = lstrCategoryList _
                                                & "|" _
                                                & mtypCarrierCategoryList.typCarrierCategory(llngLoopCnt).strCategoryName
                        End If
                        
                    Next
                Else
                    '@存在しない場合
                    lstrCategoryList = CPstrComboBrank
                End If
                
                '@使用ｶﾃｺﾞﾘ
                .Cols(CMlngvsfCarrierListColCategoryName).ComboList = lstrCategoryList
            
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCarrierListCategory_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbStockerName_Disp
    '機　能：ｽﾄｯｶｰ表示
    '引　数：
    '戻り値：なし
    '作成日：2004/11/29 (Mon) 16:50:34 N.Kojima
    '更新日：2004/11/29 (Mon) 16:50:34
    '備　考：
    Private Sub prvcmbStockerName_Disp()
        
        Dim lblnAns             As Boolean  '戻り値
        Dim llngCnt             As Integer  'ｶｳﾝﾄ
        Dim lblnDefaultFlag     As Boolean  'ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
        Dim lstrFormName        As String   'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String   'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrClassDivision   As String   '処理区分

        Try
            
            With cmbStockerName
                
                '@ｽﾄｯｶｰ初期化
                .Clear()
                .DispCols = CMlngCmbGetCol1                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGetCol0                                      'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGetCol1                                    '値取得列
                .DirectInput = False                                           'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, _
                        CMlngCmbFontSize, .Font.Style, .Font.Unit)             'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, _
                        CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                 '行の高さ
                .ColAlignment(CMlngCmbGetCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .Enabled = True                                                '有効
                .GroupRows = 20                                                'GroupRow=取得件数
                
                '@ﾌｫｰﾑ名格納
                lstrFormName = Me.Name
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                lstrEventName = "prvcmbStockerName_Disp"
                Call pubResponseStart(lstrFormName, lstrEventName)
                
                '@処理区分の設定
                Select Case cmbCarrType.Value
                    '@SMIF
                    Case CPstrCarrTypeSMIF
                        '@ｽﾄｯｶｰｺﾝﾎﾞをﾛｯｸ解除
                        cmbStockerName.Enabled = True
                        lstrClassDivision = CPstrCD2J '2J：ﾚﾁｸﾙｽﾄｯｶｰのみ
                    '@FOUP
                    Case CPstrCarrTypeFOUP
                        '@ｽﾄｯｶｰｺﾝﾎﾞをﾛｯｸ解除
                        cmbStockerName.Enabled = True
                        lstrClassDivision = CPstrCD3K '3K：FOUPｽﾄｯｶｰのみ
                    '@その他
                    Case Else
                        '@ｽﾄｯｶｰｺﾝﾎﾞをﾛｯｸ
                        cmbStockerName.Enabled = False
                        '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        Exit Sub
                End Select
                
                '@ｽﾄｯｶﾏｽﾀ取得
                lblnAns = pubblnMasStockerList_Sel(mtypStockerList, _
                                                   CMstrmas_stockerlistVer, _
                                                   mlngStockerListCnt, _
                                                   lstrClassDivision)
                '@戻り値判定
                If lblnAns = True Then
                        
                    '@ｽﾄｯｶｰｾｯﾄ
                    For llngCnt = 0 To mlngStockerListCnt - 1

                        '@ﾘｽﾄに項目追加
                        .AddItem(mtypStockerList(llngCnt).strStockerName _
                               & vbTab _
                               & mtypStockerList(llngCnt).strStockerId _
                               & vbTab _
                               & llngCnt)                                        'ｽﾄｯｶｰ & ｽﾄｯｶID & 現在のｶｳﾝﾄ数
                        
                    Next llngCnt
                                 
                    '@表示件数分だけ表示
                    .GroupRows = llngCnt
                    
                    '@ﾘｽﾄが1件の場合は直接表示
                    If .ListCount = 1 Then
                        '@表示
                        .ListIndex = 0
                    End If
                    
                    '@ﾃﾞﾌｫﾙﾄﾌﾗｸﾞをfalseに
                    lblnDefaultFlag = False
                Else
                    '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    Exit Sub
                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbStockerName_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMoveSlotMap4_MouseUp
    '機　能：ｽﾛｯﾄ情報変更後ｽﾛｯﾄﾏｯﾌﾟ ﾏｳｽｱｯﾌﾟ処理
    '引　数：Button：未使用
    '　　　：Shift：未使用
    '　　　：X：未使用
    '　　　：Y：未使用
    '戻り値：なし
    '作成日：2005/01/05 (Wed) 13:26:36 H.Wajima
    '更新日：2009/06/22 (Mon) 17:16:01 T.Oide
    '備　考：
    '　　　：2006/02/06 (Mon) 11:21:42 N.Kojima     変更前ｽﾛｯﾄﾏｯﾌﾟのﾀｲﾄﾙ行が選択されている場合は、
    '　　　：                                       変更後ｽﾛｯﾄﾏｯﾌﾟにWF情報を反映しないように修正。(不具合№3407)
    Private Sub vsfMoveSlotMap4_MouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMoveSlotMap4.Click
        
        Dim lstrWFID1       As String   '変更前WFID
        Dim lstrWFID2       As String   '変更後WFID
        Dim llngRowTop      As Integer  '選択最上段行
        Dim llngRowBottom   As Integer  '選択最下段行
        Dim llngCnt         As Integer  'ｶｳﾝﾄ
        Dim lblnFlg         As Boolean  '複数行選択ﾌﾗｸﾞ(True:複数,False:一行)

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@変更ﾎﾞﾀﾝﾛｯｸ
            cmdMove2.Enabled = False
            
            With vsfMoveSlotMap4
                If .Rows.Selected.Count < 1 Then
                    '選択行なし
                    Exit Sub
                End If
                '@選択最上段行を格納
                llngRowTop = .Rows.Selected(CMlngvsfGridTitleRow).Index
                '@選択最下段行を格納
                llngRowBottom = llngRowTop + .Rows.Selected.Count - 1
                
                '@複数行選択されなかった場合
                If llngRowBottom - llngRowTop = 0 Then
                    '@複数行選択されている場合
                    If llngRowBottom - llngRowTop <> 0 Then
                        '@複数行選択ﾌﾗｸﾞ(複数)
                        lblnFlg = True
                    Else
                        '@複数行選択ﾌﾗｸﾞ(一行)
                        lblnFlg = False
                    End If
                    
                    '@変更前ｽﾛｯﾄﾏｯﾌﾟのﾃﾞｰﾀ行の場合
                    If .Rows.Fixed <= .Row And vsfMoveSlotMap3.Row <> 0 Then
                        
                        '@変更前WFID
                        lstrWFID1 = vsfMoveSlotMap3.GetData(vsfMoveSlotMap3.Row, CMlngvsfMoveSlotMapColWFID)
                        '@変更後WFID
                        lstrWFID2 = .GetData(.Row, CMlngvsfMoveSlotMapColWFID)
                        
                        '@ﾊﾞｯｸｶﾗｰが濃い灰色以外の場合
                        If .GetCellRange(.Row, CMlngvsfMoveSlotMapColWFID).StyleDisplay.BackColor <> ColorTranslator.FromWin32(CPlngGridDarkGray) Then
                        
                            '@変更後WFIDがない場合(一行)
                            If lstrWFID2 = vbNullString And lblnFlg = False Then
                                '@変更前WFIDがある場合
                                If lstrWFID1 <> vbNullString Then
                                
                                    .SetData(.Row, CMlngvsfMoveSlotMapColWFID, lstrWFID1)                           'WF_ID
                                    '@↓2020/02/10 (Mon) 13:44:51 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                    .SetData(.Row, CMlngvsfMoveSlotMapColGRB, _
                                        vsfMoveSlotMap3.GetData(vsfMoveSlotMap3.Row, CMlngvsfMoveSlotMapColGRB))    'GRB
                                    '@↑2020/02/10 (Mon) 13:44:51 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                    .SetData(.Row, CMlngvsfMoveSlotMapColJIGID, _
                                        vsfMoveSlotMap3.GetData(vsfMoveSlotMap3.Row, CMlngvsfMoveSlotMapColJIGID))  '治具ID
                                    .SetData(.Row, CMlngvsfMoveSlotMapColBeforJIG, _
                                        vsfMoveSlotMap3.GetData(vsfMoveSlotMap3.Row, CMlngvsfMoveSlotMapColJIGID))  '変更前の治具ID
                                    .SetData(.Row, CMlngvsfMoveSlotMapColWFStat, _
                                        vsfMoveSlotMap3.GetData(vsfMoveSlotMap3.Row, CMlngvsfMoveSlotMapColWFStat)) '状態
                                    .SetData(.Row, CMlngvsfMoveSlotMapColBeforRow, vsfMoveSlotMap3.Row)             '変更前のRow
                                    
                                    vsfMoveSlotMap3.SetData(vsfMoveSlotMap3.Row, CMlngvsfMoveSlotMapColWFID, vbNullString)  'WF_IDを空にする
                                    '@↓2020/02/10 (Mon) 13:45:18 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                    vsfMoveSlotMap3.SetData(vsfMoveSlotMap3.Row, CMlngvsfMoveSlotMapColGRB, vbNullString)   'GRBを空にする
                                    '@↑2020/02/10 (Mon) 13:45:18 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                    vsfMoveSlotMap3.SetData(vsfMoveSlotMap3.Row, CMlngvsfMoveSlotMapColJIGID, vbNullString) '治具IDを空にする
                                    vsfMoveSlotMap3.SetData(vsfMoveSlotMap3.Row, CMlngvsfMoveSlotMapColWFStat, vbNullString)'状態を空にする
                                    
                                    '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ解除
                                    cmdMoveCancel2.Enabled = True
                                    '@確定ﾎﾞﾀﾝ制御
                                    Call prvWFMove2_Set()
                                    Exit Sub
                                Else
                                    '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ解除
                                    cmdMoveCancel2.Enabled = False
                                 End If
                            Else
                                '@変更前選択行が一行の場合
                                If lblnFlg = False Then
                                    '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ解除
                                    cmdMoveCancel2.Enabled = True
                                Else
                                    '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ
                                    cmdMoveCancel2.Enabled = False
                                End If
                            End If
                        End If
                    End If
                    '@確定ﾎﾞﾀﾝ制御
                    Call prvWFMove2_Set()
                Else
                    '@複数行選択された場合(変更ｷｬﾝｾﾙする場合)
                    For llngCnt = llngRowBottom To llngRowTop Step -1
                        '@ﾃﾞｰﾀ行の場合
                        If .Rows.Fixed <= .Rows.Count Then
                            '@変更後WFID
                            lstrWFID2 = .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                            '@変更後WFIDがある場合
                             If lstrWFID2 <> vbNullString Then
                                '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ解除
                                cmdMoveCancel2.Enabled = True
                                '@確定ﾎﾞﾀﾝ制御
                                Call prvWFMove2_Set()
                                Exit Sub
                             End If
                        End If
                    Next llngCnt
                    '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ
                    cmdMoveCancel2.Enabled = False
                End If
            End With
            
            '@確定ﾎﾞﾀﾝ制御
            Call prvWFMove2_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMoveSlotMap4_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfMoveSlotMapSelect_Proc
    '機　能：統合元ｽﾛｯﾄﾏｯﾌﾟ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/05 (Wed) 13:43:09 H.Wajima
    '更新日：2005/01/05 (Wed) 13:43:09
    '備　考：
    Private Sub prvvsfMoveSlotMapSelect_Proc()

        Dim lstrWFID1       As String   '統合元WFID
        Dim lstrWFID2       As String   '統合先WFID
        Dim llngRowTop      As Integer  '選択最上段行
        Dim llngRowBottom   As Integer  '選択最下段行
        Dim llngCnt         As Integer  'ｶｳﾝﾄ

        Try
            
            '@統合ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ
            cmdMoveCancel.Enabled = False
            
            With vsfMoveSlotMap
                If .Rows.Selected.Count < 1 Then
                    '選択行なし
                    Exit Sub
                End If
                '@選択最上段行を格納
                llngRowTop = .Rows.Selected(CMlngvsfGridTitleRow).Index
                '@選択最下段行を格納
                llngRowBottom = llngRowTop + .Rows.Selected.Count - 1
                
                For llngCnt = llngRowBottom To llngRowTop Step -1
                    '@ﾃﾞｰﾀ行の場合
                    If .Rows.Fixed <= .Rows.Count Then
                        '@統合元WFID
                        lstrWFID1 = .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                        '@統合先WFID
                        lstrWFID2 = vsfMoveSlotMap2.GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                        
                        '@統合元WFIDがある場合
                        If lstrWFID1 <> vbNullString Then
                            '@統合先WFIDがない場合
                             If lstrWFID2 = vbNullString Then
                                '@統合ﾎﾞﾀﾝ解除
                                cmdMove.Enabled = True
                                Exit Sub
                             End If
                        End If
                    End If
                Next llngCnt
            End With
            
            '@統合ﾎﾞﾀﾝﾛｯｸ
            cmdMove.Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfMoveSlotMapSelect_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfMoveSlotMap2Select_Proc
    '機　能：統合先ｽﾛｯﾄﾏｯﾌﾟ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/05 (Wed) 13:46:36 H.Wajima
    '更新日：2005/12/01 (Thu) 15:26:29 N.Kasai
    '備　考：
    '　　　：2005/12/01 (Thu) 15:26:29 N.Kasai      移動先のｽﾛｯﾄｻｲｽﾞを判定
    Private Sub prvvsfMoveSlotMap2Select_Proc()

        Dim lstrWFID1       As String   '変更前WFID
        Dim lstrWFID2       As String   '変更後WFID
        Dim llngRowTop      As Integer  '選択最上段行
        Dim llngRowBottom   As Integer  '選択最下段行
        Dim llngCnt         As Integer  'ｶｳﾝﾄ
        Dim llngBackColor   As Color    'ﾊﾞｯｸｶﾗｰ
        Dim lblnFlg         As Boolean  '複数行選択ﾌﾗｸﾞ(True:複数,False:一行)

        Try
            
            '@変更ﾎﾞﾀﾝﾛｯｸ
            cmdMove.Enabled = False
            
            With vsfMoveSlotMap2
                If .Rows.Selected.Count < 1 Then
                    '選択行なし
                    Exit Sub
                End If
                '@選択最上段行を格納
                llngRowTop = .Rows.Selected(CMlngvsfGridTitleRow).Index
                
                '@選択最下段行を格納
                llngRowBottom = llngRowTop + .Rows.Selected.Count - 1
                
                '@複数行選択されなかった場合
                If llngRowBottom - llngRowTop = 0 Then
                    '@選択最上段行を格納
                    llngRowTop = vsfMoveSlotMap.Rows.Selected(CMlngvsfGridTitleRow).Index
                    '@選択最下段行を格納
                    llngRowBottom = llngRowTop + vsfMoveSlotMap.Rows.Selected.Count - 1
                
                    '@複数行選択されている場合
                    If llngRowBottom - llngRowTop <> 0 Then
                        '@複数行選択ﾌﾗｸﾞ(複数)
                        lblnFlg = True
                    Else
                        '@複数行選択ﾌﾗｸﾞ(一行)
                        lblnFlg = False
                    End If
                    
                    '@変更前ｽﾛｯﾄﾏｯﾌﾟのﾃﾞｰﾀ行の場合
                    If .Rows.Fixed <= .Row Then
                        '@変更後ｽﾛｯﾄﾏｯﾌﾟのﾃﾞｰﾀ行の場合
                        If vsfMoveSlotMap.Rows.Fixed <= vsfMoveSlotMap.Row Then
                            '@変更前WFID
                            lstrWFID1 = vsfMoveSlotMap.GetData(vsfMoveSlotMap.Row, CMlngvsfMoveSlotMapColWFID)
                            '@変更後WFID
                            lstrWFID2 = .GetData(.Row, CMlngvsfMoveSlotMapColWFID)
                            '@ﾊﾞｯｸｶﾗｰ
                            llngBackColor = .GetCellRange(.Row, CMlngvsfMoveSlotMapColWFID).StyleDisplay.BackColor
                            
                            '@変更後WFIDがない場合(一行の場合)
                            If lstrWFID2 = vbNullString And lblnFlg = False Then
                                '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ
                                cmdMoveCancel.Enabled = False
                                
                                '@ｽﾛｯﾄ№が空白以外(ｷｬﾘｱのMAXｽﾛｯﾄｻｲｽﾞ以外)
                                If vsfMoveSlotMap2.GetData(.Row, CMlngvsfMoveSlotMapColNo) <> vbNullString Then

                                    '@変更前WFIDがある場合
                                     If lstrWFID1 <> vbNullString Then
                                     
                                        .SetData(.Row, CMlngvsfMoveSlotMapColWFID, lstrWFID1)                         'WF_ID
                                        '@↓2020/02/10 (Mon) 13:45:47 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                        .SetData(.Row, CMlngvsfMoveSlotMapColGRB, vsfMoveSlotMap.GetData(vsfMoveSlotMap.Row, CMlngvsfMoveSlotMapColGRB))        'GRB
                                        '@↑2020/02/10 (Mon) 13:45:47 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                        .SetData(.Row, CMlngvsfMoveSlotMapColJIGID, vsfMoveSlotMap.GetData(vsfMoveSlotMap.Row, CMlngvsfMoveSlotMapColJIGID))    '治具ID
                                        .SetData(.Row, CMlngvsfMoveSlotMapColWFStat, vsfMoveSlotMap.GetData(vsfMoveSlotMap.Row, CMlngvsfMoveSlotMapColWFStat))  '状態
                                        .SetData(.Row, CMlngvsfMoveSlotMapColBeforRow, vsfMoveSlotMap.Row)
                                        vsfMoveSlotMap.SetData(vsfMoveSlotMap.Row, CMlngvsfMoveSlotMapColWFID, vbNullString)    'WF_ID削除
                                        '@↓2020/02/10 (Mon) 13:46:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                        vsfMoveSlotMap.SetData(vsfMoveSlotMap.Row, CMlngvsfMoveSlotMapColGRB, vbNullString)     'GRB削除
                                        '@↑2020/02/10 (Mon) 13:46:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                        vsfMoveSlotMap.SetData(vsfMoveSlotMap.Row, CMlngvsfMoveSlotMapColJIGID, vbNullString)   '治具ID削除
                                            
                                        '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ解除
                                        cmdMoveCancel.Enabled = True
                                        '@確定ﾎﾞﾀﾝ制御
                                        Call prvWFMove_Set()
                                        Exit Sub
                                     End If
                                 End If
                            Else
                                '@WFIDが統合元の場合(一行)
                                If llngBackColor <> ColorTranslator.FromWin32(CPlngGridGray) And lblnFlg = False Then
                                    '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ解除
                                    cmdMoveCancel.Enabled = True
                                Else
                                    '@WFIDが統合元の場合(複数)
                                    If llngBackColor <> ColorTranslator.FromWin32(CPlngGridGray) Then
                                        '@統合先ｽﾛｯﾄﾏｯﾌﾟにﾃﾞｰﾀがあるか
                                        If lstrWFID2 <> vbNullString Then
                                            '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ解除
                                            cmdMoveCancel.Enabled = True
                                        Else
                                            '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ
                                            cmdMoveCancel.Enabled = False
                                        End If
                                    Else
                                        '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ
                                        cmdMoveCancel.Enabled = False
                                    End If
                                End If
                            End If
                        End If
                    End If
                    '@確定ﾎﾞﾀﾝ制御
                    Call prvWFMove_Set()
                Else
                    '@複数行選択された場合(変更ｷｬﾝｾﾙする場合)
                    For llngCnt = llngRowBottom To llngRowTop Step -1
                        '@ﾃﾞｰﾀ行の場合
                        If .Rows.Fixed <= .Rows.Count Then
                            '@変更後WFID
                            lstrWFID2 = .GetData(llngCnt, CMlngvsfMoveSlotMapColWFID)
                            '@ﾊﾞｯｸｶﾗｰ
                            llngBackColor = .GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID).StyleDisplay.BackColor
                            
                            '@統合元WFIDがある場合
                             If lstrWFID2 <> vbNullString And llngBackColor <> ColorTranslator.FromWin32(CPlngGridGray) Then
                                '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ解除
                                cmdMoveCancel.Enabled = True
                                '@確定ﾎﾞﾀﾝ制御
                                Call prvWFMove_Set()
                                Exit Sub
                             Else
                                '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ
                                cmdMoveCancel.Enabled = False
                             End If
                        End If
                    Next llngCnt
                    '@ｽﾛｯﾄ情報変更ｷｬﾝｾﾙﾎﾞﾀﾝﾛｯｸ
                    cmdMoveCancel.Enabled = False
                End If
            End With
            
            '@確定ﾎﾞﾀﾝ制御
            Call prvWFMove_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfMoveSlotMap2Select_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnmasPlaceList_Sel
    '機　能：ｷｬﾘｱ位置情報取得
    '引　数：lstrCarrierID：ｷｬﾘｱID
    '　　　：llngResponseFlag：ﾚｽﾎﾟﾝｽﾌﾗｸﾞ(True:測定中,False:新規測定)
    '戻り値：True：OK/False：NG
    '作成日：2005/05/30 (Mon) 09:54:28 S.Deguchi
    '更新日：2005/05/30 (Mon) 09:54:28
    '備　考：
    Private Function prvblnmasPlaceList_Sel(ByVal lstrCarrierID As String, _
                                            ByVal lblnResponseFlag As Boolean) As Boolean

        Dim lblnAns             As Boolean              'ｷｬﾘｱ情報設定戻り値(True:正常,False:異常)
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngPlaceCnt        As Integer              '保管場所ﾏｽﾀ件数
        Dim ltypPlaceList       As List(Of PlaceList)   '保管場所ﾏｽﾀ取得構造体
        Dim llngCnt             As Integer              'ｶｳﾝﾄ

        Try
            
            '@初期化
            prvblnmasPlaceList_Sel = False
            
            If lblnResponseFlag = False Then
                '@ﾚｽﾎﾟﾝｽ取得開始
                lstrFormName = Me.Name
                lstrEventName = "masPlaceList_Sel"
                Call pubResponseStart(lstrFormName, lstrEventName)
            End If
            
            '@保管場所ﾏｽﾀの取得
            lblnAns = pubblnMasPlaceList_Sel(CMstrmas_placelistVer, _
                                             ltypPlaceList, _
                                             llngPlaceCnt, _
                                             lstrCarrierID)
            '@結果判定
            If lblnAns = True Then
                With cmbChangePosiotionID
                    .Clear()                      '初期化
                    
                    '@変更後位置にﾃﾞｰﾀがない場合
                    If .ListCount = 0 Then
                        '@位置ｺﾝﾎﾞｾｯﾄ
                        For llngCnt = 0 To llngPlaceCnt - 1
                            '@ｽﾄｯｶｰ№ & ｽﾄｯｶｰ名 & ｽﾄｯｶｰ№+ｽﾄｯｶｰ名
                            .AddItem(ltypPlaceList(llngCnt).strPlaceID & vbTab & _
                                     ltypPlaceList(llngCnt).strPlaceName & vbTab & _
                                     ltypPlaceList(llngCnt).strPlaceID & CPstrSpace & _
                                     ltypPlaceList(llngCnt).strPlaceName)
                        Next llngCnt
                    End If
                    
                    '@実行ﾌﾗｸﾞ立て
                    mblnCarrChangeFlag = True
                    
                    '@ﾛｯｸ解除
                    .Enabled = True
                    
                    '@保管場所ﾏｽﾀ件数が1件の場合(ﾘｽﾄを表示しない)
                    If llngPlaceCnt = 1 Then
                        .ListIndex = 0
                    End If
                    
                    If lblnResponseFlag = False Then
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(lstrFormName, lstrEventName)
                    End If
                    
                    '@成功を返す
                    prvblnmasPlaceList_Sel = True
                End With
            Else
                If lblnResponseFlag = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                End If
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnmasPlaceList_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvvsfSlotMap_Edit
    '機　能：ｸﾞﾘｯﾄﾞ編集(ﾁｪｯｸﾎﾞｯｸｽ)を許可する制御
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/18 (Fri) 14:41:43 N.Kasai
    '更新日：2005/11/18 (Fri) 14:41:43
    '備　考：
    Private Sub prvvsfSlotMap_Edit()

        Dim lblnAns As Boolean  '汎用戻り値

        Try

            With vsfMoveSlotMap5
                '@ｽﾛｯﾄｻｲｽﾞ以外の行はﾁｪｯｸさせない
                If .Row < .Rows.Fixed OrElse .GetCellRange(.Row, CMlngvsfMoveSlotMapColCheck).StyleDisplay.BackColor <> Color.White Then
                    Exit Sub
                End If
            
                '@選択された列が空行以外の場合には編集を可能にする
                If .GetData(.Row, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                    If .GetCellCheck(.Row, CMlngvsfMoveSlotMapColCheck) = CheckEnum.Unchecked Then
                        '@ﾁｪｯｸなし→ﾁｪｯｸ
                        .SetCellCheck(.Row, CMlngvsfMoveSlotMapColCheck, CheckEnum.Checked)     'ﾁｪｯｸ
                    Else
                        '@ﾁｪｯｸ→ﾁｪｯｸなし
                        .SetCellCheck(.Row, CMlngvsfMoveSlotMapColCheck, CheckEnum.Unchecked)   'ﾁｪｯｸ解除
                    End If
                Else
                    '@ﾁｪｯｸ→ﾁｪｯｸなし
                        .SetCellCheck(.Row, CMlngvsfMoveSlotMapColCheck, CheckEnum.Unchecked)   'ﾁｪｯｸ解除
                End If
            End With

            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnSlotMap_Chk()
            '@結果判定
            If lblnAns = False Then
            '@失敗の場合
                '@確定ﾎﾞﾀﾝ使用不可
                cmdWFScrap.Enabled = False
            Else
            '@成功の場合
                '@確定ﾎﾞﾀﾝ使用可
                cmdWFScrap.Enabled = True
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap_Edit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnSlotMap_Chk
    '機　能：入力ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/12 (Mon) 11:43:09 N.Kasai
    '更新日：2005/12/12 (Mon) 11:43:09
    '備　考：
    Private Function prvblnSlotMap_Chk() As Boolean

        Dim llngCnt         As Integer  '汎用ｶｳﾝﾀ

        Try
            
            '@初期化
            prvblnSlotMap_Chk = False
          
            '@ｽﾛｯﾄﾏｯﾌﾟ件数ﾁｪｯｸ
            With vsfMoveSlotMap5
                For llngCnt = 1 To .Rows.Count - 1
                    '@ﾁｪｯｸﾎﾞｯｸｽのﾁｪｯｸ可否判定：1WFにでもﾁｪｯｸがあればOK
                    If .GetCellCheck(llngCnt, CMlngvsfMoveSlotMapColCheck) = CheckEnum.Checked Then
                        '@成功をｾｯﾄ
                        prvblnSlotMap_Chk = True
                        
                        '@処理抜け
                        Exit For
                    End If
                Next llngCnt
            End With
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnSlotMap_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvvsfCarrierList_Edit
    '機　能：ｸﾞﾘｯﾄﾞ編集(ﾘｽﾄ選択,ｺﾒﾝﾄ入力)を許可する制御
    '引　数：llngEditFlg    ：制御の判断ﾌﾗｸﾞ(1=ﾏｳｽ,2=ｷｰﾎﾞｰﾄﾞ)
    '　　　：llngKeyCode    ：ｷｰｺｰﾄﾞ(0:ﾏｳｽ(定義),32(vbKeySpace):ｽﾍﾟｰｽｷｰ)
    '戻り値：なし
    '作成日：2006/02/22 (Wed) 14:23:10 N.Kojima
    '更新日：2006/02/22 (Wed) 14:23:10
    '備　考：
    Private Sub prvvsfCarrierList_Edit(ByRef llngEditFlg As Integer, ByRef llngKeyCode As Short)

        Try
            
            With vsfCarrierList
                
                '@選択された列が下記の場合には編集を可能にする
                Select Case .Col
                        
                    Case CMlngvsfCarrierListColCategoryName
                        '@使用ｶﾃｺﾞﾘﾘｽﾄ欄

                        'NSYS ヘッダクリックの場合は編集モードにしない
                        If CMlngvsfKeyDown = llngEditFlg OrElse _
                            (CMlngvsfMouseClick = llngEditFlg AndAlso .Row >= .Rows.Fixed AndAlso .MouseRow >= .Rows.Fixed) Then
	                        '@使用ｶﾃｺﾞﾘﾘｽﾄ作成処理へ
	                         Call prvvsfCarrierListCategory_Disp()
	                        
	                        '@ｸﾞﾘｯﾄﾞを編集可能にする
	                        .StartEditing()
                        End If
                        
                    Case Else
                        '@上記以外
                        
                        '@編集不可
                        .AllowEditing = False
                End Select

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCarrierList_Edit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWfCarryFlag_Chk
    '機　能：WF移載ﾌﾗｸﾞ制御
    '引　数：なし
    '戻り値：なし
    '作成日：2007/04/20 (Fri) 14:29:56 N.Kasai
    '更新日：2007/04/20 (Fri) 14:29:56
    '備　考：
    Private Sub prvWfCarryFlag_Chk()

        Try
            
            '@WF_CARRY_FLAG=1(WF移載予約)のｷｬﾘｱを入力された場合
            '@ｷｬﾘｱﾒﾝﾃﾅﾝｽｽﾛｯﾄ一覧は閲覧のみとする。
            '@WF移動ﾀﾌﾞ
            '@ｽﾛｯﾄ情報変更ﾀﾌﾞ
            '@WF破棄ﾀﾌﾞ
            '@ｷｬﾘｱ交換ﾀﾌﾞ
            '@※ｷｬﾘｱ位置変更はWF移載に関係なく利用可能(仕様)
            '@後々、ｿｰｽ整備を行いう必要ある。ｺﾝﾄﾛｰﾙの使用制限は
            '@FUNCTIONにまとめて記述した方が良い(今は工数がないのでここまで)
            
            '@WF移載予約の場合
            If mstrWpCarryFlag = "1" Then
                '@WF移動ﾀﾌﾞ
                vsfMoveSlotMap.Enabled = False
        '        cmdMove.Enabled = False
        '        cmdMoveCancel.Enabled = False
        '        txtCarrierMnt.Enabled = False
        '        cmdCarrierSelect.Enabled = False
                
                '@ｽﾛｯﾄ情報変更ﾀﾌﾞ
                vsfMoveSlotMap3.Enabled = False
        '        cmdMove2.Enabled = False
        '        cmdMoveCancel2.Enabled = False
        '        vsfMoveSlotMap4.Enabled = False
                
                '@WF破棄ﾀﾌﾞ
                vsfMoveSlotMap5.Enabled = False
        '        txtComment.Enabled = False
        '        cmdWFAllSelect.Enabled = False
                
                '@ｷｬﾘｱ交換ﾀﾌﾞ
                vsfMoveSlotMap6.Enabled = False
        '        txtCarrierMnt2.Enabled = False
        '        cmdCarrierSelect2.Enabled = False
                
            Else
        '        '@WF移動ﾀﾌﾞ
        '        vsfMoveSlotMap.Enabled = True
        '        cmdMove.Enabled = True
        '        cmdMoveCancel.Enabled = True
        '        txtCarrierMnt.Enabled = True
        '        cmdCarrierSelect.Enabled = True
        '
        '        '@ｽﾛｯﾄ情報変更ﾀﾌﾞ
        '        vsfMoveSlotMap3.Enabled = True
        '        cmdMove2.Enabled = True
        '        cmdMoveCancel2.Enabled = True
        '        vsfMoveSlotMap4.Enabled = True
        '
        '        '@WF破棄ﾀﾌﾞ
        '        vsfMoveSlotMap5.Enabled = True
        '        txtComment.Enabled = True
        '        cmdWFAllSelect.Enabled = True
        '
        '        '@ｷｬﾘｱ交換ﾀﾌﾞ
        '        vsfMoveSlotMap6.Enabled = True
        '        txtCarrierMnt2.Enabled = True
        '        cmdCarrierSelect2.Enabled = True
                
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWfCarryFlag_Chk"
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

    '関数名：flexgrid_MouseDown
    '機　能：グリッドのマウスダウン時の処理
    '引　数：sender：イベント発生源のオブジェクト
    '　　　：e     ：イベントオブジェクト
    '戻り値：なし
    '作成日：2020/03/11 (Wed) NSYS
    '備　考：
    Private Sub flexgrid_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles vsfMoveSlotMap.MouseDown, vsfMoveSlotMap2.MouseDown, vsfMoveSlotMap3.MouseDown, vsfMoveSlotMap4.MouseDown

        Try
            '左クリックの場合
            If e.Button = MouseButtons.Left Then
                With CType(sender, C1FlexGrid)
                    ' No.列のヘッダの場合
                    If .MouseRow = 0 AndAlso .MouseCol = 0 Then
                        '全て選択
                        .Select(.Rows.Fixed, .Cols.Fixed, .Rows.Count -1, .Cols.Count -1)
                    End If
                End With
            End If

        Catch ex As Exception
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "flexgrid_MouseDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

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

    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraSlotMap1.Paint, fraSlotMap2.Paint, fraSlotMap3.Paint, fraSlotMap4.Paint, fraSlotMap5.Paint, fraSlotMap6.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfCarrierList.BeforeDoubleClick, vsfMoveSlotMap.BeforeDoubleClick, vsfMoveSlotMap2.BeforeDoubleClick, vsfMoveSlotMap3.BeforeDoubleClick, vsfMoveSlotMap4.BeforeDoubleClick, vsfMoveSlotMap5.BeforeDoubleClick, vsfMoveSlotMap6.BeforeDoubleClick, vsfMoveSlotMap7.BeforeDoubleClick

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
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfCarrierList.KeyDownEdit, vsfMoveSlotMap.KeyDownEdit, vsfMoveSlotMap2.KeyDownEdit, vsfMoveSlotMap3.KeyDownEdit, vsfMoveSlotMap4.KeyDownEdit, vsfMoveSlotMap5.KeyDownEdit, vsfMoveSlotMap6.KeyDownEdit, vsfMoveSlotMap7.KeyDownEdit

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
                            If sender Is vsfMoveSlotMap4 Then
                                vsfMoveSlotMap4.AllowEditing = False
                            End If
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
                            If sender Is vsfMoveSlotMap4 Then
                                vsfMoveSlotMap4.AllowEditing = False
                            End If
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
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfCarrierList.SetupEditor, vsfMoveSlotMap.SetupEditor, vsfMoveSlotMap2.SetupEditor, vsfMoveSlotMap3.SetupEditor, vsfMoveSlotMap4.SetupEditor, vsfMoveSlotMap5.SetupEditor, vsfMoveSlotMap6.SetupEditor, vsfMoveSlotMap7.SetupEditor
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

    '関数名：tabList_Deselecting
    '機　能：タブの選択が解除される前に発生するイベント処理
    '引　数：sender：イベント発生源のオブジェクト
    '        e     ：イベント情報
    '戻り値：なし
    '作成日：2018/10/12 (Fri) NSYS
    '更新日：
    '備　考：
    Private Sub tabList_Deselecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles _
        tabCarrier.Deselecting, tabCarrierMnt.Deselecting

        '処理中の場合またはタブ切り替えが無効の場合はタブ選択をキャンセルする
        If Me.buttonProcessing = True OrElse mblnTabSelectEnabled = False Then
            e.Cancel = True
            mblnTabSelectEnabled = True
        End If

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

    '関数名：txtDummy0_Enter
    '機　能：txtDummy0のEnterイベント処理
    '引　数：sender：イベント発生源のオブジェクト
    '        e     ：イベント情報
    '戻り値：なし
    '作成日：2019/06/22 (Sat) NSYS
    '更新日：
    '備　考：
    Private Sub txtDummy0_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtDummy0.Enter
        If (Control.ModifierKeys And Keys.Shift) = Keys.Shift Then
            '前のコントロールを選択する
             calManuDate.Focus()
        Else
            '次のコントロールを選択する
            If cmdRegist.Enabled = True Then
                cmdRegist.Focus()
            Else
                cmdClose.Focus()
            End If
        End If
    End Sub
    
    '関数名：cursor_Enter	
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。	
    '作成日：2019/07/02 NSYS	
    '更新日：	
    '備　考：Handlesは画面で入力できるすべての項目が対象	
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
        tabCarrier.Enter, _
        tabCarrierMnt.Enter, cmdCarrierSelect.Enter, cmdCarrierSelect2.Enter, cmdClose.Enter, cmdClean.Enter, cmdCarrierClean.Enter, _
        cmdShip.Enter, cmdCarrierForcedmove.Enter, _
        cmbSBID0.Enter, txtCarrierID0.Enter, calUseStartDate.Enter, calManuDate.Enter, txtDummy0.Enter, cmdDel.Enter, cmdRegist.Enter, _
        cmbSBID1.Enter, cmbCarrType.Enter, cmbUseCategory.Enter, cmbStockerName.Enter, cmdNowList.Enter, _
        vsfCarrierList.Enter, txtCarrierComments.Enter, cmdUp.Enter, cmdDown.Enter, cmdUpdate.Enter, cmdCopy.Enter, _
        txtCarrierID2.Enter, _
        vsfMoveSlotMap.Enter, cmdMove.Enter, cmdMoveCancel.Enter, vsfMoveSlotMap2.Enter, cmdWFMove.Enter, txtCarrierMnt.Enter, _
        vsfMoveSlotMap3.Enter, cmdMove2.Enter, cmdMoveCancel2.Enter, vsfMoveSlotMap4.Enter, cmdUpper.Enter, cmdLower.Enter, cmdWFMove2.Enter, cmdJigSelect.Enter, _
        vsfMoveSlotMap5.Enter, cmdWFAllSelect.Enter, txtComment.Enter, cmdCommentUp.Enter, cmdCommentDown.Enter, cmdWFScrap.Enter, _
        cmbChangePosiotionID.Enter, cmdChgStocker.Enter, _
        vsfMoveSlotMap6.Enter, txtCarrierMnt2.Enter, vsfMoveSlotMap7.Enter, cmdExchange.Enter, optOnline0.Enter, optOnline1.Enter

        '選択されている項目の名前で判定	
        Select sender.Name
            'キャリアメンテナンスタブ、空きキャリア選択ボタン、閉じるボタン、
            '洗浄ボタン、出庫指示ボタン、キャリア強制交換ボタン の場合は自動Validate = OFF	
            Case "tabCarrierMnt", "cmdCarrierSelect", "cmdCarrierSelect2", "cmdClose", _
                 "cmdClean", "cmdShip", "cmdCarrierForcedmove"
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
                '上記以外は自動Validate = ON	
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
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
    Private Sub flex_OwnerDrawCell(ByVal sender As Object, ByVal e As OwnerDrawCellEventArgs) Handles vsfMoveSlotMap.OwnerDrawCell, vsfMoveSlotMap2.OwnerDrawCell, vsfMoveSlotMap3.OwnerDrawCell, vsfMoveSlotMap4.OwnerDrawCell, vsfMoveSlotMap6.OwnerDrawCell, vsfMoveSlotMap7.OwnerDrawCell
        pubVsfOwnerDrawCell(CType(sender, C1FlexGrid), e)
    End Sub

End Class
