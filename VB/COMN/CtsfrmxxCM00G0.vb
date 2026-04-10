'ﾌｧｲﾙ名：xxCM00G0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：装置データ登録/参照　メインフォーム
'作成日：2005/01/24 (Mon) 10:28:38 S.Deguchi
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00G0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00G0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00G0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00G0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00G0)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property

    
    '******************************************************************************************
    '                                       *定数の記述*
    '******************************************************************************************
    '=========================================Private==========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2020/03/06 (Fri) 10:45:26 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion                 As String = "13.01"
    Private Const CMstrLocalVersion                 As String = "13.02"
    '@↑2020/03/06 (Fri) 10:45:26 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN00T0      'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2020/01/15 (Wed) 14:17:00 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer              As String = "03.04"             'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer              As String = "04.00"             'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:17:00 Y.Yoneyama 「.Netへ反映未」 **************************************************
    '@↓2010/06/17 (Thu) 19:36:49 Y.Yoneyama **************************************************
    Private Const CMstrlot_waferlistVer             As String = "02.05"             'ﾛｯﾄWF情報取得(新)
    '@↑2010/06/17 (Thu) 19:36:49 Y.Yoneyama **************************************************
    Private Const CMstrlot_collectparamsVer         As String = "02.01"             '収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀ取得
    Private Const CMstreq__state___Ver              As String = "03.00"             '装置状態取得
    Private Const CMstrspc_regcollectVer            As String = "05.00"             '装置ﾃﾞｰﾀ登録
    Private Const CMstrspc_collectioninfoVer        As String = "01.00"             '装置ﾃﾞｰﾀ参照
        
    '@vsf共通のｶﾗﾑ定数
    Private Const CMlngGridTitleHeight              As Integer = 20                 'ﾀｲﾄﾙの高さ
    Private Const CMlngGridRowHeight                As Integer = 18                 '1明細の高さ
    Private Const CMlngGridRowCol_0                 As Integer = 0                  'ﾀｲﾄﾙ行列
    Private Const CMstrvsfNoTitle                   As String = "№"                '№

    Private Const CMlngvsfTitleHeight               As Integer = 27                 'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfRowHeight                 As Integer = 38                 '行の高さ
    Private Const CMvsfSlotMapVisibleRows           As Integer = 10                 'ｽﾛｯﾄﾏｯﾌﾟの表示行数
    Private Const CMlngVsfDispRows                  As Integer = 10                 '画面の表示行数(ｽｸﾛｰﾙﾎﾞﾀﾝの計算で使用)
    Private Const CMlngvsfTopRow                    As Integer = 1                  '画面の一番上の行(WF№25の行)
    Private Const CMlngvsfBottomRow                 As Integer = 25                 '画面の一番下の行(WF№01の行)
    Private Const CMlngvsfTitle                     As Integer = 0                  'ﾌﾚｯｸｽｸﾞﾘｯﾄﾞのﾀｲﾄﾙ行
    Private Const CMlngvsfSlotMapRows               As Integer = 26                 'ｽﾛｯﾄﾏｯﾌﾟの行数
    Private Const CMlngSlotNo10Row                  As Integer = 17                 '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№10の行番号
    Private Const CMlngSlotNo16Row                  As Integer = 11                 '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№16の行番号
    Private Const CMvsfCollectValueVisibleRows      As Integer = 5                  'ﾃﾞｰﾀ入力の表示行数
    Private Const CMvsfCollectVisibleRows           As Integer = 5                  'ﾊﾟﾗﾒｰﾀ入力の表示行数

    '@ｸﾞﾘｯﾄﾞ共通関数で使用
    Private Const CMstrNothing                      As String = "Nothing"           'Nothing
    Private Const CMlngFlexcpText                   As Integer = 0                  'ﾃｷｽﾄ(Cellﾌﾟﾛﾊﾟﾃｨ用)

    '@ｽﾛｯﾄﾏｯﾌﾟ情報
    '@ｽﾛｯﾄﾏｯﾌﾟ情報(列定義)
    Private Const CMlngvsfSlotMapNoC                As Integer = 0                  '№
    Private Const CMlngvsfSlotMapWfIdC              As Integer = 1                  'WFID
    Private Const CMlngvsfSlotMapInputRequestC      As Integer = 2                  '入力必要

    '@ｽﾛｯﾄﾏｯﾌﾟ情報(幅定義)
    Private Const CMlngvsfSlotMapNoW                As Integer = 22                 '№
    Private Const CMlngvsfSlotMapWfIdW              As Integer = 94                 'WFID
    Private Const CMlngvsfSlotMapInputRequestW      As Integer = 50                 '入力必要

    '@ｽﾛｯﾄﾏｯﾌﾟ情報(ﾀｲﾄﾙ)
    Private Const CMstrvsfSlotMapWfIdC              As String = "WFID"              'WFID
    Private Const CMstrvsfSlotMapInputRequestC      As String = "入力"              '入力必要

    '@装置収集項目情報
    '@装置収集項目情報(列定義)
    Private Const CMlngvsfCollectNoC                As Integer = 0                  '№
    Private Const CMlngvsfCollectParaIdC            As Integer = 1                  'ﾊﾟﾗﾒｰﾀID
    Private Const CMlngvsfCollectParaVerC           As Integer = 2                  'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
    Private Const CMlngvsfCollectUnitC              As Integer = 3                  '単位
    Private Const CMlngvsfCollectMandatoryCountC    As Integer = 4                  '必須項目数
    Private Const CMlngvsfCollectInputEndFlagC      As Integer = 5                  '入力済
    Private Const CMlngvsfCollectDataTypeC          As Integer = 6                  'ﾃﾞｰﾀﾀｲﾌﾟ
    Private Const CMlngvsfCollectClass1C            As Integer = 7                  'ﾃﾞｰﾀ分類1名
    Private Const CMlngvsfCollectClass2C            As Integer = 8                  'ﾃﾞｰﾀ分類2名
    Private Const CMlngvsfCollectClass3C            As Integer = 9                  'ﾃﾞｰﾀ分類3名
    Private Const CMlngvsfCollectClass4C            As Integer = 10                 'ﾃﾞｰﾀ分類4名
    Private Const CMlngvsfCollectDvNameC            As Integer = 11                 '装置報告ﾃﾞｰﾀ名
    Private Const CMlngvsfCollectCfFlagC            As Integer = 12                 'CFﾌﾗｸﾞ
    Private Const CMlngvsfCollectLpFlagC            As Integer = 13                 '大板ﾌﾗｸﾞ
    Private Const CMlngvsfCollectDataUnit           As Integer = 14                 '収集ﾃﾞｰﾀ処理単位
    Private Const CMlngvsfCollectMeasureMode        As Integer = 15                 '収集ﾃﾞｰﾀ測定ﾓｰﾄﾞ
    Private Const CMlngvsfCollectRiftainFlag        As Integer = 16                 '収集ﾃﾞｰﾀ引継ぎﾌﾗｸﾞ
    'Private Const CMlngvsfCollectSpecJudgeFlag      As Long = 17                    '規格値判定ﾌﾗｸﾞ
    Private Const CMlngvsfCollectParameterLoad      As Integer = 17                 'ﾊﾟﾗﾒｰﾀ情報読込(0:未読込/1:読込済/2:入力済)
    Private Const CMlngvsfCollectCollectionType     As Integer = 18                 '収集項目ﾀｲﾌﾟ(0:作業記録/1:装置ﾃﾞｰﾀ)
    Private Const CMlngvsfCollectCeId               As Integer = 19                 'CEID(0:正/1:異/Null:正)


    '@装置収集項目情報(幅定義)
    Private Const CMlngvsfCollectNoW                As Integer = 25                 '№
    Private Const CMlngvsfCollectParaIdW            As Integer = 87                 'ﾊﾟﾗﾒｰﾀID
    Private Const CMlngvsfCollectParaVerW           As Integer = 34                 'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
    Private Const CMlngvsfCollectUnitW              As Integer = 47                 '単位
    Private Const CMlngvsfCollectMandatoryCountW    As Integer = 87                 '必須項目数
    Private Const CMlngvsfCollectInputEndFlagW      As Integer = 44                 '入力済ﾌﾗｸﾞ
    Private Const CMlngvsfCollectDataTypeW          As Integer = 87                 'ﾃﾞｰﾀﾀｲﾌﾟ
    Private Const CMlngvsfCollectClass1W            As Integer = 87                 'ﾃﾞｰﾀ分類1名
    Private Const CMlngvsfCollectClass2W            As Integer = 87                 'ﾃﾞｰﾀ分類2名
    Private Const CMlngvsfCollectClass3W            As Integer = 87                 'ﾃﾞｰﾀ分類3名
    Private Const CMlngvsfCollectClass4W            As Integer = 87                 'ﾃﾞｰﾀ分類4名
    Private Const CMlngvsfCollectDvNameW            As Integer = 87                 '装置報告ﾃﾞｰﾀ名
    Private Const CMlngvsfCollectCfFlagW            As Integer = 87                 'CFﾌﾗｸﾞ
    Private Const CMlngvsfCollectLpFlagW            As Integer = 87                 '大板ﾌﾗｸﾞ
    Private Const CMlngvsfCollectDataUnitW          As Integer = 87                 '収集ﾃﾞｰﾀ処理単位
    Private Const CMlngvsfCollectMeasureModeW       As Integer = 87                 '収集ﾃﾞｰﾀ測定ﾓｰﾄﾞ
    Private Const CMlngvsfCollectRiftainFlagW       As Integer = 87                 '収集ﾃﾞｰﾀ引継ぎﾌﾗｸﾞ
    'Private Const CMlngvsfCollectSpecJudgeFlagW     As Long = 1300                  '規格値判定ﾌﾗｸﾞ
    Private Const CMlngvsfCollectParameterLoadW     As Integer = 44                 'ﾊﾟﾗﾒｰﾀ情報読込(0:未読込/1:読込済/2:入力済)
    Private Const CMlngvsfCollectCollectionTypeW    As Integer = 44                 '収集項目ﾀｲﾌﾟ(0:作業記録/1:装置ﾃﾞｰﾀ)
    Private Const CMlngvsfCollectCeIdW              As Integer = 44                 'CEID(0:正/1:異/Null:正)


    '@装置収集項目情報(行数)
    Private Const CMlngvsfCollectDisplayRow         As Integer = 11                 '収集項目表示数

    '@装置ﾃﾞｰﾀ情報
    '@装置ﾃﾞｰﾀ情報(列定義)
    Private Const CMlngvsfCollectValueNoC           As Integer = 0                  '№
    Private Const CMlngvsfCollectValueClass1C       As Integer = 1                  'ﾃﾞｰﾀ分類1名
    Private Const CMlngvsfCollectValueClass2C       As Integer = 2                  'ﾃﾞｰﾀ分類2名
    Private Const CMlngvsfCollectValueClass3C       As Integer = 3                  'ﾃﾞｰﾀ分類3名
    Private Const CMlngvsfCollectValueClass4C       As Integer = 4                  'ﾃﾞｰﾀ分類4名
    Private Const CMlngvsfCollectValueDataC         As Integer = 5                  '登録値

    '@装置ﾃﾞｰﾀ情報(幅定義)
    Private Const CMlngvsfCollectValueNoW           As Integer = 25                 '№
    Private Const CMlngvsfCollectValueClass1W       As Integer = 87                 'ﾃﾞｰﾀ分類1名
    Private Const CMlngvsfCollectValueClass2W       As Integer = 87                 'ﾃﾞｰﾀ分類2名
    Private Const CMlngvsfCollectValueClass3W       As Integer = 87                 'ﾃﾞｰﾀ分類3名
    Private Const CMlngvsfCollectValueClass4W       As Integer = 87                 'ﾃﾞｰﾀ分類4名
    Private Const CMlngvsfCollectValueDataW         As Integer = 87                 '登録値

    '@装置ﾃﾞｰﾀ情報(ﾀｲﾄﾙ定義)
    Private Const CMstrvsfCollectValueDataT         As String = "　　値　　"        '値

    '@装置ﾃﾞｰﾀ情報(行数)
    Private Const CMstrvsfCollectValueCols          As Integer = 6                  '装置ﾃﾞｰﾀ列数(=6)

    '@色宣言
    Private Const CMlngEnableFalseColor             As Integer = &H80000004         '灰色(使用不可)
    Private Const CMlngEnableTrueColor              As Integer = &H80000005         '白(使用可)
    Private Const CMlngOkForeColor                  As Integer = &H0                '黒色(通常色)
    Private Const CMlngNgForeColor                  As Integer = &HFF               '赤(ｴﾗｰ色)
    Private Const CMlngOKBackColor                  As Integer = &HFFC0C0           '藤色(ﾗｲﾄﾌﾞﾙｰ)
    Private Const CMlngInputColor                   As Integer = &HC0C0FF           'ﾋﾟﾝｸ
    Private Const CMlngNotInputColor                As Integer = &HE0E0E0           '薄灰色
    Private Const CMlngRetainColor                  As Integer = &HFFFFC0           '水色(引継情報)

    '@情報取得ｺﾝﾄﾛｰﾙ名(ｷｬﾘｱ/ﾛｯﾄ)
    Private Const CMstrInfoGetControlNameCarrier    As String = "txtCarrier"        'ｷｬﾘｱIDのｺﾝﾄﾛｰﾙ名
    Private Const CMstrInfoGetControlNameLot        As String = "txtLot"            'ﾛｯﾄIDのｺﾝﾄﾛｰﾙ名

    '@その他宣言
    Private Const CMlngCarrierMaxLength             As Integer = 6                  'ｷｬﾘｱIDの最大桁数
    Private Const CMlngLotMaxLength                 As Integer = 10                 'ﾛｯﾄIDの最大桁数
    Private Const CMlngMaxSlotNo                    As Integer = 25                 'ｽﾛｯﾄ№の最大値
    Private Const CMlngInputClassMaxByte            As Integer = 30                 'ﾃﾞｰﾀ分類名の最大ﾊﾞｲﾄ数
    Private Const CMlngInputDataMaxByte             As Integer = 256                '文字入力の最大ﾊﾞｲﾄ数
    Private Const CMlngInputNumberMaxByte           As Integer = 35                 '数字入力の最大ﾊﾞｲﾄ数
    Private Const CMlngColonKeyAscii                As Integer = 58                 'ｺﾛﾝ(DV_NAMEｾﾊﾟﾚｰﾄ用)ｱｽｷｰ定数
    Private Const CMstrDataTypeA                    As String = "A"                 '文字ﾃﾞｰﾀﾀｲﾌﾟ
    Private Const CMstrDataTypeN                    As String = "N"                 '数字ﾃﾞｰﾀﾀｲﾌﾟ
    Private Const CMstrColon                        As String = ":"                 'ｺﾛﾝ(DV_NAMEｾﾊﾟﾚｰﾄ用)
    Private Const CMstrOfflineMode                  As String = "M1"                'ｵﾌﾗｲﾝﾓｰﾄﾞ
    Private Const CMstrRequireCheck                 As String = "○"                '必須ﾌﾗｸﾞ
    Private Const CMstrRequireCheck1                As String = "1"                 '必須ﾌﾗｸﾞ
    Private Const CMstrNaString                     As String = "N/A"               '値未入力文字
    Private Const CMstrInputRequest                 As String = "要"                '入力要ﾌﾗｸﾞ
    Private Const CMstrNoInputString                As String = "'"                 '禁則文字："'"
    Private Const CMstrCeID0                        As String = "正"                'CEID
    Private Const CMstrCeID1                        As String = "異"                'CEID

    'その他(数値定数)
    Private Const CMstrLotUnit                      As String = "1"                 'ﾛｯﾄ単位
    Private Const CMstrWFUnit                       As String = "2"                 'WF単位
    Private Const CMstrBatchUnit                    As String = "3"                 'ﾊﾞｯﾁ単位
    Private Const CMstrZero                         As String = "0"                 '0
    Private Const CMstrOne                          As String = "1"                 '1
    Private Const CMstrTwo                          As String = "2"                 '2
    Private Const CMstrThree                        As String = "3"                 '3
    Private Const CMstrFour                         As String = "4"                 '4
    Private Const CMlngZero                         As Integer = 0                  '0(数値)
    Private Const CMlngOne                          As Integer = 1                  '1(数値)
    Private Const CMlngOptDataUnit1                 As Integer = 1                  'ﾃﾞｰﾀ処理単位(ﾛｯﾄ単位,ﾊﾞｯﾁ単位)
    Private Const CMlngOptDataUnit2                 As Integer = 2                  'ﾃﾞｰﾀ処理単位(WF単位)
    Private Const CMstrDataDivisionL                As String = "LOT"               'DATA_DIVISION：LOT
    Private Const CMstrDataDivisionW                As String = "WAFER"             'DATA_DIVISION：WAFER
    Private Const CMstrDataDivisionDisp             As String = "Disp"              '入力済ﾃﾞｰﾀ表示：
    Private ReadOnly vbButtonFace                   As Color = SystemColors.ControlLight 'NSYS vbButtonFace定義

    '******************************************************************************************
    '                                       *変数の記述*
    '******************************************************************************************
    '=========================================Private==========================================
    Private mblnFormStartKbn                        As Boolean                      'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動)
    Private mblnTakeOverDispFlg                     As Boolean                      '引継ぎ表示ﾌﾗｸﾞ
    Private mstrInfoGetControlName                  As String                       '抽出ｺﾝﾄﾛｰﾙ(ｷｬﾘｱID or ﾛｯﾄID)
    Private mblnEditFlag                            As Boolean                      '編集ﾌﾗｸﾞ(True:変更有/False:変更無)
    Private mstrTaihiCarrierID                      As String                       'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrTaihiLotID                          As String                       'ﾛｯﾄ情報取得時のﾛｯﾄID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrLotLastUpdate                       As String                       '最終更新日時退避
    Private mblnScreenDispFlag                      As Boolean                      '画面表示処理ﾌﾗｸﾞ(True:Validate処理中/False:それ以外)
    Private mstrNewCol                              As String                       'WF選択Col(New)
    Private mstrOldCol                              As String                       'WF選択Col(Old)
    Private mstrNewRow                              As String                       'WF選択Row(New)
    Private mstrOldRow                              As String                       'WF選択Row(Old)
    Private mblnLotParamNothingFlag                 As Boolean                      'Lot単位ﾊﾟﾗﾒｰﾀ有無判別ﾌﾗｸﾞ
    Private mblnWFParamNothingFlag                  As Boolean                      'WF単位ﾊﾟﾗﾒｰﾀ有無判別ﾌﾗｸﾞ

    Private mtypLotCollectParamsList                As LotCollectParamsList         'ﾊﾟﾗﾒｰﾀ項目取得構造体
    Private mtypWaferList                           As Waferlist                    'WFﾘｽﾄ取得構造体
     
    Private mstrCollectionID                        As String                       '収集項目ID
    Private mstrCollectionVersion                   As String                       '収集項目Ver

    Private mstrvsfCollectValueRow                  As String                        'ﾃﾞｰﾀ入力ｾﾙ行保持変数

    '@VsfCollcetValueのInput構造体
    Private Structure WFDvName
        Dim strNo                                   As String                       '№
        Dim strClass1                               As String                       'ﾃﾞｰﾀ分類1名
        Dim strClass1Disp                           As String                       'ﾃﾞｰﾀ分類1名表示ﾌﾗｸﾞ(0:非表示/1:表示)
        Dim strClass2                               As String                       'ﾃﾞｰﾀ分類2名
        Dim strClass2Disp                           As String                       'ﾃﾞｰﾀ分類2名表示ﾌﾗｸﾞ(0:非表示/1:表示)
        Dim strClass3                               As String                       'ﾃﾞｰﾀ分類3名
        Dim strClass3Disp                           As String                       'ﾃﾞｰﾀ分類3名表示ﾌﾗｸﾞ(0:非表示/1:表示)
        Dim strClass4                               As String                       'ﾃﾞｰﾀ分類4名
        Dim strClass4Disp                           As String                       'ﾃﾞｰﾀ分類4名表示ﾌﾗｸﾞ(0:非表示/1:表示)
        Dim strData                                 As String                       '登録値
    End Structure

    '@VsfCollcetの情報構造体
    Private Structure Parameter
        Dim strParameterID                          As String                       'ﾊﾟﾗﾒｰﾀID
        Dim strParameterVersion                     As String                       'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
        Dim strRiftainFlag                          As String                       '引継ぎﾌﾗｸﾞ(0:引継無/1:引継有)
        Dim strMeasureMode                          As String                       '測定ﾓｰﾄﾞ(0:ｵﾌﾗｲﾝ/2:ｵﾌﾗｲﾝ・ｵﾝﾗｲﾝ)
        Dim strMandatoryCount                       As String                       '必須項目数
        Dim strInputDataFlag                        As String                       '入力ﾃﾞｰﾀﾌﾗｸﾞ(0:無/1:読込完/2:入力完/3:引継完/4:装置ﾃﾞｰﾀ)
        Dim strNextParameterInputFlag               As String                       '引継情報登録完ﾌﾗｸﾞ
        Dim strCollectionType                       As String                       '収集項目ﾀｲﾌﾟ(0:作業記録/1:装置ﾃﾞｰﾀ)
        Dim strCeId                                 As String                       'CEID(0:正、1:異、Null:正)
        Dim lngInputDataCnt                         As Integer                      '入力ﾊﾟﾗﾒｰﾀ数
        Dim typInputData                            As List(Of WFDvName)            '入力ﾃﾞｰﾀ構造体
    End Structure

    '@ﾛｯﾄ単位/WF単位の確定情報構造体
    Private Structure DataCollect
        Dim strChgID                                As String                       '登録ID(ﾛｯﾄID/WFIDを格納)
        Dim strCollectionID                         As String                       '収集項目ID
        Dim strCollectionVersion                    As String                       '収集項目Ver
        Dim strOpID                                 As String                       '大工程
        Dim strStepID                               As String                       '小工程
        Dim lngParameterCnt                         As Integer                      '取得ﾊﾟﾗﾒｰﾀ数
        Dim typParameter                            As List(Of Parameter)           '取得ﾊﾟﾗﾒｰﾀ構造体
    End Structure
    Private mtypDataCollect                         As DataCollect                  '登録用構造体

    Private buttonProcessing                        As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                      'NSYS WindowCloseフラグ
    Private mblnEditCloseFlg                        As Boolean                      'NSYS EditCloseフラグ

    '******************************************************************************************
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
        pubVsfMouseWheelManager_Set(vsfSlotMap, cmdVsfUpWF, cmdVsfDownWF)
        pubVsfMouseWheelManager_Set(vsfCollect, cmdVsfUpCollect, cmdVsfDownCollect)
        pubVsfMouseWheelManager_Set(vsfCollectValue, cmdVsfUpCollectValue, cmdVsfDownCollectValue)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                 *イベントハンドラの記述*
    '******************************************************************************************
    '=========================================Private==========================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 10:43:21 S.Deguchi
    '更新日：2005/01/24 (Mon) 10:43:21
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns         As Boolean      '戻り値

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00T0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If

            '@ﾌｫｰﾑ起動区分の設定
            mblnFormStartKbn = pblnfrmxxCM00G0Kbn

            '@情報取得ｺﾝﾄﾛｰﾙ名(ｷｬﾘｱ/ﾛｯﾄ)のｸﾘｱ
            mstrInfoGetControlName = vbNullString
            
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@画面初期化
            Call prvfrmxxCM00G0_Init()
            
            '@変数初期化
            mstrvsfCollectValueRow = vbNullString

            '@ﾌｫｰﾑ起動区分判定
            If mblnFormStartKbn = False Then
            '@単体起動の場合
                '@ｷｬﾘｱIDを使用可能
                txtCarrier.Enabled = True
                txtCarrier.BackColor = Color.White
                
                '@ﾛｯﾄIDを使用可能
                txtLot.Enabled = True
                txtLot.BackColor = Color.White
                
                '@引継ぎ情報初期化
                With ptypCommonInfo
                    .strCarrierId = vbNullString    'ｷｬﾘｱID
                    .strDivision = vbNullString     '処理区分
                    .strLotID = vbNullString        'ﾛｯﾄID
                    .strOpID = vbNullString         '大工程
                    .strStepID = vbNullString       '小工程
                    .strWpID = vbNullString         '装置ID
                    .strWpName = vbNullString       '装置名
                End With
                
                '@Form_Loadﾌﾗｸﾞ(正常)
                pblnFormLoad = True
            Else
            '@親ﾌｫｰﾑから起動の場合
                '@ｷｬﾘｱIDを使用不可能
                With txtCarrier
                    .Enabled = True
                    .Locked = True
                    .TabStop = False
                    .BackColor = SystemColors.ControlLight
                    .GotBackColor = SystemColors.ControlLight
                    .GotHighLight = False
                    .Text = ptypCommonInfo.strCarrierId
                End With
                
                '@ﾛｯﾄIDを使用不可能
                With txtLot
                    .Enabled = True
                    .Locked = True
                    .TabStop = False
                    .BackColor = SystemColors.ControlLight
                    .GotBackColor = SystemColors.ControlLight
                    .GotHighLight = False
                    .Text = ptypCommonInfo.strLotID
                End With
                
                '@ｷｬﾘｱIDの自動取得
                Call txtCarrier_Validate(mblnFormStartKbn, New CancelEventArgs(True))
            End If
            
            'NSYS 一覧の有効無効判定
            If vsfCollect.Rows.Count > 1 Then
                vsfCollect.Enabled = True
            Else
                vsfCollect.Enabled = False
            End If

            '@引継ぎ情報表示済みﾌﾗｸﾞ
            mblnTakeOverDispFlg = False
            
            mblnEditCloseFlg = False

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
    '作成日：2005/01/24 (Mon) 10:44:16 S.Deguchi
    '更新日：2005/01/24 (Mon) 10:44:16
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@親ﾌｫｰﾑ起動の場合
            If mblnFormStartKbn = True Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@処理を抜ける
                Exit Sub
            End If
                
            '@引継ぎ情報表示済みﾌﾗｸﾞの判定
            '@FormLoad後、最初の1回しか処理しない
            If mblnTakeOverDispFlg = True Then
            '@引継ぎ情報が表示済みの場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
            '@引継ぎ情報表示済みﾌﾗｸﾞにTrueを設定する
            mblnTakeOverDispFlg = True

            '@引数のｷｬﾘｱIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
            '@空白でない場合
                'NSYS 表示中白抜け対策
                Me.Refresh()
                '@ｷｬﾘｱIDの初期値を設定する
                RemoveHandler txtCarrier.Change,AddressOf txtCarrier_Change
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                AddHandler txtCarrier.Change,AddressOf txtCarrier_Change
                
                '@情報取得ｺﾝﾄﾛｰﾙ名(ｷｬﾘｱ/ﾛｯﾄ)の設定
                mstrInfoGetControlName = CMstrInfoGetControlNameCarrier

                '@ｷｬﾘｱID情報取得
                RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(sender , New CancelEventArgs(False))
                AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                
                '@ﾌｫｰｶｽの制御(装置別ﾛｯﾄ一覧より連動した場合のみ走行)
                If vsfSlotMap.Enabled = True Then
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            Else
                '@ｷｬﾘｱID初期化
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

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 10:45:38 S.Deguchi
    '更新日：2008/05/08 (Thu) 11:31:20 N.Kojima
    '備　考：
    '　　　：2008/05/08 (Thu) 11:31:20 N.Kojima     装置ﾃﾞｰﾀｸﾞﾘｯﾄﾞのﾌｫｰｶｽ制御対応。(案件№02853)
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
            
            '@ｸﾞﾘｯﾄﾞｷｰの↓↑ｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
            '@ﾃﾞｰﾀ入力ｸﾞﾘｯﾄﾞ
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfCollectValue, cmdVsfUpCollectValue, cmdVsfDownCollectValue)
            
            '@ﾊﾟﾗﾒｰﾀ表示ｸﾞﾘｯﾄﾞ
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfCollect, cmdVsfUpCollect, cmdVsfDownCollect)
            
            '@SLOTMAP表示ｸﾞﾘｯﾄﾞ
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfSlotMap, cmdVsfUpWF, cmdVsfDownWF)


            Select Case ActiveControl.Name
                '@ｷｬﾘｱIDにﾌｫｰｶｽがある場合
                Case txtCarrier.Name
                    '@Enterの場合
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@ﾛｯﾄ情報取得処理へ
                            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Call txtCarrier_Validate(sender, New CancelEventArgs(False))
                            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                    End Select
                
                '@ﾛｯﾄIDにﾌｫｰｶｽがある場合
                Case txtLot.Name
                    '@Enterの場合
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@ﾛｯﾄ情報取得処理へ
                            RemoveHandler txtLot.Validating, AddressOf txtLot_Validate
                            Call txtLot_Validate(sender, New CancelEventArgs(False))
                            AddHandler txtLot.Validating, AddressOf txtLot_Validate
                    End Select
                
                'NSYS
                Case vsfCollectValue.Name
                    '@Enterの場合
                    Select Case e.KeyCode
                        Case Keys.Return
                            vsfCollectValue.AllowEditing = False
                            If vsfCollectValue.Col = CMlngvsfCollectValueDataC Then
                                If vsfCollectValue.Row = vsfCollectValue.Rows.Count -1 Then
                                    'なにもしない
                                Else
                                    SendKeys.SendWait(CPstrSendKeysTab)
                                    '@現在のﾌｫｰｶｽ行が№列か
                                    If vsfCollectValue.Col = CMlngvsfCollectValueNoC Then
                                        '@№列の場合は、次の有効列にﾌｫｰｶｽｾｯﾄ
                                        SendKeys.SendWait(CPstrSendKeysTab)
                                    End If
                                    e.Handled = True
                                End If
                            Else
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                            End If
                    End Select

                            
                '@その他のｺﾝﾄﾛｰﾙにﾌｫｰｶｽがある場合
                Case Else
                    
                    '@Enterの場合
                    Select Case e.KeyCode
                        
                        Case Keys.Return
                            
                            '@次ﾌｫｰｶｽへ
                            SendKeys.SendWait(CPstrSendKeysTab)

                            '@現在のﾌｫｰｶｽ行が№列か
                            If vsfCollectValue.Col = CMlngvsfCollectValueNoC Then
                                '@№列の場合は、次の有効列にﾌｫｰｶｽｾｯﾄ
                                SendKeys.SendWait(CPstrSendKeysTab)
                            End If

                            e.Handled = True
                            
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

    '関数名：Form_KeyPress
    '機　能：ﾌｫｰﾑｷｰﾌﾟﾚｽ処理
    '引　数：KeyAscii：ｱｽｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 10:45:42 S.Deguchi
    '更新日：2005/01/24 (Mon) 10:45:42
    '備　考：
    Private Sub Form_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress

        Try

            Select Case Asc(e.KeyChar)
                '@ｺﾛﾝ(:)58の場合は入力不可
                Case CMlngColonKeyAscii
                   e.Handled = True
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_KeyPress"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 10:45:45 S.Deguchi
    '更新日：2005/01/24 (Mon) 10:45:45
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler  MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender, e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                If mblnEditCloseFlg = True Then
                    e.Cancel = True
                    mblnEditCloseFlg = False
                    Exit Sub
                End If
            End If

            '@ﾓｼﾞｭｰﾙ構造体の初期化
            If mtypLotCollectParamsList.typLotCollectParams IsNot Nothing Then
                mtypLotCollectParamsList.typLotCollectParams.Clear()
            End If
            mtypLotCollectParamsList.llngLotCollectParamsCnt = 0
            mtypLotCollectParamsList.strCategoryID = vbNullString

            If mtypWaferList.typWfList IsNot Nothing Then
                mtypWaferList.typWfList.Clear()
            End If
            mtypWaferList.lngListCnt = 0
            mtypWaferList.strCurrentPositionName = vbNullString
            mtypWaferList.strWfCarryFlag = vbNullString
            mtypWaferList.strSlotSize = vbNullString
            
            IF mtypDataCollect.typParameter IsNot Nothing Then
                mtypDataCollect.typParameter.Clear()
            End If
            mtypDataCollect.lngParameterCnt = 0
            mtypDataCollect.strChgID = vbNullString
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@ﾌﾟﾗｲﾍﾞｰﾄ変数のｸﾘｱ
            '@自ﾌｫｰﾑ起動の場合はACT開放後、終了する
            If mblnFormStartKbn = False Then
                '@ActInitﾌﾗｸﾞの判定
                If pblnActInitFlg = True Then
                    
                    '@Actを自前で初期化した場合
                    '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                    lblnAnsTerm = pubblnAct_Term
                    
                    If lblnAnsTerm = True Then
                        '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                    End If
                Else
                    '@単独機動か否かで処理分岐
                    If pblnfrmxxCM00G0Kbn = False Then
                        '@ﾒｲﾝﾒﾆｭｰ画面を広げる
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
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能："閉じる"ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 10:48:08 S.Deguchi
    '更新日：2018/11/16 (Fri) 09:47:55 Y.Yoneyama
    '備　考：
    '　　　：2005/03/07 (Mon) 10:53:13 N.Kojima     戻り先画面の判定を追加(改善№512)
    '　　　：2005/06/21 (Tue) 09:40:03 N.Kojima     ｺﾒﾝﾄ行の削除(select_proc関数部)
    '　　　：2018/11/16 (Fri) 09:47:55 Y.Yoneyama   防湿ALD対応
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo  As CommonInfo   '戻り構造体
        Dim llngAns         As Integer      '戻り値

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
                    '@装置ﾃﾞｰﾀﾘｽﾄにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfCollectValue)
                    mblnEditCloseFlg = True

                    Exit Sub
                End If
            End If

            '@親ﾌｫｰﾑ起動の場合
            If mblnFormStartKbn = True Then
                '@ﾌｫｰﾑを閉じる
                Me.Close()
            Else
                '@引継ぎ情報のｷｬﾘｱIDが空白かどうか判定する
                If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白でない場合
                    '@装置別ﾛｯﾄ一覧から引き継いで起動された場合
                    If pblnfrmxxEN0150Kbn = True Then
                        '@装置別ﾛｯﾄ一覧を起動する
                        Call pubMenuSelect_Proc(CPstrKeyEN0150)
                                        
        '@↓2018/11/16 (Fri) 09:47:55 Y.Yoneyama **************************************************
                    '@装置別ﾛｯﾄ(防湿ALD)一覧から引き継いで起動された場合
                    ElseIf pblnfrmxxEN0151Kbn = True Then
                        '@装置別ﾛｯﾄ(防湿ALD)一覧を起動する
                        Call pubMenuSelect_Proc(CPstrKeyEN0151)
        '@↑2018/11/16 (Fri) 09:47:55 Y.Yoneyama **************************************************
                        
                    Else
                        '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧から引き継いで起動された場合
                        If pblnfrmxxEN00J0Kbn = True Then
                            '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧を起動する
                            Call pubMenuSelect_Proc(CPstrKeyEN00J0)
                        Else
                        '@工程別ﾛｯﾄ一覧から引き継いで起動された場合
                            '@工程別ﾛｯﾄ一覧を起動する
                            Call pubMenuSelect_Proc(CPstrKeyEN0200)
                        End If
                    End If
                Else
                '@空白の場合
                    '@終了関数を実行する
                    Call publngEnd_Proc(CPstrKeyEN00T0, ltypCommonInfo)
                End If
            End If

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

    '関数名：cmdLineInsert_Click
    '機　能：行追加ﾎﾞﾀﾝのｸﾘｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/26 (Wed) 09:13:00 S.Deguchi
    '更新日：2008/04/04 (Fri) 16:41:10 T.Sawaguchi
    '備　考：
    '　　　：2005/06/14 (Tue) 17:07:44 N.Kojima     判定結果列の表示処理をｺﾒﾝﾄｱｳﾄ(不具合№883)
    '　　　：2005/08/30 (Tue) 16:38:48 S.Deguchi    行挿入時背景色の設定を修正
    '　　　：2006/12/21 (Thu) 13:33:11 N.Kasai      収集項目ﾀｲﾌﾟ追加(№01515)
    '　　　：2008/04/04 (Fri) 16:41:28 T.Sawaguchi  ﾍﾟｰｼﾞ送りﾎﾞﾀﾝ制御追加　案件No02761　対応

    Private Sub cmdLineInsert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLineInsert.Click

        Dim llngCnt             As Integer  'ｶｳﾝﾀ
        Dim llngCnt2            As Integer  'ｶｳﾝﾀ2
        Dim lstrInsertData      As String   '追加ﾃﾞｰﾀ内容
        Dim llngRow             As Integer  'NSYS 選択行格納

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@入力対象不可の場合はｽｷｯﾌﾟ
            With vsfCollect
                
                If .GetData(.Row, CMlngvsfCollectParameterLoad) = CMstrOne Then
                    
                    '@収集項目ﾀｲﾌﾟが1:装置ﾃﾞｰﾀの場合
                    If .GetData(.Row, CMlngvsfCollectCollectionType) = CMstrOne Then
                        Exit Sub
                    Else
                        .SetData(.Row, CMlngvsfCollectParameterLoad, CMstrTwo)
                    End If
                End If
            End With
            
            '@追加ﾃﾞｰﾀ内容の設定
            lstrInsertData = vbNullString
            
            '@変数を初期化
            mstrvsfCollectValueRow = vbNullString
            
            '@編集中ﾌﾗｸﾞを立てる
            mblnEditFlag = True
            
            '@№～値
            For llngCnt = CMlngvsfCollectValueNoC To CMlngvsfCollectValueDataC
                '@判定結果Colよりも前の項目か
                If llngCnt < CMlngvsfCollectValueDataC Then
                    '@追加ﾃﾞｰﾀ内容に格納
                    lstrInsertData = lstrInsertData & vbNullString & vbTab
                Else
                    '@追加ﾃﾞｰﾀ内容に格納
                    lstrInsertData = lstrInsertData & vbNullString
                End If
            Next llngCnt
            
            '@行挿入
            With vsfCollectValue
                llngRow = .Row
                '@前行へ追加する
                RemoveHandler vsfCollectValue.EnterCell,AddressOf vsfCollectValue_EnterCell
                .AddItem(lstrInsertData, .Row)
                .Row = llngRow
                AddHandler vsfCollectValue.EnterCell,AddressOf vsfCollectValue_EnterCell
                
                '@内部変数へ行Noをｾｯﾄする
                mstrvsfCollectValueRow = str(vsfCollectValue.Row - 2)
                mstrvsfCollectValueRow = LTrim(RTrim(mstrvsfCollectValueRow))
                
                '@値位置の設定
                If vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectDataTypeC) = CMstrDataTypeN Then
                    '@数字ﾀｲﾌﾟの場合は右寄
                    .Cols(CMlngvsfCollectValueDataC).TextAlign =TextAlignEnum.RightCenter
                Else
                    '@文字ﾀｲﾌﾟの場合は左寄
                    .Cols(CMlngvsfCollectValueDataC).TextAlign = TextAlignEnum.LeftCenter
                End If
                
                '@色戻し
                For llngCnt = 1 To .Rows.Count - 1
                    For llngCnt2 = CMlngvsfCollectValueNoC To CMlngvsfCollectValueDataC
                        '@前の色がﾋﾟﾝｸの場合
                        If .GetCellRange(llngCnt, llngCnt2).StyleDisplay.BackColor = ColorTranslator.FromWin32(CMlngInputColor) Then
                            '@選択されている行が,現在どの色かにより処理を分岐
                            Select Case .GetCellRange(llngCnt, CMlngvsfCollectValueNoC).StyleDisplay.BackColor
                                Case ColorTranslator.FromWin32(CMlngOKBackColor)
                                '@収集不要色
                                    '@選択ｾﾙを藤色に
                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngOKBackColor" + llngCnt2.ToString)
                                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngOKBackColor)
                                    Dim cellRange As CellRange = .GetCellRange(llngCnt, llngCnt2)
                                    cellRange.Style = newStyle
                                
                                Case ColorTranslator.FromWin32(CMlngRetainColor)
                                '@引継色
                                    '@選択ｾﾙを水色に
                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngRetainColor" + llngCnt2.ToString)
                                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngRetainColor)
                                    Dim cellRange As CellRange = .GetCellRange(llngCnt, llngCnt2)
                                    cellRange.Style = newStyle
                                
                                Case Else
                                '@その他
                                    '@選択ｾﾙを白に
                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite" + llngCnt2.ToString)
                                    newStyle.BackColor = Color.White
                                    Dim cellRange As CellRange = .GetCellRange(llngCnt, llngCnt2)
                                    cellRange.Style = newStyle
                            End Select
                        End If
                    Next llngCnt2
                Next llngCnt
                
                'NSYS 選択セル背景色
                Select Case .GetCellRange(.Row, .Col).StyleDisplay.BackColor
                    Case ColorTranslator.FromWin32(CMlngOKBackColor)
                        .Styles.Focus.BackColor =  ColorTranslator.FromWin32(CMlngOKBackColor)
                        .Styles.Highlight.BackColor =  ColorTranslator.FromWin32(CMlngOKBackColor)

                    Case ColorTranslator.FromWin32(CMlngRetainColor)
                        .Styles.Focus.BackColor =  ColorTranslator.FromWin32(CMlngRetainColor)
                        .Styles.Highlight.BackColor =  ColorTranslator.FromWin32(CMlngRetainColor)

                    Case Else
                        .Styles.Focus.BackColor =  Color.White
                        .Styles.Highlight.BackColor =  Color.White

                End Select

                '@高さ設定
                .Rows(.Row).Height = CMlngvsfRowHeight             'CMlngGridRowHeight→CMlngvsfRowHeightに変更
                
                '@削除ﾎﾞﾀﾝの制御
                cmdLineDelete.Enabled = True
                If .Rows.Count - 1 >= 1 Then
                    If IsNumeric(vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectMandatoryCountC)) = True Then
                        If .Rows.Count - 1 <= vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectMandatoryCountC) Then
                            cmdLineDelete.Enabled = False
                        End If
                    End If
                Else
                    cmdLineDelete.Enabled = False
                End If
            
            End With
                
            '@行番号の採番
            For llngCnt = 1 To vsfCollectValue.Rows.Count - 1
                '@行番号格納
                vsfCollectValue.SetData(llngCnt, CMlngvsfCollectValueNoC, llngCnt)
            Next llngCnt
            
            '@確定ﾎﾞﾀﾝの使用可設定
            Call prvcmdRegistEnabled_Chk()

            '@装置ﾃﾞｰﾀにﾌｫｰｶｽ設定する
            If vsfCollectValue.Enabled = True Then
                Call pubSetFocus(vsfCollectValue)
                Call vsfCollectValue_EnterCell(sender, e)

                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ、前頁、次頁)
                Call pubVsfCmdUp(vsfCollectValue, cmdVsfUpCollectValue, cmdVsfDownCollectValue)
                
                '@行の表示を行う
                Call prvVsfInputControll(vsfCollectValue, 0, cmdVsfUpCollectValue, _
                                            cmdVsfDownCollectValue, vsfCollectValue.Row + 1, True, _
                                            mstrvsfCollectValueRow)

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLineInsert_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLineDelete_Click
    '機　能：行削除ﾎﾞﾀﾝのｸﾘｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/26 (Wed) 09:13:15 S.Deguchi
    '更新日：2008/04/04 (Fri) 16:40:24 T.Sawaguchi
    '備　考：
    '　　　：2005/06/14 (Tue) 17:07:44 N.Kojima     判定結果列の表示処理をｺﾒﾝﾄｱｳﾄ(不具合№883)
    '　　　：2006/12/21 (Thu) 13:34:27 N.Kasai      収集項目ﾀｲﾌﾟ追加(№01515)
    '　　　：2008/04/04 (Fri) 16:40:42 T.Sawaguchi  ﾍﾟｰｼﾞ送りﾎﾞﾀﾝ制御追加　案件No02761　対応

    Private Sub cmdLineDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLineDelete.Click

        Dim llngCnt             As Integer  'ｶｳﾝﾀ
        Dim llngCnt2            As Integer  'ｶｳﾝﾀ2

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@入力対象不可の場合はｽｷｯﾌﾟ
            With vsfCollect
                
                If .GetData(.Row, CMlngvsfCollectParameterLoad) = CMstrOne Then
                    
                    '@収集項目ﾀｲﾌﾟが1:装置ﾃﾞｰﾀの場合
                    If .GetData(.Row, CMlngvsfCollectCollectionType) = CMstrOne Then
                        Exit Sub
                    Else
                        .SetData(.Row, CMlngvsfCollectParameterLoad, CMstrTwo)
                    End If
                
                End If
            End With
            
            '@変数を初期化
            mstrvsfCollectValueRow = vbNullString
            
            '@行削除
            With vsfCollectValue
                
                '@表示用の為に内部変数へ行Noをｾｯﾄする
                mstrvsfCollectValueRow = str(vsfCollectValue.Row)
                mstrvsfCollectValueRow = LTrim(RTrim(mstrvsfCollectValueRow))

                '@前行を削除する
                .Redraw = False
                .RemoveItem(.Row)
                .Redraw = True

            End With
            
            '@必須項目数以下の行数になった場合には編集ﾌﾗｸﾞを解除
            If vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectMandatoryCountC) > _
                vsfCollectValue.Rows.Count - 1 Then
                
                '@編集中ﾌﾗｸﾞを解除
                mblnEditFlag = False
            Else
                '@編集中ﾌﾗｸﾞを立てる
                mblnEditFlag = True
            End If
            
            '@行追加
            With vsfCollectValue
                '@0行の場合は最終行へ追加する
                If .Rows.Count = 1 Then
                    .Rows.Count = .Rows.Count + 1
                End If
                
                '@値位置の設定
                If vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectDataTypeC) = CMstrDataTypeN Then
                    '@数字ﾀｲﾌﾟの場合は右寄
                    .Cols(CMlngvsfCollectValueDataC).TextAlign = TextAlignEnum.RightCenter
                Else
                    '@文字ﾀｲﾌﾟの場合は左寄
                    .Cols(CMlngvsfCollectValueDataC).TextAlign = TextAlignEnum.LeftCenter
                End If
                
                '@色戻し
                For llngCnt = 1 To .Rows.Count - 1
                    For llngCnt2 = CMlngvsfCollectValueNoC To CMlngvsfCollectValueDataC
                        '@前の色がﾋﾟﾝｸの場合
                        If .GetCellRange(llngCnt, llngCnt2).StyleDisplay.BackColor = ColorTranslator.FromWin32(CMlngInputColor) Then
                            '@選択ｾﾙを白に
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite" + llngCnt2.ToString)
                            newStyle.BackColor = Color.White
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, llngCnt2)
                            cellRange.Style = newStyle
                        End If
                    Next llngCnt2
                Next llngCnt
                      
                '@高さ設定
                .Rows(.Rows.Count - 1).Height = CMlngvsfRowHeight   'CMlngGridRowHeight→CMlngvsfRowHeightへ変更

                '@削除ﾎﾞﾀﾝの制御
                If .Rows.Count - 1 > 1 Then
                    If IsNumeric(vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectMandatoryCountC)) = True Then
                        If .Rows.Count - 1 <= CLng(vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectMandatoryCountC)) Then
                            cmdLineDelete.Enabled = False
                        End If
                    End If
                Else
                    '@行削除ﾎﾞﾀﾝを非活性化
                    cmdLineDelete.Enabled = False
                End If
            
            End With
            
            '@行番号の採番
            For llngCnt = 1 To vsfCollectValue.Rows.Count - 1
                '@行番号格納
                vsfCollectValue.SetData(llngCnt, CMlngvsfCollectValueNoC, llngCnt)
            Next llngCnt
            
            '@確定ﾎﾞﾀﾝの使用可設定
            Call prvcmdRegistEnabled_Chk()

            '@装置ﾃﾞｰﾀにﾌｫｰｶｽ設定する
            If vsfCollectValue.Enabled = True Then
                Call pubSetFocus(vsfCollectValue)
                Call vsfCollectValue_EnterCell(sender ,e)
            End If
            
            '@ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ、前頁、次頁)
             Call pubVsfCmdUp(vsfCollectValue, cmdVsfUpCollectValue, cmdVsfDownCollectValue)
             
             '@行の表示を行う
             Call prvVsfInputControll(vsfCollectValue, 0, cmdVsfUpCollectValue, _
                                        cmdVsfDownCollectValue, vsfCollectValue.Row + 1, True, _
                                        mstrvsfCollectValueRow)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLineDelete_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNAInput_Click
    '機　能：値未入力ﾎﾞﾀﾝのｸﾘｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/26 (Wed) 09:13:29 S.Deguchi
    '更新日：2008/04/04 (Fri) 16:42:06 T.Sawaguchi
    '備　考：
    '　　　：2005/06/14 (Tue) 17:07:44 N.Kojima     判定結果列の表示処理をｺﾒﾝﾄｱｳﾄ(不具合№883)
    '　　　：2006/12/21 (Thu) 13:35:44 N.Kasai      収集項目ﾀｲﾌﾟ追加(№01515)
    '　　　：2008/04/04 (Fri) 16:42:24 T.Sawaguchi  ﾍﾟｰｼﾞ送りﾎﾞﾀﾝ制御追加　案件No02761　対応

    Private Sub cmdNAInput_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNAInput.Click

        Dim llngCnt                 As Integer      'ｶｳﾝﾀ
        Dim llngNextCol             As Integer      '次列
        Dim llngStartCol            As Integer      '検索対象開始列

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@編集項目以外はｽｷｯﾌﾟ
            Select Case vsfCollectValue.Col
                '@ﾃﾞｰﾀ分類名1～4 or ﾃﾞｰﾀ値の場合
                Case CMlngvsfCollectValueClass1C, _
                     CMlngvsfCollectValueClass2C, _
                     CMlngvsfCollectValueClass3C, _
                     CMlngvsfCollectValueClass4C, _
                     CMlngvsfCollectValueDataC
                    '@処理続行
                
                Case Else
                    Exit Sub
            End Select
            
            '@変数を初期化
            mstrvsfCollectValueRow = vbNullString
            
            '@編集中ﾌﾗｸﾞを立てる
            mblnEditFlag = True
            
            '@入力対象不可の場合はｽｷｯﾌﾟ
            With vsfCollect
                
                If .GetData(.Row, CMlngvsfCollectParameterLoad) = CMstrOne Or _
                   .GetData(.Row, CMlngvsfCollectParameterLoad) = CMstrFour Then
                    
                    '@収集項目ﾀｲﾌﾟが1:装置ﾃﾞｰﾀの場合
                    If .GetData(.Row, CMlngvsfCollectCollectionType) = CMstrOne Then
                        Exit Sub
                    Else
                        .SetData(.Row, CMlngvsfCollectParameterLoad, CMstrTwo)
                    End If
                
                End If
            End With
            
            '@N/A設定
            With vsfCollectValue
                
                '@列がﾃﾞｰﾀ値の場合
                If .Col = CMlngvsfCollectValueDataC Then
                    '@判定結果の初期表示
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngOkForeColor" + .Row.ToString)
                    newStyle.ForeColor = ColorTranslator.FromWin32(CMlngOkForeColor)
                    '@選択されている行が引継色
                    If .GetCellRange(.Row, CMlngvsfCollectValueNoC).StyleDisplay.BackColor = ColorTranslator.FromWin32(CMlngRetainColor) Then
                        '@選択ｾﾙを水色に
                        newStyle.BackColor = ColorTranslator.FromWin32(CMlngRetainColor)
                    Else
                        newStyle.BackColor = Color.White
                    End If
                    Dim cellRange As CellRange = .GetCellRange(.Row, .Col)
                    cellRange.Style = newStyle                               '列 = 黒
                End If
                
                '@N/A文字設定
                .SetData(.Row, .Col, CMstrNaString)   'N/A格納
                
                '@内部変数へ行Noをｾｯﾄする
                mstrvsfCollectValueRow = str(vsfCollectValue.Row)
                mstrvsfCollectValueRow = LTrim(RTrim(mstrvsfCollectValueRow))
            
            End With
                
            '@列幅の自動調整
            With vsfCollectValue
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCol(vsfCollectValue.Col, 6)
            End With

            '@行追加
            With vsfCollectValue
                
                '@常に1行分の余裕を確保
                If .Row >= .Rows.Count - 1 Then
                    
                    '@最終行へ追加する
                    .Rows.Count = .Rows.Count + 1
                    
                    '@値位置の設定
                    If vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectDataTypeC) = CMstrDataTypeN Then
                        '@数字ﾀｲﾌﾟの場合は右寄
                        .Cols(CMlngvsfCollectValueDataC).TextAlign = TextAlignEnum.RightCenter
                    Else
                        '@文字ﾀｲﾌﾟの場合は左寄
                        .Cols(CMlngvsfCollectValueDataC).TextAlign = TextAlignEnum.LeftCenter
                    End If

                    '@高さ設定
                    .Rows(.Rows.Count - 1).Height = CMlngvsfRowHeight   'CMlngGridRowHeight→CMlngvsfRowHeightへ変更

                    '@行番号の採番
                    For llngCnt = 1 To .Rows.Count - 1
                        '@行番号格納
                        .SetData(llngCnt, CMlngvsfCollectValueNoC, llngCnt)
                    Next llngCnt
                End If
            End With
            
            '@次ﾌｫｰｶｽ設定
            With vsfCollectValue
                '@列がﾃﾞｰﾀ値の場合
                If .Col = CMlngvsfCollectValueDataC Then
                    '@検索対象開始列にﾃﾞｰﾀ分類1名を格納
                    llngStartCol = CMlngvsfCollectValueClass1C
                    .Row = .Row + 1
                Else
                    llngStartCol = .Col + 1
                End If
                llngNextCol = -1
                '@検索対象開始列からﾃﾞｰﾀ値まで
                For llngCnt = llngStartCol To CMlngvsfCollectValueDataC
                    '@隠しColではない場合
                    If .Cols(llngCnt).Visible = True Then
                        llngNextCol = llngCnt
                        Exit For
                    End If
                Next llngCnt
                '@次列が"0"より大きいか
                If llngNextCol > 0 Then
                    .Col = llngNextCol
                End If
                .ShowCell(.Row, .Col)
                '@ﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfCollectValue)
            End With
            
            '@確定ﾎﾞﾀﾝの使用可設定
            Call prvcmdRegistEnabled_Chk()
            
            '@ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ、前頁、次頁)
            Call pubVsfCmdUp(vsfCollectValue, cmdVsfUpCollectValue, cmdVsfDownCollectValue)
            
            '@行の表示を行う
            Call prvVsfInputControll(vsfCollectValue, 0, cmdVsfUpCollectValue, _
                                        cmdVsfDownCollectValue, vsfCollectValue.Row + 1, True, _
                                        mstrvsfCollectValueRow)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNAInput_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能："確定"ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/26 (Wed) 09:11:37 S.Deguchi
    '更新日：2008/04/11 (Fri) 14:27:03 T.Sawaguchi
    '備　考：
    '　　　：2005/08/30 (Tue) 12:59:31 S.Deguchi    画面情報を構造体へｾｯﾄする処理を追加(EditText対応)
    '　　　：2005/10/19 (Wed) 16:45:24 S.Deguchi    不具合№2325の対応で,作業者入力ｷｬﾝｾﾙ時確定ﾎﾞﾀﾝを使用できるように修正
    '　　　：2005/10/20 (Thu) 14:06:57 S.Deguchi    不具合№3093の対応で,ﾃﾞｰﾀﾘｽﾄが0件の場合には処理をしなくするように修正
    '　　　：2005/11/07 (Mon) 14:00:39 S.Deguchi    作業者IDをｾｯﾄする処理を追加
    '　　　：2005/12/05 (Mon) 09:19:09 S.Deguchi    運用障害№619対応
    '　　　：2008/04/11 (Fri) 14:27:03 T.Sawaguchi  案件No02761結合ﾃｽﾄ不具合対応
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnInputCheck              As Boolean              '画面入力ﾁｪｯｸ(True:正常,False:異常)
        Dim lblnAns                     As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypWfChgCollection         As WfChgCollection      '装置ﾃﾞｰﾀ登録構造体
        Dim lstrFormName                As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngDispWFRow               As Integer              'WFｽﾛｯﾄ数退避
        Dim lstrLotLastUpdate           As String               '最終更新日時
        Dim llngCollectIndex            As Integer              '引継ぎ情報戻

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

            '@初期化
            llngCollectIndex = 0
            
            '@画面の入力情報を構造体へｾｯﾄする
            With vsfCollect
                If .GetData(.Row, CMlngvsfCollectParameterLoad) <> CMstrOne And _
                   .GetData(.Row, CMlngvsfCollectParameterLoad) <> CMstrFour Then
                    '@ｸﾞﾘｯﾄﾞﾃﾞｰﾀを構造体へ反映させる
                    Call prvParameterInputData_Set(.GetData(.Row, CMlngvsfCollectParaIdC))
                
                    If .GetData(.Row, CMlngvsfCollectParameterLoad) <> CMstrThree Then
                        '@ﾌﾗｸﾞを立てる(引継情報)
                        Dim typParameterTmp As Parameter = mtypDataCollect.typParameter(.Row-1)
                        typParameterTmp.strInputDataFlag = CMstrTwo
                        mtypDataCollect.typParameter(.Row-1) = typParameterTmp 
                        .SetData(.Row, CMlngvsfCollectParameterLoad, CMstrTwo)
                    End If
                End If
            End With
            
            '@画面入力ﾁｪｯｸ
            lblnInputCheck = prvblnInput_Check
            '@結果異常
            If lblnInputCheck = False Then
            
                '@ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ、前頁、次頁)
                Call pubVsfCmdUp(vsfCollectValue, cmdVsfUpCollectValue, cmdVsfDownCollectValue)
                '@行の表示を行う
                Call prvVsfInputControll(vsfCollectValue, 0, cmdVsfUpCollectValue, _
                                            cmdVsfDownCollectValue, vsfCollectValue.Row + 1, True, _
                                            mstrvsfCollectValueRow)

                Exit Sub
            End If
            
            '@要求構造体を作成
            Call prvRegistData_Set(ltypWfChgCollection)
                
            '@要求構造体の構成内容から処理分岐
            If ltypWfChgCollection.lngEqWfDataEntryCnt = 0 Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007E)

                '@"収集不要のパラメータに対して、装置データを入力せずに$登録することはできません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@確定ﾎﾞﾀﾝを非活性化
                cmdRegist.Enabled = False
                
                Exit Sub
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                '@確定ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
                
                Exit Sub
            End If

            With ltypWfChgCollection
                '@作業者IDをｾｯﾄ
                .strEmpID = pstrUserID
            
                '@DATA_DIVISIONをｾｯﾄ
                If optDataUnit1.Checked = True Then
                    '@LOT単位
                    .strDataDivision = CMstrDataDivisionL
                Else
                    '@WAFER単位
                    .strDataDivision = CMstrDataDivisionW
                End If
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@情報によりﾒｯｾｰｼﾞを変更する
            lblnAns = pubblnSpcRegCollect_Ins(ltypWfChgCollection, lstrLotLastUpdate)
            '@結果判定
            If lblnAns = False Then
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Sub
            Else
                '@表示ﾒｯｾｰｼﾞ
                If optDataUnit2.Checked = True Then
                    '@ﾃﾞｰﾀ単位が「WF単位」の場合
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@pubVsfInfo_Disp("メッセージコード：<TRM0XI>$$装置データを登録しました。キャリア[%1] ロット[%2] WF_ID[%3] パラメータ[%4]")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000X, txtCarrier.Text, txtLot.Text, _
                                        vsfSlotMap.GetData(vsfSlotMap.Row, CMlngvsfSlotMapWfIdC), _
                                        vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectParaIdC))
                Else
                    '@ﾃﾞｰﾀ処理単位が「Lot単位(ﾊﾞｯﾁ単位)」の場合
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@pubVsfInfo_Disp("メッセージコード：<TRM2T>$$装置データを登録しました。キャリア[%1] ロット[%2] パラメータ[%3]")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002T, txtCarrier.Text, txtLot.Text, _
                                                    vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectParaIdC))
                End If
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
            End If

            '@次回の引継ぎ用装置ﾃﾞｰﾀを格納
            Call prvCollectNextInfo_Set(llngCollectIndex)

            '@情報の再取得
            '@情報取得ｺﾝﾄﾛｰﾙ設定(ｷｬﾘｱID)
            mstrInfoGetControlName = CMstrInfoGetControlNameCarrier
            
            '@ﾛｯﾄ最終更新日時の退避
            mstrLotLastUpdate = lstrLotLastUpdate
            
            '@最終更新日を書き換える
            ptypLotprestate.strLotLastUpdate = lstrLotLastUpdate

            '@編集ﾌﾗｸﾞを初期化
            mblnEditFlag = False

            '@画面表示する情報による処理分岐
            If optDataUnit1.Checked = True Then
                        
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@ｷｬﾘｱIDの退避領域をｸﾘｱ
                mstrTaihiCarrierID = vbNullString
                
                '@ｷｬﾘｱIDのValidate処理を呼出す
                Call txtCarrier_Validate(sender, New CancelEventArgs(True))
            
                'ﾌｫｰｶｽ処理("ﾛｯﾄ単位"にﾌｫｰｶｽｾｯﾄ)
                If optDataUnit1.Checked = True Then
                    Call pubSetFocus(optDataUnit1)
                End If
            Else
                '@WF情報構造体の初期化
                If mtypWaferList.typWfList Is Nothing Then
                    mtypWaferList.typWfList = New List(Of WFList)
                Else
                    mtypWaferList.typWfList.Clear
                End If
                mtypWaferList.lngListCnt = 0
                mtypWaferList.strCurrentPositionName = vbNullString
                mtypWaferList.strWfCarryFlag = vbNullString
                mtypWaferList.strSlotSize = vbNullString
            
                '@表示ｲﾝﾃﾞｯｸｽによる処理分岐(WF単位のみ処置)
                '@WF情報の取得
                lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, txtCarrier.Text, CPstrCD0T, mtypWaferList)
                '@結果判定
                If lblnAns = False Then
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)

                    Exit Sub

                End If
                
                '@画面表示処理ﾌﾗｸﾞを立てる
                mblnScreenDispFlag = True
            
                '@WF選択行を退避
                llngDispWFRow = vsfSlotMap.Row
            
                'ｽﾛｯﾄﾏｯﾌﾟの初期化
                Call prvvsfSlotMap_init()
            
                '@ｽﾛｯﾄMAPの画面表示処理
                Call prvVsfSlotMap_Disp()
            
                '@退避したWFｽﾛｯﾄをｾｯﾄ
                vsfSlotMap.Row = llngDispWFRow
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@画面表示処理ﾌﾗｸﾞを戻す
                mblnScreenDispFlag = False
                    
                '@SlotMapのEnterCell処理を呼出す
                Call vsfSlotMap_EnterCell(sender, e)
                
                '@画面表示処理ﾌﾗｸﾞを立てる
                mblnScreenDispFlag = True
                
                '@ﾌｫｰｶｽ処理
                If vsfSlotMap.Enabled = True Then
                    vsfSlotMap.Select(vsfSlotMap.Row, CMlngvsfSlotMapWfIdC)
                    Call pubSetFocus(vsfSlotMap)
                End If
            
                '@画面表示処理ﾌﾗｸﾞを戻す
                mblnScreenDispFlag = False
            End If

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

    '関数名：optDataUnit_Click
    '機　能：ﾛｯﾄ/WFの切替え
    '引　数：Index：1:ﾛｯﾄ単位/2:WF単位
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 09:48:06 S.Deguchi
    '更新日：2008/04/11 (Fri) 13:25:12 T.Sawaguchi
    '備　考：
    '　　　：2005/06/21 (Tue) 15:42:16 N.Kojima     ｺﾒﾝﾄ行の削除(装置ﾃﾞｰﾀｸﾞﾘｯﾄﾞの処理追加部)
    '　　　：2005/06/24 (Fri) 12:34:43 N.Kojima     運用障害対応(№434)
    '　　　：2007/01/29 (Mon) 13:13:28 N.Kojima     WF単位が選択された場合は、WF_IDをｾｯﾄして収集ﾊﾟﾗﾒｰﾀ取得を行なう。
    '　　　：                                       Lot単位が選択された場合は、WF_IDにNULLをｾｯﾄする。(案件№01428)
    '　　　：2007/02/06 (Tue) 11:35:51 N.Kasai      WF単位で装置ﾃﾞｰﾀ入力対象WFIDが存在しない場合は値の入力不可(№01120)
    '　　　：2008/04/11 (Fri) 13:25:30 T.Sawaguchi  案件02761のﾃｽﾄ不具合修正
    Private Sub optDataUnit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optDataUnit1.CheckedChanged, optDataUnit2.CheckedChanged

        Dim lblnAns                     As Boolean                  '結果取得(True:正常,False:異常)
        Dim llngAns                     As Integer                  '結果取得
        Dim lstrFormName                As String                   'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String                   'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypwfCollectionInfo        As WfCollectionInfo         '装置ﾃﾞｰﾀ取得構造体
        Dim ltypSpcCollectionInfo       As CollectionInfoRequest    '装置ﾃﾞｰﾀ要求構造体
        Dim llngCnt                     As Integer                  'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lstrLotID                   As String                   'ﾛｯﾄID(ﾛｰｶﾙ変数置換)
        Dim lstrParameterID             As String                   'ﾊﾟﾗﾒｰﾀID(ﾛｰｶﾙ変数置換)
        Dim lstrParameterVer            As String                   'ﾊﾟﾗﾒｰﾀVer(ﾛｰｶﾙ変数置換)
        Dim lstrWFID                    As String                   'WFID(ﾛｰｶﾙ変数置換)
        Dim llngDispRow                 As Integer                  '表示行
        Dim lstrLotWFSelectFlag         As String                   'ﾛｯﾄ/WF切替えﾌﾗｸﾞ
        Dim llngCollectIndex            As Integer                  '引継ﾌﾗｸﾞ

        Try

            'NSYS FALSEは処理を抜ける
            If sender.Checked = False Then
                Exit Sub
            End If

            '@初期化
            llngCnt = 0
            lstrLotID = vbNullString
            lstrParameterID = vbNullString
            lstrParameterVer = vbNullString
            lstrWFID = vbNullString
            llngDispRow = 0
            llngCollectIndex = 0
            
            '@起動時には処理しない
            If pblnFormLoad = False Then
                Exit Sub
            End If

            '@画面表示処理ﾌﾗｸﾞ判定
            If mblnScreenDispFlag = True Then
                Exit Sub
            End If

            '@編集中判定(編集ﾌﾗｸﾞから判断)
            If mblnEditFlag = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                
                '@"編集中です。 内容を破棄してよろしいですか？"
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                '@要求確認
                If llngAns = vbNo Then
                    '@装置ﾃﾞｰﾀﾘｽﾄにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfCollectValue)
                    
                    '@表示処理ﾌﾗｸﾞを立てる(無限ﾙｰﾌﾟ回避)
                    mblnScreenDispFlag = True
                    
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝを元に戻す
                    If sender.Name = optDataUnit1.Name Then
                        optDataUnit2.Checked = True
                    Else
                        optDataUnit1.Checked = True
                    End If
                    
                    '@表示処理ﾌﾗｸﾞを戻す(無限ﾙｰﾌﾟ回避)
                    mblnScreenDispFlag = False
                    
                    '@ﾛｯﾄ情報取得時のｷｬﾘｱIDを格納
                    txtCarrier.Text = mstrTaihiCarrierID
                    
                    Exit Sub
                End If
            End If

            '@ﾛｯﾄ/WFの切替え処置
            Select Case sender.Name
                '@ﾛｯﾄ単位・ﾊﾞｯﾁ単位
                Case optDataUnit1.Name
                    vsfSlotMap.HighLight = HighLightEnum.Never
                    lstrLotWFSelectFlag = CMstrOne
                    
                '@WF単位
                Case optDataUnit2.Name
                    vsfSlotMap.HighLight = HighlightEnum.Always
                    lstrLotWFSelectFlag = CMstrTwo
            End Select

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "optDataUnit_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
        '@情報取得処理**************************************************(失敗した場合は,終了)
            '@WF情報構造体の初期化
            If mtypWaferList.typWfList Is Nothing Then
                 mtypWaferList.typWfList = New List(Of WfList)
            Else
                 mtypWaferList.typWfList.Clear()
            End If
            mtypWaferList.lngListCnt = 0
            mtypWaferList.strCurrentPositionName = vbNullString
            mtypWaferList.strWfCarryFlag = vbNullString
            mtypWaferList.strSlotSize = vbNullString
            
            '@ﾓｼﾞｭｰﾙ構造体を初期化
            If mtypLotCollectParamsList.typLotCollectParams Is Nothing Then
                mtypLotCollectParamsList.typLotCollectParams = New List(Of LotCollectParams)
            Else
                mtypLotCollectParamsList.typLotCollectParams.Clear()
            End If
            mtypLotCollectParamsList.llngLotCollectParamsCnt = 0
            mtypLotCollectParamsList.strCategoryID = vbNullString
            mtypLotCollectParamsList.strLotDataCollCompFlag = vbNullString
            
            With ptypLotprestate
            
                '@表示ｲﾝﾃﾞｯｸｽによる処理分岐(WF単位のみ処置)
                If lstrLotWFSelectFlag = CMlngOptDataUnit2 Then
                    '@WF情報の取得
                    lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, txtCarrier.Text, CPstrCD0T, mtypWaferList)
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        '@装置ﾃﾞｰﾀ一覧が有効か
                        If vsfCollectValue.Enabled = True Then
                            '@装置ﾃﾞｰﾀ一覧へﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfCollectValue)
                        End If
                        
                        Exit Sub
                    End If
                    
                    '@WF情報取得でWFが存在したか(存在しない場合はWF_IDをNULLで送信する)
                    If mtypWaferList.lngListCnt <> 0 Then
                        '@WFが存在した場合
                        
                        '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀの取得(WF単位、WF_IDに値をｾｯﾄ)
                        lblnAns = pubblnLotCollectParams_Sel(CMstrlot_collectparamsVer, _
                                                             .strLotID, _
                                                             .strOpID, _
                                                             .strStepID, _
                                                             lstrLotWFSelectFlag, _
                                                             mtypWaferList.typWfList(0).strWfId, _
                                                             mtypLotCollectParamsList)
                    Else
                        '@WFが存在しない場合
                    
                        '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀの取得(WF単位、WF_ID=NULLをｾｯﾄ)
                        lblnAns = pubblnLotCollectParams_Sel(CMstrlot_collectparamsVer, _
                                                             .strLotID, _
                                                             .strOpID, _
                                                             .strStepID, _
                                                             lstrLotWFSelectFlag, _
                                                             vbNullString, _
                                                             mtypLotCollectParamsList)
                    End If

                Else
                    '@Lot単位が選択されている場合
                
                    '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀの取得(Lot単位、WF_ID=NULLをｾｯﾄ)
                    lblnAns = pubblnLotCollectParams_Sel(CMstrlot_collectparamsVer, _
                                                         .strLotID, _
                                                         .strOpID, _
                                                         .strStepID, _
                                                         lstrLotWFSelectFlag, _
                                                         vbNullString, _
                                                         mtypLotCollectParamsList)
            
                End If
            
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@入力情報一覧へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfCollectValue)
                    
                    Exit Sub
                End If
            End With
                
            '@ﾊﾟﾗﾒｰﾀ入力情報の取得
            With mtypLotCollectParamsList
                '@ﾊﾟﾗﾒｰﾀ情報がある場合
                If .llngLotCollectParamsCnt > 0 Then
                    '@ﾛｯﾄ単位の場合
                    If lstrLotWFSelectFlag = CMlngOptDataUnit1 Then
                        '@ﾊﾟﾗﾒｰﾀの最初の1件で情報を取得しに行く
                        '@ﾛｰｶﾙ変数へ置換
                        lstrLotID = txtLot.Text                                                     'ﾛｯﾄID
                        lstrParameterID = .typLotCollectParams(CMlngZero).strParameterID            'ﾊﾟﾗﾒｰﾀID
                        lstrParameterVer = .typLotCollectParams(CMlngZero).strParameterVersion      'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
                        lstrWFID = vbNullString                                                     'WFID
                        
                        '@要求構造体にｾｯﾄ
                        With ltypSpcCollectionInfo
                            .strMsgVer = CMstrspc_collectioninfoVer         'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                            .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                            .strLotID = lstrLotID                           'ﾛｯﾄID
                            .strParameterID = lstrParameterID               'ﾊﾟﾗﾒｰﾀID
                            .strParameterVersion = lstrParameterVer         'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
                            .strWfId = vbNullString                         'WFID
                        End With
                        
                        '@装置ﾃﾞｰﾀ情報の取得
                        lblnAns = pubblnSpcCollectionInfo_Sel(ltypSpcCollectionInfo, ltypwfCollectionInfo)
                        '@結果判定
                        If lblnAns = False Then
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)
                            
                            '@入力情報一覧へﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfCollectValue)
                            
                            Exit Sub
                        End If
                    Else
                        '@ﾊﾟﾗﾒｰﾀの最初の1件と最初のWFIDで情報を取得しに行く
                        '@ﾛｰｶﾙ変数へ置換
                        lstrLotID = txtLot.Text                                                     'ﾛｯﾄID
                        lstrParameterID = .typLotCollectParams(CMlngZero).strParameterID            'ﾊﾟﾗﾒｰﾀID
                        lstrParameterVer = .typLotCollectParams(CMlngZero).strParameterVersion      'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
                        lstrWFID = mtypWaferList.typWfList(CMlngZero).strWfId                       'WF_ID
                                
                        '@要求構造体にｾｯﾄ
                        With ltypSpcCollectionInfo
                            .strMsgVer = CMstrspc_collectioninfoVer         'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                            .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                            .strLotID = lstrLotID                           'ﾛｯﾄID
                            .strParameterID = lstrParameterID               'ﾊﾟﾗﾒｰﾀID
                            .strParameterVersion = lstrParameterVer         'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
                            .strWfId = lstrWFID                             'WFID
                        End With
                        
                        '@装置ﾃﾞｰﾀ情報の取得
                        lblnAns = pubblnSpcCollectionInfo_Sel(ltypSpcCollectionInfo, ltypwfCollectionInfo)
                        '@結果判定
                        If lblnAns = False Then
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)
                            
                            '@入力情報一覧へﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfCollectValue)
                            
                            Exit Sub
                        End If
                    End If
                End If
            End With
        '@情報取得処理**************************************************(失敗した場合は,終了)

        '@取得情報表示処理**************************************************
            '@画面表示処理ﾌﾗｸﾞを立てる
            mblnScreenDispFlag = True
            
            'ｽﾛｯﾄﾏｯﾌﾟの初期化
            Call prvvsfSlotMap_init()

            'ﾊﾟﾗﾒｰﾀ項目一覧の初期化
            Call prvvsfCollect_Init()
            
            'ﾊﾟﾗﾒｰﾀ入力用一覧の初期化
            Call prvvsfCollectValue_Init()
            
            '@ｽﾛｯﾄMAPの画面表示処理
            Call prvVsfSlotMap_Disp()
                
            '@ﾊﾟﾗﾒｰﾀ項目の画面表示処理
            Call prvvsfCollect_Disp()
            
            '@入力ﾊﾟﾗﾒｰﾀ情報のﾀｲﾄﾙ設定
            Call prvvsfCollectValue_Set(CMlngOne)
            
            '@入力ﾊﾟﾗﾒｰﾀ情報の取得値設定
            Call prvvsfCollectValue_Disp(ltypwfCollectionInfo, CMlngOne)
            
            '@ﾊﾟﾗﾒｰﾀ項目の色設定
            'Call prvvsfCollect_Color()
            
            '@ﾊﾟﾗﾒｰﾀ項目一覧で取得した装置ﾃﾞｰﾀのﾊﾟﾗﾒｰﾀ行を選択状態にする
            If mtypLotCollectParamsList.llngLotCollectParamsCnt <> 0 Then
                vsfCollect.Row = CMlngOne
            End If
            

        ''@運用障害№434対応：測定ﾓｰﾄﾞ=ｵﾝﾗｲﾝの場合は、ﾃﾞｰﾀ行を表示しない
        '    '@装置ﾃﾞｰﾀ(ｵﾝﾗｲﾝ)の場合にはﾀｲﾄﾙのみ表示
        '    If vsfCollect.Cell(flexcpText, vsfCollect.Row, CMlngvsfCollectMeasureMode) = CMstrOne Then
        '
        '        '@表示行の設定
        '        llngDispRow = mtypLotCollectParamsList.llngLotCollectParamsCnt
        '
        '        '@ﾊﾟﾗﾒｰﾀﾀｲﾄﾙ設定
        '        Call prvvsfCollectValue_Set(llngDispRow)
        '
        '    End If

            
            '@ﾊﾟﾗﾒｰﾀ項目/入力項目等をﾓｼﾞｭｰﾙ変数へｾｯﾄ
            Call prvParameterInfo_Set(lstrWFID)
            
            '@ﾊﾟﾗﾒｰﾀ入力ﾃﾞｰﾀをﾓｼﾞｭｰﾙ変数へｾｯﾄ
            Call prvParameterInputData_Set(lstrParameterID)
            
            'NSYS 代入用一時格納変数
            Dim typParameterTmp As Parameter = mtypDataCollect.typParameter(CMlngZero)
            '@入力ﾊﾟﾗﾒｰﾀ情報が取得できた場合
            If ltypwfCollectionInfo.lngWfCollectionInfoListCnt = 0 Then
                '@測定ﾓｰﾄﾞによるﾌﾗｸﾞ変更
                If vsfCollect.GetData(CMlngOne, CMlngvsfCollectMeasureMode) = CMstrOne Then
                    '@ｵﾝﾗｲﾝの場合
                    typParameterTmp.strInputDataFlag = CMstrFour
                    mtypDataCollect.typParameter(CMlngZero) = typParameterTmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrFour)
                Else
                    '@新規読込
                    typParameterTmp.strInputDataFlag = CMstrZero
                    mtypDataCollect.typParameter(CMlngZero) = typParameterTmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrZero)
                    
                    '@引継情報構造体から引継げる情報を検索する
                    lblnAns = prvCollectNextInfo_Disp(lstrParameterID)
                    If lblnAns = True Then
                        '@ﾌﾗｸﾞを立てる(引継情報)
                        typParameterTmp.strInputDataFlag = CMstrThree
                        mtypDataCollect.typParameter(CMlngZero) = typParameterTmp
                        vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrThree)
                    End If
                End If
                    
                '@画面情報を構造体に格納する
                Call prvParameterInputData_Set(lstrParameterID)
                
                '@確定ﾎﾞﾀﾝの活性化処理
                Call prvcmdRegistEnabled_Chk()
            Else
                '@測定ﾓｰﾄﾞによるﾌﾗｸﾞ変更
                If vsfCollect.GetData(CMlngOne, CMlngvsfCollectMeasureMode) = CMstrOne Then
                    '@ｵﾝﾗｲﾝの場合
                    typParameterTmp.strInputDataFlag = CMstrFour
                    mtypDataCollect.typParameter(CMlngZero) = typParameterTmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrFour)
                
                    '@画面情報を構造体に格納する
                    Call prvParameterInputData_Set(lstrParameterID)
                
                    '@確定ﾎﾞﾀﾝの活性化処理
                    Call prvcmdRegistEnabled_Chk()
                Else
                    '@読込済ﾌﾗｸﾞを立てる
                    typParameterTmp.strInputDataFlag = CMstrOne
                    mtypDataCollect.typParameter(CMlngZero) = typParameterTmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrOne)
                End If
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            '@画面表示処理ﾌﾗｸﾞを解除
            mblnScreenDispFlag = False

            '@情報取得ｺﾝﾄﾛｰﾙ名(ｷｬﾘｱ/ﾛｯﾄ)にNullを格納
            mstrInfoGetControlName = vbNullString

            '@編集ﾌﾗｸﾞを初期化
            mblnEditFlag = False
            
            '@WF単位でWFが存在しない場合
            If optDataUnit2.Checked = True Then
                
                '@WFｽﾛｯﾄﾏｯﾌﾟは有効か
                If vsfSlotMap.Enabled = False Then
                    '@ﾊﾟﾗｰﾒｰﾀ値入力不可
                    Dim newStyle As CellStyle = vsfCollectValue.Styles.Add("CustomStyle_BackColor_CMlngNotInputColor")
                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngNotInputColor)
                    Dim cellRange As CellRange = vsfCollectValue.GetCellRange(CMlngOne, CMlngvsfCollectValueNoC, _
                                     vsfCollectValue.Rows.Count - 1, CMlngvsfCollectValueDataC)
                    cellRange.Style = newStyle       '薄い灰色
                    vsfCollectValue.Enabled = False
                End If
            Else
                vsfCollectValue.Enabled = True
            End If

            '@前頁、次頁ｽｸﾛｰﾙﾎﾞﾀﾝ表示設定
            If vsfCollect.Rows.Count > CMvsfCollectVisibleRows Then
                    
                If vsfCollect.Row < 5 Then
                    cmdVsfUpCollect.Enabled = False
                    cmdVsfDownCollect.Enabled = True
                Else
                    cmdVsfUpCollect.Enabled = True
                    cmdVsfDownCollect.Enabled = True
                End If
            Else
                cmdVsfUpCollect.Enabled = False
                cmdVsfDownCollect.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optDataUnit_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱIDChange処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 11:33:37 S.Deguchi
    '更新日：2005/01/24 (Mon) 11:33:37
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change
        
        Try
            
            '@情報取得ｺﾝﾄﾛｰﾙがｷｬﾘｱIDではない場合(処理終了)
            If mstrInfoGetControlName <> CMstrInfoGetControlNameCarrier Then
                Exit Sub
            End If
            
            '@画面の初期化
            Call prvfrmxxCM00G0_Init()
            
            'NSYS 全Gridの無効化
            vsfSlotMap.Enabled = False
            vsfCollect.Enabled = False
            vsfCollectValue.Enabled = False

        Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_GotFocus
    '機　能：ｷｬﾘｱIDGotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 14:15:04 S.Deguchi
    '更新日：2005/01/25 (Tue) 14:15:04
    '備　考：
    Private Sub txtCarrier_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Enter

        Try

            '@情報取得ｺﾝﾄﾛｰﾙ設定
            mstrInfoGetControlName = CMstrInfoGetControlNameCarrier
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱIDValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 11:40:38 S.Deguchi
    '更新日：2007/01/29 (Mon) 13:20:14 N.Kojima
    '備　考：
    '　　　：2005/02/16 (Wed) 10:29:41 N.Kojima     収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀの取得処理追加
    '　　　：2005/02/17 (Thu) 10:36:16 S.Deguchi    Lot単位ﾊﾟﾗﾒｰﾀ有無判別ﾌﾗｸﾞ判定処理追加
    '　　　：2005/06/21 (Tue) 15:44:37 N.Kojima     ｺﾒﾝﾄ行の削除(収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀの取得処理,Lot単位ﾊﾟﾗﾒｰﾀ有無判別ﾌﾗｸﾞ判定処理部)
    '　　　：2005/06/24 (Fri) 12:35:14 N.Kojima     運用障害対応(№434)
    '　　　：2007/01/29 (Mon) 13:20:14 N.Kojima     WF単位が選択された場合は、WF_IDをｾｯﾄして収集ﾊﾟﾗﾒｰﾀ取得を行なう。
    '　　　：                                       Lot単位が選択された場合は、WF_IDにNULLをｾｯﾄする。(案件№01428)
    Private Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim ltypEqstate                 As Eqstate                  '装置状態取得構造体
        Dim ltypwfCollectionInfo        As WfCollectionInfo         '装置ﾃﾞｰﾀ取得構造体
        Dim ltypSpcCollectionInfo       As CollectionInfoRequest    '装置ﾃﾞｰﾀ要求構造体
        Dim lblnAns                     As Boolean                  '結果取得(True:正常,False:異常)
        Dim lstrFormName                As String                   'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String                   'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngCnt                     As Integer                  'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lstrLotID                   As String                   'ﾛｯﾄID(ﾛｰｶﾙ変数置換)
        Dim lstrParameterID             As String                   'ﾊﾟﾗﾒｰﾀID(ﾛｰｶﾙ変数置換)
        Dim lstrParameterVer            As String                   'ﾊﾟﾗﾒｰﾀVer(ﾛｰｶﾙ変数置換)
        Dim llngDispRow                 As Integer                  '表示行
        Dim lstrWFID                    As String                   'WFID(ﾀﾞﾐｰ)
        Dim llngCollectIndex            As Integer                  '引継情報

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@初期化
            llngCnt = 0
            lstrLotID = vbNullString
            lstrParameterID = vbNullString
            lstrParameterVer = vbNullString
            llngDispRow = 0
            lstrWFID = vbNullString
            llngCollectIndex = 0
            
            '@ﾌｫｰﾑ起動区分判定(単独起動の場合)
            If mblnFormStartKbn = False Then
                '@ｷｬﾘｱIDの空白ﾁｪｯｸ
                If Trim(txtCarrier.Text) = vbNullString Then
                    If ActiveControl.Name = txtCarrier.Name Then
                        '@ﾛｯﾄID欄へｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(txtLot)
                    End If
                    Exit Sub
                End If
                '@ｷｬﾘｱIDの桁ﾁｪｯｸ
                If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                    '@"キャリアIDは6桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    e.Cancel = True
                    Exit Sub
                End If
            End If
                
            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If Trim(txtCarrier.Text) = vbNullString Or txtCarrier.Text = mstrTaihiCarrierID Then
                If ActiveControl.Name = txtCarrier.Name Then
                    '@ﾛｯﾄID欄へｾｯﾄﾌｫｰｶｽ
                    If txtLot.Enabled = True Then
                        Call pubSetFocus(txtLot)
                    Else
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                
                '@処理しない
                Exit Sub
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "txtCarrier_Validate"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@画面の初期化
            'Call prvfrmxxCM00G0_Init()
            
            '@WF情報構造体の初期化
            If mtypWaferList.typWfList Is Nothing Then
                mtypWaferList.typWfList = New List(Of WFList)
            Else
                mtypWaferList.typWfList.Clear()
            End If
            mtypWaferList.lngListCnt = 0
            mtypWaferList.strCurrentPositionName = vbNullString
            mtypWaferList.strWfCarryFlag = vbNullString
            mtypWaferList.strSlotSize = vbNullString
            
            '@ﾓｼﾞｭｰﾙ構造体を初期化
            If mtypLotCollectParamsList.typLotCollectParams Is Nothing Then
                mtypLotCollectParamsList.typLotCollectParams = New List(Of LotCollectParams)
            Else
                mtypLotCollectParamsList.typLotCollectParams.Clear()
            End If
            mtypLotCollectParamsList.llngLotCollectParamsCnt = 0
            mtypLotCollectParamsList.strCategoryID = vbNullString
            mtypLotCollectParamsList.strLotDataCollCompFlag = vbNullString

        '@情報取得処理**************************************************(失敗した場合は,終了)
            '@ﾛｯﾄ情報の取得
            lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                            CPstrCD1F, _
                                            txtCarrier.Text, _
                                            ptypLotprestate)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                e.Cancel = True
                Exit Sub
            End If

            '@装置IDが空ではない場合,装置状態の取得(運用ﾓｰﾄﾞの取得)
            If ptypLotprestate.strWpID <> vbNullString Then
                lblnAns = pubblnEqState_Sel(CMstreq__state___Ver, _
                                            ptypLotprestate.strWpID, _
                                            ltypEqstate)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    Exit Sub
                End If
            End If

            With ptypLotprestate
                '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀの取得(WF単位) →　ﾗｼﾞｵﾎﾞﾀﾝ制御の為
                lblnAns = pubblnLotCollectParams_Sel(CMstrlot_collectparamsVer, _
                                                     .strLotID, _
                                                     .strOpID, _
                                                     .strStepID, _
                                                     CMstrTwo, _
                                                     vbNullString, _
                                                     mtypLotCollectParamsList)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)

                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    Exit Sub
                End If

                '@WF単位ﾊﾟﾗﾒｰﾀﾘｽﾄｶｳﾝﾄを判定
                If mtypLotCollectParamsList.llngLotCollectParamsCnt = 0 Then
                    '@WF単位ﾊﾟﾗﾒｰﾀ有無判定ﾌﾗｸﾞをtrueに
                    mblnWFParamNothingFlag = True
                End If
            End With
            
            '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀの取得(Lot単位)
            With ptypLotprestate
                lblnAns = pubblnLotCollectParams_Sel(CMstrlot_collectparamsVer, _
                                                     .strLotID, _
                                                     .strOpID, _
                                                     .strStepID, _
                                                     CMstrOne, _
                                                     vbNullString, _
                                                     mtypLotCollectParamsList)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    Exit Sub
                End If
            End With
            
            '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀ情報(Lot単位)が取得できなかった場合
            If mtypLotCollectParamsList.llngLotCollectParamsCnt = 0 Then
                '@Lot単位ﾊﾟﾗﾒｰﾀ有無判定ﾌﾗｸﾞをTrueに
                mblnLotParamNothingFlag = True

                '@WF情報の取得
                lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                                 txtCarrier.Text, _
                                                 CPstrCD0T, _
                                                 mtypWaferList)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)

                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    Exit Sub
                Else
                    '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀの取得(WF単位)
                    With ptypLotprestate
                    
                        lblnAns = pubblnLotCollectParams_Sel(CMstrlot_collectparamsVer, _
                                                                 .strLotID, _
                                                                 .strOpID, _
                                                                 .strStepID, _
                                                                 CMstrTwo, _
                                                                 vsfSlotMap.GetData(vsfSlotMap.Row, CMlngvsfSlotMapWfIdC), _
                                                                 mtypLotCollectParamsList)

                        '@結果判定
                        If lblnAns = False Then
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)

                            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                            e.Cancel = True
                            Exit Sub
                        End If
                    End With
                End If
            End If
            
            '@ﾊﾟﾗﾒｰﾀ入力情報の取得
            With mtypLotCollectParamsList
                '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀ情報が取得できた場合
                If .llngLotCollectParamsCnt > 0 Then
                    '@最初の1件目のﾊﾟﾗﾒｰﾀ入力情報を取得しに行く
                    '@ﾛｰｶﾙ変数へ置換
                    lstrLotID = ptypLotprestate.strLotID
                    lstrParameterID = .typLotCollectParams(CMlngZero).strParameterID
                    lstrParameterVer = .typLotCollectParams(CMlngZero).strParameterVersion
                            
                    '@要求構造体にｾｯﾄ
                    With ltypSpcCollectionInfo
                        .strMsgVer = CMstrspc_collectioninfoVer         'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                        .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strLotID = lstrLotID                           'ﾛｯﾄID
                        .strParameterID = lstrParameterID               'ﾊﾟﾗﾒｰﾀID
                        .strParameterVersion = lstrParameterVer         'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
                        
                        '@ﾌﾗｸﾞ判定により表示する装置ﾃﾞｰﾀのWFIDを渡す
                        If mblnLotParamNothingFlag = True Then
                            .strWfId = mtypWaferList.typWfList(CMlngZero).strWfId
                        Else
                            .strWfId = vbNullString
                        End If
                    End With
                        
                    '@装置ﾃﾞｰﾀ情報の取得
                    lblnAns = pubblnSpcCollectionInfo_Sel(ltypSpcCollectionInfo, _
                                                          ltypwfCollectionInfo)
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                        e.Cancel = True
                        Exit Sub
                    End If
                    
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004Y)
                    '@"<TRM4YW>$$収集項目パラメータが設定されていないため、$装置データ登録／参照を行うことができません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If
            End With
        '@情報取得処理**************************************************(失敗した場合は,終了)
            
        '@取得情報表示処理**************************************************
            '@画面表示処理ﾌﾗｸﾞを立てる
            mblnScreenDispFlag = True
            
            '@ﾛｯﾄ情報の画面表示処理
            Call prvfrmxxCM00G0_Disp(ltypEqstate)
                
            '@ｽﾛｯﾄMAPの画面表示処理
            Call prvVsfSlotMap_Disp()
                    
            '@Lot単位ﾊﾟﾗﾒｰﾀ有無判定ﾌﾗｸﾞがTrueの場合
            If mblnLotParamNothingFlag = True Then
                '@選択WFIDを格納
                lstrWFID = vsfSlotMap.GetData(vsfSlotMap.Row, CMlngvsfSlotMapWfIdC)
            End If
                
            '@ﾊﾟﾗﾒｰﾀ項目の画面表示処理
            Call prvvsfCollect_Disp()
            
            '@入力ﾊﾟﾗﾒｰﾀ情報のﾀｲﾄﾙ設定(1件目をｾｯﾄする)
            Call prvvsfCollectValue_Set(CMlngOne)
            
            '@入力ﾊﾟﾗﾒｰﾀ情報の表示処理を行う
            Call prvvsfCollectValue_Disp(ltypwfCollectionInfo, CMlngOne)
            
            '@ﾊﾟﾗﾒｰﾀ項目の色設定
            'Call prvvsfCollect_Color()

            '@ﾊﾟﾗﾒｰﾀ項目一覧で取得した装置ﾃﾞｰﾀのﾊﾟﾗﾒｰﾀ行を選択状態にする
            If mtypLotCollectParamsList.llngLotCollectParamsCnt <> 0 Then
                '@先頭行を選択状態とする
                vsfCollect.Row = CMlngOne
            End If
            
        ''@運用障害№434対応：測定ﾓｰﾄﾞ=ｵﾝﾗｲﾝの場合は、ﾃﾞｰﾀ行を表示しない
        '    '@装置ﾃﾞｰﾀ(ｵﾝﾗｲﾝ)の場合にはﾀｲﾄﾙのみ表示
        '    If vsfCollect.Cell(flexcpText, vsfCollect.Row, CMlngvsfCollectMeasureMode) = CMstrOne Then
        '
        '        '@表示行の設定
        '        llngDispRow = mtypLotCollectParamsList.llngLotCollectParamsCnt
        '
        '        '@ﾊﾟﾗﾒｰﾀﾀｲﾄﾙ設定
        '        Call prvvsfCollectValue_Set(llngDispRow)
        '
        '    End If
            
            '@ｷｬﾘｱID,ﾛｯﾄIDの退避
            mstrTaihiCarrierID = txtCarrier.Text
            mstrTaihiLotID = txtLot.Text
                
            '@ﾊﾟﾗﾒｰﾀ項目/入力項目等をﾓｼﾞｭｰﾙ変数へｾｯﾄ
            Call prvParameterInfo_Set(lstrWFID)
            
            '@ﾊﾟﾗﾒｰﾀ入力ﾃﾞｰﾀをﾓｼﾞｭｰﾙ変数へｾｯﾄ
            Call prvParameterInputData_Set(lstrParameterID)
            
            'NSYS 代入用格納変数
            Dim typParametertmp As Parameter = mtypDataCollect.typParameter(CMlngZero)

            '@入力ﾊﾟﾗﾒｰﾀ情報が取得できた場合
            If ltypwfCollectionInfo.lngWfCollectionInfoListCnt = 0 Then
                '@測定ﾓｰﾄﾞによるﾌﾗｸﾞ変更
                If vsfCollect.GetData(CMlngOne, CMlngvsfCollectMeasureMode) = CMstrOne Then
                    '@ｵﾝﾗｲﾝの場合
                    typParametertmp.strInputDataFlag = CMstrFour
                    mtypDataCollect.typParameter(CMlngZero) = typParametertmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrFour)
                Else
                    '@新規読込
                    typParametertmp.strInputDataFlag = CMstrZero
                    mtypDataCollect.typParameter(CMlngZero) = typParametertmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrZero)
                        
                    '@引継情報構造体から引継げる情報を検索する
                    lblnAns = prvCollectNextInfo_Disp(lstrParameterID)
                    If lblnAns = True Then
                        '@ﾌﾗｸﾞを立てる(引継情報)
                        typParametertmp.strInputDataFlag = CMstrThree
                        mtypDataCollect.typParameter(CMlngZero) = typParametertmp
                        vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrThree)
                    End If
                End If
                    
                '@画面情報を構造体に格納する
                Call prvParameterInputData_Set(lstrParameterID)
                
                '@確定ﾎﾞﾀﾝの活性化処理
                Call prvcmdRegistEnabled_Chk()
            Else
                '@測定ﾓｰﾄﾞによるﾌﾗｸﾞ変更
                If vsfCollect.GetData(CMlngOne, CMlngvsfCollectMeasureMode) = CMstrOne Then
                    '@ｵﾝﾗｲﾝの場合
                    typParametertmp.strInputDataFlag = CMstrFour
                    mtypDataCollect.typParameter(CMlngZero) = typParametertmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrFour)
                
                    '@画面情報を構造体に格納する
                    Call prvParameterInputData_Set(lstrParameterID)
                
                    '@確定ﾎﾞﾀﾝの活性化処理
                    Call prvcmdRegistEnabled_Chk()
                Else
                    '@読込済ﾌﾗｸﾞを立てる
                    typParametertmp.strInputDataFlag = CMstrOne
                    mtypDataCollect.typParameter(CMlngZero) = typParametertmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrOne)
                End If
            End If
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
                
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            '@画面表示処理ﾌﾗｸﾞを解除
            mblnScreenDispFlag = False

            '@編集ﾌﾗｸﾞを初期化
            mblnEditFlag = False

            'ﾌｫｰｶｽ処理("ﾛｯﾄ単位"にﾌｫｰｶｽｾｯﾄ)
            If mblnTakeOverDispFlg = True Then
                If ActiveControl.Name = txtCarrier.Name Then
                    If optDataUnit1.Enabled = True Then
                        Call pubSetFocus(optDataUnit1)
                    Else
                        '@閉じるへﾌｫｰｶｽｾｯﾄ
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

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLot_Change
    '機　能：ﾛｯﾄIDChange処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 13:30:15 S.Deguchi
    '更新日：2005/01/24 (Mon) 13:30:15
    '備　考：
    Private Sub txtLot_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLot.Change

        Try
            
            '@情報取得ｺﾝﾄﾛｰﾙ名(ｷｬﾘｱ/ﾛｯﾄ)がﾛｯﾄIDではない場合(処理終了)
            If mstrInfoGetControlName <> CMstrInfoGetControlNameLot Then
                Exit Sub
            End If
            
            '@画面の初期化
            Call prvfrmxxCM00G0_Init()

            'NSYS 全Gridの無効化
            vsfSlotMap.Enabled = False
            vsfCollect.Enabled = False
            vsfCollectValue.Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLot_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLot_GotFocus
    '機　能ﾛｯﾄIDGotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 14:16:11 S.Deguchi
    '更新日：2005/01/25 (Tue) 14:16:11
    '備　考：
    Private Sub txtLot_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtLot.Enter

        Try

            '@情報取得ｺﾝﾄﾛｰﾙ設定
            mstrInfoGetControlName = CMstrInfoGetControlNameLot

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLot_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLot_Validate
    '機　能：ﾛｯﾄIDValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 13:30:17 S.Deguchi
    '更新日：2007/01/29 (Mon) 13:20:14 N.Kojima
    '備　考：
    '　　　：2005/02/16 (Wed) 17:26:06 N.Kojima     収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀの取得処理、Lot単位ﾊﾟﾗﾒｰﾀ有無判定処理追加
    '　　　：2005/06/21 (Tue) 15:51:44 N.Kojima     ｺﾒﾝﾄ行の削除(収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀの取得処理、Lot単位ﾊﾟﾗﾒｰﾀ有無判定処理部)
    '　　　：2005/06/24 (Fri) 12:35:49 N.Kojima     運用障害対応(№434)
    '　　　：2006/01/18 (Wed) 14:28:40 T.Kitagawa   不具合№3376対応(ﾛｯﾄID指定の場合、登録済の装置データが参照できない)
    '　　　：2007/01/29 (Mon) 13:20:14 N.Kojima     WF単位が選択された場合は、WF_IDをｾｯﾄして収集ﾊﾟﾗﾒｰﾀ取得を行なう。
    '　　　：                                       Lot単位が選択された場合は、WF_IDにNULLをｾｯﾄする。(案件№01428)
    Private Sub txtLot_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtLot.Validating

        Dim ltypEqstate                 As Eqstate                  '装置状態取得構造体
        Dim ltypwfCollectionInfo        As WfCollectionInfo         '装置ﾃﾞｰﾀ取得構造体
        Dim ltypSpcCollectionInfo       As CollectionInfoRequest    '装置ﾃﾞｰﾀ要求構造体
        Dim lblnAns                     As Boolean                  '結果取得(True:正常,False:異常)
        Dim lstrFormName                As String                   'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String                   'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngCnt                     As Integer                  'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lstrLotID                   As String                   'ﾛｯﾄID
        Dim lstrParameterID             As String                   'ﾊﾟﾗﾒｰﾀID(ﾛｰｶﾙ変数置換)
        Dim lstrParameterVer            As String                   'ﾊﾟﾗﾒｰﾀVer(ﾛｰｶﾙ変数置換)
        Dim llngDispRow                 As Integer                  '表示行
        Dim lstrWFID                    As String                   'WFID(ﾀﾞﾐｰ)
        Dim llngCollectIndex            As Integer                  '引継情報

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@初期化
            llngCnt = 0
            lstrLotID = vbNullString
            lstrParameterID = vbNullString
            lstrParameterVer = vbNullString
            llngDispRow = 0
            lstrWFID = vbNullString
            llngCollectIndex = 0

            '@ﾌｫｰﾑ起動区分判定
            If mblnFormStartKbn = False Then
                '@ﾛｯﾄIDの空白ﾁｪｯｸ
                If Trim(txtLot.Text) = vbNullString Then
                    If ActiveControl.Name = txtLot.Name Then
                        '@閉じるへｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmdClose)
                    End If
                    Exit Sub
                End If
                '@ﾛｯﾄIDの桁ﾁｪｯｸ
                If txtLot.NowByte < txtLot.ChrMaxByte Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                    '@"ロットIDは10桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    e.Cancel = True
                    Exit Sub
                End If
                
            End If

            '@ﾛｯﾄID情報の取得(入力ﾛｯﾄIDと前回のﾛｯﾄID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If Trim(txtLot.Text) = vbNullString Or txtLot.Text = mstrTaihiLotID Then
                If ActiveControl.Name = txtLot.Name Then
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    If optDataUnit1.Enabled = True Then
                        Call pubSetFocus(optDataUnit1)
                    Else
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                
                '@処理しない
                Exit Sub
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "txtLot_Validate"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@画面の初期化
            'Call prvfrmxxCM00G0_Init()
            
            '@WF情報構造体の初期化
            If mtypWaferList.typWfList Is Nothing Then
                mtypWaferList.typWfList = New List(Of WfList)
            Else
                mtypWaferList.typWfList.Clear()
            End If
            mtypWaferList.lngListCnt = 0
            mtypWaferList.strCurrentPositionName = vbNullString
            mtypWaferList.strWfCarryFlag = vbNullString
            mtypWaferList.strSlotSize = vbNullString
            
            '@ﾓｼﾞｭｰﾙ構造体を初期化
            If mtypLotCollectParamsList.typLotCollectParams Is Nothing Then
                mtypLotCollectParamsList.typLotCollectParams = New List(Of LotCollectParams)
            Else
                mtypLotCollectParamsList.typLotCollectParams.Clear()
            End If
            mtypLotCollectParamsList.llngLotCollectParamsCnt = 0
            mtypLotCollectParamsList.strCategoryID = vbNullString
            mtypLotCollectParamsList.strLotDataCollCompFlag = vbNullString
            
        '@情報取得処理**************************************************(失敗した場合は,終了)
            '@ﾛｯﾄ情報の取得
            lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                            CPstrCD1F, _
                                            vbNullString, _
                                            ptypLotprestate, _
                                            txtLot.Text)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                e.Cancel = True
                
                Exit Sub
            End If

            '@装置IDが空ではない場合,装置状態の取得(運用ﾓｰﾄﾞの取得)
            If ptypLotprestate.strWpID <> vbNullString Then
                lblnAns = pubblnEqState_Sel(CMstreq__state___Ver, _
                                            ptypLotprestate.strWpID, _
                                            ltypEqstate)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    
                    Exit Sub
                End If
            End If
            
            With ptypLotprestate
                '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀの取得(WF単位) →　ﾗｼﾞｵﾎﾞﾀﾝ制御の為
                lblnAns = pubblnLotCollectParams_Sel(CMstrlot_collectparamsVer, _
                                                     .strLotID, _
                                                     .strOpID, _
                                                     .strStepID, _
                                                     CMstrTwo, _
                                                     vsfSlotMap.GetData(vsfSlotMap.Row, CMlngvsfSlotMapWfIdC), _
                                                     mtypLotCollectParamsList)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)

                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    Exit Sub
                End If

                '@WF単位ﾊﾟﾗﾒｰﾀﾘｽﾄｶｳﾝﾄを判定
                If mtypLotCollectParamsList.llngLotCollectParamsCnt = 0 Then
                    '@WF単位ﾊﾟﾗﾒｰﾀ有無判定ﾌﾗｸﾞをtrueに
                    mblnWFParamNothingFlag = True
                End If
            End With
            
            '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀの取得(Lot単位)
            With ptypLotprestate
                lblnAns = pubblnLotCollectParams_Sel(CMstrlot_collectparamsVer, _
                                                         .strLotID, _
                                                         .strOpID, _
                                                         .strStepID, _
                                                         CMstrOne, _
                                                         vbNullString, _
                                                         mtypLotCollectParamsList)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    
                    Exit Sub
                End If
            End With
            
            '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀ情報(Lot単位)が取得できなかった場合
            If mtypLotCollectParamsList.llngLotCollectParamsCnt = 0 Then
                '@Lot単位ﾊﾟﾗﾒｰﾀ有無判定ﾌﾗｸﾞをTrueに
                mblnLotParamNothingFlag = True
                
                '@ｷｬﾘｱIDｾｯﾄ
                txtCarrier.Text = ptypLotprestate.strCarrierId
                
                '@WF情報の取得
                lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                                 txtCarrier.Text, _
                                                 CPstrCD0T, _
                                                 mtypWaferList)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)

                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    Exit Sub
                Else
                    '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀの取得(WF単位)
                    With ptypLotprestate
                        lblnAns = pubblnLotCollectParams_Sel(CMstrlot_collectparamsVer, _
                                                                 .strLotID, _
                                                                 .strOpID, _
                                                                 .strStepID, _
                                                                 CMstrTwo, _
                                                                 vsfSlotMap.GetData(vsfSlotMap.Row, CMlngvsfSlotMapWfIdC), _
                                                                 mtypLotCollectParamsList)
                        '@結果判定
                        If lblnAns = False Then
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)

                            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                            e.Cancel = True
                            Exit Sub
                        End If
                    End With
                End If
            End If
            
            '@ﾊﾟﾗﾒｰﾀ入力情報の取得
            With mtypLotCollectParamsList
                '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀ情報が取得できた場合
                If .llngLotCollectParamsCnt > 0 Then
                    '@最初の1件目のﾊﾟﾗﾒｰﾀ入力情報を取得しに行く
                    '@ﾛｰｶﾙ変数へ置換
                    lstrLotID = ptypLotprestate.strLotID
                    lstrParameterID = .typLotCollectParams(CMlngZero).strParameterID
                    lstrParameterVer = .typLotCollectParams(CMlngZero).strParameterVersion
                            
                    '@要求構造体にｾｯﾄ
                    With ltypSpcCollectionInfo
                        .strMsgVer = CMstrspc_collectioninfoVer         'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                        .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strLotID = lstrLotID                           'ﾛｯﾄID
                        .strParameterID = lstrParameterID               'ﾊﾟﾗﾒｰﾀID
                        .strParameterVersion = lstrParameterVer         'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ

                        '@ﾌﾗｸﾞ判定により表示する装置ﾃﾞｰﾀのWFIDを渡す
                        If mblnLotParamNothingFlag = True Then
                            .strWfId = mtypWaferList.typWfList(CMlngZero).strWfId
                        Else
                            .strWfId = vbNullString
                        End If
                    End With
                    
                    '@装置ﾃﾞｰﾀ情報の取得
                    lblnAns = pubblnSpcCollectionInfo_Sel(ltypSpcCollectionInfo, _
                                                          ltypwfCollectionInfo)
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                        e.Cancel = True
                        
                        Exit Sub
                    End If
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004Y)
                    '@"<TRM4YW>$$収集項目パラメータが設定されていないため、$装置データ登録／参照を行うことができません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If
                
            End With
        '@情報取得処理**************************************************(失敗した場合は,終了)
            
        '@取得情報表示処理**************************************************
            '@画面表示処理ﾌﾗｸﾞを立てる
            mblnScreenDispFlag = True
            
            '@ﾛｯﾄ情報の画面表示処理
            Call prvfrmxxCM00G0_Disp(ltypEqstate)
                
            '@ｽﾛｯﾄMAPの画面表示処理
            Call prvVsfSlotMap_Disp()
                    
            '@Lot単位ﾊﾟﾗﾒｰﾀ有無判定ﾌﾗｸﾞがTrueの場合
            If mblnLotParamNothingFlag = True Then
                '@選択WFIDを格納
                lstrWFID = vsfSlotMap.GetData(vsfSlotMap.Row, CMlngvsfSlotMapWfIdC)
            End If
                
            '@ﾊﾟﾗﾒｰﾀ項目の画面表示処理
            Call prvvsfCollect_Disp()
            
            '@入力ﾊﾟﾗﾒｰﾀ情報のﾀｲﾄﾙ設定(1件目をｾｯﾄする)
            Call prvvsfCollectValue_Set(CMlngOne)
            
            '@入力ﾊﾟﾗﾒｰﾀ情報の表示処理を行う
            Call prvvsfCollectValue_Disp(ltypwfCollectionInfo, CMlngOne)
            
            '@ﾊﾟﾗﾒｰﾀ項目の色設定
            'Call prvvsfCollect_Color()

            '@ﾊﾟﾗﾒｰﾀ項目一覧で取得した装置ﾃﾞｰﾀのﾊﾟﾗﾒｰﾀ行を選択状態にする
            If mtypLotCollectParamsList.llngLotCollectParamsCnt <> 0 Then
                '@先頭行を選択状態とする
                vsfCollect.Row = CMlngOne
            End If
            
        ''@運用障害№434対応：測定ﾓｰﾄﾞ=ｵﾝﾗｲﾝの場合は、ﾃﾞｰﾀ行を表示しない
        '    '@装置ﾃﾞｰﾀ(ｵﾝﾗｲﾝ)の場合にはﾀｲﾄﾙのみ表示
        '    If vsfCollect.Cell(flexcpText, vsfCollect.Row, CMlngvsfCollectMeasureMode) = CMstrOne Then
        '
        '        '@表示行の設定
        '        llngDispRow = mtypLotCollectParamsList.llngLotCollectParamsCnt
        '
        '        '@ﾊﾟﾗﾒｰﾀﾀｲﾄﾙ設定
        '        Call prvvsfCollectValue_Set(llngDispRow)
        '
        '    End If
            
            '@ｷｬﾘｱID,ﾛｯﾄIDの退避
            mstrTaihiCarrierID = txtCarrier.Text
            mstrTaihiLotID = txtLot.Text
                
            '@ﾊﾟﾗﾒｰﾀ項目/入力項目等をﾓｼﾞｭｰﾙ変数へｾｯﾄ
            Call prvParameterInfo_Set(lstrWFID)
            
            '@ﾊﾟﾗﾒｰﾀ入力ﾃﾞｰﾀをﾓｼﾞｭｰﾙ変数へｾｯﾄ
            Call prvParameterInputData_Set(lstrParameterID)
            
            'NSYS 代入用格納変数
            Dim typParametertmp As Parameter = mtypDataCollect.typParameter(CMlngZero)

            '@入力ﾊﾟﾗﾒｰﾀ情報が取得できた場合
            If ltypwfCollectionInfo.lngWfCollectionInfoListCnt = 0 Then
                '@測定ﾓｰﾄﾞによるﾌﾗｸﾞ変更
                If vsfCollect.GetData(CMlngOne, CMlngvsfCollectMeasureMode) = CMstrOne Then
                    '@ｵﾝﾗｲﾝの場合
                    typParametertmp.strInputDataFlag = CMstrFour
                    mtypDataCollect.typParameter(CMlngZero) = typParametertmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrFour)
                Else
                    '@新規読込
                    typParametertmp.strInputDataFlag = CMstrZero
                    mtypDataCollect.typParameter(CMlngZero) = typParametertmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrZero)
                        
                    '@引継情報構造体から引継げる情報を検索する
                    lblnAns = prvCollectNextInfo_Disp(lstrParameterID)
                    If lblnAns = True Then
                        '@ﾌﾗｸﾞを立てる(引継情報)
                        typParametertmp.strInputDataFlag = CMstrThree
                        mtypDataCollect.typParameter(CMlngZero) = typParametertmp
                        vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrThree)
                    End If
                End If
                    
                '@画面情報を構造体に格納する
                Call prvParameterInputData_Set(lstrParameterID)
                
                '@確定ﾎﾞﾀﾝの活性化処理
                Call prvcmdRegistEnabled_Chk()
            Else
                '@測定ﾓｰﾄﾞによるﾌﾗｸﾞ変更
                If vsfCollect.GetData(CMlngOne, CMlngvsfCollectMeasureMode) = CMstrOne Then
                    '@ｵﾝﾗｲﾝの場合
                    typParametertmp.strInputDataFlag = CMstrFour
                    mtypDataCollect.typParameter(CMlngZero) = typParametertmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrFour)
                
                    '@画面情報を構造体に格納する
                    Call prvParameterInputData_Set(lstrParameterID)
                
                    '@確定ﾎﾞﾀﾝの活性化処理
                    Call prvcmdRegistEnabled_Chk()
                Else
                    '@読込済ﾌﾗｸﾞを立てる
                    typParametertmp.strInputDataFlag = CMstrOne
                    mtypDataCollect.typParameter(CMlngZero) = typParametertmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrOne)
                End If
            End If
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
                
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            '@画面表示処理ﾌﾗｸﾞを解除
            mblnScreenDispFlag = False

            '@編集ﾌﾗｸﾞを初期化
            mblnEditFlag = False

            'ﾌｫｰｶｽ処理("ﾛｯﾄ単位"にﾌｫｰｶｽｾｯﾄ)
            If optDataUnit1.Enabled = True Then
                'NSYS ActiveControlが自分の場合
                If ActiveControl.Name = txtLot.Name Then
                    Call pubSetFocus(optDataUnit1)
                End If
            Else
                'NSYS ActiveControlが自分の場合
                If ActiveControl.Name = txtLot.Name Then
                    '@閉じるへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLot_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap_BeforeRowColChange
    '機　能：ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞのｶﾚﾝﾄ行変更(変更前)
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 12:36:02 S.Deguchi
    '更新日：2005/01/25 (Tue) 12:36:02
    '備　考：
    Private Sub vsfSlotMap_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfSlotMap.BeforeRowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap.Rows.Count <= vsfSlotMap.Rows.Fixed Then
                Return
            End If
            
            '@列の値を退避
            mstrNewCol = e.NewRange.c1
            mstrOldCol = e.OldRange.c2
            mstrNewRow = e.NewRange.r1
            mstrOldRow = e.OldRange.r2
            
            '@同じ行で列が違う場合は列を同じにする
            If e.NewRange.r1 = e.OldRange.r2 And e.NewRange.c1 <> e.OldRange.c2 Then
                mstrNewCol = mstrOldCol
            End If

            '@読み込み判定
            If e.NewRange.r1 < 1 Or e.OldRange.r2 < 1 Or e.NewRange.r1 = e.OldRange.r2 Or vsfCollect.Row < 1 Then
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap_EnterCell
    '機　能：ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞのﾌｫｰｶｽ移動
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 12:37:54 S.Deguchi
    '更新日：2007/01/29 (Mon) 13:28:24 N.Kojima
    '備　考：
    '　　　：2005/02/16 (Wed) 18:17:43 N.Kojima     ﾎﾞﾀﾝの有効無効制御追加。
    '　　　：2005/06/21 (Tue) 15:54:53 N.Kojima     ｺﾒﾝﾄ行の削除(ﾎﾞﾀﾝの有効無効制御部)
    '　　　：2005/06/24 (Fri) 12:36:28 N.Kojima     運用障害対応(№434)、「編集中～」のMsg表示判定追加。
    '　　　：2007/01/29 (Mon) 13:28:24 N.Kojima     WF単位が選択された場合は、WF_IDをｾｯﾄして収集ﾊﾟﾗﾒｰﾀ取得を行なう。
    '　　　：                                       Lot単位が選択された場合は、WF_IDにNULLをｾｯﾄする。(案件№01428)
    Private Sub vsfSlotMap_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap.EnterCell

        Dim ltypwfCollectionInfo        As WfCollectionInfo         '装置ﾃﾞｰﾀ取得構造体
        Dim ltypSpcCollectionInfo       As CollectionInfoRequest    '装置ﾃﾞｰﾀ要求構造体
        Dim llngAns                     As Integer                  '結果取得
        Dim lblnAns                     As Boolean                  '結果取得(True:正常,False:異常)
        Dim lstrFormName                As String                   'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String                   'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrLotID                   As String                   'ﾛｯﾄID(ﾛｰｶﾙ変数置換)
        Dim lstrParameterID             As String                   'ﾊﾟﾗﾒｰﾀID(ﾛｰｶﾙ変数置換)
        Dim lstrParameterVer            As String                   'ﾊﾟﾗﾒｰﾀVer(ﾛｰｶﾙ変数置換)
        Dim lstrWFID                    As String                   'WFID(ﾛｰｶﾙ変数置換)
        Dim llngDispRow                 As Integer                  '表示行
        Dim lstrLotWFSelectFlag         As String                   'ﾛｯﾄ/WF切替えﾌﾗｸﾞ
        Dim llngCollectIndex            As Integer                  '引継情報

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap.Rows.Count <= vsfSlotMap.Rows.Fixed Then
                Return
            End If
            
            '@読み込み判定
            With vsfSlotMap
                If .Row < 1 Then
                    Exit Sub
                End If
            End With
            
            '@初期化
            lstrLotID = vbNullString
            lstrParameterID = vbNullString
            lstrParameterVer = vbNullString
            lstrWFID = vbNullString
            llngDispRow = 0
            llngCollectIndex = 0
            
            '@起動時には処理しない
            If pblnFormLoad = False Then
                Exit Sub
            End If
            
            '@画面表示処理ﾌﾗｸﾞ判定
            If mblnScreenDispFlag = True Then
                Exit Sub
            End If
            
            '@編集中判定(編集ﾌﾗｸﾞから判断)
            If mblnEditFlag = True Then
                '@同じ列行の場合には処理抜け
                If mstrNewCol = mstrOldCol And mstrNewRow = mstrOldRow Then
                    Exit Sub
                End If
                
                '@WFｽﾛｯﾄﾏｯﾌﾟにﾃﾞｰﾀが存在するか
                If vsfSlotMap.GetData(CInt(mstrOldRow), CMlngvsfSlotMapWfIdC) <> vbNullString Then
                '@WF情報無し

                    'NSYS メッセージ表示中は新行を選択状態にするためGridをRefresh
                    vsfSlotMap.Refresh

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                    
                    '@"編集中です。 内容を破棄してよろしいですか？"
                    llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                    '@要求確認
                    If llngAns = vbNo Then
                        '@画面表示処理ﾌﾗｸﾞ判定
                        mblnScreenDispFlag = True
                        
                        '@旧行へﾌｫｰｶｽｾｯﾄ
                        vsfSlotMap.Select(mstrOldRow, mstrOldCol)
                        
                        '@画面表示処理ﾌﾗｸﾞ判定
                        mblnScreenDispFlag = False
                        
                        '@装置ﾃﾞｰﾀﾘｽﾄが有効な場合
                        If vsfCollectValue.Enabled = True Then
                            '@装置ﾃﾞｰﾀﾘｽﾄにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfCollectValue)
                        End If
                        
                        Exit Sub
                    End If
                End If
            End If

            '@ｽﾛｯﾄﾏｯﾌﾟでWFIDがない行が選択された場合
            With vsfSlotMap
                If .GetData(.Row, CMlngvsfSlotMapWfIdC) = vbNullString Then
                    '@ﾊﾟﾗﾒｰﾀ項目一覧の初期化
                    Call prvvsfCollect_Init()
                    
                    '@ﾊﾟﾗﾒｰﾀ入力用一覧の初期化
                    Call prvvsfCollectValue_Init()
                    
                    '@各種ﾎﾞﾀﾝ無効に
                    cmdRegist.Enabled = False
                    cmdNaInput.Enabled = False
                    cmdLineDelete.Enabled = False
                    cmdLineInsert.Enabled = False
                    
                    'NSYS Gridを無効化
                    vsfCollect.Enabled = False
                    vsfCollectValue.Enabled = False

                    Exit Sub
                End If
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "vsfSlotMap_EnterCell"
            Call pubResponseStart(lstrFormName, lstrEventName)
                
            '@ﾛｰｶﾙ変数へ置換
            lstrLotID = txtLot.Text                                                         'ﾛｯﾄID
            lstrLotWFSelectFlag = CMstrTwo                                                  '切替えﾌﾗｸﾞ(=WF)
            With vsfSlotMap
                lstrWFID = .GetData(.Row, CMlngvsfSlotMapWfIdC)                    'WFID
            End With
                
        '@情報取得処理**************************************************(失敗した場合は,終了)
            '@ﾓｼﾞｭｰﾙ構造体を初期化
            If mtypLotCollectParamsList.typLotCollectParams Is Nothing Then
                mtypLotCollectParamsList.typLotCollectParams = New List(Of LotCollectParams)
            Else
                mtypLotCollectParamsList.typLotCollectParams.Clear()
            End If
            mtypLotCollectParamsList.llngLotCollectParamsCnt = 0
            mtypLotCollectParamsList.strCategoryID = vbNullString
            mtypLotCollectParamsList.strLotDataCollCompFlag = vbNullString
            
            
            With ptypLotprestate
            
                '@収集ﾃﾞｰﾀﾊﾟﾗﾒｰﾀの取得(WF単位)
                lblnAns = pubblnLotCollectParams_Sel(CMstrlot_collectparamsVer, _
                                                         .strLotID, _
                                                         .strOpID, _
                                                         .strStepID, _
                                                         lstrLotWFSelectFlag, _
                                                         vsfSlotMap.GetData(vsfSlotMap.Row, CMlngvsfSlotMapWfIdC), _
                                                         mtypLotCollectParamsList)
                                                         
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@入力情報一覧へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfCollectValue)
                    
                    Exit Sub
                Else
                    '@ﾊﾟﾗﾒｰﾀ項目の画面表示処理
                    Call prvvsfCollect_Disp()
                    
                    '@ﾊﾟﾗﾒｰﾀ情報をﾛｰｶﾙ変数へｾｯﾄ
                    With vsfCollect
                        lstrParameterID = .GetData(CMlngOne, CMlngvsfCollectParaIdC)       'ﾊﾟﾗﾒｰﾀID
                        lstrParameterVer = .GetData(CMlngOne, CMlngvsfCollectParaVerC)     'ﾊﾟﾗﾒｰﾀVer
                    End With
                End If
            End With
            
            '@要求構造体にｾｯﾄ
            With ltypSpcCollectionInfo
                .strMsgVer = CMstrspc_collectioninfoVer         'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strLotID = lstrLotID                           'ﾛｯﾄID
                .strParameterID = lstrParameterID               'ﾊﾟﾗﾒｰﾀID
                .strParameterVersion = lstrParameterVer         'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
                .strWfId = lstrWFID                             'WFID
            End With

            '@装置ﾃﾞｰﾀ情報の取得
            lblnAns = pubblnSpcCollectionInfo_Sel(ltypSpcCollectionInfo, ltypwfCollectionInfo)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@装置ﾃﾞｰﾀﾘｽﾄにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfCollectValue)
                
                Exit Sub
            End If
        '@情報取得処理**************************************************(失敗した場合は,終了)
            
        '@取得情報表示処理**************************************************
            '@画面表示処理ﾌﾗｸﾞを立てる
            mblnScreenDispFlag = True
            
            '@ﾊﾟﾗﾒｰﾀ項目一覧の初期化
            Call prvvsfCollect_Init()
            
            '@ﾊﾟﾗﾒｰﾀ入力用一覧の初期化
            Call prvvsfCollectValue_Init()
            
            '@ﾊﾟﾗﾒｰﾀ項目の画面表示処理
            Call prvvsfCollect_Disp()
            
            '@入力ﾊﾟﾗﾒｰﾀ情報のﾀｲﾄﾙ設定
            Call prvvsfCollectValue_Set(CMlngOne)
            
            '@入力ﾊﾟﾗﾒｰﾀ情報の取得値設定
            Call prvvsfCollectValue_Disp(ltypwfCollectionInfo, CMlngOne)
            
            '@ﾊﾟﾗﾒｰﾀ項目の色設定
            Call prvvsfCollect_Color()
            
            '@ﾊﾟﾗﾒｰﾀ項目一覧で取得した装置ﾃﾞｰﾀのﾊﾟﾗﾒｰﾀ行を選択状態にする
            If mtypLotCollectParamsList.llngLotCollectParamsCnt <> 0 Then
                '@先頭行を選択状態とする
                vsfCollect.Row = CMlngOne
            End If
            
        ''@運用障害№434対応：測定ﾓｰﾄﾞ=ｵﾝﾗｲﾝの場合は、ﾃﾞｰﾀ行を表示しない
        '    '@装置ﾃﾞｰﾀ(ｵﾝﾗｲﾝ)の場合にはﾀｲﾄﾙのみ表示
        '    If vsfCollect.Cell(flexcpText, vsfCollect.Row, CMlngvsfCollectMeasureMode) = CMstrOne Then
        '
        '        '@表示行の設定
        '        llngDispRow = mtypLotCollectParamsList.llngLotCollectParamsCnt
        '
        '        '@ﾊﾟﾗﾒｰﾀﾀｲﾄﾙ設定
        '        Call prvvsfCollectValue_Set(llngDispRow)
        '
        '    End If
            
            '@ｷｬﾘｱID,ﾛｯﾄIDの退避
            mstrTaihiCarrierID = txtCarrier.Text
            mstrTaihiLotID = txtLot.Text
                
            '@ﾊﾟﾗﾒｰﾀ項目/入力項目等をﾓｼﾞｭｰﾙ変数へｾｯﾄ
            Call prvParameterInfo_Set(lstrWFID)
            
            '@ﾊﾟﾗﾒｰﾀ入力ﾃﾞｰﾀをﾓｼﾞｭｰﾙ変数へｾｯﾄ
            Call prvParameterInputData_Set(lstrParameterID)
            
            'NSYS 代入用格納変数
            Dim typParametertmp As Parameter = mtypDataCollect.typParameter(CMlngZero)

            '@入力ﾊﾟﾗﾒｰﾀ情報が取得できた場合
            If ltypwfCollectionInfo.lngWfCollectionInfoListCnt = 0 Then
                '@測定ﾓｰﾄﾞによるﾌﾗｸﾞ変更
                If vsfCollect.GetData(CMlngOne, CMlngvsfCollectMeasureMode) = CMstrOne Then
                    '@ｵﾝﾗｲﾝの場合
                    typParametertmp.strInputDataFlag = CMstrFour
                    mtypDataCollect.typParameter(CMlngZero) = typParametertmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrFour)
                Else
                    '@新規読込
                    typParametertmp.strInputDataFlag = CMstrZero
                    mtypDataCollect.typParameter(CMlngZero) = typParametertmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrZero)
                End If
                
                '@引継情報構造体から引継げる情報を検索する
                lblnAns = prvCollectNextInfo_Disp(lstrParameterID)
                If lblnAns = True Then
                    '@ﾌﾗｸﾞを立てる(引継情報)
                    typParametertmp.strInputDataFlag = CMstrThree
                    mtypDataCollect.typParameter(CMlngZero) = typParametertmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrThree)
                End If
                    
                '@画面情報を構造体に格納する
                Call prvParameterInputData_Set(lstrParameterID)
                
            Else
                '@測定ﾓｰﾄﾞによるﾌﾗｸﾞ変更
                If vsfCollect.GetData(CMlngOne, CMlngvsfCollectMeasureMode) = CMstrOne Then
                    '@ｵﾝﾗｲﾝの場合
                    typParametertmp.strInputDataFlag = CMstrFour
                    mtypDataCollect.typParameter(CMlngZero) = typParametertmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrFour)
                
                    '@画面情報を構造体に格納する
                    Call prvParameterInputData_Set(lstrParameterID)
                
                    '@確定ﾎﾞﾀﾝの活性化処理
                    Call prvcmdRegistEnabled_Chk()
                Else
                    '@読込済ﾌﾗｸﾞを立てる
                    typParametertmp.strInputDataFlag = CMstrOne
                    mtypDataCollect.typParameter(CMlngZero) = typParametertmp
                    vsfCollect.SetData(CMlngOne, CMlngvsfCollectParameterLoad, CMstrOne)
                End If
            End If
            
            '@画面表示処理ﾌﾗｸﾞを解除
            mblnScreenDispFlag = False
            
            '@編集ﾌﾗｸﾞを初期化
            mblnEditFlag = False
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCollect_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 13:17:39 S.Deguchi
    '更新日：2005/01/25 (Tue) 13:17:39
    '備　考：
    Private Sub vsfCollect_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfCollect.AfterSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfCollect.Rows.Count <= vsfCollect.Rows.Fixed Then
                Return
            End If
            
            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列[№]、前頁、次頁)
            Call pubVsfAfterSort(vsfCollect, CMlngvsfCollectNoC)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCollect_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCollect_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 13:17:43 S.Deguchi
    '更新日：2005/01/25 (Tue) 13:17:43
    '備　考：
    Private Sub vsfCollect_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfCollect.BeforeSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfCollect.Rows.Count <= vsfCollect.Rows.Fixed Then
                Return
            End If
            
            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列[№])
            Call pubVsfBeforeSort(vsfCollect, CMlngvsfCollectNoC)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCollect_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCollect_BeforeRowColChange
    '機　能：装置収集項目ｸﾞﾘｯﾄﾞのｶﾚﾝﾄ行変更(変更前)
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 13:17:45 S.Deguchi
    '更新日：2005/01/25 (Tue) 13:17:45
    '備　考：
    Private Sub vsfCollect_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfCollect.BeforeRowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfCollect.Rows.Count <= vsfCollect.Rows.Fixed Then
                Return
            End If

            '@読み込み判定
            If e.NewRange.r1 < 1 Or e.OldRange.r1 < 1 Or vsfCollect.Row < 1 Then
                Exit Sub
            End If
            
            '@新列と旧列が同じか
            If e.NewRange.r1 = e.OldRange.r1 Then
                '@ｷｬﾝｾﾙする
                e.Cancel = True
                Exit Sub
            End If

            '@入力した情報をﾓｼﾞｭｰﾙ構造体にｾｯﾄする
            With vsfCollect
                If .GetData(e.OldRange.r1, CMlngvsfCollectParameterLoad) <> CMstrOne Then
                    Call prvParameterInputData_Set(.GetData(e.OldRange.r1, CMlngvsfCollectParaIdC))
                    
                    If .GetData(e.OldRange.r1, CMlngvsfCollectParameterLoad) = CMstrFour Then
                        Exit Sub
                    End If
                
                    If .GetData(e.OldRange.r1, CMlngvsfCollectParameterLoad) <> CMstrThree Then
                        
                        If .GetData(e.OldRange.r1, CMlngvsfCollectParameterLoad) <> CMstrZero Then
                        
                            '@ﾌﾗｸﾞを立てる(引継情報)
                            Dim typParametertmp As Parameter = mtypDataCollect.typParameter(CLng(e.OldRange.r1) - 1)
                            typParametertmp.strInputDataFlag = CMstrTwo
                            mtypDataCollect.typParameter(CLng(e.OldRange.r1) - 1) = typParametertmp
                            .SetData(e.OldRange.r1, CMlngvsfCollectParameterLoad, CMstrTwo)
                        End If
                    End If
                End If
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCollect_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCollect_EnterCell
    '機　能：装置収集項目ｸﾞﾘｯﾄﾞのﾌｫｰｶｽ移動
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 13:17:48 S.Deguchi
    '更新日：2007/02/06 (Tue) 11:38:30 N.Kasai
    '備　考：
    '　　　：2005/05/10 (Tue) 17:27:32 N.Kojima     任意入力ﾊﾟﾗﾒｰﾀの場合は、WFｽﾛｯﾄﾏｯﾌﾟの「要」を消す。(不具合№556)
    '　　　：2005/05/31 (Tue) 09:40:23 N.Kasai      任意入力ﾊﾟﾗﾒｰﾀの場合は、WFｽﾛｯﾄﾏｯﾌﾟの「要」を消す。(不具合№798)
    '　　　：2007/02/06 (Tue) 11:38:30 N.Kasai      WF単位で装置ﾃﾞｰﾀ入力対象WFが存在しない場合は値の入力不可(№01120)
    Private Sub vsfCollect_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfCollect.EnterCell

        Dim ltypwfCollectionInfo        As WfCollectionInfo         '装置ﾃﾞｰﾀ取得構造体
        Dim ltypSpcCollectionInfo       As CollectionInfoRequest    '装置ﾃﾞｰﾀ要求構造体体
        Dim lblnAns                     As Boolean                  '結果取得(True:正常,False:異常)
        Dim lstrFormName                As String                   'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String                   'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrLotID                   As String                   'ﾛｯﾄID(ﾛｰｶﾙ変数置換)
        Dim lstrParameterID             As String                   'ﾊﾟﾗﾒｰﾀID(ﾛｰｶﾙ変数置換)
        Dim lstrParameterVer            As String                   'ﾊﾟﾗﾒｰﾀVer(ﾛｰｶﾙ変数置換)
        Dim lstrWFID                    As String                   'WFID(ﾛｰｶﾙ変数置換)
        Dim llngDispRow                 As Integer                  '表示行
        Dim lstrLotWFSelectFlag         As String                   'ﾛｯﾄ/WF切替えﾌﾗｸﾞ
        Dim llngCnt                     As Integer                  'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCollectIndex            As Integer                  '引継情報

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfCollect.Rows.Count <= vsfCollect.Rows.Fixed Then
                Return
            End If

            '@初期化
            llngCnt = 0
            lstrLotID = vbNullString
            lstrParameterID = vbNullString
            lstrParameterVer = vbNullString
            lstrWFID = vbNullString
            llngDispRow = 0
            llngCollectIndex = 0
            
            '@起動時には処理しない
            If pblnFormLoad = False Then
                Exit Sub
            End If
            
            '@画面表示処理ﾌﾗｸﾞ判定
            If mblnScreenDispFlag = True Then
                Exit Sub
            End If

            '@ﾊﾟﾗﾒｰﾀ入力情報の取得
            With vsfCollect
                '@取得するﾊﾟﾗﾒｰﾀの行を退避
                llngDispRow = .Row
                
                '@ﾛｰｶﾙ変数へ置換
                lstrLotID = txtLot.Text                                                                 'ﾛｯﾄID
                lstrParameterID = .GetData(.Row, CMlngvsfCollectParaIdC)                                'ﾊﾟﾗﾒｰﾀID
                lstrParameterVer = .GetData(.Row, CMlngvsfCollectParaVerC)                              'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
                
                '@ﾛｯﾄ/WF切替えによる処理分岐
                Select Case True
                    '@ﾛｯﾄ単位・ﾊﾞｯﾁ単位
                    Case optDataUnit1.Checked
                        lstrLotWFSelectFlag = CMstrOne                                                  '選択ﾌﾗｸﾞ
                        lstrWFID = vbNullString                                                         'WF_ID
                        
                    '@WF単位
                    Case optDataUnit2.Checked
                        lstrLotWFSelectFlag = CMstrTwo                                                  '選択ﾌﾗｸﾞ
                        lstrWFID = vsfSlotMap.GetData(vsfSlotMap.Row, CMlngvsfSlotMapWfIdC)             'WF_ID
                End Select

                '@ﾀｲﾄﾙ以外
                If .Row <> 0 Then
                    If .GetData(.Row, CMlngvsfCollectParameterLoad) = CMstrZero Or _
                        .GetData(.Row, CMlngvsfCollectParameterLoad) = CMstrFour Then
                    '@ﾃﾞｰﾀ読込ﾌﾗｸﾞが未読込/装置ﾃﾞｰﾀの場合

                        '@ﾚｽﾎﾟﾝｽ取得開始
                        lstrFormName = Me.Name
                        lstrEventName = "vsfCollect_EnterCell"
                        Call pubResponseStart(lstrFormName, lstrEventName)
                        
                       '@要求構造体にｾｯﾄ
                        With ltypSpcCollectionInfo
                            .strMsgVer = CMstrspc_collectioninfoVer         'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                            .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                            .strLotID = lstrLotID                           'ﾛｯﾄID
                            .strParameterID = lstrParameterID               'ﾊﾟﾗﾒｰﾀID
                            .strParameterVersion = lstrParameterVer         'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
                            .strWfId = lstrWFID                             'WFID
                        End With
                        
                        '@装置ﾃﾞｰﾀ情報の取得
                        lblnAns = pubblnSpcCollectionInfo_Sel(ltypSpcCollectionInfo, ltypwfCollectionInfo)
                        '@結果判定
                        If lblnAns = False Then
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)

                            '@入力情報一覧へﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfCollectValue)

                            Exit Sub
                        Else
                            '@情報をﾒｯｾｰｼﾞから取得した場合の表示処理
                            '@ﾊﾟﾗﾒｰﾀﾀｲﾄﾙ設定
                            Call prvvsfCollectValue_Set(llngDispRow)
                            
                            '@入力ﾊﾟﾗﾒｰﾀ情報の取得値設定
                            Call prvvsfCollectValue_Disp(ltypwfCollectionInfo, llngDispRow)
                            
                            '@ﾊﾟﾗﾒｰﾀ入力ﾃﾞｰﾀをﾓｼﾞｭｰﾙ変数へｾｯﾄ
                            Call prvParameterInputData_Set(lstrParameterID)
                            
                            'NSYS 代入用格納変数
                            Dim typParametertmp As Parameter = mtypDataCollect.typParameter(llngDispRow -1)

                            '@取得情報で,Inputﾃﾞｰﾀが"0"件の場合
                            If ltypwfCollectionInfo.lngWfCollectionInfoListCnt = 0 Then
                                '@装置ﾃﾞｰﾀ(ｵﾝﾗｲﾝ)の場合にはﾀｲﾄﾙのみ表示
                                If .GetData(.Row, CMlngvsfCollectMeasureMode) = CMstrOne Then
                                    '@ﾊﾟﾗﾒｰﾀﾀｲﾄﾙ設定
                                    Call prvvsfCollectValue_Set(llngDispRow)
                                    
                                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                    Call pubResponseCancel(lstrFormName, lstrEventName)
                                    
                                    '@確定ﾎﾞﾀﾝ活性化ﾁｪｯｸ
                                    Call prvcmdRegistEnabled_Chk()
                                    
                                    Exit Sub
                                End If
                                
                                '@ﾌﾗｸﾞを立てない(登録ﾃﾞｰﾀ無し)
                                typParametertmp.strInputDataFlag = CMstrZero
                                mtypDataCollect.typParameter(llngDispRow -1) = typParametertmp
                                vsfCollect.SetData(llngDispRow, CMlngvsfCollectParameterLoad, CMstrZero)
                                
                                '@引継情報構造体から引継げる情報を検索する
                                lblnAns = prvCollectNextInfo_Disp(lstrParameterID)
                                If lblnAns = True Then
                                    '@ﾌﾗｸﾞを立てる(引継情報)
                                    typParametertmp.strInputDataFlag = CMstrThree
                                    mtypDataCollect.typParameter(llngDispRow -1) = typParametertmp
                                    vsfCollect.SetData(llngDispRow, CMlngvsfCollectParameterLoad, CMstrThree)
            
                                    '@画面情報を構造体に格納する
                                    Call prvParameterInputData_Set(lstrParameterID)
                                End If
                                
                                '@確定ﾎﾞﾀﾝの活性化処理
                                Call prvcmdRegistEnabled_Chk()
                            Else
                                '@測定ﾓｰﾄﾞによるﾌﾗｸﾞ変更
                                If vsfCollect.GetData(llngDispRow, CMlngvsfCollectMeasureMode) = CMstrOne Then
                                    '@ｵﾝﾗｲﾝの場合
                                    typParametertmp.strInputDataFlag = CMstrFour
                                    mtypDataCollect.typParameter(llngDispRow -1) = typParametertmp
                                    vsfCollect.SetData(llngDispRow, CMlngvsfCollectParameterLoad, CMstrFour)
                                
                                    '@画面情報を構造体に格納する
                                    Call prvParameterInputData_Set(lstrParameterID)
                                Else
                                '@ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝ,ｵﾌﾗｲﾝの場合
                                    '@読込済ﾌﾗｸﾞを立てる
                                    typParametertmp.strInputDataFlag = CMstrOne
                                    mtypDataCollect.typParameter(llngDispRow -1) = typParametertmp
                                    vsfCollect.SetData(llngDispRow, CMlngvsfCollectParameterLoad, CMstrOne)
                                End If
                            
                                '@確定ﾎﾞﾀﾝの活性化処理
                                Call prvcmdRegistEnabled_Chk()
                            End If
                            
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(lstrFormName, lstrEventName)
                        End If
                    Else
                    '@ﾃﾞｰﾀ読込ﾌﾗｸﾞが読込済の場合
                        '@ﾓｼﾞｭｰﾙ退避領域から入力ﾃﾞｰﾀを表示させる
                        Call prvParameterInputData_Disp(lstrParameterID)
                        
                        '@表示させたﾃﾞｰﾀが存在しない(ﾀｲﾄﾙしかない)場合
                        If vsfCollectValue.Rows.Count > 1 Then
                            
                            '@確定ﾎﾞﾀﾝ活性化ﾁｪｯｸ
                            Call prvcmdRegistEnabled_Chk()
                            
                            '@5行以上あったら▼ﾎﾞﾀﾝを有効にする
                            If vsfCollectValue.Rows.Count > 5 Then
                                cmdVsfDownCollectValue.Enabled = True
                                cmdVsfUpCollectValue.Enabled = False
                            Else
                                cmdVsfDownCollectValue.Enabled = False
                                cmdVsfUpCollectValue.Enabled = False
                            
                            End If
                        Else
                        '@1行増やして空欄とする
                            '@行追加
                            vsfCollectValue.Rows.Count = CLng(.GetData(.Row, CMlngvsfCollectMandatoryCountC)) + 1
                            
                            '@入力ﾌｨｰﾙﾄﾞ作成
                            For llngCnt = 1 To vsfCollectValue.Rows.Count - 1
                                vsfCollectValue.SetData(llngCnt, CMlngvsfCollectValueNoC, llngCnt)                           '№
                            Next llngCnt
                            
                            '@ﾛｯｸ解除
                            .Enabled = True
                        End If
                    End If
                End If
                
                '@WFｽﾛｯﾄﾏｯﾌﾟは有効か
                If vsfSlotMap.Enabled = True Then
                    '@ｽﾛｯﾄﾏｯﾌﾟのWFIDが空白でない場合
                    If vsfSlotMap.GetData(vsfSlotMap.Row, CMlngvsfSlotMapWfIdC) <> vbNullString Then
                        '@ﾊﾟﾗﾒｰﾀﾘｽﾄの選択行が必須項目なしか否かで分岐
                        If .GetData(.Row, CMlngvsfCollectMandatoryCountC) = CMstrZero Then
                            '@取得ﾃﾞｰﾀが存在している場合か否かで,分岐
                            If ltypwfCollectionInfo.lngWfCollectionInfoListCnt > 0 Then
                                '@収集項目ﾀｲﾌﾟが1:作業記録の場合
                                If vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectCollectionType) = CMstrZero Then
                                    '@WFｽﾛｯﾄﾏｯﾌﾟの「入力」欄の要を消す
                                    vsfSlotMap.SetData(vsfSlotMap.Row, CMlngvsfSlotMapInputRequestC, vbNullString)
                                End If
                            End If
                        Else
                            '@ﾊﾟﾗﾒｰﾀﾘｽﾄの選択行の「入力」欄が"空白"の場合
                            If .GetData(.Row, CMlngvsfCollectInputEndFlagC) = vbNullString Then
                                
                                If .GetData(.Row, CMlngvsfCollectMandatoryCountC) <> CMstrOne Then
                                    '@WFｽﾛｯﾄﾏｯﾌﾟの「入力」欄の要を消す
                                    vsfSlotMap.SetData(vsfSlotMap.Row, CMlngvsfSlotMapInputRequestC, vbNullString)
                                End If
                            Else
                                '@WFｽﾛｯﾄﾏｯﾌﾟの「入力」欄の要を表示
                                vsfSlotMap.SetData(vsfSlotMap.Row, CMlngvsfSlotMapInputRequestC, CMstrInputRequest)
                            End If
                        End If
                    End If
                Else
                    '@WF単位でWFが存在しない場合
                    If optDataUnit2.Checked = True Then
                        Dim newStyle As CellStyle = vsfCollectValue.Styles.Add("CustomStyle_BackColor_CMlngNotInputColor")
                        newStyle.BackColor = ColorTranslator.FromWin32(CMlngNotInputColor)
                        Dim cellRange As CellRange = vsfCollectValue.GetCellRange(CMlngOne, CMlngvsfCollectValueNoC, _
                                         vsfCollectValue.Rows.Count - 1, CMlngvsfCollectValueDataC)
                        cellRange.Style = newStyle       '薄い灰色
                        vsfCollectValue.Enabled = False
                    Else
                        vsfCollectValue.Enabled = True
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCollect_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCollectValue_AfterEdit
    '機　能：装置ﾃﾞｰﾀｸﾞﾘｯﾄの変更後処理
    '引　数：Row：変更行
    '　　　：Col：変更列
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 13:31:42 S.Deguchi
    '更新日：2005/01/25 (Tue) 13:31:42
    '備　考：
    Private Sub vsfCollectValue_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfCollectValue.AfterEdit

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfCollectValue.Rows.Count <= vsfCollectValue.Rows.Fixed Then
                Return
            End If

            '@列幅の自動調整
            With vsfCollectValue
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCol(.Col, 6)
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCollectValue_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCollectValue_SetupEdit
    '機　能：装置ﾃﾞｰﾀｸﾞﾘｯﾄの変更前処理
    '引　数：Row：変更行
    '　　　：Col：変更列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 13:31:47 S.Deguchi
    '更新日：2006/12/21 (Thu) 08:38:38 N.Kasai
    '備　考：
    '　　　：2005/05/30 (Mon) 17:11:55 N.Kasai      文字ﾀｲﾌﾟを判定して表示位置を制御追加
    '　　　：2006/12/21 (Thu) 08:38:38 N.Kasai      収集項目ﾀｲﾌﾟ追加(№01515)
    '　　　：2020/05/09 (Sat) 10:00:00 NSYS         関数名をBeforeEditからSetupEditへ変更
    Private Sub vsfCollectValue_SetupEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfCollectValue.SetupEditor

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfCollectValue.Rows.Count <= vsfCollectValue.Rows.Fixed Then
                Return
            End If

            '@固定行の場合はｽｷｯﾌﾟ
            If e.Row < vsfCollectValue.Rows.Fixed Then
                e.Cancel = True
                Exit Sub
            End If
            
            '@編集項目以外はｽｷｯﾌﾟ
            Select Case e.Col
                '@ﾃﾞｰﾀ分類名1～4 or ﾃﾞｰﾀ値の場合
                Case CMlngvsfCollectValueClass1C, _
                     CMlngvsfCollectValueClass2C, _
                     CMlngvsfCollectValueClass3C, _
                     CMlngvsfCollectValueClass4C, _
                     CMlngvsfCollectValueDataC
                    '@続行
                
                Case Else
                    e.Cancel = True
                    Exit Sub
            End Select
            
            '@入力対象不可の場合はｽｷｯﾌﾟ
            With vsfCollect
                If .GetData(.Row, CMlngvsfCollectParameterLoad) = CMstrOne Or _
                   .GetData(.Row, CMlngvsfCollectParameterLoad) = CMstrFour Then
                   
                    '@収集項目ﾀｲﾌﾟが1:装置ﾃﾞｰﾀの場合
                    If .GetData(.Row, CMlngvsfCollectCollectionType) = CMstrOne Then
                        Exit Sub
                    End If
                End If
            End With

            '@最大入力文字数の設定
            With vsfCollectValue
                Select Case e.Col
                    '@ﾃﾞｰﾀ分類名
                    Case CMlngvsfCollectValueClass1C, _
                         CMlngvsfCollectValueClass2C, _
                         CMlngvsfCollectValueClass3C, _
                         CMlngvsfCollectValueClass4C
                        '@30ﾊﾞｲﾄ迄入力可能
                        CType(.Editor, TextBox).MaxLength = CMlngInputClassMaxByte
                        
                    '@ﾃﾞｰﾀ値
                    Case CMlngvsfCollectValueDataC
                        '@数字ﾃﾞｰﾀﾀｲﾌﾟか文字列ﾀｲﾌﾟか
                        If vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectDataTypeC) = CMstrDataTypeN Then
                        '@数字ﾀｲﾌﾟﾁｪｯｸの場合
                            '@35ﾊﾞｲﾄ迄入力可能
                            CType(.Editor, TextBox).MaxLength = CMlngInputNumberMaxByte
                            
                            '@数字ﾀｲﾌﾟの場合は右寄
                            .Cols(CMlngvsfCollectValueDataC).TextAlign = TextAlignEnum.RightCenter
                        Else
                        '@文字ﾀｲﾌﾟﾁｪｯｸの場合
                            '@256ﾊﾞｲﾄ迄入力可能
                            CType(.Editor, TextBox).MaxLength = CMlngInputDataMaxByte
                            
                            '@文字ﾀｲﾌﾟの場合は左寄
                            .Cols(CMlngvsfCollectValueDataC).TextAlign = TextAlignEnum.LeftCenter
                        End If
                    Case Else
                End Select
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCollectValue_SetupEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCollectValue_DblClick
    '機　能：装置ﾃﾞｰﾀｸﾞﾘｯﾄのﾀﾞﾌﾞﾙｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 13:35:28 S.Deguchi
    '更新日：2006/12/21 (Thu) 08:40:26 N.Kasai
    '備　考：
    '　　　：2005/10/28 (Fri) 09:53:35 S.Deguchi    ﾏｳｽで触っているｶﾗﾑがﾀｲﾄﾙの場合には,処理抜けするように処理追加
    '　　　：2006/12/21 (Thu) 08:40:26 N.Kasai      収集項目ﾀｲﾌﾟ追加
    Private Sub vsfCollectValue_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfCollectValue.DoubleClick

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfCollectValue.Rows.Count <= vsfCollectValue.Rows.Fixed Then
                Return
            End If

            '@ﾏｳｽで触っているｶﾗﾑがﾀｲﾄﾙの場合には,処理抜け
            If vsfCollectValue.MouseRow < 1 Then
                Exit Sub
            End If
            
            '@読込判定(ﾀｲﾄﾙは除外)
            If vsfCollectValue.Row < 1 Then
                Exit Sub
            End If

            '@入力対象不可の場合はｽｷｯﾌﾟ
            With vsfCollect
                '@ｵﾝﾗｲﾝﾃﾞｰﾀ読込,登録済みの場合は処理しない
                If .GetData(.Row, CMlngvsfCollectParameterLoad) = CMstrOne Or _
                   .GetData(.Row, CMlngvsfCollectParameterLoad) = CMstrFour Then
                   
                    '@収集項目ﾀｲﾌﾟが1:装置ﾃﾞｰﾀの場合
                    If .GetData(.Row, CMlngvsfCollectCollectionType) = CMstrOne Then
                        Exit Sub
                    End If
                Else
                    '@値未入力ｺﾏﾝﾄﾞをｺｰﾙ
                    Call cmdNAInput_Click(sender, e)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCollectValue_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCollectValue_EnterCell
    '機　能：装置ﾃﾞｰﾀｸﾞﾘｯﾄの使用可能設定
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 13:32:05 S.Deguchi
    '更新日：2008/05/02 (Fri) 13:46:55 T.Sawaguchi
    '備　考：
    '　　　：2005/10/20 (Thu) 16:36:25 S.Deguchi    不具合№2443の対応で,ｵﾝﾗｲﾝ読込時の時も処理しないようにする
    '　　　：2006/12/21 (Thu) 08:41:01 N.Kasai      収集項目ﾀｲﾌﾟ追加(№01515)
    '　　　：2008/04/04 (Fri) 16:26:14 T.Sawaguchi　ﾍﾟｰｼﾞ送りﾎﾞﾀﾝ制御追加　案件No02761　対応
    '　　　：2008/04/23 (Wed) 18:33:21 T.Sawaguchi  案件No02761でﾊﾞｸﾞを埋め込んだ為削除
    '　　　：2008/05/02 (Fri) 13:47:26 T.Sawaguchi  運用障害02853、必須の作業記録を入力しても、確定ﾎﾞﾀﾝが押せない。

    Private Sub vsfCollectValue_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfCollectValue.EnterCell

        Dim llngCnt                 As Integer  'ｶｳﾝﾀ
        Dim llngCnt2                As Integer  'ｶｳﾝﾀ2

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfCollectValue.Rows.Count <= vsfCollectValue.Rows.Fixed Then
                Return
            End If

            '@読込判定
            If vsfCollectValue.Row < 1 Then
                Exit Sub
            End If
           
           '@内部変数へ行Noをｾｯﾄする
            mstrvsfCollectValueRow = str(vsfCollectValue.Row)
            mstrvsfCollectValueRow = LTrim(RTrim(mstrvsfCollectValueRow))
            
            '@起動時には処理しない
            If pblnFormLoad = False Then
                Exit Sub
            End If

            '@画面表示処理ﾌﾗｸﾞ判定
            If mblnScreenDispFlag = True Then
                Exit Sub
            End If

            '@入力対象不可(読込済み/ｵﾝﾗｲﾝ読込)の場合はｽｷｯﾌﾟ
            '@ﾊﾟﾗﾒｰﾀ情報読込(0:未読込/1:読込済/2:入力済/3:引継ぎ情報/4:ｵﾝﾗｲﾝ)
            With vsfCollect
                If .GetData(.Row, CMlngvsfCollectParameterLoad) = CMstrOne Or _
                   .GetData(.Row, CMlngvsfCollectParameterLoad) = CMstrFour Then
                   
                    '@収集項目ﾀｲﾌﾟが1:装置ﾃﾞｰﾀの場合
                    If .GetData(.Row, CMlngvsfCollectCollectionType) = CMstrOne Then
                        '@編集を不許可
                        vsfCollectValue.AllowEditing = False
                        With vsfCollectValue
                            Select Case .GetCellRange(.Row, .Col).StyleDisplay.BackColor
                            Case ColorTranslator.FromWin32(CMlngNotInputColor)
                                .Styles.Focus.BackColor =  ColorTranslator.FromWin32(CMlngNotInputColor)
                                .Styles.Highlight.BackColor =  ColorTranslator.FromWin32(CMlngNotInputColor)
                            Case Else
                                .Styles.Focus.BackColor = Color.White
                                .Styles.Highlight.BackColor = Color.White
                            End Select
                        End With
                        Exit Sub
                    End If
                End If
            End With
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
            cmdLineInsert.Enabled = True    '行追加ﾎﾞﾀﾝ
            cmdLineDelete.Enabled = True    '行削除ﾎﾞﾀﾝ

            '@編集ﾓｰﾄﾞの設定
            With vsfCollectValue

                Select Case .Col
                    '@ﾃﾞｰﾀ分類名1～4 or ﾃﾞｰﾀ値の場合
                    Case CMlngvsfCollectValueClass1C, CMlngvsfCollectValueClass2C, _
                         CMlngvsfCollectValueClass3C, CMlngvsfCollectValueClass4C, CMlngvsfCollectValueDataC
                        '@N/A文字の場合はﾀﾞﾌﾞﾙｸﾘｯｸOK
                        If .GetData(.Row, .Col) = CMstrNaString Then
                            '@編集を許可(ﾀﾞﾌﾞﾙｸﾘｯｸ含み)
                            .AllowEditing = True
                        Else
                            '@編集を許可(ﾀﾞﾌﾞﾙｸﾘｯｸ以外)
                            .AllowEditing = True
                        End If
                        
                        '@ﾊｲﾗｲﾄ表示(初めて)
                        '.EditSelStart = 0
                        '.EditSelLength = Len(.GetData(.Row, .Col))
                        
                        '@N/Aﾎﾞﾀﾝの有効
                        cmdNaInput.Enabled = True
                        cmdLineInsert.Enabled = True
                        cmdLineDelete.Enabled = True
                        
                        '@削除ﾎﾞﾀﾝの制御
                        '@装置ﾃﾞｰﾀｸﾞﾘｯﾄﾞに入力可能行があるか
                        If .Rows.Count - 1 > 1 Then
                            '@必須入力項目数が数値か
                            If IsNumeric(vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectMandatoryCountC)) = True Then
                                '@必須入力項目数が装置ﾃﾞｰﾀｸﾞﾘｯﾄﾞの入力可能行より多いか等しいか
                                If .Rows.Count - 1 <= CLng(vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectMandatoryCountC)) Then
                                    '@行削除ﾎﾞﾀﾝ無効
                                    cmdLineDelete.Enabled = False
                                End If
                            End If
                        Else
                            '@行削除ﾎﾞﾀﾝ無効
                            cmdLineDelete.Enabled = False
                        End If
                    Case Else
                        '@編集を非許可
                        .AllowEditing = False
                        
                        '@N/Aﾎﾞﾀﾝの無効
                        cmdNaInput.Enabled = False
                        
                        '@削除ﾎﾞﾀﾝの制御
                        '@装置ﾃﾞｰﾀｸﾞﾘｯﾄﾞに入力可能行があるか
                        If .Rows.Count - 1 > 1 Then
                            '@必須入力項目数が数値か
                            If IsNumeric(vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectMandatoryCountC)) = True Then
                                '@必須入力項目数が装置ﾃﾞｰﾀｸﾞﾘｯﾄﾞの入力可能行より多いか等しいか
                                If .Rows.Count - 1 <= CLng(vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectMandatoryCountC)) Then
                                    '@行削除ﾎﾞﾀﾝ無効
                                    cmdLineDelete.Enabled = False
                                End If
                            End If
                        Else
                            '@行削除ﾎﾞﾀﾝ無効
                            cmdLineDelete.Enabled = False
                        End If
                        cmdLineInsert.Enabled = True
                End Select
            End With
            
            '@ｾﾙ色設定
            With vsfCollectValue
                For llngCnt = 1 To .Rows.Count - 1
                    For llngCnt2 = CMlngvsfCollectValueNoC To CMlngvsfCollectValueDataC
                        '@前の色がﾋﾟﾝｸの場合
                        If .GetCellRange(llngCnt, llngCnt2).StyleDisplay.BackColor = ColorTranslator.FromWin32(CMlngInputColor) Then
                            '@装置ﾃﾞｰﾀｸﾞﾘｯﾄﾞが水色(引継ぎ)か
                            If .GetCellRange(llngCnt, CMlngvsfCollectValueNoC).StyleDisplay.BackColor = ColorTranslator.FromWin32(CMlngRetainColor) Then
                                '@引継色へ
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngRetainColor" + llngCnt2.ToString)
                                newStyle.BackColor = ColorTranslator.FromWin32(CMlngRetainColor)
                                Dim cellRange As CellRange = .GetCellRange(llngCnt, llngCnt2)
                                cellRange.Style = newStyle
                            Else
                                '@選択ｾﾙを白に
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite" + llngCnt2.ToString)
                                newStyle.BackColor = Color.White
                                Dim cellRange As CellRange = .GetCellRange(llngCnt, llngCnt2)
                                cellRange.Style = newStyle
                            End If
                        End If
                    Next llngCnt2
                Next llngCnt
                'NSYS 選択セル背景色
                Select Case .GetCellRange(.Row, .Col).StyleDisplay.BackColor
                    Case ColorTranslator.FromWin32(CMlngRetainColor)
                        .Styles.Focus.BackColor = ColorTranslator.FromWin32(CMlngRetainColor)
                        .Styles.Highlight.BackColor = ColorTranslator.FromWin32(CMlngRetainColor)

                    Case Else
                        .Styles.Focus.BackColor = Color.White
                        .Styles.Highlight.BackColor = Color.White

                End Select

                '@選択ｾﾙが結果ではない、入力済みではない場合
                If .GetCellRange(.Row, .Col).StyleDisplay.BackColor <> ColorTranslator.FromWin32(CMlngNotInputColor) And _
                    .GetCellRange(.Row, .Col).StyleDisplay.BackColor <> ColorTranslator.FromWin32(CMlngOKBackColor) Then
                    '@選択ｾﾙをﾋﾟﾝｸに
                    Select Case .Col
                        Case CMlngvsfCollectValueClass1C To CMlngvsfCollectValueDataC
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngInputColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngInputColor)
                            Dim cellRange As CellRange = .GetCellRange(.Row, .Col)
                            cellRange.Style = newStyle
                            .Styles.Focus.BackColor =  ColorTranslator.FromWin32(CMlngInputColor)
                            .Styles.Highlight.BackColor = ColorTranslator.FromWin32(CMlngInputColor)
                            '@新規の入力ｾﾙへﾌｫｰｶｽを移動する
                            Call pubSetFocus(vsfCollectValue)
                    End Select
                End If
            End With

            '@入力した情報をﾓｼﾞｭｰﾙ構造体にｾｯﾄする
            With vsfCollect
                '@ﾊﾟﾗﾒｰﾀ情報が未読み込みか
                If .GetData(.Row, CMlngvsfCollectParameterLoad) <> CMstrOne And _
                   .GetData(.Row, CMlngvsfCollectParameterLoad) <> CMstrFour Then
                    
                    '@収集項目ﾀｲﾌﾟが1:装置ﾃﾞｰﾀの以外場合
                    If .GetData(.Row, CMlngvsfCollectCollectionType) <> CMstrOne Then
                    
                        '@ﾊﾟﾗﾒｰﾀ入力ﾃﾞｰﾀをﾓｼﾞｭｰﾙ変数へｾｯﾄ
                        Call prvParameterInputData_Set(.GetData(.Row, CMlngvsfCollectParaIdC))
                        
                        'NSYS 代入用格納変数
                        Dim typParametertmp As Parameter = mtypDataCollect.typParameter(.Row - 1)

                        '@必須入力項目が存在する場合
                        If .GetData(.Row, CMlngvsfCollectInputEndFlagC) <> vbNullString Then
                            '@???
                            If .GetData(.Row, CMlngvsfCollectParameterLoad) <> CMstrThree Then
                                '@ﾌﾗｸﾞを立てる(引継情報)
                                typParametertmp.strInputDataFlag = CMstrTwo
                                mtypDataCollect.typParameter(.Row - 1) = typParametertmp
                                .SetData(.Row, CMlngvsfCollectParameterLoad, CMstrTwo)
                            End If
                        
                        Else
                            
                            '@ﾌﾗｸﾞを立てる(引継情報)
                            typParametertmp.strInputDataFlag = CMstrTwo
                            mtypDataCollect.typParameter(.Row - 1) = typParametertmp
                            .SetData(.Row, CMlngvsfCollectParameterLoad, CMstrTwo)
                        End If
                    End If
                End If
            End With

            '@確定ﾎﾞﾀﾝの使用可設定
            Call prvcmdRegistEnabled_Chk()


            '@案件02761でvsfCollectValue_ValidateEditに次の行にﾌｫｰｶｽする修正をいれたが、
            '@案件02853の運用障害を発生させてしまった為、下記に入れた。

            '@入力する行をｸﾞﾘｯﾄﾞ内へ表示する。
            Call prvVsfInputControll(vsfCollectValue, 0, cmdVsfUpCollectValue, _
                                        cmdVsfDownCollectValue, vsfCollectValue.Row + 1, True, _
                                        mstrvsfCollectValueRow)

            '@ﾌｫｰｶｽを設定する
            Call pubSetFocus(vsfCollectValue)
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCollectValue_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCollectValue_KeyDown
    '機　能：装置ﾃﾞｰﾀｸﾞﾘｯﾄのKeyDown処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 10:13:26 S.Deguchi
    '更新日：2005/02/17 (Thu) 10:13:26
    '備　考：
    Private Sub vsfCollectValue_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfCollectValue.KeyDown

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfCollectValue.Rows.Count <= vsfCollectValue.Rows.Fixed Then
                Return
            End If
            
            With vsfCollectValue

                '@選択セルがﾀｲﾄﾙ行またはNo.列の場合処理をしない
                If .Row < 1 Or .Col < 1 Then
                    Exit Sub
                End If

                '@入力対象不可の場合はｽｷｯﾌﾟ
                '@ｵﾝﾗｲﾝﾃﾞｰﾀ読込,登録済みの場合は処理しない
                If vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectParameterLoad) = CMstrOne Or _
                    vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectParameterLoad) = CMstrFour Then

                    '@収集項目ﾀｲﾌﾟが1:装置ﾃﾞｰﾀの場合
                    If vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectCollectionType) = CMstrOne Then
                        Exit Sub
                    End If
                Else
                    Select Case e.KeyCode
                    
                        '@Delete/BackSpaceｷｰの場合
                        Case Keys.Delete, Keys.Back
                        
                            '@Nullにする
                            .SetData(.Row, .Col, vbNullString)
                    
                            '@編集処理
                            .StartEditing()
                            If e.KeyCode = Keys.Back AndAlso (TypeOf .Editor Is TextBox)
                                CType(.Editor, TextBox).Clear()
                            End If

                    End Select
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCollectValue_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCollectValue_KeyDownEdit
    '機　能：装置ﾃﾞｰﾀｸﾞﾘｯﾄのEnter処理
    '引　数：Row：変更行
    '　　　：Col：変更列
    '　　　：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 13:32:35 S.Deguchi
    '更新日：2008/05/03 (Sat) 07:31:35 T.Sawaguchi
    '備　考：
    '　　　：2008/05/03 (Sat) 07:27:16 T.Sawaguchi  運用障害02853、必須の作業記録を入力しても、確定ﾎﾞﾀﾝが押せない。
    Private Sub vsfCollectValue_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfCollectValue.KeyDownEdit
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfCollectValue.Rows.Count <= vsfCollectValue.Rows.Fixed Then
                Return
            End If
            
            '@Enterの場合
            Select Case e.KeyCode
                
                Case Keys.Return
                    
                    SendKeys.SendWait(CPstrSendKeysTab)

                    '@案件02853対応で、Enterｷｰを押した時に、入力ｾﾙへﾌｫｰｶｽを移動する為の判定を追加。
                    '@値列でEnterｷｰを押した時に、ﾌｫｰｶｽを1つ目の入力ｾﾙへ移動する。
                    '@その他の列の場合は右の列へ1つ移動する。
                    '@ｴﾗｰMsgの有無も一緒に判断し、ｴﾗｰの場合は移動しない。
                    
                    If e.Col = CMlngvsfCollectValueDataC Then
                        '@ｴﾗｰMsgをﾁｪｯｸし、入力ﾃﾞｰﾀ以外のMsgの場合は、ﾌｫｰｶｽを移動する。
                        If prvErrMsgCheck = True Then
                            '@次の行へﾌｫｰｶｽを移動する。
                            SendKeys.SendWait(CPstrSendKeysTab)
                        End If
                    End If
                    
                    e.Handled = True
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCollectValue_KeyDownEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCollectValue_ValidateEdit
    '機　能：装置ﾃﾞｰﾀｸﾞﾘｯﾄの変更後処理
    '引　数：Row：変更行
    '　　　：Col：変更列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 13:33:10 S.Deguchi
    '更新日：2008/04/24 (Fri) 07:27:48 T.Sawaguchi
    '備　考：
    '　　　：2005/06/21 (Tue) 16:11:51 N.Kojima     規格上・下限値ﾁｪｯｸをｺﾒﾝﾄｱｳﾄ(不具合№883)
    '　　　：2006/12/21 (Thu) 08:45:04 N.Kasai      収集項目ﾀｲﾌﾟ追加(№01515)
    '　　　：2008/04/04 (Fri) 16:28:05 T.Sawaguchi  ﾍﾟｰｼﾞ送りﾎﾞﾀﾝ制御追加　案件No02761　対応
    '　　　：2008/04/24 (Fri) 07:28:05 T.Sawaguchi  案件No02761でのDVNAMEがある時の行制御追加
    Private Sub vsfCollectValue_ValidateEdit(ByVal sender As Object, ByVal e As ValidateEditEventArgs) Handles vsfCollectValue.ValidateEdit

        Dim llngCnt             As Integer  'ｶｳﾝﾀ
        Dim llngCnt2            As Integer  'ｶｳﾝﾀ2

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfCollectValue.Rows.Count <= vsfCollectValue.Rows.Fixed Then
                Return
            End If

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@固定行の場合はｽｷｯﾌﾟ
            If e.Row < vsfCollectValue.Rows.Fixed Then
                Exit Sub
            End If
            
            '@編集項目以外はｽｷｯﾌﾟ
            Select Case e.Col
                '@ﾃﾞｰﾀ分類名1～4 or ﾃﾞｰﾀ値の場合
                Case CMlngvsfCollectValueClass1C, _
                     CMlngvsfCollectValueClass2C, _
                     CMlngvsfCollectValueClass3C, _
                     CMlngvsfCollectValueClass4C, _
                     CMlngvsfCollectValueDataC
                    '@続行
                
                Case Else
                '@その他
                    '@ｽｷｯﾌﾟ
                    Exit Sub
            End Select
            
            '@入力対象不可の場合はｽｷｯﾌﾟ
            With vsfCollect
                If .GetData(.Row, CMlngvsfCollectParameterLoad) = CMstrOne Or _
                   .GetData(.Row, CMlngvsfCollectParameterLoad) = CMstrFour Then
                   
                    '@収集項目ﾀｲﾌﾟが1:装置ﾃﾞｰﾀの場合
                    If .GetData(.Row, CMlngvsfCollectCollectionType) = CMstrOne Then
                        Exit Sub
                    End If
                End If
            End With
            
            '@変数初期化
            mstrvsfCollectValueRow = vbNullString
            
            '@入力ﾁｪｯｸ
            With vsfCollectValue
                '@列の判定
                Select Case e.Col
                    Case CMlngvsfCollectValueClass1C, _
                         CMlngvsfCollectValueClass2C, _
                         CMlngvsfCollectValueClass3C, _
                         CMlngvsfCollectValueClass4C, _
                         CMlngvsfCollectValueDataC
                         
                        '@入力ﾌｨｰﾙﾄﾞの編集後判定
                        For llngCnt = 1 To Len(.Editor.Text)
                            Select Case Mid(.Editor.Text, llngCnt, 1)
                                Case CMstrNoInputString
                                    '@禁則文字："'"
                                    e.Cancel = True
                                    
                                    Exit For
                                Case Else
                                    '@禁則文字以外
                            End Select
                        Next llngCnt
                        
                        If e.Cancel = False Then
                            .Editor.Text = .Editor.Text
                        Else
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004V, CMstrNoInputString)
                            '@"文字[%1]は入力できません。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            'NSYS エラー値入力前の値に戻す
                            .Editor.Text = vsfCollectValue(e.Row,e.Col)

                            e.Cancel = True
                            Exit Sub
                        End If
                End Select
                
                Dim editorTextAllByte As Integer = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(.Editor.Text)
                Select Case e.Col
                    '@ﾃﾞｰﾀ分類名1～4
                    Case CMlngvsfCollectValueClass1C, _
                         CMlngvsfCollectValueClass2C, _
                         CMlngvsfCollectValueClass3C, _
                         CMlngvsfCollectValueClass4C
            
                        '@文字数ﾁｪｯｸ
                        If editorTextAllByte > CMlngInputClassMaxByte Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001E, CMlngInputClassMaxByte)
                            '@"入力は%1ﾊﾞｲﾄまでです。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            'NSYS エラー値入力前の値に戻す
                            .Editor.Text = vsfCollectValue(e.Row,e.Col)

                            e.Cancel = True
                            Exit Sub
                        End If
                        
                    '@ﾃﾞｰﾀ値
                    Case CMlngvsfCollectValueDataC
                        '@数字ﾃﾞｰﾀﾀｲﾌﾟか
                        If vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectDataTypeC) = CMstrDataTypeN Then
                        '@数字ﾀｲﾌﾟﾁｪｯｸの場合
                            '@数字ﾀｲﾌﾟの場合は右寄
                            .Cols(e.Col).TextAlign = TextAlignEnum.RightCenter
                            
                            '@文字数ﾁｪｯｸ
                            If editorTextAllByte > CMlngInputNumberMaxByte Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001E, CMlngInputNumberMaxByte)
                                '@"入力は[%1]ﾊﾞｲﾄまでです。設定を見直してください。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                'NSYS エラー値入力前の値に戻す
                                .Editor.Text = vsfCollectValue(e.Row,e.Col)

                                e.Cancel = True
                                Exit Sub
                            End If
                            
                            '@"N/A"以外の場合は数字ﾁｪｯｸ
                            If .Editor.Text <> CMstrNaString And .Editor.Text <> vbNullString Then
                                '@数字型ﾁｪｯｸ
                                If IsNumeric(.Editor.Text) = False Then
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001F)
                                    '@"数字を入力してください。"
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    
                                    'NSYS エラー値入力前の値に戻す
                                    .Editor.Text = vsfCollectValue(e.Row,e.Col)

                                    e.Cancel = True
                                    Exit Sub
                                Else
                                    For llngCnt2 = 1 To Len(.Editor.Text)
                                        Dim editorTextMidByte As Integer = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(Mid(.Editor.Text, llngCnt2, 1))
                                        If editorTextMidByte >= 2 Then
                                            '@表示ﾒｯｾｰｼﾞ変換
                                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001F)
                                            '@"数字を入力してください。"
                                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                            
                                            'NSYS エラー値入力前の値に戻す
                                            .Editor.Text = vsfCollectValue(e.Row,e.Col)

                                            e.Cancel = True
                                            Exit Sub
                                        End If
                                    Next llngCnt2
                                End If
                            End If
                        Else
                        '@文字ﾀｲﾌﾟﾁｪｯｸの場合
                            '@文字数ﾁｪｯｸ
                            If editorTextAllByte > CMlngInputDataMaxByte Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001E, CMlngInputDataMaxByte)
                                '@"入力は%1ﾊﾞｲﾄまでです。設定を見直してください。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                'NSYS エラー値入力前の値に戻す
                                .Editor.Text = vsfCollectValue(e.Row,e.Col)

                                e.Cancel = True
                                Exit Sub
                            End If
                        End If
                        
                        '@列幅の自動調整
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCols(CMlngGridRowCol_0, .Cols.Count - 1, 6)
                        mstrvsfCollectValueRow = str(.Rows.Count - 1)
                        mstrvsfCollectValueRow = LTrim(RTrim(mstrvsfCollectValueRow))
                End Select
            End With
            
            '@設定を有効にする
            e.Cancel = False
            
            With vsfCollect
                '@ﾌﾗｸﾞを立てる(引継情報)
                Dim typParametertmp As Parameter = mtypDataCollect.typParameter(.Row - 1)
                typParametertmp.strInputDataFlag = CMstrTwo
                mtypDataCollect.typParameter(.Row - 1) = typParametertmp
                .SetData(.Row, CMlngvsfCollectParameterLoad, CMstrTwo)
            End With
            
            '@編集中ﾌﾗｸﾞを立てる
            mblnEditFlag = True

            '@行追加
            With vsfCollectValue
                '@常に1行分の余裕を確保
                If .Row >= .Rows.Count - 1 Then
                    '@最終行へ追加する
                    .Rows.Count = .Rows.Count + 1
                    
                    '@DVNAMEがある場合は、入力行を保持する。
                    Select Case e.Col
                    '@ﾃﾞｰﾀ分類名1～4
                        Case CMlngvsfCollectValueClass1C, _
                             CMlngvsfCollectValueClass2C, _
                             CMlngvsfCollectValueClass3C, _
                             CMlngvsfCollectValueClass4C
                                '@内部変数へ現在行をｾｯﾄ
                                mstrvsfCollectValueRow = str(.Rows.Count - 2)  ' 1→2
                                mstrvsfCollectValueRow = LTrim(RTrim(mstrvsfCollectValueRow))
                    
                    
                        Case Else
                                '@内部変数へ次の行をｾｯﾄ　但しここにはこないはず
                                mstrvsfCollectValueRow = str(.Rows.Count - 1)
                                mstrvsfCollectValueRow = LTrim(RTrim(mstrvsfCollectValueRow))
                    
                    End Select
                    
                    '@値位置の設定
                    If vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectDataTypeC) = CMstrDataTypeN Then
                        '@数字ﾀｲﾌﾟの場合は右寄
                        .Cols(CMlngvsfCollectValueDataC).TextAlign = TextAlignEnum.RightCenter
                    Else
                        '@文字ﾀｲﾌﾟの場合は左寄
                        .Cols(CMlngvsfCollectValueDataC).TextAlign = TextAlignEnum.LeftCenter
                    End If
                    
                    '@高さ設定
                    .Rows(.Rows.Count - 1).Height = CMlngvsfRowHeight  'CMlngGridRowHeight→CMlngvsfRowHeightへ変更
                    
                    '@行番号の採番
                    For llngCnt = 1 To .Rows.Count - 1
                        '@行番号格納
                        .SetData(llngCnt, CMlngvsfCollectValueNoC, llngCnt)
                    Next llngCnt
                Else
                    '@内部変数へｾｯﾄ
                    mstrvsfCollectValueRow = str(.Row)
                    mstrvsfCollectValueRow = LTrim(RTrim(mstrvsfCollectValueRow))
                End If
            End With
                
            '@ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ、前頁、次頁)
            Call pubVsfCmdUp(vsfCollectValue, cmdVsfUpCollectValue, cmdVsfDownCollectValue)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCollectValue_ValidateEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCollectValue_Validate
    '機　能：装置ﾃﾞｰﾀValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 17:55:09 S.Deguchi
    '更新日：2006/12/21 (Thu) 08:47:15 N.Kasai
    '備　考：
    '　　　：2006/12/21 (Thu) 08:47:15 N.Kasai      収集項目追加(№01515)
    Private Sub vsfCollectValue_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles vsfCollectValue.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfCollect.Rows.Count <= vsfCollect.Rows.Fixed Then
                Return
            End If

            '@入力した情報をﾓｼﾞｭｰﾙ構造体にｾｯﾄする
            With vsfCollect
                If .GetData(.Row, CMlngvsfCollectParameterLoad) <> CMstrOne And _
                   .GetData(.Row, CMlngvsfCollectParameterLoad) <> CMstrFour Then
                   
                     '@収集項目ﾀｲﾌﾟが1:装置ﾃﾞｰﾀ以外の場合
                    If .GetData(.Row, CMlngvsfCollectCollectionType) <> CMstrOne Then
                        
                        '@ｸﾞﾘｯﾄﾞﾃﾞｰﾀを構造体へ反映させる
                        Call prvParameterInputData_Set(.GetData(.Row, CMlngvsfCollectParaIdC))
            
                        If .GetData(.Row, CMlngvsfCollectParameterLoad) <> CMstrThree Then
                            '@ﾌﾗｸﾞを立てる(引継情報)
                            Dim typParametertmp As Parameter = mtypDataCollect.typParameter(.Row - 1)
                            typParametertmp.strInputDataFlag = CMstrTwo
                            mtypDataCollect.typParameter(.Row - 1) = typParametertmp
                            .SetData(.Row, CMlngvsfCollectParameterLoad, CMstrTwo)
                        End If
                    End If
                End If
            End With
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCollectValue_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '******************************************************************************************
    '                                       *関数の記述*
    '******************************************************************************************
    '=========================================Private==========================================
    '関数名：prvfrmxxCM00G0_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 10:50:58 S.Deguchi
    '更新日：2005/06/21 (Tue) 16:17:33 N.Kojima
    '備　考：
    '　　　：2005/02/16 (Wed) 18:18:20 N.Kojima     Lot/WF単位ﾊﾟﾗﾒｰﾀ有無判定ﾌﾗｸﾞの初期化。
    '　　　：2005/06/21 (Tue) 16:17:33 N.Kojima     ｺﾒﾝﾄ行の削除(初期化処理部)
    Private Sub prvfrmxxCM00G0_Init()

        Dim lstrFormTitle           As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00T0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@ﾛｯﾄ情報取得時のｷｬﾘｱID、ﾛｯﾄID退避情報を初期化
            mstrTaihiCarrierID = vbNullString
            mstrTaihiLotID = vbNullString
            
            '@最終更新日時情報の初期化
            mstrLotLastUpdate = vbNullString
            
            '@編集ﾌﾗｸﾞの初期化
            mblnEditFlag = False
            
            '@Lot単位ﾊﾟﾗﾒｰﾀ有無判定ﾌﾗｸﾞの初期化
            mblnLotParamNothingFlag = False
            
            '@WF単位ﾊﾟﾗﾒｰﾀ有無判定ﾌﾗｸﾞの初期化
            mblnWFParamNothingFlag = False
            
            '@WF情報構造体の初期化
            If mtypWaferList.typWfList Is Nothing Then
                mtypWaferList.typWfList = New List(Of WfList)
            Else
                mtypWaferList.typWfList.Clear()
            End If
            mtypWaferList.lngListCnt = 0
            mtypWaferList.strCurrentPositionName = vbNullString
            mtypWaferList.strWfCarryFlag = vbNullString
            mtypWaferList.strSlotSize = vbNullString
            
            '@ﾓｼﾞｭｰﾙ構造体を初期化
            If mtypLotCollectParamsList.typLotCollectParams Is Nothing Then
                mtypLotCollectParamsList.typLotCollectParams = New List(Of LotCollectParams)
            Else
                mtypLotCollectParamsList.typLotCollectParams.Clear()
            End If
            mtypLotCollectParamsList.llngLotCollectParamsCnt = 0
            mtypLotCollectParamsList.strCategoryID = vbNullString
            mtypLotCollectParamsList.strLotDataCollCompFlag = vbNullString
            
            '@各ﾎﾞﾀﾝの初期化
            cmdLineInsert.Enabled = False                               '行追加ﾎﾞﾀﾝ
            cmdLineDelete.Enabled = False                               '行削除ﾎﾞﾀﾝ
            cmdNaInput.Enabled = False                                  '値未入力ﾎﾞﾀﾝ
            cmdRegist.Enabled = False                                   '確定ﾎﾞﾀﾝ

            '@各ｺﾝﾄﾛｰﾙを初期化
            lblFlowClass.Text = vbNullString                            '流動区分
            lblWFNo.Text = vbNullString                                 'WF枚数
            lblMesMode.Text = vbNullString                              '運用ﾓｰﾄﾞ
            lblWpName.Text = vbNullString                               '装置名
            lblOpID.Text = vbNullString                                 '大工程ID
            lblStepID.Text = vbNullString                               '小工程ID
            
            '@収集項目の初期化
            mstrCollectionID = vbNullString                             '収集項目ID
            mstrCollectionVersion = vbNullString                        '収集項目ﾊﾞｰｼﾞｮﾝ
            
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの処理を初期化処理で処理しないようにする為,下記画面表示ﾌﾗｸﾞを設定
            '@画面表示処理ﾌﾗｸﾞの初期化
            mblnScreenDispFlag = True
            
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの初期化
            optDataUnit1.Checked = True                                 'ﾛｯﾄ単位を初期値設定
            optDataUnit1.Enabled = False                                'ﾛｯﾄ指定
            optDataUnit2.Enabled = False                                'WF指定
            
            '@画面表示処理ﾌﾗｸﾞの初期化
            mblnScreenDispFlag = False
                
            '@情報取得ｺﾝﾄﾛｰﾙ名(ｷｬﾘｱ/ﾛｯﾄ)の判定
            Select Case mstrInfoGetControlName
                Case CMstrInfoGetControlNameCarrier
                '@ｷｬﾘｱID
                    '@ﾛｯﾄIDを初期化
                    txtLot.Text = vbNullString
                
                Case CMstrInfoGetControlNameLot
                '@ﾛｯﾄID
                    '@ｷｬﾘｱIDを初期化
                    txtCarrier.Text = vbNullString
                
                Case Else
                '@その他
                    '@親ﾌｫｰﾑ起動(作業終了から)の場合はｷｬﾘｱから情報を取得する
                    '@ﾛｯﾄIDを初期化
                    txtLot.Text = vbNullString
                    
                    '@ﾌｫｰﾑ起動区分が自ﾌｫｰﾑ起動の場合
                    If mblnFormStartKbn = False Then
                        '@ｷｬﾘｱIDを初期化
                        txtCarrier.Text = vbNullString
                    End If
            End Select

            '@ｸﾞﾘｯﾄ領域の初期化
            'ｽﾛｯﾄﾏｯﾌﾟの初期化
            Call prvvsfSlotMap_init()

            'ﾊﾟﾗﾒｰﾀ項目一覧の初期化
            Call prvvsfCollect_Init()
            
            'ﾊﾟﾗﾒｰﾀ入力用一覧の初期化
            Call prvvsfCollectValue_Init()
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00G0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM00G0_Disp
    '機　能：ﾛｯﾄ・装置情報の画面描写処理
    '引　数：ltypEqstate：装置状態取得構造体
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 13:55:46 S.Deguchi
    '更新日：2005/05/26 (Thu) 13:51:12 N.Kasai
    '備　考：
    '　　　：2005/02/16 (Wed) 10:52:12 N.Kojima     Lot/WF単位ﾊﾟﾗﾒｰﾀ有無判定処理追加
    '　　　：2005/05/26 (Thu) 13:51:12 N.Kasai      LP_FLAG判定追加
    Private Sub prvfrmxxCM00G0_Disp(ByRef ltypEqstate As Eqstate)

        Try
            'NSYS 不要なHandlerを一時除外
            RemoveHandler txtCarrier.Change,AddressOf txtCarrier_Change
            RemoveHandler txtLot.Change,AddressOf txtLot_Change

            '@ﾛｯﾄ情報の表示
            With ptypLotprestate
            '@ｷｬﾘｱ/ﾛｯﾄIDをﾃｷｽﾄﾎﾞｯｸｽへｾｯﾄ
                '@情報取得ｺﾝﾄﾛｰﾙ名(ｷｬﾘｱ/ﾛｯﾄ)の判定
                Select Case mstrInfoGetControlName
                    '@情報取得ｺﾝﾄﾛｰﾙ = ｷｬﾘｱID
                    Case CMstrInfoGetControlNameCarrier
                        '@ﾛｯﾄID(ｾｯﾄ)
                        txtLot.Text = .strLotID
                    
                    '@情報取得ｺﾝﾄﾛｰﾙ = ﾛｯﾄID
                    Case CMstrInfoGetControlNameLot
                        '@ｷｬﾘｱID(ｾｯﾄ)
                        txtCarrier.Text = .strCarrierId
                        
                    '@情報取得ｺﾝﾄﾛｰﾙ = Null(ｷｬﾘｱ/ﾛｯﾄの両方をｾｯﾄ)
                    Case Else
                        '@ｷｬﾘｱID(ｾｯﾄ)
                        txtCarrier.Text = .strCarrierId
                        '@ﾛｯﾄID(ｾｯﾄ)
                        txtLot.Text = .strLotID
                End Select
                
                '@ﾗﾍﾞﾙに情報をｾｯﾄ
                lblFlowClass.Text = .strFlowClass                                                '流動区分
                lblMesMode.Text = ltypEqstate.strMesModeId                                       '運用ﾓｰﾄﾞ
                lblWpName.Text = .strWpName                                                      '装置名
                lblOpID.Text = .strOpID                                                          '大工程ID
                lblStepID.Text = .strStepID                                                      '小工程ID
                mstrLotLastUpdate = .strLotLastUpdate                                            'ﾛｯﾄ最終更新日時
                mstrCollectionID = .strCollectionID                                              '収集項目ID
                mstrCollectionVersion = .strCollectionVersion                                    '収集項目ﾊﾞｰｼﾞｮﾝ
                
                '@ﾌｫｰﾑ起動区分判定(CF・TPﾛｯﾄの場合の判定)
                If mblnFormStartKbn = True Then
                    '@親ﾌｫｰﾑから起動された場合はそのまま表示(CFﾌﾗｸﾞの判定は親ﾌｫｰﾑで行う為)
                    If IsNumeric(.strWfNum) Then
                        lblWFNo.Text = Format$(CInt(.strWfNum), CPstrCFKnmaFormat)               'WF枚数
                    End If
                Else
                    '@枚数表示判定(CF_FLAGを判定し、WF枚数とﾁｯﾌﾟ枚数の表示を切替)
                    Select Case .strCfFlag
                        '@CFﾛｯﾄ
                        Case CPstrCF
                            '@大判ﾌﾗｸﾞ判定(LP_FLAG)
                            If .strLpFlag = CPstrLP Then
                                '@大判の場合
                                lblWFNo.Text = .strWfNum                                         'WF枚数
                            Else
                                If IsNumeric(.strChipQuantity) Then
                                    lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)      'ﾁｯﾌﾟ枚数
                                End If
                             End If
                        
                        '@CFﾛｯﾄ以外
                        Case Else
                            '@TPALﾛｯﾄ
                            If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                                If IsNumeric(.strChipQuantity) Then
                                    lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)      'ﾁｯﾌﾟ枚数
                                End If
                            Else
                                '@CF,TPALﾛｯﾄ以外
                                lblWFNo.Text = .strWfNum                                         'WF枚数
                            End If
                    End Select
                End If
            End With
            
            '@Lot単位ﾊﾟﾗﾒｰﾀ有無判定ﾌﾗｸﾞがFalseか
            If mblnLotParamNothingFlag = False Then
                '@WF単位ﾊﾟﾗﾒｰﾀ有無判定ﾌﾗｸﾞがfalseか
                If mblnWFParamNothingFlag = False Then
                    '@Lot単位/WF単位の両ﾊﾟﾗﾒｰﾀがある場合
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ設定(txtCarrier/txtLotのValidate処理から遷移する為,ﾛｯﾄ単位がﾁｪｯｸ状態とする)
                    optDataUnit1.Checked = True                                                  'ﾛｯﾄ指定(ﾁｪｯｸ状態)
                    optDataUnit1.Enabled = True                                                  'ﾛｯﾄ指定
                    optDataUnit2.Enabled = True                                                  'WF指定
                Else
                    '@WF単位のﾊﾟﾗﾒｰﾀがない場合
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ設定(txtCarrier/txtLotのValidate処理から遷移する為,ﾛｯﾄ単位がﾁｪｯｸ状態とする)
                    optDataUnit1.Checked = True                                                  'ﾛｯﾄ指定(ﾁｪｯｸ状態)
                    optDataUnit1.Enabled = True                                                  'ﾛｯﾄ指定
                    optDataUnit2.Enabled = False                                                 'WF指定
                End If
            Else
                '@Lot単位のﾊﾟﾗﾒｰﾀがない場合
                '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ設定(txtCarrier/txtLotのValidate処理から遷移する為,WF単位がﾁｪｯｸ状態とする)
                optDataUnit2.Checked = True                                                      'WF指定(ﾁｪｯｸ状態)
                optDataUnit1.Enabled = False                                                     'ﾛｯﾄ指定
                optDataUnit2.Enabled = True                                                      'WF指定
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00G0_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        Finally
            'NSYS 除外していたHandlerを復帰
            AddHandler txtCarrier.Change,AddressOf txtCarrier_Change
            AddHandler txtLot.Change,AddressOf txtLot_Change

        End Try
    End Sub

    '関数名：prvvsfSlotMap_Init
    '機　能：ｽﾛｯﾄﾏｯﾌﾟの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 10:55:55 S.Deguchi
    '更新日：2008/04/04 (Fri) T.Sawaguchi
    '備　考：ﾍﾟｰｼﾞ送りﾎﾞﾀﾝ制御追加　案件No02761　対応
    Private Sub prvvsfSlotMap_init()

        Dim llngCnt As Integer      'ﾙｰﾌﾟｶｳﾝﾀ

        Try
            'NSYS 不要なHandler処理を一時除外
            RemoveHandler vsfSlotMap.BeforeRowColChange,AddressOf vsfSlotMap_BeforeRowColChange
            RemoveHandler vsfSlotMap.EnterCell,AddressOf vsfSlotMap_EnterCell

            '@ｽﾛｯﾄﾏｯﾌﾟ情報の初期化
            With vsfSlotMap
                '@ｸﾘｱ
                .SelectionMode = SelectionModeEnum.Row
                
                '@ﾀｲﾄﾙの設定(背景色：紺/文字色:黄)
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbYellow")
                newStyle.ForeColor = color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                Dim cellRange As CellRange = .GetCellRange(CMlngGridRowCol_0, CMlngGridRowCol_0, CMlngGridRowCol_0, .Cols.Count - 1)
                cellRange.Style = newStyle
               
                '@ﾀｲﾄﾙ文字列の設定
                .SetData(CMlngGridRowCol_0, CMlngGridRowCol_0, CMstrvsfNoTitle)
                .SetData(CMlngGridRowCol_0, CMlngvsfSlotMapWfIdC, CMstrvsfSlotMapWfIdC)
                .SetData(CMlngGridRowCol_0, CMlngvsfSlotMapInputRequestC, CMstrvsfSlotMapInputRequestC)
                
                '@ﾀｲﾄﾙの高さ
                .Rows(CMlngGridRowCol_0).Height = CMlngvsfTitleHeight       'CMlngGridTitleHeight→CMlngvsfTitleHeight
                
                '@行数の初期設定(ｽﾛｯﾄﾏｯﾌﾟMax:25+ﾀｲﾄﾙ:1)
                .Rows.Count = CMlngMaxSlotNo + 1
                
                '@表示ｾﾙ背景色設定(背景色：白)
                newStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor")
                newStyle.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                For llngCnt = 1 To CMlngMaxSlotNo
                    .SetData(llngCnt, CMlngvsfSlotMapWfIdC, vbNullString)
                    .SetData(llngCnt, CMlngvsfSlotMapInputRequestC, vbNullString)
                    cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapWfIdC)
                    cellRange.Style = newStyle
                    cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapInputRequestC)
                    cellRange.Style = newStyle
                Next llngCnt
                
                '@初期№表示
                For llngCnt = 1 To CMlngMaxSlotNo
                    .SetData(llngCnt, CMlngGridRowCol_0, CMlngMaxSlotNo - llngCnt + 1)
                    .Rows(llngCnt).Height = CMlngvsfRowHeight       'CMlngGridTitleHeight → CMlngvsfRowHeight
                Next llngCnt
                .Rows.DefaultSize = CMlngvsfRowHeight
                
                '@ﾀｲﾄﾙ選択状態とする
                .Row = CMlngZero
                
                '@使用不可
                .Enabled = False
                .TopRow = CMlngSlotNo10Row
                cmdVsfUpWF.Enabled = False
                cmdVsfDownWF.Enabled = False
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        Finally
            'NSYS 除外していたHandler処理を復元
            AddHandler vsfSlotMap.BeforeRowColChange,AddressOf vsfSlotMap_BeforeRowColChange
            AddHandler vsfSlotMap.EnterCell,AddressOf vsfSlotMap_EnterCell

        End Try
    End Sub

    '関数名：prvvsfSlotMap_Disp
    '機　能：ｽﾛｯﾄﾏｯﾌﾟの表示
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 14:15:14 S.Deguchi
    '更新日：2007/02/05 (Mon) 14:24:44 N.Kasai
    '　　　：2008/04/04 (Fri) 16:02:26 T.Sawaguchi
    '備　考：
    '　　　：2007/02/05 (Mon) 14:24:44 N.Kasai    WF表示条件追加(RECIPE_IDが未設定の場合は非表示)№01120
    '　　　：2008/04/04 (Fri) 16:02:52 T.Sawaguchi ﾍﾟｰｼﾞ送りﾎﾞﾀﾝ制御追加　案件No02761　対応
    Private Sub prvVsfSlotMap_Disp()

        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngSlotMapIndex        As Integer              '初期表示WFｲﾝﾃﾞｯｸｽ
        Dim llngSlotPosition        As Integer              'ｽﾛｯﾄ位置(計算値)
        Dim llngTempSlotP           As Integer

        Try

            '@ｽﾛｯﾄﾏｯﾌﾟの初期化
            Call prvvsfSlotMap_init()

            'NSYS 不要なHandlerを一時除外
            RemoveHandler vsfSlotMap.BeforeRowColChange,AddressOf vsfSlotMap_BeforeRowColChange
            RemoveHandler vsfSlotMap.EnterCell,AddressOf vsfSlotMap_EnterCell

            '@ｽﾛｯﾄﾏｯﾌﾟ情報の表示
            With vsfSlotMap
                
                .Redraw = False

                '@ﾀｲﾄﾙの高さ
                .Rows(CMlngGridRowCol_0).Height = CMlngvsfTitleHeight       'CMlngGridTitleHeight→CMlngvsfTitleHeight
                
                '@ﾘｽﾄｶｳﾝﾄが0以上の場合
                If mtypWaferList.lngListCnt > 0 Then
                    '@WF情報が取得できた場合
                    
                    '@ｸﾞﾘｯﾄﾞ背景色を設定する
                    For llngCnt = 1 To CMlngMaxSlotNo
                        
                        '@ｽﾛｯﾄ№欄(番号&右寄中央揃)
                        .SetData(llngCnt, CMlngvsfSlotMapNoC, Format$(CMlngMaxSlotNo - llngCnt + 1, CPstrSlotNoFormat))
                        .Cols(CMlngvsfSlotMapNoC).TextAlign = TextAlignEnum.RightCenter
                    
                        '@WF構成枚数以上の場合：背景色灰色
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray" + llngCnt.ToString)
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapWfIdC, llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle
                        
                        '@ﾀｲﾄﾙの高さ
                        .Rows(llngCnt).Height = CMlngvsfRowHeight     'CMlngGridTitleHeight→CMlngvsfRowHeight
                    
                    Next llngCnt
                    
                    '@ｽﾛｯﾄ№欄の設定(ｸﾞﾘｯﾄﾞの背景色を設定する)
                    For llngCnt = 1 To mtypWaferList.lngListCnt
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝを取得する
                        llngTempSlotP = CLng(mtypWaferList.typWfList(llngCnt - 1).strSlotPosition)
                        
                        '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                        If CLng(mtypWaferList.strSlotSize) < CMlngMaxSlotNo - llngTempSlotP + 1 Then
                            '@ｽﾛｯﾄ№欄(空白＆薄いｸﾞﾚｰ)
                            .SetData(llngCnt, CMlngvsfSlotMapNoC, vbNullString)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbButtonFace" + llngCnt.ToString)
                            newStyle.BackColor = vbButtonFace
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapWfIdC, llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        Else
                        
                            '@ﾚｼﾋﾟIDが未設定の場合は装置ﾃﾞｰﾀ入力の対象外
                            If mtypWaferList.typWfList(llngCnt - 1).strRecipeId <> vbNullString Then
                                '@WF構成枚数以内の場合：背景色白
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_White" + llngCnt.ToString)
                                Dim cellRange As CellRange = .GetCellRange((CMlngMaxSlotNo - llngTempSlotP + 1), CMlngvsfSlotMapWfIdC,(CMlngMaxSlotNo - llngTempSlotP + 1), .Cols.Count - 1)
                                newStyle.BackColor = Color.White
                                cellRange.Style = newStyle 
                            End If
                        End If
                    Next llngCnt
                
                    '@WF_ID欄&入力欄の設定
                    For llngCnt = 0 To mtypWaferList.lngListCnt - 1
                        
                        '@-----------------------------------------------------------------------------------------
                        '@ﾛｯﾄﾚｼﾋﾟor(WFﾚｼﾋﾟが設定ずみandWFにﾚｼﾋﾟが存在する)場合のみ表示
                        '@ﾚｼﾋﾟが存在しない場合は(WF選択条件で測定(ﾚｼﾋﾟ)なし、工順変更で枚葉ﾚｼﾋﾟなしを設定された)
                        '@ﾊﾟﾗｰﾒｰﾀの入力は必要ない為、表示しない。(№01120)
                        '@(WF_RECIPE_FLAG = 0:ﾛｯﾄﾚｼﾋﾟ、1:枚葉ﾚｼﾋﾟ)
                        '@-----------------------------------------------------------------------------------------
                        If mtypWaferList.strWfRecipeFlag = "0" Or (mtypWaferList.strWfRecipeFlag = "1" And mtypWaferList.typWfList(llngCnt).strRecipeId <> vbNullString) Then

                            '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが数値の場合
                            If IsNumeric(mtypWaferList.typWfList(llngCnt).strSlotPosition) = True Then
                                '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝがWFのMax以内の場合WF_IDをｾｯﾄ
                                Select Case CInt(mtypWaferList.typWfList(llngCnt).strSlotPosition)
                                    '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝがMaxｽﾛｯﾄ内の場合
                                    Case 1 To CMlngMaxSlotNo
                                        '@ｽﾛｯﾄ位置の計算
                                        llngSlotPosition = CMlngMaxSlotNo - mtypWaferList.typWfList(llngCnt).strSlotPosition + 1
                                        
                                        '@WF_IDの設定(WF_ID)
                                        .SetData(llngSlotPosition, CMlngvsfSlotMapWfIdC, mtypWaferList.typWfList(llngCnt).strWfId)
                                        
                                        '@収集項目完了判定
                                        If mtypWaferList.typWfList(llngCnt).strDataCollCompFlag = CMstrOne Then
                                            '@入力不要の場合(空欄&背景色:ﾗｲﾄﾌﾞﾙｰ)
                                            .SetData(llngSlotPosition, CMlngvsfSlotMapInputRequestC, vbNullString)
                                            
                                            '@色設定
                                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngOKBackColor" + llngCnt.ToString)
                                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngOKBackColor)
                                            newStyle.TextAlign = TextAlignEnum.LeftCenter
                                            Dim cellRange As CellRange = .GetCellRange(llngSlotPosition, CMlngvsfSlotMapWfIdC, _
                                                                   llngSlotPosition, .Cols.Count - 1)
                                            cellRange.Style = newStyle
                                        Else
                                            '@入力必要の場合("要"&背景色:白)
                                            .SetData(llngSlotPosition, CMlngvsfSlotMapInputRequestC, CMstrInputRequest)
                                            
                                            '@色設定
                                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor" + llngCnt.ToString)
                                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                                            newStyle.TextAlign = TextAlignEnum.LeftCenter
                                            Dim cellRange As CellRange = .GetCellRange(llngSlotPosition, CMlngvsfSlotMapWfIdC, _
                                                                   llngSlotPosition, .Cols.Count - 1)
                                            cellRange.Style = newStyle
                                        End If
                                End Select
                            End If
                        End If
                    Next llngCnt
                    
                    '@初期表示WFｲﾝﾃﾞｯｸｽ
                    llngSlotMapIndex = 0
                    For llngCnt = CMlngMaxSlotNo To 1 Step -1
                        '@WF_IDがある行を選択
                        If .GetData(llngCnt, CMlngvsfSlotMapWfIdC) <> vbNullString Then
                            '@初期表示WFｲﾝﾃﾞｯｸｽに格納
                            llngSlotMapIndex = llngCnt
                            .TopRow = CMlngSlotNo10Row
                            Exit For
                        End If
                    Next llngCnt
                    
                    '@ﾊﾟﾗﾒｰﾀ項目の色設定
                    Call prvvsfCollect_Color()

                    .Redraw = True

                    '@WFｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行判定
                    If llngSlotMapIndex = 0 Then
                    '@表示ｲﾝﾃﾞｯｸｽが"0"の場合(非活性化)
                        llngSlotMapIndex = CMlngMaxSlotNo
                        .Enabled = False
                    Else
                    '@表示ｲﾝﾃﾞｯｸｽが"0"以外の場合(活性化)
                        .Row = llngSlotMapIndex
                        .Enabled = True
                        '@前頁、次頁ｽｸﾛｰﾙﾎﾞﾀﾝ表示設定
                        cmdVsfUpWF.Enabled = True
                        cmdVsfDownWF.Enabled = False
                    End If
                Else
                '@ﾘｽﾄｶｳﾝﾄが0の場合
                    '@背景色設定
                    For llngCnt = 1 To CMlngMaxSlotNo
                        '@ｽﾛｯﾄ№欄(薄いｸﾞﾚｰ)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbButtonFace" + llngCnt.ToString)
                        newStyle.BackColor = vbButtonFace
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapWfIdC, _
                                               llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle
                    Next llngCnt
                    
                    '@ﾊﾟﾗﾒｰﾀ項目の色設定
                    Call prvvsfCollect_Color()

                    .Redraw = True

                    '@ｽﾛｯﾄﾏｯﾌﾟを非活性化
                    .Enabled = False
                    .TopRow = CMlngSlotNo10Row
                    cmdVsfUpWF.Enabled = False
                    cmdVsfDownWF.Enabled = False
                             
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        Finally
            'NSYS 除外していたHandlerを復帰
            AddHandler vsfSlotMap.BeforeRowColChange,AddressOf vsfSlotMap_BeforeRowColChange
            AddHandler vsfSlotMap.EnterCell,AddressOf vsfSlotMap_EnterCell

        End Try
    End Sub

    '関数名：prvvsfCollect_Init
    '機　能：ﾊﾟﾗﾒｰﾀ項目一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 10:59:47 S.Deguchi
    '更新日：2008/04/04 (Fri) 16:10:07 T.Sawaguchi
    '備　考：
    '　　　：2006/12/20 (Wed) 15:22:29 N.Kasai      収集項目ﾀｲﾌﾟ追加(№01515)
    '　　　：2007/03/01 (Thu) 09:19:41 N.Kasai      不要ﾀｸﾞの削除(№01126)
    '　　　：2008/04/04 (Fri) 16:10:25 T.Sawaguchi  ﾍﾟｰｼﾞ送りﾎﾞﾀﾝ,制御追加　案件No02761　対応
    Private Sub prvvsfCollect_Init()
        
        Try

            '@ﾊﾟﾗﾒｰﾀ項目情報の初期化
            With vsfCollect
                '@ｸﾘｱ
                .Row = 0
                
                '@ﾀｲﾄﾙの設定(背景色：紺/文字色:黄)
                .Styles.Fixed.ForeColor = color.Yellow                                                                '文字色
                .Styles.Fixed.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                  '背景色
                .Styles.Fixed.Trimming = StringTrimming.None                                                          '省略符号(...)表示なし
                
                '@ﾀｲﾄﾙの高さ
                .Rows(CMlngGridRowCol_0).Height = CMlngvsfTitleHeight       '@CMlngGridTitleHeight → CMlngvsfTitleHeightへ変更
                
                '@行数の初期設定(行:1)
                .Rows.Count = CMlngOne

                '@列幅設定
                .Cols(CMlngvsfCollectNoC).Width = CMlngvsfCollectNoW                                '№
                .Cols(CMlngvsfCollectParaIdC).Width = CMlngvsfCollectParaIdW                        'ﾊﾟﾗﾒｰﾀID
                .Cols(CMlngvsfCollectParaVerC).Width = CMlngvsfCollectParaVerW                      'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
                .Cols(CMlngvsfCollectUnitC).Width = CMlngvsfCollectUnitW                            '単位
                .Cols(CMlngvsfCollectMandatoryCountC).Width = CMlngvsfCollectMandatoryCountW        '必須項目数
                .Cols(CMlngvsfCollectInputEndFlagC).Width = CMlngvsfCollectInputEndFlagW            '入力済
                .Cols(CMlngvsfCollectDataTypeC).Width = CMlngvsfCollectDataTypeW                    'ﾃﾞｰﾀﾀｲﾌﾟ
                .Cols(CMlngvsfCollectClass1C).Width = CMlngvsfCollectClass1W                        'ﾃﾞｰﾀ分類名1
                .Cols(CMlngvsfCollectClass2C).Width = CMlngvsfCollectClass2W                        'ﾃﾞｰﾀ分類名2
                .Cols(CMlngvsfCollectClass3C).Width = CMlngvsfCollectClass3W                        'ﾃﾞｰﾀ分類名3
                .Cols(CMlngvsfCollectClass4C).Width = CMlngvsfCollectClass4W                        'ﾃﾞｰﾀ分類名4
                .Cols(CMlngvsfCollectDvNameC).Width = CMlngvsfCollectDvNameW                        '装置報告ﾃﾞｰﾀ名
                .Cols(CMlngvsfCollectCfFlagC).Width = CMlngvsfCollectCfFlagW                        'CFﾌﾗｸﾞ
                .Cols(CMlngvsfCollectLpFlagC).Width = CMlngvsfCollectLpFlagW                        '大板ﾌﾗｸﾞ
                .Cols(CMlngvsfCollectDataUnit).Width = CMlngvsfCollectDataUnitW                     '収集ﾃﾞｰﾀ処理単位
                .Cols(CMlngvsfCollectMeasureMode).Width = CMlngvsfCollectMeasureModeW               '収集ﾃﾞｰﾀ測定ﾓｰﾄﾞ
                .Cols(CMlngvsfCollectRiftainFlag).Width = CMlngvsfCollectRiftainFlagW               '収集ﾃﾞｰﾀ引継ぎﾌﾗｸﾞ
        '        .ColWidth(CMlngvsfCollectSpecJudgeFlag) = CMlngvsfCollectSpecJudgeFlagW             '規格値判定ﾌﾗｸﾞ
                .Cols(CMlngvsfCollectParameterLoad).Width = CMlngvsfCollectParameterLoadW           'ﾊﾟﾗﾒｰﾀ情報読込(0:未読込/1:読込済)
                .Cols(CMlngvsfCollectCollectionType).Width = CMlngvsfCollectCollectionTypeW         '収集項目ﾀｲﾌﾟ(0:作業記録/1:装置ﾃﾞｰﾀ)
                .Cols(CMlngvsfCollectCeId).Width = CMlngvsfCollectCeIdW                             'CEID(0:正/1:異/Null:正)
                
                '@非表示項目設定
                .Cols(CMlngvsfCollectDataTypeC).visible = False                                     'ﾃﾞｰﾀﾀｲﾌﾟ
                .Cols(CMlngvsfCollectClass1C).visible = False                                       'ﾃﾞｰﾀ分類名1
                .Cols(CMlngvsfCollectClass2C).visible = False                                       'ﾃﾞｰﾀ分類名2
                .Cols(CMlngvsfCollectClass3C).visible = False                                       'ﾃﾞｰﾀ分類名3
                .Cols(CMlngvsfCollectClass4C).visible = False                                       'ﾃﾞｰﾀ分類名4
                .Cols(CMlngvsfCollectDvNameC).visible = False                                       '装置報告ﾃﾞｰﾀ名
                .Cols(CMlngvsfCollectCfFlagC).visible = False                                       'CFﾌﾗｸﾞ
                .Cols(CMlngvsfCollectLpFlagC).visible = False                                       '大板ﾌﾗｸﾞ
                .Cols(CMlngvsfCollectDataUnit).visible = False                                      '収集ﾃﾞｰﾀ処理単位
                .Cols(CMlngvsfCollectMeasureMode).visible = False                                   '収集ﾃﾞｰﾀ測定ﾓｰﾄﾞ
                .Cols(CMlngvsfCollectRiftainFlag).visible = False                                   '収集ﾃﾞｰﾀ引継ぎﾌﾗｸﾞ
        '        .ColHidden(CMlngvsfCollectSpecJudgeFlag) = True                                     '規格値判定ﾌﾗｸﾞ
                .Cols(CMlngvsfCollectParameterLoad).visible = False                                 'ﾊﾟﾗﾒｰﾀ情報読込(0:未読込/1:読込済)
                .Cols(CMlngvsfCollectCollectionType).visible = False                                '収集項目ﾀｲﾌﾟ(0:作業記録/1:装置ﾃﾞｰﾀ)
                
                '@使用不可
                '.Enabled = False
            End With
            
            '@ｽｸﾛｰﾙﾎﾞﾀﾝを無効
            cmdVsfUpCollect.Enabled = False
            cmdVsfDownCollect.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCollect_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCollect_Disp
    '機　能：ﾊﾟﾗﾒｰﾀ項目一覧の表示
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 15:26:39 S.Deguchi
    '更新日：2008/04/04 (Fri) 16:17:35 T.Sawaguchi
    '備　考：
    '　　　：2005/06/21 (Tue) 16:21:30 N.Kojima     規格上・中・下限値の表示処理をｺﾒﾝﾄｱｳﾄ
    '　　　：2006/12/20 (Wed) 15:22:29 N.Kasai      収集項目ﾀｲﾌﾟ追加(№01515)
    '　　　：2007/03/01 (Thu) 09:20:40 N.Kasai      不要ﾀｸﾞの削除(№01126)
    '　　　：2008/04/04 (Fri) 16:17:59 T.Sawaguchi  ﾍﾟｰｼﾞ送りﾎﾞﾀﾝ制御追加　案件No02761　対応
    Private Sub prvvsfCollect_Disp()

        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾀ

        Try
            
            '@装置収集項目情報の設定
            With vsfCollect
                '@描画ﾛｯｸ
                .Redraw = False

                '@取得ﾊﾟﾗﾒｰﾀ数が"1"以上の場合
                If mtypLotCollectParamsList.llngLotCollectParamsCnt > 0 Then
                    RemoveHandler vsfCollect.BeforeRowColChange,AddressOf vsfCollect_BeforeRowColChange
                    RemoveHandler vsfCollect.EnterCell,AddressOf vsfCollect_EnterCell
                    '@行設定
                    .Rows.Count = mtypLotCollectParamsList.llngLotCollectParamsCnt + 1
                    AddHandler vsfCollect.BeforeRowColChange,AddressOf vsfCollect_BeforeRowColChange
                    AddHandler vsfCollect.EnterCell,AddressOf vsfCollect_EnterCell
                
                    '@ﾊﾟﾗﾒｰﾀ情報をｸﾞﾘｯﾄﾞにｾｯﾄする
                    For llngCnt = 1 To mtypLotCollectParamsList.llngLotCollectParamsCnt
                        .SetData(llngCnt, CMlngvsfCollectNoC, llngCnt)                                           '№
                        
                        .SetData(llngCnt, CMlngvsfCollectParaIdC, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strParameterID)            'ﾊﾟﾗﾒｰﾀID
                        
                        .SetData(llngCnt, CMlngvsfCollectParaVerC, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strParameterVersion)       'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
                            
                        .SetData(llngCnt, CMlngvsfCollectUnitC, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strUnit)                   '単位
                            
                        .SetData(llngCnt, CMlngvsfCollectMandatoryCountC, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strMandatoryCount)         '必須項目数
                            
                        '@隠しCol
                        .SetData(llngCnt, CMlngvsfCollectDataTypeC, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strDataType)               'ﾃﾞｰﾀﾀｲﾌﾟ
                            
                        .SetData(llngCnt, CMlngvsfCollectClass1C, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strClassification1)        'ﾃﾞｰﾀ分類1
                            
                        .SetData(llngCnt, CMlngvsfCollectClass2C, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strClassification2)        'ﾃﾞｰﾀ分類2
                            
                        .SetData(llngCnt, CMlngvsfCollectClass3C, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strClassification3)        'ﾃﾞｰﾀ分類3
                            
                        .SetData(llngCnt, CMlngvsfCollectClass4C, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strClassification4)        'ﾃﾞｰﾀ分類4
                            
                        .SetData(llngCnt, CMlngvsfCollectDvNameC, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strDvName)                 '装置報告ﾃﾞｰﾀ名
                            
                        .SetData(llngCnt, CMlngvsfCollectCfFlagC, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strCfFlag)                 'CFﾌﾗｸﾞ
                            
                        .SetData(llngCnt, CMlngvsfCollectLpFlagC, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strLpFlag)                 '大判ﾌﾗｸﾞ
                            
                        .SetData(llngCnt, CMlngvsfCollectDataUnit, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strDataUnit)               'ﾃﾞｰﾀ処理単位
                        
                        .SetData(llngCnt, CMlngvsfCollectMeasureMode, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strMeasureMode)            'ﾃﾞｰﾀ測定ﾓｰﾄﾞ
                            
                        .SetData(llngCnt, CMlngvsfCollectRiftainFlag, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strDataRetainFlag)         'ﾃﾞｰﾀ引継ぎﾌﾗｸﾞ
                        
                        If mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strMeasureMode = CMstrOne Then
                            .SetData(llngCnt, CMlngvsfCollectParameterLoad, CMstrFour)                           'ﾊﾟﾗﾒｰﾀ情報読込ﾌﾗｸﾞ(4:ｵﾝﾗｲﾝ)
                        Else
                            .SetData(llngCnt, CMlngvsfCollectParameterLoad, CMstrZero)                           'ﾊﾟﾗﾒｰﾀ情報読込ﾌﾗｸﾞ(0:未読込)
                        End If
                        
                        .SetData(llngCnt, CMlngvsfCollectCollectionType, _
                            mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strCollectionType)         '収集項目ﾀｲﾌﾟ(0:作業記録/1:装置ﾃﾞｰﾀ)
                        
                        Select Case mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strCeId   'CEID(0:正/1:異/Null:正)
                            Case "1"
                                .SetData(llngCnt, CMlngvsfCollectCeId, CMstrCeID1)
                            Case Else
                                .SetData(llngCnt, CMlngvsfCollectCeId, CMstrCeID0)
                        End Select
                        
                        '@入力済み判定処理
                        If optDataUnit1.Checked = True Then
                        '@ﾛｯﾄ単位にﾁｪｯｸがついている場合
                            '@ﾛｯﾄﾃﾞｰﾀ収集完了ﾌﾗｸﾞがたっていない場合(="0")
                            If mtypLotCollectParamsList.strLotDataCollCompFlag = CMstrZero Then
                                '@必須入力項目が"0"以外の場合
                                If mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strMandatoryCount <> 0 Then
                                    '@測定ﾃﾞｰﾀがｵﾝﾗｲﾝの場合
                                    If mtypLotCollectParamsList.typLotCollectParams(llngCnt - 1).strMeasureMode = CMstrOne Then
                                        '@入力Cell(空欄)
                                        .SetData(llngCnt, CMlngvsfCollectInputEndFlagC, vbNullString)
                                    Else
                                        '@入力Cell("要")
                                        .SetData(llngCnt, CMlngvsfCollectInputEndFlagC, CMstrInputRequest)
                                    End If
                                Else
                                    '@入力Cell(空欄)
                                    .SetData(llngCnt, CMlngvsfCollectInputEndFlagC, vbNullString)
                                End If
                            Else
                                '@入力Cell(空欄)
                                .SetData(llngCnt, CMlngvsfCollectInputEndFlagC, vbNullString)
                            End If
                        Else
                        '@WF単位にﾁｪｯｸがついている場合
                            '@選択されているWFｽﾛｯﾄﾏｯﾌﾟの"入力"欄に"要"がたっている場合
                            If vsfSlotMap.GetData(vsfSlotMap.Row, CMlngvsfSlotMapInputRequestC) = CMstrInputRequest Then
                                If .GetData(llngCnt, CMlngvsfCollectMandatoryCountC) = CMstrZero Then
                                    '@入力Cell(空欄)
                                    .SetData(llngCnt, CMlngvsfCollectInputEndFlagC, vbNullString)
                                Else
                                    '@測定ﾃﾞｰﾀが装置の場合
                                    If .GetData(llngCnt, CMlngvsfCollectMeasureMode) = CMstrOne Then
                                        '@入力Cell(空欄)
                                        .SetData(llngCnt, CMlngvsfCollectInputEndFlagC, vbNullString)
                                    Else
                                        '@入力Cell("要")
                                        .SetData(llngCnt, CMlngvsfCollectInputEndFlagC, CMstrInputRequest)
                                    End If
                                End If
                            Else
                                '@入力Cell(空欄)
                                .SetData(llngCnt, CMlngvsfCollectInputEndFlagC, vbNullString)
                            End If
                        End If
                        
                        '@高さ設定
                        .Rows(llngCnt).Height = CMlngvsfRowHeight         'CMlngGridRowHeight → CMlngvsfRowHeightへ変更
                    Next llngCnt
                    
                    '@列幅の自動調整
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(CMlngGridRowCol_0, .Cols.Count - 1, 6)
                    .Cols.Frozen = CMlngvsfCollectUnitC + 1         '固定列
                    .AllowResizing = AllowResizingEnum.Columns      'ﾏｳｽよる列ｻｲｽﾞ変更の可／不可
                    .Rows.DefaultSize = CMlngvsfRowHeight
            
                End If
                
                '@ﾊﾟﾗﾒｰﾀ項目の色設定
                Call prvvsfCollect_Color()

                '@描画ﾛｯｸ解除
                .Redraw = True

                '@ﾊﾟﾗﾒｰﾀﾘｽﾄが1件以上ある場合
                If .Rows.Count > 1 Then
                    '@ﾊﾟﾗﾒｰﾀﾘｽﾄのﾛｯｸ解除
                    .Enabled = True
                Else
                    .Enabled = False
                End If
                
                '@前頁、次頁ｽｸﾛｰﾙﾎﾞﾀﾝ表示設定
                If .Rows.Count > CMvsfCollectVisibleRows Then
                    If .Row < CMvsfCollectVisibleRows Then
                        cmdVsfUpCollect.Enabled = False
                        cmdVsfDownCollect.Enabled = True
                    Else
                        cmdVsfUpCollect.Enabled = True
                        cmdVsfDownCollect.Enabled = True
                    End If
                Else
                    cmdVsfUpCollect.Enabled = False
                    cmdVsfDownCollect.Enabled = False
                End If
            End With


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCollect_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCollect_Color
    '機　能：ﾊﾟﾗﾒｰﾀ項目一覧の入力状況による色設定
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 08:43:30 S.Deguchi
    '更新日：2005/05/10 (Tue) 15:39:54 N.Kojima
    '備　考：
    '　　　：2005/05/10 (Tue) 15:39:54 N.Kojima     任意入力ﾊﾟﾗﾒｰﾀは収集不要ｶﾗｰで表示するように処理を修正。(不具合№556)
    Private Sub prvvsfCollect_Color()

        Dim llngCnt         As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lstrClass1      As String       'Class1ﾌﾗｸﾞ(1:空欄,2:入力済,3:非表示)
        Dim lstrClass2      As String       'Class2ﾌﾗｸﾞ(1:空欄,2:入力済,3:非表示)
        Dim lstrClass3      As String       'Class3ﾌﾗｸﾞ(1:空欄,2:入力済,3:非表示)
        Dim lstrClass4      As String       'Class4ﾌﾗｸﾞ(1:空欄,2:入力済,3:非表示)
        Dim lstrValue       As String       '値ﾌﾗｸﾞ(1:空欄,2:入力済,3:非表示)

        Try

            '@ﾛｯﾄ単位かWF単位かにより判別するｸﾞﾘｯﾄﾞを変更
            If optDataUnit1.Checked = True Then
            '@ﾛｯﾄ単位の場合
                With vsfCollect
                    For llngCnt = 1 To .Rows.Count - 1
                        '@入力欄が空欄の場合
                        If .GetData(llngCnt, CMlngvsfCollectInputEndFlagC) = vbNullString Then
                            '@必須項目数が"0"件の場合
                            If .GetData(llngCnt, CMlngvsfCollectMandatoryCountC) = CMstrZero Then
                                '@入力ﾃﾞｰﾀがない(ﾀｲﾄﾙしかない)場合
                                If vsfCollectValue.Rows.Count = 1 Then
                                    '@入力済／入力不要色を初期設定
                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngOKBackColor" + llngCnt.ToString)
                                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngOKBackColor)
                                    Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngGridRowCol_0, llngCnt, .Cols.Count - 1)
                                    cellRange.Style = newStyle
                                Else
                                    '@入力情報欄が表示状態(Class1)
                                    If vsfCollectValue.Cols(CMlngvsfCollectValueClass1C).Visible = True Then
                                        If vsfCollectValue.GetData(CMlngOne, CMlngvsfCollectValueClass1C) = vbNullString Then
                                            '@結果(空欄)
                                            lstrClass1 = CMstrOne
                                        Else
                                            '@結果(入力有)
                                            lstrClass1 = CMstrTwo
                                        End If
                                    Else
                                        '@結果(非表示)
                                        lstrClass1 = CMstrThree
                                    End If
                                    
                                    '@入力情報欄が表示状態(Class2)
                                    If vsfCollectValue.Cols(CMlngvsfCollectValueClass2C).Visible = True Then
                                        If vsfCollectValue.GetData(CMlngOne, CMlngvsfCollectValueClass2C) = vbNullString Then
                                            '@結果(空欄)
                                            lstrClass2 = CMstrOne
                                        Else
                                            '@結果(入力有)
                                            lstrClass2 = CMstrTwo
                                        End If
                                    Else
                                        '@結果(非表示)
                                        lstrClass2 = CMstrThree
                                    End If
                                    
                                    '@入力情報欄が表示状態(Class3)
                                    If vsfCollectValue.Cols(CMlngvsfCollectValueClass3C).Visible = True Then
                                        If vsfCollectValue.GetData(CMlngOne, CMlngvsfCollectValueClass3C) = vbNullString Then
                                            '@結果(空欄)
                                            lstrClass3 = CMstrOne
                                        Else
                                            '@結果(入力有)
                                            lstrClass3 = CMstrTwo
                                        End If
                                    Else
                                        '@結果(非表示)
                                        lstrClass3 = CMstrThree
                                    End If
                                    
                                    '@入力情報欄が表示状態(Class4)
                                    If vsfCollectValue.Cols(CMlngvsfCollectValueClass4C).Visible = True Then
                                        If vsfCollectValue.GetData(CMlngOne, CMlngvsfCollectValueClass4C) = vbNullString Then
                                            '@結果(空欄)
                                            lstrClass4 = CMstrOne
                                        Else
                                            '@結果(入力有)
                                            lstrClass4 = CMstrTwo
                                        End If
                                    Else
                                        '@結果(非表示)
                                        lstrClass4 = CMstrThree
                                    End If
                                    
                                    '@入力情報欄が表示状態(値)
                                    If vsfCollectValue.Cols(CMlngvsfCollectValueDataC).Visible = True Then
                                        If vsfCollectValue.GetData(CMlngOne, CMlngvsfCollectValueDataC) = vbNullString Then
                                            '@結果NG(空欄)
                                            lstrValue = CMstrOne
                                        Else
                                            '@結果OK(入力有)
                                            lstrValue = CMstrTwo
                                        End If
                                    Else
                                        '@結果NG
                                        lstrValue = CMstrThree
                                    End If
                                    
                                    '@結果判定(空欄か非表示)
                                    If (lstrClass1 = CMstrOne Or lstrClass1 = CMstrThree) And _
                                       (lstrClass2 = CMstrOne Or lstrClass2 = CMstrThree) And _
                                       (lstrClass3 = CMstrOne Or lstrClass3 = CMstrThree) And _
                                       (lstrClass4 = CMstrOne Or lstrClass4 = CMstrThree) And _
                                       (lstrValue = CMstrOne Or lstrValue = CMstrThree) Then
                                        '@全て空欄か非表示の場合
                                        
                                        '@入力済／入力不要色を初期設定
                                        Dim newStyle As CellStyle = vsfCollect.Styles.Add("CustomStyle_BackColor_CMlngOKBackColor" + llngCnt.ToString)
                                        newStyle.BackColor = ColorTranslator.FromWin32(CMlngOKBackColor)
                                        Dim cellRange As CellRange = vsfCollect.GetCellRange(llngCnt, CMlngGridRowCol_0, _
                                                                         llngCnt, vsfCollect.Cols.Count - 1)
                                        cellRange.Style = newStyle
                                    Else
                                        '@結果判定(入力か非表示)
                                        If (lstrClass1 = CMstrTwo Or lstrClass1 = CMstrThree) And _
                                           (lstrClass2 = CMstrTwo Or lstrClass2 = CMstrThree) And _
                                           (lstrClass3 = CMstrTwo Or lstrClass3 = CMstrThree) And _
                                           (lstrClass4 = CMstrTwo Or lstrClass4 = CMstrThree) And _
                                           lstrValue = CMstrTwo Then
                                            '@全て入力か非表示の場合
                                        
                                            '@入力済／入力不要色を初期設定
                                            Dim newStyle As CellStyle = vsfCollect.Styles.Add("CustomStyle_BackColor_CMlngOKBackColor" + llngCnt.ToString)
                                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngOKBackColor)
                                            Dim cellRange As CellRange = vsfCollect.GetCellRange(llngCnt, CMlngGridRowCol_0, _
                                                                             llngCnt, vsfCollect.Cols.Count - 1)
                                            cellRange.Style = newStyle
                                        Else
                                            '@入力可能背景色をｾｯﾄ
                                            Dim newStyle As CellStyle = vsfCollect.Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor" + llngCnt.ToString)
                                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                                            Dim cellRange As CellRange = vsfCollect.GetCellRange(llngCnt, CMlngGridRowCol_0, _
                                                                             llngCnt, vsfCollect.Cols.Count - 1)
                                            cellRange.Style = newStyle
                                        End If
                                    End If
                                
                                End If
                            Else
                            '@必須項目数が"0"件以外の場合
                                '@入力済／入力不要色を初期設定
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngOKBackColor" + llngCnt.ToString)
                                newStyle.BackColor = ColorTranslator.FromWin32(CMlngOKBackColor)
                                Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngGridRowCol_0, llngCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle
                            End If
                        Else
                        '@入力欄が"要"の場合
                            Select Case .GetData(llngCnt, CMlngvsfCollectMeasureMode)
                                Case CMstrZero, CMstrTwo
                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor" + llngCnt.ToString)
                                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                                    Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngGridRowCol_0, llngCnt, .Cols.Count - 1)
                                    cellRange.Style = newStyle
                                Case CMstrOne
                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngOKBackColor" + llngCnt.ToString)
                                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngOKBackColor)
                                    Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngGridRowCol_0, llngCnt, .Cols.Count - 1)
                                    cellRange.Style = newStyle
                            End Select
                        End If
                    Next llngCnt
                End With
            Else
            '@WF単位の場合
                With vsfSlotMap
                    '@入力欄に「要」が表示されているか
                    If .GetData(vsfSlotMap.Row, CMlngvsfSlotMapInputRequestC) = vbNullString Then
                    '@入力欄が空欄の場合
                        For llngCnt = 1 To vsfCollect.Rows.Count - 1
                            '@必須項目数が"0"件の場合
                            If vsfCollect.GetData(llngCnt, CMlngvsfCollectMandatoryCountC) = CMstrZero Then
                                '@入力ﾃﾞｰﾀがない(ﾀｲﾄﾙしかない)場合
                                If vsfCollectValue.Rows.Count = 1 Then
                                    '@入力済／入力不要色を初期設定
                                    Dim newStyle As CellStyle = vsfCollect.Styles.Add("CustomStyle_BackColor_CMlngOKBackColor" + llngCnt.ToString)
                                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngOKBackColor)
                                    Dim cellRange As CellRange = vsfCollect.GetCellRange(llngCnt, CMlngGridRowCol_0, _
                                                                     llngCnt, vsfCollect.Cols.Count - 1)
                                    cellRange.Style = newStyle
                                Else
                                    '@入力済／入力不要色を初期設定
                                    Dim newStyle As CellStyle = vsfCollect.Styles.Add("CustomStyle_BackColor_CMlngOKBackColor" + llngCnt.ToString)
                                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngOKBackColor)
                                    Dim cellRange As CellRange = vsfCollect.GetCellRange(llngCnt, CMlngGridRowCol_0, _
                                                                        llngCnt, vsfCollect.Cols.Count - 1)
                                    cellRange.Style = newStyle
                                End If
                            Else
                                '@入力済／入力不要色を初期設定
                                Dim newStyle As CellStyle = vsfCollect.Styles.Add("CustomStyle_BackColor_CMlngOKBackColor" + llngCnt.ToString)
                                newStyle.BackColor = ColorTranslator.FromWin32(CMlngOKBackColor)
                                Dim cellRange As CellRange = vsfCollect.GetCellRange(llngCnt, CMlngGridRowCol_0, _
                                                                 llngCnt, vsfCollect.Cols.Count - 1)
                                cellRange.Style = newStyle
                            End If
                        Next llngCnt
                    Else
                    '@入力欄が"要"の場合
                        '@入力欄が空欄の場合
                        For llngCnt = 1 To vsfCollect.Rows.Count - 1
                            If vsfCollect.GetData(llngCnt, CMlngvsfCollectMandatoryCountC) > 0 Then
                                '@選択ﾊﾟﾗﾒｰﾀによる処理判別
                                If vsfCollect.GetData(llngCnt, CMlngvsfCollectMeasureMode) = CMstrOne Then
                                '@ﾊﾟﾗﾒｰﾀがｵﾝﾗｲﾝの場合
                                    Dim newStyle As CellStyle = vsfCollect.Styles.Add("CustomStyle_BackColor_CMlngOKBackColor" + llngCnt.ToString)
                                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngOKBackColor)
                                    Dim cellRange As CellRange = vsfCollect.GetCellRange(llngCnt, CMlngGridRowCol_0, _
                                                                     llngCnt, vsfCollect.Cols.Count - 1)
                                    cellRange.Style = newStyle
                                Else
                                '@ﾊﾟﾗﾒｰﾀがｵﾝﾗｲﾝ/ｵﾌﾗｲﾝ,ｵﾌﾗｲﾝの場合
                                    Dim newStyle As CellStyle = vsfCollect.Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor" + llngCnt.ToString)
                                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                                    Dim cellRange As CellRange = vsfCollect.GetCellRange(llngCnt, CMlngGridRowCol_0, _
                                                                     llngCnt, vsfCollect.Cols.Count - 1)
                                    cellRange.Style = newStyle
                                End If
                            Else
                                Dim newStyle As CellStyle = vsfCollect.Styles.Add("CustomStyle_BackColor_CMlngOKBackColor" + llngCnt.ToString)
                                newStyle.BackColor = ColorTranslator.FromWin32(CMlngOKBackColor)
                                Dim cellRange As CellRange = vsfCollect.GetCellRange(llngCnt, CMlngGridRowCol_0, _
                                                                 llngCnt, vsfCollect.Cols.Count - 1)
                                cellRange.Style = newStyle
                            End If
                        Next llngCnt
                    End If
                End With
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCollect_Color"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCollectValue_Init
    '機　能：ﾊﾟﾗﾒｰﾀ入力用一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 11:13:57 S.Deguchi
    '更新日：2006/01/18 (Wed) 09:29:52 T.Kitagawa
    '　　　：2008/04/07 (Mon) 07:56:25 T.Sawaguchi
    '備　考：
    '　　　：2006/01/18 (Wed) 09:29:52 T.Kitagawa   ﾕｰｻﾞｰ要望№0135対応(ExtendLastCol=False)
    '　　　：2008/04/07 (Mon) 07:56:25 T.Sawaguchi  ｸﾞﾘｯﾄﾞ高さ制御追加　案件No02761　対応

    Private Sub prvvsfCollectValue_Init()

        Try
            
            '@ﾊﾟﾗﾒｰﾀ入力項目の初期化
            With vsfCollectValue
                '@ｸﾘｱ
                .Row = 0
                
                '@行数、列数の初期設定(行:1/列:1)
                .Rows.Count = CMlngOne
                .Cols.Count = CMlngOne
                
                '@ﾀｲﾄﾙの設定(背景色：紺)
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngBlueColor")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                Dim cellRange As CellRange = .GetCellRange(CMlngGridRowCol_0, CMlngGridRowCol_0, _
                                       CMlngGridRowCol_0, .Cols.Count - 1)
                cellRange.Style = newStyle
                .Styles.Fixed.Trimming = StringTrimming.None                '省略符号(...)表示なし
                
                '@ﾀｲﾄﾙの高さ
                .Rows(CMlngGridRowCol_0).Height = CMlngvsfTitleHeight       'CMlngvsfTitleHeightへ変更
                
                '@使用不可
                '.Enabled = False
            
                '@最終列をｸﾞﾘｯﾄﾞの右端に合わせない(※画面とは異なるが、ﾕｰｻﾞ要望により変更とする)
                .ExtendLastCol = False
                '@列幅設定
                .Cols(CMlngvsfCollectValueNoC).Width = 0
                
                cmdVsfUpCollectValue.Enabled = False
                cmdVsfDownCollectValue.Enabled = False

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCollectValue_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCollectValue_Set
    '機　能：ﾊﾟﾗﾒｰﾀ入力用一覧のﾀｲﾄﾙ設定
    '引　数：llngDispRow：表示ﾀｲﾄﾙ行
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 17:38:07 S.Deguchi
    '更新日：2005/06/21 (Tue) 16:24:28 N.Kojima
    '　　　：2008/04/10 (Thu) 13:40:29 T.Sawaguchi
    '備　考：
    '　　　：2005/06/21 (Tue) 16:24:28 N.Kojima       結果欄削除(不具合№883)
    '　　　：2008/04/04 (Fri) 16:04:55 T.Sawaguchi    ｸﾞﾘｯﾄﾞ高さ制御追加　案件No02761　対応
    Private Sub prvvsfCollectValue_Set(ByVal llngDispRow As Integer)

        Dim llngCnt             As Integer      'ﾙｰﾌﾟｶｳﾝﾀ

        Try

            With vsfCollectValue
                '@ｸﾘｱ
                RemoveHandler vsfCollectValue.EnterCell,AddressOf vsfCollectValue_Entercell
            
                '@行設定
                .Rows.Count = CMlngOne
                
                '@列設定
                .Cols.Count = CMstrvsfCollectValueCols
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngGridRowCol_0, CMlngvsfCollectValueNoC, CMstrvsfNoTitle)                             'ﾀｲﾄﾙ
                
                .SetData(CMlngGridRowCol_0, CMlngvsfCollectValueClass1C, _
                    mtypLotCollectParamsList.typLotCollectParams(llngDispRow - 1).strClassification1)             'ﾃﾞｰﾀ分類1名
                
                .SetData(CMlngGridRowCol_0, CMlngvsfCollectValueClass2C, _
                    mtypLotCollectParamsList.typLotCollectParams(llngDispRow - 1).strClassification2)             'ﾃﾞｰﾀ分類2名
                
                .SetData(CMlngGridRowCol_0, CMlngvsfCollectValueClass3C, _
                    mtypLotCollectParamsList.typLotCollectParams(llngDispRow - 1).strClassification3)             'ﾃﾞｰﾀ分類3名
                
                .SetData(CMlngGridRowCol_0, CMlngvsfCollectValueClass4C, _
                    mtypLotCollectParamsList.typLotCollectParams(llngDispRow - 1).strClassification4)             'ﾃﾞｰﾀ分類4名
                
                .SetData(CMlngGridRowCol_0, CMlngvsfCollectValueDataC, CMstrvsfCollectValueDataT)                 '値
                
                '@ﾀｲﾄﾙ色、位置
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbYellow")
                newStyle.ForeColor = color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                newStyle.TextAlign = TextAlignEnum.CenterCenter
                Dim cellRange As CellRange = .GetCellRange(CMlngGridRowCol_0, CMlngGridRowCol_0, CMlngGridRowCol_0, .Cols.Count - 1)
                cellRange.Style = newStyle
                
                '@行高さ
                .Rows(CMlngGridRowCol_0).Height = CMlngvsfTitleHeight           'CMlngGridTitleHeight → CMlngvsfTitleHeight へ変更
                
                '@列幅の自動調整
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngGridRowCol_0, .Cols.Count - 1, 6)
                .AllowResizing = AllowResizingEnum.Columns       'ﾏｳｽよる列ｻｲｽﾞ変更の可／不可

                .Col = 0
                AddHandler vsfCollectValue.EnterCell,AddressOf vsfCollectValue_Entercell
            
                '@列設定(ﾀｲﾄﾙが空欄の場合には,非表示とする)
                For llngCnt = 1 To .Cols.Count - 1
                    If .GetData(CMlngGridRowCol_0, llngCnt) = vbNullString Then
                        '@非表示
                        .Cols(llngCnt).Visible = False
                    Else
                        '@表示
                        .Cols(llngCnt).Visible = True
                    End If
                Next llngCnt
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCollectValue_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCollectValue_Disp
    '機　能：ﾊﾟﾗﾒｰﾀ入力用一覧の表示(情報取得後表示処理)
    '引　数：ltypwfCollectionInfo：ﾊﾟﾗﾒｰﾀ情報
    '　　　：llngDispRow：ﾊﾟﾗﾒｰﾀ項目一覧の選択行数
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 17:15:59 S.Deguchi
    '更新日：2008/04/04 (Fri) 16:08:47 T.Sawaguchi
    '備　考：
    '　　　：2005/06/07 (Tue) 17:31:36 N.Kasai      表示位置修正
    '　　　：2005/06/14 (Tue) 17:03:01 N.Kojima     結果判定処理ｺﾒﾝﾄｱｳﾄ(不具合№883)
    '　　　：2006/12/21 (Thu) 13:46:52 N.Kasai      収集項目ﾀｲﾌﾟ追加(№01515)
    '　　　：2008/04/04 (Fri) 16:09:01 T.Sawaguchi  ﾍﾟｰｼﾞ送りﾎﾞﾀﾝ,ｸﾞﾘｯﾄﾞ高さ制御追加　案件No02761　対応

    Private Sub prvvsfCollectValue_Disp(ByRef ltypwfCollectionInfo As WfCollectionInfo, ByVal llngDispRow As Integer)

        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngNextInfoIndex       As Integer              '引継ぎ構造体のIndex(0:なし、1:引継ぎ構造体のIndex)
        Dim lstrInputDataDispFlag   As String               '入力済のﾃﾞｰﾀ表示ﾌﾗｸﾞ(NULL；表示無し、)
        Dim lblnEnable              As Boolean              'NSYS GridのEnable
        Dim llngFindRow             As Integer

        Try
            '＠変数初期化
            lstrInputDataDispFlag = vbNullString

            '@入力済みﾊﾟﾗﾒｰﾀの表示
            With vsfCollectValue
                '@装置ﾃﾞｰﾀ表示
                .Redraw = False

                If ltypwfCollectionInfo.lngWfCollectionInfoListCnt > 0 Then
                '@入力ﾃﾞｰﾀが"0"件以上の場合
                    '@行設定
                    RemoveHandler vsfCollectValue.EnterCell,AddressOf vsfCollectValue_EnterCell
                    .Rows.Count = ltypwfCollectionInfo.lngWfCollectionInfoListCnt + 1
                    AddHandler vsfCollectValue.EnterCell,AddressOf vsfCollectValue_EnterCell
                    lstrInputDataDispFlag = CMstrDataDivisionDisp
                    '@ｸﾞﾘｯﾄﾞ表示
                    For llngCnt = 1 To ltypwfCollectionInfo.lngWfCollectionInfoListCnt
                        .SetData(llngCnt, CMlngvsfCollectValueNoC, llngCnt)                                          '№
                        
                        .SetData(llngCnt, CMlngvsfCollectValueClass1C, _
                            ltypwfCollectionInfo.typWfCollectionInfoList(llngCnt - 1).strClassification1)            'ﾃﾞｰﾀ分類1名
                        
                        .SetData(llngCnt, CMlngvsfCollectValueClass2C, _
                            ltypwfCollectionInfo.typWfCollectionInfoList(llngCnt - 1).strClassification2)            'ﾃﾞｰﾀ分類2名
                        
                        .SetData(llngCnt, CMlngvsfCollectValueClass3C, _
                            ltypwfCollectionInfo.typWfCollectionInfoList(llngCnt - 1).strClassification3)            'ﾃﾞｰﾀ分類3名
                        
                        .SetData(llngCnt, CMlngvsfCollectValueClass4C, _
                            ltypwfCollectionInfo.typWfCollectionInfoList(llngCnt - 1).strClassification4)            'ﾃﾞｰﾀ分類4名
                        
                        .SetData(llngCnt, CMlngvsfCollectValueDataC, _
                            ltypwfCollectionInfo.typWfCollectionInfoList(llngCnt - 1).strData)                       '値
                        
                        '@収集項目ﾀｲﾌﾟが1:装置ﾃﾞｰﾀの場合
                        If vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectCollectionType) = CMstrOne Then
                        
                            '@背景色を薄い灰色とする(情報があるということは,入力・登録済みと言うことなので,編集不可設定とする)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngNotInputColor" + llngCnt.ToString)
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngNotInputColor)
                            Dim cellRange As CellRange = .GetCellRange(CMlngOne, CMlngvsfCollectValueNoC, _
                                                   .Rows.Count - 1, CMlngvsfCollectValueDataC)
                            cellRange.Style = newStyle       '薄い灰色
                        End If
                    Next llngCnt
                            
                    '@一覧へ表示した内容の各種設定
                    With vsfCollectValue
                        
                        For llngCnt = 1 To .Rows.Count - 1
                            
                            '@値位置の設定
                            If vsfCollect.GetData(llngDispRow, CMlngvsfCollectDataTypeC) = CMstrDataTypeN Then
                                '@数字ﾀｲﾌﾟの場合は右寄
                                .Cols(CMlngvsfCollectValueDataC).TextAlign = TextAlignEnum.RightCenter
                            Else
                                '@文字ﾀｲﾌﾟの場合は左寄
                                .Cols(CMlngvsfCollectValueDataC).TextAlign = TextAlignEnum.LeftCenter
                            End If
                            
                            '@高さ設定
                            .Rows(llngCnt).Height = CMlngvsfRowHeight  'CMlngGridRowHeight→CMlngvsfRowHeightへ変更
                        Next llngCnt
                        .Rows.DefaultSize = CMlngvsfRowHeight
                        
                        '@ﾃﾞｰﾀ分類名列の非表示設定(ﾀｲﾄﾙと内容がNullの場合は非表示とする)
                        '@ﾃﾞｰﾀ分類1名の非表示判定
                        '@ﾌﾗｸﾞ初期化
                        llngFindRow = -1
                        For llngCnt = 0 To .Rows.Count - 1
                            '@ﾃﾞｰﾀが何かしらある場合にｶｳﾝﾄｱｯﾌﾟ
                            If .GetData(llngCnt, CMlngvsfCollectValueClass1C) <> vbNullString And _
                                .GetData(llngCnt, CMlngvsfCollectValueClass1C) <> CMstrNaString Then
                                llngFindRow = llngCnt
                                Exit For
                            End If
                        Next llngCnt
                        
                        '@ﾌﾗｸﾞ判定
                        If llngFindRow = -1 Then
                            '@Col非表示
                            .Cols(CMlngvsfCollectValueClass1C).Visible = False
                        Else
                            '@Col表示
                            .Cols(CMlngvsfCollectValueClass1C).Visible = True
                        End If
                        
                        '@ﾃﾞｰﾀ分類2名の非表示判定(ﾀｲﾄﾙと内容がNullの場合は非表示とする)
                        '@ﾌﾗｸﾞ初期化
                        llngFindRow = -1
                        For llngCnt = 0 To .Rows.Count - 1
                            '@ﾃﾞｰﾀが何かしらある場合にｶｳﾝﾄｱｯﾌﾟ
                            If .GetData(llngCnt, CMlngvsfCollectValueClass2C) <> vbNullString And _
                                .GetData(llngCnt, CMlngvsfCollectValueClass2C) <> CMstrNaString Then
                                llngFindRow = llngCnt
                                Exit For
                            End If
                        Next llngCnt

                        '@ﾌﾗｸﾞ判定
                        If llngFindRow = -1 Then
                            .Cols(CMlngvsfCollectValueClass2C).Visible = False
                        Else
                            .Cols(CMlngvsfCollectValueClass2C).Visible = True
                        End If
                        
                        '@ﾃﾞｰﾀ分類3名の非表示判定(ﾀｲﾄﾙと内容がNullの場合は非表示とする)
                        '@ﾌﾗｸﾞ初期化
                        llngFindRow = -1
                        For llngCnt = 0 To .Rows.Count - 1
                            '@ﾃﾞｰﾀが何かしらある場合にｶｳﾝﾄｱｯﾌﾟ
                            If .GetData(llngCnt, CMlngvsfCollectValueClass3C) <> vbNullString And _
                                .GetData(llngCnt, CMlngvsfCollectValueClass3C) <> CMstrNaString Then
                                llngFindRow = llngCnt
                                Exit For
                            End If
                        Next llngCnt
                        
                        '@ﾌﾗｸﾞ判定
                        If llngFindRow = -1 Then
                            .Cols(CMlngvsfCollectValueClass3C).Visible = False
                        Else
                            .Cols(CMlngvsfCollectValueClass3C).Visible = True
                        End If
                        
                        '@ﾃﾞｰﾀ分類4名の非表示判定(ﾀｲﾄﾙと内容がNullの場合は非表示とする)
                        '@ﾌﾗｸﾞ初期化
                        llngFindRow = -1
                        For llngCnt = 0 To .Rows.Count - 1
                            '@ﾃﾞｰﾀが何かしらある場合にｶｳﾝﾄｱｯﾌﾟ
                            If .GetData(llngCnt, CMlngvsfCollectValueClass4C) <> vbNullString And _
                                .GetData(llngCnt, CMlngvsfCollectValueClass4C) <> CMstrNaString Then
                                llngFindRow = llngCnt
                                Exit For
                            End If
                        Next llngCnt
                        
                        '@ﾌﾗｸﾞ判定
                        If llngFindRow = -1 Then
                            .Cols(CMlngvsfCollectValueClass4C).Visible = False
                        Else
                            .Cols(CMlngvsfCollectValueClass4C).Visible = True
                        End If
                        
                        '@使用可設定
                        If .Rows.Count > 1 Then
                            '@ﾛｯｸ解除
                            lblnEnable = True
                        End If
                    End With
            
                    '@列幅の自動調整
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(CMlngGridRowCol_0, .Cols.Count - 1, 6)
                    .AllowResizing = AllowResizingEnum.Columns      'ﾏｳｽよる列ｻｲｽﾞ変更の可／不可

                    '@ﾊﾟﾗﾒｰﾀ項目の色設定
                    Call prvvsfCollect_Color()

                    '@ﾛｯｸ解除
                    lblnEnable = True
                Else
                '@入力ﾃﾞｰﾀが"0"件の場合
                    '@装置の状態がｵﾝﾗｲﾝか否かで処理分岐
                    If vsfCollect.GetData(llngDispRow, CMlngvsfCollectMeasureMode) <> CMstrOne Then
                        '@ｵﾝﾗｲﾝでない場合,入力ﾌｨｰﾙﾄﾞを作成する
                        RemoveHandler vsfCollectValue.EnterCell,AddressOf vsfCollectValue_EnterCell
                        If vsfCollect.GetData(llngDispRow, CMlngvsfCollectMandatoryCountC) > 0 Then
                            '@行追加
                            .Rows.Count = CLng(vsfCollect.GetData(llngDispRow, CMlngvsfCollectMandatoryCountC)) + 1
                        Else
                            .Rows.Count = .Rows.Count + 1
                        End If
                        AddHandler vsfCollectValue.EnterCell,AddressOf vsfCollectValue_EnterCell
                        
                        '@入力ﾌｨｰﾙﾄﾞ作成
                        '@2008/09/10 Sawa
                        For llngCnt = 1 To .Rows.Count - 1
                            
                            .SetData(llngCnt, CMlngvsfCollectValueNoC, llngCnt)
                            
                            '@工程端末ｻｲｽﾞに設定に高さを設定
                            .Rows(llngCnt).Height = CMlngvsfRowHeight     '
                        Next llngCnt
                        .Rows.DefaultSize = CMlngvsfRowHeight
                    End If

                    '@ﾊﾟﾗﾒｰﾀ項目の色設定
                    Call prvvsfCollect_Color()

                    '@ﾛｯｸ解除
                    lblnEnable = True
                End If
            End With
            
            '@ﾌｫｰｶｽ設定
            With vsfCollectValue
                .KeyActionTab = KeyActionEnum.None      'ｺﾝﾄﾛｰﾙTAB設定
                If lblnEnable = True Then
                    '@入力時はｾﾙ単位にﾌｫｰｶｽ移動
                    .KeyActionTab = KeyActionEnum.MoveAcross
                    
                    '@引継ぎ情報が設定されている場合は即時確定OKとする
                    If lblnEnable = True And llngNextInfoIndex > 0 And .Rows.Count > 2 Then
                        .Row = 1
                    Else
                        .Row = 0
                    End If
                    
                    '@前頁、次頁ｽｸﾛｰﾙﾎﾞﾀﾝ表示設定
                    If .Rows.Count > CMvsfCollectValueVisibleRows Then
                        If lstrInputDataDispFlag = vbNullString Then
                            cmdVsfUpCollectValue.Enabled = True
                        Else
                            cmdVsfUpCollectValue.Enabled = False
                        End If
                        cmdVsfDownCollectValue.Enabled = True
                    Else
                        cmdVsfUpCollectValue.Enabled = False
                        cmdVsfDownCollectValue.Enabled = False
                    End If
                End If

                '@直接描画
                .Redraw = True

                'NSYS Gridの有効/無効化
                .Enabled = lblnEnable

                .Rows(CMlngGridRowCol_0).Height = CMlngvsfTitleHeight  'CMlngGridRowHeight → CMlngvsfTitleHeight へ変更
            End With
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期制御
            cmdLineInsert.Enabled = False   '行追加ﾎﾞﾀﾝ
            cmdLineDelete.Enabled = False   '行削除ﾎﾞﾀﾝ
            cmdNaInput.Enabled = False      '値未入力ﾎﾞﾀﾝ
            cmdRegist.Enabled = False       '確定ﾎﾞﾀﾝ

        Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCollectValue_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvParameterInfo_Set
    '機　能：ﾊﾟﾗﾒｰﾀ情報を確定構造体にｾｯﾄ処理(初期設定)
    '引　数：lstrWFID：WFID
    '戻り値：なし
    '作成日：2005/01/20 (Thu) 15:18:45 S.Deguchi
    '更新日：2007/01/24 (Wed) 10:11:26 N.Kasai
    '備　考：
    '　　　：2006/12/20 (Wed) 16:20:14 N.Kasai      収集項目ﾀｲﾌﾟ追加(№01515)
    '　　　：2007/01/24 (Wed) 10:11:26 N.Kasai      CEID追加(№01428)
    Private Sub prvParameterInfo_Set(ByVal lstrWFID As String)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾀ1

        Try
            
            '@初期化
            If mtypDataCollect.typParameter Is Nothing Then
                mtypDataCollect.typParameter = New List(Of Parameter)
            Else
                mtypDataCollect.typParameter.Clear()
            End If
            mtypDataCollect.lngParameterCnt = 0
            mtypDataCollect.strChgID = vbNullString

            '@ﾛｯﾄ/WF単位でﾊﾟﾗﾒｰﾀの設定と入力ﾃﾞｰﾀ欄の領域確保を行う
            With mtypDataCollect
                '@IDを退避
                If optDataUnit1.Checked = True Then
                    '@ﾛｯﾄ単位の場合には,ﾛｯﾄIDをｾｯﾄ
                    .strChgID = txtLot.Text
                Else
                    '@WF単位の場合には,WFIDをｾｯﾄ
                    .strChgID = lstrWFID
                End If
                
                '@収集項目ID
                .strCollectionID = mstrCollectionID
                
                '@収集項目Ver
                .strCollectionVersion = mstrCollectionVersion
                
                '@大工程
                .strOpID = lblOpID.Text
                
                '@小工程
                .strStepID = lblStepID.Text
                
                '@ﾊﾟﾗﾒｰﾀ情報数をｾｯﾄ
                .lngParameterCnt = mtypLotCollectParamsList.llngLotCollectParamsCnt
                '@領域確保
                Dim typParametertmp As Parameter
                
                '@ﾊﾟﾗﾒｰﾀ情報をｾｯﾄする
                For llngCnt = 0 To mtypLotCollectParamsList.llngLotCollectParamsCnt - 1
                    'NSYS 領域追加構造体初期化
                    typParametertmp = New Parameter
                    '@ﾊﾟﾗﾒｰﾀｾｯﾄ
                    typParametertmp.strParameterID = _
                        mtypLotCollectParamsList.typLotCollectParams(llngCnt).strParameterID                'ﾊﾟﾗﾒｰﾀID
                    
                    typParametertmp.strParameterVersion = _
                        mtypLotCollectParamsList.typLotCollectParams(llngCnt).strParameterVersion           'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
                
                    typParametertmp.strRiftainFlag = _
                        mtypLotCollectParamsList.typLotCollectParams(llngCnt).strDataRetainFlag             '引継ﾌﾗｸﾞ
                    
                    typParametertmp.strMeasureMode = _
                        mtypLotCollectParamsList.typLotCollectParams(llngCnt).strMeasureMode                '測定ﾓｰﾄﾞ
                    
                    typParametertmp.strMandatoryCount = _
                        mtypLotCollectParamsList.typLotCollectParams(llngCnt).strMandatoryCount             '必須項目数
                    
                    If mtypLotCollectParamsList.typLotCollectParams(llngCnt).strMeasureMode = CMstrOne Then
                        typParametertmp.strInputDataFlag = CMstrFour                                        '入力ﾃﾞｰﾀﾌﾗｸﾞ(4:ｵﾝﾗｲﾝ)
                    Else
                        typParametertmp.strInputDataFlag = CMstrZero                                        '入力ﾃﾞｰﾀﾌﾗｸﾞ(0:無)
                    End If
                    
                    typParametertmp.strNextParameterInputFlag = CMstrZero                                   'ﾊﾟﾌﾞﾘｯｸへ登録済みﾌﾗｸﾞ(0:未)
                
                    typParametertmp.strCollectionType = _
                        mtypLotCollectParamsList.typLotCollectParams(llngCnt).strCollectionType             '収集項目ﾀｲﾌﾟ(0:作業記録/1:装置ﾃﾞｰﾀ)
                    
                    typParametertmp.strCeId = _
                        mtypLotCollectParamsList.typLotCollectParams(llngCnt).strCeId                       'CEID(0:正/1:異/Null:正)
                    .typParameter.Add(typParametertmp)
                Next llngCnt
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvParameterInfo_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvParameterInputData_Set
    '機　能：入力ﾃﾞｰﾀを確定構造体にｾｯﾄ
    '引　数：lstrParameterID：ﾊﾟﾗﾒｰﾀID
    '戻り値：なし
    '作成日：2005/01/21 (Fri) 11:45:26 S.Deguchi
    '更新日：2008/04/04 (Fri) 16:19:15 T.Sawaguchi
    '備　考：
    '　　　：2005/06/14 (Tue) 17:04:00 N.Kojima     判定結果格納処理をｺﾒﾝﾄｱｳﾄ(不具合№883)
    '　　　：2007/06/08 (Fri) 13:55:45 N.Kasai      .Cell(flexcpVariantValue→.Cell(flexcptextへ変更 012→12となる為
    '　　　：2008/04/04 (Fri) 16:19:35 T.Sawaguchi  ﾍﾟｰｼﾞ送りﾎﾞﾀﾝ制御追加　案件No02761　対応
    Private Sub prvParameterInputData_Set(ByVal lstrParameterID As String)

        Dim llngCnt1            As Integer      'ﾙｰﾌﾟｶｳﾝﾀ1
        Dim llngCnt2            As Integer      'ﾙｰﾌﾟｶｳﾝﾀ2
        Dim llngInputDataCnt    As Integer      '入力ﾃﾞｰﾀ数

        Try
            
            With mtypDataCollect
                '@選択されているﾊﾟﾗﾒｰﾀIDが確定処理構造体にｾｯﾄされている場合
                For llngCnt1 = 0 To .lngParameterCnt - 1
                    '@同じﾊﾟﾗﾒｰﾀIDの場合
                    If .typParameter(llngCnt1).strParameterID = lstrParameterID Then
                        '@入力情報のﾃﾞｰﾀ数による分岐(ﾀｲﾄﾙ以上のみ処理)
                        If vsfCollectValue.Rows.Count - 1 > 0 Then
                            Dim typParametertmp As Parameter = .typParameter(llngCnt1)
                            typParametertmp.typInputData = New List(Of WFDvName)
                            '@表示情報数分の領域を確保
                            typParametertmp.lngInputDataCnt = vsfCollectValue.Rows.Count - 1
                            llngInputDataCnt = vsfCollectValue.Rows.Count - 1

                            '@ﾊﾟﾗﾒｰﾀ入力領域を確保
                            Dim typInputDatatmp As WFDvName

                            '@登録済み情報をｾｯﾄする
                            For llngCnt2 = 1 To llngInputDataCnt
                                'NSYS ADD要素格納変数初期化
                                typInputDatatmp = New WFDvName
                                '@行№
                                typInputDatatmp.strNo = _
                                    vsfCollectValue.GetData(llngCnt2, CMlngvsfCollectValueNoC)
                                
                                '@ﾃﾞｰﾀ分類1
                                typInputDatatmp.strClass1 = _
                                    vsfCollectValue.GetData(llngCnt2, CMlngvsfCollectValueClass1C)
                                
                                '@ﾃﾞｰﾀ分類1名表示ﾌﾗｸﾞ判定
                                If vsfCollectValue.Cols(CMlngvsfCollectValueClass1C).Visible = False Then
                                    '@ﾌﾗｸﾞ：0 = 非表示
                                    typInputDatatmp.strClass1Disp = CMstrZero
                                Else
                                    '@ﾌﾗｸﾞ：1 = 表示
                                    typInputDatatmp.strClass1Disp = CMstrOne
                                End If
                                
                                '@ﾃﾞｰﾀ分類2
                                typInputDatatmp.strClass2 = _
                                    vsfCollectValue.GetData(llngCnt2, CMlngvsfCollectValueClass2C)
                                
                                '@ﾃﾞｰﾀ分類2名表示ﾌﾗｸﾞ判定
                                If vsfCollectValue.Cols(CMlngvsfCollectValueClass2C).Visible = False Then
                                    '@ﾌﾗｸﾞ：0 = 非表示
                                    typInputDatatmp.strClass2Disp = CMstrZero
                                Else
                                    '@ﾌﾗｸﾞ：1 = 表示
                                    typInputDatatmp.strClass2Disp = CMstrOne
                                End If
                                
                                '@ﾃﾞｰﾀ分類3
                                typInputDatatmp.strClass3 = _
                                    vsfCollectValue.GetData(llngCnt2, CMlngvsfCollectValueClass3C)
                                
                                '@ﾃﾞｰﾀ分類3名表示ﾌﾗｸﾞ判定
                                If vsfCollectValue.Cols(CMlngvsfCollectValueClass3C).Visible = False Then
                                    '@ﾌﾗｸﾞ：0 = 非表示
                                    typInputDatatmp.strClass3Disp = CMstrZero
                                Else
                                    '@ﾌﾗｸﾞ：1 = 表示
                                    typInputDatatmp.strClass3Disp = CMstrOne
                                End If
                                
                                '@ﾃﾞｰﾀ分類4
                                typInputDatatmp.strClass4 = _
                                    vsfCollectValue.GetData(llngCnt2, CMlngvsfCollectValueClass4C)
                                
                                '@ﾃﾞｰﾀ分類4名表示ﾌﾗｸﾞ判定
                                If vsfCollectValue.Cols(CMlngvsfCollectValueClass4C).Visible = False Then
                                    '@ﾌﾗｸﾞ：0 = 非表示
                                    typInputDatatmp.strClass4Disp = CMstrZero
                                Else
                                    '@ﾌﾗｸﾞ：1 = 表示
                                    typInputDatatmp.strClass4Disp = CMstrOne
                                End If
                                
                                '@値
                                typInputDatatmp.strData = _
                                    vsfCollectValue.GetData(llngCnt2, CMlngvsfCollectValueDataC)
                                typParametertmp.typInputData.Add(typInputDatatmp)  
                            Next llngCnt2
                            .typParameter(llngCnt1) = typParametertmp
                        End If
                    End If
                Next llngCnt1

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvParameterInputData_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvParameterInputData_Disp
    '機　能：確定構造体から入力ﾃﾞｰﾀをｸﾞﾘｯﾄﾞにｾｯﾄ
    '引　数：lstrParameterID：ﾊﾟﾗﾒｰﾀID
    '戻り値：なし
    '作成日：2005/01/21 (Fri) 15:32:57 S.Deguchi
    '更新日：2008/04/04 (Fri) 16:20:10 T.Sawaguchi
    '備　考：
    '　　　：2005/06/14 (Tue) 17:04:30 N.Kojima     「結果」欄削除に伴うﾛｼﾞｯｸの修正。(不具合№883)
    '　　　：2008/04/04 (Fri) 16:20:27 T.Sawaguchi   ｸﾞﾘｯﾄﾞ高さ制御追加　案件No02761　対応

    Private Sub prvParameterInputData_Disp(ByVal lstrParameterID As String)

        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngFindRow             As Integer      '検索行
        Dim llngNextInfoIndex       As Integer      '引継ぎ構造体のIndex(0:なし、1:引継ぎ構造体のIndex)
        Dim lstrData                As String       '表示ﾃﾞｰﾀ

        Try
            
            '@装置ﾃﾞｰﾀのﾀｲﾄﾙ設定
            With vsfCollectValue
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@行数、列数の初期設定
                .Rows.Count = 1
                .Cols.Count = CMlngvsfCollectValueDataC + 1
                .Col = 0
                
                '@ﾀｲﾄﾙの設定
                .SetData(CMlngGridRowCol_0, CMlngvsfCollectValueNoC, CMstrvsfNoTitle)                     'ﾀｲﾄﾙ
                
                .SetData(CMlngGridRowCol_0, CMlngvsfCollectValueClass1C, _
                    vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectClass1C))                             'ﾃﾞｰﾀ分類1名
                
                .SetData(CMlngGridRowCol_0, CMlngvsfCollectValueClass2C, _
                    vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectClass2C))                             'ﾃﾞｰﾀ分類2名
                
                .SetData(CMlngGridRowCol_0, CMlngvsfCollectValueClass3C, _
                    vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectClass3C))                             'ﾃﾞｰﾀ分類3名
                
                .SetData(CMlngGridRowCol_0, CMlngvsfCollectValueClass4C, _
                    vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectClass4C))                             'ﾃﾞｰﾀ分類4名
            
                .SetData(CMlngGridRowCol_0, CMlngvsfCollectValueDataC, CMstrvsfCollectValueDataT)         '値

                '@ﾀｲﾄﾙ色、位置
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbYellow")
                newStyle.ForeColor = Color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                newStyle.TextAlign = TextAlignEnum.CenterCenter
                Dim cellRange As CellRange = .GetCellRange(CMlngGridRowCol_0, CMlngGridRowCol_0, _
                                       CMlngGridRowCol_0, CMlngvsfCollectValueDataC)
                cellRange.Style = newStyle
                                       
                .Rows(CMlngGridRowCol_0).Height = CMlngvsfTitleHeight       'CMlngGridTitleHeight → CMlngvsfTitleHeight
                
                '@列幅設定
                .Cols(CMlngvsfCollectValueNoC).Width = CMlngvsfCollectValueNoW
                .Cols(CMlngvsfCollectValueClass1C).Width = CMlngvsfCollectValueClass1W
                .Cols(CMlngvsfCollectValueClass2C).Width = CMlngvsfCollectValueClass2W
                .Cols(CMlngvsfCollectValueClass3C).Width = CMlngvsfCollectValueClass3W
                .Cols(CMlngvsfCollectValueClass4C).Width = CMlngvsfCollectValueClass4W
                .Cols(CMlngvsfCollectValueDataC).Width = CMlngvsfCollectValueDataW

                '@描画ﾛｯｸ解除
                .Redraw = True
            End With
            
            '@装置ﾃﾞｰﾀのｸﾞﾘｯﾄﾞ内容設定
            If mtypDataCollect.lngParameterCnt = 0 Then
                '@処理終了
                Exit Sub
            End If
            
            '@引継ぎﾊﾟﾗﾒｰﾀのｶｳﾝﾄ取得
            '@初期化処理
            llngCnt = 0
            llngNextInfoIndex = - 1
            
            '@ﾓｼﾞｭｰﾙ変数に退避していたﾊﾟﾗﾒｰﾀIDと比較
            For llngCnt = 0 To mtypDataCollect.lngParameterCnt - 1
                '@引継ぎﾊﾟﾗﾒｰﾀのIDを引き継ぐ
                If lstrParameterID = mtypDataCollect.typParameter(llngCnt).strParameterID Then
                    '@行番号を取得
                    llngNextInfoIndex = llngCnt
                End If
            Next llngCnt
            
            '@引継情報が存在しない場合
            If llngNextInfoIndex = - 1 Then
                '@処理終了
                Exit Sub
            End If

            '@入力ﾊﾟﾗﾒｰﾀﾃﾞｰﾀの行数を設定
            RemoveHandler vsfCollectValue.EnterCell ,AddressOf vsfCollectValue_EnterCell
            vsfCollectValue.Rows.Count = mtypDataCollect.typParameter(llngNextInfoIndex).lngInputDataCnt + 1
            AddHandler vsfCollectValue.EnterCell ,AddressOf vsfCollectValue_EnterCell
            
            '@ﾓｼﾞｭｰﾙ変数の内容を一覧へｾｯﾄ
            For llngCnt = 1 To mtypDataCollect.typParameter(llngNextInfoIndex).lngInputDataCnt
                With mtypDataCollect.typParameter(llngNextInfoIndex).typInputData(llngCnt - 1)
                    '@番号(№)
                    vsfCollectValue.SetData(llngCnt, CMlngvsfCollectValueNoC, .strNo)    '№
                    
                    '@ﾃﾞｰﾀ分類1
                    If .strClass1 = vbNullString Then
                        vsfCollectValue.SetData(llngCnt, CMlngvsfCollectValueClass1C, lstrData)
                    Else
                        vsfCollectValue.SetData(llngCnt, CMlngvsfCollectValueClass1C, .strClass1)
                    End If
                    
                    '@ﾃﾞｰﾀ分類2
                    If .strClass2 = vbNullString Then
                        vsfCollectValue.SetData(llngCnt, CMlngvsfCollectValueClass2C, lstrData)
                    Else
                        vsfCollectValue.SetData(llngCnt, CMlngvsfCollectValueClass2C, .strClass2)
                    End If
                    
                    '@ﾃﾞｰﾀ分類3
                    If .strClass3 = vbNullString Then
                        vsfCollectValue.SetData(llngCnt, CMlngvsfCollectValueClass3C, lstrData)
                    Else
                        vsfCollectValue.SetData(llngCnt, CMlngvsfCollectValueClass3C, .strClass3)
                    End If
                    
                    '@ﾃﾞｰﾀ分類4
                    If .strClass4 = vbNullString Then
                        vsfCollectValue.SetData(llngCnt, CMlngvsfCollectValueClass4C, lstrData)
                    Else
                        vsfCollectValue.SetData(llngCnt, CMlngvsfCollectValueClass4C, .strClass4)
                    End If
                    
                    '@値
                    If .strData = vbNullString Then
                        vsfCollectValue.SetData(llngCnt, CMlngvsfCollectValueDataC, lstrData)
                    Else
                        vsfCollectValue.SetData(llngCnt, CMlngvsfCollectValueDataC, .strData)
                    End If
                End With
            Next llngCnt
                
            '@一覧へ表示した内容の各種設定
            With vsfCollectValue
                For llngCnt = 1 To .Rows.Count - 1
                    '@値位置の設定
                    If vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectDataTypeC) = CMstrDataTypeN Then
                        '@数字ﾀｲﾌﾟの場合は右寄
                        .Cols(CMlngvsfCollectValueDataC).TextAlign = TextAlignEnum.RightCenter
                    Else
                        '@文字ﾀｲﾌﾟの場合は左寄
                        .Cols(CMlngvsfCollectValueDataC).TextAlign = TextAlignEnum.LeftCenter
                    End If
                    
                    '@高さ設定
                    .Rows(llngCnt).Height = CMlngvsfRowHeight  'CMlngGridRowHeight→CMlngvsfRowHeightへ変更

                Next llngCnt
                
                '@列幅の自動調整
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngGridRowCol_0, .Cols.Count - 1, 6)
                
                '@ﾏｳｽよる列ｻｲｽﾞ変更の可／不可設定
                .AllowResizing = AllowResizingEnum.Columns

                '@ﾃﾞｰﾀ分類名列の非表示設定(ﾀｲﾄﾙと内容がNullの場合は非表示とする)
                '@ﾃﾞｰﾀ分類1名の非表示判定
                llngFindRow = -1
                For llngCnt = 0 To .Rows.Count - 1
                    If .GetData(llngCnt, CMlngvsfCollectValueClass1C) <> vbNullString And _
                        .GetData(llngCnt, CMlngvsfCollectValueClass1C) <> CMstrNaString Then
                        llngFindRow = llngCnt
                        Exit For
                    End If
                Next llngCnt
                If llngFindRow = -1 Then
                    .Cols(CMlngvsfCollectValueClass1C).Visible = False
                Else
                    .Cols(CMlngvsfCollectValueClass1C).Visible = True
                End If
                
                '@ﾃﾞｰﾀ分類2名の非表示判定(ﾀｲﾄﾙと内容がNullの場合は非表示とする)
                llngFindRow = -1
                For llngCnt = 0 To .Rows.Count - 1
                    If .GetData(llngCnt, CMlngvsfCollectValueClass2C) <> vbNullString And _
                        .GetData(llngCnt, CMlngvsfCollectValueClass2C) <> CMstrNaString Then
                        llngFindRow = llngCnt
                        Exit For
                    End If
                Next llngCnt
                If llngFindRow = -1 Then
                    .Cols(CMlngvsfCollectValueClass2C).Visible = False
                Else
                    .Cols(CMlngvsfCollectValueClass2C).Visible = True
                End If
                
                '@ﾃﾞｰﾀ分類3名の非表示判定(ﾀｲﾄﾙと内容がNullの場合は非表示とする)
                llngFindRow = -1
                For llngCnt = 0 To .Rows.Count - 1
                    If .GetData(llngCnt, CMlngvsfCollectValueClass3C) <> vbNullString And _
                        .GetData(llngCnt, CMlngvsfCollectValueClass3C) <> CMstrNaString Then
                        llngFindRow = llngCnt
                        Exit For
                    End If
                Next llngCnt
                If llngFindRow = -1 Then
                    .Cols(CMlngvsfCollectValueClass3C).Visible = False
                Else
                    .Cols(CMlngvsfCollectValueClass3C).Visible = True
                End If
                
                '@ﾃﾞｰﾀ分類4名の非表示判定(ﾀｲﾄﾙと内容がNullの場合は非表示とする)
                llngFindRow = -1
                For llngCnt = 0 To .Rows.Count - 1
                    If .GetData(llngCnt, CMlngvsfCollectValueClass4C) <> vbNullString And _
                        .GetData(llngCnt, CMlngvsfCollectValueClass4C) <> CMstrNaString Then
                        llngFindRow = llngCnt
                        Exit For
                    End If
                Next llngCnt
                If llngFindRow = -1 Then
                    .Cols(CMlngvsfCollectValueClass4C).Visible = False
                Else
                    .Cols(CMlngvsfCollectValueClass4C).Visible = True
                End If

                '@最終色設定
                Select Case mtypDataCollect.typParameter(llngNextInfoIndex).strInputDataFlag
                    
                    Case CMstrOne, CMstrFour
                        '@読込済
                        '@収集項目ﾀｲﾌﾟ：装置ﾃﾞｰﾀの場合
                        If mtypDataCollect.typParameter(llngNextInfoIndex).strCollectionType = CMstrOne Then
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngNotInputColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngNotInputColor)
                            Dim cellRange As CellRange = .GetCellRange(CMlngOne, CMlngvsfCollectValueNoC, _
                                                .Rows.Count - 1, CMlngvsfCollectValueDataC)
                            cellRange.Style = newStyle       '薄い灰色
                            .Styles.Focus.BackColor =  ColorTranslator.FromWin32(CMlngNotInputColor)
                            .Styles.Highlight.BackColor =  ColorTranslator.FromWin32(CMlngNotInputColor)
                        Else
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                            Dim cellRange As CellRange = .GetCellRange(CMlngOne, CMlngvsfCollectValueNoC, _
                                                .Rows.Count - 1, CMlngvsfCollectValueDataC)
                            cellRange.Style = newStyle     '白
                            .Styles.Focus.BackColor =  ColorTranslator.FromWin32(CMlngEnableTrueColor)
                            .Styles.Highlight.BackColor =  ColorTranslator.FromWin32(CMlngEnableTrueColor)
                        End If
                    
                    Case CMstrTwo
                        '@入力済み
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor")
                        newStyle.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                        Dim cellRange As CellRange = .GetCellRange(CMlngOne, CMlngvsfCollectValueNoC, _
                                               .Rows.Count - 1, CMlngvsfCollectValueDataC)
                        cellRange.Style = newStyle     '白
                        .Styles.Focus.BackColor =  ColorTranslator.FromWin32(CMlngEnableTrueColor)
                        .Styles.Highlight.BackColor =  ColorTranslator.FromWin32(CMlngEnableTrueColor)
                    Case CMstrThree
                        '@引継情報
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngRetainColor")
                        newStyle.BackColor = ColorTranslator.FromWin32(CMlngRetainColor)
                        Dim cellRange As CellRange = .GetCellRange(CMlngOne, CMlngvsfCollectValueNoC, _
                                               .Rows.Count - 1, CMlngvsfCollectValueDataC)
                        cellRange.Style = newStyle         '水色(引継情報)
                        .Styles.Focus.BackColor =  ColorTranslator.FromWin32(CMlngRetainColor)
                        .Styles.Highlight.BackColor =  ColorTranslator.FromWin32(CMlngRetainColor)
                    Case Else
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor")
                        newStyle.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                        Dim cellRange As CellRange = .GetCellRange(CMlngOne, CMlngvsfCollectValueNoC, _
                                            .Rows.Count - 1, CMlngvsfCollectValueDataC)
                        cellRange.Style = newStyle     '白
                        .Styles.Focus.BackColor =  ColorTranslator.FromWin32(CMlngEnableTrueColor)
                        .Styles.Highlight.BackColor =  ColorTranslator.FromWin32(CMlngEnableTrueColor)
                End Select
                
                '@使用可設定
                If .Rows.Count > 1 Then
                    '@ﾛｯｸ解除
                    .Enabled = True
                End If
                
            End With
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期制御
            cmdLineInsert.Enabled = False   '行追加ﾎﾞﾀﾝ
            cmdLineDelete.Enabled = False   '行削除ﾎﾞﾀﾝ
            cmdNaInput.Enabled = False      '値未入力ﾎﾞﾀﾝ
            cmdRegist.Enabled = False       '確定ﾎﾞﾀﾝ
            
            vsfCollectValue.Redraw = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvParameterInputData_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCollectNextInfo_Disp
    '機　能：引継ぎ情報からCollectValueの値を表示する
    '引　数：lstrParameterID：ﾊﾟﾗﾒｰﾀID
    '戻り値：True:OK/False:NG
    '作成日：2005/01/27 (Thu) 15:18:38 S.Deguchi
    '更新日：2008/09/10 (Wed) 15:01:07 T.Sawaguchi
    '備　考：
    '　　　：2005/05/10 (Tue) 12:44:36 N.Kojima     引継ぎ情報がある場合でClass1～4,値がNULLの場合は、ﾊﾞｯｸｶﾗｰを引継ぎｶﾗｰにしない。(不具合№556関連)
    '　　　：2005/06/14 (Tue) 17:07:05 N.Kojima     「結果」欄削除に伴い、処理ｺﾒﾝﾄｱｳﾄ(不具合№883)
    '　　　：2005/06/24 (Fri) 12:41:03 N.Kojima     運用障害対応(№434)
    '　　　：2008/04/04 (Fri) 16:22:24 T.Sawaguchi  ｸﾞﾘｯﾄﾞ高さ制御追加　案件No02761　対応
    '　　　：2008/09/10 (Wed) 15:01:07 T.Sawaguchi  ｸﾞﾘｯﾄﾞ高さ制御追加  案件No03171ﾊﾞｸﾞ対応

    Private Function prvCollectNextInfo_Disp(ByVal lstrParameterID As String) As Boolean

        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt1                As Integer              'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2                As Integer              'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngResultFColor        As Integer              '結果文字列色
        Dim llngFindRow             As Integer              '行数
        Dim lblnParameter           As Boolean              'ﾊﾟﾗﾒｰﾀ有無(True:有/False:無)
        Dim lblnRetainJudgeFlag     As Boolean              '引継ぎ有無ﾌﾗｸﾞ

        Try
            
            '@引継ぎﾌﾗｸﾞ判定
            If vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectRiftainFlag) = 0 Then
            '@引継ぎﾌﾗｸﾞが立っていない場合は、処理を抜ける
                '@Falseを返す
                prvCollectNextInfo_Disp = False
                
                Exit Function
            End If
            
            '@初期化
            lblnRetainJudgeFlag = False

            '@初期化
            prvCollectNextInfo_Disp = False
            
            '@装置ﾃﾞｰﾀの引継ぎ表示
            With ptypNextCollectInfo
                '@情報がない場合
                If .lngCollectCnt = 0 Then
                    Exit Function
                End If
                
                For llngCnt = 0 To .lngCollectCnt - 1
                    '@収集項目ID/収集項目Ver/大工程/小工程が同一の場合,引継ぎ構造体から検索する
                    If mstrCollectionID = .typCollect(llngCnt).strCollectID And _
                        mstrCollectionVersion = .typCollect(llngCnt).strCollectVer And _
                        lblOpID.Text = .typCollect(llngCnt).strOpID And _
                        lblStepID.Text = .typCollect(llngCnt).strStepID Then
                    
                        '@引継ぎﾌﾗｸﾞがONでかつ、測定ﾓｰﾄﾞがｵﾌﾗｲﾝ、ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝの場合に検索する
                        For llngCnt1 = 0 To .typCollect(llngCnt).lngParameterCnt - 1
                            '@ﾊﾟﾗﾒｰﾀIDから情報を検索する
                            If .typCollect(llngCnt).typParameter(llngCnt1).strParameterID = lstrParameterID Then
                            '@合致情報があった場合：Input情報をｸﾞﾘｯﾄﾞに表示する
                                vsfCollectValue.Redraw = False
                                '@行設定
                                RemoveHandler vsfCollectValue.EnterCell,AddressOf vsfCollectValue_EnterCell
                                vsfCollectValue.Rows.Count = .typCollect(llngCnt).typParameter(llngCnt1).lngDvNameCnt + 1
                                AddHandler vsfCollectValue.EnterCell,AddressOf vsfCollectValue_EnterCell
                                
                                For llngCnt2 = 1 To .typCollect(llngCnt).typParameter(llngCnt1).lngDvNameCnt
                                    '@№
                                    vsfCollectValue.SetData(llngCnt2, CMlngvsfCollectValueNoC, _
                                        .typCollect(llngCnt).typParameter(llngCnt1).typDvName(llngCnt2 - 1).strNo)
                                    
                                    '@Class1
                                    vsfCollectValue.SetData(llngCnt2, CMlngvsfCollectValueClass1C, _
                                        .typCollect(llngCnt).typParameter(llngCnt1).typDvName(llngCnt2 - 1).strClass1)
                                        
                                    '@Class2
                                    vsfCollectValue.SetData(llngCnt2, CMlngvsfCollectValueClass2C, _
                                        .typCollect(llngCnt).typParameter(llngCnt1).typDvName(llngCnt2 - 1).strClass2)
                                        
                                    '@Class3
                                    vsfCollectValue.SetData(llngCnt2, CMlngvsfCollectValueClass3C, _
                                        .typCollect(llngCnt).typParameter(llngCnt1).typDvName(llngCnt2 - 1).strClass3)
                                        
                                    '@Class4
                                    vsfCollectValue.SetData(llngCnt2, CMlngvsfCollectValueClass4C, _
                                        .typCollect(llngCnt).typParameter(llngCnt1).typDvName(llngCnt2 - 1).strClass4)
                                        
                                    '@値
                                    vsfCollectValue.SetData(llngCnt2, CMlngvsfCollectValueDataC, _
                                        .typCollect(llngCnt).typParameter(llngCnt1).typDvName(llngCnt2 - 1).strData)
                                    
                                    '@引継ぎ有無ﾌﾗｸﾞ=Falseの場合
                                    If lblnRetainJudgeFlag = False Then
                                        '@Class1,Class2,Class3,Class4,値がNULLの場合
                                        If vsfCollectValue.GetData(llngCnt2, CMlngvsfCollectValueClass1C) = vbNullString And _
                                           vsfCollectValue.GetData(llngCnt2, CMlngvsfCollectValueClass2C) = vbNullString And _
                                           vsfCollectValue.GetData(llngCnt2, CMlngvsfCollectValueClass3C) = vbNullString And _
                                           vsfCollectValue.GetData(llngCnt2, CMlngvsfCollectValueClass4C) = vbNullString And _
                                           vsfCollectValue.GetData(llngCnt2, CMlngvsfCollectValueDataC) = vbNullString Then
                                            '@引継ぎ有無ﾌﾗｸﾞを「引継ぎ無し=False」に
                                            lblnRetainJudgeFlag = False
                                        Else
                                            '@引継ぎ有無ﾌﾗｸﾞを「引継ぎ有り=True」に
                                            lblnRetainJudgeFlag = True
                                        End If
                                    End If
                                    
                                    Dim newStyle As CellStyle = vsfCollectValue.Styles.Add("CustomStyle_ForeColor_llngResultFColor" + llngCnt1.ToString)
                                    newStyle.ForeColor = ColorTranslator.FromWin32(llngResultFColor)
                                    Dim cellRange As CellRange = vsfCollectValue.GetCellRange(llngCnt2, CMlngvsfCollectValueDataC)
                                    cellRange.Style = newStyle           '値：文字色
                                    
                                    '@高さ設定
                                    vsfCollectValue.Rows(llngCnt2).Height = CMlngvsfRowHeight  'CMlngGridRowHeight→CMlngvsfRowHeightへ変更

                                Next llngCnt2
                                
                                '@引継情報の背景色にする
                                If lblnRetainJudgeFlag = False Then
                                    '@入力可の背景色にする
                                    Dim newStyle As CellStyle = vsfCollectValue.Styles.Add("CustomStyle_BackColor_CMlngEnableTrueColor" + llngCnt1.ToString)
                                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                                    Dim cellRange As CellRange = vsfCollectValue.GetCellRange(CMlngOne, CMlngGridRowCol_0, _
                                                         vsfCollectValue.Rows.Count - 1, CMlngvsfCollectValueDataC)
                                    cellRange.Style = newStyle
                                Else
                                    '@引継情報の背景色にする
                                    Dim newStyle As CellStyle = vsfCollectValue.Styles.Add("CustomStyle_BackColor_CMlngRetainColor" + llngCnt1.ToString)
                                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngRetainColor)
                                    Dim cellRange As CellRange = vsfCollectValue.GetCellRange(CMlngOne, CMlngGridRowCol_0, _
                                                         vsfCollectValue.Rows.Count - 1, CMlngvsfCollectValueDataC)
                                    cellRange.Style = newStyle
                                End If

                                vsfCollectValue.Redraw = True
                            
                                '@合致するﾊﾟﾗﾒｰﾀが存在
                                lblnParameter = True
                                
                                Exit For
                            Else
                                '@合致するﾊﾟﾗﾒｰﾀが存在しない
                                lblnParameter = False
                            End If
                        Next llngCnt1
                    Else
                        '@合致するﾊﾟﾗﾒｰﾀが存在しない
                        lblnParameter = False
                    End If
                Next llngCnt

                'NSYS 選択セル背景色
                Select Case vsfCollectValue.GetCellRange(vsfCollectValue.Row, vsfCollectValue.Col).StyleDisplay.BackColor
                    Case ColorTranslator.FromWin32(CMlngEnableTrueColor)
                        vsfCollectValue.Styles.Focus.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                        vsfCollectValue.Styles.Highlight.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)

                    Case ColorTranslator.FromWin32(CMlngRetainColor)
                        vsfCollectValue.Styles.Focus.BackColor = ColorTranslator.FromWin32(CMlngRetainColor)
                        vsfCollectValue.Styles.Highlight.BackColor = ColorTranslator.FromWin32(CMlngRetainColor)

                End Select

            End With

            '@合致するﾊﾟﾗﾒｰﾀが存在しない場合には処理終了
            If lblnParameter = False Then
                '@失敗を返す
                prvCollectNextInfo_Disp = False
                
                Exit Function
            End If
            
            '@一覧へ表示した内容の各種設定
            With vsfCollectValue
                For llngCnt = 1 To .Rows.Count - 1
                    '@値位置の設定
                    If vsfCollect.GetData(vsfCollect.Row, CMlngvsfCollectDataTypeC) = CMstrDataTypeN Then
                        '@数字ﾀｲﾌﾟの場合は右寄
                        .Cols(CMlngvsfCollectValueDataC).TextAlign = TextAlignEnum.RightCenter
                    Else
                        '@文字ﾀｲﾌﾟの場合は左寄
                        .Cols(CMlngvsfCollectValueDataC).TextAlign = TextAlignEnum.LeftCenter
                    End If
                    
                    '@高さ設定
                    .Rows(llngCnt).Height = CMlngvsfRowHeight  'CMlngGridRowHeight→CMlngvsfRowHeightへ変更

                Next llngCnt
                
                '@ﾃﾞｰﾀ分類名列の非表示設定(ﾀｲﾄﾙと内容がNullの場合は非表示とする)
                '@ﾃﾞｰﾀ分類1名の非表示判定
                llngFindRow = -1
                For llngCnt = 0 To .Rows.Count - 1
                    If .GetData(llngCnt, CMlngvsfCollectValueClass1C) <> vbNullString And _
                        .GetData(llngCnt, CMlngvsfCollectValueClass1C) <> CMstrNaString Then
                        llngFindRow = llngCnt
                        Exit For
                    End If
                Next llngCnt
                If llngFindRow = -1 Then
                    .Cols(CMlngvsfCollectValueClass1C).Visible = False
                Else
                    .Cols(CMlngvsfCollectValueClass1C).Visible = True
                End If
                
                '@ﾃﾞｰﾀ分類2名の非表示判定(ﾀｲﾄﾙと内容がNullの場合は非表示とする)
                llngFindRow = -1
                For llngCnt = 0 To .Rows.Count - 1
                    If .GetData(llngCnt, CMlngvsfCollectValueClass2C) <> vbNullString And _
                        .GetData(llngCnt, CMlngvsfCollectValueClass2C) <> CMstrNaString Then
                        llngFindRow = llngCnt
                        Exit For
                    End If
                Next llngCnt
                If llngFindRow = -1 Then
                    .Cols(CMlngvsfCollectValueClass2C).Visible = False
                Else
                    .Cols(CMlngvsfCollectValueClass2C).Visible = True
                End If
                
                '@ﾃﾞｰﾀ分類3名の非表示判定(ﾀｲﾄﾙと内容がNullの場合は非表示とする)
                llngFindRow = -1
                For llngCnt = 0 To .Rows.Count - 1
                    If .GetData(llngCnt, CMlngvsfCollectValueClass3C) <> vbNullString And _
                        .GetData(llngCnt, CMlngvsfCollectValueClass3C) <> CMstrNaString Then
                        llngFindRow = llngCnt
                        Exit For
                    End If
                Next llngCnt
                If llngFindRow = -1 Then
                    .Cols(CMlngvsfCollectValueClass3C).Visible = False
                Else
                    .Cols(CMlngvsfCollectValueClass3C).Visible = True
                End If
                
                '@ﾃﾞｰﾀ分類4名の非表示判定(ﾀｲﾄﾙと内容がNullの場合は非表示とする)
                llngFindRow = -1
                For llngCnt = 0 To .Rows.Count - 1
                    If .GetData(llngCnt, CMlngvsfCollectValueClass4C) <> vbNullString And _
                        .GetData(llngCnt, CMlngvsfCollectValueClass4C) <> CMstrNaString Then
                        llngFindRow = llngCnt
                        Exit For
                    End If
                Next llngCnt
                If llngFindRow = -1 Then
                    .Cols(CMlngvsfCollectValueClass4C).Visible = False
                Else
                    .Cols(CMlngvsfCollectValueClass4C).Visible = True
                End If
                '@使用可設定
                If .Rows.Count > 1 Then
                    '@ﾛｯｸ解除
                    .Enabled = True
                End If
            
                '@列幅の自動調整
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngGridRowCol_0, .Cols.Count - 1, 6)
                .AllowResizing = AllowResizingEnum.Columns      'ﾏｳｽよる列ｻｲｽﾞ変更の可／不可
                
                '@ﾛｯｸ解除
                .Enabled = True
            End With

            '@成功を返す
            prvCollectNextInfo_Disp = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCollectNextInfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvCollectNextInfo_Set
    '機　能：次回引継ぎ情報の設定
    '引　数：llngCollectIndex：引継ぎ情報戻し番号
    '戻り値：なし
    '作成日：2005/01/26 (Wed) 08:58:58 S.Deguchi
    '更新日：2005/01/26 (Wed) 08:58:58
    '備　考：
    Private Sub prvCollectNextInfo_Set(ByRef llngCollectIndex As Integer)

        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt1                As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngPParameterIndex     As Integer      'ﾊﾟﾌﾞﾘｯｸのﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽ
        Dim llngMParameterIndex     As Integer      'ﾓｼﾞｭｰﾙのﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽ

        Try
            
            '@収集項目ID/収集項目Ver/大工程/小工程が同じか判別
            llngCollectIndex = - 1
            With ptypNextCollectInfo
                If .lngCollectCnt <> CMlngZero Then
                    For llngCnt = 0 To .lngCollectCnt - 1
                        '@既存の引継ぎ構造体のﾁｪｯｸ
                        If mstrCollectionID = .typCollect(llngCnt).strCollectID And _
                           mstrCollectionVersion = .typCollect(llngCnt).strCollectVer And _
                           lblOpID.Text = .typCollect(llngCnt).strOpID And _
                           lblStepID.Text = .typCollect(llngCnt).strStepID Then
                            '@収集項目ID/収集項目Ver/大工程/小工程が同じ場合
                            
                            '@ｲﾝﾃﾞｯｸｽを退避
                            llngCollectIndex = llngCnt
                            
                            '@ﾙｰﾌﾟ抜け
                            Exit For
                        Else
                            '@収集項目ID/収集項目Ver/大工程/小工程が存在しない場合
                            
                            '@ｲﾝﾃﾞｯｸｽ=-1
                            llngCollectIndex = - 1
                        End If
                    Next llngCnt
                Else
                    '@ｲﾝﾃﾞｯｸｽ=-1
                    llngCollectIndex = - 1
                End If
            End With

            '@ﾊﾟﾗﾒｰﾀIDが同じ場合
            '@引継ﾌﾗｸﾞが立っている場合
            '@測定条件がｵﾌﾗｲﾝ,ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝの場合
            If llngCollectIndex <> - 1 Then
                With ptypNextCollectInfo.typCollect(llngCollectIndex)
                    '@引継情報のﾙｰﾌﾟ
                    For llngCnt = 0 To .lngParameterCnt - 1
                        '@ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽを退避
                        llngPParameterIndex = CMlngZero
                        llngMParameterIndex = CMlngZero
                        
                        '@退避領域のﾙｰﾌﾟ
                        For llngCnt1 = 0 To mtypDataCollect.lngParameterCnt - 1
                            
                            '@同じﾊﾟﾗﾒｰﾀID/Verか比較
                            If .typParameter(llngCnt).strParameterID = _
                                mtypDataCollect.typParameter(llngCnt1).strParameterID And _
                                .typParameter(llngCnt).strParameterVer = _
                                mtypDataCollect.typParameter(llngCnt1).strParameterVersion Then
                                
                                '@引継ﾌﾗｸﾞが立っている場合&入力ﾃﾞｰﾀﾌﾗｸﾞが0:無以外の場合
                                If mtypDataCollect.typParameter(llngCnt1).strRiftainFlag = CMstrOne And _
                                   mtypDataCollect.typParameter(llngCnt1).strInputDataFlag <> CMstrZero Then
                                    
                                    '@測定ﾓｰﾄ判定(0:ｵﾌﾗｲﾝのみ、2:ｵﾝﾗｲﾝ/ｵﾌﾗｲﾝ)
                                    If mtypDataCollect.typParameter(llngCnt1).strMeasureMode = CMstrZero Or _
                                        mtypDataCollect.typParameter(llngCnt1).strMeasureMode = CMstrTwo Then
                                
                                        '@ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽを退避
                                        llngPParameterIndex = llngCnt
                                        llngMParameterIndex = llngCnt1
                                        
                                        '@ﾊﾟﾗﾒｰﾀ引継処理へ
                                        Call prvCollectInfo_UpdateSet(llngCollectIndex, llngPParameterIndex, llngMParameterIndex)
                                        
                                        '@ﾊﾟﾌﾞﾘｯｸへ登録済みﾌﾗｸﾞを立てる
                                        Dim typParametertmp = mtypDataCollect.typParameter(llngCnt1)
                                        typParametertmp.strNextParameterInputFlag = CMstrOne
                                        mtypDataCollect.typParameter(llngCnt1) = typParametertmp
                                    End If
                                End If
                            End If
                        Next llngCnt1
                    Next llngCnt
                End With
            
                '@残りのﾊﾟﾗﾒｰﾀを新規登録
                With mtypDataCollect
                    For llngCnt = 0 To .lngParameterCnt - 1
                        '@登録ﾌﾗｸﾞが立っていない場合
                        If .typParameter(llngCnt).strNextParameterInputFlag = CMstrZero Then
                            '@ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽを退避
                            llngMParameterIndex = llngCnt
                        
                            '@ﾊﾟﾗﾒｰﾀ引継処理へ
                            Call prvCollectInfo_InsertSet(llngCollectIndex, llngMParameterIndex)
                        End If
                    Next
                End With
                
                Exit Sub
            End If
            
            '@新規登録
                With ptypNextCollectInfo
                    '@収集項目の領域を確保
                    .lngCollectCnt = .lngCollectCnt + 1
                    llngCollectIndex = .lngCollectCnt - 1
                    If .typCollect Is Nothing Then 
                        .typCollect = New List(Of CollectNextInfo)
                    End If
                    
                    '@収集項目の値をｾｯﾄ
                    Dim typCollectTmp = New CollectNextInfo
                    typCollectTmp.strCollectID = mstrCollectionID
                    typCollectTmp.strCollectVer = mstrCollectionVersion
                    typCollectTmp.strOpID = lblOpID.Text
                    typCollectTmp.strStepID = lblStepID.Text
                    .typCollect.Add(typCollectTmp)
                    
                    For llngCnt = 0 To mtypDataCollect.lngParameterCnt - 1
                        '@登録ﾌﾗｸﾞが立っていない場合
                        If mtypDataCollect.typParameter(llngCnt).strNextParameterInputFlag = CMstrZero Then
                            '@ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽを退避
                            llngMParameterIndex = llngCnt
                        
                            '@ﾊﾟﾗﾒｰﾀ引継処理へ
                            Call prvCollectInfo_InsertSet(llngCollectIndex, llngMParameterIndex)
                        End If
                    Next
                End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCollectNextInfo_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCollectInfo_InsertSet
    '機　能：引継ぎ情報のｲﾝｻｰﾄ
    '引　数：llngCollectIndex：ﾊﾟﾌﾞﾘｯｸ_収集項目ｲﾝﾃﾞｯｸｽ
    '　　　：llngMParameterIndex：ﾓｼﾞｭｰﾙ_ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2005/02/02 (Wed) 11:20:28 S.Deguchi
    '更新日：2005/02/02 (Wed) 11:20:28
    '備　考：
    Private Sub prvCollectInfo_InsertSet(ByVal llngCollectIndex As Integer, _
                                         ByVal llngMParameterIndex As Integer)

        Dim llngCnt     As Integer      'ﾛｰｶﾙ変数
        Dim llngCnt1    As Integer      'ﾛｰｶﾙ変数
        Dim llngCnt2    As Integer      'ﾙｰﾌﾟｶｳﾝﾀ

        Try
            'NSYS 一時編集変数へ退避
            Dim insCollectNextInfoObj As CollectNextInfo = ptypNextCollectInfo.typCollect(llngCollectIndex)

            With insCollectNextInfoObj
                
                If mtypDataCollect.typParameter(llngMParameterIndex).lngInputDataCnt > 0 Then
                    '@ﾛｰｶﾙ変数で計算(1ｱｯﾌﾟ)
                    llngCnt = .lngParameterCnt + 1
                    
                    '@ﾊﾟﾗﾒｰﾀIDを追加する為に領域を確保
                    If .typParameter Is Nothing Then
                        .typParameter = New List(Of CollectNextParamater)
                    End If
                    Dim ltypParameter As new CollectNextParamater
                    ltypParameter.typDvName = New List(Of CollectNextDvName)

                    .lngParameterCnt = llngCnt
                    
                    '@ﾊﾟﾗﾒｰﾀID
                    ltypParameter.strParameterID = _
                        mtypDataCollect.typParameter(llngMParameterIndex).strParameterID
                    
                    '@ﾊﾟﾗﾒｰﾀVer
                    ltypParameter.strParameterVer = _
                        mtypDataCollect.typParameter(llngMParameterIndex).strParameterVersion
                    
                    '@引継情報
                    ltypParameter.strDataRetainFlag = _
                        mtypDataCollect.typParameter(llngMParameterIndex).strRiftainFlag
                    
                    '@測定
                    ltypParameter.strMeasureMode = _
                        mtypDataCollect.typParameter(llngMParameterIndex).strMeasureMode
                    
                    '@入力ﾃﾞｰﾀ領域を確保
                    ltypParameter.lngDvNameCnt = _
                        mtypDataCollect.typParameter(llngMParameterIndex).lngInputDataCnt
                    llngCnt1 = mtypDataCollect.typParameter(llngMParameterIndex).lngInputDataCnt
                    Dim ltypDvName As CollectNextDvName
                    
                    '@情報をｾｯﾄ
                    For llngCnt2 = 0 To llngCnt1 - 1

                        ltypDvName = New CollectNextDvName

                        '@№
                        ltypDvName.strNo = _
                            mtypDataCollect.typParameter(llngMParameterIndex).typInputData(llngCnt2).strNo
                            
                        '@Class1
                        ltypDvName.strClass1 = _
                            mtypDataCollect.typParameter(llngMParameterIndex).typInputData(llngCnt2).strClass1
                            
                        '@Class2
                        ltypDvName.strClass2 = _
                            mtypDataCollect.typParameter(llngMParameterIndex).typInputData(llngCnt2).strClass2
                            
                        '@Class3
                        ltypDvName.strClass3 = _
                            mtypDataCollect.typParameter(llngMParameterIndex).typInputData(llngCnt2).strClass3
                            
                        '@Class4
                        ltypDvName.strClass4 = _
                            mtypDataCollect.typParameter(llngMParameterIndex).typInputData(llngCnt2).strClass4
                            
                        '@値
                        ltypDvName.strData = _
                            mtypDataCollect.typParameter(llngMParameterIndex).typInputData(llngCnt2).strData
                        ltypParameter.typDvName.Add(ltypDvName)
                    Next llngCnt2
                    .typParameter.Add(ltypParameter)
                End If
            End With

            'NSYS 編集済みオブジェクトを上書き
            ptypNextCollectInfo.typCollect(llngCollectIndex) = insCollectNextInfoObj

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCollectInfo_InsertSet"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCollectInfo_UpdateSet
    '機　能：引継ぎ情報のｱｯﾌﾟﾃﾞｰﾄ
    '引　数：llngCollectIndex：ﾊﾟﾌﾞﾘｯｸ_収集項目ｲﾝﾃﾞｯｸｽ
    '　　　：llngPParameterIndex：ﾊﾟﾌﾞﾘｯｸ_ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽ
    '　　　：llngMParameterIndex：ﾓｼﾞｭｰﾙ_ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2005/02/02 (Wed) 10:48:34 S.Deguchi
    '更新日：2005/02/02 (Wed) 10:48:34
    '備　考：
    '　　　：2005/09/05 (Mon) 08:28:24 S.Deguchi    ｴﾗｰ判別用ﾒｯｾｰｼﾞﾎﾞｯｸｽを一時追加
    Private Sub prvCollectInfo_UpdateSet(ByVal llngCollectIndex As Integer, _
                                         ByVal llngPParameterIndex As Integer, _
                                         ByVal llngMParameterIndex As Integer)

        Dim llngCnt     As Integer      'ﾛｰｶﾙ変数
        Dim llngCnt1    As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lstrErr     As String       'ｴﾗｰ退避

        Try
            
            With ptypNextCollectInfo.typCollect(llngCollectIndex)
                '@既存の情報を削除して,引継ぎ情報に登録し直す
                Dim ltypParameter = .typParameter(llngPParameterIndex)

                ltypParameter.lngDvNameCnt = CMlngZero
                
                '@ﾊﾟﾗﾒｰﾀID
                ltypParameter.strParameterID = _
                    mtypDataCollect.typParameter(llngMParameterIndex).strParameterID
                
                '@ﾊﾟﾗﾒｰﾀVer
                ltypParameter.strParameterVer = _
                    mtypDataCollect.typParameter(llngMParameterIndex).strParameterVersion
                
                '@引継情報(上書き)
                ltypParameter.strDataRetainFlag = vbNullString
                
                '@測定(上書き)
                ltypParameter.strMeasureMode = _
                    mtypDataCollect.typParameter(llngMParameterIndex).strMeasureMode
                
        '@↓2005/09/05 (Mon) 09:51:55 S.Deguchi **************************************************
        '@処理確認用ﾒｯｾｰｼﾞﾎﾞｯｸｽ＆ｴﾗｰ表示処理(残しておいてね！)
        '        '@ｴﾗｰ判別用ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
        '        Call MsgBox(mtypDataCollect.typParameter(llngMParameterIndex).lngInputDataCnt, 0, "!")
        '
                lstrErr = mtypDataCollect.typParameter(llngMParameterIndex).lngInputDataCnt
        '@↑2005/09/05 (Mon) 09:51:55 S.Deguchi **************************************************
                
                '@領域を再確保
                ltypParameter.lngDvNameCnt = _
                    mtypDataCollect.typParameter(llngMParameterIndex).lngInputDataCnt
                '@ﾛｰｶﾙ変数へ退避
                llngCnt = mtypDataCollect.typParameter(llngMParameterIndex).lngInputDataCnt
                ltypParameter.typDvname = New List(Of CollectNextDvName)
                Dim ltypDvName As New CollectNextDvName
                
                '@情報をｾｯﾄ
                For llngCnt1 = 0 To llngCnt - 1
                    ltypDvName = New CollectNextDvName
                    ltypDvName.strNo = _
                        mtypDataCollect.typParameter(llngMParameterIndex).typInputData(llngCnt1).strNo
                        
                    ltypDvName.strClass1 = _
                        mtypDataCollect.typParameter(llngMParameterIndex).typInputData(llngCnt1).strClass1
                        
                    ltypDvName.strClass2 = _
                        mtypDataCollect.typParameter(llngMParameterIndex).typInputData(llngCnt1).strClass2
                        
                    ltypDvName.strClass3 = _
                        mtypDataCollect.typParameter(llngMParameterIndex).typInputData(llngCnt1).strClass3
                        
                    ltypDvName.strClass4 = _
                        mtypDataCollect.typParameter(llngMParameterIndex).typInputData(llngCnt1).strClass4
                        
                    ltypDvName.strData = _
                        mtypDataCollect.typParameter(llngMParameterIndex).typInputData(llngCnt1).strData
                    ltypParameter.typDvname.Add(ltypDvName)
                Next llngCnt1
                .typParameter(llngPParameterIndex) = ltypParameter
            End With
             
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCollectInfo_UpdateSet"
                .strErrMessage = lstrErr
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Check
    '機　能：確定時の入力ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2005/01/26 (Wed) 14:16:56 S.Deguchi
    '更新日：2005/01/26 (Wed) 14:16:56
    '備　考：
    Private Function prvblnInput_Check() As Boolean

        Dim llngCnt             As Integer  'ｶｳﾝﾀ
        Dim llngParameterIndex  As Integer  'ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽ
        Dim lblnAns             As Boolean  '汎用結果判定

        Try
            
            '@確定ﾎﾞﾀﾝの使用不可
            cmdRegist.Enabled = False
            
            '@ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽの初期化
            llngParameterIndex = 0
            
            '@入力ﾁｪｯｸ初期化
            prvblnInput_Check = False
            
            With mtypDataCollect
                '@ﾛｯﾄID/WFIDが空欄の場合
                If .strChgID = vbNullString Then
                    Exit Function
                End If
                
                '@入力ﾊﾟﾗﾒｰﾀ毎に判断
                For llngCnt = 0 To .lngParameterCnt - 1
                    '入力ﾃﾞｰﾀﾌﾗｸﾞから判別
                    Select Case .typParameter(llngCnt).strInputDataFlag
                        Case CMstrZero
                        '@読込無し&入力無し
                            '@必須入力項目数が"0"の場合
                            If .typParameter(llngCnt).strMandatoryCount = CMstrZero Then
                                '@処理なし
                            Else
                                If .typParameter(llngCnt).lngInputDataCnt > CMlngOne Then
                                    '@入力ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽ
                                    llngParameterIndex = llngCnt
                                    
                                    '@ﾊﾟﾗﾒｰﾀの格納
                                    lblnAns = prvcmdRegistInputFlag_Set(llngParameterIndex)
                                    If lblnAns = True Then
                                    
                                    Else
                                        '@ﾁｪｯｸNG
                                        prvblnInput_Check = False
                                        
                                        Exit For
                                    End If
                                Else
                                    '@装置ﾃﾞｰﾀの場合
                                    If .typParameter(llngCnt).strCollectionType = 1 Then
                                        Exit Function
                                    End If
                                End If
                            End If
                        
                        Case CMstrOne
                        '@読込済み
                            
                        Case CMstrTwo
                        '@入力有りﾌﾗｸﾞ
                            '@入力ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽ
                            llngParameterIndex = llngCnt
                            
                            '@ﾊﾟﾗﾒｰﾀ個別判定
                            lblnAns = prvblnInputData_Check(llngParameterIndex)
                            If lblnAns = False Then
                                '@失敗を返す
                                prvblnInput_Check = False
                                
                                Exit Function
                            End If
                            
                        Case CMstrThree
                        '@引継情報有りﾌﾗｸﾞ
                            '@入力ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽ
                            llngParameterIndex = llngCnt
                            
                            '@ﾊﾟﾗﾒｰﾀ個別判定
                            lblnAns = prvblnInputData_Check(llngParameterIndex)
                            If lblnAns = False Then
                                '@失敗を返す
                                prvblnInput_Check = False
                                
                                Exit Function
                            End If
                    
                        Case CMstrFour
                        '@ｵﾝﾗｲﾝ
                        
                    End Select
                Next llngCnt
            End With

            '@入力OK
            prvblnInput_Check = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInput_Check"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnInputData_Check
    '機　能：個別ﾁｪｯｸ
    '引　数：llngParameterIndex：ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽ
    '戻り値：True:OK/Flase:NG
    '作成日：2005/02/03 (Thu) 13:51:54 S.Deguchi
    '更新日：2005/02/03 (Thu) 13:51:54
    '備　考：
    Private Function prvblnInputData_Check(ByVal llngParameterIndex As Integer) As Boolean

        Dim llngCnt             As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lblnClassCheck1     As Boolean      'ﾃﾞｰﾀ分類1正常区分(False:異常、True:正常)
        Dim lblnClassCheck2     As Boolean      'ﾃﾞｰﾀ分類2正常区分(False:異常、True:正常)
        Dim lblnClassCheck3     As Boolean      'ﾃﾞｰﾀ分類3正常区分(False:異常、True:正常)
        Dim lblnClassCheck4     As Boolean      'ﾃﾞｰﾀ分類4正常区分(False:異常、True:正常)
        Dim lblnDataCheck       As Boolean      '値正常区分(False:異常、True:正常)
        Dim llngInputCnt        As Integer      'ｶｳﾝﾄ

        Try

            '@初期化
            lblnClassCheck1 = False
            lblnClassCheck2 = False
            lblnClassCheck3 = False
            lblnClassCheck4 = False
            lblnDataCheck = False
            
            prvblnInputData_Check = False
            
            With mtypDataCollect.typParameter(llngParameterIndex)
                '@入力＆引継
                If .strInputDataFlag = CMstrTwo Or .strInputDataFlag = CMstrThree Then
                    For llngCnt = 0 To .lngInputDataCnt - 1
                        '@入力ﾃﾞｰﾀの1行目が全て空欄の場合はｽｷｯﾌﾟ
                        If (.typInputData(llngCnt).strClass1 = vbNullString) And _
                           (.typInputData(llngCnt).strClass2 = vbNullString) And _
                           (.typInputData(llngCnt).strClass3 = vbNullString) And _
                           (.typInputData(llngCnt).strClass4 = vbNullString) And _
                           (.typInputData(llngCnt).strData = vbNullString) Then
                                Exit For
                        End If
                        
                        '@ﾃﾞｰﾀ分類1
                        If .typInputData(llngCnt).strClass1Disp = CMstrOne Then
                        '@表示区分：表示
                            
                            If .typInputData(llngCnt).strClass1 = vbNullString Then
                            '@ﾃﾞｰﾀ無し
                                '@失敗を返す
                                lblnClassCheck1 = False
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0027)
                                
                                '@"必須データが未入力です。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                '@行を選択
                                vsfCollectValue.Row = llngCnt + 1
                                
                                '@行を選択状態とする
                                vsfCollectValue.ShowCell(llngCnt + 1, CMlngvsfCollectValueClass1C)
                                
                                '@ｾｯﾄﾌｫｰｶｽ処理
                                Call pubSetFocus(vsfCollectValue)
                                
                                Exit Function
                            Else
                                '@成功を返す
                                lblnClassCheck1 = True
                            End If
                        Else
                        '@表示区分：非表示
                            If .typInputData(llngCnt).strClass1 <> vbNullString Then
                            '@ﾃﾞｰﾀ有り
                                lblnClassCheck1 = False
                            Else
                            '@ﾃﾞｰﾀ無し
                                lblnClassCheck1 = True
                            End If
                        End If
                    
                        '@ﾃﾞｰﾀ分類2
                        If .typInputData(llngCnt).strClass2Disp = CMstrOne Then
                        '@表示区分：表示
                            If .typInputData(llngCnt).strClass2 = vbNullString Then
                            '@ﾃﾞｰﾀ無し
                                '@失敗を返す
                                lblnClassCheck2 = False
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0027)
                                
                                '@"必須データが未入力です。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                '@行を選択
                                vsfCollectValue.Row = llngCnt + 1
                                
                                '@行を選択状態とする
                                vsfCollectValue.ShowCell(llngCnt + 1, CMlngvsfCollectValueClass2C)
                                
                                '@ｾｯﾄﾌｫｰｶｽ処理
                                Call pubSetFocus(vsfCollectValue)
                                
                                Exit Function
                            Else
                                '@成功を返す
                                lblnClassCheck2 = True
                            End If
                        Else
                        '@表示区分：非表示
                            If .typInputData(llngCnt).strClass2 <> vbNullString Then
                            '@ﾃﾞｰﾀ有り
                                lblnClassCheck2 = False
                            Else
                            '@ﾃﾞｰﾀ無し
                                lblnClassCheck2 = True
                            End If
                        End If
                    
                        '@ﾃﾞｰﾀ分類3
                        If .typInputData(llngCnt).strClass3Disp = CMstrOne Then
                        '@表示区分：表示
                            
                            If .typInputData(llngCnt).strClass3 = vbNullString Then
                            '@ﾃﾞｰﾀ無し
                                '@失敗を返す
                                lblnClassCheck3 = False
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0027)
                                
                                '@"必須データが未入力です。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                '@行を選択
                                vsfCollectValue.Row = llngCnt + 1
                                
                                '@行を選択状態とする
                                vsfCollectValue.ShowCell(llngCnt + 1, CMlngvsfCollectValueClass3C)
                                
                                '@ｾｯﾄﾌｫｰｶｽ処理
                                Call pubSetFocus(vsfCollectValue)
                                
                                Exit Function
                            Else
                                '@成功を返す
                                lblnClassCheck3 = True
                            End If
                        Else
                        '@表示区分：非表示
                            
                            If .typInputData(llngCnt).strClass3 <> vbNullString Then
                            '@ﾃﾞｰﾀ有り
                                lblnClassCheck3 = False
                            Else
                            '@ﾃﾞｰﾀ無し
                                lblnClassCheck3 = True
                            End If
                        End If
                
                        '@ﾃﾞｰﾀ分類4
                        If .typInputData(llngCnt).strClass4Disp = CMstrOne Then
                        '@表示区分：表示
                            If .typInputData(llngCnt).strClass4 = vbNullString Then
                            '@ﾃﾞｰﾀ無し
                                '@失敗を返す
                                lblnClassCheck4 = False
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0027)
                                
                                '@"必須データが未入力です。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                '@行を選択
                                vsfCollectValue.Row = llngCnt + 1
                                
                                '@行を選択状態とする
                                vsfCollectValue.ShowCell(llngCnt + 1, CMlngvsfCollectValueClass4C)
                                
                                '@ｾｯﾄﾌｫｰｶｽ処理
                                Call pubSetFocus(vsfCollectValue)
                                
                                Exit Function
                            Else
                                '@成功を返す
                                lblnClassCheck4 = True
                            End If
                        Else
                        '@表示区分：非表示
                            If .typInputData(llngCnt).strClass4 <> vbNullString Then
                            '@ﾃﾞｰﾀ有り
                                lblnClassCheck4 = False
                            Else
                            '@ﾃﾞｰﾀ無し
                                lblnClassCheck4 = True
                            End If
                        End If
                                    
                        '@値
                        If .typInputData(llngCnt).strData = vbNullString Then
                        '@ﾃﾞｰﾀ無し
                            '@失敗を返す
                            lblnDataCheck = False
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007X, "値")
                            
                            '@"必須データが未入力です。"
                            '@"<TRM7XW>$$[%1]が入力されていません。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@行を選択
                            vsfCollectValue.Row = llngCnt + 1
                            
                            '@行を選択状態とする
        '                    vsfCollectValue.ShowCell llngCnt, CMlngvsfCollectValueDataC
                            vsfCollectValue.Select(llngCnt + 1, CMlngvsfCollectValueDataC)
                            '@ｾｯﾄﾌｫｰｶｽ処理
                            Call pubSetFocus(vsfCollectValue)
                        
                            Exit Function
                        Else
                            '@成功を返す
                            lblnDataCheck = True
                        End If
                
                        '@ｶｳﾝﾄ数の算出
                        If lblnClassCheck1 = True And lblnClassCheck2 = True And _
                           lblnClassCheck3 = True And lblnClassCheck4 = True And _
                           lblnDataCheck = True Then
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngInputCnt = llngInputCnt + 1
                        Else
                            llngInputCnt = llngInputCnt
                        End If
                    Next llngCnt
                
                    If llngInputCnt >= CLng(.strMandatoryCount) Then
                        '@初期化
                        llngInputCnt = 0
                    Else
                        '@必須入力項目が0の場合
                        If CLng(.strMandatoryCount) <> CMlngZero Then
                            '@失敗を返す
                            prvblnInputData_Check = False
                            
                            Exit Function
                        End If
                    End If
                End If
            End With

            '@成功を返す
            prvblnInputData_Check = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInputData_Check"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvcmdRegistEnabled_Chk
    '機　能：確定ﾎﾞﾀﾝ活性ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/26 (Wed) 14:37:25 S.Deguchi
    '更新日：2005/06/22 (Wed) 17:27:05 N.Kojima
    '備　考：
    '　　　：2005/06/22 (Wed) 17:27:05 N.Kojima     ｵﾝﾗｲﾝ時の確定処理の判定を修正(運用障害№434)
    Private Function prvcmdRegistEnabled_Chk()

        Dim llngCnt             As Integer  'ｶｳﾝﾀ
        Dim lblnClassCheck      As Boolean  'ﾃﾞｰﾀ分類正常区分(False:異常、True:正常)
        Dim llngParameterIndex  As Integer  'ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽ
        Dim lblnAns             As Boolean  '汎用結果判定

        Try
            
            '@確定ﾎﾞﾀﾝの使用不可
            'cmdRegist.Enabled = False
            
            '@ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽの初期化
            llngParameterIndex = 0
            
            With mtypDataCollect
                '@ﾛｯﾄID/WFIDが空欄の場合
                If .strChgID = vbNullString Then
                    Exit Function
                End If
                
                '@入力ﾊﾟﾗﾒｰﾀ毎に判断
                For llngCnt = 0 To .lngParameterCnt - 1
                    '入力ﾃﾞｰﾀﾌﾗｸﾞから判別
                    Select Case .typParameter(llngCnt).strInputDataFlag
                        Case CMstrZero
                        '@読込無し&入力無し
                            '@必須入力項目数が"0"の場合
                            If .typParameter(llngCnt).strMandatoryCount = CMstrZero Then
                                '@ﾊﾟﾗﾒｰﾀで並び：最後の場合は,ﾌﾗｸﾞを維持
                                If llngCnt = .lngParameterCnt - 1 Then
                                    '@ﾁｪｯｸOK
                                    lblnClassCheck = True
                                End If
                            Else
                                If .typParameter(llngCnt).lngInputDataCnt > CMlngOne Then
                                    '@入力ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽ
                                    llngParameterIndex = llngCnt
                                    
                                    '@ﾊﾟﾗﾒｰﾀの格納
                                    lblnAns = prvcmdRegistInputFlag_Set(llngParameterIndex)
                                    If lblnAns = True Then
                                        '@ﾁｪｯｸOK
                                        lblnClassCheck = True
                                    Else
                                        '@ﾁｪｯｸNG
                                        lblnClassCheck = False
                                        
                                        Exit For
                                    End If
                                Else
                                    '@装置ﾃﾞｰﾀの場合
                                    If .typParameter(llngCnt).strCollectionType = 1 Then
                                        Exit Function
                                    Else
                                        If vsfSlotMap.Enabled = True Then
                                            If vsfSlotMap.GetData(vsfSlotMap.Row, CMlngvsfSlotMapInputRequestC) <> vbNullString Then
                                                '@ﾁｪｯｸNG
                                                lblnClassCheck = False
                                                Exit For
                                            End If
                                        Else
                                            '@ﾁｪｯｸNG
                                                lblnClassCheck = False
                                                Exit For
                                        End If
                                    End If
                                End If
                            End If
                        
                        Case CMstrOne
                        '@読込済み
                            
                            '@処理なし
                            
                            
                        Case CMstrTwo
                        '@入力有りﾌﾗｸﾞ
                            '@入力ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽ
                            llngParameterIndex = llngCnt
                            
                            '@ﾊﾟﾗﾒｰﾀの格納
                            lblnAns = prvcmdRegistInputFlag_Set(llngParameterIndex)
                            If lblnAns = True Then
                                '@ﾁｪｯｸOK
                                lblnClassCheck = True
                            Else
                                '@ﾁｪｯｸNG
                                lblnClassCheck = False
                                
                                Exit For
                            End If
                            
                        Case CMstrThree
                        '@引継情報
                            '@入力ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽ
                            llngParameterIndex = llngCnt
                    
                            '@ﾊﾟﾗﾒｰﾀの格納
                            lblnAns = prvcmdRegistInputFlag_Set(llngParameterIndex)
                            If lblnAns = True Then
                                '@ﾁｪｯｸOK
                                lblnClassCheck = True
                            Else
                                '@ﾁｪｯｸNG
                                lblnClassCheck = False
                                
                                Exit For
                            End If
                        
                        Case CMstrFour
                        '@ｵﾝﾗｲﾝ
                            '@装置ﾃﾞｰﾀ行がある場合
                            If vsfCollectValue.Rows.Count > 0 Then
                                '@装置ﾃﾞｰﾀ入力済みか
                                If mtypDataCollect.typParameter(vsfCollect.Row - 1).strInputDataFlag = CMstrOne Or _
                                    mtypDataCollect.typParameter(vsfCollect.Row - 1).strInputDataFlag = CMstrFour Then
                                    '@ﾁｪｯｸNG
                                    lblnClassCheck = False
                                Else
                                    '@ﾁｪｯｸOK
                                    lblnClassCheck = True
                                End If
                            Else
                                '@ﾁｪｯｸNG
                                lblnClassCheck = False
                            End If
                    End Select
                Next llngCnt
            End With
            
            '@確定ﾎﾞﾀﾝ活性化処理
            If lblnClassCheck = True Then
                cmdRegist.Enabled = True
            Else
                cmdRegist.Enabled = False
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdRegistEnabled_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvcmdRegistInputFlag_Set
    '機　能：登録内容のﾁｪｯｸ処理
    '引　数：llngParameterIndex：ﾊﾟﾗﾒｰﾀｲﾝﾃﾞｯｸｽ
    '戻り値：True:OK/False:NG
    '作成日：2005/02/03 (Thu) 13:21:01 S.Deguchi
    '更新日：2005/02/03 (Thu) 13:21:01
    '備　考：
    Private Function prvcmdRegistInputFlag_Set(ByVal llngParameterIndex As Integer) As Boolean

        Dim llngCnt             As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngInputCnt        As Integer      '入力件数
        Dim lblnClassCheck1     As Boolean      'ﾃﾞｰﾀ分類1正常区分(False:異常、True:正常)
        Dim lblnClassCheck2     As Boolean      'ﾃﾞｰﾀ分類2正常区分(False:異常、True:正常)
        Dim lblnClassCheck3     As Boolean      'ﾃﾞｰﾀ分類3正常区分(False:異常、True:正常)
        Dim lblnClassCheck4     As Boolean      'ﾃﾞｰﾀ分類4正常区分(False:異常、True:正常)
        Dim lblnDataCheck       As Boolean      '値正常区分(False:異常、True:正常)

        Try

            '@初期化
            lblnClassCheck1 = False
            lblnClassCheck2 = False
            lblnClassCheck3 = False
            lblnClassCheck4 = False
            lblnDataCheck = False

            prvcmdRegistInputFlag_Set = False

            With mtypDataCollect.typParameter(llngParameterIndex)
                '@入力＆引継
                If .strInputDataFlag = CMstrTwo Or .strInputDataFlag = CMstrThree Then
                    For llngCnt = 0 To .lngInputDataCnt - 1
                        '@入力ﾃﾞｰﾀの1行目が全て空欄の場合はｽｷｯﾌﾟ
                        If (.typInputData(llngCnt).strClass1Disp = CMstrOne And .typInputData(llngCnt).strClass1 = vbNullString) And _
                           (.typInputData(llngCnt).strClass2Disp = CMstrOne And .typInputData(llngCnt).strClass2 = vbNullString) And _
                           (.typInputData(llngCnt).strClass3Disp = CMstrOne And .typInputData(llngCnt).strClass3 = vbNullString) And _
                           (.typInputData(llngCnt).strClass4Disp = CMstrOne And .typInputData(llngCnt).strClass4 = vbNullString) And _
                           (.typInputData(llngCnt).strData = vbNullString) Then
                            
                            Exit For
                        End If
                        
                        '@ﾃﾞｰﾀ分類1
                        If .typInputData(llngCnt).strClass1Disp = CMstrOne Then
                        '@表示区分：表示
                            If .typInputData(llngCnt).strClass1 <> vbNullString Then
                            '@ﾃﾞｰﾀ有り
                                lblnClassCheck1 = True
                            Else
                            '@ﾃﾞｰﾀ無し
                                lblnClassCheck1 = False
                            End If
                        Else
                        '@表示区分：非表示
                            If .typInputData(llngCnt).strClass1 <> vbNullString Then
                            '@ﾃﾞｰﾀ有り
                                lblnClassCheck1 = False
                            Else
                            '@ﾃﾞｰﾀ無し
                                lblnClassCheck1 = True
                            End If
                        End If
            
                        '@ﾃﾞｰﾀ分類2
                        If .typInputData(llngCnt).strClass2Disp = CMstrOne Then
                        '@表示区分：表示
                            If .typInputData(llngCnt).strClass2 <> vbNullString Then
                            '@ﾃﾞｰﾀ有り
                                lblnClassCheck2 = True
                            Else
                            '@ﾃﾞｰﾀ無し
                                lblnClassCheck2 = False
                            End If
                        Else
                        '@表示区分：非表示
                            If .typInputData(llngCnt).strClass2 <> vbNullString Then
                            '@ﾃﾞｰﾀ有り
                                lblnClassCheck2 = False
                            Else
                            '@ﾃﾞｰﾀ無し
                                lblnClassCheck2 = True
                            End If
                        End If
            
                        '@ﾃﾞｰﾀ分類3
                        If .typInputData(llngCnt).strClass3Disp = CMstrOne Then
                        '@表示区分：表示
                            If .typInputData(llngCnt).strClass3 <> vbNullString Then
                            '@ﾃﾞｰﾀ有り
                                lblnClassCheck3 = True
                            Else
                            '@ﾃﾞｰﾀ無し
                                lblnClassCheck3 = False
                            End If
                        Else
                        '@表示区分：非表示
                            If .typInputData(llngCnt).strClass3 <> vbNullString Then
                            '@ﾃﾞｰﾀ有り
                                lblnClassCheck3 = False
                            Else
                            '@ﾃﾞｰﾀ無し
                                lblnClassCheck3 = True
                            End If
                        End If
            
                        '@ﾃﾞｰﾀ分類4
                        If .typInputData(llngCnt).strClass4Disp = CMstrOne Then
                        '@表示区分：表示
                            If .typInputData(llngCnt).strClass4 <> vbNullString Then
                            '@ﾃﾞｰﾀ有り
                                lblnClassCheck4 = True
                            Else
                            '@ﾃﾞｰﾀ無し
                                lblnClassCheck4 = False
                            End If
                        Else
                        '@表示区分：非表示
                            If .typInputData(llngCnt).strClass4 <> vbNullString Then
                            '@ﾃﾞｰﾀ有り
                                lblnClassCheck4 = False
                            Else
                            '@ﾃﾞｰﾀ無し
                                lblnClassCheck4 = True
                            End If
                        End If
            
                        '@値
                        If .typInputData(llngCnt).strData <> vbNullString Then
                        '@ﾃﾞｰﾀ有り
                            lblnDataCheck = True
                        Else
                        '@ﾃﾞｰﾀ無し
                            lblnDataCheck = False
                        End If
            
                        '@上記ﾃﾞｰﾀ分類1～4＆値のﾌﾗｸﾞ状況から判断
                        If lblnClassCheck1 = True And lblnClassCheck2 = True And _
                           lblnClassCheck3 = True And lblnClassCheck4 = True And _
                           lblnDataCheck = True Then
                            
                            llngInputCnt = llngInputCnt + 1
                        Else
                            llngInputCnt = llngInputCnt
                        End If
                    Next llngCnt
                        
                    '@必須入力項目数以上か否かで判断
                    If llngInputCnt >= CLng(.strMandatoryCount) Then
                        '@初期化
                        llngInputCnt = 0
                    Else
                        '@必須入力項目が0の場合
                        If .strMandatoryCount <> CMlngZero Then
                                
                            '@失敗を返す
                            prvcmdRegistInputFlag_Set = False
                            
                            Exit Function
                        End If
                    End If
                Else
                    '@失敗を返す
                    prvcmdRegistInputFlag_Set = False
                    
                    Exit Function
                End If
            End With

            '@成功を返す
            prvcmdRegistInputFlag_Set = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdRegistInputFlag_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvRegistData_Set
    '機　能：確定構造体に情報をｾｯﾄ
    '引　数：ltypWfChgCollection：登録構造体
    '戻り値：なし
    '作成日：2005/01/27 (Thu) 08:29:05 S.Deguchi
    '更新日：2006/12/20 (Wed) 16:14:32 N.Kasai
    '備　考：
    '　　　：2005/11/07 (Mon) 13:59:32 S.Deguchi    作業者IDをｾｯﾄする処理を修正
    '　　　：2006/12/20 (Wed) 16:14:32 N.Kasai      収集項目ﾀｲﾌﾟ追加(№01515)
    Private Sub prvRegistData_Set(ByRef ltypWfChgCollection As WfChgCollection)

        Dim llngCnt         As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngDataCnt     As Integer      '登録ﾃﾞｰﾀﾙｰﾌﾟｶｳﾝﾀ
        Dim llngSaveCnt     As Integer      '登録ﾃﾞｰﾀｶｳﾝﾀ
        Dim lstrTempData    As String       '登録ﾃﾞｰﾀ退避領域

        Try
            
            '@初期化
            If ltypWfChgCollection.typEqWfDataEntry Is Nothing Then
                ltypWfChgCollection.typEqWfDataEntry = New List(Of EqWfDataEntry)
            Else
                ltypWfChgCollection.typEqWfDataEntry.Clear()
            End If
            
            '@確定構造体に情報をｾｯﾄ
            With ltypWfChgCollection
                '@第1階層の情報をｾｯﾄ
                For llngCnt = 0 To mtypDataCollect.lngParameterCnt - 1
                    '@ﾊﾟﾗﾒｰﾀID/ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ(使用していない)
                    .strParameterID = vbNullString
                    .strParameterVersion = vbNullString
                    
                    '@ｼｽﾃﾑﾌﾞﾛｯｸ
                    .strSbID = pstrSBID
                    
                    '@ClassDivision
                    .strClassDivision = CPstrCD01
                    
                    '@ｷｬﾘｱID
                    .strCarrierId = txtCarrier.Text
                    
                    '@最終更新日時
                    .strLotLastUpdate = mstrLotLastUpdate
                    
                    '@作業者ID：後ほどｾｯﾄ
                    .strEmpID = vbNullString
                    
                    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                    .strMsgVer = CMstrspc_regcollectVer
                    
                    '@ﾛｯﾄ単位/WF単位で処理分岐
                    If optDataUnit1.Checked = True Then
                    '@ﾛｯﾄ単位
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                        .strSlotPosition = vbNullString
                    Else
                    '@WF単位
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                        .strSlotPosition = vsfSlotMap.GetData(vsfSlotMap.Row, CMlngvsfSlotMapNoC)
                    End If
                Next llngCnt
                
                    '@ﾃﾞｰﾀﾘｽﾄ情報作成
                    '@初期化
                    .lngEqWfDataEntryCnt = 0
                    
                '@第2階層の情報をｾｯﾄ
                For llngCnt = 0 To mtypDataCollect.lngParameterCnt - 1
                    For llngDataCnt = 0 To mtypDataCollect.typParameter(llngCnt).lngInputDataCnt - 1
                        '@ﾓｼﾞｭｰﾙ構造体へ格納している情報のInputDataFlagが"2"の場合のみ
                        If mtypDataCollect.typParameter(llngCnt).strInputDataFlag = CMstrTwo Or mtypDataCollect.typParameter(llngCnt).strInputDataFlag = CMstrThree Then
                            '@入力ﾊﾟﾗﾒｰﾀ情報欄でﾃﾞｰﾀ分類1～4,値で表示ﾌﾗｸﾞ"1"＆Null以外の場合はｽｷｯﾌﾟ
                            If (mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass1 = vbNullString And _
                                mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass1Disp = CMstrOne) Or _
                                (mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass2 = vbNullString And _
                                mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass2Disp = CMstrOne) Or _
                                (mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass3 = vbNullString And _
                                mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass3Disp = CMstrOne) Or _
                                (mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass4 = vbNullString And _
                                mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass4Disp = CMstrOne) Or _
                                mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strData = vbNullString Then
                                
                                '@ｽｷｯﾌﾟする
                            Else
                                '@登録ｶｳﾝﾄｱｯﾌﾟ
                                .lngEqWfDataEntryCnt = .lngEqWfDataEntryCnt + 1
                                llngSaveCnt = .lngEqWfDataEntryCnt
                                
                                '@領域確保
                                Dim typEqEqWfDataEntrytmp = New EqWfDataEntry
                                
                                '@文字列退避領域初期化
                                lstrTempData = vbNullString
                                
                                '@DV_NAME_PARAMETERの編集(：ﾃﾞｰﾀ分類1：ﾃﾞｰﾀ分類2：ﾃﾞｰﾀ分類3：ﾊﾟﾗﾒｰﾀID：ﾃﾞｰﾀ分類4：)
                                '@区切り文字列ｾｯﾄ(=:)
                                lstrTempData = lstrTempData & CMstrColon
                                
                                '@ﾃﾞｰﾀ分類1
                                If mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass1 = CMstrNaString Then
                                    '@Nullｾｯﾄ
                                    lstrTempData = lstrTempData & vbNullString
                                Else
                                    lstrTempData = lstrTempData & _
                                        mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass1
                                End If
                                
                                '@区切り文字列ｾｯﾄ(=:)
                                lstrTempData = lstrTempData & CMstrColon
                                
                                '@ﾃﾞｰﾀ分類2
                                If mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass2 = CMstrNaString Then
                                    '@Nullｾｯﾄ
                                    lstrTempData = lstrTempData & vbNullString
                                Else
                                    lstrTempData = lstrTempData & _
                                        mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass2
                                End If
                                
                                '@区切り文字列ｾｯﾄ(=:)
                                lstrTempData = lstrTempData & CMstrColon
                                
                                '@ﾃﾞｰﾀ分類3
                                If mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass3 = CMstrNaString Then
                                    '@Nullｾｯﾄ
                                    lstrTempData = lstrTempData & vbNullString
                                Else
                                    lstrTempData = lstrTempData & _
                                        mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass3
                                End If
                                
                                '@区切り文字列ｾｯﾄ(=:)
                                lstrTempData = lstrTempData & CMstrColon
                                
                                '@ﾊﾟﾗﾒｰﾀID
                                lstrTempData = lstrTempData & mtypDataCollect.typParameter(llngCnt).strParameterID
                                
                                '@区切り文字列ｾｯﾄ(=:)
                                lstrTempData = lstrTempData & CMstrColon
                                
                                '@ﾃﾞｰﾀ分類4
                                If mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass4 = CMstrNaString Then
                                    '@Nullｾｯﾄ
                                    lstrTempData = lstrTempData & vbNullString
                                Else
                                    lstrTempData = lstrTempData & _
                                        mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strClass4
                                End If
                                
                                '@区切り文字列ｾｯﾄ(=:)
                                lstrTempData = lstrTempData & CMstrColon
                                
                                '@ﾊﾟﾗﾒｰﾀに作成した情報をｾｯﾄ
                                typEqEqWfDataEntrytmp.strDvNameParameter = lstrTempData
                                
                                '@値
                                If mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strData = CMstrNaString Then
                                    typEqEqWfDataEntrytmp.strDvValue = vbNullString
                                Else
                                    typEqEqWfDataEntrytmp.strDvValue = _
                                        mtypDataCollect.typParameter(llngCnt).typInputData(llngDataCnt).strData
                                End If
                                
                                '@収集項目ﾀｲﾌﾟ
                                typEqEqWfDataEntrytmp.strCollectionType = _
                                        mtypDataCollect.typParameter(llngCnt).strCollectionType
                                .typEqWfDataEntry.Add(typEqEqWfDataEntrytmp)
                            End If
                        End If
                    Next llngDataCnt
                Next llngCnt
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvRegistData_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdVsfDownCollectValue_Click
    '機　能：作業記録ﾃﾞｰﾀ入力ｸﾞﾘｯﾄﾞを下方向へﾍﾟｰｼﾞを移動する。
    '引　数：なし
    '戻り値：なし
    '作成日：2008/04/02 (Wed) 10:03:16 T.Sawaguchi
    '更新日：
    '備　考：案件No02761対応により追加

    Private Sub cmdVsfDownCollectValue_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVsfDownCollectValue.Click
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdDown(vsfCollectValue, cmdVsfUpCollectValue, cmdVsfDownCollectValue, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdVsfDownWF_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：cmdVsfUpCollectValue_Click
    '機　能：作業記録ﾃﾞｰﾀ入力ｸﾞﾘｯﾄﾞを上方向へﾍﾟｰｼﾞを移動する。
    '戻り値：なし
    '作成日：2008/04/02 (Wed) 10:03:16 T.Sawaguchi
    '更新日：
    '備　考：案件No02761対応により追加

    Private Sub cmdVsfUpCollectValue_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVsfUpCollectValue.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdUp(vsfCollectValue, cmdVsfUpCollectValue, cmdVsfDownCollectValue)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdVsfUpWF_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfInputControll
    '機　能：ﾃﾞｰﾀ入力後のｶﾚﾝﾄ行設定
    '引　数：lobjvsfGrid            ：ｸﾞﾘｯﾄﾞ
    '　　　：lvalKeyCol             ：KeyのCol
    '　　　：lobjcmdUp              ：前頁ﾎﾞﾀﾝ(省略可)
    '　　　：lobjcmdDown            ：次頁ﾎﾞﾀﾝ(省略可)
    '　　　：lblnRowNo              ：行番号(省略可)True：固定列の最左列に行番設定する、False：行番設定なし
    '　　　：lblnLastSpace          ：最下段の空白(省略可)Ture：最下段の空白あり、False：最下段の空白なし
    '　　　：lstrVsfCollectValueRow ：選択された行
    '戻り値：なし
    '作成日：2008/04/04 (Fri) 10:47:10　T.Sawaguchi
    '更新日：
    '備　考：vsfcollectValueｸﾞﾘｯﾄﾞで使用
    '　　　：
    Public Sub prvVsfInputControll(ByVal lobjvsfGrid As Object, _
                               ByVal lvalKeyCol As Object, _
                               Optional ByVal lobjcmdUp As Object = Nothing, _
                               Optional ByVal lobjcmdDown As Object = Nothing, _
                               Optional ByVal lblnRowNo As Boolean = True, _
                               Optional ByVal lblnLastSpace As Boolean = True, _
                               Optional ByVal lstrVsfCollectValueRow As String = vbNullString)
        
        Dim llngDoCnt       As Integer  '行
        Dim llngRow         As Integer  '行
        Dim llngRows        As Integer  '１頁行数
        Dim llngTopRow      As String   '頁先頭行
        Dim llngCnt         As Integer  'ｶｳﾝﾄ
        Dim lstrKey         As String   'ｿｰﾄ前のｶﾚﾝﾄKey
        Dim llngKeyCol()    As Integer  'ｶﾚﾝﾄ行保持用のCol(個別)
        Dim llngLen         As Integer  '文字数
        Dim llngKeyNum      As Integer  '文字列のvbTabの桁位置
        Dim llngColCnt      As Integer  'ｶﾚﾝﾄ行保持用のCol数
        Dim lstrCol         As String   'ｶﾚﾝﾄ行保持用のCol(複数)
        Dim lstrKeyAfter    As String   'ｶﾚﾝﾄ行比較用
        
        With CType(lobjvsfGrid,C1FlexGrid)
            
            '@ｿｰﾄ前のKey値取得
            lstrKey = pubstrVsfTag_Get(lobjvsfGrid, 2)

            '@ｸﾞﾘｯﾄﾞの１頁の行数を取得
            llngRows = publngVsfPageRows_Get(lobjvsfGrid)

            '@文字列数取得
            llngLen = Len(lvalKeyCol)
            If llngLen = 0 Then
                '@ｶﾚﾝﾄｷｰ値の初期化
                Call pubblnVsfTag_Set(lobjvsfGrid, 2, vbNullString)

                Exit Sub
            End If

            '@ｶﾚﾝﾄ行検索用のｷｰColの取得
            llngKeyNum = 1
            llngColCnt = 0
            For llngCnt = 1 To llngLen
                If Mid$(lvalKeyCol, llngCnt, 1) = vbTab Then
                    lstrCol = Mid$(lvalKeyCol, llngKeyNum, llngCnt - llngKeyNum)
                    If IsNumeric(lstrCol) = True Then
                        llngColCnt = llngColCnt + 1

                        ReDim Preserve llngKeyCol(llngColCnt)

                        llngKeyCol(llngColCnt) = CLng(lstrCol)

                        llngKeyNum = llngCnt + 1
                    End If
                End If
            Next llngCnt

            If llngColCnt = 0 Then
                If IsNumeric(lvalKeyCol) = True Then
                    llngColCnt = llngColCnt + 1
                    ReDim Preserve llngKeyCol(llngColCnt)
                    llngKeyCol(llngColCnt) = CLng(lvalKeyCol)
                End If
            Else
                If llngKeyNum <= llngLen Then
                    lstrCol = Mid$(lvalKeyCol, llngKeyNum, llngLen)
                    If IsNumeric(lstrCol) = True Then
                        llngColCnt = llngColCnt + 1

                        ReDim Preserve llngKeyCol(llngColCnt)

                        llngKeyCol(llngColCnt) = CLng(lstrCol)
                    End If
                End If
            End If
            
            '@ｶﾚﾝﾄ行検索
            For llngDoCnt = .Rows.Fixed To .Rows.Count - 1

                lstrKeyAfter = vbNullString

                '@ｷｰ値取得
                For llngCnt = 1 To llngColCnt
                    lstrKeyAfter = lstrKeyAfter & .GetData(llngDoCnt, llngKeyCol(llngCnt))
                Next llngCnt

            Next llngDoCnt
            
            '@現在の行をｾｯﾄする。
            If lstrVsfCollectValueRow <> vbNullString Then
                llngRow = Val(lstrVsfCollectValueRow)
            End If
            
            '@ｶﾚﾝﾄ行が"-1"の場合は"0"をｾｯﾄする
            If llngRow = -1 Then
                llngRow = 0
            End If
            
            
            '@真ん中の行の計算
            If llngRows Mod 2 = 0 Then
                '@1ﾍﾟｰｼﾞ偶数行の場合は、真ん中より1つ上の行
                llngTopRow = llngRow - ((llngRows \ 2) - 1)
            Else
                '@1ﾍﾟｰｼﾞ奇数行の場合は、真ん中の行
                llngTopRow = llngRow - (llngRows \ 2)
            End If
            
            '@頁先頭行取得
            If llngTopRow < .Rows.Fixed Then
                llngTopRow = .Rows.Fixed
            End If
            
            '@行表示
            For llngCnt = .Rows.Count - 1 To llngTopRow Step -1
                .Rows(llngCnt).Visible = True
            Next llngCnt
            
            '@頁切替ﾎﾞﾀﾝがあり、最下段空白ありの場合
            If TypeName(lobjcmdUp) <> CMstrNothing _
               And TypeName(lobjcmdDown) <> CMstrNothing _
               And lblnLastSpace = True _
               And llngRows + .Rows.Fixed < .Rows.Count Then
                '@行非表示
                For llngCnt = llngRow To .Rows.Fixed Step -1 '@To llngTopRow

                    If llngRow - llngCnt >= 4 Then
                        .Rows(llngCnt).Visible = False
                    End If
                Next llngCnt
                
                 '@ｶﾚﾝﾄ行設定
                 If Val(lstrVsfCollectValueRow) = llngRow Then
                    .TopRow = llngTopRow - llngCnt
                    .Row = llngRow
                Else
                    .TopRow = llngTopRow - llngCnt
                    .Row = Val(lstrVsfCollectValueRow)
                End If
           Else
                '@先頭行の設定
                If llngRows + .Rows.Fixed < .Rows.Count Then
                    '@データが1ページに満たない場合
                    '@ｶﾚﾝﾄ行設定
                    .TopRow = llngTopRow
                    .Row = llngRow
                Else
                    '@2ページ以上データがある場合
                    '@ｶﾚﾝﾄ行設定
                    .TopRow = .Rows.Fixed
                    .Row = llngRow
                End If
            End If
        
            If .TopRow + llngRows >= .Rows.Count Then
                '@頁切替ﾎﾞﾀﾝがない場合
                If TypeName(lobjcmdDown) <> CMstrNothing Then
                    '@次頁ﾎﾞﾀﾝﾛｯｸ
                    lobjcmdDown.Enabled = False
                End If
            Else
                '@頁切替ﾎﾞﾀﾝがない場合
                If TypeName(lobjcmdDown) <> CMstrNothing Then
                    '@次頁ﾎﾞﾀﾝﾛｯｸ解除
                    lobjcmdDown.Enabled = True
                End If
            End If
            
            If .TopRow = .Rows.Fixed Then
                '@頁切替ﾎﾞﾀﾝがない場合
                If TypeName(lobjcmdUp) <> CMstrNothing Then
                    '@前頁ﾎﾞﾀﾝﾛｯｸ
                    lobjcmdUp.Enabled = False
                End If
            Else
                '@頁切替ﾎﾞﾀﾝがない場合
                If TypeName(lobjcmdUp) <> CMstrNothing Then
                    '@前頁ﾎﾞﾀﾝﾛｯｸ解除
                    lobjcmdUp.Enabled = True
                End If
            End If
            
            '@=======================
            '@　ﾍﾟｰｼﾞ先頭行格納処理
            '@=======================
            Call pubblnVsfTag_Set(lobjvsfGrid, 1, .TopRow)
            
            '@ﾛｯｸ解除
            .Enabled = True
            '@ﾌｫｰｶｽｾｯﾄ
            If .Visible = True Then
                If .Enabled = True Then
                    Call pubSetFocus(lobjvsfGrid)
                End If
            End If
        End With
        
    End Sub


    '関数名：cmdVsfDownCollect_Click
    '機　能：ﾊﾟﾗﾒｰﾀ表示ｸﾞﾘｯﾄﾞを下方向へﾍﾟｰｼﾞを移動する。
    '引　数：なし
    '戻り値：なし
    '作成日：2008/04/04 (Fri) 11:23:04　T.Sawaguchi
    '更新日：
    '備　考：案件No02761対応により追加

    Private Sub cmdVsfDownCollect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVsfDownCollect.Click
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdDown(vsfCollect, cmdVsfUpCollect, cmdVsfDownCollect, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdVsfDownWF_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：cmdVsfUpCollect_Click
    '機　能：ﾊﾟﾗﾒｰﾀ表示ｸﾞﾘｯﾄﾞを上方向へﾍﾟｰｼﾞを移動する。
    '戻り値：なし
    '作成日：2008/04/04 (Fri) 11:23:04　T.Sawaguchi
    '更新日：
    '備　考：案件No02761対応により追加

    Private Sub cmdVsfUpCollect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVsfUpCollect.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdUp(vsfCollect, cmdVsfUpCollect, cmdVsfDownCollect)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdVsfUpWF_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdVsfDownWF_Click
    '機　能：SLOT表示ｸﾞﾘｯﾄﾞを下方向へﾍﾟｰｼﾞを移動する。
    '引　数：なし
    '戻り値：なし
    '作成日：2008/04/04 (Fri) 14:16:37　T.Sawaguchi
    '更新日：
    '備　考：案件No02761対応により追加

    Private Sub cmdVsfDownWF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVsfDownWF.Click
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdDown(vsfSlotMap, cmdVsfUpWF, cmdVsfDownWF, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdVsfDownWF_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：cmdVsfUpWF_Click
    '機　能：SLOT表示ｸﾞﾘｯﾄﾞを上方向へﾍﾟｰｼﾞを移動する。
    '戻り値：なし
    '作成日：　T.S2008/04/04 (Fri) 14:16:28awaguchi
    '更新日：
    '備　考：案件No02761対応により追加

    Private Sub cmdVsfUpWF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVsfUpWF.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdUp(vsfSlotMap, cmdVsfUpWF, cmdVsfDownWF)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdVsfUpWF_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：prvErrMsgCheck
    '機　能：ｴﾗｰMsgを解析し入力ｴﾗｰかを判断する
    '引　数：なし
    '戻り値：該当無し；True　、該当あり；False
    '作成日：2008/05/03 (Sat) 09:04:18 T.Sawaguchi
    '更新日：
    '備　考：2008/05/03 (Sat) 09:04:18 T.Sawaguchi 案件02853対応でｴﾗｰMsgをﾁｪｯｸする。
    Private Function prvErrMsgCheck() As Boolean

        Try
            
            prvErrMsgCheck = False
            
            '@下記のｴﾗｰMsgの場合以外は「True」で返す。
            Select Case Strings.Left$(pstrDMsg, 8)
                
                Case Strings.Left$(CPstrMsgWar001E, 8), _
                     Strings.Left$(CPstrMsgWar001F, 8), _
                     Strings.Left$(CPstrMsgWar0027, 8), _
                     Strings.Left$(CPstrMsgWar004V, 8), _
                     Strings.Left$(CPstrMsgWar007X, 8)

                        prvErrMsgCheck = False
                        
                Case Else
                        '@不一致だったのでTrueをｾｯﾄする。
                        prvErrMsgCheck = True
                 
            End Select
            
            '@ｴﾗｰMsgをｸﾘｱする。
            pstrDMsg = vbNullString
            
            Exit Function
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvErrMsgCheck"
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfCollect.BeforeDoubleClick, vsfCollectValue.BeforeDoubleClick, vsfSlotMap.BeforeDoubleClick

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
    '備　考： Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles txtCarrier.Enter,
                                                                       txtLot.Enter,
                                                                       optDataUnit1.Click,
                                                                       optDataUnit2.Click,
                                                                       vsfSlotMap.Enter,
                                                                       vsfCollect.Enter,
                                                                       vsfCollectValue.Enter,
                                                                       cmdClose.Enter,
                                                                       cmdLineDelete.Enter,
                                                                       cmdLineInsert.Enter,
                                                                       cmdNaInput.Enter,
                                                                       cmdRegist.Enter,
                                                                       cmdVsfDownWF.Enter,
                                                                       cmdVsfUpWF.Enter,
                                                                       cmdVsfDownCollect.Enter,
                                                                       cmdVsfUpCollect.Enter,
                                                                       cmdVsfDownCollectValue.Enter,
                                                                       cmdVsfUpCollectValue.Enter

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

    '関数名：vsfCollectValue_BeforeDoubleClick
    '機　能：編集モード制御 
    '作成日：2019/11/05 NSYS
    '更新日：
    '備　考：
    Private Sub vsfCollectValue_BeforeDoubleClick(sender As Object, e As EventArgs) Handles vsfCollectValue.BeforeDoubleClick
        
        '@編集ﾓｰﾄﾞの設定
            With vsfCollectValue
                Select Case .Col
                    '@ﾃﾞｰﾀ分類名1～4 or ﾃﾞｰﾀ値の場合
                    Case CMlngvsfCollectValueClass1C, CMlngvsfCollectValueClass2C, _
                         CMlngvsfCollectValueClass3C, CMlngvsfCollectValueClass4C, CMlngvsfCollectValueDataC                          
                        '@N/A文字の場合はﾀﾞﾌﾞﾙｸﾘｯｸOK                        
                        If .GetData(.Row, .Col) = CMstrNaString Then
                            '@編集を許可（ﾀﾞﾌﾞﾙｸﾘｯｸ含み）
                            .AllowEditing = True
                        Else
                            '@編集を許可（ﾀﾞﾌﾞﾙｸﾘｯｸ以外）
                            .AllowEditing = False
                        End If
                End Select

            End With
        
    End Sub

End Class
