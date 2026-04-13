'ﾌｧｲﾙ名：xxEN00Z0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾚﾁｸﾙ管理 ﾒｲﾝﾌｫｰﾑ
'作成日：2004/08/24 (Tue) 09:21:49 Y.Yamagishi
'更新日：2012/01/24 (Tue) 11:49:51 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Imports SEComboBoxEx
Public Class frmxxEN00Z0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00Z0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00Z0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00Z0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00Z0)
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
    '@↓2012/01/24 (Tue) 11:49:51 T.Oide **************************************************
    'Private Const CMstrLocalVersion                         As String = "12.01"
    'Private Const CMstrLocalVersion                         As String = "12.02"
    '@↑2012/01/24 (Tue) 11:49:51 T.Oide **************************************************
    Private Const CMstrLocalVersion                         As String = "12.03"

    '@機能ID
    Private Const CMstrLocalMenuKey                         As String = CPstrKeyEN00Z0

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_rtclcodelistVer                  As String = "01.00"                 'ﾚﾁｸﾙ型番取得
    Private Const CMstrmas_wplist__Ver                      As String = "05.01"                 '装置一覧取得
    Private Const CMstrrtcllist____Ver                      As String = "01.05"                 'ﾚﾁｸﾙ情報取得
    Private Const CMstrrtclregist__Ver                      As String = "01.00"                 'ﾚﾁｸﾙ登録
    Private Const CMstrrtclchgstat_Ver                      As String = "01.00"                 'ﾚﾁｸﾙ状態変更
    Private Const CMstrrtclDelete__Ver                      As String = "01.00"                 'ﾚﾁｸﾙ削除
    Private Const CMstrcarrmanuoutportVer                   As String = "01.00"                 'ｷｬﾘｱ手動出庫要求
    Private Const CMstrmas_stockerlistVer                   As String = "01.00"                 'ｽﾄｯｶｰﾏｽﾀ取得

    '@vsf共通の定数宣言
    Private Const CMlngVsfRowTitle                          As Integer = 0                         'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                          As Integer = 0                         'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                         As Integer = 12                        'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfHHeight                           As Integer = 24                        'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfHeight                            As Integer = 38                        '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfRtclListRegistCnt                 As Integer = 5                         'ﾚﾁｸﾙ登録ﾘｽﾄ行数
    Private Const CMlngvsfRtclListMenteCnt                  As Integer = 7                         'ﾚﾁｸﾙﾒﾝﾃﾅﾝｽﾘｽﾄ行数
    Private Const CMlngvsfRtclListWpInCnt                   As Integer = 10                        '装置内ﾚﾁｸﾙﾘｽﾄ行数

    '@vsfRtclListRegist(ﾚﾁｸﾙ登録Tab)の定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfRtclListRegistNo                  As Integer = 0                         '№
    Private Const CMlngvsfRtclListRegistStatus              As Integer = 1                         '状態
    Private Const CMlngvsfRtclListRegistRtclID              As Integer = 2                         'ﾚﾁｸﾙID
    Private Const CMlngvsfRtclListRegistCurrentPotition     As Integer = 3                         '現在位置
    Private Const CMlngvsfRtclListRegistArriveTime          As Integer = 4                         '入荷日

    '@vsfRtclListRegist(ﾚﾁｸﾙ登録Tab)の定数宣言(幅)
    Private Const CMlngvsfWColRtclListRegistNo              As Integer = 33                       '№
    Private Const CMlngvsfWColRtclListRegistRtclID          As Integer = 293                      'ﾚﾁｸﾙID
    Private Const CMlngvsfWColRtclListRegistCurrentPotition As Integer = 200                      '設定
    Private Const CMlngvsfWColRtclListRegistStatus          As Integer = 54                       '状態
    Private Const CMlngvsfWColRtclListRegistArriveTime      As Integer = 98                       '登録日

    '@vsfRtclListRegist(ﾚﾁｸﾙ登録Tab)の定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfRtclListRegistNo                  As String = "№"                    '№
    Private Const CMstrvsfRtclListRegistStatus              As String = "状態"                  '状態
    Private Const CMstrvsfRtclListRegistRtclID              As String = "ﾚﾁｸﾙID"            'ﾚﾁｸﾙID
    Private Const CMstrvsfRtclListRegistCurrentPotition     As String = "現在位置"              '現在位置
    Private Const CMstrvsfRtclListRegistArriveTime          As String = "入荷日"                '入荷日

    '@vsfRtclListMente(ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab)の定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfRtclListMenteNo                   As Integer = 0                         '№
    Private Const CMlngvsfRtclListMenteStatus               As Integer = 1                         '状態
    Private Const CMlngvsfRtclListMenteRtclID               As Integer = 2                         'ﾚﾁｸﾙID
    Private Const CMlngvsfRtclListMenteSMIF                 As Integer = 3                         'SMIFID
    Private Const CMlngvsfRtclListMenteCurrentPotition      As Integer = 4                         '現在位置
    Private Const CMlngvsfRtclListMenteArriveTime           As Integer = 12                        '入荷日
    Private Const CMlngvsfRtclListMenteEditTime             As Integer = 13                        '最終更新日
    Private Const CMlngvsfRtclListMenteWpInFlag             As Integer = 5                         '装置内ﾌﾗｸﾞ(非表示)
    Private Const CMlngvsfRtclListMenteStatusID             As Integer = 6                         '状態ID(非表示)
    Private Const CMlngvsfRtclListMenteReasonCode           As Integer = 7                         'ｴﾗｰ理由(非表示)
    Private Const CMlngvsfRtclListMenteReasonComments       As Integer = 8                         'ｴﾗｰｺﾒﾝﾄ(非表示)
    Private Const CMlngvsfRtclListMenteEditTimeWk           As Integer = 9                         '最終更新日時(非表示)
    Private Const CMlngvsfRtclListMenteStockerInFlag        As Integer = 10                        'ｽﾄｯｶｰ内ﾌﾗｸﾞ(非表示)
    Private Const CMlngvsfRtclListMenteCurrentPotitionID    As Integer = 11                        '現在位置ID

    '@vsfRtclListMente(ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab)の定数宣言(幅)
    Private Const CMlngvsfWColRtclListMenteNo               As Integer = 47                        '№
    Private Const CMlngvsfWColRtclListMenteStatus           As Integer = 54                        '状態
    Private Const CMlngvsfWColRtclListMenteRtclID           As Integer = 167                       'ﾚﾁｸﾙID
    Private Const CMlngvsfWColRtclListMenteSMIF             As Integer = 77                        'SMIFID
    Private Const CMlngvsfWColRtclListMenteCurrentPotition  As Integer = 198                       '現在位置
    Private Const CMlngvsfWColRtclListMenteArriveTime       As Integer = 98                        '入荷日
    Private Const CMlngvsfWColRtclListMenteEditTime         As Integer = 98                        '最終更新日
    Private Const CMlngvsfWColRtclListMenteWpInFlag         As Integer = 0                         '装置内ﾌﾗｸﾞ(非表示)
    Private Const CMlngvsfWColRtclListMenteStatusID         As Integer = 0                         '状態ID(非表示)
    Private Const CMlngvsfWRtclListMenteReasonCode          As Integer = 0                         'ｴﾗｰ理由(非表示)
    Private Const CMlngvsfWRtclListMenteReasonComments      As Integer = 0                         'ｴﾗｰｺﾒﾝﾄ(非表示)
    Private Const CMlngvsfWColRtclListMenteEditTimeWk       As Integer = 0                         '最終更新日時(非表示)
    Private Const CMlngvsfWColRtclListMenteStockerInFlag    As Integer = 0                         'ｽﾄｯｶｰ内ﾌﾗｸﾞ(非表示)
    Private Const CMlngvsfWColRtclListMentePotitionID       As Integer = 0                         '現在位置ID(非表示)

    '@vsfRtclListMente(ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab)の定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfRtclListMenteNo                   As String = "№"                    '№
    Private Const CMstrvsfRtclListMenteStatus               As String = "状態"                  '状態
    Private Const CMstrvsfRtclListMenteRtclID               As String = "ﾚﾁｸﾙID"            'ﾚﾁｸﾙID
    Private Const CMstrvsfRtclListMenteSMIF                 As String = "SMIF"                  'SMIFID
    Private Const CMstrvsfRtclListMenteCurrentPotition      As String = "現在位置"              '現在位置
    Private Const CMstrvsfRtclListMenteArriveTime           As String = "入荷日"                '入荷日
    Private Const CMstrvsfRtclListMenteEditTime             As String = "最終更新日時"          '最終更新日時

    '@vsfRtclListWpIn(装置内ﾚﾁｸﾙ一覧Tab)の定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfRtclListWpInNo                    As Integer = 0                         '№
    Private Const CMlngvsfRtclListWpInWPID                  As Integer = 1                         '装置
    Private Const CMlngvsfRtclListWpInStatus                As Integer = 2                         '状態
    Private Const CMlngvsfRtclListWpInRtclID                As Integer = 3                         'ﾚﾁｸﾙID
    Private Const CMlngvsfRtclListWpInEditTime              As Integer = 4                         '最終更新日

    '@vsfRtclListWpIn(装置内ﾚﾁｸﾙ一覧Tab)の定数宣言(幅)
    Private Const CMlngvsfWColRtclListWpInNo                As Integer = 47                       '№
    Private Const CMlngvsfWColRtclListWpInWPID              As Integer = 198                      '装置
    Private Const CMlngvsfWColRtclListWpInStatus            As Integer = 54                       '状態
    Private Const CMlngvsfWColRtclListWpInRtclID            As Integer = 293                      'ﾚﾁｸﾙID
    Private Const CMlngvsfWColRtclListWpInEditTime          As Integer = 98                       '最終更新日

    '@vsfRtclListWpIn(装置内ﾚﾁｸﾙ一覧Tab)の定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfRtclListWpInNo                    As String = "№"                    '№
    Private Const CMstrvsfRtclListWpInWPID                  As String = "装置名"                '装置名
    Private Const CMstrvsfRtclListWpInStatus                As String = "状態"                  '状態
    Private Const CMstrvsfRtclListWpInRtclID                As String = "ﾚﾁｸﾙID"            'ﾚﾁｸﾙID
    Private Const CMstrvsfRtclListWpInEditTime              As String = "最終更新日"            '最終更新日

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                          As Single = 15.75                      'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                      As Single = 15.75                      'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols                          As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbValueCol                          As Integer = 1                         'ｸﾞﾘｯﾄﾞ値取得列
    Private Const CMlngCmbGroupCols                         As Integer = 1                         '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMlngCMbSelectMode                        As Integer = 1                         '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMlngCmbRowHeight                         As Integer = 43                       'ﾘｽﾄ行の高さ
    Private Const CMstrCmbAddedComment                      As String = " 項目選択"              '表示 文字列
    Private Const CMstrCmbAddedCommentNone                  As String = "0 項目選択"             '表示 文字列「選択なし」
    Private Const CMlngCmbGridCol0                          As Integer = 0                         '選択列数
    Private Const CMlngCmbValueCol1                         As Integer = 1                         '値取得列=1
    Private Const CMlngCmbGetCol0                           As Integer = 0                         'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=0
    Private Const CMlngCmbGetCol1                           As Integer = 1                         'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=1

    '@ｽﾄｯｶｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbGridColName                       As Integer = 0                         '名称列番(ｽﾄｯｶ名)
    Private Const CMlngCmbValueColID                        As Integer = 1                         '装置ID・ｽﾄｯｶｰの取得列数
    Private Const CMlngCmbValueColName                      As Integer = 0                         '装置ID・ｽﾄｯｶｰの名称取得列数

    '@ｽｸﾛｰﾙ制御
    Private Const CMlngSideScrollOnFlag                 As Integer = 1                             '横ｽｸﾛｰﾙ活性化
    Private Const CMlngSideScrollOffFlag                As Integer = 2                             '横ｽｸﾛｰﾙ非活性化

    '@Tab
    Private Const CMlngRegistTab                            As Integer = 0                         'ﾚﾁｸﾙ登録ﾀﾌﾞIndex
    Private Const CMlngMenteTab                             As Integer = 1                         'ﾚﾁｸﾙﾒﾝﾃﾅﾝｽﾀﾌﾞIndex
    Private Const CMlngWPINTab                              As Integer = 2                         '装置内ﾚﾁｸﾙ一覧ﾀﾌﾞIndex

    '@ﾚﾁｸﾙ状態項目ID
    Private Const CMstrStatus1                              As String = "1"                     '要検査
    Private Const CMstrStatus2                              As String = "2"                     '有効
    Private Const CMstrStatus3                              As String = "3"                     '無効
    Private Const CMstrStatus4                              As String = "4"                     '返却中
    Private Const CMstrStatus5                              As String = "5"                     'ｴﾗｰ

    '@ﾚﾁｸﾙ状態変更ﾎﾞﾀﾝ
    Private Const CMstrChgStat1                             As String = "1"                     '返却ﾎﾞﾀﾝ
    Private Const CMstrChgStat2                             As String = "2"                     '再入荷ﾎﾞﾀﾝ
    Private Const CMstrChgStat3                             As String = "3"                     'ｺﾞﾐ検NGﾎﾞﾀﾝ
    Private Const CMstrChgStat4                             As String = "4"                     'ｺﾞﾐ検OKﾎﾞﾀﾝ

    '@ｺﾞﾐ検
    Private Const CMstrGarbageInspectionOK                  As String = "OK"                     'ｺﾞﾐ検NG
    Private Const CMstrGarbageInspectionNG                  As String = "NG"                     'ｺﾞﾐ検OK

    '@装置内ﾌﾗｸﾞ
    Private Const CMstrInFlag0                              As String = "0"                     '装置内
    Private Const CMstrInFlag1                              As String = "1"                     '装置外

    '@ﾚﾁｸﾙ型番ｽﾗｯｼｭ
    Private Const CMstrlblSrash                             As String = "/"
    '@ﾚﾁｸﾙIDﾊｲﾌﾝ
    Private Const CMstrHyphen                               As String = "-"

    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ
    Private Const CMstrGarbage                              As String = "ゴミ検"
    Private Const CMstrGarbageNg                            As String = "ゴミ検NG"
    Private Const CMstrGarbageOk                            As String = "ゴミ検OK"
    Private Const CMstrErrSet                               As String = "エラー" & vbCrLf & "設定"
    Private Const CMstrErrRelese                            As String = "エラー" & vbCrLf & "解除"

    '@ｷｬﾘｱ位置
    'Private Const CMstrOutStocker                           As String = "OUT"
    Private Const CMstrTransPortStatusID                    As String = "MOVE"
    Private Const CMstrArrow                                As String = "→"

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@全Tabで使用している共通構造体
   Private mtypRtclCodeList                                 As List (Of RtclCodeList)           'ﾚﾁｸﾙ型番(機種ｺｰﾄﾞ・ﾏｽｸﾊﾟﾀｰﾝ)格納変数
    Private mlngRtclCodeListCnt                             As Integer                          'ﾚﾁｸﾙ型番(機種ｺｰﾄﾞ・ﾏｽｸﾊﾟﾀｰﾝ)格納数
    Private mtypRtclList                                    As List (Of RtclList)               'ﾚﾁｸﾙ情報格納変数
    Private mlngRtclListCnt                                 As Integer                          'ﾚﾁｸﾙ情報格納数
    Private mlngSortCol                                     As Integer                          'ｿｰﾄ列格納
    Private mlngSortOrder                                   As Integer                          'ｿｰﾄ方法格納
    Private mstrPdCodeRegist                                As String                           'ﾚﾁｸﾙ登録Tab機種ｺｰﾄﾞ退避用
    Private mstrMaskPatternRegist                           As String                           'ﾚﾁｸﾙ登録Tabﾏｽｸﾊﾟﾀｰﾝ退避用
    Private mstrPdCodeMente                                 As String                           'ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab機種ｺｰﾄﾞ退避用
    Private mstrMaskPatternMente                            As String                           'ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTabﾏｽｸﾊﾟﾀｰﾝ退避用
    Private mstrWplist                                      As String                           '装置内ﾚﾁｸﾙ一覧Tabﾚﾁｸﾙ使用装置退避用
    Private mstrEditTime                                    As String                           '装置内ﾚﾁｸﾙ一覧Tabﾚﾁｸﾙ使用装置退避用
    Private mtypChgSort1                                    As ChgSort                          'ｿｰﾄ保持用(ﾚﾁｸﾙ登録)
    Private mtypChgSort2                                    As ChgSort                          'ｿｰﾄ保持用(ﾚﾁｸﾙﾒﾝﾃﾅﾝｽ)
    Private mtypChgSort3                                    As ChgSort                          'ｿｰﾄ保持用(装置内ﾚﾁｸﾙ一覧)
    Private mlngSideScrollFlag                              As Integer                          '横ｽｸﾛｰﾙの使用ﾌﾗｸﾞ(1:発生/2:不要)
    Private mlngStockerListCnt                              As Integer                          'ｽﾄｯｶﾘｽﾄｶｳﾝﾄ
    Private mstrStockerName                                 As String                           'ｽﾄｯｶ名退避用
    Private mtypStockerList                                 As List (Of StockerList)            'ｽﾄｯｶﾏｽﾀ格納
    Private buttonProcessing                                As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                        As Boolean                          'NSYS システムコマンドでの画面クローズ 
    Private mblnWindowClose                                 As Boolean                          'NSYS WindowCloseフラグ
    Private mblnFormLoad1st                                 As Boolean                          'NSYS ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ（Ture:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み）
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
        pubVsfMouseWheelManager_Set(vsfRtclListRegist, cmdUP1, cmdDown1,cmdLeft1,cmdRight1)
        pubVsfMouseWheelManager_Set(vsfRtclListMente, cmdUP2, cmdDown2,cmdLeft2,cmdRight2)
        pubVsfMouseWheelManager_Set(vsfRtclListWpIn, cmdUP3, cmdDown3,cmdLeft3,cmdRight3)

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
    '作成日：2004/08/24 (Tue) 10:14:35 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 15:11:06 Y.Yamagishi
    '備　考：2004/10/14 (Thu) 15:11:06 Y.Yamagishi 列幅,ｿｰﾄ順,ｶﾚﾝﾄ行の保持修正
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngWpCnt           As Integer              '装置数格納

        Try
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00Z0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                
                '@ﾌｫｰﾑを閉じる
                Call Form_QueryUnload(Me, New FormClosingEventArgs(CloseReason.UserClosing, False))
                
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            
            With mtypChgSort1
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
            
            With mtypChgSort2
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
            
            With mtypChgSort3
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

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@画面情報の初期化
            Call prvfrmxxEN00Z0_Init()
            
            '@ﾚﾁｸﾙ登録Tabにﾌｫｰｶｽｾｯﾄ
            tabReticle.SelectedTab = Tab0
            
            '@ﾚﾁｸﾙ型番(機種ｺｰﾄﾞ・ﾏｽｸﾊﾟﾀｰﾝ)取得
            lblnAns = pubblnMasRtclCodeList_Sel(CMstrmas_rtclcodelistVer, mtypRtclCodeList, mlngRtclCodeListCnt)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If
            
            '@機種ｺｰﾄﾞ情報表示
            Call prvcmbPdCode_Disp()
            
            '@装置一覧取得結果
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, llngWpCnt, pstrSBID, CPstrCD2J)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If
            
            '@ﾚﾁｸﾙ使用装置情報表示
            Call prvcmbWplist_Disp(llngWpCnt)
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            'NSYS フォームロード初回のみ
            mblnFormLoad1st = True

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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 17:16:22 Y.Yamagishi
    '更新日：2007/07/05 (Thu) 14:47:21 N.Kasai
    '備　考：2004/10/27 (Wed) 14:19:26 N.Kasai      ｽｸﾛｰﾙ制御追加
    '　　　：2007/07/05 (Thu) 14:47:21 N.Kasai      ｸﾞﾘｯﾄﾞ共通
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
                        
            '@ｽｸﾛｰﾙ制御
            Select Case ActiveControl.Name
                Case vsfRtclListRegist.Name
                '@ﾚﾁｸﾙ登録ﾀﾌﾞ(上下ｽｸﾛｰﾙのみ)
                    '@ｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfRtclListRegist, cmdUP1, cmdDown1)
                    '@ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ)
                    Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfRtclListRegist, cmdLeft1, cmdRight1)

                Case vsfRtclListMente.Name
                '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽﾀﾌﾞ
                    '@ｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfRtclListMente, cmdUP2, cmdDown2)
                    '@ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ)
                    Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfRtclListMente, cmdLeft2, cmdRight2)
                
                Case vsfRtclListWpIn.Name
                '@装置内ﾚﾁｸﾙ一覧
                    '@ｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfRtclListWpIn, cmdUP3, cmdDown3)
                    '@ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ)
                    Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfRtclListWpIn, cmdLeft3, cmdRight3)

            End Select
            
            Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙによる処理分岐
                    Select Case ActiveControl.Name
                    
                        '@ﾚﾁｸﾙ登録-機種
                        Case cmbPdCodeRegist.Name
                            '@ﾚﾁｸﾙ登録-機種Validate処理へ
                            RemoveHandler cmbPdCodeRegist.Validating, AddressOf cmbPdCodeRegist_Validate
                            Call cmbPdCodeRegist_Validate(cmbPdCodeRegist,New CancelEventArgs(True))
                            AddHandler cmbPdCodeRegist.Validating, AddressOf cmbPdCodeRegist_Validate
                            e.Handled = True
                        '@ﾚﾁｸﾙ登録-ﾏｽｸﾊﾟﾀｰﾝ
                        Case cmbMaskPatternRegist.Name
                            '@ﾚﾁｸﾙ登録-ﾏｽｸﾊﾟﾀｰﾝValidate処理へ
                            RemoveHandler cmbMaskPatternRegist.Validating, AddressOf cmbMaskPatternRegist_Validate
                            Call cmbMaskPatternRegist_Validate(cmbMaskPatternRegist,New CancelEventArgs(True))
                            AddHandler cmbMaskPatternRegist.Validating, AddressOf cmbMaskPatternRegist_Validate
                            e.Handled = True
                            
                        '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽ-機種
                        Case cmbPdCodeMente.Name
                            '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽ-機種Validate処理へ
                            RemoveHandler cmbPdCodeMente.Validating, AddressOf cmbPdCodeMente_Validate 
                            Call cmbPdCodeMente_Validate(cmbPdCodeMente,New CancelEventArgs(True))
                            AddHandler cmbPdCodeMente.Validating, AddressOf cmbPdCodeMente_Validate 
                            e.Handled = True
                        '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽ-ﾏｽｸﾊﾟﾀｰﾝ
                        Case cmbMaskPatternMente.Name
                            '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽ-ﾏｽｸﾊﾟﾀｰﾝValidate処理へ
                            RemoveHandler cmbMaskPatternMente.Validating, AddressOf  cmbMaskPatternMente_Validate
                            Call cmbMaskPatternMente_Validate(cmbMaskPatternMente,New CancelEventArgs(True))
                            AddHandler cmbMaskPatternMente.Validating, AddressOf  cmbMaskPatternMente_Validate
                            e.Handled = True
                            
                        '@装置内ﾚﾁｸﾙ一覧-ﾚﾁｸﾙ使用装置
                        Case cmbWplist.Name
                            '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽ-ﾏｽｸﾊﾟﾀｰﾝValidate処理へ
                            RemoveHandler cmbWplist.Validating, AddressOf cmbWplist_Validate 
                            Call cmbWplist_Validate(cmbWplist,New CancelEventArgs(True))
                            AddHandler cmbWplist.Validating, AddressOf cmbWplist_Validate 
                            e.Handled = True
                            
                        Case Else
                            '@次項目へｾｯﾄﾌｫｰｶｽ
                            SendKeys.SendWait(CPstrSendKeysTab)
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

    '関数名：Form_QueryUnload
    '機　能：終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/08/24 (Tue) 10:52:51 Y.Yamagishi
    '更新日：2004/08/24 (Tue) 10:52:51
    '備　考：
    '　　　：2004/11/01 (Mon) 16:00:35 S.Deguchi 閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm         As Boolean      '開放結果格納
        Dim ltypHoldConnect     As HoldConnect  '引継ぎ用構造体

        Try
                        
           '@構造体の初期化
            If IsNothing(mtypRtclCodeList) Then             
                mtypRtclCodeList = New List(Of RtclCodeList)
            Else
                mtypRtclCodeList.Clear()
            End If
            If IsNothing(mtypRtclList) Then             
                mtypRtclList = New List(Of RtclList)
            Else
                mtypRtclList.Clear()
            End If
            If IsNothing(mtypChgSort1.typChgSortList) Then             
                mtypChgSort1.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort1.typChgSortList.Clear()
            End If
            If IsNothing(mtypChgSort2.typChgSortList) Then             
                mtypChgSort2.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort2.typChgSortList.Clear()
            End If
            If IsNothing(mtypChgSort3.typChgSortList) Then             
                mtypChgSort3.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort3.typChgSortList.Clear()
            End If

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose,New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

            '@引継ぎ用構造体の初期化
            ptypHoldConnect = ltypHoldConnect
            
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

    '関数名：cmdClose_Click
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 17:22:54 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 17:22:54
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim llngRet As Integer
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
            llngRet = publngEnd_Proc(CPstrKeyEN00Z0, ltypCommonInfo)
            
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

    '関数名：tabReticle_Click
    '機　能：ﾀﾌﾞｸﾘｯｸ時処理
    '引　数：PreviousTab：使用しない
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 17:42:03 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 17:42:03
    '備　考：
    Private Sub tabReticle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tabReticle.SelectedIndexChanged

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
           Select Case tabReticle.SelectedTab.Name
                Case Tab0.Name
                '@ﾚﾁｸﾙ登録在庫
                    '@ﾚﾁｸﾙ登録Tab活性化
                    fraRegist.Enabled = True
                    
                    '@一覧が使用可能な場合
                    If vsfRtclListRegist.Enabled = True Then
                        '@一覧にｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(vsfRtclListRegist)
                    Else
                        '@機種ｺｰﾄﾞにｾｯﾄﾌｫｰｶｽ
                        cmbPdCodeRegist.Enabled = True
                        Call pubSetFocus(cmbPdCodeRegist)
                    End If
                    
                    '@他の項目を使えなくする(非活性化)
                    fraMente.Enabled = False
                    fraWpIn.Enabled = False
                    
                Case Tab1.Name
                '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽ
                    '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab活性化
                    fraMente.Enabled = True
                    
                    '@一覧が使用可能な場合
                    If vsfRtclListMente.Enabled = True Then
                        '@一覧にｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(vsfRtclListMente)
                    Else
                        '@機種ｺｰﾄﾞにｾｯﾄﾌｫｰｶｽ
                        cmbPdCodeMente.Enabled = True
                        Call pubSetFocus(cmbPdCodeMente)
                    End If
                    
                    '@他の項目を使えなくする(非活性化)
                    fraRegist.Enabled = False
                    fraWpIn.Enabled = False
                    
                Case Tab2.Name
                '@装置内ﾚﾁｸﾙ一覧
                    '@装置内ﾚﾁｸﾙTab活性化
                    fraWpIn.Enabled = True
                    
                    '@一覧が使用可能な場合
                    If vsfRtclListWpIn.Enabled = True Then
                        '@一覧にｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(vsfRtclListWpIn)
                    Else
                        '@ﾚﾁｸﾙ使用装置にｾｯﾄﾌｫｰｶｽ
                        cmbWplist.Enabled = True
                        Call pubSetFocus(cmbWplist)
                    End If
                    
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "tabReticle_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@ﾚﾁｸﾙ登録Tab処理############################################################
    '関数名：cmbPdCodeRegist_change
    '機　能：ﾚﾁｸﾙ登録Tab機種ｺｰﾄﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 10:37:53 Y.Yamagishi
    '更新日：2004/09/28 (Tue) 09:46:33 Y.Yamagishi
    '備　考：2004/09/22 (Wed) 20:23:05 Y.Yamagishi ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ有効無効ﾁｪｯｸを削除(不具合改善№848)
    '　　　：2004/09/28 (Tue) 09:46:33 Y.Yamagishi ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ有効無効ﾁｪｯｸを追加(不具合改善№848)
    Private Sub cmbPdCodeRegist_change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPdCodeRegist.change

        Try
                       
            '@情報取得日時初期化
            lblNowDateRegist.Text = vbNullString
            
            '@該当件数ﾗﾍﾞﾙの初期化
            lblLotCntRegist.Text = vbNullString
            
            '@ﾏｽｸﾊﾟﾀｰﾝの初期化
            cmbMaskPatternRegist.Clear
            
            '@ﾚﾁｸﾙ登録Tab新規登録ﾚﾁｸﾙID情報初期化
            Call prvNewReticleInf_Init()
            
            '@ﾚﾁｸﾙ登録Tab-ﾚﾁｸﾙID一覧の初期化
            Call prvvsfRtclListRegist_Init()

            '@ﾚﾁｸﾙ登録ﾎﾞﾀﾝ有効無効ﾁｪｯｸ
            Call prvRegist_Chk()
            
            '@ﾚﾁｸﾙ登録Tab機種ｺｰﾄﾞ退避用変数をｸﾘｱ
            mstrPdCodeRegist = vbNullString
            
            '@機種ｺｰﾄﾞとﾏｽｸﾊﾟﾀｰﾝが設定されている場合
            If cmbPdCodeRegist.Text <> vbNullString And cmbMaskPatternRegist.Text <> vbNullString Then
                '@ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ有効
                cmdRtclIDCopy.Enabled = True
            Else
                '@ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ無効
                cmdRtclIDCopy.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPdCodeRegist_change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPdCodeRegist
    '機　能：ﾚﾁｸﾙ登録Tab機種ｺｰﾄﾞCloseUp
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 10:38:17 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 10:38:17
    '備　考：
    Private Sub cmbPdCodeRegist_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPdCodeRegist.CloseUp

        Try
                        
            '@cmbPdCodeRegistのValidateｲﾍﾞﾝﾄ呼び出す
            If cmbPdCodeRegist.Text <> vbNullString Then
                RemoveHandler cmbPdCodeRegist.Validating,AddressOf cmbPdCodeRegist_Validate
                Call cmbPdCodeRegist_Validate(cmbPdCodeRegist,New CancelEventArgs(True))
                AddHandler cmbPdCodeRegist.Validating,AddressOf cmbPdCodeRegist_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPdCodeRegist_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPdCodeRegist_Validate
    '機　能：ﾚﾁｸﾙ登録Tab機種ｺｰﾄﾞのValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 10:41:36 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 10:41:36
    '備　考：
    Private Sub cmbPdCodeRegist_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPdCodeRegist.Validating

        Try
           
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            

            If cmbPdCodeRegist.Text = vbNullString Then
            '@機種ｺｰﾄﾞ空欄の場合
               If ActiveControl.Name = cmbPdCodeRegist.Name Then
                    '@閉じるにｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmdClose)
                End If
                
                Exit Sub
            End If
            
            '@前回ﾚﾁｸﾙ登録Tab機種ｺｰﾄﾞと同じ場合処理を抜ける
            If mstrPdCodeRegist = cmbPdCodeRegist.Text Then
                 If ActiveControl.Name = cmbPdCodeRegist.Name Then
                    '@ﾏｽｸﾊﾟﾀｰﾝが有効の場合
                    If cmbMaskPatternRegist.Enabled = True Then
                        '@ﾏｽｸﾊﾟﾀｰﾝにｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmbMaskPatternRegist)
                    End If
                 End If
                Exit Sub
            End If
            
            If cmbPdCodeRegist.Text <> vbNullString Then
                If cmbMaskPatternRegist.Text = vbNullString Then
                '@ﾏｽｸﾊﾟﾀｰﾝ空欄の場合
                    '@ﾏｽｸﾊﾟﾀｰﾝCombo作成
                    Call prvcmbMaskPattern_Disp(cmbMaskPatternRegist, cmbPdCodeRegist)
                    
                    '@ﾚﾁｸﾙ登録Tab機種ｺｰﾄﾞを退避
                    mstrPdCodeRegist = cmbPdCodeRegist.Text
                End If
                '@ﾏｽｸﾊﾟﾀｰﾝが空白の場合(ﾏｽｸﾊﾟﾀｰﾝｺﾝﾎﾞﾎﾞｯｸｽにﾃﾞｰﾀが1件以上あった場合)
                If cmbMaskPatternRegist.Text = vbNullString Then

                Else
                    '@ﾏｽｸﾊﾟﾀｰﾝValidate処理
                    RemoveHandler cmbMaskPatternRegist.Validating,AddressOf cmbMaskPatternRegist_Validate
                    Call cmbMaskPatternRegist_Validate(cmbMaskPatternRegist,New CancelEventArgs(False))
                    AddHandler cmbMaskPatternRegist.Validating,AddressOf cmbMaskPatternRegist_Validate
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPdCodeRegist_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMaskPatternRegist_Change
    '機　能：ﾚﾁｸﾙ登録Tabﾏｽｸﾊﾟﾀｰﾝ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 11:17:18 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 15:10:28 Y.Yamagishi
    '備　考：2004/09/22 (Wed) 20:23:56 Y.Yamagishi ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ有効無効ﾁｪｯｸを削除(不具合改善№848)
    '　　　：2004/09/28 (Tue) 09:47:20 Y.Yamagishi ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ有効無効ﾁｪｯｸを追加(不具合改善№848)
    '　　　：2004/10/14 (Thu) 15:10:28 Y.Yamagishi 列幅、ｿｰﾄ順、ｶﾚﾝﾄ行の保持修正
    Private Sub cmbMaskPatternRegist_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMaskPatternRegist.Change
        
        Try
                      
            '@初期化
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort1.strKey = vbNullString
            
            '@ﾚﾁｸﾙ登録Tab新規登録ﾚﾁｸﾙID情報初期化
            Call prvNewReticleInf_Init()

            '@ﾚﾁｸﾙ登録ﾎﾞﾀﾝ有効無効ﾁｪｯｸ
            Call prvRegist_Chk()

            '@ﾚﾁｸﾙ登録Tabﾏｽｸﾊﾟﾀｰﾝ退避用変数初期化
            mstrMaskPatternRegist = vbNullString
            
            '@ﾎﾞﾀﾝ制御
            If cmbPdCodeRegist.Text = vbNullString Or cmbMaskPatternRegist.Text = vbNullString Then
            '@未選択項目あり
                cmdNowListRegist.Enabled = False      '最新取得ﾎﾞﾀﾝ非活性

                '@ﾚﾁｸﾙ登録Tab-ﾚﾁｸﾙID一覧の初期化
                Call prvvsfRtclListRegist_Init()

                Exit Sub
            Else
            '@未選択項目なし
                cmdNowListRegist.Enabled = True       '最新取得ﾎﾞﾀﾝ活性
            End If
            
            '@機種ｺｰﾄﾞとﾏｽｸﾊﾟﾀｰﾝが設定されている場合
            If cmbPdCodeRegist.Text <> vbNullString And cmbMaskPatternRegist.Text <> vbNullString Then
                '@ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ有効
                cmdRtclIDCopy.Enabled = True
            Else
                '@ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ無効
                cmdRtclIDCopy.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMaskPatternRegist_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMaskPatternRegist_CloseUp
    '機　能：ﾚﾁｸﾙ登録TabﾏｽｸﾊﾟﾀｰﾝCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 11:17:45 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 11:17:45
    '備　考：
    Private Sub cmbMaskPatternRegist_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMaskPatternRegist.CloseUp

        Try
            
            '@ﾏｽｸﾊﾟﾀｰﾝ選択がされていない場合
            If cmbMaskPatternRegist.Text = vbNullString Then
                
                Exit Sub
            End If
                
            '@前回ﾚﾁｸﾙ登録Tabﾏｽｸﾊﾟﾀｰﾝと同じ場合処理を抜ける
            If mstrMaskPatternRegist = cmbMaskPatternRegist.Text Then
                '@ｸﾞﾘｯﾄﾞにﾃﾞｰﾀがある場合
                If vsfRtclListRegist.Rows.Count > 1 Then
                    '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽをｾｯﾄ
                    Call pubSetFocus(vsfRtclListRegist)
                End If
                
                Exit Sub
            End If
            
           RemoveHandler cmbMaskPatternRegist.Validating,AddressOf cmbMaskPatternRegist_Validate
            '@最新情報取得処理へ
            Call cmdNowListRegist_Click(cmdNowListRegist,New EventArgs)
           AddHandler cmbMaskPatternRegist.Validating,AddressOf cmbMaskPatternRegist_Validate


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMaskPatternRegist_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMaskPatternRegist_Validate
    '機　能：ﾚﾁｸﾙ登録TabﾏｽｸﾊﾟﾀｰﾝValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 11:17:58 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 11:17:58
    '備　考：
    Private Sub cmbMaskPatternRegist_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMaskPatternRegist.Validating

        Try
           
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            

           '@ﾏｽｸﾊﾟﾀｰﾝ選択がされていない場合
            If cmbMaskPatternRegist.Text = vbNullString Then
                If ActiveControl.Name = cmbMaskPatternRegist.Name Then
                    '@最新取得ﾎﾞﾀﾝが活性化の場合
                    If cmdNowListRegist.Enabled = True Then
                        '@最新取得へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdNowListRegist)
                    Else
                        '@次ﾌｫｰｶｽに移る
                        Call pubSetFocus(txtNewRtclID)
                    End If
                End If
                Exit Sub
            End If
                
            '@前回ﾚﾁｸﾙ登録Tabﾏｽｸﾊﾟﾀｰﾝと同じ場合処理を抜ける
            If mstrMaskPatternRegist = cmbMaskPatternRegist.Text Then
                If ActiveControl.Name = cmbMaskPatternRegist.Name Then
                    '@ｸﾞﾘｯﾄﾞにﾃﾞｰﾀがある場合
                    If vsfRtclListRegist.Rows.Count > 1 Then
                        '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽをｾｯﾄ
                        Call pubSetFocus(vsfRtclListRegist)
                    Else
                        '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽをｾｯﾄ
                        Call pubSetFocus(cmdNowListRegist)
                    End If
                End If
                Exit Sub
            End If
            
            '@最新情報取得処理へ
            Call cmdNowListRegist_Click(cmdNowListRegist,New EventArgs)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMaskPatternRegist_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtNewRtclID_Change
    '機　能：ﾚﾁｸﾙ登録Tab新規登録ﾚﾁｸﾙIDChange
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 15:11:03 Y.Yamagishi
    '更新日：2004/09/22 (Wed) 20:24:58 Y.Yamagishi
    '備　考：2004/09/22 (Wed) 20:24:58 Y.Yamagishi ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ有効無効ﾁｪｯｸを削除(不具合改善№848)
    Private Sub txtNewRtclID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtNewRtclID.Change

        Try
            
            '@ﾚﾁｸﾙ登録ﾎﾞﾀﾝ有効無効ﾁｪｯｸ
            Call prvRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtNewRtclID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtNewRtclID_Validate
    '機　能：ﾚﾁｸﾙ登録Tab新規登録ﾚﾁｸﾙIDValidate
    '引　数：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 15:13:48 Y.Yamagishi
    '更新日：2004/09/22 (Wed) 20:14:11 Y.Yamagishi
    '備　考：2004/09/22 (Wed) 20:14:11 Y.Yamagishi  入力したﾚﾁｸﾙ型番が存在しない場合ｴﾗｰﾒｯｾｰｼﾞを表示する(不具合改善№844)
    '　　　　　　　　　　　　　　　　　　　　　　　　  ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ有効無効ﾁｪｯｸを削除(不具合改善№848)
    Private Sub txtNewRtclID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtNewRtclID.Validating

        Dim llngCnt         As Integer          'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lblnFlg         As Boolean          'ﾌﾗｸﾞ

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            
            '@ﾚﾁｸﾙIDが空欄の場合は処理を抜ける
            If txtNewRtclID.Text = vbNullString Then
                Exit Sub
            End If
            
            If tabReticle.SelectedTab.Name <> Tab0.Name Then
                Exit Sub
            End If

            '@初期化
            lblnFlg = False
            
            '@ﾚﾁｸﾙ型番の存在ﾁｪｯｸ
            If txtNewRtclID.Text <> vbNullString Then
                With vsfRtclListRegist
                    For llngCnt = 0 To mlngRtclCodeListCnt-1
                        '@一致するﾚﾁｸﾙIDが存在するか否かで処理分岐
                        If txtNewRtclID.Text = mtypRtclCodeList(llngCnt).lstrReticleName Then
                            '@True設定
                            lblnFlg = True
                            
                            Exit For
                        End If
                    Next
                End With
            End If
            
            '@結果判定
            If lblnFlg = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                 pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003H)
                 
                '@"ﾚﾁｸﾙ型番が存在しません。設定を見直してください。"
                 Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                 
                 '@ｷｬﾝｾﾙ
                 e.Cancel = True
                 
                 '@確定ﾎﾞﾀﾝ無効
                 cmdRegist.Enabled = False
                 
                 Exit Sub
            End If
            
            '@ﾚﾁｸﾙ登録ﾎﾞﾀﾝ有効無効ﾁｪｯｸ
            Call prvRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtNewRtclID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtNewRtclID2_Change
    '機　能：ﾚﾁｸﾙ登録Tab新規登録ﾚﾁｸﾙID(番号)Change
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 15:11:03 Y.Yamagishi
    '更新日：2004/09/22 (Wed) 20:25:47 Y.Yamagishi
    '備　考：2004/09/22 (Wed) 20:25:47 Y.Yamagishi ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ有効無効ﾁｪｯｸを削除(不具合改善№848)
    Private Sub txtNewRtclID2_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtNewRtclID2.Change

        Try
           
            '@ﾚﾁｸﾙ登録ﾎﾞﾀﾝ有効無効ﾁｪｯｸ
            Call prvRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtNewRtclID2_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtNewRtclID2_Validate
    '機　能：ﾚﾁｸﾙ登録Tab新規登録ﾚﾁｸﾙID(番号)Validate
    '引　数：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 15:13:48 Y.Yamagishi
    '更新日：2004/09/22 (Wed) 20:26:01 Y.Yamagishi
    '備　考：2004/09/22 (Wed) 20:26:01 Y.Yamagishi ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ有効無効ﾁｪｯｸを削除(不具合改善№848)
    Private Sub txtNewRtclID2_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtNewRtclID2.Validating

        Try
           
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            
            '@ﾚﾁｸﾙ登録ﾎﾞﾀﾝ有効無効ﾁｪｯｸ
            Call prvRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtNewRtclID2_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpArriveTime_CalendarSelect
    '機　能：ﾚﾁｸﾙ登録Tab入荷日選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 16:18:24 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 16:18:24
    '備　考：
    Private Sub dtpArriveTime_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles dtpArriveTime.CalendarSelect
        
        Try
            
            '@日付の場合
            If IsDate(dtpArriveTime.Value) = True Then
                '@次項目にﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "dtpArriveTime_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpArriveTime_Change
    '機　能：ﾚﾁｸﾙ登録Tab入荷日変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/30 (Mon) 18:51:45 Y.Yamagishi
    '更新日：2004/08/30 (Mon) 18:51:45
    '備　考：
    Private Sub dtpArriveTime_Change(ByVal sender As Object, ByVal e As EventArgs) Handles dtpArriveTime.Change
        
        Try
            
            '@ﾚﾁｸﾙ登録ﾎﾞﾀﾝ有効無効ﾁｪｯｸ
            Call prvRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "dtpArriveTime_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpArriveTime_Validate
    '機　能：ﾚﾁｸﾙ登録Tab入荷日Validate時入力ﾁｪｯｸ
    '引　数：Cancel：
    '戻り値：
    '作成日：2004/08/25 (Wed) 16:20:55 Y.Yamagishi
    '更新日：2004/09/22 (Wed) 20:26:17 Y.Yamagishi
    '備　考：2004/09/22 (Wed) 20:26:17 Y.Yamagishi ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ有効無効ﾁｪｯｸを削除(不具合改善№848)
    Private Sub dtpArriveTime_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles dtpArriveTime.Validating

        Try
           
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            If tabReticle.SelectedTab.Name <> Tab0.Name Then
                Exit Sub
            End If

            '@ﾚﾁｸﾙ登録ﾎﾞﾀﾝ有効無効ﾁｪｯｸ
            Call prvRegist_Chk()
            
            '@入荷日ﾁｪｯｸ
            If dtpArriveTime.Value = CPstrNullDate Then

                Call pubSetFocus(dtpArriveTime)

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001W)
                
                '@"入荷日の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@入荷日にｾｯﾄﾌｫｰｶｽ
                e.Cancel = True
                
                '@登録ﾎﾞﾀﾝ無効
                cmdRegist.Enabled = False
                
                Exit Sub
            Else
                '@日付ﾁｪｯｸ
                If IsDate(dtpArriveTime.Value) = False Then

                    Call pubSetFocus(dtpArriveTime)

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001W)
                    
                    '@"入荷日の設定が正しくありません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@入荷日にｾｯﾄﾌｫｰｶｽ
                    e.Cancel = True
                    
                    '@登録ﾎﾞﾀﾝ無効
                    cmdRegist.Enabled = False
                    
                    Exit Sub
                End If
                
                '@未来の日付ﾁｪｯｸ
                If dtpArriveTime.Value > Format$(Now, CPstrDateTimeYMD) Then

                    Call pubSetFocus(dtpArriveTime)

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                    
                    '@"未来の日付は指定できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@入荷日にｾｯﾄﾌｫｰｶｽ
                    e.Cancel = True
                    
                    '@登録ﾎﾞﾀﾝ無効
                    cmdRegist.Enabled = False
                    
                    Exit Sub
                End If
                
                '@ﾚﾁｸﾙ登録ﾎﾞﾀﾝが有効の場合
                If cmdRegist.Enabled = True Then
                    If ActiveControl.Name = dtpArriveTime.Name Then
                        '@次項目にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdRegist)
                    End If
                End If
            End If

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "dtpArriveTime_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：ﾚﾁｸﾙ登録TabﾚﾁｸﾙID新規登録処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 14:24:43 Y.Yamagishi
    '更新日：2004/09/22 (Wed) 19:10:40 Y.Yamagishi
    '備　考：2004/09/22 (Wed) 19:10:40 Y.Yamagishi ｴﾗｰ後のﾌｫｰｶｽ位置変更(不具合改善№817)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAnsAdd              As Boolean          'ﾚﾁｸﾙ登録結果
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim lstrEventName           As String           'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        Dim ltypRtclRegist          As RtclRegist       'ﾚﾁｸﾙ登録情報格納要構造体
        Dim lblnRegistCheck         As Boolean          '画面入力ﾁｪｯｸ

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@画面入力ﾁｪｯｸ
            lblnRegistCheck = prvblnRegist_Chk
            '@結果判定
            If lblnRegistCheck = False Then
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
            lstrEventName = "cmdRegist_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            With ltypRtclRegist
                '@ｼｽﾃﾑﾌﾞﾛｯｸｾｯﾄ
                .strSbID = pstrSBID
                '@Msgﾊﾞｰｼﾞｮﾝｾｯﾄ
                .strMsgVer = CMstrrtclregist__Ver
                '@ﾚﾁｸﾙIDｾｯﾄ
                .strReticleID = txtNewRtclID.Text & CMstrHyphen & txtNewRtclID2.Text
                '@入荷日ｾｯﾄ
                .strArriveTime = dtpArriveTime.Value
                '@作業者ID
                .strEmpID = pstrUserID
                '@ﾚﾁｸﾙ型番ｾｯﾄ
                .strReticleName = txtNewRtclID.Text
            End With
            
            '@ﾚﾁｸﾙ新規登録実行
            lblnAnsAdd = pubblnReticleID_Ins(ltypRtclRegist)
            '@結果判定
            If lblnAnsAdd = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001J, ltypRtclRegist.strReticleID)
                
                '@pubVsfInfo_Disp("<TRM1IJ>$$ﾚﾁｸﾙ[ %1 ]を登録しました。")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ﾚﾁｸﾙ登録Tab新規登録ﾚﾁｸﾙID情報初期化
                Call prvNewReticleInf_Init()
                
                '@ﾚﾁｸﾙ登録Tab最新情報取得処理へ
                Call cmdNowListRegist_Click(cmdNowListRegist,New EventArgs)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            
                Exit Sub
            Else
                '@ﾚﾁｸﾙID番号にｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(txtNewRtclID2)
            End If
            
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(lstrFormName, lstrEventName)
            
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

    '関数名：cmdNowListRegist_Click
    '機　能：ﾚﾁｸﾙ登録Tabﾏｽｸﾊﾟﾀｰﾝ最新取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 11:21:24 Y.Yamagishi
    '更新日：2004/10/18 (Mon) 16:22:54 Y.Yamagishi
    '備　考：2004/09/22 (Wed) 20:24:28 Y.Yamagishi ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ有効無効ﾁｪｯｸを削除(不具合改善№848)
    '　　　：2004/10/18 (Mon) 16:22:54 Y.Yamagishi 0件表示のﾒｯｾｰｼﾞﾎﾞｯｸｽを表示しない(ｺﾒﾝﾄｱｳﾄ)不具合改善№1093
    Private Sub cmdNowListRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowListRegist.Click

        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypRtclList2           As RtclList2            'ﾚﾁｸﾙ情報格納変数

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@機種ｺｰﾄﾞ空欄の場合
            If cmbPdCodeRegist.Text = vbNullString Then
                '@機種ｺｰﾄﾞにｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmbPdCodeRegist)
                
                '@処理を抜ける
                Exit Sub
            End If

            '@ﾏｽｸﾊﾟﾀｰﾝ空欄 or 0項目の場合
            If cmbMaskPatternRegist.Text = vbNullString Then
                '@ﾏｽｸﾊﾟﾀｰﾝにｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmbMaskPatternRegist)
                
                '@処理を抜ける
                Exit Sub
            End If

            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
            lstrFormName = Me.Name
            lstrEventName = "cmdNowListRegist_Click"

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ﾚﾁｸﾙ登録Tab-ﾚﾁｸﾙID一覧の初期化
            'Call prvvsfRtclListRegist_Init()
            
            '@ﾚﾁｸﾙ情報格納変数に値をｾｯﾄ
            With ltypRtclList2
                '@ｼｽﾃﾑﾌﾞﾛｯｸｾｯﾄ
                .strSbID = pstrSBID
                '@Msgﾊﾞｰｼﾞｮﾝｾｯﾄ
                .strMsgVer = CMstrrtcllist____Ver
                '@処理区分ｾｯﾄ
                .strClassDivison = CPstrCD04 & CPstrCD2K
                '@機種ｺｰﾄﾞｾｯﾄ
                .strReticlePdCode = cmbPdCodeRegist.Text
                '@ﾏｽｸﾊﾟﾀｰﾝｾｯﾄ
                .strReticleMaskPattern = cmbMaskPatternRegist.Text
                '@ﾚﾁｸﾙ型番ｾｯﾄ
                .strReticleName = CMstrlblSrash & cmbPdCodeRegist.Text & CMstrlblSrash & cmbMaskPatternRegist.Text
                '@装置ID
                .lngWpListCnt = 0
            End With
            
            '@ﾚﾁｸﾙ情報取得
            lblnAns = pubblnRtclList____Sel(ltypRtclList2, mtypRtclList, mlngRtclListCnt)
            '@結果判定
            If lblnAns = True Then
                '@一覧表示
                Call vsfRtclListRegist_Disp()

                '@最新取得ﾎﾞﾀﾝ活性化
                cmdNowListRegist.Enabled = True

                If vsfRtclListRegist.Enabled = True Then
                    '@一覧へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(vsfRtclListRegist)
                Else
                    '@取得件数が1件以上の場合
                    If mlngRtclListCnt > 0 Then
                        '@最新取得ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmdNowListRegist)
                    End If
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                '@ﾚﾁｸﾙ登録Tabﾏｽｸﾊﾟﾀｰﾝ退避
                mstrMaskPatternRegist = cmbMaskPatternRegist.Text
                
                '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
                If lblLotCntRegist.Text = CPstrLotCnt0 Then
                    '@ﾚﾁｸﾙ登録Tab-ﾚﾁｸﾙID一覧の初期化
                    Call prvvsfRtclListRegist_Init()
                Else
                    '@ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ有効
                    cmdRtclIDCopy.Enabled = True
                End If
                
                '@ﾚﾁｸﾙ登録ﾎﾞﾀﾝ有効無効ﾁｪｯｸ
                Call prvRegist_Chk()
            　　
                vsfRtclListMente.Redraw = True
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                vsfRtclListMente.Redraw = True
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowListRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListRegist_AfterSort
    '機　能：一覧AfterSort処理
    '引　数：Col：ｿｰﾄ列
    '　　　：Order：ｿｰﾄ方法
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 16:53:13 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 15:15:11 Y.Yamagishi
    '備　考：2004/10/14 (Thu) 15:15:11 Y.Yamagishi 列幅、ｿｰﾄ順、ｶﾚﾝﾄ行の保持修正
    Private Sub vsfRtclListRegist_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfRtclListRegist.AfterSort
Dim ScrollPosition As Point

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfRtclListRegist.Rows.Count <= vsfRtclListRegist.Rows.Fixed Then
                Return
            End If
            
            AddHandler vsfRtclListRegist.BeforeRowColChange,AddressOf vsfRtclListRegist_BeforeRowColChange
            
            '@ｿｰﾄ順を格納
            With mtypChgSort1
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                Do While (.typChgSortList.Count -1 < .lngCnt)
                    .typChgSortList.Add(New ChgSortList)
                Loop
                Dim typChgSortListTmp As ChgSortList = New ChgSortList
                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                
                '@並び替え方法を格納(昇順/降)）
                typChgSortListTmp.lngOrder = e.Order
                .typChgSortList(.lngCnt)  = typChgSortListTmp
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
            End With
                        
            '@ｿｰﾄされた列を格納
            mlngSortCol = e.Col
            '@ｿｰﾄ方法を格納
            mlngSortOrder = e.Order
               
            'NSYS スクロール位置格納
            ScrollPosition = vsfRtclListRegist.ScrollPosition

            '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列）
            Call pubVsfAfterSort(vsfRtclListRegist, CMlngVsfRowTitle,cmdUP1 ,cmdDown1  ,False, False, False, False)

            vsfRtclListRegist.ScrollPosition = New Point(ScrollPosition.X,vsfRtclListRegist.ScrollPosition.Y)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListRegist_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListRegist_AfterUserResize
    '機　能：列幅の変更時処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2004/10/14 (Thu) 15:18:21 Y.Yamagishi
    '更新日：2007/07/09 (Mon) 14:32:22 N.Kasai
    '備　考：
    '　　　：2007/07/09 (Mon) 14:32:22 N.Kasai  ｸﾞﾘｯﾄﾞ共通
    Private Sub vsfRtclListRegist_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfRtclListRegist.AfterResizeColumn, vsfRtclListRegist.AfterResizeRow

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfRtclListRegist.Rows.Count <= vsfRtclListRegist.Rows.Fixed Then
                Return
            End If
            

            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort1.blnChgWidth = True
            
        '@↓2007/07/09 (Mon) 14:32:50 N.Kasai **************************************************
            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
            Call pubCmdLREnable_Set(vsfRtclListRegist, cmdLeft1, cmdRight1)
            
        '    With vsfRtclListRegist
        '        '@全列数の幅取得(非表示項目は含めない)
        '        For llngCnt = 0 To .Cols - 1
        '            '@非表示列ではない場合
        '            If .ColHidden(llngCnt) <> True Then
        '                llngWidthAll = llngWidthAll + .ColWidth(llngCnt)
        '            End If
        '        Next llngCnt
        '
        '        '@ｸﾞﾘｯﾄﾞ幅と比較して横ｽｸﾛｰﾙﾎﾞﾀﾝを活性化するか判断
        '        If .Width - llngWidthAll >= 0 Then
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=2:非活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOffFlag
        '
        '            '@右ｽｸﾛｰﾙ非活性化
        '            cmdRight1.Enabled = False
        '        Else
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=1:活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOnFlag
        '
        '            '@右ｽｸﾛｰﾙ活性化
        '            cmdRight1.Enabled = True
        '        End If
        '    End With
        '@↑2007/07/09 (Mon) 14:32:50 N.Kasai **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListRegist_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListRegist_BeforeRowColChange
    '機　能：変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2004/10/14 (Thu) 15:23:35 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 15:23:35
    '備　考：
    Private Sub vsfRtclListRegist_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfRtclListRegist.BeforeRowColChange

        Try
           
            'NSYS データ行がない場合は処理を抜ける
            If vsfRtclListRegist.Rows.Count <= vsfRtclListRegist.Rows.Fixed Then
                Return
            End If
            

            '@旧行と新行が違っていて、新行がデータ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1> 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ﾚﾁｸﾙID)
                mtypChgSort1.strKey = vsfRtclListRegist.GetData(e.NewRange.r1, CMlngvsfRtclListRegistRtclID)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListRegist_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListRegist_BeforeSort
    '機　能：ﾚﾁｸﾙ登録TabﾚﾁｸﾙID一覧ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 16:52:59 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 16:52:59
    '備　考：
    Private Sub vsfRtclListRegist_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfRtclListRegist.BeforeSort

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfRtclListRegist.Rows.Count <= vsfRtclListRegist.Rows.Fixed Then
                Return
            End If
            
            RemoveHandler vsfRtclListRegist.BeforeRowColChange,AddressOf vsfRtclListRegist_BeforeRowColChange

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfBeforeSort(vsfRtclListRegist, CMlngVsfRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListRegist_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUP1_Click
    '機　能：前ﾍﾟｰｼﾞﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/19 (Tue) 09:29:47 N.Kojima
    '更新日：2004/10/19 (Tue) 09:29:47
    '備　考：
    Private Sub cmdUP1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUP1.Click

        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
           

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdUp(vsfRtclListRegist, cmdUP1, cmdDown1)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUP1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown1_Click
    '機　能：次ﾍﾟｰｼﾞﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/19 (Tue) 09:29:47 N.Kojima
    '更新日：2004/10/19 (Tue) 09:29:47
    '備　考：
    Private Sub cmdDown1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown1.Click

        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdDown(vsfRtclListRegist, cmdUP1, cmdDown1, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLeft1_Click
    '機　能：左ｽｸﾛｰﾙﾎﾞﾀﾝ押下(ﾚﾁｸﾙ登録)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/27 (Wed) 15:22:41 N.Kasai
    '更新日：2007/07/05 (Thu) 14:40:47 N.Kasai
    '備　考：
    '　　　：2007/07/05 (Thu) 14:40:47 N.Kasai  ｸﾞﾘｯﾄﾞ共通化
    Private Sub cmdLeft1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft1.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@左ｽｸﾛｰﾙﾎﾞﾀﾝ制御
            Call pubVsfCmdLeft(vsfRtclListRegist, cmdLeft1, cmdRight1)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLeft1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRight1_Click
    '機　能：右ｽｸﾛｰﾙﾎﾞﾀﾝ押下(ﾚﾁｸﾙ登録)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/27 (Wed) 15:23:19 N.Kasai
    '更新日：2007/07/05 (Thu) 14:41:36 N.Kasai
    '備　考：
    '　　　：2007/07/05 (Thu) 14:41:36 N.Kasai  ｸﾞﾘｯﾄﾞ共通化
    Private Sub cmdRight1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight1.Click

        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
           

            '@右ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            Call pubVsfCmdRight(vsfRtclListRegist, cmdLeft1, cmdRight1)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRight1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRtclIDCopy_Click
    '機　能：ﾚﾁｸﾙ登録TabﾚﾁｸﾙIDｺﾋﾟｰ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 13:43:06 Y.Yamagishi
    '更新日：2004/10/06 (Wed) 11:06:41 Y.Yamagishi
    '備　考：2004/09/22 (Wed) 20:20:11 Y.Yamagishi 番号部分はｺﾋﾟｰしないように変更(不具合改善№848)
    '　　　：2004/10/06 (Wed) 11:06:41 Y.Yamagishi 番号にﾌｫｰｶｽを移動する(不具合改善№1051)
    Private Sub cmdRtclIDCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRtclIDCopy.Click

        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@機種ｺｰﾄﾞとﾏｽｸﾊﾟﾀｰﾝがNULL以外の場合ｺﾋﾟｰ
            If cmbPdCodeRegist.Text <> vbNullString And cmbMaskPatternRegist.Text <> vbNullString Then
                '@新規登録ﾚﾁｸﾙIDに値をｺﾋﾟｰ
                txtNewRtclID.Text = CMstrlblSrash & cmbPdCodeRegist.Text & CMstrlblSrash & cmbMaskPatternRegist.Text
            End If
            
            '@ﾚﾁｸﾙID番号が有効の場合
            If txtNewRtclID2.Enabled = True Then
                '@ﾚﾁｸﾙID番号部分にｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(txtNewRtclID2)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRtclIDCopy_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab処理############################################################
    '関数名：cmbPdCodeMente
    '機　能：ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab機種ｺｰﾄﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 10:37:53 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 10:37:53
    '備　考：
    Private Sub cmbPdCodeMente_change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPdCodeMente.change

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@情報取得日時初期化
            lblNowDateMente.Text = vbNullString
            
            '@該当件数ﾗﾍﾞﾙの初期化
            lblLotCntMente.Text = vbNullString
            
            '@ﾏｽｸﾊﾟﾀｰﾝの初期化
            cmbMaskPatternMente.Clear
           
            '@ﾚﾁｸﾙ登録Tab-ﾚﾁｸﾙID一覧の初期化
            Call prvvsfRtclListMente_Init()
            
            '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab機種ｺｰﾄﾞ退避用変数の初期化
            mstrPdCodeMente = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPdCodeMente_change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPdCodeMente
    '機　能：ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab機種ｺｰﾄﾞCloseUp
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 10:38:17 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 10:38:17
    '備　考：
    Private Sub cmbPdCodeMente_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPdCodeMente.CloseUp

        Try
                       
            '@cmbPdCodeMenteのValidateｲﾍﾞﾝﾄ呼び出す
            If cmbPdCodeMente.Text <> vbNullString Then
                RemoveHandler cmbPdCodeMente.Validating, AddressOf cmbPdCodeMente_Validate 
                Call cmbPdCodeMente_Validate(cmbPdCodeMente,new CancelEventArgs(True))
                AddHandler cmbPdCodeMente.Validating, AddressOf cmbPdCodeMente_Validate 
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPdCodeMente_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPdCodeMente_Validate
    '機　能：ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab機種ｺｰﾄﾞのValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 10:41:36 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 10:41:36
    '備　考：
    Private Sub cmbPdCodeMente_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPdCodeMente.Validating

        Try
           
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            

            If cmbPdCodeMente.Text = vbNullString Then
            '@機種ｺｰﾄﾞ空欄の場合
                If ActiveControl.Name = cmbPdCodeMente.Name 
                 '@閉じるにｾｯﾄﾌｫｰｶｽ
                 Call pubSetFocus(cmdClose)
                End if
                Exit Sub
            End If
            
            '@前回ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab機種ｺｰﾄﾞと同じ場合処理を抜ける
            If mstrPdCodeMente = cmbPdCodeMente.Text Then
                If ActiveControl.Name = cmbPdCodeMente.Name
                    '@ﾏｽｸﾊﾟﾀｰﾝが有効の場合
                    If cmbMaskPatternMente.Enabled = True Then
                        '@ﾏｽｸﾊﾟﾀｰﾝにｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmbMaskPatternMente)
                    End If
                End If 
                Exit Sub
            End If
            
            If cmbPdCodeMente.Text <> vbNullString Then
                If cmbMaskPatternMente.Text = vbNullString Then
                '@ﾏｽｸﾊﾟﾀｰﾝ空欄の場合
                    '@ﾏｽｸﾊﾟﾀｰﾝCombo作成
                    Call prvcmbMaskPattern_Disp(cmbMaskPatternMente, cmbPdCodeMente)
                    
                    '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab機種ｺｰﾄﾞ退避
                    mstrPdCodeMente = cmbPdCodeMente.Text
                End If
                '@ﾏｽｸﾊﾟﾀｰﾝが空白の場合(ﾏｽｸﾊﾟﾀｰﾝｺﾝﾎﾞﾎﾞｯｸｽにﾃﾞｰﾀが1件以上ある場合)
                If cmbMaskPatternMente.Text = vbNullString Then
                    If ActiveControl.Name = cmbPdCodeMente.Name
                        '@ﾏｽｸﾊﾟﾀｰﾝへｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmbMaskPatternMente)
                    End if
                Else
                    RemoveHandler cmbMaskPatternMente.Validating, AddressOf cmbMaskPatternMente_Validate
                    '@ﾏｽｸﾊﾟﾀｰﾝValidate処理
                    Call cmbMaskPatternMente_Validate(cmbMaskPatternMente,new CancelEventArgs(False))
                    AddHandler cmbMaskPatternMente.Validating, AddressOf cmbMaskPatternMente_Validate
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPdCodeMente_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMaskPatternMente_Change
    '機　能：ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTabﾏｽｸﾊﾟﾀｰﾝ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 11:17:18 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 15:11:47 Y.Yamagishi
    '備　考：2004/10/14 (Thu) 15:11:47 Y.Yamagishi 列幅、ｿｰﾄ順、ｶﾚﾝﾄ行の保持修正
    Private Sub cmbMaskPatternMente_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMaskPatternMente.Change

        Try
            
            '@初期化
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort2.strKey = vbNullString
            
            '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTabﾏｽｸﾊﾟﾀｰﾝ退避用変数初期化
            mstrMaskPatternMente = vbNullString
            
            '@ﾎﾞﾀﾝ制御
            If cmbPdCodeMente.Text = vbNullString Or cmbMaskPatternMente.Text = vbNullString Then
                '@未選択項目あり
                cmdNowListMente.Enabled = False      '最新取得ﾎﾞﾀﾝ非活性
            Else
                '@未選択項目なし
                cmdNowListMente.Enabled = True       '最新取得ﾎﾞﾀﾝ活性
            End If
            
            '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab-ﾚﾁｸﾙID一覧の初期化
            Call prvvsfRtclListMente_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMaskPatternMente_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMaskPatternMente_CloseUp
    '機　能：ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTabﾏｽｸﾊﾟﾀｰﾝCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 11:17:45 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 11:17:45
    '備　考：
    Private Sub cmbMaskPatternMente_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMaskPatternMente.CloseUp

        Try
            
            '@ﾏｽｸﾊﾟﾀｰﾝ選択がされていない場合
            If cmbMaskPatternMente.Text = vbNullString Then
                Exit Sub
            End If
                
            '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTabﾏｽｸﾊﾟﾀｰﾝ退避
            If mstrMaskPatternMente = cmbMaskPatternMente.Text Then
                If vsfRtclListMente.Rows.Count > 1 Then
                    Call pubSetFocus(vsfRtclListMente)
                End If
                Exit Sub
            End If
            
            '@ｽﾄｯｶｰ情報ｾｯﾄ
            Call prvcmbStockerName_Disp()
            
            '@最新情報取得処理へ
            Call cmdNowListMente_Click(sender,New EventArgs())

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMaskPatternMente_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMaskPatternMente_Validate
    '機　能：ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTabﾏｽｸﾊﾟﾀｰﾝValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 11:17:58 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 11:17:58
    '備　考：
    Private Sub cmbMaskPatternMente_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMaskPatternMente.Validating

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            

            '@ﾏｽｸﾊﾟﾀｰﾝ選択がされていない場合
            If cmbMaskPatternMente.Text = vbNullString Then
              If ActiveControl.Name = cmbMaskPatternMente.name
                If cmdNowListMente.Enabled = True Then
                    '@最新取得へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdNowListMente)
                Else
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
              End if  
                Exit Sub
            End If
                
            '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTabﾏｽｸﾊﾟﾀｰﾝ退避
            If mstrMaskPatternMente = cmbMaskPatternMente.Text Then
                If ActiveControl.Name = cmbMaskPatternMente.name
                    '@1件以上か否かで処理分岐
                    If vsfRtclListMente.Rows.Count > 1 Then
                        '@一覧にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfRtclListMente)
                    Else
                        '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdNowListMente)
                    End If
                End if
                Exit Sub
            End If
            
            '@ｽﾄｯｶｰ情報ｾｯﾄ
            Call prvcmbStockerName_Disp()
            
            '@最新情報取得処理へ
            Call cmdNowListMente_Click(sender,New EventArgs())

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMaskPatternMente_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStockerName_Change
    '機　能：ｽﾄｯｶｰ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/30 (Tue) 15:29:03 N.Kasai
    '更新日：2004/11/30 (Tue) 15:29:03
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

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbStockerName_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStockerName_CloseUp
    '機　能：ｽﾄｯｶｰのCloseUp
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/08 (Mon) 11:52:37 N.Kojima
    '更新日：2004/11/08 (Mon) 11:52:37
    '備　考：
    Private Sub cmbStockerName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStockerName.CloseUp

        Try
                       
            '@ｽﾄｯｶｰが空白の場合
            If cmbStockerName.Text <> vbNullString Then
                '@次項目へｾｯﾄﾌｫｰｶｽ
                SendKeys.SendWait(CPstrSendKeysTab)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbStockerName_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdPut_Click
    '機　能：ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab「返却」ﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 14:24:43 Y.Yamagishi
    '更新日：2004/09/22 (Wed) 17:33:24 Y.Yamagishi
    '備　考：
    Private Sub cmdPut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPut.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@「返却」処理実行
            Call prvRtclChgStat_Set(CMstrChgStat1)
            
            '@ﾌｫｰｶｽの設定
            If vsfRtclListMente.Enabled = True Then
                Call pubSetFocus(vsfRtclListMente)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPut_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdArrive_Click
    '機　能：ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab「再入荷」ﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 14:24:43 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 14:24:43
    '備　考：
    Private Sub cmdArrive_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdArrive.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            Call prvRtclChgStat_Set(CMstrChgStat2)
            
            '@ﾌｫｰｶｽの設定
            If vsfRtclListMente.Enabled = True Then
                Call pubSetFocus(vsfRtclListMente)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdArrive_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDel_Click
    '機　能：ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab「ﾚﾁｸﾙ削除」ﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 17:59:24 Y.Yamagishi
    '更新日：2004/10/19 (Tue) 16:59:11 N.Kojima
    '備　考：
    '　　　：2004/10/19 (Tue) 16:59:11 N.Kojima ﾚﾁｸﾙ削除にﾌｫｰｶｽを留める処理追加。(不具合№113)
    Private Sub cmdDel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDel.Click

        Dim lblnAns                 As Boolean          'ﾚﾁｸﾙ登録結果
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim lstrEventName           As String           'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        Dim ltypRtclChgState        As RtclChgState     'ﾚﾁｸﾙ状態変更情報格納要構造体

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
            
            '@ｷｬﾝｾﾙなら処理中止
            If pblnCancel = True Then
                '@ﾌｫｰｶｽの設定
                If vsfRtclListMente.Enabled = True Then
                    Call pubSetFocus(vsfRtclListMente)
                End If
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "cmdDel_Click"
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾚﾁｸﾙ状態変更情報格納要構造体に値をｾｯﾄする
            With ltypRtclChgState
                '@ｼｽﾃﾑﾌﾞﾛｯｸｾｯﾄ
                .strSbID = pstrSBID
                '@Msgﾊﾞｰｼﾞｮﾝｾｯﾄ
                .strMsgVer = CMstrrtclDelete__Ver
                '@ﾚﾁｸﾙIDｾｯﾄ
                .strReticleID = vsfRtclListMente.GetData(vsfRtclListMente.Row, CMlngvsfRtclListMenteRtclID)
                '@作業者ID
                .strEmpID = pstrUserID
                '@最終更新日
                .strEditTime = vsfRtclListMente.GetData(vsfRtclListMente.Row, CMlngvsfRtclListMenteEditTimeWk)
            End With
            
            '@ﾚﾁｸﾙ削除実行
            lblnAns = pubblnReticleDelete_Ins(ltypRtclChgState)
            '@結果判定
            If lblnAns = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001R, ltypRtclChgState.strReticleID)
                
                '@pubVsfInfo_Disp("<TRM1RI>$$ﾚﾁｸﾙ[ %1 ]を削除しました。")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab最新情報取得処理へ
                Call cmdNowListMente_Click(sender,New EventArgs())
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
            
           
            
            '@ﾌｫｰｶｽの設定
            If vsfRtclListMente.Enabled = True Then
                Call pubSetFocus(vsfRtclListMente)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRtclInfChange_Click
    '機　能：ﾚﾁｸﾙ情報変更画面表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 20:28:20 Y.Yamagishi
    '更新日：2012/01/24 (Tue) 13:38:37 T.Oide
    '備　考：
    Private Sub cmdRtclInfChange_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRtclInfChange.Click

        Dim lstrKeyID   As String                   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer                  '現在行を格納

        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@引継ぎ構造体に格納
            With ptypRtclInfChg
                '@ﾚﾁｸﾙID
                .strReticleID = vsfRtclListMente.GetData(vsfRtclListMente.Row, CMlngvsfRtclListMenteRtclID)
                '@SMIFID
                .strSmifID = vsfRtclListMente.GetData(vsfRtclListMente.Row, CMlngvsfRtclListMenteSMIF)
                '@最終更新日
                .strEditTime = vsfRtclListMente.GetData(vsfRtclListMente.Row, CMlngvsfRtclListMenteEditTimeWk)
            End With
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfRtclListMente
                '@ﾌｫｰｶｽを取得しているﾚﾁｸﾙIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfRtclListMenteRtclID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN00Z1.Instance = New frmxxEN00Z1()
            
            '@子画面名称設定
            frmxxEN00Z1.Instance.Text = CPstrSubFormEN00Z1
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00Z1.Instance = Nothing
                Exit Sub
            End If
            
            '@保留画面起動
            frmxxEN00Z1.Instance.ShowDialog(Me)
            frmxxEN00Z1.Instance = Nothing

            '@最新取得処理
            Call cmdNowListMente_Click(sender,New EventArgs())
            
            '@ﾌｫｰｶｽ戻り位置を設定
        '@↓2012/01/24 (Tue) 12:05:26 T.Oide **************************************************
        '    Call prvFocus_Set(vsfRtclListMente, lstrKeyID, CMlngvsfRtclListMenteRtclID, llngTopRow)
            Call pubGridFocus_Set(vsfRtclListMente, lstrKeyID, CMlngvsfRtclListMenteRtclID, cmdClose)
        '@↑2012/01/24 (Tue) 12:05:26 T.Oide **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRtclInfChange_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdGarbage_Click
    '機　能：ｺﾞﾐ検OK/NG処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/30 (Tue) 15:35:06 N.Kasai
    '更新日：2004/11/30 (Tue) 15:35:06
    '備　考：
    Private Sub cmdGarbage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdGarbage.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
          
            
            '@ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝを判定し処理を分岐
            Select Case cmdGarbage.Text
                '@ｺﾞﾐ検NG
                Case CMstrGarbageNg
                    Call prvRtclChgStat_Set(CMstrChgStat3)
                '@ｺﾞﾐ検OK
                Case CMstrGarbageOk
                    Call prvRtclChgStat_Set(CMstrChgStat4)
            End Select
            
            '@ﾌｫｰｶｽの設定
            If vsfRtclListMente.Enabled = True Then
                Call pubSetFocus(vsfRtclListMente)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdGarbage_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdErrSet_Click
    '機　能：ｴﾗｰ設定/解除処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/30 (Tue) 15:34:26 N.Kasai
    '更新日：2012/01/24 (Tue) 13:38:45 T.Oide
    '備　考：
    Private Sub cmdErrSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdErrSet.Click
        
        Dim lstrKeyID   As String                   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer                  '現在行を格納

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝを判定し処理を分岐
            Select Case cmdErrSet.Text
                '@ｴﾗｰ設定
                Case CMstrErrSet

                    '@引継ぎ構造体に格納
                    With ptypRtclInfChg
                        '@ﾚﾁｸﾙID
                        .strReticleID = vsfRtclListMente.GetData(vsfRtclListMente.Row, CMlngvsfRtclListMenteRtclID)
                        '@最終更新日
                        .strEditTime = vsfRtclListMente.GetData(vsfRtclListMente.Row, CMlngvsfRtclListMenteEditTimeWk)
                        '@ｴﾗｰ理由
                        .strSmifID = vsfRtclListMente.GetData(vsfRtclListMente.Row, CMlngvsfRtclListMenteReasonCode)
                        '@ｴﾗｰｺﾒﾝﾄ
                        .strSmifID = vsfRtclListMente.GetData(vsfRtclListMente.Row, CMlngvsfRtclListMenteReasonComments)
                        '@ｴﾗｰﾎﾞﾀﾝﾌﾗｸﾞ
                        .blnErrBtnFlg = True
                    End With
                    
                    '@ﾌｫｰｶｽ戻り位置を取得
                    With vsfRtclListMente
                        '@ﾌｫｰｶｽを取得しているﾚﾁｸﾙIDを格納
                        lstrKeyID = .GetData(.Row, CMlngvsfRtclListMenteRtclID)
                        '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                        llngTopRow = .Row
                    End With
                    
                    '@Form_Loadﾌﾗｸﾞ(異常)
                    pblnFormLoad = False
                    
                    '@子画面をﾛｰﾄﾞ
                    frmxxEN00Z2.Instance = New frmxxEN00Z2()
                    
                    '@子画面名称設定
                    frmxxEN00Z2.Instance.Text = CPstrSubFormEN00Z2
                    
                    '@Form_Loadﾌﾗｸﾞが異常の場合
                    If pblnFormLoad = False Then
                        '@異常の場合は子画面終了
                        frmxxEN00Z2.Instance = Nothing
                        Exit Sub
                    End If
                    
                    '@保留画面起動
                    frmxxEN00Z2.Instance.ShowDialog(Me)
                    frmxxEN00Z2.Instance = Nothing
                
                    '@最新取得処理
                    Call cmdNowListMente_Click(sender,New EventArgs())
                    
                    '@ﾌｫｰｶｽ戻り位置を設定
        '@↓2012/01/24 (Tue) 12:06:07 T.Oide **************************************************
        '            Call prvFocus_Set(vsfRtclListMente, lstrKeyID, CMlngvsfRtclListMenteRtclID, llngTopRow)
                    Call pubGridFocus_Set(vsfRtclListMente, lstrKeyID, CMlngvsfRtclListMenteRtclID, cmdClose)
        '@↑2012/01/24 (Tue) 12:06:07 T.Oide **************************************************
                    
                '@ｴﾗｰ解除
                Case CMstrErrRelese
                
                    '@引継ぎ構造体に格納
                    With ptypRtclInfChg
                        '@ﾚﾁｸﾙID
                        .strReticleID = vsfRtclListMente.GetData(vsfRtclListMente.Row, CMlngvsfRtclListMenteRtclID)
                        '@最終更新日
                        .strEditTime = vsfRtclListMente.GetData(vsfRtclListMente.Row, CMlngvsfRtclListMenteEditTimeWk)
                        '@ｴﾗｰ理由
                        .strReasonCode = vsfRtclListMente.GetData(vsfRtclListMente.Row, CMlngvsfRtclListMenteReasonCode)
                        '@ｴﾗｰｺﾒﾝﾄ
                        .strReasonComments = vsfRtclListMente.GetData(vsfRtclListMente.Row, CMlngvsfRtclListMenteReasonComments)
                        
                        '@ｴﾗｰﾎﾞﾀﾝﾌﾗｸﾞ
                        .blnErrBtnFlg = False
                    End With
                    
                    '@ﾌｫｰｶｽ戻り位置を取得
                    With vsfRtclListMente
                        '@ﾌｫｰｶｽを取得しているﾚﾁｸﾙIDを格納
                        lstrKeyID = .GetData(.Row, CMlngvsfRtclListMenteRtclID)
                        '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                        llngTopRow = .Row
                    End With
                    
                    '@Form_Loadﾌﾗｸﾞ(異常)
                    pblnFormLoad = False
                    
                    '@子画面をﾛｰﾄﾞ
                    frmxxEN00Z2.Instance = New frmxxEN00Z2()
                    
                    '@子画面名称設定
                    frmxxEN00Z2.Instance.Text = CPstrSubFormEN00Z2
                    
                    '@Form_Loadﾌﾗｸﾞが異常の場合
                    If pblnFormLoad = False Then
                        '@異常の場合は子画面終了
                        frmxxEN00Z2.Instance = Nothing
                        Exit Sub
                    End If
                    
                    '@保留画面起動
                    frmxxEN00Z2.Instance.ShowDialog(Me)
                    frmxxEN00Z2.Instance = Nothing
                
                    '@最新取得処理
                    Call cmdNowListMente_Click(sender,New EventArgs())
                    
                    '@ﾌｫｰｶｽ戻り位置を設定
        '@↓2012/01/24 (Tue) 12:06:42 T.Oide **************************************************
        '            Call prvFocus_Set(vsfRtclListMente, lstrKeyID, CMlngvsfRtclListMenteRtclID, llngTopRow)
                    Call pubGridFocus_Set(vsfRtclListMente, lstrKeyID, CMlngvsfRtclListMenteRtclID, cmdClose)
        '@↑2012/01/24 (Tue) 12:06:42 T.Oide **************************************************
                    
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdErrSet_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdShip_Click
    '機　能：出庫指示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/30 (Tue) 18:59:25 N.Kasai
    '更新日：2004/11/30 (Tue) 18:59:25
    '備　考：
    Private Sub cmdShip_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdShip.Click
        
        Dim lblnAns                 As Boolean          '戻り値
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim lstrEventName           As String           'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        Dim lstrCarrierID           As String           'ｷｬﾘｱID
        Dim lstrCarrierPosition     As String           'ｷｬﾘｱ位置
        Dim llngCnt                 As Integer          'ｶｳﾝﾀ

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@ｽﾄｯｶｰのﾁｪｯｸ
            '@ｽﾄｯｶｰ未設定の場合は中止
            If cmbStockerName.Value = vbNullString Then

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004L)

                '@失敗ﾒｯｾｰｼﾞ表示("<TRM4LW>$$ストッカーが設定されていません。設定を見直してください。")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@ﾌｫｰｶｽの設定
                If cmbStockerName.Enabled = True Then
                    Call pubSetFocus(cmbStockerName)
                End If
                
                Exit Sub
            End If
            
            '@ﾃﾞｰﾀﾁｪｯｸ用
            With vsfRtclListMente
                lstrCarrierID = .GetData(.Row, CMlngvsfRtclListMenteSMIF)                          'SMIF
                lstrCarrierPosition = .GetData(.Row, CMlngvsfRtclListMenteCurrentPotition)         '現在位置
            End With

            '@空の項目があれば中止
            '@ｷｬﾘｱIDﾁｪｯｸ
            If lstrCarrierID = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004I)

                '@失敗ﾒｯｾｰｼﾞ表示("SMIFが設定されていません。設定を見直してください。")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@ﾌｫｰｶｽの設定
                If vsfRtclListMente.Enabled = True Then
                    Call pubSetFocus(vsfRtclListMente)
                End If
                
                Exit Sub
            End If
            
        '@↓2017/02/09 (Thu) S.Otaki **************************************************
            '@ｷｬﾘｱ位置ﾁｪｯｸ
            With vsfRtclListMente
                For llngCnt = 0 To mlngStockerListCnt-1
                    '@ｽﾄｯｶｰIDと選択現在位置IDが同じか
                    If .GetData(.Row, CMlngvsfRtclListMenteCurrentPotitionID) _
                       = mtypStockerList(llngCnt).strStockerId Then
                        '@出庫指示ﾎﾞﾀﾝを有効に
                        cmdShip.Enabled = True
                        Exit For
                    End If
                Next llngCnt
                
                If cmdShip.Enabled = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003O, lstrCarrierID)
                        
                    '@失敗ﾒｯｾｰｼﾞ表示("SMIF[%1]はストッカー内に存在しません。")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                    '@ﾌｫｰｶｽの設定
                    If vsfRtclListMente.Enabled = True Then
                        Call pubSetFocus(vsfRtclListMente)
                    End If
                        
                    Exit Sub
                End If
            End With
        '@↑2017/02/09 (Thu) S.Otaki **************************************************
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                '@ﾌｫｰｶｽの設定
                If vsfRtclListMente.Enabled = True Then
                    Call pubSetFocus(vsfRtclListMente)
                End If
                
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
                
                '@pubVsfInfo_Disp(ﾒｯｾｰｼﾞｺｰﾄﾞ："<TRM3GI>$$SMIF[%1]のストッカー[%2]への出庫指示を受け付けました。")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@最新情報取得
                Call cmdNowListMente_Click(sender,New EventArgs())
                
                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@ﾌｫｰｶｽの設定
                If vsfRtclListMente.Enabled = True Then
                    Call pubSetFocus(vsfRtclListMente)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdShip_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowListMente_Click
    '機　能：ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab最新取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 11:21:24 Y.Yamagishi
    '更新日：2004/10/18 (Mon) 16:36:17 Y.Yamagishi
    '備　考：2004/10/18 (Mon) 16:36:17 Y.Yamagishi 0件表示のﾒｯｾｰｼﾞﾎﾞｯｸｽを表示しない(ｺﾒﾝﾄｱｳﾄ)不具合改善№1093
    Private Sub cmdNowListMente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowListMente.Click

        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypRtclList2           As RtclList2            'ﾚﾁｸﾙ情報格納変数

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@機種ｺｰﾄﾞ空欄の場合
            If cmbPdCodeMente.Text = vbNullString Then
                '@機種ｺｰﾄﾞにｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmbPdCodeMente)
                
                '@処理を抜ける
                Exit Sub
            End If

            '@ﾏｽｸﾊﾟﾀｰﾝ空欄 or 0項目の場合
            If cmbMaskPatternMente.Text = vbNullString Then
                '@ﾏｽｸﾊﾟﾀｰﾝにｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmbMaskPatternMente)
                
                '@処理を抜ける
                Exit Sub
            End If

            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
            lstrFormName = Me.Name
            lstrEventName = "cmdNowListMente_Click"
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab-ﾚﾁｸﾙID一覧の初期化
            'Call prvvsfRtclListMente_Init()
            
            '@ﾚﾁｸﾙ情報格納変数に値をｾｯﾄ
            With ltypRtclList2
                '@ｼｽﾃﾑﾌﾞﾛｯｸｾｯﾄ
                .strSbID = pstrSBID
                '@Msgﾊﾞｰｼﾞｮﾝｾｯﾄ
                .strMsgVer = CMstrrtcllist____Ver
                '@処理区分ｾｯﾄ
                .strClassDivison = CPstrCD04 & CPstrCD2K
                '@機種ｺｰﾄﾞｾｯﾄ
                .strReticlePdCode = cmbPdCodeMente.Text
                '@ﾏｽｸﾊﾟﾀｰﾝｾｯﾄ
                .strReticleMaskPattern = cmbMaskPatternMente.Text
                '@ﾚﾁｸﾙ型番ｾｯﾄ
                .strReticleName = CMstrlblSrash & cmbPdCodeMente.Text & CMstrlblSrash & cmbMaskPatternMente.Text
                '@装置ID
                .lngWpListCnt = 0
            End With
            
            '@ﾚﾁｸﾙ情報取得
            lblnAns = pubblnRtclList____Sel(ltypRtclList2, mtypRtclList, mlngRtclListCnt)
            '@結果判定
            If lblnAns = True Then
                '@一覧表示
                Call vsfRtclListMente_Disp()

                '@最新取得ﾎﾞﾀﾝ活性化
                cmdNowListMente.Enabled = True

                If vsfRtclListMente.Enabled = True Then
                    '@一覧へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(vsfRtclListMente)
                Else
                    '@取得件数が1件以上の場合
                    If mlngRtclListCnt > 0 Then
                        '@最新取得ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmdNowListMente)
                    End If
                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTabﾏｽｸﾊﾟﾀｰﾝ退避
                mstrMaskPatternMente = cmbMaskPatternMente.Text
                
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowListMente_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListMente_AfterSort
    '機　能：ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab一覧AfterSort処理
    '引　数：Col：ｿｰﾄ列
    '　　　：Order：ｿｰﾄ方法
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 16:53:13 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 15:15:11 Y.Yamagishi
    '備　考：2004/10/14 (Thu) 15:15:11 Y.Yamagishi 列幅、ｿｰﾄ順、ｶﾚﾝﾄ行の保持修正
    Private Sub vsfRtclListMente_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfRtclListMente.AfterSort
        Dim ScrollPosition As Point
        Try
           
            'NSYS データ行がない場合は処理を抜ける
            If vsfRtclListMente.Rows.Count <= vsfRtclListMente.Rows.Fixed Then
                Return
            End If
            
            AddHandler vsfRtclListMente.EnterCell, AddressOf vsfRtclListMente_EnterCell
            AddHandler vsfRtclListMente.BeforeRowColChange,AddressOf vsfRtclListMente_BeforeRowColChange 
            
            '@ｿｰﾄ順を格納
            With mtypChgSort2
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
                .typChgSortList(.lngCnt)  = typChgSortListTmp
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
            End With

            '@ｿｰﾄされた列を格納
            mlngSortCol = e.Col
            '@ｿｰﾄ方法を格納
            mlngSortOrder = e.Order
               
            'NSYS スクロール位置格納
            ScrollPosition = vsfRtclListRegist.ScrollPosition

            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfAfterSort(vsfRtclListMente, CMlngvsfRowTitle,cmdUP1 ,cmdDown1  ,False, False, False, False)
            vsfRtclListRegist.ScrollPosition = New Point(ScrollPosition.X,vsfRtclListRegist.ScrollPosition.Y)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListMente_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListMente_AfterUserResize
    '機　能：列幅変更時処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2004/10/14 (Thu) 15:20:12 Y.Yamagishi
    '更新日：2007/07/09 (Mon) 14:33:59 N.Kasai
    '備　考：2004/10/27 (Wed) 13:07:57 N.Kasai  横ｽｸﾛｰﾙ機能追加
    '　　　：2007/07/09 (Mon) 14:33:59 N.Kasai  ｸﾞﾘｯﾄﾞ共通
    Private Sub vsfRtclListMente_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfRtclListMente.AfterResizeColumn, vsfRtclListMente.AfterResizeRow

        Try
           
            'NSYS データ行がない場合は処理を抜ける
            If vsfRtclListMente.Rows.Count <= vsfRtclListMente.Rows.Fixed Then
                Return
            End If
            

            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort2.blnChgWidth = True
            
        '@↓2007/07/09 (Mon) 14:33:47 N.Kasai **************************************************
            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
            Call pubCmdLREnable_Set(vsfRtclListMente, cmdLeft2, cmdRight2)
            
        '    With vsfRtclListMente
        '        '@全列数の幅取得(非表示項目は含めない)
        '        For llngCnt = 0 To .Cols - 1
        '            '@非表示列ではない場合
        '            If .ColHidden(llngCnt) <> True Then
        '                llngWidthAll = llngWidthAll + .ColWidth(llngCnt)
        '            End If
        '        Next llngCnt
        '
        '        '@ｸﾞﾘｯﾄﾞ幅と比較して横ｽｸﾛｰﾙﾎﾞﾀﾝを活性化するか判断
        '        If .Width - llngWidthAll >= 0 Then
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=2:非活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOffFlag
        '
        '            '@右ｽｸﾛｰﾙ非活性化
        '            cmdRight2.Enabled = False
        '        Else
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=1:活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOnFlag
        '
        '            '@右ｽｸﾛｰﾙ活性化
        '            cmdRight2.Enabled = True
        '        End If
        '    End With
        '@↑2007/07/09 (Mon) 14:33:47 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListMente_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListMente_BeforeRowColChange
    '機　能：変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2004/10/14 (Thu) 15:26:43 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 15:26:43
    '備　考：
    Private Sub vsfRtclListMente_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfRtclListMente.BeforeRowColChange
        
        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfRtclListMente.Rows.Count <= vsfRtclListMente.Rows.Fixed Then
                Return
            End If
            

            '@旧行と新行が違っていて、新行がデータ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ﾚﾁｸﾙID)
                mtypChgSort2.strKey = vsfRtclListMente.GetData(e.NewRange.r1, CMlngvsfRtclListMenteRtclID)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListMente_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListMente_BeforeSort
    '機　能：ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab一覧ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 16:52:59 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 16:52:59
    '備　考：
    Private Sub vsfRtclListMente_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfRtclListMente.BeforeSort

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfRtclListMente.Rows.Count <= vsfRtclListMente.Rows.Fixed Then
                Return
            End If
            
            RemoveHandler vsfRtclListMente.BeforeRowColChange, AddressOf vsfRtclListMente_BeforeRowColChange 
            RemoveHandler vsfRtclListMente.EnterCell, AddressOf vsfRtclListMente_EnterCell

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfBeforeSort(vsfRtclListMente, CMlngVsfRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListMente_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListMente_EnterCell
    '機　能：ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTabﾚﾁｸﾙID一覧ｸﾞﾘｯﾄﾞEnterCell
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 16:16:19 Y.Yamagishi
    '更新日：2004/08/26 (Thu) 16:16:19
    '備　考：
    Private Sub vsfRtclListMente_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfRtclListMente.EnterCell

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfRtclListMente.Rows.Count <= vsfRtclListMente.Rows.Fixed Then
                Return
            End If
            
            
            '@状態変更ﾎﾞﾀﾝ有効無効ﾁｪｯｸ
            Call prvChgStatBtn_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListMente_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp2_Click
    '機　能：前ﾍﾟｰｼﾞﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/19 (Tue) 09:29:47 N.Kojima
    '更新日：2004/10/19 (Tue) 09:29:47
    '備　考：
    Private Sub cmdUp2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp2.Click

        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdUp(vsfRtclListMente, cmdUP2, cmdDown2)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown2_Click
    '機　能：次ﾍﾟｰｼﾞﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/19 (Tue) 09:29:47 N.Kojima
    '更新日：2004/10/19 (Tue) 09:29:47
    '備　考：
    Private Sub cmdDown2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown2.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdDown(vsfRtclListMente, cmdUP2, cmdDown2, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLeft2_Click
    '機　能：左ｽｸﾛｰﾙﾎﾞﾀﾝ押下(ﾚﾁｸﾙﾒﾝﾃﾅﾝｽ)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/27 (Wed) 15:24:07 N.Kasai
    '更新日：2007/07/05 (Thu) 14:44:37 N.Kasai
    '備　考：
    '　　　：2007/07/05 (Thu) 14:44:37 N.Kasai  ｸﾞﾘｯﾄﾞ共通
    Private Sub cmdLeft2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft2.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
           

            '@左ｽｸﾛｰﾙﾎﾞﾀﾝ制御
            Call pubVsfCmdLeft(vsfRtclListMente, cmdLeft2, cmdRight2)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLeft2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRight2_Click
    '機　能：右ｽｸﾛｰﾙﾎﾞﾀﾝ押下(ﾚﾁｸﾙﾒﾝﾃﾅﾝｽ)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/27 (Wed) 15:24:58 N.Kasai
    '更新日：2007/07/05 (Thu) 14:42:49 N.Kasai
    '備　考：
    '　　　：2007/07/05 (Thu) 14:42:49 N.Kasai  ｸﾞﾘｯﾄﾞ共通
    Private Sub cmdRight2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight2.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
           

            '@右ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            Call pubVsfCmdRight(vsfRtclListMente, cmdLeft2, cmdRight2)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRight2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@装置内ﾚﾁｸﾙ一覧Tab処理############################################################
    '関数名：cmbWplist_Change
    '機　能：装置内ﾚﾁｸﾙ一覧Tabﾚﾁｸﾙ使用装置変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 18:57:27 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 15:12:20 Y.Yamagishi
    '備　考：2004/10/14 (Thu) 15:12:20 Y.Yamagishi 列幅、ｿｰﾄ順、ｶﾚﾝﾄ行の保持修正
    Private Sub cmbWplist_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWplist.Change

        Try
            
            '@初期化
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort3.strKey = vbNullString
            
            '@空欄 の場合
            If cmbWplist.Text = vbNullString Then
                '@装置内ﾚﾁｸﾙ一覧TabﾚﾁｸﾙID一覧初期化
                Call prvvsfRtclListWpIn_Init()
            Else
                '@装置内ﾚﾁｸﾙ一覧Tabﾚﾁｸﾙ使用装置退避用変数初期化
                mstrWplist = vbNullString
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWplist_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWplist_CloseUp
    '機　能：装置内ﾚﾁｸﾙ一覧Tabﾚﾁｸﾙ使用装置CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 18:57:27 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 18:57:27
    '備　考：
    Private Sub cmbWplist_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWplist.CloseUp

        Try
                       
            '@空欄 の場合
            If cmbWplist.Text <> vbNullString And cmbWplist.Text <> CMstrCmbAddedCommentNone Then
                '@Validate処理へ
                RemoveHandler cmbWplist.Validating,AddressOf cmbWplist_Validate
                Call cmbWplist_Validate(cmbWplist,New CancelEventArgs(True))
                AddHandler cmbWplist.Validating,AddressOf cmbWplist_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWplist_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWplist_Validate
    '機　能：装置内ﾚﾁｸﾙ一覧Tabﾚﾁｸﾙ使用装置Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 18:57:27 Y.Yamagishi
    '更新日：2004/09/06 (Mon) 09:29:10 Y.Yamagishi
    '備　考：
    Private Sub cmbWplist_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWplist.Validating

        Try
           
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            

            '@装置内ﾚﾁｸﾙ一覧Tabﾚﾁｸﾙ使用装置退避
            If mstrWplist = cmbWplist.Value And _
               (cmbWplist.Value <> vbNullString And cmbWplist.Text <> CMstrCmbAddedCommentNone) Then
                 If ActiveControl.Name = cmbWplist.name
                    If vsfRtclListWpIn.Rows.Count > 1 Then
                        Call pubSetFocus(vsfRtclListWpIn)
                    Else
                        Call pubSetFocus(cmdNowListWpIn)
                    End If
                 End if
                Exit Sub
            End If
            
            '@ﾚﾁｸﾙ使用装置選択がされていない場合
            If cmbWplist.Text = vbNullString Or cmbWplist.Text = CMstrCmbAddedCommentNone Then
                If ActiveControl.Name = cmbWplist.name
                   If cmdNowListRegist.Enabled = True Then
                     '@最新取得へﾌｫｰｶｽｾｯﾄ
                     Call pubSetFocus(cmdNowListWpIn)
                   Else
                     '@閉じるﾎﾞﾀﾝにｾｯﾄﾌｫｰｶｽ
                     Call pubSetFocus(cmdClose)
                   End If
                End if
                Exit Sub
            End If
            
            '@最新情報取得処理へ
            Call cmdNowListWpIn_Click(sender,New EventArgs())

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWplist_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowListWpIn_Click
    '機　能：装置内ﾚﾁｸﾙ一覧Tabﾚﾁｸﾙ使用装置最新取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 19:01:15 Y.Yamagishi
    '更新日：2004/10/18 (Mon) 16:38:21 Y.Yamagishi
    '備　考：2004/10/18 (Mon) 16:38:21 Y.Yamagishi 0件表示のﾒｯｾｰｼﾞﾎﾞｯｸｽを表示しない(ｺﾒﾝﾄｱｳﾄ)不具合改善№1093
    Private Sub cmdNowListWpIn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowListWpIn.Click

        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypRtclList2           As RtclList2            'ﾚﾁｸﾙ情報格納変数
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
           
            
            '@ﾚﾁｸﾙ使用装置空欄 or 0項目の場合
            If cmbWplist.Text = vbNullString Or cmbWplist.Text = CMstrCmbAddedCommentNone Then
                '@ﾚﾁｸﾙ使用装置にｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmbWplist)
                
                '@処理を抜ける
                Exit Sub
            End If

            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
            lstrFormName = Me.Name
            lstrEventName = "cmdNowListRegist_Click"

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@装置内ﾚﾁｸﾙ一覧TabﾚﾁｸﾙID一覧初期化
            'Call prvvsfRtclListWpIn_Init()

            '@ﾚﾁｸﾙ情報格納変数に値をｾｯﾄ
            With ltypRtclList2
                '@ｼｽﾃﾑﾌﾞﾛｯｸｾｯﾄ
                .strSbID = pstrSBID
                '@Msgﾊﾞｰｼﾞｮﾝｾｯﾄ
                .strMsgVer = CMstrrtcllist____Ver
                '@処理区分ｾｯﾄ
                .strClassDivison = CPstrCD26
                '@機種ｺｰﾄﾞｾｯﾄ
                .strReticlePdCode = vbNullString
                '@ﾏｽｸﾊﾟﾀｰﾝｾｯﾄ
                .strReticleMaskPattern = vbNullString
                '@ﾚﾁｸﾙ型番ｾｯﾄ
                .strReticleName = vbNullString
                '装置IDｶｳﾝﾄ数
                .lngWpListCnt = cmbWplist.ValueCount
                
                '@装置ID構造体作成
               If .typWpList Is Nothing Then
                    .typWpList = New List(Of WP)
                End If
                Do While .typWPList.Count -1 < .lngWPListCnt -1
                    .typWpList.Add(New WP)
                Loop
                Dim typWpListTmp As WP = New WP

                lstrTemp = Split(cmbWpList.Value, vbTab)
                For llngLoopCnt = LBound(lstrTemp) To UBound(lstrTemp)
                    typWPlistTmp.strWpID = lstrTemp(llngLoopCnt)                 '装置ID
                    .typWpList(llngLoopCnt) = typWpListTmp
                Next llngLoopCnt
            End With
            
            '@ﾚﾁｸﾙ情報取得
            lblnAns = pubblnRtclList____Sel(ltypRtclList2, mtypRtclList, mlngRtclListCnt)
            '@結果判定
            If lblnAns = True Then
                '@一覧表示
                Call vsfRtclListWpIn_Disp()

                '@最新取得ﾎﾞﾀﾝ活性化
                cmdNowListWpIn.Enabled = True

                If vsfRtclListWpIn.Enabled = True Then
                    '@一覧へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(vsfRtclListWpIn)
                Else
                    '@取得件数が1件以上の場合
                    If mlngRtclListCnt > 0 Then
                        '@最新取得ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmdNowListMente)
                    End If
                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                '@装置内ﾚﾁｸﾙ一覧Tabﾚﾁｸﾙ使用装置を退避
                mstrWplist = cmbWplist.Value

                '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
                If lblLotCntWpIn.Text = CPstrLotCnt0 Then
                    '@装置内ﾚﾁｸﾙ一覧TabﾚﾁｸﾙID一覧初期化
                    Call prvvsfRtclListWpIn_Init()
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowListWpIn_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListWpIn_AfterSort
    '機　能：装置内ﾚﾁｸﾙ一覧Tab一覧AfterSort処理
    '引　数：Col：ｿｰﾄ列
    '　　　：Order：ｿｰﾄ方法
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 16:53:13 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 16:53:13
    '更新日：2004/10/14 (Thu) 15:15:11 Y.Yamagishi
    '備　考：2004/10/14 (Thu) 15:15:11 Y.Yamagishi 列幅、ｿｰﾄ順、ｶﾚﾝﾄ行の保持修正
    Private Sub vsfRtclListWpIn_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfRtclListWpIn.AfterSort
        Dim ScrollPosition As Point

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfRtclListWpIn.Rows.Count <= vsfRtclListWpIn.Rows.Fixed Then
                Return
            End If

            AddHandler vsfRtclListWpIn.BeforeRowColChange,AddressOf vsfRtclListWpIn_BeforeRowColChange

            '@ｿｰﾄ順を格納
            With mtypChgSort3
                
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                Do While .typChgSortList.Count -1 < .lngCnt
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

            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort3.blnChgWidth = True
            
            '@ｿｰﾄされた列を格納
            mlngSortCol = e.Col
            
            '@ｿｰﾄ方法を格納
            mlngSortOrder = e.Order

            'NSYS スクロール位置格納
            ScrollPosition = vsfRtclListWpIn.ScrollPosition

            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfAfterSort(vsfRtclListWpIn, CMlngVsfRowTitle,cmdUP3 ,cmdDown3 ,False, False, False, False)

            vsfRtclListWpIn.ScrollPosition = New Point(ScrollPosition.X,vsfRtclListWpIn.ScrollPosition.Y)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListWpIn_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListWpIn_AfterUserResize
    '機　能：列幅変更時処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2004/10/14 (Thu) 15:21:01 Y.Yamagishi
    '更新日：2007/07/09 (Mon) 14:34:53 N.Kasai
    '備　考：
    '　　　：2007/07/09 (Mon) 14:34:53 N.Kasai  ｸﾞﾘｯﾄﾞ共通
    Private Sub vsfRtclListWpIn_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfRtclListWpIn.AfterResizeColumn, vsfRtclListWpIn.AfterResizeRow

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfRtclListWpIn.Rows.Count <= vsfRtclListWpIn.Rows.Fixed Then
                Return
            End If
         

            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort3.blnChgWidth = True
            
        '@↓2007/07/09 (Mon) 14:34:50 N.Kasai **************************************************
            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
            Call pubCmdLREnable_Set(vsfRtclListWpIn, cmdLeft3, cmdRight3)

            
        '    With vsfRtclListWpIn
        '        '@全列数の幅取得(非表示項目は含めない)
        '        For llngCnt = 0 To .Cols - 1
        '            '@非表示列ではない場合
        '            If .ColHidden(llngCnt) <> True Then
        '                llngWidthAll = llngWidthAll + .ColWidth(llngCnt)
        '            End If
        '        Next llngCnt
        '
        '        '@ｸﾞﾘｯﾄﾞ幅と比較して横ｽｸﾛｰﾙﾎﾞﾀﾝを活性化するか判断
        '        If .Width - llngWidthAll >= 0 Then
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=2:非活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOffFlag
        '
        '            '@右ｽｸﾛｰﾙ非活性化
        '            cmdRight3.Enabled = False
        '        Else
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=1:活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOnFlag
        '
        '            '@右ｽｸﾛｰﾙ活性化
        '            cmdRight3.Enabled = True
        '        End If
        '    End With
        '@↑2007/07/09 (Mon) 14:34:50 N.Kasai **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListWpIn_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListWpIn_BeforeRowColChange
    '機　能：変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2004/10/14 (Thu) 15:28:07 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 15:28:07
    '備　考：
    Private Sub vsfRtclListWpIn_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfRtclListWpIn.BeforeRowColChange
        
        Try
                       
            'NSYS データ行がない場合は処理を抜ける
            If vsfRtclListWpIn.Rows.Count <= vsfRtclListWpIn.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がデータ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ﾚﾁｸﾙID)
                mtypChgSort3.strKey = vsfRtclListWpIn.GetData(e.NewRange.r1, CMlngvsfRtclListWpInRtclID)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListWpIn_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListWpIn_BeforeSort
    '機　能：装置内ﾚﾁｸﾙ一覧Tab一覧ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 16:52:59 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 16:52:59
    '備　考：
    Private Sub vsfRtclListWpIn_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfRtclListWpIn.BeforeSort

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfRtclListWpIn.Rows.Count <= vsfRtclListWpIn.Rows.Fixed Then
                Return
            End If
            
            RemoveHandler vsfRtclListWpIn.BeforeRowColChange, AddressOf vsfRtclListWpIn_BeforeRowColChange 

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfBeforeSort(vsfRtclListWpIn, CMlngVsfRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListWpIn_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp3_Click
    '機　能：前ﾍﾟｰｼﾞﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/19 (Tue) 09:29:47 N.Kojima
    '更新日：2004/10/19 (Tue) 09:29:47
    '備　考：
    Private Sub cmdUp3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp3.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
           

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdUp(vsfRtclListWpIn, cmdUP3, cmdDown3)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp3_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown3_Click
    '機　能：次ﾍﾟｰｼﾞﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/19 (Tue) 09:29:47 N.Kojima
    '更新日：2004/10/19 (Tue) 09:29:47
    '備　考：
    Private Sub cmdDown3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown3.Click

        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
           

            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdDown(vsfRtclListWpIn, cmdUP3, cmdDown3)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown3_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLeft3_Click
    '機　能：左ｽｸﾛｰﾙﾎﾞﾀﾝ押下(装置内ﾚﾁｸﾙ一覧)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/27 (Wed) 15:25:20 N.Kasai
    '更新日：2007/07/05 (Thu) 14:45:14 N.Kasai
    '備　考：
    '　　　：2007/07/05 (Thu) 14:45:14 N.Kasai  ｸﾞﾘｯﾄﾞ共通
    Private Sub cmdLeft3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft3.Click

        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@左ｽｸﾛｰﾙﾎﾞﾀﾝ制御
            Call pubVsfCmdLeft(vsfRtclListWpIn, cmdLeft3, cmdRight3)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLeft3_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRight3_Click
    '機　能：右ｽｸﾛｰﾙﾎﾞﾀﾝ押下(装置内ﾚﾁｸﾙ一覧)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/27 (Wed) 15:26:17 N.Kasai
    '更新日：2007/07/05 (Thu) 14:43:45 N.Kasai
    '備　考：
    '　　　：2007/07/05 (Thu) 14:43:45 N.Kasai  ｸﾞﾘｯﾄﾞ共通
    Private Sub cmdRight3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight3.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@右ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            Call pubVsfCmdRight(vsfRtclListWpIn, cmdLeft3, cmdRight3)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRight3_Click"
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

    '関数名：prvfrmxxEN00Z0_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/24 (Tue) 10:17:00 Y.Yamagishi
    '更新日：2004/11/30 (Tue) 14:49:14 N.Kasai
    '備　考：2004/09/22 (Wed) 20:27:12 Y.Yamagishi  ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝを常時有効(不具合改善№848)
    '　　　：2004/10/04 (Mon) 13:52:46 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/11/30 (Tue) 14:49:14 N.Kasai      出庫指示ﾎﾞﾀﾝ初期化追加
    Private Sub prvfrmxxEN00Z0_Init()
        
        Dim lstrFormTitle   As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00Z0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@各Comboﾎﾞｯｸｽの初期化
            cmbPdCodeRegist.Clear                   'ﾚﾁｸﾙ登録Tab-機種ｺｰﾄﾞ
            cmbPdCodeMente.Clear                    'ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab-機種ｺｰﾄﾞ
            cmbPdCodeMente.Enabled = False          'ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab-機種ｺｰﾄﾞ
            cmbMaskPatternRegist.Clear              'ﾚﾁｸﾙ登録Tab-ﾏｽｸﾊﾟﾀｰﾝ
            cmbMaskPatternMente.Clear               'ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab-ﾏｽｸﾊﾟﾀｰﾝ
            cmbMaskPatternRegist.Enabled = False    'ﾚﾁｸﾙ登録Tab-ﾏｽｸﾊﾟﾀｰﾝ
            cmbMaskPatternMente.Enabled = False     'ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab-ﾏｽｸﾊﾟﾀｰﾝ
            cmbWplist.Clear                         '装置内ﾚﾁｸﾙ一覧Tab-ﾚﾁｸﾙ使用装置
            cmbWplist.Enabled = False               '装置内ﾚﾁｸﾙ一覧Tab-ﾚﾁｸﾙ使用装置
            
            '@各ﾗﾍﾞﾙの初期化
            lblNowDateRegist.Text = vbNullString 'ﾚﾁｸﾙ登録Tab-取得時間
            lblNowDateMente.Text = vbNullString  'ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab-取得時間
            lblNowDateWpIn.Text = vbNullString   '装置内ﾚﾁｸﾙ一覧Tab-取得時間
            lblLotCntRegist.Text = vbNullString  'ﾚﾁｸﾙ登録Tab-取得時間
            lblLotCntMente.Text = vbNullString   'ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab-取得時間
            lblLotCntWpIn.Text = vbNullString    '装置内ﾚﾁｸﾙ一覧Tab-取得時間
            
            '@ﾚﾁｸﾙ登録Tab新規登録ﾚﾁｸﾙID情報初期化
            Call prvNewReticleInf_Init()
            
            '@各Commandﾎﾞﾀﾝの初期化(非活性化)
            '@ﾚﾁｸﾙ登録Tab
            cmdNowListRegist.Enabled = False        '最新取得
            cmdRtclIDCopy.Enabled = False           'ﾚﾁｸﾙIDｺﾋﾟｰ
            cmdRegist.Enabled = False               'ﾚﾁｸﾙID登録
            
            '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab
            cmdNowListMente.Enabled = False         '最新取得
            cmdPut.Enabled = False                  '返却
            cmdArrive.Enabled = False               '再入荷
            cmdDel.Enabled = False                  'ﾚﾁｸﾙ削除
            cmdRtclInfChange.Enabled = False        'ﾚﾁｸﾙ情報変更
            cmdGarbage.Enabled = False              'ｺﾞﾐ検OK/NG
            cmdErrSet.Enabled = False               'ｴﾗｰ設定/解除
            cmdShip.Enabled = False                 '出庫指示
            cmbStockerName.Enabled = False          'ｽﾄｯｶｰ
            
            '@装置内ﾚﾁｸﾙ一覧Tab
            cmdNowListWpIn.Enabled = False          '最新取得
            
            '@各vsfｸﾞﾘｯﾄﾞの初期化
            Call prvvsfRtclListRegist_Init          'ﾚﾁｸﾙ登録Tab-ﾚﾁｸﾙID一覧
            Call prvvsfRtclListMente_Init           'ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab-ﾚﾁｸﾙID一覧
            Call prvvsfRtclListWpIn_Init            '装置内ﾚﾁｸﾙ一覧Tab-ﾚﾁｸﾙID一覧
            
            'NSYS 各グリッドの使用を不可
            'vsfRtclListRegist.Enabled = False
            'vsfRtclListMente.Enabled = False
            'vsfRtclListWpIn.Enabled = false

            '@閉じるボタンへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00Z0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvNewReticleInf_Init
    '機　能：ﾚﾁｸﾙ登録Tab新規登録ﾚﾁｸﾙID情報初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/24 (Tue) 10:17:00 Y.Yamagishi
    '更新日：2004/08/24 (Tue) 10:17:00
    '備　考：
    Private Sub prvNewReticleInf_Init()

        Try

            '@ﾚﾁｸﾙ登録TabﾚﾁｸﾙID初期化
            txtNewRtclID.Text = vbNullString
            txtNewRtclID2.Text = vbNullString
            txtNewRtclID.Enabled = True
            txtNewRtclID2.Enabled = True
            
            '@ﾚﾁｸﾙ登録Tab入荷日初期化
            With dtpArriveTime
                .Value = Format$(Now, CPstrDateTimeYMD)
                .Enabled = True
                .CalendarHeight = CPlngClHeight                                 'ｶﾚﾝﾀﾞｰ高さ
                .CalendarWidth = CPlngClWidth                                   'ｶﾚﾝﾀﾞｰ幅
                .DayFont = New Font(.Font.FontFamily,CPlngClFontSize)           '日付ﾌｫﾝﾄｻｲｽﾞ
                .TitleFont= New Font(.Font.FontFamily,CPlngClTlFontSize)        'ｶﾚﾝﾀﾞｰ見出ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.FontFamily,CPlngClGridFontSize)      'ｶﾗﾝﾀﾞｰｸﾞﾘｯﾄｻｲｽﾞ
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvNewReticleInf_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfRtclListRegist_Init
    '機　能：ﾚﾁｸﾙ登録Tab-ﾚﾁｸﾙID一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/24 (Tue) 10:38:08 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 15:39:52 Y.Yamagishi
    '備　考：2004/10/14 (Thu) 15:39:52 Y.Yamagishi  列幅、ｿｰﾄ順、ｶﾚﾝﾄ行の保持修正
    '　　　：2004/10/27 (Wed) 12:53:33 N.Kasai      左右ｽｸﾛｰﾙﾎﾞﾀﾝ機能追加
    '　　　：2004/11/19 (Fri) 16:24:58 S.Deguchi    該当件数と取得日時の初期化を追加
    Private Sub prvvsfRtclListRegist_Init()

        Try

            With vsfRtclListRegist

                .Redraw = false

                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
                '.FillStyle = flexFillRepeat
                
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '@ﾏｳｽでｾﾙ範囲選択不可
                '@ｾﾙ選択の設定
                .SelectionMode = SelectionModeEnum.Row
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号（...）を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter

                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.BackColor = Color.Navy              '背景色
                lFixedStyle.ForeColor = Color.Yellow            '文字色
                lFixedStyle.Font = New Font(.Font.FontFamily,CMlngvsfHFontSize, .Font.Style, .Font.Unit)'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListRegistNo, CMstrvsfRtclListRegistNo)                                'No.
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListRegistStatus, CMstrvsfRtclListRegistStatus)                        '状態
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListRegistRtclID, CMstrvsfRtclListRegistRtclID)                        'ﾚﾁｸﾙID
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListRegistCurrentPotition, CMstrvsfRtclListRegistCurrentPotition)      '現在位置
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListRegistArriveTime, CMstrvsfRtclListRegistArriveTime)                '入荷日

                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort1.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfRtclListRegistNo).Width = CMlngvsfWColRtclListRegistNo                              'No.
                    .Cols(CMlngvsfRtclListRegistStatus).Width = CMlngvsfWColRtclListRegistStatus                      '状態
                    .Cols(CMlngvsfRtclListRegistRtclID).Width = CMlngvsfWColRtclListRegistRtclID                      'ﾚﾁｸﾙID
                    .Cols(CMlngvsfRtclListRegistCurrentPotition).Width = CMlngvsfWColRtclListRegistCurrentPotition    '現在位置
                    .Cols(CMlngvsfRtclListRegistArriveTime).Width = CMlngvsfWColRtclListRegistArriveTime              '入荷日
                End If
                
                '@表示位置の設定
                .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
                .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngvsfRowTitle).Height = CMlngvsfHHeight    '高さ
                
                '@ﾛｯｸ
                .Enabled = False
                
                '@行列のﾏｳｽでの変更を可にする
                .AllowResizing = AllowResizingEnum.Columns
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                '@次,前ﾍﾟｰｼﾞﾎﾞﾀﾝ使用不可
                cmdUP1.Enabled = False
                cmdDown1.Enabled = False
                '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御
                cmdLeft1.Enabled = False
                cmdRight1.Enabled = False
                
                '@該当件数/取得日時の初期化
                lblNowDateRegist.Text = vbNullString
                lblLotCntRegist.Text = vbNullString

                .Redraw = True
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfRtclListRegist_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfRtclListMente_Init
    '機　能：ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab-ﾚﾁｸﾙID一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/24 (Tue) 10:38:08 Y.Yamagishi
    '更新日：2005/02/09 (Wed) 14:33:37 N.Kasai
    '備　考：2004/10/14 (Thu) 15:40:48 Y.Yamagishi  列幅、ｿｰﾄ順、ｶﾚﾝﾄ行の保持修正
    '　　　：2004/10/27 (Wed) 12:53:33 N.Kasai      左右ｽｸﾛｰﾙﾎﾞﾀﾝ機能追加
    '　　　：2004/11/19 (Fri) 16:24:58 S.Deguchi    該当件数と取得日時の初期化を追加
    '　　　：2005/02/09 (Wed) 14:33:37 N.Kasai      ｺﾏﾝﾄﾞﾎﾞﾀﾝ初期化追加(№527)
    Private Sub prvvsfRtclListMente_Init()

        Try

            With vsfRtclListMente
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ｶﾚﾝﾄ列初期化
                .Col = .Cols.Fixed
                
                '@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
                '.FillStyle = flexFillRepeat
                
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可               
                '@ﾏｳｽでｾﾙ範囲選択不可                
                '@ｾﾙ選択の設定
                .SelectionMode = SelectionModeEnum.Row
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.BackColor = Color.Navy              '背景色
                lFixedStyle.ForeColor = Color.Yellow            '文字色
                lFixedStyle.Font = New Font(.Font.FontFamily,CMlngvsfHFontSize, .Font.Style, .Font.Unit)'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListMenteNo, CMstrvsfRtclListMenteNo)                              'No.
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListMenteStatus, CMstrvsfRtclListMenteStatus)                      '状態
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListMenteRtclID, CMstrvsfRtclListMenteRtclID)                      'ﾚﾁｸﾙID
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListMenteSMIF, CMstrvsfRtclListMenteSMIF)                          'SMIFID
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListMenteCurrentPotition, CMstrvsfRtclListMenteCurrentPotition)    '現在位置
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListMenteArriveTime, CMstrvsfRtclListMenteArriveTime)              '入荷日
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListMenteEditTime, CMstrvsfRtclListMenteEditTime)                  '最終更新日時

                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort2.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfRtclListMenteNo).Width = CMlngvsfWColRtclListMenteNo                                'No.
                    .Cols(CMlngvsfRtclListMenteStatus).Width = CMlngvsfWColRtclListMenteStatus                        '状態
                    .Cols(CMlngvsfRtclListMenteRtclID).Width = CMlngvsfWColRtclListMenteRtclID                        'ﾚﾁｸﾙID
                    .Cols(CMlngvsfRtclListMenteSMIF).Width = CMlngvsfWColRtclListMenteSMIF                            'SMIF
                    .Cols(CMlngvsfRtclListMenteCurrentPotition).Width = CMlngvsfWColRtclListMenteCurrentPotition      '現在位置
                    .Cols(CMlngvsfRtclListMenteArriveTime).Width = CMlngvsfWColRtclListMenteArriveTime                '入荷日
                    .Cols(CMlngvsfRtclListMenteEditTime).Width = CMlngvsfWColRtclListMenteEditTime                    '最終更新日
                    .Cols(CMlngvsfRtclListMenteWpInFlag).Width = CMlngvsfWColRtclListMenteWpInFlag                    '装置内ﾌﾗｸﾞ(非表示)
                    .Cols(CMlngvsfRtclListMenteReasonCode).Width = CMlngvsfWRtclListMenteReasonCode                   '状態ID(非表示)
                    .Cols(CMlngvsfRtclListMenteReasonComments).Width = CMlngvsfWRtclListMenteReasonComments           'ｴﾗｰ理由(非表示)
                    .Cols(CMlngvsfRtclListMenteStatusID).Width = CMlngvsfWColRtclListMenteStatusID                    'ｴﾗｰｺﾒﾝﾄ(非表示)
                    .Cols(CMlngvsfRtclListMenteEditTimeWk).Width = CMlngvsfWColRtclListMenteEditTimeWk                '最終更新日時(非表示)
                    .Cols(CMlngvsfRtclListMenteStockerInFlag).Width = CMlngvsfWColRtclListMenteStockerInFlag          'ｽﾄｯｶｰ内ﾌﾗｸﾞ(非表示)
                    .Cols(CMlngvsfRtclListMenteCurrentPotitionID).Width = CMlngvsfWColRtclListMentePotitionID         '現在位置ID(非表示)
                End If
                
                '@非表示設定
                .Cols(CMlngvsfRtclListMenteWpInFlag).Visible = false                '装置内ﾌﾗｸﾞ(非表示)
                .Cols(CMlngvsfRtclListMenteStatusID).Visible = false               '状態ID(非表示)
                .Cols(CMlngvsfRtclListMenteReasonComments).Visible = false           'ｴﾗｰ理由(非表示)
                .Cols(CMlngvsfRtclListMenteStatusID).Visible = false                'ｴﾗｰｺﾒﾝﾄ(非表示)
                .Cols(CMlngvsfRtclListMenteEditTimeWk).Visible = false              '最終更新日時(非表示)
                .Cols(CMlngvsfRtclListMenteStockerInFlag).Visible = false           'ｽﾄｯｶｰ内ﾌﾗｸﾞ(非表示)
                .Cols(CMlngvsfRtclListMenteCurrentPotitionID).Visible = false        '現在位置ID(非表示)

                '@表示位置の設定
                .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
                .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight    '高さ
                 
                '@ﾛｯｸ
                .Enabled = False

                '@行列のﾏｳｽでの変更を可にする
                .AllowResizing = AllowResizingEnum.Columns
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                '@次,前ﾍﾟｰｼﾞﾎﾞﾀﾝ使用不可
                cmdUP2.Enabled = False
                cmdDown2.Enabled = False
                '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ使用不可
                cmdLeft2.Enabled = False
                cmdRight2.Enabled = False

                '@該当件数/取得日時の初期化
                lblNowDateMente.Text = vbNullString
                lblLotCntMente.Text = vbNullString

                '@ﾎﾞﾀﾝ初期化
                cmdPut.Enabled = False                  '返却
                cmdArrive.Enabled = False               '再入荷
                cmdDel.Enabled = False                  'ﾚﾁｸﾙ削除
                cmdRtclInfChange.Enabled = False        'ﾚﾁｸﾙ情報変更
                cmdGarbage.Enabled = False              'ｺﾞﾐ検OK/NG
                cmdErrSet.Enabled = False               'ｴﾗｰ設定/解除
                cmdShip.Enabled = False                 '出庫指示
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfRtclListMente_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfRtclListWpIn_Init
    '機　能：装置内ﾚﾁｸﾙ一覧Tab-ﾚﾁｸﾙID一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/24 (Tue) 11:05:59 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 15:41:46 Y.Yamagishi
    '備　考：2004/10/14 (Thu) 15:41:46 Y.Yamagishi  列幅、ｿｰﾄ順、ｶﾚﾝﾄ行の保持修正
    '　　　：2004/10/27 (Wed) 12:53:33 N.Kasai      左右ｽｸﾛｰﾙﾎﾞﾀﾝ機能追加
    '　　　：2004/11/19 (Fri) 16:24:58 S.Deguchi    該当件数と取得日時の初期化を追加
    Private Sub prvvsfRtclListWpIn_Init()

        Try

            With vsfRtclListWpIn
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定

                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可

                '@ﾏｳｽでｾﾙ範囲選択不可

                '@ｾﾙ選択の設定
                .SelectionMode = SelectionModeEnum.Row
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号（...）を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter

                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed 
                lFixedStyle.BackColor = Color.Navy              '文字色
                lFixedStyle.ForeColor = Color.Yellow            '背景色
                lFixedStyle.Font = New Font(.Font.FontFamily,CMlngvsfHFontSize, .Font.Style, .Font.Unit)'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ 

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListWpInNo, CMstrvsfRtclListWpInNo)                    'No.
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListWpInWPID, CMstrvsfRtclListWpInWPID)                '装置
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListWpInStatus, CMstrvsfRtclListWpInStatus)            '状態
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListWpInRtclID, CMstrvsfRtclListWpInRtclID)            'ﾚﾁｸﾙID
                .SetData(CMlngVsfRowTitle, CMlngvsfRtclListWpInEditTime, CMstrvsfRtclListWpInEditTime)        '最終更新日

                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort3.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfRtclListWpInNo).Width = CMlngvsfWColRtclListWpInNo                                          'No.
                    .Cols(CMlngvsfRtclListWpInWPID).Width = CMlngvsfWColRtclListWpInWPID                                      '装置
                    .Cols(CMlngvsfRtclListWpInStatus).Width = CMlngvsfWColRtclListWpInStatus                                  '状態
                    .Cols(CMlngvsfRtclListWpInRtclID).Width = CMlngvsfWColRtclListWpInRtclID                                  'ﾚﾁｸﾙID
                    .Cols(CMlngvsfRtclListWpInEditTime).Width = CMlngvsfWColRtclListWpInEditTime                              '最終更新日
                End If
                
                '@表示位置の設定
                .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
                .Styles.Normal.TextAlign = TextAlignEnum.LeftCenter

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngvsfRowTitle).Height = CMlngvsfHHeight    '高さ
                
                '@ﾛｯｸ
                .Enabled = false

                '@行列のﾏｳｽでの変更を可にする
                .AllowResizing = AllowResizingEnum.Columns
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                '@次,前ﾍﾟｰｼﾞﾎﾞﾀﾝ使用不可
                cmdUP3.Enabled = False
                cmdDown3.Enabled = False
                
                '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ使用不可
                cmdLeft3.Enabled = False
                cmdRight3.Enabled = False
                
                '@該当件数/取得日時の初期化
                lblNowDateWpIn.Text = vbNullString
                lblLotCntWpIn.Text = vbNullString
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfRtclListWpIn_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPdCode_Disp
    '機　能：機種ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 09:59:01 Y.Yamagishi
    '更新日：2004/10/04 (Mon) 09:35:37 Y.Yamagishi
    '備　考：2004/10/04 (Mon) 09:35:37 Y.Yamagishi 機種ｺｰﾄﾞ1件の時初期表示しない(不具合改善№1007)
    Private Sub prvcmbPdCode_Disp()

       Dim llngCnt              As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngRtclCodeCntList  As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngRtclCodeCnt      As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrRtclCode         As List(Of String)      'ｷｬﾘｱﾀｲﾌﾟ格納配列
        Dim lblnFlg              As Boolean              '配列格納ﾌﾗｸﾞ

        Try
            
            '@ﾚﾁｸﾙ登録Tab機種ｺｰﾄﾞｺﾝﾎﾞ
            With cmbPdCodeRegist
                '@機種ｺｰﾄﾞｺﾝﾎﾞ初期化
                .Clear
                .BackColor = SystemColors.Window
                .DispCols = CMlngCmbDispCols                                'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                               '値取得列
                .GetCol = CMlngCmbGetCol0                                   '表示列
                .Font = New Font(.Font.FontFamily,CMlngCmbFontSize)         'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily,CMlngCmbGridFontSize) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .ColAlignment(CMlngCmbGetCol0) = TextAlignEnum.LeftCenter   '左寄中央揃え
                .RowHeight = CMlngCmbRowHeight                              'ｸﾞﾘｯﾄの高さ
                .DirectInput = False                                        '直接入力(Flase)
                
                llngRtclCodeCntList = 0
                
                lstrRtclCode = New List(Of String)
                
                lstrRtclCode.Add(mtypRtclCodeList(llngRtclCodeCntList).lstrReticlePdCode)
                
                '@ｷｬﾘｱﾀｲﾌﾟ情報ｾｯﾄ
                '@構造体のﾙｰﾌﾟ
                For llngCnt = 0 To mlngRtclCodeListCnt-1
                    '@配列格納ﾌﾗｸﾞ初期化
                    lblnFlg = False
                    '@配列のﾙｰﾌﾟ
                    For llngRtclCodeCnt = 0 To llngRtclCodeCntList
                        '@機種ｺｰﾄﾞの判定
                        If lstrRtclCode(llngRtclCodeCnt) = mtypRtclCodeList(llngCnt).lstrReticlePdCode Then
                            '@同じ場合
                            '@配列格納ﾌﾗｸﾞTrue
                            lblnFlg = True
                            Exit For
                        End If
                    Next llngRtclCodeCnt
                    '@配列格納ﾌﾗｸﾞがFalseの場合
                    If lblnFlg = False Then
                        
                        '@配列に機種ｺｰﾄﾞ格納
                        lstrRtclCode.Add(mtypRtclCodeList(llngCnt).lstrReticlePdCode)
                        '@配列ｶｳﾝﾄｱｯﾌﾟ
                        llngRtclCodeCntList = llngRtclCodeCntList + 1
                    End If
                Next llngCnt
                
                '@配列のﾙｰﾌﾟ
                For llngRtclCodeCnt = 0 To llngRtclCodeCntList
                    .AddItem(lstrRtclCode(llngRtclCodeCnt))               '機種ｺｰﾄﾞ
                Next llngRtclCodeCnt
                         
                '@0件目表示
                .ListIndex = -1
            End With
            
            '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab機種ｺｰﾄﾞｺﾝﾎﾞ
            With cmbPdCodeMente
                '@機種ｺｰﾄﾞｺﾝﾎﾞ初期化
                .Clear
                .BackColor = SystemColors.Window
                .DispCols = CMlngCmbDispCols                                'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                               '値取得列
                .GetCol = CMlngCmbGetCol0                                   '表示列
                .Font = New Font(.Font.FontFamily,CMlngCmbFontSize)         'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily,CMlngCmbGridFontSize) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .ColAlignment(CMlngCmbGetCol0) = TextAlignEnum.LeftCenter   '左寄中央揃え
                .RowHeight = CMlngCmbRowHeight                              'ｸﾞﾘｯﾄの高さ
                .DirectInput = False                                        '直接入力(Flase)
                
                '@配列のﾙｰﾌﾟ
                For llngRtclCodeCnt = 0 To llngRtclCodeCntList
                    .AddItem(lstrRtclCode(llngRtclCodeCnt))               '機種ｺｰﾄﾞ
                Next llngRtclCodeCnt
                
                '@0件目表示
                .ListIndex = -1
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbPdCode_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbMaskPattern_Disp
    '機　能：ﾏｽｸﾊﾟﾀｰﾝｺﾝﾎﾞﾎﾞｯｸｽ作成
    '引　数：lobjControl1：ﾏｽｸﾊﾟﾀｰﾝｺﾝﾎﾞﾎﾞｯｸｽ
    '　　　：lobjControl2：機種ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ
    '戻り値：
    '作成日：2004/08/25 (Wed) 11:08:33 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 11:08:33
    '備　考：ﾚﾁｸﾙ登録Tab,ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab共通
    Private Sub prvcmbMaskPattern_Disp(ByVal lobjControl1 As ComboBoxEx, ByVal lobjControl2 As ComboBoxEx)

        Dim llngCnt              As Integer              'ﾙｰﾌﾟｶｳﾝﾄ

        Try
            
            '@ﾚﾁｸﾙ登録Tab機種ｺｰﾄﾞｺﾝﾎﾞ
            With lobjControl1
                '@機種ｺｰﾄﾞｺﾝﾎﾞ初期化
                .Clear
                .DispCols = CMlngCmbDispCols                                'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                               '値取得列
                .GetCol = CMlngCmbGetCol0                                   '表示列
                .Font = New Font(.Font.FontFamily,CMlngCmbFontSize)         'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily,CMlngCmbGridFontSize)'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .ColAlignment(CMlngCmbGetCol0) = TextAlignEnum.LeftCenter   '左寄中央揃え
                .RowHeight = CMlngCmbRowHeight                              'ｸﾞﾘｯﾄの高さ
                .DirectInput = False                                        '直接入力(Flase)
                
                '@ｷｬﾘｱﾀｲﾌﾟ情報ｾｯﾄ
                '@構造体のﾙｰﾌﾟ
                For llngCnt = 0 To mlngRtclCodeListCnt -1
                    '機種ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽの内容とﾚﾁｸﾙ情報格納変数の機種ｺｰﾄﾞが同じ場合
                    If lobjControl2.Text = mtypRtclCodeList(llngCnt).lstrReticlePdCode Then
                        '@ﾏｽｸﾊﾟﾀｰﾝｺﾝﾎﾞﾎﾞｯｸｽに値をｾｯﾄ
                        .AddItem(mtypRtclCodeList(llngCnt).lstrReticleMaskpattern)
                    End If
                Next llngCnt
                
                '@機種ｺｰﾄﾞ情報が1件の場合
                If .ListCount = 1 Then
                    '@1件目表示
                    .ListIndex = 0
                End If
                
                '@有効
                .Enabled = True
            End With
                        
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbMaskPattern_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbWplist_Disp
    '機　能：ﾚﾁｸﾙ使用装置ｺﾝﾎﾞﾎﾞｯｸｽ作成
    '引　数：llngWpCnt:装置数
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 18:37:06 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 18:37:06
    '備　考：
    Private Sub prvcmbWplist_Disp(ByVal llngWpCnt As Integer)
        
        Dim llngCnt As Integer                  'ｶｳﾝﾄ

        Try
            
            '@装置内ﾚﾁｸﾙ一覧Tab機種ｺｰﾄﾞｺﾝﾎﾞ
            With cmbWplist
                '@ﾚﾁｸﾙ使用装置ｺﾝﾎﾞﾘｽﾄ初期化
                .Clear
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol                                    'ｸﾞﾘｯﾄﾞ値取得列数
                .GroupCols = CMlngCmbGroupCols                                  '列方向のﾚｺｰﾄﾞ数
                .GroupRows = llngWpCnt                                          '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                            '"選択"文字列
                .Font = New Font(.Font.FontFamily,CMlngCmbFontSize)             'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily,CMlngCmbGridFontSize) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                    
                If llngWpCnt > 0 Then
                    For llngCnt = 0 To llngWpCnt -1
                        .AddItem (ptypWPList(llngCnt).strWpName & _
                                 vbTab & _
                                 ptypWPList(llngCnt).strWpID)                  'ID/名前
                    Next
                End If
                        
                '@機種ｺｰﾄﾞ情報が1件の場合
                If llngWpCnt = 1 Then
                    '@1件目表示
                    .ListIndex = 0
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbWplist_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListRegist_Disp
    '機　能：ﾚﾁｸﾙ登録Tabﾚﾁｸﾙ一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 11:36:47 Y.Yamagishi
    '更新日：2007/07/09 (Mon) 14:39:32 N.Kasai
    '備　考：2004/10/14 (Thu) 15:44:15 Y.Yamagishi  列幅、ｿｰﾄ順、ｶﾚﾝﾄ行の保持修正
    '　　　：2004/10/27 (Wed) 15:19:39 N.Kasai      横ｽｸﾛｰﾙ機能追加
    '　　　：2007/07/09 (Mon) 14:39:32 N.Kasai      ｸﾞﾘｯﾄﾞ共通
    Private Sub vsfRtclListRegist_Disp()

        Dim llngDoCnt       As Integer  'ｶｳﾝﾄ
        Dim llngCnt         As Integer  'ｶｳﾝﾄ
        Dim arrayIndex      As Integer  'NSYS 配列用ｶｳﾝﾀｰ

        Try
            
            With vsfRtclListRegist
            
                If mlngRtclListCnt <> 0 Then                
                '@格納ﾃﾞｰﾀがある場合
                    '@描画ﾛｯｸ
                    .Redraw = False

                    RemoveHandler vsfRtclListRegist.BeforeRowColChange,Addressof vsfRtclListRegist_BeforeRowColChange

                    '@行数設定
                    .Rows.Count = mlngRtclListCnt + 1
                    
                    .Row = 0

                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 1

                    arrayIndex = 0

                    '@ﾛｯﾄ一覧表示情報設定
                    Do While .Rows.Count > llngDoCnt
                        .SetData(llngDoCnt, CMlngvsfRtclListRegistStatus, _
                            mtypRtclList(arrayIndex).lstrReticleStatusItemName)                               '状態
                        
                        .SetData(llngDoCnt, CMlngvsfRtclListRegistRtclID, _
                            mtypRtclList(arrayIndex).lstrReticleID)                                           'ﾚﾁｸﾙID
                        
                        .SetData(llngDoCnt, CMlngvsfRtclListRegistCurrentPotition, _
                            mtypRtclList(arrayIndex).lstrCurrentPositionName)                                 '現在位置
                        
                        .SetData(llngDoCnt, CMlngvsfRtclListRegistArriveTime, _
                             Format(cdate(mtypRtclList(arrayIndex).lstrArriveTime), CPstrDateTimeYMD))               '入荷日
                        
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height  = CMlngVsfHeight
                        
                        '@ｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                        arrayIndex = arrayIndex + 1

                    Loop

                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort1.blnChgWidth = False Then
                        '@ｵｰﾄｻｲｽﾞ設定
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCol(CMlngvsfRtclListRegistStatus, 6)                '状態
                        .AutoSizeCol(CMlngvsfRtclListRegistRtclID, 6)                'ﾚﾁｸﾙID
                        .AutoSizeCol(CMlngvsfRtclListRegistCurrentPotition, 6)       '現在位置
                        .AutoSizeCol(CMlngvsfRtclListRegistArriveTime, 6)            '入荷日
                    End If
                    
                    '@書式設定
                    .Cols(CMlngvsfRtclListRegistStatus).TextAlign  = TextAlignEnum.LeftCenter                '状態(左寄せ中央揃え)
                    .Cols(CMlngvsfRtclListRegistRtclID).TextAlign  = TextAlignEnum.LeftCenter                'ﾚﾁｸﾙID(左寄せ中央揃え)
                    .Cols(CMlngvsfRtclListRegistCurrentPotition).TextAlign  = TextAlignEnum.LeftCenter       '現在位置(左寄せ中央揃え)
                    .Cols(CMlngvsfRtclListRegistArriveTime).TextAlign  = TextAlignEnum.LeftCenter            '入荷日(左寄せ中央揃え)
                    
                    '@№設定
                    For llngDoCnt = 1 To .Rows.Count - 1
                        .SetData(llngDoCnt, CMlngvsfRtclListRegistNo, llngDoCnt)
                        
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height  = CMlngVsfHeight
                        
                        '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                        .Cols(CMlngvsfRtclListRegistNo).TextAlign  = TextAlignEnum.RightCenter              '右寄せ中央揃え
                    Next llngDoCnt
                    
                    Dim llngRow As Integer = .Row
                   '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort1.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort1.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort1.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort1.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort,mtypChgSort1.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                        .Row = llngRow
                    End If
                    
                    AddHandler vsfRtclListRegist.BeforeRowColChange,Addressof vsfRtclListRegist_BeforeRowColChange
                    
                   If mtypChgSort1.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@ﾚﾁｸﾙIDが同じ場合
                            If vsfRtclListRegist.GetData(llngCnt, CMlngvsfRtclListRegistRtclID) = mtypChgSort1.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持（グリッド、保持列）
                                Call pubVsfBeforeSort(vsfRtclListRegist, CMlngvsfRtclListRegistNo)
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定（グリッド、保持列、前頁、次頁）
                                Call pubVsfAfterSort(vsfRtclListRegist, CMlngvsfRtclListRegistNo,cmdUP1 ,cmdDown1 ,False, False, False, False)
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        .TopRow = 0    '行
                        .Row = 0       'ｶﾚﾝﾄ行の移動
                    End If

                    If .Row < 1 Then
                        .Row = 0
                        .TopRow = 0
                        .LeftCol = 0
                    End If

                    '@描画ﾛｯｸ解除
                    .Redraw = True

                    '@ﾛｯｸ解除
                    .Enabled = True
                    
                    '@有効の場合
                    If .Enabled = True Then
                        '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfRtclListRegist)
                    End If
                 Else
                    .Enabled = False
                End If

                '@該当件数
                lblLotCntRegist.Text = mlngRtclListCnt
            
                '@現在日時表示
                lblNowDateRegist.Text = Format(Now, CPstrDateFormat)
                
                '@新規登録ﾚﾁｸﾙID有効
                txtNewRtclID.Enabled = True
                '@新規登録ﾚﾁｸﾙID有効
                txtNewRtclID2.Enabled = True
                '@入荷日有効
                dtpArriveTime.Enabled = True
            
                '@左右ｽｸﾛｰﾙ制御の記述
                '@ｶﾚﾝﾄ列初期化
                .Col = .Cols.Fixed
                .LeftCol = .Cols.Fixed
             
        '@↓2007/07/09 (Mon) 14:39:24 N.Kasai **************************************************
        '        '@全列数の幅取得(非表示項目は含めない)
        '        For llngDoCnt = 0 To .Cols - 1
        '            If .ColHidden(llngDoCnt) <> True Then
        '                llngWidthAll = llngWidthAll + .ColWidth(llngDoCnt)
        '            End If
        '        Next llngDoCnt
        '        '@ｸﾞﾘｯﾄﾞ幅と比較して横ｽｸﾛｰﾙﾎﾞﾀﾝを活性化するか判断
        '        If .Width - llngWidthAll >= 0 Then
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=2:非活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOffFlag
        '
        '            '@右ｽｸﾛｰﾙ非活性化
        '            cmdRight1.Enabled = False
        '        Else
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=1:活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOnFlag
        '
        '            '@右ｽｸﾛｰﾙ活性化
        '            cmdRight1.Enabled = True
        '        End If

                '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                Call pubCmdLREnable_Set(vsfRtclListRegist, cmdLeft1, cmdRight1)
                
        '@↑2007/07/09 (Mon) 14:39:24 N.Kasai **************************************************


                '@前ﾍﾟｰｼﾞ、次ﾍﾟｰｼﾞ、ｽｸﾛｰﾙﾗﾍﾞﾙ表示設定
                If .Rows.Count > 1 Then
                    cmdUP1.Enabled = True
                    cmdDown1.Enabled = True

                    '@ｸﾞﾘｯﾄﾞﾎﾞﾀﾝ制御、保持値ｸﾘｱ
                    Call pubVsfDisp(vsfRtclListRegist, cmdUP1, cmdDown1)
                Else
                    cmdUP1.Enabled = False
                    cmdDown1.Enabled = False
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListRegist_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListMente_Disp
    '機　能：ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTabﾚﾁｸﾙ一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 11:36:47 Y.Yamagishi
    '更新日：2007/07/09 (Mon) 14:42:01 N.Kasai
    '備　考：2004/10/14 (Thu) 15:43:23 Y.Yamagishi  列幅、ｿｰﾄ順、ｶﾚﾝﾄ行の保持修正
    '　　　：2004/10/27 (Wed) 15:15:34 N.Kasai      横ｽｸﾛｰﾙ機能追加
    '　　　：2005/01/21 (Fri) 09:19:03 N.Kasai      ｷｬﾘｱ状態を判定して搬送中の場合は搬送先を表示　不具合№327
    '　　　：2005/02/09 (Wed) 08:44:19 N.Kasai      ｷｬﾘｱ状態入庫、出庫中の場合は搬送先を表示　不具合№514
    '　　　：2005/05/31 (Tue) 12:49:39 N.Kasai      最終更新日時ﾌｫｰﾏｯﾄ処理追加
    '　　　：2007/07/09 (Mon) 14:42:01 N.Kasai      ｸﾞﾘｯﾄﾞ共通
    Private Sub vsfRtclListMente_Disp()

        Dim llngDoCnt           As Integer  'ｶｳﾝﾄ
        Dim llngCnt             As Integer  'ｶｳﾝﾄ
        Dim arrayIndex          As Integer  'NSYS 配列用ｶｳﾝﾀｰ

        Try
                       
            With vsfRtclListMente
                If mlngRtclListCnt <> 0 Then
                '@格納ﾃﾞｰﾀがある場合
                    '@描画ﾛｯｸ
                    .Redraw = false
                    
                    RemoveHandler vsfRtclListMente.BeforeRowColChange,Addressof vsfRtclListMente_BeforeRowColChange
                    RemoveHandler vsfRtclListMente.EnterCell,Addressof vsfRtclListMente_EnterCell

                    '@行数設定
                    .Rows.Count = mlngRtclListCnt + 1

                    .Row = 0

                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 1
                    
                    '@ﾛｯﾄ一覧表示情報設定
                    
                    Do While .Rows.Count > llngDoCnt
                    
                        .SetData(llngDoCnt, CMlngvsfRtclListMenteStatus, _
                            mtypRtclList(arrayIndex).lstrReticleStatusItemName)                               '状態
                        
                        .SetData(llngDoCnt, CMlngvsfRtclListMenteRtclID, _
                            mtypRtclList(arrayIndex).lstrReticleID)                                           'ﾚﾁｸﾙID
                        
                        .SetData(llngDoCnt, CMlngvsfRtclListMenteSMIF, _
                            mtypRtclList(arrayIndex).lstrSmifID)                                              'SMIF
                            
                        '@ｷｬﾘｱ状態を判定
                        Select Case mtypRtclList(arrayIndex).strCarrierStatID
                            '@ｷｬﾘｱ状態(搬送中、出庫中、入庫中)
                            Case CPstrCarrierStatMove, CPstrCarrierStatStkout, CPstrCarrierStatStkin
                                '@搬送中の場合
                                .SetData(llngDoCnt, CMlngvsfRtclListMenteCurrentPotition, _
                                    CMstrArrow & CPstrSpace & mtypRtclList(arrayIndex).strDestName)               '搬送先
                                '@搬送中の場合位置情報をｸﾘｱしないと出庫指示ﾎﾞﾀﾝの制御判定に不備あり
                                .SetData(llngDoCnt, CMlngvsfRtclListMenteCurrentPotitionID, _
                                    vbNullString)                                                                '位置情報ID(非表示)
                                
                            Case Else
                                '@搬送中ではない場合
                                .SetData(llngDoCnt, CMlngvsfRtclListMenteCurrentPotition, _
                                    mtypRtclList(arrayIndex).lstrCurrentPositionName)                             '現在位置
                                
                                .SetData(llngDoCnt, CMlngvsfRtclListMenteCurrentPotitionID, _
                                    mtypRtclList(arrayIndex).lstrCurrentPositionID)                               '位置情報ID(非表示)
                                
                        End Select
                       
                        .SetData(llngDoCnt, CMlngvsfRtclListMenteArriveTime, _
                             Format$(Cdate(mtypRtclList(arrayIndex).lstrArriveTime), CPstrDateTimeYMD))              '入荷日
                             
                        .SetData(llngDoCnt, CMlngvsfRtclListMenteEditTime, _
                                prvstrTimeFormat_Set(mtypRtclList(arrayIndex).lstrEditTime))                  '最終更新日

                        .SetData(llngDoCnt, CMlngvsfRtclListMenteWpInFlag, _
                            mtypRtclList(arrayIndex).lstrWPInFlag)                                            '装置内ﾌﾗｸﾞ(非表示)
                        
                        .SetData(llngDoCnt, CMlngvsfRtclListMenteStatusID, _
                            mtypRtclList(arrayIndex).lstrReticleStatusItemID)                                 '状態ID(非表示)
                            
                        .SetData(llngDoCnt, CMlngvsfRtclListMenteReasonCode, _
                            mtypRtclList(arrayIndex).lstrReasonCode)                                          'ｴﾗｰ理由(非表示)
                        
                        .SetData(llngDoCnt, CMlngvsfRtclListMenteReasonComments, _
                            mtypRtclList(arrayIndex).lstrReasonComment)                                       'ｴﾗｰｺﾒﾝﾄ(非表示)

                        .SetData(llngDoCnt, CMlngvsfRtclListMenteEditTimeWk, _
                            mtypRtclList(arrayIndex).lstrEditTime)                                            '最終更新日時(非表示)
                            
                        .SetData(llngDoCnt, CMlngvsfRtclListMenteStockerInFlag, _
                            mtypRtclList(arrayIndex).lstrStockerInFlag)                                       'ｽﾄｯｶｰ内ﾌﾗｸﾞ(非表示)
                     
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height  = CMlngVsfHeight
                        
                        '@ｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                        arrayIndex = arrayIndex+1
                    Loop

                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort2.blnChgWidth = False Then
                        '@ｵｰﾄｻｲｽﾞ設定
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCol(CMlngvsfRtclListMenteStatus, 6)                '状態
                        .AutoSizeCol(CMlngvsfRtclListMenteRtclID, 6)                'ﾚﾁｸﾙID
                        .AutoSizeCol(CMlngvsfRtclListMenteSMIF, 6)                  'SMIFID
                        .AutoSizeCol(CMlngvsfRtclListMenteCurrentPotition, 6)       '現在位置
                        .AutoSizeCol(CMlngvsfRtclListMenteArriveTime, 6)            '入荷日
                        .AutoSizeCol(CMlngvsfRtclListMenteEditTime, 6)              '最終更新日
                    End If
                    
                    '@書式設定
                    .Cols(CMlngvsfRtclListMenteStatus).TextAlign  = TextAlignEnum.LeftCenter                    '状態(左寄せ中央揃え)
                    .Cols(CMlngvsfRtclListMenteRtclID).TextAlign  = TextAlignEnum.LeftCenter                    'ﾚﾁｸﾙID(左寄せ中央揃え)
                    .Cols(CMlngvsfRtclListMenteRtclID).TextAlign  = TextAlignEnum.LeftCenter                    'SMIFID(左寄せ中央揃え)
                    .Cols(CMlngvsfRtclListMenteCurrentPotition).TextAlign  = TextAlignEnum.LeftCenter           '現在位置(左寄せ中央揃え)
                    .Cols(CMlngvsfRtclListMenteArriveTime).TextAlign  = TextAlignEnum.LeftCenter                '入荷日(左寄せ中央揃え)
                    .Cols(CMlngvsfRtclListMenteEditTime).TextAlign  = TextAlignEnum.LeftCenter                  '最終更新日(左寄せ中央揃え)
                    
                    '@№設定
                    For llngDoCnt = 1 To .Rows.Count - 1
                        .SetData(llngDoCnt, CMlngvsfRtclListMenteNo, llngDoCnt)
                        
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height  = CMlngVsfHeight
                        
                        '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                        .Cols(CMlngvsfRtclListMenteNo).TextAlign  = TextAlignEnum.RightCenter                    '右寄せ中央揃え
                    Next llngDoCnt
                    
                   '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort2.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort2.lngCnt-1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort2.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort2.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort,mtypChgSort2.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    AddHandler vsfRtclListMente.EnterCell,Addressof vsfRtclListMente_EnterCell
                    AddHandler vsfRtclListMente.BeforeRowColChange,Addressof vsfRtclListMente_BeforeRowColChange

                    '@ｿｰﾄ検索用ｷｰ(ﾚﾁｸﾙID)がある場合
                    If mtypChgSort2.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@ﾚﾁｸﾙIDが同じ場合
                            If vsfRtclListMente.GetData(llngCnt, CMlngvsfRtclListRegistRtclID) = mtypChgSort2.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持(グリッド、保持列)
                                Call pubVsfBeforeSort(vsfRtclListMente, CMlngvsfRtclListMenteNo)
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(グリッド、保持列、前頁、次頁)
                                Call pubVsfAfterSort(vsfRtclListMente, CMlngvsfRtclListMenteNo,cmdUP1 ,cmdDown1 ,False, False, False, False)
                                Exit For
                            End If
                        Next llngCnt
                     Else
                        .TopRow = 0    '行
                        .Row = 0       'ｶﾚﾝﾄ行の移動
                    End If

                    If .Row < 1 Then
                        .Row = 0
                        .TopRow = 0
                        .LeftCol = 0
                    End If

                    '@描画ﾛｯｸ解除
                    .Redraw = True

                    '@ﾛｯｸ解除
                    .Enabled = True
                                
                    '@有効の場合
                    If .Enabled = True Then
                        '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfRtclListMente)
                    End If
                 Else
                    .Enabled = False
                End If

                '@該当件数
                lblLotCntMente.Text = mlngRtclListCnt
            
                '@現在日時表示
                lblNowDateMente.Text = Format(Now, CPstrDateFormat)
            
                '@左右ｽｸﾛｰﾙ制御の記述
                '@ｶﾚﾝﾄ列初期化
                .Col = .Cols.Fixed
                .LeftCol = .Cols.Fixed

        '@↓2007/07/09 (Mon) 14:41:55 N.Kasai **************************************************
        '        '@全列数の幅取得(非表示項目は含めない)
        '        For llngDoCnt = 0 To .Cols - 1
        '            If .ColHidden(llngDoCnt) <> True Then
        '                llngWidthAll = llngWidthAll + .ColWidth(llngDoCnt)
        '            End If
        '        Next llngDoCnt
        '        '@ｸﾞﾘｯﾄﾞ幅と比較して横ｽｸﾛｰﾙﾎﾞﾀﾝを活性化するか判断
        '        If .Width - llngWidthAll >= 0 Then
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=2:非活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOffFlag
        '
        '            '@右ｽｸﾛｰﾙ非活性化
        '            cmdRight2.Enabled = False
        '        Else
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=1:活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOnFlag
        '
        '            '@右ｽｸﾛｰﾙ活性化
        '            cmdRight2.Enabled = True
        '        End If

                '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                Call pubCmdLREnable_Set(vsfRtclListMente, cmdLeft2, cmdRight2)
        '@↑2007/07/09 (Mon) 14:41:55 N.Kasai **************************************************

                '@前ﾍﾟｰｼﾞ、次ﾍﾟｰｼﾞ、ｽｸﾛｰﾙﾗﾍﾞﾙ表示設定
                If .Rows.Count > 1 Then
                    cmdUP2.Enabled = True
                    cmdDown2.Enabled = True

                    '@ｸﾞﾘｯﾄﾞﾎﾞﾀﾝ制御、保持値ｸﾘｱ
                    Call pubVsfDisp(vsfRtclListMente, cmdUP2, cmdDown2)
                Else
                    cmdUP2.Enabled = False
                    cmdDown2.Enabled = False
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListMente_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRtclListWpIn_Disp
    '機　能：装置内ﾚﾁｸﾙ一覧Tabﾚﾁｸﾙ一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 19:46:06 Y.Yamagishi
    '更新日：2007/07/09 (Mon) 14:43:22 N.Kasai
    '備　考：2004/10/14 (Thu) 15:45:13 Y.Yamagishi  列幅、ｿｰﾄ順、ｶﾚﾝﾄ行の保持修正
    '　　　：2004/10/27 (Wed) 15:17:51 N.Kasai      横ｽｸﾛｰﾙ機能追加
    '　　　：2005/05/31 (Tue) 12:52:21 N.Kasai      最終更新日時ﾌｫｰﾏﾄ処理追加
    '　　　：2007/07/09 (Mon) 14:43:22 N.Kasai      ｸﾞﾘｯﾄﾞ共通
    Private Sub vsfRtclListWpIn_Disp()

        Dim llngDoCnt               As Integer  'ｶｳﾝﾄ
        Dim llngCnt2                As Integer  'ｶｳﾝﾄ
        Dim arrayIndex              As Integer  'NSYS 配列用ｶｳﾝﾀｰ

        Try
           
            With vsfRtclListWpIn
                If mlngRtclListCnt <> 0 Then
                '@格納ﾃﾞｰﾀがある場合
                    '@描画ﾛｯｸ
                    .Redraw = False
                    
                    RemoveHandler vsfRtclListWpIn.BeforeRowColChange,AddressOf vsfRtclListWpIn_BeforeRowColChange

                    '@行数設定
                    .Rows.Count = mlngRtclListCnt + 1

                    .Row = 0

                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 1
                    
                    '@ﾛｯﾄ一覧表示情報設定
                    Do While .Rows.Count > llngDoCnt

                        .SetData(llngDoCnt, CMlngvsfRtclListWpInWPID, _
                            mtypRtclList(arrayIndex).lstrCurrentPositionName)                             '装置

                        .SetData(llngDoCnt, CMlngvsfRtclListWpInStatus, _
                            mtypRtclList(arrayIndex).lstrReticleStatusItemName)                           '状態

                        .SetData(llngDoCnt, CMlngvsfRtclListWpInRtclID, _
                            mtypRtclList(arrayIndex).lstrReticleID)                                       'ﾚﾁｸﾙID

                        .SetData(llngDoCnt, CMlngvsfRtclListWpInEditTime, _
                                prvstrTimeFormat_Set(mtypRtclList(arrayIndex).lstrEditTime))              '最終更新日

                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height  = CMlngVsfHeight

                        '@ｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                        arrayIndex = arrayIndex+1
                    Loop
                    
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort3.blnChgWidth = False Then
                        '@ｵｰﾄｻｲｽﾞ設定
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCol(CMlngvsfRtclListWpInWPID, 6)                '装置
                        .AutoSizeCol(CMlngvsfRtclListWpInStatus, 6)              '状態
                        .AutoSizeCol(CMlngvsfRtclListWpInRtclID, 6)              'ﾚﾁｸﾙID
                        .AutoSizeCol(CMlngvsfRtclListWpInEditTime, 6)            '最終更新日
                    End If
                    
                    '@書式設定
                    .Cols(CMlngvsfRtclListWpInWPID).TextAlign = TextAlignEnum.LeftCenter                       '装置(左寄せ中央揃え)
                    .Cols(CMlngvsfRtclListWpInStatus).TextAlign = TextAlignEnum.LeftCenter                     '状態(左寄せ中央揃え)
                    .Cols(CMlngvsfRtclListWpInRtclID).TextAlign = TextAlignEnum.LeftCenter                     'ﾚﾁｸﾙID(左寄せ中央揃え)
                    .Cols(CMlngvsfRtclListWpInEditTime).TextAlign = TextAlignEnum.LeftCenter                   '最終更新日(左寄せ中央揃え)
                    
                    '@№設定
                    For llngDoCnt = 1 To .Rows.Count - 1
                        .SetData(llngDoCnt, CMlngvsfRtclListWpInNo, llngDoCnt)
                        
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height  = CMlngVsfHeight
                        
                        '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                        .Cols(CMlngvsfRtclListWpInNo).TextAlign  = TextAlignEnum.RightCenter                   '右寄せ中央揃え
                    Next llngDoCnt
                    
                   '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort3.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt2 = 0 To mtypChgSort3.lngCnt-1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort3.typChgSortList(llngCnt2).lngCol).Sort = mtypChgSort3.typChgSortList(llngCnt2).lngOrder
                            .Sort(SortFlags.UseColSort,mtypChgSort3.typChgSortList(llngCnt2).lngCol)
                        Next llngCnt2
                    End If
                    
                    AddHandler vsfRtclListWpIn.BeforeRowColChange,AddressOf vsfRtclListWpIn_BeforeRowColChange

                    '@ｿｰﾄ検索用ｷｰ(ﾚﾁｸﾙID)がある場合
                    If mtypChgSort3.strKey <> vbNullString Then
                        For llngCnt2 = .Rows.Fixed To .Rows.Count - 1
                            '@ﾚﾁｸﾙIDが同じ場合
                            If vsfRtclListWpIn.GetData(llngCnt2, CMlngvsfRtclListWpInRtclID) = mtypChgSort3.strKey Then
                                .Row = llngCnt2
                                '@ｶﾚﾝﾄ行の保持(グリッド、保持列)
                                Call pubVsfBeforeSort(vsfRtclListWpIn, CMlngvsfRtclListWpInNo)
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(グリッド、保持列、前頁、次頁)
                                Call pubVsfAfterSort(vsfRtclListWpIn, CMlngvsfRtclListWpInNo,cmdUP3 ,cmdDown3 ,False, False, False, False)
                                Exit For
                            End If
                        Next llngCnt2
                    Else
                        .TopRow = 0    '行
                        .Row = 0       'ｶﾚﾝﾄ行の移動
                    End If

                    If .Row < 1 Then
                        .Row = 0
                        .TopRow = 0
                        .LeftCol = 0
                    End If

                    '@描画ﾛｯｸ解除
                    .Redraw = True

                    '@ﾛｯｸ解除
                    .Enabled = True
                                
                    '@有効の場合
                    If .Enabled = True Then
                        '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfRtclListWpIn)
                    End If
                Else
                    .Enabled = False
                End If

                '@該当件数
                lblLotCntWpIn.Text = mlngRtclListCnt
            
                '@現在日時表示
                lblNowDateWpIn.Text = Format(Now, CPstrDateFormat)
                
                '@左右ｽｸﾛｰﾙ制御の記述
                '@ｶﾚﾝﾄ列初期化
                .Col = .Cols.Fixed
                .LeftCol = .Cols.Fixed

        '@↓2007/07/09 (Mon) 14:43:17 N.Kasai **************************************************
        '        '@全列数の幅取得(非表示項目は含めない)
        '        For llngDoCnt = 0 To .Cols - 1
        '            If .ColHidden(llngDoCnt) <> True Then
        '                llngWidthAll = llngWidthAll + .ColWidth(llngDoCnt)
        '            End If
        '        Next llngDoCnt
        '        '@ｸﾞﾘｯﾄﾞ幅と比較して横ｽｸﾛｰﾙﾎﾞﾀﾝを活性化するか判断
        '        If .Width - llngWidthAll >= 0 Then
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=2:非活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOffFlag
        '
        '            '@右ｽｸﾛｰﾙ非活性化
        '            cmdRight3.Enabled = False
        '        Else
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=1:活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOnFlag
        '
        '            '@右ｽｸﾛｰﾙ活性化
        '            cmdRight3.Enabled = True
        '        End If

                '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                Call pubCmdLREnable_Set(vsfRtclListWpIn, cmdLeft3, cmdRight3)
        '@↑2007/07/09 (Mon) 14:43:17 N.Kasai **************************************************


                '@前ﾍﾟｰｼﾞ、次ﾍﾟｰｼﾞ、ｽｸﾛｰﾙﾗﾍﾞﾙ表示設定
                If .Rows.Count > 1 Then
                    cmdUP3.Enabled = True
                    cmdDown3.Enabled = True
            
                    '@ｸﾞﾘｯﾄﾞﾎﾞﾀﾝ制御、保持値ｸﾘｱ
                    Call pubVsfDisp(vsfRtclListWpIn, cmdUP3, cmdDown3)
                Else
                    cmdUP3.Enabled = False
                    cmdDown3.Enabled = False
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRtclListWpIn_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvRegist_Chk
    '機　能：確定ﾎﾞﾀﾝの活性化ﾁｪｯｸ･制御
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 15:02:10 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 15:02:10
    '備　考：
    Private Sub prvRegist_Chk()

        Dim lblnFlg     As Boolean      'ﾌﾗｸﾞ処理(True:確定ﾎﾞﾀﾝ活性化,False:確定ﾎﾞﾀﾝ非活性化)

        Try
            
            '@初期化
            lblnFlg = True

            '@ﾚﾁｸﾙIDﾁｪｯｸ
            If txtNewRtclID.Text = vbNullString Then
                lblnFlg = False
            End If
            
            '@ﾚﾁｸﾙIDﾁｪｯｸ
            If txtNewRtclID2.Text = vbNullString Then
                lblnFlg = False
            End If
            
            '@入荷日ﾁｪｯｸ
            If dtpArriveTime.Value = CPstrNullDate Then
                lblnFlg = False
            End If

            '@入荷日ﾁｪｯｸ
            If IsDate(dtpArriveTime.Value) = True Then
                '@日付の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(dtpArriveTime.Value) = False Then
                    lblnFlg = False
                End If
            Else
                lblnFlg = False
            End If
            
            '@最終結果判定
            If lblnFlg = True Then
                cmdRegist.Enabled = True
            Else
                cmdRegist.Enabled = False
            End If

            Exit Sub

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
    End Sub

    '関数名：prvRtclIDCopy_Chk
    '機　能：ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝの活性化ﾁｪｯｸ･制御
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 16:01:56 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 16:01:56
    '備　考：
    Private Sub prvRtclIDCopy_Chk()

        Try

            '@ﾘｽﾄのﾍｯﾀﾞｰ以外が選択されている場合
            If vsfRtclListRegist.Row <> 0 Then
                '@ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ有効
                cmdRtclIDCopy.Enabled = True
            Else
                '@ﾚﾁｸﾙIDｺﾋﾟｰﾎﾞﾀﾝ無効
                cmdRtclIDCopy.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvRtclIDCopy_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnRegist_Chk
    '機　能：ﾚﾁｸﾙ登録Tabﾚﾁｸﾙ登録時ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：成功、False：失敗
    '作成日：2004/08/25 (Wed) 14:41:27 Y.Yamagishi
    '更新日：2004/09/22 (Wed) 20:00:27 Y.Yamagishi
    '備　考：2004/09/22 (Wed) 20:00:27 Y.Yamagishi ﾚﾁｸﾙ重複ﾁｪｯｸ追加(不具合改善№841)
    Private Function prvblnRegist_Chk() As Boolean

        Dim llngCnt                 As Integer          'ﾙｰﾌﾟｶｳﾝﾀ

        Try
            
            '@初期化
            prvblnRegist_Chk = False
            
            '@ﾚﾁｸﾙIDの入力ﾁｪｯｸ
            If txtNewRtclID.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001V)
                
               '@"ﾚﾁｸﾙIDが設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Call pubSetFocus(txtNewRtclID)
                
                Exit Function
            End If
            
            '@ﾚﾁｸﾙIDの入力ﾁｪｯｸ
            If txtNewRtclID2.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001V)
                
               '@"ﾚﾁｸﾙIDが設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Call pubSetFocus(txtNewRtclID2)
                
                Exit Function
            End If
            
            '@ﾚﾁｸﾙIDの重複ﾁｪｯｸ
            If txtNewRtclID.Text <> vbNullString And txtNewRtclID2.Text <> vbNullString Then
                With vsfRtclListRegist
                    For llngCnt = 1 To .Rows.Count - 1
                        If txtNewRtclID.Text & CMstrHyphen & txtNewRtclID2.Text _
                            = .GetData(llngCnt, CMlngvsfRtclListRegistRtclID) Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003G)
                            
                            '@"ﾚﾁｸﾙIDが重複しています。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                             
                            Call pubSetFocus(txtNewRtclID2)
                             
                            Exit Function
                        End If
                    Next
                End With
            End If
            
            '@入荷日ﾁｪｯｸ
            If dtpArriveTime.Value = CPstrNullDate Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001W)
                
                '@"入荷日の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@入荷日にｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(dtpArriveTime)
                
                Exit Function
            Else
                '@日付ﾁｪｯｸ
                If IsDate(dtpArriveTime.Value) = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001W)
                    
                    '@"入荷日の設定が正しくありません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@入荷日にｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(dtpArriveTime)
                    
                    Exit Function
                End If
                '@未来の日付ﾁｪｯｸ
                If dtpArriveTime.Value > Format$(Now, CPstrDateTimeYMD) Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                    
                    '@"未来の日付は指定できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@入荷日にﾌｫｰｶｽｾｯﾄ
                    If dtpArriveTime.Enabled = True Then
                        Call pubSetFocus(dtpArriveTime)
                    End If
                    
                    Exit Function
                End If
            End If
                
            '@入力OK
            prvblnRegist_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '@↓2012/01/24 (Tue) 12:07:16 T.Oide **************************************************共通関数pubGridFocus_Setに変更
    '@'関数名：prvFocus_Set
    '@'機　能：ﾌｫｰｶｽの戻り位置を設定
    '@'引　数：lobjControl: VSFlexGridオブジェクト
    '@'　　　：lstrKeyID：KeyID
    '@'　　　：llngKeyColNo：KeyIDのCol位置
    '@'　　　：llngTopRow：先頭行
    '@'戻り値：なし
    '@'作成日：2004/08/25 (Wed) 20:40:06 Y.Yamagishi
    '@'更新日：2004/08/25 (Wed) 20:40:06
    '@'備　考：ﾚﾁｸﾙNoを検索してHitした場合は該当行にﾌｫｰｶｽｾｯﾄする。ない場合はｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
    '@Private Sub prvFocus_Set(ByVal lobjControl As VSFlexGrid, _
    '@                         ByVal lstrKeyID As String, _
    '@                         llngKeyColNo As Long, ByVal llngTopRow)
    '@
    '@    Dim llngRowCnt     As Long         'ｶｳﾝﾄ
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    With lobjControl
    '@        '@確定ﾎﾞﾀﾝ押下前のﾌｫｰｶｽ位置を検索
    '@        For llngRowCnt = 0 To .Rows - 1
    '@            '@ﾛｯﾄNo検索
    '@            If .Cell(flexcpText, llngRowCnt, llngKeyColNo) = lstrKeyID Then
    '@                '@行の選択範囲を設定
    '@                .Row = llngRowCnt
    '@
    '@                '@選択行を表示
    '@                .ShowCell llngRowCnt, llngKeyColNo
    '@                Exit Sub
    '@            End If
    '@        Next llngRowCnt
    '@
    '@        '@ﾌｫｰｶｽｾｯﾄ
    '@        '@明細行が1件もない場合ﾌｫｰｶｽの戻り位置を制御
    '@        If .Enabled = False Then
    '@            Call pubSetFocus(cmdClose)
    '@        Else
    '@            Call pubSetFocus(lobjControl)
    '@        End If
    '@    End With
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "prvFocus_Set"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2012/01/24 (Tue) 12:07:16 T.Oide **************************************************

    '関数名：prvChgStatBtn_Chk
    '機　能：状態変更ﾎﾞﾀﾝ有効無効ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 16:18:24 Y.Yamagishi
    '更新日：2005/02/09 (Wed) 14:28:44 N.Kasai
    '備　考：2004/09/30 (Thu) 09:09:34 Y.Yamagishi 「返却」ﾎﾞﾀﾝをｽﾄｯｶｰ内のときは押せないように変更(不具合改善№852)
    '                                             「ﾚﾁｸﾙ状態変更」ﾎﾞﾀﾝを無効の場合でも押せるように変更(不具合改善№852)
    '                                             「ﾚﾁｸﾙ状態変更」ﾎﾞﾀﾝを無効の場合は押せないように変更(不具合改善№852)
    '　　　：2004/11/30 (Tue) 13:38:46 N.Kasai      ｺﾞﾐ検OK/NG、ｴﾗｰ設定/解除ﾎﾞﾀﾝをそれぞれ統一
    Private Sub prvChgStatBtn_Chk()
        
        Dim llngCnt         As Integer  '汎用ｶｳﾝﾀ

        Try
            
            With vsfRtclListMente
                '@「返却」ﾎﾞﾀﾝ
                '@ｽﾃｰﾀｽが"要検査"又はｽﾃｰﾀｽが"ｴﾗｰ"で,装置内ﾌﾗｸﾞが1：装置外で,ｽﾄｯｶ-内ﾌﾗｸﾞが1：ｽﾄｯｶｰ外の時
                If (.GetData(.Row, CMlngvsfRtclListMenteStatusID) = CMstrStatus1 Or _
                   .GetData(.Row, CMlngvsfRtclListMenteStatusID) = CMstrStatus5) And _
                    .GetData(.Row, CMlngvsfRtclListMenteWpInFlag) = CMstrInFlag1 And _
                    .GetData(.Row, CMlngvsfRtclListMenteStockerInFlag) = CMstrInFlag1 Then
                    
                    '@「返却」ﾎﾞﾀﾝ有効
                    cmdPut.Enabled = True
                Else
                    '@「返却」ﾎﾞﾀﾝ無効
                    cmdPut.Enabled = False
                End If
                
                '@「再入荷」ﾎﾞﾀﾝ
                '@ｽﾃｰﾀｽが"返却中"で装置内ﾌﾗｸﾞが1：装置外の時
                If .GetData(.Row, CMlngvsfRtclListMenteStatusID) = CMstrStatus4 And _
                   .GetData(.Row, CMlngvsfRtclListMenteWpInFlag) = CMstrInFlag1 Then
                   
                    '@「再入荷」ﾎﾞﾀﾝ有効
                    cmdArrive.Enabled = True
                Else
                    '@「再入荷」ﾎﾞﾀﾝ無効
                    cmdArrive.Enabled = False
                End If
                
                '@「ﾚﾁｸﾙ削除」ﾎﾞﾀﾝ
                '@ｽﾃｰﾀｽが"無効"以外で装置内ﾌﾗｸﾞが1：装置外の時
                If .GetData(.Row, CMlngvsfRtclListMenteStatusID) <> CMstrStatus3 And _
                   .GetData(.Row, CMlngvsfRtclListMenteWpInFlag) = CMstrInFlag1 Then
                   
                    '@「ﾚﾁｸﾙ削除」ﾎﾞﾀﾝ有効
                    cmdDel.Enabled = True
                Else
                    '@「ﾚﾁｸﾙ削除」ﾎﾞﾀﾝ無効
                    cmdDel.Enabled = False
                End If
                
                '@「ﾚﾁｸﾙ情報変更」ﾎﾞﾀﾝ
                '@ｽﾃｰﾀｽが"有効"又は"ｴﾗｰ"の時
                If (.GetData(.Row, CMlngvsfRtclListMenteStatusID) = CMstrStatus2 Or _
                   .GetData(.Row, CMlngvsfRtclListMenteStatusID) = CMstrStatus5) Then
                   
                    '@「ﾚﾁｸﾙ情報変更」ﾎﾞﾀﾝ有効
                    cmdRtclInfChange.Enabled = True
                Else
                    '@「ﾚﾁｸﾙ情報変更」ﾎﾞﾀﾝ無効
                    cmdRtclInfChange.Enabled = False
                End If

                '@「ｺﾞﾐ検」ﾎﾞﾀﾝ
                '@ｽﾃｰﾀｽが"有効"で装置内ﾌﾗｸﾞが1：装置外の時
                If .GetData(.Row, CMlngvsfRtclListMenteStatusID) = CMstrStatus2 And _
                    .GetData(.Row, CMlngvsfRtclListMenteWpInFlag) = CMstrInFlag1 Then
                    
                    '@「ｺﾞﾐ検NG」ﾎﾞﾀﾝ有効
                    cmdGarbage.Text = CMstrGarbageNg
                    cmdGarbage.Enabled = True
                End If
                
                '@「ｺﾞﾐ検OK」ﾎﾞﾀﾝ
                '@ｽﾃｰﾀｽが"要検査"の時
                If .GetData(.Row, CMlngvsfRtclListMenteStatusID) = CMstrStatus1 Then
                
                    '@「ｺﾞﾐ検OK」ﾎﾞﾀﾝ有効
                    cmdGarbage.Text = CMstrGarbageOk
                    cmdGarbage.Enabled = True
                    
                    '@ｴﾗｰ設定ﾎﾞﾀﾝ使用不可
                    cmdErrSet.Text = CMstrErrSet
                    cmdErrSet.Enabled = False
                End If
                
                '@「ｴﾗｰ設定」ﾎﾞﾀﾝ
                '@ｽﾃｰﾀｽが"有効"の時
                If .GetData(.Row, CMlngvsfRtclListMenteStatusID) = CMstrStatus2 Then
                
                    '@「ｴﾗｰ設定」ﾎﾞﾀﾝ有効
                    cmdErrSet.Text = CMstrErrSet
                    cmdErrSet.Enabled = True
                End If
                
                '@「ｴﾗｰ解除」ﾎﾞﾀﾝ
                '@ｽﾃｰﾀｽが"ｴﾗｰ"の時
                If .GetData(.Row, CMlngvsfRtclListMenteStatusID) = CMstrStatus5 Then
                
                    '@「ｴﾗｰ解除」ﾎﾞﾀﾝ有効
                    cmdErrSet.Text = CMstrErrRelese
                    cmdErrSet.Enabled = True
                    
                    '@ｺﾞﾐ検ﾎﾞﾀﾝ使用不可
                    cmdGarbage.Text = CMstrGarbage
                    cmdGarbage.Enabled = False
                End If
                
                '@「ｴﾗｰ設定/解除、ｺﾞﾐ検」ﾎﾞﾀﾝ
                '@ｽﾃｰﾀｽが"無効"or "返却中"の時
                If .GetData(.Row, CMlngvsfRtclListMenteStatusID) = CMstrStatus3 Or _
                   .GetData(.Row, CMlngvsfRtclListMenteStatusID) = CMstrStatus4 Then
                   
                    '@「ｴﾗｰ解除」ﾎﾞﾀﾝ無効
                    cmdErrSet.Text = CMstrErrSet
                    cmdErrSet.Enabled = False
                    
                    '@「ｺﾞﾐ検」ﾎﾞﾀﾝ無効
                    cmdGarbage.Text = CMstrGarbage
                    cmdGarbage.Enabled = False
                End If
                        
                '@現在位置IDが"NULL"ではないか
                If .GetData(.Row, CMlngvsfRtclListMenteCurrentPotitionID) <> vbNullString Then
                    '@SMIFが"NULL"ではないか
                    If .GetData(.Row, CMlngvsfRtclListMenteSMIF) <> vbNullString Then
                        For llngCnt = 0 To mlngStockerListCnt-1
                            '@ｽﾄｯｶｰIDと選択現在位置IDが同じか
                            If .GetData(.Row, CMlngvsfRtclListMenteCurrentPotitionID) _
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
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvChgStatBtn_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvRtclChgStat_Set
    '機　能：ﾚﾁｸﾙ状態変更処理
    '引　数：lstrBtnName：押下されたｺﾏﾝﾄﾞﾎﾞﾀﾝ(「返却」=1,「再入荷」=2,「ｺﾞﾐ検NG」=3,「ｺﾞﾐ検OK」=4)
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 17:04:42 Y.Yamagishi
    '更新日：2012/01/24 (Tue) 13:39:14 T.Oide
    '備　考：
    Private Sub prvRtclChgStat_Set(ByVal lstrBtnName As String)

        Dim lblnAns                 As Boolean          'ﾚﾁｸﾙ登録結果
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim lstrEventName           As String           'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        Dim ltypRtclChgState        As RtclChgState     'ﾚﾁｸﾙ状態変更情報格納要構造体
        Dim lstrKeyID               As String           'ﾚﾁｸﾙIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow              As Integer          '現在行を格納

        Try
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfRtclListMente
                '@ﾌｫｰｶｽを取得しているﾚﾁｸﾙIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfRtclListMenteRtclID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "prvRtclChgStat_Set"
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾚﾁｸﾙ状態変更情報格納要構造体に値をｾｯﾄする
            With ltypRtclChgState
                '@ｼｽﾃﾑﾌﾞﾛｯｸｾｯﾄ
                .strSbID = pstrSBID
                
                '@Msgﾊﾞｰｼﾞｮﾝｾｯﾄ
                .strMsgVer = CMstrrtclchgstat_Ver
                
                '@「返却」「再入荷」が押下された場合
                If lstrBtnName = CMstrChgStat1 Or lstrBtnName = CMstrChgStat2 Then
                    '@処理区分(06)
                    .strClassDivison = CPstrCD06
                Else
                    '@処理区分(1M)
                    .strClassDivison = CPstrCD1M
                End If
                
                '@ﾚﾁｸﾙIDｾｯﾄ
                .strReticleID = vsfRtclListMente.GetData(vsfRtclListMente.Row, CMlngvsfRtclListMenteRtclID)
                
                '@押下されたﾎﾞﾀﾝによって処理分岐
                Select Case lstrBtnName
                    '@「返却」ﾎﾞﾀﾝの場合
                    Case CMstrChgStat1
                        '@ﾚﾁｸﾙ状態項目IDをｾｯﾄ(1:要検査)
                        .strReticleStatusItemName = CMstrStatus1
                        
                    '@「再入荷」ﾎﾞﾀﾝの場合
                    Case CMstrChgStat2
                        '@ﾚﾁｸﾙ状態項目IDをｾｯﾄ(4:返却中)
                        .strReticleStatusItemName = CMstrStatus4
                        
                    '@「ｺﾞﾐ検NG」「ｺﾞﾐ検OK」の場合
                    Case CMstrChgStat3, CMstrChgStat4
                        .strReticleStatusItemName = vbNullString
                End Select
                
                '@押下されたﾎﾞﾀﾝによって処理分岐
                Select Case lstrBtnName
                    '@「返却」「再入荷」ﾎﾞﾀﾝの場合
                    Case CMstrChgStat1, CMstrChgStat2
                        .strGarbageInspection = vbNullString
                        
                    '@「ｺﾞﾐ検NG」の場合
                    Case CMstrChgStat3
                        '@"NG"をｾｯﾄ
                        .strGarbageInspection = CMstrGarbageInspectionNG
                        
                    '@「ｺﾞﾐ検OK」の場合
                    Case CMstrChgStat4
                        '@"OK"をｾｯﾄ
                        .strGarbageInspection = CMstrGarbageInspectionOK
                End Select
                
                '@作業者ID
                .strEmpID = pstrUserID
                
                '@最終更新日時
                .strEditTime = vsfRtclListMente.GetData(vsfRtclListMente.Row, CMlngvsfRtclListMenteEditTimeWk)
            End With
            
            '@ﾚﾁｸﾙ状態変更実行
            lblnAns = pubblnReticleChgStatus_Ins(ltypRtclChgState)
            '@結果判定
            If lblnAns = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001Q, ltypRtclChgState.strReticleID)
                
                '@pubVsfInfo_Disp("<TRM1QI>$$ﾚﾁｸﾙ[ %1 ]の状態を変更しました。")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ﾚﾁｸﾙﾒﾝﾃﾅﾝｽTab最新情報取得処理へ
                Call cmdNowListMente_Click(Me, New EventArgs())
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                

                '@ﾌｫｰｶｽ戻り位置を設定
        '@↓2012/01/24 (Tue) 13:23:42 T.Oide **************************************************
        '        Call prvFocus_Set(vsfRtclListMente, lstrKeyID, CMlngvsfRtclListMenteRtclID, llngTopRow)
                Call pubGridFocus_Set(vsfRtclListMente, lstrKeyID, CMlngvsfRtclListMenteRtclID, cmdClose)
        '@↑2012/01/24 (Tue) 13:23:42 T.Oide **************************************************
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(lstrFormName, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvRtclChgStat_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2007/07/05 (Thu) 14:48:31 N.Kasai **************************************************
    ''関数名：prvcmdLeft_Proc
    ''機　能：ｸﾞﾘｯﾄﾞの左へﾌｫｰｶｽ移動処理
    ''引　数：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    ''　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    ''　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    ''戻り値：なし
    ''作成日：2004/10/25 (Mon) 15:42:02 N.Kasai
    ''更新日：2004/10/25 (Mon) 15:42:02 N.Kasai
    ''備　考：
    'Public Sub prvcmdLeft_Proc(ByVal lobjvsfGrid As Object, _
    '                           Optional ByVal lobjcmdLeft As Object = Nothing, _
    '                           Optional ByVal lobjcmdRight As Object = Nothing)
    '
    '    Dim llngLeftCol         As Long     '画面表示最左Col番号
    '    Dim llngLeftColCal      As Long     '計算後の最左Col番号
    '    Dim llngRightCol        As Long     '画面表示最右Col番号
    '    Dim llngMinCol          As Long     '固定Col数
    '    Dim llngMaxCol          As Long     'Col総数
    '    Dim llngHideStartCol    As Long     '表示変動開始Col番号
    '    Dim llngRow             As Long     '取得Row番号
    '    Dim llngloopcount       As Long     'ループｶｳﾝﾄ
    '    Dim llngWidthAll        As Long     'Col全体の幅
    '    Dim llngWidthHide       As Long     'ｽｸﾛｰﾙで隠れたColの幅
    '    Dim llngWidth           As Long     'Colの幅
    '
    '    On Error GoTo Error_Handler
    '
    '    '@初期設定
    '    llngLeftCol = 0
    '    llngLeftColCal = 0
    '    llngRightCol = 0
    '    llngMinCol = 0
    '    llngMaxCol = 0
    '    llngHideStartCol = 0
    '    llngloopcount = 0
    '    llngWidthAll = 0
    '    llngWidthHide = 0
    '    llngWidth = 0
    '
    '    '@横ｽｸﾛｰﾙ発生ﾌﾗｸﾞによる処理分岐
    '    If mlngSideScrollFlag = CMlngSideScrollOffFlag Then
    '        Exit Sub
    '    End If
    '
    '    With lobjvsfGrid
    '        '@画面表示最左Col番号取得
    '        llngLeftCol = .LeftCol
    '
    '        '@画面表示最右Col番号取得
    '        llngRightCol = .RightCol
    '
    '        '@固定Col番号取得(=.FrozenCols:固定列数 -1)
    '        llngMinCol = .FrozenCols - 1
    '
    '        '@ｽｸﾛｰﾙで隠れるCol番号取得
    '        llngHideStartCol = llngMinCol + 1
    '
    '        '@一覧ｽｸﾛｰﾙ制御
    '        '@ｸﾞﾘｯﾄﾞの固定列より,可動する列(最左)が小さい場合
    '        If llngLeftCol > llngMinCol Then
    '            llngLeftColCal = llngLeftCol - 1
    '            .ShowCell llngRow, llngLeftColCal
    '        Else
    '            '@ｸﾞﾘｯﾄﾞの固定列と,可動する列(最左)が同じ場合
    '            If llngLeftCol = llngMinCol Then
    '                llngLeftColCal = llngLeftCol
    '                .ShowCell llngRow, llngLeftColCal
    '            End If
    '        End If
    '
    '        '@最大Col番号取得(非表示項目含まない)
    '        For llngloopcount = 0 To .Cols - 1
    '            If .ColHidden(llngloopcount) <> True Then
    '                llngMaxCol = llngMaxCol + 1
    '            End If
    '        Next llngloopcount
    '
    '        '@全列数の幅取得(非表示項目は含めない)
    '        For llngloopcount = 0 To .Cols - 1
    '            If .ColHidden(llngloopcount) <> True Then
    '                llngWidthAll = llngWidthAll + .ColWidth(llngloopcount)
    '            End If
    '        Next llngloopcount
    '
    '        '@ｽｸﾛｰﾙで隠れた列の幅を取得
    '        For llngloopcount = llngHideStartCol To llngLeftColCal - 1
    '            llngWidthHide = llngWidthHide + .ColWidth(llngloopcount)
    '        Next llngloopcount
    '
    '        '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御(右側)
    '        llngWidth = llngWidthAll - llngWidthHide
    '        '@ｸﾞﾘｯﾄﾞの全体幅より、表示使用としている全列幅が大きい場合
    '        If .Width - llngWidth <= 0 Then
    '            lobjcmdRight.Enabled = True
    '        Else
    '            lobjcmdRight.Enabled = False
    '        End If
    '
    '        '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御(左側)
    '        '@可動する列(最左)と,隠れている列が同じ場合
    '        If llngLeftColCal = llngHideStartCol Then
    '            lobjcmdLeft.Enabled = False
    '        Else
    '            lobjcmdLeft.Enabled = True
    '        End If
    '
    '        '@ﾌｫｰｶｽをｾｯﾄ
    '        Call pubSetFocus(lobjvsfGrid)
    '    End With
    '
    '    Exit Sub
    '
    'Error_Handler:
    '
    '    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '    With ptypOnErrorInfo
    '        .strMenuKey = CMstrLocalMenuKey
    '        .strProcName = "prvcmdLeft_Proc"
    '        .strErrMessage = vbNullString
    '    End With
    '
    '    '@共通ｴﾗｰ処理
    '    Call pubOnError_Proc
    '
    'End Sub
    '
    ''関数名：prvcmdRight_Proc
    ''機　能：ｸﾞﾘｯﾄﾞの右へﾌｫｰｶｽ移動
    ''引　数：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    ''　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    ''　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    ''戻り値：なし
    ''作成日：2004/10/25 (Mon) 15:43:09 N.Kasai
    ''更新日：2004/10/25 (Mon) 15:43:09 N.Kasai
    ''備　考：
    'Public Sub prvcmdRight_Proc(ByVal lobjvsfGrid As Object, _
    '                            Optional ByVal lobjcmdLeft As Object = Nothing, _
    '                            Optional ByVal lobjcmdRight As Object = Nothing)
    '
    '    Dim llngLeftCol         As Long     '画面表示最左Col番号
    '    Dim llngLeftColCal      As Long     '計算後の最左Col番号
    '    Dim llngMinCol          As Long     '固定Col数
    '    Dim llngMaxCol          As Long     'Col総数
    '    Dim llngHideStartCol    As Long     '表示変動開始Col番号
    '    Dim llngloopcount       As Long     'ループｶｳﾝﾄ
    '    Dim llngWidthAll        As Long     'Col全体の幅
    '    Dim llngWidthHide       As Long     'ｽｸﾛｰﾙで隠れたColの幅
    '    Dim llngWidth           As Long     'Colの幅
    '
    '    On Error GoTo Error_Handler
    '
    '    '@初期設定
    '    llngLeftCol = 0
    '    llngLeftColCal = 0
    '    llngMinCol = 0
    '    llngMaxCol = 0
    '    llngHideStartCol = 0
    '    llngloopcount = 0
    '    llngWidthAll = 0
    '    llngWidthHide = 0
    '    llngWidth = 0
    '
    '    '@横ｽｸﾛｰﾙ発生ﾌﾗｸﾞによる処理分岐
    '    If mlngSideScrollFlag = CMlngSideScrollOffFlag Then
    '        Exit Sub
    '    End If
    '
    '    With lobjvsfGrid
    '        '@ｽｸﾛｰﾙ制御(最終列直前まで)
    '        llngLeftCol = .LeftCol
    '        llngLeftColCal = llngLeftCol + 1
    '        .LeftCol = llngLeftColCal
    '
    '        '@固定Col番号取得(=.FrozenCols:固定列数 -1)
    '        llngMinCol = .FrozenCols - 1
    '
    '        '@ｽｸﾛｰﾙで隠れるCol番号取得
    '        llngHideStartCol = llngMinCol + 1
    '
    '        '@最大Col番号取得(非表示項目含まない)
    '        For llngloopcount = 0 To .Cols - 1
    '            If .ColHidden(llngloopcount) <> True Then
    '                llngMaxCol = llngMaxCol + 1
    '            End If
    '        Next llngloopcount
    '
    '        '@全列数の幅取得(非表示項目は含めない)
    '        For llngloopcount = 0 To .Cols - 1
    '            If .ColHidden(llngloopcount) <> True Then
    '                llngWidthAll = llngWidthAll + .ColWidth(llngloopcount)
    '            End If
    '        Next llngloopcount
    '
    '        '@ｽｸﾛｰﾙで隠れた列の幅を取得
    '        For llngloopcount = llngHideStartCol To llngLeftCol
    '            llngWidthHide = llngWidthHide + .ColWidth(llngloopcount)
    '        Next llngloopcount
    '
    '        '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御(右側)
    '        llngWidth = llngWidthAll - llngWidthHide + 75
    '        '@ｸﾞﾘｯﾄﾞの全体幅より、表示使用としている全列幅が大きい場合
    '        If .Width - llngWidth <= 0 Then
    '            lobjcmdRight.Enabled = True
    '        Else
    '            lobjcmdRight.Enabled = False
    '        End If
    '
    '        '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御(左側)
    '        '@可動する列(最左)と,隠れている列が同じ場合
    '        If llngLeftColCal = llngHideStartCol Then
    '            lobjcmdLeft.Enabled = False
    '        Else
    '            lobjcmdLeft.Enabled = True
    '        End If
    '
    '        '@ﾌｫｰｶｽをｾｯﾄ
    '        Call pubSetFocus(lobjvsfGrid)
    '    End With
    '
    '
    '    Exit Sub
    '
    'Error_Handler:
    '
    '    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '    With ptypOnErrorInfo
    '        .strMenuKey = CMstrLocalMenuKey
    '        .strProcName = "prvcmdRight_Proc"
    '        .strErrMessage = vbNullString
    '    End With
    '
    '    '@共通ｴﾗｰ処理
    '    Call pubOnError_Proc
    '
    'End Sub
    '
    ''関数名：prvvsfSideKeyDown_Proc
    ''機　能：ｸﾞﾘｯﾄﾞｷｰ制御
    ''引　数：lintKeyCode：ｷｰｺｰﾄﾞ
    ''　　　：lstrActiveCtlNm：ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名
    ''　　　：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    ''　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    ''　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    ''戻り値：なし
    ''作成日：2004/10/26 (Tue) 17:57:06 N.Kasai
    ''更新日：2004/10/26 (Tue) 17:57:06 N.Kasai
    ''備　考：※FrozenColsを使用していないこと
    'Public Sub prvvsfSideKeyDown_Proc(ByRef lintKeyCode As Integer, _
    '                                  ByVal lstrActiveCtlNm As String, _
    '                                  ByVal lobjvsfGrid As Object, _
    '                                  Optional ByVal lobjcmdLeft As Object = Nothing, _
    '                                  Optional ByVal lobjcmdRight As Object = Nothing)
    '
    '    Dim llngRow             As Long     'ｶｳﾝﾄ
    '    Dim llngActiveCol       As Long     'ﾌｫｰｶｽがあたっているCol番号
    '    Dim llngLeftCol         As Long     '画面表示最左Col番号
    '    Dim llngLeftColCal      As Long     '計算後の最左Col番号
    '    Dim llngMinCol          As Long     '固定Col数(最小Col数)
    '    Dim llngMaxCol          As Long     'Col総数
    '    Dim llngHideStartCol    As Long     '表示変動開始Col番号
    '    Dim llngLoopCol         As Long     'ﾙｰﾌﾟｶｳﾝﾄ用Col番号
    '    Dim llngloopcount       As Long     'ﾙｰﾌﾟｶｳﾝﾄ
    '    Dim llngWidthAll        As Long     'Col全体の幅
    '    Dim llngWidthHide       As Long     'ｽｸﾛｰﾙで隠れるColの幅
    '    Dim llngWidth           As Long     'Colの幅(計算結果)
    '
    '    On Error GoTo Error_Handler
    '
    '    '@初期設定
    '    llngLeftCol = 0
    '    llngLeftColCal = 0
    '    llngMinCol = 0
    '    llngMaxCol = 0
    '    llngHideStartCol = 0
    '    llngLoopCol = 0
    '    llngloopcount = 0
    '    llngWidthAll = 0
    '    llngWidthHide = 0
    '    llngWidth = 0
    '
    '    '@横ｽｸﾛｰﾙ発生ﾌﾗｸﾞによる処理分岐
    '    If mlngSideScrollFlag = CMlngSideScrollOffFlag Then
    '        Exit Sub
    '    End If
    '
    '    With lobjvsfGrid
    '        '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ判定
    '        Select Case lstrActiveCtlNm
    '            '@ｸﾞﾘｯﾄﾞﾌｫｰｶｽがある場合
    '            Case .Name
    '                '@ｷｰｺｰﾄﾞ判定
    '                Select Case lintKeyCode
    '                   '@ｸﾞﾘｯﾄﾞｷｰ制御([←]ｷｰﾎﾞﾀﾝ)
    '                    Case vbKeyLeft
    '                        '@画面表示最左Col番号取得
    '                        llngLeftCol = .LeftCol
    '
    '                        '@ﾌｫｰｶｽがあたっているCol番号取得
    '                        llngActiveCol = .Col
    '
    '                        '@固定Col番号取得(.FrozenCols:固定列数 -1)
    '                        llngMinCol = .FrozenCols - 1
    '
    '                        '@ｽｸﾛｰﾙで隠れるCol番号取得
    '                        llngHideStartCol = llngMinCol + 1
    '
    '                        '@最大Col番号取得(非表示項目含まない)
    '                        For llngloopcount = 0 To .Cols - 1
    '                            '@非表示列ではない場合
    '                            If .ColHidden(llngloopcount) <> True Then
    '                                llngMaxCol = llngMaxCol + 1
    '                            End If
    '                        Next llngloopcount
    '
    '                        '@全列数の幅取得(非表示項目は含めない)
    '                        For llngloopcount = 0 To llngMaxCol - 1
    '                            If .ColHidden(llngloopcount) <> True Then
    '                                llngWidthAll = llngWidthAll + .ColWidth(llngloopcount)
    '                            End If
    '                        Next llngloopcount
    '
    '                        '@ｽｸﾛｰﾙで隠れた列の幅を取得
    '                        For llngloopcount = llngHideStartCol To llngLeftCol - 1
    '                            llngWidthHide = llngWidthHide + .ColWidth(llngloopcount)
    '                        Next llngloopcount
    '
    '                        '@表示されている列の幅を取得
    '                        llngWidth = llngWidthAll - llngWidthHide
    '
    '                        '@ｽｸﾛｰﾙ制御
    '                        '@ﾌｫｰｶｽｾﾙの列場所による処理分岐
    '                        If llngActiveCol = llngLeftCol Then
    '                            '@現在の列より固定列が小さい場合
    '                            If llngLeftCol > llngMinCol Then
    '                                llngLeftColCal = llngLeftCol - 1
    '                                '@ﾌｫｰｶｽｾﾙがﾏｲﾅｽの場合は0をｾｯﾄ
    '                                If llngLeftColCal < 0 Then
    '                                    llngLeftColCal = 0
    '                                End If
    '                                '@表示列を設定
    '                                .ShowCell llngRow, llngLeftColCal
    '                            Else
    '                                '@現在の列と固定列が同じ場合
    '                                If llngLeftCol = llngMinCol Then
    '                                    llngLeftColCal = llngLeftCol
    '                                    '@表示列を設定
    '                                    .ShowCell llngRow, llngLeftColCal
    '                                End If
    '                            End If
    '                            '@>>、<<ﾎﾞﾀﾝを有効
    '                            lobjcmdRight.Enabled = True
    '                            lobjcmdLeft.Enabled = True
    '                        End If
    '
    '                        '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御
    '                        '@ﾌｫｰｶｽｾﾙの列場所による処理分岐
    '                        If llngActiveCol <= llngMinCol + 2 Then
    '                            '@<<ﾎﾞﾀﾝを無効
    '                            lobjcmdLeft.Enabled = False
    '                            '@>>ﾎﾞﾀﾝを有効
    '                            lobjcmdRight.Enabled = True
    '                        Else
    '                            '@現在の列と最大列が同じ場合
    '                            If llngActiveCol = llngMaxCol Then
    '                                '@<<ﾎﾞﾀﾝを有効
    '                                lobjcmdLeft.Enabled = True
    '                                '@>>ﾎﾞﾀﾝを無効
    '                                lobjcmdRight.Enabled = False
    '                            End If
    '                        End If
    '
    '                   '@ｸﾞﾘｯﾄﾞｷｰ制御([→]ｷｰﾎﾞﾀﾝ)
    '                    Case vbKeyRight
    '                        '@画面表示最左Col番号取得
    '                        llngLeftCol = .LeftCol
    '
    '                        '@ﾌｫｰｶｽがあたっているCol番号取得
    '                        llngActiveCol = .Col
    '
    '                        '@固定Col番号取得(.FrozenCols:固定列数 -1)
    '                        llngMinCol = .FrozenCols - 1
    '
    '                        '@最大Col番号取得(非表示項目含まない)
    '                        For llngloopcount = 0 To .Cols - 1
    '                            '@非表示列ではない場合
    '                            If .ColHidden(llngloopcount) <> True Then
    '                                llngMaxCol = llngMaxCol + 1
    '                            End If
    '                        Next llngloopcount
    '
    '                        '@全列数の幅取得(非表示項目は含めない)
    '                        For llngloopcount = 0 To llngMaxCol - 1
    '                            '@非表示列ではない場合
    '                            If .ColHidden(llngloopcount) <> True Then
    '                                llngWidthAll = llngWidthAll + .ColWidth(llngloopcount)
    '                            End If
    '                        Next llngloopcount
    '
    '                        '@ｽｸﾛｰﾙ制御用幅計算
    '                        '@現在の右隣列が最大列以上の場合
    '                        If llngActiveCol + 1 >= llngMaxCol Then
    '                            llngLoopCol = llngMaxCol
    '                        Else
    '                            llngLoopCol = llngActiveCol + 1
    '                        End If
    '
    '                        '@ｽｸﾛｰﾙ制御
    '                        If .Width <= llngWidthAll Then
    '                            '@ﾌｫｰｶｽがあたっているｾﾙが固定列以下の場合には左右ﾎﾞﾀﾝ活性化
    '                            If llngActiveCol <= llngMinCol Then
    '                                llngLeftCol = .LeftCol
    '                                .LeftCol = llngLeftCol
    '                            Else
    '                                llngLeftCol = .LeftCol
    '                                llngLeftColCal = llngLeftCol + 1
    '                                .LeftCol = llngLeftColCal
    '                            End If
    '                            '@>>、<<ﾎﾞﾀﾝを有効
    '                            lobjcmdRight.Enabled = True
    '                            lobjcmdLeft.Enabled = True
    '                        End If
    '
    '                        '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御
    '                        '@現在の行と固定列が同じ場合
    '                        If llngActiveCol = llngMinCol Then
    '                            lobjcmdLeft.Enabled = False
    '                            lobjcmdRight.Enabled = True
    '                        Else
    '                            '@現在の列が最大列数の左隣以上の場合
    '                            If llngActiveCol >= llngMaxCol - 2 Then
    '                                '@<<ﾎﾞﾀﾝを有効
    '                                lobjcmdLeft.Enabled = True
    '                                '@>>ﾎﾞﾀﾝを無効
    '                                lobjcmdRight.Enabled = False
    '                            End If
    '                            '@最終行-1Colからのﾌｫｰｶｽ移動の場合
    '                            If llngActiveCol = .Cols - 2 Then
    '                                '@最終colへﾌｫｰｶｽ移動
    '                                .ShowCell llngRow, .Cols - 1
    '                                '@ﾌｫｰｶｽをｾｯﾄ
    '                                Exit Sub
    '                            End If
    '                            '@最終colからのﾌｫｰｶｽ移動
    '                            If llngActiveCol = .Cols - 1 Then
    '                                '@最終colへﾌｫｰｶｽ移動
    '                                .ShowCell llngRow, .Cols - 1
    '                                '@ﾌｫｰｶｽをｾｯﾄ
    '                                Exit Sub
    '                            End If
    '                        End If
    '
    '                        '@ﾌｫｰｶｽをｾｯﾄ
    '                        Call pubSetFocus(lobjvsfGrid)
    '                End Select
    '        End Select
    '    End With
    '
    '    Exit Sub
    '
    'Error_Handler:
    '
    '    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '    With ptypOnErrorInfo
    '        .strMenuKey = CMstrLocalMenuKey
    '        .strProcName = "prvvsfSideKeyDown_Proc"
    '        .strErrMessage = vbNullString
    '    End With
    '
    '    '@共通ｴﾗｰ処理
    '    Call pubOnError_Proc
    '
    'End Sub
    '@↑2007/07/05 (Thu) 14:48:31 N.Kasai **************************************************

    '関数名：prvcmbStockerName_Disp
    '機　能：ｽﾄｯｶｰ表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/30 (Tue) 11:57:52 N.Kasai
    '更新日：2004/11/30 (Tue) 11:57:52 N.Kasai
    '備　考：
    Private Sub prvcmbStockerName_Disp()
        
        Dim lblnAns             As Boolean  '戻り値
        Dim llngCnt             As Integer  'ｶｳﾝﾄ
        Dim lstrEventName       As String   'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrFormName        As String   'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrClassDivision   As String   '処理区分

        Try
            
            With cmbStockerName
                '@ｽﾄｯｶｰ初期化
                .Clear
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                   'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbValueCol                                    '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily,CMlngCmbFontSize)             'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily,CMlngCmbGridFontSize) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え
                .GroupCols = CMlngCmbGroupCols
                .Enabled = True                                                 '有効
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                lstrEventName = "prvcmbStockerName_Disp"
                '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
                lstrFormName = Me.Name
                
                Call pubResponseStart(lstrFormName, lstrEventName)
                
                '@処理区分の設定
                lstrClassDivision = CPstrCD2J '2J；ﾚﾁｸﾙｽﾄｯｶｰのみ

                '@ｽﾄｯｶﾏｽﾀ取得
                lblnAns = pubblnMasStockerList_Sel(mtypStockerList, _
                                                   CMstrmas_stockerlistVer, _
                                                   mlngStockerListCnt, _
                                                   lstrClassDivision)
                '@戻り値判定
                If lblnAns = True Then
                    '@ｽﾄｯｶｰｺﾝﾎﾞの活性化
                    .Enabled = True
                    
                    '@ｽﾄｯｶｰｾｯﾄ
                    For llngCnt = 0 To mlngStockerListCnt-1
                        '@ﾘｽﾄに項目追加
                        .AddItem(mtypStockerList(llngCnt).strStockerName & _
                                 vbTab & _
                                 mtypStockerList(llngCnt).strStockerId & _
                                 vbTab & _
                                 llngCnt)                                        'ｽﾄｯｶｰ & ｽﾄｯｶID & 現在のｶｳﾝﾄ数
                    Next llngCnt
                                 
                                       
                    '@ﾘｽﾄが1件の場合は直接表示
                    If .ListCount = 1 Then
                        '@表示
                        .ListIndex = 0
                    End If
                Else
                    '@ｽﾄｯｶｰｺﾝﾎﾞの非活性化
                    .Enabled = False
                    
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

    '関数名：prvstrTimeFormat_Set
    '機　能：日付ﾌｫｰﾏｯﾄ
    '引　数：lstrEditTime：EDIT_TIME
    '戻り値：ﾌｫｰﾏｯﾄ編集後EditTime
    '作成日：2005/05/31 (Tue) 12:40:22 N.Kasai
    '更新日：2005/05/31 (Tue) 12:40:22
    '備　考：
    Private Function prvstrTimeFormat_Set(ByVal lstrEditTime As String) As String

        Try

            '@編集前EDIT_TIMEを格納
            prvstrTimeFormat_Set = lstrEditTime
            
            '@空白の場合は編集なし
            If lstrEditTime = vbNullString Then
                Exit Function
            End If
            
            '@ﾋﾟﾘｵﾄﾞが発見できない場合は編集なし
            If InStr(lstrEditTime, CPstrAppVerPeriod) = 0 Then
                Exit Function
            End If

            '@EDIT_TIME編集("2005/04/13 12:57:58.489"→"2005/04/13 12:57:58")
            prvstrTimeFormat_Set = Strings.Left$(lstrEditTime, InStr(lstrEditTime, CPstrAppVerPeriod) - 1)

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvstrTimeFormat_Set"
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
                

        End Select

        MyBase.WndProc(m)

        If lblnSysCommandScClose = True Then
            'NSYS SC_CLOSE 処理後 WM_CLOSE が発生しないでキャンセルされることもあるため、フラグを戻す
            'NSYS WM_CLOSE が発生していれば、すでにこの時点では画面は閉じている
            mblnCloseFromControlMenu = False
        End If        
    End Sub


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Frame1.Paint, Frame2.Paint, Frame3.Paint, Frame4.Paint, Frame5.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfRtclListMente.BeforeDoubleClick, vsfRtclListRegist.BeforeDoubleClick, vsfRtclListWpIn.BeforeDoubleClick

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True

        End If

    End Sub

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
                                                                       cmdClose.Enter,
                                                                       vsfRtclListWpIn.Enter,
                                                                       cmbWplist.Enter,
                                                                       cmdNowListWpIn.Enter,
                                                                       cmdDown3.Enter,
                                                                       cmdUP3.Enter,
                                                                       cmdRight3.Enter,
                                                                       cmdLeft3.Enter,
                                                                       vsfRtclListRegist.Enter,
                                                                       cmdRtclIDCopy.Enter,
                                                                       cmdNowListRegist.Enter,
                                                                       cmbPdCodeRegist.Enter,
                                                                       cmbMaskPatternRegist.Enter,
                                                                       cmbStockerName.Enter, 
                                                                       txtNewRtclID.Enter,
                                                                       cmdLeft1.Enter,
                                                                       cmdRight1.Enter,
                                                                       cmdUP1.Enter,
                                                                       cmdDown1.Enter,
                                                                       vsfRtclListRegist.Enter,
                                                                       cmdRegist.Enter,
                                                                       tabReticle.Enter,
                                                                       dtpArriveTime.Enter
        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF
            Case cmdClose.Name,tabReticle.Name 
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub
    '関数名：Form_activate
    '機　能：FORM更新
    '引　数：
    '戻り値：なし
    '作成日：2009/04/23 (Thu) 14:23:06 KK
    '更新日：
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            'NSYS フォームロード初回のみ
            If mblnFormLoad1st = True Then

                mblnFormLoad1st = False
                '機種にフォーカス移動
                Call pubSetFocus(cmbPdCodeRegist)

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_activate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
              
        End Try
    End Sub

End Class
