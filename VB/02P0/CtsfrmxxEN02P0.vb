'ﾌｧｲﾙ名：xxEN02P0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：バッチ_受入在庫　メインフォーム
'作成日：2018/08/02 (Thu) 15:16:58 T.Oide
'更新日：2019/10/28 (Mon) 14:34:11 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2018-2019, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02P0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02P0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02P0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02P0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02P0)
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
    '@Private Const CMstrLocalVersion                     As String = "01.05"
    Private Const CMstrLocalVersion                     As String = "01.06"

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN02P0          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_tapeStickGrListVer           As String = "01.00"                 'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟﾘｽﾄ取得
    Private Const CMstrmas_pdlist__Ver                  As String = "03.00"                 '機種区分一覧取得
    Private Const CMstrmas_flowlistVer                  As String = "04.00"                 '種別区分一覧取得
    Private Const CMstrbataldbatchlistVer               As String = "01.00"                 'ALDﾊﾞｯﾁﾘｽﾄ取得
    Private Const CMstrinv_acptlotlistVer               As String = "05.00"                 '在庫ﾛｯﾄﾘｽﾄ
    Private Const CMstrmas_aldbatchrecipeVer            As String = "01.00"                 '防湿膜ALDﾊﾞｯﾁﾚｼﾋﾟ取得
    Private Const CMstrmas_aldbatchRegistVer            As String = "01.00"                 '防湿膜ALDﾊﾞｯﾁ情報登録
    '@↓2019/12/19 (Thu) 19:17:01 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_rsvlist_Ver                  As String = "02.01"                 '投入予定ﾛｯﾄ一覧
    Private Const CMstrlot_rsvlist_Ver                  As String = "03.00"                 '投入予定ﾛｯﾄ一覧
    '@↑2019/12/19 (Thu) 19:17:01 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrmas_definelistVer                As String = "01.00"                 'DEFINE情報取得

    '@vsfAldBatch設定
    ' 列定義
    Private Const CMlngvsfAldBatchColNo                 As Integer = 0                      '№
    Private Const CMlngvsfAldBatchColThrowinStatus      As Integer = 1                      '投入状態
    Private Const CMlngvsfAldBatchColLotId              As Integer = 2                      'ﾛｯﾄID
    Private Const CMlngvsfAldBatchColPd                 As Integer = 3                      '機種
    Private Const CMlngvsfAldBatchColWfNum              As Integer = 4                      'ｳｪﾊｰ数
    Private Const CMlngvsfAldBatchColChipNum            As Integer = 5                      'ﾁｯﾌﾟ数
    Private Const CMlngvsfAldBatchColACarrierGr         As Integer = 6                      'Aｷｬﾘｱｸﾞﾙｰﾌﾟ
    Private Const CMlngvsfAldBatchColTapeStickGr        As Integer = 7                      'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
    Private Const CMlngvsfAldBatchColACarrierNum        As Integer = 8                      'Aｷｬﾘｱ収容数
    Private Const CMlngvsfAldBatchColACarrierChipNum    As Integer = 9                      'Aｷｬﾘｱﾁｯﾌﾟ収容数(隠)
    Private Const CMlngvsfAldBatchColACarrierEmptNum    As Integer = 10                     'Aｷｬﾘｱ空きﾁｯﾌﾟ数
    Private Const CMlngvsfAldBatchColFlowClass          As Integer = 11                     '種別
    Private Const CMlngvsfAldBatchColTapeStickBatch     As Integer = 12                     'ﾃｰﾌﾟ貼りﾊﾞｯﾁID
    Private Const CMlngvsfAldBatchColTapeStickRecp      As Integer = 13                     'ﾃｰﾌﾟ貼りﾚｼﾋﾟ
    Private Const CMlngvsfAldBatchColOvenBatch          As Integer = 14                     'ｵｰﾌﾞﾝﾊﾞｯﾁID
    Private Const CMlngvsfAldBatchColOvenRecp           As Integer = 15                     'ｵｰﾌﾞﾝﾚｼﾋﾟ
    Private Const CMlngvsfAldBatchColAldBatch           As Integer = 16                     'ALDﾊﾞｯﾁID
    Private Const CMlngvsfAldBatchColAldBRecp           As Integer = 17                     'ALDﾚｼﾋﾟ

    ' 幅定義
    Private Const CMlngvsfAldBatchColWNo                As Integer = 37                     '№
    Private Const CMlngvsfAldBatchColWThrowinStatus     As Integer = 43                     '投入状態
    Private Const CMlngvsfAldBatchColWLotId             As Integer = 96                     'ﾛｯﾄID
    Private Const CMlngvsfAldBatchColWPd                As Integer = 60                     '機種
    Private Const CMlngvsfAldBatchColWWfNum             As Integer = 50                     'ｳｪﾊｰ数
    Private Const CMlngvsfAldBatchColWChipNum           As Integer = 60                     'ﾁｯﾌﾟ数
    Private Const CMlngvsfAldBatchColWTapeStickGr       As Integer = 98                     'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
    Private Const CMlngvsfAldBatchColWACarrierGr        As Integer = 84                     'Aｷｬﾘｱｸﾞﾙｰﾌﾟ
    Private Const CMlngvsfAldBatchColWACarrierNum       As Integer = 99                     'Aｷｬﾘｱ収容数(ｸﾞﾙｰﾌﾟ-ｳｪﾊｰ数(ﾁｯﾌﾟ数))
    Private Const CMlngvsfAldBatchColWACarrierChipNum   As Integer = 91                     'Aｷｬﾘｱﾁｯﾌﾟ収容数(隠)
    Private Const CMlngvsfAldBatchColWACarrierEmptNum   As Integer = 84                     'Aｷｬﾘｱ空ﾁｯﾌﾟ数
    Private Const CMlngvsfAldBatchColWFlowClass         As Integer = 47                     '種別
    Private Const CMlngvsfAldBatchColWTapeStickBatch    As Integer = 92                     'ﾃｰﾌﾟ貼りﾊﾞｯﾁID
    Private Const CMlngvsfAldBatchColWTapeStickRecp     As Integer = 87                     'ﾃｰﾌﾟ貼りﾚｼﾋﾟ
    Private Const CMlngvsfAldBatchColWOvenBatch         As Integer = 92                     'ｵｰﾌﾞﾝﾊﾞｯﾁID
    Private Const CMlngvsfAldBatchColWOvenRecp          As Integer = 87                     'ｵｰﾌﾞﾝﾚｼﾋﾟ
    Private Const CMlngvsfAldBatchColWAldBatch          As Integer = 92                     'ALDﾊﾞｯﾁID
    Private Const CMlngvsfAldBatchColWAldBRecp          As Integer = 87                     'ALDﾚｼﾋﾟ

    ' ﾀｲﾄﾙ表示
    Private Const CMstrvsfAldBatchColTNo                As String = "№"
    Private Const CMstrvsfAldBatchColThrowinStatus      As String = "投入"
    Private Const CMstrvsfAldBatchColTLotId             As String = "ロットID"
    Private Const CMstrvsfAldBatchColTPd                As String = "機種"
    Private Const CMstrvsfAldBatchColTWfNum             As String = "WF数"
    Private Const CMstrvsfAldBatchColTChipNum           As String = "CHIP数"
    Private Const CMstrvsfAldBatchColTTapeStickGr       As String = "テープ貼り" & vbCrLf & "グループ"
    Private Const CMstrvsfAldBatchColTACarrierGr        As String = "Aｷｬﾘｱ" & vbCrLf & "ｸﾞﾙｰﾌﾟ"         '隠し列
    Private Const CMstrvsfAldBatchColTACarrierNum       As String = "Aキャリア" & vbCrLf & "収容数"     '(ｸﾞﾙｰﾌﾟ-ｳｪﾊｰ数(ﾁｯﾌﾟ数))
    Private Const CMstrvsfAldBatchColTACarrierChipNum   As String = "AｷｬﾘｱCHIP" & vbCrLf & "収容数(隠)" '隠し列(Aﾄﾚｰ収容数xｳｪﾊｰ数)
    Private Const CMstrvsfAldBatchColTACarrierEmptNum   As String = "Aキャリア" & vbCrLf & "空CHIP数"
    Private Const CMstrvsfAldBatchColTFlowClass         As String = "種別"
    Private Const CMstrvsfAldBatchColTTapeStickBatch    As String = "テープ貼り" & vbCrLf & "バッチID"
    Private Const CMstrvsfAldBatchColTTapeStickRecp     As String = "テープ貼り" & vbCrLf & "レシピ"
    Private Const CMstrvsfAldBatchColTOvenBatch         As String = "オーブン" & vbCrLf & "バッチID"
    Private Const CMstrvsfAldBatchColTOvenRecp          As String = "オーブン" & vbCrLf & "レシピ"
    Private Const CMstrvsfAldBatchColTAldBatch          As String = "ALD" & vbCrLf & "バッチID"
    Private Const CMstrvsfAldBatchColTAldBRecp          As String = "ALD" & vbCrLf & "レシピ"

    '@vsfInvLotの設定
    ' 列定義
    Private Const CMlngvsfInvLotColNo                   As Integer = 0                      '№
    Private Const CMlngvsfInvLotColInfo                 As Integer = 1                      '保留 or ﾊﾞｯﾁの情報表示
    Private Const CMlngvsfInvLotColInvDate              As Integer = 2                      '受入日
    Private Const CMlngvsfInvLotColLotID                As Integer = 3                      'ﾛｯﾄID
    Private Const CMlngvsfInvLotColFlowClass            As Integer = 4                      '種別
    Private Const CMlngvsfInvLotColPriority             As Integer = 5                      '優先度
    Private Const CMlngvsfInvLotColPd                   As Integer = 6                      '機種
    Private Const CMlngvsfInvLotColWfNum                As Integer = 7                      'ｳｪﾊｰ数
    Private Const CMlngvsfInvLotColChipNum              As Integer = 8                      'ﾁｯﾌﾟ数
    Private Const CMlngvsfInvLotColTapeStickGr          As Integer = 9                      'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
    Private Const CMlngvsfInvLotColStagnateTerm         As Integer = 10                     '停滞時間
    Private Const CMlngvsfInvLotColComments             As Integer = 11                     'ｺﾒﾝﾄ
    Private Const CMlngvsfInvLotColHoldTerm             As Integer = 12                     '保留期間
    Private Const CMlngvsfInvLotColHoldEmpId            As Integer = 13                     '保留担当者
    Private Const CMlngvsfInvLotColHoldReason           As Integer = 14                     '保留理由
    Private Const CMlngvsfInvLotColEditTime             As Integer = 15                     '更新日時

    ' 幅定義
    Private Const CMlngvsfInvLotColWNo                  As Integer = 37                     '№
    Private Const CMlngvsfInvLotColWInfo                As Integer = 28                     '保留 or ﾊﾞｯﾁの情報表示
    Private Const CMlngvsfInvLotColWInvDate             As Integer = 105                    '受入日
    Private Const CMlngvsfInvLotColWLotID               As Integer = 96                     'ﾛｯﾄID
    Private Const CMlngvsfInvLotColWFlowClass           As Integer = 47                     '種別
    Private Const CMlngvsfInvLotColWPriority            As Integer = 39                     '優先度
    Private Const CMlngvsfInvLotColWPd                  As Integer = 60                     '機種
    Private Const CMlngvsfInvLotColWWfNum               As Integer = 50                     'ｳｪﾊｰ数
    Private Const CMlngvsfInvLotColWChipNum             As Integer = 60                     'ﾁｯﾌﾟ数
    Private Const CMlngvsfInvLotColWTapeStickGr         As Integer = 98                     'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
    Private Const CMlngvsfInvLotColWStagnateTerm        As Integer = 109                    '停滞時間(在庫に入ってからの時間)
    Private Const CMlngvsfInvLotColWComments            As Integer = 109                    'ｺﾒﾝﾄ
    Private Const CMlngvsfInvLotColWHoldTerm            As Integer = 109                    '保留期間(保留されてからの時間)
    Private Const CMlngvsfInvLotColWHoldEmpId           As Integer = 119                    '保留担当者
    Private Const CMlngvsfInvLotColWHoldReason          As Integer = 109                    '保留理由
    Private Const CMlngvsfInvLotColWEditTime            As Integer = 109                    '更新日時

    '@ﾀｲﾄﾙ表示
    Private Const CMlngvsfInvLotColTNo                  As String = "№"
    Private Const CMlngvsfInvLotColTInfo                As String = ""
    Private Const CMlngvsfInvLotColTInvDate             As String = "受入日"
    Private Const CMlngvsfInvLotColTThrowinDate         As String = "投入予定日"
    Private Const CMlngvsfInvLotColTLotID               As String = "ロットID"
    Private Const CMlngvsfInvLotColTFlowClass           As String = "種別"
    Private Const CMlngvsfInvLotColTPriority            As String = "優"
    Private Const CMlngvsfInvLotColTPd                  As String = "機種"
    Private Const CMlngvsfInvLotColTWfNum               As String = "WF数"
    Private Const CMlngvsfInvLotColTChipNum             As String = "CHIP数"
    Private Const CMlngvsfInvLotColTTapeStickGr         As String = "テープ貼り" & vbCrLf & "グループ"
    Private Const CMlngvsfInvLotColTStagnateTerm        As String = "停滞時間"
    Private Const CMlngvsfInvLotColTComments            As String = "コメント"
    Private Const CMlngvsfInvLotColTHoldTerm            As String = "保留期間"
    Private Const CMlngvsfInvLotColTHoldEmpId           As String = "保留担当者"
    Private Const CMlngvsfInvLotColTHoldReason          As String = "保留理由"
    Private Const CMlngvsfInvLotColTEditTime            As String = "更新日時"

    '@ｸﾞﾘｯﾄﾞ共通の定数宣言
    Private Const CMlngVsfRowTitle                  As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                  As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                 As Integer = 11                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                   As Integer = 35                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                    As Integer = 24                     '1ｽﾛｯﾄの高さ
    Private Const CMstrLotHoldFlgOn                 As String = "1"                     '保留ﾛｯﾄﾌﾗｸﾞON
    Private Const CMlngFrozenColsBatch              As Integer = 8                      '固定列(ﾊﾞｯﾁ)
    Private Const CMlngFrozenColsInv                As Integer = 8                      '固定列(受入在庫)
    Private Const CMlngvsfColNo                     As Integer = 0                      '№
    Private Const CMlngNotFind                      As Integer = -1                     'FindRowして見つからない場合の値

    '@ﾓﾆﾀｵﾌﾟｼｮﾝ
    Private Const CMlngMoniterAri                   As Integer = 0                     '有
    Private Const CMlngMoniterNasi                  As Integer = 1                     '無

    '@製品区分ｵﾌﾟｼｮﾝ
    Private Const CMlngProduct                      As Integer = 0                     '製品
    Private Const CMlngNoProduct                    As Integer = 1                     'ﾀﾞﾐｰ、ﾓﾆﾀｰ、品確


    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                  As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols                  As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbDispCol4                  As Integer = 4                      'ｸﾞﾘｯﾄﾞ表示列数=4
    Private Const CMlngCMbSelectMode                As Integer = 1                      '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMlngCmbRowHeight                 As Integer = 18                     'ﾘｽﾄ行の高さ
    Private Const CMstrCmbAddedComment              As String = " 項目選択"             '表示 文字列
    Private Const CMstrCmbAddedCommentNone          As String = "0 項目選択"            '表示 文字列「選択なし」
    Private Const CMlngCmbGridCol0                  As Integer = 0                      '選択列数
    Private Const CMlngCmbValueCol0                 As Integer = 0                      '値取得列=0
    Private Const CMlngCmbFirstIndex                As Integer = 0                      'ﾘｽﾄの先頭表示用
    Private Const CMstrCmbCheckOn                   As String = "1"                     'ﾁｪｯｸON
    Private Const CMstrCmbCheckOff                  As String = "0"                     'ﾁｪｯｸOff

    '@ﾌｫｰﾏｯﾄ定数宣言
    Private Const CMlngFormatStart                  As Integer = 1                      'Mid取得先頭数(=1)
    Private Const CMlngFormatMid9                   As Integer = 9                      'Mid取得=9文字

    '@ﾁｪｯｸON/OFF
    Private Const CMlngChkOFF                       As Integer = 0                      'ﾁｪｯｸOFF
    Private Const CMlngChkON                        As Integer = 1                      'ﾁｪｯｸON

    '@その他
    '@↓2019/10/28 (Mon) 13:47:29 T.Oide **************************************************
    Private Const CMlngACriierMaxNum                As Integer = 5                      'Aｷｬﾘｱの使用制限
    '@↑2019/10/28 (Mon) 13:47:29 T.Oide **************************************************
    Private Const CMlngMoniUsesWfNum                As Integer = 12                     'ﾓﾆﾀ使用時のｳｪﾊｰ(Aﾄﾚｰ)数
    Private Const CMlngMoniUnUsesWfNum              As Integer = 13                     'ﾓﾆﾀ未使用時のｳｪﾊｰ(Aﾄﾚｰ)数
    Private Const CMstrMoniter                      As String = "モニタ:"               'モニタ有無表示用
    Private Const CMstrMoniterAri                   As String = "有"                    'モニタ有無表示用
    Private Const CMstrMoniterNasi                  As String = "無"                    'モニタ有無表示用
    Private Const CMstrProduct                      As String = "PRODUCT"               'ﾊﾞｯﾁ流動区分判定用
    Private Const CMstrQuality                      As String = "QUALITY"               'ﾊﾞｯﾁ流動区分判定用
    Private Const CMstrBatchFlowClassPR             As String = "製品"                  'ﾊﾞｯﾁ流動区分表示用
    Private Const CMstrBatchFlowClassQU             As String = "品確"                  'ﾊﾞｯﾁ流動区分表示用
    Private Const CMstrBatchNew                     As String = "新規作成"              'ﾊﾞｯﾁ新規作成用
    Private Const CMstrThrowInDate                  As String = "[投入予定日]"          'ﾊﾞｯﾁｺﾝﾎﾞ表示用
    Private Const CMstrMoniBatchClass               As String = "[モニタ バッチ区分]"   'ﾊﾞｯﾁｺﾝﾎﾞ表示用
    Private Const CMstrMoniBatchStatus              As String = "[バッチ状態 / 編集可否]"   'ﾊﾞｯﾁｺﾝﾎﾞ表示用
    Private Const CMstrACarrier                     As String = "Aキャリア"             'グリッド表示用
    Private Const CmlngACrrierGr01                  As String = "01"                    'Aｷｬﾘｱｸﾞﾙｰﾌﾟ初期値
    Private Const CmlngACrrierGrFormat              As String = "0#"                    'Aｷｬﾘｱｸﾞﾙｰﾌﾟﾌｫｰﾏｯﾄ
    Private Const CmstrBatchString                  As String = "バッチ情報"            'ﾒｯｾｰｼﾞ表示用
    Private Const CmstrBatchStatusEdit              As String = "0"                     'ﾊﾞｯﾁｽﾃｰﾀｽ編集中
    Private Const CmstrBatchStatusThrowInWaite      As String = "1"                     'ﾊﾞｯﾁｽﾃｰﾀｽ投入待ち
    Private Const CmstrBatchStatusThrowIn           As String = "2"                     'ﾊﾞｯﾁｽﾃｰﾀｽ投入済
    Private Const CmstrBatchStatusThrowInEdit       As String = "3"                     'ﾊﾞｯﾁｽﾃｰﾀｽ再編集
    Private Const CmstrBatchStatusBatchOut          As String = "9"                     'ﾊﾞｯﾁｽﾃｰﾀｽ終了
    Private Const CmstrLotStatusThrowinWait         As String = "0"                     'ﾛｯﾄ投入待ちｽﾃｰﾀｽ
    Private Const CmstrBatchStatusHensyu            As String = "編集中"                'DBﾃﾞｰﾀの編集中(画面の編集中はmblnEditFlagでみること)
    Private Const CmstrBatchStatusTonyuMachi        As String = "投入待ち"
    Private Const CmstrBatchStatusTonyu             As String = "投入済"
    Private Const CmstrBatchStatusSaihensyu         As String = "再編集"
    Private Const CmstrBatchStatusSyuryou           As String = "終了"
    Private Const CmstrBatchDelString               As String = "バッチ削除"            'ﾒｯｾｰｼﾞ表示用
    Private Const CmstrBatchEditString              As String = "バッチ編集"            'ﾒｯｾｰｼﾞ表示用
    Private Const CmstrThlowinStatusMi              As String = "未"                    '投入状態
    Private Const CmstrThlowinStatusSumi            As String = "済"                    '投入状態
    Private Const CmstrDivLotUe                     As String = "上"                    'ﾛｯﾄ分割が上で行われている
    Private Const CmstrDivLotSita                   As String = "下"                    'ﾛｯﾄ分割が下で行われている
    Private Const CMstrOK                           As String = "OK"                    'OK


    '@Defineﾃｰﾌﾞﾙ定義
    Private Const CmstrAldMonitorCount              As String = "ALD_MONITOR_COUNT"     'ALDﾓﾆﾀｰ数(ｳｪﾊｰorﾁｯﾌﾟ)
    Private Const CmstrAldDummyCount                As String = "ALD_DUMMY_COUNT"       'ALDのﾀﾞﾐｰﾁｯﾌﾟｶｳﾝﾄ数
    Private Const CmstrWfCount                      As String = "WF_COUNT"              'ｳｪﾊｰ数
    Private Const CmstrChipCount                    As String = "CHIP_COUNT"            'ﾁｯﾌﾟ数

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mtypTapeStickList                       As TapeStickGrList          'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟﾘｽﾄ
    Private mtypPdList                              As List(Of ProductList)     '機種一覧格納用
    Private mlngPdListCnt                           As Integer                  '機種一覧ｶｳﾝﾄ
    Private mtypDivisionList                        As List(Of DivisionList)    '種別一覧格納用
    Private mlngDivisionListCnt                     As Integer                  '種別一覧ｶｳﾝﾄ
    Private mtypAldBatchList                        As typAldBatchList          'ALDﾊﾞｯﾁﾘｽﾄ
    Private mvrnClipSetText                         As List(Of String)          '[↑]の内容格納
    Private mblnEditFlag                            As Boolean                  '編集ﾌﾗｸﾞ
    Private mblnVvsfAldBatchGotFocus                As Boolean                  'ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞのﾌｫｰｶｽ
    Private mblnVsfInvLotGotFocus                   As Boolean                  '受入在庫ｸﾞﾘｯﾄﾞのﾌｫｰｶｽ
    Private mtypeAldBatchRecipe                     As typAldBatchRecipeList    '防湿膜ALDの「ﾃｰﾌﾟ貼り」「ｵｰﾌﾞﾝ」「ALD」ﾚｼﾋﾟを格納
    Private mblnEventCancelFlag                     As Boolean                  'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ
    Private mstrBatchId                             As String                   'ﾊﾞｯﾁｺﾝﾎﾞ退避用
    Private mlngMoQuWfNum                           As Integer                  'ﾓﾆﾀｰ、品確のAﾄﾚｰ数
    Private mlngMoQuChipNum                         As Integer                  'ﾓﾆﾀｰ、品確ﾛｯﾄのﾁｯﾌﾟ数
    Private mlngDummyChipNum                       As Integer                  ' = 0                         'ﾀﾞﾐｰﾛｯﾄのﾁｯﾌﾟ数
    Private buttonProcessing                        As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                  'NSYS WindowCloseフラグ
    Private mtypVsfAldBatchFocusBackColor           As Color                    'NSYS vsfAldBatchのフォーカスの背景色
    Private mtypVsfAldBatchFocusForeColor           As Color                    'NSYS vsfAldBatchのフォーカスの前景色
    Private mintTotalBatchChipCnt                   As Integer


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
    '作成日：2018/08/27 (Mon) 13:29:12 T.Oide
    '更新日：2018/08/27 (Mon)
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02P0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
                
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            'NSYS デザイナーで指定された色を保存
            mtypVsfAldBatchFocusBackColor = vsfAldBatch.Styles.Focus.BackColor
            mtypVsfAldBatchFocusForeColor = vsfAldBatch.Styles.Focus.ForeColor
            
            'NSYS コンボボックスの背景色が灰色になるため、白を設定
            cmbAldBatch.BackColor = SystemColors.Window
            cmbTapStickGr.BackColor = SystemColors.Window
            cmbPD.BackColor = SystemColors.Window
            cmbFlowClass.BackColor = SystemColors.Window
            
            '@画面情報の初期化
            Call prvfrmxxEN02P0_Init()

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            pblnFormLoad = False

            '@ﾀﾞﾐｰ、ﾓﾆﾀｰﾛｯﾄのﾁｯﾌﾟ数取得
            If prvMonitorNumSel = False Then
                Exit Sub
            End If

            '@初期化時のデータ取得
            If prvInitDataSelDisp = False Then
                Exit Sub
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
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown

        Try
            'NSYS 千歳工程QA No.114により、イベントタイミングを初回表示時だけにする。→ Shown イベントに変更
            
            '@受入在庫情報取得
            Call cmdNowList_Click(cmdNowList, EventArgs.Empty)

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐
            If pblnFormLoad = False Then

                '@ﾌﾗｸﾞを戻す
                pblnFormLoad = True

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose

            End If
            
            '@ﾎﾞﾀﾝの有効/無効制御
            Call prvBtnCtl()
            
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

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbAldBatch_Change
    '機　能：選択したﾊﾞｯﾁの情報をﾊﾞｯﾁｸﾞﾘｯﾄﾞに表示する
    '引　数：なし
    '戻り値：
    '作成日：2018/08/07 (Tue) 13:34:39 T.Oide
    '更新日：2019/08/06 (Tue) 16:08:17 T.Oide
    '備　考：
    Private Sub cmbAldBatch_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbAldBatch.Change

        Try
            
            '@ﾌｫｰﾑﾛｰﾄﾞ中は処理しない
            If pblnFormLoad = False Then
                Exit Sub
            End If
            
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙ中は処理しない
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If

            'NSYS 編集中の場合
            If mblnEditFlag = True Then
                'NSYS 変更された場合(キーボードの「N」で確認メッセージを閉じた後、破棄しますか？を再び表示しない為の判定)
                If cmbAldBatch.Text <> mstrBatchId Then
                    '@編集中ﾁｪｯｸ
                    If prvEditCheck = False Then
                        mblnEventCancelFlag = True
                        'ﾊﾞｯﾁIDを元に戻して終了
                        cmbAldBatch.Text = mstrBatchId
                        mblnEventCancelFlag = False
                        Exit Sub
                    End If
                Else
                    'NSYS 変更されなかった場合は抜ける
                    Exit Sub
                End If
            End If
            
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙ設定
            mblnEventCancelFlag = True
            
            If cmbAldBatch.Text = CMstrBatchNew Then
                
                '@新規作成の場合､ｸﾞﾘｯﾄﾞ初期化
                Call prvvGrid_Init(vsfAldBatch, False)
                
                '@投入予定日初期化
                dtpThrowInDate.Value = vbNullString
                
                '@モニタ初期化
                optMoni0.Enabled = True
                
                '@バッチ流動区分初期化
                labBatchFlowClass.Text = vbNullString
                
                '@状態初期化
                labStatus.Text = vbNullString
                
        '@↓2019/08/06 (Tue) 16:08:11 T.Oide  **************************************************
                '@編集可否初期化
                lblEditable.Text = vbNullString
        '@↑2019/08/06 (Tue) 16:08:11 T.Oide  **************************************************
                        
                '@範囲選択可
                vsfAldBatch.SelectionMode = SelectionModeEnum.ListBox
                
                '@ﾊｲﾗｲﾄする
                vsfAldBatch.HighLight = HighLightEnum.WithFocus
                vsfAldBatch.Styles.Focus.BackColor = mtypVsfAldBatchFocusBackColor
                vsfAldBatch.Styles.Focus.ForeColor = mtypVsfAldBatchFocusForeColor

            Else
                '@既存ﾊﾞｯﾁ情報の場合
                ' ﾊﾞｯﾁの情報をﾊﾞｯﾁｸﾞﾘｯﾄﾞに表示する
                Call prvvsfAldBatch_Disp()
                
                '@範囲選択不可
                vsfAldBatch.SelectionMode = SelectionModeEnum.Row
                
                '@ﾊｲﾗｲﾄしない(ﾏｰｼﾞしたｾﾙをﾊｲﾗｲﾄすると見栄えが悪いので)
                vsfAldBatch.HighLight = HighLightEnum.Never
                'NSYS Focusセルの背景色と文字色の指定を解除する(無指定は透過になる)
                With vsfAldBatch
                    .Styles.Focus.DefinedElements = (.Styles.Focus.DefinedElements And Not StyleElementFlags.BackColor And Not StyleElementFlags.ForeColor)
                End With
            
            End If

            '@ﾊﾞｯﾁID退避
            mstrBatchId = cmbAldBatch.Value

            If mblnEditFlag = True Then
                '@受入在庫情報取得
                Call cmdNowList_Click(cmdNowList, EventArgs.Empty)
            End If

            '@編集中ではない
            mblnEditFlag = False

            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙ戻し
            mblnEventCancelFlag = False

            If vsfAldBatch.Rows.Count <= vsfAldBatch.Rows.Fixed Then
                vsfAldBatch.Enabled = False
            End If

            '@ﾎﾞﾀﾝ有効/無効制御
            Call prvBtnCtl()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbAldBatch_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpThrowInDate_Change
    '機　能：ｶﾚﾝﾀﾞｰ変更時のﾎﾞﾀﾝ有効/無効制御
    '引　数：なし
    '戻り値：
    '作成日：2018/08/24 (Fri) 13:52:27 T.Oide
    '更新日：2018/08/24 (Fri) 13:52:27
    '備　考：
    Private Sub dtpThrowInDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles dtpThrowInDate.Change

        Try
            
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙ中は処理しない
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            '@画面起動最中は編集中にしない
            ' 通常の画面操作では編集中にする
            If pblnFormLoad = True Then
                '@編集中にする
                mblnEditFlag = True
            End If
            
            '@ﾎﾞﾀﾝ有効/無効制御
            Call prvBtnCtl()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "dtpThrowInDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optMoni_Click
    '機　能：ﾓﾆﾀｰﾁｪｯｸ変更時に「Aｷｬﾘｱ収容数」「Aｷｬﾘｱ収容数(隠)」「Aｷｬﾘｱ空CHIP数」の数を再計算する
    '引　数：Index：
    '戻り値：
    '作成日：2018/08/24 (Fri) 13:52:31 T.Oide
    '更新日：2018/08/24 (Fri) 13:52:31
    '備　考：
    Private Sub optMoni_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optMoni0.CheckedChanged, optMoni1.CheckedChanged

        Dim llngAns             As Boolean
        Dim llngCnt             As Integer
        Dim lstrTapeStickGr     As String
        Dim lstrFlowClass       As String
        Dim lngACrrierChipNum   As Integer
        Dim lstrFindLotId       As String
        Dim llngFindRow         As List(Of Integer) '分割したﾛｯﾄを削除する場合に行を覚えておく
        Dim llngFindCnt         As Integer          '上記配列の個数
        Dim llngFindLotChipNum  As Integer
        Dim llngtmpFindRow      As Integer

        Try
            
            '@ﾌｫｰﾑﾛｰﾄﾞ中は処理しない
            If pblnFormLoad = False Then
                Exit Sub
            End If
            
            '@ｷｬﾝｾﾙﾌﾗｸﾞはTreuか
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            If sender.Checked = False Then
                Exit Sub
            End If

            With vsfAldBatch
                
                '@ﾏｰｼﾞしているか（既にAｷｬﾘｱｸﾞﾙｰﾌﾟ設定しているか）
                '@解除していいか?ﾒｯｾｰｼﾞを表示する
                If .Cols(CMlngvsfAldBatchColTapeStickGr).AllowMerging = True Then
            
                    '@「$$ モニター設定を変更すると製品のAキャリア収納数が変更になるため、" & _
                    '    $ 設定済の同一Aキャリア設定を解除しますがよろしいですか?"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0153)
                    llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                    
                    '@要求確認
                    If llngAns = vbNo Then          '内容破棄しない
                        Exit Sub
                    End If
                    
        '-------------------------------------------------------------------------------------------------------------------
                    '@OKならﾏｰｼﾞ解除を実行
                    Call prvVsfGridMergeCol(False)
                    
                    '@ｸﾞﾘｯﾄﾞを回す
                    llngFindCnt = 0
                    llngFindRow = New List(Of Integer)
                    For llngCnt = 1 To .Rows.Count - 1
                        .SetData(llngCnt, CMlngvsfAldBatchColACarrierGr, vbNullString)            'Aｷｬﾘｱｸﾞﾙｰﾌﾟｸﾘｱ
                        .SetData(llngCnt, CMlngvsfAldBatchColACarrierEmptNum, vbNullString)       'Aｷｬﾘｱ空ﾁｯﾌﾟ数ｸﾘｱ
                        
                        '@分割ﾛｯﾄがある場合ﾛｯﾄを戻す
                        If .GetCellRange(llngCnt, CMlngvsfAldBatchColLotId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange) Then
                        
                            '@ﾛｯﾄIDを退避
                            lstrFindLotId = .GetData(llngCnt, CMlngvsfAldBatchColLotId)
                            
                            '@分割相手を探す
                            llngtmpFindRow = .FindRow(lstrFindLotId, llngCnt + 1, CMlngvsfAldBatchColLotId, False)
                            
                            '@見つかったか(見つからない場合←削除対象の行なので何もしない)
                            If llngtmpFindRow <> CMlngNotFind Then
                            
                                '@見つかった場合
                                llngFindCnt = llngFindCnt + 1
                                llngFindRow.Add(llngtmpFindRow)
                            
                                '@分割相手のﾁｯﾌﾟ数格納
                                llngFindLotChipNum = .GetData(llngtmpFindRow, CMlngvsfAldBatchColChipNum)
                                                    
                                '@自分に数を足す
                                .SetData(llngCnt, CMlngvsfAldBatchColChipNum, _
                                    CLng(.GetData(llngCnt, CMlngvsfAldBatchColChipNum)) + llngFindLotChipNum)
                                
                                '@背景色を白に戻す
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngEnableTrueColor")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                                Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfAldBatchColNo, _
                                                       llngCnt, CMlngvsfAldBatchColChipNum)
                                cellRange.Style = newStyle
                            End If
                            
                        End If
                    Next
                    
                    '@削除する列を消す
                    .Redraw = False
                    For llngCnt = 0 To llngFindCnt - 1
                        '@分割相手を削除
                        .RemoveItem(llngFindRow(llngCnt))
                    Next
                    .Redraw = True
        '-------------------------------------------------------------------------------------------------------
                End If
                
                '@Aｷｬﾘｱ収容数、AｷｬﾘｱChip収容数(隠)を更新する
                '@ｸﾞﾘｯﾄﾞを回す
                For llngCnt = 1 To .Rows.Count - 1
                
                    '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ格納
                    lstrTapeStickGr = .GetData(llngCnt, CMlngvsfAldBatchColTapeStickGr)
                    lstrFlowClass = .GetData(llngCnt, CMlngvsfAldBatchColFlowClass)
                         
                    '@Aｷｬﾘｱ収納数、AｷｬﾘｱCHIP数を計算して表示
                    lngACrrierChipNum = 0
                    .SetData(llngCnt, CMlngvsfAldBatchColACarrierNum, _
                                prvACarrierNum(lstrTapeStickGr, lstrFlowClass, lngACrrierChipNum))  'Aｷｬﾘｱ収容数
                    .SetData(llngCnt, CMlngvsfAldBatchColACarrierChipNum, lngACrrierChipNum)        'Aｷｬﾘｱﾁｯﾌﾟ収容数(隠)
                Next

            End With

            '@編集中にする
            mblnEditFlag = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optMoni_Click"
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
    '作成日：2018/08/07 (Tue) 11:47:43 T.Oide
    '更新日：2018/08/07 (Tue) 11:47:43
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm             As Boolean              '開放結果格納

        Try

            '@編集中ﾁｪｯｸ
            If prvEditCheck = False Then
                e.Cancel = True
                Exit Sub
            End If

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, EventArgs.Empty)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

            '@ActInitﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合

                '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                lblnAnsTerm = pubblnAct_Term
                
                '@ACTｵﾌﾞｼﾞｪｸﾄ開放処理が正常に行われたか
                If lblnAnsTerm = True Then
                    '@処理なし(ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了)
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

    '関数名：optClass_Click
    '機　能：製品区分のｵﾌﾟｼｮﾝ変更
    '引　数：Index：0：製品、1：ﾀﾞﾐｰ、ﾓﾆﾀｰ、品確
    '戻り値：
    '作成日：2018/11/05 (Mon) 14:40:41 T.Oide
    '更新日：2018/11/05 (Mon) 14:40:41
    '備　考：
    Private Sub optClass_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optClass0.CheckedChanged, optClass1.CheckedChanged

        Try
            
            If sender.Checked = False Then
                Exit Sub
            End If

            '@製品か
            If sender Is optClass0 Then
            
                '@製品の場合、検索条件有効
                cmbTapStickGr.Enabled = True
                cmbPD.Enabled = True
                cmbFlowClass.Enabled = True
            Else
            
                '@ﾓﾆﾀｰ・ﾀﾞﾐｰ・品確の場合、検索条件無効
                cmbTapStickGr.Enabled = False
                cmbPD.Enabled = False
                cmbFlowClass.Enabled = False
            
            
            End If
            
            '@受入在庫ｸﾞﾘｯﾄﾞ初期化
            Call prvvGrid_Init(vsfInvLot, False)

            '@最新取得
            Call cmdNowList_Click(cmdNowList, EventArgs.Empty)

            If vsfInvLot.Rows.Count <= vsfInvLot.Rows.Fixed Then
                vsfInvLot.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optClass_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbTapStickGr_Change
    '機　能：ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ変更で受入在庫ｸﾘｱ
    '引　数：なし
    '戻り値：
    '作成日：2018/08/15 (Wed) 08:27:40 T.Oide
    '更新日：2018/08/15 (Wed) 08:27:40
    '備　考：
    Private Sub cmbTapStickGr_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTapStickGr.Change

        Try
            
            '@↓2019/10/28 (Mon) 13:05:17 T.Oide **************************************************
            '@起動中は処理しない
            If pblnFormLoad = False Then
                Exit Sub
            End If
            '@↑2019/10/28 (Mon) 13:05:17 T.Oide **************************************************
            
            '@受入在庫ｸﾞﾘｯﾄﾞ初期化
            Call prvvGrid_Init(vsfInvLot)
            
            '@最新取得
            Call cmdNowList_Click(cmdNowList, EventArgs.Empty)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbTapStickGr_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbPd_Change
    '機　能：機種変更で受入在庫ｸﾘｱ
    '引　数：なし
    '戻り値：
    '作成日：2018/08/15 (Wed) 08:30:13 T.Oide
    '更新日：2018/08/15 (Wed) 08:30:13
    '備　考：
    Private Sub cmbPd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.Change

        Try
            
            '@↓2019/10/28 (Mon) 13:05:17 T.Oide **************************************************
            '@起動中は処理しない
            If pblnFormLoad = False Then
                Exit Sub
            End If
            '@↑2019/10/28 (Mon) 13:05:17 T.Oide **************************************************
            
            '@受入在庫ｸﾞﾘｯﾄﾞ初期化
            Call prvvGrid_Init(vsfInvLot)
            
            '@最新取得
            Call cmdNowList_Click(cmdNowList, EventArgs.Empty)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPd_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbFlowClass_Change
    '機　能：種別変更で受入在庫ｸﾘｱ
    '引　数：なし
    '戻り値：
    '作成日：2018/08/15 (Wed) 08:30:07 T.Oide
    '更新日：2018/08/15 (Wed) 08:30:07
    '備　考：
    Private Sub cmbFlowClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFlowClass.Change

        Try
            
            '@↓2019/10/28 (Mon) 13:05:17 T.Oide **************************************************
            '@起動中は処理しない
            If pblnFormLoad = False Then
                Exit Sub
            End If
            '@↑2019/10/28 (Mon) 13:05:17 T.Oide **************************************************
            
            '@受入在庫ｸﾞﾘｯﾄﾞ初期化
            Call prvvGrid_Init(vsfInvLot)

            '@最新取得
            Call cmdNowList_Click(cmdNowList, EventArgs.Empty)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbFlowClass_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfAldBatch_Click
    '機　能：ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞ選択時
    '引　数：なし
    '戻り値：
    '作成日：2018/08/18 (Sat) 11:54:55 T.Oide
    '更新日：2018/08/18 (Sat) 11:54:55
    '備　考：
    Private Sub vsfAldBatch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfAldBatch.Click

        Try
            
            '@ﾎﾞﾀﾝの有効/無効制御
            Call prvBtnCtl()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfAldBatch_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfAldBatch_AfterSelChange
    '機　能：ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞ選択時
    '引　数：OldRowSel：
    '　　　：OldColSel：
    '　　　：NewRowSel：
    '　　　：NewColSel：
    '戻り値：
    '作成日：2018/08/18 (Sat) 14:10:40 T.Oide
    '更新日：2018/08/18 (Sat) 14:10:40
    '備　考：
    Private Sub vsfAldBatch_AfterSelChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfAldBatch.AfterSelChange
        
        Try
            
            '@ﾎﾞﾀﾝの有効/無効制御
            mblnVvsfAldBatchGotFocus = True
            Call prvBtnCtl()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfAldBatch_AfterSelChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()


        End Try
    End Sub

    '関数名：vsfAldBatch_GotFocus
    '機　能：ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞにﾌｫｰｶｽがある時だけ「↓」を押せるようにする
    '引　数：なし
    '戻り値：
    '作成日：2018/08/18 (Sat) 13:02:14 T.Oide
    '更新日：2018/08/18 (Sat) 13:02:14
    '備　考：
    Private Sub vsfAldBatch_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfAldBatch.Enter

        Try

            '@ﾎﾞﾀﾝ有効/無効制御
            mblnVvsfAldBatchGotFocus = True
            Call prvBtnCtl()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfAldBatch_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfInvLot_AfterSelChange
    '機　能：受入在庫ﾛｯﾄ選択時
    '引　数：OldRowSel：
    '　　　：OldColSel：
    '　　　：NewRowSel：
    '　　　：NewColSel：
    '戻り値：
    '作成日：2018/08/18 (Sat) 14:11:33 T.Oide
    '更新日：2018/08/18 (Sat) 14:11:33
    '備　考：
    Private Sub vsfInvLot_AfterSelChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfInvLot.AfterSelChange

        Try

            '@ﾎﾞﾀﾝの有効/無効制御
            mblnVsfInvLotGotFocus = True
            Call prvBtnCtl()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfInvLot_AfterSelChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfInvLot_GotFocus
    '機　能：受入在庫ｸﾞﾘｯﾄﾞにﾌｫｰｶｽがある時だけ「↑」を押せるようにする
    '引　数：なし
    '戻り値：
    '作成日：2018/08/18 (Sat) 13:02:14 T.Oide
    '更新日：2018/08/18 (Sat) 13:02:14
    '備　考：
    Private Sub vsfInvLot_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfInvLot.Enter

        Try

            '@ﾎﾞﾀﾝ有効/無効制御
            mblnVsfInvLotGotFocus = True
            Call prvBtnCtl()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfInvLot_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowList_Click
    '機　能：受入在庫-最新取得
    '引　数：なし
    '戻り値：
    '作成日：2018/11/05 (Mon) 16:15:35 T.Oide
    '更新日：2018/11/05 (Mon) 16:15:35
    '備　考：
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click

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

            '@ﾌｫｰﾑのﾛｯｸ中は処理を行わない
            If Me.Enabled = False Then
                Exit Sub
            End If

            '@製品区分のﾁｪｯｸによって処理分岐
            '@製品か
            If optClass0.Checked = True Then
            
                '@製品の場合、在庫情報を取得する
                Call prvAldInvListSel()
            Else
            
                '@ﾓﾆﾀｰ・ﾀﾞﾐｰ・品確の場合、投入待ちﾛｯﾄ一覧を取得する
                Call prvLotRsvListSel()
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdHold_Click
    '機　能：受入在庫-保留ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/14 (Tue) 13:05:01 T.Oide
    '更新日：2018/08/14 (Tue)
    '備　考：
    Private Sub cmdHold_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHold.Click

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
            Call prvHoldConnect_Set()

            '@起動区分ｾｯﾄ(保留起動)
            ptypHoldConnect.strLotHoldFlg = "0"

            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfInvLot
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfInvLotColLotID)
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
            Call cmdNowList_Click(cmdNowList, EventArgs.Empty)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdHold_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdReleaseHold_Click
    '機　能：保管在庫-保留解除ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/14 (Tue) 13:33:35 T.Oide
    '更新日：2018/08/14 (Tue) 13:33:35
    '備　考：
    Private Sub cmdReleaseHold_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdReleaseHold.Click

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
            Call prvHoldConnect_Set()

            '@起動区分ｾｯﾄ(保留解除起動)
            ptypHoldConnect.strLotHoldFlg = "1"

            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfInvLot
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfInvLotColLotID)
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
            Call cmdNowList_Click(cmdNowList, EventArgs.Empty)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdReleaseHold_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotIn_Click
    '機　能：「↑」ﾎﾞﾀﾝ（在庫ﾛｯﾄをﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞに持っていく)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/15 (Wed) 08:58:48 T.Oide
    '更新日：2018/08/15 (Wed) 08:58:48
    '備　考：
    Private Sub cmdLotIn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotIn.Click

        Dim llngAryCount        As Integer  '配列ｶｳﾝﾀ
        Dim llngRow             As Integer
        Dim lstrTmp()           As String
        Dim lngACrrierChipNum   As Integer
        Dim lstrTapeStickRecipe As String
        Dim lstrOvenRecipe      As String
        Dim lstrAldRecipe       As String

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@配列の初期化
            mvrnClipSetText = New List(Of String)
            
            '@受入在庫ｸﾞﾘｯﾄﾞ
            With vsfInvLot
                
                '@選択行分だけﾙｰﾌﾟし対象を配列に格納
                For llngRow = 1 To .Rows.Count - 1
                    
                    '@選択セルでﾊﾞｯﾁ編成や保留ﾛｯﾄ以外か
                    If .Rows(llngRow).Selected = True And _
                       .GetData(llngRow, CMlngvsfInvLotColInfo) = vbNullString Then
                        
                        'バッチ編成ロットの全Chip数
                        If IsNumeric(.GetData(llngRow, CMlngvsfInvLotColChipNum)) Then
                            mintTotalBatchChipCnt = mintTotalBatchChipCnt + CInt(.GetData(llngRow, CMlngvsfInvLotColChipNum))
                        Else
                            If .GetData(llngRow, CMlngvsfInvLotColFlowClass) = CPstrFlowClassMO Or _
                                .GetData(llngRow, CMlngvsfInvLotColFlowClass) = CPstrFlowClassQU Then
                                mintTotalBatchChipCnt = mintTotalBatchChipCnt + mlngMoQuChipNum
                            End If
                        End If
                        
                        '@選択行の内容を配列に格納
                        llngAryCount = llngAryCount + 1
                        mvrnClipSetText.Add(.GetCellRange(llngRow, CMlngvsfInvLotColNo, _
                                                              llngRow, CMlngvsfInvLotColTapeStickGr).Clip)
                        
                        '@受入在庫の表示を「バ(ﾊﾞｯﾁ編成済)」に変える
                        .SetData(llngRow, CMlngvsfInvLotColInfo, CPstrBatch)
                    
                    End If
                    
                Next
            
            End With
            
            '@ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞ
            With vsfAldBatch
            
                '@配列から登録ﾘｽﾄに追加
                For llngAryCount = 0 To mvrnClipSetText.Count - 1
                
                    '@1行追加
                    .Rows.Count = .Rows.Count + 1
                    
                    '@書込み行設定
                    llngRow = .Rows.Count - 1
                    
                    '@要素を配列に格納
                    lstrTmp = Split(mvrnClipSetText(llngAryCount), vbTab)
                    
                    '@ｸﾞﾘｯﾄﾞに表示
                    .SetData(llngRow, CMlngvsfAldBatchColNo, lstrTmp(CMlngvsfInvLotColNo))                    '№
                    .SetData(llngRow, CMlngvsfAldBatchColThrowinStatus, CmstrThlowinStatusMi)                 '投入状態(未)
                    .SetData(llngRow, CMlngvsfAldBatchColLotId, lstrTmp(CMlngvsfInvLotColLotID))              'LotId
                    .SetData(llngRow, CMlngvsfAldBatchColPd, pubParentPdToAldPd(lstrTmp(CMlngvsfInvLotColPd), mtypTapeStickList))  '機種(3A0機種に変換)
                    .SetData(llngRow, CMlngvsfAldBatchColWfNum, lstrTmp(CMlngvsfInvLotColWfNum))              'Wf数
                    .SetData(llngRow, CMlngvsfAldBatchColTapeStickGr, lstrTmp(CMlngvsfInvLotColTapeStickGr))  'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                    .SetData(llngRow, CMlngvsfAldBatchColFlowClass, lstrTmp(CMlngvsfInvLotColFlowClass))      '種別
                    
                    '@FlowClassで分解
                    Select Case lstrTmp(CMlngvsfInvLotColFlowClass)

                        '@ﾓﾆﾀｰ、品確認か
                        Case CPstrFlowClassMO, CPstrFlowClassQU
                            .SetData(llngRow, CMlngvsfAldBatchColChipNum, mlngMoQuChipNum)                   'ﾓﾆﾀｰ、品確のﾁｯﾌﾟ数は15

                        '@ﾀﾞﾐｰか
                        Case CPstrFillerDummy, CPstrSideDummy, CPstrExtraDummy
                            .SetData(llngRow, CMlngvsfAldBatchColChipNum, mlngDummyChipNum)                  'ﾀﾞﾐｰのﾁｯﾌﾟ数は0

                        '@製品の場合
                        Case Else
                            .SetData(llngRow, CMlngvsfAldBatchColChipNum, lstrTmp(CMlngvsfInvLotColChipNum))  'ﾁｯﾌﾟ数

                    End Select
                    
                    lngACrrierChipNum = 0
                    .SetData(llngRow, CMlngvsfAldBatchColACarrierNum, _
                            prvACarrierNum(lstrTmp(CMlngvsfInvLotColTapeStickGr), lstrTmp(CMlngvsfInvLotColFlowClass), lngACrrierChipNum))   'Aｷｬﾘｱ収容数
                    .SetData(llngRow, CMlngvsfAldBatchColACarrierChipNum, lngACrrierChipNum)                  'Aｷｬﾘｱﾁｯﾌﾟ収容数(隠)
                    
                    '@ﾚｼﾋﾟ情報を取得して表示
                    Call prvGetAldBatchRecipe(lstrTmp(CMlngvsfInvLotColPd), lstrTapeStickRecipe, lstrOvenRecipe, lstrAldRecipe)
                    .SetData(llngRow, CMlngvsfAldBatchColTapeStickRecp, lstrTapeStickRecipe)                  'ﾃｰﾌﾟ貼りﾚｼﾋﾟ
                    .SetData(llngRow, CMlngvsfAldBatchColOvenRecp, lstrOvenRecipe)                            'ｵｰﾌﾞﾝﾚｼﾋﾟ
                    .SetData(llngRow, CMlngvsfAldBatchColAldBRecp, lstrAldRecipe)                             'ALDﾚｼﾋﾟ
                    
                    '@行の高さの設定
                    .Rows(llngRow).Height = CMlngVsfHeight
                    
                Next

                If .Row < CMlngVsfRowTitle Then
                    .Row = CMlngVsfRowTitle
                End If
            
            End With
            
            '@1行以上ある場合はロックを解除
            If vsfAldBatch.Rows.Count > 1 Then
                vsfAldBatch.Enabled = True
            End If
            
            '@ﾌｫｰｶｽを受入在庫ｸﾞﾘｯﾄﾞにｾｯﾄ
            Call pubSetFocus(vsfInvLot)
            
            '@ﾎﾞﾀﾝｺﾝﾄﾛｰﾙ
            mblnVsfInvLotGotFocus = False
            Call prvBtnCtl()
            
            '@変更有無ﾌﾗｸﾞの更新
            mblnEditFlag = True      '変更有り
            
            '@配列の初期化
            mvrnClipSetText = Nothing

            'NSYSLotDelイベントで最終行をクリア際のLotInボタン活性の為の対策
            mblnVsfInvLotGotFocus = True
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotIn_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotDel_Click
    '機　能：「↓」ﾎﾞﾀﾝ(ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞから在庫に戻す)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/15 (Wed) 08:59:06 T.Oide
    '更新日：2018/08/15 (Wed) 08:59:06
    '備　考：
    Private Sub cmdLotDel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotDel.Click

        Dim lstrLotID           As String
        Dim lstrChipNum         As String
        Dim lstrACarrierGr      As String
        Dim llngRow             As Integer
        Dim llngCnt             As Integer

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞ
            With vsfAldBatch

                '@ﾀｲﾄﾙ行以外か
                If .Row > CMlngVsfRowTitle Then

                    '@対象ﾛｯﾄを格納
                    lstrLotID = .GetData(.Row, CMlngvsfAldBatchColLotId)

                    '@同一Aｷｬﾘｱｸﾞﾙｰﾌﾟ設定済か(設定済の場合、「空きｷｬﾘｱCHIP数」を再計算する)
                    If .GetData(.Row, CMlngvsfAldBatchColACarrierGr) <> vbNullString Then
                    
                        lstrChipNum = IIf(.GetData(.Row, CMlngvsfAldBatchColChipNum) <> vbNullString, _
                                          .GetData(.Row, CMlngvsfAldBatchColChipNum), 0)
                        lstrACarrierGr = .GetData(.Row, CMlngvsfAldBatchColACarrierGr)

                        '@ｸﾞﾘｯﾄﾞで回す
                        For llngCnt = 1 To .Rows.Count - 1
                        
                            '@Aｷｬﾘｱｸﾞﾙｰﾌﾟは同じか
                            If lstrACarrierGr = .GetData(llngCnt, CMlngvsfAldBatchColACarrierGr) Then
                            
                                '@空きCHIP数を再計算して表示する
                                .SetData(llngCnt, CMlngvsfAldBatchColACarrierEmptNum, _
                                    CStr(CLng(.GetData(llngCnt, CMlngvsfAldBatchColACarrierEmptNum)) + CLng(lstrChipNum)))
                            End If
                        Next
                    End If

                    'バッチ編成ロットの全Chip数
                    If IsNumeric(.GetData(.Row, CMlngvsfAldBatchColChipNum)) Then
                        mintTotalBatchChipCnt = mintTotalBatchChipCnt - CInt(.GetData(.Row, CMlngvsfAldBatchColChipNum))
                    End If

                    '@ﾘｽﾄから削除する
                    .Redraw = False
                    .RemoveItem(.Row)
                    .Redraw = True

                End If

            End With

            '@受入在庫ｸﾞﾘｯﾄﾞ
            With vsfInvLot

                '@ｸﾞﾘｯﾄﾞをﾙｰﾌﾟして対象ﾛｯﾄを探す
                For llngRow = 1 To .Rows.Count - 1
                
                    '@対象ﾛｯﾄか
                    If lstrLotID = .GetData(llngRow, CMlngvsfInvLotColLotID) Then
                        
                        '@「バ」を消す
                        .SetData(llngRow, CMlngvsfInvLotColInfo, vbNullString)
                        
                    End If
                
                Next
                
            End With
                
            '@ﾌｫｰｶｽをﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞにｾｯﾄ
            Call pubSetFocus(vsfAldBatch)
            
            '@ﾎﾞﾀﾝｺﾝﾄﾛｰﾙ
            mblnVvsfAldBatchGotFocus = False
            Call prvBtnCtl()

            '@変更有無ﾌﾗｸﾞの更新
            mblnEditFlag = True      '変更有り

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotDel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSameACarrier_Click
    '機　能：同一Aｷｬﾘｱ設定(ｾﾙをﾏｰｼﾞして同一Aｷｬﾘｱに収納する表示にする)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/15 (Wed) 08:59:21 T.Oide
    '更新日：2019/07/29 (Mon) 13:54:04 T.Oide
    '備　考：
    Private Sub cmdSameACarrier_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSameACarrier.Click

        Dim llngRowStart        As Integer      '同一Aｷｬﾘｱ設定ｽﾀｰﾄ行
        Dim llngRowEnd          As Integer      '同一Aｷｬﾘｱ設定ｴﾝﾄﾞ行
        Dim llngColStart        As Integer      'ｽﾀｰﾄ列
        Dim llngColEnd          As Integer      'ｴﾝﾄﾞ列
        Dim llngRow             As Integer      '対象行
        Dim llngChipNum         As Integer      'ﾁｯﾌﾟ数合計
        Dim llngEnptChipNum     As Integer      'Aｷｬﾘｱ空きﾁｯﾌﾟ数
        Dim lstrACarrierGr      As String       'Aｷｬﾘｱｸﾞﾙｰﾌﾟ
        Dim ltypeDivLotList     As typeDivLot   '分割ﾛｯﾄ情報格納
            
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞ
            With vsfAldBatch

                '@選択範囲の取得
                llngRowStart = .Selection.TopRow
                llngRowEnd = .Selection.BottomRow
                llngColStart = .Selection.LeftCol
                llngColEnd = .Selection.RightCol
                
                '@同一Aｷｬﾘｱ設定前ﾁｪｯｸ
                If prvSameACrier_Chk(llngRowStart, llngRowEnd) = False Then
                    Exit Sub
                End If
                
                '@ﾁｯﾌﾟ数の合計を求める
                llngChipNum = 0
                For llngRow = llngRowStart To llngRowEnd
                
                    '@値選択行のﾁｯﾌﾟ数を合計する
                    llngChipNum = llngChipNum + CLng(IIf(.GetData(llngRow, CMlngvsfAldBatchColChipNum) <> vbNullString, _
                                                         .GetData(llngRow, CMlngvsfAldBatchColChipNum), "0"))
                    
                    '@ついでにAｷｬﾘｱｸﾞﾙｰﾌﾟが設定済ではないかﾁｪｯｸするために値をとっておく
                    If .GetData(llngRow, CMlngvsfAldBatchColACarrierGr) <> vbNullString Then
                        lstrACarrierGr = .GetData(llngRow, CMlngvsfAldBatchColACarrierGr)
                    End If
                    
                Next
                
                '@lstrACarrierGrはNULL以外か(既にAｷｬﾘｱｸﾞﾙｰﾌﾟ設定済ではなかったか)
                If lstrACarrierGr <> vbNullString Then
                
                    '@構造体ｸﾘｱ
                    ltypeDivLotList.lngDivLotInfoCnt = 0
                    ltypeDivLotList.typeDivLotInfo = New List(Of DivLotInfo)
                
                    '@既に同一Aｷｬﾘｱ設定していた場合は一旦解除する(この場合は解除だけで終わり）
                    '@ｸﾞﾘｯﾄﾞを全ﾅﾒして対象ｷｬﾘｱｸﾞﾙｰﾌﾟの設定は解除する
                    For llngRow = 1 To .Rows.Count - 1
                        
                        '@対象Aｷｬﾘｱｸﾞﾙｰﾌﾟか
                        If lstrACarrierGr = .GetData(llngRow, CMlngvsfAldBatchColACarrierGr) Then
                            
                            '@値を空で設定
                            .SetData(llngRow, CMlngvsfAldBatchColACarrierGr, vbNullString)         'Aｷｬﾘｱｸﾞﾙｰﾌﾟ
                            .SetData(llngRow, CMlngvsfAldBatchColACarrierEmptNum, vbNullString)    'Aｷｬﾘｱ空Chip数
                        
                            '@背景ｵﾚﾝｼﾞの場合情報を格納する(後で1ﾛｯﾄに戻すため)
                            '@背景ｵﾚﾝｼﾞの分割ﾛｯﾄか
                            If .GetCellRange(llngRow, CMlngvsfAldBatchColLotId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange) Then
                            
                                '@分割ﾛｯﾄがある場合、保持しておく
                                ltypeDivLotList.lngDivLotInfoCnt = ltypeDivLotList.lngDivLotInfoCnt + 1
                                Dim ltypDivLotInfoTmp As New DivLotInfo

                                ltypDivLotInfoTmp.strLotID = _
                                                            .GetData(llngRow, CMlngvsfAldBatchColLotId)    'ﾛｯﾄID
                                ltypDivLotInfoTmp.lngRow = llngRow                                         '対象行
                                ltypDivLotInfoTmp.lngChipNum = _
                                                            .GetData(llngRow, CMlngvsfAldBatchColChipNum)  'ﾁｯﾌﾟ数
                                
        '@↓2019/07/29 (Mon) 13:38:35 T.Oide  **************************************************
                                '@対象Aｷｬﾘｱｸﾞﾙｰﾌﾟの開始行か
        '@                        If llngRow = llngRowStart Then
        '@                            '@開始行の場合
        '@                            ltypeDivLotList.typeDivLotInfo(ltypeDivLotList.lngDivLotInfoCnt).strPosition = CmstrDivLotUe    '上側
        '@                        Else
        '@                            '@終了行の場合
        '@                            ltypeDivLotList.typeDivLotInfo(ltypeDivLotList.lngDivLotInfoCnt).strPosition = CmstrDivLotSita  '下側
        '@                        End If
        '@------------------------------------------------------------------------------------------------------
                                
                                '@分割相手が自分の上にいるか、下にいるか判定
                                ' llngRow：自分の行
                                '@自分の位置で分岐
                                Select Case llngRow
                                
                                    '@自分が1行目なら相手は必ず下
                                    Case 1
                                        ltypDivLotInfoTmp.strPosition = _
                                            CmstrDivLotSita  '下側
                                
                                    '@自分が最下行なら相手は必ず上
                                    Case .Rows.Count - 1
                                        ltypDivLotInfoTmp.strPosition = _
                                            CmstrDivLotUe    '上側
                                    
                                    '@上記以外(自分が途中行にいる場合)
                                    Case Else
                                
                                        '@自分の位置=ｽﾀｰﾄ行か
                                        If llngRow = llngRowStart Then
                                            '@ｽﾀｰﾄ行と同じなら相手は上
                                            ltypDivLotInfoTmp.strPosition = _
                                                CmstrDivLotUe    '上側
                                        Else
                                            '@そうでなければ、相手は下
                                            ltypDivLotInfoTmp.strPosition = _
                                                CmstrDivLotSita  '下側
                                        End If
                                
                                End Select
        '@↑2019/07/29 (Mon) 13:38:35 T.Oide  **************************************************
                                
                                ltypeDivLotList.typeDivLotInfo.Add(ltypDivLotInfoTmp)
                            End If
                            
                        End If
                    Next

                    '@分割ﾛｯﾄの保持情報がある場合、ﾛｯﾄIDを探して消して1ﾛｯﾄにする
                    '@また消した相手がAｷｬﾘｱｸﾞﾙｰﾌﾟ設定済の場合、
                    '　「Aｷｬﾘｱ収容数」「AｷｬﾘｱCHIP収容数(隠)」｢Aｷｬﾘｱ空CHIP数｣をｸﾘｱする
                    Call prvDivPartLotDelete(ltypeDivLotList)
                    
                Else
                
                    '@同一Aｷｬﾘｱ設定
                    
                    '@Aｷｬﾘｱの収容数をｵｰﾊﾞしていないか
                    If llngChipNum > CLng(.GetData(llngRowStart, CMlngvsfAldBatchColACarrierChipNum)) Then
                    
                        '@ｵｰﾊﾞしている場合は、該当ﾛｯﾄを2行にして数調整をする
                        ' これによりAｷｬﾘｱに満タンにCHIPが入り、Aｷｬﾘｱを跨って収容された状態になる
                        Call prvDivideLot(llngRowStart, llngRowEnd)
                        
                        '@ﾁｯﾌﾟ数の合計を数え直す
                        llngChipNum = 0
                        For llngRow = llngRowStart To llngRowEnd
                            '@値選択行のﾁｯﾌﾟ数を合計する
                            llngChipNum = llngChipNum + CLng(.GetData(llngRow, CMlngvsfAldBatchColChipNum))
                        Next
                        
                        '※選択行を満タンになるﾛｯﾄまでとし、
                        '  Aｷｬﾘｱｸﾞﾙｰﾌﾟを以下の処理で設定する
                    
                    End If
                    
                    '@現行最大値のｷｬﾘｱｸﾞﾙｰﾌﾟ取得
                    lstrACarrierGr = vbNullString           '初期化
                    For llngRow = 1 To .Rows.Count - 1
                        
                        '@ｸﾞﾘｯﾄﾞのAｷｬﾘｱｸﾞﾙｰﾌﾟは空以外か
                        If .GetData(llngRow, CMlngvsfAldBatchColACarrierGr) <> vbNullString Then
                        
                            '@lstrACarrierGrは空か
                            If lstrACarrierGr = vbNullString Then
                                '@Aｷｬﾘｱｸﾞﾙｰﾌﾟを一旦格納
                                lstrACarrierGr = .GetData(llngRow, CMlngvsfAldBatchColACarrierGr)
                            End If
                            
                            '@より大きいか
                            If CLng(lstrACarrierGr) < _
                               CLng(.GetData(llngRow, CMlngvsfAldBatchColACarrierGr)) Then
                                '@より大きい値を格納
                                lstrACarrierGr = .GetData(llngRow, CMlngvsfAldBatchColACarrierGr)
                            End If
                            
                        End If
                    Next
                    
                    '@Aｷｬﾘｱｸﾞﾙｰﾌﾟは初期値の01以外か
                    If lstrACarrierGr = vbNullString Then
                        lstrACarrierGr = CmlngACrrierGr01
                    Else
                        '@ +1 して新規ｷｬﾘｱｸﾞﾙｰﾌﾟ設定
                        lstrACarrierGr = Format(CLng(lstrACarrierGr) + 1, CmlngACrrierGrFormat)
                    End If
                    
                    '@Aｷｬﾘｱ空きﾁｯﾌﾟ数計算(Aｷｬﾘｱﾁｯﾌﾟ収容数(隠) - ﾁｯﾌﾟ数合計値）
                    llngEnptChipNum = CLng(.GetData(llngRowStart, CMlngvsfAldBatchColACarrierChipNum)) - llngChipNum
                    
                    '@選択したﾛｯﾄのAｷｬﾘｱｸﾞﾙｰﾌﾟ、Aｷｬﾘｱ空Chip数に値を入れてﾏｰｼﾞして表示する
                    For llngRow = llngRowStart To llngRowEnd
                        '@値を設定
                        .SetData(llngRow, CMlngvsfAldBatchColACarrierGr, lstrACarrierGr)          'Aｷｬﾘｱｸﾞﾙｰﾌﾟ
                        .SetData(llngRow, CMlngvsfAldBatchColACarrierEmptNum, llngEnptChipNum)    'Aｷｬﾘｱ空Chip数
                    Next
                    
                End If
                
                '@ｾﾙのﾏｰｼﾞ設定
                Call prvVsfGridMergeCol(True)
                
                '@Aｷｬﾘｱｸﾞﾙｰﾌﾟにﾌｫｰｶｽをあてる(見栄えを良くするだけ)
        '@↓2019/02/27 (Wed) 10:09:53 T.Oide **************************************************
        '@        .Row = llngRowStart
        '@        .Col = CMlngvsfAldBatchColACarrierGr
        '@        .ShowCell llngRowStart, CMlngvsfAldBatchColACarrierGr
        '@-------------------------------------------------------------------------------------
                
                '@Aｷｬﾘｱｸﾞﾙｰﾌﾟにﾌｫｰｶｽをあてる(見栄えを良くするだけ)
                '@行数はｽﾀｰﾄ行より小さいか(最終行を削除された場合の対応)
                If .Rows.Count > llngRowStart Then
                    .Row = llngRowStart
                    .Col = CMlngvsfAldBatchColACarrierGr
                    .ShowCell(llngRowStart, CMlngvsfAldBatchColACarrierGr)
                Else
                    .Row = llngRowStart - 1
                    .Col = CMlngvsfAldBatchColACarrierGr
                    .ShowCell(.Row, .Col)
                End If
        '@↑2019/02/27 (Wed) 10:09:53 T.Oide **************************************************
                
            End With
            
            '@ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞにﾌｫｰｶｽ
            Call pubSetFocus(vsfAldBatch)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSameACarrier_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdPosiUp_Click
    '機　能：ALD処理部(↑)（1行上に行を移動する）
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/15 (Wed) 08:59:41 T.Oide
    '更新日：2018/08/15 (Wed) 08:59:41
    '備　考：
    Private Sub cmdPosiUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPosiUp.Click

        Dim llngRowStart    As Integer  'ｽﾀｰﾄ行
        Dim llngRowEnd      As Integer  'ｴﾝﾄﾞ行
        Dim llngColStart    As Integer  'ｽﾀｰﾄ列
        Dim llngColEnd      As Integer  'ｴﾝﾄﾞ列

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞ
            With vsfAldBatch

                '@選択範囲の取得
                llngRowStart = .Selection.TopRow
                llngRowEnd = .Selection.BottomRow
                llngColStart = .Selection.LeftCol
                llngColEnd = .Selection.RightCol
                
                '@選択範囲の直前にある行を選択範囲直後にの移動
                .Rows.Move(llngRowStart - 1, llngRowEnd)
                
                '@選択範囲を移動
                .Select(llngRowStart - 1, llngColStart, llngRowEnd - 1, llngColEnd)
                .ShowCell(llngRowStart - 1, llngColStart)
                        
            End With

            '@ﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(vsfAldBatch)

            '@ﾎﾞﾀﾝｺﾝﾄﾛｰﾙ
            Call prvBtnCtl()
            
            '@編集中にする
            mblnEditFlag = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPosiUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdPosiDown_Click
    '機　能：ALD処理部(↓)（1行下に行を移動する）
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/15 (Wed) 09:00:08 T.Oide
    '更新日：2018/08/15 (Wed) 09:00:08
    '備　考：
    Private Sub cmdPosiDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPosiDown.Click

        Dim llngRowStart    As Integer  'ｽﾀｰﾄ行
        Dim llngRowEnd      As Integer  'ｴﾝﾄﾞ行
        Dim llngColStart    As Integer  'ｽﾀｰﾄ列
        Dim llngColEnd      As Integer  'ｴﾝﾄﾞ列
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfAldBatch
            
                '@選択範囲の取得
                llngRowStart = .Selection.TopRow
                llngRowEnd = .Selection.BottomRow
                llngColStart = .Selection.LeftCol
                llngColEnd = .Selection.RightCol
                
                '@選択範囲の直後にある行を選択範囲の直前に移動
                .Rows.Move(llngRowEnd + 1, llngRowStart)
                
                '@選択範囲を移動
                .Select(llngRowStart + 1, llngColStart, llngRowEnd + 1, llngColEnd)
                .ShowCell(llngRowEnd + 1, llngColEnd)
                
            End With

            '@ﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(vsfAldBatch)

            '@ﾎﾞﾀﾝｺﾝﾄﾛｰﾙ
            Call prvBtnCtl()

            '@編集中にする
            mblnEditFlag = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPosiDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClear_Click
    '機　能：ｸﾘｱ(新規作成中のﾊﾞｯﾁｸﾞﾘｯﾄﾞを初期化する)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/15 (Wed) 09:00:19 T.Oide
    '更新日：2018/08/15 (Wed) 09:00:19
    '備　考：
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@編集中ﾁｪｯｸ
            If prvEditCheck = False Then
                Exit Sub
            End If
            
            '@編集終了
            mblnEditFlag = False
            
            '@画面情報の初期化
            Call prvfrmxxEN02P0_Init()
            
            '@初期化時のデータ取得
            If prvInitDataSelDisp = False Then
                Exit Sub
            End If
            
            '@受入在庫最新取得表示
            Call Form_Activate(Me, EventArgs.Empty)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClear_Click"
                .strErrMessage = vbNullString
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdBatchDele_Click
    '機　能：削除(ﾊﾞｯﾁを削除する)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/15 (Wed) 09:00:29 T.Oide
    '更新日：2018/08/15 (Wed) 09:00:29
    '備　考：
    Private Sub cmdBatchDele_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBatchDele.Click

        Dim llngAns     As Integer

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@投入待ちのﾊﾞｯﾁを削除する場合は、確認ﾒｯｾｰｼﾞを表示する
            If labStatus.Text = CmstrBatchStatusTonyuMachi Then

                '@$$ [%1]ステータスのバッチを[%2]しようとしています" & _
                '  $よろしいですか?"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0154, CmstrBatchStatusTonyuMachi, CmstrBatchDelString)
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                
                '@確認
                If llngAns = vbNo Then
                    Exit Sub
                End If

            End If

            '@ﾊﾞｯﾁ情報削除
            Call prvBatchDataRegist(CPstrCD05)

            '@ｷｬﾝｾﾙの場合は情報ｸﾘｱしないで終了
            If pblnCancel = True Then
                Exit Sub
            End If

            '@削除後は、ﾊﾞｯﾁ情報をｸﾘｱする
            mblnEventCancelFlag = True
            Call cmdClear_Click(cmdClear, EventArgs.Empty)
            mblnEventCancelFlag = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdBatchDele_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdEdit_Click
    '機　能：編集(編成済のﾊﾞｯﾁを再度編集する)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/15 (Wed) 09:00:39 T.Oide
    '更新日：2018/08/15 (Wed) 09:00:39
    '備　考：
    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEdit.Click

        Dim llngAns     As Integer

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@投入待ちのﾊﾞｯﾁを編集する場合は、確認ﾒｯｾｰｼﾞを表示する
            If labStatus.Text = CmstrBatchStatusTonyuMachi Then

                '@$$ [%1]ステータスのバッチを[%2]しようとしています" & _
                '  $よろしいですか?"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0154, CmstrBatchStatusTonyuMachi, CmstrBatchEditString)
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                
                '@確認
                If llngAns = vbNo Then
                    Exit Sub
                End If

            End If
            
            '@編集中
            mblnEditFlag = True
            
           '@範囲選択可能
            vsfAldBatch.SelectionMode = SelectionModeEnum.ListBox
            
            '@ﾊｲﾗｲﾄする(画面編集中はハイライト)
            vsfAldBatch.HighLight = HighlightEnum.WithFocus
            vsfAldBatch.Styles.Focus.BackColor = mtypVsfAldBatchFocusBackColor
            vsfAldBatch.Styles.Focus.ForeColor = mtypVsfAldBatchFocusForeColor
                
            '@ﾎﾞﾀﾝ有効/無効
            vsfAldBatch.Row = 1     '編集でﾎﾞﾀﾝの有効/無効が変化して判りやすくするため
            Call prvBtnCtl()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdEdit_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSave_Click
    '機　能：登録(ﾊﾞｯﾁを登録する→ﾊﾞｯﾁｽﾃｰﾀｽ：0編集中)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/15 (Wed) 09:00:50 T.Oide
    '更新日：2018/08/15 (Wed) 09:00:50
    '備　考：
    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@登録前ﾁｪｯｸ
            If prvRegist_Chk = False Then
                Exit Sub
            End If

            '@ﾊﾞｯﾁ情報登録(登録)
            Call prvBatchDataRegist(CPstrCD39)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSave_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：適用(ﾊﾞｯﾁを登録する→ﾊﾞｯﾁｽﾃｰﾀｽ：1投入待ち)
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/15 (Wed) 09:01:07 T.Oide
    '更新日：2018/08/15 (Wed) 09:01:07
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lstrClassDiv            As String

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@登録前ﾁｪｯｸ
            If prvRegist_Chk = False Then
                Exit Sub
            End If
            
            '@状態は“編集中”“投入待ち”か
            If labStatus.Text = CmstrBatchStatusHensyu Or _
               labStatus.Text = CmstrBatchStatusTonyuMachi Then
                '@“編集中”“投入待ち”の場合
                lstrClassDiv = CPstrCD06    '投入待ち状態にする
            Else
                '@“投入済”“再編集”の場合
                lstrClassDiv = CPstrCD07    '再編集状態にする
            End If
            
            '@ﾊﾞｯﾁ情報登録(適用)
            Call prvBatchDataRegist(lstrClassDiv)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRegist_Click"
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
    '作成日：2018/08/02 (Thu) 17:08:43 T.Oide
    '更新日：2018/08/02 (Thu) 17:08:43
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
            Call publngEnd_Proc(CPstrKeyEN02P0, ltypCommonInfo)

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

    '@'****************************************************************************************
    '@'                                      *関数の記述*
    '@'****************************************************************************************
    '@'========================================Private=========================================

    '関数名：prvfrmxxEN02P0_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/07 (Tue) 13:29:06 T.Oide
    '更新日：2018/08/07 (Tue) 13:29:06
    '備　考：
    Private Sub prvfrmxxEN02P0_Init()

        Dim lstrFormTitle       As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02P0, lstrFormTitle)

            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞ初期化
            Call prvvGrid_Init(vsfAldBatch)
            
            '@受入在庫ｸﾞﾘｯﾄﾞ初期化
            Call prvvGrid_Init(vsfInvLot)

            '@情報取得日時ｸﾘｱ
            lblNowDate.Text = vbNullString

            '@取得件数ｸﾘｱ
            lblDataCnt.Text = vbNullString

            '@ﾃﾞｰﾀ格納変数初期化
            mtypTapeStickList.typTapeStickGr = Nothing  'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟﾘｽﾄ
            mtypTapeStickList.lngTapeStickGrCnt = 0
            
            mtypPdList = Nothing                        '機種一覧格納用
            mlngPdListCnt = 0                           '機種一覧ｶｳﾝﾄ
            
            mtypDivisionList = Nothing                  '種別一覧格納用
            mlngDivisionListCnt = 0                     '種別一覧ｶｳﾝﾄ
            
            With mtypAldBatchList                       'ALDﾊﾞｯﾁﾘｽﾄ
                .strSbID = vbNullString
                .lngAldBatchListCnt = 0
                .typAldBatchList = Nothing
            End With
            
            mvrnClipSetText = Nothing                   '「↑」時の情報格納
            
            mtypeAldBatchRecipe.lngAldBatchRecipeCnt = 0
            mtypeAldBatchRecipe.typeAldBatchRecipe = Nothing    '防湿膜ALDの「ﾃｰﾌﾟ貼り」「ｵｰﾌﾞﾝ」「ALD」ﾚｼﾋﾟを格納


            cmbTapStickGr.Clear                         '貼りｸﾞﾙｰﾌﾟｺﾝﾎﾞｸﾘｱ
            cmbPD.Clear                                 '機種ｺﾝﾎﾞｸﾘｱ
            cmbFlowClass.Clear                          '種別ｺﾝﾎﾞｸﾘｱ

            '@製品区分ﾁｪｯｸ
            optClass0.Enabled = True                    '有効にする
            optClass0.Checked = True                    '製品をﾁｪｯｸOnになる
            
            '@モニター
            optMoni0.Enabled = True                     '有効にする
            optMoni0.Checked = True                     '有をﾁｪｯｸOnにする
            
            '@ｶﾚﾝﾀﾞｰ設定
            With dtpThrowInDate
                .CalendarHeight = CPlngMClHeight        '高さ
                .CalendarWidth = CPlngMClWidth          '幅
                .DayFont = New Font(.DayFont.FontFamily, CPlngMClFontSize, .DayFont.Style, .DayFont.Unit, _
                                    .DayFont.GdiCharSet, .DayFont.GdiVerticalFont)                          'ﾌｫﾝﾄｻｲｽﾞ
                .TitleFont = New Font(.TitleFont.FontFamily, CPlngMClTlFontSize, .TitleFont.Style, .TitleFont.Unit, _
                                      .TitleFont.GdiCharSet, .TitleFont.GdiVerticalFont)                    'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CPlngMClGridFontSize, .GridFont.Style, .GridFont.Unit, _
                                     .GridFont.GdiCharSet, .GridFont.GdiVerticalFont)                       'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
            End With

            'バッチ編成ロットの全Chip数、初期化
            mintTotalBatchChipCnt = 0

            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02P0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvGrid_Init
    '機　能：ｸﾞﾘｯﾄﾞ初期化
    '引　数：lblnDoEnableFalse     ：Enable=False処理の実行有無（省略可）True：実行する、False：実行しない(NSYS追加)
    '戻り値：なし
    '作成日：2018/08/07 (Tue) 11:51:04 T.Oide
    '更新日：2018/08/07 (Tue) 11:51:04
    '備　考：
    Private Sub prvvGrid_Init(ByRef vsfGridObj As C1FlexGrid, _
                              Optional ByVal lblnDoEnableFalse As Boolean = True)

        Try

            With vsfGridObj

                

                '@初期行数設定
                .Redraw = False
                .Row = -1
                .Rows.Count = .Rows.Fixed
                                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                '@行列のﾏｳｽでの幅変更を可にする
                .AllowResizing = AllowResizingEnum.Columns

                '@範囲選択可
                .SelectionMode = SelectionModeEnum.ListBox       'これじゃないと「.SelectedRows」で選択行数が取得できない

                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter

                .Rows.DefaultSize = CMlngVsfHeight

                '@一覧表のﾀｲﾄﾙ設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                                '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)   '背景色
                With .Font                                                          'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMlngVsfHFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                lFixedStyle.Trimming = StringTrimming.None
                lFixedStyle.WordWrap = False
                       
                '@ﾀｲﾄﾙ表示位置の設定
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight      '高さ

                '@非表示設定
                Select Case vsfGridObj.Name
                
                    '@ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞの場合
                    Case vsfAldBatch.Name
                    
                        '@ｿｰﾄﾌ(ﾍｯﾀﾞｰｸﾘｯｸでｿｰﾄしない)
                        .AllowSorting = AllowSortingEnum.None
                    
                        '@ﾊｲﾗｲﾄする
                        .HighLight = HighlightEnum.WithFocus
                        .Styles.Focus.BackColor = mtypVsfAldBatchFocusBackColor
                        .Styles.Focus.ForeColor = mtypVsfAldBatchFocusForeColor

                        .Cols(CMlngvsfAldBatchColACarrierChipNum).Visible = False  'AｷｬﾘｱCHIP収容数(隠)

                        '@ﾀｲﾄﾙ設定
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColNo, CMstrvsfAldBatchColTNo)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColThrowinStatus, CMstrvsfAldBatchColThrowinStatus)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColLotId, CMstrvsfAldBatchColTLotId)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColPd, CMstrvsfAldBatchColTPd)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColWfNum, CMstrvsfAldBatchColTWfNum)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColChipNum, CMstrvsfAldBatchColTChipNum)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColTapeStickGr, CMstrvsfAldBatchColTTapeStickGr)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColACarrierGr, CMstrvsfAldBatchColTACarrierGr)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColACarrierNum, CMstrvsfAldBatchColTACarrierNum)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColACarrierChipNum, CMstrvsfAldBatchColTACarrierChipNum)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColACarrierEmptNum, CMstrvsfAldBatchColTACarrierEmptNum)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColFlowClass, CMstrvsfAldBatchColTFlowClass)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColTapeStickBatch, CMstrvsfAldBatchColTTapeStickBatch)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColTapeStickRecp, CMstrvsfAldBatchColTTapeStickRecp)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColOvenBatch, CMstrvsfAldBatchColTOvenBatch)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColOvenRecp, CMstrvsfAldBatchColTOvenRecp)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColAldBatch, CMstrvsfAldBatchColTAldBatch)
                        .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColAldBRecp, CMstrvsfAldBatchColTAldBRecp)
                        
                        '@幅設定
                        .Cols(CMlngvsfAldBatchColNo).Width = CMlngvsfAldBatchColWNo
                        .Cols(CMlngvsfAldBatchColThrowinStatus).Width = CMlngvsfAldBatchColWThrowinStatus
                        .Cols(CMlngvsfAldBatchColLotId).Width = CMlngvsfAldBatchColWLotId
                        .Cols(CMlngvsfAldBatchColPd).Width = CMlngvsfAldBatchColWPd
                        .Cols(CMlngvsfAldBatchColWfNum).Width = CMlngvsfAldBatchColWWfNum
                        .Cols(CMlngvsfAldBatchColChipNum).Width = CMlngvsfAldBatchColWChipNum
                        .Cols(CMlngvsfAldBatchColTapeStickGr).Width = CMlngvsfAldBatchColWTapeStickGr
                        .Cols(CMlngvsfAldBatchColACarrierGr).Width = CMlngvsfAldBatchColWACarrierGr
                        .Cols(CMlngvsfAldBatchColACarrierNum).Width = CMlngvsfAldBatchColWACarrierNum
                        .Cols(CMlngvsfAldBatchColACarrierChipNum).Width = CMlngvsfAldBatchColWACarrierChipNum
                        .Cols(CMlngvsfAldBatchColACarrierEmptNum).Width = CMlngvsfAldBatchColWACarrierEmptNum
                        .Cols(CMlngvsfAldBatchColFlowClass).Width = CMlngvsfAldBatchColWFlowClass
                        .Cols(CMlngvsfAldBatchColTapeStickBatch).Width = CMlngvsfAldBatchColWTapeStickBatch
                        .Cols(CMlngvsfAldBatchColTapeStickRecp).Width = CMlngvsfAldBatchColWTapeStickRecp
                        .Cols(CMlngvsfAldBatchColOvenBatch).Width = CMlngvsfAldBatchColWOvenBatch
                        .Cols(CMlngvsfAldBatchColOvenRecp).Width = CMlngvsfAldBatchColWOvenRecp
                        .Cols(CMlngvsfAldBatchColAldBatch).Width = CMlngvsfAldBatchColWAldBatch
                        .Cols(CMlngvsfAldBatchColAldBRecp).Width = CMlngvsfAldBatchColWAldBRecp

                        '@ｾﾙのﾏｰｼﾞ設定(解除)
                        Call prvVsfGridMergeCol(False)
                    
                        '@折り返し表示(「Aｷｬﾘｱ数(収容数)」を折返し表示したい)
                        .Styles.Normal.WordWrap = True
                        'NSYS WordWrap と 省略表示同時使用はできない
                        .Styles.Normal.Trimming = StringTrimming.None
                        
                        '@固定列の設定
                        .Cols.Frozen = CMlngFrozenColsBatch
                    
                    '@受入在庫ｸﾞﾘｯﾄﾞの場合
                    Case vsfInvLot.Name
                                        
                        '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ(ﾍｯﾀﾞｰｸﾘｯｸでｿｰﾄ可)
                        .AllowSorting = AllowSortingEnum.SingleColumn
                
                        '@ﾊｲﾗｲﾄする
                        .HighLight = HighlightEnum.Always
                        
                        .Cols(CMlngvsfInvLotColEditTime).Visible = False                                          '更新日時

                        '@ﾀｲﾄﾙ表示
                        .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColNo, CMlngvsfInvLotColTNo)                     '№
                        .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColInfo, CMlngvsfInvLotColTInfo)                 '(保留 or ﾊﾞｯﾁ情報表示)
                        
                        '@在庫か投入予定ﾛｯﾄかで表示変更
                        If optClass0.Checked = True Then
                            '@受入在庫の場合
                            .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColInvDate, CMlngvsfInvLotColTInvDate)       '受入日
                        Else
                            '@投入予定ﾛｯﾄの場合
                            .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColInvDate, CMlngvsfInvLotColTThrowinDate)   '投入予定日
                        End If
                        
                        .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColLotID, CMlngvsfInvLotColTLotID)               'ロットID
                        .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColFlowClass, CMlngvsfInvLotColTFlowClass)       '種別
                        .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColPriority, CMlngvsfInvLotColTPriority)         '優先度
                        .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColPd, CMlngvsfInvLotColTPd)                     '機種
                        .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColWfNum, CMlngvsfInvLotColTWfNum)               'WF数
                        .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColChipNum, CMlngvsfInvLotColTChipNum)           'CHIP数
                        .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColTapeStickGr, CMlngvsfInvLotColTTapeStickGr)   'テープ貼りグループ
                        .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColStagnateTerm, CMlngvsfInvLotColTStagnateTerm) '停滞時間
                        .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColHoldTerm, CMlngvsfInvLotColTHoldTerm)         '保留期間
                        .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColHoldEmpId, CMlngvsfInvLotColTHoldEmpId)       '保留担当者
                        .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColHoldReason, CMlngvsfInvLotColTHoldReason)     '保留理由
                        .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColComments, CMlngvsfInvLotColTComments)         'ｺﾒﾝﾄ
                        .SetData(CMlngVsfRowTitle, CMlngvsfInvLotColEditTime, CMlngvsfInvLotColTEditTime)         '更新日時
                        
                        '@幅設定
                        .Cols(CMlngvsfInvLotColNo).Width = CMlngvsfInvLotColWNo                                   '№
                        .Cols(CMlngvsfInvLotColInfo).Width = CMlngvsfInvLotColWInfo                               '(保留 or ﾊﾞｯﾁ情報表示)
                        .Cols(CMlngvsfInvLotColInvDate).Width = CMlngvsfInvLotColWInvDate                         '受入日
                        .Cols(CMlngvsfInvLotColLotID).Width = CMlngvsfInvLotColWLotID                             'ﾛｯﾄID
                        .Cols(CMlngvsfInvLotColFlowClass).Width = CMlngvsfInvLotColWFlowClass                     '種別
                        .Cols(CMlngvsfInvLotColPriority).Width = CMlngvsfInvLotColWPriority                       '優先度
                        .Cols(CMlngvsfInvLotColPd).Width = CMlngvsfInvLotColWPd                                   '機種
                        .Cols(CMlngvsfInvLotColWfNum).Width = CMlngvsfInvLotColWWfNum                             'ｳｪﾊｰ数
                        .Cols(CMlngvsfInvLotColChipNum).Width = CMlngvsfInvLotColWChipNum                         'ﾁｯﾌﾟ数
                        .Cols(CMlngvsfInvLotColTapeStickGr).Width = CMlngvsfInvLotColWTapeStickGr                 'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                        .Cols(CMlngvsfInvLotColStagnateTerm).Width = CMlngvsfInvLotColWStagnateTerm               '停滞時間(在庫に入ってからの時間)
                        .Cols(CMlngvsfInvLotColHoldTerm).Width = CMlngvsfInvLotColWHoldTerm                       '保留期間(保留されてからの時間)
                        .Cols(CMlngvsfInvLotColHoldEmpId).Width = CMlngvsfInvLotColWHoldEmpId                     '保留担当者
                        .Cols(CMlngvsfInvLotColHoldReason).Width = CMlngvsfInvLotColWHoldReason                   '保留理由
                        .Cols(CMlngvsfInvLotColComments).Width = CMlngvsfInvLotColWComments                       'ｺﾒﾝﾄ
                        .Cols(CMlngvsfInvLotColEditTime).Width = CMlngvsfInvLotColWEditTime                       '更新日時
                        
                        '@固定列の設定
                        .Cols.Frozen = CMlngFrozenColsInv
                        
                End Select
                    
                .Redraw = True

                If lblnDoEnableFalse = True Then
                    '@ﾛｯｸ
                    .Enabled = False
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvGrid_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbTapStickGr_Disp
    '機　能：ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟｺﾝﾎﾞ設定
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/06 (Mon) 18:00:56 T.Oide
    '更新日：2018/08/06 (Mon) 18:00:56
    '備　考：
    Private Sub prvcmbTapStickGr_Disp()

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ

        Try

            With cmbTapStickGr
            
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .Enabled = True                                                 '活性化
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = 1                                                  '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mtypTapeStickList.lngTapeStickGrCnt                '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                            '"選択"文字列
                With .Font                                                      'ﾌｫﾝﾄｻｲｽﾞ
                    cmbTapStickGr.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                                  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbTapStickGr.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
            
                '@取得数ぶん繰返し
                For llngCnt = 0 To mtypTapeStickList.lngTapeStickGrCnt - 1

                    '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟｺﾝﾎﾞ内容の設定(ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ/ﾘｽﾄIndex/NULL/NULL/ﾁｪｯｸBOXのﾃﾞﾌｫﾙﾄﾁｪｯｸ(1：ON))
                    .AddItem(mtypTapeStickList.typTapeStickGr(llngCnt).strTapeStickGr & vbTab & _
                             (llngCnt + 1) & vbTab & _
                             vbNullString & vbTab & _
                             vbNullString & vbTab & _
                             CMstrCmbCheckOn)

                Next llngCnt

                '@ﾃｷｽﾄ部分に情報をｾｯﾄ
                .AddedComment = CMstrCmbAddedComment        '" 項目選択"
                .Text = .ListCount & CMstrCmbAddedComment   '"N項目選択"(Nは選択数)
                
                
                '@種別ｺﾝﾎﾞを有効にする
                .Enabled = True
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbTapStickGr_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbFlowClasst_Disp
    '機　能：種別ｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/06 (Mon) 14:48:58 T.Oide
    '更新日：2018/08/06 (Mon) 14:48:58
    '備　考：
    Private Sub prvcmbFlowClasst_Disp()

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ

        Try

            With cmbFlowClass
            
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
                With .Font                                                      'ﾌｫﾝﾄｻｲｽﾞ
                    cmbFlowClass.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                                  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbFlowClass.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
            
                '@取得数ぶん繰返し
                For llngCnt = 0 To mlngDivisionListCnt - 1

                    '@種別ｺﾝﾎﾞ内容の設定(種別/ﾘｽﾄIndex/NULL/NULL/ﾁｪｯｸBOXのﾃﾞﾌｫﾙﾄﾁｪｯｸ(1：ON))
                    .AddItem(mtypDivisionList(llngCnt).strDivisionID & vbTab & _
                             (llngCnt + 1) & vbTab & _
                             vbNullString & vbTab & _
                             vbNullString & vbTab & _
                             CMstrCmbCheckOn)

                Next llngCnt

                '@ﾃｷｽﾄ部分に情報をｾｯﾄ
                .AddedComment = CMstrCmbAddedComment        '" 項目選択"
                .Text = .ListCount & CMstrCmbAddedComment   '"N項目選択"(Nは選択数)
                
                
                '@種別ｺﾝﾎﾞを有効にする
                .Enabled = True
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbFlowClasst_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPd_Disp
    '機　能：機種ｺﾝﾎﾞ設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/06 (Mon) 15:21:40 T.Oide
    '更新日：2018/08/06 (Mon) 15:21:40
    '備　考：
    Private Sub prvcmbPd_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@機種ｺﾝﾎﾞの設定
            With cmbPD
                
                .Clear                                                      'ｸﾘｱ
                .Enabled = True                                             '有効
                .DirectInput = False                                        '直接入力不可(False)
                .SelectMode = CMlngCMbSelectMode                            '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                     '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbDispCols                               '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngPdListCnt                                  '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                        '"選択"文字列
                With .Font                                                  'ﾌｫﾝﾄｻｲｽﾞ
                    cmbPD.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                              'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbPD.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .RowHeight = CMlngCmbRowHeight                              '行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左寄中央揃え

                For llngCnt = 0 To mlngPdListCnt - 1
                
                    '@機種ｺﾝﾎﾞ内容の設定(機種ID/機種名/ﾘｽﾄIndex/NULL/ﾁｪｯｸBOXのﾃﾞﾌｫﾙﾄﾁｪｯｸ(0：OFF))
                    .AddItem(mtypPdList(llngCnt).strProductID & vbTab & _
                             mtypPdList(llngCnt).strProductName & vbTab & _
                             (llngCnt + 1) & vbTab & _
                             vbNullString & vbTab & _
                             CMstrCmbCheckOff)
                
                Next llngCnt
                
                '@ﾃｷｽﾄ部分に情報をｾｯﾄ
                .AddedComment = CMstrCmbAddedComment        '" 項目選択"
                .Text = CMstrCmbAddedCommentNone            '"0 項目選択"
            
            End With
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbPd_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbAldBatch_Disp
    '機　能：ﾊﾞｯﾁｺﾝﾎﾞ設定処理
    '引　数：なし
    '戻り値：
    '作成日：2018/08/07 (Tue) 10:09:46 T.Oide
    '更新日：2019/08/06 (Tue) 15:42:34 T.Oide
    '備　考：
    Private Sub prvcmbAldBatch_Disp()
        
        Dim llngCnt             As Integer          'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrMoniter         As String
        Dim lstrBatchFlowClass  As String
        Dim lstrBatchStatus     As String
        
        Try
            
            With cmbAldBatch
            
                '@初期化
                .Clear
                .Height = CMlngCmbRowHeight             '高さ
                .DispCols = CMlngCmbDispCol4            '表示列(ﾊﾞｯﾁｽﾃｰﾀｽまで）
                .GetCol = CMlngCmbGridCol0              'Text値表示列
                .ValueCol = CMlngCmbValueCol0           '値取得列
                With .GridFont                          'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbAldBatch.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
            
            End With
            
            With mtypAldBatchList
                
                '@新規作成を追加
                cmbAldBatch.AddItem(CMstrBatchNew _
                            & vbTab _
                            & CMstrThrowInDate _
                            & vbTab _
                            & CMstrMoniBatchClass _
                            & vbTab _
                            & CMstrMoniBatchStatus)
                            
                
                '@ﾊﾞｯﾁ情報ｾｯﾄ
                For llngCnt = 0 To .lngAldBatchListCnt - 1
                    
                    '@ﾓﾆﾀ有無表示文字列作成
                    If .typAldBatchList(llngCnt).steMonitorUseFlag = 0 Then
                        lstrMoniter = CMstrMoniter & CMstrMoniterNasi
                    Else
                        lstrMoniter = CMstrMoniter & CMstrMoniterAri
                    End If
                    
                    '@ﾊﾞｯﾁ流動区分表示文字列作成
                    If .typAldBatchList(llngCnt).strBatchFlowClass = CMstrProduct Then
                        lstrBatchFlowClass = CMstrBatchFlowClassPR
                    Else
                        lstrBatchFlowClass = CMstrBatchFlowClassQU
                    End If
                
                    '@ﾊﾞｯﾁ状態表示設定
                    Select Case .typAldBatchList(llngCnt).strBatchStatus
                        
                        '@編集中
                        Case CmstrBatchStatusEdit
                            lstrBatchStatus = CmstrBatchStatusHensyu
                        
                        '@投入待ち
                        Case CmstrBatchStatusThrowInWaite
                            lstrBatchStatus = CmstrBatchStatusTonyuMachi
                        
                        '@投入済
                        Case CmstrBatchStatusThrowIn
                            lstrBatchStatus = CmstrBatchStatusTonyu
                        
                        '@再編集
                        Case CmstrBatchStatusThrowInEdit
                            lstrBatchStatus = CmstrBatchStatusSaihensyu
                        
                    End Select
                    
        '@↓2019/08/06 (Tue) 15:40:52 T.Oide  **************************************************
                    '@編集可否情報を追加
                    lstrBatchStatus = lstrBatchStatus + " / " + .typAldBatchList(llngCnt).strEditable
        '@↑2019/08/06 (Tue) 15:40:52 T.Oide  **************************************************
                
                    '@'「ﾊﾞｯﾁID」&「投入予定日」&「ﾓﾆﾀ ﾊﾞｯﾁ流動区分」&「ﾊﾞｯﾁｽﾃｰﾀｽ」
                    cmbAldBatch.AddItem(.typAldBatchList(llngCnt).strBatchId _
                            & vbTab _
                            & .typAldBatchList(llngCnt).strPlanThrowinDate _
                            & vbTab _
                            & lstrMoniter & CPstrSpace & lstrBatchFlowClass _
                            & vbTab _
                            & lstrBatchStatus)
                            
                Next llngCnt

            End With

            '@新規作成を初期表示
            cmbAldBatch.ListIndex = CMlngCmbFirstIndex

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbAldBatch_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfAldBatch_Disp
    '機　能：ﾊﾞｯﾁの情報をﾊﾞｯﾁｸﾞﾘｯﾄﾞに表示する
    '引　数：なし
    '戻り値：
    '作成日：2018/08/07 (Tue) 14:58:36 T.Oide
    '更新日：2019/08/06 (Tue) 16:06:15 T.Oide
    '備　考：
    Private Sub prvvsfAldBatch_Disp()
        
        Dim llngCnt             As Integer
        Dim llngLotCnt          As Integer
        Dim llngWFNum           As Integer      'ｳｪﾊｰ数
        Dim llngRowCnt          As Integer
        
        Try
            
            With mtypAldBatchList
                vsfAldBatch.Row = -1
                
                '@ﾊﾞｯﾁ情報を格納している構造体から該当情報を探す
                For llngCnt = 0 To .lngAldBatchListCnt - 1
                    
                    '@該当ﾊﾞｯﾁIDか
                    If .typAldBatchList(llngCnt).strBatchId = cmbAldBatch.Value Then
                        
                        '@ｸﾞﾘｯﾄﾞ行設定
                        vsfAldBatch.Rows.Count = .typAldBatchList(llngCnt).lngBatchDetailCnt + 1
                        
                        '@ﾓﾆﾀ使用ﾌﾗｸﾞを参照してｳｪﾊｰ枚数を決める
                        If .typAldBatchList(llngCnt).steMonitorUseFlag = 0 Then
                        
                            '@ﾓﾆﾀｰ無(ｳｪﾊｰ:13枚)
                            llngWFNum = CMlngMoniUnUsesWfNum
                        Else
                        
                            '@ﾓﾆﾀｰ有(ｳｪﾊｰ:12枚)
                            llngWFNum = CMlngMoniUsesWfNum
                        End If
                        
                        '@ﾛｯﾄ数ぶん繰返し
                        For llngLotCnt = 0 To .typAldBatchList(llngCnt).lngBatchDetailCnt - 1
                            llngRowCnt = llngLotCnt + vsfAldBatch.Rows.Fixed
                        
                            With .typAldBatchList(llngCnt).typBatchDetail(llngLotCnt)
                            
                                '@ｸﾞﾘｯﾄﾞに表示する
                                vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColNo, .strSeqNum)                        '№
                                vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColLotId, .strLotID)                      'ﾛｯﾄID
                                vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColPd, pubParentPdToAldPd(.strPdId, mtypTapeStickList))  '機種(3A0機種に変換)
                                vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColWfNum, .strWfQty)                      'ｳｪﾊｰ数
                                vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColChipNum, .strChipQty)              'ﾁｯﾌﾟ数
                                vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColTapeStickGr, prvPdToTapeStickGr(.strPdId))         'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                                vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColACarrierGr, .strACrrierGroup)          'Aｷｬﾘｱｸﾞﾙｰﾌﾟ
                                
                                '@Aｷｬﾘｱ収容数
                                Select Case .strFlowClass
                                    
                                    '@MOまたはQUか
                                    Case CPstrFlowClassMO, CPstrFlowClassQU
                                        vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColACarrierChipNum, mlngMoQuChipNum)
                                    
                                    '@ﾀﾞﾐｰか
                                    Case CPstrFillerDummy, CPstrSideDummy, CPstrExtraDummy
                                        vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColACarrierChipNum, mlngDummyChipNum)
                                    
                                    '@製品
                                    Case Else
                                        vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColACarrierChipNum, .strAtrayChipNum * llngWFNum)     'Aｷｬﾘｱﾁｯﾌﾟ収容数(Aﾄﾚｰﾁｯﾌﾟ収容数 * ｳｪﾊｰ数)
                                End Select
                                
                                'Aｷｬﾘｱ空きﾁｯﾌﾟ数(後で表示)
                                vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColFlowClass, .strFlowClass)              '種別
                                vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColTapeStickBatch, .strTapeStickBatchId)  'ﾃｰﾌﾟ貼りﾊﾞｯﾁID
                                vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColTapeStickRecp, .strTapeStickRrecipeId) 'ﾃｰﾌﾟ貼りﾚｼﾋﾟ
                                vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColOvenBatch, .strOvenBatchId)            'ｵｰﾌﾞﾝﾊﾞｯﾁID
                                vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColOvenRecp, .strOvenRecipeId)            'ｵｰﾌﾞﾝﾚｼﾋﾟ
                                vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColAldBatch, .strAldBatchId)              'ALDﾊﾞｯﾁID
                                vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColAldBRecp, .strAldRecipeId)             'ALDﾚｼﾋﾟ
                            
                                '@投入待ちﾛｯﾄか
                                If .strLotEventId = CmstrLotStatusThrowinWait Then
                                    '@投入待ちは背景色白設定、隠し列に"未"設定
                                    Dim newStyle As CellStyle = vsfAldBatch.Styles.Add("CustomStyle_BackColor_vbWhite")
                                    newStyle.BackColor = Color.White
                                    Dim cellRange As CellRange = vsfAldBatch.GetCellRange( _
                                                     llngRowCnt, CMlngvsfAldBatchColNo, _
                                                     llngRowCnt, vsfAldBatch.Cols.Count - 1)
                                    cellRange.Style = newStyle
                                    vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColThrowinStatus, _
                                                    CmstrThlowinStatusMi)
                                Else
                                
                                    '@投入待ち以外は№～Chipまで背景色灰色、隠し列に"済"設定
                                    Dim newStyle As CellStyle = vsfAldBatch.Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                                    Dim cellRange As CellRange = vsfAldBatch.GetCellRange( _
                                                     llngRowCnt, CMlngvsfAldBatchColNo, _
                                                     llngRowCnt, CMlngvsfAldBatchColChipNum)
                                    cellRange.Style = newStyle
                                    newStyle = vsfAldBatch.Styles.Add("CustomStyle_BackColor_vbWhite")
                                    newStyle.BackColor = Color.White
                                    cellRange = vsfAldBatch.GetCellRange( _
                                                     llngRowCnt, CMlngvsfAldBatchColACarrierGr, _
                                                     llngRowCnt, vsfAldBatch.Cols.Count - 1)
                                    cellRange.Style = newStyle
                                    vsfAldBatch.SetData(llngRowCnt, CMlngvsfAldBatchColThrowinStatus, _
                                                    CmstrThlowinStatusSumi)
                                End If
                            
                            End With
                            
                            '@行の高さの設定
                            vsfAldBatch.Rows(llngRowCnt).Height = CMlngVsfHeight
                        
                        Next
                                        
                        '@投入予定日を表示
                        dtpThrowInDate.Value = .typAldBatchList(llngCnt).strPlanThrowinDate
                        
                        '@ﾓﾆﾀｰﾁｪｯｸを表示
                        If .typAldBatchList(llngCnt).steMonitorUseFlag = CMlngChkON Then
                            '@ﾓﾆﾀｰ有の場合
                            optMoni0.Checked = True
                        Else
                            '@ﾓﾆﾀｰ無の場合
                            optMoni1.Checked = True
                        End If
                        
                        '@バッチ流動区分表示
                        If .typAldBatchList(llngCnt).strBatchFlowClass = CMstrProduct Then
                            '@製品
                            labBatchFlowClass.Text = CMstrBatchFlowClassPR
                        Else
                            '@品確
                            labBatchFlowClass.Text = CMstrBatchFlowClassQU
                        End If
                        
                        '@状態表示
                        Select Case .typAldBatchList(llngCnt).strBatchStatus
                            '@編集中
                            Case CmstrBatchStatusEdit
                                labStatus.Text = CmstrBatchStatusHensyu
                            '@投入待ち
                            Case CmstrBatchStatusThrowInWaite
                                labStatus.Text = CmstrBatchStatusTonyuMachi
                            '@投入済
                            Case CmstrBatchStatusThrowIn
                                labStatus.Text = CmstrBatchStatusTonyu
                            '@再編集
                            Case CmstrBatchStatusThrowInEdit
                                labStatus.Text = CmstrBatchStatusSaihensyu
                            '@終了
                            Case CmstrBatchStatusBatchOut
                                labStatus.Text = CmstrBatchStatusSyuryou
                        End Select
                        
        '@↓2019/08/06 (Tue) 16:05:33 T.Oide  **************************************************
                        '@編集可否
                        lblEditable.Text = .typAldBatchList(llngCnt).strEditable
        '@↑2019/08/06 (Tue) 16:05:33 T.Oide  **************************************************
                        
                    End If
                Next
                
            End With

            '@「Aｷｬﾘｱｸﾞﾙｰﾌﾟ」を見てｾﾙのﾏｰｼﾞと「Aｷｬﾘｱ空きﾁｯﾌﾟ数」を表示する
            Call prvACarrieEmptNum_Disp(llngWFNum)
            
            '@Aｷｬﾘｱを跨るﾛｯﾄがある場合は黄色表示する
            Call prvACarrieDivideBackColor()
            
            '@表示行があればロック解除
            If vsfAldBatch.Rows.Count > 1 Then
                vsfAldBatch.Enabled = True
            End If

            vsfAldBatch.Select(CMlngVsfRowTitle, CMlngvsfColNo)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfAldBatch_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvACarrieEmptNum_Disp
    '機　能：「Aｷｬﾘｱｸﾞﾙｰﾌﾟ」を見てｾﾙのﾏｰｼﾞと「Aｷｬﾘｱ空きﾁｯﾌﾟ数」を表示する
    '引　数：lngWFNum:ﾓﾆﾀｰ有無によるAｶｾｯﾄ1つのｳｴﾊｰ数
    '戻り値：なし
    '作成日：2018/08/07 (Tue) 15:30:29 T.Oide
    '更新日：2018/08/07 (Tue) 15:30:29
    '備　考：
    Private Sub prvACarrieEmptNum_Disp(ByVal lngWFNum As Integer)
        
        Dim llngCnt             As Integer
        Dim lstrACarrierGr      As String
        Dim lngAStartRow        As Integer  '同一Aｶｾｯﾄｽﾀｰﾄ行
        Dim lngAEndRow          As Integer  '同一Aｶｾｯﾄｴﾝﾄﾞ行
        
        Try
            
            With vsfAldBatch
                
                '@2行のみ(ﾃﾞｰﾀ行が1行だけ)の場合、処理不要
                If .Rows.Count <= 2 Then
                    Exit Sub
                End If
                
                '@変数初期化
                lngAStartRow = 1
                lngAEndRow = 1
                
                '@1行目のAｷｬﾘｱｸﾞﾙｰﾌﾟを格納
                lstrACarrierGr = .GetData(lngAStartRow, CMlngvsfAldBatchColACarrierGr)
                
                '@ﾊﾞｯﾁ編成の行ぶん繰返す
                For llngCnt = 2 To vsfAldBatch.Rows.Count - 1

                    '@Aｶｾｯﾄｸﾞﾙｰﾌﾟは同一か
                    If lstrACarrierGr = .GetData(llngCnt, CMlngvsfAldBatchColACarrierGr) Then
                        
                        '@ｴﾝﾄﾞ行を更新
                        lngAEndRow = lngAEndRow + 1
                    
                    Else
                        
                        '@ｸﾞﾙｰﾌﾟが変わった場合
                        ' そこまでの同一Aｷｬﾘｱのﾁｯﾌﾟ数を合計して空き数を計算・表示
                        Call prvACarrieCalc(lngAStartRow, lngAEndRow, lngWFNum)
                        
                        
                        '@開始行、終了行を現在行で初期化
                        lngAStartRow = llngCnt
                        lngAEndRow = llngCnt
                        
                        '@Aｶｾｯﾄｸﾞﾙｰﾌﾟを退避する
                        lstrACarrierGr = .GetData(llngCnt, CMlngvsfAldBatchColACarrierGr)
                        
                    End If
                    
                Next
                
                '@最終ｸﾞﾙｰﾌﾟの同一Aｷｬﾘｱのﾁｯﾌﾟ数を合計して空き数を計算・表示
                Call prvACarrieCalc(lngAStartRow, lngAEndRow, lngWFNum)
                
                '@ｾﾙをﾏｰｼﾞする
                Call prvVsfGridMergeCol(True)
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfAldBatch_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvACarrieCalc
    '機　能：同一Aｷｬﾘｱのﾁｯﾌﾟ数を合計して空き数を計算して表示
    '引　数：lngAStartRow：同一Aｶｾｯﾄｽﾀｰﾄ行
    '　　　：lngAEndRow：同一Aｶｾｯﾄｴﾝﾄﾞ行
    '　　　：lngWFNum:ﾓﾆﾀｰ有無によるAｷｬﾘｱ内のｳｪﾊｰ数
    '戻り値：
    '作成日：2018/08/07 (Tue) 16:51:31 T.Oide
    '更新日：2018/08/07 (Tue) 16:51:31
    '備　考：
    Private Sub prvACarrieCalc(ByVal lngAStartRow As Integer, ByVal lngAEndRow As Integer, ByVal lngWFNum As Integer)
        
        Dim llngCalc            As Integer  '計算用ｶｳﾝﾀ
        Dim llngChipNum         As Integer  'Aｶｾｯﾄ搭載ﾁｯﾌﾟ数
        
        Try
            
            With vsfAldBatch
            
                '@①ﾁｯﾌﾟ数合計を計算する
                For llngCalc = lngAStartRow To lngAEndRow
                    llngChipNum = llngChipNum + IIf(.GetData(llngCalc, CMlngvsfAldBatchColChipNum) <> vbNullString, _
                                                    .GetData(llngCalc, CMlngvsfAldBatchColChipNum), 0)
                Next
                
                '@②「Aｷｬﾘｱ収容数」と「Aｷｬﾘｱ空CHIP数」を表示(各行同じ値)
                For llngCalc = lngAStartRow To lngAEndRow
                    
                    '@「Aｷｬﾘｱ収容数」を表示（「ｸﾞﾙｰﾌﾟ-ｳｪﾊｰ数(ﾁｯﾌﾟ数)」、例「Aキャリア01 12(1040)」）
                    .SetData(llngCalc, CMlngvsfAldBatchColACarrierNum, _
                        CMstrACarrier & _
                        .GetData(lngAStartRow, CMlngvsfAldBatchColACarrierGr) & CPstrSpace & _
                        CStr(lngWFNum) & _
                        CPstrParenthesisLeft & _
                        IIf(.GetData(lngAStartRow, CMlngvsfAldBatchColACarrierChipNum) <> vbNullString, _
                            .GetData(lngAStartRow, CMlngvsfAldBatchColACarrierChipNum), 0) & _
                        CPstrParenthesisRight)
                    
                    '@「Aｷｬﾘｱ空CHIP数」を計算(②-①)して表示
                    .SetData(llngCalc, CMlngvsfAldBatchColACarrierEmptNum, _
                        IIf(.GetData(lngAStartRow, CMlngvsfAldBatchColACarrierChipNum) <> vbNullString, _
                            .GetData(lngAStartRow, CMlngvsfAldBatchColACarrierChipNum), 0) - llngChipNum)
                Next
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvACarrieCalc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfInvLot_Disp
    '機　能：受入在庫一覧取得
    '引　数：ltypInvActptLotList：受入在庫構造体
    '戻り値：なし
    '作成日：2018/08/10 (Fri) 10:39:21 T.Oide
    '更新日：2018/08/10 (Fri) 10:39:40
    '備　考：
    Private Sub prvvsfInvLot_Disp(ByRef ltypInvAcptLotListAns As InvAcptLotListAns, _
                                  ByVal llngInvAcptLotListCnt As Integer)

        Dim llngDoCnt   As Integer  'ｶｳﾝﾄ
        Dim llngRow     As Integer

        Try
            
            If llngInvAcptLotListCnt <> 0 Then
                '@格納ﾃﾞｰﾀがあるの場合

                With vsfInvLot
                
                    '@描画ﾛｯｸ
                    .Redraw = False

                    .Row = - 1
                    
                    '@行数初期化(ｸﾞﾘｯﾄﾞの初期化)
                    .Rows.Count = .Rows.Fixed
                    
                    '@行数設定
                    .Rows.Count = llngInvAcptLotListCnt + 1
                    
                    '@初めの描画行
                    llngRow = 1
                    
                    '@ﾛｯﾄ一覧表示情報(通常ﾛｯﾄ)
                    For llngDoCnt = 0 To llngInvAcptLotListCnt - 1
                        
                        '@保留ﾌﾗｸﾞは0か
                        If ltypInvAcptLotListAns.typLotList(llngDoCnt).strLotHoldFlag <> CPstrHold1 Then
                            '@在庫情報を1行表示
                            Call prvInvLot_Disp(ltypInvAcptLotListAns, llngInvAcptLotListCnt, llngDoCnt, llngRow)
                        End If
                        
                    Next

                    '@ﾛｯﾄ一覧表示情報(保留ﾛｯﾄ)
                    For llngDoCnt = 0 To llngInvAcptLotListCnt - 1

                        '@保留ﾌﾗｸﾞは1か
                        If ltypInvAcptLotListAns.typLotList(llngDoCnt).strLotHoldFlag = CPstrHold1 Then
                            '@在庫情報を1行表示
                            Call prvInvLot_Disp(ltypInvAcptLotListAns, llngInvAcptLotListCnt, llngDoCnt, llngRow)
                        End If
                        
                    Next

                    .Select(CMlngVsfRowTitle, CMlngvsfColNo)
                              
                    '@再描画
                    .Redraw = True
                   
                    '@ﾛｯｸ解除
                    .Enabled = True
                    
                    '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfInvLot)
                    
                End With
            End If

            '@該当件数
            lblDataCnt.Text = llngInvAcptLotListCnt

            '@取得日時
            lblNowDate.Text = Format$(Now, CPstrDateFormat)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfInvLot_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvInvLot_Disp
    '機　能：受け入れ在庫を表示
    '引　数：ltypInvAcptLotListAns：受入在庫情報
    '　　　：llngInvAcptLotListCnt：受入在庫数
    '戻り値：
    '作成日：2018/08/14 (Tue) 14:57:42 T.Oide
    '更新日：2018/08/14 (Tue) 14:57:42
    '備　考：
    Private Sub prvInvLot_Disp(ByRef ltypInvAcptLotListAns As InvAcptLotListAns, _
                               ByVal llngInvAcptLotListCnt As Integer, _
                               ByVal llngDoCnt As Integer, ByRef llngRow As Integer)

        Dim lstrTemp    As String

        Try

            With vsfInvLot

                .SetData(llngRow, CMlngvsfInvLotColNo, llngRow)                                      '№
                
                If IsDate(ltypInvAcptLotListAns.typLotList(llngDoCnt).strEntryTime) Then
                    .SetData(llngRow, CMlngvsfInvLotColInvDate, _
                        Format$(CDate(ltypInvAcptLotListAns.typLotList(llngDoCnt).strEntryTime), _
                                CPstrDateFormatMDHM))                                                '受入日
                Else
                    .SetData(llngRow, CMlngvsfInvLotColInvDate, _
                        ltypInvAcptLotListAns.typLotList(llngDoCnt).strEntryTime)                    '受入日
                End If
                
                .SetData(llngRow, CMlngvsfInvLotColLotID, _
                    ltypInvAcptLotListAns.typLotList(llngDoCnt).strLotID)                            'ﾛｯﾄID
                
                .SetData(llngRow, CMlngvsfInvLotColFlowClass, _
                    ltypInvAcptLotListAns.typLotList(llngDoCnt).strFlowClass)                        '種別
                    
                .SetData(llngRow, CMlngvsfInvLotColPriority, _
                    ltypInvAcptLotListAns.typLotList(llngDoCnt).strLotPriority)                      '優先度
                
                .SetData(llngRow, CMlngvsfInvLotColPd, _
                    ltypInvAcptLotListAns.typLotList(llngDoCnt).strPdId)                             '機種
                
                .SetData(llngRow, CMlngvsfInvLotColWfNum, _
                    ltypInvAcptLotListAns.typLotList(llngDoCnt).strWFQuantity)                       'WF枚数
                
                .SetData(llngRow, CMlngvsfInvLotColChipNum, _
                    ltypInvAcptLotListAns.typLotList(llngDoCnt).strChipQuantity)                     'CHIP枚数
                
                .SetData(llngRow, CMlngvsfInvLotColTapeStickGr, _
                    prvPdToTapeStickGr(ltypInvAcptLotListAns.typLotList(llngDoCnt).strPdId))         'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                
                '@ﾌｫｰﾏｯﾄ変更
                lstrTemp = Mid(ltypInvAcptLotListAns.typLotList(llngDoCnt).strStayTime, _
                               CMlngFormatStart, CMlngFormatMid9)
                .SetData(llngRow, CMlngvsfInvLotColStagnateTerm, lstrTemp)                           '停滞時間
                                
                '@保留中の場合, 保留情報をｾｯﾄ
                If ltypInvAcptLotListAns.typLotList(llngDoCnt).strLotHoldFlag = CPstrHold1 Then
                    
                    lstrTemp = Mid(ltypInvAcptLotListAns.typLotList(llngDoCnt).strHoldStayDate, _
                                   CMlngFormatStart, CMlngFormatMid9)
                    
                    .SetData(llngRow, CMlngvsfInvLotColHoldTerm, lstrTemp)                           '保留期間
                                            
                    .SetData(llngRow, CMlngvsfInvLotColHoldEmpId, _
                        ltypInvAcptLotListAns.typLotList(llngDoCnt).strHoldEmpName)                  '保留担当者
                
                    .SetData(llngRow, CMlngvsfInvLotColHoldReason, _
                        ltypInvAcptLotListAns.typLotList(llngDoCnt).strReasonName)                   '保留理由
                End If
                    
                .SetData(llngRow, CMlngvsfInvLotColComments, _
                    ltypInvAcptLotListAns.typLotList(llngDoCnt).strLotComments)                      'ｺﾒﾝﾄ
                    
                .SetData(llngRow, CMlngvsfInvLotColEditTime, _
                    ltypInvAcptLotListAns.typLotList(llngDoCnt).strEditTime)                         '最終更新日時
                
                '@保留表示（ｾﾙ色変更 LOT_HOLD_FLAG = 1(保留中) 黄色）
                If ltypInvAcptLotListAns.typLotList(llngDoCnt).strLotHoldFlag = CMstrLotHoldFlgOn Then
                    .SetData(llngRow, CMlngvsfInvLotColInfo, CPstrHo)
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor")
                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                    Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngVsfColTitle, llngRow, .Cols.Count - 1)
                    cellRange.Style = newStyle
                End If
                
                '@ﾊﾞｯﾁ表示（ｾﾙ色変更 ﾊﾞｯﾁ編成済 灰色)
                If prvblnBatchChk(ltypInvAcptLotListAns.typLotList(llngDoCnt).strLotID) = True Then
                    .SetData(llngRow, CMlngvsfInvLotColInfo, CPstrBatch)
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                    Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngVsfColTitle, llngRow, .Cols.Count - 1)
                    cellRange.Style = newStyle
                End If
                
                '@行の高さの設定
                .Rows(llngRow).Height = CMlngVsfHeight
                
                '@行ｶｳﾝﾄ
                llngRow = llngRow + 1

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvInvLot_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvPdToTapeStickGr
    '機　能：機種からﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟを返す
    '引　数：strPdId：機種
    '戻り値：ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
    '作成日：2018/08/14 (Tue) 10:35:21 T.Oide
    '更新日：2018/08/14 (Tue) 10:35:21
    '備　考：
    Private Function prvPdToTapeStickGr(ByVal strPdId As String) As String

        Dim llngCnt         As Integer
        Dim llngCnt2        As Integer
        Dim lblnFindFlag    As Boolean

        Try
            
            '@結果を初期化
            prvPdToTapeStickGr = vbNullString
            lblnFindFlag = False
            
            With mtypTapeStickList
                
                '@mtypTapeStickListで回す
                For llngCnt = 0 To .lngTapeStickGrCnt - 1
                
                    '@.lngPdListCntで回す
                    For llngCnt2 = 0 To .typTapeStickGr(llngCnt).lngPdListCnt - 1
                    
                        With .typTapeStickGr(llngCnt)
                        
                            '@機種は一致したか
                            If strPdId = .typPdList(llngCnt2).strParentPdId Then
                                
                                '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟを格納
                                prvPdToTapeStickGr = .strTapeStickGr
                                lblnFindFlag = True
                                Exit For
                            End If
                            
                        End With
                    Next
                    
                    '@見つかったらﾙｰﾌﾟ終了
                    If lblnFindFlag = True Then
                        Exit For
                    End If
                Next
            
                '@============================
                '@見つからなかった場合(投入済の場合、機種IDが3A0になっているのでﾋｯﾄしない)
                ' もう一度3A0の機種で探してみる
                '@============================
                If lblnFindFlag = False Then
                
                    '@mtypTapeStickListで回す
                    For llngCnt = 0 To .lngTapeStickGrCnt - 1
                    
                        '@.lngPdListCntで回す
                        For llngCnt2 = 0 To .typTapeStickGr(llngCnt).lngPdListCnt - 1
                        
                            With .typTapeStickGr(llngCnt)
                            
                                '@3A0の機種と一致したか
                                If strPdId = .typPdList(llngCnt2).strPdId Then
                                    
                                    '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟを格納
                                    prvPdToTapeStickGr = .strTapeStickGr
                                    lblnFindFlag = True
                                    Exit For
                                End If
                                
                            End With
                        Next
                        
                        '@見つかったらﾙｰﾌﾟ終了
                        If lblnFindFlag = True Then
                            Exit For
                        End If
                    Next
            
                End If
            
            End With
            
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvPdToTapeStickGr"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvHoldConnect_Set
    '機　能：引継ぎ構造体へ格納
    '引　数：なし
    '戻り値：True:OK/False:NG
    '作成日：2018/08/14 (Tue) 13:09:56 T.Oide
    '更新日：2018/08/14 (Tue) 13:09:56
    '備　考：
    Private Function prvHoldConnect_Set() As Boolean

        Try

            '@初期化
            prvHoldConnect_Set = False
            
            With vsfInvLot
            
                ptypHoldConnect.lngTabFlag = 0                                                 'ﾀﾌﾞﾌﾗｸﾞ(本機能ではﾀﾞﾐｰ情報)
                ptypHoldConnect.strCarrierId = vbNullString                                    'ｷｬﾘｱID
                ptypHoldConnect.strLotID = .GetData(.Row, CMlngvsfInvLotColLotID)              'ﾛｯﾄID
                ptypHoldConnect.strFlowClass = .GetData(.Row, CMlngvsfInvLotColFlowClass)      '流動区分
                ptypHoldConnect.strCommnents = .GetData(.Row, CMlngvsfInvLotColComments)       'ﾛｯﾄｺﾒﾝﾄ内容
                ptypHoldConnect.strLastUpdate = .GetData(.Row, CMlngvsfInvLotColEditTime)      '最終更新日時
                
                '@結果OKを返す
                prvHoldConnect_Set = True

            End With
            
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

    '関数名：prvblnBatchChk
    '機　能：引数のﾛｯﾄがﾊﾞｯﾁ編成済か否か返す
    '引　数：strLotID：ﾛｯﾄID
    '戻り値：True：編成済、False:未編成
    '作成日：2018/08/14 (Tue) 15:45:57 T.Oide
    '更新日：2018/08/14 (Tue) 15:45:57
    '備　考：
    Private Function prvblnBatchChk(ByVal strLotID As String) As Boolean

        Dim llngCnt     As Integer
        Dim llngCnt2    As Integer

        Try

            prvblnBatchChk = False

            With mtypAldBatchList

                '@ﾊﾞｯﾁ数でﾙｰﾌﾟ
                For llngCnt = 0 To .lngAldBatchListCnt - 1
                
                    '@ﾛｯﾄでﾙｰﾌﾟ
                    For llngCnt2 = 0 To .typAldBatchList(llngCnt).lngBatchDetailCnt - 1
                
                        With .typAldBatchList(llngCnt).typBatchDetail(llngCnt2)
                            
                            '@ﾛｯﾄIDは同じか
                            If strLotID = .strLotID Then
                                
                                prvblnBatchChk = True
                            End If
                        End With
                    Next
                Next

            End With

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnBatchChk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvACarrierNum
    '機　能：引数からmtypTapeStickListの中を探してAｷｬﾘｱ収容数の文字列を返す
    '　　　　ついでにAｷｬﾘｱChip数も計算して返す
    '引　数：strTapeStickGr     ：ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
    '　　　：strFlowClass       ：FLOW_CLASS
    '　　　：lngACarrierChipNum ：Aｷｬﾘｱﾁｯﾌﾟ収容数
    '戻り値：Aｷｬﾘｱ収容数（例：12(3048)）
    '作成日：2018/08/18 (Sat) 09:49:53 T.Oide
    '更新日：2018/08/18 (Sat) 09:49:53
    '備　考：
    Private Function prvACarrierNum(ByVal strTapeStickGr As String, ByVal strFlowClass As String, ByRef lngACarrierChipNum As Integer) As String

        Dim llngCnt As Integer

        Try
            
            '@結果初期化
            prvACarrierNum = vbNullString
            
            '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ情報
            With mtypTapeStickList
            
                '@FlowClassで分解
                Select Case strFlowClass
                    
                    '@ﾓﾆﾀｰ、品確認か
                    Case CPstrFlowClassMO, CPstrFlowClassQU
                        lngACarrierChipNum = mlngMoQuChipNum                   'ﾓﾆﾀｰ、品確のﾁｯﾌﾟ数は15
                        prvACarrierNum = mlngMoQuWfNum & CPstrParenthesisLeft & lngACarrierChipNum & CPstrParenthesisRight
                        
                    '@ﾀﾞﾐｰか
                    Case CPstrFillerDummy, CPstrSideDummy, CPstrExtraDummy
                        lngACarrierChipNum = mlngDummyChipNum                  'ﾀﾞﾐｰのﾁｯﾌﾟ数は0
                        prvACarrierNum = CMlngMoniUsesWfNum & CPstrParenthesisLeft & lngACarrierChipNum & CPstrParenthesisRight
                        
                    '@製品の場合
                    Case Else
            
                        '@構造体を回す
                        For llngCnt = 0 To .lngTapeStickGrCnt - 1
                            
                            '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟは一致したか
                            If strTapeStickGr = .typTapeStickGr(llngCnt).strTapeStickGr Then
                                
                                '@ﾓﾆﾀｰ有ﾁｪｯｸOnか
                                If optMoni0.Checked = True Then
                                    '@有の場合は、AﾄﾚｰChip数 x WF数は12枚
                                    lngACarrierChipNum = .typTapeStickGr(llngCnt).strAtrayChipNum * CMlngMoniUsesWfNum
                                    prvACarrierNum = CMlngMoniUsesWfNum & CPstrParenthesisLeft & lngACarrierChipNum & CPstrParenthesisRight
                                Else
                                    '@無の場合は、AﾄﾚｰChip数 x Wf数は13枚
                                    lngACarrierChipNum = .typTapeStickGr(llngCnt).strAtrayChipNum * CMlngMoniUnUsesWfNum
                                    prvACarrierNum = CMlngMoniUnUsesWfNum & CPstrParenthesisLeft & lngACarrierChipNum & CPstrParenthesisRight
                                End If
                                
                                Exit For
                                
                            End If
                            
                        Next
                
                End Select
            
            End With
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvACarrierNum"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function


    '関数名：prvVsfGridMergeCol
    '機　能：ｾﾙのﾏｰｼﾞを設定する
    '引　数：blnMerge：True:ﾏｰｼﾞする、Flase:ﾏｰｼﾞしない
    '戻り値：
    '作成日：2018/08/18 (Sat) 15:35:59 T.Oide
    '更新日：2018/08/18 (Sat) 15:35:59
    '備　考：
    Private Sub prvVsfGridMergeCol(ByVal blnMerge As Boolean)

        Try
                        
            With vsfAldBatch
            
                'ｾﾙをﾏｰｼﾞ設定(行方向)
                .AllowMerging = AllowMergingEnum.Free
                
                '一旦ﾏｰｼﾞ解除(新規はﾏｰｼﾞが不要なので)
                .Cols(CMlngvsfAldBatchColTapeStickGr).AllowMerging = blnMerge       'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                .Cols(CMlngvsfAldBatchColACarrierGr).AllowMerging = blnMerge        'Aｷｬﾘｱｸﾞﾙｰﾌﾟ
                .Cols(CMlngvsfAldBatchColACarrierNum).AllowMerging = blnMerge       'Aｷｬﾘｱ収容数
                .Cols(CMlngvsfAldBatchColACarrierChipNum).AllowMerging = blnMerge   'Aｷｬﾘｱﾁｯﾌﾟ収容数(隠)
                .Cols(CMlngvsfAldBatchColACarrierEmptNum).AllowMerging = blnMerge   'Aｷｬﾘｱ空ﾁｯﾌﾟ数
                .Cols(CMlngvsfAldBatchColFlowClass).AllowMerging = blnMerge         '機種
                .Cols(CMlngvsfAldBatchColTapeStickBatch).AllowMerging = blnMerge    'ﾃｰﾌﾟ貼りﾊﾞｯﾁID
                .Cols(CMlngvsfAldBatchColTapeStickRecp).AllowMerging = blnMerge     'ﾃｰﾌﾟ貼りﾚｼﾋﾟ
                .Cols(CMlngvsfAldBatchColOvenBatch).AllowMerging = blnMerge         'ｵｰﾌﾞﾝﾊﾞｯﾁID
                .Cols(CMlngvsfAldBatchColOvenRecp).AllowMerging = blnMerge          'ｵｰﾌﾞﾝﾚｼﾋﾟ
                .Cols(CMlngvsfAldBatchColAldBatch).AllowMerging = blnMerge          'ALDﾊﾞｯﾁID
                .Cols(CMlngvsfAldBatchColAldBRecp).AllowMerging = blnMerge          'ALDﾚｼﾋﾟ

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfGridMergeCol"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvGetAldBatchRecipe
    '機　能：機種のマスター工順の「ﾃｰﾌﾟ貼り」「ｵｰﾌﾞﾝ」「ALD」ﾚｼﾋﾟを取得する
    '引　数：strPdId            ：機種ID
    '　　　：lstrTapeStickRecipe：ﾃｰﾌﾟ貼り行程ﾚｼﾋﾟ
    '　　　：lstrOvenRecipe     ：ｵｰﾌﾞﾝ行程ﾚｼﾋﾟ
    '　　　：lstrAldRecipe      ：ALD行程ﾚｼﾋﾟ
    '戻り値：
    '作成日：2018/08/20 (Mon) 13:36:16 T.Oide
    '更新日：2018/08/20 (Mon) 13:36:16
    '備　考：
    Private Sub prvGetAldBatchRecipe(ByVal strPdId As String, _
                                     ByRef strTapeStickRecipe As String, _
                                     ByRef strOvenRecipe As String, _
                                     ByRef strAldRecipe As String)
        Dim llngCnt         As Integer
        Dim lblnAns         As Boolean
        Dim lstrFormName    As String
        Dim lstrEventName   As String

        Try
            
            lstrFormName = Me.Name
            lstrEventName = "prvGetAldBatchRecipe"
            
            '@結果を初期化
            strTapeStickRecipe = vbNullString
            strOvenRecipe = vbNullString
            strAldRecipe = vbNullString
            
            With mtypeAldBatchRecipe
            
                '@mtypeAldBatchRecipeに該当機種のﾚｼﾋﾟが既に格納済かﾁｪｯｸ
                For llngCnt = 0 To .lngAldBatchRecipeCnt - 1
                
                    With .typeAldBatchRecipe(llngCnt)
                
                        '@該当親機種か
                        If strPdId = .strParentPdId Then
                            
                            '@ﾚｼﾋﾟを返す
                            strTapeStickRecipe = .strTapeStickRecipe
                            strOvenRecipe = .strOvenRecipe
                            strAldRecipe = .strAldRecipe
                            
                        End If
                        
                    End With
                Next
            
                '@無ければ取得
                If strTapeStickRecipe = vbNullString Then
            
                    '================
                    '@各工程のﾚｼﾋﾟ取得
                    '================
                    lblnAns = pubblnMasAldbatchrecipe_Sel(CMstrmas_aldbatchrecipeVer, _
                                                          mtypeAldBatchRecipe, _
                                                          pstrSBID, _
                                                          strPdId, _
                                                          pubParentPdToAldPd(strPdId, mtypTapeStickList))
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                
                        '@Escﾎﾞﾀﾝを有効
                        Me.CancelButton = Me.cmdClose
                
                        Exit Sub
                    End If
                    
                    '@ﾚｼﾋﾟを返す
                    strTapeStickRecipe = .typeAldBatchRecipe(.lngAldBatchRecipeCnt - 1).strTapeStickRecipe
                    strOvenRecipe = .typeAldBatchRecipe(.lngAldBatchRecipeCnt - 1).strOvenRecipe
                    strAldRecipe = .typeAldBatchRecipe(.lngAldBatchRecipeCnt - 1).strAldRecipe
                    
                End If
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGetAldBatchRecipe"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvSameACrier_Chk
    '機　能：同一Aｷｬﾘｱ設定前ﾁｪｯｸ
    '引　数：lngRowStart   ：開始行
    '　　　：llngRowEn      ：終了行
    '戻り値：True:OK、False：NG
    '作成日：2018/08/20 (Mon) 16:11:38 T.Oide
    '更新日：2018/08/20 (Mon) 16:11:38
    '備　考：
    Private Function prvSameACrier_Chk(ByRef lngRowStart, ByRef lngRowEnd) As Boolean

        Dim llngRow         As Integer
        Dim lblnPRFlag      As Boolean
        Dim lblnNotPRFlag   As Boolean

        Try
            
            '@結果の初期化
            prvSameACrier_Chk = False
            
            With vsfAldBatch
                
                lblnPRFlag = False
                lblnNotPRFlag = False
                
                For llngRow = lngRowStart To lngRowEnd
                    
                    '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟが違う者同士Aｷｬﾘｱに入れようとしていないか
                    '@1回目のﾙｰﾌﾟはﾁｪｯｸをﾊﾟｽ
                    If llngRow <> lngRowStart Then
                    
                        '@1つ上の行と「ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ」が違わないか
                        If .GetData(llngRow, CMlngvsfAldBatchColTapeStickGr) <> _
                           .GetData(llngRow - 1, CMlngvsfAldBatchColTapeStickGr) Then
                            
                            '@違った場合処理を中止
                            '「<TRM151W>$$「テープ貼りグループ」が異なるロットを同一Aキャリアに収納できません。」
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0151)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@対象にﾌｫｰｶｽｾｯﾄ
                            .Row = llngRow
                            .Col = CMlngvsfAldBatchColTapeStickGr
                            Call pubSetFocus(vsfAldBatch)
                            
                            Exit Function
                        End If
                    
                    End If
                    
                    
                    '@PRとPR以外が同一Aｷｬﾘｱに入れようとしていないか
                    '@PR品があったか
                    If .GetData(llngRow, CMlngvsfAldBatchColFlowClass) = CPstrFlowClassPR Then
                        lblnPRFlag = True
                    End If

                    '@PR以外があったか
                    If .GetData(llngRow, CMlngvsfAldBatchColFlowClass) <> CPstrFlowClassPR Then
                        lblnNotPRFlag = True
                    End If

                Next
                
                '@PRとPR以外があったか
                If lblnPRFlag = True And lblnNotPRFlag = True Then
                    
                    '「TRM152W>$$ 量産品(PR)とそれ以外を同一Aキャリアに収納できません。」
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0152)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@対象にﾌｫｰｶｽｾｯﾄ
                    .Row = lngRowEnd
                    .Col = CMlngvsfAldBatchColFlowClass
                    Call pubSetFocus(vsfAldBatch)
                    
                    Exit Function
                End If
                
                '@ﾀﾞﾐｰ、ﾓﾆﾀｰ・品確に対して、複数ﾛｯﾄでAｶｾｯﾄに入れようとしていないか？
                ' ﾀﾞﾐｰ、ﾓﾆﾀｰ・品確は、そのまま1ﾛｯﾄ1Aｷｬﾘｱになる
                For llngRow = lngRowStart To lngRowEnd
                
                    '@2行目以降でﾀﾞﾐｰ、ﾓﾆﾀｰ・品確ではないか(SDとEDもないとは思うが一応入れておく）
                    If llngRow <> lngRowStart And _
                       (.GetData(llngRow, CMlngvsfAldBatchColFlowClass) = CPstrFillerDummy OrElse _
                        .GetData(llngRow, CMlngvsfAldBatchColFlowClass) = CPstrFlowClassMO OrElse _
                        .GetData(llngRow, CMlngvsfAldBatchColFlowClass) = CPstrFlowClassQU OrElse _
                        .GetData(llngRow, CMlngvsfAldBatchColFlowClass) = CPstrSideDummy OrElse _
                        .GetData(llngRow, CMlngvsfAldBatchColFlowClass) = CPstrExtraDummy) Then
                        
                        '@「"<TRM160W>$$[ダミー][モニター][品確]ロットは1ロット→1Aキャリアになります。"」
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0160)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@対象にﾌｫｰｶｽｾｯﾄ
                        .Row = lngRowEnd
                        .Col = CMlngvsfAldBatchColFlowClass
                        Call pubSetFocus(vsfAldBatch)
                        
                        Exit Function
                        
                    End If
                
                Next
                            
                '@↓2020/01/23 (Thu) 10:30:47 T.Oide 「.Netへ反映未」 **************************************************
                '@ﾃｰﾌﾟ貼りﾚｼﾋﾟの違う者同士を同一Aｷｬﾘｱに入れようとしていないか
                For llngRow = lngRowStart To lngRowEnd
        
                    '@1回目のﾙｰﾌﾟはﾁｪｯｸをﾊﾟｽ
                    If llngRow <> lngRowStart Then
            
                        '@1つ上の行と「ﾃｰﾌﾟ貼りﾚｼﾋﾟ」が違わないか
                        If .GetData(llngRow, CMlngvsfAldBatchColTapeStickRecp) <> _
                            .GetData(llngRow - 1, CMlngvsfAldBatchColTapeStickRecp) Then
                    
                            '@違った場合処理を中止
                            '「<TRM151W>$$「テープ貼りレシピ」が異なるロットを同一Aキャリアに収納できません。」
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0168)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                            '@対象にﾌｫｰｶｽｾｯﾄ
                            .Row = llngRow
                            .Col = CMlngvsfAldBatchColTapeStickGr
                            Call pubSetFocus(vsfAldBatch)
                    
                            Exit Function
                        End If
            
                    End If
        
                Next
                '@↑2020/01/23 (Thu) 10:30:47 T.Oide 「.Netへ反映未」 **************************************************

            End With

            '@ﾁｪｯｸOK
            prvSameACrier_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSameACrier_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvNewBatchLotInfo_Disp
    '機　能：新規ﾊﾞｯﾁ作成中に受入在庫を検索し直しした場合に、編集中のﾛｯﾄの情報を「バ」に変える
    '引　数：なし
    '戻り値：
    '作成日：2018/08/20 (Mon) 17:13:53 T.Oide
    '更新日：2018/08/20 (Mon) 17:13:53
    '備　考：
    Private Sub prvNewBatchLotInfo_Disp()

        Dim strLotList      As List(Of String)
        Dim llngCnt         As Integer
        Dim llngCnt2        As Integer

        Try
            
            With vsfAldBatch
                
                '@ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞのﾛｯﾄ情報を配列に格納する
                strLotList = New List(Of String)(.Rows.Count - 1)
                For llngCnt = 1 To .Rows.Count - 1
                    strLotList.Add(.GetData(llngCnt, CMlngvsfAldBatchColLotId))
                Next
                
            End With

            '@受入在庫ﾛｯﾄの情報を「バ」に変更する
            With vsfInvLot
            
                '@ﾛｯﾄの配列で回す
                For llngCnt = 0 To strLotList.Count - 1
                    
                    '@受入在庫のｸﾞﾘｯﾄﾞで回す
                    For llngCnt2 = 1 To .Rows.Count - 1
                    
                        '@ﾛｯﾄは一致したか
                        If strLotList(llngCnt) = .GetData(llngCnt2, CMlngvsfInvLotColLotID) Then
                            '@「バ」を表示する
                            .SetData(llngCnt2, CMlngvsfInvLotColInfo, CPstrBatch)
                            Exit For
                        End If
                        
                    Next
                    
                Next
                
            End With
            
         Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvNewBatchLotInfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvBatchDataRegist
    '機　能：ﾊﾞｯﾁ情報を登録する
    '引　数：strClassDiv：39:登録、06：登録(投入待ち)、05削除
    '戻り値：
    '作成日：2018/08/24 (Fri) 17:07:24 T.Oide
    '更新日：2019/03/26 (Tue) 10:39:55 T.Oide
    '備　考：
    Private Sub prvBatchDataRegist(ByVal strClassDiv As String)

        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngCnt                 As Integer          '汎用ｶｳﾝﾀ
        Dim ltypAldBatch            As typAldBatchList  '登録ﾊﾞｯﾁ情報格納
        Dim lblnQuFindFlag          As Boolean          'ﾛｯﾄﾘｽﾄの中にQUﾛｯﾄがあるかどうか(BATCH_FLOW_CLASS設定用)
        '@↓2020/03/16 (Mon) 14:54:48 T.Oide 「.Netへ反映未」 **************************************************
        'Dim lblnQuMoFindFlag        As Boolean          'ﾛｯﾄﾘｽﾄの中にQU or MOﾛｯﾄがあるかどうか(ﾓﾆﾀｰ有無ﾁｪｯｸ用)
        Dim lblnMoFindFlag          As Boolean          'ﾛｯﾄﾘｽﾄの中にMOﾛｯﾄがあるかどうか(ﾓﾆﾀｰ有無ﾁｪｯｸ用)
        '@↑2020/03/16 (Mon) 14:54:48 T.Oide 「.Netへ反映未」 **************************************************
        Dim lblnAns                 As Boolean
        Dim lstrBatchID             As String

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@ﾌｫｰﾑのﾛｯｸ中は処理を行わない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            '@設定がない場合処理しない
            If vsfAldBatch.Rows.Count = 1 Or dtpThrowInDate.Value = CPstrNullDate Then
                Exit Sub
            End If
            
            '@↓2019/08/06 (Tue) 16:57:48 T.Oide  **************************************************
            '@QUとそれ以外のﾛｯﾄがﾊﾞｯﾁ組されていないか
            If prvChkQu = False Then
                Exit Sub
            End If
            '@↑2019/08/06 (Tue) 16:57:48 T.Oide  **************************************************
            
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称を設定
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"

            '@登録ﾊﾞｯﾁ情報格納
            With ltypAldBatch
                .strClassDiv = strClassDiv
                .strSbID = pstrSBID
                .lngAldBatchListCnt = 1
                .typAldBatchList = New List(Of typAldBatch)(.lngAldBatchListCnt)
                Dim ltypAldBatchTmp As New typAldBatch
                
                With ltypAldBatchTmp
                
                    '@バッチは新規作成か
                    If cmbAldBatch.Text = CMstrBatchNew Then
                        .strBatchId = vbNullString              '@新規登録の場合Batch情報はNULLを渡す
                        lstrBatchID = vbNullString
                    Else
                        .strBatchId = cmbAldBatch.Text
                        lstrBatchID = cmbAldBatch.Text          '@表示再現用
                    End If
                    .strPlanThrowinDate = dtpThrowInDate.Value  '@投入予定日
                    
                    '@ﾓﾆﾀ使用はOnか
                    If optMoni0.Checked = True Then
                        '@ﾓﾆﾀｰあり
                        .steMonitorUseFlag = CMlngChkON
                    Else
                        '@ﾓﾆﾀｰなし
                        .steMonitorUseFlag = CMlngChkOFF
                    End If
                    
                    '@ﾛｯﾄﾘｽﾄの要素設定
                    .lngBatchDetailCnt = vsfAldBatch.Rows.Count - 1
                    .typBatchDetail = New List(Of typBatchDetail)(.lngBatchDetailCnt)
                    Dim ltypBatchDetailTmp As typBatchDetail
                    lblnQuFindFlag = False
                    '@↓2020/03/16 (Mon) 14:55:24 T.Oide 「.Netへ反映未」 **************************************************
                    'lblnQuMoFindFlag = False
                    lblnMoFindFlag = False
                    '@↑2020/03/16 (Mon) 14:55:24 T.Oide 「.Netへ反映未」 **************************************************

                    '@ｸﾞﾘｯﾄﾞでﾙｰﾌﾟして各値を設定
                    For llngCnt = 1 To vsfAldBatch.Rows.Count - 1
                        ltypBatchDetailTmp = New typBatchDetail
                    
                        With ltypBatchDetailTmp
                        
                            .strLotID = vsfAldBatch.GetData(llngCnt, CMlngvsfAldBatchColLotId)                         'ﾛｯﾄID
                            .strPdId = vsfAldBatch.GetData(llngCnt, CMlngvsfAldBatchColPd)                             '機種

                            '@↓2020/01/22 (Wed) 16:40:18 T.Oide 「.Netへ反映未」**************************************************
                            '.strWfQty = vsfAldBatch.GetData(llngCnt, CMlngvsfAldBatchColWfNum)                         'Wf数
                            '.strChipQty = vsfAldBatch.GetData(llngCnt, CMlngvsfAldBatchColChipNum)                     'Chip数
                            '@-----------------------------------------------------------------------------------------------------------
                            .strWfQty = CLng(vsfAldBatch.GetData(llngCnt, CMlngvsfAldBatchColWfNum))                   'Wf数
                            .strChipQty = CLng(vsfAldBatch.GetData(llngCnt, CMlngvsfAldBatchColChipNum))               'Chip数
                            '@↑2020/01/22 (Wed) 16:40:18 T.Oide 「.Netへ反映未」**************************************************

                            .strACrrierGroup = vsfAldBatch.GetData(llngCnt, CMlngvsfAldBatchColACarrierGr)             'Aｷｬﾘｱｸﾞﾙｰﾌﾟ
                            .strTapeStickGr = vsfAldBatch.GetData(llngCnt, CMlngvsfAldBatchColTapeStickGr)             'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                            .strAtrayChipNum = vsfAldBatch.GetData(llngCnt, CMlngvsfAldBatchColACarrierChipNum)        'AｷｬﾘｱChip数
                            .strFlowClass = vsfAldBatch.GetData(llngCnt, CMlngvsfAldBatchColFlowClass)                 '種別
                            .strTapeStickRrecipeId = vsfAldBatch.GetData(llngCnt, CMlngvsfAldBatchColTapeStickRecp)    'ﾃｰﾌﾟ貼りﾚｼﾋﾟ
                            .strOvenRecipeId = vsfAldBatch.GetData(llngCnt, CMlngvsfAldBatchColOvenRecp)               'ｵｰﾌﾞﾝﾚｼﾋﾟ
                            .strAldRecipeId = vsfAldBatch.GetData(llngCnt, CMlngvsfAldBatchColAldBRecp)                'ALDﾚｼﾋﾟ
                            
                            '@QUか
                            If .strFlowClass = CPstrFlowClassQU Then
                                lblnQuFindFlag = True
                                '@↓2020/03/16 (Mon) 14:55:47 T.Oide 「.Netへ反映未」 **************************************************
                                'lblnQuMoFindFlag = True
                                '@↑2020/03/16 (Mon) 14:55:47 T.Oide 「.Netへ反映未」 **************************************************
                            End If
                            
                            '@MOか
                            If .strFlowClass = CPstrFlowClassMO Then
                                '@↓2020/03/16 (Mon) 14:56:22 T.Oide 「.Netへ反映未」 **************************************************
                                'lblnQuMoFindFlag = True
                                lblnMoFindFlag = True
                                '@↑2020/03/16 (Mon) 14:56:22 T.Oide 「.Netへ反映未」 **************************************************
                            End If
                            
                        End With

                        .typBatchDetail.Add(ltypBatchDetailTmp)
                    Next
                    
                    '@QUﾛｯﾄが存在するか
                    If lblnQuFindFlag = True Then
                        '@QUが存在する場合、品確認
                        .strBatchFlowClass = CMstrQuality
                    Else
                        '@QUがない場合、ﾌﾟﾛﾀﾞｸﾄ
                        .strBatchFlowClass = CMstrProduct
                    End If
                    
                End With

                .typAldBatchList.Add(ltypAldBatchTmp)
            
                '@==========
                '@ ﾓﾆﾀｰﾁｪｯｸ
                '@ (ﾓﾆﾀｰ有でﾓﾆﾀｰﾛｯﾄがない場合、ﾓﾆﾀｰ無でﾓﾆﾀｰﾛｯﾄ有の場合MG）
                '@==========
                '@適用か
                If .strClassDiv = CPstrCD06 Then
                    
                    '@↓2020/03/16 (Mon) 14:57:25 T.Oide 「.Netへ反映未」 **************************************************
                    ''@ﾓﾆﾀｰ有でﾓﾆﾀｰﾛｯﾄなしか
                    'If optMoni0.Checked = True And lblnQuMoFindFlag = False Then
                    '@--------------------------------------------------------------------------
                    '@ﾓﾆﾀｰ有Onでﾓﾆﾀｰﾛｯﾄなしか
                    If optMoni0.Checked = True And lblnMoFindFlag = False Then
                    '@↑2020/03/16 (Mon) 14:57:25 T.Oide 「.Netへ反映未」 **************************************************

                        '@"<TRM162W>$$モニタ有無の設定と実際のﾛｯﾄの構成が異なっています。$設定を見直してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0162)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Exit Sub
                        
                    End If
                    
                    '@↓2020/03/16 (Mon) 14:58:44 T.Oide 「.Netへ反映未」 **************************************************
                    ''@ﾓﾆﾀｰ無でﾓﾆﾀｰﾛｯﾄありか
                    'If optMoni1.Checked = True And lblnQuMoFindFlag = True Then
                    '@---------------------------------------------------------------------------
                    '@ﾓﾆﾀｰ無Onでﾓﾆﾀｰﾛｯﾄありか
                    If optMoni1.Checked = True And lblnMoFindFlag = True Then
                    '@↑2020/03/16 (Mon) 14:58:44 T.Oide 「.Netへ反映未」 **************************************************

                        '@"<TRM162W>$$モニタ有無の設定と実際のﾛｯﾄの構成が異なっています。$設定を見直してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0162)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Exit Sub
                        
                    End If
                    
                End If

            End With

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾊﾞｯﾁ情報を登録
            If prvblnAldBatchRegist(CMstrmas_aldbatchRegistVer, ltypAldBatch) = True Then

                '@"<TRM46I>$$%1を登録しました。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0046, CmstrBatchString)
                Call pubVsfInfo_Disp(pstrDMsg)

            Else
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If

            '@変更ﾌﾗｸﾞﾘｾｯﾄ
            mblnEditFlag = False

            '================
            '@ALDﾊﾞｯﾁ一覧取得
            ' 最新を取得して表示
            '================
            lblnAns = pubblnAldBatchList_Sel(CMstrbataldbatchlistVer, _
                                             mtypAldBatchList)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose

                Exit Sub
            End If

            '@ﾊﾞｯﾁｺﾝﾎﾞ設定
            Call prvcmbAldBatch_Disp()

            '@退避したバッチIDあるか
            If lstrBatchID <> vbNullString Then
                '@退避バッチIDを再表示
                cmbAldBatch.Text = lstrBatchID
            Else
                '@一番最後のﾊﾞｯﾁ(登録したﾊﾞｯﾁ)を表示
                ' ﾁｪﾝｼﾞｲﾍﾞﾝﾄが走って表示する
                cmbAldBatch.ListIndex = cmbAldBatch.ListCount - 1
            End If
            
            '================
            '@受入在庫情報取得
            ' 最新を取得して表示
            '================
            Call cmdNowList_Click(cmdNowList, EventArgs.Empty)

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvBatchDataRegist"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvSetACarrierGrChk
    '機　能：Aｷｬﾘｱｸﾞﾙｰﾌﾟが設定済かﾁｪｯｸ
    '引　数：なし
    '戻り値：True：OK、False：NG(未設定あり)
    '作成日：2018/08/24 (Fri) 13:32:23 T.Oide
    '更新日：2018/08/24 (Fri) 13:32:23
    '備　考：
    Private Function prvSetACarrierGrChk() As Boolean

        Dim llngCnt     As Integer

        Try

            '@結果の初期化
            prvSetACarrierGrChk = True

            With vsfAldBatch

                '@ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞで回す
                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@Aｷｬﾘｱｸﾞﾙｰﾌﾟ未設定か
                    If .GetData(llngCnt, CMlngvsfAldBatchColACarrierGr) = vbNullString Then
                        '@NG:未設定あり
                        prvSetACarrierGrChk = False
                        Exit For
                    End If
                Next
                
            End With

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvBatchDataRegist"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvEditCheck
    '機　能：編集中ﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2018/08/28 (Tue) 13:08:31 T.Oide
    '更新日：2018/08/28 (Tue) 13:08:31
    '備　考：
    Private Function prvEditCheck() As Boolean
        
        Dim llngAns     As Integer
        
        Try

            '@結果の初期化
            prvEditCheck = False

            '@編集中の場合ﾒｯｾｰｼﾞを表示
            If mblnEditFlag = True Then
                
                '@"<TRM1AW>$$編集中です。 内容を破棄してよろしいですか？"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                
                '@ﾒｯｾｰｼﾞBoxにて「いいえ」が選択されたか
                If llngAns = vbNo Then
                    Exit Function
                End If
                
            End If

            '@結果OK
            prvEditCheck = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvEditCheck"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvInitDataSelDisp
    '機　能：初期化ﾃﾞｰﾀ取得&表示
    '引　数：なし
    '戻り値：
    '作成日：2018/08/28 (Tue) 13:26:26 T.Oide
    '更新日：2018/08/28 (Tue) 13:26:26
    '備　考：
    Private Function prvInitDataSelDisp() As Boolean

        Dim lblnAns             As Boolean
        Dim lstrClassDivision   As String
        Dim lstrFormName        As String
        Dim lstrEventName       As String

        Try
            
            '@初期化
            prvInitDataSelDisp = False
            lstrFormName = Me.Text
            lstrEventName = "prvInitDataSelDisp()"
            
            '================
            '@貼りｸﾞﾙｰﾌﾟ取得
            '================
            lblnAns = pubblnMasTapeStickGrList_Sel(CMstrmas_tapeStickGrListVer, _
                                                   mtypTapeStickList, _
                                                   pstrSBID)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose

                Exit Function
            End If

            '================
            '@機種一覧取得(組立機種)
            '================
            '@処理区分に"2A02：全機種・全種別"をｾｯﾄ
            lstrClassDivision = CPstrCD2A & CPstrCD30
            lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                          lstrClassDivision, _
                                          mtypPdList, _
                                          mlngPdListCnt, _
                                          CPstrSBID2A0)

            '@機種区分一覧取得結果が"False：取得失敗"か
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効に戻す
                Me.CancelButton = Me.cmdClose
                Exit Function
            End If

            '================
            '@種別一覧取得
            '================
            lstrClassDivision = CPstrCD02                      '全て
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
                Me.CancelButton = Me.cmdClose

                Exit Function

            End If

            '================
            '@ALDﾊﾞｯﾁ一覧取得
            '================
            lblnAns = pubblnAldBatchList_Sel(CMstrbataldbatchlistVer, _
                                             mtypAldBatchList)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose

                Exit Function
            End If

            '@ ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟｺﾝﾎﾞ設定
            Call prvcmbTapStickGr_Disp()

            '@ 機種ｺﾝﾎﾞ設定
            Call prvcmbPd_Disp()
           
            '@種別ｺﾝﾎﾞ設定
            Call prvcmbFlowClasst_Disp()
            
            '@ﾊﾞｯﾁｺﾝﾎﾞ設定
            Call prvcmbAldBatch_Disp()

            '@結果成功
            prvInitDataSelDisp = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvInitDataSelDisp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvDivideLot
    '機　能：同一Aｷｬﾘｱｸﾞﾙｰﾌﾟ設定でAｷｬﾘｱ収容数をｵｰﾊﾞしている場合、ﾛｯﾄを分割表示して丁度満タンになるようにする
    '引　数：lngRowStart：
    '　　　：lngRowEnd：
    '戻り値：
    '作成日：2018/08/29 (Wed) 15:08:51 T.Oide
    '更新日：2018/08/29 (Wed) 15:08:51
    '備　考：
    Private Sub prvDivideLot(ByVal lngRowStart As Integer, ByRef lngRowEnd As Integer)

        Dim llngCnt                 As Integer
        Dim llngACarrierChipNum     As Integer  'Aｷｬﾘｱ収容数
        Dim llngOverRow             As Integer  '収容数をｵｰﾊﾞするﾛｯﾄの行
        Dim llngCalkChipNum         As Integer  'ﾛｯﾄづつ足し算したChip数

        Try
            
            With vsfAldBatch
                
                '@Aｷｬﾘｱ収容数を格納(合計する先頭行から取得)
                llngACarrierChipNum = CLng(.GetData(lngRowStart, CMlngvsfAldBatchColACarrierChipNum))

                '@どこまで足したらｵｰﾊﾞするか調べる
                
                For llngCnt = lngRowStart To lngRowEnd
                    
                    '@CHIPを足していく
                    llngCalkChipNum = llngCalkChipNum + CLng(IIf(.GetData(llngCnt, CMlngvsfAldBatchColChipNum) <> vbNullString, _
                                                                 .GetData(llngCnt, CMlngvsfAldBatchColChipNum), 0))
                    
                    '@丁度か
                    If llngCalkChipNum = llngACarrierChipNum Then
                        '@丁度の行がある場合は、そこをEnd行にして戻す
                        lngRowEnd = llngCnt
                        Exit Sub
                    End If
                    
                    '@ｵｰﾊﾞしたか
                    If llngCalkChipNum > llngACarrierChipNum Then
                        '@ｵｰﾊﾞ行を格納
                        llngOverRow = llngCnt
                        Exit For
                    End If
                    
                Next

                '@ｵｰﾊﾞ行をｺﾋﾟｰして2行にする
                .AddItem(.GetCellRange(llngOverRow, CMlngvsfAldBatchColNo, llngOverRow, .Cols.Count - 1).Clip, llngOverRow)
                
                '@行の高さの設定
                .Rows(llngOverRow).Height = CMlngVsfHeight
                
                '@上の行に満ﾀﾝになるﾁｯﾌﾟ数を設定
                '@下の行にｵｰﾊﾞ分のﾁｯﾌﾟ数を設定　背景オレンジ表示
                .SetData(llngOverRow, CMlngvsfAldBatchColChipNum, _
                    IIf(.GetData(llngOverRow + 1, CMlngvsfAldBatchColChipNum) <> vbNullString, _
                        .GetData(llngOverRow + 1, CMlngvsfAldBatchColChipNum), 0) - (llngCalkChipNum - llngACarrierChipNum))
                .SetData(llngOverRow + 1, CMlngvsfAldBatchColChipNum, (llngCalkChipNum - llngACarrierChipNum))
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngVbColorOrange")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)
                Dim cellRange As CellRange = .GetCellRange(llngOverRow, CMlngvsfAldBatchColLotId, llngOverRow + 1, CMlngvsfAldBatchColChipNum)
                cellRange.Style = newStyle

                '@ｵｰﾊﾞ行(ﾋﾟｯﾀﾘ満タンになる行を返して、lngRowEndまでを同一Aｶｾｯﾄに設定することとして処理を継続させる)
                lngRowEnd = llngOverRow
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvDivideLot"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvACarrieDivideBackColor
    '機　能：Aｷｬﾘｱを跨るﾛｯﾄが存在する場合背景を黄色表示する
    '引　数：なし
    '戻り値：
    '作成日：2018/08/29 (Wed) 16:11:55 T.Oide
    '更新日：2018/08/29 (Wed) 16:11:55
    '備　考：
    Private Sub prvACarrieDivideBackColor()

        Dim llngRow         As Integer

        Try
            
            With vsfAldBatch
            
                '@ｸﾞﾘｯﾄﾞで回す(2行目からﾁｪｯｸ)
                For llngRow = 2 To .Rows.Count - 1
                    
                    '@上の行とﾛｯﾄIDが同じか
                    If .GetData(llngRow - 1, CMlngvsfAldBatchColLotId) = _
                       .GetData(llngRow, CMlngvsfAldBatchColLotId) Then
                       
                       '@背景色をオレンジにする(2行、ﾛｯﾄID～ﾁｯﾌﾟ列まで)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngVbColorOrange")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)
                        Dim cellRange As CellRange = .GetCellRange(llngRow - 1, CMlngvsfAldBatchColLotId, _
                                               llngRow, CMlngvsfAldBatchColChipNum)
                        cellRange.Style = newStyle
                    End If
                    
                Next
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvDivideLot"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvRegist_Chk
    '機　能：登録前ﾁｪｯｸ
    '引　数：なし
    '戻り値：Ture：OK、Flase：NG
    '作成日：2018/08/30 (Thu) 10:25:29 T.Oide
    '更新日：2019/10/29 (Tue) 17:50:51 T.Oide
    '備　考：
    Private Function prvRegist_Chk() As Boolean

        Try
            
            '@結果初期化
            prvRegist_Chk = False

            'バッチ編成ロットの全Chip数照合
            If prvTotalBatchChipCntCheck = False Then
                Exit Function
            End If
            
            '@ﾁｪｯｸ1：Aｷｬﾘｱｸﾞﾙｰﾌﾟがｽﾌﾟﾘｯﾄﾞ状態になっていないか
            If prvRegist_Chk1 = False Then
                Exit Function
            End If
            
            '@ﾁｪｯｸ2：Aｷｬﾘｱを5つ以上使っていないか
            If prvRegist_Chk2 = False Then
                Exit Function
            End If
            
            '@ﾁｪｯｸ3：ﾓﾆﾀｰ有無とﾊﾞｯﾁの内容に矛盾はないか
            If prvRegist_Chk3 = False Then
                Exit Function
            End If
            
            prvRegist_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    ''' <summary>
    ''' バッチ組のロット全Chip数の照合
    ''' </summary>
    ''' <returns></returns>
    Private Function prvTotalBatchChipCntCheck() As Boolean

        Dim lintRow                 As Integer
        Dim lintTotalBatchChipCnt   As Integer
        Dim lintACarrierGrReference As Integer

        Try
            
            '初期化
            prvTotalBatchChipCntCheck = False
            lintTotalBatchChipCnt = 0
            lintACarrierGrReference = 1

            With vsfAldBatch
                
                For lintRow = 1 To .Rows.Count - 1

                    'ACarrierグループの数値は昇順になっていることの確認
                    Dim lintCurrentACarrier As Integer = CInt(.GetData(lintRow, CMlngvsfAldBatchColACarrierGr))
                    If lintCurrentACarrier = lintACarrierGrReference Then
                        lintACarrierGrReference = lintCurrentACarrier       
                    ElseIf lintCurrentACarrier = (lintACarrierGrReference + 1) Then
                        lintACarrierGrReference = lintACarrierGrReference + 1
                    Else
                        Exit For
                    End If

                    'バッチ編成数の計算
                    If IsNumeric(.GetData(lintRow, CMlngvsfAldBatchColChipNum)) Then
                        lintTotalBatchChipCnt = lintTotalBatchChipCnt + CInt(.GetData(lintRow, CMlngvsfAldBatchColChipNum))
                    End If
                Next
                
            End With
            
            'バッチ編成Chip数に異常がある場合は終了
            If mintTotalBatchChipCnt <> lintTotalBatchChipCnt Then
                '「"<TRM180W>$$設定に異常が見つかりました。$最初からやり直してください。"」表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0180)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Exit Function
            End If

            prvTotalBatchChipCntCheck = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvTotalBatchChipCntCheck"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvRegist_Chk1
    '機　能：Aｷｬﾘｱｸﾞﾙｰﾌﾟがｽﾌﾟﾘｯﾄﾞ状態になっていないかﾁｪｯｸする
    '引　数：なし
    '戻り値：True:OK、False:NG
    '作成日：2019/10/29 (Tue) 17:49:33 T.Oide
    '更新日：2019/10/29 (Tue) 17:49:33
    '備　考：
    Private Function prvRegist_Chk1() As Boolean

        Dim llngCnt                 As Integer
        Dim lstrACarrierGr          As String       'ﾁｪｯｸ中のAｷｬﾘｱｸﾞﾙｰﾌﾟ
        Dim lstrBefACarrierGr       As String       '1つ前のAｷｬﾘｱｸﾞﾙｰﾌﾟ
        Dim llngGrouNum             As Integer      'ｸﾞﾙｰﾌﾟ番号
        Dim llngBefGrouNum          As Integer      '1つ前ｸﾞﾙｰﾌﾟ番号
        Dim lblnGrStart(10)         As Boolean      'ｸﾞﾙｰﾌﾟ1～10(通常1～4までしかないが一応10まで)まで、ｸﾞﾙｰﾌﾟが始まったらTrueにする
        Dim lblnGrEnd(10)           As Boolean      'ｸﾞﾙｰﾌﾟが終わったらTrueにする
                                                    'ｸﾞﾙｰﾌﾟ開始時にｸﾞﾙｰﾌﾟ終了がTrueだったらﾁｪｯｸNGを返す
        Try
            
            '@結果初期化
            prvRegist_Chk1 = True
            For llngCnt = 0 To 10
                lblnGrStart(llngCnt) = False
                lblnGrEnd(llngCnt) = False
            Next
            
            With vsfAldBatch
                
                '@ｸﾞﾘｯﾄﾞを回す
                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@Aｷｬﾘｱｸﾞﾙｰﾌﾟ格納
                    lstrACarrierGr = .GetData(llngCnt, CMlngvsfAldBatchColACarrierGr)
                    
                    '@Aｷｬﾘｱｸﾞﾙｰﾌﾟが変わったか
                    If lstrACarrierGr <> lstrBefACarrierGr Then
                        
                        '@ｸﾞﾙｰﾌﾟ番号格納
                        llngGrouNum = CLng(lstrACarrierGr)
                        
                        '@1回目は値がないのでﾊﾟｽ
                        If llngCnt <> 1 Then
                            llngBefGrouNum = CLng(lstrBefACarrierGr)
                        End If
                        
                        '@自分の終了ﾌﾗｸﾞはTrueではないか
                        If lblnGrEnd(llngGrouNum - 1) = True Then
                        
                            '@Trueの場合ﾁｪｯｸNG
                            prvRegist_Chk1 = False
                            
                            '@「"<TRM155W>$$ 「Aキャリアグループ(%1)」の設定が不正です。設定を見直してください。"」表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0155, lstrACarrierGr)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit For
                        End If
                                        
                        '@自分の開始ﾌﾗｸﾞをTrueにする
                        lblnGrStart(llngGrouNum - 1) = True
                        
                        '@1回目は値がないのでﾊﾟｽ
                        If llngCnt <> 1 Then
                            '@前ｸﾞﾙｰﾌﾟの終了ﾌﾗｸﾞをTrueにする
                            lblnGrEnd(llngBefGrouNum - 1) = True
                        End If
                        
                    End If
                    
                    '@1つ前のAｷｬﾘｱｸﾞﾙｰﾌﾟとして退避
                    lstrBefACarrierGr = lstrACarrierGr
                    
                Next
                
            End With
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvRegist_Chk1"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvRegist_Chk2
    '機　能：ｷｬﾘｱを5つ以上使っていないかﾁｪｯｸ(5個までで制限)
    '引　数：なし
    '戻り値：True:OK、Fakse：NG
    '作成日：2019/10/29 (Tue) 17:47:37 T.Oide
    '更新日：2019/10/29 (Tue) 17:47:37
    '備　考：
    Private Function prvRegist_Chk2() As Boolean

        Dim lstrACarrierGrList      As List(Of String)  'Aｷｬﾘｱｸﾞﾙｰﾌﾟのﾘｽﾄを格納
        Dim llngListCnt             As Integer          'Aｷｬﾘｱのｶｳﾝﾀｰ
        Dim lblnFind                As Boolean
        Dim llngCnt                 As Integer
        Dim llngCnt2                As Integer

        Try

            prvRegist_Chk2 = True

            With vsfAldBatch
                
                '@初期化
                llngListCnt = 0
                lstrACarrierGrList = New List(Of String)
                
                '@ｸﾞﾘｯﾄﾞを回す
                For llngCnt = 1 To .Rows.Count - 1
                
                    '@ｷｬﾘｱｸﾞﾙｰﾌﾟをｶｳﾝﾄして5ｶｾｯﾄより多く使っていないか確認する
                    lblnFind = False
                    For llngCnt2 = 0 To llngListCnt - 1
                        '@一致するか(既に格納済か)
                        If lstrACarrierGrList(llngCnt2) = _
                           .GetData(llngCnt, CMlngvsfAldBatchColACarrierGr) Then
                            '@格納済ﾌﾗｸﾞOn
                            lblnFind = True
                        End If
                    Next
                    
                    '@未格納か
                    If lblnFind = False Then
                    
                        '@配列にAｷｬﾘｱｸﾞﾙｰﾌﾟ格納
                        llngListCnt = llngListCnt + 1
                        lstrACarrierGrList.Add(.GetData(llngCnt, CMlngvsfAldBatchColACarrierGr))
                    End If

                Next
                
                '@要素が5より多いか
                If llngListCnt > CMlngACriierMaxNum Then
                    '@Aｷｬﾘｱを5個以上使用しています。設定を見直してください。ﾒｯｾｰｼﾞ表示
                    
                    '@「<TRM164W>$$Aキャリアは1バッチ[5個]までです。$設定を見直してください。」表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0164, CMlngACriierMaxNum)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾁｪｯｸ結果NG
                    prvRegist_Chk2 = False
                End If
                
            End With
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvRegist_Chk2"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvRegist_Chk3
    '機　能：ﾓﾆﾀｰの有無とﾊﾞｯﾁの内容に矛盾は無いか
    '引　数：なし
    '戻り値：True:OK、Fakse：NG
    '作成日：2019/10/29 (Tue) 17:47:37 T.Oide
    '更新日：2019/10/29 (Tue) 17:47:37
    '備　考：
    Private Function prvRegist_Chk3() As Boolean

        Dim llngCnt     As Integer
        Dim lblnFind_QU As Boolean
        Dim lblnFind_MO As Boolean
        
        Try

            prvRegist_Chk3 = True

            '@ﾁｪｯｸ内容
            '1）ﾊﾞｯﾁ内にQUがあり、ﾓﾆﾀ有りOnの場合ﾒｯｾｰｼﾞ
            '2）ﾊﾞｯﾁ内にMOがあり、ﾓﾆﾀ無しOnの場合ﾒｯｾｰｼﾞ
            '3）ﾊﾞｯﾁ内にMOがなし、ﾓﾆﾀ有りOnの場合ﾒｯｾｰｼﾞ


            With vsfAldBatch
                
                '@初期化
                lblnFind_QU = False
                lblnFind_MO = False
                
                '@ｸﾞﾘｯﾄﾞを回す(QUかMOがあるか調べる)
                For llngCnt = 1 To .Rows.Count - 1
                
                    '@QUか
                    If .GetData(llngCnt, CMlngvsfAldBatchColFlowClass) = "QU" Then
                        lblnFind_QU = True
                    End If
                    
                    '@MOか
                    If .GetData(llngCnt, CMlngvsfAldBatchColFlowClass) = "MO" Then
                        lblnFind_MO = True
                    End If
                    
                Next

                '@=================
                '@ QUはあったか
                '@=================
                If lblnFind_QU = True Then
                    
                    '@ﾓﾆﾀｰ(有)Onか
                    If optMoni0.Checked = True Then
                    
                        '@「<TRM167W>$$「モニタ(有)」Onの場合、バッチに[品確ロット]を含めることはできません。」表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0167, CMlngACriierMaxNum)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                        '@ﾁｪｯｸ結果NG
                        prvRegist_Chk3 = False
                        Exit Function
                    End If
                End If
                
                '@=================
                '@ MOはあったか
                '@=================
                If lblnFind_MO = True Then
                    
                    '@ﾓﾆﾀｰ(無)Onか
                    If optMoni1.Checked = True Then
                    
                        '@「<TRM165W>$$「モニタ(無)」Onでバッチに[モニターロット]が含まれています。」表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0165, CMlngACriierMaxNum)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@ﾁｪｯｸ結果NG
                        prvRegist_Chk3 = False
                    End If
                    
                Else
                    '@ﾓﾆﾀｰ(有)Onか
                    If optMoni0.Checked = True Then
                    
                        '@「<TRM166W>$$「モニタ(有)」Onでバッチに[モニターロット]が含まれていません。」表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0166, CMlngACriierMaxNum)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                        '@ﾁｪｯｸ結果NG
                        prvRegist_Chk3 = False
                    End If
                    
                End If
                
            End With
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvRegist_Chk3"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvAldInvListSel
    '機　能：ALDの受入在庫の情報を取得して表示する
    '引　数：なし
    '戻り値：
    '作成日：2018/11/05 (Mon) 16:42:03 T.Oide
    '更新日：2018/11/05 (Mon) 16:42:03
    '備　考：
    Private Sub prvAldInvListSel()

        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypInvAcptLotListReq   As invAcptLotListReq    '要求格納構造体
        Dim ltypInvAcptLotListAns   As InvAcptLotListAns    '応答格納構造体
        Dim llngInvAcptLotListCnt   As Integer              '応答ﾃﾞｰﾀﾛｯﾄﾘｽﾄ数
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngLoopCnt             As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrTemp()              As String               '一時取得
        Dim llngCnt                 As Integer
        Dim llngCnt2                As Integer
        Dim llngCnt3                As Integer
        Dim llngPdCnt               As Integer

        Try

            '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟｺﾝﾎﾞが空欄 or 0項目で
            '@機種ｺﾝﾎﾞが空欄 or 0項目か
            If (cmbTapStickGr.Text = vbNullString Or cmbTapStickGr.Text = CMstrCmbAddedCommentNone) And _
               (cmbPD.Text = vbNullString Or cmbPD.Text = CMstrCmbAddedCommentNone) Then
                Call pubSetFocus(cmbPD)
                Exit Sub
            End If

            '@種別ｺﾝﾎﾞが空欄 or 0項目か
            If cmbFlowClass.Text = vbNullString Or _
               cmbFlowClass.Text = CMstrCmbAddedCommentNone Then
                Call pubSetFocus(cmbFlowClass)
                Exit Sub
            End If

            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
            lstrFormName = Me.Name
            lstrEventName = "prvAldInvListSel"

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@受入在庫ｸﾞﾘｯﾄﾞ初期化
            Call prvvGrid_Init(vsfInvLot, False)

            '@要求格納構造体の初期化
            ltypInvAcptLotListReq.typPdList = New List(Of PDList)
            ltypInvAcptLotListReq.typFlowClassList = New List(Of FlowClassList)

            '@要求格納構造体へ格納
            With ltypInvAcptLotListReq
                .strMsgVer = CMstrinv_acptlotlistVer                                            'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strClassDivision = CPstrCD02           '02:全件検索
                .strSbID = pstrSBID                                                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                
                        
                '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ情報を機種情報として格納
                ' 機種ｺﾝﾎﾞで選択された機種とかぶるかもしれないがIN句で検索されるので問題なし）
                '
                '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟｺﾝﾎﾞで選択されたｸﾞﾙｰﾌﾟで回す
                lstrTemp = Split(cmbTapStickGr.Value, vbTab)
                llngPdCnt = 0
                For llngCnt = LBound(lstrTemp) To UBound(lstrTemp)
                
                    '@対象ｸﾞﾙｰﾌﾟを構造体から探す
                    For llngCnt2 = 0 To mtypTapeStickList.lngTapeStickGrCnt - 1
                    
                        '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟが一致したか
                        If lstrTemp(llngCnt) = mtypTapeStickList.typTapeStickGr(llngCnt2).strTapeStickGr Then
                        
                            '@該当ｸﾞﾙｰﾌﾟの機種を配列に追加
                            For llngCnt3 = 0 To mtypTapeStickList.typTapeStickGr(llngCnt2).lngPdListCnt - 1
                                '@機種IDを追加
                                Dim ltypPDListTmp As New PDList
                                ltypPDListTmp.strPdId = mtypTapeStickList.typTapeStickGr(llngCnt2).typPdList(llngCnt3).strParentPdId
                                .typPdList.Add(ltypPDListTmp)
                            Next
                            llngPdCnt = llngPdCnt + llngCnt3
                            Exit For
                        End If
                    Next
                
                Next
                
                '@機種情報格納
                .lngPdCnt = cmbPD.ValueCount + llngPdCnt                                        'PD_IDｶｳﾝﾄ数(貼りｸﾞﾙｰﾌﾟで追加した分ゲタ上げ)
                lstrTemp = Split(cmbPD.Value, vbTab)
                For llngLoopCnt = LBound(lstrTemp) To UBound(lstrTemp)
                    Dim ltypPDListTmp As New PDList
                    ltypPDListTmp.strPdId = lstrTemp(llngLoopCnt)                               '機種ID
                    .typPdList.Add(ltypPDListTmp)
                Next llngLoopCnt

                '@種別情報格納
                .lngFlowClassCnt = cmbFlowClass.ValueCount                                      'FlowClassｶｳﾝﾄ数
                lstrTemp = Split(cmbFlowClass.Value, vbTab)
                For llngLoopCnt = LBound(lstrTemp) To UBound(lstrTemp)
                    Dim ltypFlowClassListTmp As New FlowClassList
                    ltypFlowClassListTmp.strFlowClass = lstrTemp(llngLoopCnt)                   '種別ID
                    .typFlowClassList.Add(ltypFlowClassListTmp)
                Next llngLoopCnt

            End With

            '@受入在庫Lot一覧取得
            lblnAns = pubblnInvAcptlotList_Sel(ltypInvAcptLotListReq, _
                                               ltypInvAcptLotListAns, _
                                               llngInvAcptLotListCnt)
            '@結果判定
            If lblnAns = True Then

                '@一覧表示
                Call prvvsfInvLot_Disp(ltypInvAcptLotListAns, llngInvAcptLotListCnt)

                '@作成中のﾊﾞｯﾁがある場合、受入在庫の表示を「バ(ﾊﾞｯﾁ編成済)」に変える
                If cmbAldBatch.Text = CMstrBatchNew And vsfAldBatch.Rows.Count > 1 Then
                
                    '@受入在庫ﾛｯﾄの情報を「バ」に変える
                    Call prvNewBatchLotInfo_Disp()
                End If

                
                If vsfInvLot.Enabled = True Then
                    '@一覧へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(vsfInvLot)
                Else
                    '@最新取得ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmdNowList)
                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)

            Else

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                vsfInvLot.Enabled = False

                Exit Sub
            End If

            If vsfInvLot.Rows.Count <= vsfInvLot.Rows.Fixed Then
                vsfInvLot.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvAldInvListSel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvLotRsvListSel
    '機　能：ALDﾗｲﾝの投入待ちﾛｯﾄ(ﾀﾞﾐｰ、ﾓﾆﾀｰ、品確)一覧取得&表示
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/05 (Mon) 16:47:24 T.Oide
    '更新日：2019/02/27 (Wed) 11:15:18 T.Oide
    '備　考：
    Private Sub prvLotRsvListSel()

        Dim lstrFormName            As String
        Dim lstrEventName           As String
        Dim llngcFlowClassCnt       As Integer              '種別配列ｶｳﾝﾄ
        Dim ltypLotRlst             As List(Of typLotRlst)  '投入予定ﾛｯﾄ一覧格結果納用の構造体
        Dim ltypLotresvlist         As Lotresvlist          '送信ﾒｯｾｰｼﾞ（投入予定ﾛｯﾄ一覧）格納用
        Dim lblnAns                 As Boolean              '戻り値
        Dim ltypInvAcptLotListAns   As InvAcptLotListAns    '在庫ﾛｯﾄ一覧表示用
        Dim llngInvAcptLotListCnt   As Integer              '在庫ﾛｯﾄ一覧ｶｳﾝﾄ
        Dim llngCnt                 As Integer
        
        Try
            
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
            lstrFormName = Me.Name
            lstrEventName = "prvLotRsvListSel"

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@受入在庫ｸﾞﾘｯﾄﾞ初期化
            Call prvvGrid_Init(vsfInvLot, False)

            '@投入予定一覧取得用ﾒｯｾｰｼﾞ情報格納
            With ltypLotresvlist
            
                '@構造体のｸﾘｱ
                llngcFlowClassCnt = 5
                
                .typFlowClassList = New List(Of FlowClassList)(llngcFlowClassCnt)
                .typFlowClassList.Add(New FlowClassList With { .strFlowClass = CPstrFlowClassMO })
                .typFlowClassList.Add(New FlowClassList With { .strFlowClass = CPstrFlowClassQU })
                .typFlowClassList.Add(New FlowClassList With { .strFlowClass = CPstrExtraDummy })
                .typFlowClassList.Add(New FlowClassList With { .strFlowClass = CPstrFillerDummy })
                .typFlowClassList.Add(New FlowClassList With { .strFlowClass = CPstrSideDummy })
                
                '@処理区分(0Z：品確、ﾓﾆﾀｰ、ﾀﾞﾐｰ)
                .strClassDivision = CPstrCD0Z
                '@ﾛｯﾄID
                .strLotID = vbNullString

            End With

        '@↓2019/02/27 (Wed) 11:15:09 T.Oide **************************************************
            '@構造体の最初の要素を定義して機種IDを空にしておく
            '戻りが空の場合の対応(本当は取得側でﾃﾞｰﾀなしでﾊﾝﾄﾞﾘﾝｸﾞすればよいが、急ぐので暫定で対応する)
            'ReDim Preserve ltypLotRlst(1)
            'ltypLotRlst(1).strPdId = vbNullString
        '@↑2019/02/27 (Wed) 11:15:09 T.Oide **************************************************

            '@=======================
            '@ 投入予定ﾛｯﾄ一覧取得結果
            '@=======================
            lblnAns = pubblnLotRsvlist__Sel(CMstrlot_rsvlist_Ver, ltypLotRlst, _
                                            llngcFlowClassCnt, ltypLotresvlist)
            
            '@結果判定
            If lblnAns = True Then

        '@↓2019/02/27 (Wed) 11:14:55 T.Oide **************************************************
                '@ﾃﾞｰﾀがヒットしなかったか
                If ltypLotRlst.Count > 0 Then
        '@↑2019/02/27 (Wed) 11:14:55 T.Oide **************************************************

                    ltypInvAcptLotListAns.typLotList = New List(Of InvAcptLotListLotList)(ltypLotRlst.Count)

                    '@ltypLotRlst　→　ltypInvAcptLotListAnsに情報を渡す
                    For llngCnt = 0 To ltypLotRlst.Count - 1
                        Dim ltypInvAcptLotListLotListTmp As New InvAcptLotListLotList
                        ltypInvAcptLotListLotListTmp.strLotID = ltypLotRlst(llngCnt).strLotID
                        ltypInvAcptLotListLotListTmp.strEntryTime = ltypLotRlst(llngCnt).strPlanThrowinDate
                        ltypInvAcptLotListLotListTmp.strPdId = ltypLotRlst(llngCnt).strPdId
                        ltypInvAcptLotListLotListTmp.strFlowClass = ltypLotRlst(llngCnt).strFlowClass
                        ltypInvAcptLotListLotListTmp.strWFQuantity = ltypLotRlst(llngCnt).strWfNum
                        ltypInvAcptLotListLotListTmp.strLotComments = ltypLotRlst(llngCnt).strComments
                        ltypInvAcptLotListLotListTmp.strEngEmpId = ltypLotRlst(llngCnt).strEngEmpId
                        ltypInvAcptLotListLotListTmp.strEngEmpName = ltypLotRlst(llngCnt).strEngEmpName
                        ltypInvAcptLotListAns.typLotList.Add(ltypInvAcptLotListLotListTmp)
                        llngInvAcptLotListCnt = llngCnt + 1
                    Next
                    
                    '@一覧表示
                    Call prvvsfInvLot_Disp(ltypInvAcptLotListAns, llngInvAcptLotListCnt)
            
                    '@作成中のﾊﾞｯﾁがある場合、受入在庫の表示を「バ(ﾊﾞｯﾁ編成済)」に変える
                    If cmbAldBatch.Text = CMstrBatchNew And vsfAldBatch.Rows.Count > 1 Then
                    
                        '@受入在庫ﾛｯﾄの情報を「バ」に変える
                        Call prvNewBatchLotInfo_Disp()
                    End If

        '@↓2019/02/27 (Wed) 11:14:30 T.Oide **************************************************
                End If
        '@↑2019/02/27 (Wed) 11:14:30 T.Oide **************************************************
                
                If vsfInvLot.Enabled = True Then
                    '@一覧へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(vsfInvLot)
                Else
                    '@最新取得ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmdNowList)
                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)

            Else

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                vsfInvLot.Enabled = False

                Exit Sub
                
            End If

            If vsfInvLot.Rows.Count <= vsfInvLot.Rows.Fixed Then
                vsfInvLot.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLotRsvListSel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvDivPartLotDelete
    '機　能：同一Aｷｬﾘｱ設定解除の場合で分割ﾛｯﾄ(背景ｵﾚﾝｼﾞ)があった場合にﾛｯﾄを1ﾛｯﾄに戻す
    '引　数：ltypeDivLotList：分割ﾛｯﾄ情報格納
    '戻り値：
    '作成日：2018/11/12 (Mon) 10:58:42 T.Oide
    '更新日：2019/03/20 (Wed) 14:44:55 T.Oide
    '備　考：
    Private Sub prvDivPartLotDelete(ByRef ltypeDivLotList As typeDivLot)

        Dim llngtmpFindRow      As Integer
        Dim llngCnt             As Integer
        Dim llngCnt2            As Integer
        Dim ltypeDivPartLotList As typeDivLot   '分割相手ﾛｯﾄ情報格納

        Try

            With vsfAldBatch
            
                '@分割ﾛｯﾄの保持情報がある場合、ﾛｯﾄIDを探して消して1ﾛｯﾄにする
                '@また消した相手がAｷｬﾘｱｸﾞﾙｰﾌﾟ設定済の場合、
                '　「Aｷｬﾘｱ収容数」「AｷｬﾘｱCHIP収容数(隠)」｢Aｷｬﾘｱ空CHIP数｣をｸﾘｱする
                If ltypeDivLotList.lngDivLotInfoCnt <> 0 Then
            
                    '@分割相手(削除対象)の情報ｸﾘｱ
                    ltypeDivPartLotList.lngDivLotInfoCnt = 0
                    ltypeDivPartLotList.typeDivLotInfo = New List(Of DivLotInfo)
                    
                    '@ｸﾞﾘｯﾄﾞを回す
                    For llngCnt = 0 To ltypeDivLotList.lngDivLotInfoCnt - 1
            
                        '@分割したﾛｯﾄ(ｵﾚﾝｼﾞ)は上側か
                        If ltypeDivLotList.typeDivLotInfo(llngCnt).strPosition = CmstrDivLotUe Then
                            '@上側の分割相手を探す
                            llngtmpFindRow = .FindRow(ltypeDivLotList.typeDivLotInfo(llngCnt).strLotID, _
                                                      CMlngVsfRowTitle, CMlngvsfAldBatchColLotId, False)
                        Else
                            '@下側の分割相手を探す
                            llngtmpFindRow = .FindRow(ltypeDivLotList.typeDivLotInfo(llngCnt).strLotID, _
                                                      ltypeDivLotList.typeDivLotInfo(llngCnt).lngRow + 1, CMlngvsfAldBatchColLotId, False)
                        End If
            
                        '@見つかったか
                        If llngtmpFindRow <> CMlngNotFind Then
            
                            '@見つかった場合
                            ltypeDivPartLotList.lngDivLotInfoCnt = ltypeDivPartLotList.lngDivLotInfoCnt + 1
                            Dim ltypDivLotInfoTmp As New DivLotInfo

                            ltypDivLotInfoTmp.lngRow = llngtmpFindRow
            
                            '@分割相手のﾁｯﾌﾟ数格納
                            ltypDivLotInfoTmp.lngChipNum = _
                                                        .GetData(llngtmpFindRow, CMlngvsfAldBatchColChipNum)
            
                            '@自分に数を足す
                            .SetData(ltypeDivLotList.typeDivLotInfo(llngCnt).lngRow, CMlngvsfAldBatchColChipNum, _
                                CLng(.GetData(ltypeDivLotList.typeDivLotInfo(llngCnt).lngRow, CMlngvsfAldBatchColChipNum)) + _
                                ltypDivLotInfoTmp.lngChipNum)
            
                            '@背景色を白に戻す
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngEnableTrueColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                            Dim cellRange As CellRange = .GetCellRange(ltypeDivLotList.typeDivLotInfo(llngCnt).lngRow, CMlngvsfAldBatchColNo, _
                                                       ltypeDivLotList.typeDivLotInfo(llngCnt).lngRow, CMlngvsfAldBatchColChipNum)
                            cellRange.Style = newStyle
                        
                            '@分割相手のAｷｬﾘｱｸﾞﾙｰﾌﾟ格納
                            ltypDivLotInfoTmp.strA_CrrierGr = _
                                .GetData(ltypDivLotInfoTmp.lngRow, CMlngvsfAldBatchColACarrierGr)
                            
                            ltypeDivPartLotList.typeDivLotInfo.Add(ltypDivLotInfoTmp)
                        End If
                    
                    Next
            
                    '@削除する列を消す
                    .Redraw = False
                    For llngCnt = 0 To ltypeDivPartLotList.lngDivLotInfoCnt - 1
                        '@分割相手を削除
        '@↓2019/03/20 (Wed) 14:33:55 T.Oide **************************************************
        '@                .RemoveItem ltypeDivPartLotList.typeDivLotInfo(llngCnt).lngRow
        '@-------------------------------------------------------------------------------------
                        '@削除1回目か
                        If llngCnt = 0 Then
                            '@1回目の場合、そのままの行を削除
                            .RemoveItem(ltypeDivPartLotList.typeDivLotInfo(llngCnt).lngRow)
                        Else
                            '@2回目の場合、記憶してある行-(回数-1)の行を削除(削除される毎に1行ｽﾞﾚﾙから)
                            ' ここの処理は、上だけ、または、下だけ、または両方のﾊﾟﾀｰﾝがあるので最大でも2回まで
                            .RemoveItem(ltypeDivPartLotList.typeDivLotInfo(llngCnt).lngRow - (llngCnt - 1))
                        End If
        '@↑2019/03/20 (Wed) 14:33:55 T.Oide **************************************************

                    Next
                    .Redraw = True
                    
                    '@分割相手が属していたAｷｬﾘｱｸﾞﾙｰﾌﾟの「Aｷｬﾘｱ収容数」「AｷｬﾘｱCHIP収容数(隠)」｢Aｷｬﾘｱ空CHIP数｣をｸﾘｱする
                    '@分割相手の数で回す
                    For llngCnt2 = 0 To ltypeDivPartLotList.lngDivLotInfoCnt - 1
                                        
                        '@ｸﾞﾘｯﾄﾞを回す
                        For llngCnt = 1 To .Rows.Count - 1
                        
                            '@削除したﾛｯﾄと同じAｷｬﾘｱｸﾞﾙｰﾌﾟか
                            If .GetData(llngCnt, CMlngvsfAldBatchColACarrierGr) = _
                               ltypeDivPartLotList.typeDivLotInfo(llngCnt2).strA_CrrierGr Then
                            
                                '@「Aｷｬﾘｱｸﾞﾙｰﾌﾟ」｢Aｷｬﾘｱ空CHIP数｣をｸﾘｱ
                                .SetData(llngCnt, CMlngvsfAldBatchColACarrierGr, vbNullString)
                                .SetData(llngCnt, CMlngvsfAldBatchColACarrierEmptNum, vbNullString)
                            
                            End If
                        Next
                    Next
                    
                End If
                    
            End With
                    
        Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvDivPartLotDelete"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMonitorNumSel
    '機　能：ﾊﾞｯﾁ編成時に必要になるﾓﾆﾀｰﾛｯﾄのｳｪﾊｰ数、ﾁｯﾌﾟ数を取得する「mlngMoQuWfNum」「mlngMoQuChipNum」に格納する
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/12 (Mon) 13:03:30 T.Oide
    '更新日：2018/11/12 (Mon) 13:03:30
    '備　考：
    Private Function prvMonitorNumSel() As Boolean

        Dim llngCnt             As Integer
        Dim ltypMasDefineReq    As MasDefineReq    'ﾘｸｴｽﾄﾒｯｾｰｼﾞ
        Dim ltypMasDefineAns    As MasDefineAns    '結果

        Try
            
            prvMonitorNumSel = False
            
            '@ ==================================
            '@「ALD_MONITOR_COUNT」「WF_COUNT」取得
            '@ ==================================
            '@ﾘｸｴｽﾄﾒｯｾｰｼﾞ情報設定
            With ltypMasDefineReq
                .strMsgVer = CMstrmas_definelistVer
                .strTableName = CmstrAldMonitorCount
                .strColumnName = CmstrWfCount
            End With
            
            llngCnt = 0
            
            '@Define情報取得
            If pubblnMasDfineList_Sel(ltypMasDefineReq, ltypMasDefineAns) = False Then
                Exit Function
            End If
            
            With ltypMasDefineAns
                '@1件以上取得できたか
                If .lngMasDefineListCnt > 0 Then
                    '@ｳｪﾊｰｶｳﾝﾄ格納(ﾚｺｰﾄﾞは1件のみなのでﾙｰﾌﾟはしない)
                    mlngMoQuWfNum = .typMasDefineList(llngCnt).strId
                End If
            End With
            
            '@ ==================================
            '@「ALD_MONITOR_COUNT」「CHIP_COUNT」取得
            '@ ==================================
            '@ﾘｸｴｽﾄﾒｯｾｰｼﾞ情報設定
            With ltypMasDefineReq
                .strMsgVer = CMstrmas_definelistVer
                .strTableName = CmstrAldMonitorCount
                .strColumnName = CmstrChipCount
            End With
            
            '@Define情報取得
            If pubblnMasDfineList_Sel(ltypMasDefineReq, ltypMasDefineAns) = False Then
                Exit Function
            End If
            
            With ltypMasDefineAns
                '@1件以上取得できたか
                If .lngMasDefineListCnt > 0 Then
                    '@ﾁｯﾌﾟｶｳﾝﾄ格納(ﾚｺｰﾄﾞは1件のみなのでﾙｰﾌﾟはしない)
                    mlngMoQuChipNum = mlngMoQuWfNum * CLng(.typMasDefineList(llngCnt).strId)
                End If
            End With
            
            '@ ==================================
            '@「ALD_DUMMY_COUNT」取得
            '@ ==================================
            '@ﾘｸｴｽﾄﾒｯｾｰｼﾞ情報設定
            With ltypMasDefineReq
                .strMsgVer = CMstrmas_definelistVer
                .strTableName = CmstrAldDummyCount
                .strColumnName = CmstrChipCount
            End With
            
            '@Define情報取得
            If pubblnMasDfineList_Sel(ltypMasDefineReq, ltypMasDefineAns) = False Then
                Exit Function
            End If
            
            With ltypMasDefineAns
                '@1件以上取得できたか
                If .lngMasDefineListCnt > 0 Then
                    '@ﾁｯﾌﾟｶｳﾝﾄ格納(ﾚｺｰﾄﾞは1件のみなのでﾙｰﾌﾟはしない)
                    mlngDummyChipNum = CLng(.typMasDefineList(llngCnt).strId)
                End If
            End With
            
            prvMonitorNumSel = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMonitorNumSel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvChkQu
    '機　能：ﾊﾞｯﾁ内にQUとそれ以外のﾛｯﾄが混ざっていないか
    '引　数：
    '戻り値：True：OK、False：NG(混じっている)
    '作成日：2019/08/06 (Tue) 16:59:17 T.Oide
    '更新日：
    '備　考：
    Private Function prvChkQu() As Boolean

        Dim llngCnt     As Integer
        Dim lblnQU      As Boolean  'QUが存在する場合True
        Dim lblnOther   As Boolean  'QU以外が存在する場合True

        Try

            '@変数初期化
            lblnQU = False
            lblnOther = False

            With vsfAldBatch
                
                '@ﾊﾞｯﾁ組しようとしている行を回す
                For llngCnt = 1 To .Rows.Count - 1

                    '@QUﾛｯﾄか
                    If .GetData(llngCnt, CMlngvsfAldBatchColFlowClass) = CPstrFlowClassQU Then
                        lblnQU = True
                    End If
                    
                    '@QUﾛｯﾄ以外か
                    If .GetData(llngCnt, CMlngvsfAldBatchColFlowClass) <> CPstrFlowClassQU Then
                        lblnOther = True
                    End If
                Next

                '@両方存在するか
                If lblnQU = True And lblnOther = True Then
                    '@ﾁｪｯｸNG
                    prvChkQu = False
                    
                    '@「"<TRM163W>$$ 「バッチ内にQUとそれ以外のロットを混在することはできません。設定を見直してください。"」表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0163)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Else
                    '@ﾁｪｯｸOK
                    prvChkQu = True
                End If

            End With

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvChkQu"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvBtnCtl
    '機　能：ﾎﾞﾀﾝ有効/無効制御
    '引　数：なし
    '戻り値：
    '作成日：2018/08/17 (Fri) 15:07:20 T.Oide
    '更新日：2018/08/17 (Fri) 15:07:20
    '備　考：
    Private Sub prvBtnCtl()

        Try
            
            '@================
            '@「↑」ﾎﾞﾀﾝ
            '@ 保留中、ﾊﾞｯﾁ編成済以外、編集中 有効
            '@================
            With vsfInvLot
                '@先頭行以外で「保留 or ﾊﾞｯﾁの情報表示」は空で
                ' 新規作成 or 編集中でﾌｫｰｶｽを持っているか
                If .Row > CMlngVsfRowTitle AndAlso _
                   .GetData(.Row, CMlngvsfInvLotColInfo) = vbNullString AndAlso _
                   mblnVsfInvLotGotFocus = True AndAlso _
                   mblnEditFlag = True Then
                    cmdLotIn.Enabled = True
                Else
                    cmdLotIn.Enabled = False
                End If
            End With
            
            '@================
            '@「↓」ﾎﾞﾀﾝ
            '@ ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ以外を選択で、編集中(mblnEditFlag)、状態が投入済で選択ﾛｯﾄのﾃｰﾌﾟ貼りﾊﾞｯﾁがNULL 有効
            '@ ※投入済の場合は、ﾊﾞｯﾁにﾛｯﾄを追加できても、流動済のﾛｯﾄを外すことは出来ない制限をつけている
            '@分割(背景ｵﾚﾝｼﾞ)されたﾛｯﾄの戻しもダメ
            '@================
            With vsfAldBatch
                '@ﾀｲﾄﾙ行以外で新規作成で
                ' ﾌｫｰｶｽを持っているか
                If .Row > CMlngVsfRowTitle AndAlso _
                   mblnVvsfAldBatchGotFocus = True AndAlso .Rows.Selected.Count = 1 AndAlso _
                   mblnEditFlag = True Then
                   
                    cmdLotDel.Enabled = True
                                
                    '@ 投入済でﾊﾞｯﾁIDが設定済のものは流動中なのでダメ
                    If labStatus.Text = CmstrBatchStatusTonyu AndAlso _
                       .GetData(.Row, CMlngvsfAldBatchColTapeStickBatch) <> vbNullString Then
                        cmdLotDel.Enabled = False
                    End If
                    
        '@↓2019/02/27 (Wed) 14:37:36 T.Oide **************************************************
                    '@分割(背景ｵﾚﾝｼﾞ)のﾛｯﾄの戻しもダメ
                    If .GetCellRange(.Row, CMlngvsfAldBatchColLotId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange) Then
                        cmdLotDel.Enabled = False
                    End If
        '@↑2019/02/27 (Wed) 14:37:36 T.Oide **************************************************
                    
                Else
                    cmdLotDel.Enabled = False
                End If
            End With
            
            '@================
            '@「同一Aｷｬﾘｱ設定」ﾎﾞﾀﾝ
            '@ ﾊﾞｯﾁ編成中ﾛｯﾄ選択時、編集中 有効
            '@================
            With vsfAldBatch
                '@ﾀｲﾄﾙ行以外で新規作成で
                ' ﾌｫｰｶｽを持っていて1行以上選択しているか
                If .Row > CMlngVsfRowTitle AndAlso _
                   mblnVvsfAldBatchGotFocus = True AndAlso .Rows.Selected.Count > 0 AndAlso _
                   mblnEditFlag = True Then
                    cmdSameACarrier.Enabled = True
                Else
                    cmdSameACarrier.Enabled = False
                End If
            End With
            
            '@================
            '@「ALD処理部(↑)」ﾎﾞﾀﾝ
            '@ ﾊﾞｯﾁ編成中ﾛｯﾄ選択で先頭以降のﾛｯﾄ選択中、ﾌｫｰｶｽを持っている、編集中
            '@ 但し、分割ﾛｯﾄ(背景ｵﾚﾝｼﾞ)ﾛｯﾄの移動は不可とする
            '@================
            With vsfAldBatch
        '@↓2019/02/27 (Wed) 13:37:48 T.Oide **************************************************
        '@        If .Row > CMlngVsfRowTitle + 1 And mblnVvsfAldBatchGotFocus = True And _
        '@           mblnEditFlag = True Then
        '@            cmdPosiUp.Enabled = True
        '@-------------------------------------------------------------------------------------
                If .Row > CMlngVsfRowTitle + 1 AndAlso _
                   mblnVvsfAldBatchGotFocus = True AndAlso mblnEditFlag = True AndAlso _
                   .GetCellRange(.Row, CMlngvsfAldBatchColLotId).StyleDisplay.BackColor <> ColorTranslator.FromWin32(CPlngVbColorOrange) Then
                   
                    '@1行上の行が存在してｵﾚﾝｼﾞの場合は無効、複数行選択も無効
                    If (.Row > 1 AndAlso _
                        .GetCellStyleDisplay(.Row - 1, CMlngvsfAldBatchColLotId).BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)) OrElse _
                        .Rows.Selected.Count > 1 Then
                        cmdPosiUp.Enabled = False
                    Else
                        cmdPosiUp.Enabled = True
                    End If
        '@↑2019/02/27 (Wed) 13:37:48 T.Oide **************************************************
                Else
                    cmdPosiUp.Enabled = False
                End If
            End With
            
            '@================
            '@「ALD処理部(↓)」ﾎﾞﾀﾝ
            '@ ﾊﾞｯﾁ編成中ﾛｯﾄ選択で最終行以外のﾛｯﾄ選択中、ﾌｫｰｶｽを持っている、編集中
            '@ 但し、分割ﾛｯﾄ(背景ｵﾚﾝｼﾞ)ﾛｯﾄの移動は不可とする
            '@================
            With vsfAldBatch
        '@↓2019/02/27 (Wed) 13:40:20 T.Oide **************************************************
        '@        If .Row > CMlngVsfRowTitle And .Row < .Rows - 1 And _
        '@           mblnVvsfAldBatchGotFocus = True And _
        '@           mblnEditFlag = True Then
        '@            cmdPosiDown.Enabled = True
        '@------------------------------------------------------------------------------------
                If .Row > CMlngVsfRowTitle AndAlso .Row < .Rows.Count - 1 AndAlso _
                   mblnVvsfAldBatchGotFocus = True AndAlso _
                   mblnEditFlag = True AndAlso _
                   .GetCellStyleDisplay(.Row, CMlngvsfAldBatchColLotId).BackColor <> ColorTranslator.FromWin32(CPlngVbColorOrange) Then
                   
                    '@1行下の行が存在してｵﾚﾝｼﾞの場合は無効、複数行選択も無効
                    If (.Row < .Rows.Count - 1 AndAlso _
                        .GetCellStyleDisplay(.Row + 1, CMlngvsfAldBatchColLotId).BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)) OrElse _
                        .Rows.Selected.Count > 1 Then
                        cmdPosiDown.Enabled = False
                    Else
                        cmdPosiDown.Enabled = True
                    End If
        '@↑2019/02/27 (Wed) 13:40:20 T.Oide **************************************************
                
                Else
                    cmdPosiDown.Enabled = False
                End If
            End With
            
            '@================
            '@「ｸﾘｱ」ﾎﾞﾀﾝ
            '@ 新規作成の場合
            '@================
            If mblnEditFlag = True Then
                cmdClear.Enabled = True
            Else
                cmdClear.Enabled = False
            End If
            
            '@================
            '@「削除」ﾎﾞﾀﾝ
            '@ 編集中、投入待ち ｽﾃｰﾀｽので編集中(mblnEditFlag)ではない場合有効
            '@================
            If (labStatus.Text = CmstrBatchStatusHensyu OrElse _
                labStatus.Text = CmstrBatchStatusTonyuMachi) AndAlso _
               mblnEditFlag = False Then
               
                cmdBatchDele.Enabled = True
            Else
                cmdBatchDele.Enabled = False
                
            End If

        '@↓2019/08/06 (Tue) 16:09:49 T.Oide  **************************************************
        '@    '@================
        '@    '@「編集」ﾎﾞﾀﾝ
        '@    '@ 新規作成以外か編集中以外有効
        '@    '@================
        '@    If cmbAldBatch.Text <> CMstrBatchNew And mblnEditFlag = False Then
        '@        cmdEdit.Enabled = True
        '@    Else
        '@        cmdEdit.Enabled = False
        '@    End If
        '@-----------------------------------------------------------------------------------------------------

            '@================
            '@「編集」ﾎﾞﾀﾝ
            '@ 新規作成以外か(編集中以外で編集可否OK)の場合有効
            '@================
            If cmbAldBatch.Text <> CMstrBatchNew AndAlso _
               mblnEditFlag = False AndAlso lblEditable.Text = CMstrOK Then
                cmdEdit.Enabled = True
            Else
                cmdEdit.Enabled = False
            End If
        '@↑2019/08/06 (Tue) 16:09:49 T.Oide  **************************************************
            
            
            '@================
            '@「登録」ﾎﾞﾀﾝ
            '@ ﾛｯﾄが設定されていて、投入予定日設定済、Aｷｬﾘｱｸﾞﾙｰﾌﾟが設定済、編集中(mblnEditFlag)で、状態が編集中or投入待ち
            '@================
            If (vsfAldBatch.Rows.Count > 1 AndAlso dtpThrowInDate.Value <> CPstrNullDate AndAlso _
                prvSetACarrierGrChk = True) AndAlso _
               mblnEditFlag = True AndAlso _
               (labStatus.Text = vbNullString OrElse labStatus.Text = CmstrBatchStatusHensyu OrElse _
                labStatus.Text = CmstrBatchStatusTonyuMachi) Then
                cmdSave.Enabled = True
            Else
                cmdSave.Enabled = False
            End If
            
            '@================
            '@「適用」ﾎﾞﾀﾝ
            '@ ﾛｯﾄが設定されていて、投入予定日設定済、Aｷｬﾘｱｸﾞﾙｰﾌﾟ設定済、編集中(mblnEditFlag)が未編集状態、状態が編集中or投入済or再編集 (投入待ちは適用は押せない状態)
            '@================
            If (vsfAldBatch.Rows.Count > 1 AndAlso dtpThrowInDate.Value <> CPstrNullDate AndAlso prvSetACarrierGrChk = True) AndAlso _
               ((mblnEditFlag = False AndAlso labStatus.Text = CmstrBatchStatusHensyu) OrElse _
                (mblnEditFlag = True AndAlso labStatus.Text = CmstrBatchStatusTonyu) OrElse _
                (mblnEditFlag = True AndAlso labStatus.Text = CmstrBatchStatusSaihensyu)) Then
                cmdRegist.Enabled = True
            Else
                cmdRegist.Enabled = False
            End If
            
            '@================
            '@「閉じる」ﾎﾞﾀﾝ
            '@================
            cmdClose.Enabled = True
            
            '@================
            '@「保留」ﾎﾞﾀﾝ
            '@ 受入在庫選択中で、保留、ﾊﾞｯﾁ編成済でないﾛｯﾄ選択時有効
            '@================
            With vsfInvLot
                '@「保留 or ﾊﾞｯﾁの情報表示」は空か
                If .Row > CMlngVsfRowTitle AndAlso _
                   .GetData(.Row, CMlngvsfInvLotColInfo) = vbNullString Then
                    cmdHold.Enabled = True
                Else
                    cmdHold.Enabled = False
                End If
            End With
            
            '@================
            '@「保留解除」ﾎﾞﾀﾝ
            '@ 保留中の受入在庫ﾛｯﾄ選択時有効
            '@================
            With vsfInvLot
                '@ﾀｲﾄﾙ行以外で「保留 or ﾊﾞｯﾁの情報表示」は「保」か
                If .Row > CMlngVsfRowTitle AndAlso _
                   .GetData(.Row, CMlngvsfInvLotColInfo) = CPstrHo Then
                    cmdReleaseHold.Enabled = True
                Else
                    cmdReleaseHold.Enabled = False
                End If
            End With
            
            '@================
            '@「投入予定日」
            '@ 新規作成か編集状態で変更可
            '@================
            If (cmbAldBatch.Text = CMstrBatchNew) OrElse _
                mblnEditFlag = True Then
                dtpThrowInDate.Enabled = True
            Else
                dtpThrowInDate.Enabled = False
            End If
            
            '@================
            '@「モニター」
            '@ 新規作成か編集状態で変更可
            '@================
            If (cmbAldBatch.Text = CMstrBatchNew) OrElse _
                mblnEditFlag = True Then
                optMoni0.Enabled = True
                optMoni1.Enabled = True
            Else
                optMoni0.Enabled = False
                optMoni1.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvBtnCtl"
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfAldBatch.BeforeDoubleClick, vsfInvLot.BeforeDoubleClick

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

        Dim colindex As Integer 'ダブルクリックした列番号

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True

            If sender Is vsfInvLot Then
                'ダブルクリックした列番号を格納
                colindex = gridObj.HitTest(e.X,e.Y).Column

                'サイズを自動調整
                gridObj.AutoSizeCol(colindex,6)
            End If
        End If

    End Sub

    '関数名：flex_OwnerDrawCell
    '機　能：オーナー描画イベント。Focusの背景色のカスタマイズ
    '引　数：sender：イベント発生元
    '　　　：e     ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/03/13 (Wed) 18:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub flex_OwnerDrawCell(ByVal sender As Object, ByVal e As OwnerDrawCellEventArgs) Handles vsfAldBatch.OwnerDrawCell, vsfInvLot.OwnerDrawCell
        pubVsfOwnerDrawCell(CType(sender, C1FlexGrid), e)
    End Sub

End Class
