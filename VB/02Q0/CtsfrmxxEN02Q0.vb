'ﾌｧｲﾙ名：xxEN02Q0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：作業開始　ﾒｲﾝﾌｫｰﾑ
'作成日：2018/08/02 (Thu) 17:46:09 Y.Yoneyama
'更新日：2019/02/13 (Wed) 15:11:04 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2019, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02Q0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02Q0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02Q0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02Q0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02Q0)
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
    '====================================== Private ========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    'Private Const CMstrLocalVersion             As String = "01.02"
    Private Const CMstrLocalVersion             As String = "01.03"

    '@ﾛｰｶﾙ機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN02Q0  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CPstrcarracarsetVer           As String = "01.00"         'AｷｬﾘｱSET
    Private Const CPstrlot_wplistaldVer         As String = "01.00"         'ﾛｯﾄ装置情報取得(防湿ALD)
    Private Const CPstrlot_workaldlotlistVer    As String = "01.00"         '防湿ALD作業作業ﾛｯﾄ一覧
    Private Const CMstrlot_curstateVer          As String = "04.00"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_wrkstartVer          As String = "07.03"         'ﾛｯﾄ作業開始
    Private Const CMstrlot_prcstartVer          As String = "07.00"         'ﾛｯﾄ処理開始
    Private Const CMstrlot_procend_Ver          As String = "04.00"         'ﾛｯﾄ処理終了
    Private Const CMstrlot_wrkendVer            As String = "04.05"         'ﾛｯﾄ作業終了
    Private Const CMstrlot_nextSendVer          As String = "03.03"         'ﾛｯﾄ次工程送出
    Private Const CMstrlot_actlist_Ver          As String = "01.00"         'ｱｸｼｮﾝ予約ﾘｽﾄ取得
    Private Const CMstrcarrcurstateVer          As String = "05.02"         'ｷｬﾘｱ状態確認
    Private Const CMstrmat_materiallistVer      As String = "02.01"         '装置部材情報取得
    Private Const CMstrmat_chkwpmaterialVer     As String = "03.00"         '装置使用部材判定
    Private Const CMstrspc_regcollectVer        As String = "05.00"         '装置ﾃﾞｰﾀ登録
    Private Const CMstrutilreftminfoVer         As String = "04.00"         '端末設定情報取得
    Private Const CMstreqchkintervalVer         As String = "01.00"         '装置経過時間ﾁｪｯｸ
    Private Const CMstrlot_chkovertake          As String = "01.00"         '無機ODF追越制限違反確認
    Private Const CMstrlot_nextsteplistVer      As String = "03.01"         'ﾛｯﾄ次工程取得
    Private Const CPstrlot_wplist__Ver          As String = "02.05"         'ﾛｯﾄ装置情報取得
    Private Const CMstrctl_updwaitinglotVer     As String = "01.01"         '処理待ちﾛｯﾄ更新
    Private Const CMstrlot_detail__Ver          As String = "03.00"         'ﾛｯﾄ詳細情報
    Private Const CMstrspc_judge___Ver          As String = "03.01"         'SPC規格値判定
    Private Const CMstrlot_waferlistVer         As String = "02.05"         'ﾛｯﾄWF情報取得(新)
    Private Const CMstreqft_syncregistVer       As String = "02.00"         'ｵﾌﾗｲﾝFTPﾃﾞｰﾀ同期登録
    Private Const CMstrbat_startwrkVer          As String = "03.01"         'ﾊﾞｯﾁ作業開始
    Private Const CMstrbat_prcstartVer          As String = "03.01"         'ﾊﾞｯﾁ処理開始
    Private Const CMstrbat_prcend__Ver          As String = "02.00"         'ﾊﾞｯﾁ処理終了
    Private Const CMstrbat_endwrk_Ver           As String = "03.01"         'ﾊﾞｯﾁ作業終了

    '@ｷｬﾘｱIDの最大桁数
    Private Const CMlngCarrierMaxLength         As Integer = 6              'ｷｬﾘｱIDの最大桁数
    Private Const CMlngLotMaxLength             As Integer = 10             'ﾛｯﾄIDの最大桁数

    '@WPIDｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbDispCols              As Integer = 1              'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbGridColWPName         As Integer = 0              '装置名列番
    Private Const CMlngCmbGridColWPID           As Integer = 1              '装置ID列番(非表示項目)
    Private Const CMlngCmbFontSize              As Integer = 16             'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize          As Integer = 16             'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbRowHeight             As Integer = 43             'ﾘｽﾄ行の高さ
    Private Const CMlngCmbSortAsc               As Integer = 1              '昇順(ｿｰﾄ)

    '@vsfLotの定数宣言(ｶﾗﾑ)
    Private Const CMvsfLotColNo                 As Integer = 0              '№
    Private Const CMvsfLotColLotID              As Integer = 1              'ﾛｯﾄID
    Private Const CMvsfLotColLimitTime          As Integer = 2              '時間制限
    Private Const CMvsfLotColKb                 As Integer = 3              '保/停区分
    Private Const CMvsfLotColNowSt              As Integer = 4              '状態
    Private Const CMvsfLotColPdID               As Integer = 5              '機種
    Private Const CMvsfLotColPdVersion          As Integer = 6              '機種Ver
    Private Const CMvsfLotColCarrierID          As Integer = 7              'ｷｬﾘｱID
    Private Const CMvsfLotColToCarrierId        As Integer = 8              'ｷｬﾘｱID(Unloader)
    Private Const CMvsfLotColACarrierId         As Integer = 9              'AｷｬﾘｱID
    Private Const CMvsfLotColATrayNum           As Integer = 10             'Aﾄﾚｲ数
    Private Const CMvsfLotColTapeBatchId        As Integer = 11             'ﾃｰﾌﾟﾊﾞｯﾁID
    Private Const CMvsfLotColOvenBatchId        As Integer = 12             'ｵｰﾌﾞﾊﾞｯﾁID
    Private Const CMvsfLotColALDBatchId         As Integer = 13             'ALDﾊﾞｯﾁID
    Private Const CMvsfLotColFlowClass          As Integer = 14             '種別
    Private Const CMvsfLotColPriority           As Integer = 15             '優先順位
    Private Const CMvsfLotColOpID               As Integer = 16             '大工程
    Private Const CMvsfLotColStepID             As Integer = 17             '小工程
    Private Const CMvsfLotColWfNum              As Integer = 18             'WF枚数
    Private Const CMvsfLotColChipNum            As Integer = 19             'ﾁｯﾌﾟ数
    Private Const CMvsfLotColALDProcessNum      As Integer = 20             '防湿ALD処理番号
    Private Const CMvsfLotColALDProcessName     As Integer = 21             '防湿ALD処理名
    Private Const CMvsfLotColComments           As Integer = 22             'ｺﾒﾝﾄ
    Private Const CMvsfLotColEditTime           As Integer = 23             '最終更新日
    Private Const CMvsfLotColWorkCondition      As Integer = 24             '作業指示
    Private Const CMvsfLotColEngEmpName         As Integer = 25             'ﾛｯﾄ担当
    Private Const CMvsfLotColCollectionId       As Integer = 26             '収集項目
    Private Const CMvsfLotColCollectionVersion  As Integer = 27             '収集項目Ver
    Private Const CMvsfLotColResultFlag         As Integer = 28             'SPC結果

    '@vsfLotの定数宣言(幅)
    Private Const CMvsfLotColWNo                As Integer = 37             '№
    Private Const CMvsfLotColWKb                As Integer = 27             '保/停区分
    Private Const CMvsfLotColWNowSt             As Integer = 87             '状態
    Private Const CMvsfLotColWLimitTime         As Integer = 189            '時間制限(ﾃﾞｰﾀなし)
    Private Const CMvsfLotColWPdID              As Integer = 54             '機種
    Private Const CMvsfLotColWPdVersion         As Integer = 54             '機種Ver
    Private Const CMvsfLotColWLotID             As Integer = 110            'ﾛｯﾄID
    Private Const CMvsfLotColWWfID              As Integer = 144            'WFID
    Private Const CMvsfLotColWWfNum             As Integer = 133            'WF枚数
    Private Const CMvsfLotColWChipNum           As Integer = 133            'ﾁｯﾌﾟ数
    Private Const CMvsfLotColWCarrierID         As Integer = 65             'ｷｬﾘｱID
    Private Const CMvsfLotColWToCarrierID       As Integer = 65             'ｷｬﾘｱID(Unloader)
    Private Const CMvsfLotColWACarrierID        As Integer = 65             'AｷｬﾘｱID
    Private Const CMvsfLotColWATrayNum          As Integer = 65             'Aﾄﾚｲ数
    Private Const CMvsfLotColWTapeBatchID       As Integer = 54             'ﾃｰﾌﾟﾊﾞｯﾁID
    Private Const CMvsfLotColWOvenBatchID       As Integer = 54             'ｵｰﾌﾞﾊﾞｯﾁID
    Private Const CMvsfLotColWALDBatchID        As Integer = 54             'ALDﾊﾞｯﾁID
    Private Const CMvsfLotColWFlowClass         As Integer = 25             '種別
    Private Const CMvsfLotColWPriority          As Integer = 25             '優先順位
    Private Const CMvsfLotColWOpID              As Integer = 133            '大工程
    Private Const CMvsfLotColWStepID            As Integer = 133            '小工程
    Private Const CMvsfLotColWALDProcessNum     As Integer = 27             '防湿ALD処理番号
    Private Const CMvsfLotColWALDProcessName    As Integer = 133            '防湿ALD処理名
    Private Const CMvsfLotColWComments          As Integer = 133            'ｺﾒﾝﾄ
    Private Const CMvsfLotColWEditTime          As Integer = 133            '最終更新日
    Private Const CMvsfLotColWWorkCondition     As Integer = 133            '作業指示
    Private Const CMvsfLotColWEngEmpName        As Integer = 133            'ﾛｯﾄ担当
    Private Const CMvsfLotColWCollectionId      As Integer = 7              '収集項目
    Private Const CMvsfLotColWCollectionVersion As Integer = 7              '収集項目Ver
    Private Const CMvsfLotColWResultFlag        As Integer = 7              'SPC結果

    '@vsfLotの定数宣言(ﾀｲﾄﾙ)
    Private Const CMvsfLotColTNo                As String = "№"
    Private Const CMvsfLotColTKb                As String = ""
    Private Const CMvsfLotColTNowSt             As String = "状態"
    Private Const CMvsfLotColTLimitTime         As String = "時間制限"
    Private Const CMvsfLotColTPdID              As String = "機種"
    Private Const CMvsfLotColTPdVersion         As String = "機種Ver"
    Private Const CMvsfLotColTLotID             As String = "ﾛｯﾄID"
    Private Const CMvsfLotColTWfID              As String = "WFID"
    Private Const CMvsfLotColTWfNum             As String = "WF枚数"
    Private Const CMvsfLotColTChipNum           As String = "ﾁｯﾌﾟ"
    Private Const CMvsfLotColTCarrierID         As String = "ｷｬﾘｱID"
    Private Const CMvsfLotColTToCarrierID       As String = "ULｷｬﾘｱID"
    Private Const CMvsfLotColTACarrierID        As String = "AｷｬﾘｱID"
    Private Const CMvsfLotColTATrayNum          As String = "Aﾄﾚｲ数"
    Private Const CMvsfLotColTTapeBatchID       As String = "ﾃｰﾌﾟﾊﾞｯﾁID"
    Private Const CMvsfLotColTOvenBatchID       As String = "ｵｰﾌﾞﾝﾊﾞｯﾁID"
    Private Const CMvsfLotColTALDBatchID        As String = "ALDﾊﾞｯﾁID"
    Private Const CMvsfLotColTFlowClass         As String = "種別"
    Private Const CMvsfLotColTPriority          As String = "優"
    Private Const CMvsfLotColTOpID              As String = "大工程"
    Private Const CMvsfLotColTStepID            As String = "小工程"
    Private Const CMvsfLotColTALDProcessNum     As String = "ALD処理No"
    Private Const CMvsfLotColTALDProcessName    As String = "ALD処理名"
    Private Const CMvsfLotColTComments          As String = "ｺﾒﾝﾄ"
    Private Const CMvsfLotColTEditTime          As String = "最終更新日"
    Private Const CMvsfLotColTWorkCondition     As String = "作業指示"
    Private Const CMvsfLotColTEngEmpName        As String = "ﾛｯﾄ担当"
    Private Const CMvsfLotColTCollectionId      As String = "収集項目"
    Private Const CMvsfLotColTCollectionVersion As String = "収集項目Ver"
    Private Const CMvsfLotColTResultFlag        As String = "SPC結果"

    '@vsfLot定数宣言(その他)
    Private Const CMvsfLotCols                  As Integer = 29             'ｶﾗﾑ数
    Private Const CMvsfLotHHeight               As Integer = 21             'ﾍｯﾀﾞｰの高さ
    Private Const CMvsfLotHeight                As Integer = 21             '1ｽﾛｯﾄの高さ
    Private Const CMvsfLotTitleRow              As Integer = 0              'ﾀｲﾄﾙ行
    Private Const CMvsfLotTFontSize             As Integer = 12             'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMvsfLotFontSize              As Integer = 16             'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ

    '@vsfWpの定数宣言(ｶﾗﾑ)
    Private Const CMvsfWPColNo                      As Integer = 0          '№
    Private Const CMvsfWPColWpID                    As Integer = 1          'WPID
    Private Const CMvsfWPColWpName                  As Integer = 2          '装置名
    Private Const CMvsfWpColRecipe                  As Integer = 3          'ﾚｼﾋﾟ
    Private Const CMvsfWPColLotRecipeFlag           As Integer = 4          'ﾛｯﾄﾚｼﾋﾟﾌﾗｸﾞ
    Private Const CMvsfWpColActionFlag              As Integer = 5          'ｱｸｼｮﾝ予約表示ﾌﾗｸﾞ
    Private Const CMvsfWPColLoaderUnloaderFlag      As Integer = 6          'Loader/Unloaderﾌﾗｸﾞ
    Private Const CMvsfWpColBeforeCarrierTypeId     As Integer = 7          'INｷｬﾘｱﾀｲﾌﾟID
    Private Const CMvsfWpColBeforeCarrierTypeName   As Integer = 8          'INｷｬﾘｱﾀｲﾌﾟ名
    Private Const CMvsfWpColAfterCarrierTypeId      As Integer = 9          'OUTｷｬﾘｱﾀｲﾌﾟID
    Private Const CMvsfWpColAfterCarrierTypeName    As Integer = 10         'OUTｷｬﾘｱﾀｲﾌﾟ名
    Private Const CMvsfWPColEqType                  As Integer = 11         'EQﾀｲﾌﾟ
    Private Const CMvsfWpColMcType                  As Integer = 12         'MCﾀｲﾌﾟ
    Private Const CMvsfWpColMesModeId               As Integer = 13         'MESMODE
    Private Const CMvsfWpColMesModeStatus           As Integer = 14         'MESMODE_STATUS
    Private Const CMvsfWpColWpStatusName            As Integer = 15         '処理状態
    Private Const CMvsfWpColUseId                   As Integer = 16         '装置状態ID
    Private Const CMvsfWpColWpTypeFlag              As Integer = 17         'WP_TYPE_FLAG
    Private Const CMvsfWPColCleanCondition          As Integer = 18         '洗浄条件
    Private Const CMvsfWpColWpStopFlag              As Integer = 19         '装置停止
    Private Const CMvsfWpColFtpDataFlag             As Integer = 20         'FTP装置ﾃﾞｰﾀ転送
    Private Const CMvsfWPColOpID                    As Integer = 21         '大工程
    Private Const CMvsfWPColStepID                  As Integer = 22         '小工程
    Private Const CMvsfWpColNextOpId                As Integer = 23         '次大工程
    Private Const CMvsfWpColNextStepId              As Integer = 24         '次小工程
    Private Const CMvsfWpColALDProcessNum           As Integer = 25         '防湿ALD処理番号
    Private Const CMvsfWpColALDProcessName          As Integer = 26         '防湿ALD処理名

    '@vsfWpの定数宣言(表示幅)
    Private Const CMvsfWPColWNo                     As Integer = 37         '№
    Private Const CMvsfWPColWWpID                   As Integer = 0          '装置ID
    Private Const CMvsfWPColWWpName                 As Integer = 187        '装置
    Private Const CMvsfWpColWRecipe                 As Integer = 187        'ﾚｼﾋﾟ
    Private Const CMvsfWPColWLotRecipeFlag          As Integer = 0          'ﾛｯﾄﾚｼﾋﾟﾌﾗｸﾞ
    Private Const CMvsfWpColWActionFlag             As Integer = 0          'ｱｸｼｮﾝ予約表示ﾌﾗｸﾞ
    Private Const CMvsfWPColWLoaderUnloaderFlag     As Integer = 0          'Loader/Unloaderﾌﾗｸﾞ
    Private Const CMvsfWpColWBeforeCarrierTypeId    As Integer = 0          'INｷｬﾘｱﾀｲﾌﾟID
    Private Const CMvsfWpColWBeforeCarrierTypeName  As Integer = 187        'INｷｬﾘｱﾀｲﾌﾟ名
    Private Const CMvsfWpColWAfterCarrierTypeId     As Integer = 0          'OUTｷｬﾘｱﾀｲﾌﾟID
    Private Const CMvsfWpColWAfterCarrierTypeName   As Integer = 187        'OUTｷｬﾘｱﾀｲﾌﾟ名
    Private Const CMvsfWPColWEqType                 As Integer = 0          'EQﾀｲﾌﾟ
    Private Const CMvsfWpColWMCType                 As Integer = 0          'MCﾀｲﾌﾟ
    Private Const CMvsfWpColWMesModeId              As Integer = 67         'MESMODE
    Private Const CMvsfWpColWMesModeStatus          As Integer = 0          'MESMODE_STATUS
    Private Const CMvsfWpColWWpStatusName           As Integer = 67         '処理状態
    Private Const CMvsfWpColWUseId                  As Integer = 0          '装置状態ID
    Private Const CMvsfWpColWWpTypeFlag             As Integer = 0          'WP_TYPE_FLAG
    Private Const CMvsfWPColWCleanCondition         As Integer = 0          '洗浄条件
    Private Const CMvsfWpColWWpStopFlag             As Integer = 0          '装置停止
    Private Const CMvsfWpColWFtpDataFlag            As Integer = 0          'FTP装置ﾃﾞｰﾀ転送
    Private Const CMvsfWPColWOpID                   As Integer = 67         '大工程
    Private Const CMvsfWPColWStepID                 As Integer = 67         '小工程
    Private Const CMvsfWpColWNextOpId               As Integer = 333        '次大工程
    Private Const CMvsfWpColWNextStepId             As Integer = 333        '次小工程
    Private Const CMvsfWpColWALDProcessNum          As Integer = 0          '防湿ALD処理番号
    Private Const CMvsfWpColWALDProcessName         As Integer = 0          '防湿ALD処理名

    '@vsfWpの定数宣言(ﾀｲﾄﾙ)
    Private Const CMvsfWPColTNo                     As String = "№"
    Private Const CMvsfWPColTWpID                   As String = "WPID"
    Private Const CMvsfWPColTWpName                 As String = "装置名"
    Private Const CMvsfWpColTRecipe                 As String = "ﾚｼﾋﾟ"
    Private Const CMvsfWPColTLotRecipeFlag          As String = "LOT_RECIPE_FLAG"
    Private Const CMvsfWpColTActionFlag             As String = "ﾃﾞﾌｫﾙﾄ"
    Private Const CMvsfWPColTLoaderUnloaderFlag     As String = "LODER_UNLODER_FLAG"
    Private Const CMvsfWpColTBeforeCarrierTypeId    As String = "BEFORE_CARRIER_TYPE_ID"
    Private Const CMvsfWpColTBeforeCarrierTypeName  As String = "ｷｬﾘｱﾀｲﾌﾟ(IN)"
    Private Const CMvsfWpColTAfterCarrierTypeId     As String = "AFTER_CARRIER_TYPE_ID"
    Private Const CMvsfWpColTAfterCarrierTypeName   As String = "ｷｬﾘｱﾀｲﾌﾟ(OUT)"
    Private Const CMvsfWPColTEqType                 As String = "EQ_TYPE"
    Private Const CMvsfWpColTMcType                 As String = "MC_TYPE"
    Private Const CMvsfWpColTMesModeId              As String = "運用ﾓｰﾄﾞ"
    Private Const CMvsfWpColTMesModeStatus          As String = "MESMODE_STATUS"
    Private Const CMvsfWpColTWpStatusName           As String = "処理状態"
    Private Const CMvsfWpColTUseId                  As String = "装置状態ID"
    Private Const CMvsfWpColTWpTypeFlag             As String = "WP_TYPE_FLAG"
    Private Const CMvsfWpColTCleanCondition         As String = "洗浄条件"
    Private Const CMvsfWpColTWpStopFlag             As String = "装置停止"
    Private Const CMvsfWpColTFtpDataFlag            As String = "FTP装置ﾃﾞｰﾀ転送"
    Private Const CMvsfWPColTOpID                   As String = "大工程"
    Private Const CMvsfWPColTStepID                 As String = "小工程"
    Private Const CMvsfWpColTNextOpId               As String = "次大工程"
    Private Const CMvsfWpColTNextStepId             As String = "次小工程"
    Private Const CMvsfWpColTALDProcessNum          As String = "ALD処理No"
    Private Const CMvsfWpColTALDProcessName         As String = "ALD処理名"

    Private Const CMvsfWPCols                       As Integer = 27         'ｶﾗﾑ数
    Private Const CMvsfWPHHeight                    As Integer = 21         'ﾍｯﾀﾞｰの高さ
    Private Const CMvsfWPHeight                     As Integer = 43         '1ｽﾛｯﾄの高さ
    Private Const CMvsfWPTitleRow                   As Integer = 0          'ﾀｲﾄﾙ行
    Private Const CMvsfWPTFontSize                  As Integer = 12         'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMvsfWPFontSize                   As Integer = 16         'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ

    Private Const CMstrBrLeft                       As String = "["
    Private Const CMstrBrRight                      As String = "]"
    Private Const CMstrEnter                        As String = "$"


    Private Const CMstrResultFlag00                 As String = "00"        '流動可(次工程送出可)
    Private Const CMstrResultFlag1                  As String = "1"         '10の位で使用時：移載予約状態、1の位で使用時：ｱｸｼｮﾝ予約停止
    Private Const CMstrResultFlag2                  As String = "2"         'ｱｸｼｮﾝ予約保留
    Private Const CMstrResultFlag3                  As String = "3"         '異常処理票保留
    Private Const CMstrResultFlag4                  As String = "4"         '通常保留
    Private Const CMlngResultRight1                 As Integer = 1          '処理結果の右1桁用
    Private Const CMstrResultFlag_                  As String = "#"         '処理結果比較用

    '@次工程送出ﾊﾞｯﾁﾌﾗｸﾞ定数宣言
    Private Const CMlngBatchWorkEnd                 As Integer = 1          'ﾊﾞｯﾁ作業終了正常処理(=1)
    Private Const CMlngBatchOnError                 As Integer = 2          'ﾊﾞｯﾁ作業終了通信ｴﾗｰ(=2)
    Private Const CMlngBatchRequestFail             As Integer = 3          'ﾊﾞｯﾁ作業終了正常処理(=3)


    Private Const CMstrDefault                  As String = "○"            '小工程ﾃﾞﾌｫﾙﾄﾏｰｸ
    Private Const CMlngEqFlag                   As Integer = 0              '装置ﾌﾗｸﾞ

    Private Const CMstrAri                      As String = "あり"          '代替工程用
    Private Const CMstrNasi                     As String = "なし"          '代替工程用

    Private Const CMstrActionFlgNever           As String = "0"             'ｱｸｼｮﾝ予約ﾌﾗｸﾞ(未表示)
    Private Const CMstrColon                    As String = ":"             'ｺﾛﾝ

    Private Const CMstrEN0030Title              As String = "作業開始"
    Private Const CMstrNoneRecipe               As String = "レシピ無し"    'ﾚｼﾋﾟ設定ﾎﾞﾀﾝ制御用

    '@制限ﾀｲﾌﾟ
    Private Const CMstrRestrictTypeID1          As String = "1"             '以下
    Private Const CMstrRestrictTypeID2          As String = "2"             '以上

    '@ﾗﾍﾞﾙ最大ｲﾝﾃﾞｯｸｽ数
    Private Const CMlngLabelMaxIndex            As Integer = 10

    '@ｶﾗｰ(専属装置以外は青、それ以外は赤)
    Private Const CMlngRedColor                 As Integer = &HFF           '赤色

    '@その他
    Private Const CMlngRecpCrLen                As Integer = 16             'ﾚｼﾋﾟ折り返し文字数
    Private Const CMlngKeyAsciiComma            As Integer = 44             'KeyAscii=44(ｶﾝﾏ)
    Private Const CMVariableResultNG            As String = "1"             'CMP研磨ﾃﾞｰﾀなし(NG)
    Private Const CMstrHandWork                 As String = "0"             'ﾊﾝﾄﾞﾜｰｸ
    Private Const CMlngMaxDispRow               As Integer = 4              'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ﾛｯﾄｺﾒﾝﾄ)
    Private Const CMlngMaxDispMemoRow           As Integer = 3              'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '@保留/停止/ﾘﾜｰｸ
    Private Const CMstrLotHoldFlgOn             As String = "1"             '保留ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrLotStopFlgOn             As String = "1"             '停止ﾛｯﾄﾌﾗｸﾞON

    '@ﾛｯﾄ状態表記
    Private Const CMstrHo                       As String = "保"            '保留表示
    Private Const CMstrTei                      As String = "停"            '停止表示

    '@代替工程No(防湿ALDでは代替なしの為0固定)
    Private Const CMlngAltNum                   As Integer = 0

    '@PORT
    Private Const CMstrLoaderPortNum            As String = "1"
    Private Const CMstrUnloaderPortNum          As String = "2"

    '@次工程ｵﾌﾟｼｮﾝﾎﾞﾀﾝの定数宣言
    Private Const CMlngOptLotNextSend0          As Integer = 0              '次工程自動送出あり
    Private Const CMlngOptLotNextSend1          As Integer = 1              '次工程自動送出なし

    '@追加処理結果用
    Private Const CMstrOK                       As String = "OK"            '結果OK
    Private Const CMstrNG                       As String = "NG"            '結果NG

    '@SPC規格値判定結果
    Private Const CMstrSpecCheckOK              As String = "0"             '正常
    Private Const CMstrSpecCheckSPCNG           As String = "1"             'SPC異常
    Private Const CMstrSpecCheckSpecNG          As String = "2"             '規格値異常
    Private Const CMstrSpecCheckOtherNG         As String = "3"             'その他異常

    '@SPC判定ｱﾗｰﾑﾒｯｾｰｼﾞﾎﾞｯｸｽ ｷｬﾌﾟｼｮﾝ
    Private Const CMstrSpecCheckAlarmCaption    As String = "品質管理システムアラーム"

    '@電特、保留時のﾒｯｾｰｼﾞ
    Private Const CMstrMsgELT                   As String = "電特"
    Private Const CMstrMsgTFT                   As String = "TFT"
    Private Const CMstrMsgEltTft                As String = "電特及びTFT"
    Private Const CMstrMsgHold                  As String = "保留"
    Private Const CMstrMsgExcpHold              As String = "異常処理票保留"
    Private Const CMstrMsgActHold               As String = "アクション予約保留"
    Private Const CMstrMsgActStop               As String = "アクション予約停止"

    Private Const CMstrLotEventChip             As String = "1"             'ﾁｯﾌﾟ
    Private Const CMstrLotEventMove             As String = "2"             '移載
    Private Const CMstrLotEventLotOut           As String = "3"             'ﾛｯﾄ終了
    Private Const CMstrLotEventWfScrap          As String = "4"             'WF廃棄


    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mstrCarrier                         As String                   'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mblnTakeOverDispFlg                 As Boolean                  '引継ぎ情報表示済みﾌﾗｸﾞ
    Private mblnValidateFlag                    As Boolean                  'True:Validate完了、False:Validate走行中(ﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
    Private mstrPdErrMsg                        As String                   '機種限定判定ｴﾗｰMsg格納用
    Private mstrLimitErrMsg                     As String                   '部材期限判定ｴﾗｰMsg格納用
    Private mstrPdForcedAction                  As String                   '機種限定強制実行ﾌﾗｸﾞ格納用(0=通常実行、1=強制実行)
    Private mstrLimitForcedAction               As String                   '部材期限超過強制実行ﾌﾗｸﾞ格納用(0=通常実行、1=強制実行)
    Private mtypLotprestate                     As List(Of Lotprestate)     'ﾛｯﾄ情報格納構造体
    Private mtypWorkALDLotList                  As WorkALDLotList
    Private mtypLotWpList                       As ALDWpList
    Private mlngCurrentLotRowNo                 As Integer
    Private mtypACarrierGroup                   As ACarrierGroup
    Private mtypLotAction                       As List(Of LotAction)
    Private mblnACarrierMoQuFd                  As Boolean                  '@ACarrier(MO/QU/FD)
    Private buttonProcessing                    As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                  'NSYS WindowCloseフラグ
    Private mblnCarrierValidateCallFlag         As Boolean                  'NSYS txtCarrier_Validateを直接呼び出している場合 True
    Private mstrLotLastUpdate                   As String                   'ﾛｯﾄ最終更新日時

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
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値
        Dim lstrKey         As String

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@起動区分
            Select Case pstrfrmxxEN2Q0Div
                Case CPstrCD10
                    lstrKey = CPstrKeyEN02Q1
                
                Case CPstrCD11
                    lstrKey = CPstrKeyEN02Q2
                    
                Case CPstrCD12
                    lstrKey = CPstrKeyEN02Q3
                    
                Case CPstrCD13
                    lstrKey = CPstrKeyEN02Q4
                    
                Case Else
                    lstrKey = CPstrKeyEN02Q0
            End Select
                
            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝの判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(lstrKey, CMstrLocalVersion)
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
                Exit Sub
            End If
            
            '@=======================
            '@ ﾎﾞﾀﾝ位置変更
            '@=======================
            'cmdACarrierSelect.Top = cmdWorkRecord.Top
            'cmdACarrierSelect.Left = cmdWorkRecord.Left

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset
            
            '@=======================
            '@ 各種初期化処理(画面内ｺﾝﾄﾛｰﾙ、変数等)
            '@=======================
            Call prvfrmxxEN02Q0_Init()
            'NSYS グリッド非活性
            VsfLot.Enabled = False
            vsfWP.Enabled = False
            
            
            '@ｺﾒﾝﾄ、作業ﾒﾓ用の上下ｽｸﾛｰﾙﾎﾞﾀﾝの無効化
            cmdCommentUp.Enabled = False                'ｺﾒﾝﾄ ▲ﾎﾞﾀﾝ
            cmdCommentDown.Enabled = False              'ｺﾒﾝﾄ ▼ﾎﾞﾀﾝ
            cmdMemoUp.Enabled = False                   '作業ﾒﾓ ▲ﾎﾞﾀﾝ
            cmdMemoDown.Enabled = False                 '作業ﾒﾓ ▼ﾎﾞﾀﾝ
            
            '@ｷｬﾘｱIDのｸﾘｱ
            txtCarrier.Text = vbNullString

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：起動成功"をｾｯﾄ
            pblnFormLoad = True

            '@引継ぎ情報表示済みﾌﾗｸﾞに"False：未表示"をｾｯﾄ
            mblnTakeOverDispFlg = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0        '機能ID
                .strProcName = "Form_Load"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString       'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        
        Dim llngLoopCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾀ

        Try
            
            '@引継ぎ情報表示済みﾌﾗｸﾞが"True:表示済"か
            '@　※FormLoad後、最初の1回しか処理しないように
            If mblnTakeOverDispFlg = True Then
                '@引継ぎ情報が表示済みの場合
                
                '@Escﾎﾞﾀﾝを有効にし、処理抜け
                Me.CancelButton = Me.cmdClose
                Exit Sub
            End If
                
            '@Escﾎﾞﾀﾝを有効にする
            Me.CancelButton = Me.cmdClose
            
            '@引継ぎ情報表示済みﾌﾗｸﾞに"True：表示済"をｾｯﾄする
            mblnTakeOverDispFlg = True
            
            '@Validateﾌﾗｸﾞの初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            mblnValidateFlag = True
            
            '@引継情報のMO/QUの場合(ｷｬﾘｱ情報無い)
            If ptypCommonInfo.strCarrierId = vbNullString And _
                ptypCommonInfo.strLotID <> vbNullString And _
                (ptypCommonInfo.strFlowClass = CPstrFlowClassMO Or ptypCommonInfo.strFlowClass = CPstrFlowClassQU) Then
                    
                Exit Sub
                    
                '@=======================
                '@ ﾛｯﾄID検索
                '@=======================
                'Call prvKeyLot_Sel(ptypCommonInfo.strLotID)
            
            '@引継ぎ情報のｷｬﾘｱIDがNULL以外か
            ElseIf ptypCommonInfo.strCarrierId <> vbNullString Then
                '@NULL以外の場合
                
                '@引継ぎ情報のｷｬﾘｱIDを設定する
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                
                '@=======================
                '@ ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                '@=======================
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                
                '@=======================
                '@ ﾃﾞﾌｫﾙﾄ装置以外(pstrTerminalFlag="1"orNULL)かにより、ﾗﾍﾞﾙ&ｸﾞﾘｯﾄﾞﾀｲﾄﾙ行の色を変える
                '@ (ｷｬﾘｱ引き継ぎ時の処理)
                '@=======================
                Call prvColorChang()
                
                '@選択可能装置があるか
                If vsfWp.Rows.Count > 2 Then
                
                    '@装置IDから選択状態の設定を行う(装置選択の一覧がある場合)
                    For llngLoopCnt = 1 To vsfWp.Rows.Count - 1
                    
                        '@引継ぎ情報の大工程、小工程、装置IDと、装置一覧ｸﾞﾘｯﾄﾞの大工程、小工程、装置IDが全て同じか
                        If vsfWp.GetData(llngLoopCnt, CMvsfWPColWpID) = ptypCommonInfo.strWpID Then
                            
                            '@同じ大工程、小工程、装置IDが存在する場合は選択状態にする
                            vsfWp.Select(llngLoopCnt, 0)
                            
                            '@=======================
                            '@ ｿｰﾄ前後処理(擬似的に行選択したので、ｶﾚﾝﾄ行情報格納の為に行なう必要がある)
                            '@=======================
                            Call pubVsfBeforeSort(vsfWp, CMvsfWPColWpID)
                            'Call pubVsfAfterSort(vsfWp, CMvsfWPColWpID, cmdWpUP, cmdWpDown, False)
                            
                            Exit For
                        End If
                    Next
                End If
            End If

            'NSYS Activate中にpublngMsgBox等で別ウィンドウを表示するとActivateがキャンセルされるため、再Activateする
            'NSYS Activateイベント中にActivate()を呼び出しても作用しないため、遅延で実行する。ラムダ式使用
            Dim lfuncActivate As Action = Sub()
                                              Me.Activate()
                                          End Sub
            Me.BeginInvoke(lfuncActivate)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0             '機能ID
                .strProcName = "Form_Activate"              'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try
            
            '@以下の条件の場合、ｷｰｺｰﾄﾞを初期化し処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If

            '@装置一覧ｸﾞﾘｯﾄﾞがｱｸﾃｨﾌﾞか
            If ActiveControl.Name = vsfWp.Name Then
                
                '@ｶﾚﾝﾄ行がﾀｲﾄﾙ行ではないか
                If vsfWp.Row > vsfWp.Rows.Fixed Then
                    
                    '@ｶﾚﾝﾄ列が装置名以外か
                    If vsfWp.Col <> CMvsfWPColWpName Then
                    
                        '@ｶﾚﾝﾄ列を装置名に移動
                        vsfWp.Col = CMvsfWPColWpName
                    End If
                End If
            End If
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            'Call pubVsf_KeyDown(KeyCode, ActiveControl.Name, vsfWp, cmdWpUP, cmdWpDown)
            
            '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
            Select Case e.KeyCode
            
                '@〓 Enterｷｰ 〓
                Case Keys.Return
                
                    '@★★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★★
                    Select Case ActiveControl.Name
                    
                        '@〓〓 ｷｬﾘｱID 〓〓
                        Case txtCarrier.Name
                            
                            '@=======================
                            '@ ｷｬﾘｱIDﾃｷｽﾄValidate処理
                            '@=======================
                            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                            e.Handled = True

                        '@〓〓 作業ﾒﾓ 〓〓
                        Case txtWorkMemo.Name
                        
                            '@処理なし
                                                    
                        '@〓〓 UnloaderｷｬﾘｱID 〓〓
                        Case txtUnloaderCarrier.Name
                        
                            '@=======================
                            '@ ｱﾝﾛｰﾀﾞｷｬﾘｱIDﾃｷｽﾄValidate処理
                            '@=======================
                            Call txtUnloaderCarrier_Validate(txtUnloaderCarrier, New CancelEventArgs(False))
                            e.Handled = True
                            
                        '@〓〓 その他 〓〓
                        Case Else
                        
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    
                    End Select
                    
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0        '機能ID
                .strProcName = "Form_KeyDown"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString       'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyPress
    '機　能：ﾌｫｰﾑ　ｷｰ押下時処理
    '引　数：KeyAscii：入力ｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub Form_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress
        
        Try
            
            '@ｷｰｺｰﾄﾞが"'(ｶﾝﾏ)"か
            If Asc(e.KeyChar) = CMlngKeyAsciiComma Then
            
                '@ｶﾝﾏは入力禁止なので、ｷｰｺｰﾄﾞを無効にする
                e.Handled = True
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0        '機能ID
                .strProcName = "Form_KeyPress"      'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString       'ｴﾗｰﾒｯｾｰｼﾞ
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
    '戻り値：
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      'ACT開放結果格納

        Try
            
            '@"×"ﾎﾞﾀﾝでの終了か
            If mblnCloseFromControlMenu Then
            
                '@=======================
                '@　閉じるﾎﾞﾀﾝ押下時処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, EventArgs.Empty)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@各種ﾊﾟﾌﾞﾘｯｸﾌﾗｸﾞを初期化
            pblnFormLoad = False                    '装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnMaterialSelectFlag = False          '使用部材選択済みﾌﾗｸﾞの初期化
            pblnfrmxxEN02Q0Kbn = False              '引継作業開始ﾌﾗｸﾞの初期化
            
            '@使用部材ﾘｽﾄ構造体をｸﾘｱ
            ptypChkMaterial.typMaterialTypeList = Nothing
            ptypChkMaterial.lngMaterialTypeCnt = 0              '部材種別IDｶｳﾝﾄ
            ptypChkMaterial.strClassDivision = vbNullString     '処理区分
            ptypChkMaterial.strLotID = vbNullString             'ﾛｯﾄID
            ptypChkMaterial.strMaterialID = vbNullString        '部材ID
            ptypChkMaterial.strMaterialLotID = vbNullString     '部材管理ID
            ptypChkMaterial.strMaterialTypeID = vbNullString    '部材種別ID
            ptypChkMaterial.strMsgVer = vbNullString            'Msgﾊﾞｰｼﾞｮﾝ
            ptypChkMaterial.strSbID = vbNullString              'ｼｽﾃﾑﾌﾞﾛｯｸ
            ptypChkMaterial.strWpID = vbNullString              '装置ID
            
            '@ﾊﾟﾌﾞﾘｯｸ構造体の初期化
            mtypLotprestate = Nothing
            mtypLotAction = Nothing
            
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

                '@=======================
                '@ ﾒｲﾝﾒﾆｭｰ画面拡張処理
                '@=======================
                Call pubMenuExpand_Disp

            End If
            
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0            '機能ID
                .strProcName = "Form_QueryUnload"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change
        
        Try
            
            '@検索ﾃﾞｰﾀがある場合
            If mtypWorkALDLotList.strCarrierId <> vbNullString Then
                '@=======================
                '@　画面情報初期化処理
                '@=======================
                Call prvfrmxxEN02Q0_Init()
                'NSYS グリッド非活性
                VsfLot.Enabled = False
                vsfWP.Enabled = False
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
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
    '機　能：ｷｬﾘｱIDのLOST
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ1
        Dim llngCnt1                As Integer              '汎用ｶｳﾝﾀ1
        Dim llngCnt2                As Integer              '汎用ｶｳﾝﾀ2
        Dim llngWpCount             As Integer              '端末WP_ID数
        Dim lstrWpNameAtList        As String
        Dim lstrWpNameByTerminal    As String
        Dim lstrCurrentWpID         As String
        Dim lblnWpIDMatch           As Boolean
        Dim lblnAns                 As Boolean
        Dim llngRowCnt              As Integer              '装置ﾘｽﾄの行ｶｳﾝﾀ
        Dim llngRowSetPosition      As Integer              '対象装置の行番号
        Dim ltypTmInfo              As UtilRefTmInfo        '端末設定情報格納
        Dim lstrWarLotInfo          As String
        Dim laryCaller()            As Control              'NSYS SetFocus使用の呼出元コントロール


        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If mblnCarrierValidateCallFlag = True Then
                laryCaller = {}
            Else
                laryCaller = { txtCarrier }
            End If
            
            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrier.Text) = vbNullString Then
                
                '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(cmdClose, laryCaller)
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM07W>$$キャリアIDは6桁で入力してください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽを留める
                e.Cancel = True
                Exit Sub
            End If
                
            '@ﾌﾗｸﾞ判定開始(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            mblnValidateFlag = False
            
            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If txtCarrier.Text = mstrCarrier Then
                If vsfWp.Enabled = True Then
                    Call prvSetFocus(vsfWp, laryCaller)
                Else
                    Call prvSetFocus(cmdClose, laryCaller)
                End If
            
                '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
                mblnValidateFlag = True
                Exit Sub
            End If
                        
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "txtCarrier_Validate"
            Call pubResponseStart(Me.Text, lstrEventName)
                        
            '@=======================
            '@ 防湿ALD作業作業ﾛｯﾄ一覧取得
            '@=======================
            lblnAns = prvblnWorkLotList_Sel(vbNullString, txtCarrier.Text)
            
            If lblnAns = False Then
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Text, lstrEventName)
                
                '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
                mblnValidateFlag = True
                
                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                e.Cancel = True
                Exit Sub
            End If
                
            '@ﾛｯﾄ数が検索できない場合は終了
            If mtypWorkALDLotList.lngAldWorkLotListCnt < 0 Then
                Exit Sub
            End If

            '@領域確保
            mtypLotprestate = New List(Of Lotprestate)(mtypWorkALDLotList.lngAldWorkLotListCnt)
            For llngCnt = 0 To mtypWorkALDLotList.lngAldWorkLotListCnt - 1
                mtypLotprestate.Add(New Lotprestate)
            Next
            
            '@ｷｬﾘｱ無判定
            mblnACarrierMoQuFd = False
            
            '@ﾛｯﾄ毎処理
            For llngCnt = 0 To mtypWorkALDLotList.lngAldWorkLotListCnt - 1
                
                '@ｷｬﾘｱIDが無い場合
                '@製品以外(QU/MO/SD等)はﾛｯﾄ投入時にｷｬﾘｱIDはなくAｷｬﾘｱIDを指定する為
                '@ｷｬﾘｱIDが無い場合がある
                If mtypWorkALDLotList.typAldWorkLotList(llngCnt).strCarrierId = vbNullString Then
                    mblnACarrierMoQuFd = True
                    '@表示用ﾛｯﾄ作成
                    If lstrWarLotInfo = vbNullString Then
                        lstrWarLotInfo = mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLotID
                    Else
                        lstrWarLotInfo = lstrWarLotInfo + "/" + mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLotID
                    End If
                Else
                    '@=======================
                    '@ ﾛｯﾄ現在状態取得
                    '@=======================
                    lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                            pstrfrmxxEN2Q0Div, _
                                            mtypWorkALDLotList.typAldWorkLotList(llngCnt).strCarrierId, _
                                            mtypLotprestate(llngCnt))
            
                    If lblnAns = False Then
            
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Text, lstrEventName)
            
                        '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
                        mblnValidateFlag = True
            
                        '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                        e.Cancel = True
            
                        mtypLotprestate = Nothing
            
                        Exit Sub
                    End If
            
                    '@ﾛｯﾄIDが同じ場合
                    If mtypWorkALDLotList.strLotID = mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLotID Then
            
                        '@選択ﾛｯﾄ
                        mlngCurrentLotRowNo = llngCnt
            
                        '@引き継ぎﾃﾞｰﾀ
                        ptypLotprestate = mtypLotprestate(llngCnt)
                    End If
                End If
            Next
            
            '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ成功時)
            mstrCarrier = txtCarrier.Text
            
            '@=======================
            '@ 画面表示処理
            '@=======================
            Call prvVsfLot_Disp()
                                                                                                   
            '@=======================
            '@ 装置情報取得
            '@=======================
            lblnAns = pubblnLotWplistALD_Sel(CPstrlot_wplistaldVer, _
                                            pstrfrmxxEN2Q0Div, _
                                            mtypWorkALDLotList.typAldWorkLotList(mlngCurrentLotRowNo).strLotID, _
                                            mtypWorkALDLotList.typAldWorkLotList(mlngCurrentLotRowNo).strOpID, _
                                            mtypWorkALDLotList.typAldWorkLotList(mlngCurrentLotRowNo).strStepID, _
                                            mtypLotWpList)
            '@結果判定
            If lblnAns = False Then
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Text, lstrEventName)
                            
                '@作業開始→ﾚｼﾋﾟ変更画面で使用(True:WP_ID=NULL)
                pblnWpIDNullFlag = True
                'NSYS グリッド使用可能
                VsfLot.Enabled = True
                Exit Sub
            Else
                '@作業開始→ﾚｼﾋﾟ変更画面で使用(True:WP_ID=NULL)
                pblnWpIDNullFlag = False
            End If
            
            
            '@=======================
            '@ 装置(WPID)一覧の設定
            '@=======================
            Call prvvsfWP_Disp()

            llngWpCount = 0                     '割り当て装置数のｸﾘｱ
            lstrCurrentWpID = vbNullString      '現在WP_IDのｸﾘｱ
            lblnWpIDMatch = False               '装置ﾘｽﾄ内一致ﾌﾗｸﾞを初期化
            pblnWpSelectFlag = False            '自端末の装置選択ﾌﾗｸﾞを初期化
                
            '@=======================
            '@【端末設定情報取得】ﾒｯｾｰｼﾞ送受信処理 "util.reftminfo"
            '@=======================
            lblnAns = pubblnUtilRefTmInfo_Sel(pstrSBID, _
                                                  CMstrutilreftminfoVer, _
                                                  pstrComputerName, _
                                                  ltypTmInfo) '

            '@通信結果判定
            If lblnAns = True Then
                    
                '@結果：正常の場合
                With ltypTmInfo
                        
                    '@端末情報が取得出来たか
                    If .strMcGroupID <> vbNullString Then
                            
                        '@取得したWPIDを変数に格納
                        llngWpCount = .lngWpListCount               '端末に割当られた装置数入手
                        lstrCurrentWpID = .strWpID                  '現設定WP入手
                    End If
                End With
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Text, lstrEventName)

                With vsfWp
                        
                    '@行ｶｳﾝﾀ初期化
                    llngRowCnt = 0
                    llngRowSetPosition = 0

                    '@装置ｸﾞﾘｯﾄ読み出し＆WPID比較
                    For llngCnt1 = 1 To .Rows.Count - 1
                            
                        lstrWpNameAtList = .GetData(llngCnt1, CMvsfWPColWpID)
                        llngRowCnt = llngRowCnt + 1

                        For llngCnt2 = 0 To llngWpCount - 1
                                
                            lstrWpNameByTerminal = ltypTmInfo.typWpList(llngCnt2).strDefaultWpID

                            '@装置ﾘｽﾄ内に，自端末のWPIDがあるか？
                            If StrComp(lstrWpNameByTerminal, lstrWpNameAtList, 1) = 0 Then
                                    
                                lblnWpIDMatch = True
                                llngRowSetPosition = llngRowCnt                             '行位置格納
                                    
                                '@あったらそのWPIDは，現在選択中のWPIDに一致しているか？
                                If StrComp(lstrCurrentWpID, lstrWpNameByTerminal, 1) = 0 Then
                                    pblnWpSelectFlag = True
                                End If
                            End If
                        Next llngCnt2

                        If pblnWpSelectFlag = True Then
                            Exit For
                        End If
                    Next llngCnt1
                End With
                    
                '@装置ﾘｽﾄの自動選択処理
                '@端末1つに対し複数装置が割り当てられている場合は，自動選択を実施しない。
                If llngWpCount = 1 Then
                        
                    '@装置ﾘｽﾄ内に自端末の装置があった場合，その行番号にフォーカスする。
                    If lblnWpIDMatch = True Then
                            
                        If llngRowSetPosition > 1 Then
                            vsfWp.TopRow = llngRowSetPosition - 1
                        End If
                            
                        vsfWp.Row = llngRowSetPosition          '自端末の装置を選択(vsfWp_AfterRowColChangeｲﾍﾞﾝﾄ発生)
                            
                        '@=======================
                        '@ 装置一覧初期ﾎﾞﾀﾝ設定
                        '@=======================
                        'Call pubVsfDisp(vsfWp, cmdWpUP, cmdWpDown)
                    End If
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Text, lstrEventName)
            End If
            
            '@=======================
            '@ ﾃﾞﾌｫﾙﾄ端末で無ければ色を変える
            '@=======================
            Call prvColorChang()

            '@装置が1件の場合
            With vsfWp
                If .Rows.Count = .Rows.Fixed + 1 Then
                    .Select(.Rows.Fixed, CMvsfWPColNo, .Rows.Fixed, .Cols.Count - 1)
                    .Row = .Rows.Fixed
                End If
            End With

            'NSYS グリッド活性化
            VsfLot.Enabled = True
            vsfWP.Enabled = True

            '@=======================
            '@ｱｲﾃﾑ有効設定
            '@=======================
            Call prvItemEnable_Check()
                
            '@=======================
            '@確定ﾎﾞﾀﾝ有効ﾁｪｯｸ
            '@=======================
            Call prvCmdRegistEnable_Check(txtCarrier)

            '@=======================
            '@ ｷｬﾘｱ無判断
            '@=======================
            If mblnACarrierMoQuFd = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM2CI>$$ロット[%1]の$$Aキャリア選択を実施してください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002C, lstrWarLotInfo, Replace(cmdACarrierMoQuFdSelect.Text, vbCrLf, ""))
                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
            End If

            '@ﾌｫｰｶｽの制御
            If vsfWp.Enabled = True Then
                '@装置ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(vsfWp, laryCaller)
            Else
                '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(cmdClose, laryCaller)
            End If
            
            '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            mblnValidateFlag = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "txtCarrier_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtUnloaderCarrier_Change
    '機　能：LoaderｷｬﾘｱID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub txtUnloaderCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtUnloaderCarrier.Change
        
        Try
                
                
            '@=======================
            '@確定ﾎﾞﾀﾝ有効ﾁｪｯｸ
            '@=======================
            Call prvCmdRegistEnable_Check(txtUnloaderCarrier)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "txtUnloaderCarrier_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtUnloaderCarrier_Validate
    '機　能：LoaderｷｬﾘｱID入力ﾁｪｯｸ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub txtUnloaderCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtUnloaderCarrier.Validating
        
        Dim lblnAns                 As Boolean              '汎用戻り値結果取得(True:正常,False:異常)
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypCarrCurstate        As CarrCurstate         'ｷｬﾘｱ状態確認要求構造体

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtUnloaderCarrier.Text) = vbNullString Then
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                Exit Sub
            End If
            
            '@LoaderｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtUnloaderCarrier.NowByte < txtUnloaderCarrier.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM07W>$$キャリアIDは6桁で入力してください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽを留める
                e.Cancel = True
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "txtUnloaderCarrier_Validate"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@***********************
            '@ ｷｬﾘｱ情報(要求)格納
            '@***********************
            With ltypCarrCurstate
                .strCarrierId = txtUnloaderCarrier.Text
                .strClassDivision = pstrfrmxxEN2Q0Div           '処理区分
                .strMsgVer = CMstrcarrcurstateVer               'MSGVER
                .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strCarrierTypeID = vsfWp.GetData(vsfWp.Row, CMvsfWpColAfterCarrierTypeId)
                .strLotID = vsfLot.GetData(vsfLot.Row, CMvsfLotColLotID)
                .strOpID = vsfLot.GetData(vsfLot.Row, CMvsfLotColOpID)
                .strStepID = vsfLot.GetData(vsfLot.Row, CMvsfLotColStepID)
                .strAltNumber = CMlngAltNum
            End With
            
            '@=======================
            '@ ｷｬﾘｱ状態取得
            '@=======================
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, True, vbNullString)
            
            '@取得結果確認
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽを留める
                e.Cancel = True
                Exit Sub
                
            End If
            
            '@=======================
            '@確定ﾎﾞﾀﾝ有効ﾁｪｯｸ
            '@=======================
            Call prvCmdRegistEnable_Check(txtUnloaderCarrier)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "txtUnloaderCarrier_Validate"  'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotCommnt_Change
    '機　能：ﾛｯﾄｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub txtLotCommnt_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotCommnt.Change

        Try

            '@=======================
            '@ ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtLotCommnt, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
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
    '機　能：ﾛｯﾄｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub txtLotCommnt_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLotCommnt.KeyUp

        Try

            '@=======================
            '@ ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtLotCommnt, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
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
    '機　能：ﾛｯﾄｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub txtLotCommnt_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtLotCommnt.MouseUp

        Try

            '@=======================
            '@ ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtLotCommnt, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "txtLotCommnt_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentUp_Click
    '機　能：ｺﾒﾝﾄﾃｷｽﾄ用上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
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

            '@ｺﾒﾝﾄが有効か
            If txtLotCommnt.Enabled = True Then
                
                '@=======================
                '@ ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
                '@=======================
                Call pubtxtCmdUp_Proc(txtLotCommnt, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)

            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0             '機能ID
                .strProcName = "cmdCommentUp_Click"             'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentDown_Click
    '機　能：ｺﾒﾝﾄﾃｷｽﾄ用下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
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
            
            '@ｺﾒﾝﾄが有効か
            If txtLotCommnt.Enabled = True Then
            
                '@=======================
                '@ ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
                '@=======================
                Call pubtxtCmdDown_Proc(txtLotCommnt, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0             '機能ID
                .strProcName = "cmdCommentDown_Click"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_Change
    '機　能：作業メモ
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change
        
        Dim llngNowByte As Integer  'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@=======================
            '@ 現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            '@=======================
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
                    
            '@=======================
            '@ ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
                          
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "txtWorkMemo_Change"         'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoUp_Click
    '機　能：作業メモの前頁切替
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
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
            '@ ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            '@=======================
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "cmdMemoUp_Click"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoDown_Click
    '機　能：作業メモの次頁切替
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
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
            '@ ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            '@=======================
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "cmdMemoDown_Click"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_KeyUp
    '機　能：作業ﾒﾓｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try
            
            '@=======================
            '@ ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "txtLotCommnt_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：作業ﾒﾓﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try

            '@=======================
            '@ ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "txtWorkMemo_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLot_AfterRowColChange
    '機　能：変更処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub vsfLot_AfterRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLot.AfterRowColChange

        Dim NewRow          As Integer      'NSYS 新行
        Dim OldRow          As Integer      'NSYS 旧行
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLot.Rows.Count <= vsfLot.Rows.Fixed Then
                Return
            End If
               
            With vsfLot
                NewRow = e.NewRange.r1
                OldRow = e.OldRange.r1
                
                '@ﾀｲﾄﾙではない場合
                If NewRow >= .Rows.Fixed And OldRow <> NewRow Then
                
                    '@作業条件表示
                    txtOpeCond.Text = .GetData(NewRow, CMvsfLotColWorkCondition)
                    txtLotCommnt.Text = .GetData(NewRow, CMvsfLotColComments)
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "vsfLot_AfterRowColChange"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfWp_AfterRowColChange
    '機　能：装置変更処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub vsfWP_AfterRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfWP.AfterRowColChange

        Dim lstrErrMessage  As String       '装置の処理間隔ﾜｰﾆﾝｸﾞ時間をﾁｪｯｸした場合のｴﾗｰﾒｯｾｰｼﾞ格納
        Dim strEqchk_Result As String       '装置の処理間隔ﾜｰﾆﾝｸﾞ時間をﾁｪｯｸした場合の結果格納
        Dim lstrWP_ID       As String       'WP_ID
        Dim llngMsgAns      As Integer      'ﾒｯｾｰｼﾞﾎﾞｯｸｽの戻り値格納
        Dim NewRow          As Integer      'NSYS 新行
        Dim OldRow          As Integer      'NSYS 旧行
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfWP.Rows.Count <= vsfWP.Rows.Fixed Then
                Return
            End If
               
            With vsfWp
                NewRow = e.NewRange.r1
                OldRow = e.OldRange.r1
                
                '@ﾀｲﾄﾙではない場合
                If NewRow >= .Rows.Fixed And OldRow <> NewRow Then
                       
                    '@ｱｸｼｮﾝ予約表示ﾌﾗｸﾞの判定
                    'If vsfWp.Cell(flexcpText, NewRow, CMvsfWpColActionFlag) = CMstrActionFlgNever Then
                        
                        '@=======================
                        '@ ｱｸｼｮﾝ予約ﾘｽﾄ取得
                        '@=======================
                        Call prvAllLotAction_Get(vsfWp.GetData(NewRow, CMvsfWPColWpID))
                        
                        '@=======================
                        '@ ｱｸｼｮﾝ予約ﾘｽﾄの表示
                        '@=======================
                        Call prvAllLotActionDisp_Proc(vsfWp.GetData(NewRow, CMvsfWPColWpID))
                        
                        If cmdActionDisp.Enabled = True Then
                            '@ｱｸｼｮﾝ予約表示ﾌﾗｸﾞに表示済を設定する
                            vsfWp.SetData(NewRow, CMvsfWpColActionFlag, CPstrFlagOn)
                        End If
                    'End If
                       
                    '@=======================
                    '@ 装置処理経過時間ﾁｪｯｸ
                    '@=======================
                    lstrWP_ID = vsfWp.GetData(NewRow, CMvsfWPColWpID)
                    Call pubEqWarning_Chk(CMstreqchkintervalVer, lstrWP_ID, lstrErrMessage, strEqchk_Result)
                    
                    '@装置処理経過時間ﾁｪｯｸの結果ｵｰﾊﾞありの場合ﾜｰﾆﾝｸﾞﾒｯｾｰｼﾞ表示
                    If strEqchk_Result = CPstrchkResultNG Then
                        
                        '@ﾒｯｾｰｼﾞ表示
                        llngMsgAns = publngMsgBox(lstrErrMessage, vbExclamation, Me.Text, True, 16, False)
                    End If
                       
                    '@=======================
                    '@ｱｲﾃﾑ有効設定
                    '@=======================
                    Call prvItemEnable_Check()
                                                           
                End If

            End With

            '@=======================
            '@確定ﾎﾞﾀﾝ有効ﾁｪｯｸ
            '@=======================
            Call prvCmdRegistEnable_Check()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "vsfWp_AfterRowColChange"    'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfWp_BeforeRowColChange
    '機　能：装置ﾘｽﾄ行列変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub vsfWP_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfWP.BeforeRowColChange
        
        Dim llngAns     As Integer  '戻り値格納用
        Dim NewRow      As Integer  'NSYS 新行
        Dim OldRow      As Integer  'NSYS 旧行
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfWP.Rows.Count <= vsfWP.Rows.Fixed Then
                Return
            End If
            
            With vsfWp
                NewRow = e.NewRange.r1
                OldRow = e.OldRange.r1
                
                '@ﾀｲﾄﾙではない場合
                If NewRow >= .Rows.Fixed And OldRow <> NewRow And OldRow <> 0 Then
                    
                    '@使用部材ﾘｽﾄ構造体にﾃﾞｰﾀが存在する場合
                    If ptypChkMaterial.lngMaterialTypeCnt <> 0 Then
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM8EW>$$装置を変更した場合、部材の選択情報をクリアします。 $よろしいですか？"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008E)
                        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                        
                        '@要求確認
                        If llngAns = vbNo Then          '内容破棄しない
                            '@処理しない
                            e.Cancel = True
                            Exit Sub
                        End If
                        
                        '@使用部材選択済みﾌﾗｸﾞの初期化
                        pblnMaterialSelectFlag = False
                        
                        '@使用部材ﾘｽﾄ構造体をｸﾘｱ
                        ptypChkMaterial.typMaterialTypeList = Nothing
                        ptypChkMaterial.lngMaterialTypeCnt = 0              '部材種別IDｶｳﾝﾄ
                        ptypChkMaterial.strClassDivision = vbNullString     '処理区分
                        ptypChkMaterial.strLotID = vbNullString             'ﾛｯﾄID
                        ptypChkMaterial.strMaterialID = vbNullString        '部材ID
                        ptypChkMaterial.strMaterialLotID = vbNullString     '部材管理ID
                        ptypChkMaterial.strMaterialTypeID = vbNullString    '部材種別ID
                        ptypChkMaterial.strMsgVer = vbNullString            'Msgﾊﾞｰｼﾞｮﾝ
                        ptypChkMaterial.strSbID = vbNullString              'ｼｽﾃﾑﾌﾞﾛｯｸ
                        ptypChkMaterial.strWpID = vbNullString              '装置ID
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "vsfWp_BeforeRowColChange"   'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRecipeChange_Click
    '機　能：ﾚｼﾋﾟ設定変更
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmdRecipeChange_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRecipeChange.Click
        
        Dim lstrOldKey              As String               '旧：大工程ID+小工程ID+装置ID
        Dim lstrWorkMemo            As String               '作業ﾒﾓ退避用変数

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
            
            '@***********************
            '@ 引継ぎﾃﾞｰﾀを格納
            '@***********************
            ptypLotprestate = mtypLotprestate(mlngCurrentLotRowNo)
            pstrCarrierID = txtCarrier.Text
            With vsfWp
                pstrWPID = .GetData(.Row, CMvsfWPColWpID)
                pstrWPName = .GetData(.Row, CMvsfWPColWpName)
                pstrDefaultStep = CMstrDefault
                pstrEqType = .GetData(.Row, CMvsfWPColEqType)
                pstrLotRecipeFlag = .GetData(.Row, CMvsfWPColLotRecipeFlag)
                pstrLoaderUnloaderFlag = .GetData(.Row, CMvsfWPColLoaderUnloaderFlag)
            End With
                
            '@起動ﾌﾗｸﾞ(親から起動)
            pblnfrmxxCM0050Kbn = True
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ ﾚｼﾋﾟ設定変更画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0050.Instance = New frmxxCM0050()
            
            '@ﾚｼﾋﾟ詳細画面名称設定
            frmxxCM0050.Instance.Text = CPstrSubDispTitleRepSet
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                
                '@特殊処理：起動失敗の場合には,明示的にﾌﾗｸﾞを立てる
                pblnfrmxxCM0050CVFlag = True
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM0050.Instance = Nothing
                
                '@ﾌﾗｸﾞを戻す
                pblnfrmxxCM0050CVFlag = False
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ ﾚｼﾋﾟ設定変更画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0050.Instance.ShowDialog(Me)
            frmxxCM0050.Instance = Nothing
            
            '@起動ﾌﾗｸﾞの初期化
            pblnfrmxxCM0050Kbn = False
            
            '@ｻﾌﾞ画面で確定の場合
            If pblnSubDecision = True Then
                
                With vsfWp
                    
                    '@ｶﾚﾝﾄ行の保持
                    Call pubVsfBeforeSort(vsfWp, CMvsfWPColWpID)
                    
                    '@ｶﾚﾝﾄｷｰ値の保持
                    lstrOldKey = pubstrVsfTag_Get(vsfWp, 2)
                End With
                
                '@作業ﾒﾓ退避
                lstrWorkMemo = txtWorkMemo.Text
                
                '@=======================
                '@ ｷｬﾘｱID変更処理
                '@ ※ﾛｯﾄ最終更新日時を取得する為
                '@=======================
                Call txtCarrier_Change(txtCarrier, EventArgs.Empty)
                
                txtCarrier.Text = pstrCarrierID
                
                '@=======================
                '@ ｷｬﾘｱIDﾃｷｽﾄValidate処理
                '@=======================
                mblnCarrierValidateCallFlag = True
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                mblnCarrierValidateCallFlag = False
                
                With vsfWp
                    
                    '@最新の装置がある場合
                    If .Rows.Fixed < .Rows.Count Then
                        
                        '@=======================
                        '@ ｶﾚﾝﾄｷｰ値の設定
                        '@=======================
                        Call pubblnVsfTag_Set(vsfWp, 2, lstrOldKey)
                        
                        '@=======================
                        '@ ｶﾚﾝﾄ行の設定
                        '@=======================
                        'Call pubVsfAfterSort(vsfWp, CMvsfWPColWpID, cmdWpUP, cmdWpDown)
                        
                        '@作業開始→ﾚｼﾋﾟ変更画面で使用(True:WP_ID=NULL)
                        pblnWpIDNullFlag = False
                        
                        '@WP_IDが1件の場合
                        If .Rows.Count = 2 Then
                            '@1行目をｾﾚｸﾄ
                            .Select(1, CMvsfWPColWpID)
                        End If
                    Else
                        '@作業開始→ﾚｼﾋﾟ変更画面で使用(True:WP_ID=NULL)
                        pblnWpIDNullFlag = True
                    End If
                End With
                
                '@作業ﾒﾓ
                txtWorkMemo.Text = lstrWorkMemo
            End If
            
            '@確定ﾎﾞﾀﾝがﾛｯｸ解除の場合
            If cmdRegist.Enabled = True Then
                
                '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdRegist)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "cmdRecipeChange_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdActionDisp_Click
    '機　能：ｱｸｼｮﾝ予約表示
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmdActionDisp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdActionDisp.Click
        
        Dim llngRow                 As Integer              '行番号

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
            
            '@装置一覧の選択行を取得
            llngRow = vsfWp.Row
            
            '@★ 装置一覧の選択行により処理分岐 ★
            Select Case llngRow
                
                '@〓 -1：ﾃﾞｰﾀ行以外 〓
                Case Is <= -1
                    
                    '@選択されていない場合
                    Exit Sub
                
                '@〓 0：ﾀｲﾄﾙ行 〓
                Case 0 To vsfWp.Rows.Fixed - 1
                    
                    '@見出し行が選択されている場合
                    Exit Sub
            
            End Select
            
            '@=======================
            '@ ｱｸｼｮﾝ予約ﾘｽﾄの表示
            '@=======================
            Call prvAllLotActionDisp_Proc(vsfWp.GetData(llngRow, CMvsfWPColWpID))
                        
            If cmdActionDisp.Enabled = True Then
                '@ｱｸｼｮﾝ予約表示ﾌﾗｸﾞに表示済を設定する
                vsfWp.SetData(llngRow, CMvsfWpColActionFlag, CPstrFlagOn)
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "cmdActionDisp_Click"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommntInput_Click
    '機　能：ﾛｯﾄｺﾒﾝﾄ登録画面表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmdCommntInput_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommntInput.Click
        
        Dim lstrTitle       As String       'ﾀｲﾄﾙ

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

            '@***********************
            '@ 引継ぎﾃﾞｰﾀを格納
            '@ ※ptypLotprestateに格納してfrmxxCM0030を呼ぶ
            '@***********************
            Dim ltypLotprestateTmp As Lotprestate
            ltypLotprestateTmp = mtypLotprestate(mlngCurrentLotRowNo)
            ltypLotprestateTmp.strComments = txtLotCommnt.Text
            mtypLotprestate(mlngCurrentLotRowNo) = ltypLotprestateTmp
            ptypLotprestate = mtypLotprestate(mlngCurrentLotRowNo)
            pstrCarrierID = txtCarrier.Text
                    
            '@親ﾌｫｰﾑからの呼び出しを識別するためにTrueにする
            pblnfrmxxCM0030Kbn = True
            
            '@起動ﾌﾗｸﾞを設定
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
                
            '@ﾌｫｰﾑの呼出識別から判別
            If pblnFormLoad = True Then
                    
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ ﾛｯﾄｺﾒﾝﾄ画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0030.Instance.ShowDialog(Me)
                frmxxCM0030.Instance = Nothing
                    
                '@引き継ぎﾃﾞｰﾀ受信
                txtLotCommnt.Text = ptypLotprestate.strComments
                vsfLot.SetData(vsfLot.Row, CMvsfLotColComments, ptypLotprestate.strComments)
                vsfLot.SetData(vsfLot.Row, CMvsfLotColEditTime, ptypLotprestate.strLotLastUpdate)
            Else
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM0030.Instance = Nothing
                
                '@起動ﾌﾗｸﾞを戻す
                pblnFormLoad = True
                    
                Exit Sub
            End If
                
            '@次項目にﾌｫｰｶｽｾｯﾄ
            SendKeys.SendWait(CPstrSendKeysTab)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "cmdCommntInput_Click"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSelectMaterial_Click
    '機　能：使用部材選択
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmdSelectMaterial_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSelectMaterial.Click

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
                
            '@引継ぎﾃﾞｰﾀ格納
            pstrWPID = vsfWp.GetData(vsfWp.Row, CMvsfWPColWpID)        '装置ID

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 使用部材一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00Y0.Instance = New frmxxCM00Y0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00Y0.Instance = Nothing
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 使用部材一覧画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00Y0.Instance.ShowDialog(Me)
            frmxxCM00Y0.Instance = Nothing
            
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrWPID = vbNullString                '装置ID
            
            '@確定ﾎﾞﾀﾝが有効な場合
            If cmdRegist.Enabled = True Then
                
                '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdRegist)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "cmdSelectMaterial_Click"    'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdACarrierMoQuFdSelect
    '機　能：Aｷｬﾘｱ(MO/QU/FD)選択
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmdACarrierMoQuFdSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdACarrierMoQuFdSelect.Click

        Dim ltypACarrierGroup   As ACarrierGroup
        Dim lstrCarrier         As String

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ALDﾊﾞｯﾁIDがNULL時は実行しない
            If mtypACarrierGroup.strAldBatchId = vbNullString Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱ退避
            lstrCarrier = txtCarrier.Text
            
            '@ﾊﾟﾌﾞﾘｯｸ変数に引継
            ptypACarrierGroup = mtypACarrierGroup
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ Aｷｬﾘｱ選択画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00E2.Instance = New frmxxCM00E2()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00E2.Instance = Nothing
                    
                '@引継情報を初期化
                ptypACarrierGroup = ltypACarrierGroup
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ Aｷｬﾘｱ選択画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00E2.Instance.ShowDialog(Me)
            frmxxCM00E2.Instance = Nothing
            
            '@=======================
            '@ 各種初期化処理(画面内ｺﾝﾄﾛｰﾙ、変数等)
            '@=======================
            Call prvfrmxxEN02Q0_Init()
            
            '@ｷｬﾘｱ再入力(次工程ｵﾌﾟｼｮﾅﾙﾁｪｯｸ付きの復元処理はValidateにあります)
            txtCarrier.Text = lstrCarrier
            mblnCarrierValidateCallFlag = True
            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(True))
            mblnCarrierValidateCallFlag = False
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "cmdACarrierMoQuFdSelect"    'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdACarrierSelect_Click
    '機　能：Aｷｬﾘｱ一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmdACarrierSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdACarrierSelect.Click

        Dim ltypACarrierGroup   As ACarrierGroup


        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾃｰﾌﾟﾊﾞｯﾁIDがNULL時は実行しない
            If mtypACarrierGroup.strTapeBatchId = vbNullString Then
                Exit Sub
            End If
            
            '@ﾊﾟﾌﾞﾘｯｸ変数に引継
            ptypACarrierGroup = mtypACarrierGroup
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ Aｷｬﾘｱ選択画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00E1.Instance = New frmxxCM00E1()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00E1.Instance = Nothing
                    
                '@引継情報を初期化
                ptypACarrierGroup = ltypACarrierGroup
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ Aｷｬﾘｱ選択画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00E1.Instance.ShowDialog(Me)
            frmxxCM00E1.Instance = Nothing
            
            '@ﾒﾝﾊﾞｰ変数に引継
            mtypACarrierGroup = ptypACarrierGroup
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ Aｷｬﾘｱ表示
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            Call prvVsfLotAcarrier_Disp()
            
            '@=======================
            '@確定ﾎﾞﾀﾝ有効ﾁｪｯｸ
            '@=======================
            Call prvCmdRegistEnable_Check()
            
            '@引継情報を初期化
            ptypACarrierGroup = ltypACarrierGroup
            
            '@ﾌｫｰｶｽｾｯﾄ
            'Call pubSetFocus(cmdACarrierSelect)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "cmdACarrierSelect_Click"    'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierSelect_Click
    '機　能：空きｷｬﾘｱ一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
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
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@移載先ｷｬﾘｱID保存
            pstrCarrierID = txtUnloaderCarrier.Text
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            With vsfWp
                
                '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱﾀｲﾌﾟIDがNULL以外の場合
                If .GetData(.Row, CMvsfWpColAfterCarrierTypeId) <> vbNullString Then
                    
                    '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱﾀｲﾌﾟID引渡し
                    pstrCarrierTypeID = .GetData(.Row, CMvsfWpColAfterCarrierTypeId)
                End If
                
                '@洗浄条件がNULL以外の場合
                If .GetData(.Row, CMvsfWPColCleanCondition) <> vbNullString Then
                    
                    '@洗浄条件引渡し
                    pstrCleanCondition = .GetData(.Row, CMvsfWPColCleanCondition)
                End If
            End With
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 空きｷｬﾘｱ一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00E0.Instance = New frmxxCM00E0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00E0.Instance = Nothing
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 空きｷｬﾘｱ一覧画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00E0.Instance.ShowDialog(Me)
            frmxxCM00E0.Instance = Nothing
                 
            '@空きｷｬﾘｱが選択されている場合
            If pstrCarrierID <> vbNullString Then
                
                '@ｷｬﾘｱIDをｾｯﾄ
                txtUnloaderCarrier.Text = pstrCarrierID
            End If
            
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｷｬﾘｱID
            
            '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtUnloaderCarrier)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "cmdCarrierSelect_Click"     'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定(作業開始)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lstrEventName As String
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@=======================
            '@ 画面入力ﾁｪｯｸ処理
            '@=======================
            If prvblnData_Check = False Then
                Exit Sub
            End If
            
            '@=======================
            '@装置使用部材有効時
            '@=======================
            If cmdSelectMaterial.Visible = True And cmdSelectMaterial.Enabled = True Then
                '@装置使用部材確定
                If prvblnMaterial_Regist = False Then
                    Exit Sub
                End If
            Else
                '@作業者ｺｰﾄﾞ入力
                frmxxCM0010.Instance.ShowDialog(Me)
                frmxxCM0010.Instance = Nothing
            
                '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
                If pblnCancel = True Then
                    Exit Sub
                End If
            End If
            
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmdRegist_Click"
            Call pubResponseStart(Me.Text, lstrEventName)
            
            '@=======================
            '@処理単位がﾛｯﾄの場合
            '@=======================
            If mtypWorkALDLotList.strProcessUnit = CPstrProcessUnit_Lot Then
                '@起動区分
                Select Case pstrfrmxxEN2Q0Div
                    Case CPstrCD10
                        '@作業開始
                        Call prvWorkStart()
                    Case CPstrCD11
                        '@処理開始
                        Call prvProcStart()
                    Case CPstrCD12
                        '@処理終了
                        Call prvProcEnd()
                    Case CPstrCD13
                        '@作業終了
                        Call prvWorkEnd()
                    Case Else
                End Select
            
            '@=======================
            '@処理単位がﾊﾞｯﾁの場合
            '@=======================
            ElseIf mtypWorkALDLotList.strProcessUnit = CPstrProcessUnit_Batch Then
            
                '@起動区分
                Select Case pstrfrmxxEN2Q0Div
                    Case CPstrCD10
                        '@ﾊﾞｯﾁ作業開始
                        Call prvBatchWorkStart()
                    Case CPstrCD11
                        '@ﾊﾞｯﾁ処理開始
                        Call prvBatchProcStart()
                    Case CPstrCD12
                        '@ﾊﾞｯﾁ処理終了
                        Call prvBatchProcEnd()
                    Case CPstrCD13
                        '@ﾊﾞｯﾁ作業終了
                        Call prvBatchWorkEnd()
                    Case Else
                End Select
            
                '@ﾒﾝﾊﾞｰ変数に引継
                mtypACarrierGroup = ptypACarrierGroup
                
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Text, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "cmdRegist_Click"
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
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim ltypCommonInfo      As CommonInfo

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@引継ぎ情報のｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                
                '@装置別ﾛｯﾄ一覧から引き継いで起動されたか
                If pblnfrmxxEN0151Kbn = True Then
                    
                    '@=======================
                    '@ 装置別ﾛｯﾄ一覧を起動する
                    '@=======================
                    Call pubMenuSelect_Proc(CPstrKeyEN0151)
                    Exit Sub
                
                '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧から引き継いで起動されたか
                ElseIf pblnfrmxxEN00J0Kbn = True Then
                    
                    '@=======================
                    '@ 装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧を起動する
                    '@=======================
                    Call pubMenuSelect_Proc(CPstrKeyEN00J0)
                    Exit Sub
                    
                '@工程別ﾛｯﾄ一覧から引き継いで起動された場合
                ElseIf pblnfrmxxEN0200Kbn = True Then
                    
                    '@=======================
                    '@ 工程別ﾛｯﾄ一覧を起動する
                    '@=======================
                    Call pubMenuSelect_Proc(CPstrKeyEN0200)
                    Exit Sub
                    
                End If
            
            End If
            
            '@=======================
            '@ 終了関数を実行する
            '@=======================
            Call publngEnd_Proc(CPstrKeyEN02Q0, ltypCommonInfo)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0            '機能ID
                .strProcName = "cmdClose_Click"         'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTreatChip_Click
    '機　能：ﾁｯﾌﾟ状態変更ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 15:20:11 T.Kitagawa
    '更新日：2008/05/07 (Wed) 18:28:57 N.Kojima
    '備　考：
    Private Sub cmdTreatChip_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTreatChip.Click

        Dim lstrTitle           As String           'ﾁｯﾌﾟ状態変更登録画面ﾀｲﾄﾙ用
        Dim lstrFunctionKey     As String           'ﾒﾆｭｰKey格納
        Dim ltypOldCommonInfo   As CommonInfo       '機能間受け渡し情報格納用構造体
        Dim ltypWorkEndInfo     As WorkEndInfo      '作業終了<=>WF状態変更/ﾁｯﾌﾟ状態変更/特殊流動 引継ぎ構造体
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@★ 起動引数により処理分岐 ★
            Select Case pstrTerminalMode
            
                '@〓 M:工程管理 〓
                Case CPstrManufactureStatus
                    
                    '@機能IDに"EN0190:ﾁｯﾌﾟ状態変更登録"を格納
                    lstrFunctionKey = CPstrKeyEN0190
                
                '@〓 その他 〓
                Case Else
                    
                    '@機能IDに"EN01Q0:ﾁｯﾌﾟ状態変更登録(上書き)"を格納
                    lstrFunctionKey = CPstrKeyEN01Q0

            End Select
            
            
            '@機能間受け渡し情報格納用構造体の退避
            ltypOldCommonInfo = ptypCommonInfo
            
            '@引継ぎ情報格納①
            With ptypCommonInfo
            
                '@ﾛｯﾄ状態が「後処理」か
                'If vsfLot.Cell(flexcpText, vsfLot.Row, CMvsfLotColNowSt) = CPstrAfterProgressSt Then
                
                    
                .strCarrierId = vsfLot.GetData(vsfLot.Row, CMvsfLotColCarrierID)
                'End If
                
                .strDivision = vbNullString         '起動区分：NULL
                .strLotID = vbNullString            'ﾛｯﾄID：NULL
                .strOpID = vbNullString             '大工程：NULL
                .strStepID = vbNullString           '小工程：NULL
                .strWpID = vbNullString             '装置ID：NULL
                .strWpName = vbNullString           '装置名：NULL
            End With
            
            
            '@作業終了<=>WF状態変更/ﾁｯﾌﾟ状態変更/特殊流動 引継ぎ構造体の初期化
            ptypWorkEndInfo = ltypWorkEndInfo
            
            '@引継ぎ情報格納②
            With ptypWorkEndInfo
            
                '@ﾛｯﾄ状態が「後処理」か
                'If lblStatus.Caption = CPstrAfterProgressSt Then
                '
                '    '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱを格納
                '    .strCarrierID = txtCarrier.Text
                'Else
                '    '@ﾛｰﾀﾞｰｷｬﾘｱを格納
                '    .strCarrierID = mstrRetainCarrier
                'End If
                
                .strCarrierId = vsfLot.GetData(vsfLot.Row, CMvsfLotColCarrierID)
                .strLotID = vsfLot.GetData(vsfLot.Row, CMvsfLotColLotID)
                .strfrmxxKbn = lstrFunctionKey          '子画面の機能ID
            End With
            
            '@起動ﾌﾗｸﾞに"False:起動処理未完"をｾｯﾄ
            pblnFormLoad = False
            
            '@子画面起動ﾌﾗｸﾞに"True:子画面として起動"をｾｯﾄ
            pblnfrmxxCM0080Kbn = True
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　ﾁｯﾌﾟ状態変更登録画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0080.Instance = New frmxxCM0080()
                    
            '@起動ﾌﾗｸﾞが"False:起動処理未完"か
            If pblnFormLoad = True Then
                '@起動処理結果：正常の場合
                
                '@=======================
                '@　機能関連情報取得処理
                '@=======================
                Call pubMenuItemCorrelation_Set(lstrFunctionKey, lstrTitle)
            
                '@ﾁｯﾌﾟ状態変更登録画面のﾌｫｰﾑ名称を設定
                frmxxCM0080.Instance.Text = lstrTitle
            
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　ﾁｯﾌﾟ状態変更登録画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0080.Instance.ShowDialog(Me)
                frmxxCM0080.Instance = Nothing
            
                '@引継ぎ情報構造体の復元
                ptypCommonInfo = ltypOldCommonInfo

                '@子画面起動ﾌﾗｸﾞの初期化
                pblnfrmxxCM0080Kbn = False
                
            Else
                '@起動処理結果：異常の場合
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM0080.Instance = Nothing
                
                '@引継ぎ情報構造体の復元
                ptypCommonInfo = ltypOldCommonInfo
                '@子画面起動ﾌﾗｸﾞの初期化
                pblnfrmxxCM0080Kbn = False
                
                Exit Sub
            End If

            '@ﾁｯﾌﾟ状態変更登録から戻ってきたときに、ｽﾃｰﾀｽﾊﾞｰにﾒｯｾｰｼﾞを表示する
            Call pubVsfInfo_Disp(pstrStatusberMSG)
                

            With ptypWorkEndInfo
            
                '@★ 作業ﾌﾗｸﾞ(0:処理なし/1:ﾁｯﾌﾟ/2:WF移載/3:ﾛｯﾄ終了)により処理分岐 ★
                Select Case .strWorkKbn
                    
                    '@〓 1:ﾁｯﾌﾟ or 2:移載 〓
                    Case CMstrLotEventChip, CMstrLotEventMove
                        
                        '@=======================
                        '@ 作業終了画面の最新取得＆復元処理
                        '@=======================
                        Call prvRefresh_Disp()
                        
                        If cmdTreatChip.Enabled = True Then
                            Call pubSetFocus(cmdTreatChip)
                        End If
                                    
                    
                    '@〓 3:ﾛｯﾄｱｳﾄ 〓
                    Case CMstrLotEventLotOut

                        txtCarrier.Text = vbNullString
                        Exit Sub
                        
                    '@〓 その他 〓
                    Case Else
                        
                        '@処理なし

                End Select
            End With

            '@=======================
            '@ 作業終了画面の最新取得＆復元処理
            '@=======================
            Call prvRefresh_Disp()

            RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
            SendKeys.SendWait(CPstrSendKeysTab)
            AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTreatChip_Click"
                .strErrMessage = ""
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTreatWF_Click
    '機　能：WF状態変更ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 10:11:11 T.Oide
    '更新日：2008/05/07 (Wed) 18:08:11 N.Kojima
    '備　考：
    Private Sub cmdTreatWF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTreatWF.Click

        Dim lstrTitle           As String           'WF状態変更登録画面ﾀｲﾄﾙ用
        Dim ltypOldCommonInfo   As CommonInfo       '機能間受け渡し情報格納用構造体
        Dim ltypWorkEndInfo     As WorkEndInfo      '作業終了<=>WF状態変更/ﾁｯﾌﾟ状態変更/特殊流動 引継ぎ構造体
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            
            '@機能間受け渡し情報格納用構造体を退避構造体に格納
            ltypOldCommonInfo = ptypCommonInfo
            
            '@引継ぎ情報格納①
            With ptypCommonInfo
            
                '@ﾛｯﾄ状態が「後処理」か
                'If lblStatus.Caption = CPstrAfterProgressSt Then
                '
                '    '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱを格納
                '    .strCarrierID = txtCarrier.Text
                'Else
                '    '@ﾛｰﾀﾞｰｷｬﾘｱを格納
                '    .strCarrierID = mstrRetainCarrier
                'End If
                
                .strCarrierId = vsfLot.GetData(vsfLot.Row, CMvsfLotColCarrierID)
                
                .strDivision = vbNullString         '起動区分：NULL
                .strLotID = vbNullString            'ﾛｯﾄID：NULL
                .strOpID = vbNullString             '大工程：NULL
                .strStepID = vbNullString           '小工程：NULL
                .strWpID = vbNullString             '装置ID：NULL
                .strWpName = vbNullString           '装置名：NULL
            End With


            '@作業終了<=>WF状態変更/ﾁｯﾌﾟ状態変更/特殊流動 引継ぎ構造体の初期化
            ptypWorkEndInfo = ltypWorkEndInfo
            
            '@引継ぎ情報格納②
            With ptypWorkEndInfo
            
                '@ﾛｯﾄ状態が「後処理」か
                'If lblStatus.Caption = CPstrAfterProgressSt Then
                '
                '    '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱを格納
                '    .strCarrierID = txtCarrier.Text
                'Else
                '    '@ﾛｰﾀﾞｰｷｬﾘｱを格納
                '    .strCarrierID = mstrRetainCarrier
                'End If
                
                .strCarrierId = vsfLot.GetData(vsfLot.Row, CMvsfLotColCarrierID)
                .strLotID = vsfLot.GetData(vsfLot.Row, CMvsfLotColLotID)
                .strfrmxxKbn = CPstrKeyEN0180           '子画面の機能ID
            End With
            
            '@起動ﾌﾗｸﾞに"False:起動処理未完"をｾｯﾄ
            pblnFormLoad = False
            
            '@子画面起動ﾌﾗｸﾞに"True:子画面として起動"をｾｯﾄ
            pblnfrmxxCM0070Kbn = True

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　WF状態変更登録画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0070.Instance = New frmxxCM0070()
            
            '@=======================
            '@　機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0180, lstrTitle)
            
            '@WF状態変更登録画面のﾌｫｰﾑ名称を設定
            frmxxCM0070.Instance.Text = lstrTitle
            
            '@起動ﾌﾗｸﾞが"False:起動処理未完"か
            If pblnFormLoad = False Then
                '@起動処理結果：異常の場合
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM0070.Instance = Nothing
                
                '@引継ぎ情報構造体の復元
                ptypCommonInfo = ltypOldCommonInfo      '機能間受け渡し情報格納用構造体
                '@子画面起動ﾌﾗｸﾞの初期化
                pblnfrmxxCM0070Kbn = False
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　WF状態変更登録画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0070.Instance.ShowDialog(Me)
            frmxxCM0070.Instance = Nothing

            '@引継ぎ情報構造体の復元
            ptypCommonInfo = ltypOldCommonInfo          '機能間受け渡し情報格納用構造体
            '@子画面起動ﾌﾗｸﾞの初期化
            pblnfrmxxCM0070Kbn = False

            '@最終更新日を書き換える
            vsfLot.SetData(vsfLot.Row, CMvsfLotColEditTime, ptypLotprestate.strLotLastUpdate)
            

            With ptypWorkEndInfo
                
                '@★ 作業ﾌﾗｸﾞ(0:処理なし/1:ﾁｯﾌﾟ/2:WF移載/3:ﾛｯﾄ終了)により処理分岐 ★
                Select Case .strWorkKbn
                
                    '@〓 2:移載 〓
                    Case CMstrLotEventMove
                        
                        '@=======================
                        '@　作業終了画面の最新取得＆復元処理
                        '@=======================
                        Call prvRefresh_Disp()
                        
                        '@ﾁｯﾌﾟ状態変更ﾎﾞﾀﾝが有効か
                        If cmdTreatChip.Enabled = True Then
                            '@ﾁｯﾌﾟ状態変更ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdTreatChip)
                        End If

                        Exit Sub
                    
                    
                    '@〓 3:ﾛｯﾄｱｳﾄ 〓
                    Case CMstrLotEventLotOut

                        '@ｷｬﾘｱIDを初期化する(画面情報を初期化する)
                        txtCarrier.Text = vbNullString

                        Exit Sub
                    
                    
                    '@〓 4:WF廃棄 〓
                    Case CMstrLotEventWfScrap

                        '@特に制御なしだが、明示的に記述しておきます。
                    
                    
                    '@〓 その他 〓
                    Case Else

                        '@特に制御なしだが、明示的に記述しておきます。

                End Select
            End With
            
            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
            SendKeys.SendWait(CPstrSendKeysTab)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTreatWF_Click"
                .strErrMessage = ""
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTrouble_Click
    '機　能：異常処理票起案ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/12 (Thu) 16:33:14 S.Deguchi
    '更新日：2008/06/04 (Wed) 10:33:15 N.Kojima
    '備　考：
    Private Sub cmdTrouble_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTrouble.Click

        Dim lstrTitle               As String               'ﾀｲﾄﾙ
        Dim ltypExcpConnectList     As ExcpConnectList      '異常処理登録/表示引継ぎ構造体初期化用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@子画面起動ﾌﾗｸﾞに"True:子画面として起動"をｾｯﾄ
            pblnfrmxxCM00I0Kbn = True
            
            '@起動ﾌﾗｸﾞに"False:起動処理未完"をｾｯﾄ
            pblnFormLoad = False

            '@異常処理登録/表示引継ぎ構造体を初期化する
            ptypExcpConnectList = ltypExcpConnectList
            
            '@引継ぎ情報格納
            With ptypExcpConnectList.typLotList
            
                .lngBatLotListCnt = 1                                       'ﾛｯﾄ数(=1)
                .strBatchId = vbNullString                                  'ﾊﾞｯﾁID(=Null)
                .strWpID = vsfWp.GetData(vsfWp.Row, CMvsfWPColWpID)
                .strWpName = vsfWp.GetData(vsfWp.Row, CMvsfWPColWpName)
                .strRecipeId = vsfWp.GetData(vsfWp.Row, CMvsfWpColRecipe)
                
                '@領域を確保
                .typBatList = New List(Of BatList)
                Dim ltypBatListTmp As BatList
                
                '@領域へ情報をｾｯﾄする
                ltypBatListTmp.strLotID = vsfLot.GetData(vsfLot.Row, CMvsfLotColLotID)
                ltypBatListTmp.strFlowClass = vsfLot.GetData(vsfLot.Row, CMvsfLotColFlowClass)
                ltypBatListTmp.strWFQuantity = vsfLot.GetData(vsfLot.Row, CMvsfLotColWfNum)
                ltypBatListTmp.strOpID = vsfLot.GetData(vsfLot.Row, CMvsfLotColOpID)
                ltypBatListTmp.strStepID = vsfLot.GetData(vsfLot.Row, CMvsfLotColStepID)
                ltypBatListTmp.strPdId = vsfLot.GetData(vsfLot.Row, CMvsfLotColPdID)
                ltypBatListTmp.strSpecialFlag = vbNullString
                
                
                ltypBatListTmp.strStartTime = vbNullString       '処理開始日時
                
                
                
                ltypBatListTmp.strCurrentStatusName = vsfLot.GetData(vsfLot.Row, CMvsfLotColNowSt)
                ltypBatListTmp.strEngEmpName = vsfLot.GetData(vsfLot.Row, CMvsfLotColEngEmpName)
                ltypBatListTmp.strLimitTime = vsfLot.GetData(vsfLot.Row, CMvsfLotColLimitTime)
                ltypBatListTmp.strLotLastUpdate = vsfLot.GetData(vsfLot.Row, CMvsfLotColEditTime)
                ltypBatListTmp.strCarrierId = vsfLot.GetData(vsfLot.Row, CMvsfLotColCarrierID)

                .typBatList.Add(ltypBatListTmp)
                
                '@ﾛｯﾄ状態が「後処理」か
                'If lblStatus.Caption = CPstrAfterProgressSt Then
                '
                '    '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱを格納する
                '    .typBatList(1).strCarrierID = txtCarrier.Text
                'Else
                '    '@ﾛｰﾀﾞｰｷｬﾘｱを格納する
                '    .typBatList(1).strCarrierID = mstrRetainCarrier
                'End If
            End With

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　工程異常/不適合品処理票登録画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00I0.Instance = New frmxxCM00I0()
            
            '@=======================
            '@　機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00U0, lstrTitle)

            '@工程異常/不適合品処理票登録画面のﾌｫｰﾑ名称を設定
            frmxxCM00I0.Instance.Text = lstrTitle
            
            '@起動ﾌﾗｸﾞが"False:起動処理未完"か
            If pblnFormLoad = False Then
                '@起動処理結果：異常の場合
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00I0.Instance = Nothing
                
                '@異常処理登録/表示引継ぎ構造体を初期化する
                ptypExcpConnectList = ltypExcpConnectList
                '@子画面起動ﾌﾗｸﾞの初期化
                pblnfrmxxCM00I0Kbn = False

                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　工程異常/不適合品処理票登録画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00I0.Instance.ShowDialog(Me)
            frmxxCM00I0.Instance = Nothing
            
            '@異常処理登録/表示引継ぎ構造体を初期化する
            ptypExcpConnectList = ltypExcpConnectList
            '@子画面起動ﾌﾗｸﾞの初期化
            pblnfrmxxCM00I0Kbn = False
            
            '@=======================
            '@　作業終了画面の最新取得＆復元処理
            '@=======================
            Call prvRefresh_Disp()
            
            '@異常処理票起案ﾎﾞﾀﾝが有効か
            If cmdTrouble.Enabled = True Then
                '@異常処理票起案ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                Call pubSetFocus(cmdTrouble)
                AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
            End If
            
            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
            RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
            SendKeys.SendWait(CPstrSendKeysTab)
            AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdTrouble_Click"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCollectionInfo_Click
    '機　能：装置ﾃﾞｰﾀ登録/参照ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/18 (Wed) 14:47:40 T.Kitagawa
    '更新日：2008/05/07 (Wed) 17:13:29 N.Kojima
    '備　考：
    Private Sub cmdCollectionInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCollectionInfo.Click
        
        Dim lstrTitle               As String           '装置ﾃﾞｰﾀ登録/参照画面ﾀｲﾄﾙ格納用
        Dim lstrtxtWorkMemo         As String           '作業ﾒﾓ退避ｴﾘｱ
        Dim lintNextSendIndex       As Short            '送出Index
        Dim ltypOldCommonInfo       As CommonInfo       '機能間受け渡し情報格納用構造体
        Dim ltypLotprestate         As Lotprestate      'ﾛｯﾄ現在情報格納用構造体
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@引継ぎ情報構造体を退避する。※当Functionの処理後に値を戻す
            ltypOldCommonInfo = ptypCommonInfo          '機能間受け渡し情報格納用構造体
            ltypLotprestate = ptypLotprestate           'ﾛｯﾄ現在情報格納用構造体


            '@★ 選択されているｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
            Select Case True
            
                '@〓 送出あり 〓
                Case optLotNextSend0.Checked

                   lintNextSendIndex = CMlngOptLotNextSend0
                
                '@〓 送出なし 〓
                Case optLotNextSend1.Checked

                   lintNextSendIndex = CMlngOptLotNextSend1
                
                '@〓 その他(選択なし) 〓
                Case Else

                   lintNextSendIndex = 9
            End Select

            '@現在入力されている作業ﾒﾓを退避
            lstrtxtWorkMemo = txtWorkMemo.Text
            
            '@引継ぎ情報格納
            With ptypCommonInfo
                .strCarrierId = vsfLot.GetData(vsfLot.Row, CMvsfLotColCarrierID)
                .strLotID = vsfLot.GetData(vsfLot.Row, CMvsfLotColLotID)
                .strOpID = vsfLot.GetData(vsfLot.Row, CMvsfLotColOpID)
                .strStepID = vsfLot.GetData(vsfLot.Row, CMvsfLotColStepID)
                .strWpID = vsfWp.GetData(vsfWp.Row, CMvsfWPColWpID)
                .strWpName = vsfWp.GetData(vsfWp.Row, CMvsfWPColWpName)
            End With
            
            '@起動ﾌﾗｸﾞに"False:起動処理未完"をｾｯﾄ
            pblnFormLoad = False
            
            '@子画面起動ﾌﾗｸﾞに"True:子画面として起動"をｾｯﾄ
            pblnfrmxxCM00G0Kbn = True
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　装置ﾃﾞｰﾀ登録/参照画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00G0.Instance = New frmxxCM00G0()
                
            '@=======================
            '@　機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00T0, lstrTitle)

            '@装置ﾃﾞｰﾀ登録/参照画面のﾌｫｰﾑ名称を設定
            frmxxCM00G0.Instance.Text = lstrTitle
            
            '@起動ﾌﾗｸﾞが"False:起動処理未完"か
            If pblnFormLoad = False Then
                '@起動処理結果：異常の場合
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00G0.Instance = Nothing
                
                '@引継ぎ情報構造体の復元
                ptypCommonInfo = ltypOldCommonInfo      '機能間受け渡し情報格納用構造体
                '@子画面起動ﾌﾗｸﾞの初期化
                pblnfrmxxCM00G0Kbn = False
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　装置ﾃﾞｰﾀ登録/参照画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00G0.Instance.ShowDialog(Me)
            frmxxCM00G0.Instance = Nothing
            
            '@引継ぎ情報構造体の復元
            ptypCommonInfo = ltypOldCommonInfo          '機能間受け渡し情報格納用構造体
            '@子画面起動ﾌﾗｸﾞの初期化
            pblnfrmxxCM00G0Kbn = False
            
            '@最終更新日時が更新されているか
            If vsfLot.GetData(vsfLot.Row, CMvsfLotColEditTime) = ptypLotprestate.strLotLastUpdate Then
                
                '@ﾛｯﾄ現在情報格納構造体を復元する
                ptypLotprestate = ltypLotprestate
            Else
                '@更新されている場合
                
                '@=======================
                '@　作業終了画面の最新取得＆復元処理
                '@=======================
                Call prvRefresh_Disp()
                
                '@装置ﾃﾞｰﾀ登録/参照ﾎﾞﾀﾝが有効か
                If cmdCollectionInfo.Enabled = True Then
                    '@装置ﾃﾞｰﾀ登録/参照ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdCollectionInfo)
                End If
            End If
            
            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
            SendKeys.SendWait(CPstrSendKeysTab)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCollectionInfo_Click"
                .strErrMessage = ""
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWorkRecord_Click
    '機　能：作業記録入力ﾌｫｰﾑ表示
    '引　数：なし
    '戻り値：ない
    '作成日：2004/06/02 (Wed) 12:42:05 S.Deguchi
    '更新日：2004/06/02 (Wed) 12:42:05
    '備　考：構造体　項目でﾃﾞｰﾀを渡し表示する
    Private Sub cmdWorkRecord_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkRecord.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@現状機能なし
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkRecord_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLabelScan_Click
    '機　能：現品票ﾗﾍﾞﾙ読込ﾌｫｰﾑ表示
    '引　数：なし
    '戻り値：ない
    '作成日：2018/12/26 (Wed) 10:06:44 Y.Yoneyama
    '更新日：2018/12/26 (Wed) 10:06:44 Y.Yoneyama
    '備　考：
    Private Sub cmdLabelScan_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLabelScan.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱ引継変数初期化
            pstrCarrierID = vbNullString
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ Aｷｬﾘｱ選択画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM01D0.Instance = New frmxxCM01D0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM01D0.Instance = Nothing
                    
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ Aｷｬﾘｱ選択画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM01D0.Instance.ShowDialog(Me)
            frmxxCM01D0.Instance = Nothing
                
            If pstrCarrierID = vbNullString Then
                Exit Sub
            End If
                
            '@=======================
            '@ 各種初期化処理(画面内ｺﾝﾄﾛｰﾙ、変数等)
            '@=======================
            Call prvfrmxxEN02Q0_Init()
            
            '@ｷｬﾘｱ再入力(次工程ｵﾌﾟｼｮﾅﾙﾁｪｯｸ付きの復元処理はValidateにあります)
            txtCarrier.Text = pstrCarrierID
            mblnCarrierValidateCallFlag = True
            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(True))
            mblnCarrierValidateCallFlag = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkRecord_Click"
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
    '関数名：prvfrmxxEN02Q0_Init
    '機　能：各種初期化処理(画面内ｺﾝﾄﾛｰﾙ、変数等)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvfrmxxEN02Q0_Init()
        
        Dim ltypLotprestate     As New Lotprestate
        Dim ltypWorkALDLotList  As New WorkALDLotList
        Dim ltypLotWpList       As New ALDWpList
        Dim ltypChkMaterial     As New ChkMaterial
        Dim ltypACarrierGroup   As New ACarrierGroup


        Try

            '@Public変数の初期化
            ptypLotprestate = ltypLotprestate           '引継ぎ構造体
            pblnWpIDNullFlag = False                    '引継ぎﾌﾗｸﾞ初期化作業開始→ﾚｼﾋﾟ変更画面で使用(True:WP_ID=NULL)
            pblnMkEasyDivFlag = False                   '無機専用の簡易分割ﾌﾗｸﾞ
            pblnfrmxxEN02Q0Kbn = False                  '作業開始ﾌﾗｸﾞ
            ptypChkMaterial = ltypChkMaterial
            
            '@ﾒﾝﾊﾞｰ変数初期化
            mstrCarrier = vbNullString                  'ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功時のｷｬﾘｱID)
            mstrPdErrMsg = vbNullString                 '機種限定ｴﾗｰMsg格納用
            mstrLimitErrMsg = vbNullString              '部材期限ｴﾗｰMsg格納用
            mstrPdForcedAction = CPstrZero              '機種限定強制実行判定用
            mstrLimitForcedAction = CPstrZero           '部材期限強制実行判定用
            mlngCurrentLotRowNo = 0
            mstrLotLastUpdate = vbNullString            'ﾛｯﾄ最終更新日時

            mtypLotprestate = Nothing
            mtypLotAction = Nothing
            mtypWorkALDLotList = ltypWorkALDLotList
            mtypLotWpList = ltypLotWpList
            mtypACarrierGroup = ltypACarrierGroup
            
            '@=======================
            '@ 機能関連情報取得処理
            '@=======================
            'Call pubMenuItemCorrelation_Set(CPstrKeyEN02Q0, lstrFormTitle)
            
            '@ﾗﾍﾞﾙ
            lblProcessUnit.Text = vbNullString
            lblTapeBatchId.Text = vbNullString
            lblOvenBatchId.Text = vbNullString
            lblALDBatchId.Text = vbNullString
            
            
            '@作業ﾒﾓ初期化
            With txtWorkMemo
                .ChrMaxByte = CPlngLotCommentsMaxByte
                .Text = vbNullString
                '@=======================
                '@ 作業ﾒﾓﾊﾞｲﾄ数初期化
                '@=======================
                Call txtWorkMemo_Change(txtWorkMemo, EventArgs.Empty)
            End With
            
            '@作業条件設定
            With txtOpeCond
                .Text = vbNullString
                .BackColor = SystemColors.ControlLight
                .GotBackColor = SystemColors.ControlLight
                .Locked = True
            End With
            
            '@Aｷｬﾘｱ一覧
            With txtACarrierList
                .Text = vbNullString
                .BackColor = SystemColors.ControlLight
                .GotBackColor = SystemColors.ControlLight
                .Locked = True
            End With
                
            '@ﾛｯﾄｺﾒﾝﾄ設定
            With txtLotCommnt
                .ChrMaxByte = CPlngLotCommentsMaxByte
                .Text = vbNullString
                .BackColor = SystemColors.ControlLight
                .GotBackColor = SystemColors.ControlLight
                .Locked = True
            End With
            
            '@CarrierId
            With txtCarrier
                .Text = vbNullString
            End With
            
            '@UnloaderCarrierId
            With txtUnloaderCarrier
                .Text = vbNullString
                .Enabled = False
                .BackColor = SystemColors.ControlLight
            End With
                     
            '@Validateを実行しない
            cmdSelectMaterial.CausesValidation = False
            cmdActionDisp.CausesValidation = False
            cmdCommntInput.CausesValidation = False
            cmdRecipeChange.CausesValidation = False
            cmdCarrierSelect.CausesValidation = False
            cmdCollectionInfo.CausesValidation = False
            cmdTrouble.CausesValidation = False
            cmdTreatWF.CausesValidation = False
            cmdTreatChip.CausesValidation = False
            cmdWorkRecord.CausesValidation = False
            cmdLabelScan.CausesValidation = False
            
            '@=======================
            '@ ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvvsfLot_Init()
            
            '@=======================
            '@ 装置一覧ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvvsfWP_init()
            
            '@=======================
            '@ 表示項目設定
            '@=======================
            Call prvItemVisible_Check()
            
            '@=======================
            '@ｱｲﾃﾑ有効設定
            '@=======================
            Call prvItemEnable_Check()
            
            '@=======================
            '@ ｺﾝﾄﾛｰﾙの色の初期化
            '@=======================
            Call prvControlColor_Init()
            
            '@使用部材選択済みﾌﾗｸﾞの初期化
            pblnMaterialSelectFlag = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "prvfrmxxEN02Q0_Init"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfLot_Init
    '機　能：装置一覧ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvvsfLot_Init()

        Try
            
            With vsfLot

                .Redraw = False

                .Row = -1
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                'NSYS AutoSizeされ、かつリサイズ不可のため基本省略されない。AutoSize後の列幅をVB6に合わせると省略表示されるため Noneにする
                .Styles.Normal.Trimming = StringTrimming.None

                .Rows.DefaultSize = CMvsfLotHeight
                
                '@列数設定
                .Cols.Count = CMvsfLotCols
                '@行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .FocusRect = FocusRectEnum.None
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                  '中央表示
                lFixedStyle.ForeColor = Color.Yellow                                '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)   '背景色
                With .Font                                                          'ﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMvsfLotTFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .Rows(CMvsfLotTitleRow).Height = CMvsfLotHHeight                    '高さ
                lFixedStyle.Trimming = StringTrimming.None
                                
                '@列幅、ﾀｲﾄﾙ設定
                .SetData(CMvsfLotTitleRow, CMvsfLotColNo, CMvsfLotColTNo)
                .SetData(CMvsfLotTitleRow, CMvsfLotColKb, CMvsfLotColTKb)
                .SetData(CMvsfLotTitleRow, CMvsfLotColNowSt, CMvsfLotColTNowSt)
                .SetData(CMvsfLotTitleRow, CMvsfLotColLimitTime, CMvsfLotColTLimitTime)
                .SetData(CMvsfLotTitleRow, CMvsfLotColPdID, CMvsfLotColTPdID)
                .SetData(CMvsfLotTitleRow, CMvsfLotColPdVersion, CMvsfLotColTPdVersion)
                .SetData(CMvsfLotTitleRow, CMvsfLotColLotID, CMvsfLotColTLotID)
                .SetData(CMvsfLotTitleRow, CMvsfLotColWfNum, CMvsfLotColTWfNum)
                .SetData(CMvsfLotTitleRow, CMvsfLotColChipNum, CMvsfLotColTChipNum)
                .SetData(CMvsfLotTitleRow, CMvsfLotColCarrierID, CMvsfLotColTCarrierID)
                .SetData(CMvsfLotTitleRow, CMvsfLotColToCarrierId, CMvsfLotColTToCarrierID)
                .SetData(CMvsfLotTitleRow, CMvsfLotColACarrierId, CMvsfLotColTACarrierID)
                .SetData(CMvsfLotTitleRow, CMvsfLotColATrayNum, CMvsfLotColTATrayNum)
                .SetData(CMvsfLotTitleRow, CMvsfLotColTapeBatchId, CMvsfLotColTTapeBatchID)
                .SetData(CMvsfLotTitleRow, CMvsfLotColOvenBatchId, CMvsfLotColTOvenBatchID)
                .SetData(CMvsfLotTitleRow, CMvsfLotColALDBatchId, CMvsfLotColTALDBatchID)
                .SetData(CMvsfLotTitleRow, CMvsfLotColFlowClass, CMvsfLotColTFlowClass)
                .SetData(CMvsfLotTitleRow, CMvsfLotColPriority, CMvsfLotColTPriority)
                .SetData(CMvsfLotTitleRow, CMvsfLotColOpID, CMvsfLotColTOpID)
                .SetData(CMvsfLotTitleRow, CMvsfLotColStepID, CMvsfLotColTStepID)
                .SetData(CMvsfLotTitleRow, CMvsfLotColALDProcessNum, CMvsfLotColTALDProcessNum)
                .SetData(CMvsfLotTitleRow, CMvsfLotColALDProcessName, CMvsfLotColTALDProcessName)
                .SetData(CMvsfLotTitleRow, CMvsfLotColComments, CMvsfLotColTComments)
                .SetData(CMvsfLotTitleRow, CMvsfLotColEditTime, CMvsfLotColTEditTime)
                .SetData(CMvsfLotTitleRow, CMvsfLotColWorkCondition, CMvsfLotColTWorkCondition)
                .SetData(CMvsfLotTitleRow, CMvsfLotColEngEmpName, CMvsfLotColTEngEmpName)
                .SetData(CMvsfLotTitleRow, CMvsfLotColCollectionId, CMvsfLotColTCollectionId)
                .SetData(CMvsfLotTitleRow, CMvsfLotColCollectionVersion, CMvsfLotColTCollectionVersion)
                .SetData(CMvsfLotTitleRow, CMvsfLotColResultFlag, CMvsfLotColTResultFlag)
                
                .Cols(CMvsfLotColNo).Width = CMvsfLotColWNo
                .Cols(CMvsfLotColKb).Width = CMvsfLotColWKb
                .Cols(CMvsfLotColNowSt).Width = CMvsfLotColWNowSt
                .Cols(CMvsfLotColLimitTime).Width = CMvsfLotColWLimitTime
                .Cols(CMvsfLotColPdID).Width = CMvsfLotColWPdID
                .Cols(CMvsfLotColPdVersion).Width = CMvsfLotColWPdVersion
                .Cols(CMvsfLotColLotID).Width = CMvsfLotColWLotID
                .Cols(CMvsfLotColWfNum).Width = CMvsfLotColWWfNum
                .Cols(CMvsfLotColChipNum).Width = CMvsfLotColWChipNum
                .Cols(CMvsfLotColCarrierID).Width = CMvsfLotColWCarrierID
                .Cols(CMvsfLotColToCarrierId).Width = CMvsfLotColWToCarrierID
                .Cols(CMvsfLotColACarrierId).Width = CMvsfLotColWACarrierID
                .Cols(CMvsfLotColATrayNum).Width = CMvsfLotColWATrayNum
                .Cols(CMvsfLotColTapeBatchId).Width = CMvsfLotColWTapeBatchID
                .Cols(CMvsfLotColOvenBatchId).Width = CMvsfLotColWOvenBatchID
                .Cols(CMvsfLotColALDBatchId).Width = CMvsfLotColWALDBatchID
                .Cols(CMvsfLotColFlowClass).Width = CMvsfLotColWFlowClass
                .Cols(CMvsfLotColPriority).Width = CMvsfLotColWPriority
                .Cols(CMvsfLotColOpID).Width = CMvsfLotColWOpID
                .Cols(CMvsfLotColStepID).Width = CMvsfLotColWStepID
                .Cols(CMvsfLotColALDProcessNum).Width = CMvsfLotColWALDProcessNum
                .Cols(CMvsfLotColALDProcessName).Width = CMvsfLotColWALDProcessName
                .Cols(CMvsfLotColComments).Width = CMvsfLotColWComments
                .Cols(CMvsfLotColEditTime).Width = CMvsfLotColWEditTime
                .Cols(CMvsfLotColWorkCondition).Width = CMvsfLotColWWorkCondition
                .Cols(CMvsfLotColEngEmpName).Width = CMvsfLotColWEngEmpName
                .Cols(CMvsfLotColCollectionId).Width = CMvsfLotColWCollectionId
                .Cols(CMvsfLotColCollectionVersion).Width = CMvsfLotColWCollectionVersion
                .Cols(CMvsfLotColResultFlag).Width = CMvsfLotColWResultFlag
                
                '@列位置の設定
                .Cols(CMvsfLotColNo).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMvsfLotColKb).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColNowSt).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColLimitTime).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColPdID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColPdVersion).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMvsfLotColLotID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColWfNum).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMvsfLotColChipNum).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMvsfLotColCarrierID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColToCarrierId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColACarrierId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColATrayNum).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMvsfLotColTapeBatchId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColOvenBatchId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColALDBatchId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColFlowClass).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColPriority).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMvsfLotColOpID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColStepID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColALDProcessNum).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMvsfLotColALDProcessName).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColComments).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColEditTime).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColWorkCondition).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColEngEmpName).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColCollectionId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColCollectionVersion).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfLotColResultFlag).TextAlign = TextAlignEnum.LeftCenter
                
                '@非表示列設定
                .Cols(CMvsfLotColKb).Visible = False
                .Cols(CMvsfLotColPdVersion).Visible = False
                .Cols(CMvsfLotColACarrierId).Visible = False
                .Cols(CMvsfLotColATrayNum).Visible = False
                .Cols(CMvsfLotColTapeBatchId).Visible = False
                .Cols(CMvsfLotColOvenBatchId).Visible = False
                .Cols(CMvsfLotColALDBatchId).Visible = False
                .Cols(CMvsfLotColALDProcessNum).Visible = False
                .Cols(CMvsfLotColALDProcessName).Visible = False
                .Cols(CMvsfLotColComments).Visible = False
                .Cols(CMvsfLotColEditTime).Visible = False
                .Cols(CMvsfLotColWorkCondition).Visible = False
                .Cols(CMvsfLotColEngEmpName).Visible = False
                .Cols(CMvsfLotColCollectionId).Visible = False
                .Cols(CMvsfLotColCollectionVersion).Visible = False
                .Cols(CMvsfLotColResultFlag).Visible = False
                      
                '@自動列幅設定=自動調整する
                .AutoSizeCols(CMvsfLotColNo, .Cols.Count - 1, 6)
                
                .Redraw = True

                '@ﾛｯｸ
                '.Enabled = False
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvVsfLot_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfWp_init
    '機　能：装置一覧ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvvsfWP_init()
        
        Dim llngCnt As Integer
        
        Try
            
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfWp

                .Redraw = False
                
                .Row = -1
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter

                .Rows.DefaultSize = CMvsfWPHeight
                
                '@列数設定
                .Cols.Count = CMvsfWPCols
                '@行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .FocusRect = FocusRectEnum.None
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                  '中央表示
                lFixedStyle.ForeColor = Color.Yellow                                '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)   '背景色
                With .Font                                                          'ﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMvsfWPTFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .Rows(CMvsfWPTitleRow).Height = CMvsfWPHHeight                      '高さ
                lFixedStyle.Trimming = StringTrimming.None
                        
                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMvsfWPColNo).Width = CMvsfWPColWNo
                .Cols(CMvsfWPColWpID).Width = CMvsfWPColWWpID
                .Cols(CMvsfWPColWpName).Width = CMvsfWPColWWpName
                .Cols(CMvsfWpColRecipe).Width = CMvsfWpColWRecipe
                .Cols(CMvsfWPColLotRecipeFlag).Width = CMvsfWPColWLotRecipeFlag
                .Cols(CMvsfWpColActionFlag).Width = CMvsfWpColWActionFlag
                .Cols(CMvsfWPColLoaderUnloaderFlag).Width = CMvsfWPColWLoaderUnloaderFlag
                .Cols(CMvsfWpColBeforeCarrierTypeId).Width = CMvsfWpColWBeforeCarrierTypeId
                .Cols(CMvsfWpColBeforeCarrierTypeName).Width = CMvsfWpColWBeforeCarrierTypeName
                .Cols(CMvsfWpColAfterCarrierTypeId).Width = CMvsfWpColWAfterCarrierTypeId
                .Cols(CMvsfWpColAfterCarrierTypeName).Width = CMvsfWpColWAfterCarrierTypeName
                .Cols(CMvsfWPColEqType).Width = CMvsfWPColWEqType
                .Cols(CMvsfWpColMcType).Width = CMvsfWpColWMCType
                .Cols(CMvsfWpColMesModeId).Width = CMvsfWpColWMesModeId
                .Cols(CMvsfWpColMesModeStatus).Width = CMvsfWpColWMesModeStatus
                .Cols(CMvsfWpColWpStatusName).Width = CMvsfWpColWWpStatusName
                .Cols(CMvsfWpColUseId).Width = CMvsfWpColWUseId
                .Cols(CMvsfWpColWpTypeFlag).Width = CMvsfWpColWWpTypeFlag
                .Cols(CMvsfWPColCleanCondition).Width = CMvsfWPColWCleanCondition
                .Cols(CMvsfWpColWpStopFlag).Width = CMvsfWpColWWpStopFlag
                .Cols(CMvsfWpColFtpDataFlag).Width = CMvsfWpColWFtpDataFlag
                .Cols(CMvsfWPColOpID).Width = CMvsfWPColWOpID
                .Cols(CMvsfWPColStepID).Width = CMvsfWPColWStepID
                .Cols(CMvsfWpColNextOpId).Width = CMvsfWpColWNextOpId
                .Cols(CMvsfWpColNextStepId).Width = CMvsfWpColWNextStepId
                .Cols(CMvsfWpColALDProcessNum).Width = CMvsfWpColWALDProcessNum
                .Cols(CMvsfWpColALDProcessName).Width = CMvsfWpColWALDProcessName
                                
                .SetData(CMvsfWPTitleRow, CMvsfWPColNo, CMvsfWPColTNo)
                .SetData(CMvsfWPTitleRow, CMvsfWPColWpID, CMvsfWPColTWpID)
                .SetData(CMvsfWPTitleRow, CMvsfWPColWpName, CMvsfWPColTWpName)
                .SetData(CMvsfWPTitleRow, CMvsfWpColRecipe, CMvsfWpColTRecipe)
                .SetData(CMvsfWPTitleRow, CMvsfWPColLotRecipeFlag, CMvsfWPColTLotRecipeFlag)
                .SetData(CMvsfWPTitleRow, CMvsfWpColActionFlag, CMvsfWpColTActionFlag)
                .SetData(CMvsfWPTitleRow, CMvsfWPColLoaderUnloaderFlag, CMvsfWPColTLoaderUnloaderFlag)
                .SetData(CMvsfWPTitleRow, CMvsfWpColBeforeCarrierTypeId, CMvsfWpColTBeforeCarrierTypeId)
                .SetData(CMvsfWPTitleRow, CMvsfWpColBeforeCarrierTypeName, CMvsfWpColTBeforeCarrierTypeName)
                .SetData(CMvsfWPTitleRow, CMvsfWpColAfterCarrierTypeId, CMvsfWpColTAfterCarrierTypeId)
                .SetData(CMvsfWPTitleRow, CMvsfWpColAfterCarrierTypeName, CMvsfWpColTAfterCarrierTypeName)
                .SetData(CMvsfWPTitleRow, CMvsfWPColEqType, CMvsfWPColTEqType)
                .SetData(CMvsfWPTitleRow, CMvsfWpColMcType, CMvsfWpColTMcType)
                .SetData(CMvsfWPTitleRow, CMvsfWpColMesModeId, CMvsfWpColTMesModeId)
                .SetData(CMvsfWPTitleRow, CMvsfWpColMesModeStatus, CMvsfWpColTMesModeStatus)
                .SetData(CMvsfWPTitleRow, CMvsfWpColWpStatusName, CMvsfWpColTWpStatusName)
                .SetData(CMvsfWPTitleRow, CMvsfWpColUseId, CMvsfWpColTUseId)
                .SetData(CMvsfWPTitleRow, CMvsfWpColWpTypeFlag, CMvsfWpColTWpTypeFlag)
                .SetData(CMvsfWPTitleRow, CMvsfWPColCleanCondition, CMvsfWpColTCleanCondition)
                .SetData(CMvsfWPTitleRow, CMvsfWpColWpStopFlag, CMvsfWpColTWpStopFlag)
                .SetData(CMvsfWPTitleRow, CMvsfWpColFtpDataFlag, CMvsfWpColTFtpDataFlag)
                .SetData(CMvsfWPTitleRow, CMvsfWPColOpID, CMvsfWPColTOpID)
                .SetData(CMvsfWPTitleRow, CMvsfWPColStepID, CMvsfWPColTStepID)
                .SetData(CMvsfWPTitleRow, CMvsfWpColNextOpId, CMvsfWpColTNextOpId)
                .SetData(CMvsfWPTitleRow, CMvsfWpColNextStepId, CMvsfWpColTNextStepId)
                .SetData(CMvsfWPTitleRow, CMvsfWpColALDProcessNum, CMvsfWpColTALDProcessNum)
                .SetData(CMvsfWPTitleRow, CMvsfWpColALDProcessName, CMvsfWpColTALDProcessName)
                
                '@列位置の設定
                .Cols(CMvsfWPColNo).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMvsfWPColWpID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWPColWpName).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColRecipe).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWPColLotRecipeFlag).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColActionFlag).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWPColLoaderUnloaderFlag).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColBeforeCarrierTypeId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColBeforeCarrierTypeName).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColAfterCarrierTypeId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColAfterCarrierTypeName).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWPColEqType).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColMcType).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColMesModeId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColMesModeStatus).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColWpStatusName).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColUseId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColWpTypeFlag).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWPColCleanCondition).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColWpStopFlag).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMvsfWpColFtpDataFlag).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMvsfWPColOpID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWPColStepID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColNextOpId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColNextStepId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColALDProcessNum).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMvsfWpColALDProcessName).TextAlign = TextAlignEnum.LeftCenter
                
                '@非表示列設定
                For llngCnt = 0 To .Cols.Count - 1
                    .Cols(llngCnt).Visible = False
                Next
                        
                '@表示項目設定
                '@作業終了時
                If pstrfrmxxEN2Q0Div = CPstrCD13 Then
                    .Cols(CMvsfWpColNextOpId).Visible = True
                    .Cols(CMvsfWpColNextStepId).Visible = True
                
                '@それ以外
                Else
                    .Cols(CMvsfWPColWpName).Visible = True
                    .Cols(CMvsfWpColRecipe).Visible = True
                    .Cols(CMvsfWpColBeforeCarrierTypeName).Visible = True
                    .Cols(CMvsfWpColAfterCarrierTypeName).Visible = True
                    .Cols(CMvsfWpColMesModeId).Visible = True
                    .Cols(CMvsfWpColWpStatusName).Visible = True
                    
                    '@自動列幅設定=自動調整する
                    .AutoSizeCols(CMvsfWPColNo, .Cols.Count - 1, 6)
                    
                End If
                        
                .Redraw = True

                '@ﾛｯｸ
                '.Enabled = False
                'cmdWpUP.Enabled = False
                'cmdWpDown.Enabled = False
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "prvvsfWp_init"              'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfLot_Disp
    '機　能：画面の表示
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvVsfLot_Disp()

        Dim llngCnt             As Integer
        Dim llngSelectRow       As Integer
        Dim lstrLimitTime       As String
        Dim lstrLimitTimeAns    As String
        Dim lstrACarrier        As String
        Dim llngRowCnt          As Integer
        
        Try


            With mtypWorkALDLotList
            
                '@ﾗﾍﾞﾙ
                If .strProcessUnit = CPstrProcessUnit_Lot Then
                    lblProcessUnit.Text = CPstrProcessUnitName_Lot
                ElseIf .strProcessUnit = CPstrProcessUnit_Batch Then
                    lblProcessUnit.Text = CPstrProcessUnitName_Batch
                End If
                
                lblTapeBatchId.Text = .strTapeBatchId
                lblOvenBatchId.Text = .strOvenBatchId
                lblALDBatchId.Text = .strAldBatchId

                '@ｷｬﾘｱID
                If txtCarrier.Text = vbNullString Then
                    txtCarrier.Text = .strCarrierId
                End If
                
                '@ﾒﾝﾊﾞｰ変数
                mtypACarrierGroup.strTapeBatchId = .strTapeBatchId
                mtypACarrierGroup.strOvenBatchId = .strOvenBatchId
                mtypACarrierGroup.strAldBatchId = .strAldBatchId
                
                '@ACarrier文字設定
                lstrACarrier = prvstrACarrierLabelProductLot
                txtACarrierList.Text = lstrACarrier
                
            End With

            '@ﾛｯﾄ一覧
            With vsfLot

                .Redraw = False
            
                llngSelectRow = 0
                                
                For llngCnt = 0 To mtypWorkALDLotList.lngAldWorkLotListCnt - 1
                    llngRowCnt = llngCnt + 1
                                                       
                    .Rows.Count = .Rows.Count + 1
                    .SetData(llngRowCnt, CMvsfLotColNo, llngCnt + 1)
                    .SetData(llngRowCnt, CMvsfLotColKb, vbNullString)
                    .SetData(llngRowCnt, CMvsfLotColNowSt, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strNowST)
                    .SetData(llngRowCnt, CMvsfLotColPdID, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strPdId)
                    .SetData(llngRowCnt, CMvsfLotColPdVersion, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strPdVersion)
                    .SetData(llngRowCnt, CMvsfLotColLotID, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLotID)
                    .SetData(llngRowCnt, CMvsfLotColWfNum, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strWfNum)
                    .SetData(llngRowCnt, CMvsfLotColChipNum, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strChipQuantity)
                    .SetData(llngRowCnt, CMvsfLotColOpID, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strOpID)
                    .SetData(llngRowCnt, CMvsfLotColStepID, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strStepID)
                    .SetData(llngRowCnt, CMvsfLotColCarrierID, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strCarrierId)
                    .SetData(llngRowCnt, CMvsfLotColToCarrierId, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strToCarrierId)
                    
                    '@製品以外
                    If mtypWorkALDLotList.typAldWorkLotList(llngCnt).strFlowClass <> CPstrFlowClassMO And _
                       mtypWorkALDLotList.typAldWorkLotList(llngCnt).strFlowClass <> CPstrFlowClassQU And _
                       mtypWorkALDLotList.typAldWorkLotList(llngCnt).strFlowClass <> CPstrFillerDummy And _
                       mtypWorkALDLotList.typAldWorkLotList(llngCnt).strFlowClass <> CPstrSideDummy Then
                        .SetData(llngRowCnt, CMvsfLotColACarrierId, lstrACarrier)
                    Else
                        .SetData(llngRowCnt, CMvsfLotColACarrierId, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strACarrierId)
                    End If
                                
                    .SetData(llngRowCnt, CMvsfLotColATrayNum, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strATrayNum)
                    .SetData(llngRowCnt, CMvsfLotColPriority, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLotPriority)
                    .SetData(llngRowCnt, CMvsfLotColFlowClass, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strFlowClass)
                    .SetData(llngRowCnt, CMvsfLotColALDProcessNum, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strProcessNum)
                    .SetData(llngRowCnt, CMvsfLotColALDProcessName, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strProcessName)
                    .SetData(llngRowCnt, CMvsfLotColComments, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strComments)
                    .SetData(llngRowCnt, CMvsfLotColEditTime, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strEditTime)
                    .SetData(llngRowCnt, CMvsfLotColWorkCondition, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strWorkCondition)
                    .SetData(llngRowCnt, CMvsfLotColEngEmpName, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strEngEmpName)
                    .SetData(llngRowCnt, CMvsfLotColCollectionId, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strCollectionID)
                    .SetData(llngRowCnt, CMvsfLotColCollectionVersion, mtypWorkALDLotList.typAldWorkLotList(llngCnt).strCollectionVersion)
                    .SetData(llngRowCnt, CMvsfLotColResultFlag, vbNullString)
                                
                    '@-----------------------------------------------
                    '@ ﾌｫﾝﾄ色の設定1
                    '@　①警告時間：紫色
                    '@　②制限時間：赤色
                    '@-----------------------------------------------
                    '@時間制約有無の表示
                    If mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLimitTime <> vbNullString Then

                        '@時間制約がﾌﾟﾗｽの場合
                        If CLng(mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLimitTime) >= 0 Then

                            '@制限時間以下or処理時間制限以下の場合
                            If mtypWorkALDLotList.typAldWorkLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                mtypWorkALDLotList.typAldWorkLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID3 Then

                                '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                lstrLimitTime = Format(CLng(mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLimitTime), CPstrDateFormatKanma)

                                '@制限時間先大工程+制限時間先小工程+制限時間+「以内」(組立は小工程のみの表示）
                                '@制限時間を時間と分で分割表示する
                                lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)

                                .SetData(llngRowCnt, CMvsfLotColLimitTime, _
                                    mtypWorkALDLotList.typAldWorkLotList(llngCnt).strToStepId & CPstrMade & lstrLimitTimeAns & CPstrinai)
                                
                                '@警告時間が設定されている場合
                                If mtypWorkALDLotList.typAldWorkLotList(llngCnt).strWarnTime <> vbNullString Then
                                    '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                    If CLng(mtypWorkALDLotList.typAldWorkLotList(llngCnt).strWarnTime) < 0 And _
                                       CLng(mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLimitTime) >= 0 Then
                                        '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_CPlngVbColorPurple")
                                        newStyle.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)
                                        Dim cellRange As CellRange = .GetCellRange(llngRowCnt, CMvsfLotColLimitTime, _
                                                               llngRowCnt, CMvsfLotColLimitTime)
                                        cellRange.Style = newStyle
                                    End If
                                End If
                            End If
                        Else
                            '@制限時間がﾏｲﾅｽの場合

                            '@ﾌｫﾝﾄｶﾗｰを赤に変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_CPlngVbColorRed")
                            newStyle.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)
                            Dim cellRange As CellRange = .GetCellRange(llngRowCnt, CMvsfLotColLimitTime, llngRowCnt, CMvsfLotColLimitTime)
                            cellRange.Style = newStyle

                            '@制限時間以下or処理時間制限以下の場合
                            If mtypWorkALDLotList.typAldWorkLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                mtypWorkALDLotList.typAldWorkLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID3 Then

                                '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                lstrLimitTime = Format(CLng(mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLimitTime), CPstrDateFormatKanma)

                                '@制限時間先大工程+制限時間先小工程+制限時間+「以内」(組立は小工程のみの表示）
                                '@制限時間を時間と分で分割表示する
                                lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)

                                .SetData(llngRowCnt, CMvsfLotColLimitTime, _
                                    mtypWorkALDLotList.typAldWorkLotList(llngCnt).strToStepId & CPstrMade & lstrLimitTimeAns & CPstrinai)
                                
                            End If

                            '@制限時間以上の場合
                            If mtypWorkALDLotList.typAldWorkLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID2 Then

                                '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,##0)+"分"
                                lstrLimitTime = Replace(Format(CLng(mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString)

                                '@制限時間先大工程+制限時間先小工程+制限時間+「以上」(組立は小工程のみの表示）
                                '@制限時間を時間と分で分割表示する
                                lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)

                                .SetData(llngRowCnt, CMvsfLotColLimitTime, _
                                    mtypWorkALDLotList.typAldWorkLotList(llngCnt).strToStepId & CPstrMade & lstrLimitTimeAns & CPstrijyou)
                                
                            End If
                        End If
                    End If

                    '@-----------------------------------------------
                    '@ 保/停区分列の設定
                    '@　①部分ﾚｼﾋﾟ > 号機指定 > ﾘﾜｰｸ/追加流動 > 処理限定ﾚｼﾋﾟ > 保留 > 停止
                    '@-----------------------------------------------
                    '@停止ﾌﾗｸﾞが"1：停止中"か
                    If mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLotStopFlag = CMstrLotStopFlgOn Then

                        '@=======================
                        '@ 区分列表示処理(※区分列に"停"を表示)
                        '@=======================
                        .SetData(llngRowCnt, CMvsfLotColKb, _
                            pubstrColKbn_Set(.GetData(llngRowCnt, CMvsfLotColKb), CMstrTei))

                    End If

                    '@保留ﾌﾗｸﾞが"1：保留中"か
                    If mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLotHoldFlag = CMstrLotHoldFlgOn Then

                        '@=======================
                        '@ 区分列表示処理(※区分列に"保"を表示)
                        '@=======================
                        .SetData(llngRowCnt, CMvsfLotColKb, _
                            pubstrColKbn_Set(.GetData(llngRowCnt, CMvsfLotColKb), CMstrHo))
                    End If
                    
                    '@行の高さ設定
                    .Rows(llngRowCnt).Height = CMvsfLotHeight
                    
                    If mtypWorkALDLotList.strLotID = mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLotID Then
                        llngSelectRow = llngRowCnt
                    End If
                    
                Next llngCnt
                        
                '@Cellﾏｰｼﾞ
                .AllowMerging = AllowMergingEnum.Free
                .Cols(CMvsfLotColACarrierId).AllowMerging = True
                
                '@列幅の設定
                .AutoSizeCol(CMvsfLotColNo, -2)            '№
                .AutoSizeCol(CMvsfLotColLotID, 6)          'ﾛｯﾄID
                .AutoSizeCol(CMvsfLotColLimitTime, -2)     '時間制限
                .AutoSizeCol(CMvsfLotColNowSt, 4)          '状態
                .AutoSizeCol(CMvsfLotColPdID, 4)           '機種
                .AutoSizeCol(CMvsfLotColCarrierID, -2)     'ｷｬﾘｱID
                .AutoSizeCol(CMvsfLotColToCarrierId, -4)   'ｷｬﾘｱID(Unloader)
                .AutoSizeCol(CMvsfLotColFlowClass, -2)     '種別
                .AutoSizeCol(CMvsfLotColPriority, 0)       '優先順位
                .AutoSizeCol(CMvsfLotColOpID, 4)           '大工程
                .AutoSizeCol(CMvsfLotColStepID, 4)         '小工程
                .AutoSizeCol(CMvsfLotColWfNum, -4)         'WF枚数
                .AutoSizeCol(CMvsfLotColChipNum, 0)        'ﾁｯﾌﾟ数
                
                If llngSelectRow > 0 Then
                    .Row = llngSelectRow
                End If
                If .Row < 0 Then
                    .Row = CMvsfLotTitleRow
                End If
                .Col = CMvsfLotColNo
                
                .Redraw = True

                '@ﾛｯｸ解除
                '.Enabled = True
                          
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvVsfLot_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfWp_Disp
    '機　能：装置(WPID)一覧の設定
    '引　数：mtypLotWpList：装置情報格納用構造体
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvvsfWP_Disp()
        
        Dim llngCnt             As Integer
        Dim llngRowCnt          As Integer

        Try
            
            
            With vsfWp

                .Redraw = False
                
                '@ｶｳﾝﾀ初期化
                llngCnt = 1
                
                '@行設定
                llngRowCnt = .Rows.Fixed
                    
                '@装置ｸﾞﾘｯﾄ格納
                For llngCnt = 0 To mtypLotWpList.lngALDWpListListCnt - 1
                        
                    .Rows.Count = .Rows.Count + 1
                    .SetData(llngRowCnt, CMvsfWPColNo, llngCnt + 1)
                    .SetData(llngRowCnt, CMvsfWPColWpID, mtypLotWpList.typALDWpListList(llngCnt).strWpID)
                    .SetData(llngRowCnt, CMvsfWPColWpName, mtypLotWpList.typALDWpListList(llngCnt).strWpName)
                    .SetData(llngRowCnt, CMvsfWpColRecipe, mtypLotWpList.typALDWpListList(llngCnt).strRecipeId)
                    .SetData(llngRowCnt, CMvsfWPColLotRecipeFlag, mtypLotWpList.typALDWpListList(llngCnt).strLotRecipeFlag)
                    .SetData(llngRowCnt, CMvsfWPColLoaderUnloaderFlag, mtypLotWpList.typALDWpListList(llngCnt).strLoaderUnloaderFlag)
                    .SetData(llngRowCnt, CMvsfWpColBeforeCarrierTypeId, mtypLotWpList.typALDWpListList(llngCnt).strBeforeCarrierTypeId)
                    .SetData(llngRowCnt, CMvsfWpColBeforeCarrierTypeName, mtypLotWpList.typALDWpListList(llngCnt).strBeforeCarrierTypeName)
                    .SetData(llngRowCnt, CMvsfWpColAfterCarrierTypeId, mtypLotWpList.typALDWpListList(llngCnt).strAfterCarrierTypeId)
                    .SetData(llngRowCnt, CMvsfWpColAfterCarrierTypeName, mtypLotWpList.typALDWpListList(llngCnt).strAfterCarrierTypeName)
                    .SetData(llngRowCnt, CMvsfWPColEqType, mtypLotWpList.typALDWpListList(llngCnt).strEqType)
                    .SetData(llngRowCnt, CMvsfWpColMcType, mtypLotWpList.typALDWpListList(llngCnt).strMcType)
                    .SetData(llngRowCnt, CMvsfWpColMesModeId, mtypLotWpList.typALDWpListList(llngCnt).strMesModeId)
                    .SetData(llngRowCnt, CMvsfWpColMesModeStatus, mtypLotWpList.typALDWpListList(llngCnt).strMesModeStatus)
                    .SetData(llngRowCnt, CMvsfWpColWpStatusName, mtypLotWpList.typALDWpListList(llngCnt).strWpStatusName)
                    .SetData(llngRowCnt, CMvsfWpColUseId, mtypLotWpList.typALDWpListList(llngCnt).strUseId)
                    .SetData(llngRowCnt, CMvsfWpColWpTypeFlag, mtypLotWpList.typALDWpListList(llngCnt).strWpTypeFlag)
                    .SetData(llngRowCnt, CMvsfWPColCleanCondition, mtypLotWpList.typALDWpListList(llngCnt).strCleanCondition)
                    .SetData(llngRowCnt, CMvsfWpColWpStopFlag, mtypLotWpList.typALDWpListList(llngCnt).strWpStopFlag)
                    .SetData(llngRowCnt, CMvsfWpColFtpDataFlag, mtypLotWpList.typALDWpListList(llngCnt).strFtpDataFlag)
                    .SetData(llngRowCnt, CMvsfWPColOpID, mtypLotWpList.typALDWpListList(llngCnt).strOpID)
                    .SetData(llngRowCnt, CMvsfWPColStepID, mtypLotWpList.typALDWpListList(llngCnt).strStepID)
                    .SetData(llngRowCnt, CMvsfWpColNextOpId, mtypLotWpList.typALDWpListList(llngCnt).strNextOpId)
                    .SetData(llngRowCnt, CMvsfWpColNextStepId, mtypLotWpList.typALDWpListList(llngCnt).strNextStepId)
                    .SetData(llngRowCnt, CMvsfWpColALDProcessNum, mtypLotWpList.typALDWpListList(llngCnt).strProcessNum)
                    .SetData(llngRowCnt, CMvsfWpColALDProcessName, mtypLotWpList.typALDWpListList(llngCnt).strProcessName)
                            
                    '@ｱｸｼｮﾝ予約表示ﾌﾗｸﾞの初期化
                    .SetData(llngRowCnt, CMvsfWpColActionFlag, CMstrActionFlgNever)
                            
                    '@行の高さ設定
                    .Rows(llngRowCnt).Height = CMvsfWPHeight
                    llngRowCnt = llngRowCnt + 1
                    
                Next
                            
                '@作業開始時以外
                If pstrfrmxxEN2Q0Div <> CPstrCD13 Then
                    
                    '@列幅の設定
                    .AutoSizeCols(CMvsfWPColNo, .Cols.Count - 1, 6)
                    
                End If

                If .Row < 0 Then
                    .Row = CMvsfWPTitleRow
                End If
                .Col = CMvsfWPColNo

                .Redraw = True
                
                '@ﾛｯｸ解除
                '.Enabled = True
            End With
            
            '@=======================
            '@ 装置一覧初期ﾎﾞﾀﾝ設定
            '@=======================
            'Call pubVsfDisp(vsfWp, cmdWpUP, cmdWpDown)
            
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "prvvsfWp_Disp"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfLotAcarrier_Disp
    '機　能：画面の表示(ACarrier)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvVsfLotAcarrier_Disp()

        Dim llngCnt             As Integer
        Dim lstrACarrier        As String

        Try
            
            
            '@ﾛｯﾄ一覧
            With vsfLot
            
                lstrACarrier = vbNullString
                
                '@ﾛｯｸ
                .Enabled = False
                
                For llngCnt = 0 To mtypACarrierGroup.lngGroupListCnt - 1
                    '@ACaarier有
                    If mtypACarrierGroup.typACarrierGroupList(llngCnt).strACarrierId <> vbNullString Then
                        If lstrACarrier = vbNullString Then
                            lstrACarrier = mtypACarrierGroup.typACarrierGroupList(llngCnt).strACarrierId
                        Else
                            lstrACarrier = lstrACarrier + vbCrLf + mtypACarrierGroup.typACarrierGroupList(llngCnt).strACarrierId
                        End If
                    End If
                Next llngCnt
                
                '@ACarrier表示
                For llngCnt = 1 To .Rows.Count - 1
                    .SetData(llngCnt, CMvsfLotColACarrierId, lstrACarrier)
                Next
                
                '@Cellﾏｰｼﾞ
                .AllowMerging = AllowMergingEnum.Free
                .Cols(CMvsfLotColACarrierId).AllowMerging = True
                
                '@列幅の設定
                .AutoSizeCol(CMvsfLotColACarrierId, 6)
                
                '@ﾛｯｸ解除
                .Enabled = True
                                  
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvVsfLotAcarrier_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnData_Check
    '機　能：確定時の入力ﾁｪｯｸ
    '引　数：
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Function prvblnData_Check() As Boolean
        
        Dim llngCnt         As Integer
        Dim lstrLotStatus   As String
        
        
        Try
            
            prvblnData_Check = False
            
            '@ｷｬﾘｱIDの入力ﾁｪｯｸ
            If txtCarrier.Text = vbNullString Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If Len(txtCarrier.Text) <> CMlngCarrierMaxLength Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM07W>$$キャリアIDは6桁で入力してください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
                
            '@ｱﾝﾛｰﾀﾞｷｬﾘｱ有効時
            If txtUnloaderCarrier.Enabled = True Then
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱの入力ﾁｪｯｸ
                If txtUnloaderCarrier.Text = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                    '@ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtUnloaderCarrier)
                    Exit Function
                End If
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDの桁ﾁｪｯｸ
                If Len(txtUnloaderCarrier.Text) <> CMlngCarrierMaxLength Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「<TRM12W>$$ロットIDは10桁で入力してください。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                    '@ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtUnloaderCarrier)
                Exit Function
                End If
            End If
                    
            '@装置ﾁｪｯｸ
            With vsfWp
                
                '@装置が無い場合
                If .Row = CMvsfWPTitleRow Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM18W>$$装置名が設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0018)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@装置一覧にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfWp)
                    Exit Function
                    
                End If
                
                '@装置IDのﾁｪｯｸ
                If .GetData(vsfWp.Row, CMvsfWPColWpID) = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM18W>$$装置名が設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0018)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                    '@装置一覧にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfWp)
                    Exit Function
                End If
                
                '@作業開始時
                If pstrfrmxxEN2Q0Div = CPstrCD10 Then
                   '@通常装置(H/W以外を想定)
                   '@待機中以外(処理中では作業開始NG)
                   '@作業開始時に装置通信用FTPﾌｧｲﾙを作成する為、複数ﾛｯﾄの作業開始は制限する
                    If .GetData(vsfWp.Row, CMvsfWpColWpTypeFlag) = CPstrWpTypeNormal And _
                        .GetData(vsfWp.Row, CMvsfWpColWpStatusName) <> CPstrWpIdle Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM18W>$$装置が待機中ではない為、中止します。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004D)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@装置一覧にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfWp)
                        Exit Function
                    End If
                End If
                        
            End With
            
            '@起動区分
            Select Case pstrfrmxxEN2Q0Div
                Case CPstrCD10
                    '@作業待ち
                    lstrLotStatus = CPstrWaitWorkSt
                
                Case CPstrCD11
                    '@前処理
                    lstrLotStatus = CPstrBeforeProgressSt
                    
                Case CPstrCD12
                    '@処理中
                    lstrLotStatus = CPstrProcessingSt
                    
                Case CPstrCD13
                    '@後処理
                    lstrLotStatus = CPstrAfterProgressSt
                    
                    '@ﾊﾝﾄﾞﾜｰｸ装置の場合
                    If vsfWp.GetData(vsfWp.Row, CMvsfWpColWpTypeFlag) = CMstrHandWork Then
                        '@処理中
                        lstrLotStatus = CPstrProcessingSt
                    End If
                    
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「 "<TRMY0W>$$システムエラーが発生しました。システム担当者に連絡してください。"」
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y0)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Exit Function
                    
            End Select
            
            '@ﾛｯﾄﾁｪｯｸ
            With vsfLot
                For llngCnt = 1 To .Rows.Count - 1
                    If .GetData(llngCnt, CMvsfLotColNowSt) <> lstrLotStatus Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「 "<TRM2BI>$$ロット[%1]は[%2]の為[%3]できません。"」
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002B, .GetData(llngCnt, CMvsfLotColLotID), _
                            .GetData(llngCnt, CMvsfLotColNowSt), Me.Text)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                        '@ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtCarrier)
                        Exit Function
                    End If
                    
                    
                    
                Next
            End With

            prvblnData_Check = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "prvblnData_Check"  'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvAllLotActionDisp_Proc
    '機　能：ｱｸｼｮﾝ予約表示(全ﾛｯﾄ)
    '引　数：lstrWPID       ：装置ID
    '戻り値：
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvAllLotActionDisp_Proc(ByVal lstrWpId As String)
        
        Dim llngCnt     As Integer
        
        Try
            
            '@ﾎﾞﾀﾝ非表示は終了
            If cmdActionDisp.Visible = False Then
                Exit Sub
            End If
            
            '@初期化
            cmdActionDisp.Enabled = False
            
            '@ｱｸｼｮﾝ予約検索
            If mtypLotAction IsNot Nothing Then
                For llngCnt = 0 To mtypLotAction.Count - 1
            
                    If mtypLotAction(llngCnt).lnglstCnt > 0 Then
                        
                        '@ﾃﾞｰﾀ引継
                        ptypLotAction = mtypLotAction(llngCnt)
                        
                        '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面名称設定
                        frmxxCM0040.Instance.Text = CPstrSubDispTitleActionMsg
                        
                        '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ表示画面を表示(ltypLotActionの情報でｱｸｼｮﾝ予約の内容を表示)
                        frmxxCM0040.Instance.ShowDialog(Me)
                        frmxxCM0040.Instance = Nothing

                        cmdActionDisp.Enabled = True

                    End If
                Next
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvAllLotActionDisp_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvAllLotAction_Get
    '機　能：ｱｸｼｮﾝ予約表示
    '引　数：lstrWPID           ：装置ID
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvAllLotAction_Get(ByVal lstrWpId As String)
                                                                                    
        Dim lblnAns         As Boolean
        Dim llngCnt         As Integer
        Dim llngCnt2        As Integer
        Dim llngCnt3        As Integer
        Dim lstrEventName   As String
        
        Try
            
            '@ｱｸｼｮﾝ予約ﾎﾞﾀﾝ
            If cmdActionDisp.Visible = False Then
                Exit Sub
            End If

            '@初期化
            mtypLotAction = New List(Of LotAction)
            llngCnt2 = 0
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "prvAllLotAction_Get"
            Call pubResponseStart(Me.Text, lstrEventName)
            
            '@全ﾛｯﾄ対象
            For llngCnt = 0 To mtypWorkALDLotList.lngAldWorkLotListCnt - 1
                '@同じALD処理工程のみ確認
                If mtypWorkALDLotList.typAldWorkLotList(llngCnt).strProcessNum = mtypWorkALDLotList.strProcessNum Then
                
                    Dim ltypLotActionTmp As New LotAction

                    '@=======================
                    '@ ｱｸｼｮﾝ予約ﾘｽﾄ取得
                    '@=======================
                    lblnAns = pubblnLotActList_Sel(CMstrlot_actlist_Ver, _
                                                   mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLotID, _
                                                   mtypWorkALDLotList.typAldWorkLotList(llngCnt).strOpID, _
                                                   mtypWorkALDLotList.typAldWorkLotList(llngCnt).strStepID, _
                                                   mtypWorkALDLotList.typAldWorkLotList(llngCnt).strPdId, _
                                                   mtypWorkALDLotList.typAldWorkLotList(llngCnt).strPdVersion, _
                                                   lstrWpId, _
                                                   ltypLotActionTmp)
                    
                    For llngCnt3 = 0 To ltypLotActionTmp.lnglstCnt - 1
                        Dim ltypLotActListTmp As New LotActList
                        ltypLotActListTmp = ltypLotActionTmp.typLotActList(llngCnt3)

                        ltypLotActListTmp.strLotID = mtypWorkALDLotList.typAldWorkLotList(llngCnt).strLotID
                        ltypLotActListTmp.strOpID = mtypWorkALDLotList.typAldWorkLotList(llngCnt).strOpID
                        ltypLotActListTmp.strStepID = mtypWorkALDLotList.typAldWorkLotList(llngCnt).strStepID
                        ltypLotActListTmp.strFlowClass = mtypWorkALDLotList.typAldWorkLotList(llngCnt).strFlowClass
                            
                        '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ判定
                        Select Case ltypLotActListTmp.strLotActionTypeID
                            '@ﾛｯﾄの場合
                            Case CPstrLotActionTypeID0
                                ltypLotActListTmp.strLotActionTypeName = CPstrActTypeLOT     'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                            '@機種の場合
                            Case CPstrLotActionTypeID1
                                ltypLotActListTmp.strLotActionTypeName = CPstrActTypePD      'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                            '@装置の場合
                            Case CPstrLotActionTypeID2
                                ltypLotActListTmp.strLotActionTypeName = CPstrActTypeWP      'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                            '@特定工程の場合
                            Case CPstrLotActionTypeID3
                                ltypLotActListTmp.strLotActionTypeName = CPstrActTypeTStep   'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                        End Select
                            
                        ltypLotActListTmp.strActionTrigger = Me.Text                         'ｱｸｼｮﾝﾄﾘｶﾞｰ

                        ltypLotActionTmp.typLotActList(llngCnt3) = ltypLotActListTmp
                    Next

                    mtypLotAction.Add(ltypLotActionTmp)
                    
                    llngCnt2 = llngCnt2 + 1
                    
                    '@結果OK/NGは判断しない
                End If
            Next
                                                  
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Text, lstrEventName)
                                                              
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "prvAllLotAction_Get"   'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

' 未使用機能NSYS ↓
''関数名：prvstrRecipeIDCr_Proc
''機　能：ﾚｼﾋﾟIDを折り返す
''引　数：lstrRecpID：ﾚｼﾋﾟID
''戻り値：折り返し後のﾚｼﾋﾟID
''作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
''更新日：
''備　考：
'Private Function prvstrRecipeIDCr_Proc(ByVal lstrRecpID As String) As String

'    Dim llngMaxLen              As Long                 'ﾚｼﾋﾟ文字数
'    Dim llngLenCnt              As Long                 '文字ｶｳﾝﾄ
'    Dim lstrRecpIDWk            As String               'ﾚｼﾋﾟID

'    On Error GoTo Error_Handler

'    '@ﾚｼﾋﾟIDの文字数
'    llngMaxLen = Len(lstrRecpID)
    
'    '@ﾚｼﾋﾟID文字数が折り返し文字数以下の場合
'    If llngMaxLen <= CMlngRecpCrLen Then
        
'        '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟをｾｯﾄ
'        prvstrRecipeIDCr_Proc = lstrRecpID
'    Else
'        '@ﾚｼﾋﾟIDの最後の文字まで
'        For llngLenCnt = 1 To llngMaxLen
            
'            '@文字数判定
'            Select Case llngLenCnt
                
'                '@折り返し文字数の場合
'                Case CMlngRecpCrLen, CMlngRecpCrLen + CMlngRecpCrLen
                    
'                    lstrRecpIDWk = lstrRecpIDWk & Mid$(lstrRecpID, llngLenCnt, 1) & vbCrLf
                
'                Case Else
                    
'                    lstrRecpIDWk = lstrRecpIDWk & Mid$(lstrRecpID, llngLenCnt, 1)
            
'            End Select
'        Next llngLenCnt
        
'        '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟをｾｯﾄ
'        prvstrRecipeIDCr_Proc = lstrRecpIDWk
'    End If

'    Exit Function

'Error_Handler:

'    '@ｴﾗｰ情報設定
'    With ptypOnErrorInfo
'        .strMenuKey = CPstrKeyEN02Q0                '機能ID
'        .strProcName = "prvstrRecipeIDCr_Proc"      'ﾌﾟﾛｼｰｼﾞｬ名
'        .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
'    End With

'    '@=======================
'    '@ 共通ｴﾗｰ処理
'    '@=======================
'    Call pubOnError_Proc

'End Function
' 未使用機能NSYS ↑

    '関数名：prvHandWork_Set
    '機　能：ﾊﾝﾄﾞﾜｰｸ対応
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvHandWork_Set()
        
        Try
                
            '@引継構造体のｷｬﾘｱIDが空欄でない場合
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                
                '@UnloaderｷｬﾘｱIDが空欄でないか否かで判別
                If txtUnloaderCarrier.Text <> vbNullString Then
                    ptypCommonInfo.strCarrierId = txtCarrier.Text
                    ptypCommonInfo.strToCarrierId = txtUnloaderCarrier.Text
                Else
                    ptypCommonInfo.strCarrierId = txtCarrier.Text
                    ptypCommonInfo.strToCarrierId = vbNullString
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0                '機能ID
                .strProcName = "prvHandWork_Set"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvColorChang
    '機　能：色変え処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvColorChang()

        Dim llngNo      As Integer      'ｶｳﾝﾀ

        Try

            '@ﾃﾞﾌｫﾙﾄ装置でない場合は，「赤」表示
            If pstrTerminalFlag = CPstrZero Then
                If pblnWpSelectFlag <> True Then

                    '@全てのｺﾝﾄﾛｰﾙのﾀｲﾄﾙを赤にする
                    For llngNo = 0 To CMlngLabelMaxIndex
                        Me.Controls("lblTtl" & llngNo.ToString).BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    Next

                    vsfLot.Styles.Fixed.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    vsfWp.Styles.Fixed.BackColor = ColorTranslator.FromWin32(CMlngRedColor)

                End If
            Else
                '@全てのｺﾝﾄﾛｰﾙのﾀｲﾄﾙを赤にする
                For llngNo = 0 To CMlngLabelMaxIndex
                    Me.Controls("lblTtl" & llngNo.ToString).BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                Next

                vsfLot.Styles.Fixed.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                vsfWp.Styles.Fixed.BackColor = ColorTranslator.FromWin32(CMlngRedColor)

            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvColorChang"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnChgMaterial_Chk
    '機　能：使用部材判定＆権限ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True   ：権限あり or 通常実行
    '　　　：False  ：権限なし or 処理中断
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Function prvblnChgMaterial_Chk() As Boolean

        Dim lblnAns                 As Boolean      '戻り値判定用(true or false)
        Dim llngAns                 As Integer      '戻り値判定用(ﾒｯｾｰｼﾞﾎﾞｯｸｽからのﾘﾀｰﾝ値参照)
        Dim lstrPdResultFlag        As String       '機種限定ﾁｪｯｸﾌﾗｸﾞ格納用

        Try
            
            '@戻り値の初期化
            prvblnChgMaterial_Chk = False
            
            '@---- 使用部材期限関連ﾁｪｯｸ ----
            
            '@=======================
            '@ 装置使用部材の判定処理(期限関連)を行なう
            '@=======================
            lblnAns = prvblnMaterialPeriod_Chk(lstrPdResultFlag)
                
            '@ｴﾗｰMsg判定(何らかの期限制約に引っ掛かっている場合は、"Msgあり")
            If lblnAns = True Then
                '@ﾁｪｯｸOK

                '@ｴﾗｰMsg判定(Msg有り=何らかの期限超過あり、Msg無し=期限等の制約に問題なし)
                If mstrLimitErrMsg <> vbNullString Then
                    '@ｴﾗｰMsgが格納されている場合

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM7UW>$$%1"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007U, mstrLimitErrMsg)
                    '@確認ﾒｯｾｰｼﾞBOXを表示する
                    llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                    '@要求確認
                    If llngAns = vbNo Then
                        
                        '@戻り値を"false=処理中断"を設定
                        prvblnChgMaterial_Chk = False
                        
                        '@強制実行ﾌﾗｸﾞを初期化
                        mstrLimitForcedAction = CPstrZero
                        Exit Function
                    Else
                        '@強制実行を行なう(mstrLimitForcedAction=1)
                        mstrLimitForcedAction = CPstrOne
                    End If
                Else
                    '@ｴﾗｰMsgが格納されていない場合

                    '@通常実行を行なう(mstrLimitForcedAction=0)
                    mstrLimitForcedAction = CPstrZero
                End If

                '@機種限定判定ｴﾗｰMsg判定(Msg有り=機種限定判定問題あり、Msg無し=機種限定判定問題なし)
                If mstrPdErrMsg <> vbNullString Then
                    '@ｴﾗｰMsgが格納されている場合

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM7UW>$$%1"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007U, mstrPdErrMsg)
                    '@確認ﾒｯｾｰｼﾞBOXを表示する
                    llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                    '@要求確認
                    If llngAns = vbNo Then
                        
                        '@戻り値を"false=処理中断"を設定
                        prvblnChgMaterial_Chk = False
                        
                        '@強制実行ﾌﾗｸﾞを初期化
                        mstrPdForcedAction = CPstrZero
                        Exit Function
                    Else
                        '@強制実行を行なう(mstrPdForcedAction=1)
                        mstrPdForcedAction = CPstrOne
                    End If
                Else
                    '@ｴﾗｰMsgが格納されていない場合

                    '@通常実行を行なう(mstrPdForcedAction=0)
                    mstrPdForcedAction = CPstrZero
                End If
            Else
                '@ﾁｪｯｸNG
                Exit Function
            End If
            
            '@期限切れ、機種限定部材の強制実行か
            If mstrPdForcedAction = CPstrOne Or _
                mstrLimitForcedAction = CPstrOne Then
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ 作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0020.Instance.ShowDialog(Me)
                frmxxCM0020.Instance = Nothing
            Else
            
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ 作業者ｺｰﾄﾞ入力画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0010.Instance.ShowDialog(Me)
                frmxxCM0010.Instance = Nothing
            End If
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                
                '@戻り値を"false=処理中断"を設定
                prvblnChgMaterial_Chk = False
                Exit Function
            End If
                
            '@強制実行が行なわれた場合は、権限ﾁｪｯｸを行なう
            If mstrPdForcedAction = CPstrOne Or _
                mstrLimitForcedAction = CPstrOne Then
                '@強制実行の場合
                
                '@=======================
                '@ 期限超過部材使用権限ﾁｪｯｸ
                '@=======================
                lblnAns = prvblnAuthority_Chk
                    
                '@権限判定結果
                If lblnAns = False Then
                    '@"権限なし"の場合
                
                    '@戻り値を"false=権限なし"を設定
                    prvblnChgMaterial_Chk = False
                    '@処理中断
                    Exit Function
                Else
                    '@"権限あり"の場合
                    
                    '@戻り値を"true=権限あり"を設定
                    prvblnChgMaterial_Chk = True
                End If
            Else
                '@通常実行の場合
                
                '@戻り値を"true=通常"を設定
                prvblnChgMaterial_Chk = True
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvblnChgMaterial_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnMaterialPeriod_Chk
    '機　能：使用部材ﾁｪｯｸ処理
    '引　数：lstrPdResultFlag   :機種限定ﾁｪｯｸﾌﾗｸﾞ
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Function prvblnMaterialPeriod_Chk(ByRef lstrPdResultFlag As String) As Boolean

        Dim lblnAns             As Boolean              '戻り値判定用
        Dim ltypChkMaterial     As ChkMaterial          '装置使用部材判定要求格納用
        Dim lstrEventName       As String


        Try
            
            lstrEventName = "prvblnMaterialPeriod_Chk"
                
            '@戻り値の初期化
            prvblnMaterialPeriod_Chk = False
            
            '@画面の使用禁止
            Me.KeyPreview = False
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ格納
            '@***********************
            With ltypChkMaterial
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrmat_chkwpmaterialVer      'Msgﾊﾞｰｼﾞｮﾝ
                .strMaterialTypeID = vbNullString           '部材種別ID(NULL)
                .strMaterialID = vbNullString               '部材ID(NULL)
                .strMaterialLotID = vbNullString            '部材管理ID(NULL)
                .strClassDivision = pstrfrmxxEN2Q0Div       '処理区分
                .strWpID = vsfWp.GetData(vsfWp.Row, CMvsfWPColWpID)        '装置ID
                .strLotID = vsfLot.GetData(vsfLot.Row, CMvsfLotColLotID)   'ﾛｯﾄID
            End With
            
            '@構造体のｺﾋﾟｰ
            ltypChkMaterial.typMaterialTypeList = ptypChkMaterial.typMaterialTypeList       '配列
            ltypChkMaterial.lngMaterialTypeCnt = ptypChkMaterial.lngMaterialTypeCnt         '配列ｶｳﾝﾀ
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Text, lstrEventName)
            
            '@=======================
            '@ 装置使用部材判定ﾒｯｾｰｼﾞ送信
            '@=======================
            lblnAns = pubblnMatChkWPMaterial_Chk(ltypChkMaterial, _
                                                 mstrPdErrMsg, _
                                                 mstrLimitErrMsg)
                
            '@画面の使用禁止解除
            Me.KeyPreview = True
            
            '@戻り値判定
            If lblnAns = True Then
                '@取得成功
         
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Text, lstrEventName)
                
                '@戻り値の設定
                prvblnMaterialPeriod_Chk = True
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Text, lstrEventName)
            End If

            Exit Function

        Catch ex As Exception

            '@画面の使用禁止解除
            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvblnMaterialPeriod_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnAuthority_Chk
    '機　能：期限超過部材使用権限ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Function prvblnAuthority_Chk() As Boolean

        Dim lblnAns                 As Boolean              '戻り値判定用
        Dim lstrFunctionID          As String               '機能ID
        Dim lstrActionID            As String               'ｱｸｼｮﾝID
        Dim lstrEmpID               As String               '作業者ID
        Dim lstrEmpName             As String               '作業者名
        Dim lstrSBID                As String               'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim lstrEventName           As String


        Try
                    
            lstrEventName = "prvblnAuthority_Chk"
                           
            '@戻り値の初期化
            prvblnAuthority_Chk = False
                    
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Function
            End If
            
            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                Exit Function
            End If
            
            '@画面の使用禁止
            Me.KeyPreview = False
                
                
            '@部材期限強制実行が選択されている場合
            If mstrLimitForcedAction = CPstrOne Then
            
                '@実行権限の処理を追加
                lstrFunctionID = CPstrKeyEN02Q1             '機能ID：EN02Q1
                lstrActionID = CPstrUsePeriodOverMaterial   'ｱｸｼｮﾝID：期限超過部材使用
                lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
                lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
                lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
            
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Text, lstrEventName)
                
                '@=======================
                '@ 実行権限ﾁｪｯｸ
                '@=======================
                lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                           lstrActionID, _
                                           lstrEmpID, _
                                           lstrEmpName, _
                                           lstrSBID)
                
                '@画面の使用禁止
                Me.KeyPreview = True
                
                '@結果判定
                If lblnAns = False Then
                    '@権限が"なし"の場合
            
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Text, lstrEventName)
            
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
                    '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                    '@戻り値を"False=権限なし"で設定
                    prvblnAuthority_Chk = False
                    Exit Function
                Else
                    '@権限が"あり"の場合
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Text, lstrEventName)
                    
                    '@戻り値を"True=権限あり"で設定
                    prvblnAuthority_Chk = True
                End If
            End If
            
            
            '@機種限定強制実行が選択された場合
            If mstrPdForcedAction = CPstrOne Then
            
                '@実行権限の処理を追加
                lstrFunctionID = CPstrKeyEN02Q1             '機能ID：EN02Q1
                lstrActionID = CPstrUsePdRestrictMaterial   'ｱｸｼｮﾝID：機種限定部材使用
                lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
                lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
                lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
            
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Text, lstrEventName)
                
                '@=======================
                '@ 実行権限ﾁｪｯｸ
                '@=======================
                lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                           lstrActionID, _
                                           lstrEmpID, _
                                           lstrEmpName, _
                                           lstrSBID)
                
                '@画面の使用禁止
                Me.KeyPreview = True
                
                '@結果判定
                If lblnAns = False Then
                    '@権限が"なし"の場合
            
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Text, lstrEventName)
            
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
                    '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                    '@戻り値を"False=権限なし"で設定
                    prvblnAuthority_Chk = False
                Else
                    '@権限が"あり"の場合
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Text, lstrEventName)
                    
                    '@戻り値を"True=権限あり"で設定
                    prvblnAuthority_Chk = True
                End If
            End If
            
            Exit Function

        Catch ex As Exception

            '@画面の使用禁止解除
            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvblnAuthority_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnSpcRegcollect_Set
    '機　能：装置ﾃﾞｰﾀ登録
    '引　数：mstrLotLastUpdate：
    '戻り値：True:成功、False:失敗
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Function prvblnSpcRegcollect_Set(ByRef mstrLotLastUpdate As String) As Boolean

        Dim lblnAns                 As Boolean              '戻り値
        Dim ltypWfChgCollection     As New WfChgCollection  '装置ﾃﾞｰﾀ格納
        Dim llngCnt1                As Integer              '大ｶｳﾝﾀ
        Dim llngCnt2                As Integer              '中ｶｳﾝﾀ
        Dim llngCnt3                As Integer              '小ｶｳﾝﾀ
        Dim llngDataCnt             As Integer              '実ﾃﾞｰﾀｶｳﾝﾄ
        Dim lstrParameter           As String               'ﾊﾟﾗﾒｰﾀ格納
        
        Try
            
            '@戻り値
            prvblnSpcRegcollect_Set = False
            
            '@ｶｳﾝﾀ初期値
            llngDataCnt = 1
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypWfChgCollection
                
                .strMsgVer = CMstrspc_regcollectVer
                .strSbID = pstrSBID
                .strClassDivision = CPstrCD01
                .strCarrierId = txtCarrier.Text
                .strDataDivision = "LOT"
                .strEmpID = pstrUserID
                .strLotLastUpdate = mstrLotLastUpdate
                .strParameterID = vbNullString
                .strParameterVersion = vbNullString
                .strSlotPosition = vbNullString
                
                If ltypWfChgCollection.typEqWfDataEntry Is Nothing 
                    ltypWfChgCollection.typEqWfDataEntry = New List(Of EqWfDataEntry) 
                Else 
                    ltypWfChgCollection.typEqWfDataEntry.Clear()
                End if

                '@装置ﾃﾞｰﾀ取得
                For llngCnt1 = 0 To ptypChkMaterial.lngMaterialTypeCnt-1
                    
                    For llngCnt2 = 0 To ptypChkMaterial.typMaterialTypeList(llngCnt1).lngMaterialCnt-1
                        
                        For llngCnt3 = 0 To ptypChkMaterial.typMaterialTypeList(llngCnt1).typMaterialIDList(llngCnt2).lngMaterialLotCnt-1
                        
                        '@配列の再定義
                        Dim typEqWfDataEntrytmp As EqWfDataEntry = New EqWfDataEntry 
                        
                        '@ﾃﾞｰﾀ格納
                        typEqWfDataEntrytmp.strDvName = vbNullString
                        
                        lstrParameter = vbNullString
                        If ptypChkMaterial.typMaterialTypeList(llngCnt1).strParameterID <> vbNullString Then
                            lstrParameter = CMstrColon & CMstrColon & CMstrColon & CMstrColon & _
                                    ptypChkMaterial.typMaterialTypeList(llngCnt1).strParameterID & CMstrColon & CMstrColon
                        End If
                        typEqWfDataEntrytmp.strDvNameParameter = lstrParameter
                                
                        typEqWfDataEntrytmp.strDvValue = _
                                ptypChkMaterial.typMaterialTypeList(llngCnt1).typMaterialIDList(llngCnt2).typMaterialLotIDList(llngCnt3).strMaterialLotID
                        
                        '@収集項目ﾀｲﾌﾟは作業開始からは必要ない項目だ(吉田氏より)
                        typEqWfDataEntrytmp.strCollectionType = vbNullString
                        llngDataCnt = llngDataCnt + 1
                        ltypWfChgCollection.typEqWfDataEntry.Add(typEqWfDataEntrytmp)
                        Next
                    Next
                Next
                
                '@ﾃﾞｰﾀ数格納
                .lngEqWfDataEntryCnt = llngDataCnt - 1
            End With

            '@=======================
            '@ 装置ﾃﾞｰﾀ登録
            '@=======================
            lblnAns = pubblnSpcRegCollect_Ins(ltypWfChgCollection, mstrLotLastUpdate)
            
            '@結果判定
            If lblnAns = True Then
                prvblnSpcRegcollect_Set = True
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvblnSpcRegcollect_Set"
                .strErrMessage = vbNullString
            End With
            
            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvControlColor_Init
    '機　能：ｺﾝﾄﾛｰﾙの色の初期化(青色化)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvControlColor_Init()

        Dim llngCnt         As Integer

        Try

            '@ｺﾝﾄﾛｰﾙのﾀｲﾄﾙを青にする
            For llngCnt = 0 To CMlngLabelMaxIndex
                Me.Controls("lblTtl" & llngCnt.ToString).BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            Next

            vsfLot.Styles.Fixed.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            vsfWp.Styles.Fixed.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                    
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvControlColor_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnWorkLotList_Sel
    '機　能：防湿ALD作業作業ﾛｯﾄ一覧取得
    '引　数：lstrLotId
    '　　　：lstrCarrierId
    '戻り値：True：取得成功、False：取得失敗
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Function prvblnWorkLotList_Sel(ByVal lstrLotID As String, _
                                           ByVal lstrCarrierID As String) As Boolean

        Dim lblnAns             As Boolean
        Dim ltypWorkALDLotList  As WorkALDLotList
        

        Try

            '@初期化
            prvblnWorkLotList_Sel = False
            mtypWorkALDLotList = ltypWorkALDLotList
            
            '@=======================
            '@ 防湿ALD作業作業ﾛｯﾄ一覧取得
            '@=======================
            lblnAns = pubblnWorkLotList_Sel(CPstrlot_workaldlotlistVer, _
                                            lstrLotID, _
                                            lstrCarrierID, _
                                            pstrSBID, _
                                            mtypWorkALDLotList)

            If lblnAns = True Then
                prvblnWorkLotList_Sel = True
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnWorkLotList_Sel"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvCmdRegistEnable_Check
    '機　能：確定ﾎﾞﾀﾝ有効ﾁｪｯｸ
    '引　数：
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvCmdRegistEnable_Check(Optional ByVal lctlCaller As Control = Nothing)
        
        Dim llngCnt As Integer
        
        Try
            
            
            '@ｷｬﾘｱIDの入力ﾁｪｯｸ
            If txtCarrier.Text = vbNullString Then
                cmdRegist.Enabled = False
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If Len(txtCarrier.Text) <> CMlngCarrierMaxLength Then
                cmdRegist.Enabled = False
                Exit Sub
            End If
                
            With vsfWp
                '@選択行が0(ﾀｲﾄﾙ以外の場合)
                If .Row <= CMvsfWPTitleRow Then
                    cmdRegist.Enabled = False
                    Exit Sub
                Else
                    '@ﾚｼﾋﾟ
                    If .GetData(.Row, CMvsfWpColRecipe) = vbNullString Then
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                
                End If
            End With
            
            '@ｱﾝﾛｰﾀﾞｷｬﾘｱ有効時
            If txtUnloaderCarrier.Enabled = True Then
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱの入力ﾁｪｯｸ
                If txtUnloaderCarrier.Text = vbNullString Then
                    cmdRegist.Enabled = False
                    Exit Sub
                End If
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDの桁ﾁｪｯｸ
                If Len(txtUnloaderCarrier.Text) <> CMlngCarrierMaxLength Then
                    cmdRegist.Enabled = False
                    Exit Sub
                End If
            End If
            
            '@ACarrier選択
            If cmdACarrierSelect.Enabled = True Then
                If mtypACarrierGroup.lngGroupListCnt <= 0 Then
                    cmdRegist.Enabled = False
                    Exit Sub
                End If
            End If
            
            '@ALD処理
            '@ﾊﾞｯﾁ処理の場合
            If mtypWorkALDLotList.strProcessUnit = CPstrProcessUnit_Batch Then
                For llngCnt = 0 To mtypWorkALDLotList.lngAldWorkLotListCnt - 1
                    '@全ﾛｯﾄが同じALD処理Noであること
                    If mtypWorkALDLotList.typAldWorkLotList(llngCnt).strProcessNum <> mtypWorkALDLotList.strProcessNum Then
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                    
                    '@全Recipeが同じであること
                    'If mtypWorkALDLotList.typAldWorkLotList(llngCnt).strACarrierId <> mtypWorkALDLotList.strProcessNum Then
                    '    Exit Sub
                    'End If
                Next
                
                '@=======================
                '@ ｷｬﾘｱ無判断
                '@=======================
                If cmdACarrierMoQuFdSelect.Enabled = True And mblnACarrierMoQuFd = True Then
                    cmdRegist.Enabled = False
                    Exit Sub
                End If
            End If
            
            '@確定ﾎﾞﾀﾝ有効
            cmdRegist.Enabled = True
                    
            '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
            If lctlCaller Is Nothing Then
                Call pubSetFocus(cmdRegist)
            Else
                Call prvSetFocus(cmdRegist, lctlCaller)
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvCmdRegistEnable_Check"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvItemVisible_Check
    '機　能：Item表示ﾁｪｯｸ
    '引　数：
    '戻り値：
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvItemVisible_Check()
        
        Try
            
            '@初期化(非表示)
            cmdActionDisp.Visible = False
            cmdCommntInput.Visible = False
            cmdRecipeChange.Visible = False
            cmdCollectionInfo.Visible = False
            cmdTrouble.Visible = False
            cmdTreatWF.Visible = False
            cmdTreatChip.Visible = False
            cmdCarrierSelect.Visible = False
            cmdSelectMaterial.Visible = False
            cmdWorkRecord.Visible = False
            cmdACarrierSelect.Visible = False
            cmdACarrierMoQuFdSelect.Visible = False
            cmdLabelScan.Visible = False
            
            '@UnloaderCarrierId
            lblTtl6.Visible = False
            txtUnloaderCarrier.Visible = False
            
            '@作業条件
            lblTtl5.Visible = False
            txtOpeCond.Visible = False
            
            '@次工程送出
            lblTtl7.Visible = False
            optLotNextSend0.Visible = False
            optLotNextSend1.Visible = False
            lblBack1.Visible = False
            
            '@起動区分
            Select Case pstrfrmxxEN2Q0Div
                
                '@作業開始
                Case CPstrCD10
                    cmdActionDisp.Visible = True
                    cmdCommntInput.Visible = True
                    cmdRecipeChange.Visible = True
                    cmdCarrierSelect.Visible = True
                    cmdSelectMaterial.Visible = True
                    cmdACarrierSelect.Visible = True
                    cmdACarrierMoQuFdSelect.Visible = True
                    cmdLabelScan.Visible = True

                    '@UnloaderCarrierId
                    lblTtl6.Visible = True
                    txtUnloaderCarrier.Visible = True
                    
                    '@作業条件
                    lblTtl5.Visible = True
                    txtOpeCond.Visible = True
                    
                '@処理開始
                Case CPstrCD11
                    cmdCommntInput.Visible = True
                                
                    '@作業条件
                    lblTtl5.Visible = True
                    txtOpeCond.Visible = True
                    
                '@処理終了
                Case CPstrCD12
                    cmdCommntInput.Visible = True
                    
                '@作業終了
                Case CPstrCD13
                    cmdActionDisp.Visible = True
                    cmdCommntInput.Visible = True
                    cmdCollectionInfo.Visible = True
                    cmdTrouble.Visible = True
                    cmdTreatWF.Visible = True
                    cmdTreatChip.Visible = True
                    
                    '@次工程送出
                    lblTtl7.Visible = True
                    optLotNextSend0.Visible = True
                    optLotNextSend1.Visible = True
                    lblBack1.Visible = True
                    
                '@その他
                Case Else
                    
            End Select
                    
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvItemVisible_Check"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvItemEnable_Check
    '機　能：Item表示ﾁｪｯｸ
    '引　数：
    '戻り値：
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvItemEnable_Check()
        
        Try
            
            '@初期化
            cmdActionDisp.Enabled = False
            cmdCommntInput.Enabled = False
            cmdRecipeChange.Enabled = False
            cmdCollectionInfo.Enabled = False
            cmdTrouble.Enabled = False
            cmdTreatWF.Enabled = False
            cmdTreatChip.Enabled = False
            cmdCarrierSelect.Enabled = False
            cmdSelectMaterial.Enabled = False
            cmdWorkRecord.Enabled = False
            cmdACarrierSelect.Enabled = False
            cmdACarrierMoQuFdSelect.Enabled = False
            cmdLabelScan.Enabled = True
            
            txtUnloaderCarrier.Enabled = False
            txtUnloaderCarrier.BackColor = SystemColors.ControlLight
            
            optLotNextSend0.Enabled = False
            optLotNextSend1.Enabled = False
             
            '@現品票ﾗﾍﾞﾙ
            If cmdLabelScan.Visible = True Then
                cmdLabelScan.Enabled = True
            End If
             
            '@LOT起因
            If vsfLot.Row > CMvsfLotTitleRow Then
             
                '@ｺﾒﾝﾄ
                If cmdCommntInput.Visible = True Then
                    cmdCommntInput.Enabled = True
                End If
                
                '@作業記録
                If cmdWorkRecord.Visible = True Then
                    cmdWorkRecord.Enabled = True
                End If
                
                '@ﾁｯﾌﾟ状態変更
                If cmdTreatChip.Visible = True Then
                    cmdTreatChip.Enabled = True
                End If
                
                '@WF状態変更
                If cmdTreatWF.Visible = True And lblProcessUnit.Text = CPstrProcessUnitName_Lot Then
                    cmdTreatWF.Enabled = True
                End If
                        
                '@異常処置
                If cmdTrouble.Visible = True Then
                    cmdTrouble.Enabled = True
                End If
                
                '@装置ﾃﾞｰﾀ登録
                If cmdCollectionInfo.Visible = True And _
                    vsfLot.GetData(vsfLot.Row, CMvsfLotColCollectionId) <> vbNullString Then
                    cmdCollectionInfo.Enabled = True
                End If
                
                '@次工程送出(あり)
                If optLotNextSend0.Visible = True Then
                    optLotNextSend0.Enabled = True
                    optLotNextSend0.Checked = True
                End If
                
                '@次工程送出(なし)
                If optLotNextSend1.Visible = True Then
                    optLotNextSend1.Enabled = True
                End If
                                
            End If
            
            '@装置起因
            If vsfWp.Row > CMvsfWPTitleRow Then
                '@ﾚｼﾋﾟ変更
                If lblProcessUnit.Text = CPstrProcessUnitName_Lot And cmdRecipeChange.Visible = True Then
                    cmdRecipeChange.Enabled = True
                End If
                            
                '@ｱｸｼｮﾝ予約
                If vsfWp.GetData(vsfWp.Row, CMvsfWpColActionFlag) = CPstrFlagOn And cmdActionDisp.Visible = True Then
                    cmdActionDisp.Enabled = True
                End If
                
                '@使用部材
                If cmdSelectMaterial.Visible = True Then
                    cmdSelectMaterial.Enabled = True
                End If
                        
                '@装置処理単位(ﾛｯﾄ)
                If lblProcessUnit.Text = CPstrProcessUnitName_Lot Then
                    '@Unloader処理条件の場合
                    If vsfWp.GetData(vsfWp.Row, CMvsfWPColLoaderUnloaderFlag) = CPstrFlagOn Then
                        '@作業開始
                        If pstrfrmxxEN2Q0Div = CPstrCD10 And cmdCarrierSelect.Visible = True Then
                            txtUnloaderCarrier.Enabled = True
                            txtUnloaderCarrier.BackColor = Color.White
                            cmdCarrierSelect.Enabled = True
                        End If
                    End If
                End If
                
                '@検数(投入)装置以外の場合
                If vsfWp.GetData(vsfWp.Row, CMvsfWpColALDProcessNum) <> CPstrALDProcessNum_10 And _
                    cmdLabelScan.Visible = True Then
                    cmdLabelScan.Enabled = False
                End If
                
                '@ﾃｰﾌﾟ貼装置の場合
                If vsfWp.GetData(vsfWp.Row, CMvsfWpColALDProcessNum) = CPstrALDProcessNum_20 And _
                    cmdACarrierSelect.Visible = True Then
                    cmdACarrierSelect.Enabled = True
                End If
                
                '@ALD装置の場合
                If vsfWp.GetData(vsfWp.Row, CMvsfWpColALDProcessNum) = CPstrALDProcessNum_40 And _
                    cmdACarrierMoQuFdSelect.Visible = True Then
                    cmdACarrierMoQuFdSelect.Enabled = True
                End If
                        
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvItemEnable_Check"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnMaterial_Regist
    '機　能：装置使用部材確定
    '引　数：なし
    '戻り値：True:成功、False:失敗
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Function prvblnMaterial_Regist() As Boolean

        Dim lblnAns             As Boolean
        Dim lblnChkFlag         As Boolean
        Dim llngCnt             As Integer
        Dim llngCnt2            As Integer
        Dim lstrEventName       As String
        Dim ltypMaterialList    As MaterialWPList


        Try
            
            lstrEventName = "prvblnMaterial_Regist"
            
            prvblnMaterial_Regist = False

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Text, lstrEventName)

            '@=======================
            '@ 装置使用部材情報取得
            '@=======================
            lblnAns = pubblnMatMaterialList_Sel(CMstrmat_materiallistVer, _
                                                vsfWp.GetData(vsfWp.Row, CMvsfWPColWpID), _
                                                ltypMaterialList)
                
            
            '@結果判定
            If lblnAns = False Then
                    
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Text, lstrEventName)
                Exit Function
                
            Else
                    
                '@部材種別に対して1部材が最低選択されているかのﾁｪｯｸ
                    
                '@ﾁｪｯｸﾌﾗｸﾞ,汎用ｶｳﾝﾀの初期化
                lblnChkFlag = False
                    
                With ltypMaterialList
                        
                    For llngCnt = 0 To .lngMaterialTypeCnt - 1
                            
                        With .typMaterialTypeList(llngCnt)
                                
                            For llngCnt2 = 0 To ptypChkMaterial.lngMaterialTypeCnt - 1
                                    
                                '@構造体の部材種別とｸﾞﾘｯﾄﾞに表示されている部材種別が同じ場合
                                If .strMaterialTypeID = ptypChkMaterial.typMaterialTypeList(llngCnt2).strMaterialTypeID Then
                                        
                                    lblnChkFlag = True
                                    Exit For
                                Else
                                    lblnChkFlag = False
                                End If
                            Next llngCnt2
                                
                            '@ﾁｪｯｸﾌﾗｸﾞをFalse(=未選択)
                            If lblnChkFlag = False Then
                            
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(Me.Text, lstrEventName)
                            
                                '@表示ﾒｯｾｰｼﾞ変換
                                '@「"<TRM8DW>$$選択されていない部材が存在します。$1つの部材種別に対し、最低1つ部材を選択してください。"」のﾒｯｾｰｼﾞ表示
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008D)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    
                                '@使用部材選択ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(cmdSelectMaterial)
                                Exit Function
                            End If
                        End With
                    Next
                End With
            
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Text, lstrEventName)
            End If
                
            '@=======================
            '@ 装置使用部材判定＆権限ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnChgMaterial_Chk
                
            '@使用部材判定＆権限ﾁｪｯｸ処理の戻り値を判定
            If lblnAns = False Then
                '@処理中断 or 権限なしの場合
                    
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Text, lstrEventName)
                Exit Function
            End If

            prvblnMaterial_Regist = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvblnMaterial_Regist"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvWorkStart
    '機　能：確定(作業開始)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvWorkStart()
        
        Dim lblnAns             As Boolean          '結果取得(True:正常,False:異常)
        Dim ltypLotwrkstart     As Lotwrkstart      'ﾛｯﾄ作業開始構造体
        Dim lstrActionFlag      As String           'ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ(0:実行なし、1:停止、２:保留)
        Dim lstrToOpID          As String           '制限時間先大工程
        Dim lstrToStepID        As String           '制限時間先小工程
        Dim lstrLimitTime       As String           '制限時間
        Dim lstrWarnTime        As String           '警告時間
        Dim llngAns             As String           '警告時間ﾁｪｯｸ結果


        Try
            
            '@***********************
            '@ 作業開始ﾃﾞｰﾀ格納
            '@***********************
            With ltypLotwrkstart
                .strLotID = vsfLot.GetData(vsfLot.Row, CMvsfLotColLotID)
                .strOpID = vsfLot.GetData(vsfLot.Row, CMvsfLotColOpID)
                .strStepID = vsfLot.GetData(vsfLot.Row, CMvsfLotColStepID)
                .strWpID = vsfWp.GetData(vsfWp.Row, CMvsfWPColWpID)
                .strEngEmpId = pstrUserID
                .strLotLastUpdate = vsfLot.GetData(vsfLot.Row, CMvsfLotColEditTime)
                .strComments = txtWorkMemo.Text
                .strAltNumber = CMlngAltNum
                .strToCarriaID = txtUnloaderCarrier.Text
                .strLoaderUnloaderFlag = vsfWp.GetData(vsfWp.Row, CMvsfWPColLoaderUnloaderFlag)
            End With

            '@=======================
            '@ ﾛｯﾄ作業開始登録(処理区分：3B)
            '@=======================
            lblnAns = pubblnLotStart_Ins(CMstrlot_wrkstartVer, _
                                         ltypLotwrkstart, _
                                         lstrActionFlag, _
                                         lstrToOpID, _
                                         lstrToStepID, _
                                         lstrLimitTime, _
                                         lstrWarnTime, _
                                         mstrLotLastUpdate, _
                                         CPstrCD3B)
            
            '@結果判定
            If lblnAns = True Then
            
                '@引継ぎ構造体の代替番号が空白以外の場合
                If ptypCommonInfo.strAltPointer <> vbNullString Then
                    '@装置別ﾛｯﾄ一覧で、「作業待ち」以外のﾛｯﾄは代替番号が空白で返ってくる為、引継ぎ構造体の代替番号もｸﾘｱする
                    ptypCommonInfo.strAltPointer = vbNullString
                End If
                
                '@=======================
                '@ 引継構造体のｷｬﾘｱIDとｱﾝﾛｰﾀﾞｰ側ｷｬﾘｱIDの入れ替えを行う
                '@=======================
                Call prvHandWork_Set()
                
                '@制限時間超過の警告が発生している場合
                If lstrToOpID <> vbNullString Or lstrToStepID <> vbNullString Or lstrLimitTime <> vbNullString Then
                    
                    '@制限時間以下の場合
                    If mtypLotprestate(mlngCurrentLotRowNo).strRestrictTypeID = CMstrRestrictTypeID1 Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM3BW>$$ロット[xxx]は[xxx xxx]までの工程において制限時間を経過しています。処理を継続しますか？"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003F, ltypLotwrkstart.strLotID, lstrToOpID, lstrToStepID)
                        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                         
                        '@ﾒｯｾｰｼﾞBOXにて「いいえ」が選択されたか
                        If llngAns = vbNo Then
                            
                            '@処理をｷｬﾝｾﾙする
                        
                        Else
                            '@「はい」が選択された場合
                            
                            '@=======================
                            '@ ﾛｯﾄ作業開始登録(処理区分：02)
                            '@=======================
                            lblnAns = pubblnLotStart_Ins(CMstrlot_wrkstartVer, _
                                                         ltypLotwrkstart, _
                                                         lstrActionFlag, _
                                                         lstrToOpID, _
                                                         lstrToStepID, _
                                                         lstrLimitTime, _
                                                         lstrWarnTime, _
                                                         mstrLotLastUpdate, _
                                                         CPstrCD02)

                            '@結果判定
                            If lblnAns = True Then
                                
                                '@使用部材が存在する場合
                                If ptypChkMaterial.lngMaterialTypeCnt > 0 Then
                                    
                                    '@=======================
                                    '@ 使用部材を作業記録へ反映
                                    '@=======================
                                    lblnAns = prvblnSpcRegcollect_Set(mstrLotLastUpdate)
                                    
                                    '@登録ｴﾗｰの場合
                                    If lblnAns = False Then
                                                                        
                                        '@表示ﾒｯｾｰｼﾞ変換
                                        '@"<TRM97W>$$使用部材を作業記録へ登録に失敗しました。"
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0097)
                                        
                                        '@ﾒｯｾｰｼﾞ表示
                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                    End If
                                End If
                                
                                '@Unloaderｷｬﾘｱの入力判定(Unloaderｷｬﾘｱの入力可否にて表示ﾒｯｾｰｼﾞを切替)
                                If txtUnloaderCarrier.Text = vbNullString Then
                                    '@表示ﾒｯｾｰｼﾞ変換(UNI装置用)
                                    
                                    '@"<TRM05I>$$作業を開始しました。キャリア[ %1 ] ロット[ %2 ]"
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0005, txtCarrier.Text, ltypLotwrkstart.strLotID)
                                Else

                                    '@表示ﾒｯｾｰｼﾞ変換(L/N装置用)
                                        
                                    '@"<TRM0TI>$$作業を開始しました。キャリア[ %1 ] ロット[ %2 ] Unloaderキャリア[ %3 ]"
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000T, txtCarrier.Text, ltypLotwrkstart.strLotID, txtUnloaderCarrier.Text)

                                End If
                                
                                '@成功ﾒｯｾｰｼﾞ表示
                                Call pubVsfInfo_Disp(pstrDMsg)
                                
                                '@ｷｬﾘｱIDのｸﾘｱ
                                txtCarrier.Text = vbNullString
                                
                                '@=======================
                                '@ 各種初期化処理(画面内ｺﾝﾄﾛｰﾙ、変数等)
                                '@=======================
                                Call prvfrmxxEN02Q0_Init()
                                'NSYS グリッド非活性
                                VsfLot.Enabled = False
                                vsfWP.Enabled = False
                                
                            End If
                        End If
                    End If
                    
                    '@制限時間以下の場合
                    If mtypLotprestate(mlngCurrentLotRowNo).strRestrictTypeID = CMstrRestrictTypeID2 Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM3IW>$$ロット[xxx]は[xxx xxx]までの工程において制限時間を経過していません。処理を継続しますか？"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003I, ltypLotwrkstart.strLotID, lstrToOpID, lstrToStepID)
                        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                         
                        '@要求確認
                        If llngAns = vbNo Then
                            '@ｷｬﾝｾﾙする
                        Else
                            '@「はい」が選択された場合
                            
                            '@=======================
                            '@ ﾛｯﾄ作業開始登録(処理区分：02)
                            '@=======================
                            lblnAns = pubblnLotStart_Ins(CMstrlot_wrkstartVer, _
                                                         ltypLotwrkstart, _
                                                         lstrActionFlag, _
                                                         lstrToOpID, _
                                                         lstrToStepID, _
                                                         lstrLimitTime, _
                                                         lstrWarnTime, _
                                                         mstrLotLastUpdate, _
                                                         CPstrCD02)

                            '@結果判定
                            If lblnAns = True Then
                            
                                '@使用部材が存在する場合
                                If ptypChkMaterial.lngMaterialTypeCnt > 0 Then
                                    
                                    '@=======================
                                    '@ 使用部材を作業記録へ反映
                                    '@=======================
                                    lblnAns = prvblnSpcRegcollect_Set(mstrLotLastUpdate)
                                    
                                    '@登録ｴﾗｰの場合
                                    If lblnAns = False Then
                                        '@表示ﾒｯｾｰｼﾞ変換
                                        '@「"<TRM97W>$$使用部材を作業記録へ登録に失敗しました。"」のﾒｯｾｰｼﾞ表示
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0097)
                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    End If
                                End If
                            
                                '@Unloaderｷｬﾘｱの入力判定(Unloaderｷｬﾘｱの入力可否にて表示ﾒｯｾｰｼﾞを切替)
                                If txtUnloaderCarrier.Text = vbNullString Then
                                    '@表示ﾒｯｾｰｼﾞ変換(UNI装置用)
                                    
                                    '@"<TRM05I>$$作業を開始しました。キャリア[ %1 ] ロット[ %2 ]"
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0005, txtCarrier.Text, ltypLotwrkstart.strLotID)
                                Else

                                    '@表示ﾒｯｾｰｼﾞ変換(L/N装置用)
                                        
                                    '@"<TRM0TI>$$作業を開始しました。キャリア[ %1 ] ロット[ %2 ] Unloaderキャリア[ %3 ]"
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000T, txtCarrier.Text, ltypLotwrkstart.strLotID, txtUnloaderCarrier.Text)
                                End If
                                
                                '@成功ﾒｯｾｰｼﾞ表示
                                Call pubVsfInfo_Disp(pstrDMsg)

                                '@ｷｬﾘｱIDのｸﾘｱ
                                txtCarrier.Text = vbNullString
                                
                                '@=======================
                                '@ 各種初期化処理(画面内ｺﾝﾄﾛｰﾙ、変数等)
                                '@=======================
                                Call prvfrmxxEN02Q0_Init()
                                'NSYS グリッド非活性
                                VsfLot.Enabled = False
                                vsfWP.Enabled = False
                                
                            End If
                        End If
                    End If
                Else
                    '@制限時間が超過していない場合
                    
                    '@使用部材が存在する場合
                    If ptypChkMaterial.lngMaterialTypeCnt > 0 Then
                        '@=======================
                        '@ 使用部材を作業記録へ反映
                        '@=======================
                        lblnAns = prvblnSpcRegcollect_Set(mstrLotLastUpdate)
                        
                        '@登録ｴﾗｰの場合
                        If lblnAns = False Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM97W>$$使用部材を作業記録へ登録に失敗しました。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0097)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        End If
                    End If
                    
                    '@Unloaderｷｬﾘｱの入力判定(Unloaderｷｬﾘｱの入力可否にて表示ﾒｯｾｰｼﾞを切替)
                    If txtUnloaderCarrier.Text = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換(UNI装置用)
                        '@"<TRM05I>$$作業を開始しました。キャリア[ %1 ] ロット[ %2 ]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0005, txtCarrier.Text, ltypLotwrkstart.strLotID)
                    Else
                        '@表示ﾒｯｾｰｼﾞ変換(L/N装置用)
                        '@"<TRM0TI>$$作業を開始しました。キャリア[ %1 ] ロット[ %2 ] Unloaderキャリア[ %3 ]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000T, txtCarrier.Text, ltypLotwrkstart.strLotID, txtUnloaderCarrier.Text)
                    End If

                    '@成功ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    '@ｷｬﾘｱIDのｸﾘｱ
                    txtCarrier.Text = vbNullString
                    
                    '@=======================
                    '@ 各種初期化処理(画面内ｺﾝﾄﾛｰﾙ、変数等)
                    '@=======================
                    Call prvfrmxxEN02Q0_Init()
                    'NSYS グリッド非活性
                    VsfLot.Enabled = False
                    vsfWP.Enabled = False
                    
                End If
            End If
                                
            '@=======================
            '@ 防湿ALDﾚｼﾋﾟ作成要求(eqsvr(ftppol)へ送信)
            '@=======================
            lblnAns = pubblnAldMakeRecipe_Upd(ltypLotwrkstart.strWpID)

            '@登録ｴﾗｰの場合
            If lblnAns = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM02E>$$レシピファイル作成に失敗しました。$システム担当者に連絡してください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0002)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            End If
            
            '@ﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvWorkStart"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvProcStart
    '機　能：確定(処理開始)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvProcStart()
        
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotprcstart         As Lotprcstart          'ﾛｯﾄ処理開始構造体
        Dim lstrToOpID              As String               '制限時間先大工程
        Dim lstrToStepID            As String               '制限時間先小工程
        Dim lstrLimitTime           As String               '制限時間
        Dim lstrWarnTime            As String               '警告時間
        Dim llngAns                 As String               '警告時間ﾁｪｯｸ結果
        Dim lstrRecipID             As String               'ﾚｼﾋﾟID(lot_.prcstartの応答)
        Dim lstrPolTime             As String               '研磨時間(lot_.prcstartの応答)
        Dim lstrPlcResult           As String               'PLCﾚｼﾋﾟ照合結果


        Try
                                                   
            '@処理開始ﾃﾞｰﾀ格納
            With ltypLotprcstart
                .strLotID = vsfLot.GetData(vsfLot.Row, CMvsfLotColLotID)
                .strOpID = vsfLot.GetData(vsfLot.Row, CMvsfLotColOpID)
                .strStepID = vsfLot.GetData(vsfLot.Row, CMvsfLotColStepID)
                .strWpID = vsfWp.GetData(vsfWp.Row, CMvsfWPColWpID)
                .strEngEmpId = pstrUserID
                .strLotLastUpdate = vsfLot.GetData(vsfLot.Row, CMvsfLotColEditTime)
                .strEQFlag = CMlngEqFlag
                .strComment = txtWorkMemo.Text
                .strPortID = CMstrLoaderPortNum
                
                '@L/UL装置の場合
                If vsfWp.GetData(vsfWp.Row, CMvsfWPColLoaderUnloaderFlag) = CPstrFlagOn Then
                    .strToPortID = CMstrUnloaderPortNum
                Else
                    .strToPortID = vbNullString
                End If
                        
            End With

            '@ﾒｯｾｰｼﾞ送信処理呼び出し:処理開始要求(処理区分：013B)
            lblnAns = pubblnLotPrcstart_Ins(CMstrlot_prcstartVer, _
                                            CPstrCD01 & CPstrCD3B, _
                                            ltypLotprcstart, _
                                            lstrToOpID, _
                                            lstrToStepID, _
                                            lstrLimitTime, _
                                            lstrWarnTime, _
                                            lstrRecipID, _
                                            lstrPolTime, _
                                            lstrPlcResult)
            '@結果判定
            If lblnAns = True Then
                
                '@制限時間超過の警告が発生している場合
                If lstrToOpID <> vbNullString Or lstrToStepID <> vbNullString Or lstrLimitTime <> vbNullString Then
                                
                    '@制限時間以下の場合
                    If mtypLotprestate(mlngCurrentLotRowNo).strRestrictTypeID = CMstrRestrictTypeID1 Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003F, ltypLotprcstart.strLotID, lstrToOpID, lstrToStepID)
                        
                        '@"<TRM3BW>$$ロット[xxx]は[xxx xxx]までの工程において制限時間を経過しています。処理を継続しますか？"
                        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                        '@要求確認
                        If llngAns = vbNo Then
                            '@ｷｬﾝｾﾙする
                        Else
                        '@「はい」が選択された場合
                            
                            '@ﾒｯｾｰｼﾞ送信処理呼び出し(処理区分：0102)
                            lblnAns = pubblnLotPrcstart_Ins(CMstrlot_prcstartVer, _
                                                            CPstrCD01 & CPstrCD02, _
                                                            ltypLotprcstart, _
                                                            lstrToOpID, _
                                                            lstrToStepID, _
                                                            lstrLimitTime, _
                                                            lstrWarnTime, _
                                                            lstrRecipID, _
                                                            lstrPolTime, _
                                                            lstrPlcResult)
                            
                            '@結果判定
                            If lblnAns = True Then
                                
                                '@表示ﾒｯｾｰｼﾞ変換(UNI装置用)"<TRM18I>$$処理を開始しました。キャリア[ %1 ] ロット[ %2 ]"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0018, txtCarrier.Text, ltypLotprcstart.strLotID)
                                
                                '@成功ﾒｯｾｰｼﾞ表示
                                Call pubVsfInfo_Disp(pstrDMsg)
                                
                                '@Loader/Unloaderの場合
                                ptypCommonInfo.strToCarrierId = vsfLot.GetData(vsfLot.Row, CMvsfLotColToCarrierId)
                                
                                '@ﾛｯﾄ情報の初期化
                                Call prvfrmxxEN02Q0_Init()
                                'NSYS グリッド非活性
                                VsfLot.Enabled = False
                                vsfWP.Enabled = False
                                
                            End If
                        End If
                    End If
                    
                    '@制限時間以下の場合
                    If mtypLotprestate(mlngCurrentLotRowNo).strRestrictTypeID = CMstrRestrictTypeID2 Then
                        '@表示ﾒｯｾｰｼﾞ変換
                         pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003I, ltypLotprcstart.strLotID, lstrToOpID, lstrToStepID)
                         '@"<TRM3IW>$$ロット[xxx]は[xxx xxx]までの工程において制限時間を経過していません。処理を継続しますか？"
                         llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                        
                        '@要求確認
                        If llngAns = vbNo Then
                            '@ｷｬﾝｾﾙする
                        Else
                        '@「はい」が選択された場合
                            
                            '@ﾒｯｾｰｼﾞ送信処理呼び出し(処理区分：0102)
                            lblnAns = pubblnLotPrcstart_Ins(CMstrlot_prcstartVer, _
                                                            CPstrCD01 & CPstrCD02, _
                                                            ltypLotprcstart, _
                                                            lstrToOpID, _
                                                            lstrToStepID, _
                                                            lstrLimitTime, _
                                                            lstrWarnTime, _
                                                            lstrRecipID, _
                                                            lstrPolTime, _
                                                            lstrPlcResult)
                            
                            '@結果判定
                            If lblnAns = True Then
                                
                                '@表示ﾒｯｾｰｼﾞ変換(UNI装置用)"<TRM18I>$$処理を開始しました。キャリア[ %1 ] ロット[ %2 ]"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0018, txtCarrier.Text, ltypLotprcstart.strLotID)
                                
                                '@成功ﾒｯｾｰｼﾞ表示
                                Call pubVsfInfo_Disp(pstrDMsg)
                            
                                '@Loader/Unloaderの場合
                                ptypCommonInfo.strToCarrierId = vsfLot.GetData(vsfLot.Row, CMvsfLotColToCarrierId)
                                
                                '@ﾛｯﾄ情報の初期化
                                Call prvfrmxxEN02Q0_Init()
                                'NSYS グリッド非活性
                                VsfLot.Enabled = False
                                vsfWP.Enabled = False
                                
                            End If
                        End If
                    End If
                
                
                '@制限時間が超過していない場合
                Else
                
                    '@表示ﾒｯｾｰｼﾞ変換(UNI装置用)"<TRM18I>$$処理を開始しました。キャリア[ %1 ] ロット[ %2 ]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0018, txtCarrier.Text, ltypLotprcstart.strLotID)
                    
                    '@成功ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    '@Loader/Unloaderの場合
                    ptypCommonInfo.strToCarrierId = vsfLot.GetData(vsfLot.Row, CMvsfLotColToCarrierId)
                
                    '@ﾛｯﾄ情報の初期化
                    Call prvfrmxxEN02Q0_Init()
                    'NSYS グリッド非活性
                    VsfLot.Enabled = False
                    vsfWP.Enabled = False
                    
                End If
            End If
            
            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvProcStart"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvProcEnd
    '機　能：確定(処理終了)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvProcEnd()

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrPlcResult           As String               'PLCﾚｼﾋﾟ照合結果

            
        Try
            
            '@ﾛｯﾄ処理終了ﾒｯｾｰｼﾞ送信(最終更新日時は、確定時に返される値を使う。ﾒｯｾｰｼﾞ関数内で書き換えている。)
            lblnAns = pubblnLotProcend_Upd(CMstrlot_procend_Ver, _
                                           CPstrCD01, _
                                           vsfLot.GetData(vsfLot.Row, CMvsfLotColLotID), _
                                           pstrUserID, _
                                           txtWorkMemo.Text, _
                                           vsfLot.GetData(vsfLot.Row, CMvsfLotColEditTime), _
                                           lstrGuidMsg, _
                                           lstrGuidMsgCode, _
                                           lstrPlcResult)


            '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If
                        
            '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞに値が入っている場合
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
            
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0019, txtCarrier.Text, vsfLot.GetData(vsfLot.Row, CMvsfLotColLotID))
                
            '@pubVsfInfo_Disp("メッセージコード：C_I19%0$$処理を終了しました。キャリア[ %1 ] ロット[ %2 ]")
            Call pubVsfInfo_Disp(pstrDMsg)
                                         
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN02Q0_Init()
            'NSYS グリッド非活性
            VsfLot.Enabled = False
            vsfWP.Enabled = False
            
            '@ｷｬﾘｱIDにﾌｫｰｶｽをｾｯﾄ
            Call pubSetFocus(txtCarrier)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvProcEnd"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWorkEnd
    '機　能：確定(作業終了)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    Private Sub prvWorkEnd()
        
        Dim lblnAns                     As Boolean              '結果取得(True:正常,False:異常)
        Dim lblnAnsNextSend             As Boolean              '次工程取得結果格納
        Dim ltypLotwrkend               As LotwrkEnd            'ﾛｯﾄ作業終了構造体
        Dim lstrActionFlag              As String               'ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ(0:実行なし、1:停止、２:保留)
        Dim lstrResultReworkState       As String               '特殊流動状態(3桁で制御
                                                                '    百の位：0；特殊流動無/1；部分特殊流動/2;全数特殊流動
                                                                '    十の位：0；分割元の次工程無/1；分割元の次工程有
                                                                '    一の位：0；分割先(or全数)の次工程無/1；分割先(or全数)の次工程有
        Dim lstrMoveResult              As String               '移載状態(0：移載なし、1：移載前、2：移載完了)
        Dim lstrNextActionFlag          As String               '次工程ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ(0:実行なし、1:停止、2:保留)
        Dim lstrSendResult              As String               '次工程送出結果格納(Null:次工程送出/0:中間在庫/1:完成在庫/2:組立送品)
        Dim lstrToCarrierID             As String               '特殊流動分割元ｷｬﾘｱID
        Dim lblnCtlAns                  As Boolean              'CtlSvr2結果取得(True:正常,False:異常)
        Dim ltypCtlUpdWaitingLotList    As CtlUpWaitingLot      'CtlSvr2送信構造体
        Dim ltypSpcJudge                As SpcJudge             'SPC規格値判定構造体
        Dim lblnSpcSpecchkAns           As Boolean              'SPC規格値判定結果
        Dim lstrGuidMsg                 As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode             As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance            As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrEleHoldFlag             As String               '電特保留ﾌﾗｸﾞ
        Dim lstrTftHoldFlag             As String               'TFT保留ﾌﾗｸﾞ
        Dim lstrExcpHoldFlag            As String               '異常処理票保留(0：未保留、1：保留)
        Dim lstrNormalHoldFlag          As String               '通常保留(0：未保留、1：保留)
        Dim ltypLotCfkiMoveAns          As LotCfkiMoveAns       'CFKI作業入力要求応答構造体
        Dim lstrComment                 As String               '次行程送出結果のｺﾒﾝﾄ格納

        Try
            
            '@**************************************************
            '@装置ﾃﾞｰﾀ(FTP同期)
            '@**************************************************
            '@FTP同期の場合
            If vsfWp.GetData(vsfWp.Row, CMvsfWpColFtpDataFlag) = CPstrFtpDataFlagOn Then
                
                '@ｵﾌﾗｲﾝFTPﾃﾞｰﾀ同期処理【lstrFTPResult:FTP送信結果】
                'lblnAns = prvblnEqftSyncRegist_Proc(lstrFTPResult, lstrWfFlag)
                '
                '@結果判定
                'If lblnAns = False Then
                '    '@ｴﾗｰの場合 (ここでは通信ｴﾗｰ等)
                '    '@FTPｻｰﾊﾞｰが死んでる場合(CLのﾛｸﾞにも出力します。)又は
                '    '@FTP送信結果がNGの場合でも作業終了続行する。
                '    '@WFﾘｽﾄが取得できない場合は致命的なｴﾗｰの為以降の処理はSTOP
                '    lstrFTPResult = CMstrNG
                '
                '    '@致命的なｴﾗｰが発生した場合(WFﾘｽﾄが取得できない)
                '    If lstrWfFlag = CMstrNG Then
                '        Exit Sub
                '    End If
                'End If
            End If
            
            '@**************************************************
            '@作業終了
            '@**************************************************
            '@作業終了ﾃﾞｰﾀ格納
            With ltypLotwrkend
                .strLotID = vsfLot.GetData(vsfLot.Row, CMvsfLotColLotID)
                .strOpID = vsfLot.GetData(vsfLot.Row, CMvsfLotColOpID)
                .strStepID = vsfLot.GetData(vsfLot.Row, CMvsfLotColStepID)
                .strEngEmpId = pstrUserID
                .strComment = txtWorkMemo.Text
                .strLotLastUpdate = vsfLot.GetData(vsfLot.Row, CMvsfLotColEditTime)
            End With

            '@=======================
            '@作業終了処理
            '@=======================
            lblnAns = pubblnLotWrkend_Upd(CMstrlot_wrkendVer, _
                                          ltypLotwrkend, _
                                          lstrActionFlag, _
                                          lstrEleHoldFlag, _
                                          lstrResultReworkState, _
                                          CPstrCD23, _
                                          lstrGuidMsg, _
                                          lstrGuidMsgCode, _
                                          lstrTftHoldFlag, _
                                          lstrExcpHoldFlag, _
                                          lstrNormalHoldFlag, _
                                          ltypLotCfkiMoveAns, _
                                          lstrMoveResult, _
                                          lstrToCarrierID)
                                          
             '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If
                        
            '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞに値が入っている場合
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

            '@成功ﾒｯｾｰｼﾞ格納
            '@表示ﾒｯｾｰｼﾞ変換"メッセージコード：C_I13%0$$作業を終了しました。キャリア[ %1 ] ロット[ %2 ]"
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0013, txtCarrier.Text, ltypLotwrkend.strLotID)
            '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
            Call pubVsfInfo_Disp(pstrDMsg)
            
            
            '@**************************************************
            '@SPC判定
            '@**************************************************
            '@構造体に情報をｾｯﾄする
            With ltypSpcJudge
                .strMsgVer = CMstrspc_judge___Ver               'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strLotID = vsfLot.GetData(vsfLot.Row, CMvsfLotColLotID)
                .strOpID = vsfLot.GetData(vsfLot.Row, CMvsfLotColOpID)
                .strStepID = vsfLot.GetData(vsfLot.Row, CMvsfLotColStepID)
                .strEmpID = pstrUserID                          '作業者ID
                .strNextLotID = ltypLotwrkend.strLotID          '作業終了後ﾛｯﾄID
            End With

            '@=======================
            '@ SPC判定
            '@=======================
            lblnSpcSpecchkAns = pubblnSpcJudge_Sel(ltypSpcJudge)

            '@SPC規格値判定ﾒｯｾｰｼﾞ送信処理の戻り値の判定
            If lblnSpcSpecchkAns = False Then
                Exit Sub
            End If
                                                  
            '@**************************************************
            '@次工程送出不可ﾒｯｾｰｼﾞ表示
            '@ｱｸｼｮﾝ予定実行ﾌﾗｸﾞ判定
            '@異常処理票保留、通常保留
            '@SPC規格値判定
            '@**************************************************
            If prvNextNgMsg_Disp(ltypLotwrkend.strLotID, lstrActionFlag, lstrExcpHoldFlag, lstrNormalHoldFlag, ltypSpcJudge) = True Then
                Exit Sub
            End If
                
            '@**************************************************
            '@次工程送出前ﾁｪｯｸ
            '@**************************************************
            '@ｱｸｼｮﾝ予定実行なし
            '@SPC規格値判定結果が「正常」「SPC異常」
            '@全保留なし(電特保留、TFT保留、異常処理票保留、通常保留)
            
            '@ｱｸｼｮﾝ予約
            If lstrActionFlag <> CPstrActionFlag0 Then
                Exit Sub
            End If

            '@SPC
            If Not (ltypSpcJudge.strSpecCheck = CMstrSpecCheckOK Or ltypSpcJudge.strSpecCheck = CMstrSpecCheckSPCNG) Then
                Exit Sub
            End If

            '@その他保留
            If Not (lstrExcpHoldFlag = CPstrHold0 And lstrNormalHoldFlag = CPstrHold0) Then
                Exit Sub
            End If
            
            '@**************************************************
            '@次工程送出
            '@**************************************************
            '@自動送信「あり」の場合
            If optLotNextSend0.Checked = True Then

                '@最終工程の場合
                If vsfWp.GetData(vsfWp.Row, CMvsfWpColNextOpId) = vbNullString And _
                    vsfWp.GetData(vsfWp.Row, CMvsfWpColNextStepId) = vbNullString Then
                
                    '@=======================
                    '@ 次工程送出
                    '@=======================
                    lblnAnsNextSend = pubblnLotNextSend_Upd(CMstrlot_nextSendVer, _
                                                            ltypLotwrkend.strLotID, _
                                                            ltypLotwrkend.strLotLastUpdate, _
                                                            pstrUserID, _
                                                            CPstrEnableFlagFalse, _
                                                            CPstrCD24, _
                                                            , _
                                                            , _
                                                            , _
                                                            lstrNextActionFlag, _
                                                            lstrEleHoldFlag, _
                                                            lstrSendResult, _
                                                            lstrTftHoldFlag)


                    '@結果判定
                    If lblnAnsNextSend = False Then
                        '@「次工程送出に失敗しました。メニューの次工程送出から再度実行して下さい。」
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000E)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                        Exit Sub
                    End If
                    
                    '@完成時ﾒｯｾｰｼﾞ取得
                    Call pubLotNextSendResultPopUp(lstrSendResult, txtCarrier.Text, ltypLotwrkend.strLotID)
                    
                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)


                '@最終工程ではない場合
                Else
                    
                    '@=======================
                    '@ 次工程送出
                    '@=======================
                    lblnAnsNextSend = pubblnLotNextSend_Upd(CMstrlot_nextSendVer, _
                                                            ltypLotwrkend.strLotID, _
                                                            ltypLotwrkend.strLotLastUpdate, _
                                                            pstrUserID, _
                                                            CPstrEnableFlagFalse, _
                                                            , _
                                                            , _
                                                            lstrComment, _
                                                            , _
                                                            lstrNextActionFlag, _
                                                            lstrEleHoldFlag, _
                                                            lstrSendResult, _
                                                            lstrTftHoldFlag)
                    

                    '@結果判定
                    If lblnAnsNextSend = False Then
                                    
                        '@「次工程送出に失敗しました。メニューの次工程送出から再度実行して下さい。」
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000E)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        Exit Sub
                    End If
                    
                    '@次工程送出結果格納(Null:次工程送出/0:中間在庫/1:完成在庫/2:組立送品)
                    If lstrSendResult <> vbNullString Then
                        Exit Sub
                    End If
                    
                    '@更新処理の為送信構造体に状態をｾｯﾄする
                    With ltypCtlUpdWaitingLotList
                        .strClassDivision = CPstrCD01               '処理区分(=01)
                        .strMsgVer = CMstrctl_updwaitinglotVer      'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                        .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strWpID = vbNullString                     'WPID(=vbNullString)
                        .lngWaitingLotListCnt = 1                   'ﾘｽﾄｶｳﾝﾄ(=1)
                        .typWaitingLotList = New List(Of UpWaitingLotList)(.lngWaitingLotListCnt)

                        Dim ltypUpWaitingLotListTmp As New UpWaitingLotList
                                                            
                        '@作業終了Msgの応答LotIDを設定
                        ltypUpWaitingLotListTmp.strLotID = vsfLot.GetData(vsfLot.Row, CMvsfLotColLotID)
                        ltypUpWaitingLotListTmp.strOpID = vsfLot.GetData(vsfLot.Row, CMvsfLotColOpID)
                        ltypUpWaitingLotListTmp.strStepID = vsfLot.GetData(vsfLot.Row, CMvsfLotColStepID)
                        ltypUpWaitingLotListTmp.strSeqNum = vbNullString

                        .typWaitingLotList.Add(ltypUpWaitingLotListTmp)
                    End With
                    
                    '@=======================
                    '@ 処理待ちﾛｯﾄ更新処理
                    '@=======================
                    lblnCtlAns = pubblnCtlUpdWaitingLot_Upd(ltypCtlUpdWaitingLotList)
                        
                    '@結果判定
                    If lblnCtlAns = False Then
                        Exit Sub
                    End If
                                                    
                    '@ｺﾒﾝﾄは空か
                    If lstrComment = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換"<TRM23I>$$次工程送出しました。キャリア[ %1 ] ロット[ %2 ]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0023, txtCarrier.Text, ltypLotwrkend.strLotID)
                        Call pubVsfInfo_Disp(pstrDMsg)

                    Else
                        '@ﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(lstrComment)
                        Call pubVsfInfo_Disp(pstrDMsg)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If
                                                    
                    '@装置別ﾛｯﾄ一覧より呼ばれている場合、次工程送出にて装置ID、大工程、小工程が変わる為
                    '@引継ぎ構造体よりｸﾘｱする。
                    With ptypCommonInfo
                        .strWpID = vbNullString
                        .strWpName = vbNullString
                        .strOpID = vbNullString
                        .strStepID = vbNullString
                    End With
                                                                               
                    '@ｱｸｼｮﾝﾌﾗｸﾞによる分岐
                    Select Case lstrNextActionFlag
                                                    
                        '@停止の場合
                        Case CPstrActionFlag1
                            '@表示ﾒｯｾｰｼﾞ変換"<TRM2SI>$$アクション予約によりロット[ %1 ] は [停止] されました。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, ltypLotwrkend.strLotID, CPstrStopSt)
                            Call pubVsfInfo_Disp(pstrDMsg)
                                                        
                        '@保留の場合
                        Case CPstrActionFlag2
                            '@表示ﾒｯｾｰｼﾞ変換"<TRM2SI>$$アクション予約によりロット[ %1 ] は [保留] されました。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, ltypLotwrkend.strLotID, CPstrHoldSt)
                            Call pubVsfInfo_Disp(pstrDMsg)
                                
                    End Select
                    
                End If
            End If
            
            
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN02Q0_Init()
            'NSYS グリッド非活性
            VsfLot.Enabled = False
            vsfWP.Enabled = False
            
            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)
            
            Exit Sub

        '@例外処理
        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02Q0
                .strProcName = "prvWorkEnd"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
                
        End Try
    End Sub

' 未使用機能NSYS ↓
''関数名：prvblnEqftSyncRegist_Proc
''機　能：ｵﾌﾗｲﾝFTPﾃﾞｰﾀ同期登録処理
''引　数：lstrFTPResult  ：FTP送信結果
''　　　：lstrWfFlag     ：WF情報取得判定 NG:失敗
''戻り値：True:成功、False:失敗
''作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
''更新日：
''備　考：
'Private Function prvblnEqftSyncRegist_Proc(ByRef lstrFTPResult As String, _
'                                           ByRef lstrWfFlag As String) As Boolean
    
'    Dim ltypWFList                  As Waferlist                'WF情報ﾃﾞｰﾀ
'    Dim ltypEqftSyncregistReq       As EqftSyncregistReq        'ｵﾌﾗｲﾝFTPﾃﾞｰﾀ
'    Dim lblnAns                     As Boolean                  '汎用戻り値
'    Dim llngCnt                     As Long                     '汎用ｶｳﾝﾀ
'    Dim ltypOnErrorInfoLog          As CommonOnErrorInfoLog     'ｴﾗｰﾛｸﾞ情報
'    Dim lstrTitle                   As String

'    On Error GoTo Error_Handler
    
'    '@----------------------------------------
'    '@ ｵﾌﾗｲﾝFTPﾃﾞｰﾀ同期登録
'    '@ 処理条件(AND条件です。)
'    '@ ①FTP装置
'    '@ ②運用ﾓｰﾄﾞがM1
'    '@ ③装置ﾀｲﾌﾟがODF以外(ODFの場合はﾎﾟｰﾘﾝｸﾞSVで行う為)
'    '@ pubblnEqftSyncRegist_Upd　ﾛｸﾞ出力機能あり(FTPｻｰﾊﾞｰが起動していない場合通信ｴﾗｰとなります。SVのﾛｸﾞに表示されない)
'    '@ そこで落合様よりCLのﾛｸﾞに残して欲しいと要望があり(Deve以外はあり得ないが例外処理として記述します。)
'    '@----------------------------------------
    
'    '@戻り値初期化
'    prvblnEqftSyncRegist_Proc = False
    
            
'    '@ｲﾝﾌｫﾒｰｼｮﾝ画面起動
'    Load frmxxCM00X0
        
'    '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定
'    frmxxCM00X0.Caption = CPstrSubFormCM00X0Work
'    '@ｲﾝﾌｫﾒｰｼｮﾝ(装置データ登録中です。)
'    frmxxCM00X0.lblInfomation1.Caption = CPstrFTP
    
'    '@ｲﾝﾌｫﾒｰｼｮﾝﾌｫｰﾑを先行して描画する為、記述しています。
'    DoEvents
    
'    '@WFﾘｽﾄ取得ﾌﾗｸﾞ初期化
'    lstrWfFlag = vbNullString
    
'    With mtypLotprestate(mlngCurrentLotRowNo)
        
'        '@WF情報取得【CPstrCD0T:有効ｳｪﾊ】
'        lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, .strCarrierId, CPstrCD0T, ltypWFList)
'        '@結果判定
'        If lblnAns = False Then
'            '@WFﾘｽﾄ取得失敗
'            '@WF情報取得に失敗すると言うことは致命的であり
'            '@作業終了はさせない
'            lstrWfFlag = CMstrNG
'            Exit Function
'        End If

'    End With
    
'    '@ｵﾌﾗｲﾝFTPﾃﾞｰﾀ要求ﾃﾞｰﾀ格納
'    With ltypEqftSyncregistReq
'        .strMsgVer = CMstreqft_syncregistVer
'        .strWpID = ptypLotprestate.strWpID
'        .strSbID = pstrSBID
'        .strCarrierId = txtCarrier.Text
'        .strLotID = mtypLotprestate(mlngCurrentLotRowNo).strLotID
'        .strWorkStartTime = Format$(mtypLotprestate(mlngCurrentLotRowNo).strStartTime, "yyyymmddhhmmss") 'ftpの日付ﾌｫｰﾏｯﾄ
'        '@ﾃﾞｰﾀ件数
'        .lngEqftWfListCnt = ltypWFList.lngListCnt
'        '@件数ありの場合
'        If .lngEqftWfListCnt > 0 Then
'            '@配列の定義
'             ReDim .typEqftWfList(.lngEqftWfListCnt)
'            '@ﾃﾞｰﾀ件数分格納
'            For llngCnt = 1 To .lngEqftWfListCnt
'                .typEqftWfList(llngCnt).strWfId = ltypWFList.typWfList(llngCnt).strWfId
'                .typEqftWfList(llngCnt).strSlotNo = ltypWFList.typWfList(llngCnt).strSlotPosition
'            Next
'        End If
'    End With
        
'    '@ｵﾌﾗｲﾝFTPﾃﾞｰﾀ同期登録【lstrFTPResult：FTP送信結果】
'    lblnAns = pubblnEqftSyncRegist_Upd(ltypEqftSyncregistReq, lstrFTPResult)
'    '@結果判定
'    If lblnAns = True Then
'        '@正常終了
'        prvblnEqftSyncRegist_Proc = True
'    End If
    
'    '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
'    Unload frmxxCM00X0
    
'    Exit Function
    
'Error_Handler:

'    '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
'    Unload frmxxCM00X0
        
'    '@ｴﾗｰ情報設定
'    With ptypOnErrorInfo
'        .strMenuKey = CMstrLocalMenuKey
'        .strProcName = "prvblnEqftSyncRegist_Proc"
'        .strErrMessage = ""
'    End With

'    '@=======================
'    '@ 共通ｴﾗｰ処理
'    '@=======================
'    Call pubOnError_Proc

'End Function
' 未使用機能NSYS ↑

    '関数名：prvNextNgMsg_Disp
    '機　能：次工程送出不可ﾒｯｾｰｼﾞ表示
    '引　数：lstrRtnLotId       ：作業終了後、ﾛｯﾄID
    '　　　：lstrExcpHoldFlag   ：異常処理票保留ﾌﾗｸﾞ(0：未保留、1：保留)
    '　　　：lstrNormalHoldFlag ：通常保留ﾌﾗｸﾞ(0：未保留、1：保留)
    '　　　：ltypSpcJudge       ：SPC判定
    '戻り値：なし
    '作成日：2006/11/07 (Tue) 10:56:48 M.Miura
    '更新日：2006/11/07 (Tue) 10:56:48
    '備　考：
    Private Function prvNextNgMsg_Disp(ByVal lstrRtnLotId As String, _
                                  ByVal lstrActionFlag As String, _
                                  ByVal lstrExcpHoldFlag As String, _
                                  ByVal lstrNormalHoldFlag As String, _
                                  ByRef ltypSpcJudge As SpcJudge) As Boolean
                                  
        Dim lstrMsgHold As String
                                  
        Try

            prvNextNgMsg_Disp = False

            '@**************************************************
            '@ｱｸｼｮﾝ予定実行ﾌﾗｸﾞ判定
            '@**************************************************
            Select Case lstrActionFlag
                '@保留/停止の実行なし
                Case CPstrActionFlag0
                                                  
                '@停止
                Case CPstrActionFlag1
                
                    '@自動送信「あり」の場合は連続して次工程送出ﾒｯｾｰｼﾞ送信
                    If optLotNextSend0.Checked = True Then
                        '@表示ﾒｯｾｰｼﾞ変換("アクション予約によりロット[ %1 ] は [ %2 ] されました。" & "$$ロット[ %3 ]は次工程送出されません。")
                        pstrDMsg = CPstrActionInfo & CPstrActionStopNextStepInfo
                        pstrDMsg = pubstrMsgReplace_Set(pstrDMsg, lstrRtnLotId, CPstrStopSt, lstrRtnLotId)
                        '@表示ﾒｯｾｰｼﾞ変換"<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。"
                        lstrMsgHold = pubstrMsgReplace_Set(CPstrMsgInf006L, lstrRtnLotId, CMstrMsgActStop)
                        '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                        Call pubVsfInfo_Disp(lstrMsgHold)
                    Else
                        '@表示ﾒｯｾｰｼﾞ変換("アクション予約によりロット[ %1 ] は [ %2 ] されました。")
                        pstrDMsg = pubstrMsgReplace_Set(CPstrActionInfo, lstrRtnLotId, CPstrStopSt)
                    End If
                    
                    '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ構造体設定
                    With ptypLotAction
                        .lnglstCnt = 1
                        .strActionFlag = CPstrActionFlag1   '1:停止
                        Dim ltypLotActListTmp As LotActList
                        ltypLotActListTmp = .typLotActList(.lnglstCnt - 1)
                        ltypLotActListTmp.strLotID = lstrRtnLotId
                        ltypLotActListTmp.strMessage = pstrDMsg
                        .typLotActList(.lnglstCnt - 1) = ltypLotActListTmp
                    End With

                    '@ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ画面名称設定
                    frmxxCM0040.Instance.Text = CPstrSubDispTitleActionInfo

                    '@ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ表示画面を表示(ptypLotActionの情報でｱｸｼｮﾝ予約の内容を表示)
                    frmxxCM0040.Instance.ShowDialog(Me)
                    frmxxCM0040.Instance = Nothing
                    
                    prvNextNgMsg_Disp = True
                    
                '@保留
                Case CPstrActionFlag2
                
                    '@自動送信「あり」の場合は連続して次工程送出ﾒｯｾｰｼﾞ送信
                    If optLotNextSend0.Checked = True Then
                        '@表示ﾒｯｾｰｼﾞ変換("アクション予約によりロット[ %1 ] は [ %2 ] されました。" & "$$ロット[ %3 ]は次工程送出されません。")
                        pstrDMsg = CPstrActionInfo & CPstrActionStopNextStepInfo
                        pstrDMsg = pubstrMsgReplace_Set(pstrDMsg, lstrRtnLotId, CPstrHoldSt, lstrRtnLotId)
                        '@表示ﾒｯｾｰｼﾞ変換"<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。"
                        lstrMsgHold = pubstrMsgReplace_Set(CPstrMsgInf006L, lstrRtnLotId, CMstrMsgActHold)
                        '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                        Call pubVsfInfo_Disp(lstrMsgHold)
                    Else
                        '@表示ﾒｯｾｰｼﾞ変換("アクション予約によりロット[ %1 ] は [ %2 ] されました。")
                        pstrDMsg = pubstrMsgReplace_Set(CPstrActionInfo, lstrRtnLotId, CPstrHoldSt)
                    End If
                    
                    '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ構造体設定
                    With ptypLotAction
                        .lnglstCnt = 1
                        .strActionFlag = CPstrActionFlag2   '2:保留
                        Dim ltypLotActListTmp As LotActList
                        ltypLotActListTmp = .typLotActList(.lnglstCnt - 1)
                        ltypLotActListTmp.strLotID = lstrRtnLotId
                        ltypLotActListTmp.strMessage = pstrDMsg
                        .typLotActList(.lnglstCnt - 1) = ltypLotActListTmp
                    End With

                    '@ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ画面名称設定
                    frmxxCM0040.Instance.Text = CPstrSubDispTitleActionInfo

                    '@ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ表示画面を表示(ptypLotActionの情報でｱｸｼｮﾝ予約の内容を表示)
                    frmxxCM0040.Instance.ShowDialog(Me)
                    frmxxCM0040.Instance = Nothing
                    
                    prvNextNgMsg_Disp = True
                    
            End Select

            '@**************************************************
            '@保留判定
            '@**************************************************
            Select Case True
                    
                '@異常処理票保留
                Case lstrExcpHoldFlag = CPstrHold1
                    
                    '@異常処理票保留の場合
                    '@表示ﾒｯｾｰｼﾞ変換"<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006L, lstrRtnLotId, CMstrMsgExcpHold)
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                    
                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    prvNextNgMsg_Disp = True
            
                '@通常保留
                Case lstrNormalHoldFlag = CPstrHold1
                    
                    '@通常保留の場合
                    '@表示ﾒｯｾｰｼﾞ変換"<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006L, lstrRtnLotId, CMstrMsgHold)
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                    
                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    prvNextNgMsg_Disp = True
                    
            End Select
            
            '@**************************************************
            '@SPC規格値判定結果の判定
            '@**************************************************
            Select Case ltypSpcJudge.strSpecCheck
            
                '@規格値異常、その他異常の場合 (SPEC_CHEK="2"or"3")
                Case CMstrSpecCheckSpecNG, CMstrSpecCheckOtherNG

                    '@「"<%1><TRM4WW>$$%2"」
                    pstrDMsg = pubstrMsgReplace_Set(ltypSpcJudge.strSpecMsg)
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004W, ltypSpcJudge.strSpecMsgCode, pstrDMsg)
                    
                    '@ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, CMstrSpecCheckAlarmCaption, True, 16)
                    
                    prvNextNgMsg_Disp = True
                    
                '@SPC異常
                Case CMstrSpecCheckSPCNG

                    '@「"<%1><TRM4MI>$$%2"」
                    pstrDMsg = pubstrMsgReplace_Set(ltypSpcJudge.strSpecMsg)
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004M, ltypSpcJudge.strSpecMsgCode, pstrDMsg)
                        
                    '@ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, CMstrSpecCheckAlarmCaption, True, 16)
                    
            End Select
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvNextNgMsg_Disp"
                .strErrMessage = ""
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvRefresh_Disp
    '機　能：作業終了画面の最新取得と復元
    '引　数：lblnJudge(True：最終更新日時の判定あり、False：なし)
    '戻り値：なし
    '作成日：2006/06/07 (Wed) 09:00:21 M.Miura
    '更新日：2006/06/07 (Wed) 09:00:21
    '備　考：
    Private Sub prvRefresh_Disp(ByRef Optional lblnJudge As Boolean = False)
        
        Dim lstrWorkMemo        As String           '作業ﾒﾓ復元用
        Dim llngOptCnt          As Integer          '次工程ｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝのｶｳﾝﾄ

        '@最終更新日時の判定あり
        If lblnJudge = True Then
            '@子画面で更新されていない場合は抜ける
            If vsfLot.GetData(vsfLot.Row, CMvsfLotColEditTime) = ptypLotprestate.strLotLastUpdate Then
                Exit Sub
            End If
        End If
        
        '@次工程ｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝがなくなるまで(送出あり～追加流動)
        Dim optLotNextSend() As RadioButton = { optLotNextSend0, optLotNextSend1 }
        For llngOptCnt = LBound(optLotNextSend) To UBound(optLotNextSend)
            '@ﾁｪｯｸが付いている場合
            If optLotNextSend(llngOptCnt).Checked = True Then
                '@ﾁｪｯｸ付きIndex退避
                pstrOptionValue = llngOptCnt
                '@ﾙｰﾌﾟを抜ける
                Exit For
            End If
        Next llngOptCnt
        
        '@作業ﾒﾓを退避
        lstrWorkMemo = txtWorkMemo.Text

        '@ｷｬﾘｱ再入力(次工程ｵﾌﾟｼｮﾅﾙﾁｪｯｸ付きの復元処理はValidateにあります)
        mblnCarrierValidateCallFlag = True
        Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(True))
        mblnCarrierValidateCallFlag = False

        '@送出なしのみ有効な場合(送出できない場合)
        If optLotNextSend0.Enabled = False And _
           optLotNextSend1.Enabled = True Then
            '@送出なしにﾁｪｯｸ
            optLotNextSend1.Checked = True
        End If
        
        '@作業ﾒﾓを子画面起動前に復元
        txtWorkMemo.Text = lstrWorkMemo
                         
        Exit Sub
                         
    Error_Handler:
        
        '@ｴﾗｰ情報設定
        With ptypOnErrorInfo
            .strMenuKey = CMstrLocalMenuKey
            .strProcName = "prvRefresh_Disp"
            .strErrMessage = ""
        End With

        '@共通ｴﾗｰ処理
        Call pubOnError_Proc()
                              
    End Sub

    '関数名：prvblnACarrierSet
    '機　能：ACarrier選択
    '引　数：なし
    '戻り値：True:成功、False:失敗
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Function prvblnACarrierSet() As Boolean
        
        Dim lblnAns As Boolean
        
        Try
            
            '@戻り値初期化
            prvblnACarrierSet = False
                                                                      
            '@ACARRIER_SET
            lblnAns = pubblnACarrierSet_Upd(CPstrcarracarsetVer, mtypACarrierGroup)
            '@結果判定
            If lblnAns = False Then
                Exit Function
            End If
            
            '@正常終了
            prvblnACarrierSet = True
            
            Exit Function
            
        Catch ex As Exception
                
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnACarrierSet"
                .strErrMessage = ""
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvstrACarrierLabelProductLot
    '機　能：ACarrier表示用ﾗﾍﾞﾙ作成(製品用)
    '引　数：なし
    '戻り値：ACarrier
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Function prvstrACarrierLabelProductLot() As String
        
        Dim llngCnt                     As Integer                  '汎用ｶｳﾝﾀ
        Dim lstrTargetBatchId           As String
        Dim lblnTargetFlag              As Boolean
        
        Try
            
            
            '@戻り値初期化
            prvstrACarrierLabelProductLot = vbNullString
            
            '@ﾊﾞｯﾁ単位以外
            If mtypWorkALDLotList.strProcessUnit <> CPstrProcessUnit_Batch Then
                Exit Function
            End If
                
            '@ﾊﾞｯﾁID種別
            lstrTargetBatchId = prvstrBatchIdLabel
            
            '@ﾀｰｹﾞｯﾄﾊﾞｯﾁIDを探す
            For llngCnt = 0 To mtypWorkALDLotList.lngAldWorkACarrierListCnt - 1
                If mtypWorkALDLotList.typAldWorkACarrierList(llngCnt).strTapeBatchId = lstrTargetBatchId Then
                    lblnTargetFlag = True
                ElseIf mtypWorkALDLotList.typAldWorkACarrierList(llngCnt).strOvenBatchId = lstrTargetBatchId Then
                    lblnTargetFlag = True
                ElseIf mtypWorkALDLotList.typAldWorkACarrierList(llngCnt).strAldBatchId = lstrTargetBatchId Then
                    lblnTargetFlag = True
                Else
                    lblnTargetFlag = False
                End If
                
                '@該当ﾊﾞｯﾁID
                '@製品の場合はﾃｰﾌﾟ、ｵｰﾌﾞﾝにﾊﾞｯﾁIDがある
                'If lblnTargetFlag = True And _
                '    mtypWorkALDLotList.typAldWorkACarrierList(llngCnt).strTapeBatchId <> vbNullString And _
                '    mtypWorkALDLotList.typAldWorkACarrierList(llngCnt).strOvenBatchId <> vbNullString Then
                    
                    
                If lblnTargetFlag = True Then
                    
                    '@文字列NULL
                    If prvstrACarrierLabelProductLot = vbNullString Then
                        prvstrACarrierLabelProductLot = mtypWorkALDLotList.typAldWorkACarrierList(llngCnt).strACarrierId
                    Else
                        '@既にあるACarrierを検索(新規の場合)
                        If InStr(1, prvstrACarrierLabelProductLot, mtypWorkALDLotList.typAldWorkACarrierList(llngCnt).strACarrierId, vbBinaryCompare) = 0 Then
                            prvstrACarrierLabelProductLot = prvstrACarrierLabelProductLot + vbCrLf + mtypWorkALDLotList.typAldWorkACarrierList(llngCnt).strACarrierId
                        End If
                    End If
                End If
            Next
                
            Exit Function
            
        Catch ex As Exception
                
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvstrACarrierLabelProductLot"
                .strErrMessage = ""
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvstrBatchIdLabel
    '機　能：ﾊﾞｯﾁIDﾗﾍﾞﾙ作成
    '引　数：なし
    '戻り値：ﾊﾞｯﾁID
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Function prvstrBatchIdLabel() As String
            
        Try
            
            '@ﾊﾞｯﾁID種別
            Select Case mtypWorkALDLotList.strProcessNum
                '@ﾃｰﾌﾟ貼り/剥離
                Case CPstrALDProcessNum_20, CPstrALDProcessNum_50
                    prvstrBatchIdLabel = mtypWorkALDLotList.strTapeBatchId
                '@ｵｰﾌﾞﾝ
                Case CPstrALDProcessNum_30
                    prvstrBatchIdLabel = mtypWorkALDLotList.strOvenBatchId
                '@成膜
                Case CPstrALDProcessNum_40
                    prvstrBatchIdLabel = mtypWorkALDLotList.strAldBatchId
                Case Else
                    prvstrBatchIdLabel = vbNullString
            End Select
                    
            Exit Function
            
        Catch ex As Exception
                
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvstrBatchIdLabel"
                .strErrMessage = ""
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvBatchWorkStart
    '機　能：ﾊﾞｯﾁ作業開始
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/06 (Tue) 16:54:44 Y.Yoneyama
    '更新日：2018/11/06 (Tue) 16:54:44 Y.Yoneyama
    '備　考：
    Private Sub prvBatchWorkStart()

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lblnLotMatchFlag        As Boolean              '送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞ(True:格納済,False:未格納)
        Dim lstrCarrierID           As String               '登録ｷｬﾘｱID
        Dim lstrCompareCarrierID    As String               '比較用ｷｬﾘｱID
        Dim ltypBatStartWrk         As BatStartWrk          'ﾊﾞｯﾁﾛｯﾄ作業開始構造体
        Dim ltypRestrictInfo        As RestrictInfo         '時間制限情報格納構造体
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ1
        Dim llngCnt2                As Integer              '汎用ｶｳﾝﾀ2
        Dim llngAns                 As Integer              'ﾎﾟｯﾌﾟｱｯﾌﾟﾒｯｾｰｼﾞ戻り値格納用

        Try
                                    
            '@=======================
            '@ACarrierSet
            '@=======================
            If cmdACarrierSelect.Enabled = True Then
                If prvblnACarrierSet = False Then
                    Exit Sub
                End If
            End If
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypBatStartWrk
                .strSbID = pstrSBID                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strBatchId = prvstrBatchIdLabel                    'ﾊﾞｯﾁID
                .strComments = txtWorkMemo.Text                     '作業ﾒﾓ
                .strEmpID = pstrUserID                              '作業者ID
                .strMsgVer = CMstrbat_startwrkVer                   'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strClassDivision = CPstrCD3B                       '処理区分(3B=制限時間ﾁｪｯｸ有り)
                .strEqType = vsfWp.GetData(vsfWp.Row, CMvsfWPColEqType)
                .strWpID = vsfWp.GetData(vsfWp.Row, CMvsfWPColWpID)
                .strRecipeId = vsfWp.GetData(vsfWp.Row, CMvsfWpColRecipe)
                .typBLotList = New List(Of BLotList)

                '@ﾊﾞｯﾁ組ﾛｯﾄIDと最終更新日時を構造体へ
                For llngCnt = 1 To vsfLot.Rows.Count - 1
                
                    '@ﾛｯﾄIDがNULL以外か
                    If vsfLot.GetData(llngCnt, CMvsfLotColLotID) <> vbNullString Then
                        
                        '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞの初期化
                        lblnLotMatchFlag = False
                        
                        For llngCnt2 = 0 To .lngBLotListCnt - 1
                            
                            '@送信ﾃﾞｰﾀのﾛｯﾄﾘｽﾄに既に対象ﾛｯﾄが格納済みか
                            If .typBLotList(llngCnt2).strLotID = _
                                vsfLot.GetData(llngCnt, CMvsfLotColLotID) Then
                                
                                '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞに"True：格納済"をｾｯﾄ
                                lblnLotMatchFlag = True
                            End If
                        Next llngCnt2
                            
                        '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞが"False：格納済"か
                        If lblnLotMatchFlag = False Then
                            
                            '@ﾘｽﾄを+1する
                            .lngBLotListCnt = .lngBLotListCnt + 1
                            Dim ltypBLotListTmp As New BLotList
                            
                            ltypBLotListTmp.strLotID = _
                                vsfLot.GetData(llngCnt, CMvsfLotColLotID)          'ﾛｯﾄID
                                
                            ltypBLotListTmp.strLotLastUpdate = _
                                vsfLot.GetData(llngCnt, CMvsfLotColEditTime)       '最終更新日時

                            .typBLotList.Add(ltypBLotListTmp)
                        End If
                    End If
                Next llngCnt

            End With
            
            
            '@=======================
            '@ 1回目のﾊﾞｯﾁ作業開始(まずは制限時間の確認のみ→時間制限が無い場合はこれで確定)
            '@=======================
            lblnAns = pubblnBatStartWrk_Ins(ltypBatStartWrk, ltypRestrictInfo)
            
            '@1回目のﾊﾞｯﾁ作業開始結果が"True：通信成功"か
            If lblnAns = True Then

                '@制限時間超過の警告が発生している、または時間制限設定が存在しないか
                If ltypRestrictInfo.strToOpId <> vbNullString Or _
                    ltypRestrictInfo.strToStepId <> vbNullString Or _
                    ltypRestrictInfo.strLimitTime <> vbNullString Then
                    
                    For llngCnt2 = 0 To mtypLotprestate.Count - 1
                    
                        '@制限時間が設定されているか
                        '@※以下(CMstrRestrictTypeID1=以下設定),以上(CMstrRestrictTypeID2=以上設定)の場合
                        If mtypLotprestate(llngCnt2).strRestrictTypeID = CMstrRestrictTypeID1 Or _
                            mtypLotprestate(llngCnt2).strRestrictTypeID = CMstrRestrictTypeID2 Then
                                            
                            '@=備忘録=
                            '@時間制限のﾒｯｾｰｼﾞ内容を時間制限ﾀｲﾌﾟを判定し、ﾒｯｾｰｼﾞ内容を作業開始と同じﾒｯｾｰｼﾞとしたが
                            '@複数時間制限が超過されていてもSVからの応答は1件のみ返却される。(作成当初から)
                            '@このことからﾒｯｾｰｼﾞ内容は曖昧な表現を使用していたのであろう。元の表記に戻す。
                            '@又、既存の作りで確定時に一度、登録要求を行いSVで時間制限超過を判定する。ｴﾗｰがある場合は応答ﾒｯｾｰｼﾞに文字列が
                            '@返却される仕組み(エラーがない場合はそのまま登録)でCLは文字列の有無でｲﾝﾌｫﾒｰｼｮﾝﾒｯｾｰｼﾞを表示する。この時点でﾛｯﾄの判別は不能です。
                            '@詳細を表示する場合はSVからｴﾗｰ情報を全て返却してもらう必要あり。
                            '@R4-08ﾃｽﾄ前ﾚﾋﾞｭｰで落合様より複数超過の場合ｴﾗｰが存在してもﾒｯｾｰｼﾞは最初の1件のみ。応答「はい」でその他の超過は無視して登録する仕組み
                            '@であれば、ﾛｯﾄIDを表示する意味もないとのこと。(三浦様　談)
                            
                            '@旧ﾒｯｾｰｼﾞ
                            '@"<TRM7NW>$$バッチ組されているロットに[%1 %2]までの工程において$制限時間が守られていないロットが存在します。処理を継続しますか？"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007N, ltypRestrictInfo.strToOpId, ltypRestrictInfo.strToStepId)

                            '@=======================
                            '@ ｲﾝﾌｫﾒｰｼｮﾝﾒｯｾｰｼﾞBOX表示
                            '@=======================
                            llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                
                            '@ﾒｯｾｰｼﾞBOXにて「いいえ」が選択されたか
                            If llngAns = vbNo Then
                            
                                '@処理終了
                                Exit Sub
                            Else
                                '@「はい」が選択された場合

                                '@処理区分再設定(02=指定なし)
                                ltypBatStartWrk.strClassDivision = CPstrCD02
                                
                                '@=======================
                                '@ 2回目のﾊﾞｯﾁ作業開始(こちらはﾊﾞｯﾁ組ﾛｯﾄ作業開始のみ)
                                '@=======================
                                lblnAns = pubblnBatStartWrk_Ins(ltypBatStartWrk, ltypRestrictInfo)
                
                                '@2回目のﾊﾞｯﾁ作業開始結果が"True：通信成功"か
                                If lblnAns = True Then
                                    
                                    '@最終更新日時を退避しておく(ﾊﾞｯﾁ作業開始後なのでどのﾛｯﾄの最終更新日時でも同じなので先頭でとっておく)
                                    mstrLotLastUpdate = ltypRestrictInfo.typBatStart(0).strLastUpdate
                                    
                                    '@使用部材が存在する場合
                                    If ptypChkMaterial.lngMaterialTypeCnt > 0 Then
                                                                        
                                        '@=======================
                                        '@ 使用部材を作業記録へ反映
                                        '@=======================
                                        lblnAns = prvblnSpcRegcollect_Set(mstrLotLastUpdate)
                                        
                                        '@登録ｴﾗｰの場合
                                        If lblnAns = False Then
                                            
                                            '@表示ﾒｯｾｰｼﾞ変換
                                            '@"<TRM97W>$$使用部材を作業記録へ登録に失敗しました。"
                                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0097)
                                            
                                            '@ﾒｯｾｰｼﾞ表示
                                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                        End If
                                    End If

                                    '@表示ﾒｯｾｰｼﾞ作成
                                    lstrCarrierID = vbNullString
                                    
                                    With vsfLot
                                        
                                        For llngCnt = 1 To .Rows.Count - 1
                                            
                                            '@ﾛｯﾄIDがNULL以外か
                                            If .GetData(llngCnt, CMvsfLotColLotID) <> vbNullString Then
                                                
                                                '@比較用ｷｬﾘｱIDに格納
                                                lstrCompareCarrierID = .GetData(llngCnt, CMvsfLotColCarrierID)
                                                
                                                '@-----------------------
                                                '@ 既にｷｬﾘｱIDが格納されているかﾁｪｯｸ(蒸着ﾊﾞｯﾁ組対応)
                                                '@-----------------------
                                                '@表示ﾒｯｾｰｼﾞ用ｷｬﾘｱIDにﾙｰﾌﾟ行のｷｬﾘｱIDが含まれていないか
                                                If InStr(1, lstrCarrierID, lstrCompareCarrierID) = 0 Then
                                                
                                                    '@表示ﾒｯｾｰｼﾞ用のｷｬﾘｱID連結処理：[[ｷｬﾘｱID1][ｷｬﾘｱID2]]
                                                    lstrCarrierID = lstrCarrierID & _
                                                                    CMstrBrLeft & _
                                                                    .GetData(llngCnt, CMvsfLotColCarrierID) & _
                                                                    CMstrBrRight
                                                End If
                                            End If
                                        Next llngCnt
                                    End With

                                    
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    '@pubVsfInfo_Disp("メッセージコード：C_I05%0$$バッチ作業開始しました。ｷｬﾘｱ%1")
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000I, lstrCarrierID)
                                    Call pubVsfInfo_Disp(pstrDMsg)


                                    With ptypCommonInfo
                                        
                                        '@引継構造体のｷｬﾘｱIDがNULL以外か(Alt_Pointerを初期化)
                                        If .strCarrierId <> vbNullString Then
                                            .strAltPointer = vbNullString
                                        End If
                                    End With
                                    
                                    '@ｷｬﾘｱIDのｸﾘｱ
                                    txtCarrier.Text = vbNullString
                                    
                                    '@=======================
                                    '@ 画面情報初期化処理
                                    '@=======================
                                    Call prvfrmxxEN02Q0_Init()
                                    'NSYS グリッド非活性
                                    VsfLot.Enabled = False
                                    vsfWP.Enabled = False
                                    
                                    Exit For
                                Else
                                    '@2回目のﾊﾞｯﾁ作業開始結果が"False：通信失敗"か
                                    Exit Sub
                                End If
                            End If
                        End If
                    Next llngCnt2

                Else
                    '@制限時間が超過していない、又は時間制限設定が存在しない場合

                    '@使用部材が存在する場合
                    If ptypChkMaterial.lngMaterialTypeCnt > 0 Then
                        
                        '@最終更新日時を退避しておく(ﾊﾞｯﾁ作業開始後なのでどのﾛｯﾄの最終更新日時でも同じなので先頭でとっておく)
                        mstrLotLastUpdate = ltypRestrictInfo.typBatStart(0).strLastUpdate
                        
                        '@=======================
                        '@ 使用部材を作業記録へ反映
                        '@=======================
                        lblnAns = prvblnSpcRegcollect_Set(mstrLotLastUpdate)
                        
                        '@登録ｴﾗｰの場合
                        If lblnAns = False Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM97W>$$使用部材を作業記録へ登録に失敗しました。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0097)
                            
                            '@ﾒｯｾｰｼﾞ表示
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        End If
                        
                    End If
                
                    '@表示ﾒｯｾｰｼﾞ作成
                    lstrCarrierID = vbNullString

                    With vsfLot
                        
                        For llngCnt = 1 To .Rows.Count - 1
                            
                            '@ﾛｯﾄIDがNULL以外か
                            If .GetData(llngCnt, CMvsfLotColLotID) <> vbNullString Then
                                
                                '@比較用ｷｬﾘｱIDに格納
                                lstrCompareCarrierID = .GetData(llngCnt, CMvsfLotColCarrierID)
                                
                                '@-----------------------
                                '@ 既にｷｬﾘｱIDが格納されているかﾁｪｯｸ(蒸着ﾊﾞｯﾁ組対応)
                                '@-----------------------
                                '@表示ﾒｯｾｰｼﾞ用ｷｬﾘｱIDにﾙｰﾌﾟ行のｷｬﾘｱIDが含まれていないか
                                If InStr(1, lstrCarrierID, lstrCompareCarrierID) = 0 Then
                                
                                    '@表示ﾒｯｾｰｼﾞ用のｷｬﾘｱID連結処理：[[ｷｬﾘｱID1][ｷｬﾘｱID2]]
                                    lstrCarrierID = lstrCarrierID & _
                                                    CMstrBrLeft & _
                                                    .GetData(llngCnt, CMvsfLotColCarrierID) & _
                                                    CMstrBrRight
                                End If
                            End If
                        Next llngCnt
                    End With
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@pubVsfInfo_Disp("メッセージコード：C_I05%0$$バッチ作業開始しました。ｷｬﾘｱ%1")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000I, lstrCarrierID)
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    
                    With ptypCommonInfo
                    
                        '@引継構造体のｷｬﾘｱIDがNULL以外か(Alt_Pointerを初期化)
                        If .strCarrierId <> vbNullString Then
                            .strAltPointer = vbNullString
                        End If
                    End With
                    
                    '@ｷｬﾘｱIDのｸﾘｱ
                    txtCarrier.Text = vbNullString
                    
                    '@=======================
                    '@ 画面情報初期化処理
                    '@=======================
                    Call prvfrmxxEN02Q0_Init()
                    'NSYS グリッド非活性
                    VsfLot.Enabled = False
                    vsfWP.Enabled = False

                End If
            Else
                '@1回目のﾊﾞｯﾁ作業開始結果が"False：通信失敗"か
            
                Exit Sub
            End If

            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)
                            
            '@=======================
            '@ 防湿ALDﾚｼﾋﾟ作成要求(eqsvr(ftppol)へ送信)
            '@=======================
            lblnAns = pubblnAldMakeRecipe_Upd(ltypBatStartWrk.strWpID)

            '@登録ｴﾗｰの場合
            If lblnAns = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM02E>$$レシピファイル作成に失敗しました。$システム担当者に連絡してください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0002)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvBatchWorkStart"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvBatchProcStart
    '機　能：ﾊﾞｯﾁ処理開始
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/06 (Tue) 16:54:44 Y.Yoneyama
    '更新日：2018/11/06 (Tue) 16:54:44 Y.Yoneyama
    '備　考：
    Private Sub prvBatchProcStart()

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lblnLotMatchFlag        As Boolean              '送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞ(True:格納済,False:未格納)
        Dim lstrCarrierID           As String               '登録ｷｬﾘｱID
        Dim lstrCompareCarrierID    As String               '比較用ｷｬﾘｱID
        Dim ltypBatPrcStart         As BatPrcStartEnd       'ﾊﾞｯﾁ処理開始構造体
        Dim ltypRestrictInfo        As RestrictInfo         '時間制限情報格納構造体
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ1
        Dim llngCnt2                As Integer              '汎用ｶｳﾝﾀ2
        Dim llngAns                 As Integer              'ﾎﾟｯﾌﾟｱｯﾌﾟﾒｯｾｰｼﾞ戻り値格納用

        Try

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypBatPrcStart
                .strSbID = pstrSBID                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strBatchId = prvstrBatchIdLabel        'ﾊﾞｯﾁID
                .strComments = txtWorkMemo.Text         '作業ﾒﾓ
                .strEmpID = pstrUserID                  '作業者ID
                .strMsgVer = CMstrbat_prcstartVer       'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strClassDivision = CPstrCD3B           '処理区分(3B=制限時間ﾁｪｯｸ有り)
                .strEqType = vsfWp.GetData(vsfWp.Row, CMvsfWPColEqType)
                .typBLotList = New List(Of BLotList)
                
                '@ﾊﾞｯﾁ組ﾛｯﾄIDと最終更新日時を構造体へ
                For llngCnt = 1 To vsfLot.Rows.Count - 1
                
                    '@ﾛｯﾄIDがNULL以外か
                    If vsfLot.GetData(llngCnt, CMvsfLotColLotID) <> vbNullString Then
                        
                        '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞの初期化
                        lblnLotMatchFlag = False
                        
                        For llngCnt2 = 0 To .lngBLotListCnt - 1
                            
                            '@送信ﾃﾞｰﾀのﾛｯﾄﾘｽﾄに既に対象ﾛｯﾄが格納済みか
                            If .typBLotList(llngCnt2).strLotID = _
                                vsfLot.GetData(llngCnt, CMvsfLotColLotID) Then
                                
                                '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞに"True：格納済"をｾｯﾄ
                                lblnLotMatchFlag = True
                            End If
                        Next llngCnt2
                            
                        '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞが"False：格納済"か
                        If lblnLotMatchFlag = False Then
                            
                            '@ﾘｽﾄを+1する
                            .lngBLotListCnt = .lngBLotListCnt + 1
                            Dim ltypBLotListTmp As New BLotList
                            
                            ltypBLotListTmp.strLotID = _
                                vsfLot.GetData(llngCnt, CMvsfLotColLotID)          'ﾛｯﾄID
                                
                            ltypBLotListTmp.strLotLastUpdate = _
                                vsfLot.GetData(llngCnt, CMvsfLotColEditTime)       '最終更新日時

                            .typBLotList.Add(ltypBLotListTmp)
                        End If
                    End If
                Next llngCnt
            End With


            '@=======================
            '@ 1回目のﾊﾞｯﾁ処理開始(まずは制限時間の確認のみ)
            '@=======================
            lblnAns = pubblnbatPrcStart_Ins(ltypBatPrcStart, ltypRestrictInfo)
            
            '@1回目のﾊﾞｯﾁ作業開始結果が"True：通信成功"か
            If lblnAns = True Then
                
                '@制限時間超過の警告が発生している、または時間制限設定が存在しないか
                If ltypRestrictInfo.strToOpId <> vbNullString Or _
                    ltypRestrictInfo.strToStepId <> vbNullString Or _
                    ltypRestrictInfo.strLimitTime <> vbNullString Then
                    
                    
                    For llngCnt2 = 0 To mtypLotprestate.Count - 1
                    
                        '@制限時間が設定されているか
                        '@※以下(CMstrRestrictTypeID1=以下設定),以上(CMstrRestrictTypeID2=以上設定)の場合
                        If mtypLotprestate(llngCnt2).strRestrictTypeID = CMstrRestrictTypeID1 Or _
                            mtypLotprestate(llngCnt2).strRestrictTypeID = CMstrRestrictTypeID2 Then
                                
                            '@=備忘録=
                            '@時間制限のﾒｯｾｰｼﾞ内容を時間制限ﾀｲﾌﾟを判定し、ﾒｯｾｰｼﾞ内容を作業開始と同じﾒｯｾｰｼﾞとしたが
                            '@複数時間制限が超過されていてもSVからの応答は1件のみ返却される。(作成当初から)
                            '@このことからﾒｯｾｰｼﾞ内容は曖昧な表現を使用していたのであろう。元の表記に戻す。
                            '@又、既存の作りで確定時に一度、登録要求を行いSVで時間制限超過を判定する。ｴﾗｰがある場合は応答ﾒｯｾｰｼﾞに文字列が
                            '@返却される仕組み(エラーがない場合はそのまま登録)でCLは文字列の有無でｲﾝﾌｫﾒｰｼｮﾝﾒｯｾｰｼﾞを表示する。この時点でﾛｯﾄの判別は不能です。
                            '@詳細を表示する場合はSVからｴﾗｰ情報を全て返却してもらう必要あり。
                            '@R4-08ﾃｽﾄ前ﾚﾋﾞｭｰで落合様より複数超過の場合ｴﾗｰが存在してもﾒｯｾｰｼﾞは最初の1件のみ。応答「はい」でその他の超過は無視して登録する仕組み
                            '@であれば、ﾛｯﾄIDを表示する意味もないとのこと。(三浦様　談)

                            '@旧ﾒｯｾｰｼﾞ
                            '@"<TRM7NW>$$バッチ組されているロットに[%1 %2]までの工程において$制限時間が守られていないロットが存在します。処理を継続しますか？"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007N, ltypRestrictInfo.strToOpId, ltypRestrictInfo.strToStepId)

                            '@=======================
                            '@ ｲﾝﾌｫﾒｰｼｮﾝﾒｯｾｰｼﾞBOX表示
                            '@=======================
                            llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                
                            '@ﾒｯｾｰｼﾞBOXにて「いいえ」が選択されたか
                            If llngAns = vbNo Then

                                '@処理終了
                                Exit Sub
                            Else
                                '@「はい」が選択された場合
                                
                                '@処理区分再設定(02=指定なし)
                                ltypBatPrcStart.strClassDivision = CPstrCD02
                                
                                '@=======================
                                '@ 2回目のﾊﾞｯﾁ処理開始(こちらはﾊﾞｯﾁ組ﾛｯﾄ処理開始のみ)
                                '@=======================
                                lblnAns = pubblnbatPrcStart_Ins(ltypBatPrcStart, ltypRestrictInfo)
                
                                '@2回目のﾊﾞｯﾁ作業開始結果が"True：通信成功"か
                                If lblnAns = True Then
                                    
                                    '@表示ﾒｯｾｰｼﾞ作成
                                    lstrCarrierID = vbNullString
                                    
                                    With vsfLot
                                        For llngCnt = 1 To .Rows.Count - 1
                                            
                                            '@ﾛｯﾄIDがNULL以外か
                                            If .GetData(llngCnt, CMvsfLotColLotID) <> vbNullString Then
                                                
                                                '@比較用ｷｬﾘｱIDに格納
                                                lstrCompareCarrierID = .GetData(llngCnt, CMvsfLotColCarrierID)
                                                
                                                '@-----------------------
                                                '@ 既にｷｬﾘｱIDが格納されているかﾁｪｯｸ(蒸着ﾊﾞｯﾁ組対応)
                                                '@-----------------------
                                                '@表示ﾒｯｾｰｼﾞ用ｷｬﾘｱIDにﾙｰﾌﾟ行のｷｬﾘｱIDが含まれていないか
                                                If InStr(1, lstrCarrierID, lstrCompareCarrierID) = 0 Then
                                                
                                                    '@表示ﾒｯｾｰｼﾞ用のｷｬﾘｱID連結処理：[[ｷｬﾘｱID1][ｷｬﾘｱID2]]
                                                    lstrCarrierID = lstrCarrierID & _
                                                                    CMstrBrLeft & _
                                                                    .GetData(llngCnt, CMvsfLotColCarrierID) & _
                                                                    CMstrBrRight
                                                End If
                                            End If
                                        Next llngCnt
                                    End With
         
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000M, lstrCarrierID)
                                    
                                    '@成功ﾒｯｾｰｼﾞ表示
                                    '@pubVsfInfo_Disp("<TRM0MI>$$バッチ処理開始しました。ｷｬﾘｱ%1")
                                    Call pubVsfInfo_Disp(pstrDMsg)
                                    
                                    '@ｷｬﾘｱIDのｸﾘｱ
                                    txtCarrier.Text = vbNullString
                                    
                                    '@=======================
                                    '@ 画面情報初期化処理
                                    '@=======================
                                    Call prvfrmxxEN02Q0_Init()
                                    'NSYS グリッド非活性
                                    VsfLot.Enabled = False
                                    vsfWP.Enabled = False
                                    
                                    Exit For
                                Else
                                    '@2回目のﾊﾞｯﾁ処理開始結果が"False：通信失敗"か
                                    Exit Sub
                                End If
                            End If
                        End If
                    Next llngCnt2
                Else
                    '@制限時間が超過していない、又は時間制限設定が存在しない場合
                
                    '@表示ﾒｯｾｰｼﾞ作成
                    lstrCarrierID = vbNullString
                    
                    With vsfLot
                        For llngCnt = 1 To .Rows.Count - 1
                            '@ﾛｯﾄIDがNULL以外か
                            If .GetData(llngCnt, CMvsfLotColLotID) <> vbNullString Then
                                
                                '@比較用ｷｬﾘｱIDに格納
                                lstrCompareCarrierID = .GetData(llngCnt, CMvsfLotColCarrierID)
                                
                                '@-----------------------
                                '@ 既にｷｬﾘｱIDが格納されているかﾁｪｯｸ(蒸着ﾊﾞｯﾁ組対応)
                                '@-----------------------
                                '@表示ﾒｯｾｰｼﾞ用ｷｬﾘｱIDにﾙｰﾌﾟ行のｷｬﾘｱIDが含まれていないか
                                If InStr(1, lstrCarrierID, lstrCompareCarrierID) = 0 Then
                                
                                    '@表示ﾒｯｾｰｼﾞ用のｷｬﾘｱID連結処理：[[ｷｬﾘｱID1][ｷｬﾘｱID2]]
                                    lstrCarrierID = lstrCarrierID & _
                                                    CMstrBrLeft & _
                                                    .GetData(llngCnt, CMvsfLotColCarrierID) & _
                                                    CMstrBrRight
                                End If
                            End If
                        Next llngCnt
                    End With
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000M, lstrCarrierID)
                    
                    '@成功ﾒｯｾｰｼﾞ表示
                    '@pubVsfInfo_Disp("<TRM0MI>$$バッチ処理開始しました。ｷｬﾘｱ%1")
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    '@ｷｬﾘｱIDのｸﾘｱ
                    txtCarrier.Text = vbNullString
                    
                    '@=======================
                    '@ 画面情報初期化処理
                    '@=======================
                    Call prvfrmxxEN02Q0_Init()
                    'NSYS グリッド非活性
                    VsfLot.Enabled = False
                    vsfWP.Enabled = False

                End If
            Else
                '@1回目のﾊﾞｯﾁ処理開始結果が"False：通信失敗"か
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvBatchProcStart"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvBatchProcEnd
    '機　能：ﾊﾞｯﾁ処理終了
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/06 (Tue) 16:54:44 Y.Yoneyama
    '更新日：2018/11/06 (Tue) 16:54:44 Y.Yoneyama
    '備　考：
    Private Sub prvBatchProcEnd()

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lblnLotMatchFlag        As Boolean              '送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞ(True:格納済,False:未格納)
        Dim lstrCarrierID           As String               '登録ｷｬﾘｱID
        Dim lstrCompareCarrierID    As String               '比較用ｷｬﾘｱID
        Dim ltypBatPrcStart         As BatPrcStartEnd       'ﾊﾞｯﾁ処理開始構造体
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ1
        Dim llngCnt2                As Integer              '汎用ｶｳﾝﾀ2


        Try
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypBatPrcStart
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strBatchId = prvstrBatchIdLabel            'ﾊﾞｯﾁID
                .strComments = txtWorkMemo.Text             '作業ﾒﾓ
                .strEmpID = pstrUserID                      '作業者ID
                .strMsgVer = CMstrbat_prcend__Ver           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strClassDivision = CPstrCD01               '処理区分(ｸﾗｲｱﾝﾄ)
                .strEqType = vsfWp.GetData(vsfWp.Row, CMvsfWPColEqType)
                .typBLotList = New List(Of BLotList)
                
                '@ﾊﾞｯﾁ組ﾛｯﾄIDと最終更新日時を構造体へ
                For llngCnt = 1 To vsfLot.Rows.Count - 1
                
                    '@ﾛｯﾄIDがNULL以外か
                    If vsfLot.GetData(llngCnt, CMvsfLotColLotID) <> vbNullString Then
                        
                        '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞの初期化
                        lblnLotMatchFlag = False
                        
                        For llngCnt2 = 0 To .lngBLotListCnt - 1
                            
                            '@送信ﾃﾞｰﾀのﾛｯﾄﾘｽﾄに既に対象ﾛｯﾄが格納済みか
                            If .typBLotList(llngCnt2).strLotID = _
                                vsfLot.GetData(llngCnt, CMvsfLotColLotID) Then
                                
                                '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞに"True：格納済"をｾｯﾄ
                                lblnLotMatchFlag = True
                            End If
                        Next llngCnt2
                            
                        '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞが"False：格納済"か
                        If lblnLotMatchFlag = False Then
                            
                            '@ﾘｽﾄを+1する
                            .lngBLotListCnt = .lngBLotListCnt + 1
                            Dim ltypBLotListTmp As New BLotList
                            
                            ltypBLotListTmp.strLotID = _
                                vsfLot.GetData(llngCnt, CMvsfLotColLotID)          'ﾛｯﾄID
                                
                            ltypBLotListTmp.strLotLastUpdate = _
                                vsfLot.GetData(llngCnt, CMvsfLotColEditTime)       '最終更新日時

                            .typBLotList.Add(ltypBLotListTmp)
                        End If
                    End If
                Next llngCnt
            End With
            
            '@=======================
            '@ ﾊﾞｯﾁ処理終了
            '@=======================
            lblnAns = pubblnbatPrcEnd_Ins(ltypBatPrcStart)
            
            '@ﾊﾞｯﾁ処理終了結果が"True：通信成功"か
            If lblnAns = True Then
                
                With vsfLot
                    For llngCnt = 1 To .Rows.Count - 1
                        '@ﾛｯﾄIDがNULL以外か
                        If .GetData(llngCnt, CMvsfLotColLotID) <> vbNullString Then
                                
                            '@比較用ｷｬﾘｱIDに格納
                            lstrCompareCarrierID = .GetData(llngCnt, CMvsfLotColCarrierID)
                                
                            '@-----------------------
                            '@ 既にｷｬﾘｱIDが格納されているかﾁｪｯｸ(蒸着ﾊﾞｯﾁ組対応)
                            '@-----------------------
                            '@表示ﾒｯｾｰｼﾞ用ｷｬﾘｱIDにﾙｰﾌﾟ行のｷｬﾘｱIDが含まれていないか
                            If InStr(1, lstrCarrierID, lstrCompareCarrierID) = 0 Then
                                
                                '@表示ﾒｯｾｰｼﾞ用のｷｬﾘｱID連結処理：[[ｷｬﾘｱID1][ｷｬﾘｱID2]]
                                lstrCarrierID = lstrCarrierID & _
                                                CMstrBrLeft & _
                                                .GetData(llngCnt, CMvsfLotColCarrierID) & _
                                                CMstrBrRight
                            End If
                        End If
                    Next llngCnt
                End With
                        
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000N, lstrCarrierID)
                
                '@成功ﾒｯｾｰｼﾞ表示
                '@pubVsfInfo_Disp("<TRM0MI>$$バッチ処理終了しました。ｷｬﾘｱ%1")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ｷｬﾘｱIDのｸﾘｱ
                txtCarrier.Text = vbNullString
                
                '@=======================
                '@ 画面情報初期化処理
                '@=======================
                Call prvfrmxxEN02Q0_Init()
                'NSYS グリッド非活性
                VsfLot.Enabled = False
                vsfWP.Enabled = False

            Else
                '@ﾊﾞｯﾁ処理終了結果が"False：通信失敗"か
                        
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvBatchProcEnd"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvBatchWorkEnd
    '機　能：ﾊﾞｯﾁ作業終了
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/06 (Tue) 16:54:44 Y.Yoneyama
    '更新日：2018/11/06 (Tue) 16:54:44 Y.Yoneyama
    '備　考：
    Private Sub prvBatchWorkEnd()

        Dim lblnAns                     As Boolean              '結果取得(True:正常,False:異常)
        Dim lblnLotMatchFlag            As Boolean              '送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞ(True:格納済,False:未格納)
        Dim lblnCtlAns                  As Boolean              'CtlSvr2結果取得(True:正常,False:異常)
        Dim ltypBatEndWrk               As BatEndWrk            'ﾊﾞｯﾁﾛｯﾄ作業終了構造体
        Dim ltypBatLotEndList           As BatLotEndList        'ﾊﾞｯﾁﾛｯﾄ作業終了結果格納構造体
        Dim ltypCtlUpdWaitingLotList    As CtlUpWaitingLot      'CtlSvr2送信構造体
        Dim llngCnt                     As Integer              '汎用ｶｳﾝﾀ1
        Dim llngCnt2                    As Integer              '汎用ｶｳﾝﾀ2
        Dim llngEndCnt                  As Integer              '汎用ｶｳﾝﾀ3
        Dim lstrRLotID                  As String               '結果ﾛｯﾄID
        Dim lstrErrorMsgCal             As String               'ﾊﾞｯﾁ作業終了ｴﾗｰﾒｯｾｰｼﾞ集計
        Dim lstrSendResult              As String               '次工程送出結果格納(Null:次工程送出/0:中間在庫/1:完成在庫/2:組立送品)
        Dim lstrGuidMsg                 As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode             As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance            As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim ltypSpcJudge                As SpcJudge             'SPC規格値判定構造体
        Dim lblnSpcSpecchkAns           As Boolean              'SPC規格値判定結果
        Dim lstrSpcArermMsg             As String               'ｱﾗｰﾑ判定異常ﾒｯｾｰｼﾞ格納
        Dim lblnSpcJudgeSystemErr       As Boolean              'ｱﾗｰﾑ判定ｼｽﾃﾑｴﾗｰﾌﾗｸﾞ
        Dim lstrNextActionFlag          As String
        Dim lstrEleHoldFlag             As String
        Dim lstrTftHoldFlag             As String
        Dim lblnAnsNextSend             As Boolean
        Dim lstrComment                 As String

        Try
            
            
            '@**************************************************
            '@装置ﾃﾞｰﾀ(FTP同期)
            '@**************************************************
            '@FTP同期の場合
            If vsfWp.GetData(vsfWp.Row, CMvsfWpColFtpDataFlag) = CPstrFtpDataFlagOn Then
                
                '@ｵﾌﾗｲﾝFTPﾃﾞｰﾀ同期処理【lstrFTPResult:FTP送信結果】
                'lblnAns = prvblnEqftSyncRegist_Proc(lstrFTPResult, lstrWfFlag)
                '
                '@結果判定
                'If lblnAns = False Then
                '    '@ｴﾗｰの場合 (ここでは通信ｴﾗｰ等)
                '    '@FTPｻｰﾊﾞｰが死んでる場合(CLのﾛｸﾞにも出力します。)又は
                '    '@FTP送信結果がNGの場合でも作業終了続行する。
                '    '@WFﾘｽﾄが取得できない場合は致命的なｴﾗｰの為以降の処理はSTOP
                '    lstrFTPResult = CMstrNG
                '
                '    '@致命的なｴﾗｰが発生した場合(WFﾘｽﾄが取得できない)
                '    If lstrWfFlag = CMstrNG Then
                '        Exit Sub
                '    End If
                'End If
            End If

            '@確定処理したｷｬﾘｱIDを格納する為に,まず初期化
            lstrErrorMsgCal = vbNullString
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypBatEndWrk
                .strSbID = pstrSBID                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strBatchId = prvstrBatchIdLabel                    'ﾊﾞｯﾁID
                .strComments = txtWorkMemo.Text                     '作業ﾒﾓ
                .strEmpID = pstrUserID                              '作業者ID
                .strMsgVer = CMstrbat_endwrk_Ver                    'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strClassDivision = CPstrCD01                       '処理区分(01=ｸﾗｲｱﾝﾄ)
                .strEqType = vsfWp.GetData(vsfWp.Row, CMvsfWPColEqType)
                .typBLotList = New List(Of BLotList)
                
                '@ﾊﾞｯﾁ組ﾛｯﾄIDと最終更新日時を構造体へ
                For llngCnt = 1 To vsfLot.Rows.Count - 1
                
                    '@ﾛｯﾄIDがNULL以外か
                    If vsfLot.GetData(llngCnt, CMvsfLotColLotID) <> vbNullString Then
                    
                        '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞの初期化
                        lblnLotMatchFlag = False
                        
                        For llngCnt2 = 0 To .lngBLotListCnt - 1
                            
                            '@送信ﾃﾞｰﾀのﾛｯﾄﾘｽﾄに既に対象ﾛｯﾄが格納済みか
                            If .typBLotList(llngCnt2).strLotID = _
                                vsfLot.GetData(llngCnt, CMvsfLotColLotID) Then
                                
                                '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞに"True：格納済"をｾｯﾄ
                                lblnLotMatchFlag = True
                            End If
                        Next llngCnt2
                            
                        '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞが"False：格納済"か
                        If lblnLotMatchFlag = False Then
                            
                            '@ﾘｽﾄを+1する
                            .lngBLotListCnt = .lngBLotListCnt + 1
                            Dim ltypBLotListTmp As New BLotList
                            
                            ltypBLotListTmp.strLotID = _
                                vsfLot.GetData(llngCnt, CMvsfLotColLotID)
                                
                            ltypBLotListTmp.strLotLastUpdate = _
                                vsfLot.GetData(llngCnt, CMvsfLotColEditTime)
                                
                            '@ﾛｯﾄ区分に"0：TFT"をｾｯﾄ
                            ltypBLotListTmp.strLotKind = CPstrZero
                                
                            .typBLotList.Add(ltypBLotListTmp)
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
            
            
             '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If
                
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
            
            '@**************************************************
            '@取得(更新)したﾛｯﾄの最終更新日時をｸﾞﾘｯﾄﾞの列へ反映
            '@**************************************************
            With vsfLot
                For llngEndCnt = 0 To ltypBatLotEndList.lngLotEndListCnt - 1
                        
                    '@ﾛｯﾄID格納(長いから変数に退避)
                    lstrRLotID = ltypBatLotEndList.typLotEndList(llngEndCnt).strLotID
                    
                    For llngCnt = 1 To .Rows.Count - 1
                            
                        '@対象ﾛｯﾄと同じか
                        If lstrRLotID = .GetData(llngCnt, CMvsfLotColLotID) Then
                                
                            '@最終更新日時
                            .SetData(llngCnt, CMvsfLotColEditTime, _
                                    ltypBatLotEndList.typLotEndList(llngEndCnt).strLastUpdate)
                                    
                            '@処理結果ﾌﾗｸﾞ
                            .SetData(llngCnt, CMvsfLotColResultFlag, _
                                    ltypBatLotEndList.typLotEndList(llngEndCnt).strResultFlag)
                                                        
                        End If
                    Next
                Next
            End With
            
            '@**************************************************
            '@SPC判定
            '@**************************************************
            '@ｱﾗｰﾑﾒｯｾｰｼﾞ格納変数初期化
            lstrSpcArermMsg = vbNullString
            lblnSpcJudgeSystemErr = False
                    
            With vsfLot
                    
                '@ﾛｯﾄﾘｽﾄでｱﾗｰﾑ判定を実行
                For llngEndCnt = 0 To ltypBatLotEndList.lngLotEndListCnt - 1
                        
                    '@ﾛｯﾄID格納
                    lstrRLotID = ltypBatLotEndList.typLotEndList(llngEndCnt).strLotID
                        
                    '@ｸﾞﾘｯﾄﾞの行数で回して対象ﾛｯﾄと同じ行を探す
                    For llngCnt = 1 To .Rows.Count - 1
                            
                        '@対象ﾛｯﾄと同じか
                        If lstrRLotID = .GetData(llngCnt, CMvsfLotColLotID) Then
                                
                            '@SPC規格値判定実行用の構造体に情報をｾｯﾄ
                            With ltypSpcJudge
                                .strMsgVer = CMstrspc_judge___Ver                           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                                .strSbID = pstrSBID                                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                                .strLotID = vsfLot.GetData(llngCnt, CMvsfLotColLotID)       'ﾛｯﾄID
                                .strOpID = vsfLot.GetData(llngCnt, CMvsfLotColOpID)         '大工程ID
                                .strStepID = vsfLot.GetData(llngCnt, CMvsfLotColStepID)     '小工程ID
                                .strEmpID = pstrUserID                                      '作業者ID
                                .strNextLotID = .strLotID                                   '作業終了後ﾛｯﾄID
                            End With
                                
                            '@**************************************************
                            '@ SPC規格値判定ﾒｯｾｰｼﾞ送信処理呼び出し
                            '@**************************************************
                            lblnSpcSpecchkAns = pubblnSpcJudge_Sel(ltypSpcJudge)
                            
                            '@ｱﾗｰﾑ判定は失敗か
                            'If lblnSpcSpecchkAns = False Then
                            '    '@ｼｽﾃﾑｴﾗｰの場合はﾌﾗｸﾞを立てておく
                            '    ' ﾊﾞｯﾁ内の判定は一通り行い、次行程送出の前で処理を中止する
                            '    lblnSpcJudgeSystemErr = True
                            '    lstrErrLotID = lstrErrLotID + ltypSpcJudge.strLotID + " "
                            '
                            'End If
                            
                            '@**************************************************
                            '@次工程送出不可ﾒｯｾｰｼﾞ表示
                            '@ｱｸｼｮﾝ予定実行ﾌﾗｸﾞ判定
                            '@異常処理票保留、通常保留
                            '@SPC規格値判定
                            '@**************************************************
                            If prvNextNgMsg_Disp(lstrRLotID, ltypBatLotEndList.typLotEndList(llngEndCnt).strResultFlag, _
                                        CPstrHold0, CPstrHold0, ltypSpcJudge) = True Then
                                lblnSpcJudgeSystemErr = True
                            End If
                
                            '@**************************************************
                            '@次工程送出前ﾁｪｯｸ
                            '@**************************************************
                            '@ｱｸｼｮﾝ予定実行なし
                            '@SPC規格値判定結果が「正常」「SPC異常」
                            '@全保留なし(電特保留、TFT保留、異常処理票保留、通常保留)
            
                            '@ｱｸｼｮﾝ予約
                            'If lstrActionFlag <> CPstrActionFlag0 Then
                            '    lblnSpcJudgeSystemErr = True
                            'End If

                            '@SPC
                            'If Not (ltypSpcJudge.strSpecCheck = CMstrSpecCheckOK Or ltypSpcJudge.strSpecCheck = CMstrSpecCheckSPCNG) Then
                            '    lblnSpcJudgeSystemErr = True
                            'End If

                            '@その他保留
                            'If Not (lstrExcpHoldFlag = CPstrHold0 And lstrNormalHoldFlag = CPstrHold0) Then
                            '    lblnSpcJudgeSystemErr = True
                            'End If
                            
                            '@「管理NG」「規格NG」「その他NG(有効ﾃﾞｰﾀ不足など)」の場合ｴﾗｰﾒｯｾｰｼﾞを格納
                            'If ltypSpcJudge.strSpecCheck = CMstrSpecCheckSPCNG Or _
                            '    ltypSpcJudge.strSpecCheck = CMstrSpecCheckSpecNG Or _
                            '    ltypSpcJudge.strSpecCheck = CMstrSpecCheckOtherNG Then
                            '
                            '    '@ﾒｯｾｰｼﾞを退避しておく(最後にまとめて表示用)
                            '    lstrSpcArermMsg = lstrSpcArermMsg + _
                            '            ltypSpcJudge.strSpecMsgCode + vbCrLf + _
                            '            lstrRLotID + ":" + Mid$(ltypSpcJudge.strSpecMsg, 2) + vbCrLf + vbCrLf   'MIDの2は先頭の「$｣を外して改行させない為
                            'End If
                        End If
                    Next
                Next
                    
                '@ｱﾗｰﾑ判定異常があった場合ﾒｯｾｰｼﾞを表示する(まとめて表示)
                'If lstrSpcArermMsg <> vbNullString Then
                '    '@spcｻｰﾊﾞが返した、異常ﾒｯｾｰｼﾞをまとめて表示
                '    pstrDMsg = pubstrMsgReplace_Set(lstrSpcArermMsg)
                '    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Caption, True, 16)
                'End If
                    
                '@ｱﾗｰﾑ判定に失敗はないか
                If lblnSpcJudgeSystemErr = True Then
                    '@失敗がある場合処理を中止する
                        
                    '@Spcｱﾗｰﾑ判定が失敗しました。処理を中止します。
                    'pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000R, lstrErrLotID)
                    'Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Caption, True, 16)
                                    
                    Exit Sub
                End If
            End With
            
            
            '@**************************************************
            '@次工程送出
            '@**************************************************
            '@自動送信「あり」の場合
            If optLotNextSend0.Checked = True Then
            
                '@ﾛｯﾄﾘｽﾄでｱﾗｰﾑ判定を実行
                For llngEndCnt = 0 To ltypBatLotEndList.lngLotEndListCnt - 1
                        
                    '@ﾛｯﾄID格納
                    lstrRLotID = ltypBatLotEndList.typLotEndList(llngEndCnt).strLotID
                        
                    '@ｸﾞﾘｯﾄﾞの行数で回して対象ﾛｯﾄと同じ行を探す
                    For llngCnt = 1 To vsfLot.Rows.Count - 1
            
                        '@対象ﾛｯﾄと同じか
                        If lstrRLotID = vsfLot.GetData(llngCnt, CMvsfLotColLotID) Then
            

                            '@最終工程の場合
                            If vsfWp.GetData(vsfWp.Row, CMvsfWpColNextOpId) = vbNullString And _
                                vsfWp.GetData(vsfWp.Row, CMvsfWpColNextStepId) = vbNullString Then
                
                                '@=======================
                                '@ 次工程送出
                                '@=======================
                                lblnAnsNextSend = pubblnLotNextSend_Upd(CMstrlot_nextSendVer, _
                                                            ltypBatLotEndList.typLotEndList(llngEndCnt).strLotID, _
                                                            ltypBatLotEndList.typLotEndList(llngEndCnt).strLastUpdate, _
                                                            pstrUserID, _
                                                            CPstrEnableFlagFalse, _
                                                            CPstrCD24, _
                                                            , _
                                                            , _
                                                            , _
                                                            lstrNextActionFlag, _
                                                            lstrEleHoldFlag, _
                                                            lstrSendResult, _
                                                            lstrTftHoldFlag)


                                '@結果判定
                                If lblnAnsNextSend = False Then
                    
                                    '@「次工程送出に失敗しました。メニューの次工程送出から再度実行して下さい。」
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000E)
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                                    Exit Sub
                                End If
                                
                                '@完成時ﾒｯｾｰｼﾞ取得
                                Call pubLotNextSendResultPopUp(lstrSendResult, txtCarrier.Text, lstrRLotID)
                    
                                '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                Call pubVsfInfo_Disp(pstrDMsg)


                            '@最終工程ではない場合
                            Else
                    
                                '@=======================
                                '@ 次工程送出
                                '@=======================
                                lblnAnsNextSend = pubblnLotNextSend_Upd(CMstrlot_nextSendVer, _
                                                            ltypBatLotEndList.typLotEndList(llngEndCnt).strLotID, _
                                                            ltypBatLotEndList.typLotEndList(llngEndCnt).strLastUpdate, _
                                                            pstrUserID, _
                                                            CPstrEnableFlagFalse, _
                                                            , _
                                                            , _
                                                            lstrComment, _
                                                            , _
                                                            lstrNextActionFlag, _
                                                            lstrEleHoldFlag, _
                                                            lstrSendResult, _
                                                            lstrTftHoldFlag)
                    
                                '@結果判定
                                If lblnAnsNextSend = False Then
                                    '@「次工程送出に失敗しました。メニューの次工程送出から再度実行して下さい。」
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000E)
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                    Exit Sub
                                End If
                                
                                '@次工程送出結果格納(Null:次工程送出/0:中間在庫/1:完成在庫/2:組立送品)
                                If lstrSendResult <> vbNullString Then
                                        
                                    Exit Sub
                                End If
                    
                                '@更新処理の為送信構造体に状態をｾｯﾄする
                                With ltypCtlUpdWaitingLotList
                                    .strClassDivision = CPstrCD01               '処理区分(=01)
                                    .strMsgVer = CMstrctl_updwaitinglotVer      'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                                    .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                                    .strWpID = vbNullString                     'WPID(=vbNullString)
                                    .lngWaitingLotListCnt = 1                   'ﾘｽﾄｶｳﾝﾄ(=1)
                                    .typWaitingLotList = New List(Of UpWaitingLotList)
                                    Dim ltypUpWaitingLotListTmp As New UpWaitingLotList
                                                            
                                    '@作業終了Msgの応答LotIDを設定
                                    ltypUpWaitingLotListTmp.strLotID = vsfLot.GetData(llngCnt, CMvsfLotColLotID)
                                    ltypUpWaitingLotListTmp.strOpID = vsfLot.GetData(llngCnt, CMvsfLotColOpID)
                                    ltypUpWaitingLotListTmp.strStepID = vsfLot.GetData(llngCnt, CMvsfLotColStepID)
                                    ltypUpWaitingLotListTmp.strSeqNum = vbNullString

                                    .typWaitingLotList.Add(ltypUpWaitingLotListTmp)
                                End With
                    
                                '@=======================
                                '@ 処理待ちﾛｯﾄ更新処理
                                '@=======================
                                lblnCtlAns = pubblnCtlUpdWaitingLot_Upd(ltypCtlUpdWaitingLotList)
                        
                                '@結果判定
                                If lblnCtlAns = False Then
                                    Exit Sub
                                End If

                                '@ｺﾒﾝﾄは空か
                                If lstrComment = vbNullString Then
                                    '@表示ﾒｯｾｰｼﾞ変換"<TRM23I>$$次工程送出しました。キャリア[ %1 ] ロット[ %2 ]"
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0023, txtCarrier.Text, lstrRLotID)
                                    Call pubVsfInfo_Disp(pstrDMsg)

                                Else
                                    '@ﾒｯｾｰｼﾞ表示
                                    pstrDMsg = pubstrMsgReplace_Set(lstrComment)
                                    Call pubVsfInfo_Disp(pstrDMsg)
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                End If
                                                    
                                '@装置別ﾛｯﾄ一覧より呼ばれている場合、次工程送出にて装置ID、大工程、小工程が変わる為
                                '@引継ぎ構造体よりｸﾘｱする。
                                With ptypCommonInfo
                                    .strWpID = vbNullString
                                    .strWpName = vbNullString
                                    .strOpID = vbNullString
                                    .strStepID = vbNullString
                                End With
                                                                               
                                '@ｱｸｼｮﾝﾌﾗｸﾞによる分岐
                                Select Case lstrNextActionFlag
                                                    
                                    '@停止の場合
                                    Case CPstrActionFlag1
                                        '@表示ﾒｯｾｰｼﾞ変換"<TRM2SI>$$アクション予約によりロット[ %1 ] は [停止] されました。"
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, lstrRLotID, CPstrStopSt)
                                        Call pubVsfInfo_Disp(pstrDMsg)
                                                        
                                    '@保留の場合
                                    Case CPstrActionFlag2
                                        '@表示ﾒｯｾｰｼﾞ変換"<TRM2SI>$$アクション予約によりロット[ %1 ] は [保留] されました。"
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, lstrRLotID, CPstrHoldSt)
                                        Call pubVsfInfo_Disp(pstrDMsg)
                                
                                End Select
                            End If
                        End If
                    Next
                Next
            End If
                        
            '@ｷｬﾘｱIDのｸﾘｱ
            txtCarrier.Text = vbNullString
                
            '@=======================
            '@ 画面情報初期化処理
            '@=======================
            Call prvfrmxxEN02Q0_Init()
            'NSYS グリッド非活性
            VsfLot.Enabled = False
            vsfWP.Enabled = False
            
            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvBatchWorkEnd"
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

    '関数名：prvSetFocus
    '機　能：フォーム専用のフォーカスセット追加処理
    '引　数：lctlNext：フォーカス先コントロールオブジェクト
    '      ：laryCallers：呼出し元コントロールの配列
    '戻り値：なし
    '作成日：2020/03/12 (Thu) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub prvSetFocus(ByVal lctlNext As Control, ParamArray ByVal laryCallers As Control())

        Dim ldicMatchHandler        As List(Of Tuple(Of Control, CancelEventHandler))
        Dim ldicCtrlToHandler       As Dictionary(Of Control, CancelEventHandler)

        If laryCallers Is Nothing OrElse laryCallers.Count = 0 Then
            pubSetFocus(lctlNext)
            Exit Sub
        End If

        'NSYS コントロールとValidateハンドラーの組み合わせ定義
        ldicCtrlToHandler = New Dictionary(Of Control, CancelEventHandler) From { _
                { txtCarrier, AddressOf txtCarrier_Validate }, _
                { txtUnloaderCarrier, AddressOf txtUnloaderCarrier_Validate } _
            }
        ldicMatchHandler = New List(Of Tuple(Of Control, CancelEventHandler))

        If ActiveControl IsNot Nothing Then
            Dim lblnMatch As Boolean = False
            ' 呼出し元コントロールの配列に ActiveControlが含まれるか
            For Each lctlCaller As Control In laryCallers
                If ActiveControl Is lctlCaller Then
                    lblnMatch = True
                End If
                ' Validateハンドラーコントロールの判定
                If ldicCtrlToHandler.ContainsKey(lctlCaller) = True Then
                    ldicMatchHandler.Add(Tuple.Create(lctlCaller, ldicCtrlToHandler(lctlCaller)))
                End If
            Next

            If lblnMatch = False Then
                ' ActiveControlが呼び出し元と異なる場合、フォーカス移動しない (VB6互換動作)
                Exit Sub
            End If
        End If

        Try
            ' Validateをハンドリングしているコントロールの場合は、ハンドラーをはずす
            For Each lPair As Tuple(Of Control, CancelEventHandler) In ldicMatchHandler
                RemoveHandler lPair.Item1.Validating, lPair.Item2
            Next
            ' フォーカスセット
            pubSetFocus(lctlNext)
        Finally
            ' Validateハンドラーを戻す
            For Each lPair As Tuple(Of Control, CancelEventHandler) In ldicMatchHandler
                AddHandler lPair.Item1.Validating, lPair.Item2
            Next
        End Try

    End Sub

End Class
